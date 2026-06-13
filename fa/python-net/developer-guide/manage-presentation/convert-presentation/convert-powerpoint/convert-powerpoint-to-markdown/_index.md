---
title: تبدیل ارائه‌های PowerPoint به Markdown در Python
linktitle: PowerPoint به Markdown
type: docs
weight: 140
url: /fa/python-net/convert-powerpoint-to-markdown/
keywords:
- تبدیل PowerPoint به Markdown
- تبدیل OpenDocument به Markdown
- تبدیل ارائه به Markdown
- تبدیل اسلاید به Markdown
- تبدیل PPT به Markdown
- تبدیل PPTX به Markdown
- تبدیل ODP به Markdown
- تبدیل PowerPoint به MD
- تبدیل OpenDocument به MD
- تبدیل ارائه به MD
- تبدیل اسلاید به MD
- تبدیل PPT به MD
- تبدیل PPTX به MD
- تبدیل ODP به MD
- PowerPoint
- OpenDocument
- ارائه
- Markdown
- Python
- Aspose.Slides
description: "تبدیل اسلایدهای PowerPoint و OpenDocument—PPT، PPTX، ODP—به Markdown تمیز با Aspose.Slides برای Python از طریق .NET، مستندسازی را خودکار کنید و قالب‌بندی را حفظ کنید."
---
## **معرفی**

Aspose.Slides به شما امکان می‌دهد ارائه‌های PowerPoint را به Markdown تبدیل کنید که می‌تواند برای جریان‌های کاری مستندسازی، تولید سایت‌های ایستا، مهاجرت محتوا و انتشار متن تحت کنترل نسخه مفید باشد. این API از صادرات مستقیم ارائه‌های PPT و PPTX به فایل‌های MD پشتیبانی می‌کند و گزینه‌های اضافه‌ای برای کنترل نحوه نمایش محتوای اسلایدها در سند Markdown تولید شده فراهم می‌آورد.

می‌توانید ارائه‌ها را به صورت Markdown ساده صادر کنید، از میان چندین طعم Markdown مانند CommonMark و GitHub Flavored Markdown انتخاب کنید و نحوه پردازش تصاویر را در حین خروجی تنظیم کنید. برای ارائه‌هایی که محتوای تصویری دارند، Aspose.Slides همچنین به شما اجازه می‌دهد تصاویر را در یک پوشه جداگانه ذخیره کنید و از فایل Markdown تولید شده به آن‌ها ارجاع دهید.

{{% alert color="warning" %}}
صادرات PowerPoint به Markdown به‌صورت پیش‌فرض **بدون تصاویر** است. اگر می‌خواهید سند PowerPoint حاوی تصاویر را صادر کنید، باید `export_type = MarkdownExportType.VISUAL` را تنظیم کنید و `base_path` را مشخص کنید، جایی که تصاویر ارجاع داده شده در سند Markdown ذخیره خواهند شد.
{{% /alert %}}

## **تبدیل ارائه‌ها به Markdown**

مثال زیر ساده‌ترین روش برای تبدیل یک ارائه PowerPoint به Markdown را با استفاده از Aspose.Slides برای Python از طریق .NET با تنظیمات پیش‌فرض نشان می‌دهد.

1. یک [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید تا ارائه را بارگذاری کنید.
1. فراخوانی `save` برای صادر کردن آن به عنوان یک فایل Markdown.

از قطعه کد Python زیر برای انجام تبدیل استفاده کنید:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:  
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **تبدیل ارائه‌ها به قالب Markdown**

Aspose.Slides به شما امکان می‌دهد ارائه‌ها را به فرمت‌های Markdown تبدیل کنید، از جمله Markdown پایه، CommonMark، GitHub‑flavored Markdown، Trello، XWiki، GitLab و ۱۷ طعم دیگر Markdown.

مثال Python زیر نشان می‌دهد چگونه یک ارائه PowerPoint را به CommonMark تبدیل کنید:

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, save_options)
```

۲۳ طعم پشتیبانی‌شده Markdown در enumeration [Flavor](https://reference.aspose.com/slides/fa/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) از کلاس [MarkdownSaveOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) فهرست شده‌اند.

## **تبدیل ارائه‌های حاوی تصویر به Markdown**

کلاس [MarkdownSaveOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) ویژگی‌ها و enumerationهایی را فراهم می‌کند که به شما امکان پیکربندی فایل Markdown حاصل را می‌دهد. برای مثال، enum [MarkdownExportType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) نحوه پردازش تصاویر را کنترل می‌کند: `SEQUENTIAL`، `TEXT_ONLY` یا `VISUAL`.

### **تبدیل تصویر به صورت متوالی**

اگر می‌خواهید تصاویر به‌صورت جداگانه—یکی پس از دیگری—در Markdown تولید شده ظاهر شوند، گزینه `SEQUENTIAL` را انتخاب کنید. مثال Python زیر نشان می‌دهد چگونه یک ارائه حاوی تصاویر را به Markdown تبدیل کنید.

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.show_hidden_slides = True
save_options.show_slide_number = True
save_options.flavor = slides.export.Flavor.GITHUB
save_options.export_type = slides.export.MarkdownExportType.SEQUENTIAL
save_options.new_line_type = slides.export.NewLineType.WINDOWS

slide_indices = [1, 3, 5]

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slide_indices, slides.export.SaveFormat.MD, save_options)
```

### **تبدیل تصویر به صورت بصری**

اگر می‌خواهید تصاویر به‌صورت همراه در Markdown نهایی ظاهر شوند، گزینه `VISUAL` را انتخاب کنید. در این حالت، تصاویر در پوشهٔ فعلی برنامه ذخیره می‌شوند (و سند Markdown از مسیرهای نسبی استفاده می‌کند)، یا می‌توانید مسیر خروجی سفارشی و نام پوشه را تعیین کنید.

مثال Python زیر این عملیات را نشان می‌دهد:

```python
import os
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.export_type = slides.export.MarkdownExportType.VISUAL
save_options.images_save_folder_name = "md-images"
save_options.base_path = "c:\\documents"

with slides.Presentation("presentation.pptx") as presentation:
    file_path = os.path.join(save_options.base_path, "presentation.md")
    presentation.save(file_path, slides.export.SaveFormat.MD, save_options)
```

## **پرسش‌های متداول**

**آیا پیوندهای متنی در هنگام صادرات به Markdown حفظ می‌شوند؟**

بله. متن [hyperlinks](/slides/fa/python-net/manage-hyperlinks/) به‌صورت پیوندهای استاندارد Markdown حفظ می‌شود. [transitions](/slides/fa/python-net/slide-transition/) و [animations](/slides/fa/python-net/powerpoint-animation/) اسلاید تبدیل نمی‌شوند.

**آیا می‌توانم با اجرای تبدیل در چندین نخ سرعت را افزایش دهم؟**

می‌توانید پردازش را بر روی فایل‌ها موازی کنید، اما [به‌اشتراک‌گذاری نکنید](/slides/fa/python-net/multithreading/) همان شیء [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) را بین نخ‌ها به‌اشتراک نگذارید. برای هر فایل از نمونه‌ها/فرایندهای جداگانه استفاده کنید تا از تداخل جلوگیری شود.

**چه اتفاقی برای تصاویر می‌افتد—کجا ذخیره می‌شوند و آیا مسیرها نسبی هستند؟**

تصاویر [Images](/slides/fa/python-net/image/) به یک پوشه اختصاصی صادر می‌شوند و فایل Markdown به‌صورت پیش‌فرض آن‌ها را با مسیرهای نسبی ارجاع می‌دهد. می‌توانید مسیر خروجی پایه و نام پوشهٔ دارایی‌ها را پیکربندی کنید تا ساختار مخزن پیش‌بینی‌پذیر باقی بماند.