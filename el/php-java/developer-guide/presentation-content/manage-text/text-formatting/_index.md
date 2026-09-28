---
title: Μορφοποίηση κειμένου παρουσίασης σε PHP
linktitle: Μορφοποίηση κειμένου
type: docs
weight: 50
url: /el/php-java/text-formatting/
keywords:
- στοίχιση παραγράφου
- στυλ κειμένου
- φόντο κειμένου
- διαφάνεια κειμένου
- διάστημα χαρακτήρων
- ιδιότητες γραμματοσειράς
- οικογένεια γραμματοσειράς
- περιστροφή κειμένου
- γωνία περιστροφής
- πλαίσιο κειμένου
- διάστημα γραμμής
- ιδιότητα αυτόματης προσαρμογής
- άγκυρα πλαισίου κειμένου
- καρτέλες κειμένου
- προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μορφοποίηση και στυλιζάρισμα κειμένου σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java. Προσαρμόστε τις γραμματοσειρές, τα χρώματα, την στοίχιση και άλλα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να μορφοποιήσετε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java. Καλύπτει χρώματα φόντου, διαφάνεια, απόσταση χαρακτήρων, ιδιότητες γραμματοσειράς, περιστροφή, απόσταση παραγράφων, συμπεριφορά αυτόματης προσαρμογής, αγκύρωση κειμένου, διαστήματα στηλοθέτη και ρυθμίσεις γλώσσας.

Εκτός αν αναφέρεται διαφορετικά, τα παραδείγματα χρησιμοποιούν [sample.pptx](sample.pptx). Το πρώτο σχήμα στην πρώτη διαφάνειά του είναι ένα πλαίσιο κειμένου και η πρώτη του παράγραφος περιέχει το κείμενο που φαίνεται παρακάτω. Οι αριθμοί διαφάνειας και σχήματος είναι μηδενικής βάσης. Τα παραδείγματα που επιλέγουν έντονα τμήματα χρησιμοποιούν αποτελεσματική μορφοποίηση, συμπεριλαμβανομένης της κληθείσας έντονης μορφοποίησης:

![Δείγμα κειμένου](sample_text.png)

Για να βρείτε και να επισημάνετε κυριολεκτικό κείμενο ή αντιστοιχίες κανονικών εκφράσεων, δείτε [Αναζήτηση και Αντικατάσταση Κειμένου](/slides/el/php-java/search-and-replace-text/).

## **Ορισμός Χρώματος Φόντου Κειμένου**

Χρησιμοποιήστε [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) για να ορίσετε το προεπιλεγμένο χρώμα επισήμανσης για μια παράγραφο ή χρησιμοποιήστε [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#getHighlightColor) για μεμονωμένα τμήματα κειμένου.

Το παρακάτω παράδειγμα ορίζει ένα ανοιχτό γκρι χρώμα επισήμανσης ως προεπιλογή για την πρώτη παράγραφο. Τα ρητά χρώματα επισήμανσης σε μεμονωμένα τμήματα έχουν προτεραιότητα έναντι αυτής της προεπιλογής:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // Ορίστε το χρώμα επισήμανσης για ολόκληρη την παράγραφο.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Η γκρι παράγραφος](gray_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε το χρώμα φόντου για **τμήματα κειμένου με έντονη γραμματοσειρά**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // Ορίστε το χρώμα επισήμανσης για το τμήμα κειμένου.
            $portion->getPortionFormat()->getHighlightColor()->setColor($highlightColor);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Τα γκρι τμήματα κειμένου](gray_text_portions.png)

## **Στοίχιση Παραγράφων Κειμένου**

Χρησιμοποιήστε [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#setAlignment) για να ορίσετε την στοίχιση παραγράφων μέσα σε ένα πλαίσιο κειμένου. Η τιμή μπορεί να είναι κεντραρισμένη, αριστερή, δεξιά, στοιχισμένη (justify) κ.λπ.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να στοιχίσετε την παράγραφο στο **κέντρο**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Ορίστε τη στοίχιση της παραγράφου στο κέντρο.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Η στοιχισμένη παράγραφος](aligned_paragraph.png)

## **Ορισμός Διαφάνειας για Κείμενο**

Η διαφάνεια του κειμένου ελέγχεται μέσω του αλφα‑συστατικού του χρώματος που έχει ανατεθεί στο [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#getFillFormat). Σ τα παραδείγματα παρακάτω, `alpha = 50` είναι μια τιμή καναλιού αλφα ARGB στην κλίμακα 0–255, όχι ποσοστό διαφάνειας.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια στην **ολόκληρη παράγραφο**:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // Ορίστε το χρώμα γεμίσματος του κειμένου σε διαφανές χρώμα.
    $fillFormat->setFillType(FillType::Solid);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);
    $fillFormat->getSolidFillColor()->setColor($transparentColor);

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Η διαφανής παράγραφος](transparent_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια σε **τμήματα κειμένου με έντονη γραμματοσειρά**:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // Ορίστε τη διαφάνεια του τμήματος κειμένου.
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor($transparentColor);
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Τα διαφανή τμήματα κειμένου](transparent_text_portions.png)

## **Ορισμός Διαστημάτων Χαρακτήρων για Κείμενο**

Χρησιμοποιήστε [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setSpacing) για να αυξήσετε ή να μειώσετε το διάστημα μεταξύ χαρακτήρων σε ένα πλαίσιο κειμένου. Τα παραδείγματα προσθέτουν 3 σημεία διαστήματος· οι αρνητικές τιμές μειώνουν το κείμενο.

Ο παρακάτω κώδικας PHP δείχνει πώς να αυξήσετε το διάστημα χαρακτήρων στην **ολόκληρη παράγραφο**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε το διάστημα χαρακτήρων.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Αυξήστε το διάστημα χαρακτήρων.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το διάστημα χαρακτήρων στην παράγραφο](character_spacing_in_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να αυξήσετε το διάστημα χαρακτήρων σε **τμήματα κειμένου με έντονη γραμματοσειρά**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε το διάστημα χαρακτήρων.
            $portion->getPortionFormat()->setSpacing(3); // Αυξήστε το διάστημα χαρακτήρων.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το διάστημα χαρακτήρων στα τμήματα κειμένου](character_spacing_in_text_portions.png)

### **Απενεργοποίηση kerning για συγκεκριμένες γραμματοσειρές**

Σε ορισμένες περιπτώσεις, το κείμενο που αποδίδεται από το Aspose.Slides μπορεί να φαίνεται ελαφρώς πιο συμπαγές από το ίδιο κείμενο που εμφανίζεται στο PowerPoint. Αυτό μπορεί να συμβαίνει επειδή το PowerPoint μπορεί να αγνοεί τα δεδομένα kerning για ορισμένες γραμματοσειρές, ακόμη και όταν η γραμματοσειρά περιέχει έγκυρες πληροφορίες kerning και το kerning είναι ενεργοποιημένο στις ρυθμίσεις του PowerPoint.

Για να φέρετε το παραγόμενο αποτέλεσμα πιο κοντά στο PowerPoint σε τέτοιες περιπτώσεις, μπορείτε να απενεργοποιήσετε το kerning για τμήματα κειμένου που χρησιμοποιούν την επηρεαζόμενη γραμματοσειρά. Ορίστε [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) σε μια τιμή μεγαλύτερη από το πραγματικό μέγεθος της γραμματοσειράς. Αυτό το παράδειγμα απαιτεί το «presentation.pptx» με ένα πλαίσιο κειμένου ως το πρώτο σχήμα στην πρώτη διαφάνεια. Ελέγχει τα αποτελεσματικά ονόματα γραμματοσειρών, συμπεριλαμβανομένων των κλημένων γραμματοσειρών, και ορίζει ένα όριο 100 σημείων για τμήματα που χρησιμοποιούν το Roboto. Αυτό απενεργοποιεί το kerning για τα ταιριαστά τμήματα με μέγεθος γραμματοσειράς κάτω από 100 σημεία:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $targetFont = "Roboto";

    $paragraphCount = java_values($autoShape->getTextFrame()->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portionFormat = $portion->getPortionFormat()->getEffective();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portion->getPortionFormat()->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Για κείμενο που ταιριάζει κάτω από το όριο, αυτή η ρύθμιση αποτρέπει το kerning και μπορεί να βοηθήσει να ευθυγραμμιστεί η απόδοση του Aspose.Slides με την οπτική έξοδο του PowerPoint για γραμματοσειρές που επηρεάζονται από αυτή τη συμπεριφορά συγκεκριμένη στο PowerPoint.

## **Διαχείριση Ιδιοτήτων Γραμματοσειράς Κειμένου**

Οι ιδιότητες γραμματοσειράς μπορούν να οριστούν σε επίπεδο παραγράφου μέσω του [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) ή σε μεμονωμένα τμήματα μέσω του [PortionFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/portionformat/).

Το παρακάτω παράδειγμα ορίζει τη προεπιλεγμένη γραμματοσειρά της πρώτης παραγράφου σε Times New Roman 12 σημείων με έντονη, πλάγια και διακριτή υπογράμμιση. Η ρητή μορφοποίηση σε μεμονωμένα τμήματα έχει προτεραιότητα έναντι αυτών των προεπιλογών:

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $font = new FontData("Times New Roman");

    // Ορίστε τις ιδιότητες γραμματοσειράς για την παράγραφο.
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont($font);

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Οι ιδιότητες γραμματοσειράς για την παράγραφο](font_properties_for_paragraph.png)

Το παρακάτω παράδειγμα εφαρμόζει Times New Roman 13 σημείων, πλάγια μορφοποίηση και διακριτή υπογράμμιση σε τμήματα των οποίων η αποτελεσματική μορφοποίηση είναι έντονη:

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // Ορίστε τις ιδιότητες γραμματοσειράς για το τμήμα κειμένου.
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont($font);
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Οι ιδιότητες γραμματοσειράς για τα τμήματα κειμένου](font_properties_for_text_portions.png)

## **Ορισμός Περιστροφής Κειμένου**

Χρησιμοποιήστε [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/#setTextVerticalType) για να ορίσετε μια προκαθορισμένη προσανατολισμό κειμένου μέσα σε ένα σχήμα.

Το παρακάτω παράδειγμα κώδικα ορίζει τον προσανατολισμό του κειμένου στο σχήμα σε [TextVerticalType::Vertical270](https://reference.aspose.com/slides/el/php-java/aspose.slides/textverticaltype/), που περιστρέφει το κείμενο **90 μοίρες αριστερόστροφα**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Η περιστροφή κειμένου](text_rotation.png)

## **Ορισμός Προσαρμοσμένης Περιστροφής για Πλαίσια Κειμένου**

Χρησιμοποιήστε [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/#setRotationAngle) για να ορίσετε μια προσαρμοσμένη γωνία περιστροφής για ένα [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/).

Το παρακάτω παράδειγμα κώδικα περιστρέφει το πλαίσιο κειμένου κατά 3 μοίρες δεξιόστροφα μέσα στο σχήμα:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Η προσαρμοσμένη περιστροφή κειμένου](custom_text_rotation.png)

## **Ορισμός Διαστήματος Γραμμής για Παραγράφους**

Το Aspose.Slides παρέχει τα [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#setSpaceBefore), και [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#setSpaceWithin) για να ελέγχει το διάστημα παραγράφων. Αυτές οι ιδιότητες χρησιμοποιούνται ως εξής:

* Χρησιμοποιήστε μια θετική τιμή για να καθορίσετε το διάστημα γραμμής ως ποσοστό του ύψους της γραμμής.
* Χρησιμοποιήστε μια αρνητική τιμή για να καθορίσετε το διάστημα γραμμής σε σημεία.

Το παρακάτω παράδειγμα ορίζει το διάστημα εντός της πρώτης παραγράφου στο 200% του ύψους της γραμμής (διπλό διάστημα):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το διάστημα γραμμής εντός της παραγράφου](line_spacing.png)

## **Έλεγχος Διακοπής Γραμμής**

Οι κανόνες διακοπής γραμμής παραγράφου είναι χρήσιμοι σε στενά μπλοκ κειμένου και παρουσιάσεις που συνδυάζουν λατινικό και ανατολικοασιατικό κείμενο. Οι παρακάτω μέθοδοι ανήκουν στο [ParagraphFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/), επομένως εφαρμόζονται σε ολόκληρη την παράγραφο:

- [setLatinLineBreak](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) ελέγχει τους κανόνες διακοπής γραμμής για το λατινικό κείμενο. Σε μικτό κείμενο, η αλλαγή του μπορεί επίσης να αλλάξει το πού τυλίγεται το γειτονικό ανατολικοασιατικό κείμενο και η στίξη.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) ελέγχει τους κανόνες διακοπής γραμμής για το ανατολικοασιατικό κείμενο, συμπεριλαμβανομένων των περιορισμών σε χαρακτήρες στην αρχή και το τέλος μιας γραμμής.

Αυτοί οι κανόνες δεν αντικαθιστούν το [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/#setWrapText), που ενεργοποιεί την αυτόματη αναδίπλωση μέσα σε ένα πλαίσιο κειμένου. Επηρεάζουν τη διάταξη όταν συμβαίνει η αναδίπλωση· δεν εισάγουν χαρακτήρες διακοπής γραμμής. Μια ρητή διακοπή γραμμής εξαναγκάζει νέα γραμμή μέσα στην παράγραφο ανεξάρτητα από το διαθέσιμο πλάτος.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα στενό μπλοκ κειμένου που περιέχει Κινέζικο και λατινικό κείμενο. Ορίζει ρητά και τις δύο επιλογές διακοπής γραμμής και αποθηκεύει το "line_breaking.pptx". Για να πειραματιστείτε με οποιονδήποτε κανόνα, αλλάξτε την αντίστοιχη τιμή ενώ διατηρείτε τις άλλες ρυθμίσεις σταθερές. Το παράδειγμα χρησιμοποιεί Arial 24 σημείων και SimSun με πλάτος πλαισίου 160 σημείων και μηδενικά οριζόντια περιθώρια πλαισίου κειμένου. Το [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/#setAutofitType) καλείται με [TextAutofitType::None](https://reference.aspose.com/slides/el/php-java/aspose.slides/textautofittype/) ώστε το μέγεθος κειμένου και οι διαστάσεις του πλαισίου να παραμείνουν σταθερές.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 160, 300);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("中文排版测试，PowerPoint 中文演示。");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $eastAsianFont = new FontData("SimSun");
    $format->getDefaultPortionFormat()->setEastAsianFont($eastAsianFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setLatinLineBreak(NullableBool::False);
    $format->setEastAsianLineBreak(NullableBool::True);

    $presentation->save("line_breaking.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Έλεγχος Κρεμαστής Στίξης**

[ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) επιτρέπει σε επιλέξιμη στίξη να εκτείνεται πέρα από την δεξιά άκρη της γραμμής κειμένου αντί να καταλαμβάνει την επόμενη γραμμή. Εφαρμόζεται σε ολόκληρη την παράγραφο και διαφέρει από ένα κρεμασμένο εσοχή.

Το παρακάτω αυτόνομο παράδειγμα ενεργοποιεί την κρεμαστή στίξη σε ένα πλαίσιο κειμένου 100 σημείων πλάτους και αποθηκεύει το "hanging_punctuation.pptx". Με Arial 24 σημείων και μηδενικά οριζόντια περιθώρια πλαισίου κειμένου, η τελική τελεία παραμένει μετά το "sentence" και εκτείνεται πέρα από το δεξιό άκρο του κειμένου. Ορίστε την ιδιότητα σε [NullableBool::False](https://reference.aspose.com/slides/el/php-java/aspose.slides/nullablebool/) για σύγκριση: με αυτές τις ρυθμίσεις, η τελεία καταλαμβάνει ξεχωριστή γραμμή. Η αναδίπλωση είναι ενεργή και η αυτόματη προσαρμογή απενεργοποιημένη ώστε το διαθέσιμο πλάτος να παραμείνει σταθερό.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 200);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("Simple text, next sentence.");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setHangingPunctuation(NullableBool::True);

    $presentation->save("hanging_punctuation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Δεν μπορεί να κρεμαστεί κάθε σημάδι στίξης. Το ορατό αποτέλεσμα εξαρτάται από τη διαθεσιμότητα της γραμματοσειράς και τη διάταξη: η αλλαγή της γραμματοσειράς, του διαθέσιμου πλάτους, των περιθωρίων ή των ρυθμίσεων αυτόματης προσαρμογής μπορεί να αφαιρέσει τη διαφορά.

## **Ορισμός Τύπου Αυτόματης Προσαρμογής για Πλαίσια Κειμένου**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/#setAutofitType) καθορίζει τον τρόπο με τον οποίο το κείμενο συμπεριφέρεται όταν υπερβαίνει τα όρια του περιέκτη του. Χρησιμοποιήστε το για να ελέγξετε αν το κείμενο μικραίνει, υπερέχει ή αλλάζει αυτόματα το μέγεθος του σχήματος. Το παρακάτω παράδειγμα ρυθμίζει το σχήμα ώστε να αλλάζει μέγεθος ώστε να ταιριάζει με το κείμενο του και αποθηκεύει το αποτέλεσμα στο "autofit_type.pptx".

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAutofitType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Για να μετρήσετε τις γραμμές μετά την αυτόματη αναδίπλωση και να δείτε πώς το κείμενο ή το πλάτος του σχήματος αλλάζει το αποτέλεσμα, δείτε [Count Rendered Lines](/slides/el/php-java/manage-paragraph/). Ο μόνος ο αριθμός γραμμών δεν δείχνει εάν το κείμενο υπερβαίνει το περιεχόμενό του.

## **Ορισμός Άγκυρας Πλαισίων Κειμένου**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/#setAnchoringType) ορίζει πώς το κείμενο τοποθετείται κάθετα μέσα σε ένα σχήμα, π.χ. στο πάνω μέρος, στη μέση ή στο κάτω. Το παρακάτω παράδειγμα αγκυροβολεί το κείμενο στο κάτω μέρος του πρώτου σχήματος και αποθηκεύει το αποτέλεσμα στο "text_anchor.pptx".

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ορισμός Καρτελών για το Κείμενο**

Χρησιμοποιήστε [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) και [ParagraphFormat::getTabs](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#getTabs) για να ρυθμίσετε τα σημεία στήλης (tab stops) σε μια παράγραφο. Το παρακάτω παράδειγμα ορίζει το προεπιλεγμένο διάστημα καρτέλας στα 100 σημεία και προσθέτει ένα αριστερά ευθυγραμμισμένο σημείο καρτέλας στα 30 σημεία. Αυτές οι ρυθμίσεις επηρεάζουν το κείμενο που περιέχει χαρακτήρες καρτέλας.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TabAlignment;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->setDefaultTabSize(100);
    $paragraph->getParagraphFormat()->getTabs()->add(30, TabAlignment::Left);

    $presentation->save("paragraph_tabs.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Οι καρτέλες της παραγράφου](paragraph_tabs.png)

## **Ορισμός Γλώσσας Ελέγχου Ορθογραφίας**

Το Aspose.Slides παρέχει το [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setLanguageId), το οποίο σας επιτρέπει να ορίσετε τη γλώσσα ελέγχου ορθογραφίας για ένα τμήμα κειμένου. Η γλώσσα ελέγχου καθορίζει τη γλώσσα που χρησιμοποιείται για ελέγχους ορθογραφίας και γραμματικής στο PowerPoint.

Το παρακάτω παράδειγμα απαιτεί το «presentation.pptx» με ένα πλαίσιο κειμένου ως το πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον μία παράγραφο. Αντικαθιστά το περιεχόμενο της πρώτης παραγράφου με "1。", ορίζει τη γραμματοσειρά SimSun και καθορίζει τη γλώσσα ελέγχου απλής κινεζικής (`zh-CN`). Αποθηκεύει το αποτέλεσμα στο "proofing_language.pptx":

```php
use aspose\slides\FontData;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // Ορίστε το Id της γλώσσας ελέγχου ορθογραφίας.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Χρησιμοποιήστε το [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) για να ορίσετε τη προεπιλεγμένη γλώσσα για κείμενο που δημιουργείται κατά τη φόρτωση ή δημιουργία μιας παρουσίασης. Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση με αμερικανική αγγλική ως προεπιλεγμένη γλώσσα κειμένου, προσθέτει ένα πλαίσιο κειμένου και εκτυπώνει `en-US` για το πρώτο τμήμα κειμένου.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Προσθέστε ένα νέο ορθογώνιο σχήμα με κείμενο.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // Ελέγξτε τη γλώσσα του πρώτου τμήματος.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **Ορισμός Προεπιλεγμένου Στυλ Κειμένου**

Για να εφαρμόσετε προεπιλεγμένη μορφοποίηση κειμένου σε επίπεδο παρουσίασης, χρησιμοποιήστε το [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getDefaultTextStyle).

Το παρακάτω παράδειγμα ορίζει μια γραμματοσειρά 14 σημείων έντονη ως προεπιλογή για τις παραγράφους κορυφαίου επιπέδου σε μια νέα παρουσίαση και την αποθηκεύει στο "default_text_style.pptx". Το κείμενο μπορεί να κληρονομήσει αυτές τις προεπιλογές εκτός εάν πιο συγκεκριμένες μορφοποιήσεις τις αντικαταστήσουν.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // Λάβετε τη μορφοποίηση της παραγράφου του ανώτερου επιπέδου.
    $paragraphFormat = $presentation->getDefaultTextStyle()->getLevel(0);

    if (!java_is_null($paragraphFormat)) {
        $paragraphFormat->getDefaultPortionFormat()->setFontHeight(14);
        $paragraphFormat->getDefaultPortionFormat()->setFontBold(NullableBool::True);
    }

    $presentation->save("default_text_style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Εξαγωγή Κειμένου με το Εφέ Όλων Κεφαλαίων**

Στο PowerPoint, η εφαρμογή του εφέ **All Caps** (όλα κεφαλαία) κάνει το κείμενο να εμφανίζεται με κεφαλαία γράμματα στη διαφάνεια ακόμη και αν αρχικά πληκτρολογήθηκε με πεζά. Όταν ανακτάτε ένα τέτοιο τμήμα κειμένου με το Aspose.Slides, η βιβλιοθήκη επιστρέφει το κείμενο ακριβώς όπως καταχωρήθηκε. Για να ταιριάζει με το εμφανιζόμενο κείμενο, ελέγξτε το [TextCapType](https://reference.aspose.com/slides/el/php-java/aspose.slides/textcaptype/) και μετατρέψτε το επιστρεφόμενο κείμενο σε κεφαλαία όταν η τιμή είναι `All`.

Αυτό το παράδειγμα απαιτεί το «sample2.pptx» με ένα πλαίσιο κειμένου ως το πρώτο σχήμα στην πρώτη διαφάνεια. Η πρώτη παράγραφος του πρώτου τμήματος περιέχει το "Hello, Aspose!" με το εφέ All Caps εφαρμόσμένο, όπως φαίνεται παρακάτω.

![Το εφέ All Caps](all_caps_effect.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εξαγάγετε το κείμενο με το εφαρμοσμένο εφέ **All Caps**:

```php
use aspose\slides\Presentation;
use aspose\slides\TextCapType;

$presentation = new Presentation("sample2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $autoShape = $slide->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    $originalText = $textPortion->getText();
    echo "Original text: ", $originalText, "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($originalText);
        echo "All-Caps effect: ", $text, "\n";
    }
} finally {
    $presentation->dispose();
}
```

Αποτέλεσμα:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να τροποποιήσω το κείμενο σε έναν πίνακα σε μια διαφάνεια;**

Για να τροποποιήσετε το κείμενο σε έναν πίνακα σε μια διαφάνεια, χρησιμοποιήστε το [Table](https://reference.aspose.com/slides/el/php-java/aspose.slides/table/). Περιηγηθείτε στα κελιά και ενημερώστε κάθε κελί μέσω του [Cell::getTextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/cell/#getTextFrame) και τη μορφοποίηση παραγράφου μέσω του [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/#getParagraphFormat).

**Πώς μπορώ να εφαρμόσω διαβαθμισμένο χρώμα σε κείμενο σε μια διαφάνεια PowerPoint;**

Για να εφαρμόσετε διαβαθμισμένο χρώμα σε κείμενο, χρησιμοποιήστε το [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#getFillFormat). Ορίστε το [FillFormat::setFillType](https://reference.aspose.com/slides/el/php-java/aspose.slides/fillformat/#setFillType) στο [FillType::Gradient](https://reference.aspose.com/slides/el/php-java/aspose.slides/filltype/) και διαμορφώστε τα σημεία διαβάθμισης, την κατεύθυνση και τη διαφάνεια.