---
title: تبدیل اسلایدهای PowerPoint به PNG در C++
linktitle: PowerPoint به PNG
type: docs
weight: 30
url: /fa/cpp/convert-powerpoint-to-png/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به PNG
- ارائه به PNG
- اسلاید به PNG
- PPT به PNG
- PPTX به PNG
- ذخیره PPT به صورت PNG
- ذخیره PPTX به صورت PNG
- صادرات PPT به PNG
- صادرات PPTX به PNG
- C++
- Aspose.Slides
description: "با Aspose.Slides برای C++، ارائه‌های PowerPoint را به سرعت به تصاویر PNG با کیفیت بالا تبدیل کنید و نتایج دقیق و خودکار را تضمین نمایید."
---
## **مروری کلی**

این مقاله توضیح می‌دهد چگونه اسلایدهای ارائه را به تصاویر PNG تبدیل کنید با استفاده از Aspose.Slides برای C++. می‌توانید ارائه‌ها را در قالب‌هایی مانند PPT، PPTX و ODP بارگذاری کنید، هر اسلاید را رندر کنید و به‌عنوان یک تصویر PNG جداگانه ذخیره نمایید.

مثال‌های زیر نمایش می‌دهند رندر با مقیاس پیش‌فرض، افزایش مقیاس، تعیین ابعاد خروجی به پیکسل و انتخاب سبک رندر گرادیان.

## **تبدیل PowerPoint به PNG**

یک ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) بارگذاری کنید و اسلایدهای آن را از طریق دسترسی‌گر [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) دریافت کنید. مثال هر اسلاید را با استفاده از [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) بدون پارامتر برای ایجاد تصویر بندانگشتی رندر می‌کند. سپس با فراخوانی [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) همراه با [ImageFormat::Png](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/) هر اسلاید رندر شده را به عنوان تصویر PNG ذخیره می‌نماید.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage();
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
بارگذاری بدون پارامتر [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) با مقیاسی برابر 0.2 رندر می‌شود. برای مثال، اسلایدی با اندازهٔ 720 × 540 نقطه یک تصویر بندانگشتی 144 × 108 پیکسل تولید می‌کند. برای کنترل ابعاد خروجی، از بارگذاری‌های با عوامل مقیاس یا اندازهٔ تصویر صریح نشان داده‌شده در ادامه استفاده کنید.
{{% /alert %}}

## **تبدیل PowerPoint به PNG با ابعاد سفارشی**

عوامل مقیاس افقی و عمودی را به [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) پاس دهید تا ابعاد رندر شده را کنترل کنید. در این مثال هر دو عامل برابر 2 هستند، بنابراین اسلایدی با اندازهٔ 720 × 540 نقطه تصویری 1440 × 1080 پیکسل تولید می‌کند. عوامل مقیاس برابر نسبت ابعاد اسلاید را حفظ می‌کنند. هر تصویر با استفاده از [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) در قالب PNG ذخیره می‌شود.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto scaleX = 2.f;
auto scaleY = scaleX;

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **تبدیل PowerPoint به PNG با اندازه سفارشی**

برای تعیین ابعاد خروجی به پیکسل، به جای عوامل مقیاس یک اندازه به [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) پاس دهید. این مثال هر اسلاید را با ابعاد 960 × 720 پیکسل رندر می‌کند و نتیجه را با [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) ذخیره می‌نماید. برای جلوگیری از کشیدگی تصویر، ابعاد را طوری انتخاب کنید که نسبت ابعاد اسلاید را حفظ کنند.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <drawing/size.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto imageSize = System::Drawing::Size(960, 720);

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(imageSize);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **انتخاب سبک رندر گرادیان**

فرض کنید اسلایدی دارای پر کردن‌های گرادیان باشد، اما انتقال‌ها در PNG استخراج‌شده روشن‌تر یا به‌صورت دیگری نسبت به آنچه در PowerPoint می‌بینید به‌نظر برسند. می‌توانید از متد [SaveOptions::set_GradientStyle](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_gradientstyle/) کلاس [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/) برای انتخاب نحوه رندر کردن گرادیان‌ها استفاده کنید.

فایل [gradient-styles.pptx](gradient-styles.pptx) را دانلود کنید و در پوشهٔ کاری برنامه قرار دهید. اسلاید اول آن شامل دو گرادیان خطی است: از cyan به orange در بالا و از blue به yellow در پایین. هر گرادیان دو توقف دارد، در 0٪ و 100٪.

مثال زیر این ارائه را بارگذاری می‌کند و همان اسلاید اول را در هر دو حالت با [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) رندر می‌نماید.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <DOM/GradientStyle.h>
#include <Export/RenderingOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"gradient-styles.pptx");
auto slide = presentation->get_Slide(0);

auto gradientStyles = { GradientStyle::Default, GradientStyle::PowerPointUI };
for (auto style : gradientStyles)
{
    auto options = MakeObject<RenderingOptions>();
    options->set_GradientStyle(style);

    auto image = slide->GetImage(options, 1.f, 1.f);
    auto styleName = style == GradientStyle::Default ? u"Default" : u"PowerPointUI";
    image->Save(String::Format(u"gradient-{0}.png", styleName), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

تصاویر زیر خروجی همان اسلاید را نشان می‌دهند، به‌طوری که هر تصویر هر دو گرادیان را شامل می‌شود:

| Default | PowerPointUI |
| --- | --- |
| ![گرادیان‌های سیان تا نارنجی و آبی تا زرد رندر شده با Default](gradient-Default.png) | ![همان گرادیان‌ها رندر شده با PowerPointUI](gradient-PowerPointUI.png) |

در این مثال، `Default` رنگ‌های میانی روشن‌تری تولید می‌کند، در حالی که `PowerPointUI` رنگ‌های میانی تیره‌تری تولید می‌کند. تفاوت بسته به رنگ‌ها و توقف‌های گرادیان است.

زمانی که خروجی استاندارد Aspose.Slides به نیازهای شما می‌خورد، `Default` را انتخاب کنید. وقتی اولویت شما تطابق ظاهر با PowerPoint است، `PowerPointUI` را امتحان کنید. هر دو خروجی را با نتیجهٔ موردنظر خود مقایسه کنید؛ هیچ کدام به‌طور کلی بر دیگری برتری ندارند.

## **پرسش‌های متداول**

**چگونه می‌توانم یک شکل خاص، مانند نمودار یا تصویر، را به‌جای کل اسلاید صادر کنم؟**  
Aspose.Slides امکان [ایجاد تصویر بندانگشتی برای شکل‌های منفرد](/slides/fa/cpp/shape-thumbnails/) را دارد و به شما اجازه می‌دهد یک شکل را به‌عنوان تصویر PNG رندر کنید.

**آیا تبدیل موازی بر روی سرور پشتیبانی می‌شود؟**  
بله. برای هر رشته یا فرآیند یک نمونهٔ جداگانه از ارائه استفاده کنید؛ [به‌اشتراک‌گذاری یک نمونهٔ واحد بین رشته‌ها مجاز نیست](/slides/fa/cpp/multithreading/).

**محدودیت‌های حالت ارزیابی هنگام صادرات به PNG چیست؟**  
حالت ارزیابی یک واترمارک به تصاویر خروجی اضافه می‌کند و تا زمانی که لایسنس اعمال شود، [محدودیت‌های دیگر](/slides/fa/cpp/licensing/) اعمال می‌شود.