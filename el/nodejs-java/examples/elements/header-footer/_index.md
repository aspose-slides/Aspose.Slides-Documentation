---
title: Κεφαλίδα Υποσέλιδο
type: docs
weight: 220
url: /el/nodejs-java/examples/elements/header-footer/
keywords:
- παράδειγμα κώδικα
- κεφαλίδα
- υποσέλιδο
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Έλεγχος κεφαλίδων και υποσελίδων διαφανειών με Aspose.Slides για Node.js: προσθέστε ημερομηνίες, αριθμούς διαφανειών και προσαρμοσμένο κείμενο σε PPT, PPTX και ODP με παραδείγματα JavaScript."
---
Αυτό το άρθρο δείχνει πώς να προσθέσετε υποσέλιδα και να ενημερώσετε τις θέσεις κράτησης ημερομηνίας και ώρας χρησιμοποιώντας **Aspose.Slides for Node.js via Java**.

## **Προσθήκη Υποσέλιδας**

Προσθέστε κείμενο στην περιοχή υποσέλιδας μιας διαφάνειας και κάντε το ορατό.

```js
function addHeaderFooter() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);

        presentation.save("header_footer.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Ενημέρωση Ημερομηνίας και Ώρας**

Τροποποιήστε το σύμβολο κράτησης ημερομηνίας και ώρας σε μια διαφάνεια.

```js
function updateDateTime() {
    let presentation = new aspose.slides.Presentation("header_footer.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);

        presentation.save("header_footer_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```