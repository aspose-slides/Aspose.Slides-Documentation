---
title: افزودن خطوط روند به نمودارهای ارائه در .NET
linktitle: خط روند
type: docs
url: /fa/net/trend-line/
keywords:
- نمودار
- خط روند
- خط روند نمایی
- خط روند خطی
- خط روند لگاریتمی
- خط روند میانگین متحرک
- خط روند چندجمله‌ای
- خط روند توان
- خط روند سفارشی
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌سرعت خطوط روند را در نمودارهای PowerPoint با Aspose.Slides برای .NET اضافه و سفارشی کنید — راهنمای عملی برای جذب مخاطبان شما."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه خطوط روند را به نمودارهای ارائه با استفاده از Aspose.Slides اضافه کنیم. نشان می‌دهد چگونه یک نمودار ایجاد کنیم، خطوط روند را به سری‌های نمودار اضافه کنیم، و با انواع مختلف خطوط روند از جمله نمایی، خطی، لگاریتمی، میانگین متحرک، چندجمله‌ای و توان کار کنیم.

همچنین توضیح می‌دهد چگونه یک خط سفارشی را به نمودار اضافه کنیم با قرار دادن یک شکل خطی، و شامل یک سوالات متداول کوتاه درباره مقادیر پیش‌بینی‌گر جلو و عقب خط روند و اینکه آیا خطوط روند در زمان خروجی به PDF یا SVG و هنگام رندر نمودارها به‌صورت تصویر حفظ می‌شوند یا نه.

## **افزودن خط روند**
Aspose.Slides برای .NET یک API ساده برای مدیریت انواع خطوط روند نمودارها ارائه می‌دهد:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. مرجع یک اسلاید را با استفاده از فهرست (نمایه) آن به دست آورید.
1. یک نمودار با داده‌های پیش‌فرض به همراه هر نوع دلخواه اضافه کنید (در این مثال از ChartType.ClusteredColumn استفاده شده است).
1. افزودن خط روند نمایی برای سری نمودار 1.
1. افزودن خط روند خطی برای سری نمودار 1.
1. افزودن خط روند لگاریتمی برای سری نمودار 2.
1. افزودن خط روند میانگین متحرک برای سری نمودار 2.
1. افزودن خط روند چندجمله‌ای برای سری نمودار 3.
1. افزودن خط روند توان برای سری نمودار 3.
1. ارائه اصلاح‌شده را در یک فایل PPTX بنویسید.

کد زیر برای ایجاد یک نمودار با خطوط روند استفاده می‌شود.

```c#
// ایجاد ارائه خالی
Presentation pres = new Presentation();

// ایجاد نمودار ستون‌های خوشه‌ای
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// افزودن خط روند نمایی برای سری نمودار 1
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// افزودن خط روند خطی برای سری نمودار 1
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// افزودن خط روند لگاریتمی برای سری نمودار 2
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("New log trend line");

// افزودن خط روند میانگین‌متحرک برای سری نمودار 2
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "New TrendLine Name";

// افزودن خط روند چندجمله‌ای برای سری نمودار 3
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// افزودن خط روند توان برای سری نمودار 3
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// ذخیره ارائه
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```

## **افزودن خط سفارشی**
Aspose.Slides برای .NET یک API ساده برای افزودن خطوط سفارشی در نمودار ارائه می‌دهد. برای افزودن یک خط ساده به اسلاید انتخابی ارائه، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس Presentation ایجاد کنید
- مرجع یک اسلاید را با استفاده از Index آن به دست آورید
- یک نمودار جدید با استفاده از متد AddChart که توسط شیء Shapes در دسترس است، ایجاد کنید
- یک AutoShape از نوع خط را با استفاده از متد AddAutoShape که توسط شیء Shapes در دسترس است، اضافه کنید
- رنگ خطوط شکل را تنظیم کنید.
- ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید

کد زیر برای ایجاد یک نمودار با خطوط سفارشی استفاده می‌شود.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.UserShapes.Shapes.AddAutoShape(ShapeType.Line, 0, chart.Height / 2, chart.Width, 0);
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
    pres.Save("AddCustomLines.pptx", SaveFormat.Pptx);
}
```

## **سوالات متداول**

**'forward' و 'backward' برای یک خط روند به چه معنی هستند؟**

آنها طول‌های خط روند هستند که به جلو/به عقب پیش‌بینی می‌شوند: برای نمودارهای scatter (XY) — بر حسب واحدهای محور؛ برای نمودارهای غیر‑scatter — بر حسب تعداد دسته‌ها. فقط مقادیر غیرمنفی مجاز هستند.

**آیا خط روند در هنگام خروجی به PDF یا SVG یا هنگام رندر یک اسلاید به تصویر حفظ می‌شود؟**

بله. Aspose.Slides ارائه‌ها را به [PDF](/slides/fa/net/convert-powerpoint-to-pdf/)/[SVG](/slides/fa/net/render-a-slide-as-an-svg-image/) تبدیل می‌کند و نمودارها را به تصاویر رندر می‌سازد؛ خطوط روند، به‌عنوان بخشی از نمودار، در طول این عملیات‌ها حفظ می‌شوند. یک متد نیز برای [صدور تصویر از نمودار](/slides/fa/net/create-shape-thumbnails/) موجود است.