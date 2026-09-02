---
title: Μετατροπή PowerPoint Παρουσιάσεων σε XML σε Java
linktitle: PowerPoint σε XML
type: docs
weight: 145
url: /el/java/convert-powerpoint-to-xml/
keywords:
- μετατροπή PowerPoint σε XML
- μετατροπή παρουσίασης σε XML
- PPT σε XML
- PPTX σε XML
- ODP σε XML
- Παρουσίαση PowerPoint XML
- SaveFormat.Xml
- αποθήκευση παρουσίασης ως XML
- εξαγωγή παρουσίασης σε XML
- ροή XML
- Java
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις PowerPoint και OpenDocument σε αρχεία ή ροές PowerPoint XML σε Java με Aspose.Slides for Java."
---
## **Επισκόπηση**

Aspose.Slides for Java μπορεί να μετατρέπει παρουσιάσεις PowerPoint σε μορφή PowerPoint XML Presentation. Η έξοδος XML είναι χρήσιμη όταν χρειάζεστε μια κειμενική αναπαράσταση για την επιθεώρηση της δομής της παρουσίασης, την αντιμετώπιση προβλημάτων των παραγόμενων εγγράφων, τη σύγκριση της εξόδου σε αυτοματοποιημένες δοκιμές, ή την ενσωμάτωση με μια ροή εργασιών που καταναλώνει XML αντί για πακέτο παρουσίασης.

Χρησιμοποιήστε τη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#save-java.lang.String-int-) με την τιμή `Xml` από την κλάση [SaveFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/saveformat/). Μπορείτε να γράψετε το αποτέλεσμα απευθείας σε αρχείο ή σε ροή.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` δημιουργεί μια PowerPoint XML Presentation. Δεν εξάγει τα μεμονωμένα μέρη Office Open XML που αποθηκεύονται μέσα σε ένα πακέτο PPTX. Εάν χρειάζεστε τα ακριβή μέρη του πακέτου PPTX, όπως `ppt/presentation.xml` ή μεμονωμένα αρχεία XML διαφάνειας, επιθεωρήστε το ίδιο το πακέτο PPTX.
{{% /alert %}}

## **Μετατροπή παρουσίασης σε αρχείο XML**

Φορτώστε μια πηγαία παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/), και στη συνέχεια περάστε τη διαδρομή εξόδου και το `SaveFormat.Xml` στη [Presentation.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Η πηγή μπορεί να είναι οποιαδήποτε μορφή παρουσίασης που υποστηρίζεται για φόρτωση, όπως PPT, PPTX ή ODP.

Το παρακάτω παράδειγμα μετατρέπει μια παρουσίαση PPTX σε αρχείο XML:

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

## **Γράψτε την έξοδο XML σε ροή**

Χρησιμοποιήστε την υπερφόρτωση ροής της [Presentation.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) όταν το XML πρέπει να παραμείνει στη μνήμη ή να περαστεί σε άλλο στοιχείο, όπως μια υπηρεσία ιστού, πάροχο αποθήκευσης ή αγωγό επεξεργασίας XML. Το παρακάτω παράδειγμα γράφει το αποτέλεσμα σε ένα [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) και λαμβάνει το παραγόμενο XML ως byte array:

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

## **Σύγκριση XML με Παρουσίαση και Μορφές Εξαγωγής**

Επιλέξτε τη μορφή εξόδου με βάση τον τρόπο χρήσης του αποτελέσματος:

| Format | Output | Typical use |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Μια PowerPoint XML Presentation | Επιθεώρηση δομής, αντιμετώπιση προβλημάτων, σύγκριση παραγόμενης εξόδου και ενσωμάτωση βάσει XML |
| PPT (`.ppt`) | Ένα παλιό δυαδικό αρχείο παρουσίασης | Συμβατότητα με παλαιότερες ροές εργασίας PowerPoint |
| PPTX (`.pptx`) | Ένα πακέτο Office Open XML που περιέχει πολλαπλά μέρη | Κανονική επεξεργασία PowerPoint και ανταλλαγή παρουσιάσεων |
| PDF or TIFF | Σελίδες σταθερής διάταξης ή εικόνα πολλαπλών σελίδων | Προβολή, εκτύπωση και αρχειοθέτηση |
| PNG, JPEG, or SVG | Μια αποδομένη αναπαράσταση μιας μεμονωμένης διαφάνειας | Μικρογραφίες, προεπισκοπήσεις και κάλυμμα εικόνων |
| HTML or HTML5 | Έξοδος παρουσίασης προσανατολισμένης στο web | Προβολή σε πρόγραμμα περιήγησης και δημοσίευση στο web |

Σε αντίθεση με τα PPT και PPTX, η έξοδος XML προορίζεται κυρίως για επιθεώρηση και εργασίες προσανατολισμένες στα δεδομένα. Σε αντίθεση με τα PDF, TIFF, HTML και μορφές εικόνας διαφάνειας, αντιπροσωπεύει δεδομένα παρουσίασης αντί για απόδοση διαφανειών ως σελίδες ή οπτικά στοιχεία. Ο πίνακας [supported file formats](/slides/el/java/supported-file-formats/) αναφέρει το PowerPoint XML Presentation ως μορφή μόνο για αποθήκευση, επομένως μην το χρησιμοποιείτε όταν μια ροή εργασίας πρέπει να φορτώσει το εξαγόμενο αρχείο ξανά στο Aspose.Slides για συνεχή επεξεργασία.

## **FAQ**

**Είναι το `SaveFormat.Xml` το ίδιο με την αποθήκευση ενός αρχείου PPTX;**

Όχι. Το PPTX είναι ένα πακέτο που περιέχει πολλαπλά μέρη Office Open XML, ενώ το `SaveFormat.Xml` δημιουργεί ένα αρχείο PowerPoint XML Presentation.

**Μπορώ να αποθηκεύσω την έξοδο XML χωρίς να δημιουργήσω αρχείο στο δίσκο;**

Ναι. Περάστε μια εγγράψιμη ροή στη [Presentation.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Για παράδειγμα, χρησιμοποιήστε ένα [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) για επεξεργασία στη μνήμη.

**Μπορεί το Aspose.Slides να φορτώσει ξανά το εξαγόμενο αρχείο XML;**

Όχι. Το PowerPoint XML Presentation υποστηρίζεται επί του παρόντος μόνο για αποθήκευση και όχι για φόρτωση. Χρησιμοποιήστε PPTX ή άλλη υποστηριζόμενη μορφή παρουσίασης όταν απαιτείται πλήρης επεξεργασία (round‑trip).

**Η μετατροπή XML αποδίδει κάθε διαφάνεια ως σελίδα ή εικόνα;**

Όχι. Η μετατροπή XML γράφει δομημένα δεδομένα παρουσίασης. Χρησιμοποιήστε PDF ή TIFF για έξοδο προσανατολισμένο σε σελίδες, ή PNG, JPEG και SVG για εικόνες μεμονωμένων διαφανών.