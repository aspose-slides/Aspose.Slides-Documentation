---
title: Öffentliche API und rückwärts inkompatible Änderungen in Aspose.Slides für .NET 14.7.0
type: docs
weight: 90
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) oder [entfernten](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) Klassen, Methoden, Eigenschaften usw. sowie andere Änderungen auf, die mit der Aspose.Slides für .NET 14.7.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
### **Entfernte Konstruktoren und Elemente**
#### **Einige Konstruktoren des Subtyps TransitionValueBase und TransitionValueFactory entfernt**
Die Konstruktoren einiger Subtypen von TransitionValueBase (insbesondere CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) sind in der öffentlichen API nutzlos und wurden daher entfernt.

Die zugehörige Klasse TransitionValueFactory und ihr Interface ITransitionValueFactory wurden aus dem gleichen Grund entfernt.
#### **Das Element SoundAction aus der Aufzählung Aspose.Slides.SlideShow.TransitionType entfernt**
Das Element SoundAction war inkorrekt und wurde nicht verwendet. Soundeinstellungen werden durch die Eigenschaften SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName definiert.
### **Hinzugefügte Klassen und Schnittstellen**
#### **Die Klasse FlyThroughTransition und das Interface IFlyThroughTransition hinzugefügt**
Die Aspose.Slides.SlideShow.FlyThroughTransition-Klasse (und ihr Interface Aspose.Slides.SlideShow.IFlyThroughTransition) bezieht sich auf den Flythrough-Übergangstyp, der ab diesem Release unterstützt wird.
#### **Die Klasse GlitterTransition, das IGlitterTransition-Interface und die TransitionPattern-Aufzählung hinzugefügt**
Die Aspose.Slides.SlideShow.GlitterTransition-Klasse (und ihr Interface Aspose.Slides.SlideShow.IGlitterTransition) bezieht sich auf den Glitter-Übergangstyp, der ab diesem Release unterstützt wird.

Die Aspose.Slides.SlideShow.TransitionPattern-Aufzählung wird in dieser Klasse verwendet und gibt ein geometrisches Muster an, das zusammenfließt, um einen größeren Bereich auszufüllen.
#### **Die Klasse LeftRightDirectionTransition, das ILeftRightDirectionTransition-Interface und die TransitionLeftRightDirectionType-Aufzählung hinzugefügt**
Die Aspose.Slides.SlideShow.LeftRightDirectionTransition-Klasse (und ihr Interface Aspose.Slides.SlideShow.ILeftRightDirectionTransition) bezieht sich auf die Übergangstypen Conveyor, Ferris, Flip, Gallery und Switch. Alle werden ab diesem Release unterstützt.

Die Aspose.Slides.SlideShow.TransitionLeftRightDirectionType-Aufzählung wird in dieser Klasse verwendet und gibt eine Richtung an, die auf die Werte links und rechts beschränkt ist.
#### **Neue Elemente zur Aufzählung Aspose.Slides.SlideShow.TransitionType hinzugefügt**
Die Aspose.Slides.SlideShow.TransitionType-Aufzählung wurde um neue Elemente erweitert.

- Neue Elemente in Bezug auf PowerPoint 2010-Übergänge: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- Neue Elemente in Bezug auf neue PowerPoint 2013-Übergänge: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **Die Klasse RevealTransition und das Interface IRevealTransition hinzugefügt**
Die Aspose.Slides.SlideShow.RevealTransition-Klasse (und ihr Interface Aspose.Slides.SlideShow.IRevealTransition) bezieht sich auf den Reveal-Übergangstyp, der ab diesem Release unterstützt wird.
#### **Die Klasse RippleTransition, das IRippleTransition-Interface und die TransitionCornerAndCenterDirectionType-Aufzählung hinzugefügt**
Die Aspose.Slides.SlideShow.RippleTransition-Klasse (und ihr Interface Aspose.Slides.SlideShow.IRippleTransition) bezieht sich auf den Ripple-Übergangstyp, der ab diesem Release unterstützt wird.

Die Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType-Aufzählung wird in dieser Klasse verwendet und gibt eine Richtung an, die auf die Ecken und die Mitte beschränkt ist.