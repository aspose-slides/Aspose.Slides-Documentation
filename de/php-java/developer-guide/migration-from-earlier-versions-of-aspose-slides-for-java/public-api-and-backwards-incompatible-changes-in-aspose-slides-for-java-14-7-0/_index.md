---
title: Öffentliches API und nicht rückwärtskompatible Änderungen in Aspose.Slides für PHP über Java 14.7.0
type: docs
weight: 60
url: /de/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) Klassen, Methoden, Eigenschaften und so weiter, neue Einschränkungen und andere Änderungen auf, die mit der Aspose.Slides für PHP über Java 14.7.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen im öffentlichen API**
### **Konstruktoren einiger TransitionValueBase-Subtypen wurden entfernt und TransitionValueFactory wurde entfernt**
Konstruktoren einiger TransitionValueBase-Subtypen (insbesondere CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) sind im öffentlichen API nutzlos und wurden daher entfernt. Die zugehörige Klasse TransitionValueFactory und ihr Interface ITransitionValueFactory wurden aus demselben Grund entfernt.
### **Element SoundAction wurde aus der Enumeration com.aspose.slides.TransitionType entfernt**
Das Element SoundAction war inkorrekt und wurde nicht verwendet. Die Toneinstellungen werden durch die Eigenschaften SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName definiert..
### **FlyThroughTransition-Klasse und IFlyThroughTransition-Interface wurden hinzugefügt**
Die Klasse com.aspose.slides.FlyThroughTransition (und ihr Interface com.aspose.slides.IFlyThroughTransition) bezieht sich auf den Übergangstyp Flythrough, der in diesem Release unterstützt wurde..
### **GlitterTransition-Klasse, IGlitterTransition-Interface und TransitionPattern-Enumeration wurden hinzugefügt**
Die Klasse com.aspose.slides.GlitterTransition (und ihr Interface com.aspose.slides.IGlitterTransition) bezieht sich auf den Übergangstyp Glitter, der in diesem Release unterstützt wurde.
Die Enumeration com.aspose.slides.TransitionPattern wird in dieser Klasse verwendet und spezifiziert ein geometrisches Muster, das zusammengefügt wird, um eine größere Fläche zu füllen.
### **LeftRightDirectionTransition-Klasse, ILeftRightDirectionTransition-Interface und TransitionLeftRightDirectionType-Enumeration wurden hinzugefügt**
Die Klasse com.aspose.slides.LeftRightDirectionTransition (und ihr Interface com.aspose.slides.ILeftRightDirectionTransition) bezieht sich auf die Übergangstypen Switch, Flip, Ferris, Gallery, Conveyor, die in diesem Release unterstützt wurden.
Die Enumeration com.aspose.slides.TransitionLeftRightDirectionType wird in dieser Klasse verwendet und spezifiziert eine Richtung, die auf die Werte links und rechts beschränkt ist.
### **Neue Elemente wurden in die Enumeration com.aspose.slides.TransitionType hinzugefügt**
Die Enumeration com.aspose.slides.TransitionType wurde um neue Elemente erweitert.
Neue Elemente beziehen sich auf neue PowerPoint 2010-Übergänge: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse.
Neue Elemente beziehen sich auf neue PowerPoint 2013-Übergänge: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **RevealTransition-Klasse und IRevealTransition-Interface wurden hinzugefügt**
Die Klasse com.aspose.slides.RevealTransition (und ihr Interface com.aspose.slides.IRevealTransition) bezieht sich auf den Übergangstyp Reveal, der in diesem Release unterstützt wurde.
Die RippleTransition-Klasse, das IRippleTransition-Interface und die TransitionCornerAndCenterDirectionType-Enumeration wurden hinzugefügt.
Die Klasse com.aspose.slides.RippleTransition (und ihr Interface com.aspose.slides.IRippleTransition) bezieht sich auf den Übergangstyp Ripple, der in diesem Release unterstützt wurde.
Die Enumeration com.aspose.slides.TransitionCornerAndCenterDirectionType wird in dieser Klasse verwendet und spezifiziert eine Richtung, die auf die Ecken und die Mitte beschränkt ist.
### **ShredTransition-Klasse, IShredTransition-Interface und TransitionShredPattern-Enumeration wurden hinzugefügt**
Die Klasse com.aspose.slides.ShredTransition (und ihr Interface com.aspose.slides.IShredTransition) bezieht sich auf den Übergangstyp Shred, der in diesem Release unterstützt wurde.
Die Enumeration com.aspose.slides.TransitionShredPattern wird in dieser Klasse verwendet und spezifiziert eine geometrische Form, die zusammengefügt wird, um eine größere Fläche zu füllen.