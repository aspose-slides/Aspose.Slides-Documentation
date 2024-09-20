---
title: Публичный API и несовместимые изменения в Aspose.Slides для PHP через Java 15.4.0
type: docs
weight: 120
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
---

{{% alert color="primary" %}} 

Эта страница содержит список всех [добавленных](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) классов, методов, свойств и так далее, любых новых ограничений и других [изменений](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/), введенных с API Aspose.Slides для PHP через Java 15.4.0.

{{% /alert %}} 
## **Изменения в публичном API**
### **Добавлен перечисляемый тип OrganizationChartLayoutType**
Перечисляемый тип com.aspose.slides.OrganizationChartLayoutType представляет собой форматирование типа дочерних узлов в организационной диаграмме.
### **Добавлен метод IBulletFormat.applyDefaultParagraphIndentsShifts()**
Метод com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts устанавливает значения по умолчанию для не нулевых смещений для эффективного отступа параграфа и MarginLeft, когда включены маркеры (так же, как PowerPoint делает, когда включает маркеры/нумерацию параграфов). Если маркеры отключены, то просто сбрасывается отступ параграфа и MarginLeft (так же, как PowerPoint делает, когда отключает маркеры/нумерацию параграфов).
### **Добавлен метод IConnector.reroute()**
Метод com.aspose.slides.IConnector.reroute() перенаправляет соединитель так, чтобы он следовал самым коротким путем между фигурами, которые он соединяет. Для этого метод reroute() может изменить StartShapeConnectionSiteIndex и EndShapeConnectionSiteIndex.

```php
  $input = new Presentation();
  $shapes = $input->getSlides()->get_Item(0)->getShapes();
  $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
  $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
  $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
  $connector->setStartShapeConnectedTo($ellipse);
  $connector->setEndShapeConnectedTo($rectangle);
  $connector->reroute();
  $input->save("output.pptx", SaveFormat::Pptx);

```
### **Добавлен метод IPresentation.getSlideById(long)**
Метод Aspose.Slides.IPresentation.getSlideById(int) возвращает слайд, MasterSlide или LayoutSlide по идентификатору слайда.

```php
  $presentation = new Presentation();
  $id = $presentation->getSlides()->get_Item(0)->getSlideId();
  $slide = $presentation->getSlideById($id);

```
### **Добавлен метод ISmartArt.getNodes()**
Метод com.aspose.slides.ISmartArt.getNodes() возвращает коллекцию корневых узлов в объекте SmartArt.

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::VerticalBulletList);
  $node = $smart->getNodes()->get_Item(1);// выбираем второй корневой узел

  $node->getTextFrame()->setText("Второй корневой узел");
  $pres->save("out.pptx", SaveFormat::Pptx);

```
### **Добавлен метод ISmartArt.setLayout(int)**
Метод для свойства com.aspose.slides.ISmartArt.setLayout(int) был добавлен. Он позволяет изменить тип компоновки существующей диаграммы.

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
  $smart->setLayout(SmartArtLayoutType::BasicProcess);
  $pres->save("out.pptx", SaveFormat::Pptx);

```
### **Добавлен метод ISmartArtNode.isHidden()**
Метод com.aspose.slides.ISmartArtNode.isHidden() возвращает true, если этот узел является скрытым узлом в модели данных.

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
  $node = $smart->getAllNodes()->addNode();
  $hidden = $node->isHidden();// возвращает true

  if ($hidden) {
    # выполнить некоторые действия или уведомления
  }
  $pres->Save("out.pptx", SaveFormat::Pptx);

```
### **Добавлены методы ISmartArt.isReversed(), setReserved()**
Свойство com.aspose.slides.ISmartArt.IsReversed позволяет получать или устанавливать состояние диаграммы SmartArt в отношении (слева направо) LTR или (справа налево) RTL, если диаграмма поддерживает реверсию.

```php
  $presentation = new Presentation();
  $smart = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicProcess);
  $smart->setReversed(true);
  $presentation->save("out.pptx", SaveFormat::Pptx);

```
### **Добавлены методы ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int)**
Методы com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) позволяют получать или устанавливать тип организационной диаграммы, связанный с текущим узлом.

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
  $smart->getNodes()->get_Item(0)->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);
  $pres->save("out.pptx", SaveFormat::Pptx);

```
### **Добавлено свойство IShape.getConnectionSiteCount()**
Свойство com.aspose.slides.getConnectionSiteCount() возвращает количество соединительных точек на фигуре.

```php
  $input = new Presentation();
  $shapes = $input->getSlides()->get_Item(0)->getShapes();
  $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
  $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
  $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);
  $connector->setStartShapeConnectedTo($ellipse);
  $connector->setEndShapeConnectedTo($rectangle);
  $wantedIndex = 6;
  if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
    $connector->setStartShapeConnectionSiteIndex($wantedIndex);
  }
  $input->save("output.pptx", SaveFormat::Pptx);

```
### **Незначительные изменения**
Это список незначительных изменений в API:

|Enum com.aspose.slides.BevelColorMode |удален, неиспользуемый enum |
| :- | :- |
|Метод ThreeDFormatEffectiveData.getBevelColorMode() |удален, неиспользуемое свойство |
|Метод com.aspose.slides.ChartSeriesGroup.getChart() |добавлен |
|Наследование IParagraphFormatEffectiveData от ISlideComponent <br>Наследование IThreeDFormat от ISlideComponent |удалено |
|Метод com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Метод com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Метод com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Метод com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Метод com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Метод com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |удалены как устаревшие |

