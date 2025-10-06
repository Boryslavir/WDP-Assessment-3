// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.getElementById('body-dalle-card').addEventListener('mouseover', function(tag) {
    if (tag.target.tagName === 'IMG') {
        this.innerHTML = `<p>DALL-E 3</p>`;
    }
});

document.getElementById('body-dalle-card').addEventListener('mouseout', function(tag) {
    if (!this.contains(tag.relatedTarget)) {
        this.innerHTML = '<img src="/img/dalle.webp" alt="DALL-E Logo" />';
    }
});

document.getElementById('body-midjourney-card').addEventListener('mouseover', function(tag) {
    if (tag.target.tagName === 'IMG') {
        this.innerHTML = `<p>Mid Journey</p>`;
    }
});

document.getElementById('body-midjourney-card').addEventListener('mouseout', function(tag) {
    if (!this.contains(tag.relatedTarget)) {
        this.innerHTML = '<img src="/img/midjourney.webp" alt="MidJourney Logo" />';
    }
});

