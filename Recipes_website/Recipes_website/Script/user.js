
//toggle menu tab
const savedRecipeTab = document.querySelector(".menu-tab div:first-child")
const createdRecipeTab = document.querySelector(".menu-tab div:last-child")

function toggleTab(e) {
    const savedRecipeTab = document.querySelector(".menu-tab div:first-child")
    const createdRecipeTab = document.querySelector(".menu-tab div:last-child")

    savedRecipeTab.classList.remove("selected")
    createdRecipeTab.classList.remove("selected")

    e.target.classList.add("selected")
}
