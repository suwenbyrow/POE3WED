document.addEventListener('DOMContentLoaded', () => {
    const form = document.getElementById('newsletter-form');
    const modal = document.getElementById('success-modal');
    const closeButton = document.querySelector('.close-button');
    const modalUserInfo = document.getElementById('modal-user-info');

    const showModal = (name, email) => {
        modalUserInfo.textContent = `Signed in as: ${name} | ${email}`;
        modal.style.display = 'block';
        modal.setAttribute('aria-hidden', 'false');

        setTimeout(() => {
            window.location.href = "dashboard.html";
        }, 2000);
    };

    const hideModal = () => {
        modal.style.display = 'none';
        modal.setAttribute('aria-hidden', 'true');
    };

    closeButton.addEventListener('click', hideModal);
    window.addEventListener('click', (event) => {
        if (event.target === modal) hideModal();
    });

    form.addEventListener('submit', (e) => {
        e.preventDefault();
        
        // Get the input values
        const name = document.getElementById('name').value;
        const surname = document.getElementById('surname').value;
        const phone = document.getElementById('phone').value;
        const email = document.getElementById('email').value;

        // Validate name and surname length
        if (name.length < 4 || surname.length < 4) {
            alert('Name and surname must be at least 4 characters long.');
            return;
        }

        // Validate phone number length
        if (!/0[0-9]{9}/.test(phone)) {
            alert('Phone number must be exactly 10 digits long, starting with 0.');
            return;
        }

        // Validate email pattern for Gmail
        if (!/^[a-zA-Z0-9._%+-]+@gmail\.com$/.test(email)) {
            alert('Email must be a valid Gmail address (e.g., user@gmail.com).');
            return;
        }

        // If all validation passes, show the modal
        showModal(name, email);
    });
});