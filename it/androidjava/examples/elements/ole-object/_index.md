---
title: Oggetto OLE
type: docs
weight: 210
url: /it/androidjava/examples/elements/ole-object/
keywords:
- esempio di codice
- oggetto OLE
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Gestisci gli oggetti OLE in Aspose.Slides per Android: inserisci, collega, aggiorna ed estrai contenuti incorporati con Java in presentazioni PPT, PPTX e ODP."
---
Questo articolo mostra come incorporare un file come oggetto OLE e aggiornare i suoi dati utilizzando **Aspose.Slides for Android via Java**.

## **Aggiungere un oggetto OLE**

Incorpora un file PDF nella presentazione.

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

## **Accedere a un oggetto OLE**

Recupera il primo frame dell'oggetto OLE in una diapositiva.

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

## **Rimuovere un oggetto OLE**

Elimina un oggetto OLE incorporato dalla diapositiva.

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

## **Aggiornare i dati dell'oggetto OLE**

Sostituisci i dati incorporati in un oggetto OLE esistente.

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


### **Metodo readAllBytes**

```java
public static byte[] readAllBytes(String file) throws IOException {
    FileInputStream fis = new FileInputStream(new File(file));
    byte[] data = new byte[(int) file.length()];
    fis.read(data);
    fis.close();
    return data;
}
```