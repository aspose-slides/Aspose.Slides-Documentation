---
title: سفارشی‌سازی نقاط داده در نمودارهای Treemap و Sunburst در .NET
linktitle: نقاط داده در نمودارهای Treemap و Sunburst
type: docs
url: /fa/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- نمودار treemap
- نمودار sunburst
- نقطه داده
- رنگ برچسب
- رنگ شاخه
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه نقاط داده را در نمودارهای treemap و sunburst با Aspose.Slides برای .NET مدیریت کنید، سازگار با قالب‌های PowerPoint."
---
## **مقدمه**

در میان انواع دیگر نمودارهای PowerPoint، دو نوع «سلسله‌مراتبی» وجود دارد - نمودار **Treemap** و نمودار **Sunburst** (که همچنین به عنوان Sunburst Graph، Sunburst Diagram، Radial Chart، Radial Graph یا Multi Level Pie Chart شناخته می‌شود). این نمودارها داده‌های سلسله‌مراتبی را که به شکل یک درخت سازماندهی شده‌اند، از برگ‌ها تا بالای شاخه نمایش می‌دهند. برگ‌ها توسط نقاط داده سطر (Series) تعریف می‌شوند و هر سطح تو در توی بعدی توسط دسته‌بندی مربوطه تعریف می‌شود. Aspose.Slides for .NET امکان فرمت‌بندی نقاط داده نمودار Sunburst و Treemap را در C# فراهم می‌کند.

در اینجا نمودار Sunburst آورده شده است که داده‌های ستون Series1 گره‌های برگ را تعریف می‌کنند، در حالی که ستون‌های دیگر نقاط داده سلسله‌مراتبی را تعریف می‌کنند:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

بیایید با افزودن یک نمودار Sunburst جدید به ارائه آغاز کنیم:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```

{{% alert color="primary" title="همچنین ببینید" %}} 
- [**ایجاد نمودار Sunburst**](/slides/fa/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

اگر نیازی به فرمت‌بندی نقاط داده نمودار وجود داشته باشد، باید از موارد زیر استفاده کنیم:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/IChartDataPointLevelsManager), [IChartDataPointLevel](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatapointlevel) کلاس‌ها و [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) ویژگی دسترسی برای فرمت‌بندی نقاط داده‌ی نمودارهای Treemap و Sunburst را فراهم می‌کنند.  
[**IChartDataPointLevelsManager**] برای دسترسی به دسته‌بندی‌های چندسطحی استفاده می‌شود - این یک محفظه برای اشیای [**IChartDataPointLevel**] است. اساساً این یک wrapper برای [**IChartCategoryLevelsManager**] است که ویژگی‌های خاصی برای نقاط داده اضافه کرده است.  
کلاس [**IChartDataPointLevel**] دو ویژگی دارد: [**Format**] و [**DataLabel**] که دسترسی به تنظیمات مربوطه را فراهم می‌کنند.

## **نمایش مقدار نقطه داده**

نمایش مقدار نقطه داده «Leaf 4»:

```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **تنظیم برچسب و رنگ نقطه داده**

برچسب داده «Branch 1» را به‌گونه‌ای تنظیم کنید که نام سری («Series1») را به‌جای نام دسته‌بندی نمایش دهد. سپس رنگ متن را به زرد تغییر دهید:

```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **تنظیم رنگ شاخه نقطه داده**

رنگ شاخه «Stem 4» را تغییر دهید:

```csharp
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    
    IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

    IChartDataPointLevel stem4branch = dataPoints[9].DataPointLevels[1];
    
    stem4branch.Format.Fill.FillType = FillType.Solid;
    stem4branch.Format.Fill.SolidFillColor.Color = Color.Red;
      
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **پرسش‌های متداول**

**آیا می‌توانم ترتیب (مرتب‌سازی) بخش‌ها در Sunburst/Treemap را تغییر دهم؟**  
خیر. PowerPoint به‌صورت خودکار بخش‌ها را مرتب می‌کند (معمولاً بر حسب مقادیر نزولی و به‌صورت ساعتگرد). Aspose.Slides این رفتار را تقلید می‌کند: شما نمی‌توانید ترتیب را به‌صورت مستقیم تغییر دهید؛ بلکه با پیش‌پردازش داده‌ها به این هدف می‌رسید.

**چگونه تم ارائه بر رنگ‌های بخش‌ها و برچسب‌ها تأثیر می‌گذارد؟**  
رنگ‌های نمودار از [تم/پالت](/slides/fa/net/presentation-theme/) ارائه ارث می‌برند مگر اینکه به‌صورت صریح پر/فونت‌ها را تنظیم کنید. برای نتایج ثابت، پرهای جامد و فرمت‌بندی متن را در سطوح مورد نیاز قفل کنید.

**آیا خروجی به PDF/PNG رنگ‌های سفارشی شاخه و تنظیمات برچسب‌ها را حفظ می‌کند؟**  
بله. هنگام صادرات ارائه، تنظیمات نمودار (پرها، برچسب‌ها) در فرمت‌های خروجی حفظ می‌شوند زیرا Aspose.Slides با فرمت‌بندی اعمال‌شده بر نمودار رندر می‌کند.

**آیا می‌توانم مختصات واقعی یک برچسب/عنصر را برای قرار دادن لایه سفارشی بالای نمودار محاسبه کنم؟**  
بله. پس از اعتبارسنجی چیدمان نمودار، `ActualX`/`ActualY` برای عناصر (مثلاً یک [DataLabel](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/datalabel/)) در دسترس هستند که به موقعیت‌یابی دقیق لایه‌های سفارشی کمک می‌کند.