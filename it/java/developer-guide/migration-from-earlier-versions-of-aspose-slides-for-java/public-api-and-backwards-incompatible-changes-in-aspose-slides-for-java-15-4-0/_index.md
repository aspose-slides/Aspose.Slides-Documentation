---
title: API pubbliche e modifiche incompatibili con le versioni precedenti in Aspose.Slides per Java 15.4.0
linktitle: Aspose.Slides per Java 15.4.0
type: docs
weight: 120
url: /it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
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
description: "Esamina gli aggiornamenti dell'API pubblica e le modifiche incompatibili in Aspose.Slides per Java per migrare senza problemi le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Questa pagina elenca tutte le classi, i metodi, le proprietà [aggiunte](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) e così via, eventuali nuove restrizioni e altre [modifiche](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) introdotte con l'API Aspose.Slides per Java 15.4.0.

{{% /alert %}} 
## **Modifiche API Pubbliche**
### **Enum OrganizationChartLayoutType è stato aggiunto**
L'enumerazione com.aspose.slides.OrganizationChartLayoutType rappresenta il tipo di formattazione dei nodi figlio in un organigramma.
### **Metodo IBulletFormat.applyDefaultParagraphIndentsShifts() è stato aggiunto**
Il metodo com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts imposta gli spostamenti predefiniti non zero per l'indentazione del paragrafo e il margine sinistro quando i punti elenco sono abilitati (come fa PowerPoint se si attivano i punti/numero del paragrafo). Se i punti elenco sono disabilitati, il metodo ripristina semplicemente l'indentazione del paragrafo e il margine sinistro (come fa PowerPoint se si disattivano i punti/numero del paragrafo).
### **Metodo IConnector.reroute() è stato aggiunto**
Il metodo com.aspose.slides.IConnector.reroute() riorganizza il connettore in modo che segua il percorso più breve possibile tra le forme che collega. Per farlo, il metodo reroute() può modificare gli indici StartShapeConnectionSiteIndex e EndShapeConnectionSiteIndex.

``` java

 Presentation input = new Presentation();

IShapeCollection shapes = input.getSlides().get_Item(0).getShapes();

IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

connector.setStartShapeConnectedTo(ellipse);

connector.setEndShapeConnectedTo(rectangle);

connector.reroute();

input.save("output.pptx", SaveFormat.Pptx);

```
### **Metodo IPresentation.getSlideById(long) è stato aggiunto**
Il metodo Aspose.Slides.IPresentation.getSlideById(int) restituisce una Slide, una MasterSlide o una LayoutSlide in base all'ID della diapositiva.

``` java

 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Metodo ISmartArt.getNodes() è stato aggiunto**
Il metodo com.aspose.slides.ISmartArt.getNodes() restituisce una raccolta di nodi radice nell'oggetto SmartArt.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // seleziona il secondo nodo radice

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Metodo ISmartArt.setLayout(int) è stato aggiunto**
È stato aggiunto il metodo per la proprietà com.aspose.slides.ISmartArt.setLayout(int). Consente di modificare il tipo di layout di un diagramma esistente.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Metodo ISmartArtNode.isHidden() è stato aggiunto**
Il metodo com.aspose.slides.ISmartArtNode.isHidden() restituisce true se questo nodo è nascosto nel modello dati.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //restituisce true

if(hidden) {

    //esegui alcune azioni o notifiche

}

pres.Save("out.pptx", SaveFormat.Pptx);

```
### **Metodi ISmartArt.isReversed(), setReserved() sono stati aggiunti**
La proprietà com.aspose.slides.ISmartArt.IsReversed consente di ottenere o impostare lo stato del diagramma SmartArt rispetto a (da sinistra a destra) LTR o (da destra a sinistra) RTL, se il diagramma supporta l'inversione.

``` java

 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Metodi ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) sono stati aggiunti**
I metodi com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() e setOrganizationChartLayout(int) consentono di ottenere o impostare il tipo di organigramma associato al nodo corrente.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Proprietà IShape.getConnectionSiteCount() è stata aggiunta**
La proprietà com.aspose.slides.getConnectionSiteCount() restituisce il numero di punti di connessione sulla forma.

``` java

 Presentation input = new Presentation();

IShapeCollection shapes = input.getSlides().get_Item(0).getShapes();

IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

connector.setStartShapeConnectedTo(ellipse);

connector.setEndShapeConnectedTo(rectangle);

long wantedIndex = 6;

if (ellipse.getConnectionSiteCount() > wantedIndex) {

  connector.setStartShapeConnectionSiteIndex(wantedIndex);

}

input.save("output.pptx", SaveFormat.Pptx);

```
### **Modifiche Minori**
Questa è l'elenco delle modifiche minori dell'API:

|Enum com.aspose.slides.BevelColorMode|eliminata, enum non utilizzata|
|:-|:-|
|Method ThreeDFormatEffectiveData.getBevelColorMode()|eliminata, proprietà non utilizzata|
|Method com.aspose.slides.ChartSeriesGroup.getChart()|aggiunta|
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent|eliminata|
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle()|eliminate come obsolete|