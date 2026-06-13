---
title: مدیریت برچسب‌های داده نمودار در ارائه‌های اندروید
linktitle: برچسب داده
type: docs
url: /fa/androidjava/chart-data-label/
keywords:
- نمودار
- برچسب داده
- دقت داده
- درصد
- فاصله برچسب
- مکان برچسب
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه برچسب‌های داده نمودار را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای اندروید از طریق جاوا اضافه و قالب‌بندی کنید تا اسلایدهای جذاب‌تری داشته باشید."
---
## **مقدمه**

برچسب‌های داده در نمودار جزئیات مربوط به سری داده‌های نمودار یا نقاط داده فردی را نشان می‌دهند. آن‌ها به خوانندگان امکان می‌دهند سری‌های داده را به سرعت شناسایی کنند و همچنین نمودارها را فهم‌پذیرتر می‌کنند.

## **تنظیم دقت داده در برچسب‌های داده نمودار**

این کد جاوا نشان می‌دهد چگونه دقت داده را در یک برچسب داده نمودار تنظیم کنید:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    
    chart.setDataTable(true);
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00");

    pres.save("output.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **نمایش درصدها به عنوان برچسب‌ها**
Aspose.Slides for Android via Java به شما امکان می‌دهد برچسب‌های درصدی را در نمودارهای نمایش داده شده تنظیم کنید. این کد جاوا عملکرد را نشان می‌دهد:

```java
// یک نمونه از کلاس Presentation را ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // اسلاید اول را دریافت می‌کند
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);
    IChartSeries series;
    double[] total_for_Cat = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        IChartCategory cat = chart.getChartData().getCategories().get_Item(k);
    
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            total_for_Cat[k] = total_for_Cat[k] + (double) (chart.getChartData().getSeries().get_Item(i).getDataPoints().get_Item(k).getValue().getData());
        }
    }
    
    double dataPontPercent = 0f;
    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);
    
        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel lbl = series.getDataPoints().get_Item(j).getLabel();
            dataPontPercent = (double) ((series.getDataPoints().get_Item(j).getValue().getData())) / (double) (total_for_Cat[j]) * 100;
    
            IPortion port = new Portion();
            port.setText(String.format("{0:F2} %.2f", dataPontPercent));
            port.getPortionFormat().setFontHeight(8f);
            lbl.getTextFrameForOverriding().setText("");
            IParagraph para = lbl.getTextFrameForOverriding().getParagraphs().get_Item(0);
            para.getPortions().add(port);
    
            lbl.getDataLabelFormat().setShowSeriesName(false);
            lbl.getDataLabelFormat().setShowPercentage(false);
            lbl.getDataLabelFormat().setShowLegendKey(false);
            lbl.getDataLabelFormat().setShowCategoryName(false);
            lbl.getDataLabelFormat().setShowBubbleSize(false);
        }
    }
    
    // ارائه شامل نمودار را ذخیره می‌کند
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم علامت درصد با برچسب‌های داده نمودار**
این کد جاوا نشان می‌دهد چگونه علامت درصد را برای یک برچسب داده نمودار تنظیم کنید:

```java
// یک نمونه از کلاس Presentation را ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // مرجع اسلاید را از طریق ایندکس آن دریافت می‌کند
    ISlide slide = pres.getSlides().get_Item(0);
    
    // نمودار PercentsStackedColumn را بر روی اسلاید ایجاد می‌کند
    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);
    
    // NumberFormatLinkedToSource را روی false تنظیم می‌کند
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");
    
    chart.getChartData().getSeries().clear();
    int defaultWorksheetIndex = 0;
    
    // ورک‌شیت داده‌های نمودار را دریافت می‌کند
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    
    // سری جدید اضافه می‌کند
    IChartSeries series = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.getType());
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 1, 0.30));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 1, 0.50));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 1, 0.80));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 1, 0.65));
    
    // رنگ پر کردن سری را تنظیم می‌کند
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // ویژگی‌های LabelFormat را تنظیم می‌کند
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // سری جدید اضافه می‌کند
    IChartSeries series2 = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.getType());
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 2, 0.70));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 2, 0.50));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 2, 0.20));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 2, 0.35));
    
    // نوع پر کردن و رنگ را تنظیم می‌کند
    series2.getFormat().getFill().setFillType(FillType.Solid);
    series2.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);
    series2.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    
    // ارائه را بر روی دیسک ذخیره می‌کند
    pres.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم فاصله برچسب از محور**
این کد جاوا نشان می‌دهد چگونه فاصله برچسب را از محور دسته‌بندی هنگام کار با نموداری که از محورها رسم شده تنظیم کنید:

```java
// یک نمونه از کلاس Presentation را ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // مرجع یک اسلاید را دریافت می‌کند
    ISlide sld = pres.getSlides().get_Item(0);
    
    // یک نمودار را روی اسلاید ایجاد می‌کند
    IChart ch = sld.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    
    // فاصله برچسب را از محور تنظیم می‌کند
    ch.getAxes().getHorizontalAxis().setLabelOffset(500);
    
    // ارائه را بر روی دیسک ذخیره می‌کند
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم مکان برچسب**

هنگامی که نموداری ایجاد می‌کنید که به هیچ محور متکی نیست، مانند نمودار دایره‌ای، ممکن است برچسب‌های داده نمودار زیاد به لبه آن نزدیک شوند. در چنین حالتی باید مکان برچسب داده را تنظیم کنید تا خطوط راهنما به‌وضوح نشان داده شوند.

این کد جاوا نشان می‌دهد چگونه مکان برچسب را در یک نمودار دایره‌ای تنظیم کنید:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);

    IChartSeriesCollection series = chart.getChartData().getSeries();
    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);

    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![نمودار-دایره‌ای-با-برچسب-تنظیم-شده](pie-chart-adjusted-label.png)

## **سؤالات متداول**

**چگونه می‌توانم از هم‌پوشانی برچسب‌های داده در نمودارهای پرچگالی جلوگیری کنم؟**

از قرارگیری خودکار برچسب، خطوط راهنما و کاهش اندازه قلم استفاده کنید؛ در صورت لزوم برخی فیلدها (مثلاً دسته) را مخفی کنید یا فقط برای نقاط بحرانی/کلیدی برچسب نشان دهید.

**چگونه می‌توانم برچسب‌ها را فقط برای مقادیر صفر، منفی یا خالی غیرفعال کنم؟**

نقاط داده را قبل از فعال‌سازی برچسب‌ها فیلتر کنید و نمایش مقادیر 0، مقادیر منفی یا مقادیر گمشده را بر اساس یک قاعده تعریف‌شده غیرفعال کنید.

**چگونه می‌توانم سبک برچسب ثابت را هنگام خروجی به PDF/تصاویر تضمین کنم؟**

قلم‌ها (خانواده، اندازه) را به‌صورت صریح تنظیم کنید و اطمینان حاصل کنید که قلم موردنظر در سمت رندرینگ موجود باشد تا از fallback جلوگیری شود.