---
title: بازیابی و به‌روزرسانی اطلاعات ارائه در پایتون
linktitle: اطلاعات ارائه
type: docs
weight: 30
url: /fa/python-net/examine-presentation/
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
- پاورپوینت
- اسناد باز
- ارائه
- پایتون
- Aspose.Slides
description: "با استفاده از پایتون، اسلایدها، ساختار و متادیتا در ارائه‌های پاورپوینت و اسناد باز را بررسی کنید تا بینش‌های سریع‌تری به دست آورده و ارزیابی‌های محتوا هوشمندانه‌تری انجام دهید."
---
## **مروری کلی**

Aspose.Slides می‌تواند فرمت یک ارائه را شناسایی کرده و متادیتای سند آن را بدون ایجاد یک مدل شیء کامل ارائه بخواند. این مورد زمانی مفید است که نیاز به طبقه‌بندی فایل‌ها، ساخت موجودی یا بررسی خصوصیات قبل از تصمیم‌گیری برای بارگذاری و پردازش محتویات ارائه داشته باشید.

این مقاله با استفاده از [PresentationFactory](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationfactory/) و [PresentationInfo](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/) بازرسی سبک را نشان می‌دهد و همچنین به‌روزرسانی هدفمند را از طریق [DocumentProperties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/) ارائه می‌کند.

## **بررسی فرمت ارائه**

از [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationfactory/get_presentation_info/) برای بازرسی یک فایل بدون ایجاد یک نمونه‌ی [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) استفاده کنید. ویژگی [PresentationInfo.load_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/load_format/) فرمت شناسایی‌شده را گزارش می‌دهد، مانند PPTX، PPT یا ODP.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **ساخت یک موجودی سبک از ارائه‌ها**

هنگامی که تعداد زیادی فایل ارائه را پردازش می‌کنید، ممکن است به یک موجودی فشرده برای اعتبارسنجی، ایندکس‌گذاری یا یک سیستم مدیریت سند نیاز داشته باشید. در این سناریو، از [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationfactory/get_presentation_info/) برای دریافت یک شیء [PresentationInfo](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/) استفاده کنید و سپس [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/read_document_properties/) را فراخوانی کنید تا متادیتای سند را بخوانید. این روش یک نمونه‌ی [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد نمی‌کند و نیازی به پیمایش کامل مدل شیء ارائه ندارید.

خواص گسترش‌یافته‌ای که توسط [DocumentProperties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/) ارائه می‌شود، مقادیر موجودی زیر را فراهم می‌کند:

| ویژگی | مقدار موجودی |
| --- | --- |
| [slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/slides/fa/) | تعداد کل اسلایدها. |
| [hidden_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/hidden_slides/) | تعداد اسلایدهای پنهان. |
| [notes](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/notes/) | تعداد اسلایدهایی که حاوی یادداشت هستند. |
| [paragraphs](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/paragraphs/) | تعداد کل پاراگراف‌ها، در صورت موجود بودن. |
| [words](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/words/) | تعداد کل واژگان. |
| [multimedia_clips](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/multimedia_clips/) | تعداد کل کلیپ‌های صوتی و تصویری. |

مثال زیر این مقادیر را بدون ایجاد یک شیء [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) می‌خواند و موجودی فشرده‌ای چاپ می‌کند. همچنین [heading_pairs](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/heading_pairs/) را با [titles_of_parts](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/titles_of_parts/) ترکیب می‌کند تا گروه‌های محتوا مانند قلم‌ها، تم‌ها و عناوین اسلایدها را نشان دهد.

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

هر [HeadingPair](https://reference.aspose.com/slides/fa/python-net/aspose.slides/headingpair/) یک نام گروه و تعداد موارد در آن گروه را فراهم می‌کند. [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/titles_of_parts/) یک مجموعهٔ صاف و مرتب است، بنابراین تعداد عناوین متوالی مشخص‌شده توسط هر جفت سرصفحه را مصرف کنید.

### **متاداده ذخیره‌شده و محدودیت‌های فرمت**

خواص موجودی که توسط [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/read_document_properties/) بازگردانده می‌شود، متادیتای موجود در سند منبع را نشان می‌دهد. Aspose.Slides برای این فراخوانی مدل شیء ارائه را بارگذاری و پیمایش نمی‌کند تا این مقادیر را دوباره محاسبه کند. خواص گمشده با مقادیر پیش‌فرض نشان داده می‌شوند و مقادیر ذخیره‌شده ممکن است منسوخ شوند اگر برنامه‌ای که آخرین بار فایل را ذخیره کرده باشد، خواص سند را به‌روزرسانی نکرده باشد.

- **PPTX:** این فرمت خواص سند گسترش‌یافته برای تعداد اسلایدها، یادداشت‌ها، اسلایدهای مخفی، پاراگراف‌ها، واژگان و چندرسانه‌ها، همچنین جفت‌های سرصفحه و عناوین بخش‌ها را فراهم می‌کند. در دسترس بودن آن بستگی به این دارد که کدام خواص توسط تولیدکننده سند نوشته شده‌اند.
- **PPT:** فرمت باینری می‌تواند خواص خلاصه‌سندی سند متناظر را ذخیره کند. اگر یک خاصیت غایب باشد یا توسط تولیدکننده سند به‌روزرسانی نشده باشد، Aspose.Slides مقدار ذخیره‌شده یا پیش‌فرض آن را برمی‌گرداند به‌جای اینکه از اسلایدها محاسبه کند.
- **ODP:** متادیتای OpenDocument آمار کلی سند مانند شمارش صفحات، پاراگراف‌ها و واژگان را فراهم می‌کند، اما این مقادیر به هر خاصیت گسترش‌یافتهٔ خاص PowerPoint نگاشت نمی‌شوند. متادیتای اسلایدهای مخفی، اسلایدهای یادداشت، چندرسانه‌ای، جفت سرصفحه و عنوان بخش ممکن است در دسترس نباشد و خواص موجودی ممکن است مقادیر پیش‌فرض را برگردانند. مقدار صفر یا مجموعه خالی را به‌عنوان اثبات قطعی عدم وجود محتوا در نظر نگیرید.

از روش متادیتای سبک برای موجودی‌ها و بررسی‌های اولیه استفاده کنید. وقتی که نتیجه باید تغییرات در‑حافظه را منعکس کند یا نیاز به تأیید محتویات واقعی ارائه دارید، ارائه را بارگذاری و مدل شیء زندهٔ آن را بازرسی کنید.

## **به‌روزرسانی ویژگی‌های ارائه**

خواص بازگردانده‌شده توسط [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/read_document_properties/) می‌توانند بدون ایجاد یک نمونه‌ی [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) نیز تغییر یابند. تغییرات را با [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/update_document_properties/) اعمال کنید و سپس ارائهٔ بایند‌شده را با [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/write_binded_presentation/) بنویسید.

تصویر زیر ویژگی‌های سند اصلی ارائه پاورپوینت را نشان می‌دهد.

![ویژگی‌های سند اصلی ارائه پاورپوینت](input_properties.png)

مثال زیر عنوان و زمان آخرین ذخیره‌سازی را تغییر می‌دهد و نتیجه را در فایل جدیدی می‌نویسد:

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

تصویر زیر ویژگی‌های سند به‌روزرسانی‌شده را نشان می‌دهد.

![ویژگی‌های سند تغییر‌یافتهٔ ارائه پاورپوینت](output_properties.png)

## **لینک‌های مفید**

برای بررسی‌های امنیتی مرتبط و تنظیمات حفاظت، به مقالات زیر مراجعه کنید:

- [Password‑Protect Presentations](/slides/fa/python-net/password-protected-presentation/)
- [Write‑Protect Presentations](/slides/fa/python-net/write-protected-presentation/)

## **پرسش‌های متداول**

**چگونه می‌توانم بررسی کنم که آیا قلم‌ها جاسازی شده‌اند و کدام‌ها؟**

ارائه را بارگذاری کنید و از [Presentation.fonts_manager](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/fonts_manager/) استفاده کنید. با فراخوانی [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) قلم‌های جاسازی‌شده را به‌دست آورید و با [FontsManager.get_fonts](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/get_fonts/) قلم‌های مورد استفاده توسط ارائه را دریافت کنید. دو نتیجه را مقایسه کنید تا قلم‌های مورد نیاز برای رندر ولی جاسازی‌نشده را پیدا کنید.

**چگونه می‌توانم سریعاً تشخیص دهم که آیا فایل اسلایدهای مخفی دارد و تعداد آنها چقدر است؟**

زمانی که متادیتای ذخیره‌شدهٔ سند کافی باشد، [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/hidden_slides/) را از طریق [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationfactory/get_presentation_info/) و [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/read_document_properties/) بخوانید. این برای یک موجودی سبک مناسب است. اگر ارائه در حافظه‌ تغییر کرده باشد، متادیتای ذخیره‌شده ممکن است گمشده یا منسوخ باشد و یا نیاز به تأیید مقادیر زنده داشته باشید؛ در این صورت از طریق [Presentation.slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/slides/fa/) پیمایش کنید و ویژگی [Slide.hidden](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/hidden/) هر اسلاید را بررسی کنید.

**آیا می‌توانم تشخیص دهم که آیا اندازه و جهت سفارشی اسلاید استفاده شده است و آیا با پیش‌فرض‌ها متفاوت است؟**

بله. ارائه را بارگذاری کنید و [Presentation.slide_size](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/slide_size/) را بخوانید. ویژگی‌های [SlideSize.type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidesize/type/)، [SlideSize.size](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidesize/size/) و [SlideSize.orientation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidesize/orientation/) را بررسی کنید تا تنظیمات جاری را با پیش‌فرض‌های انتظار‌داشته‌شده مقایسه کنید.

**آیا راهی سریع برای دیدن این‌که آیا نمودارها به منابع داده خارجی ارجاع می‌دهند وجود دارد؟**

بله. هر [Chart](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/) را پیدا کنید و ویژگی [ChartData.data_source_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/data_source_type/) را بررسی کنید. برای یک کتاب‌کار خارجی، [ChartData.external_workbook_path](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdata/external_workbook_path/) را بخوانید. نوع منبع داده و مسیر، ارجاع خارجی را شناسایی می‌کند، اما تأیید دسترس‌پذیری هدف نیاز به بررسی منبع جداگانه دارد.

**چگونه می‌توانم اسلایدهای «سنگین» را که ممکن است رندر یا خروجی PDF را کند کنند ارزیابی کنم؟**

هیچ خاصیت پیچیدگی واحدی وجود ندارد. از طریق [Presentation.slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/slides/fa/) و مجموعهٔ [BaseSlide.shapes](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseslide/shapes/) هر اسلاید پیمایش کنید. از تعداد اشکال و حضور تصاویر بزرگ، افکت‌ها، انیمیشن‌ها یا چندرسانه‌ها به‌عنوان سیگنال‌های غربالگری استفاده کنید و قبل از تصمیم‌گیری به‌عنوان یک گلوگاه تأییدشدهٔ عملکرد، یک رندر یا خروجی نمایشی نمونه‌گیری کنید.