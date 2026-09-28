---
title: Εφαρμογή ή Αλλαγή Διατάξεων Διαφάνειας σε Java
linktitle: Διάταξη Διαφάνειας
type: docs
weight: 60
url: /el/java/slide-layout/
keywords:
- διάταξη διαφάνειας
- διάταξη περιεχομένου
- δείκτης θέσης
- σχεδιασμός παρουσίασης
- σχεδιασμός διαφάνειας
- αχρησιμοποιημένη διάταξη
- ορατότητα υποσέλιδου
- διαφάνεια τίτλου
- τίτλος και περιεχόμενο
- επικεφαλίδα ενότητας
- δυο περιεχόμενα
- σύγκριση
- μόνο τίτλος
- κενή διάταξη
- περιεχόμενο με υπότιτλο
- εικόνα με υπότιτλο
- τίτλος και κάθετο κείμενο
- κάθετος τίτλος και κείμενο
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Εφαρμόστε, δημιουργήστε και τροποποιήστε διατάξεις διαφάνειας στο Aspose.Slides για Java, προσθέστε δείκτες θέσης, αφαιρέστε αχρησιμοποιημένες διατάξεις και ελέγξτε την ορατότητα του υποσέλιδου."
---
## **Επισκόπηση**

Ένα διάταξη διαφάνειας ορίζει τις θέσεις και τη μορφοποίηση των δεικτών θέσης όπως τίτλοι, κείμενο, εικόνες, γραφήματα και πίνακες. Η εφαρμογή μιας διάταξης παρέχει στις διαφάνειες μια συνεπή δομή ενώ επιτρέπει σε κάθε διαφάνεια να περιέχει το δικό της περιεχόμενο.

Οι πιο κοινές διατάξεις περιλαμβάνουν:

- **Διαφάνεια Τίτλου**: Περιέχει δείκτες θέσης τίτλου και υπότιτλου.
- **Τίτλος και Περιεχόμενο**: Περιέχει έναν δείκτη θέσης τίτλου και έναν γενικού σκοπού δείκτη περιεχομένου.
- **Κενή**: Δεν περιέχει δείκτες θέσης περιεχομένου και είναι χρήσιμη όταν κάθε σχήμα θα τοποθετηθεί χειροκίνητα.

## **Κατανόηση Κληρονομικότητας Διατάξεων**

Μια παρουσίαση έχει τρία σχετικούς επίπεδα:

1. Μια [master slide](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterslide/) καθορίζει το θέμα, κοινή μορφοποίηση, φόντα και κοινά αντικείμενα.
2. Μια [layout slide](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutslide/) ανήκει σε κύρια και καθορίζει μια συγκεκριμένη διάταξη δεικτών θέσης.
3. Μια [normal slide](https://reference.aspose.com/slides/el/java/com.aspose.slides/islide/) χρησιμοποιεί μία διάταξη και αποθηκεύει το περιεχόμενο που εισήχθη για εκείνη τη διαφάνεια.

Μια κανονική διαφάνεια κληρονομεί το θέμα και τη μορφοποίηση από τη διάταξή της, ενώ η διάταξη κληρονομεί από την κύρια. Μια τιμή που ορίζεται άμεσα σε μια κανονική διαφάνεια παρακάμπτει την κληρονομημένη τιμή σε εκείνο το επίπεδο. Όταν δημιουργείται μια κανονική διαφάνεια, τα σχήματα δεικτών θέσης παράγονται από την επιλεγμένη διάταξη, ενώ το περιεχόμενο που εισάγεται σε αυτούς τους δείκτες ανήκει στην κανονική διαφάνεια.

Προσθέστε απαιτούμενους δείκτες θέσης σε μια διάταξη πριν δημιουργήσετε διαφάνειες από αυτήν. Η προσθήκη ενός ακόμη δείκτη σε μια διάταξη αργότερα δεν προσθέτει αυτόματα το αντίστοιχο σχήμα δείκτη σε υπάρχουσες κανονικές διαφάνειες.

Αυτή η σχέση έχει δύο σημαντικές συνέπειες:

- Η αλλαγή κληρονομικής μορφοποίησης ή της γεωμετρίας των υπαρχόντων δεικτών σε μια διάταξη μπορεί να ενημερώσει κάθε διαφάνεια που εξαρτάται από αυτήν. Πριν επεξεργαστείτε μια διάταξη που χρησιμοποιείται ήδη, ελέγξτε τις εξαρτημένες διαφάνειες και εξετάστε το τελικό αποτέλεσμα.
- Μια διάταξη που εξακολουθεί να χρησιμοποιείται από κάποια διαφάνεια δεν μπορεί να αφαιρεθεί. Αναθέστε πρώτα τις εξαρτημένες διαφάνειες σε άλλη διάταξη ή αφαιρέστε μόνο τις ανεξάρτητες διατάξεις.

Για περισσότερες πληροφορίες σχετικά με το ανώτερο επίπεδο αυτής της ιεραρχίας, δείτε [Slide Master](/slides/el/java/slide-master/).

Για να κρύψετε κληρονομικά λογότυπα ή διακοσμητικά σχήματα κύριας σε μία διαφάνεια ή μέσω κοινής διάταξης, δείτε [Control the Visibility of Master Graphics](/slides/el/java/slide-master/). Το παράδειγμα συγκρίνει δύο διαφάνειες που χρησιμοποιούν την ίδια κύρια.

## **Επιλογή και Εφαρμογή Διάταξης Διαφάνειας**

Χρησιμοποιήστε έναν τύπο διάταξης όταν η παρουσίαση ακολουθεί τις τυπικές ορισμούς διάταξης του PowerPoint. Τα ονόματα διατάξεων μπορούν να επεξεργαστούν από τον χρήστη και να εντοπιστούν, γι’ αυτό η επιλογή με βάση το όνομα είναι λιγότερο αξιόπιστη εκτός εάν ελέγχετε το πρότυπο πηγή.

Το παρακάτω παράδειγμα ψάχνει για **Title and Content** στην πρώτη κύρια. Εάν αυτή η διάταξη δεν είναι διαθέσιμη, επιστρέφει σκόπιμα στο **Blank**. Ο δεύτερος έλεγχος null είναι απαραίτητος επειδή μια παρουσίαση μπορεί να περιέχει μόνο προσαρμοσμένες διατάξεις. Η επιλεγμένη διάταξη εφαρμόζεται στη πρώτη κανονική διαφάνεια μέσω της [ISlide.setLayoutSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) μεθόδου.

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

Η αλλαγή της διάταξης μιας διαφάνειας δεν αφαιρεί τα κανονικά σχήματα που προστέθηκαν απευθείας στη διαφάνεια. Ωστόσο, οι θέσεις των δεικτών, η κληρονομική μορφοποίηση και η αντιστοιχία μεταξύ των υπαρχουσών δεικτών και της νέας διάταξης μπορεί να αλλάξει, οπότε ελέγξτε το αποτέλεσμα όταν μεταβάλλετε σε σημαντικά διαφορετικές διατάξεις.

## **Προσθήκη Διάταξης Διαφάνειας**

Η επιλογή και η δημιουργία είναι ξεχωριστές λειτουργίες. Το προηγούμενο παράδειγμα επιλέγει μια υπάρχουσα διάταξη· δεν δημιουργεί μια νέα. Για να δημιουργήσετε μια διάταξη, καλέστε τη μέθοδο [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) στη συλλογή διευθύνσεων της στοχευμένης κύριας.

Το παρακάτω παράδειγμα προσθέτει πάντα μια νέα διάταξη **Title and Content** με όνομα `Report Title and Content`, στη συνέχεια προσθέτει μια κανονική διαφάνεια βασισμένη σε αυτήν. Τα ονόματα διατάξεων πρέπει να είναι μοναδικά μέσα στη συλλογή.

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

Προσθέστε μια διάταξη μόνο όταν το πρότυπο απαιτεί πραγματικά μια επιπλέον δομή επαναχρησιμοποίησης. Εάν υπάρχει ήδη κατάλληλη διάταξη, επιλέξτε και επαναχρησιμοποιήστε την αντί να δημιουργήσετε διπλότυπο.

## **Προσθήκη Δεικτών Θέσης σε Διάταξη Διαφάνειας**

Η μέθοδος [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) παρέχει ένα [ILayoutPlaceholderManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutplaceholdermanager/) για την προσθήκη σχημάτων δεικτών σε μια διάταξη.

| Δείκτης PowerPoint                | `ILayoutPlaceholderManager` Μέθοδος |
| ----------------------------------- | ----------------------------------- |
| ![Περιεχόμενο](content.png)        | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Περιεχόμενο (Κατακόρυφο)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Κείμενο](text.png)               | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Κείμενο (Κατακόρυφο)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Εικόνα](picture.png)             | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Διάγραμμα](chart.png)            | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Πίνακας](table.png)              | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png)          | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Πολυμέσα](media.png)             | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Διαδικτυακή Εικόνα](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Το παρακάτω παράδειγμα ελέγχει ότι η διάταξη **Blank** υπάρχει, προσθέτει τέσσερις δείκτες σε αυτήν και, στη συνέχεια, δημιουργεί μια κανονική διαφάνεια που χρησιμοποιεί τη τροποποιημένη διάταξη. Η σειρά είναι σκόπιμη: οι δείκτες προστίθενται πριν δημιουργηθεί η κανονική διαφάνεια, ώστε το Aspose.Slides να δημιουργήσει τα αντίστοιχα σχήματα δεικτών σε αυτήν τη διαφάνεια.

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

![Οι δείκτες θέσης στη διάταξη της διαφάνειας](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Η αλλαγή κληρονομικής μορφοποίησης ή της γεωμετρίας των υπαρχόντων δεικτών διάταξης μπορεί να επηρεάσει τις εξαρτημένες διαφάνειες. Ένας νέος προστιθέμενος δείκτης δεν προστίθεται αυτόματα σε υπάρχουσες κανονικές διαφάνειες. Δοκιμάστε τις αλλαγές διάταξης σε αντίγραφο της παρουσίασης και ελέγξτε κάθε εξαρτημένη διαφάνεια.
{{% /alert %}}

## **Αφαίρεση Αχρησιμοποίητων Διατάξεων Διαφάνειας**

Χρησιμοποιήστε τη μέθοδο [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) για να αφαιρέσετε διατάξεις που δεν αναφέρονται σε καμία κανονική διαφάνεια. Η μέθοδος αφήνει άθικτες τις διατάξεις που χρησιμοποιούνται ακόμη.

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

Για να αφαιρέσετε μια συγκεκριμένη διάταξη, πρώτα χρησιμοποιήστε τη μέθοδο [hasDependingSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) ή [getDependingSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) της. Επαναναθέστε τυχόν εξαρτημένες διαφάνειες πριν καλέσετε το [ILayoutSlide.remove](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutslide/#remove--). Η προσπάθεια αφαίρεσης μιας διάταξης που χρησιμοποιείται προκαλεί [PptxEditException](https://reference.aspose.com/slides/el/java/com.aspose.slides/pptxeditexception/).

## **Έλεγχος Ορατότητας Υποσέλιδου σε Διάταξη Διαφάνειας**

Μια διάταξη διαθέτει τα δικά της υποσέλιδα, αριθμούς διαφάνειας και δείκτες ημερομηνίας‑ώρας. Χρησιμοποιήστε τη μέθοδο [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) για να ελέγξετε αυτούς τους δείκτες για μία διάταξη. Αυτό είναι χρήσιμο όταν, για παράδειγμα, οι διατάξεις περιεχομένου πρέπει να εμφανίζουν υποσέλιδα αλλά οι διατάξεις τίτλου όχι.

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

## **Έλεγχος Ορατότητας Υποσέλιδου σε Κύρια Διαφάνεια και τις Υποδιατάξεις της**

Για να εφαρμόσετε συνεπείς ρυθμίσεις υποσέλιδου σε όλη την ιεραρχία της κύριας, χρησιμοποιήστε τη μέθοδο [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--). Οι μέθοδοι διάδοσης του [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterslideheaderfootermanager/) λειτουργούν στην κύρια και στις εξαρτημένες διατάξεις και κανονικές διαφάνειες· δεν στοχεύουν μόνο μία κανονική διαφάνεια.

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

**Ποια είναι η διαφορά μεταξύ μιας κύριας διαφάνειας και μιας διάταξης διαφάνειας;**

Μια κύρια διαφάνεια ορίζει το θέμα και τη κοινή μορφοποίηση της παρουσίασης. Μια διάταξη διαφάνειας ανήκει σε κύρια και καθορίζει μία επαναχρησιμοποιήσιμη διάταξη δεικτών θέσης. Οι κανονικές διαφάνειες χρησιμοποιούν αυτές τις διατάξεις και αποθηκεύουν το περιεχόμενο της συγκεκριμένης διαφάνειας.

**Μπορώ να αντιγράψω μια διάταξη διαφάνειας από μια παρουσίαση σε μία άλλη;**

Ναι. Προσθέστε ένα αντίγραφο στη συλλογή προορισμού με τη μέθοδο [addClone](https://reference.aspose.com/slides/el/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). Όταν αντιγράφετε μεταξύ παρουσιάσεων, ελέγξτε επίσης γραμματοσειρές, θέματα, εικόνες και άλλους πόρους που χρησιμοποιεί η πηγή διάταξης.

**Τι συμβαίνει όταν τροποποιώ μια διάταξη που χρησιμοποιείται ήδη;**

Οι εξαρτημένες διαφάνειες κληρονομούν τις αλλαγές της διάταξης, εκτός εάν παρακάμπτουν τη μορφοποίηση ή τα αντικείμενα τοπικά. Η γεωμετρία των δεικτών και η κληρονομική μορφοποίηση μπορούν επομένως να αλλάξουν σε πολλές διαφάνειες ταυτόχρονα. Χρησιμοποιήστε το [getDependingSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) για να εντοπίσετε τις επηρεασμένες διαφάνειες πριν επεξεργαστείτε τη διάταξη.

**Τι συμβαίνει αν αφαιρέσω μια διάταξη που χρησιμοποιείται ακόμα;**

Το Aspose.Slides ρίχνει μια [PptxEditException](https://reference.aspose.com/slides/el/java/com.aspose.slides/pptxeditexception/). Αναθέστε πρώτα τις εξαρτημένες διαφάνειες ή χρησιμοποιήστε το [removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) για να αφαιρέσετε μόνο τις μη αναφερόμενες διατάξεις.