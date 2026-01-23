---
title: إدارة دفاتر عمل المخططات في العروض التقديمية باستخدام PHP
linktitle: دفتر عمل المخطط
type: docs
weight: 70
url: /ar/php-java/chart-workbook/
keywords:
- دفتر عمل المخطط
- بيانات المخطط
- خلية دفتر العمل
- علامة البيانات
- ورقة عمل
- مصدر البيانات
- دفتر عمل خارجي
- بيانات خارجية
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "اكتشف Aspose.Slides للـ PHP عبر Java: إدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint و OpenDocument لتبسيط بيانات العرض التقديمي الخاص بك."
---

## **قراءة وكتابة بيانات المخطط من دفتر عمل**
توفر Aspose.Slides طرق readWorkbookStream و writeWorkbookStream التي تسمح لك بقراءة وكتابة دفاتر عمل بيانات المخططات (التي تحتوي على بيانات مخطط تم تعديلها باستخدام Aspose.Cells). **ملحوظة** أنه يجب تنظيم بيانات المخطط بنفس الطريقة أو يجب أن تكون لها بنية مشابهة للمصدر.

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
  # ينشئ مثيلًا من فئة العرض التي تمثل ملف عرض تقديمي
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

يوضح هذا الشيفرة PHP عملية يتم فيها استخدام طريقة [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/#getWorksheets) للوصول إلى مجموعة أوراق العمل:
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

يظهر لك هذا الشيفرة PHP كيفية تحديد نوع لمصدر البيانات:
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

يدعم Aspose.Slides دفاتر العمل الخارجية كمصدر بيانات للمخططات.

### **إنشاء دفتر عمل خارجي**

باستخدام طريقتي **`readWorkbookStream`** و **`setExternalWorkbook`** يمكنك إما إنشاء دفتر عمل خارجي من الصفر أو جعل دفتر عمل داخلي خارجيًا.

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

باستخدام طريقة **`setExternalWorkbook`** يمكنك ربط دفتر عمل خارجي بمخطط كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار دفتر العمل الخارجي (إذا تم نقل الأخير).

على الرغم من أنه لا يمكنك تعديل البيانات في دفاتر العمل المخزنة في مواقع أو موارد عن بُعد، إلا أنه لا يزال بإمكانك استخدام هذه الدفاتر كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لدفتر عمل خارجي، يتم تحويله تلقائيًا إلى مسار كامل.

```php
  # ينشئ مثيلاً من فئة Presentation
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


المعامل `ChartData` (ضمن طريقة `setExternalWorkbook`) يستخدم لتحديد ما إذا كان سيتم تحميل دفتر Excel أم لا.

* عندما تكون قيمة `ChartData` `false`، يتم تحديث مسار دفتر العمل فقط—لن يتم تحميل بيانات المخطط أو تحديثها من دفتر العمل الهدف. قد ترغب في استخدام هذا الإعداد عندما يكون دفتر العمل الهدف غير موجود أو غير متاح.  
* عندما تكون قيمة `ChartData` `true`، يتم تحديث بيانات المخطط من دفتر العمل الهدف.

```php
  # ينشئ مثيلاً من فئة Presentation
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


### **الحصول على مسار دفتر العمل الخارجي لمصدر البيانات لمخطط**

1. إنشاء مثيل من الفئة [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/presentation) .
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إنشاء كائن لشكل المخطط.
4. إنشاء كائن لنوع المصدر (`ChartDataSourceType`) الذي يمثل مصدر بيانات المخطط.
5. تحديد الشرط المناسب بناءً على أن نوع المصدر هو نفسه نوع مصدر دفتر العمل الخارجي.

```php
  # ينشئ مثيلاً من فئة Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(1);
    $chart = $slide->getShapes()->get_Item(0);
    $sourceType = $chart->getChartData()->getDataSourceType();
    if ($sourceType == ChartDataSourceType::ExternalWorkbook) {
      $path = $chart->getChartData()->getExternalWorkbookPath();
    }
    # يحفظ العرض التقديمي
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **تحرير بيانات المخطط**

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تعدل بها محتويات دفاتر العمل الداخلية. عندما لا يمكن تحميل دفتر عمل خارجي، يتم إلقاء استثناء.

```php
  # ينشئ مثيلاً من فئة Presentation
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

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًا بدفتر عمل خارجي أم مدمج؟**  
نعم. يحتوي المخطط على [نوع مصدر البيانات](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) ومسار إلى دفتر عمل خارجي [مسار دفتر العمل الخارجي](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/); إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل تدعم المسارات النسبية لدفاتر العمل الخارجية، وكيف يتم تخزينها؟**  
نعم. إذا قمت بتحديد مسار نسبي، يتم تحويله تلقائيًا إلى مسار مطلق. هذا مفيد لقابلية نقل المشروع؛ ومع ذلك، يجب أن تكون على علم بأن العرض التخطيطي سيخزن المسار المطلق في ملف PPTX.

**هل يمكنني استخدام دفاتر العمل الموجودة على موارد/مشاركات الشبكة؟**  
نعم، يمكن استخدام مثل هذه الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يدعم Aspose.Slides تعديل دفاتر العمل البعيدة مباشرةً—يمكن استخدامها فقط كمصدر.

**هل يقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض التقديمي؟**  
لا. يقوم العرض التخطيطي بتخزين [رابط إلى الملف الخارجي](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) ويستخدمه لقراءة البيانات. لا يتم تعديل الملف الخارجي عند حفظ العرض.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**  
Aspose.Slides لا تقبل كلمة مرور عند الربط. عادةً ما يُزال الحماية مسبقًا أو يتم إعداد نسخة غير مشفرة (مثلاً باستخدام [Aspose.Cells](/cells/php-java/)) وربطها بهذه النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**  
نعم. كل مخطط يخزن رابطه الخاص. إذا أشاروا جميعًا إلى نفس الملف، فإن تحديث ذلك الملف سينعكس في كل مخطط في المرة التالية التي يتم فيها تحميل البيانات.