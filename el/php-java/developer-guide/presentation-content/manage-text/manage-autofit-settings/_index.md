---
title: Βελτιώστε τις παρουσιάσεις σας με AutoFit σε PHP
linktitle: Ρυθμίσεις AutoFit
type: docs
weight: 30
url: /el/php-java/manage-autofit-settings/
keywords:
- πλαίσιο κειμένου
- αυτόματη προσαρμογή
- μη αυτόματη προσαρμογή
- προσαρμογή κειμένου
- συρρίκνωση κειμένου
- αναδίπλωση κειμένου
- αλλαγή μεγέθους σχήματος
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Διαχειριστείτε τις ρυθμίσεις AutoFit στο Aspose.Slides για PHP για να βελτιστοποιήσετε την εμφάνιση του κειμένου στις παρουσιάσεις PowerPoint και OpenDocument και να βελτιώσετε την αναγνωσιμότητα του περιεχομένου."
---
## **Εισαγωγή**

Από προεπιλογή, όταν προσθέτετε ένα πλαίσιο κειμένου, το Microsoft PowerPoint χρησιμοποιεί τη ρύθμιση **Resize shape to fix text** για το πλαίσιο κειμένου—προσαρμόζει αυτόματα το μέγεθος του πλαισίου ώστε το κείμενο του να χωράει πάντα.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Όταν το κείμενο στο πλαίσιο γίνεται πιο μακρύ ή μεγαλύτερο, το PowerPoint αυξάνει αυτόματα το ύψος του πλαισίου για να χωρέσει περισσότερο κείμενο.  
* Όταν το κείμενο στο πλαίσιο γίνεται πιο σύντομο ή μικρότερο, το PowerPoint μειώνει αυτόματα το ύψος του πλαισίου για να αφαιρέσει περιττό χώρο.

Στο PowerPoint, αυτά είναι τα 4 σημαντικά παραμέτρους ή επιλογές που ελέγχουν τη συμπεριφορά autofit για ένα πλαίσιο κειμένου:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Το Aspose.Slides for PHP via Java παρέχει παρόμοιες επιλογές—ορισμένες ιδιότητες στην κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/TextFrameFormat) που επιτρέπουν τον έλεγχο της συμπεριφοράς autofit για πλαίσια κειμένου σε παρουσιάσεις.

## **Resize a Shape to Fit Text**

Αν θέλετε το κείμενο σε ένα πλαίσιο να ταιριάζει πάντα στο πλαίσιο μετά από αλλαγές, πρέπει να χρησιμοποιήσετε την επιλογή **Resize shape to fix text**. Για να ορίσετε αυτή τη ρύθμιση, θέστε την ιδιότητα [AutofitType](https://reference.aspose.com/slides/el/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/TextFrameFormat)) σε `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Αυτός ο κώδικας PHP δείχνει πώς να ορίσετε ότι το κείμενο πρέπει πάντα να ταιριάζει στο πλαίσιο του σε μια παρουσίαση PowerPoint:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Shape);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Αν το κείμενο γίνει πιο μακρύ ή μεγαλύτερο, το πλαίσιο κειμένου θα αυξηθεί αυτόματα (αύξηση ύψους) ώστε όλο το κείμενο να χωράει. Αν το κείμενο γίνει πιο σύντομο, συμβαίνει το αντίστροφο.

## **Do Not Autofit**

Αν θέλετε ένα πλαίσιο ή σχήμα να διατηρεί τις διαστάσεις του ανεξάρτητα από τις αλλαγές στο κείμενο, πρέπει να χρησιμοποιήσετε την επιλογή **Do not Autofit**. Για να ορίσετε αυτή τη ρύθμιση, θέστε την ιδιότητα [AutofitType](https://reference.aspose.com/slides/el/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/TextFrameFormat)) σε `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Αυτός ο κώδικας PHP δείχνει πώς να ορίσετε ότι ένα πλαίσιο κειμένου πρέπει πάντα να διατηρεί τις διαστάσεις του σε μια παρουσίαση PowerPoint:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::None);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Όταν το κείμενο γίνει πολύ μακρύ για το πλαίσιο, θα υπερχειλίσει έξω.

## **Shrink Text on Overflow**

Αν ένα κείμενο γίνει πολύ μακρύ για το πλαίσιο του, μέσω της επιλογής **Shrink text on overflow** μπορείτε να ορίσετε ότι το μέγεθος και η απόσταση του κειμένου πρέπει να μειωθούν ώστε να χωράει. Για να ορίσετε αυτή τη ρύθμιση, θέστε την ιδιότητα [AutofitType](https://reference.aspose.com/slides/el/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/TextFrameFormat)) σε `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Αυτός ο κώδικας PHP δείχνει πώς να ορίσετε ότι το κείμενο πρέπει να στενεύει όταν υπερχειλίζει σε μια παρουσίαση PowerPoint:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Normal);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Info" color="info" %}}
Όταν χρησιμοποιείται η επιλογή **Shrink text on overflow**, η ρύθμιση εφαρμόζεται μόνο όταν το κείμενο γίνεται πολύ μακρύ για το πλαίσιο του.
{{% /alert %}}

## **Wrap Text**

Αν θέλετε το κείμενο σε ένα σχήμα να αναδιπλώνεται μέσα στο σχήμα όταν ξεπερνά το όριό του (μόνο το πλάτος), πρέπει να χρησιμοποιήσετε την παράμετρο **Wrap text in shape**. Για να ορίσετε αυτή τη ρύθμιση, πρέπει να θέσετε την ιδιότητα [WrapText](https://reference.aspose.com/slides/el/php-java/aspose.slides/TextFrameFormat#getWrapText--) (από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/TextFrameFormat)) σε `true`.

Αυτός ο κώδικας PHP δείχνει πώς να χρησιμοποιήσετε τη ρύθμιση Wrap Text σε μια παρουσίαση PowerPoint:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setWrapText(NullableBool::True);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 
Αν θέσετε την ιδιότητα `WrapText` σε `False` για ένα σχήμα, όταν το κείμενο μέσα στο σχήμα γίνει μεγαλύτερο από το πλάτος του σχήματος, το κείμενο θα εκταθεί πέρα από τα όρια του σχήματος σε μία μόνο γραμμή.
{{% /alert %}}

## **FAQ**

**Do the text frame’s internal margins affect AutoFit?**

Ναι. Η εσωτερική απόσταση (padding) μειώνει την διαθέσιμη περιοχή για κείμενο, έτσι το AutoFit ενεργοποιείται νωρίτερα—σμικρύνοντας τη γραμματοσειρά ή αλλάζοντας το μέγεθος του σχήματος. Ελέγξτε και προσαρμόστε τα περιθώρια πριν ρυθμίσετε το AutoFit.

**How does AutoFit interact with manual and soft line breaks?**

Οι βίαιοι αλλαγές γραμμής παραμένουν, και το AutoFit προσαρμόζει το μέγεθος γραμματοσειράς και την απόσταση γύρω τους. Η αφαίρεση περιττών αλλαγών γραμμής μειώνει συχνά το πόσο έντονα πρέπει να σμικρύνει το κείμενο το AutoFit.

**Does changing the theme font or triggering font substitution affect AutoFit results?**

Ναι. Η αντικατάσταση με γραμματοσειρά που έχει διαφορετικά μετρικά γλιφών αλλάζει το πλάτος/ύψος του κειμένου, κάτι που μπορεί να αλλάξει το τελικό μέγεθος γραμματοσειράς και τη συστροφή γραμμών. Μετά από κάθε αλλαγή ή αντικατάσταση γραμματοσειράς, ελέγξτε ξανά τις διαφάνειες.