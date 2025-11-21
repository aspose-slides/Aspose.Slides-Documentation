---
title: Гиперссылка
type: docs
weight: 130
url: /ru/net/examples/elements/hyperlink/
keywords:
- пример гиперссылки
- добавить гиперссылку
- доступ к гиперссылке
- удалить гиперссылку
- обновить гиперссылку
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Добавляйте, редактируйте и удаляйте гиперссылки в C# с помощью Aspose.Slides: текст ссылок, фигуры, слайды, URL и электронную почту; задавайте цели и действия для PPT, PPTX и ODP."
---

Продемонстрировано добавление, доступ, удаление и обновление гиперссылок на фигурах с использованием **Aspose.Slides for .NET**.

## Добавить гиперссылку

Создайте прямоугольную фигуру с гиперссылкой, указывающей на внешний веб‑сайт.
```csharp
static void Add_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");
}
```


## Доступ к гиперссылке

Прочитайте информацию о гиперссылке из текстовой части фигуры.
```csharp
static void Access_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;
}
```


## Удалить гиперссылку

Очистите гиперссылку из текста фигуры.
```csharp
static void Remove_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = null;
}
```


## Обновить гиперссылку

Измените цель существующей гиперссылки. Используйте `HyperlinkManager` для изменения текста, который уже содержит гиперссылку, что имитирует безопасное обновление гиперссылок в PowerPoint.
```csharp
static void Update_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // Изменение гиперссылки внутри существующего текста должно выполняться через
    // HyperlinkManager, а не прямую установку свойства.
    // Это имитирует способ, которым PowerPoint безопасно обновляет гиперссылки.
    portion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```
