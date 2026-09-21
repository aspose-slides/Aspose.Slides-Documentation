---
title: Επεξεργασία εγγράφων PDF σε .NET
linktitle: Επεξεργασία PDF
type: docs
weight: 65
url: /el/net/edit-pdf/
keywords:
- επεξεργασία PDF
- αντικατάσταση κειμένου PDF
- PDF σε PPTX
- PPTX σε PDF
- .NET
- C#
- Aspose.Slides
description: "Επεξεργαστείτε έγγραφα PDF σε C# εισάγοντάς τα στο Aspose.Slides, αντικαθιστώντας το κείμενο και αποθηκεύοντας την τροποποιημένη παρουσίαση ξανά σε PDF."
---
## **Επισκόπηση**

Το Aspose.Slides for .NET σας επιτρέπει να επεξεργάζεστε περιεχόμενο PDF εισάγοντας τις σελίδες του ως διαφάνειες, τροποποιώντας την παρουσίαση και εξάγοντας την ξανά σε PDF. Αυτό το άρθρο δείχνει μια απλή αντικατάσταση κειμένου. Η παρουσίαση παραμένει στη μνήμη, έτσι η αποθήκευση ενός ενδιάμεσου αρχείου PPTX είναι προαιρετική.

## **Αντικατάσταση Κειμένου σε PDF**

Χρησιμοποιήστε [AddFromPdf](https://reference.aspose.com/slides/el/net/aspose.slides/slidecollection/addfrompdf/) για να εισάγετε τις σελίδες, [ReplaceText](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/replacetext/) για να ενημερώσετε το κείμενο και [Save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/save/) για να εξάγετε το αποτέλεσμα.

Το παρακάτω παράδειγμα υποθέτει ότι το `input.pdf` περιέχει τη λέξη «Draft» ως επεξεργάσιμο κείμενο μετά την εισαγωγή. Αντικαθιστά αυτή τη λέξη με «Final» και γράφει το `edited.pdf`. Η εκκαθάριση της αρχικής διαφάνειας πριν από την εισαγωγή αποτρέπει μια επιπλέον κενή σελίδα στο αποτέλεσμα. Η αναζήτηση ταιριάζει με ολόκληρες λέξεις με το ίδιο κεφαλαίο/μικρό γράμμα· το `null` σημαίνει ότι δεν απαιτείται κλήση επιστροφής αποτελέσματος.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Slides.RemoveAt(0);

presentation.Slides.AddFromPdf("input.pdf");

var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};
presentation.ReplaceText("Draft", "Final", searchOptions, null);

presentation.Save("edited.pdf", SaveFormat.Pdf);
```

Για περισσότερες επιλογές, δείτε [Αναζήτηση και Αντικατάσταση Κειμένου](/slides/el/net/search-and-replace-text/) και [Μετατροπή PowerPoint σε PDF](/slides/el/net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Η αντικατάσταση κειμένου λειτουργεί σε εισαχθέν κείμενο, όχι σε κείμενο μέσα σε σαρωμένες εικόνες. Η μετατροπή μπορεί να επηρεάσει τη διάταξη και τη μορφοποίηση, επομένως ελέγξτε το αποτέλεσμα, ειδικά όταν το κείμενο αντικατάστασης είναι μεγαλύτερο από το αρχικό.
{{% /alert %}}

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Χρειάζεται να αποθηκεύσω ένα αρχείο PPTX πριν εξάγω το PDF;**

Όχι. Μπορείτε να επεξεργαστείτε και να εξάγετε την ίδια παρουσίαση στη μνήμη. Αποθηκεύστε ένα αντίγραφο PPTX μόνο αν θέλετε επίσης να συνεχίσετε την επεξεργασία του στο PowerPoint· δείτε [Αποθήκευση Παρουσιάσεων](/slides/el/net/save-presentation/).

**Γιατί κάποιο κείμενο μπορεί να παραμείνει αμετάβλητο;**

Το παράδειγμα ταιριάζει με ολόκληρη τη λέξη «Draft» με ακριβή διάκριση κεφαλαίων/μικρών. Το κείμενο που εισάγεται ως εικόνα ή είναι χωρισμένο σε ξεχωριστά πλαίσια κειμένου δεν θα ταιριάξει απαραίτητα με την αναζήτηση. Ελέγξτε το εισαχθέν περιεχόμενο και προσαρμόστε την αναζήτηση για το έγγραφό σας.