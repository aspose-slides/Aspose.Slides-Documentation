---
title: Öffentliches API und nicht rückwärtskompatible Änderungen in Aspose.Slides für Java 14.7.0
type: docs
weight: 60
url: /de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) Klassen, Methoden, Eigenschaften und so weiter auf, sowie alle neuen Einschränkungen und anderen Änderungen, die mit der Aspose.Slides für Java 14.7.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
### **Konstruktoren einiger TransitionValueBase-Subtypen wurden entfernt und TransitionValueFactory wurde entfernt**
Die Konstruktoren einiger TransitionValueBase-Subtypen (und speziell CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) sind im öffentlichen API nutzlos und wurden daher entfernt. Die zugehörige Klasse TransitionValueFactory und ihr Interface ITransitionValueFactory wurden aus demselben Grund entfernt.
### **Element SoundAction wurde aus der Enumeration com.aspose.slides.TransitionType entfernt**
Das Element SoundAction war inkorrekt und wurde nicht verwendet. Die Soundeinstellungen werden durch die Eigenschaften SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName definiert..
### **FlyThroughTransition-Klasse und IFlyThroughTransition-Interface wurden hinzugefügt**
Die com.aspose.slides.FlyThroughTransition-Klasse (und ihr Interface com.aspose.slides.IFlyThroughTransition) bezieht sich auf den Übergangstyp Flythrough, der in dieser Version unterstützt wurde..
### **GlitterTransition-Klasse, IGlitterTransition-Interface und TransitionPattern-Enumeration wurden hinzugefügt**
Die com.aspose.slides.GlitterTransition-Klasse (und ihr Interface com.aspose.slides.IGlitterTransition) bezieht sich auf den Übergangstyp Glitter, der in dieser Version unterstützt wurde.
Die com.aspose.slides.TransitionPattern-Enumeration wird in dieser Klasse verwendet und spezifiziert ein geometrisches Muster, das zusammengekachelt wird, um eine größere Fläche zu füllen.
### **LeftRightDirectionTransition-Klasse, ILeftRightDirectionTransition-Interface und TransitionLeftRightDirectionType-Enumeration wurden hinzugefügt**
Die com.aspose.slides.LeftRightDirectionTransition-Klasse (und ihr Interface com.aspose.slides.ILeftRightDirectionTransition) bezieht sich auf die Übergangstypen Switch, Flip, Ferris, Gallery, Conveyor, die in dieser Version unterstützt wurden.
Die com.aspose.slides.TransitionLeftRightDirectionType-Enumeration wird in dieser Klasse verwendet und spezifiziert eine Richtung, die auf die Werte links und rechts beschränkt ist.
### **Neue Elemente wurden in die Enumeration com.aspose.slides.TransitionType hinzugefügt**
Die Enumeration com.aspose.slides.TransitionType wurde um neue Elemente erweitert.
Neue Elemente beziehen sich auf neue PowerPoint 2010-Übergänge: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse.
Neue Elemente beziehen sich auf neue PowerPoint 2013-Übergänge: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **RevealTransition-Klasse und IRevealTransition-Interface wurden hinzugefügt**
Die com.aspose.slides.RevealTransition-Klasse (und ihr Interface com.aspose.slides.IRevealTransition) bezieht sich auf den Übergangstyp Reveal, der in dieser Version unterstützt wurde.
Die RippleTransition-Klasse, das IRippleTransition-Interface und die TransitionCornerAndCenterDirectionType-Enumeration wurden hinzugefügt.
Die com.aspose.slides.RippleTransition-Klasse (und ihr Interface com.aspose.slides.IRippleTransition) bezieht sich auf den Übergangstyp Ripple, der in dieser Version unterstützt wurde.
Die com.aspose.slides.TransitionCornerAndCenterDirectionType-Enumeration wird in dieser Klasse verwendet und spezifiziert eine Richtung, die auf die Ecken und die Mitte beschränkt ist.
### **ShredTransition-Klasse, IShredTransition-Interface und TransitionShredPattern-Enumeration wurden hinzugefügt**
Die com.aspose.slides.ShredTransition-Klasse (und ihr Interface com.aspose.slides.IShredTransition) bezieht sich auf den Übergangstyp Shred, der in dieser Version unterstützt wurde.
Die com.aspose.slides.TransitionShredPattern-Enumeration wird in dieser Klasse verwendet und spezifiziert eine geometrische Form, die zusammengekachelt wird, um eine größere Fläche zu füllen.