---
title: تبدیل ارائه‌های PowerPoint به XPS در Python
linktitle: PowerPoint به XPS
type: docs
weight: 70
url: /fa/python-java/convert-powerpoint-to-xps/
keywords:
  - تبدیل PowerPoint
  - تبدیل ارائه
  - تبدیل PPT
  - تبدیل PPTX
  - PowerPoint به XPS
  - ارائه به XPS
  - PPT به XPS
  - PPTX به XPS
  - ذخیره PPT به عنوان XPS
  - ذخیره PPTX به عنوان XPS
  - صادرات PPT به XPS
  - صادرات PPTX به XPS
  - Python
  - Java
  - Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint PPT و PPTX به XPS در Python با استفاده از Aspose.Slides برای Python از طریق Java، با تنظیمات صادرات پیش‌فرض یا سفارشی."
---
## **مروری**

Aspose.Slides for Python via Java به شما امکان می‌دهد ارائه‌های PowerPoint را به XPS تبدیل کنید با ذخیره‌سازی یک فایل PPT یا PPTX در قالب XPS. این مقاله توضیح می‌دهد که چه زمانی XPS مفید است و نحوه صادرات یک ارائه را با استفاده از تنظیمات پیش‌فرض یا تنظیمات سفارشی [XpsOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/xpsoptions/) نشان می‌دهد.

## **درباره XPS**

XPS (XML Paper Specification) یک قالب سند مبتنی بر XML است که توسط مایکروسافت توسعه یافته است. این قالب صفحات ثابت را توصیف می‌کند و چیدمان متن و گرافیک را برای مشاهده و چاپ با نرم‌افزارهای سازگار حفظ می‌کند.

## **زمان استفاده از قالب XPS مایکروسافت**

از XPS استفاده کنید وقتی جریان کاری سند شما به فایل‌های با چیدمان ثابت برای اشتراک‌گذاری یا چاپ از طریق ابزارهای سازگار با XPS نیاز دارد. دریافت‌کنندگان باید نرم‌افزاری داشته باشند که از XPS پشتیبانی کند. اگر جریان کاری شما به PDF نیاز دارد، به [Convert PowerPoint to PDF](/slides/fa/python-java/convert-powerpoint-to-pdf/) مراجعه کنید.

{{% alert color="info" title="Note" %}}
برای آزمایش تبدیل یک ارائه PPT یا PPTX به XPS، از [free online converter](https://products.aspose.app/slides/fa/conversion) استفاده کنید.
{{% /alert %}}

| ارائه PowerPoint ورودی | سند XPS خروجی |
| --- | --- |
| ![Original PowerPoint presentation](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png) | ![Presentation converted to XPS](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png) |

## **تبدیل XPS با Aspose.Slides**

از متد [save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) همراه با [SaveFormat.Xps](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/#Xps) برای صادرات یک ارائه استفاده کنید. می‌توانید از تنظیمات پیش‌فرض صادرات استفاده کنید یا با ارائه [XpsOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/xpsoptions/) خروجی را سفارشی کنید.

هر مثال زیر در صورت نیاز ماشین مجازی جاوا را راه‌اندازی می‌کند و پس از استفاده ارائه را آزاد می‌کند. نام فایل ورودی را با مسیر فایل PPT یا PPTX خود جایگزین کنید.

### **تبدیل ارائه‌ها به XPS با تنظیمات پیش‌فرض**

کد Python زیر ارائه را با تنظیمات پیش‌فرض به XPS تبدیل می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # ارائه را به عنوان سند XPS ذخیره کنید.
    presentation.save("output.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

### **تبدیل ارائه‌ها به XPS با تنظیمات سفارشی**

مثال زیر از [XpsOptions.setSaveMetafilesAsPng](https://reference.aspose.com/slides/fa/python-java/aspose.slides/xpsoptions/#setSaveMetafilesAsPng) برای ذخیره متافایل‌ها به عنوان تصاویر PNG در سند XPS حاصل استفاده می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpase.startJVM()

from asposeslides.api import Presentation, SaveFormat, XpsOptions

presentation = Presentation("presentation.pptx")
try:
    xps_options = XpsOptions()
    xps_options.setSaveMetafilesAsPng(True)

    # ارائه را با تنظیمات سفارشی XPS ذخیره کنید.
    presentation.save("output_custom.xps", SaveFormat.Xps, xps_options)
finally:
    presentation.dispose()
```

## **سوالات متداول**

**آیا می‌توانم XPS را به یک جریان (stream) به‌جای فایل ذخیره کنم؟**

بله. متد [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) بارگذاری‌های مختلفی دارد که یک جریان خروجی جاوا را می‌پذیرند. با Python via Java می‌توانید از یک جریان سازگار جاوا از طریق JPype استفاده کنید، مانند Java byte-array output stream، تا داده‌های صادر شده در حافظه باقی بمانند.

**آیا اسلایدهای مخفی در خروجی XPS گنجانده می‌شوند؟**

اسلایدهای مخفی به‌صورت پیش‌فرض حذف می‌شوند. برای گنجاندن آنها، قبل از ذخیره‌سازی [XpsOptions.setShowHiddenSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/xpsoptions/#setShowHiddenSlides) را به `True` تنظیم کنید.

**آیا انیمیشن‌ها و انتقالات اسلاید در XPS حفظ می‌شوند؟**

خیر. XPS شامل صفحات ثابت است، بنابراین اسلایدهای صادر شده انیمیشن یا اثرات انتقال را اجرا نمی‌کنند.