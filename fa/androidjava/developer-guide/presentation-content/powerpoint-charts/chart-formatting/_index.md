---
title: قالب‌بندی نمودارهای ارائه در اندروید
linktitle: قالب‌بندی نمودار
type: docs
weight: 60
url: /fa/androidjava/chart-formatting/
keywords:
- قالب‌بندی نمودار
- قالب‌بندی نمودار
- موجودیت نمودار
- ویژگی‌های نمودار
- تنظیمات نمودار
- گزینه‌های نمودار
- ویژگی‌های قلم
- حاشیهٔ گرد
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "در Aspose.Slides برای اندروید از طریق Java، قالب‌بندی نمودارها را بیاموزید و ارائه PowerPoint خود را با استایل حرفه‌ای و چشم‌نواز ارتقا دهید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه می‌توان نمودارها را در ارائه‌های PowerPoint با استفاده از Aspose.Slides قالب‌بندی کرد. این راهنما نشان می‌دهد که چگونه عناصر کلیدی نمودار مانند محورها، خطوط شبکه، عناوین، افسانه‌ها، ناحیه‌ رسم و پر کردن دیوارها را سفارشی کنید تا ظاهر و قابلیت خواندن داده‌های نمودار بهبود یابد.

همچنین نحوه تنظیم ویژگی‌های قلم برای متن نمودار، اعمال قالب‌های عددی پیش‌تنظیم‌شده و سفارشی به داده‌های نمودار، و فعال‌سازی گوشه‌های گرد برای ناحیه نمودار را نشان می‌دهد. این مثال‌ها نشان می‌دهند که چگونه می‌توان هم سبک بصری و هم نمایش داده‌های نمودار را در یک ارائه کنترل کرد.

## **قالب‌بندی موجودیت‌های نمودار**
Aspose.Slides برای Android از طریق Java به توسعه‌دهندگان امکان می‌دهد تا نمودارهای سفارشی را از ابتدا به اسلایدهای خود اضافه کنند. این مقاله توضیح می‌دهد که چگونه موجودیت‌های مختلف نمودار از جمله محور طبقه‌بند و محور مقدار را قالب‌بندی کنید.

Aspose.Slides برای Android از طریق Java یک API ساده برای مدیریت موجودیت‌های مختلف نمودار و قالب‌بندی آن‌ها با مقادیر سفارشی ارائه می‌دهد:

1. یک نمونه از کلاس [**ارائه**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. مرجع یک اسلاید را بر اساس شاخص آن دریافت کنید.
3. یک نمودار با داده‌های پیش‌فرض به همراه هر نوع دلخواه اضافه کنید (در این مثال از **ChartType.LineWithMarkers** استفاده می‌کنیم).
4. به محور مقدار (Value Axis) نمودار دسترسی پیدا کنید و ویژگی‌های زیر را تنظیم کنید:
   1. تنظیم **قالب خط** برای خطوط شبکه اصلی محور مقدار
   2. تنظیم **قالب خط** برای خطوط شبکه فرعی محور مقدار
   3. تنظیم **قالب عددی** برای محور مقدار
   4. تنظیم **حداقل، حداکثر، واحدهای اصلی و فرعی** برای محور مقدار
   5. تنظیم **ویژگی‌های متن** برای داده‌های محور مقدار
   6. تنظیم **عنوان** برای محور مقدار
   7. تنظیم **قالب خط** برای محور مقدار
5. به محور طبقه‌بند (Category Axis) نمودار دسترسی پیدا کنید و ویژگی‌های زیر را تنظیم کنید:
   1. تنظیم **قالب خط** برای خطوط شبکه اصلی محور طبقه‌بند
   2. تنظیم **قالب خط** برای خطوط شبکه فرعی محور طبقه‌بند
   3. تنظیم **ویژگی‌های متن** برای داده‌های محور طبقه‌بند
   4. تنظیم **عنوان** برای محور طبقه‌بند
   5. تنظیم **موقعیت برچسب** برای محور طبقه‌بند
   6. تنظیم **زاویه چرخش** برای برچسب‌های محور طبقه‌بند
6. به افسانه (Legend) نمودار دسترسی پیدا کنید و **ویژگی‌های متن** آن‌ها را تنظیم کنید
7. نمایش افسانه‌های نمودار بدون همپوشانی با نمودار
8. به **محور مقدار ثانویه** (Secondary Value Axis) دسترسی پیدا کنید و ویژگی‌های زیر را تنظیم کنید:
   1. فعال‌سازی **محور مقدار ثانویه**
   2. تنظیم **قالب خط** برای محور مقدار ثانویه
   3. تنظیم **قالب عددی** برای محور مقدار ثانویه
   4. تنظیم **حداقل، حداکثر، واحدهای اصلی و فرعی** برای محور مقدار ثانویه
9. اکنون اولین سری نمودار را بر روی محور مقدار ثانویه رسم کنید
10. رنگ پر کردن دیوار پس‌زمینه نمودار را تنظیم کنید
11. رنگ پر کردن ناحیه رسم نمودار را تنظیم کنید
12. ارائه اصلاح‌شده را در یک فایل PPTX ذخیره کنید

```java
// یک نمونه از کلاس Presentation ایجاد کنید
Presentation pres = new Presentation();
try {
    // دسترسی به اولین اسلاید
    ISlide slide = pres.getSlides().get_Item(0);

    // افزودن نمودار نمونه
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // تنظیم عنوان نمودار
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // تنظیم قالب خطوط شبکه اصلی برای محور مقدار
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // تنظیم قالب خطوط شبکه فرعی برای محور مقدار
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // تنظیم قالب عددی محور مقدار
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // تنظیم مقادیر حداکثر و حداقل نمودار
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // تنظیم ویژگی‌های متن محور مقدار
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // تنظیم عنوان محور مقدار
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // تنظیم قالب خطوط شبکه اصلی برای محور دسته‌بند
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // تنظیم قالب خطوط شبکه فرعی برای محور دسته‌بند
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // تنظیم ویژگی‌های متن محور دسته‌بند
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // تنظیم عنوان دسته‌بند
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // تنظیم موقعیت برچسب محور دسته‌بند
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // تنظیم زاویه چرخش برچسب محور دسته‌بند
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // تنظیم ویژگی‌های متن افسانه‌ها
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // نمایش افسانه‌های نمودار بدون همپوشانی با نمودار را تنظیم کنید

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // تنظیم محور مقدار ثانویه
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // تنظیم قالب عددی محور مقدار ثانویه
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // تنظیم مقادیر حداکثر و حداقل نمودار
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // تنظیم رنگ دیوار پشت نمودار
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // تنظیم رنگ ناحیه رسم
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // ذخیره ارائه
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم ویژگی‌های قلم برای یک نمودار**
Aspose.Slides برای Android از طریق Java امکان تنظیم ویژگی‌های مربوط به قلم برای نمودار را فراهم می‌کند. لطفاً مراحل زیر را برای تنظیم ویژگی‌های قلم برای نمودار دنبال کنید.

- شیء کلاس [**ارائه**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) را نمونه‌سازی کنید.
- نمودار را به اسلاید اضافه کنید.
- ارتفاع قلم را تنظیم کنید.
- ارائه اصلاح‌شده را ذخیره کنید.

نمونه مثال زیر ارائه شده است.

```java
// یک نمونه از کلاس Presentation ایجاد کنید
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    pres.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم قالب عددی**
Aspose.Slides برای Android از طریق Java یک API ساده برای مدیریت قالب داده‌های نمودار ارائه می‌دهد:

1. یک نمونه از کلاس [**ارائه**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
2. مرجع یک اسلاید را بر حسب شاخص آن دریافت کنید.
3. یک نمودار با داده‌های پیش‌فرض به همراه هر نوع دلخواه اضافه کنید (این مثال از **ChartType.ClusteredColumn** استفاده می‌کند).
4. قالب عددی پیش‌تنظیم‌شده را از مقادیر ممکن انتخاب کنید.
5. در هر سری نمودار، سلول داده‌های نمودار را پیمایش کنید و قالب عددی داده‌ها را تنظیم کنید.
6. ارائه را ذخیره کنید.
7. قالب عددی سفارشی را تنظیم کنید.
8. در هر سری نمودار، سلول داده‌های نمودار را پیمایش کنید و قالب عددی متفاوتی برای داده‌ها تعیین کنید.
9. ارائه را ذخیره کنید.

```java
// یک نمونه از کلاس Presentation ایجاد کنید
Presentation pres = new Presentation();
try {
    // به اولین اسلاید ارائه دسترسی پیدا کنید
    ISlide slide = pres.getSlides().get_Item(0);

    // افزودن یک نمودار ستونی خوشه‌ای پیش‌فرض
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // دسترسی به مجموعه سری‌های نمودار
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // پیمایش هر سری نمودار
    for (IChartSeries ser : series) 
    {
        // پیمایش هر سلول داده در سری
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // تنظیم قالب عددی
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // ذخیره ارائه
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

مقادیر قالب عددی پیش‌تنظیم‌شده ممکن به همراه شاخص پیش‌تنظیم آن‌ها که می‌توان استفاده کرد، در ذیل آمده است:

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
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **تنظیم حاشیه‌های گرد ناحیه نمودار**
Aspose.Slides برای Android از طریق Java پشتیبانی از تنظیم ناحیه نمودار را فراهم می‌کند. متدهای [**hasRoundedCorners**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChart#hasRoundedCorners--) و [**setRoundedCorners**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChart#setRoundedCorners-boolean-) به رابط [IChart](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChart) و کلاس [Chart](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Chart) افزوده شده‌اند.

1. شیء کلاس [**ارائه**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) را نمونه‌سازی کنید.
2. نمودار را به اسلاید اضافه کنید.
3. نوع پرکردن و رنگ پرکردن نمودار را تنظیم کنید.
4. ویژگی گوشه‌های گرد را به مقدار True تنظیم کنید.
5. ارائه اصلاح‌شده را ذخیره کنید.

نمونه مثال زیر ارائه شده است.

```java
// یک نمونه از کلاس Presentation ایجاد کنید
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**آیا می‌توانم پر شدن نیمه‌شفاف برای ستون‌ها/ناحیه‌ها تنظیم کنم در حالی که حاشیه‌ها اپاک هستند؟**

بله. شفافیت پرکردن و خطوط حاشیه به‌صورت جداگانه پیکربندی می‌شوند. این کار برای بهبود قابلیت خواندن شبکه و داده‌ها در تصاویر متراکم مفید است.

**چگونه می‌توانم با برچسب‌های داده که با هم همپوشانی دارند، مقابله کنم؟**

اندازه قلم را کاهش دهید، اجزای غیرضروری برچسب (مانند دسته‌ها) را غیرفعال کنید، موقعیت/جابجایی برچسب را تنظیم کنید، در صورت لزوم فقط برچسب‌های نقاط انتخابی را نمایش دهید، یا قالب را به «مقدار + افسانه» تغییر دهید.

**آیا می‌توانم پر کردن گرادیان یا الگو را به سری‌ها اعمال کنم؟**

بله. هر دو نوع پر کردن ثابت و گرادیان/الگو معمولاً در دسترس هستند. در عمل، از گرادیان‌ها به‌صورت کم استفاده کنید و ترکیب‌هایی که کنتراست را با شبکه و متن کاهش می‌دهد، پرهیز کنید.