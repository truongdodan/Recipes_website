//move top recipes section horizontally
const slider = document.querySelector(".top-cards")
const sliderWrapper = document.querySelector(".top-recipes-wrapper .overflow-wrapper")
const leftArrow = document.querySelector(".top-content-wrapper > img:first-child")
const rightArrow = document.querySelector(".top-content-wrapper > img:last-child")
let topIndex = 2 //recipe lie in the center of the top recipe
let start = 0

leftArrow.addEventListener("click", (e) => {
    if (topIndex <= 2) return

    start += 10
    slider.style.transform = `translateX(${start}%)`;
    topIndex--
})
rightArrow.addEventListener("click", (e) => {
    if (topIndex >= 9) return

    start -= 10
    slider.style.transform = `translateX(${start}%)`
    topIndex++
})
