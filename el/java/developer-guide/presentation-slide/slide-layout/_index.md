---
title: Εφαρμογή ή Αλλαγή Διατάξεων Διαφάνειας σε Java
linktitle: Διάταξη Διαφάνειας
type: docs
weight: 60
url: /el/java/slide-layout/
keywords:
- διάταξη διαφάνειας
- διάταξη περιεχομένου
- δεσμευτική θέση
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
- τίτλος και κατακόρυφο κείμενο
- κατακόρυφος τίτλος και κείμενο
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Εφαρμόστε, δημιουργήστε και τροποποιήστε διατάξεις διαφάνειας στο Aspose.Slides για Java, προσθέστε δεσμευτικές θέσεις, αφαιρέστε αχρησιμοποίητες διατάξεις και ελέγξτε την ορατότητα του υποσέλιδου."
---
## **Επισκόπηση**

Η μορφοποίηση μιας διαφάνειας ορίζει τις θέσεις και τη μορφοποίηση των δεσμευτικών θέσεων όπως τίτλους, κείμενο, εικόνες, διαγράμματα και πίνακες. Η εφαρμογή μιας μορφοποίησης παρέχει στις διαφάνειες μια συνεπή δομή, ενώ επιτρέπει σε κάθε διαφάνεια να περιέχει το δικό της περιεχόμενο.

Οι πιο συχνές μορφοποιήσεις περιλαμβάνουν:

- **Διαφάνεια Τίτλου**: Περιέχει δεσμευτικές θέσεις τίτλου και υποτίτλου.
- **Τίτλος και Περιεχόμενο**: Περιέχει μια δεσμευτική θέση τίτλου και μια γενικής χρήσης δεσμευτική θέση περιεχομένου.
- **Κενή**: Δεν περιέχει δεσμευτικές θέσεις περιεχομένου και είναι χρήσιμη όταν κάθε σχήμα θα τοποθετηθεί χειροκίνητα.

## **Κατανόηση της Κληρονομικότητας της Μορφοποίησης**

Μία παρουσίαση έχει τρία σχετιζόμενα επίπεδα:

1. Μια [master slide](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterslide/) ορίζει το θέμα, τη κοινή μορφοποίηση, τα παρασκήνια και τα κοινά αντικείμενα.
1. Μια [layout slide](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutslide/) ανήκει σε μια master και ορίζει μια συγκεκριμένη διάταξη των δεσμευτικών θέσεων.
1. Μια [normal slide](https://reference.aspose.com/slides/el/java/com.aspose.slides/islide/) χρησιμοποιεί μία διάταξη και αποθηκεύει το περιεχόμενο που εισήχθη για εκείνη τη διαφάνεια.

Μια κανονική διαφάνεια κληρονομεί το θέμα και τη μορφοποίηση από τη διάταξη της, και η διάταξη κληρονομεί από τη master της. Μια τιμή που ορίζεται άμεσα στην κανονική διαφάνεια παρακάμπτει την κληρονομημένη τιμή σε αυτό το επίπεδο. Όταν δημιουργείται μια κανονική διαφάνεια, τα σχήματα των δεσμευτικών θέσεων δημιουργούνται από τη επιλεγμένη διάταξη, ενώ το περιεχόμενο που εισάγεται σε αυτές τις δεσμευτικές θέσεις ανήκει στην κανονική διαφάνεια.

Προσθέστε τις απαιτούμενες δεσμευτικές θέσεις σε μια διάταξη πριν δημιουργήσετε διαφάνειες από αυτήν. Η προσθήκη μιας ακόμη δεσμευτικής θέσης σε μια διάταξη αργότερα δεν προσθέτει αυτόματα το αντίστοιχο σχήμα δεσμευτικής θέσης στις υπάρχουσες κανονικές διαφάνειες.

Αυτή η σχέση έχει δύο σημαντικές συνέπειες:

- Η αλλαγή της κληρονομημένης μορφοποίησης ή της υπάρχουσας γεωμετρίας δεσμευτικής θέσης σε μια διάταξη μπορεί να ενημερώσει κάθε διαφάνεια που εξαρτάται από αυτήν. Πριν επεξεργαστείτε μια διάταξη που ήδη χρησιμοποιείται, ελέγξτε τις εξαρτημένες διαφάνειες της και επανεξετάστε την προκύπτουσα παρουσίαση.
- Μια διάταξη που εξακολουθεί να χρησιμοποιείται από μια διαφάνεια δεν μπορεί να αφαιρεθεί. Αναπροσαρμόστε πρώτα τις εξαρτημένες διαφάνειές της σε άλλη διάταξη ή αφαιρέστε μόνο τις αχρησιμοποίητες διατάξεις.

Για περισσότερες πληροφορίες σχετικά με το ανώτερο επίπεδο αυτής της ιεραρχίας, δείτε το [Slide Master](/slides/el/java/slide-master/).

## **Επιλογή και Εφαρμογή Διατάξεων Διαφάνειας**

Χρησιμοποιήστε έναν τύπο διάταξης όταν η παρουσίαση ακολουθεί τις τυπικές ορισμούς διατάξεων του PowerPoint. Τα ονόματα των διατάξεων μπορούν να επεξεργαστούν από τον χρήστη και μπορούν να τοπικοποιηθούν, έτσι η επιλογή βάσει ονόματος είναι λιγότερο αξιόπιστη εκτός εάν ελέγχετε το πηγαίο πρότυπο.

Το παρακάτω παράδειγμα ψάχνει για **Title and Content** στην πρώτη master. Εάν αυτή η διάταξη δεν είναι διαθέσιμη, επιστρέφει εκ προθέσεως στην **Blank**. Ο δεύτερος έλεγχος null είναι αναγκαίος επειδή μια παρουσίαση μπορεί να περιέχει μόνο προσαρμοσμένες διατάξεις. Η επιλεγμένη διάταξη εφαρμόζεται στη πρώτη κανονική διαφάνεια μέσω της μεθόδου [ISlide.setLayoutSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-).

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

Η αλλαγή της διάταξης μιας διαφάνειας δεν αφαιρεί τα συνηθισμένα σχήματα που προστέθηκαν απευθείας στη διαφάνεια. Ωστόσο, οι θέσεις των δεσμευτικών θέσεων, η κληρονομημένη μορφοποίηση και η αντιστοίχηση μεταξύ των υπαρχουσών δεσμευτικών θέσεων και της νέας διάταξης μπορούν να αλλάξουν, γι' αυτό ελέγξτε το αποτέλεσμα όταν μεταβαίνετε μεταξύ σημαντικά διαφορετικών διατάξεων.

## **Προσθήκη Διάταξης Διαφάνειας**

Η επιλογή και η δημιουργία είναι ξεχωριστές λειτουργίες. Το προηγούμενο παράδειγμα επιλέγει μια υπάρχουσα διάταξη· δεν δημιουργεί νέα. Για να δημιουργήσετε μια διάταξη, καλέστε τη μέθοδο [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) στη συλλογή διατάξεων του επιλεγμένου master.

Το παρακάτω παράδειγμα προσθέτει πάντα μια νέα διάταξη **Title and Content** με όνομα `Report Title and Content`, στη συνέχεια προσθέτει μια κανονική διαφάνεια βασισμένη σε αυτήν. Τα ονόματα των διατάξεων πρέπει να είναι μοναδικά μέσα στη συλλογή.

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

Προσθέστε μια διάταξη μόνο όταν το πρότυπο πραγματικά χρειάζεται μια άλλη επαναχρησιμοποιήσιμη δομή. Εάν υπάρχει ήδη μια κατάλληλη διάταξη, επιλέξτε τη και επαναχρησιμοποιήστε τη αντί να δημιουργήσετε αντίγραφο.

## **Προσθήκη Δεσμευτικών Θέσεων σε Διάταξη Διαφάνειας**

Η μέθοδος [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) παρέχει ένα [ILayoutPlaceholderManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutplaceholdermanager/) για την προσθήκη σχημάτων δεσμευτικών θέσεων σε μια διάταξη.

| Δεσμευτική Θέση PowerPoint | `ILayoutPlaceholderManager` Method |
| -------------------------- | ---------------------------------- |
| ![Περιεχόμενο](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Περιεχόμενο (Κατακόρυφο)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Κείμενο](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Κείμενο (Κατακόρυφο)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Εικόνα](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Διάγραμμα](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Πίνακας](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Πολυμέσα](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Διαδικτυακή Εικόνα](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Το παρακάτω παράδειγμα ελέγχει αν η διάταξη **Blank** υπάρχει, προσθέτει τέσσερις δεσμευτικές θέσεις σε αυτήν, και στη συνέχεια δημιουργεί μια κανονική διαφάνεια που χρησιμοποιεί τη τροποποιημένη διάταξη. Η σειρά είναι σκόπιμη: οι δεσμευτικές θέσεις προστίθενται πριν δημιουργηθεί η κανονική διαφάνεια, ώστε το Aspose.Slides να μπορεί να δημιουργήσει τα αντίστοιχα σχήματα δεσμευτικών θέσεων σε εκείνη τη διαφάνεια.

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

![Οι δεσμευτικές θέσεις στη διάταξη διαφάνειας](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Η αλλαγή της κληρονομημένης μορφοποίησης ή της γεωμετρίας των υπαρχουσών δεσμευτικών θέσεων διάταξης μπορεί να επηρεάσει τις εξαρτημένες διαφάνειες. Μια νεοπροστεθείσα δεσμευτική θέση διάταξης δεν προστίθεται αυτόματα στις υπάρχουσες κανονικές διαφάνειες. Δοκιμάστε τις αλλαγές διάταξης σε αντίγραφο της παρουσίασης και ελέγξτε κάθε εξαρτημένη διαφάνεια.
{{% /alert %}}

## **Αφαίρεση Μη Χρησιμοποιούμενων Διατάξεων Διαφάνειας**

Χρησιμοποιήστε τη μέθοδο [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) για να αφαιρέσετε διατάξεις που δεν αναφέρονται σε καμία κανονική διαφάνεια. Η μέθοδος διατηρεί αμετάβλητες τις διατάξεις που εξακολουθούν να χρησιμοποιούνται.

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

Για να αφαιρέσετε μια συγκεκριμένη διάταξη, χρησιμοποιήστε πρώτα τη μέθοδο [hasDependingSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) ή [getDependingSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutslide/#getDependingSlides--). Αναπροσαρμόστε τυχόν εξαρτημένες διαφάνειες πριν καλέσετε τη [ILayoutSlide.remove](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutslide/#remove--). Η προσπάθεια αφαίρεσης μιας χρησιμοποιούμενης διάταξης προκαλεί την εξαίρεση [PptxEditException](https://reference.aspose.com/slides/el/java/com.aspose.slides/pptxeditexception/).

## **Έλεγχος Ορατότητας Υποσέλιδου σε Διάταξη Διαφάνειας**

Μία διάταξη διαθέτει τις δικές της δεσμευτικές θέσεις υποσέλιδου, αριθμού διαφάνειας και ημερομηνίας‑ ώρας. Χρησιμοποιήστε τη μέθοδο [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) για να ελέγξετε αυτές τις δεσμευτικές θέσεις για μια διάταξη. Αυτό είναι χρήσιμο όταν, για παράδειγμα, οι διατάξεις περιεχομένου πρέπει να εμφανίζουν υποσέλιδα ενώ οι διατάξεις τίτλου όχι.

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

## **Έλεγχος Ορατότητας Υποσέλιδου σε Master και τις Παράγωγες Διατάξεις της**

Για να εφαρμόσετε συνεπείς ρυθμίσεις υποσέλιδου σε ολόκληρη τη ιεραρχία ενός master, χρησιμοποιήστε τη μέθοδο [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--). Οι μέθοδοι διάδοσης του [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterslideheaderfootermanager/) λειτουργούν στο master και στις εξαρτημένες από αυτό διατάξεις διαφάνειας και κανονικές διαφάνειες· δεν στοχεύουν μόνο σε μία κανονική διαφάνεια.

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

## **FAQ**

**Ποια είναι η διαφορά μεταξύ μιας Master Slide και μιας Layout Slide;**

Μια master slide ορίζει το θέμα της παρουσίασης και τη κοινή μορφοποίηση. Μια layout slide ανήκει σε μια master και ορίζει μία επαναχρησιμοποιήσιμη διάταξη δεσμευτικών θέσεων. Οι κανονικές διαφάνειες χρησιμοποιούν αυτές τις διατάξεις και αποθηκεύουν περιεχόμενο ειδικό για κάθε διαφάνεια.

**Μπορώ να αντιγράψω μια Layout Slide από μία παρουσίαση σε άλλη;**

Ναι. Προσθέστε ένα αντίγραφο στη συλλογή προορισμού με τη μέθοδο [addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). Κατά την αντιγραφή μεταξύ παρουσιάσεων, ελέγξτε επίσης τις γραμματοσειρές, τα θέματα, τις εικόνες και άλλους πόρους που χρησιμοποιεί η πηγαία διάταξη.

**Τι συμβαίνει όταν τροποποιώ μια Διάταξη που χρησιμοποιείται ήδη;**

Οι εξαρτημένες διαφάνειες κληρονομούν τις αλλαγές της διάταξης εκτός εάν παρακάμπτουν τη μορφοποίηση ή τα αντικείμενα τοπικά. Η γεωμετρία των δεσμευτικών θέσεων και η κληρονομημένη μορφοποίηση μπορούν έτσι να αλλάξουν σε πολλές διαφάνειες ταυτόχρονα. Χρησιμοποιήστε την [getDependingSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) για να εντοπίσετε τις επηρεαζόμενες διαφάνειες πριν επεξεργαστείτε τη διάταξη.

**Τι συμβαίνει εάν αφαιρέσω μια Διάταξη που χρησιμοποιείται ακόμη;**

Το Aspose.Slides πετάει μια [PptxEditException](https://reference.aspose.com/slides/el/java/com.aspose.slides/pptxeditexception/). Αναπροσαρμόστε πρώτα τις εξαρτημένες διαφάνειες ή χρησιμοποιήστε τη [removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) για να αφαιρέσετε μόνο τις ακατάσχετες διατάξεις.