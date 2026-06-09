---
title: Εισαγωγή Παρουσιάσεων από PDF ή HTML σε PHP
linktitle: Εισαγωγή Παρουσίασης
type: docs
weight: 60
url: /el/php-java/import-presentation/
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
- PHP
- Aspose.Slides
description: "Εισαγάγετε έγγραφα PDF και HTML σε παρουσιάσεις PowerPoint και OpenDocument σε PHP με το Aspose.Slides για απρόσκοπτη, υψηλών επιδόσεων επεξεργασία διαφανειών."
---
## **Εισαγωγή**

Χρησιμοποιώντας [**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/el/php-java/), μπορείτε να εισάγετε παρουσιάσεις από αρχεία σε άλλες μορφές. Η Aspose.Slides παρέχει την κλάση [SlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidecollection/) για να σας επιτρέψει την εισαγωγή παρουσιάσεων από PDF, έγγραφα HTML, κλπ.

## **Εισαγωγή PowerPoint από PDF**

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/).
2. Καλέστε τη μέθοδο [addFromPdf()](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) και περάστε το αρχείο PDF.
3. Χρησιμοποιήστε τη μέθοδο [save()](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation#save-java.lang.String-int-) για να αποθηκεύσετε το αρχείο στη μορφή PowerPoint.

```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->addFromPdf("InputPDF.pdf");
    $pres->save("OutputPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert  title="Συμβουλή" color="primary" %}} 
Μπορείτε να θέλετε να δοκιμάσετε την **Aspose free** εφαρμογή ιστού [PDF to PowerPoint](https://products.aspose.app/slides/el/import/pdf-to-powerpoint) επειδή είναι μια ζωντανή υλοποίηση της διαδικασίας που περιγράφεται εδώ. 
{{% /alert %}} 

## **Εισαγωγή PowerPoint από HTML**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/).
2. Καλέστε τη μέθοδο [addFromHtml()](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) και περάστε το αρχείο PDF.
3. Χρησιμοποιήστε τη μέθοδο [save()](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation#save-java.lang.String-int-) για να αποθηκεύσετε το αρχείο στη μορφή PowerPoint.

```php
  $presentation = new Presentation();
  try {
    $htmlStream = new Java("java.io.FileInputStream", "page.html");
    try {
      $presentation->getSlides()->addFromHtml($htmlStream);
    } finally {
      if (!java_is_null($htmlStream)) {
        $htmlStream->close();
      }
    }
    $presentation->save("MyPresentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Συχνές ερωτήσεις**

**Διατηρούνται οι πίνακες κατά την εισαγωγή ενός PDF, και μπορεί να βελτιωθεί η ανίχνευσή τους;**

Οι πίνακες μπορούν να εντοπιστούν κατά την εισαγωγή· η κλάση [PdfImportOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/pdfimportoptions/) περιλαμβάνει τη μέθοδο [setDetectTables](https://reference.aspose.com/slides/el/php-java/aspose.slides/pdfimportoptions/#setDetectTables) που ενεργοποιεί την αναγνώριση πινάκων. Η αποτελεσματικότητα εξαρτάται από τη δομή του PDF.

{{% alert title="Σημείωση" color="warning" %}} 
Μπορείτε επίσης να χρησιμοποιήσετε το Aspose.Slides για να μετατρέψετε HTML σε άλλες δημοφιλείς μορφές αρχείων: 

* [HTML σε εικόνα](https://products.aspose.com/slides/el/php-java/conversion/html-to-image/)
* [HTML σε JPG](https://products.aspose.com/slides/el/php-java/conversion/html-to-jpg/)
* [HTML σε XML](https://products.aspose.com/slides/el/php-java/conversion/html-to-xml/)
* [HTML σε TIFF](https://products.aspose.com/slides/el/php-java/conversion/html-to-tiff/)

{{% /alert %}}