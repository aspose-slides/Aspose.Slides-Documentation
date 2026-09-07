---
title: تبدیل PPT و PPTX به PDF در Python از طریق Java [شامل ویژگی‌های پیشرفته]
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
- صادرات PPT به PDF
- صادرات PPTX به PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- پایتون
- جاوا
- Aspose.Slides
description: "تبدیل PowerPoint PPT/PPTX به PDFهای با کیفیت بالا و قابل جستجو در Python از طریق Java با استفاده از Aspose.Slides، همراه با مثال‌های سریع کد و گزینه‌های پیشرفته تبدیل."
---
## **نمای کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP و غیره) به فرمت PDF در Python از طریق Java مزایای متعددی دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ چیدمان و فرمت‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای مخفی را گنجانید، فایل‌های PDF را با رمز عبور محافظت کنید، جایگزینی فونت‌ها را شناسایی کنید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای انطباق را بر اسناد خروجی اعمال کنید.

## **تبدیل PowerPoint به PDF**

با استفاده از Aspose.Slides می‌توانید ارائه‌ها را در قالب‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به عنوان آرگومان به کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) پاس دهید و سپس ارائه را با استفاده از متد [save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) به PDF ذخیره کنید. کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) متد [save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) را ارائه می‌دهد که معمولاً برای تبدیل یک ارائه به PDF استفاده می‌شود.

{{% alert color="info" title="Note" %}}
Aspose.Slides برای Python از طریق Java اطلاعات API و شماره نسخه خود را به اسناد خروجی اضافه می‌کند. برای مثال، هنگام تبدیل یک ارائه به PDF، Aspose.Slides فیلد Application را با "*Aspose.Slides*" و فیلد PDF Producer را با مقداری به شکل "*Aspose.Slides v XX.XX*" پر می‌کند. **Note** اینکه شما نمی‌توانید Aspose.Slides را مجبور کنید این اطلاعات را در اسناد خروجی تغییر یا حذف کند.
{{% /alert %}}

Aspose.Slides به شما اجازه می‌دهد:

* کل ارائه‌ها به PDF
* اسلایدهای خاصی از یک ارائه به PDF

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد PDF‌های حاصل به‌خوبی با ارائه‌های اصلی مطابقت داشته باشند. عناصر و ویژگی‌ها به‌دقت در تبدیل رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و شکل‌ها
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندها
* سرصفحه‌ها و پانویس‌ها
* نقاط بولت
* جداول

## **تبدیل PowerPoint به PDF**

تبدیل استاندارد از تنظیمات پیش‌فرض خروجی PDF استفاده می‌کند. هنگامی که نیاز به کنترل کیفیت تصویر، محتوای صفحه یا انطباق PDF دارید، از گزینه‌های سفارشی استفاده کنید.

قبل از اجرای مثال‌ها، [Aspose.Slides for Python via Java](/slides/fa/python-java/installation/) و یک زمان‌اجرای Java سازگار را نصب کنید. هر مثال فایل `presentation.pptx` را از پوشهٔ کاری فعلی می‌خواند؛ آن را با فایل PPT، PPTX یا ODP خود جایگزین کنید. JVM را تنها یک‌بار برای هر فرآیند Python راه‌اندازی کنید.

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
Aspose یک **مبدل آنلاین رایگان PowerPoint به PDF** ارائه می‌دهد که فرایند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با این مبدل یک تست انجام دهید تا پیاده‌سازی زندهٔ روشی که در اینجا توضیح داده شده است را مشاهده کنید.
{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—ویژگی‌های تحت کلاس [PdfOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/)—را ارائه می‌دهد که به شما امکان می‌دهد PDF حاصل را شخصی‌سازی کنید، PDF را با رمز عبور قفل کنید یا نحوهٔ پیشرفت فرآیند تبدیل را مشخص کنید.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی می‌توانید تنظیم کیفیت ترجیحی برای تصاویر رستری را تعریف کنید، نحوهٔ پردازش متافایل‌ها را مشخص کنید، سطح فشرده‌سازی متن را تنظیم کنید، DPI تصاویر را پیکربندی کنید و موارد دیگر.

مثال کد زیر نشان می‌دهد چگونه ارائه PowerPoint را به PDF با چندین گزینه سفارشی تبدیل کنید.
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

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر یک ارائه شامل اسلایدهای مخفی باشد، می‌توانید از متد [setShowHiddenSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) کلاس [PdfOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/) استفاده کنید تا اسلایدهای مخفی به عنوان صفحه در PDF حاصل گنجانده شوند.

این کد نشان می‌دهد چگونه ارائه PowerPoint را به PDF با اسلایدهای مخفی گنجانده شده تبدیل کنید:
```python
import jpide
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

### **تبدیل PowerPoint به PDF با حفاظت رمز عبور**

این کد نشان می‌دهد چگونه ارائه PowerPoint را به یک PDF محافظت‌شده با رمز عبور تبدیل کنید با استفاده از پارامترهای حفاظت آورده‌شده در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/):
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

Aspose.Slides متد [setWarningCallback](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveoptions/#setWarningCallback) را تحت کلاس [PdfOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/) فراهم می‌کند تا بتوانید جایگزینی فونت‌ها را در طول فرآیند تبدیل ارائه به PDF شناسایی کنید.

از یک پراکسی JPype برای دریافت کال‌بک‌های هشدار از API جاوا استفاده کنید. قبل از بررسی پیشوند، رشتهٔ توضیح جاوا را به رشتهٔ Python تبدیل کنید:
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
برای اطلاعات بیشتر درباره دریافت کال‌بک‌های هشدار برای جایگزینی فونت‌ها در طول فرآیند رندرینگ، به [Getting Warning Callbacks for Fonts Substitution](/slides/fa/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) مراجعه کنید.

برای اطلاعات بیشتر درباره جایگزینی فونت‌ها، مقالهٔ [Font Substitution](/slides/fa/python-java/font-substitution/) را ببینید.
{{% /alert %}}

## **تبدیل اسلایدهای انتخابی در PowerPoint به PDF**

اعداد اسلایدهای پاس‌شده به متد [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) از ۱ شروع می‌شوند. این مثال اسلایدهای ۱ و ۳ را زمانی که هر دو موجود باشند، صادر می‌کند:
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

## **تبدیل PowerPoint به PDF با اندازه سفارشی اسلاید**

این مثال اسلاید اول را روی صفحه‌ای به اندازهٔ ۶۱۲ در ۷۹۲ پوینت (US Letter) صادر می‌کند. اسلاید را به ارائهٔ جدیدی با اندازهٔ مشخص شده کلون می‌کند:
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

## **تبدیل PowerPoint به PDF در نمای اسلایدهای یادداشت‌ها**

این کد نشان می‌دهد چگونه ارائه PowerPoint را به PDFی که شامل یادداشت‌ها است، تبدیل کنید:
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

## **استانداردهای دسترسی و انطباق برای PDF**

هنگام تهیهٔ PDFهای دسترس‌پذیر، به [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) مراجعه کنید. از [PdfOptions.setCompliance](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/#setCompliance) برای انتخاب استاندارد خروجی استفاده کنید: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد یک فرآیند تبدیل PowerPoint به PDF را نشان می‌دهد که بر اساس استانداردهای مختلف انطباق چند PDF تولید می‌کند:
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

> **Note:** هنگام خروجی به PDF/UA، Aspose.Slides گرافیک‌های پیچیده مانند SmartArt، نمودارها و فرمول‌ها را به صورت یک شکل واحد در نظر می‌گیرد. عناصر مسیر تک‌تک به عنوان محتوای جداگانه حفظ نمی‌شوند و ممکن است به عنوان artefacts علامت‌گذاری شوند؛ متن جایگزین فقط برای کل شکل ارائه می‌شود.

## **پرسش‌وپاسخ**

**آیا می‌توانم چندین فایل PowerPoint را به صورت دسته‌ای به PDF تبدیل کنم؟**  
بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌نویسی بر روی فایل‌های خود تکرار کنید و فرآیند تبدیل را اعمال کنید.

**آیا امکان محافظت از PDF تبدیل‌شده با رمز عبور وجود دارد؟**  
بله. از کلاس [PdfOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/) برای تنظیم یک رمز عبور و تعریف سطوح دسترسی در طول فرآیند تبدیل استفاده کنید.

**چگونه می‌توانم اسلایدهای مخفی را در PDF گنجانده کنم؟**  
از متد [setShowHiddenSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/) استفاده کنید تا اسلایدهای مخفی در PDF نهایی گنجانده شوند.

**آیا Aspose.Slides می‌تواند کیفیت بالای تصویر را در PDF حفظ کند؟**  
بله، می‌توانید با استفاده از متدهایی مانند [setJpegQuality](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/#setJpegQuality) و [setSufficientResolution](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/#setSufficientResolution) در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/) کیفیت تصویر بالا را در PDF خود تضمین کنید.

**آیا Aspose.Slides از استانداردهای انطباق PDF/A پشتیبانی می‌کند؟**  
بله، Aspose.Slides به شما امکان می‌دهد PDFهایی صادر کنید که با [استانداردهای مختلف](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfcompliance/) از جمله PDF/A1a، PDF/A1b و PDF/UA سازگار باشند، برای دسترس‌پذیری یا آرشیو. استاندارد مناسب را انتخاب کنید و خروجی را نسبت به نیازهای خود بازبینی کنید.

## **منابع بیشتر**

- [مستندات Aspose.Slides برای Python از طریق Java](/slides/fa/python-java/)
- [مرجع API Aspose.Slides برای Python از طریق Java](https://reference.aspose.com/slides/fa/python-java/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/fa/conversion)