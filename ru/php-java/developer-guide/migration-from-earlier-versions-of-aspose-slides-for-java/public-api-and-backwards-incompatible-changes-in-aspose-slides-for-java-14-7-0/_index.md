---
title: Публичный API и изменения, несовместимые с предыдущими версиями в Aspose.Slides для PHP через Java 14.7.0
type: docs
weight: 60
url: /ru/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
---

{{% alert color="primary" %}} 

Эта страница содержит все [добавленные](/slides/ru/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) классы, методы, свойства и так далее, любые новые ограничения и другие изменения, введенные в API Aspose.Slides для PHP через Java 14.7.0.

{{% /alert %}} 
## **Изменения в публичном API**
### **Конструкторы некоторых подтипов TransitionValueBase были удалены, и TransitionValueFactory была удалена**
Конструкторы некоторых подтипов TransitionValueBase (в частности, CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) бесполезны в публичном API и были удалены. Связанный класс TransitionValueFactory и его интерфейс ITransitionValueFactory были удалены по той же причине.
### **Элемент SoundAction был удален из перечисления com.aspose.slides.TransitionType**
Элемент SoundAction был некорректным и не использовался. Звуковые настройки определяются свойствами SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Класс FlyThroughTransition и интерфейс IFlyThroughTransition были добавлены**
Класс com.aspose.slides.FlyThroughTransition (и его интерфейс com.aspose.slides.IFlyThroughTransition) относится к типу перехода Flythrough, который поддерживается в этом релизе.
### **Класс GlitterTransition, интерфейс IGlitterTransition и перечисление TransitionPattern были добавлены**
Класс com.aspose.slides.GlitterTransition (и его интерфейс com.aspose.slides.IGlitterTransition) относится к типу перехода Glitter, который поддерживается в этом релизе.
Перечисление com.aspose.slides.TransitionPattern используется в этом классе и определяет геометрический узор, который соединяется вместе, чтобы заполнить большую площадь.
### **Класс LeftRightDirectionTransition, интерфейс ILeftRightDirectionTransition и перечисление TransitionLeftRightDirectionType были добавлены**
Класс com.aspose.slides.LeftRightDirectionTransition (и его интерфейс com.aspose.slides.ILeftRightDirectionTransition) относится к типам переходов Switch, Flip, Ferris, Gallery, Conveyor, которые поддерживаются в этом релизе.
Перечисление com.aspose.slides.TransitionLeftRightDirectionType используется в этом классе и определяет направление, ограниченное значениями "left" и "right".
### **Новые элементы были добавлены в перечисление com.aspose.slides.TransitionType**
Перечисление com.aspose.slides.TransitionType было расширено новыми элементами.
Новые элементы связаны с новыми переходами PowerPoint 2010: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse.
Новые элементы связаны с новыми переходами PowerPoint 2013: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **Класс RevealTransition и интерфейс IRevealTransition были добавлены**
Класс com.aspose.slides.RevealTransition (и его интерфейс com.aspose.slides.IRevealTransition) относится к типу перехода Reveal, который поддерживается в этом релизе.
Класс RippleTransition, интерфейс IRippleTransition и перечисление TransitionCornerAndCenterDirectionType были добавлены
Класс com.aspose.slides.RippleTransition (и его интерфейс com.aspose.slides.IRippleTransition) относится к типу перехода Ripple, который поддерживается в этом релизе.
Перечисление com.aspose.slides.TransitionCornerAndCenterDirectionType используется в этом классе и определяет направление, ограниченное углами и центром.
### **Класс ShredTransition, интерфейс IShredTransition и перечисление TransitionShredPattern были добавлены**
Класс com.aspose.slides.ShredTransition (и его интерфейс com.aspose.slides.IShredTransition) относится к типу перехода Shred, который поддерживается в этом релизе.
Перечисление com.aspose.slides.TransitionShredPattern используется в этом классе и определяет геометрическую форму, которая соединяется вместе, чтобы заполнить большую площадь.