---
title: عملیات ارائه با کد‑کم در پایتون از طریق جاوا
linktitle: API کد‑کم
type: docs
weight: 50
url: /fa/python-java/low-code-presentation-operations/
keywords:
- API ارائه کد‑کم
- تبدیل ارائه
- ترکیب ارائه‌ها
- تکرار اسلایدها
- تکرار اشکال
- تکرار متن
- جمع‌آوری اشکال
- فشرده‌سازی ارائه
- حذف اسلایدهای مستر استفاده نشده
- حذف اسلایدهای قالب استفاده نشده
- فشرده‌سازی فونت‌های توکار
- پاورپوینت
- OpenDocument
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "از API کد‑کم Aspose.Slides در پایتون از طریق جاوا برای تبدیل و ترکیب ارائه‌ها، تکرار محتوا، جمع‌آوری اشکال و کاهش حجم ارائه استفاده کنید."
---
## **نمای کلی**

API [Aspose.Slides for Python via Java](https://reference.aspose.com/slides/fa/python-java/aspose.slides/) کلاس‌های کمکی ایستا برای عملیات رایج ارائه را فراهم می‌کند. این کمکی‌ها جریان‌های کاری مدل‑شیء پرکاربرد را در متدهای متمرکز می‌پیچند، به‌طوری که می‌توانید فایل‌ها را تبدیل یا ترکیب کنید، عناصر ارائه را پردازش کنید، شکل‌ها را جمع‌آوری کنید و محتویات استفاده نشده را با کد کمتر حذف کنید.

کمکی‌های کم‌کد بیشترین کاربرد را زمانی دارند که عملیات بر روی یک فایل یا ارائه کامل اعمال می‌شود و جریان کاری پیش‌فرض با نیازهای شما هم‌خوانی داشته باشد. هنگامی که نیاز به کنترل دقیق بر اسلایدهای تک‌تک، مسترها، قالب‌ها، اشکال، تنظیمات خروجی یا روابط بین عناصر ارائه دارید، از [Aspose.Slides object model](https://reference.aspose.com/slides/fa/python-java/aspose.slides/) کامل استفاده کنید.

جدول زیر خلاصه‌ای از کمکی‌های موجود را ارائه می‌دهد:

| کمکی | موارد استفاده |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/fa/python-java/aspose.slides/convert/) | تبدیل ارائه به قالب دیگر با فراخوانی مستقیم فایل‑به‑فایل. |
| [Merger](https://reference.aspose.com/slides/fa/python-java/aspose.slides/merger/) | ترکیب فایل‌های ارائه کامل با همان قالب. |
| [ForEach](https://reference.aspose.com/slides/fa/python-java/aspose.slides/foreach/) | اجرای عملی برای هر اسلاید، شکل، پاراگراف یا بخش متن. |
| [Collect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/collect/) | استخراج شکل‌ها از کل ارائه برای پردازش یا تحلیل مکرر. |
| [Compress](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compress/) | حذف مسترها و قالب‌های استفاده نشده و کاهش داده‌های فونت توکار. |

## **تبدیل یک ارائه**

از [Convert.autoByExtension](https://reference.aspose.com/slides/fa/python-java/aspose.slides/convert/#autoByExtension) زمانی استفاده کنید که پسوند فایل خروجی برای انتخاب قالب خروجی کافی باشد. این متد ارائه منبع را باز می‌کند، قالب مورد نیاز را از مسیر خروجی تعیین می‌کند و نتیجه را می‌نویسد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Convert

Convert.autoByExtension("input.pptx", "output.pdf")
```

کلاس [Convert](https://reference.aspose.com/slides/fa/python-java/aspose.slides/convert/) همچنین متدهای اختصاصی برای خروجی PDF، SVG، JPEG، PNG و TIFF فراهم می‌کند. زمانی که نیاز دارید پیش از خروجی‌گیری ارائه را بررسی یا تغییر دهید یا گزینه خروجی‌ای را تنظیم کنید که توسط کمکی منتخب در دسترس نیست، از مدل شیء کامل استفاده کنید. برای جریان‌های کاری و گزینه‌های خاص هر قالب، به [Convert Presentation](/slides/fa/python-java/convert-presentation/) مراجعه کنید.

## **ادغام ارائه‌ها**

از [Merger.process](https://reference.aspose.com/slides/fa/python-java/aspose.slides/merger/#process) برای ترکیب فایل‌های ارائه کامل با یک فراخوانی استفاده کنید. ارائه‌های ورودی باید همان قالب فایل را داشته باشند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Merger

input_files = jpype.JArray(jpype.JString)(["part-1.pptx", "part-2.pptx"])
Merger.process(input_files, "merged.pptx")
```

این کمکی مناسب است هنگامی که همه اسلایدها باید بدون انتخاب یا نگاشت جداگانه به یک نتیجه اضافه شوند. هنگامی که نیاز به ادغام اسلایدهای منتخب، اعمال مستر یا قالب مقصد، حفظ واضح بخش‌ها یا سازگار کردن اندازه‌های متفاوت اسلایدها دارید، از مدل شیء کامل استفاده کنید. برای این سناریوها به [Merge Presentations](/slides/fa/python-java/merge-presentation/) مراجعه کنید.

## **تکرار در عناصر ارائه**

کلاس [ForEach](https://reference.aspose.com/slides/fa/python-java/aspose.slides/foreach/) یک کال‌بک را برای هر نوع عنصر درخواست‌شده از ارائه فراخوانی می‌کند. این کار از حلقه‌های تو در توی جمع‌آوری جلوگیری می‌کند و برای بازرسی یا تغییر فرمت در سطح کل ارائه مناسب است.

مثال زیر از [ForEach.slide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/foreach/#slide)، [ForEach.shape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/foreach/#shape)، [ForEach.paragraph](https://reference.aspose.com/slides/fa/python-java/aspose.slides/foreach/#paragraph) و [ForEach.portion](https://reference.aspose.com/slides/fa/python-java/aspose.slides/foreach/#portion) برای بررسی عناصر مربوطه استفاده می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ForEach, Presentation

def print_slide(slide, index):
    print(f"Slide {index}: {slide.getShapes().size()} shapes")

def print_shape(shape, slide, index):
    print(f"Shape {index} on {slide.getClass().getSimpleName()}: {shape.getName()}")

def print_paragraph(paragraph, slide, index):
    print(f"Paragraph {index} on {slide.getClass().getSimpleName()}: {paragraph.getText()}")

def print_portion(portion, paragraph, slide, index):
    print(f"Portion {index} on {slide.getClass().getSimpleName()}: {portion.getText()}")

presentation = Presentation("input.pptx")
try:
    ForEach.slide(presentation, print_slide)
    ForEach.shape(presentation, print_shape)
    ForEach.paragraph(presentation, print_paragraph)
    ForEach.portion(presentation, print_portion)
finally:
    presentation.dispose()
```

به طور پیش‌فرض، پیمایش شکل و متن در سطح کل ارائه شامل اسلایدهای عادی، مستر و قالب می‌شود. بارگذاری‌های با پارامتر `includeNotes` می‌توانند اسلایدهای یادداشت‌ها را نیز پردازش کنند. هنگامی که ترتیب پیمایش، خروج زودهنگام، فیلتر قبل از فراخوانی کال‌بک یا کنترل دقیق والد‑فرزندی مهم باشد، از حلقه‌های جمع‌آوری مستقیم استفاده کنید.

## **جمع‌آوری اشکال**

از [Collect.shapes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/collect/#shapes) زمانی استفاده کنید که به یک مجموعه از تمام اشکال در یک ارائه نیاز دارید نه کال‌بکی برای هر شکل. این برای زمانی مفید است که همان مجموعه بارها فیلتر، شمارش یا پردازش شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Collect, Presentation

presentation = Presentation("input.pptx")
try:
    shapes = Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.getName()}: {shape.getClass().getSimpleName()}")
finally:
    presentation.dispose()
```

به‌جای آن وقتی که می‌توانید هر شکل را بلافاصله در یک کال‌بک پردازش کنید و نیازی به نگه داشتن نتیجه جمع‌آوری شده ندارید، از [ForEach.shape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/foreach/#shape) استفاده کنید.

## **فشرده‌سازی محتوای ارائه**

کلاس [Compress](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compress/) می‌تواند عناصر ساختاری استفاده نشده را حذف و داده‌های فونت توکار را کاهش دهد:

- [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) قالب‌های اسلایدی را که هیچ اسلاید عادی به آن ارجاع نمی‌دهد حذف می‌کند.
- [removeUnusedMasterSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compress/#removeUnusedMasterSlides) اسلایدهای مستری که دیگر استفاده نمی‌شوند را حذف می‌کند.
- [compressEmbeddedFonts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compress/#compressEmbeddedFonts) کاراکترهای استفاده نشده را از فونت‌های توکار حذف می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    Compress.removeUnusedMasterSlides(presentation)
    Compress.compressEmbeddedFonts(presentation)

    presentation.save("compressed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

قالب‌های استفاده نشده را قبل از مسترهای استفاده نشده حذف کنید تا مستری که پس از پاک‌سازی قالب‌ها دیگر مرجع نداشته باشد، بتواند حذف شود. اگر ممکن است بعداً به مسترها، قالب‌ها یا داده‌های کامل فونت توکار اصلی نیاز داشته باشید، ارائه بهینه‌سازی شده را در فایل جدیدی ذخیره کنید. برای جزئیات بیشتر به [Slide Master](/slides/fa/python-java/slide-master/) و [Embedded Font](/slides/fa/python-java/embedded-font/) مراجعه کنید.

## **سؤالات متداول**

**چه زمانی باید از API کم‌کد به‌جای مدل شیء کامل استفاده کنم؟**

وقتی یک عملیات استاندارد بر روی یک فایل یا ارائه کامل اعمال می‌شود و نیازی به کنترل جزئی بر عناصر تک‌تک نیست، از کمکی‌های کم‌کد استفاده کنید. زمانی که باید اسلایدهای خاصی را انتخاب کنید، روابط مستر و قالب را کنترل کنید، وضعیت میانی را بررسی کنید یا رفتارهایی را تنظیم کنید که کمکی آن‌ها را نشان نمی‌دهد، از مدل شیء کامل استفاده کنید.

**آیا Merger می‌تواند ارائه‌ها را در قالب‌های فایل مختلف ترکیب کند؟**

خیر. [Merger.process](https://reference.aspose.com/slides/fa/python-java/aspose.slides/merger/#process) نیاز دارد که ارائه‌های ورودی در همان قالب باشند. ابتدا فایل‌های ورودی را به قالب مشترکی تبدیل کنید، برای مثال با [Convert.autoByExtension](https://reference.aspose.com/slides/fa/python-java/aspose.slides/convert/#autoByExtension)، سپس فایل‌های تبدیل‌شده را ادغام کنید.

**آیا ForEach اسلایدهای مستر، قالب و یادداشت‌ها را پردازش می‌کند؟**

[ForEach.slide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/foreach/#slide) فقط اسلایدهای عادی ارائه را پیمایش می‌کند. عملیات‌های [ForEach.shape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/foreach/#shape)، [ForEach.paragraph](https://reference.aspose.com/slides/fa/python-java/aspose.slides/foreach/#paragraph) و [ForEach.portion](https://reference.aspose.com/slides/fa/python-java/aspose.slides/foreach/#portion) به طور پیش‌فرض اسلایدهای عادی، مستر و قالب را شامل می‌شوند. برای شامل کردن اسلایدهای یادداشت‌ها از بارگذاری‌هایشان با مقدار `includeNotes` برابر `True` استفاده کنید.

**تفاوت Between ForEach.shape و Collect.shapes چیست؟**

از [ForEach.shape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/foreach/#shape) برای پردازش هر شکل بلافاصله در یک کال‌بک استفاده کنید. وقتی به یک نتیجه قابل تکرار نیاز دارید که می‌تواند نگه‌داشته، فیلتر یا شمارش شود، از [Collect.shapes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/collect/#shapes) استفاده کنید.

**آیا Compress همیشه فایل ارائه را کوچک‌تر می‌کند؟**

لزومی نیست. نتیجه به این بستگی دارد که آیا ارائه شامل قالب‌های استفاده نشده، مسترهای استفاده نشده یا فونت‌های توکار با کاراکترهای استفاده نشده باشد یا خیر. اگر هیچ‌یک از این موارد وجود نداشته باشد، عملیات‌های مربوط به [Compress](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compress/) ممکن است اندازه فایل را کاهش ندهند.

**آیا تغییرات اعمال‌شده توسط ForEach یا Compress به‌صورت خودکار ذخیره می‌شوند؟**

خیر. این کمکی‌ها بر روی شیء [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بارگذاری‌شده در حافظه کار می‌کنند. پس از تغییر عناصر در کال‌بک [ForEach](https://reference.aspose.com/slides/fa/python-java/aspose.slides/foreach/) یا اجرای [Compress](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compress/)، برای نوشتن نتیجه باید [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) را فراخوانی کنید.

## **مقالات مرتبط**

- [Convert Presentation](/slides/fa/python-java/convert-presentation/)
- [Merge Presentations](/slides/fa/python-java/merge-presentation/)
- [Slide Master](/slides/fa/python-java/slide-master/)
- [Manage Text Box](/slides/fa/python-java/manage-textbox/)
- [Embedded Font](/slides/fa/python-java/embedded-font/)