---
title: Ομαδικό σχήμα
type: docs
weight: 170
url: /el/net/examples/elements/group-shape/
keywords:
- ομάδα
- προσθήκη ομαδικού σχήματος
- πρόσβαση σε ομαδικό σχήμα
- αφαίρεση ομαδικού σχήματος
- αποομαδοποίηση σχημάτων
- παράδειγμα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Διαχειριστείτε τα ομαδικά σχήματα στο Aspose.Slides για .NET: δημιουργήστε, ενσωματώστε, ευθυγραμμίστε, αναδιατάξτε και μορφοποιήστε ομαδικά σχήματα με παραδείγματα C# σε παρουσιάσεις PPT, PPTX και ODP."
---
Παραδείγματα δημιουργίας ομάδων σχημάτων, πρόσβασης σε αυτές, αποομαδοποίησης και αφαίρεσης χρησιμοποιώντας **Aspose.Slides for .NET**.

## **Προσθήκη ομάδας σχήματος**

Δημιουργήστε μια ομάδα που περιέχει δύο βασικά σχήματα.

```csharp
static void AddGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    group.Shapes.AddAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
}
```

## **Πρόσβαση σε ομάδα σχήματος**

Ανακτήστε το πρώτο σχήμα ομάδας από τη διαφάνεια.

```csharp
static void AccessGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    var firstGroup = slide.Shapes.OfType<IGroupShape>().First();
}
```

## **Αφαίρεση ομάδας σχήματος**

Διαγράψτε μια ομάδα σχήματος από τη διαφάνεια.

```csharp
static void RemoveGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```

## **Αποομαδοποίηση σχημάτων**

Μετακινήστε τα σχήματα εκτός του δοχείου της ομάδας.

```csharp
static void UngroupShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // Μετακινήστε το σχήμα εκτός της ομάδας.
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```