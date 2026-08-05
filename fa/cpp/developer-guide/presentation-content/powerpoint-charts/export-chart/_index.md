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
description: "بیاموزید چگونه نمودارهای ارائه را با Aspose.Slides برای C++ صادر کنید، از فرمت‌های PPT و PPTX پشتیبانی می‌کند و گزارش‌دهی را در هر جریان کاری ساده می‌کند."
---
## **مرور کلی**

Aspose.Slides به شما اجازه می‌دهد یک نمودار را از یک ارائه به عنوان تصویر صادر کنید. این مقاله نشان می‌دهد چگونه از یک نمودار تصویر دریافت کنید و آن را ذخیره کنید، که وقتی نیاز به استفاده مجدد از تصاویر نمودار خارج از ارائه PowerPoint دارید مفید است.

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

**آیا می‌توانم یک نمودار را به‌جای تصویر رستر به‌صورت برداری (SVG) صادر کنم؟**

بله. یک نمودار یک شکل است و محتویات آن می‌تواند با استفاده از [روش ذخیره‌سازی shape-to-SVG](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shape/writeassvg/) به SVG ذخیره شود.

**چگونه می‌توانم اندازه دقیق نمودار صادرشده را بر حسب پیکسل تنظیم کنم؟**

از overloadهای رندر تصویر استفاده کنید که به شما امکان مشخص کردن اندازه یا مقیاس را می‌دهند — کتابخانه از رندر اشیاء با ابعاد یا مقیاس تعیین‌شده پشتیبانی می‌کند.

**اگر پس از صادر کردن، قلم‌های برچسب‌ها و افسانه (legend) اشتباه نشان داده شوند، چه کار باید بکنم؟**

از طریق [بارگذاری قلم‌های مورد نیاز](/slides/fa/cpp/custom-font/) با [FontsLoader](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/) استفاده کنید تا رندر نمودار معیارها و ظاهر متن را حفظ کند.

**آیا فرآیند صادرات، تم، سبک‌ها و افکت‌های PowerPoint را رعایت می‌کند؟**

بله. رندر Aspose.Slides قالب‌بندی ارائه (تم‌ها، سبک‌ها، پرکننده‌ها، افکت‌ها) را دنبال می‌کند، بنابراین ظاهر نمودار حفظ می‌شود.

**در کجا می‌توانم قابلیت‌های رندر/صادرات موجود فراتر از تصاویر نمودار را پیدا کنم؟**

به بخش صادراتی [API](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/)/[مستندات](/slides/fa/cpp/convert-powerpoint/) برای اهداف خروجی (مانند [PDF](/slides/fa/cpp/convert-powerpoint-to-pdf/)، [SVG](/slides/fa/cpp/render-a-slide-as-an-svg-image/)، [XPS](/slides/fa/cpp/convert-powerpoint-to-xps/)، [HTML](/slides/fa/cpp/convert-powerpoint-to-html/)، و غیره) و گزینه‌های رندر مرتبط مراجعه کنید.