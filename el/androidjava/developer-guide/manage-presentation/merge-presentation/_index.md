---
title: Αποδοτική Συγχώνευση Παρουσιάσεων στο Android
linktitle: Συγχώνευση Παρουσιάσεων
type: docs
weight: 40
url: /el/androidjava/merge-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να συγχωνεύετε παρουσιάσεις PowerPoint και OpenDocument στο Android κλωνοποιώντας διαφάνειες, ελέγχοντας τα master και τα layouts, αλλάζοντας το μέγεθος του περιεχομένου των διαφανειών, διατηρώντας τις ενότητες και διαχειριζόμενοι προστατευμένα ή μεγάλα αρχεία."
---
## **Επισκόπηση**

Το Aspose.Slides for Android μέσω Java συγχωνεύει παρουσιάσεις κλωνοποιώντας διαφάνειες από ένα [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) σε άλλο. Η κύρια λειτουργία είναι το [ISlideCollection.addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), το οποίο μπορεί να διατηρήσει τη μορφοποίηση της πηγής ή να συνδέσει την κλωνοποιημένη διαφάνεια με ένα master ή layout στην προορισμένη παρουσίαση.

Αυτό το άρθρο καλύπτει τις πιο κοινές ροές εργασίας συγχώνευσης:

- συγχώνευση όλων των διαφανειών διατηρώντας τη μορφοποίηση της πηγής·
- συγχώνευση επιλεγμένων διαφανειών·
- εφαρμογή master από την προορισμένη παρουσίαση·
- εφαρμογή συγκεκριμένου layout από την προορισμένη παρουσίαση·
- ομαλοποίηση διαφορετικών μεγεθών διαφανειών πριν από τη συγχώνευση·
- προσθήκη κλωνοποιημένων διαφανειών σε ενότητα·
- συγχώνευση πολλαπλών παρουσιάσεων σε μία ολοκληρωμένη ροή εργασίας·
- αντιμετώπιση master, πόρων, σημειώσεων, σχολίων, πολυμέσων, γραμματοσειρών, κωδικών πρόσβασης, μεγάλων αρχείων και θεμάτων πολυνηματικότητας.

## **Πώς η Κλωνοποίηση Διαφάνειας Επηρεάζει τα Masters και τα Layouts**

Μια διαφάνεια κληρονομεί μεγάλο μέρος της εμφάνισης της από το layout και το master της. Για αυτόν τον λόγο, η υπερφόρτωση κλωνοποίησης που επιλέγετε καθορίζει πώς η συγχωνευμένη διαφάνεια ενσωματώνεται στην προορισμένη παρουσίαση.

Χρησιμοποιήστε το [ISlideCollection.addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidecollection/) με έναν από τους ακόλουθους τρόπους:

- `addClone(sourceSlide)` — διατηρεί το layout και τη μορφοποίηση της πηγής. Όταν απαιτείται, το master της πηγής μπορεί να κλωνοποιηθεί αυτόματα στην προορισμένη παρουσίαση. Το Aspose.Slides παρακολουθεί αυτόματα κλωνοποιημένα master ώστε επαναλαμβανόμενες διαφάνειες που χρησιμοποιούν το ίδιο master πηγής να μην προκαλούν επαναλαμβανόμενη κλωνοποίηση του master.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — συνδέει την κλωνοποιημένη διαφάνεια με ένα συγκεκριμένο προορισμένο [IMasterSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterslide/). Το Aspose.Slides ψάχνει για ένα αντιστοιχικό layout κάτω από αυτό το master με βάση τον τύπο ή το όνομα του layout.
- `addClone(sourceSlide, destinationLayout)` — συνδέει την κλωνοποιημένη διαφάνεια απευθείας με ένα συγκεκριμένο προορισμένο [ILayoutSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutslide/).

Το master ή το layout που περνιέται σε μια υπερφόρτωση `addClone` πρέπει να ανήκει στην **προορισμένη** παρουσίαση, όχι στην πηγή.

## **Συγχώνευση Ολόκληρων Παρουσιάσεων και Διατήρηση Μορφοποίησης Πηγής**

Η πιο απλή συγχώνευση αντιγράφει κάθε διαφάνεια από την παρουσίαση πηγής στην προορισμένη παρουσίαση. Αυτή είναι η κατάλληλη επιλογή όταν οι εισαγόμενες διαφάνειες πρέπει να διατηρήσουν το αρχικό θέμα, master και σχέσεις layout.

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

Η προκύπτουσα παρουσίαση μπορεί να περιλαμβάνει πολλαπλά master όταν η πηγή και ο προορισμός χρησιμοποιούν διαφορετικά σχέδια. Αυτό είναι αναμενόμενο όταν η μορφοποίηση της πηγής διατηρείται σκόπιμα.

## **Συγχώνευση Επιλεγμένων Διαφανειών**

Δεν χρειάζεται να κλωνοποιήσετε κάθε διαφάνεια. Το παρακάτω παράδειγμα εισάγει μόνο επιλεγμένους δείκτες διαφανειών από την παρουσίαση πηγής.

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

## **Συγχώνευση Διαφανειών Χρησιμοποιώντας Master Προορισμού**

Χρησιμοποιήστε την υπερφόρτωση [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) όταν οι εισαγόμενες διαφάνειες πρέπει να ακολουθούν ένα master που ήδη ανήκει στην προορισμένη παρουσίαση.

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

Το Aspose.Slides επιλέγει ένα κατάλληλο layout κάτω από το καθορισμένο master ταιριάζοντας με τον τύπο ή το όνομα του layout πηγής. Αν δεν υπάρχει κατάλληλο layout και το `allowCloneMissingLayout` είναι `true`, το layout της πηγής κλωνοποιείται ώστε η διαφάνεια να προστεθεί. Αν είναι `false`, ρίχνεται μια [PptxEditException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pptxeditexception/).

Χρησιμοποιήστε `false` όταν θέλετε η συγχώνευση να αποτύχει αντί να εισάγει ένα επιπλέον layout στο master προορισμού.

## **Συγχώνευση Διαφανειών Χρησιμοποιώντας Συγκεκριμένο Layout Προορισμού**

Χρησιμοποιήστε την υπερφόρτωση [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) όταν γνωρίζετε ακριβώς ποιο layout προορισμού πρέπει να χρησιμοποιήσουν οι εισαγόμενες διαφάνειες.

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

Η εφαρμογή ενός layout προορισμού τροποποιεί τη κληρονεμένη σχέση layout· δεν αλλάζει το περιεχόμενο της διαφάνειας πηγής. Εάν τα layout πηγής και προορισμού έχουν διαφορετικές δομές placeholder, εξετάστε το αποτέλεσμα για να επιβεβαιώσετε ότι η κληρονομημένη μορφοποίηση και η συμπεριφορά placeholder είναι κατάλληλες.

## **Συγχώνευση Παρουσιάσεων με Διαφορετικά Μεγέθη Διαφανειών**

Παρουσιάσεις με διαφορετικές διαστάσεις διαφάνειας μπορούν να συγχωνευτούν, αλλά η κλωνοποίηση μιας διαφάνειας σε παρουσίαση με διαφορετικό μέγεθος δεν επανασχεδιάζει αυτόματα το περιεχόμενό της για το νέο καμβά. Τα σχήματα μπορεί έτσι να εμφανιστούν μετατοπισμένα, κλιμακωμένα απρόσμενα ή εκτός του ορατού χώρου της διαφάνειας.

Μία πρακτική προσέγγιση είναι να αλλάξετε το μέγεθος της παρουσίασης πηγής πριν από την κλωνοποίηση. Η μέθοδος [SlideSize.setSize](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) μπορεί να κλιμακώσει το υπάρχον περιεχόμενο ενώ αλλάζει τις διαστάσεις της διαφάνειας. Η [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slidesizescaletype/) κλιμακώνει το περιεχόμενο ώστε να ταιριάζει στο ζητούμενο μέγεθος.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    SizeF sourceSize = source.getSlideSize().getSize();
    SizeF destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
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

Η αλλαγή μεγέθους τροποποιεί το αντικείμενο παρουσίασης πηγής στη μνήμη. Εάν χρειάζεστε την αρχική παρουσίαση πηγής αμετάβλητη για άλλες λειτουργίες, ανοίξτε ένα ξεχωριστό αντίγραφο για τη συγχώνευση.

## **Συγχώνευση Διαφανειών σε Ενότητα Παρουσίασης**

Ο βασικός βρόχος κλωνοποίησης διαφανειών δεν αναδημιουργεί την ιεραρχία ενοτήτων της παρουσίασης πηγής. Εάν οι ενότητες έχουν σημασία στο τελικό αποτέλεσμα, δημιουργήστε ή επιλέξτε ενότητες στην προορισμένη παρουσίαση και κλωνοποιήστε τις διαφάνειες σε αυτές ρητά με το [addClone(ISlide, ISection)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

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

Οι κλωνοποιημένες διαφάνειες προσαρτώνται στην καθορισμένη ενότητα προορισμού. Για να διατηρήσετε πολλές ενότητες πηγής, κάντε επαναληπτική κλήση στο [Presentation.getSections](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getSections--), ανακτήστε τις τρέχουσες διαφάνειες κάθε ενότητας πηγής με το [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--), δημιουργήστε ξανά τις ενότητες στον προορισμό και κλωνοποιήστε κάθε διαφάνεια στην αντίστοιχη ενότητα προορισμού. Δείτε το [Manage Slide Sections](/slides/el/androidjava/slide-section/) για ολοκληρωμένο παράδειγμα με κενές ενότητες και δομικές αλλαγές.

## **Ασφαλής Συγχώνευση Πολλαπλών Παρουσιάσεων**

Το παρακάτω παράδειγμα ολοκληρωμένης ροής χρησιμοποιεί την πρώτη παρουσίαση ως προορισμό, ομαλοποιεί το μέγεθος διαφάνειας κάθε επιπλέον πηγής, διατηρεί κάθε πηγή ανοιχτή μόνο ενώ αντιγράφεται, και αποθηκεύει το τελικό αρχείο μόλις ολοκληρωθεί.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    SizeF mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            SizeF sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
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

Αυτή είναι μια χρήσιμη βάση για τη διατήρηση της μορφοποίησης πηγής των εισαγόμενων διαφανειών. Εάν το αποτέλεσμα σας πρέπει να χρησιμοποιεί ένα ενιαίο θέμα προορισμού, αντικαταστήστε την απλή κλήση `addClone(slide)` με την κατάλληλη υπερφόρτωση master‑προορισμού ή layout‑προορισμού που παρουσιάστηκε νωρίτερα.

## **Πρακτικές Σκέψεις**

### **Masters, Layouts και Ακρίβεια Μορφοποίησης**

Η προεπιλεγμένη κλωνοποίηση διαφάνειας μπορεί αυτόματα να φέρει ένα απαιτούμενο master πηγής στην προορισμένη παρουσίαση. Το Aspose.Slides διατηρεί εσωτερικό μητρώο για αυτόματα κλωνοποιημένα master ώστε να αποφεύγεται η επαναλαμβανόμενη κλωνοποίηση του ίδιου master. Τα χειροκίνητα κλωνοποιημένα master δεν παρακολουθούνται από αυτό το μητρώο, οπότε αποφύγετε την προ‑κλωνοποίηση master εκτός εάν χρειάζεστε σαφή έλεγχο της δομής του master.

Μην θεωρείτε ότι δύο master ή layout με το ίδιο όνομα είναι οπτικά ισοδύναμα. Εάν ένα εταιρικό πρότυπο πρέπει να ελέγχει την τελική εμφάνιση, επιλέξτε ρητά ένα master ή layout προορισμού και επαληθεύστε το αποτέλεσμα μετά τη συγχώνευση.

### **Σημειώσεις και Σχόλια**

Οι σημειώσεις ομιλητή και τα σχόλια σε διαφάνειες συνδέονται με το περιεχόμενο της διαφάνειας και αντιγράφονται όταν μια διαφάνεια κλωνοποιείται. Το Aspose.Slides προσφέρει επίσης εξειδικευμένα API για [presentation notes](/slides/el/androidjava/presentation-notes/) και [presentation comments](/slides/el/androidjava/presentation-comments/).

Εάν η μορφοποίηση της σελίδας σημειώσεων είναι σημαντική, επαληθεύστε την συγχωνευμένη παρουσίαση επειδή τα notes masters είναι αντικείμενα επιπέδου παρουσίασης και μπορεί να διαφέρουν μεταξύ των αρχείων πηγής. Για ροές ελέγχου, επαληθεύστε επίσης τους συγγραφείς σχολίων και τις αλληλουχικές συνομιλίες μετά τη συγχώνευση αρχείων από διαφορετικούς συγγραφείς ή πρότυπα.

### **Εικόνες, Ήχος, Βίντεο, Αντικείμενα OLE και Εξωτερικοί Σύνδεσμοι**

Οι διαφάνειες μπορούν να αναφέρονται σε πόρους επιπέδου παρουσίασης όπως εικόνες, ενσωματωμένο ήχο, ενσωματωμένο βίντεο και δεδομένα OLE. Κλωνοποιήστε τη διαφάνεια αυτή καθεαυτή αντί να αντιγράφετε μόνο τα ορατά σχήματα, ώστε το Aspose.Slides να διατηρήσει τις σχέσεις της διαφάνειας με τους πόρους της.

Οι ενσωματωμένοι και συνδεδεμένοι πόροι πρέπει να αντιμετωπίζονται διαφορετικά. Ένας συνδεδεμένος ήχος, βίντεο, αντικείμενο OLE ή υπερσύνδεσμος παραμένει εξαρτημένος από τον εξωτερικό του προορισμό· η κλωνοποίηση μιας διαφάνειας δεν μετατρέπει έναν εξωτερικό σύνδεσμο σε ενσωματωμένο περιεχόμενο. Δοκιμάστε τις διαδρομές και τα URL των συνδεδεμένων πόρων στο περιβάλλον όπου θα ανοιχτεί η συγχωνευμένη παρουσίαση.

Το Aspose.Slides παρακολουθεί ρητά αυτόματα κλωνοποιημένα master, αλλά αυτό δεν πρέπει να θεωρείται γενική εγγύηση ότι τα ίδια δυαδικά αρχεία από ανεξάρτητες παρουσιάσεις θα αφαιρεθούν αυτόματα. Εάν το μέγεθος του εξαγόμενου αρχείου είναι σημαντικό, ελέγξτε το πακέτο που προκύπτει και μετρήστε το αποτέλεσμα αντί να βασίζεστε σε έμμεση αφαιρετική διαδικασία.

### **Ενσωματωμένες Γραμματοσειρές και Διαθεσιμότητα Γραμματοσειρών**

Οι γραμματοσειρές διαχειρίζονται σε επίπεδο παρουσίασης. Εάν η τυπογραφία πρέπει να παραμείνει συνεπής μεταξύ μηχανών, μην υποθέτετε ότι η κλωνοποίηση μόνο των διαφανειών εγγυάται ότι κάθε απαιτούμενη γραμματοσειρά είναι διαθέσιμη στο περιβάλλον προορισμού. Μπορείτε να εξετάσετε τις ενσωματωμένες γραμματοσειρές με το [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) και να διαχειριστείτε την ενσωμάτωση ρητά, όπως περιγράφεται στην ενότητα [Embed Fonts in Presentations](/slides/el/androidjava/embedded-font/).

Επιβεβαιώστε επίσης ότι έχετε δικαίωμα να ενσωματώσετε τις γραμματοσειρές που χρησιμοποιούν τα αρχεία πηγής. Οι άδειες γραμματοσειρών ενδέχεται να περιορίζουν την ενσωμάτωση.

### **Παραγωγές με Κωδικό Πρόσβασης**

Μια πηγή με κωδικό πρόσβασης πρέπει να ανοίξει επιτυχώς πριν κλωνοποιηθεί η διαφάνειά της. Παρέχετε τον κωδικό μέσω του [LoadOptions.setPassword](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

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

Το άνοιγμα μιας κρυπτογραφημένης πηγής δεν εφαρμόζει αυτόματα την ίδια προστασία στην προορισμένη παρουσίαση. Ρυθμίστε την προστασία εξόδου ξεχωριστά όταν απαιτείται.

### **Μεγάλες Παρουσιάσεις και Χρήση Μνήμης**

Μεγάλες παρουσιάσεις που περιέχουν εικόνες υψηλής ανάλυσης, ήχους, βίντεο ή άλλα μεγάλα δυαδικά αντικείμενα μπορούν να καταναλώσουν σημαντική μνήμη. Το [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) προσφέρει επιλογές ελέγχου για τη διαχείριση BLOB και τη χρήση προσωρινών αρχείων. Δείτε την ενότητα [Manage Presentation BLOBs](/slides/el/androidjava/manage-blob/) για στρατηγικές μεγάλων αρχείων.

Για μεγάλα αρχεία, προτιμήστε τη φόρτωση από διαδρομές αρχείων όταν είναι δυνατόν, απελευθερώστε κάθε παρουσίαση πηγής μόλις ολοκληρωθεί η συγχώνευση και αποφύγετε την επαναλαμβανόμενη αποθήκευση ενδιάμεσων αποτελεσμάτων εκτός εάν η ροή εργασίας απαιτεί σημεία ελέγχου.

### **Ασφάλεια Πολυνηματικότητας**

Μην φορτώνετε, τροποποιείτε, αποθηκεύετε ή κλωνοποιείτε την ίδια [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) ταυτόχρονα από πολλαπλά νήματα. Κρατήστε κάθε παρουσίαση περιορισμένη σε μία λειτουργία συγχώνευσης. Εάν παράγετε ανεξάρτητες εργασίες παράλληλα, χρησιμοποιήστε ξεχωριστές παρουσιές και ακολουθήστε τις οδηγίες [Aspose.Slides multithreading guidance](/slides/el/androidjava/multithreading/).

## **FAQ**

**Πώς διατηρώ το αρχικό σχέδιο κάθε παρουσίασης πηγής;**

Χρησιμοποιήστε το [addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) χωρίς να παρέχετε master ή layout προορισμού. Το Aspose.Slides μπορεί αυτόματα να κλωνοποιήσει το master πηγής όταν απαιτείται από τη διαφάνεια που εισάγεται.

**Πώς κάνω ώστε οι εισαγόμενες διαφάνειες να χρησιμοποιούν το θέμα προορισμού;**

Χρησιμοποιήστε την υπερφόρτωση που δέχεται ένα master προορισμού. Περάστε ένα master από την προορισμένη παρουσίαση, όχι από την πηγή. Το Aspose.Slides θα προσπαθήσει να αντιστοιχίσει κάθε διαφάνεια πηγής σε ένα κατάλληλο layout κάτω από αυτό το master.

**Πότε πρέπει να χρησιμοποιήσω συγκεκριμένο layout προορισμού αντί για master προορισμού;**

Χρησιμοποιήστε συγκεκριμένο layout όταν κάθε εισαγόμενη διαφάνεια πρέπει να χρησιμοποιεί ένα γνωστό layout. Χρησιμοποιήστε master όταν θέλετε το Aspose.Slides να επιλέξει ανάμεσα στα layout του master βάσει του τύπου ή του ονόματος του layout πηγής.

**Μπορούν να συγχωνευτούν παρουσιάσεις με διαφορετικά μεγέθη διαφανειών;**

Ναι, αλλά το περιεχόμενο της διαφάνειας δεν επανασχεδιάζεται αυτόματα για τις διαστάσεις προορισμού. Αλλάξτε το μέγεθος της παρουσίασης πηγής πρώτα όταν χρειάζεται προβλεπόμενη διάταξη, π.χ. με το [SlideSize.setSize](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) και το [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slidesizescaletype/).

**Μπορώ να συγχωνεύσω PPT, PPTX και ODP παρουσιάσεις σε ένα αρχείο;**

Ναι. Φορτώστε κάθε παρουσίαση πηγής, κλωνοποιήστε τις απαιτούμενες διαφάνειες σε μία προορισμένη παρουσίαση και αποθηκεύστε το αποτέλεσμα σε υποστηριζόμενη μορφή εξόδου. Επειδή οι μορφές παρουσίασης δεν υποστηρίζουν ακριβώς το ίδιο σύνολο λειτουργιών, ελέγξτε το πολύπλοκο περιεχόμενο μετά τη διαφορομορφική συγχώνευση. Δείτε τη σελίδα [Supported File Formats](/slides/el/androidjava/supported-file-formats/).

**Διατηρούνται αυτόματα οι ενότητες πηγής;**

Όχι, από έναν βασικό βρόχο που κλωνοποιεί μόνο διαφάνειες. Αναδημιουργήστε τις απαιτούμενες ενότητες στην προορισμένη παρουσίαση και χρησιμοποιήστε την υπερφόρτωση ενότητας του [addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) όταν η δομή ενότητας πρέπει να διατηρηθεί.

**Διατηρούνται οι σημειώσεις ομιλητή και τα σχόλια;**

Αντιγράφονται μαζί με την κλωνοποιημένη διαφάνεια. Για ροές που εξαρτώνται από το στυλ του notes‑master, τους συγγραφείς σχολίων ή τις αλληλουχικές συνομιλίες, επαληθεύστε το τελικό αποτέλεσμα, καθώς αυτά τα σενάρια περιλαμβάνουν δομές επιπέδου παρουσίασης καθώς και περιεχόμενο διαφάνειας.

**Τι γίνεται με ήχο, βίντεο, αντικείμενα OLE και υπερσυνδέσμους;**

Το ενσωματωμένο περιεχόμενο μεταφέρεται ως μέρος των σχέσεων πόρων της κλωνοποιημένης διαφάνειας. Οι εξωτερικοί σύνδεσμοι παραμένουν εξωτερικοί, επομένως τα αρχεία‑στόχοι ή οι URL τους πρέπει να είναι διαθέσιμα μετά τη συγχώνευση.

**Εγγυώνται οι ενσωματωμένες γραμματοσειρές από κάθε πηγή στην τελική παρουσίαση;**

Μην βασίζεστε μόνο στην κλωνοποίηση διαφάνειας για την ανάπτυξη γραμματοσειρών. Εξετάστε τις ενσωματωμένες γραμματοσειρές του προορισμού και διαχειριστείτε ρητά την ενσωμάτωση ή τη διαθεσιμότητα εξωτερικών γραμματοσειρών όταν η τυπογραφία είναι σημαντική.

**Πώς συγχωνεύω ένα αρχείο με κωδικό πρόσβασης;**

Ανοίξτε το με το σωστό [LoadOptions.setPassword](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), στη συνέχεια κλωνοποιήστε τις διαφάνειές του κανονικά. Η προστασία εξόδου ρυθμίζεται ξεχωριστά.

**Πώς να διαχειριστώ πολύ μεγάλες παρουσιάσεις;**

Χρησιμοποιήστε τη διαχείριση BLOB όταν κυριαρχούν μεγάλα δυαδικά αντικείμενα, προτιμήστε τη φόρτωση από διαδρομές αρχείων για πολύ μεγάλα αρχεία, απελευθερώστε τις παρουσιάσεις πηγής άμεσα και αποθηκεύστε το τελικό αποτέλεσμα μόνο όταν είναι απαραίτητο.

**Μπορώ να συγχωνεύσω διαφάνειες από πολλαπλά νήματα;**

Μην χρησιμοποιείτε μία [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) ταυτόχρονα από πολλαπλά νήματα. Κρατήστε κάθε λειτουργία συγχώνευσης απομονωμένη στις δικές της παρουσιές.