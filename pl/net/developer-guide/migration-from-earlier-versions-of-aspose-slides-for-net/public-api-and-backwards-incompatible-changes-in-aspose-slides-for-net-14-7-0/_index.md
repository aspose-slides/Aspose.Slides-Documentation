---
title: Publiczne API i niekompatybilne zmiany wstecz w Aspose.Slides dla .NET 14.7.0
linktitle: Aspose.Slides dla .NET 14.7.0
type: docs
weight: 90
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- migracja
- stary kod
- nowoczesny kod
- stare podejście
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przejrzyj aktualizacje publicznego API i zmiany łamiące w Aspose.Slides dla .NET, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="primary" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) lub [usunięte](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) klasy, metody, właściwości i podobne elementy, a także inne zmiany wprowadzone w API Aspose.Slides for .NET 14.7.0.

{{% /alert %}} 
## **Zmiany w publicznym API**
### **Usunięte konstruktory i elementy**
#### **Usunięto niektóre konstruktory podtypów TransitionValueBase oraz TransitionValueFactory**
Konstruktory niektórych podtypów TransitionValueBase (konkretnie CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) są bezużyteczne w publicznym API i zostały usunięte. 

Powiązana klasa TransitionValueFactory oraz jej interfejs ITransitionValueFactory zostały usunięte z tego samego powodu.
#### **Usunięto element SoundAction z wyliczenia Aspose.Slides.SlideShow.TransitionType**
Element SoundAction był nieprawidłowy i nieużywany. Ustawienia dźwięku definiowane są właściwościami SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Dodane klasy i interfejsy**
#### **Dodano klasę FlyThroughTransition oraz interfejs IFlyThroughTransition**
Klasa Aspose.Slides.SlideShow.FlyThroughTransition (oraz jej interfejs Aspose.Slides.SlideShow.IFlyThroughTransition) odnosi się do typu przejścia Flythrough obsługiwanego od tej wersji.
#### **Dodano klasę GlitterTransition, interfejs IGlitterTransition oraz wyliczenie TransitionPattern**
Klasa Aspose.Slides.SlideShow.GlitterTransition (oraz jej interfejs Aspose.Slides.SlideShow.IGlitterTransition) odnosi się do typu przejścia Glitter obsługiwanego od tej wersji.

Wyliczenie Aspose.Slides.SlideShow.TransitionPattern jest używane w tej klasie i określa wzór geometryczny, który układa się w kafelki, aby wypełnić większy obszar.
#### **Dodano klasę LeftRightDirectionTransition, interfejs ILeftRightDirectionTransition oraz wyliczenie TransitionLeftRightDirectionType**
Klasa Aspose.Slides.SlideShow.LeftRightDirectionTransition (oraz jej interfejs Aspose.Slides.SlideShow.ILeftRightDirectionTransition) odnosi się do typów przejść Conveyor, Ferris, Flip, Gallery i Switch. Wszystkie są obsługiwane od tej wersji.

Wyliczenie Aspose.Slides.SlideShow.TransitionLeftRightDirectionType jest używane w tej klasie i określa kierunek, ograniczony do wartości left i right.
#### **Dodano nowe elementy do wyliczenia Aspose.Slides.SlideShow.TransitionType**
Wyliczenie Aspose.Slides.SlideShow.TransitionType zostało rozszerzone o nowe elementy.

- Nowe elementy związane z przejściami PowerPoint 2010: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- Nowe elementy związane z przejściami PowerPoint 2013: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **Dodano klasę RevealTransition oraz interfejs IRevealTransition**
Klasa Aspose.Slides.SlideShow.RevealTransition (oraz jej interfejs Aspose.Slides.SlideShow.IRevealTransition) odnosi się do typu przejścia Reveal obsługiwanego od tej wersji.
#### **Dodano klasę RippleTransition, interfejs IRippleTransition oraz wyliczenie TransitionCornerAndCenterDirectionType**
Klasa Aspose.Slides.SlideShow.RippleTransition (oraz jej interfejs Aspose.Slides.SlideShow.IRippleTransition) odnosi się do typu przejścia Ripple obsługiwanego od tej wersji.

Wyliczenie Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType jest używane w tej klasie i określa kierunek, ograniczony do narożników i środka.