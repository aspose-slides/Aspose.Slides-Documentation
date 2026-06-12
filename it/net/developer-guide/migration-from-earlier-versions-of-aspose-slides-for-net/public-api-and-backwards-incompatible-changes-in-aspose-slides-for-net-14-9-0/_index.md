---
title: API pubbliche e modifiche incompatibili retroattive in Aspose.Slides per .NET 14.9.0
linktitle: Aspose.Slides per .NET 14.9.0
type: docs
weight: 110
url: /it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- migrazione
- codice legacy
- codice moderno
- approccio legacy
- approccio moderno
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Esamina gli aggiornamenti dell'API pubblica e le modifiche incompatibili in Aspose.Slides per .NET per migrare senza problemi le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Questa pagina elenca tutte le classi, i metodi, le proprietà e così via [aggiunti](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) o [rimossi](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/), e le altre modifiche introdotte con l'API di Aspose.Slides per .NET 14.9.0.

{{% /alert %}} 
## **Modifiche all'API pubblica**
#### **Ereditarietà dalle interfacce ICollection e IEnumerable generiche aggiunta a ISmartArtNodeCollection**
La classe Aspose.Slides.SmartArt.SmartArtNodeCollection (e l'interfaccia correlata Aspose.Slides.SmartArt.ISmartArtNodeCollection) eredita l'interfaccia generica IEnumerable<ISmartArtNode> e l'interfaccia ICollection.
#### **Valore Enum SmartArtLayoutType.Custom aggiunto**
Il tipo di layout SmartArt Custom rappresenta un diagramma con un modello personalizzato. I diagrammi personalizzati possono essere caricati solo da un file di presentazione e non possono essere creati tramite il metodo ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom).
#### **Classe SmartArtShape e interfaccia ISmartArtShape aggiunte**
La classe Aspose.Slides.SmartArt.SmartArtShape (e la sua interfaccia Aspose.Slides.SmartArt.ISmartArtShape) fornisce l'accesso alle singole forme in un diagramma SmartArt. SmartArtShape può essere utilizzata per modificare FillFormat, LineFormat, aggiungere collegamenti ipertestuali e altre operazioni.

{{% alert color="primary" %}} 

**Nota**: SmartArtShape non supporta le proprietà IShape RawFrame, Frame, Rotation, X, Y, Width, Height e genera una System.NotSupportedException quando si tenta di accedervi.

Esempio di utilizzo:

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **Classe SmartArtShapeCollection, interfaccia ISmartArtShapeCollection e proprietà ISmartArtNode.Shapes aggiunte**
La classe Aspose.Slides.SmartArt.SmartArtShapeCollection (e la sua interfaccia Aspose.Slides.SmartArt.ISmartArtShapeCollection) aggiunge l'accesso alle singole forme in un diagramma SmartArt. La collezione contiene le forme associate a SmartArtNode. La proprietà SmartArtNode.Shapes restituisce le collezioni di tutte le forme associate al nodo.

{{% alert color="primary" %}} 

**Nota**: a seconda del SmartArtLayoutType, una SmartArtShape può essere condivisa tra più nodi.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **Metodi per salvare le diapositive mantenendo i numeri di pagina aggiunti**
Sono stati aggiunti i seguenti metodi:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Questi metodi consentono agli sviluppatori di salvare le diapositive specificate di una presentazione in formati PDF, XPS, TIFF, HTML. L'array 'slides' è usato per specificare i numeri di pagina, a partire da 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Array delle posizioni delle diapositive

presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **Metodi per sostituire le immagini aggiunti a PPImage, IPPImage**
Nuovi metodi aggiunti:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);

//Primo metodo

byte[] data = File.ReadAllBytes(image0.jpeg);

IPPImage oldImage = presentation.Images[0];

oldImage.ReplaceImage(data);

//Secondo metodo

Image newImage = Image.FromFile(image1.png);

oldImage = presentation.Images[1];

oldImage.ReplaceImage(newImage);

//Terzo metodo

oldImage = presentation.Images[2];

oldImage.ReplaceImage(presentation.Images[3]);

presentation.Save(presentation_out.pptx, SaveFormat.Pptx);

```