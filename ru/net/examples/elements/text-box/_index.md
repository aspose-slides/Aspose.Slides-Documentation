---
title: Текстовое поле
type: docs
weight: 40
url: /ru/net/examples/elements/text-box/
keywords:
- текстовое поле
- добавить текстовое поле
- доступ к текстовому полю
- удалить текстовое поле
- пример кода
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Работайте с текстовыми полями в Aspose.Slides для .NET: добавляйте, форматируйте, выравнивайте, переносите, автоматически подгоняйте и стилизуйте текст с помощью C# для презентаций PPT, PPTX и ODP."
---
В Aspose.Slides **текстовое поле** представлено объектом `AutoShape`. Практически любая фигура может содержать текст, но типичное текстовое поле не имеет заливки или границы и отображает только текст.

Это руководство объясняет, как программно добавлять, получать доступ и удалять текстовые поля.

## **Добавить текстовое поле**

Текстовое поле — это просто `AutoShape` без заливки и границы и с некоторым форматированным текстом. Ниже показано, как создать его:

```csharp
public static void AddTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Создать прямоугольную форму (по умолчанию заполнена границей и без текста).
    var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // Удалить заливку и границу, чтобы он выглядел как типичное текстовое поле.
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // Установить форматирование текста.
    var paragraph = textBox.TextFrame.Paragraphs[0];
    var textFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
    textFormat.FillFormat.FillType = FillType.Solid;
    textFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // Назначить фактическое содержимое текста.
    textBox.TextFrame.Text = "Some text...";
}
```

> 💡 **Примечание:** Любой `AutoShape`, содержащий непустой `TextFrame`, может функционировать как текстовое поле.

## **Получить доступ к текстовым полям по содержимому**

Чтобы найти все текстовые поля, содержащие определённое ключевое слово (например, "Slide"), пройдите по всем фигурам и проверьте их текст:

```csharp
public static void AccessTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        // Только AutoShape могут содержать редактируемый текст.
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // Выполните нужные действия с найденным текстовым полем.
            }
        }
    }
}
```

## **Удалить текстовые поля по содержимому**

В этом примере находятся и удаляются все текстовые поля на первом слайде, содержащие определённое ключевое слово:

```csharp
public static void RemoveTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shapesToRemove = slide.Shapes
        .Where(s => s is AutoShape autoShape && autoShape.TextFrame.Text.Contains("Slide"))
        .ToList();

    shapesToRemove.ForEach(shape => slide.Shapes.Remove(shape));
}
```

> 💡 **Совет:** Всегда создавайте копию коллекции фигур перед её изменением во время обхода, чтобы избежать ошибок модификации коллекции.