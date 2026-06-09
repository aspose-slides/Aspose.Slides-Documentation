---
title: Εφαρμογή ή Αλλαγή Διατάξεων Διαφανειών σε PHP
linktitle: Διάταξη Διαφάνειας
type: docs
weight: 60
url: /el/php-java/slide-layout/
keywords:
- διάταξη διαφάνειας
- διάταξη περιεχομένου
- θέση κράτησης
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
- PHP
- Aspose.Slides
description: "Διαχειριστείτε και προσαρμόστε τις διατάξεις διαφανειών στο Aspose.Slides for PHP μέσω Java. Εξερευνήστε τους τύπους διατάξεων, τον έλεγχο των θέσεων κράτησης και την ορατότητα του υποσέλιδου μέσα από παραδείγματα κώδικα."
---
## **Εισαγωγή**

Μια διάταξη διαφάνειας ορίζει τη διάταξη των κουτιών θέσεων κράτησης και τη μορφοποίηση του περιεχομένου σε μια διαφάνεια. Ελέγχει ποιες θέσεις κράτησης είναι διαθέσιμες και πού εμφανίζονται. Οι διατάξεις διαφανειών σας βοηθούν να δημιουργείτε παρουσιάσεις γρήγορα και με συνέπεια — είτε δημιουργείτε κάτι απλό είτε πιο σύνθετο. Μερικές από τις πιο συνηθισμένες διατάξεις διαφανειών στο PowerPoint περιλαμβάνουν:

**Διάταξη Διαφάνειας Τίτλου** – Περιλαμβάνει δύο θέσεις κράτησης κειμένου: μία για τον τίτλο και μία για τον υπότιτλο.

**Διάταξη Τίτλου και Περιεχομένου** – Διαθέτει μια μικρότερη θέση κράτησης τίτλου στην κορυφή και μια μεγαλύτερη κάτω για το κύριο περιεχόμενο (όπως κείμενο, σημεία λίστας, διαγράμματα, εικόνες και άλλα).

**Κενή διάταξη** – Δεν περιέχει θέσεις κράτησης, δίνοντάς σας πλήρη έλεγχο για να σχεδιάσετε τη διαφάνεια από το μηδέν.

Οι διατάξεις διαφανειών είναι μέρος μιας κύριας διαφάνειας, η οποία είναι η διαφάνεια υψηλότερου επιπέδου που ορίζει τα στυλ διάταξης για την παρουσίαση. Μπορείτε να προσπελάσετε και να τροποποιήσετε τις διατάξεις διαφανειών μέσω της κύριας διαφάνειας — είτε με τον τύπο, το όνομα ή το μοναδικό τους αναγνωριστικό. Εναλλακτικά, μπορείτε να επεξεργαστείτε μια συγκεκριμένη διάταξη διαφάνειας άμεσα μέσα στην παρουσίαση.

Για να εργαστείτε με διατάξεις διαφανειών στο Aspose.Slides for PHP, μπορείτε να χρησιμοποιήσετε:

- Μεθόδους όπως [getLayoutSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getLayoutSlides) και [getMasters](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getMasters) στην κλάση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) 
- Τύπους όπως [LayoutSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutplaceholdermanager/), και [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Για να μάθετε περισσότερα σχετικά με τη δουλειά με τις κύριες διαφάνειες, δείτε το άρθρο [Slide Master](/slides/el/php-java/slide-master/).
{{% /alert %}}

## **Προσθήκη Διατάξεων Διαφανειών σε Παρουσιάσεις**

Για να προσαρμόσετε την εμφάνιση και τη δομή των διαφανειών σας, ίσως χρειαστεί να προσθέσετε νέες διατάξεις διαφανειών σε μια παρουσίαση. Το Aspose.Slides for PHP σας επιτρέπει να ελέγξετε αν existe ήδη μια συγκεκριμένη διάταξη, να προσθέσετε μια νέα εάν χρειάζεται, και να τη χρησιμοποιήσετε για την εισαγωγή διαφανειών βάσει εκείνης της διάταξης.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) .
2. Προσπελάστε τη συλλογή [MasterLayoutSlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterlayoutslidecollection/) .
3. Ελέγξτε αν η επιθυμητή διάταξη διαφάνειας υπάρχει ήδη στη συλλογή. Αν όχι, προσθέστε τη διάταξη διαφάνειας που χρειάζεστε.
4. Προσθέστε μια κενή διαφάνεια βασισμένη στη νέα διάταξη διαφάνειας.
5. Αποθηκεύστε την παρουσίαση.

Ο ακόλουθος κώδικας PHP δείχνει πώς να προσθέσετε μια διάταξη διαφάνειας σε μια παρουσίαση PowerPoint:

```php
// Δημιουργία αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint.
$presentation = new Presentation("Sample.pptx");
try {
    // Περιηγηθείτε στους τύπους διατάξεων διαφάνειας για να επιλέξετε μια διάταξη διαφάνειας.
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $layoutSlide = null;
    if (!java_is_null($layoutSlides->getByType(SlideLayoutType::TitleAndObject))) {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);
    } else {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Title);
    }

    if (java_is_null($layoutSlide)) {
        // Μια κατάσταση όπου η παρουσίαση δεν περιέχει όλους τους τύπους διατάξεων.
        // Το αρχείο παρουσίασης περιέχει μόνο τύπους διατάξεων Blank και Custom.
        // Ωστόσο, διατάξεις διαφανειών με προσαρμοσμένους τύπους μπορεί να έχουν αναγνωρίσιμα ονόματα,
        // όπως "Title", "Title and Content", κλπ., που μπορούν να χρησιμοποιηθούν για την επιλογή διάταξης διαφάνειας.
        // Μπορείτε επίσης να βασιστείτε σε ένα σύνολο τύπων σχημάτων θέσεων κράτησης.
        // Για παράδειγμα, μια διαφάνεια τίτλου πρέπει να έχει μόνο τον τύπο θέσης κράτησης Title, κλπ.
        foreach($layoutSlides as $titleAndObjectLayoutSlide) {
            if (java_values($titleAndObjectLayoutSlide->getName()) == "Title and Object") {
                $layoutSlide = $titleAndObjectLayoutSlide;
                break;
            }
        }

        if (java_is_null($layoutSlide)) {
            foreach($layoutSlides as $titleLayoutSlide) {
                if (java_values($titleLayoutSlide->getName()) == "Title") {
                    $layoutSlide = $titleLayoutSlide;
                    break;
                }
            }

            if (java_is_null($layoutSlide)) {
                $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Blank);
                if (java_is_null($layoutSlide)) {
                    $layoutSlide = $layoutSlides->add(SlideLayoutType::TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Προσθήκη κενής διαφάνειας χρησιμοποιώντας τη διαταγή διαφάνειας που προστέθηκε.
    $presentation->getSlides()->insertEmptySlide(0, $layoutSlide);

    // Αποθήκευση της παρουσίασης στο δίσκο.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Κατάργηση Αχρησιμοποίητων Διατάξεων Διαφανειών**

Το Aspose.Slides παρέχει τη μέθοδο [removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) από την κλάση [Compress](https://reference.aspose.com/slides/el/php-java/aspose.slides/compress/) ώστε να μπορείτε να διαγράψετε ανεπιθύμητες και αχρησιμοποίητες διατάξεις διαφανειών.

Ο ακόλουθος κώδικας PHP δείχνει πώς να αφαιρέσετε μια διάταξη διαφάνειας από μια παρουσίαση PowerPoint:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Προσθήκη Θέσεων Κράτησης σε Διατάξεις Διαφανειών**

Το Aspose.Slides παρέχει τη μέθοδο [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslide/#getPlaceholderManager) , η οποία σας επιτρέπει να προσθέτετε νέες θέσεις κράτησης σε μια διάταξη διαφάνειας.

Αυτός ο διαχειριστής περιέχει μεθόδους για τους παρακάτω τύπους θέσεων κράτησης:

| Θέση κράτησης PowerPoint | Μέθοδος [LayoutPlaceholderManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutplaceholdermanager/) |
| ------------------------ | ------------------------------------------------------------ |
| ![Περιεχόμενο](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Περιεχόμενο (Κατακόρυφο)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Κείμενο](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Κείμενο (Κατακόρυφο)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Εικόνα](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Διάγραμμα](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Πίνακας](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Μέσα](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Διαδικτυακή Εικόνα](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Ο ακόλουθος κώδικας PHP δείχνει πώς να προσθέσετε νέα σχήματα θέσης κράτησης στη κενή διάταξη διαφάνειας:

```php
$presentation = new Presentation();
try {
    // Λάβετε τη διαφάνεια διάταξης Blank.
    $layout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // Λάβετε τον διαχειριστή θέσεων κράτησης της διαφάνειας διάταξης.
    $placeholderManager = $layout->getPlaceholderManager();

    // Προσθέστε διαφορετικές θέσεις κράτησης στη διαφάνεια διάταξης Blank.
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    // Προσθέστε μια νέα διαφάνεια με τη διάταξη Blank.
    $newSlide = $presentation->getSlides()->addEmptySlide($layout);

    $presentation->save("Placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Οι θέσεις κράτησης στη διάταξη διαφάνειας](add_placeholders.png)

## **Ορισμός Ορατότητας Υποσέλιδου για Διάταξη Διαφάνειας**

Σε παρουσιάσεις PowerPoint, στοιχεία υποσέλιδου όπως η ημερομηνία, ο αριθμός διαφάνειας και προσαρμοσμένο κείμενο μπορούν να εμφανιστούν ή να κρυφτούν ανάλογα με τη διάταξη διαφάνειας. Το Aspose.Slides for PHP σας επιτρέπει να ελέγξετε την ορατότητα αυτών των θέσεων κράτησης υποσέλιδου. Αυτό είναι χρήσιμο όταν θέλετε ορισμένες διατάξεις να εμφανίζουν πληροφορίες υποσέλιδου ενώ άλλες παραμένουν καθαρές και ελάχιστες.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) .
2. Πάρτε μια αναφορά σε διάταξη διαφάνειας με βάση το δείκτη της.
3. Ορίστε τη θέση κράτησης υποσέλιδου διαφάνειας σε ορατή.
4. Ορίστε τη θέση κράτησης αριθμού διαφάνειας σε ορατή.
5. Ορίστε τη θέση κράτησης ημερομηνίας/ώρας σε ορατή.
6. Αποθηκεύστε την παρουσίαση.

Ο ακόλουθος κώδικας PHP δείχνει πώς να ορίσετε την ορατότητα του υποσέλιδου μιας διαφάνειας και να εκτελέσετε σχετικές ενέργειες:

```php
$presentation = new Presentation("Presentation.ppt");
try {
    $headerFooterManager = $presentation->getLayoutSlides()->get_Item(0)->getHeaderFooterManager();

    if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
    }

    if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
    }

    if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
    }

    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("Presentation.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

## **Ορισμός Ορατότητας Υποσέλιδου για Παιδί Διαφάνειας**

Σε παρουσιάσεις PowerPoint, στοιχεία υποσέλιδου όπως η ημερομηνία, ο αριθμός διαφάνειας και προσαρμοσμένο κείμενο μπορούν να ελεγχθούν σε επίπεδο κύριας διαφάνειας για να διασφαλιστεί η συνέπεια σε όλες τις διατάξεις διαφανειών. Το Aspose.Slides for PHP επιτρέπει να ορίσετε την ορατότητα και το περιεχόμενο αυτών των θέσεων κράτησης υποσέλιδου στην κύρια διαφάνεια και να προβάλετε αυτές τις ρυθμίσεις σε όλες τις παιδικές διατάξεις διαφανειών. Αυτή η προσέγγιση εξασφαλίζει ομοιόμορφη πληροφορία υποσέλιδου σε όλη την παρουσίαση.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) .
2. Πάρτε μια αναφορά στη κύρια διαφάνεια με βάση το δείκτη της.
3. Ορίστε τις θέσεις κράτησης υποσέλιδου της κύριας και όλων των παιδικών διαφανειών σε ορατές.
4. Ορίστε τις θέσεις κράτησης αριθμού διαφάνειας της κύριας και όλων των παιδικών διαφανειών σε ορατές.
5. Ορίστε τις θέσεις κράτησης ημερομηνίας/ώρας της κύριας και όλων των παιδικών διαφανειών σε ορατές.
6. Αποθηκεύστε την παρουσίαση.

Ο ακόλουθος κώδικας PHP δείχνει αυτή τη λειτουργία:

```php
$presentation = new Presentation("presentation.ppt");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();

    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ μιας κύριας διαφάνειας και μιας διάταξης διαφάνειας;**

Μια κύρια διαφάνεια ορίζει το συνολικό θέμα και την προεπιλεγμένη μορφοποίηση, ενώ οι διατάξεις διαφανειών ορίζουν συγκεκριμένες διατάξεις θέσεων κράτησης για διάφορους τύπους περιεχομένου.

**Μπορώ να αντιγράψω μια διάταξη διαφάνειας από μία παρουσίαση σε άλλη;**

Ναι, μπορείτε να κλωνοποιήσετε μια διάταξη διαφάνειας από τη συλλογή διατάξεων μιας παρουσίασης, προσβάσιμη μέσω της μεθόδου [getLayoutSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getLayoutSlides) , και να την εισάγετε σε άλλη παρουσίαση χρησιμοποιώντας τη μέθοδο `addClone`.

**Τι συμβαίνει αν διαγράψω μια διάταξη διαφάνειας που χρησιμοποιείται ακόμα από κάποια διαφάνεια;**

Αν προσπαθήσετε να διαγράψετε μια διάταξη διαφάνειας που είναι ακόμα αναφορά από τουλάχιστον μία διαφάνεια στην παρουσίαση, το Aspose.Slides θα ρίξει μια [PptxEditException](https://reference.aspose.com/slides/el/php-java/aspose.slides/pptxeditexception/) . Για να το αποφύγετε, χρησιμοποιήστε [removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) που αφαιρεί με ασφάλεια μόνο τις διατάξεις που δεν χρησιμοποιούνται.