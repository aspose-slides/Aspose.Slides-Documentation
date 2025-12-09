---
title: "Заголовок и нижний колонтитул"
type: docs
weight: 220
url: /ru/net/examples/elements/elements/header-footer/
keywords:
- пример заголовка и нижнего колонтитула
- добавить заголовок и нижний колонтитул
- обновить заголовок и нижний колонтитул
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Управление заголовками и нижними колонтитулами в C# с помощью Aspose.Slides: добавление или редактирование даты/времени, номеров слайдов и текста нижнего колонтитула, отображение или скрытие заполнителей в PPT, PPTX и ODP."
---

Показывает, как добавлять нижние колонтитулы и обновлять заполнители даты и времени с использованием **Aspose.Slides for .NET**.

## Добавить нижний колонтитул

Добавьте текст в область нижнего колонтитула слайда и сделайте его видимым.
```csharp
static void Add_Header_Footer()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```


## Обновить дату и время

Измените заполнитель даты и времени на слайде.
```csharp
static void Update_Date_Time()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```
