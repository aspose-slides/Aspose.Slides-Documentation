---
title: خودکارسازی بومی‌سازی ارائه در C++
linktitle: بومی‌سازی ارائه
type: docs
weight: 100
url: /fa/cpp/presentation-localization/
keywords:
- تغییر زبان
- بررسی املا
- شناسه زبان
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "بومی‌سازی اسلایدهای PowerPoint و OpenDocument را در C++ با Aspose.Slides به صورت خودکار انجام دهید، با استفاده از نمونه‌های کد عملی و نکات برای گسترش سریع جهانی."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه با استفاده از Aspose.Slides شناسه `LanguageId` را برای متن در یک ارائه تنظیم کنیم. نشان می‌دهد چگونه یک ارائه را باز کنیم، شکلی با متن اضافه کنیم، شناسه زبان را به یک بخش از متن اختصاص دهیم و نتیجه را به صورت فایل PPTX ذخیره کنیم.

## **تغییر زبان برای ارائه و متن شکل**
- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) را ایجاد کنید.
- با استفاده از Index اسلاید، مرجع آن را دریافت کنید.
- یک AutoShape از نوع Rectangle را به اسلاید اضافه کنید.
- متنی به TextFrame اضافه کنید.
- تنظیم Language Id برای متن.
- ارائه را به عنوان یک فایل PPTX ذخیره کنید.

پیاده‌سازی مراحل فوق در مثال زیر نشان داده شده است.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxOnSlideProgram-TextBoxOnSlideProgram.cpp" >}}

## **سوالات متداول**

**آیا Language ID ترجمه خودکار متن را فعال می‌کند؟**

خیر. [Language ID](https://reference.aspose.com/slides/fa/cpp/aspose.slides/baseportionformat/set_languageid/) در Aspose.Slides برای ذخیرهٔ زبان جهت بررسی املا و گرامر استفاده می‌شود، اما متن را ترجمه یا تغییر نمی‌دهد. این یک فراداده است که PowerPoint برای تصحیح می‌فهمد.

**آیا Language ID بر تقسیم‌بندی و شکست خطوط در حین رندر تأثیر می‌گذارد؟**

در Aspose.Slides، [Language ID](https://reference.aspose.com/slides/fa/cpp/aspose.slides/baseportionformat/set_languageid/) برای تصحیح استفاده می‌شود. کیفیت هیفن‌گذاری و پیچش خط عمدتاً به موجودیت [فونت‌های مناسب](/slides/fa/cpp/powerpoint-fonts/) و تنظیمات چیدمان/شکست خط برای سیستم نوشتاری وابسته است. برای اطمینان از رندر صحیح، فونت‌های مورد نیاز را در دسترس قرار دهید، [قواعد جایگزینی فونت](/slides/fa/cpp/font-substitution/) را پیکربندی کنید و/یا [فونت‌ها را جاسازی](/slides/fa/cpp/embedded-font/) کنید.

**آیا می‌توانم زبان‌های مختلفی را در یک پاراگراف واحد تنظیم کنم؟**

بله. [Language ID](https://reference.aspose.com/slides/fa/cpp/aspose.slides/baseportionformat/set_languageid/) در سطح بخش متن اعمال می‌شود، بنابراین یک پاراگراف می‌تواند چندین زبان با تنظیمات تصحیح متفاوت را ترکیب کند.