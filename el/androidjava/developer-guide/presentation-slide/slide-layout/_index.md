---
title: Εφαρμογή ή Αλλαγή Διατάξεων Διαφανειών στο Android
linktitle: Διάταξη Διαφάνειας
type: docs
weight: 60
url: /el/androidjava/slide-layout/
keywords:
- διάταξη διαφάνειας
- διάταξη περιεχομένου
- πλαίσιο κράτησης θέσης
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
- Android
- Java
- Aspose.Slides
description: "Διαχειριστείτε και προσαρμόστε τις διατάξεις διαφανειών στην Aspose.Slides για Android. Εξερευνήστε τους τύπους διατάξεων, τον έλεγχο των πλαισίων κράτησης θέσης και την ορατότητα του υποσέλιδου μέσω παραδειγμάτων κώδικα Java."
---
## **Εισαγωγή**

Μια διάταξη διαφάνειας ορίζει τη διαρρύθμιση των πλαισίων κράτησης θέσης και τη μορφοποίηση του περιεχομένου σε μια διαφάνεια. Ελέγχει ποια πλαίσια είναι διαθέσιμα και πού εμφανίζονται. Οι διατάξεις διαφανειών σας βοηθούν να δημιουργείτε παρουσιάσεις γρήγορα και συνεπώς—είτε δημιουργείτε κάτι απλό είτε πιο σύνθετο. Μερικές από τις πιο κοινές διατάξεις διαφανειών στο PowerPoint περιλαμβάνουν:

**Διάταξη Διαφάνειας Τίτλου** – Περιλαμβάνει δύο πλαίσια κειμένου: ένα για τον τίτλο και ένα για τον υπότιτλο.

**Διάταξη Τίτλου και Περιεχομένου** – Περιλαμβάνει ένα μικρότερο πλαίσιο τίτλου στην κορυφή και ένα μεγαλύτερο από κάτω για το κύριο περιεχόμενο (όπως κείμενο, σημεία με κουκκίδες, γραφήματα, εικόνες και άλλα).

**Κενή Διάταξη** – Δεν περιέχει πλαίσια, δίνοντάς σας πλήρη έλεγχο για το σχεδιασμό της διαφάνειας από το μηδέν.

Οι διατάξεις διαφανειών αποτελούν μέρος ενός κύριου σκίτστου, που είναι η ανώτερη διαφάνεια που ορίζει τα στυλ διάταξης για την παρουσίαση. Μπορείτε να έχετε πρόσβαση και να τροποποιήσετε τις διατάξεις μέσω του κύριου σκίτστου—είτε με βάση τον τύπο, το όνομα ή το μοναδικό ID. Εναλλακτικά, μπορείτε να επεξεργαστείτε μια συγκεκριμένη διάταξη άμεσα μέσα στην παρουσίαση.

Για εργασία με διατάξεις διαφανειών στην Aspose.Slides for Android, μπορείτε να χρησιμοποιήσετε:

- Μεθόδους όπως [getLayoutSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) και [getMasters](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getMasters--) στην κλάση [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) 
- Τύπους όπως [ILayoutSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutplaceholdermanager/), και [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Για να μάθετε περισσότερα σχετικά με τη δουλειά με τις κύριες διαφάνειες, δείτε το άρθρο [Slide Master](/slides/el/androidjava/slide-master/).
{{% /alert %}}

## **Προσθήκη Διατάξεων Διαφανειών σε Παρουσιάσεις**

Για να προσαρμόσετε την εμφάνιση και τη δομή των διαφανειών σας, ίσως χρειαστεί να προσθέσετε νέες διατάξεις σε μια παρουσίαση. Η Aspose.Slides for Android σας επιτρέπει να ελέγξετε αν μια συγκεκριμένη διάταξη υπάρχει ήδη, να προσθέσετε μια νέα εάν χρειάζεται, και να τη χρησιμοποιήσετε για την εισαγωγή διαφανειών βάσει αυτής της διάταξης.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
1. Πρόσβαση στη συλλογή [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imasterlayoutslidecollection/).
1. Ελέγξτε αν η επιθυμητή διάταξη διαφάνειας υπάρχει ήδη στη συλλογή. Εάν όχι, προσθέστε τη διάταξη που χρειάζεστε.
1. Προσθέστε μια κενή διαφάνεια βασισμένη στη νέα διάταξη.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας Java δείχνει πώς να προσθέσετε μια διάταξη διαφάνειας σε μια παρουσίαση PowerPoint:

```java
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Περνάμε από τους τύπους διατάξεων διαφανειών για να επιλέξουμε μια διάταξη διαφάνειας.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // Μια περίπτωση όπου η παρουσίαση δεν περιέχει όλους τους τύπους διατάξεων.
        // Το αρχείο παρουσίασης περιέχει μόνο τύπους διατάξεων Blank και Custom.
        // Ωστόσο, οι διατάξεις διαφανειών με προσαρμοσμένους τύπους μπορεί να έχουν αναγνωρίσιμα ονόματα,
        // όπως "Title", "Title and Content", κ.λπ., που μπορούν να χρησιμοποιηθούν για την επιλογή διάταξης διαφάνειας.
        // Μπορείτε επίσης να βασιστείτε σε ένα σύνολο τύπων σχημάτων placeholder.
        // Για παράδειγμα, μια διαφάνεια Τίτλου πρέπει να έχει μόνο τον τύπο placeholder Title, κ.λπ.
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

    // Προσθήκη κενής διαφάνειας χρησιμοποιώντας τη προστιθέμενη διάταξη διαφάνειας.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Αποθήκευση της παρουσίασης στο δίσκο.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Αφαίρεση Αχρησιμοποίητων Διατάξεων Διαφανειών**

Η Aspose.Slides παρέχει τη μέθοδο [removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) από την κλάση [Compress](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compress/) για να διαγράψετε ανεπιθύμητες και αχρησιμοποίητες διατάξεις διαφανειών.

Ο παρακάτω κώδικας Java δείχνει πώς να αφαιρέσετε μια διάταξη διαφάνειας από μια παρουσίαση PowerPoint:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Προσθήκη Πλαισίων Κράτησης Θέσης στις Διατάξεις Διαφανειών**

Η Aspose.Slides παρέχει τη μέθοδο [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) που επιτρέπει την προσθήκη νέων πλαισίων κράτησης θέσης σε μια διάταξη διαφάνειας.

Αυτός ο διαχειριστής περιέχει μεθόδους για τους ακόλουθους τύπους πλαισίων:

| PowerPoint Placeholder | Μέθοδος [ILayoutPlaceholderManager] |
| ---------------------- | ------------------------------------ |
| ![Περιεχόμενο](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Περιεχόμενο (Κατακόρυφα)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Κείμενο](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Κείμενο (Κατακόρυφα)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Εικόνα](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Διάγραμμα](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Πίνακας](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Μέσα](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Διαδικτυακή Εικόνα](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Ο παρακάτω κώδικας Java δείχνει πώς να προσθέσετε νέα σχήματα πλαισίων σε μια κενή διάταξη διαφάνειας:

```java
Presentation presentation = new Presentation();
try {
    // Λάβετε τη διαφάνεια κενής διάταξης.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Αποκτήστε το διαχειριστή πλαισίων κράτησης θέσης της διαφάνειας διάταξης.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Προσθέστε διαφορετικά πλαίσια κράτησης θέσης στη διαφάνεια κενής διάταξης.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Προσθέστε μια νέα διαφάνεια με την κενή διάταξη.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Τα πλαίσια κράτησης θέσης στη διάταξη διαφάνειας](add_placeholders.png)

## **Ορισμός Ορατότητας Υποσέλιδου για Μια Διάταξη Διαφάνειας**

Σε παρουσιάσεις PowerPoint, στοιχεία υποσέλιδου όπως η ημερομηνία, ο αριθμός διαφάνειας και το προσαρμοσμένο κείμενο μπορούν να εμφανίζονται ή να κρύβονται ανάλογα με τη διάταξη της διαφάνειας. Η Aspose.Slides for Android σας επιτρέπει να ελέγχετε την ορατότητα αυτών των πλαίσια υποσέλιδου. Αυτό είναι χρήσιμο όταν θέλετε ορισμένες διατάξεις να εμφανίζουν πληροφορίες υποσέλιδου ενώ άλλες παραμένουν καθαρές και ελαφριές.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
1. Λάβετε μια αναφορά διάταξης διαφάνειας με βάση το index της.
1. Ορίστε το πλαίσιο υποσέλιδου της διαφάνειας σε ορατό.
1. Ορίστε το πλαίσιο αριθμού διαφάνειας σε ορατό.
1. Ορίστε το πλαίσιο ημερομηνίας/ώρας σε ορατό.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας Java δείχνει πώς να ορίσετε την ορατότητα ενός υποσέλιδου διαφάνειας και να εκτελέσετε σχετικές εργασίες:

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

## **Ορισμός Ορατότητας Υποσέλιδου για Τα Υποδιαμέρισματα μιας Διαφάνειας**

Σε παρουσιάσεις PowerPoint, στοιχεία υποσέλιδου όπως η ημερομηνία, ο αριθμός διαφάνειας και το προσαρμοσμένο κείμενο μπορούν να ελεγχθούν σε επίπεδο κύριας διαφάνειας για να διασφαλιστεί η συνέπεια σε όλες τις διατάξεις. Η Aspose.Slides for Android επιτρέπει τον ορισμό της ορατότητας και του περιεχομένου αυτών των πλαίσια υποσέλιδου στην κύρια διαφάνεια και την προώθηση αυτών των ρυθμίσεων σε όλες τις διατάξεις παιδικών διαφανειών. Αυτή η προσέγγιση εξασφαλίζει ομοιόμορφη πληροφόρηση υποσέλιδου σε όλη την παρουσίαση.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
1. Λάβετε μια αναφορά στην κύρια διαφάνεια με βάση το index της.
1. Ορίστε όλα τα πλαίσια υποσέλιδου της κυρίας και όλων των παιδίων σε ορατό.
1. Ορίστε όλα τα πλαίσια αριθμού διαφάνειας της κυρίας και όλων των παιδίων σε ορατό.
1. Ορίστε όλα τα πλαίσια ημερομηνίας/ώρας της κυρίας και όλων των παιδίων σε ορατό.
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

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ μιας κύριας διαφάνειας και μιας διάταξης διαφάνειας;**

Μια κύρια διαφάνεια ορίζει το συνολικό θέμα και την προεπιλεγμένη μορφοποίηση, ενώ οι διατάξεις διαφανειών καθορίζουν συγκεκριμένες διαρρυθμίσεις πλαισίων για διαφορετικούς τύπους περιεχομένου.

**Μπορώ να αντιγράψω μια διάταξη διαφάνειας από μία παρουσίαση σε άλλη;**

Ναι, μπορείτε να κλωνοποιήσετε μια διάταξη διαφάνειας από τη συλλογή διατάξεων μιας παρουσίασης, προσβάσιμη μέσω της μεθόδου [getLayoutSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getLayoutSlides--), και να την εισάγετε σε άλλη παρουσίαση χρησιμοποιώντας τη μέθοδο `addClone`.

**Τι συμβαίνει αν διαγράψω μια διάταξη διαφάνειας που εξακολουθεί να χρησιμοποιείται από κάποια διαφάνεια;**

Αν προσπαθήσετε να διαγράψετε μια διάταξη διαφάνειας που εξακολουθεί να αναφέρεται από τουλάχιστον μια διαφάνεια στην παρουσίαση, η Aspose.Slides θα ρίξει μια [PptxEditException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pptxeditexception/). Για να το αποφύγετε, χρησιμοποιήστε τη μέθοδο [removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) που αφαιρεί με ασφάλεια μόνο τις διατάξεις που δεν χρησιμοποιούνται.