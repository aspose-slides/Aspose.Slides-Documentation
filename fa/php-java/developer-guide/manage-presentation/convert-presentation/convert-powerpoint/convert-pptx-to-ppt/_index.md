---
title: تبدیل PPTX به PPT در PHP
linktitle: PPTX به PPT
type: docs
weight: 21
url: /fa/php-java/convert-pptx-to-ppt/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPTX
- PPTX به PPT
- ذخیره PPTX به عنوان PPT
- صادر کردن PPTX به PPT
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "به راحتی PPTX را به PPT با Aspose.Slides تبدیل کنید — سازگاری یکپارچه با فرمت‌های PowerPoint را تضمین کنید و در عین حال چیدمان و کیفیت ارائهٔ خود را حفظ کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه ارائهٔ PowerPoint با فرمت PPTX را با استفاده از PHP به فرمت PPT تبدیل کنید. موضوعات زیر پوشش داده می‌شوند.

- تبدیل PPTX به PPT

## **تبدیل PPTX به PPT در PHP**

برای کد نمونهٔ Java که PPTX را به PPT تبدیل می‌کند، لطفاً به بخش زیر نگاه کنید: [تبدیل PPTX به PPT](#convert-pptx-to-ppt). این فقط فایل PPTX را بارگذاری کرده و در فرمت PPT ذخیره می‌کند. با مشخص کردن فرمت‌های ذخیره متفاوت، می‌توانید فایل PPTX را به فرمت‌های دیگر مانند PDF، XPS، ODP، HTML و غیره ذخیره کنید همان‌طور که در این مقالات توضیح داده شده است.

- [تبدیل PPTX به PDF در PHP](/slides/fa/php-java/convert-powerpoint-to-pdf/)
- [تبدیل PPTX به XPS در PHP](/slides/fa/php-java/convert-powerpoint-to-xps/)
- [تبدیل PPTX به HTML در PHP](/slides/fa/php-java/convert-powerpoint-to-html/)
- [تبدیل PPTX به ODP در PHP](/slides/fa/php-java/save-presentation/)
- [تبدیل PPTX به PNG در PHP](/slides/fa/php-java/convert-powerpoint-to-png/)

## **تبدیل PPTX به PPT**
برای تبدیل یک فایل PPTX به PPT کافی است نام فایل و فرمت ذخیره را به متد **Save** کلاس [**Presentation**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) پاس دهید. نمونه کد PHP زیر یک Presentation را از PPTX به PPT با گزینه‌های پیش‌فرض تبدیل می‌کند.

```php
  # یک شیء Presentation که نمایانگر یک فایل PPTX است را ایجاد کنید
  $presentation = new Presentation("template.pptx");
  # ارائه را به صورت PPT ذخیره کنید
  $presentation->save("output.ppt", SaveFormat::Ppt);
```

## **سوالات متداول**

**آیا تمام افکت‌ها و ویژگی‌های PPTX هنگام ذخیره به فرمت قدیمی PPT (97–2003) حفظ می‌شوند؟**

همیشه نیست. فرمت PPT برخی قابلیت‌های جدیدتر (مانند برخی افکت‌ها، اشیاء و رفتارها) را ندارد؛ بنابراین ویژگی‌ها ممکن است در فرآیند تبدیل ساده‌سازی یا به بیت‌مپ تبدیل شوند.

**آیا می‌توان تنها اسلایدهای انتخابی را به PPT تبدیل کرد به‌جای کل ارائه؟**

ذخیره مستقیم کل ارائه را هدف می‌گیرد. برای تبدیل اسلایدهای خاص، یک ارائهٔ جدید فقط با آن اسلایدها ایجاد کنید و به صورت PPT ذخیره کنید؛ یا از سرویس/API‌ای استفاده کنید که پارامترهای تبدیل به‌ازای اسلاید را پشتیبانی می‌کند.

**آیا ارائه‌های محافظت‌شده با رمز عبور پشتیبانی می‌شوند؟**

بله. می‌توانید تشخیص دهید که آیا فایل محافظت‌شده است، آن را با رمز عبور باز کنید و همچنین [تنظیمات حفاظت/رمزنگاری](/slides/fa/php-java/password-protected-presentation/) را برای PPT ذخیره‌شده پیکربندی کنید.