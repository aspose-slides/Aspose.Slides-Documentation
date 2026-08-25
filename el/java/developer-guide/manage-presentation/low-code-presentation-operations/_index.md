---
title: Λειτουργίες Παρουσίασης Χαμηλού Κώδικα σε Java
linktitle: API Χαμηλού Κώδικα
type: docs
weight: 50
url: /el/java/low-code-presentation-operations/
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
- Java
- Aspose.Slides
description: "Χρησιμοποιήστε το API χαμηλού κώδικα Aspose.Slides σε Java για να μετατρέψετε και να συγχωνεύετε παρουσιάσεις, να επαναλαμβάνετε το περιεχόμενο, να συλλέγετε σχήματα και να μειώσετε το μέγεθος της παρουσίασης."
---
## **Επισκόπηση**

Το πακέτο [com.aspose.slides](https://reference.aspose.com/slides/el/java/com.aspose.slides/) παρέχει στατικές βοηθητικές κλάσεις για συνηθισμένες λειτουργίες παρουσίασης. Αυτοί οι βοηθοί τυλίγουν συχνά χρησιμοποιημένες ροές εργασίας αντικειμενοστραφούς μοντέλου σε εστιασμένες μεθόδους, ώστε να μπορείτε να μετατρέπετε ή να συγχωνεύετε αρχεία, να επεξεργάζεστε στοιχεία παρουσίασης, να συλλέγετε σχήματα και να αφαιρείτε αχρησιμοποίητο περιεχόμενο με λιγότερο κώδικα.

Οι βοηθοί χαμηλού κώδικα είναι πιο χρήσιμοι όταν η λειτουργία εφαρμόζεται σε ολόκληρο το αρχείο ή την παρουσίαση και η προεπιλεγμένη ροή εργασίας ταιριάζει στις απαιτήσεις σας. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων [Aspose.Slides](https://reference.aspose.com/slides/el/java/com.aspose.slides/) όταν χρειάζεστε λεπτομερή έλεγχο πάνω σε μεμονωμένες διαφάνειες, master, διατάξεις, σχήματα, ρυθμίσεις εξαγωγής ή σχέσεις μεταξύ στοιχείων παρουσίασης.

Ο παρακάτω πίνακας συνοψίζει τους διαθέσιμους βοηθούς:

| Βοηθός | Χρήση |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/el/java/com.aspose.slides/convert/) | Μετατροπή μιας παρουσίασης σε άλλη μορφή με άμεση κλήση αρχείου‑προς‑αρχείο. |
| [Merger](https://reference.aspose.com/slides/el/java/com.aspose.slides/merger/) | Συνδυασμός πλήρων αρχείων παρουσίασης του ίδιου τύπου. |
| [ForEach](https://reference.aspose.com/slides/el/java/com.aspose.slides/foreach/) | Εκτέλεση ενέργειας για κάθε διαφάνεια, σχήμα, παράγραφο ή τμήμα κειμένου. |
| [Collect](https://reference.aspose.com/slides/el/java/com.aspose.slides/collect/) | Ανάκτηση σχημάτων από ολόκληρη την παρουσίαση για επαναλαμβανόμενη επεξεργασία ή ανάλυση. |
| [Compress](https://reference.aspose.com/slides/el/java/com.aspose.slides/compress/) | Αφαίρεση αχρησιμοποίητων master και διατάξεων και μείωση ενσωματωμένων δεδομένων γραμματοσειρών. |

## **Convert a Presentation**

Χρησιμοποιήστε το [Convert.autoByExtension](https://reference.aspose.com/slides/el/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) όταν η κατάληξη του αρχείου εξόδου είναι επαρκής για την επιλογή της μορφής εξαγωγής. Η μέθοδος ανοίγει την πηγή παρουσίασης, καθορίζει την απαιτούμενη μορφή από τη διαδρομή εξόδου και γράφει το αποτέλεσμα.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

Η κλάση [Convert](https://reference.aspose.com/slides/el/java/com.aspose.slides/convert/) παρέχει επίσης ειδικές μεθόδους για έξοδο PDF, SVG, JPEG, PNG και TIFF. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεστε να ελέγξετε ή να τροποποιήσετε την παρουσίαση πριν από την εξαγωγή ή να διαμορφώσετε μια επιλογή εξαγωγής που δεν εκτίθεται από τον επιλεγμένο βοηθό. Δείτε το [Convert Presentation](/slides/el/java/convert-presentation/) για ροές εργασίας και επιλογές ειδικές για μορφές.

## **Merge Presentations**

Χρησιμοποιήστε το [Merger.process](https://reference.aspose.com/slides/el/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) για να συνδυάσετε πλήρη αρχεία παρουσίασης με μία κλήση. Οι εισερχόμενες παρουσιάσεις πρέπει να έχουν τον ίδιο τύπο αρχείου.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Ο βοηθός είναι κατάλληλος όταν όλες οι διαφάνειες πρέπει να προσαρτηθούν σε ένα αποτέλεσμα χωρίς επιλεκτική ή επαναπροοριστική επεξεργασία. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεστε συγχώνευση επιλεγμένων διαφανειών, εφαρμογή master ή διάταξης προορισμού, ρητή διατήρηση ενοτήτων ή εναρμόνιση διαφορετικών μεγεθών διαφανειών. Δείτε το [Merge Presentations](/slides/el/java/merge-presentation/) για αυτά τα σενάρια.

## **Iterate Through Presentation Elements**

Η κλάση [ForEach](https://reference.aspose.com/slides/el/java/com.aspose.slides/foreach/) καλεί μια συνάρτηση επανάκλησης για κάθε ζητούμενο τύπο στοιχείου παρουσίασης. Αποφεύγει ενσωματωμένους βρόχους συλλογής και είναι βολική για επιθεώρηση ή αλλαγές μορφοποίησης σε ολόκληρη την παρουσίαση.

Το παρακάτω παράδειγμα χρησιμοποιεί τις μεθόδους [ForEach.slide](https://reference.aspose.com/slides/el/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/el/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/el/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), και [ForEach.portion](https://reference.aspose.com/slides/el/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) για να επιθεωρήσετε τα αντίστοιχα στοιχεία:

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

Από προεπιλογή, η διαπέραση σχημάτων και κειμένου σε όλη την παρουσίαση περιλαμβάνει κανονικές, master και layout διαφάνειες. Οι υπερφορτώσεις με παράμετρο `includeNotes` μπορούν επίσης να επεξεργαστούν διαφάνειες σημειώσεων. Χρησιμοποιήστε άμεσους βρόχους συλλογής όταν η σειρά διαπέρασης, η πρόωρη έξοδος, η φιλτράριση πριν την κλήση της επανάκλησης ή ο λεπτομερής έλεγχος γονέα‑παιδιού είναι σημαντικά.

## **Collect Shapes**

Χρησιμοποιήστε το [Collect.shapes](https://reference.aspose.com/slides/el/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) όταν χρειάζεστε μια συλλογή όλων των σχημάτων σε μια παρουσίαση αντί για επανάκληση για κάθε σχήμα. Αυτό είναι χρήσιμο όταν το ίδιο σύνολο θα φιλτραριστεί, μετρηθεί ή υποβληθεί σε επεξεργασία περισσότερες από μία φορές.

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

Χρησιμοποιήστε το [ForEach.shape](https://reference.aspose.com/slides/el/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) εναλλακτικά όταν κάθε σχήμα μπορεί να χειριστεί αμέσως και δεν χρειάζεται να διατηρηθεί το συλλεγμένο αποτέλεσμα.

## **Compress Presentation Content**

Η κλάση [Compress](https://reference.aspose.com/slides/el/java/com.aspose.slides/compress/) μπορεί να αφαιρέσει αχρησιμοποίητα δομικά στοιχεία και να μειώσει τα ενσωματωμένα δεδομένα γραμματοσειρών:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) αφαιρεί διαφάνειες διάταξης που δεν αναφέρονται από καμία κανονική διαφάνεια.  
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) αφαιρεί master διαφάνειες που δεν χρησιμοποιούνται πλέον.  
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/el/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) αφαιρεί αχρησιμοποίητους χαρακτήρες από ενσωματωμένες γραμματοσειρές.

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

Αφαιρέστε πρώτα τις αχρησιμοποίητες διατάξεις πριν τα αχρησιμοποίητα master, ώστε ένα master που γίνει άσχετο μετά τον καθαρισμό διατάξεων να μπορεί επίσης να αφαιρεθεί. Αποθηκεύστε την βελτιστοποιημένη παρουσίαση σε νέο αρχείο εάν ενδέχεται να χρειαστείτε αργότερα τα αρχικά master, διατάξεις ή πλήρη ενσωματωμένα δεδομένα γραμματοσειρών. Για περισσότερες λεπτομέρειες, δείτε το [Slide Master](/slides/el/java/slide-master/) και το [Embedded Font](/slides/el/java/embedded-font/).

## **FAQ**

**Πότε θα πρέπει να χρησιμοποιήσω το API χαμηλού κώδικα αντί του πλήρους μοντέλου αντικειμένων;**

Χρησιμοποιήστε τους βοηθούς χαμηλού κώδικα όταν μια τυπική λειτουργία εφαρμόζεται σε ολοκληρωμένο αρχείο ή παρουσίαση και δεν απαιτεί λεπτομερή έλεγχο των μεμονωμένων στοιχείων. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεστε επιλογή συγκεκριμένων διαφανειών, έλεγχο σχέσεων master‑layout, επιθεώρηση ενδιάμεσας κατάστασης ή διαμόρφωση συμπεριφοράς που δεν εκτίθεται από τον βοηθό.

**Μπορεί το Merger να συνδυάσει παρουσιάσεις διαφορετικών τύπων αρχείων;**

Όχι. Το [Merger.process](https://reference.aspose.com/slides/el/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) απαιτεί εισερχόμενες παρουσιάσεις με τον ίδιο τύπο. Μετατρέψτε πρώτα τα αρχεία εισόδου σε κοινό τύπο, π.χ. με το [Convert.autoByExtension](https://reference.aspose.com/slides/el/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), και στη συνέχεια συγχωνεύστε τα μετατρεπόμενα αρχεία.

**Το ForEach επεξεργάζεται master, layout και διαφάνειες σημειώσεων;**

Το [ForEach.slide](https://reference.aspose.com/slides/el/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) διασχίζει τις κανονικές διαφάνειες παρουσίασης. Οι λειτουργίες [ForEach.shape](https://reference.aspose.com/slides/el/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/el/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) και [ForEach.portion](https://reference.aspose.com/slides/el/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) περιλαμβάνουν προεπιλογή τις κανονικές, master και layout διαφάνειες. Χρησιμοποιήστε τις υπερφορτώσεις τους με `includeNotes` ορισμένο σε `true` για να συμπεριλάβετε και τις διαφάνειες σημειώσεων.

**Ποια είναι η διαφορά μεταξύ ForEach.shape και Collect.shapes;**

Χρησιμοποιήστε το [ForEach.shape](https://reference.aspose.com/slides/el/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) για άμεση επεξεργασία κάθε σχήματος μέσω επανάκλησης. Χρησιμοποιήστε το [Collect.shapes](https://reference.aspose.com/slides/el/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) όταν χρειάζεστε ένα επαναχρησιμοποιήσιμο αποτέλεσμα που μπορεί να φιλτραριστεί, μετρηθεί ή διαπεραστεί πολλαπλές φορές.

**Το Compress μειώνει πάντα το μέγεθος του αρχείου παρουσίασης;**

Όχι απαραίτητα. Το αποτέλεσμα εξαρτάται από το αν η παρουσίαση περιέχει αχρησιμοποίητες διατάξεις, αχρησιμοποίητα master ή ενσωματωμένες γραμματοσειρές με αχρησιμοποίητους χαρακτήρες. Εάν δεν υπάρχουν αυτά τα στοιχεία, οι αντίστοιχες λειτουργίες [Compress](https://reference.aspose.com/slides/el/java/com.aspose.slides/compress/) μπορεί να μην μειώσουν το μέγεθος του αρχείου.

**Οι αλλαγές που κάνουν τα ForEach ή Compress αποθηκεύονται αυτόματα;**

Όχι. Οι βοηθοί αυτοί λειτουργούν στο φορτωμένο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) στη μνήμη. Μετά την αλλαγή στοιχείων σε μια επανάκληση [ForEach] ή την εκτέλεση του [Compress], καλέστε το [Presentation.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#save-java.lang.String-int-) για να γράψετε το αποτέλεσμα.

## **Σχετικά Άρθρα**

- [Convert Presentation](/slides/el/java/convert-presentation/)
- [Merge Presentations](/slides/el/java/merge-presentation/)
- [Slide Master](/slides/el/java/slide-master/)
- [Manage Text Box](/slides/el/java/manage-textbox/)
- [Embedded Font](/slides/el/java/embedded-font/)