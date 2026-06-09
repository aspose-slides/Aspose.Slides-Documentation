---
title: Μετάβαση διαφάνειας
type: docs
weight: 110
url: /el/net/examples/elements/slide-transition/
keywords:
- μετάβαση διαφάνειας
- προσθήκη μετάβασης διαφάνειας
- πρόσβαση σε μετάβαση διαφάνειας
- αφαίρεση μετάβασης διαφάνειας
- διάρκεια μετάβασης
- παράδειγμα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Αποκτήστε τον πλήρη έλεγχο των μεταβάσεων διαφάνειας στο Aspose.Slides for .NET: προσθήκη, προσαρμογή και αλληλουχία εφέ και χρονικών διαρκειών με παραδείγματα C# για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο παρουσιάζει την εφαρμογή εφέ μετάβασης διαφάνειας και χρονισμών με **Aspose.Slides for .NET**.

## **Προσθήκη Μετάβασης Διαφάνειας**

Εφαρμόστε εφέ μετάβασης fade στην πρώτη διαφάνεια.

```csharp
static void AddSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Εφαρμόστε μια μετάβαση fade.
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```

## **Πρόσβαση σε Μετάβαση Διαφάνειας**

Διαβάστε τον τύπο μετάβασης που έχει εκχωρηθεί αυτή τη στιγμή σε μια διαφάνεια.

```csharp
static void AccessSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Push;

    // Πρόσβαση στον τύπο μετάβασης.
    var type = slide.SlideShowTransition.Type;
}
```

## **Αφαίρεση Μετάβασης Διαφάνειας**

Καθαρίστε οποιοδήποτε εφέ μετάβασης ορίζοντας τον τύπο σε `None`.

```csharp
static void RemoveSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Fade;

    // Αφαιρέστε τη μετάβαση ορίζοντας none.
    slide.SlideShowTransition.Type = TransitionType.None;
}
```

## **Ορισμός Διάρκειας Μετάβασης**

Καθορίστε πόσο χρονικό διάστημα εμφανίζεται η διαφάνεια πριν προχωρήσει αυτόματα.

```csharp
static void SetTransitionDuration()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // σε χιλιοστά του δευτερολέπτου
}
```