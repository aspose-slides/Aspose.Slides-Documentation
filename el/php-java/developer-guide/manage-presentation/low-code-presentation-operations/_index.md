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
- αφαίρεση αχρησιμοποίητων master διαφανειών
- αφαίρεση αχρησιμοποίητων διατάξεων διαφανειών
- συμπίεση ενσωματωμένων γραμματοσειρών
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Χρησιμοποιήστε το API χαμηλού κώδικα του Aspose.Slides σε PHP για να μετατρέπετε και να συγχωνεύετε παρουσιάσεις, να επαναλαμβάνετε το περιεχόμενο, να συλλέγετε σχήματα και να μειώνετε το μέγεθος της παρουσίασης."
---
## **Επισκόπηση**

Το όνομα χώρου [aspose.slides](https://reference.aspose.com/slides/el/php-java/aspose.slides/) παρέχει στατικές βοηθητικές κλάσεις για κοινές λειτουργίες παρουσιάσεων. Αυτές οι βοηθοί περιτυλίγουν συχνά χρησιμοποιούμενες ροές εργασίας του μοντέλου αντικειμένων σε εστιασμένες μεθόδους, ώστε να μπορείτε να μετατρέπετε ή να συγχωνεύετε αρχεία, να επεξεργάζεστε στοιχεία παρουσίασης, να συλλέγετε σχήματα και να αφαιρείτε αχρησιμοποίητο περιεχόμενο με λιγότερο κώδικα.

Οι βοηθοί χαμηλού κώδικα είναι πιο χρήσιμοι όταν η λειτουργία εφαρμόζει σε ολόκληρο το αρχείο ή την παρουσίαση και η προεπιλεγμένη ροή εργασίας ταιριάζει με τις απαιτήσεις σας. Χρησιμοποιήστε το πλήρες [Aspose.Slides object model](https://reference.aspose.com/slides/el/php-java/aspose.slides/) όταν χρειάζεστε λεπτομερή έλεγχο των μεμονωμένων διαφανειών, master, διατάξεων, σχημάτων, ρυθμίσεων εξαγωγής ή σχέσεων μεταξύ στοιχείων παρουσίασης.

Ο παρακάτω πίνακας συνοψίζει τους διαθέσιμους βοηθούς:

| Βοηθός | Χρήση |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/el/php-java/aspose.slides/convert/) | Μετατροπή μιας παρουσίασης σε άλλη μορφή με απλή κλήση αρχείου‑σε‑αρχείο. |
| [Merger](https://reference.aspose.com/slides/el/php-java/aspose.slides/merger/) | Συνένωση πλήρων αρχείων παρουσίασης της ίδιας μορφής. |
| [ForEach_](https://reference.aspose.com/slides/el/php-java/aspose.slides/foreach_/) | Εκτέλεση callback για κάθε διαφάνεια, σχήμα, παράγραφο ή τμήμα κειμένου. |
| [Collect](https://reference.aspose.com/slides/el/php-java/aspose.slides/collect/) | Ανάκτηση σχημάτων από ολόκληρη την παρουσίαση για επαναλαμβανόμενη επεξεργασία ή ανάλυση. |
| [Compress](https://reference.aspose.com/slides/el/php-java/aspose.slides/compress/) | Αφαίρεση αχρησιμοποίητων master και διατάξεων και μείωση ενσωματωμένων δεδομένων γραμματοσειρών. |

## **Μετατροπή Παρουσίασης**

Χρησιμοποιήστε το [Convert::autoByExtension](https://reference.aspose.com/slides/el/php-java/aspose.slides/convert/#autoByExtension) όταν η κατάληξη του αρχείου εξόδου είναι επαρκής για την επιλογή της μορφής εξαγωγής. Η μέθοδος ανοίγει την πηγή παρουσίασης, καθορίζει τη ζητούμενη μορφή από τη διαδρομή εξόδου και γράφει το αποτέλεσμα.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

Η κλάση [Convert](https://reference.aspose.com/slides/el/php-java/aspose.slides/convert/) παρέχει επίσης ειδικές μεθόδους για έξοδο PDF, SVG, JPEG, PNG και TIFF. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να εξετάσετε ή να τροποποιήσετε την παρουσίαση πριν από την εξαγωγή ή να ρυθμίσετε μια επιλογή εξαγωγής που δεν εκτίθεται από τον επιλεγμένο βοηθό. Δείτε το άρθρο [Convert Presentation](/slides/el/php-java/convert-presentation/) για ροές εργασίας και επιλογές συγκεκριμένων μορφών.

## **Συνένωση Παρουσιάσεων**

Χρησιμοποιήστε το [Merger::process](https://reference.aspose.com/slides/el/php-java/aspose.slides/merger/#process) για να συνδυάσετε πλήρη αρχεία παρουσίασης με μία κλήση. Οι εισερχόμενες παρουσιάσεις πρέπει να έχουν την ίδια μορφή αρχείου.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

Ο βοηθός είναι κατάλληλος όταν όλες οι διαφάνειες πρέπει να προσαρτηθούν σε ένα αποτέλεσμα χωρίς να χρειάζεται η ατομική επιλογή ή αντιστοίχηση τους. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να συγχωνεύσετε επιλεγμένες διαφάνειες, να εφαρμόσετε προορισμό master ή διάταξης, να διατηρήσετε ενότητες ρητά ή να εναρμονίσετε διαφορετικά μεγέθη διαφάνειας. Δείτε το άρθρο [Merge Presentations](/slides/el/php-java/merge-presentation/) για αυτές τις περιπτώσεις.

## **Επανάληψη Στοιχείων Παρουσίασης**

Η κλάση [ForEach_](https://reference.aspose.com/slides/el/php-java/aspose.slides/foreach_/) καλεί ένα callback για κάθε ζητούμενο τύπο στοιχείου παρουσίασης. Αποφεύγει τις εμφωλευμένες βρόχους συλλογής και είναι βολική για ολική επιθεώρηση ή αλλαγές μορφοποίησης.

Το παρακάτω παράδειγμα χρησιμοποιεί [ForEach_::slide](https://reference.aspose.com/slides/el/php-java/aspose.slides/foreach_/#slide), [ForEach_::shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/foreach_/#paragraph) και [ForEach_::portion](https://reference.aspose.com/slides/el/php-java/aspose.slides/foreach_/#portion) για να ελέγξουν τα αντίστοιχα στοιχεία:

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

Από προεπιλογή, η διαδρομή σχήματος και κειμένου σε όλη την παρουσίαση περιλαμβάνει κανονικές, master και διατάξεις διαφάνειες. Οι υπερφορτώσεις με παράμετρο `includeNotes` μπορούν επίσης να επεξεργαστούν διαφάνειες σημειώσεων. Χρησιμοποιήστε απλούς βρόχους συλλογής όταν η σειρά διαδρομής, η πρώιμη έξοδος, το φιλτράρισμα πριν την κλήση του callback ή ο λεπτομερής έλεγχος γονέα‑παιδιού είναι σημαντικά.

## **Συλλογή Σχημάτων**

Χρησιμοποιήστε το [Collect::shapes](https://reference.aspose.com/slides/el/php-java/aspose.slides/collect/#shapes) όταν χρειάζεστε μια συλλογή όλων των σχημάτων σε μια παρουσίαση αντί για callback για κάθε σχήμα. Αυτό είναι χρήσιμο όταν το ίδιο σύνολο θα φιλτραριστεί, θα μετρηθεί ή θα επεξεργαστεί περισσότερες φορές.

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

Χρησιμοποιήστε το [ForEach_::shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/foreach_/#shape) αντ' αυτού όταν κάθε σχήμα μπορεί να επεξεργαστεί αμέσως και δεν χρειάζεται να διατηρηθεί το συλλεγμένο αποτέλεσμα.

## **Συμπίεση Περιεχομένου Παρουσίασης**

Η κλάση [Compress](https://reference.aspose.com/slides/el/php-java/aspose.slides/compress/) μπορεί να αφαιρέσει αχρησιμοποίητα δομικά στοιχεία και να μειώσει τα ενσωματωμένα δεδομένα γραμματοσειρών:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) αφαιρεί διατάξεις που δεν αναφέρονται από καμία κανονική διαφάνεια.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/compress/#removeUnusedMasterSlides) αφαιρεί master που δεν χρησιμοποιούνται πλέον.
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

Αφαιρέστε πρώτα τις αχρησιμοποίητες διατάξεις πριν τα αχρησιμοποίητα master, ώστε ένα master που γίνει αδέσμευτο μετά τον καθαρισμό των διατάξεων να μπορεί επίσης να αφαιρεθεί. Αποθηκεύστε την βελτιστοποιημένη παρουσίαση σε νέο αρχείο αν μπορεί να χρειαστείτε αργότερα τα αρχικά master, διατάξεις ή πλήρη ενσωματωμένα δεδομένα γραμματοσειρών. Για περισσότερα, δείτε το [Slide Master](/slides/el/php-java/slide-master/) και το [Embedded Font](/slides/el/php-java/embedded-font/).

## **Συχνές Ερωτήσεις**

**Πότε πρέπει να χρησιμοποιήσω το API χαμηλού κώδικα αντί του πλήρους μοντέλου αντικειμένων;**

Χρησιμοποιήστε τους βοηθούς χαμηλού κώδικα όταν μια τυπική λειτουργία εφαρμόζεται σε πλήρες αρχείο ή παρουσίαση και δεν απαιτεί λεπτομερή έλεγχο των μεμονωμένων στοιχείων. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να επιλέξετε συγκεκριμένες διαφάνειες, να ελέγξετε σχέσεις master‑layout, να επεξεργαστείτε ενδιάμεση κατάσταση ή να ρυθμίσετε συμπεριφορά που ο βοηθός δεν εκθέτει.

**Μπορεί ο Merger να συνδυάσει παρουσιάσεις σε διαφορετικές μορφές αρχείου;**

Όχι. Το [Merger::process](https://reference.aspose.com/slides/el/php-java/aspose.slides/merger/#process) απαιτεί εισερχόμενες παρουσιάσεις στην ίδια μορφή. Μετατρέψτε πρώτα τα αρχεία εισόδου σε κοινή μορφή, για παράδειγμα με το [Convert::autoByExtension](https://reference.aspose.com/slides/el/php-java/aspose.slides/convert/#autoByExtension), και μετά συγχωνεύστε τα μετατραπέντα αρχεία.

**Το ForEach_ επεξεργάζεται master, layout και notes διαφάνειες;**

Το [ForEach_::slide](https://reference.aspose.com/slides/el/php-java/aspose.slides/foreach_/#slide) επαναλαμβάνει τις κανονικές διαφάνειες παρουσίασης. Οι λειτουργίες [ForEach_::shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/foreach_/#paragraph) και [ForEach_::portion](https://reference.aspose.com/slides/el/php-java/aspose.slides/foreach_/#portion) σε ολόκληρη την παρουσίαση περιλαμβάνουν από προεπιλογή κανονικές, master και layout διαφάνειες. Χρησιμοποιήστε τις υπερφορτώσεις τους με `includeNotes` ορισμένο σε `true` για να συμπεριλάβετε και τις notes διαφάνειες.

**Ποια είναι η διαφορά μεταξύ ForEach_::shape και Collect::shapes;**

Χρησιμοποιήστε το [ForEach_::shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/foreach_/#shape) για να επεξεργαστείτε κάθε σχήμα αμέσως μέσω ενός callback. Χρησιμοποιήστε το [Collect::shapes](https://reference.aspose.com/slides/el/php-java/aspose.slides/collect/#shapes) όταν χρειάζεστε ένα επαναχρησιμοποιήσιμο αποτέλεσμα που μπορεί να διατηρηθεί, φιλτραριστεί, μετρηθεί ή διασχιστεί πολλές φορές.

**Η Compress κάνει πάντα το αρχείο παρουσίασης μικρότερο;**

Δεν είναι απαραίτητα. Το αποτέλεσμα εξαρτάται από το εάν η παρουσίαση περιέχει αχρησιμοποίητες διατάξεις, αχρησιμοποίητα master ή ενσωματωμένες γραμματοσειρές με αχρησιμοποίητους χαρακτήρες. Εάν δεν υπάρχουν, οι αντίστοιχες λειτουργίες [Compress](https://reference.aspose.com/slides/el/php-java/aspose.slides/compress/) μπορεί να μην μειώσουν το μέγεθος του αρχείου.

**Αποθηκεύονται αυτόματα οι αλλαγές που κάνει το ForEach_ ή το Compress;**

Όχι. Οι βοηθοί αυτοί λειτουργούν στο φορτωμένο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) στη μνήμη. Μετά την αλλαγή στοιχείων σε ένα callback του [ForEach_](https://reference.aspose.com/slides/el/php-java/aspose.slides/foreach_/) ή την εκτέλεση του [Compress](https://reference.aspose.com/slides/el/php-java/aspose.slides/compress/), καλέστε το [Presentation::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#save) για να γράψετε το αποτέλεσμα.

## **Σχετικά Άρθρα**

- [Convert Presentation](/slides/el/php-java/convert-presentation/)
- [Merge Presentations](/slides/el/php-java/merge-presentation/)
- [Slide Master](/slides/el/php-java/slide-master/)
- [Manage Text Box](/slides/el/php-java/manage-textbox/)
- [Embedded Font](/slides/el/php-java/embedded-font/)