---
title: Public API i zmiany niekompatybilne wstecz w Aspose.Slides for Java 14.7.0
linktitle: Aspose.Slides for Java 14.7.0
type: docs
weight: 60
url: /pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- migracja
- kod legacy
- nowoczesny kod
- podejście legacy
- podejście nowoczesne
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Przegląd aktualizacji publicznego API oraz zmian łamiących w Aspose.Slides for Java, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="info" %}} 
Ta strona wymienia wszystkie [dodane](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) klasy, metody, właściwości i tak dalej, wszelkie nowe ograniczenia oraz inne zmiany wprowadzone w API Aspose.Slides for Java 14.7.0.
{{% /alert %}} 
## **Zmiany publicznego API**
### **Konstruktory niektórych podtypów TransitionValueBase zostały usunięte, a TransitionValueFactory również został usunięty**
Konstruktory niektórych podtypów TransitionValueBase (w szczególności CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) są nieużyteczne w publicznym API i zostały usunięte. Powiązana klasa TransitionValueFactory oraz jej interfejs ITransitionValueFactory zostały usunięte z tego samego powodu.
### **Element SoundAction został usunięty z wyliczenia com.aspose.slides.TransitionType**
Element SoundAction był nieprawidłowy i nie był używany. Ustawienia dźwięku są definiowane przez własności SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Klasa FlyThroughTransition oraz interfejs IFlyThroughTransition zostały dodane**
Klasa com.aspose.slides.FlyThroughTransition (oraz jej interfejs com.aspose.slides.IFlyThroughTransition) odnosi się do typu przejścia Flythrough, który jest obsługiwany w tej wersji.
### **Klasa GlitterTransition, interfejs IGlitterTransition oraz wyliczenie TransitionPattern zostały dodane**
Klasa com.aspose.slides.GlitterTransition (oraz jej interfejs com.aspose.slides.IGlitterTransition) odnosi się do typu przejścia Glitter, który jest obsługiwany w tej wersji. Wyliczenie com.aspose.slides.TransitionPattern jest używane w tej klasie i określa geometryczny wzór, który układa się w większy obszar.
### **Klasa LeftRightDirectionTransition, interfejs ILeftRightDirectionTransition oraz wyliczenie TransitionLeftRightDirectionType zostały dodane**
Klasa com.aspose.slides.LeftRightDirectionTransition (oraz jej interfejs com.aspose.slides.ILeftRightDirectionTransition) odnosi się do typów przejść Switch, Flip, Ferris, Gallery, Conveyor, które są obsługiwane w tej wersji. Wyliczenie com.aspose.slides.TransitionLeftRightDirectionType jest używane w tej klasie i określa kierunek ograniczony do wartości left i right.
### **Do wyliczenia com.aspose.slides.TransitionType zostały dodane nowe elementy**
Wyliczenie com.aspose.slides.TransitionType zostało rozszerzone o nowe elementy. Nowe elementy związane z przejściami PowerPoint 2010: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse. Nowe elementy związane z przejściami PowerPoint 2013: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **Klasa RevealTransition oraz interfejs IRevealTransition zostały dodane**
Klasa com.aspose.slides.RevealTransition (oraz jej interfejs com.aspose.slides.IRevealTransition) odnosi się do typu przejścia Reveal, który jest obsługiwany w tej wersji.  
Klasa RippleTransition, interfejs IRippleTransition oraz wyliczenie TransitionCornerAndCenterDirectionType zostały dodane.  
Klasa com.aspose.slides.RippleTransition (oraz jej interfejs com.aspose.slides.IRippleTransition) odnosi się do typu przejścia Ripple, który jest obsługiwany w tej wersji.  
Wyliczenie com.aspose.slides.TransitionCornerAndCenterDirectionType jest używane w tej klasie i określa kierunek ograniczony do rogów i środka.
### **Klasa ShredTransition, interfejs IShredTransition oraz wyliczenie TransitionShredPattern zostały dodane**
Klasa com.aspose.slides.ShredTransition (oraz jej interfejs com.aspose.slides.IShredTransition) odnosi się do typu przejścia Shred, który jest obsługiwany w tej wersji. Wyliczenie com.aspose.slides.TransitionShredPattern jest używane w tej klasie i określa geometryczny kształt, który układa się w większy obszar.