---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 14.7.0
type: docs
weight: 90
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
---

{{% alert color="primary" %}} 

Эта страница содержит список всех [добавленных](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) или [удаленных](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) классов, методов, свойств и так далее, а также других изменений, введенных с API Aspose.Slides для .NET 14.7.0.

{{% /alert %}} 
## **Изменения публичного API**
### **Удаленные конструкторы и элементы**
#### **Удалены некоторые конструкторы подтипов TransitionValueBase и TransitionValueFactory**
Конструкторы некоторых подтипов TransitionValueBase (в частности CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) бесполезны в публичном API и поэтому были удалены.

Связанный класс TransitionValueFactory и его интерфейс ITransitionValueFactory также были удалены по той же причине.
#### **Удален элемент SoundAction из перечисления Aspose.Slides.SlideShow.TransitionType**
Элемент SoundAction был некорректным и не использовался. Звуковые настройки определяются свойствами SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Добавленные классы и интерфейсы**
#### **Добавлен класс FlyThroughTransition и интерфейс IFlyThroughTransition**
Класс Aspose.Slides.SlideShow.FlyThroughTransition (и его интерфейс Aspose.Slides.SlideShow.IFlyThroughTransition) относится к типу перехода Flythrough, поддерживаемому с этого релиза.
#### **Добавлен класс GlitterTransition, интерфейс IGlitterTransition и перечисление TransitionPattern**
Класс Aspose.Slides.SlideShow.GlitterTransition (и его интерфейс Aspose.Slides.SlideShow.IGlitterTransition) относится к типу перехода Glitter, поддерживаемому с этого релиза.

Перечисление Aspose.Slides.SlideShow.TransitionPattern используется в этом классе и специфицирует геометрический узор, который заполняет более крупную область.
#### **Добавлен класс LeftRightDirectionTransition, интерфейс ILeftRightDirectionTransition и перечисление TransitionLeftRightDirectionType**
Класс Aspose.Slides.SlideShow.LeftRightDirectionTransition (и его интерфейс Aspose.Slides.SlideShow.ILeftRightDirectionTransition) относится к типам переходов Conveyor, Ferris, Flip, Gallery и Switch. Все они поддерживаются с этого релиза.

Перечисление Aspose.Slides.SlideShow.TransitionLeftRightDirectionType используется в этом классе и специфицирует направление, ограниченное значениями левое и правое.
#### **Добавлены новые элементы в перечисление Aspose.Slides.SlideShow.TransitionType**
Перечисление Aspose.Slides.SlideShow.TransitionType было расширено новыми элементами.

- Новые элементы, связанные с переходами PowerPoint 2010: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- Новые элементы, связанные с новыми переходами PowerPoint 2013: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **Добавлен класс RevealTransition и интерфейс IRevealTransition**
Класс Aspose.Slides.SlideShow.RevealTransition (и его интерфейс Aspose.Slides.SlideShow.IRevealTransition) относится к типу перехода Reveal, поддерживаемому с этого релиза.
#### **Добавлен класс RippleTransition, интерфейс IRippleTransition и перечисление TransitionCornerAndCenterDirectionType**
Класс Aspose.Slides.SlideShow.RippleTransition (и его интерфейс Aspose.Slides.SlideShow.IRippleTransition) относится к типу перехода Ripple, поддерживаемому с этого релиза.

Перечисление Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType используется в этом классе и специфицирует направление, ограниченное углами и центром.