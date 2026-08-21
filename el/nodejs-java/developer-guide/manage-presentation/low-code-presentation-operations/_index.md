---
title: Λειτουργίες Παρουσίασης Χαμηλού Κώδικα σε JavaScript
linktitle: API Χαμηλού Κώδικα
type: docs
weight: 50
url: /el/nodejs-java/low-code-presentation-operations/
keywords:
- API παρουσίασης χαμηλού κώδικα
- μετατροπή παρουσίασης
- συγχώνευση παρουσιάσεων
- επανάληψη διαφανειών
- επανάληψη σχημάτων
- επανάληψη κειμένου
- συλλογή σχημάτων
- συμπίεση παρουσίασης
- αφαίρεση αχρησιμοποίητων master διαφανειών
- αφαίρεση αχρησιμοποίητων διαφανειών διάταξης
- συμπίεση ενσωματωμένων γραμματοσειρών
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Χρησιμοποιήστε το API χαμηλού κώδικα του Aspose.Slides σε JavaScript για να μετατρέψετε και να συγχωνεύσετε παρουσιάσεις, να επαναλάβετε το περιεχόμενο, να συλλέξετε σχήματα και να μειώσετε το μέγεθος της παρουσίασης."
---
## **Επισκόπηση**

Ο χώρος ονομάτων `aspose.slides` παρέχει στατικές βοηθητικές κλάσεις για κοινές λειτουργίες παρουσίασης. Αυτοί οι βοηθοί περιβάλλουν συχνά χρησιμοποιούμενες ροές εργασίας του μοντέλου αντικειμένων σε εστιασμένες μεθόδους, ώστε να μπορείτε να μετατρέπετε ή να συγχωνεύετε αρχεία, να επεξεργάζεστε στοιχεία παρουσίασης, να συλλέγετε σχήματα και να αφαιρείτε αχρησιμοποίητο περιεχόμενο με λιγότερο κώδικα.

Οι low-code βοηθοί είναι πιο χρήσιμοι όταν η λειτουργία εφαρμόζεται σε ολόκληρο το αρχείο ή την παρουσίαση και η προεπιλεγμένη ροή εργασίας ταιριάζει με τις απαιτήσεις σας. Χρησιμοποιήστε το πλήρες [Aspose.Slides object model](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/) όταν χρειάζεστε λεπτομερή έλεγχο πάνω σε μεμονωμένες διαφάνειες, master, διατάξεις, σχήματα, ρυθμίσεις εξαγωγής ή σχέσεις μεταξύ των στοιχείων της παρουσίασης.

Ο παρακάτω πίνακας συνοψίζει τους διαθέσιμους βοηθούς:

| Βοηθός | Χρήση |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/convert/) | Μετατροπή μιας παρουσίασης σε άλλη μορφή με άμεση κλήση αρχείου-προς-αρχείο. |
| [Merger](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/merger/) | Συνδυασμός πλήρων αρχείων παρουσίασης του ίδια μορφής. |
| [ForEach](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/foreach/) | Εκτέλεση ενέργειας για κάθε διαφάνεια, σχήμα, παράγραφο ή τμήμα κειμένου. |
| [Collect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/collect/) | Ανάκτηση σχημάτων από ολόκληρη την παρουσίαση για επαναλαμβανόμενη επεξεργασία ή ανάλυση. |
| [Compress](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compress/) | Αφαίρεση αχρησιμοποίητων master και διατάξεων και μείωση δεδομένων ενσωματωμένων γραμματοσειρών. |

## **Μετατροπή Παρουσίασης**

Χρησιμοποιήστε το [Convert.autoByExtension](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/convert/#autoByExtension) όταν η επέκταση του αρχείου εξόδου είναι επαρκής για την επιλογή της μορφής εξαγωγής. Η μέθοδος ανοίγει την πηγή παρουσίασης, καθορίζει τη ζητούμενη μορφή από τη διαδρομή εξόδου και γράφει το αποτέλεσμα.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

Η κλάση [Convert](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/convert/) παρέχει επίσης ειδικές μεθόδους για έξοδο PDF, SVG, JPEG, PNG και TIFF. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να επιθεωρήσετε ή να τροποποιήσετε την παρουσίαση πριν την εξαγωγή ή να ρυθμίσετε μια επιλογή εξαγωγής που δεν εκτίθεται από τον επιλεγμένο βοηθό. Δείτε το [Convert Presentation](/nodejs-java/convert-presentation/) για ροές εργασίας και επιλογές συγκεκριμένων μορφών.

## **Συγχώνευση Παρουσιάσεων**

Χρησιμοποιήστε το [Merger.process](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/merger/#process) για να συνδυάσετε πλήρως αρχεία παρουσίασης με μία κλήση. Οι εισερχόμενες παρουσιάσεις πρέπει να έχουν την ίδια μορφή αρχείου.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

Ο βοηθός είναι κατάλληλος όταν όλες οι διαφάνειες πρέπει να προσαρτηθούν σε ένα αποτέλεσμα χωρίς να τις επιλέγετε ή να τις αντιστοιχίζετε ξεχωριστά. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να συγχωνεύσετε επιλεγμένες διαφάνειες, να εφαρμόσετε προορισμό master ή διάταξης, να διατηρήσετε σαφώς ενότητες ή να συμφιλιώσετε διαφορετικά μεγέθη διαφανειών. Δείτε το [Merge Presentations](/nodejs-java/merge-presentation/) για αυτά τα σενάρια.

## **Επανάληψη Στοιχείων Παρουσίασης**

Η κλάση [ForEach](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/foreach/) καλεί μια λειτουργία επανάκλησης για κάθε ζητούμενο τύπο στοιχείου παρουσίασης. Αποφεύγει ενσωματωμένους βρόχους συλλογής και είναι βολική για επιθεώρηση ή αλλαγές μορφοποίησης σε όλη την παρουσίαση. Στο Node.js, δημιουργήστε υλοποιήσεις των διεπαφών επανάκλησης με `java.newProxy`.

Το παρακάτω παράδειγμα χρησιμοποιεί τα [ForEach.slide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/foreach/#paragraph) και [ForEach.portion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/foreach/#portion) για να επιθεωρήσουν τα αντίστοιχα στοιχεία:

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCallback = java.newProxy("com.aspose.slides.ForEach$ForEachSlideCallback", {
        invoke: function (slide, index) {
            console.log(`Slide ${index}: ${slide.getShapes().size()} shapes`);
        }
    });
    aspose.slides.ForEach.slide(presentation, slideCallback);

    const shapeCallback = java.newProxy("com.aspose.slides.ForEach$ForEachShapeCallback", {
        invoke: function (shape, slide, index) {
            console.log(`Shape ${index} on ${slide.getClass().getSimpleName()}: ${shape.getName()}`);
        }
    });
    aspose.slides.ForEach.shape(presentation, shapeCallback);

    const paragraphCallback = java.newProxy("com.aspose.slides.ForEach$ForEachParagraphCallback", {
        invoke: function (paragraph, slide, index) {
            console.log(`Paragraph ${index} on ${slide.getClass().getSimpleName()}: ${paragraph.getText()}`);
        }
    });
    aspose.slides.ForEach.paragraph(presentation, paragraphCallback);

    const portionCallback = java.newProxy("com.aspose.slides.ForEach$ForEachPortionCallback", {
        invoke: function (portion, paragraph, slide, index) {
            console.log(`Portion ${index} on ${slide.getClass().getSimpleName()}: ${portion.getText()}`);
        }
    });
    aspose.slides.ForEach.portion(presentation, portionCallback);
} finally {
    presentation.dispose();
}
```

Από προεπιλογή, η διάσχιση σχημάτων και κειμένου σε όλη την παρουσίαση περιλαμβάνει κανονικές, master και διατάξεις διαφάνειες. Οι υπερφορτώσεις με παράμετρο `includeNotes` μπορούν επίσης να επεξεργαστούν διαφάνειες σημειώσεων. Χρησιμοποιήστε άμεσους βρόχους συλλογής όταν η σειρά διάσχισης, η έγκαιρη έξοδος, το φιλτράρισμα πριν την κλήση της επανάκλησης ή ο λεπτομερής έλεγχος γονέας-παιδιού είναι σημαντικά.

## **Συλλογή Σχημάτων**

Χρησιμοποιήστε το [Collect.shapes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/collect/#shapes) όταν χρειάζεστε μια συλλογή όλων των σχημάτων σε μια παρουσίαση αντί για επανάκληση για κάθε σχήμα. Αυτό είναι χρήσιμο όταν το ίδιο σύνολο θα φιλτράρεται, θα μετριέται ή θα επεξεργάζεται περισσότερες φορές.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const shapes = aspose.slides.Collect.shapes(presentation);
    const iterator = shapes.iterator();

    while (iterator.hasNext()) {
        const shape = iterator.next();
        console.log(`${shape.getName()}: ${shape.getClass().getSimpleName()}`);
    }
} finally {
    presentation.dispose();
}
```

Χρησιμοποιήστε το [ForEach.shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/foreach/#shape) αντί για αυτό όταν κάθε σχήμα μπορεί να διαχειριστεί άμεσα και δεν χρειάζεστε τη διατήρηση του συλλεγμένου αποτελέσματος.

## **Συμπίεση Περιεχομένου Παρουσίασης**

Η κλάση [Compress](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compress/) μπορεί να αφαιρέσει αχρησιμοποίητα δομικά στοιχεία και να μειώσει τα ενσωματωμένα δεδομένα γραμματοσειρών:

- Το [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) αφαιρεί διαφάνειες διατάξεων που δεν αναφέρονται από καμία κανονική διαφάνεια.
- Το [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) αφαιρεί master διαφάνειες που δεν χρησιμοποιούνται πλέον.
- Το [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) αφαιρεί αχρησιμοποίητους χαρακτήρες από ενσωματωμένες γραμματοσειρές.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    aspose.slides.Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Αφαιρέστε τις αχρησιμοποίητες διατάξεις πριν από τους αχρησιμοποίητους master, ώστε ένας master που γίνεται ακατάσχετος μετά τον καθαρισμό των διατάξεων να μπορεί επίσης να αφαιρεθεί. Αποθηκεύστε την βελτιστοποιημένη παρουσίαση σε ένα νέο αρχείο εάν ενδέχεται να χρειαστείτε αργότερα τους αρχικούς master, τις διατάξεις ή τα πλήρη ενσωματωμένα δεδομένα γραμματοσειρών. Για περισσότερες λεπτομέρειες, δείτε το [Slide Master](/nodejs-java/slide-master/) και το [Embedded Font](/nodejs-java/embedded-font/).

## **Συχνές Ερωτήσεις**

**Πότε πρέπει να χρησιμοποιήσω το low-code API αντί για το πλήρες μοντέλο αντικειμένων;**

Χρησιμοποιήστε low-code βοηθούς όταν μια τυπική λειτουργία εφαρμόζεται σε ολόκληρο το αρχείο ή την παρουσίαση και δεν απαιτεί λεπτομερή έλεγχο των μεμονωμένων στοιχείων. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να επιλέξετε συγκεκριμένες διαφάνειες, να ελέγξετε σχέσεις master και διάταξης, να επιθεωρήσετε ενδιάμεσες καταστάσεις ή να διαμορφώσετε συμπεριφορά που ο βοηθός δεν εκθέτει.

**Μπορεί ο Merger να συνδυάσει παρουσιάσεις σε διαφορετικές μορφές αρχείου;**

Όχι. Το [Merger.process](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/merger/#process) απαιτεί εισερχόμενες παρουσιάσεις στην ίδια μορφή. Μετατρέψτε πρώτα τα αρχεία εισόδου σε κοινή μορφή, για παράδειγμα με το [Convert.autoByExtension](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/convert/#autoByExtension), και μετά συγχωνεύστε τα μετατραπέντα αρχεία.

**Επεξεργάζεται το ForEach τις master, layout και διαφάνειες σημειώσεων;**

Το [ForEach.slide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/foreach/#slide) διατρέχει τις κανονικές διαφάνειες παρουσίασης. Οι λειτουργίες [ForEach.shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/foreach/#paragraph) και [ForEach.portion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/foreach/#portion) σε όλη την παρουσίαση περιλαμβάνουν κανονικές, master και layout διαφάνειες από προεπιλογή. Χρησιμοποιήστε τις υπερφορτώσεις τους με `includeNotes` ορισμένο σε `true` για να συμπεριλάβετε διαφάνειες σημειώσεων.

**Ποια είναι η διαφορά μεταξύ ForEach.shape και Collect.shapes;**

Χρησιμοποιήστε το [ForEach.shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/foreach/#shape) για να επεξεργαστείτε κάθε σχήμα αμέσως μέσω μιας επανάκλησης. Χρησιμοποιήστε το [Collect.shapes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/collect/#shapes) όταν χρειάζεστε ένα επαναλαμβανόμενο αποτέλεσμα που μπορεί να διατηρηθεί, φιλτραριστεί, μετρηθεί ή διασχιστεί πολλαπλές φορές.

**Η λειτουργία Compress μειώνει πάντα το μέγεθος του αρχείου παρουσίασης;**

Δεν είναι απαραίτητο. Το αποτέλεσμα εξαρτάται από το εάν η παρουσίαση περιλαμβάνει αχρησιμοποίητες διατάξεις, αχρησιμοποίητους master ή ενσωματωμένες γραμματοσειρές με αχρησιμοποίητους χαρακτήρες. Εάν κανένα από αυτά δεν υπάρχει, οι αντίστοιχες λειτουργίες [Compress](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compress/) ενδέχεται να μην μειώσουν το μέγεθος του αρχείου.

**Αποθηκεύονται αυτόματα οι αλλαγές που γίνονται από το ForEach ή το Compress;**

Όχι. Αυτοί οι βοηθοί λειτουργούν στο φορτωμένο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) στη μνήμη. Μετά την αλλαγή στοιχείων σε μια επανάκληση του [ForEach](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/foreach/) ή την εκτέλεση του [Compress](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compress/), καλέστε το [Presentation.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#save) για να γράψετε το αποτέλεσμα.

## **Σχετικά Άρθρα**

- [Μετατροπή Παρουσίασης](/nodejs-java/convert-presentation/)
- [Συγχώνευση Παρουσιάσεων](/nodejs-java/merge-presentation/)
- [Master Διαφάνειας](/nodejs-java/slide-master/)
- [Διαχείριση Πλαισίου Κειμένου](/nodejs-java/manage-textbox/)
- [Ενσωματωμένη Γραμματοσειρά](/nodejs-java/embedded-font/)