---
title: Εφαρμογή ή Αλλαγή διατάξεων διαφάνειας σε Java
linktitle: Διάταξη Διαφάνειας
type: docs
weight: 60
url: /el/java/slide-layout/
keywords:
- διάταξη διαφάνειας
- διάταξη περιεχομένου
- πλαίσιο κράτησης θέσης
- σχεδίαση παρουσίασης
- σχεδίαση διαφάνειας
- μη χρησιμοποιημένη διάταξη
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
description: "Διαχειριστείτε και προσαρμόστε τις διατάξεις διαφάνειας στο Aspose.Slides for Java. Εξερευνήστε τύπους διατάξεων, έλεγχο πλαισίων κράτησης θέσης και ορατότητα υποσέλιδου μέσω παραδειγμάτων κώδικα Java."
---
## **Εισαγωγή**

Μια διάταξη διαφάνειας ορίζει τη διάταξη των πλαισίων κράτησης θέσης και τη μορφοποίηση για το περιεχόμενο σε μια διαφάνεια. Ελέγχει ποια πλαίσια κράτησης θέσης είναι διαθέσιμα και πού εμφανίζονται. Οι διατάξεις διαφάνειας σας βοηθούν να σχεδιάζετε παρουσιάσεις γρήγορα και με συνέπεια — είτε δημιουργείτε κάτι απλό είτε πιο περίπλοκο. Μερικές από τις πιο συνηθισμένες διατάξεις διαφάνειας στο PowerPoint περιλαμβάνουν:

**Title Slide layout** – Περιλαμβάνει δύο πλαίσια κειμένου: ένα για τον τίτλο και ένα για τον υπότιτλο.

**Title and Content layout** – Περιέχει ένα μικρότερο πλαίσιο τίτλου στην κορυφή και ένα μεγαλύτερο από κάτω για το κύριο περιεχόμενο (όπως κείμενο, κουκίδες, διαγράμματα, εικόνες κ.ά.).

**Blank layout** – Δεν περιέχει πλαίσια κράτησης θέσης, δίνοντάς σας πλήρη έλεγχο για το σχεδιασμό της διαφάνειας από το μηδέν.

Οι διατάξεις διαφάνειας αποτελούν μέρος ενός master διαφάνειας, η οποία είναι η ανώτερη διαφάνεια που ορίζει τα στυλ διατάξεων για την παρουσίαση. Μπορείτε να έχετε πρόσβαση και να τροποποιήσετε τις διατάξεις διαφάνειας μέσω του master—είτε με τον τύπο, το όνομα ή το μοναδικό ID. Εναλλακτικά, μπορείτε να επεξεργαστείτε μια συγκεκριμένη διάταξη διαφάνειας απευθείας μέσα στην παρουσίαση.

Για να εργάζεστε με διατάξεις διαφάνειας στο Aspose.Slides for Java, μπορείτε να χρησιμοποιήσετε:

- Μεθόδους όπως [getLayoutSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getLayoutSlides--) και [getMasters](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getMasters--) κάτω από την κλάση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) 
- Τύπους όπως [ILayoutSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutplaceholdermanager/), και [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Για να μάθετε περισσότερα για την εργασία με master διαφάνειες, δείτε το άρθρο [Slide Master](/slides/el/java/slide-master/) .
{{% /alert %}}

## **Προσθήκη Διατάξεων Διαφάνειας σε Παρουσιάσεις**

Για να προσαρμόσετε την εμφάνιση και τη δομή των διαφανειών σας, ίσως χρειαστεί να προσθέσετε νέες διατάξεις σε μια παρουσίαση. Το Aspose.Slides for Java σας επιτρέπει να ελέγξετε αν μια συγκεκριμένη διάταξη υπάρχει ήδη, να προσθέσετε νέα εάν χρειάζεται, και να τη χρησιμοποιήσετε για την εισαγωγή διαφανειών βασισμένων σε αυτήν.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) .
1. Πρόσβαση στην [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/imasterlayoutslidecollection/) .
1. Ελέγξτε αν η επιθυμητή διάταξη διαφάνειας υπάρχει ήδη στη συλλογή. Αν όχι, προσθέστε τη διάταξη που χρειάζεστε.
1. Προσθέστε μια κενή διαφάνεια βασισμένη στη νέα διάταξη.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας Java δείχνει πώς να προσθέσετε μια διάταξη διαφάνειας σε μια παρουσίαση PowerPoint:

```java
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Περάστε από τους τύπους διατάξεων διαφάνειας για να επιλέξετε μια διάταξη διαφάνειας.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // Μια κατάσταση όπου η παρουσίαση δεν περιέχει όλους τους τύπους διατάξεων.
        // Το αρχείο παρουσίασης περιέχει μόνο τους τύπους διατάξεων Blank και Custom.
        // Ωστόσο, οι διατάξεις διαφάνειας με προσαρμοσμένους τύπους μπορεί να έχουν αναγνωρίσιμα ονόματα,
        // όπως "Title", "Title and Content", κ.λπ., που μπορούν να χρησιμοποιηθούν για επιλογή διάταξης διαφάνειας.
        // Μπορείτε επίσης να βασιστείτε σε ένα σύνολο τύπων σχημάτων κράτησης θέσης.
        // Για παράδειγμα, μια διαφάνεια Τίτλου πρέπει να έχει μόνο τον τύπο κράτησης θέσης Title, κ.ο.κ.
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName().equals("Title and Object")) {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName().equals("Title")) {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(SlideLayoutType.Blank);
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Προσθέστε μια κενή διαφάνεια χρησιμοποιώντας τη δοθείσα διάταξη διαφάνειας.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Κατάργηση Μη Χρησιμοποιούμενων Διατάξεων Διαφάνειας**

Το Aspose.Slides παρέχει τη μέθοδο [removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) από την κλάση [Compress](https://reference.aspose.com/slides/el/java/com.aspose.slides/compress/) για να διαγράψετε ανεπιθύμητες και μη χρησιμοποιούμενες διατάξεις διαφάνειας.

Ο παρακάτω κώδικας Java δείχνει πώς να καταργήσετε μια διάταξη διαφάνειας από μια παρουσίαση PowerPoint:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Προσθήκη Πλαισίων Κράτησης Θέσης σε Διατάξεις Διαφάνειας**

Το Aspose.Slides παρέχει τη μέθοδο [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) που σας επιτρέπει να προσθέσετε νέα πλαίσια κράτησης θέσης σε μια διάταξη διαφάνειας.

Αυτός ο διαχειριστής περιέχει μεθόδους για τους ακόλουθους τύπους πλαισίων:

| Πλαίσιο PowerPoint | Μέθοδος |
| ------------------- | -------- |
| ![Περιεχόμενο](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Περιεχόμενο (Κατακόρυφα)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Κείμενο](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Κείμενο (Κατακόρυφα)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Εικόνα](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Διάγραμμα](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Πίνακας](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Μέσα](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Φωτογραφία στο Διαδίκτυο](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Ο παρακάτω κώδικας Java δείχνει πώς να προσθέσετε νέα σχήματα πλαισίων κράτησης θέσης στη διάταξη Blank:

```java
Presentation presentation = new Presentation();
try {
    // Πάρτε τη διάταξη διαφάνειας Blank.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Αποκτήστε τον διαχειριστή πλαισίων κράτησης θέσης της διάταξης διαφάνειας.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Προσθέστε διαφορετικά πλαίσια κράτησης θέσης στη διάταξη διαφάνειας Blank.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Προσθέστε μια νέα διαφάνεια με τη διάταξη Blank.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![The placeholders on the layout slide](add_placeholders.png)

## **Ορισμός Ορατότητας Υποσέλιδου για Διάταξη Διαφάνειας**

Σε παρουσιάσεις PowerPoint, στοιχεία υποσέλιδου όπως ημερομηνία, αριθμός διαφάνειας και προσαρμοσμένο κείμενο μπορούν να εμφανίζονται ή να κρύβονται ανάλογα με τη διάταξη. Το Aspose.Slides for Java σας επιτρέπει να ελέγξετε την ορατότητα αυτών των πλαισίων υποσέλιδου. Αυτό είναι χρήσιμο όταν θέλετε ορισμένες διατάξεις να εμφανίζουν πληροφορίες υποσέλιδου ενώ άλλες παραμένουν καθαρές.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) .
1. Λάβετε μια αναφορά στη διάταξη διαφάνειας με το δείκτη της.
1. Ορίστε το πλαίσιο υποσέλιδου της διαφάνειας ως ορατό.
1. Ορίστε το πλαίσιο αριθμού διαφάνειας ως ορατό.
1. Ορίστε το πλαίσιο ημερομηνίας/ώρας ως ορατό.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας Java δείχνει πώς να ορίσετε την ορατότητα του υποσέλιδου μιας διαφάνειας:

```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

    if (!headerFooterManager.isFooterVisible()) {
        headerFooterManager.setFooterVisibility(true);
    }

    if (!headerFooterManager.isSlideNumberVisible()) {
        headerFooterManager.setSlideNumberVisibility(true);
    }

    if (!headerFooterManager.isDateTimeVisible()) {
        headerFooterManager.setDateTimeVisibility(true);
    }

    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("Presentation.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Ορατότητας Υποσέλιδου στα Παράγωγα για μια Διαφάνεια**

Σε παρουσιάσεις PowerPoint, στοιχεία υποσέλιδου όπως ημερομηνία, αριθμός διαφάνειας και προσαρμοσμένο κείμενο μπορούν να ελεγχθούν στο επίπεδο της master διαφάνειας ώστε να εξασφαλιστεί συνέπεια σε όλες τις διατάξεις. Το Aspose.Slides for Java σας επιτρέπει να ορίσετε την ορατότητα και το περιεχόμενο αυτών των πλαίσιων υποσέλιδου στη master διαφάνεια και να διαδράσετε αυτές τις ρυθμίσεις σε όλες τις θυγατρικές διατάξεις διαφάνειας. Αυτή η προσέγγιση εξασφαλίζει ομοιόμορφη πληροφορία υποσέλιδου σε όλη την παρουσίαση.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) .
1. Λάβετε μια αναφορά στη master διαφάνεια με το δείκτη της.
1. Ορίστε τα πλαίσια υποσέλιδου της master και όλων των θυγατρικών ως ορατά.
1. Ορίστε τα πλαίσια αριθμού διαφάνειας της master και όλων των θυγατρικών ως ορατά.
1. Ορίστε τα πλαίσια ημερομηνίας/ώρας της master και όλων των θυγατρικών ως ορατά.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας Java δείχνει αυτή τη λειτουργία:

```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Ποια είναι η διαφορά μεταξύ μιας master διαφάνειας και μιας διάταξης διαφάνειας;**

Μια master διαφάνεια ορίζει το γενικό θέμα και τη προεπιλεγμένη μορφοποίηση, ενώ οι διατάξεις διαφάνειας ορίζουν συγκεκριμένες διατάξεις πλαισίων για διαφορετικούς τύπους περιεχομένου.

**Μπορώ να αντιγράψω μια διάταξη διαφάνειας από μια παρουσίαση σε άλλη;**

Ναι, μπορείτε να κλωνοποιήσετε μια διάταξη διαφάνειας από τη συλλογή διατάξεων μιας παρουσίασης, προσβάσιμη μέσω της μεθόδου [getLayoutSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getLayoutSlides--) , και να την εισάγετε σε άλλη παρουσίαση χρησιμοποιώντας τη μέθοδο `addClone`.

**Τι συμβαίνει αν διαγράψω μια διάταξη διαφάνειας που χρησιμοποιείται ακόμη από μια διαφάνεια;**

Αν προσπαθήσετε να διαγράψετε μια διάταξη διαφάνειας που εξακολουθεί να αναφέρεται από τουλάχιστον μία διαφάνεια στην παρουσίαση, το Aspose.Slides θα εγείρει μια [PptxEditException](https://reference.aspose.com/slides/el/java/com.aspose.slides/pptxeditexception/). Για να το αποφύγετε, χρησιμοποιήστε τη [removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) η οποία αφαιρεί με ασφάλεια μόνο τις διατάξεις που δεν χρησιμοποιούνται.