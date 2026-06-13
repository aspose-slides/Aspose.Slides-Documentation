---
title: قالب‌سازی نمودارهای ارائه در جاوا
linktitle: قالب‌سازی نمودار
type: docs
weight: 60
url: /fa/java/chart-formatting/
keywords:
- قالب نمودار
- قالب‌سازی نمودار
- موجودیت نمودار
- ویژگی‌های نمودار
- تنظیمات نمودار
- گزینه‌های نمودار
- ویژگی‌های قلم
- حاشیه گرد
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: "قالب‌سازی نمودارها را در Aspose.Slides برای جاوا بیاموزید و ارائهٔ پاورپوینت خود را با سبک‌های حرفه‌ای و چشم‌نواز بهبود بخشید."
---
## **Overview**

این مقاله توضیح می‌دهد چگونه نمودارها را در ارائه‌های PowerPoint با استفاده از Aspose.Slides قالب‌بندی کنیم. همچنین نشان می‌دهد چگونه عناصر کلیدی نمودار مانند محورها، خطوط شبکه، عناوین، افسانه‌ها، ناحیه ترسیم و پر کردن دیوارها را سفارشی کنیم تا ظاهر و قابلیت خواندن داده‌های نمودار بهبود یابد.

همچنین نحوه تنظیم ویژگی‌های قلم برای متن نمودار، اعمال قالب‌های عددی پیش‌فرض و سفارشی به داده‌های نمودار و فعال‌سازی گوشه‌های گرد برای ناحیه نمودار را نشان می‌دهد. این نمونه‌ها نشان می‌دهند چگونه می‌توان سبک بصری و ارائه داده‌های نمودار را در یک ارائه کنترل کرد.

## **Format Chart Entities**
Aspose.Slides for Java به توسعه‌دهندگان امکان می‌دهد نمودارهای سفارشی را از ابتدا به اسلایدهای خود اضافه کنند. این مقاله نحوه قالب‌بندی موجودیت‌های مختلف نمودار از جمله محور دسته‌بندی و محور مقدار را توضیح می‌دهد.

Aspose.Slides for Java یک API ساده برای مدیریت موجودیت‌های مختلف نمودار و قالب‌بندی آن‌ها با مقادیر سفارشی فراهم می‌کند:

1. یک نمونه از کلاس [**Presentation**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید را بر اساس اندیس آن به‌دست آورید.
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع دلخواه را انتخاب کنید (در این مثال از ChartType.LineWithMarkers استفاده می‌کنیم).
1. به محور مقدار نمودار دسترسی یافته و ویژگی‌های زیر را تنظیم کنید:
   1. تنظیم **Line format** برای خطوط شبکه اصلی محور مقدار
   1. تنظیم **Line format** برای خطوط شبکه فرعی محور مقدار
   1. تنظیم **Number Format** برای محور مقدار
   1. تنظیم **Min, Max, Major and Minor units** برای محور مقدار
   1. تنظیم **Text Properties** برای داده‌های محور مقدار
   1. تنظیم **Title** برای محور مقدار
   1. تنظیم **Line Format** برای محور مقدار
1. به محور دسته‌بندی نمودار دسترسی یافته و ویژگی‌های زیر را تنظیم کنید:
   1. تنظیم **Line format** برای خطوط شبکه اصلی محور دسته‌بندی
   1. تنظیم **Line format** برای خطوط شبکه فرعی محور دسته‌بندی
   1. تنظیم **Text Properties** برای داده‌های محور دسته‌بندی
   1. تنظیم **Title** برای محور دسته‌بندی
   1. تنظیم **Label Positioning** برای محور دسته‌بندی
   1. تنظیم **Rotation Angle** برای برچسب‌های محور دسته‌بندی
1. به افسانه نمودار دسترسی یافته و **Text Properties** آن‌ها را تنظیم کنید
1. نمایش افسانه‌های نمودار بدون همپوشانی با نمودار
1. به **Secondary Value Axis** دسترسی یافته و ویژگی‌های زیر را تنظیم کنید:
   1. فعال‌سازی **Value Axis** ثانویه
   1. تنظیم **Line Format** برای محور مقدار ثانویه
   1. تنظیم **Number Format** برای محور مقدار ثانویه
   1. تنظیم **Min, Max, Major and Minor units** برای محور مقدار ثانویه
1. الآن سری اول نمودار را بر روی محور مقدار ثانویه ترسیم کنید
1. رنگ پر کردن دیوار پشت نمودار را تنظیم کنید
1. رنگ پر کردن ناحیه ترسیم نمودار را تنظیم کنید
1. ارائه اصلاح‌شده را در یک فایل PPTX ذخیره کنید

```java
// یک نمونه از کلاس Presentation ایجاد کنید
Presentation pres = new Presentation();
try {
    // دسترسی به اسلاید اول
    ISlide slide = pres.getSlides().get_Item(0);

    // اضافه کردن نمودار نمونه
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

    // تنظیم حداکثر و حداقل مقادیر نمودار
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

    // تنظیم قالب خطوط شبکه اصلی برای محور دسته‌بندی
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // تنظیم قالب خطوط شبکه فرعی برای محور دسته‌بندی
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // تنظیم ویژگی‌های متن محور دسته‌بندی
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // تنظیم عنوان دسته‌بندی
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // تنظیم موقعیت برچسب‌های محور دسته‌بندی
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // تنظیم زاویه چرخش برچسب‌های محور دسته‌بندی
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // تنظیم ویژگی‌های متن افسانه‌ها
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // نمایش افسانه‌های نمودار بدون همپوشانی با نمودار

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

    // تنظیم حداکثر و حداقل مقادیر نمودار
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
    // تنظیم رنگ ناحیه ترسیم
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // ذخیرهٔ ارائه
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Font Properties for a Chart**
Aspose.Slides for Java پشتیبانی از تنظیم ویژگی‌های مربوط به قلم برای نمودار را فراهم می‌کند. لطفاً مراحل زیر را برای تنظیم ویژگی‌های قلم نمودار دنبال کنید.

- شیء کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) را نمونه‌سازی کنید.
- یک نمودار به اسلاید اضافه کنید.
- ارتفاع قلم را تنظیم کنید.
- ارائه اصلاح‌شده را ذخیره کنید.

نمونه کد زیر ارائه شده است.

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

## **Set the Numeric Format**
Aspose.Slides for Java یک API ساده برای مدیریت قالب داده‌های نمودار ارائه می‌دهد:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
1. مرجع اسلاید را بر اساس اندیس آن به‌دست آورید.
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع دلخواه را انتخاب کنید (در این مثال از **ChartType.ClusteredColumn** استفاده می‌شود).
1. قالب عددی پیش‌فرض را از مقادیر پیش‌فرض موجود تنظیم کنید.
1. در هر سری نمودار، سلول داده‌های نمودار را پیمایش کرده و قالب عددی داده‌ها را تنظیم کنید.
1. ارائه را ذخیره کنید.
1. قالب عددی سفارشی را تنظیم کنید.
1. در هر سری نمودار، سلول داده‌های نمودار را پیمایش کرده و قالب عددی متفاوتی را تنظیم کنید.
1. ارائه را ذخیره کنید.

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
    
    // پیمایش در تمام سری‌های نمودار
    for (IChartSeries ser : series) 
    {
        // پیمایش در تمام سلول‌های داده‌ای سری
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // تنظیم قالب عددی
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // ذخیرهٔ ارائه
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

مقادیر ممکن برای قالب عددی پیش‌فرض به همراه شاخص پیش‌فرض آن‌ها در جدول زیر آورده شده است:

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

## **Set Chart Area Rounded Borders**
Aspose.Slides for Java پشتیبانی از تنظیم ناحیه نمودار را فراهم می‌کند. متدهای [**hasRoundedCorners**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChart#hasRoundedCorners--) و [**setRoundedCorners**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChart#setRoundedCorners-boolean-) به اینترفیس [IChart](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChart) و کلاس [Chart](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Chart) افزوده شده‌اند.

1. شیء کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) را نمونه‌سازی کنید.
1. یک نمودار به اسلاید اضافه کنید.
1. نوع و رنگ پر کردن نمودار را تنظیم کنید.
1. خاصیت گوشه‌های گرد را به مقدار True تنظیم کنید.
1. ارائه اصلاح‌شده را ذخیره کنید.

نمونه کد زیر ارائه شده است.

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

## **FAQ**

**Can I set semi-transparent fills for columns/areas while keeping the border opaque?**

بله. شفافیت پر کردن و خط‌کشی به‌صورت جداگانه پیکربندی می‌شوند. این ویژگی برای بهبود قابلیت خواندن شبکه و داده‌ها در تجسم‌های متراکم مفید است.

**How can I deal with data labels when they overlap?**

اندازه قلم را کاهش دهید، اجزای غیرضروری برچسب‌ها (مانند دسته‌ها) را غیرفعال کنید، موقعیت/جابجایی برچسب را تنظیم کنید، در صورت نیاز فقط برچسب‌های نقاط منتخب را نمایش دهید یا قالب را به «مقدار + افسانه» تغییر دهید.

**Can I apply gradient or pattern fills to series?**

بله. پر کردن‌های تک‌رنگ و گرادیان/الگو معمولاً موجود هستند. در عمل، گرادیان‌ها را به‌کاربرد کم استفاده کنید و از ترکیب‌های کاهنده کنتراست با شبکه و متن خودداری کنید.