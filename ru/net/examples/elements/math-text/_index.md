---
title: Математический текст
type: docs
weight: 160
url: /ru/net/examples/elements/math-text/
keywords:
- пример математического текста
- добавить математический текст
- доступ к математическому тексту
- удалить математический текст
- форматировать математический текст
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Работа с математическим текстом в C# с использованием Aspose.Slides: создание и редактирование уравнений, дробей, радикалов, индексов, форматирование и визуализация результатов для PPT и PPTX."
---

Иллюстрирует работу с математическими текстовыми фигурами и форматирование уравнений с использованием **Aspose.Slides for .NET**.

## **Добавить математический текст**

Создайте математическую фигуру, содержащую дробь и формулу Пифагора.
```csharp
static void Add_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Добавить математическую фигуру на слайд
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // Получить доступ к математическому абзацу
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

Найдите фигуру, содержащую математический абзац на слайде.
```csharp
static void Access_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Найти первую фигуру, содержащую математический абзац
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Пример: создать дробь (не добавлена здесь)
        var fraction = new MathematicalText("x").Divide("y");

        // Использовать mathParagraph или fraction по необходимости...
    }
}
```


## **Удалить математический текст**

Удалите математическую фигуру со слайда.
```csharp
static void Remove_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

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
static void Format_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    mathShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 20;
}
```
