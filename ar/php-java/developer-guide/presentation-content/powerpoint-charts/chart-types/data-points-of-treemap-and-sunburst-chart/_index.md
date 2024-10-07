---
title: نقاط البيانات في مخطط الشجرة ومخطط الشمس
type: docs
url: /php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords: "مخطط الشمس في Aspose.Slides لـ PHP عبر Java"
description: "مخطط الشمس، مخطط شمس، مخطط شمس، مخطط دائري، رسم دائري أو مخطط فطيرة متعدد المستويات مع Aspose.Slides لـ PHP عبر Java."
---

بين أنواع مخططات PowerPoint الأخرى، هناك نوعان "هرميان" - **مخطط الشجرة** و **مخطط الشمس** (المعروف أيضًا بمخطط الشمس، مخطط الشمس، مخطط دائري، رسم دائري أو مخطط فطيرة متعدد المستويات). تعرض هذه المخططات بيانات هرمية منظمة على شكل شجرة - من الأوراق إلى قمة الفرع. الأوراق تُعرف بواسطة نقاط البيانات في السلسلة، وكل مستوى تجميع متداخل يليه يُعرف بواسطة الفئة المقابلة. يسمح Aspose.Slides لـ PHP عبر Java بتنسيق نقاط البيانات في مخطط الشمس ومخطط الشجرة.

إليكم مخطط شمس، حيث تحدد البيانات في عمود Series1 العقد الورقية، بينما تحدد الأعمدة الأخرى نقاط البيانات الهرمية:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

لنبدأ بإضافة مخطط شمس جديد إلى العرض التقديمي:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" title="انظر أيضًا" %}} 
- [**إنشاء مخطط شمس**](/slides/php-java/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}


إذا كانت هناك حاجة لتنسيق نقاط البيانات في المخطط، يجب استخدام ما يلي:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevelsManager)، 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel) classes 
و [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPoint#getDataPointLevels--) method 
توفر الوصول لتنسيق نقاط البيانات في مخططات الشجرة ومخططات الشمس. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevelsManager)
تُستخدم للوصول إلى الفئات متعددة المستويات - فهي تمثل حاوية لـ
[**IChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel) objects.
أساسًا، هي غلاف لـ
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartCategoryLevelsManager) مع
الخصائص المضافة المحددة لنقاط البيانات. 
تحتوي فئة [**IChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel) على
طريقتين: [**getFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel#getFormat--) و 
[**getDataLabel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel#getLabel--) التي
تقدم الوصول إلى الإعدادات المقابلة.
## **عرض قيمة نقطة البيانات**
عرض قيمة نقطة البيانات "ورقة 4":

```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **تعيين علامة نقطة البيانات واللون**
تعيين علامة بيانات "الفرع 1" لتظهر اسم السلسلة ("Series1") بدلاً من اسم الفئة. ثم تحديد لون النص إلى الأصفر:

```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **تعيين لون فرع نقطة البيانات**
تغيير لون فرع "تبخير 4":

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
    $stem4branch = $dataPoints->get_Item(9)->getDataPointLevels()->get_Item(1);
    $stem4branch->getFormat()->getFill()->setFillType(FillType::Solid);
    $stem4branch->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)