//COMMENT FORM
const addCommentBtn = document.querySelector(".add-comment")
const commentFormWrapper = document.querySelector(".comment-form-wrapper")
const commentForm = document.querySelector(".comment-form-wrapper .comment-form")
const textArea = document.querySelector("#addCommentText")
const commentImage = document.querySelector(".added-comment-image > input")
const errorMsg = document.querySelector(".comment-form-wrapper .input-error")
const addedCommentImage = document.querySelector(".added-comment-image")
const addFile = document.querySelector("#addedCommentImage")
const imageContainer = document.querySelector(".custom-file-upload")
const cameraIcon = document.querySelector(".added-comment-image > label img")

//show form
function turnOnForm() {
    const commentFormWrapper = document.querySelector(".comment-form-wrapper")
    commentFormWrapper.style.display = "flex"
}

//turn off form, reset input in form
function turnOffForm() {
    //select again cuz the update panel will refresh, make these null - i think?
    const commentFormWrapper = document.querySelector(".comment-form-wrapper")
    const errorMsg = document.querySelector(".comment-form-wrapper .input-error")
    const imageContainer = document.querySelector(".custom-file-upload")
    const cameraIcon = document.querySelector(".added-comment-image > label img")
    const textArea = document.querySelector("#addCommentText")

    commentFormWrapper.style.display = "none"
    errorMsg.style.display = "none"
    imageContainer.style.backgroundImage = "none"
    cameraIcon.style.display = "block"
    textArea.value = ""
}

//submit form
function submitForm(e) {
    const textArea = document.querySelector("#addCommentText")
    const commentImage = document.querySelector(".added-comment-image > input")
    const errorMsg = document.querySelector(".comment-form-wrapper .input-error")

    /*if ((textArea.value == "" || textArea.value == null) || commentImage.files.length == 0) {
        errorMsg.style.display = "block"
        return false;
    }*/

    if ((textArea.value == "" || textArea.value == null)) {
        errorMsg.style.display = "block"
        return false;
    }
    
    return true;
}

//show preview image that user choose
/*addFile.addEventListener("change", (e) => {
    imageContainer.style.backgroundImage = "url(" + URL.createObjectURL(e.target.files[0]) + ")"
    imageContainer.classList.add("has-image")
    cameraIcon.style.display = "none"

})*/
function showChosenImage(e) {
    const imageContainer = document.querySelector(".custom-file-upload")
    const cameraIcon = document.querySelector(".added-comment-image > label img")
    imageContainer.style.backgroundImage = "url(" + URL.createObjectURL(e.target.files[0]) + ")"
    imageContainer.classList.add("has-image")
    cameraIcon.style.display = "none"
    console.log("changed")
}


//CHANGE STAR COLOR WHEN CLICK
function changeStarColor(e) {
    const starCounter = document.querySelector(".comment-form .review-infor input")  //select star counter to get review value in code-behind c#

    if (e.target.classList.contains("active")) {
        e.target.src = "./icon/star.svg";
        e.target.classList.toggle("active")
        starCounter.value -= 1
        return;
    }

    e.target.src = "./icon/star_yellow.svg"
    e.target.classList.toggle("active")
    starCounter.value += 1
}

