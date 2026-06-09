---
title: Προηγμένη Εξαγωγή Κειμένου από Παρουσιάσεις σε PHP
linktitle: Εξαγωγή Κειμένου
type: docs
weight: 90
url: /el/php-java/extract-text-from-presentation/
keywords:
- εξαγωγή κειμένου
- εξαγωγή κειμένου από διαφάνεια
- εξαγωγή κειμένου από παρουσίαση
- εξαγωγή κειμένου από PowerPoint
- εξαγωγή κειμένου από OpenDocument
- εξαγωγή κειμένου από PPT
- εξαγωγή κειμένου από PPTX
- εξαγωγή κειμένου από ODP
- ανάκτηση κειμένου
- ανάκτηση κειμένου από διαφάνεια
- ανάκτηση κειμένου από παρουσίαση
- ανάκτηση κειμένου από PowerPoint
- ανάκτηση κειμένου από OpenDocument
- ανάκτηση κειμένου από PPT
- ανάκτηση κειμένου από PPTX
- ανάκτηση κειμένου από ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Εξάγετε γρήγορα κείμενο από παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java. Ακολουθήστε τον απλό, βήμα-προς-βήμα οδηγό μας για εξοικονόμηση χρόνου."
---
## **Επισκόπηση**

Η εξαγωγή κειμένου από παρουσιάσεις είναι μια κοινή αλλά απαραίτητη εργασία για προγραμματιστές που εργάζονται με περιεχόμενο διαφανειών. Είτε χειρίζεστε αρχεία Microsoft PowerPoint σε μορφή PPT ή PPTX, είτε παρουσιάσεις OpenDocument (ODP), η πρόσβαση και η ανάκτηση δεδομένων κειμένου μπορεί να είναι κρίσιμη για ανάλυση, αυτοματοποίηση, ευρετηρίαση ή σκοπούς μετεγκατάστασης περιεχομένου.

Αυτό το άρθρο παρέχει έναν ολοκληρωμένο οδηγό για το πώς να εξάγετε αποδοτικά κείμενο από διάφορες μορφές παρουσιάσεων, συμπεριλαμβανομένων των PPT, PPTX και ODP, χρησιμοποιώντας το Aspose.Slides for PHP via Java. Θα μάθετε πώς να διασχίζετε συστηματικά τα στοιχεία της παρουσίασης για να ανακτήσετε με ακρίβεια το κείμενο που χρειάζεστε.

## **Εξαγωγή Κειμένου από Διαφάνεια**

Το Aspose.Slides for PHP via Java παρέχει την κλάση [SlideUtil](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideutil/) . Η κλάση αυτή εκθέτει πολλές υπερφορτωμένες στατικές μεθόδους για την εξαγωγή όλου του κειμένου από μια παρουσίαση ή διαφάνεια. Για να εξάγετε κείμενο από μια διαφάνεια σε παρουσίαση, χρησιμοποιήστε τη μέθοδο [getAllTextBoxes](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideutil/#getAllTextBoxes) . Αυτή η μέθοδος δέχεται ένα αντικείμενο τύπου [BaseSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseslide/) ως παράμετρο. Όταν εκτελεστεί, η μέθοδος σαρώνει ολόκληρη τη διαφάνεια για κείμενο και επιστρέφει έναν πίνακα αντικειμένων τύπου [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) , διατηρώντας τυχόν μορφοποίηση κειμένου.

Το παρακάτω απόσπασμα κώδικα εξάγει όλο το κείμενο από την πρώτη διαφάνεια της παρουσίασης:

```php
$slideIndex = 0;

$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $slide = $presentation->getSlides()->get_Item($slideIndex);

    $textFrames = SlideUtil::getAllTextBoxes($slide);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Εξαγωγή Κειμένου από Παρουσίαση**

Για να σαρώσετε κείμενο σε ολόκληρη την παρουσίαση, χρησιμοποιήστε τη στατική μέθοδο [getAllTextFrames](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideutil/#getAllTextFrames) που εκτίθεται από την κλάση [SlideUtil](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideutil/) . Δέχεται δύο παραμέτρους:

1. Πρώτα, ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) που αντιπροσωπεύει μια παρουσίαση PowerPoint ή OpenDocument από την οποία θα εξαχθεί το κείμενο.
2. Δεύτερα, μια τιμή `boolean` που υποδεικνύει εάν οι κύριες διαφάνειες (master slides) πρέπει να συμπεριληφθούν κατά τη σάρωση του κειμένου στην παρουσίαση.

Η μέθοδος επιστρέφει έναν πίνακα αντικειμένων τύπου [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) , περιλαμβάνοντας πληροφορίες μορφοποίησης κειμένου. Ο παρακάτω κώδικας σαρώει το κείμενο και τις λεπτομέρειες μορφοποίησης από μια παρουσίαση, συμπεριλαμβανομένων των κύριων διαφανειών.

```php
$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $includeMasterSlides = true;
    $textFrames = SlideUtil::getAllTextFrames($presentation, $includeMasterSlides);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Κατηγοριοποιημένη και Γρήγορη Εξαγωγή Κειμένου**

Η κλάση [PresentationFactory](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationfactory/) παρέχει επίσης μεθόδους για την εξαγωγή όλου του κειμένου από παρουσιάσεις:

```php
PresentationText getPresentationText(String, int);
PresentationText getPresentationText(InputStream, int);
PresentationText getPresentationText(InputStream, int, LoadOptions);
```

Το όρισμα enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/el/php-java/aspose.slides/textextractionarrangingmode/) υποδεικνύει τη λειτουργία για την οργάνωση του αποτελέσματος εξαγωγής κειμένου και μπορεί να οριστεί στις ακόλουθες τιμές:
- `Unarranged` - Το ακατέργαστο κείμενο χωρίς λόγο για τη θέση του στη διαφάνεια.
- `Arranged` - Το κείμενο είναι οργανωμένο στην ίδια σειρά όπως στη διαφάνεια.

Η λειτουργία Unarranged μπορεί να χρησιμοποιηθεί όταν η ταχύτητα είναι κρίσιμη· είναι ταχύτερη από τη λειτουργία Arranged.

Το [PresentationText](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationtext/) αντιπροσωπεύει το ακατέργαστο κείμενο που εξάγεται από την παρουσίαση. Η μέθοδός του `getSlidesText` επιστρέφει έναν πίνακα αντικειμένων όπου κάθε αντικείμενο αντιπροσωπεύει το κείμενο στην αντίστοιχη διαφάνεια. Κάθε επιστρεφόμενο αντικείμενο διαθέτει τις ακόλουθες μεθόδους:

- `getText` - Το κείμενο μέσα στα σχήματα της διαφάνειας.
- `getMasterText` - Το κείμενο μέσα στα σχήματα της κύριας διαφάνειας (master) που σχετίζονται με αυτή τη διαφάνεια.
- `getLayoutText` - Το κείμενο μέσα στα σχήματα της διάταξης (layout) που σχετίζονται με αυτή τη διαφάνεια.
- `getNotesText` - Το κείμενο μέσα στα σχήματα της διαφάνειας σημειώσεων που σχετίζονται με αυτή τη διαφάνεια.
- `getCommentsText` - Το κείμενο μέσα σε σχόλια που σχετίζονται με αυτή τη διαφάνεια.

```php
$presentationPath = "presentation.ppt";
$arrangingMode = TextExtractionArrangingMode::Unarranged;
$presentationText = PresentationFactory::getInstance()->getPresentationText($presentationPath, $arrangingMode);
$slidesText = $presentationText->getSlidesText();
$firstSlideText = $slidesText[0];

echo($firstSlideText->getText());
echo($firstSlideText->getLayoutText());
echo($firstSlideText->getMasterText());
echo($firstSlideText->getNotesText());
echo($firstSlideText->getCommentsText());
```

## **Συχνές Ερωτήσεις**

**Πόσο γρήγορα επεξεργάζεται το Aspose.Slides μεγάλες παρουσιάσεις κατά την εξαγωγή κειμένου;**

Το Aspose.Slides είναι βελτιστοποιημένο για υψηλή απόδοση και μπορεί να επεξεργαστεί ακόμη και [μεγάλες παρουσιάσεις](/slides/el/php-java/open-presentation/), καθιστώντας το κατάλληλο για σεναρίων σε πραγματικό χρόνο ή μαζικής επεξεργασίας.

**Μπορεί το Aspose.Slides να εξάγει κείμενο από πίνακες και διαγράμματα μέσα σε παρουσιάσεις;**

Ναι. Το Aspose.Slides μπορεί να εξάγει κείμενο από πολλά στοιχεία διαφάνειας, συμπεριλαμβανομένων πινάκων και αντικειμένων σχετικών με διαγράμματα, ώστε να μπορείτε να έχετε πρόσβαση και να αναλύετε το κειμενικό περιεχόμενο σε κοινές δομές παρουσίασης.

**Χρειάζομαι ειδική άδεια Aspose.Slides για την εξαγωγή κειμένου από παρουσιάσεις;**

Μπορείτε να εξάγετε κείμενο χρησιμοποιώντας τη δωρεάν δοκιμαστική έκδοση του Aspose.Slides, αν και θα έχει [ορισμένους περιορισμούς](/slides/el/php-java/licensing/), όπως η επεξεργασία μόνο ενός περιορισμένου αριθμού διαφανειών. Για απεριόριστη χρήση και για την επεξεργασία μεγαλύτερων παρουσιάσεων, συνιστάται η αγορά πλήρους άδειας.