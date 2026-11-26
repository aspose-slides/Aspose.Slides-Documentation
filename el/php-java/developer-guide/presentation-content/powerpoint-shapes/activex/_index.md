---
title: "Διαχείριση Ελέγχων ActiveX σε Παρουσιάσεις Χρησιμοποιώντας PHP"
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
description: "Επεξεργασία πεδίων κειμένου και κουμπιών ActiveX, ενημέρωση προεπισκοπήσεων ελέγχων και επαναχρησιμοποίηση ελέγχου Windows Media Player σε παρουσιάσεις PowerPoint με το Aspose.Slides για PHP μέσω Java."
---
## **Εισαγωγή**

Οι έλεγχοι ActiveX παρέχουν σε μια διαφάνεια του PowerPoint διαδραστικά στοιχεία όπως πεδία κειμένου, κουμπιά εντολών και προγράμματα αναπαραγωγής μέσων. Το Aspose.Slides για PHP μέσω Java εκθέτει τους ελέγχους μιας διαφάνειας μέσω του [BaseSlide::getControls](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getControls). Χρησιμοποιήστε αυτή τη συλλογή για να επεξεργαστείτε έναν έλεγχο, να τον μετακινήσετε στη διαφάνεια ή να τον καταργήσετε.

## **Λίστα Ελέγχων ActiveX και των Αποθηκευμένων Ιδιοτήτων τους**

Για να εξετάσετε ένα άγνωστο πρότυπο, ανοίξτε το για ανάγνωση και επαναλάβετε τους ελέγχους σε κάθε διαφάνεια. Το παράδειγμα αναφέρει τον αριθμό της διαφάνειας, το όνομα του ελέγχου, [getClassId](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getClassId), και κάθε ζεύγος κλειδί‑τιμή στο [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties). Διαβάζει την παρουσίαση χωρίς να ενεργοποιήσει τους ελέγχους, να καλέσει γεγονότα ή μακροεντολές, να αλλάξει τιμές ή να αποθηκεύσει το αρχείο.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ActiveX.pptm");
try {
    $slides = $presentation->getSlides();
    for ($i = 0; $i < java_values($slides->size()); $i++) {
        $controls = $slides->get_Item($i)->getControls();
        for ($j = 0; $j < java_values($controls->size()); $j++) {
            $control = $controls->get_Item($j);
            printf("Slide %d | %s | %s\n", $i + 1, $control->getName(), $control->getClassId());
            $properties = $control->getProperties();
            if (java_is_null($properties)) {
                echo "  Properties unavailable\n";
                continue;
            }
            if (java_values($properties->getCount()) === 0) {
                echo "  []\n";
                continue;
            }
            $names = $properties->getNamesOfProperties()->iterator();
            while (java_values($names->hasNext())) {
                $name = $names->next();
                printf("  %s = %s\n", $name, $properties->get_Item($name));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Η επιλεγμένη έξοδος από το `ActiveX.pptm` εμφανίζει ένα πεδίο κειμένου και ένα κουμπί εντολής.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Μια κενή συλλογή ιδιοτήτων εμφανίζεται ως `[]`. Για ελέγχους που χρησιμοποιούν δυαδική αποθήκευση, το [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties) μπορεί να επιστρέψει `null`, που εμφανίζεται ως `Properties unavailable`. Αν χρειάζεστε μόνο τα ονόματα, χρησιμοποιήστε το [getNamesOfProperties](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) μετά τον έλεγχο για null. Η αναφορά παραθέτει τις ιδιότητες που διατίθενται στην παρουσίαση. Ένας έλεγχος μπορεί να υποστηρίζει επιπλέον ιδιότητες κατά το χρόνο εκτέλεσης.

## **Τροποποίηση Ελέγχων ActiveX**

Το παράδειγμα αναμένει μια παρουσίαση με ενεργοποιημένα μακροεντολές που περιέχει ένα πεδίο κειμένου με όνομα `TextBox1` και ένα κουμπί εντολής με όνομα `CommandButton1` στην πρώτη διαφάνεια. Χρησιμοποιεί τη [control properties collection](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) για να αλλάξει την τιμή του πεδίου κειμένου και τη λεζάντα του κουμπιού. Κάθε έλεγχος διαθέτει επίσης μια στατική προεπισκόπηση που το PowerPoint μπορεί να εμφανίσει πριν την ενεργοποίηση. Παρέχετε ένα PNG για κάθε έλεγχο που δείχνει το ενημερωμένο κείμενο και την εμφάνισή του. Το παράδειγμα αναθέτει αυτές τις εικόνες μέσω του [Control::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getSubstitutePictureFormat).

Το παράδειγμα μετακινεί κάθε έλεγχο στην πρώτη διαφάνεια προς τα κάτω κατά 100 σημεία ορίζοντας το πλαίσιο του με το [Control::setFrame](https://reference.aspose.com/slides/php-java/aspose.slides/control/#setFrame). Αποθηκεύει την επεξεργασμένη παρουσίαση σε μορφή PPTM, στη συνέχεια χρησιμοποιεί το [ControlCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/#clear) για να αποθηκεύσει ένα δεύτερο αντίγραφο με όλους τους ελέγχους ActiveX αφαιρεμένους από εκείνη τη διαφάνεια.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("ActiveX.pptm");
try {
    $controls = $presentation->getSlides()->get_Item(0)->getControls();
    $textBox = null;
    $button = null;
    for ($j = 0; $j < java_values($controls->size()); $j++) {
        $control = $controls->get_Item($j);
        $name = (string) $control->getName();
        if ($name === "TextBox1") {
            $textBox = $control;
        } elseif ($name === "CommandButton1") {
            $button = $control;
        }
    }
    if ($textBox === null || $button === null || java_is_null($textBox->getProperties()) || java_is_null($button->getProperties())) {
        echo "The first slide must contain both named controls with editable properties.\n";
        return;
    }

    foreach ([[$textBox, "text-box-preview.png"], [$button, "button-preview.png"]] as [$control, $path]) {
        $image = Images::fromFile($path);
        try {
            $preview = $presentation->getImages()->addImage($image);
            $control->getSubstitutePictureFormat()->getPicture()->setImage($preview);
        } finally {
            $image->dispose();
        }
    }
    $textBox->getProperties()->set_Item("Value", "Changed text");
    $button->getProperties()->set_Item("Caption", "Show message");

    for ($j = 0; $j < java_values($controls->size()); $j++) {
        $control = $controls->get_Item($j);
        $frame = $control->getFrame();
        $newY = java_values($frame->getY()) + 100;
        $moved = new ShapeFrame($frame->getX(), $newY, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation());
        $control->setFrame($moved);
    }
    $presentation->save("edited-controls.pptm", SaveFormat::Pptm);

    $controls->clear();
    $presentation->save("removed-controls.pptm", SaveFormat::Pptm);
} finally {
    $presentation->dispose();
}
```
## **Προσθήκη Ελέγχου Media Player ActiveX**

Για να ξαναχρησιμοποιήσετε έναν ρυθμισμένο έλεγχο Windows Media Player, ξεκινήστε με ένα πρότυπο της οποίας η πρώτη διαφάνεια περιέχει έναν αναπαραγωγέα με όνομα `WindowsMediaPlayer1`. Το [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addClone) αντιγράφει ολόκληρη τη διαφάνεια σε μια νέα παρουσίαση. Το παράδειγμα ορίζει το `URL` του αναπαραγωγέα στη [properties collection](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) και αποθηκεύει τη κλωνοποιημένη διαφάνεια ως τη μοναδική διαφάνεια στην έξοδο. Το βίντεο παραμένει εξωτερικό, επομένως επιλέξτε μια διαδρομή που ο αναπαραγωγέας να μπορεί να προσπελάσει κατά την αναπαραγωγή.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$template = new Presentation("template.pptx");
try {
    $presentation = new Presentation();
    try {
        $slides = $presentation->getSlides();
        $sourceSlide = $template->getSlides()->get_Item(0);
        $slide = $slides->addClone($sourceSlide);
        $player = null;
        $controls = $slide->getControls();
        for ($j = 0; $j < java_values($controls->size()); $j++) {
            $control = $controls->get_Item($j);
            if ((string) $control->getName() === "WindowsMediaPlayer1") {
                $player = $control;
                break;
            }
        }
        if ($player === null || java_is_null($player->getProperties())) {
            echo "The template slide must contain a named media player with editable properties.\n";
            return;
        }
        $player->getProperties()->set_Item("URL", "Wildlife.mp4");
        $slides->removeAt(0);
        $presentation->save("linked-video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $template->dispose();
}
```
## **Συχνές ερωτήσεις**

**Μπορεί το Aspose.Slides να διατηρήσει τους ελέγχους ActiveX χωρίς να τους εκτελέσει;**

Ναι. Το Aspose.Slides μπορεί να διαβάσει και να αποθηκεύσει ελέγχους, συμπεριλαμβανομένων των ιδιοτήτων και των θέσεών τους, χωρίς να τους ενεργοποιήσει.

**Πώς διαφέρουν οι έλεγχοι ActiveX από τα αντικείμενα OLE;**

Οι έλεγχοι ActiveX επιτρέπουν στους χρήστες να αλληλεπιδράσουν με μια διαφάνεια, για παράδειγμα εισάγοντας κείμενο ή πατώντας ένα κουμπί. Ένα [OLE object](/slides/el/php-java/manage-ole/) επιτρέπει σε μια διαφάνεια να περιέχει ή να συνδέεται με περιεχόμενο που διαχειρίζεται μια άλλη εφαρμογή, όπως ένα φύλλο εργασίας Excel.

**Θα εξακολουθούν οι συμβάντα ActiveX να εκκινούν μακροεντολές VBA μετά την αποθήκευση μιας παρουσίασης με το Aspose.Slides;**

Αποθηκεύστε την παρουσίαση σε μορφή με ενεργοποιημένα μακροεντολές, όπως PPTM, για να διατηρήσετε το έργο VBA. Το PowerPoint για Windows μπορεί να εκτελέσει τους υπάρχοντες χειριστές συμβάντων όταν οι ρυθμίσεις ασφαλείας του επιτρέπουν τόσο ελέγχους ActiveX όσο και μακροεντολές.