---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro Java 14.7.0
linktitle: Aspose.Slides pro Java 14.7.0
type: docs
weight: 60
url: /cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- migrace
- starý kód
- moderní kód
- starý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Prohlédněte si aktualizace veřejného API a kritické změny v Aspose.Slides pro Java, abyste hladce migrovali svá řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="info" %}} 
Tato stránka uvádí všechny [přidané](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) třídy, metody, vlastnosti a podobně, všechna nová omezení a další změny zavedené v API Aspose.Slides pro Java 14.7.0.
{{% /alert %}} 
## **Změny veřejného API**
### **Konstruktory některých podtypů TransitionValueBase byly odstraněny a TransitionValueFactory byl odstraněn**
Konstruktory některých podtypů TransitionValueBase (konkrétně CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) jsou v veřejném API zbytečné, a proto byly odstraněny. Související třída TransitionValueFactory a její rozhraní ITransitionValueFactory byly z toho samého důvodu odstraněny.
### **Prvek SoundAction byl odstraněn z výčtu com.aspose.slides.TransitionType**
Prvek SoundAction byl nesprávný a nebyl používán. Nastavení zvuku jsou definována vlastnostmi SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Byly přidány třída FlyThroughTransition a rozhraní IFlyThroughTransition**
Třída com.aspose.slides.FlyThroughTransition (a její rozhraní com.aspose.slides.IFlyThroughTransition) se vztahuje k typu přechodu Flythrough, který je v tomto vydání podporován.
### **Byly přidány třída GlitterTransition, rozhraní IGlitterTransition a výčet TransitionPattern**
Třída com.aspose.slides.GlitterTransition (a její rozhraní com.aspose.slides.IGlitterTransition) se vztahuje k typu přechodu Glitter, který je v tomto vydání podporován. Výčet com.aspose.slides.TransitionPattern se v této třídě používá a určuje geometrický vzor, který se opakuje, aby vyplnil větší oblast.
### **Byly přidány třída LeftRightDirectionTransition, rozhraní ILeftRightDirectionTransition a výčet TransitionLeftRightDirectionType**
Třída com.aspose.slides.LeftRightDirectionTransition (a její rozhraní com.aspose.slides.ILeftRightDirectionTransition) se vztahuje k typům přechodů Switch, Flip, Ferris, Gallery, Conveyor, které jsou v tomto vydání podporovány. Výčet com.aspose.slides.TransitionLeftRightDirectionType se v této třídě používá a určuje směr omezený na hodnoty left a right.
### **Do výčtu com.aspose.slides.TransitionType byly přidány nové položky**
Výčet com.aspose.slides.TransitionType byl rozšířen o nové položky.
Nové položky související s novými přechody PowerPoint 2010: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse.
Nové položky související s novými přechody PowerPoint 2013: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **Byly přidány třída RevealTransition a rozhraní IRevealTransition**
Třída com.aspose.slides.RevealTransition (a její rozhraní com.aspose.slides.IRevealTransition) se vztahuje k typu přechodu Reveal, který je v tomto vydání podporován.
Byly přidány třída RippleTransition, rozhraní IRippleTransition a výčet TransitionCornerAndCenterDirectionType.
Třída com.aspose.slides.RippleTransition (a její rozhraní com.aspose.slides.IRippleTransition) se vztahuje k typu přechodu Ripple, který je v tomto vydání podporován. Výčet com.aspose.slides.TransitionCornerAndCenterDirectionType se v této třídě používá a určuje směr omezený na rohy a střed.
### **Byly přidány třída ShredTransition, rozhraní IShredTransition a výčet TransitionShredPattern**
Třída com.aspose.slides.ShredTransition (a její rozhraní com.aspose.slides.IShredTransition) se vztahuje k typu přechodu Shred, který je v tomto vydání podporován. Výčet com.aspose.slides.TransitionShredPattern se v této třídě používá a určuje geometrický tvar, který se opakuje, aby vyplnil větší oblast.