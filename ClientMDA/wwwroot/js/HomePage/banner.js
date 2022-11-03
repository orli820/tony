﻿//banner
var swiper = new Swiper(".mySwiper", {
    spaceBetween: 30,
    centeredSlides: true,
    autoplay: {
        delay: 1500,
        disableOnInteraction: false,
        pauseOnMouseEnter: 1,

    },
    pagination: {
        el: ".swiper-pagination",
        clickable: true,
    },
    navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
    },
});




/*rate*/
var swiper = new Swiper(".mySwiperRATE", {
    slidesPerView: 4,
    spaceBetween: 30,
    autoplay: {
        delay: 1500,
        disableOnInteraction: false,
        pauseOnMouseEnter: 1,
    },
    pagination: {
        el: ".swiper-paginationR",
        clickable: true,
    },

});

//modal  
//const openModalButtons = document.querySelectorAll('[data-modal-target]')
const openModalButtons = document.querySelectorAll('#openbtn')
const closeModalButtons = document.querySelectorAll('[data-close-button]')
const overlay = document.querySelector('#overlay')
const headerofstar = document.getElementById("in-rating-movie");
const movienum = document.getElementById('movienum');
const inputstar = document.querySelectorAll('.inputstar')
const 電影編號in = document.getElementById('movienum')
const 評論編號in = document.getElementById('memrankid')
const 評論分數in = document.getElementById('scorenumber')
const x = document.getElementById('評論編號Comment_ID')


function disableBtn() {
    document.getElementById("submit").style.backgroundColor = "dimgrey";
    document.getElementById("submit").disabled = true;
}
function openModal(modal) {
    if (modal == null) return
    modal.classList.add('active')
    overlay.classList.add('active')    
}

function closeModal(modal) {
    if (modal == null) return
    modal.classList.remove('active')
    overlay.classList.remove('active')
    disableBtn();
    $("#deletestar").css("display", 'none')
    resetmodel()
    rankposter();
    newmovie();
    listmovie();

}

function resetmodel() {
    rm.innerText = "?"
    $("#1").prop('checked', false);
    $("#2").prop('checked', false);
    $("#3").prop('checked', false);
    $("#4").prop('checked', false);
    $("#5").prop('checked', false);
}

for (let i = 0; i < openModalButtons.length; i++) {
    openModalButtons[i].addEventListener('click', e => {    
        rankposter();
        newmovie();
        listmovie();
        const modal = document.querySelector("#modal")
        openModal(modal)
        const f = $(event.currentTarget).parents(".box").find("h5")[0].textContent
        const o = $(event.currentTarget).parents(".box").find("a")[1].getAttribute('data')
        const g = $(event.currentTarget).parents(".box").find("a")[1].getAttribute('data-rank')
        const ef = $(event.currentTarget).parents(".box").find("a")[1].getAttribute('data-rate')
        headerofstar.textContent = f
        電影編號in.value = o;
        document.getElementById('memrankid').value = g;
        document.getElementById('scorenumber').value = ef;        
        if ($('#會員編號Member_ID').val() != 0) {
            
            if (document.getElementById('scorenumber').value == 1 || document.getElementById('scorenumber').value == 2 || document.getElementById('scorenumber').value == 3 || document.getElementById('scorenumber').value == 4 || document.getElementById('scorenumber').value == 5) {               
                rm.innerText = document.getElementById('scorenumber').value;
                $("#deletestar").css("display", 'inline')               
                if (rm.innerText == 1) {
                    $("#1").prop('checked', true);
                }
                else if (rm.innerText == 2) {
                    $("#1").prop('checked', true);
                    $("#2").prop('checked', true);
                }
                else if (rm.innerText == 3) {
                    $("#1").prop('checked', true);
                    $("#2").prop('checked', true);
                    $("#3").prop('checked', true);
                }
                else if (rm.innerText == 4) {
                    $("#1").prop('checked', true);
                    $("#2").prop('checked', true);
                    $("#3").prop('checked', true);
                    $("#4").prop('checked', true);
                }
                else if (rm.innerText == 5) {
                    $("#1").prop('checked', true);
                    $("#2").prop('checked', true);
                    $("#3").prop('checked', true);
                    $("#4").prop('checked', true);
                    $("#5").prop('checked', true);
                }

            }
            else {
                rankposter();
                newmovie();
                listmovie();
                $("#deletestar").css("display", 'none')
                resetmodel()
            }
        }
    })
}

overlay.addEventListener('click', () => {
    const modals = document.querySelectorAll('.modalst.active')
    modals.forEach(modal => {
        closeModal(modal)
    })
})

closeModalButtons.forEach(button => {
    button.addEventListener('click', () => {
        const modal = button.closest('.modalst')
        closeModal(modal)
    })
})



//modal2
const openModalButtons2 = document.querySelectorAll('#openbtnE')
const closeModalButtons2 = document.querySelector('#closebtnE')
const overlay2 = document.querySelector('#overlayE')
const headerofstar2 = document.getElementById("in-rating-movieE");
//const movienum = document.getElementById('movienum');

//function disableBtn() {
//    document.getElementById("submit").style.backgroundColor = "dimgrey";
//    document.getElementById("submit").disabled = true;
//}

function openModal2(modal2) {
    if (modal2 == null) return
    modal2.classList.add('active')
    overlay2.classList.add('active')
}

function closeModal2(modal2) {
    if (modal2 == null) return
    modal2.classList.remove('active')
    overlay2.classList.remove('active')

    //disableBtn();
    //$("#1").prop('checked', false);
    //$("#2").prop('checked', false);
    //$("#3").prop('checked', false);
    //$("#4").prop('checked', false);
    //$("#5").prop('checked', false);
}

for (let i = 0; i < openModalButtons2.length; i++) {
    openModalButtons2[i].addEventListener('click', en => {
        const modal2 = document.querySelector("#modalstE")
        openModal2(modal2)
        const f = $(event.currentTarget).parents(".box").find("h5")[0].textContent
        headerofstar2.textContent = f
        //const o = $(event.currentTarget).parents(".box").find("a")[1].getAttribute('data')
        //document.getElementById('movienumE').value = o;
    })
}

overlay2.addEventListener('click', () => {
    const modals2 = document.querySelector('.modalstE.active')
    closeModal2(modals2)
})

closeModalButtons2.addEventListener('click', () => {
        const modals2 = document.querySelector('.modalstE.active')
        closeModal2(modals2)
    })


//change font



//swiper
    var swiper = new Swiper(".mySwipersw", {
        effect: "cards",
            /*grabCursor: true,*/
    });

//add rate






