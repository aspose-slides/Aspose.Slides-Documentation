---
title: Εισαγωγή παρουσιάσεων από PDF ή HTML σε JavaScript
linktitle: Εισαγωγή παρουσίασης
type: docs
weight: 60
url: /el/nodejs-java/import-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Εισαγωγή εγγράφων PDF και HTML σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για Node.js, για απρόσκοπτη, υψηλής απόδοσης επεξεργασία διαφανειών."
---
## **Εισαγωγή**

Χρησιμοποιώντας [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/el/nodejs-java/), μπορείτε να εισάγετε παρουσιάσεις από αρχεία σε άλλες μορφές. Το Aspose.Slides παρέχει την κλάση [SlideCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidecollection/) ώστε να μπορείτε να εισάγετε παρουσιάσεις από PDF, έγγραφα HTML κ.λπ.

## **Εισαγωγή PowerPoint από PDF**

Σε αυτή την περίπτωση, μπορείτε να μετατρέψετε ένα PDF σε παρουσίαση PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/).
2. Κλήστε τη μέθοδο [addFromPdf()](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) και περάστε το αρχείο PDF.
3. Χρησιμοποιήστε τη μέθοδο [save()](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) για να αποθηκεύσετε το αρχείο σε μορφή PowerPoint.

Αυτός ο κώδικας JavaScript δείχνει τη λειτουργία μετατροπής PDF σε PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert  title="Tip" color="primary" %}} 
Μπορεί να θέλετε να δοκιμάσετε την δωρεάν εφαρμογή **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/el/import/pdf-to-powerpoint) web app, καθώς αποτελεί ζωντανή υλοποίηση της διαδικασίας που περιγράφεται εδώ. 
{{% /alert %}} 

## **Εισαγωγή PowerPoint από HTML**

Σε αυτή την περίπτωση, μπορείτε να μετατρέψετε ένα έγγραφο HTML σε παρουσίαση PowerPoint.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/).
2. Κλήστε τη μέθοδο [addFromHtml()](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) και περάστε το αρχείο HTML.
3. Χρησιμοποιήστε τη μέθοδο [save()](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) για να αποθηκεύσετε το αρχείο σε μορφή PowerPoint.

Αυτός ο κώδικας JavaScript δείχνει τη λειτουργία μετατροπής HTML σε PowerPoint:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var htmlStream = java.newInstanceSync("java.io.FileInputStream", "page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) {
            htmlStream.close();
        }
    }
    presentation.save("MyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {
    console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Συχνές ερωτήσεις**

**Διατηρούνται οι πίνακες κατά την εισαγωγή ενός PDF, και μπορεί να βελτιωθεί η ανίχνευσή τους;**

Οι πίνακες μπορούν να ανιχνευθούν κατά την εισαγωγή· το [PdfImportOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pdfimportoptions/) περιλαμβάνει τη μέθοδο [setDetectTables](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pdfimportoptions/#setDetectTables) που ενεργοποιεί την αναγνώριση πινάκων. Η αποτελεσματικότητα εξαρτάται από τη δομή του PDF.