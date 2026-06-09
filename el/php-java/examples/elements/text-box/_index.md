---
title: Πλαίσιο κειμένου
type: docs
weight: 40
url: /el/php-java/examples/elements/text-box/
keywords:
- πλαίσιο κειμένου
- προσθήκη πλαισίου κειμένου
- πρόσβαση σε πλαίσιο κειμένου
- αφαίρεση πλαισίου κειμένου
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δημιουργήστε και μορφοποιήστε πλαίσια κειμένου σε PHP με Aspose.Slides: ορίστε γραμματοσειρές, στοίχιση, αναδίπλωση, αυτόματη προσαρμογή και συνδέσμους για βελτίωση των διαφανειών σε PowerPoint και OpenDocument."
---
Στο Aspose.Slides, ένα **πλαίσιο κειμένου** αντιπροσωπεύεται από ένα `AutoShape`. Σχεδόν κάθε σχήμα μπορεί να περιέχει κείμενο, αλλά ένα τυπικό πλαίσιο κειμένου δεν έχει γέμισμα ή περίγραμμα και εμφανίζει μόνο κείμενο.

Αυτός ο οδηγός εξηγεί πώς να προσθέτετε, να προσπελάζετε και να αφαιρείτε πλαίσια κειμένου προγραμματιστικά.

## **Προσθήκη πλαισίου κειμένου**

Ένα πλαίσιο κειμένου είναι απλώς ένα `AutoShape` χωρίς γέμισμα ή περίγραμμα και με κάποια μορφοποιημένα κείμενα. Δείτε πώς να δημιουργήσετε ένα:

```php
function addTextBox() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Δημιουργήστε ένα σχήμα ορθογωνίου (προεπιλογή είναι γεμάτο με περίγραμμα και χωρίς κείμενο).
        $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

        // Αφαιρέστε τη γέμισμα και το περίγραμμα ώστε να μοιάζει με τυπικό πλαίσιο κειμένου.
        $textBox->getFillFormat()->setFillType(FillType::NoFill);
        $textBox->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        // Ορίστε τη μορφοποίηση του κειμένου.
        $paragraph = $textBox->getTextFrame()->getParagraphs()->get_Item(0);
        $portionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $portionFormat->getFillFormat()->setFillType(FillType::Solid);
        $portionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        // Αντιστοιχίστε το πραγματικό περιεχόμενο κειμένου.
        $textBox->getTextFrame()->setText("Some text...");

        $presentation->save("text_box.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Σημείωση:** Κάθε `AutoShape` που περιέχει ένα μη-κενό `TextFrame` μπορεί να λειτουργήσει ως πλαίσιο κειμένου.

## **Πρόσβαση σε πλαίσια κειμένου βάσει περιεχομένου**

Για να βρείτε όλα τα πλαίσια κειμένου που περιέχουν μια συγκεκριμένη λέξη-κλειδί (π.χ. "Slide"), επανλάβετε τα σχήματα και ελέγξτε το κείμενό τους:

```php
function accessTextBox() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Πρόσβαση στο πρώτο πλαίσιο κειμένου στη διαφάνεια.
        $firstTextBox = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $firstTextBox = $shape;
                if (strpos($firstTextBox->getTextFrame()->getText(), "Slide") !== false) {
                    // Κάντε κάτι με το αντίστοιχο πλαίσιο κειμένου.
                }
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Αφαίρεση πλαισίων κειμένου βάσει περιεχομένου**

Αυτό το παράδειγμα εντοπίζει και διαγράφει όλα τα πλαίσια κειμένου στην πρώτη διαφάνεια που περιέχουν μια συγκεκριμένη λέξη-κλειδί:

```php
function removeTextBoxes() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shapesToRemove = [];

        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $autoShape = $shape;
                if (strpos($autoShape->getTextFrame()->getText(), "Slide") !== false) {
                    $shapesToRemove[] = $shape;
                }
            }
        }

        foreach ($shapesToRemove as $shape) {
            $slide->getShapes()->remove($shape);
        }

        $presentation->save("text_boxes_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Συμβουλή:** Πάντα δημιουργείτε αντίγραφο της συλλογής σχημάτων πριν το τροποποιήσετε κατά την επανάληψη, ώστε να αποφύγετε σφάλματα τροποποίησης της συλλογής.