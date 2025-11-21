---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 14.7.0
linktitle: Aspose.Slides для .NET 14.7.0
type: docs
weight: 90
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- миграция
- наследуемый код
- современный код
- наследуемый подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и критических изменений в Aspose.Slides для .NET, позволяющих плавно мигрировать ваши решения для презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) или [удалённые](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) классы, методы, свойства и т. д., а также другие изменения, внесённые в Aspose.Slides for .NET 14.7.0 API.

{{% /alert %}} 
## **Изменения публичного API**
### **Удалённые конструкторы и элементы**
#### **Удалены некоторые конструкторы подтипов TransitionValueBase и TransitionValueFactory**
Конструкторы некоторых подтипов TransitionValueBase (а именно CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) бесполезны в публичном API и поэтому удалены. 

Связанное с ними класс TransitionValueFactory и его интерфейс ITransitionValueFactory также удалены по той же причине.
#### **Удалён элемент SoundAction из перечисления Aspose.Slides.SlideShow.TransitionType**
Элемент SoundAction был некорректен и не использовался. Настройки звука определяются свойствами SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Добавленные классы и интерфейсы**
#### **Добавлен класс FlyThroughTransition и интерфейс IFlyThroughTransition**
Класс Aspose.Slides.SlideShow.FlyThroughTransition (и его интерфейс Aspose.Slides.SlideShow.IFlyThroughTransition) относится к типу перехода Flythrough, поддерживаемому начиная с этого релиза.
#### **Добавлен класс GlitterTransition, интерфейс IGlitterTransition и перечисление TransitionPattern**
Класс Aspose.Slides.SlideShow.GlitterTransition (и его интерфейс Aspose.Slides.SlideShow.IGlitterTransition) относится к типу перехода Glitter, поддерживаемому начиная с этого релиза.

Перечисление Aspose.Slides.SlideShow.TransitionPattern используется в этом классе и задаёт геометрический шаблон, который мозаично заполняет большую область.
#### **Добавлен класс LeftRightDirectionTransition, интерфейс ILeftRightDirectionTransition и перечисление TransitionLeftRightDirectionType**
Класс Aspose.Slides.SlideShow.LeftRightDirectionTransition (и его интерфейс Aspose.Slides.SlideShow.ILeftRightDirectionTransition) относится к типам переходов Conveyor, Ferris, Flip, Gallery и Switch. Все они поддерживаются начиная с этого релиза.

Перечисление Aspose.Slides.SlideShow.TransitionLeftRightDirectionType используется в этом классе и задаёт направление, ограниченное значениями left и right.
#### **Добавлены новые элементы в перечисление Aspose.Slides.SlideShow.TransitionType**
Перечисление Aspose.Slides.SlideShow.TransitionType расширено новыми элементами.

- Новые элементы, связанные с переходами PowerPoint 2010: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- Новые элементы, связанные с переходами PowerPoint 2013: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **Добавлен класс RevealTransition и интерфейс IRevealTransition**
Класс Aspose.Slides.SlideShow.RevealTransition (и его интерфейс Aspose.Slides.SlideShow.IRevealTransition) относится к типу перехода Reveal, поддерживаемому начиная с этого релиза.
#### **Добавлен класс RippleTransition, интерфейс IRippleTransition и перечисление TransitionCornerAndCenterDirectionType**
Класс Aspose.Slides.SlideShow.RippleTransition (и его интерфейс Aspose.Slides.SlideShow.IRippleTransition) относится к типу перехода Ripple, поддерживаемому начиная с этого релиза.

Перечисление Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType используется в этом классе и задаёт направление, ограниченное углами и центром.