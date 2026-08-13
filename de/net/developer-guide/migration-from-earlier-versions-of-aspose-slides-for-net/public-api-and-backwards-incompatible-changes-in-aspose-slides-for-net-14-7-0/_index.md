---
title: Öffentliche API und rückwärtsinkompatible Änderungen in Aspose.Slides für .NET 14.7.0
linktitle: Aspose.Slides für .NET 14.7.0
type: docs
weight: 90
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- Migration
- Legacy‑Code
- Moderner Code
- Legacy‑Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Überblick über die öffentlichen API‑Updates und Breaking‑Changes in Aspose.Slides für .NET, um Ihre PowerPoint‑PPT-, PPTX‑ und ODP‑Präsentationslösungen reibungslos zu migrieren."
---
{{% alert color="info" %}} 

Diese Seite listet alle [added](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) oder [removed](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides für .NET 14.7.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen der öffentlichen API**
### **Entfernte Konstruktoren und Elemente**
#### **Entfernte einige TransitionValueBase Subtyp‑Konstruktoren und TransitionValueFactory**
Die Konstruktoren einiger TransitionValueBase‑Subtypen (insbesondere CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) sind in der öffentlichen API nutzlos und wurden daher entfernt. 

Die zugehörige Klasse TransitionValueFactory und ihre Schnittstelle ITransitionValueFactory wurden aus demselben Grund entfernt.
#### **Entfernt das SoundAction‑Element aus der Aspose.Slides.SlideShow.TransitionType‑Aufzählung**
Das SoundAction‑Element war fehlerhaft und wurde nicht verwendet. Toneinstellungen werden durch die Eigenschaften SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn und .SoundName definiert.
### **Hinzugefügte Klassen und Schnittstellen**
#### **Hinzugefügt die FlyThroughTransition‑Klasse und die IFlyThroughTransition‑Schnittstelle**
Die Klasse Aspose.Slides.SlideShow.FlyThroughTransition (und ihre Schnittstelle Aspose.Slides.SlideShow.IFlyThroughTransition) bezieht sich auf den Flythrough‑Übergangstyp, der ab diesem Release unterstützt wird.
#### **Hinzugefügt die GlitterTransition‑Klasse, die IGlitterTransition‑Schnittstelle und die TransitionPattern‑Aufzählung**
Die Klasse Aspose.Slides.SlideShow.GlitterTransition (und ihre Schnittstelle Aspose.Slides.SlideShow.IGlitterTransition) bezieht sich auf den Glitter‑Übergangstyp, der ab diesem Release unterstützt wird.

Die Aufzählung Aspose.Slides.SlideShow.TransitionPattern wird in dieser Klasse verwendet und gibt ein geometrisches Muster an, das zusammengefügt wird, um eine größere Fläche zu füllen.
#### **Hinzugefügt die LeftRightDirectionTransition‑Klasse, die ILeftRightDirectionTransition‑Schnittstelle und die TransitionLeftRightDirectionType‑Aufzählung**
Die Klasse Aspose.Slides.SlideShow.LeftRightDirectionTransition (und ihre Schnittstelle Aspose.Slides.SlideShow.ILeftRightDirectionTransition) bezieht sich auf die Übergangstypen Conveyor, Ferris, Flip, Gallery und Switch. Alle werden ab diesem Release unterstützt.

Die Aufzählung Aspose.Slides.SlideShow.TransitionLeftRightDirectionType wird in dieser Klasse verwendet und gibt eine Richtung an, die auf die Werte left und right beschränkt ist.
#### **Hinzugefügt neue Elemente zur Aspose.Slides.SlideShow.TransitionType‑Aufzählung**
Die Aufzählung Aspose.Slides.SlideShow.TransitionType wurde um neue Elemente erweitert.

- Neue Elemente im Zusammenhang mit PowerPoint 2010‑Übergängen: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- Neue Elemente im Zusammenhang mit den neuen PowerPoint 2013‑Übergängen: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **Hinzugefügt die RevealTransition‑Klasse und die IRevealTransition‑Schnittstelle**
Die Klasse Aspose.Slides.SlideShow.RevealTransition (und ihre Schnittstelle Aspose.Slides.SlideShow.IRevealTransition) bezieht sich auf den Reveal‑Übergangstyp, der ab diesem Release unterstützt wird.
#### **Hinzugefügt die RippleTransition‑Klasse, die IRippleTransition‑Schnittstelle und die TransitionCornerAndCenterDirectionType‑Aufzählung**
Die Klasse Aspose.Slides.SlideShow.RippleTransition (und ihre Schnittstelle Aspose.Slides.SlideShow.IRippleTransition) bezieht sich auf den Ripple‑Übergangstyp, der ab diesem Release unterstützt wird.

Die Aufzählung Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType wird in dieser Klasse verwendet und gibt eine Richtung an, die auf die Ecken und die Mitte beschränkt ist.