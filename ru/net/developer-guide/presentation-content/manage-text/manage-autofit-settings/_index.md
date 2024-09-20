---
title: Управление настройками автоматической подгонки
type: docs
weight: 30
url: /net/manage-autofit-settings/
keywords: "Textbox, Автоматическая подгонка, Презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Настройка параметров автоматической подгонки для текстового поля в PowerPoint на C# или .NET"
---

По умолчанию, когда вы добавляете текстовое поле, Microsoft PowerPoint использует настройку **Изменить размер фигуры, чтобы исправить текст** для текстового поля — оно автоматически изменяет размер текстового поля, чтобы текст всегда помещался в него.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Когда текст в текстовом поле становится длиннее или больше, PowerPoint автоматически увеличивает текстовое поле — увеличивает его высоту — чтобы оно могло содержать больше текста.
* Когда текст в текстовом поле становится короче или меньше, PowerPoint автоматически уменьшает текстовое поле — уменьшает его высоту — чтобы очистить избыточное пространство.

В PowerPoint есть 4 важных параметра или опции, которые контролируют поведение автоматической подгонки для текстового поля:

* **Не изменять размер**
* **Уменьшить текст при переполнении**
* **Изменить размер фигуры, чтобы соответствовать тексту**
* **Перенос текста в фигуре.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides для .NET предлагает аналогичные параметры — некоторые свойства класса [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) — которые позволяют вам контролировать поведение автоматической подгонки для текстовых полей в презентациях.

## **Изменить размер фигуры, чтобы соответствовать тексту**

Если вы хотите, чтобы текст в рамке всегда помещался в эту рамку после внесения изменений в текст, вы должны использовать опцию **Изменить размер фигуры, чтобы исправить текст**. Чтобы задать эту настройку, установите свойство [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/autofittype) (из класса [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)) в значение `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Этот код на C# показывает, как задать, чтобы текст всегда помещался в свою рамку в презентации PowerPoint:

```c#
 using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Shape;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

Если текст становится длиннее или больше, текстовое поле автоматически изменяет свои размеры (высота увеличивается), чтобы весь текст помещался в него. Если текст становится короче, происходит обратное.

## **Не изменять размер**

Если вы хотите, чтобы текстовое поле или фигура сохраняли свои размеры независимо от внесенных изменений в содержащийся текст, вы должны использовать опцию **Не изменять размер**. Чтобы задать эту настройку, установите свойство [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/autofittype) (из класса [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)) в значение `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Этот код на C# показывает, как указать, чтобы текстовое поле всегда сохраняло свои размеры в презентации PowerPoint:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.None;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

Когда текст становится слишком длинным для своей рамки, он выходит за пределы.

## **Уменьшить текст при переполнении**

Если текст становится слишком длинным для своей рамки, с помощью опции **Уменьшить текст при переполнении** вы можете указать, что размер и расстояние текста должны быть уменьшены, чтобы текст помещался в свою рамку. Чтобы задать эту настройку, установите свойство [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/autofittype) (из класса [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)) в значение `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Этот код на C# показывает, как указать, что текст должен уменьшаться при переполнении в презентации PowerPoint:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Normal;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Информация" color="info" %}}

Когда используется опция **Уменьшить текст при переполнении**, настройка применяется только тогда, когда текст становится слишком длинным для своей рамки.

{{% /alert %}}

## **Перенос текста**

Если вы хотите, чтобы текст в фигуре переносился внутри этой фигуры, когда текст превышает границы фигуры (только ширина), вы должны использовать параметр **Перенос текста в фигуре**. Чтобы задать эту настройку, вам нужно установить свойство [WrapText](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/wraptext) (из класса [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)) в значение `true`.

Этот код на C# показывает, как использовать настройку Перенос текста в презентации PowerPoint:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.WrapText = NullableBool.True;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Примечание" color="warning" %}}

Если вы установите свойство `WrapText` в значение `False` для фигуры, когда текст внутри фигуры становится длиннее ширины фигуры, текст выходит за пределы границ фигуры по одной линии.

{{% /alert %}}