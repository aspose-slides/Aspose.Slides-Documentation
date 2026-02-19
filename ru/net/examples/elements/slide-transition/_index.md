---
title: Переход слайда
type: docs
weight: 110
url: /ru/net/examples/elements/slide-transition/
keywords:
- переход слайда
- добавить переход слайда
- получить переход слайда
- удалить переход слайда
- длительность перехода
- пример кода
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Освойте переходы слайдов в Aspose.Slides for .NET: добавляйте, настраивайте и упорядочивайте эффекты и их длительность с примерами на C# для презентаций PPT, PPTX и ODP."
---
В этой статье демонстрируется применение эффектов переходов слайдов и их таймингов с помощью **Aspose.Slides for .NET**.

## **Добавить переход слайда**
Примените эффект плавного перехода к первому слайду.

```csharp
static void AddSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Применить плавный переход.
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```

## **Получить переход слайда**
Прочитайте тип перехода, текущий для слайда.

```csharp
static void AccessSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Push;

    // Получить тип перехода.
    var type = slide.SlideShowTransition.Type;
}
```

## **Удалить переход слайда**
Снимите любой эффект перехода, установив тип в `None`.

```csharp
static void RemoveSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Fade;

    // Удалить переход, установив None.
    slide.SlideShowTransition.Type = TransitionType.None;
}
```

## **Установить длительность перехода**
Укажите, как долго слайд отображается перед автоматическим переходом.

```csharp
static void SetTransitionDuration()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // в миллисекундах
}
```