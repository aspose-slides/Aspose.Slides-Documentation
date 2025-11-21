---
title: محور المخطط
type: docs
url: /ar/nodejs-java/chart-axis/
keywords: "محور مخطط PowerPoint, مخططات العرض التقديمي, Java, تعديل محور المخطط, بيانات المخطط"
description: "كيفية تعديل محور مخطط PowerPoint في JavaScript"
---

## **الحصول على القيم القصوى على المحور العمودي في المخططات**

تتيح لك Aspose.Slides لـ Node.js عبر Java الحصول على القيم الدنيا والعظمى على المحور العمودي. اتبع هذه الخطوات:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. الوصول إلى الشريحة الأولى.
3. إضافة مخطط ببيانات افتراضية.
4. الحصول على القيمة العظمى الفعلية للمحور.
5. الحصول على القيمة الدنيا الفعلية للمحور.
6. الحصول على الوحدة الرئيسية الفعلية للمحور.
7. الحصول على الوحدة الثانوية الفعلية للمحور.
8. الحصول على مقياس الوحدة الرئيسية الفعلي للمحور.
9. الحصول على مقياس الوحدة الثانوية الفعلي للمحور.

يعرض لك رمز العينة هذا—تنفيذ الخطوات أعلاه—كيفية الحصول على القيم المطلوبة في JavaScript:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
    // يحفظ العرض التقديمي
    pres.save("MaxValuesVerticalAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تبديل البيانات بين المحاور**

تتيح لك Aspose.Slides تبديل البيانات بين المحاور بسرعة—البيانات الموجودة على المحور العمودي (المحور y) تنتقل إلى المحور الأفقي (المحور x) والعكس.

يعرض لك رمز JavaScript هذا كيفية تنفيذ مهمة تبديل البيانات بين المحاور في مخطط:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    // يبدل الصفوف والأعمدة
    chart.getChartData().switchRowColumn();
    // يحفظ العرض التقديمي
    pres.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إلغاء تفعيل المحور العمودي لمخططات الخط**

يعرض لك رمز JavaScript هذا كيفية إخفاء المحور العمودي لمخطط خط:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إلغاء تفعيل المحور الأفقي لمخططات الخط**

يعرض لك هذا الرمز كيفية إخفاء المحور الأفقي لمخطط خط:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تغيير محور الفئة**

باستخدام الخاصية **CategoryAxisType**، يمكنك تحديد نوع محور الفئة المفضل لديك (**date** أو **text**). يوضح لك هذا الرمز في JavaScript العملية:
```javascript
var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);
    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **تعيين تنسيق التاريخ لقيمة محور الفئة**

تتيح لك Aspose.Slides لـ Node.js عبر Java تعيين تنسيق التاريخ لقيمة محور الفئة. يتم عرض العملية في هذا الرمز في JavaScript:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 450, 300);
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(java.newInstanceSync("GregorianCalendar", 2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(java.newInstanceSync("GregorianCalendar", 2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(java.newInstanceSync("GregorianCalendar", 2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(java.newInstanceSync("GregorianCalendar", 2018, 1, 1))));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
const dayjs = require('dayjs');

function convertToOADate(date) {
    const baseDate = dayjs('1899-12-30');

    const days = date.diff(baseDate, 'day');

    const fractionalDay = (date.hour() / 24) +
                          (date.minute() / (60 * 24)) +
                          (date.second() / (60 * 24 * 60));

    const oaDate = days + fractionalDay;

    return String(oaDate);
}
```


## **تعيين زاوية الدوران لعنوان محور المخطط**

تتيح لك Aspose.Slides لـ Node.js عبر Java تعيين زاوية الدوران لعنوان محور المخطط. يوضح لك هذا الرمز في JavaScript العملية:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تعيين موقع المحور في محور الفئة أو القيمة**

تتيح لك Aspose.Slides لـ Node.js عبر Java تعيين موقع المحور في محور الفئة أو القيمة. يوضح لك هذا الرمز في JavaScript كيفية تنفيذ المهمة:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تمكين عرض وحدة التسمية على محور قيمة المخطط**

تتيح لك Aspose.Slides لـ Node.js عبر Java تكوين المخطط لعرض علامة وحدة على محور قيم المخطط. يوضح لك هذا الرمز في JavaScript العملية:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**كيف يمكنني تعيين القيمة التي يتقاطع عندها محور مع الآخر (تقاطع المحاور)؟**

توفر المحاور إعدادًا لتقاطع المحاور [crossing setting](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/): يمكنك اختيار التقاطع عند الصفر، أو عند الفئة/القيمة القصوى، أو عند قيمة رقمية محددة. يكون ذلك مفيدًا لتحريك محور X أعلاه أو أسفله أو لتسليط الضوء على خط الأساس.

**كيف يمكنني وضع تسميات الفواصل بالنسبة إلى المحور (بجانب، خارج، داخل)؟**

قم بتعيين [label position](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) إلى "cross" أو "outside" أو "inside". يؤثر ذلك على قابلية القراءة ويساعد في توفير المساحة، خصوصًا في المخططات الصغيرة.