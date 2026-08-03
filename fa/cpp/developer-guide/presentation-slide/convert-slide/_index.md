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
description: "اسلایدها را از فرمت‌های PPT، PPTX و ODP به تصاویر در C++ با استفاده از Aspose.Slides تبدیل کنید — رندرینگ سریع و با کیفیت بالا با مثال‌های کد واضح."
---
## **مقدمه**

Aspose.Slides for C++ به شما امکان می‌دهد اسلایدهای ارائه PowerPoint و OpenDocument را به‌راحتی به فرمت‌های تصویری مختلف از جمله BMP، PNG، JPG (JPEG)، GIF و ... تبدیل کنید.

برای تبدیل یک اسلاید به تصویر، مراحل زیر را دنبال کنید:

1. تنظیمات تبدیل مورد نظر را تعریف کنید و اسلایدهایی را که می‌خواهید صادر کنید انتخاب کنید با استفاده از:
    - رابط [ITiffOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/itiffoptions/) ، یا
    - رابط [IRenderingOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/irenderingoptions/) .
2. تصویر اسلاید را با فراخوانی متد [GetImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/getimage/) تولید کنید.

یک [Bitmap](https://reference.aspose.com/slides/fa/cpp/system.drawing/bitmap/) شی‌ای است که به شما امکان کار با تصاویری که توسط داده‌های پیکسل تعریف شده‌اند را می‌دهد. می‌توانید از یک نمونه از این کلاس برای ذخیره تصاویر در مجموعه گسترده‌ای از فرمت‌ها (BMP، JPG، PNG و ...) استفاده کنید.

## **تبدیل اسلایدها به بیت‌مپ و ذخیره تصاویر در قالب PNG**

می‌توانید اسلاید را به یک شی بیت‌مپ تبدیل کنید و مستقیماً در برنامه خود استفاده کنید. به‌طور جایگزین، می‌توانید اسلاید را به بیت‌مپ تبدیل کنید و سپس تصویر را در فرمت JPEG یا هر فرمت دلخواه دیگری ذخیره نمایید.

این کد C++ نشان می‌دهد که چگونه اولین اسلاید یک ارائه را به شی بیت‌مپ تبدیل کرده و سپس تصویر را در قالب PNG ذخیره کنید:

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

ممکن است نیاز داشته باشید تصویری با اندازه خاص بدست آورید. با استفاده از یک overload از متد [GetImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/getimage/)، می‌توانید اسلاید را به تصویر با ابعاد مشخص (عرض و ارتفاع) تبدیل کنید.

این نمونه کد نشان می‌دهد که چگونه این کار را انجام دهید:

```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// اسلاید اول ارائه را به بیت‌مپ با اندازه مشخص تبدیل کنید.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// تصویر را در قالب JPEG ذخیره کنید.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **تبدیل اسلایدها با یادداشت‌ها و نظرات به تصاویر**

برخی اسلایدها ممکن است شامل یادداشت‌ها و نظرات باشند.

Aspose.Slides دو رابط—[ITiffOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/itiffoptions/) و [IRenderingOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/irenderingoptions/)—را فراهم می‌کند که به شما اجازه می‌دهد رندر اسلایدهای ارائه به تصویر را کنترل کنید. هر دو رابط شامل متد `set_SlidesLayoutOptions` هستند که امکان پیکربندی رندر یادداشت‌ها و نظرات بر روی اسلاید را هنگام تبدیل به تصویر فراهم می‌کند.

با استفاده از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/notescommentslayoutingoptions/) می‌توانید موقعیت دلخواه خود برای یادداشت‌ها و نظرات را در تصویر نهایی تعیین کنید.

این کد C++ نشان می‌دهد که چگونه اسلایدی با یادداشت‌ها و نظرات را تبدیل کنید:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// فایل ارائه را بارگذاری کنید.
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // موقعیت یادداشت‌ها را تنظیم کنید.
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // موقعیت نظرات را تنظیم کنید.
notesCommentsOptions->set_CommentsAreaWidth(500);                          // عرض ناحیه نظرات را تنظیم کنید.
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // رنگ ناحیه نظرات را تنظیم کنید.

// گزینه‌های رندرینگ را ایجاد کنید.
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// اولین اسلاید ارائه را به تصویر تبدیل کنید.
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// تصویر را در قالب GIF ذخیره کنید.
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 

در هر فرآیند تبدیل اسلاید به تصویر، متد [set_NotesPosition](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) نمی‌تواند `BottomFull` را اعمال کند (برای تعیین موقعیت یادداشت‌ها) زیرا متن یک یادداشت ممکن است بسیار بزرگ باشد و نتواند در اندازه تصویر مشخص شده جا بگیرد.

{{% /alert %}} 

## **تبدیل اسلایدها به تصاویر با استفاده از گزینه‌های TIFF**

رابط [ITiffOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/itiffoptions/) کنترل بیشتری بر روی تصویر TIFF خروجی فراهم می‌کند، با امکان مشخص کردن پارامترهایی همچون اندازه، وضوح، پالت رنگ و غیره.

این کد C++ یک فرآیند تبدیل را نشان می‌دهد که در آن گزینه‌های TIFF برای خروجی تصویر سیاه‑سفید با وضوح 300 DPI و اندازه 2160 × 2800 استفاده می‌شود:

```cpp 
// یک فایل ارائه را بارگذاری کنید.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// اولین اسلاید را از ارائه دریافت کنید.
auto slide = presentation->get_Slide(0);

// تنظیمات تصویر خروجی TIFF را پیکربندی کنید.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // اندازه تصویر را تنظیم کنید.
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // فرمت پیکسل را تنظیم کنید (سیاه و سفید).
tiffOptions->set_DpiX(300);                                         // وضوح افقی را تنظیم کنید.
tiffOptions->set_DpiY(300);                                         // وضوح عمودی را تنظیم کنید.

// اسلاید را با گزینه‌های مشخص شده به تصویر تبدیل کنید.
auto image = slide->GetImage(tiffOptions);

// تصویر را در قالب TIFF ذخیره کنید.
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **تبدیل تمام اسلایدها به تصاویر**

Aspose.Slides به شما امکان می‌دهد تمام اسلایدهای یک ارائه را به تصاویر تبدیل کنید و به‌طور مؤثر کل ارائه را به مجموعه‌ای از تصاویر تبدیل کنید.

این نمونه کد نشان می‌دهد که چگونه تمام اسلایدهای یک ارائه را در C++ به تصاویر تبدیل کنید:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// ارائه را اسلاید به اسلاید به تصاویر رندر کنید.
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

## **رندر اموجی رنگی**

{{% alert title="Note" color="warning" %}} 
برای رندر صحیح اموجی‌های رنگی هنگام تبدیل اسلایدهای ارائه به تصاویر، قلم‌های اموجی مورد استفاده در ارائه باید بر روی سیستمی که تبدیل را انجام می‌دهد نصب و در دسترس باشند. به‌عنوان مثال، اگر ارائه از **Segoe UI Emoji** استفاده کند و این قلم موجود نباشد، اموجی‌ها ممکن است به صورت تک‌رنگ در تصاویر خروجی نمایش داده شوند.
{{% /alert %}}

## **سؤالات متداول**

**آیا Aspose.Slides از رندر اسلایدها با انیمیشن‌ها پشتیبانی می‌کند؟**

خیر، متد `GetImage` فقط یک تصویر ثابت از اسلاید را ذخیره می‌کند و انیمیشن‌ها را شامل نمی‌شود.

**آیا می‌توان اسلایدهای مخفی را به عنوان تصویر صادر کرد؟**

بله، اسلایدهای مخفی می‌توانند همانند اسلایدهای عادی پردازش شوند. فقط مطمئن شوید که در حلقه پردازش گنجانده شده‌اند.

**آیا می‌توان تصاویر را با سایه‌ها و اثرات ذخیره کرد؟**

بله، Aspose.Slides از رندر سایه‌ها، شفافیت و سایر افکت‌های گرافیکی هنگام ذخیره اسلایدها به عنوان تصویر پشتیبانی می‌کند.