---
title: Раздел
type: docs
weight: 90
url: /ru/net/examples/elements/section/
keywords:
- пример раздела
- раздел слайдов
- добавить раздел
- доступ к разделу
- удалить раздел
- переименовать раздел
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Управляйте разделами слайдов в C# с помощью Aspose.Slides: легко создавайте, переименовывайте, переставляйте, перемещайте слайды между разделами и контролируйте их видимость для PPT, PPTX и ODP."
---

Примеры управления разделами презентации—добавление, доступ, удаление и переименование их программно с использованием **Aspose.Slides for .NET**.

## **Добавить раздел**
Создайте раздел, который начинается с определённого слайда.
```csharp
static void Add_Section()
{
    using var pres = new Presentation();

    // Укажите слайд, который отмечает начало раздела
    pres.Sections.AddSection("New Section", pres.Slides[0]);
}
```


## **Доступ к разделу**
Прочитайте информацию о разделе из презентации.
```csharp
static void Access_Section()
{
    using var pres = new Presentation();
    pres.Sections.AddSection("My Section", pres.Slides[0]);

    // Доступ к разделу по индексу
    var section = pres.Sections[0];
    var sectionName = section.Name;
}
```


## **Удалить раздел**
Удалите ранее добавленный раздел.
```csharp
static void Remove_Section()
{
    using var pres = new Presentation();
    var section = pres.Sections.AddSection("Temporary Section", pres.Slides[0]);

    // Удалить первый раздел
    pres.Sections.RemoveSection(section);
}
```


## **Переименовать раздел**
Измените название существующего раздела.
```csharp
static void Rename_Section()
{
    using var pres = new Presentation();
    pres.Sections.AddSection("Old Name", pres.Slides[0]);

    var section = pres.Sections[0];
    section.Name = "New Name";
}
```
