const container = document.querySelector('.test-room');
const colorButton = document.getElementById('colorButton');
let colorClass = "sillyString"


let mouseStillDown = false;

let stringCount = 1;
let interval_;

function sillyString(e){

  const string = document.createElement('div');
  
  string.classList.add(colorClass);
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

container.addEventListener('mousedown', (e) => {
  sillyString(e);
  
  container.onmousemove = function(e){
    sillyString(e)
  }
  
});

container.addEventListener('mouseup', () => {
  clearInterval(interval_);
  window.onmousemove = null;
})









