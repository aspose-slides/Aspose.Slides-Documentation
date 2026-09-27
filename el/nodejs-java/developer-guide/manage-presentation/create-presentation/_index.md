---
title: Δημιουργία Παρουσιάσεων σε JavaScript
linktitle: Δημιουργία Παρουσίασης
type: docs
weight: 10
url: /el/nodejs-java/create-presentation/
keywords:
- δημιουργία παρουσίασης
- νέα παρουσίαση
- δημιουργία PPT
- νέο PPT
- δημιουργία PPTX
- νέο PPTX
- δημιουργία ODP
- νέο ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Δημιουργήστε παρουσιάσεις με το Aspose.Slides—παράγετε αρχεία PPT, PPTX και ODP, αξιοποιήστε την υποστήριξη OpenDocument και αποθηκεύστε τα προγραμματιστικά για αξιόπιστα αποτελέσματα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια παρουσίαση στο Aspose.Slides, να προσθέσετε ένα πλαίσιο κειμένου στην πρώτη της διαφάνεια και να αποθηκεύσετε το αποτέλεσμα ως αρχείο.

Πριν ξεκινήσετε, εγκαταστήστε το πακέτο `aspose.slides.via.java` από το npm, μαζί με το JDK, το Python και τα εργαλεία δημιουργίας C++ που χρειάζεται. Δείτε την [Εγκατάσταση](/slides/el/nodejs-java/installation/).

## **Δημιουργία παρουσίασης PowerPoint**

Για να δημιουργήσετε μια παρουσίαση και να τοποθετήσετε ένα πλαίσιο κειμένου στην πρώτη της διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/). Μια νέα παρουσίαση περιλαμβάνει ήδη μια κενή διαφάνεια.
1. Αποκτήστε αυτή τη διαφάνεια από τη [συλλογή διαφανειών]((https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/getslides/)) με το δείκτη της, 0.
1. Προσθέστε ένα ορθογώνιο με τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/addautoshape/) και ορίστε το κείμενό του με το [setText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/settext/).
1. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX χρησιμοποιώντας τη μέθοδο [save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/save/).
1. Αποδεσμεύστε την παρουσίαση με τη μέθοδο [dispose](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/dispose/) και τερματίστε τη διαδικασία.

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Το Aspose.Slides εκτελείται σε εικονική μηχανή Java που κρατά το Node.js σε λειτουργία, επομένως τερματίστε τη διαδικασία ρητά.
process.exit(0);
```

Η αριστερή‑πάνω γωνία του ορθογωνίου βρίσκεται 50 σημεία από το αριστερό άκρο και 50 σημεία από το πάνω άκρο της διαφάνειας, και το ορθογώνιο έχει πλάτος 400 σημεία και ύψος 100 σημεία. Αποθηκεύστε τον κώδικα ως *hello.js* στο φάκελο του έργου σας και εκτελέστε `node hello.js`: δημιουργεί το *hello.pptx*, με μία διαφάνεια που περιέχει αυτό το ορθογώνιο και το κείμενό του, στον τρέχοντα φάκελο.

Το Aspose.Slides λειτουργεί σε εικονική μηχανή Java που το πακέτο `java` εκκινεί μέσα στη διαδικασία Node.js. Η εικονική μηχανή εμποδίζει το Node.js να τερματιστεί αυτόματα αφού ολοκληρωθεί το σενάριο, γι’ αυτό το παράδειγμα λήγει με `process.exit(0)`.

Χωρίς άδεια, το Aspose.Slides προσθέτει επίσης υδατογραφή αξιολόγησης σε κάθε διαφάνεια που αποθηκεύει· δείτε την [Αδειοδότηση](/slides/el/nodejs-java/licensing/).

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

### Σε ποιες μορφές μπορώ να αποθηκεύσω μια νέα παρουσίαση;

Μπορείτε να αποθηκεύσετε σε [PPTX, PPT και ODP](/slides/el/nodejs-java/save-presentation/), και να εξάγετε σε [PDF](/slides/el/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/el/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/el/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/el/nodejs-java/render-a-slide-as-an-svg-image/), και [εικόνες](/slides/el/nodejs-java/convert-powerpoint-to-png/), μεταξύ άλλων.

### Μπορώ να αρχίσω από ένα πρότυπο (POTX/POTM) και να το αποθηκεύσω ως κανονικό PPTX;

Ναι. Φορτώστε το πρότυπο και αποθηκεύστε το στην επιθυμητή μορφή· τα POTX/POTM/PPTM και παρόμοιες μορφές [είναι υποστηριζόμενα](/slides/el/nodejs-java/supported-file-formats/).

### Πώς ελέγχω το μέγεθος/αναλογία διαφάνειας όταν δημιουργώ μια παρουσίαση;

Ορίστε το [μέγεθος διαφάνειας](/slides/el/nodejs-java/slide-size/) (συμπεριλαμβανομένων προρυθμίσεων όπως 4:3 και 16:9 ή προσαρμοσμένων διαστάσεων) και επιλέξτε πώς θα κλιμακωθεί το περιεχόμενο.

### Σε ποιες μονάδες μετριούνται τα μεγέθη και οι συντεταγμένες;

Σε σημεία: 1 ίντσα ισούται με 72 μονάδες.

### Πώς να διαχειριστώ πολύ μεγάλες παρουσιάσεις (με πολλά αρχεία πολυμέσων) ώστε να μειωθεί η χρήση μνήμης;

Χρησιμοποιήστε [Στρατηγικές διαχείρισης BLOB](/slides/el/nodejs-java/manage-blob/), περιορίστε την αποθήκευση στη μνήμη αξιοποιώντας προσωρινά αρχεία, και προτιμήστε ροές εργασίας βασισμένες σε αρχεία αντί για καθαρούς ροές στη μνήμη.

### Μπορώ να δημιουργήσω/αποθηκεύσω παρουσιάσεις παράλληλα;

Δεν μπορείτε να λειτουργήσετε πάνω στο ίδιο αντικείμενο [Presentation]((https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/)) από [πολλαπλά νήματα](/slides/el/nodejs-java/multithreading/). Εκτελέστε ξεχωριστές, απομονωμένες εμφανίσεις ανά νήμα ή διαδικασία.

### Πώς αφαιρώ την υδατογραφή δοκιμής και τους περιορισμούς;

[Εφαρμόστε άδεια](/slides/el/nodejs-java/licensing/) μία φορά ανά διαδικασία. Το XML της άδειας πρέπει να παραμείνει αμετάβλητο, και η ρύθμιση της άδειας πρέπει να συγχρονιστεί εάν εμπλέκονται πολλαπλά νήματα.

### Μπορώ να υπογράψω ψηφιακά το PPTX που δημιουργώ;

Ναι. Οι [Ψηφιακές υπογραφές](/slides/el/nodejs-java/digital-signature-in-powerpoint/) (προσθήκη και επαλήθευση) υποστηρίζονται για παρουσιάσεις.

### Υποστηρίζονται μακροεντολές (VBA) στις δημιουργημένες παρουσιάσεις;

Ναι. Μπορείτε να [δημιουργήσετε/επεξεργαστείτε έργα VBA](/slides/el/nodejs-java/presentation-via-vba/) και να αποθηκεύσετε αρχεία με ενεργοποιημένα μακροεντολές όπως PPTM/PPSM.