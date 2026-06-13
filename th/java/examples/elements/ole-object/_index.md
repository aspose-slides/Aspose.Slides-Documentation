---
title: อ็อบเจ็กต์ OLE
type: docs
weight: 210
url: /th/java/examples/elements/ole-object/
keywords:
- ตัวอย่างโค้ด
- อ็อบเจ็กต์ OLE
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "จัดการอ็อบเจ็กต์ OLE ใน Aspose.Slides for Java: แทรก, เชื่อมโยง, อัปเดต, และดึงเนื้อหาที่ฝังไว้ด้วย Java ในงานนำเสนอ PPT, PPTX, และ ODP"
---
บทความนี้แสดงวิธีการฝังไฟล์เป็นอ็อบเจ็กต์ OLE และอัปเดตข้อมูลของมันโดยใช้ **Aspose.Slides for Java**.

## **เพิ่มอ็อบเจ็กต์ OLE**

ฝังไฟล์ PDF ลงในงานนำเสนอ.

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

## **เข้าถึงอ็อบเจ็กต์ OLE**

ดึงเฟรมอ็อบเจ็กต์ OLE ตัวแรกบนสไลด์.

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

## **ลบอ็อบเจ็กต์ OLE**

ลบอ็อบเจ็กต์ OLE ที่ฝังอยู่จากสไลด์.

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

## **อัปเดตข้อมูลอ็อบเจ็กต์ OLE**

แทนที่ข้อมูลที่ฝังอยู่ในอ็อบเจ็กต์ OLE ที่มีอยู่.

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