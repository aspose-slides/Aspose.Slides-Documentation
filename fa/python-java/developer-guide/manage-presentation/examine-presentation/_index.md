---
title: دریافت و به‌روزرسانی اطلاعات ارائه در پایتون از طریق جاوا
linktitle: اطلاعات ارائه
type: docs
weight: 30
url: /fa/python-java/examine-presentation/
keywords:
- فرمت ارائه
- ویژگی‌های ارائه
- ویژگی‌های سند
- دریافت ویژگی‌ها
- خواندن ویژگی‌ها
- تغییر ویژگی‌ها
- اصلاح ویژگی‌ها
- به‌روزرسانی ویژگی‌ها
- بررسی PPTX
- بررسی PPT
- بررسی ODP
- PowerPoint
- OpenDocument
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "اسلایدها، ساختار و متادیتا را در ارائه‌های PowerPoint و OpenDocument با استفاده از پایتون از طریق جاوا بررسی کنید تا بینش‌های سریع‌تر و ارزیابی‌های هوشمندانه‌تر محتوا به‌دست آورید."
---
## **بررسی کلی**

Aspose.Slides می‌تواند قالب یک ارائه را شناسایی کرده و متادیتای سند آن را بدون ایجاد یک مدل شیء کامل ارائه بخواند. این زمانی مفید است که نیاز به طبقه‌بندی فایل‌ها، ایجاد موجودی یا بررسی ویژگی‌ها قبل از تصمیم‌گیری برای بارگذاری و پردازش محتوای ارائه داشته باشید.

مثال‌ها نیاز به Aspose.Slides برای Python از طریق Java و یک زمان اجرا (runtime) سازگار Java دارند. هر مثال JVM را در صورتی که در حال اجرا نباشد، راه‌اندازی می‌کند. فایل‌های ارائه موجود را در مسیرهای استفاده‌شده در مثال‌ها قرار دهید.

این مقاله بازبینی سبک را از طریق [PresentationFactory](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationfactory/) و [PresentationInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/) و همچنین به‌روزرسانی‌های هدفمند را از طریق [DocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/) نشان می‌دهد.

## **بررسی قالب ارائه**

اگر قبلاً یک ارائه بارگذاری شده دارید، برای تشخیص پس از بارگذاری و محدودیت‌های جریان‌های PPT، PPS و POT قدیمی، به [Determine the Original Presentation Format](/slides/fa/python-java/detect-presentation-source-format/) مراجعه کنید.

از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationfactory/#getPresentationInfo) برای بازرسی یک فایل بدون ایجاد یک شیء [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) استفاده کنید. متد [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#getLoadFormat) قالب شناسایی‌شده را گزارش می‌دهد، مانند PPTX، PPT یا ODP.

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

زمانی که فایل‌های بسیاری از ارائه‌ها را پردازش می‌کنید، ممکن است به یک موجودی فشرده برای اعتبارسنجی، ایندکس‌گذاری یا یک سیستم مدیریت سند نیاز داشته باشید. در این سناریو، از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationfactory/#getPresentationInfo) برای دریافت یک شیء [PresentationInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/) استفاده کنید و سپس متد [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#readDocumentProperties) را برای خواندن متادیتای سند فراخوانی کنید. این روش شیء [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد نمی‌کند و نیازی به پیمایش کامل مدل شیء ارائه ندارید.

ویژگی‌های گسترش‌یافته‌ای که توسط [DocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/) نمایان می‌شوند، مقادیر موجودی زیر را فراهم می‌آورند:

| متد | مقدار موجودی |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getSlides) | تعداد کل اسلایدها. |
| [getHiddenSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getHiddenSlides) | تعداد اسلایدهای پنهان. |
| [getNotes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getNotes) | تعداد اسلایدهایی که حاوی یادداشت هستند. |
| [getParagraphs](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getParagraphs) | تعداد کل پاراگراف‌ها، در صورتی که موجود باشد. |
| [getWords](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getWords) | تعداد کل کلمات. |
| [getMultimediaClips](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getMultimediaClips) | تعداد کل کلیپ‌های صوتی و تصویری. |

مثال زیر این مقادیر را بدون ایجاد شیء [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) می‌خواند و یک موجودی فشرده را چاپ می‌کند. همچنین [getHeadingPairs](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getHeadingPairs) را با [getTitlesOfParts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getTitlesOfParts) ترکیب می‌کند تا گروه‌های محتوایی مانند قلم‌ها، تم‌ها و عناوین اسلاید را نمایش دهد.

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

هر [HeadingPair](https://reference.aspose.com/slides/fa/python-java/aspose.slides/headingpair/) یک نام گروه و تعداد موارد در آن گروه را فراهم می‌کند. متد [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getTitlesOfParts) یک آرایه صاف و ترتیبی برمی‌گرداند، بنابراین تعداد عناوین متوالی مشخص‌شده توسط هر جفت سرعنوان را مصرف کنید.

### **متادیتای ذخیره‌شده و محدودیت‌های قالب**

ویژگی‌های موجودی که توسط [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#readDocumentProperties) بازگردانده می‌شوند، متادیتای موجود در سند منبع را بازتاب می‌دهند. Aspose.Slides مدل شیء ارائه را بارگذاری و پیمایش نمی‌کند تا این مقادیر را برای این فراخوانی مجدد محاسبه کند. ویژگی‌های غائب با مقادیر پیش‌فرض نشان داده می‌شوند و مقادیر ذخیره‌شده ممکن است منسوخ باشند اگر برنامه‌ای که آخرین بار فایل را ذخیره کرده است، ویژگی‌های سند را به‌روز نکرده باشد.

- **PPTX:** این قالب ویژگی‌های مستند گسترش‌یافته برای شمارش اسلاید، یادداشت، اسلایدهای پنهان، پاراگراف، کلمه و چندرسانه‌ای، همچنین جفت‌های سرعنوان و عناوین بخش‌ها را ارائه می‌دهد. در دسترس بودن بستگی به این دارد که کدام ویژگی‌ها توسط تولیدکننده سند نوشته شده‌اند.
- **PPT:** قالب باینری می‌تواند ویژگی‌های خلاصه‌سند متناظر را ذخیره کند. اگر ویژگی‌ای غایب باشد یا توسط تولیدکننده سند تازه‌سازی نشده باشد، Aspose.Slides مقدار ذخیره‌شده یا پیش‌فرض آن را برمی‌گرداند، نه این‌که آن را از اسلایدها محاسبه کند.
- **ODP:** متادیتای OpenDocument آمار کلی سند مانند تعداد صفحه، پاراگراف و کلمه را فراهم می‌کند، اما این مقادیر به همه ویژگی‌های گسترش‌یافته مخصوص PowerPoint نقشه‌برداری نمی‌شود. متادیتای اسلایدهای پنهان، اسلایدهای یادداشت، چندرسانه‌ای، جفت‑سرعنوان و عناوین بخش ممکن است در دسترس نباشد و ویژگی‌های موجودی ممکن است مقادیر پیش‌فرض بازگردانند. مقدار صفر یا آرایه خالی را به‌عنوان اثبات قطعی عدم وجود محتوا در نظر نگیرید.

از رویکرد متادیتای سبک برای موجودی‌ها و بررسی‌های اولیه استفاده کنید. وقتی نتیجه باید تغییرات در حافظه را منعکس کند یا نیاز به تأیید محتوای واقعی ارائه دارید، ارائه را بارگذاری و مدل شیء زنده آن را بازرسی کنید.

## **به‌روزرسانی ویژگی‌های ارائه**

ویژگی‌هایی که توسط [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#readDocumentProperties) بازگردانده می‌شوند، می‌توانند بدون ایجاد یک شیء [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) نیز تغییر کنند. تغییرات را با [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) اعمال کرده و سپس ارائه وابسته را با [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) بنویسید.

تصویر زیر ویژگی‌های سند اصلی ارائه PowerPoint را نشان می‌دهد.

![ویژگی‌های سند اصلی ارائه PowerPoint](input_properties.png)

مثال زیر عنوان و زمان آخرین ذخیره را تغییر می‌دهد و نتیجه را در فایلی جدید می‌نویسد:

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

تصویر زیر ویژگی‌های سند به‌روزرسانی‌شده را نشان می‌دهد.

![ویژگی‌های سند به‌روزرسانی‌شده ارائه PowerPoint](output_properties.png)

## **پیوندهای مفید**

برای بررسی‌های امنیتی مرتبط و تنظیمات حفاظت، به مقالات زیر مراجعه کنید:

- [Password-Protect Presentations](/slides/fa/python-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/fa/python-java/write-protected-presentation/)

## **سوالات متداول**

**چگونه می‌توانم بررسی کنم که آیا قلم‌ها جاسازی شده‌اند و کدام‌ها هستند؟**

ارائه را بارگذاری کنید و از [Presentation.getFontsManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getFontsManager) استفاده کنید. با فراخوانی [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) قلم‌های جاسازی‌شده را دریافت کنید و با [FontsManager.getFonts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/#getFonts) قلم‌های استفاده‌شده در ارائه را بگیرید. دو نتیجه را مقایسه کنید تا قلم‌هایی را که برای رندر لازم هستند ولی جاسازی نشده‌اند، پیدا کنید.

**چگونه می‌توانم به‌سرعت بفهمم فایل اسلایدهای پنهان دارد و چقدر؟**

وقتی متادیتای ذخیره‌شده سند کافی باشد، از [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getHiddenSlides) از طریق [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationfactory/#getPresentationInfo) و [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#readDocumentProperties) بخوانید. این برای موجودی سبک مناسب است. اگر ارائه در حافظه اصلاح شده باشد، ممکن است متادیتای ذخیره‌شده مفقود یا منسوخ باشد یا نیاز به تأیید مقادیر زنده داشته باشید؛ در این صورت از [Presentation.getSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSlides) پیمایش کنید و برای هر اسلاید متد [Slide.getHidden](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getHidden) را بررسی کنید.

**آیا می‌توانم تشخیص دهم که اندازه و جهت سفارشی اسلاید استفاده شده است و آیا با پیش‌فرض‌ها متفاوت است؟**

بله. ارائه را بارگذاری کنید و متد [Presentation.getSlideSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSlideSize) را فراخوانی کنید. با استفاده از [SlideSize.getType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesize/#getType)، [SlideSize.getSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesize/#getSize) و [SlideSize.getOrientation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesize/#getOrientation) تنظیمات فعلی را با پیش‌تنظیمات و ابعاد پیش‌فرض مقایسه کنید.

**آیا راه سریع برای دیدن این که نمودارها به منابع داده خارجی ارجاع می‌دهند وجود دارد؟**

بله. هر [Chart](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/) را پیدا کنید و متد [ChartData.getDataSourceType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#getDataSourceType) را فراخوانی کنید. برای یک کارنامه خارجی، متد [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) را فراخوانی کنید. نوع منبع داده و مسیر یک ارجاع خارجی را شناسایی می‌کند، اما تأیید در دسترس بودن هدف نیاز به بررسی منبع جداگانه دارد.

**چگونه می‌توانم اسلایدهای «سنگین» که ممکن است رندر یا خروجی PDF را کند کنند ارزیابی کنم؟**

هیچ ویژگی پیچیدگی واحدی وجود ندارد. با پیمایش [Presentation.getSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSlides) و مجموعه [BaseSlide.getShapes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/#getShapes) هر اسلاید، از شمارش اشکال و وجود تصاویر بزرگ، افکت‌ها، انیمیشن‌ها یا چندرسانه‌ای به‌عنوان نشانه‌های فیلتر استفاده کنید و یک رندر یا خروجی نماینده را اندازه‌گیری کنید قبل از اینکه اسلاید را به‌عنوان یک گلوگاه عملکردی تأیید کنید.