---
title: Αποδοτική Συγχώνευση Παρουσιάσεων σε Java
linktitle: Συγχώνευση Παρουσιάσεων
type: docs
weight: 40
url: /el/java/merge-presentation/
keywords:
- συγχώνευση PowerPoint
- συγχώνευση παρουσιάσεων
- συγχώνευση διαφανειών
- συγχώνευση PPT
- συγχώνευση PPTX
- συγχώνευση ODP
- συνδυασμός PowerPoint
- συνδυασμός παρουσιάσεων
- συνδυασμός διαφανειών
- συνδυασμός PPT
- συνδυασμός PPTX
- συνδυασμός ODP
- Java
- Aspose.Slides
description: "Μάθετε πώς να συγχωνεύετε παρουσιάσεις PowerPoint και OpenDocument σε Java κλωνοποιώντας διαφάνειες, ελέγχοντας masters και διατάξεις, αλλάζοντας το μέγεθος του περιεχομένου των διαφανειών, διατηρώντας ενότητες, και αντιμετωπίζοντας προστατευμένα ή μεγάλα αρχεία."
---
## **Επισκόπηση**

Aspose.Slides for Java συνδυάζει παρουσιάσεις κλωνοποιώντας διαφάνειες από μία [Παρουσίαση](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) σε άλλη. Η κύρια λειτουργία είναι [ISlideCollection.addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), η οποία μπορεί να διατηρήσει τη μορφοποίηση της διαφάνειας‑προέλευσης ή να προσθέσει την κλωνοποιημένη διαφάνεια σε ένα master ή μια διάταξη στην προοριστική παρουσίαση.

Αυτό το άρθρο καλύπτει τις πιο συνηθισμένες ροές συγχώνευσης:

- συγχώνευση όλων των διαφανειών διατηρώντας τη μορφοποίηση της πηγής·
- συγχώνευση επιλεγμένων διαφανειών·
- εφαρμογή master από την προοριστική παρουσίαση·
- εφαρμογή συγκεκριμένης διάταξης από την προοριστική παρουσίαση·
- ομαλοποίηση διαφορετικών μεγεθών διαφανειών πριν από τη συγχώνευση·
- προσθήκη κλωνοποιημένων διαφανειών σε ενότητα·
- συγχώνευση πολλαπλών παρουσιάσεων σε μια ολοκληρωμένη ροή·
- διαχείριση masters, πόρων, σημειώσεων, σχολίων, πολυμέσων, γραμματοσειρών, κωδικών πρόσβασης, μεγάλων αρχείων και θεμάτων πολυνηματικότητας.

## **Πώς η κλωνοποίηση διαφανειών επηρεάζει τα κύρια πρότυπα και τις διατάξεις**

Μια διαφάνεια κληρονομεί μεγάλο μέρος της εμφάνισης της από τη διάταξη και το master που την περιέχει. Για αυτόν τον λόγο, η υπερφόρτωση κλωνοποίησης που επιλέγετε καθορίζει πώς η συγχωνευμένη διαφάνεια ενσωματώνεται στην προοριστική παρουσίαση.

Χρησιμοποιήστε [ISlideCollection.addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidecollection/) με έναν από τους παρακάτω τρόπους:

- `addClone(sourceSlide)` — διατηρεί τη διάταξη και τη μορφοποίηση της διαφάνειας‑προέλευσης. Αν χρειαστεί, το master της πηγής μπορεί να κλωνοποιηθεί αυτόματα στην προοριστική παρουσίαση. Το Aspose.Slides παρακολουθεί αυτόματα κλωνοποιημένα masters ώστε επαναλαμβανόμενες διαφάνειες που χρησιμοποιούν το ίδιο master να μην το κλωνοποιούν ξανά.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — συνδέει την κλωνοποιημένη διαφάνεια με ένα συγκεκριμένο [IMasterSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterslide/). Το Aspose.Slides αναζητά μια ταιριαστή διάταξη κάτω από εκείνο το master με βάση τον τύπο ή το όνομα της διάταξης.
- `addClone(sourceSlide, destinationLayout)` — συνδέει την κλωνοποιημένη διαφάνεια απευθείας με μια συγκεκριμένη [ILayoutSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutslide/).

Το master ή η διάταξη που περνιούνται σε μια υπερφόρτωση `addClone` πρέπει να ανήκει στην **προοριστική** παρουσίαση, όχι στην πηγή.

## **Συγχώνευση ολόκληρων παρουσιάσεων και διατήρηση μορφοποίησης πηγής**

Η πιο απλή συγχώνευση αντιγράφει κάθε διαφάνεια από την πηγαία παρουσίαση στην προοριστική. Αυτή είναι η κατάλληλη επιλογή όταν οι εισαχθέντες διαφάνειες πρέπει να διατηρήσουν το αρχικό θέμα, το master και τις σχέσεις διάταξης.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Η προκύπτουσα παρουσίαση μπορεί να περιέχει πολλαπλά masters όταν η πηγή και ο προορισμός χρησιμοποιούν διαφορετικά σχέδια. Αυτό είναι αναμενόμενο όταν η μορφοποίηση πηγής διατηρείται σκόπιμα.

## **Συγχώνευση επιλεγμένων διαφανειών**

Δεν χρειάζεται να κλωνοποιήσετε κάθε διαφάνεια. Στο παρακάτω παράδειγμα εισάγονται μόνο οι επιλεγμένοι δείκτες διαφανειών από την πηγαία παρουσίαση.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    int[] slideIndexes = { 0, 2, 4 };

    for (int index : slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Επικυρώστε τους δείκτες διαφανειών πριν από την κλωνοποίηση όταν προέρχονται από είσοδο χρήστη ή εξωτερική διαμόρφωση.

## **Συγχώνευση διαφανειών χρησιμοποιώντας Master προορισμού**

Χρησιμοποιήστε την υπερφόρτωση [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) όταν οι εισαχθέντες διαφάνειες πρέπει να ακολουθήσουν ένα master που ανήκει ήδη στην προοριστική παρουσίαση.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    IMasterSlide destinationMaster = destination.getMasters().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Το Aspose.Slides επιλέγει μια κατάλληλη διάταξη κάτω από το συγκεκριμένο master ταιριάζοντας με τον τύπο ή το όνομα της διάταξης‑προέλευσης. Αν δεν υπάρχει κατάλληλη διάταξη και το `allowCloneMissingLayout` είναι `true`, η διάταξη‑προέλευσης κλωνοποιείται ώστε η διαφάνεια να προστεθεί. Αν είναι `false`, πετιέται ένα [PptxEditException](https://reference.aspose.com/slides/el/java/com.aspose.slides/pptxeditexception/).

Χρησιμοποιήστε `false` όταν θέλετε η συγχώνευση να αποτύχει αντί να εισάγει πρόσθετη διάταξη στο master προορισμού.

## **Συγχώνευση διαφανειών χρησιμοποιώντας συγκεκριμένη διάταξη προορισμού**

Χρησιμοποιήστε την υπερφόρτωση [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) όταν γνωρίζετε ακριβώς ποια διάταξη προορισμού πρέπει να χρησιμοποιούν οι εισαχθέντες διαφάνειες.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ILayoutSlide destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Η εφαρμογή μιας διάταξης προορισμού αλλάζει τη κληρονομική σχέση διάταξης· δεν αλλάζει το περιεχόμενο της διαφάνειας‑προέλευσης. Εάν οι διατάξεις πηγής και προορισμού έχουν διαφορετικές δομές placeholder, ελέγξτε το αποτέλεσμα για να βεβαιωθείτε ότι η κληρονομική μορφοποίηση και η συμπεριφορά placeholder είναι κατάλληλες.

## **Συγχώνευση παρουσιάσεων με διαφορετικά μεγέθη διαφανειών**

Παρουσιάσεις με διαφορετικές διαστάσεις διαφάνειας μπορούν να συγχωνευτούν, αλλά η κλωνοποίηση μιας διαφάνειας σε παρουσίαση με άλλο μέγεθος δεν επανασχεδιάζει αυτόματα το περιεχόμενό της για το νέο καμβά. Τα σχήματα μπορεί να εμφανιστούν μετατοπισμένα, κλιμακωμένα απρόσμενα ή εκτός του ορατού περιορισμού.

Μια πρακτική προσέγγιση είναι να αλλάξετε το μέγεθος της πηγαίας παρουσίασης πριν από την κλωνοποίηση. Η μέθοδος [SlideSize.setSize](https://reference.aspose.com/slides/el/java/com.aspose.slides/slidesize/#setSize-float-float-int-) μπορεί να κλιμακώσει το υπάρχον περιεχόμενο ενώ αλλάζει τις διαστάσεις της διαφάνειας. Το [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/el/java/com.aspose.slides/slidesizescaletype/) κλιμακώνει το περιεχόμενο ώστε να ταιριάζει στο ζητούμενο μέγεθος.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    Dimension2D sourceSize = source.getSlideSize().getSize();
    Dimension2D destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            (float) destinationSize.getWidth(), 
            (float) destinationSize.getHeight(), 
            SlideSizeScaleType.EnsureFit);
    }

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Η αλλαγή μεγέθους τροποποιεί το αντικείμενο της πηγαίας παρουσίασης στη μνήμη. Εάν χρειάζεστε την αρχική παρουσίαση αμετάβλητη για άλλες εργασίες, ανοίξτε ένα ξεχωριστό αντίγραφο για τη συγχώνευση.

## **Συγχώνευση διαφανειών σε ενότητα παρουσίασης**

Ο βασικός βρόχος κλωνοποίησης διαφανειών δεν αναδημιουργεί την ιεραρχία ενοτήτων της πηγαίας παρουσίασης. Εάν οι ενότητες έχουν σημασία στο αποτέλεσμα, δημιουργήστε ή επιλέξτε ενότητες στην προοριστική παρουσίαση και κλωνοποιήστε τις διαφάνειες σε αυτές ρητά με [addClone(ISlide, ISection)](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ISection importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, importedSection);
    }

    destination.save("merged-with-section.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Οι κλωνοποιημένες διαφάνειες προσατίθενται στην καθορισμένη ενότητα προορισμού. Για να διατηρήσετε πολλές ενότητες πηγής, δημιουργήστε τις ενότητες στο προορισμό και αντιστοιχίστε κάθε διαφάνεια πηγής στην αντίστοιχη ενότητα προορισμού.

## **Ασφαλής συγχώνευση πολλαπλών παρουσιάσεων**

Το παρακάτω ολοκληρωμένο παράδειγμα χρησιμοποιεί την πρώτη παρουσίαση ως προορισμό, ομαλοποιεί το μέγεθος διαφάνειας κάθε πρόσθετης πηγής, διατηρεί κάθε πηγή ανοιχτή μόνο όσο αντιγράφεται, και αποθηκεύει το τελικό αρχείο μόνο μία φορά.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    Dimension2D mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            Dimension2D sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    (float) mergedSize.getWidth(), 
                    (float) mergedSize.getHeight(), 
                    SlideSizeScaleType.EnsureFit);
            }

            for (ISlide slide : source.getSlides()) {
                merged.getSlides().addClone(slide);
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

Αυτή είναι μια χρήσιμη βάση για διατήρηση της μορφοποίησης της πηγής των εισαχθέντων διαφανειών. Εάν το αποτέλεσμα πρέπει να χρησιμοποιεί ένα ενιαίο θέμα προορισμού, αντικαταστήστε την απλή κλήση `addClone(slide)` με την κατάλληλη υπερφόρτωση master ή layout που παρουσιάστηκε νωρίτερα.

## **Πρακτικές παρατηρήσεις**

### **Masters, Layouts και πιστότητα μορφοποίησης**

Η προεπιλεγμένη κλωνοποίηση διαφανειών μπορεί αυτόματα να φέρει ένα απαιτούμενο master πηγής στην προοριστική παρουσίαση. Το Aspose.Slides διατηρεί ένα εσωτερικό μητρώο αυτόματα κλωνοποιημένων masters για να αποφεύγει την επαναλαμβανόμενη κλωνοποίηση του ίδιου master. Οι χειροκίνητα κλωνοποιημένοι masters δεν παρακολουθούνται από το μητρώο· επομένως αποφύγετε την προ‑κλωνοποίηση masters εκτός εάν χρειάζεστε ρητό έλεγχο της δομής.

Μην υποθέτετε ότι δύο masters ή διατάξεις με το ίδιο όνομα είναι οπτικά ισοδύναμα. Εάν ένα εταιρικό πρότυπο πρέπει να ελέγχει την τελική εμφάνιση, επιλέξτε ρητά master ή διάταξη προορισμού και επαληθεύστε το αποτέλεσμα μετά τη συγχώνευση.

### **Σημειώσεις και σχόλια**

Οι σημειώσεις ομιλητή και τα σχόλια διαφάνειας συνδέονται με το περιεχόμενο της διαφάνειας και αντιγράφονται όταν κλωνοποιείται η διαφάνεια. Το Aspose.Slides παρέχει επίσης ειδικά API για [presentation notes](https://docs.aspose.com/slides/el/java/presentation-notes/) και [presentation comments](https://docs.aspose.com/slides/el/java/presentation-comments/).

Εάν η μορφοποίηση της σελίδας σημειώσεων είναι σημαντική, ελέγξτε την συγχωνευμένη παρουσίαση επειδή οι masters σημειώσεων είναι αντικείμενα επιπέδου παρουσίασης και μπορεί να διαφέρουν μεταξύ των πηγών. Για ροές ελέγχου, επαληθεύστε επίσης τους συντάκτες σχολίων και τα νήματα σχόλια μετά τη συγχώνευση αρχείων από διαφορετικούς συγγραφείς ή πρότυπα.

### **Εικόνες, ήχος, βίντεο, αντικείμενα OLE και εξωτερικοί σύνδεσμοι**

Οι διαφάνειες μπορούν να αναφέρονται σε πόρους επιπέδου παρουσίασης όπως εικόνες, ενσωματωμένο ήχο, ενσωματωμένο βίντεο και δεδομένα OLE. Κλωνοποιήστε τη διαφάνεια ολόκληρη αντί να αντιγράψετε μόνο τα ορατά σχήματα ώστε το Aspose.Slides να διατηρήσει τις σχέσεις της διαφάνειας με τους πόρους της.

Οι ενσωματωμένοι και οι συνδεόμενοι πόροι πρέπει να αντιμετωπίζονται διαφορετικά. Ένα συνδεόμενο ήχος, βίντεο, αντικείμενο OLE ή υπερσύνδεσμος παραμένει εξαρτημένο από τον εξωτερικό του προορισμό· η κλωνοποίηση μιας διαφάνειας δεν μετατρέπει έναν εξωτερικό σύνδεσμο σε ενσωματωμένο περιεχόμενο. Δοκιμάστε τις διαδρομές και τα URLs των συνδεόμενων πόρων στο περιβάλλον όπου θα ανοίξει η τελική παρουσίαση.

Το Aspose.Slides παρακολουθεί αυτόματα κλωνοποιημένα masters, αλλά αυτό δεν αποτελεί γενική εγγύηση ότι παρόμοιο δυαδικό περιεχόμενο από ανεξάρτητες πηγές θα αφαιρεθεί αυτόματα. Εάν το μέγεθος του αρχείου εξόδου είναι κρίσιμο, επιθεωρήστε το τελικό πακέτο και μετρήστε το αποτέλεσμα αντί να βασίζεστε στην εσωτερική αποθάρρυνση.

### **Ενσωματωμένες γραμματοσειρές και διαθεσιμότητα γραμματοσειρών**

Οι γραμματοσειρές διαχειρίζονται σε επίπεδο παρουσίασης. Εάν η τυπογραφία πρέπει να παραμείνει σταθερή σε διάφορους υπολογιστές, μην υποθέτετε ότι η κλωνοποίηση διαφανειών εγγυάται ότι κάθε απαιτούμενη γραμματοσειρά είναι διαθέσιμη στο περιβάλλον προορισμού. Μπορείτε να ελέγξετε τις ενσωματωμένες γραμματοσειρές με [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) και να διαχειριστείτε την ενσωμάτωση όπως περιγράφεται στο άρθρο [Embed Fonts in Presentations](https://docs.aspose.com/slides/el/java/embedded-font/).

Επιβεβαιώστε επίσης ότι έχετε δικαίωμα να ενσωματώσετε τις γραμματοσειρές των πηγαίων αρχείων· οι άδειες γραμματοσειρών μπορεί να περιορίζουν την ενσωμάτωση.

### **Παρουσιάσεις με κωδικό πρόσβασης**

Μια πηγή με κωδικό πρόσβασης πρέπει να ανοίξει επιτυχώς προτού κλωνοποιηθούν οι διαφάνειές της. Παρέχετε τον κωδικό μέσω του [LoadOptions.setPassword](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // Εργαστείτε με την αποκρυπτογραφημένη παρουσίαση.
} finally {
    source.dispose();
}
```

Το άνοιγμα ενός κρυπτογραφημένου αρχείου δεν εφαρμόζει αυτόματα την ίδια προστασία στην προοριστική παρουσίαση. Ρυθμίστε την προστασία εξόδου ξεχωριστά όταν χρειάζεται.

### **Μεγάλες παρουσιάσεις και χρήση μνήμης**

Μεγάλες παρουσιάσεις που περιέχουν εικόνες υψηλής ανάλυσης, ήχο, βίντεο ή άλλα μεγάλα δυαδικά αντικείμενα μπορούν να καταναλώσουν σημαντική μνήμη. Το [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) παρέχει ελέγχους για τη διαχείριση BLOB και τη χρήση προσωρινών αρχείων. Δείτε το θέμα [Manage Presentation BLOBs](https://docs.aspose.com/slides/el/java/manage-blob/) για στρατηγικές μεγάλων αρχείων.

Για μεγάλα αρχεία, προτιμήστε τη φόρτωση από διαδρομές αρχείων όταν είναι δυνατόν, απελευθερώστε κάθε πηγαία παρουσίαση μόλις ολοκληρωθεί η συγχώνευσή της και αποφύγετε την επαναλαμβανόμενη αποθήκευση ενδιάμεσων αποτελεσμάτων εκτός εάν η ροή απαιτεί σημεία ελέγχου.

### **Ασφάλεια σε νήματα**

Μην φορτώνετε, τροποποιείτε, αποθηκεύετε ή κλωνοποιείτε το ίδιο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) ταυτόχρονα από πολλαπλά νήματα. Κρατήστε κάθε παρουσίαση περιορισμένη σε μία λειτουργία συγχώνευσης. Εάν παραλληλοποιείτε ανεξάρτητες εργασίες, χρησιμοποιήστε ανεξάρτητα αντικείμενα παρουσίασης και ακολουθήστε τις οδηγίες [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/el/java/multithreading/).

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να διατηρήσω το αρχικό σχέδιο κάθε πηγαίας παρουσίασης;**

Χρησιμοποιήστε [`addClone(sourceSlide)`](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) χωρίς να παρέχετε master ή διάταξη προορισμού. Το Aspose.Slides μπορεί αυτόματα να κλωνοποιήσει το master πηγής όταν απαιτείται από τη διαφάνεια‑προέλευσης.

**Πώς να κάνω τις εισαχθείσες διαφάνειες να χρησιμοποιούν το θέμα προορισμού;**

Χρησιμοποιήστε την υπερφόρτωση που δέχεται προοριστικό master. Παραχωρήστε ένα master από την προοριστική παρουσίαση, όχι από την πηγή. Το Aspose.Slides θα προσπαθήσει να αντιστοιχίσει κάθε διαφάνεια πηγής σε κατάλληλη διάταξη κάτω από αυτό το master.

**Πότε να προτιμήσω συγκεκριμένη διάταξη προορισμού αντί για master;**

Χρησιμοποιήστε συγκεκριμένη διάταξη όταν κάθε εισαχθείσα διαφάνεια πρέπει να χρησιμοποιεί μία γνωστή διάταξη. Χρησιμοποιήστε master όταν θέλετε το Aspose.Slides να επιλέξει αυτόματα μεταξύ των διατάξεων του master βάσει του τύπου ή του ονόματος της διάταξης πηγής.

**Μπορούν να συγχωνευτούν παρουσιάσεις με διαφορετικά μεγέθη διαφανειών;**

Ναι, αλλά το περιεχόμενο της διαφάνειας δεν επανασχεδιάζεται αυτόματα για τις νέες διαστάσεις. Αλλάξτε το μέγεθος της πηγαίας παρουσίασης πρώτα όταν χρειάζεται προβλεπόμενη στοίχιση, π.χ. με [SlideSize.setSize](https://reference.aspose.com/slides/el/java/com.aspose.slides/slidesize/#setSize-float-float-int-) και [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/el/java/com.aspose.slides/slidesizescaletype/).

**Μπορώ να συγχωνεύσω αρχεία PPT, PPTX και ODP σε ένα αρχείο;**

Ναι. Φορτώστε κάθε πηγαία παρουσίαση, κλωνοποιήστε τις απαιτούμενες διαφάνειες σε έναν προορισμό και αποθηκεύστε τον προορισμό σε μια υποστηριζόμενη μορφή εξόδου. Δεδομένου ότι οι μορφές δεν υποστηρίζουν ακριβώς το ίδιο σύνολο λειτουργιών, ελέγξτε το σύνθετο περιεχόμενο μετά από διαμορφώσεις μεταξύ διαφορετικών μορφών. Δείτε τη σελίδα [Supported File Formats](https://docs.aspose.com/slides/el/java/supported-file-formats/).

**Διατηρούνται αυτόματα οι ενότητες πηγής;**

Όχι, από έναν βασικό βρόχο που κλωνοποιεί μόνο διαφάνειες. Δημιουργήστε τις απαιτούμενες ενότητες στο προορισμό και χρησιμοποιήστε την υπερφόρτωση ενότητας του [addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) όταν πρέπει να διατηρηθεί η δομή ενοτήτων.

**Διατηρούνται οι σημειώσεις ομιλητή και τα σχόλια;**

Αντιγράφονται μαζί με την κλωνοποιημένη διαφάνεια. Για ροές που εξαρτώνται από το στυλ του master σημειώσεων, τους συγγραφείς σχολίων ή τα νήματα ανασκόπησης, επαληθεύστε το συγχωνευμένο αποτέλεσμα καθώς αυτά τα σενάρια περιλαμβάνουν δομές επιπέδου παρουσίασης καθώς και περιεχόμενο διαφάνειας.

**Τι συμβαίνει με ήχο, βίντεο, αντικείμενα OLE και υπερσυνδέσμους;**

Το ενσωματωμένο περιεχόμενο μεταφέρονται ως μέρος των σχέσεων πόρων της κλωνοποιημένης διαφάνειας. Οι εξωτερικοί σύνδεσμοι παραμένουν εξωτερικοί· πρέπει να είναι διαθέσιμοι τα αρχεία ή οι URLs τους μετά τη συγχώνευση.

**Εγγυώνται οι ενσωματωμένες γραμματοσειρές από όλες τις πηγές στο τελικό αρχείο;**

Μην βασίζεστε μόνο στην κλωνοποίηση διαφανειών για τη διάθεση γραμματοσειρών. Ελέγξτε τις ενσωματωμένες γραμματοσειρές του προορισμού και διαχειριστείτε ρητά την ενσωμάτωση ή τη διαθεσιμότητα εξωτερικών γραμματοσειρών όταν η τυπογραφία είναι σημαντική.

**Πώς να συγχωνεύσω ένα αρχείο με κωδικό πρόσβασης;**

Ανοίξτε το με το σωστό [LoadOptions.setPassword](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), στη συνέχεια κλωνοποιήστε τις διαφάνειές του κανονικά. Η προστασία εξόδου ρυθμίζεται ξεχωριστά.

**Πώς να χειριστώ πολύ μεγάλες παρουσιάσεις;**

Χρησιμοποιήστε τη διαχείριση BLOB όταν οι μεγάλοι δυαδικοί πόροι κυριαρχούν στη χρήση μνήμης, προτιμήστε φόρτωση από διαδρομές αρχείων για πολύ μεγάλα αρχεία, απελευθερώστε τις πηγές άμεσα μετά τη συγχώνευση και αποθηκεύστε το τελικό αποτέλεσμα μόνο όταν απαιτείται.

**Μπορώ να συγχωνεύσω διαφάνειες από πολλαπλά νήματα;**

Μην χρησιμοποιείτε το ίδιο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) ταυτόχρονα από πολλαπλά νήματα. Κρατήστε κάθε λειτουργία συγχώνευσης απομονωμένη σε ξεχωριστά αντικείμενα παρουσίασης.