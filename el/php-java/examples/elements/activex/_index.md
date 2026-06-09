---
title: ActiveX
type: docs
weight: 200
url: /el/php-java/examples/elements/activex/
keywords:
- ActiveX
- Ελεγκτής ActiveX
- προσθήκη ActiveX
- πρόσβαση ActiveX
- αφαίρεση ActiveX
- Ιδιότητες ActiveX
- παραδείγματα κώδικα
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να εντοπίζετε, να επεξεργάζεστε και να αφαιρείτε ελέγχους ActiveX στο PHP με το Aspose.Slides, συμπεριλαμβανομένων των ενημερώσεων ιδιοτήτων για παρουσιάσεις PowerPoint."
---
Δείχνει πώς να προσθέσετε, να προσπελάσετε, να αφαιρέσετε και να διαμορφώσετε ελέγχους ActiveX σε μια παρουσίαση χρησιμοποιώντας **Aspose.Slides for PHP via Java**.

## **Προσθήκη ελέγχου ActiveX**
Εισάγετε ένα νέο έλεγχο ActiveX.

```php
function addActiveX() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Προσθέτει ένα νέο έλεγχο ActiveX.
        $control = $slide->getControls()->addControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

        $presentation->save("activex.pptm", SaveFormat::Pptm);
    } finally {
        // Αποδέσμευση της παρουσίασης.
        $presentation->dispose();
    }
}
```

## **Πρόσβαση σε έλεγχο ActiveX**
Διαβάστε πληροφορίες από τον πρώτο έλεγχο ActiveX στη διαφάνεια.

```php
function accessActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Πρόσβαση στον πρώτο έλεγχο ActiveX.
        $control = $slide->getControls()->get_Item(0);

        echo "Control Name: " . $control->getName() . PHP_EOL;
    } finally {
        // Αποδέσμευση της παρουσίασης.
        $presentation->dispose();
    }
}
```

## **Αφαίρεση ελέγχου ActiveX**
Διαγράψτε έναν υπάρχοντα έλεγχο ActiveX από τη διαφάνεια.

```php
function removeActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        if (java_values($slide->getControls()->size()) > 0) {
            // Αφαίρεση του πρώτου ελέγχου ActiveX.
            $slide->getControls()->removeAt(0);
        }

        $presentation->save("activex_removed.pptm", SaveFormat::Pptm);
    } finally {
        // Αποδέσμευση της παρουσίασης.
        $presentation->dispose();
    }
}
```

## **Ορισμός ιδιοτήτων ActiveX**
Διαμορφώστε πολλές ιδιότητες ActiveX.

```php
function setActiveXProperties() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Υποθέτοντας ότι ο πρώτος έλεγχος είναι αυτός που προσθέσαμε.
        $control = $slide->getControls()->get_Item(0);

        // Διαμόρφωση ιδιοτήτων.
        $control->getProperties()->set_Item("Caption", "Click Me");
        $control->getProperties()->set_Item("Enabled", "true");

        $presentation->save("activex_properties.pptm", SaveFormat::Pptm);
    } finally {
        // Αποδέσμευση της παρουσίασης.
        $presentation->dispose();
    }
}
```