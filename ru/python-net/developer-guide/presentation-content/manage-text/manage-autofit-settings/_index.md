---
title: Улучшите свои презентации с помощью AutoFit в Python
linktitle: Настройки Autofit
type: docs
weight: 30
url: /ru/python-net/manage-autofit-settings/
keywords:
- текстовое поле
- автоподгонка
- не автоподгонка
- подгонка текста
- сжатие текста
- перенос текста
- изменение размера фигуры
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как управлять настройками AutoFit в Aspose.Slides for Python via .NET для оптимизации отображения текста в ваших презентациях PowerPoint и OpenDocument и повышения читаемости содержимого."
---

По умолчанию, когда вы добавляете текстовое поле, Microsoft PowerPoint использует настройку **Resize shape to fix text** для этого поля — он автоматически изменяет размер текстового поля, чтобы текст всегда помещался в нём. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Когда текст в текстовом поле становится длиннее или крупнее, PowerPoint автоматически увеличивает размер поля — увеличивает его высоту — чтобы разместить больше текста. 
* Когда текст в текстовом поле становится короче или меньше, PowerPoint автоматически уменьшает поле — уменьшает его высоту — освобождая лишнее пространство. 

В PowerPoint это 4 важных параметра или опции, которые контролируют поведение автоподгонки для текстового поля: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via .NET предоставляет аналогичные параметры — некоторые свойства класса [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) — которые позволяют управлять поведением автоподгонки для текстовых полей в презентациях. 

## **Resize Shapes to Fit Text**

Если вы хотите, чтобы текст в коробке всегда помещался в неё после изменения текста, необходимо использовать параметр **Resize shape to fix text**. Чтобы задать эту настройку, установите свойство [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) класса [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) в значение `SHAPE`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Этот фрагмент Python показывает, как задать, чтобы текст всегда помещался в свою коробку в презентации PowerPoint:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


Если текст станет длиннее или крупнее, текстовое поле будет автоматически изменено (увеличена высота), чтобы весь текст поместился. Если текст станет короче, произойдёт обратное. 

## **Do Not Autofit**

Если вы хотите, чтобы текстовое поле или форма сохраняли свои размеры независимо от изменений текста, необходимо использовать параметр **Do not Autofit**. Чтобы задать эту настройку, установите свойство [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) класса [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) в значение `NONE`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Этот фрагмент Python показывает, как задать, чтобы текстовое поле всегда сохраняло свои размеры в презентации PowerPoint:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


Когда текст становится слишком длинным для своей коробки, он выходит за её пределы. 

## **Shrink Text on Overflow**

Если текст становится слишком длинным для своей коробки, с помощью параметра **Shrink text on overflow** вы можете указать, что размер текста и его межбуквенный интервал должны уменьшаться, чтобы он уместился. Чтобы задать эту настройку, установите свойство [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) класса [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) в значение `NORMAL`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Этот фрагмент Python показывает, как задать, чтобы текст сжимался при переполнении в презентации PowerPoint:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NORMAL

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="Info" color="info" %}}
При использовании опции **Shrink text on overflow** настройка применяется только тогда, когда текст становится слишком длинным для своей коробки. 
{{% /alert %}}

## **Wrap Text**

Если вы хотите, чтобы текст в форме переносился внутри этой формы, когда он выходит за её границы по ширине, используйте параметр **Wrap text in shape**. Чтобы задать эту настройку, установите свойство [wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) класса [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) в значение `NullableBool.TRUE`. 

Этот фрагмент Python показывает, как использовать параметр Wrap Text в презентации PowerPoint:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame_format.wrap_text = slides.NullableBool.TRUE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="Note" color="warning" %}} 
Если установить свойство `wrap_text` в `NullableBool.FALSE` для формы, когда текст внутри формы станет длиннее её ширины, текст будет продолжаться за границы формы в одну строку. 
{{% /alert %}}

## **FAQ**

**Влияют ли внутренние отступы текстового кадра на AutoFit?**

Да. Отступы (внутренние поля) уменьшают доступную площадь для текста, поэтому AutoFit срабатывает раньше — шрифт сокращается или форма меняет размер быстрее. Проверьте и скорректируйте отступы перед настройкой AutoFit.

**Как AutoFit взаимодействует с ручными и мягкими разрывами строк?**

Принудительные разрывы сохраняются, а AutoFit подбирает размер шрифта и межстрочный интервал вокруг них. Удаление лишних разрывов часто уменьшает агрессивность сжатия текста AutoFit.

**Влияет ли изменение шрифта темы или подстановка шрифта на результаты AutoFit?**

Да. Подмена шрифта с другими метриками глифов меняет ширину/высоту текста, что может изменить конечный размер шрифта и перенос строк. После любой смены или подстановки шрифта повторно проверьте слайды.