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
- zděděný přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prohlédněte si aktualizace veřejného API a nekompatibilní změny v Aspose.Slides pro .NET, abyste hladce migrovali svá řešení pro prezentace PowerPoint PPT, PPTX a ODP."
---
{{% alert color="primary" %}} 

Tato stránka uvádí všechny [přidané](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) nebo [odstraněné](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) třídy, metody, vlastnosti a podobně a další změny zavedené v API Aspose.Slides pro .NET 14.7.0.

{{% /alert %}} 
## **Změny veřejného API**
### **Odebrané konstruktory a prvky**
#### **Odebráno některé konstruktorové podtypy TransitionValueBase a TransitionValueFactory**
Konstruktory některých podtypů TransitionValueBase (konkrétně CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) jsou v veřejném API zbytečné a byly odebrány. 

Související třída TransitionValueFactory a její rozhraní ITransitionValueFactory byly z téhož důvodu odebrány.
#### **Odebrán prvek SoundAction z výčtu Aspose.Slides.SlideShow.TransitionType**
Prvek SoundAction byl nesprávný a nepoužívaný. Nastavení zvuku jsou definována vlastnostmi SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Přidané třídy a rozhraní**
#### **Přidána třída FlyThroughTransition a rozhraní IFlyThroughTransition**
Třída Aspose.Slides.SlideShow.FlyThroughTransition (a její rozhraní Aspose.Slides.SlideShow.IFlyThroughTransition) souvisí s typem přechodu Flythrough, který je od tohoto vydání podporován.
#### **Přidána třída GlitterTransition, rozhraní IGlitterTransition a výčet TransitionPattern**
Třída Aspose.Slides.SlideShow.GlitterTransition (a její rozhraní Aspose.Slides.SlideShow.IGlitterTransition) souvisí s typem přechodu Glitter, který je od tohoto vydání podporován.

Výčet Aspose.Slides.SlideShow.TransitionPattern se v této třídě používá a určuje geometrický vzor, který se opakuje a vyplní větší plochu.
#### **Přidána třída LeftRightDirectionTransition, rozhraní ILeftRightDirectionTransition a výčet TransitionLeftRightDirectionType**
Třída Aspose.Slides.SlideShow.LeftRightDirectionTransition (a její rozhraní Aspose.Slides.SlideShow.ILeftRightDirectionTransition) souvisí s typy přechodů Conveyor, Ferris, Flip, Gallery a Switch. Všechny jsou od tohoto vydání podporovány.

Výčet Aspose.Slides.SlideShow.TransitionLeftRightDirectionType se v této třídě používá a určuje směr, omezený na hodnoty left a right.
#### **Přidány nové prvky do výčtu Aspose.Slides.SlideShow.TransitionType**
Výčet Aspose.Slides.SlideShow.TransitionType byl rozšířen o nové prvky.

- Nové prvky související s přechody PowerPoint 2010: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- Nové prvky související s novými přechody PowerPoint 2013: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **Přidána třída RevealTransition a rozhraní IRevealTransition**
Třída Aspose.Slides.SlideShow.RevealTransition (a její rozhraní Aspose.Slides.SlideShow.IRevealTransition) souvisí s typem přechodu Reveal, který je od tohoto vydání podporován.
#### **Přidána třída RippleTransition, rozhraní IRippleTransition a výčet TransitionCornerAndCenterDirectionType**
Třída Aspose.Slides.SlideShow.RippleTransition (a její rozhraní Aspose.Slides.SlideShow.IRippleTransition) souvisí s typem přechodu Ripple, který je od tohoto vydání podporován.

Výčet Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType se v této třídě používá a určuje směr, omezený na rohy a střed.