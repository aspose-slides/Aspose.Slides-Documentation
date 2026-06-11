---
title: Offentligt API och bakåtinkompatibla förändringar i Aspose.Slides för .NET 14.7.0
linktitle: Aspose.Slides för .NET 14.7.0
type: docs
weight: 90
url: /sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- migration
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
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för .NET för att smidigt migrera dina PowerPoint PPT, PPTX och ODP presentationslösningar."
---
{{% alert color="primary" %}} 
Den här sidan listar alla [tillagda](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) eller [borttagna](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) klasser, metoder, egenskaper och så vidare, samt andra förändringar som införts med Aspose.Slides för .NET 14.7.0 API.
{{% /alert %}} 
## **Offentliga API-förändringar**
### **Borttagna konstruktorer och element**
#### **Borttagna vissa TransitionValueBase-deltypskonstruktorer och TransitionValueFactory**
Konstruktorerna för vissa TransitionValueBase-deltyper (specifikt CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) är onödiga i det offentliga API:et och har därför tagits bort.  

Den relaterade klassen TransitionValueFactory och dess gränssnitt ITransitionValueFactory har tagits bort av samma anledning.  
#### **Borttaget SoundAction-elementet från Aspose.Slides.SlideShow.TransitionType‑enumerationen**
SoundAction‑elementet var felaktigt och användes inte. Ljudinställningar definieras av egenskaperna SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.  
### **Tillagda klasser och gränssnitt**
#### **Tillagt FlyThroughTransition‑klassen och IFlyThroughTransition‑gränssnittet**
Klassen Aspose.Slides.SlideShow.FlyThroughTransition (och dess gränssnitt Aspose.Slides.SlideShow.IFlyThroughTransition) gäller Flythrough‑övergångstypen som stöds från denna version.  
#### **Tillagt GlitterTransition‑klassen, IGlitterTransition‑gränssnittet och TransitionPattern‑enumerationen**
Klassen Aspose.Slides.SlideShow.GlitterTransition (och dess gränssnitt Aspose.Slides.SlideShow.IGlitterTransition) gäller Glitter‑övergångstypen som stöds från denna version.  

Enumerationen Aspose.Slides.SlideShow.TransitionPattern används i denna klass och anger ett geometriskt mönster som läggs ihop för att fylla ett större område.  
#### **Tillagt LeftRightDirectionTransition‑klassen, ILeftRightDirectionTransition‑gränssnittet och TransitionLeftRightDirectionType‑enumerationen**
Klassen Aspose.Slides.SlideShow.LeftRightDirectionTransition (och dess gränssnitt Aspose.Slides.SlideShow.ILeftRightDirectionTransition) gäller övergångstyperna Conveyor, Ferris, Flip, Gallery och Switch. Alla stöds från denna version.  

Enumerationen Aspose.Slides.SlideShow.TransitionLeftRightDirectionType används i denna klass och anger en riktning, begränsad till värdena left och right.  
#### **Tillagda nya element till Aspose.Slides.SlideShow.TransitionType‑enumerationen**
Enumerationen Aspose.Slides.SlideShow.TransitionType har utökats med nya element.  

- Nya element relaterade till PowerPoint 2010‑övergångar: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.  
- Nya element relaterade till de nya PowerPoint 2013‑övergångarna: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.  
#### **Tillagt RevealTransition‑klassen och IRevealTransition‑gränssnittet**
Klassen Aspose.Slides.SlideShow.RevealTransition (och dess gränssnitt Aspose.Slides.SlideShow.IRevealTransition) gäller Reveal‑övergångstypen som stöds från denna version.  
#### **Tillagt RippleTransition‑klassen, IRippleTransition‑gränssnittet och TransitionCornerAndCenterDirectionType‑enumerationen**
Klassen Aspose.Slides.SlideShow.RippleTransition (och dess gränssnitt Aspose.Slides.SlideShow.IRippleTransition) gäller Ripple‑övergångstypen som stöds från denna version.  

Enumerationen Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType används i denna klass och anger en riktning, begränsad till hörnen och centrum.