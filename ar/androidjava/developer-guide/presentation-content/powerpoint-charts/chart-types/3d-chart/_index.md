---
title: تخصيص المخططات ثلاثية الأبعاد في العروض التقديمية على Android
linktitle: مخطط ثلاثي الأبعاد
type: docs
url: /ar/androidjava/3d-chart/
keywords:
- مخطط ثلاثي الأبعاد
- دوران
- عمق
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إنشاء مخططات ثلاثية الأبعاد في عروض PowerPoint التقديمية باستخدام Aspose.Slides for Android عبر Java. ضبط الدوران، نسب الارتفاع، عمق المخطط، والمسافات بين السلاسل باستخدام أمثلة Java."
---
## **نظرة عامة**

Aspose.Slides for Android عبر Java يتيح لك تخصيص عرض مخطط ثلاثي الأبعاد من خلال الطريقة [IChart.getRotation3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getRotation3D--) . توضح هذه المقالة كيفية تعديل الدوران، نسب الارتفاع، العمق، المحاور ذات الزاوية القائمة، والمسافات بين السلاسل، ثم حفظ العرض التقديمي بصيغة PPTX.

## **تعيين الدوران والعمق لمخطط ثلاثي الأبعاد**

المثال أدناه ينشئ [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ويستخدم [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) لإضافة مخطط عمودي ثلاثي الأبعاد مكدس إلى الشريحة الأولى. يتم استبدال السلاسل والفئات الافتراضية بسلسلتين تحتوي كل منهما على ثلاثة قيم. يشير فهرس ورقة العمل `0` إلى ورقة البيانات الأولى للمخطط؛ الصف `0` يحتفظ بأسماء السلاسل، والعمود `0` يحتوي على تسميات الفئات.

تقوم الطريقتان [setRotationX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationX-byte-) و[setRotationY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationY-int-) بتعيين دوران المخطط إلى 40 و270 درجة على التوالي. تقوم [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) بتعيين عمقه إلى 150 % من عرضه، بينما تمكّن [setRightAngleAxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) المحاور بزاوية قائمة بدلاً من المنظور. يحتوي العرض التقديمي الناتج على المخطط المملوء بهذه الإعدادات الثلاثية الأبعاد.

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

لمخطط ثلاثي الأبعاد ثلاثة أسطح يمكنك تعبئتها بشكل مستقل: [side wall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getSideWall--)، و[back wall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getBackWall--)، و[floor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getFloor--) . اضبط [fill type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) للسطح إلى `Picture` وعيّن صورة. اضبط كلًا من [picture fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) و[picture type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartwall/#setPictureType-int-) للسطح إلى `Stretch` لتطابق نسخة واحدة من الصورة على السطح.

احفظ [arrow.png](arrow.png) في دليل العمل. يقوم المثال بدوران المخطط ورفع القيمة القصوى على المحور الرأسي بحيث يصبح الأرضية مرئية بين الأعمدة. ثم ينسخ الشريحة مرتين ويطبق السهم على سطح مختلف في كل شريحة. تحتفظ جميع المخططات الثلاثة بنفس البيانات، زاوية الرؤية، والخلفية.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try (FileInputStream image = new FileInputStream("arrow.png")) {
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

    IPPImage arrow = presentation.getImages().addImage(image);

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

يعرض Microsoft PowerPoint الشرائح الثلاث كما يلي.

| الجدار الجانبي | الجدار الخلفي | الأرضية |
| --- | --- | --- |
| ![سهم يشير إلى المخطط على طول الجدار الجانبي](side-wall.png) | ![سهم يشير إلى اليمين عبر الجدار الخلفي](back-wall.png) | ![سهم يشير إلى اليمين عبر الأرضية بين الأعمدة](floor.png) |

## **ضبط نسب ارتفاع مخطط ثلاثي الأبعاد**

استخدم [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) لتعيين ارتفاع مخطط ثلاثي الأبعاد كنسبة مئوية من عرضه. يغيّر ذلك نسب المشهد الثلاثي الأبعاد دون تعديل حجم كائن المخطط على الشريحة.

المثال التالي ينشئ مخطط [Column3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) بالبيانات الافتراضية: ثلاث سلاسل وأربعة فئات. يحفظ ثلاثة عروض تقديمية بنسب ارتفاع 50 %، 100 %، و200 %. يبقى موضع المخطط وعرضه وارتفاعه ثابتًا. البيانات، الدوران، العمق، تباعد السلاسل، والتنسيق متطابقة في جميع الملفات الثلاثة؛ يتغير فقط نسبة الارتفاع.

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

توضح الصور التالية نفس إعدادات الارتفاع في المثال المكافئ لـ .NET وتم تصديرها باستخدام Microsoft PowerPoint. النسبة الصغيرة تنتج مشهدًا أكثر تسطحًا، بينما النسبة الكبيرة تنتج مشهدًا أعلى داخل نفس كائن المخطط. قد يضبط PowerPoint أيضًا فواصل علامات المحور ومكان التسميات لتلائم المشهد.

| الارتفاع: 50 % | الارتفاع: 100 % | الارتفاع: 200 % |
| --- | --- | --- |
| ![مخطط عمودي ثلاثي الأبعاد بارتفاع يساوي 50 % من عرضه](height_percent_50.png) | ![مخطط عمودي ثلاثي الأبعاد بارتفاع يساوي 100 % من عرضه](height_percent_100.png) | ![مخطط عمودي ثلاثي الأبعاد بارتفاع يساوي 200 % من عرضه](height_percent_200.png) |

هذه الطرق تتحكم في جوانب مختلفة من المخطط:

| الطريقة | الأثر |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) | ارتفاع المشهد ثلاثي الأبعاد كنسبة مئوية من عرضه. |
| [IChart.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setHeight-float-) | ارتفاع كائن المخطط على الشريحة، بالنقاط. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | عمق المشهد ثلاثي الأبعاد كنسبة مئوية من عرضه. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | التباعد بين السلاسل على محور العمق، كنسبة مئوية من عرض العلامة. |

تؤثر إعدادات الارتفاع على المخططات العمودية والشريطية الثلاثية الأبعاد، بما في ذلك الأنواع الأسطوانية، المخروطية، والهرمية، وكذلك المخططات الخطية، المساحية، الدائرية، والسطحية الثلاثية الأبعاد. يستخدم المقارنة أعلاه النوع المؤكد `Column3D`. لا يغيّر الإعداد مظهر مخطط `ClusteredColumn` ثنائي الأبعاد أو مخطط `BubbleWith3D`؛ هذه الأسماء هي أعضاء فئة [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). للحصول على إعدادات مظهر مخطط أخرى، راجع [Chart Formatting](/slides/ar/androidjava/chart-formatting/).

## **ضبط الفجوة بين السلاسل**

استخدم [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) للتحكم في المسافة بين سلاسل البيانات على محور العمق في مخطط ثلاثي الأبعاد، معبرًا عنها كنسبة مئوية من عرض العلامة. استخدم قيمًا من **0 إلى 500** شاملة: `0` يزيل الفجوة، بينما القيم الأكبر تزيد التباعد. مع عمق مخطط ثابت، يزيد زيادة الفجوة من نحافة العلامات على محور العمق.

الوصول إلى المجموعة عبر [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) . ينطبق الإعداد على كل سلسلة في تلك المجموعة، وليس فقط السلسلة المستخدمة للوصول إليها. تُعيد [IChartSeries.getGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getGapDepth--) عمق الفجوة وتُعكس إعدادات المجموعة الأصلية.

يؤثر هذا الإعداد على المخططات العمودية والشريطية الثلاثية الأبعاد، بما في ذلك أنماط الأسطوانة، المخروط، والهرم، وكذلك المخططات الخطية والمساحية الثلاثية الأبعاد. يعتمد المظهر على ما إذا كانت السلاسل مرتبة في العمق، مُجمعة، أو مكدسة. للحصول على مقارنة واضحة للفجوات بين السلاسل المنفصلة، استخدم `ChartType.Column3D` من فئة [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/).

هذه الطرق تتحكم في جوانب مختلفة من المخطط:

| الطريقة | الأثر |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | التباعد بين السلاسل على محور العمق، كنسبة مئوية من عرض العلامة. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | التباعد بين مجموعات الأعمدة أو الشرائط المتجاورة، كنسبة مئوية من عرض العمود أو الشرط. |
| [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | عمق المخطط العام، كنسبة مئوية من عرض المخطط. |

المثال المستقل التالي يستخدم بيانات المخطط الافتراضية التي تحتوي على ثلاث سلاسل وأربع فئات. يحفظ عرضين تقديميين ببيانات، دوران، عرض فجوة، وعمق مخطط متطابقة؛ يتغير فقط عمق الفجوة.

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

توضح الصور التالية نفس إعدادات عمق الفجوة في المثال المكافئ لـ .NET وتم تصديرها باستخدام Microsoft PowerPoint.

| عمق الفجوة: 0 % | عمق الفجوة: 500 % |
| --- | --- |
| ![مخطط عمودي ثلاثي الأبعاد بدون فجوة بين السلاسل على محور العمق](gap_depth_0.png) | ![مخطط عمودي ثلاثي الأبعاد بفجوة 500 % بين السلاسل على محور العمق](gap_depth_500.png) |

## **تغيير نوع السلسلة الثلاثية الأبعاد وشكل الشريط**

في مخطط أسطوانة مُجمعة، يبدأ العنصر الأول بشكل شريط أسطواني. يقوم المثال بطباعة القيم الصحيحة التي تُرجعها [IChartSeries.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getType--) و[IChartSeries.getBar3DShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getBar3DShape--) قبل وبعد كل تغيير. يعرض الجدول أسماء الثوابت المقابلة.

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

| تغيير للسلسلة الأولى | نوع السلسلة | شكل الشريط |
| --- | --- | --- |
| إنشاء المخطط | `ClusteredCylinder` | `Cylinder` |
| ضبط نوع السلسلة إلى `ClusteredCone` | `ClusteredCone` | `Cone` |
| ضبط شكل الشريط إلى `Box` | `ClusteredColumn3D` | `Box` |

تغيير الشكل إلى `Box` يغيّر أيضًا نوع السلسلة إلى `ClusteredColumn3D`. إذا كان الكود يفرع بناءً على نوع السلسلة، استدعِ `series.getType()` بعد تغيير الشكل. القيمة المخزنة قبل التعيين ستظل تختار فرع `ClusteredCone`.

![مقارنة PowerPoint تُظهر السلسلة الأولى كأسطوانات، مخاريط، وأعمدة مستطيلة من اليسار إلى اليمين](series-shapes.png)

## **الأسئلة المتكررة**

**ما أنواع المخططات التي تدعم الوضع ثلاثي الأبعاد في Aspose.Slides؟**

يدعم Aspose.Slides الأنواع الثلاثية الأبعاد من المخططات العمودية، بما في ذلك Column 3D، Clustered Column 3D، Stacked Column 3D، و100 % Stacked Column 3D، بالإضافة إلى الأنواع الثلاثية المرتبطة المعروضة عبر فئة [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). للحصول على قائمة دقيقة ومحدّثة، تحقق من أعضاء [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) في مرجع API للإصدار المثبت لديك.

**هل يمكن الحصول على صورة نقطية لمخطط ثلاثي الأبعاد لتقارير أو للويب؟**

نعم. يمكنك تصدير المخطط إلى صورة باستخدام [Shape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) أو [تصوير الشريحة بالكامل](/slides/ar/androidjava/convert-powerpoint-to-png/) إلى صيغ مثل PNG أو JPEG. هذا مفيد عندما تحتاج إلى معاينة نقطية أو تريد تضمين المخطط في مستندات، لوحات معلومات، أو صفحات ويب دون الحاجة إلى PowerPoint.

**ما مدى كفاءة بناء ورسم المخططات الثلاثية الكبيرة؟**

تعتمد الكفاءة على حجم البيانات وتعقيد المشهد البصري. للحصول على أفضل النتائج، ابقِ التأثيرات الثلاثية الحد الأدنى، تجنّب القوام الثقيلة على الجدران ومناطق الرسم، حدّ من عدد نقاط البيانات لكل سلسلة كلما أمكن، ورّس إلى حجم إخراج مناسب (الدقة والأبعاد) يتلاءم مع العرض المستهدف أو متطلبات الطباعة.