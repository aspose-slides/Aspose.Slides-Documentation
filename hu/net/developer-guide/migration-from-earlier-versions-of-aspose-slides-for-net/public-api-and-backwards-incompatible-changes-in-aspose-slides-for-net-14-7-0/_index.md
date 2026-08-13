---
title: Publikus API és visszafelé nem kompatibilis változások az Aspose.Slides .NET 14.7.0-ban
linktitle: Aspose.Slides .NET 14.7.0
type: docs
weight: 90
url: /hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- migráció
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tekintse át a publikus API frissítéseit és a visszafelé nem kompatibilis változásokat az Aspose.Slides for .NET-ben, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="info" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) vagy [eltávolított](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) osztályt, metódust, tulajdonságot stb., valamint a Aspose.Slides for .NET 14.7.0 API-val bevezetett egyéb változásokat.

{{% /alert %}} 
## **Publikus API változások**
### **Eltávolított konstruktőrök és elemek**
#### **Eltávolított néhány TransitionValueBase alosztály konstruktőre és a TransitionValueFactory**
A néhány TransitionValueBase alosztály (konkrétan CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) konstruktőrei haszontalannak bizonyultak a publikus API-ban, ezért el lettek távolítva.  

A kapcsolódó TransitionValueFactory osztály és az ITransitionValueFactory interfész ugyanazért az okért lett eltávolítva.  
#### **Eltávolítva a SoundAction elem az Aspose.Slides.SlideShow.TransitionType felsorolásból**
A SoundAction elem helytelen volt és nem volt használatban. A hangbeállításokat a SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn és .SoundName tulajdonságok határozzák meg.  
### **Hozzáadott osztályok és interfészek**
#### **Hozzáadva a FlyThroughTransition osztály és az IFlyThroughTransition interfész**
Az Aspose.Slides.SlideShow.FlyThroughTransition osztály (és az Aspose.Slides.SlideShow.IFlyThroughTransition interfész) a kiadás óta támogatott Flythrough átmenettípusra vonatkozik.  
#### **Hozzáadva a GlitterTransition osztály, az IGlitterTransition interfész és a TransitionPattern felsorolás**
Az Aspose.Slides.SlideShow.GlitterTransition osztály (és az Aspose.Slides.SlideShow.IGlitterTransition interfész) a kiadás óta támogatott Glitter átmenettípusra vonatkozik.  

Az Aspose.Slides.SlideShow.TransitionPattern felsorolás ebben az osztályban használható, és egy geometriai mintát határoz meg, amely egymásra helyezve nagyobb területet tölt ki.  
#### **Hozzáadva a LeftRightDirectionTransition osztály, az ILeftRightDirectionTransition interfész és a TransitionLeftRightDirectionType felsorolás**
Az Aspose.Slides.SlideShow.LeftRightDirectionTransition osztály (és az Aspose.Slides.SlideShow.ILeftRightDirectionTransition interfész) a Conveyor, Ferris, Flip, Gallery és Switch átmenettípusokra vonatkozik. Mind támogatott a kiadástól.  

Az Aspose.Slides.SlideShow.TransitionLeftRightDirectionType felsorolás ebben az osztályban használatos, és egy irányt határoz meg, amely csak a left és right értékekre korlátozódik.  
#### **Új elemek hozzáadva az Aspose.Slides.SlideShow.TransitionType felsoroláshoz**
Az Aspose.Slides.SlideShow.TransitionType felsorolást új elemekkel bővítették.  

- Új, a PowerPoint 2010 átmenetekhez kapcsolódó elemek: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.  
- Új, az új PowerPoint 2013 átmenetekhez kapcsolódó elemek: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.  
#### **Hozzáadva a RevealTransition osztály és az IRevealTransition interfész**
Az Aspose.Slides.SlideShow.RevealTransition osztály (és az Aspose.Slides.SlideShow.IRevealTransition interfész) a kiadás óta támogatott Reveal átmenettípusra vonatkozik.  
#### **Hozzáadva a RippleTransition osztály, az IRippleTransition interfész és a TransitionCornerAndCenterDirectionType felsorolás**
Az Aspose.Slides.SlideShow.RippleTransition osztály (és az Aspose.Slides.SlideShow.IRippleTransition interfész) a kiadás óta támogatott Ripple átmenettípusra vonatkozik.  

Az Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType felsorolás ebben az osztályban használatos, és egy irányt határoz meg, amely csak a sarkokra és a középre korlátozódik.