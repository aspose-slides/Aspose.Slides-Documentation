---
title: Λειτουργίες Παρουσίασης Χαμηλού Κώδικα σε Android
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
- αφαίρεση αχρησιμοποίητων διαφανειών διάταξης
- συμπίεση ενσωματωμένων γραμματοσειρών
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Χρησιμοποιήστε το API χαμηλού κώδικα του Aspose.Slides σε Android για μετατροπή και συγχώνευση παρουσιάσεων, επανάληψη του περιεχομένου, συλλογή σχημάτων και μείωση του μεγέθους της παρουσίασης."
---
## **Επισκόπηση**

Το πακέτο [com.aspose.slides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/) παρέχει στατικές βοηθητικές κλάσεις για συνηθισμένες λειτουργίες παρουσίασης. Αυτοί οι βοηθοί περιβάλλουν συχνά χρησιμοποιούμενες ροές εργασίας του μοντέλου αντικειμένων σε εστιασμένες μεθόδους, ώστε να μπορείτε να μετατρέπετε ή να συγχωνεύετε αρχεία, να επεξεργάζεστε στοιχεία παρουσίασης, να συλλέγετε σχήματα και να αφαιρείτε αχρησιμοποίητο περιεχόμενο με λιγότερο κώδικα.

Οι βοηθητές χαμηλού κώδικα είναι πιο χρήσιμοι όταν η λειτουργία εφαρμόζεται σε ολόκληρο το αρχείο ή την παρουσίαση και η προεπιλεγμένη ροή εργασίας ταιριάζει με τις απαιτήσεις σας. Χρησιμοποιήστε το πλήρες [Aspose.Slides object model](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/) όταν χρειάζεστε λεπτομερή έλεγχο πάνω σε μεμονωμένες διαφάνειες, master, διατάξεις, σχήματα, ρυθμίσεις εξαγωγής ή σχέσεις μεταξύ των στοιχείων παρουσίασης.

| Βοηθός | Χρήση |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/convert/) | Μετατροπή μιας παρουσίασης σε άλλη μορφή με άμεση κλήση αρχείου-σε-αρχείο. |
| [Merger](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/merger/) | Συνδυασμός πλήρων αρχείων παρουσίασης του ίδιου μορφότυπου. |
| [ForEach](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/foreach/) | Εκτέλεση ενέργειας για κάθε διαφάνεια, σχήμα, παράγραφο ή τμήμα κειμένου. |
| [Collect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/collect/) | Ανάκτηση σχημάτων από ολόκληρη την παρουσίαση για επαναλαμβανόμενη επεξεργασία ή ανάλυση. |
| [Compress](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compress/) | Αφαίρεση αχρησιμοποίητων master και διατάξεων και μείωση των ενσωματωμένων δεδομένων γραμματοσειράς. |

## **Μετατροπή Παρουσίασης**

Χρησιμοποιήστε το [Convert.autoByExtension](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) όταν η κατάληξη του αρχείου εξόδου είναι επαρκής για την επιλογή του φορμάτ εξαγωγής. Η μέθοδος ανοίγει την πηγή παρουσίασης, καθορίζει το απαιτούμενο φορμάτ από τη διαδρομή εξόδου και γράφει το αποτέλεσμα.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

Η κλάση [Convert](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/convert/) παρέχει επίσης ειδικές μεθόδους για έξοδο PDF, SVG, JPEG, PNG και TIFF. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να εξετάσετε ή να τροποποιήσετε την παρουσίαση πριν από την εξαγωγή ή να ρυθμίσετε μια επιλογή εξαγωγής που δεν εκτίθεται από τον επιλεγμένο βοηθό. Δείτε το [Μετατροπή Παρουσίασης](/androidjava/convert-presentation/) για ροές εργασίας και επιλογές συγκεκριμένων φορμάτ.

## **Συγχώνευση Παρουσιάσεων**

Χρησιμοποιήστε το [Merger.process](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) για να συνδυάσετε πλήρη αρχεία παρουσίασης με μια κλήση. Οι εισερχόμενες παρουσιάσεις πρέπει να έχουν τον ίδιο τύπο αρχείου.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Αυτός ο βοηθός είναι κατάλληλος όταν όλες οι διαφάνειες πρέπει να προσαρτηθούν σε ένα αποτέλεσμα χωρίς να τις επιλέξετε ή να τις αναδιανείμετε ξεχωριστά. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να συγχωνεύσετε επιλεγμένες διαφάνειες, να εφαρμόσετε master ή διάταξη προορισμού, να διατηρήσετε ενότητες ρητά ή να ευθυγραμμίσετε διαφορετικά μεγέθη διαφανειών. Δείτε το [Συγχώνευση Παρουσιάσεων](/androidjava/merge-presentation/) για αυτές τις περιπτώσεις.

## **Επανάληψη Στοιχείων Παρουσίασης**

Η κλάση [ForEach](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/foreach/) καλεί μια callback για κάθε ζητούμενο τύπο στοιχείου παρουσίασης. Αποφεύγει ενθυλασμένες βρόχους συλλογής και είναι βολική για επιθεώρηση ή αλλαγές μορφοποίησης σε όλη την παρουσίαση.

Το παρακάτω παράδειγμα χρησιμοποιεί τα [ForEach.slide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), και [ForEach.portion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) για να επιθεωρήσετε τα αντίστοιχα στοιχεία:

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

Από προεπιλογή, η περιήγηση σε σχήματα και κείμενο σε όλη την παρουσίαση περιλαμβάνει κανονικές, master και διατάξεις διαφάνειες. Οι υπερφορτώσεις με παράμετρο `includeNotes` μπορούν επίσης να επεξεργαστούν διαφάνειες σημειώσεων. Χρησιμοποιήστε άμεσους βρόχους συλλογής όταν η σειρά περιήγησης, η πρόωρη έξοδος, το φιλτράρισμα πριν την κλήση της callback ή ο λεπτομερής έλεγχος γονέα-παιδιού είναι σημαντικά.

## **Συλλογή Σχημάτων**

Χρησιμοποιήστε το [Collect.shapes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) όταν χρειάζεστε μια συλλογή όλων των σχημάτων σε μια παρουσίαση αντί για μια callback για κάθε σχήμα. Αυτό είναι χρήσιμο όταν το ίδιο σύνολο θα φιλτραριστεί, μετρηθεί ή επεξεργαστεί πολλές φορές.

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

Χρησιμοποιήστε το [ForEach.shape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) αντ' αυτού όταν κάθε σχήμα μπορεί να επεξεργαστεί άμεσα και δεν χρειάζεστε να διατηρήσετε το συλλεγμένο αποτέλεσμα.

## **Συμπίεση Περιεχομένου Παρουσίασης**

Η κλάση [Compress](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compress/) μπορεί να αφαιρέσει αχρησιμοποίητα δομικά στοιχεία και να μειώσει τα ενσωματωμένα δεδομένα γραμματοσειρών:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) αφαιρεί διαφάνειες διάταξης που δεν αναφέρονται από καμία κανονική διαφάνεια.  
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) αφαιρεί master διαφάνειες που δεν χρησιμοποιούνται πλέον.  
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) αφαιρεί αχρησιμοποίητους χαρακτήρες από τις ενσωματωμένες γραμματοσειρές.  

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

Αφαιρέστε τις αχρησιμοποίητες διατάξεις πριν τα αχρησιμοποίητα master, ώστε ένα master που γίνεται αδερμημένο μετά τον καθαρισμό διατάξεων να μπορεί επίσης να αφαιρεθεί. Αποθηκεύστε την βελτιστοποιημένη παρουσίαση σε νέο αρχείο εάν ενδέχεται να χρειαστείτε αργότερα τα αρχικά master, διατάξεις ή τα πλήρη ενσωματωμένα δεδομένα γραμματοσειράς. Για περισσότερες λεπτομέρειες, δείτε το [Slide Master](/androidjava/slide-master/) και το [Embedded Font](/androidjava/embedded-font/).

## **Συχνές Ερωτήσεις**

**Πότε πρέπει να χρησιμοποιήσω το API χαμηλού κώδικα αντί για το πλήρες μοντέλο αντικειμένων;**

Χρησιμοποιήστε βοηθούς χαμηλού κώδικα όταν μια τυπική λειτουργία εφαρμόζεται σε πλήρες αρχείο ή παρουσίαση και δεν απαιτεί λεπτομερή έλεγχο των μεμονωμένων στοιχείων. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να επιλέξετε συγκεκριμένες διαφάνειες, να ελέγξετε τις σχέσεις master και διάταξης, να επιθεωρήσετε ενδιάμεση κατάσταση ή να ρυθμίσετε συμπεριφορά που ο βοηθός δεν εκθέτει.

**Μπορεί ο Merger να συνδυάσει παρουσιάσεις σε διαφορετικούς τύπους αρχείων;**

Όχι. Το [Merger.process](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) απαιτεί οι εισερχόμενες παρουσιάσεις να είναι στον ίδιο τύπο αρχείου. Μετατρέψτε πρώτα τα αρχεία εισόδου σε κοινό φορμά, για παράδειγμα με το [Convert.autoByExtension](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), και έπειτα συγχωνεύστε τα μετατρεπόμενα αρχεία.

**Επεξεργάζεται το ForEach master, layout και διαφάνειες σημειώσεων;**

Το [ForEach.slide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) επαναλαμβάνει τις κανονικές διαφάνειες της παρουσίασης. Οι λειτουργίες σε όλη την παρουσίαση [ForEach.shape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), και [ForEach.portion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) περιλαμβάνουν από προεπιλογή κανονικές, master και διατάξεις διαφάνειες. Χρησιμοποιήστε τις υπερφορτώσεις τους με την παράμετρο `includeNotes` ορισμένη σε `true` για να συμπεριλάβετε τις διαφάνειες σημειώσεων.

**Ποια είναι η διαφορά μεταξύ ForEach.shape και Collect.shapes;**

Χρησιμοποιήστε το [ForEach.shape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) για να επεξεργαστείτε κάθε σχήμα άμεσα μέσω μιας callback. Χρησιμοποιήστε το [Collect.shapes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) όταν χρειάζεστε ένα Iterable αποτέλεσμα που μπορεί να διατηρηθεί, φιλτραριστεί, μετρηθεί ή να περιηγηθεί πολλές φορές.

**Η συμπίεση πάντα κάνει το αρχείο παρουσίασης μικρότερο;**

Δεν είναι απαραίτητα. Το αποτέλεσμα εξαρτάται από το αν η παρουσίαση περιέχει αχρησιμοποίητες διατάξεις, αχρησιμοποίητα master ή ενσωματωμένες γραμματοσειρές με αχρησιμοποίητους χαρακτήρες. Εάν κανένα από αυτά δεν υπάρχει, οι αντίστοιχες λειτουργίες [Compress](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compress/) ενδέχεται να μην μειώσουν το μέγεθος του αρχείου.

**Αποθηκεύονται αυτόματα οι αλλαγές που γίνονται από το ForEach ή το Compress;**

Όχι. Αυτοί οι βοηθοί λειτουργούν στο φορτωμένο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) στη μνήμη. Μετά την τροποποίηση στοιχείων σε μια callback του [ForEach](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/foreach/) ή την εκτέλεση του [Compress](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compress/), καλέστε το [Presentation.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) για να γράψετε το αποτέλεσμα.

## **Σχετικά Άρθρα**

- [Μετατροπή Παρουσίασης](/androidjava/convert-presentation/)
- [Συγχώνευση Παρουσιάσεων](/androidjava/merge-presentation/)
- [Slide Master](/androidjava/slide-master/)
- [Διαχείριση Πλαισίου Κειμένου](/androidjava/manage-textbox/)
- [Ενσωματωμένη Γραμματοσειρά](/androidjava/embedded-font/)