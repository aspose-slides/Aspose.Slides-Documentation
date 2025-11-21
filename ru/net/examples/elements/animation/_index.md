---
title: Анимация
type: docs
weight: 100
url: /ru/net/examples/elements/animation/
keywords:
- пример анимации
- добавить анимацию
- доступ к анимации
- удалить анимацию
- последовательность анимации
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Мастер анимаций слайдов на C# с использованием Aspose.Slides: добавляйте, редактируйте и удаляйте эффекты, тайминг и триггеры, чтобы создавать динамические презентации в PPT, PPTX и ODP."
---

Показывает, как создавать простые анимации и управлять их последовательностью с помощью **Aspose.Slides for .NET**.

## Добавить анимацию

Создайте прямоугольную фигуру и примените эффект fade-in, запускаемый при щелчке.
```csharp
static void Add_Animation()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // Эффект появления
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}
```


## Доступ к анимации

Получите первый эффект анимации из временной шкалы слайда.
```csharp
static void Access_Animation()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.Bottom, EffectTriggerType.OnClick);

    // Получить первый эффект анимации
    var effect = slide.Timeline.MainSequence[0];
}
```


## Удалить анимацию

Удалите эффект анимации из последовательности.
```csharp
static void Remove_Animation()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.Bottom, EffectTriggerType.OnClick);

    // Удалить эффект
    slide.Timeline.MainSequence.Remove(effect);
}
```


## Последовательность анимаций

Добавьте несколько эффектов и продемонстрируйте порядок их выполнения.
```csharp
static void Sequence_Animations()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 200, 50, 100, 100);

    var seq = slide.Timeline.MainSequence;
    seq.AddEffect(shape1, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
    seq.AddEffect(shape2, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}
```
