# What is autoaccess?
autoaccess is an acronnim that stands for accessible automation and, as its name states, aims to make device automation/maintenance accessible for everyone, regardless of their disability.
# how does it work?
It solves the problem of manual device automation/maintenance through scripting, something like autoit for windows, but a bit limited at the moment due to it being in the early stage of development.
# why should I use it? 
So, imagine you have to perform the following task:
1. Check the battery level.
2. If it is above 50%, then vibrate once, show an animation, and be ready to proceed
if not, vibrate twice, speak battery not above safe level to proceed, then cancel whatever you were trying to do next.
3. Start some moderately power-hungry task, like launching a video in the browser or performing a wether lookup every x minutes, notifying the user when something important changed.

Familiar, right? Then, know autoaccess will be able to do these tasks and many more through easely importable user-created scripts.
## Aren't there better equipped and more feature-packed tools for this?
well, yes and no.
So, there is something called sl4a(scripting layer for android) that, at its core, tryes to do just that, add scripting to the android stack.
However, this has its own disadvantages:
*it's not cross-platform. Because it relyes too much on native code, that approach to accessible automation will remain only for android
*no accessible frontends have been developed for it as of now. Of course there will always be things like luastudio, but their interface is accessible to blind users no more than 10%, I'd estimate, and even that is by accident, not design.

So, having that in mind, I had basically two choices. Either I would develop an accessible frontend to sl4a and limit my self to android, or try to make it as cross-platform as possible, so here we are, with this beginning of an app.

# supported platforms
remember when I said this app is going to be as cross-platform as possible? well, I wasn't joking at all.
so, due to xamarin.forms, the app currently supports windows 10 through uwp, android and iOS.
Those are the most popular platforms, but I will investigate on adding more upon request.
# scripting languages
for now, the app will only support lua, but more languages will be hopefully added in future releases
# documentation
the app is evolving massively on a regular bases, so be warned that multiple breaking changes could appear in a single release
  # conventions
this will remain pretty stable through the lifecycle of this app, so at least from that perspective, you don't have to worry.
**note: An app-specific name is defined by any variable, type, function, object instance from .net, constant, or anything else you could think of that is introduced by this application.**
*If an app-specific name consists of one word and one word only, then it will be written completely in lowercase
*However, if an app-specific name is made of multiple words, then the starting letter of each word would be capitalised. This is done in order to improve readability and slightly reduce code size because there's no need for dashes or whatever else you've seen before to separate identifiers.
  # available modules:
For the moment, there are the following libraries available
*PowerIndicator:
used to check battery related things
*VibrationService:
used to emit vibrations, both blocking and non-blocking ones.
