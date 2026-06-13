---
title: تبدیل ارائه‌های PowerPoint به SWF Flash در C++
linktitle: PowerPoint به SWF
type: docs
weight: 80
url: /fa/cpp/convert-powerpoint-to-swf-flash/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به SWF
- ارائه به SWF
- اسلاید به SWF
- PPT به SWF
- PPTX به SWF
- PowerPoint به Flash
- ارائه به Flash
- اسلاید به Flash
- PPT به Flash
- PPTX به Flash
- ذخیره PPT به عنوان SWF
- ذخیره PPTX به عنوان SWF
- صادرات PPT به SWF
- صادرات PPTX به SWF
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "تبدیل PowerPoint (PPT/PPTX) به SWF Flash در C++ با Aspose.Slides. نمونه‌های کد گام به گام، خروجی با کیفیت سریع، بدون اتوماسیون PowerPoint."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides به فرمت SWF تبدیل کنید. این مقاله نحوه ذخیره یک ارائه به عنوان فایل SWF با متد [Presentation::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) و نحوه پیکربندی صادرات با [SwfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/swfoptions/) را نشان می‌دهد، از جمله تنظیمات نمایشگر و چیدمان یادداشت‌ها یا نظرات.

## **تبدیل ارائه‌ها به فلش**

متد [Save](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ارائه می‌شود می‌تواند برای تبدیل کل ارائه به سند SWF استفاده شود. همچنین می‌توانید نظرات را در SWF تولید شده با استفاده از کلاس [SWFOptions](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.export.swf_options) و کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/notescommentslayoutingoptions/) گنجانید. مثال زیر نشان می‌دهد چگونه یک ارائه را با استفاده از گزینه‌های ارائه‌شده توسط کلاس SWFOptions به سند SWF تبدیل کنید.

``` cpp
// مسیر به پوشه اسناد.
    System::String dataDir = GetDataPath();

    // یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // ذخیره ارائه و صفحات یادداشت‌ها
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```

## **سوالات متداول**

**آیا می‌توانم اسلایدهای مخفی را در SWF گنجانده کنم؟**

بله. از متد [set_ShowHiddenSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) در کلاس [SwfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/swfoptions/) استفاده کنید. به‌طور پیش‌فرض، اسلایدهای مخفی صادر نمی‌شوند.

**چگونه می‌توانم فشرده‌سازی و اندازه نهایی SWF را کنترل کنم؟**

از متد [set_Compressed](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/swfoptions/set_compressed/) استفاده کنید و [JPEG quality](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/swfoptions/set_jpegquality/) را تنظیم کنید تا تعادل بین حجم فایل و وضوح تصویر برقرار شود.

**متد 'set_ViewerIncluded' برای چه منظوری است و چه زمانی باید از آن استفاده کرد؟**

[set_ViewerIncluded](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) یک رابط کاربری پخش‌کننده توکار (کنترل‌های ناوبری، پنل‌ها، جستجو) اضافه می‌کند. اگر قصد استفاده از پخش‌کننده خودتان را دارید یا به یک چارچوب SWF خالی بدون رابط کاربری نیاز دارید، این گزینه را غیرفعال کنید.

**اگر یک قلم منبع در ماشین صادرکننده موجود نباشد چه اتفاقی می‌افتد؟**

Aspose.Slides قلم را که با متد [set_DefaultRegularFont](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) در [SwfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/swfoptions/) مشخص کرده‌اید جایگزین می‌کند تا از جایگزینی ناخواسته جلوگیری شود.