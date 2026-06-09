---
title: Διαφάνεια
type: docs
weight: 10
url: /el/net/examples/elements/slide/
keywords:
- διαφάνεια
- προσθήκη διαφάνειας
- πρόσβαση σε διαφάνεια
- δείκτης διαφάνειας
- κλωνοποίηση διαφάνειας
- αναδιάταξη διαφανειών
- αφαίρεση διαφάνειας
- παράδειγμα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Έλεγχος διαφανειών στο Aspose.Slides για .NET: δημιουργία, κλωνοποίηση, αναδιάταξη, αλλαγή μεγέθους, ορισμός φόντων και εφαρμογή μεταβάσεων με C# για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο παρέχει μια σειρά παραδειγμάτων που δείχνουν πώς να εργάζεστε με διαφάνειες χρησιμοποιώντας **Aspose.Slides for .NET**. Θα μάθετε πώς να προσθέτετε, να προσπελάτε, να κλωνοποιείτε, να αναδιατάσσετε και να αφαιρείτε διαφάνειες χρησιμοποιώντας την κλάση `Presentation`.

Κάθε παράδειγμα παρακάτω περιλαμβάνει μια σύντομη εξήγηση, ακολουθούμενη από αποσπάσματα κώδικα σε C#.

## **Προσθήκη διαφάνειας**

Για να προσθέσετε μια νέα διαφάνεια, πρέπει πρώτα να επιλέξετε μια διάταξη. Σε αυτό το παράδειγμα, χρησιμοποιούμε τη διάταξη `Blank` και προσθέτουμε μια κενή διαφάνεια στην παρουσίαση.

```csharp
static void AddSlide()
{
    using var presentation = new Presentation();

    // Κάθε διαφάνεια βασίζεται σε μια διάταξη, η οποία με τη σειρά της βασίζεται σε μια κύρια διαφάνεια.
    // Χρησιμοποιήστε τη διάταξη Blank για να δημιουργήσετε μια νέα διαφάνεια.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Προσθέστε μια νέα κενή διαφάνεια χρησιμοποιώντας την επιλεγμένη διάταξη.
    presentation.Slides.AddEmptySlide(layout: blankLayout);
}
```

> 💡 **Σημείωση:** Κάθε διάταξη διαφάνειας προέρχεται από μια κύρια διαφάνεια, η οποία ορίζει το συνολικό σχεδιασμό και τη δομή των δεσμευτικών θέσεων. Η εικόνα παρακάτω απεικονίζει πώς οργανώνονται οι κύριες διαφάνειες και οι σχετικές διατάξεις τους στο PowerPoint.

![Σχέση κύριας διαφάνειας και διάταξης](master-layout-slide.png)

## **Πρόσβαση σε διαφάνειες κατά δείκτη**

Μπορείτε να προσπελάσετε διαφάνειες χρησιμοποιώντας τον δείκτη τους ή να βρείτε τον δείκτη μιας διαφάνειας με βάση μια αναφορά. Αυτό είναι χρήσιμο για επανάληψη ή τροποποίηση συγκεκριμένων διαφανειών.

```csharp
static void AccessSlide()
{
    // Από προεπιλογή, μια παρουσίαση δημιουργείται με μία κενή διαφάνεια.
    using var presentation = new Presentation();

    // Προσθέστε άλλη μία κενή διαφάνεια.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Πρόσβαση σε διαφάνειες κατά δείκτη.
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides[1];

    // Λάβετε τον δείκτη της διαφάνειας από μια αναφορά, έπειτα προσπελάστε την κατά δείκτη.
    var secondSlideIndex = presentation.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = presentation.Slides[secondSlideIndex];
}
```

## **Κλωνοποίηση διαφάνειας**

Αυτό το παράδειγμα δείχνει πώς να κλωνοποιήσετε μια υπάρχουσα διαφάνεια. Η κλωνοποιημένη διαφάνεια προστίθεται αυτόματα στο τέλος της συλλογής διαφανειών.

```csharp
static void CloneSlide()
{
    // Από προεπιλογή, η παρουσίαση περιέχει μία κενή διαφάνεια.
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Κλωνοποιήστε την πρώτη διαφάνεια; θα προστεθεί στο τέλος της παρουσίασης.
    var clonedSlide = presentation.Slides.AddClone(sourceSlide: firstSlide);

    // Ο δείκτης της κλωνοποιημένης διαφάνειας είναι 1 (η δεύτερη διαφάνεια στην παρουσίαση).
    var clonedSlideIndex = presentation.Slides.IndexOf(clonedSlide);
}
```

## **Αναδιάταξη διαφανειών**

Μπορείτε να αλλάξετε τη σειρά των διαφανειών μετακινώντας μία σε νέο δείκτη. Σε αυτήν την περίπτωση, μετακινούμε μια κλωνοποιημένη διαφάνεια στην πρώτη θέση.

```csharp
static void ReorderSlide()
{
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Προσθέστε ένα κλώνο της πρώτης διαφάνειας (δημιουργήθηκε από προεπιλογή).
    var clonedSlide = presentation.Slides.AddClone(firstSlide);

    // Μετακινήστε τη κλωνοποιημένη διαφάνεια στην πρώτη θέση (οι άλλες μετακινούνται προς τα κάτω).
    presentation.Slides.Reorder(index: 0, clonedSlide);
}
```

## **Αφαίρεση διαφάνειας**

Για να αφαιρέσετε μια διαφάνεια, απλώς αναφορθείτε σε αυτήν και καλέστε `Remove`. Αυτό το παράδειγμα προσθέτει μια δεύτερη διαφάνεια και στη συνέχεια αφαιρεί την αρχική, αφήνοντας μόνο τη νέα.

```csharp
static void RemoveSlide()
{
    using var presentation = new Presentation();

    // Προσθέστε μια νέα κενή διαφάνεια επιπλέον της προεπιλεγμένης πρώτης διαφάνειας.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    var secondSlide = presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Αφαιρέστε την πρώτη διαφάνεια· θα παραμείνει μόνο η νεοσχεδιασμένη διαφάνεια.
    var firstSlide = presentation.Slides[0];
    presentation.Slides.Remove(firstSlide);
}
```