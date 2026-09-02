---
title: Μετατροπή παρουσιάσεων PowerPoint σε XML στο Android
linktitle: PowerPoint σε XML
type: docs
weight: 145
url: /el/androidjava/convert-powerpoint-to-xml/
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
- Android
- Java
- Aspose.Slides
description: "Μετατροπή παρουσιάσεων PowerPoint και OpenDocument σε αρχεία ή ροές PowerPoint XML στο Android με το Aspose.Slides."
---
## **Επισκόπηση**

Το Aspose.Slides for Android μέσω Java μπορεί να μετατρέπει παρουσιάσεις PowerPoint σε μορφή PowerPoint XML Presentation. Η έξοδος XML είναι χρήσιμη όταν χρειάζεστε μια κειμενική αναπαράσταση για την επιθεώρηση της δομής της παρουσίασης, την αντιμετώπιση προβλημάτων των παραγόμενων εγγράφων, τη σύγκριση της εξόδου σε αυτοματοποιημένες δοκιμές ή την ενσωμάτωση σε μια ροή εργασίας που καταναλώνει XML αντί για πακέτο παρουσίασης.

Χρησιμοποιήστε τη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) με το [SaveFormat.Xml](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/saveformat/#Xml). Μπορείτε να γράψετε το αποτέλεσμα απευθείας σε αρχείο ή σε ροή.

{{% alert color="info" title="Σημείωση" %}}

`SaveFormat.Xml` δημιουργεί μια PowerPoint XML Presentation. Δεν εξάγει τα μεμονωμένα μέρη Office Open XML που αποθηκεύονται μέσα σε ένα πακέτο PPTX. Εάν χρειάζεστε τα ακριβή μέρη του πακέτου PPTX, όπως `ppt/presentation.xml` ή τα μεμονωμένα αρχεία XML διαφάνειας, ελέγξτε το ίδιο το πακέτο PPTX.

{{% /alert %}}

## **Μετατροπή Παρουσίασης σε Αρχείο XML**

Φορτώστε μια πηγαία παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) , και στη συνέχεια περάστε τη διαδρομή εξόδου και το [SaveFormat.Xml](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/saveformat/#Xml) στη [Presentation.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Η πηγή μπορεί να είναι οποιαδήποτε μορφή παρουσίασης που υποστηρίζεται για φόρτωση, όπως PPT, PPTX ή ODP.

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

## **Γράψτε την Έξοδο XML σε Ροή**

Χρησιμοποιήστε την υπερφόρτωση ροής της [Presentation.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) όταν το XML πρέπει να παραμείνει στη μνήμη ή να περαστεί σε άλλο στοιχείο, όπως μια υπηρεσία ιστού, πάροχο αποθήκευσης ή διοχέλαιο επεξεργασίας XML. Το ακόλουθο παράδειγμα γράφει το αποτέλεσμα σε ένα [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) και παίρνει το παραγόμενο XML ως πίνακα byte:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ByteArrayOutputStream xmlStream = new ByteArrayOutputStream();
    try {
        presentation.save(xmlStream, SaveFormat.Xml);
        byte[] xmlData = xmlStream.toByteArray();

        // Περνάτε το xmlData στο επόμενο στοιχείο της ροής εργασίας.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Σύγκριση XML με Παρουσίαση και Μορφές Εξαγωγής**

Επιλέξτε τη μορφή εξόδου ανάλογα με το πώς θα χρησιμοποιηθεί το αποτέλεσμα:

| Μορφή | Έξοδος | Τυπική χρήση |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Μια PowerPoint XML Presentation | Επιθεώρηση δομής, αντιμετώπιση προβλημάτων, σύγκριση παραγόμενης εξόδου και ενσωμάτωση βασισμένη σε XML |
| PPT (`.ppt`) | Ένα παλαιό δυαδικό αρχείο παρουσίασης | Συμβατότητα με παλαιότερες ροές εργασίας PowerPoint |
| PPTX (`.pptx`) | Ένα πακέτο Office Open XML που περιέχει πολλαπλά μέρη | Κανονική επεξεργασία PowerPoint και ανταλλαγή παρουσιάσεων |
| PDF or TIFF | Σελίδες σταθερής διάταξης ή εικόνα πολλών σελίδων | Προβολή, εκτύπωση και αρχειοθέτηση |
| PNG, JPEG, or SVG | Μια αποδοτική αναπαράσταση μιας μεμονωμένης διαφάνειας | Μικρογραφίες, προεπισκοπήσεις και εικόνες περιουσιακών στοιχείων |
| HTML or HTML5 | Παρουσίαση προσανατολισμένη στο web | Προβολή σε προγράμματα περιήγησης και δημοσίευση στο διαδίκτυο |

Σε αντίθεση με τα PPT και PPTX, η έξοδος XML προορίζεται κυρίως για επιθεώρηση και ροές εργασίας προσανατολισμένες στα δεδομένα. Σε αντίθεση με τα PDF, TIFF, HTML και μορφές εικόνας διαφάνειας, αντιπροσωπεύει τα δεδομένα παρουσίασης αντί για την απόδοση διαφανειών ως σελίδες ή οπτικά στοιχεία. Ο πίνακας [supported file formats](/slides/el/androidjava/supported-file-formats/) αναφέρει τη PowerPoint XML Presentation ως μορφή μόνο για αποθήκευση, επομένως μην τη χρησιμοποιείτε όταν μια ροή εργασίας πρέπει να φορτώσει το εξαχθέν αρχείο ξανά στο Aspose.Slides για συνέχιση επεξεργασίας.

## **Συχνές Ερωτήσεις**

**Είναι το `SaveFormat.Xml` το ίδιο με την αποθήκευση αρχείου PPTX;**

Όχι. Το PPTX είναι ένα πακέτο που περιέχει πολλαπλά μέρη Office Open XML, ενώ το `SaveFormat.Xml` δημιουργεί ένα αρχείο PowerPoint XML Presentation.

**Μπορώ να αποθηκεύσω την έξοδο XML χωρίς να δημιουργήσω αρχείο στο δίσκο;**

Ναι. Περνάτε μια εγγράψιμη ροή στη [Presentation.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Για παράδειγμα, χρησιμοποιήστε ένα [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) για επεξεργασία στη μνήμη.

**Μπορεί το Aspose.Slides να φορτώσει ξανά το εξαχθέν αρχείο XML;**

Όχι. Η PowerPoint XML Presentation υποστηρίζεται αυτή τη στιγμή μόνο για αποθήκευση και όχι για φόρτωση. Χρησιμοποιήστε PPTX ή άλλη υποστηριζόμενη μορφή παρουσίασης όταν απαιτείται επαναφόρτωση για επεξεργασία.

**Η μετατροπή XML αποδίδει κάθε διαφάνεια ως σελίδα ή εικόνα;**

Όχι. Η μετατροπή XML γράφει δομημένα δεδομένα παρουσίασης. Χρησιμοποιήστε PDF ή TIFF για έξοδο προσανατολισμένο σε σελίδες ή PNG, JPEG και SVG για εικόνες μεμονωμένων διαφανειών.