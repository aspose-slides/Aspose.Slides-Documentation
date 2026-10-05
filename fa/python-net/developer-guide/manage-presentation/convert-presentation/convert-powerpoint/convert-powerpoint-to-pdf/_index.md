---
title: "تبدیل PPT و PPTX به PDF در پایتون | گزینه‌های پیشرفته"
linktitle: "پاورپوینت به PDF"
type: docs
weight: 40
url: /fa/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
  - "تبدیل پاورپوینت"
  - "ارائه"
  - "پاورپوینت به PDF"
  - "PPT به PDF"
  - "PPTX به PDF"
  - "ذخیره پاورپوینت به‌عنوان PDF"
  - "پیوست"
  - "PDF/A1a"
  - "PDF/A1b"
  - "PDF/UA"
  - "Python"
  - "Aspose.Slides for Python"
description: "راهنمای گام به گام برای تبدیل PPT، PPTX و ODP به PDFهای با کیفیت بالا و سازگار با WCAG در پایتون با Aspose.Slides — شامل حفاظت با رمز عبور، انتخاب اسلاید و کنترل کیفیت تصویر."
showReadingTime: true
---
## **بررسی کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP) به فرمت PDF در پایتون مزایای متعددی دارد، از جمله اطمینان از سازگاری در دستگاه‌های مختلف و حفظ طرح و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای مخفی را شامل شوید، اسناد PDF را با رمز عبور محافظت کنید، جایگزینی فونت‌ها را شناسایی کنید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای انطباق را بر روی اسناد خروجی اعمال کنید.

## **تبدیل PowerPoint به PDF**

با استفاده از Aspose.Slides می‌توانید ارائه‌های زیر را به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF در پایتون، کافی است نام فایل را به‌عنوان آرگومان به کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) بدهید و سپس با استفاده از متد [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) ارائه را به‌صورت PDF ذخیره کنید. کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) متد [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) را ارائه می‌دهد که معمولاً برای تبدیل یک ارائه به PDF استفاده می‌شود.

{{% alert color="info" title="Note" %}}
Aspose.Slides برای پایتون اطلاعات API و شماره نسخه خود را در اسناد خروجی وارد می‌کند. به عنوان مثال، وقتی یک ارائه را به PDF تبدیل می‌کند، فیلد Application را با مقدار '*Aspose.Slides*' و فیلد PDF Producer را با مقداری به شکل '*Aspose.Slides v XX.XX*' پر می‌کند. **توجه** داشته باشید که نمی‌توانید به Aspose.Slides برای پایتون بگویید این اطلاعات را در اسناد خروجی تغییر یا حذف کند.
{{% /alert %}}

Aspose.Slides به شما اجازه می‌دهد تا:
* کل ارائه‌ها به PDF
* اسلایدهای خاصی در یک ارائه به PDF

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد محتویات PDF‌های حاصل به‌دقت با ارائه‌های اصلی مطابقت داشته باشند. عناصر و ویژگی‌ها به‌دقت در تبدیل رندر می‌شوند، از جمله:
* تصاویر
* جعبه‌های متن و اشکال
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندهای فراگیر
* سرصفحه‌ها و پاورصفحه‌ها
* نکات
* جداول

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائهٔ ارائه‌شده را با تنظیمات بهینه و در بالاترین سطوح کیفیت به PDF تبدیل کند.

مثال زیر یک ارائه را بارگذاری می‌کند و تمام اسلایدهای قابل مشاهده را با تنظیمات صادرات پیش‌فرض به PDF ذخیره می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose یک [**تبدیل‌کننده PowerPoint به PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) آنلاین رایگان ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. برای اجرای زندهٔ روش توضیح داده‌شده در اینجا، می‌توانید با این تبدیل‌کننده یک آزمایش انجام دهید.
{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—ویژگی‌های موجود در کلاس [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—را فراهم می‌کند که به شما امکان می‌دهد PDF حاصل از فرآیند تبدیل را سفارشی کنید، PDF را با رمز عبور قفل کنید یا حتی نحوهٔ انجام فرآیند تبدیل را مشخص کنید.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی تبدیل، می‌توانید تنظیم کیفیت ترجیحی خود را برای تصاویر ماتریسی، نحوهٔ پردازش فایل‌های متا، سطح فشرده‌سازی متن، DPI برای تصاویر و غیره تنظیم کنید.

مثال زیر یک ارائه را با کیفیت JPEG برابر 90، وضوح تصویر 300 DPI، ذخیرهٔ متا‌فایل‌ها به‌صورت PNG و فشرده‌سازی متن Flate به PDF 1.5 صادر می‌کند.

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

### **حفظ فایل‌های OLE جاسازی‌شده به عنوان پیوست PDF**

اگر یک ارائه شامل کتاب‌کار Excel جاسازی‌شده باشد، ممکن است بخواهید گیرندگان PDF بتوانند به داده‌های کتاب‌کار دسترسی داشته باشند و اسلایدها را مشاهده کنند. برای حفظ فایل‌های OLE جاسازی‌شده به‌عنوان پیوست در PDF حاصل، ویژگی [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) را به `True` تنظیم کنید.

مقدار پیش‌فرض `False` است: تصویر پیش‌نمایش یا آیکون شی OLE روی صفحه PDF رندر می‌شود، اما فایل جاسازی‌شده به‌عنوان پیوست گنجانده نمی‌شود. تنظیم گزینه به `True` علاوه بر پیش‌نمایش، دادهٔ فایل را نیز شامل می‌شود. پیش‌نمایش همچنان یک نمایش بصری است؛ پیوست به گیرندگان اجازه می‌دهد فایل جاسازی‌شده را به‌صورت جداگانه باز یا ذخیره کنند. شی OLE تبدیل به یک کاربرگ Excel تعاملی در صفحه PDF نمی‌شود.

مثال زیر یک ارائه‌ای را که قبلاً شامل کتاب‌کار Excel جاسازی‌شده است بارگذاری می‌کند و آن را به PDF با کتاب‌کار پیوست‌شده صادر می‌کند.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

برای بررسی نتیجه:
1. PDF صادرشده را در نمایگری که از پیوست‌های فایل پشتیبانی می‌کند (مانند Adobe Acrobat Reader) باز کنید.
2. پنل **Attachments** (پیوست‌ها) را باز کنید و کتاب‌کار جاسازی‌شده را پیدا کنید.
3. پیوست را ذخیره کنید و در Excel باز کنید تا داده‌ها را بررسی کنید، یا اگر نمایگر اجازه می‌دهد مستقیماً باز کنید. پیش‌نمایش روی صفحه PDF جدا از پیوست است.

{{% alert color="info" title="Note" %}}
استانداردهای PDF/A محدودیت‌هایی برای پیوست‌ها اعمال می‌کنند: PDF/A-1 از فایل‌های جاسازی‌شده منع می‌کند، PDF/A-2 فقط پیوست‌های PDF/A را اجازه می‌دهد، و PDF/A-3 انواع فایل‌های دیگر از جمله کتاب‌کارهای Excel را مجاز می‌داند. این‌ها الزامات استانداردها هستند، نه محدودیت‌های خاص Aspose.Slides. این مثال از تنظیم پیش‌فرض انطباق PDF استفاده می‌کند و صادرات PDF/A را نشان نمی‌دهد.
{{% /alert %}}

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر یک ارائه شامل اسلایدهای مخفی باشد، می‌توانید از گزینهٔ سفارشی—ویژگی [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) از کلاس [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)— برای دستور دادن به Aspose.Slides استفاده کنید تا اسلایدهای مخفی را به‌عنوان صفحات در PDF حاصل گنجانده شوند.

مثال زیر یک ارائه را به PDF صادر می‌کند که شامل هر اسلاید مخفی است.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **تبدیل PowerPoint به PDF با حفاظت رمز عبور**

مثال زیر یک ارائه را به PDF صادر می‌کند که برای باز کردن نیاز به رمز عبور `password` دارد. مجوزهای دسترسی اجازه چاپ، از جمله چاپ با کیفیت بالا، را می‌دهند.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **تبدیل اسلایدهای انتخابی در PowerPoint به PDF**

مثال زیر اسلایدهای 1 و 3 را از یک ارائه به PDF صادر می‌کند. شماره‌های اسلاید در این آرایه از 1 شروع می‌شوند و ارائهٔ ورودی باید حداقل شامل سه اسلاید باشد.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **تبدیل PowerPoint به PDF با اندازه سفارشی اسلاید**

مثال زیر اولین اسلاید را از یک ارائه به یک ارائهٔ جدید با اندازه اسلاید 612 × 792 نقطه (8.5 × 11 اینچ) کپی می‌کند. محتوای اسلاید برای پر کردن مقیاس‌بندی می‌شود و اسلاید منفرد به PDF صادر می‌شود.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # اسلاید خالی که ارائه جدید با آن ساخته شده بود را حذف کنید.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **تبدیل PowerPoint به PDF در نمای اسلاید یادداشت‌ها**

مثال زیر یک ارائه را به PDF صادر می‌کند به‌طوری‌ که یادداشت‌های سخنران هر اسلاید زیر اسلاید قرار می‌گیرد. برای دیدن نتیجه از ارائه‌ای حاوی یادداشت‌های سخنران استفاده کنید.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **استانداردهای دسترس‌پذیری و انطباق برای PDF**

Aspose.Slides به شما اجازه می‌دهد از روش تبدیل سازگار با [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) استفاده کنید. می‌توانید سند PowerPoint را به PDF صادر کنید و از هر یک از استانداردهای انطباق زیر استفاده کنید: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد پایتون عملیاتی برای تبدیل PowerPoint به PDF را نشان می‌دهد که در آن چندین PDF بر پایه استانداردهای انطباق مختلف تولید می‌شوند:

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
پشتیبانی Aspose.Slides از عملیات تبدیل PDF به شما امکان می‌دهد PDF را به پرطرفدارترین فرمت‌های فایل تبدیل کنید. می‌توانید تبدیل‌های [PDF به HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/)، [PDF به تصویر](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/)، [PDF به JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/)، و [PDF به PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) را انجام دهید. سایر عملیات تبدیل PDF به فرمت‌های تخصصی—[PDF به SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/)، [PDF به TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/)، و [PDF به XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)—هم نیز پشتیبانی می‌شود.
{{% /alert %}}

> **Note:** هنگام صادر کردن به PDF/UA، Aspose.Slides گرافیک‌های پیچیده مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. عناصر مسیر جداگانه به‌عنوان محتوی جداگانه حفظ نمی‌شوند و ممکن است به‌عنوان artefacts علامت‌گذاری شوند؛ متن جایگزین فقط برای کل شکل ارائه می‌شود.

## **FAQ**

**آیا Aspose.Slides برای پایتون می‌تواند اطلاعات برنامه را از PDF حذف کند؟**

خیر، Aspose.Slides برای پایتون به‌ طور خودکار اطلاعات API و شماره نسخه را در PDF خروجی گنجانده است. این اطلاعات قابل تغییر یا حذف نیست.

**چگونه می‌توانم فقط اسلایدهای خاصی را در تبدیل PDF گنجانده کنم؟**

با پاس دادن یک آرایهٔ شامل موقعیت‌های اسلاید به متد [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) می‌توانید شاخص‌های اسلایدی که می‌خواهید تبدیل کنید را مشخص کنید.

**آیا می‌توانم هنگام تبدیل PDF را با رمز عبور محافظت کنم؟**

بله، قبل از ذخیرهٔ ارائه به‌عنوان PDF می‌توانید کلاس [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) را تنظیم کنید تا رمز عبور و مجوزهای دسترسی مورد نظر را مشخص کنید.

**آیا Aspose.Slides امکان تبدیل PDF به فرمت‌های دیگر را دارد؟**

بله، Aspose.Slides امکان تبدیل PDFها به فرمت‌هایی مانند HTML، فرمت‌های تصویر (JPG، PNG)، SVG، TIFF و XML را فراهم می‌کند.

**چگونه می‌توانم اطمینان حاصل کنم PDF من با استانداردهای دسترس‌پذیری مطابقت دارد؟**

خاصیت [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) در [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) را به استانداردهایی مانند `PDF_A1A`، `PDF_A1B` یا `PDF_UA` تنظیم کنید تا انطباق با راهنمایی‌های دسترس‌پذیری تضمین شود.

**آیا می‌توانم اسلایدهای مخفی را در خروجی PDF گنجانده کنم؟**

بله، با تنظیم خاصیت [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) در [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) به `True`، اسلایدهای مخفی در PDF گنجانده می‌شوند.

**چگونه می‌توانم کیفیت تصویر و وضوح را هنگام تبدیل تنظیم کنم؟**

از ویژگی‌های [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) و [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) در [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) برای کنترل کیفیت و وضوح تصویر در PDF حاصل استفاده کنید.

**آیا Aspose.Slides به‌صورت خودکار جایگزینی فونت‌ها را انجام می‌دهد؟**

Aspose.Slides هنگام تبدیل جایگزینی فونت‌ها را شناسایی می‌کند و می‌توانید آن‌ها را با استفاده از ویژگی `warning_callback` در `SaveOptions` (در حال حاضر محدود) مدیریت کنید.

## **منابع اضافی**

- [Aspose.Slides برای پایتون از طریق .NET Documentation](/slides/fa/python-net/)
- [مراجعهٔ API Aspose.Slides](https://reference.aspose.com/slides/python-net/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/conversion)