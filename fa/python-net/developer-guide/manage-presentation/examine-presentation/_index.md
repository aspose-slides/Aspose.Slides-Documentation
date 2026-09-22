---
title: دریافت و به‌روزرسانی اطلاعات ارائه با Python
linktitle: اطلاعات ارائه
type: docs
weight: 30
url: /fa/python-net/examine-presentation/
keywords:
- قالب ارائه
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
- پاورپوینت
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "با استفاده از Python، اسلایدها، ساختار و متادیتا را در ارائه‌های PowerPoint و OpenDocument بررسی کنید تا بینش‌های سریع‌تر و ارزیابی‌های محتوا هوشمندانه‌تری داشته باشید."
---
## **مرور کلی**

Aspose.Slides می‌تواند فرمت یک ارائه را شناسایی کرده و متادیتای سند آن را بدون ایجاد یک مدل کامل شیء ارائه بخواند. این زمانی مفید است که نیاز به طبقه‌بندی فایل‌ها، ساخت یک فهرست یا بررسی ویژگی‌ها قبل از تصمیم‌گیری برای بارگذاری و پردازش محتوای ارائه داشته باشید.

این مقاله با استفاده از [PresentationFactory](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationfactory/) و [PresentationInfo](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/) بررسی سبک وزن را نشان می‌دهد و همچنین به‌روزرسانی‌های هدفمند را از طریق [DocumentProperties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/) معرفی می‌کند.

## **بررسی فرمت یک ارائه**

اگر پیش از این یک ارائه بارگذاری شده دارید، برای تشخیص پس از بارگذاری و محدودیت‌های جریان‌های PPT، PPS و POT قدیمی، به مقاله [Determine the Original Presentation Format](/slides/fa/python-net/detect-presentation-source-format/) مراجعه کنید.

از [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationfactory/get_presentation_info/) برای بررسی یک فایل بدون ایجاد نمونه‌ای از [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) استفاده کنید. ویژگی [PresentationInfo.load_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/load_format/) فرمت شناسایی‌شده را گزارش می‌دهد، مانند PPTX، PPT یا ODP.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **ساخت فهرست سبک وزن از ارائه‌ها**

زمانی که تعداد زیادی فایل ارائه را پردازش می‌کنید، ممکن است به یک فهرست فشرده برای اعتبارسنجی، فهرست‌گذاری یا سیستم مدیریت اسناد نیاز داشته باشید. در این حالت، از [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationfactory/get_presentation_info/) برای دریافت یک شیء [PresentationInfo](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/) استفاده کنید و سپس با فراخوانی [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/read_document_properties/) متادیتای سند را بخوانید. این روش نمونه‌ای از [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد نمی‌کند و نیازی به پیمایش کل مدل شیء ارائه نیست.

خواص گسترش‌یافته‌ای که توسط [DocumentProperties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/) ارائه می‌شود، مقادیر فهرست زیر را فراهم می‌کند:

| Property | Inventory value |
| --- | --- |
| [slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/slides/fa/) | مجموع تعداد اسلایدها. |
| [hidden_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/hidden_slides/) | تعداد اسلایدهای مخفی. |
| [notes](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/notes/) | تعداد اسلایدهایی که حاوی یادداشت هستند. |
| [paragraphs](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/paragraphs/) | مجموع تعداد پاراگراف‌ها، در صورت موجود بودن. |
| [words](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/words/) | مجموع تعداد کلمات. |
| [multimedia_clips](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/multimedia_clips/) | مجموع تعداد کلیپ‌های صوتی و تصویری. |

مثال زیر این مقادیر را بدون ایجاد شیء [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) می‌خواند و فهرست فشرده‌ای را چاپ می‌کند. همچنین [heading_pairs](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/heading_pairs/) را با [titles_of_parts](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/titles_of_parts/) ترکیب می‌کند تا گروه‌های محتوا مانند قلم‌ها، تم‌ها و عناوین اسلاید را نمایش دهد.

```python
import os
import aspose.slides as slides

file_path = "sample.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)
document_properties = presentation_info.read_document_properties()

print(f"File: {os.path.basename(file_path)}")
print(f"Format: {presentation_info.load_format}")
print(f"Title: {document_properties.title}")
print(f"Author: {document_properties.author}")
print("Statistics:")
print(f"  Slides: {document_properties.slides}")
print(f"  Hidden slides: {document_properties.hidden_slides}")
print(f"  Slides with notes: {document_properties.notes}")
print(f"  Paragraphs: {document_properties.paragraphs}")
print(f"  Words: {document_properties.words}")
print(f"  Multimedia clips: {document_properties.multimedia_clips}")

heading_pairs = document_properties.heading_pairs or []
titles_of_parts = document_properties.titles_of_parts or []
part_index = 0

if not heading_pairs or not titles_of_parts:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.name} ({heading_pair.count})")

        for _ in range(heading_pair.count):
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

هر [HeadingPair](https://reference.aspose.com/slides/fa/python-net/aspose.slides/headingpair/) یک نام گروه و تعداد موارد در آن گروه را فراهم می‌کند. [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/titles_of_parts/) یک مجموعهٔ صاف و ترتیب‌دار است، بنابراین تعداد عناوین متوالی مشخص‌شده توسط هر جفت سرخط را مصرف کنید.

### **متادیتای ذخیره‌شده و محدودیت‌های فرمت**

خواص فهرست که توسط [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/read_document_properties/) بازگردانده می‌شوند، متادیتای موجود در سند منبع را نشان می‌دهند. Aspose.Slides برای این فراخوانی مدل شیء ارائه را بارگذاری و پیمایش نمی‌کند تا این مقادیر را دوباره محاسبه کند. خواص گم‌شده با مقدار پیش‌فرض نشان داده می‌شوند و مقادیر ذخیره‌شده ممکن است منسوخ باشند اگر برنامه‌ای که آخرین بار فایل را ذخیره کرده بود، خواص سند را به‌روزرسانی نکرده باشد.

- **PPTX:** این فرمت خواص سند گسترش‌یافته برای شمارش اسلاید، یادداشت، اسلاید مخفی، پاراگراف، کلمه و چندرسانه‌ای، همچنین جفت‌های سرخط و عناوین بخش را فراهم می‌کند. در دسترس بودن آن بستگی به این دارد که کدام خواص توسط تولیدکننده سند نوشته شده‌اند.
- **PPT:** فرمت باینری می‌تواند خواص خلاصه‌سند متناظر را ذخیره کند. اگر یک خاصیت غیربدسترس باشد یا توسط تولیدکننده سند به‌روزرسانی نشود، Aspose.Slides مقدار ذخیره‌شده یا پیش‌فرض آن را بر می‌گرداند نه این‌که از اسلایدها محاسبه کند.
- **ODP:** متادیتای OpenDocument آمار کلی سند مانند شمارش صفحات، پاراگراف و کلمه را ارائه می‌دهد، اما این مقادیر به تمام خواص گسترش‌یافته مخصوص PowerPoint نگاشت نمی‌شوند. متادیتای اسلاید مخفی، اسلاید یادداشت، چندرسانه‌ای، جفت سرخط و عنوان بخش ممکن است در دسترس نباشند و خواص فهرست ممکن است مقادیر پیش‌فرض برگردانند. صفر یا مجموعهٔ خالی را به‌عنوان اثبات قطعی عدم وجود محتوا در نظر نگیرید.

از رویکرد متادیتای سبک وزن برای فهرست‌ها و بررسی‌های اولیه استفاده کنید. هنگامی که نتیجه باید تغییرات حافظهٔ موقت را منعکس کند یا نیاز به تأیید محتوای واقعی ارائه دارید، ارائه را بارگذاری و مدل شیء زندهٔ آن را بررسی کنید.

## **به‌روزرسانی خواص ارائه**

خواص بازگشتی توسط [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/read_document_properties/) می‌توانند بدون ایجاد نمونه‌ای از [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) تغییر یابند. تغییرات را با [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/update_document_properties/) اعمال کنید و سپس ارائهٔ بایند شده را با [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/write_binded_presentation/) بنویسید.

تصویر زیر خواص سند اصلی ارائهٔ PowerPoint را نشان می‌دهد.

![Original document properties of the PowerPoint presentation](input_properties.png)

مثال زیر عنوان و زمان آخرین ذخیره‌سازی را تغییر می‌دهد و نتایج را در یک فایل جدید می‌نویسد:

```python
import datetime
import aspose.slides as slides

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(source_file)
document_properties = presentation_info.read_document_properties()

document_properties.title = "Quarterly sales report"
document_properties.last_saved_time = datetime.datetime.now(datetime.timezone.utc)

presentation_info.update_document_properties(document_properties)

with open(output_file, "wb") as output_stream:
    presentation_info.write_binded_presentation(output_stream)
```

تصویر زیر خواص سند به‌روز شدهٔ ارائهٔ PowerPoint را نشان می‌دهد.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **لینک‌های مفید**

برای بررسی‌های امنیتی مرتبط و تنظیمات حفاظت، مقالات زیر را ببینید:

- [Password-Protect Presentations](/slides/fa/python-net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/fa/python-net/write-protected-presentation/)

## **سؤالات متداول**

**چگونه می‌توانم بررسی کنم که آیا قلم‌ها جاسازی شده‌اند و کدام‌ها هستند؟**

ارائه را بارگذاری کنید و از [Presentation.fonts_manager](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/fonts_manager/) استفاده کنید. با فراخوانی [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) قلم‌های جاسازی‌شده را به‌دست آورید و با [FontsManager.get_fonts](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/get_fonts/) قلم‌های مورد استفاده در ارائه را دریافت کنید. دو نتیجه را مقایسه کنید تا قلم‌های موردنیاز برای رندر که جاسازی نشده‌اند را پیدا کنید.

**چگونه می‌توانم به‌سرعت بفهمم که فایل اسلایدهای مخفی دارد و تعداد آن‌ها چقدر است؟**

زمانی که متادیتای ذخیره‌شدهٔ سند کافی است، از [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/hidden_slides/) از طریق [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationfactory/get_presentation_info/) و [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/read_document_properties/) بخوانید. این برای فهرست سبک وزن مناسب است. اگر ارائه در حافظه تغییر کرده باشد، متادیتای ذخیره‌شده ممکن است گم یا منسوخ باشد یا نیاز به تأیید مقادیر زنده داشته باشید؛ در این صورت به‌جای آن، از طریق [Presentation.slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/slides/fa/) پیمایش کنید و ویژگی [Slide.hidden](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/hidden/) هر اسلاید را بررسی کنید.

**آیا می‌توانم تشخیص دهم که اندازه و جهت اسلاید سفارشی استفاده شده‌اند و آیا از پیش‌فرض‌ها متفاوت هستند؟**

بله. ارائه را بارگذاری کنید و [Presentation.slide_size](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/slide_size/) را بخوانید. با بررسی [SlideSize.type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidesize/type/)، [SlideSize.size](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidesize/size/) و [SlideSize.orientation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidesize/orientation/) تنظیمات فعلی را نسبت به پیش‌فرض‌ها مقایسه کنید.

**آیا راه سریعی برای مشاهده این‌که نمودارها به منابع دادهٔ خارجی ارجاع می‌دهند وجود دارد؟**

بله. هر [Chart](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/) را پیدا کنید و [ChartData.data_source_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/data_source_type/) را بررسی کنید. برای یک کتاب‌کار خارجی، [ChartData.external_workbook_path](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/external_workbook_path/) را بخوانید. نوع منبع داده و مسیر یک ارجاع خارجی را شناسایی می‌کند، اما تأیید دسترسی به هدف نیاز به بررسی منبع جداگانه دارد.

**چگونه می‌توانم اسلایدهای «سنگین» که ممکن است رندر یا خروجی PDF را کند کنند ارزیابی کنم؟**

خاصیت پیچیدگی واحدی وجود ندارد. [Presentation.slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/slides/fa/) و مجموعهٔ [BaseSlide.shapes](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseslide/shapes/) هر اسلاید را پیمایش کنید. از شمارش اشکال و وجود تصاویر بزرگ، افکت‌ها، انیمیشن‌ها یا چندرسانه‌ای‌ها به‌عنوان علائم فیلتر استفاده کنید و قبل از تصمیم‌گیری نهایی دربارهٔ یک اسلاید به‌عنوان گلوگاه عملکرد، یک رندر یا خروجی نمایشی نمونه‌برداری کنید.