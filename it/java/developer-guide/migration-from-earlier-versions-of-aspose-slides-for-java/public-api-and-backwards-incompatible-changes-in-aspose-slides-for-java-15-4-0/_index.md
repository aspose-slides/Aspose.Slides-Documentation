---
title: API Pubblica e Modifiche Incompatibili in Aspose.Slides per Java 15.4.0
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
description: "Esamina gli aggiornamenti dell'API pubblica e le modifiche incompatibili in Aspose.Slides per Java per migrare agevolmente le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 
Questa pagina elenca tutte le classi, i metodi, le proprietà e così via, eventuali nuove restrizioni e altre [modifiche](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) introdotte con l'API Aspose.Slides for Java 15.4.0.
{{% /alert %}} 
## **Modifiche all'API pubblica**
### **Enum OrganizationChartLayoutType è stato aggiunto**
L'enum com.aspose.slides.OrganizationChartLayoutType rappresenta il tipo di formattazione dei nodi figlio in un organigramma.
### **Metodo IBulletFormat.applyDefaultParagraphIndentsShifts() è stato aggiunto**
Il metodo com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts imposta spostamenti predefiniti non zero per l'Indent del paragrafo e per MarginLeft quando i punti elenco sono abilitati (come fa PowerPoint se si attivano i punti/elenco numerato). Se i punti elenco sono disabilitati, il metodo ripristina semplicemente Indent e MarginLeft (come fa PowerPoint se li disattiva).
### **Metodo IConnector.reroute() è stato aggiunto**
Il metodo com.aspose.slides.IConnector.reroute() ricalcola il percorso del connettore in modo che prenda il tragitto più breve possibile tra le forme collegate. Per fare ciò, il metodo reroute() può modificare StartShapeConnectionSiteIndex e EndShapeConnectionSiteIndex.

``` java
import com.aspose.slides.*;


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
Il metodo Aspose.Slides.IPresentation.getSlideById(long) restituisce una Slide, MasterSlide o LayoutSlide in base all'ID della slide.

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Metodo ISmartArt.getNodes() è stato aggiunto**
Il metodo com.aspose.slides.ISmartArt.getNodes() restituisce la raccolta di nodi radice nell'oggetto SmartArt.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // seleziona il secondo nodo radice

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Metodo ISmartArt.setLayout(int) è stato aggiunto**
Il metodo per la proprietà com.aspose.slides.ISmartArt.setLayout(int) è stato aggiunto. Consente di modificare il tipo di layout di un diagramma esistente.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Metodo ISmartArtNode.isHidden() è stato aggiunto**
Il metodo com.aspose.slides.ISmartArtNode.isHidden() restituisce true se questo nodo è nascosto nel modello dati.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //restituisce true

if(hidden) {

    //esegui alcune azioni o notifiche

}

pres.save("out.pptx", SaveFormat.Pptx);
```
### **Metodi ISmartArt.isReversed(), setReversed() sono stati aggiunti**
La proprietà com.aspose.slides.ISmartArt.IsReversed consente di ottenere o impostare lo stato del diagramma SmartArt rispetto a LTR (da sinistra a destra) o RTL (da destra a sinistra), se il diagramma supporta l'inversione.

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Metodi ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) sono stati aggiunti**
I metodi com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() e setOrganizationChartLayout(int) consentono di ottenere o impostare il tipo di organigramma associato al nodo corrente.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);
```
### **Proprietà IShape.getConnectionSiteCount() è stata aggiunta**
La proprietà com.aspose.slides.getConnectionSiteCount() restituisce il numero di punti di connessione sulla forma.

``` java
import com.aspose.slides.*;


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
Questo è l'elenco delle modifiche minori all'API:

|Enum com.aspose.slides.BevelColorMode|eliminato, enum non utilizzato|
|:-|:-|
|Method ThreeDFormatEffectiveData.getBevelColorMode()|eliminato, proprietà non utilizzata|
|Method com.aspose.slides.ChartSeriesGroup.getChart()|aggiunto|
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent|eliminato|
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle()|eliminato come obsoleto|