---
title: Μορφοποίηση κειμένου παρουσίασης σε PHP
linktitle: Μορφοποίηση κειμένου
type: docs
weight: 50
url: /el/php-java/text-formatting/
keywords:
- στοίχιση παραγράφου
- στυλ κειμένου
- υπόβαθρο κειμένου
- διαφάνεια κειμένου
- απόσταση χαρακτήρων
- ιδιότητες γραμματοσειράς
- οικογένεια γραμματοσειράς
- περιστροφή κειμένου
- γωνία περιστροφής
- πλαίσιο κειμένου
- απόσταση γραμμής
- ιδιότητα αυτόματης προσαρμογής
- αγκύρωση πλαισίου κειμένου
- στηλοθέτηση κειμένου
- προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μορφοποιήστε και εφαρμόστε στυλ σε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java. Προσαρμόστε γραμματοσειρές, χρώματα, στοίχιση και άλλα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να μορφοποιήσετε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java. Καλύπτει χρώματα παρασκηνίου, διαφάνεια, απόσταση χαρακτήρων, ιδιότητες γραμματοσειράς, περιστροφή, απόσταση παραγράφων, συμπεριφορά αυτόματης προσαρμογής, αγκύρωση κειμένου, σημάνσεις στηλοθετών και ρυθμίσεις γλώσσας.

Εκτός εάν αναφέρεται διαφορετικά, τα παραδείγματα χρησιμοποιούν το [sample.pptx](sample.pptx). Το πρώτο σχήμα στην πρώτη διαφάνειά του είναι ένα πλαίσιο κειμένου και η πρώτη παράγραφος του περιέχει το κείμενο που φαίνεται παρακάτω. Οι δείκτες διαφάνειας και σχήματος είναι μηδενική βάση. Τα παραδείγματα που επιλέγουν έντονες περιοχές χρησιμοποιούν αποτελεσματική μορφοποίηση, συμπεριλαμβανομένης της κληρονομικής έντονης μορφοποίησης:

![Δείγμα κειμένου](sample_text.png)

Για να βρείτε και να επισήμάνετε κυριολεκτικό κείμενο ή αντιστοιχίες κανονικής έκφρασης, δείτε [Αναζήτηση και αντικατάσταση κειμένου](/slides/el/php-java/search-and-replace-text/).

## **Ορισμός χρώματος φόντου κειμένου**

Χρησιμοποιήστε το [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) για να ορίσετε το προεπιλεγμένο χρώμα επισήμανσης για μια παράγραφο, ή χρησιμοποιήστε το [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getHighlightColor) για ξεχωριστές περιοχές κειμένου.

Το παρακάτω παράδειγμα ορίζει ένα ανοιχτό γκρι χρώμα επισύμανσης ως προεπιλογή για την πρώτη παράγραφο. Οι ρητές χρωματικές επισυμάνσεις στις μεμονωμένες περιοχές έχουν προτεραιότητα έναντι αυτής της προεπιλογής:

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

![Το γκρι παράγραφο](gray_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε το χρώμα φόντου για **περιοχές κειμένου με έντονη γραμματοσειρά**:

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
            // Ορίστε το χρώμα επισήμανσης για την περιοχή κειμένου.
            $portion->getPortionFormat()->getHighlightColor()->setColor($highlightColor);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Οι γκρι περιοχές κειμένου](gray_text_portions.png)

## **Στοίχιση παραγράφων κειμένου**

Χρησιμοποιήστε το [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) για να ορίσετε την ευθυγράμμιση παραγράφου μέσα σε ένα πλαίσιο κειμένου. Η τιμή μπορεί να είναι κεντραρισμένη, αριστερή, δεξιά, στοιχισμένη και ούτω καθεξής.

Το παρακάτω παράδειγμα δείχνει πώς να στοιχίσετε την παράγραφο στο **κέντρο**:

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

## **Στοίχιση γραμματοσειρών μέσα σε γραμμή**

Χρησιμοποιήστε το [ParagraphFormat::setFontAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setFontAlignment) για κάθετη στοίχιση περιοχών κειμένου διαφορετικών μεγεθών γραμματοσειράς μέσα σε μια γραμμή. Αυτή η ρύθμιση ισχύει για ολόκληρη την παράγραφο και ελέγχει τη στοίχιση εντός κάθε γραμμής της.

Το παρακάτω αυτοτελές παράδειγμα δημιουργεί τέσσερα ετικετισμένα πλαίσια κειμένου σε μία διαφάνεια. Κάθε παράγραφος περιέχει το ίδιο κείμενο σε 18, 36 και 54 σημεία, με διαφορετική στοίχιση γραμματοσειράς. Χρησιμοποιεί Arial, απενεργοποιεί την αυτόματη προσαρμογή και την αναδίπλωση, και διατηρεί τα πλαίσια κειμένου αρκετά μεγάλα για μία γραμμή.

```php
use aspose\slides\FillType;
use aspose\slides\FontAlignment;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $alignments = [FontAlignment::Baseline, FontAlignment::Top, FontAlignment::Center, FontAlignment::Bottom];
    $alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    $fontSizes = [18, 36, 54];
    $font = new FontData("Arial");
    $gray = java("java.awt.Color")->GRAY;
    $black = java("java.awt.Color")->BLACK;

    for ($i = 0; $i < count($alignments); $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 20 + $i * 130, 660, 120);
        $shape->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $textFrame = $shape->getTextFrame();
        $textFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
        $textFrame->getTextFrameFormat()->setWrapText(NullableBool::False);

        $label = $textFrame->getParagraphs()->get_Item(0);
        $label->setText($alignmentNames[$i]);
        $label->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $label->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(14);
        $label->getParagraphFormat()->getDefaultPortionFormat()->setLatinFont($font);
        $label->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $label->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($gray);

        $paragraph = new Paragraph();
        $paragraph->getParagraphFormat()->setFontAlignment($alignments[$i]);
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setLatinFont($font);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

        foreach ($fontSizes as $fontSize) {
            $portion = new Portion("Ag ");
            $portion->getPortionFormat()->setFontHeight($fontSize);
            $paragraph->getPortions()->add($portion);
        }

        $textFrame->getParagraphs()->add($paragraph);
    }

    $presentation->save("font_alignment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Σύγκριση στοίχισης Baseline, Top, Center και Bottom με μεικτά μεγέθη γραμματοσειράς](font_alignment.png)

Η στοίχιση γραμματοσειράς χρησιμοποιεί μετρικές γραμματοσειράς, έτσι τα ορατά άκρα των μεμονωμένων γραμμάτων δεν ευθυγραμμίζονται απαραίτητα ακριβώς. Το παράδειγμα περιλαμβάνει τόσο ένα κεφαλαίο γράμμα όσο και έναν κατώφλι για να δείξει τη διαφορά μεταξύ baseline και bottom στοίχισης. Η διαθεσιμότητα γραμματοσειράς και η αντικατάστασή της, οι χαρακτήρες που χρησιμοποιούνται και η διαφορά στα μεγέθη γραμματοσειράς επηρεάζουν το αποτέλεσμα. Οι διαστάσεις του πλαισίου, τα περιθώρια, η απόσταση μεταξύ γραμμών, η αναδίπλωση και η αυτόματη προσαρμογή επηρεάζουν επίσης τη διάταξη· χρησιμοποιήστε τις ίδιες γραμματοσειρές και ρυθμίσεις διάταξης όταν συγκρίνετε τις λειτουργίες.

Αυτή η ρύθμιση διαφέρει από το [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment), το οποίο ελέγχει την οριζόντια στοίχιση παραγράφου, και το [TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType), το οποίο τοποθετεί το μπλοκ κειμένου κάθετα μέσα στο σχήμα του. Η μορφοποίηση εκθέτη και υπογράμμισης μέσω του [BasePortionFormat::setEscapement](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setEscapement) μετακινεί τις μεμονωμένες περιοχές σε σχέση με το baseline αντί να ορίζει τη στοίχιση της γραμματοσειράς για τις γραμμές της παραγράφου.

## **Ορισμός διαφάνειας για κείμενο**

Η διαφάνεια του κειμένου ελέγχεται μέσω του αλφα-συστατικού του χρώματος που έχει οριστεί στο [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat). Στα παρακάτω παραδείγματα, `alpha = 50` είναι τιμή καναλιού αλφα ARGB σε κλίμακα 0–255, όχι ποσοστό διαφάνειας.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια σε **ολόκληρη την παράγραφο**:

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

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια σε **περιοχές κειμένου με έντονη γραμματοσειρά**:

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
            // Ορίστε τη διαφάνεια της περιοχής κειμένου.
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

![Οι διαφανείς περιοχές κειμένου](transparent_text_portions.png)

## **Ορισμός απόστασης χαρακτήρων για κείμενο**

Χρησιμοποιήστε το [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setSpacing) για να αυξήσετε ή να μειώσετε την απόσταση μεταξύ χαρακτήρων σε ένα πλαίσιο κειμένου. Τα παραδείγματα προσθέτουν 3 σημεία απόστασης· αρνητικές τιμές μειώνουν το κείμενο.

Το παρακάτω PHP κώδικα δείχνει πώς να επεκτείνετε την απόσταση χαρακτήρων στο **ολόκληρο το παράγραφο**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε την απόσταση χαρακτήρων.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Αυξήστε την απόσταση χαρακτήρων.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Η απόσταση χαρακτήρων στην παράγραφο](character_spacing_in_paragraph.png)

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να επεκτείνετε την απόσταση χαρακτήρων σε **περιοχές κειμένου με έντονη γραμματοσειρά**:

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
            // Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε την απόσταση χαρακτήρων.
            $portion->getPortionFormat()->setSpacing(3); // Αυξήστε την απόσταση χαρακτήρων.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Η απόσταση χαρακτήρων στις περιοχές κειμένου](character_spacing_in_text_portions.png)

### **Απενεργοποίηση Kerning για συγκεκριμένες γραμματοσειρές**

Σε ορισμένες περιπτώσεις, το κείμενο που αποδίδεται από το Aspose.Slides μπορεί να φαίνεται ελαφρώς πιο σφιχτό από το ίδιο κείμενο που εμφανίζεται στο PowerPoint. Αυτό μπορεί να συμβαίνει επειδή το PowerPoint μπορεί να αγνοήσει τα δεδομένα kerning για ορισμένες γραμματοσειρές, ακόμη και όταν η γραμματοσειρά περιέχει έγκυρα δεδομένα kerning και το kerning είναι ενεργοποιημένο στις ρυθμίσεις του PowerPoint.

Για να φέρετε την απόδοση πιο κοντά στο PowerPoint, μπορείτε να απενεργοποιήσετε το kerning για περιοχές κειμένου που χρησιμοποιούν τη συγκεκριμένη γραμματοσειρά. Ορίστε το [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) σε τιμή μεγαλύτερη από το πραγματικό μέγεθος γραμματοσειράς. Το παράδειγμα αυτό απαιτεί το “presentation.pptx” με ένα πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια. Ελέγχει τα αποτελεσματικά ονόματα γραμματοσειρών, συμπεριλαμβανομένων των κληρονομικών, και ορίζει κατώφλι 100 σημείων για περιοχές που χρησιμοποιούν το Roboto. Αυτό απενεργοποιεί το kerning για τις αντίστοιχες περιοχές με μέγεθος γραμματοσειράς κάτω από 100 σημεία:

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

Για κείμενο που ταιριάζει κάτω από το κατώφλι, αυτή η ρύθμιση αποτρέπει το kerning και μπορεί να βοηθήσει στην ευθυγράμμιση της απόδοσης του Aspose.Slides με την οπτική έξοδο του PowerPoint για γραμματοσειρές που επηρεάζονται από αυτήν τη συμπεριφορά ειδική του PowerPoint.

## **Διαχείριση ιδιοτήτων γραμματοσειράς κειμένου**

Οι ιδιότητες γραμματοσειράς μπορούν να οριστούν σε επίπεδο παραγράφου μέσω του [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) ή σε μεμονωμένες περιοχές μέσω του [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/).

Το παρακάτω παράδειγμα ορίζει την προεπιλεγμένη γραμματοσειρά της πρώτης παραγράφου σε Times New Roman 12 σημείων με έντονη, πλάγια και υπογραμμισμένη με κουκκίδες μορφοποίηση. Η ρητή μορφοποίηση σε μεμονωμένες περιοχές έχει προτεραιότητα έναντι αυτών των προεπιλογών.

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

Το παρακάτω παράδειγμα εφαρμόζει Times New Roman 13 σημείων, πλάγια μορφοποίηση και υπογράμμιση με κουκκίδες σε περιοχές των οποίων η αποτελεσματική μορφοποίηση είναι έντονη:

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
            // Ορίστε τις ιδιότητες γραμματοσειράς για την περιοχή κειμένου.
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

![Οι ιδιότητες γραμματοσειράς για τις περιοχές κειμένου](font_properties_for_text_portions.png)

## **Έλεγχος ομαλοποίησης ύψους κειμένου**

Χρησιμοποιήστε το [BasePortionFormat::setNormaliseHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setNormaliseHeight) όταν αναπαράγετε την τυπογραφία προτύπων ή ερευνάτε διαφορές στο ύψος χαρακτήρων. Στο PowerPoint, η ενεργοποίηση της ομαλοποίησης τεντώνει ή συμπιέζει κάθε χαρακτήρα κατακόρυφα ώστε να έχει ομοιόμορφο ορατό ύψος μέσα στην περιοχή κειμένου. Δεν εγγυάται ίσα ύψη κειμένου μεταξύ διαφορετικών γραμματοσειρών.

Ορίστε την ιδιότητα σε [NullableBool::True ή False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) για να ενεργοποιήσετε ή να απενεργοποιήσετε ρητά την ομαλοποίηση. `NullableBool::NotDefined` αφήνει την τοπική ρύθμιση ακαθόριστη ώστε η περιοχή να κληρονομήσει την τιμή, π.χ. από το [getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) της παραγράφου. Δεν σημαίνει `False`. Χρησιμοποιήστε το [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) και διαβάστε το `getNormaliseHeight` στα αποτελεσματικά δεδομένα μορφοποίησης για να λάβετε την επιλυμένη λογική τιμή.

Το παρακάτω αυτοτελές παράδειγμα απαιτεί **Arial** εγκατεστημένο. Δημιουργεί δύο μπλοκ κειμένου με τα ίδια κεφαλαία, πεζά, κάτω γράμματα και διατεταγμένους χαρακτήρες σε 54 σημεία. Και οι δύο παράγραφοι ενεργοποιούν την ομαλοποίηση από προεπιλογή. Η πάνω περιοχή την απενεργοποιεί ρητά· η κάτω κληρονομεί την τιμή. Τα μεγέθη πλαισίων, τα περιθώρια και η απόσταση παραγράφου είναι ίδια, με την αναδίπλωση και την αυτόματη προσαρμογή ανενεργές για σταθερή σύγκριση. Το παράδειγμα εμφανίζει `False: false` και `NotDefined: true`, έπειτα αποθηκεύει το “text_height_normalization.pptx”.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $settings = [NullableBool::False, NullableBool::NotDefined];
    $settingNames = ["False", "NotDefined"];

    for ($i = 0; $i < count($settings); $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 60 + $i * 200, 660, 150);
        $shape->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $textFrame = $shape->getTextFrame();
        $textFrame->setText("Hxgjpq ÅÉ 0123");
        $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
        $textFrame->getTextFrameFormat()->setWrapText(NullableBool::False);
        $textFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $textFrame->getTextFrameFormat()->setMarginTop(0);
        $textFrame->getTextFrameFormat()->setMarginLeft(0);

        $paragraph = $textFrame->getParagraphs()->get_Item(0);
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->setSpaceBefore(0);
        $paragraph->getParagraphFormat()->setSpaceAfter(0);
        $paragraph->getParagraphFormat()->setSpaceWithin(100);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setNormaliseHeight(NullableBool::True);

        $portion = $paragraph->getPortions()->get_Item(0);
        $font = new FontData("Arial");
        $portion->getPortionFormat()->setLatinFont($font);
        $portion->getPortionFormat()->setFontHeight(54);
        $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $black = java("java.awt.Color")->BLACK;
        $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);
        $portion->getPortionFormat()->setNormaliseHeight($settings[$i]);

        $normaliseHeight = java_values($portion->getPortionFormat()->getEffective()->getNormaliseHeight());
        echo $settingNames[$i], ": ", $normaliseHeight ? "true" : "false", PHP_EOL;
    }

    $presentation->save("text_height_normalization.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η σύγκριση παρακάτω εξήχθη από την αποθηκευμένη παρουσίαση. Η πάνω σειρά έχει την ομαλοποίηση απενεργοποιημένη (`False`); η κάτω σειρά κληρονομεί την ενεργοποιημένη ρύθμιση (`NotDefined` → `True`). Διατηρήστε το Arial εγκατεστημένο για να αναπαράγετε αυτήν την εμφάνιση.

![Κείμενο Arial 54 σημείων με ομαλοποίηση απενεργοποιημένη επάνω και κληρονομική ενεργή παρακάτω](text_height_normalization.png)

Η ομαλοποίηση αλλάζει το ύψος των χαρακτήρων χωρίς να αλλάζει την τιμή του [getFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFontHeight), η οποία καθορίζει το μέγεθος γραμματοσειράς σε σημεία. Η παράγραφος [setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) ελέγχει την απόσταση γραμμών, ενώ το [setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) του πλαισίου κειμένου ελέγχει πώς το κείμενο ή το περιέκτη του προσαρμόζεται. Αυτές οι ρυθμίσεις εξυπηρετούν διαφορετικούς σκοπούς και μπορούν να επηρεάσουν τη συνολική διάταξη ανεξάρτητα. Για περισσότερα σχετικά με τη μορφοποίηση παραγράφων και την κληρονομικότητα, δείτε [Διαχείριση παραγράφων](/slides/el/php-java/manage-paragraph/).

## **Εφαρμογή και αφαίρεση διακριτής διαγράμμισης**

Χρησιμοποιήστε το [BasePortionFormat::setStrikethroughType](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setStrikethroughType) σε μια περιοχή κειμένου για να εμφανίσετε διορθώσεις, ακυρωμένες εκφράσεις ή προηγούμενες τιμές χωρίς να διαγράψετε το αρχικό κείμενο. Ορίστε το σε [TextStrikethroughType::Single ή Double](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/) για μία ή δύο γραμμές διαγράμμισης μέσω του κειμένου.

Για να αφαιρέσετε τη διαγραμμάτωση, περάστε το [TextStrikethroughType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#None). Αυτό απενεργοποιεί ρητά το εφέ, ακόμη και αν η περιβάλλουσα μορφοποίηση το καθορίζει. Αντιθέτως, το [TextStrikethroughType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#NotDefined) αφήνει την τοπική ρύθμιση ακαθόριστη, επιτρέποντας στην περιοχή να κληρονομήσει τη μορφοποίηση, π.χ. από την παράγραφο. Δεν εγγυάται ότι η διαγράμμιση θα αφαιρεθεί. Χρησιμοποιήστε το [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) για να διαβάσετε τη τελική μορφοποίηση, συμπεριλαμβανομένων των κληρονομημένων τιμών.

Το παρακάτω αυτοτελές παράδειγμα δημιουργεί τρεις συγκρίσεις τιμών. Κάθε παράγραφος έχει διαφορετικές περιοχές για την ετικέτα, την προηγούμενη τιμή και την τρέχουσα τιμή, έτσι μόνο η προηγούμενη τιμή επηρεάζεται. Η πρώτη σειρά εφαρμόζει και μετά αφαιρεί τη διαγραμμάτωση· οι άλλες σειρές διατηρούν την απλή και διπλή διαγραμμάτωση. Η αλλαγή αυτής της ρύθμισης διατηρεί το κείμενο και τις άλλες μορφοποιήσεις του, όπως η έντονη προηγούμενη τιμή.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextStrikethroughType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 620, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $labels = [ "None: ", "Single: ", "Double: " ];

    foreach ($labels as $label) {
        $paragraph = new Paragraph();
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->setSpaceAfter(20);

        $format = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $format->setFontHeight(28);
        $font = new FontData("Arial");
        $format->setLatinFont($font);
        $format->getFillFormat()->setFillType(FillType::Solid);
        $blackColor = java("java.awt.Color")->BLACK;
        $format->getFillFormat()->getSolidFillColor()->setColor($blackColor);

        $labelPortion = new Portion($label);
        $paragraph->getPortions()->add($labelPortion);

        $previousPrice = new Portion("$100");
        $previousPrice->getPortionFormat()->setFontBold(NullableBool::True);
        $paragraph->getPortions()->add($previousPrice);
        $currentPrice = new Portion(" → $80");
        $paragraph->getPortions()->add($currentPrice);

        $shape->getTextFrame()->getParagraphs()->add($paragraph);
    }

    $paragraphs = $shape->getTextFrame()->getParagraphs();

    // Εφαρμόστε διαγραμμάτωση, μετά αφαιρέστε την ρητά από την πρώτη προηγούμενη τιμή.
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::None);

    $paragraphs->get_Item(1)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(2)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Double);

    $presentation->save("strikethrough.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα, από πάνω προς τα κάτω: χωρίς διαγραμμάτωση, απλή διαγραμμάτωση και διπλή διαγραμμάτωση.

![Προηγούμενες τιμές χωρίς διαγραμμάτωση, με απλή διαγραμμάτωση και με διπλή διαγραμμάτωση](strikethrough.png)

## **Ορισμός περιστροφής κειμένου**

Χρησιμοποιήστε το [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType) για να ορίσετε μια προεπιλεγμένη προσανατολισμό κειμένου μέσα σε σχήμα.

Το παρακάτω παράδειγμα κώδικα ορίζει τον προσανατολισμό κειμένου στο σχήμα σε [TextVerticalType::Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/), που περιστρέφει το κείμενο **90 μοίρες αριστερά**:

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

![Η περιστροφή του κειμένου](text_rotation.png)

## **Προβολή ψηφίων δίπλα-δίπλα σε κατακόρυφο κείμενο**

Για να διατηρήσετε έναν διψήφιο αριθμό ενωμένα σε κατακόρυφη ιαπωνική ετικέτα, τοποθετήστε και τα δύο ψηφία σε μία περιοχή κειμένου και καλέστε το [BasePortionFormat::setKumimoji](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKumimoji) σε αυτήν την περιοχή. Το παράδειγμα χρησιμοποιεί το [TextVerticalType::EastAsianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#EastAsianVertical) και γραμματοσειρά MS Gothic 40 σημείων και για τις δύο ετικέτες. Μόνο η τιμή του [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) που περνάται στην αριθμητική περιοχή διαφέρει.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $x = 120;

    foreach ([NullableBool::True, NullableBool::False] as $kumimoji) {
        $label = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, 48, 120, 420);
        $label->getFillFormat()->setFillType(FillType::NoFill);
        $label->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $frame = $label->addTextFrame("");
        $frame->getTextFrameFormat()->setTextVerticalType(TextVerticalType::EastAsianVertical);

        $paragraph = $frame->getParagraphs()->get_Item(0);
        $format = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $font = new FontData("MS Gothic");
        $format->setLatinFont($font);
        $format->setEastAsianFont($font);
        $format->setFontHeight(40);
        $format->getFillFormat()->setFillType(FillType::Solid);
        $black = java("java.awt.Color")->BLACK;
        $format->getFillFormat()->getSolidFillColor()->setColor($black);

        $digits = new Portion("12");
        $digits->getPortionFormat()->setKumimoji($kumimoji);

        $portions = $paragraph->getPortions();
        $portions->clear();
        $portions->add(new Portion("令和"));
        $portions->add($digits);
        $portions->add(new Portion("年"));

        $x += 240;
    }
    $presentation->save("vertical_date.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Στο PowerPoint, η αριστερή ετικέτα (`True`) εμφανίζει τα ψηφία όρθια και δίπλα-δίπλα μεταξύ των χαρακτήρων 和 και 年. Στη δεξιά ετικέτα (`False`), το ζεύγος περιστρέφεται 90 μοίρες δεξιά. Οι γύρω ιαπωνικοί χαρακτήρες παραμένουν όρθια και στις δύο ετικέτες.

![Σύγκριση ετικετών ημερομηνίας σε κατακόρυφο κείμενο στο PowerPoint με ψηφία ορθά αριστερά και περιστρεφόμενα δεξιά.](vertical_date.png)

## **Ορισμός προσαρμοσμένης περιστροφής για πλαίσια κειμένου**

Χρησιμοποιήστε το [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) για να ορίσετε προσαρμοσμένη γωνία περιστροφής για ένα [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).

Το παρακάτω παράδειγμα κώδικα περιστρέφει το πλαίσιο κειμένου κατά 3 μοίρες δεξιά μέσα στο σχήμα:

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

![Η προσαρμοσμένη περιστροφή του κειμένου](custom_text_rotation.png)

## **Ορισμός απόστασης γραμμών παραγράφων**

Το Aspose.Slides παρέχει τα [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) και [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) για έλεγχο της απόστασης παραγράφων. Αυτά τα χαρακτηριστικά χρησιμοποιούνται ως εξής:

* Χρησιμοποιήστε θετική τιμή για να ορίσετε την απόσταση γραμμής ως ποσοστό του ύψους της γραμμής.
* Χρησιμοποιήστε αρνητική τιμή για να ορίσετε την απόσταση γραμμής σε σημεία.

Το παρακάτω παράδειγμα ορίζει την απόσταση εντός της πρώτης παραγράφου στο 200 % του ύψους της γραμμής (διπλή απόσταση):

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

![Η απόσταση γραμμής μέσα στην παράγραφο](line_spacing.png)

## **Έλεγχος αλλαγής γραμμής**

Οι κανόνες αλλαγής γραμμής παραγράφων είναι χρήσιμοι σε στενά μπλοκ κειμένου και παρουσιάσεις που αναμειγνύουν λατινικό και ανατολικοασιατικό κείμενο. Οι παρακάτω μέθοδοι ανήκουν στο [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/), έτσι εφαρμόζονται σε ολόκληρη την παράγραφο:

- Το [setLatinLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) ελέγχει τους κανόνες αλλαγής γραμμής για λατινικό κείμενο. Σε μεικτό κείμενο, η αλλαγή του μπορεί επίσης να επηρεάσει το πού περιβάλλει το ανατολικοασιατικό κείμενο και η στίξη αναδιπλώνεται.
- Το [setEastAsianLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) ελέγχει τους κανόνες αλλαγής γραμμής για ανατολικοασιατικό κείμενο, συμπεριλαμβανομένων περιορισμών στα χαρακτήρες στην αρχή και το τέλος μιας γραμμής.

Αυτοί οι κανόνες δεν αντικαθιστούν το [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText), το οποίο ενεργοποιεί αυτόματη αναδίπλωση μέσα σε πλαίσιο κειμένου. Επηρεάζουν τη διάταξη όταν συμβαίνει η αναδίπλωση· δεν εισάγουν χαρακτήρες αλλαγής γραμμής. Μια ρητή αλλαγή γραμμής αναγκάζει νέα γραμμή στην παράγραφο ανεξάρτητα από το διαθέσιμο πλάτος.

Το παρακάτω αυτοτελές παράδειγμα δημιουργεί ένα στενό μπλοκ κειμένου που περιέχει κινέζικο και λατινικό κείμενο. Ορίζει και τις δύο επιλογές αλλαγής γραμμής ρητά και αποθηκεύει το “line_breaking.pptx”. Για να πειραματιστείτε με οποιονδήποτε κανόνα, αλλάξτε την αντίστοιχη τιμή διατηρώντας τις άλλες ρυθμίσεις σταθερές. Το παράδειγμα χρησιμοποιεί Arial 24 σημείων και SimSun με πλάτος πλαισίου 160 σημείων και μηδενικά οριζόντια περιθώρια πλαισίου κειμένου. Το [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) καλείται με [TextAutofitType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/) ώστε το μέγεθος κειμένου και οι διαστάσεις πλαισίου να παραμείνουν σταθερά.

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

## **Έλεγχος εκκρεμούς στίξης**

Το [ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) επιτρέπει σε κατάλληλη στίξη να επεκταθεί πέρα από την δεξιά άκρη της γραμμής κειμένου αντί να καταλαμβάνει την επόμενη γραμμή. Ισχύει για ολόκληρη την παράγραφο και διαφέρει από την κρεμαστή εσοχή.

Το παρακάτω αυτοτελές παράδειγμα ενεργοποιεί την εκκρεμούσα στίξη σε πλαίσιο κειμένου πλάτους 100 σημεία και αποθηκεύει το “hanging_punctuation.pptx”. Με Arial 24 σημείων και μηδενικά οριζόντια περιθώρια πλαισίου κειμένου, η τελική τελεία παραμένει μετά τη λέξη “sentence” και εκτείνεται πέρα από το δεξιό άκρο του κειμένου. Ορίστε την ιδιότητα σε [NullableBool::False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) για σύγκριση: με αυτές τις ρυθμίσεις, η τελεία καταλαμβάνει ξεχωριστή γραμμή. Η αναδίπλωση είναι ενεργή και η αυτόματη προσαρμογή απενεργοποιημένη για να διατηρηθεί το διαθέσιμο πλάτος σταθερό.

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

Δεν μπορεί να εκκρεμήσει κάθε χαρακτήρας στίξης. Οι [συνθήκες γραμματοσειράς και διάταξης που περιγράφονται παραπάνω](#control-line-breaking) ισχύουν επίσης για αυτήν τη σύγκριση: η αλλαγή της γραμματοσειράς, του διαθέσιμου πλάτους, των περιθωρίων ή των ρυθμίσεων αυτόματης προσαρμογής μπορεί να αφαιρέσει τη διακριτή διαφορά.

## **Ορισμός τύπου αυτόματης προσαρμογής για πλαίσια κειμένου**

Το [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) καθορίζει πώς συμπεριφέρεται το κείμενο όταν ξεπερνά τα όρια του περιέκτη του. Χρησιμοποιήστε το για να ελέγξετε αν το κείμενο συμπιέζεται, υπερχειλίζει ή το σχήμα αλλάζει αυτόματα μέγεθος. Το παρακάτω παράδειγμα ρυθμίζει το σχήμα ώστε να επαναπροσδιορίζεται ώστε να χωρά το κείμενο και αποθηκεύει το αποτέλεσμα στο “autofit_type.pptx”.

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

Για να μετρήσετε τις γραμμές μετά την αυτόματη αναδίπλωση και να δείτε πώς αλλάζει το πλάτος του κειμένου ή του σχήματος, δείτε [Καταμέτρηση αποδιδόμενων γραμμών](/slides/el/php-java/manage-paragraph/). Η μόνη η καταμέτρηση γραμμών δεν υποδεικνύει αν το κείμενο υπερχειλίζει το περιέκτη του.

## **Ορισμός αγκύρωσης πλαισίων κειμένου**

Το [TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType) ορίζει πώς το κείμενο τοποθετείται κάθετα μέσα σε σχήμα, π.χ. στην κορυφή, στο κέντρο ή στο κάτω μέρος. Το παρακάτω παράδειγμα αγκυρώνει το κείμενο στο κάτω μέρος του πρώτου σχήματος και αποθηκεύει το αποτέλεσμα στο “text_anchor.pptx”.

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

## **Ορισμός στηλοθετών κειμένου**

Χρησιμοποιήστε τα [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) και [ParagraphFormat::getTabs](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getTabs) για να διαμορφώσετε τα σημεία στήλης σε μια παράγραφο. Το παρακάτω παράδειγμα ορίζει το προεπιλεγμένο διάστημα στηλοθέτη στα 100 σημεία και προσθέτει ένα αριστερά ευθυγραμμισμένο σημείο στήλης στα 30 σημεία. Αυτές οι ρυθμίσεις επηρεάζουν το κείμενο που περιέχει χαρακτήρες στήλης.

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

![Οι στηλοθέτες της παραγράφου](paragraph_tabs.png)

## **Ορισμός γλώσσας ελέγχου ορθογραφίας**

Το Aspose.Slides παρέχει το [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId), το οποίο επιτρέπει τον ορισμό της γλώσσας ελέγχου ορθογραφίας για μια περιοχή κειμένου. Η γλώσσα ελέγχου ορθογραφίας καθορίζει τη γλώσσα που χρησιμοποιείται για ελέγχους ορθογραφίας και γραμματικής στο PowerPoint.

Το παρακάτω παράδειγμα απαιτεί το “presentation.pptx” με ένα πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον μία παράγραφο. Αντικαθιστά το περιεχόμενο της πρώτης παραγράφου με “1。”, ορίζει το SimSun ως γραμματοσειρά του και εκχωρεί τη γλώσσα ελέγχου ορθογραφίας απλού Κινέζου (`zh-CN`). Αποθηκεύει το αποτέλεσμα στο “proofing_language.pptx”:

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

### **Αντιγραφή μεταδεδομένων γλώσσας**

Κατά την αντιγραφή πολυγλωσσικού κειμένου από πρότυπο, διατηρήστε τόσο το [BasePortionFormat::getLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getLanguageId) όσο και το [BasePortionFormat::getAlternativeLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). Το παρακάτω αυτοτελές παράδειγμα δημιουργεί μια πηγή περιοχής με αγγλική γλώσσα ΗΠΑ ως γλώσσα και γαλλική ως εναλλακτική γλώσσα και αντιγράφει το κείμενο και τους ταυτοποιητές σε μια περιοχή σε νέα παρουσίαση.

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$source = new Portion("Hello! Bonjour!");
$source->getPortionFormat()->setLanguageId("en-US");
$source->getPortionFormat()->setAlternativeLanguageId("fr-FR");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $destination = new Portion();
    $destination->setText($source->getText());
    $destination->getPortionFormat()->setLanguageId($source->getPortionFormat()->getLanguageId());
    // Εάν η πηγή δεν έχει εναλλακτική γλώσσα, το null διαγράφει την τιμή του προορισμού.
    $destination->getPortionFormat()->setAlternativeLanguageId($source->getPortionFormat()->getAlternativeLanguageId());
    $paragraph->getPortions()->add($destination);

    $presentation->save("copied_language_metadata.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Για να δοκιμάσετε μια πηγή χωρίς εναλλακτική γλώσσα, παραλείψτε την ανάθεση του `"fr-FR"`. Τότε ο εναλλακτικός ταυτοποιητής είναι `null` και η ίδια εντολή αντιγραφής διατηρεί την απουσία του χωρίς την εισαγωγή προεπιλεγμένης τιμής, ακόμη και αν ο προορισμός είχε ήδη εναλλακτική γλώσσα ορισμένη.

Αυτοί οι ταυτοποιητές αποθηκεύουν μεταδεδομένα γλώσσας. Η διατήρησή τους δεν καθορίζει ποιο λεξικό το PowerPoint θα χρησιμοποιήσει για ελέγχους ορθογραφίας ή γραμματικής.

## **Ορισμός προεπιλεγμένης γλώσσας**

Χρησιμοποιήστε το [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) για να ορίσετε τη προεπιλεγμένη γλώσσα για κείμενο που δημιουργείται κατά τη φόρτωση ή τη δημιουργία παρουσίασης. Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση με αγγλική γλώσσα ΗΠΑ ως προεπιλεγμένη γλώσσα κειμένου, προσθέτει ένα πλαίσιο κειμένου και εκτυπώνει `en-US` για την πρώτη περιοχή κειμένου.

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

    // Ελέγξτε τη γλώσσα της πρώτης περιοχής.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **Ορισμός προεπιλεγμένου στυλ κειμένου**

Για να εφαρμόσετε προεπιλεγμένη μορφοποίηση κειμένου στο επίπεδο παρουσίασης, χρησιμοποιήστε το [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDefaultTextStyle).

Το παρακάτω παράδειγμα ορίζει γραμματοσειρά 14 σημείων εντονα ως προεπιλογή για παραγράφους κορυφαίου επιπέδου σε νέα παρουσίαση και το αποθηκεύει στο “default_text_style.pptx”. Το κείμενο μπορεί να κληρονομήσει αυτές τις προεπιλογές εκτός αν πιο συγκεκριμένη μορφοποίηση τις αντικαταστήσει.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // Λάβετε τη μορφοποίηση παραγράφου κορυφαίου επιπέδου.
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

## **Εξαγωγή κειμένου με το εφέ Όλα Κεφαλαία**

Στο PowerPoint, η εφαρμογή του εφέ γραμματοσειράς **All Caps** κάνει το κείμενο να εμφανίζεται με κεφαλαία γράμματα στη διαφάνεια ακόμη κι αν αρχικά πληκτρολογήθηκε με πεζά. Όταν ανακτάτε μια τέτοια περιοχή κειμένου με το Aspose.Slides, η βιβλιοθήκη επιστρέφει το κείμενο ακριβώς όπως εισήχθη. Για να ταιριάξετε το εμφανιζόμενο κείμενο, ελέγξτε το [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/) και μετατρέψτε τη επιστρεφόμενη συμβολοσειρά σε κεφαλαία όταν η τιμή είναι `All`.

Αυτό το παράδειγμα απαιτεί το “sample2.pptx” με ένα πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια. Στην πρώτη παράγραφο της πρώτης περιοχής περιέχεται το κείμενο “Hello, Aspose!” με το εφέ All Caps ενεργό, όπως φαίνεται παρακάτω.

![Το εφέ Όλα Κεφαλαία](all_caps_effect.png)

Ο κώδικας παρακάτω δείχνει πώς να εξαγάγετε το κείμενο με το εφέ **All Caps** εφαρμοσμένο:

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

Έξοδος:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **ΣΥ.Α.Ε.**

**Πώς μπορώ να τροποποιήσω το κείμενο σε πίνακα σε μια διαφάνεια;**

Για να τροποποιήσετε το κείμενο σε πίνακα σε μια διαφάνεια, χρησιμοποιήστε το [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/). Διατρέξτε τα κελιά και ενημερώστε το κάθε κελί μέσω του [Cell::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/#getTextFrame) και της μορφοποίησης παραγράφων μέσω του [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat).

**Πώς να εφαρμόσετε χρώμα διαβάσματος σε κείμενο σε διαφάνεια PowerPoint;**

Για να εφαρμόσετε χρώμα διαβάσματος σε κείμενο, χρησιμοποιήστε το [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat). Ορίστε το [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) σε [FillType::Gradient](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) και ρυθμίστε τα διαβάσματα διαβάσματος.