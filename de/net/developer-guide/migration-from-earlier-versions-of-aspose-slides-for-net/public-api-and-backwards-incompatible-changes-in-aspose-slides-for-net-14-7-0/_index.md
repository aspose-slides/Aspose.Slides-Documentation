---
title: Öffentliche API und rückwärtsinkompatible Änderungen in Aspose.Slides für .NET 14.7.0
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
description: "Überblicken Sie die Aktualisierungen der öffentlichen API und die inkompatiblen Änderungen in Aspose.Slides für .NET, um Ihre PowerPoint-PPT-, PPTX- und ODP-Präsentationslösungen reibungslos zu migrieren."
---

{{% alert color="primary" %}} 
Diese Seite listet alle hinzugefügten oder entfernten Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen auf, die mit der Aspose.Slides für .NET 14.7.0 API eingeführt wurden.
{{% /alert %}} 
## **Änderungen der öffentlichen API**
### **Entfernte Konstruktoren und Elemente**
#### **Einige Konstruktoren von TransitionValueBase‑Untertypen und TransitionValueFactory entfernt**
Die Konstruktoren einiger TransitionValueBase‑Untertypen (insbesondere CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) sind in der öffentlichen API nutzlos und wurden daher entfernt. 
Die zugehörige Klasse TransitionValueFactory und ihr Interface ITransitionValueFactory wurden aus demselben Grund entfernt.
#### **Das SoundAction‑Element aus der Aufzählung Aspose.Slides.SlideShow.TransitionType entfernt**
Das SoundAction‑Element war falsch und wurde nicht verwendet. Sound‑Einstellungen werden durch die Eigenschaften SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn und .SoundName definiert.
### **Hinzugefügte Klassen und Interfaces**
#### **Die Klasse FlyThroughTransition und das Interface IFlyThroughTransition hinzugefügt**
Die Klasse Aspose.Slides.SlideShow.FlyThroughTransition (und ihr Interface Aspose.Slides.SlideShow.IFlyThroughTransition) bezieht sich auf den Flythrough‑Übergangstyp, der ab dieser Version unterstützt wird.
#### **Die Klasse GlitterTransition, das Interface IGlitterTransition und die Aufzählung TransitionPattern hinzugefügt**
Die Klasse Aspose.Slides.SlideShow.GlitterTransition (und ihr Interface Aspose.Slides.SlideShow.IGlitterTransition) bezieht sich auf den Glitter‑Übergangstyp, der ab dieser Version unterstützt wird.
Die Aufzählung Aspose.Slides.SlideShow.TransitionPattern wird in dieser Klasse verwendet und gibt ein geometrisches Muster an, das zusammengefügt wird, um einen größeren Bereich zu füllen.
#### **Die Klasse LeftRightDirectionTransition, das Interface ILeftRightDirectionTransition und die Aufzählung TransitionLeftRightDirectionType hinzugefügt**
Die Klasse Aspose.Slides.SlideShow.LeftRightDirectionTransition (und ihr Interface Aspose.Slides.SlideShow.ILeftRightDirectionTransition) bezieht sich auf die Übergangstypen Conveyor, Ferris, Flip, Gallery und Switch. Alle werden ab dieser Version unterstützt.
Die Aufzählung Aspose.Slides.SlideShow.TransitionLeftRightDirectionType wird in dieser Klasse verwendet und gibt eine Richtung an, die auf die Werte left und right beschränkt ist.
#### **Neue Elemente zur Aufzählung Aspose.Slides.SlideShow.TransitionType hinzugefügt**
Die Aufzählung Aspose.Slides.SlideShow.TransitionType wurde um neue Elemente erweitert.
- Neue Elemente im Zusammenhang mit PowerPoint‑2010‑Übergängen: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- Neue Elemente im Zusammenhang mit den neuen PowerPoint‑2013‑Übergängen: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **Die Klasse RevealTransition und das Interface IRevealTransition hinzugefügt**
Die Klasse Aspose.Slides.SlideShow.RevealTransition (und ihr Interface Aspose.Slides.SlideShow.IRevealTransition) bezieht sich auf den Reveal‑Übergangstyp, der ab dieser Version unterstützt wird.
#### **Die Klasse RippleTransition, das Interface IRippleTransition und die Aufzählung TransitionCornerAndCenterDirectionType hinzugefügt**
Die Klasse Aspose.Slides.SlideShow.RippleTransition (und ihr Interface Aspose.Slides.SlideShow.IRippleTransition) bezieht sich auf den Ripple‑Übergangstyp, der ab dieser Version unterstützt wird.
Die Aufzählung Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType wird in dieser Klasse verwendet und gibt eine Richtung an, die auf die Ecken und die Mitte beschränkt ist.