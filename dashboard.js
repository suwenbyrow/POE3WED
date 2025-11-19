document.addEventListener("DOMContentLoaded", () => {
    const title = document.getElementById("page-title");
    const content = document.getElementById("page-content");

    const pages = {
        mailbox: "Your messages and notifications.",
        calendar: "Your scheduled events and reminders.",
        groupchat: "Your active group chats.",
        features: "Platform features overview.",
        forms: "Interactive forms and inputs.",
        charts: "Data visualizations and charts.",
        tables: "Data tables and lists.",
        apps: "Installed apps and integrations.",
        widgets: "Dashboard widgets and mini-tools."
    };

    document.querySelectorAll(".menu-item").forEach(item => {
        item.addEventListener("click", () => {
            const page = item.dataset.page;
            if (pages[page]) {
                title.textContent = item.textContent;
                content.textContent = pages[page];
            }
        });
    });
});