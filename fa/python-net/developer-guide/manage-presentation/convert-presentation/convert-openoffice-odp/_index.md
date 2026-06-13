---
title: تبدیل ارائه‌های OpenDocument در پایتون
linktitle: تبدیل OpenDocument
type: docs
weight: 10
url: /fa/python-net/convert-openoffice-odp/
keywords:
- تبدیل OpenDocument
- تبدیل ODP
- ODP به PDF
- ODP به PPT
- ODP به PPTX
- ODP به XPS
- ODP به HTML
- ODP به TIFF
- ODP به SWF
- OpenDocument
- ارائه
- پایتون
- Aspose.Slides
description: "تبدیل OpenDocument ODP به PDF، PPT، PPTX، XPS، HTML، TIFF یا SWF در پایتون با Aspose.Slides: مثال‌های کد، دقت بالا، تبدیل دسته‌ای و سفارشی‌سازی."
---
## **معرفی**

[**Aspose.Slides API**](https://products.aspose.com/slides/fa/python-net/) به شما امکان تبدیل ارائه‌های OpenDocument (ODP) به بسیاری از فرمت‌ها (HTML، PDF، TIFF، SWF، XPS و غیره) را می‌دهد. API مورد استفاده برای تبدیل فایل‌های ODP به سایر فرمت‌های سند، همان API است که برای عملیات تبدیل PowerPoint (PPT و PPTX) به کار می‌رود.

به عنوان مثال، اگر نیاز به تبدیل یک ارائه ODP به PDF داشته باشید، می‌توانید به صورت زیر عمل کنید:

```py
import aspose.slides as slides

with slides.Presentation("pres.odp") as presentation:
    presentation.save("pres.pdf", slides.export.SaveFormat.PDF)
```

## **پرسش‌های متداول**

**آیا می‌توانم ODP را به PPTX تبدیل کنم بدون نصب LibreOffice یا OpenOffice؟**

بله. Aspose.Slides یک کتابخانه کاملاً مستقل است که هر دو فرمت PowerPoint و OpenOffice را بدون نیاز به هیچ برنامهٔ خارجی‌ای مدیریت می‌کند.

**آیا Aspose.Slides می‌تواند فایل‌های ODP/OTP محافظت‌شده با رمز عبور را باز و ذخیره کند؟**

بله. می‌تواند [ارائه‌های رمزنگاری‌شده](/slides/fa/python-net/password-protected-presentation/) را هنگام ارائهٔ رمز عبور بارگذاری کند و همچنین می‌تواند ارائه‌ها را با تنظیمات رمزگذاری و حفاظت ذخیره کند.

**آیا می‌توانم فایل‌های رسانه‌ای توکار (صدا/ویدئو) را از ODP قبل از تبدیل استخراج کنم؟**

بله. Aspose.Slides به شما امکان دسترسی و استخراج [صدا](/slides/fa/python-net/audio-frame/) و [ویدئو](/slides/fa/python-net/video-frame/) توکار را از ارائه‌ها می‌دهد، که برای پردازش پیش از تبدیل یا استفاده مجدد جداگانه مفید است.

**آیا می‌توانم ODP تبدیل‌شده را به‌صورت Strict Office Open XML ذخیره کنم؟**

بله. هنگام ذخیره به PPTX می‌توانید Strict OOXML را از طریق [گزینه‌های ذخیره](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/pptxoptions/) فعال کنید تا نیازهای سخت‌گیرانه‌تر سازگاری را برآورده کنید.