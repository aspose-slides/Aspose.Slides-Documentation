---
title: "Μετατροπή παρουσιάσεων PowerPoint σε XML με Java"
linktitle: "PowerPoint σε XML"
type: docs
weight: 145
url: /el/java/convert-powerpoint-to-xml/
keywords:
- "μετατροπή PowerPoint σε XML"
- "μετατροπή παρουσίασης σε XML"
- "PPT σε XML"
- "PPTX σε XML"
- "ODP σε XML"
- "Παρουσίαση PowerPoint XML"
- "SaveFormat.Xml"
- "αποθήκευση παρουσίασης ως XML"
- "εξαγωγή παρουσίασης σε XML"
- "ροή XML"
- "Java"
- "Aspose.Slides"
description: "Μετατρέψτε παρουσιάσεις PowerPoint και OpenDocument σε αρχεία ή ροές PowerPoint XML με Java χρησιμοποιώντας το Aspose.Slides for Java."
---
## **Επισκόπηση**

Το Aspose.Slides for Java μπορεί να μετατρέπει παρουσιάσεις PowerPoint στη μορφή PowerPoint XML Presentation. Η έξοδος XML είναι χρήσιμη όταν χρειάζεστε μια κειμενική αναπαράσταση για την επιθεώρηση της δομής της παρουσίασης, την αντιμετώπιση προβλημάτων των δημιουργημένων εγγράφων, τη σύγκριση της εξόδου σε αυτοματοποιημένες δοκιμές ή την ενσωμάτωση σε μια ροή εργασίας που καταναλώνει XML αντί για πακέτο παρουσίασης.

Χρησιμοποιήστε τη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#save-java.lang.String-int-) με την τιμή `Xml` από την κλάση [SaveFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/saveformat/). Μπορείτε να γράψετε το αποτέλεσμα απευθείας σε ένα αρχείο ή σε μια ροή.

{{% alert color="info" title="Σημείωση" %}}
`SaveFormat.Xml` δημιουργεί μια παρουσίαση PowerPoint XML. Δεν εξάγει τα ξεχωριστά μέρη Office Open XML που είναι αποθηκευμένα μέσα σε ένα πακέτο PPTX. Εάν χρειάζεστε τα ακριβή μέρη του πακέτου PPTX, όπως `ppt/presentation.xml` ή μεμονωμένα αρχεία XML διαφανειών, ελέγξτε το ίδιο το πακέτο PPTX.
{{% /alert %}}

## **Μετατροπή Παρουσίασης σε Αρχείο XML**

Φορτώστε μια παρουσίαση προέλευσης με την κλάση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) και στη συνέχεια περάστε τη διαδρομή εξόδου και το `SaveFormat.Xml` στη [Presentation.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Η προέλευση μπορεί να είναι οποιαδήποτε μορφή παρουσίασης που υποστηρίζεται για φόρτωση, όπως PPT, PPTX ή ODP.

Το ακόλουθο παράδειγμα μετατρέπει μια παρουσίαση PPTX σε αρχείο XML:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.xml", SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **Εγγραφή της Εξόδου XML σε Ροή**

Χρησιμοποιήστε την υπερφόρτωση ροής της [Presentation.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) όταν το XML πρέπει να παραμείνει στη μνήμη ή να περάσει σε άλλο στοιχείο, όπως μια υπηρεσία web, πάροχο αποθήκευσης ή γραμμή επεξεργασίας XML. Το παρακάτω παράδειγμα γράφει το αποτέλεσμα σε ένα [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) και λαμβάνει το παραγόμενο XML ως ένα σύνολο byte:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // Περάστε το xmlData στο επόμενο στοιχείο της ροής εργασίας.
} finally {
    presentation.dispose();
}
```

## **Σύγκριση XML με Μορφές Παρουσίασης και Εξαγωγής**

Επιλέξτε τη μορφή εξόδου ανάλογα με το πώς θα χρησιμοποιηθεί το αποτέλεσμα:

| Μορφή | Έξοδος | Τυπική χρήση |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Μια παρουσίαση PowerPoint XML. Εξέταση δομής, αντιμετώπιση προβλημάτων, σύγκριση παραγόμενης εξόδου και ενσωμάτωση με βάση το XML. | |
| PPT (`.ppt`) | Ένα παλιό δυαδικό αρχείο παρουσίασης. Συμβατότητα με παλαιότερες ροές εργασίας PowerPoint. | |
| PPTX (`.pptx`) | Ένα πακέτο Office Open XML που περιέχει πολλαπλά μέρη. Κανονική επεξεργασία PowerPoint και ανταλλαγή παρουσιάσεων. | |
| PDF ή TIFF | Σελίδες σταθερής διάταξης ή εικόνα πολλαπλών σελίδων. Προβολή, εκτύπωση και αρχειοθέτηση. | |
| PNG, JPEG ή SVG | Μια αποδιδόμενη αναπαράσταση μιας μεμονωμένης διαφάνειας. Μικρογραφίες, προεπισκοπήσεις και εικόνες περιουσιακών στοιχείων. | |
| HTML ή HTML5 | Έξοδος παρουσίασης προσανατολισμένη στο web. Προβολή σε πρόγραμμα περιήγησης και δημοσίευση στο web. | |

Σε αντίθεση με τα PPT και PPTX, η έξοδος XML προορίζεται κυρίως για επιθεώρηση και ροές εργασίας προσανατολισμένες στα δεδομένα. Σε αντίθεση με τα PDF, TIFF, HTML και μορφές εικόνας διαφανειών, αντιπροσωπεύει δεδομένα παρουσίασης αντί για απόδοση διαφανειών ως σελίδες ή οπτικά στοιχεία. Ο πίνακας [υποστηριζόμενων μορφών αρχείων](/slides/el/java/supported-file-formats/) παραθέτει κάθε μορφή που μπορεί να φορτώσει, εισάγει, αποθηκεύσει ή αποδώσει το Aspose.Slides.

## **Συχνές Ερωτήσεις**

**Είναι το `SaveFormat.Xml` το ίδιο με την αποθήκευση ενός αρχείου PPTX;**

Όχι. Το PPTX είναι ένα πακέτο που περιέχει πολλαπλά μέρη Office Open XML, ενώ το `SaveFormat.Xml` δημιουργεί ένα αρχείο PowerPoint XML Presentation.

**Μπορώ να αποθηκεύσω την έξοδο XML χωρίς να δημιουργήσω αρχείο στο δίσκο;**

Ναι. Περνέστε μια εγγράψιμη ροή στη [Presentation.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Για παράδειγμα, χρησιμοποιήστε ένα [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) για επεξεργασία στη μνήμη.

**Μπορεί το Aspose.Slides να φορτώσει ξανά το εξαγόμενο αρχείο XML;**

Ναι. Περνέστε το αρχείο XML ή μια ροή στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#Presentation-java.lang.String-). Η [Presentation.getSourceFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getSourceFormat--) επιστρέφει τότε το `SourceFormat.Xml`. Η [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) αναφέρει `LoadFormat.Unknown` για αυτήν τη μορφή, οπότε μην τη χρησιμοποιείτε για να αποφασίσετε αν μπορεί να ανοιχτεί ένα αρχείο XML.

**Η μετατροπή XML αποδίδει κάθε διαφάνεια ως σελίδα ή εικόνα;**

Όχι. Η μετατροπή XML γράφει δομημένα δεδομένα παρουσίασης. Χρησιμοποιήστε PDF ή TIFF για έξοδο προσανατολισμένη σε σελίδες, ή PNG, JPEG και SVG για εικόνες μεμονωμένων διαφανειών.