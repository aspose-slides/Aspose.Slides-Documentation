---
title: تخصيص مخططات الفطائر في العروض التقديمية على Android
linktitle: مخطط الفطيرة
type: docs
url: /ar/androidjava/pie-chart/
keywords:
- مخطط الفطيرة
- إدارة المخطط
- تخصيص المخطط
- خيارات المخطط
- إعدادات المخطط
- خيارات المخطط البياني
- لون الشريحة
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إنشاء وتخصيص مخططات الفطائر على Android باستخدام Aspose.Slides for Android عبر Java. تكوين المخططات الثانوية، وعرض تسميات البيانات، وتطبيق ألوان الشرائح تلقائيًا في PowerPoint."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية العمل مع مخططات الفطائر في Aspose.Slides. وتظهر كيفية تكوين خيارات المخطط الثانوي لمخططات Pie of Pie و Bar of Pie، وكيفية تمكين تلوين الشرائح تلقائيًا لمخطط الفطيرة القياسي.

تركز الأمثلة على مهام تخصيص المخططات مثل إضافة مخطط إلى شريحة، وضبط إعدادات السلاسل والتسميات، واستبدال بيانات المخطط الافتراضية بفئات وقيم مخصصة، وحفظ العرض التقديمي المحدث.

## **خيارات المخطط الثانوي لمخططات Pie of Pie و Bar of Pie**

يدعم Aspose.Slides for Android عبر Java خيارات المخطط الثانوي لمخططات Pie of Pie و Bar of Pie. تتحكم هذه الخيارات في حجم المخطط الثانوي وكيفية تقسيم نقاط البيانات بين المخططين.

المثال التالي ينشئ مخطط Pie of Pie في عرض تقديمي جديد ويعرض قيم نقاط البيانات كملصقات. طريقة [setSecondPieSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setSecondPieSize-int-) تُحدد حجم المخطط الثانوي إلى 149% من المخطط الرئيسي. طريقة [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) تختار الانقسام القائم على النسبة المئوية، وطريقة [setPieSplitPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitPosition-double-) تُحدد العتبة إلى 53%.

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

استخدم التقسيم المخصص عندما تريد تجميع فئات معينة في المخطط الثانوي بغض النظر عن قيم نسبتها. على سبيل المثال، قد يُظهر تقرير مبيعات القنوات Online و Events معًا لتمكين القراء من مقارنة هاتين القناتين، رغم أنهما تمثلان 35% و10% من إجمالي المبيعات.

استدعِ طريقة [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) مع [PieSplitType.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplittype/#Custom) وحدد النقاط عبر [getPieSplitCustomPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#getPieSplitCustomPoints--). طريقة المجموعة [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#add-int-) تقبل فهرسًا يبدأ من الصفر في السلسلة؛ استخدم [addItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#addItem-com.aspose.slides.IChartDataPoint-) لإضافة كائن نقطة بيانات. في هذا المثال، الفهرس 1 يختار Online، والنقطة في الفهرس 3 تختار Events. يتم إضافة Partners مؤقتًا، ثم استثناؤه باستخدام [removeItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#removeItem-com.aspose.slides.IChartDataPoint-).

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

    // حدد Online باستخدام الفهرس الصفري و Events باستخدام كائن نقطة البيانات.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // استبعاد Partners من الاختيار دون حذف بيانات المصدر.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) و Events (10) يظهران كشريحات منفصلة في المخطط الثانوي. في المخطط الأساسي، يتم تمثيلهما بشريحة واحدة مجمعة بقيمة 45، إلى جانب Retail (40) و Partners (15). إزالة Partners من الاختيار المخصص يبقيها في المخطط الأساسي؛ ولا تُزيل الفئة أو قيمتها من بيانات المصدر للمخطط.

الصورة التالية توضح العرض التقديمي المحفوظ في PowerPoint:

![مخطط Pie of Pie مع Online و Events في المخطط الثانوي وقيمتهما المجمعة 45 في المخطط الأساسي](pie_of_pie_custom.png)

## **تعيين ألوان شرائح المخطط الدائري تلقائيًا**

يمكن Aspose.Slides for Android عبر Java تعيين ألوان مختلفة تلقائيًا لشريحات المخطط الدائري. المثال التالي ينشئ مخططًا دائريًا بعنوان مركزي ويستبدل البيانات الافتراضية بثلاث فئات ربع سنوية وقيمها. طريقة [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) تعرض القيم 20 و 50 و 30 كملصقات، بينما طريقة [setColorVaried](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setColorVaried-boolean-) تُفعّل لونًا مميزًا لكل شريحة.

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

    // إظهار القيم وتعيين ألوان مختلفة للشرائح.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**هل يتم دعم تنويعات Pie of Pie و Bar of Pie؟**

نعم، المكتبة [يدعم](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) مخططًا ثانويًا لمخططات الفطيرة، بما في ذلك الأنواع Pie of Pie و Bar of Pie.

**هل يمكنني تصدير المخطط نفسه كصورة (مثلاً PNG)؟**

نعم، يمكنك [تصدير المخطط نفسه كصورة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) (such as PNG) دون تصدير العرض التقديمي بأكمله.