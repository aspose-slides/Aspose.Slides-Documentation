---
title: Εφαρμογή ή Αλλαγή Διατάξεων Διαφάνειας σε Android
linktitle: Διάταξη Διαφάνειας
type: docs
weight: 60
url: /el/androidjava/slide-layout/
keywords:
- διάταξη διαφάνειας
- διάταξη περιεχομένου
- στοιχείο κράτησης θέσης
- σχεδίαση παρουσίασης
- σχεδίαση διαφάνειας
- αχρησιμοποίητη διάταξη
- ορατότητα υποσέλιδου
- διαφάνεια τίτλου
- τίτλος και περιεχόμενο
- επικεφαλίδα ενότητας
- δύο περιεχόμενα
- σύγκριση
- μόνο τίτλος
- κενή διάταξη
- περιεχόμενο με λεζάντα
- εικόνα με λεζάντα
- τίτλος και κάθετο κείμενο
- κάθετος τίτλος και κείμενο
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Εφαρμόζετε, δημιουργείτε και τροποποιείτε διατάξεις διαφάνειας στην Aspose.Slides για Android μέσω Java, προσθέτετε στοιχεία κράτησης θέσης, αφαιρείτε αχρησιμοποίητες διατάξεις και ελέγχετε την ορατότητα του υποσέλιδου."
---
## **Επισκόπηση**

Μια διάταξη διαφάνειας ορίζει τις θέσεις και τη μορφοποίηση των στοιχείων κράτησης θέσης, όπως τίτλοι, κείμενο, εικόνες, διαγράμματα και πίνακες. Η εφαρμογή μιας διάταξης παρέχει στις διαφάνειες μια συνεπή δομή ενώ επιτρέπει σε κάθε διαφάνεια να περιέχει το δικό της περιεχόμενο.

Οι πιο συχνές διατάξεις είναι:

- **Διαφάνεια Τίτλου**: Περιέχει στοιχεία κράτησης θέσης τίτλου και υποτίτλου.
- **Τίτλος και Περιεχόμενο**: Περιέχει ένα στοιχείο κράτησης θέσης τίτλου και ένα γενικού σκοπού στοιχείο κράτησης θέσης περιεχομένου.
- **Κενή**: Δεν περιέχει στοιχεία κράτησης θέσης περιεχομένου και είναι χρήσιμη όταν κάθε μορφή θα τοποθετηθεί χειροκίνητα.

## **Κατανόηση Κληρονομικότητας Διάταξης**

Μια παρουσίαση έχει τρία σχετιζόμενα επίπεδα:

1. A [κύρια διαφάνεια](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterslide/) καθορίζει το θέμα, τη κοινή μορφοποίηση, το παρασκήνιο και τα κοινά αντικείμενα.
2. A [διάταξη διαφάνειας](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutslide/) ανήκει σε μια κύρια διαφάνεια και ορίζει μια συγκεκριμένη διάταξη των στοιχείων κράτησης θέσης.
3. A [κανονική διαφάνεια](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islide/) χρησιμοποιεί μια διάταξη και αποθηκεύει το περιεχόμενο που εισήχθη για αυτή τη διαφάνεια.

Μια κανονική διαφάνεια κληρονομεί το θέμα και τη μορφοποίηση από τη διάταξή της, και η διάταξη κληρονομεί από την κύρια διαφάνειά της. Μια τιμή που ορίζεται απευθείας σε μια κανονική διαφάνεια παρακάμπτει την κληρονομημένη τιμή σε εκείνο το επίπεδο. Όταν δημιουργείται μια κανονική διαφάνεια, τα σχήματα των στοιχείων κράτησης θέσης παράγονται από την επιλεγμένη διάταξη, ενώ το περιεχόμενο που εισάγεται σε αυτά τα στοιχεία ανήκει στην κανονική διαφάνεια.

Προσθέστε τα απαιτούμενα στοιχεία κράτησης θέσης σε μια διάταξη πριν δημιουργήσετε διαφάνειες από αυτήν. Η προσθήκη ενός επιπλέον στοιχείου κράτησης θέσης σε μια διάταξη αργότερα δεν προσθέτει αυτόματα το αντίστοιχο σχήμα στοιχείου σε υπάρχουσες κανονικές διαφάνειες.

Αυτή η σχέση έχει δύο σημαντικές συνέπειες:

- Η αλλαγή της κληρονομημένης μορφοποίησης ή της γεωμετρίας των υφιστάμενων στοιχείων κράτησης θέσης σε μια διάταξη μπορεί να ενημερώσει κάθε διαφάνεια που εξαρτάται από αυτήν. Πριν επεξεργαστείτε μια διάταξη που χρησιμοποιείται ήδη, ελέγξτε τις εξαρτημένες διαφάνειες και ανασκοπήστε την προκύπτουσα παρουσίαση.
- Μια διάταξη που εξακολουθεί να χρησιμοποιείται από κάποια διαφάνεια δεν μπορεί να αφαιρεθεί. Αναθέστε πρώτα τις εξαρτημένες διαφάνειες της σε άλλη διάταξη ή αφαιρέστε μόνο τις αχρησιμοποίητες διατάξεις.

Για περισσότερες πληροφορίες σχετικά με το ανώτερο επίπεδο αυτής της ιεραρχίας, δείτε [Κύρια Διαφάνεια](/slides/el/androidjava/slide-master/).

## **Επιλογή και Εφαρμογή Διάταξης Διαφάνειας**

Χρησιμοποιήστε έναν τύπο διάταξης όταν η παρουσίαση ακολουθεί τις τυπικές ορισμούς διάταξης του PowerPoint. Τα ονόματα διατάξεων είναι επεξεργάσιμα από το χρήστη και μπορούν να εντοπιστούν, επομένως η επιλογή με βάση το όνομα είναι λιγότερο αξιόπιστη εκτός αν ελέγχετε το πηγαίο πρότυπο.

Το παρακάτω παράδειγμα αναζητά **Title and Content** στην πρώτη κύρια διαφάνεια. Αν αυτή η διάταξη δεν είναι διαθέσιμη, επιστρέφει σκόπιμα στην **Blank**. Ο δεύτερος έλεγχος null είναι απαραίτητος επειδή μια παρουσίαση μπορεί να περιέχει μόνο προσαρμοσμένες διατάξεις. Η επιλεγμένη διάταξη εφαρμόζεται στη πρώτη κανονική διαφάνεια μέσω της μεθόδου [ISlide.setLayoutSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) .

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide targetLayout = layoutSlides.getByType(SlideLayoutType.TitleAndObject);

    if (targetLayout == null) {
        targetLayout = layoutSlides.getByType(SlideLayoutType.Blank);
    }

    if (targetLayout == null) {
        throw new IllegalStateException("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η αλλαγή της διάταξης μιας διαφάνειας δεν αφαιρεί τα κανονικά σχήματα που έχουν προστεθεί απευθείας στη διαφάνεια. Ωστόσο, οι θέσεις των στοιχείων κράτησης θέσης, η κληρονομημένη μορφοποίηση και η αντιστοίχηση μεταξύ των υπαρχόντων στοιχείων και της νέας διάταξης μπορεί να αλλάξει, γι’ αυτό ελέγξτε το αποτέλεσμα όταν εναλλάσσετε μεταξύ σημαντικά διαφορετικών διατάξεων.

## **Προσθήκη Διάταξης Διαφάνειας**

Η επιλογή και η δημιουργία είναι ξεχωριστές λειτουργίες. Το προηγούμενο παράδειγμα επιλέγει μια υπάρχουσα διάταξη· δεν δημιουργεί κάποια. Για να δημιουργήσετε μια διάταξη, καλέστε τη μέθοδο [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) στη συλλογή διατάξεων της στοχευόμενης κύριας διαφάνειας.

Το παρακάτω παράδειγμα προσθέτει πάντα μια νέα διάταξη **Title and Content** με όνομα `Report Title and Content`, στη συνέχεια προσθέτει μια κανονική διαφάνεια που βασίζεται σε αυτήν. Τα ονόματα διατάξεων πρέπει να είναι μοναδικά μέσα στη συλλογή.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide reportLayout = masterSlide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Προσθέστε μια διάταξη μόνο όταν το πρότυπο χρειάζεται πραγματικά μια άλλη επαναχρησιμοποιήσιμη δομή. Εάν υπάρχει ήδη μια κατάλληλη διάταξη, επιλέξτε την και επαναχρησιμοποιήστε την αντί να δημιουργήσετε αντιγραφή.

## **Προσθήκη Συμπληρωματικών Στοιχείων σε Διάταξη Διαφάνειας**

Η μέθοδος [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) παρέχει ένα [ILayoutPlaceholderManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) για την προσθήκη σχήματος στοιχείων κράτησης θέσης σε μία διάταξη.

| Στοιχείο κράτησης θέσης PowerPoint | Μέθοδος ILayoutPlaceholderManager |
| ----------------------------------- | ---------------------------------- |
| ![Περιεχόμενο](content.png)             | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Περιεχόμενο (Κατακόρυφο)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Κείμενο](text.png)                   | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Κείμενο (Κατακόρυφο)](textV.png)       | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Εικόνα](picture.png)             | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Διάγραμμα](chart.png)                 | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Πίνακας](table.png)                 | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Πολυμέσα](media.png)                 | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Διαδικτυακή Εικόνα](onlineImage.png)    | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Το παρακάτω παράδειγμα ελέγχει αν η διάταξη **Blank** υπάρχει, προσθέτει τέσσερα στοιχεία κράτησης θέσης σε αυτήν και, στη συνέχεια, δημιουργεί μια κανονική διαφάνεια που χρησιμοποιεί την τροποποιημένη διάταξη. Η σειρά είναι σκόπιμη: τα στοιχεία προστίθενται πριν δημιουργηθεί η κανονική διαφάνεια, ώστε η Aspose.Slides να μπορεί να δημιουργήσει τα αντίστοιχα σχήματα στοιχείων στην εν λόγω διαφάνεια.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayout == null) {
        throw new IllegalStateException("The presentation does not contain a Blank layout slide.");
    }

    ILayoutPlaceholderManager placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Τα στοιχεία κράτησης θέσης στη διάταξη διαφάνειας](add_placeholders.png)

{{% alert color="warning" title="Προειδοποίηση" %}}
Η αλλαγή της κληρονομημένης μορφοποίησης ή της γεωμετρίας των υφιστάμενων στοιχείων κράτησης θέσης μιας διάταξης μπορεί να επηρεάσει τις εξαρτημένες διαφάνειες. Ένα νέο στοιχείο κράτησης θέσης δεν προστίθεται αυτόματα σε υπάρχουσες κανονικές διαφάνειες. Δοκιμάστε τις αλλαγές διάταξης σε αντίγραφο της παρουσίασης και ελέγξτε κάθε εξαρτημένη διαφάνεια.
{{% /alert %}}

## **Αφαίρεση Αχρησιμοποίητων Διάταξεων Διαφάνειας**

Χρησιμοποιήστε τη μέθοδο [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) για να αφαιρέσετε διατάξεις που δεν αναφέρονται από καμία κανονική διαφάνεια. Η μέθοδος αφήνει άθικτες τις διατάξεις που εξακολουθούν να χρησιμοποιούνται.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για να αφαιρέσετε μια συγκεκριμένη διάταξη, χρησιμοποιήστε πρώτα την μέθοδο [hasDependingSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) ή [getDependingSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) της. Αναθέστε τυχόν εξαρτημένες διαφάνειες πριν καλέσετε την [ILayoutSlide.remove](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutslide/#remove--). Η προσπάθεια αφαίρεσης μιας διάταξης που χρησιμοποιείται προκαλεί την εξαίρεση [PptxEditException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pptxeditexception/).

## **Έλεγχος Ορατότητας Υποσέλιδου σε Διάταξη Διαφάνειας**

Μια διάταξη διαθέτει τα δικά της στοιχεία κράτησης θέσης υποσέλιδου, αριθμού διαφάνειας και ημερομηνίας-ώρας. Χρησιμοποιήστε τη μέθοδο [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) για να ελέγξετε αυτά τα στοιχεία σε μία διάταξη. Αυτό είναι χρήσιμο όταν, για παράδειγμα, οι διατάξεις περιεχομένου πρέπει να εμφανίζουν υποσέλιδα ενώ οι διατάξεις τίτλου όχι.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);

    if (layoutSlide == null) {
        layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    }

    if (layoutSlide == null) {
        throw new IllegalStateException("The presentation does not contain a suitable layout slide.");
    }

    ILayoutSlideHeaderFooterManager headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Έλεγχος Ορατότητας Υποσέλιδου σε Μάστερ και τις Παιδικές Του Διάταξεις**

Για να εφαρμόσετε συνεπή ρυθμίσεις υποσέλιδου σε όλη τη ιεραρχία μιας κύριας διαφάνειας, χρησιμοποιήστε τη μέθοδο [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--) . Οι μέθοδοι διάδοσης του [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) λειτουργούν στην κύρια διαφάνεια, στις εξαρτημένες διατάξεις της και στις κανονικές διαφάνειες· δεν στοχεύουν μόνο μία κανονική διαφάνεια.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ μιας κύριας διαφάνειας και μιας διάταξης διαφάνειας;**

Η κύρια διαφάνεια ορίζει το θέμα και τη συνοδική μορφοποίηση της παρουσίασης. Μια διάταξη διαφάνειας ανήκει σε μια κύρια διαφάνεια και καθορίζει μια επαναχρησιμοποιήσιμη διάταξη στοιχείων κράτησης θέσης. Οι κανονικές διαφάνειες χρησιμοποιούν αυτές τις διατάξεις και αποθηκεύουν το συγκεκριμένο περιεχόμενο της διαφάνειας.

**Μπορώ να αντιγράψω μια διάταξη διαφάνειας από μια παρουσίαση σε άλλη;**

Ναι. Προσθέστε ένα αντίγραφο στη συλλογή προορισμού με τη μέθοδο [addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) . Όταν αντιγράφετε μεταξύ παρουσιάσεων, ελέγξτε επίσης τις γραμματοσειρές, τα θέματα, τις εικόνες και άλλους πόρους που χρησιμοποιούνται από τη διάταξη προέλευσης.

**Τι συμβαίνει όταν τροποποιώ μια διάταξη που χρησιμοποιείται ήδη;**

Οι εξαρτημένες διαφάνειες κληρονομούν τις αλλαγές της διάταξης, εκτός αν έχουν παρακάμψει τη σχετική μορφοποίηση ή τα αντικείμενα τοπικά. Η γεωμετρία των στοιχείων κράτησης θέσης και η κληρονομημένη μορφοποίηση μπορούν έτσι να αλλάξουν σε πολλές διαφάνειες ταυτόχρονα. Χρησιμοποιήστε τη [getDependingSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) για να εντοπίσετε τις επηρεαζόμενες διαφάνειες πριν επεξεργαστείτε τη διάταξη.

**Τι συμβαίνει αν αφαιρέσω μια διάταξη που εξακολουθεί να χρησιμοποιείται;**

Η Aspose.Slides εγείρει μια [PptxEditException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pptxeditexception/). Αναθέστε πρώτα τις εξαρτημένες διαφάνειες ή χρησιμοποιήστε τη [removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) για να αφαιρέσετε μόνο τις αχρησιμοποίητες διατάξεις.