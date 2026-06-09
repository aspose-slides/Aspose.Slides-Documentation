---
title: Αντικείμενο OLE
type: docs
weight: 210
url: /el/nodejs-java/examples/elements/ole-object/
keywords:
- παράδειγμα κώδικα
- αντικείμενο OLE
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαχείριση αντικειμένων OLE στο Aspose.Slides for Node.js: εισαγωγή, σύνδεσμος, ενημέρωση και εξαγωγή ενσωματωμένου περιεχομένου με JavaScript σε παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να ενσωματώσετε ένα αρχείο ως αντικείμενο OLE και να ενημερώσετε τα δεδομένα του χρησιμοποιώντας **Aspose.Slides for Node.js via Java**.

## **Προσθήκη αντικειμένου OLE**

Ενσωματώστε ένα αρχείο PDF σε μια παρουσίαση.

```js
function addOleObject() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let pdfStream = fs.readFileSync("doc.pdf");
        let pdfData = java.newArray("byte", Array.from(pdfStream));
        let dataInfo = new aspose.slides.OleEmbeddedDataInfo(pdfData, "pdf");
        let oleFrame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, dataInfo);

        presentation.save("ole_object.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε αντικείμενο OLE**

Ανακτήστε το πρώτο πλαίσιο αντικειμένου OLE σε μια διαφάνεια.

```js
function accessOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstOleFrame = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IOleObjectFrame")) {
                firstOleFrame = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση αντικειμένου OLE**

Διαγράψτε ένα ενσωματωμένο αντικείμενο OLE από τη διαφάνεια.

```js
function removeOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Υποθέτουμε ότι το πρώτο σχήμα είναι το πλαίσιο αντικειμένου OLE.
        let oleFrame = slide.getShapes().get_Item(0);
        
        slide.getShapes().remove(oleFrame);

        presentation.save("ole_object_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Ενημέρωση δεδομένων αντικειμένου OLE**

Αντικαταστήστε τα δεδομένα που έχουν ενσωματωθεί σε ένα υπάρχον αντικείμενο OLE.

```js
function updateOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Υποθέτοντας ότι το πρώτο σχήμα είναι το πλαίσιο αντικειμένου OLE.
        let oleFrame = slide.getShapes().get_Item(0);

        let dataStream = fs.readFileSync("picture.png");
        let newData = java.newArray("byte", Array.from(dataStream));
        let dataInfo = new aspose.slides.OleEmbeddedDataInfo(newData, "png");
        oleFrame.setEmbeddedData(dataInfo);

        presentation.save("ole_object_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```