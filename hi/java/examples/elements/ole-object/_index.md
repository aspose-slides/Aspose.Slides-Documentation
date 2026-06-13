---
title: OLE ऑब्जेक्ट
type: docs
weight: 210
url: /hi/java/examples/elements/ole-object/
keywords:
- कोड उदाहरण
- OLE ऑब्जेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में OLE ऑब्जेक्ट को संभालें: PPT, PPTX, और ODP प्रेजेंटेशन में एंबेडेड कंटेंट को सम्मिलित करें, लिंक करें, अपडेट करें, और निकालें।"
---
यह लेख एक फ़ाइल को OLE ऑब्जेक्ट के रूप में एंबेड करने और **Aspose.Slides for Java** का उपयोग करके उसके डेटा को अपडेट करने का प्रदर्शन करता है।

## **OLE ऑब्जेक्ट जोड़ें**

प्रेजेंटेशन में एक PDF फ़ाइल एंबेड करें।

```java
static void addOleObject() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        byte[] pdfData = Files.readAllBytes(Paths.get("doc.pdf"));
        IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
        IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, dataInfo);
    } finally {
        presentation.dispose();
    }
}
```

## **OLE ऑब्जेक्ट तक पहुँचें**

स्लाइड पर पहला OLE ऑब्जेक्ट फ्रेम प्राप्त करें।

```java
static void accessOleObject() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        byte[] pdfData = Files.readAllBytes(Paths.get("doc.pdf"));
        IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
        IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, dataInfo);

        IOleObjectFrame firstOleFrame = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IOleObjectFrame) {
                firstOleFrame = (IOleObjectFrame) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **OLE ऑब्जेक्ट हटाएँ**

स्लाइड से एंबेडेड OLE ऑब्जेक्ट को हटाएँ।

```java
static void removeOleObject() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        byte[] pdfData = Files.readAllBytes(Paths.get("doc.pdf"));
        IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
        IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, dataInfo);
        
        slide.getShapes().remove(oleFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **OLE ऑब्जेक्ट डेटा अपडेट करें**

मौजूदा OLE ऑब्जेक्ट में एंबेडेड डेटा को बदलें।

```java
static void updateOleObjectData() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        byte[] pdfData = Files.readAllBytes(Paths.get("doc.pdf"));
        OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
        IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, dataInfo);

        byte[] newData = Files.readAllBytes(Paths.get("Picture.png"));
        OleEmbeddedDataInfo newDataInfo = new OleEmbeddedDataInfo(newData, "png");
        oleFrame.setEmbeddedData(newDataInfo);
    } finally {
        presentation.dispose();
    }
}
```