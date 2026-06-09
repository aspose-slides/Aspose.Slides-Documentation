---
title: OLE Nesnesi
type: docs
weight: 210
url: /tr/nodejs-java/examples/elements/ole-object/
keywords:
- kod örneği
- OLE nesnesi
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js'te OLE nesnelerini yönetin: PPT, PPTX ve ODP sunumlarında JavaScript ile gömülü içeriği ekleyin, bağlayın, güncelleyin ve çıkarın."
---
Bu makale, bir dosyanın OLE nesnesi olarak gömülmesini ve **Aspose.Slides for Node.js via Java** kullanarak verilerinin güncellenmesini gösterir.

## **OLE Nesnesi Ekle**

Bir PDF dosyasını sunuma gömün.

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

## **OLE Nesnesine Erişim**

Bir slayttaki ilk OLE nesnesi çerçevesini alın.

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

## **OLE Nesnesini Kaldır**

Gömülü OLE nesnesini slayttan silin.

```js
function removeOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // İlk şeklin OLE nesne çerçevesi olduğunu varsayarak.
        let oleFrame = slide.getShapes().get_Item(0);
        
        slide.getShapes().remove(oleFrame);

        presentation.save("ole_object_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **OLE Nesne Verilerini Güncelle**

Mevcut OLE nesnesine gömülmüş verileri değiştirin.

```js
function updateOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // İlk şeklin OLE nesne çerçevesi olduğunu varsayarak.
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