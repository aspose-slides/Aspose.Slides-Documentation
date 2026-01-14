---
title: تخصيص مخططات الفقاعات في العروض التقديمية باستخدام PHP
linktitle: مخطط الفقاعات
type: docs
url: /ar/php-java/bubble-chart/
keywords:
- مخطط الفقاعات
- حجم الفقاعات
- تحجيم الحجم
- تمثيل الحجم
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء وتخصيص مخططات فقاعات قوية في PowerPoint باستخدام Aspose.Slides for PHP عبر Java لتعزيز تصور البيانات بسهولة."
---

## **تحجيم حجم مخطط الفقاعات**
توفر Aspose.Slides for PHP عبر Java دعمًا لتحجيم حجم مخطط الفقاعات. تمّت إضافة الطرق [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbubblesizescale/)، [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/getbubblesizescale/) و[**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setbubblesizescale/) في Aspose.Slides for PHP عبر Java. المثال العملي التالي مقدم.
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 100, 100, 400, 300);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeScale(150);
    $pres->save("Result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تمثيل البيانات كأحجام مخطط الفقاعات**
تمت إضافة الطرق [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setbubblesizerepresentation/) و[**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/getbubblesizerepresentation/) إلى الفئات [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/)، [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) والفئات المرتبطة. **BubbleSizeRepresentation** يحدد كيفية تمثيل قيم حجم الفقعات في المخطط. القيم الممكنة هي: [**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Area) و[**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Width). بناءً على ذلك، تم إضافة تعداد [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType) لتحديد الطرق الممكنة لتمثيل البيانات كأحجام مخطط الفقاعات. تم تقديم شفرة العينة أدناه.
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeRepresentation(BubbleSizeRepresentationType::Width);
    $pres->save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة الشائعة**

**هل يتم دعم "مخطط فقاعات مع تأثير ثلاثي الأبعاد"، وكيف يختلف عن المخطط العادي؟**

نعم. يوجد نوع مخطط منفصل يُدعى "Bubble with 3-D". يطبق تنسيقًا ثلاثي الأبعاد على الفقاعات لكنه لا يضيف محورًا إضافيًا؛ تظل البيانات X-Y-S (الحجم). يتوفر هذا النوع في فئة [chart type](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) .

**هل هناك حد لعدد السلاسل والنقاط في مخطط الفقاعات؟**

ليس هناك حد ثابت على مستوى API؛ يتم تحديد القيود بناءً على الأداء وإصدار PowerPoint المستهدف. يُنصح بالحفاظ على عدد النقاط معقولًا لتحسين قابلية القراءة وسرعة العرض.

**كيف سيؤثر التصدير على مظهر مخطط الفقاعات (PDF، الصور)؟**

يحافظ التصدير إلى الصيغ المدعومة على مظهر المخطط؛ يتم تنفيذ عملية الرسم بواسطة محرك Aspose.Slides. بالنسبة للصيغ النقطية/المتجهة، تُطبق قواعد الرسم العامة للرسوم البيانية (الدقة، مكافحة تموّج الحواف)، لذا يُنصح باختيار DPI كافٍ للطباعة.