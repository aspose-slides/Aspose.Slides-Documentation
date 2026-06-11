---
title: Publiczne API i zmiany niekompatybilne wstecz w Aspose.Slides dla Java 14.7.0
linktitle: Aspose.Slides dla Java 14.7.0
type: docs
weight: 60
url: /pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- migracja
- kod starszy
- nowoczesny kod
- podejście starsze
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Przejrzyj aktualizacje publicznego API oraz zmiany łamiące kompatybilność w Aspose.Slides for Java, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="primary" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) klasy, metody, właściwości i tak dalej, wszelkie nowe ograniczenia oraz inne zmiany wprowadzone w API Aspose.Slides for Java 14.7.0.

{{% /alert %}} 
## **Zmiany w publicznym API**
### **Konstruktory niektórych podtypów TransitionValueBase zostały usunięte, a TransitionValueFactory został usunięty**
Konstruktory niektórych podtypów TransitionValueBase (a konkretnie CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) są bezużyteczne w publicznym API i dlatego zostały usunięte. Powiązana klasa TransitionValueFactory i jej interfejs ITransitionValueFactory zostały usunięte z tego samego powodu.
### **Element SoundAction został usunięty z wyliczenia com.aspose.slides.TransitionType**
Element SoundAction był nieprawidłowy i nie był używany. Ustawienia dźwięku są definiowane przez właściwości SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Dodano klasę FlyThroughTransition i interfejs IFlyThroughTransition**
Klasa com.aspose.slides.FlyThroughTransition (oraz jej interfejs com.aspose.slides.IFlyThroughTransition) odnosi się do typu przejścia Flythrough, który jest obsługiwany w tej wersji.
### **Dodano klasę GlitterTransition, interfejs IGlitterTransition oraz wyliczenie TransitionPattern**
Klasa com.aspose.slides.GlitterTransition (oraz jej interfejs com.aspose.slides.IGlitterTransition) odnosi się do typu przejścia Glitter, który jest obsługiwany w tej wersji. Wyliczenie com.aspose.slides.TransitionPattern jest używane w tej klasie i określa geometryczny wzór, który układa się w mozaikę, aby wypełnić większy obszar.
### **Dodano klasę LeftRightDirectionTransition, interfejs ILeftRightDirectionTransition oraz wyliczenie TransitionLeftRightDirectionType**
Klasa com.aspose.slides.LeftRightDirectionTransition (oraz jej interfejs com.aspose.slides.ILeftRightDirectionTransition) odnosi się do typów przejść Switch, Flip, Ferris, Gallery, Conveyor, które są obsługiwane w tej wersji. Wyliczenie com.aspose.slides.TransitionLeftRightDirectionType jest używane w tej klasie i określa kierunek ograniczony do wartości left i right.
### **Dodano nowe elementy do wyliczenia com.aspose.slides.TransitionType**
Wyliczenie com.aspose.slides.TransitionType zostało rozszerzone o nowe elementy. Nowe elementy związane z przejściami PowerPoint 2010: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse. Nowe elementy związane z przejściami PowerPoint 2013: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **Dodano klasę RevealTransition i interfejs IRevealTransition**
Klasa com.aspose.slides.RevealTransition (oraz jej interfejs com.aspose.slides.IRevealTransition) odnosi się do typu przejścia Reveal, który jest obsługiwany w tej wersji.
Dodano klasę RippleTransition, interfejs IRippleTransition oraz wyliczenie TransitionCornerAndCenterDirectionType
Klasa com.aspose.slides.RippleTransition (oraz jej interfejs com.aspose.slides.IRippleTransition) odnosi się do typu przejścia Ripple, który jest obsługiwany w tej wersji. Wyliczenie com.aspose.slides.TransitionCornerAndCenterDirectionType jest używane w tej klasie i określa kierunek ograniczony do rogów i środka.
### **Dodano klasę ShredTransition, interfejs IShredTransition oraz wyliczenie TransitionShredPattern**
Klasa com.aspose.slides.ShredTransition (oraz jej interfejs com.aspose.slides.IShredTransition) odnosi się do typu przejścia Shred, który jest obsługiwany w tej wersji. Wyliczenie com.aspose.slides.TransitionShredPattern jest używane w tej klasie i określa geometryczny kształt, który układa się w mozaikę, aby wypełnić większy obszar.