---
title: تبدیل PPTX به PPT در جاوا
linktitle: PPTX به PPT
type: docs
weight: 21
url: /fa/java/convert-pptx-to-ppt/
keywords:
- تبدیل PowerPoint
- تبدیل پرزنتیشن
- تبدیل اسلاید
- تبدیل PPTX
- PPTX به PPT
- ذخیره PPTX به صورت PPT
- صادرات PPTX به PPT
- PowerPoint
- پرزنتیشن
- Java
- Aspose.Slides
description: "به راحتی PPTX را با Aspose.Slides برای جاوا به PPT تبدیل کنید—سازگاری یکپارچه با فرمت‌های PowerPoint را تضمین کنید و چیدمان و کیفیت پرزنتیشن خود را حفظ نمایید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه پرزنتیشن PowerPoint در فرمت PPTX را به فرمت PPT با استفاده از جاوا تبدیل کنیم. موضوعات زیر پوشش داده می‌شوند.

- تبدیل PPTX به PPT در جاوا

## **تبدیل PPTX به PPT در جاوا**

برای کد نمونه جاوا جهت تبدیل PPTX به PPT، لطفاً بخش زیر را ببینید یعنی [Convert PPTX to PPT](#convert-pptx-to-ppt). این کد فقط فایل PPTX را بارگذاری و در فرمت PPT ذخیره می‌کند. با تعیین فرمت‌های ذخیره‌سازی مختلف، می‌توانید فایل PPTX را به بسیاری از فرمت‌های دیگر مانند PDF، XPS، ODP، HTML و غیره نیز ذخیره کنید همان‌طور که در این مقالات بحث شده است.

- [تبدیل PPTX به PDF در جاوا](/slides/fa/java/convert-powerpoint-to-pdf/)
- [تبدیل PPTX به XPS در جاوا](/slides/fa/java/convert-powerpoint-to-xps/)
- [تبدیل PPTX به HTML در جاوا](/slides/fa/java/convert-powerpoint-to-html/)
- [تبدیل PPTX به ODP در جاوا](/slides/fa/java/save-presentation/)
- [تبدیل PPTX به PNG در جاوا](/slides/fa/java/convert-powerpoint-to-png/)

## **تبدیل PPTX به PPT**
برای تبدیل یک PPTX به PPT کافی است نام فایل و فرمت ذخیره‌سازی را به متد **Save** از کلاس [**Presentation**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) پاس بدهید. نمونه کد جاوا زیر یک پرزنتیشن را از PPTX به PPT با گزینه‌های پیش‌فرض تبدیل می‌کند.

```java
// یک شیء Presentation ایجاد کنید که نمایانگر یک فایل PPTX است
Presentation presentation = new Presentation("template.pptx");

// پرزنتیشن را به صورت PPT ذخیره کنید
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **سوالات متداول**

**آیا تمام افکت‌ها و ویژگی‌های PPTX هنگام ذخیره به فرمت PPT (97–2003) حفظ می‌شوند؟**

همیشه نیست. فرمت PPT برخی قابلیت‌های جدیدتر (مانند افکت‌های خاص، اشیاء و رفتارها) را پشتیبانی نمی‌کند، بنابراین ممکن است ویژگی‌ها در حین تبدیل ساده‌سازی یا Rasterize شوند.

**آیا می‌توان فقط اسلایدهای انتخاب‌شده را به PPT تبدیل کرد به جای کل پرزنتیشن؟**

ذخیره‌سازی مستقیم کل پرزنتیشن را هدف می‌گیرد. برای تبدیل اسلایدهای خاص، پرزنتیشن جدیدی با فقط آن اسلایدها ایجاد کنید و به عنوان PPT ذخیره کنید؛ یا از سرویسی/API که پارامترهای تبدیل به‌صورت اسلایدی را پشتیبانی می‌کند استفاده کنید.

**آیا پرزنتیشن‌های محافظت‌شده با رمز عبور پشتیبانی می‌شوند؟**

بله. می‌توانید تشخیص دهید که آیا فایل محافظت‌شده است، آن را با رمز عبور باز کنید و همچنین [پیکربندی تنظیمات محافظت/رمزنگاری](/slides/fa/java/password-protected-presentation/) را برای PPT ذخیره‌شده تنظیم کنید.