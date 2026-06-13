---
title: تبدیل اسلایدهای ارائه به تصاویر در C++
linktitle: اسلاید به تصویر
type: docs
weight: 41
url: /fa/cpp/convert-slide/
keywords:
- تبدیل اسلاید
- صادرات اسلاید
- اسلاید به تصویر
- ذخیره اسلاید به عنوان تصویر
- اسلاید به PNG
- اسلاید به JPEG
- اسلاید به بیت‌مپ
- اسلاید به TIFF
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "اسلایدها را از فرمت‌های PPT، PPTX و ODP به تصاویر در C++ با استفاده از Aspose.Slides تبدیل کنید—رندر سریع و با کیفیت بالا همراه با مثال‌های کد واضح."
---
## **مقدمه**

Aspose.Slides برای C++ به شما امکان می‌دهد اسلایدهای ارائه PowerPoint و OpenDocument را به راحتی به قالب‌های تصویری مختلف تبدیل کنید، از جمله BMP، PNG، JPG (JPEG)، GIF و سایرین.

برای تبدیل یک اسلاید به تصویر، مراحل زیر را دنبال کنید:

1. تنظیمات تبدیل دلخواه را تعریف کنید و اسلایدهایی که می‌خواهید صادر کنید را با استفاده از موارد زیر انتخاب کنید:
    - رابط [ITiffOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/itiffoptions/)
    - رابط [IRenderingOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/irenderingoptions/)
2. با فراخوانی متد [GetImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/getimage/) تصویر اسلاید را تولید کنید.

کلاس [Bitmap](https://reference.aspose.com/slides/fa/cpp/system.drawing/bitmap/) یک شیء است که به شما امکان می‌دهد با تصاویر تعریف‌شده با داده‌های پیکسل کار کنید. می‌توانید از یک نمونه از این کلاس برای ذخیره تصاویر در طیف وسیعی از قالب‌ها (BMP، JPG، PNG و غیره) استفاده کنید.

## **تبدیل اسلایدها به بیت‌مپ‌ها و ذخیره تصویرها در قالب PNG**

می‌توانید یک اسلاید را به شیء بیت‌مپ تبدیل کنید و مستقیماً در برنامه خود استفاده نمایید. همچنین می‌توانید یک اسلاید را به بیت‌مپ تبدیل کنید و سپس تصویر را در قالب JPEG یا هر قالب دلخواه دیگری ذخیره کنید.

این کد C++ نشان می‌دهد چگونه اسلاید اول یک ارائه را به شیء بیت‌مپ تبدیل کرده و سپس تصویر را در قالب PNG ذخیره کنید:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// اسلاید اول ارائه را به بیت‌مپ تبدیل کنید.
auto image = presentation->get_Slide(0)->GetImage();

// تصویر را در قالب PNG ذخیره کنید.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **تبدیل اسلایدها به تصاویر با اندازه‌های سفارشی**

ممکن است نیاز داشته باشید تصویری با اندازه خاص دریافت کنید. با استفاده از یک overload از متد [GetImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/getimage/)، می‌توانید اسلاید را به تصویری با ابعاد مشخص (عرض و ارتفاع) تبدیل کنید.

این کد نمونه نشان می‌دهد چگونه این کار انجام شود:

```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// اسلاید اول ارائه را به بیت‌مپ با اندازه مشخص شده تبدیل کنید.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// تصویر را در قالب JPEG ذخیره کنید.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **تبدیل اسلایدهای دارای یادداشت و نظرات به تصاویر**

برخی اسلایدها ممکن است حاوی یادداشت‌ها و نظرات باشند.

Aspose.Slides دو اینترفیس—[ITiffOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/itiffoptions/) و [IRenderingOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/irenderingoptions/)—را فراهم می‌کند که به شما امکان می‌دهد رندر اسلایدهای ارائه به تصویر را کنترل کنید. هر دو اینترفیس شامل متد `set_SlidesLayoutOptions` هستند که به شما اجازه می‌دهد رندر یادداشت‌ها و نظرات یک اسلاید را هنگام تبدیل به تصویر تنظیم کنید.

با کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/notescommentslayoutingoptions/) می‌توانید موقعیت دلخواه خود برای یادداشت‌ها و نظرات در تصویر نهایی مشخص کنید.

این کد C++ نشان می‌دهد چگونه یک اسلاید همراه با یادداشت‌ها و نظرات را تبدیل کنید:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// Load a presentation file.
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // موقعیت یادداشت‌ها را تنظیم کنید.
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // موقعیت نظرات را تنظیم کنید.
notesCommentsOptions->set_CommentsAreaWidth(500);                          // عرض ناحیه نظرات را تنظیم کنید.
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // رنگ ناحیه نظرات را تنظیم کنید.

// Create the rendering options.
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// Convert the first slide of the presentation to an image.
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// Save the image in the GIF format.
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="یادداشت" color="warning" %}} 

در هر فرآیند تبدیل اسلاید به تصویر، متد [set_NotesPosition](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) نمی‌تواند مقدار `BottomFull` را اعمال کند (برای مشخص کردن موقعیت یادداشت‌ها) زیرا متن یک یادداشت ممکن است بسیار بزرگ باشد و نتواند در اندازه تصویر مشخص شده جای بگیرد.

{{% /alert %}} 

## **تبدیل اسلایدها به تصاویر با استفاده از گزینه‌های TIFF**

اینترفیس [ITiffOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/itiffoptions/) کنترل بیشتری بر تصویر TIFF خروجی فراهم می‌کند؛ به شما اجازه می‌دهد پارامترهایی مانند اندازه، وضوح، پالت رنگ و موارد دیگر را مشخص کنید.

این کد C++ یک فرآیند تبدیل را نشان می‌دهد که در آن گزینه‌های TIFF برای خروجی یک تصویر سیاه‑سفید با وضوح 300 DPI و اندازه 2160 × 2800 استفاده می‌شود:

```cpp 
// یک فایل ارائه را بارگذاری کنید.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// اولین اسلاید را از ارائه دریافت کنید.
auto slide = presentation->get_Slide(0);

// تنظیمات تصویر خروجی TIFF را پیکربندی کنید.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // تنظیم اندازه تصویر.
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // تنظیم فرمت پیکسل (سیاه و سفید).
tiffOptions->set_DpiX(300);                                         // تنظیم وضوح افقی.
tiffOptions->set_DpiY(300);                                         // تنظیم وضوح عمودی.

// اسلاید را با گزینه‌های مشخص به تصویر تبدیل کنید.
auto image = slide->GetImage(tiffOptions);

// تصویر را در قالب TIFF ذخیره کنید.
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **تبدیل تمام اسلایدها به تصاویر**

Aspose.Slides به شما امکان می‌دهد تمام اسلایدهای یک ارائه را به تصاویر تبدیل کنید و به‌طور مؤثری کل ارائه را به مجموعه‌ای از تصاویر تبدیل نمایید.

این کد نمونه نشان می‌دهد چگونه تمام اسلایدهای یک ارائه را به تصاویر تبدیل کنید در C++:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// ارائه را به صورت اسلاید به اسلاید به تصاویر رندر کنید.
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // کنترل اسلایدهای مخفی (اسلایدهای مخفی رندر نشوند).
    if (presentation->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // اسلاید را به تصویر تبدیل کنید.
    auto image = presentation->get_Slide(i)->GetImage(scaleX, scaleY);

    // تصویر را در قالب JPEG ذخیره کنید.
    image->Save(String::Format(u"Slide_{0}.jpg", i), ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **سوالات متداول**

**آیا Aspose.Slides از رندر اسلایدها با انیمیشن‌ها پشتیبانی می‌کند؟**

خیر، متد `GetImage` فقط یک تصویر ثابت از اسلاید را ذخیره می‌کند و انیمیشن‌ها را شامل نمی‌شود.

**آیا می‌توان اسلایدهای مخفی را به عنوان تصویر صادر کرد؟**

بله، اسلایدهای مخفی می‌توانند همانند اسلایدهای معمولی پردازش شوند. فقط اطمینان حاصل کنید که در حلقه پردازش گنجانده شده‌اند.

**آیا می‌توان تصاویر را با سایه‌ها و افکت‌ها ذخیره کرد؟**

بله، Aspose.Slides هنگام ذخیره اسلایدها به عنوان تصویر، رندر سایه‌ها، شفافیت و سایر افکت‌های گرافیکی را پشتیبانی می‌کند.