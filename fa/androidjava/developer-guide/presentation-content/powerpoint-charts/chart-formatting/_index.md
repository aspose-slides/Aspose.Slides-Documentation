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
- خصوصیات نمودار
- تنظیمات نمودار
- گزینه‌های نمودار
- خصوصیات قلم
- حاشیه گرد
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "قالب‌بندی نمودارها را در Aspose.Slides برای اندروید با استفاده از جاوا بیاموزید و ارائه PowerPoint خود را با محورها، قلم‌ها، قالب‌های عددی سفارشی و حاشیه‌های گرد نمودار ارتقاء دهید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه نمودارها را در ارائه‌های PowerPoint با استفاده از Aspose.Slides قالب‌بندی کنیم. این مقاله نشان می‌دهد چگونه عناصر کلیدی نمودار مانند محورها، خطوط شبکه، عناوین، راهنماها، ناحیه رسم و پر کردن دیوارها را سفارشی‌سازی کنیم تا ظاهر و خوانایی داده‌های نمودار بهبود یابد.

همچنین نشان می‌دهد چگونه خصوصیات قلم برای متن نمودار تنظیم شود، قالب‌های عددی پیش‌تنظیم‌شده بر داده‌های نمودار اعمال گردد و گوشه‌های گرد برای ناحیه نمودار فعال شود. این مثال‌ها به‌صورت ترکیبی نشان می‌دهند چگونه سبک بصری و ارائه داده‌های نمودار را در یک ارائه کنترل کنیم.

برای پر کردن‌ها و خطوط جداگانه در بازه‌های صعودی و نزولی، به [مثال نمودار سهام](/slides/fa/androidjava/create-chart/#create-stock-charts) مراجعه کنید.

## **قالب‌بندی موجودیت‌های نمودار**

از [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) برای قالب‌بندی عناوین نمودار، محورها، خطوط شبکه، راهنماها و ناحیه رسم استفاده کنید. این مثال یک نمودار خطی با مارکرها و داده‌های پیش‌فرض ایجاد می‌کند، سپس سبک‌های متن و خط جداگانه‌ای برای محور مقدار و محور دسته‌بندی آن اعمال می‌نماید. اندازه قلم و ضخامت خطوط بر حسب پوینت مشخص شده‌اند؛ برچسب‌های دسته‌بندی با زاویه ۴۵ درجه چرخانده می‌شوند.

محور مقدار از متد [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) به‌صورت مستقل از سلول‌های منبع استفاده می‌کند. مقیاس آن از ‎-۲ تا ۱۵ است، با فاصله‌های اصلی ۲ و فاصله‌های فرعی ۰.۵. این مثال همچنین قالب‌بندی درصد را با متد [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setDisplayUnit-int-) که روی هزار تنظیم شده ترکیب می‌کند، بنابراین این تنظیمات را مطابق با معنای داده‌ها و مقیاس آن‌ها تنظیم کنید. راهنما به‌دلیل فراخوانی [setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegend/#setOverlay-boolean-) با مقدار `false` خارج از ناحیه رسم می‌ماند. پر کردن‌های دیوار پشتی و کف از طریق [getBackWall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getBackWall--) و [getFloor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getFloor--) پیکربندی می‌شوند، اما این سطوح تنها در نمودارهای سه‌بعدی قابل مشاهده‌اند.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    IChartPortionFormat valueAxisText = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    valueAxisText.setFontBold(NullableBool.True);
    valueAxisText.setFontHeight(16);
    valueAxisText.setFontItalic(NullableBool.True);
    valueAxisText.getFillFormat().setFillType(FillType.Solid);
    valueAxisText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen);
    valueAxisText.setLatinFont(new FontData("Times New Roman"));

    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valueAxisTitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valueAxisTitle.setText("Primary Axis");
    valueAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valueAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valueAxisTitle.getPortionFormat().setFontHeight(20);
    valueAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    valueAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 128, 0));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    IChartPortionFormat categoryAxisText = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    categoryAxisText.setFontBold(NullableBool.True);
    categoryAxisText.setFontHeight(16);
    categoryAxisText.setFontItalic(NullableBool.True);
    categoryAxisText.getFillFormat().setFillType(FillType.Solid);
    categoryAxisText.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    categoryAxisText.setLatinFont(new FontData("Arial"));

    chart.getAxes().getHorizontalAxis().setTitle(true);
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion categoryAxisTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    categoryAxisTitle.setText("Sample Category");
    categoryAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    categoryAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    categoryAxisTitle.getPortionFormat().setFontHeight(20);
    categoryAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    categoryAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    IChartPortionFormat legendText = chart.getLegend().getTextFormat().getPortionFormat();
    legendText.setFontBold(NullableBool.True);
    legendText.setFontHeight(16);
    legendText.setFontItalic(NullableBool.True);
    legendText.getFillFormat().setFillType(FillType.Solid);
    legendText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed);

    chart.getLegend().setOverlay(false);

    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan);

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم خصوصیات قلم برای یک نمودار**

اندازه قلم پیش‌فرض برای متن نمودار را از طریق [Chart.getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#getTextFormat--) تنظیم کنید. این مثال یک نمودار ستونی خوشه‌ای با قلم ۲۰ پوینت ایجاد می‌کند و با استفاده از متد [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) برچسب‌های مقدار را برای سری اول فعال می‌نماید. عناصر متنی با تنظیمات قلم صریح خود می‌توانند پیش‌فرض نمودار را بازنویسی کنند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **استفاده مجدد از قالب‌بندی فریم متن برای راهنمای نمودار**

برای مطابقت راهنما با عنوان اسلاید، قلم عنوان را از طریق [getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) در اولین پاراگراف تنظیم کنید. سپس بر روی قالب بازگردانده‌شده توسط [getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformattedtextcontainer/#getTextFormat--) راهنما، متد [copyFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextformat/#copyFrom-com.aspose.slides.ITextFrame-) را فراخوانی کنید. این متد تنظیمات فریم متن، قالب‌بندی اولین پاراگراف و خصوصیات قلم پیش‌فرض آن پاراگراف را کپی می‌کند. قالب‌بندی اعمال‌شده مستقیماً بر بخش‌های منفرد یا پاراگراف‌های بعدی فقط بر منبع محلی می‌ماند.

مثال از یک عنوان بولد، ۲۶ پوینت Calibri به رنگ نیلی به عنوان الگو استفاده می‌کند. پس از استایل‌دادن به راهنما، متد [copyTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextformat/#copyTo-com.aspose.slides.ITextFrame-) برای اعمال همان قالب‌بندی به یک کپشن جداگانه فراخوانی می‌شود.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape heading = shapes.addAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
    ITextFrame sourceTextFrame = heading.addTextFrame("Quarterly sales");
    IPortionFormat font = sourceTextFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    font.setLatinFont(new FontData("Calibri"));
    font.setFontHeight(26);
    font.setFontBold(NullableBool.True);
    font.getFillFormat().setFillType(FillType.Solid);
    font.getFillFormat().getSolidFillColor().setColor(Color.rgb(32, 64, 96));

    IChart chart = shapes.addChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
    chart.setStyle(StyleType.Style3);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.getCell(0, 0, 1).setValue("Retail");
    workbook.getCell(0, 0, 2).setValue("Online");
    workbook.getCell(0, 0, 3).setValue("Wholesale");
    for (int quarter = 1; quarter <= 4; quarter++) {
        workbook.getCell(0, quarter, 0).setValue("Q" + quarter);
    }

    chart.setLegend(true);
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    IChartTextFormat legendFormat = chart.getLegend().getTextFormat();
    legendFormat.copyFrom(sourceTextFrame);

    IAutoShape caption = shapes.addAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
    ITextFrame captionTextFrame = caption.addTextFrame("Sales in millions of dollars");
    legendFormat.copyTo(captionTextFrame);

    presentation.save("legend-formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

در ارائه ذخیره‌شده، راهنما و کپشن از نظر اندازه، وزن و رنگ با عنوان مطابقت دارند. راهنما همچنان نام‌های سری‌ها را نمایش می‌دهد و کپشن متن خود را حفظ می‌کند. اگر بخشی از کپشن قبلاً دارای اندازه قلم صریح باشد، آن اندازه بر پیش‌فرض پاراگراف کپی‌شده تقدم دارد.

| قبل از کپی | بعد از کپی |
| --- | --- |
| ![نمودار فروش فصلی با برچسب‌های راهنمایی سیاه معمولی و کپشن سیاه](legend-formatting-before.png) | ![نمودار همان با برچسب‌های راهنمایی بزرگ‌تر، بولد و نیلی و کپشن منطبق](legend-formatting.png) |

## **تنظیم قالب عددی**

از [IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-) برای اعمال یک قالب عددی داخلی به سلول‌های کارپوشه نمودار استفاده کنید. این مثال یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض پشتیبانی‌شده توسط سلول ایجاد می‌کند و ایندکس قالب ۱۰ (`0.00%`) را به هر سلول مقدار سری اعمال می‌نماید. این کار نحوه نمایش مقادیر را در کارپوشه بدون تغییر عددهای زیرین تغییر می‌دهد؛ برای مثال، ۰٫۲۵ به صورت ۲۵٫۰۰٪ نمایش داده می‌شود. قالب‌های محور و برچسب داده‌ها می‌توانند به‌صورت جداگانه پیکربندی شوند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    for (IChartSeries chartSeries : series)
    {
        for (IChartDataPoint dataPoint : chartSeries.getDataPoints())
        {
            dataPoint.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

جدول زیر فهرست ایندکس‌های قالب عددی داخلی همراه با قالب‌های نمایشی Excel برای محل (en-US) را نشان می‌دهد. رشته‌های قالب دقیق و نمایش آن‌ها می‌توانند بسته به برنامه و محل متفاوت باشند، به‌ویژه برای ارزها و تاریخ‌ها. برخی قالب‌های Excel نیز با پیش‌فرض‌های استاندارد OOXML تفاوت دارند، همان‌طور که در [یادداشت‌های پیاده‌سازی قالب عددی مایکروسافت](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) توضیح داده شده است.

| شاخص | قالب |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **تنظیم گوشه‌های گرد برای ناحیه نمودار**

متد [IChart.setRoundedCorners](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setRoundedCorners-boolean-) را با مقدار `true` فراخوانی کنید تا گوشه‌های ناحیه نمودار گرد شوند. این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند و از طریق [getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) رنگ خطی ثابت خاکستری و سبک تک‌خطی به مرز آن اختصاص می‌دهد قبل از ذخیرهٔ ارائه.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    presentation.save("out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ویرایش حاشیه‌نویسی‌های موجود در نمودار**

یک نمودار می‌تواند شامل اشکال سفارشی باشد، مانند یک حاشیه‌نویسی متنی که وضعیت گزارشی را توضیح می‌دهد. به این اشکال از طریق [IChart.getUserShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getUserShapes--) دسترسی داشته باشید؛ این متد همچنین در زیر [Chart.getUserShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#getUserShapes--) در مستندات API نمودار فهرست شده است. مجموعه‌ای که توسط [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) بازگردانده می‌شود، اشکال متعلق به نمودار را شامل می‌شود.

یک جعبه متنی معمولی که بر روی نمودار قرار می‌گیرد، به اسلاید تعلق دارد، حتی اگر شبیه بخشی از نمودار به‌نظر برسد. با تکرار روی [Slide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--)، نمودار و اشکال معمولی اسلاید یافت می‌شوند، اما اشکال فردی داخل نمودار فهرست نمی‌شوند. عناوین نمودار و برچسب‌های داده، عناصر جداگانهٔ نمودار هستند، نه حاشیه‌نویسی‌های سفارشی در این مجموعه.

فایل [chart-annotations.pptx](chart-annotations.pptx) را دانلود کنید و در پوشهٔ کاری برنامه بگذارید. اسلاید اول آن شامل یک نمودار با حاشیه‌نویسی بدون گروه «Preliminary results»، یک خط متعلق به نمودار و یک جعبه متنی اسلایدی «Slide overlay» است. مثال اولین نمودار آن اسلاید را پیدا می‌کند و حاشیه‌نویسی را به «Final results» تغییر می‌دهد وقتی گزارش آماده انتشار است. این مثال برای مجموعهٔ خالی بررسی می‌کند و فقط یک [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) با فریم متن غیر‌خالی برگرفته از [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#getTextFrame--) و متن مورد انتظار را ویرایش می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-annotations.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IChart) {
            chart = (IChart) shape;
            break;
        }
    }

    if (chart == null || chart.getUserShapes().getShapes().size() == 0) {
        System.out.println("No chart or chart-owned shapes found.");
        return;
    }

    boolean updated = false;
    for (IShape shape : chart.getUserShapes().getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape annotation = (IAutoShape) shape;
            if (annotation.getTextFrame() != null && "Preliminary results".equals(annotation.getTextFrame().getText())) {
                annotation.getTextFrame().setText("Final results");
                updated = true;
                break;
            }
        }
    }

    if (updated) {
        presentation.save("chart-annotations-updated.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No matching text annotation found.");
    }
} finally {
    presentation.dispose();
}
```

خط و جعبهٔ متنی اسلاید بدون تغییر باقی می‌مانند. تصاویر زیر ورودی و نتیجهٔ ذخیره‌شده و باز شده را نشان می‌دهند:

| قبل از ویرایش | بعد از ویرایش |
| --- | --- |
| ![حاشیه‌نویسی نمودار با متن Preliminary results](chart-annotations-before.png) | ![حاشیه‌نویسی نمودار با متن Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
مثال فقط شکل‌های سطح‑بالای متعلق به نمودار را بررسی می‌کند. اگر حاشیه‌نویسی داخل یک [IGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/) باشد، مجموعهٔ [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) همان گروه را نیز بررسی کنید. این کار را به‌صورت بازگشتی برای گروه‌های تو در تو انجام دهید و همان چک‌های متنی را بر روی اشکال فرزند اعمال کنید. یک گروه خود یک مخزن است؛ آن را به‌عنوان جعبهٔ متن در نظر نگیرید.
{{% /alert %}}

## **سوالات متداول**

**آیا می‌توانم پر کردن‌های نیمه‌شفاف برای ستون‌ها/ناحیه‌ها داشته باشم در حالی که حاشیه را مات باقی می‌گذارم؟**

بله. شفافیت پر کردن و خطوط حاشیه به‌صورت جداگانه پیکربندی می‌شوند. این امر برای بهبود خوانایی شبکه و داده‌ها در نمایش‌های پرپیکسل مفید است.

**چگونه می‌توانم با برچسب‌های داده‌ای که هم‌پوشانی دارند برخورد کنم؟**

اندازه قلم را کاهش دهید، مؤلفه‌های غیرضروری برچسب (مانند دسته‌ها) را غیرفعال کنید، موقعیت برچسب را تنظیم کنید، در صورت لزوم فقط برای نقاط انتخابی برچسب را نشان دهید، یا قالب را به «مقدار + راهنما» تغییر دهید.

**آیا می‌توانم پر کردن‌های گرادیان یا الگو را برای سری‌ها اعمال کنم؟**

بله. سری‌ها از پر کردن‌های ثابت، گرادیان و الگو پشتیبانی می‌کنند. در عمل از گرادیان‌ها به‌صرفه استفاده کنید و ترکیب‌هایی که کنتراست را با شبکه و متن کاهش می‌دهند، جلوگیری کنید.