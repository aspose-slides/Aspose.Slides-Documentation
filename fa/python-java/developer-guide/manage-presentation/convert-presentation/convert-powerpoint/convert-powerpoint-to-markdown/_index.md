---
title: تبدیل ارائه‌های PowerPoint به Markdown در Python از طریق Java
linktitle: PowerPoint به Markdown
type: docs
weight: 140
url: /fa/python-java/convert-powerpoint-to-markdown/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به MD
- ارائه به MD
- اسلاید به MD
- PPT به MD
- PPTX به MD
- ذخیره PowerPoint به عنوان Markdown
- ذخیره ارائه به عنوان Markdown
- ذخیره اسلاید به عنوان Markdown
- ذخیره PPT به عنوان MD
- ذخیره PPTX به عنوان MD
- صدور PPT به MD
- صدور PPTX به MD
- صدور تصویر Markdown
- لینک‌های تصویر CDN
- PowerPoint
- ارائه
- Markdown
- Python
- Java
- Aspose.Slides
description: "تبدیل ارائه‌های PPT و PPTX به Markdown در Python از طریق Java و کنترل مکان ذخیره‌سازی و ارجاع تصاویر bitmap، metafile و SVG صادرشده."
---
## **بررسی کلی**

Aspose.Slides for Python via Java می‌تواند ارائه‌های PPT و PPTX را به Markdown برای مستندسازی، سایت‌های ایستای، مهاجرت محتوا و جریان‌های کنترل نسخه تبدیل کند. می‌توانید یک نوع Markdown را انتخاب کنید، نحوه رندر محتوای اسلاید را کنترل کنید و تصمیم بگیرید که تصاویر صادر شده در کجا ذخیره شوند و Markdown تولید شده چگونه به آن‌ها ارجاع دهد.

به طور پیش‌فرض، خروجی Markdown فقط متن است. برای صادرات محتوای تصویری، نوع صادرات را با متد [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/markdownsaveoptions/#setExportType) به مقدار `Sequential` یا `Visual` از شمارش‌گر [MarkdownExportType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/markdownexporttype/) تنظیم کنید. `Sequential` موارد اسلاید را به‌صورت جداگانه و به ترتیب رندر می‌کند، در حالی که `Visual` موارد گروه‌بندی‌شده را با هم نگه می‌دارد تا رابطه بصری آن‌ها حفظ شود. مقدار `TextOnly` هیچ منبع تصویری صادر نمی‌کند، بنابراین فراخوانی‌های ذخیره‌سازی تصویر در آن حالت اجرا نمی‌شوند.

## **تبدیل ارائه به Markdown**

فایل منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بارگذاری کنید و سپس متد [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) را با مقدار `Md` از شمارش‌گر [SaveFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/) صدا بزنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.md", SaveFormat.Md)
finally:
    presentation.dispose()
```

هر مثال `presentation.pptx` را از پوشه کاری فعلی می‌خواند. قبل از اجرای مثال‌ها Aspose.Slides for Python via Java و یک محیط اجرایی Java سازگار را نصب کنید. JVM را یک بار برای هر فرآیند Python راه‌اندازی کنید.

## **انتخاب یک نوع Markdown**

متد [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/markdownsaveoptions/#setFlavor) مشخص می‌کند که کدام مشخصات Markdown برای خروجی استفاده شود. شمارش‌گر [Flavor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/flavor/) شامل CommonMark، GitHub Flavored Markdown و سایر انواع پشتیبانی‌شده است.

مثال زیر ارائه را به‌صورت CommonMark صادر می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Flavor, MarkdownSaveOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setFlavor(Flavor.CommonMark)

    presentation.save("presentation.md", SaveFormat.Md, options)
finally:
    presentation.dispose()
```

## **صادر کردن تصاویر با رفتار پیش‌فرض ذخیره‌سازی محلی**

کلاس [MarkdownSaveOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/markdownsaveoptions/) دو متد برای پیکربندی ذخیره‌سازی محلی تصاویر ارائه می‌دهد:

- [setBasePath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/markdownsaveoptions/#setBasePath) مسیر پایه برای سند Markdown و منابع آن را مشخص می‌کند.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/fa/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) زیرپوشه تصویر را تعیین می‌کند. مقدار پیش‌فرض آن `Images` است.

مثال زیر محتوای تصویری را رندر می‌کند، تصاویر را در `output/assets` می‌نویسد و ارجاع‌های نسبی تصویر را در سند Markdown ایجاد می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("assets")

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

این رفتار همچنین به‌عنوان بازگشت پیش‌فرض زمانی استفاده می‌شود که یک Handlers سفارشی ذخیره‌سازی تصویر مقدار `False` برگرداند.

## **سفارشی‌سازی ذخیره‌سازی تصویر و پیوندهای Markdown**

از متد [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/fa/python-java/aspose.slides/markdownsaveoptions/) برای ثبت یک Callback برای منابع bitmap و metafile غیر SVG که در طول صادرات Markdown صادر می‌شوند، استفاده کنید. Callback `MarkdownImageSavingHandler` شی تصویر، مقدار [ImageFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imageformat/) آن و پیوند Markdown تولید‌شده را به‌صورت پارامتر `String[]` تک عنصری دریافت می‌کند. تصویر را با فرمت فراهم‌شده ذخیره یا آپلود کنید و `link[0]` را با ارجاعی که باید در خروجی Markdown ظاهر شود، جایگزین کنید.

منابع صادرشده در قالب SVG به‌صورت جداگانه مدیریت می‌شوند. یک Callback با متد [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/fa/python-java/aspose.slides/markdownsaveoptions/) ثبت کنید. Callback `MarkdownSvgImageSavingHandler` یک شی [SvgImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgimage/) و پارامتر `String[] link` تک عنصری را دریافت می‌کند. برای SVG هیچ آرگومان `ImageFormat` وجود ندارد؛ به‌جای آن داده‌های XML را از متد [SvgImage.getSvgData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgimage/#getSvgData) بنویسید یا آپلود کنید. بسته به حالت صادرات و گروه‌بندی بصری، یک SVG در ارائه منبع می‌تواند رستر شده یا با محتوای دیگر ترکیب شود؛ منبع غیر SVG حاصل سپس به Callback ذخیره‌سازی تصویر ارسال می‌شود. هنگامی که هر منبع تصویری صادرشده نیاز به پردازش سفارشی دارد، هر دو Callback را ثبت کنید.

مقدار برگشتی Handler تعیین می‌کند که چه کسی تصویر را پردازش می‌کند:

- پس از ذخیره، آپلود، تبدیل یا پردازش تصویر توسط Handler و اختصاص مقدار معتبر به `link[0]`، `True` برگردانید. Aspose.Slides این مقدار را به سند Markdown می‌نویسد و ذخیره محلی پیش‌فرض را انجام نمی‌دهد.
- `False` برگردانید تا Aspose.Slides تصویر را به‌صورت محلی ذخیره کند و پیوند آن را بر اساس مقادیری که با [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/markdownsaveoptions/#setBasePath) و [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/fa/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) تنظیم شده‌اند، تولید کند.

{{% alert color="danger" title="مهم" %}}
یک Handler که مقدار `True` برمی‌گرداند مسئولیت تصویر را به‌عهده می‌گیرد. اگر بدون اختصاص یک پیوند معتبر و غیر خالی `True` برگرداند، صادرات با `InvalidOperationException` شکست می‌خورد.
{{% /alert %}}

در Python، این Callbacks را با `jpype.JProxy` ثبت می‌کنید؛ رابط Callback جاوا را از طریق متد `invoke` پیاده‌سازی کنید. آرگومان `link` یک آرایه رشته‌ای قابل تغییر در Java است: قبل از پردازش `link[0]` را به رشته Python تبدیل کنید، سپس URL جایگزین را مجدداً به `link[0]` اختصاص دهید.

### **ذخیره تصاویر در پوشه‌ای از CDN و استفاده از URLهای خارجی**

مثال زیر `cdn-origin/presentations/quarterly-report` را به‌عنوان یک پوشه مبداء CDN سوار یا همگام‌شده در نظر می‌گیرد. هر Handler نام فایل تولیدشده را استخراج می‌کند، تصویر را در آن پوشه سفارشی ذخیره می‌کند و مرجع محلی تولیدشده را با یک URL عمومی CDN جایگزین می‌نماید. خود نمونه هیچ آپلود شبکه‌ای انجام نمی‌دهد: URL تنها پس از سوار شدن پوشه به‌عنوان مبداء CDN یا انتشار فایل‌ها در CDN معتبر می‌شود. برای ذخیره‌سازی شیء، عملیات نوشتن در سیستم فایل را با آپلود SDK ذخیره‌سازی جایگزین کنید و `link[0]` را پس از موفقیت‌آمیز بودن آپلود تنظیم کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from urllib.parse import quote
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
public_base_url = "https://cdn.example.com/presentations/quarterly-report"
storage_directory = Path("cdn-origin", "presentations", "quarterly-report")
output_directory.mkdir(parents=True, exist_ok=True)
storage_directory.mkdir(parents=True, exist_ok=True)

def get_file_name(generated_link):
    normalized_link = str(generated_link).replace("\\", "/")
    return normalized_link.rsplit("/", 1)[-1]

def save_image(image, image_format, link):
    if image.getWidth() < 128 or image.getHeight() < 128:
        return False

    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    image.save(str(storage_path), image_format)
    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

def save_svg(svg_image, link):
    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    svg_data = svg_image.getSvgData()
    try:
        storage_path.write_bytes(bytes(svg_data))
    except OSError as error:
        print(f"Could not save the SVG image: {error}")
        return False

    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

image_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", dict(invoke=save_image))
svg_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", dict(invoke=save_svg))

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("fallback-images")
    options.setImageSaving(image_handler)
    options.setSvgImageSaving(svg_handler)

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

Handler bitmap عمداً برای تصاویر کوچکتر از 128 × 128 پیکسل مقدار `False` برمی‌گرداند، بنابراین Aspose.Slides آن‌ها را به‌صورت پیش‌فرض در `output/fallback-images` ذخیره می‌کند. منابع bitmap و metafile بزرگ‌تر، همراه با منابع SVG، توسط کد سفارشی پردازش می‌شوند. به‌عنوان مثال، یک مرجع محلی تولید‌شده مانند `fallback-images/image1.png` به `https://cdn.example.com/presentations/quarterly-report/image1.png` تبدیل می‌شود. Handlerها فقط هنگام نوشتن فایل‌ها از مسیرهای سیستم‌عامل استفاده می‌کنند؛ پیوندهای نوشته‌شده در Markdown از خطوط مورب `/` و نام‌های فایل URL‑escaped استفاده می‌کنند. همین قاعده را هنگام ساخت پیوندهای نسبی نیز اعمال کنید: از `/` استفاده کنید، نه جداکننده مسیر خاص پلتفرم.

## **سؤالات متداول**

**آیا یک Handler می‌تواند هم تصاویر رستر و هم SVGها را پردازش کند؟**

خیر. برای منابع bitmap و metafile صادرشده از [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/fa/python-java/aspose.slides/markdownsaveoptions/) استفاده کنید و برای منابع صادرشده به‌صورت SVG از [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/fa/python-java/aspose.slides/markdownsaveoptions/) بهره‌برداری کنید. اولین متد یک شی تصویر و مقدار [ImageFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imageformat/) را ارائه می‌دهد؛ دومی یک شی [SvgImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgimage/) که می‌توان داده‌های SVG آن را با [SvgImage.getSvgData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgimage/#getSvgData) خواند. یک SVG منبع که در زمان صادرات رستر می‌شود توسط Callback ذخیره‌سازی تصویر پردازش می‌شود.

**هنگامی که یک Handler مقدار `False` برمی‌گرداند، چه اتفاقی می‌افتد؟**

Aspose.Slides رفتار پیش‌فرض ذخیره‌سازی محلی خود را به‌کار می‌گیرد. مکان تصویر و مرجع تولیدشده توسط مقادیری که با [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/markdownsaveoptions/#setBasePath) و [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/fa/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) تنظیم شده‌اند، کنترل می‌شود.

**آیا یک Handler می‌تواند بدون ذخیره محلی تصویر، فقط URL ارائه دهد؟**

بله. Handler می‌تواند تصویر را به ذخیره‌سازی شیء آپلود کند یا به سرویس دیگری بفرستد، URL حاصل را به `link[0]` اختصاص دهد و `True` برگرداند. Handler باید پردازش را به‌تنهایی به‌پایان برساند؛ بازگرداندن `True` از ذخیره‌سازی محلی پیش‌فرض جلوگیری می‌کند.

**چرا هنگام استفاده از Handler، صادرات Markdown خطای `InvalidOperationException` می‌دهد؟**

این استثنا زمانی رخ می‌دهد که Handler مقدار `True` برگرداند ولی پیوند معتبری ارائه ندهد. پیش از برگرداندن `True` مسیر نسبی یا URL خارجی که باید در Markdown نوشته شود را به `link[0]` اختصاص دهید.

**کدام جداکننده مسیر باید در پیوندهای تصویر استفاده شود؟**

در پیوندهای Markdown و URLها از خطوط مورب `/` استفاده کنید. برای مسیرهای سیستم‌فایل فقط از `pathlib.Path` بهره ببرید و سپس مرجع Markdown را جداگانه ایجاد یا نرمال کنید.

**آیا لینک‌های فراگیر در طول صادرات Markdown حفظ می‌شوند؟**

بله. متن [hyperlinks](/slides/fa/python-java/manage-hyperlinks/) به‌صورت پیوندهای استاندارد Markdown حفظ می‌شود. [transitions](/slides/fa/python-java/slide-transition/) اسلاید و [animations](/slides/fa/python-java/powerpoint-animation/) تبدیل نمی‌شوند.

**آیا می‌توان ارائه‌ها را به‌صورت همزمان به Markdown تبدیل کرد؟**

می‌توانید فایل‌های ارائه متفاوت را به‌صورت همزمان پردازش کنید، اما نباید همان نمونه [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) را بین رشته‌ها به‌اشتراک بگذارید. راهنمایی‌های [multithreading](/slides/fa/python-java/multithreading/) را دنبال کنید و برای هر فایل یک نمونه جداگانه استفاده کنید.