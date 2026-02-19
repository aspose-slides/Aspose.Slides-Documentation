---
title: Анимация
type: docs
weight: 100
url: /ru/net/examples/elements/animation/
keywords:
- анимация
- добавить анимацию
- доступ к анимации
- удалить анимацию
- последовательность анимаций
- пример кода
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Изучите примеры анимации Aspose.Slides для .NET: добавление, последовательность и настройку эффектов и переходов с помощью C# для презентаций PPT, PPTX и ODP."
---
В этой статье демонстрируется, как создавать простые анимации и управлять их последовательностью с помощью **Aspose.Slides for .NET**.

## **Add an Animation**
Создайте прямоугольную форму и примените эффект затухания, вызываемый при щелчке.

```csharp
static void AddAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // Эффект затухания.
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
}
```

## **Access an Animation**
Получите первый анимационный эффект из временной шкалы слайда.

```csharp
static void AccessAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Получить первый эффект анимации.
    var effect = slide.Timeline.MainSequence[0];
}
```

## **Remove an Animation**
Удалите анимационный эффект из последовательности.

```csharp
static void RemoveAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Удалить эффект.
    slide.Timeline.MainSequence.Remove(effect);
}
```

## **Sequence Animations**
Добавьте несколько эффектов и продемонстрируйте порядок их выполнения.

```csharp
static void SequenceAnimations()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 200, 50, 100, 100);

    var sequence = slide.Timeline.MainSequence;
    sequence.AddEffect(shape1, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
    sequence.AddEffect(shape2, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}
```