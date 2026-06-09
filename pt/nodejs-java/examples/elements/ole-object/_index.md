---
title: Objeto OLE
type: docs
weight: 210
url: /pt/nodejs-java/examples/elements/ole-object/
keywords:
- exemplo de código
- objeto OLE
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Manipule objetos OLE no Aspose.Slides para Node.js: insira, vincule, atualize e extraia conteúdo incorporado com JavaScript em apresentações PPT, PPTX e ODP."
---
Este artigo demonstra como incorporar um arquivo como um objeto OLE e atualizar seus dados usando **Aspose.Slides for Node.js via Java**.

## **Adicionar um Objeto OLE**

Incorpore um arquivo PDF em uma apresentação.

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

## **Acessar um Objeto OLE**

Recupere o primeiro quadro de objeto OLE em um slide.

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

## **Remover um Objeto OLE**

Exclua um objeto OLE incorporado do slide.

```js
function removeOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Assumindo que a primeira forma é o quadro de objeto OLE.
        let oleFrame = slide.getShapes().get_Item(0);
        
        slide.getShapes().remove(oleFrame);

        presentation.save("ole_object_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Atualizar Dados do Objeto OLE**

Substitua os dados incorporados em um objeto OLE existente.

```js
function updateOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Assumindo que a primeira forma é o quadro de objeto OLE.
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