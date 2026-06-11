---
title: OLE-objekt
type: docs
weight: 210
url: /sv/androidjava/examples/elements/ole-object/
keywords:
- kodexempel
- OLE-objekt
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Hantera OLE-objekt i Aspose.Slides för Android: infoga, länka, uppdatera och extrahera inbäddat innehåll med Java i PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln visar hur man bäddar in en fil som ett OLE‑objekt och uppdaterar dess data med **Aspose.Slides for Android via Java**.

## **Lägg till ett OLE‑objekt**

Bädda in en PDF‑fil i presentationen.

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

## **Åtkomst till ett OLE‑objekt**

Hämta den första OLE‑objekt‑ramen på en bild.

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

## **Ta bort ett OLE‑objekt**

Radera ett inbäddat OLE‑objekt från bilden.

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

## **Uppdatera OLE‑objektdata**

Byt ut den data som är inbäddad i ett befintligt OLE‑objekt.

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

### **Metod readAllBytes**

```java
public static byte[] readAllBytes(String file) throws IOException {
    FileInputStream fis = new FileInputStream(new File(file));
    byte[] data = new byte[(int) file.length()];
    fis.read(data);
    fis.close();
    return data;
}
```