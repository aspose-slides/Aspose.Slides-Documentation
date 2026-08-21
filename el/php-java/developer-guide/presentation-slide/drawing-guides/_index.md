---
title: Διαχειριστείτε τους Οδηγούς Σχεδίασης σε Παρουσιάσεις σε PHP
linktitle: Οδηγοί Σχεδίασης
type: docs
weight: 85
url: /el/php-java/drawing-guides/
keywords:
- οδηγός σχεδίασης
- οριζόντιος οδηγός
- κάθετος οδηγός
- οδηγός ευθυγράμμισης
- προβολή διαφάνειας
- master διαφάνειας
- διαφάνεια διάταξης
- master σημειώσεων
- master φυλλαδίου
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Προσθέστε, αποκτήστε πρόσβαση και διαγράψτε οριζόντιους και κάθετους οδηγούς σχεδίασης σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java."
---
## **Επισκόπηση**

Οι οδηγοί σχεδίασης είναι ρυθμιζόμενες οριζόντιες και κατακόρυφες γραμμές που βοηθούν τους χρήστες να ευθυγραμμίζουν τα σχήματα με συνέπεια κατά την επεξεργασία μιας παρουσίασης στο PowerPoint. Είναι ιδιαίτερα χρήσιμοι όταν μια εφαρμογή δημιουργεί μια παρουσίαση που θα βελτιωθεί χειροκίνητα αργότερα: η εφαρμογή μπορεί να αποθηκεύσει τα ίδια βοηθήματα ευθυγράμμισης που πρέπει να ακολουθήσουν οι συγγραφείς κατά την προσθήκη ή τη μετακίνηση του περιεχομένου.

Οι οδηγοί σχεδίασης είναι βοηθήματα επεξεργασίας, όχι περιεχόμενο διαφάνειας. Δεν εμφανίζονται σε παρουσίαση ή σε εξαγόμενο αποτέλεσμα. Το Aspose.Slides for PHP via Java τα εκθέτει μέσω της κλάσης [DrawingGuidesCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/drawingguidescollection/) . Ένας οδηγός αναπαρίσταται από το [DrawingGuide](https://reference.aspose.com/slides/el/php-java/aspose.slides/drawingguide/) και διαθέτει προσανατολισμό, θέση και χρώμα.

Η θέση μετράται σε σημεία από την πάνω αριστερή γωνία της σχετικής διαφάνειας ή του master. Ένας κάθετος οδηγός χρησιμοποιεί μια οριζόντια συντεταγμένη, συνήθως μεταξύ του μηδενός και του πλάτους της διαφάνειας. Ένας οριζόντιος οδηγός χρησιμοποιεί μια κατακόρυφη συντεταγμένη, συνήθως μεταξύ του μηδενός και του ύψους της διαφάνειας.

## **Προσθήκη Οδηγών στην Προβολή Διαφάνειας**

Χρησιμοποιήστε το [CommonSlideViewProperties::getDrawingGuides](https://reference.aspose.com/slides/el/php-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) για να διαχειριστείτε τους οδηγούς που εμφανίζονται κατά την επεξεργασία κανονικών διαφανειών. Καλέστε το [DrawingGuidesCollection::add](https://reference.aspose.com/slides/el/php-java/aspose.slides/drawingguidescollection/#add) με μια τιμή [Orientation](https://reference.aspose.com/slides/el/php-java/aspose.slides/orientation/) και μια θέση σε σημεία.

Το παρακάτω παράδειγμα προσθέτει έναν κάθετο οδηγό δεξιά του κέντρου της διαφάνειας και έναν οριζόντιο οδηγό κάτω από αυτόν:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();

    $guides->add(Orientation::Vertical, $slideWidth / 2 + 12.5);
    $guides->add(Orientation::Horizontal, $slideHeight / 2 + 12.5);

    $presentation->save("drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Πρόσβαση στους Οδηγούς Σχεδίασης**

Οι μέθοδοι [DrawingGuidesCollection::getCount](https://reference.aspose.com/slides/el/php-java/aspose.slides/drawingguidescollection/#getCount) και [DrawingGuidesCollection::get_Item](https://reference.aspose.com/slides/el/php-java/aspose.slides/drawingguidescollection/#get_Item) παρέχουν πρόσβαση στους υπάρχοντες οδηγούς. Οι μέθοδοι [DrawingGuide::getOrientation](https://reference.aspose.com/slides/el/php-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide::getPosition](https://reference.aspose.com/slides/el/php-java/aspose.slides/drawingguide/#getPosition) και [DrawingGuide::getColor](https://reference.aspose.com/slides/el/php-java/aspose.slides/drawingguide/#getColor) επιστρέφουν τιμές που μπορούν επίσης να αλλάξουν μέσω των αντίστοιχων μεθόδων setter.

Το παρακάτω παράδειγμα διαβάζει τους οδηγούς προβολής διαφάνειας από την παρουσίαση που δημιουργήθηκε παραπάνω:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("drawing-guides.pptx");
try {
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();
    $guideCount = java_values($guides->getCount());

    for ($index = 0; $index < $guideCount; $index++) {
        $guide = $guides->get_Item($index);
        $orientation = java_values($guide->getOrientation());
        $position = java_values($guide->getPosition());
        $color = java_values($guide->getColor()->toString());
        echo sprintf("Guide %d: orientation = %d, position = %.2f, color = %s", $index, $orientation, $position, $color) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Προσθήκη Οδηγών σε Master και Layout Διαφάνειες**

Ένας master διαφάνειας και κάθε μία από τις layout διαφάνειες του μπορούν να έχουν τις δικές τους συλλογές οδηγών σχεδίασης. Χρησιμοποιήστε το [MasterSlide::getDrawingGuides](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslide/#getDrawingGuides) για έναν master διαφάνειας και το [LayoutSlide::getDrawingGuides](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslide/#getDrawingGuides) για μια layout διαφάνειας.

Το παρακάτω παράδειγμα προσθέτει έναν κάθετο οδηγό στην πρώτη master διαφάνειας και έναν οριζόντιο οδηγό στην πρώτη layout διαφάνειας:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $masterGuides = $presentation->getMasters()->get_Item(0)->getDrawingGuides();
    $layoutGuides = $presentation->getLayoutSlides()->get_Item(0)->getDrawingGuides();

    $masterGuides->add(Orientation::Vertical, $slideWidth / 2 - 20);
    $layoutGuides->add(Orientation::Horizontal, $slideHeight / 2 + 20);

    $presentation->save("master-layout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Προσθήκη Οδηγών σε Notes και Handout Masters**

Οι masters σημειώσεων και των φυλλαδίων υποστηρίζουν επίσης οδηγούς σχεδίασης. Χρησιμοποιήστε το [MasterNotesSlide::getDrawingGuides](https://reference.aspose.com/slides/el/php-java/aspose.slides/masternotesslide/#getDrawingGuides) και το [MasterHandoutSlide::getDrawingGuides](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterhandoutslide/#getDrawingGuides) για να αποκτήσετε πρόσβαση στις συλλογές τους. Εάν η παρουσίαση δεν περιέχει κάποιον από αυτούς τους masters, αποκτήστε τον κατάλληλο διαχειριστή με το [Presentation::getMasterNotesSlideManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getMasterNotesSlideManager) ή το [Presentation::getMasterHandoutSlideManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getMasterHandoutSlideManager), στη συνέχεια δημιουργήστε τον προεπιλεγμένο master με `setDefaultMasterNotesSlide` ή `setDefaultMasterHandoutSlide`.

Το παρακάτω παράδειγμα προσθέτει έναν οριζόντιο οδηγό σε έναν master σημειώσεων και έναν κάθετο οδηγό σε έναν master φυλλαδίου:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $notesSize = $presentation->getNotesSize()->getSize();
    $notesWidth = java_values($notesSize->getWidth());
    $notesHeight = java_values($notesSize->getHeight());
    $notesMaster = $presentation->getMasterNotesSlideManager()->setDefaultMasterNotesSlide();
    $handoutMaster = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();

    $notesMaster->getDrawingGuides()->add(Orientation::Horizontal, $notesHeight / 2 + 50);
    $handoutMaster->getDrawingGuides()->add(Orientation::Vertical, $notesWidth / 2 - 50);

    $presentation->save("notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Καθαρισμός Οδηγών Σχεδίασης**

Καλέστε το [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/el/php-java/aspose.slides/drawingguidescollection/#clear) για να αφαιρέσετε κάθε οδηγό από μια συγκεκριμένη συλλογή. Ο καθαρισμός μιας συλλογής δεν επηρεάζει τους οδηγούς που είναι αποθηκευμένοι σε άλλη εμβέλεια.

Το παρακάτω παράδειγμα καθαρίζει τους οδηγούς προβολής διαφάνειας και όλους τους οδηγούς σε master διαφάνειες, layout διαφάνειες, τον master σημειώσεων και τον master φυλλαδίου χωρίς να δημιουργήσει ελλιπείς masters:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation-with-guides.pptx");
try {
    $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides()->clear();

    $masterCount = java_values($presentation->getMasters()->size());
    for ($index = 0; $index < $masterCount; $index++) {
        $presentation->getMasters()->get_Item($index)->getDrawingGuides()->clear();
    }

    $layoutCount = java_values($presentation->getLayoutSlides()->size());
    for ($index = 0; $index < $layoutCount; $index++) {
        $presentation->getLayoutSlides()->get_Item($index)->getDrawingGuides()->clear();
    }

    $notesMaster = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
        $notesMaster->getDrawingGuides()->clear();
    }

    $handoutMaster = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();
    if (!java_is_null($handoutMaster)) {
        $handoutMaster->getDrawingGuides()->clear();
    }

    $presentation->save("presentation-without-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Εμφανίζονται οι οδηγοί σχεδίασης σε παρουσίαση ή εξαγόμενες εικόνες;**

Όχι. Οι οδηγοί σχεδίασης είναι βοηθήματα ευθυγράμμισης για επεξεργασία και δεν αποδίδονται ως περιεχόμενο παρουσίασης.

**Μπορεί ένας οδηγός σχεδίασης να προστεθεί άμεσα σε μία μεμονωμένη κανονική διαφάνεια;**

Οι οδηγοί επεξεργασίας κανονικής διαφάνειας αποθηκεύονται στις ιδιότητες προβολής διαφάνειας της παρουσίασης. Διαχωρισμένες συλλογές οδηγών είναι διαθέσιμες για τους master διαφάνειες, τις layout διαφάνειες, τους notes masters και τους handout masters.

**Ποια μονάδα χρησιμοποιείται για τις θέσεις των οδηγών;**

Οι θέσεις ορίζονται σε σημεία, όπου 72 σημεία ισοδυναμούν με ένα ίντσα. Οι κάθετες θέσεις μετρώνται από την αριστερή άκρη, και οι οριζόντιες θέσεις από την πάνω άκρη.

**Καθαρίζοντας τους οδηγούς σχεδίασης αφαιρούνται σχήματα ή αλλάζει το περιεχόμενο της διαφάνειας;**

Όχι. Η μέθοδος [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/el/php-java/aspose.slides/drawingguidescollection/#clear) αφαιρεί μόνο τους οδηγούς στην επιλεγμένη συλλογή. Τα σχήματα και το άλλο περιεχόμενο της διαφάνειας παραμένουν αμετάβλητα.