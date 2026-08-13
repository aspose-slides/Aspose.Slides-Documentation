---
title: Публичный API и несовместимые изменения в Aspose.Slides for Java 15.4.0
linktitle: Aspose.Slides для Java 15.4.0
type: docs
weight: 120
url: /ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
keywords:
- миграция
- старый код
- современный код
- устаревший подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Обзор обновлений публичного API и ломающих изменений в Aspose.Slides for Java для плавной миграции ваших решений по работе с презентациями PowerPoint PPT, PPTX и ODP."
---
{{% alert color="info" %}} 
Эта страница перечисляет все [добавленные](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) классы, методы, свойства и т.д., любые новые ограничения и другие [изменения](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) , введённые в API Aspose.Slides for Java 15.4.0.
{{% /alert %}} 
## **Изменения публичного API**
### **Enum OrganizationChartLayoutType был добавлен**
Перечисление com.aspose.slides.OrganizationChartLayoutType представляет тип форматирования дочерних узлов в организационной схеме.
### **Метод IBulletFormat.applyDefaultParagraphIndentsShifts() был добавлен**
Метод com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts задаёт значения сдвигов по умолчанию, отличные от нуля, для эффективных отступов абзаца (Indent) и левого поля (MarginLeft), когда маркеры включены (как делает PowerPoint при включении маркированных/нумерованных списков). Если маркеры отключены, то просто сбрасывает отступ абзаца и левое поле (как делает PowerPoint при их отключении).
### **Метод IConnector.reroute() был добавлен**
Метод com.aspose.slides.IConnector.reroute() перенаправляет соединитель так, чтобы он принимал кратчайший возможный путь между соединяемыми фигурами. Для этого метод reroute() может изменить свойства StartShapeConnectionSiteIndex и EndShapeConnectionSiteIndex.
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
### **Метод IPresentation.getSlideById(long) был добавлен**
Метод Aspose.Slides.IPresentation.getSlideById(long) возвращает объект Slide, MasterSlide или LayoutSlide по идентификатору слайда.
``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Метод ISmartArt.getNodes() был добавлен**
Метод com.aspose.slides.ISmartArt.getNodes() возвращает коллекцию корневых узлов в объекте SmartArt.
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // выбрать второй корневой узел

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Метод ISmartArt.setLayout(int) был добавлен**
Метод свойства com.aspose.slides.ISmartArt.setLayout(int) был добавлен. Он позволяет изменять тип макета существующей диаграммы.
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Метод ISmartArtNode.isHidden() был добавлен**
Метод com.aspose.slides.ISmartArtNode.isHidden() возвращает true, если данный узел является скрытым в модели данных.
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); // возвращает true

if(hidden) {

    // выполнить некоторые действия или уведомления

}

pres.save("out.pptx", SaveFormat.Pptx);
```
### **Методы ISmartArt.isReversed(), setReversed() были добавлены**
Свойство com.aspose.slides.ISmartArt.IsReversed позволяет получить или задать состояние диаграммы SmartArt относительно ориентации слева направо (LTR) или справа налево (RTL), если диаграмма поддерживает обратную ориентацию.
``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Методы ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) были добавлены**
Методы com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() и setOrganizationChartLayout(int) позволяют получить или задать тип организационной схемы, связанный с текущим узлом.
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);
```
### **Свойство IShape.getConnectionSiteCount() было добавлено**
Свойство com.aspose.slides.getConnectionSiteCount() возвращает количество точек соединения на фигуре.
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
### **Мелкие изменения**
Это список мелких изменений API:

|Enum com.aspose.slides.BevelColorMode |удалён, неиспользуемый enum |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |удалено, неиспользуемое свойство |
|Method com.aspose.slides.ChartSeriesGroup.getChart() |добавлен |
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |удалено |
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |удалено как устаревшее |