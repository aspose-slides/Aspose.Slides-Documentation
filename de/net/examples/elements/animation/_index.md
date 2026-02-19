---
title: Animation
type: docs
weight: 100
url: /de/net/examples/elements/animation/
keywords:
- Animation
- Animation hinzufügen
- Animation abrufen
- Animation entfernen
- Animationssequenz
- Codebeispiel
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie Animationsbeispiele von Aspose.Slides für .NET: Hinzufügen, Sequenzieren und Anpassen von Effekten und Übergängen mit C# für PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel demonstriert, wie man einfache Animationen erstellt und ihre Reihenfolge mit **Aspose.Slides for .NET** verwaltet.

## **Animation hinzufügen**

Erstellen Sie eine Rechteckform und wenden Sie einen Fade‑Effekt an, der beim Klicken ausgelöst wird.

```csharp
static void AddAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // Fade-Effekt.
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
}
```

## **Zugriff auf eine Animation**

Rufen Sie den ersten Animationseffekt aus der Folienzeitachse ab.

```csharp
static void AccessAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Greifen Sie auf den ersten Animationseffekt zu.
    var effect = slide.Timeline.MainSequence[0];
}
```

## **Animation entfernen**

Entfernen Sie einen Animationseffekt aus der Sequenz.

```csharp
static void RemoveAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Effekt entfernen.
    slide.Timeline.MainSequence.Remove(effect);
}
```

## **Animationen sequenzieren**

Fügen Sie mehrere Effekte hinzu und zeigen Sie die Reihenfolge, in der die Animationen ablaufen.

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