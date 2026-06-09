---
title: Αντικείμενο OLE
type: docs
weight: 210
url: /el/androidjava/examples/elements/ole-object/
keywords:
- παράδειγμα κώδικα
- αντικείμενο OLE
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Διαχειριστείτε τα αντικείμενα OLE στο Aspose.Slides για Android: εισαγωγή, σύνδεση, ενημέρωση και εξαγωγή ενσωματωμένου περιεχομένου με Java σε παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει την ενσωμάτωση ενός αρχείου ως αντικείμενο OLE και την ενημέρωση των δεδομένων του χρησιμοποιώντας **Aspose.Slides for Android via Java**.

## **Προσθήκη αντικειμένου OLE**

Ενσωματώστε ένα αρχείο PDF στην παρουσίαση.

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

## **Πρόσβαση σε αντικείμενο OLE**

Ανακτήστε το πρώτο πλαίσιο αντικειμένου OLE σε μια διαφάνεια.

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

## **Αφαίρεση αντικειμένου OLE**

Διαγράψτε ένα ενσωματωμένο αντικείμενο OLE από τη διαφάνεια.

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

## **Ενημέρωση δεδομένων αντικειμένου OLE**

Αντικαταστήστε τα δεδομένα που είναι ενσωματωμένα σε ένα υπάρχον αντικείμενο OLE.

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


### **Μέθοδος readAllBytes**

```java
public static byte[] readAllBytes(String file) throws IOException {
    FileInputStream fis = new FileInputStream(new File(file));
    byte[] data = new byte[(int) file.length()];
    fis.read(data);
    fis.close();
    return data;
}
```