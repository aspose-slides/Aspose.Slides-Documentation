---
title: Publikt API och bakåt oförenliga ändringar i Aspose.Slides för .NET 14.7.0
linktitle: Aspose.Slides för .NET 14.7.0
type: docs
weight: 90
url: /sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- migrering
- gammal kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för .NET för att smidigt migrera dina PowerPoint PPT-, PPTX- och ODP-presentationslösningar."
---
{{% alert color="info" %}} 

Den här sidan listar alla [tillagda](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) eller [borttagna](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) klasser, metoder, egenskaper osv, och andra förändringar som införts med Aspose.Slides for .NET 14.7.0 API.

{{% /alert %}} 
## **Publika API-ändringar**
### **Borttagna konstruktorer och element**
#### **Borttagna vissa TransitionValueBase-subtypkonstruktorer och TransitionValueFactory**
Konstruktorerna för vissa TransitionValueBase-subtyper (specifikt CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) är onödiga i det offentliga API:et och har därför tagits bort. 

Den relaterade klassen TransitionValueFactory och dess gränssnitt ITransitionValueFactory har tagits bort av samma anledning.
#### **Borttagen SoundAction-elementet från Aspose.Slides.SlideShow.TransitionType‑enumerationen**
SoundAction-elementet var felaktigt och användes inte. Ljudinställningar definieras av egenskaperna SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Tillagda klasser och gränssnitt**
#### **Tillagd FlyThroughTransition-klass och IFlyThroughTransition‑gränssnitt**
Klassen Aspose.Slides.SlideShow.FlyThroughTransition (och dess gränssnitt Aspose.Slides.SlideShow.IFlyThroughTransition) hör till Flythrough‑övergångstypen som stöds från denna version.
#### **Tillagd GlitterTransition-klass, IGlitterTransition‑gränssnitt och TransitionPattern‑enumeration**
Klassen Aspose.Slides.SlideShow.GlitterTransition (och dess gränssnitt Aspose.Slides.SlideShow.IGlitterTransition) hör till Glitter‑övergångstypen som stöds från denna version.

Aspose.Slides.SlideShow.TransitionPattern‑enumerationen används i denna klass och specificerar ett geometriskt mönster som bildar en mosaik för att fylla ett större område.
#### **Tillagd LeftRightDirectionTransition-klass, ILeftRightDirectionTransition‑gränssnitt och TransitionLeftRightDirectionType‑enumeration**
Klassen Aspose.Slides.SlideShow.LeftRightDirectionTransition (och dess gränssnitt Aspose.Slides.SlideShow.ILeftRightDirectionTransition) hör till övergångstyperna Conveyor, Ferris, Flip, Gallery och Switch. Alla stöds från denna version.

Aspose.Slides.SlideShow.TransitionLeftRightDirectionType‑enumerationen används i denna klass och specificerar en riktning, begränsad till värdena left och right.
#### **Tillagda nya element till Aspose.Slides.SlideShow.TransitionType‑enumerationen**
Aspose.Slides.SlideShow.TransitionType‑enumerationen har utökats med nya element.

- Nya element relaterade till PowerPoint 2010-övergångar: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- Nya element relaterade till de nya PowerPoint 2013-övergångarna: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **Tillagd RevealTransition-klass och IRevealTransition‑gränssnitt**
Klassen Aspose.Slides.SlideShow.RevealTransition (och dess gränssnitt Aspose.Slides.SlideShow.IRevealTransition) hör till Reveal‑övergångstypen som stöds från denna version.
#### **Tillagd RippleTransition-klass, IRippleTransition‑gränssnitt och TransitionCornerAndCenterDirectionType‑enumeration**
Klassen Aspose.Slides.SlideShow.RippleTransition (och dess gränssnitt Aspose.Slides.SlideShow.IRippleTransition) hör till Ripple‑övergångstypen som stöds från denna version.

Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType‑enumerationen används i denna klass och specificerar en riktning, begränsad till hörnen och centrum.