---
title: وارد کردن ارائه‌ها از PDF یا HTML در Python از طریق Java
linktitle: وارد کردن ارائه
type: docs
weight: 60
url: /fa/python-java/import-presentation/
keywords:
- وارد کردن ارائه
- وارد کردن اسلاید
- وارد کردن PDF
- وارد کردن HTML
- PDF به ارائه
- PDF به PPT
- PDF به PPTX
- PDF به ODP
- HTML به ارائه
- HTML به PPT
- HTML به PPTX
- HTML به ODP
- پاورپوینت
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "چگونه محتوای PDF و HTML را به ارائه‌های PowerPoint در Python از طریق Java با Aspose.Slides وارد کنید و نتایج را به صورت فایل‌های PPTX ذخیره نمایید."
---
## **مقدمه**

Aspose.Slides for Python via Java می‌تواند صفحات PDF یا محتوای HTML را بدون نیاز به Microsoft PowerPoint به اسلایدهای PowerPoint تبدیل کند. کلاس [SlideCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/) متدهای [addFromPdf](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addFromPdf) و [addFromHtml](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addFromHtml) را برای افزودن محتوای وارد شده به یک ارائه فراهم می‌کند.

برای کنترل بیشتر روی قرارگیری HTML، متد [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#insertFromHtml) می‌تواند اسلایدهای تولید شده را در یک ایندکس از مجموعه درج کند یا فضای موجود در یک اسلاید فعلی را پر کند. HTML طولانی به‌صورت خودکار بر روی اسلایدهای اضافی صفحه‌بندی می‌شود، منبع می‌تواند به‌صورت رشته یا جریان ارائه شود و منابع خارجی می‌توانند از طریق [ExternalResourceResolver](https://reference.aspose.com/slides/fa/python-java/aspose.slides/externalresourceresolver/) با یک URI پایه بارگذاری شوند. آرایهٔ [Slide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/) برگردانده شده اسلایدهای تحت تاثیر و اسلایدهای جدید ایجاد شده را شناسایی می‌کند.

## **وارد کردن از PDF**

برای تبدیل یک سند PDF به ارائهٔ PowerPoint، محتوای آن را به مجموعه اسلایدها وارد کرده و نتیجه را به‌صورت فایل PPTX ذخیره کنید.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. یک شیء جدید از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
2. با مسیر فایل PDF، متد [addFromPdf](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addFromPdf) را فراخوانی کنید.
3. متد [save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) را با [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/#Pptx) فراخوانی کنید تا ارائه در یک فایل PPTX نوشته شود.

مثال زیر به زبان Python یک سند PDF را وارد کرده و اسلایدهای تولید شده را به‌صورت ارائهٔ PowerPoint ذخیره می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().addFromPdf("document.pdf")
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

اسلاید خالی پیش‌فرض در ارائه باقی می‌ماند زیرا وارد کردن اسلایدها را اضافه می‌کند. برای نگه داشتن فقط صفحات وارد شده، پیش از وارد کردن مجموعه اسلایدها را با [SlideCollection.clear](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#clear) پاک کنید.

متد [addFromPdf](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addFromPdf) اسلایدهایی را که اضافه می‌کند برمی‌گرداند که وقتی فقط نیاز به پردازش اسلایدهای وارد شده دارید، مفید است.

{{% alert title="نکته" color="success" %}}
از برنامهٔ وب رایگان [PDF to PowerPoint](https://products.aspose.app/slides/fa/import/pdf-to-powerpoint) استفاده کنید تا این جریان تبدیل را در عمل ببینید.
{{% /alert %}}

## **وارد کردن از HTML**

Aspose.Slides همچنین می‌تواند اسلایدها را از یک سند HTML ایجاد کند. منبع می‌تواند به‌صورت متن HTML یا یک جریان ارائه شود. مراحل زیر از یک جریان فایل استفاده می‌کند:

1. یک شیء جدید از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
2. فایل HTML را برای خواندن باز کنید و جریان را به [addFromHtml](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addFromHtml) پاس بدهید.
3. متد [save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) را با [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/#Pptx) فراخوانی کنید تا نتیجه در یک فایل PPTX نوشته شود.

مثال زیر به زبان Python یک سند HTML را وارد کرده و اسلایدهای تولید شده را به‌صورت ارائهٔ PowerPoint ذخیره می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.io import FileInputStream

presentation = Presentation()
try:
    html_stream = FileInputStream("page.html")
    try:
        presentation.getSlides().addFromHtml(html_stream)
    finally:
        html_stream.close()
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **درج محتوای HTML**

هنگامی که اسلایدهای تولید شده توسط HTML باید در موقعیت خاصی قرار گیرند نه اینکه به انتها اضافه شوند، از [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#insertFromHtml) استفاده کنید. ایندکس بصورت صفر‑مبنا است و موقعیتی را که وارد کردن از آن آغاز می‌شود مشخص می‌کند.

آرگومان `useSlideWithIndexAsStart` نحوهٔ استفادهٔ واردکننده از آن موقعیت را کنترل می‌کند:

- وقتی مقدار آن `False` باشد، واردکننده اسلایدهای جدیدی در ایندکس مشخص شده ایجاد می‌کند و اسلایدهای بعدی را جابجا می‌کند.
- وقتی مقدار آن `True` باشد، واردکننده شروع به پر کردن محتوا در فضای موجود بر روی اسلاید فعلی در همان ایندکس می‌کند. اگر HTML جا نیفتد، Aspose.Slides به‌صورت خودکار آن را صفحه‌بندی کرده و اسلایدهای اضافی را بلافاصله پس از اسلاید شروع درج می‌کند.

متد [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#insertFromHtml) آرایه‌ای از اشیاء [Slide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/) برمی‌گرداند. وقتی درج بر روی اسلایدهای جدید آغاز می‌شود، هر مورد برگردانده‌شده اسلایدی جدید است. وقتی یک اسلاید موجود به‌عنوان شروع استفاده می‌شود، آرایه شامل آن اسلاید تحت تأثیر و سپس هر اسلاید اضافهٔ overflow است. می‌توانید این آرایه را بررسی کنید به جای محاسبهٔ محدودهٔ تحت تأثیر بر پایهٔ تعداد اسلایدهای ارائه.

### **درج HTML به‌عنوان اسلایدهای جدید**

مثال زیر HTML را به‌صورت رشتهٔ متنی می‌رساند و اسلایدهای تولید شده را در ایندکس `1` مجموعه درج می‌کند. پاس دادن `False` اسلایدهای موجود را تغییری نمی‌دهد جز اینکه برای جا دادن اسلایدهای جدید آن‌ها را جابجا می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    insert_index = 1
    html = "<html><body><h1>Quarterly update</h1><p>This content is inserted before the slide that was at index 1.</p></body></html>"
    inserted_slides = presentation.getSlides().insertFromHtml(insert_index, html, False)

    for slide in inserted_slides:
        print("Inserted slide index:", presentation.getSlides().indexOf(slide))

    presentation.save("presentation-with-inserted-html.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **شروع بر روی اسلاید موجود**

مثال بعدی HTML را از طریق یک جریان می‌گیرد. یک شکل هدر روی اسلاید قالب موجود را حفظ می‌کند، وارد کردن را زیر ناحیهٔ اشغال‌شده شروع می‌کند و اجازه می‌دهد محتوای طولانی به اسلایدهای جدید ادامه یابد.

HTML همچنین شامل یک URL تصویر نسبی است. یک [ExternalResourceResolver](https://reference.aspose.com/slides/fa/python-java/aspose.slides/externalresourceresolver/) منبع را به دست می‌آورد، در حالی که URI پایه به واردکننده می‌گوید چگونه `images/logo.png` را حل کند. در این مثال، انتظار می‌رود این فایل در `html-assets/images/logo.png` قرار داشته باشد.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExternalResourceResolver, Presentation, SaveFormat, ShapeType
from java.io import ByteArrayInputStream

presentation = Presentation()
try:
    template_slide = presentation.getSlides().get_Item(0)
    header = template_slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 680, 60)
    header.getTextFrame().setText("Product roadmap")

    html_parts = ["<html><body><img src='images/logo.png' width='120' height='60'><h2>Roadmap details</h2>"]
    for item_index in range(1, 61):
        html_parts.append(f"<p style='font-size:24pt'>Roadmap item {item_index}: detailed implementation notes.</p>")
    html_parts.append("</body></html>")

    html = "".join(html_parts)
    html_data = html.encode("utf-8")
    resolver = ExternalResourceResolver()
    base_directory = Path("html-assets").resolve()
    base_uri = base_directory.as_uri() + "/"

    html_stream = ByteArrayInputStream(html_data)
    try:
        affected_slides = presentation.getSlides().insertFromHtml(0, html_stream, resolver, base_uri, True)
        for slide in affected_slides:
            print("Affected slide index:", presentation.getSlides().indexOf(slide))
    finally:
        html_stream.close()

    presentation.save("presentation-with-html-overflow.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="هشدار" color="warning" %}}
یک resolver منابع خارجی بدون محدودیت می‌تواند منابع محلی یا شبکه‌ای که توسط HTML ارجاع داده شده‌اند را بخواند. برای ورودی‌های غیرقابل اعتماد، قبل از وارد کردن HTML، URLهای منابع را نسبت به فهرست سفید از طرح‌نامه‌های مجاز، دایرکتوری‌ها و میزبان‌ها اعتبارسنجی و تمیز کنید.
{{% /alert %}}

## **سوالات متداول**

**آیا Aspose.Slides می‌تواند جدول‌ها را هنگام وارد کردن PDF تشخیص دهد؟**

بله. یک شیء [PdfImportOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfimportoptions/) ایجاد کنید، متد [setDetectTables](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfimportoptions/#setDetectTables) را با `True` فراخوانی کنید و گزینه‌ها را به [addFromPdf](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addFromPdf) پاس دهید. کیفیت شناسایی جدول‌ها به ساختار و پیچیدگی PDF منبع بستگی دارد.

{{% alert title="نکته" color="info" %}}
پس از وارد کردن HTML، می‌توانید اسلایدها را به [images](/slides/fa/python-java/convert-powerpoint-to-png/)، [TIFF](/slides/fa/python-java/convert-powerpoint-to-tiff/)، یا [SVG](/slides/fa/python-java/render-slide-as-svg/) نیز صادر کنید.
{{% /alert %}}