---
title: مدیریت سری داده‌های نمودار در ارائه‌ها در .NET
linktitle: سری داده‌ها
type: docs
url: /fa/net/chart-series/
keywords:
- سری نمودار
- همپوشانی سری
- رنگ سری
- رنگ دسته
- نام سری
- نقطه داده
- فاصله سری
- پاورپوینت
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه سری‌های نمودار را در C# برای پاورپوینت (PPT/PPTX) مدیریت کنید، با مثال‌های کد عملی و بهترین روش‌ها برای بهبود ارائه‌های داده‌ای خود."
---
## **بررسی کلی**

این مقاله نقش [ChartSeries](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chartseries/) را در Aspose.Slides برای .NET توضیح می‌دهد و بر چگونگی ساختاردهی و تجسم داده‌ها در ارائه‌ها تمرکز دارد. این اشیاء عناصر بنیادینی را فراهم می‌کنند که مجموعه‌های جداگانه‌ای از نقاط داده، دسته‌ها و پارامترهای ظاهر را در نمودار تعریف می‌کنند. با کار با [ChartSeries](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chartseries/)، توسعه‌دهندگان می‌توانند به‌صورت یکپارچه منابع داده زیربنایی را ادغام کرده و کنترل کامل بر نحوه نمایش اطلاعات داشته باشند، که منجر به ارائه‌های پویا و مبتنی بر داده می‌شود که به‌وضوح بینش‌ها و تحلیل‌ها را منتقل می‌کند.

یک سری، یک سطر یا ستون از اعداد است که در یک نمودار ترسیم می‌شود.

![نمودار-سری-پاورپوینت](chart-series-powerpoint.png)

## **تنظیم همپوشانی سری‌های نمودار**

خاصیت [IChartSeriesOverlap](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/properties/overlap) کنترل می‌کند که نوارها و ستون‌ها در یک نمودار دو‌بعدی چگونه همپوشانی داشته باشند، به‌طوری که بازه‌ای از -100 تا 100 را تعیین می‌کند. از آنجا که این خاصیت به گروه سری تعلق دارد نه به هر سری نمودار به‌صورت جداگانه، در سطح سری فقط‑خواندنی است. برای پیکربندی مقادیر همپوشانی، از خاصیت `ParentSeriesGroup.Overlap` که قابل خواندن/نوشتن است، استفاده کنید؛ این خاصیت همپوشانی تعیین‌شده را برای تمام سری‌های آن گروه اعمال می‌کند.

در ادامه یک مثال C# آورده شده است که نشان می‌دهد چگونه یک ارائه ایجاد کنید، یک نمودار ستونی خوشه‌ای اضافه کنید، به اولین سری نمودار دسترسی پیدا کنید، تنظیم همپوشانی را پیکربندی کنید و سپس نتیجه را به صورت فایل PPTX ذخیره کنید:

```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض اضافه کنید.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.ChartData.Series[0];
    if (series.Overlap == 0)
    {
        // همپوشانی سری را تنظیم کنید.
        series.ParentSeriesGroup.Overlap = overlap;
    }

    // پرونده ارائه را روی دیسک ذخیره کنید.
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![همپوشانی سری‌ها](series_overlap.png)

## **تغییر رنگ پر کردن سری**

Aspose.Slides این امکان را به‌صورت ساده فراهم می‌کند که رنگ‌های پرکردن سری‌های نمودار را سفارشی کنید، به‌طوری که بتوانید نقاط داده خاص را برجسته کرده و نمودارهای بصری جذابی ایجاد کنید. این کار از طریق شیء [IFormat](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/iformat/) انجام می‌شود که انواع مختلفی از پرکردن‌ها، پیکربندی‌های رنگی و گزینه‌های پیشرفته استایل را پشتیبانی می‌کند. پس از افزودن یک نمودار به اسلاید و دسترسی به سری مورد نظر، به سادگی سری را دریافت کرده و رنگ پرکردن مناسب را اعمال کنید. علاوه بر پرکردن‌های یکدست، می‌توانید از پرکردن‌های گرادیان یا الگو برای انعطاف‌پذیری بیشتر طراحی استفاده کنید. پس از تنظیم رنگ‌ها مطابق نیازهای خود، ارائه را ذخیره کنید تا ظاهر بروز شده نهایی شود.

کد مثال C# زیر نشان می‌دهد چگونه رنگ اولین سری را تغییر دهید:

```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض اضافه کنید.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // رنگ اولین سری را تنظیم کنید.
    IChartSeries series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;

    // پرونده ارائه را روی دیسک ذخیره کنید.
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![رنگ سری](series_color.png)

## **تغییر نام سری**

Aspose.Slides روش ساده‌ای برای تغییر نام‌های سری‌های نمودار فراهم می‌کند که برچسب‌گذاری داده‌ها را به‌صورت واضح و معنادار آسان‌تر می‌سازد. با دسترسی به سلول مربوط به worksheet در داده‌های نمودار، توسعه‌دهندگان می‌توانند نحوه ارائه داده‌ها را سفارشی کنند. این تغییر به‌ویژه وقتی مفید است که نام‌های سری بر اساس زمینه داده‌ها نیاز به به‌روزرسانی یا شفاف‌سازی داشته باشند. پس از تغییر نام سری، می‌توان ارائه را ذخیره کرد تا تغییرات حفظ شوند.

در زیر یک قطعه کد C# آورده شده است که این فرآیند را به‌صورت عملی نشان می‌دهد:

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض اضافه کنید.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // نام اولین سری را تنظیم کنید.
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // پرونده ارائه را روی دیسک ذخیره کنید.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

کد C# زیر روش دیگری برای تغییر نام سری نشان می‌دهد:

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض اضافه کنید.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // نام اولین سری را تنظیم کنید.
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // پرونده ارائه را روی دیسک ذخیره کنید.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![نام سری](series_name.png)

## **دریافت رنگ پر کردن خودکار سری**

Aspose.Slides برای .NET به شما امکان می‌دهد رنگ پرکردن خودکار سری‌های نمودار را در داخل ناحیه نمودار به‌دست آورید. پس از ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) می‌توانید با استفاده از ایندکس به اسلاید مورد نظر دسترسی پیدا کنید، سپس یک نمودار با نوع دلخواه (مانند `ChartType.ClusteredColumn`) اضافه کنید. با دسترسی به سری‌ها در نمودار، می‌توانید رنگ پرکردن خودکار را دریافت کنید.

کد C# زیر این فرآیند را به‌تفصیل نشان می‌دهد.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض اضافه کنید.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        // رنگ پرکردن سری را دریافت کنید.
        Color color = chart.ChartData.Series[i].GetAutomaticSeriesColor();
        Console.WriteLine($"Series {i} color: {color.Name}");
    }
}
```

خروجی:
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```

## **تنظیم رنگ پرکردن معکوس برای یک سری نمودار**

زمانی که سری داده‌های شما شامل مقادیر مثبت و منفی باشد، رنگ یکسان برای تمام ستون‌ها یا نوارها می‌تواند خوانایی نمودار را دشوار کند. Aspose.Slides برای .NET به شما امکان می‌دهد رنگ پرکردن معکوس را اختصاص دهید — یک پرکردن جداگانه که به‌صورت خودکار برای نقاط داده‌ای که زیر صفر هستند اعمال می‌شود — تا مقادیر منفی به‌سرعت برجسته شوند. در این بخش می‌آموزید چگونه این گزینه را فعال کنید، رنگ مناسب را انتخاب کنید و ارائه بروز‌رسانی‌شده را ذخیره کنید.

مثال کد زیر عملیات را نشان می‌دهد:

```cs
Color inverColor = Color.Red;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // افزودن دسته‌های جدید.
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Category 3"));

    // افزودن سری جدید.
    IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // پر کردن داده‌های سری.
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));

    // تنظیمات رنگ برای سری.
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;

    presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![رنگ پرکردن جامد معکوس](inverted_solid_fill_color.png)

می‌توانید رنگ پرکردن را برای یک نقطه داده واحد به‌جای تمام سری معکوس کنید. به سادگی به `IChartDataPoint` مورد نظر دسترسی پیدا کنید و خاصیت `InvertIfNegative` آن را روی true تنظیم کنید.

مثال کد زیر نشان می‌دهد چگونه این کار را انجام دهید:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200, true);

    chart.ChartData.Series.Clear();
    IChartSeries series = chart.ChartData.Series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);

    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

    // اگر نقطه دادهٔ ایندکس ۲ منفی باشد، رنگ را معکوس کنید.
    series.InvertIfNegative = false;
    series.DataPoints[2].InvertIfNegative = true;
                
    presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
}
```

## **پاک کردن مقادیر نقاط داده خاص**

گاهی یک نمودار شامل مقادیر تستی، نقاط پرت یا ورودی‌های منقضی شده است که نیاز به حذف آن‌ها بدون بازسازی کل سری دارد. Aspose.Slides برای .NET به شما امکان می‌دهد به هر نقطه داده‌ای بر اساس ایندکس هدف بگیرید، محتوای آن را پاک کنید و بلافاصله نمودار را تازه کنید تا نقاط باقی‌مانده جابجا شوند و محور‌ها به‌صورت خودکار مقیاس‌بندی شوند.

مثال کد زیر عملیات را نشان می‌دهد:

```cs
using (Presentation presentation = new Presentation("test_chart.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = (IChart)slide.Shapes[0];
    IChartSeries series = chart.ChartData.Series[0];

    foreach (IChartDataPoint dataPoint in series.DataPoints)
    {
        dataPoint.XValue.AsCell.Value = null;
        dataPoint.YValue.AsCell.Value = null;
    }

    series.DataPoints.Clear();

    presentation.Save("clear_data_points.pptx", SaveFormat.Pptx);
}
```

## **تنظیم عرض شکاف سری**

عرض شکاف میزان فضای خالی بین ستون‌ها یا نوارهای مجاور را کنترل می‌کند — شکاف‌های وسیع‌تر دسته‌های جداگانه را برجسته می‌کند، در حالی که شکاف‌های باریک‌تر ظاهری متراکم و فشرده به‌وجود می‌آورد. با استفاده از Aspose.Slides برای .NET می‌توانید این پارامتر را برای یک سری کامل به‌دقت تنظیم کنید و دقیقاً تعادل بصری مورد نیاز ارائه خود را بدون تغییر داده‌های زیربنایی به‌دست آورید.

مثال کد زیر نشان می‌دهد چگونه عرض شکاف را برای یک سری تنظیم کنید:

```cs
ushort gapWidth = 30;

// یک ارائهٔ خالی ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // به اولین اسلاید دسترسی پیدا کنید.
    ISlide slide = presentation.Slides[0];

    // یک نمودار با داده‌های پیش‌فرض اضافه کنید.
    IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

    // ارائه را روی دیسک ذخیره کنید.
    presentation.Save("default_gap_width.pptx", SaveFormat.Pptx);

    // مقدار GapWidth را تنظیم کنید.
    IChartSeries series = chart.ChartData.Series[0];
    series.ParentSeriesGroup.GapWidth = gapWidth;

    // ارائه را روی دیسک ذخیره کنید.
    presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![عرض شکاف](gap_width.png)

## **سوالات متداول**

**آیا محدودیتی برای تعداد سری‌های یک نمودار منفرد وجود دارد؟**

Aspose.Slides هیچ سقف ثابت برای تعداد سری‌هایی که اضافه می‌کنید اعمال نمی‌کند. محدودیت عملی توسط قابلیت خواندن نمودار و حافظه موجود برای برنامه شما تعیین می‌شود.

**اگر ستون‌های داخل یک خوشه بیش از حد نزدیک یا بیش از حد دور باشند چه می‌شود؟**

مقدار تنظیم `GapWidth` برای آن سری (یا گروه سری والد) را تنظیم کنید. افزایش مقدار فضای بین ستون‌ها را گسترده می‌کند، در حالی که کاهش آن آن‌ها را به‌هم نزدیک‌تر می‌کند.