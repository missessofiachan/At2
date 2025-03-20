document.addEventListener("DOMContentLoaded", function () {
    const form = document.getElementById("applicantForm");

    if (form) {
        form.addEventListener("submit", function (event) {
            let isValid = true;

            // Clear previous error messages
            document.querySelectorAll(".error-message").forEach(el => el.textContent = "");

            // Name Validation
            const nameInput = document.getElementById("Name");
            const nameError = document.getElementById("nameError");
            if (nameInput) {
                const nameValue = nameInput.value.trim();
                const nameRegex = /^[A-Za-z\s]+$/; // Only letters and spaces allowed

                if (nameValue === "") {
                    nameError.textContent = "Name is required.";
                    isValid = false;
                } else if (!nameRegex.test(nameValue)) {
                    nameError.textContent = "Name can only contain letters and spaces.";
                    isValid = false;
                }
            }

            // Date of Birth Validation (At least 18 years old)
            const dobInput = document.getElementById("DOB");
            const dobError = document.getElementById("dobError");
            if (dobInput) {
                const dobValue = new Date(dobInput.value);
                const today = new Date();
                const age = today.getFullYear() - dobValue.getFullYear();

                if (isNaN(dobValue.getTime())) {
                    dobError.textContent = "Please enter a valid date.";
                    isValid = false;
                } else if (age < 18) {
                    dobError.textContent = "Applicant must be at least 18 years old.";
                    isValid = false;
                }
            }

            // Qualification Validation (Must be a valid option)
            const qualificationInput = document.getElementById("Qualification");
            const qualificationError = document.getElementById("qualificationError");
            const validQualifications = ["Master of Data Science", "Master of Artificial Intelligence", "Master of Information Technology", "Master of Science (Statistics)"];

            if (qualificationInput) {
                const qualificationValue = qualificationInput.value.trim();
                if (!validQualifications.includes(qualificationValue)) {
                    qualificationError.textContent = "Please select a valid qualification.";
                    isValid = false;
                }
            }

            // GPA Validation (Must be a number >= 3.0)
            const gpaInput = document.getElementById("GPA");
            const gpaError = document.getElementById("gpaError");
            if (gpaInput) {
                const gpaValue = parseFloat(gpaInput.value);
                if (isNaN(gpaValue) || gpaValue < 3.0) {
                    gpaError.textContent = "GPA must be 3.0 or higher!";
                    isValid = false;
                }
            }

            // University Validation (Must not be empty)
            const universityInput = document.getElementById("University");
            const universityError = document.getElementById("universityError");
            if (universityInput) {
                const universityValue = universityInput.value.trim();
                if (universityValue === "") {
                    universityError.textContent = "University name is required.";
                    isValid = false;
                }
            }

            // Prevent form submission if validation fails
            if (!isValid) {
                event.preventDefault();
            }
        });
    }
});

const deleteButton = document.getElementById("deleteButton");
if (deleteButton) {
    deleteButton.addEventListener("click", function (event) {
        if (!confirm("Are you sure you want to delete this applicant?")) {
            event.preventDefault();
        }
    });
}

const darkModeSwitch = document.getElementById('darkModeSwitch');
const body = document.body;

if (darkModeSwitch) {
    // Check localStorage for user's theme preference
    if (localStorage.getItem('theme') === 'dark') {
        body.classList.add('dark-mode');
        darkModeSwitch.checked = true;
    }

    // Listen for changes on the dark mode switch
    darkModeSwitch.addEventListener('change', function () {
        if (this.checked) {
            body.classList.add('dark-mode');
            localStorage.setItem('theme', 'dark');
        } else {
            body.classList.remove('dark-mode');
            localStorage.setItem('theme', 'light');
        }
    });
}
