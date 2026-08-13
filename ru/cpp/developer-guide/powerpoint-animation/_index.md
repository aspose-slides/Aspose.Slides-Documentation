---
title: Улучшение презентаций PowerPoint с помощью анимации в C++
linktitle: Анимация PowerPoint
type: docs
weight: 150
url: /ru/cpp/powerpoint-animation/
keywords:
- добавить анимацию
- обновить анимацию
- изменить анимацию
- удалить анимацию
- управлять анимацией
- контролировать анимацию
- эффект анимации
- анимация PowerPoint
- временная шкала анимации
- интерактивная анимация
- пользовательская анимация
- анимация фигур
- анимированная диаграмма
- анимированный текст
- анимированная фигура
- анимированный объект OLE
- анимированное изображение
- анимированная таблица
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как добавлять и управлять продвинутыми анимационными эффектами в Aspose.Slides для C++, чтобы создавать динамические презентации PowerPoint и OpenDocument."
---
## **Введение**

Поскольку презентации созданы для демонстрации чего‑либо, их визуальный вид и интерактивное поведение всегда учитываются при их создании.

**PowerPoint animation** играет важную роль, позволяя сделать презентацию привлекательной и интересной для зрителей. Aspose.Slides for C++ предлагает широкий набор возможностей для добавления анимации в презентацию PowerPoint:

- применять различные типы эффектов анимации PowerPoint к фигурам, диаграммам, таблицам, объектам OLE и другим элементам презентации.
- использовать несколько эффектов анимации PowerPoint для одной фигуры.
- использовать временную шкалу анимации для управления эффектами анимации.
- создавать пользовательскую анимацию.

В Aspose.Slides for C++ различные анимационные эффекты могут быть применены к фигурам. Поскольку каждый элемент на слайде, включая текст, изображения, объект OLE, таблицу и т.д., рассматривается как фигура, это означает, что мы можем применять анимационный эффект к каждому элементу слайда.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/ru/cpp/namespace/aspose.slides.animation) **namespace** предоставляет классы для работы с анимациями PowerPoint.
## **Эффекты анимации**
Aspose.Slides поддерживает **150+ анимационных эффектов**, включая базовые эффекты такие как Bounce, PathFootball, Zoom и специфические эффекты как OLEObjectShow, OLEObjectOpen. Полный список анимационных эффектов можно найти в перечислении [**EffectType**](https://reference.aspose.com/slides/ru/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31).

Кроме того, эти анимационные эффекты могут использоваться в комбинации с ними:

- [ColorEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.animation.set_effect)

## **Пользовательская анимация**
В Aspose.Slides можно создавать собственные **пользовательские анимации**. Это достигается, если объединить несколько поведений в новую пользовательскую анимацию.

[**Behavior**](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.animation.behavior) — строительный блок любого эффекта анимации PowerPoint. Все анимационные эффекты фактически представляют собой набор поведений, объединённых в одну стратегию. Вы можете объединять поведения в пользовательскую анимацию один раз и повторно использовать её в других презентациях. Если добавить новое поведение в стандартный эффект анимации PowerPoint, будет получена другая пользовательская анимация. Например, можно добавить повторяющееся поведение к анимации, чтобы она повторялась несколько раз.

[**Animation Point**](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.animation.point) — точка, в которой должно быть применено поведение.

## **Временная шкала анимации**
[**Sequence**](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.animation.sequence) — коллекция анимационных эффектов, применяемая к конкретной фигуре.

[**AnimationTimeLine**](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.animation.animation_time_line) — набор последовательностей, используемых в конкретном слайде. Это анимационный движок, представленный начиная с PowerPoint 2002. В предыдущих версиях PowerPoint добавление анимационных эффектов в презентацию было сложным и возможно только с помощью различных обходных методов. Временная шкала заменяет старый класс AnimationSettings и предоставляет более ясную объектную модель для анимации PowerPoint. Один слайд может содержать только одну временную шкалу анимации.

## **Интерактивная анимация**
[**EffectTriggerType**](https://reference.aspose.com/slides/ru/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) позволяет определить действия пользователя (например, щелчок кнопки), которые запустят определённую анимацию. Триггеры были добавлены только в последних версиях PowerPoint.

## **Анимация фигур**
Aspose.Slides позволяет применять анимацию к фигурам, которые могут быть текстом, прямоугольником, линией, рамкой, объектом OLE и т.д.

{{% alert color="info" %}} 
Читать подробнее [**О анимации фигур**](/slides/ru/cpp/shape-animation/).
{{% /alert %}}

## **Анимированные диаграммы**
Чтобы создать анимированные диаграммы, необходимо использовать те же классы, что и для фигур. Однако анимацию PowerPoint можно применять только к категориям диаграммы или к сериям диаграммы. Также можно применить анимационный эффект к элементу категории или к элементу серии.

{{% alert color="info" %}} 
Читать подробнее [**О анимированных диаграммах**](/slides/ru/cpp/animated-charts/).
{{% /alert %}}

## **Анимированный текст**
Помимо анимированного текста, также возможно применять анимацию к абзацу.

{{% alert color="info" %}} 
Читать подробнее [**О анимированном тексте**](/slides/ru/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

### Будут ли анимации сохранены при экспорте в PDF?

Нет. PDF — статический формат, поэтому анимации и [переходы слайдов](/slides/ru/cpp/slide-transition/) не воспроизводятся. Если нужен эффект движения, экспортируйте в [HTML5](/slides/ru/cpp/export-to-html5/), [анимированный GIF](/slides/ru/cpp/convert-powerpoint-to-animated-gif/) или [видео](/slides/ru/cpp/convert-powerpoint-to-video/).

### Можно ли превратить анимированную презентацию в видео и задать частоту кадров и размер кадра?

Да. Вы можете [рендерить презентацию как кадры](/slides/ru/cpp/convert-powerpoint-to-video/) и кодировать их в видео (например, с помощью ffmpeg), выбирая FPS и разрешение. Анимации и переходы слайдов воспроизводятся во время рендеринга.

### Сохранятся ли анимации при работе с ODP (не только PPTX)?

PPT, PPTX и ODP поддерживаются для [чтения](/slides/ru/cpp/open-presentation/) и [записи](/slides/ru/cpp/save-presentation/), но различия форматов могут привести к небольшим отличиям внешнего вида или поведения некоторых эффектов. Проверяйте критически важные случаи на реальных образцах.