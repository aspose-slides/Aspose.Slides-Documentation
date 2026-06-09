---
title: Σύνδεσμος
type: docs
weight: 190
url: /el/nodejs-java/examples/elements/connector/
keywords:
- παράδειγμα κώδικα
- Σύνδεσμος
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, να δρομολογείτε και να μορφοποιείτε συνδέσμους μεταξύ σχημάτων χρησιμοποιώντας Aspose.Slides για Node.js, με παραδείγματα JavaScript για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να συνδέσετε σχήματα με συνδέσμους και να αλλάξετε τους προορισμούς τους χρησιμοποιώντας **Aspose.Slides for Node.js via Java**.

## **Προσθήκη Συνδέσμου**

Εισάγετε ένα σχήμα συνδέσμου μεταξύ δύο σημείων στη διαφάνεια.

```js
function addConnector() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 100, 100);

        presentation.save("connector.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε Σύνδεσμο**

Ανακτήστε το πρώτο σχήμα συνδέσμου που προστέθηκε σε μια διαφάνεια.

```js
function accessConnector() {
    let presentation = new aspose.slides.Presentation("connector.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Πρόσβαση στον πρώτο σύνδεσμο στη διαφάνεια.
        let connector = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                connector = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση Συνδέσμου**

Διαγράψτε ένα σύνδεσμο από τη διαφάνεια.

```js
function removeConnector() {
    let presentation = new aspose.slides.Presentation("connector.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Υποθέτουμε ότι το πρώτο σχήμα είναι σύνδεσμος και το αφαιρούμε.
        slide.getShapes().removeAt(0);

        presentation.save("connector_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Επανασύνδεση Σχημάτων**

Συνδέστε ένα σύνδεσμο με δύο σχήματα αναθέτοντας τους αρχικούς και τελικούς προορισμούς.

```js
function reconnectShapes() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 50, 50);
        let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 50, 50);

        let connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 100, 100);

        connector.setStartShapeConnectedTo(shape1);
        connector.setEndShapeConnectedTo(shape2);
    } finally {
        presentation.dispose();
    }
}
```