---
title: Διαχείριση SmartArt σε Παρουσιάσεις PowerPoint χρησιμοποιώντας PHP
linktitle: Διαχείριση SmartArt
type: docs
weight: 10
url: /el/php-java/manage-smartart/
keywords:
- SmartArt
- Κείμενο SmartArt
- Τύπος διάταξης
- Κρυφή ιδιότητα
- Διάγραμμα οργανισμού
- Διάγραμμα οργανισμού με εικόνα
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να επεξεργάζεστε SmartArt PowerPoint με το Aspose.Slides για PHP μέσω Java, χρησιμοποιώντας σαφή παραδείγματα κώδικα που επιταχύνουν το σχεδιασμό και την αυτοματοποίηση των διαφανειών."
---
## **Επισκόπηση**

SmartArt είναι ένα διάγραμμα PowerPoint που αποτελείται από κόμβους, σχήματα κόμβων και μια διάταξη. Με το Aspose.Slides για PHP μέσω Java, μπορείτε να δημιουργήσετε SmartArt, να διαβάσετε κείμενο από τους κόμβους του, να αλλάξετε τη διάταξή του, να εξετάσετε κρυφούς κόμβους, να διαμορφώσετε διατάξεις οργανωτικών γραφημάτων και να δημιουργήσετε οργανωτικά γραφήματα με εικόνες.

## **Λήψη κειμένου από ένα αντικείμενο SmartArt**

Ένας κόμβος SmartArt μπορεί να περιέχει ένα ή περισσότερα σχήματα. Για να διαβάσετε το ορατό κείμενο, επαναλάβετε μέσω του [SmartArt::getAllNodes](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartart/#getAllNodes), στη συνέχεια διαβάστε το [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) που επιστρέφεται από το [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartartshape/#getTextFrame).

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.ISmartArt"))) {
        $smartArt = $shape;

        foreach ($smartArt->getAllNodes() as $smartArtNode) {
            foreach ($smartArtNode->getShapes() as $smartArtShape) {
                if (!java_is_null($smartArtShape->getTextFrame())) {
                    echo($smartArtShape->getTextFrame()->getText());
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Αλλαγή τύπου διάταξης ενός αντικειμένου SmartArt**

Η διάταξη SmartArt ελέγχει πώς διατάσσονται και συνδέονται οι κόμβοι. Το παρακάτω παράδειγμα δημιουργεί ένα αντικείμενο SmartArt με την τιμή [SmartArtLayoutType](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, την αλλάζει στην τιμή `BasicProcess` και αποθηκεύει την παρουσίαση.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);

    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Έλεγχος εάν ένας κόμβος SmartArt είναι κρυμμένος**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartartnode/ishidden/) δείχνει εάν ο κόμβος είναι κρυμμένος στο μοντέλο δεδομένων SmartArt. Οι κρυφοί κόμβοι μπορούν να υπάρχουν στη δομή ακόμη και όταν η επιλεγμένη διάταξη δεν τους εμφανίζει ως ορατά στοιχεία διαγράμματος.

Το παρακάτω παράδειγμα προσθέτει έναν κόμβο σε ένα αντικείμενο SmartArt που χρησιμοποιεί την τιμή [SmartArtLayoutType](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartartlayouttype/) `RadialCycle` και ελέγχει την κρυφή κατάσταση του κόμβου.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::RadialCycle);

    $smartArtNode = $smartArt->getAllNodes()->addNode();
    $isHidden = $smartArtNode->isHidden();

    if ($isHidden) {
        echo("The node is hidden in the SmartArt data model.");
    }

    $presentation->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Λήψη ή ορισμός της διάταξης οργανωτικού διαγράμματος**

Για διαγράμματα SmartArt που χρησιμοποιούν διάταξη οργανωτικού διαγράμματος, τα [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) και [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) ορίζουν πώς διατάσσονται οι θυγατρικοί κόμβοι κάτω από έναν γονικό κόμβο. Για παράδειγμα, μπορείτε να ρυθμίσετε τους θυγατρικούς κόμβους να κρέμονται από τα αριστερά, δεξιά ή και από τις δύο πλευρές, ανάλογα με την επιλεγμένη [OrganizationChartLayoutType](https://reference.aspose.com/slides/el/php-java/aspose.slides/organizationchartlayouttype/).

Το παρακάτω παράδειγμα δημιουργεί ένα οργανωτικό διάγραμμα και ορίζει τη διάταξη για τον πρώτο κόμβο στην τιμή [OrganizationChartLayoutType](https://reference.aspose.com/slides/el/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);

    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Δημιουργία οργανωτικού διαγράμματος με εικόνα**

Ένα οργανωτικό διάγραμμα με εικόνα είναι μια διάταξη SmartArt σχεδιασμένη για διαγράμματα ιεραρχίας που περιλαμβάνουν θέση εικόνας. Χρησιμοποιήστε την τιμή [SmartArtLayoutType](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` όταν προσθέτετε το αντικείμενο SmartArt σε μια διαφάνεια.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Συχνές ερωτήσεις**

**Υποστηρίζει το SmartArt την κατοπτρισμό ή αντίστροφη εμφάνιση για γλώσσες RTL;**

Ναι. Η μέθοδος [SmartArt::setReversed](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartart/setreversed/) αλλάζει την κατεύθυνση του διαγράμματος από αριστερά προς δεξιά σε δεξιά προς αριστερά, ή αντίστροφα, όταν η επιλεγμένη διάταξη SmartArt υποστηρίζει την αντιστροφή.

**Πώς μπορώ να αντιγράψω το SmartArt στην ίδια διαφάνεια ή σε άλλη παρουσίαση διατηρώντας τη μορφοποίηση;**

Μπορείτε να [κλωνοποιήσετε το σχήμα SmartArt](/slides/el/php-java/shape-manipulations/) με το [ShapeCollection::addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/addclone/) ή να [κλωνοποιήσετε ολόκληρη τη διαφάνεια](/slides/el/php-java/clone-slides/) που περιέχει το SmartArt. Και οι δύο προσεγγίσεις διατηρούν το μέγεθος, τη θέση και τη μορφοποίηση.

**Πώς αποδίδω το SmartArt σε ραστερ εικόνα για προεπισκόπηση ή εξαγωγή στο web;**

[Αποδώστε τη διαφάνεια](/slides/el/php-java/convert-powerpoint-to-png/) ή ολόκληρη την παρουσίαση σε PNG ή JPEG. Το SmartArt αποδίδεται ως μέρος της διαφάνειας.

**Πώς μπορώ να βρω ένα συγκεκριμένο αντικείμενο SmartArt σε μια διαφάνεια αν υπάρχουν πολλά;**

Ορίστε μια διακριτική τιμή στο [Shape::getAlternativeText](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getalternativetext/) ή στο [Shape::getName](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getname/) του σχήματος SmartArt, ψάξτε για αυτήν την τιμή στο [BaseSlide::getShapes](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseslide/#getShapes) και, στη συνέχεια, ελέγξτε ότι το αντίστοιχο σχήμα είναι ένα [SmartArt](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartart/).