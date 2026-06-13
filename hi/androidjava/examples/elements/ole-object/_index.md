---
title: OLE ऑब्जेक्ट
type: docs
weight: 210
url: /hi/androidjava/examples/elements/ole-object/
keywords:
- कोड उदाहरण
- OLE ऑब्जेक्ट
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में OLE ऑब्जेक्ट को संभालें: PPT, PPTX और ODP प्रेजेंटेशन में Java के साथ एम्बेडेड कंटेंट को डालें, लिंक करें, अपडेट करें और निकालें।"
---
यह लेख **Aspose.Slides for Android via Java** का उपयोग करके फ़ाइल को OLE ऑब्जेक्ट के रूप में एम्बेड करने और उसके डेटा को अपडेट करने का प्रदर्शन करता है।

## **OLE ऑब्जेक्ट जोड़ें**

प्रेज़ेंटेशन में एक PDF फ़ाइल एम्बेड करें।

```java
static void addOleObject() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        byte[] pdfData = readAllBytes("doc.pdf");
        IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
        IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, dataInfo);
    } finally {
        presentation.dispose();
    }
}
```

## **OLE ऑब्जेक्ट एक्सेस करें**

एक स्लाइड पर पहला OLE ऑब्जेक्ट फ़्रेम प्राप्त करें।

```java
static void accessOleObject() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        byte[] pdfData = readAllBytes("doc.pdf");
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

स्लाइड से एम्बेडेड OLE ऑब्जेक्ट को हटाएँ।

```java
static void removeOleObject() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        byte[] pdfData = readAllBytes("doc.pdf");
        IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
        IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, dataInfo);
        
        slide.getShapes().remove(oleFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **OLE ऑब्जेक्ट डेटा अपडेट करें**

मौजूदा OLE ऑब्जेक्ट में एम्बेड किए गए डेटा को प्रतिस्थापित करें।

```java
static void updateOleObjectData() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        byte[] pdfData = readAllBytes("doc.pdf");
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

### **विधि readAllBytes**

```java
public static byte[] readAllBytes(String file) throws IOException {
    FileInputStream fis = new FileInputStream(new File(file));
    byte[] data = new byte[(int) file.length()];
    fis.read(data);
    fis.close();
    return data;
}
```