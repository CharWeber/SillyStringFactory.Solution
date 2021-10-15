const container = document.querySelector('.test-room');
const colorButton = document.getElementById('colorButton');

let mouseStillDown = false;

let stringCount = 1;
let interval_;

function sillyString(e){

  const string = document.createElement('div');
  
  string.classList.add('sillyString');
  string.id = 'string' + stringCount;
  
  const screenHeight = e.view.innerHeight;
  const bottom = screenHeight - e.y - 50;
  
  string.style.bottom = `${bottom}px`;
  string.style.left = `${e.x -50}px`;
  
  container.appendChild(string);
  
  const stringFall = anime ({
    autoplay:false,
    targets: '#string' + stringCount,
    translateY: [0,bottom],
    duration: 575,
    easing: 'easeInQuad',
  });
  
  stringFall.play();
  stringCount++;


}

// window.addEventListener('mousedown', (e) => {
//   interval_ = setInterval(function(){sillyString(e);},  100);;
// });
window.addEventListener('mousedown', (e) => {
  sillyString(e);
  
  window.onmousemove = function(e){
    sillyString(e)
  }
  
});

window.addEventListener('mouseup', () => {
  clearInterval(interval_);
  window.onmousemove = null;
})

colorButton.addEventListener('click', () =>{
  let colorValue = document.getElementById("color");
  console.log(colorValue);
})






