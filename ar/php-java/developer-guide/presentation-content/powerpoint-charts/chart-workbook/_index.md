---
title: مصنف الرسم البياني
type: docs
weight: 70
url: /php-java/chart-workbook/
keywords: "مصنف الرسم البياني، بيانات الرسم البياني، عرض PowerPoint، Java، Aspose.Slides لـ PHP عبر Java"
description: "مصنف الرسم البياني في عرض PowerPoint"
---

## **تعيين بيانات الرسم البياني من المصنف**
توفر Aspose.Slides طرق [ReadWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#readWorkbookStream--) و [WriteWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#writeWorkbookStream-byte:A-) التي تتيح لك قراءة وكتابة مصنفات بيانات الرسم البياني (تحتوي على بيانات الرسم البياني المعدلة باستخدام Aspose.Cells). **ملاحظة** يجب تنظيم بيانات الرسم البياني بنفس الطريقة أو يجب أن تحتوي على بنية مشابهة للمصدر.

يوضح هذا الكود PHP عملية نموذجية:

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

## **تعيين خلية المصنف كعلامة بيانات الرسم البياني**

1. إنشاء مثيل من فئة [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/presentation).
1. الحصول على مرجع الشريحة من خلال الفهرس الخاص بها.
1. إضافة رسم بياني فقاعة مع بعض البيانات.
1. الوصول إلى سلسلة الرسم البياني.
1. تعيين خلية المصنف كعلامة بيانات.
1. حفظ العرض التقديمي.

يوضح لك هذا الكود PHP كيفية تعيين خلية المصنف كعلامة بيانات للرسم البياني:

```php
  $lbl0 = "قيمة خلية التسمية 0";
  $lbl1 = "قيمة خلية التسمية 1";
  $lbl2 = "قيمة خلية التسمية 2";
  # ينشئ مثيلًا من فئة العرض التقديمي التي تمثل ملف عرض تقديمي
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

يوضح هذا الكود PHP عملية حيث يتم استخدام طريقة [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook#getWorksheets--) للوصول إلى مجموعة أوراق العمل:

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

يوضح لك هذا الكود PHP كيفية تحديد نوع لمصدر البيانات:

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

## **المصنف الخارجي**

{{% alert color="primary" %}} 
في [Aspose.Slides 19.4](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-19-4-release-notes/)، قمنا بتنفيذ دعم المصنفات الخارجية كمصدر بيانات للرسم البياني.
{{% /alert %}} 

### **إنشاء مصنف خارجي**

باستخدام الطريقتين **`readWorkbookStream`** و **`setExternalWorkbook`**، يمكنك إما إنشاء مصنف خارجي من الصفر أو جعل مصنف داخلي خارجي.

يوضح هذا الكود PHP عملية إنشاء المصنف الخارجي:

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

### **تعيين المصنف الخارجي**

باستخدام طريقة **`setExternalWorkbook`**، يمكنك تعيين مصنف خارجي لرسم بياني كمصدر بيانات له. يمكن استخدام هذه الطريقة أيضًا لتحديث المسار إلى المصنف الخارجي (إذا تم نقل الأخير).

بينما لا يمكنك تحرير البيانات في المصنفات المخزنة في المواقع أو الموارد البعيدة، يمكنك استخدام مثل هذه المصنفات كمصدر بيانات خارجي. إذا تم توفير المسار النسبي لمصنف خارجي، فإنه يتم تحويله تلقائيًا إلى مسار كامل.

يوضح هذا الكود PHP كيفية تعيين مصنف خارجي:

```php
  # ينشئ مثيلًا من فئة العرض التقديمي
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

معامل `ChartData` (تحت طريقة `setExternalWorkbook`) يستخدم لتحديد ما إذا كان سيتم تحميل مصنف Excel أم لا.

* عند تعيين قيمة `ChartData` إلى `false`، يتم تحديث مسار المصنف فقط - لن يتم تحميل بيانات الرسم البياني أو تحديثها من المصنف المستهدف. قد ترغب في استخدام هذا الإعداد في حالة عدم وجود المصنف المستهدف أو عدم توفره.
* عند تعيين قيمة `ChartData` إلى `true` ، يتم تحديث بيانات الرسم البياني من المصنف المستهدف.

```php
  # ينشئ مثيلًا من فئة العرض التقديمي
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

### **الحصول على مسار مصدر البيانات الخارجي للرسم البياني**

1. إنشاء مثيل من فئة [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/presentation).
1. الحصول على مرجع الشريحة من خلال الفهرس الخاص بها.
1. إنشاء كائن لشكل الرسم البياني.
1. إنشاء كائن لنوع مصدر البيانات (`ChartDataSourceType`) الذي يمثل مصدر بيانات الرسم البياني.
1. تحديد الشرط الملائم بناءً على نوع المصدر الذي يكون نفس نوع مصدر البيانات للمصنف الخارجي.

يوضح هذا الكود PHP العملية:

```php
  # ينشئ مثيلًا من فئة العرض التقديمي
  $pres = new Presentation("chart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(1);
    $chart = $slide->getShapes()->get_Item(0);
    $sourceType = $chart->getChartData()->getDataSourceType();
    if ($sourceType == ChartDataSourceType::ExternalWorkbook) {
      $path = $chart->getChartData()->getExternalWorkbookPath();
    }
    # حفظ العرض التقديمي
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **تحرير بيانات الرسم البياني**

يمكنك تحرير البيانات في المصنفات الخارجية بنفس الطريقة التي تقوم بها بإجراء تغييرات على محتويات المصنفات الداخلية. عندما لا يمكن تحميل المصنف الخارجي، يتم طرح استثناء.

هذا الكود PHP هو تنفيذ للعملية الموصوفة:

```php
  # ينشئ مثيلًا من فئة العرض التقديمي
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