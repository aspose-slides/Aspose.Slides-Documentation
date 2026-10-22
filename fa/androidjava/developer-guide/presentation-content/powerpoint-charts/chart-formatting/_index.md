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
description: "یادگیری قالب‌بندی نمودار در Aspose.Slides برای اندروید با استفاده از جاوا و ارتقاء ارائهٔ PowerPoint خود با محورهای سفارشی، قلم‌ها، قالب‌های عددی و حاشیه‌های گرد نمودار."
---
## **نگاه کلی**

این مقاله توضیح می‌دهد چگونه نمودارها را در ارائه‌های PowerPoint با استفاده از Aspose.Slides قالب‌بندی کنیم. این مقاله نشان می‌دهد چگونه عناصر کلیدی نمودار مانند محورها، خطوط شبکه، عناوین، افسانه‌ها، ناحیه رسم و پرکردن دیوارها را سفارشی کنیم تا ظاهر و قابلیت خواندن داده‌های نمودار بهبود یابد.

همچنین نحوه تنظیم ویژگی‌های قلم برای متن نمودار، اعمال قالب‌های عددی از پیش تعریف‌شده به داده‌های نمودار، و فعال‌سازی گوشه‌های گرد برای ناحیه نمودار را نشان می‌دهد. این مثال‌ها نشان می‌دهند چگونه می‌توان هم سبک بصری و هم ارائه داده‌های نمودار را در یک ارائه کنترل کرد.

## **قالب‌بندی موجودیت‌های نمودار**

از [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) برای قالب‌بندی عناوین نمودار، محورها، خطوط شبکه، افسانه‌ها و ناحیه رسم استفاده کنید. این مثال یک نمودار خطی با نشانگرها و داده‌های پیش‌فرض ایجاد می‌کند، سپس سبک‌های متن و خط جداگانه‌ای را بر محورهاى مقدار و دسته‌بندی اعمال می‌کند. اندازه‌های قلم و عرض خطوط بر حسب پوینت مشخص شده‌اند؛ برچسب‌های دسته‌بندی به میزان 45 درجه چرخانده می‌شوند.

محور مقدار از [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) به‌صورت مستقل از سلول‌های منبع استفاده می‌کند. مقیاس آن از -2 تا 15 است، با فاصله‌های اصلی 2 و فاصله‌های فرعی 0.5. مثال همچنین قالب‌بندی درصدی را با [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setDisplayUnit-int-) تنظیم شده بر روی هزارها ترکیب می‌کند، بنابراین این تنظیمات را بر اساس معنی و بزرگی داده‌های خود تنظیم کنید. افسانه به دلیل اینکه [setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegend/#setOverlay-boolean-) با `false` فراخوانی شده خارج از ناحیه رسم می‌ماند. پرکردن‌های پشت‌دیوار و کف از طریق [getBackWall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getBackWall--) و [getFloor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getFloor--) پیکربندی می‌شوند، اما این سطوح فقط در نمودارهای سه‌بعدی قابل مشاهده هستند.

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

## **تنظیم ویژگی‌های قلم برای یک نمودار**

اندازه پیش‌فرض قلم برای متن نمودار را از طریق [Chart.getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#getTextFormat--) تنظیم کنید. این مثال یک نمودار ستونی خوشه‌ای با قلم 20 پوینت ایجاد می‌کند و برچسب‌های مقدار برای اولین سری را از طریق [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) فعال می‌سازد. عناصر متنی که تنظیمات قلم صریح خود را دارند می‌توانند تنظیمات پیش‌فرض نمودار را بازنویسی کنند.

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

## **تنظیم قالب عددی**

از [IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-) برای اعمال یک قالب عددی پیش‌تعریف‌شده به سلول‌های کارنامه نمودار استفاده کنید. این مثال یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض و پشت‌سلولی ایجاد می‌کند و شاخص قالب 10 (`0.00%`) را به هر سلول مقدار سری اعمال می‌نماید. این کار نحوه نمایش مقادیر را در کتاب‌کار بدون تغییر اعداد اصلی تغییر می‌دهد؛ برای مثال، 0.25 به صورت 25.00٪ نمایش داده می‌شود. قالب‌های محورها و برچسب‌های داده می‌توانند به‌صورت جداگانه پیکربندی شوند.

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

جدول زیر شاخص‌های قالب عددی داخلی را همراه با قالب‌های نمایشی Excel برای محل (United States) انگلیسی فهرست می‌کند. رشته‌های قالب دقیق و نمایش آن‌ها ممکن است بسته به برنامه و مکان‌گذاری، به‌ویژه برای ارزها و تاریخ‌ها، متفاوت باشد. برخی از قالب‌های Excel نیز با پیش‌فرض‌های استاندارد OOXML تفاوت دارند، همان‌طور که در [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) توضیح داده شده است.

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

## **تنظیم لبه‌های گرد ناحیهٔ نمودار**

با فراخوانی [IChart.setRoundedCorners](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setRoundedCorners-boolean-) و مقدار `true`، گوشه‌های ناحیهٔ نمودار را گرد کنید. این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند و از [getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) برای دادن رنگ خاکستری ثابت و سبک خط تک‌خطی به حاشیهٔ آن پیش از ذخیرهٔ ارائه استفاده می‌کند.

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

یک نمودار می‌تواند اشکال سفارشی مانند یک حاشیه‌نویسی متنی که وضعیت گزارشی را توضیح می‌دهد، شامل شود. به این اشکال از طریق [IChart.getUserShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getUserShapes--) که همچنین تحت [Chart.getUserShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#getUserShapes--) در مرجع API نمودار فهرست شده است، دسترسی داشته باشید. مجموعه‌ای که توسط [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) برگردانده می‌شود، اشکال مالکیت‌دار توسط نمودار را شامل می‌شود.

یک جعبهٔ متن عادی که بر روی نمودار قرار می‌گیرد به اسلاید تعلق دارد، حتی اگر شبیه بخشی از نمودار به نظر برسد. پیمایش از طریق [Slide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) نمودار و اشکال عادی اسلاید را پیدا می‌کند، اما اشکال منفرد داخل نمودار را فهرست نمی‌کند. عناوین نمودار و برچسب‌های داده به‌عنوان عناصر جداگانهٔ نمودار محسوب می‌شوند، نه حاشیه‌نویسی‌های سفارشی در این مجموعه.

فایل [chart-annotations.pptx](chart-annotations.pptx) را دانلود کنید و در پوشهٔ کاری برنامه قرار دهید. اسلاید اول آن شامل یک نمودار با حاشیه‌نویسی جداسازی‑نشده با متن «Preliminary results»، یک خط مالکیت‌دار نمودار، و یک جعبهٔ متن اسلایدی با متن «Slide overlay» است. مثال اولین نمودار آن اسلاید را پیدا می‌کند و حاشیه‌نویسی را به «Final results» تغییر می‌دهد وقتی گزارش آماده انتشار باشد. این مثال وجود یک مجموعه خالی را بررسی می‌کند و فقط یک [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) با چارچوب متن غیر‌خالی که توسط [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#getTextFrame--) برگردانده می‌شود و متن مورد انتظار دارد، ویرایش می‌نماید.

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

خط و جعبهٔ متن اسلاید دست‌نخورده می‌مانند. تصاویر زیر ورودی و نتیجهٔ ذخیره‌شده و بازگشایی‌شده را نشان می‌دهند:

| قبل از ویرایش | بعد از ویرایش |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
مثال فقط اشکال مالکیت‌دار سطح بالای نمودار را بررسی می‌کند. اگر حاشیه‌نویسی داخل یک [IGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/) باشد، مجموعهٔ [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) آن گروه را نیز بررسی کنید. این کار را به‌صورت بازگشتی برای گروه‌های تو در تو انجام دهید و همان بررسی‌های متنی را روی اشکال فرزندی آنها اعمال کنید. یک گروه خود یک محفظه است؛ آن را به‌عنوان جعبهٔ متن درنظر نگیرند.
{{% /alert %}}

## **سوالات متداول**

**آیا می‌توانم پرکردن‌های نیمه‑شفاف برای ستون‌ها/ناحیه‌ها تنظیم کنم در حالی که حاشیه آن‌ها مات باقی می‌ماند؟**

بله. شفافیت پرکردن و خط خارجی به‌صورت جداگانه پیکربندی می‌شوند. این کار برای بهبود خوانایی شبکه و داده‌ها در تجسم‌های متراکم مفید است.

**چگونه می‌توانم با برچسب‌های داده که هم‌پوشانی دارند برخورد کنم؟**

اندازه قلم را کاهش دهید، مؤلفه‌های غیرضروری برچسب‌ها (مثلاً دسته‌ها) را غیرفعال کنید، موقعیت برچسب را تنظیم کنید، در صورت لزوم فقط برچسب‌های نقاط انتخاب‌شده را نمایش دهید، یا قالب را به «مقدار + افسانه» تغییر دهید.

**آیا می‌توانم پرکردن‌های گرادیان یا الگو را به سری‌ها اعمال کنم؟**

بله. سری‌ها از پرکردن‌های ثابت، گرادیان و الگو پشتیبانی می‌کنند. در عمل، از گرادیان‌ها به‌صورت مقتصدانه استفاده کنید و ترکیباتی که کنتراست با شبکه و متن را کاهش می‌دهند، اجتناب کنید.