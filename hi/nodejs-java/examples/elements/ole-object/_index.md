---
title: OLE ऑब्जेक्ट
type: docs
weight: 210
url: /hi/nodejs-java/examples/elements/ole-object/
keywords:
- कोड उदाहरण
- OLE ऑब्जेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js में OLE ऑब्जेक्ट को संभालें: PPT, PPTX और ODP प्रस्तुतियों में JavaScript के साथ एम्बेडेड सामग्री को जोड़ें, लिंक करें, अपडेट करें और निकालें।"
---
यह लेख फ़ाइल को OLE ऑब्जेक्ट के रूप में एम्बेड करने और **Aspose.Slides for Node.js via Java** का उपयोग करके उसके डेटा को अपडेट करने का प्रदर्शन करता है।

## **OLE ऑब्जेक्ट जोड़ें**

एक प्रस्तुति में PDF फ़ाइल को एम्बेड करें।

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

## **OLE ऑब्जेक्ट तक पहुँचें**

स्लाइड पर पहला OLE ऑब्जेक्ट फ्रेम प्राप्त करें।

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

## **OLE ऑब्जेक्ट हटाएँ**

स्लाइड से एम्बेड किया गया OLE ऑब्जेक्ट हटाएँ।

```js
function removeOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // मान लेते हैं कि पहली आकृति OLE ऑब्जेक्ट फ्रेम है।
        let oleFrame = slide.getShapes().get_Item(0);
        
        slide.getShapes().remove(oleFrame);

        presentation.save("ole_object_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **OLE ऑब्जेक्ट डेटा अपडेट करें**

मौजूद OLE ऑब्जेक्ट में एम्बेड किए गए डेटा को बदलें।

```js
function updateOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // मान लेते हैं कि पहली आकृति OLE ऑब्जेक्ट फ्रेम है।
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