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
description: "إنشاء مخططات ثلاثية الأبعاد في عروض PowerPoint التقديمية باستخدام Aspose.Slides for Java. تعديل الدوران، نسب الارتفاع، عمق المخطط، والمسافة بين السلاسل باستخدام أمثلة Java."
---
## **نظرة عامة**

Aspose.Slides for Java يتيح لك تخصيص عرض مخطط ثلاثي الأبعاد من خلال الطريقة [IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--) . توضح هذه المقالة كيفية تعديل الدوران، نسب الارتفاع، العمق، المحاور بزاوية قائمة، والمسافة بين السلاسل، ثم حفظ العرض التقديمي بتنسيق PPTX.

## **ضبط الدوران والعمق لمخطط ثلاثي الأبعاد**

المثال أدناه ينشئ [عرض تقديمي](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ويستخدم [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) لإضافة مخطط عمودي ثلاثي الأبعاد مكدس إلى شريحته الأولى. يستبدل السلاسل والفئات الافتراضية بسلسلتين يحتوي كل منهما على ثلاثة قيم. فهرس ورقة العمل `0` يحدد أول ورقة بيانات للمخطط؛ الصف `0` يحمل أسماء السلاسل، والعمود `0` يحمل تسميات الفئات.

تقوم الطريقتان [setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) و [setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) بتعيين دوران المخطط إلى 40 و 270 درجة على التوالي. تقوم [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) بتعيين عمقه إلى 150% من عرضه، بينما تقوم [setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) بتمكين المحاور بزاوية قائمة بدلاً من المنظور. يحتوي العرض التقديمي الناتج على المخطط المملوء بهذه إعدادات العرض ثلاثية الأبعاد.

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

## **تطبيق تعبئة صورة على سطح مخطط ثلاثي الأبعاد**

المخطط ثلاثي الأبعاد يحتوي على ثلاثة أسطح يمكنك تعبئتها بشكل مستقل: [side wall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getSideWall--), [back wall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--), و [floor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--) . اضبط [fill type](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) إلى `Picture` وعيّن صورة. اضبط كل من [picture fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) و[picture type](https://reference.aspose.com/slides/java/com.aspose.slides/ichartwall/#setPictureType-int-) إلى `Stretch` لتلائم نسخة واحدة من الصورة عبر السطح.

احفظ [arrow.png](arrow.png) في دليل العمل. يقوم المثال بتدوير المخطط ويرفع القيمة القصوى على المحور العمودي بحيث تكون الأرضية مرئية بين الأعمدة. ثم يستنسخ الشريحة مرتين ويطبق السهم على سطح مختلف في كل شريحة. تحتفظ جميع المخططات الثلاثة بنفس البيانات، زاوية العرض، والخلفية.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    ISlide backSlide = presentation.getSlides().addClone(slide);
    ISlide floorSlide = presentation.getSlides().addClone(slide);
    IChart backChart = (IChart) backSlide.getShapes().get_Item(0);
    IChart floorChart = (IChart) floorSlide.getShapes().get_Item(0);

    byte[] imageBytes = Files.readAllBytes(Paths.get("arrow.png"));
    IPPImage arrow = presentation.getImages().addImage(imageBytes);

    IChartWall[] surfaces = { chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor() };
    for (IChartWall surface : surfaces) {
        IFillFormat fill = surface.getFormat().getFill();
        fill.setFillType(FillType.Picture);
        fill.getPictureFillFormat().getPicture().setImage(arrow);
        fill.getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
        surface.setPictureType(PictureType.Stretch);
    }

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يعرض Microsoft PowerPoint الشرائح الثلاثة كما يلي.

| الجدار الجانبي | الجدار الخلفي | الأرضية |
| --- | --- | --- |
| ![سهم يشير إلى داخل المخطط على الجدار الجانبي](side-wall.png) | ![سهم يشير إلى اليمين عبر الجدار الخلفي](back-wall.png) | ![سهم يشير إلى اليمين عبر الأرضية بين الأعمدة](floor.png) |

## **ضبط نسب ارتفاع مخطط ثلاثي الأبعاد**

استخدم [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) لتعيين ارتفاع مخطط ثلاثي الأبعاد كنسبة مئوية من عرضه. هذا يغيّر نسب المشهد ثلاثي الأبعاد دون تغيير حجم كائن المخطط على الشريحة.

المثال التالي ينشئ مخطط [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) بالبيانات الافتراضية: ثلاث سلاسل وأربع فئات. يحفظ ثلاث عروض تقديمية بنسب ارتفاع 50%، 100%، و200%. يظل موضع المخطط وعرضه وارتفاعه ثابتًا. البيانات، الدوران، العمق، تباعد السلاسل، والتنسيق متطابقة في جميع الملفات الثلاثة؛ فقط نسبة الارتفاع تتغيّر.

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

الصور التالية توضح نفس إعدادات الارتفاع في المثال المكافئ لـ .NET وقد تم تصديرها باستخدام Microsoft PowerPoint. النسبة الأقل ينتج مشهدًا أكثر تسطحًا، بينما النسبة الأكبر ينتج مشهدًا أعلى داخل نفس كائن المخطط. قد يقوم PowerPoint أيضًا بضبط فواصل علامات المحور ومواقع التسميات لتلائم المشهد.

| الارتفاع: 50% | الارتفاع: 100% | الارتفاع: 200% |
| --- | --- | --- |
| ![مخطط عمود ثلاثي الأبعاد بارتفاع يساوي 50٪ من عرضه](height_percent_50.png) | ![مخطط عمود ثلاثي الأبعاد بارتفاع يساوي 100٪ من عرضه](height_percent_100.png) | ![مخطط عمود ثلاثي الأبعاد بارتفاع يساوي 200٪ من عرضه](height_percent_200.png) |

هذه الطرق تتحكم في جوانب مختلفة من المخطط:

| الطريقة | التأثير |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | ارتفاع المشهد ثلاثي الأبعاد كنسبة مئوية من عرضه. |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | ارتفاع كائن المخطط على الشريحة، بالنقاط. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | عمق المشهد ثلاثي الأبعاد كنسبة مئوية من عرضه. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | التباعد بين السلاسل على محور العمق، كنسبة مئوية من عرض العلامة. |

إعداد الارتفاع يؤثر على مخططات الأعمدة والشرائط ثلاثية الأبعاد، بما في ذلك المتغيرات الأسطوانية، المخروطية، والهرمية، وكذلك المخططات الخطية، المساحية، الدائرية، والسطحية ثلاثية الأبعاد. المقارنة أعلاه تستخدم النوع المؤكد `Column3D`. لا يغيّر الإعداد مظهر مخطط `ClusteredColumn` ثنائي الأبعاد أو مخطط `BubbleWith3D`؛ هذه الأسماء هي أعضاء في فئة [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). لإعدادات مظهر أخرى للمخططات، راجع [Chart Formatting](/slides/ar/java/chart-formatting/).

## **ضبط الفجوة بين السلاسل**

استخدم [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) للتحكم في المسافة بين سلاسل البيانات على محور العمق في مخطط ثلاثي الأبعاد، معبرًا عنها كنسبة مئوية من عرض العلامة. استخدم قيمًا من **0 إلى 500** شاملة: `0` يزيل الفجوة، بينما القيم الأكبر تزيد التباعد. مع عمق مخطط ثابت، زيادة الفجوة تجعل العلامات أرفع على محور العمق.

الوصول إلى المجموعة يتم عبر [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--). الإعداد ينطبق على كل سلسلة في تلك المجموعة، وليس فقط السلسلة المستخدمة للوصول إليها. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) يعيد فجوة العمق ويعكس إعداد المجموعة الأصلية.

هذا الإعداد يؤثر على مخططات الأعمدة والشرائط ثلاثية الأبعاد، بما في ذلك المتغيرات الأسطوانية، المخروطية، والهرمية، وكذلك المخططات الخطية والمساحية ثلاثية الأبعاد. يعتمد المظهر على ما إذا كانت السلاسل مرتبة في العمق، متجمعة، أو مكدسة. للمقارنة الواضحة للفجوات بين سلاسل منفصلة، استخدم `ChartType.Column3D` من فئة [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/).

| الطريقة | التأثير |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | التباعد بين السلاسل على محور العمق، كنسبة مئوية من عرض العلامة. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | التباعد بين مجموعات الأعمدة أو الشرائط المتجاورة، كنسبة مئوية من عرض العمود أو الشريط. |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | عمق المخطط الكلي، كنسبة مئوية من عرض المخطط. |

المثال التالي المستقل يستخدم البيانات الافتراضية للمخطط، التي تحتوي على ثلاث سلاسل وأربع فئات. يحفظ عرضين تقديميين ببيانات، دوران، عرض فجوة، وعمق مخطط متطابقة؛ فقط فجوة العمق تتغيّر.

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

الصور التالية توضح نفس إعدادات فجوة العمق في المثال المكافئ لـ .NET وقد تم تصديرها باستخدام Microsoft PowerPoint.

| عمق الفجوة: 0% | عمق الفجوة: 500% |
| --- | --- |
| ![مخطط عمود ثلاثي الأبعاد بدون فجوة بين السلاسل على محور العمق](gap_depth_0.png) | ![مخطط عمود ثلاثي الأبعاد بفجوة 500٪ بين السلاسل على محور العمق](gap_depth_500.png) |

## **تغيير نوع السلسلة ثلاثية الأبعاد وشكل العمود**

في مخطط أسطوانة متجمعة، تبدأ السلسلة الأولى بشكل عمود أسطواني. يطبع المثال القيم الصحيحة التي تعيدها [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) و[IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) قبل وبعد كل تعديل. الجدول يعطي أسماء الثوابت المقابلة.

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

| تغيير السلسلة الأولى | نوع السلسلة | شكل العمود |
| --- | --- | --- |
| إنشاء المخطط | `ClusteredCylinder` | `Cylinder` |
| تعيين نوع السلسلة إلى `ClusteredCone` | `ClusteredCone` | `Cone` |
| تعيين شكل العمود إلى `Box` | `ClusteredColumn3D` | `Box` |

تعيين الشكل إلى `Box` يغيّر أيضًا نوع السلسلة إلى `ClusteredColumn3D`. إذا كان الكود يفرع بناءً على نوع السلسلة، استدعِ `series.getType()` بعد تغيير الشكل. القيمة المخزنة قبل التعيين ستظل تختار الفَرع `ClusteredCone`.

![مقارنة PowerPoint تُظهر السلسلة الأولى كأسطوانات، مخاريط، وأعمدة مستطيلة من اليسار إلى اليمين](series-shapes.png)

## **FAQ**

**ما أنواع المخططات التي تدعم وضع ثلاثي الأبعاد في Aspose.Slides؟**

Aspose.Slides يدعم المتغيّرات ثلاثية الأبعاد من المخططات العمودية، بما في ذلك Column 3D، Clustered Column 3D، Stacked Column 3D، و100 % Stacked Column 3D، بالإضافة إلى الأنواع الثلاثية الأبعاد ذات الصلة المعروضة عبر فئة [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). للحصول على قائمة دقيقة ومحدّثة، تحقق من أعضاء [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) في مرجع API للإصدار المثبت لديك.

**هل يمكنني الحصول على صورة نقطية لمخطط ثلاثي الأبعاد لتقرير أو للويب؟**

نعم. يمكنك تصدير المخطط إلى صورة باستخدام [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) أو [تحويل الشريحة بالكامل](/slides/ar/java/convert-powerpoint-to-png/) إلى صيغ مثل PNG أو JPEG. هذا مفيد عندما تحتاج إلى معاينة نقطية أو تريد تضمين المخطط في مستندات، لوحات معلومات، أو صفحات ويب دون الحاجة إلى PowerPoint.

**ما مدى أداء بناء وعرض المخططات الثلاثية الأبعاد الكبيرة؟**

يعتمد الأداء على حجم البيانات وتعقيد العرض. للحصول على أفضل النتائج، حافظ على الحد الأدنى من التأثيرات الثلاثية الأبعاد، تجنّب القوام الثقيلة على الجدران ومساحات الرسم، حدّ من عدد نقاط البيانات لكل سلسلة إن أمكن، وابدأ الإخراج بحجم ودقة مناسبين للعرض أو الطباعة المستهدف.