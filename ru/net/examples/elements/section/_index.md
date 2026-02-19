---
title: Раздел
type: docs
weight: 90
url: /ru/net/examples/elements/section/
keywords:
- раздел
- раздел слайда
- добавить раздел
- доступ к разделу
- удалить раздел
- переименовать раздел
- пример кода
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Управляйте разделами слайдов в Aspose.Slides for .NET: создавайте, переименовывайте, переупорядочивайте и группируйте слайды с примерами на C# для форматов PPT, PPTX и ODP."
---
Примеры управления разделами презентации — добавление, доступ, удаление и переименование их программно с использованием **Aspose.Slides for .NET**.

## **Добавить раздел**

Создайте раздел, который начинается с определённого слайда.

```csharp
static void AddSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Укажите слайд, который отмечает начало раздела.
    presentation.Sections.AddSection("New Section", slide);
}
```

## **Доступ к разделу**

Прочитайте информацию о разделе из презентации.

```csharp
static void AccessSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("My Section", slide);

    // Доступ к разделу по индексу.
    var section = presentation.Sections[0];
    var sectionName = section.Name;
}
```

## **Удалить раздел**

Удалите ранее добавленный раздел.

```csharp
static void RemoveSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var section = presentation.Sections.AddSection("Temporary Section", slide);

    // Удалить первый раздел.
    presentation.Sections.RemoveSection(section);
}
```

## **Переименовать раздел**

Измените имя существующего раздела.

```csharp
static void RenameSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("Old Name", slide);

    var section = presentation.Sections[0];
    section.Name = "New Name";
}
```