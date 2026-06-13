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
- ذخیره PowerPoint به عنوان JPG
- ذخیره ارائه به عنوان JPG
- ذخیره اسلاید به عنوان JPG
- ذخیره PPT به عنوان JPG
- ذخیره PPTX به عنوان JPG
- صدور PPT به JPG
- صدور PPTX به JPG
- C++
- Aspose.Slides
description: "تبدیل اسلایدهای PowerPoint (PPT، PPTX) به تصاویر JPG با کیفیت بالا در C++ با Aspose.Slides با استفاده از نمونه‌های کد سریع و قابل اطمینان."
---
## **معرفی**

تبدیل ارائه‌های PowerPoint و OpenDocument به تصاویر JPG به اشتراک‌گذاری اسلایدها، بهینه‌سازی عملکرد و درج محتوا در وب‌سایت‌ها یا برنامه‌ها کمک می‌کند. Aspose.Slides برای C++ به شما امکان تبدیل فایل‌های PPTX، PPT و ODP به تصاویر JPEG با کیفیت بالا را می‌دهد. این راهنما روش‌های مختلف تبدیل را توضیح می‌دهد.

با این امکانات، پیاده‌سازی مشاهده‌گر ارائه خود و ایجاد تصویر بندانگشتی برای هر اسلاید آسان است. این می‌تواند مفید باشد اگر بخواهید اسلایدهای ارائه را از کپی شدن محافظت کنید یا ارائه را در حالت فقط‑خواندنی نمایش دهید. Aspose.Slides به شما اجازه می‌دهد کل ارائه یا یک اسلاید خاص را به فرمت‌های تصویری تبدیل کنید.

## **تبدیل اسلایدهای ارائه به تصاویر JPG**

Here are the steps to convert a PPT, PPTX, or ODP file to JPG:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) class.
1. Get the slide object of the [ISlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/) type from the presentation's slide collection.
1. Create an image of the slide using the [ISlide.GetImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/getimage/) method.
1. Call the [IImage.Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/save/) method on the image object. Pass the output file name and image format as arguments.

{{% alert color="primary" %}} 

**Note:** تبدیل PPT، PPTX یا ODP به JPG با تبدیل به سایر فرمت‌ها در API Aspose.Slides برای C++ متفاوت است. برای سایر فرمت‌ها معمولاً از متد [IPresentation.Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/save/) استفاده می‌کنید. اما برای تبدیل به JPG باید از متد [IImage.Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/save/) استفاده کنید.

{{% /alert %}} 

```cpp
float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // تصویر اسلاید را با مقیاس مشخص شده ایجاد کنید.
    // تصویر را به صورت JPEG در دیسک ذخیره کنید.
    auto image = slide->GetImage(scaleX, scaleY);

    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **تبدیل اسلایدها به JPG با ابعاد سفارشی**

برای تغییر ابعاد تصاویر JPG تولید شده، می‌توانید اندازه تصویر را با عبور دادن آن به متد [ISlide.GetImage(Size)](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method) تنظیم کنید. این امکان را به شما می‌دهد تا تصاویر با مقادیر عرض و ارتفاع خاص تولید کنید و اطمینان حاصل کنید که خروجی مطابق نیازهای شما برای وضوح و نسبت تصویر باشد. این انعطاف‌پذیری به‌ویژه هنگام تولید تصاویر برای برنامه‌های وب، گزارش‌ها یا مستندات که ابعاد دقیق تصویر مورد نیاز است، مفید است.

```cpp
Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // یک تصویر اسلاید با اندازهٔ مشخص ایجاد کنید.
    auto image = slide->GetImage(imageSize);

    // تصویر را در قالب JPEG به دیسک ذخیره کنید.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **رندر نظرات هنگام ذخیره اسلایدها به صورت تصویر**

Aspose.Slides برای C++ ویژگی‌ای فراهم می‌کند که به شما امکان رندر نظرات روی اسلایدهای یک ارائه را هنگام تبدیل آنها به تصاویر JPG می‌دهد. این قابلیت به‌ویژه برای حفظ حاشیه‌ها، بازخوردها یا بحث‌هایی که توسط همکاران در ارائه‌های PowerPoint اضافه شده‌اند، مفید است. با فعال‌سازی این گزینه، اطمینان حاصل می‌کنید که نظرات در تصاویر تولید شده قابل مشاهده هستند و بررسی و اشتراک‌گذاری بازخورد بدون نیاز به باز کردن فایل ارائه اصلی آسان‌تر می‌شود.

فرض کنید فایلی به نام "sample.pptx" داریم که یک اسلاید حاوی نظرات دارد:

![اسلاید با نظرات](slide_with_comments.png)

کد C++ زیر اسلاید را به تصویر JPG تبدیل می‌کند در حالی که نظرات را حفظ می‌کند:

```cpp
float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // گزینه‌ها را برای نظرات اسلاید تنظیم کنید.
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // اسلاید اول را به تصویر تبدیل کنید.
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);
        
    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

نتیجه:

![تصویر JPG با نظرات](image_with_comments.png)

## **موارد مرتبط**

به گزینه‌های دیگر برای تبدیل PPT، PPTX یا ODP به تصاویر، مانند موارد زیر نگاه کنید:

- [تبدیل PowerPoint به GIF](/slides/fa/cpp/convert-powerpoint-to-animated-gif/)
- [تبدیل PowerPoint به PNG](/slides/fa/cpp/convert-powerpoint-to-png/)
- [تبدیل PowerPoint به TIFF](/slides/fa/cpp/convert-powerpoint-to-tiff/)
- [تبدیل PowerPoint به SVG](/slides/fa/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

برای مشاهده چگونگی تبدیل PowerPoint به تصاویر JPG توسط Aspose.Slides، این مبدل‌های آنلاین رایگان را امتحان کنید: PowerPoint [PPTX به JPG](https://products.aspose.app/slides/fa/conversion/pptx-to-jpg) و [PPT به JPG](https://products.aspose.app/slides/fa/conversion/ppt-to-jpg). 

{{% /alert %}}

![مبدل آنلاین رایگان PPTX به JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose یک [برنامه وب رایگان Collage](https://products.aspose.app/slides/fa/collage) ارائه می‌دهد. با استفاده از این سرویس آنلاین می‌توانید تصاویر [JPG به JPG](https://products.aspose.app/slides/fa/collage/jpg) یا PNG به PNG را ترکیب کنید، [شبکه‌های عکس](https://products.aspose.app/slides/fa/collage/photo-grid) بسازید و غیره.

با استفاده از همان اصول توصیف‌شده در این مقاله می‌توانید تصاویر را از یک فرمت به فرمت دیگر تبدیل کنید. برای اطلاعات بیشتر این صفحات را ببینید: تبدیل [تصویر به JPG](https://products.aspose.com/slides/fa/cpp/conversion/image-to-jpg/); تبدیل [JPG به تصویر](https://products.aspose.com/slides/fa/cpp/conversion/jpg-to-image/); تبدیل [JPG به PNG](https://products.aspose.com/slides/fa/cpp/conversion/jpg-to-png/), تبدیل [PNG به JPG](https://products.aspose.com/slides/fa/cpp/conversion/png-to-jpg/); تبدیل [PNG به SVG](https://products.aspose.com/slides/fa/cpp/conversion/png-to-svg/), تبدیل [SVG به PNG](https://products.aspose.com/slides/fa/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **سوالات متداول**

**آیا این روش از تبدیل دسته‌ای پشتیبانی می‌کند؟**

بله، Aspose.Slides امکان تبدیل دسته‌ای چندین اسلاید به JPG را در یک عملیات واحد فراهم می‌کند.

**آیا تبدیل از SmartArt، نمودارها و سایر اشیای پیچیده پشتیبانی می‌کند؟**

بله، Aspose.Slides تمام محتوا شامل SmartArt، نمودارها، جداول، شکل‌ها و موارد دیگر را رندر می‌کند. با این حال، دقت رندر ممکن است نسبت به PowerPoint کمی متفاوت باشد، به‌ویژه هنگام استفاده از قلم‌های سفارشی یا قلم‌های گم‌شده.

**آیا محدودیتی برای تعداد اسلایدهای قابل پردازش وجود دارد؟**

خود Aspose.Slides هیچ محدودیت سخت‌گیرانه‌ای برای تعداد اسلایدهای قابل پردازش اعمال نمی‌کند. با این حال، ممکن است هنگام کار با ارائه‌های بزرگ یا تصاویر با وضوح بالا با خطای کمبود حافظه مواجه شوید.