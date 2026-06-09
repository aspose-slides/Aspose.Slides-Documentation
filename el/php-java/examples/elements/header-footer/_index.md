---
title: Κεφαλίδα και Υποσέλιδο
type: docs
weight: 220
url: /el/php-java/examples/elements/header-footer/
keywords:
- κεφαλίδα υποσέλιδο
- προσθήκη κεφαλίδας και υποσέλιδου
- ενημέρωση κεφαλίδας και υποσέλιδου
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Διαχειριστείτε τις κεφαλίδες και τα υποσέλιδα σε PHP με Aspose.Slides: προσθέστε ή επεξεργαστείτε την ημερομηνία/ώρα, τους αριθμούς διαφάνειας και το κείμενο υποσέλιδου, εμφανίστε ή κρύψτε τους δείκτες σε PPT, PPTX και ODP."
---
Δείχνει πώς να προσθέσετε υποσέλιδες και να ενημερώσετε τα δείκτες ημερομηνίας και ώρας χρησιμοποιώντας **Aspose.Slides for PHP via Java**.

## **Προσθήκη υποσέλιδου**

Προσθέστε κείμενο στην περιοχή υποσέλιδου μιας διαφάνειας και κάντε το ορατό.

```php
function addHeaderFooter() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setFooterText("My footer");
        $slide->getHeaderFooterManager()->setFooterVisibility(true);

        $presentation->save("footer.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ενημέρωση ημερομηνίας και ώρας**

Τροποποιήστε το δείκτη ημερομηνίας και ώρας σε μια διαφάνεια.

```php
function updateDateTime() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setDateTimeText("01/01/2024");
        $slide->getHeaderFooterManager()->setDateTimeVisibility(true);

        $presentation->save("datetime.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```