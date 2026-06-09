---
title: Διάταξη διαφάνειας
type: docs
weight: 20
url: /el/net/examples/elements/layout-slide/
keywords:
- διάταξη διαφάνειας
- προσθήκη διάταξης διαφάνειας
- πρόσβαση σε διάταξη διαφάνειας
- αφαίρεση διάταξης διαφάνειας
- αχρησιμοποίητη διάταξη διαφάνειας
- κλωνοποίηση διάταξης διαφάνειας
- παράδειγμα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Κύριες διαφάνειες διάταξης στο Aspose.Slides για .NET: επιλέξτε, εφαρμόστε και προσαρμόστε διατάξεις διαφάνειας, σύμβολα κράτησης θέσης και κύριες διαφάνειες με παραδείγματα C# για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο παρουσιάζει πώς να εργάζεστε με **Layout Slides** στο Aspose.Slides για .NET. Μια διαφάνεια διάταξης καθορίζει το σχεδιαστικό και μορφοποίηση που κληρονομείται από τις κανονικές διαφάνειες. Μπορείτε να προσθέσετε, να έχετε πρόσβαση, να κλωνοποιήσετε και να αφαιρέσετε διαφάνειες διάταξης, καθώς και να καθαρίσετε τις αχρησιμοποίητες για να μειώσετε το μέγεθος της παρουσίασης.

## **Προσθήκη διαφάνειας διάταξης**

Μπορείτε να δημιουργήσετε μια προσαρμοσμένη διαφάνεια διάταξης για να ορίσετε επαναχρησιμοποιήσιμη μορφοποίηση. Για παράδειγμα, μπορείτε να προσθέσετε ένα πλαίσιο κειμένου που εμφανίζεται σε όλες τις διαφάνειες που χρησιμοποιούν αυτή τη διάταξη.

```csharp
static void AddLayoutSlide()
{
    using var presentation = new Presentation();
    
    var masterSlide = presentation.Masters[0];

    // Δημιουργήστε μια διαφάνεια διάταξης με κενό τύπο διάταξης και προσαρμοσμένο όνομα.
    var layoutSlide = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.Blank, "Main layout");

    // Προσθέστε ένα πλαίσιο κειμένου στη διαφάνεια διάταξης.
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // Προσθέστε δύο διαφάνειες χρησιμοποιώντας αυτή τη διάταξη· και οι δύο θα κληρονομήσουν το κείμενο από τη διάταξη.
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
}
```

> 💡 **Σημείωση 1:** Οι διαφάνειες διάταξης λειτουργούν ως πρότυπα για μεμονωμένες διαφάνειες. Μπορείτε να ορίσετε κοινά στοιχεία μία φορά και να τα επαναχρησιμοποιήσετε σε πολλές διαφάνειες.
> 💡 **Σημείωση 2:** Όταν προσθέτετε σχήματα ή κείμενο σε μια διαφάνεια διάταξης, όλες οι διαφάνειες που βασίζονται σε αυτή τη διάταξη θα εμφανίζουν αυτό το κοινό περιεχόμενο αυτόματα.
> Η εικόνα παρακάτω δείχνει δύο διαφάνειες, η κάθε μια κληρονομεί ένα πλαίσιο κειμένου από την ίδια διαφάνεια διάταξης.

![Διαφάνειες που κληρονομούν περιεχόμενο διάταξης](layout-slide-result.png)

## **Πρόσβαση σε διαφάνεια διάταξης**

Μπορείτε να έχετε πρόσβαση σε διαφάνειες διάταξης με δείκτη ή με τύπο διάταξης (π.χ., `Blank`, `Title`, `SectionHeader`, κ.λπ.).

```csharp
static void AccessLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Πρόσβαση σε διαφάνεια διάταξης με δείκτη.
    var firstLayoutSlide = presentation.LayoutSlides[0];
    
    // Πρόσβαση σε διαφάνεια διάταξης με τύπο.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## **Αφαίρεση διαφάνειας διάταξης**

Μπορείτε να αφαιρέσετε μια συγκεκριμένη διαφάνεια διάταξης αν δεν χρειάζεται πλέον.

```csharp
static void RemoveLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Λάβετε μια διαφάνεια διάταξης με τύπο και αφαιρέστε την.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Custom);
    presentation.LayoutSlides.Remove(blankLayoutSlide);
}
```

## **Αφαίρεση αχρησιμοποίητων διαφάνειων διάταξης**

Για να μειώσετε το μέγεθος της παρουσίασης, μπορεί να θέλετε να αφαιρέσετε διαφάνειες διάταξης που δεν χρησιμοποιούνται από καμία κανονική διαφάνεια.

```csharp
static void RemoveUnusedLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Αφαιρεί αυτόματα όλες τις διαφάνειες διάταξης που δεν αναφέρονται από καμία διαφάνεια.
    presentation.LayoutSlides.RemoveUnused();
}
```

## **Κλωνοποίηση διαφάνειας διάταξης**

Μπορείτε να δημιουργήσετε αντίγραφο μιας διαφάνειας διάταξης χρησιμοποιώντας τη μέθοδο `AddClone`.

```csharp
static void CloneLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Λάβετε μια υπάρχουσα διαφάνεια διάταξης με τύπο.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // Κλωνοποιήστε τη διαφάνεια διάταξης στο τέλος της συλλογής διαφάνειων διάταξης.
    var clonedLayoutSlide = presentation.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **Σύνοψη:** Οι διαφάνειες διάταξης είναι ισχυρά εργαλεία για τη διαχείριση συνεπούς μορφοποίησης σε όλες τις διαφάνειες. Το Aspose.Slides παρέχει πλήρη έλεγχο στη δημιουργία, τη διαχείριση και τη βελτιστοποίηση των διαφάνειων διάταξης.