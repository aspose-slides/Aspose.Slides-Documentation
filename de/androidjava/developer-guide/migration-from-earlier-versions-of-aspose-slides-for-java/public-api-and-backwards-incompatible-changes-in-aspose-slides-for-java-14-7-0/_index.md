---
title: Öffentliche API und rückwärts inkompatible Änderungen in Aspose.Slides für Java 14.7.0
type: docs
weight: 60
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) Klassen, Methoden, Eigenschaften usw. auf, sowie alle neuen Einschränkungen und anderen Änderungen, die mit der Aspose.Slides für Java 14.7.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen der öffentlichen API**
### **Konstruktoren einiger TransitionValueBase-Subtypen wurden entfernt und TransitionValueFactory wurde entfernt**
Die Konstruktoren einiger TransitionValueBase-Subtypen (insbesondere CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) sind in der öffentlichen API überflüssig und wurden daher entfernt. Die zugehörige Klasse TransitionValueFactory und ihr Interface ITransitionValueFactory wurden aus demselben Grund entfernt.
### **Element SoundAction wurde aus der Enumeration com.aspose.slides.TransitionType entfernt**
Das Element SoundAction war falsch und wurde nicht verwendet. Die Soundeinstellungen werden durch die Eigenschaften SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName definiert.
### **FlyThroughTransition-Klasse und IFlyThroughTransition-Interface wurden hinzugefügt**
Die Klasse com.aspose.slides.FlyThroughTransition (und ihr Interface com.aspose.slides.IFlyThroughTransition) bezieht sich auf den Übergangstyp Flythrough, der in dieser Version unterstützt wurde.
### **GlitterTransition-Klasse, IGlitterTransition-Interface und TransitionPattern-Enumeration wurden hinzugefügt**
Die Klasse com.aspose.slides.GlitterTransition (und ihr Interface com.aspose.slides.IGlitterTransition) bezieht sich auf den Übergangstyp Glitter, der in dieser Version unterstützt wurde. 
Die Enumeration com.aspose.slides.TransitionPattern wird in dieser Klasse verwendet und spezifiziert ein geometrisches Muster, das zusammengefügt wird, um einen größeren Bereich auszufüllen.
### **LeftRightDirectionTransition-Klasse, ILeftRightDirectionTransition-Interface und TransitionLeftRightDirectionType-Enumeration wurden hinzugefügt**
Die Klasse com.aspose.slides.LeftRightDirectionTransition (und ihr Interface com.aspose.slides.ILeftRightDirectionTransition) bezieht sich auf die Übergangstypen Switch, Flip, Ferris, Gallery, Conveyor, die in dieser Version unterstützt wurden. 
Die Enumeration com.aspose.slides.TransitionLeftRightDirectionType wird in dieser Klasse verwendet und spezifiziert eine Richtung, die auf die Werte links und rechts beschränkt ist.
### **Neue Elemente wurden in die Enumeration com.aspose.slides.TransitionType hinzugefügt**
Die Enumeration com.aspose.slides.TransitionType wurde um neue Elemente erweitert. 
Neue Elemente, die mit den neuen PowerPoint 2010-Übergängen verbunden sind: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse. 
Neue Elemente, die mit den neuen PowerPoint 2013-Übergängen verbunden sind: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **RevealTransition-Klasse und IRevealTransition-Interface wurden hinzugefügt**
Die Klasse com.aspose.slides.RevealTransition (und ihr Interface com.aspose.slides.IRevealTransition) bezieht sich auf den Übergangstyp Reveal, der in dieser Version unterstützt wurde.
RippleTransition-Klasse, IRippleTransition-Interface und TransitionCornerAndCenterDirectionType-Enumeration wurden hinzugefügt
Die Klasse com.aspose.slides.RippleTransition (und ihr Interface com.aspose.slides.IRippleTransition) bezieht sich auf den Übergangstyp Ripple, der in dieser Version unterstützt wurde. 
Die Enumeration com.aspose.slides.TransitionCornerAndCenterDirectionType wird in dieser Klasse verwendet und spezifiziert eine Richtung, die auf die Ecken und die Mitte beschränkt ist.
### **ShredTransition-Klasse, IShredTransition-Interface und TransitionShredPattern-Enumeration wurden hinzugefügt**
Die Klasse com.aspose.slides.ShredTransition (und ihr Interface com.aspose.slides.IShredTransition) bezieht sich auf den Übergangstyp Shred, der in dieser Version unterstützt wurde. 
Die Enumeration com.aspose.slides.TransitionShredPattern wird in dieser Klasse verwendet und spezifiziert eine geometrische Form, die zusammengefügt wird, um einen größeren Bereich auszufüllen.