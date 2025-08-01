---
title: Улучшайте презентации с AutoFit в Python
linktitle: Настройки AutoFit
type: docs
weight: 30
url: /ru/python-net/manage-autofit-settings/
keywords:
- текстовое поле
- автоподгонка
- не применять автоподгонку
- подогнать текст
- сжать текст
- перенос текста
- изменить размер фигуры
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как управлять настройками AutoFit в Aspose.Slides for Python via .NET, чтобы оптимизировать отображение текста в презентациях PowerPoint и OpenDocument и повысить удобочитаемость контента."
---

По умолчанию, когда вы добавляете текстовое поле, Microsoft PowerPoint использует настройку **Изменить размер формы для соответствия тексту** для текстового поля — оно автоматически изменяет размеры текстового поля, чтобы текст всегда помещался в него.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Когда текст в текстовом поле становится длиннее или больше, PowerPoint автоматически увеличивает текстовое поле — увеличивает его высоту — чтобы оно вмещало больше текста.
* Когда текст в текстовом поле становится короче или меньше, PowerPoint автоматически уменьшает текстовое поле — уменьшает его высоту — чтобы избавиться от лишнего пространства.

В PowerPoint 4 основных параметра или опции управляют поведением автоподбора для текстового поля:

* **Не автоподбирай**
* **Уменьшить текст при переполнении**
* **Изменить размер формы для соответствия тексту**
* **Переносить текст в форме.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides для Python через .NET предоставляет аналогичные параметры — некоторые свойства класса [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) — которые позволяют контролировать поведение автоподбора для текстовых полей в презентациях.

## **Изменить размер формы для соответствия тексту**

Если вы хотите, чтобы текст в пределах текстового поля всегда помещался в него после внесения изменений в текст, вам необходимо использовать опцию **Изменить размер формы для соответствия тексту**. Чтобы установить эту настройку, установите свойство [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) (из класса [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)) на `SHAPE`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Этот код на Python показывает, как указать, что текст всегда должен помещаться в текстовое поле в презентации PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    autoShape.text_frame.paragraphs[0].portions.add(portion)

    textFrameFormat = autoShape.text_frame.text_frame_format
    textFrameFormat.autofit_type = slides.TextAutofitType.SHAPE

    pres.save("Output-presentation.pptx", slides.export.SaveFormat.PPTX)
```

Если текст станет длиннее или больше, текстовое поле будет автоматически изменено в размере (увеличение высоты), чтобы весь текст поместился в него. Если текст станет короче, произойдет обратное.

## **Не автоподбирай**

Если вы хотите, чтобы текстовое поле или форма сохраняли свои размеры, независимо от изменений, внесенных в текст, содержащийся в них, вам необходимо использовать опцию **Не автоподбирай**. Чтобы установить эту настройку, установите свойство [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) (из класса [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)) на `NONE`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Этот код на Python показывает, как указать, что текстовое поле должно всегда сохранять свои размеры в презентации PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    autoShape.text_frame.paragraphs[0].portions.add(portion)

    textFrameFormat = autoShape.text_frame.text_frame_format
    textFrameFormat.autofit_type = slides.TextAutofitType.NONE

    pres.save("Output-presentation.pptx", slides.export.SaveFormat.PPTX)
```

Когда текст становится слишком длинным для своего текстового поля, он вышибает из него.

## **Уменьшить текст при переполнении**

Если текст становится слишком длинным для своего текстового поля, с помощью опции **Уменьшить текст при переполнении** вы можете указать, что размер и интервалы текста должны быть уменьшены, чтобы он поместился в своем текстовом поле. Чтобы установить эту настройку, установите свойство [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) (из класса [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)) на `NORMAL`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Этот код на Python показывает, как указать, что текст должен уменьшаться при переполнении в презентации PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    autoShape.text_frame.paragraphs[0].portions.add(portion)

    textFrameFormat = autoShape.text_frame.text_frame_format
    textFrameFormat.autofit_type = slides.TextAutofitType.NORMAL

    pres.save("Output-presentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Информация" color="info" %}}

Когда используется опция **Уменьшить текст при переполнении**, настройка применяется только в том случае, если текст становится слишком длинным для своего текстового поля.

{{% /alert %}}

## **Переносить текст**

Если вы хотите, чтобы текст в форме переносился внутри этой формы, когда текст превышает границы формы (только по ширине), вам необходимо использовать параметр **Переносить текст в форме**. Чтобы установить эту настройку, вам необходимо установить свойство [wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) (из класса [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)) на `1`.

Этот код на Python показывает, как использовать настройку Переноса текста в презентации PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    autoShape.text_frame.paragraphs[0].portions.add(portion)

    textFrameFormat = autoShape.text_frame.text_frame_format
    textFrameFormat.autofit_type = slides.TextAutofitType.NONE
    textFrameFormat.wrap_text = 1

    pres.save("Output-presentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Замечание" color="warning" %}} 

Если вы установите свойство `wrap_text` в `0` для формы, когда текст внутри формы становится длиннее ширины формы, текст продолжает отображаться за пределами границ формы в одной строке.

{{% /alert %}}