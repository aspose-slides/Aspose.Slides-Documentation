---
title: Εικόνα
type: docs
weight: 50
url: /el/nodejs-java/examples/elements/picture/
keywords:
- παράδειγμα κώδικα
- εικόνα
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Εργαστείτε με εικόνες στο Aspose.Slides για Node.js: εισαγωγή, περικοπή, συμπίεση, αλλαγή χρώματος και εξαγωγή εικόνων με παραδείγματα για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να εισάγετε και να προσπελάσετε εικόνες χρησιμοποιώντας **Aspose.Slides for Node.js via Java**. Τα παρακάτω παραδείγματα διαβάζουν μια εικόνα από αρχείο, την τοποθετούν σε μια διαφάνεια και στη συνέχεια την ανακτούν.

## **Προσθήκη εικόνας**

Αυτός ο κώδικας διαβάζει μια εικόνα από αρχείο και την εισάγει ως πλαίσιο εικόνας στην πρώτη διαφάνεια.

```js
function addPicture() {
    const FileInputStream = java.import("java.io.FileInputStream");

    let presentation = new aspose.slides.Presentation();

    try {
        let slide = presentation.getSlides().get_Item(0);

        let imageStream = new FileInputStream("image.jpg");
        let image = presentation.getImages().addImage(imageStream);

        // Εισαγωγή πλαισίου εικόνας που εμφανίζει την εικόνα στην πρώτη διαφάνεια.
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 50, 50, image.getWidth(), image.getHeight(), image);

        presentation.save("picture.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε εικόνα**

Αυτό το παράδειγμα εξασφαλίζει ότι μια διαφάνεια περιέχει πλαίσιο εικόνας και στη συνέχεια προσπελαύνει το πρώτο που εντοπίζει.

```js
function accessPicture() {
    let presentation = new aspose.slides.Presentation("picture.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let pictureFrame = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                pictureFrame = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```