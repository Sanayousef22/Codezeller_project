// const body = document.querySelector("body"),
//   nav = document.querySelector("nav"),
//   modeToggle = document.querySelector(".dark-light"),
//   searchToggle = document.querySelector(".searchToggle"),
//   sidebarOpen = document.querySelector(".sidebarOpen"),
//   siderbarClose = document.querySelector(".siderbarClose");

// let getMode = localStorage.getItem("mode");
// if (getMode && getMode === "dark-mode") {
//   body.classList.add("dark");
// }

// // js code to toggle dark and light mode
// modeToggle.addEventListener("click", () => {
//   modeToggle.classList.toggle("active");
//   body.classList.toggle("dark");

//   // js code to keep user selected mode even page refresh or file reopen
//   if (!body.classList.contains("dark")) {
//     localStorage.setItem("mode", "light-mode");
//   } else {
//     localStorage.setItem("mode", "dark-mode");
//   }
// });

// // js code to toggle search box
// searchToggle.addEventListener("click", () => {
//   searchToggle.classList.toggle("active");
// });

// //   js code to toggle sidebar
// sidebarOpen.addEventListener("click", () => {
//   nav.classList.add("active");
// });

// body.addEventListener("click", (e) => {
//   let clickedElm = e.target;

//   if (
//     !clickedElm.classList.contains("sidebarOpen") &&
//     !clickedElm.classList.contains("menu")
//   ) {
//     nav.classList.remove("active");
//   }
// });



//function to store user name and password


const form = document.querySelector("form");
eField = form.querySelector(".email"),
eInput = eField.querySelector("input"),
pField = form.querySelector(".password"),
pInput = pField.querySelector("input");

form.onsubmit = (e)=>{
  e.preventDefault(); //preventing from form submitting
  //if email and password is blank then add shake class in it else call specified function
  (eInput.value == "") ? eField.classList.add("shake", "error") : checkEmail();
  (pInput.value == "") ? pField.classList.add("shake", "error") : checkPass();

  setTimeout(()=>{ //remove shake class after 500ms
    eField.classList.remove("shake");
    pField.classList.remove("shake");
  }, 500);

  eInput.onkeyup = ()=>{checkEmail();} //calling checkEmail function on email input keyup
  pInput.onkeyup = ()=>{checkPass();} //calling checkPassword function on pass input keyup

  function checkEmail(){ //checkEmail function
    let pattern = /^[^ ]+@[^ ]+\.[a-z]{2,3}$/; //pattern for validate email
    if(!eInput.value.match(pattern)){ //if pattern not matched then add error and remove valid class
      eField.classList.add("error");
      eField.classList.remove("valid");
      let errorTxt = eField.querySelector(".error-txt");
      //if email value is not empty then show please enter valid email else show Email can't be blank
      (eInput.value != "") ? errorTxt.innerText = "Enter a valid email address" : errorTxt.innerText = "Email can't be blank";
    }else{ //if pattern matched then remove error and add valid class
      eField.classList.remove("error");
      eField.classList.add("valid");
    }
  }

  function checkPass(){ //checkPass function
    if(pInput.value == ""){ //if pass is empty then add error and remove valid class
      pField.classList.add("error");
      pField.classList.remove("valid");
    }else{ //if pass is empty then remove error and add valid class
      pField.classList.remove("error");
      pField.classList.add("valid");
    }
  }

  //if eField and pField doesn't contains error class that mean user filled details properly
  if(!eField.classList.contains("error") && !pField.classList.contains("error")){
      // Serialize form data
      var formData = $('#myForm').serialize();
      // Send AJAX request
      $.ajax({
          type: 'post',
          url: '/apis/login',
          data: formData,
          success: function (response) {
              // Handle success response
              if (response.code == 200) {
                  swal.fire("success", "signed up successfuly", "success");
                  setTimeout(function () {
                      window.location.href = "/pages/";
                  }, 3000);

              } else {
                  swal.fire('error', "something went wrong please try again", "error");
              }
          },
          error: function (xhr, status, error) {
              // Handle error
              console.error(xhr.responseText);
          }
      });
  }
}


