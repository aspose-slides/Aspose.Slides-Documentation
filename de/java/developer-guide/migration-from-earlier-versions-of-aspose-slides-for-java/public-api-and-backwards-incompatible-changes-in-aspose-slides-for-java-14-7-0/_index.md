---
title: Öffentliche API und rückwärtsinkompatible Änderungen in Aspose.Slides für Java 14.7.0
linktitle: Aspose.Slides für Java 14.7.0
type: docs
weight: 60
url: /de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- Migration
- Legacy-Code
- Moderner Code
- Legacy-Ansatz
- Moderne Vorgehensweise
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Überprüfen Sie die Aktualisierungen der öffentlichen API und Breaking Changes in Aspose.Slides für Java, um Ihre PowerPoint PPT, PPTX und ODP Präsentationslösungen reibungslos zu migrieren."
---
{{% alert color="info" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) Klassen, Methoden, Eigenschaften usw. sowie neue Einschränkungen und weitere Änderungen, die mit der Aspose.Slides for Java 14.7.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen der öffentlichen API**
### **Konstruktoren einiger TransitionValueBase‑Untertypen wurden entfernt und TransitionValueFactory wurde entfernt**
Konstruktoren einiger TransitionValueBase‑Untertypen (insbesondere CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) sind in der öffentlichen API nutzlos und wurden deshalb entfernt. Die zugehörige Klasse TransitionValueFactory und ihr Interface ITransitionValueFactory wurden aus demselben Grund entfernt.

### **Element SoundAction wurde aus der Aufzählung com.aspose.slides.TransitionType entfernt**
Das Element SoundAction war fehlerhaft und wurde nicht verwendet. Toneinstellungen werden durch die Eigenschaften SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName definiert.

### **Klasse FlyThroughTransition und Interface IFlyThroughTransition wurden hinzugefügt**
Die Klasse com.aspose.slides.FlyThroughTransition (und ihr Interface com.aspose.slides.IFlyThroughTransition) bezieht sich auf den Übergangstyp Flythrough, der in dieser Version unterstützt wird.

### **Klasse GlitterTransition, Interface IGlitterTransition und Aufzählung TransitionPattern wurden hinzugefügt**
Die Klasse com.aspose.slides.GlitterTransition (und ihr Interface com.aspose.slides.IGlitterTransition) bezieht sich auf den Übergangstyp Glitter, der in dieser Version unterstützt wird. Die Aufzählung com.aspose.slides.TransitionPattern wird in dieser Klasse verwendet und gibt ein geometrisches Muster an, das zusammengefügt ein größeres Gebiet füllt.

### **Klasse LeftRightDirectionTransition, Interface ILeftRightDirectionTransition und Aufzählung TransitionLeftRightDirectionType wurden hinzugefügt**
Die Klasse com.aspose.slides.LeftRightDirectionTransition (und ihr Interface com.aspose.slides.ILeftRightDirectionTransition) bezieht sich auf die Übergangstypen Switch, Flip, Ferris, Gallery, Conveyor, die in dieser Version unterstützt werden. Die Aufzählung com.aspose.slides.TransitionLeftRightDirectionType wird in dieser Klasse verwendet und gibt eine Richtung an, die auf die Werte links und rechts beschränkt ist.

### **Neue Elemente wurden zur Aufzählung com.aspose.slides.TransitionType hinzugefügt**
Die Aufzählung com.aspose.slides.TransitionType wurde um neue Elemente erweitert. Neue Elemente im Zusammenhang mit den PowerPoint‑2010‑Übergängen: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse. Neue Elemente im Zusammenhang mit den PowerPoint‑2013‑Übergängen: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.

### **Klasse RevealTransition und Interface IRevealTransition wurden hinzugefügt**
Die Klasse com.aspose.slides.RevealTransition (und ihr Interface com.aspose.slides.IRevealTransition) bezieht sich auf den Übergangstyp Reveal, der in dieser Version unterstützt wird.
Klasse RippleTransition, Interface IRippleTransition und Aufzählung TransitionCornerAndCenterDirectionType wurden hinzugefügt
Die Klasse com.aspose.slides.RippleTransition (und ihr Interface com.aspose.slides.IRippleTransition) bezieht sich auf den Übergangstyp Ripple, der in dieser Version unterstützt wird. Die Aufzählung com.aspose.slides.TransitionCornerAndCenterDirectionType wird in dieser Klasse verwendet und gibt eine Richtung an, die auf die Ecken und die Mitte beschränkt ist.

### **Klasse ShredTransition, Interface IShredTransition und Aufzählung TransitionShredPattern wurden hinzugefügt**
Die Klasse com.aspose.slides.ShredTransition (und ihr Interface com.aspose.slides.IShredTransition) bezieht sich auf den Übergangstyp Shred, der in dieser Version unterstützt wird. Die Aufzählung com.aspose.slides.TransitionShredPattern wird in dieser Klasse verwendet und gibt eine geometrische Form an, die zusammengefügt ein größeres Gebiet füllt.