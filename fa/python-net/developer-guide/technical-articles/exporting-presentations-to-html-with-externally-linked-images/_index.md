---
title: صادرات ارائه‌ها به HTML با تصاویر لینک‌دار خارجی در پایتون
linktitle: صادرات ارائه‌ها به HTML با تصاویر لینک‌دار خارجی
type: docs
weight: 100
url: /fa/python-net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- صادرات پاورپوینت
- صادرات OpenDocument
- صادرات ارائه
- صادرات اسلاید
- صادرات PPT
- صادرات PPTX
- صادرات ODP
- پاورپوینت به HTML
- OpenDocument به HTML
- ارائه به HTML
- اسلاید به HTML
- PPT به HTML
- PPTX به HTML
- ODP به HTML
- تصویر لینک‌دار
- تصویر لینک‌دار خارجی
- منبع لینک‌دار
- منبع خارجی
- پایتون
- Aspose.Slides
description: "صادرات ارائه‌های پاورپوینت و OpenDocument به HTML در پایتون با استفاده از Aspose.Slides و ذخیره‌سازی تصاویر به‌صورت فایل‌های لینک‌دار خارجی."
---
## **بررسی کلی**

به‌طور پیش‌فرض، Aspose.Slides یک ارائه را به یک فایل HTML خودمحافظت‌شده صادر می‌کند. تصاویر و دیگر منابع مستقیماً داخل HTML نوشته می‌شوند، معمولاً به صورت داده Base64. این روش زمانی که به یک فایل قابل حمل نیاز دارید مفید است، اما همیشه بهترین قالب برای یک وب‌سایت، یک CMS یا یک خط لوله تبدیل سمت سرور نیست.

از تصاویر لینک‌دار خارجی استفاده کنید وقتی می‌خواهید:

- اندازه سند HTML را کاهش دهید؛
- تصاویر را به‌صورت جداگانه در مرورگر یا CDN کش کنید؛
- پس از خروجی‌گیری، تصاویر تولیدشده را بررسی، جایگزین، فشرده یا پس‌پردازش کنید؛
- ساختار خروجی را نزدیک‌تر به آنچه یک برنامه وب انتظار دارد نگه دارید.

برای گردش‌کار کلی تبدیل HTML، به [Convert PowerPoint Presentations to HTML](/slides/fa/python-net/convert-powerpoint-to-html/) مراجعه کنید. این مقاله بر بخش لینک‌دادن تصاویر در خروجی متمرکز است.

## **چگونه صادرات تصویر لینک‌دار کار می‌کند**

در .NET و Java، [ILinkEmbedController](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/ilinkembedcontroller/) رابط فراخوانی‌ای است که توسط صادرکننده برای تصمیم‌گیری دربارهٔ جاسازی یا لینک‌دادن یک منبع استفاده می‌شود. در Python از طریق .NET، کلاس‌های Python در حال حاضر نمی‌توانند این رابط فراخوانی .NET را به‌صورت مستقیم پیاده‌سازی کنند، بنابراین روش عملی به این صورت است:

1. ارائه را به HTML با استفاده از [HtmlOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/htmloptions/) صادر کنید.
1. از [SlideImageFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/slideimageformat/) همراه با [SVGOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/svgoptions/) استفاده کنید تا اسلایدها به‌صورت SVG در HTML نمایش داده شوند.
1. داده‌های تصویر Base64 را از URLهای `data:` در HTML به فایل‌های جداگانه منتقل کنید.
1. URLهای اصلی `data:` را با لینک‌های نسبی مانند `assets/resource-1.jpg` جایگزین کنید.

مسیر سیستم فایل و URL مرورگر دو نگرانی جداگانه هستند. برای مثال، نمونهٔ زیر فایل‌های تصویر را در `html-output/assets` روی دیسک می‌نویسد، در حالی که HTML شامل URLهای نسبی مانند `assets/resource-1.jpg` است. مرورگر این URLها را نسبت به فایل HTMLی که لینک را درون‌اش دارد، حل می‌کند.

## **صادر کردن HTML با تصاویر لینک‌دار**

مثال Python زیر یک پوشهٔ خروجی ایجاد می‌کند، فایل HTML را در آن ذخیره می‌سازد، تصاویر استخراج‌شده را در زیرپوشهٔ `assets` ذخیره می‌کند و URLهای تصویر Base64 را به لینک‌های نسبی بازنویسی می‌کند. این مثال فرمت‌های تصویر Base64 رایج را وقتی Aspose.Slides پسوند فایل ایمن ارائه می‌دهد، استخراج می‌کند. URLهای داده‌ای که شناخته نمی‌شوند به‌صورت جاسازی‌شده باقی می‌مانند.

```python
import base64
import os
import re

import aspose.slides as slides
import aspose.slides.export as slides_export


EXTENSIONS_BY_CONTENT_TYPE = {
    "image/jpeg": ".jpg",
    "image/png": ".png",
    "image/gif": ".gif",
    "image/bmp": ".bmp",
    "image/svg+xml": ".svg",
    "image/tiff": ".tiff",
    "image/x-emf": ".emf",
    "image/x-wmf": ".wmf",
}

DATA_URI_PATTERN = re.compile(
    r"data:(?P<content_type>[-\w.+]+/[-\w.+]+);base64,(?P<data>[A-Za-z0-9+/=\r\n]+)"
)


def export_presentation_to_html_with_linked_images(
    input_file_path,
    output_directory,
    asset_directory_name="assets",
):
    asset_directory = os.path.join(output_directory, asset_directory_name)

    os.makedirs(output_directory, exist_ok=True)
    os.makedirs(asset_directory, exist_ok=True)

    html_options = slides_export.HtmlOptions()
    html_options.html_formatter = slides_export.HtmlFormatter.create_document_formatter("", False)
    html_options.slide_image_format = slides_export.SlideImageFormat.svg(
        slides_export.SVGOptions()
    )

    html_file_path = os.path.join(output_directory, "presentation.html")

    with slides.Presentation(input_file_path) as presentation:
        presentation.save(html_file_path, slides_export.SaveFormat.HTML, html_options)

    externalize_base64_images(html_file_path, asset_directory, asset_directory_name)


def externalize_base64_images(html_file_path, asset_directory, asset_directory_name):
    with open(html_file_path, "r", encoding="utf-8-sig") as html_file:
        html_content = html_file.read()

    saved_resource_names = {}
    resource_index = 1

    def replace_data_uri(match):
        nonlocal resource_index

        data_uri = match.group(0)
        if data_uri in saved_resource_names:
            return saved_resource_names[data_uri]

        content_type = match.group("content_type").lower()
        extension = EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if extension is None:
            return data_uri

        encoded_data = match.group("data")
        image_data = base64.b64decode(encoded_data)
        if len(image_data) == 0:
            return data_uri

        file_name = f"resource-{resource_index}{extension}"
        resource_index += 1

        file_path = os.path.join(asset_directory, file_name)
        with open(file_path, "wb") as image_file:
            image_file.write(image_data)

        linked_url = f"{asset_directory_name}/{file_name}"
        saved_resource_names[data_uri] = linked_url
        return linked_url

    updated_html_content = DATA_URI_PATTERN.sub(replace_data_uri, html_content)

    with open(html_file_path, "w", encoding="utf-8", newline="\n") as html_file:
        html_file.write(updated_html_content)


input_file_path = "presentation.pptx"
output_directory = "html-output"

export_presentation_to_html_with_linked_images(input_file_path, output_directory)
```

پس از صادرات، پوشهٔ خروجی ممکن است این ساختار را داشته باشد:

```text
html-output/
  presentation.html
  assets/
    resource-1.jpg
    resource-2.png
```

فایل‌های دقیق به محتوای ارائه و گزینه‌های صادرات بستگی دارند. برای مثال، تصاویر رستری معمولاً به‌صورت JPEG یا PNG صادر می‌شوند. Aspose.Slides ممکن است کدک تصویری متفاوتی نسبت به ارائهٔ منبع انتخاب کند وقتی که باعث تولید فایل کوچکتر یا مناسب‌تر می‌شود. تصاویر با شفافیت به‌صورت PNG صادر می‌شوند.

## **انتخاب URLها برای استقرار**

این نمونه از پیشوند URL نسبی `assets/` استفاده می‌کند: اگر `presentation.html` از `html-output/presentation.html` باز شود، مرورگر `html-output/assets/resource-1.jpg` را بارگذاری می‌کند.

در زمان استقرار فایل‌ها در مکان دیگری، از نام پوشهٔ دارایی متفاوت استفاده کنید یا لینک‌های تولیدشده را بازنویسی کنید:

- از `assets/` وقتی که پوشهٔ دارایی کنار فایل HTML باشد، استفاده کنید.
- از `../assets/` وقتی که پوشهٔ دارایی یک سطح بالاتر از فایل HTML باشد، استفاده کنید.
- از `https://cdn.example.com/presentations/job-123/assets/` وقتی که فایل‌ها به CDN یا سرور فایل‌های استاتیک بارگذاری می‌شوند، استفاده کنید.

در برنامه‌های سرور، برای هر کار تبدیل یک پوشهٔ خروجی یا پیشوند ذخیره‌سازی منحصر به‌فرد استفاده کنید تا از نوشتن‌مانند روی فایل‌های خروجی دیگر جلوگیری شود.

## **چه زمانی به جای لینک‌دادن، جاسازی کنیم**

HTML با Base64 جاسازی‌شده هنوز هنگام نیاز به یک فایل واحد مفید است، مانند پیوست ایمیل، پیش‌نمایش آفلاین یا سندی که بدون پوشهٔ دارایی پشتیبان جابه‌جا می‌شود. تصاویر لینک‌دار زمانی مناسب‌تر هستند که HTML توسط یک برنامه وب سرویس‌دهی شود، در CMS ذخیره شود، توسط یک خط لوله ساخت بهینه‌سازی شود یا توسط مرورگرها به‌صورت مستقل از HTML کش شود.

## **سؤالات متداول**

**آیا می‌توانم فقط تصاویر را به‌صورت خارجی ذخیره کنم و سایر منابع را جاسازی بمانم؟**

بله. این نمونه تنها URLهای داده‌ای Base64 از نوع `image/*` که نوع محتواهایشان در `EXTENSIONS_BY_CONTENT_TYPE` فهرست شده است را استخراج می‌کند. دیگر URLهای داده‌ای به‌صورت جاسازی‌شده می‌مانند.

**چرا پسوند تصویر صادرشده با ارائهٔ منبع متفاوت است؟**

Aspose.Slides ممکن است در طول صادرات HTML تصاویر رستری را برای بهبود اندازه یا سازگاری مرورگر دوباره کدگذاری کند. برای مثال، یک تصویر از فایل منبع ممکن است بسته به نتیجه رندر به عنوان JPEG یا PNG نوشته شود.

**آیا URLهای نسبی پس از جابجایی فایل HTML کار می‌کنند؟**

URLهای نسبی فقط زمانی کار می‌کنند که ساختار پوشهٔ نسبی یکسان حفظ شود. اگر HTML به `assets/resource-1.png` اشاره کند، پوشهٔ `assets` باید کنار فایل HTML بماند، مگر اینکه پیشوند URL متفاوتی تولید کنید.

**آیا برنامه‌های سرور باید از پوشهٔ خروجی یکسان استفاده کنند؟**

نه. برای هر کار تبدیل یک پوشهٔ خروجی یا پیشوند ذخیره‌سازی منحصر به‌فرد استفاده کنید. این کار از برخورد نام فایل‌ها جلوگیری می‌کند و مانع نوشتن‌مانند روی منابع تولیدشده توسط یک صادرات دیگر می‌شود.