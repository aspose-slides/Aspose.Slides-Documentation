---
title: "تبدیل PPT و PPTX به PDF در Python از طریق Java [ویژگی‌های پیشرفته گنجانده شده]"
linktitle: "PowerPoint به PDF"
type: docs
weight: 40
url: /fa/python-java/convert-powerpoint-to-pdf/
keywords:
- "تبدیل PowerPoint"
- "تبدیل ارائه"
- "PowerPoint به PDF"
- "ارائه به PDF"
- "PPT به PDF"
- "تبدیل PPT به PDF"
- "PPTX به PDF"
- "تبدیل PPTX به PDF"
- "ذخیره PowerPoint به عنوان PDF"
- "ذخیره PPT به عنوان PDF"
- "ذخیره PPTX به عنوان PDF"
- "صادرات PPT به PDF"
- "صادرات PPTX به PDF"
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "تبدیل PowerPoint PPT/PPTX به PDFهای با کیفیت بالا و قابل جستجو در Python از طریق Java با استفاده از Aspose.Slides، با مثال‌های کد سریع و گزینه‌های پیشرفته تبدیل."
---
## **بررسی کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP و غیره) به فرمت PDF در Python با استفاده از Java چندین مزیت دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ چینش و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای پنهان را شامل کنید، فایل‌های PDF را با رمز عبور محافظت کنید، جایگزینی فونت‌ها را شناسایی کنید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای سازگاری را بر اسناد خروجی اعمال کنید.

## **تبدیل PowerPoint به PDF**

با استفاده از Aspose.Slides می‌توانید ارائه‌ها را در فرمت‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به عنوان آرگومان به کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بدهید و سپس ارائه را با استفاده از متد [save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) به PDF ذخیره کنید. کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) متد [save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) را در اختیار می‌گذارد که معمولاً برای تبدیل یک ارائه به PDF استفاده می‌شود.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java اطلاعات API و شماره نسخه خود را در اسناد خروجی درج می‌کند. به عنوان مثال، هنگام تبدیل یک ارائه به PDF، Aspose.Slides فیلد Application را با "*Aspose.Slides*" و فیلد PDF Producer را با مقداری به شکل "*Aspose.Slides v XX.XX*" پر می‌کند. **توجه** داشته باشید که نمی‌توانید به Aspose.Slides دستور دهید این اطلاعات را از اسناد خروجی حذف یا تغییر دهد.
{{% /alert %}}

Aspose.Slides به شما امکان می‌دهد:

* کل ارائه‌ها را به PDF تبدیل کنید
* اسلایدهای خاصی از یک ارائه را به PDF تبدیل کنید

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد PDFهای تولید شده به‌دقت با ارائه‌های اصلی مطابقت داشته باشند. عناصر و ویژگی‌ها به‌صورت دقیق در تبدیل رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و شکل‌ها
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندها
* سرصفحه‌ها و پاورقی‌ها
* بولت‌ها
* جدول‌ها

## **تبدیل PowerPoint به PDF**

تبدیل استاندارد از تنظیمات پیش‌فرض خروجی PDF استفاده می‌کند. هنگام نیاز به کنترل کیفیت تصویر، محتوای صفحه یا سازگاری PDF، از گزینه‌های سفارشی استفاده کنید.

قبل از اجرای مثال‌ها، [Aspose.Slides for Python via Java](/slides/fa/python-java/installation/) و یک محیط اجرایی Java سازگار را نصب کنید. هر مثال فایل `presentation.pptx` را از پوشه کاری فعلی می‌خواند؛ آن را با فایل PPT، PPTX یا ODP خود جایگزین کنید. JVM را یکبار برای هر فرآیند Python راه‌اندازی کنید.

این کد یک ارائه را به PDF تبدیل می‌کند:

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

{{% alert color="info" title="Note" %}}
Aspose یک مبدل آنلاین رایگان **PowerPoint به PDF** در [اینجا](https://products.aspose.app/slides/fa/conversion/ppt-to-pdf) ارائه می‌دهد که فرایند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با این مبدل یک تست زنده از روش شرح داده‌شده انجام دهید.
{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—ویژگی‌های موجود در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/)—را فراهم می‌کند که به شما اجازه می‌دهد PDF نهایی را تنظیم کنید، با رمز عبور قفل کنید یا نحوه پیشرفت فرایند تبدیل را مشخص کنید.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های تبدیل سفارشی می‌توانید تنظیمات کیفیت دلخواه برای تصاویر رستر، نحوه پردازش متافایل‌ها، سطح فشرده‌سازی متن، DPI برای تصاویر و موارد دیگر را تعریف کنید.

مثال کد زیر نشان می‌دهد چگونه یک ارائه PowerPoint را به PDF با چندین گزینه سفارشی تبدیل کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setJpegQuality(jpype.JByte(90))
    pdf_options.setSufficientResolution(300)
    pdf_options.setSaveMetafilesAsPng(True)
    pdf_options.setTextCompression(PdfTextCompression.Flate)
    pdf_options.setCompliance(PdfCompliance.Pdf15)
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **تبدیل PowerPoint به PDF با اسلایدهای پنهان**

اگر ارائه‌ای شامل اسلایدهای پنهان باشد، می‌توانید با استفاده از متد [setShowHiddenSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) از کلاس [PdfOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/) اسلایدهای پنهان را به عنوان صفحات در PDF نهایی گنجانده و تبدیل کنید.

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را به PDF با اسلایدهای پنهان گنجانده تبدیل کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setShowHiddenSlides(True)
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **تبدیل PowerPoint به PDF با حفاظت با رمز عبور**

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را به PDF محافظت‌شده با رمز عبور تبدیل کنید باستخدام پارامترهای حفاظتی از کلاس [PdfOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setPassword("password")
    permissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint
    pdf_options.setAccessPermissions(permissions)
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **تشخیص جایگزینی فونت‌ها**

Aspose.Slides متد [setWarningCallback](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveoptions/#setWarningCallback) را در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/) فراهم می‌کند تا بتوانید جایگزینی فونت‌ها را در طول فرایند تبدیل ارائه به PDF شناسایی کنید.

از یک پراکسی JPype برای دریافت فراخوانی‌های هشدار از API جاوا استفاده کنید. قبل از بررسی پیشوند رشته توضیح Java، آن را به رشته Python تبدیل کنید:

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


presentation = Presentation("presentation.pptx")
try:
    handler = FontSubstitutionHandler()
    callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
    pdf_options = PdfOptions()
    pdf_options.setWarningCallback(callback)
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
برای اطلاعات بیشتر درباره دریافت فراخوانی‌های هشدار برای جایگزینی فونت‌ها در طول رندر، به [دریافت فراخوانی‌های هشدار برای جایگزینی فونت‌ها](/slides/fa/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) مراجعه کنید.

برای اطلاعات بیشتر درباره جایگزینی فونت، مقاله [جایگزینی فونت](/slides/fa/python-java/font-substitution/) را ببینید.
{{% /alert %}}

## **تبدیل اسلایدهای انتخابی PowerPoint به PDF**

شماره اسلایدهای پاس داده‌شده به [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) از 1 شروع می‌شود. این مثال اسلایدهای 1 و 3 را (در صورتی که موجود باشند) صادر می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    if presentation.getSlides().size() >= 3:
        slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
        presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
    else:
        print("The presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

## **تبدیل PowerPoint به PDF با اندازه اسلاید سفارشی**

این مثال اولین اسلاید را روی صفحه‌ای به ابعاد 612 در 792 پوینت (US Letter) صادر می‌کند. اسلاید را به یک ارائه جدید با اندازه مشخص کپی می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
try:
    resized_presentation = Presentation()
    try:
        resized_presentation.getSlideSize().setSize(612.0, 792.0, SlideSizeScaleType.EnsureFit)
        if presentation.getSlides().size() > 0:
            slide = presentation.getSlides().get_Item(0)
            resized_presentation.getSlides().insertClone(0, slide)
            resized_presentation.getSlides().removeAt(1)
            resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
        else:
            print("The presentation contains no slides.")
    finally:
        resized_presentation.dispose()
finally:
    presentation.dispose()
```

## **تبدیل PowerPoint به PDF در نمای اسلاید یادداشت‌ها**

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را به PDF که شامل یادداشت‌ها است تبدیل کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **دسترس‌پذیری و استانداردهای سازگاری برای PDF**

هنگام تهیه PDFهای دسترس‌پذیر، به [راهنمای WCAG]((https://www.w3.org/TR/WCAG-TECHS/pdf.html)) مراجعه کنید. از [PdfOptions.setCompliance](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/#setCompliance) برای انتخاب یک استاندارد خروجی استفاده کنید: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد یک فرایند تبدیل PowerPoint به PDF را نشان می‌دهد که بر پایه استانداردهای مختلف سازگاری چندین PDF تولید می‌کند:

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

> **توجه:** هنگام خروجی به PDF/UA، Aspose.Slides گرافیک‌های پیچیده مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. عناصر مسیر جداگانه حفظ نمی‌شوند و ممکن است به عنوان artefact علامت‌گذاری شوند؛ متن جایگزین تنها برای کل شکل ارائه می‌شود.

## **سؤالات متداول**

**آیا می‌توانم چندین فایل PowerPoint را به طور دسته‌ای به PDF تبدیل کنم؟**

بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌ای بر روی فایل‌های خود تکرار کنید و فرایند تبدیل را اعمال کنید.

**آیا می‌توان PDF تبدیل‌شده را با رمز عبور محافظت کرد؟**

بله. از کلاس [PdfOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/) برای تنظیم رمز عبور و تعریف مجوزهای دسترسی در طول فرایند تبدیل استفاده کنید.

**چگونه می‌توانم اسلایدهای پنهان را در PDF گنجاندم؟**

از متد [setShowHiddenSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/) برای گنجاندن اسلایدهای پنهان در PDF نهایی استفاده کنید.

**آیا Aspose.Slides می‌تواند کیفیت تصویر بالا را در PDF حفظ کند؟**

بله، می‌توانید با استفاده از متدهایی مانند [setJpegQuality](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/#setJpegQuality) و [setSufficientResolution](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/#setSufficientResolution) در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/) کیفیت تصویر بالا را در PDF خود تضمین کنید.

**آیا Aspose.Slides از استانداردهای سازگاری PDF/A پشتیبانی می‌کند؟**

بله، Aspose.Slides به شما امکان می‌دهد PDFهایی صادر کنید که با [استانداردهای مختلف]((https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfcompliance/)) از جمله PDF/A1a، PDF/A1b و PDF/UA مطابقت داشته باشند، برای دسترس‌پذیری یا آرشیو. استاندارد مناسب را انتخاب کنید و خروجی را نسبت به نیازهای خود ارزیابی کنید.

## **منابع تکمیلی**

- [مستندات Aspose.Slides for Python via Java](/slides/fa/python-java/)
- [مرجع API Aspose.Slides for Python via Java](https://reference.aspose.com/slides/fa/python-java/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/fa/conversion)