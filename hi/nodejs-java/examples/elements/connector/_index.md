---
title: कनेक्टर
type: docs
weight: 190
url: /hi/nodejs-java/examples/elements/connector/
keywords:
- कोड उदाहरण
- कनेक्टर
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js का उपयोग करके शैप्स के बीच कनेक्टर्स को जोड़ना, मार्ग निर्धारित करना और स्टाइल करना सीखें, PPT, PPTX और ODP प्रस्तुतियों के लिए JavaScript उदाहरणों के साथ।"
---
यह लेख दर्शाता है कि कैसे शेप्स को कनेक्टर्स से जोड़ें और उनके टार्गेट को बदलें, **Aspose.Slides for Node.js via Java** का उपयोग करके।

## **कनेक्टर जोड़ें**

स्लाइड पर दो बिंदुओं के बीच एक कनेक्टर शेप डालें।

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

## **कनेक्टर तक पहुँचें**

स्लाइड में जोड़ा गया पहला कनेक्टर शेप प्राप्त करें।

```js
function accessConnector() {
    let presentation = new aspose.slides.Presentation("connector.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // स्लाइड पर पहला कनेक्टर एक्सेस करें।
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

## **कनेक्टर हटाएँ**

स्लाइड से एक कनेक्टर हटाएँ।

```js
function removeConnector() {
    let presentation = new aspose.slides.Presentation("connector.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // मान लें कि पहला आकार एक कनेक्टर है और इसे हटाएँ।
        slide.getShapes().removeAt(0);

        presentation.save("connector_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **शेप्स को पुनः जोड़ें**

शुरुआती और अंत लक्ष्य निर्धारित करके दो शेप्स को कनेक्टर से जोड़ें।

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