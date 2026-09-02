---
title: Διαχείριση θεμάτων παρουσίασης σε PHP
linktitle: Θέμα Παρουσίασης
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
- Εξωτερικό θέμα
- THMX
- Χρώμα θέματος
- Πρόσθετη παλέτα
- Γραμματοσειρά θέματος
- Στυλ θέματος
- Εφέ θέματος
- PowerPoint
- OpenDocument
- Παρουσίαση
- PHP
- Aspose.Slides
description: "Διαχειριστείτε τα κύρια θέματα παρουσίασης στο Aspose.Slides για PHP μέσω Java, ώστε να δημιουργείτε, προσαρμόζετε και μετατρέπετε αρχεία PowerPoint με συνεπή επωνυμία."
---
## **Εισαγωγή**

Ένα θέμα παρουσίασης ορίζει ένα συντονισμένο σύνολο χρωμάτων, γραμματοσειρών, στυλ φόντου, γεμίσματος, γραμμών και εφέ. Τα αντικείμενα που είναι θέμα‑aware αναφέρονται σε αυτές τις κοινές ορισμούς αντί να αποθηκεύουν κάθε οπτική ιδιότητα ως σταθερή τιμή, ώστε μια αλλαγή θέματος να μπορεί να ενημερώνει πολλά αντικείμενα ταυτόχρονα.

Στο Aspose.Slides, το θέμα σε επίπεδο παρουσίασης είναι προσβάσιμο μέσω του [Presentation.getMasterTheme](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/). Μια παρουσίαση μπορεί επίσης να περιέχει παρακάμψεις θέματος σε χαμηλότερα επίπεδα. Ένας master μπορεί να παρακάμψει το θέμα παρουσίασης μέσω του [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterthememanager/), ενώ ένα layout ή μια μεμονωμένη διαφάνεια μπορεί να παρακάμψει το κληρονομημένο θέμα μέσω του [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseoverridethememanager/). Στην πράξη, το αποτελεσματικό θέμα για μια διαφάνεια επιλύεται μέσω αυτής της αλυσίδας κληρονομικότητας: θέμα παρουσίασης, παράκαμψη master, παράκαμψη layout και παράκαμψη διαφάνειας.

![Συστατικά του θέματος: χρώματα, γραμματοσειρές, στυλ φόντου και εφέ](theme-constituents.png)

Οι παρακάτω ενότητες δείχνουν τις πιο συνηθισμένες ροές εργασίας με τα θέματα: έλεγχος ενός θέματος, αλλαγή χρωμάτων και γραμματοσειρών, αντιγραφή ή εφαρμογή θέματος, ενημέρωση στυλ φόντου και εφέ, και ανάγνωση των αποτελεσματικών τιμών μετά την κληρονομικότητα και τις παρακάμψεις.

## **Έλεγχος Θέματος**

Το αντικείμενο [MasterTheme](https://reference.aspose.com/slides/el/php-java/aspose.slides/mastertheme/) εκθέτει το σχήμα χρωμάτων, το σχήμα γραμματοσειρών και το σχήμα μορφοποίησης του θέματος μέσω των [MasterTheme.getColorScheme](https://reference.aspose.com/slides/el/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/el/php-java/aspose.slides/mastertheme/) και [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/el/php-java/aspose.slides/mastertheme/). Η επιθεώρηση αυτών των συλλογών πριν τις αλλάξετε είναι ιδιαίτερα χρήσιμη όταν η παρουσίαση προέρχεται από εξωτερική πηγή, επειδή ο αριθμός και το περιεχόμενο των καταχωρήσεων στυλ μπορεί να διαφέρουν.

Το παρακάτω παράδειγμα διαβάζει τις κύριες ιδιότητες του θέματος και αναφέρει πόσες στυλ φόντου, γεμίσματος, γραμμής και εφέ αποθηκεύονται στο θέμα:

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

Αν ένα αρχείο χρησιμοποιεί πολλαπλούς masters, μην υποθέτετε ότι κάθε διαφάνεια έχει το ίδιο αποτελεσματικό θέμα. Ελέγξτε τον master που σχετίζεται με τη διαφάνεια και χρησιμοποιήστε τη ροή εργασίας αποτελεσματικού‑θέματος που εμφανίζεται αργότερα σε αυτό το άρθρο όταν μπορεί να υπάρχουν παρακάμψεις σε layout ή διαφάνειες.

## **Αλλαγή Χρωμάτων Θέματος**

Τα γεμίσματα, οι γραμμές και το κείμενο που είναι θέμα‑aware μπορούν να αναφέρονται σε λογικό χρώμα από την απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/php-java/aspose.slides/schemecolor/). Όταν αλλάζετε την αντίστοιχη καταχώρηση στην [ColorScheme](https://reference.aspose.com/slides/el/php-java/aspose.slides/colorscheme/), όλα τα αντικείμενα που εξακολουθούν να αναφέρονται σε αυτό το χρώμα θέματος επιλύονται με τη νέα τιμή. Τα αντικείμενα που χρησιμοποιούν άμεσο χρώμα RGB δεν αλλάζουν με την ενημέρωση χρώματος θέματος.

Το παρακάτω παράδειγμα end‑to‑end δημιουργεί ένα σχήμα που χρησιμοποιεί το `Accent4`, αλλάζει το χρώμα `Accent4` του θέματος σε κόκκινο, αποθηκεύει την παρουσίαση, την ανοίγει ξανά και εκτυπώνει το αποτελεσματικό χρώμα γεμίσματος:

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

Επειδή το ορθογώνιο παραμένει συνδεδεμένο με το `Accent4`, το ορατό του χρώμα γίνεται κόκκινο μετά την αλλαγή του θέματος. Αν αντικαταστήσετε το χρώμα σχήματος με άμεσο χρώμα, οι μεταγενέστερες αλλαγές στο `Accent4` δεν θα επηρεάζουν πλέον αυτό το γέμισμα.

### **Χρήση Χρωμάτων από το Πρόσθετο Παλέτο**

Το PowerPoint παράγει πιο φωτεινές και πιο σκούρες παραλλαγές από ένα χρώμα θέματος εφαρμόζοντας μετασχηματισμούς χρώματος. Το Aspose.Slides εκθέτει αυτούς τους μετασχηματισμούς μέσω της απαρίθμησης [ColorTransformOperation](https://reference.aspose.com/slides/el/php-java/aspose.slides/colortransformoperation/).

![Κύρια χρώματα θέματος και πιο φωτεινά/σκούρα χρώματα που παράγονται από το πρόσθετο παλέτο](additional-palette-colors.png)

**1** – Κύρια χρώματα θέματος.

**2** – Πιο φωτεινές και πιο σκούρες παραλλαγές που παράγονται από τα κύρια χρώματα θέματος.

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

Αυτές οι παραλλαγές παραμένουν βασισμένες στο χρώμα θέματος. Αν το `Accent4` αλλάξει αργότερα, τα μετασχηματισμένα χρώματα επαναϋπολογίζονται από τη νέα τιμή του `Accent4`.

### **Χαρτογράφηση Τιμών `SchemeColor` σε Θέσεις `ColorScheme`**

Η απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/php-java/aspose.slides/schemecolor/) χρησιμοποιεί τα `Text1`, `Background1`, `Text2` και `Background2`, ενώ η [ColorScheme](https://reference.aspose.com/slides/el/php-java/aspose.slides/colorscheme/) εκθέτει τις ίδιες θέσεις θέματος ως `Dark1`, `Light1`, `Dark2` και `Light2`. Η αντιστοίχηση είναι σταθερή:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Αυτά είναι εναλλακτικά ονόματα για τις ίδιες θέσεις θέματος· δεν πρόκειται για τιμές που μετατρέπονται δυναμικά από τη μία μορφή στην άλλη.

## **Αλλαγή Γραμματοσειρών Θέματος**

Ένα σχήμα γραμματοσειρών θέματος περιλαμβάνει ένα κύριο σύνολο γραμματοσειρών για επικεφαλίδες και ένα δευτερεύον σύνολο για το κύριο κείμενο. Οι μέθοδοι [FontScheme.getMajor](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontscheme/) και [FontScheme.getMinor](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontscheme/) εκθέτουν αυτά τα σύνολα.

Οι ταυτοποιητές γραμματοσειρών θέματος συμβατοί με PowerPoint μπορούν να χρησιμοποιηθούν στη μορφοποίηση κειμένου:

* `+mn‑lt` – Γραμματοσειρά σώματος Latin (Minor Latin Font)
* `+mj‑lt` – Γραμματοσειρά επικεφαλίδας Latin (Major Latin Font)
* `+mn‑ea` – Γραμματοσειρά σώματος Ανατολικής Ασίας (Minor East Asian Font)
* `+mj‑ea` – Γραμματοσειρά επικεφαλίδας Ανατολικής Ασίας (Major East Asian Font)

Το παρακάτω παράδειγμα δημιουργεί μια επικεφαλίδα που χρησιμοποιεί τη μεγάλη γραμματοσειρά Latin του θέματος και μια γραμμή σώματος που χρησιμοποιεί τη μικρή γραμματοσειρά Latin του θέματος. Στη συνέχεια αλλάζει τις γραμματοσειρές θέματος και αποθηκεύει το αποτέλεσμα:

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

Η επικεφαλίδα ακολουθεί τη μεγάλη γραμματοσειρά και το κείμενο σώματος ακολουθεί τη μικρή γραμματοσειρά. Κείμενο που έχει ρητό όνομα γραμματοσειράς αντί για ταυτότητα θέματος δεν θα αλλάξει αυτόματα όταν το σχήμα γραμματοσειρών θέματος αλλάξει.

Οι συλλογές μεγάλης και μικρής γραμματοσειράς μπορούν επίσης να περιέχουν αντιστοιχίσεις γραμματοσειρών για μεμονωμένα συστήματα γραφής, όπως Κυριλλική, Αραβική, Ιαπωνική, Γεωργιανή και Θάνα. Για επιθεώρηση, προσθήκη, αντικατάσταση ή αφαίρεση αυτών των αντιστοιχίσεων, δείτε [Script‑Specific Theme Fonts](/slides/el/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}

Για περισσότερες πληροφορίες σχετικά με τις γραμματοσειρές παρουσίασης, δείτε το [PowerPoint Fonts](/slides/el/php-java/powerpoint-fonts/).

{{% /alert %}}

## **Αντιγραφή ή Εφαρμογή Θέματος**

Οι παρακάτω ροές εργασίας λύνουν διαφορετικά προβλήματα σχετικά με τα θέματα.

### **Εφαρμογή Εξωτερικού Θέματος σε Διαφάνειες Εξαρτημένες από Master**

Χρησιμοποιήστε τη μέθοδο [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslide/) όταν έχετε ένα αρχείο θέματος PowerPoint (`.thmx`) και θέλετε να επανασχεδιάσετε κάθε διαφάνεια που εξαρτάται από έναν συγκεκριμένο master. Επιλέξτε τον master από τη συλλογή [Presentation::getMasters](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/), η οποία αντιπροσωπεύεται από το [MasterSlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslidecollection/), και περάστε τη διαδρομή του αρχείου θέματος στη μέθοδο.

Η μέθοδος εκτελεί τις ακόλουθες ενέργειες:

1. Δημιουργεί μια νέα master διαφάνεια βασισμένη στον επιλεγμένο master.
1. Εφαρμόζει το εξωτερικό θέμα στη νέα master.
1. Αναθέτει τη νέα master σε όλες τις διαφάνειες που προηγουμένως εξαρτώνταν από τον επιλεγμένο master.
1. Επιστρέφει το νέο [MasterSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslide/).

Το παρακάτω παράδειγμα εφαρμόζει ένα εξωτερικό θέμα στις διαφάνειες που εξαρτώνται από τον πρώτο master και αποθηκεύει την παρουσίαση:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $selectedMaster = $presentation->getMasters()->get_Item(0);
    $themedMaster = $selectedMaster->applyExternalThemeToDependingSlides("corporate-theme.thmx");

    echo "Created master: " . java_values($themedMaster->getName()) . PHP_EOL;
    $presentation->save("presentation-with-external-theme.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ένα μη έγκυρο, κατεστραμμένο ή μη υποστηριζόμενο θέμα μπορεί να προκαλέσει [PptxReadException](https://reference.aspose.com/slides/el/php-java/aspose.slides/pptxreadexception/). Επικυρώστε τις διαδρομές που παρέχουν οι χρήστες, διαχειριστείτε αποτυχίες πρόσβασης στο σύστημα αρχείων και αποθηκεύστε την παρουσίαση μόνο αφού το θέμα έχει εφαρμοστεί επιτυχώς.

Μόνο οι διαφάνειες που εξαρτώνταν από τον επιλεγμένο master αντιστοιχίζονται εκ νέου. Διαφάνειες που σχετίζονται με άλλους masters διατηρούν τους υπάρχοντες masters και θέματα τους. Τα χρώματα, γραμματοσειρές, γεμίσματα, γραμμές, υπόβαθρα και εφέ που είναι θέμα‑aware επιλύονται με βάση το εξωτερικό θέμα. Τα χρώματα, γραμματοσειρές, γεμίσματα και άλλες ρητές μορφοποιήσεις που έχουν οριστεί άμεσα μπορεί να παραμείνουν αμετάβλητα. Οι παρακάμψεις σε επίπεδο layout και διαφάνειας μπορούν επίσης να έχουν προτεραιότητα έναντι τιμών που κληρονομούνται από τον νέο master.

Το θέμα μπορεί να αναφέρει γραμματοσειρές που δεν είναι διαθέσιμες στο περιβάλλον εκτέλεσης. Για συνεπή απόδοση και εξαγωγή, εγκαταστήστε τις απαιτούμενες γραμματοσειρές, παρέχετε τις μέσω [custom font sources](/slides/el/php-java/custom-font/), ή ρυθμίστε την [font substitution](/slides/el/php-java/font-substitution/).

Αυτή είναι μια άμεση ροή εργασίας σε επίπεδο master: η μέθοδος δέχεται διαδρομή αρχείου `.thmx` και δεν απαιτεί τη δημιουργία χειροκίνητα παρακάμψεων θέματος σε επίπεδο διαφάνειας ή layout.

### **Εφαρμογή Διαφορετικών Εξωτερικών Θεμάτων σε Παρουσίαση με Πολλούς Masters**

Όταν ο σχετικός master δεν είναι γνωστός εκ των προτέρων, αποκτήστε τον από μια αντιπροσωπευτική διαφάνεια μέσω [Slide::getLayoutSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/) και [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslide/). Αποθηκεύστε τις αρχικές αναφορές master πριν εφαρμόσετε οποιαδήποτε θέματα, επειδή κάθε κλήση δημιουργεί έναν νέο master στην παρουσίαση.

Το παρακάτω παράδειγμα χρησιμοποιεί διαφάνειες από δύο ενότητες για να εντοπίσει τους masters τους και εφαρμόζει διαφορετικό εξωτερικό θέμα σε κάθε ομάδα:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (java_values($presentation->getSlides()->size()) < 5) {
        echo "The presentation does not contain the expected representative slides." . PHP_EOL;
    } else {
        $firstGroupMaster = $presentation->getSlides()->get_Item(0)->getLayoutSlide()->getMasterSlide();
        $secondGroupMaster = $presentation->getSlides()->get_Item(4)->getLayoutSlide()->getMasterSlide();

        if (java_values($firstGroupMaster->getSlideId()) === java_values($secondGroupMaster->getSlideId())) {
            echo "The representative slides use the same master." . PHP_EOL;
        } else {
            $firstThemedMaster = $firstGroupMaster->applyExternalThemeToDependingSlides("blue-theme.thmx");
            $secondThemedMaster = $secondGroupMaster->applyExternalThemeToDependingSlides("green-theme.thmx");

            echo "First themed master: " . java_values($firstThemedMaster->getName()) . PHP_EOL;
            echo "Second themed master: " . java_values($secondThemedMaster->getName()) . PHP_EOL;
            $presentation->save("multi-master-with-external-themes.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

Η πρώτη κλήση επηρεάζει μόνο τις διαφάνειες που εξαρτώνται από το `$firstGroupMaster`, και η δεύτερη κλήση επηρεάζει μόνο τις διαφάνειες που εξαρτώνται από το `$secondGroupMaster`. Διαφάνειες που ανήκουν σε οποιονδήποτε άλλον master δεν επανασχεδιάζονται.

### **Διατήρηση Πρωτότυπου Θέματος κατά τη Μεταφορά Διαφάνειας**

Αν θέλετε να μεταφέρετε μια διαφάνεια σε άλλη παρουσίαση και να διατηρήσετε το αρχικό της σχέδιο, κλωνοποιήστε τον πηγαίο master στην προορισμένη παρουσίαση με τη μέθοδο [MasterSlideCollection.addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslidecollection/), έπειτα κλωνοποιήστε τη διαφάνεια με το [SlideCollection.addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidecollection/) και τον κλωνοποιημένο master. Αυτό μεταφέρει μαζί του τον master, τα layout του και το σχετικό θέμα.

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

Αυτή είναι η προτιμώμενη ροή εργασίας όταν η πηγαία διαφάνεια πρέπει να φαίνεται ίδιοι στον προορισμό. Η απλή κλωνοποίηση περιεχομένου πάνω σε έναν μη σχετικό master προορισμού μπορεί να μεταβάλει χρώματα, γραμματοσειρές, υπόβαθρα και εφέ που προέρχονται από το θέμα.

### **Εφαρμογή Τιμών Θέματος σε Υπάρχουσα Διαφάνεια**

Αν η διαφάνεια‑προορισμός πρέπει να παραμείνει στον τρέχοντα master και layout, αρχικοποιήστε μια παρακάμψη σε επίπεδο διαφάνειας από το πηγαίο θέμα. Οι μέθοδοι [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/el/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/el/php-java/aspose.slides/overridetheme/), και [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/el/php-java/aspose.slides/overridetheme/) αντιγράφουν τα τρία κύρια στοιχεία του θέματος στην παρακάμψη.

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

Αυτό αλλάζει το θέμα που χρησιμοποιεί η συγκεκριμένη διαφάνεια χωρίς να επηρεάζει το θέμα που κληρονομείται από άλλες διαφάνειες. Για να αφαιρέσετε την τοπική παρακάμψη και να επιστρέψετε στις κληρονομημένες τιμές, καλέστε το [OverrideTheme.clear](https://reference.aspose.com/slides/el/php-java/aspose.slides/overridetheme/).

### **Εφαρμογή Παρακάμψης Θέματος σε Layout**

Μια παρακάμψη σε επίπεδο layout εφαρμόζεται σε διαφάνειες που χρησιμοποιούν αυτό το layout, εκτός εάν μια συγκεκριμένη διαφάνεια έχει τη δική της παρακάμψη. Οι ίδιες μέθοδοι αρχικοποίησης μπορούν να χρησιμοποιηθούν μέσω του [LayoutSlideThemeManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslidethememanager/):

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

Χρησιμοποιήστε θέμα σε επίπεδο master ή παρουσίασης όταν πολλά layout και διαφάνειες πρέπει να μοιράζονται το ίδιο βασικό σχέδιο, μια παρακάμψη layout όταν μια οικογένεια layout χρειάζεται διαφορετικό στυλ, και μια παρακάμψη διαφάνειας μόνο για πραγματικές εξαιρέσεις. Υπερβολικές παρακάμψεις σε επίπεδο διαφάνειας καθιστούν τις μελλοντικές παγκόσμιες αλλαγές θέματος πιο αβέβαιες.

## **Ενημέρωση Στυλ Φόντου Θέματος**

Τα στυλ φόντου του θέματος αποθηκεύονται στη μέθοδο [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/el/php-java/aspose.slides/formatscheme/). Το PowerPoint μπορεί να παρουσιάσει περισσότερες επιλογές φόντου στην UI του απ' ό,τι ο αριθμός των ορισμών γεμίσματος που είναι αποθηκευμένοι στη συλλογή, επειδή η UI μπορεί να συνδυάσει γεμίσματα θέματος με χρώματα θέματος και άλλες αναφορές στυλ.

![Γκαλερί στυλ φόντου PowerPoint για ένα θέμα παρουσίασης](presentation-design_8.png)

Πριν χρησιμοποιήσετε ένα στυλ φόντου, επιθεωρήστε τη συλλογή που αποθηκεύεται και το τρέχον [Background.getStyleIndex](https://reference.aspose.com/slides/el/php-java/aspose.slides/background/). Ένα δείκτη στυλ `0` σημαίνει ότι δεν υπάρχει θεματικό γέμισμα· θετικές τιμές είναι αναφορές σε στυλ φόντου θέματος. Αυτό είναι διαφορετικό από την απευθείας αντιμετώπιση της PHP‑συλλογής, όπου `get_Item(0)` σημαίνει το πρώτο αποθηκευμένο στοιχείο. Μην υποθέτετε ότι κάθε παρουσίαση περιέχει τον ίδιο αριθμό στυλ φόντου.

Το παρακάτω παράδειγμα αναφέρει τον διαθέσιμο αριθμό γεμισμάτων φόντου, αντιστοιχίζει μια θεματική αναφορά φόντου στον πρώτο master και αποθηκεύει την παρουσίαση:

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

Το ορατό αποτέλεσμα εξαρτάται από την καταχώρηση θέματος που αναφέρεται από τον master και από τυχόν παρακάμψεις φόντου σε επίπεδο layout ή διαφάνειας. Αν μια διαφάνεια χρησιμοποιεί το δικό της φόντο, η αλλαγή μόνο του φόντου του master μπορεί να μην επηρεάσει αυτή τη διαφάνεια. Χρησιμοποιήστε το [Background.getEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/background/) όταν χρειάζεται να γνωρίζετε το τελικό φόντο μετά την εφαρμογή κληρονομικότητας.

{{% alert color="warning" title="Warning" %}}

Μην αντιμετωπίζετε το δείκτη στυλ ως δείκτη μηδενικής βάσης της συλλογής. Επίσης, αποφύγετε τη σκληρή κωδικοποίηση αριθμού στυλ από ένα αρχείο και την υπόθεση ότι θα έχει την ίδια εμφάνιση σε άλλο αρχείο· οι ορισμοί στυλ θέματος είναι ειδικοί για κάθε παρουσίαση.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

Για άμεση μορφοποίηση φόντου και κληρονομικότητα φόντου, δείτε το [Presentation Background](/slides/el/php-java/presentation-background/).

{{% /alert %}}

## **Ενημέρωση Εφέ Θέματος**

Ένα σχήμα μορφοποίησης θέματος περιλαμβάνει ξεχωριστές συλλογές γεμίσματος, γραμμής και εφέ που εκτίθενται μέσω των [FormatScheme.getFillStyles](https://reference.aspose.com/slides/el/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/el/php-java/aspose.slides/formatscheme/), και [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/el/php-java/aspose.slides/formatscheme/). Τα τυπικά θέματα Office συχνά περιέχουν τρία κύρια στοιχεία στυλ που αντιστοιχούν οπτικά σε διακριτά, μετριοπαθή και έντονα στυλ, αλλά ο κώδικας πρέπει να εξετάζει κάθε συλλογή αντί να υποθέτει σταθερό αριθμό.

![Διακριτά, μετριοπαθή και έντονα εφέ θέματος που εφαρμόζονται στο ίδιο σχήμα](presentation-design_10.png)

Όταν έχετε πρόσβαση σε αυτές τις συλλογές στην PHP, ο δείκτης της συλλογής είναι μηδενικής βάσης: `get_Item(0)` είναι το πρώτο αποθηκευμένο στυλ και `get_Item(2)` είναι το τρίτο. Οι δείκτες αναφοράς στυλ ενός σχήματος είναι ξεχωριστή έννοια, εκτινόμενη μέσω του [ShapeStyle](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapestyle/). Η τροποποίηση ενός στυλ θέματος επηρεάζει τα σχήματα που το αναφέρουν· σχήματα με άμεση μορφοποίηση μπορεί να παραμείνουν αμετάβλητα.

Το παρακάτω παράδειγμα ελέγχει ότι οι απαιτούμενες καταχωρήσεις στυλ υπάρχουν, αλλάζει το πρώτο στυλ γραμμής, το τρίτο στυλ γεμίσματος, ενεργοποιεί μια εξωτερική σκιά στο τρίτο στυλ εφέ και αποθηκεύει το αποτέλεσμα:

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

Για σχήματα που αναφέρονται σε αυτές τις θέσεις, το πρώτο στυλ γραμμής θέματος γίνεται κόκκινο, το τρίτο στυλ γεμίσματος θέματος γίνεται στερεό δάσος πράσινο, και το τρίτο στυλ εφέ αποκτά εξωτερική σκιά με απόσταση 10 σημείων. Το ακριβές οπτικό αποτέλεσμα εξακολουθεί να εξαρτάται από το ποιο στυλ αναφέρεται κάθε σχήμα και αν η άμεση μορφοποίηση παρακάμπτει το θέμα.

![Στυλ εφέ θέματος μετά την αλλαγή γραμμής, γεμίσματος και σκιάς](presentation-design_11.png)

## **Ανάγνωση Αποτελεσματικών Τιμών Θέματος**

Οι ακατέργαστοι αντικειμενοί του θέματος σας λένε τι ορίζεται σε συγκεκριμένο επίπεδο. Οι αποτελεσματικές τιμές σας λένε τι χρησιμοποιεί πραγματικά μια διαφάνεια ή σχήμα μετά την κληρονομικότητα και τις τοπικές παρακάμψεις. Για μια διαφάνεια, καλέστε το [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseoverridethememanager/). Για φόντο, χρησιμοποιήστε το [Background.getEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/background/), και για γέμισμα, το [FillFormat.getEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/fillformat/).

Το παρακάτω παράδειγμα διαβάζει το αποτελεσματικό θέμα, το φόντο και το πρώτο γέμισμα σχήματος από μια διαφάνεια:

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

Χρησιμοποιήστε τα αποτελεσματικά δεδομένα για διαγνωστικούς σκοπούς απόδοσης, επικύρωση και συγκρίσεις. Αν επιθεωρήσετε μόνο το [Presentation.getMasterTheme](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/), μπορεί να χάσετε έναν master, layout, διαφάνεια ή παρακάμψη σχήματος που αλλάζει την τελική εμφάνιση.

## **Συχνές Ερωτήσεις**

**Επηρεάζει η εφαρμογή εξωτερικού θέματος κάθε διαφάνεια στην παρουσίαση;**

Όχι. Η [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslide/) επανααναθέτει μόνο τις διαφάνειες που εξαρτώνται από τον επιλεγμένο master. Διαφάνειες που χρησιμοποιούν άλλους masters διατηρούν τα υπάρχοντα θέματα τους.

**Μπορώ να εφαρμόσω θέμα σε μία μόνο διαφάνεια χωρίς να αλλάξω τον master;**

Ναι. Χρησιμοποιήστε το [SlideThemeManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidethememanager/) της διαφάνειας και αρχικοποιήστε το override theme της. Η αλλαγή παραμένει τοπική σε αυτή τη διαφάνεια· οι άλλες διαφάνειες συνεχίζουν να κληρονομούν τα υπάρχοντα θέματα τους.

**Ποιος είναι ο ασφαλέστερος τρόπος για να μεταφέρω θέμα από μια παρουσίαση σε άλλη;**

Κατά τη μεταφορά μιας διαφάνειας και τη διατήρηση της αρχικής της εμφάνισης, κλωνοποιήστε τον πηγαίο master στον προορισμό και κλωνοποιήστε τη διαφάνεια με αυτόν τον master χρησιμοποιώντας τις [MasterSlideCollection.addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslidecollection/) και [SlideCollection.addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidecollection/). Αυτό διατηρεί μαζί τον master, τα layout και το θέμα.

**Πώς μπορώ να δω τις αποτελεσματικές τιμές μετά την κληρονομικότητα και τις παρακάμψεις;**

Χρησιμοποιήστε το [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseoverridethememanager/) για ένα θέμα διαφάνειας ή layout και τις αντίστοιχες μεθόδους αποτελεσματικών δεδομένων για αντικείμενα μορφοποίησης όπως το [Background.getEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/background/) και το [FillFormat.getEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/fillformat/). Αυτά τα API επιστρέφουν τις επιλυμένες τιμές μετά την εφαρμογή κληρονομικότητας και παρακάμψεων.