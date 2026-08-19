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
- συνδυασμός PowerPoint
- συνδυασμός παρουσιάσεων
- συνδυασμός διαφανειών
- συνδυασμός PPT
- συνδυασμός PPTX
- συνδυασμός ODP
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να συγχωνεύετε παρουσιάσεις PowerPoint και OpenDocument σε JavaScript κλωνοποιώντας διαφάνειες, ελέγχοντας masters και layouts, αλλάζοντας το μέγεθος του περιεχομένου των διαφανειών, διατηρώντας ενότητες και διαχειριζόμενοι προστατευμένα ή μεγάλα αρχεία."
---
## **Επισκόπηση**

Το Aspose.Slides for Node.js μέσω Java συγχωνεύει παρουσιάσεις κλωνοποιώντας διαφάνειες από μία [Παρουσίαση](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) σε άλλη. Η κύρια λειτουργία είναι [SlideCollection.addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-), η οποία μπορεί να διατηρήσει τη μορφοποίηση της πηγαίας διαφάνειας ή να επισυνάψει την κλωνοποιημένη διαφάνεια σε ένα master ή layout στην προοριστική παρουσίαση.

Αυτό το άρθρο καλύπτει τις πιο κοινές ροές εργασίας συγχώνευσης:

- συγχώνευση όλων των διαφανειών διατηρώντας τη μορφοποίηση της πηγής·
- συγχώνευση επιλεγμένων διαφανειών·
- εφαρμογή master από την προοριστική παρουσίαση·
- εφαρμογή συγκεκριμένου layout από την προοριστική παρουσίαση·
- ομαλοποίηση διαφορετικών μεγεθών διαφανειών πριν τη συγχώνευση·
- προσθήκη κλωνοποιημένων διαφανειών σε ενότητα·
- συγχώνευση πολλαπλών παρουσιάσεων σε μια ολοκληρωμένη ροή εργασίας·
- διαχείριση masters, πόρων, σημειώσεων, σχολίων, μέσων, γραμματοσειρών, κωδικών πρόσβασης, μεγάλων αρχείων και θεμάτων πολυνηματικότητας.

## **Πώς η Κλωνοποίηση Διαφανειών Επηρεάζει τα Masters και τα Layouts**

Μια διαφάνεια κληρονομεί μεγάλο μέρος της εμφάνισής της από το layout και το master της. Για αυτόν το λόγο, η υπερφόρτωση κλωνοποίησης που επιλέγετε καθορίζει πώς η συγχωνευμένη διαφάνεια ενσωματώνεται στην προοριστική παρουσίαση.

Χρησιμοποιήστε [SlideCollection.addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidecollection/) με έναν από τους ακόλουθους τρόπους:

- `addClone(sourceSlide)` — διατηρεί το layout και τη μορφοποίηση της πηγαίας διαφάνειας. Όταν απαιτείται, το πηγαίο master μπορεί να κλωνοποιηθεί αυτόματα στην προοριστική παρουσίαση. Το Aspose.Slides παρακολουθεί αυτόματα κλωνοποιημένα masters ώστε οι επαναλαμβανόμενες διαφάνειες που χρησιμοποιούν το ίδιο πηγαίο master να μην προκαλούν πολλαπλή κλωνοποίηση του master.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — επισυνάπτει την κλωνοποιημένη διαφάνεια σε ένα συγκεκριμένο προοριστικό [MasterSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterslide/). Το Aspose.Slides αναζητά ένα αντίστοιχο layout κάτω από το master αυτό με βάση τον τύπο ή το όνομα του layout.
- `addClone(sourceSlide, destinationLayout)` — επισυνάπτει την κλωνοποιημένη διαφάνεια απευθείας σε ένα συγκεκριμένο προοριστικό [LayoutSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslide/).

Το master ή το layout που περνιέται σε μια υπερφόρτωση `addClone` πρέπει να ανήκει στην **προοριστική** παρουσίαση, όχι στην πηγαία παρουσίαση.

## **Συγχώνευση Ολόκληρων Παρουσιάσεων και Διατήρηση Μορφοποίησης Πηγής**

Η πιο απλή συγχώνευση αντιγράφει κάθε διαφάνεια από την πηγαία παρουσίαση στην προοριστική παρουσίαση. Πρόκειται για την κατάλληλη επιλογή όταν οι εισαχθείσες διαφάνειες πρέπει να διατηρήσουν το αρχικό θέμα, το master και τις σχέσεις layout.

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

Η τελική παρουσίαση μπορεί να περιέχει πολλαπλά masters όταν η πηγή και ο προορισμός χρησιμοποιούν διαφορετικά σχέδια. Αυτό είναι αναμενόμενο όταν η μορφοποίηση της πηγής διατηρείται επί bewusst.

## **Συγχώνευση Επιλεγμένων Διαφανειών**

Δεν χρειάζεται να κλωνοποιήσετε κάθε διαφάνεια. Στο παρακάτω παράδειγμα εισάγονται μόνο επιλεγμένα ευρετήρια διαφανειών από την πηγαία παρουσίαση.

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

Επικυρώστε τα ευρετήρια διαφανειών πριν την κλωνοποίηση όταν προέρχονται από είσοδο χρήστη ή εξωτερική διαμόρφωση.

## **Συγχώνευση Διαφανειών Χρησιμοποιώντας Προοριστικό Master**

Χρησιμοποιήστε την υπερφόρτωση [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) όταν οι εισαχθείσες διαφάνειες πρέπει να ακολουθήσουν ένα master που ήδη ανήκει στην προοριστική παρουσίαση.

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

Το Aspose.Slides επιλέγει ένα κατάλληλο layout κάτω από το καθορισμένο master ταιριάζοντας με τον τύπο ή το όνομα του πηγαίου layout. Εάν δεν υπάρχει κατάλληλο layout και το `allowCloneMissingLayout` είναι `true`, το πηγαίο layout κλωνοποιείται ώστε να προστεθεί η διαφάνεια. Εάν είναι `false`, ρίχνεται μια [PptxEditException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pptxeditexception/).

Χρησιμοποιήστε `false` όταν θέλετε η συγχώνευση να αποτύχει αντί να εισάγει ένα επιπλέον layout στο προοριστικό master.

## **Συγχώνευση Διαφανειών Χρησιμοποιώντας Συγκεκριμένο Προοριστικό Layout**

Χρησιμοποιήστε την υπερφόρτωση [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) όταν γνωρίζετε ακριβώς ποιο προοριστικό layout πρέπει να χρησιμοποιούν οι εισαχθείσες διαφάνειες.

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

Η εφαρμογή ενός προοριστικού layout αλλάζει τη σχέση κληρονομίας layout· δεν αλλάζει το περιεχόμενο της πηγαίας διαφάνειας. Εάν τα layouts της πηγής και του προορισμού έχουν διαφορετικές δομές placeholder, εξετάστε το αποτέλεσμα για να επιβεβαιώσετε ότι η κληρονομημένη μορφοποίηση και η συμπεριφορά placeholder είναι κατάλληλες.

## **Συγχώνευση Παρουσιάσεων με Διαφορετικά Μεγέθη Διαφανειών**

Παρουσιάσεις με διαφορετικές διαστάσεις διαφανειών μπορούν να συγχωνευτούν, αλλά η κλωνοποίηση μιας διαφάνειας σε παρουσίαση με άλλο μέγεθος δεν επανασχεδιάζει αυτόματα το περιεχόμενό της για το νέο καμβά. Τα σχήματα μπορεί να εμφανιστούν μετατοπισμένα, κλιμακωμένα απροσδόκητα ή εκτός του ορατού τμήματος της διαφάνειας.

Μια πρακτική προσέγγιση είναι η αλλαγή μεγέθους της πηγαίας παρουσίασης πριν την κλωνοποίηση. Η μέθοδος [SlideSize.setSize](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) μπορεί να κλιμακώσει το υπάρχον περιεχόμενο ενώ αλλάζει τις διαστάσεις της διαφάνειας. Το [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidesizescaletype/) κλιμακώνει το περιεχόμενο ώστε να ταιριάζει στο ζητούμενο μέγεθος.

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

Η αλλαγή μεγέθους τροποποιεί το αντικείμενο της πηγαίας παρουσίασης στη μνήμη. Εάν χρειάζεστε την αρχική πηγαία παρουσίαση αμετάβλητη για άλλες λειτουργίες, ανοίξτε ένα ξεχωριστό αντίτυπο για τη συγχώνευση.

## **Συγχώνευση Διαφανειών σε Ενότητα Παρουσίασης**

Ο βασικός βρόχος κλωνοποίησης διαφανειών δεν αναδημιουργεί την ιεραρχία ενοτήτων της πηγαίας παρουσίασης. Εάν οι ενότητες είναι σημαντικές στο αποτέλεσμα, δημιουργήστε ή επιλέξτε ενότητες στην προοριστική παρουσίαση και κλωνοποιήστε τις διαφάνειες σε αυτές ρητά με [addClone(Slide, Section)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-).

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

Οι κλωνοποιημένες διαφάνειες προσαρτώνται στην ορισμένη προοριστική ενότητα. Για να διατηρηθούν πολλαπλές πηγαίες ενότητες, αναδημιουργήστε αυτές τις ενότητες στον προορισμό και χαρτογραφήστε κάθε πηγαία διαφάνεια στην αντίστοιχη προοριστική ενότητα.

## **Ασφαλής Συγχώνευση Πολλαπλών Παρουσιάσεων**

Το παρακάτω παράδειγμα πλήρους ροής χρησιμοποιεί την πρώτη παρουσίαση ως προορισμό, ομαλοποιεί το μέγεθος διαφάνειας κάθε επιπλέον πηγής, διατηρεί κάθε πηγή ανοιχτή μόνο κατά τη διάρκεια της αντιγραφής και αποθηκεύει το τελικό αρχείο μία φορά.

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

Αυτό αποτελεί ένα χρήσιμο υπόδειγμα για τη διατήρηση της μορφοποίησης της πηγής των εισαχθέντων διαφανειών. Εάν το αποτέλεσμα πρέπει να χρησιμοποιεί ένα ενιαίο θέμα προορισμού, αντικαταστήστε την απλή κλήση `addClone(sourceSlide)` με την κατάλληλη υπερφόρτωση master ή layout του προορισμού όπως παρουσιάστηκε προηγουμένως.

## **Πρακτικές Σκέψεις**

### **Masters, Layouts, and Formatting Fidelity**

Η προεπιλεγμένη κλωνοποίηση διαφάνειας μπορεί αυτόματα να φέρει το απαιτούμενο πηγαίο master στην προοριστική παρουσίαση. Το Aspose.Slides διατηρεί ένα εσωτερικό μητρώο για αυτόματα κλωνοποιημένα masters ώστε να αποφεύγεται η πολλαπλή κλωνοποίηση του ίδιου master. Τα χειροκίνητα κλωνοποιημένα masters δεν παρακολουθούνται από αυτό το μητρώο, γι’ αυτό αποφύγετε την προ-κλωνοποίηση masters εκτός εάν χρειάζεστε έλεγχο της δομής του master.

Μην υποθέτετε ότι δύο masters ή layouts με το ίδιο όνομα είναι οπτικά ισοδύναμα. Εάν ένα εταιρικό πρότυπο πρέπει να ελέγχει την τελική εμφάνιση, επιλέξτε ρητά ένα προοριστικό master ή layout και επαληθεύστε το αποτέλεσμα μετά τη συγχώνευση.

### **Notes and Comments**

Οι σημειώσεις ομιλητή και τα σχόλια διαφάνειας συνδέονται με το περιεχόμενο της διαφάνειας και αντιγράφονται όταν κλωνοποιείται η διαφάνεια. Το Aspose.Slides παρέχει επίσης ειδικά APIs για [presentation notes](https://docs.aspose.com/slides/el/nodejs-java/presentation-notes/) και [presentation comments](https://docs.aspose.com/slides/el/nodejs-java/presentation-comments/).

Εάν η μορφοποίηση της σελίδας σημειώσεων είναι σημαντική, επαληθεύστε τη συγχωνευμένη παρουσίαση επειδή τα notes masters είναι αντικείμενα επιπέδου παρουσίασης και μπορεί να διαφέρουν μεταξύ πηγαίων αρχείων. Σε ροές ελέγχου, ελέγξτε επίσης τους συγγραφείς σχολίων και τα νήματα σχολίων μετά τον συνδυασμό αρχείων από διαφορετικούς συγγραφείς ή πρότυπα.

### **Images, Audio, Video, OLE Objects, and External Links**

Οι διαφάνειες μπορούν να αναφέρονται σε πόρους επιπέδου παρουσίασης όπως εικόνες, ενσωματωμένο ήχο, ενσωματωμένο βίντεο και δεδομένα OLE. Κλωνοποιήστε τη διαφάνεια ίδιαν αντί να αντιγράψετε μόνο τα ορατά σχήματα ώστε το Aspose.Slides να διατηρήσει τις σχέσεις της διαφάνειας με τους πόρους της.

Οι ενσωματωμένοι και συνδεδεμένοι πόροι πρέπει να αντιμετωπίζονται διαφορετικά. Ένας συνδεδεμένος ήχος, βίντεο, αντικείμενο OLE ή υπερσύνδεσμος παραμένει εξαρτημένος από τον εξωτερικό του στόχο· η κλωνοποίηση μιας διαφάνειας δεν μετατρέπει έναν εξωτερικό σύνδεσμο σε ενσωματωμένο περιεχόμενο. Δοκιμάστε τις διαδρομές και τις URL των συνδεδεμένων πόρων στο περιβάλλον όπου θα ανοιχτεί η συγχωνευμένη παρουσίαση.

Το Aspose.Slides παρακολουθεί αυτόματα κλωνοποιημένα masters, αλλά αυτό δεν σημαίνει ότι οι πανομοιότυποι δυαδικοί πόροι από μη σχετιζόμενες πηγαίες παρουσιάσεις θα αφαιρεθούν πάντα. Εάν το μέγεθος του αρχείου εξόδου είναι κρίσιμο, ελέγξτε το συγχωνευμένο πακέτο και μετρήστε το αποτέλεσμα αντί να βασίζεστε σε έμμεση αφαίρεση διπλότυπων.

### **Embedded Fonts and Font Availability**

Οι γραμματοσειρές διαχειρίζονται σε επίπεδο παρουσίασης. Εάν η τυπογραφία πρέπει να παραμείνει συνεπής μεταξύ μηχανών, μην υποθέτετε ότι η κλωνοποίηση διαφανειών εγγυάται ότι κάθε απαιτούμενη γραμματοσειρά είναι διαθέσιμη στο περιβάλλον προορισμού. Μπορείτε να ελέγξετε τις ενσωματωμένες γραμματοσειρές με [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) και να διαχειριστείτε την ενσωμάτωση όπως περιγράφεται στο [Embed Fonts in Presentations](https://docs.aspose.com/slides/el/nodejs-java/embedded-font/).

Επιπλέον, βεβαιωθείτε ότι έχετε άδεια για την ενσωμάτωση των γραμματοσειρών που χρησιμοποιούν τα πηγαία αρχεία. Οι άδειες των γραμματοσειρών μπορεί να περιορίζουν την ενσωμάτωση.

### **Password‑Protected Presentations**

Μια πηγαία παρουσίαση με κωδικό πρόσβασης πρέπει να ανοιχθεί επιτυχώς πριν κλωνοποιηθούν οι διαφάνειές της. Παρέχετε τον κωδικό μέσω του [LoadOptions.setPassword](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#setPassword-String-).

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

Το άνοιγμα κρυπτογραφημένης πηγής δεν εφαρμόζει αυτόματα την ίδια προστασία στην προοριστική παρουσίαση. Διαμορφώστε την προστασία εξόδου ξεχωριστά όταν απαιτείται.

### **Large Presentations and Memory Use**

Μεγάλες παρουσιάσεις που περιέχουν εικόνες υψηλής ανάλυσης, ήχο, βίντεο ή άλλα μεγάλα δυαδικά αντικείμενα μπορούν να καταναλώσουν σημαντική μνήμη. Το [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) παρέχει ελέγχους για τη διαχείριση BLOB και τη χρήση προσωρινών αρχείων. Δείτε τη σελίδα [Manage Presentation BLOBs](https://docs.aspose.com/slides/el/nodejs-java/manage-blob/) για στρατηγικές μεγάλων αρχείων.

Για μεγάλα αρχεία, προτιμήστε τη φόρτωση από διαδρομές αρχείων όταν είναι δυνατόν, εκκαθάριση κάθε πηγής αμέσως μετά τη συγχώνευση και αποφύγετε την επανειλημμένη αποθήκευση ενδιάμεσων αποτελεσμάτων εκτός εάν η ροή εργασίας απαιτεί σημεία ελέγχου.

### **Thread Safety**

Μην φορτώνετε, αποθηκεύετε ή κλωνοποιείτε μια [Παρουσίαση](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) σε πολλαπλά νήματα. Αυτές οι λειτουργίες δεν υποστηρίζονται για πολυνηματική χρήση. Εάν χρειάζεστε παράλληλη εκτέλεση ανεξάρτητων εργασιών συγχώνευσης, χρησιμοποιήστε αρκετές μονονήματες διεργασίες, η καθεμία με τις δικές της παρουσίες παρουσίασης, και ακολουθήστε τις οδηγίες [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/el/nodejs-java/multithreading/).

## **FAQ**

**Πώς διατηρώ το αρχικό σχέδιο κάθε πηγαίας παρουσίασης;**

Χρησιμοποιήστε [`addClone(sourceSlide)`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) χωρίς να παρέχετε προοριστικό master ή layout. Το Aspose.Slides μπορεί αυτόματα να κλωνοποιήσει το πηγαίο master όταν απαιτείται από την εισαχθείσα διαφάνεια.

**Πώς κάνω τις εισαχθείσες διαφάνειες να χρησιμοποιούν το θέμα του προορισμού;**

Χρησιμοποιήστε την υπερφόρτωση που δέχεται προοριστικό master. Παρέχετε ένα master από την προοριστική παρουσίαση, όχι από την πηγή. Το Aspose.Slides θα προσπαθήσει να αντιστοιχίσει κάθε πηγαία διαφάνεια σε ένα κατάλληλο layout κάτω από αυτό το master.

**Πότε πρέπει να χρησιμοποιήσω συγκεκριμένο προοριστικό layout αντί για προοριστικό master;**

Χρησιμοποιήστε συγκεκριμένο layout όταν κάθε εισαχθείσα διαφάνεια πρέπει να χρησιμοποιεί ένα γνωστό layout. Χρησιμοποιήστε master όταν θέλετε το Aspose.Slides να επιλέξει μεταξύ των layouts του master βάσει του τύπου ή του ονόματος του πηγαίου layout.

**Μπορούν να συγχωνευτούν παρουσιάσεις με διαφορετικά μεγέθη διαφανειών;**

Ναι, αλλά το περιεχόμενο της διαφάνειας δεν επανασχεδιάζεται αυτόματα για τις διαστάσεις του προορισμού. Αλλάξτε το μέγεθος της πηγαίας παρουσίασης πρώτα όταν χρειάζεται προβλεπόμενη τοποθέτηση, π.χ. με [SlideSize.setSize](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) και [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidesizescaletype/).

**Μπορώ να συγχωνεύσω αρχεία PPT, PPTX και ODP σε ένα αρχείο;**

Ναι. Φορτώστε κάθε πηγαία παρουσίαση, κλωνοποιήστε τις απαιτούμενες διαφάνειες σε έναν προορισμό και αποθηκεύστε τον προορισμό σε μια υποστηριζόμενη μορφή εξόδου. Επειδή οι μορφές παρουσίασης δεν υποστηρίζουν ακριβώς το ίδιο σύνολο λειτουργιών, ελέγξτε το σύνθετο περιεχόμενο μετά από διαμορφώσεις μεταξύ μορφών. Δείτε τη σελίδα [Supported File Formats](https://docs.aspose.com/slides/el/nodejs-java/supported-file-formats/).

**Διατηρούνται αυτόματα οι ενότητες της πηγής;**

Δεν διατηρούνται από έναν βασικό βρόχο που κλωνοποιεί μόνο διαφάνειες. Αναδημιουργήστε τις απαιτούμενες ενότητες στον προορισμό και χρησιμοποιήστε την υπερφόρτωση ενότητας του [addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) όταν η δομή ενοτήτων πρέπει να διατηρηθεί.

**Διατηρούνται οι σημειώσεις ομιλητή και τα σχόλια;**

Αντιγράφονται με την κλωνοποιημένη διαφάνεια. Για ροές που εξαρτώνται από τη μορφοποίηση του notes‑master, τους συγγραφείς σχολίων ή τα νήματα ανασκόπησης, επαληθεύστε το συγχωνευμένο αποτέλεσμα επειδή αυτά τα σενάρια περιλαμβάνουν δομές επιπέδου παρουσίασης καθώς και περιεχόμενο διαφάνειας.

**Τι συμβαίνει με ήχο, βίντεο, αντικείμενα OLE και υπερσυνδέσμους;**

Το ενσωματωμένο περιεχόμενο μεταφέρεται ως μέρος των σχέσεων πόρων της κλωνοποιημένης διαφάνειας. Οι εξωτερικοί σύνδεσμοι παραμένουν εξωτερικοί, οπότε τα αρχεία‑στόχοι ή οι URL τους πρέπει να είναι διαθέσιμοι μετά τη συγχώνευση.

**Εγγυώνται οι ενσωματωμένες γραμματοσειρές από κάθε πηγή να είναι διαθέσιμες στην τελική παρουσίαση;**

Μην βασίζεστε μόνο στην κλωνοποίηση διαφανειών για την ανάπτυξη γραμματοσειρών. Ελέγξτε τις ενσωματωμένες γραμματοσειρές του προορισμού και διαχειριστείτε ρητά την ενσωμάτωση ή τη διαθεσιμότητα εξωτερικών γραμματοσειρών όταν η τυπογραφία είναι σημαντική.

**Πώς συγχωνεύω ένα αρχείο με προστασία κωδικού;**

Ανοίξτε το με το σωστό [LoadOptions.setPassword](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#setPassword-String-), στη συνέχεια κλωνοποιήστε τις διαφάνειές του κανονικά. Η προστασία εξόδου ρυθμίζεται ξεχωριστά.

**Πώς πρέπει να χειριστώ πολύ μεγάλες παρουσιάσεις;**

Χρησιμοποιήστε τη διαχείριση BLOB όταν μεγάλα δυαδικά αντικείμενα κυριαρχούν στη χρήση μνήμης, προτιμήστε τη φόρτωση από διαδρομές αρχείων για πολύ μεγάλα αρχεία, εκκαθαρίστε τις πηγές παρουσίασης άμεσα και αποθηκεύστε το τελικό αποτέλεσμα μόνο όταν είναι απαραίτητο.

**Μπορώ να συγχωνεύσω διαφάνειες από πολλαπλά νήματα;**

Μην φορτώνετε, αποθηκεύετε ή κλωνοποιείτε παρουσίες παρουσίασης σε πολλαπλά νήματα. Για παράλληλες εργασίες συγχώνευσης, χρησιμοποιήστε ξεχωριστές μονονήματες διεργασίες και ανεξάρτητες παρουσίες παρουσίασης.