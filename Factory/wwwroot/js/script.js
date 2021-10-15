const container = document.querySelector('.test-room');




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
  

  const bounceUp = anime({
    autoplay: false,
    targets: '#string' + stringCount,
    translateY: [bottom, 0],
    duration: 575,
    easing: 'easeOutQuad',
    complete: () => {
      stringFall.play();
    }
  });
  const stringFall = anime({
    autoplay: false,
    targets: '#string' + stringCount,
    translateY: [0, bottom],
    duration: 575,
    easing: 'easeInQuad',
    complete: () => {
      bounceUp.play();
    }
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











