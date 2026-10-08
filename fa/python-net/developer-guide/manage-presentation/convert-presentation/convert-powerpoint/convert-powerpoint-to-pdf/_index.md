---
title: "تبدیل PPT & PPTX به PDF در Python | گزینه‌های پیشرفته"
linktitle: "PowerPoint به PDF"
type: docs
weight: 40
url: /fa/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
- "تبدیل PowerPoint"
- "ارائه"
- "PowerPoint به PDF"
- "PPT به PDF"
- "PPTX به PDF"
- "ذخیره PowerPoint به عنوان PDF"
- "پیوست"
- "PDF/A1a"
- "PDF/A1b"
- "PDF/UA"
- "Python"
- "Aspose.Slides برای Python"
description: "راهنمای گام به گام برای تبدیل PPT، PPTX و ODP به PDFهای با کیفیت بالا و سازگار با WCAG در Python با Aspose.Slides—شامل حفاظت با رمز عبور، انتخاب اسلایدها و کنترل کیفیت تصویر."
showReadingTime: true
---
## **مروری کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP) به فرمت PDF در پایتون مزایای متعددی دارد، از جمله اطمینان از سازگاری در دستگاه‌های مختلف و حفظ طرح‌بندی و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای مخفی را شامل شوید، اسناد PDF را با رمز عبور محافظت کنید، تعویض فونت‌ها را شناسایی کنید، اسلایدهای خاصی را برای تبدیل انتخاب کنید، و استانداردهای انطباق را بر اسناد خروجی اعمال کنید.

## **تبدیل‌های PowerPoint به PDF**

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF در پایتون، کافی است نام فایل را به عنوان آرگومان به کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) پاس دهید و سپس با استفاده از متد [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) ارائه را به‌صورت PDF ذخیره کنید. کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) متد [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) را در اختیار می‌گذارد که معمولاً برای تبدیل یک ارائه به PDF استفاده می‌شود.

{{% alert color="info" title="Note" %}}
Aspose.Slides برای پایتون اطلاعات API و شماره نسخه خود را در اسناد خروجی درج می‌کند. به عنوان مثال، هنگامی که یک ارائه را به PDF تبدیل می‌کند، Aspose.Slides برای پایتون فیلد Application را با مقدار '*Aspose.Slides*' و فیلد PDF Producer را با مقداری به شکل '*Aspose.Slides v XX.XX*' پر می‌کند. **Note** اینکه شما نمی‌توانید Aspose.Slides برای پایتون را مجبور کنید این اطلاعات را در اسناد خروجی تغییر یا حذف کند.
{{% /alert %}}

Aspose.Slides به شما اجازه می‌دهد تا:

* کل ارائه‌ها را به PDF تبدیل کنید
* اسلایدهای خاصی در یک ارائه را به PDF تبدیل کنید

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و محتوای PDF‌های حاصل را بسیار نزدیک به ارائه‌های اصلی نگه می‌دارد. عناصر و ویژگی‌ها به‌دقت در تبدیل رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و شکل‌ها
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندها
* سرصفحه و پاصفحه
* نقطه‌گذاری
* جدول‌ها

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائه ارائه‌شده را به PDF با تنظیمات بهینه و در بالاترین سطوح کیفیت تبدیل کند.

مثال زیر یک ارائه را بارگذاری می‌کند و تمام اسلایدهای قابل مشاهده را با استفاده از تنظیمات پیش‌فرض خروجی به PDF ذخیره می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose یک مبدل آنلاین رایگان [**مبدل PowerPoint به PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. برای پیاده‌سازی زنده این روش توصیف‌شده در اینجا، می‌توانید با مبدل یک آزمون انجام دهید.
{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—خصوصیات زیر کلاس [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—را فراهم می‌کند که به شما اجازه می‌دهد PDF حاصل از فرآیند تبدیل را سفارشی کنید، PDF را با رمز عبور قفل کنید، یا حتی نحوه اجرای فرآیند تبدیل را تعیین کنید.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های تبدیل سفارشی، می‌توانید تنظیم کیفیت دلخواه خود برای تصاویر رستر، نحوه پردازش متافایل‌ها، سطح فشرده‌سازی متن، DPI تصاویر و موارد دیگر را تنظیم کنید.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.jpeg_quality = 90
pdf_options.sufficient_resolution = 300
pdf_options.save_metafiles_as_png = True
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE
pdf_options.compliance = slides.export.PdfCompliance.PDF15

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **حفظ فایل‌های OLE نهفته به‌عنوان پیوست‌های PDF**

اگر یک ارائه حاوی کتاب کار Excel نهفته باشد، ممکن است بخواهید دریافت‌کنندگان PDF به داده‌های کتاب کار دسترسی داشته باشند و اسلایدها را نیز ببینند. برای حفظ فایل‌های OLE نهفته به‌عنوان پیوست‌ها در PDF حاصل، [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) را به `True` تنظیم کنید.

مقدار پیش‌فرض `False` است: تصویر پیش‌نمایش یا آیکون شیء OLE بر روی صفحه PDF رندر می‌شود، اما فایل نهفته به‌عنوان پیوست شامل نمی‌شود. تنظیم این گزینه به `True` علاوه بر آن داده فایل را نیز شامل می‌شود. پیش‌نمایش به‌عنوان نمایش تصویری باقی می‌ماند؛ پیوست به دریافت‌کنندگان امکان می‌دهد فایل نهفته را جداگانه باز یا ذخیره کنند. شیء OLE تبدیل به یک برگه کار تعاملی Excel در صفحه PDF نمی‌شود.

مثال زیر یک ارائه را که قبلاً شامل کتاب کار Excel نهفته است بارگذاری می‌کند و آن را به PDF با پیوست کتاب کار صادر می‌کند.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

برای بررسی نتیجه:

1. PDF صادرشده را در یک نمایشگر که از پیوست‌های فایل پشتیبانی می‌کند، مانند Adobe Acrobat Reader، باز کنید.
2. پنل **Attachments** نمایشگر را باز کنید و کتاب کار نهفته را پیدا کنید.
3. پیوست را ذخیره کرده و در Excel باز کنید تا داده‌های آن را بررسی کنید، یا اگر نمایشگر اجازه دهد مستقیماً باز کنید. پیش‌نمایش در صفحه PDF جدا از پیوست است.

{{% alert color="info" title="Note" %}}
استانداردهای PDF/A محدودیت‌هایی برای پیوست‌ها اعمال می‌کنند: PDF/A-1 فایل‌های نهفته را ممنوع می‌کند، PDF/A-2 فقط پیوست‌های PDF/A را اجازه می‌دهد، و PDF/A-3 انواع دیگر فایل‌ها از جمله کتاب‌های کار Excel را مجاز می‌داند. این‌ها الزامات استانداردها هستند و نه محدودیت‌های خاص Aspose.Slides. این مثال از تنظیم پیش‌فرض انطباق PDF استفاده می‌کند و خروجی PDF/A را نشان نمی‌دهد.
{{% /alert %}}

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر یک ارائه شامل اسلایدهای مخفی باشد، می‌توانید از گزینه سفارشی—خاصیت [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) از کلاس [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—استفاده کنید تا Aspose.Slides را هدایت کنید اسلایدهای مخفی را به‌عنوان صفحات در PDF حاصل شامل کند.

مثال زیر یک ارائه را به PDF صادر می‌کند که اسلایدهای مخفی را نیز شامل می‌شود.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **تبدیل PowerPoint به PDF حفاظت‌شده با رمز عبور**

مثال زیر یک ارائه را به PDF صادر می‌کند که برای باز شدن به رمز عبور `password` نیاز دارد. مجوزهای دسترسی چاپ، از جمله چاپ با کیفیت بالا، را مجاز می‌سازند.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **مدیریت فونت‌ها بدون نوع بولد اختصاصی**

یک ارائه می‌تواند قالب‌بندی بولد را بر روی متن اعمال کند حتی اگر فونت آن نوع بولد اختصاصی نداشته باشد. متن می‌تواند از طریق بولدسازی مصنوعی که گلیف‌های معمولی را به‌صورت مصنوعی ضخیم می‌کند، بولد به‌نظر برسد. وقتی این متن بیش از حد سنگین به‌نظر می‌رسد یا از ظاهر موردنظر در PDF متفاوت است، سعی کنید [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) را به `True` تنظیم کنید. این گزینه متن تحت تأثیر را به‌عنوان یک بیت‌مپ هنگام خروجی PDF رندر می‌کند و می‌تواند ظاهر آن را برای برخی فونت‌ها بهبود بخشد. مقدار پیش‌فرض آن `False` است.

نمایش نمونه شامل دو جعبه متن است: یکی با متن عادی و دیگری با قالب‌بندی بولد اعمال‌شده بر همان فونت که نوع بولد اختصاصی ندارد. مثال زیر ارائه را بارگذاری می‌کند، رسترسازی سبک‌های فونت پشتیبانی‌نشده را فعال می‌کند و آن را به PDF صادر می‌نماید:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

پیشنمایش‌های زیر خروجی غیرفعال و فعال را نشان می‌دهند. در این مثال، متن بولد با گزینه غیرفعال خطوط ضخیم‌تری دارد. با فعال‌کردن گزینه، خطوط آن سبک‌تر می‌شوند؛ متن عادی بدون تغییر باقی می‌ماند. قبل از انتخاب تنظیم برای ارائه خود، نتایج را مقایسه کنید.

| گزینه غیرفعال (`False`، پیش‌فرض) | گزینه فعال (`True`) |
|---|---|
| ![PDF با رسترسازی سبک فونت پشتیبانی‌نشده غیرفعال](unsupported-bold-disabled.png) | ![PDF با رسترسازی سبک فونت پشتیبانی‌نشده فعال](unsupported-bold-enabled.png) |

در این مثال، فعال‌سازی گزینه فقط متن بولد را به بیت‌مپ تبدیل می‌کند: این متن نمی‌تواند بدون OCR انتخاب، کپی یا جستجو شود و لبه‌های آن در زوم 800٪ نرم‌تر به‌نظر می‌رسند. متن عادی همچنان قابل جستجو می‌ماند. با غیرفعال‌کردن گزینه، هر دو رشته به‌عنوان متن باقی می‌مانند.

این گزینه متن قالب‌بندی‌شده به‌صورت بولد را زمانی که فونت آن نوع بولد اختصاصی ندارد، رستر می‌کند. [Font substitution](/slides/fa/python-net/font-substitution/) به‌جای آن زمانی که فونت اصلی در دسترس نباشد، فونت دیگری را انتخاب می‌کند.

## **تبدیل اسلایدهای انتخاب‌شده در PowerPoint به PDF**

مثال زیر اسلایدهای 1 و 3 را از یک ارائه به PDF صادر می‌کند. اعداد اسلایدها در این آرایه از 1 شروع می‌شوند و ارائه ورودی باید حداقل سه اسلاید داشته باشد.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **تبدیل PowerPoint به PDF با اندازه اسلاید سفارشی**

مثال زیر اسلاید اول را از یک ارائه به یک ارائه جدید با اندازه اسلاید 612 × 792 نقطه (8.5 × 11 اینچ) کپی می‌کند. محتوای اسلاید را برای جابه‌جایی مقیاس می‌دهد و اسلاید منفرد را به PDF صادر می‌کند.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # حذف اسلاید خالی که ارائه جدید با آن ساخته شد.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **تبدیل PowerPoint به PDF در نمای اسلایدهای یادداشت‌ها**

مثال زیر یک ارائه را به PDF صادر می‌کند به‌طوری که یادداشت‌های سخنران هر اسلاید زیر اسلاید قرار می‌گیرد. برای دیدن نتیجه، از ارائه‌ای حاوی یادداشت‌های سخنران استفاده کنید.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **استانداردهای دسترسی‌پذیری و انطباق برای PDF**

Aspose.Slides به شما اجازه می‌دهد از یک روش تبدیل استفاده کنید که با [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار است. می‌توانید یک سند PowerPoint را به PDF با استفاده از هر یک از این استانداردهای انطباق صادر کنید: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد پایتون یک عملیات تبدیل PowerPoint به PDF را نشان می‌دهد که در آن چندین PDF بر اساس استانداردهای انطباق مختلف به‌دست می‌آیند:

```python
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

options = slides.export.PdfOptions()

options.compliance = slides.export.PdfCompliance.PDF_A1A
pres.save("pres-a1a-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_A1B
pres.save("pres-a1b-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_UA
pres.save("pres-ua-compliance.pdf", slides.export.SaveFormat.PDF, options)
```

{{% alert color="info" title="Note" %}}
پشتیبانی Aspose.Slides برای عملیات تبدیل PDF به شما اجازه می‌دهد PDF را به محبوب‌ترین فرمت‌های فایل تبدیل کنید. می‌توانید تبدیل‌های [PDF به HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/)، [PDF به تصویر](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/)، [PDF به JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/) و [PDF به PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) را انجام دهید. سایر عملیات تبدیل PDF به فرمت‌های تخصصی—[PDF به SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/)، [PDF به TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/) و [PDF به XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)—نیز پشتیبانی می‌شود.
{{% /alert %}}

> **Note:** هنگام صادر کردن به PDF/UA، Aspose.Slides گرافیک‌های پیچیده مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. عناصر مسیر فردی به‌عنوان محتوای جداگانه حفظ نمی‌شوند و ممکن است به‌عنوان اثرات جانبی علامت‌گذاری شوند؛ متن جایگزین فقط برای کل شکل ارائه می‌شود.

## **FAQ**

**آیا Aspose.Slides برای پایتون می‌تواند اطلاعات برنامه را از PDF حذف کند؟**  
خیر، Aspose.Slides برای پایتون به‌صورت خودکار اطلاعات API و شماره نسخه را در PDF خروجی درج می‌کند. این اطلاعات قابل تغییر یا حذف نیست.

**چگونه تنها اسلایدهای خاصی را در تبدیل PDF شامل کنم؟**  
می‌توانید شاخص‌های اسلایدی که می‌خواهید تبدیل کنید را با عبور یک آرایه از موقعیت‌های اسلاید به متد [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) مشخص کنید.

**آیا می‌توان در حین تبدیل، PDF را با رمز عبور محافظت کرد؟**  
بله، می‌توانید قبل از ذخیره‌سازی ارائه به‌عنوان PDF، رمز عبور تنظیم کرده و مجوزهای دسترسی را با استفاده از کلاس [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) تعریف کنید.

**آیا Aspose.Slides از تبدیل PDF به سایر فرمت‌ها پشتیبانی می‌کند؟**  
بله، Aspose.Slides از تبدیل PDF به فرمت‌هایی مانند HTML، فرمت‌های تصویری (JPG، PNG)، SVG، TIFF و XML پشتیبانی می‌کند.

**چگونه می‌توانم اطمینان حاصل کنم که PDF من با استانداردهای دسترسی‌پذیری مطابقت دارد؟**  
ویژگی [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) را در [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) به استانداردهایی مانند `PDF_A1A`، `PDF_A1B` یا `PDF_UA` تنظیم کنید تا از انطباق با راهنمایی‌های دسترسی‌پذیری اطمینان حاصل کنید.

**آیا می‌توانم اسلایدهای مخفی را در خروجی PDF شامل کنم؟**  
بله، با تنظیم ویژگی [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) در [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) به `True`، اسلایدهای مخفی در PDF گنجانده می‌شوند.

**چگونه کیفیت و وضوح تصویر را در حین تبدیل تنظیم کنم؟**  
از ویژگی‌های [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) و [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) در [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) برای کنترل کیفیت تصویر و وضوح در PDF حاصل استفاده کنید.

**آیا Aspose.Slides به‌طور خودکار تعویض فونت‌ها را مدیریت می‌کند؟**  
Aspose.Slides تعویض‌های فونت را در حین تبدیل شناسایی می‌کند و می‌توانید آنها را با استفاده از ویژگی `warning_callback` در `SaveOptions` (در حال حاضر محدود) مدیریت کنید.

## **منابع اضافی**

- [مستندات Aspose.Slides برای پایتون از طریق .NET](/slides/fa/python-net/)
- [مرجع API Aspose.Slides](https://reference.aspose.com/slides/python-net/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/conversion)