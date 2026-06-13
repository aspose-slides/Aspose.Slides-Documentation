---
title: تبدیل ارائه‌های PowerPoint به TIFF با یادداشت‌ها در JavaScript
linktitle: PowerPoint به TIFF با یادداشت‌ها
type: docs
weight: 100
url: /fa/nodejs-java/convert-powerpoint-to-tiff-with-notes/
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
- صادر کردن PPT به TIFF
- صادر کردن PPTX به TIFF
- PowerPoint با یادداشت‌ها
- ارائه با یادداشت‌ها
- اسلاید با یادداشت‌ها
- PPT با یادداشت‌ها
- PPTX با یادداشت‌ها
- TIFF با یادداشت‌ها
- Node.js
- JavaScript
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint به TIFF با یادداشت‌ها در JavaScript با استفاده از Aspose.Slides برای Node.js. یاد بگیرید چگونه اسلایدها را با یادداشت‌های گوینده به‌صورت کارآمد صادر کنید."
---
## **مقدمه**

Aspose.Slides for Node.js via Java یک راه‌حل ساده برای تبدیل ارائه‌های PowerPoint و OpenDocument (PPT، PPTX و ODP) همراه با یادداشت‌ها به فرمت TIFF فراهم می‌کند. این فرمت به‌طور گسترده برای ذخیره‌سازی تصویر با کیفیت بالا، چاپ و بایگانی اسناد استفاده می‌شود. با Aspose.Slides می‌توانید نه تنها کل ارائه‌ها را همراه با یادداشت‌های گوینده صادر کنید، بلکه تصاویر کوچک اسلایدها را در نمای اسلاید یادداشت‌ها نیز تولید کنید. فرایند تبدیل ساده و کارآمد است و از متد `save` کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) برای تبدیل کل ارائه به مجموعه‌ای از تصاویر TIFF در حالی که یادداشت‌ها و چیدمان حفظ می‌شود، استفاده می‌کند.

## **تبدیل یک ارائه به TIFF با یادداشت‌ها**

ذخیره یک ارائه PowerPoint یا OpenDocument به TIFF همراه با یادداشت‌ها با استفاده از Aspose.Slides for Node.js via Java شامل مراحل زیر است:

1. یک شی از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید: یک فایل PowerPoint یا OpenDocument را بارگذاری کنید.  
2. گزینه‌های چیدمان خروجی را پیکربندی کنید: از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/notescommentslayoutingoptions/) برای تعیین نحوه نمایش یادداشت‌ها و نظرات استفاده کنید.  
3. ارائه را به TIFF ذخیره کنید: گزینه‌های پیکربندی‌شده را به متد [save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#save) پاس دهید.

فرض کنید یک فایل «speaker_notes.pptx» داریم که شامل اسلاید زیر است:

![اسلاید ارائه با یادداشت‌های گوینده](slide_with_notes.png)

قطعه کد زیر نشان می‌دهد چگونه می‌توان ارائه را به یک تصویر TIFF در نمای اسلاید یادداشت‌ها تبدیل کرد با استفاده از متد [setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions).

```js
// یک شیء از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
let presentation = new aspose.slides.Presentation("speaker_notes.pptx");
try {
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull); // یادداشت‌ها را در زیر اسلاید نمایش می‌دهد.

    // گزینه‌های TIFF را با چیدمان یادداشت‌ها پیکربندی کنید.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // ارائه را به صورت TIFF همراه با یادداشت‌های گوینده ذخیره کنید.
    presentation.save("TIFF_with_notes.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

نتیجه:

![تصویر TIFF با یادداشت‌های گوینده](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
به Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online) نگاهی بیندازید.
{{% /alert %}}

## **سوالات متداول**

**آیا می‌توانم موقعیت ناحیه یادداشت‌ها را در TIFF حاصل کنترل کنم؟**

بله. از [settings چیدمان یادداشت‌ها](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) می‌توانید بین گزینه‌هایی مانند `None`، `BottomTruncated` یا `BottomFull` انتخاب کنید که به ترتیب یادداشت‌ها را مخفی می‌کند، در یک صفحه می‌گنجاند یا اجازه می‌دهد بر روی صفحات اضافه جریان یابد.

**چگونه می‌توانم اندازه فایل TIFF با یادداشت‌ها را بدون کاهش قابل مشاهده کیفیت کاهش دهم؟**

یک [فشرده‌سازی کارآمد](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/setcompressiontype/) (مثلاً `LZW` یا `RLE`) انتخاب کنید، DPI معقولی تنظیم کنید و در صورت امکان از یک [فرمت پیکسل](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/setpixelformat/) پایین‌تر (مانند 8 bpp یا 1 bpp برای تک‌رنگ) استفاده کنید. کمی کوچک کردن [ابعاد تصویر](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/setimagesize/) نیز می‌تواند بدون ایجاد چشم‌گیری در خوانایی کمک کند.

**آیا فونت در یادداشت‌ها بر نتیجه تأثیر می‌گذارد اگر فونت‌های اصلی در سیستم موجود نباشند؟**

بله. نبودن فونت‌ها باعث فعال شدن [جایگزینی](/slides/fa/nodejs-java/font-selection-sequence/) می‌شود که می‌تواند معیارهای متن و ظاهر آن را تغییر دهد. برای جلوگیری از این موضوع، [فونت‌های مورد نیاز را فراهم کنید](/slides/fa/nodejs-java/custom-font/) یا یک [فونت پیش‌فرض جایگزین](/slides/fa/nodejs-java/fallback-font/) تنظیم کنید تا قلم‌های مورد نظر استفاده شوند.