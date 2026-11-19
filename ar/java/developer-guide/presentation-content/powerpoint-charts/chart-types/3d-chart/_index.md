---
title: تخصيص المخططات ثلاثية الأبعاد في العروض التقديمية باستخدام Java
linktitle: مخطط ثلاثي الأبعاد
type: docs
url: /ar/java/3d-chart/
keywords:
- مخطط ثلاثي الأبعاد
- دوران
- عمق
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "إنشاء مخططات ثلاثية الأبعاد في عروض PowerPoint التقديمية باستخدام Aspose.Slides for Java. تعديل الدوران، نسب الارتفاع، عمق المخطط، والمسافة بين السلاسل مع أمثلة Java."
---
## **نظرة عامة**

تتيح لك Aspose.Slides for Java تخصيص عرض مخطط ثلاثي الأبعاد عبر الطريقة [IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--) . توضح هذه المقالة كيفية تعديل الدوران، نسب الارتفاع، العمق، المحاور بزاوية قائمة، والمسافات بين السلاسل، ثم حفظ العرض التقديمي بتنسيق PPTX.

## **تعيين الدوران والعمق لمخطط ثلاثي الأبعاد**

المثال أدناه ينشئ [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ويستخدم [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) لإضافة مخطط عمودي ثلاثي الأبعاد مكدس إلى شريحته الأولى. يستبدل السلاسل والفئات الافتراضية بسلسلتين تحتوي كل منهما على ثلاثة قيم. يحدد فهرس ورقة العمل `0` ورقة البيانات الأولى للمخطط؛ الصف `0` يحتوي على أسماء السلاسل، والعمود `0` يحتوي على تسميات الفئات.

تحدد الطريقتان [setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) و[setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) دوران المخطط إلى 40 و270 درجة على التوالي. يضبط [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) عمقه إلى 150 % من عرضه، بينما يفعِّل [setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) المحاور بزاوية قائمة بدلاً من المنظور. يحتوي العرض التقديمي الناتج على المخطط المملوء بهذه إعدادات العرض ثلاثية الأبعاد.

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

استخدم [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) لتعيين ارتفاع المخطط ثلاثي الأبعاد كنسبة مئوية من عرضه. يغيّر ذلك نسب المشهد ثلاثي الأبعاد دون تغيير حجم كائن المخطط على الشريحة.

المثال التالي ينشئ مخطط [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) بالبيانات الافتراضية: ثلاث سلاسل وأربع فئات. يحفظ ثلاثة عروض تقديمية بنسب ارتفاع 50 %، 100 %، و200 %. يبقى موضع المخطط وعرضه وارتفاعه ثابتين. البيانات، الدوران، العمق، مسافة السلاسل، والتنسيق متطابقة في جميع الملفات الثلاثة؛ فقط نسبة الارتفاع تتغيّر.

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

الصور التالية توضح نفس إعدادات الارتفاع في المثال النظير لـ .NET وتم تصديرها باستخدام Microsoft PowerPoint. النسبة الأصغر تنتج مشهداً أكثر تسطحاً، بينما النسبة الأكبر تنتج مشهداً أعلى داخل نفس كائن المخطط. قد يضبط PowerPoint أيضًا فواصل علامات المحور ومواقع التسميات لتتناسب مع المشهد.

| الارتفاع: 50% | الارتفاع: 100% | الارتفاع: 200% |
| --- | --- | --- |
| ![مخطط عمودي ثلاثي الأبعاد بارتفاع محدد بنسبة 50٪ من عرضه](height_percent_50.png) | ![مخطط عمودي ثلاثي الأبعاد بارتفاع محدد بنسبة 100٪ من عرضه](height_percent_100.png) | ![مخطط عمودي ثلاثي الأبعاد بارتفاع محدد بنسبة 200٪ من عرضه](height_percent_200.png) |

هذه الطرق تتحكم في جوانب مختلفة من المخطط:

| الطريقة | التأثير |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | ارتفاع المشهد ثلاثي الأبعاد كنسبة مئوية من عرضه. |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | ارتفاع كائن المخطط على الشريحة، بالنقاط. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | عمق المشهد ثلاثي الأبعاد كنسبة مئوية من عرضه. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | المسافة بين السلاسل على محور العمق، كنسبة مئوية من عرض العلامة. |

إعداد الارتفاع يؤثر على المخططات العمودية والشريطية ثلاثية الأبعاد، بما في ذلك المتغيرات الأسطوانية، المخروطية، والهرمية، بالإضافة إلى المخططات الخطية، المساحية، الدائرية، والسطحية ثلاثية الأبعاد. المقارنة أعلاه تستخدم النوع المؤكد `Column3D`. الإعداد لا يغيّر مظهر مخطط `ClusteredColumn` ثنائي الأبعاد أو مخطط `BubbleWith3D`؛ هذه الأسماء هي أعضاء فئة [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). للحصول على إعدادات مظهر أخرى للمخططات، راجع [Chart Formatting](/slides/ar/java/chart-formatting/).

## **ضبط الفجوة بين السلاسل**

استخدم [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) للتحكم في المسافة بين سلاسل البيانات على محور العمق في مخطط ثلاثي الأبعاد، معبرًا عنها كنسبة مئوية من عرض العلامة. استخدم قيمًا من **0 إلى 500** شاملة: `0` يزيل الفجوة، بينما القيم الأكبر تزيد المسافة. مع عمق مخطط ثابت، زيادة الفجوة تجعل العلامات أرق على محور العمق.

الوصول إلى المجموعة يتم عبر [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) . يطبق الإعداد على كل السلاسل في تلك المجموعة، لا على السلسلة المستخدمة للوصول فقط. تُعيد [IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) الفجوة العمقية وتعكس إعداد المجموعة الأصلية.

هذا الإعداد يؤثر على المخططات العمودية والشريطية ثلاثية الأبعاد، بما في ذلك المتغيرات الأسطوانية، المخروطية، والهرمية، بالإضافة إلى المخططات الخطية والمساحية ثلاثية الأبعاد. يعتمد المظهر على ما إذا كانت السلاسل مرتبة في العمق، موزعة، أو مكدسة. للمقارنة الواضحة بين الفجوات بين السلاسل المنفصلة، استخدم `ChartType.Column3D` من فئة [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/).

هذه الطرق تتحكم في جوانب مختلفة من المخطط:

| الطريقة | التأثير |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | المسافة بين السلاسل على محور العمق، كنسبة مئوية من عرض العلامة. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | المسافة بين مجموعات الأعمدة أو الأشجار المتجاورة، كنسبة مئوية من عرض العمود أو الشريط. |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | عمق المخطط الكلي، كنسبة مئوية من عرض المخطط. |

المثال المستقل التالي يستخدم بيانات المخطط الافتراضية، التي تحتوي على ثلاث سلاسل وأربع فئات. يحفظ عرضين تقديميين ببيانات، دوران، عرض فجوة، وعمق مخطط متطابقين؛ فقط فجوة العمق تتغيّر.

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

الصور التالية توضح نفس إعدادات فجوة العمق في المثال النظير لـ .NET وتم تصديرها باستخدام Microsoft PowerPoint.

| فجوة العمق: 0% | فجوة العمق: 500% |
| --- | --- |
| ![مخطط عمودي ثلاثي الأبعاد بدون فجوة بين السلاسل على محور العمق](gap_depth_0.png) | ![مخطط عمودي ثلاثي الأبعاد بفجوة 500٪ بين السلاسل على محور العمق](gap_depth_500.png) |

## **تغيير نوع السلسلة ثلاثية الأبعاد وشكل الشريط**

في مخطط أسطواني مجموع، يبدأ السلسلة الأولى بشكل شريط أسطواني. يطبع المثال القيم الصحيحة التي تُرجعها [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) و[IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) قبل وبعد كل تغيير. الجدول يوضح أسماء الثوابت المقابلة.

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

| تغيير إلى السلسلة الأولى | نوع السلسلة | شكل الشريط |
| --- | --- | --- |
| إنشاء المخطط | `ClusteredCylinder` | `Cylinder` |
| تعيين نوع السلسلة إلى `ClusteredCone` | `ClusteredCone` | `Cone` |
| تعيين شكل الشريط إلى `Box` | `ClusteredColumn3D` | `Box` |

تغيير الشكل إلى `Box` يغيّر أيضًا نوع السلسلة إلى `ClusteredColumn3D`. إذا كان رمزك يتفرع بناءً على نوع السلسلة، استدعِ `series.getType()` بعد تغيير الشكل. القيمة المخزنة مسبقًا قبل التعيين ستظل تختار الفَرع `ClusteredCone`.

![مقارنة PowerPoint تُظهر السلسلة الأولى كأسطوانات، مخاريط، وأعمدة مستطيلة من اليسار إلى اليمين](series-shapes.png)

## **الأسئلة المتكررة**

**ما أنواع المخططات التي تدعم وضع ثلاثي الأبعاد في Aspose.Slides؟**

يدعم Aspose.Slides المتغيرات ثلاثية الأبعاد للمخططات العمودية، بما في ذلك Column 3D، Clustered Column 3D، Stacked Column 3D، و100 % Stacked Column 3D، إلى جانب الأنواع الثلاثية الأبعاد المرتبطة التي تُعرض عبر فئة [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). للحصول على قائمة دقيقة ومُحدَّثة، راجع أعضاء [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) في مرجع API للإصدار المثبت لديك.

**هل يمكنني الحصول على صورة نقطية لمخطط ثلاثي الأبعاد لتقرير أو للويب؟**

نعم. يمكنك تصدير مخطط إلى صورة باستخدام [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) أو [تصدير الشريحة بالكامل](/slides/ar/java/convert-powerpoint-to-png/) إلى صيغ مثل PNG أو JPEG. هذا مفيد عندما تحتاج إلى معاينة نقطية أو تريد تضمين المخطط في مستندات، لوحات معلومات، أو صفحات ويب دون الحاجة إلى PowerPoint.

**ما مدى أداء بناء وعرض المخططات ثلاثية الأبعاد الكبيرة؟**

الأداء يعتمد على حجم البيانات وتعقيد الرسوم. للحصول على أفضل النتائج، حافظ على الحد الأدنى من التأثيرات ثلاثية الأبعاد، تجنّب القوام الثقيلة على الجدران ومساحات الرسم، قلل عدد نقاط البيانات لكل سلسلة إن أمكن، وقم بالعرض إلى حجم إخراج ملائم (الدقة والأبعاد) لتتناسب مع شاشة العرض أو متطلبات الطباعة.