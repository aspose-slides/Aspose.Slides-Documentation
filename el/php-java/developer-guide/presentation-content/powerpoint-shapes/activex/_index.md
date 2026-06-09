---
title: Διαχείριση ελέγχων ActiveX σε παρουσιάσεις χρησιμοποιώντας PHP
linktitle: ActiveX
type: docs
weight: 80
url: /el/php-java/activex/
keywords:
- ActiveX
- Έλεγχος ActiveX
- Διαχείριση ActiveX
- Προσθήκη ActiveX
- Τροποποίηση ActiveX
- Αναπαραγωγέας πολυμέσων
- PowerPoint
- Παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς το Aspose.Slides για PHP μέσω Java αξιοποιεί το ActiveX για την αυτοματοποίηση και βελτίωση παρουσιάσεων PowerPoint, παρέχοντας στους προγραμματιστές ισχυρό έλεγχο των διαφανειών."
---
## **Introduction**

Οι έλεγχοι ActiveX χρησιμοποιούνται σε παρουσιάσεις. Το Aspose.Slides για PHP μέσω Java σάς επιτρέπει να προσθέτετε και να διαχειρίζεστε ελέγχους ActiveX, αλλά είναι λίγο πιο δύσκολο να τους διαχειριστείτε σε σύγκριση με τα κανονικά σχήματα παρουσίασης. Έχουμε υλοποιήσει υποστήριξη για την προσθήκη ελέγχου Media Player Active στο Aspose.Slides. Σημειώστε ότι οι έλεγχοι ActiveX δεν είναι σχήματα· δεν αποτελούν μέρος του [ShapeCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/). Αντί αυτού, αποτελούν μέρος του ξεχωριστού [ControlCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/controlcollection/) . Σε αυτό το θέμα, θα σας δείξουμε πώς να εργάζεστε με αυτούς.

## **Add a Media Player ActiveX Control to a Slide**
Για να προσθέσετε έναν έλεγχο Media Player ActiveX, κάντε το εξής:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation) και δημιουργήστε μια κενή παρουσίαση.
2. Προσπελάστε τη διαφάνεια‑στόχο στην [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation).
3. Προσθέστε τον έλεγχο Media Player ActiveX χρησιμοποιώντας τη μέθοδο [addControl](https://reference.aspose.com/slides/el/php-java/aspose.slides/controlcollection/addcontrol/) που εκτίθεται από το [ControlCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/controlcollection/).
4. Προσπελάστε τον έλεγχο Media Player ActiveX και ορίστε τη διαδρομή βίντεο χρησιμοποιώντας τις ιδιότητές του.
5. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

Αυτό το δείγμα κώδικα, με βάση τα παραπάνω βήματα, δείχνει πώς να προσθέσετε τον έλεγχο Media Player ActiveX σε μια διαφάνεια:

```php
  # Δημιουργία κενής παρουσίασης
  $pres = new Presentation();
  try {
    # Προσθήκη του ελέγχου Media Player ActiveX
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # Πρόσβαση στον έλεγχο Media Player ActiveX και ορισμός της διαδρομής βίντεο
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # Αποθήκευση της παρουσίασης
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Modify an ActiveX Control**
{{% alert color="primary" %}} 

Το Aspose.Slides για PHP μέσω Java 7.1.0 και νεότερες εκδόσεις διαθέτουν συστατικά για διαχείριση ελέγχων ActiveX. Μπορείτε να προσπελάσετε τον ήδη προστεθειμένο έλεγχο ActiveX στην παρουσίασή σας και να τον τροποποιήσετε ή να τον διαγράψετε μέσω των ιδιοτήτων του.

{{% /alert %}} 

Για να διαχειριστείτε έναν απλό έλεγχο ActiveX, όπως ένα πλαίσιο κειμένου και ένα απλό κουμπί εντολής σε μια διαφάνεια, κάντε το εξής:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation) και φορτώστε την παρουσίαση που περιέχει ελέγχους ActiveX.
2. Αποκτήστε μια αναφορά διαφάνειας βάσει του δείκτη της.
3. Προσπελάστε τους ελέγχους ActiveX στη διαφάνεια προσπελάζοντας το [ControlCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/controlcollection/).
4. Προσπελάστε τον έλεγχο ActiveX TextBox1 χρησιμοποιώντας το αντικείμενο [Control](https://reference.aspose.com/slides/el/php-java/aspose.slides/control/).
5. Αλλάξτε τις ιδιότητες του ελέγχου ActiveX TextBox1 που περιλαμβάνουν το κείμενο, τη γραμματοσειρά, το ύψος γραμματοσειράς και τη θέση του πλαισίου.
6. Προσπελάστε τον δεύτερο έλεγχο που ονομάζεται CommandButton1.
7. Αλλάξτε τη λεζάντα του κουμπιού, τη γραμματοσειρά και τη θέση.
8. Μετακινήστε τη θέση των πλαισίων των ελέγχων ActiveX.
9. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

Αυτό το δείγμα κώδικα, με βάση τα παραπάνω βήματα, δείχνει πώς να διαχειριστείτε έναν απλό έλεγχο ActiveX: 

```php
  # Πρόσβαση στην παρουσίαση με ελέγχους ActiveX
  $pres = new Presentation("ActiveX.pptm");
  try {
    # Πρόσβαση στην πρώτη διαφάνεια της παρουσίασης
    $slide = $pres->getSlides()->get_Item(0);
    # αλλαγή κειμένου TextBox
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "Changed text";
      $control->getProperties()->set_Item("Value", $newText);
      # Αλλαγή εικόνας υποκατάστασης. Το PowerPoint θα αντικαταστήσει αυτή την εικόνα κατά την ενεργοποίηση του ActiveX,
      # έτσι κάποιες φορές είναι εντάξει να αφήσουμε την εικόνα αμετάβλητη.
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->window);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $graphics->drawString($newText, 10, 20);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # Αλλαγή λεζάντας κουμπιού
    $control = $pres->getSlides()->get_Item(0)->getControls()->get_Item(1);
    if (!java_is_null($control->getName()->equalsIgnoreCase("CommandButton1") && $control->getProperties())) {
      $newCaption = "Show MessageBox";
      $control->getProperties()->set_Item("Caption", $newCaption);
      # Αλλαγή υποκατάστασης
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->control);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $metrics = $graphics->getFontMetrics($font);
      $graphics->drawString($newCaption, $image->getWidth() - $metrics->stringWidth($newCaption) / 2, 20);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # μετακίνηση 100 μονάδων προς τα κάτω
    foreach($pres->getSlides()->get_Item(0)->getControls() as $ctl) {
      $frame = $ctl->getFrame();
      $ctl->setFrame(new ShapeFrame($frame->getX(), $frame->getY() + 100, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation()));
    }
    $pres->save("withActiveX-edited_java.pptm", SaveFormat::Pptm);
    # αφαίρεση ελέγχων
    $pres->getSlides()->get_Item(0)->getControls()->clear();
    $pres->save("withActiveX-cleared_java.pptm", SaveFormat::Pptm);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Διατηρεί το Aspose.Slides τους ελέγχους ActiveX κατά την ανάγνωση και επαναποθήκευση εάν δεν μπορούν να εκτελεστούν στο περιβάλλον χρόνου εκτέλεσης της Java;**

Ναι. Το Aspose.Slides τους αντιμετωπίζει ως μέρος της παρουσίασης και μπορεί να διαβάσει/τροποποιήσει τις ιδιότητές τους και τα πλαίσια· δεν απαιτείται η εκτέλεση των ελέγχων για να διατηρηθούν.

**Πώς διαφέρουν οι έλεγχοι ActiveX από τα αντικείμενα OLE σε μια παρουσίαση;**

Οι έλεγχοι ActiveX είναι διαδραστικά διαχειριζόμενα στοιχεία (πλήκτρα, πλαίσια κειμένου, media player), ενώ το [OLE](/slides/el/php-java/manage-ole/) αφορά ενσωματωμένα αντικείμενα εφαρμογών (π.χ., ένα φύλλο εργασίας Excel). Αποθηκεύονται και διαχειρίζονται διαφορετικά και έχουν διαφορετικά μοντέλα ιδιοτήτων.

**Λειτουργούν τα γεγονότα ActiveX και οι μακροεντολές VBA εάν το αρχείο έχει τροποποιηθεί από το Aspose.Slides;**

Το Aspose.Slides διατηρεί την υπάρχουσα σήμανση και τα μεταδεδομένα· ωστόσο, τα γεγονότα και οι μακροεντολές εκτελούνται μόνο μέσα στο PowerPoint στα Windows όταν η ασφάλεια το επιτρέπει. Η βιβλιοθήκη δεν εκτελεί VBA.