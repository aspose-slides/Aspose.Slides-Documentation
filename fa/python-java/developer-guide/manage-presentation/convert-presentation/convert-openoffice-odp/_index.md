---
title: تبدیل پرزنتیشن‌های OpenDocument در پایتون
linktitle: تبدیل OpenDocument
type: docs
weight: 10
url: /fa/python-java/convert-openoffice-odp/
keywords:
- تبدیل ODP
- ODP به PDF
- ODP به HTML
- ODP به TIFF
- ODP به PPT
- ODP به PPTX
- ODP به XPS
- OpenDocument
- پرزنتیشن
- Python
- Java
- Aspose.Slides
description: "پرزنتیشن‌های OpenDocument (ODP) را به PDF، HTML و سایر فرمت‌ها با Aspose.Slides برای پایتون از طریق جاوا تبدیل کنید، بدون نیاز به نصب OpenOffice یا LibreOffice."
---
## **معرفی**

Aspose.Slides for Python via Java به شما امکان می‌دهد پرزنتیشن‌های OpenDocument (ODP) را به قالب‌هایی مانند PDF، HTML، TIFF، XPS، PPT و PPTX تبدیل کنید. تبدیل ODP از همان API تبدیل PowerPoint استفاده می‌شود: فایل منبع را با [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بارگذاری کنید و قالب خروجی را با [SaveFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/) انتخاب کنید.

## **تبدیل ODP به PDF**

قبل از اجرای مثال، [دستورالعمل نصب](/slides/fa/python-java/installation/) را دنبال کنید. یک پرزنتیشن ODP به نام `pres.odp` را در پوشه کاری قرار دهید. کد زیر در صورت نیاز JVM را راه‌اندازی می‌کند، پرزنتیشن را بارگذاری می‌کند و آن را به صورت `pres.pdf` ذخیره می‌نماید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.odp")
try:
    presentation.save("pres.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **پرزنتیشن OpenDocument در برنامه‌های مختلف**

یک پرزنتیشن ODP ممکن است در PowerPoint و LibreOffice/OpenOffice Impress ظاهر متفاوتی داشته باشد زیرا این برنامه‌ها ویژگی‌ها و رفتارهای رندرینگ متفاوتی را پشتیبانی می‌کنند. هنگامیکه چیدمان به قالب‌بندی‌های پیچیده وابسته است، پرزنتیشن‌های تبدیل‌شده را بررسی کنید.

تفاوت‌های سازگاری می‌توانند بر موارد زیر تأثیر بگذارند:

- جداول، از جمله ترتیب لایه‌بندی آنها نسبت به اشکال دیگر و پشتیبانی از پر کردن با تصویر.
- چرخش و تراز متن.
- پر کردن تصویر، گرادیان و الگو برای متن.
- فهرست‌های شماره‌دار و بولت‌دار.

تصویر زیر یک فهرست ایجاد‌شده در LibreOffice Impress را نشان می‌دهد:

![مثال لیست ODP در LibreOffice Impress](odp-list-example.png)

Aspose.Slides فهرست‌های ODP را برای سازگاری با LibreOffice/OpenOffice Impress ذخیره می‌کند.

برای جزئیات درباره سازگاری ویژگی‌ها، به [راهنمای مایکروسافت برای فرمت پرزنتیشن OpenDocument](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0) مراجعه کنید.

## **سوالات متداول**

**اگر قالب‌بندی فایل ODP من پس از تبدیل تغییر کند چه؟**

ODP و PowerPoint از مدل‌های پرزنتیشن متفاوتی استفاده می‌کنند. جداول، فونت‌ها و سبک‌های پر کردن ممکن است به‌صورت متفاوتی رندر شوند. اطمینان حاصل کنید فونت‌های مورد نیاز موجود هستند، خروجی را بررسی کنید و در صورت لزوم چیدمان یا قالب‌بندی را تنظیم کنید.

**آیا برای تبدیل فایل‌های ODP نیاز به نصب OpenOffice یا LibreOffice دارم؟**

خیر. Aspose.Slides for Python via Java پرزنتیشن‌ها را بدون هیچ‌یک از این برنامه‌ها پردازش می‌کند. فقط یک محیط اجرایی جاوا سازگار و بسته پایتون مورد نیاز است.

**آیا می‌توانم خروجی PDF را هنگام تبدیل یک پرزنتیشن ODP سفارشی کنم؟**

بله. از [PdfOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/) برای پیکربندی تنظیمات خروجی PDF استفاده کنید، مانند کیفیت تصویر و فشرده‌سازی.

**آیا می‌توانم پرزنتیشن‌های ODP را روی سرور یا در یک کانتینر تبدیل کنم؟**

بله. بسته پایتون، یک محیط اجرایی جاوا سازگار و فونت‌های مورد نیاز پرزنتیشن‌های خود را در محیط هدف نصب کنید. نیازی به برنامهٔ اداری نیست.