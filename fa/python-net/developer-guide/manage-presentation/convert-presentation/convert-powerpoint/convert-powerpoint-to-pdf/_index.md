---
title: تبدیل PPT و PPTX به PDF در پایتون | گزینه‌های پیشرفته
linktitle: PowerPoint به PDF
type: docs
weight: 40
url: /fa/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
- تبدیل PowerPoint
- ارائه
- PowerPoint به PDF
- PPT به PDF
- PPTX به PDF
- ذخیره PowerPoint به عنوان PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides برای پایتون
description: "راهنمای گام به گام برای تبدیل PPT، PPTX و ODP به PDFهای با کیفیت بالا و سازگار با WCAG در پایتون با Aspose.Slides — شامل حفاظت با رمز عبور، انتخاب اسلاید و کنترل کیفیت تصویر."
showReadingTime: true
---
## **بررسی کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP) به قالب PDF در پایتون مزایای متعددی دارد، از جمله اطمینان از سازگاری در دستگاه‌های مختلف و حفظ طرح و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای پنهان را شامل کنید، اسناد PDF را با رمز عبور محافظت کنید، جایگزینی فونت‌ها را تشخیص دهید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای انطباق را بر اسناد خروجی اعمال کنید.

## **نصب**

```bash
pip install aspose.slides
```

این بسته زمان اجرای مورد نیاز خود را شامل می‌شود، بنابراین نیازی به نصب Microsoft PowerPoint بر روی ماشینی که تبدیل را انجام می‌دهد نیست.

## **تبدیل PowerPoint به PDF**

با استفاده از Aspose.Slides می‌توانید ارائه‌ها را در این فرمت‌ها به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF در پایتون، کافی است نام فایل را به عنوان آرگومان به کلاس [Presentation](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides/presentation/) بدهید و سپس با استفاده از متد [Save](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides/presentation/#methods) ارائه را به PDF ذخیره کنید. کلاس [Presentation](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides/presentation/) متد [Save](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides/presentation/#methods) را ارائه می‌دهد که معمولاً برای تبدیل یک ارائه به PDF استفاده می‌شود.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides برای پایتون به‌صورت مستقیم اطلاعات API و شماره نسخه را در اسناد خروجی می‌نویسد. به‌عنوان مثال، هنگام تبدیل یک ارائه به PDF، Aspose.Slides برای پایتون فیلد Application را با مقدار '*Aspose.Slides*' و فیلد PDF Producer را با مقداری به شکل '*Aspose.Slides v XX.XX*' پر می‌کند. **Note** اینکه شما نمی‌توانید Aspose.Slides برای پایتون را مجبور کنید این اطلاعات را در اسناد خروجی تغییر یا حذف کند.

{{% /alert %}}

Aspose.Slides به شما امکان تبدیل زیر را می‌دهد:

* کل ارائه‌ها به PDF
* اسلایدهای خاص در یک ارائه به PDF

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد محتویات PDFهای حاصل دقیقاً با ارائه‌های اصلی مطابقت داشته باشند. عناصر و ویژگی‌ها به‌دقت در تبدیل رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و اشکال
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندها
* سرصفحه‌ها و پاصفحه‌ها
* گلوله‌دارها
* جداول

## **تبدیل PowerPoint به PDF**

عملیات استاندارد تبدیل PowerPoint به PDF با استفاده از گزینه‌های پیش‌فرض اجرا می‌شود. در این حالت، Aspose.Slides سعی می‌کند ارائه‌ی داده‌شده را با تنظیمات بهینه و حداکثر کیفیت به PDF تبدیل کند. این کد پایتون نشان می‌دهد چگونه یک PowerPoint را به PDF تبدیل کنید:

_مراحل: تبدیل PowerPoint به PDF در پایتون_

- <a name="python-net-powerpoint-to-pdf"><strong>مراحل: تبدیل PowerPoint به PDF با استفاده از پایتون از طریق .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>مراحل: تبدیل PPT به PDF با استفاده از پایتون از طریق .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>مراحل: تبدیل PPTX به PDF با استفاده از پایتون از طریق .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>مراحل: تبدیل ODP به PDF با استفاده از پایتون از طریق .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>مراحل: تبدیل PPS به PDF با استفاده از پایتون از طریق .NET</a></strong>

_مراحل کد:_

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید و فایل PowerPoint را به آن بدهید.
  * پسوند _.ppt_ برای بارگذاری فایل **PPT** در داخل کلاس _Presentation_.
  * پسوند _.pptx_ برای بارگذاری فایل **PPTX** در داخل کلاس _Presentation_.
  * پسوند _.odp_ برای بارگذاری فایل **ODP** در داخل کلاس _Presentation_.
  * پسوند _.pps_ برای بارگذاری فایل **PPS** در داخل کلاس _Presentation_.
- با فراخوانی متد **Save** و استفاده از مقدار **SaveFormat.PDF**، _Presentation_ را به قالب **PDF** ذخیره کنید.

```python
import aspose.slides as slides

# یک شیء از کلاس Presentation که یک فایل PowerPoint را نشان می‌دهد
presentation = slides.Presentation("PowerPoint.ppt")

# ارائه را به صورت PDF ذخیره می‌کند
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose یک [**مبدل آنلاین رایگان PowerPoint به PDF**](https://products.aspose.app/slides/fa/conversion/ppt-to-pdf) ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. برای اجرای زندهٔ این روش می‌توانید با مبدل تست انجام دهید.

{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—ویژگی‌های موجود در کلاس [PdfOptions](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides.export/pdfoptions/)—را فراهم می‌کند تا بتوانید PDF حاصل از فرآیند تبدیل را شخصی‌سازی کنید، آن را با رمز عبور قفل کنید یا حتی نحوهٔ انجام فرآیند تبدیل را مشخص کنید.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی می‌توانید تنظیم کیفیت دلخواه خود برای تصاویر رستر، نحوهٔ پردازش متافایل‌ها، سطح فشرده‌سازی متن، DPI تصاویر و ... را تعیین کنید.

کد مثال زیر عملیاتی را نشان می‌دهد که در آن یک ارائه PowerPoint با چند گزینهٔ سفارشی به PDF تبدیل می‌شود:

```python
import aspose.slides as slides

# یک شیء از کلاس PdfOptions را می‌سازد
pdf_options = slides.export.PdfOptions()

# کیفیت تصاویر JPG را تنظیم می‌کند
pdf_options.jpeg_quality = 90

# DPI تصاویر را تنظیم می‌کند
pdf_options.sufficient_resolution = 300

# رفتار متافایل‌ها را تنظیم می‌کند
pdf_options.save_metafiles_as_png = True

# سطح فشرده‌سازی متن برای محتوای متنی را تنظیم می‌کند
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# حالت انطباق PDF را تعریف می‌کند
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# یک شیء از کلاس Presentation که یک سند PowerPoint را نشان می‌دهد را می‌سازد
with slides.Presentation("PowerPoint.pptx") as presentation:
    # ارائه را به عنوان یک سند PDF ذخیره می‌کند
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر یک ارائه شامل اسلایدهای مخفی باشد، می‌توانید از گزینهٔ سفارشی—ویژگی `show_hidden_slides` از کلاس [PdfOptions](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides.export/pdfoptions/)—استفاده کنید تا Aspose.Slides اسلایدهای مخفی را به عنوان صفحات در PDF نهایی شامل کند.

این کد پایتون نشان می‌دهد چگونه یک ارائه PowerPoint را به PDF با اسلایدهای مخفی شامل شده تبدیل کنید:

```python
import aspose.slides as slides

# یک شیء از کلاس Presentation که یک فایل PowerPoint را نشان می‌دهد را می‌سازد
presentation = slides.Presentation("PowerPoint.pptx")

# یک شیء از کلاس PdfOptions را می‌سازد
pdfOptions = slides.export.PdfOptions()

# اسلایدهای مخفی را اضافه می‌کند
pdfOptions.show_hidden_slides = True

# ارائه را به عنوان PDF ذخیره می‌کند
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **تبدیل PowerPoint به PDF محافظت‌شده با رمز عبور**

این کد پایتون نشان می‌دهد چگونه یک PowerPoint را به PDF محافظت‌شده با رمز عبور تبدیل کنید (با استفاده از پارامترهای محافظت موجود در کلاس [PdfOptions](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# یک شیء Presentation را می‌سازد که یک فایل PowerPoint را نشان می‌دهد
presentation = slides.Presentation("PowerPoint.pptx")

# یک شیء از کلاس PdfOptions را می‌سازد
pdfOptions = slides.export.PdfOptions()

# رمز عبور PDF و مجوزهای دسترسی را تنظیم می‌کند
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# ارائه را به عنوان PDF ذخیره می‌کند
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **تبدیل اسلایدهای منتخب در PowerPoint به PDF**

این کد پایتون نشان می‌دهد چگونه اسلایدهای خاص یک ارائه PowerPoint را به PDF تبدیل کنید:

```python
import aspose.slides as slides

# یک شیء Presentation را می‌سازد که یک فایل PowerPoint را نشان می‌دهد
presentation = slides.Presentation("PowerPoint.pptx")

# یک آرایه از موقعیت‌های اسلایدها را تنظیم می‌کند
slides_array = [ 1, 3 ]

# ارائه را به عنوان PDF ذخیره می‌کند
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **تبدیل PowerPoint به PDF با اندازه اسلاید سفارشی**

این کد پایتون نشان می‌دهد چگونه وقتی اندازه اسلاید مشخص شده باشد، PowerPoint را به PDF تبدیل کنید:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# یک شیء از کلاس Presentation که یک فایل PowerPoint یا OpenDocument را نشان می‌دهد را می‌سازد.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # یک ارائه جدید با اندازه اسلاید تنظیم‌شده ایجاد می‌کند.
    with slides.Presentation() as resized_presentation:

        # اندازه اسلاید سفارشی را تنظیم می‌کند.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # اسلاید اول را از ارائه اصلی کلون می‌کند و اسلاید خالی پیش‌فرض را حذف می‌کند.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)
        resized_presentation.slides.remove_at(1)

        # ارائه تغییر اندازه‌یافته را به PDF ذخیره می‌کند.
        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **تبدیل PowerPoint به PDF در نمای یادداشت اسلاید**

این کد پایتون نشان می‌دهد چگونه یک PowerPoint را به یادداشت‌های PDF تبدیل کنید:

```python
import aspose.slides as slides

# یک شیء از کلاس Presentation که یک فایل PowerPoint را نشان می‌دهد را می‌سازد
presentation = slides.Presentation("NotesFile.pptx")

# گزینه‌های PDF را با طرح یادداشت‌ها پیکربندی می‌کند
pdfOptions = slides.export.PdfOptions()
pdfOptions.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdfOptions.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# ارائه را به یک PDF با یادداشت‌ها ذخیره می‌کند
presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **استانداردهای دسترسی و انطباق برای PDF**

Aspose.Slides به شما امکان استفاده از یک روش تبدیل که با [راهنمای دسترس‌پذیری محتوای وب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار است، می‌دهد. می‌توانید یک سند PowerPoint را به PDF با هر یک از این استانداردهای انطباق صادر کنید: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد پایتون یک عملیات تبدیل PowerPoint به PDF را نشان می‌دهد که در آن چندین PDF بر پایهٔ استانداردهای انطباق مختلف به‌دست می‌آید:

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

{{% alert title="Note" color="warning" %}} 

پشتیبانی Aspose.Slides برای عملیات تبدیل PDF شامل امکان تبدیل PDF به محبوب‌ترین فرمت‌های فایل می‌شود. می‌توانید تبدیل‌های [PDF به HTML](https://products.aspose.com/slides/fa/python-net/conversion/pdf-to-html/)، [PDF به تصویر](https://products.aspose.com/slides/fa/python-net/conversion/pdf-to-image/)، [PDF به JPG](https://products.aspose.com/slides/fa/python-net/conversion/pdf-to-jpg/)، و [PDF به PNG](https://products.aspose.com/slides/fa/python-net/conversion/pdf-to-png/) را انجام دهید. سایر عملیات تبدیل PDF به فرمت‌های تخصصی—[PDF به SVG](https://products.aspose.com/slides/fa/python-net/conversion/pdf-to-svg/)، [PDF به TIFF](https://products.aspose.com/slides/fa/python-net/conversion/pdf-to-tiff/)، و [PDF به XML](https://products.aspose.com/slides/fa/python-net/conversion/pdf-to-xml/)—نیز پشتیبانی می‌شوند.

{{% /alert %}}

> **Note:** هنگام صدور به PDF/UA، Aspose.Slides گرافیک‌های پیچیده‌ای مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک تصویر واحد در نظر می‌گیرد. عناصر مسیر به‌صورت محتویات جداگانه حفظ نمی‌شوند و ممکن است به‌عنوان آثار جانبی علامت‌گذاری شوند؛ متن جایگزین فقط برای کل تصویر ارائه می‌شود.

## **پرسش‌های متداول**

### آیا Aspose.Slides برای پایتون می‌تواند اطلاعات برنامه را از PDF حذف کند؟

خیر، Aspose.Slides برای پایتون به‌صورت خودکار اطلاعات API و شماره نسخه را در PDF خروجی گنجانده و این اطلاعات قابل تغییر یا حذف نیست.

### چگونه فقط اسلایدهای خاصی را در تبدیل به PDF شامل کنم؟

می‌توانید ایندکس‌های اسلاید موردنظر را با ارسال یک آرایه از موقعیت‌های اسلاید به متد `save` مشخص کنید.

### آیا امکان محافظت با رمز عبور از PDF در هنگام تبدیل وجود دارد؟

بله، می‌توانید قبل از ذخیرهٔ ارائه به PDF، یک رمز عبور تعیین کرده و مجوزهای دسترسی را با استفاده از کلاس `PdfOptions` تنظیم کنید.

### آیا Aspose.Slides قابلیت تبدیل PDF به فرمت‌های دیگر را دارد؟

بله، Aspose.Slides تبدیل PDF به فرمت‌هایی مانند HTML، فرمت‌های تصویری (JPG، PNG)، SVG، TIFF و XML را پشتیبانی می‌کند.

### چگونه می‌توانم اطمینان حاصل کنم که PDF من با استانداردهای دسترس‌پذیری سازگار است؟

مقدار ویژگی `compliance` را در `PdfOptions` بر روی استانداردهایی مانند `PDF_A1A`، `PDF_A1B` یا `PDF_UA` تنظیم کنید.

### آیا می‌توانم اسلایدهای مخفی را در خروجی PDF گنجانده کنم؟

بله، با تنظیم ویژگی `show_hidden_slides` در `PdfOptions` به `True`، اسلایدهای مخفی در PDF گنجانده می‌شوند.

### چگونه می‌توانم کیفیت تصویر و وضوح را هنگام تبدیل تنظیم کنم؟

از ویژگی‌های `jpeg_quality` و `sufficient_resolution` در `PdfOptions` برای کنترل کیفیت و وضوح تصویر در PDF نهایی استفاده کنید.

### آیا Aspose.Slides جایگزینی فونت‌ها را به‌صورت خودکار انجام می‌دهد؟

Aspose.Slides در هنگام تبدیل جایگزینی فونت‌ها را تشخیص می‌دهد و می‌توانید با استفاده از ویژگی `warning_callback` در `SaveOptions` (در حال حاضر محدود) آن را مدیریت کنید.

## **منابع اضافی**

- [مستندات Aspose.Slides برای .NET](https://docs.aspose.com/slides/fa/python-net/)
- [مرجع API Aspose.Slides](https://reference.aspose.com/slides/fa/python-net/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/fa/conversion)