---
title: Αποδοτική Συγχώνευση Παρουσιάσεων σε Android
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
description: "Μάθετε πώς να συγχωνεύετε παρουσιάσεις PowerPoint και OpenDocument σε Android κλωνοποιώντας διαφάνειες, ελέγχοντας masters και layouts, αλλάζοντας το μέγεθος του περιεχομένου των διαφανειών, διατηρώντας τις ενότητες και διαχειριζόμενοι προστατευμένα ή μεγάλα αρχεία."
---
## **Επισκόπηση**

Το Aspose.Slides for Android μέσω Java συγχωνεύει παρουσιάσεις κλωνοποιώντας διαφάνειες από μία [Παρουσίαση](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) σε άλλη. Η κύρια λειτουργία είναι το [ISlideCollection.addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), η οποία μπορεί να διατηρήσει τη μορφοποίηση της πηγαίας διαφάνειας ή να επισυνάψει τη κλωνοποιημένη διαφάνεια σε ένα master ή layout στην προοριστική παρουσίαση.

Αυτή η άρθρο καλύπτει τις πιο συνηθισμένες ροές συγχώνευσης:

- συγχώνευση όλων των διαφανειών διατηρώντας τη μορφοποίηση προέλευσής τους·  
- συγχώνευση επιλεγμένων διαφανειών·  
- εφαρμογή master από την προοριστική παρουσίαση·  
- εφαρμογή συγκεκριμένου layout από την προοριστική παρουσίαση·  
- ομαλοποίηση διαφορετικών μεγεθών διαφάνειας πριν τη συγχώνευση·  
- προσθήκη κλωνοποιημένων διαφανειών σε ενότητα·  
- συγχώνευση πολλαπλών παρουσιάσεων σε μια ολοκληρωμένη ροή εργασίας·  
- διαχείριση masters, πόρων, σημειώσεων, σχολίων, πολυμέσων, γραμματοσειρών, κωδικών πρόσβασης, μεγάλων αρχείων και προβλημάτων πολυνηματικότητας.

## **Πώς η Κλωνοποίηση Διαφανειών Επηρεάζει Masters και Layouts**

Μια διαφάνεια κληρονομεί μεγάλο μέρος της εμφάνισής της από το layout και το master της. Για τον λόγο αυτό, η υπερφόρτωση κλωνοποίησης που επιλέγετε καθορίζει πώς η συγχωνευμένη διαφάνεια ενσωματώνεται στην προοριστική παρουσίαση.

Χρησιμοποιήστε το [ISlideCollection.addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidecollection/) με έναν από τους παρακάτω τρόπους:

- `addClone(sourceSlide)` — διατηρήστε το layout και τη μορφοποίηση της πηγαίας διαφάνειας. Όταν απαιτείται, το master της πηγής μπορεί να κλωνοποιηθεί αυτόματα στην προοριστική παρουσίαση. Το Aspose.Slides παρακολουθεί αυτόματα κλωνοποιημένα masters ώστε επαναλαμβανόμενες διαφάνειες που χρησιμοποιούν το ίδιο master προέλευσης να μην κλωνοποιούν το master επανειλημμένα.  
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — επισυνάψτε τη κλωνοποιημένη διαφάνεια σε ένα συγκεκριμένο προοριστικό [IMasterSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterslide/). Το Aspose.Slides αναζητά ένα αντίστοιχο layout κάτω από αυτό το master με βάση τον τύπο ή το όνομα του layout.  
- `addClone(sourceSlide, destinationLayout)` — επισυνάψτε τη κλωνοποιημένη διαφάνεια απευθείας σε ένα συγκεκριμένο προοριστικό [ILayoutSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutslide/).

Το master ή layout που περνιέται σε μια υπερφόρτωση `addClone` πρέπει να ανήκει στην **προοριστική** παρουσίαση, όχι στην πηγαία παρουσίαση.

## **Συγχώνευση Ολόκληρων Παρουσιάσεων και Διατήρηση Μορφοποίησης Προέλευσης**

Η πιο απλή συγχώνευση αντιγράφει κάθε διαφάνεια από την πηγαία παρουσίαση στην προοριστική παρουσίαση. Αυτή είναι η κατάλληλη επιλογή όταν οι εισαγόμενες διαφάνειες πρέπει να διατηρήσουν το αρχικό θέμα, το master και τις σχέσεις των layout.

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

Δεν χρειάζεται να κλωνοποιήσετε κάθε διαφάνεια. Το παρακάτω παράδειγμα εισάγει μόνο επιλεγμένους δείκτες διαφανειών από την πηγαία παρουσίαση.

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

Επικυρώστε τους δείκτες διαφανειών πριν την κλωνοποίηση όταν προέρχονται από είσοδο χρήστη ή εξωτερική διαμόρφωση.

## **Συγχώνευση Διαφανειών Χρησιμοποιώντας Προοριστικό Master**

Χρησιμοποιήστε την υπερφόρτωση [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) όταν οι εισαγόμενες διαφάνειες πρέπει να ακολουθούν ένα master που ανήκει ήδη στην προοριστική παρουσίαση.

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

Το Aspose.Slides επιλέγει το κατάλληλο layout κάτω από το καθορισμένο master αντιστοιχίζοντας τον τύπο ή το όνομα του layout προέλευσης. Εάν δεν υπάρχει κατάλληλο layout και το `allowCloneMissingLayout` είναι `true`, το layout προέλευσης κλωνοποιείται ώστε η διαφάνεια να προστεθεί. Εάν είναι `false`, ρίχνεται ένα [PptxEditException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pptxeditexception/).

Χρησιμοποιήστε `false` όταν θέλετε η συγχώνευση να αποτύχει αντί να εισάγει ένα επιπλέον layout στο προοριστικό master.

## **Συγχώνευση Διαφανειών Χρησιμοποιώντας Συγκεκριμένο Προοριστικό Layout**

Χρησιμοποιήστε την υπερφόρτωση [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) όταν γνωρίζετε ακριβώς ποιο προοριστικό layout πρέπει να χρησιμοποιούν οι εισαγόμενες διαφάνειες.

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

Η εφαρμογή ενός προοριστικού layout αλλάζει τη σχέση κληρονομικού layout· δεν επανασχεδιάζει το περιεχόμενο της πηγαίας διαφάνειας. Εάν τα layout πηγής και προορισμού έχουν διαφορετικές δομές placeholders, εξετάστε το αποτέλεσμα για να επιβεβαιώσετε ότι η κληρονομική μορφοποίηση και η συμπεριφορά των placeholders είναι κατάλληλη.

## **Συγχώνευση Παρουσιάσεων με Διαφορετικά Μεγέθη Διαφάνειας**

Παραγόμενες παρουσιάσεις με διαφορετικές διαστάσεις διαφάνειας μπορούν να συγχωνευτούν, αλλά η κλωνοποίηση μιας διαφάνειας σε παρουσίαση με διαφορετικό μέγεθος διαφάνειας δεν επανασχεδιάζει αυτόματα το περιεχόμενό της για το νέο καμβά. Οι σχήματα ενδέχεται να εμφανιστούν μετατοπισμένα, κλιμακωμένα απροσδόκητα ή έξω από το ορατό πεδίο της διαφάνειας.

Μία πρακτική προσέγγιση είναι να αλλάξετε το μέγεθος της πηγαίας παρουσίασης πριν την κλωνοποίηση. Η μέθοδος [SlideSize.setSize](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) μπορεί να κλιμακώσει το υπάρχον περιεχόμενο ενώ αλλάζει τις διαστάσεις της διαφάνειας. Η [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slidesizescaletype/) κλιμακώνει το περιεχόμενο ώστε να χωράει στο ζητούμενο μέγεθος.

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

Η αλλαγή μεγέθους τροποποιεί το αντικείμενο της πηγαίας παρουσίασης στη μνήμη. Εάν χρειάζεστε την αρχική πηγαία παρουσίαση αμετάβλητη για άλλες λειτουργίες, ανοίξτε μια ξεχωριστή παρουσίαση για τη συγχώνευση.

## **Συγχώνευση Διαφανειών σε Ενότητα Παρουσίασης**

Ο βασικός βρόχος κλωνοποίησης διαφανειών δεν δημιουργεί ξανά την ιεραρχία ενοτήτων της πηγαίας παρουσίασης. Εάν οι ενότητες έχουν σημασία στο έξοδο, δημιουργήστε ή επιλέξτε ενότητες στην προοριστική παρουσίαση και κλωνοποιήστε διαφάνειες σε αυτές ρητά με το [addClone(ISlide, ISection)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

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

Οι κλωνοποιημένες διαφάνειες προσαρτώνται στην καθορισμένη προοριστική ενότητα. Για να διατηρήσετε πολλές πηγικές ενότητες, δημιουργήστε ξανά αυτές τις ενότητες στην προοριστική παρουσίαση και αντιστοιχίστε κάθε πηγαία διαφάνεια στην αντίστοιχη προοριστική ενότητα.

## **Συγχώνευση Πολλών Παρουσιάσεων με Ασφάλεια**

Το παρακάτω παράδειγμα πλήρους ροής χρησιμοποιεί την πρώτη παρουσίαση ως προορισμό, ομαλοποιεί το μέγεθος διαφάνειας κάθε πρόσθετης πηγής, κρατά κάθε πηγή ανοικτή μόνο όσο αντιγράφεται, και αποθηκεύει το τελικό αρχείο μια φορά.

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

Αυτή είναι μια χρήσιμη βάση για τη διατήρηση της μορφοποίησης προέλευσης των εισαγόμενων διαφανειών. Εάν το αποτέλεσμα σας πρέπει να χρησιμοποιεί ένα ενιαίο προοριστικό θέμα, αντικαταστήστε την απλή κλήση `addClone(slide)` με την κατάλληλη υπερφόρτωση destination‑master ή destination‑layout που φαίνεται παραπάνω.

## **Πρακτικές Παρατηρήσεις**

### **Masters, Layouts και Ακρίβεια Μορφοποίησης**

Η προεπιλεγμένη κλωνοποίηση διαφανειών μπορεί αυτόματα να μεταφέρει ένα απαιτούμενο master της πηγής στην προοριστική παρουσίαση. Το Aspose.Slides διατηρεί ένα εσωτερικό μητρώο για αυτόματα κλωνοποιημένα masters ώστε να αποφεύγεται η επαναλαμβανόμενη κλωνοποίηση του ίδιου master. Τα χειροκίνητα κλωνοποιημένα masters δεν παρακολουθούνται από αυτό το μητρώο, επομένως αποφύγετε την προ‑κλωνοποίηση masters εκτός εάν χρειάζεστε ρητό έλεγχο της δομής του master.

Μην υποθέτετε ότι δύο masters ή layouts με το ίδιο όνομα είναι οπτικά ισοδύναμα. Εάν ένα εταιρικό πρότυπο πρέπει να ελέγχει την τελική εμφάνιση, επιλέξτε ρητά έναν προοριστικό master ή layout και επαληθεύστε το αποτέλεσμα μετά τη συγχώνευση.

### **Σημειώσεις και Σχόλια**

Οι σημειώσεις ομιλητή και τα σχόλια διαφάνειας συνδέονται με το περιεχόμενο της διαφάνειας και αντιγράφονται όταν κλωνοποιείται μια διαφάνεια. Το Aspose.Slides παρέχει επίσης εξειδικευμένα API για [σημειώσεις παρουσίασης](https://docs.aspose.com/slides/el/androidjava/presentation-notes/) και [σχόλια παρουσίασης](https://docs.aspose.com/slides/el/androidjava/presentation-comments/).

Εάν η μορφοποίηση της σελίδας σημειώσεων είναι σημαντική, επαληθεύστε την προκύπτουσα παρουσίαση, επειδή τα notes masters είναι αντικείμενα επιπέδου παρουσίασης και μπορεί να διαφέρουν μεταξύ των αρχείων προέλευσης. Για ροές ελέγχου, επαληθεύστε επίσης τους συγγραφείς σχολίων και τα νημάτια σχολίων μετά το συνδυασμό αρχείων από διαφορετικούς συγγραφείς ή πρότυπα.

### **Εικόνες, Ήχος, Βίντεο, Αντικείμενα OLE και Εξωτερικοί Σύνδεσμοι**

Οι διαφάνειες μπορούν να αναφέρονται σε πόρους επιπέδου παρουσίασης όπως εικόνες, ενσωματωμένο ήχο, ενσωματωμένο βίντεο και δεδομένα OLE. Κλωνοποιήστε τη διαφάνεια αυτή καθ' αυτή αντί να αντιγράψετε μόνο τα ορατά σχήματα ώστε το Aspose.Slides να διατηρήσει τις σχέσεις της διαφάνειας με τους πόρους της.

Οι ενσωματωμένοι και συνδεδεμένοι πόροι πρέπει να αντιμετωπίζονται διαφορετικά. Ένας συνδεδεμένος ήχος, βίντεο, αντικείμενο OLE ή υπερσύνδεσμος παραμένει εξαρτημένος από τον εξωτερικό του προορισμό· η κλωνοποίηση μιας διαφάνειας δεν μετατρέπει έναν εξωτερικό σύνδεσμο σε ενσωματωμένο περιεχόμενο. Δοκιμάστε τις διαδρομές και τα URLs των συνδεδεμένων πόρων στο περιβάλλον όπου η συγχωνευμένη παρουσίαση θα ανοίξει.

Το Aspose.Slides παρακολουθεί ρητά τα αυτόματα κλωνοποιημένα masters, αλλά αυτό δεν πρέπει να θεωρείται γενική εγγύηση ότι τα ίδια δυαδικά αρχεία από διαφορετικές πηγές θα αφαιρεθούν πάντα. Εάν το μέγεθος του αρχείου εξόδου είναι σημαντικό, εξετάστε το συγχωνευμένο πακέτο και μετρήστε το αποτέλεσμα αντί να βασίζεστε σε έμμεση αποπλεοναστική διαχείριση.

### **Ενσωματωμένες Γραμματοσειρές και Διαθεσιμότητα Γραμματοσειρών**

Οι γραμματοσειρές διαχειρίζονται σε επίπεδο παρουσίασης. Εάν η τυπογραφία πρέπει να παραμένει συνεπής μεταξύ των μηχανών, μην υποθέτετε ότι η κλωνοποίηση διαφανειών μόνη εξασφαλίζει ότι κάθε απαιτούμενη γραμματοσειρά είναι διαθέσιμη στο περιβάλλον προορισμού. Μπορείτε να εξετάσετε τις ενσωματωμένες γραμματοσειρές με το [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) και να διαχειριστείτε την ενσωμάτωση ρητά όπως περιγράφεται στο [Embed Fonts in Presentations](https://docs.aspose.com/slides/el/androidjava/embedded-font/).

Επιβεβαιώστε επίσης ότι έχετε άδεια να ενσωματώσετε τις γραμματοσειρές που χρησιμοποιούν τα πηγαία αρχεία. Οι άδειες γραμματοσειρών μπορεί να περιορίζουν την ενσωμάτωση.

### **Παρουσιάσεις με Προστασία Κωδικού Πρόσβασης**

Μια πηγή με κωδικό πρόσβασης πρέπει να ανοίξει επιτυχώς πριν τις διαφάνειες της κλωνοποιηθούν. Παρέχετε τον κωδικό μέσω του [LoadOptions.setPassword](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

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

Το άνοιγμα μιας κρυπτογραφημένης πηγής δεν εφαρμόζει αυτόματα την ίδια προστασία στην προοριστική παρουσίαση. Διαμορφώστε την προστασία εξόδου ξεχωριστά όταν απαιτείται.

### **Μεγάλες Παρουσιάσεις και Χρήση Μνήμης**

Οι μεγάλες παρουσιάσεις που περιέχουν εικόνες υψηλής ανάλυσης, ήχο, βίντεο ή άλλα μεγάλα δυαδικά αντικείμενα μπορούν να καταναλώνουν σημαντική μνήμη. Η μέθοδος [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) παρέχει ελέγχους για το χειρισμό BLOB και τη χρήση προσωρινών αρχείων. Δείτε το [Manage Presentation BLOBs](https://docs.aspose.com/slides/el/androidjava/manage-blob/) για στρατηγικές μεγάλων αρχείων.

Για μεγάλα αρχεία, προτιμήστε τη φόρτωση από διαδρομές αρχείων όταν είναι δυνατόν, εκκαθαρίστε κάθε πηγή παρουσίασης μόλις συγχωνευθεί και αποφύγετε την επαναλαμβανόμενη αποθήκευση ενδιάμεσων αποτελεσμάτων εκτός εάν η ροή εργασίας απαιτεί σημεία ελέγχου.

### **Ασφάλεια Νημάτων**

Μην φορτώνετε, τροποποιείτε, αποθηκεύετε ή κλωνοποιείτε το ίδιο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) ταυτόχρονα από πολλαπλά νήματα. Διατηρήστε κάθε παρουσίαση περιορισμένη σε μια λειτουργία συγχώνευσης. Εάν παράλληλα εκτελείτε ανεξάρτητες εργασίες, χρησιμοποιήστε ανεξάρτητα αντικείμενα παρουσίασης και ακολουθήστε τις οδηγίες [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/el/androidjava/multithreading/).

## **FAQ**

**Πώς να διατηρήσω το αρχικό σχέδιο κάθε πηγαίας παρουσίασης;**  
Χρησιμοποιήστε το [`addClone(sourceSlide)`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) χωρίς να παρέχετε προοριστικό master ή layout. Το Aspose.Slides μπορεί αυτόματα να κλωνοποιήσει το master της πηγής όταν απαιτείται από την εισαγόμενη διαφάνεια.

**Πώς να κάνω τις εισαγόμενες διαφάνειες να χρησιμοποιούν το προοριστικό θέμα;**  
Χρησιμοποιήστε την υπερφόρτωση που δέχεται προοριστικό master. Περάστε ένα master από την προοριστική παρουσίαση, όχι από την πηγή. Το Aspose.Slides θα προσπαθήσει να αντιστοιχίσει κάθε πηγαία διαφάνεια σε ένα κατάλληλο layout κάτω από αυτό το master.

**Πότε πρέπει να χρησιμοποιήσω συγκεκριμένο προοριστικό layout αντί για προοριστικό master;**  
Χρησιμοποιήστε ένα συγκεκριμένο layout όταν κάθε εισαγόμενη διαφάνεια πρέπει να χρησιμοποιεί ένα γνωστό layout. Χρησιμοποιήστε ένα master όταν θέλετε το Aspose.Slides να επιλέγει ανάμεσα στα layout του master βάσει του τύπου ή του ονόματος του layout προέλευσης.

**Μπορούν οι παρουσιάσεις με διαφορετικά μεγέθη διαφάνειας να συγχωνευτούν;**  
Ναι, αλλά το περιεχόμενο των διαφωνιών δεν επανασχεδιάζεται αυτόματα για τις διαστάσεις προορισμού. Αλλάξτε το μέγεθος της πηγαίας παρουσίασης πρώτα όταν χρειάζεστε προβλέψιμη τοποθέτηση, π.χ. με το [SlideSize.setSize](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) και το [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slidesizescaletype/).

**Μπορώ να συγχωνεύσω PPT, PPTX και ODP παρουσιάσεις σε ένα αρχείο;**  
Ναι. Φορτώστε κάθε πηγαία παρουσίαση, κλωνοποιήστε τις απαιτούμενες διαφάνειες σε έναν προορισμό και αποθηκεύστε τον προορισμό σε μια υποστηριζόμενη μορφή εξόδου. Επειδή οι μορφές παρουσίασης δεν υποστηρίζουν ακριβώς το ίδιο σύνολο λειτουργιών, επαληθεύστε το σύνθετο περιεχόμενο μετά τη συγχώνευση μεταξύ διαφορετικών μορφών. Δείτε το [Supported File Formats](https://docs.aspose.com/slides/el/androidjava/supported-file-formats/).

**Διατηρούνται αυτόματα οι πηγικές ενότητες;**  
Όχι με έναν βασικό βρόχο που κλωνοποιεί μόνο διαφάνειες. Δημιουργήστε ξανά τις απαιτούμενες ενότητες στην προοριστική παρουσίαση και χρησιμοποιήστε την υπερφόρτωση ενότητας του [addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) όταν πρέπει να διατηρηθεί η δομή των ενοτήτων.

**Διατηρούνται οι σημειώσεις ομιλητή και τα σχόλια;**  
Αντιγράφονται μαζί με τη κλωνοποιημένη διαφάνεια. Για ροές εργασίας που εξαρτώνται από τη μορφοποίηση του notes‑master, τους συγγραφείς σχολίων ή τα δεδομένα αξιολόγησης σε νήμα, επαληθεύστε το αποτέλεσμα της συγχώνευσης επειδή αυτά τα σενάρια περιλαμβάνουν δομές επιπέδου παρουσίασης καθώς και περιεχόμενο επιπέδου διαφάνειας.

**Τι συμβαίνει με ήχο, βίντεο, αντικείμενα OLE και υπερσυνδέσμους;**  
Το ενσωματωμένο περιεχόμενο μεταφέρεται ως μέρος των σχέσεων πόρων της κλωνοποιημένης διαφάνειας. Οι εξωτερικοί σύνδεσμοι παραμένουν εξωτερικοί, επομένως τα αρχεία-στόχοι ή τα URLs τους πρέπει να είναι ακόμη διαθέσιμα μετά τη συγχώνευση.

**Εγγυώνονται οι ενσωματωμένες γραμματοσειρές από κάθε πηγή στην τελική παρουσίαση;**  
Μην βασίζεστε μόνο στην κλωνοποίηση διαφανειών για την ανάπτυξη γραμματοσειρών. Εξετάστε τις ενσωματωμένες γραμματοσειρές στην προοριστική παρουσίαση και διαχειριστείτε ρητά την ενσωμάτωση γραμματοσειρών ή τη διαθεσιμότητα εξωτερικών γραμματοσειρών όταν η τυπογραφία είναι σημαντική.

**Πώς να συγχωνεύσω ένα αρχείο με προστασία κωδικού πρόσβασης;**  
Ανοίξτε το με το σωστό [LoadOptions.setPassword](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), στη συνέχεια κλωνοποιήστε τις διαφάνειές του κανονικά. Η προστασία εξόδου διαμορφώνεται ξεχωριστά.

**Πώς πρέπει να διαχειριστώ πολύ μεγάλες παρουσιάσεις;**  
Χρησιμοποιήστε τη διαχείριση BLOB όταν μεγάλα δυαδικά αντικείμενα κυριαρχούν στη χρήση μνήμης, προτιμήστε φόρτωση από διαδρομή αρχείου για πολύ μεγάλα αρχεία, διαγράψτε γρήγορα τις πηγές παρουσίασης και αποθηκεύστε το τελικό αποτέλεσμα μόνο όταν είναι απαραίτητο.

**Μπορώ να συγχωνεύσω διαφάνειες από πολλαπλά νήματα;**  
Μην χρησιμοποιείτε ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) ταυτόχρονα από πολλαπλά νήματα. Κρατήστε κάθε λειτουργία συγχώνευσης απομονωμένη στις δικές της παρουσιές.