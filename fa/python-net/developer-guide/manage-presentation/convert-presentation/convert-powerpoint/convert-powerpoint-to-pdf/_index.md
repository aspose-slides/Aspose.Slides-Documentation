---
title: تبدیل PPT و PPTX به PDF در Python | گزینه‌های پیشرفته
linktitle: PowerPoint به PDF
type: docs
weight: 40
url: /fa/python-net/convert-powerpoint-to-pdf/
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
- Aspose.Slides برای Python
description: "راهنمای گام‌به‌گام برای تبدیل PPT، PPTX و ODP به PDFهای با کیفیت بالا و سازگار با WCAG در Python با Aspose.Slides—شامل محافظت با رمز عبور، انتخاب اسلایدها و کنترل کیفیت تصویر."
showReadingTime: true
---
## **بررسی کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP) به فرمت PDF در Python چندین مزیت دارد، از جمله اطمینان از سازگاری در دستگاه‌های مختلف و حفظ طرح‌بندی و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای مخفی را شامل کنید، اسناد PDF را با رمز عبور محافظت کنید، جایگزینی فونت‌ها را شناسایی کنید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای تطبیق را روی اسناد خروجی اعمال کنید.

## **تبدیل‌های PowerPoint به PDF**

با استفاده از Aspose.Slides می‌توانید ارائه‌ها را در این فرمت‌ها به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF در Python، کافی است نام فایل را به‌عنوان آرگومان به کلاس [Presentation](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides/presentation/) بدهید و سپس ارائه را با استفاده از متد [Save](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides/presentation/#methods) به PDF ذخیره کنید. کلاس [Presentation](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides/presentation/) متد [Save](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides/presentation/#methods) را ارائه می‌دهد که معمولاً برای تبدیل ارائه به PDF استفاده می‌شود.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides برای Python به‌صورت مستقیم اطلاعات API و شماره نسخه را در اسناد خروجی می‌نویسد. به‌عنوان مثال، وقتی یک ارائه را به PDF تبدیل می‌کند، فیلد Application را با مقدار '*Aspose.Slides*' و فیلد PDF Producer را با مقداری به شکل '*Aspose.Slides v XX.XX*' پر می‌کند. **توجه** داشته باشید که نمی‌توانید Aspose.Slides برای Python را واگذار کنید تا این اطلاعات را از اسناد خروجی حذف یا تغییر دهد.

{{% /alert %}}

Aspose.Slides به شما اجازه می‌دهد:

* کل ارائه‌ها را به PDF تبدیل کنید
* اسلایدهای خاصی را در یک ارائه به PDF تبدیل کنید

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و محتوای PDFهای حاصل با ارائه‌های اصلی به‌دقت مطابقت دارد. عناصر و ویژگی‌ها در تبدیل به‌درستی رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و اشکال
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* لینک‌ها
* سرصفحه‌ها و پاورقی‌ها
* بولت‌ها
* جدول‌ها

## **تبدیل PowerPoint به PDF**

عملیات استاندارد تبدیل PowerPoint به PDF با استفاده از گزینه‌های پیش‌فرض اجرا می‌شود. در این حالت، Aspose.Slides سعی می‌کند ارائهٔ داده‌شده را با تنظیمات بهینه و در بالاترین سطوح کیفیت به PDF تبدیل کند. این کد Python نشان می‌دهد چگونه PowerPoint را به PDF تبدیل کنید:

_مراحل: تبدیل PowerPoint به PDF در Python_

نمونه کد زیر این تبدیل‌ها را با استفاده از Python از طریق .NET توضیح می‌دهد
- <a name="python-net-powerpoint-to-pdf"><strong>مراحل: تبدیل PowerPoint به PDF با استفاده از Python via .NET</strong></a>
- <a name="python-net-ppt-to-pdf"><strong>مراحل: تبدیل PPT به PDF با استفاده از Python via .NET</strong></a>
- <a name="python-net-pptx-to-pdf"><strong>مراحل: تبدیل PPTX به PDF با استفاده از Python via .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>مراحل: تبدیل ODP به PDF با استفاده از Python via .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>مراحل: تبدیل PPS به PDF با استفاده از Python via .NET</strong></a>

_کد گام‌ها:_

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید و فایل PowerPoint را به آن بدهید.
  * پسوند _.ppt_ برای بارگذاری فایل **PPT** در کلاس _Presentation_.
  * پسوند _.pptx_ برای بارگذاری فایل **PPTX** در کلاس _Presentation_.
  * پسوند _.odp_ برای بارگذاری فایل **ODP** در کلاس _Presentation_.
  * پسوند _.pps_ برای بارگذاری فایل **PPS** در کلاس _Presentation_.
- _Presentation_ را با فراخوانی متد **Save** و استفاده از مقدار **SaveFormat.PDF** به فرمت **PDF** ذخیره کنید.
  

```python
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PowerPoint است
presentation = slides.Presentation("PowerPoint.ppt")

# ارائه را به صورت PDF ذخیره می‌کند
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose یک [**مبدل PowerPoint به PDF**](https://products.aspose.app/slides/fa/conversion/ppt-to-pdf) آنلاین رایگان ارائه می‌دهد که فرایند تبدیل ارائه به PDF را نشان می‌دهد. برای پیاده‌سازی زندهٔ روشی که در اینجا توضیح داده شده است، می‌توانید یک آزمایش با این مبدل انجام دهید.

{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—خواص تحت کلاس [PdfOptions](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides.export/pdfoptions/)—را فراهم می‌کند که به شما اجازه می‌دهد PDF حاصل از فرآیند تبدیل را سفارشی کنید، PDF را با رمز عبور قفل کنید یا حتی نحوهٔ انجام تبدیل را تعیین کنید.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی می‌توانید تنظیمات کیفیت دلخواه برای تصاویر رستری، نحوهٔ پردازش متافایل‌ها، سطح فشرده‌سازی متون، DPI برای تصاویر و غیره را تعیین کنید.

مثال کد زیر یک عملیات را نشان می‌دهد که در آن یک ارائه PowerPoint با چندین گزینه سفارشی به PDF تبدیل می‌شود:

```python
import aspose.slides as slides

# یک نمونه از کلاس PdfOptions ایجاد می‌شود
pdf_options = slides.export.PdfOptions()

# کیفیت تصاویر JPG را تنظیم می‌کند
pdf_options.jpeg_quality = 90

# DPI تصاویر را تنظیم می‌کند
pdf_options.sufficient_resolution = 300

# رفتار متافایل‌ها را تنظیم می‌کند
pdf_options.save_metafiles_as_png = True

# سطح فشرده‌سازی متن برای محتواهای متنی را تنظیم می‌کند
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# حالت تطبیق PDF را تعریف می‌کند
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک سند PowerPoint است
with slides.Presentation("PowerPoint.pptx") as presentation:
    # ارائه را به عنوان یک سند PDF ذخیره می‌کند
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر ارائه شامل اسلایدهای مخفی باشد، می‌توانید از گزینهٔ سفارشی `show_hidden_slides` در کلاس [PdfOptions](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides.export/pdfoptions/) استفاده کنید تا Aspose.Slides اسلایدهای مخفی را به‌عنوان صفحات در PDF حاصل شامل کند.

این کد Python نشان می‌دهد چگونه یک ارائه PowerPoint را با اسلایدهای مخفی به PDF تبدیل کنید:

```python
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PowerPoint است
presentation = slides.Presentation("PowerPoint.pptx")

# یک نمونه از کلاس PdfOptions ایجاد می‌شود
pdfOptions = slides.export.PdfOptions()

# اسلایدهای مخفی را اضافه می‌کند
pdfOptions.show_hidden_slides = True

# ارائه را به عنوان PDF ذخیره می‌کند
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **تبدیل PowerPoint به PDF با رمز عبور**

این کد Python نشان می‌دهد چگونه PowerPoint را به یک PDF دارای رمز عبور (با استفاده از پارامترهای حفاظتی کلاس [PdfOptions](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides.export/pdfoptions/)) تبدیل کنید:

```python
import aspose.slides as slides

# یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PowerPoint است
presentation = slides.Presentation("PowerPoint.pptx")

# یک نمونه از کلاس PdfOptions ایجاد می‌شود
pdfOptions = slides.export.PdfOptions()

# رمز عبور PDF و مجوزهای دسترسی را تنظیم می‌کند
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# ارائه را به صورت PDF ذخیره می‌کند
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **تبدیل اسلایدهای انتخابی در PowerPoint به PDF**

این کد Python نشان می‌دهد چگونه اسلایدهای خاصی در یک ارائه PowerPoint را به PDF تبدیل کنید:

```python
import aspose.slides as slides

# یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PowerPoint است
presentation = slides.Presentation("PowerPoint.pptx")

# یک آرایه از موقعیت‌های اسلایدها را تنظیم می‌کند
slides_array = [ 1, 3 ]

# ارائه را به صورت PDF ذخیره می‌کند
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **تبدیل PowerPoint به PDF با اندازهٔ اسلاید سفارشی**

این کد Python نشان می‌دهد چگونه PowerPoint را وقتی اندازهٔ اسلاید آن مشخص شده است به PDF تبدیل کنید:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PowerPoint یا OpenDocument است.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # یک ارائه جدید با اندازه اسلاید تنظیم‌شده ایجاد می‌کند.
    with slides.Presentation() as resized_presentation:

        # اندازه اسلاید سفارشی را تنظیم می‌کند.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # اسلاید اول را از ارائه اصلی کپی می‌کند.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # ارائه با اندازه تغییر یافته را به صورت PDF با یادداشت‌ها ذخیره می‌کند.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **تبدیل PowerPoint به PDF در نمای اسلایدهای یادداشت‌ها**

این کد Python نشان می‌دهد چگونه PowerPoint را به PDF یادداشت‌ها تبدیل کنید:

```python
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PowerPoint است
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# ارائه را به PDF با یادداشت‌ها ذخیره می‌کند
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **دسترس‌پذیری و استانداردهای تطبیق برای PDF**

Aspose.Slides به شما اجازه می‌دهد از روشی استفاده کنید که با [راهنمای دسترس‌پذیری محتوای وب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار باشد. می‌توانید یک سند PowerPoint را به PDF صادر کنید و از هر یک از این استانداردهای تطبیق استفاده کنید: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد Python یک عملیات تبدیل PowerPoint به PDF را نشان می‌دهد که در آن چندین PDF بر پایهٔ استانداردهای مختلف تطبیق تولید می‌شود:

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

پشتیبانی Aspose.Slides برای عملیات تبدیل PDF شامل امکان تبدیل PDF به رایج‌ترین فرمت‌های فایل نیز می‌شود. می‌توانید تبدیل‌های [PDF به HTML](https://products.aspose.com/slides/fa/python-net/conversion/pdf-to-html/)، [PDF به تصویر](https://products.aspose.com/slides/fa/python-net/conversion/pdf-to-image/)، [PDF به JPG](https://products.aspose.com/slides/fa/python-net/conversion/pdf-to-jpg/)، و [PDF به PNG](https://products.aspose.com/slides/fa/python-net/conversion/pdf-to-png/) را انجام دهید. سایر عملیات تبدیل PDF به فرمت‌های تخصصی—[PDF به SVG](https://products.aspose.com/slides/fa/python-net/conversion/pdf-to-svg/)، [PDF به TIFF](https://products.aspose.com/slides/fa/python-net/conversion/pdf-to-tiff/)، و [PDF به XML](https://products.aspose.com/slides/fa/python-net/conversion/pdf-to-xml/)—نیز پشتیبانی می‌شوند.

{{% /alert %}}

> **توجه:** هنگام صادرات به PDF/UA، Aspose.Slides گرافیک‌های پیچیده مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد درنظر می‌گیرد. عناصر مسیر جداگانه به‌عنوان محتوای مستقل حفظ نمی‌شوند و ممکن است به‌عنوان artefacts علامت‌گذاری شوند؛ متن جایگزین تنها برای کل شکل ارائه می‌شود.

## **سوالات متداول**

**آیا Aspose.Slides برای Python می‌تواند اطلاعات برنامه را از PDF حذف کند؟**

خیر، Aspose.Slides برای Python به‌صورت خودکار اطلاعات API و شماره نسخه را در PDF خروجی قرار می‌دهد. این اطلاعات قابل تغییر یا حذف نیستند.

**چگونه می‌توانم فقط اسلایدهای خاص را در تبدیل PDF گنجانده؟**

می‌توانید ایندکس‌های اسلایدهایی که می‌خواهید تبدیل کنید را با ارسال یک آرایه از موقعیت‌های اسلاید به متد `save` مشخص کنید.

**آیا امکان محافظت PDF با رمز عبور در حین تبدیل وجود دارد؟**

بله، می‌توانید قبل از ذخیرهٔ ارائه به PDF، از کلاس `PdfOptions` رمز عبور تعیین کرده و مجوزهای دسترسی را تعریف کنید.

**آیا Aspose.Slides قابلیت تبدیل PDF به فرمت‌های دیگر را دارد؟**

بله، Aspose.Slides قابلیت تبدیل PDFها به فرمت‌هایی مانند HTML، فرمت‌های تصویر (JPG، PNG)، SVG، TIFF و XML را دارد.

**چگونه می‌توانم اطمینان حاصل کنم PDF من با استانداردهای دسترس‌پذیری سازگار است؟**

ویژگی `compliance` در `PdfOptions` را بر روی استانداردهایی مانند `PDF_A1A`، `PDF_A1B` یا `PDF_UA` تنظیم کنید تا سازگاری با راهنمای دسترس‌پذیری حاصل شود.

**آیا می‌توانم اسلایدهای مخفی را در خروجی PDF گنجانده کنم؟**

بله، با تنظیم ویژگی `show_hidden_slides` در `PdfOptions` برابر با `True`، اسلایدهای مخفی در PDF گنجانده می‌شوند.

**چگونه می‌توانم کیفیت تصویر و وضوح را در حین تبدیل تنظیم کنم؟**

از ویژگی‌های `jpeg_quality` و `sufficient_resolution` در `PdfOptions` برای کنترل کیفیت تصویر و وضوح در PDF حاصل استفاده کنید.

**آیا Aspose.Slides جایگزینی فونت‌ها را به‌صورت خودکار برخورد می‌کند؟**

Aspose.Slides هنگام تبدیل جایگزینی فونت‌ها را شناسایی می‌کند و می‌توانید با استفاده از ویژگی `warning_callback` در `SaveOptions` (در حال حاضر محدود) این موضوع را مدیریت کنید.

## **منابع تکمیلی**

- [مستندات Aspose.Slides برای .NET](https://docs.aspose.com/slides/fa/python-net/)
- [مرجع API Aspose.Slides](https://reference.aspose.com/slides/fa/python-net/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/fa/conversion)