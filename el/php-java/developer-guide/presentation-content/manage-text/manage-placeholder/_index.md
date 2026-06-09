---
title: "Διαχείριση Placeholder Παρουσιάσεων σε PHP"
linktitle: "Διαχείριση Placeholder"
type: docs
weight: 10
url: /el/php-java/manage-placeholder/
keywords:
- "συμβόλο κράτησης"
- "συμβόλο κειμένου"
- "συμβόλο εικόνας"
- "συμβόλο διαγράμματος"
- "κείμενο προτροπής"
- "PowerPoint"
- "OpenDocument"
- "παρουσίαση"
- "PHP"
- "Aspose.Slides"
description: "Διαχειριστείτε εύκολα τα placeholders στο Aspose.Slides για PHP μέσω Java: αντικαταστήστε κείμενο, προσαρμόστε προτροπές & ορίστε τη διαφάνεια εικόνας σε PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Aspose.Slides σας επιτρέπει να διαχειρίζεστε τα placeholders προγραμματιστικά. Αυτό το άρθρο εξηγεί πώς να βρίσκετε placeholders σε διαφάνειες και να αλλάζετε το κείμενό τους, να ορίζετε προσαρμοσμένο κείμενο προτροπής για τις διατάξεις των placeholders, και να ρυθμίζετε τη διαφάνεια μιας εικόνας που χρησιμοποιείται ως φόντο placeholder. Περιλαμβάνει επίσης μια σύντομη **Συχνές ερωτήσεις** που διευκρινίζει τη διαφορά μεταξύ base placeholders και τοπικών σχημάτων, εξηγεί πώς μπορούν να εφαρμοστούν αλλαγές placeholders μέσω διατάξεων ή master, και παραπέμπει στη διαχείριση των placeholders κεφαλίδας και υποσέλιδου.

## **Αλλαγή κειμένου σε Placeholder**
Using [Aspose.Slides for PHP via Java](/slides/el/php-java/), you can find and modify placeholders on slides in presentations. Aspose.Slides allows you to make changes to the text in a placeholder.

**Απαίτηση**: You need a presentation that contains a placeholder. You can create such a presentation in the standard Microsoft PowerPoint app.

This is how you use Aspose.Slides to replace the text in the placeholder in that presentation:

1. Instantiate the [`Presentation`](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) class. and pass the presentation as an argument.
2. Get a slide reference through its index.
3. Iterate through the shapes to find the placeholder.
4. Typecast the placeholder shape to an [`AutoShape`](https://reference.aspose.com/slides/el/php-java/aspose.slides/AutoShape) and change the text using the [`TextFrame`](https://reference.aspose.com/slides/el/php-java/aspose.slides/TextFrame) associated with the [`AutoShape`](https://reference.aspose.com/slides/el/php-java/aspose.slides/AutoShape).
5. Save the modified presentation.

This PHP code shows how to change the text in a placeholder:

```php
  # Δημιουργεί μια κλάση Presentation
  $pres = new Presentation("ReplacingText.pptx");
  try {
    # Πρόσβαση στην πρώτη διαφάνεια
    $sld = $pres->getSlides()->get_Item(0);
    # Διασχίζει τα σχήματα για να βρει το placeholder
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # Αλλάζει το κείμενο σε κάθε placeholder
        $shp->getTextFrame()->setText("This is Placeholder");
      }
    }
    # Αποθηκεύει την παρουσίαση στο δίσκο
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ορισμός κειμένου προτροπής σε Placeholder**
Standard and pre-built layouts contain placeholder prompt texts such as ***Click to add a title*** or ***Click to add a subtitle***. Using Aspose.Slides, you can insert your preferred prompt texts into placeholder layouts.

This PHP code shows you how to set the prompt text in a placeholder:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Διασχίζει τη διαφάνεια
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # Το PowerPoint εμφανίζει "Click to add title"
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "Add Title";
        } else // Προσθέτει υπότιτλο
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "Add Subtitle";
        }
        $shape->getTextFrame()->setText($text);
        echo("Placeholder with text: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ορισμός διαφάνειας εικόνας Placeholder**

Aspose.Slides allows you to set the transparency of the background image in a text placeholder. By adjusting the transparency of the picture in such a frame, you can make the text or the image stand out (depending on the text's and picture's colors).

This PHP code shows you how to set the transparency for a picture background (inside a shape):

```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("Current transparency value: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);
```

## **Συχνές ερωτήσεις**

**Τι είναι ένα base placeholder και πώς διαφέρει από ένα τοπικό σχήμα σε μια διαφάνεια;**

Ένα base placeholder είναι το αρχικό σχήμα σε μια διάταξη ή master από το οποίο κληρονομεί το σχήμα της διαφάνειας—ο τύπος, η θέση και ορισμένες μορφοποιήσεις προέρχονται από αυτό. Ένα τοπικό σχήμα είναι ανεξάρτητο· εάν δεν υπάρχει base placeholder, η κληρονομικότητα δεν εφαρμόζεται.

**Πώς μπορώ να ενημερώσω όλους τους τίτλους ή τις λεζάντες σε όλη την παρουσίαση χωρίς να επαναλαμβάνομαι σε κάθε διαφάνεια;**

Επεξεργαστείτε το αντίστοιχο placeholder στη διάταξη ή στο master. Οι διαφάνειες που βασίζονται σε αυτές τις διατάξεις/στο master θα κληρονομήσουν αυτόματα την αλλαγή.

**Πώς ελέγχω τα τυπικά placeholders κεφαλίδας/υποσέλιδου—ημερομηνία & ώρα, αριθμός διαφάνειας και κείμενο υποσέλιδου;**

Χρησιμοποιήστε τους διαχειριστές HeaderFooter στην κατάλληλη εμβέλεια (κανονικές διαφάνειες, διατάξεις, master, σημειώσεις/υλικό διανομής) για να ενεργοποιήσετε ή να απενεργοποιήσετε αυτά τα placeholders και να ορίσετε το περιεχόμενό τους.