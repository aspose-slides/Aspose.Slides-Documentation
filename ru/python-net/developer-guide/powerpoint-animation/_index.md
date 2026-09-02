---
title: Улучшение презентаций PowerPoint анимациями в Python
linktitle: Анимация PowerPoint
type: docs
weight: 150
url: /ru/python-net/powerpoint-animation/
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
- анимированный OLE-объект
- анимированное изображение
- анимированная таблица
- презентация PowerPoint
- Python
- Aspose.Slides
description: "Изучите возможности Aspose.Slides for Python via .NET по работе с анимациями PowerPoint. Этот общий обзор подчеркивает ключевые функции и предлагает идеи для улучшения ваших презентаций."
---
## **Введение**

Презентации предназначены для передачи информации, поэтому их визуальный вид и интерактивное поведение являются ключевыми аспектами при создании.

**PowerPoint animation** играет важную роль в том, чтобы презентация привлекала внимание и удерживала интерес зрителей. Aspose.Slides for Python via .NET предоставляет широкий набор возможностей для добавления анимации в презентацию PowerPoint. Вы можете:

- Применять различные анимационные эффекты к фигурам, диаграммам, таблицам, OLE‑объектам и другим элементам.
- Использовать несколько анимационных эффектов на одной фигуре.
- Управлять эффектами через временную шкалу анимации.
- Создавать пользовательские анимации.

В Aspose.Slides for Python via .NET анимационные эффекты могут быть применены к фигурам. Поскольку каждый элемент на слайде — включая текст, изображения, OLE‑объекты и таблицы — рассматривается как фигура, вы можете применить анимационный эффект к любому элементу на слайде.

Пространство имён [aspose.slides.animation](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/) предоставляет классы для работы с анимациями PowerPoint.

## **Установка**

```bash
pip install aspose.slides
```

## **Добавление анимационного эффекта к фигуре в Python**

Анимационные эффекты находятся в главной последовательности слайда. Добавьте фигуру, затем вызовите `add_effect` у
`slide.timeline.main_sequence`, передав тип эффекта, его подтип и триггер, который его запускает.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 100)
    shape.text_frame.text = "Animated shape"

    sequence = slide.timeline.main_sequence
    effect = sequence.add_effect(
        shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.LEFT,
        slides.animation.EffectTriggerType.ON_CLICK,
    )
    effect.timing.duration = 2.0

    presentation.save("animated.pptx", slides.export.SaveFormat.PPTX)
```

Сохранённый файл содержит один эффект на первом слайде: прямоугольник появляется слева за две
секунды при щелчке презентера. При повторном открытии и чтении `slide.timeline.main_sequence` возвращается
этот эффект, поэтому анимация сохраняется после round‑trip, а не существует только в памяти.

## **Анимационные эффекты**

Aspose.Slides поддерживает **более 150 анимационных эффектов**, включая базовые эффекты, такие как Bounce, PathFootball и Zoom, а также специализированные эффекты, такие как OLEObjectShow и OLEObjectOpen. Полный список можно найти в перечислении [EffectType](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/effecttype/).

Кроме того, эти анимационные эффекты можно комбинировать со следующими эффектами:

- [ColorEffect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/seteffect/)

## **Пользовательская анимация**

Вы можете создавать собственные **пользовательские анимации** в Aspose.Slides, комбинируя несколько поведений в один эффект.

[Behavior](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/behavior/) — базовый строительный блок любого анимационного эффекта PowerPoint. Каждый анимационный эффект по сути представляет собой набор поведений, упорядоченных в одну стратегию или временную шкалу. Вы можете собрать поведения в пользовательскую анимацию один раз и переиспользовать её в других презентациях. Если вы добавляете новое поведение к стандартному анимационному эффекту PowerPoint, оно становится пользовательской анимацией — например, добавление поведения повторения, чтобы анимация воспроизводилась несколько раз.

[Animation Point](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/point/) обозначает момент или позицию, в которой применяется поведение (ключевой кадр).

## **Временная шкала анимации**

[Sequence](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/sequence/) — набор анимационных эффектов, примененных к конкретной фигуре.

[Timeline](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/animationtimeline/) — набор последовательностей, используемых на конкретном слайде. Он был введён в PowerPoint 2002. В более ранних версиях PowerPoint добавление анимационных эффектов было сложным и часто требовало обходных решений. Timeline заменил старый класс `AnimationSettings` и предоставляет более понятную объектную модель для анимации PowerPoint. Каждый слайд может иметь только одну временную шкалу анимации.

## **Интерактивная анимация**

[Trigger](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/effecttriggertype/) позволяет определить действия пользователя (например, щелчок кнопки), которые запускают конкретную анимацию. Триггеры были добавлены только в последних версиях PowerPoint.

## **Анимация фигур**

Aspose.Slides позволяет применять анимацию к фигурам — таким как текст, прямоугольники, линии, рамки, OLE‑объекты и прочее.

{{% alert color="primary" %}}

Читать далее [**О анимации фигур**](/slides/ru/python-net/shape-animation/).

{{% /alert %}}

## **Анимированные диаграммы**

Чтобы создавать анимированные диаграммы, используйте те же классы, что и для фигур. Однако анимацию PowerPoint можно применять только к категориям диаграммы или к сериям диаграммы. Вы также можете применить анимационный эффект к отдельному элементу категории или к элементу серии.

{{% alert color="primary" %}}

Читать далее [**О анимированных диаграммах**](/slides/ru/python-net/animated-charts/).

{{% /alert %}}

## **Анимированный текст**

Помимо анимации текста, вы можете применять анимацию к абзацу.

{{% alert color="primary" %}}

Читать далее [**О анимированном тексте**](/slides/ru/python-net/animated-text/).

{{% /alert %}}

## **FAQ**

### Сохранится ли анимация при экспорте в PDF?

Нет. PDF — статический формат, поэтому анимации и [переходы между слайдами](/slides/ru/python-net/slide-transition/) не воспроизводятся. Если вам требуется движение, экспортируйте в [HTML5](/slides/ru/python-net/export-to-html5/), [анимированный GIF](/slides/ru/python-net/convert-powerpoint-to-animated-gif/) или [видео](/slides/ru/python-net/convert-powerpoint-to-video/) вместо этого.

### Можно ли превратить анимированную презентацию в видео и управлять частотой кадров и размером кадра?

Да. Вы можете [рендерить презентацию в кадры](/slides/ru/python-net/convert-powerpoint-to-video/) и кодировать их в видеоролик (например, с помощью ffmpeg), выбирая FPS и разрешение. Анимации и переходы между слайдами воспроизводятся во время рендеринга.

### Сохранится ли анимация при работе с ODP (не только PPTX)?

PPT, PPTX и ODP поддерживаются для [чтения](/slides/ru/python-net/open-presentation/) и [записи](/slides/ru/python-net/save-presentation/), но различия форматов означают, что некоторые эффекты могут выглядеть или вести себя немного иначе. Проверьте критические случаи на реальных образцах.