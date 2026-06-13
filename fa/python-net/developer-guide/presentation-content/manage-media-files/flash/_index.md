---
title: استخراج اشیای Flash از ارائه‌ها در Python
linktitle: فلاش
type: docs
weight: 10
url: /fa/python-net/flash/
keywords:
- استخراج فلاش
- شیء فلاش
- پاورپوینت
- سند باز
- ارائه
- پایتون
- Aspose.Slides
description: "یاد بگیرید چگونه اشیای Flash را از اسلایدهای PowerPoint و OpenDocument در پایتون با Aspose.Slides استخراج کنید، نمونه کد کامل و بهترین شیوه‌ها."
---
## **نمای کلی**

این مقاله نحوه استخراج اشیای Flash از ارائه‌ها را با استفاده از Aspose.Slides توضیح می‌دهد. نشان می‌دهد چگونه می‌توان کنترل Flash را بر اساس نام در مجموعه کنترل‌های یک اسلاید پیدا کرد و با داده‌های شیء SWF جاسازی‌شده کار کرد.

## **استخراج اشیای Flash از ارائه**
Aspose.Slides برای Python از طریق .NET قابلیت استخراج اشیای flash را از یک ارائه فراهم می‌کند. می‌توانید کنترل flash را بر حسب نام دسترسی پیدا کنید و آن را از ارائه استخراج کنید و داده‌های شیء SWF را ذخیره کنید.

```py
import aspose.slides as slides

with slides.Presentation("withFlash.pptm") as pres:
    controls = pres.slides[0].controls
    for control in controls:
        if control.Name == "ShockwaveFlash1":
            flashControl = control
```

## **سؤالات متداول**

**چه فرمت‌های ارائه‌ای هنگام استخراج محتوای Flash پشتیبانی می‌شوند؟**

[پشتیبانی Aspose.Slides](/slides/fa/python-net/supported-file-formats/) فرمت‌های اصلی PowerPoint مانند PPT و PPTX را، زیرا می‌تواند این کانتینرها را بارگذاری کرده و به کنترل‌های آن‌ها دسترسی پیدا کند، از جمله عناصر ActiveX مرتبط با Flash.

**آیا می‌توانم یک ارائه حاوی Flash را به HTML5 تبدیل کنم و تعاملات Flash را نگه دارم؟**

خیر. Aspose.Slides محتویات SWF را اجرا نمی‌کند و تعاملات آن را تبدیل نمی‌سازد. در حالی که صادرات به [HTML](/slides/fa/python-net/convert-powerpoint-to-html/)/[HTML5](/slides/fa/python-net/export-to-html5/) پشتیبانی می‌شود، Flash در مرورگرهای مدرن به دلیل پایان پشتیبانی اجرا نمی‌شود. مسیر توصیه‌شده این است که قبل از صادرات Flash را با جایگزین‌هایی مانند ویدیو یا انیمیشن‌های HTML5 تعویض کنید.

**از منظر امنیتی، آیا Aspose.Slides هنگام خواندن یک ارائه فایل‌های SWF را اجرا می‌کند؟**

خیر. Aspose.Slides Flash را به عنوان دادهٔ باینری در فایل در نظر می‌گیرد و در حین پردازش محتویات SWF را اجرا نمی‌کند.

**چگونه باید ارائه‌هایی را که Flash همراه با فایل‌های جاسازی‌شده دیگر از طریق OLE دارند، مدیریت کنم؟**

Aspose.Slides از [استخراج اشیای OLE جاسازی‌شده](/slides/fa/python-net/manage-ole/) پشتیبانی می‌کند، بنابراین می‌توانید تمام محتویات جاسازی‌شده مرتبط را در یک عبور پردازش کنید و کنترل‌های Flash و دیگر اسناد جاسازی‌شده از طریق OLE را به‌طور همزمان مدیریت کنید.