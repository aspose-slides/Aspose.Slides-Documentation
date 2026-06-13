---
title: تبدیل PPTX به PPT در .NET
linktitle: PPTX به PPT
type: docs
weight: 21
url: /fa/net/convert-pptx-to-ppt/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPTX
- PPTX به PPT
- ذخیره PPTX به صورت PPT
- صادر کردن PPTX به PPT
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به راحتی PPTX را به PPT با Aspose.Slides برای .NET تبدیل کنید—سازگاری یکپارچه با فرمت‌های PowerPoint را تضمین کنید و چیدمان و کیفیت ارائه خود را حفظ نمایید."
---
## **مروری کلی**

این مقاله توضیح می‌دهد چگونه ارائهٔ پاورپوینت در فرمت PPTX را با استفاده از C# به فرمت PPT تبدیل کنیم. موضوع زیر پوشش داده می‌شود.

- تبدیل PPTX به PPT در C#

## **تبدیل PPTX به PPT در .NET**

برای مثال کد C# جهت تبدیل PPTX به PPT، لطفاً به بخش زیر مراجعه کنید؛ [Convert PPTX to PPT](#convert-pptx-to-ppt). این کد فقط فایل PPTX را بارگذاری کرده و در فرمت PPT ذخیره می‌کند. با تعیین فرمت‌های ذخیره‌سازی مختلف، می‌توانید فایل PPTX را به فرمت‌های دیگری مانند PDF، XPS، ODP، HTML و غیره نیز ذخیره کنید، همان‌طور که در این مقالات بحث شده است.

- [تبدیل PPTX به PDF در .NET](/slides/fa/net/convert-powerpoint-to-pdf/)
- [تبدیل PPTX به XPS در .NET](/slides/fa/net/convert-powerpoint-to-xps/)
- [تبدیل PPTX به HTML در .NET](/slides/fa/net/convert-powerpoint-to-html/)
- [تبدیل PPTX به ODP در .NET](/slides/fa/net/save-presentation/)
- [تبدیل PPTX به PNG در .NET](/slides/fa/net/convert-powerpoint-to-png/)

## **تبدیل PPTX به PPT**
برای تبدیل یک PPTX به PPT کافی است نام فایل و فرمت ذخیره‌سازی را به متد [**Save**](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) کلاس [**Presentation**](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) منتقل کنید. نمونه کد C# زیر یک Presentation را از PPTX به PPT با استفاده از گزینه‌های پیش‌فرض تبدیل می‌کند.

```c#
// یک شیء Presentation که نمایانگر یک فایل PPTX است را ایجاد کنید
Presentation pres = new Presentation("presentation.pptx");

// ذخیرهٔ ارائه PPTX به فرمت PPT
pres.Save("presentation.ppt", SaveFormat.Ppt);
```

## **پرسش‌های متداول**

**آیا تمام افکت‌ها و ویژگی‌های PPTX هنگام ذخیره‌سازی به فرمت PPT قدیمی (97–2003) حفظ می‌شوند؟**

همیشه 그렇 نیست. فرمت PPT برخی قابلیت‌های جدیدتر (مانند برخی افکت‌ها، اشیاء و رفتارها) را شامل نمی‌شود، بنابراین ویژگی‌ها ممکن است در طول تبدیل ساده‌سازی یا به تصویر رستر شوند.

**آیا می‌توانم فقط اسلایدهای انتخابی را به PPT تبدیل کنم به جای کل ارائه؟**

ذخیره‌گیری مستقیم تمام ارائه را هدف می‌گیرد. برای تبدیل اسلایدهای خاص، یک ارائه جدید فقط با آن اسلایدها ایجاد کنید و به‌صورت PPT ذخیره کنید؛ یا از سرویس/API‌ای استفاده کنید که پارامترهای تبدیل بر پایه اسلاید را پشتیبانی می‌کند.

**آیا ارائه‌های رمز‌گذاری‌شده پشتیبانی می‌شوند؟**

بله. می‌توانید تشخیص دهید که آیا فایل محافظت‌شده است، آن را با رمز عبور باز کنید، و همچنین [تنظیمات حفاظت/رمزنگاری](/slides/fa/net/password-protected-presentation/) را برای PPT ذخیره‌شده پیکربندی کنید.