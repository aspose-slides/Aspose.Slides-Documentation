---
title: تبدیل ارائه‌های PowerPoint به XML در Python via Java
linktitle: PowerPoint به XML
type: docs
weight: 145
url: /fa/python-java/convert-powerpoint-to-xml/
keywords:
- تبدیل PowerPoint به XML
- تبدیل ارائه به XML
- PPT به XML
- PPTX به XML
- ODP به XML
- ارائه PowerPoint XML
- SaveFormat.Xml
- ذخیره ارائه به عنوان XML
- صادرات ارائه به XML
- جریان XML
- Python
- Java
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint و OpenDocument به فایل‌ها یا جریان‌های PowerPoint XML در Python via Java با Aspose.Slides for Python via Java."
---
## **مرور کلی**

Aspose.Slides for Python via Java می‌تواند ارائه‌های PowerPoint را به فرمت PowerPoint XML Presentation تبدیل کند. خروجی XML زمانی مفید است که به نمایشی متنی برای بررسی ساختار ارائه، عیب‌یابی اسناد تولید شده، مقایسه خروجی در تست‌های خودکار یا یکپارچه‌سازی با یک گردش کاری که به جای بسته ارائه از XML استفاده می‌کند، نیاز داشته باشید.

از متد [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) همراه با مقدار [Xml](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/#Xml) از کلاس [SaveFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/) استفاده کنید. می‌توانید نتیجه را مستقیماً در یک فایل یا به یک جریان بنویسید.

{{% alert color="info" title="Note" %}}
[SaveFormat.Xml](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/#Xml) یک PowerPoint XML Presentation ایجاد می‌کند. این کار قسمت‌های جداگانهٔ Office Open XML ذخیره‌شده درون بسته PPTX را استخراج نمی‌کند. اگر به قسمت‌های دقیق بسته PPTX نیاز دارید، مانند `ppt/presentation.xml` یا فایل‌های XML اسلایدهای جداگانه، بسته PPTX را مستقیماً بررسی کنید.
{{% /alert %}}

## **تبدیل ارائه به فایل XML**

یک ارائه منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بارگذاری کنید و سپس مسیر خروجی و [SaveFormat.Xml](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/#Xml) را به [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) پاس دهید. منبع می‌تواند هر فرمت ارائه‌ای باشد که برای بارگذاری پشتیبانی می‌شود، مانند PPT، PPTX یا ODP.

مثال زیر یک ارائهٔ PPTX را به یک فایل XML تبدیل می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.xml", SaveFormat.Xml)
finally:
    presentation.dispose()
```

## **نوشتن خروجی XML به یک جریان**

زمانی که XML باید در حافظه بماند یا به مؤلفه‌ای دیگر مانند سرویس وب، ارائه‌دهندهٔ ذخیره‌سازی یا خط لولهٔ پردازش XML منتقل شود، از بارگذاری جریان متد [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) استفاده کنید. مثال زیر نتیجه را در یک [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) می‌نویسد و XML حاصل را به‌صورت یک شیء bytes در پایتون به‌دست می‌آورد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpaste.startJVM()

from asposeslides.api import Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

presentation = Presentation("presentation.pptx")
try:
    xml_stream = ByteArrayOutputStream()
    try:
        presentation.save(xml_stream, SaveFormat.Xml)
        java_bytes = xml_stream.toByteArray()
        xml_data = bytes(java_bytes)

        # xml_data را به مؤلفهٔ بعدی در جریان کاری منتقل کنید.
    finally:
        xml_stream.close()
finally:
    presentation.dispose()
```

## **مقایسه XML با فرمت‌های ارائه و خروجی**

فرمت خروجی را بر اساس نحوهٔ استفاده از نتیجه انتخاب کنید:

| فرمت | خروجی | کاربرد معمول |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | یک PowerPoint XML Presentation | بازرسی ساختار، عیب‌یابی، مقایسه خروجی تولید شده و یکپارچه‌سازی مبتنی بر XML |
| PPT (`.ppt`) | یک فایل ارائهٔ دودویی قدیمی | سازگاری با گردش‌های کاری قدیمی PowerPoint |
| PPTX (`.pptx`) | یک بسته Office Open XML شامل چندین بخش | ویرایش معمول PowerPoint و تبادل ارائه |
| PDF یا TIFF | صفحات با طرح ثابت یا تصویر چندصفحه‌ای | مشاهده، چاپ و آرشیت | 
| PNG، JPEG یا SVG | یک نمای رندر شده از یک اسلاید منفرد | تصویرک‌ها، پیش‌نمایش‌ها و دارایی‌های تصویری |
| HTML یا HTML5 | خروجی ارائهٔ مبتنی بر وب | نمایش در مرورگر و انتشار وب |

بر خلاف PPT و PPTX، خروجی XML عمدتاً برای بازرسی و گردش‌های کاری داده‑محور هدف‌گذاری شده است. بر خلاف PDF، TIFF، HTML و فرمت‌های تصویر اسلاید، XML داده‌های ارائه را نمایش می‌دهد نه اینکه اسلایدها را به‌صورت صفحات یا دارایی‌های تصویری رندر کند. جدول [فرمت‌های فایل پشتیبانی‌شده](/slides/fa/python-java/supported-file-formats/) PowerPoint XML Presentation را تنها به عنوان فرمت ذخیره‑تنها فهرست می‌کند، بنابراین هنگام نیاز به بارگذاری مجدد فایل صادراتی برای ویرایش ادامه‌دار، از آن استفاده نکنید.

## **سوالات متداول**

**آیا صادرات XML همانند ذخیره‌سازی یک فایل PPTX است؟**

خیر. PPTX یک بسته حاوی بخش‌های متعدد Office Open XML است، در حالی که [SaveFormat.Xml](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/#Xml) یک فایل PowerPoint XML Presentation ایجاد می‌کند.

**آیا می‌توان خروجی XML را بدون ایجاد فایل روی دیسک ذخیره کرد؟**

بله. یک جریان خروجی قابل نوشتن جاوا را به [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) پاس دهید. برای مثال، می‌توانید از یک [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) برای پردازش در حافظه استفاده کنید.

**آیا Aspose.Slides می‌تواند فایل XML صادرشده را دوباره بارگذاری کند؟**

خیر. PowerPoint XML Presentation در حال حاضر فقط برای ذخیره‌سازی پشتیبانی می‌شود و برای بارگذاری قابل استفاده نیست. برای ویرایش دور‌دور، از PPTX یا فرمت ارائهٔ پشتیبانی‌شده دیگری استفاده کنید.

**آیا تبدیل XML هر اسلاید را به‌صورت صفحه یا تصویر رندر می‌کند؟**

خیر. تبدیل XML داده‌های ساختاریافتهٔ ارائه را می‌نویسد. برای خروجی صفحه‑محور از PDF یا TIFF استفاده کنید یا برای تصاویر اسلایدهای منفرد از PNG، JPEG و SVG بهره ببرید.