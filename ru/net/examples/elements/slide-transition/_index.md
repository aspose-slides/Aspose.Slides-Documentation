---
title: Переход слайда
type: docs
weight: 110
url: /ru/net/examples/elements/slide-transition/
keywords:
- пример перехода слайда
- добавить переход слайда
- доступ к переходу слайда
- удалить переход слайда
- длительность перехода
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Управляйте переходами слайдов в C# с помощью Aspose.Slides: выбирайте типы, скорость, звук и тайминг, чтобы улучшить презентации в форматах PPT, PPTX и ODP."
---

Продемонстрировано применение эффектов перехода слайдов и их временных настроек с помощью **Aspose.Slides for .NET**.

## **Добавить переход слайда**

Примените эффект плавного перехода к первому слайду.
```csharp
static void Add_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Применить плавный переход
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```


## **Получить переход слайда**

Прочитайте тип перехода, в данный момент назначенный слайду.
```csharp
static void Access_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.SlideShowTransition.Type = TransitionType.Push;

    // Доступ к типу перехода
    var type = slide.SlideShowTransition.Type;
}
```


## **Удалить переход слайда**

Очистите любой эффект перехода, установив тип в `None`.
```csharp
static void Remove_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.SlideShowTransition.Type = TransitionType.Fade;

    // Удалить переход, установив None
    slide.SlideShowTransition.Type = TransitionType.None;
}
```


## **Установить длительность перехода**

Укажите, как долго слайд будет отображаться перед автоматическим переходом.
```csharp
static void Set_Transition_Duration()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // в миллисекундах
}
```
