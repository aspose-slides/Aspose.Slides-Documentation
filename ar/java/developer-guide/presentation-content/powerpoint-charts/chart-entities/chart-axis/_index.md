---
title: تخصيص محاور المخطط في العروض التقديمية باستخدام Java
linktitle: محور المخطط
type: docs
url: /ar/java/chart-axis/
keywords:
- محور المخطط
- محور رأسي
- محور أفقي
- تخصيص المحور
- تعديل المحور
- إدارة المحور
- خصائص المحور
- القيمة القصوى
- القيمة الدنيا
- خط المحور
- تنسيق التاريخ
- عنوان المحور
- موضع المحور
- PowerPoint
- العرض التقديمي
- Java
- Aspose.Slides
description: "اكتشف كيفية استخدام Aspose.Slides for Java لتخصيص محاور المخطط في عروض PowerPoint التقديمية للتقارير والتصوير البياني."
---

## **احصل على القيم القصوى على المحور الرأسي في المخططات**
Aspose.Slides for Java يتيح لك الحصول على القيم الدنيا والقصوى على محور رأسي. اتبع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الوصول إلى الشريحة الأولى.
3. إضافة مخطط مع البيانات الافتراضية.
4. الحصول على القيمة القصوى الفعلية على المحور.
5. الحصول على القيمة الدنيا الفعلية على المحور.
6. الحصول على الوحدة الرئيسية الفعلية للمحور.
7. الحصول على الوحدة الفرعية الفعلية للمحور.
8. الحصول على مقياس الوحدة الرئيسية الفعلية للمحور.
9. الحصول على مقياس الوحدة الفرعية الفعلية للمحور.

يعرض هذا الكود النموذجي—تنفيذ للخطوات أعلاه—كيفية الحصول على القيم المطلوبة في Java:
```java
Presentation pres = new Presentation();
try {
	Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
	chart.validateChartLayout();

	double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
	double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

	double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
	double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();

	// يحفظ العرض التقديمي
	pres.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **تبادل البيانات بين المحاور**
يتيح لك Aspose.Slides تبديل البيانات بين المحاور بسرعة — البيانات المعروضة على المحور الرأسي (محور y) تنتقل إلى المحور الأفقي (محور x) والعكس بالعكس.

يعرض لك هذا الكود Java كيفية تنفيذ مهمة تبديل البيانات بين المحاور في المخطط:
```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//تبديل الصفوف والأعمدة
	chart.getChartData().switchRowColumn();

	// حفظ العرض التقديمي
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **إلغاء تفعيل المحور الرأسي للمخططات الخطية**
يعرض لك هذا الكود Java كيفية إخفاء المحور الرأسي لمخطط خطي:
```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
	chart.getAxes().getVerticalAxis().setVisible(false);

	pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **إلغاء تفعيل المحور الأفقي للمخططات الخطية**
يعرض لك هذا الكود كيفية إخفاء المحور الأفقي لمخطط خطي:
```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
	chart.getAxes().getHorizontalAxis().setVisible(false);

	pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **تغيير محور الفئة**
باستخدام خاصية **CategoryAxisType**، يمكنك تحديد نوع محور الفئة المفضل لديك (**date** أو **text**). يوضح هذا الكود في Java العملية: 
```java
Presentation presentation = new Presentation("ExistingChart.pptx");
try {
	IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
	chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
	chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
	chart.getAxes().getHorizontalAxis().setMajorUnit(1);
	chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);
	presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```


## **تعيين تنسيق التاريخ لقيم محور الفئة**
يتيح لك Aspose.Slides for Java تعيين تنسيق التاريخ لقيمة محور الفئة. يتم توضيح العملية في هذا الكود Java:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
	
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
public static String convertToOADate(GregorianCalendar date) throws ParseException
{
    double oaDate;
    SimpleDateFormat myFormat = new SimpleDateFormat("dd MM yyyy");
    java.util.Date baseDate = myFormat.parse("30 12 1899");
    Long days = TimeUnit.DAYS.convert(date.getTimeInMillis() - baseDate.getTime(), TimeUnit.MILLISECONDS);
    oaDate = (double) days + ((double) date.get(Calendar.HOUR_OF_DAY) / 24) + ((double) date.get(Calendar.MINUTE) / (60 * 24)) + ((double) date.get(Calendar.SECOND) / (60 * 24 * 60));
    return String.valueOf(oaDate);
}
```


## **تعيين زاوية دوران لعنوان محور المخطط**
يتيح لك Aspose.Slides for Java تعيين زاوية الدوران لعنوان محور المخطط. يوضح هذا الكود Java العملية:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين موضع المحور على محور الفئة أو القيمة**
يتيح لك Aspose.Slides for Java تعيين موضع المحور في محور الفئة أو القيمة. يوضح هذا الكود Java كيفية تنفيذ المهمة:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تمكين تسمية وحدة العرض على محور قيم المخطط**
يتيح لك Aspose.Slides for Java تكوين المخطط لعرض تسمية وحدة على محور قيم المخطط. يوضح هذا الكود Java العملية:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة الشائعة**

**كيف يمكنني تعيين القيمة التي يتقاطع عندها أحد المحاور مع الآخر (تقاطع المحاور)؟**

توفر المحاور إعدادًا للتقاطع [crossing setting](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-): يمكنك اختيار التقاطع عند الصفر، أو عند أقصى فئة/قيمة، أو عند قيمة عددية محددة. هذا مفيد لتحريك محور X للأعلى أو الأسفل أو لتسليط الضوء على خط أساس.

**كيف يمكنني وضع تسميات العلامات بالنسبة إلى المحور (بجانب، خارج، داخل)؟**

قم بتعيين [label position](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) إلى "cross" أو "outside" أو "inside". يؤثر ذلك على قابلية القراءة ويساعد في توفير المساحة، خاصةً في المخططات الصغيرة.