---
title: Улучшите презентации PowerPoint с помощью анимаций в Python
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
- анимированный объект OLE
- анимированное изображение
- анимированная таблица
- презентация PowerPoint
- Python
- Aspose.Slides
description: "Изучите возможности Aspose.Slides for Python via .NET по работе с анимациями PowerPoint. Этот общий обзор выделяет ключевые функции и предлагает идеи для улучшения ваших презентаций."
---
## **Введение**

Презентации созданы для передачи информации, поэтому их визуальный вид и интерактивное поведение являются ключевыми аспектами при создании.

**PowerPoint animation** играет важную роль в том, чтобы презентация была привлекательной и захватывающей для зрителей. Aspose.Slides for Python via .NET предоставляет широкий набор возможностей для добавления анимации в презентацию PowerPoint. Вы можете:

- Применять различные анимационные эффекты к фигурам, диаграммам, таблицам, объектам OLE и другим элементам.
- Использовать несколько анимационных эффектов на одной фигуре.
- Управлять эффектами через временную шкалу анимации.
- Создавать пользовательские анимации.

В Aspose.Slides for Python via .NET анимационные эффекты могут применяться к фигурам. Поскольку каждый элемент на слайде — включая текст, изображения, объекты OLE и таблицы — рассматривается как фигура, вы можете применять анимационные эффекты к любому элементу на слайде.

Пространство имён [aspose.slides.animation](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/) предоставляет классы для работы с анимациями PowerPoint.

## **Установка**

```bash
pip install aspose.slides
```

## **Добавление анимационного эффекта к фигуре в Python**

Анимационные эффекты находятся в основной последовательности слайда. Добавьте фигуру, затем вызовите `add_effect` у
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

Сохранённый файл содержит один эффект на первом слайде: прямоугольник появляется слева за две секунды при щелчке докладчика. При повторном открытии и чтении `slide.timeline.main_sequence` этот эффект возвращается, поэтому анимация сохраняется после сохранения, а не существует только в памяти.

## **Анимационные эффекты**

Aspose.Slides поддерживает **более 150 анимационных эффектов**, включая базовые эффекты, такие как Bounce, PathFootball и Zoom, а также специализированные эффекты, такие как OLEObjectShow и OLEObjectOpen. Полный список доступен в перечислении [EffectType](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/effecttype/).

Кроме того, эти анимационные эффекты могут комбинироваться со следующими эффектами:

- [ColorEffect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/seteffect/)

## **Пользовательская анимация**

Полные примеры на Python, демонстрирующие создание, инспектирование и изменение поведений и редактируемых траекторий движения, см. в разделе [Custom Animation](/slides/ru/python-net/custom-animation/).

Вы можете создавать свои **пользовательские анимации** в Aspose.Slides, комбинируя несколько поведений в один эффект.

[Behavior](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/behavior/) — строительный блок анимационного эффекта PowerPoint. Комбинируйте поведения, чтобы настроить эффект, или добавляйте поведение, чтобы расширить предопределённый эффект. Повторяемость настраивается через параметры тайминга, а не отдельным поведением повторения.

[Animation Point](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/point/) обозначает момент или позицию, в которой применяется поведение (ключевой кадр).

## **Временная шкала анимации**

[Sequence](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/sequence/) — набор анимационных эффектов, который может быть привязан к разным фигурам.

[Timeline](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/animationtimeline/) — набор последовательностей, используемых на конкретном слайде. Он был введён в PowerPoint 2002. В более ранних версиях PowerPoint добавление анимационных эффектов было сложным и требовало обходных решений. Timeline заменил старый класс `AnimationSettings` и предоставляет более понятную объектную модель для анимации PowerPoint. Каждый слайд может иметь только одну временную шкалу анимации.

## **Интерактивная анимация**

[Trigger](https://reference.aspose.com/slides/ru/python-net/aspose.slides.animation/effecttriggertype/) позволяет определить действия пользователя (например, щелчок кнопки), которые запускают конкретную анимацию. Триггеры появились только в последних версиях PowerPoint.

## **Анимация фигур**

Aspose.Slides позволяет применять анимацию к фигурам — таким как текст, прямоугольники, линии, рамки, объекты OLE и другие.

{{% alert color="info" title="Note" %}}
Подробнее [**Об анимации фигур**](/slides/ru/python-net/shape-animation/).
{{% /alert %}}

## **Анимированные диаграммы**

Для создания анимированных диаграмм используйте те же классы, что и для фигур. Однако анимацию PowerPoint можно применять только к категориям диаграммы или её сериям. Вы также можете применить анимационный эффект к отдельному элементу категории или серии.

{{% alert color="info" title="Note" %}}
Подробнее [**Об анимированных диаграммах**](/slides/ru/python-net/animated-charts/).
{{% /alert %}}

## **Анимированный текст**

Помимо анимации текста, вы можете применять анимацию к абзацу.

{{% alert color="info" title="Note" %}}
Подробнее [**Об анимированном тексте**](/slides/ru/python-net/animated-text/).
{{% /alert %}}

## **Часто задаваемые вопросы**

**Сохранятся ли анимации при экспорте в PDF?**

Нет. PDF — статичный формат, поэтому анимации и [переходы между слайдами](/slides/ru/python-net/slide-transition/) не воспроизводятся. Если вам требуется движение, экспортируйте в [HTML5](/slides/ru/python-net/export-to-html5/), [анимированное GIF](/slides/ru/python-net/convert-powerpoint-to-animated-gif/) или [видео](/slides/ru/python-net/convert-powerpoint-to-video/).

**Можно ли превратить анимированную презентацию в видео и управлять частотой кадров и размером кадра?**

Да. Вы можете [рендерировать презентацию кадром за кадром](/slides/ru/python-net/convert-powerpoint-to-video/) и кодировать его в видео (например, с помощью ffmpeg), выбирая FPS и разрешение. Анимации и переходы между слайдами воспроизводятся во время рендеринга.

**Сохраняются ли анимации при работе с ODP (не только PPTX)?**

PPT, PPTX и ODP поддерживаются для [чтения](/slides/ru/python-net/open-presentation/) и [записи](/slides/ru/python-net/save-presentation/), однако это не гарантирует сохранение анимаций. При конвертации в ODP пользовательские анимационные данные могут быть утеряны. См. раздел [Custom Animation](/slides/ru/python-net/custom-animation/) для примеров и рекомендаций по проверке совместимости форматов.