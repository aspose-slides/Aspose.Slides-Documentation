---
title: إدارة دفاتر عمل المخططات في العروض باستخدام PHP
linktitle: دفتر عمل المخطط
type: docs
weight: 70
url: /ar/php-java/chart-workbook/
keywords:
- دفتر عمل المخطط
- بيانات المخطط
- خلية دفتر العمل
- تسمية البيانات
- ورقة عمل
- مصدر البيانات
- دفتر عمل خارجي
- بيانات خارجية
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "اكتشف Aspose.Slides لـ PHP عبر Java: إدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint وOpenDocument لتبسيط بيانات عرضك التقديمي."
---

## **قراءة وكتابة بيانات المخطط من دفتر عمل**
توفر Aspose.Slides الطريقة [ReadWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#readWorkbookStream--) و [WriteWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#writeWorkbookStream-byte:A-) التي تسمح لك بقراءة وكتابة دفاتر عمل بيانات المخطط (التي تحتوي على بيانات مخطط تم تحريرها باستخدام Aspose.Cells). **ملاحظة** أن بيانات المخطط يجب أن تكون منظمة بنفس الطريقة أو أن تكون لها بنية مشابهة للمصدر.

```php
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $data = $chart->getChartData();
    $stream = $data->readWorkbookStream();
    $data->getSeries()->clear();
    $data->getCategories()->clear();
    $data->writeWorkbookStream($stream);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تعيين خلية دفتر العمل كعلامة بيانات للمخطط**
1. إنشاء مثيل من الفئة [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/presentation) .
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة مخطط فقاعي مع بعض البيانات.
4. الوصول إلى سلسلة المخطط.
5. تعيين خلية دفتر العمل كعلامة بيانات.
6. حفظ العرض.

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # ينشئ كائنًا من فئة العرض الذي يمثل ملف عرض
  $pres = new Presentation("chart2.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $dataLabelCollection = $series->get_Item(0)->getLabels();
    $dataLabelCollection->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $dataLabelCollection->get_Item(0)->setValueFromCell($wb->getCell(0, "A10", $lbl0));
    $dataLabelCollection->get_Item(1)->setValueFromCell($wb->getCell(0, "A11", $lbl1));
    $dataLabelCollection->get_Item(2)->setValueFromCell($wb->getCell(0, "A12", $lbl2));
    $pres->save("resultchart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إدارة أوراق العمل**
هذا الكود PHP يُظهر عملية حيث يتم استخدام الطريقة [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook#getWorksheets--) للوصول إلى مجموعة أوراق العمل:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    for($i = 0; $i < java_values($wb->getWorksheets()->size()) ; $i++) {
      echo($wb->getWorksheets()->get_Item($i)->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تحديد نوع مصدر البيانات**
هذا الكود PHP يوضح لك كيفية تحديد نوع لمصدر البيانات:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $val = $chart->getChartData()->getSeries()->get_Item(0)->getName();
    $val->setDataSourceType(DataSourceType::StringLiterals);
    $val->setData("LiteralString");
    $val = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $val->setData($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1", "NewCell"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **دفتر عمل خارجي**
{{% alert color="primary" %}} 
في [Aspose.Slides 19.4](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-19-4-release-notes/)، قمنا بتنفيذ دعم دفاتر العمل الخارجية كمصدر بيانات للمخططات.
{{% /alert %}} 

### **إنشاء دفتر عمل خارجي**
باستخدام الطريقتين **`readWorkbookStream`** و **`setExternalWorkbook`**، يمكنك إما إنشاء دفتر عمل خارجي من الصفر أو جعل دفتر عمل داخلي خارجيًا.

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $workbookPath = "externalWorkbook1.xlsx";
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
    $Array = new java_class("java.lang.reflect.Array");
    try {
      $workbookData = $chart->getChartData()->readWorkbookStream();
      $fileStream->write($workbookData, 0, $Array->getLength($workbookData));
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
    $chart->getChartData()->setExternalWorkbook($workbookPath);
    $pres->save("externalWorkbook.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **تعيين دفتر عمل خارجي**
باستخدام الطريقة **`setExternalWorkbook`**، يمكنك تعيين دفتر عمل خارجي لمخطط كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار دفتر العمل الخارجي (إذا تم نقل الأخير).

على الرغم من أنك لا تستطيع تحرير البيانات في دفاتر العمل المخزنة في مواقع أو موارد بعيدة، يمكنك لا يزال استخدام هذه الدفاتر كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لدفتر عمل خارجي، يتم تحويله إلى مسار كامل تلقائيًا.

هذا الكود PHP يوضح لك كيفية تعيين دفتر عمل خارجي:

```php
  # ينشئ مثيلاً لفئة Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, false);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("externalWorkbook.xlsx");
    $chartData->getSeries()->add($chartData->getChartDataWorkbook()->getCell(0, "B1"), ChartType::Pie);
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B2"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B3"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B4"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A2"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A3"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A4"));
    $pres->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


المعلمة `ChartData` (تحت طريقة `setExternalWorkbook`) تُستخدم لتحديد ما إذا كان سيتم تحميل دفتر عمل Excel أم لا.

* عند تعيين قيمة `ChartData` إلى `false`، يتم تحديث مسار دفتر العمل فقط—لن يتم تحميل بيانات المخطط أو تحديثها من دفتر العمل المستهدف. قد ترغب في استخدام هذا الإعداد عندما يكون دفتر العمل المستهدف غير موجود أو غير متاح.
* عند تعيين قيمة `ChartData` إلى `true`، يتم تحديث بيانات المخطط من دفتر العمل المستهدف.

```php
  # ينشئ مثيلاً لفئة Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("http://path/doesnt/exists", false);
    $pres->save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **الحصول على مسار دفتر العمل كمصدر بيانات خارجي لمخطط**
1. إنشاء مثيل من الفئة [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/presentation) .
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إنشاء كائن لشكل المخطط.
4. إنشاء كائن لنوع المصدر (`ChartDataSourceType`) الذي يمثل مصدر بيانات المخطط.
5. تحديد الشرط المناسب بناءً على أن نوع المصدر هو نفسه نوع مصدر دفتر العمل الخارجي.

هذا الكود PHP يُظهر العملية:

```php
  # ينشئ مثيلاً لفئة Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(1);
    $chart = $slide->getShapes()->get_Item(0);
    $sourceType = $chart->getChartData()->getDataSourceType();
    if ($sourceType == ChartDataSourceType::ExternalWorkbook) {
      $path = $chart->getChartData()->getExternalWorkbookPath();
    }
    # يحفظ العرض
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **تحرير بيانات المخطط**
يمكنك تحرير البيانات في دفاتر العمل الخارجية بالطريقة نفسها التي تجري بها تغييرات على محتويات دفاتر العمل الداخلية. عندما لا يمكن تحميل دفتر عمل خارجي، يُطلق استثناء.

هذا الكود PHP هو تنفيذ للعملية الموصوفة:

```php
  # ينشئ مثيلاً لفئة Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chartData = $chart->getChartData();
    $chartData->getSeries()->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell()->setValue(100);
    $pres->save("presentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة الشائعة**
**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًا بدفتر عمل خارجي أم مضمّن؟**  
نعم. يحتوي المخطط على [نوع مصدر البيانات](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) و[مسار إلى دفتر عمل خارجي](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/)؛ إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من أن ملفًا خارجيًا يتم استخدامه.

**هل يتم دعم المسارات النسبية لدفاتر العمل الخارجية، وكيف يتم تخزينها؟**  
نعم. إذا حددت مسارًا نسبيًا، يتم تحويله تلقائيًا إلى مسار مطلق. هذا مريح لنقل المشروع؛ ومع ذلك، يجب أن تكون على علم أن العرض سيخزن المسار المطلق في ملف PPTX.

**هل يمكنني استخدام دفاتر العمل الموجودة على موارد/مشاركات الشبكة؟**  
نعم، يمكن استخدام هذه الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يُدعم تحرير دفاتر العمل البعيدة مباشرةً من Aspose.Slides—يمكن استخدامها فقط كمصدر.

**هل تقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض؟**  
لا. يحفظ العرض [رابطًا إلى الملف الخارجي](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) ويستخدمه لقراءة البيانات. الملف الخارجي نفسه لا يتغير عند حفظ العرض.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**  
لا تقبل Aspose.Slides كلمة مرور عند الربط. نهج شائع هو إزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (مثلاً باستخدام [Aspose.Cells](/cells/php-java/)) وربطها بتلك النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**  
نعم. كل مخطط يخزن رابطه الخاص. إذا كانت جميعها تشير إلى نفس الملف، سيتم انعكاس تحديث ذلك الملف على كل مخطط في المرة التالية التي يتم فيها تحميل البيانات.