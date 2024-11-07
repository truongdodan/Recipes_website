//toggle password
function showPassword() {
    const togglePasswordCkBox = document.getElementById("togglePassword")
    const passwordInput = document.querySelectorAll(".password-wrapper > input")

    if (togglePasswordCkBox.checked) {
        passwordInput.forEach(input => {
            input.type = "text"
        })
    }
    else {
        passwordInput.forEach(input => {
            input.type = "password"
        })
    }

}

//regex for password

//check confirm password
function checkConfirmPassword(e) {
    const password = document.getElementById("password")
    const passwordConfirm = document.getElementById("passwordConfirm")
    const errorMessage = document.querySelector(".error-message-signup")
    const signupSuccessfulMessage = document.querySelector(".signup-success-notification")


    if (passwordConfirm.value === password.value) {
        errorMessage.style.display = "none"

        //signup successfully notification snackbar
        signupSuccessfulMessage.classList.add("show")
        setTimeout(function () {
            signupSuccessfulMessage.classList.remove("show")
        }, 3000)

        return true
    }

    e.preventDefault()
    errorMessage.style.display = "block"
    return false
}