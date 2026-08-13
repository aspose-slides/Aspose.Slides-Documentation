---
title: API عمومی و تغییرات ناسازگار به عقب در Aspose.Slides برای .NET 15.10.0
linktitle: Aspose.Slides برای .NET 15.10.0
type: docs
weight: 200
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-10-0/
keywords:
- مهاجرت
- کد قدیمی
- کد مدرن
- رویکرد قدیمی
- رویکرد مدرن
- پاورپوینت
- سند باز
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای .NET را مرور کنید تا به‌صورت روان‌سازی راه‌حل‌های ارائه PowerPoint PPT, PPTX و ODP خود را منتقل کنید."
---
{{% alert color="info" %}} 

این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و غیره که [اضافه شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-10-0/) یا [حذف شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-10-0/) هستند، و سایر تغییرات معرفی شده با API Aspose.Slides for .NET 15.10.0 را فهرست می‌کند.

{{% /alert %}} 
## **تغییرات API عمومی**
#### **یک VideoPlayerHtmlController جدید برای پشتیبانی از صادر کردن فایل‌های رسانه‌ای به HTML اضافه شد**
کلاس عمومی جدید VideoPlayerHtmlController به فضای نام Aspose.Slides.Export اضافه شده است. با استفاده از یک نمونه از این کلاس کاربر می‌تواند فایل‌های ویدئو و صوتی را به HTML صادر کند.
سازنده‌های VideoPlayerHtmlController پارامترهای زیر را می‌پذیرند:

path: مسیر جایی که فایل‌های ویدئو و صوتی تولید خواهند شد  
fileName: نام فایل HTML  

baseUri: URI پایه‌ای که برای تولید لینک‌ها استفاده خواهد شد  
مثال استفاده:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation("example.pptx"))

{

    const string path = "path";

    const string fileName = "video.html";

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: path, fileName: fileName, baseUri: baseUri);

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    pres.Save(Path.Combine(path, fileName), SaveFormat.Html, htmlOptions);

}

``` 
#### **API انیمیشن سری‌های نمودار اضافه شد**
دو متد جدید به اینترفیس Aspose.Slides.Animation.ISequence اضافه شده‌اند.

``` csharp
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;


 IEffect AddEffect(IChart chart, EffectChartMajorGroupingType type, int index, EffectType effectType, EffectSubtype subtype, EffectTriggerType triggerType);

IEffect AddEffect(IChart chart, EffectChartMinorGroupingType type, int seriesIndex, int categoriesIndex, EffectType effectType, EffectSubtype subtype, EffectTriggerType triggerType);

``` 

این متدها برای پشتیبانی از انیمیشن‌های عناصر نمودار طراحی شده‌اند:
by series  
by categories  
by series elements  
by categories elements  

دو enum جدید EffectChartMajorGroupingType و EffectChartMinorGroupingType که مرتبط با انیمیشن عناصر نمودار هستند معرفی شدند.

برای افزودن انیمیشن سری به نمودار می‌توان از کد زیر استفاده کرد:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string inFileName = "sample.pptx";
string outFileName = "output.pptx";

using (Presentation pres = new Presentation(inFileName))
{
    var slide = pres.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,
        EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMajorGroupingType.BySeries, 0,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMajorGroupingType.BySeries, 1,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMajorGroupingType.BySeries, 2,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMajorGroupingType.BySeries, 3,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    pres.Save(outFileName, SaveFormat.Pptx);
}
``` 

انیمیشن دسته‌بندی‌ها:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string inFileName = "sample.pptx";
string outFileName = "output.pptx";

using (Presentation pres = new Presentation(inFileName))
{
    var slide = pres.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,
        EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMajorGroupingType.ByCategory, 0,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMajorGroupingType.ByCategory, 1,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMajorGroupingType.ByCategory, 2,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMajorGroupingType.ByCategory, 3,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    pres.Save(outFileName, SaveFormat.Pptx);
}
``` 

انیمیشن عناصر سری:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string inFileName = "sample.pptx";
string outFileName = "output.pptx";

using (Presentation pres = new Presentation(inFileName))
{
    var slide = pres.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,
        EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 0, 0,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 0, 1,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 0, 2,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 0, 3,
        EffectType.Appear, EffectSubtype.No

ne, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 1, 0,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGrouping

Type.ByElementInSeries, 1, 1,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline

.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 1, 2,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline

.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 1, 3,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline

.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 2, 0,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline

.MainSequence).AddEffect(chart,
        EffectChartMinor

GroupingType.ByElementInSeries, 2, 1,
        EffectType.Appear, EffectSubtype

None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline

.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 2, 2,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline

.MainSequence).AddEffect(chart,
        EffectChartMinor

GroupingType.ByElementInSeries, 2, 3,
        EffectType.Appear, EffectSubtype

None, EffectTriggerType.AfterPrevious);
    pres.Save(outFileName, SaveFormat.Pptx);
}
``` 

انیمیشن عناصر دسته‌بندی:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string inFileName = "sample.pptx";
string outFileName = "output.pptx";

using (Presentation pres = new Presentation(inFileName))
{
    var slide = pres.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,
        EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 0, 0,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 0, 1,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 0, 2,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 0, 3,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 1, 0,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 1, 1,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 1, 2,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 1, 3,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 2, 0,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 2, 1,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 2, 2,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 2, 3,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    pres.Save(outFileName, SaveFormat.Pptx);
}
```