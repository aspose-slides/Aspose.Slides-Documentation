---
title: Λειτουργίες Παρουσίασης Χαμηλού Κώδικα σε PHP
linktitle: API Χαμηλού Κώδικα
type: docs
weight: 50
url: /el/php-java/low-code-presentation-operations/
keywords:
- API παρουσίασης χαμηλού κώδικα
- μετατροπή παρουσίασης
- συγχώνευση παρουσιάσεων
- επανάληψη διαφανειών
- επανάληψη σχημάτων
- επανάληψη κειμένου
- συλλογή σχημάτων
- συμπίεση παρουσίασης
- κατάργηση αχρησιμοποίητων master διαφανειών
- κατάργηση αχρησιμοποίητων διαφανειών διάταξης
- συμπίεση ενσωματωμένων γραμματοσειρών
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Χρησιμοποιήστε το API χαμηλού κώδικα του Aspose.Slides σε PHP για να μετατρέψετε και να συγχωνεύσετε παρουσιάσεις, να επαναλάβετε το περιεχόμενο, να συλλέξετε σχήματα και να μειώσετε το μέγεθος της παρουσίασης."
---
## **Επισκόπηση**

Το [aspose.slides](https://reference.aspose.com/slides/el/php-java/aspose.slides/) namespace παρέχει στατικές βοηθητικές κλάσεις για κοινές λειτουργίες παρουσιάσεων. Αυτοί οι βοηθοί περιτυλίγουν συχνά χρησιμοποιούμενες ροές εργασίας του μοντέλου αντικειμένων σε εστιασμένες μεθόδους, ώστε να μπορείτε να μετατρέπετε ή να συγχωνεύετε αρχεία, να επεξεργάζεστε στοιχεία παρουσίασης, να συλλέγετε σχήματα και να αφαιρείτε αχρησιμοποίητο περιεχόμενο με λιγότερο κώδικα.

Οι βοηθοί χαμηλού κώδικα είναι πιο χρήσιμοι όταν η λειτουργία εφαρμόζεται σε ολόκληρο το αρχείο ή την παρουσίαση και η προεπιλεγμένη ροή εργασίας ταιριάζει στις απαιτήσεις σας. Χρησιμοποιήστε το πλήρες [Aspose.Slides object model](https://reference.aspose.com/slides/el/php-java/aspose.slides/) όταν χρειάζεστε λεπτομερή έλεγχο των μεμονωμένων διαφανειών, master, διατάξεων, σχημάτων, ρυθμίσεων εξαγωγής ή σχέσεων μεταξύ στοιχείων παρουσίασης.

Ο παρακάτω πίνακας συνοψίζει τους διαθέσιμους βοηθούς:

| Βοηθός | Χρησιμοποιήστε το για |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/el/php-java/aspose.slides/convert/) | Μετατροπή μιας παρουσίασης σε άλλη μορφή με άμεση κλήση αρχείου‑σε‑αρχείο. |
| [Merger](https://reference.aspose.com/slides/el/php-java/aspose.slides/merger/) | Συνένωση πλήρων αρχείων παρουσίασης του ίδιου τύπου. |
| [ForEach_](https://reference.aspose.com/slides/el/php-java/aspose.slides/foreach_/) | Εκτέλεση κλήσης επιστροφής για κάθε διαφάνεια, σχήμα, παράγραφο ή τμήμα κειμένου. |
| [Collect](https://reference.aspose.com/slides/el/php-java/aspose.slides/collect/) | Ανάκτηση σχημάτων από ολόκληρη την παρουσίαση για επαναλαμβανόμενη επεξεργασία ή ανάλυση. |
| [Compress](https://reference.aspose.com/slides/el/php-java/aspose.slides/compress/) | Αφαίρεση αχρησιμοποίητων master και διατάξεων και μείωση ενσωματωμένων δεδομένων γραμματοσειράς. |

## **Μετατροπή Παρουσίασης**

Χρησιμοποιήστε [Convert::autoByExtension](https://reference.aspose.com/slides/el/php-java/aspose.slides/convert/#autoByExtension) όταν η επέκταση του αρχείου εξόδου είναι επαρκής για την επιλογή της μορφής εξαγωγής. Η μέθοδος ανοίγει την πηγή παρουσίασης, καθορίζει τη ζητούμενη μορφή από τη διαδρομή εξόδου και γράφει το αποτέλεσμα.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

Η κλάση [Convert](https://reference.aspose.com/slides/el/php-java/aspose.slides/convert/) παρέχει επίσης αφιερωμένες μεθόδους για έξοδο PDF, SVG, JPEG, PNG και TIFF. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να ελέγξετε ή να τροποποιήσετε την παρουσίαση πριν την εξαγωγή ή να ρυθμίσετε μια επιλογή εξαγωγής που δεν εκτίθεται από τον βοηθό. Δείτε το [Convert Presentation](/php-java/convert-presentation/) για ροές εργασίας και επιλογές ανά μορφή.

## **Συγχώνευση Παρουσιάσεων**

Χρησιμοποιήστε [Merger::process](https://reference.aspose.com/slides/el/php-java/aspose.slides/merger/#process) για να συνδυάσετε πλήρη αρχεία παρουσίασης με μία κλήση. Οι εισερχόμενες παρουσιάσεις πρέπει να έχουν την ίδια μορφή αρχείου.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

Ο βοηθός είναι κατάλληλος όταν όλες οι διαφάνειες πρέπει να προσαρτηθούν σε ένα αποτέλεσμα χωρίς να τις επιλέξετε ή να τις αντιστοιχίσετε ξεχωριστά. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να συγχωνεύσετε επιλεγμένες διαφάνειες, να εφαρμόσετε προορισμό master ή διάταξης, να διατηρήσετε τις ενότητες ρητά ή να εξισορροπήσετε διαφορετικά μεγέθη διαφανειών. Δείτε το [Merge Presentations](/php-java/merge-presentation/) για αυτές τις περιπτώσεις.

## **Επανάληψη Στοιχείων Παρουσίασης**

Η κλάση [ForEach_](https://reference.aspose.com/slides/el/php-java/aspose.slides/foreach_/) καλεί μια συνάρτηση επιστροφής για κάθε ζητούμενο τύπο στοιχείου παρουσίασης. Αποφεύγει εσωτερικούς βρόχους συλλογών και είναι βολική για έλεγχο ή αλλαγές μορφοποίησης σε όλη την παρουσίαση.

Το παρακάτω παράδειγμα χρησιμοποιεί [ForEach_::slide](https://reference.aspose.com/slides/el/php-java/aspose.slides/foreach_/#slide), [ForEach_::shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/foreach_/#paragraph) και [ForEach_::portion](https://reference.aspose.com/slides/el/php-java/aspose.slides/foreach_/#portion) για να ελέγξει τα αντίστοιχα στοιχεία:

```php
use aspose\slides\ForEach_;
use aspose\slides\Presentation;

class SlideCallback {
    public function invoke($slide, $index): void {
        $slideIndex = java_values($index);
        $shapeCount = java_values($slide->getShapes()->size());
        echo sprintf("Slide %d: %d shapes", $slideIndex, $shapeCount) . PHP_EOL;
    }
}

class ShapeCallback {
    public function invoke($shape, $slide, $index): void {
        $shapeIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $shapeName = java_values($shape->getName());
        echo sprintf("Shape %d on %s: %s", $shapeIndex, $slideType, $shapeName) . PHP_EOL;
    }
}

class ParagraphCallback {
    public function invoke($paragraph, $slide, $index): void {
        $paragraphIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($paragraph->getText());
        echo sprintf("Paragraph %d on %s: %s", $paragraphIndex, $slideType, $text) . PHP_EOL;
    }
}

class PortionCallback {
    public function invoke($portion, $paragraph, $slide, $index): void {
        $portionIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($portion->getText());
        echo sprintf("Portion %d on %s: %s", $portionIndex, $slideType, $text) . PHP_EOL;
    }
}

$presentation = new Presentation("input.pptx");
try {
    $slideCallback = java_closure(new SlideCallback(), null, java('com.aspose.slides.ForEach_$ForEachSlideCallback'));
    $shapeCallback = java_closure(new ShapeCallback(), null, java('com.aspose.slides.ForEach_$ForEachShapeCallback'));
    $paragraphCallback = java_closure(new ParagraphCallback(), null, java('com.aspose.slides.ForEach_$ForEachParagraphCallback'));
    $portionCallback = java_closure(new PortionCallback(), null, java('com.aspose.slides.ForEach_$ForEachPortionCallback'));

    ForEach_::slide($presentation, $slideCallback);
    ForEach_::shape($presentation, $shapeCallback);
    ForEach_::paragraph($presentation, $paragraphCallback);
    ForEach_::portion($presentation, $portionCallback);
} finally {
    $presentation->dispose();
}
```

Από προεπιλογή, η διερεύνηση σχημάτων και κειμένου σε όλη την παρουσίαση περιλαμβάνει κανονικές, master και layout διαφάνειες. Οι υπερφορτώσεις με παράμετρο `includeNotes` μπορούν επίσης να επεξεργαστούν διαφάνειες σημειώσεων. Χρησιμοποιήστε άμεσους βρόχους συλλογών όταν η σειρά διάσχισης, η πρώιμη έξοδος, το φιλτράρισμα πριν την κλήση ή ο λεπτομερής έλεγχος γονέα‑παιδιού είναι σημαντικά.

## **Συλλογή Σχημάτων**

Χρησιμοποιήστε [Collect::shapes](https://reference.aspose.com/slides/el/php-java/aspose.slides/collect/#shapes) όταν χρειάζεστε μια συλλογή όλων των σχημάτων σε μια παρουσίαση αντί για κλήση επιστροφής για κάθε σχήμα. Αυτό είναι χρήσιμο όταν το ίδιο σύνολο θα φιλτράρεται, θα μετράται ή θα υποβάλλεται σε επεξεργασία περισσότερες από μία φορές.

```php
use aspose\slides\Collect;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $shapes = Collect::shapes($presentation);

    foreach ($shapes as $shape) {
        $shapeName = java_values($shape->getName());
        $shapeType = java_values($shape->getClass()->getSimpleName());
        echo sprintf("%s: %s", $shapeName, $shapeType) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Χρησιμοποιήστε [ForEach_::shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/foreach_/#shape) αντί για αυτό όταν κάθε σχήμα μπορεί να επεξεργαστεί αμέσως και δεν χρειάζεστε τη διατήρηση του συλλεγμένου αποτελέσματος.

## **Συμπίεση Περιεχομένου Παρουσίασης**

Η κλάση [Compress](https://reference.aspose.com/slides/el/php-java/aspose.slides/compress/) μπορεί να αφαιρέσει αχρησιμοποίητα δομικά στοιχεία και να μειώσει τα ενσωματωμένα δεδομένα γραμματοσειράς:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) αφαιρεί διαφάνειες διάταξης που δεν αναφέρονται από καμία κανονική διαφάνεια.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/compress/#removeUnusedMasterSlides) αφαιρεί master διαφάνειες που δεν χρησιμοποιούνται πλέον.
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/el/php-java/aspose.slides/compress/#compressEmbeddedFonts) αφαιρεί αχρησιμοποίητους χαρακτήρες από ενσωματωμένες γραμματοσειρές.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    Compress::removeUnusedMasterSlides($presentation);
    Compress::compressEmbeddedFonts($presentation);

    $presentation->save("compressed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Καταργήστε πρώτα τις αχρησιμοποίητες διατάξεις πριν τις αχρησιμοποίητες master, ώστε μια master που καταστεί ακατάστατη μετά τον καθαρισμό διατάξεων να μπορεί επίσης να αφαιρεθεί. Αποθηκεύστε την βελτιστοποιημένη παρουσίαση σε νέο αρχείο εάν ενδεχομένως χρειαστείτε αργότερα τις αρχικές master, διατάξεις ή το πλήρες ενσωματωμένο σύνολο γραμματοσειρών. Για περισσότερες λεπτομέρειες, δείτε το [Slide Master](/php-java/slide-master/) και το [Embedded Font](/php-java/embedded-font/).

## **Συχνές Ερωτήσεις**

**Πότε θα πρέπει να χρησιμοποιήσω το low‑code API αντί για το πλήρες μοντέλο αντικειμένων;**

Χρησιμοποιήστε τους βοηθούς χαμηλού κώδικα όταν μια τυπική λειτουργία εφαρμόζεται σε πλήρες αρχείο ή παρουσίαση και δεν απαιτεί λεπτομερή έλεγχο των μεμονωμένων στοιχείων. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να επιλέξετε συγκεκριμένες διαφάνειες, να ελέγξετε σχέσεις master‑layout, να επιθεωρήσετε ενδιάμεση κατάσταση ή να ρυθμίσετε συμπεριφορά που δεν εκτίθεται από τον βοηθό.

**Μπορεί ο Merger να συνδυάσει παρουσιάσεις διαφορετικών μορφών αρχείου;**

Όχι. Ο [Merger::process](https://reference.aspose.com/slides/el/php-java/aspose.slides/merger/#process) απαιτεί οι εισερχόμενες παρουσιάσεις να έχουν την ίδια μορφή. Μετατρέψτε πρώτα τα αρχεία εισόδου σε κοινή μορφή, π.χ. με το [Convert::autoByExtension](https://reference.aspose.com/slides/el/php-java/aspose.slides/convert/#autoByExtension), και έπειτα συγχωνεύστε τα μετατρεφθέντα αρχεία.

**Επεξεργάζεται το ForEach_ master, layout και διαφάνειες σημειώσεων;**

Το [ForEach_::slide](https://reference.aspose.com/slides/el/php-java/aspose.slides/foreach_/#slide) διατρέχει τις κανονικές διαφάνειες παρουσίασης. Οι λειτουργίες [ForEach_::shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/foreach_/#paragraph) και [ForEach_::portion](https://reference.aspose.com/slides/el/php-java/aspose.slides/foreach_/#portion) σε όλη την παρουσίαση περιλαμβάνουν κανονικές, master και layout διαφάνειες από προεπιλογή. Χρησιμοποιήστε τις υπερφορτώσεις τους με `includeNotes` ορισμένο σε `true` για να συμπεριλάβετε τις διαφάνειες σημειώσεων.

**Ποια είναι η διαφορά μεταξύ ForEach_::shape και Collect::shapes;**

Χρησιμοποιήστε το [ForEach_::shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/foreach_/#shape) για να επεξεργαστείτε κάθε σχήμα αμέσως μέσω κλήσης επιστροφής. Χρησιμοποιήστε το [Collect::shapes](https://reference.aspose.com/slides/el/php-java/aspose.slides/collect/#shapes) όταν χρειάζεστε ένα επαναχρησιμοποιήσιμο αποτέλεσμα που μπορεί να διατηρηθεί, φιλτραριστεί, μετρηθεί ή διασχιθεί πολλαπλές φορές.

**Καταφέρνει πάντα η Compress να μειώσει το μέγεθος του αρχείου παρουσίασης;**

Δεν είναι απαραίτητο. Το αποτέλεσμα εξαρτάται από το αν η παρουσίαση περιέχει αχρησιμοποίητες διατάξεις, αχρησιμοποίητους master ή ενσωματωμένες γραμματοσειρές με αχρησιμοποίητους χαρακτήρες. Εάν δεν υπάρχουν τέτοια στοιχεία, οι αντίστοιχες λειτουργίες [Compress](https://reference.aspose.com/slides/el/php-java/aspose.slides/compress/) μπορεί να μην μειώσουν το μέγεθος του αρχείου.

**Αποθηκεύονται αυτόματα οι αλλαγές που γίνονται από το ForEach_ ή το Compress;**

Όχι. Αυτοί οι βοηθοί λειτουργούν πάνω στο φορτωμένο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) στη μνήμη. Αφού τροποποιήσετε στοιχεία σε κλήση επιστροφής [ForEach_] ή εκτελέσετε το [Compress], καλέστε το [Presentation::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#save) για να γράψετε το αποτέλεσμα.

## **Σχετικά Άρθρα**

- [Convert Presentation](/php-java/convert-presentation/)
- [Merge Presentations](/php-java/merge-presentation/)
- [Slide Master](/php-java/slide-master/)
- [Manage Text Box](/php-java/manage-textbox/)
- [Embedded Font](/php-java/embedded-font/)