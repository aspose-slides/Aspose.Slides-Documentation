---
title: صادرات نمودارهای ارائه در .NET
linktitle: صادرات نمودار
type: docs
weight: 90
url: /fa/net/export-chart/
keywords:
  - نمودار
  - نمودار به تصویر
  - نمودار به عنوان تصویر
  - استخراج تصویر نمودار
  - PowerPoint
  - ارائه
  - .NET
  - C#
  - Aspose.Slides
description: "نحوه صادرات نمودارهای ارائه با Aspose.Slides برای .NET را بیاموزید، که از فرمت‌های PPT و PPTX پشتیبانی می‌کند و گزارش‌گیری را به هر جریان کاری ساده می‌سازد."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد یک نمودار را از ارائه به صورت تصویر استخراج کنید. این مقاله نشان می‌دهد چگونه از یک نمودار تصویر بگیرید و آن را ذخیره کنید، که زمانی که نیاز به استفاده مجدد از نمودارها خارج از ارائه پاورپوینت دارید، مفید است.

علاوه بر گردش کار پایه‌ای استخراج تصویر، مقاله به سؤالات رایج مربوط به استخراج نیز می‌پردازد، از جمله ذخیره محتوای نمودار به SVG، کنترل اندازه خروجی از طریق گزینه‌های رندرینگ، بارگذاری فونت‌ها برای حفظ ظاهر برچسب‌ها و legenda، و حفظ فرمت‌بندی اصلی ارائه مانند تم‌ها، سبک‌ها، پرکننده‌ها و اثرها در طول رندرینگ.

## **دریافت تصویر نمودار**
Aspose.Slides for .NET پشتیبانی از استخراج تصویر نمودارهای خاص را فراهم می‌کند. نمونه کد زیر آورده شده است.

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    using (IImage image = chart.GetImage())
    {
        image.Save("image.png", ImageFormat.Png);
    }
}
```

## **پرسش‌های متداول**

**آیا می‌توانم یک نمودار را به صورت برداری (SVG) به جای تصویر رستر صادر کنم؟**

بله. یک نمودار یک شکل است و محتویات آن می‌تواند با استفاده از [روش ذخیره‌سازی شکل به SVG](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/writeassvg/) به SVG ذخیره شود.

**چگونه می‌توانم اندازه دقیق نمودار صادر شده را برحسب پیکسل تنظیم کنم؟**

از overload‌های رندرینگ تصویر که امکان تعیین اندازه یا مقیاس را می‌دهند استفاده کنید—کتابخانه از رندر کردن اشیاء با ابعاد/مقیاس مشخص پشتیبانی می‌کند.

**اگر پس از صادرات فونت‌های برچسب‌ها و legenda اشتباه ظاهر شوند چه کاری باید انجام دهم؟**

[فونت‌های مورد نیاز را بارگذاری کنید](/slides/fa/net/custom-font/) از طریق [FontsLoader](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/) تا رندرینگ نمودار متریک‌ها و ظاهر متن را حفظ کند.

**آیا صادرات قالب‌بندی‌های تم، سبک‌ها و اثرات پاورپوینت را رعایت می‌کند؟**

بله. رندرر Aspose.Slides قالب‌بندی ارائه (تم‌ها، سبک‌ها، پرکننده‌ها، اثرات) را دنبال می‌کند، بنابراین ظاهر نمودار حفظ می‌شود.

**کجا می‌توانم قابلیت‌های دیگر رندرینگ/صادرات فراتر از تصاویر نمودار را پیدا کنم؟**

بخش صادرات [API](https://reference.aspose.com/slides/fa/net/aspose.slides.export/)/[مستندات](/slides/fa/net/convert-powerpoint/) را برای اهداف خروجی (مانند [PDF](/slides/fa/net/convert-powerpoint-to-pdf/)، [SVG](/slides/fa/net/render-a-slide-as-an-svg-image/)، [XPS](/slides/fa/net/convert-powerpoint-to-xps/)، [HTML](/slides/fa/net/convert-powerpoint-to-html/)، و غیره) و گزینه‌های رندرینگ مرتبط ببینید.