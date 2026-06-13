---
title: استخراج اشیای فلش از ارائه‌ها در .NET
linktitle: فلش
type: docs
weight: 10
url: /fa/net/flash/
keywords:
- استخراج فلش
- شیء فلش
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه اشیای فلش را از اسلایدهای PowerPoint و OpenDocument در .NET با Aspose.Slides استخراج کنید، نمونه‌های کامل کد C# و بهترین شیوه‌ها."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه با استفاده از Aspose.Slides اشیای Flash را از ارائه‌ها استخراج کنید. نشان می‌دهد چگونه یک کنترل Flash را بر اساس نام در مجموعه کنترل‌های اسلاید پیدا کنید و با داده‌های توکار شیء SWF کار کنید.

## **استخراج اشیای Flash از ارائه‌ها**
Aspose.Slides برای .NET یک قابلیت برای استخراج اشیای flash از ارائه فراهم می‌کند. می‌توانید کنترل flash را بر حسب نام دریافت کرده و آن را از ارائه استخراج کنید و داده‌های شیء SWF را ذخیره نمایید.

```c#
using (Presentation pres = new Presentation("withFlash.pptm"))
{
    IControlCollection controls = pres.Slides[0].Controls;
    Control flashControl = null;
    foreach (IControl control in controls)
    {
        if (control.Name == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
}
```

## **سؤالات متداول**

**چه قالب‌های ارائه‌ای هنگام استخراج محتوای Flash پشتیبانی می‌شوند؟**

[Aspose.Slides پشتیبانی می‌کند](/slides/fa/net/supported-file-formats/) قالب‌های اصلی PowerPoint مانند PPT و PPTX، زیرا می‌تواند این بسته‌ها را بارگذاری و به کنترل‌های آن‌ها دسترسی داشته باشد، شامل عناصر ActiveX مربوط به Flash.

**آیا می‌توانم ارائه‌ای حاوی Flash را به HTML5 تبدیل کنم و تعاملات Flash را حفظ کنم؟**

خیر. Aspose.Slides محتوای SWF را اجرا نمی‌کند و تعاملات آن را تبدیل نمی‌سازد. اگرچه صادر کردن به [HTML](/slides/fa/net/convert-powerpoint-to-html/)/[HTML5](/slides/fa/net/export-to-html5/) پشتیبانی می‌شود، Flash در مرورگرهای مدرن به دلیل پایان پشتیبانی پخش نمی‌شود. مسیر توصیه‌شده این است که قبل از صادرات، Flash را با گزینه‌های جایگزین مانند ویدیو یا انیمیشن‌های HTML5 جایگزین کنید.

**از منظر امنیت، آیا Aspose.Slides در حین خواندن یک ارائه فایل‌های SWF را اجرا می‌کند؟**

خیر. Aspose.Slides Flash را به عنوان داده‌های باینری توکار در فایل درنظر می‌گیرد و در هنگام پردازش محتوای SWF را اجرا نمی‌کند.

**چگونه باید با ارائه‌هایی که Flash را به همراه سایر فایل‌های توکار از طریق OLE شامل می‌شوند، برخورد کنم؟**

Aspose.Slides از [استخراج اشیای OLE توکار](/slides/fa/net/manage-ole/) پشتیبانی می‌کند، بنابراین می‌توانید تمام محتویات توکار مرتبط را در یک مرحله پردازش کنید و کنترل‌های Flash و سایر اسناد توکار OLE را به‌صورت همزمان مدیریت نمایید.