---
title: API Público y Cambios Incompatibles con Versiones Anteriores en Aspose.Slides para PHP a través de Java 14.6.0
type: docs
weight: 50
url: /es/php-java/api-publico-y-cambios-incompatibles-con-versiones-anteriores-en-aspose-slides-para-java-14-6-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las [clases añadidas](/slides/es/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-6-0/), métodos, propiedades, y así sucesivamente, cualquier nueva restricción y otros cambios introducidos con la API de Aspose.Slides para PHP a través de Java 14.6.0.

{{% /alert %}} 
## **Cambios en la API Pública**
### **Clases, Métodos, Interfaces y Enumeraciones Añadidos**
#### **Añadida la Enumeración ViewType, la Interfaz IViewProperties, la Clase ViewProperties y el Método IPresentation.getViewProperties()**
El método IPresentation.getViewProperty() proporciona acceso a IViewProperties y permite cambiar el tipo de vista de la presentación y la visibilidad de las notas cuando se abre una presentación en Microsoft PowerPoint.

```php
  $p = new Presentation();
  $p->getViewProperties()->setLastView(ViewType::SlideMasterView);

```
#### **Añadidos los Métodos Aspose.Slides.IShapeCollection.addClone(...) y .insertClone(...)**
Los métodos

- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape),
- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape, float x, float y),
- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape, float x, float y, float width, float height),
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape),
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape, float x, float y), y
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape, float x, float y, float width, float height)

añaden/inserta una copia de una forma específica en la colección.

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
#### **Añadida la Interfaz Aspose.Slides.Charts.IDataSourceTypeForErrorBarsCustomValues**
Esta interfaz especifica los tipos de valores en la lista de propiedades ChartDataPoint.ErrorBarsCustomValues.

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
#### **Añadida la Interfaz Aspose.Slides.Charts.IErrorBarsCustomValues**
Cuando la propiedad IErrorBarsFormat.ValueType es igual a Custom para especificar valor utiliza la propiedad ErrorBarCustomValues del punto de datos específico en la colección DataPoints de la serie.

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
#### **Añadida la Interfaz Aspose.Slides.Charts.IErrorBarsFormat**
Esta interfaz representa las barras de error de las series de gráficos.
En caso de tipo de valor personalizado para especificar el valor utiliza la propiedad ErrorBarCustomValues de un punto de datos específico en la colección DataPoints de la serie.

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