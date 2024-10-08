---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ PHP عبر Java 14.6.0
type: docs
weight: 50
url: /ar/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-6-0/
---

{{% alert color="primary" %}} 

تسرد هذه الصفحة جميع [الإضافات](/slides/ar/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-6-0/) من الفصول والأساليب والخصائص وما إلى ذلك، وأي قيود جديدة وأي تغييرات أخرى تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides لـ PHP عبر Java 14.6.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **الفصول والأساليب والواجهات والتعدادات المضافة**
#### **تمت إضافة تعداد ViewType، وواجهة IViewProperties، وفصل ViewProperties، وطريقة IPresentation.getViewProperties()**
تتيح طريقة IPresentation.getViewProperty() الوصول إلى IViewProperties وتسمح لك بتغيير نوع عرض العرض وظهور الملاحظات عند فتح عرض تقديمي في Microsoft PowerPoint.

```php
  $p = new Presentation();
  $p->getViewProperties()->setLastView(ViewType::SlideMasterView);

```
#### **تمت إضافة الأساليب Aspose.Slides.IShapeCollection.addClone(...) و .insertClone(...)**
تقوم الأساليب

- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape),
- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape, float x, float y),
- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape, float x, float y, float width, float height),
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape),
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape, float x, float y)، و
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape, float x, float y, float width, float height)

تقوم بإضافة/إدراج نسخة من شكل محدد إلى المجموعة.

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
#### **تمت إضافة واجهة Aspose.Slides.Charts.IDataSourceTypeForErrorBarsCustomValues**
تحدد هذه الواجهة أنواع القيم في قائمة خصائص ChartDataPoint.ErrorBarsCustomValues.

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
#### **تمت إضافة واجهة Aspose.Slides.Charts.IErrorBarsCustomValues**
عندما تكون خاصية IErrorBarsFormat.ValueType تساوي Custom لتحديد القيمة استخدم خاصية ErrorBarCustomValues للنقطة البيانية المحددة في مجموعة DataPoints للseries.

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
#### **تمت إضافة واجهة Aspose.Slides.Charts.IErrorBarsFormat**
تمثل هذه الواجهة أشرطة الخطأ لسلسلة المخططات. في حالة نوع القيمة المخصصة لتحديد القيمة استخدم خاصية ErrorBarCustomValues لنقطة البيانات المحددة في مجموعة DataPoints للسلسلة.

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