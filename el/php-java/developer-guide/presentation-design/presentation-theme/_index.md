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
description: "Κύρια θέματα παρουσίασης στο Aspose.Slides για PHP μέσω Java για τη δημιουργία, προσαρμογή και μετατροπή αρχείων PowerPoint με συνεπή εμπορική ταυτότητα."
---
## **Εισαγωγή**

Ένα θέμα παρουσίασης ορίζει τις ιδιότητες των στοιχείων σχεδίασης. Όταν επιλέγετε ένα θέμα παρουσίασης, ουσιαστικά επιλέγετε ένα συγκεκριμένο σύνολο οπτικών στοιχείων και τις ιδιότητές τους.

Στο PowerPoint, ένα θέμα περιλαμβάνει χρώματα, [γραμματοσειρές](/slides/el/php-java/powerpoint-fonts/), [στυλ φόντου](/slides/el/php-java/presentation-background/), και εφέ.

![συστατικά-θέματος](theme-constituents.png)

## **Αλλαγή Χρώματος Θέματος**

Ένα θέμα PowerPoint χρησιμοποιεί ένα συγκεκριμένο σύνολο χρωμάτων για διάφορα στοιχεία σε μια διαφάνεια. Εάν δεν σας αρέσουν τα χρώματα, τα αλλάζετε εφαρμόζοντας νέα χρώματα στο θέμα. Για να μπορείτε να επιλέξετε ένα νέο χρώμα θέματος, η Aspose.Slides παρέχει τιμές στην απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/php-java/aspose.slides/SchemeColor).

Αυτός ο κώδικας PHP δείχνει πώς να αλλάξετε το χρώμα έμφασης για ένα θέμα:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Μπορείτε να καθορίσετε την αποτελεσματική τιμή του προκύπτοντος χρώματος με αυτόν τον τρόπο:

```php
  $fillEffective = $shape->getFillFormat()->getEffective();
  $effectiveColor = $fillEffective->getSolidFillColor();
  echo(sprintf("Color [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));

```

Για να επιδείξουμε περαιτέρω τη λειτουργία αλλαγής χρώματος, δημιουργούμε ένα άλλο στοιχείο και του αναθέτουμε το χρώμα έμφασης (από την αρχική λειτουργία). Στη συνέχεια αλλάζουμε το χρώμα στο θέμα:

```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);

```

Το νέο χρώμα εφαρμόζεται αυτόματα και στα δύο στοιχεία.

### **Ορισμός Χρώματος Θέματος από Πρόσθετη Παλέτα**

Όταν εφαρμόζετε μετασχηματισμούς φωτεινότητας στο κύριο χρώμα θέματος (1), σχηματίζονται χρώματα από την πρόσθετη παλέτα (2). Μπορείτε στη συνέχεια να ορίσετε και να λάβετε αυτά τα χρώματα θέματος.

![χρώματα-πρόσθετης-παλέτας](additional-palette-colors.png)

**1** - Κύρια χρώματα θέματος  

**2** - Χρώματα από την πρόσθετη παλέτα.

Αυτός ο κώδικας PHP δείχνει μια λειτουργία όπου τα χρώματα της πρόσθετης παλέτας λαμβάνονται από το κύριο χρώμα θέματος και στη συνέχεια χρησιμοποιούνται σε σχήματα:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Έμφαση 4
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    # Έμφαση 4, Φωτεινότερο 80%
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
    # Έμφαση 4, Φωτεινότερο 60%
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
    # Έμφαση 4, Φωτεινότερο 40%
    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.4);
    # Έμφαση 4, Σκοτεινότερο 25%
    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
    # Έμφαση 4, Σκοτεινότερο 50%
    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.5);
    $presentation->save($path . "example_accent4.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **Χαρτογράφηση `SchemeColor` σε Χρώματα `ColorScheme`**

Όταν εργάζεστε με [SchemeColor](https://reference.aspose.com/slides/el/php-java/aspose.slides/schemecolor/), μπορεί να παρατηρήσετε ότι περιέχει τις παρακάτω τιμές χρωμάτων θέματος:

`Background1`, `Background2`, `Text1`, and `Text2`.

Ωστόσο, η `Presentation::getMasterTheme()::getColorScheme()` επιστρέφει το [ColorScheme](https://reference.aspose.com/slides/el/php-java/aspose.slides/colorscheme/), το οποίο εμφανίζει τα αντίστοιχα χρώματα ως:

`Dark1`, `Dark2`, `Light1`, and `Light2`.

Αυτή η διαφορά είναι μόνο στο όνομα. Αυτές οι τιμές αναφέρονται στα ίδια θέματα χρωμάτων και η αντιστοίχηση είναι σταθερή:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Δεν υπάρχει δυναμική μετατροπή μεταξύ `Text`/`Background` και `Dark`/`Light`. Απλώς είναι εναλλακτικά ονόματα για τα ίδια χρώματα θέματος.

Αυτή η διαφορά ονομασίας προέρχεται από την ορολογία του Microsoft Office. Οι παλαιότερες εκδόσεις του Office χρησιμοποιούσαν `Dark 1`, `Light 1`, `Dark 2` και `Light 2`, ενώ οι νεότερες εκδόσεις UI εμφανίζουν τα ίδια σύνολα ως `Text 1`, `Background 1`, `Text 2` και `Background 2`.

## **Αλλαγή Γραμματοσειράς Θέματος**

Για να μπορείτε να επιλέξετε γραμματοσειρές για θέματα και άλλους σκοπούς, η Aspose.Slides χρησιμοποιεί αυτούς τους ειδικούς αναγνωριστικούς (παρόμοιους με αυτούς που χρησιμοποιούνται στο PowerPoint):

* **+mn-lt** - Γραμματοσειρά Σώματος Λάτιν (Δευτερεύουσα Γραμματοσειρά Λάτιν)
* **+mj-lt** - Γραμματοσειρά Επικεφαλίδας Λάτιν (Κύρια Γραμματοσειρά Λάτιν)
* **+mn-ea** - Γραμματοσειρά Σώματος Ανατολικής Ασίας (Δευτερεύουσα Γραμματοσειρά Ανατολικής Ασίας)
* **+mj-ea** - Γραμματοσειρά Σώματος Ανατολικής Ασίας (Κύρια Γραμματοσειρά Ανατολικής Ασίας)

Αυτός ο κώδικας PHP δείχνει πώς να αναθέσετε τη γραμματοσειρά Λάτιν σε ένα στοιχείο θέματος:

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("Theme text format");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

```

Αυτός ο κώδικας PHP δείχνει πώς να αλλάξετε τη γραμματοσειρά του θέματος παρουσίασης:

```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
```

Η γραμματοσειρά σε όλα τα πλαίσια κειμένου θα ενημερωθεί.

{{% alert color="primary" title="ΣΥΜΒΟΥΛΗ" %}} 
Ίσως θέλετε να δείτε [γραμματοσειρές PowerPoint](/slides/el/php-java/powerpoint-fonts/).
{{% /alert %}}

## **Αλλαγή Στυλ Φόντου Θέματος**

Από προεπιλογή, η εφαρμογή PowerPoint παρέχει 12 προκαθορισμένα φόντα, αλλά μόνο 3 από αυτά τα 12 φόντα αποθηκεύονται σε μια τυπική παρουσίαση.

![σχέδιο-παρουσίασης](presentation-design_8.png)

Για παράδειγμα, αφού αποθηκεύσετε μια παρουσίαση στην εφαρμογή PowerPoint, μπορείτε να εκτελέσετε αυτόν τον κώδικα PHP για να βρείτε τον αριθμό των προκαθορισμένων φόντων στην παρουσίαση:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $numberOfBackgroundFills = $pres->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size();
    echo("Number of background fill styles for theme is " . $numberOfBackgroundFills);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 
Χρησιμοποιώντας την ιδιότητα [BackgroundFillStyles](https://reference.aspose.com/slides/el/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) από την κλάση [FormatScheme](https://reference.aspose.com/slides/el/php-java/aspose.slides/FormatScheme), μπορείτε να προσθέσετε ή να προσπελάσετε το στυλ φόντου σε ένα θέμα PowerPoint.
{{% /alert %}} 

Αυτός ο κώδικας PHP δείχνει πώς να ορίσετε το φόντο για μια παρουσίαση:

```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);
```

**Οδηγός ευρετηρίου**: 0 χρησιμοποιείται για καμία γέμιση. Το ευρετήριο ξεκινά από 1.

{{% alert color="primary" title="ΣΥΜΒΟΥΛΗ" %}} 
Ίσως θέλετε να δείτε [Φόντο PowerPoint](/slides/el/php-java/presentation-background/).
{{% /alert %}}

## **Αλλαγή Εφέ Θέματος**

Ένα θέμα PowerPoint συνήθως περιέχει 3 τιμές για κάθε πίνακα στυλ. Αυτοί οι πίνακες συνδυάζονται σε αυτά τα 3 εφέ: λεπτό, μέτριο και έντονο. Για παράδειγμα, αυτό είναι το αποτέλεσμα όταν τα εφέ εφαρμόζονται σε ένα συγκεκριμένο σχήμα:

![αποτέλεσμα-εφέ](presentation-design_10.png)

Χρησιμοποιώντας 3 ιδιότητες ([FillStyles](https://reference.aspose.com/slides/el/php-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/el/php-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/el/php-java/aspose.slides/FormatScheme#getEffectStyles--)) από την κλάση [FormatScheme](https://reference.aspose.com/slides/el/php-java/aspose.slides/FormatScheme) μπορείτε να αλλάξετε τα στοιχεία σε ένα θέμα (ακόμη πιο ευέλικτα από τις επιλογές στο PowerPoint).

Αυτός ο κώδικας PHP δείχνει πώς να αλλάξετε ένα εφέ θέματος τροποποιώντας μέρη των στοιχείων:

```php
  $pres = new Presentation("Subtle_Moderate_Intense.pptx");
  try {
    $pres->getMasterTheme()->getFormatScheme()->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $pres->getMasterTheme()->getFormatScheme()->getEffectStyles()->get_Item(2)->getEffectFormat()->getOuterShadowEffect()->setDistance(10.0);
    $pres->save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Οι τελικές αλλαγές σε χρώμα γεμίσματος, τύπο γεμίσματος, εφέ σκιάς κ.λπ.:

![αποτελέσματα-εφέ](presentation-design_11.png)

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να εφαρμόσω ένα θέμα σε μία μόνο διαφάνεια χωρίς να αλλάξω το master;**

Ναι. Η Aspose.Slides υποστηρίζει αντικαταστάσεις θέματος επιπέδου διαφάνειας, ώστε να μπορείτε να εφαρμόσετε ένα τοπικό θέμα μόνο σε εκείνη τη διαφάνεια διατηρώντας το κύριο θέμα ανέπαφο (μέσω του [SlideThemeManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidethememanager/)).

**Ποιος είναι ο πιο ασφαλής τρόπος για να μεταφέρετε ένα θέμα από μία παρουσίαση σε άλλη;**

[Κλωνοποιήστε διαφάνειες](/slides/el/php-java/clone-slides/) μαζί με το master τους στην προοριστική παρουσίαση. Αυτό διατηρεί το αρχικό master, τις διατάξεις και το σχετικό θέμα, ώστε η εμφάνιση να παραμένει συνεπής.

**Πώς μπορώ να δω τις "αποτελεσματικές" τιμές μετά από όλες τις κληρονομιές και αντικαταστάσεις;**

Χρησιμοποιήστε τις "αποτελεσματικές" προβολές του API [/slides/el/php-java/shape-effective-properties/] για θέμα/χρώμα/γραμματοσειρά/εφέ. Αυτές επιστρέφουν τις επιλύμενες, τελικές ιδιότητες μετά την εφαρμογή του master και τυχόν τοπικών αντικαταστάσεων.