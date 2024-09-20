---
title: Публичный API и изменения, несовместимые с предыдущими версиями в Aspose.Slides для Java 14.7.0
type: docs
weight: 60
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
---

{{% alert color="primary" %}} 

На этой странице перечислены все [добавленные](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) классы, методы, свойства и так далее, любые новые ограничения и другие изменения, введенные с API Aspose.Slides для Java 14.7.0.

{{% /alert %}} 
## **Изменения в публичном API**
### **Конструкторы некоторых подтипов TransitionValueBase удалены, и TransitionValueFactory удален**
Конструкторы некоторых подтипов TransitionValueBase (в частности, CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) не имеют полезности в публичном API и поэтому были удалены. Связанный класс TransitionValueFactory и его интерфейс ITransitionValueFactory также были удалены по этой же причине.
### **Элемент SoundAction удален из перечисления com.aspose.slides.TransitionType**
Элемент SoundAction был некорректным и не использовался. Звуковые настройки определяются свойствами SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName..
### **Класс FlyThroughTransition и интерфейс IFlyThroughTransition добавлены**
Класс com.aspose.slides.FlyThroughTransition (и его интерфейс com.aspose.slides.IFlyThroughTransition) относится к типу перехода Flythrough, который поддерживается в этом выпуске..
### **Класс GlitterTransition, интерфейс IGlitterTransition и перечисление TransitionPattern добавлены**
Класс com.aspose.slides.GlitterTransition (и его интерфейс com.aspose.slides.IGlitterTransition) относится к типу перехода Glitter, который поддерживается в этом выпуске.
Перечисление com.aspose.slides.TransitionPattern используется в этом классе и указывает геометрический рисунок, который заполняет большую площадь.
### **Класс LeftRightDirectionTransition, интерфейс ILeftRightDirectionTransition и перечисление TransitionLeftRightDirectionType добавлены**
Класс com.aspose.slides.LeftRightDirectionTransition (и его интерфейс com.aspose.slides.ILeftRightDirectionTransition) относится к типам переходов Switch, Flip, Ferris, Gallery, Conveyor, которые поддерживаются в этом выпуске.
Перечисление com.aspose.slides.TransitionLeftRightDirectionType используется в этом классе и указывает направление, ограниченное значениями "влево" и "вправо".
### **Новые элементы добавлены в перечисление com.aspose.slides.TransitionType**
Перечисление com.aspose.slides.TransitionType было расширено новыми элементами.
Новые элементы, относящиеся к новым переходам PowerPoint 2010: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse.
Новые элементы, относящиеся к новым переходам PowerPoint 2013: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **Класс RevealTransition и интерфейс IRevealTransition добавлены**
Класс com.aspose.slides.RevealTransition (и его интерфейс com.aspose.slides.IRevealTransition) относится к типу перехода Reveal, который поддерживается в этом выпуске.
Класс RippleTransition, интерфейс IRippleTransition и перечисление TransitionCornerAndCenterDirectionType добавлены
Класс com.aspose.slides.RippleTransition (и его интерфейс com.aspose.slides.IRippleTransition) относится к типу перехода Ripple, который поддерживается в этом выпуске.
Перечисление com.aspose.slides.TransitionCornerAndCenterDirectionType используется в этом классе и указывает направление, ограниченное углами и центром.
### **Класс ShredTransition, интерфейс IShredTransition и перечисление TransitionShredPattern добавлены**
Класс com.aspose.slides.ShredTransition (и его интерфейс com.aspose.slides.IShredTransition) относится к типу перехода Shred, который поддерживается в этом выпуске.
Перечисление com.aspose.slides.TransitionShredPattern используется в этом классе и указывает геометрическую форму, которая заполняет большую площадь.