---
title: تخصيص المخططات ثلاثية الأبعاد في العروض التقديمية على Android
linktitle: مخطط 3D
type: docs
url: /ar/androidjava/3d-chart/
keywords:
- مخطط 3D
- الدوران
- العمق
- PowerPoint
- العرض التقديمي
- Android
- Java
- Aspose.Slides
description: "إنشاء مخططات ثلاثية الأبعاد في عروض PowerPoint التقديمية باستخدام Aspose.Slides for Android عبر Java. تعديل الدوران، نسب الارتفاع، عمق المخطط، والمسافات بين السلاسل مع أمثلة Java."
---
## **نظرة عامة**

Aspose.Slides for Android عبر Java يتيح لك تخصيص عرض مخطط ثلاثي الأبعاد من خلال الطريقة [IChart.getRotation3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getRotation3D--) . توضح هذه المقالة كيفية تعديل الدوران، نسب الارتفاع، العمق، المحاور بزاوية قائمة، والمسافات بين السلاسل، ثم حفظ العرض التقديمي بتنسيق PPTX.

## **ضبط الدوران والعمق لمخطط ثلاثي الأبعاد**

المثال أدناه ينشئ كائنًا من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ويستخدم [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) لإضافة مخطط عمودي ثلاثي الأبعاد مكدس إلى الشريحة الأولى. يستبدل السلاسل والفئات الافتراضية بسلسلتين تحتوي كل منهما على ثلاث قيم. يُحدد فهرس ورقة العمل `0` ورقة البيانات الأولى للمخطط؛ الصف `0` يحمل أسماء السلاسل، والعمود `0` يحمل تسميات الفئات.

الطريقة [setRotationX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationX-byte-) والطريقة [setRotationY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationY-int-) تضبطان دوران المخطط إلى 40 و270 درجة على التوالي. الطريقة [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) تعين عمق المخطط إلى 150٪ من عرضه، بينما تمكّن [setRightAngleAxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) المحاور بزاوية قائمة بدلاً من المنظور. يحتوي العرض التقديمي الناتج على المخطط المملوء بهذه الإعدادات ثلاثية الأبعاد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    double[][] values = { { 20, 50, 30 }, { 30, 10, 60 } };

    for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (int seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ضبط نسب ارتفاع المخطط ثلاثي الأبعاد**

استخدم [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) لتعيين ارتفاع المخطط ثلاثي الأبعاد كنسبة مئوية من عرضه. يغيّر ذلك نسب المشهد ثلاثي الأبعاد دون تعديل حجم كائن المخطط على الشريحة.

المثال التالي ينشئ مخططًا من النوع [Column3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) بالبيانات الافتراضية: ثلاث سلاسل وأربع فئات. يحفظ ثلاث عروض تقديمية بنسب ارتفاع 50٪ و100٪ و200٪. يبقى موضع المخطط وعرضه وارتفاعه ثابتًا. البيانات، والدوران، والعمق، والمسافات بين السلاسل، والتنسيق هي نفسها في جميع الملفات الثلاثة؛ يتغيّر فقط نسبة الارتفاع.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (int heightPercent : new int[] { 50, 100, 200 }) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

الصورة التالية توضح نفس إعدادات الارتفاع في المثال المقابل على .NET وتم تصديرها باستخدام Microsoft PowerPoint. النسبة الأصغر تنتج مشهدًا أكثر مسطّحًا، بينما النسبة الأكبر تنتج مشهدًا أعلى داخل نفس كائن المخطط. قد يقوم PowerPoint أيضًا بتعديل فواصل تكرار المحاور وضع العلامات لتلائم المشهد.

| الارتفاع: 50% | الارتفاع: 100% | الارتفاع: 200% |
| --- | --- | --- |
| ![مخطط عمودي ثلاثي الأبعاد بارتفاع يساوي 50٪ من عرضه](height_percent_50.png) | ![مخطط عمودي ثلاثي الأبعاد بارتفاع يساوي 100٪ من عرضه](height_percent_100.png) | ![مخطط عمودي ثلاثي الأبعاد بارتفاع يساوي 200٪ من عرضه](height_percent_200.png) |

هذه الطرق تتحكم في جوانب مختلفة من المخطط:

| الطريقة | التأثير |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) | ارتفاع المشهد ثلاثي الأبعاد كنسبة مئوية من عرضه. |
| [IChart.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setHeight-float-) | ارتفاع كائن المخطط على الشريحة، بوحدات النقاط. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | عمق المشهد ثلاثي الأبعاد كنسبة مئوية من عرضه. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | المسافة بين السلاسل على محور العمق، كنسبة مئوية من عرض العلامة. |

إعداد الارتفاع يؤثر على المخططات العمودية والعمودية الثلاثية الأبعاد، بما فيها المتغيّرات الاسطوانية والهادلية والهرمية، وكذلك مخططات الخط الثلاثي الأبعاد، والمساحة، والفطيرة، والسطح. المقارنة أعلاه تستخدم النوع المؤكد `Column3D`. الإعداد لا يغيّر مظهر مخطط `ClusteredColumn` ثنائي الأبعاد أو مخطط `BubbleWith3D`؛ هذه الأسماء هي أعضاء فئة [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). لإعدادات مظهر أخرى للمخططات، راجع [Chart Formatting](/slides/ar/androidjava/chart-formatting/).

## **ضبط الفجوة بين السلاسل**

استخدم [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) للتحكم في المسافة بين سلاسل البيانات على محور العمق في مخطط ثلاثي الأبعاد، معبرًا عنها كنسبة مئوية من عرض العلامة. استخدم قيمًا من **0 إلى 500** شاملة: `0` يزيل الفجوة، بينما القيم الأكبر تزيد المسافة. مع عمق مخطط ثابت، زيادة الفجوة تجعل العلامات أرفع على محور العمق.

يمكن الوصول إلى المجموعة عبر [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--). الإعداد يُطبق على كل سلسلة في تلك المجموعة، وليس فقط السلسلة المستخدمة للوصول إليها. الطريقة [IChartSeries.getGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getGapDepth--) تُعيد الفجوة العمقية وتعكس إعداد المجموعة الأصلية.

هذا الإعداد يؤثر على المخططات العمودية والعمودية الثلاثية الأبعاد، بما فيها المتغيّرات الاسطوانية والهادلية والهرمية، وكذلك مخططات الخط والمساحة الثلاثية الأبعاد. المظهر يعتمد على ما إذا كانت السلاسل مرتبة في العمق، أو متجمّعة، أو مكدسة. للمقارنة الواضحة للفجوات بين السلاسل المنفصلة، استخدم `ChartType.Column3D` من فئة [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/).

هذه الطرق تتحكم في جوانب مختلفة من المخطط:

| الطريقة | التأثير |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | المسافة بين السلاسل على محور العمق، كنسبة مئوية من عرض العلامة. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | المسافة بين مجموعات الأعمدة أو الأشرطة المتجاورة، كنسبة مئوية من عرض العمود أو الشريط. |
| [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | العمق الكلي للمخطط، كنسبة مئوية من عرض المخطط. |

المثال التالي المتكامل يستخدم بيانات المخطط الافتراضية التي تحتوي على ثلاث سلاسل وأربع فئات. يحفظ عرضين تقديميين ببيانات ودوران وعرض فجوة وعمق مخطط متطابقة؛ يتغيّر فقط عمق الفجوة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartSeriesGroup group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (int gapDepth : new int[] { 0, 500 }) {
        group.setGapDepth(gapDepth);

        String fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

الصورة التالية توضح نفس إعدادات عمق الفجوة في المثال المقابل على .NET.

| عمق الفجوة: 0% | عمق الفجوة: 500% |
| --- | --- |
| ![مخطط عمودي ثلاثي الأبعاد لا يحتوي على فجوة بين السلاسل على محور العمق](gap_depth_0.png) | ![مخطط عمودي ثلاثي الأبعاد بفجوة 500٪ بين السلاسل على محور العمق](gap_depth_500.png) |

## **تغيير نوع السلسلة ثلاثية الأبعاد وشكل العمود**

في مخطط اسطواني متجمّع، تبدأ السلسلة الأولى بشكل عمود أسطواني. يطبع المثال القيم الصحيحة التي تُرجعها [IChartSeries.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getType--) و[IChartSeries.getBar3DShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getBar3DShape--) قبل وبعد كل تغيير. يوفّر الجدول الأسماء الثابتة المقابلة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setType(ChartType.ClusteredCone);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(ChartShapeType.Box);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| التغيير في السلسلة الأولى | نوع السلسلة | شكل العمود |
| --- | --- | --- |
| إنشاء المخطط | `ClusteredCylinder` | `Cylinder` |
| ضبط نوع السلسلة إلى `ClusteredCone` | `ClusteredCone` | `Cone` |
| ضبط شكل العمود إلى `Box` | `ClusteredColumn3D` | `Box` |

تغيير الشكل إلى `Box` يغيّر أيضًا نوع السلسلة إلى `ClusteredColumn3D`. إذا كان كودك يتفرع بناءً على نوع السلسلة، استدعِ `series.getType()` بعد تغيير الشكل. القيمة المخزنة مسبقًا قبل التعيين ستظل تختار فرع `ClusteredCone`.

![مقارنة PowerPoint تُظهر السلسلة الأولى كأسطوانات، ثم مخاريط، ثم أعمدة مستطيلة من اليسار إلى اليمين](series-shapes.png)

## **الأسئلة المتكررة**

**ما هي أنواع المخططات التي تدعم وضع 3D في Aspose.Slides؟**

Aspose.Slides يدعم المتغيّرات الثلاثية الأبعاد لأنواع المخططات العمودية، بما في ذلك Column 3D، Clustered Column 3D، Stacked Column 3D، و100% Stacked Column 3D، إلى جانب الأنواع الثلاثية الأبعاد المرتبطة التي تُعرّف عبر فئة [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). للحصول على قائمة دقيقة ومحدّثة، تحقق من أعضاء فئة [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) في مرجع API للإصدار المثبّت لديك.

**هل يمكنني الحصول على صورة نقطية لمخطط 3D لتقرير أو للويب؟**

نعم. يمكنك تصدير المخطط إلى صورة باستخدام [Shape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) أو [تحويل الشريحة بالكامل](/slides/ar/androidjava/convert-powerpoint-to-png/) إلى صيغ مثل PNG أو JPEG. هذا مفيد عندما تحتاج إلى معاينة نقطية أو ترغب في تضمين المخطط في مستندات أو لوحات معلومات أو صفحات ويب دون الحاجة إلى PowerPoint.

**ما مدى أداء بناء وعرض المخططات الثلاثية الأبعاد الكبيرة؟**

يعتمد الأداء على حجم البيانات وتعقّب العناصر البصرية. للحصول على أفضل النتائج، حافظ على الحد الأدنى من التأثيرات الثلاثية الأبعاد، وتجنّب القوام الثقيلة على الجدران ومساحات الرسم، وقلل عدد نقاط البيانات لكل سلسلة قدر الإمكان، وقم بالعرض بدقة وأبعاد مناسبة لتلائم شاشة العرض أو الطباعة المطلوبة.