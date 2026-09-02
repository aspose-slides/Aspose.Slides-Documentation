---
title: تبدیل ارائه‌های PowerPoint به XML در Python
linktitle: PowerPoint به XML
type: docs
weight: 145
url: /fa/python-net/convert-powerpoint-to-xml/
keywords:
- تبدیل PowerPoint به XML
- تبدیل ارائه به XML
- PPT به XML
- PPTX به XML
- ODP به XML
- ارائه PowerPoint XML
- SaveFormat.XML
- ذخیره ارائه به عنوان XML
- استخراج ارائه به XML
- جریان XML
- Python
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint و OpenDocument به فایل‌ها یا جریان‌های PowerPoint XML در Python با Aspose.Slides."
---
## **نمای کلی**

Aspose.Slides for Python via .NET می‌تواند ارائه‌های PowerPoint را به فرمت PowerPoint XML Presentation تبدیل کند. خروجی XML زمانی مفید است که به نمایشی مبتنی بر متن برای بررسی ساختار ارائه، عیب‌یابی اسناد تولید شده، مقایسه خروجی در تست‌های خودکار، یا یکپارچه‌سازی با گردش کاری که XML را به‌جای بسته ارائه می‌پذیرد، نیاز دارید.

از روش [Presentation.save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/save/) با مقدار `XML` از شمارنده [SaveFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/saveformat/) استفاده کنید. می‌توانید نتیجه را مستقیماً به یک فایل یا به یک جریان (stream) بنویسید.

{{% alert color="info" title="Note" %}}
`SaveFormat.XML` یک PowerPoint XML Presentation ایجاد می‌کند. این روش بخش‌های جداگانهٔ Office Open XML موجود در یک بسته PPTX را استخراج نمی‌کند. اگر به بخش‌های دقیق بسته PPTX مانند `ppt/presentation.xml` یا فایل‌های XML اسلایدهای منفرد نیاز دارید، باید بسته PPTX را به‌صورت مستقیم بررسی کنید.
{{% /alert %}}

## **تبدیل یک ارائه به فایل XML**

یک ارائه منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) بارگذاری کنید و سپس مسیر خروجی و `SaveFormat.XML` را به [Presentation.save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/save/) پاس دهید. منبع می‌تواند هر فرمت ارائه‌ای باشد که برای بارگذاری پشتیبانی می‌شود، مانند PPT، PPTX یا ODP.

مثال زیر یک ارائهٔ PPTX را به فایل XML تبدیل می‌کند:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.xml", slides.export.SaveFormat.XML)
```

## **نوشتن خروجی XML به یک جریان**

از بارگذاری (overload) جریان [Presentation.save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/save/) هنگامی که XML باید در حافظه بماند یا به مؤلفه دیگری مانند سرویس وب، ارائه‌دهندهٔ ذخیره‌سازی یا خط لولهٔ پردازش XML پاس داده شود، استفاده کنید. مثال زیر نتیجه را به یک جریان [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) می‌نویسد و برای خواندن‌های بعدی به‌سر می‌برد:

```py
from io import BytesIO

import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    xml_stream = BytesIO()
    presentation.save(xml_stream, slides.export.SaveFormat.XML)
    xml_stream.seek(0)

    # xml_stream را به مؤلفه بعدی در گردش کار پاس دهید.
```

## **مقایسه XML با فرمت‌های ارائه و خروجی**

فرمت خروجی را بر اساس نحوه استفاده انتخاب کنید:

| فرمت | خروجی | استفاده معمول |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | یک PowerPoint XML Presentation | بررسی ساختار، عیب‌یابی، مقایسه خروجی تولید شده و یکپارچه‌سازی مبتنی بر XML |
| PPT (`.ppt`) | یک فایل ارائهٔ باینری قدیمی | سازگاری با گردش‌های کاری قدیمی PowerPoint |
| PPTX (`.pptx`) | یک بسته Office Open XML شامل چندین بخش | ویرایش عادی PowerPoint و تبادل ارائه‌ها |
| PDF یا TIFF | صفحات با چیدمان ثابت یا تصویر چندصفحه‌ای | مشاهده، چاپ و بایگانی |
| PNG، JPEG یا SVG | نمایش رندر شدهٔ یک اسلاید منفرد | تصاویر بندانگشتی، پیش‌نمایش‌ها و دارایی‌های تصویری |
| HTML یا HTML5 | خروجی ارائهٔ وب‌محور | مشاهده در مرورگر و انتشار وب |

بر خلاف PPT و PPTX، خروجی XML عمدتاً برای بازرسی و جریان‌های کاری مبتنی بر داده‌ها هدف‌گذاری شده است. بر خلاف PDF، TIFF، HTML و فرمت‌های تصویر اسلاید، این خروجی داده‌های ارائه را نشان می‌دهد نه اینکه اسلایدها را به‌عنوان صفحات یا دارایی‌های بصری رندر کند. جدول [supported file formats](/slides/fa/python-net/supported-file-formats/) فرمت PowerPoint XML Presentation را به‌عنوان یک فرمت صرفاً ذخیره‌سازی نشان می‌دهد، بنابراین هنگامی که یک گردش کاری نیاز دارد فایل صادر شده را دوباره در Aspose.Slides بارگذاری کند برای ویرایش ادامه‌دار، از آن استفاده نکنید.

## **سوالات متداول**

**آیا `SaveFormat.XML` همانند ذخیرهٔ یک فایل PPTX است؟**

خیر. PPTX یک بسته شامل چندین بخش Office Open XML است، در حالی که `SaveFormat.XML` یک فایل PowerPoint XML Presentation ایجاد می‌کند.

**آیا می‌توانم خروجی XML را بدون ایجاد فایل روی دیسک ذخیره کنم؟**

بله. یک جریان قابل نوشتن را به [Presentation.save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/save/) پاس دهید. برای مثال، می‌توانید از یک جریان [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) برای پردازش در حافظه استفاده کنید.

**آیا Aspose.Slides می‌تواند فایل XML صادرشده را دوباره بارگذاری کند؟**

خیر. PowerPoint XML Presentation در حال حاضر فقط برای ذخیره‌سازی پشتیبانی می‌شود و برای بارگذاری قابل استفاده نیست. برای ویرایش دور‌دور از PPTX یا یک فرمت ارائهٔ دیگر استفاده کنید.

**آیا تبدیل XML هر اسلاید را به‌صورت صفحه یا تصویر رندر می‌کند؟**

خیر. تبدیل XML داده‌های ساختاریافتهٔ ارائه را می‌نویسد. برای خروجی صفحه‌محور از PDF یا TIFF و برای تصویر اسلایدهای منفرد از PNG، JPEG و SVG استفاده کنید.