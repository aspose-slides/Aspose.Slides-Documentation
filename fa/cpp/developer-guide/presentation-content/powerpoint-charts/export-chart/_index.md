---
title: صادرات نمودارهای ارائه در C++
linktitle: صادرات نمودار
type: docs
weight: 90
url: /fa/cpp/export-chart/
keywords:
- نمودار
- نمودار به تصویر
- نمودار به عنوان تصویر
- استخراج تصویر نمودار
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "نحوه صادرات نمودارهای ارائه با Aspose.Slides برای C++ را بیاموزید، پشتیبانی از قالب‌های PPT و PPTX، و ساده‌سازی گزارش‌گیری در هر گردش کاری."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد یک نمودار را از یک ارائه به‌عنوان تصویر خروجی بگیرید. این مقاله نشان می‌دهد چگونه یک تصویر از نمودار دریافت و ذخیره کنید، که زمانی که نیاز به استفاده مجدد از تصاویر نمودار خارج از یک ارائه PowerPoint دارید، مفید است.

## **دریافت تصویر نمودار**
Aspose.Slides برای C++ پشتیبانی از استخراج تصویر یک نمودار خاص را فراهم می‌کند. مثال نمونه زیر ارائه شده است.

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **سؤالات متداول**

**آیا می‌توانم یک نمودار را به صورت برداری (SVG) به جای تصویر رستر خروجی بگیرم؟**

بله. یک نمودار یک شکل است و محتویات آن می‌تواند با استفاده از [shape-to-SVG saving method](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shape/writeassvg/) به SVG ذخیره شود.

**چگونه می‌توانم اندازه دقیق نمودار خروجی را بر حسب پیکسل تنظیم کنم؟**

از overloadهای image‑rendering که امکان تعیین اندازه یا مقیاس را می‌دهند استفاده کنید؛ کتابخانه امکان رندر اشیا با ابعاد یا مقیاس مشخص را پشتیبانی می‌کند.

**اگر پس از خروجی گرفتن فونت‌های برچسب‌ها و legend نادرست به‌نظر برسند، چه کار کنم؟**

[فونت‌های مورد نیاز](/slides/fa/cpp/custom-font/) را از طریق [FontsLoader](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/) بارگذاری کنید تا رندر نمودار معیارها و ظاهر متن را حفظ کند.

**آیا خروجی گرفتن تم، سبک‌ها و افکت‌های PowerPoint را رعایت می‌کند؟**

بله. رندر Aspose.Slides قالب‌بندی ارائه (تم‌ها، سبک‌ها، پرکننده‌ها، افکت‌ها) را دنبال می‌کند، بنابراین ظاهر نمودار حفظ می‌شود.

**کجا می‌توانم قابلیت‌های رندر/خروجی‌گیری موجود فراتر از تصاویر نمودار را پیدا کنم؟**

به بخش export مستندات [API](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/)/[documentation](/slides/fa/cpp/convert-powerpoint/) برای اهداف خروجی (مانند [PDF](/slides/fa/cpp/convert-powerpoint-to-pdf/)، [SVG](/slides/fa/cpp/render-a-slide-as-an-svg-image/)، [XPS](/slides/fa/cpp/convert-powerpoint-to-xps/)، [HTML](/slides/fa/cpp/convert-powerpoint-to-html/)، و غیره) و گزینه‌های رندر مرتبط مراجعه کنید.