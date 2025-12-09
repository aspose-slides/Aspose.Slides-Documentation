---
title: Public API und rückwärts inkompatible Änderungen in Aspose.Slides für .NET 14.7.0
linktitle: Aspose.Slides für .NET 14.7.0
type: docs
weight: 90
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- Migration
- Legacy-Code
- Moderner Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Überprüfen Sie die Aktualisierungen der öffentlichen API und die Breaking Changes in Aspose.Slides für .NET, um Ihre PowerPoint PPT, PPTX und ODP-Präsentationslösungen reibungslos zu migrieren."
---

{{% alert color="primary" %}} 

Diese Seite listet alle [added](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) oder [removed](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides für .NET 14.7.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen an der öffentlichen API**
### **Entfernte Konstruktoren und Elemente**
#### **Entfernte einige TransitionValueBase-Untersortenkonstruktoren und TransitionValueFactory**
Die Konstruktoren einiger TransitionValueBase-Untersorten (insbesondere CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) sind in der öffentlichen API nutzlos und wurden daher entfernt.  

Die zugehörige Klasse TransitionValueFactory und ihr Interface ITransitionValueFactory wurden aus demselben Grund entfernt.
#### **Entferntes SoundAction‑Element aus der Aspose.Slides.SlideShow.TransitionType‑Aufzählung**
Das SoundAction‑Element war fehlerhaft und wurde nicht verwendet. Soundeinstellungen werden über die Eigenschaften SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName definiert.
### **Hinzugefügte Klassen und Interfaces**
#### **Hinzugefügte Klasse FlyThroughTransition und Interface IFlyThroughTransition**
Die Klasse Aspose.Slides.SlideShow.FlyThroughTransition (und ihr Interface Aspose.Slides.SlideShow.IFlyThroughTransition) bezieht sich auf den Flythrough‑Übergangstyp, der ab dieser Version unterstützt wird.
#### **Hinzugefügte Klasse GlitterTransition, Interface IGlitterTransition und Aufzählung TransitionPattern**
Die Klasse Aspose.Slides.SlideShow.GlitterTransition (und ihr Interface Aspose.Slides.SlideShow.IGlitterTransition) bezieht sich auf den Glitter‑Übergangstyp, der ab dieser Version unterstützt wird.  

Die Aufzählung Aspose.Slides.SlideShow.TransitionPattern wird in dieser Klasse verwendet und gibt ein geometrisches Muster an, das zusammengefügt ein größeres Gebiet füllt.
#### **Hinzugefügte Klasse LeftRightDirectionTransition, Interface ILeftRightDirectionTransition und Aufzählung TransitionLeftRightDirectionType**
Die Klasse Aspose.Slides.SlideShow.LeftRightDirectionTransition (und ihr Interface Aspose.Slides.SlideShow.ILeftRightDirectionTransition) bezieht sich auf die Übergangstypen Conveyor, Ferris, Flip, Gallery und Switch. Alle werden ab dieser Version unterstützt.  

Die Aufzählung Aspose.Slides.SlideShow.TransitionLeftRightDirectionType wird in dieser Klasse verwendet und gibt eine Richtung an, beschränkt auf die Werte left und right.
#### **Hinzugefügte neue Elemente zur Aspose.Slides.SlideShow.TransitionType‑Aufzählung**
Die Aufzählung Aspose.Slides.SlideShow.TransitionType wurde um neue Elemente erweitert.

- Neue Elemente im Zusammenhang mit PowerPoint 2010‑Übergängen: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.  
- Neue Elemente im Zusammenhang mit den PowerPoint 2013‑Übergängen: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **Hinzugefügte Klasse RevealTransition und Interface IRevealTransition**
Die Klasse Aspose.Slides.SlideShow.RevealTransition (und ihr Interface Aspose.Slides.SlideShow.IRevealTransition) bezieht sich auf den Reveal‑Übergangstyp, der ab dieser Version unterstützt wird.
#### **Hinzugefügte Klasse RippleTransition, Interface IRippleTransition und Aufzählung TransitionCornerAndCenterDirectionType**
Die Klasse Aspose.Slides.SlideShow.RippleTransition (und ihr Interface Aspose.Slides.SlideShow.IRippleTransition) bezieht sich auf den Ripple‑Übergangstyp, der ab dieser Version unterstützt wird.  

Die Aufzählung Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType wird in dieser Klasse verwendet und gibt eine Richtung an, beschränkt auf die Ecken und die Mitte.