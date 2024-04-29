---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for PHP via Java 14.7.0
type: docs
weight: 60
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) classes, methods, properties and so on, any new restrictions and other changes introduced with the Aspose.Slides for PHP via Java 14.7.0 API.

{{% /alert %}} 
## **Public API Changes**
### **Constructors of the some TransitionValueBase subtypes have been removed and TransitionValueFactory has been removed**
Constructors of the some TransitionValueBase subtypes (and specifically CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) are useless in public API and so have been removed. Related class TransitionValueFactory and its interface ITransitionValueFactory have been remaved by the same reason.
### **Element SoundAction has been removed from com.aspose.slides.TransitionType enumeration**
Element SoundAction was incorrect and not used. Sound settings are defined by SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName properties..
### **FlyThroughTransition class and IFlyThroughTransition interface have been added**
The com.aspose.slides.FlyThroughTransition class (and its interface com.aspose.slides.IFlyThroughTransition) relates to transition type Flythrough that has been supported in this release..
### **GlitterTransition class, IGlitterTransition interface and TransitionPattern enumeration have been added**
The com.aspose.slides.GlitterTransition class (and its interface com.aspose.slides.IGlitterTransition) relates to transition type Glitter that has been supported in this release .
com.aspose.slides.TransitionPattern enumeration is used in this class and specifies a geometric pattern that tiles together to fill a larger area.
### **LeftRightDirectionTransition class, ILeftRightDirectionTransition interface and TransitionLeftRightDirectionType enumeration have been added**
The com.aspose.slides.LeftRightDirectionTransition class (and its interface com.aspose.slides.ILeftRightDirectionTransition) relates to transition types Switch, Flip, Ferris, Gallery, Conveyor that have been supported in this release.
com.aspose.slides.TransitionLeftRightDirectionType enumeration is used in this class and specifies a direction restricted to the values of left and right.
### **New elements have been added into com.aspose.slides.TransitionType enumeration**
com.aspose.slides.TransitionType enumeration has been extended with new elements.
New elements related to new PowerPoint 2010 transitions: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse.
New elements related to new PowerPoint 2013 transitions: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **RevealTransition class and IRevealTransition interface have been added**
The com.aspose.slides.RevealTransition class (and its interface com.aspose.slides.IRevealTransition) relates to transition type Reveal that has been supported in this release.
RippleTransition class, IRippleTransition interface and TransitionCornerAndCenterDirectionType enumeration have been added
The com.aspose.slides.RippleTransition class (and its interface com.aspose.slides.IRippleTransition) relates to transition type Ripple that has been supported in this release.
com.aspose.slides.TransitionCornerAndCenterDirectionType enumeration is used in this class and specifies a direction restricted to the corners and center.
### **ShredTransition class, IShredTransition interface and TransitionShredPattern enumeration have been added**
The com.aspose.slides.ShredTransition class (and its interface com.aspose.slides.IShredTransition) relates to transition type Shred that has been supported in this release.
com.aspose.slides.TransitionShredPattern enumeration is used in this class and specifies a geometric shape that tiles together to fill a larger area.
