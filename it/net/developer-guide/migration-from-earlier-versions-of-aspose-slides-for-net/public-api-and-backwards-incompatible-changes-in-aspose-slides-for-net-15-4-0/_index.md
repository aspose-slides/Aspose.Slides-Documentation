---
title: API pubbliche e modifiche incompatibili retroattive in Aspose.Slides per .NET 15.4.0
linktitle: Aspose.Slides per .NET 15.4.0
type: docs
weight: 150
url: /it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
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
description: "Esamina gli aggiornamenti delle API pubbliche e le modifiche incompatibili in Aspose.Slides per .NET per migrare agevolmente le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Questa pagina elenca tutte le classi, i metodi, le proprietà e così via aggiunti o rimossi, nonché le altre modifiche introdotte con l'API di Aspose.Slides per .NET 15.4.0.

{{% /alert %}} 
## **Modifiche all'API pubblica**
#### **Enum OrganizationChartLayoutType è stato aggiunto**
L'enumerazione Aspose.Slides.SmartArt.OrganizationChartLayoutType rappresenta il tipo di formattazione dei nodi figli in un organigramma.
#### **Metodo IBulletFormat.ApplyDefaultParagraphIndentsShifts è stato aggiunto**
Il metodo Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts imposta gli spostamenti predefiniti non zero per l'indentazione del paragrafo e per MarginLeft quando i punti elenco sono abilitati (come fa PowerPoint se si attivano i punti/numero dei paragrafi). Se i punti elenco sono disabilitati, il metodo resetta semplicemente l'indentazione del paragrafo e MarginLeft (come fa PowerPoint se si disattivano i punti/numero dei paragrafi).

Vedi esempi [qui](/slides/it/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Metodo IConnector.Reroute è stato aggiunto**
Il metodo Aspose.Slides.IConnector.Reroute riorienta il connettore in modo che segua il percorso più corto possibile tra le forme a cui è collegato. Per fare ciò, il metodo Reroute() può modificare gli indici StartShapeConnectionSiteIndex e EndShapeConnectionSiteIndex.

``` csharp

 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  connector.Reroute();

  input.Save("output.pptx", SaveFormat.Pptx);

}

``` 
#### **Metodo IPresentation.GetSlideById è stato aggiunto**
Il metodo Aspose.Slides.IPresentation.GetSlideById(System.UInt32) restituisce una Slide, MasterSlide o LayoutSlide in base all'ID della diapositiva.

``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}
``` 
#### **Proprietà IShape.ConnectionSiteCount è stata aggiunta**
La proprietà Aspose.Slides.IShape.ConnectionSiteCount restituisce il numero di punti di connessione presenti sulla forma.

``` csharp

 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  uint wantedIndex = 6;

  if (ellipse.ConnectionSiteCount > wantedIndex)

  {

    connector.StartShapeConnectionSiteIndex = wantedIndex;

  }

  input.Save("output.pptx", SaveFormat.Pptx);

}

``` 
#### **Proprietà ISmartArt.IsReversed è stata aggiunta**
La proprietà Aspose.Slides.SmartArt.ISmartArt.IsReversed consente di ottenere o impostare lo stato del diagramma SmartArt rispetto a (da sinistra a destra) LTR o (da destra a sinistra) RTL, se il diagramma supporta l'inversione.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Proprietà ISmartArt.Nodes è stata aggiunta**
La proprietà Aspose.Slides.SmartArt.ISmartArt.Nodes restituisce la collezione di nodi radice nell'oggetto SmartArt.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // seleziona il secondo nodo radice

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}
``` 
#### **Proprietà ISmartArtNode.IsHidden è stata aggiunta**
La proprietà Aspose.Slides.SmartArt.ISmartArtNode.IsHidden restituisce true se questo nodo è un nodo nascosto nel modello dati.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //restituisce true

  if(hidden)

  {

    //esegui alcune azioni o notifiche

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}
``` 
#### **Proprietà ISmartArtNode.OrganizationChartLayout è stata aggiunta**
La proprietà Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout consente di ottenere o impostare il tipo di organigramma associato al nodo corrente.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}
``` 
#### **Metodo set per la proprietà ISmartArt.Layout è stato aggiunto**
È stato aggiunto il metodo set per la proprietà Aspose.Slides.SmartArt.ISmartArt.Layout. Consente di modificare il tipo di layout di un diagramma esistente.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}
``` 
#### **Modifiche minori all'API**
**Questa è l'elenco delle modifiche minori all'API:**

|Enum Aspose.Slides.BevelColorMode |eliminata, enum inutilizzata |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |eliminata, proprietà inutilizzata |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |aggiunto |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Ereditarietà di IParagraphFormatEffectiveData da ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Ereditarietà di IThreeDFormat da ISlideComponent |eliminata |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |eliminata come obsoleta |