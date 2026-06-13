---
title: بهینه‌سازی محاسبه‌های نمودار برای ارائه‌ها در .NET
linktitle: محاسبه‌های نمودار
type: docs
weight: 50
url: /fa/net/chart-calculations/
keywords:
- محاسبه‌های نمودار
- عناصر نمودار
- موقعیت عنصر
- موقعیت واقعی
- عنصر فرزند
- عنصر والد
- مقدارهای نمودار
- مقدار واقعی
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "محاسبه‌های نمودار، به‌روزرسانی داده‌ها و کنترل دقت را در Aspose.Slides برای .NET برای فایل‌های PPT و PPTX درک کنید، همراه با مثال‌های عملی کد C#."
---
## **نمای کلی**

Aspose.Slides API‌هایی برای کار با محاسبات نمودار و داده‌های چیدمان در ارائه‌ها فراهم می‌کند. این مقاله نشان می‌دهد چگونه مقادیر واقعی عناصر نمودار، از جمله موقعیت و اندازه واقعی عناصری که رابط `IActualLayout` را پیاده‌سازی می‌کنند و مقادیر واقعی محورها را بازیابی کنید. همچنین توضیح می‌دهد که این مقادیر پس از اعتبارسنجی چیدمان نمودار پر می‌شوند.

علاوه بر این، مقاله نشان می‌دهد چگونه موقعیت واقعی عناصر والد نمودار را به دست آورید و چگونه اجزای نمودار مانند عنوان، محورها، افسانه و خطوط شبکه را مخفی کنید. این مثال‌ها به شما کمک می‌کند تا اطلاعات چیدمان نمودار را بررسی کرده و قابلیت نمایش یا مخفی‌سازی عناصر نمودار را به‌صورت برنامه‌نویسی در ارائه‌های PowerPoint کنترل کنید.

## **محاسبه مقادیر واقعی عناصر نمودار**
Aspose.Slides for .NET یک API ساده برای دریافت این خصوصیات ارائه می‌دهد. این API به شما امکان محاسبه مقادیر واقعی عناصر نمودار را می‌دهد. مقادیر واقعی شامل موقعیت عناصر که رابط IActualLayout را پیاده‌سازی می‌کنند (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) و مقادیر واقعی محورها (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale) می‌شود.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();
    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// ذخیره‌سازی ارائه
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **محاسبه موقعیت واقعی عناصر والد نمودار**
Aspose.Slides for .NET یک API ساده برای دریافت این خصوصیات ارائه می‌دهد. خصوصیات IActualLayout اطلاعاتی درباره موقعیت واقعی عنصر والد نمودار فراهم می‌کنند. برای پر شدن این خصوصیات با مقادیر واقعی، لازم است پیش از آن متد IChart.ValidateChartLayout() را فراخوانی کنید.

```c#
// ایجاد ارائه خالی
using (Presentation pres = new Presentation())
{
   Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
   chart.ValidateChartLayout();

   double x = chart.PlotArea.ActualX;
   double y = chart.PlotArea.ActualY;
   double w = chart.PlotArea.ActualWidth;
   double h = chart.PlotArea.ActualHeight;
}
```

## **مخفی‌سازی عناصر نمودار**
این بخش به شما کمک می‌کند تا نحوه مخفی‌سازی اطلاعات در نمودار را درک کنید. با استفاده از Aspose.Slides for .NET می‌توانید **عنوان، محور عمودی، محور افقی** و **خطوط شبکه** را از نمودار مخفی کنید. مثال کد زیر نشان می‌دهد چگونه از این خصوصیات استفاده کنید.

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    // مخفی‌سازی عنوان نمودار
    chart.HasTitle = false;

    /// مخفی‌سازی محور مقادیر
    chart.Axes.VerticalAxis.IsVisible = false;

    // قابلیت مشاهده محور دسته‌بندی
    chart.Axes.HorizontalAxis.IsVisible = false;

    // مخفی‌سازی افسانه
    chart.HasLegend = false;

    // مخفی‌سازی خطوط شبکه اصلی
    chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series.RemoveAt(i);
    }

    IChartSeries series = chart.ChartData.Series[0];

    series.Marker.Symbol = MarkerStyleType.Circle;
    series.Labels.DefaultDataLabelFormat.ShowValue = true;
    series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.Top;
    series.Marker.Size = 15;

    // تنظیم رنگ خط سری
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```

## **سؤالات متداول**

**آیا کتاب‌کارهای اکسل خارجی می‌توانند به‌عنوان منبع داده استفاده شوند و این موضوع بر بازمحاسبه چه تأثیری دارد؟**

بله. یک نمودار می‌تواند به یک کتاب‌کار خارجی ارجاع دهد: هنگام اتصال یا تازه‌سازی منبع خارجی، فرمول‌ها و مقادیر از آن کتاب‌کار گرفته می‌شود و نمودار در طول عملیات باز/ویرایش به‌روزرسانی‌ها را منعکس می‌کند. API به شما اجازه می‌دهد [مشخص کردن دفتر کار خارجی](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chartdata/setexternalworkbook/) را تنظیم کنید و داده‌های لینک‌شده را مدیریت کنید.

**آیا می‌توانم خطوط روند را بدون پیاده‌سازی رگرسیون خودم محاسبه و نمایش دهم؟**

بله. [خطوط روند](/slides/fa/net/trend-line/) (خطی، نمایی و دیگر انواع) توسط Aspose.Slides اضافه و به‌روزرسانی می‌شوند؛ پارامترهای آن‌ها به‌صورت خودکار از داده‌های سری محاسبه می‌شوند، بنابراین نیازی به پیاده‌سازی محاسبات خودتان ندارید.

**اگر ارائه‌ای دارای چندین نمودار با لینک‌های خارجی باشد، آیا می‌توانم کنترل کنم که هر نمودار از کدام کتاب‌کار برای مقادیر محاسبه‌شده استفاده کند؟**

بله. هر نمودار می‌تواند به [دفتر کار خارجی]‌(https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chartdata/setexternalworkbook/) مخصوص خود اشاره کند، یا می‌توانید به‌صورت مستقل برای هر نمودار کتاب‌کار خارجی را ایجاد یا جایگزین کنید.