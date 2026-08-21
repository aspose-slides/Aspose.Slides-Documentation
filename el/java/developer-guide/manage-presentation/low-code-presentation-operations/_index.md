---
title: Χαμηλού Κώδικα Λειτουργίες Παρουσίασης σε Java
linktitle: Χαμηλού Κώδικα API
type: docs
weight: 50
url: /el/java/low-code-presentation-operations/
keywords:
- API χαμηλού κώδικα παρουσίασης
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
- Java
- Aspose.Slides
description: "Χρησιμοποιήστε το API χαμηλού κώδικα Aspose.Slides σε Java για να μετατρέψετε και να συγχωνεύσετε παρουσιάσεις, να επαναλάβετε το περιεχόμενο, να συλλέξετε σχήματα και να μειώσετε το μέγεθος της παρουσίασης."
---
## **Επισκόπηση**

Το πακέτο [com.aspose.slides](https://reference.aspose.com/slides/el/java/com.aspose.slides/) παρέχει στατικές βοηθητικές κλάσεις για κοινές λειτουργίες παρουσίασης. Αυτές οι βοηθητικές κλάσεις περιτυλίγουν συχνά χρησιμοποιούμενες ροές εργασίας του μοντέλου αντικειμένων σε εστιασμένες μεθόδους, ώστε να μπορείτε να μετατρέπετε ή να συγχωνεύετε αρχεία, να επεξεργάζεστε στοιχεία παρουσίασης, να συλλέγετε σχήματα και να αφαιρείτε αχρησιμοποίητο περιεχόμενο με λιγότερο κώδικα.

Οι βοηθητικές κλάσεις χαμηλού κώδικα είναι πιο χρήσιμες όταν η λειτουργία εφαρμόζεται σε ολόκληρο το αρχείο ή την παρουσίαση και η προεπιλεγμένη ροή εργασίας ταιριάζει με τις απαιτήσεις σας. Χρησιμοποιήστε το πλήρες [Aspose.Slides object model](https://reference.aspose.com/slides/el/java/com.aspose.slides/) όταν χρειάζεστε λεπτομερή έλεγχο πάνω σε μεμονωμένες διαφάνειες, master, διατάξεις, σχήματα, ρυθμίσεις εξαγωγής ή σχέσεις μεταξύ των στοιχείων παρουσίασης.

Ο παρακάτω πίνακας συνοψίζει τις διαθέσιμες βοηθητικές κλάσεις:

| Βοηθός | Χρήση |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/el/java/com.aspose.slides/convert/) | Μετατροπή μιας παρουσίασης σε άλλη μορφή με απευθείας κλήση αρχείου-σε-αρχείο. |
| [Merger](https://reference.aspose.com/slides/el/java/com.aspose.slides/merger/) | Συνδυασμός ολοκληρωμένων αρχείων παρουσίασης του ίδιου τύπου. |
| [ForEach](https://reference.aspose.com/slides/el/java/com.aspose.slides/foreach/) | Εκτέλεση μιας ενέργειας για κάθε διαφάνεια, σχήμα, παράγραφο ή τμήμα κειμένου. |
| [Collect](https://reference.aspose.com/slides/el/java/com.aspose.slides/collect/) | Ανάκτηση σχημάτων από ολόκληρη την παρουσίαση για επαναληπτική επεξεργασία ή ανάλυση. |
| [Compress](https://reference.aspose.com/slides/el/java/com.aspose.slides/compress/) | Αφαίρεση αχρησιμοποίητων master και διατάξεων και μείωση των ενσωματωμένων δεδομένων γραμματοσειράς. |

## **Μετατροπή Παρουσίασης**

Χρησιμοποιήστε το [Convert.autoByExtension](https://reference.aspose.com/slides/el/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) όταν η επέκταση του αρχείου εξόδου είναι επαρκής για την επιλογή του μορφότυπου εξαγωγής. Η μέθοδος ανοίγει την πηγή παρουσίασης, καθορίζει το απαιτούμενο μορφότυπο από τη διαδρομή εξόδου και γράφει το αποτέλεσμα.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

Η κλάση [Convert](https://reference.aspose.com/slides/el/java/com.aspose.slides/convert/) παρέχει επίσης ειδικές μεθόδους για εξαγωγή σε PDF, SVG, JPEG, PNG και TIFF. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να ελέγξετε ή να τροποποιήσετε την παρουσίαση πριν από την εξαγωγή ή να διαμορφώσετε μια επιλογή εξαγωγής που δεν εκτίθεται από την επιλεγμένη βοηθητική κλάση. Δείτε το [Convert Presentation](/java/convert-presentation/) για ροές εργασίας και επιλογές συγκεκριμένου μορφότυπου.

## **Συγχώνευση Παρουσιάσεων**

Χρησιμοποιήστε το [Merger.process](https://reference.aspose.com/slides/el/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) για να συγχωνεύσετε ολοκληρωμένα αρχεία παρουσίασης με μία κλήση. Οι εισερχόμενες παρουσιάσεις πρέπει να έχουν τον ίδιο τύπο αρχείου.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Η βοηθητική κλάση είναι κατάλληλη όταν όλες οι διαφάνειες πρέπει να προσαρτηθούν σε ένα αποτέλεσμα χωρίς να επιλέγονται ή να αντιστοιχίζονται ξεχωριστά. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να συγχωνεύσετε επιλεγμένες διαφάνειες, να εφαρμόσετε έναν προορισμό master ή διάταξη, να διατηρήσετε ρητά ενότητες ή να εναρμονίσετε διαφορετικά μεγέθη διαφάνειας. Δείτε το [Merge Presentations](/java/merge-presentation/) για αυτές τις περιπτώσεις.

## **Επανάληψη Στοιχείων Παρουσίασης**

Η κλάση [ForEach](https://reference.aspose.com/slides/el/java/com.aspose.slides/foreach/) καλεί μια επιστροφή κλήσης για κάθε ζητούμενο τύπο στοιχείου παρουσίασης. Αποφεύγει τις ενσωματωμένες βρόχους συλλογής και είναι βολική για ολική επιθεώρηση ή αλλαγές μορφοποίησης της παρουσίασης.

Το παρακάτω παράδειγμα χρησιμοποιεί τα [ForEach.slide](https://reference.aspose.com/slides/el/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/el/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/el/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), και [ForEach.portion](https://reference.aspose.com/slides/el/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) για να επιθεωρήσετε τα αντίστοιχα στοιχεία:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ForEach.slide(presentation, (slide, index) -> {
        System.out.println(String.format("Slide %d: %d shapes", index, slide.getShapes().size()));
    });

    ForEach.shape(presentation, (shape, slide, index) -> {
        System.out.println(String.format("Shape %d on %s: %s", index, slide.getClass().getSimpleName(), shape.getName()));
    });

    ForEach.paragraph(presentation, (paragraph, slide, index) -> {
        System.out.println(String.format("Paragraph %d on %s: %s", index, slide.getClass().getSimpleName(), paragraph.getText()));
    });

    ForEach.portion(presentation, (portion, paragraph, slide, index) -> {
        System.out.println(String.format("Portion %d on %s: %s", index, slide.getClass().getSimpleName(), portion.getText()));
    });
} finally {
    presentation.dispose();
}
```

Από προεπιλογή, η παρακολούθηση σχήματος και κειμένου σε όλη την παρουσίαση περιλαμβάνει κανονικές, master και διατάξεις διαφάνειες. Οι υπερφορτώσεις με παράμετρο `includeNotes` μπορούν επίσης να επεξεργαστούν διαφάνειες σημειώσεων. Χρησιμοποιήστε άμεσους βρόχους συλλογής όταν είναι σημαντική η σειρά επανάληψης, η πρόωρη έξοδος, η φιλτράρισμα πριν την κλήση της επιστροφής ή ο λεπτομερής έλεγχος γονέα-παιδικού στοιχείου.

## **Συλλογή Σχημάτων**

Χρησιμοποιήτε το [Collect.shapes](https://reference.aspose.com/slides/el/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) όταν χρειάζεστε μια συλλογή όλων των σχημάτων σε μια παρουσίαση αντί για επιστροφή κλήσης για κάθε σχήμα. Αυτό είναι χρήσιμο όταν το ίδιο σύνολο θα φιλτραριστεί, μετρηθεί ή επεξεργαστεί επανειλημμένα.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Iterable<Shape> shapes = Collect.shapes(presentation);

    for (Shape shape : shapes) {
        System.out.println(String.format("%s: %s", shape.getName(), shape.getClass().getSimpleName()));
    }
} finally {
    presentation.dispose();
}
```

Χρησιμοποιήστε το [ForEach.shape](https://reference.aspose.com/slides/el/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) αντ' αυτού όταν κάθε σχήμα μπορεί να επεξεργαστεί άμεσα και δεν χρειάζεται να διατηρηθεί το συλλεγμένο αποτέλεσμα.

## **Συμπίεση Περιεχομένου Παρουσίασης**

Η κλάση [Compress](https://reference.aspose.com/slides/el/java/com.aspose.slides/compress/) μπορεί να αφαιρέσει αχρησιμοποίητα δομικά στοιχεία και να μειώσει τα ενσωματωμένα δεδομένα γραμματοσειράς:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) αφαιρεί διαφάνειες διάταξης που δεν αναφέρονται από καμία κανονική διαφάνεια.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) αφαιρεί master διαφάνειες που δεν χρησιμοποιούνται πια.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/el/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) αφαιρεί αχρησιμοποίητους χαρακτήρες από τις ενσωματωμένες γραμματοσειρές.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    Compress.removeUnusedMasterSlides(presentation);
    Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Αφαιρέστε πρώτα τις αχρησιμοποίητες διατάξεις πριν από τα αχρησιμοποίητα master, ώστε ένα master που γίνεται αβάσιμο μετά τον καθαρισμό των διατάξεων να μπορεί επίσης να αφαιρεθεί. Αποθηκεύστε την βελτιστοποιημένη παρουσίαση σε νέο αρχείο εάν μπορεί να χρειαστείτε αργότερα τα αρχικά master, διατάξεις ή πλήρη ενσωματωμένα δεδομένα γραμματοσειράς. Για περισσότερες λεπτομέρειες, δείτε το [Slide Master](/java/slide-master/) και το [Embedded Font](/java/embedded-font/).

## **Συχνές Ερωτήσεις**

**Πότε πρέπει να χρησιμοποιήσω το low-code API αντί του πλήρους μοντέλου αντικειμένων;**

Χρησιμοποιήστε τις βοηθητικές κλάσεις χαμηλού κώδικα όταν μια τυπική λειτουργία εφαρμόζεται σε ολοκληρωμένο αρχείο ή παρουσίαση και δεν απαιτεί λεπτομερή έλεγχο των μεμονωμένων στοιχείων. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να επιλέξετε συγκεκριμένες διαφάνειες, να ελέγξετε τις σχέσεις master και διάταξης, να επιθεωρήσετε την ενδιάμεση κατάσταση ή να διαμορφώσετε συμπεριφορά που δεν εκτίθεται από τη βοηθητική κλάση.

**Μπορεί το Merger να συνδυάσει παρουσιάσεις σε διαφορετικούς τύπους αρχείων;**

Όχι. Το [Merger.process](https://reference.aspose.com/slides/el/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) απαιτεί οι εισερχόμενες παρουσιάσεις να είναι του ίδιου τύπου. Μετατρέψτε πρώτα τα αρχεία εισόδου σε κοινό τύπο, π.χ. με το [Convert.autoByExtension](https://reference.aspose.com/slides/el/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), και στη συνέχεια συγχωνεύστε τα μετατρεπόμενα αρχεία.

**Επεξεργάζεται το ForEach master, layout και διαφάνειες σημειώσεων;**

Το [ForEach.slide](https://reference.aspose.com/slides/el/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) επαναλαμβάνει τις κανονικές διαφάνειες παρουσίασης. Η ολική [ForEach.shape](https://reference.aspose.com/slides/el/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/el/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), και [ForEach.portion](https://reference.aspose.com/slides/el/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) περιλαμβάνουν κανονικές, master και διατάξεις διαφάνειες από προεπιλογή. Χρησιμοποιήστε τις υπερφορτώσεις τους με `includeNotes` ορισμένο σε `true` για να συμπεριλάβετε διαφάνειες σημειώσεων.

**Ποια είναι η διαφορά μεταξύ ForEach.shape και Collect.shapes;**

Χρησιμοποιήστε το [ForEach.shape](https://reference.aspose.com/slides/el/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) για να επεξεργαστείτε κάθε σχήμα άμεσα μέσω επιστροφής κλήσης. Χρησιμοποιήστε το [Collect.shapes](https://reference.aspose.com/slides/el/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) όταν χρειάζεστε ένα επαναχρησιμοποιήσιμο αποτέλεσμα που μπορεί να διατηρηθεί, φιλτραριστεί, μετρηθεί ή επαναληφθεί πολλαπλές φορές.

**Δεν κάνει πάντα η Compress το αρχείο παρουσίασης μικρότερο;**

Δεν είναι απαραίτητα. Το αποτέλεσμα εξαρτάται από το εάν η παρουσίαση περιέχει αχρησιμοποίητες διατάξεις, αχρησιμοποίητα master ή ενσωματωμένες γραμματοσειρές με αχρησιμοποίητους χαρακτήρες. Εάν δεν υπάρχουν, οι αντίστοιχες λειτουργίες [Compress](https://reference.aspose.com/slides/el/java/com.aspose.slides/compress/) ενδέχεται να μην μειώσουν το μέγεθος του αρχείου.

**Αποθηκεύονται αυτόματα οι αλλαγές που κάνει το ForEach ή το Compress;**

Όχι. Αυτές οι βοηθητικές κλάσεις λειτουργούν πάνω στο φορτωμένο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) στη μνήμη. Μετά την αλλαγή στοιχείων σε μια κλήση [ForEach](https://reference.aspose.com/slides/el/java/com.aspose.slides/foreach/) ή την εκτέλεση του [Compress](https://reference.aspose.com/slides/el/java/com.aspose.slides/compress/), καλέστε το [Presentation.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#save-java.lang.String-int-) για να γράψετε το αποτέλεσμα.

## **Σχετικά Άρθρα**

- [Μετατροπή Παρουσίασης](/java/convert-presentation/)
- [Συγχώνευση Παρουσιάσεων](/java/merge-presentation/)
- [Slide Master](/java/slide-master/)
- [Διαχείριση Πλαισίου Κειμένου](/java/manage-textbox/)
- [Ενσωματωμένη Γραμματοσειρά](/java/embedded-font/)