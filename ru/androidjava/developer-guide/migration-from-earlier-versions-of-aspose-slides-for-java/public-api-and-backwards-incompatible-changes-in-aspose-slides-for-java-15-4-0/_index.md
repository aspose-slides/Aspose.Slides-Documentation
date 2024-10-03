---
title: Публичный API и несовместимые изменения в Aspose.Slides для Java 15.4.0
type: docs
weight: 120
url: /ru/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
---

{{% alert color="primary" %}} 

На этой странице перечислены все [добавленные](/slides/ru/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) классы, методы, свойства и т. д., любые новые ограничения и другие [изменения](/slides/ru/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/), введенные в API Aspose.Slides для Java 15.4.0.

{{% /alert %}} 
## **Изменения в публичном API**
### **Добавлен Enum OrganizationChartLayoutType**
Перечисление com.aspose.slides.OrganizationChartLayoutType представляет собой тип форматирования дочерних узлов в организационной диаграмме.
### **Добавлен метод IBulletFormat.applyDefaultParagraphIndentsShifts()**
Метод com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts устанавливает значения по умолчанию для сдвигов ненулевых отступов для эффективного отступа абзаца и MarginLeft, когда включены маркеры (так же, как делает PowerPoint, если включены маркеры/нумерация абзацев). Если маркеры отключены, просто сбрасывает отступ абзаца и MarginLeft (так, как это делает PowerPoint, если отключены маркеры/нумерация абзацев).
### **Добавлен метод IConnector.reroute()**
Метод com.aspose.slides.IConnector.reroute() перенаправляет соединитель так, чтобы он проходил по кратчайшему возможному пути между фигурами, которые он соединяет. Для этого метод reroute() может изменить StartShapeConnectionSiteIndex и EndShapeConnectionSiteIndex.

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
Метод Aspose.Slides.IPresentation.getSlideById(int) возвращает слайд, мастер-слид или слайд макета по идентификатору слайда.

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
Метод для свойства com.aspose.slides.ISmartArt.setLayout(int) был добавлен. Он позволяет изменить тип макета существующей диаграммы.

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
Свойство com.aspose.slides.ISmartArt.IsReversed позволяет получить или установить состояние диаграммы SmartArt по отношению к (слева направо) LTR или (справа налево) RTL, если диаграмма поддерживает реверсию.

``` java

 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Добавлены методы ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int)**
Методы com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) позволяют получить или установить тип организационной диаграммы, связанной с текущим узлом.

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
Вот список небольших изменений API:

|Enum com.aspose.slides.BevelColorMode |удален, неиспользуемый enum |
| :- | :- |
|Метод ThreeDFormatEffectiveData.getBevelColorMode() |удален, неиспользуемое свойство |
|Метод com.aspose.slides.ChartSeriesGroup.getChart() |добавлен |
|Наследование IParagraphFormatEffectiveData от ISlideComponent <br>Наследование IThreeDFormat от ISlideComponent |удалено |
|Метод com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Метод com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Метод com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Метод com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Метод com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Метод com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |удалены как устаревшие |