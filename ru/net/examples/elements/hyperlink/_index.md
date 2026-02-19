---
title: Гиперссылка
type: docs
weight: 130
url: /ru/net/examples/elements/hyperlink/
keywords:
- гиперссылка
- добавить гиперссылку
- доступ к гиперссылке
- удалить гиперссылку
- обновить гиперссылку
- пример кода
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Добавляйте и управляйте гиперссылками в Aspose.Slides для .NET: связывайте текст, формы и изображения, задавайте цели и действия для PPT, PPTX и ODP с примерами на C#."
---
В этой статье демонстрируется добавление, чтение, удаление и обновление гиперссылок на формах с использованием **Aspose.Slides for .NET**.

## **Добавить гиперссылку**

Создайте прямоугольную форму с гиперссылкой, указывающей на внешний веб-сайт.

```csharp
static void AddHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");
}
```

## **Доступ к гиперссылке**

Прочитайте информацию о гиперссылке из текстовой части формы.

```csharp
static void AccessHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;
}
```

## **Удалить гиперссылку**

Очистите гиперссылку из текста формы.

```csharp
static void RemoveHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    textPortion.PortionFormat.HyperlinkClick = null;
}
```

## **Обновить гиперссылку**

Измените целевой адрес существующей гиперссылки. Используйте `HyperlinkManager` для изменения текста, уже содержащего гиперссылку, что имитирует безопасное обновление гиперссылок в PowerPoint.

```csharp
static void UpdateHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // Изменение гиперссылки внутри существующего текста должно выполняться через
    // HyperlinkManager, а не прямую установку свойства.
    // Это имитирует то, как PowerPoint безопасно обновляет гиперссылки.
    textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```