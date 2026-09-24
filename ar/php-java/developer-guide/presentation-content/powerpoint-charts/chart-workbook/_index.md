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
- عنوان البيانات
- ورقة العمل
- مصدر البيانات
- دفتر عمل خارجي
- بيانات خارجية
- مخزن المخطط المؤقت
- استعادة دفتر العمل
- PowerPoint
- عرض
- PHP
- Aspose.Slides
description: "اكتشف Aspose.Slides للـ PHP عبر Java: إدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint وOpenDocument لتبسيط بيانات العرض الخاص بك."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية العمل مع دفاتر عمل المخططات في Aspose.Slides. تظهر كيفية قراءة وكتابة بيانات المخطط عبر تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كعناوين بيانات للمخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

كما تغطي العمل مع دفاتر العمل الخارجية كمصادر بيانات للمخططات. توضح الأمثلة كيفية إنشاء وتعيين دفتر عمل خارجي، استرجاع مسار دفتر عمل خارجي مرتبط بمخطط، وتعديل بيانات المخطط عندما يكون دفتر العمل متاحًا.

لخلايا دفتر العمل التي تمثل بيانات مفقودة، راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/php-java/chart-series/) لمعرفة الفرق بين الخلية الفارغة والصفر، ومقارنة مخطط خطي لأوضاع العرض المتاحة.

## **قراءة وكتابة بيانات المخطط من دفتر عمل**
توفر Aspose.Slides طريقة [readWorkbookStream](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdata/#readWorkbookStream) وطريقة [writeWorkbookStream](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdata/#writeWorkbookStream) التي تتيح لك قراءة وكتابة دفاتر عمل بيانات المخطط (المحتوية على بيانات مخطط تم تحريرها باستخدام Aspose.Cells). **ملاحظة** أن بيانات المخطط يجب أن تكون منظمة بنفس الطريقة أو أن يكون لها بنية مشابهة للمصدر.

يعرض هذا الكود PHP عملية نموذجية:

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

### **التحقق من تخطيط المخطط بعد تعديل دفتر العمل**

عند استبدال دفتر عمل مدمج بآخر معدل، يحتفظ المخطط بسلسلة الفئات والتصنيفات الأصلية. هذا الاختلاف قد يتسبب في فشل [Chart::validateChartLayout](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chart/validatechartlayout/) مع خطأ فهرس خارج النطاق. قم بمسح السلاسل والتصنيفات الحالية قبل كتابة دفتر العمل المحدث مرة أخرى إلى المخطط.

```php
// بعد تعديل تدفق دفتر العمل (على سبيل المثال، باستخدام Aspose.Cells)
$updatedWorkbook = $chartData->readWorkbookStream();

// مسح مراجع البيانات الموجودة.
$chartData->getSeries()->clear();
$chartData->getCategories()->clear();

$chartData->writeWorkbookStream($updatedWorkbook);

$chart->validateChartLayout();
```

مسح المجموعات يضمن أن بنية بيانات المخطط متوافقة مع دفتر العمل الجديد، مما يسمح للـ `validateChartLayout` بإكمال العملية دون أخطاء.

## **تعيين خلية دفتر عمل كعنوان بيانات للمخطط**

1. إنشاء مثال من فئة [Presentation](https://apireference.aspose.com/slides/ar/php-java/aspose.slides/presentation).
2. الحصول على مرجع الشريحة عبر فهرستها.
3. إضافة مخطط فقاعي مع بعض البيانات.
4. الوصول إلى سلسلة المخطط.
5. تعيين خلية دفتر العمل كعنوان بيانات.
6. حفظ العرض.

يعرض هذا الكود PHP طريقة تعيين خلية دفتر عمل كعنوان بيانات للمخطط:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # ينشئ كائن فئة العرض الذي يمثل ملف عرض
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

يعرض هذا الكود PHP عملية يتم فيها استخدام طريقة [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdataworkbook/#getWorksheets) للوصول إلى مجموعة أوراق العمل:

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

يعرض هذا الكود PHP طريقة تحديد نوع لمصدر البيانات:

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

## **اكتشاف صيغ دفاتر العمل المدمجة غير المدعومة**

لا تدعم Aspose.Slides صيغة دفتر العمل الثنائي Excel (.xlsb) الذي يمكن دمجه في بعض المخططات. يمكنك استخدام طريقة `getEmbeddedWorkbookType` على [ChartData](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdata/) مع تعداد [WorkbookType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/workbooktype/) لاكتشاف الصيغ غير المدعومة وتخطي تلك المخططات.

```php
$presentation = new Presentation("sample.pptx");
try {
  $slide = $presentation->getSlides()->get_Item(0);
  $shapes = $slide->getShapes();

  for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
    $shape = $shapes->get_Item($shapeIndex);

    if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
      continue;
    }

    $chart = $shape;
    $chartData = $chart->getChartData();

    if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook &&
        java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro) {
      # دفتر العمل المدمج بتنسيق .xlsb غير مدعوم.
      continue;
    }

    # اقرأ أو عدّل بيانات دفتر عمل المخطط هنا.
  }
} finally {
  $presentation->dispose();
}
```

## **دفتر عمل خارجي**

تدعم Aspose.Slides دفاتر العمل الخارجية كمصدر بيانات للمخططات.

### **إنشاء دفتر عمل خارجي**

باستخدام طريقتي **`readWorkbookStream`** و **`setExternalWorkbook`**، يمكنك إما إنشاء دفتر عمل خارجي من الصفر أو تحويل دفتر عمل داخلي إلى خارجي.

يعرض هذا الكود PHP عملية إنشاء دفتر عمل خارجي:

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

باستخدام طريقة **`setExternalWorkbook`**، يمكنك تعيين دفتر عمل خارجي إلى مخطط كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار دفتر العمل الخارجي (في حال تم نقل الأخير).

على الرغم من عدم القدرة على تحرير البيانات في دفاتر العمل المخزنة في مواقع أو موارد عن بُعد، لا يزال بإمكانك استخدام مثل هذه الدفاتر كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لدفتر عمل خارجي، يتحول تلقائيًا إلى مسار كامل.

يعرض هذا الكود PHP طريقة تعيين دفتر عمل خارجي:

```php
  # ينشئ كائنًا من فئة Presentation
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

معامل `ChartData` (تحت طريقة `setExternalWorkbook`) يُستخدم لتحديد ما إذا كان سيتم تحميل دفتر عمل Excel أم لا.

* عندما تكون قيمة `ChartData` مضبوطة على `false`، يتم فقط تحديث مسار دفتر العمل—لن يتم تحميل بيانات المخطط أو تحديثها من دفتر العمل الهدف. قد ترغب في استخدام هذا الإعداد عندما يكون دفتر العمل الهدف غير موجود أو غير متاح.
* عندما تكون قيمة `ChartData` مضبوطة على `true`، تُحدَّث بيانات المخطط من دفتر العمل الهدف.

```php
  # ينشئ كائنًا من فئة Presentation
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

### **الحصول على مسار دفتر عمل مصدر البيانات الخارجي للمخطط**

1. إنشاء مثال من فئة [Presentation](https://apireference.aspose.com/slides/ar/php-java/aspose.slides/presentation).
2. الحصول على مرجع الشريحة عبر فهرستها.
3. إنشاء كائن لشكل المخطط.
4. إنشاء كائن لنوع المصدر (`ChartDataSourceType`) الذي يمثل مصدر بيانات المخطط.
5. تحديد الشرط المناسب بناءً على ما إذا كان نوع المصدر هو نفس نوع مصدر دفتر العمل الخارجي.

يعرض هذا الكود PHP العملية:

```php
  # ينشئ كائنًا من فئة Presentation
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

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تعدل بها محتويات دفاتر العمل الداخلية. عندما لا يمكن تحميل دفتر عمل خارجي، يتم إلقاء استثناء.

هذا الكود PHP هو تنفيذ العملية الموضحة:

```php
  # ينشئ كائنًا من فئة Presentation
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

### **استعادة دفتر عمل من ذاكرة المخطط المؤقتة**

إذا كان المخطط يستخدم دفتر عمل خارجي مفقود أو غير متاح، يمكن لـ Aspose.Slides إعادة بناء دفتر عمل المخطط من البيانات المخزنة مؤقتًا في العرض. أنشئ [LoadOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/)، قم بتهيئتها باستخدام [SpreadsheetOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/spreadsheetoptions/)، واستدعِ [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ar/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) مع القيمة `true` قبل فتح العرض.

المثال التالي بلغة PHP يفتح عرضًا يشير مخططه إلى دفتر عمل خارجي غير متاح ويصل إلى البيانات المستعادة عبر [Chart::getChartData](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chart/#getChartData) و[ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdata/#getChartDataWorkbook):

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # اقرأ أو عدّل بيانات دفتر العمل المستعاد هنا.
} finally {
    $presentation->dispose();
}
```

إذا كان دفتر العمل الخارجي غير متاح وتم تعطيل الاستعادة، تُلقي Aspose.Slides استثناءً. فعّل الاستعادة فقط عندما يكون استخدام بيانات المخطط المخزنة مؤقتًا كخيار بديل مقبولًا، لأن الذاكرة المؤقتة قد لا تحتوي على التغييرات التي أُجريت على دفتر العمل الخارجي بعد آخر تحديث للعرض.

## **الأسئلة الشائعة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًا بدفتر عمل خارجي أو مدمج؟**

نعم. يحتوي المخطط على [نوع مصدر البيانات](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdata/getdatasourcetype/) و[مسار إلى دفتر عمل خارجي](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdata/getexternalworkbookpath/); إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل يتم دعم المسارات النسبية إلى دفاتر العمل الخارجية، وكيف يتم تخزينها؟**

نعم. إذا حددت مسارًا نسبيًا، يتم تحويله تلقائيًا إلى مسار مطلق. وهذا مفيد لنقلية المشاريع؛ إلا أن العرض سيخزن المسار المطلق في ملف PPTX.

**هل يمكنني استخدام دفاتر عمل موجودة على موارد/مشاركات شبكة؟**

نعم، يمكن استخدام هذه الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يدعم Aspose.Slides تحرير دفاتر العمل البعيدة مباشرةً—يمكن استخدامها فقط كمصدر.

**هل يقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض؟**

لا. يخزن العرض [رابطًا إلى الملف الخارجي](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdata/getexternalworkbookpath/) ويستخدمه لقراءة البيانات. الملف الخارجي نفسه لا يتغير عند حفظ العرض.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

Aspose.Slides لا تقبل كلمة مرور عند الربط. عادةً ما يتم إزالة الحماية مسبقًا أو إعداد نسخة غير مشفّرة (على سبيل المثال باستخدام [Aspose.Cells](/cells/php-java/)) وربطها بهذه النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**

نعم. كل مخطط يخزن رابطه الخاص. إذا كانت جميع الروابط تشير إلى نفس الملف، فإن تحديث ذلك الملف سينعكس في كل مخطط عند تحميل البيانات مرة أخرى.