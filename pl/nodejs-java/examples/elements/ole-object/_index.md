---
title: Obiekt OLE
type: docs
weight: 210
url: /pl/nodejs-java/examples/elements/ole-object/
keywords:
- przykład kodu
- obiekt OLE
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Obsługuj obiekty OLE w Aspose.Slides for Node.js: wstawiaj, linkuj, aktualizuj i wyodrębniaj osadzoną treść przy użyciu JavaScript w prezentacjach PPT, PPTX i ODP."
---
Ten artykuł pokazuje, jak osadzić plik jako obiekt OLE i zaktualizować jego dane przy użyciu **Aspose.Slides for Node.js via Java**.

## **Dodaj obiekt OLE**

Osadź plik PDF w prezentacji.

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

## **Uzyskaj dostęp do obiektu OLE**

Pobierz pierwszą ramkę obiektu OLE na slajdzie.

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

## **Usuń obiekt OLE**

Usuń osadzony obiekt OLE ze slajdu.

```js
function removeOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Zakładając, że pierwszym kształtem jest ramka obiektu OLE.
        let oleFrame = slide.getShapes().get_Item(0);
        
        slide.getShapes().remove(oleFrame);

        presentation.save("ole_object_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Aktualizuj dane obiektu OLE**

Zastąp dane osadzone w istniejącym obiekcie OLE.

```js
function updateOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Zakładając, że pierwszym kształtem jest ramka obiektu OLE.
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