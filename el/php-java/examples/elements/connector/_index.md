---
title: Σύνδεσμος
type: docs
weight: 190
url: /el/php-java/examples/elements/connector/
keywords:
- σύνδεσμος
- προσθήκη συνδέσμου
- πρόσβαση σε σύνδεσμο
- αφαίρεση συνδέσμου
- επανασύνδεση σχημάτων
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Σχεδιάστε και ελέγξτε τους συνδέσμους σε PHP με Aspose.Slides: προσθήκη, δρομολόγηση, επαναδρομολόγηση, ορισμός σημείων σύνδεσης, βελών και στυλ για τη σύνδεση σχημάτων σε PPT, PPTX και ODP."
---
Δείχνει πώς να συνδέσετε σχήματα με συνδέσμους και να αλλάξετε τους προορισμούς τους χρησιμοποιώντας **Aspose.Slides for PHP via Java**.

## **Προσθήκη συνδέσμου**

Εισάγετε ένα σχήμα συνδέσμου μεταξύ δύο σημείων στη διαφάνεια.

```php
function addConnector() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $connector = $slide->Shapes->addConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

        $presentation->save("connector.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Πρόσβαση σε σύνδεσμο**

Ανακτήστε το πρώτο σχήμα συνδέσμου που προστέθηκε σε μια διαφάνεια.

```php
function accessConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Πρόσβαση στον πρώτο σύνδεσμο στη διαφάνεια.
        $firstConnector = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $firstConnector = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Αφαίρεση συνδέσμου**

Διαγράψτε έναν σύνδεσμο από τη διαφάνεια.

```php
function removeConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Υποθέτοντας ότι το πρώτο σχήμα στη διαφάνεια είναι σύνδεσμος.
        $connector = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($connector);

        $presentation->save("connector_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Επανασύνδεση σχημάτων**

Επισυνάψτε έναν σύνδεσμο σε δύο σχήματα ορίζοντας τους αρχικούς και τελικούς προορισμούς.

```php
function reconnectShapes() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
        $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 50, 50);
        $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

        $connector->setStartShapeConnectedTo($shape1);
        $connector->setEndShapeConnectedTo($shape2);

        $presentation->save("shapes_reconnected.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```