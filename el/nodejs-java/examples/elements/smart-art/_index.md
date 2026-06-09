---
title: SmartArt
type: docs
weight: 140
url: /el/nodejs-java/examples/elements/smart-art/
keywords:
- παράδειγμα κώδικα
- SmartArt
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Εργαστείτε με SmartArt στο Aspose.Slides για Node.js: δημιουργήστε, επεξεργαστείτε, μετατρέψτε και μορφοποιήστε διαγράμματα με JavaScript για παρουσιάσεις PowerPoint και OpenDocument."
---
Αυτό το άρθρο παρουσιάζει πώς να προσθέσετε γραφικά SmartArt, να τα αποκτήσετε, να τα αφαιρέσετε και να αλλάξετε διατάξεις χρησιμοποιώντας **Aspose.Slides for Node.js via Java**.

## **Προσθήκη SmartArt**

Εισάγετε ένα γραφικό SmartArt χρησιμοποιώντας μία από τις ενσωματωμένες διατάξεις.

```js
function addSmartArt() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, aspose.slides.SmartArtLayoutType.BasicProcess);

        presentation.save("smartart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση SmartArt**

Ανακτήστε το πρώτο αντικείμενο SmartArt σε μια διαφάνεια.

```js
function accessSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstSmartArt = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
                firstSmartArt = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση SmartArt**

Διαγράψτε ένα σχήμα SmartArt από τη διαφάνεια.

```js
function removeSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Θεωρώντας ότι το πρώτο σχήμα είναι SmartArt.
        let smartArt = slide.getShapes().get_Item(0);

        slide.getShapes().remove(smartArt);

        presentation.save("smartart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Αλλαγή Διάταξης SmartArt**

Ενημερώστε τον τύπο διάταξης ενός υπάρχοντος γραφικού SmartArt.

```js
function changeSmartArtLayout() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Θεωρώντας ότι το πρώτο σχήμα είναι SmartArt.
        let smartArt = slide.getShapes().get_Item(0);

        smartArt.setLayout(aspose.slides.SmartArtLayoutType.VerticalPictureList);

        presentation.save("smartart_layout_changed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```