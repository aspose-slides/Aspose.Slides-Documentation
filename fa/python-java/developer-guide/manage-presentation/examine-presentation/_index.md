---
title: بازیابی و به‌روزرسانی اطلاعات ارائه در پایتون از طریق جاوا
linktitle: اطلاعات ارائه
type: docs
weight: 30
url: /fa/python-java/examine-presentation/
keywords:
- فرمت ارائه
- خواص ارائه
- خواص سند
- دریافت خواص
- خواندن خواص
- تغییر خواص
- اصلاح خواص
- به‌روزرسانی خواص
- بررسی PPTX
- بررسی PPT
- بررسی ODP
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "اسلایدها، ساختار و متادیتا را در ارائه‌های PowerPoint و OpenDocument با استفاده از پایتون از طریق جاوا بررسی کنید تا بینش‌های سریع‌تر و بازبینی‌های هوشمند محتوا به دست آورید."
---
## **مرور کلی**

Aspose.Slides می‌تواند قالب ارائه را شناسایی کند و متادیتای سند آن را بدون ایجاد یک مدل شیء کامل ارائه بخواند. این برای زمانی مفید است که نیاز به طبقه‌بندی فایل‌ها، ساخت موجودی یا بررسی خصوصیات قبل از تصمیم‌گیری برای بارگذاری و پردازش محتوای ارائه داشته باشید.

مثال‌ها به Aspose.Slides برای Python از طریق Java و یک محیط اجرایی Java سازگار نیاز دارند. هر مثال JVM را در صورتی که در حال اجرا نباشد، راه‌اندازی می‌کند. فایل‌های ارائه موجود را در مسیرهای استفاده شده در مثال‌ها فراهم کنید.

این مقاله بازرسی سبک را از طریق [PresentationFactory](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationfactory/) و [PresentationInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/) نشان می‌دهد، و به‌روزرسانی‌های هدفمند را از طریق [DocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/) ارائه می‌کند.

## **بررسی قالب ارائه**

از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationfactory/#getPresentationInfo) برای بررسی یک فایل بدون ایجاد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) استفاده کنید. متد [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#getLoadFormat) قالب شناسایی‌شده را گزارش می‌دهد، مانند PPTX، PPT یا ODP.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadFormat, PresentationFactory

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_name)
    load_format = presentation_info.getLoadFormat()
    format_name = f"Other ({load_format})"

    if load_format == LoadFormat.Pptx:
        format_name = "PPTX"
    elif load_format == LoadFormat.Ppt:
        format_name = "PPT"
    elif load_format == LoadFormat.Odp:
        format_name = "ODP"

    print(f"{file_name}: {format_name}")
```

## **ساخت موجودی سبک ارائه**

هنگامی که تعداد زیادی فایل ارائه را پردازش می‌کنید، ممکن است به یک موجودی فشرده برای اعتبارسنجی، فهرست‌سازی یا سیستم مدیریت مستندات نیاز داشته باشید. در این حالت، از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationfactory/#getPresentationInfo) برای به‌دست آوردن یک شیء [PresentationInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/) استفاده کنید و سپس [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#readDocumentProperties) را فراخوانی کنید تا متادیتای سند را بخوانید. این روش یک نمونه [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد نمی‌کند و نیازی به پیمایش کامل مدل شیء ارائه ندارید.

خواص توسعه‌یافته‌ای که توسط [DocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/) ارائه می‌شود، مقادیر موجودی زیر را فراهم می‌کند:

| Method | Inventory value |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getSlides) | کل تعداد اسلایدها. |
| [getHiddenSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getHiddenSlides) | تعداد اسلایدهای مخفی. |
| [getNotes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getNotes) | تعداد اسلایدهایی که حاوی یادداشت هستند. |
| [getParagraphs](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getParagraphs) | کل تعداد پاراگراف‌ها، در صورت وجود. |
| [getWords](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getWords) | کل تعداد کلمات. |
| [getMultimediaClips](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getMultimediaClips) | کل تعداد کلیپ‌های صوتی و تصویری. |

مثال زیر این مقادیر را بدون ایجاد یک شیء [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) می‌خواند و موجودی فشرده‌ای را چاپ می‌کند. همچنین [getHeadingPairs](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getHeadingPairs) را با [getTitlesOfParts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getTitlesOfParts) ترکیب می‌کند تا گروه‌های محتوا مانند قلم‌ها، تم‌ها و عناوین اسلاید را نمایش دهد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadFormat, PresentationFactory

file_path = "sample.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)
document_properties = presentation_info.readDocumentProperties()

load_format = presentation_info.getLoadFormat()
format_name = f"Other ({load_format})"

if load_format == LoadFormat.Pptx:
    format_name = "PPTX"
elif load_format == LoadFormat.Ppt:
    format_name = "PPT"
elif load_format == LoadFormat.Odp:
    format_name = "ODP"

print(f"File: {Path(file_path).name}")
print(f"Format: {format_name}")
print(f"Title: {document_properties.getTitle()}")
print(f"Author: {document_properties.getAuthor()}")
print("Statistics:")
print(f"  Slides: {document_properties.getSlides()}")
print(f"  Hidden slides: {document_properties.getHiddenSlides()}")
print(f"  Slides with notes: {document_properties.getNotes()}")
print(f"  Paragraphs: {document_properties.getParagraphs()}")
print(f"  Words: {document_properties.getWords()}")
print(f"  Multimedia clips: {document_properties.getMultimediaClips()}")

heading_pairs = document_properties.getHeadingPairs()
titles_of_parts = document_properties.getTitlesOfParts()
heading_pairs = heading_pairs if heading_pairs is not None else []
titles_of_parts = titles_of_parts if titles_of_parts is not None else []
part_index = 0

if len(heading_pairs) == 0 or len(titles_of_parts) == 0:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.getName()} ({heading_pair.getCount()})")

        for part_offset in range(heading_pair.getCount()):
            if part_index >= len(titles_of_parts):
                break
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1

    if part_index < len(titles_of_parts):
        print("  Other parts:")

        while part_index < len(titles_of_parts):
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1
```

هر [HeadingPair](https://reference.aspose.com/slides/fa/python-java/aspose.slides/headingpair/) یک نام گروه و تعداد آیتم‌های موجود در آن گروه را فراهم می‌کند. [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getTitlesOfParts) یک آرایه تخت و مرتب بر می‌گرداند، بنابراین تعداد عناوین متوالی مشخص‌شده توسط هر جفت سرعنوان (heading pair) را مصرف کنید.

### **متادیتای ذخیره‌شده و محدودیت‌های قالب**

خواص موجودی که توسط [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#readDocumentProperties) بازگردانده می‌شوند، متادیتای موجود در سند منبع را نشان می‌دهند. Aspose.Slides این مقادیر را برای این فراخوانی با بارگذاری و پیمایش مدل شیء ارائه مجدداً محاسبه نمی‌کند. خواص گمشده با مقادیر پیش‌فرض نشان داده می‌شوند و مقادیر ذخیره‌شده ممکن است منقضی باشند اگر برنامه‌ای که آخرین بار فایل را ذخیره کرده است، خواص سند را به‌روز نکرده باشد.

- **PPTX:** این قالب خواص سند توسعه‌یافته‌ای برای تعداد اسلاید، یادداشت، اسلاید مخفی، پاراگراف، کلمه و چندرسانه‌ای، همچنین جفت‌های سرعنوان و عناوین بخش‌ها فراهم می‌کند. در دسترس بودن آن به این بستگی دارد که کدام خواص توسط تولیدکننده سند نوشته شده‌اند.
- **PPT:** این قالب باینری می‌تواند خواص خلاصه‌سند مربوطه را ذخیره کند. اگر یک خاصیت غایب باشد یا توسط تولیدکننده سند به‌روزرسانی نشده باشد، Aspose.Slides مقدار ذخیره‌شده یا پیش‌فرض آن را باز می‌گرداند و نه محاسبه آن از اسلایدها.
- **ODP:** متادیتای OpenDocument آمار کلی سند مانند تعداد صفحه، پاراگراف و کلمه را ارائه می‌دهد، اما این مقادیر با تمام خواص توسعه‌یافته مخصوص PowerPoint مطابقت ندارند. متادیتای اسلاید مخفی، اسلاید یادداشت، چندرسانه‌ای، جفت سرعنوان و عناوین بخش ممکن است در دسترس نباشند و خواص موجودی ممکن است مقادیر پیش‌فرض بازگردانند. مقدار صفر یا آرایه خالی را به‌عنوان اثبات قطعی عدم وجود محتوا در نظر نگیرید.

برای موجودی‌ها و بررسی‌های اولیه از روش متادیتای سبک استفاده کنید. هنگامیکه نتیجه باید تغییرات در حافظه را منعکس کند یا نیاز به تأیید محتوای واقعی ارائه دارید، ارائه را بارگذاری کنید و مدل شیء زنده آن را بررسی کنید.

## **به‌روزرسانی خواص ارائه**

خواص بازگردانده‌شده توسط [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#readDocumentProperties) می‌توانند بدون ایجاد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) نیز تغییر کنند. تغییرات را با [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) اعمال کنید و سپس ارائه باند شده را با [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) بنویسید.

تصویر زیر خواص سند اصلی ارائه PowerPoint را نشان می‌دهد.

![خواص سند اصلی ارائه PowerPoint](input_properties.png)

مثال زیر عنوان و زمان ذخیره‌سازی آخرین بار را تغییر می‌دهد و نتیجه را در یک فایل جدید می‌نویسد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory
from java.io import FileOutputStream
from java.util import Date

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(source_file)
document_properties = presentation_info.readDocumentProperties()

document_properties.setTitle("Quarterly sales report")
last_saved_time = Date()
document_properties.setLastSavedTime(last_saved_time)

presentation_info.updateDocumentProperties(document_properties)
output_stream = FileOutputStream(output_file)
try:
    presentation_info.writeBindedPresentation(output_stream)
finally:
    output_stream.close()
```

![خواص سند تغییر یافته ارائه PowerPoint](output_properties.png)

## **لینک‌های مفید**

برای بررسی‌های امنیتی مرتبط و تنظیمات محافظت، مقالات زیر را ببینید:

- [ارائه‌های محافظت‌شده با رمز](/slides/fa/python-java/password-protected-presentation/)
- [ارائه‌های محافظت‌شده در نوشتن](/slides/fa/python-java/write-protected-presentation/)

## **سوالات متداول**

**چگونه می‌توانم بررسی کنم که آیا فونت‌ها جاسازی شده‌اند و کدام‌ها هستند؟**

ارائه را بارگذاری کنید و از [Presentation.getFontsManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getFontsManager) استفاده کنید. برای به‌دست آوردن فونت‌های جاسازی‌شده، [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) را صدا بزنید و برای دریافت فونت‌های استفاده‌شده در ارائه، [FontsManager.getFonts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/#getFonts) را فراخوانی کنید. دو نتیجه را مقایسه کنید تا فونت‌هایی که برای رندر لازم هستند اما جاسازی نشده‌اند را پیدا کنید.

**چگونه می‌توانم سریعاً بفهمم که آیا فایل اسلایدهای مخفی دارد و تعداد آن‌ها چقدر است؟**

زمانی که متادیتای ذخیره‌شده سند کافی باشد، می‌توانید [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getHiddenSlides) را از طریق [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationfactory/#getPresentationInfo) و [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#readDocumentProperties) بخوانید. این برای یک موجودی سبک مناسب است. اگر ارائه در حافظه تغییر یافته باشد، ممکن است متادیتای ذخیره‌شده گمشده یا منقضی باشد، یا نیاز داشته باشید مقادیر زنده را تأیید کنید؛ در این صورت به‌جای آن، از طریق [Presentation.getSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSlides) پیمایش کنید و متد [Slide.getHidden](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getHidden) هر اسلاید را بررسی کنید.

**آیا می‌توانم تشخیص دهم که آیا اندازه و جهت سفارشی اسلاید استفاده شده است و آیا با پیش‌فرض‌ها متفاوت است؟**

بله. ارائه را بارگذاری کنید و [Presentation.getSlideSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSlideSize) را فراخوانی کنید. از [SlideSize.getType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesize/#getType)، [SlideSize.getSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesize/#getSize) و [SlideSize.getOrientation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesize/#getOrientation) برای مقایسه تنظیمات فعلی با پیش‌تنظیمات و ابعاد مورد انتظار استفاده کنید.

**آیا راهی سریع برای مشاهده اینکه آیا نمودارها به منابع داده خارجی ارجاع می‌دهند وجود دارد؟**

بله. هر [Chart](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/) را پیدا کنید و [ChartData.getDataSourceType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#getDataSourceType) را فراخوانی کنید. برای یک دفتر کار خارجی، [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) را صدا بزنید. نوع منبع داده و مسیر، یک ارجاع خارجی را شناسایی می‌کنند، اما تأیید در دسترس بودن هدف نیاز به بررسی منابع جداگانه دارد.

**چگونه می‌توانم اسلایدهای «سنگین» که ممکن است رندر یا خروجی PDF را کند کنند ارزیابی کنم؟**

هیچ خاصیت تک‌بعدی برای پیچیدگی وجود ندارد. از طریق [Presentation.getSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSlides) و مجموعه [BaseSlide.getShapes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/#getShapes) هر اسلاید پیمایش کنید. از تعداد اشکال و حضور تصاویر بزرگ، افکت‌ها، انیمیشن‌ها یا چندرسانه‌ای به‌عنوان علائم ارزیابی استفاده کنید و یک رندر یا خروجی نمونه‌برداری انجام دهید تا پیش از این‌که اسلاید را به‌عنوان یک گلوگاه عملکردی تأیید کنید، ارزیابی کنید.