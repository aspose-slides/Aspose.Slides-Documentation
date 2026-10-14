---
title: تخصيص مخططات الفطيرة في العروض التقديمية باستخدام جافا
linktitle: مخطط الفطيرة
type: docs
url: /ar/java/pie-chart/
keywords:
- مخطط الفطيرة
- إدارة المخطط
- تخصيص المخطط
- خيارات المخطط
- إعدادات المخطط
- خيارات الرسم
- لون الشريحة
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "إنشاء وتخصيص مخططات الفطيرة في جافا باستخدام Aspose.Slides. تكوين المخططات الثانوية، عرض تسميات البيانات، وتطبيق ألوان شرائح تلقائية في PowerPoint."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية العمل مع مخططات الفطيرة في Aspose.Slides. وتوضح كيفية تكوين خيارات المخطط الثانوي لمخططات بيف أوف بيف وبار أوف بيف، وكيفية تمكين تلوين الشرائح تلقائيًا لمخطط فطيرة قياسي.

تركز الأمثلة على مهام تخصيص المخطط مثل إضافة مخطط إلى شريحة، ضبط إعدادات السلاسل والتسميات، استبدال بيانات المخطط الافتراضية بفئات وقيم مخصصة، وحفظ العرض التقديمي المحدث.

## **خيارات المخطط الثانوي لمخططات بيف أوف بيف وبار أوف بيف**

يدعم Aspose.Slides for Java خيارات المخطط الثانوي لمخططات بيف أوف بيف وبار أوف بيف. تتحكم هذه الخيارات في حجم المخطط الثانوي وكيفية تقسيم نقاط البيانات بين المخططين.

المثال التالي ينشئ مخطط بيف أوف بيف في عرض تقديمي جديد ويعرض قيم نقاط البيانات كوسوم. الطريقة [setSecondPieSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setSecondPieSize-int-) تحدد حجم المخطط الثانوي إلى 149% من المخطط الرئيسي. الطريقة [setPieSplitBy](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) تختار تقسيمًا يعتمد على النسبة المئوية، و[setPieSplitPosition](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitPosition-double-) تحدد العتبة إلى 53%.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // عرض القيم وتكوين المخطط الثانوي.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **اختر الفئات للمخطط الثانوي**

استخدم التقسيم المخصص عندما ترغب في تجميع فئات معينة في المخطط الثانوي بغض النظر عن قيم نسبتها المئوية. على سبيل المثال، قد يُظهر تقرير المبيعات الفئات Online وEvents معًا حتى يتمكن القارئ من مقارنة هذين القناتين، رغم أنهما تمثلان 35% و10% من إجمالي المبيعات.

استدعِ الطريقة [setPieSplitBy](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) مع [PieSplitType.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/piesplittype/#Custom) وحدد النقاط عبر [getPieSplitCustomPoints](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#getPieSplitCustomPoints--). طريقة [add](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#add-int-) في المجموعة تقبل فهرسًا يبدأ من الصفر في السلسلة؛ استخدم [addItem](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#addItem-com.aspose.slides.IChartDataPoint-) لإضافة كائن نقطة بيانات. في هذا المثال، الفهرس 1 يختار Online، والنقطة في الفهرس 3 تختار Events. كما يتم إضافة Partners مؤقتًا، ثم استبعاده باستخدام [removeItem](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#removeItem-com.aspose.slides.IChartDataPoint-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200);

    // استبدال البيانات الافتراضية بمبيعات حسب القناة.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "Retail", "Online", "Partners", "Events" };
    int[] values = { 40, 35, 15, 10 };
    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // تحديد Online بواسطة الفهرس الصفري وEvents بواسطة كائن نقطة البيانات.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // استبعاد Partners من الاختيار دون حذف بياناته المصدر.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تظهر الفئات Online (35) وEvents (10) كشرائح منفصلة في المخطط الثانوي. في المخطط الرئيسي، يتم تمثيلهما بشريحة واحدة مدمجة بقيمة 45، إلى جانب Retail (40) وPartners (15). إزالة Partners من الاختيار المخصص يبقيها في المخطط الرئيسي؛ ولا تُزيل الفئة أو قيمتها من بيانات المصدر الخاصة بالمخطط.

الصورة التالية توضح العرض التقديمي المحفوظ في PowerPoint:

![مخطط بيف أوف بيف مع Online وEvents في المخطط الثانوي وقيمتهما المجمعة 45 في المخطط الرئيسي](pie_of_pie_custom.png)

## **تعيين ألوان شرائح مخطط الفطيرة تلقائيًا**

يمكن لـ Aspose.Slides for Java تعيين ألوان مختلفة تلقائيًا لشرائح مخطط الفطيرة. المثال التالي ينشئ مخطط فطيرة بعنوان مركزي ويستبدل البيانات الافتراضية بثلاث فئات ربع سنوية وقيمها. الطريقة [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) تعرض القيم 20 و50 و30 كوسوم، بينما تفعّل الطريقة [setColorVaried](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setColorVaried-boolean-) لونًا متميزًا لكل شريحة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // إضافة عنوان مخطط مركزي.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // استبدال البيانات الافتراضية باستخدام ورقة العمل الأولى.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "First Qtr", "2nd Qtr", "3rd Qtr" };
    int[] values = { 20, 50, 30 };
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // عرض القيم وتعيين ألوان مختلفة للشرائح.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة المتكررة**

**هل تدعم تنويعات بيف أوف بيف وبار أوف بيف؟**

نعم، المكتبة [تدعم](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) مخططًا ثانويًا لمخططات الفطيرة، بما في ذلك نوعي بيف أوف بيف وبار أوف بيف.

**هل يمكنني تصدير المخطط فقط كصورة (مثلاً PNG)؟**

نعم، يمكنك [تصدير المخطط نفسه كصورة](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) (مثل PNG) دون تصدير العرض التقديمي بالكامل.