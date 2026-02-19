---
title: Image
type: docs
weight: 50
url: /fr/nodejs-java/examples/elements/picture/
keywords:
- exemple de code
- image
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Travaillez avec les images dans Aspose.Slides pour Node.js : insérez, recadrez, compressez, recolorez et exportez les images avec des exemples pour les présentations PPT, PPTX et ODP."
---
Cet article montre comment insérer et accéder aux images en utilisant **Aspose.Slides for Node.js via Java**. Les exemples ci-dessous lisent une image depuis un fichier, la placent sur une diapositive, puis la récupèrent.

## **Ajouter une image**
Ce code lit une image depuis un fichier et l'insère sous forme de cadre image sur la première diapositive.

```js
function addPicture() {
    const FileInputStream = java.import("java.io.FileInputStream");

    let presentation = new aspose.slides.Presentation();

    try {
        let slide = presentation.getSlides().get_Item(0);

        let imageStream = new FileInputStream("image.jpg");
        let image = presentation.getImages().addImage(imageStream);

        // Insérer un cadre image affichant l'image sur la première diapositive.
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 50, 50, image.getWidth(), image.getHeight(), image);

        presentation.save("picture.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Accéder à une image**
Cet exemple vérifie qu'une diapositive contient un cadre image, puis accède au premier trouvé.

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