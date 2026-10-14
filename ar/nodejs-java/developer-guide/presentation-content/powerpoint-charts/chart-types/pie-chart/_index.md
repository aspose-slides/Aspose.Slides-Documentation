---
title: تخصيص المخططات الدائرية في العروض التقديمية باستخدام JavaScript
linktitle: مخطط دائري
type: docs
url: /ar/nodejs-java/pie-chart/
keywords:
- مخطط دائري
- إدارة المخطط
- تخصيص المخطط
- خيارات المخطط
- إعدادات المخطط
- خيارات الرسم
- لون الشريحة
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إنشاء وتخصيص المخططات الدائرية في JavaScript باستخدام Aspose.Slides لـ Node.js عبر Java. تكوين الرسوم الثانوية، عرض ملصقات البيانات، وتطبيق ألوان شرائح تلقائية في PowerPoint."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية العمل مع مخططات الفطيرة في Aspose.Slides. توضح طريقة تكوين خيارات الرسم الثانوي لمخططات Pie of Pie و Bar of Pie، وكيفية تمكين تلوين الشرائح تلقائيًا لمخطط فطيرة قياسي.

تركز الأمثلة على مهام تخصيص المخططات مثل إضافة مخطط إلى شريحة، وضبط إعدادات السلاسل والملصقات، واستبدال بيانات المخطط الافتراضية بفئات وقيم مخصصة، وحفظ العرض التقديمي المحدث.

## **خيارات الرسم الثانوي لمخططات Pie of Pie و Bar of Pie**

يدعم Aspose.Slides for Node.js via Java خيارات الرسم الثانوي لمخططات Pie of Pie و Bar of Pie. تتحكم هذه الخيارات في حجم الرسم الثانوي وكيفية تقسيم نقاط البيانات بين الرسمين.

المثال التالي creates a Pie of Pie chart in a new presentation and displays data point values as labels. The [setSecondPieSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setSecondPieSize) method sets the secondary plot size to 149% of the main plot. [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) selects percentage-based splitting, and [setPieSplitPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) sets the threshold to 53%.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    const series = chart.getChartData().getSeries().get_Item(0);

    // عرض القيم وتكوين المخطط الثانوي.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **حدد الفئات للرسم الثانوي**

استخدم التقسيم المخصص عندما ترغب في تجميع فئات محددة في الرسم الثانوي بغض النظر عن قيم النسبة المئوية الخاصة بها. على سبيل المثال، قد يُظهر تقرير مبيعات قنوات "Online" و "Events" معًا لكي يتمكن القارئ من مقارنة هاتين القناتين، رغم أنهما تمثلان 35% و10% من إجمالي المبيعات.

استدعِ [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) مع [PieSplitType.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplittype/#Custom) وحدد النقاط عبر [getPieSplitCustomPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). تقبل طريقة [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#add) في المجموعة فهرسًا يبدأ من الصفر داخل السلسلة؛ استخدم [addItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#addItem) لإضافة كائن نقطة بيانات. في هذا المثال، يختار الفهرس 1 فئة Online، والفهرس 3 يختار فئة Events. يتم إضافة Partners مؤقتًا، ثم استبعادها باستخدام [removeItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 600, 200);

    // استبدال البيانات الافتراضية بمبيعات حسب القناة.
    const workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    const values = [ 40, 35, 15, 10 ];
    const seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // اختيار Online باستخدام الفهرس الصفري الخاص به و Events باستخدام كائن نقطة البيانات.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // استثناء Partners من الاختيار دون حذف بيانات المصدر الخاصة به.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تظهر Online (35) و Events (10) كشرائح منفصلة في الرسم الثانوي. في الرسم الأساسي، يتم تمثيلهما بشريحة واحدة مجمعة بقيمة 45، إلى جانب Retail (40) و Partners (15). إن إزالة Partners من الاختيار المخصص يبقيها في الرسم الأساسي؛ لا يتم حذف الفئة أو قيمتها من بيانات المصدر للمخطط.

الصورة التالية تُظهر العرض التقديمي المحفوظ في PowerPoint:

![Pie of Pie chart with Online and Events in the secondary plot and their combined value of 45 in the primary plot](pie_of_pie_custom.png)

## **تعيين ألوان شرائح مخطط الفطيرة تلقائيًا**

يمكن لـ Aspose.Slides for Node.js via Java تعيين ألوان مختلفة تلقائيًا لشرائح مخطط الفطيرة. المثال التالي creates a pie chart with a centered title and replaces the default data with three quarterly categories and their values. The [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue) method displays the values 20, 50, and 30 as labels, while [setColorVaried](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setColorVaried) enables a distinct color for each slice.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);

    // إضافة عنوان مخطط مركزي.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // استبدال البيانات الافتراضية باستخدام الورقة الأولى.
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    const values = [ 20, 50, 30 ];
    const seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // عرض القيم وتعيين ألوان مختلفة للشرائح.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة المتداولة**

**هل يتم دعم أنواع Pie of Pie و Bar of Pie؟**

نعم، المكتبة [تدعم](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) رسمًا ثانويًا لمخططات الفطيرة، بما في ذلك أنواع Pie of Pie و Bar of Pie.

**هل يمكنني تصدير المخطط فقط كصورة (على سبيل المثال PNG)؟**

نعم، يمكنك [تصدير المخطط نفسه كصورة](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) (مثل PNG) دون تصدير العرض التقديمي بالكامل.