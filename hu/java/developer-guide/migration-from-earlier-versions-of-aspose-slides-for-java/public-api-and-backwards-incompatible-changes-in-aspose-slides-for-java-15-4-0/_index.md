---
title: Nyilvános API és visszafelé inkompatibilis változások az Aspose.Slides for Java 15.4.0-ban
linktitle: Aspose.Slides for Java 15.4.0
type: docs
weight: 120
url: /hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
keywords:
- migráció
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Tekintse át az Aspose.Slides for Java nyilvános API frissítéseit és törést okozó változásait, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="info" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) osztályt, metódust, tulajdonságot és így tovább, minden új korlátozást és egyéb [változást](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) amely a Aspose.Slides for Java 15.4.0 API-val került bevezetésre.

{{% /alert %}} 
## **Nyilvános API változások**
### **Az OrganizationChartLayoutType enum hozzá lett adva**
A com.aspose.slides.OrganizationChartLayoutType enum a szervezeti diagram gyermekcsomópontjainak formázási típusát képviseli.
### **Az IBulletFormat.applyDefaultParagraphIndentsShifts() metódus hozzá lett adva**
A com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts metódus alapértelmezett nem nulla eltolásokat állít be a hatékony bekezdés behúzásához (Indent) és baloldali margójához (MarginLeft), ha a felsorolás engedélyezve van (akárcsak a PowerPoint, ha engedélyezi a bekezdés felsorolásait/számozását). Ha a felsorolás le van tiltva, akkor csak visszaállítja a bekezdés behúzását és baloldali margóját (akárcsak a PowerPoint, ha letiltja a bekezdés felsorolásait/számozását).
### **Az IConnector.reroute() metódus hozzá lett adva**
A com.aspose.slides.IConnector.reroute() metódus átirányítja a csatlakozót, hogy a lehető legrövidebb utat vegye a kapcsolódó alakzatok között. Ennek érdekében a reroute() metódus megváltoztathatja a StartShapeConnectionSiteIndex és EndShapeConnectionSiteIndex értékeket.

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
### **Az IPresentation.getSlideById(long) metódus hozzá lett adva**
Az Aspose.Slides.IPresentation.getSlideById(long) metódus egy Slide, MasterSlide vagy LayoutSlide objektumot ad vissza a diavetítés azonosítója alapján.

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Az ISmartArt.getNodes() metódus hozzá lett adva**
A com.aspose.slides.ISmartArt.getNodes() metódus a SmartArt objektum gyökércsomópontjainak gyűjteményét adja vissza.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // válassza ki a második gyökércsomópontot

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Az ISmartArt.setLayout(int) metódus hozzá lett adva**
A com.aspose.slides.ISmartArt.setLayout(int) tulajdonság metódusa hozzá lett adva. Lehetővé teszi egy meglévő diagram elrendezéstípusának módosítását.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Az ISmartArtNode.isHidden() metódus hozzá lett adva**
A com.aspose.slides.ISmartArtNode.isHidden() metódus true értéket ad vissza, ha ez a csomópont rejtett a adatmodellben.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //true értéket ad vissza

if(hidden) {

    //végezzünk néhány műveletet vagy értesítést

}

pres.save("out.pptx", SaveFormat.Pptx);
```
### **Az ISmartArt.isReversed() és setReversed() metódusok hozzá lettek adva**
A com.aspose.slides.ISmartArt.IsReversed tulajdonság lehetővé teszi a SmartArt diagram állapotának lekérdezését vagy beállítását a balról jobbra (LTR) vagy jobbról balra (RTL) irányú megjelenítés tekintetében, ha a diagram támogatja a fordítást.

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Az ISmartArtNode.getOrganizationChartLayout() és setOrganizationChartLayout(int) metódusok hozzá lettek adva**
A com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() és setOrganizationChartLayout(int) metódusok lehetővé teszik a jelenlegi csomóponthoz kapcsolódó szervezeti diagram típus lekérdezését vagy beállítását.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);
```
### **Az IShape.getConnectionSiteCount() tulajdonság hozzá lett adva**
A com.aspose.slides.getConnectionSiteCount() tulajdonság visszaadja a forma csatlakozási pontjainak számát.

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
### **Apróbb változások**
Ez a kisebb API változások listája:

|Enum com.aspose.slides.BevelColorMode |törölve, nem használt enum |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |törölve, nem használt tulajdonság |
|Method com.aspose.slides.ChartSeriesGroup.getChart() |hozzáadva |
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |törölve |
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |törölve, elavultként |