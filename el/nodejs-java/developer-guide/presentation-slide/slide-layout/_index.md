---
title: Εφαρμογή ή Αλλαγή Διατάξεων Διαφάνειας σε JavaScript
linktitle: Διάταξη Διαφάνειας
type: docs
weight: 60
url: /el/nodejs-java/slide-layout/
keywords:
- διάταξη διαφάνειας
- διάταξη περιεχομένου
- πλαίσιο κράτησης θέσης
- σχεδιασμός παρουσίασης
- σχεδιασμός διαφάνειας
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαχειριστείτε και προσαρμόστε τις διατάξεις διαφάνειας στο Aspose.Slides για Node.js. Εξερευνήστε τύπους διατάξεων, έλεγχο πλαισίων κράτησης θέσης και ορατότητα υποσέλιδου μέσω παραδειγμάτων κώδικα."
---
## **Εισαγωγή**

Μια διάταξη διαφάνειας ορίζει τη διάταξη των πλαισίων κράτησης θέσης και τη μορφοποίηση του περιεχομένου σε μια διαφάνεια. Ελέγχει ποια πλαίσια κράτησης θέσης είναι διαθέσιμα και πού εμφανίζονται. Οι διατάξεις διαφάνειας σας βοηθούν να δημιουργείτε παρουσιάσεις γρήγορα και με συνέπεια — είτε δημιουργείτε κάτι απλό είτε πιο πολύπλοκο. Μερικές από τις πιο κοινές διατάξεις διαφάνειας στο PowerPoint περιλαμβάνουν:

**Διάταξη Τίτλου Διαφάνειας** – Περιλαμβάνει δύο πλαίσια κειμένου: ένα για τον τίτλο και ένα για τον υπότιτλο.

**Διάταξη Τίτλου και Περιεχομένου** – Περιλαμβάνει ένα μικρότερο πλαίσιο τίτλου στην κορυφή και ένα μεγαλύτερο κάτω για το κύριο περιεχόμενο (όπως κείμενο, σημεία λίστας, γραφήματα, εικόνες κλπ).

**Κενή διάταξη** – Δεν περιέχει πλαίσια κράτησης θέσης, δίνοντάς σας πλήρη έλεγχο για να σχεδιάσετε τη διαφάνεια από το μηδέν.

Οι διατάξεις διαφάνειας αποτελούν μέρος ενός κύριου σλάιδος, που είναι η ανώτατη διαφάνεια η οποία ορίζει τα στυλ διάταξης για την παρουσίαση. Μπορείτε να έχετε πρόσβαση και να τροποποιήσετε τις διατάξεις διαφάνειας μέσω του κύριου σλάιδος — είτε με βάση τον τύπο, το όνομα ή το μοναδικό ID. Εναλλακτικά, μπορείτε να επεξεργαστείτε μια συγκεκριμένη διάταξη διαφάνειας απευθείας μέσα στην παρουσίαση.

Για να εργαστείτε με διατάξεις διαφάνειας στο Aspose.Slides for Node.js, μπορείτε να χρησιμοποιήσετε:

- Μέθοδοι όπως [getLayoutSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#getLayoutSlides) και [getMasters](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#getMasters) στην κλάση [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/)
- Τύποι όπως [LayoutSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutplaceholdermanager/), και [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Για να μάθετε περισσότερα σχετικά με τη δουλειά με τις κύριες διαφάνειες, δείτε το άρθρο [Slide Master](/slides/el/nodejs-java/slide-master/).
{{% /alert %}}

## **Προσθήκη Διατάξεων Διαφάνειας σε Παρουσιάσεις**

Για να προσαρμόσετε την εμφάνιση και τη δομή των διαφανειών σας, μπορεί να χρειαστεί να προσθέσετε νέες διατάξεις διαφάνειας σε μια παρουσίαση. Το Aspose.Slides for Node.js σας επιτρέπει να ελέγξετε εάν υπάρχει ήδη μια συγκεκριμένη διάταξη, να προσθέσετε μια νέα εάν χρειάζεται, και να τη χρησιμοποιήσετε για να εισάγετε διαφάνειες βασισμένες σε αυτήν τη διάταξη.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
1. Προσπελάστε τη [MasterLayoutSlideCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterlayoutslidecollection/).
1. Ελέγξτε εάν η επιθυμητή διάταξη διαφάνειας υπάρχει ήδη στη συλλογή. Εάν όχι, προσθέστε τη διάταξη διαφάνειας που χρειάζεστε.
1. Προσθέστε μια κενή διαφάνεια βασισμένη στην νέα διάταξη διαφάνειας.
1. Αποθηκεύστε την παρουσίαση.

```js
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Περάστε από τους τύπους διατάξεων διαφάνειας για να επιλέξετε μια διάταξη διαφάνειας.
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let layoutSlide = null;
    if (layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject)) != null) {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    } else {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Title));
    }

    if (layoutSlide == null) {
        // Μια κατάσταση όπου η παρουσίαση δεν περιέχει όλους τους τύπους διατάξεων.
        // Το αρχείο παρουσίασης περιέχει μόνο τύπους διατάξεων Blank και Custom.
        // Ωστόσο, οι διατάξεις διαφάνειας με προσαρμοσμένους τύπους μπορεί να έχουν αναγνωρίσιμα ονόματα,
        // όπως "Title", "Title and Content", κλπ., τα οποία μπορούν να χρησιμοποιηθούν για επιλογή διάταξης διαφάνειας.
        // Μπορείτε επίσης να βασιστείτε σε ένα σύνολο τύπων placeholder shape.
        // Για παράδειγμα, μια διαφάνεια τίτλου πρέπει να έχει μόνο τον τύπο placeholder Title, κλπ.
        for (let i = 0; i < layoutSlides.size(); i++) {
            let titleAndObjectLayoutSlide = layoutSlides.get_Item(i);
            if (titleAndObjectLayoutSlide.getName() === "Title and Object") {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (let i = 0; i < layoutSlides.size(); i++) {
                let titleLayoutSlide = layoutSlides.get_Item(i);
                if (titleLayoutSlide.getName() === "Title") {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject), "Title and Object");
                }
            }
        }
    }

    // Προσθέστε μια κενή διαφάνεια χρησιμοποιώντας τη διάταξη διαφάνειας που προστέθηκε.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Αφαίρεση Μη Χρησιμοποιούμενων Διατάξεων Διαφάνειας**

Το Aspose.Slides παρέχει τη μέθοδο [removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) από την κλάση [Compress](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compress/) ώστε να μπορείτε να διαγράψετε ανεπιθύμητες και μη χρησιμοποιούμενες διατάξεις διαφάνειας.

Ο παρακάτω κώδικας JavaScript δείχνει πώς να αφαιρέσετε μια διάταξη διαφάνειας από μια παρουσίαση PowerPoint:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Προσθήκη Πλαισίων Κράτησης Θέσης στις Διατάξεις Διαφάνειας**

Το Aspose.Slides παρέχει τη μέθοδο [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) η οποία σας επιτρέπει να προσθέσετε νέα πλαίσια κράτησης θέσης σε μια διάταξη διαφάνειας.

Αυτός ο διαχειριστής περιέχει μεθόδους για τους ακόλουθους τύπους πλαισίων κράτησης θέσης:

| Πλαίσιο Κράτησης Θέσης PowerPoint | [LayoutPlaceholderManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutplaceholdermanager/) Μέθοδος |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Περιεχόμενο](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Περιεχόμενο (Κατακόρυφο)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Κείμενο](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Κείμενο (Κατακόρυφο)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Εικόνα](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Διάγραμμα](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Πίνακας](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Διαδικτυακή Εικόνα](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Ο παρακάτω κώδικας JavaScript δείχνει πώς να προσθέσετε νέες μορφές πλαισίων κράτησης θέσης στη κενή διάταξη διαφάνειας:

```js
let presentation = new aspose.slides.Presentation();
try {
    // Λάβετε τη κενή διάταξη διαφάνειας.
    let layout = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));

    // Λάβετε τον διαχειριστή placeholders της διάταξης διαφάνειας.
    let placeholderManager = layout.getPlaceholderManager();

    // Προσθέστε διαφορετικά placeholders στη κενή διάταξη διαφάνειας.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Προσθέστε μια νέα διαφάνεια με την κενή διάταξη.
    let newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Τα πλαίσια κράτησης θέσης στη διάταξη διαφάνειας](add_placeholders.png)

## **Ορισμός Ορατότητας Υποσέλιδου για Διάταξη Διαφάνειας**

Σε παρουσιάσεις PowerPoint, τα στοιχεία υποσέλιδου όπως η ημερομηνία, ο αριθμός διαφάνειας και το προσαρμοσμένο κείμενο μπορούν να εμφανιστούν ή να κρυφτούν ανάλογα με τη διάταξη της διαφάνειας. Το Aspose.Slides for Node.js σας επιτρέπει να ελέγξετε την ορατότητα αυτών των πλαισίων υποσέλιδου. Αυτό είναι χρήσιμο όταν θέλετε ορισμένες διατάξεις να εμφανίζουν πληροφορίες υποσέλιδου ενώ άλλες παραμένουν καθαρές και ελάχιστες.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
1. Πάρτε μια αναφορά διάταξης διαφάνειας με βάση το δείκτη της.
1. Ορίστε το πλαίσιο υποσέλιδου της διαφάνειας σε ορατό.
1. Ορίστε το πλαίσιο αριθμού διαφάνειας σε ορατό.
1. Ορίστε το πλαίσιο ημερομηνίας/ώρας σε ορατό.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας JavaScript δείχνει πώς να ορίσετε την ορατότητα ενός υποσέλιδου διαφάνειας και να εκτελέσετε σχετικές εργασίες:

```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

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

    presentation.save("Presentation.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Ορατότητας Υποσέλιδου σε Καταγόμενη Διάταξη**

Σε παρουσιάσεις PowerPoint, τα στοιχεία υποσέλιδου όπως η ημερομηνία, ο αριθμός διαφάνειας και το προσαρμοσμένο κείμενο μπορούν να ελεγχθούν στο επίπεδο της κύριας διαφάνειας ώστε να διασφαλιστεί η συνέπεια σε όλες τις διατάξεις διαφάνειας. Το Aspose.Slides for Node.js σάς επιτρέπει να ορίσετε την ορατότητα και το περιεχόμενο αυτών των πλαισίων υποσέλιδου στη κύρια διαφάνεια και να διαδώσετε αυτές τις ρυθμίσεις σε όλες τις καταγόμενες διατάξεις διαφάνειας. Αυτή η προσέγγιση διασφαλίζει ομοιόμορφη πληροφόρηση υποσέλιδου σε όλη την παρουσίαση.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
1. Πάρτε μια αναφορά στη κύρια διαφάνεια με βάση το δείκτη της.
1. Ορίστε τα πλαίσια υποσέλιδου της κύριας διαφάνειας και όλων των καταγόμενων σε ορατό.
1. Ορίστε τα πλαίσια αριθμού διαφάνειας της κύριας διαφάνειας και όλων των καταγόμενων σε ορατό.
1. Ορίστε τα πλαίσια ημερομηνίας/ώρας της κύριας διαφάνειας και όλων των καταγόμενων σε ορατό.
1. Αποθηκεύστε την παρουσίαση.

```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Ποια είναι η διαφορά μεταξύ κύριας διαφάνειας και διάταξης διαφάνειας;**

Μια κύρια διαφάνεια ορίζει το γενικό θέμα και τη προεπιλεγμένη μορφοποίηση, ενώ οι διατάξεις διαφάνειας ορίζουν συγκεκριμένες διατάξεις πλαισίων κράτησης θέσης για διαφορετικούς τύπους περιεχομένου.

**Μπορώ να αντιγράψω μια διάταξη διαφάνειας από μια παρουσίαση σε άλλη;**

Ναι, μπορείτε να κλωνοποιήσετε μια διάταξη διαφάνειας από τη συλλογή διατάξεων διαφάνειας μιας παρουσίασης, η οποία είναι προσβάσιμη μέσω της μεθόδου [getLayoutSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#getLayoutSlides), και να την εισάγετε σε άλλη παρουσίαση χρησιμοποιώντας τη μέθοδο `addClone`.

**Τι συμβαίνει αν διαγράψω μια διάταξη διαφάνειας που χρησιμοποιείται ακόμα από κάποια διαφάνεια;**

Εάν προσπαθήσετε να διαγράψετε μια διάταξη διαφάνειας που παραπέρεται ακόμη από τουλάχιστον μία διαφάνεια στην παρουσίαση, το Aspose.Slides θα ρίξει ένα [PptxEditException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pptxeditexception/). Για να το αποφύγετε, χρησιμοποιήστε τη μέθοδο [removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides), η οποία αφαιρεί με ασφάλεια μόνο τις διατάξεις διαφάνειας που δεν χρησιμοποιούνται.