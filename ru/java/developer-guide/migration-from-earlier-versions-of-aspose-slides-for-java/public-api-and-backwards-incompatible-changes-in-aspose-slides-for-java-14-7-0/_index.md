---
title: Публичный API и изменения, несовместимые с предыдущими версиями, в Aspose.Slides для Java 14.7.0
type: docs
weight: 60
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
---

{{% alert color="primary" %}} 

Эта страница содержит список всех [добавленных](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) классов, методов, свойств и так далее, а также новых ограничений и других изменений, внедренных в API Aspose.Slides для Java 14.7.0.

{{% /alert %}} 
## **Изменения в публичном API**
### **Конструкторы некоторых подтипов TransitionValueBase были удалены, а TransitionValueFactory был удален**
Конструкторы некоторых подтипов TransitionValueBase (в частности, CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) не нужны в публичном API и были удалены. Связанный класс TransitionValueFactory и его интерфейс ITransitionValueFactory были удалены по той же причине.
### **Элемент SoundAction был удален из перечисления com.aspose.slides.TransitionType**
Элемента SoundAction был неверным и не использовался. Звуковые настройки определяются свойствами SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Класс FlyThroughTransition и интерфейс IFlyThroughTransition были добавлены**
Класс com.aspose.slides.FlyThroughTransition (и его интерфейс com.aspose.slides.IFlyThroughTransition) относится к типу перехода Flythrough, который поддерживается в этом релизе.
### **Класс GlitterTransition, интерфейс IGlitterTransition и перечисление TransitionPattern были добавлены**
Класс com.aspose.slides.GlitterTransition (и его интерфейс com.aspose.slides.IGlitterTransition) относится к типу перехода Glitter, который поддерживается в этом релизе. Перечисление com.aspose.slides.TransitionPattern используется в этом классе и определяет геометрический шаблон, который заполняет собой большую площадь.
### **Класс LeftRightDirectionTransition, интерфейс ILeftRightDirectionTransition и перечисление TransitionLeftRightDirectionType были добавлены**
Класс com.aspose.slides.LeftRightDirectionTransition (и его интерфейс com.aspose.slides.ILeftRightDirectionTransition) относится к типам переходов Switch, Flip, Ferris, Gallery, Conveyor, которые были поддержаны в этом релизе. Перечисление com.aspose.slides.TransitionLeftRightDirectionType используется в этом классе и определяет направление, ограниченное значениями "лево" и "право".
### **В перечисление com.aspose.slides.TransitionType были добавлены новые элементы**
Перечисление com.aspose.slides.TransitionType было расширено новыми элементами. Новые элементы относятся к новым переходам PowerPoint 2010: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse. Новые элементы, относящиеся к новым переходам PowerPoint 2013: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **Класс RevealTransition и интерфейс IRevealTransition были добавлены**
Класс com.aspose.slides.RevealTransition (и его интерфейс com.aspose.slides.IRevealTransition) относится к типу перехода Reveal, который поддерживается в этом релизе. Класс RippleTransition, интерфейс IRippleTransition и перечисление TransitionCornerAndCenterDirectionType были добавлены. Класс com.aspose.slides.RippleTransition (и его интерфейс com.aspose.slides.IRippleTransition) относится к типу перехода Ripple, который поддерживается в этом релизе. Перечисление com.aspose.slides.TransitionCornerAndCenterDirectionType используется в этом классе и определяет направление, ограниченное углами и центром.
### **Класс ShredTransition, интерфейс IShredTransition и перечисление TransitionShredPattern были добавлены**
Класс com.aspose.slides.ShredTransition (и его интерфейс com.aspose.slides.IShredTransition) относится к типу перехода Shred, который поддерживается в этом релизе. Перечисление com.aspose.slides.TransitionShredPattern используется в этом классе и определяет геометрическую форму, которая заполняет собой большую площадь.