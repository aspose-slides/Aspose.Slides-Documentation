---
title: دریافت و به‌روزرسانی اطلاعات ارائه در پایتون از طریق جاوا
linktitle: اطلاعات ارائه
type: docs
weight: 30
url: /fa/python-java/examine-presentation/
keywords:
- قالب ارائه
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
- Python
- Java
- Aspose.Slides
description: "اسلایدها، ساختار و متادیتا را در ارائه‌های PowerPoint و OpenDocument با استفاده از پایتون از طریق جاوا برای دریافت سریع‌تر بینش‌ها و ارزیابی محتوا هوشمندانه بررسی کنید."
---
## **نمای کلی**

Aspose.Slides می‌تواند قالب ارائه را شناسایی کند و متادیتای سند آن را بدون ایجاد یک مدل شیء کامل از ارائه بخواند. این کار وقتی مفید است که نیاز به طبقه‌بندی فایل‌ها، ساخت موجودی یا بررسی ویژگی‌ها قبل از تصمیم‌گیری برای بارگذاری و پردازش محتویات ارائه داشته باشید.

مثال‌ها به Aspose.Slides برای Python via Java و یک محیط اجرایی Java سازگار نیاز دارند. هر مثال در صورت عدم وجود JVM، آن را راه‌اندازی می‌کند. فایل‌های ارائه موجود را در مسیرهای مورد استفاده در مثال‌ها قرار دهید.

این مقاله بازبینی سبک‌وزن را از طریق [PresentationFactory](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationfactory/) و [PresentationInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/) و همچنین به‌روزرسانی‌های هدفمند از طریق [DocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/) نشان می‌دهد.

## **بررسی قالب یک ارائه**

از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationfactory/#getPresentationInfo) برای بازبینی یک فایل بدون ایجاد نمونه‌ای از [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) استفاده کنید. متد [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#getLoadFormat) قالب تشخیص داده شده را گزارش می‌کند، مانند PPTX، PPT یا ODP.

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

## **ساخت موجودی سبک‌وزن برای ارائه‌ها**

هنگامی که تعداد زیادی فایل ارائه را پردازش می‌کنید، ممکن است به یک موجودی فشرده برای اعتبارسنجی، نمایه‌سازی یا سامانه مدیریت اسناد نیاز داشته باشید. در این حالت، از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationfactory/#getPresentationInfo) برای دریافت شیء [PresentationInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/) استفاده کنید و سپس متد [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#readDocumentProperties) را فراخوانی کنید تا متادیتای سند را بخوانید. این روش نمونه‌ای از [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد نمی‌کند و نیازی به پیمایش کامل مدل شیء ارائه ندارد.

ویژگی‌های گسترش‌ یافته‌ای که توسط [DocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/) ارائه می‌شود، مقادیر موجودی زیر را فراهم می‌کند:

| Method | مقدار موجودی |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getSlides) | تعداد کل اسلایدها. |
| [getHiddenSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getHiddenSlides) | تعداد اسلایدهای پنهان. |
| [getNotes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getNotes) | تعداد اسلایدهایی که حاوی یادداشت هستند. |
| [getParagraphs](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getParagraphs) | کل تعداد پاراگراف‌ها، در صورت موجود بودن. |
| [getWords](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getWords) | کل تعداد کلمات. |
| [getMultimediaClips](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getMultimediaClips) | کل تعداد کلیپ‌های صوتی و تصویری. |

مثال زیر این مقادیر را بدون ایجاد شیء [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) می‌خواند و موجودی فشرده‌ای را چاپ می‌کند. همچنین با ترکیب [getHeadingPairs](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getHeadingPairs) و [getTitlesOfParts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getTitlesOfParts) گروه‌های محتوایی مانند قلم‌ها، تم‌ها و عناوین اسلایدها را نمایش می‌دهد.

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

هر [HeadingPair](https://reference.aspose.com/slides/fa/python-java/aspose.slides/headingpair/) یک نام گروه و تعداد موارد در آن گروه را فراهم می‌کند. متد [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getTitlesOfParts) یک آرایه مسطح و مرتب بر می‌گرداند، بنابراین تعداد عناوین متوالی مشخص شده توسط هر جفت سرعنوان را مصرف کنید.

### **متادیتای ذخیره‌شده و محدودیت‌های قالب**

ویژگی‌های موجودی که توسط [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#readDocumentProperties) بازگردانده می‌شوند، متادیتای موجود در سند اصلی را نشان می‌دهند. Aspose.Slides این ویژگی‌ها را با بارگذاری و پیمایش مدل شیء ارائه برای محاسبه مجدد مقدارها بازنگری نمی‌کند. ویژگی‌های گمشده با مقادیر پیش‌فرض نمایان می‌شوند و مقادیر ذخیره‌شده ممکن است منسوخ باشند اگر برنامه‌ای که آخرین بار فایل را ذخیره کرده است، ویژگی‌های سند را به‌روز نکرده باشد.

- **PPTX:** این قالب ویژگی‌های مستند گسترش‌یافته برای شمارش اسلاید، یادداشت، اسلایدهای پنهان، پاراگراف، کلمه و کلیپ‌های چند رسانه‌ای، همچنین جفت‌های سرعنوان و عناوین بخش‌ها را فراهم می‌کند. در دسترس بودن بستگی به این دارد که کدام ویژگی‌ها توسط تولیدکننده سند نوشته شده‌اند.
- **PPT:** قالب باینری می‌تواند ویژگی‌های خلاصه‌سندی سند مربوطه را ذخیره کند. اگر ویژگی‌ای موجود نباشد یا توسط تولیدکننده سند تازه‌سازی نشده باشد، Aspose.Slides مقدار ذخیره‌شده یا پیش‌فرض آن را برمی‌گرداند نه این‌که از اسلایدها محاسبه کند.
- **ODP:** متادیتای OpenDocument آمار عمومی سند مانند شمارش صفحه، پاراگراف و کلمه را ارائه می‌دهد، اما این مقادیر به هر ویژگی گسترش‌یافته خاص PowerPoint نگاشته نمی‌شوند. متادیتای اسلایدهای پنهان، اسلایدهای یادداشت، چندرسانه‌ای، جفت‌های سرعنوان و عناوین بخش ممکن است در دسترس نباشند و ویژگی‌های موجودی ممکن است مقادیر پیش‌فرض برگردانند. صفر بودن مقدار یا آرایه خالی را به‌عنوان اثبات قطعی عدم وجود محتوا در نظر نگیرید.

از روش متادیتای سبک‌وزن برای موجودی‌ها و بررسی‌های اولیه استفاده کنید. وقتی نتیجه باید تغییرات در حافظه را منعکس کند یا نیاز به تأیید محتوای واقعی ارائه دارید، ارائه را بارگذاری کرده و مدل شیء زنده آن را بازبینی کنید.

## **به‌روزرسانی ویژگی‌های ارائه**

ویژگی‌هایی که توسط [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#readDocumentProperties) بازگردانده می‌شوند، می‌توانند بدون ایجاد یک نمونه از [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) نیز تغییر یابند. تغییرات را با [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) اعمال کنید و سپس ارائه باند دار را با [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) بنویسید.

تصویر زیر ویژگی‌های سند اصلی ارائه PowerPoint را نشان می‌دهد.

![Original document properties of the PowerPoint presentation](input_properties.png)

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

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **پیوندهای مفید**

برای بررسی‌های امنیتی مرتبط و تنظیمات حفاظت، به مقالات زیر مراجعه کنید:

- [Password-Protect Presentations](/slides/fa/python-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/fa/python-java/write-protected-presentation/)

## **سوالات متداول**

**چگونه می‌توانم بررسی کنم که آیا قلم‌ها جاسازی شده‌اند و کدام‌ها هستند؟**

ارائه را بارگذاری کنید و از [Presentation.getFontsManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getFontsManager) استفاده کنید. با فراخوانی [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) قلم‌های جاسازی‌شده و با [FontsManager.getFonts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/#getFonts) قلم‌های استفاده‌شده در ارائه را به‌دست آورید. دو نتیجه را مقایسه کنید تا قلم‌های موردنیاز برای رندر اما غیرجاسازی‌شده را پیدا کنید.

**چگونه می‌توانم سریعاً بفهمم آیا فایل اسلایدهای پنهان دارد و چند تا؟**

هنگامی که متادیتای ذخیره‌شده سند کافی باشد، [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getHiddenSlides) را از طریق [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationfactory/#getPresentationInfo) و [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#readDocumentProperties) بخوانید. این روش برای موجودی سبک‌وزن مناسب است. اگر ارائه در حافظه تغییر کرده باشد یا متادیتا ممکن است مفقود یا منسوخ باشد و نیاز به تأیید مقادیر زنده داشته باشید، به جای آن از [Presentation.getSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSlides) پیمایش کنید و برای هر اسلاید متد [Slide.getHidden](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getHidden) را بررسی کنید.

**آیا می‌توانم تشخیص دهم که آیا اندازه و جهت سفارشی اسلاید استفاده شده است و آیا با پیش‌فرض‌ها متفاوت است؟**

بله. ارائه را بارگذاری کنید و متد [Presentation.getSlideSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSlideSize) را صدا بزنید. از [SlideSize.getType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesize/#getType)، [SlideSize.getSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesize/#getSize) و [SlideSize.getOrientation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesize/#getOrientation) برای مقایسه تنظیمات فعلی با پیش‌فرض‌های مورد انتظار و ابعاد استفاده کنید.

**آیا روش سریعی برای مشاهده این که نمودارها به منابع داده خارجی ارجاع می‌دهند وجود دارد؟**

بله. هر [Chart](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/) را پیدا کنید و متد [ChartData.getDataSourceType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#getDataSourceType) را فراخوانی کنید. برای یک کتاب‌کار خارجی، [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) را صدا بزنید. نوع منبع داده و مسیر یک ارجاع خارجی را نشان می‌دهند، اما تأیید در دسترس بودن هدف نیاز به بررسی منبع جداگانه دارد.

**چگونه می‌توانم اسلایدهای «سنگین» که ممکن است رندر یا خروجی PDF را کند کنند ارزیابی کنم؟**

هیچ ویژگی تک‌یکه‌ای برای پیچیدگی وجود ندارد. با پیمایش [Presentation.getSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSlides) و مجموعه [BaseSlide.getShapes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/#getShapes) هر اسلاید، تعداد اشکال و حضور تصاویر بزرگ، افکت‌ها، انیمیشن‌ها یا چندرسانه‌ای را به‌عنوان علائم فیلتر کنید و یک رندر یا خروجی نمونه‌برداری انجام دهید تا قبل از قطعیت به‌عنوان نقطه‌ی گرینهٔ عملکردی تأیید شود.