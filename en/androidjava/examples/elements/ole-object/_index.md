---
title: OLE Object
type: docs
weight: 210
url: /androidjava/examples/elements/ole-object/
keywords:
- code example
- OLE object
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Handle OLE objects in Aspose.Slides for Android: insert, link, update, and extract embedded content with Java in PPT, PPTX, and ODP presentations."
---

This article demonstrates embedding a file as an OLE object and updating its data using **Aspose.Slides for Android via Java**.

## **Add an OLE Object**

Embed a PDF file into the presentation.

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

## **Access an OLE Object**

Retrieve the first OLE object frame on a slide.

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

## **Remove an OLE Object**

Delete an embedded OLE object from the slide.

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

## **Update OLE Object Data**

Replace the data embedded in an existing OLE object.

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


### **Method readAllBytes**

```java
public static byte[] readAllBytes(String file) throws IOException {
    FileInputStream fis = new FileInputStream(new File(file));
    byte[] data = new byte[(int) file.length()];
    fis.read(data);
    fis.close();
    return data;
}
```