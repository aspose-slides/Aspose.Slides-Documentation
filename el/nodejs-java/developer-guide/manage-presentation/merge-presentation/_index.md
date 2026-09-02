---
title: Αποτελεσματική Συγχώνευση Παρουσιάσεων σε JavaScript
linktitle: Συγχώνευση Παρουσιάσεων
type: docs
weight: 40
url: /el/nodejs-java/merge-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να συγχωνεύετε παρουσιάσεις PowerPoint και OpenDocument σε JavaScript κλωνοποιώντας διαφάνειες, ελέγχοντας masters και layouts, αλλάζοντας το μέγεθος του περιεχομένου των διαφανειών, διατηρώντας τις ενότητες και διαχειριζόμενοι προστατευμένα ή μεγάλα αρχεία."
---
## **Επισκόπηση**

Το Aspose.Slides for Node.js μέσω Java συγχωνεύει παρουσιάσεις κλωνοποιώντας διαφάνειες από ένα [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) σε άλλο. Η κύρια λειτουργία είναι [SlideCollection.addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-), η οποία μπορεί να διατηρήσει τη μορφοποίηση της διαφάνειας‑προέλευσης ή να συνδέσει τη κλωνοποιημένη διαφάνεια με ένα master ή layout στην προοριστική παρουσίαση.

Αυτό το άρθρο καλύπτει τις πιο κοινές ροές εργασίας συγχώνευσης:

- συγχώνευση όλων των διαφανειών διατηρώντας τη μορφοποίηση της πηγής·
- συγχώνευση επιλεγμένων διαφανειών·
- εφαρμογή master από την προοριστική παρουσίαση·
- εφαρμογή συγκεκριμένου layout από την προοριστική παρουσίαση·
- ομαλοποίηση διαφορετικών μεγεθών διαφανειών πριν τη συγχώνευση·
- προσθήκη κλωνοποιημένων διαφανειών σε ενότητα·
- συγχώνευση πολλαπλών παρουσιάσεων σε μια ολοκληρωμένη ροή εργασίας·
- διαχείριση masters, πόρων, σημειώσεων, σχολίων, πολυμέσων, γραμματοσειρών, κωδικών πρόσβασης, μεγάλων αρχείων και θεμάτων πολυνηματικότητας.

## **Πώς η κλωνοποίηση διαφανειών επηρεάζει Masters και Layouts**

Μια διαφάνεια κληρονομεί μεγάλο μέρος της εμφάνισής της από το layout και το master της. Για το λόγο αυτό, η υπερφόρτωση κλωνοποίησης που επιλέγετε καθορίζει πώς η συγχωνευμένη διαφάνεια ενσωματώνεται στην προοριστική παρουσίαση.

Χρησιμοποιήστε [SlideCollection.addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidecollection/) με έναν από τους ακόλουθους τρόπους:

- `addClone(sourceSlide)` — διατηρεί το layout και τη μορφοποίηση της διαφάνειας‑προέλευσης. Όταν απαιτείται, το master της προέλευσης μπορεί να κλωνοποιηθεί αυτόματα στην προοριστική παρουσίαση. Το Aspose.Slides παρακολουθεί αυτόματα κλωνοποιημένα masters ώστε επαναλαμβανόμενες διαφάνειες που χρησιμοποιούν το ίδιο master προέλευσης να μην προκαλούν επαναλαμβανόμενο κλωνοποίηση του master.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — συνδέει τη κλωνοποιημένη διαφάνεια με ένα συγκεκριμένο [MasterSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterslide/) προορισμού. Το Aspose.Slides αναζητά ένα ταιριαστό layout κάτω από αυτό το master με βάση τον τύπο ή το όνομα του layout.
- `addClone(sourceSlide, destinationLayout)` — συνδέει τη κλωνοποιημένη διαφάνεια άμεσα με ένα συγκεκριμένο [LayoutSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslide/) προορισμού.

Το master ή το layout που περνιέται σε μια υπερφόρτωση `addClone` πρέπει να ανήκει στην **προοριστική** παρουσίαση, όχι στην παρουσίαση‑προέλευση.

## **Συγχώνευση ολόκληρων παρουσιάσεων και διατήρηση μορφοποίησης προέλευσης**

Η πιο απλή συγχώνευση αντιγράφει κάθε διαφάνεια από την παρουσίαση‑προέλευση στην προοριστική παρουσίαση. Αυτή είναι η κατάλληλη επιλογή όταν οι εισαγόμενες διαφάνειες πρέπει να διατηρήσουν το αρχικό θέμα, το master και τις σχέσεις layout.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Η προκύπτουσα παρουσίαση μπορεί να περιέχει πολλαπλά masters όταν η προέλευση και ο προορισμός χρησιμοποιούν διαφορετικά σχέδια. Αυτό είναι αναμενόμενο όταν η μορφοποίηση της προέλευσης διατηρείται σκόπιμα.

## **Συγχώνευση επιλεγμένων διαφανειών**

Δεν χρειάζεται να κλωνοποιήσετε κάθε διαφάνεια. Το παρακάτω παράδειγμα εισάγει μόνο επιλεγμένους δείκτες διαφανειών από την παρουσίαση‑προέλευση.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const slideIndexes = [0, 2, 4];

    for (const index of slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Επικυρώστε τους δείκτες διαφανειών πριν την κλωνοποίηση όταν προέρχονται από είσοδο χρήστη ή εξωτερική διαμόρφωση.

## **Συγχώνευση διαφανειών χρησιμοποιώντας Master προορισμού**

Χρησιμοποιήστε την υπερφόρτωση [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) όταν οι εισαγόμενες διαφάνειες πρέπει να ακολουθούν ένα master που ήδη ανήκει στην προοριστική παρουσίαση.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationMaster = destination.getMasters().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Το Aspose.Slides επιλέγει ένα κατάλληλο layout κάτω από το καθορισμένο master ταιριάζοντας με τον τύπο ή το όνομα του layout της προέλευσης. Αν δεν υπάρχει κατάλληλο layout και το `allowCloneMissingLayout` είναι `true`, το layout της προέλευσης κλωνοποιείται ώστε η διαφάνεια να προστεθεί. Αν είναι `false`, ρίχνεται μια [PptxEditException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pptxeditexception/).

Χρησιμοποιήστε `false` όταν θέλετε η συγχώνευση να αποτύχει αντί να προσθέσει ένα επιπλέον layout στο master προορισμού.

## **Συγχώνευση διαφανειών χρησιμοποιώντας συγκεκριμένο Layout προορισμού**

Χρησιμοποιήστε την υπερφόρτωση [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) όταν γνωρίζετε ακριβώς ποιο layout προορισμού πρέπει να χρησιμοποιούν οι εισαγόμενες διαφάνειες.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Η εφαρμογή ενός layout προορισμού αλλάζει τη κληρονομική σχέση layout· δεν επανασχεδιάζει το περιεχόμενο της διαφάνειας‑προέλευσης. Αν τα layout προέλευσης και προορισμού έχουν διαφορετικές δομές placeholders, εξετάστε το αποτέλεσμα για να επιβεβαιώσετε ότι η κληρονομική μορφοποίηση και η συμπεριφορά των placeholders είναι κατάλληλες.

## **Συγχώνευση παρουσιάσεων με διαφορετικά μεγέθη διαφανειών**

Παραστάσεις με διαφορετικές διαστάσεις διαφάνειας μπορούν να συγχωνευτούν, αλλά η κλωνοποίηση μιας διαφάνειας σε παρουσίαση με άλλο μέγεθος διαφάνειας δεν επανασχεδιάζει αυτόματα το περιεχόμενό της για το νέο καμβά. Έτσι τα σχήματα μπορεί να εμφανιστούν μετατοπισμένα, κλιμακωμένα ανεξήγητα ή εκτός του ορατού τμήματος της διαφάνειας.

Μια πρακτική προσέγγιση είναι να αλλάξετε το μέγεθος της παρουσίασης‑προέλευσης πριν την κλωνοποίηση. Η μέθοδος [SlideSize.setSize](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) μπορεί να κλιμακώσει το υπάρχον περιεχόμενο ενώ αλλάζει τις διαστάσεις της διαφάνειας. Το [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidesizescaletype/) κλιμακώνει το περιεχόμενο ώστε να ταιριάζει στο απαιτούμενο μέγεθος.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const sourceSize = source.getSlideSize().getSize();
    const destinationSize = destination.getSlideSize().getSize();
    const sizesDiffer = sourceSize.getWidth() !== destinationSize.getWidth() || 
                        sourceSize.getHeight() !== destinationSize.getHeight();

    if (sizesDiffer) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            aspose.slides.SlideSizeScaleType.EnsureFit);
    }

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged-same-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Η αλλαγή μεγέθους τροποποιεί το αντικείμενο της παρουσίασης‑προέλευσης στη μνήμη. Αν χρειάζεστε την αρχική παρουσίαση‑προέλευση αμετάβλητη για άλλες εργασίες, ανοίξτε ένα ξεχωριστό αντίγραφο για τη συγχώνευση.

## **Συγχώνευση διαφανειών σε ενότητα παρουσίασης**

Ο βασικός βρόχος κλωνοποίησης διαφανειών δεν αναδημιουργεί την ιεραρχία ενοτήτων της παρουσίασης‑προέλευσης. Αν οι ενότητες έχουν σημασία στο αποτέλεσμα, δημιουργήστε ή επιλέξτε ενότητες στην προοριστική παρουσίαση και κλωνοποιήστε τις διαφάνειες σε αυτές ρητά με [addClone(Slide, Section)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-).

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), importedSection);
    }

    destination.save("merged-with-section.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Οι κλωνοποιημένες διαφάνειες προσαρτώνται στην καθορισμένη ενότητα προορισμού. Για να διατηρήσετε πολλές ενότητες προέλευσης, επαναλάβετε [Presentation.getSections](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#getSections), ανακτήστε τις τρέχουσες διαφάνειες κάθε ενότητας με [Section.getSlidesListOfSection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/section/#getSlidesListOfSection), δημιουργήστε ξανά τις ενότητες στην προοριστική παρουσίαση και κλωνοποιήστε κάθε διαφάνεια στην αντίστοιχη ενότητα προορισμού. Δείτε το [Manage Slide Sections](/slides/el/nodejs-java/slide-section/) για ένα πλήρες παράδειγμα καταμέτρησης ενοτήτων, συμπεριλαμβανομένων κενών ενοτήτων και δομικών αλλαγών.

## **Ασφαλής συγχώνευση πολλαπλών παρουσιάσεων**

Το παρακάτω παράδειγμα πλήρους ροής χρησιμοποιεί την πρώτη παρουσίαση ως προορισμό, ομαλοποιεί το μέγεθος διαφάνειας κάθε πρόσθετης προέλευσης, κρατά κάθε προέλευση ανοικτή μόνο όσο αντιγράφεται, και αποθηκεύει το τελικό αρχείο μία φορά.

```javascript
const aspose = require("aspose.slides.via.java");

const inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

const merged = new aspose.slides.Presentation(inputFiles[0]);
try {
    const mergedSize = merged.getSlideSize().getSize();

    for (let fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        const source = new aspose.slides.Presentation(inputFiles[fileIndex]);
        try {
            const sourceSize = source.getSlideSize().getSize();
            const sizesDiffer = sourceSize.getWidth() !== mergedSize.getWidth() || 
                                sourceSize.getHeight() !== mergedSize.getHeight();

            if (sizesDiffer) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    aspose.slides.SlideSizeScaleType.EnsureFit);
            }

            for (let slideIndex = 0; slideIndex < source.getSlides().size(); slideIndex++) {
                merged.getSlides().addClone(source.getSlides().get_Item(slideIndex));
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

Αυτή είναι μια χρήσιμη βάση για τη διατήρηση της μορφοποίησης της πηγής των εισαγόμενων διαφανειών. Αν το αποτέλεσμα πρέπει να χρησιμοποιεί ένα ενιαίο θέμα προορισμού, αντικαταστήστε την απλή κλήση `addClone(sourceSlide)` με την κατάλληλη υπερφόρτωση master‑προορισμού ή layout‑προορισμού που παρουσιάστηκε νωρίτερα.

## **Πρακτικές παρατηρήσεις**

### **Masters, Layouts και πιστότητα μορφοποίησης**

Η προεπιλεγμένη κλωνοποίηση διαφάνειας μπορεί αυτόματα να φέρει ένα απαιτούμενο master προέλευσης στην προοριστική παρουσίαση. Το Aspose.Slides διατηρεί ένα εσωτερικό μητρώο για αυτόματα κλωνοποιημένα masters ώστε να αποφεύγεται η επαναλαμβανόμενη κλωνοποίηση του ίδιου master. Τα χειροκίνητα κλωνοποιημένα masters δεν καταγράφονται σε αυτό το μητρώο, οπότε αποφεύγετε την προ-κλωνοποίηση masters εκτός αν χρειάζεστε ρητό έλεγχο της δομής του master.

Μην υποθέτετε ότι δύο masters ή layouts με το ίδιο όνομα είναι οπτικά ισοδύναμα. Αν ένα εταιρικό πρότυπο πρέπει να ελέγχει την τελική εμφάνιση, επιλέξτε ρητά ένα master ή layout προορισμού και επαληθεύστε το αποτέλεσμα μετά τη συγχώνευση.

### **Σημειώσεις και σχόλια**

Οι σημειώσεις ομιλητή και τα σχόλια διαφάνειας συνδέονται με το περιεχόμενο της διαφάνειας και αντιγράφονται όταν κλωνοποιείται η διαφάνεια. Το Aspose.Slides παρέχει επίσης ειδικά API για [presentation notes](/slides/el/nodejs-java/presentation-notes/) και [presentation comments](/slides/el/nodejs-java/presentation-comments/).

Αν η μορφοποίηση της σελίδας σημειώσεων είναι σημαντική, επιβεβαιώστε την συγχωνευμένη παρουσίαση επειδή οι masters σημειώσεων είναι αντικείμενα επιπέδου παρουσίασης και μπορεί να διαφέρουν μεταξύ αρχείων‑προέλευσης. Για διαδικασίες ελέγχου, ελέγξτε επίσης τους συγγραφείς σχολίων και τα νήματα σχολίων μετά τη συνένωση αρχείων από διαφορετικούς συγγραφείς ή πρότυπα.

### **Εικόνες, Ήχος, Βίντεο, Αντικείμενα OLE και εξωτερικοί σύνδεσμοι**

Οι διαφάνειες μπορούν να αναφέρονται σε πόρους επιπέδου παρουσίασης όπως εικόνες, ενσωματωμένο ήχο, ενσωματωμένο βίντεο και δεδομένα OLE. Κλωνοποιήστε τη διαφάνεια ίδιανυδς αντί να αντιγράψετε μόνο τα ορατά σχήματα ώστε το Aspose.Slides να διατηρήσει τις σχέσεις της διαφάνειας με τους πόρους της.

Οι ενσωματωμένοι και οι συνδεδεμένοι πόροι πρέπει να αντιμετωπίζονται διαφορετικά. Ένας συνδεδεμένος ήχος, βίντεο, αντικείμενο OLE ή υπερσύνδεσμος παραμένει εξαρτημένος από τον εξωτερικό του στόχο· η κλωνοποίηση μιας διαφάνειας δεν μετατρέπει έναν εξωτερικό σύνδεσμο σε ενσωματωμένο περιεχόμενο. Δοκιμάστε τις διαδρομές και τις URL των συνδεδεμένων πόρων στο περιβάλλον όπου θα ανοίξει η συγχωνευμένη παρουσίαση.

Το Aspose.Slides παρακολουθεί αυτόματα κλωνοποιημένα masters, αλλά αυτό δεν αποτελεί γενική εγγύηση ότι τα ίδια δυαδικά αρχεία από ανεξάρτητες πηγές θα αφαιρεθούν αυτόματα. Αν το μέγεθος του αρχείου εξόδου είναι σημαντικό, ελέγξτε το συγχωνευμένο πακέτο και μετρήστε το αποτέλεσμα αντί να βασίζεστε σε άμεση αφαίρεση διπλοτύπων.

### **Ενσωματωμένες γραμματοσειρές και διαθεσιμότητα γραμματοσειρών**

Οι γραμματοσειρές διαχειρίζονται σε επίπεδο παρουσίασης. Αν η τυπογραφία πρέπει να παραμείνει συνεπής μεταξύ συσκευών, μην υποθέτετε ότι η κλωνοποίηση διαφανειών μόνη της εγγυάται ότι κάθε απαιτούμενη γραμματοσειρά είναι διαθέσιμη στο περιβάλλον προορισμού. Μπορείτε να ελέγξετε τις ενσωματωμένες γραμματοσειρές με [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) και να διαχειριστείτε την ενσωμάτωση όπως περιγράφεται στο [Embed Fonts in Presentations](/slides/el/nodejs-java/embedded-font/).

Επίσης, βεβαιωθείτε ότι έχετε το δικαίωμα να ενσωματώσετε τις γραμματοσειρές που χρησιμοποιούν τα αρχεία‑προέλευσης. Οι άδειες γραμματοσειρών μπορεί να περιορίζουν την ενσωμάτωση.

### **Παρουσιάσεις με κωδικό πρόσβασης**

Μια πηγή προστατευμένη με κωδικό πρέπει να ανοίξει επιτυχώς πριν τις διαφάνειές της μπορούν να κλωνοποιηθούν. Πάρετε τον κωδικό μέσω [LoadOptions.setPassword](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#setPassword-String-).

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // Εργαστείτε με την αποκρυπτογραφημένη παρουσίαση.
} finally {
    source.dispose();
}
```

Το άνοιγμα ενός κρυπτογραφημένου αρχείου δεν εφαρμόζει αυτόματα την ίδια προστασία στην προοριστική παρουσίαση. Διαμορφώστε την προστασία εξόδου ξεχωριστά όταν απαιτείται.

### **Μεγάλες παρουσιάσεις και χρήση μνήμης**

Μεγάλες παρουσιάσεις που περιέχουν εικόνες υψηλής ανάλυσης, ήχο, βίντεο ή άλλα μεγάλα δυαδικά αντικείμενα μπορούν να καταναλώσουν σημαντική μνήμη. Η μέθοδος [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) παρέχει ελέγχους για τη διαχείριση BLOB και τη χρήση προσωρινών αρχείων. Δείτε τη σελίδα [Manage Presentation BLOBs](/slides/el/nodejs-java/manage-blob/) για στρατηγικές μεγάλων αρχείων.

Για μεγάλα αρχεία, προτιμήστε τη φόρτωση από μονοπάτια αρχείων όταν είναι δυνατόν, απελευθερώστε κάθε παρουσίαση‑προέλευση μόλις ολοκληρωθεί η συγχώνευσή της, και αποφύγετε την επανειλημμένη αποθήκευση ενδιάμεσων αποτελεσμάτων εκτός αν η ροή εργασίας απαιτεί σημεία ελέγχου.

### **Ασφάλεια νήματος**

Μην φορτώνετε, αποθηκεύετε ή κλωνοποιείτε ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) σε πολλαπλά νήματα. Οι λειτουργίες αυτές δεν υποστηρίζονται για πολυνηματική χρήση. Αν χρειαστεί να παράλληλες ανεξάρτητες εργασίες συγχώνευσης, χρησιμοποιήστε πολλαπλές διαδικασίες μονόνημα, καθεμία με τα δικά της αντικείμενα παρουσίασης, και ακολουθήστε τις οδηγίες πολυνηματικότητας του [Aspose.Slides](/slides/el/nodejs-java/multithreading/).

## **Συχνές ερωτήσεις**

**Πώς διατηρώ το αρχικό σχέδιο κάθε παρουσίασης‑προέλευσης;**

Χρησιμοποιήστε το [addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) χωρίς να παράσχετε master ή layout προορισμού. Το Aspose.Slides μπορεί αυτόματα να κλωνοποιήσει το master προέλευσης όταν το απαιτεί η εισαγόμενη διαφάνεια.

**Πώς κάνω τις εισαγόμενες διαφάνειες να χρησιμοποιούν το θέμα προορισμού;**

Χρησιμοποιήστε την υπερφόρτωση που δέχεται ένα master προορισμού. Περάστε ένα master από την προοριστική παρουσίαση, όχι από την πηγή. Το Aspose.Slides θα προσπαθήσει να αντιστοιχίσει κάθε διαφάνεια‑προέλευσης σε ένα κατάλληλο layout κάτω από αυτό το master.

**Πότε πρέπει να χρησιμοποιήσω συγκεκριμένο layout προορισμού αντί για master προορισμού;**

Χρησιμοποιήστε ένα συγκεκριμένο layout όταν κάθε εισαγόμενη διαφάνεια πρέπει να χρησιμοποιεί ένα γνωστό layout. Χρησιμοποιήστε master όταν θέλετε το Aspose.Slides να επιλέξει μεταξύ των layout του master με βάση τον τύπο ή το όνομα του layout προέλευσης.

**Μπορούν να συγχωνευτούν παρουσιάσεις με διαφορετικά μεγέθη διαφανειών;**

Ναι, αλλά το περιεχόμενο της διαφάνειας δεν επανασχεδιάζεται αυτόματα για τις διαστάσεις προορισμού. Αλλάξτε το μέγεθος της παρουσίασης‑προέλευσης πρώτα όταν χρειάζεστε προβλέψιμη τοποθέτηση, π.χ. με [SlideSize.setSize](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) και [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidesizescaletype/).

**Μπορώ να συγχωνεύσω αρχεία PPT, PPTX και ODP σε ένα αρχείο;**

Ναι. Φορτώστε κάθε παρουσίαση‑προέλευση, κλωνοποιήστε τις απαιτούμενες διαφάνειες σε έναν προορισμό, και αποθηκεύστε τον προορισμό σε υποστηριζόμενη μορφή εξόδου. Επειδή οι μορφές παρουσίασης δεν υποστηρίζουν ακριβώς το ίδιο σύνολο λειτουργιών, επαληθεύστε το σύνθετο περιεχόμενο μετά από διαμορφώσεις μεταξύ μορφών. Δείτε τη σελίδα [Supported File Formats](/slides/el/nodejs-java/supported-file-formats/).

**Διατηρούνται αυτόματα οι ενότητες προέλευσης;**

Όχι με έναν βασικό βρόχο που κλωνοποιεί μόνο διαφάνειες. Δημιουργήστε ξανά τις απαιτούμενες ενότητες στην προοριστική παρουσίαση και χρησιμοποιήστε την υπερφόρτωση ενότητας του [addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) όταν η δομή ενότητας πρέπει να διατηρηθεί.

**Διατηρούνται οι σημειώσεις ομιλητή και τα σχόλια;**

Αντιγράφονται μαζί με τη κλωνοποιημένη διαφάνεια. Για ροές εργασίας που εξαρτώνται από το στυλ του notes‑master, τους συγγραφείς σχολίων ή τα νήματα ανασκόπησης, επαληθεύστε το συγχωνευμένο αποτέλεσμα επειδή αυτά τα σενάρια αφορούν δομές επιπέδου παρουσίασης καθώς και περιεχόμενο διαφάνειας.

**Τι γίνεται με ήχο, βίντεο, αντικείμενα OLE και υπερσυνδέσμους;**

Το ενσωματωμένο περιεχόμενο μεταφέρεται ως μέρος των σχέσεων πόρων της κλωνοποιημένης διαφάνειας. Οι εξωτερικοί σύνδεσμοι παραμένουν εξωτερικοί, οπότε τα αρχεία ή οι URL προορισμού τους πρέπει να είναι διαθέσιμα μετά τη συγχώνευση.

**Εγγυάνονται οι ενσωματωμένες γραμματοσειρές από κάθε πηγή στο τελικό έγγραφο;**

Μην βασίζεστε μόνο στην κλωνοποίηση διαφανειών για την ανάπτυξη γραμματοσειρών. Ελέγξτε τις ενσωματωμένες γραμματοσειρές στον προορισμό και διαχειριστείτε ρητά την ενσωμάτωση ή τη διαθεσιμότητα εξωτερικών γραμματοσειρών όταν η τυπογραφία είναι σημαντική.

**Πώς συγχωνεύω ένα αρχείο προστατευμένο με κωδικό;**

Ανοίξτε το με το κατάλληλο [LoadOptions.setPassword](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#setPassword-String-), στη συνέχεια κλωνοποιήστε τις διαφάνειές του κανονικά. Η προστασία εξόδου ρυθμίζεται ξεχωριστά.

**Πώς πρέπει να αντιμετωπίζω πολύ μεγάλες παρουσιάσεις;**

Χρησιμοποιήστε τη διαχείριση BLOB όταν τα μεγάλα δυαδικά αρχεία κυριαρχούν στη μνήμη, προτιμήστε τη φόρτωση από διαδρομές αρχείων για πολύ μεγάλα αρχεία, απελευθερώστε τις πηγές παρουσίασης άμεσα και αποθηκεύστε το τελικό αποτέλεσμα μόνο όταν είναι απαραίτητο.

**Μπορώ να συγχωνεύσω διαφάνειες από πολλαπλά νήματα;**

Μην φορτώνετε, αποθηκεύετε ή κλωνοποιείτε αντικείμενα παρουσίασης σε πολλαπλά νήματα. Για παράλληλες εργασίες συγχώνευσης, χρησιμοποιήστε ξεχωριστές διαδικασίες μονόνημα και ανεξάρτητα αντικείμενα παρουσίασης.