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
description: "Rivedi gli aggiornamenti dell'API pubblica e le modifiche incompatibili in Aspose.Slides per Java per migrare senza problemi le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 
Questa pagina elenca tutte le classi, i metodi, le proprietà e così via, eventuali nuove restrizioni e altri [modifiche](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) introdotti con l'API Aspose.Slides per Java 14.9.0.
{{% /alert %}} 
## **Modifiche all'API pubblica**
### **Metodi aggiunti per la sostituzione dell'immagine in PPImage, IPPImage**
Nuovi metodi aggiunti:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java

 Presentation presentation = new Presentation("presentation.pptx");

//Il primo modo

byte[] imageData = // ...

presentation.getImages().get_Item(0).replaceImage(imageData);

//Il secondo modo

presentation.getImages().get_Item(1).replaceImage(

    presentation.getImages().get_Item(0));

presentation.save("presentation_out.pptx", SaveFormat.Pptx);

```
### **Metodi aggiunti per salvare diapositive mantenendo i numeri di pagina**
I seguenti metodi sono stati aggiunti:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Questi metodi consentono di salvare le diapositive specificate della presentazione in formati PDF, XPS, TIFF, HTML. L'array 'slides' permette di specificare i numeri di pagina, a partire da 1.

``` java

 save(string fname, int\[\] slides, SaveFormat format);

```




``` java

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Array delle posizioni delle diapositive

presentation.save(outFileName, slides, SaveFormat.Pdf);

```
### **Aggiunto il valore Enum SmartArtLayoutType.Custom**
Questo tipo di layout SmartArt rappresenta un diagramma con modello personalizzato. I diagrammi personalizzati possono essere caricati solo da file di presentazione e non possono essere creati tramite il metodo ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)
### **Aggiunta la classe SmartArtShape e l'interfaccia ISmartArtShape**
La classe Aspose.Slides.SmartArt.SmartArtShape (e la sua interfaccia Aspose.Slides.SmartArt.ISmartArtShape) forniscono l'accesso alle singole forme all'interno di un diagramma SmartArt. SmartArtShape può essere usata per modificare FillFormat, LineFormat, aggiungere hyperlink, ecc.

{{% alert color="primary" %}} 
SmartArtShape non supporta le proprietà IShape RawFrame, Frame, Rotation, X, Y, Width, Height e genera una System.NotSupportedException quando si tenta di accedervi.
{{% /alert %}} 
Esempio di utilizzo:

``` java

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
### **Aggiunte la classe SmartArtShapeCollection, l'interfaccia ISmartArtShapeCollection e il metodo ISmartArtNode.getShapes()**
La classe Aspose.Slides.SmartArt.SmartArtShapeCollection (e la sua interfaccia Aspose.Slides.SmartArt.ISmartArtShapeCollection) forniscono l'accesso alle singole forme all'interno di un diagramma SmartArt. La collezione contiene le forme associate a SmartArtNode. La proprietà SmartArtNode.Shapes restituisce le collezioni di tutte le forme associate al nodo.

{{% alert color="primary" %}} 
A seconda di SmartArtLayoutType, una SmartArtShape può essere condivisa tra più nodi.
{{% /alert %}} 

``` java

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