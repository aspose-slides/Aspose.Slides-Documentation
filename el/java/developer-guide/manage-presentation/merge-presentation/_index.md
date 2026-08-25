---
title: Αποτελεσματική Συγχώνευση Παρουσιάσεων σε Java
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
- συνένωση PowerPoint
- συνένωση παρουσιάσεων
- συνένωση διαφανειών
- συνένωση PPT
- συνένωση PPTX
- συνένωση ODP
- Java
- Aspose.Slides
description: "Μάθετε πώς να συγχωνεύετε παρουσιάσεις PowerPoint και OpenDocument σε Java κλωνοποιώντας διαφάνειες, ελέγχοντας masters και layouts, αλλάζοντας το μέγεθος του περιεχομένου των διαφανειών, διατηρώντας τις ενότητες και αντιμετωπίζοντας προστατευμένα ή μεγάλα αρχεία."
---
## **Επισκόπηση**

Aspose.Slides for Java συγχωνεύει παρουσιάσεις κλωνοποιώντας διαφάνειες από ένα [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) σε άλλο. Η κύρια λειτουργία είναι [ISlideCollection.addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), η οποία μπορεί να διατηρήσει τη μορφοποίηση της πηγαίας διαφάνειας ή να επισυνάψει τη κλωνοποιημένη διαφάνεια σε ένα master ή layout στην προορισμένη παρουσίαση.

Αυτό το άρθρο καλύπτει τις πιο κοινές ροές εργασίας συγχώνευσης:

- συγχώνευση όλων των διαφανειών διατηρώντας τη μορφοποίηση της πηγής·
- συγχώνευση επιλεγμένων διαφανειών·
- εφαρμογή master από την προορισμένη παρουσίαση·
- εφαρμογή συγκεκριμένου layout από την προορισμένη παρουσίαση·
- κανονικοποίηση διαφορετικών μεγεθών διαφάνειας πριν τη συγχώνευση·
- προσθήκη κλωνοποιημένων διαφανειών σε ενότητα·
- συγχώνευση πολλαπλών παρουσιάσεων σε μία ολοκληρωμένη ροή εργασίας·
- διαχείριση masters, πόρων, σημειώσεων, σχολίων, μέσων, γραμματοσειρών, κωδικών πρόσβασης, μεγάλων αρχείων και ζητημάτων πολυνηματισμού.

## **Πώς η Κλωνοποίηση Διαφανειών Επηρεάζει τα Masters και τα Layouts**

Μια διαφάνεια κληρονομεί μεγάλο μέρος της εμφάνισής της από το layout και το master της. Για αυτόν τον λόγο, η υπερφόρτωση κλωνοποίησης που επιλέγετε καθορίζει πώς η συγχωνευμένη διαφάνεια ενσωματώνεται στην προορισμένη παρουσίαση.

Χρησιμοποιήστε το [ISlideCollection.addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidecollection/) με έναν από τους ακόλουθους τρόπους:

- addClone(sourceSlide) — διατηρεί το layout και τη μορφοποίηση της πηγαίας διαφάνειας. Όταν απαιτείται, το πηγαίο master μπορεί να κλωνοποιηθεί αυτόματα στην προορισμένη παρουσίαση. Το Aspose.Slides παρακολουθεί αυτόματα κλωνοποιημένα masters ώστε οι επαναλαμβανόμενες διαφάνειες που χρησιμοποιούν το ίδιο πηγαίο master να μην προκαλούν πολλαπλή κλωνοποίηση του master.
- addClone(sourceSlide, destinationMaster, allowCloneMissingLayout) — επισυνάπτει τη κλωνοποιημένη διαφάνεια σε ένα συγκεκριμένο προορισμένο [IMasterSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterslide/). Το Aspose.Slides αναζητά ένα ταιριαστό layout κάτω από αυτό το master με βάση τον τύπο ή το όνομα του layout.
- addClone(sourceSlide, destinationLayout) — επισυνάπτει τη κλωνοποιημένη διαφάνεια απευθείας σε ένα συγκεκριμένο προορισμένο [ILayoutSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutslide/).

Το master ή το layout που περνιέται σε μια υπερφόρτωση `addClone` πρέπει να ανήκει στην **προορισμένη** παρουσίαση, όχι στην πηγαία παρουσίαση.

## **Συγχώνευση Ολόκληρων Παρουσιάσεων και Διατήρηση Μορφοποίησης Πηγής**

Η πιο απλή συγχώνευση αντιγράφει κάθε διαφάνεια από την πηγαία παρουσίαση στην προορισμένη παρουσίαση. Αυτή είναι η κατάλληλη επιλογή όταν οι εισαγόμενες διαφάνειες πρέπει να διατηρήσουν το αρχικό τους θέμα, master και σχέσεις layout.

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

Η προκύπτουσα παρουσίαση μπορεί να περιέχει πολλαπλά masters όταν η πηγή και ο προορισμός χρησιμοποιούν διαφορετικά σχέδια. Αυτό είναι αναμενόμενο όταν η μορφοποίηση της πηγής διατηρείται σκόπιμα.

## **Συγχώνευση Επιλεγμένων Διαφανειών**

Δεν χρειάζεται να κλωνοποιήσετε κάθε διαφάνεια. Το παρακάτω παράδειγμα εισάγει μόνο τις επιλεγμένες διαφάνειες από την πηγαία παρουσίαση.

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

Επικυρώστε τους δείκτες διαφάνειας πριν την κλωνοποίηση όταν προέρχονται από είσοδο χρήστη ή εξωτερική ρύθμιση.

## **Συγχώνευση Διαφανειών Χρησιμοποιώντας Master Προορισμού**

Χρησιμοποιήστε την υπερφόρτωση [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) όταν οι εισαγόμενες διαφάνειες πρέπει να ακολουθήσουν ένα master που ανήκει ήδη στην προορισμένη παρουσίαση.

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

Το Aspose.Slides επιλέγει ένα κατάλληλο layout κάτω από το καθορισμένο master αντιστοιχίζοντας τον τύπο ή το όνομα του layout πηγής. Εάν δεν υπάρχει κατάλληλο layout και `allowCloneMissingLayout` είναι `true`, το layout πηγής κλωνοποιείται ώστε η διαφάνεια να προστεθεί. Εάν είναι `false`, ρίχνεται μια [PptxEditException](https://reference.aspose.com/slides/el/java/com.aspose.slides/pptxeditexception/).

Χρησιμοποιήστε `false` όταν θέλετε η συγχώνευση να αποτύχει αντί να εισάγει επιπλέον layout στον προορισμένο master.

## **Συγχώνευση Διαφανειών Χρησιμοποιώντας Συγκεκριμένο Layout Προορισμού**

Χρησιμοποιήστε την υπερφόρτωση [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) όταν γνωρίζετε ακριβώς ποιο layout προορισμού πρέπει να χρησιμοποιήσουν οι εισαγόμενες διαφάνειες.

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

Η εφαρμογή ενός layout προορισμού αλλάζει τη κληρονομημένη σχέση layout· δεν επανασχεδιάζει το περιεχόμενο της πηγής. Εάν τα layouts πηγής και προορισμού έχουν διαφορετικές δομές placeholder, ελέγξτε το αποτέλεσμα για να επιβεβαιώσετε ότι η κληρονομημένη μορφοποίηση και η συμπεριφορά placeholder είναι κατάλληλες.

## **Συγχώνευση Παρουσιάσεων με Διαφορετικά Μεγέθη Διαφάνειας**

Παρουσιάσεις με διαφορετικές διαστάσεις διαφάνειας μπορούν να συγχωνευτούν, αλλά η κλωνοποίηση μιας διαφάνειας σε παρουσίαση με άλλο μέγεθος δεν επανασχεδιάζει αυτόματα το περιεχόμενό της για το νέο καμβά. Τα σχήματα μπορεί να εμφανιστούν μετατοπισμένα, κλιμακωμένα απρόσμενα ή εκτός του ορατού χώρου της διαφάνειας.

Μια πρακτική προσέγγιση είναι να αλλάξετε το μέγεθος της πηγής πριν την κλωνοποίηση. Η μέθοδος [SlideSize.setSize](https://reference.aspose.com/slides/el/java/com.aspose.slides/slidesize/#setSize-float-float-int-) μπορεί να κλιμακώσει το υπάρχον περιεχόμενο ενώ αλλάζει τις διαστάσεις της διαφάνειας. Το [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/el/java/com.aspose.slides/slidesizescaletype/) κλιμακώνει το περιεχόμενο ώστε να χωράει στο ζητούμενο μέγεθος.

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

Η αλλαγή μεγέθους τροποποιεί το αντικείμενο της πηγής στη μνήμη. Εάν χρειάζεστε την αρχική πηγή ανεπηρέαστη για άλλες λειτουργίες, ανοίξτε ένα ξεχωριστό στιγμιότυπο για τη συγχώνευση.

## **Συγχώνευση Διαφανειών σε Ενότητα Παρουσίασης**

Ο βασικός βρόχος κλωνοποίησης διαφανειών δεν επαναδημιουργεί την ιεραρχία ενοτήτων της πηγής. Εάν οι ενότητες έχουν σημασία στο αποτέλεσμα, δημιουργήστε ή επιλέξτε ενότητες στην προορισμένη παρουσίαση και κλωνοποιήστε διαφάνειες σε αυτές ρητά με [addClone(ISlide, ISection)](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

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

Οι κλωνοποιημένες διαφάνειες προσανατολίζονται στην καθορισμένη ενότητα προορισμού. Για να διατηρήσετε πολλές ενότητες πηγής, κάντε enumerate το [Presentation.getSections](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getSections--) , ανακτήστε τις τρέχουσες διαφάνειες κάθε ενότητας πηγής με [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/el/java/com.aspose.slides/isection/#getSlidesListOfSection--) , δημιουργήστε ξανά τις ενότητες στον προορισμό και κλωνοποιήστε κάθε διαφάνεια στην αντίστοιχη ενότητα προορισμού. Δείτε το [Manage Slide Sections](/slides/el/java/slide-section/) για ένα πλήρες παράδειγμα με απαρίθμηση ενοτήτων, συμπεριλαμβανομένων κενών ενοτήτων και δομικών αλλαγών.

## **Συγχώνευση Πολλαπλών Παρουσιάσεων με Ασφάλεια**

Το παρακάτω ολοκληρωμένο παράδειγμα χρησιμοποιεί την πρώτη παρουσίαση ως προορισμό, κανονικοποιεί το μέγεθος διαφάνειας κάθε επιπλέον πηγής, κρατά κάθε πηγή ανοιχτή μόνο ενώ αντιγράφεται, και αποθηκεύει το τελικό αρχείο μόνο μία φορά.

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

Αυτή είναι μια χρήσιμη βάση για τη διατήρηση της μορφοποίησης πηγής των εισαγόμενων διαφανειών. Εάν το τελικό σας αποτέλεσμα πρέπει να χρησιμοποιεί ένα ενιαίο θέμα προορισμού, αντικαταστήστε την απλή κλήση `addClone(slide)` με την κατάλληλη υπερφόρτωση master ή layout που παρουσιάστηκε νωρίτερα.

## **Πρακτικές Σκέψεις**

### **Masters, Layouts και Ακρίβεια Μορφοποίησης**

Η προεπιλεγμένη κλωνοποίηση διαφανειών μπορεί αυτόματα να φέρει το απαιτούμενο master πηγής στην προορισμένη παρουσίαση. Το Aspose.Slides διατηρεί ένα εσωτερικό μητρώο για αυτόματα κλωνοποιημένα masters ώστε να αποφεύγεται η πολλαπλή κλωνοποίηση του ίδιου master. Τα χειροκίνητα κλωνοποιημένα masters δεν παρακολουθούνται από αυτό το μητρώο, γι’ αυτό αποφύγετε την προ-κλωνοποίηση των masters εκτός εάν χρειάζεστε άμεσο έλεγχο της δομής του master.

Μην υποθέτετε ότι δύο masters ή layouts με το ίδιο όνομα είναι οπτικά ισοδύναμα. Εάν ένα εταιρικό πρότυπο πρέπει να ελέγχει την τελική εμφάνιση, επιλέξτε ρητά ένα master ή layout προορισμού και επαληθεύστε το αποτέλεσμα μετά τη συγχώνευση.

### **Σημειώσεις και Σχόλια**

Οι σημειώσεις ομιλητή και τα σχόλια διαφάνειας συνδέονται με το περιεχόμενο της διαφάνειας και αντιγράφονται όταν η διαφάνεια κλωνοποιείται. Το Aspose.Slides παρέχει επίσης εξειδικευμένα APIs για [presentation notes](/slides/el/java/presentation-notes/) και [presentation comments](/slides/el/java/presentation-comments/).

Εάν η μορφοποίηση της σελίδας σημειώσεων είναι σημαντική, επαληθεύστε την συγχωνευμένη παρουσίαση επειδή τα masters σημειώσεων είναι αντικείμενα επιπέδου παρουσίασης και μπορεί να διαφέρουν μεταξύ των πηγαίων αρχείων. Για ροές ελέγχου, επαληθεύστε επίσης τους συγγραφείς σχολίων και τα νήματα σχολίων μετά τον συνδυασμό αρχείων από διαφορετικούς συγγραφείς ή πρότυπα.

### **Εικόνες, Ήχος, Βίντεο, Αντικείμενα OLE και Εξωτερικοί Σύνδεσμοι**

Οι διαφάνειες μπορούν να κάνουν αναφορά σε πόρους επιπέδου παρουσίασης όπως εικόνες, ενσωματωμένο ήχο, ενσωματωμένο βίντεο και δεδομένα OLE. Κλωνοποιήστε τη διαφάνεια ολόκληρη αντί να αντιγράψετε μόνο τα ορατά σχήματα ώστε το Aspose.Slides να διατηρήσει τις σχέσεις της διαφάνειας με τους πόρους της.

Οι ενσωματωμένοι και οι συνδεδεμένοι πόροι πρέπει να αντιμετωπίζονται διαφορετικά. Ένας συνδεδεμένος ήχος, βίντεο, αντικείμενο OLE ή υπερσύνδεσμος παραμένει εξαρτημένος από το εξωτερικό του στόχο· η κλωνοποίηση μιας διαφάνειας δεν μετατρέπει έναν εξωτερικό σύνδεσμο σε ενσωματωμένο περιεχόμενο. Δοκιμάστε τις διαδρομές και τα URL των συνδεδεμένων πόρων στο περιβάλλον όπου θα ανοιχτεί η συγχωνευμένη παρουσίαση.

Το Aspose.Slides παρακολουθεί αυτόματα κλωνοποιημένα masters, αλλά αυτό δεν πρέπει να θεωρείται γενική εγγύηση ότι πανομοιότυποι δυαδικοί πόροι από ανεξάρτητες πηγές θα αφαιρεθούν πάντα. Εάν το μέγεθος του αρχείου εξόδου είναι σημαντικό, επιθεωρήστε το συγχωνευμένο πακέτο και μετρήστε το αποτέλεσμα αντί να βασίζεστε σε εσωτερική αφαίρεση διπλοτύπων.

### **Ενσωματωμένες Γραμματοσειρές και Διαθεσιμότητα Γραμματοσειρών**

Οι γραμματοσειρές διαχειρίζονται επιπέδου παρουσίασης. Εάν η τυπογραφία πρέπει να παραμείνει συνεπής σε διαφορετικούς υπολογιστές, μην υποθέτετε ότι η κλωνοποίηση διαφανειών εγγυάται ότι κάθε απαιτούμενη γραμματοσειρά είναι διαθέσιμη στο περιβάλλον προορισμού. Μπορείτε να ελέγξετε τις ενσωματωμένες γραμματοσειρές με [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) και να διαχειριστείτε την ενσωμάτωση ρητά όπως περιγράφεται στο [Embed Fonts in Presentations](/slides/el/java/embedded-font/).

Επιβεβαιώστε επίσης ότι έχετε δικαίωμα να ενσωματώσετε τις γραμματοσειρές που χρησιμοποιούν τα πηγαία αρχεία. Οι άδειες γραμματοσειρών μπορούν να περιορίζουν την ενσωμάτωση.

### **Παρουσιάσεις με Κωδικό Πρόσβασης**

Μια πηγή με κωδικό πρόσβασης πρέπει να ανοίξει επιτυχώς πριν μπορέσουν οι διαφάνειές της να κλωνοποιηθούν. Παρέχετε τον κωδικό μέσω του [LoadOptions.setPassword](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

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

Το άνοιγμα ενός κρυπτογραφημένου αρχείου δεν εφαρμόζει αυτόματα την ίδια προστασία στην προορισμένη παρουσίαση. Ρυθμίστε την προστασία εξόδου ξεχωριστά όταν απαιτείται.

### **Μεγάλες Παρουσιάσεις και Χρήση Μνήμης**

Οι μεγάλες παρουσιάσεις που περιέχουν εικόνες υψηλής ανάλυσης, ήχο, βίντεο ή άλλα μεγάλα δυαδικά αντικείμενα μπορούν να καταναλώσουν σημαντική μνήμη. Το [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) παρέχει ελέγχους για τη διαχείριση BLOB και τη χρήση προσωρινών αρχείων. Δείτε το [Manage Presentation BLOBs](/slides/el/java/manage-blob/) για στρατηγικές μεγάλων αρχείων.

Για μεγάλα αρχεία, προτιμήστε τη φόρτωση από διαδρομές αρχείων όταν είναι δυνατόν, αποδεσμεύστε κάθε πηγαία παρουσίαση αμέσως μετά τη συγχώνευση και αποφύγετε την επαναλαμβανόμενη αποθήκευση ενδιάμεσων αποτελεσμάτων εκτός εάν η ροή εργασίας απαιτεί σημεία ελέγχου.

### **Ασφάλεια Πολυνηματισμού**

Μην φορτώνετε, τροποποιείτε, αποθηκεύετε ή κλωνοποιείτε το ίδιο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) ταυτόχρονα από πολλαπλά νήματα. Διατηρήστε κάθε παρουσίαση περιορισμένη σε μία λειτουργία συγχώνευσης. Εάν παράγετε ανεξάρτητες εργασίες, χρησιμοποιήστε ανεξάρτητα αντικείμενα παρουσίασης και ακολουθήστε τις οδηγίες [Aspose.Slides multithreading guidance](/slides/el/java/multithreading/).

## **FAQ**

**Πώς διατηρώ το αρχικό σχέδιο κάθε πηγής παρουσίασης;**

Χρησιμοποιήστε το [addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) χωρίς να παρέχετε master ή layout προορισμού. Το Aspose.Slides μπορεί αυτόματα να κλωνοποιήσει το master πηγής όταν το χρειάζεται η εισαγόμενη διαφάνεια.

**Πώς κάνω τις εισαγόμενες διαφάνειες να χρησιμοποιούν το θέμα του προορισμού;**

Χρησιμοποιήστε την υπερφόρτωση που δέχεται ένα master προορισμού. Παραχωρήστε ένα master από την προορισμένη παρουσίαση, όχι από την πηγή. Το Aspose.Slides θα προσπαθήσει να αντιστοιχίσει κάθε διαφάνεια πηγής σε ένα κατάλληλο layout κάτω από αυτό το master.

**Πότε να χρησιμοποιήσω συγκεκριμένο layout προορισμού αντί για master προορισμού;**

Χρησιμοποιήστε ένα συγκεκριμένο layout όταν κάθε εισαγόμενη διαφάνεια πρέπει να χρησιμοποιεί ένα γνωστό layout. Χρησιμοποιήστε master όταν θέλετε το Aspose.Slides να επιλέξει μεταξύ των layouts του master βάσει του τύπου ή του ονόματος του layout πηγής.

**Μπορούν να συγχωνευτούν παρουσιάσεις με διαφορετικά μεγέθη διαφάνειας;**

Ναι, αλλά το περιεχόμενο της διαφάνειας δεν επανασχεδιάζεται αυτόματα για τις διαστάσεις προορισμού. Αλλάξτε το μέγεθος της πηγής πρώτα όταν χρειάζεται προβλεψιμότητα θέσης, π.χ. με [SlideSize.setSize](https://reference.aspose.com/slides/el/java/com.aspose.slides/slidesize/#setSize-float-float-int-) και [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/el/java/com.aspose.slides/slidesizescaletype/).

**Μπορώ να συγχωνεύσω αρχεία PPT, PPTX και ODP σε ένα αρχείο;**

Ναι. Φορτώστε κάθε πηγαία παρουσίαση, κλωνοποιήστε τις απαιτούμενες διαφάνειες σε έναν προορισμό και αποθηκεύστε τον προορισμό σε υποστηριζόμενη μορφή εξόδου. Επειδή οι μορφές παρουσίασης δεν υποστηρίζουν ακριβώς το ίδιο σύνολο λειτουργιών, επαληθεύστε το σύνθετο περιεχόμενο μετά συγχωνεύσεις μεταξύ διαφορετικών μορφών. Δείτε το [Supported File Formats](/slides/el/java/supported-file-formats/).

**Διατηρούνται αυτόματα οι ενότητες πηγής;**

Όχι από έναν βασικό βρόχο που κλωνοποιεί μόνο διαφάνειες. Δημιουργήστε τις απαιτούμενες ενότητες στον προορισμό και χρησιμοποιήστε την υπερφόρτωση ενότητας του [addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) όταν η δομή των ενοτήτων πρέπει να διατηρηθεί.

**Διατηρούνται οι σημειώσεις ομιλητή και τα σχόλια;**

Αντιγράφονται μαζί με τη κλωνοποιημένη διαφάνεια. Για ροές εργασίας που εξαρτώνται από τη μορφοποίηση του notes-master, τους συγγραφείς σχολίων ή τα νήματα ανασκόπησης, επαληθεύστε το συγχωνευμένο αποτέλεσμα επειδή αυτά τα σενάρια σχετίζονται επίσης με δομές επιπέδου παρουσίασης.

**Τι συμβαίνει με ήχο, βίντεο, αντικείμενα OLE και υπερσυνδέσμους;**

Το ενσωματωμένο περιεχόμενο μεταφέρεται ως μέρος των σχέσεων πόρων της κλωνοποιημένης διαφάνειας. Οι εξωτερικοί σύνδεσμοι παραμένουν εξωτερικοί, οπότε τα αρχεία ή οι URL- τους πρέπει να είναι διαθέσιμα μετά τη συγχώνευση.

**Εγγυώνται οι ενσωματωμένες γραμματοσειρές από κάθε πηγή στο τελικό αρχείο;**

Μην βασίζεστε μόνο στην κλωνοποίηση διαφανειών για την ανάπτυξη γραμματοσειρών. Ελέγξτε τις ενσωματωμένες γραμματοσειρές του προορισμού και διαχειριστείτε ρητά την ενσωμάτωση ή τη διαθεσιμότητα εξωτερικών γραμματοσειρών όταν η τυπογραφία είναι κρίσιμη.

**Πώς συγχωνεύω ένα κρυπτογραφημένο αρχείο;**

Ανοίξτε το με το σωστό [LoadOptions.setPassword](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), στη συνέχεια κλωνοποιήστε τις διαφάνειές του κανονικά. Η προστασία εξόδου ρυθμίζεται ξεχωριστά.

**Πώς πρέπει να χειρίζομαι πολύ μεγάλες παρουσιάσεις;**

Χρησιμοποιήστε διαχείριση BLOB όταν οι μεγάλοι δυαδικοί πόροι κυριαρχούν στη μνήμη, προτιμήστε φόρτωση από διαδρομές αρχείων για πολύ μεγάλα αρχεία, αποδεσμεύστε γρήγορα τις πηγές και αποθηκεύστε το τελικό αποτέλεσμα μόνο όταν είναι απαραίτητο.

**Μπορώ να συγχωνεύσω διαφάνειες από πολλά νήματα;**

Μην χρησιμοποιείτε ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) ταυτόχρονα από πολλά νήματα. Διατηρήστε κάθε λειτουργία συγχώνευσης απομονωμένη σε δικές της παρουσίες παρουσίασης.