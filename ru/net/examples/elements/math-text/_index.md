---
title: Математический текст
type: docs
weight: 160
url: /ru/net/examples/elements/math-text/
keywords:
- математический текст
- добавить математический текст
- доступ к математическому тексту
- удалить математический текст
- форматировать математический текст
- пример кода
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Изучите примеры MathematicalText в Aspose.Slides for .NET: создавайте и форматируйте уравнения, дроби, матрицы и символы с помощью C# в презентациях PPT, PPTX и ODP."
---
В этой статье демонстрируется работа с математическими текстовыми формами и форматирование уравнений с помощью **Aspose.Slides for .NET**.

## **Добавить математический текст**

Создайте математическую форму, содержащую дробь и теорему Пифагора.

```csharp
static void AddMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Добавить математическую форму на слайд.
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // Доступ к математическому абзацу.
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

    // Добавить простую дробь: x / y
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    // Добавить уравнение: c² = a² + b²
    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);
}
```

## **Доступ к математическому тексту**

Найдите форму, содержащую математический абзац на слайде.

```csharp
static void AccessMathText()
{
    using var presentation = new Presentation("sample.pptx");
    var slide = presentation.Slides[0];

    // Найти первую форму, содержащую математический абзац.
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Пример: создать дробь (не добавлено здесь).
        var fraction = new MathematicalText("x").Divide("y");

        // Использовать mathParagraph или fraction по мере необходимости...
    }
}
```

## **Удалить математический текст**

Удалите математическую форму со слайда.

```csharp
static void RemoveMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    slide.Shapes.Remove(mathShape);
}
```

## **Форматировать математический текст**

Установите свойства шрифта для математической части.

```csharp
static void FormatMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    mathShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 20;
}
```