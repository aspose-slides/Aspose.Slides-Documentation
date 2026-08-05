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
description: "راهنمای گام به گام برای تبدیل PPT، PPTX و ODP به PDFهای با کیفیت بالا و سازگار با WCAG در پایتون با Aspose.Slides—شامل حفاظت با رمز عبور، انتخاب اسلاید و کنترل کیفیت تصویر."
showReadingTime: true
---
## **نمایش کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP) به فرمت PDF در پایتون مزایای متعددی دارد، از جمله تضمین سازگاری در دستگاه‌های مختلف و حفظ چینش و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای مخفی را اضافه کنید، اسناد PDF را با رمز عبور محافظت کنید، جایگزینی‌ فونت‌ها را شناسایی کنید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای انطباق را بر روی اسناد خروجی اعمال کنید.

## **تبدیل PowerPoint به PDF**

با استفاده از Aspose.Slides می‌توانید ارائه‌ها را در این فرمت‌ها به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF در پایتون، فقط کافی است نام فایل را به عنوان آرگومان به کلاس [Presentation](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides/presentation/) بدهید و سپس ارائه را با متد [Save](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides/presentation/#methods) به PDF ذخیره کنید. کلاس [Presentation](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides/presentation/) متد [Save](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides/presentation/#methods) را در اختیار می‌گذارد که معمولاً برای تبدیل ارائه به PDF استفاده می‌شود.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Python به‌صورت مستقیم اطلاعات API و شماره نسخه را در اسناد خروجی می‌نویسد. به‌عنوان مثال، هنگامی که ارائه‌ای را به PDF تبدیل می‌کند، فیلد Application را با مقدار '*Aspose.Slides*' و فیلد PDF Producer را با مقداری به شکل '*Aspose.Slides v XX.XX*' پر می‌کند. **توجه** داشته باشید که نمی‌توانید Aspose.Slides for Python را مجبور کنید این اطلاعات را در اسناد خروجی تغییر یا حذف کند.

{{% /alert %}}

Aspose.Slides به شما اجازه می‌دهد تا:

* کل ارائه‌ها را به PDF تبدیل کنید
* اسلایدهای خاصی در یک ارائه را به PDF تبدیل کنید

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند به‌طوری که محتویات PDFs حاصل به‌دقت با ارائه‌های اصلی مطابقت داشته باشد. عناصر و ویژگی‌ها در تبدیل به‌درستی رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و اشکال
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندهای فراخوانی
* سرصفحات و پاورقی‌ها
* نکات بولت‌دار
* جداول

## **تبدیل PowerPoint به PDF**

عملیات استاندارد تبدیل PowerPoint به PDF با استفاده از گزینه‌های پیش‌فرض اجرا می‌شود. در این حالت، Aspose.Slides سعی می‌کند ارائهٔ ارائه‌شده را به PDF تبدیل کند با استفاده از تنظیمات بهینه در بالاترین سطوح کیفیت. این کد پایتون نشان می‌دهد چگونه یک PowerPoint را به PDF تبدیل کنید:

_مراحل: تبدیل PowerPoint به PDF در پایتون_

کد نمونهٔ زیر این تبدیل‌ها را با پایتون از طریق .NET توضیح می‌دهد
- <a name="python-net-powerpoint-to-pdf"><strong>مراحل: تبدیل PowerPoint به PDF با استفاده از پایتون از طریق .NET</strong></a>
- <a name="python-net-ppt-to-pdf"><strong>مراحل: تبدیل PPT به PDF با استفاده از پایتون از طریق .NET</strong></a>
- <a name="python-net-pptx-to-pdf"><strong>مراحل: تبدیل PPTX به PDF با استفاده از پایتون از طریق .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>مراحل: تبدیل ODP به PDF با استفاده از پایتون از طریق .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>مراحل: تبدیل PPS به PDF با استفاده از پایتون از طریق .NET</strong></a>

_گام‌های کد:_

- ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) و ارائهٔ فایل PowerPoint به آن.
  * پسوند _.ppt_ برای بارگذاری فایل **PPT** داخل کلاس _Presentation_.
  * پسوند _.pptx_ برای بارگذاری فایل **PPTX** داخل کلاس _Presentation_.
  * پسوند _.odp_ برای بارگذاری فایل **ODP** داخل کلاس _Presentation_.
  * پسوند _.pps_ برای بارگذاری فایل **PPS** داخل کلاس _Presentation_.
- ذخیرهٔ _Presentation_ به فرمت **PDF** با فراخوانی متد **Save** و استفاده از شمارش **SaveFormat.PDF**.

```python
import aspose.slides as slides

# یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PowerPoint است
presentation = slides.Presentation("PowerPoint.ppt")

# ارائه را به عنوان یک PDF ذخیره می‌کند
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose یک [**مبدل PowerPoint به PDF**](https://products.aspose.app/slides/fa/conversion/ppt-to-pdf) رایگان آنلاین فراهم می‌کند که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. برای مشاهدهٔ پیاده‌سازی زندهٔ این روش می‌توانید از مبدل تست کنید.

{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—ویژگی‌های موجود در کلاس [PdfOptions](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides.export/pdfoptions/)—را فراهم می‌کند تا بتوانید PDF حاصل از فرآیند تبدیل را سفارشی کنید، PDF را با رمز عبور قفل کنید یا حتی نحوهٔ انجام تبدیل را مشخص کنید.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی می‌توانید تنظیم کیفیت دلخواه برای تصاویر رستر، نحوهٔ پردازش متافایل‌ها، سطح فشرده‌سازی متون، DPI تصاویر و غیره را تعیین کنید.

مثال کد زیر عملی را نشان می‌دهد که در آن یک ارائه PowerPoint با چندین گزینه سفارشی به PDF تبدیل می‌شود:

```python
import aspose.slides as slides

# یک شیء از کلاس PdfOptions ایجاد می‌کند
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

# یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک سند PowerPoint است
with slides.Presentation("PowerPoint.pptx") as presentation:
    # ارائه را به عنوان یک سند PDF ذخیره می‌کند
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر ارائه شامل اسلایدهای مخفی باشد، می‌توانید با استفاده از گزینهٔ سفارشی—ویژگی `show_hidden_slides` در کلاس [PdfOptions](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides.export/pdfoptions/)—به Aspose.Slides بگویید که اسلایدهای مخفی را به‌عنوان صفحات در PDF نهایی اضافه کند.

این کد پایتون نشان می‌دهد چگونه یک ارائه PowerPoint را به PDF با اسلایدهای مخفی تبدیل کنید:

```python
import aspose.slides as slides

# یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PowerPoint است
presentation = slides.Presentation("PowerPoint.pptx")

# یک شیء از کلاس PdfOptions ایجاد می‌کند
pdfOptions = slides.export.PdfOptions()

# اسلایدهای مخفی را اضافه می‌کند
pdfOptions.show_hidden_slides = True

# ارائه را به عنوان یک PDF ذخیره می‌کند
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **تبدیل PowerPoint به PDF با حفاظت از رمز عبور**

این کد پایتون نشان می‌دهد چگونه یک PowerPoint را به PDF محافظت‌شده با رمز عبور تبدیل کنید (با استفاده از پارامترهای حفاظت در کلاس [PdfOptions](https://docs.aspose.com/slides/fa/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل PowerPoint است
presentation = slides.Presentation("PowerPoint.pptx")

# یک شیء از کلاس PdfOptions ایجاد می‌کند
pdfOptions = slides.export.PdfOptions()

# رمز عبور PDF و سطح دسترسی‌ها را تنظیم می‌کند
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# ارائه را به عنوان یک PDF ذخیره می‌کند
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **تبدیل اسلایدهای انتخاب‌شده در PowerPoint به PDF**

این کد پایتون نشان می‌دهد چگونه اسلایدهای خاصی در یک ارائه PowerPoint را به PDF تبدیل کنید:

```python
import aspose.slides as slides

# یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل PowerPoint است
presentation = slides.Presentation("PowerPoint.pptx")

# یک آرایه از موقعیت‌های اسلایدها را تنظیم می‌کند
slides_array = [ 1, 3 ]

# ارائه را به عنوان یک PDF ذخیره می‌کند
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **تبدیل PowerPoint به PDF با اندازهٔ اسلاید سفارشی**

این کد پایتون نشان می‌دهد چگونه یک PowerPoint که اندازهٔ اسلاید آن مشخص شده است به PDF تبدیل کنید:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل PowerPoint یا OpenDocument است.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # یک ارائه جدید با اندازه اسلاید تنظیم‌شده ایجاد می‌کند.
    with slides.Presentation() as resized_presentation:

        # اندازه اسلاید سفارشی را تنظیم می‌کند.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # اولین اسلاید را از ارائه اصلی کپی می‌کند.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # ارائه تغییر اندازه‌یافته را به PDF با یادداشت‌ها ذخیره می‌کند.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **تبدیل PowerPoint به PDF در نمای یادداشت اسلاید**

این کد پایتون نشان می‌دهد چگونه یک PowerPoint را به PDF یادداشت‌ها تبدیل کنید:

```python
import aspose.slides as slides

# یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PowerPoint است
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# ارائه را به یادداشت‌های PDF ذخیره می‌کند
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **دسترس‌پذیری و استانداردهای انطباق برای PDF**

Aspose.Slides به شما اجازه می‌دهد تا از رویهٔ تبدیل استفاده کنید که با [راهنمای دسترس‌پذیری محتوای وب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار باشد. می‌توانید یک سند PowerPoint را به PDF صادر کنید با هر یک از این استانداردهای انطباق: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد پایتون یک عملیات تبدیل PowerPoint به PDF را نشان می‌دهد که در آن PDFهای متعدد بر پایه استانداردهای انطباق مختلف تولید می‌شود:

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

پشتیبانی Aspose.Slides برای عملیات تبدیل PDF شامل امکان تبدیل PDF به پرکاربردترین فرمت‌های فایل است. می‌توانید تبدیل‌های [PDF به HTML](https://products.aspose.com/slides/fa/python-net/conversion/pdf-to-html/)، [PDF به تصویر](https://products.aspose.com/slides/fa/python-net/conversion/pdf-to-image/)، [PDF به JPG](https://products.aspose.com/slides/fa/python-net/conversion/pdf-to-jpg/)، و [PDF به PNG](https://products.aspose.com/slides/fa/python-net/conversion/pdf-to-png/) را انجام دهید. سایر عملیات تبدیل PDF به فرمت‌های خاص—[PDF به SVG](https://products.aspose.com/slides/fa/python-net/conversion/pdf-to-svg/)، [PDF به TIFF](https://products.aspose.com/slides/fa/python-net/conversion/pdf-to-tiff/)، و [PDF به XML](https://products.aspose.com/slides/fa/python-net/conversion/pdf-to-xml/)—نیز پشتیبانی می‌شوند.

{{% /alert %}}

> **توجه:** هنگام صادرات به PDF/UA، Aspose.Slides گرافیک‌های پیچیده‌ای مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. عناصر مسیر جداگانه به‌عنوان محتوای مستقل حفظ نمی‌شوند و ممکن است به‌عنوان artefacts علامت‌گذاری شوند؛ متن جایگزین فقط برای کل شکل فراهم می‌شود.

## **سوالات متداول**

**آیا Aspose.Slides for Python می‌تواند اطلاعات برنامه را از PDF حذف کند؟**

خیر، Aspose.Slides for Python به‌صورت خودکار اطلاعات API و شماره نسخه را در PDF خروجی می‌گنجاند. این اطلاعات قابل تغییر یا حذف نیست.

**چگونه می‌توان فقط اسلایدهای خاصی را در تبدیل PDF گنجاند؟**

می‌توانید ایندکس‌های اسلایدهای موردنظر را با ارسال آرایه‌ای از موقعیت‌های اسلاید به متد `save` مشخص کنید.

**آیا می‌توان PDF را در هنگام تبدیل با رمز عبور محافظت کرد؟**

بله، می‌توانید قبل از ذخیرهٔ ارائه به PDF، یک رمز عبور تعیین کنید و مجوزهای دسترسی را با استفاده از کلاس `PdfOptions` تنظیم کنید.

**آیا Aspose.Slides تبدیل PDF به فرمت‌های دیگر را پشتیبانی می‌کند؟**

بله، Aspose.Slides می‌تواند PDFها را به فرمت‌هایی نظیر HTML، فرمت‌های تصویری (JPG، PNG)، SVG، TIFF و XML تبدیل کند.

**چگونه می‌توان اطمینان حاصل کرد که PDF با استانداردهای دسترس‌پذیری مطابقت دارد؟**

دارای ویژگی `compliance` در `PdfOptions` باشید و آن را به استانداردهایی مانند `PDF_A1A`، `PDF_A1B` یا `PDF_UA` تنظیم کنید.

**آیا می‌توان اسلایدهای مخفی را در خروجی PDF گنجاند؟**

بله، با تنظیم ویژگی `show_hidden_slides` در `PdfOptions` به `True`، اسلایدهای مخفی در PDF گنجانده می‌شوند.

**چگونه می‌توان کیفیت تصویر و وضوح را در زمان تبدیل تنظیم کرد؟**

از ویژگی‌های `jpeg_quality` و `sufficient_resolution` در `PdfOptions` برای کنترل کیفیت تصویر و وضوح در PDF نهایی استفاده کنید.

**آیا Aspose.Slides جایگزینی فونت‌ها را به‌صورت خودکار مدیریت می‌کند؟**

Aspose.Slides در زمان تبدیل، جایگزینی فونت‌ها را شناسایی می‌کند و می‌توانید با استفاده از ویژگی `warning_callback` در `SaveOptions` (در حال حاضر محدود) آن‌ها را مدیریت کنید.

## **منابع تکمیلی**

- [مستندات Aspose.Slides for .NET](https://docs.aspose.com/slides/fa/python-net/)
- [مرجع API Aspose.Slides](https://reference.aspose.com/slides/fa/python-net/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/fa/conversion)