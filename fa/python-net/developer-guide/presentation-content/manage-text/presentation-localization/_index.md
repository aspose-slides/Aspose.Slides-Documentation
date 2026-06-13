---
title: اتوماسیون بومی‌سازی ارائه با پایتون
linktitle: بومی‌سازی ارائه
type: docs
weight: 100
url: /fa/python-net/presentation-localization/
keywords:
- تغییر زبان
- بررسی املائی
- شناسه زبان
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "اتوماسیون بومی‌سازی اسلایدهای PowerPoint و OpenDocument در پایتون با Aspose.Slides، با استفاده از نمونه‌های کد عملی و نکات برای انتشار سریع‌تر جهانی."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با استفاده از Aspose.Slides مقدار `language_id` را برای متن در یک ارائه تنظیم کنید. نحوه باز کردن یک ارائه، اضافه کردن یک شکل با متن، اختصاص شناسه زبان به یک بخش متن، و ذخیره نتیجه به صورت فایل PPTX را نشان می‌دهد.

## **تغییر زبان برای ارائه و متن شکل**
- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
- مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.
- یک AutoShape از نوع Rectangle به اسلاید اضافه کنید.
- متنی به TextFrame اضافه کنید.
- تنظیم Language Id برای متن.
- ارائه را به صورت فایل PPTX ذخیره کنید.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```

## **پرسش‌های متداول**

**آیا Language ID ترجمه خودکار متن را فعال می‌کند؟**

خیر. [language_id](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/language_id/) در Aspose.Slides زبان برای بررسی املایی و گرامری را ذخیره می‌کند، اما متن را ترجمه یا تغییر نمی‌دهد. این یک متادیتا است که PowerPoint برای اثبات (proofing) می‌فهمد.

**آیا Language ID بر تشکیل (hyphenation) و شکست خطوط در هنگام رندر تأثیر می‌گذارد؟**

در Aspose.Slides، [language_id](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/language_id/) برای اثبات استفاده می‌شود. کیفیت تشکیل و بسته‌بندی خطوط عمدتاً به در دسترس بودن [فونت‌های مناسب](/slides/fa/python-net/powerpoint-fonts/) و تنظیمات layout/line-break برای سیستم نوشتاری بستگی دارد. برای اطمینان از رندر صحیح، فونت‌های مورد نیاز را در دسترس قرار دهید، قوانین [جایگزینی فونت](/slides/fa/python-net/font-substitution/) را پیکربندی کنید، و/یا [فونت‌ها را جاسازی](/slides/fa/python-net/embedded-font/) کنید.

**آیا می‌توانم زبان‌های مختلف را در یک پاراگراف تنظیم کنم؟**

بله. [language_id](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/language_id/) در سطح بخش متن (portion) اعمال می‌شود، بنابراین یک پاراگراف می‌تواند چندین زبان مختلف با تنظیمات اثبات متفاوت داشته باشد.