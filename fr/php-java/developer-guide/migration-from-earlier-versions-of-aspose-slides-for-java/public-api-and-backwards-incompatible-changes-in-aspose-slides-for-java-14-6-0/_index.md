---
title: API public et Changements incompatibles avec les versions précédentes dans Aspose.Slides pour PHP via Java 14.6.0
type: docs
weight: 50
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-6-0/
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les [nouvelles classes](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-6-0/), méthodes, propriétés, etc., ainsi que toute nouvelle restriction et d'autres changements introduits avec l'API Aspose.Slides pour PHP via Java 14.6.0.

{{% /alert %}} 
## **Changements de l'API publique**
### **Classes, méthodes, interfaces et énumérations ajoutées**
#### **Ajout de l'énumération ViewType, de l'interface IViewProperties, de la classe ViewProperties et de la méthode IPresentation.getViewProperties()**
La méthode IPresentation.getViewProperty() fournit un accès à IViewProperties et vous permet de modifier le type de vue de la présentation et la visibilité des notes lorsqu'une présentation est ouverte dans Microsoft PowerPoint.

```php
  $p = new Presentation();
  $p->getViewProperties()->setLastView(ViewType::SlideMasterView);

```
#### **Ajout des méthodes Aspose.Slides.IShapeCollection.addClone(...) et .insertClone(...)**
Les méthodes

- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape),
- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape, float x, float y),
- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape, float x, float y, float width, float height),
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape),
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape, float x, float y), et
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape, float x, float y, float width, float height)

ajoute/insertion une copie d'une forme spécifiée dans la collection. 

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
#### **Ajout de l'interface Aspose.Slides.Charts.IDataSourceTypeForErrorBarsCustomValues**
Cette interface spécifie les types de valeurs dans la liste des propriétés ChartDataPoint.ErrorBarsCustomValues.

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
#### **Ajout de l'interface Aspose.Slides.Charts.IErrorBarsCustomValues**
Lorsque la propriété IErrorBarsFormat.ValueType est égale à Custom, utilisez la propriété ErrorBarCustomValues du point de données spécifique dans la collection DataPoints de la série pour spécifier la valeur.

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
#### **Ajout de l'interface Aspose.Slides.Charts.IErrorBarsFormat**
Cette interface représente les barres d'erreur des séries de graphique.
En cas de type de valeur personnalisé, utilisez la propriété ErrorBarCustomValues d'un point de données spécifique dans la collection DataPoins de la série pour spécifier la valeur.

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