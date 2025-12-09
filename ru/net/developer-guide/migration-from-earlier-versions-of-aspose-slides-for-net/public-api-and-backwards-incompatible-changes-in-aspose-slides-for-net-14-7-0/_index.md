---
title: Публичный API и обратные несовместимые изменения в Aspose.Slides для .NET 14.7.0
linktitle: Aspose.Slides для .NET 14.7.0
type: docs
weight: 90
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- миграция
- унаследованный код
- современный код
- унаследованный подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и разрушающих изменений в Aspose.Slides для .NET, позволяющих плавно мигрировать ваши решения для презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) или [удалённые](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) классы, методы, свойства и т.д., а также другие изменения, внесённые в API Aspose.Slides for .NET 14.7.0.

{{% /alert %}} 
## **Изменения публичного API**
### **Удалённые конструкторы и элементы**
#### **Удалены некоторые конструкторы подтипов TransitionValueBase и TransitionValueFactory**
Конструкторы некоторых подтипов TransitionValueBase (а именно CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) бесполезны в публичном API и поэтому были удалены.

Соответствующий класс TransitionValueFactory и его интерфейс ITransitionValueFactory были удалены по той же причине.
#### **Удалён элемент SoundAction из перечисления Aspose.Slides.SlideShow.TransitionType**
Элемент SoundAction был некорректен и не использовался. Настройки звука определяются свойствами SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Добавленные классы и интерфейсы**
#### **Добавлен класс FlyThroughTransition и интерфейс IFlyThroughTransition**
Класс Aspose.Slides.SlideShow.FlyThroughTransition (и его интерфейс Aspose.Slides.SlideShow.IFlyThroughTransition) относится к типу перехода Flythrough, поддерживаемому с данного релиза.
#### **Добавлен класс GlitterTransition, интерфейс IGlitterTransition и перечисление TransitionPattern**
Класс Aspose.Slides.SlideShow.GlitterTransition (и его интерфейс Aspose.Slides.SlideShow.IGlitterTransition) относится к типу перехода Glitter, поддерживаемому с данного релиза.

Перечисление Aspose.Slides.SlideShow.TransitionPattern используется в этом классе и задаёт геометрический узор, который соединяется в плитку, заполняя большую область.
#### **Добавлен класс LeftRightDirectionTransition, интерфейс ILeftRightDirectionTransition и перечисление TransitionLeftRightDirectionType**
Класс Aspose.Slides.SlideShow.LeftRightDirectionTransition (и его интерфейс Aspose.Slides.SlideShow.ILeftRightDirectionTransition) относится к типам переходов Conveyor, Ferris, Flip, Gallery и Switch. Все они поддерживаются с данного релиза.

Перечисление Aspose.Slides.SlideShow.TransitionLeftRightDirectionType используется в этом классе и задаёт направление, ограниченное значениями left и right.
#### **Добавлены новые элементы в перечисление Aspose.Slides.SlideShow.TransitionType**
Перечисление Aspose.Slides.SlideShow.TransitionType было расширено новыми элементами.

- Новые элементы, связанные с переходами PowerPoint 2010: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- Новые элементы, связанные с новыми переходами PowerPoint 2013: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **Added the RevealTransition Class and IRevealTransition Interface**
Класс Aspose.Slides.SlideShow.RevealTransition (и его интерфейс Aspose.Slides.SlideShow.IRevealTransition) относится к типу перехода Reveal, поддерживаемому с данного релиза.
#### **Added the RippleTransition class, IRippleTransition Interface and TransitionCornerAndCenterDirectionType Enumeration**
Класс Aspose.Slides.SlideShow.RippleTransition (и его интерфейс Aspose.Slides.SlideShow.IRippleTransition) относится к типу перехода Ripple, поддерживаемому с данного релиза.

Перечисление Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType используется в этом классе и задаёт направление, ограниченное углами и центром.