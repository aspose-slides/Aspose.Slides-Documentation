---
title: تبدیل ارائه‌های PowerPoint به SWF Flash در Python
linktitle: PowerPoint به SWF Flash
type: docs
weight: 80
url: /fa/python-net/convert-powerpoint-to-swf-flash/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- PowerPoint به SWF
- ارائه به SWF
- اسلاید به SWF
- PPT به SWF
- PPTX به SWF
- PowerPoint
- ارائه
- پایتون
- Aspose.Slides
description: "تبدیل PowerPoint (PPT/PPTX) به SWF Flash در Python با Aspose.Slides. نمونه‌های کد گام‌به‌گام، خروجی سریع با کیفیت، بدون اتوماسیون PowerPoint."
---
## **مروری کلی**

این مقاله توضیح می‌دهد چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides به فرمت SWF تبدیل کنیم. نشان می‌دهد چگونه یک ارائه را با متد [Presentation.save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/save/) به فایل SWF ذخیره کنیم و چگونه خروجی را با [SwfOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/swfoptions/)، شامل تنظیمات نمایشگر و چینش یادداشت‌ها یا نظرات، پیکربندی کنیم.

## **تبدیل ارائه‌ها به Flash**

متد [save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/save/) که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ارائه می‌شود می‌تواند برای تبدیل کل ارائه به سند SWF استفاده شود. همچنین می‌توانید نظرات را در SWF تولید شده با استفاده از کلاس [SWFOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/swfoptions/) و کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/notescommentslayoutingoptions/) گنجانده کنید. مثال زیر نشان می‌دهد چگونه یک ارائه را با استفاده از گزینه‌های ارائه شده توسط کلاس SWFOptions به سند SWF تبدیل کنیم.

```py
import aspose.slides as slides

# یک شیء Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# در حال ذخیره ارائه و صفحات یادداشت‌ها
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```

## **پرسش‌های متداول**

**آیا می‌توانم اسلایدهای مخفی را در SWF گنجانده کنم؟**

بله. گزینه [show_hidden_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/swfoptions/show_hidden_slides/) را در [SwfOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/swfoptions/) فعال کنید. به طور پیش‌فرض، اسلایدهای مخفی صادر نمی‌شوند.

**چگونه می‌توانم فشرده‌سازی و اندازه نهایی SWF را کنترل کنم؟**

از پرچم [compressed](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/swfoptions/compressed/) (به‌صورت پیش‌فرض فعال) استفاده کنید و [jpeg_quality](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/swfoptions/jpeg_quality/) را تنظیم کنید تا بین حجم فایل و کیفیت تصویر تعادل برقرار شود.

**'viewer_included' برای چه منظوری است و کی باید آن را غیرفعال کنم؟**

[viewer_included](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/swfoptions/viewer_included/) یک رابط کاربری پخش‌کننده توکار (کنترل‌های ناوبری، پنل‌ها، جستجو) اضافه می‌کند. اگر قصد دارید از پخش‌کننده خود استفاده کنید یا به یک قاب SWF خالی بدون UI نیاز دارید، آن را غیرفعال کنید.

**اگر یک قلم منبع در دستگاه خروجی موجود نباشد چه اتفاقی می‌افتد؟**

Aspose.Slides فونتی که توسط [default_regular_font](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/swfoptions/default_regular_font/) در [SwfOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/swfoptions/) مشخص می‌کنید جایگزین خواهد کرد تا از fallback ناخواسته جلوگیری شود.