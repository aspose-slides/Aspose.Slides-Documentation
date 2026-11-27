---
title: قالب‌بندی نمودارهای ارائه در جاوا
linktitle: قالب‌بندی نمودار
type: docs
weight: 60
url: /fa/java/chart-formatting/
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
- جاوا
- Aspose.Slides
description: "چگونگی قالب‌بندی نمودارها را در Aspose.Slides برای جاوا بیاموزید و ارائه PowerPoint خود را با محورها، قلم‌ها، قالب‌های عددی و حاشیه‌های گرد سفارشی‌سازی شده ارتقا دهید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با استفاده از Aspose.Slides نمودارها را در ارائه‌های PowerPoint قالب‌بندی کنید. این مقاله نشان می‌دهد که چگونه عناصر کلیدی نمودار مانند محورها، خطوط شبکه، عناوین، افسانه‌ها، ناحیه نمودار و پرکردن دیوارها را سفارشی کنید تا ظاهر و قابلیت خواندن داده‌های نمودار بهبود یابد.

همچنین نشان می‌دهد چگونه خصوصیات قلم برای متن نمودار تنظیم شود، قالب‌های عددی پیش‌فرض بر داده‌های نمودار اعمال شود و گوشه‌های گرد برای ناحیه نمودار فعال شود. این مثال‌ها نشان می‌دهند چگونه سبک بصری و ارائه داده‌های نمودارها در یک ارائه را کنترل کنید.

برای پرکردن‌ها و خطوط مرزی جداگانه در فواصل صعودی و نزولی، مثال [مثال نمودار سهام](/slides/fa/java/create-chart/#create-stock-charts) را ببینید.

## **قالب‌بندی موجودیت‌های نمودار**

از [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) برای قالب‌بندی عناوین نمودار، محورها، خطوط شبکه، افسانه‌ها و ناحیه نمودار استفاده کنید. این مثال یک نمودار خطی با نشانگرها و داده‌های پیش‌فرض ایجاد می‌کند و سپس سبک‌های متن و خط جداگانه‌ای را برای محور مقدار و محور دسته‌بندی اعمال می‌کند. اندازه قلم و ضخامت خطوط به پوینت مشخص شده‌اند؛ برچسب‌های دسته‌بندی با 45 درجه چرخانده می‌شوند.

محور مقدار از [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) مستقل از سلول‌های منبع استفاده می‌کند. مقیاس آن از ‑2 تا 15 است، با فواصل اصلی 2 و فواصل فرعی 0.5. این مثال همچنین قالب‌گذاری درصدی را با [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setDisplayUnit-int-) تنظیم شده بر هزارها ترکیب می‌کند، بنابراین این تنظیمات را به معنا و مقیاس داده‌های خود وفق دهید. افسانه به‌دلیل فراخوانی [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/ilegend/#setOverlay-boolean-) با `false` خارج از ناحیه نمودار می‌ماند. پرکردن‌های پشت‌دیوار و کف از طریق [getBackWall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--) و [getFloor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--) پیکربندی می‌شوند، اما این سطوح فقط در نمودارهای سه‌بعدی قابل مشاهده‌اند.

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
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
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(new Color(255, 165, 0));

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

اندازه قلم پیش‌فرض برای متن نمودار را از طریق [Chart.getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getTextFormat--) تنظیم کنید. این مثال یک نمودار ستونی خوشه‌ای با قلم 20 پوینت ایجاد می‌کند و برچسب‌های مقدار را برای سری اول از طریق [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) فعال می‌سازد. عناصر متنی با تنظیمات قلم صریح خود می‌توانند پیش‌فرض نمودار را نادیده بگیرند.

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

## **بازاستفاده از قالب‌بندی قاب متن برای افسانه نمودار**

برای مطابقت افسانه با عنوان اسلاید، قلم عنوان را از طریق [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) در اولین پاراگراف تنظیم کنید. سپس [copyFrom](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextformat/#copyFrom-com.aspose.slides.ITextFrame-) را بر روی قالب بازگردانده شده از [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iformattedtextcontainer/#getTextFormat--) افسانه فراخوانی کنید. این کار تنظیمات قاب متن، قالب‌بندی اولین پاراگراف و خصوصیات قلم پیش‌فرض آن پاراگراف را کپی می‌کند. قالب‌بندی اعمال‌شده مستقیم به بخش‌های فردی یا به پاراگراف‌های بعدی فقط به منبع محلی می‌ماند.

مثال از یک عنوان بولد، 26 پوینت Calibri با رنگ سرمئی به‌عنوان قالب استفاده می‌کند. پس از استایل‌دهی به افسانه، [copyTo](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextformat/#copyTo-com.aspose.slides.ITextFrame-) را فراخوانی می‌کنیم تا همان قالب به یک زیرنویس جداگانه اعمال شود.

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    font.getFillFormat().getSolidFillColor().setColor(new Color(32, 64, 96));

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

در ارائه ذخیره‌شده، افسانه و زیرنویس از نظر اندازه، وزن و رنگ با عنوان مطابقت دارند. افسانه هنوز نام‌های سری‌ها را نشان می‌دهد و زیرنویس متن خود را حفظ می‌کند. اگر بخشی در زیرنویس قبلاً اندازه قلم صریح داشته باشد، آن اندازه بر پیش‌فرض پاراگراف کپی‌شده اولویت دارد.

| قبل از کپی | بعد از کپی |
| --- | --- |
| ![نمودار فروش فصلی با برچسب‌های افسانه سیاه عادی و زیرنویس سیاه](legend-formatting-before.png) | ![نمودار مشابه با برچسب‌های افسانه بزرگتر، توپر نیرویی و زیرنویس منطبق](legend-formatting.png) |

## **تنظیم قالب عددی**

از [IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-) برای اعمال قالب عددی پیش‌ساخته به سلول‌های کتاب‌عمل نمودار استفاده کنید. این مثال یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض و پشتیبانی سلولی ایجاد می‌کند و ایندکس قالب 10 (`0.00%`) را به هر سلول مقدار سری اعمال می‌نماید. این کار نحوه نمایش مقادیر را در کتاب‌کار بدون تغییر اعداد پایه تغییر می‌دهد؛ برای مثال 0.25 به صورت 25.00% نمایش داده می‌شود. قالب‌های محور و برچسب‌های داده می‌توانند جداگانه پیکربندی شوند.

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

جدول زیر فهرست ایندکس‌های قالب عددی پیش‌ساخته را با قالب‌های نمایشی Excel برای تنظیمات محلی انگلیسی (ایالات متحده) نشان می‌دهد. رشته‌های قالب دقیق و نمایش آن می‌تواند بسته به برنامه و تنظیمات محلی متفاوت باشد، به‌ویژه برای ارزها و تاریخ‌ها. برخی قالب‌های Excel نیز با پیش‌فرض‌های استاندارد OOXML متفاوت هستند، همان‌طور که در [یادداشت‌های پیاده‌سازی قالب عددی مایکروسافت](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) توضیح داده شده است.

| شناسه | قالب |
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

## **تنظیم گوشه‌های گرد ناحیه نمودار**

با فراخوانی [IChart.setRoundedCorners](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setRoundedCorners-boolean-) با مقدار `true`، گوشه‌های ناحیه نمودار را گرد کنید. این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند و از [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) برای رنگ خاکستری ثابت و سبک خط تک استفاده می‌کند قبل از ذخیره‌سازی ارائه.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **ویرایش حواشی موجود نمودار**

یک نمودار می‌تواند اشکال سفارشی مانند حاشیه متنی که وضعیت گزارش را توضیح می‌دهد، داشته باشد. به این اشکال از طریق [IChart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getUserShapes--) که همچنین تحت [Chart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getUserShapes--) در مرجع API نمودار آمده است، دسترسی پیدا کنید. مجموعه‌ای که توسط [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) برگردانده می‌شود، اشکال متعلق به نمودار را شامل می‌شود.

یک کادر متن عادی که بر روی نمودار قرار می‌گیرد، به اسلاید تعلق دارد، حتی اگر شبیه بخشی از نمودار به‌نظر برسد. پیمایش [Slide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) نمودار و اشکال عادی اسلاید را پیدا می‌کند اما اشکال فردی داخل نمودار را فهرست نمی‌کند. عناوین نمودار و برچسب‌های داده المان‌های جداگانه‌ای هستند، نه حاشیه‌های سفارشی در این مجموعه.

فایل [chart-annotations.pptx](chart-annotations.pptx) را دانلود کنید و در پوشه کاری برنامه قرار دهید. اسلاید اول آن حاوی نموداری با حاشیه‌ی غیرگروه‌شده‌ای به متن «Preliminary results»، خط متعلق به نمودار و کادر متن عادی اسلاید با متن «Slide overlay» است. مثال اولین نمودار موجود در آن اسلاید را پیدا می‌کند و حاشیه را به «Final results» تغییر می‌دهد وقتی گزارش آماده انتشار باشد. ابتدا بررسی می‌شود که مجموعه خالی نیست و سپس فقط یک [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) با فریم متنی غیر خالی که توسط [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#getTextFrame--) بازگردانده می‌شود و متن مورد انتظار دارد، ویرایش می‌شود.

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

خط و کادر متن اسلاید بدون تغییر می‌مانند. تصاویر زیر ورودی و نتیجه‌ی ذخیره‑شده را نشان می‌دهند:

| قبل از ویرایش | بعد از ویرایش |
| --- | --- |
| ![حاشیه نمودار با متن Preliminary results](chart-annotations-before.png) | ![حاشیه نمودار با متن Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
مثال فقط به اشکال سطح بالای متعلق به نمودار نگاه می‌کند. اگر حاشیه‌ای داخل یک [IGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/) باشد، مجموعه‌ی [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) آن گروه را نیز بررسی کنید. این کار را به‌صورت بازگشتی برای گروه‌های تو در تو تکرار کنید و همان بررسی‌های متن را بر روی اشکال فرزندشان اعمال کنید. یک گروه خودش یک محفظه است؛ آن را به‌عنوان کادر متن در نظر نگیرید.
{{% /alert %}}

## **پرسش‌های متداول**

**آیا می‌توانم پرکردن نیمه‌شفاف برای ستون‌ها/ناحیه‌ها تنظیم کنم در حالی که لبه آن مات باقی بماند؟**

بله. شفافیت پرکردن و خط مرزی به‌صورت جداگانه پیکربندی می‌شوند. این کار برای بهبود خوانایی شبکه و داده‌ها در تجسم‌های دشفت مفید است.

**چگونه می‌توانم با برچسب‌های داده که همپوشانی دارند، مقابله کنم؟**

اندازه قلم را کاهش دهید، اجزای غیرضروری برچسب (مانند دسته‌ها) را غیرفعال کنید، موقعیت برچسب را تنظیم کنید، در صورت لزوم فقط برای نقاط منتخب برچسب‌ها را نشان دهید، یا قالب را به «مقدار + افسانه» تغییر دهید.

**آیا می‌توانم پرکردن‌های گرادیان یا الگو را بر سری‌ها اعمال کنم؟**

بله. سری‌ها از پرکردن‌های ثابت، گرادیان و الگو پشتیبانی می‌کنند. در عمل، از گرادیان‌ها به‌صورت مقتصد استفاده کنید و ترکیب‌هایی که کنتراست با شبکه و متن را کاهش می‌دهند، اجتناب کنید.