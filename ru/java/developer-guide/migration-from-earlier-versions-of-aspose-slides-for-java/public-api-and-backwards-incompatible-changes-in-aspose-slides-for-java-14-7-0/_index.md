---
title: Публичный API и несовместимые изменения в Aspose.Slides for Java 14.7.0
linktitle: Aspose.Slides for Java 14.7.0
type: docs
weight: 60
url: /ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- миграция
- устаревший код
- современный код
- устаревший подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Обзор обновлений публичного API и разрушающих изменений в Aspose.Slides for Java для плавной миграции ваших решений по работе с презентациями PowerPoint PPT, PPTX и ODP."
---
{{% alert color="info" %}}
Эта страница перечисляет все [added](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) классы, методы, свойства и т.д., любые новые ограничения и другие изменения, введённые в API Aspose.Slides for Java 14.7.0.
{{% /alert %}} 

## **Изменения публичного API**
### **Конструкторы некоторых подтипов TransitionValueBase удалены, а TransitionValueFactory также удалён**
Конструкторы некоторых подтипов TransitionValueBase (а именно CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) бесполезны в публичном API и поэтому были удалены. Связанный класс TransitionValueFactory и его интерфейс ITransitionValueFactory были удалены по той же причине.

### **Элемент SoundAction удалён из перечисления com.aspose.slides.TransitionType**
Элемент SoundAction был некорректен и не использовался. Настройки звука задаются свойствами SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.

### **Класс FlyThroughTransition и интерфейс IFlyThroughTransition добавлены**
Класс com.aspose.slides.FlyThroughTransition (и его интерфейс com.aspose.slides.IFlyThroughTransition) относится к типу перехода Flythrough, который поддерживается в этом релизе.

### **Класс GlitterTransition, интерфейс IGlitterTransition и перечисление TransitionPattern добавлены**
Класс com.aspose.slides.GlitterTransition (и его интерфейс com.aspose.slides.IGlitterTransition) относится к типу перехода Glitter, который поддерживается в этом выпуске. Перечисление com.aspose.slides.TransitionPattern используется в этом классе и задаёт геометрический узор, который складывается в более большую область.

### **Класс LeftRightDirectionTransition, интерфейс ILeftRightDirectionTransition и перечисление TransitionLeftRightDirectionType добавлены**
Класс com.aspose.slides.LeftRightDirectionTransition (и его интерфейс com.aspose.slides.ILeftRightDirectionTransition) относится к типам переходов Switch, Flip, Ferris, Gallery, Conveyor, которые поддерживаются в этом выпуске. Перечисление com.aspose.slides.TransitionLeftRightDirectionType используется в этом классе и задаёт направление, ограниченное значениями left и right.

### **В перечисление com.aspose.slides.TransitionType добавлены новые элементы**
Перечисление com.aspose.slides.TransitionType было расширено новыми элементами. Новые элементы, связанные с переходами PowerPoint 2010: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse. Новые элементы, связанные с переходами PowerPoint 2013: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.

### **Класс RevealTransition и интерфейс IRevealTransition добавлены**
Класс com.aspose.slides.RevealTransition (и его интерфейс com.aspose.slides.IRevealTransition) относится к типу перехода Reveal, который поддерживается в этом выпуске.

Класс RippleTransition, интерфейс IRippleTransition и перечисление TransitionCornerAndCenterDirectionType добавлены
Класс com.aspose.slides.RippleTransition (и его интерфейс com.aspose.slides.IRippleTransition) относится к типу перехода Ripple, который поддерживается в этом выпуске. Перечисление com.aspose.slides.TransitionCornerAndCenterDirectionType используется в этом классе и задаёт направление, ограниченное углами и центром.

### **Класс ShredTransition, интерфейс IShredTransition и перечисление TransitionShredPattern добавлены**
Класс com.aspose.slides.ShredTransition (и его интерфейс com.aspose.slides.IShredTransition) относится к типу перехода Shred, который поддерживается в этом выпуске. Перечисление com.aspose.slides.TransitionShredPattern используется в этом классе и задаёт геометрическую форму, которая складывается в более большую область.