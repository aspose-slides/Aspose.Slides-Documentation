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
- ذخیره PPT به صورت TIFF
- ذخیره PPTX به صورت TIFF
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
description: "تبدیل ارائه‌های PowerPoint به TIFF با یادداشت‌ها با استفاده از Aspose.Slides برای Java. یاد بگیرید چگونه اسلایدها را با یادداشت‌های گوینده به‌صورت کارآمد صادر کنید."
---
## **معرفی**

Aspose.Slides for Java یک راه‌حل ساده برای تبدیل ارائه‌های PowerPoint و OpenDocument (PPT، PPTX و ODP) همراه با یادداشت‌ها به فرمت TIFF فراهم می‌کند. این فرمت به‌طور گسترده‌ای برای ذخیره‌سازی تصویر با کیفیت بالا، چاپ و بایگانی اسناد استفاده می‌شود. با Aspose.Slides می‌توانید نه تنها کل ارائه‌ها را به همراه یادداشت‌های گوینده صادر کنید، بلکه تصاویر کوچک اسلایدها را در نمای Notes Slide نیز تولید کنید. فرآیند تبدیل ساده و کارآمد است و از متد `save` کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) برای تبدیل کل ارائه به مجموعه‌ای از تصاویر TIFF در حالی که یادداشت‌ها و چیدمان حفظ می‌شوند، استفاده می‌کند.

## **تبدیل یک ارائه به TIFF همراه با یادداشت‌ها**

ذخیره یک ارائه PowerPoint یا OpenDocument به TIFF با یادداشت‌ها با Aspose.Slides for Java شامل مراحل زیر است:

1. نمونه‌سازی کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/): یک فایل PowerPoint یا OpenDocument را بارگذاری کنید.  
1. پیکربندی گزینه‌های چیدمان خروجی: از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/notescommentslayoutingoptions/) برای تعیین نحوه نمایش یادداشت‌ها و نظرات استفاده کنید.  
1. ذخیره ارائه به TIFF: گزینه‌های پیکربندی شده را به متد [save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) پاس دهید.

بیایید فرض کنیم فایلی به نام "speaker_notes.pptx" با اسلاید زیر داریم:

![اسلاید ارائه با یادداشت‌های گوینده](slide_with_notes.png)

قطعه کد زیر نشان می‌دهد چگونه ارائه را به تصویر TIFF در نمای Notes Slide تبدیل کنیم با استفاده از متد [setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-).

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // نمایش یادداشت‌ها در زیر اسلاید.

    // پیکربندی گزینه‌های TIFF با چینش یادداشت‌ها.
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

{{% alert title="نکته" color="info" %}}
به Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online) مراجعه کنید.
{{% /alert %}}

## **سؤالات متداول**

### آیا می‌توانم موقعیت ناحیه یادداشت‌ها در TIFF حاصل را کنترل کنم؟

بله. از [تنظیمات چیدمان یادداشت‌ها](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) استفاده کنید تا بین گزینه‌هایی مانند `None`، `BottomTruncated` یا `BottomFull` انتخاب کنید؛ که به ترتیب یادداشت‌ها را مخفی می‌کند، در یک صفحه جای می‌دهد یا اجازه می‌دهد به صفحات اضافی جریان یابد.

### چگونه می‌توانم اندازه فایل TIFF با یادداشت‌ها را بدون از دست دادن قابل مشاهده کیفیت کاهش دهم؟

یک [فشرده‌سازی کارآمد](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) (مانند `LZW` یا `RLE`) را انتخاب کنید، DPI معقولی تنظیم کنید و در صورت امکان، از یک [قالب پیکسل](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) کمتر (مثلاً 8 bpp یا 1 bpp برای تک‌رنگ) استفاده کنید. کمی کاهش [ابعاد تصویر](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) نیز می‌تواند بدون کاهش محسوس خوانایی کمک کند.

### آیا قلم (فونت) در یادداشت‌ها بر نتیجه تأثیر می‌گذارد اگر قلم‌های اصلی در سیستم موجود نباشند؟

بله. قلم‌های گم‌شده باعث [جایگزینی](/slides/fa/java/font-selection-sequence/) می‌شوند که می‌تواند متریک‌های متن و ظاهر را تغییر دهد. برای جلوگیری از این موضوع، [قلم‌های مورد نیاز را فراهم کنید](/slides/fa/java/custom-font/) یا یک [قلم پیش‌فرض جایگزین](/slides/fa/java/fallback-font/) تنظیم کنید تا قلم‌های موردنظر استفاده شوند.