---
title: Текстовое поле
type: docs
weight: 40
url: /ru/net/examples/elements/text-box/
keywords:
- пример текстового поля
- добавить текстовое поле
- доступ к текстовому полю
- удалить текстовое поле
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создавайте и форматируйте текстовые поля в C# с помощью Aspose.Slides: задавайте шрифты, выравнивание, перенос, автоматический размер и ссылки для улучшения слайдов в PowerPoint и OpenDocument."
---

В Aspose.Slides **текстовое поле** представлено объектом `AutoShape`. Практически любая форма может содержать текст, но типичное текстовое поле не имеет заливки и границы и отображает только текст.

Это руководство объясняет, как программно добавлять, получать доступ и удалять текстовые поля.

## **Добавить текстовое поле**

Текстовое поле — это просто `AutoShape` без заливки и границы и с некоторым форматированным текстом. Вот как его создать:

```csharp
public static void Add_TextBox()
{
    using var pres = new Presentation();

    // Create a rectangle shape (defaults to filled with border and no text)
    var textBox = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // Remove fill and border to make it look like a typical text box
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // Set text formatting
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // Assign the actual text content
    textBox.TextFrame.Text = "Some text...";
}
```

> 💡 **Примечание:** Любой `AutoShape`, содержащий непустой `TextFrame`, может функционировать как текстовое поле.

## **Доступ к текстовым полям по содержимому**

Чтобы найти все текстовые поля, содержащие определённое ключевое слово (например, "Slide"), пройдите по всем фигурам и проверьте их текст:

```csharp
public static void Access_TextBox()
{
    using var pres = new Presentation();

    foreach (var shape in pres.Slides[0].Shapes)
    {
        // Only AutoShapes can contain editable text
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // Do something with the matching text box
            }
        }
    }
}
```

## **Удалить текстовые поля по содержимому**

В этом примере находятся и удаляются все текстовые поля на первом слайде, которые содержат определённое ключевое слово:

```csharp
public static void Remove_TextBox()
{
    using var pres = new Presentation();

    var shapesToRemove = pres.Slides[0].Shapes
        .Where(s => s is AutoShape autoShape && autoShape.TextFrame.Text.Contains("Slide"))
        .ToList();

    shapesToRemove.ForEach(shape => pres.Slides[0].Shapes.Remove(shape));
}
```

> 💡 **Совет:** Всегда создавайте копию коллекции фигур перед её изменением во время итерации, чтобы избежать ошибок модификации коллекции.