---
title: Διαχείριση SmartArt σε παρουσιάσεις PowerPoint χρησιμοποιώντας PHP
linktitle: Διαχείριση SmartArt
type: docs
weight: 10
url: /el/php-java/manage-smartart/
keywords:
- SmartArt
- Κείμενο SmartArt
- Τύπος διάταξης
- Ιδιότητα κρυμμένου
- Διάγραμμα οργανισμού
- Διάγραμμα οργανισμού με εικόνα
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να επεξεργάζεστε SmartArt PowerPoint με το Aspose.Slides για PHP μέσω Java, χρησιμοποιώντας σαφή παραδείγματα κώδικα που επιταχύνουν το σχεδιασμό και την αυτοματοποίηση διαφανειών."
---
## **Επισκόπηση**

Το SmartArt είναι ένα διάγραμμα PowerPoint που δημιουργείται από κόμβους, σχήματα κόμβων και μια διάταξη. Με το Aspose.Slides για PHP μέσω Java, μπορείτε να δημιουργήσετε SmartArt, να διαβάσετε κείμενο από τους κόμβους του, να αλλάξετε τη διάταξή του, να εξετάσετε κρυμμένους κόμβους, να ρυθμίσετε διατάξεις διαγραμμάτων οργανισμού και να δημιουργήσετε διαγράμματα οργανισμού με εικόνες.

## **Λήψη κειμένου από αντικείμενο SmartArt**

Ένας κόμβος SmartArt μπορεί να περιέχει ένα ή περισσότερα σχήματα. Για να διαβάσετε το κείμενο από τα σχήματα του κόμβου, επαναλάβετε μέσω του [SmartArt::getAllNodes](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/getallnodes/), στη συνέχεια διαβάστε το [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) που επιστρέφεται από το [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/smartartshape/gettextframe/).

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->get_Item(0);
    for ($i = 0; $i < java_values($smartArt->getAllNodes()->size()); $i++) {
        $node = $smartArt->getAllNodes()->get_Item($i);
        for ($j = 0; $j < java_values($node->getShapes()->size()); $j++) {
            $nodeShape = $node->getShapes()->get_Item($j);
            if (!java_is_null($nodeShape->getTextFrame())) {
                echo $nodeShape->getTextFrame()->getText() . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Αλλαγή τύπου διάταξης ενός αντικειμένου SmartArt**

Η διάταξη SmartArt ελέγχει πώς διατάσσονται και συνδέονται οι κόμβοι. Το παρακάτω παράδειγμα δημιουργεί ένα αντικείμενο SmartArt με την τιμή [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, την αλλάζει στην τιμή `BasicProcess` και αποθηκεύει την παρουσίαση. Η θέση και το μέγεθος που περνιούνται στο [ShapeCollection::addSmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) μετριούνται σε μονάδες. Χρησιμοποιήστε το [SmartArt::setLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setlayout/) για να αλλάξετε τη διάταξη.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Έλεγχος αν ένας κόμβος SmartArt είναι κρυμμένος**

Το [SmartArtNode::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) υποδεικνύει αν ο κόμβος είναι κρυμμένος στο μοντέλο δεδομένων SmartArt. Οι κρυμμένοι κόμβοι μπορούν να υπάρχουν στη δομή ακόμη και όταν η επιλεγμένη διάταξη δεν τους εμφανίζει ως ορατά στοιχεία διαγράμματος.

Το παρακάτω παράδειγμα προσθέτει έναν κόμβο σε ένα αντικείμενο SmartArt που χρησιμοποιεί την τιμή [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `RadialCycle` και ελέγχει την κρυφή κατάσταση του προστεθέντος κόμβου. Εκτυπώνει ένα μήνυμα εάν ο κόμβος είναι κρυμμένος και αποθηκεύει το διάγραμμα.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    $node = $smartArt->getAllNodes()->addNode();
    $isHidden = java_values($node->isHidden());

    if ($isHidden) {
        echo "The node is hidden in the SmartArt data model." . PHP_EOL;
    }

    $presentation->save("CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Λήψη ή ορισμός διάταξης διαγράμματος οργανισμού**

Για διαγράμματα SmartArt που χρησιμοποιούν διάταξη διαγράμματος οργανισμού, τα [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) και [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) καθορίζουν πώς διατάσσονται οι θυγατρικοί κόμβοι κάτω από έναν γονικό κόμβο. Για παράδειγμα, μπορείτε να ορίσετε τους θυγατρικούς κόμβους να κρέμονται από τη αριστερή, τη δεξιά ή και τις δύο πλευρές, ανάλογα με την επιλεγμένη [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/).

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα οργανισμού και ορίζει τη διάταξη για τον πρώτο κόμβο στην τιμή [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`. Ο μηδενικός δείκτης `0` επιλέγει τον πρώτο κόμβο υψηλότερου επιπέδου· οι θυγατρικοί του κόμβοι χρησιμοποιούν τη επιλεγμένη διάταξη. Η τροποποιημένη παρουσίαση αποθηκεύεται έπειτα.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;
use aspose\slides\OrganizationChartLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Δημιουργία διαγράμματος οργανισμού με εικόνα**

Ένα διάγραμμα οργανισμού με εικόνα είναι μια διάταξη SmartArt σχεδιασμένη για διαγράμματα ιεραρχίας που περιλαμβάνουν χώρο κράτησης εικόνας. Χρησιμοποιήστε την τιμή [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` όταν προσθέτετε το αντικείμενο SmartArt σε μια διαφάνεια. Αυτό το παράδειγμα αποθηκεύει ένα διάγραμμα με χώρους εικόνας· δεν γεμίζει τους χώρους με εικόνες.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Μετατροπή παλαιών διαγραμμάτων σε ομάδες σχημάτων**

Κατά τη μοντερνισή μιας υπάρχουσας παρουσίασης, μπορεί να χρειαστεί να ενημερώσετε ένα διάγραμμα οργανισμού που δημιουργήθηκε αρχικά στο PowerPoint 97–2003. Το Aspose.Slides αντιπροσωπεύει αυτά τα παλιά διαγράμματα ως αντικείμενα [LegacyDiagram](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/). Χρησιμοποιήστε το [LegacyDiagram::convertToGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/converttogroupshape/) για να μετατρέψετε ένα διάγραμμα σε ομάδα σχημάτων ώστε να μπορείτε να επεξεργαστείτε επιμέρους οπτικά στοιχεία. Δείτε την [LegacyDiagram API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/) για λεπτομέρειες.

Η μετατροπή προσθέτει μια νέα ομάδα στη συλλογή σχημάτων χωρίς να αφαιρεί το αρχικό διάγραμμα. Μετά την επιτυχή μετατροπή, αφαιρέστε το αρχικό με το [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) για να αποφύγετε διπλό περιεχόμενο. Συλλέξτε τα παλιά διαγράμματα σε λίστα πριν τα μετατρέψετε, ώστε η προσθήκη και η αφαίρεση σχημάτων να μην διακόπτει την επανάληψη.

Το παρακάτω παράδειγμα ανοίγει μια παρουσίαση, ψάχνει σε κάθε διαφάνεια, μετατρέπει τα διαγράμματα σε ομάδες σχημάτων και αποθηκεύει την ενημερωμένη παρουσίαση ως PPTX.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("legacy-diagrams.ppt");
try {
    $legacyDiagramType = new JavaClass("com.aspose.slides.ILegacyDiagram");
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $legacyDiagrams = [];
        for ($j = 0; $j < java_values($slide->getShapes()->size()); $j++) {
            $shape = $slide->getShapes()->get_Item($j);
            if (java_instanceof($shape, $legacyDiagramType)) {
                $legacyDiagrams[] = $shape;
            }
        }

        foreach ($legacyDiagrams as $legacyDiagram) {
            $groupShape = $legacyDiagram->convertToGroupShape();

            if (!java_is_null($groupShape)) {
                $slide->getShapes()->remove($legacyDiagram);
            }
        }
    }

    $presentation->save("modernized.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η αποθηκευμένη παρουσίαση περιέχει επεξεργάσιμες ομάδες σχημάτων στη θέση των μετατρεπόμενων παλαιών διαγραμμάτων, χωρίς να παραμείνουν τα αρχικά διαγράμματα. Ανοίξτε το PPTX στο PowerPoint για να επεξεργαστείτε μεμονωμένα στοιχεία σε κάθε ομάδα, όπως το κείμενο, το γέμισμα ή τη θέση.

## **Συχνές ερωτήσεις**

**Υποστηρίζει το SmartArt κατοπτρισμό ή αντιστροφή για γλώσσες RTL;**

Ναι. Η μέθοδος [SmartArt::setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) αλλάζει την κατεύθυνση του διαγράμματος από αριστερά προς δεξιά σε δεξιά προς αριστερά, ή αντίστροφα, όταν η επιλεγμένη διάταξη SmartArt υποστηρίζει την αντιστροφή.

**Πώς μπορώ να αντιγράψω το SmartArt στην ίδια διαφάνεια ή σε άλλη παρουσίαση διατηρώντας τη μορφοποίηση;**

Μπορείτε να [κλωνοποιήσετε το σχήμα SmartArt](/slides/el/php-java/shape-manipulations/) με το [ShapeCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/) ή να [κλωνοποιήσετε ολόκληρη τη διαφάνεια](/slides/el/php-java/clone-slides/) που περιέχει το SmartArt. Και οι δύο προσεγγίσεις διατηρούν το μέγεθος, τη θέση και τη μορφοποίηση.

**Πώς μπορώ να αποδώσω το SmartArt σε εικόνα raster για προεπισκόπηση ή εξαγωγή στο web;**

[Αποδώστε τη διαφάνεια](/slides/el/php-java/convert-powerpoint-to-png/) ή ολόκληρη την παρουσίαση σε PNG ή JPEG. Το SmartArt αποδίδεται ως μέρος της διαφάνειας.

**Πώς μπορώ να βρω ένα συγκεκριμένο αντικείμενο SmartArt σε μια διαφάνεια εάν υπάρχουν πολλά;**

Χρησιμοποιήστε το [Shape::setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) ή το [Shape::setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/) για να εκχωρήσετε ένα ξεχωριστό εναλλακτικό κείμενο ή όνομα στο σχήμα SmartArt, αναζητήστε αυτή την τιμή στο [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes), και στη συνέχεια ελέγξτε ότι το αντιστοίχιο σχήμα είναι ένα [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/).