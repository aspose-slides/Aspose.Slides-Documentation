---
title: تخصيص مخططات الفقاعات في العروض التقديمية باستخدام PHP
linktitle: مخطط الفقاعات
type: docs
url: /ar/php-java/bubble-chart/
keywords:
- مخطط الفقاعات
- حجم الفقاعة
- تحجيم الحجم
- تمثيل الحجم
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء وتخصيص مخططات فقاعات قوية في PowerPoint باستخدام Aspose.Slides for PHP عبر Java لتعزيز تصور البيانات بسهولة."
---

## **تحجيم حجم مخطط الفقاعات**
توفر Aspose.Slides for PHP عبر Java دعمًا لتحجيم حجم مخطط الفقاعات. في Aspose.Slides for PHP عبر Java تم إضافة الطرق [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeries#getBubbleSizeScale--)، [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) و[**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) . تم إعطاء مثال توضيحي أدناه.
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
تم إضافة الطرق [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) و[**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) إلى واجهتي [IChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeries) و[IChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup) والفئات ذات الصلة. **BubbleSizeRepresentation** يحدد كيف يتم تمثيل قيم حجم الفقاعات في مخطط الفقاعات. القيم الممكنة هي: [**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Area) و[**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Width). بناءً على ذلك، تمت إضافة تعداد [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType) لتحديد الطرق الممكنة لتمثيل البيانات كأحجام مخطط الفقاعات. مثال على الشيفرة موضح أدناه.
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

**هل يتم دعم "مخطط الفقاعات مع تأثير ثلاثي الأبعاد"، وكيف يختلف عن المخطط العادي؟**
نعم. يوجد نوع مخطط منفصل، "Bubble with 3-D". يطبق نمطًا ثلاثي الأبعاد على الفقاعات ولكنه لا يضيف محورًا إضافيًا؛ تظل البيانات X-Y-S (الحجم). النوع متاح في فئة [chart type](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/).

**هل هناك حد لعدد السلاسل والنقاط في مخطط الفقاعات؟**
لا يوجد حد ثابت على مستوى API؛ يتم تحديد القيود بناءً على الأداء وإصدار PowerPoint المستهدف. يُنصح بالحفاظ على عدد النقاط معقولًا لتسهيل القراءة وسرعة التجسيد.

**كيف سيؤثر التصدير على مظهر مخطط الفقاعات (PDF، صور)؟**
يحافظ التصدير إلى الصيغ المدعومة على مظهر المخطط؛ يتم التجسيد عبر محرك Aspose.Slides. بالنسبة لصيغ الرسومات النقطية/المتجهة، تُطبق قواعد التجسيد العامة (الدقة، إزالة التسنن)، لذا يُفضَّل اختيار DPI كافٍ للطباعة.