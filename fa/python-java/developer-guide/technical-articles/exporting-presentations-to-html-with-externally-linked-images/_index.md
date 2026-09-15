---
title: صدور ارائه‌ها به HTML با تصاویر لینک‌خورده خارجی
type: docs
weight: 100
url: /fa/python-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- صدور پاورپوینت
- صدور OpenDocument
- صدور ارائه
- صدور اسلاید
- صدور PPT
- صدور PPTX
- صدور ODP
- PowerPoint به HTML
- OpenDocument به HTML
- ارائه به HTML
- اسلاید به HTML
- PPT به HTML
- PPTX به HTML
- ODP به HTML
- تصویر لینک‌خورده
- تصویر لینک‌خورده خارجی
- منبع لینک‌خورده
- منبع خارجی
- Python
- Java
- Aspose.Slides
description: "صدور ارائه‌های PowerPoint و OpenDocument به HTML در Python با استفاده از Aspose.Slides به‌طوری‌که تصاویر و سایر منابع به‌صورت فایل‌های لینک‌خورده خارجی ذخیره می‌شوند."
---
## **بررسی کلی**

به طور پیش فرض، Aspose.Slides یک ارائه را به یک فایل HTML مستقل صادر می‌کند. تصاویر و سایر منابع به صورت مستقیم در HTML نوشته می‌شوند، معمولاً به عنوان داده های Base64. این کار زمانی که به یک فایل قابل حمل نیاز دارید مفید است، اما همیشه بهترین فرمت برای یک وب سایت، یک CMS یا یک خط لوله تبدیل سمت سرور نیست.

از منابع لینک خارجی استفاده کنید زمانی که می خواهید:

- حجم سند HTML را کاهش دهید؛
- تصاویر، فونت ها، صدا یا ویدیو را به صورت جداگانه در مرورگر یا CDN ذخیره کنید؛
- منابع تولید شده پس از خروجی گیری را بررسی، جایگزین، فشرده یا پس پردازش کنید؛
- ساختار خروجی را نزدیک تر به آنچه یک برنامه وب انتظار دارد نگه دارید.

برای فرآیند عمومی تبدیل HTML، ببینید [تبدیل ارائه‌های PowerPoint به HTML](/slides/fa/python-java/convert-powerpoint-to-html/). این مقاله بر روی بخش لینک گذاری منابع خروجی تمرکز دارد.

## **چگونه صادرات منبع لینک‌شده کار می‌کند**

`ILinkEmbedController` به برنامه شما امکان می دهد، برای هر منبع به صورت جداگانه، تصمیم بگیرید که آیا صادرکننده داده ها را در HTML جاسازی کند یا به صورت خارجی ذخیره کرده و یک لینک بنویسد.

این رابط دارای سه روش است:

- `ILinkEmbedController.getObjectStoringLocation` تعیین می کند که آیا یک منبع باید لینک شود یا جاسازی شود.
- `ILinkEmbedController.getUrl` URL ای را برمی گرداند که در HTML تولید شده یا در منبع لینک‌شده دیگر نوشته خواهد شد.
- `ILinkEmbedController.saveExternal` داده های منبع لینک‌شده را بر روی دیسک یا به مقصد ذخیره سازی دیگری می نویسد.

مسیر سیستم فایل و URL مرورگر مواردی جداگانه هستند. به عنوان مثال، نمونه زیر فایل های منبع را در مسیر `html-output/assets` روی دیسک می نویسد، در حالی که HTML شامل URL های نسبی مانند `assets/resource-1.svg` است. یک مرورگر این URL ها را نسبت به فایلی که لینک را دارد حل می کند. بنابراین، لینکی از `presentation.html` به یک فایل SVG از `assets/resource-1.svg` استفاده می کند، در حالی که لینکی از آن فایل SVG به تصویری که در همان پوشه `assets` ذخیره شده است، از `resource-4.jpg` استفاده می کند.

## **صادرات HTML با منابع لینک‌شده**

مثال پایتون زیر یک پوشه خروجی ایجاد می کند، فایل HTML را در آن ذخیره می نماید و منابع لینک‌شده را در زیرپوشه `assets` ذخیره می کند. کنترلر تصاویر، فونت ها، صداها، ویدیوها و منابع CSS رایج را زمانی که Aspose.Slides پسوند فایل ایمن ارائه می دهد یا می تواند آن را استنتاج کند، لینک می کند. منابری که شناسایی نشوند به صورت جاسازی باقی می مانند.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, LinkEmbedDecision, Presentation, SVGOptions, SaveFormat, SlideImageFormat


class ExternalResourceController:
    EXTENSIONS_BY_CONTENT_TYPE = {
        "image/jpeg": ".jpg",
        "image/png": ".png",
        "image/gif": ".gif",
        "image/bmp": ".bmp",
        "image/svg+xml": ".svg",
        "image/tiff": ".tiff",
        "image/x-emf": ".emf",
        "image/x-wmf": ".wmf",
        "font/woff": ".woff",
        "font/woff2": ".woff2",
        "font/ttf": ".ttf",
        "application/font-woff": ".woff",
        "application/vnd.ms-fontobject": ".eot",
        "application/x-font-ttf": ".ttf",
        "text/css": ".css",
        "audio/mpeg": ".mp3",
        "audio/mp4": ".m4a",
        "audio/wav": ".wav",
        "video/mp4": ".mp4",
        "video/webm": ".webm",
    }

    def __init__(self, asset_directory, asset_url_prefix):
        self.asset_directory = asset_directory
        normalized_prefix = asset_url_prefix.replace("\\", "/") if asset_url_prefix else ""
        self.asset_url_prefix = normalized_prefix.rstrip("/") + "/" if normalized_prefix else ""
        self.file_names_by_resource_id = {}

    def getObjectStoringLocation(self, resource_id, entity_data, semantic_name, content_type, recommended_extension):
        extension = self.resolve_extension(content_type, recommended_extension)
        if extension is None:
            return LinkEmbedDecision.Embed

        self.file_names_by_resource_id[resource_id] = f"resource-{resource_id}{extension}"
        return LinkEmbedDecision.Link

    def getUrl(self, resource_id, referrer):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            return None
        if referrer in self.file_names_by_resource_id:
            return file_name
        return self.asset_url_prefix + file_name

    def saveExternal(self, resource_id, entity_data):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            print(f"Resource {resource_id} was not registered for external storage.")
            return
        if entity_data is None or len(entity_data) == 0:
            print(f"Resource {resource_id} contains no data and cannot be saved.")
            return

        try:
            self.asset_directory.mkdir(parents=True, exist_ok=True)
            file_path = self.asset_directory / file_name
            resource_data = bytes(entity_data)
            file_path.write_bytes(resource_data)
        except OSError as error:
            print(f"Failed to save external resource {resource_id}: {error}")

    @classmethod
    def resolve_extension(cls, content_type, recommended_extension):
        content_type = str(content_type) if content_type is not None else ""
        mapped_extension = cls.EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if mapped_extension is not None:
            return mapped_extension
        if not content_type.lower().startswith(("image/", "font/", "audio/", "video/")):
            return None
        if recommended_extension is None:
            return None
        extension_characters = str(recommended_extension).strip().lstrip(".")
        if not extension_characters or not extension_characters.isalnum():
            return None
        return "." + extension_characters.lower()


input_file_path = Path("presentation.pptx")
output_directory = Path("html-output")
asset_directory_name = "assets"
asset_directory = output_directory / asset_directory_name

output_directory.mkdir(parents=True, exist_ok=True)
asset_directory.mkdir(parents=True, exist_ok=True)

asset_url_prefix = asset_directory_name + "/"
controller = ExternalResourceController(asset_directory, asset_url_prefix)
controller_proxy = jpype.JProxy("com.aspose.slides.ILinkEmbedController", inst=controller)
svg_options = SVGOptions(controller_proxy)
slide_image_format = SlideImageFormat.svg(svg_options)

html_options = HtmlOptions(controller_proxy)
html_formatter = HtmlFormatter.createDocumentFormatter("", False)
html_options.setHtmlFormatter(html_formatter)
html_options.setSlideImageFormat(slide_image_format)

presentation = Presentation(str(input_file_path))
try:
    html_file_path = output_directory / "presentation.html"
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

پس از خروجی گیری، پوشه خروجی این ساختار را دارد:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

فایل های دقیق بسته به محتوای ارائه و گزینه های خروجی متفاوت هستند. به عنوان مثال، تصاویر رستری معمولاً به صورت JPEG یا PNG صادر می شوند. Aspose.Slides ممکن است کدک تصویری متفاوتی نسبت به آنچه در ارائه منبع استفاده شده است انتخاب کند، وقتی که این کار منجر به فایل کوچکتر یا مناسب تر می شود. تصاویری که شفافیت دارند به صورت PNG صادر می شوند.

## **انتخاب URLها برای استقرار**

نمونه از پیشوند URL نسبی `assets/` استفاده می کند. اگر `presentation.html` از مسیر `html-output/presentation.html` باز شود، مرورگر `html-output/assets/resource-1.svg` را بارگذاری می کند.

زمانی که یک منبع لینک‌شده به منبع لینک‌شده دیگر ارجاع می دهد، نمونه از پارامتر `referrer` در `ILinkEmbedController.getUrl` استفاده می کند و فقط نام فایل را برمی گرداند. به عنوان مثال، اگر `resource-1.svg` و `resource-4.jpg` هر دو در پوشه `assets` باشند، فایل SVG باید به `resource-4.jpg` ارجاع دهد، نه به `assets/resource-4.jpg`.

در زمان استقرار فایل ها در مکان دیگری، از پیشوند URL متفاوتی استفاده کنید:

- از `assets/` زمانی که پوشه دارایی در کنار فایل HTML باشد، استفاده کنید.
- از `../assets/` زمانی که پوشه دارایی یک سطح بالاتر از فایل HTML باشد، استفاده کنید.
- از `https://cdn.example.com/presentations/job-123/assets/` زمانی که فایل ها به CDN یا سرور فایل های ایستای بارگذاری شوند، استفاده کنید.

URL برگردانده شده توسط `ILinkEmbedController.getUrl` باید با مکان نهایی استقرار فایلی که توسط `ILinkEmbedController.saveExternal` نوشته شده است، مطابقت داشته باشد. در برنامه های سرور، برای هر کار تبدیل یک پوشه خروجی یا پیشوند ذخیره سازی شیء منحصر به فرد استفاده کنید تا از بازنویسی فایل های خروجی دیگر جلوگیری شود.

## **چه زمانی به جای آن باید جاسازی کرد**

HTML جاسازی شده به صورت Base64 هنوز زمانی مفید است که خروجی باید یک فایل واحد باشد، مانند پیوست ایمیل، پیش نمایش آفلاین، یا سندی که بدون پوشه دارایی پشتیبان منتقل می شود. منابع لینک‌شده گزینه بهتری هستند وقتی که HTML توسط یک برنامه وب سرو می شود، در یک CMS ذخیره می شود، توسط یک خط لوله ساخت بهینه می شود، یا بطور مستقل توسط مرورگرها کش می شود.

## **FAQ**

**آیا می توانم فقط تصاویر را خارجی کنم و سایر منابع را جاسازی بمانم؟**

بله. در `ILinkEmbedController.getObjectStoringLocation`، فقط برای انواع محتوایی که می خواهید به صورت فایل های جداگانه ذخیره شوند، [LinkEmbedDecision.Link](https://reference.aspose.com/slides/fa/python-java/aspose.slides/linkembeddecision/#Link) را برگردانید و برای بقیه موارد [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/fa/python-java/aspose.slides/linkembeddecision/#Embed) را برگردانید.

**چرا پسوند تصویر صادرشده با ارائه منبع متفاوت است؟**

Aspose.Slides ممکن است در طول خروجی گیری HTML تصاویر رستری را دوباره کدگذاری کند تا اندازه یا سازگاری مرورگر بهبود یابد. به عنوان مثال، یک تصویر از فایل منبع ممکن است بسته به نتیجه رندر شده به صورت JPEG یا PNG نوشته شود.

**آیا URLهای نسبی پس از انتقال فایل HTML کار می کنند؟**

URLهای نسبی تنها زمانی کار می کنند که ساختار پوشه نسبی مشابه حفظ شود. اگر HTML به `assets/resource-1.png` ارجاع دهد، پوشه `assets` باید کنار فایل HTML بماند مگر اینکه پیشوند URL متفاوتی تولید کنید.

**آیا برنامه های سرور باید پوشه خروجی یکسان را دوباره استفاده کنند؟**

خیر. از یک پوشه خروجی یا پیشوند ذخیره سازی منحصر به فرد برای هر کار تبدیل استفاده کنید. این کار از تداخل نام فایل جلوگیری می کند و مانع از بازنویسی منابع تولید شده توسط خروجی دیگر می شود.