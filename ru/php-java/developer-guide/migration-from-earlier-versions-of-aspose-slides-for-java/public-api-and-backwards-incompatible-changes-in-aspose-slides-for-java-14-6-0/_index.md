---
title: Публичный API и несовместимые изменения в Aspose.Slides для PHP через Java 14.6.0
type: docs
weight: 50
url: /ru/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-6-0/
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-6-0/) классы, методы, свойства и так далее, любые новые ограничения и другие изменения, внесенные в API Aspose.Slides для PHP через Java 14.6.0.

{{% /alert %}} 
## **Изменения в публичном API**
### **Добавленные классы, методы, интерфейсы и перечисления**
#### **Добавлены перечисление ViewType, интерфейс IViewProperties, класс ViewProperties и метод IPresentation.getViewProperties()**
Метод IPresentation.getViewProperty() предоставляет доступ к IViewProperties и позволяет изменять тип представления презентации и видимость заметок при открытии презентации в Microsoft PowerPoint.

```php
  $p = new Presentation();
  $p->getViewProperties()->setLastView(ViewType::SlideMasterView);

```
#### **Добавлены методы Aspose.Slides.IShapeCollection.addClone(...) и .insertClone(...)**
Методы

- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape),
- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape, float x, float y),
- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape, float x, float y, float width, float height),
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape),
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape, float x, float y), и
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape, float x, float y, float width, float height)

добавляют/вставляют копию указанной формы в коллекцию. 

```php
  $srcPres = new Presentation("data/Source Frame.pptx");
  $sourceShapes = $srcPres->getSlides()->get_Item(0)->getShapes();
  $blankLayout = $srcPres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
  $destSlide = $srcPres->getSlides()->addEmptySlide($blankLayout);
  $destShapes = $destSlide->getShapes();
  $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
  $destShapes->addClone($sourceShapes->get_Item(2));
  $destShapes->addClone($sourceShapes->get_Item(3), 50, 200, 50, 50);
  $destShapes->addClone($sourceShapes->get_Item(4));
  $destShapes->addClone($sourceShapes->get_Item(5), 300, 300, 50, 200);
  $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);

```
#### **Добавлен интерфейс Aspose.Slides.Charts.IDataSourceTypeForErrorBarsCustomValues**
Этот интерфейс определяет типы значений в списке свойств ChartDataPoint.ErrorBarsCustomValues.

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
  $series = $chart->getChartData()->getSeries()->get_Item(0);
  $errBarX = $series->getErrorBarsXFormat();
  $errBarY = $series->getErrorBarsYFormat();
  $errBarX->setVisible(true);
  $errBarY->setVisible(true);
  $errBarX->setValueType(ErrorBarValueType::Custom);
  $errBarY->setValueType(ErrorBarValueType::Custom);
  $points = $series->getDataPoints();
  $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
  $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
  $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
  $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
  for($i = 0; $i < java_values($points->size()) ; $i++) {
    $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
    $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
    $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
    $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
  }
  $pres->save("data/ErrorBarsCustomValues.pptx", SaveFormat::Pptx);

```
#### **Добавлен интерфейс Aspose.Slides.Charts.IErrorBarsCustomValues**
Когда свойство IErrorBarsFormat.ValueType равно Custom, для указания значения используйте свойство ErrorBarCustomValues конкретной точки данных в коллекции DataPoints серии.

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
  $series = $chart->getChartData()->getSeries()->get_Item(0);
  $errBarX = $series->getErrorBarsXFormat();
  $errBarY = $series->getErrorBarsYFormat();
  $errBarX->setVisible(true);
  $errBarY->setVisible(true);
  $errBarX->setValueType(ErrorBarValueType::Custom);
  $errBarY->setValueType(ErrorBarValueType::Custom);
  $points = $series->getDataPoints();
  $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
  $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
  $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
  $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
  for($i = 0; $i < java_values($points->size()) ; $i++) {
    $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
    $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
    $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
    $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
  }
  $pres->save("data/ErrorBarsCustomValues.pptx", SaveFormat::Pptx);

```
#### **Добавлен интерфейс Aspose.Slides.Charts.IErrorBarsFormat**
Этот интерфейс представляет собой погрешности серий графиков.
В случае пользовательского типа значения для указания значения используйте свойство ErrorBarCustomValues конкретной точки данных в коллекции DataPoints серии.

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
  $errBarX = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsXFormat();
  $errBarY = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsYFormat();
  $errBarX->setVisible(true);
  $errBarY->setVisible(true);
  $errBarX->setValueType(ErrorBarValueType::Fixed);
  $errBarX->setValue(0.1);
  $errBarY->setValueType(ErrorBarValueType::Percentage);
  $errBarY->setValue(5);
  $errBarX->setType(ErrorBarType::Plus);
  $errBarY->getFormat()->getLine()->setWidth(2);
  $errBarX->setEndCap(true);
  $pres->save("data/ErrorBars.pptx", SaveFormat::Pptx);

```