---
title: Υπερσύνδεσμος
type: docs
weight: 130
url: /el/php-java/examples/elements/hyperlink/
keywords:
- υπερσύνδεσμος
- προσθήκη υπερσυνδέσμου
- πρόσβαση σε υπερσύνδεσμο
- αφαίρεση υπερσυνδέσμου
- ενημέρωση υπερσυνδέσμου
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Προσθήκη, επεξεργασία και αφαίρεση υπερσυνδέσμων σε PHP με Aspose.Slides: κείμενο συνδέσμου, σχήματα, διαφάνειες, URL και email· ορίστε στόχους και ενέργειες για PPT, PPTX και ODP."
---
Δείχνει πώς να προσθέτετε, να προσπελάζετε, να αφαιρείτε και να ενημερώνετε υπερσυνδέσμους σε σχήματα χρησιμοποιώντας **Aspose.Slides for PHP via Java**.

## **Προσθήκη υπερσυνδέσμου**

Δημιουργήστε ένα ορθογώνιο σχήμα με έναν υπερσύνδεσμο που οδηγεί σε έναν εξωτερικό ιστότοπο.

```php
function addHyperlink() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
        $shape->getTextFrame()->setText("Aspose");

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        $presentation->save("hyperlink.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Πρόσβαση σε υπερσύνδεσμο**

Αναγνώστε πληροφορίες υπερσυνδέσμου από το τμήμα κειμένου ενός σχήματος.

```php
function accessHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Υποθέτοντας ότι το πρώτο σχήμα περιέχει τον υπερσύνδεσμο.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $hyperlink = $portion->getPortionFormat()->getHyperlinkClick();
    } finally {
        $presentation->dispose();
    }
}
```

## **Αφαίρεση υπερσυνδέσμου**

Καθαρίστε τον υπερσύνδεσμο από το κείμενο ενός σχήματος.

```php
function removeHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Υποθέτοντας ότι το πρώτο σχήμα περιέχει τον υπερσύνδεσμο.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(null);

        $presentation->save("hyperlink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ενημέρωση υπερσυνδέσμου**

Αλλάξτε τον προορισμό ενός υπάρχοντος υπερσυνδέσμου. Χρησιμοποιήστε το `HyperlinkManager` για να τροποποιήσετε κείμενο που ήδη περιέχει υπερσύνδεσμο, προσομοιώνοντας τον τρόπο με τον οποίο το PowerPoint ενημερώνει ασφαλώς τους υπερσυνδέσμους.

```php
function updateHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Υποθέτοντας ότι το πρώτο σχήμα περιέχει τον υπερσύνδεσμο.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);

        // Η αλλαγή ενός υπερσυνδέσμου μέσα σε υπάρχον κείμενο πρέπει να γίνει μέσω
        // HyperlinkManager αντί για άμεση ανάθεση της ιδιότητας.
        // Αυτό προσομοιώνει τον τρόπο με τον οποίο το PowerPoint ενημερώνει με ασφάλεια τους υπερσυνδέσμους.
        $portion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://new.example.com");

        $presentation->save("hyperlink_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```