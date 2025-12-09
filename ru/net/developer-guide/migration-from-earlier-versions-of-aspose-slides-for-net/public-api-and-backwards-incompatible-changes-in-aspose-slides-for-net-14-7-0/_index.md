---
title: Обобщённый API и несовместимые изменения в Aspose.Slides для .NET 14.7.0
linktitle: Aspose.Slides для .NET 14.7.0
type: docs
weight: 90
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- миграция
- устаревший код
- современный код
- устаревший подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и разрывных изменений в Aspose.Slides для .NET, позволяющий плавно мигрировать ваши решения для презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [added](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) или [removed](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) классы, методы, свойства и т.д., а также другие изменения, введённые в API Aspose.Slides for .NET 14.7.0.

{{% /alert %}} 
## **Public API Changes**
### **Removed Constructors and Elements**
#### **Removed Some TransitionValueBase Subtype Constructors and TransitionValueFactory**
Конструкторы некоторых подклассов TransitionValueBase (а именно CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) бесполезны в публичном API и поэтому удалены. 

Связанный класс TransitionValueFactory и его интерфейс ITransitionValueFactory также удалены по той же причине.
#### **Removed the SoundAction Element from the Aspose.Slides.SlideShow.TransitionType Enumeration**
Элемент SoundAction был некорректен и не использовался. Настройки звука задаются свойствами SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Added Classes and Interfaces**
#### **Added the FlyThroughTransition Class and IFlyThroughTransition Interface**
Класс Aspose.Slides.SlideShow.FlyThroughTransition (и его интерфейс Aspose.Slides.SlideShow.IFlyThroughTransition) относится к типу перехода Flythrough, поддерживаемому начиная с этой версии.
#### **Added the GlitterTransition Class, IGlitterTransition Interface and TransitionPattern Enumeration**
Класс Aspose.Slides.SlideShow.GlitterTransition (и его интерфейс Aspose.Slides.SlideShow.IGlitterTransition) относится к типу перехода Glitter, поддерживаемому начиная с этой версии.

Перечисление Aspose.Slides.SlideShow.TransitionPattern используется в этом классе и задаёт геометрический узор, который повторяется для заполнения более большой области.
#### **Added the LeftRightDirectionTransition Class, ILeftRightDirectionTransition Interface and TransitionLeftRightDirectionType Enumeration**
Класс Aspose.Slides.SlideShow.LeftRightDirectionTransition (и его интерфейс Aspose.Slides.SlideShow.ILeftRightDirectionTransition) относится к типам переходов Conveyor, Ferris, Flip, Gallery и Switch. Все они поддерживаются начиная с этой версии.

Перечисление Aspose.Slides.SlideShow.TransitionLeftRightDirectionType используется в этом классе и задаёт направление, ограниченное значениями left и right.
#### **Added New Elements to the Aspose.Slides.SlideShow.TransitionType Enumeration**
Перечисление Aspose.Slides.SlideShow.TransitionType расширено новыми элементами.

- Новые элементы, связанные с переходами PowerPoint 2010: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- Новые элементы, связанные с переходами PowerPoint 2013: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **Added the RevealTransition Class and IRevealTransition Interface**
Класс Aspose.Slides.SlideShow.RevealTransition (и его интерфейс Aspose.Slides.SlideShow.IRevealTransition) относится к типу перехода Reveal, поддерживаемому начиная с этой версии.
#### **Added the RippleTransition class, IRippleTransition Interface and TransitionCornerAndCenterDirectionType Enumeration**
Класс Aspose.Slides.SlideShow.RippleTransition (и его интерфейс Aspose.Slides.SlideShow.IRippleTransition) относится к типу перехода Ripple, поддерживаемому начиная с этой версии.

Перечисление Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType используется в этом классе и задаёт направление, ограниченное углами и центром.