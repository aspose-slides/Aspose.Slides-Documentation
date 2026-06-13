---
title: تبدیل PPTX به PPT در JavaScript
linktitle: PPTX به PPT
type: docs
weight: 21
url: /fa/nodejs-java/convert-pptx-to-ppt/
keywords:
- تبدیل پاورپوینت
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPTX
- PPTX به PPT
- ذخیره PPTX به عنوان PPT
- صادر کردن PPTX به PPT
- پاورپوینت
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "به راحتی PPTX را با Aspose.Slides به PPT تبدیل کنید - سازگاری بی‌نقص با فرمت‌های PowerPoint را تضمین کنید و در عین حال چینش و کیفیت ارائه خود را حفظ کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه ارائه پاورپوینت با فرمت PPTX را با استفاده از JavaScript به فرمت PPT تبدیل کنید. موضوع زیر پوشش داده شده است.

- تبدیل PPTX به PPT در JavaScript

## **جاوا تبدیل PPTX به PPT**

برای نمونه کد JavaScript جهت تبدیل PPTX به PPT، لطفاً به بخش زیر مراجعه کنید یعنی [Convert PPTX to PPT](#convert-pptx-to-ppt). این کد فقط فایل PPTX را بارگذاری کرده و در قالب PPT ذخیره می‌کند. با تعیین فرمت‌های ذخیره‌سازی مختلف، می‌توانید فایل PPTX را به فرمت‌های دیگر مانند PDF، XPS، ODP، HTML و غیره نیز ذخیره کنید همان‌طور که در این مقالات بحث شده است.

- [تبدیل PPTX به PDF در JavaScript](/slides/fa/nodejs-java/convert-powerpoint-to-pdf/)
- [تبدیل PPTX به XPS در JavaScript](/slides/fa/nodejs-java/convert-powerpoint-to-xps/)
- [تبدیل PPTX به HTML در JavaScript](/slides/fa/nodejs-java/convert-powerpoint-to-html/)
- [تبدیل PPTX به ODP در JavaScript](/slides/fa/nodejs-java/save-presentation/)
- [تبدیل PPTX به PNG در JavaScript](/slides/fa/nodejs-java/convert-powerpoint-to-png/)

## **تبدیل PPTX به PPT**

برای تبدیل یک PPTX به PPT، کافی است نام فایل و فرمت ذخیره را به متد **Save** کلاس [**Presentation**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) پاس دهید. نمونه کد JavaScript زیر یک Presentation را از PPTX به PPT با استفاده از گزینه‌های پیش‌فرض تبدیل می‌کند.

```javascript
// یک شی Presentation که نمایانگر یک فایل PPTX است را ایجاد کنید
var presentation = new aspose.slides.Presentation("template.pptx");
// ارائه را به صورت PPT ذخیره کنید
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```

## **سؤال‌های متداول**

**آیا تمام افکت‌ها و ویژگی‌های PPTX هنگام ذخیره‌سازی به فرمت قدیمی PPT (97–2003) حفظ می‌شوند؟**

همیشه نیست. فرمت PPT برخی قابلیت‌های جدید را پشتیبانی نمی‌کند (مثلاً برخی افکت‌ها، اشیاء و رفتارها)، بنابراین ویژگی‌ها ممکن است در هنگام تبدیل ساده‌سازی یا به تصویر رستر شوند.

**آیا می‌توانم فقط اسلایدهای انتخابی را به PPT تبدیل کنم به‌جای کل ارائه؟**

ذخیره مستقیم کل ارائه را هدف می‌گیرد. برای تبدیل اسلایدهای خاص، یک ارائه جدید فقط با آن اسلایدها ایجاد کنید و به صورت PPT ذخیره کنید؛ یا از سرویس/APIی استفاده کنید که پارامترهای تبدیل بر اساس اسلاید را پشتیبانی می‌کند.

**آیا ارائه‌های محافظت‌شده با رمز عبور پشتیبانی می‌شوند؟**

بله. می‌توانید تشخیص دهید که آیا فایل محافظت‌شده است، آن را با رمز عبور باز کنید، و همچنین [پیکربندی تنظیمات حفاظت/رمزنگاری](/slides/fa/nodejs-java/password-protected-presentation/) برای PPT ذخیره‌شده تنظیم کنید.