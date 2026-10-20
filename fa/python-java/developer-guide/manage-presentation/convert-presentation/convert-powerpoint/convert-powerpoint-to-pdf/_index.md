---
title: تبدیل PPT و PPTX به PDF در پایتون از طریق جاوا [ویژگی‌های پیشرفته گنجانده شده]
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
- صادر کردن PPT به PDF
- صادر کردن PPTX به PDF
- پیوست
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "تبدیل PowerPoint PPT/PPTX به PDFهای با کیفیت بالا و قابل جستجو در پایتون از طریق جاوا با استفاده از Aspose.Slides، با مثال‌های کد سریع و گزینه‌های پیشرفته تبدیل."
---
## **مرور کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP و غیره) به فرمت PDF در پایتون از طریق جاوا مزایای متعددی دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ چیدمان و قالب‌بندی ارائه شما. این راهنما نحوه تبدیل ارائه‌ها به اسناد PDF، استفاده از گزینه‌های مختلف برای کنترل کیفیت تصویر، گنجاندن اسلایدهای مخفی، اعمال رمز عبور بر روی فایل‌های PDF، شناسایی جایگزینی‌های فونت، انتخاب اسلایدهای خاص برای تبدیل و اعمال استانداردهای سازگاری بر اسناد خروجی را نشان می‌دهد.

## **تبدیل PowerPoint به PDF**

با استفاده از Aspose.Slides می‌توانید ارائه‌ها را در فرمت‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به عنوان آرگومان به کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) پاس دهید و سپس ارائه را با استفاده از متد [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) به PDF ذخیره کنید. کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) متد [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) را که معمولاً برای تبدیل ارائه به PDF استفاده می‌شود، در اختیار می‌گذارد.

{{% alert color="info" title="توجه" %}}

Aspose.Slides برای Python از طریق Java اطلاعات API و شماره نسخه خود را در اسناد خروجی وارد می‌کند. به عنوان مثال، هنگام تبدیل یک ارائه به PDF، Aspose.Slides فیلد Application را با "*Aspose.Slides*" و فیلد PDF Producer را با مقداری به شکل "*Aspose.Slides v XX.XX*" پر می‌کند. **توجه** داشته باشید که نمی‌توانید Aspose.Slides را مجبور کنید این اطلاعات را از اسناد خروجی حذف یا تغییر دهد.

{{% /alert %}}

Aspose.Slides به شما امکان می‌دهد:

* کل ارائه‌ها را به PDF تبدیل کنید
* اسلایدهای خاصی از یک ارائه را به PDF تبدیل کنید

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد که PDFهای تولید شده نزدیک به ارائه‌های اصلی باشند. عناصر و ویژگی‌ها به طور دقیق در تبدیل رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و اشکال
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندهای ابرمتنی
* سرصفحه و پانویس
* نمادهای گلوله‌ای
* جدول‌ها

## **تبدیل PowerPoint به PDF**

تبدیل استاندارد از تنظیمات پیش‌فرض خروجی PDF استفاده می‌کند. هنگام نیاز به کنترل کیفیت تصویر، محتوای صفحه یا سازگاری PDF، از گزینه‌های سفارشی استفاده کنید.

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

{{% alert color="info" title="توجه" %}}

Aspose یک [مبدل رایگان آنلاین PowerPoint به PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf) ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با این مبدل یک تست زنده از روند شرح داده شده انجام دهید.

{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—ویژگی‌های موجود در کلاس [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)—را فراهم می‌کند که به شما امکان می‌دهد PDF خروجی را سفارشی کنید، PDF را با رمز عبور قفل کنید یا مشخص کنید فرآیند تبدیل چگونه پیش رود.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی می‌توانید تنظیمات کیفیت دلخواه خود را برای تصاویر رستری، نحوه‌ی پردازش متافایل‌ها، سطح فشرده‌سازی متن، DPI تصاویر و موارد دیگر تعریف کنید.

مثال زیر یک ارائه را با PDF 1.5، کیفیت JPEG برابر 90، وضوح تصویر 300 DPI، ذخیره‌سازی متافایل‌ها به صورت PNG و فشرده‌سازی متن Flate صادر می‌کند.

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

### **انتخاب خودکار فشرده‌سازی تصویر**

وقتی یک ارائه حاوی تعداد زیادی عکس یا اسکرین‌شات باشد، کاهش حجم PDF صادر شده می‌تواند ارسال ایمیل یا دانلود را آسان‌تر کند. برای انتخاب خودکار مناسب‌ترین الگوریتم فشرده‌سازی برای هر تصویر هنگام خروجی PDF، متد [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setBestImagesCompressionRatio) را با مقدار `True` فراخوانی کنید.

مثال زیر یک ارائه موجود را بارگذاری کرده، انتخاب خودکار فشرده‌سازی تصویر را فعال می‌کند و آن را به یک سند PDF ذخیره می‌کند. تمام تنظیمات دیگر خروجی PDF مقدار پیش‌فرض خود را حفظ می‌کنند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setBestImagesCompressionRatio(True)

presentation = Presentation("image-heavy.pptx")
try:
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

این گزینه برای هر تصویر یک الگوریتم فشرده‌سازی انتخاب می‌کند. کاهش مقدار پاس داده شده به [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) کیفیت تصویر JPEG را پایین می‌آورد، در حالی که کاهش مقدار پاس داده شده به [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) اجازه می‌دهد تصاویر به وضوح پایین‌تری کاهش نمونه شوند که می‌تواند جزئیات را کاهش دهد. فعال‌سازی انتخاب خودکار فشرده‌سازی به خودی خود هیچ‌یک از این تنظیمات را پایین نمی‌آورد.

انتخاب الگوریتم‌های فشرده‌سازی تصویر نیاز به زمان پردازش و حافظه بیشتری دارد. کاهش حجم بستگی به تصاویر ارائه و تنظیمات خروجی دارد؛ کاهش ثابت برای هر ارائه تضمین نشده است.

### **حفظ فایل‌های OLE نهفته به عنوان پیوست‌های PDF**

اگر ارائه شامل یک دفتر کار Excel نهفته باشد، ممکن است بخواهید دریافت‌کنندگان PDF بتوانند به داده‌های دفتر کار دسترسی داشته باشند و اسلایدها را نیز مشاهده کنند. برای حفظ فایل‌های OLE نهفته به عنوان پیوست در PDF نتیجه، متد [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) را با مقدار `True` فراخوانی کنید.

مقدار پیش‌فرض `False` است: تصویر پیش‌نمایش یا آیکون شیء OLE بر روی صفحه PDF رندر می‌شود، اما فایل نهفته به عنوان پیوست گنجانده نمی‌شود. تنظیم این گزینه به `True` علاوه بر این داده‌های فایل را نیز شامل می‌شود. پیش‌نمایش همچنان یک نمایش بصری است؛ پیوست به دریافت‌کنندگان اجازه می‌دهد فایل نهفته را به‌طور جداگانه باز یا ذخیره کنند. شیء OLE تبدیل به یک ورک‌شیت تعاملی Excel در صفحه PDF نمی‌شود.

مثال زیر یک ارائه را که قبلاً شامل یک دفتر کار Excel نهفته است، بارگذاری می‌کند و آن را به PDF با پیوست دفتر کار صادر می‌کند.

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

1. PDF صادر شده را در نمایشگری که از پیوست‌های فایل پشتیبانی می‌کند، مانند Adobe Acrobat Reader باز کنید.
2. پنل **Attachments** نمایشگر را باز کنید و دفتر کار نهفته را پیدا کنید.
3. پیوست را ذخیره کنید و در Excel باز کنید تا داده‌های آن را بررسی کنید، یا اگر نمایشگر اجازه می‌دهد مستقیماً باز کنید. پیش‌نمایش بر روی صفحه PDF جدا از پیوست است.

{{% alert color="info" title="توجه" %}}

استانداردهای PDF/A محدودیت‌هایی برای پیوست‌ها اعمال می‌کنند: PDF/A-1 از فایل‌های نهفته منع می‌کند، PDF/A-2 فقط اجازه پیوست‌های PDF/A را می‌دهد و PDF/A-3 انواع فایل‌های دیگر از جمله دفتر کارهای Excel را مجاز می‌داند. این موارد الزامات استانداردها هستند، نه محدودیت‌های خاص Aspose.Slides. این مثال از تنظیم پیش‌فرض سازگاری PDF استفاده می‌کند و خروجی PDF/A را نشان نمی‌دهد.

{{% /alert %}}

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر ارائه شامل اسلایدهای مخفی باشد، می‌توانید با استفاده از متد [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) از کلاس [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) اسلایدهای مخفی را به عنوان صفحات در PDF نهایی گنجانید.

مثال زیر یک ارائه را به PDF صادر می‌کند و هر اسلاید مخفی را نیز شامل می‌شود.

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

### **تبدیل PowerPoint به PDF با رمز عبور**

مثال زیر یک ارائه را به PDF صادر می‌کند که برای باز کردن به رمز عبور `password` نیاز دارد. مجوزهای دسترسی اجازه چاپ، از جمله چاپ با کیفیت بالا، را می‌دهد.

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

### **تشخیص جایگزینی فونت‌ها**

Aspose.Slides متد [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) را تحت کلاس [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) فراهم می‌کند تا بتوانید در طول فرآیند تبدیل ارائه به PDF، جایگزینی‌های فونت را شناسایی کنید.

مثال زیر یک ارائه را به PDF صادر می‌کند و هشدارهای جایگزینی فونت را در کنسول چاپ می‌کند. هشدار فقط زمانی چاپ می‌شود که یک فونت موجود نباشد و هنگام خروجی جایگزین شود. برای دریافت بازخوانی هشدارها از API جاوا از یک پراکسی JPype استفاده کنید. قبل از بررسی پیشوند، رشته توصیفی جاوا را به رشته پایتون تبدیل کنید:

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

{{% alert color="info" title="توجه" %}}

برای اطلاعات بیشتر درباره جایگزینی فونت، مقاله [Font Substitution](/slides/fa/python-java/font-substitution/) را ببینید.

{{% /alert %}}

### **مدیریت فونت‌های بدون نوع بولد اختصاصی**

یک ارائه می‌تواند قالب‌بندی بولد را بر روی متنی اعمال کند حتی اگر فونت آن نوع بولد اختصاصی نداشته باشد. متن می‌تواند از طریق بولد مصنوعی که گلیف‌های عادی را ضخیم می‌کند، به‌ظاهر بولد باشد. زمانی که این متن در PDF بیش از حد سنگین یا متفاوت از ظاهر موردنظر به‌نظر می‌رسد، می‌توانید با فراخوانی [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles) مقدار `True` را تنظیم کنید. این گزینه متن تحت تأثیر را به عنوان بیت‌مپ رستر می‌کند و می‌تواند ظاهر آن را برای برخی فونت‌ها بهبود بخشد. مقدار پیش‌فرض `False` است.

ارائه نمونه شامل دو جعبه متن است: یکی با متن عادی و دیگری با قالب‌بندی بولد بر روی همان فونت که نوع بولد اختصاصی ندارد. مثال زیر ارائه را بارگذاری می‌کند، رستر کردن سبک‌های فونت پشتیبانی‌نشده را فعال می‌کند و به PDF صادر می‌نماید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setRasterizeUnsupportedFontStyles(True)

presentation = Presentation("unsupported-bold.pptx")
try:
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

پیشنمایش‌های زیر خروجی غیرفعال و فعال را نشان می‌دهند. در این مثال، متن بولد با گزینه غیرفعال خطوط سنگین‌تری دارد. با فعال‌سازی گزینه، خطوط آن سبک‌تر هستند؛ متن عادی تغییری نمی‌کند. نتایج را قبل از انتخاب تنظیمات برای ارائه خود مقایسه کنید.

| گزینه غیرفعال (`False`، پیش‌فرض) | گزینه فعال (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

در این مثال، فعال‌سازی گزینه تنها متن بولد را به بیت‌مپ تبدیل می‌کند: بدون OCR نمی‌توان آن را انتخاب، کپی یا جستجو کرد و خطوط آن در بزرگ‌نمایی 800٪ نرم‌تر به‌نظر می‌رسند. متن عادی جست‌پذیر می‌ماند. با غیرفعال بودن گزینه، هر دو رشته به صورت متن باقی می‌مانند.

این گزینه متنی که به‌صورت بولد قالب‌بندی شده و فونت آن نوع بولد اختصاصی ندارد را رستر می‌کند. [Font substitution](/slides/fa/python-java/font-substitution/) به‌جای آن یک فونت دیگر را زمانی که فونت اصلی موجود نباشد، انتخاب می‌کند.

## **تبدیل اسلایدهای انتخابی از PowerPoint به PDF**

شماره اسلایدهای پاس داده شده به [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) به صورت 1‑Based است. این مثال اسلایدهای 1 و 3 را (در صورتی که وجود داشته باشند) صادر می‌کند:

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

این مثال اولین اسلاید را روی صفحه‌ای با ابعاد 612 در 792 نقطه (US Letter) صادر می‌کند. اسلاید را به یک ارائه جدید با اندازه مشخص کلون می‌کند و محتوای اسلاید را برای جاگیری مقیاس می‌دهد.

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

    # اسلاید خالی که ارائه جدید با آن ساخته شده بود را حذف کنید.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **تبدیل PowerPoint به PDF در نمای اسلاید یادداشت‌ها**

مثال زیر یک ارائه را به PDF صادر می‌کند و یادداشت‌های سخنران هر اسلاید را زیر اسلاید قرار می‌دهد. برای مشاهده نتیجه، از یک ارائه دارای یادداشت‌های سخنران استفاده کنید.

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

## **دسترسی‌پذیری و استانداردهای سازگاری برای PDF**

هنگام تهیه PDFهای دسترسی‌پذیر، به [راهنمایی‌های دسترسی محتوای وب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) مراجعه کنید. برای انتخاب یک استاندارد خروجی از متد [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) استفاده کنید: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد یک فرآیند تبدیل PowerPoint به PDF را نشان می‌دهد که بر اساس استانداردهای مختلف سازگاری، چندین PDF تولید می‌کند:

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

> **توجه:** هنگام خروجی به PDF/UA، Aspose.Slides گرافیک‌های پیچیده مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. عناصر مسیر جداگانه به‌عنوان محتوای مستقل حفظ نمی‌شوند و ممکن است به‌عنوان مصنوعات علامت‌گذاری شوند؛ متن جایگزینی فقط برای کل شکل فراهم می‌شود.

## **سوالات متداول**

**آیا می‌توانم چندین فایل PowerPoint را به صورت دسته‌ای به PDF تبدیل کنم؟**

بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌نویسی بر روی فایل‌هایتان پیمایش کنید و فرآیند تبدیل را اعمال کنید.

**آیا امکان قفل‌گذاری با رمز عبور بر روی PDF تبدیل‌شده وجود دارد؟**

بله. از کلاس [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) برای تنظیم رمز عبور و تعریف مجوزهای دسترسی در طول فرآیند تبدیل استفاده کنید.

**چگونه اسلایدهای مخفی را در PDF گنجانده کنم؟**

در کلاس [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) متد [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) را با مقدار `True` فراخوانی کنید تا اسلایدهای مخفی در PDF نهایی گنجانده شوند.

**آیا Aspose.Slides می‌تواند کیفیت بالای تصویر را در PDF حفظ کند؟**

بله؛ می‌توانید با استفاده از متدهایی مانند [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) و [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) در کلاس [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) کیفیت تصویر را کنترل کنید و تصاویر با کیفیت بالا در PDF داشته باشید.

**آیا Aspose.Slides استانداردهای سازگاری PDF/A را پشتیبانی می‌کند؟**

بله؛ Aspose.Slides به شما امکان می‌دهد PDFهایی صادر کنید که با [استانداردهای مختلف](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/) از جمله PDF/A1a، PDF/A1b و PDF/UA سازگار باشند، برای دسترسی‌پذیری یا بایگانی. استاندارد مناسب را انتخاب کنید و خروجی را با نیازهای خود مقایسه کنید.

## **منابع اضافی**

- [مستندات Aspose.Slides برای Python از طریق Java](/slides/fa/python-java/)
- [مرجع API Aspose.Slides برای Python از طریق Java](https://reference.aspose.com/slides/python-java/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/conversion)