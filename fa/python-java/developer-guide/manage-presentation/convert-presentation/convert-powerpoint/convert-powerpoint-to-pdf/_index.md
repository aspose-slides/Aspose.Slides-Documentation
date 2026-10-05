---
title: تبدیل PPT و PPTX به PDF در Python از طریق Java [ویژگی‌های پیشرفته گنجانده شده]
linktitle: PowerPoint به PDF
type: docs
weight: 40
url: /fa/python-java/convert-powerpoint-to-pdf/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- PowerPoint به PDF
- ارائه به PDF
- PPT به PDF
- تبدیل PPT به PDF
- PPTX به PDF
- تبدیل PPTX به PDF
- ذخیره PowerPoint به عنوان PDF
- ذخیره PPT به عنوان PDF
- ذخیره PPTX به عنوان PDF
- استخراج PPT به PDF
- استخراج PPTX به PDF
- پیوست
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "PowerPoint PPT/PPTX را به PDFهای با کیفیت بالا و جستجوپذیر در Python از طریق Java با استفاده از Aspose.Slides تبدیل کنید، با مثال‌های کد سریع و گزینه‌های پیشرفتهٔ تبدیل."
---
## **بررسی کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP و غیره) به قالب PDF در Python از طریق Java مزایای متعددی دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ چیدمان و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد که چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای مخفی را شامل کنید، فایل‌های PDF را با رمز عبور محافظت کنید، جایگزینی قلم‌ها را شناسایی کنید، اسلایدهای مشخصی را برای تبدیل انتخاب کنید و استانداردهای سازگاری را بر اسناد خروجی اعمال کنید.

## **تبدیل PowerPoint به PDF**

با استفاده از Aspose.Slides می‌توانید ارائه‌ها را در قالب‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به عنوان آرگومان به کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) پاس دهید و سپس با استفاده از متد [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) ارائه را به PDF ذخیره کنید. کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) متد [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) را ارائه می‌دهد که معمولاً برای تبدیل ارائه به PDF استفاده می‌شود.

{{% alert color="info" title="نکته" %}}

Aspose.Slides for Python via Java اطلاعات API و شماره نسخه خود را در اسناد خروجی وارد می‌کند. برای مثال، هنگام تبدیل یک ارائه به PDF، Aspose.Slides فیلد Application را با "*Aspose.Slides*" و فیلد PDF Producer را با مقداری به شکل "*Aspose.Slides v XX.XX*" پر می‌کند. **توجه** داشته باشید که نمی‌توانید Aspose.Slides را مجبور کنید این اطلاعات را از اسناد خروجی حذف یا تغییر دهد.

{{% /alert %}}

Aspose.Slides به شما امکان می‌دهد:

* کل ارائه‌ها را به PDF تبدیل کنید
* اسلایدهای مشخصی از یک ارائه را به PDF تبدیل کنید

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌یابد PDFهای تولید شده به‌دقت با ارائه‌های اصلی مطابقت دارند. عناصر و ویژگی‌ها در تبدیل به‌درستی رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و اشکال
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندهای ابرمتنی
* سرصفحه‌ها و پاورقی‌ها
* گلوله‌ها
* جدول‌ها

## **تبدیل PowerPoint به PDF**

تبدیل استاندارد از تنظیمات پیش‌فرض خروجی PDF استفاده می‌کند. هنگامی که نیاز به کنترل کیفیت تصویر، محتوای صفحه یا سازگاری PDF دارید، از گزینه‌های سفارشی استفاده کنید.

قبل از اجرای مثال‌ها، [Aspose.Slides for Python via Java](/slides/fa/python-java/installation/) و یک زمان‌اجرای Java سازگار را نصب کنید. هر مثال فایل `presentation.pptx` را از پوشهٔ کاری فعلی می‌خواند؛ آن را با فایل PPT، PPTX یا ODP خود جایگزین کنید. JVM را یک بار برای هر فرایند Python راه‌اندازی کنید.

مثال زیر یک ارائه را بارگذاری کرده و تمام اسلایدهای قابل مشاهده را با تنظیمات پیش‌فرض به PDF ذخیره می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

{{% alert color="info" title="نکته" %}}

Aspose یک مبدل آنلاین رایگان [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با این مبدل آزمونی برای اجرای زندهٔ رویهٔ توضیح داده شده انجام دهید.

{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—خصوصیات تحت کلاس [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)—را فراهم می‌کند تا بتوانید PDF خروجی را سفارشی کنید، PDF را با رمز عبور قفل کنید یا نحوه پیشرفت فرآیند تبدیل را مشخص کنید.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی می‌توانید تنظیم کیفیت دلخواه برای تصاویر رستر، نحوهٔ پردازش متافایل‌ها، سطح فشرده‌سازی متن، DPI برای تصاویر و موارد دیگر را تعریف کنید.

مثال زیر ارائه‌ای را با PDF 1.5 صادر می‌کند که کیفیت JPEG برابر 90، وضوح تصویر 300 DPI، متافایل‌ها به صورت PNG ذخیره می‌شوند و فشرده‌سازی متن Flate فعال است.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setJpegQuality(jpype.JByte(90))
pdf_options.setSufficientResolution(300)
pdf_options.setSaveMetafilesAsPng(True)
pdf_options.setTextCompression(PdfTextCompression.Flate)
pdf_options.setCompliance(PdfCompliance.Pdf15)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **حفظ فایل‌های OLE جاسازی‌شده به‌عنوان پیوست‌های PDF**

اگر ارائه شامل یک کتاب‌کار Excel جاسازی‌شده باشد، ممکن است بخواهید دریافت‌کنندگان PDF به داده‌های کتاب‌کار دسترسی داشته باشند و اسلایدها را نیز ببینند. با فراخوانی متد [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) با مقدار `True`، فایل‌های OLE جاسازی‌شده به‌عنوان پیوست در PDF نهایی حفظ می‌شوند.

مقدار پیش‌فرض `False` است: تصویر پیش‌نمایش یا آیکون شیء OLE در صفحه PDF رندر می‌شود، اما فایل جاسازی‌شده به‌عنوان پیوست افزوده نمی‌شود. تنظیم گزینه به `True` علاوه بر پیش‌نمایش، داده‌های فایل را نیز شامل می‌شود. پیش‌نمایش همچنان یک نمایش بصری است؛ پیوست به دریافت‌کنندگان اجازه می‌دهد فایل جاسازی‌شده را به‌صورت جداگانه باز یا ذخیره کنند. شیء OLE تبدیل به یک ورق‌کاری تعاملی Excel در صفحه PDF نمی‌شود.

مثال زیر یک ارائه‌ای را بارگذاری می‌کند که از قبل شامل یک کتاب‌کار Excel جاسازی‌شده است و آن را با کتاب‌کار به‌عنوان پیوست به PDF صادر می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setIncludeOleData(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

برای بررسی نتیجه:

1. PDF صادر شده را در نمایشی که از پیوست فایل پشتیبانی می‌کند (مانند Adobe Acrobat Reader) باز کنید.
2. پنل **Attachments** را باز کنید و کتاب‌کار جاسازی‌شده را پیدا کنید.
3. پیوست را ذخیره کرده و در Excel باز کنید تا داده‌ها را بررسی کنید، یا مستقیماً اگر نمایشگر اجازه دهد باز کنید. پیش‌نمایش در صفحه PDF جدا از پیوست است.

{{% alert color="info" title="نکته" %}}

استانداردهای PDF/A محدودیتی بر پیوست‌ها اعمال می‌کنند: PDF/A-1 جاسازی فایل‌ها را ممنوع می‌کند، PDF/A-2 فقط پیوست‌های PDF/A را اجازه می‌دهد و PDF/A-3 انواع دیگر فایل‌ها از جمله کتاب‌کارهای Excel را می‌پذیرد. این‌ها الزامات استانداردهاست، نه محدودیت‌های خاص Aspose.Slides. این مثال از تنظیم پیش‌فرض سازگاری PDF استفاده می‌کند و خروجی PDF/A را نشان نمی‌دهد.

{{% /alert %}}

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر ارائه شامل اسلایدهای مخفی باشد، می‌توانید با استفاده از متد [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) از کلاس [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) اسلایدهای مخفی را به‌عنوان صفحات در PDF نهایی شامل کنید.

مثال زیر ارائه‌ای را به PDF صادر می‌کند که اسلایدهای مخفی نیز در آن گنجانده شده‌اند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setShowHiddenSlides(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **تبدیل PowerPoint به PDF با حفاظت توسط رمز عبور**

مثال زیر یک ارائه را به PDF صادر می‌کند که برای باز کردن آن نیاز به رمز عبور `password` دارد. مجوزهای دسترسی چاپ، از جمله چاپ با کیفیت بالا، را اجازه می‌دهند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setPassword("password")
pdf_options.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **شناسایی جایگزینی قلم‌ها**

Aspose.Slides متد [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) را تحت کلاس [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) فراهم می‌کند تا بتوانید هنگام تبدیل ارائه به PDF، جایگزینی قلم‌ها را شناسایی کنید.

مثال زیر ارائه‌ای را به PDF صادر می‌کند و هشدارهای جایگزینی قلم را در کنسول چاپ می‌کند. هشدار تنها زمانی چاپ می‌شود که قلمی در دسترس نباشد و در طول خروجی جایگزین شود. از یک پروکسی JPype برای دریافت فراخوانی‌های هشدار از API جاوا استفاده کنید. قبل از بررسی پیشوند، رشته توضیحی جاوا را به رشتهٔ Python تبدیل کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, ReturnAction, SaveFormat, WarningType

class FontSubstitutionHandler:
    def warning(self, warning):
        description = str(warning.getDescription())
        if warning.getWarningType() == WarningType.DataLoss and description.startswith("Font will be substituted"):
            print(f"Font substitution warning: {description}")
        return ReturnAction.Continue


handler = FontSubstitutionHandler()
callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)

pdf_options = PdfOptions()
pdf_options.setWarningCallback(callback)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="نکته" %}}

برای اطلاعات بیشتر درباره جایگزینی قلم‌ها، مقالهٔ [Font Substitution](/slides/fa/python-java/font-substitution/) را ببینید.

{{% /alert %}}

## **تبدیل اسلایدهای انتخابی از PowerPoint به PDF**

شماره‌های اسلایدی که به متد [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) پاس می‌شوند، از 1 شروع می‌شوند. این مثال اسلایدهای 1 و 3 را (در صورت موجود بودن) صادر می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
    presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **تبدیل PowerPoint به PDF با اندازه اسلاید سفارشی**

این مثال اولین اسلاید را بر صفحه‌ای به اندازهٔ 612 در 792 نقطه (US Letter) صادر می‌کند. اسلاید را در یک ارائهٔ جدید با اندازهٔ مشخص کپی می‌کند و محتویات اسلاید را برای پر کردن مقیاس می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
resized_presentation = Presentation()
try:
    resized_presentation.getSlideSize().setSize(612, 792, SlideSizeScaleType.EnsureFit)
    slide = presentation.getSlides().get_Item(0)
    resized_presentation.getSlides().insertClone(0, slide)

    # اسلاید خالی که ارائه جدید با آن ایجاد شده بود را حذف کنید.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **تبدیل PowerPoint به PDF در نمای اسلایدهای یادداشت‌ها**

مثال زیر ارائه‌ای را به PDF صادر می‌کند که یادداشت‌های سخنران هر اسلاید زیر اسلاید قرار می‌گیرد. برای دیدن نتیجه، از ارائه‌ای حاوی یادداشت‌های سخنران استفاده کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

notes_options = NotesCommentsLayoutingOptions()
notes_options.setNotesPosition(NotesPositions.BottomFull)

pdf_options = PdfOptions()
pdf_options.setSlidesLayoutOptions(notes_options)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **دسترس‌پذیری و استانداردهای سازگاری برای PDF**

هنگام تهیه PDFهای دسترس‌پذیر، به [راهنمای دسترس‌پذیری محتوای وب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) مراجعه کنید. با استفاده از [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) می‌توانید یک استاندارد خروجی انتخاب کنید: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد فرآیند تبدیل PowerPoint به PDF را نشان می‌دهد که بر اساس استانداردهای مختلف سازگاری چندین PDF تولید می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()

    pdf_options.setCompliance(PdfCompliance.PdfA1a)
    presentation.save("presentation-a1a.pdf", SaveFormat.Pdf, pdf_options)

    pdf_options.setCompliance(PdfCompliance.PdfA1b)
    presentation.save("presentation-a1b.pdf", SaveFormat.Pdf, pdf_options)
    
    pdf_options.setCompliance(PdfCompliance.PdfUa)
    presentation.save("presentation-ua.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

> **نکته:** هنگام خروجی به PDF/UA، Aspose.Slides گرافیک‌های پیچیده مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد درنظر می‌گیرد. عناصر مسیر به‌صورت جداگانه حفظ نمی‌شوند و ممکن است به‌عنوان artifacts علامت‌گذاری شوند؛ متن جایگزین تنها برای کل شکل ارائه می‌شود.

## **سوالات متداول**

**آیا می‌توانم چندین فایل PowerPoint را به‌صورت دسته‌ای به PDF تبدیل کنم؟**

بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌نویسی روی فایل‌های خود حلقه بزنید و فرآیند تبدیل را اعمال کنید.

**آیا می‌توان PDF تبدیل‌شده را با رمز عبور محافظت کرد؟**

بله. از کلاس [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) برای تعیین رمز عبور و تعریف مجوزهای دسترسی هنگام تبدیل استفاده کنید.

**چگونه اسلایدهای مخفی را در PDF گنجانده کنم؟**

متد [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) را با مقدار `True` در کلاس [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) فراخوانی کنید تا اسلایدهای مخفی در PDF نهایی گنجانده شوند.

**آیا Aspose.Slides می‌تواند کیفیت تصویر بالا را در PDF حفظ کند؟**

بله، می‌توانید با استفاده از روش‌هایی مانند [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) و [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) در کلاس [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) کیفیت تصویر را کنترل کنید تا تصاویر با کیفیت بالا در PDF شما باشد.

**آیا Aspose.Slides استانداردهای سازگاری PDF/A را پشتیبانی می‌کند؟**

بله، Aspose.Slides به شما امکان می‌دهد PDFهایی صادر کنید که با [استانداردهای مختلف](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/) از جمله PDF/A1a، PDF/A1b و PDF/UA سازگار باشند، برای دسترس‌پذیری یا آرشیو. استاندارد مناسب را انتخاب کنید و خروجی را بر حسب نیازهای خود ارزیابی کنید.

## **منابع اضافی**

- [Aspose.Slides for Python via Java Documentation](/slides/fa/python-java/)
- [Aspose.Slides for Python via Java API Reference](https://reference.aspose.com/slides/python-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)