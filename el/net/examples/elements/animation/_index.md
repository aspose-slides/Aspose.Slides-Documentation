---
title: Κίνηση
type: docs
weight: 100
url: /el/net/examples/elements/animation/
keywords:
- κίνηση
- προσθήκη κίνησης
- πρόσβαση κίνησης
- αφαίρεση κίνησης
- ακολουθία κίνησης
- παράδειγμα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Εξερευνήστε παραδείγματα κίνησης του Aspose.Slides for .NET: προσθήκη, ακολουθία και προσαρμογή εφέ και μεταβάσεων με C# για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να δημιουργήσετε απλές κινούμενες εικόνες και να διαχειριστείτε την ακολουθία τους χρησιμοποιώντας **Aspose.Slides for .NET**.

## **Προσθήκη animation**
Δημιουργήστε ένα σχήμα ορθογωνίου και εφαρμόστε ένα εφέ ξεθροΐσματος που ενεργοποιείται με κλικ.

```csharp
static void AddAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // Εφέ ξεθροΐσματος.
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
}
```

## **Πρόσβαση σε animation**
Ανακτήστε το πρώτο εφέ animation από τη χρονογραμμή της διαφάνειας.

```csharp
static void AccessAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Πρόσβαση στο πρώτο εφέ κίνησης.
    var effect = slide.Timeline.MainSequence[0];
}
```

## **Αφαίρεση animation**
Αφαιρέστε ένα εφέ animation από την ακολουθία.

```csharp
static void RemoveAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Αφαίρεση του εφέ.
    slide.Timeline.MainSequence.Remove(effect);
}
```

## **Ακολουθία animations**
Προσθέστε πολλαπλά εφέ και επιδείξτε τη σειρά με την οποία λαμβάνουν χώρα τα animation.

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