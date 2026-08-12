---
title: Διαμορφώστε κείμενο παρουσίασης σε PHP
linktitle: Μορφοποίηση κειμένου
type: docs
weight: 50
url: /el/php-java/text-formatting/
keywords:
- ευθυγράμμιση παραγράφου
- στυλ κειμένου
- φόντο κειμένου
- διαφάνεια κειμένου
- απόσταση χαρακτήρων
- ιδιότητες γραμματοσειράς
- οικογένεια γραμματοσειράς
- περιστροφή κειμένου
- γωνία περιστροφής
- πλαίσιο κειμένου
- διάστημα γραμμής
- ιδιότητα autofit
- αγκύρωση πλαισίου κειμένου
- καρτέλες κειμένου
- προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Διαμορφώστε και στυλιζάτε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java. Προσαρμόστε γραμματοσειρές, χρώματα, ευθυγράμμιση και άλλα."
---
## **Overview**

Αυτό το άρθρο δείχνει πώς να μορφοποιήσετε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java. Καλύπτει χρώματα φόντου, διαφάνεια, απόσταση χαρακτήρων, ιδιότητες γραμματοσειράς, περιστροφή, απόσταση παραγράφων, συμπεριφορά Autofit, αγκύρωση κειμένου, σημάντες καρτέλας και ρυθμίσεις γλώσσας.

Στα παραδείγματα παρακάτω, θα χρησιμοποιήσουμε ένα αρχείο με όνομα «sample.pptx», το οποίο περιέχει ένα μόνο πλαίσιο κειμένου στην πρώτη διαφάνεια με το ακόλουθο κείμενο:

![Δείγμα κειμένου](sample_text.png)

Για να εντοπίσετε και να επισημάνετε κυριολεκτικό κείμενο ή αντιστοιχίες κανονικής έκφρασης, δείτε [Αναζήτηση και Αντικατάσταση Κειμένου](/slides/el/php-java/search-and-replace-text/).

## **Set Text Background Color**

Χρησιμοποιήστε [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) για να ορίσετε το προεπιλεγμένο χρώμα επισήμανσης για μια παράγραφο ή χρησιμοποιήστε [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#getHighlightColor) για μεμονωμένα τμήματα κειμένου.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε το χρώμα φόντου για **ολόκληρη την παράγραφο**:

```php
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

![Η γκρίζα παράγραφος](gray_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε το χρώμα φόντου για **τμήματα κειμένου με έντονη γραμματοσειρά**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
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

![Τα γκρίζα τμήματα κειμένου](gray_text_portions.png)

## **Align Text Paragraphs**

Χρησιμοποιήστε [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#setAlignment) για να ορίσετε την ευθυγράμμιση της παραγράφου μέσα σε πλαίσιο κειμένου. Η τιμή μπορεί να είναι κεντραρισμένη, αριστερή, δεξιά, ευθυγραμμισμένη κ.λπ.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ευθυγραμμίσετε την παράγραφο στο **κέντρο**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Ορίστε την ευθυγράμμιση της παραγράφου στο κέντρο.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Η ευθυγραμμισμένη παράγραφος](aligned_paragraph.png)

## **Set Transparency for Text**

Η διαφάνεια του κειμένου ελέγχεται μέσω του στοιχείου άλφα του χρώματος που έχει οριστεί στο [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#getFillFormat). Στα παραδείγματα παρακάτω, `alpha = 50` είναι μια τιμή αλφα-καναλιού ARGB στην κλίμακα 0–255, όχι ποσοστό διαφάνειας.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια στην **ολόκληρη την παράγραφο**:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // Ορίστε το χρώμα γέμισης του κειμένου σε διαφανές χρώμα.
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
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
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

## **Set Character Spacing for Text**

Χρησιμοποιήστε [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setSpacing) για να αυξήσετε ή να μειώσετε την απόσταση μεταξύ χαρακτήρων σε πλαίσιο κειμένου.

Ο παρακάτω κώδικας PHP δείχνει πώς να αυξήσετε την απόσταση χαρακτήρων σε **ολόκληρη την παράγραφο**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε την απόσταση χαρακτήρων.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Επεκτείνετε την απόσταση χαρακτήρων.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Η απόσταση χαρακτήρων στην παράγραφο](character_spacing_in_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να αυξήσετε την απόσταση χαρακτήρων σε **τμήματα κειμένου με έντονη γραμματοσειρά**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε την απόσταση χαρακτήρων.
            $portion->getPortionFormat()->setSpacing(3); // Επεκτείνετε την απόσταση χαρακτήρων.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Η απόσταση χαρακτήρων στα τμήματα κειμένου](character_spacing_in_text_portions.png)

### **Disable Kerning for Specific Fonts**

Σε ορισμένες περιπτώσεις, το κείμενο που αποδίδεται από το Aspose.Slides μπορεί να φαίνεται ελαφρώς πιο πυκνό από το ίδιο κείμενο που εμφανίζεται στο PowerPoint. Αυτό μπορεί να συμβεί επειδή το PowerPoint μπορεί να αγνοήσει τα δεδομένα kerning για ορισμένες γραμματοσειρές, ακόμη και όταν η γραμματοσειρά περιέχει έγκυρα δεδομένα kerning και το kerning είναι ενεργοποιημένο στις ρυθμίσεις του PowerPoint.

Για να φέρετε την απόδοση πιο κοντά στο PowerPoint σε τέτοιες περιπτώσεις, μπορείτε να απενεργοποιήσετε το kerning για τμήματα κειμένου που χρησιμοποιούν την επηρεαζόμενη γραμματοσειρά. Ορίστε [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) σε τιμή σημαντικά μεγαλύτερη από το πραγματικό μέγεθος της γραμματοσειράς:

```php
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
            $portionFormat = $portion->getPortionFormat();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portionFormat->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Αυτή η ρύθμιση εμποδίζει την εφαρμογή kerning στα αντίστοιχα τμήματα κειμένου και μπορεί να βοηθήσει την απόδοση του Aspose.Slides να ταιριάζει με το οπτικό αποτέλεσμα του PowerPoint για τις γραμματοσειρές που επηρεάζονται από αυτή τη συμπεριφορά ειδική για το PowerPoint.

## **Manage Text Font Properties**

Οι ιδιότητες γραμματοσειράς μπορούν να οριστούν σε επίπεδο παραγράφου μέσω του [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) ή σε μεμονωμένα τμήματα μέσω του [PortionFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/portionformat/).

Ο παρακάτω κώδικας ορίζει τη γραμματοσειρά και το στυλ κειμένου για ολόκληρη την παράγραφο: εφαρμόζει μέγεθος γραμματοσειράς, έντονη, πλάγια, υπογράμμιση με κουκκίδες και τη γραμματοσειρά Times New Roman σε όλα τα τμήματα της παραγράφου.

```php
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

Το παρακάτω παράδειγμα κώδικα εφαρμόζει παρόμοιες ιδιότητες σε **τμήματα κειμένου με έντονη γραμματοσειρά**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
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

## **Set Text Rotation**

Χρησιμοποιήστε [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/#setTextVerticalType) για να ορίσετε προεπιλεγμένη προσανατολισμό κειμένου μέσα σε σχήμα.

Το παρακάτω παράδειγμα κώδικα ορίζει τον προσανατολισμό κειμένου στο σχήμα σε `Vertical270`, που περιστρέφει το κείμενο **90 μοίρες αριστερόστροφα**:

```php
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

## **Set Custom Rotation for Text Frames**

Χρησιμοποιήστε [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/#setRotationAngle) για να ορίσετε προσαρμοσμένη γωνία περιστροφής για ένα [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/).

Το παρακάτω παράδειγμα κώδικα περιστρέφει το πλαίσιο κειμένου κατά 3 μοίρες δεξιόστροφα μέσα στο σχήμα:

```php
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

## **Set Line Spacing of Paragraphs**

Το Aspose.Slides παρέχει τις μεθόδους [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#setSpaceBefore) και [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#setSpaceWithin) για τον έλεγχο της απόστασης παραγράφων. Αυτές οι ιδιότητες χρησιμοποιούνται ως εξής:

* Χρησιμοποιήστε θετική τιμή για να καθορίσετε την απόσταση γραμμής ως ποσοστό του ύψους της γραμμής.
* Χρησιμοποιήστε αρνητική τιμή για να καθορίσετε την απόσταση γραμμής σε μονάδες (points).

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να καθορίσετε την απόσταση γραμμής μέσα στην παράγραφο:

```php
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

![Η απόσταση γραμμής μέσα στην παράγραφο](line_spacing.png)

## **Set Autofit Type for Text Frames**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/#setAutofitType) καθορίζει πώς το κείμενο συμπεριφέρεται όταν υπερβαίνει τα όρια του πλαισίου του. Χρησιμοποιήστε το για να ελέγξετε αν το κείμενο συρρικνώνεται, υπερχειλίζει ή αλλάζει αυτόματα το μέγεθος του σχήματος.

```php
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

## **Set Anchor of Text Frames**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/#setAnchoringType) ορίζει πώς το κείμενο θέτεται κάθετα μέσα σε ένα σχήμα, π.χ. στο πάνω μέρος, στο κέντρο ή στο κάτω μέρος.

```php
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

## **Set Text Tabulation**

Χρησιμοποιήστε [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) και [ParagraphFormat::getTabs](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#getTabs) για να διαμορφώσετε τα σημεία καρτέλας σε μια παράγραφο.

```php
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

## **Set Proofing Language**

Το Aspose.Slides παρέχει τη μέθοδο [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setLanguageId), η οποία επιτρέπει τον ορισμό της γλώσσας ελέγχου για ένα τμήμα κειμένου. Η γλώσσα ελέγχου καθορίζει τη γλώσσα που χρησιμοποιείται για ορθογραφικό και γραμματικό έλεγχο στο PowerPoint.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε τη γλώσσα ελέγχου για ένα τμήμα κειμένου:

```php
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

    // Ορίστε το Id μιας γλώσσας ελέγχου.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Set Default Language**

Χρησιμοποιήστε [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) για να ορίσετε τη προεπιλεγμένη γλώσσα για κείμενο που δημιουργείται κατά τη φόρτωση ή τη δημιουργία μιας παρουσίασης.

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Προσθέστε ένα νέο σχήμα ορθογώνιο με κείμενο.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // Ελέγξτε τη γλώσσα του πρώτου τμήματος.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **Set Default Text Style**

Για να εφαρμόσετε προεπιλεγμένη μορφοποίηση κειμένου σε επίπεδο παρουσίασης, χρησιμοποιήστε [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getDefaultTextStyle).

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε μια προεπιλεγμένη έντονη γραμματοσειρά μεγέθους 14 pt για όλο το κείμενο σε όλες τις διαφάνειες μιας νέας παρουσίασης.

```php
$presentation = new Presentation();
try {
    // Λάβετε τη μορφοποίηση παραγράφου του ανώτερου επιπέδου.
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

## **Extract Text with the All-Caps Effect**

Στο PowerPoint, η εφαρμογή του εφέ **All Caps** κάνει το κείμενο να εμφανίζεται σε κεφαλαία στην διαφάνεια ακόμα και αν αρχικά είχε πληκτρολογηθεί με πεζά. Όταν εξάγετε ένα τέτοιο τμήμα κειμένου με το Aspose.Slides, η βιβλιοθήκη επιστρέφει το κείμενο ακριβώς όπως εισήχθη. Για να ταιριάξετε το εμφανιζόμενο κείμενο, ελέγξτε το [TextCapType](https://reference.aspose.com/slides/el/php-java/aspose.slides/textcaptype/) και μετατρέψτε τη επιστρεφόμενη συμβολοσειρά σε κεφαλαία όταν η τιμή είναι `All`.

Ας υποθέσουμε ότι έχουμε το ακόλουθο πλαίσιο κειμένου στην πρώτη διαφάνεια του αρχείου sample2.pptx.

![Το εφέ Όλων-Κεφαλαίων](all_caps_effect.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εξάγετε το κείμενο με το εφαρμοσμένο εφέ **All Caps**:

```php
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

Έξοδος:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Πώς να τροποποιήσετε κείμενο σε πίνακα σε μια διαφάνεια;**

Για να τροποποιήσετε κείμενο σε πίνακα σε μια διαφάνεια, χρησιμοποιήστε το [Table](https://reference.aspose.com/slides/el/php-java/aspose.slides/table/). Επανάληψη μέσω των κελιών και ενημέρωση κάθε κελιού μέσω του [Cell::getTextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/cell/#getTextFrame) και μορφοποίηση παραγράφου μέσω του [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/#getParagraphFormat).

**Πώς να εφαρμόσετε χρώμα διαβάθμισης σε κείμενο σε μια διαφάνεια PowerPoint;**

Για να εφαρμόσετε χρώμα διαβάθμισης σε κείμενο, χρησιμοποιήστε το [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#getFillFormat). Ορίστε το [FillFormat::setFillType](https://reference.aspose.com/slides/el/php-java/aspose.slides/fillformat/#setFillType) σε [FillType::Gradient](https://reference.aspose.com/slides/el/php-java/aspose.slides/filltype/) και διαμορφώστε τα σημεία διαβάθμισης, την κατεύθυνση και τη διαφάνεια.