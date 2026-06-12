---
title: API pubbliche e modifiche incompatibili con versioni precedenti in Aspose.Slides per .NET 15.11.0
linktitle: Aspose.Slides per .NET 15.11.0
type: docs
weight: 210
url: /it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
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
description: "Rivedi gli aggiornamenti dell'API pubblica e le modifiche breaking in Aspose.Slides per .NET per migrare senza problemi le soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 
Questa pagina elenca tutte le classi, i metodi, le proprietà aggiunti o rimossi e così via, e le altre modifiche introdotte con l'API di Aspose.Slides per .NET 15.11.0.
{{% /alert %}} 
## **Modifiche all'API pubblica**

#### **Le proprietà obsolete nella classe DataLabelCollection sono state eliminate**
Le proprietà obsolete nella classe DataLabelCollection sono state eliminate:
Aspose.Slides.Charts.DataLabelCollection.Delete
Aspose.Slides.Charts.DataLabelCollection.Format
Aspose.Slides.Charts.DataLabelCollection.LinkedSource
Aspose.Slides.Charts.DataLabelCollection.NumberFormat
Aspose.Slides.Charts.DataLabelCollection.Position
Aspose.Slides.Charts.DataLabelCollection.Separator
Aspose.Slides.Charts.DataLabelCollection.ShowBubbleSize
Aspose.Slides.Charts.DataLabelCollection.ShowCategoryName
Aspose.Slides.Charts.DataLabelCollection.ShowLeaderLines
Aspose.Slides.Charts.DataLabelCollection.ShowLegendKey
Aspose.Slides.Charts.DataLabelCollection.ShowPercentage
Aspose.Slides.Charts.DataLabelCollection.ShowSeriesName
Aspose.Slides.Charts.DataLabelCollection.ShowValue

#### **È stata aggiunta la nuova proprietà FirstSlideNumber alla classe Presentation**
La nuova proprietà FirstSlideNumber aggiunta a Presentation consente di ottenere o impostare il numero della prima diapositiva in una presentazione.

Quando viene specificato un nuovo valore per FirstSlideNumber, tutti i numeri delle diapositive vengono ricalcolati.

``` csharp

 using(var pres = new Presenation(path))

{

  int firstSlideNumber = pres.FirstSlideNumber;

  pres.FirstSlideNumber = 10;

  pres.Save(newPath, SaveFormat.Pptx);

}

```