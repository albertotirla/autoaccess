# autoaccess

## What is autoaccess?

autoaccess is an acronnim that stands for accessible automation and, as its name states, aims to make device automation/maintenance accessible for everyone, regardless of their disability.

## how does it work?

It solves the problem of manual device automation/maintenance through scripting, something like autoit for windows, but a bit limited at the moment due to it being in the early stage of development.

## why should one use it? 

As autoaccess has as its main purpose automation, you can use it to perform tasks that are long, tedious, or overly complicated and tiring to do by a human operator multiple times, perhaps even for multiple devices at the same time in future releases.

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
* no accessible frontends have been developed for it as of now. Of course there will always be things like luastudio, but their interface is accessible to blind and otherwise disabled users no more than 10%, I'd estimate, and even that is by accident, not design.

So, having that in mind, I had basically two choices. Either I would develop an accessible frontend to sl4a and limit my self to android, or try to make it as cross-platform as possible, so here we are, with this beginning of an app.

## environment, building, etc

###programming language and tools used

This application is written in c# or csharp as it's informally known, a programming language developed and founded by microsoft.  
Since it's written in the .net ecosystem, it makes use of several libraries and paradigms available in the .net core, like file IO, asyncronous programming principles, etc.  
I also based my app around xamarin.forms and the companion pluggin, xamarin.essentials, a framework that allows cross-platform mobile and desktop development with the same set of libraries, .net standard.

###building

to build the app, you nead:

* visual studio 2019 or later
* xamarin.forms stable version 5 or later
* the latest android sdk and windows sdk, not to be confused with the minimum required to run the autoaccess app, more on that later.

in order to build the project, open the autoaccess.sln file in visual studio, see above for required versions.  
Next, depending on what project you want to build, you do the following:

* for android:
  1. Right-click the autoaccess.android project in the solution explorer, then select archive autoaccess
  2. When it finished building, visual studio will tell you so. Now, click the "distribute..." button and select ad-hock distribution.  
Next, follow the wizard through the steps, including signing the built android archive either with a pre-made key, or you are given the option to make one on the spot.  
When you completed the signing and entered the password, browse to where the built and signed android package should be saved.
* for the universal windows platform(modern windows 10 application):
  1. Right-click the project, then select publish, then create app packages.
  2. Select the sideloading option, then press next.
  3. As with the android application, you can choose to sign the package with either a certificate on your machine or create a new one.
  4. Select the architecture for which the app will work, x86, x64, arm, etc.
  5. Like the android steps, make sure you complete the wizard, including typing the cert password to complete the signing.  
In the end, the completed package is found in the app packages in the uwp project folder.

## supported platforms

remember when I said this app is going to be as cross-platform as possible? well, I wasn't joking at all.

So, due to xamarin.forms, the app currently supports windows 10 through uwp, android and iOS.
Those are the most popular platforms, but I will investigate on adding more upon request.

## system requirements

To be able to run this app, you must meet at least the following requirements:

### android

* Android 5.0 (API 21) or higher
*1 gb ram minimum, at least 2 gb recommended for optimal user experience
* a reasonably new snapdragon processor, or, in case of tablets, intel processor.

### universal windows

* windows 10 build 10.0.18362.0 or greater is recommended
*4 gb ram is recommended for future features that might require more processor power, however the current version can be run on 2 gb ram
* at least dualcore cpu recommended

## available scripting languages

for now, the app will only support lua, but more languages will be hopefully added in future releases

## documentation

the app is evolving massively on a regular bases, so be warned that multiple breaking changes could appear in a single release

### conventions

this will remain pretty stable through the lifecycle of this app, so at least from that perspective, you don't have to worry.

* note: An app-specific name is defined by any variable, type, function, object instance from .net, constant, or anything else you could think of that is introduced by this application. 
* If an app-specific name consists of one word and one word only, then it will be written completely in lowercase  
for example, "tts"
* However, if an app-specific name is made of multiple words, then the starting letter of each word would be capitalised. This is done in order to improve readability and slightly reduce code size because there's no need for dashes or whatever else you've seen before to delimitate words in identifier names.  
example: "VibrationService"

### available modules  

For the moment, there are the following libraries available

* PowerIndicator:  
used to check battery level, the presence of a charger, etc
* VibrationService:  
used to emit vibrations, both blocking and non-blocking ones.
* tts:  
used for any tts(text to speech) related things this environment will expose

### globally available functions

These functions are mostly used for maximum compatibility with the lua standard. Of course there could have been alternative implementations, but I want to keep this as compatible as possible with the standard  lua interpretor, and therefore with external libraries. I can't provide every feature under the sun with this application, so this compatibility will come in handy sometime, believe me.

For now, the following global functions are available:

#### print

the  print function one can find in the standard implementation of lua. It simply prints messages to the screen, however since this application is gui based, it will show a platform-specific message/alert box with the textual form of the parameters passed to it.