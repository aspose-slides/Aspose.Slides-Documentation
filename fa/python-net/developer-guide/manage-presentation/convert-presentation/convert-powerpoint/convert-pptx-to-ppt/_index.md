---
title: تبدیل PPTX به PPT در پایتون
linktitle: PPTX به PPT
type: docs
weight: 21
url: /fa/python-net/convert-pptx-to-ppt/
keywords:
- PPTX به PPT
- تبدیل PPTX به PPT
- تبدیل پاورپوینت
- تبدیل ارائه
- پایتون
- Aspose.Slides
description: "به راحتی PPTX را به PPT با Aspose.Slides برای پایتون از طریق .NET تبدیل کنید—سازگاری بی‌نقص با فرمت‌های پاورپوینت را تضمین کنید در حالی که چیدمان و کیفیت ارائه‌تان حفظ می‌شود."
---
## **نمای کلی**

Aspose.Slides برای Python به شما امکان می‌دهد ارائه‌های PPTX مدرن را به فرمت قدیمی PPT کاملاً با کد تبدیل کنید. یک فایل PPTX را باز کنید و آن را به‌عنوان PPT صادر کنید در حالی که محتوا و چیدمان ارائه حفظ می‌شود و نتیجه با نسخه‌های قدیمی PowerPoint سازگار است. همان جریان کار می‌تواند خروجی‌های دیگری مانند PDF، XPS، ODP، HTML یا تصاویر تولید کند، بنابراین به‌راحتی در اسکریپت‌ها، خطوط لوله CI و پردازش‌های دسته‌ای جای می‌گیرد.

## **تبدیل PPTX به PPT**

برای تبدیل یک PPTX به PPT، به سادگی نام فایل و قالب ذخیره‌سازی را به متد [save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/save/) کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) پاس می‌دهید. مثال پایتون زیر یک ارائه را از PPTX به PPT با استفاده از گزینه‌های پیش‌فرض تبدیل می‌کند.

```py
import aspose.slides as slides

# کلاس Presentation را که نمایانگر یک فایل PPTX است، نمونه‌سازی کنید.
presentation = slides.Presentation("presentation.pptx")

# ارائه را به عنوان فایل PPT ذخیره کنید.
presentation.save("presentation.ppt", slides.export.SaveFormat.PPT)
```

## **سوالات متداول**

**آیا تمام افکت‌ها و ویژگی‌های PPTX هنگام ذخیره‌سازی به فرمت قدیمی PPT (97–2003) حفظ می‌شوند؟**

همیشه نیست. فرمت PPT برخی از قابلیت‌های جدیدتر (مانند افکت‌های خاص، اشیاء و رفتارها) را ندارند، بنابراین ویژگی‌ها ممکن است در حین تبدیل ساده یا به‌صورت rasterized شوند.

**آیا می‌توانم فقط اسلایدهای انتخابی را به PPT تبدیل کنم به‌جای کل ارائه؟**

ذخیره مستقیم کل ارائه را هدف می‌گیرد. برای تبدیل اسلایدهای خاص، یک ارائه جدید فقط با آن اسلایدها ایجاد کنید و آن را به‌عنوان PPT ذخیره کنید؛ یا از سرویس/APIی که پارامترهای تبدیل بر پایه اسلاید را پشتیبانی می‌کند استفاده کنید.

**آیا ارائه‌های محافظت‌شده با رمز عبور پشتیبانی می‌شوند؟**

بله. می‌توانید تشخیص دهید که آیا فایل محافظت شده است، آن را با رمز عبور باز کنید، و همچنین [پیکربندی تنظیمات حفاظت/رمزنگاری](/slides/fa/python-net/password-protected-presentation/) را برای PPT ذخیره شده تنظیم کنید.

**همچنین:**
- [تبدیل PPT و PPTX به PDF در پایتون | گزینه‌های پیشرفته](/slides/fa/python-net/convert-powerpoint-to-pdf/)
- [تبدیل ارائه‌های پاورپوینت به XPS در پایتون](/slides/fa/python-net/convert-powerpoint-to-xps/)
- [تبدیل ارائه‌های پاورپوینت به HTML در پایتون](/slides/fa/python-net/convert-powerpoint-to-html/)
- [تبدیل اسلایدهای پاورپوینت به PNG در پایتون](/slides/fa/python-net/convert-powerpoint-to-png/)