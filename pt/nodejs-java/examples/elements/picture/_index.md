---
title: Imagem
type: docs
weight: 50
url: /pt/nodejs-java/examples/elements/picture/
keywords:
- exemplo de código
- imagem
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Trabalhe com imagens no Aspose.Slides for Node.js: insira, recorte, comprima, recolorize e exporte imagens com exemplos para apresentações PPT, PPTX e ODP."
---
Este artigo demonstra como inserir e acessar imagens usando **Aspose.Slides for Node.js via Java**. Os exemplos abaixo leem uma imagem de um arquivo, colocam‑na em um slide e depois a recuperam.

## **Add a Picture**
Este código lê uma imagem de um arquivo e a insere como um quadro de imagem no primeiro slide.

```js
function addPicture() {
    const FileInputStream = java.import("java.io.FileInputStream");

    let presentation = new aspose.slides.Presentation();

    try {
        let slide = presentation.getSlides().get_Item(0);

        let imageStream = new FileInputStream("image.jpg");
        let image = presentation.getImages().addImage(imageStream);

        // Insira um quadro de imagem que mostra a imagem no primeiro slide.
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 50, 50, image.getWidth(), image.getHeight(), image);

        presentation.save("picture.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Access a Picture**
Este exemplo garante que um slide contenha um quadro de imagem e então acessa o primeiro que encontrar.

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