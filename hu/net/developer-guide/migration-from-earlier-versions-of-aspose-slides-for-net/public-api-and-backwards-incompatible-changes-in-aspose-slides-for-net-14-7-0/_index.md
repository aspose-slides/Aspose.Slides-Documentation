---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for .NET 14.7.0-ban
linktitle: Aspose.Slides for .NET 14.7.0
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
description: "Tekintse át a nyilvános API frissítéseket és a törőspontokat az Aspose.Slides for .NET-ben, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="primary" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) vagy [eltávolított](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) osztályt, metódust, tulajdonságot és így tovább, valamint a Aspose.Slides for .NET 14.7.0 API-val bevezetett egyéb változásokat.

{{% /alert %}} 
## **Nyilvános API változások**
### **Eltávolított konstruktorok és elemek**
#### **Eltávolított néhány TransitionValueBase alosztály konstruktor és a TransitionValueFactory**
A néhány TransitionValueBase alosztály (konkrétan CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) konstruktorai haszontalanná váltak a nyilvános API-ban, ezért eltávolításra kerültek. 

A kapcsolódó TransitionValueFactory osztály és az ITransitionValueFactory interfész szintén ugyanazon okból eltávolításra került.
#### **Eltávolították a SoundAction elemet az Aspose.Slides.SlideShow.TransitionType enumerációból**
A SoundAction elem hibás volt és nem lett használva. A hangbeállításokat a SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName tulajdonságok határozzák meg.
### **Hozzáadott osztályok és interfészek**
#### **Hozzáadott FlyThroughTransition osztály és IFlyThroughTransition interfész**
Az Aspose.Slides.SlideShow.FlyThroughTransition osztály (és az Aspose.Slides.SlideShow.IFlyThroughTransition interfész) a kiadástól támogatott Flythrough áttűnés típusra vonatkozik.
#### **Hozzáadott GlitterTransition osztály, IGlitterTransition interfész és TransitionPattern enumeráció**
Az Aspose.Slides.SlideShow.GlitterTransition osztály (és az Aspose.Slides.SlideShow.IGlitterTransition interfész) a kiadástól támogatott Glitter áttűnés típusra vonatkozik.

Az Aspose.Slides.SlideShow.TransitionPattern enumeráció ebben az osztályban használatos, és egy geometriai mintát határoz meg, amely egymásra helyezve nagyobb területet tölti ki.
#### **Hozzáadott LeftRightDirectionTransition osztály, ILeftRightDirectionTransition interfész és TransitionLeftRightDirectionType enumeráció**
Az Aspose.Slides.SlideShow.LeftRightDirectionTransition osztály (és az Aspose.Slides.SlideShow.ILeftRightDirectionTransition interfész) a Conveyor, Ferris, Flip, Gallery és Switch áttűnés típusokra vonatkozik. Mindegyik támogatott a kiadástól.

Az Aspose.Slides.SlideShow.TransitionLeftRightDirectionType enumeráció ebben az osztályban használatos, és egy irányt határoz meg, amely csak a bal és jobb értékeket vehet fel.
#### **Új elemeket adtak hozzá az Aspose.Slides.SlideShow.TransitionType enumerációhoz**
Az Aspose.Slides.SlideShow.TransitionType enumerációt új elemekkel bővítették.

- A PowerPoint 2010 áttűnésekhez kapcsolódó új elemek: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- Az új PowerPoint 2013 áttűnésekhez kapcsolódó új elemek: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **Hozzáadott RevealTransition osztály és IRevealTransition interfész**
Az Aspose.Slides.SlideShow.RevealTransition osztály (és az Aspose.Slides.SlideShow.IRevealTransition interfész) a kiadástól támogatott Reveal áttűnés típusra vonatkozik.
#### **Hozzáadott RippleTransition osztály, IRippleTransition interfész és TransitionCornerAndCenterDirectionType enumeráció**
Az Aspose.Slides.SlideShow.RippleTransition osztály (és az Aspose.Slides.SlideShow.IRippleTransition interfész) a kiadástól támogatott Ripple áttűnés típusra vonatkozik.

Az Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType enumeráció ebben az osztályban használatos, és egy irányt határoz meg, amely csak a sarkokra és a középre korlátozódik.