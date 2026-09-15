---
title: ایجاد یک نمایشگر ارائه در پایتون از طریق جاوا
linktitle: نمایشگر ارائه
type: docs
weight: 50
url: /fa/python-java/presentation-viewer/
keywords:
- مشاهده ارائه
- نمایشگر ارائه
- ایجاد نمایشگر ارائه
- مشاهده PPT
- مشاهده PPTX
- مشاهده ODP
- پاورپوینت
- سند باز
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "یک نمایشگر ارائه سفارشی در پایتون از طریق جاوا با استفاده از Aspose.Slides ایجاد کنید. به راحتی فایل‌های پاورپوینت و سند باز را بدون نیاز به مایکروسافت پاورپوینت نمایش دهید."
---
## **مقدمه**

Aspose.Slides برای Python از طریق Java برای ایجاد فایل‌های ارائه‌ای با اسلایدها استفاده می‌شود. این اسلایدها می‌توانند با باز کردن ارائه‌ها در Microsoft PowerPoint، به عنوان مثال، مشاهده شوند. اما گاهی توسعه‌دهندگان ممکن است نیاز داشته باشند اسلایدها را به عنوان تصویر در نمایش‌گر تصویر دلخواه خود ببینند یا نمایشگر ارائه خود را بسازند. در چنین مواردی، Aspose.Slides امکان استخراج یک اسلاید منفرد به صورت تصویر را فراهم می‌کند. این مقاله توضیح می‌دهد چگونه این کار را انجام دهید.

## **تولید تصویر SVG از یک اسلاید**

برای تولید تصویر SVG از یک اسلاید ارائه با Aspose.Slides، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید را بر اساس شمارهٔ آن دریافت کنید.
1. یک جریان بایت (byte stream) باز کنید.
1. اسلاید را به صورت تصویر SVG در جریان ذخیره کنید و آن را در یک فایل بنویسید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import ByteArrayOutputStream

slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **تولید SVG با شناسه شکل سفارشی**

Aspose.Slides می‌تواند برای تولید یک [SVG](https://docs.fileformat.com/page-description-language/svg/) از اسلایدی با شناسه شکل سفارشی استفاده شود. برای این کار، از متد [SvgShape.setId](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgshape/#setId) در [SvgShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgshape/) استفاده کنید. می‌توان از `CustomSvgShapeFormattingController` برای تنظیم شناسه شکل استفاده کرد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import ByteArrayOutputStream

class CustomSvgShapeFormattingController:
    def __init__(self, shape_start_index=0):
        self.shape_index = shape_start_index

    def formatShape(self, svg_shape, shape):
        svg_shape.setId(f"shape-{self.shape_index}")
        self.shape_index += 1


slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    controller = CustomSvgShapeFormattingController()
    controller_proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(controller_proxy)

    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream, svg_options)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **ایجاد تصویر بندانگشتی اسلاید**

Aspose.Slides به شما کمک می‌کند تا تصاویر بندانگشتی اسلایدها را تولید کنید. برای تولید یک بندانگشتی از اسلاید با استفاده از Aspose.Slides، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید را بر اساس اندیس آن دریافت کنید.
1. تصویر بندانگشتی اسلاید مرجع را با مقیاس تعریف‌شده دریافت کنید.
1. تصویر بندانگشتی را در هر قالب تصویر دلخواهی ذخیره کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat

slide_index = 0
scale_x = 1.0
scale_y = scale_x

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(scale_x, scale_y)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **ایجاد بندانگشتی اسلاید با ابعاد تعریف‌شده توسط کاربر**

برای ایجاد تصویر بندانگشتی اسلاید با ابعاد تعریف‌شده توسط کاربر، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید را بر اساس اندیس آن دریافت کنید.
1. تصویر بندانگشتی اسلاید مرجع را با ابعاد تعریف‌شده دریافت کنید.
1. تصویر بندانگشتی را در هر قالب تصویر دلخواهی ذخیره کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat
from java.awt import Dimension

slide_index = 0
slide_size = Dimension(1200, 800)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(slide_size)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **ایجاد بندانگشتی اسلاید با یادداشت‌های سخنران**

برای تولید بندانگشتی اسلاید با یادداشت‌های سخنران با استفاده از Aspose.Slides، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [RenderingOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/renderingoptions/) ایجاد کنید.
1. از متد [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) برای تنظیم موقعیت یادداشت‌های سخنران استفاده کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید را بر اساس اندیس آن دریافت کنید.
1. تصویر بندانگشتی اسلاید مرجع را با گزینه‌های رندرینگ دریافت کنید.
1. تصویر بندانگشتی را در هر قالب تصویر دلخواهی ذخیره کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, RenderingOptions

slide_index = 0
layouting_options = NotesCommentsLayoutingOptions()
layouting_options.setNotesPosition(NotesPositions.BottomTruncated)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layouting_options)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(rendering_options)
    try:
        image.save("output.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **مثال زنده**

می‌توانید برنامهٔ رایگان [**Aspose.Slides Viewer**](https://products.aspose.app/slides/fa/viewer/) را امتحان کنید تا ببینید با API Aspose.Slides چه می‌توانید پیاده‌سازی کنید:

![نمایشگر آنلاین پاورپوینت](online-PowerPoint-viewer.png)

## **پرسش‌های متداول**

**آیا می‌توانم یک نمایشگر ارائه را در یک برنامه وب جاسازی کنم؟**

بله. می‌توانید از Aspose.Slides در سمت سرور برای رندر کردن اسلایدها به صورت تصویر یا HTML استفاده کنید و آنها را در مرورگر نمایش دهید. ویژگی‌های ناوبری و زوم می‌توانند با JavaScript برای تجربهٔ تعاملی پیاده‌سازی شوند.

**بهترین روش برای نمایش اسلایدها در داخل یک مشاهده‌گر سفارشی چیست؟**

روش پیشنهادی این است که هر اسلاید را به صورت تصویر (مثلاً PNG یا SVG) رندر کنید یا با استفاده از Aspose.Slides به HTML تبدیل کنید، سپس خروجی را داخل یک PictureBox (برای دسکتاپ) یا یک عنصر HTML (برای وب) نمایش دهید.

**چگونه می‌توانم ارائه‌های بزرگ با تعداد زیاد اسلاید را مدیریت کنم؟**

برای ارائه‌های بزرگ، بارگذاری تنبل (lazy‑loading) یا رندرینگ بر‑تقاضای اسلایدها را در نظر بگیرید. این به این معنی است که محتوای اسلاید فقط زمانی تولید می‌شود که کاربر به آن حرکت می‌کند، که باعث کاهش مصرف حافظه و زمان بارگذاری می‌شود.