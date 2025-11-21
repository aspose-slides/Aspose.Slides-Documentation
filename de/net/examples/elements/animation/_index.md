---
title: Animation
type: docs
weight: 100
url: /de/net/examples/elements/animation/
keywords:
- Animationsbeispiel
- Animation hinzufügen
- Animation abrufen
- Animation entfernen
- Animationssequenz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Meistern Sie Folienanimationen in C# mit Aspose.Slides: Fügen Sie Effekte, Zeitsteuerungen und Trigger hinzu, bearbeiten und entfernen Sie sie, um dynamische Präsentationen in PPT, PPTX und ODP zu erstellen."
---

Zeigt, wie einfache Animationen erstellt und ihre Reihenfolge mit **Aspose.Slides for .NET** verwaltet werden.

## Animation hinzufügen

Erstellen Sie eine Rechteckform und wenden Sie einen Einblendeffekt an, der beim Klicken ausgelöst wird.
```csharp
static void Add_Animation()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // Einblendeffekt
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}
```


## Zugriff auf eine Animation

Rufen Sie den ersten Animationseffekt aus der Folienzeitachse ab.
```csharp
static void Access_Animation()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.Bottom, EffectTriggerType.OnClick);

    // Zugriff auf den ersten Animationseffekt
    var effect = slide.Timeline.MainSequence[0];
}
```


## Animation entfernen

Entfernen Sie einen Animationseffekt aus der Sequenz.
```csharp
static void Remove_Animation()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.Bottom, EffectTriggerType.OnClick);

    // Effekt entfernen
    slide.Timeline.MainSequence.Remove(effect);
}
```


## Animationen sequenzieren

Fügen Sie mehrere Effekte hinzu und zeigen Sie die Reihenfolge, in der die Animationen ablaufen.
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
