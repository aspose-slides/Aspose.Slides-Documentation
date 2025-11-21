---
title: Улучшение презентаций PowerPoint с помощью анимаций в .NET
linktitle: Анимация PowerPoint
type: docs
weight: 150
url: /ru/net/powerpoint-animation/
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
- презентация PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Изучите возможности Aspose.Slides для .NET при работе с анимациями PowerPoint. Этот общий обзор подчеркивает ключевые функции и предлагает идеи для улучшения ваших презентаций."
---

## **Обзор**

Поскольку презентации предназначены для представления информации, их визуальный вид и интерактивное поведение всегда учитываются при создании.

**PowerPoint animation** играет важную роль в том, чтобы презентация была привлекательно выглядящей и интересной для зрителей. Aspose.Slides for .NET предоставляет широкий набор вариантов добавления анимаций в презентации PowerPoint:

- Применять различные типы эффектов анимации PowerPoint к фигурам, диаграммам, таблицам, объектам OLE и другим элементам презентации.
- Использовать несколько эффектов анимации PowerPoint для одной фигуры.
- Использовать временную шкалу анимации для управления эффектами анимации.
- Создавать пользовательские анимации.

В Aspose.Slides for .NET различные эффекты анимации могут применяться к фигурам. Поскольку каждый элемент на слайде, включая текст, изображения, объекты OLE и таблицы, считается фигурой, эффекты анимации могут применяться к любому элементу на слайде.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/) namespace предоставляет классы для работы с анимациями PowerPoint.

## **Эффекты анимации**

Aspose.Slides поддерживает **150+ анимационных эффектов**, включая базовые эффекты, такие как Bounce, PathFootball и Zoom, а также специфические эффекты, такие как OLEObjectShow и OLEObjectOpen. Полный список эффектов анимации можно найти в перечислении [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype).

Кроме того, эти анимационные эффекты могут использоваться в комбинации со следующими:

- [ColorEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/seteffect)

## **Пользовательская анимация**

В Aspose.Slides можно создавать собственные **пользовательские анимации**. Это достигается комбинированием нескольких поведений в новую пользовательскую анимацию.

[Behaviour](https://reference.aspose.com/slides/net/aspose.slides.animation/behavior) является строительным блоком любого эффекта анимации PowerPoint. Все эффекты анимации по сути представляют собой набор поведений, объединённых в одну стратегию. Вы можете один раз объединить поведения в пользовательскую анимацию и затем повторно использовать её в других презентациях. Если добавить новое поведение к стандартному эффекту анимации PowerPoint, оно станет ещё одной пользовательской анимацией. Например, можно добавить поведение повторения к анимации, чтобы она повторялась несколько раз.

[Animation Point](https://reference.aspose.com/slides/net/aspose.slides.animation/point) — это точка, в которой должно применяться поведение.

## **Временная шкала анимации**

[Sequence](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) — это набор анимационных эффектов, применяемых к определённой фигуре.

[Timeline](https://reference.aspose.com/slides/net/aspose.slides.animation/animationtimeline) — это набор последовательностей, используемых на конкретном слайде. Это анимационный движок, внедрённый в PowerPoint 2002. В более ранних версиях PowerPoint добавление анимационных эффектов в презентации было сложным и возможно только с различными обходными решениями. Временная шкала заменяет старый класс AnimationSettings и предоставляет более понятную объектную модель анимаций PowerPoint. На слайде может быть только одна временная шкала анимации.

## **Интерактивная анимация**

[Trigger](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttriggertype) позволяет определять пользовательские действия (например, щелчок кнопки), которые инициируют определённую анимацию. Триггеры были введены в последней версии PowerPoint.

## **Анимация фигур**

Aspose.Slides позволяет применять анимацию к фигурам, которые могут включать текст, прямоугольники, линии, рамки, объекты OLE и многое другое.

{{% alert color="primary" %}} 
Подробнее [**Об анимации фигур**](/slides/ru/net/shape-animation/).
{{% /alert %}}

## **Анимированные диаграммы**

Для создания анимированных диаграмм следует использовать те же классы, что и для фигур. Однако анимацию PowerPoint можно применять только к категориям диаграммы или к сериям диаграммы. Также можно применять анимационные эффекты к элементу категории или к элементу серии.

{{% alert color="primary" %}} 
Подробнее [**Об анимированных диаграммах**](/slides/ru/net/animated-charts/).
{{% /alert %}}

## **Анимированный текст**

Помимо анимированного текста, также можно применить анимацию к абзацу.

{{% alert color="primary" %}} 
Подробнее [**Об анимированном тексте**](/slides/ru/net/animated-text/).
{{% /alert %}}

## **FAQ**

**Сохранились ли анимации при экспорте в PDF?**

Нет. PDF — статический формат, поэтому анимации и [slide transitions](/slides/ru/net/slide-transition/) не воспроизводятся. Если требуется движение, экспортируйте в [HTML5](/slides/ru/net/export-to-html5/), [animated GIF](/slides/ru/net/convert-powerpoint-to-animated-gif/) или [video](/slides/ru/net/convert-powerpoint-to-video/).

**Можно ли превратить анимированную презентацию в видео и контролировать частоту кадров и их размер?**

Да. Вы можете [рендеринг презентации в кадры](/slides/ru/net/convert-powerpoint-to-video/) и закодировать их в видео (например, с помощью ffmpeg), выбирая FPS и разрешение. Анимации и переходы слайдов воспроизводятся во время рендеринга.

**Сохранятся ли анимации при работе с ODP (не только PPTX)?**

PPT, PPTX и ODP поддерживаются для [чтения](/slides/ru/net/open-presentation/) и [записи](/slides/ru/net/save-presentation/), но различия форматов означают, что некоторые эффекты могут выглядеть или вести себя немного по‑другому. Проверьте критические случаи на реальных образцах.