const express = require('express')
const app = express()
const port = 3000
const sqlite3 = require('sqlite3')
const { open } = require('sqlite')



app.use(express.static('./public/'))

app.get('/register/', (req, res) => {
    open({
        filename: './database.db',
        driver: sqlite3.Database
    }).then(async (db) => {
        db.run(`--sql
                INSERT INTO Users (Login, Password, FullName, Phone, Email)
                VALUES (?, ?, ?, ?, ?)    
            `, req.query.login, req.query.password, req.query.fullname, req.query.phone, req.query.email)
            .then(
                () => res.json({
                    login: req.query.login,
                    isAdmin: false
                }),
                () => res.status(400).json({
                    err: 'invalid data'
                })
            )

    })
})

app.get('/login/', (req, res) => {
    const login = req.query.login
    const password = req.query.password
    open({
        filename: './database.db',
        driver: sqlite3.Database
    }).then(async (db) => {
        db.get(`--sql
                SELECT * FROM Users WHERE login = ? AND password = ?
            `, login, password)
            .then(
                user => user ? res.json({
                    login,
                    isAdmin: user.IsAdmin
                }) : res.status(400).json({
                    err: 'invalid data'
                }),
            )

    })
})


app.listen(port, () => {
    console.log(`Example app listening on port ${port}`)
})
