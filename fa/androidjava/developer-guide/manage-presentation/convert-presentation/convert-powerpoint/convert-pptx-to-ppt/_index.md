---
title: تبدیل PPTX به PPT در اندروید
linktitle: PPTX به PPT
type: docs
weight: 21
url: /fa/androidjava/convert-pptx-to-ppt/
keywords:
- تبدیل پاورپوینت
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPTX
- PPTX به PPT
- ذخیره PPTX به عنوان PPT
- خروجی PPTX به PPT
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "به راحتی PPTX را با Aspose.Slides برای اندروید از طریق Java به PPT تبدیل کنید—اطمینان از سازگاری بی‌دردسر با فرمت‌های PowerPoint در حالی که طرح و کیفیت ارائه شما حفظ می‌شود."
---
## **بررسی اجمالی**

این مقاله توضیح می‌دهد که چگونه ارائه PowerPoint با فرمت PPTX را با استفاده از Java به فرمت PPT تبدیل کنید. موضوع زیر پوشش داده شده است.

- تبدیل PPTX به PPT در Java

## **تبدیل PPTX به PPT در اندروید**

برای مشاهده نمونه کد Java برای تبدیل PPTX به PPT، لطفاً به بخش زیر به آدرس [Convert PPTX to PPT](#convert-pptx-to-ppt) مراجعه کنید. این کد فقط فایل PPTX را بارگذاری کرده و در قالب PPT ذخیره می‌کند. با تعیین فرمت‌های ذخیره‌سازی مختلف، می‌توانید فایل PPTX را به سایر فرمت‌ها مانند PDF، XPS، ODP، HTML و غیره نیز ذخیره کنید همان‌طور که در این مقالات بحث شده است.

- [تبدیل PPTX به PDF در اندروید](/slides/fa/androidjava/convert-powerpoint-to-pdf/)
- [تبدیل PPTX به XPS در اندروید](/slides/fa/androidjava/convert-powerpoint-to-xps/)
- [تبدیل PPTX به HTML در اندروید](/slides/fa/androidjava/convert-powerpoint-to-html/)
- [تبدیل PPTX به ODP در اندروید](/slides/fa/androidjava/save-presentation/)
- [تبدیل PPTX به PNG در اندروید](/slides/fa/androidjava/convert-powerpoint-to-png/)

## **تبدیل PPTX به PPT**
برای تبدیل PPTX به PPT به سادگی نام فایل و فرمت ذخیره‌سازی را به متد **Save** کلاس [**Presentation**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) بدهید. نمونه کد Java زیر یک Presentation را از PPTX به PPT با استفاده از گزینه‌های پیش‌فرض تبدیل می‌کند.

```java
// یک شیء Presentation ایجاد کنید که نمایانگر فایل PPTX است
Presentation presentation = new Presentation("template.pptx");

// ارائه را به عنوان PPT ذخیره کنید
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **پرسش‌های متداول**

**آیا تمام افکت‌ها و ویژگی‌های PPTX هنگام ذخیره به فرمت legacy PPT (97–2003) حفظ می‌شوند؟**

همیشه نیست. فرمت PPT برخی قابلیت‌های جدیدتر را ندارد (مثلاً برخی افکت‌ها، اشیاء و رفتارها)، بنابراین ویژگی‌ها ممکن است در هنگام تبدیل ساده‌سازی یا به صورت رستر شده شوند.

**آیا می‌توانم فقط اسلایدهای انتخابی را به PPT تبدیل کنم به‌جای کل ارائه؟**

ذخیره‌سازی مستقیم تمام ارائه را هدف می‌گیرد. برای تبدیل اسلایدهای خاص، یک ارائه جدید فقط با آن اسلایدها ایجاد کنید و به عنوان PPT ذخیره کنید؛ یا از سرویس/API که پارامترهای تبدیل به‌صورت اسلاید به اسلاید را پشتیبانی می‌کند استفاده کنید.

**آیا ارائه‌های دارای رمز عبور پشتیبانی می‌شوند؟**

بله. می‌توانید تشخیص دهید که آیا فایل محافظت شده است، آن را با رمز عبور باز کنید، و همچنین [پیکربندی تنظیمات حفاظت/رمزگذاری](/slides/fa/androidjava/password-protected-presentation/) را برای PPT ذخیره‌شده تنظیم کنید.