---
title: Публичный API и изменения, несовместимые с обратной совместимостью в Aspose.Slides для Java 15.4.0
type: docs
weight: 120
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
---

{{% alert color="primary" %}} 

Эта страница содержит список всех [добавленных](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) классов, методов, свойств и т.д., новых ограничений и других [изменений](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/), введенных с API Aspose.Slides для Java 15.4.0.

{{% /alert %}} 
## **Изменения публичного API**
### **Добавлен enum OrganizationChartLayoutType**
Перечисление com.aspose.slides.OrganizationChartLayoutType представляет собой тип форматирования дочерних узлов в организационной схеме.
### **Добавлен метод IBulletFormat.applyDefaultParagraphIndentsShifts()**
Метод com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts устанавливает значения по умолчанию, отличные от нуля, для эффективного отступа параграфа и MarginLeft, когда включены маркеры (как делает PowerPoint, если включены маркеры/нумерация параграфов). Если маркеры отключены, происходит сброс отступа параграфа и MarginLeft (как делает PowerPoint, если отключены маркеры/нумерация параграфов).
### **Добавлен метод IConnector.reroute()**
Метод com.aspose.slides.IConnector.reroute() перенаправляет соединитель так, чтобы он принимал кратчайший возможный путь между фигурами, которые он соединяет. Для этого метод reroute() может изменять StartShapeConnectionSiteIndex и EndShapeConnectionSiteIndex.

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
### **Добавлен метод IPresentation.getSlideById(long)**
Метод Aspose.Slides.IPresentation.getSlideById(int) возвращает Slide, MasterSlide или LayoutSlide по идентификатору слайда.

``` java

 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Добавлен метод ISmartArt.getNodes()**
Метод com.aspose.slides.ISmartArt.getNodes() возвращает коллекцию корневых узлов в объекте SmartArt.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // выбираем второй корневой узел

node.getTextFrame().setText("Второй корневой узел");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Добавлен метод ISmartArt.setLayout(int)**
Метод для свойства com.aspose.slides.ISmartArt.setLayout(int) был добавлен. Он позволяет изменить тип макета существующей схемы.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Добавлен метод ISmartArtNode.isHidden()**
Метод com.aspose.slides.ISmartArtNode.isHidden() возвращает true, если этот узел является скрытым узлом в модели данных.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); // возвращает true

if(hidden) {

    // выполнить некоторые действия или уведомления

}

pres.Save("out.pptx", SaveFormat.Pptx);

```
### **Добавлены методы ISmartArt.isReversed(), setReserved()**
Свойство com.aspose.slides.ISmartArt.IsReversed позволяет получать или устанавливать состояние диаграммы SmartArt относительно (слева направо) LTR или (справа налево) RTL, если диаграмма поддерживает реверсирование.

``` java

 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Добавлены методы ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int)**
Методы com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) позволяют получать или устанавливать тип организационной схемы, связанный с текущим узлом.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Добавлено свойство IShape.getConnectionSiteCount()**
Свойство com.aspose.slides.getConnectionSiteCount() возвращает количество точек подключения на фигуре.

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
### **Небольшие изменения**
Вот список небольших изменений в API:

|Enum com.aspose.slides.BevelColorMode |удалено, неиспользуемое перечисление |
| :- | :- |
|Метод ThreeDFormatEffectiveData.getBevelColorMode() |удален, неиспользуемое свойство |
|Метод com.aspose.slides.ChartSeriesGroup.getChart() |добавлен |
|Наследование IParagraphFormatEffectiveData от ISlideComponent <br>Наследование IThreeDFormat от ISlideComponent |удалено |
|Метод com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Метод com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Метод com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Метод com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Метод com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Метод com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |удалены как устаревшие |