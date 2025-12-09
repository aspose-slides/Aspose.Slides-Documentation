---
title: Главный слайд
type: docs
weight: 30
url: /ru/net/examples/elements/master-slide/
keywords:
- пример главного слайда
- добавить главный слайд
- доступ к главному слайду
- удалить главный слайд
- неиспользуемый главный слайд
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Управляйте главными слайдами в C# с помощью Aspose.Slides: создавайте, редактируйте, клонируйте и форматируйте темы, фоны, заполнители, чтобы унифицировать слайды в PowerPoint и OpenDocument."
---

Главные слайды образуют верхний уровень иерархии наследования слайдов в PowerPoint. A **master slide** определяет общие элементы дизайна, такие как фоны, логотипы и форматирование текста. **Layout slides** наследуются от главных слайдов, а **normal slides** наследуются от слайдов макета.

Эта статья демонстрирует, как создавать, изменять и управлять главными слайдами с помощью Aspose.Slides for .NET.

## Добавить главный слайд

В этом примере показано, как создать новый главный слайд, клонировав стандартный. Затем он добавляет баннер с названием компании ко всем слайдам через наследование макета.

```csharp
static void Add_Master_Slide()
{
    using var pres = new Presentation();

    // Clone the default master slide
    var defaultMasterSlide = pres.Masters[0];
    var newMaster = pres.Masters.AddClone(defaultMasterSlide);

    // Add a banner with company name to the top of the master slide
    var textBox = newMaster.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // Assign the new master slide to a layout slide
    var layoutSlide = pres.LayoutSlides[0];
    layoutSlide.MasterSlide = newMaster;

    // Assign the layout slide to the first slide in the presentation
    pres.Slides[0].LayoutSlide = layoutSlide;
}
````

> 💡 **Подсказка 1:** Главные слайды предоставляют способ применять единый брендинг или общие элементы дизайна ко всем слайдам. Любые изменения, внесённые в главный слайд, автоматически отразятся на зависимых макетах и обычных слайдах.

> 💡 **Подсказка 2:** Любые фигуры или форматирование, добавленные в главный слайд, наследуются слайдами макета и, в свою очередь, всеми обычными слайдами, использующими эти макеты.

> Изображение ниже иллюстрирует, как текстовое поле, добавленное в главный слайд, автоматически отображается на конечном слайде.

![Пример наследования главного слайда](master-slide-banner.png)

## Доступ к главному слайду

Вы можете получить доступ к главным слайдам с помощью коллекции `Presentation.Masters`. Ниже показано, как извлечь их и работать с ними:

```csharp
static void Access_Master_Slide()
{
    using var pres = new Presentation();

    // Access the first master slide
    var firstMasterSlide = pres.Masters[0];

    // Change the background type
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## Удалить главный слайд

Главные слайды можно удалить либо по индексу, либо по ссылке.

```csharp
static void Remove_Master_Slide()
{
    using var pres = new Presentation();

    // Remove by index
    pres.Masters.RemoveAt(0);

    // Or remove by reference
    var firstMasterSlide = pres.Masters[0];
    pres.Masters.Remove(firstMasterSlide);
}
```

## Удалить неиспользуемые главные слайды

Некоторые презентации содержат главные слайды, которые не используются. Удаление этих слайдов может помочь уменьшить размер файла.

```csharp
static void RemoveUnused_Master_Slide()
{
    using var pres = new Presentation();

    // Remove all unused master slides (even those marked as Preserve)
    pres.Masters.RemoveUnused(ignorePreserveField: true);
}
```

> ⚙️ **Подсказка:** Используйте `RemoveUnused(true)`, чтобы очистить неиспользуемые главные слайды и минимизировать размер презентации.