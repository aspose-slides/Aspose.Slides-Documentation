---
title: کار چندنخی در Aspose.Slides برای Python از طریق Java
linktitle: چندنخی
type: docs
weight: 310
url: /fa/python-java/multithreading/
keywords:
- چندنخی
- چندین رشته
- کار موازی
- تبدیل اسلایدها
- اسلایدها به تصویر
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "کار چندنخی Aspose.Slides برای Python از طریق Java پردازش PowerPoint و OpenDocument را تقویت می‌کند. بهترین روش‌ها برای جریان‌های کاری مؤثر ارائه را کشف کنید."
---
## **مقدمه**

اگرچه کار همزمان با ارائه‌ها امکان‌پذیر است (به‌جز تجزیه، بارگذاری و شبیه‌سازی) و معمولاً به‌خوبی کار می‌کند، اما هنگام استفاده از کتابخانه در چندین رشته احتمال کمی برای نتایج نادرست وجود دارد.

ما قویاً توصیه می‌کنیم که **نکنید** از یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) در محیط چندرشته‌ای استفاده **نکنید** زیرا ممکن است منجر به خطاها یا شکست‌های پیش‌بینی‌نشده‌ای شود که به‌راحتی قابل شناسایی نیستند.

بارگذاری، ذخیره‌سازی و/یا شبیه‌سازی یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) در چندین رشته **نیست** امن. چنین عملیات‌هایی **پشتیبانی نمی‌شوند**. اگر نیاز به انجام چنین کارهایی دارید، باید عملیات را با استفاده از چندین فرآیند تک‌رشته‌ای موازی‌سازی کنید — و هر یک از این فرآیندها باید از نمونهٔ ارائهٔ خود استفاده کنند.

## **تبدیل اسلایدهای ارائه به تصویر به صورت موازی**

فرض کنید می‌خواهیم تمام اسلایدهای یک ارائهٔ PowerPoint را به تصاویر PNG به‌صورت موازی تبدیل کنیم. چون استفاده از یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) در چندین رشته ایمن نیست، اسلایدهای ارائه را به ارائه‌های جداگانه تقسیم می‌کنیم و اسلایدها را به‌صورت موازی به تصویر تبدیل می‌کنیم، به‌طوری که هر ارائه در یک رشته جدا استفاده شود. مثال کد زیر نشان می‌دهد چگونه این کار را انجام دهیم.

```python
from concurrent.futures import ThreadPoolExecutor

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, SlideSizeScaleType


input_file_path = "sample.pptx"
output_file_path_template = "slide_{}.png"
image_scale = 2.0


def convert_slide_to_image(slide_presentation, slide_number):
    try:
        slide = slide_presentation.getSlides().get_Item(0)
        image = slide.getImage(image_scale, image_scale)
        try:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.Png)
        finally:
            image.dispose()
    finally:
        slide_presentation.dispose()


presentation = Presentation(input_file_path)
try:
    slide_count = presentation.getSlides().size()
    slide_size = presentation.getSlideSize().getSize()
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())

    with ThreadPoolExecutor() as executor:
        conversion_tasks = []
        for slide_index in range(slide_count):
            # استخراج اسلاید به یک ارائه جداگانه.
            slide_presentation = Presentation()
            slide_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)
            slide_presentation.getSlides().removeAt(0)
            slide_presentation.getSlides().addClone(presentation.getSlides().get_Item(slide_index))

            # تبدیل اسلاید به یک تصویر در یک کار جداگانه.
            slide_number = slide_index + 1
            conversion_task = executor.submit(convert_slide_to_image, slide_presentation, slide_number)
            conversion_tasks.append(conversion_task)

        # انتظار برای تکمیل تمام کارها.
        for conversion_task in conversion_tasks:
            conversion_task.result()
finally:
    presentation.dispose()
```

## **سوالات متداول**

**آیا نیاز دارم تنظیمات لایسنس را در هر رشته فراخوانی کنم؟**

خیر. کافی است یک‌بار در هر فرآیند قبل از شروع رشته‌ها انجام شود. اگر [license setup](/slides/fa/python-java/licensing/) ممکن است به‌صورت همزمان فراخوانی شود (مثلاً در هنگام مقداردهی تنبل)، آن فراخوانی را همگام‌سازی کنید زیرا خود متد تنظیم لایسنس ایمن در برابر چندرشته‌ای نیست.

**آیا می‌توانم اشیاء [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) یا [Slide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/) را بین رشته‌ها منتقل کنم؟**

انتقال اشیاء ارائهٔ «زنده» بین رشته‌ها توصیه نمی‌شود: برای هر رشته از نمونه‌های مستقل استفاده کنید یا پیشاپیش ارائه‌ها یا محفظه‌های اسلاید جداگانه برای هر رشته ایجاد کنید. این رویکرد مطابق با توصیهٔ کلی عدم اشتراک یک نمونهٔ ارائه بین رشته‌ها است.

**آیا ایمن است که خروجی به فرمت‌های مختلف (PDF، HTML، تصاویر) را به‌صورت موازی انجام داد به‌شرط اینکه هر رشته یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) خود داشته باشد؟**

بله. با نمونه‌های مستقل و مسیرهای خروجی جداگانه، چنین وظایفی معمولاً به‌درستی به‌صورت موازی اجرا می‌شوند؛ از هر گونه شیء ارائهٔ مشترک و جریان‌های ورودی/خروجی مشترک پرهیز کنید.

**در صورت استفاده از چندرشته‌ای، باید با تنظیمات سراسری قلم (پوشه‌ها، جایگزینی‌ها) چه کاری انجام دهم؟**

تمام تنظیمات سراسری [font settings](/slides/fa/python-java/powerpoint-fonts/) را قبل از شروع رشته‌ها مقداردهی کنید و در طول کار موازی آن‌ها را تغییر ندهید. این کار رقابت‌های دسترسی به منابع قلم مشترک را از بین می‌برد.