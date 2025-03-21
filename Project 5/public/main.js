

let login = false

function makeQuery(obj) {
    return '?' + Object.entries(obj).map(([k, v]) => encodeURIComponent(k) + '=' + encodeURIComponent(v)).join('&')
}

function Login() {
    fetch('/login/' + makeQuery({
        login: document.getElementById("login").value,
        password: document.getElementById("password").value
    }))
        .then(x => x.json())
        .then(AuthHandler)
}

function AuthHandler({ login, isAdmin, err }) {
    if (err)
        return


    window.location.href = (isAdmin ? 'admin' : 'user') + '.html' + makeQuery({ login });
}

function Register() {
    fetch('/register/' + makeQuery({
        login: document.getElementById("login").value,
        password: document.getElementById("password").value,
        fullname: document.getElementById("fullname").value,
        phone: document.getElementById("phone").value,
        email: document.getElementById("email").value
    }))
        .then(x => x.json())
        .then(AuthHandler)

}

const button = document.getElementById("button");

function showLogin() {
    login = true
    document.getElementById("loginForm").classList.remove("hidden");
    document.getElementById("passwordForm").classList.remove("hidden");
    document.getElementById("fullnameForm").classList.add("hidden");
    document.getElementById("phoneForm").classList.add("hidden");
    document.getElementById("emailForm").classList.add("hidden");
    document.getElementById("button").textContent = "Войти";
}

function showRegister() {
    login = false
    document.getElementById("loginForm").classList.remove("hidden");
    document.getElementById("passwordForm").classList.remove("hidden");
    document.getElementById("fullnameForm").classList.remove("hidden");
    document.getElementById("phoneForm").classList.remove("hidden");
    document.getElementById("emailForm").classList.remove("hidden");
    document.getElementById("button").textContent = "Зарегистрироваться";
}

showRegister()
button.addEventListener('click', () => (login ? Login : Register)());