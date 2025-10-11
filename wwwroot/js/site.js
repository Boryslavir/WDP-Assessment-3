// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/**
 * Helper function to easily add card info to existen card UI elements
 * @param {string} selector     - search the card element by its class.
 * @param {string} url          - path to image that will be use for searched element.
 * @param {string} source       - reference for the image using APA7 style.
 * @param {string} id           - add 'id' attribute to the searched element.
 * @param {string} [size=100%]  - indicate how big/small the image size should be.
 * @return {null} either card info added or not found at all.
 */
function addCardInfo(
    selector,
    url,
    source,
    id,
    size = '100%'
) {
    const card = document.querySelector(selector);
        if (card) {
            card.addEventListener("mouseover", () => {
                // Hide background
                card.style.backgroundImage = 'none';

                // Create and append the <p>
                const info = document.createElement("p");
                info.className = 'text-center border border-light border-3 rounded-3 bg-dark';
                info.id = id;
                info.textContent = source;
                card.appendChild(info);
            });

            card.addEventListener("mouseout", () => {
                const info = document.getElementById(id);
                if (info) {
                    info.remove();

                    // Restore original background
                    card.style.backgroundColor = 'transparent';
                    card.style.backgroundImage = `url('${url}')`;
                    card.style.backgroundPosition = 'center';
                    card.style.backgroundSize = size;
                    card.style.backgroundRepeat = 'no-repeat';
                    card.style.backgroundOrigin = 'padding-box';
                    card.style.backgroundClip = 'border-box';
                    card.style.backgroundAttachment = 'scroll';
                } else {
                    return null;
                }
            });
    } else {
        return null;
    }
}

// Dynamically add multiple cards info
addCardInfo(
    '.dalle-card-1',
    '/img/dalle-1.webp',
    '(Dickson, 2024)',
    'dalle-card-1-info'
);
addCardInfo(
    '.dalle-card-2',
    '/img/dalle-2.webp',
    '(McKay, 2023)',
    'dalle-card-2-info'
);
addCardInfo(
    '.mid-journey-card-1',
    '/img/mid-journey-1.webp',
    '(Luices, 2023)',
    'mid-journey-card-1-info'
);
addCardInfo(
    '.mid-journey-card-2',
    '/img/mid-journey-2.webp',
    '(Kai｜生成AI, 2025)',
    'mid-journey-card-2-info'
);
addCardInfo(
    '.microsoft-designer-card-1',
    '/img/microsoft-designer-1.webp',
    '(Ondet, 2023)',
    'dmicrosoft-designer-card-1-info'
);
addCardInfo(
    '.microsoft-designer-card-2',
    '/img/microsoft-designer-2.webp',
    '(Dasher, 2024)',
    '.microsoft-designer-card-2-info',
);

document.addEventListener("DOMContentLoaded", () => {
    const aiDivs = document.querySelectorAll("[data-image]"); // select all divs with data-image

    aiDivs.forEach(div => {
        const imageFile = div.dataset.image;
        div.style.transition = "background 2s ease";

        div.addEventListener("mouseenter", () => {
            div.style.backgroundImage = `url('/img/${imageFile}')`;
            div.style.backgroundPosition = "center";
            div.style.backgroundSize = "100%";
            div.style.backgroundRepeat = "no-repeat";
        });

        div.addEventListener("mouseleave", () => {
            div.style.backgroundImage = ""; // remove background
        });
    });
});
