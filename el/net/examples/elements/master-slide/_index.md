---  
title: Κύρια διαφάνεια  
type: docs  
weight: 30  
url: /el/net/examples/elements/master-slide/  
keywords:  
- κύρια διαφάνεια  
- προσθήκη κύριας διαφάνειας  
- πρόσβαση σε κύρια διαφάνεια  
- αφαίρεση κύριας διαφάνειας  
- αχρησιμοποίητη κύρια διαφάνεια  
- παράδειγμα κώδικα  
- PowerPoint  
- OpenDocument  
- παρουσίαση  
- .NET  
- C#  
- Aspose.Slides  
description: "Εξερευνήστε παραδείγματα κύριων διαφανειών Aspose.Slides για .NET: δημιουργία, επεξεργασία και στυλιζάρισμα κυρίων, placeholders και θεμάτων σε PPT, PPTX και ODP με σαφή κώδικα C#."  
---
Οι κύριες διαφάνειες βρίσκονται στο υψηλότερο επίπεδο της ιεραρχίας κληρονομικότητας διαφανειών στο PowerPoint. Μια **κύρια διαφάνεια** ορίζει κοινά στοιχεία σχεδιασμού όπως φόντα, λογότυπα και μορφοποίηση κειμένου. Οι **διαφάνειες διάταξης** κληρονομούν από τις κύριες διαφάνειες και οι **κανονικές διαφάνειες** κληρονομούν από τις διαφάνειες διάταξης.

Αυτό το άρθρο δείχνει πώς να δημιουργήσετε, να τροποποιήσετε και να διαχειριστείτε κύριες διαφάνειες χρησιμοποιώντας το Aspose.Slides για .NET.

## **Προσθήκη κύριας διαφάνειας**

Αυτό το παράδειγμα δείχνει πώς να δημιουργήσετε μια νέα κύρια διαφάνεια κλωνοποιώντας την προεπιλεγμένη. Στη συνέχεια προσθέτει μια διαφήμιση με το όνομα της εταιρείας σε όλες τις διαφάνειες μέσω της κληρονομικότητας διάταξης.

```csharp
static void AddMasterSlide()
{
    using var presentation = new Presentation();

    // Κλωνοποιήστε την προεπιλεγμένη κύρια διαφάνεια.
    var defaultMasterSlide = presentation.Masters[0];
    var newMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

    // Προσθέστε μια κάλυψη με το όνομα της εταιρείας στο επάνω μέρος της κύριας διαφάνειας.
    var textBox = newMasterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // Αναθέστε τη νέα κύρια διαφάνεια σε μια διαφάνεια διάταξης.
    var layoutSlide = presentation.LayoutSlides[0];
    layoutSlide.MasterSlide = newMasterSlide;

    // Αναθέστε τη διαφάνεια διάταξης στην πρώτη διαφάνεια της παρουσίασης.
    presentation.Slides[0].LayoutSlide = layoutSlide;
}
```

> 💡 **Σημείωση 1:** Οι κύριες διαφάνειες παρέχουν έναν τρόπο να εφαρμόζετε συνεπές branding ή κοινά στοιχεία σχεδιασμού σε όλες τις διαφάνειες. Οποιαδήποτε αλλαγή γίνει στην κύρια διαφάνεια θα αντικατοπτριστεί αυτόματα στις εξαρτημένες διαφάνειες διάταξης και τις κανονικές διαφάνειες.

> 💡 **Σημείωση 2:** Οποιοδήποτε σχήμα ή μορφοποίηση προστεθεί σε μια κύρια διαφάνεια κληρονομείται από τις διαφάνειες διάταξης και, με τη σειρά τους, από όλες τις κανονικές διαφάνειες που χρησιμοποιούν αυτές τις διατάξεις.  
> Η εικόνα παρακάτω δείχνει πώς ένα πλαίσιο κειμένου που προστέθηκε σε μια κύρια διαφάνεια αποδίδεται αυτόματα στην τελική διαφάνεια.

![Παράδειγμα κληρονομικότητας κύριας διαφάνειας](master-slide-banner.png)

## **Πρόσβαση σε κύρια διαφάνεια**

Μπορείτε να αποκτήσετε πρόσβαση στις κύριες διαφάνειες χρησιμοποιώντας τη συλλογή `Presentation.Masters`. Δείτε πώς να τις ανακτήσετε και να εργαστείτε με αυτές:

```csharp
static void AccessMasterSlide()
{
    using var presentation = new Presentation();

    // Πρόσβαση στην πρώτη κύρια διαφάνεια.
    var firstMasterSlide = presentation.Masters[0];

    // Αλλαγή του τύπου του φόντου.
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## **Κατάργηση κύριας διαφάνειας**

Οι κύριες διαφάνειες μπορούν να αφαιρεθούν είτε με χρήση δείκτη είτε με αναφορά.

```csharp
static void RemoveMasterSlide()
{
    using var presentation = new Presentation("sample.pptx");

    // Αφαίρεση μιας κύριας διαφάνειας με δείκτη.
    presentation.Masters.RemoveAt(0);

    // Αφαίρεση μιας κύριας διαφάνειας με αναφορά.
    var firstMasterSlide = presentation.Masters[0];
    presentation.Masters.Remove(firstMasterSlide);
}
```

## **Κατάργηση αχρησιμοποίητων κύριων διαφανειών**

Κάποιες παρουσιάσεις περιέχουν κύριες διαφάνειες που δεν χρησιμοποιούνται. Η αφαίρεση αυτών των διαφανειών μπορεί να βοηθήσει στη μείωση του μεγέθους του αρχείου.

```csharp
static void RemoveUnusedMasterSlide()
{
    using var presentation = new Presentation();

    // Αφαίρεση όλων των αχρησιμοποίητων κύριων διαφανειών (ακόμη και εκείνων που είναι σημειωμένες ως Preserve).
    presentation.Masters.RemoveUnused(ignorePreserveField: true);
}
```