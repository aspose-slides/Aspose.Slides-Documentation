---
title: Увеличьте презентации PowerPoint с помощью анимаций в .NET
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
- анимированный OLE‑объект
- анимированное изображение
- анимированная таблица
- презентация PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Изучите возможности Aspose.Slides для .NET по работе с анимациями PowerPoint. Этот общий обзор выделяет основные функции и предлагает идеи для улучшения ваших презентаций."
---
## **Введение**

Поскольку презентации предназначены для демонстрации чего‑либо, их визуальный вид и интерактивное поведение всегда учитываются при создании.

**PowerPoint animation** играет важную роль в том, чтобы презентация привлекала внимание и удерживала интерес зрителей. Aspose.Slides for .NET предоставляет широкий набор возможностей для добавления анимаций в презентации PowerPoint:

- Применять различные типы эффектов анимации PowerPoint к фигурам, диаграммам, таблицам, OLE‑объектам и другим элементам презентации.
- Использовать несколько эффектов анимации PowerPoint на одной фигуре.
- Использовать временную шкалу анимации для управления эффектами анимации.
- Создавать пользовательские анимации.

В Aspose.Slides for .NET различные эффекты анимации можно применять к фигурам. Поскольку каждый элемент на слайде, включая текст, изображения, OLE‑объекты и таблицы, считается фигурой, эффекты анимации могут применяться к любому элементу на слайде.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/) namespace предоставляет классы для работы с анимациями PowerPoint.

## **Эффекты анимации**

Aspose.Slides поддерживает **150+ анимационных эффектов**, включая базовые эффекты, такие как Bounce, PathFootball и Zoom, а также специфические эффекты, такие как OLEObjectShow и OLEObjectOpen. Полный список анимационных эффектов можно найти в перечислении [EffectType](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/effecttype).

Кроме того, эти анимационные эффекты могут использоваться в сочетании со следующим:

- [ColorEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/seteffect)

## **Пользовательская анимация**

В Aspose.Slides можно создавать собственные **пользовательские анимации**. Это можно сделать, объединив несколько поведений в новую пользовательскую анимацию.

[Behaviour](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/behavior) является строительным блоком любого эффекта анимации PowerPoint. Все эффекты анимации по сути представляют собой набор поведений, собранных в одну стратегию. Вы можете один раз объединить поведения в пользовательскую анимацию и повторно использовать её в других презентациях. Если добавить новое поведение к стандартному эффекту анимации PowerPoint, оно станет другой пользовательской анимацией. Например, можно добавить повторяющееся поведение к анимации, чтобы она воспроизводилась несколько раз.

[Animation Point](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/point) — это точка, в которой должно применяться поведение.

## **Временная шкала анимации**

[Sequence](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/sequence) — это набор анимационных эффектов, примененных к определённой фигуре.

[Timeline](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/animationtimeline) — это набор последовательностей, используемых на конкретном слайде. Это анимационный механизм, введённый в PowerPoint 2002. В более ранних версиях PowerPoint добавление анимационных эффектов в презентации было сложной задачей и могло быть реализовано только с помощью различных обходных решений. Временная шкала заменяет старый класс AnimationSettings и предоставляет более понятную объектную модель для анимаций PowerPoint. На слайде может быть только одна временная шкала анимации.

## **Интерактивная анимация**

[Trigger](https://reference.aspose.com/slides/ru/net/aspose.slides.animation/effecttriggertype) позволяет определить действия пользователя (например, щелчок кнопки), которые запустят конкретную анимацию. Триггеры были введены в последней версии PowerPoint.

## **Анимация фигур**

Aspose.Slides позволяет применять анимацию к фигурам, которые могут включать текст, прямоугольники, линии, рамки, OLE‑объекты и многое другое.

{{% alert color="info" %}} 
Читать далее [**Об анимации фигур**](/slides/ru/net/shape-animation/).
{{% /alert %}}

## **Анимированные диаграммы**

Для создания анимированных диаграмм следует использовать те же классы, что и для фигур. Однако анимацию PowerPoint можно применять только к категориям диаграмм или к сериям диаграмм. Также можно применять эффекты анимации к элементу категории или элементу серии.

{{% alert color="info" %}} 
Читать далее [**Об анимированных диаграммах**](/slides/ru/net/animated-charts/).
{{% /alert %}}

## **Анимированный текст**

Помимо анимированного текста, также возможно применять анимацию к абзацу.

{{% alert color="info" %}} 
Читать далее [**Об анимированном тексте**](/slides/ru/net/animated-text/).
{{% /alert %}}

## **FAQ**

### Сохранятся ли анимации при экспорте в PDF?

Нет. PDF — статический формат, поэтому анимации и [slide transitions](/slides/ru/net/slide-transition/) не воспроизводятся. Если требуется движение, экспортируйте вместо этого в [HTML5](/slides/ru/net/export-to-html5/), [animated GIF](/slides/ru/net/convert-powerpoint-to-animated-gif/) или [video](/slides/ru/net/convert-powerpoint-to-video/).

### Могу ли я превратить анимированную презентацию в видео и контролировать частоту кадров и размер кадра?

Да. Вы можете [render the presentation as frames](/slides/ru/net/convert-powerpoint-to-video/) и закодировать их в видео (например, с помощью ffmpeg), выбирая FPS и разрешение. Анимации и переходы слайдов воспроизводятся во время рендеринга.

### Сохранятся ли анимации при работе с ODP (а не только PPTX)?

PPT, PPTX и ODP поддерживаются для [reading](/slides/ru/net/open-presentation/) и [writing](/slides/ru/net/save-presentation/), но различия форматов означают, что некоторые эффекты могут выглядеть или работать немного иначе. Проверяйте критические случаи на реальных примерах.