---
title: Слайд макета
type: docs
weight: 20
url: /ru/net/examples/elements/layout-slide/
keywords:
- макет слайда
- добавить макет слайда
- доступ к макету слайда
- удалить макет слайда
- неиспользуемый макет слайда
- клонировать макет слайда
- пример кода
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Мастер‑макеты слайдов в Aspose.Slides для .NET: выбирайте, применяйте и настраивайте макеты слайдов, заполнители и мастера с примерами на C# для презентаций PPT, PPTX и ODP."
---
В этой статье демонстрируется, как работать с **Layout Slides** в Aspose.Slides for .NET. Слайд макета определяет дизайн и форматирование, наследуемые обычными слайдами. Вы можете добавлять, получать доступ, клонировать и удалять слайды макета, а также очищать неиспользуемые, чтобы уменьшить размер презентации.

## **Добавить слайд макета**

Вы можете создать пользовательский слайд макета, чтобы определить повторно используемое форматирование. Например, вы можете добавить текстовое поле, которое будет отображаться на всех слайдах, использующих этот макет.

```csharp
static void AddLayoutSlide()
{
    using var presentation = new Presentation();
    
    var masterSlide = presentation.Masters[0];

    // Создайте слайд макета с типом пустого макета и пользовательским именем.
    var layoutSlide = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.Blank, "Main layout");

    // Добавьте текстовое поле на слайд макета.
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // Добавьте два слайда, используя этот макет; оба унаследуют текст из макета.
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
}
```

> 💡 **Примечание 1:** Слайды макета выступают в качестве шаблонов для отдельных слайдов. Вы можете определить общие элементы один раз и повторно использовать их на многих слайдах.

> 💡 **Примечание 2:** Когда вы добавляете фигуры или текст в слайд макета, все слайды, основанные на этом макете, автоматически отображают этот общий контент.  
> На скриншоте ниже показаны два слайда, каждый из которых наследует текстовое поле из одного и того же слайда макета.

![Слайды, наследующие содержимое макета](layout-slide-result.png)

## **Получить доступ к слайду макета**

Слайды макета можно получить по индексу или по типу макета (например, `Blank`, `Title`, `SectionHeader` и т.д.).

```csharp
static void AccessLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Доступ к слайду макета по индексу.
    var firstLayoutSlide = presentation.LayoutSlides[0];
    
    // Доступ к слайду макета по типу.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## **Удалить слайд макета**

Вы можете удалить конкретный слайд макета, если он больше не нужен.

```csharp
static void RemoveLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Получить слайд макета по типу и удалить его.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Custom);
    presentation.LayoutSlides.Remove(blankLayoutSlide);
}
```

## **Удалить неиспользуемые слайды макета**

Чтобы уменьшить размер презентации, вы можете удалить слайды макета, которые не используются ни одним обычным слайдом.

```csharp
static void RemoveUnusedLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Автоматически удаляет все слайды макета, которые не используются ни одним слайдом.
    presentation.LayoutSlides.RemoveUnused();
}
```

## **Клонировать слайд макета**

Вы можете дублировать слайд макета с помощью метода `AddClone`.

```csharp
static void CloneLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Получить существующий слайд макета по типу.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // Клонировать слайд макета в конец коллекции слайдов макета.
    var clonedLayoutSlide = presentation.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **Итог:** Слайды макета являются мощным инструментом для управления единообразным форматированием на всех слайдах. Aspose.Slides предоставляет полный контроль над созданием, управлением и оптимизацией слайдов макета.