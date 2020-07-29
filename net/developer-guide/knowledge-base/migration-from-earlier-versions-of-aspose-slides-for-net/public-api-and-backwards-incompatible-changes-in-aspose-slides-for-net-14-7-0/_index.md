---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for .NET 14.7.0
type: docs
weight: 90
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) or [removed](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) classes, methods, properties and so on, and other changes introduced with the Aspose.Slides for .NET 14.7.0 API.

{{% /alert %}} 
## **Public API Changes**
### **Removed Constructors and Elements**
#### **Removed Some TransitionValueBase Subtype Constructors and TransitionValueFactory**
The constructors of some TransitionValueBase subtypes (specifically CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) are useless in the public API and so have been removed. 

The related class TransitionValueFactory and its interface ITransitionValueFactory have been removed for the same reason.
#### **Removed the SoundAction Element from the Aspose.Slides.SlideShow.TransitionType Enumeration**
The SoundAction element was incorrect and not used. Sound settings are defined by the SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName properties.
### **Added Classes and Interfaces**
#### **Added the FlyThroughTransition Class and IFlyThroughTransition Interface**
The Aspose.Slides.SlideShow.FlyThroughTransition class (and its interface Aspose.Slides.SlideShow.IFlyThroughTransition) relates to the Flythrough transition type supported from this release.
#### **Added the GlitterTransition Class, IGlitterTransition Interface and TransitionPattern Enumeration**
The Aspose.Slides.SlideShow.GlitterTransition class (and its interface Aspose.Slides.SlideShow.IGlitterTransition) relates to the Glitter transition type supported from this release.

The Aspose.Slides.SlideShow.TransitionPattern enumeration is used in this class and specifies a geometric pattern that tiles together to fill a larger area.
#### **Added the LeftRightDirectionTransition Class, ILeftRightDirectionTransition Interface and TransitionLeftRightDirectionType Enumeration**
The Aspose.Slides.SlideShow.LeftRightDirectionTransition class (and its interface Aspose.Slides.SlideShow.ILeftRightDirectionTransition) relates to the transition types Conveyor, Ferris, Flip, Gallery and Switch. All are supported from this release.

The Aspose.Slides.SlideShow.TransitionLeftRightDirectionType enumeration is used in this class and specifies a direction, restricted to the values left and right.
#### **Added New Elements to the Aspose.Slides.SlideShow.TransitionType Enumeration**
The Aspose.Slides.SlideShow.TransitionType enumeration has been extended with new elements.

- New elements related to PowerPoint 2010 transitions: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- New elements related to new PowerPoint 2013 transitions: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **Added the RevealTransition Class and IRevealTransition Interface**
The Aspose.Slides.SlideShow.RevealTransition class (and its interface Aspose.Slides.SlideShow.IRevealTransition) relates to the Reveal transition type supported from this release.
#### **Added the RippleTransition class, IRippleTransition Interface and TransitionCornerAndCenterDirectionType Enumeration**
The Aspose.Slides.SlideShow.RippleTransition class (and its interface Aspose.Slides.SlideShow.IRippleTransition) relates to the Ripple transition type supported from this release.

The Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType enumeration is used in this class and specifies a direction, restricted to the corners and center.
