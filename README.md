# What is autoaccess?
autoaccess is an acronnim that stands for accessible automation and, as its name states, aims to make device automation/maintenance accessible for everyone, regardless of their disability.
# how does it work?
It solves the problem of manual device automation/maintenance through scripting, something like autoit for windows, but a bit limited at the moment due to it being in the early stage of development.
# why should I use it? 
As autoaccess has as its main purpose automation, you can automatically perform tasks that are long, tedious, or overly complicated and tiring to do if done by a human being multiple times, perhaps even for multiple devices. As an afterthought, one can set up more computers at once, perhaps for users who don't know how to use a  computer at the required level to do it themselfs, though they need some specific configuration.
For example, , imagine you have to perform a task, but as it's a rather power-hungry one, you have to do it only if the battery is high enough. So, you'd have to do something like this:
1. Check the battery level.
2. If it is above 50%, then vibrate once, show an animation, and be ready to proceed

if not, vibrate twice, speak battery not above safe level to proceed, then cancel whatever you were trying to do next.
3. Start some moderately power-hungry task, like launching a video in the browser or performing a wether lookup every x minutes, notifying the user when something important changed.

If you find your self often in need of something like this, and perhaps   nostalgically  regard   the days of autoit/autohotkey, know autoaccess will eventually be for you.

## Aren't there better equipped and more feature-packed tools for this?
well, yes and no.

So, there is something called sl4a(scripting layer for android) that, at its core, tryes to do just that, add scripting to the android stack.
However, this has its own disadvantages:
* it's not cross-platform. Because it relyes too much on native code, that approach to accessible automation will remain only for android
* no accessible frontends have been developed for it as of now. Of course there will always be things like luastudio, but their interface is accessible to blind users no more than 10%, I'd estimate, and even that is by accident, not design.

So, having that in mind, I had basically two choices. Either I would develop an accessible frontend to sl4a and limit my self to android, or try to make it as cross-platform as possible, so here we are, with this beginning of an app.

# supported platforms
remember when I said this app is going to be as cross-platform as possible? well, I wasn't joking at all.

So, due to xamarin.forms, the app currently supports windows 10 through uwp, android and iOS.
Those are the most popular platforms, but I will investigate on adding more upon request.
# scripting languages
for now, the app will only support lua, but more languages will be hopefully added in future releases
# documentation
the app is evolving massively on a regular bases, so be warned that multiple breaking changes could appear in a single release
  # conventions
this will remain pretty stable through the lifecycle of this app, so at least from that perspective, you don't have to worry.
* note: An app-specific name is defined by any variable, type, function, object instance from .net, constant, or anything else you could think of that is introduced by this application. *

* If an app-specific name consists of one word and one word only, then it will be written completely in lowercase
* However, if an app-specific name is made of multiple words, then the starting letter of each word would be capitalised. This is done in order to improve readability and slightly reduce code size because there's no need for dashes or whatever else you've seen before to separate identifiers.
  # available modules:
For the moment, there are the following libraries available
* PowerIndicator:

used to check battery related things
* VibrationService:

used to emit vibrations, both blocking and non-blocking ones.

*tts

used for any tts(text to speech) related things this environment will expose
#globally available functions

These functions are mostly used for maximum compatibility with the lua standard. Of course there could have been alternative implementations, but I want to keep this as compatible as possible with the standard  lua interpretor, and therefore with external libraries. I can't provide every feature under the sun with this application, so this compatibility will come in handy sometime, believe me.
For now, the following global functions are available:
*print

the  print function one can find in the standard implementation of lua. It simply prints messages to the screen, however since this application is gui based, it will show a platform-specific message/alert box with the textual form of the parameters passed to it.
