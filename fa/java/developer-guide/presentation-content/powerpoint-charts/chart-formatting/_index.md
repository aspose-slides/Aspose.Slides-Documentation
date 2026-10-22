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
- مرزهای گرد
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "قالب‌بندی نمودارها را در Aspose.Slides برای جاوا بیاموزید و ارائهٔ PowerPoint خود را با محورها، قلم‌ها، فرمت‌های عددی و مرزهای گرد سفارشی ارتقا دهید."
---
## **مروری**

این مقاله توضیح می‌دهد چگونه با استفاده از Aspose.Slides نمودارها را در ارائه‌های PowerPoint قالب‌بندی کنیم. نحوهٔ سفارشی‌سازی عناصر کلیدی نمودار مانند محورها، خطوط شبکه، عناوین، افسانه‌ها، ناحیهٔ ترسیم و پرکنندگی‌های دیوارها را نشان می‌دهد تا ظاهر و قابلیت خواندن داده‌های نمودار بهبود یابد.

همچنین نشان می‌دهد چگونه ویژگی‌های قلم برای متن نمودار تنظیم شود، فرمت‌های عددی از پیش تعریف‌شده به داده‌های نمودار اعمال گردد و گوشه‌های مدور برای ناحیهٔ نمودار فعال شود. این مثال‌ها به‌صورت ترکیبی کنترل سبک بصری و ارائهٔ داده‌های نمودار در یک ارائه را نشان می‌دهند.

## **قالب‌گذاری موجودیت‌های نمودار**

از [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) برای قالب‌گذاری عناوین، محورها، خطوط شبکه، افسانه‌ها و ناحیهٔ ترسیم استفاده کنید. این مثال یک نمودار خطی با نشانگرها و داده‌های پیش‌فرض ایجاد می‌کند، سپس سبک‌های متن و خط را به‌صورت جداگانه برای محور مقدار و محور دسته‌بندی اعمال می‌کند. اندازهٔ قلم‌ها و عرض خطوط برحسب پوینت تعیین می‌شود؛ برچسب‌های دسته‌بندی به‌صورت 45 درجه چرخانده می‌شوند.

محور مقدار از متد [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) مستقل از سلول‌های منبع استفاده می‌کند. مقیاس آن از -2 تا 15 است و فواصل اصلی 2 و فواصل جزئی 0.5 هستند. این مثال همچنین قالب‌بندی درصدی را همراه با تنظیم [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setDisplayUnit-int-) به هزارها ترکیب می‌کند، بنابراین این تنظیمات را بر حسب معنای داده‌ها و مقیاس آن تنظیم کنید. افسانه به‌دلیل فراخوانی [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/ilegend/#setOverlay-boolean-) با مقدار `false` در خارج از ناحیهٔ ترسیم می‌ماند. پرکنندگی‌های دیوار پشت و کف از طریق [getBackWall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--) و [getFloor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--) پیکربندی می‌شوند، اما این سطوح تنها در نمودارهای سه‌بعدی قابل مشاهده هستند.

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

## **تنظیم ویژگی‌های قلم برای یک نمودار**

اندازهٔ قلم پیش‌فرض برای متن نمودار از طریق [Chart.getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getTextFormat--) تنظیم می‌شود. این مثال یک نمودار ستونی خوشه‌ای با قلم 20‑پوینت ایجاد می‌کند و برچسب‌های مقدار را برای اولین سری از طریق [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) فعال می‌سازد. عناصر متنی که تنظیمات قلم صریح خود را دارند می‌توانند پیش‌فرض نمودار را بازنویسی کنند.

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

از [IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-) برای اعمال یک قالب عددی از پیش تعریف‌شده به سلول‌های کاربرگ نمودار استفاده کنید. این مثال یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض، پشتیبانی‌شده توسط سلول‌ها ایجاد می‌کند و اندیس قالب 10 (`0.00%`) را به هر سلول مقدار سری اعمال می‌دارد. این کار نحوهٔ نمایش مقادیر را در کاربرگ تغییر می‌دهد بدون اینکه عددهای پایه تغییر کنند؛ به‌عنوان مثال، 0.25 به‌صورت 25.00% نمایش داده می‌شود. قالب محور و برچسب‌های داده می‌توانند به‌صورت جداگانه پیکربندی شوند.

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

جدول زیر فهرستی از اندیس‌های قالب عددی از پیش تعریف‌شده به همراه قالب‌های نمایشی Excel برای محلّی «English (United States)» را نشان می‌دهد. رشته‌های قالب دقیق و نمایش آن‌ها می‌تواند بسته به برنامه و محلّی متفاوت باشد، به‌ویژه برای ارز و تاریخ‌ها. برخی قالب‌های Excel نیز با پیش‌فرض‌های استاندارد OOXML متفاوت هستند، همان‌طور که در [یادداشت‌های پیاده‌سازی فرمت عددی مایکروسافت](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) توصیف شده است.

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

## **گوشه‌های گرد ناحیهٔ نمودار**

با فراخوانی [IChart.setRoundedCorners](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setRoundedCorners-boolean-) مقدار `true`، گوشه‌های ناحیهٔ نمودار گرد می‌شوند. این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند و با استفاده از [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) به مرز آن رنگ خاکستری جامد و سبک خط تک‌خطی می‌دهد پیش از ذخیرهٔ ارائه.

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

## **ویرایش حاشیه‌نویسی‌های موجود در نمودار**

یک نمودار می‌تواند اشکال سفارشی مانند حاشیه‌نویسی متنی که وضعیت یک گزارش را توضیح می‌دهد، داشته باشد. به این اشکال می‌توانید از طریق [IChart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getUserShapes--) که همچنین در [Chart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getUserShapes--) در مرجع API نمودار فهرست شده است، دسترسی پیدا کنید. مجموعه‌ای که توسط [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) برگردانده می‌شود، شامل اشکال متعلق به نمودار است.

یک جعبه متن معمولی که بر روی نمودار قرار می‌گیرد، متعلق به اسلاید است، حتی اگر شبیه بخشی از نمودار به نظر برسد. پیمایش از طریق [Slide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) نمودار و اشکال معمولی اسلاید را می‌یابد، اما اشکال فردی داخل نمودار را فهرست نمی‌کند. عناوین نمودار و برچسب‌های داده عناصر جداگانه‌ای هستند، نه حاشیه‌نویسی‌های سفارشی در این مجموعه.

فایل [chart-annotations.pptx](chart-annotations.pptx) را دانلود کنید و در پوشهٔ کاری برنامه قرار دهید. اسلاید اول آن حاوی یک نمودار با حاشیه‌نویسی جداشدهٔ «Preliminary results»، یک خط متعلق به نمودار و یک جعبه متن اسلایدی «Slide overlay» است. مثال اولین نمودار در آن اسلاید را پیدا می‌کند و حاشیه‌نویسی را به «Final results» تغییر می‌دهد وقتی گزارش آماده انتشار است. ابتدا بررسی می‌کند که مجموعه خالی نیست و تنها یک [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) با قاب متن غیر‑خالی که توسط [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#getTextFrame--) برگردانده می‌شود و متن مورد انتظار دارد را ویرایش می‌کند.

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

خط و جعبه متن اسلاید بدون تغییر می‌مانند. تصاویر زیر ورودی و نتیجهٔ ذخیره‌شده و بازگشایی‌شده را نمایش می‌دهند:

| قبل از ویرایش | بعد از ویرایش |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
مثال فقط اشکال سطح‑بالای متعلق به نمودار را بررسی می‌کند. اگر حاشیه‌نویسی داخل یک [IGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/) باشد، مجموعهٔ [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) آن گروه را نیز مورد بررسی قرار دهید. این کار را به‌صورت بازگشتی برای گروه‌های تو در تو انجام دهید و همان بررسی‌های متنی را برای اشکال فرزند اعمال کنید. خود گروه یک контейнер است؛ آن را به‌عنوان جعبه متن در نظر نگیرید.
{{% /alert %}}

## **سوالات متداول**

**آیا می‌توانم پرکنندگی‌های نیمه‑شفاف برای ستون‌ها/ناحیه‌ها تنظیم کنم در حالی که مرزها مات نمانند؟**

بله. شفافیت پرکنندگی و خطوط مرز به‌صورت جداگانه پیکربندی می‌شوند. این کار برای بهبود خوانایی شبکه و داده‌ها در نمایش‌های متراکم مفید است.

**چگونه می‌توانم با برچسب‌های داده‌ای که روی هم می‌افتند سروکار داشته باشم؟**

اندازهٔ قلم را کاهش دهید، اجزای غیرضروری برچسب (مثلاً دسته‌بندی‌ها) را غیرفعال کنید، موقعیت برچسب را تنظیم کنید، در صورت لزوم فقط برای نقاط انتخاب‌شده برچسب نشان دهید، یا قالب را به «مقدار + افسانه» تغییر دهید.

**آیا می‌توانم پرکنندگی‌های گرادیان یا الگو را به سری‌ها اعمال کنم؟**

بله. سری‌ها از پرکنندگی‌های ثابت، گرادیان و الگو پشتیبانی می‌کنند. در عمل، از گرادیان‌ها به‌طور معقول استفاده کنید و ترکیب‌هایی که تضاد را با شبکه و متن کاهش می‌دهند، پرهیز کنید.