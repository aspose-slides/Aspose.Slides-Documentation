---
title: تبدیل PPT و PPTX به JPG در C++
linktitle: PowerPoint به JPG
type: docs
weight: 60
url: /fa/cpp/convert-powerpoint-to-jpg/
keywords: 
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به JPG
- ارائه به JPG
- اسلاید به JPG
- PPT به JPG
- PPTX به JPG
- ذخیره PowerPoint به صورت JPG
- ذخیره ارائه به صورت JPG
- ذخیره اسلاید به صورت JPG
- ذخیره PPT به JPG
- ذخیره PPTX به JPG
- خروجی PPT به JPG
- خروجی PPTX به JPG
- C++
- Aspose.Slides
description: "اسلایدهای PowerPoint (PPT، PPTX) را به تصاویر JPG با کیفیت بالا در C++ با استفاده از Aspose.Slides و نمونه‌های کد سریع و قابل اعتماد تبدیل کنید."
---
## **مقدمه**

تبدیل ارائه‌های PowerPoint و OpenDocument به تصاویر JPG به اشتراک‌گذاری اسلایدها، بهینه‌سازی عملکرد و ادغام محتوا در وب‌سایت‌ها یا برنامه‌ها کمک می‌کند. Aspose.Slides برای C++ به شما امکان می‌دهد فایل‌های PPTX، PPT و ODP را به تصاویر JPEG با کیفیت بالا تبدیل کنید. این راهنما روش‌های مختلف تبدیل را توضیح می‌دهد.

با این ویژگی‌ها، پیاده‌سازی نمایشگر شخصی ارائه و ایجاد تصویر بندانگشتی برای هر اسلاید آسان می‌شود. این می‌تواند مفید باشد اگر بخواهید اسلایدهای ارائه را از کپی‌برداری محافظت کنید یا ارائه را در حالت فقط‑خواندنی نشان دهید. Aspose.Slides به شما اجازه می‌دهد کل ارائه یا اسلاید خاصی را به فرمت‌های تصویری تبدیل کنید.

## **تبدیل اسلایدهای ارائه به تصاویر JPG**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. شی اسلاید از نوع [ISlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/) را از مجموعه اسلایدهای ارائه دریافت کنید.
3. با استفاده از متد [ISlide.GetImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/getimage/) یک تصویر از اسلاید ایجاد کنید.
4. متد [IImage.Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/save/) را بر روی شئ تصویر فراخوانی کنید. نام فایل خروجی و فرمت تصویر را به عنوان آرگومان پاس دهید.

{{% alert color="info" %}} 

**توجه:** تبدیل PPT، PPTX یا ODP به JPG با تبدیل به سایر فرمت‌ها در API Aspose.Slides برای C++ متفاوت است. برای سایر فرمت‌ها، معمولاً از متد [IPresentation.Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/save/) استفاده می‌کنید. اما برای تبدیل به JPG، باید از متد [IImage.Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/save/) استفاده کنید.

{{% /alert %}} 

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/enumerator_adapter.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // یک تصویر اسلاید با مقیاس مشخص ایجاد کنید.
    auto image = slide->GetImage(scaleX, scaleY);

    // تصویر را در قالب JPEG در دیسک ذخیره کنید.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **تبدیل اسلایدها به JPG با ابعاد سفارشی**

برای تغییر ابعاد تصاویر JPG حاصل، می‌توانید اندازه تصویر را با عبور دادن آن به متد [ISlide.GetImage(Size)](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method) تنظیم کنید. این امکان را به شما می‌دهد تا تصاویری با مقادیر عرض و ارتفاع مشخص تولید کنید و خروجی با نیازهای شما برای وضوح و نسبت تصویر مطابقت داشته باشد. این انعطاف‌پذیری به‌ویژه هنگام تولید تصاویر برای برنامه‌های وب، گزارش‌ها یا مستندات که ابعاد دقیق تصویر لازم است، مفید است.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

System::Drawing::Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // یک تصویر اسلاید با اندازهٔ مشخص ایجاد کنید.
    auto image = slide->GetImage(imageSize);

    // تصویر را در قالب JPEG بر روی دیسک ذخیره کنید.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **رندر نظرات هنگام ذخیره اسلایدها به‌صورت تصویر**

Aspose.Slides برای C++ ویژگی‌ای ارائه می‌دهد که به شما امکان می‌دهد نظرات روی اسلایدهای یک ارائه را هنگام تبدیل به تصاویر JPG رندر کنید. این عملکرد به‌ویژه برای حفظ حاشیه‌نویسی‌ها، بازخوردها یا بحث‌های اضافه‌شده توسط همکاران در ارائه‌های PowerPoint مفید است. با فعال‌سازی این گزینه، اطمینان می‌یابید که نظرات در تصاویری که تولید می‌شوند قابل مشاهده هستند و مرور و به‌اشتراک‌گذاری بازخوردها بدون نیاز به باز کردن فایل اصلی ارائه آسان‌تر می‌شود.

فرض کنید فایلی به نام "sample.pptx" داریم که شامل اسلایدی با نظرات است:

![اسلاید با نظرات](slide_with_comments.png)

کد C++ زیر اسلاید را به تصویر JPG تبدیل می‌کند در حالی که نظرات را حفظ می‌کند:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // تنظیم گزینه‌ها برای نظرات اسلاید.
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // تبدیل اولین اسلاید به تصویر.
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

نتیجه:

![تصویر JPG با نظرات](image_with_comments.png)

## **موارد مرتبط**

گزینۀ دیگر برای تبدیل PPT، PPTX یا ODP به تصویر را ببینید، مانند:

- [تبدیل PowerPoint به GIF](/slides/fa/cpp/convert-powerpoint-to-animated-gif/)
- [تبدیل PowerPoint به PNG](/slides/fa/cpp/convert-powerpoint-to-png/)
- [تبدیل PowerPoint به TIFF](/slides/fa/cpp/convert-powerpoint-to-tiff/)
- [تبدیل PowerPoint به SVG](/slides/fa/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 

برای مشاهده نحوه تبدیل PowerPoint به تصاویر JPG توسط Aspose.Slides، این مبدل‌های آنلاین رایگان را امتحان کنید: PowerPoint [PPTX به JPG](https://products.aspose.app/slides/fa/conversion/pptx-to-jpg) و [PPT به JPG](https://products.aspose.app/slides/fa/conversion/ppt-to-jpg). 

{{% /alert %}}

![مبدل آنلاین رایگان PPTX به JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose یک برنامه وب رایگان [Collage](https://products.aspose.app/slides/fa/collage) ارائه می‌دهد. با استفاده از این سرویس آنلاین، می‌توانید تصاویر [JPG به JPG](https://products.aspose.app/slides/fa/collage/jpg) یا PNG به PNG را ادغام کنید، [شبکه‌های عکس](https://products.aspose.app/slides/fa/collage/photo-grid) ایجاد کنید و غیره.

با استفاده از اصول مشابه توضیح داده‌شده در این مقاله، می‌توانید تصاویر را از یک فرمت به فرمت دیگر تبدیل کنید. برای اطلاعات بیشتر، به این صفحات مراجعه کنید: تبدیل [تصویر به JPG](https://products.aspose.com/slides/fa/cpp/conversion/image-to-jpg/); تبدیل [JPG به تصویر](https://products.aspose.com/slides/fa/cpp/conversion/jpg-to-image/); تبدیل [JPG به PNG](https://products.aspose.com/slides/fa/cpp/conversion/jpg-to-png/)، تبدیل [PNG به JPG](https://products.aspose.com/slides/fa/cpp/conversion/png-to-jpg/); تبدیل [PNG به SVG](https://products.aspose.com/slides/fa/cpp/conversion/png-to-svg/)، تبدیل [SVG به PNG](https://products.aspose.com/slides/fa/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **سوالات متداول**

### آیا این روش از تبدیل دسته‌جمعی پشتیبانی می‌کند؟

بله، Aspose.Slides امکان تبدیل دسته‌جمعی چندین اسلاید به JPG را در یک عملیات واحد فراهم می‌کند.

### آیا تبدیل از SmartArt، نمودارها و سایر اشیای پیچیده پشتیبانی می‌کند؟

بله، Aspose.Slides تمام محتوا از جمله SmartArt، نمودارها، جدول‌ها، اشکال و موارد دیگر را رندر می‌کند. با این حال، دقت رندر ممکن است نسبت به PowerPoint کمی متفاوت باشد، به‌ویژه هنگام استفاده از قلم‌های سفارشی یا گمشده.

### آیا محدودیتی در تعداد اسلایدهایی که می‌توان پردازش کرد وجود دارد؟

Aspose.Slides به‌طور خودکار محدودیت سخت‌گیرانه‌ای بر تعداد اسلایدهایی که می‌توانید پردازش کنید اعمال نمی‌کند. اما ممکن است هنگام کار با ارائه‌های بزرگ یا تصاویر با وضوح بالا با خطای کمبود حافظه مواجه شوید.