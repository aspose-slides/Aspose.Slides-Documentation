---
title: تخصيص المخططات ثلاثية الأبعاد في العروض التقديمية باستخدام جافاسكريبت
linktitle: مخطط ثلاثي الأبعاد
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
description: "إنشاء مخططات ثلاثية الأبعاد في العروض التقديمية PowerPoint باستخدام Aspose.Slides للـ Node.js عبر Java. ضبط الدوران، نسب الارتفاع، عمق المخطط، والمسافات بين السلاسل باستخدام أمثلة JavaScript."
---
## **نظرة عامة**

تتيح لك Aspose.Slides for Node.js عبر Java تخصيص طريقة عرض مخطط ثلاثي الأبعاد من خلال طريقة [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/) . توضح هذه المقالة كيفية ضبط الدوران، نسب الارتفاع، العمق، المحاور ذات الزاوية القائمة، والمسافات بين السلاسل، ثم حفظ العرض التقديمي بتنسيق PPTX.

## **تعيين الدوران والعمق لمخطط ثلاثي الأبعاد**

المثال أدناه ينشئ [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ويستخدم [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) لإضافة مخطط عمودي ثلاثي الأبعاد مكدس إلى الشريحة الأولى. يستبدل السلاسل والفئات الافتراضية بسلسلتين تحتوي كل منهما على ثلاث قيم. يحدد فهرس ورقة العمل `0` ورقة البيانات الأولى للمخطط؛ الصف `0` يحتوي على أسماء السلاسل، والعمود `0` يحتوي على تسميات الفئات.

تقوم الطريقتان [setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) و [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) بتعيين دوران المخطط إلى 40 و 270 درجة على التوالي. تقوم الطريقة [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) بتعيين عمقه إلى 150٪ من عرضه، بينما تمكّن الطريقة [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) المحاور ذات الزاوية القائمة بدلاً من المنظور. يحتوي العرض التقديمي الناتج على المخطط المملوء بهذه إعدادات العرض ثلاثية الأبعاد.

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

## **تطبيق تعبئة صورة على سطح مخطط ثلاثي الأبعاد**

يمكنك تعبئة [side wall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getsidewall/) و [back wall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getbackwall/) و [floor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getfloor/) لمخطط ثلاثي الأبعاد بشكل مستقل. اضبط [fill type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) للسطح على `Picture` وعيّن صورة. اضبط كل من [picture fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/setpicturefillmode/) ونوع الصورة للسطح [picture type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartwall/setpicturetype/) على `Stretch` لتطبيق نسخة واحدة من الصورة على كامل السطح.

احفظ [arrow.png](arrow.png) في دليل العمل. يقوم المثال بتدوير المخطط ويرفع القيمة القصوى على المحور الرأسي بحيث يكون الأرضية مرئية بين الأعمدة. ثم يستنسخ الشريحة مرتين ويطبّق السهم على سطح مختلف في كل شريحة. تحتفظ جميع المخططات الثلاثة بنفس البيانات وزاوية الرؤية والخلفية.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    const backSlide = presentation.getSlides().addClone(slide);
    const floorSlide = presentation.getSlides().addClone(slide);
    const backChart = backSlide.getShapes().get_Item(0);
    const floorChart = floorSlide.getShapes().get_Item(0);

    const image = slides.Images.fromFile("arrow.png");
    try {
        const arrow = presentation.getImages().addImage(image);
        const surfaces = [chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor()];
        for (const surface of surfaces) {
            const fill = surface.getFormat().getFill();
            fill.setFillType(java.newByte(slides.FillType.Picture));
            const pictureFill = fill.getPictureFillFormat();
            pictureFill.getPicture().setImage(arrow);
            pictureFill.setPictureFillMode(slides.PictureFillMode.Stretch);
            surface.setPictureType(slides.PictureType.Stretch);
        }
    } finally {
        image.dispose();
    }

    presentation.save("chart-surfaces.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint يظهر الشرائح الثلاثة كما يلي.

| جدار جانبي | جدار خلفي | أرضية |
| --- | --- | --- |
| ![سهم يشير إلى داخل المخطط على الجدار الجانبي](side-wall.png) | ![سهم يشير إلى اليمين عبر الجدار الخلفي](back-wall.png) | ![سهم يشير إلى اليمين عبر الأرضية بين الأعمدة](floor.png) |

## **ضبط نسب الارتفاع لمخطط ثلاثي الأبعاد**

استخدم [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) لتعيين ارتفاع مخطط ثلاثي الأبعاد كنسبة مئوية من عرضه. يغيّر هذا نسب المشهد ثلاثي الأبعاد دون تعديل حجم كائن المخطط على الشريحة.

المثال التالي ينشئ مخطط [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) ببيانات افتراضية: ثلاث سلاسل وأربع فئات. يحفظ ثلاث عروض تقديمية بنسب ارتفاع 50٪، 100٪، و200٪. يبقى موضع المخطط وعرضه وارتفاعه ثابتًا. البيانات، الدوران، العمق، مسافات السلاسل، والتنسيق هي نفسها في جميع الملفات الثلاثة؛ فقط نسبة الارتفاع تتغير.

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

توضح الصور التالية نفس إعدادات الارتفاع في المثال .NET المكافئ وتم تصديرها باستخدام Microsoft PowerPoint. النسبة الأصغر تنتج مشهدًا أكثر تسطحًا، بينما النسبة الأكبر تنتج مشهدًا أعلى ضمن نفس كائن المخطط. قد يقوم PowerPoint أيضًا بتعديل فواصل العلامات على المحاور ووضع التسميات لتناسب المشهد.

| الارتفاع: 50٪ | الارتفاع: 100٪ | الارتفاع: 200٪ |
| --- | --- | --- |
| ![مخطط عمودي ثلاثي الأبعاد بارتفاع يساوي 50٪ من عرضه](height_percent_50.png) | ![مخطط عمودي ثلاثي الأبعاد بارتفاع يساوي 100٪ من عرضه](height_percent_100.png) | ![مخطط عمودي ثلاثي الأبعاد بارتفاع يساوي 200٪ من عرضه](height_percent_200.png) |

تتحكم هذه الأساليب في جوانب مختلفة من المخطط:

| Method | Effect |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | ارتفاع المشهد ثلاثي الأبعاد كنسبة مئوية من عرضه. |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | ارتفاع كائن المخطط على الشريحة، بالنقاط. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | عمق المشهد ثلاثي الأبعاد كنسبة مئوية من عرضه. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | مسافة بين السلاسل على محور العمق، كنسبة مئوية من عرض العلامة. |

يؤثر إعداد الارتفاع على المخططات العمودية والشريطية ثلاثية الأبعاد، بما في ذلك المتنوعات الأسطوانية، المخروطية، والهرمية، وكذلك مخططات الخط والمساحة، والدوائر، والسطوح ثلاثية الأبعاد. المقارنة أعلاه تستخدم النوع المؤكد `Column3D`. لا يغيّر الإعداد مظهر مخطط `ClusteredColumn` ثنائي الأبعاد أو مخطط `BubbleWith3D`؛ هذه الأسماء أعضاء في فئة [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). لإعدادات مظهر المخطط الأخرى، راجع [تنسيق المخطط](/slides/ar/nodejs-java/chart-formatting/).

## **ضبط الفجوة بين السلاسل**

استخدم [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) للتحكم في المسافة بين سلاسل البيانات على محور العمق لمخطط ثلاثي الأبعاد، معبرًا عنها كنسبة مئوية من عرض العلامة. استخدم قيمًا من **0 إلى 500** شاملة: `0` يزيل الفجوة، بينما القيم الأكبر تزيد المسافة. مع عمق مخطط ثابت، زيادة الفجوة تجعل العلامات أرق على محور العمق.

يمكن الوصول إلى المجموعة عبر [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/). ينطبق الإعداد على كل سلسلة في تلك المجموعة، وليس فقط السلسلة المستخدمة للوصول إليها. تُعيد [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) الفجوة في العمق وتعكس إعداد المجموعة الأصلية.

يؤثر هذا الإعداد على المخططات العمودية والشريطية ثلاثية الأبعاد، بما في ذلك المتنوعات الأسطوانية، المخروطية، والهرمية، وكذلك مخططات الخط والمساحة ثلاثية الأبعاد. تعتمد المظهرية على ما إذا كانت السلاسل مرتبة في العمق أو مجمّعة أو مكدسة. للمقارنة الواضحة للفجوات بين السلاسل المنفصلة، استخدم `ChartType.Column3D` من فئة [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/).

تتحكم هذه الأساليب في جوانب مختلفة من المخطط:

| Method | Effect |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | مسافة بين السلاسل على محور العمق، كنسبة مئوية من عرض العلامة. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | مسافة بين مجموعات الأعمدة أو الأشرطة المتجاورة، كنسبة مئوية من عرض العمود أو الشريط. |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | عمق المخطط الكلي، كنسبة مئوية من عرض المخطط. |

المثال المستقل التالي يستخدم بيانات المخطط الافتراضية، التي تحتوي على ثلاث سلاسل وأربع فئات. يحفظ عرضين تقديميين ببيانات، دوران، عرض فجوة، وعمق مخطط متطابقة؛ فقط فجوة العمق تتغير.

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

توضح الصور التالية نفس إعدادات الفجوة في المثال .NET المكافئ وتم تصديرها باستخدام Microsoft PowerPoint.

| فجوة العمق: 0٪ | فجوة العمق: 500٪ |
| --- | --- |
| ![مخطط عمودي ثلاثي الأبعاد بدون فجوة بين السلاسل على محور العمق](gap_depth_0.png) | ![مخطط عمودي ثلاثي الأبعاد بفجوة 500٪ بين السلاسل على محور العمق](gap_depth_500.png) |

## **تغيير نوع السلسلة ثلاثي الأبعاد وشكل الشريط**

في مخطط أسطواني مُجمّع، تبدأ السلسلة الأولى بشكل شريط أسطواني. يطبع المثال القيم الصحيحة التي تُرجعها [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) و [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) قبل وبعد كل تغيير. تُظهر الجدول الأسماء الثابتة المقابلة.

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

| تغيير للسلسلة الأولى | نوع السلسلة | شكل الشريط |
| --- | --- | --- |
| إنشاء المخطط | `ClusteredCylinder` | `Cylinder` |
| تعيين نوع السلسلة إلى `ClusteredCone` | `ClusteredCone` | `Cone` |
| تعيين شكل الشريط إلى `Box` | `ClusteredColumn3D` | `Box` |

تغيير الشكل إلى `Box` يغيّر أيضًا نوع السلسلة إلى `ClusteredColumn3D`. إذا كان شفرتك تتفرع بناءً على نوع السلسلة، استدعِ `series.getType()` بعد تغيير الشكل. القيمة المخزنة مؤقتًا قبل التعيين ما زالت ستختار فرع `ClusteredCone`.

![مقارنة PowerPoint تُظهر السلسلة الأولى كأسطوانات، مخاريط، وأعمدة مستطيلة من اليسار إلى اليمين](series-shapes.png)

## **الأسئلة الشائعة**

**أي أنواع المخططات تدعم وضع 3D في Aspose.Slides?**

يدعم Aspose.Slides المتنوعات ثلاثية الأبعاد لمخططات الأعمدة، بما في ذلك Column 3D، Clustered Column 3D، Stacked Column 3D، و100% Stacked Column 3D، جنبًا إلى جنب مع الأنواع الثلاثية ذات الصلة التي تكشف عنها فئة [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) . للحصول على قائمة دقيقة ومحدثة، تحقق من أعضاء فئة [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) في مرجع API للنسخة المثبتة لديك.

**هل يمكنني الحصول على صورة نقطية لمخطط ثلاثي الأبعاد لتقرير أو للويب؟**

نعم. يمكنك تصدير المخطط إلى صورة باستخدام [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) أو [تصيير الشريحة بالكامل](/slides/ar/nodejs-java/convert-powerpoint-to-png/) إلى صيغ مثل PNG أو JPEG. هذا مفيد عندما تحتاج إلى معاينة نقطية أو تريد تضمين المخطط في مستندات، لوحات معلومات، أو صفحات ويب دون الحاجة إلى PowerPoint.

**ما مدى أداء بناء وعرض مخططات ثلاثية الأبعاد الكبيرة؟**

يعتمد الأداء على حجم البيانات وتعقيد العرض المرئي. للحصول على أفضل النتائج، احرص على تقليل تأثيرات 3D إلى الحد الأدنى، وتجنب القوام الثقيلة على الجدران ومناطق الرسم، وحدّ عدد نقاط البيانات لكل سلسلة عندما يكون ذلك ممكنًا، وقم بالتصيير إلى مخرج بحجم مناسب (الدقة والأبعاد) لتتناسب مع شاشة العرض أو احتياجات الطباعة المستهدفة.