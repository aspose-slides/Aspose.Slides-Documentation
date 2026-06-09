---
title: Μετατροπή παρουσιάσεων PowerPoint σε έγγραφα Word στο Android
linktitle: PowerPoint σε Word
type: docs
weight: 110
url: /el/androidjava/convert-powerpoint-to-word/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε Word
- παρουσίαση σε Word
- διαφάνεια σε Word
- PPT σε Word
- PPTX σε Word
- PowerPoint σε DOCX
- παρουσίαση σε DOCX
- διαφάνεια σε DOCX
- PPT σε DOCX
- PPTX σε DOCX
- PowerPoint σε DOC
- παρουσίαση σε DOC
- διαφάνεια σε DOC
- PPT σε DOC
- PPTX σε DOC
- αποθήκευση PPT ως DOCX
- αποθήκευση PPTX ως DOCX
- εξαγωγή PPT σε DOCX
- εξαγωγή PPTX σε DOCX
- Android
- Java
- Aspose.Slides
description: "Μετατρέψτε τις διαφάνειες PowerPoint PPT και PPTX σε επεξεργάσιμα έγγραφα Word σε Java χρησιμοποιώντας το Aspose.Slides για Android με ακριβή διάταξη, εικόνες και διατήρηση της μορφοποίησης."
---
## **Επισκόπηση**

Αυτό το άρθρο παρέχει μια λύση για προγραμματιστές σχετικά με τη μετατροπή παρουσιάσεων PowerPoint και OpenDocument σε έγγραφα Word χρησιμοποιώντας τα Aspose.Slides και Aspose.Words. Ο οδηγός βήμα-προς-βήμα σας οδηγεί μέσα από κάθε στάδιο της διαδικασίας μετατροπής.

## **Aspose.Slides και Aspose.Words**

Για να μετατρέψετε ένα αρχείο PowerPoint (PPTX ή PPT) σε Word (DOCX ή DOCX), χρειάζεστε και τα [Aspose.Slides για Android μέσω Java](https://products.aspose.com/slides/el/androidjava/) και [Aspose.Words για Android μέσω Java](https://products.aspose.com/words/android-java/).

Ως αυτόνομη API, το [Aspose.Slides](https://products.aspose.app/slides) για Java παρέχει λειτουργίες που επιτρέπουν την εξαγωγή κειμένου από παρουσιάσεις.

Το [Aspose.Words](https://docs.aspose.com/words/androidjava/) είναι μια προηγμένη API επεξεργασίας εγγράφων που επιτρέπει στις εφαρμογές να δημιουργούν, τροποποιούν, μετατρέπουν, αποδίδουν, εκτυπώνουν αρχεία και να εκτελούν άλλες εργασίες με έγγραφα χωρίς να χρησιμοποιούν το Microsoft Word.

## **Μετατροπή PowerPoint σε Word**

1. Κατεβάστε τις βιβλιοθήκες [Aspose.Slides για Android μέσω Java](https://downloads.aspose.com/slides/el/java) και [Aspose.Words για Java](https://downloads.aspose.com/words/java).
2. Προσθέστε τα *aspose-slides-x.x-jdk16.jar* και *aspose-words-x.x-jdk16.jar* στο CLASSPATH σας.
3. Χρησιμοποιήστε αυτό το απόσπασμα κώδικα για να μετατρέψετε το PowerPoint σε Word:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // δημιουργεί μια εικόνα διαφάνειας ως ροή byte array
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    // εισάγει τα κείμενα της διαφάνειας
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof AutoShape) {
            builder.writeln(((AutoShape) shape).getTextFrame().getText());
        }
    }

    builder.insertBreak(BreakType.PAGE_BREAK);
}

doc.save("output.docx");
pres.dispose();
```

## **Συχνές Ερωτήσεις**

**Ποια στοιχεία πρέπει να εγκατασταθούν για τη μετατροπή παρουσιάσεων PowerPoint και OpenDocument σε έγγραφα Word;**

Απαιτείται μόνο η προσθήκη του αντίστοιχου πακέτου για [Aspose.Slides για Android μέσω Java](https://releases.aspose.com/slides/el/androidjava/) και [Aspose.Words για Android μέσω Java](https://releases.aspose.com/words/androidjava/) στο έργο σας. Και οι δύο βιβλιοθήκες λειτουργούν ως αυτόνομες API και δεν απαιτείται η εγκατάσταση του Microsoft Office.

**Υποστηρίζονται όλοι οι τύποι παρουσιάσεων PowerPoint και OpenDocument;**

Το Aspose.Slides [υποστηρίζει όλους τους τύπους παρουσιάσεων](/slides/el/androidjava/supported-file-formats/), συμπεριλαμβανομένων των PPT, PPTX, ODP και άλλων κοινών τύπων αρχείων. Αυτό εξασφαλίζει ότι μπορείτε να εργαστείτε με παρουσιάσεις που δημιουργήθηκαν σε διάφορες εκδόσεις του Microsoft PowerPoint.