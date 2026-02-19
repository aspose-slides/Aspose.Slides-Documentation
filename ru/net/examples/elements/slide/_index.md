---
title: Слайд
type: docs
weight: 10
url: /ru/net/examples/elements/slide/
keywords:
- слайд
- добавить слайд
- доступ к слайду
- индекс слайда
- клонировать слайд
- переупорядочить слайды
- удалить слайд
- пример кода
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Управляйте слайдами в Aspose.Slides for .NET: создавайте, клонируйте, переупорядочивайте, изменяйте размер, задавайте фон и применяйте переходы с помощью C# для презентаций PPT, PPTX и ODP."
---
В этой статье представлена серия примеров, демонстрирующих работу со слайдами с помощью **Aspose.Slides for .NET**. Вы узнаете, как добавлять, получать доступ, копировать, переупорядочивать и удалять слайды, используя класс `Presentation`.

Каждый пример ниже содержит краткое объяснение, за которым следует фрагмент кода на C#.

## **Добавить слайд**

Чтобы добавить новый слайд, сначала необходимо выбрать макет. В этом примере мы используем макет `Blank` и добавляем пустой слайд в презентацию.

```csharp
static void AddSlide()
{
    using var presentation = new Presentation();

    // Каждый слайд основан на макете, который сам основан на главном слайде.
    // Используйте макет Blank, чтобы создать новый слайд.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Добавьте новый пустой слайд, используя выбранный макет.
    presentation.Slides.AddEmptySlide(layout: blankLayout);
}
```

> 💡 **Примечание:** Каждый макет слайда наследуется от главного слайда, который определяет общий дизайн и структуру заполнителей. Ниже изображение, иллюстрирующее, как главные слайды и их связанные макеты организованы в PowerPoint.

![Отношения главного слайда и макета](master-layout-slide.png)

## **Доступ к слайдам по индексу**

Вы можете получать доступ к слайдам, используя их индекс, или найти индекс слайда по ссылке. Это полезно для перебора или изменения определенных слайдов.

```csharp
static void AccessSlide()
{
    // По умолчанию при создании презентации добавляется один пустой слайд.
    using var presentation = new Presentation();

    // Добавьте еще один пустой слайд.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Получите доступ к слайдам по индексу.
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides[1];

    // Получите индекс слайда по ссылке, затем доступ к нему по индексу.
    var secondSlideIndex = presentation.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = presentation.Slides[secondSlideIndex];
}
```

## **Клонировать слайд**

В этом примере показывается, как клонировать существующий слайд. Клонированный слайд автоматически добавляется в конец коллекции слайдов.

```csharp
static void CloneSlide()
{
    // По умолчанию презентация содержит один пустой слайд.
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Клонируйте первый слайд; он будет добавлен в конец презентации.
    var clonedSlide = presentation.Slides.AddClone(sourceSlide: firstSlide);

    // Индекс клонированного слайда равен 1 (второй слайд в презентации).
    var clonedSlideIndex = presentation.Slides.IndexOf(clonedSlide);
}
```

## **Переупорядочить слайды**

Вы можете изменить порядок слайдов, переместив один в новый индекс. В данном случае мы перемещаем клонированный слайд на первую позицию.

```csharp
static void ReorderSlide()
{
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Добавьте клон первого слайда (созданный по умолчанию).
    var clonedSlide = presentation.Slides.AddClone(firstSlide);

    // Переместите клонированный слайд в первую позицию (остальные сдвигаются вниз).
    presentation.Slides.Reorder(index: 0, clonedSlide);
}
```

## **Удалить слайд**

Чтобы удалить слайд, просто укажите его и вызовите `Remove`. В этом примере добавляется второй слайд, после чего оригинальный удаляется, оставляя только новый.

```csharp
static void RemoveSlide()
{
    using var presentation = new Presentation();

    // Добавьте новый пустой слайд в дополнение к первому слайду, созданному по умолчанию.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    var secondSlide = presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Удалите первый слайд; останется только что добавленный слайд.
    var firstSlide = presentation.Slides[0];
    presentation.Slides.Remove(firstSlide);
}
```