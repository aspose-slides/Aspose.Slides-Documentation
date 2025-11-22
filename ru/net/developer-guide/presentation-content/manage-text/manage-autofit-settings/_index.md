---
title: Улучшите свои презентации с помощью AutoFit в C#
linktitle: Управление настройками AutoFit
type: docs
weight: 30
url: /ru/net/manage-autofit-settings/
keywords:
- текстовое поле
- автоподгонка
- не автоподгонка
- подгонка текста
- уменьшение текста
- перенос текста
- изменение размера фигуры
- PowerPoint
- презентация
- C#
- .NET
- Aspose.Slides
description: "Узнайте, как управлять настройками AutoFit в Aspose.Slides для .NET, оптимизировать отображение текста в ваших презентациях PowerPoint и OpenDocument и улучшить читаемость контента."
---

## **Обзор**

По умолчанию, когда вы добавляете текстовое поле, Microsoft PowerPoint использует настройку **Resize shape to fit text** — он автоматически изменяет размер текстового поля, чтобы его текст всегда помещался.

![Текстовое поле в PowerPoint](textbox-in-powerpoint.png)

* Когда текст в текстовом поле становится длиннее или крупнее, PowerPoint автоматически увеличивает высоту поля, чтобы разместить больше текста.
* Когда текст в текстовом поле становится короче или меньше, PowerPoint автоматически уменьшает высоту поля, освобождая лишнее пространство.

В PowerPoint существуют четыре важных параметра, управляющих поведением автоматической подгонки текста в текстовом поле:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape**

![Параметры автоматической подгонки в PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for .NET предоставляет аналогичные параметры — свойства класса [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat), позволяющие управлять поведением автоматической подгонки текста в презентациях.

## **Resize Shape to Fit Text**

Если вы хотите, чтобы текст всегда помещался в поле после внесения изменений, необходимо использовать параметр **Resize shape to fit text**. Чтобы задать эту настройку, установите свойство `AutofitType` класса [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) в значение `Shape`.

![Resize shape to fit text](alwaysfit-setting-powerpoint.png)

Этот C#‑код демонстрирует, как указать, что текст всегда должен помещаться в своё поле в презентации PowerPoint:
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


Если текст становится длиннее или крупнее, высота текстового поля будет автоматически увеличена, чтобы весь текст уместился. При уменьшении текста произойдёт обратное действие.

## **Do Not Autofit**

Если требуется, чтобы текстовое поле или фигура сохраняли свои размеры независимо от изменений текста, используйте параметр **Do not Autofit**. Для задания этой настройки установите свойство `AutofitType` класса [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) в значение `None`.

!["Do not Autofit" настройка в PowerPoint](donotautofit-setting-powerpoint.png)

Этот C#‑код показывает, как задать, чтобы текстовое поле сохраняло свои размеры в презентации PowerPoint:
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


Когда текст становится слишком длинным для поля, он выходит за его пределы.

## **Shrink Text on Overflow**

Если текст слишком длинный для поля, с помощью параметра **Shrink text on overflow** можно указать, что размер и межсимвольный интервал текста должны уменьшаться, чтобы он поместился. Установите свойство `AutofitType` класса [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) в значение `Normal`.

!["Shrink text on overflow" настройка в PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

Этот C#‑код демонстрирует, как указать, что текст должен уменьшаться при переполнении в презентации PowerPoint:
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


{{% alert title="Информация" color="info" %}}
При использовании опции **Shrink text on overflow** настройка применяется только тогда, когда текст становится слишком длинным для своего поля.
{{% /alert %}}

## **Wrap Text**

Если необходимо, чтобы текст в фигуре переносился внутри неё, когда он превышает ширину фигуры, используйте параметр **Wrap text in shape**. Для задания этой настройки установите свойство `WrapText` класса [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) в значение `NullableBool.True`.

Этот C#‑код показывает, как применить настройку переноса текста в презентации PowerPoint:
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


{{% alert title="Примечание" color="warning" %}} 
Если свойство `WrapText` установить в `NullableBool.False` для фигуры, при превышении текста ширины фигуры он будет выходить за её границы в одну строку.
{{% /alert %}}

## **FAQ**

**Влияют ли внутренние отступы текстового кадра на AutoFit?**

Да. Внутренние отступы (padding) уменьшают доступную область для текста, поэтому AutoFit срабатывает раньше — шрифт уменьшается или фигура изменяется размером раньше. Проверьте и при необходимости поправьте отступы перед настройкой AutoFit.

**Как AutoFit взаимодействует с ручными и мягкими разрывами строк?**

Принудительные разрывы остаются на месте, а AutoFit подстраивает размер шрифта и межсимвольный интервал вокруг них. Удаление лишних разрывов часто снижает степень, с которой AutoFit вынужден уменьшать текст.

**Влияет ли изменение шрифта темы или подстановка шрифта на результаты AutoFit?**

Да. Замена шрифта на другой с другими метриками глифов меняет ширину/высоту текста, что может изменить итоговый размер шрифта и перенос строк. После любой замены шрифта или подстановки рекомендуется перепроверить слайды.