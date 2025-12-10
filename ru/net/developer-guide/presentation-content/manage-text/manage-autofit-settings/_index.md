---
title: Улучшите свои презентации с AutoFit в .NET
linktitle: Настройки автоподгонки
type: docs
weight: 30
url: /ru/net/manage-autofit-settings/
keywords:
- текстовое поле
- автоподгонка
- отключить автоподгонку
- подгонка текста
- сжатие текста
- перенос текста
- изменение размера фигуры
- PowerPoint
- презентация
- C#
- .NET
- Aspose.Slides
description: "Узнайте, как управлять настройками AutoFit в Aspose.Slides для .NET, чтобы оптимизировать отображение текста в ваших презентациях PowerPoint и OpenDocument и повысить читаемость содержимого."
---

## **Обзор**

По умолчанию, когда вы добавляете текстовое поле, Microsoft PowerPoint использует параметр **Resize shape to fit text** для текстового поля — он автоматически изменяет размер поля, чтобы текст всегда помещался в нём.

![Текстовое поле в PowerPoint](textbox-in-powerpoint.png)

* Когда текст в текстовом поле становится длиннее или крупнее, PowerPoint автоматически увеличивает текстовое поле — увеличивая его высоту — чтобы разместить больше текста.
* Когда текст в текстовом поле становится короче или меньше, PowerPoint автоматически уменьшает текстовое поле — уменьшая его высоту — чтобы избавиться от лишнего пространства.

В PowerPoint эти четыре важных параметра или опции управляют поведением автоподгонки для текстового поля:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape**

![Параметры автоподгонки в PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for .NET предоставляет аналогичные опции — свойства класса [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) — которые позволяют контролировать поведение автоподгонки для текстовых полей в презентациях.

## **Resize a Shape to Fit Text**

Если вы хотите, чтобы текст в поле всегда помещался в это поле после изменений текста, необходимо использовать опцию **Resize shape to fit text**. Чтобы задать эту настройку, установите свойство `AutofitType` класса [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) в значение `Shape`.

![Изменить размер фигуры под текст](alwaysfit-setting-powerpoint.png)

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


Если текст становится длиннее или крупнее, текстовое поле будет автоматически изменено (увеличена высота), чтобы весь текст помещался в нём. Если текст становится короче, произойдёт обратное действие.

## **Do Not Autofit**

Если вы хотите, чтобы текстовое поле или фигура сохраняла свои размеры независимо от изменений текста, необходимо использовать опцию **Do not Autofit**. Чтобы задать эту настройку, установите свойство `AutofitType` класса [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) в значение `None`.

![Настройка "Do not Autofit" в PowerPoint](donotautofit-setting-powerpoint.png)

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


Когда текст становится слишком длинным для своего поля, он выходит за его границы.

## **Shrink Text on Overflow**

Если текст становится слишком длинным для своего поля, с помощью опции **Shrink text on overflow** можно указать, что размер и межбуквенное расстояние текста должны быть уменьшены, чтобы он поместился в поле. Чтобы задать эту настройку, установите свойство `AutofitType` класса [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) в значение `Normal`.

![Настройка "Shrink text on overflow" в PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

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
При использовании опции **Shrink text on overflow** настройка применяется только тогда, когда текст становится слишком длинным для своего поля.
{{% /alert %}}

## **Wrap Text**

Если вы хотите, чтобы текст внутри фигуры автоматически переносился внутри этой фигуры, когда текст выходит за её границу (только по ширине), используйте параметр **Wrap text in shape**. Чтобы задать эту настройку, установите свойство `WrapText` класса [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) в значение `NullableBool.True`.

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
Если установить свойство `WrapText` в `NullableBool.False` для фигуры, когда текст внутри фигуры становится длиннее её ширины, текст будет выходить за границы фигуры в одну строку.
{{% /alert %}}

## **FAQ**

**Влияют ли внутренние отступы текстового фрейма на автоподгонку?**

Да. Отступы (внутренние поля) уменьшают доступную площадь для текста, поэтому автоподгонка срабатывает раньше — уменьшая шрифт или размер фигуры быстрее. Проверьте и отрегулируйте отступы перед настройкой автоподгонки.

**Как автоподгонка взаимодействует с ручными и мягкими разрывами строк?**

Принудительные разрывы остаются на месте, а автоподгонка регулирует размер шрифта и межстрочное расстояние вокруг них. Удаление лишних разрывов часто уменьшает степень, с которой автоподгонка должна сжимать текст.

**Влияет ли изменение шрифта темы или подстановка шрифта на результаты автоподгонки?**

Да. Замена шрифта на другой с другими метриками глифов меняет ширину/высоту текста, что может изменить конечный размер шрифта и перенос строк. После любой смены шрифта или подстановки проверьте слайды заново.