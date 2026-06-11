---
title: Publikt API och bakåt inkompatibla förändringar i Aspose.Slides för Java 14.7.0
linktitle: Aspose.Slides för Java 14.7.0
type: docs
weight: 60
url: /sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- migration
- gammal kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Granska uppdateringar av offentligt API och brytande förändringar i Aspose.Slides för Java för att smidigt migrera dina PowerPoint PPT-, PPTX- och ODP-presentationer."
---
{{% alert color="primary" %}} 

Den här sidan listar alla [added](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) klasser, metoder, egenskaper osv., eventuella nya begränsningar och andra ändringar som introducerats med Aspose.Slides for Java 14.7.0 API.

{{% /alert %}} 
## **Ändringar i offentligt API**
### **Constructors of the some TransitionValueBase subtypes have been removed and TransitionValueFactory has been removed**
Konstruktörer för vissa TransitionValueBase‑subtyper (och specifikt CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) är onödiga i det offentliga API:et och har därför tagits bort. Den relaterade klassen TransitionValueFactory och dess gränssnitt ITransitionValueFactory har av samma anledning tagits bort.
### **Element SoundAction has been removed from com.aspose.slides.TransitionType enumeration**
Elementet SoundAction har tagits bort från uppräkningen com.aspose.slides.TransitionType.
### **FlyThroughTransition class and IFlyThroughTransition interface have been added**
Klassen FlyThroughTransition och gränssnittet IFlyThroughTransition har lagts till.
### **GlitterTransition class, IGlitterTransition interface and TransitionPattern enumeration have been added**
Klassen GlitterTransition, gränssnittet IGlitterTransition och uppräkningen TransitionPattern har lagts till.
### **LeftRightDirectionTransition class, ILeftRightDirectionTransition interface and TransitionLeftRightDirectionType enumeration have been added**
Klassen LeftRightDirectionTransition, gränssnittet ILeftRightDirectionTransition och uppräkningen TransitionLeftRightDirectionType har lagts till.
### **New elements have been added into com.aspose.slides.TransitionType enumeration**
Nya element har lagts till i uppräkningen com.aspose.slides.TransitionType.
### **RevealTransition class and IRevealTransition interface have been added**
Klassen RevealTransition och gränssnittet IRevealTransition har lagts till.
Element SoundAction var felaktigt och användes inte. Ljudinställningar definieras av egenskaperna SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
Klassen com.aspose.slides.FlyThroughTransition (och dess gränssnitt com.aspose.slides.IFlyThroughTransition) avser övergångstypen Flythrough som stöds i denna version.
Klassen com.aspose.slides.GlitterTransition (och dess gränssnitt com.aspose.slides.IGlitterTransition) avser övergångstypen Glitter som stöds i denna version. Uppräkningen com.aspose.slides.TransitionPattern används i denna klass och specificerar ett geometriskt mönster som läggs ihop för att fylla ett större område.
Klassen com.aspose.slides.LeftRightDirectionTransition (och dess gränssnitt com.aspose.slides.ILeftRightDirectionTransition) avser övergångstyperna Switch, Flip, Ferris, Gallery, Conveyor som stöds i denna version. Uppräkningen com.aspose.slides.TransitionLeftRightDirectionType används i denna klass och anger en riktning begränsad till värdena left och right.
Uppräkningen com.aspose.slides.TransitionType har utökats med nya element. Nya element relaterade till nya PowerPoint 2010‑övergångar: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse. Nya element relaterade till nya PowerPoint 2013‑övergångar: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
Klassen com.aspose.slides.RevealTransition (och dess gränssnitt com.aspose.slides.IRevealTransition) avser övergångstypen Reveal som stöds i denna version.
Klassen RippleTransition, gränssnittet IRippleTransition och uppräkningen TransitionCornerAndCenterDirectionType har lagts till. Klassen com.aspose.slides.RippleTransition (och dess gränssnitt com.aspose.slides.IRippleTransition) avser övergångstypen Ripple som stöds i denna version. Uppräkningen com.aspose.slides.TransitionCornerAndCenterDirectionType används i denna klass och specificerar en riktning begränsad till hörnen och mitten.
Klassen com.aspose.slides.ShredTransition (och dess gränssnitt com.aspose.slides.IShredTransition) avser övergångstypen Shred som stöds i denna version. Uppräkningen com.aspose.slides.TransitionShredPattern används i denna klass och specificerar en geometrisk form som läggs ihop för att fylla ett större område.