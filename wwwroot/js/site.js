// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const setTheme = (theme) => {
    document.documentElement.className = theme;
    localStorage.setItem('theme', theme);
}

const getTheme = () => {
    const theme = localStorage.getItem('theme');
    theme && setTheme(theme);
}

getTheme();
document.getElementById('theme-select').addEventListener('change', function () {
    setTheme(this.value);
});
