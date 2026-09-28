---
title: Εφαρμόστε ή Αλλάξτε διατάξεις διαφάνειας στο Android
linktitle: Διάταξη διαφάνειας
type: docs
weight: 60
url: /el/androidjava/slide-layout/
keywords:
- διάταξη διαφάνειας
- διάταξη περιεχομένου
- σύμβολο κράτησης θέσης
- σχεδιασμός παρουσίασης
- σχεδιασμός διαφάνειας
- αχρησιμοποίητη διάταξη
- ορατότητα υποσέλιδου
- διαφάνεια τίτλου
- τίτλος και περιεχόμενο
- κεφαλίδα ενότητας
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
description: "Εφαρμόστε, δημιουργήστε και τροποποιήστε διατάξεις διαφάνειας στο Aspose.Slides για Android μέσω Java, προσθέστε σύμβολα κράτησης θέσης, αφαιρέστε αχρησιμοποίητες διατάξεις και ελέγξτε την ορατότητα του υποσέλιδου."
---
## **Επισκόπηση**

Η διάταξη μιας διαφάνειας ορίζει τις θέσεις και τη μορφοποίηση των σύμβολων κράτησης θέσης όπως τίτλους, κείμενο, εικόνες, διαγράμματα και πίνακες. Η εφαρμογή μιας διάταξης παρέχει στις διαφάνειες μια συνεπή δομή, ενώ επιτρέπει σε κάθε διαφάνεια να περιέχει το δικό της περιεχόμενο.

Οι πιο συχνές διατάξεις περιλαμβάνουν:

- **Title Slide**: Περιέχει σύμβολα κράτησης θέσης τίτλου και υπότιτλου.
- **Title and Content**: Περιέχει σύμβολο κράτησης θέσης τίτλου και ένα γενικού σκοπού σύμβολο κράτησης θέσης περιεχομένου.
- **Blank**: Δεν περιέχει σύμβολα κράτησης θέσης και είναι χρήσιμη όταν κάθε σχήμα θα τοποθετηθεί χειροκίνητα.

## **Κατανόηση Κληρονομικότητας Διάταξης**

Μια παρουσίαση έχει τρία σχετιζόμενα επίπεδα:

1. Ένα [master slide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterslide/) ορίζει το θέμα, τη κοινή μορφοποίηση, τα φόντα και τα κοινά αντικείμενα.
1. Ένα [layout slide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutslide/) ανήκει σε έναν master και ορίζει μια συγκεκριμένη διάταξη συμβόλων κράτησης θέσης.
1. Μια [normal slide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islide/) χρησιμοποιεί μια διάταξη και αποθηκεύει το περιεχόμενο που εισήχθη για εκείνη τη διαφάνεια.

Μια κανονική διαφάνεια κληρονομεί το θέμα και τη μορφοποίηση από τη διάταξή της, και η διάταξη κληρονομεί από τον master της. Μια τιμή που ορίζεται απευθείας σε μια κανονική διαφάνεια παρακάμπτει την κληρονομημένη τιμή σε εκείνο το επίπεδο. Όταν δημιουργείται μια κανονική διαφάνεια, τα σχήματα σύμβολων κράτησης θέσης παράγονται από τη επιλεγμένη διάταξη, ενώ το περιεχόμενο που εισάγεται σε αυτά τα σύμβολα ανήκει στην κανονική διαφάνεια.

Προσθέστε τα απαιτούμενα σύμβολα κράτησης θέσης σε μια διάταξη πριν δημιουργήσετε διαφάνειες από αυτήν. Η προσθήκη άλλου συμβόλου κράτησης θέσης σε μια διάταξη αργότερα δεν προσθέτει αυτόματα το αντίστοιχο σχήμα σε υπάρχουσες κανονικές διαφάνειες.

Αυτή η σχέση έχει δύο σημαντικές συνέπειες:

- Η αλλαγή κληρονομισμένης μορφοποίησης ή της γεωμετρίας υφιστάμενων συμβόλων κράτησης θέσης σε μια διάταξη μπορεί να ενημερώσει κάθε διαφάνεια που εξαρτάται από αυτήν. Πριν επεξεργαστείτε μια διάταξη που ήδη χρησιμοποιείται, ελέγξτε τις εξαρτημένες διαφάνειες και εξετάστε το τελικό αποτέλεσμα.
- Μια διάταξη που χρησιμοποιείται ακόμη από κάποια διαφάνεια δεν μπορεί να αφαιρεθεί. Αναθέστε πρώτα τις εξαρτημένες διαφάνειες σε άλλη διάταξη ή αφαιρέστε μόνο τις αχρησιμοποίητες διατάξεις.

Για περισσότερες πληροφορίες σχετικά με το ανώτερο επίπεδο της ιεραρχίας, δείτε [Slide Master](/slides/el/androidjava/slide-master/).

Για να κρύψετε κληρονομημένα λογότυπα ή διακοσμητικά σχήματα κυρίου σε μια διαφάνεια ή μέσω κοινής διάταξης, δείτε [Control the Visibility of Master Graphics](/slides/el/androidjava/slide-master/). Το παράδειγμα συγκρίνει δύο διαφάνειες που χρησιμοποιούν τον ίδιο κύριο.

## **Επιλογή και Εφαρμογή Διάταξης Διαφάνειας**

Χρησιμοποιήστε έναν τύπο διάταξης όταν η παρουσίαση ακολουθεί τις τυπικές ορισμούς διάταξης του PowerPoint. Τα ονόματα διατάξεων μπορούν να επεξεργαστούν από τον χρήστη και να εντοπιστούν, επομένως η επιλογή βάσει ονόματος είναι λιγότερο αξιόπιστη εκτός αν ελέγχετε το πρότυπο πηγής.

Το παρακάτω παράδειγμα αναζητά **Title and Content** στον πρώτο master. Εάν αυτή η διάταξη δεν είναι διαθέσιμη, επανέρχεται σκόπιμα σε **Blank**. Ο δεύτερος έλεγχος null είναι απαραίτητος επειδή μια παρουσίαση μπορεί να περιέχει μόνο προσαρμοσμένες διατάξεις. Η επιλεγμένη διάταξη εφαρμόζεται στη πρώτη κανονική διαφάνεια μέσω της μεθόδου [ISlide.setLayoutSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) .

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

Η αλλαγή της διάταξης μιας διαφάνειας δεν αφαιρεί τα κανονικά σχήματα που προστέθηκαν άμεσα στη διαφάνεια. Ωστόσο, οι θέσεις των συμβόλων κράτησης θέσης, η κληρονομισμένη μορφοποίηση και η αντιστοίχηση μεταξύ των υπαρκτών συμβόλων και της νέας διάταξης μπορεί να αλλάξουν, επομένως ελέγξτε το αποτέλεσμα όταν αλλάζετε μεταξύ σημαντικά διαφορετικών διατάξεων.

## **Προσθήκη Διάταξης Διαφάνειας**

Η επιλογή και η δημιουργία είναι ξεχωριστές ενέργειες. Το προηγούμενο παράδειγμα επιλέγει μια υπάρχουσα διάταξη· δεν τη δημιουργεί. Για να δημιουργήσετε μια διάταξη, καλέστε τη μέθοδο [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) στη συλλογή διατάξεων του στοχευμένου master.

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

Προσθέστε μια διάταξη μόνο όταν το πρότυπο χρειάζεται πραγματικά μια ακόμη επαναχρησιμοποιήσιμη δομή. Εάν υπάρχει ήδη κατάλληλη διάταξη, επιλέξτε και επαναχρησιμοποιήστε την αντί να δημιουργήσετε διπλότυπο.

## **Προσθήκη Σύμβολων Θέσης σε Διάταξη Διαφάνειας**

Η μέθοδος [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) παρέχει ένα [ILayoutPlaceholderManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) για προσθήκη σχημάτων σύμβολων κράτησης θέσης σε μια διάταξη.

| Σύμβολο Θέσης PowerPoint | `ILayoutPlaceholderManager` Μέθοδος |
| ------------------------ | ----------------------------------- |
| ![Περιεχόμενο](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Περιεχόμενο (Κάθετο)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Κείμενο](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Κείμενο (Κάθετο)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Εικόνα](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Διάγραμμα](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Πίνακας](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Πολυμέσα](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Διαδικτυακή Εικόνα](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Το παρακάτω παράδειγμα ελέγχει ότι η διάταξη **Blank** υπάρχει, προσθέτει τέσσερα σύμβολα στη διάταξη και στη συνέχεια δημιουργεί μια κανονική διαφάνεια που χρησιμοποιεί τη τροποποιημένη διάταξη. Η σειρά είναι σκόπιμη: τα σύμβολα προστίθενται πριν δημιουργηθεί η κανονική διαφάνεια, ώστε το Aspose.Slides να μπορεί να δημιουργήσει τα αντίστοιχα σχήματα συμβόλου στη διαφάνεια.

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

Αποτέλεσμα:

![Τα σύμβολα θέσης στη διάταξη διαφάνειας](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}

Η αλλαγή κληρονομισμένης μορφοποίησης ή της γεωμετρίας υφιστάμενων συμβόλων κράτησης θέσης σε μια διάταξη μπορεί να επηρεάσει τις εξαρτημένες διαφάνειες. Ένα πρόσφατα προστιθέμενο σύμβολο διάταξης δεν συμπληρώνεται αυτόματα σε υπάρχουσες κανονικές διαφάνειες. Δοκιμάστε τις αλλαγές διάταξης σε αντίγραφο της παρουσίασης και ελέγξτε κάθε εξαρτημένη διαφάνεια.

{{% /alert %}}

## **Αφαίρεση Ανάρκτητων Διατάξεων Διαφάνειας**

Χρησιμοποιήστε τη μέθοδο [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) για να αφαιρέσετε διατάξεις που δεν αναφέρονται από καμία κανονική διαφάνεια. Η μέθοδος αφήνει αμετάβλητες τις διατάξεις που είναι ακόμη σε χρήση.

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

Για να αφαιρέσετε μια συγκεκριμένη διάταξη, χρησιμοποιήστε πρώτα τη μέθοδο [hasDependingSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) ή [getDependingSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--). Αναθέστε τυχόν εξαρτημένες διαφάνειες πριν καλέσετε το [ILayoutSlide.remove](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutslide/#remove--). Προσπάθεια αφαίρεσης μιας διατάξης που χρησιμοποιείται ενεργά προκαλεί [PptxEditException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pptxeditexception/).

## **Έλεγχος Ορατότητας Υποσέλιδου σε Διάταξη Διαφάνειας**

Μια διάταξη διαθέτει τα δικά της σύμβολα κράτησης θέσης υποσέλιδου, αριθμού διαφάνειας και ημερομηνίας‑ώρας. Χρησιμοποιήστε τη μέθοδο [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) για να ελέγξετε αυτά τα σύμβολα για μία διάταξη. Αυτό είναι χρήσιμο όταν, για παράδειγμα, οι διατάξεις περιεχομένου πρέπει να εμφανίζουν υποσέλιδα ενώ οι διατάξεις τίτλου όχι.

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

## **Έλεγχος Ορατότητας Υποσέλιδου σε Κύριο και τις Παιδικές Διατάξεις**

Για να εφαρμόσετε συνεπείς ρυθμίσεις υποσέλιδου σε όλη την ιεραρχία του master, χρησιμοποιήστε τη μέθοδο [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--). Οι μέθοδοι διάδοσης του [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) λειτουργούν στον master και στις εξαρτημένες διατάξεις διαφάνειας και στις κανονικές διαφάνειες· δεν στοχεύουν μόνο μία κανονική διαφάνεια.

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

**What Is the Difference Between a Master Slide and a Layout Slide?**

Μια κύρια διαφάνεια (master slide) ορίζει το θέμα της παρουσίασης και τη κοινή μορφοποίηση. Μια διάταξη διαφάνειας ανήκει σε έναν master και καθορίζει μια επαναχρησιμοποιήσιμη διάταξη συμβόλων κράτησης θέσης. Οι κανονικές διαφάνειες χρησιμοποιούν αυτές τις διατάξεις και αποθηκεύουν το περιεχόμενο που είναι συγκεκριμένο για κάθε διαφάνεια.

**Can I Copy a Layout Slide from One Presentation to Another?**

Ναι. Προσθέστε ένα αντίγραφο στη συλλογή προορισμού με τη μέθοδο [addClone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). Όταν αντιγράφετε μεταξύ παρουσιάσεων, ελέγξτε επίσης τις γραμματοσειρές, τα θέματα, τις εικόνες και άλλους πόρους που χρησιμοποιεί η πηγή διάταξης.

**What Happens When I Modify a Layout That Is Already in Use?**

Οι εξαρτημένες διαφάνειες κληρονομούν τις αλλαγές της διάταξης εκτός εάν έχουν παρακάμψει τη μορφοποίηση ή τα αντικείμενα τοπικά. Η γεωμετρία των συμβόλων και η κληρονομική μορφοποίηση μπορούν κατά συνέπεια να αλλάξουν σε πολλές διαφάνειες ταυτόχρονα. Χρησιμοποιήστε το [getDependingSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) για να εντοπίσετε τις επηρεαζόμενες διαφάνειες πριν επεξεργαστείτε τη διάταξη.

**What Happens If I Remove a Layout That Is Still in Use?**

Το Aspose.Slides ρίχνει μια [PptxEditException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pptxeditexception/). Αναθέστε πρώτα τις εξαρτημένες διαφάνειες ή χρησιμοποιήστε τη [removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) για να αφαιρέσετε μόνο τις διατάξεις που δεν αναφέρονται.