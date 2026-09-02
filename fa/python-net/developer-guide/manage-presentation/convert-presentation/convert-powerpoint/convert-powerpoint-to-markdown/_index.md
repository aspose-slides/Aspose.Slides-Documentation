---
title: تبدیل ارائه‌های پاورپوینت به مارک‌داون در پایتون
linktitle: پاورپوینت به مارک‌داون
type: docs
weight: 140
url: /fa/python-net/convert-powerpoint-to-markdown/
keywords:
- تبدیل پاورپوینت
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- پاورپوینت به MD
- ارائه به MD
- اسلاید به MD
- PPT به MD
- PPTX به MD
- ذخیره‌سازی پاورپوینت به عنوان مارک‌داون
- ذخیره‌سازی ارائه به عنوان مارک‌داون
- ذخیره‌سازی اسلاید به عنوان مارک‌داون
- ذخیره‌سازی PPT به MD
- ذخیره‌سازی PPTX به MD
- صادرات PPT به MD
- صادرات PPTX به MD
- صادرات تصویر به مارک‌داون
- لینک‌های تصویر CDN
- پاورپوینت
- ارائه
- مارک‌داون
- پایتون
- پایتون از طریق .NET
- Aspose.Slides
description: "پیشنهاد تبدیل ارائه‌های PPT و PPTX به مارک‌داون در پایتون و کنترل مکان ذخیره‌سازی تصاویر صادرشده و نحوه ارجاع سند مارک‌داون به آن‌ها."
---
## **بررسی کلی**

Aspose.Slides for Python via .NET می‌تواند ارائه‌های PPT و PPTX را به Markdown برای مستندات، سایت‌های استاتیک، مهاجرت محتوا و جریان‌های کاری کنترل نسخه تبدیل کند. شما می‌توانید یک نوع Markdown را انتخاب کنید، نحوه رندر محتوای اسلایدها را کنترل کنید و تصمیم بگیرید تصاویر صادراتی در کجا ذخیره شوند و Markdown تولید شده چگونه به آن‌ها ارجاع دهد.

به طور پیش‌فرض، خروجی Markdown فقط متن است. برای صادرات محتوای تصویری، خاصیت [MarkdownSaveOptions.export_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/markdownsaveoptions/export_type/) را به مقدار `SEQUENTIAL` یا `VISUAL` از شمارش [MarkdownExportType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/markdownexporttype/) تنظیم کنید. `SEQUENTIAL` موارد اسلاید را به‌صورت جداگانه و به ترتیب رندر می‌کند، در حالی که `VISUAL` موارد گروه‌بندی‌شده را کنار هم نگه می‌دارد تا رابطه بصری آن‌ها حفظ شود. مقدار `TEXT_ONLY` هیچ منبع تصویری تولید نمی‌کند.

## **تبدیل ارائه به Markdown**

فایل منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) بارگیری کنید و سپس متد [Presentation.save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ipresentation/save/) را با مقدار `MD` از شمارش [SaveFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/saveformat/) فراخوانی کنید.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **انتخاب نوع Markdown**

خاصیت [MarkdownSaveOptions.flavor](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/markdownsaveoptions/flavor/) مشخص می‌کند که کدام مشخصهٔ Markdown برای خروجی استفاده شود. شمارش [Flavor](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/flavor/) شامل CommonMark، GitHub Flavored Markdown و سایر انواع پشتیبانی‌شده است.

مثال زیر یک ارائه را به صورت CommonMark صادر می‌کند:

```python
import aspose.slides as slides

options = slides.export.MarkdownSaveOptions()
options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, options)
```

## **صادرات تصاویر با رفتار ذخیره‌سازی محلی پیش‌فرض**

کلاس [MarkdownSaveOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/markdownsaveoptions/) دو خاصیت برای ذخیرهٔ محلی تصاویر فراهم می‌کند:

- خاصیت [base_path](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/markdownsaveoptions/base_path/) دایرکتوری پایهٔ سند Markdown و منابع آن را مشخص می‌کند.
- خاصیت [images_save_folder_name](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) پوشهٔ فرعی تصاویر را مشخص می‌کند. مقدار پیش‌فرض آن `Images` است.

مثال زیر محتوای تصویری را رندر می‌کند، تصاویر را در `output/assets` می‌نویسد و ارجاعات تصویر نسبی را در سند Markdown ایجاد می‌کند:

```python
import os
import aspose.slides as slides

output_directory = "output"
os.makedirs(output_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = output_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(output_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

Aspose.Slides هنگام صادرات منابع تصویری، پوشهٔ فرعی تصویر را ایجاد می‌کند، اما برنامه باید قبل از ذخیرهٔ فایل Markdown، `base_path` را ایجاد کند.

## **آماده‌سازی Markdown و تصاویر برای انتشار**

Aspose.Slides for Python via .NET بازتاب callbacks ذخیره‌سازی تصویر .NET را برای جایگزینی هر لینک تصویر تولید شده هنگام صادرات در اختیار نمی‌گذارد. در عوض، سند Markdown و پوشهٔ تصویر را به یک دایرکتوری انتشار صادر کرده و سپس آن دایرکتوری را بدون تغییر ساختار نسبی آن منتشر کنید.

مثال زیر `cdn-origin/presentations/quarterly-report` را به عنوان یک دایرکتوری انتشار سوار شده یا همگام شده آماده می‌کند. خود نمونه هیچ بارگذاری شبکه‌ای انجام نمی‌دهد: لینک‌های تولید شده پس از انتشار دایرکتوری در سایت یا مکان CDN موردنظر معتبر می‌شوند.

```python
import os
import aspose.slides as slides

publication_directory = os.path.join(
    "cdn-origin",
    "presentations",
    "quarterly-report")
os.makedirs(publication_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = publication_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(publication_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

فایل `presentation.md` را همراه با پوشهٔ `assets` منتشر کنید. سند Markdown از ارجاعات تصویر نسبی استفاده می‌کند، بنابراین هر دو آیتم باید رابطهٔ یکسانی را در مقصد حفظ کنند. اگر سیستم انتشار نیاز به URLهای خارجی مطلق داشته باشد، لینک‌های تولید شده را پس از انتشار تمام فایل‌های تصویر، در یک مرحلهٔ پردازش پس از تولید مجدداً بازنویسی کنید.

## **پرسش‌های متداول**

**آیا کال‌بک‌های پایتون می‌توانند فایل‌ها و لینک‌های تصویر فردی را در حین صادرات Markdown سفارشی کنند؟**

خیر. Aspose.Slides for Python via .NET بازتاب کال‌بک‌های .NET `ImageSaving` و `SvgImageSaving` را ارائه نمی‌دهد. خروجی محلی را با [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/markdownsaveoptions/base_path/) و [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) تنظیم کنید، سپس منابع تولید شده را منتشر یا پس از پردازش نمایید.

**تصاویر صادر شده کجا ذخیره می‌شوند؟**

محل ذخیره تصویر توسط [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/markdownsaveoptions/base_path/) و [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) کنترل می‌شود. سند Markdown با مسیرهای نسبی به آن تصاویر ارجاع می‌دهد.

**کدام جداکننده مسیر باید در لینک‌های تصویر استفاده شود؟**

در لینک‌ها و URLهای Markdown از اسلش‌های مستقیم استفاده کنید. `os.path.join` را فقط برای مسیرهای سیستم‑فایل به کار ببرید و هر لینکی که در پردازش پس از تولید ایجاد می‌شود، به‌صورت جداگانه نرمال کنید.

**آیا هایپرلینک‌ها در حین صادرات Markdown حفظ می‌شوند؟**

بله. متن [hyperlinks](/slides/fa/python-net/manage-hyperlinks/) به‌عنوان لینک‌های استاندارد Markdown حفظ می‌شود. اسلایدهای [transitions](/slides/fa/python-net/slide-transition/) و [animations](/slides/fa/python-net/powerpoint-animation/) تبدیل نمی‌شوند.

**آیا می‌توان ارائه‌ها را به صورت موازی به Markdown تبدیل کرد؟**

می‌توانید فایل‌های ارائهٔ مختلف را به‌صورت موازی پردازش کنید، اما نباید همان نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) را بین رشته‌ها به اشتراک بگذارید. راهنمایی‌های [multithreading guidelines](/slides/fa/python-net/multithreading/) را دنبال کنید و برای هر فایل از یک نمونه جداگانه استفاده نمایید.