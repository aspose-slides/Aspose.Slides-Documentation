---
title: Εισαγωγή Παρουσιάσεων από PDF ή HTML σε .NET
linktitle: Εισαγωγή Παρουσίασης
type: docs
weight: 60
url: /el/net/import-presentation/
keywords:
- εισαγωγή παρουσίασης
- εισαγωγή διαφάνειας
- εισαγωγή PDF
- εισαγωγή HTML
- PDF σε παρουσίαση
- PDF σε PPT
- PDF σε PPTX
- PDF σε ODP
- HTML σε παρουσίαση
- HTML σε PPT
- HTML σε PPTX
- HTML σε ODP
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Εισάγετε εύκολα έγγραφα PDF και HTML σε παρουσιάσεις PowerPoint και OpenDocument σε .NET με το Aspose.Slides για αδιάκοπη, υψηλής απόδοσης επεξεργασία διαφανειών."
---
## **Εισαγωγή**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να εισάγετε παρουσιάσεις από αρχεία σε άλλες μορφές. Το Aspose.Slides παρέχει την κλάση [SlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/slidecollection/) που σας επιτρέπει να εισάγετε παρουσιάσεις από έγγραφα PDF και HTML.

## **Εισαγωγή PowerPoint από PDF**

Σε αυτήν την περίπτωση, θα μετατρέψετε ένα PDF σε παρουσίαση PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/). 
2. Καλέστε τη μέθοδο [AddFromPdf](https://reference.aspose.com/slides/el/net/aspose.slides.slidecollection/addfrompdf/methods/1) και περάστε το αρχείο PDF. 
3. Χρησιμοποιήστε τη μέθοδο [Save](https://reference.aspose.com/slides/el/net/aspose.slides.presentation/save/methods/5) για να αποθηκεύσετε το αρχείο σε μορφή PowerPoint.

Αυτός ο κώδικας C# δείχνει τη λειτουργία μετατροπής PDF σε PowerPoint:

```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="TIP" color="primary" %}} 
Ίσως θελήσετε να δοκιμάσετε την δωρεάν εφαρμογή **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/el/import/pdf-to-powerpoint) επειδή είναι μια ζωντανή υλοποίηση της διαδικασίας που περιγράφεται εδώ. 
{{% /alert %}} 

## **Εισαγωγή PowerPoint από HTML**

Σε αυτήν την περίπτωση, θα μετατρέψετε ένα έγγραφο HTML σε παρουσίαση PowerPoint.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) . 
2. Καλέστε τη μέθοδο [AddFromHtml](https://reference.aspose.com/slides/el/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) και περάστε το αρχείο HTML. 
3. Χρησιμοποιήστε τη μέθοδο [Save](https://apireference.aspose.com/slides/el/net/aspose.slides.presentation/save/methods/5) για να αποθηκεύσετε το αρχείο ως έγγραφο PowerPoint.

Αυτός ο κώδικας C# δείχνει τη λειτουργία μετατροπής HTML σε PowerPoint: 

```c#
using (var presentation = new Presentation())
{
    using (var htmlStream = File.OpenRead("page.html"))
    {
        presentation.Slides.AddFromHtml(htmlStream);
    }

    presentation.Save("MyPresentation.pptx", SaveFormat.Pptx);
}
```

## **Συχνές ερωτήσεις**

**Διατηρούνται οι πίνακες κατά την εισαγωγή PDF και μπορεί να βελτιωθεί η ανίχνευσή τους;**

Οι πίνακες μπορούν να εντοπιστούν κατά την εισαγωγή· το [PdfImportOptions](https://reference.aspose.com/slides/el/net/aspose.slides.import/pdfimportoptions/) περιλαμβάνει την παράμετρο [DetectTables](https://reference.aspose.com/slides/el/net/aspose.slides.import/pdfimportoptions/detecttables/) που ενεργοποιεί την αναγνώριση πινάκων. Η αποτελεσματικότητα εξαρτάται από τη δομή του PDF.

{{% alert title="Note" color="warning" %}} 
Μπορείτε επίσης να χρησιμοποιήσετε το Aspose.Slides για να μετατρέψετε HTML σε άλλες δημοφιλείς μορφές αρχείων: 

* [HTML σε εικόνα](https://products.aspose.com/slides/el/net/conversion/html-to-image/)
* [HTML σε JPG](https://products.aspose.com/slides/el/net/conversion/html-to-jpg/)
* [HTML σε XML](https://products.aspose.com/slides/el/net/conversion/html-to-xml/)
* [HTML σε TIFF](https://products.aspose.com/slides/el/net/conversion/html-to-tiff/)

{{% /alert %}}