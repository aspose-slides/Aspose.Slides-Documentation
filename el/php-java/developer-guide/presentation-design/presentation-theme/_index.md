---
title: Διαχείριση θεμάτων παρουσίασης σε PHP
linktitle: Θέμα παρουσίασης
type: docs
weight: 10
url: /el/php-java/presentation-theme/
keywords:
- Θέμα PowerPoint
- Θέμα παρουσίασης
- Θέμα διαφάνειας
- Ορισμός θέματος
- Αλλαγή θέματος
- Διαχείριση θέματος
- Χρώμα θέματος
- Επιπλέον παλέτα
- Γραμματοσειρά θέματος
- Στυλ θέματος
- Εφέ θέματος
- PowerPoint
- OpenDocument
- Παρουσίαση
- PHP
- Aspose.Slides
description: "Κύρια θέματα παρουσίασης στο Aspose.Slides για PHP μέσω Java για τη δημιουργία, προσαρμογή και μετατροπή αρχείων PowerPoint με συνεπή εταιρική ταυτότητα."
---
## **Εισαγωγή**

Ένα θέμα παρουσίασης ορίζει ένα συντονισμένο σύνολο χρωμάτων, γραμματοσειρών, στυλ υποβάθρου, γεμίσματα, γραμμές και εφέ. Τα αντικείμενα που είναι ευαίσθητα στο θέμα αναφέρονται σε αυτές τις κοινές ορισμούς αντί να αποθηκεύουν κάθε οπτική ιδιότητα ως σταθερή τιμή, έτσι μια αλλαγή θέματος μπορεί να ενημερώσει πολλά αντικείμενα ταυτόχρονα.

Στο Aspose.Slides, το θέμα σε επίπεδο παρουσίασης είναι διαθέσιμο μέσω του [Presentation.getMasterTheme](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/). Μια παρουσίαση μπορεί επίσης να περιέχει παρακάμψεις θέματος σε χαμηλότερα επίπεδα. Ένας master μπορεί να παρακάμψει το θέμα της παρουσίασης μέσω του [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterthememanager/), ενώ μια διάταξη ή μια μεμονωμένη διαφάνεια μπορεί να παρακάμψει το κληρονομημένο θέμα της μέσω του [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseoverridethememanager/). Στην πράξη, το αποτελεσματικό θέμα για μια διαφάνεια επιλύεται μέσω αυτής της αλυσίδας κληρονομικότητας: θέμα παρουσίασης, παράκαμψη master, παράκαμψη διάταξης και παράκαμψη διαφάνειας.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Οι ενότητες παρακάτω δείχνουν τις πιο κοινές ροές εργασίας με θέμα: επιθεώρηση ενός θέματος, αλλαγή χρωμάτων και γραμματοσειρών, αντιγραφή ή εφαρμογή θέματος, ενημέρωση στυλ υποβάθρου και εφέ, και ανάγνωση των αποτελεσματικών τιμών μετά την κληρονομικότητα και τις παρακάμψεις.

## **Επιθεώρηση θέματος**

Το αντικείμενο [MasterTheme](https://reference.aspose.com/slides/el/php-java/aspose.slides/mastertheme/) εκθέτει το χρωματικό σχήμα του θέματος, το σχήμα γραμματοσειράς και το σχήμα μορφοποίησης μέσω των [MasterTheme.getColorScheme](https://reference.aspose.com/slides/el/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/el/php-java/aspose.slides/mastertheme/) και [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/el/php-java/aspose.slides/mastertheme/). Η επιθεώρηση αυτών των συλλογών πριν από τις αλλαγές είναι ιδιαίτερα χρήσιμη όταν μια παρουσίαση προέρχεται από εξωτερική πηγή, επειδή ο αριθμός και το περιεχόμενο των καταχωρήσεων στυλ μπορεί να διαφέρουν.

Το παρακάτω παράδειγμα διαβάζει τις κύριες ιδιότητες του θέματος και αναφέρει πόσες στυλ υποβάθρου, γεμίσματος, γραμμής και εφέ αποθηκεύονται στο θέμα:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $theme = $presentation->getMasterTheme();
    echo "Theme name: " . $theme->getName() . PHP_EOL;
    echo "Accent 1: " . $theme->getColorScheme()->getAccent1()->getColor() . PHP_EOL;
    echo "Major Latin font: " . $theme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Minor Latin font: " . $theme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Background fill styles: " . java_values($theme->getFormatScheme()->getBackgroundFillStyles()->size()) . PHP_EOL;
    echo "Fill styles: " . java_values($theme->getFormatScheme()->getFillStyles()->size()) . PHP_EOL;
    echo "Line styles: " . java_values($theme->getFormatScheme()->getLineStyles()->size()) . PHP_EOL;
    echo "Effect styles: " . java_values($theme->getFormatScheme()->getEffectStyles()->size()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Αν ένα αρχείο χρησιμοποιεί πολλαπλούς masters, μην υποθέτετε ότι κάθε διαφάνεια έχει το ίδιο αποτελεσματικό θέμα. Επιθεωρήστε τον master που σχετίζεται με τη διαφάνεια και χρησιμοποιήστε τη ροή εργασίας αποτελεσματικού‑θέματος που εμφανίζεται αργότερα σε αυτό το άρθρο όταν μπορεί να υπάρξουν παρακάμψεις διάταξης ή διαφάνειας.

## **Αλλαγή χρωμάτων θέματος**

Τα γεμίσματα, οι γραμμές και το κείμενο που είναι ευαίσθητα στο θέμα μπορούν να αναφέρονται σε λογικό χρώμα από την απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/php-java/aspose.slides/schemecolor/). Όταν αλλάζετε την αντίστοιχη καταχώρηση στην [ColorScheme](https://reference.aspose.com/slides/el/php-java/aspose.slides/colorscheme/), όλα τα αντικείμενα που εξακολουθούν να αναφέρονται σε εκείνο το χρώμα θέματος επιλύονται με την νέα τιμή. Τα αντικείμενα που χρησιμοποιούν άμεσο χρώμα RGB δεν αλλάζουν με μια ενημέρωση χρώματος θέματος.

Το παρακάτω ολοκληρωμένο παράδειγμα δημιουργεί ένα σχήμα που χρησιμοποιεί `Accent4`, αλλάζει το χρώμα `Accent4` του θέματος σε κόκκινο, αποθηκεύει την παρουσίαση, την ανοίγει ξανά και εκτυπώνει το αποτελεσματικό χρώμα γεμίσματος:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $presentation->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
    $presentation->save("theme-color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("theme-color.pptx");
try {
    $savedSlide = $savedPresentation->getSlides()->get_Item(0);
    $savedShape = $savedSlide->getShapes()->get_Item(0);
    $effectiveColor = $savedShape->getFillFormat()->getEffective()->getSolidFillColor();
    echo sprintf("Effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
} finally {
    $savedPresentation->dispose();
}
```

Επειδή το ορθογώνιο παραμένει συνδεδεμένο με το `Accent4`, το ορατό του χρώμα γίνεται κόκκινο μετά την αλλαγή του θέματος. Αν αντικαταστήσετε το χρώμα σχήματος με άμεσο χρώμα στο σχήμα, οι επόμενες αλλαγές στο `Accent4` δεν θα επηρεάσουν πια αυτό το γέμισμα.

### **Χρήση χρωμάτων από την επιπλέον παλέτα**

Το PowerPoint δημιουργεί πιο ανοιχτές και πιο σκούρες παραλλαγές από ένα χρώμα θέματος εφαρμόζοντας μετασχηματισμούς χρώματος. Το Aspose.Slides εκθέτει αυτούς τους μετασχηματισμούς μέσω της απαρίθμησης [ColorTransformOperation](https://reference.aspose.com/slides/el/php-java/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - Κύρια χρώματα θέματος.

**2** - Πιο ανοιχτές και πιο σκούρες παραλλαγές που παράγονται από τα κύρια χρώματα θέματος.

Το παρακάτω παράδειγμα δημιουργεί έξι ορθογώνια βασισμένα στο `Accent4`, εφαρμόζει μετασχηματισμούς φωτεινότητας σε πέντε από αυτά και αποθηκεύει το αποτέλεσμα:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.8);

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.6);

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.4);

    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.75);

    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.5);

    $presentation->save("theme-color-palette.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Αυτές οι παραλλαγές παραμένουν βασισμένες στο χρώμα θέματος. Αν το `Accent4` αλλάξει αργότερα, τα μετασχηματισμένα χρώματα υπολογίζονται ξανά από τη νέα τιμή του `Accent4`.

### **Ανάθεση τιμών SchemeColor σε θέσεις ColorScheme**

Η απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/php-java/aspose.slides/schemecolor/) χρησιμοποιεί τα `Text1`, `Background1`, `Text2` και `Background2`, ενώ η [ColorScheme](https://reference.aspose.com/slides/el/php-java/aspose.slides/colorscheme/) εκθέτει τις ίδιες θέσεις θέματος ως `Dark1`, `Light1`, `Dark2` και `Light2`. Η αντιστοίχηση είναι σταθερή:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Αυτά είναι εναλλακτικά ονόματα για τις ίδιες θέσεις θέματος· δεν αποτελούν τιμές που μετατρέπονται δυναμικά από τη μια μορφή στην άλλη.

## **Αλλαγή γραμματοσειρών θέματος**

Ένα σχήμα γραμματοσειρών θέματος περιέχει ένα κύριο σύνολο γραμματοσειρών για τίτλους και ένα δευτερεύον σύνολο για το σώμα του κειμένου. Οι μέθοδοι [FontScheme.getMajor](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontscheme/) και [FontScheme.getMinor](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontscheme/) εκθέτουν αυτά τα σύνολα.

Οι αναγνωριστικοί γραμματοσειρών θέματος συμβατοί με PowerPoint μπορούν να χρησιμοποιηθούν σε μορφοποίηση κειμένου:

* `+mn-lt` - Γραμματοσειρά σώματος Latin (Minor Latin Font)
* `+mj-lt` - Γραμματοσειρά τίτλου Latin (Major Latin Font)
* `+mn-ea` - Γραμματοσειρά σώματος East Asian (Minor East Asian Font)
* `+mj-ea` - Γραμματοσειρά τίτλου East Asian (Major East Asian Font)

Το παρακάτω παράδειγμα δημιουργεί έναν τίτλο που χρησιμοποιεί τη βασική Latin γραμματοσειρά θέματος και μία γραμμή σώματος που χρησιμοποιεί τη δευτερεύουσα Latin γραμματοσειρά θέματος. Στη συνέχεια αλλάζει τις γραμματοσειρές θέματος και αποθηκεύει το αποτέλεσμα:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $heading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 500, 60);
    $heading->getTextFrame()->setText("Theme heading");
    $heading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mj-lt"));

    $body = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 120, 500, 60);
    $body->getTextFrame()->setText("Theme body text");
    $body->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $presentation->getMasterTheme()->getFontScheme()->getMajor()->setLatinFont(new FontData("Aptos Display"));
    $presentation->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
    $presentation->save("theme-fonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ο τίτλος ακολουθεί τη βασική γραμματοσειρά και το κείμενο σώματος ακολουθεί τη δευτερεύουσα γραμματοσειρά. Κείμενο που έχει ρητό όνομα γραμματοσειράς αντί για αναγνωριστικό θέματος δεν θα αλλάξει αυτόματα όταν αλλάξει το σχήμα γραμματοσειρών θέματος.

{{% alert color="info" title="Tip" %}}
Για περισσότερες πληροφορίες σχετικά με τις γραμματοσειρές παρουσίασης, δείτε το [PowerPoint Fonts](/slides/el/php-java/powerpoint-fonts/).
{{% /alert %}}

## **Αντιγραφή ή εφαρμογή θέματος**

Υπάρχουν δύο κοινές ροές εργασίας, και λύνουν διαφορετικά προβλήματα.

### **Διατήρηση πηγαίου θέματος κατά τη μετακίνηση διαφανειών**

Αν θέλετε να μετακινήσετε μια διαφάνεια σε άλλη παρουσίαση και να διατηρήσετε το αρχικό της σχέδιο, κλωνοποιήστε τον πηγαίο master στην προορισμένη παρουσίαση με το [MasterSlideCollection.addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslidecollection/), έπειτα κλωνοποιήστε τη διαφάνεια με το [SlideCollection.addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidecollection/) και τον κλωνοποιημένο master. Αυτό μεταφέρει μαζί του τον master, τις διατάξεις του και το σχετικό θέμα.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $sourceSlide = $source->getSlides()->get_Item(0);
        $sourceMaster = $sourceSlide->getLayoutSlide()->getMasterSlide();
        $clonedMaster = $target->getMasters()->addClone($sourceMaster);
        $target->getSlides()->addClone($sourceSlide, $clonedMaster, true);
        $target->save("theme-preserved.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Αυτή είναι η προτιμώμενη ροή εργασίας όταν η πηγαία διαφάνεια πρέπει να φαίνεται τα ίδια στο προορισμό. Η απλή κλωνοποίηση περιεχομένου σε έναν μη σχετικό master προορισμού μπορεί να αλλάξει χρώματα, γραμματοσειρές, υπόβαθρα και εφέ που καθοδηγούνται από το θέμα.

### **Εφαρμογή τιμών θέματος σε υπάρχουσα διαφάνεια**

Αν η διαφάνεια-στόχος πρέπει να παραμείνει στον τρέχοντα master και διάταξή της, αρχικοποιήστε μια παρακάμψη επιπέδου διαφάνειας από το πηγαίο θέμα. Οι μέθοδοι [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/el/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/el/php-java/aspose.slides/overridetheme/) και [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/el/php-java/aspose.slides/overridetheme/) αντιγράφουν τα τρία κύρια στοιχεία του θέματος στην παρακάμψη.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-slide.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Αυτή η ενέργεια αλλάζει το θέμα που χρησιμοποιεί η συγκεκριμένη διαφάνεια χωρίς να αλλάζει το θέμα που κληρονομούν οι άλλες διαφάνειες. Για να αφαιρέσετε την τοπική παρακάμψη και να επιστρέψετε στις κληρονομημένες τιμές, καλέστε το [OverrideTheme.clear](https://reference.aspose.com/slides/el/php-java/aspose.slides/overridetheme/).

### **Εφαρμογή παρακάμψης θέματος σε διάταξη**

Μια παρακάμψη σε επίπεδο διάταξης εφαρμόζεται στις διαφάνειες που χρησιμοποιούν εκείνη τη διάταξη, εκτός αν μια συγκεκριμένη διαφάνεια έχει τη δική της παρακάμψη. Οι ίδιες μέθοδοι αρχικοποίησης μπορούν να χρησιμοποιηθούν μέσω του [LayoutSlideThemeManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslidethememanager/):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getLayoutSlide()->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-layout.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Χρησιμοποιήστε ένα θέμα σε επίπεδο master ή παρουσίασης όταν πολλές διατάξεις και διαφάνειες πρέπει να μοιράζονται το ίδιο βασικό σχέδιο, μια παρακάμψη διάταξης όταν μια οικογένεια διατάξεων χρειάζεται διαφορετικό στυλ, και μια παρακάμψη διαφάνειας μόνο για πραγματικές εξαιρέσεις. Οι υπερβολικές παρακάμψεις σε επίπεδο διαφάνειας δυσκολεύουν την πρόβλεψη μελλοντικών παγκόσμιων αλλαγών θέματος.

## **Ενημέρωση στυλ υποβάθρου θέματος**

Τα γεμίσματα υποβάθρου του θέματος αποθηκεύονται στη μέθοδο [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/el/php-java/aspose.slides/formatscheme/). Το PowerPoint μπορεί να παρουσιάσει περισσότερες επιλογές υποβάθρου στην διεπαφή του απ' ό,τι είναι οι καταχωρήσεις γεμίσματος που αποθηκεύονται φυσικά σε αυτή τη συλλογή, επειδή η διεπαφή μπορεί να συνδυάσει γεμίσματα θέματος με χρώματα θέματος και άλλες αναφορές στυλ.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Πριν χρησιμοποιήσετε ένα στυλ υποβάθρου, εξετάστε τη συλλογή που αποθηκεύεται και το τρέχον [Background.getStyleIndex](https://reference.aspose.com/slides/el/php-java/aspose.slides/background/). Ένας δείκτης στυλ `0` σημαίνει ότι δεν υπάρχει θεματικό γέμισμα· θετικές τιμές είναι αναφορές στυλ υποβάθρου θέματος. Αυτό είναι διαφορετικό από την ευθεία δεικτοδότηση της συλλογής PHP, όπου `get_Item(0)` σημαίνει το πρώτο αποθηκευμένο στοιχείο. Μην υποθέτετε ότι κάθε παρουσίαση περιέχει τον ίδιο αριθμό στυλ γεμίσματος υποβάθρου.

Το παρακάτω παράδειγμα αναφέρει τον διαθέσιμο αριθμό γεμισμάτων υποβάθρου, εκχωρεί μια θεματική αναφορά υποβάθρου στον πρώτο master και αποθηκεύει την παρουσίαση:

```php
use aspose\slides\BackgroundType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $backgroundStyleCount = java_values($presentation->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size());
    echo "Background fill styles: " . $backgroundStyleCount . PHP_EOL;
    if ($backgroundStyleCount === 0) {
        throw new RuntimeException("The presentation theme does not contain background fill styles.");
    }

    $masterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlide->getBackground()->setType(BackgroundType::Themed);
    $masterSlide->getBackground()->setStyleIndex(1);
    $presentation->save("theme-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το οπτικό αποτέλεσμα εξαρτάται από την καταχώριση θέματος που αναφέρεται από τον master και από τυχόν παρακάμψεις υποβάθρου στη διάταξη ή στο επίπεδο διαφάνειας. Αν μια διαφάνεια χρησιμοποιεί το δικό της υπόβαθρο, η αλλαγή μόνο του υποβάθρου του master μπορεί να μην επηρεάσει αυτή τη διαφάνεια. Χρησιμοποιήστε το [Background.getEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/background/) όταν χρειάζεται να γνωρίζετε το τελικό υπόβαθρο μετά την εφαρμογή κληρονομικότητας.

{{% alert color="warning" title="Warning" %}}
Μην αντιμετωπίζετε τον δείκτη στυλ ως μηδενική βάση δείκτη συλλογής. Επίσης, αποφύγετε την σκληρή κωδικοποίηση ενός αριθμού στυλ από ένα αρχείο και την υπόθεση ότι θα έχει την ίδια εμφάνιση σε άλλο αρχείο· οι ορισμοί στυλ θέματος είναι ειδικοί για κάθε παρουσίαση.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Για άμεση μορφοποίηση υποβάθρου και κληρονομικότητα υποβάθρου, δείτε το [Presentation Background](/slides/el/php-java/presentation-background/).
{{% /alert %}}

## **Ενημέρωση εφέ θέματος**

Ένα σχήμα μορφοποίησης θέματος περιέχει ξεχωριστές συλλογές γεμίσματος, γραμμής και εφέ που εκτίθενται μέσω των [FormatScheme.getFillStyles](https://reference.aspose.com/slides/el/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/el/php-java/aspose.slides/formatscheme/) και [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/el/php-java/aspose.slides/formatscheme/). Τα τυπικά θέματα Office συχνά περιέχουν τρεις κύριες καταχωρίσεις στυλ που αντιστοιχούν οπτικά σε ήπια, μέτρια και έντονη μορφοποίηση, αλλά ο κώδικας πρέπει να ελέγχει κάθε συλλογή αντί να υποθέτει σταθερό αριθμό.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Όταν προσπελάζετε αυτές τις συλλογές σε PHP, ο δείκτης της συλλογής είναι μηδενικής βάσης: `get_Item(0)` είναι το πρώτο αποθηκευμένο στυλ και `get_Item(2)` το τρίτο. Οι δείκτες αναφοράς στυλ ενός σχήματος είναι ξεχωριστή έννοια, που εκτίθεται μέσω του [ShapeStyle](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapestyle/). Η τροποποίηση ενός στυλ θέματος επηρεάζει τα σχήματα που παραπέμπουν σε αυτό το στυλ θέματος· τα σχήματα με άμεση μορφοποίηση μπορεί να παραμείνουν αμετάβλητα.

Το παρακάτω παράδειγμα ελέγχει αν οι απαιτούμενες καταχωρήσεις στυλ υπάρχουν, αλλάζει το πρώτο στυλ γραμμής, αλλάζει το τρίτο στυλ γεμίσματος, ενεργοποιεί μια εξωτερική σκιά στο τρίτο στυλ εφέ και αποθηκεύει το αποτέλεσμα:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    $formatScheme = $presentation->getMasterTheme()->getFormatScheme();
    if (java_values($formatScheme->getLineStyles()->size()) < 1 || java_values($formatScheme->getFillStyles()->size()) < 3 || java_values($formatScheme->getEffectStyles()->size()) < 3) {
        throw new RuntimeException("The theme does not contain the style entries required by this example.");
    }

    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->setFillType(FillType::Solid);
    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $formatScheme->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $formatScheme->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(new Java("java.awt.Color", 34, 139, 34));
    $effectFormat = $formatScheme->getEffectStyles()->get_Item(2)->getEffectFormat();
    $effectFormat->enableOuterShadowEffect();
    $effectFormat->getOuterShadowEffect()->setDistance(10.0);
    $presentation->save("theme-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Για σχήματα που παραπέμπουν σε αυτές τις θέσεις, το πρώτο στυλ γραμμής θέματος γίνεται κόκκινο, το τρίτο στυλ γεμίσματος θέματος γίνεται συμπαγές δάσος πράσινο, και το τρίτο στυλ εφέ αποκτά εξωτερική σκιά με απόσταση 10 σημεία. Το ακριβές οπτικό αποτέλεσμα εξαρτάται ακόμη από το ποια θέσεις στυλ παραπέμπει κάθε σχήμα και αν η άμεση μορφοποίηση υπερισχύει του θέματος.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Ανάγνωση αποτελεσματικών τιμών θέματος**

Αυτές οι ακατέργαστες αντικείμενα θέματος σας λένε τι είναι ορισμένο σε ένα συγκεκριμένο επίπεδο. Οι αποτελεσματικές τιμές σας λένε τι χρησιμοποιεί πραγματικά μια διαφάνεια ή ένα σχήμα μετά την κληρονομικότητα και τις τοπικές παρακάμψεις. Για μια διαφάνεια, καλέστε το [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseoverridethememanager/). Για ένα υπόβαθρο, χρησιμοποιήστε το [Background.getEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/background/), και για ένα γέμισμα, το [FillFormat.getEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/fillformat/).

Το παρακάτω παράδειγμα διαβάζει το αποτελεσματικό θέμα, το υπόβαθρο και το πρώτο γέμισμα σχήματος από μια διαφάνεια:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $effectiveTheme = $slide->getThemeManager()->createThemeEffective();
    $effectiveBackground = $slide->getBackground()->getEffective();
    echo "Effective major Latin font: " . $effectiveTheme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective minor Latin font: " . $effectiveTheme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective background fill type: " . java_values($effectiveBackground->getFillFormat()->getFillType()) . PHP_EOL;
    if (java_values($slide->getShapes()->size()) > 0) {
        $effectiveFill = $slide->getShapes()->get_Item(0)->getFillFormat()->getEffective();
        echo "First shape effective fill type: " . java_values($effectiveFill->getFillType()) . PHP_EOL;
        if (java_values($effectiveFill->getFillType()) == FillType::Solid) {
            $effectiveColor = $effectiveFill->getSolidFillColor();
            echo sprintf("First shape effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Χρησιμοποιήστε τα αποτελεσματικά δεδομένα για διαγνωστικά απόδοσης, επικύρωση και συγκρίσεις. Αν επιθεωρήσετε μόνο το [Presentation.getMasterTheme](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/), μπορεί να χάσετε ένα master, μια διάταξη, μια διαφάνεια ή μια παρακάμψη σχήματος που αλλάζει την τελική εμφάνιση.

## **Συχνές ερωτήσεις**

**Μπορώ να εφαρμόσω ένα θέμα σε μία μόνο διαφάνεια χωρίς να αλλάξω τον master;**

Ναι. Χρησιμοποιήστε τον [SlideThemeManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidethememanager/) της διαφάνειας και αρχικοποιήστε το θέμα παρακάμψης. Η αλλαγή παραμένει τοπική σε εκείνη τη διαφάνεια· οι άλλες διαφάνειες συνεχίζουν να κληρονομούν τα υπάρχοντα θέματα τους.

**Ποιος είναι ο πιο ασφαλής τρόπος για να μεταφέρω ένα θέμα από μια παρουσίαση σε άλλη;**

Κατά τη μετακίνηση μιας διαφάνειας και τη διατήρηση της αρχικής της εμφάνισης, κλωνοποιήστε τον πηγαίο master στον προορισμό και κλωνοποιήστε τη διαφάνεια με αυτόν τον master χρησιμοποιώντας τα [MasterSlideCollection.addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslidecollection/) και [SlideCollection.addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidecollection/). Αυτό διατηρεί μαζί του τον master, τις διατάξεις και το θέμα.

**Πώς μπορώ να δω τις αποτελεσματικές τιμές μετά την κληρονομικότητα και τις παρακάμψεις;**

Χρησιμοποιήστε το [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseoverridethememanager/) για ένα θέμα διαφάνειας ή διάταξης και τις αντίστοιχες μεθόδους αποτελεσματικών δεδομένων για αντικείμενα μορφοποίησης όπως το [Background.getEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/background/) και το [FillFormat.getEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/fillformat/). Αυτά τα API επιστρέφουν τις τιμές που έχουν επιλυθεί μετά την εφαρμογή κληρονομικότητας και παρακάμψεων.