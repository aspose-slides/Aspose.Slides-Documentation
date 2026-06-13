---
title: مدیریت برچسب‌های داده نمودار در ارائه‌ها با استفاده از Java
linktitle: برچسب داده
type: docs
url: /fa/java/chart-data-label/
keywords:
- نمودار
- برچسب داده
- دقت داده
- درصد
- فاصله برچسب
- مکان برچسب
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه برچسب‌های داده نمودار را در ارائه‌های PowerPoint با استفاده از Aspose.Slides for Java اضافه و قالب‌بندی کنید تا اسلایدهای جذاب‌تری داشته باشید."
---
## **مقدمه**

برچسب‌های داده در یک نمودار جزئیات مربوط به سری‌های دادهٔ نمودار یا نقاط دادهٔ منفرد را نشان می‌دهند. آن‌ها به خوانندگان کمک می‌کند تا سری‌های داده را به‌سرعت شناسایی کنند و همچنین درک نمودارها را آسان‌تر می‌سازند.

## **تنظیم دقت داده‌ها در برچسب‌های دادهٔ نمودار**

این کد Java نشان می‌دهد که چگونه دقت داده‌ها را در یک برچسب دادهٔ نمودار تنظیم کنید:

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

## **نمایش درصد به‌عنوان برچسب‌ها**
Aspose.Slides for Java به شما امکان می‌دهد برچسب‌های درصدی را بر روی نمودارهای نمایش داده‌شده تنظیم کنید. این کد Java عملیات را نشان می‌دهد:

```java
// یک نمونه از کلاس Presentation ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // اولین اسلاید را دریافت می‌کند
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

## **تنظیم علامت درصد در برچسب‌های دادهٔ نمودار**
این کد Java نشان می‌دهد که چگونه علامت درصد را برای یک برچسب دادهٔ نمودار تنظیم کنید:

```java
// یک نمونه از کلاس Presentation ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // مرجع یک اسلاید را از طریق شاخص آن دریافت می‌کند
    ISlide slide = pres.getSlides().get_Item(0);
    
    // نمودار PercentsStackedColumn را روی اسلاید ایجاد می‌کند
    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);
    
    // NumberFormatLinkedToSource را به false تنظیم می‌کند
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");
    
    chart.getChartData().getSeries().clear();
    int defaultWorksheetIndex = 0;
    
    // کاربرگ داده‌های نمودار را دریافت می‌کند
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    
    // یک سری جدید اضافه می‌کند
    IChartSeries series = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.getType());
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 1, 0.30));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 1, 0.50));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 1, 0.80));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 1, 0.65));
    
    // رنگ پر کردن سری را تنظیم می‌کند
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // خصوصیات LabelFormat را تنظیم می‌کند
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // یک سری جدید اضافه می‌کند
    IChartSeries series2 = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.getType());
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 2, 0.70));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 2, 0.50));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 2, 0.20));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 2, 0.35));
    
    // نوع و رنگ پر کردن را تنظیم می‌کند
    series2.getFormat().getFill().setFillType(FillType.Solid);
    series2.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);
    series2.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    
    // ارائه را روی دیسک ذخیره می‌کند
    pres.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم فاصله برچسب از محور**
این کد Java نشان می‌دهد که چگونه فاصله برچسب را از محور دسته‌بندی هنگام کار با نموداری که از محورها ترسیم شده تنظیم کنید:

```java
// یک نمونه از کلاس Presentation ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // مرجع یک اسلاید را دریافت می‌کند
    ISlide sld = pres.getSlides().get_Item(0);
    
    // یک نمودار را روی اسلاید ایجاد می‌کند
    IChart ch = sld.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    
    // فاصله برچسب را از یک محور تنظیم می‌کند
    ch.getAxes().getHorizontalAxis().setLabelOffset(500);
    
    // ارائه را روی دیسک ذخیره می‌کند
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم مکان برچسب**

زمانی که یک نمودار ایجاد می‌کنید که به هیچ محوری وابسته نیست، مانند نمودار دایره‌ای، ممکن است برچسب‌های دادهٔ نمودار خیلی نزدیک به لبهٔ آن شوند. در چنین حالتی باید مکان برچسب داده را تنظیم کنید تا خطوط راهنما به‌وضوح نمایش داده شوند.

این کد Java نشان می‌دهد که چگونه مکان برچسب را در یک نمودار دایره‌ای تنظیم کنید:

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

![نقشه‌دائره با برچسب تنظیم‌شده](pie-chart-adjusted-label.png)

## **سوالات متداول**

**چگونه می‌توانم از هم‌پوشانی برچسب‌های داده در نمودارهای پر تراکم جلوگیری کنم؟**

از جایگذاری خودکار برچسب‌ها، خطوط راهنما و کاهش اندازهٔ قلم استفاده کنید؛ در صورت نیاز، برخی فیلدها (مثلاً دسته) را پنهان کنید یا برچسب‌ها را فقط برای نقاط انتهایی/کلیدی نمایش دهید.

**چگونه می‌توانم برچسب‌ها را فقط برای مقادیر صفر، منفی یا خالی غیرفعال کنم؟**

نقاط داده را قبل از فعال کردن برچسب‌ها فیلتر کنید و نمایش را برای مقادیر ۰، مقادیر منفی یا مقادیر گمشده بر اساس یک قانون تعریف‌شده خاموش کنید.

**چگونه می‌توانم سبک برچسب‌ها را هنگام خروجی به PDF/تصاویر یکنواخت نگه دارم؟**

قلم‌ها (خانواده، اندازه) را به‌صورت صریح تنظیم کنید و اطمینان حاصل کنید که قلم موردنظر در سمت رندر موجود است تا از استفادهٔ قلم جایگزین جلوگیری شود.