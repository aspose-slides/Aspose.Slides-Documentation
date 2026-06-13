---
title: تبدیل ارائه‌های PowerPoint به TIFF با یادداشت‌ها در Java
linktitle: PowerPoint به TIFF با یادداشت‌ها
type: docs
weight: 100
url: /fa/java/convert-powerpoint-to-tiff-with-notes/
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
  - صادرات PPT به TIFF
  - صادرات PPTX به TIFF
  - PowerPoint با یادداشت‌ها
  - ارائه با یادداشت‌ها
  - اسلاید با یادداشت‌ها
  - PPT با یادداشت‌ها
  - PPTX با یادداشت‌ها
  - TIFF با یادداشت‌ها
  - جاوا
  - Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint به TIFF با یادداشت‌ها با استفاده از Aspose.Slides for Java. یاد بگیرید چگونه اسلایدها را با یادداشت‌های سخنران به‌طور کارآمد صادر کنید."
---
## **معرفی**

Aspose.Slides for Java یک راه‌حل ساده برای تبدیل ارائه‌های PowerPoint و OpenDocument (PPT, PPTX و ODP) همراه با یادداشت‌ها به فرمت TIFF فراهم می‌کند. این فرمت به‌طور گسترده‌ای برای ذخیره‌سازی با کیفیت بالا، چاپ و بایگانی اسناد استفاده می‌شود. با Aspose.Slides نه تنها می‌توانید کل ارائه‌ها را همراه با یادداشت‌های سخنران صادر کنید بلکه می‌توانید تصویرهای کوچک اسلاید را در نمای Notes Slide نیز تولید کنید. فرآیند تبدیل ساده و کارآمد است و از متد `save` کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) برای تبدیل کل ارائه به مجموعه‌ای از تصاویر TIFF استفاده می‌کند، در حالی که یادداشت‌ها و چیدمان حفظ می‌شوند.

## **تبدیل یک ارائه به TIFF با یادداشت‌ها**

Saving a PowerPoint or OpenDocument presentation to TIFF with notes using Aspose.Slides for Java involves the following steps:

1. یک شی از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) را ایجاد کنید: یک فایل PowerPoint یا OpenDocument را بارگذاری کنید.
1. گزینه‌های چیدمان خروجی را پیکربندی کنید: از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/notescommentslayoutingoptions/) برای تعیین نحوه نمایش یادداشت‌ها و نظرات استفاده کنید.
1. ارائه را به TIFF ذخیره کنید: گزینه‌های پیکربندی شده را به متد [save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) ارسال کنید.

Let's say we have a "speaker_notes.pptx" file with the following slide:

![اسلاید ارائه با یادداشت‌های سخنران](slide_with_notes.png)

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // نمایش یادداشت‌ها در زیر اسلاید.

    // پیکربندی گزینه‌های TIFF با چیدمان یادداشت‌ها.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // ذخیره ارائه به TIFF با یادداشت‌های سخنران.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

نتیجه:

![تصویر TIFF با یادداشت‌های سخنران](TIFF_with_notes.png)

{{% alert title="نکته" color="primary" %}}
به Aspose [مبدل رایگان PowerPoint به پوستر](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online) نگاهی بیندازید.
{{% /alert %}}

## **سؤالات متداول**

**آیا می‌توانم موقعیت ناحیه یادداشت‌ها را در TIFF تولید شده کنترل کنم؟**

بله. از [تنظیمات چیدمان یادداشت‌ها](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) استفاده کنید تا بین گزینه‌هایی مانند `None`، `BottomTruncated` یا `BottomFull` انتخاب کنید که به ترتیب یادداشت‌ها را مخفی می‌کند، آن‌ها را در یک صفحه جا می‌دهد یا اجازه می‌دهد به صفحات اضافی ادامه یابند.

**چگونه می‌توانم اندازه یک فایل TIFF با یادداشت‌ها را بدون کاهش محسوس کیفیت کاهش دهم؟**

یک [فشرده‌سازی کارآمد](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) (مثلاً `LZW` یا `RLE`) را انتخاب کنید، DPI معقولی تنظیم کنید و در صورت قابل قبول، از یک [فرمت پیکسل](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) پایین‌تر (مانند 8 bpp یا 1 bpp برای مونوفرم) استفاده کنید. کمی کاهش [ابعاد تصویر](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) نیز می‌تواند کمک کند بدون اینکه خوانایی به‌‌طور قابل ملاحظه‌ای آسیب ببیند.

**آیا قلم (فونت) در یادداشت‌ها بر نتیجه تأثیر می‌گذارد اگر فونت‌های اصلی در سیستم موجود نباشند؟**

بله. نبودن فونت‌ها باعث [جایگزینی](/slides/fa/java/font-selection-sequence/) می‌شود که می‌تواند معیارهای متن و ظاهر را تغییر دهد. برای جلوگیری از این موضوع، [فونت‌های مورد نیاز را فراهم کنید](/slides/fa/java/custom-font/) یا یک [فونت پیش‌فرض بازگشتی](/slides/fa/java/fallback-font/) تنظیم کنید تا قلم‌های مورد نظر استفاده شوند.