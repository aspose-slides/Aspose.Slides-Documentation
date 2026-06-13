---
title: تبدیل ارائه‌های PowerPoint به TIFF همراه با یادداشت‌ها در C++
linktitle: PowerPoint به TIFF همراه با یادداشت‌ها
type: docs
weight: 100
url: /fa/cpp/convert-powerpoint-to-tiff-with-notes/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به TIFF
- ارائه به TIFF
- اسلاید به TIFF
- PPT به TIFF
- PPTX به TIFF
- ذخیره PPT به عنوان TIFF
- ذخیره PPTX به عنوان TIFF
- خروجی PPT به TIFF
- خروجی PPTX به TIFF
- PowerPoint با یادداشت‌ها
- ارائه با یادداشت‌ها
- اسلاید با یادداشت‌ها
- PPT با یادداشت‌ها
- PPTX با یادداشت‌ها
- TIFF با یادداشت‌ها
- C++
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint به TIFF همراه با یادداشت‌ها با استفاده از Aspose.Slides برای C++. یاد بگیرید چگونه اسلایدها را با یادداشت‌های گوینده به‌صورت مؤثر صادر کنید."
---
## **مقدمه**

Aspose.Slides for C++ راه‌حلی ساده برای تبدیل ارائه‌های PowerPoint و OpenDocument (PPT، PPTX و ODP) همراه با یادداشت‌ها به فرمت TIFF فراهم می‌کند. این فرمت برای ذخیره‌سازی تصویر با کیفیت بالا، چاپ و آرشیو اسناد به‌طور گسترده‌ای استفاده می‌شود. با Aspose.Slides می‌توانید نه تنها کل ارائه‌ها را همراه با یادداشت‌های گوینده صادر کنید، بلکه تصویرهای بندانگشتی اسلاید را در نمای Notes Slide نیز تولید کنید. فرآیند تبدیل ساده و کارآمد است و با استفاده از متد `Save` کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) کل ارائه را به مجموعه‌ای از تصاویر TIFF تبدیل می‌کند در حالی که یادداشت‌ها و چیدمان حفظ می‌شوند.

## **تبدیل یک ارائه به TIFF با یادداشت‌ها**

ذخیره یک ارائه PowerPoint یا OpenDocument به TIFF با یادداشت‌ها با استفاده از Aspose.Slides for C++ شامل مراحل زیر است:

1. یک شیء از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید: فایل PowerPoint یا OpenDocument را بارگذاری کنید.
1. گزینه‌های چیدمان خروجی را پیکربندی کنید: از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/notescommentslayoutingoptions/) برای تعیین نحوه نمایش یادداشت‌ها و نظرات استفاده کنید.
1. ارائه را به TIFF ذخیره کنید: گزینه‌های پیکربندی شده را به متد [Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) پاس دهید.

فرض کنید فایلی به نام "speaker_notes.pptx" داریم که اسلاید زیر را شامل می‌شود:

![اسلاید ارائه با یادداشت‌های گوینده](slide_with_notes.png)

قطعه کد زیر نشان می‌دهد چگونه با استفاده از متد [set_SlidesLayoutOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) ارائه را به تصویر TIFF در نمای Notes Slide تبدیل کنیم.

```cpp
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // نمایش یادداشت‌ها در زیر اسلاید.

// پیکربندی گزینه‌های TIFF با چینش یادداشت‌ها.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// ذخیره ارائه به فرمت TIFF همراه با یادادت‌های گوینده.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

نتیجه:

![تصویر TIFF با یادداشت‌های گوینده](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online) را بررسی کنید.
{{% /alert %}}

## **سوالات متداول**

**آیا می‌توانم موقعیت ناحیه یادداشت‌ها را در TIFF نهایی کنترل کنم؟**

بله. از [notes layout settings](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) استفاده کنید تا بین گزینه‌هایی مانند `None`، `BottomTruncated` یا `BottomFull` انتخاب کنید؛ این گزینه‌ها به ترتیب یادداشت‌ها را مخفی می‌کنند، در یک صفحه جا می‌دهند یا اجازه می‌دهند به صفحات اضافی جریان یابند.

**چگونه می‌توانم حجم فایل TIFF با یادداشت‌ها را بدون کاهش قابل‌مشاهده کیفیت کاهش دهم؟**

یک [compression کارآمد](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (مانند `LZW` یا `RLE`) انتخاب کنید، DPI معقولی تنظیم کنید و در صورت امکان از یک [pixel format](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) با بیت کمتر (مانند 8 bpp یا 1 bpp برای تک‌رنگ) استفاده کنید. کمی کاهش [ابعاد تصویر](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/set_imagesize/) نیز می‌تواند بدون آسیب قابل‌مشاهده به خوانایی مفید باشد.

**آیا فونت در یادداشت‌ها بر نتیجه تأثیر می‌گذارد اگر فونت‌های اصلی در سیستم موجود نباشند؟**

بله. فونت‌های گمشده باعث [substitution](/slides/fa/cpp/font-selection-sequence/) می‌شوند که می‌تواند متریک‌ها و ظاهر متن را تغییر دهد. برای جلوگیری از این موضوع، [فونت‌های مورد نیاز را فراهم کنید](/slides/fa/cpp/custom-font/) یا یک [fallback font](/slides/fa/cpp/fallback-font/) پیش‌فرض تنظیم کنید تا قلم‌های مورد نظر استفاده شوند.