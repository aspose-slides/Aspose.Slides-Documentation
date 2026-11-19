---
title: تخصيص المخططات ثلاثية الأبعاد في العروض التقديمية باستخدام JavaScript
linktitle: مخطط 3D
type: docs
url: /ar/nodejs-java/3d-chart/
keywords:
- مخطط ثلاثي الأبعاد
- دوران
- عمق
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إنشاء مخططات ثلاثية الأبعاد في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ Node.js عبر Java. ضبط الدوران، نسب الارتفاع، عمق المخطط، والمسافات بين السلاسل بأمثلة JavaScript."
---
## **نظرة عامة**

تتيح لك Aspose.Slides لـ Node.js عبر Java تخصيص عرض مخطط ثلاثي الأبعاد عبر طريقة [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/) . توضح هذه المقالة كيفية تعديل الدوران، نسب الارتفاع، العمق، المحاور القائمة على الزاوية القائمة، والمسافات بين السلاسل، ثم حفظ العرض التقديمي بصيغة PPTX.

## **تعيين الدوران والعمق لمخطط ثلاثي الأبعاد**

المثال أدناه ينشئ [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ويستخدم [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) لإضافة مخطط عمودي ثلاثي الأبعاد مكدس إلى الشريحة الأولى. يستبدل السلاسل والفئات الافتراضية بسلسلتين تحتوي كل منهما على ثلاثة قيم. يشير فهرس ورقة العمل `0` إلى ورقة البيانات الأولى للمخطط؛ الصف `0` يحتوي على أسماء السلاسل، والعمود `0` يحتوي على تسميات الفئات.

[setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) و[setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) يضبطان دوران المخطط إلى 40 و270 درجة على التوالي. [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) يضبط عمقه إلى 150% من عرضه، بينما [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) يفعّل المحاور القائمة على الزاوية القائمة بدلًا من المنظور. العرض التقديمي الناتج يحتوي على المخطط المملوء بهذه إعدادات العرض الثلاثي الأبعاد.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    const values = [[20, 50, 30], [30, 10, 60]];

    for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        const categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            const valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ضبط نسب الارتفاع لمخطط ثلاثي الأبعاد**

استخدم [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) لتعيين ارتفاع المخطط ثلاثي الأبعاد كنسبة مئوية من عرضه. يغيّر هذا نسب المشهد ثلاثي الأبعاد دون تغيير حجم كائن المخطط على الشريحة.

المثال التالي ينشئ مخطط [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) بالبيانات الافتراضية: ثلاث سلاسل وأربع فئات. يحفظ ثلاث عروض تقديمية بنسب ارتفاع 50%، 100%، و200%. يبقى موضع المخطط وعرضه وارتفاعه ثابتًا. البيانات، الدوران، العمق، مسافة السلاسل، والتنسيق متطابقة في جميع الملفات الثلاثة؛ يتغير فقط نسبة الارتفاع.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (const heightPercent of [50, 100, 200]) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

الصور التالية توضح نفس إعدادات الارتفاع في مثال .NET المكافئ وتم تصديرها باستخدام Microsoft PowerPoint. النسبة الأصغر تُنتج مشهدًا أكثر تسطيحًا، بينما النسبة الأكبر تُنتج مشهدًا أعلى داخل نفس كائن المخطط. قد يقوم PowerPoint أيضًا بضبط فواصل علامات المحور وتوقعات التسميات لتناسب المشهد.

| الارتفاع: 50% | الارتفاع: 100% | الارتفاع: 200% |
| --- | --- | --- |
| ![مخطط عمودي ثلاثي الأبعاد بارتفاع يساوي 50٪ من عرضه](height_percent_50.png) | ![مخطط عمودي ثلاثي الأبعاد بارتفاع يساوي 100٪ من عرضه](height_percent_100.png) | ![مخطط عمودي ثلاثي الأبعاد بارتفاع يساوي 200٪ من عرضه](height_percent_200.png) |

تتحكم هذه الطرق في جوانب مختلفة من المخطط:

| الطريقة | التأثير |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | ارتفاع المشهد ثلاثي الأبعاد كنسبة مئوية من عرضه. |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | ارتفاع كائن المخطط على الشريحة، بوحدات النقاط. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | عمق المشهد ثلاثي الأبعاد كنسبة مئوية من عرضه. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | المسافة بين السلاسل على محور العمق، كنسبة مئوية من عرض العلامة. |

تؤثر إعدادات الارتفاع على المخططات العمودية والشريطية ثلاثية الأبعاد، بما في ذلك المتغيرات الأسطوانية، المخروطية، والهرمية، وكذلك المخططات الخطية، المساحية، الدائرية، والسطحية ثلاثية الأبعاد. المقارنة أعلاه تستخدم النوع `Column3D` المؤكد. لا تغير الإعداد مظهر مخطط `ClusteredColumn` ثنائي الأبعاد أو مخطط `BubbleWith3D`؛ هذه الأسماء هي أعضاء في الفئة [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). للحصول على إعدادات مظهر أخرى للمخططات، راجع [Chart Formatting](/slides/ar/nodejs-java/chart-formatting/).

## **ضبط الفجوة بين السلاسل**

استخدم [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) للتحكم في المسافة بين سلاسل البيانات على محور العمق في مخطط ثلاثي الأبعاد، معبرًا عنها كنسبة مئوية من عرض العلامة. استخدم قيمًا من **0 إلى 500** شاملًا: `0` يزيل الفجوة، بينما القيم الأكبر تزيد من المسافة. مع عمق مخطط ثابت، زيادة الفجوة تجعل العلامات أرق على محور العمق.

الوصول إلى المجموعة عبر [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/). يطبق الإعداد على كل سلسلة في تلك المجموعة، وليس فقط السلسلة المستخدمة للوصول إليها. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) يُرجع فجوة العمق ويعكس إعداد المجموعة الأصلية.

تؤثر هذه الإعدادات على المخططات العمودية والشريطية ثلاثية الأبعاد، بما في ذلك المتغيرات الأسطوانية، المخروطية، والهرمية، وكذلك مخططات الخط والمساحة ثلاثية الأبعاد. يعتمد المظهر على ما إذا كانت السلاسل مرتبة في العمق، أو مجمعة، أو مكدسة. للحصول على مقارنة واضحة للفجوات بين السلاسل المنفصلة، استخدم `ChartType.Column3D` من الفئة [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/).

تتحكم هذه الطرق في جوانب مختلفة من المخطط:

| الطريقة | التأثير |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | المسافة بين السلاسل على محور العمق، كنسبة مئوية من عرض العلامة. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | المسافة بين مجموعات الأعمدة أو الأشرطة المتجاورة، كنسبة مئوية من عرض العمود أو الشريط. |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | عمق المخطط الكامل، كنسبة مئوية من عرض المخطط. |

المثال المستقل التالي يستخدم بيانات المخطط الافتراضية، التي تحتوي على ثلاث سلاسل وأربع فئات. يحفظ عرضين تقديميين ببيانات، دوران، عرض الفجوة، وعمق المخطط متطابقة؛ يتغير فقط عمق الفجوة.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    const series = chart.getChartData().getSeries().get_Item(0);
    const group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (const gapDepth of [0, 500]) {
        group.setGapDepth(gapDepth);

        const fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

الصور التالية توضح نفس إعدادات عمق الفجوة في مثال .NET المكافئ وتم تصديرها باستخدام Microsoft PowerPoint.

| عمق الفجوة: 0% | عمق الفجوة: 500% |
| --- | --- |
| ![مخطط عمودي ثلاثي الأبعاد بدون فجوة بين السلاسل على محور العمق](gap_depth_0.png) | ![مخطط عمودي ثلاثي الأبعاد بفجوة 500٪ بين السلاسل على محور العمق](gap_depth_500.png) |

## **تغيير نوع السلسلة ثلاثية الأبعاد وشكل الشريط**

في مخطط أسطواني مجمع، تبدأ السلسلة الأولى بشكل شريط أسطواني. يطبع المثال القيم الصحيحة التي تُرجعها [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) و[ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) قبل وبعد كل تغيير. الجدول يعطي أسماء الثوابت المقابلة.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.ClusteredCylinder, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setType(slides.ChartType.ClusteredCone);
    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(slides.ChartShapeType.Box);
    console.log(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| تغيير السلسلة الأولى | نوع السلسلة | شكل الشريط |
| --- | --- | --- |
| إنشاء المخطط | `ClusteredCylinder` | `Cylinder` |
| تعيين نوع السلسلة إلى `ClusteredCone` | `ClusteredCone` | `Cone` |
| تعيين شكل الشريط إلى `Box` | `ClusteredColumn3D` | `Box` |

تغيير الشكل إلى `Box` يغير أيضًا نوع السلسلة إلى `ClusteredColumn3D`. إذا كان كودك يتفرع بناءً على نوع السلسلة، استدعِ `series.getType()` بعد تغيير الشكل. القيمة المخزنة مسبقًا قبل التعيين ستختار ما زالت فرع `ClusteredCone`.

![مقارنة PowerPoint تُظهر السلسلة الأولى كأنابيب أسطوانية، مخروطية، وأعمدة مستطيلة من اليسار إلى اليمين](series-shapes.png)

## **الأسئلة المتكررة**

**ما أنواع المخططات التي تدعم الوضع ثلاثي الأبعاد في Aspose.Slides؟**

يدعم Aspose.Slides المتغيرات الثلاثية الأبعاد من المخططات العمودية، بما في ذلك Column 3D وClustered Column 3D وStacked Column 3D و100% Stacked Column 3D، بالإضافة إلى الأنواع الثلاثية الأبعاد المرتبطة التي يتم عرضها عبر فئة [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). للحصول على قائمة دقيقة ومحدثة، تحقق من أعضاء [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) في مرجع API للإصدار المثبت لديك.

**هل يمكنني الحصول على صورة نقطية لمخطط ثلاثي الأبعاد لتقرير أو للويب؟**

نعم. يمكنك تصدير المخطط إلى صورة باستخدام [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) أو [تحويل الشريحة بالكامل](/slides/ar/nodejs-java/convert-powerpoint-to-png/) إلى صيغ مثل PNG أو JPEG. هذا مفيد عندما تحتاج إلى معاينة نقطية أو تريد تضمين المخطط في مستندات، لوحات معلومات، أو صفحات ويب دون الحاجة إلى PowerPoint.

**ما مدى كفاءة بناء وعرض المخططات الثلاثية الأبعاد الكبيرة؟**

تعتمد الأداء على حجم البيانات وتعقيد العرض البصري. للحصول على أفضل النتائج، احرص على تقليل تأثيرات 3D إلى الحد الأدنى، وتجنب القوام الثقيلة على الجدران ومساحات الرسم، وحدّ عدد نقاط البيانات لكل سلسلة عندما يكون ذلك ممكنًا، وقم بالعرض إلى إخراج بالحجم المناسب (الدقة والأبعاد) لتطابق شاشة العرض أو احتياجات الطباعة المستهدفة.