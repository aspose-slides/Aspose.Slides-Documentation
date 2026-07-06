---
title: Απόκτηση ορίων τμημάτων κειμένου από παρουσιάσεις σε .NET
linktitle: Όρια Τμήματος
type: docs
weight: 47
url: /el/net/portion-bounds/
keywords:
- όρια τμήματος κειμένου
- τμήμα κειμένου
- μέρος κειμένου
- συντεταγμένες κειμένου
- θέση κειμένου
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να ανακτήσετε τα όρια τμημάτων κειμένου σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για .NET."
---
## **Επισκόπηση**

Μία περιοχή κειμένου αντιπροσωπεύει ένα συγκεκριμένο απόσπασμα κειμένου μέσα σε μια παράγραφο και σας επιτρέπει να εργαστείτε με αυτό το απόσπασμα ανεξάρτητα από το περιεχόμενο γύρω του. Στην Aspose.Slides, οι περιοχές μπορούν να χρησιμοποιηθούν όταν χρειάζεται να ανακτήσετε τα όρια ενός αποσπάσματος κειμένου, να εφαρμόσετε μορφοποίηση μόνο σε μέρος μιας παραγράφου ή να ελέγξετε τη συμπεριφορά του κειμένου σε πιο λεπτομερές επίπεδο.

Αυτό το άρθρο δείχνει πώς να λάβετε το οριοθετημένο ορθογώνιο μιας περιοχής χρησιμοποιώντας [IPortion.GetRect](https://reference.aspose.com/slides/el/net/aspose.slides/iportion/getrect/). Επίσης δείχνει πώς να λάβετε τις συντεταγμένες της αρχής μιας περιοχής χρησιμοποιώντας [IPortion.GetCoordinates](https://reference.aspose.com/slides/el/net/aspose.slides/iportion/getcoordinates/). Επιπλέον, επισημαίνει κοινά σενάρια που σχετίζονται με τις περιοχές, όπως η προσθήκη υπερσυνδέσμου σε ένα μόνο απόσπασμα κειμένου, η κατανόηση του πώς η μορφοποίηση επιλύεται μέσω της περιοχής, της παραγράφου, του πλαισίου κειμένου και της κληρονομικότητας θέματος, καθώς και η αντιμετώπιση περιπτώσεων όπου η καθορισμένη γραμματοσειρά δεν είναι διαθέσιμη.

## **Λήψη ορίων μιας περιοχής κειμένου**

Χρησιμοποιήστε το [IPortion.GetRect](https://reference.aspose.com/slides/el/net/aspose.slides/iportion/getrect/) για να ανακτήσετε το οριοθετημένο ορθογώνιο μιας περιοχής κειμένου:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var rectangle = portion.GetRect();
        Console.WriteLine($"X = {rectangle.X}; Y = {rectangle.Y}; Width = {rectangle.Width}; Height = {rectangle.Height}");
    }
}
```

## **Λήψη συντεταγμένων μιας περιοχής κειμένου**

Χρησιμοποιήστε το [IPortion.GetCoordinates](https://reference.aspose.com/slides/el/net/aspose.slides/iportion/getcoordinates/) για να ανακτήσετε τις συντεταγμένες της αρχής μιας περιοχής κειμένου:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var point = portion.GetCoordinates();
        Console.WriteLine($"X = {point.X}; Y = {point.Y}");
    }
}
```

## **Συχνές ερωτήσεις**

**Μπορώ να εφαρμόσω υπερσύνδεσμο μόνο σε μέρος του κειμένου σε μία μόνο παράγραφο;**

Ναι, μπορείτε να [ορίσετε έναν υπερσύνδεσμο](/slides/el/net/manage-hyperlinks/) σε μια μεμονωμένη περιοχή· μόνο αυτό το απόσπασμα θα είναι κλικαρίσιμο, όχι ολόκληρη η παράγραφος.

**Πώς λειτουργεί η κληρονομικότητα στυλ: τι υπερισχύει από μια περιοχή και τι λαμβάνεται από μια παράγραφο ή ένα πλαίσιο κειμένου;**

Οι ιδιότητες σε επίπεδο περιοχής έχουν την υψηλότερη προτεραιότητα. Εάν μια ιδιότητα δεν έχει οριστεί στην [IPortion](https://reference.aspose.com/slides/el/net/aspose.slides/iportion/), η Aspose.Slides την λαμβάνει από την [IParagraph](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/). Εάν δεν έχει οριστεί εκεί επίσης, η Aspose.Slides χρησιμοποιεί το στυλ του [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/) ή του [theme](https://reference.aspose.com/slides/el/net/aspose.slides.theme/theme/).

**Τι συμβαίνει αν η γραμματοσειρά που έχει οριστεί για μια περιοχή λείπει από το μηχάνημα ή τον διακομιστή στόχο;**

[Οι κανόνες αντικατάστασης γραμματοσειρών](/slides/el/net/font-selection-sequence/) εφαρμόζονται. Το κείμενο μπορεί να επαναδιαταχθεί: οι μετρικές, η συλλαβοτομία και το πλάτος μπορεί να αλλάξουν, γεγονός που είναι σημαντικό για ακριβή τοποθέτηση.

**Μπορώ να ορίσω διαφάνεια γεμίσματος κειμένου ή διαβάθμιση ειδικά για μια περιοχή, ανεξάρτητα από το υπόλοιπο της παραγράφου;**

Ναι, το χρώμα κειμένου, το γέμισμα και η διαφάνεια σε επίπεδο [IPortion](https://reference.aspose.com/slides/el/net/aspose.slides/iportion/) μπορούν να διαφέρουν από τα γειτονικά αποσπάσματα.