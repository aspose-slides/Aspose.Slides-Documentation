---
title: Publikus API és visszafelé nem kompatibilis változások az Aspose.Slides for Java 14.7.0-ban
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
description: "Tekintse át az Aspose.Slides for Java publikus API frissítéseit és a töréspont változásokat, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="primary" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) osztályt, metódust, tulajdonságot stb., valamint az új korlátozásokat és egyéb változásokat, amelyeket az Aspose.Slides for Java 14.7.0 API vezet be.

{{% /alert %}} 
## **Publikus API változások**
### **Néhány TransitionValueBase alosztály konstruktorai és a TransitionValueFactory eltávolításra kerültek**
A néhány TransitionValueBase alosztály (és különösen a CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) konstruktorai feleslegesek a publikus API-ban, ezért eltávolításra kerültek. A kapcsolódó TransitionValueFactory osztályt és ITransitionValueFactory interfészt ugyanazon okból eltávolították.
### **A SoundAction elem eltávolításra került a com.aspose.slides.TransitionType felsorolásból**
A SoundAction elem helytelen volt, és nem volt használva. A hangbeállításokat a SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName tulajdonságok határozzák meg.
### **FlyThroughTransition osztály és IFlyThroughTransition interfész hozzáadva**
A com.aspose.slides.FlyThroughTransition osztály (és a hozzá tartozó com.aspose.slides.IFlyThroughTransition interfész) a Flythrough áttűnés típusra vonatkozik, amely ebben a kiadásban támogatott.
### **GlitterTransition osztály, IGlitterTransition interfész és a TransitionPattern felsorolás hozzáadva**
A com.aspose.slides.GlitterTransition osztály (és a hozzá tartozó com.aspose.slides.IGlitterTransition interfész) a Glitter áttűnés típusra vonatkozik, amely ebben a kiadásban támogatott. A com.aspose.slides.TransitionPattern felsorolást ebben az osztályban használják, és egy geometriai mintát határoz meg, amely egymásra helyezve nagyobb területet tölt ki.
### **LeftRightDirectionTransition osztály, ILeftRightDirectionTransition interfész és a TransitionLeftRightDirectionType felsorolás hozzáadva**
A com.aspose.slides.LeftRightDirectionTransition osztály (és a hozzá tartozó com.aspose.slides.ILeftRightDirectionTransition interfész) a Switch, Flip, Ferris, Gallery, Conveyor áttűnés típusokra vonatkozik, amelyek ebben a kiadásban támogatottak. A com.aspose.slides.TransitionLeftRightDirectionType felsorolást ebben az osztályban használják, és egy olyan irányt határoz meg, amely csak a bal és jobb értékekre korlátozódik.
### **Új elemeket adtak hozzá a com.aspose.slides.TransitionType felsoroláshoz**
A com.aspose.slides.TransitionType felsorolást új elemekkel bővítették. Az új PowerPoint 2010 áttűnésekhez kapcsolódó elemek: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse. Az új PowerPoint 2013 áttűnésekhez kapcsolódó elemek: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **RevealTransition osztály és IRevealTransition interfész hozzáadva**
A com.aspose.slides.RevealTransition osztály (és a hozzá tartozó com.aspose.slides.IRevealTransition interfész) a Reveal áttűnés típusra vonatkozik, amely ebben a kiadásban támogatott.
A RippleTransition osztály, az IRippleTransition interfész és a TransitionCornerAndCenterDirectionType felsorolás hozzá lett adva.
A com.aspose.slides.RippleTransition osztály (és a hozzá tartozó com.aspose.slides.IRippleTransition interfész) a Ripple áttűnés típusra vonatkozik, amely ebben a kiadásban támogatott. A com.aspose.slides.TransitionCornerAndCenterDirectionType felsorolást ebben az osztályban használják, és egy olyan irányt határoz meg, amely a sarkokra és a középre korlátozódik.
### **ShredTransition osztály, IShredTransition interfész és a TransitionShredPattern felsorolás hozzáadva**
A com.aspose.slides.ShredTransition osztály (és a hozzá tartozó com.aspose.slides.IShredTransition interfész) a Shred áttűnés típusra vonatkozik, amely ebben a kiadásban támogatott. A com.aspose.slides.TransitionShredPattern felsorolást ebben az osztályban használják, és egy geometriai alakzatot határoz meg, amely egymásra helyezve nagyobb területet tölt ki.