---
title: مدیریت برچسب‌های دادهٔ نمودار در ارائه‌ها در .NET
linktitle: برچسب داده
type: docs
url: /fa/net/chart-data-label/
keywords:
- نمودار
- برچسب داده
- دقت داده
- درصد
- فاصله برچسب
- موقعیت برچسب
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه برچسب‌های دادهٔ نمودار را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای .NET اضافه و قالب‌بندی کنید تا اسلایدهای جذاب‌تری داشته باشید."
---
## **مقدمه**

برچسب‌های داده در یک نمودار جزئیات دربارهٔ سری‌های دادهٔ نمودار یا نقاط دادهٔ فردی را نشان می‌دهند. این برچسب‌ها به خوانندگان امکان می‌دهند سری‌های داده را به سرعت تشخیص دهند و نمودارها را به‌سوی درک آسان‌تر هدایت می‌کنند.

## **تنظیم دقت داده در برچسب‌های دادهٔ نمودار**

این کد C# نشان می‌دهد چگونه دقت داده را در یک برچسب دادهٔ نمودار تنظیم کنید:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
	chart.HasDataTable = true;
	chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

	pres.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
}
```

## **نمایش درصد به‌عنوان برچسب‌ها**
Aspose.Slides برای .NET امکان تنظیم برچسب‌های درصدی روی نمودارهای نمایش داده‌شده را فراهم می‌کند. این کد C# عملیات را نشان می‌دهد:

```c#
// یک نمونه از کلاس Presentation ایجاد می‌کند
Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 400, 400);
IChartSeries series = chart.ChartData.Series[0];
IChartCategory cat;
double[] total_for_Cat = new double[chart.ChartData.Categories.Count];
for (int k = 0; k < chart.ChartData.Categories.Count; k++)
{
    cat = chart.ChartData.Categories[k];

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        total_for_Cat[k] = total_for_Cat[k] + Convert.ToDouble(chart.ChartData.Series[i].DataPoints[k].Value.Data);
    }
}

double dataPontPercent = 0f;

for (int x = 0; x < chart.ChartData.Series.Count; x++)
{
    series = chart.ChartData.Series[x];
    series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;

    for (int j = 0; j < series.DataPoints.Count; j++)
    {
        IDataLabel lbl = series.DataPoints[j].Label;
        dataPontPercent = (Convert.ToDouble(series.DataPoints[j].Value.Data) / total_for_Cat[j]) * 100;

        IPortion port = new Portion();
        port.Text = String.Format("{0:F2} %", dataPontPercent);
        port.PortionFormat.FontHeight = 8f;
        lbl.TextFrameForOverriding.Text = "";
        IParagraph para = lbl.TextFrameForOverriding.Paragraphs[0];
        para.Portions.Add(port);

        lbl.DataLabelFormat.ShowSeriesName = false;
        lbl.DataLabelFormat.ShowPercentage = false;
        lbl.DataLabelFormat.ShowLegendKey = false;
        lbl.DataLabelFormat.ShowCategoryName = false;
        lbl.DataLabelFormat.ShowBubbleSize = false;
    }
}

// ارائه‌ای که شامل نمودار است را ذخیره می‌کند
presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```

## **تنظیم علامت درصد با برچسب‌های دادهٔ نمودار**
این کد C# نشان می‌دهد چگونه علامت درصد را برای یک برچسب دادهٔ نمودار تنظیم کنید:

```c#
// یک نمونه از کلاس Presentation ایجاد می‌کند
Presentation presentation = new Presentation();

// مرجع یک اسلاید را از طریق شاخص آن دریافت می‌کند
ISlide slide = presentation.Slides[0];

// نمودار PercentsStackedColumn را روی اسلاید ایجاد می‌کند
IChart chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

// مقدار NumberFormatLinkedToSource را روی false تنظیم می‌کند
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
int defaultWorksheetIndex = 0;

// ورک‌شیت دادهٔ نمودار را دریافت می‌کند
IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

// سری جدیدی اضافه می‌کند
IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.Type);
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 0.30));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 0.50));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 0.80));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 0.65));

// رنگ پر کنندهٔ سری را تنظیم می‌کند
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

// ویژگی‌های LabelFormat را تنظیم می‌کند
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

// سری جدیدی اضافه می‌کند
IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.Type);
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 0.70));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 0.50));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 0.20));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 2, 0.35));

// نوع و رنگ پر کننده را تنظیم می‌کند
series2.Format.Fill.FillType = FillType.Solid;
series2.Format.Fill.SolidFillColor.Color = Color.Blue;
series2.Labels.DefaultDataLabelFormat.ShowValue = true;
series2.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series2.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;

// ارائه را روی دیسک ذخیره می‌کند
presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```

## **تنظیم فاصلهٔ برچسب از محور**
این کد C# نشان می‌دهد چگونه فاصلهٔ برچسب را از محور دسته‌بندی هنگام کار با نموداری که از محورها رسم شده تنظیم کنید:

```c#
// یک نمونه از کلاس Presentation ایجاد می‌کند
Presentation presentation = new Presentation();

// مرجع یک اسلاید را دریافت می‌کند
ISlide sld = presentation.Slides[0];

// یک نمودار روی اسلاید ایجاد می‌کند
IChart ch = sld.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

// فاصله برچسب را از یک محور تنظیم می‌کند
ch.Axes.HorizontalAxis.LabelOffset = 500;

// ارائه را روی دیسک ذخیره می‌کند
presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

## **تنظیم موقعیت برچسب**

زمانی که نموداری ایجاد می‌کنید که به هیچ محور وابسته نیست (مانند نمودار دایره‌ای)، ممکن است برچسب‌های دادهٔ نمودار بسیار نزدیک به لبهٔ آن شوند. در چنین حالتی باید موقعیت برچسب داده را تنظیم کنید تا خطوط راهنما واضح نمایش داده شوند.

این کد C# نشان می‌دهد چگونه موقعیت برچسب را در یک نمودار دایره‌ای تنظیم کنید:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 200, 200);

    IChartSeriesCollection series = chart.ChartData.Series;
    IDataLabel label = series[0].Labels[0];

    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
    label.X = 0.71f;
    label.Y = 0.04f;

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **سوالات متداول**

**چگونه می‌توانم از هم‌پوشانی برچسب‌های داده در نمودارهای پرچالش جلوگیری کنم؟**

از قرارگاه خودکار برچسب‌ها، خطوط راهنما و کاهش اندازهٔ قلم استفاده کنید؛ در صورت لزوم برخی فیلدها (مانند دسته) را مخفی کنید یا فقط برای نقاط کلیدی/نقطه‌های انتهایی برچسب نمایش دهید.

**چگونه می‌توانم برچسب‌ها را فقط برای مقادیر صفر، منفی یا خالی غیرفعال کنم؟**

نقاط داده را قبل از فعال‌سازی برچسب‌ها فیلتر کنید و نمایش مقادیر ۰، مقادیر منفی یا مقادیر گمشده را بر اساس قاعده‌ای تعریف‌شده غیرفعال کنید.

**چگونه می‌توانم سبک برچسب را به‌صورت ثابت هنگام خروجی به PDF/تصاویر تضمین کنم؟**

قلم‌ها (نام خانوادگی، اندازه) را به‌طور صریح تنظیم کنید و اطمینان حاصل کنید که قلم موردنظر در سمت رندر موجود است تا از fallback جلوگیری شود.