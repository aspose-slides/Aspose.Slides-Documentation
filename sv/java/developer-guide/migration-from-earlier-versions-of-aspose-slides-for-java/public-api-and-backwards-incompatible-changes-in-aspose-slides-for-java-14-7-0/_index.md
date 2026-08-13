---
title: Publikt API och bakåtinkompatibla ändringar i Aspose.Slides för Java 14.7.0
linktitle: Aspose.Slides för Java 14.7.0
type: docs
weight: 60
url: /sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- migrering
- gammal kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Granska publika API-uppdateringar och brytande förändringar i Aspose.Slides för Java för att smidigt migrera dina PowerPoint PPT, PPTX och ODP-presentationer."
---
{{% alert color="info" %}} 

Den här sidan listar alla [tillagda](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) klasser, metoder, egenskaper med mera, eventuella nya begränsningar och andra förändringar som införts med Aspose.Slides för Java 14.7.0 API.

{{% /alert %}} 
## **Ändringar i offentligt API**
### **Konstruktörer för vissa TransitionValueBase‑undertyper har tagits bort och TransitionValueFactory har tagits bort**
Konstruktörer för vissa TransitionValueBase‑undertyper (och specifikt CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) är oanvändbara i det offentliga API:et och har därför tagits bort. Den relaterade klassen TransitionValueFactory och dess gränssnitt ITransitionValueFactory har tagits bort av samma anledning.
### **Elementet SoundAction har tagits bort från uppräkningen com.aspose.slides.TransitionType**
Elementet SoundAction var felaktigt och användes inte. Ljudinställningar definieras av egenskaperna SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Klassen FlyThroughTransition och gränssnittet IFlyThroughTransition har lagts till**
Klassen com.aspose.slides.FlyThroughTransition (och dess gränssnitt com.aspose.slides.IFlyThroughTransition) hör till övergångstypen Flythrough som har stöd i denna version.
### **Klassen GlitterTransition, gränssnittet IGlitterTransition och uppräkningen TransitionPattern har lagts till**
Klassen com.aspose.slides.GlitterTransition (och dess gränssnitt com.aspose.slides.IGlitterTransition) hör till övergångstypen Glitter som har stöd i denna version. Uppräkningen com.aspose.slides.TransitionPattern används i denna klass och specificerar ett geometriskt mönster som läggs ihop för att fylla ett större område.
### **Klassen LeftRightDirectionTransition, gränssnittet ILeftRightDirectionTransition och uppräkningen TransitionLeftRightDirectionType har lagts till**
Klassen com.aspose.slides.LeftRightDirectionTransition (och dess gränssnitt com.aspose.slides.ILeftRightDirectionTransition) hör till övergångstyperna Switch, Flip, Ferris, Gallery, Conveyor som har stöd i denna version. Uppräkningen com.aspose.slides.TransitionLeftRightDirectionType används i denna klass och specificerar en riktning begränsad till värdena vänster och höger.
### **Nya element har lagts till i uppräkningen com.aspose.slides.TransitionType**
Uppräkningen com.aspose.slides.TransitionType har utökats med nya element. Nya element relaterade till nya PowerPoint 2010‑övergångar: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse. Nya element relaterade till nya PowerPoint 2013‑övergångar: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **Klassen RevealTransition och gränssnittet IRevealTransition har lagts till**
Klassen com.aspose.slides.RevealTransition (och dess gränssnitt com.aspose.slides.IRevealTransition) hör till övergångstypen Reveal som har stöd i denna version.

Klassen com.aspose.slides.RippleTransition (och dess gränssnitt com.aspose.slides.IRippleTransition) hör till övergångstypen Ripple som har stöd i denna version. Uppräkningen com.aspose.slides.TransitionCornerAndCenterDirectionType används i denna klass och specificerar en riktning begränsad till hörnen och centrum.
### **Klassen ShredTransition, gränssnittet IShredTransition och uppräkningen TransitionShredPattern har lagts till**
Klassen com.aspose.slides.ShredTransition (och dess gränssnitt com.aspose.slides.IShredTransition) hör till övergångstypen Shred som har stöd i denna version. Uppräkningen com.aspose.slides.TransitionShredPattern används i denna klass och specificerar en geometrisk form som läggs ihop för att fylla ett större område.