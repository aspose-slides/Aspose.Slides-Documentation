---
title: API pubblica e modifiche incompatibili retroattive in Aspose.Slides per Java 14.9.0
linktitle: Aspose.Slides per Java 14.9.0
type: docs
weight: 80
url: /it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- migrazione
- codice legacy
- codice moderno
- approccio legacy
- approccio moderno
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Rivedi gli aggiornamenti dell'API pubblica e le modifiche incompatibili in Aspose.Slides per Java per migrare senza problemi le soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Questa pagina elenca tutte le [aggiunte](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) classi, metodi, proprietà e così via, eventuali nuove restrizioni e altre [modifiche](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) introdotte con l'API Aspose.Slides for Java 14.9.0.

{{% /alert %}} 
## **Modifiche all'API pubblica**
### **Metodi aggiunti per la sostituzione dell'immagine in PPImage, IPPImage**
Nuovi metodi aggiunti:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation.pptx");
try {
    // Il primo modo
    byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
    presentation.getImages().get_Item(0).replaceImage(imageData);

    // Il secondo modo
    presentation.getImages().get_Item(1).replaceImage(presentation.getImages().get_Item(0));

    presentation.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Metodi aggiunti per salvare le diapositive mantenendo i numeri di pagina**
I seguenti metodi sono stati aggiunti:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Questi metodi consentono di salvare le diapositive specificate della presentazione in formati PDF, XPS, TIFF, HTML. L'array 'slides' permette di specificare i numeri di pagina, a partire da 1.

``` java
// Sovraccarichi aggiunti a IPresentation (i valori di SaveFormat sono costanti intere in Java):
//
// void save(String fname, int[] slides, int format);
// void save(String fname, int[] slides, int format, ISaveOptions options);
// void save(OutputStream stream, int[] slides, int format);
// void save(OutputStream stream, int[] slides, int format, ISaveOptions options);
```




``` java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int[] slides = new int[] { 2, 3, 5 }; // Array di posizioni delle diapositive

    presentation.save("presentation_out.pdf", slides, SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Aggiunto il valore enum SmartArtLayoutType.Custom**
Questo tipo di layout SmartArt rappresenta un diagramma con modello personalizzato. I diagrammi personalizzati possono essere caricati solo da un file di presentazione e non possono essere creati tramite il metodo ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)

### **Aggiunta la classe SmartArtShape e l'interfaccia ISmartArtShape**
Le classi Aspose.Slides.SmartArt.SmartArtShape (e la sua interfaccia Aspose.Slides.SmartArt.ISmartArtShape) forniscono l'accesso alle singole forme all'interno di un diagramma SmartArt. SmartArtShape può essere utilizzata per modificare FillFormat, LineFormat, aggiungere collegamenti ipertestuali, ecc.

{{% alert color="info" %}} 

SmartArtShape non supporta le proprietà IShape RawFrame, Frame, Rotation, X, Y, Width, Height e lancia System.NotSupportedException quando si tenta di accedervi.

{{% /alert %}} 

Example of usage:

``` java
import com.aspose.slides.*;
import java.awt.Color;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Aggiunta la classe SmartArtShapeCollection, l'interfaccia ISmartArtShapeCollection e il metodo ISmartArtNode.getShapes()**
Le classi Aspose.Slides.SmartArt.SmartArtShapeCollection (e la sua interfaccia Aspose.Slides.SmartArt.ISmartArtShapeCollection) forniscono l'accesso alle singole forme all'interno di un diagramma SmartArt. La collezione contiene le forme associate a SmartArtNode. La proprietà SmartArtNode.Shapes restituisce le collezioni di tutte le forme associate al nodo.

{{% alert color="info" %}} 

A seconda del tipo SmartArtLayoutType, una SmartArtShape può essere condivisa tra più nodi.

{{% /alert %}} 

 

``` java
import com.aspose.slides.*;
import java.awt.Color;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```