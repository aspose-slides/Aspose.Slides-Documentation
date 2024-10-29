---
title: Öffentliche API und nicht rückwärtskompatible Änderungen in Aspose.Slides für PHP über Java 14.6.0
type: docs
weight: 50
url: /de/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-6-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-6-0/) Klassen, Methoden, Eigenschaften und so weiter, alle neuen Einschränkungen und andere Änderungen auf, die mit der Aspose.Slides für PHP über Java 14.6.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen der öffentlichen API**
### **Hinzugefügte Klassen, Methoden, Schnittstellen und Aufzählungen**
#### **Hinzugefügte ViewType-Aufzählung, IViewProperties-Schnittstelle, ViewProperties-Klasse und IPresentation.getViewProperties() Methode**
Die IPresentation.getViewProperty() Methode bietet Zugriff auf IViewProperties und ermöglicht es Ihnen, den Präsentationsansichtstyp und die Sichtbarkeit von Notizen zu ändern, wenn eine Präsentation in Microsoft PowerPoint geöffnet wird.

```php
  $p = new Presentation();
  $p->getViewProperties()->setLastView(ViewType::SlideMasterView);

```
#### **Hinzugefügte Methoden Aspose.Slides.IShapeCollection.addClone(...) und .insertClone(...)**
Die Methoden

- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape),
- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape, float x, float y),
- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape, float x, float y, float width, float height),
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape),
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape, float x, float y), und
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape, float x, float y, float width, float height)

fügen eine Kopie einer bestimmten Form in die Sammlung ein.

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
#### **Hinzugefügte Aspose.Slides.Charts.IDataSourceTypeForErrorBarsCustomValues-Schnittstelle**
Diese Schnittstelle spezifiziert die Typen von Werten in der Auflistung der Eigenschaften ChartDataPoint.ErrorBarsCustomValues.

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
#### **Hinzugefügte Aspose.Slides.Charts.IErrorBarsCustomValues-Schnittstelle**
Wenn die IErrorBarsFormat.ValueType-Eigenschaft gleich Custom ist, verwenden Sie die ErrorBarCustomValues-Eigenschaft des spezifischen Datenpunkts in der Datenpunkte-Auflistung der Serie, um den Wert anzugeben.

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
#### **Hinzugefügte Aspose.Slides.Charts.IErrorBarsFormat-Schnittstelle**
Diese Schnittstelle stellt die Fehlerbalken von Diagrammserien dar. 
Im Falle des benutzerdefinierten Werttyps verwenden Sie die ErrorBarCustomValues-Eigenschaft eines spezifischen Datenpunkts in der Datenpunkte-Auflistung der Serie, um den Wert anzugeben.

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