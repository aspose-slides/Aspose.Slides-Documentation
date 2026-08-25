---
title: Λειτουργίες Παρουσίασης Χαμηλού Κώδικα στο Android
linktitle: API Χαμηλού Κώδικα
type: docs
weight: 50
url: /el/androidjava/low-code-presentation-operations/
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
- αφαίρεση αχρησιμοποίητων layout διαφανειών
- συμπίεση ενσωματωμένων γραμματοσειρών
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Χρησιμοποιήστε το API χαμηλού κώδικα Aspose.Slides στο Android για να μετατρέψετε και να συγχώνευσετε παρουσιάσεις, να επαναλάβετε το περιεχόμενο, να συλλέξετε σχήματα και να μειώσετε το μέγεθος της παρουσίασης."
---
## **Επισκόπηση**

Το πακέτο [com.aspose.slides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/) παρέχει στατικές βοηθητικές κλάσεις για συνηθισμένες λειτουργίες παρουσίασης. Αυτοί οι βοηθοί περιβάλλουν συχνά χρησιμοποιούμενες ροές εργασίας του αντικειμενο-μοντέλου σε στοχευμένες μεθόδους, ώστε να μπορείτε να μετατρέπετε ή να συγχνοίτε αρχεία, να επεξεργάζεστε στοιχεία παρουσίασης, να συλλέγετε σχήματα και να αφαιρείτε αχρησιμοποίητο περιεχόμενο με λιγότερο κώδικα.

Οι βοηθοί χαμηλού κώδικα είναι πιο χρήσιμοι όταν η λειτουργία εφαρμόζεται σε ολόκληρο το αρχείο ή την παρουσίαση και η προεπιλεγμένη ροή ταιριάζει με τις απαιτήσεις σας. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων [Aspose.Slides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/) όταν χρειάζεστε λεπτομερή έλεγχο σε ξεχωριστές διαφάνειες, master, διατάξεις, σχήματα, ρυθμίσεις εξαγωγής ή σχέσεις μεταξύ των στοιχείων παρουσίασης.

Ο παρακάτω πίνακας συνοψίζει τους διαθέσιμους βοηθούς:

| Βοηθός | Χρήση |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/convert/) | Μετατροπή μιας παρουσίασης σε άλλη μορφή με άμεση κλήση αρχείο‑σε‑αρχείο. |
| [Merger](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/merger/) | Συγχώνευση πλήρων αρχείων παρουσίασης του ίδιου τύπου. |
| [ForEach](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/foreach/) | Εκτέλεση ενέργειας για κάθε διαφάνεια, σχήμα, παράγραφο ή τμήμα κειμένου. |
| [Collect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/collect/) | Ανάκτηση σχημάτων από ολόκληρη την παρουσίαση για επαναλαμβανόμενη επεξεργασία ή ανάλυση. |
| [Compress](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compress/) | Αφαίρεση αχρησιμοποίητων master και διατάξεων και μείωση ενσωματωμένων δεδομένων γραμματοσειράς. |

## **Μετατροπή Παρουσίασης**

Χρησιμοποιήστε [Convert.autoByExtension](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) όταν η επέκταση του αρχείου εξόδου είναι επαρκής για την επιλογή μορφής εξαγωγής. Η μέθοδος ανοίγει την πηγή παρουσίασης, καθορίζει τη απαιτούμενη μορφή από το μονοπάτι εξόδου και γράφει το αποτέλεσμα.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

Η κλάση [Convert](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/convert/) παρέχει επίσης ειδικές μεθόδους για έξοδο σε PDF, SVG, JPEG, PNG και TIFF. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να εξετάσετε ή να τροποποιήσετε την παρουσίαση πριν την εξαγωγή ή να ρυθμίσετε μια επιλογή εξαγωγής που δεν εκτίθεται από τον επιλεγμένο βοηθό. Δείτε το [Convert Presentation](/slides/el/androidjava/convert-presentation/) για ροές εργασίας και επιλογές ειδικές ανά μορφή.

## **Συγχώνευση Παρουσιάσεων**

Χρησιμοποιήστε [Merger.process](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) για να συνδυάσετε πλήρη αρχεία παρουσίασης με μία κλήση. Οι εισερχόμενες παρουσιάσεις πρέπει να έχουν την ίδια μορφή αρχείου.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Ο βοηθός είναι κατάλληλος όταν όλες οι διαφάνειες πρέπει να προσαρτηθούν σε ένα αποτέλεσμα χωρίς να χρειάζεται η ατομική επιλογή ή αντιστοίχιση τους. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να συγχωνεύσετε επιλεγμένες διαφάνειες, να εφαρμόσετε έναν προορισμό master ή διάταξη, να διατηρήσετε ενότητες ρητά ή να εναρμονίσετε διαφορετικά μεγέθη διαφανειών. Δείτε το [Merge Presentations](/slides/el/androidjava/merge-presentation/) για αυτές τις περιπτώσεις.

## **Επανάληψη Μέσω Στοιχείων Παρουσίασης**

Η κλάση [ForEach](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/foreach/) καλεί ένα callback για κάθε ζητούμενο τύπο στοιχείου παρουσίασης. Αποφεύγει τα ένθετα βρόχους συλλογής και είναι βολική για έλεγχο ή αλλαγές μορφοποίησης σε όλη την παρουσίαση.

Το παρακάτω παράδειγμα χρησιμοποιεί [ForEach.slide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), και [ForEach.portion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) για να εξετάσετε τα αντίστοιχα στοιχεία:

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

Από προεπιλογή, η διέλευση σχήματος και κειμένου σε όλη την παρουσίαση περιλαμβάνει κανονικές, master και layout διαφάνειες. Οι υπερφορτώσεις με παράμετρο `includeNotes` μπορούν επίσης να επεξεργαστούν διαφάνειες σημειώσεων. Χρησιμοποιήστε άμεσους βρόχους συλλογής όταν η σειρά διέλευσης, η πρώιμη έξοδος, η φιλτράρισμα πριν την κλήση του callback ή ο λεπτομερής έλεγχος γονέα‑παιδιού είναι σημαντικά.

## **Συλλογή Σχημάτων**

Χρησιμοποιήστε [Collect.shapes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) όταν χρειάζεστε μια συλλογή όλων των σχημάτων σε μια παρουσίαση αντί για ένα callback για κάθε σχήμα. Αυτό είναι χρήσιμο όταν το ίδιο σύνολο θα φιλτράρεται, υπολογίζεται ή επεξεργάζεται περισσότερες φορές.

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

Χρησιμοποιήστε το [ForEach.shape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) αν θέλετε να χειριστείτε κάθε σχήμα άμεσα και δεν χρειάζεστε να διατηρήσετε το συλλεγμένο αποτέλεσμα.

## **Συμπίεση Περιεχομένου Παρουσίασης**

Η κλάση [Compress](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compress/) μπορεί να αφαιρέσει αχρησιμοποίητα δομικά στοιχεία και να μειώσει τα ενσωματωμένα δεδομένα γραμματοσειράς:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) αφαιρεί διαφάνειες διάταξης που δεν αναφέρονται από καμία κανονική διαφάνεια.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) αφαιρεί master διαφάνειες που δεν χρησιμοποιούνται πλέον.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) αφαιρεί αχρησιμοποίητους χαρακτήρες από ενσωματωμένες γραμματοσειρές.

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

Αφαιρέστε πρώτα τις αχρησιμοποίητες διατάξεις και μετά τους αχρησιμοποίητους master, ώστε ένας master που γίνεται αδέσμευτος μετά τον καθαρισμό διατάξεων να μπορεί επίσης να αφαιρεθεί. Αποθηκεύστε την βελτιστοποιημένη παρουσίαση σε νέο αρχείο αν μπορεί να χρειαστείτε αργότερα τους αρχικούς master, τις διατάξεις ή το πλήρες ενσωματωμένο σύνολο γραμματοσειρών. Για περισσότερες λεπτομέρειες, δείτε το [Slide Master](/slides/el/androidjava/slide-master/) και το [Embedded Font](/slides/el/androidjava/embedded-font/).

## **Συχνές Ερωτήσεις**

**Πότε πρέπει να χρησιμοποιήσω το API χαμηλού κώδικα αντί για το πλήρες μοντέλο αντικειμένων;**

Χρησιμοποιήστε τους βοηθούς χαμηλού κώδικα όταν μια τυπική λειτουργία εφαρμόζεται σε ολόκληρο το αρχείο ή την παρουσίαση και δεν απαιτεί λεπτομερή έλεγχο των μεμονωμένων στοιχείων. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να επιλέξετε συγκεκριμένες διαφάνειες, να ελέγξετε σχέσεις master‑layout, να εξετάσετε ενδιάμεση κατάσταση ή να ρυθμίσετε συμπεριφορά που ο βοηθός δεν εκθέτει.

**Μπορεί ο Merger να συνδυάσει παρουσιάσεις διαφορετικών μορφών αρχείου;**

Όχι. Το [Merger.process](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) απαιτεί εισερχόμενες παρουσιάσεις στην ίδια μορφή. Μετατρέψτε πρώτα τα αρχεία εισόδου σε κοινή μορφή, π.χ. με το [Convert.autoByExtension](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), και μετά συγχωνεύστε τα μετατρεπόμενα αρχεία.

**Επεξεργάζεται το ForEach master, layout και notes διαφάνειες;**

Το [ForEach.slide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) διατρέχει τις κανονικές διαφάνειες παρουσίασης. Η [ForEach.shape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), η [ForEach.paragraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) και οι [ForEach.portion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) περιλαμβάνουν κανονικές, master και layout διαφάνειες από προεπιλογή. Χρησιμοποιήστε τις υπερφορτώσεις τους με `includeNotes` ορισμένο σε `true` για να συμπεριλάβετε και τις notes διαφάνειες.

**Ποια είναι η διαφορά μεταξύ ForEach.shape και Collect.shapes;**

Χρησιμοποιήστε το [ForEach.shape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) για άμεση επεξεργασία κάθε σχήματος μέσω callback. Χρησιμοποιήστε το [Collect.shapes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) όταν χρειάζεστε ένα επαναχρησιμοποιήσιμο αποτέλεσμα που μπορεί να φιλτραριστεί, μετρηθεί ή δια遍 συχνά.

**Η συμπίεση μειώνει πάντα το μέγεθος του αρχείου παρουσίασης;**

Δεν είναι υποχρεωτικό. Το αποτέλεσμα εξαρτάται από το αν η παρουσίαση περιέχει αχρησιμοποίητες διατάξεις, αχρησιμοποίητους master ή ενσωματωμένες γραμματοσειρές με αχρησιμοποίητους χαρακτήρες. Αν καμία από αυτές τις περιπτώσεις δεν υπάρχει, οι αντίστοιχες λειτουργίες [Compress](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compress/) ενδέχεται να μην μειώσουν το μέγεθος του αρχείου.

**Οι αλλαγές που γίνονται από το ForEach ή το Compress αποθηκεύονται αυτόματα;**

Όχι. Αυτοί οι βοηθοί λειτουργούν στο φορτωμένο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) στη μνήμη. Μετά την τροποποίηση των στοιχείων σε ένα callback του [ForEach](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/foreach/) ή την εκτέλεση του [Compress](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compress/), καλέστε το [Presentation.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) για να γράψετε το αποτέλεσμα.

## **Σχετικά Άρθρα**

- [Convert Presentation](/slides/el/androidjava/convert-presentation/)
- [Merge Presentations](/slides/el/androidjava/merge-presentation/)
- [Slide Master](/slides/el/androidjava/slide-master/)
- [Manage Text Box](/slides/el/androidjava/manage-textbox/)
- [Embedded Font](/slides/el/androidjava/embedded-font/)