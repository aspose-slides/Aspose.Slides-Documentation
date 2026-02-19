---
title: OLE-Objekt
type: docs
weight: 210
url: /de/java/examples/elements/ole-object/
keywords:
- Codebeispiel
- OLE-Objekt
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Verwalten Sie OLE-Objekte in Aspose.Slides für Java: Einfügen, Verlinken, Aktualisieren und Extrahieren eingebetteter Inhalte mit Java in PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel zeigt, wie man eine Datei als OLE-Objekt einbettet und deren Daten mit **Aspose.Slides for Java** aktualisiert.

## **OLE-Objekt hinzufügen**

Betten Sie eine PDF-Datei in die Präsentation ein.

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

## **Auf ein OLE-Objekt zugreifen**

Rufen Sie den ersten OLE-Objekt-Frame auf einer Folie ab.

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

## **Ein OLE-Objekt entfernen**

Löschen Sie ein eingebettetes OLE-Objekt von der Folie.

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

## **OLE-Objektdaten aktualisieren**

Ersetzen Sie die in einem vorhandenen OLE-Objekt eingebetteten Daten.

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