---
title: تبدیل ارائه‌های PowerPoint به SWF Flash در Python از طریق Java
linktitle: PowerPoint به SWF
type: docs
weight: 80
url: /fa/python-java/convert-powerpoint-to-swf-flash/
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
- صادر کردن PPT به SWF
- صادر کردن PPTX به SWF
- پایتون
- جاوا
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint به SWF Flash در Python از طریق Java با Aspose.Slides. نمایشگر، یادداشت‌ها، اسلایدهای پنهان، فشرده‌سازی و فونت‌ها را پیکربندی کنید."
---
## **بررسی کلی**

Aspose.Slides for Python via Java به شما امکان می‌دهد ارائه‌های PowerPoint را بدون نیاز به Microsoft PowerPoint به SWF تبدیل کنید. از [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) برای صادر کردن ارائه و [SwfOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/swfoptions/) برای تنظیمات نمایشگر، کیفیت تصویر و چیدمان یادداشت‌ها یا نظرات استفاده کنید.

## **تبدیل ارائه‌ها به فلش**

فایل منبع را با [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بارگذاری کنید، [SwfOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/swfoptions/) را پیکربندی کنید و با استفاده از [SaveFormat.Swf](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/#Swf) ذخیره نمایید.

مثال زیر `presentation.pptx` را به `presentation.swf` صادر می‌کند. این مثال نمایشگر توکار را با [setViewerIncluded](https://reference.aspose.com/slides/fa/python-java/aspose.slides/swfoptions/#setViewerIncluded) غیرفعال می‌کند و یادداشت‌های ارائه‌کننده را زیر اسلایدها با استفاده از [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notescommentslayoutingoptions/) اضافه می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, SwfOptions

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    swf_options = SwfOptions()
    swf_options.setViewerIncluded(False)
    swf_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation.swf", SaveFormat.Swf, swf_options)
finally:
    presentation.dispose()
```

قبل از اجرای مثال، [install Aspose.Slides for Python via Java](/slides/fa/python-java/installation/) را انجام دهید و فایل `presentation.pptx` را در پوشه کاری قرار دهید. JVM یک‌بار برای هر فرآیند Python راه‌اندازی می‌شود.

این مثال از [NotesPositions.BottomFull](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notespositions/#BottomFull) از طریق [setNotesPosition](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) استفاده می‌کند و چیدمان را به [SwfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/swfoptions/#setSlidesLayoutOptions) می‌فرستد. برای افزودن نظرات نیز قبل از خروجی گرفتن، [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) را پیکربندی کنید.

## **پرسش‌های متداول**

**آیا می‌توانم اسلایدهای مخفی را در SWF گنجانده کنم؟**

بله. با فراخوانی [SwfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/swfoptions/#setShowHiddenSlides) مقدار `True` را تنظیم کنید. به‌ طور پیش‌فرض، اسلایدهای مخفی صادر نمی‌شوند.

**چگونه می‌توانم فشرده‌سازی و اندازه نهایی SWF را کنترل کنم؟**

از [SwfOptions.setCompressed](https://reference.aspose.com/slides/fa/python-java/aspose.slides/swfoptions/#setCompressed) برای فعال یا غیرفعال کردن فشرده‌سازی و از [SwfOptions.setJpegQuality](https://reference.aspose.com/slides/fa/python-java/aspose.slides/swfoptions/#setJpegQuality) برای تنظیم کیفیت تصویر JPEG استفاده کنید. کاهش کیفیت JPEG می‌تواند اندازه فایل را کاهش دهد، اما به هزینهٔ وفاداری تصویر.

**نمایشگر توکار چه کاربردی دارد و چه زمانی باید آن را غیرفعال کنم؟**

[SwfOptions.setViewerIncluded](https://reference.aspose.com/slides/fa/python-java/aspose.slides/swfoptions/#setViewerIncluded) تعیین می‌کند که آیا SWF تولید شده شامل نمایشگر باشد یا نه. هنگام نیاز به اسلایدهای صادر شده بدون نمایشگر توکار، همان‌طور که در مثال فوق آمده است، مقدار `False` را پاس دهید.

**اگر یک فونت منبع در ماشین مقصد موجود نباشد چه می‌شود؟**

می‌توانید یک فونت پیش‌فرض عادی را با [setDefaultRegularFont](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) که توسط [SwfOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/swfoptions/) به ارث برده می‌شود، مشخص کنید. فونتی که در فرآیند خروجی در دسترس است انتخاب کنید؛ جایگزینی فونت می‌تواند ظاهر متن و چیدمان را تغییر دهد.