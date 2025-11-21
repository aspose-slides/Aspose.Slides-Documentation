---
title: Улучшите свои презентации с помощью AutoFit в .NET
linktitle: Настройки автоподгонки
type: docs
weight: 30
url: /ru/net/manage-autofit-settings/
keywords:
- текстовое поле
- автоподгонка
- не автоподгонка
- подгонка текста
- уменьшить текст
- перенос текста
- изменить размер фигуры
- PowerPoint
- презентация
- C#
- .NET
- Aspose.Slides
description: "Узнайте, как управлять настройками AutoFit в Aspose.Slides для .NET, чтобы оптимизировать отображение текста в ваших презентациях PowerPoint и OpenDocument и повысить удобочитаемость контента."
---

## **Обзор**

По умолчанию, когда вы добавляете текстовое поле, Microsoft PowerPoint использует настройку **Resize shape to fit text** для текстового поля — он автоматически изменяет размер текстового поля, чтобы его текст всегда помещался в него.

![Текстовое поле в PowerPoint](textbox-in-powerpoint.png)

* Когда текст в текстовом поле становится длиннее или больше, PowerPoint автоматически увеличивает текстовое поле — повышая его высоту — чтобы разместить больше текста.
* Когда текст в текстовом поле становится короче или меньше, PowerPoint автоматически уменьшает текстовое поле — снижая его высоту — чтобы убрать лишнее пространство.

В PowerPoint это четыре важных параметра или опции, которые контролируют поведение автоподгонки для текстового поля:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape**

![Параметры автоподгонки в PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for .NET предоставляет аналогичные параметры — свойства класса [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) — которые позволяют контролировать поведение автоподгонки для текстовых полей в презентациях.

## **Resize Shape to Fit Text**

Если вы хотите, чтобы текст в рамке всегда помещался в неё после изменения текста, необходимо использовать опцию **Resize shape to fit text**. Чтобы задать эту настройку, установите свойство `AutofitType` класса [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) в значение `Shape`.

![Опция Resize shape to fit text](alwaysfit-setting-powerpoint.png)

Этот код C# демонстрирует, как указать, что текст всегда должен помещаться в свою рамку в презентации PowerPoint:
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```


Если текст становится длиннее или больше, текстовое поле будет автоматически изменено (увеличена высота), чтобы весь текст помещался в него. Если текст становится короче, произойдёт обратное.

## **Do Not Autofit**

Если вы хотите, чтобы текстовое поле или форма сохраняли свои размеры независимо от изменений текста, необходимо использовать опцию **Do not Autofit**. Чтобы задать эту настройку, установите свойство `AutofitType` класса [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) в значение `None`.

![Настройка "Do not Autofit" в PowerPoint](donotautofit-setting-powerpoint.png)

Этот код C# демонстрирует, как указать, что текстовое поле всегда должно сохранять свои размеры в презентации PowerPoint:
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.None;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```


Когда текст становится слишком длинным для рамки, он выходит за её пределы.

## **Shrink Text on Overflow**

Если текст становится слишком длинным для рамки, с помощью опции **Shrink text on overflow** можно указать, что размер и межбуквенный интервал текста должны уменьшаться, чтобы поместиться в рамку. Чтобы задать эту настройку, установите свойство `AutofitType` класса [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) в значение `Normal`.

![Настройка "Shrink text on overflow" в PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

Этот код C# демонстрирует, как указать, что текст должен уменьшаться при переполнении в презентации PowerPoint:
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Normal;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```


{{% alert title="Info" color="info" %}}
Когда используется опция **Shrink text on overflow**, настройка применяется только тогда, когда текст становится слишком длинным для рамки.
{{% /alert %}}

## **Wrap Text**

Если вы хотите, чтобы текст в фигуре переносился внутри этой фигуры, когда текст выходит за её границу (только по ширине), необходимо использовать параметр **Wrap text in shape**. Чтобы задать эту настройку, нужно установить свойство `WrapText` класса [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) в значение `NullableBool.True`.

Этот код C# демонстрирует, как использовать настройку Wrap Text в презентации PowerPoint:
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.WrapText = NullableBool.True;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```


{{% alert title="Note" color="warning" %}} 
Если установить свойство `WrapText` в `NullableBool.False` для фигуры, когда текст внутри фигуры становится длиннее ширины фигуры, текст будет выходить за её границы одной строкой.
{{% /alert %}}

## **FAQ**

**Влияют ли внутренние отступы текстовой рамки на AutoFit?**

Да. Внутренние отступы (padding) уменьшают доступную область для текста, поэтому AutoFit срабатывает раньше — уменьшая шрифт или изменяя размер формы быстрее. Проверьте и скорректируйте отступы перед настройкой AutoFit.

**Как AutoFit взаимодействует с ручными и мягкими разрывами строк?**

Принудительные разрывы остаются, а AutoFit адаптирует размер шрифта и интервал вокруг них. Удаление лишних разрывов часто уменьшает степень сжатия текста AutoFit.

**Влияет ли изменение шрифта темы или замена шрифта на результаты AutoFit?**

Да. Замена шрифта на другой с другими метриками глифов изменяет ширину/высоту текста, что может изменить окончательный размер шрифта и перенос строк. После любого изменения или замены шрифта следует повторно проверить слайды.