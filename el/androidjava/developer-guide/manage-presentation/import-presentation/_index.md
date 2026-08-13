---
title: Εισαγωγή παρουσιάσεων από PDF ή HTML στο Android
linktitle: Εισαγωγή παρουσίασης
type: docs
weight: 60
url: /el/androidjava/import-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Εισαγωγή εγγράφων PDF και HTML σε παρουσιάσεις PowerPoint και OpenDocument σε Java με το Aspose.Slides for Android για αδιάλειπτη, υψηλής απόδοσης επεξεργασία διαφανειών."
---
## **Εισαγωγή**

Χρησιμοποιώντας [**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/el/androidjava/), μπορείτε να εισαγάγετε παρουσιάσεις από αρχεία σε άλλες μορφές. Το Aspose.Slides παρέχει την κλάση [SlideCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slidecollection/) ώστε να μπορείτε να εισαγάγετε παρουσιάσεις από PDF, έγγραφα HTML κ.λπ.

## **Εισαγωγή PowerPoint από PDF**

Σε αυτή την περίπτωση, μπορείτε να μετατρέψετε ένα PDF σε παρουσίαση PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/).
2. Καλέστε τη μέθοδο [addFromPdf()](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) και περάστε το αρχείο PDF.
3. Χρησιμοποιήστε τη μέθοδο [save()](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) για να αποθηκεύσετε το αρχείο στη μορφή PowerPoint.

Αυτός ο κώδικας Java δείχνει τη λειτουργία μετατροπής PDF σε PowerPoint:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="Tip" color="info" %}} 
Ίσως θελήσετε να δοκιμάσετε την δωρεάν εφαρμογή ιστού **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/el/import/pdf-to-powerpoint) επειδή αποτελεί ζωντανή υλοποίηση της διαδικασίας που περιγράφεται εδώ. 
{{% /alert %}} 

## **Εισαγωγή PowerPoint από HTML**

Σε αυτή την περίπτωση, μπορείτε να μετατρέψετε ένα έγγραφο HTML σε παρουσίαση PowerPoint.

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/).
2. Καλέστε τη μέθοδο [addFromHtml()](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) και περάστε μια ροή με το έγγραφο HTML.
3. Χρησιμοποιήστε τη μέθοδο [save()](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) για να αποθηκεύσετε το αρχείο στη μορφή PowerPoint.

Αυτός ο κώδικας Java δείχνει τη λειτουργία μετατροπής HTML σε PowerPoint: 

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

Presentation presentation = new Presentation();
try {
    FileInputStream htmlStream = new FileInputStream("page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) htmlStream.close();
    }

    presentation.save("MyPresentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

### Διατηρούνται οι πίνακες κατά την εισαγωγή PDF, και μπορεί να βελτιωθεί η ανίχνευσή τους;

Οι πίνακες μπορούν να εντοπιστούν κατά την εισαγωγή· το [PdfImportOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pdfimportoptions/) περιλαμβάνει μια μέθοδο [setDetectTables](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) που ενεργοποιεί την αναγνώριση πινάκων. Η αποτελεσματικότητα εξαρτάται από τη δομή του PDF.