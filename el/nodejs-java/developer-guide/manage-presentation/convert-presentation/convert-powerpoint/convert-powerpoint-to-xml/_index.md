---
title: Μετατροπή παρουσιάσεων PowerPoint σε XML σε JavaScript
linktitle: PowerPoint σε XML
type: docs
weight: 145
url: /el/nodejs-java/convert-powerpoint-to-xml/
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
- Ροή XML
- Node.js
- JavaScript
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις PowerPoint και OpenDocument σε αρχεία ή ροές PowerPoint XML σε JavaScript με το Aspose.Slides για Node.js μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides για Node.js μέσω Java μπορεί να μετατρέψει παρουσιάσεις PowerPoint σε μορφή PowerPoint XML Presentation. Η έξοδος XML είναι χρήσιμη όταν χρειάζεστε μια κειμενική αναπαράσταση για την εξέταση της δομής της παρουσίασης, την αντιμετώπιση προβλημάτων σε δημιουργημένα έγγραφα, τη σύγκριση της εξόδου σε αυτοματοποιημένες δοκιμές ή την ενσωμάτωση σε μια ροή εργασίας που καταναλώνει XML αντί για πακέτο παρουσίασης.

Χρησιμοποιήστε τη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#save) με την τιμή `Xml` από την απαρίθμηση [SaveFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/saveformat/) . Μπορείτε να γράψετε το αποτέλεσμα απευθείας σε αρχείο ή σε ροή.

{{% alert color="info" title="Σημείωση" %}}
`SaveFormat.Xml` δημιουργεί μια παρουσίαση PowerPoint XML. Δεν εξάγει τα μεμονωμένα τμήματα Office Open XML που αποθηκεύονται μέσα σε ένα πακέτο PPTX. Εάν χρειάζεστε τα ακριβή τμήματα του πακέτου PPTX, όπως `ppt/presentation.xml` ή μεμονωμένα αρχεία XML διαφάνειας, εξετάστε το ίδιο το πακέτο PPTX.
{{% /alert %}}

## **Μετατροπή παρουσίασης σε αρχείο XML**

Φορτώστε μια πηγή παρουσίασης με την κλάση [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) και, στη συνέχεια, περάστε τη διαδρομή εξόδου και το `SaveFormat.Xml` στη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#save). Η πηγή μπορεί να είναι οποιαδήποτε μορφή παρουσίασης που υποστηρίζεται για φόρτωση, όπως PPT, PPTX ή ODP.

Το παρακάτω παράδειγμα μετατρέπει μια παρουσίαση PPTX σε αρχείο XML:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("presentation.xml", aspose.slides.SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **Εγγραφή της εξόδου XML σε ροή**

Χρησιμοποιήστε την υπερφόρτωση ροής της μεθόδου [Presentation.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#save) όταν το XML πρέπει να παραμείνει στη μνήμη ή να περάσει σε άλλο στοιχείο, όπως μια υπηρεσία web, πάροχος αποθήκευσης ή αγωγός επεξεργασίας XML. Το παρακάτω παράδειγμα γράφει το αποτέλεσμα σε ένα Java `ByteArrayOutputStream` και αντιγράφει τα δημιουργημένα δεδομένα σε ένα Node.js `Buffer`:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xmlStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        presentation.save(xmlStream, aspose.slides.SaveFormat.Xml);

        const xmlBuffer = Buffer.from(xmlStream.toByteArray());
        console.log(`XML size: ${xmlBuffer.length} bytes`);

        // Περάστε το xmlBuffer στο επόμενο στοιχείο της ροής εργασίας.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Σύγκριση XML με μορφές παρουσίασης και εξαγωγής**

Επιλέξτε τη μορφή εξόδου ανάλογα με το πώς θα χρησιμοποιηθεί το αποτέλεσμα:

| Μορφή | Έξοδος | Τυπική χρήση |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Μία παρουσίαση PowerPoint XML | Εξέταση δομής, αντιμετώπιση προβλημάτων, σύγκριση δημιουργημένης εξόδου και ενσωμάτωση με βάση XML |
| PPT (`.ppt`) | Παλαιότερο δυαδικό αρχείο παρουσίασης | Συμβατότητα με παλαιότερες ροές εργασίας PowerPoint |
| PPTX (`.pptx`) | Πακέτο Office Open XML που περιέχει πολλαπλά τμήματα | Κανονική επεξεργασία PowerPoint και ανταλλαγή παρουσιάσεων |
| PDF ή TIFF | Σελίδες σταθερής διάταξης ή εικόνα πολλαπλών σελίδων | Προβολή, εκτύπωση και αρχειοθέτηση |
| PNG, JPEG ή SVG | Αναπαράσταση μιας μεμονωμένης διαφάνειας | Μικρογραφίες, προεπισκοπήσεις και εικόνες πόρων |
| HTML ή HTML5 | Έξοδος παρουσίασης προσανατολισμένης στο Web | Προβολή σε προγράμματα περιήγησης και δημοσίευση στο διαδίκτυο |

Σε αντίθεση με τα PPT και PPTX, η έξοδος XML προορίζεται κυρίως για επιθεώρηση και ροές εργασίας προσανατολισμένες στα δεδομένα. Σε αντίθεση με τα PDF, TIFF, HTML και μορφές εικόνων διαφάνειας, αντιπροσωπεύει δεδομένα παρουσίασης αντί για απόδοση διαφαινών ως σελίδες ή οπτικό υλικό. Ο πίνακας [υποστηριζόμενων μορφών αρχείων](/slides/el/nodejs-java/supported-file-formats/) αναφέρει το PowerPoint XML Presentation ως μορφή μόνο αποθήκευσης, επομένως μην το χρησιμοποιείτε όταν μια ροή εργασίας πρέπει να φορτώσει ξανά το εξαγόμενο αρχείο στο Aspose.Slides για περαιτέρω επεξεργασία.

## **Συχνές ερωτήσεις**

**Είναι το `SaveFormat.Xml` το ίδιο με την αποθήκευση αρχείου PPTX;**

Όχι. Το PPTX είναι ένα πακέτο που περιέχει πολλαπλά τμήματα Office Open XML, ενώ το `SaveFormat.Xml` δημιουργεί ένα αρχείο παρουσίασης PowerPoint XML.

**Μπορώ να αποθηκεύσω την έξοδο XML χωρίς να δημιουργήσω αρχείο στο δίσκο;**

Ναι. Περνάτε μια ρεγγράψιμη ροή στη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#save). Για παράδειγμα, χρησιμοποιήστε ένα Java `ByteArrayOutputStream` και αντιγράψτε τα δεδομένα του σε ένα Node.js `Buffer` για επεξεργασία στη μνήμη.

**Μπορεί το Aspose.Slides να φορτώσει ξανά το εξαγόμενο αρχείο XML;**

Όχι. Η παρουσίαση PowerPoint XML υποστηρίζεται αυτή τη στιγμή μόνο για αποθήκευση και όχι για φόρτωση. Χρησιμοποιήστε PPTX ή άλλη υποστηριζόμενη μορφή παρουσίασης όταν απαιτείται επαναλαμβανόμενη επεξεργασία.

**Η μετατροπή XML αποδίδει κάθε διαφάνεια ως σελίδα ή εικόνα;**

Όχι. Η μετατροπή XML γράφει δομημένα δεδομένα παρουσίασης. Χρησιμοποιήστε PDF ή TIFF για έξοδο προσανατολισμένο σε σελίδες ή PNG, JPEG και SVG για μεμονωμένες εικόνες διαφανειών.