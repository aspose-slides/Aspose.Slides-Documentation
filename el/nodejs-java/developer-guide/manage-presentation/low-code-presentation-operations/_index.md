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
- αφαίρεση αχρησιμοποίητων master διαφανίων
- αφαίρεση αχρησιμοποίητων διαφανειών διάταξης
- συμπίεση ενσωματωμένων γραμματοσειρών
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Χρησιμοποιήστε το API χαμηλού κώδικα του Aspose.Slides σε JavaScript για να μετατρέψετε και να συγχωνεύσετε παρουσιάσεις, να επαναλαμβάνετε το περιεχόμενο, να συλλέγετε σχήματα και να μειώσετε το μέγεθος της παρουσίασης."
---
## **Επισκόπηση**

Ο χώρος ονομάτων `aspose.slides` παρέχει στατικές βοηθητικές κλάσεις για κοινές λειτουργίες παρουσίασης. Αυτοί οι βοηθοί περιτυλίγουν συχνά χρησιμοποιούμενες ροές εργασίας του μοντέλου αντικειμένων σε εστιασμένες μεθόδους, ώστε να μπορείτε να μετατρέψετε ή να συνενώσετε αρχεία, να επεξεργαστείτε στοιχεία παρουσίασης, να συλλέξετε σχήματα και να αφαιρέσετε αχρησιμοποίητο περιεχόμενο με λιγότερο κώδικα.

Οι βοηθοί χαμηλού κώδικα είναι πιο χρήσιμοι όταν η λειτουργία εφαρμόζεται σε ολόκληρο το αρχείο ή την παρουσίαση και η προεπιλεγμένη ροή εργασίας ταιριάζει με τις απαιτήσεις σας. Χρησιμοποιήστε το πλήρες [Aspose.Slides object model](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/) όταν χρειάζεστε λεπτομερή έλεγχο πάνω σε μεμονωμένες διαφάνειες, master, διατάξεις, σχήματα, ρυθμίσεις εξαγωγής ή σχέσεις μεταξύ των στοιχείων της παρουσίασης.

Ο παρακάτω πίνακας συνοψίζει τους διαθέσιμους βοηθούς:

| Βοηθός | Χρήση |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/convert/) | Μετατροπή μιας παρουσίασης σε άλλη μορφή με άμεση κλήση αρχείο-προς-αρχείο. |
| [Merger](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/merger/) | Συνδυασμός ολόκληρων αρχείων παρουσίασης του ίδιου μορφότυπου. |
| [ForEach](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/foreach/) | Εκτέλεση μιας ενέργειας για κάθε διαφάνεια, σχήμα, παράγραφο ή τμήμα κειμένου. |
| [Collect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/collect/) | Ανάκτηση σχημάτων από ολόκληρη την παρουσίαση για επαναλαμβανόμενη επεξεργασία ή ανάλυση. |
| [Compress](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compress/) | Αφαίρεση αχρησιμοποίητων master και διατάξεων και μείωση των ενσωματωμένων δεδομένων γραμματοσειράς. |

## **Μετατροπή Παρουσίασης**

Χρησιμοποιήστε το [Convert.autoByExtension](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/convert/#autoByExtension) όταν η επέκταση του αρχείου εξόδου είναι επαρκής για την επιλογή της μορφής εξαγωγής. Η μέθοδος ανοίγει την πηγαία παρουσίαση, καθορίζει την απαιτούμενη μορφή από τη διαδρομή εξόδου και γράφει το αποτέλεσμα.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

Η κλάση [Convert](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/convert/) παρέχει επίσης ειδικές μεθόδους για εξαγωγή σε PDF, SVG, JPEG, PNG και TIFF. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να ελέγξετε ή να τροποποιήσετε την παρουσίαση πριν την εξαγωγή ή να ρυθμίσετε μια επιλογή εξαγωγής που δεν εκτίθεται από τον επιλεγμένο βοηθό. Δείτε το [Convert Presentation](/slides/el/nodejs-java/convert-presentation/) για ροές εργασίας και επιλογές ανά μορφή.

## **Συγχώνευση Παρουσιών**

Χρησιμοποιήστε το [Merger.process](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/merger/#process) για να συνδυάσετε ολόκληρα αρχεία παρουσίασης με μία κλήση. Οι εισερχόμενες παρουσιάσεις πρέπει να έχουν τον ίδιο μορφότυπο αρχείου.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

Ο βοηθός είναι κατάλληλος όταν όλες οι διαφάνειες πρέπει να προσαρτηθούν σε ένα αποτέλεσμα χωρίς να επιλέγονται ή να επαναχαρτογραφούνται ατομικά. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να συγχωνεύσετε επιλεγμένες διαφάνειες, να εφαρμόσετε master ή διάταξη προορισμού, να διατηρήσετε ενότητες ρητά ή να εναρμονίσετε διαφορετικά μεγέθη διαφανειών. Δείτε το [Merge Presentations](/slides/el/nodejs-java/merge-presentation/) για αυτά τα σενάρια.

## **Επανάληψη Στοιχείων Παρουσίασης**

Η κλάση [ForEach](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/foreach/) καλεί μια συνάρτηση callback για κάθε ζητούμενο τύπο στοιχείου παρουσίασης. Αποφεύγει ένθετους βρόχους συλλογής και είναι βολική για επιθεώρηση ή αλλαγές μορφοποίησης σε ολόκληρη την παρουσίαση. Στο Node.js, δημιουργήστε υλοποιήσεις των διασυνολο interfaces του callback με `java.newProxy`.

Το παρακάτω παράδειγμα χρησιμοποιεί τα [ForEach.slide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/foreach/#paragraph) και [ForEach.portion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/foreach/#portion) για να επιθεωρήσει τα αντίστοιχα στοιχεία:

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

Από προεπιλογή, η διασχέιση σχημάτων και κειμένου σε ολόκληρη την παρουσίαση περιλαμβάνει κανονικές, master και layout διαφάνειες. Οι υπερφορτώσεις με παράμετρο `includeNotes` μπορούν επίσης να επεξεργαστούν διαφάνειες σημειώσεων. Χρησιμοποιήστε άμεσους βρόχους συλλογής όταν η σειρά διασχέισης, η έγκαιρη έξοδος, η φιλτράρισμα πριν την κλήση του callback ή ο λεπτομερής έλεγχος γονέα-παιδιού είναι σημαντικά.

## **Συλλογή Σχημάτων**

Χρησιμοποιήστε το [Collect.shapes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/collect/#shapes) όταν χρειάζεστε μια συλλογή όλων των σχημάτων σε μια παρουσίαση αντί για ένα callback για κάθε σχήμα. Αυτό είναι χρήσιμο όταν το ίδιο σύνολο θα φιλτράρεται, θα μετράται ή θα επεξεργάζεται περισσότερες φορές.

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

Χρησιμοποιήστε το [ForEach.shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/foreach/#shape) αντ' αυτού όταν κάθε σχήμα μπορεί να επεξεργαστεί άμεσα και δεν χρειάζεται να διατηρήσετε το συλλεγμένο αποτέλεσμα.

## **Συμπίεση Περιεχομένου Παρουσίασης**

Η κλάση [Compress](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compress/) μπορεί να αφαιρέσει αχρησιμοποίητα δομικά στοιχεία και να μειώσει τα ενσωματωμένα δεδομένα γραμματοσειράς:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) αφαιρεί τις διαφάνειες διάταξης που δεν αναφέρονται από καμία κανονική διαφάνεια.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) αφαιρεί τις master διαφάνειες που δεν χρησιμοποιούνται πλέον.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) αφαιρεί αχρησιμοποίητους χαρακτήρες από τις ενσωματωμένες γραμματοσειρές.

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

Αφαιρέστε τις αχρησιμοποίητες διατάξεις πριν από τα αχρησιμοποίητα master, ώστε ένα master που γίνεται χωρίς αναφορά μετά τον καθαρισμό των διατάξεων να μπορεί επίσης να αφαιρεθεί. Αποθηκεύστε την βελτιστοποιημένη παρουσίαση σε νέο αρχείο αν μπορεί να χρειαστείτε αργότερα τα αρχικά master, τις διατάξεις ή τα πλήρη ενσωματωμένα δεδομένα γραμματοσειράς. Για περισσότερες λεπτομέρειες, δείτε [Slide Master](/slides/el/nodejs-java/slide-master/) και [Embedded Font](/slides/el/nodejs-java/embedded-font/).

## **Συχνές Ερωτήσεις**

**Πότε πρέπει να χρησιμοποιήσω το API χαμηλού κώδικα αντί για το πλήρες μοντέλο αντικειμένων;**

Χρησιμοποιήστε τους βοηθούς χαμηλού κώδικα όταν μια τυπική λειτουργία εφαρμόζεται σε ολοκληρωμένο αρχείο ή παρουσίαση και δεν απαιτεί λεπτομερή έλεγχο των μεμονωμένων στοιχείων. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να επιλέξετε συγκεκριμένες διαφάνειες, να ελέγξετε σχέσεις master και διάταξης, να επιθεωρήσετε ενδιάμεση κατάσταση ή να ρυθμίσετε συμπεριφορά που ο βοηθός δεν εκθέτει.

**Μπορεί το Merger να συνδυάσει παρουσιάσεις σε διαφορετικούς μορφότυπους αρχείων;**

Όχι. Το [Merger.process](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/merger/#process) απαιτεί οι εισερχόμενες παρουσιάσεις να έχουν τον ίδιο μορφότυπο. Μετατρέψτε πρώτα τα εισερχόμενα αρχεία σε κοινό μορφότυπο, για παράδειγμα με το [Convert.autoByExtension](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/convert/#autoByExtension), και στη συνέχεια συνενώστε τα μετατρεπόμενα αρχεία.

**Επεξεργάζεται το ForEach τα master, layout και τις διαφάνειες σημειώσεων;**

Το [ForEach.slide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/foreach/#slide) επαναλαμβάνει τις κανονικές διαφάνειες παρουσίασης. Οι λειτουργίες [ForEach.shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/foreach/#paragraph) και [ForEach.portion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/foreach/#portion) σε ολόκληρη την παρουσίαση περιλαμβάνουν κανονικές, master και layout διαφάνειες από προεπιλογή. Χρησιμοποιήστε τις υπερφορτώσεις τους με `includeNotes` ορισμένο σε `true` για να συμπεριλάβετε τις διαφάνειες σημειώσεων.

**Ποια είναι η διαφορά μεταξύ ForEach.shape και Collect.shapes;**

Χρησιμοποιήστε το [ForEach.shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/foreach/#shape) για να επεξεργαστείτε αμέσως κάθε σχήμα μέσω ενός callback. Χρησιμοποιήστε το [Collect.shapes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/collect/#shapes) όταν χρειάζεστε ένα επαναχρησιμοποιήσιμο αποτέλεσμα που μπορεί να διατηρηθεί, να φιλτραριστεί, να μετρηθεί ή να περάσει ξανά πολλές φορές.

**Κάνει πάντα το Compress το αρχείο παρουσίασης μικρότερο;**

Δεν είναι απαραίτητα. Το αποτέλεσμα εξαρτάται από το αν η παρουσίαση περιέχει αχρησιμοποίητες διατάξεις, αχρησιμοποίητα master ή ενσωματωμένες γραμματοσειρές με αχρησιμοποίητους χαρακτήρες. Αν κανένα από αυτά δεν υπάρχει, οι αντίστοιχες λειτουργίες [Compress](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compress/) ενδέχεται να μην μειώσουν το μέγεθος του αρχείου.

**Αποθηκεύονται αυτόματα οι αλλαγές που γίνονται από το ForEach ή το Compress;**

Όχι. Αυτοί οι βοηθοί λειτουργούν στο φορτωμένο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) στη μνήμη. Μετά την αλλαγή στοιχείων σε ένα callback του [ForEach](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/foreach/) ή την εκτέλεση του [Compress](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compress/), καλέστε το [Presentation.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#save) για να γράψετε το αποτέλεσμα.

## **Σχετικά Άρθρα**

- [Μετατροπή Παρουσίασης](/slides/el/nodejs-java/convert-presentation/)
- [Συγχώνευση Παρουσιών](/slides/el/nodejs-java/merge-presentation/)
- [Master Διαφάνειας](/slides/el/nodejs-java/slide-master/)
- [Διαχείριση Πλαισίου Κειμένου](/slides/el/nodejs-java/manage-textbox/)
- [Ενσωματωμένη Γραμματοσειρά](/slides/el/nodejs-java/embedded-font/)