---
title: تبدیل ارائه‌های PowerPoint به TIFF با یادداشت‌ها در Android
linktitle: PowerPoint به TIFF با یادداشت‌ها
type: docs
weight: 100
url: /fa/androidjava/convert-powerpoint-to-tiff-with-notes/
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
- Android
- Java
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint به TIFF با یادداشت‌ها با استفاده از Aspose.Slides برای Android از طریق Java. یاد بگیرید چگونه اسلایدها را با یادداشت‌های گوینده به‌صورت کارآمد صادر کنید."
---
## **مقدمه**

Aspose.Slides for Android via Java راهکار ساده‌ای برای تبدیل ارائه‌های PowerPoint و OpenDocument (PPT، PPTX و ODP) همراه با یادداشت‌ها به فرمت TIFF فراهم می‌کند. این فرمت به‌طور گسترده‌ای برای ذخیره‌سازی تصویر با کیفیت بالا، چاپ و بایگانی اسناد استفاده می‌شود. با Aspose.Slides می‌توانید نه تنها کل ارائه‌ها را همراه با یادداشت‌های گوینده استخراج کنید، بلکه تصاویر بندانگشتی اسلایدها را در نمای Notes Slide نیز تولید کنید. فرآیند تبدیل ساده و کارآمد است و از متد `save` کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) استفاده می‌کند تا کل ارائه را به‌صورت مجموعه‌ای از تصاویر TIFF تبدیل کند در حالی که یادداشت‌ها و طرح‌بندی حفظ می‌شوند.

## **تبدیل یک ارائه به TIFF همراه با یادداشت‌ها**

ذخیره یک ارائه PowerPoint یا OpenDocument به TIFF همراه با یادداشت‌ها با استفاده از Aspose.Slides for Android via Java شامل مراحل زیر است:

1. نمونه‌سازی کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) : یک فایل PowerPoint یا OpenDocument را بارگذاری کنید.
2. تنظیم گزینه‌های چیدمان خروجی: از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/notescommentslayoutingoptions/) استفاده کنید تا مشخص کنید یادداشت‌ها و نظرات چگونه نمایش داده شوند.
3. ذخیره ارائه به TIFF: گزینه‌های پیکربندی شده را به متد [save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) پاس دهید.

فرض کنید فایلی به نام "speaker_notes.pptx" داریم که اسلاید زیر را شامل می‌شود:

![اسلاید ارائه با یادداشت‌های گوینده](slide_with_notes.png)

قطعه کد زیر نشان می‌دهد چگونه می‌توان ارائه را به تصویر TIFF در نمای Notes Slide تبدیل کرد با استفاده از متد [setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) :

```java
// یک شی از کلاس Presentation که نمایانگر فایل ارائه است را ایجاد کنید.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // نمایش یادداشت‌ها در زیر اسلاید.

    // پیکربندی گزینه‌های TIFF با چیدمان یادداشت‌ها.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // ذخیره ارائه به TIFF همراه با یادداشت‌های گوینده.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
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

**آیا می‌توانم موقعیت ناحیه یادداشت‌ها را در TIFF تولید شده کنترل کنم؟**

بله. از [تنظیمات چیدمان یادداشت‌ها](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) استفاده کنید تا بین گزینه‌هایی مانند `None`، `BottomTruncated` یا `BottomFull` یکی را انتخاب کنید؛ که به ترتیب یادداشت‌ها را مخفی می‌کنند، در یک صفحه جای می‌دهند یا اجازه می‌دهند به صفحات اضافی جریان پیدا کنند.

**چگونه می‌توان اندازه فایل TIFF با یادداشت‌ها را بدون کاهش محسوس کیفیت کاهش داد؟**

یک [فشرده‌سازی کارآمد](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) (مثلاً `LZW` یا `RLE`) انتخاب کنید، DPI معقولی تنظیم کنید و در صورت امکان از [فرمت پیکسل](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) پایین‌تر (مانند 8 bpp یا 1 bpp برای تک‌رنگ) استفاده کنید. کمی کاهش [ابعاد تصویر](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) نیز می‌تواند بدون اثر قابل توجه بر خوانایی کمک کند.

**آیا فونت موجود در یادداشت‌ها بر نتیجه تأثیر می‌گذارد اگر فونت‌های اصلی در سیستم موجود نباشند؟**

بله. نبود فونت‌ها منجر به [جایگزینی](/slides/fa/androidjava/font-selection-sequence/) می‌شود که می‌تواند متریک‌ها و ظاهر متن را تغییر دهد. برای جلوگیری از این موضوع، [فونت‌های مورد نیاز را فراهم کنید](/slides/fa/androidjava/custom-font/) یا یک [فونت پیش‌فرض جایگزین](/slides/fa/androidjava/fallback-font/) تنظیم کنید تا قلم‌های مورد نظر استفاده شوند.