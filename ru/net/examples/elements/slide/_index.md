---
title: Слайд
type: docs
weight: 10
url: /ru/net/examples/elements/slide/
keywords:
- пример слайда
- добавить слайд
- доступ к слайду
- индекс слайда
- клонировать слайд
- переупорядочить слайды
- удалить слайд
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Управляйте слайдами в C# с помощью Aspose.Slides: создавайте, клонируйте, переупорядочивайте, скрывайте, задавайте фон и размер, применяйте переходы и экспортируйте для PowerPoint и OpenDocument."
---

В этой статье представлена серия примеров, демонстрирующих, как работать со слайдами с помощью **Aspose.Slides for .NET**. Вы узнаете, как добавлять, получать доступ, клонировать, переупорядочивать и удалять слайды, используя класс `Presentation`.

Каждый пример ниже включает краткое объяснение, за которым следует фрагмент кода на C#.

## **Добавить слайд**

Чтобы добавить новый слайд, сначала необходимо выбрать макет. В этом примере мы используем макет `Blank` и добавляем пустой слайд в презентацию.
```csharp
static void Add_Slide()
{
    using var pres = new Presentation();

    // Каждый слайд основан на макете, который сам основан на главном слайде.
    // Используйте макет Blank для создания нового слайда.
    var blankLayout = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Добавьте новый пустой слайд, используя выбранный макет
    pres.Slides.AddEmptySlide(layout: blankLayout);
}
````

> 💡 **Tip:** Each slide layout is derived from a master slide, which defines the overall design and placeholder structure. The image below illustrates how master slides and their associated layouts are organized in PowerPoint.

![Master and Layout Relationship](master-layout-slide.png)

## **Access Slides by Index**

You can access slides using their index, or find a slide’s index based on a reference. This is useful for iterating through or modifying specific slides.

```csharp
static void Access_Slide()
{
    // По умолчанию создаётся презентация с одним пустым слайдом
    using var pres = new Presentation();

    // Добавьте ещё один пустой слайд
    pres.Slides.AddEmptySlide(layout: pres.LayoutSlides.GetByType(SlideLayoutType.Blank));

    // Доступ к слайдам по индексу
    var firstSlide = pres.Slides[0];
    var secondSlide = pres.Slides[1];

    // Получите индекс слайда из ссылки, затем доступ к нему по индексу
    var secondSlideIndex = pres.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = pres.Slides[secondSlideIndex];
}
```

## **Clone a Slide**

This example demonstrates how to clone an existing slide. The cloned slide is automatically added to the end of the slide collection.

```csharp
static void Clone_Slide()
{
    // По умолчанию презентация содержит один пустой слайд
    using var pres = new Presentation();

    // Клонируйте первый слайд; он будет добавлен в конец презентации
    var clonedSlide = pres.Slides.AddClone(sourceSlide: pres.Slides[0]);

    // Индекс клонированного слайда равен 1 (второй слайд в презентации)
    var clonedSlideIndex = pres.Slides.IndexOf(clonedSlide);
}
```

## **Reorder Slides**

You can change the order of slides by moving one to a new index. In this case, we move a cloned slide to the first position.

```csharp
static void ReOrder_Slide()
{
    using var pres = new Presentation();

    // Добавьте клон первого слайда (созданного по умолчанию)
    var clonedSlide = pres.Slides.AddClone(pres.Slides[0]);

    // Переместите клонированный слайд в первую позицию (остальные сдвигаются вниз)
    pres.Slides.Reorder(index: 0, clonedSlide);
}
```

## **Remove a Slide**

To remove a slide, simply reference it and call `Remove`. This example adds a second slide and then removes the original, leaving only the new one.

```csharp
static void Remove_Slide()
{
    using var pres = new Presentation();

    // Добавьте новый пустой слайд в дополнение к первому слайду по умолчанию
    var secondSlide = pres.Slides.AddEmptySlide(layout: pres.LayoutSlides.GetByType(SlideLayoutType.Blank));

    // Удалите первый слайд; останется только только что добавленный слайд
    var firstSlide = pres.Slides[0];
    pres.Slides.Remove(firstSlide);
}
```
