---
title: سفارشی‌سازی محورها در نمودارهای ارائه‌ها با استفاده از جاوااسکریپت
linktitle: محور نمودار
type: docs
url: /fa/nodejs-java/chart-axis/
keywords:
- محور نمودار
- محور عمودی
- محور افقی
- سفارشی‌سازی محور
- دستکاری محور
- مدیریت محور
- ویژگی‌های محور
- بیشترین مقدار
- کمترین مقدار
- خط محور
- قالب تاریخ
- عنوان محور
- موقعیت محور
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید با استفاده از جاوااسکریپت و Aspose.Slides برای Node.js از طریق Java، محورها در نمودارهای ارائه‌های PowerPoint را برای گزارش‌ها و مصورسازی‌ها سفارشی کنید."
---
## **بررسی کلی**

این مقاله نحوهٔ سفارشی‌سازی محورها در نمودارهای Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه مقادیر واقعی محور را به‌دست آورید، داده‌ها را بین محورها جابجا کنید، محور عمودی یا افقی را برای نمودارهای خطی مخفی کنید، نوع محور دسته‌بندی را تغییر دهید، قالب تاریخ برای مقادیر محور دسته‌بندی تنظیم کنید، عنوان محور را بچرخانید، موقعیت محور را تعیین کنید و برچسب واحد را بر محور مقدار نمایش دهید.

## **دریافت بیشترین مقادیر روی محور عمودی در نمودارها**

Aspose.Slides for Node.js via Java به شما امکان می‌دهد مقدار حداقل و حداکثر روی محور عمودی را به‌دست آورید. این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. به اولین اسلاید دسترسی پیدا کنید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید.
4. مقدار حداکثر واقعی محور را دریافت کنید.
5. مقدار حداقل واقعی محور را دریافت کنید.
6. واحد اصلی واقعی محور را دریافت کنید.
7. واحد فرعی واقعی محور را دریافت کنید.
8. مقیاس واحد اصلی واقعی محور را دریافت کنید.
9. مقیاس واحد فرعی واقعی محور را دریافت کنید.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
    // ارائه را ذخیره می‌کند
    pres.save("MaxValuesVerticalAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **جابه‌جایی داده‌ها بین محورها**

Aspose.Slides به شما اجازه می‌دهد به سرعت داده‌ها را بین محورها جابجا کنید؛ داده‌های نمایش‌داده‌شده در محور عمودی (محور y) به محور افقی (محور x) منتقل می‌شوند و بالعکس.

این کد JavaScript نشان می‌دهد چگونه این کار را انجام دهید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    // سطرها و ستون‌ها را جابجا می‌کند
    chart.getChartData().switchRowColumn();
    // ارائه را ذخیره می‌کند
    pres.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **غیرفعال‌سازی محور عمودی برای نمودارهای خطی**

این کد JavaScript نشان می‌دهد چگونه محور عمودی را برای یک نمودار خطی مخفی کنید:

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

## **غیرفعال‌سازی محور افقی برای نمودارهای خطی**

این کد نشان می‌دهد چگونه محور افقی را برای یک نمودار خطی مخفی کنید:

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

## **تغییر محور دسته‌بندی**

با استفاده از ویژگی **CategoryAxisType** می‌توانید نوع محور دسته‌بندی مورد نظر خود (**date** یا **text**) را مشخص کنید. این کد JavaScript عملیات را نشان می‌دهد:

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

## **تنظیم قالب تاریخ برای مقدار محور دسته‌بندی**

Aspose.Slides for Node.js via Java به شما امکان می‌دهد قالب تاریخ برای یک مقدار محور دسته‌بندی را تنظیم کنید. عملیات در این کد JavaScript نشان داده شده است:

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

## **تنظیم زاویه چرخش برای عنوان محور نمودار**

Aspose.Slides for Node.js via Java به شما امکان می‌دهد زاویه چرخش برای عنوان محور نمودار را تنظیم کنید. این کد JavaScript عملیات را نشان می‌دهد:

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

## **تنظیم موقعیت محور در محور دسته‌بندی یا مقدار**

Aspose.Slides for Node.js via Java به شما امکان می‌دهد موقعیت محور را در یک محور دسته‌بندی یا مقدار تنظیم کنید. این کد JavaScript نشان می‌دهد چگونه این کار را انجام دهید:

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

## **فعال‌سازی نمایش برچسب واحد بر محور مقدار نمودار**

Aspose.Slides for Node.js via Java به شما امکان می‌دهد یک نمودار را طوری پیکربندی کنید که برچسب واحد را بر محور مقدار نمودار نشان دهد. این کد JavaScript عملیات را نشان می‌دهد:

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

## **سؤالات متداول**

**چگونه مقدار تقاطع یک محور با محور دیگر (axis crossing) را تنظیم کنم؟**

محورها یک [crossing setting](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/axis/setcrosstype/) ارائه می‌دهند: می‌توانید انتخاب کنید که در صفر، در حداکثر دسته/مقدار یا در یک مقدار عددی مشخص تقاطع کنند. این برای جابه‌جایی محور X به بالا یا پایین یا برای برجسته‌سازی یک خط پایه مفید است.

**چگونه می‌توانم برچسب‌های تیک را نسبت به محور (کناره، خارج، داخل) موقعیت‌دهی کنم؟**

[Label position](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/axis/setmajortickmark/) را به "cross"، "outside" یا "inside" تنظیم کنید. این بر خوانایی تأثیر می‌گذارد و به‌خصوص در نمودارهای کوچک به حفظ فضا کمک می‌کند.