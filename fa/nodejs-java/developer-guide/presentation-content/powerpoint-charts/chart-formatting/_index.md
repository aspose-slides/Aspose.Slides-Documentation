---
title: قالب‌بندی نمودارهای ارائه در جاوااسکریپت
linktitle: قالب‌بندی نمودار
type: docs
weight: 60
url: /fa/nodejs-java/chart-formatting/
keywords:
- قالب‌بندی نمودار
- قالب‌بندی نمودار
- موجودیت نمودار
- ویژگی‌های نمودار
- تنظیمات نمودار
- گزینه‌های نمودار
- ویژگی‌های قلم
- حاشیه گرد
- PowerPoint
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "یاد بگیرید چگونه نمودارها را در Aspose.Slides برای Node.js با استفاده از جاوااسکریپت قالب‌بندی کنید و ارائه PowerPoint خود را با سبک حرفه‌ای و جذاب ارتقا دهید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه با استفاده از Aspose.Slides نمودارها را در ارائه‌های PowerPoint قالب‌بندی کنیم. نشان می‌دهد چگونه عناصر کلیدی نمودار مانند محورها، خطوط شبکه، عناوین، راهنماها، ناحیه‌ نمودار و پر کردن دیوارها را سفارشی‌سازی کنیم تا ظاهر و قابلیت خواندن داده‌های نمودار بهبود یابد.

همچنین نشان می‌دهد چگونه ویژگی‌های قلم برای متن نمودار تنظیم شود، قالب‌های عددی پیش‌فرض و سفارشی بر داده‌های نمودار اعمال شوند و گوشه‌های گرد برای ناحیه نمودار فعال شود. این مثال‌ها نشان می‌دهند چگونه هم سبک بصری و هم ارائه داده‌های نمودار در یک ارائه را کنترل کنیم.

## **قالب‌بندی موجودیت‌های نمودار**

Aspose.Slides for Node.js via Java به توسعه‌دهندگان اجازه می‌دهد نمودارهای سفارشی را از ابتدا به اسلایدهای خود اضافه کنند. این مقاله توضیح می‌دهد چگونه موجودیت‌های مختلف نمودار شامل محور دسته‌بندی و محور مقدار را قالب‌بندی کنیم.

Aspose.Slides for Node.js via Java یک API ساده برای مدیریت موجودیت‌های مختلف نمودار و قالب‌بندی آن‌ها با استفاده از مقادیر سفارشی فراهم می‌کند:

1. یک نمونه از کلاس [**Presentation**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلایدی را با استفاده از اندیس آن دریافت کنید.
1. یک نمودار با داده‌های پیش‌فرض به همراه هر نوع دلخواه اضافه کنید (در این مثال از ChartType.LineWithMarkers استفاده می‌کنیم).
1. به محور مقدار نمودار دسترسی پیدا کنید و ویژگی‌های زیر را تنظیم کنید:
   1. تنظیم **Line format** برای خطوط شبکهٔ بزرگ محور مقدار
   1. تنظیم **Line format** برای خطوط شبکهٔ کوچک محور مقدار
   1. تنظیم **Number Format** برای محور مقدار
   1. تنظیم **Min, Max, Major and Minor units** برای محور مقدار
   1. تنظیم **Text Properties** برای داده‌های محور مقدار
   1. تنظیم **Title** برای محور مقدار
   1. تنظیم **Line Format** برای محور مقدار
1. به محور دسته‌بندی نمودار دسترسی پیدا کنید و ویژگی‌های زیر را تنظیم کنید:
   1. تنظیم **Line format** برای خطوط شبکهٔ بزرگ محور دسته‌بندی
   1. تنظیم **Line format** برای خطوط شبکهٔ کوچک محور دسته‌بندی
   1. تنظیم **Text Properties** برای داده‌های محور دسته‌بندی
   1. تنظیم **Title** برای محور دسته‌بندی
   1. تنظیم **Label Positioning** برای محور دسته‌بندی
   1. تنظیم **Rotation Angle** برای برچسب‌های محور دسته‌بندی
1. به راهنما (Legend) نمودار دسترسی پیدا کنید و **Text Properties** آن‌ها را تنظیم کنید.
1. نمایش راهنمای نمودار بدون همپوشانی با نمودار را فعال کنید.
1. به **Secondary Value Axis** نمودار دسترسی پیدا کنید و ویژگی‌های زیر را تنظیم کنید:
   1. فعال‌سازی **Value Axis** ثانویه
   1. تنظیم **Line Format** برای محور مقدار ثانویه
   1. تنظیم **Number Format** برای محور مقدار ثانویه
   1. تنظیم **Min, Max, Major and Minor units** برای محور مقدار ثانویه
1. حال سری اول نمودار را روی محور مقدار ثانویه رسم کنید.
1. رنگ پر شدن دیوار پشت نمودار را تنظیم کنید.
1. رنگ پر شدن ناحیهٔ نمودار را تنظیم کنید.
1. ارائهٔ اصلاح‌شده را به فایل PPTX ذخیره کنید.

```javascript
// یک نمونه از کلاس Presentation ایجاد کنید
var pres = new aspose.slides.Presentation();
try {
    // دسترسی به اولین اسلاید
    var slide = pres.getSlides().get_Item(0);
    // اضافه کردن نمودار نمونه
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);
    // تنظیم عنوان نمودار
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    var chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // تنظیم قالب خطوط شبکهٔ بزرگ برای محور مقدار
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // تنظیم قالب خطوط شبکهٔ کوچک برای محور مقدار
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // تنظیم قالب عددی محور مقدار
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");
    // تنظیم مقادیر حداکثر و حداقل نمودار
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getVerticalAxis().setMaxValue(15.0);
    chart.getAxes().getVerticalAxis().setMinValue(-2.0);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);
    // تنظیم ویژگی‌های متنی محور مقدار
    var txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(aspose.slides.NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(aspose.slides.NullableBool.True);
    txtVal.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtVal.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkGreen));
    txtVal.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // تنظیم عنوان محور مقدار
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    var valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // تنظیم قالب خطوط شبکهٔ بزرگ برای محور دسته‌بندی
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    // تنظیم قالب خطوط شبکهٔ کوچک برای محور دسته‌بندی
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // تنظیم ویژگی‌های متنی محور دسته‌بندی
    var txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(aspose.slides.NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(aspose.slides.NullableBool.True);
    txtCat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtCat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    txtCat.setLatinFont(new aspose.slides.FontData("Arial"));
    // تنظیم عنوان دسته‌بندی
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");
    var catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // تنظیم موقعیت برچسب محور دسته‌بندی
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    // تنظیم زاویه چرخش برچسب محور دسته‌بندی
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);
    // تنظیم ویژگی‌های متنی راهنماها
    var txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(aspose.slides.NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(aspose.slides.NullableBool.True);
    txtleg.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtleg.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkRed));
    // نمایش راهنماهای نمودار بدون همپوشانی با نمودار
    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;
    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // تنظیم محور مقدار ثانویه
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);
    // تنظیم قالب عددی محور مقدار ثانویه
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");
    // تنظیم مقادیر حداکثر و حداقل نمودار
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0);
    // تنظیم رنگ دیوار پشت نمودار
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // تنظیم رنگ ناحیهٔ رسم
    chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.LightCyan));
    // ذخیرهٔ ارائه
    pres.save("FormattedChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تنظیم ویژگی‌های قلم برای نمودار**

Aspose.Slides for Node.js via Java پشتیبانی از تنظیم ویژگی‌های مربوط به قلم برای نمودار را فراهم می‌کند. لطفاً مراحل زیر را برای تنظیم ویژگی‌های قلم برای نمودار دنبال کنید.

- یک شیء از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
- یک نمودار به اسلاید اضافه کنید.
- ارتفاع قلم را تنظیم کنید.
- ارائهٔ اصلاح‌شده را ذخیره کنید.

یک نمونهٔ کد زیر ارائه شده است.

```javascript
// یک نمونه از کلاس Presentation ایجاد کنید
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    pres.save("FontPropertiesForChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تنظیم قالب عددی**

Aspose.Slides for Node.js via Java یک API ساده برای مدیریت قالب داده‌های نمودار فراهم می‌کند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
1. مرجع اسلایدی را با استفاده از اندیس آن دریافت کنید.
1. یک نمودار با داده‌های پیش‌فرض به همراه هر نوع دلخواه اضافه کنید (در این مثال از **ChartType.ClusteredColumn** استفاده می‌شود).
1. قالب عددی پیش‌فرض را از مقادیر پیش‌فرض موجود تنظیم کنید.
1. در هر سری نمودار، به سلول دادهٔ نمودار دسترسی پیدا کنید و قالب عددی دادهٔ نمودار را تنظیم کنید.
1. ارائه را ذخیره کنید.
1. قالب عددی سفارشی را تنظیم کنید.
1. در هر سری نمودار، به سلول دادهٔ نمودار دسترسی پیدا کنید و قالب عددی متفاوتی تنظیم کنید.
1. ارائه را ذخیره کنید.

```javascript
// یک نمونه از کلاس Presentation ایجاد کنید
var pres = new aspose.slides.Presentation();
try {
    // دسترسی به اولین اسلاید ارائه
    var slide = pres.getSlides().get_Item(0);
    // اضافه کردن یک نمودار ستونی خوشه‌ای پیش‌فرض
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    // دسترسی به مجموعه سری‌های نمودار
    var series = chart.getChartData().getSeries();
    // پیمایش در هر سری نمودار
    for (var i = 0; i < series.size(); i++) {
        var ser = series.get_Item(i);
        // پیمایش در هر سلول داده در سری
        for (var j = 0; j < ser.getDataPoints().size(); j++) {
            var cell = ser.getDataPoints().get_Item(j);
            // تنظیم قالب عددی
            cell.getValue().getAsCell().setPresetNumberFormat(java.newByte(10));// 0.00%
        }
    }
    // ذخیرهٔ ارائه
    pres.save("PresetNumberFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

مقادیر قابل استفاده برای قالب عددی پیش‌فرض به همراه ایندکس پیش‌فرض آن‌ها در زیر آورده شده است:

|**0**|عمومی|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **تنظیم گوشه‌های گرد ناحیه نمودار**

Aspose.Slides for Node.js via Java پشتیبانی از تنظیم ناحیهٔ نمودار را فراهم می‌کند. متدهای [**hasRoundedCorners**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Chart#hasRoundedCorners--) و [**setRoundedCorners**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Chart#setRoundedCorners-boolean-) به کلاس [Chart](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Chart) افزوده شده‌اند.

1. یک شیء از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
1. یک نمودار به اسلاید اضافه کنید.
1. نوع پر و رنگ پر نمودار را تنظیم کنید.
1. ویژگی گوشهٔ گرد را به مقدار True تنظیم کنید.
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

یک نمونهٔ کد زیر ارائه شده است.

```javascript
// یک نمونه از کلاس Presentation ایجاد کنید
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getLineFormat().setStyle(aspose.slides.LineStyle.Single);
    chart.setRoundedCorners(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سوالات متداول**

**آیا می‌توانم پرهای نیمه‌شفاف برای ستون‌ها/ناحیه‌ها تنظیم کنم در حالی که حاشیه را مات نگه می‌دارم؟**

بله. شفافیت پر و خطوط حاشیه به‌صورت جداگانه پیکربندی می‌شوند. این کار برای بهبود قابلیت خواندن شبکه و داده‌ها در تجسم‌های پرتراکم مفید است.

**وقتی برچسب‌های داده هم‌پوشانی دارند، چگونه باید اقدام کنم؟**

اندازهٔ قلم را کاهش دهید، مؤلفه‌های غیرضروری برچسب (مانند دسته‌ها) را غیرفعال کنید، آفست/موقعیت برچسب را تنظیم کنید، در صورت نیاز فقط برای نقاط انتخاب‌شده برچسب‌ها را نمایش دهید یا قالب را به «مقدار + راهنما» تغییر دهید.

**آیا می‌توانم پرهای گرادیانی یا الگو را برای سری‌ها اعمال کنم؟**

بله. هر دو نوع پرهای یکدانه و گرادیان/الگو معمولاً در دسترس هستند. در عمل، از گرادیان‌ها به‌طور مقتصدانه استفاده کنید و ترکیب‌هایی که کنتراست با شبکه و متن را کاهش می‌دهند، پرهیز کنید.