---
title: ذخیره ارائه‌ها در پایتون
linktitle: ذخیره ارائه‌ها
type: docs
weight: 80
url: /fa/python-net/save-presentation/
keywords:
- ذخیره پاورپوینت
- ذخیره OpenDocument
- ذخیره ارائه
- ذخیره اسلاید
- ذخیره PPT
- ذخیره PPTX
- ذخیره ODP
- ارائه به فایل
- ارائه به جریان
- نوع نمای پیش‌تعریف‌شده
- قالب Strict Office Open XML
- حالت Zip64
- به‌روزرسانی تصویر بندانگشتی
- پیشرفت ذخیره‌سازی
- پایتون
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید ارائه‌ها را در پایتون با استفاده از Aspose.Slides ذخیره کنید—به‌صورت PowerPoint یا OpenDocument صادر کنید در حالی که طرح‌ها، فونت‌ها و افکت‌ها حفظ می‌شوند."
---
## **مروری کلی**

[باز کردن یک ارائه در پایتون](/slides/fa/python-net/open-presentation/) نحوهٔ استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای باز کردن یک ارائه را شرح داد. این مقاله نحوهٔ ایجاد و ذخیرهٔ ارائه‌ها را توضیح می‌دهد. کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) شامل محتوای یک ارائه است. چه در حال ایجاد یک ارائه از ابتدا باشید یا در حال تغییر یک ارائه موجود، پس از اتمام می‌خواهید آن را ذخیره کنید. با Aspose.Slides برای پایتون، می‌توانید در یک **فایل** یا **جریان** ذخیره کنید. این مقاله روش‌های مختلف ذخیرهٔ یک ارائه را شرح می‌دهد.

## **ذخیره ارائه‌ها در فایل‌ها**

Save a presentation to a file by calling the [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) class’s `save` method. Pass the file name and save format to the method. The following example show how to save a presentation with Aspose.Slides for Python.

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation که نشان‌دهنده یک فایل ارائه است.
with slides.Presentation() as presentation:
    
    # در اینجا کارهایی انجام دهید...

    # ارائه را در یک فایل ذخیره کنید.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ذخیره ارائه‌ها در جریان‌ها**

You can save a presentation to a stream by passing an output stream to the [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) class’s `save` method. A presentation can be written to many stream types. In the example below, we create a new presentation, add text to a shape, and save it to a stream.

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation که نشان‌دهنده یک فایل ارائه است.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # ارائه را در جریان ذخیره کنید.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **ذخیره ارائه‌ها با نوع نمای پیش‌تعریف شده**

Aspose.Slides for Python lets you set the initial view that PowerPoint uses when the generated presentation opens through the [ViewProperties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewproperties/) class. Set the `last_view` property to a value from the [ViewType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewtype/) enumeration.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **ذخیره ارائه‌ها در فرمت Strict Office Open XML**

Aspose.Slides lets you save a presentation in the Strict Office Open XML format. Use the [PptxOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/pptxoptions/) class and set its conformance property when saving. If you set `Conformance.ISO_29500_2008_STRICT`, the output file is saved in the Strict Office Open XML format.

The example below creates a presentation and saves it in the Strict Office Open XML format.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# یک نمونه از کلاس Presentation که نشان‌دهنده یک فایل ارائه است.
with slides.Presentation() as presentation:
    # ارائه را در قالب Strict Office Open XML ذخیره کنید.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **ذخیره ارائه‌ها در فرمت Office Open XML در حالت Zip64**

An Office Open XML file is a ZIP archive that imposes 4 GB (2^32 bytes) limits on the uncompressed size of any file, the compressed size of any file, and the total size of the archive, and it also limits the archive to 65,535 (2^16-1) files. ZIP64 format extensions raise these limits to 2^64.

The [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) property lets you choose when to use ZIP64 format extensions when saving an Office Open XML file.

This property provides the following modes:

- `IF_NECESSARY` فقط در صورتی که ارائه از محدودیت‌های فوق فراتر رود، از افزونه‌های قالب ZIP64 استفاده می‌کند. این حالت پیش‌فرض است.
- `NEVER` هرگز از افزونه‌های قالب ZIP64 استفاده نمی‌کند.
- `ALWAYS` همیشه از افزونه‌های قالب ZIP64 استفاده می‌کند.

The following code demonstrates how to save a presentation as PPTX with ZIP64 format extensions enabled:

```py
pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}
When you save with `Zip64Mode.NEVER`, a [PptxException](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pptxexception/) is thrown if the presentation cannot be saved in ZIP32 format.
{{% /alert %}}

## **ذخیره ارائه‌ها بدون به‌روزرسانی تصویر بندانگشتی**

The [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) property controls thumbnail generation when saving a presentation to PPTX:

- اگر به `True` تنظیم شود، تصویر بندانگشتی هنگام ذخیره به‌روزرسانی می‌شود. این مقدار پیش‌فرض است.
- اگر به `False` تنظیم شود، تصویر بندانگشتی فعلی حفظ می‌شود. اگر ارائه تصویر بندانگشتی نداشته باشد، هیچ‌کدام تولید نمی‌شود.

In the code below, the presentation is saved to PPTX without refreshing its thumbnail.

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}
این گزینه به کاهش زمان مورد نیاز برای ذخیرهٔ ارائه در فرمت PPTX کمک می‌کند.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Aspose یک برنامهٔ رایگان تقسیم‌کننده PowerPoint (PowerPoint Splitter) را با استفاده از API خود توسعه داده است. این برنامه به شما امکان می‌دهد یک ارائه را به چندین فایل تقسیم کنید با ذخیرهٔ اسلایدهای انتخاب‌شده به عنوان فایل‌های جدید PPTX یا PPT.
{{% /alert %}}

## **پرسش‌های متداول**

**آیا «ذخیره سریع» (ذخیره افزایشی) پشتیبانی می‌شود تا فقط تغییرات نوشته شوند؟**

خیر. هر بار ذخیره، فایل هدف کامل ایجاد می‌شود؛ ذخیره افزایشی «سرعتی» پشتیبانی نمی‌شود.

**آیا ذخیرهٔ همان نمونه Presentation از چندین رشته به‌صورت thread‑safe است؟**

خیر. یک نمونه Presentation thread‑safe نیست؛ آن را فقط از یک رشته ذخیره کنید.

**چه اتفاقی برای پیوندهای هیپرتکست و فایل‌های لینک‌شده خارجی هنگام ذخیره می‌افتد؟**

[Hyperlinks](/slides/fa/python-net/manage-hyperlinks/) حفظ می‌شوند. فایل‌های لینک‌شده خارجی (مانند ویدیوها via relative paths) به‌صورت خودکار کپی نمی‌شوند—اطمینان حاصل کنید مسیرهای مرجع قابل دسترسی باقی بمانند.

**آیا می‌توانم متادادهٔ سند (نویسنده، عنوان، شرکت، تاریخ) را تنظیم/ذخیره کنم؟**

بله. ویژگی‌های استاندارد سند پشتیبانی می‌شوند و هنگام ذخیره به فایل نوشته می‌شوند.