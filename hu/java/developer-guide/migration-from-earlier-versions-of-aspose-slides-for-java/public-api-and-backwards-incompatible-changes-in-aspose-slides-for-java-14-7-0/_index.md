---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for Java 14.7.0-ban
linktitle: Aspose.Slides for Java 14.7.0
type: docs
weight: 60
url: /hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- migráció
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Tekintse át a nyilvános API frissítéseit és a visszafelé nem kompatibilis változásokat az Aspose.Slides for Java-ban, hogy zökkenőmentesen migruálhasson PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="info" %}} 
Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) osztályt, metódust, tulajdonságot stb., valamint az új korlátozásokat és egyéb változásokat, amelyeket az Aspose.Slides for Java 14.7.0 API bevezet.
{{% /alert %}} 
## **Nyilvános API változások**
### **Néhány TransitionValueBase alosztály konstruktorai és a TransitionValueFactory eltávolítva**
A néhány TransitionValueBase alosztály (és különösen a CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) konstruktorai a nyilvános API-ban haszontalanok, ezért eltávolításra kerültek. A kapcsolódó TransitionValueFactory osztály és ITransitionValueFactory interfész ugyanazon okból el lett távolítva.
### **A SoundAction elem eltávolítva a com.aspose.slides.TransitionType felsorolásból**
A SoundAction elem hibás volt és nem volt használatban. A hangbeállításokat a SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn és .SoundName tulajdonságok határozzák meg.
### **FlyThroughTransition osztály és IFlyThroughTransition interfész hozzáadva**
A com.aspose.slides.FlyThroughTransition osztály (és a hozzá tartozó com.aspose.slides.IFlyThroughTransition interfész) a Flythrough átmenettípushoz kapcsolódik, amely ebben a kiadásban támogatott.
### **GlitterTransition osztály, IGlitterTransition interfész és a TransitionPattern felsorolás hozzáadva**
A com.aspose.slides.GlitterTransition osztály (és a hozzá tartozó com.aspose.slides.IGlitterTransition interfész) a Glitter átmenettípushoz kapcsolódik, amely ebben a kiadásban támogatott. A com.aspose.slides.TransitionPattern felsorolás ebben az osztályban van használva, és egy geometriai mintát határoz meg, amely egymásra tépésként nagyobb területet tölt ki.
### **LeftRightDirectionTransition osztály, ILeftRightDirectionTransition interfész és a TransitionLeftRightDirectionType felsorolás hozzáadva**
A com.aspose.slides.LeftRightDirectionTransition osztály (és a hozzá tartozó com.aspose.slides.ILeftRightDirectionTransition interfész) a Switch, Flip, Ferris, Gallery és Conveyor átmenettípusokhoz kapcsolódik, amelyek ebben a kiadásban támogatottak. A com.aspose.slides.TransitionLeftRightDirectionType felsorolás ebben az osztályban van használva, és egy irányt határoz meg, amely csak a bal és jobb értékekre korlátozódik.
### **Új elemek hozzáadva a com.aspose.slides.TransitionType felsoroláshoz**
A com.aspose.slides.TransitionType felsorolás új elemekkel lett bővítve. Az új PowerPoint 2010 átmenetekhez kapcsolódó elemek: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse. Az új PowerPoint 2013 átmenetekhez kapcsolódó elemek: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **RevealTransition osztály és IRevealTransition interfész hozzáadva**
A com.aspose.slides.RevealTransition osztály (és a hozzá tartozó com.aspose.slides.IRevealTransition interfész) a Reveal átmenettípushoz kapcsolódik, amely ebben a kiadásban támogatott. A RippleTransition osztály, az IRippleTransition interfész és a TransitionCornerAndCenterDirectionType felsorolás hozzá lett adva. A com.aspose.slides.RippleTransition osztály (és a hozzá tartozó com.aspose.slides.IRippleTransition interfész) a Ripple átmenettípushoz kapcsolódik, amely ebben a kiadásban támogatott. A com.aspose.slides.TransitionCornerAndCenterDirectionType felsorolás ebben az osztályban van használva, és egy olyan irányt határoz meg, amely a sarkokra és a középre korlátozódik.
### **ShredTransition osztály, IShredTransition interfész és a TransitionShredPattern felsorolás hozzáadva**
A com.aspose.slides.ShredTransition osztály (és a hozzá tartozó com.aspose.slides.IShredTransition interfész) a Shred átmenettípushoz kapcsolódik, amely ebben a kiadásban támogatott. A com.aspose.slides.TransitionShredPattern felsorolás ebben az osztályban van használva, és egy geometriai alakzatot határoz meg, amely egymásra tépésként nagyobb területet tölt ki.