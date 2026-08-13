---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro .NET 14.7.0
linktitle: Aspose.Slides pro .NET 14.7.0
type: docs
weight: 90
url: /cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- migrace
- starý kód
- moderní kód
- starý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prozkoumejte aktualizace veřejného API a rozbití změny v Aspose.Slides pro .NET, abyste hladce migrovali své řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="info" %}} 
Tato stránka uvádí všechny [přidány](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) nebo [odstraněny](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) třídy, metody, vlastnosti a podobně a další změny zavedené v API Aspose.Slides pro .NET 14.7.0.
{{% /alert %}} 
## **Změny veřejného API**
### **Odebrané konstruktory a prvky**
#### **Odebrány některé konstruktory podtypů TransitionValueBase a třída TransitionValueFactory**
Konstruktory některých podtypů TransitionValueBase (konkrétně CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) jsou v veřejném API zbytečné a byly odstraněny.

Související třída TransitionValueFactory a její rozhraní ITransitionValueFactory byly odstraněny ze stejného důvodu.
#### **Odebrán prvek SoundAction z výčtu Aspose.Slides.SlideShow.TransitionType**
Prvek SoundAction byl nesprávný a nepoužívaný. Nastavení zvuku jsou definována pomocí vlastností SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Přidány třídy a rozhraní**
#### **Přidána třída FlyThroughTransition a rozhraní IFlyThroughTransition**
Třída Aspose.Slides.SlideShow.FlyThroughTransition (a její rozhraní Aspose.Slides.SlideShow.IFlyThroughTransition) se vztahuje k typu přechodu Flythrough, který je podporován od tohoto vydání.
#### **Přidána třída GlitterTransition, rozhraní IGlitterTransition a výčet TransitionPattern**
Třída Aspose.Slides.SlideShow.GlitterTransition (a její rozhraní Aspose.Slides.SlideShow.IGlitterTransition) se vztahuje k typu přechodu Glitter, který je podporován od tohoto vydání.

Výčet Aspose.Slides.SlideShow.TransitionPattern je v této třídě používán a určuje geometrický vzor, který se skládá dohromady a vyplní větší oblast.
#### **Přidána třída LeftRightDirectionTransition, rozhraní ILeftRightDirectionTransition a výčet TransitionLeftRightDirectionType**
Třída Aspose.Slides.SlideShow.LeftRightDirectionTransition (a její rozhraní Aspose.Slides.SlideShow.ILeftRightDirectionTransition) se vztahuje k typům přechodů Conveyor, Ferris, Flip, Gallery a Switch. Všechny jsou podporovány od tohoto vydání.

Výčet Aspose.Slides.SlideShow.TransitionLeftRightDirectionType je v této třídě používán a určuje směr, omezený na hodnoty left a right.
#### **Přidány nové prvky do výčtu Aspose.Slides.SlideShow.TransitionType**
Výčet Aspose.Slides.SlideShow.TransitionType byl rozšířen o nové prvky.

- Nové prvky související s přechody PowerPoint 2010: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- Nové prvky související s novými přechody PowerPoint 2013: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **Přidána třída RevealTransition a rozhraní IRevealTransition**
Třída Aspose.Slides.SlideShow.RevealTransition (a její rozhraní Aspose.Slides.SlideShow.IRevealTransition) se vztahuje k typu přechodu Reveal, který je podporován od tohoto vydání.
#### **Přidána třída RippleTransition, rozhraní IRippleTransition a výčet TransitionCornerAndCenterDirectionType**
Třída Aspose.Slides.SlideShow.RippleTransition (a její rozhraní Aspose.Slides.SlideShow.IRippleTransition) se vztahuje k typu přechodu Ripple, který je podporován od tohoto vydání.

Výčet Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType je v této třídě používán a určuje směr, omezený na rohy a střed.