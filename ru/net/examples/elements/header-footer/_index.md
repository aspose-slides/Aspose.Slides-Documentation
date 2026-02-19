---
title: Заголовок и нижний колонтитул
type: docs
weight: 220
url: /ru/net/examples/elements/header-footer/
keywords:
- заголовок и нижний колонтитул
- добавить заголовок и нижний колонтитул
- обновить заголовок и нижний колонтитул
- пример кода
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Управляйте заголовками и нижними колонтитулами слайдов с помощью Aspose.Slides for .NET: добавляйте даты, номера слайдов и пользовательский текст в PPT, PPTX и ODP с примерами на C#."
---
В этой статье демонстрируется, как добавить нижние колонтитулы и обновить заполнители даты и времени с использованием **Aspose.Slides for .NET**.

## **Add a Footer**
## **Add a Footer**
Добавьте текст в область нижнего колонтитула слайда и сделайте его видимым.

```csharp
static void AddHeaderFooter()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```

## **Update Date and Time**
## **Update Date and Time**
Измените заполнитель даты и времени на слайде.

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```