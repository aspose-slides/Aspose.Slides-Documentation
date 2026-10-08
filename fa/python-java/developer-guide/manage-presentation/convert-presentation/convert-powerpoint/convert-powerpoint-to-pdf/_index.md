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
- صدور PPT به PDF
- صدور PPTX به PDF
- پیوست
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "تبدیل PowerPoint PPT/PPTX به PDFهای با کیفیت بالا و جستجوپذیر در Python از طریق Java با استفاده از Aspose.Slides، همراه با مثال‌های سریع کد و گزینه‌های پیشرفته تبدیل."
---
## **نمایش کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP و غیره) به فرمت PDF در Python از طریق Java مزایای متعددی دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ چیدمان و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای مخفی را شامل کنید، فایل‌های PDF را با رمز عبور محافظت کنید، جایگزینی قلم‌ها را شناسایی کنید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای انطباق را بر اسناد خروجی اعمال کنید.

## **تبدیل‌های پاورپوینت به PDF**

با استفاده از Aspose.Slides می‌توانید ارائه‌های در فرمت‌های زیر را به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به‌عنوان آرگومان به کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) پاس بدهید و سپس با استفاده از متد [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) ارائه را به PDF ذخیره کنید. کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) متد [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) را که معمولاً برای تبدیل یک ارائه به PDF استفاده می‌شود، در اختیار می‌گذارد.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python via Java اطلاعات API و شماره نسخه خود را به اسناد خروجی اضافه می‌کند. به‌عنوان مثال، هنگام تبدیل یک ارائه به PDF، Aspose.Slides فیلد Application را با "*Aspose.Slides*" و فیلد PDF Producer را با مقداری به شکل "*Aspose.Slides v XX.XX*" پر می‌کند. **توجه** داشته باشید که نمی‌توانید Aspose.Slides را وادار کنید این اطلاعات را از اسناد خروجی حذف یا تغییر دهد.

{{% /alert %}}

Aspose.Slides به شما امکان می‌دهد:

* کل ارائه‌ها را به PDF تبدیل کنید
* اسلایدهای خاصی از یک ارائه را به PDF تبدیل کنید

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد که PDFهای حاصل به‌خوبی با ارائه‌های اصلی مطابقت داشته باشند. عناصر و ویژگی‌ها به‌دقت در تبدیل رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و اشکال
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندهای ابرمتنی
* سرصفحه و پاورقی
* نقطه‌گذاری‌ها
* جداول

## **تبدیل پاورپوینت به PDF**

تبدیل استاندارد از تنظیمات پیش‌فرض خروجی PDF استفاده می‌کند. هنگام نیاز به کنترل کیفیت تصویر، محتویات صفحه یا انطباق PDF از گزینه‌های سفارشی استفاده کنید.

قبل از اجرای مثال‌ها، [Aspose.Slides for Python via Java](/slides/fa/python-java/installation/) و یک runtime جاوا سازگار را نصب کنید. هر مثال `presentation.pptx` را از پوشه کاری جاری می‌خواند؛ آن را با فایل PPT، PPTX یا ODP خود جایگزین کنید. JVM را یک‌بار برای هر فرآیند Python راه‌اندازی کنید.

مثال زیر یک ارائه را بارگذاری می‌کند و تمام اسلایدهای قابل دید را با تنظیمات پیش‌فرض به PDF ذخیره می‌کند.

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

Aspose یک مبدل آنلاین رایگان [**مبدل PowerPoint به PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با استفاده از این مبدل، یک آزمایش زنده از روشی که در اینجا توضیح داده شده است، انجام دهید.

{{% /alert %}}

## **تبدیل پاورپوینت به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—ویژگی‌های موجود در کلاس [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)—را فراهم می‌کند که به شما اجازه می‌دهد PDF حاصل را سفارشی کنید، آن را با رمز عبور قفل کنید یا نحوه پیشبرد فرآیند تبدیل را مشخص کنید.

### **تبدیل پاورپوینت به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های تبدیل سفارشی می‌توانید تنظیم کیفیت دلخواه برای تصاویر رستر، نحوه پردازش متافایل‌ها، سطح فشرده‌سازی متن، تنظیم DPI برای تصاویر و موارد دیگر را تعریف کنید.

مثال زیر یک ارائه را به PDF 1.5 صادر می‌کند که کیفیت JPEG روی 90 تنظیم شده، وضوح تصویر روی 300 DPI، متافایل‌ها به PNG ذخیره می‌شوند و فشرده‌سازی متن Flate به کار رفته است.

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

اگر یک ارائه شامل یک کتاب کاری Excel جاسازی‌شده باشد، ممکن است بخواهید دریافت‌کنندگان PDF به داده‌های کتاب کاری دسترسی داشته باشند و همچنین اسلایدها را مشاهده کنند. با فراخوانی متد [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) با مقدار `True`، فایل‌های OLE جاسازی‌شده به‌عنوان پیوست در PDF الناتج حفظ می‌شوند.

مقدار پیش‌فرض `False` است: تصویر پیش‌نمایش یا آیکون شیء OLE روی صفحه PDF رندر می‌شود، اما فایل جاسازی‌شده به‌عنوان پیوست اضافه نمی‌شود. تنظیم این گزینه به `True` به‌علاوه داده فایل را شامل می‌شود. پیش‌نمایش همچنان یک نمای بصری است؛ پیوست به دریافت‌کنندگان اجازه می‌دهد فایل جاسازی‌شده را به‌صورت جداگانه باز یا ذخیره کنند. شیء OLE تبدیل به یک کاربرگ تعاملی Excel در صفحه PDF نخواهد شد.

مثال زیر یک ارائه حاوی کتاب کاری Excel جاسازی‌شده را بارگذاری می‌کند و آن را با کتاب کاری به‌عنوان پیوست به PDF صادر می‌کند.

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

1. PDF صادرشده را در یک نمایشگری که از پیوست‌های فایل پشتیبانی می‌کند (مانند Adobe Acrobat Reader) باز کنید.
2. پنل **Attachments** نمایشگر را باز کنید و کتاب کاری جاسازی‌شده را بیابید.
3. پیوست را ذخیره کنید و در Excel باز کنید تا داده‌های آن را بررسی کنید، یا مستقیماً اگر نمایشگر اجازه دهد آن را باز کنید. پیش‌نمایش روی صفحه PDF جدا از پیوست است.

{{% alert color="info" title="Note" %}}

استانداردهای PDF/A محدودیت‌هایی برای پیوست‌ها اعمال می‌کنند: PDF/A-1 از فایل‌های جاسازی‌شده منع می‌کند، PDF/A-2 تنها اجازه پیوست‌های PDF/A را می‌دهد و PDF/A-3 انواع دیگر فایل‌ها از جمله کتاب‌های کاری Excel را می‌پذیرد. این موارد الزامات استانداردهاست و محدودیت‌های خاص Aspose.Slides نیستند. این مثال از تنظیم پیش‌فرض انطباق PDF استفاده می‌کند و خروجی PDF/A را نشان نمی‌دهد.

{{% /alert %}}

### **تبدیل پاورپوینت به PDF با اسلایدهای مخفی**

اگر یک ارائه شامل اسلایدهای مخفی باشد، می‌توانید با استفاده از متد [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) از کلاس [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) اسلایدهای مخفی را به‌عنوان صفحات در PDF حاصل درج کنید.

مثال زیر یک ارائه را به PDF صادر می‌کند که شامل اسلایدهای مخفی است.

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

### **تبدیل پاورپوینت به PDF با حفاظت توسط رمز عبور**

مثال زیر یک ارائه را به PDF‌ای صادر می‌کند که برای باز کردن آن نیاز به رمز عبور `password` دارد. مجوزهای دسترسی اجازه چاپ، از جمله چاپ با کیفیت بالا، را می‌دهد.

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

Aspose.Slides متد [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) را تحت کلاس [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) ارائه می‌دهد که به شما امکان می‌دهد در طول فرآیند تبدیل ارائه به PDF، جایگزینی قلم‌ها را شناسایی کنید.

مثال زیر یک ارائه را به PDF صادر می‌کند و هشدارهای جایگزینی قلم را در کنسول چاپ می‌کند. یک هشدار فقط زمانی چاپ می‌شود که قلمی در دسترس نباشد و در هنگام خروجی جایگزین شود. برای دریافت بازتاب‌های هشدار از API جاوا از یک پراکسی JPype استفاده کنید. رشته توصیفی جاوا را قبل از بررسی پیشوند به رشته Python تبدیل کنید:

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

{{% alert color="info" title="Note" %}}

برای اطلاعات بیشتر درباره جایگزینی قلم، مقاله [Font Substitution](/slides/fa/python-java/font-substitution/) را ببینید.

{{% /alert %}}

### **پردازش قلم‌هایی که نوع Bold اختصاصی ندارند**

یک ارائه می‌تواند قالب‌بندی Bold را به متن اعمال کند حتی اگر قلم آن نوع Bold اختصاصی نداشته باشد. متن می‌تواند به‌صورت synthetic bold ظاهر شود که گلیف‌های معمولی را به‌طور مصنوعی ضخیم می‌کند. وقتی این متن در PDF بسیار سنگین یا متفاوت از ظاهر موردنظر به‌نظر برسد، می‌توانید با فراخوانی متد [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles) با مقدار `True` این گزینه را فعال کنید. این گزینه متن تحت تأثیر را به‌عنوان bitmap در هنگام خروجی PDF رستر می‌کند و می‌تواند ظاهر آن را برای برخی قلم‌ها بهبود بخشد. مقدار پیش‌فرض آن `False` است.

ارائه نمونه شامل دو جعبه متن است: یکی با متن عادی و دیگری با قالب‌بندی Bold بر همان قلم که نوع Bold اختصاصی ندارد. مثال زیر ارائه را بارگذاری می‌کند، رسترسازی سبک‌های قلم پشتیبانی‌نشده را فعال می‌کند و آن را به PDF صادر می‌کند:

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

پیش‌نمایش‌های زیر خروجی غیرفعال و خروجی فعال را نشان می‌دهند. در این مثال، متن Bold وقتی گزینه غیرفعال باشد، خطوط سنگین‌تری دارد. با فعال کردن گزینه، خطوط آن سبک‌تر می‌شود؛ متن عادی بدون تغییر می‌ماند. نتایج را قبل از انتخاب تنظیم برای ارائه خود مقایسه کنید.

| گزینه غیرفعال (`False`، پیش‌فرض) | گزینه فعال (`True`) |
|---|---|
| ![PDF با رسترسازی سبک فونت پشتیبانی‌نشده غیرفعال](unsupported-bold-disabled.png) | ![PDF با رسترسازی سبک فونت پشتیبانی‌نشده فعال](unsupported-bold-enabled.png) |

در این مثال، فعال سازی گزینه فقط متن Bold را به bitmap تبدیل می‌کند: بدون OCR نمی‌توان آن را انتخاب، کپی یا جستجو کرد و لبه‌های آن در بزرگ‌نمایی 800٪ نرم‌تر به‌نظر می‌رسند. متن عادی جستجوپذیر می‌ماند. وقتی گزینه غیرفعال باشد، هر دو رشته به‌صورت متن باقی می‌مانند.

این گزینه متن قالب‌بندی‌شده به عنوان Bold را وقتی قلم نوع Bold اختصاصی ندارد رستر می‌کند. [Font substitution](/slides/fa/python-java/font-substitution/) به‌جای آن قلم دیگری را زمانی که قلم اصلی در دسترس نیست، انتخاب می‌کند.

## **تبدیل اسلایدهای انتخاب‌شده از پاورپوینت به PDF**

شماره‌های اسلایدی که به متد [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) پاس داده می‌شوند، بر پایه 1 هستند. این مثال اسلایدهای 1 و 3 را (در صورتی که موجود باشند) صادر می‌کند:

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

## **تبدیل پاورپوینت به PDF با اندازه اسلاید سفارشی**

این مثال اولین اسلاید را روی صفحه‌ای به اندازه 612×792 پوینت (US Letter) صادر می‌کند. اسلاید را به یک ارائه جدید با اندازه مشخص کپی کرده و محتویات اسلاید را برای پر شدن مقیاس می‌کند.

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

    # حذف اسلاید خالی که ارائه جدید با آن ساخته شد.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **تبدیل پاورپوینت به PDF در نمای اسلاید یادداشت‌ها**

مثال زیر یک ارائه را به PDF صادر می‌کند به‌طوری که یادداشت‌های گوینده هر اسلاید زیر اسلاید قرار می‌گیرد. برای مشاهده نتیجه از ارائه‌ای استفاده کنید که شامل یادداشت‌های گوینده باشد.

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

## **استانداردهای دسترس‌پذیری و انطباق برای PDF**

هنگام تهیه PDFهای دسترس‌پذیر، به [راهنمای دسترس‌پذیری محتوای وب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) مراجعه کنید. برای انتخاب یک استاندارد خروجی از متد [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) استفاده کنید: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد فرآیند تبدیل پاورپوینت به PDF را نشان می‌دهد که بر اساس استانداردهای انطباق مختلف، چندین PDF تولید می‌کند:

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

> **توجه:** هنگام خروجی به PDF/UA، Aspose.Slides گرافیک‌های پیچیده مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. عناصر مسیر جداگانه به‌عنوان محتوای مستقل حفظ نمی‌شوند و ممکن است به‌عنوان artifacts علامت‌گذاری شوند؛ متن Alt تنها برای کل شکل ارائه می‌شود.

## **سوالات متداول**

**آیا می‌توانم چندین فایل PowerPoint را به‌صورت دسته‌ای به PDF تبدیل کنم؟**

بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید فایل‌های خود را به‌صورت حلقه‌وار پردازش کرده و فرآیند تبدیل را برنامه‌نویسی کنید.

**آیا می‌توان PDF تبدیل‌شده را با رمز عبور محافظت کرد؟**

بله. از کلاس [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) برای تنظیم رمز عبور و تعریف مجوزهای دسترسی در طول فرآیند تبدیل استفاده کنید.

**چگونه می‌توان اسلایدهای مخفی را در PDF گنجاند؟**

در کلاس [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) متد [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) را با مقدار `True` فراخوانی کنید تا اسلایدهای مخفی در PDF نهایی گنجانده شوند.

**آیا Aspose.Slides می‌تواند کیفیت تصویر بالا را در PDF حفظ کند؟**

بله، می‌توانید با استفاده از متدهایی مانند [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) و [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) در کلاس [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) کیفیت تصویر را کنترل کنید تا تصاویر با کیفیت بالا در PDF شما باشد.

**آیا Aspose.Slides استانداردهای انطباق PDF/A را پشتیبانی می‌کند؟**

بله، Aspose.Slides به شما اجازه می‌دهد که PDFهایی صادر کنید که با [استانداردهای مختلف](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/) از جمله PDF/A1a، PDF/A1b و PDF/UA سازگار باشند، برای دسترس‌پذیری یا بایگانی. استاندارد مناسب را انتخاب کنید و خروجی را بر پایه نیازهای خود ارزیابی کنید.

## **منابع اضافی**

- [Aspose.Slides for Python via Java Documentation](/slides/fa/python-java/)
- [Aspose.Slides for Python via Java API Reference](https://reference.aspose.com/slides/python-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)