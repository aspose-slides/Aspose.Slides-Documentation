---
title: مدیریت SmartArt در ارائه‌های PowerPoint با استفاده از Python
linktitle: مدیریت SmartArt
type: docs
weight: 10
url: /fa/python-net/manage-smartart/
keywords:
- SmartArt
- متن از SmartArt
- نوع طرح‌بندی
- ویژگی مخفی
- نمودار سازمانی
- نمودار سازمانی تصویر
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه SmartArt در PowerPoint را با Aspose.Slides برای Python از طریق .NET بسازید و ویرایش کنید، با استفاده از نمونه‌های کد واضح که طراحی اسلاید و خودکارسازی را تسریع می‌کند."
---
## **نمای کلی**

SmartArt یک نمودار PowerPoint است که از گره‌ها، شکل‌های گره و یک طرح‌بندی ساخته شده است. با Aspose.Slides برای Python از طریق .NET، می‌توانید SmartArt ایجاد کنید، متن را از گره‌های آن بخوانید، طرح‌بندی آن را تغییر دهید، گره‌های مخفی را بررسی کنید، طرح‌بندی نمودارهای سازمانی را پیکربندی کنید و نمودارهای سازمانی تصویری بسازید.

## **دریافت متن از یک شیء SmartArt**

یک گره SmartArt می‌تواند یک یا چند شکل را شامل شود. برای خواندن متن قابل نمایش، به‌صورت تکراری بر روی [SmartArt.all_nodes](https://reference.aspose.com/slides/fa/python-net/aspose.slides.smartart/smartart/all_nodes/) مرور کنید، سپس [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) برگردانده‌شده توسط [SmartArtShape.text_frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides.smartart/smartartshape/text_frame/) را بخوانید.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        smart_art = shape

        for smart_art_node in smart_art.all_nodes:
            for smart_art_shape in smart_art_node.shapes:
                if smart_art_shape.text_frame is not None:
                    print(smart_art_shape.text_frame.text)
```

## **تغییر نوع طرح‌بندی یک شیء SmartArt**

طرح‌بندی SmartArt کنترل می‌کند گره‌ها چگونه چینیده و به‌هم متصل می‌شوند. مثال زیر یک شیء SmartArt را با مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST` ایجاد می‌کند، آن را به مقدار `BASIC_PROCESS` تغییر می‌دهد و ارائه را ذخیره می‌کند.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **بررسی اینکه آیا یک گره SmartArt مخفی است یا نه**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/fa/python-net/aspose.slides.smartart/smartartnode/is_hidden/) نشان می‌دهد آیا گره در مدل داده‌ای SmartArt مخفی است یا نه. گره‌های مخفی می‌توانند در ساختار وجود داشته باشند حتی زمانی که طرح‌بندی انتخابی آن‌ها را به‌عنوان المان‌های نموداری قابل مشاهده نشان نمی‌دهد.

مثال زیر یک گره به شیء SmartArt که از مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` استفاده می‌کند، اضافه می‌کند و وضعیت مخفی بودن گره را بررسی می‌کند.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    smart_art_node = smart_art.all_nodes.add_node()
    is_hidden = smart_art_node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", slides.export.SaveFormat.PPTX)
```

## **دریافت یا تنظیم طرح‌بندی نمودار سازمانی**

برای نمودارهای SmartArt که از طرح‌بندی نمودار سازمانی استفاده می‌کنند، [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/fa/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) نحوه چینش گره‌های فرزند زیر یک گره والد را تعریف می‌کند. به عنوان مثال می‌توانید گره‌های فرزند را طوری تنظیم کنید که از سمت چپ، راست یا هر دو طرف آویزان شوند، بسته به [OrganizationChartLayoutType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.smartart/organizationchartlayouttype/) انتخابی.

مثال زیر یک نمودار سازمانی ایجاد می‌کند و طرح‌بندی گرهٔ اول را به مقدار [OrganizationChartLayoutType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING` تنظیم می‌کند.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ایجاد نمودار سازمانی تصویری**

نمودار سازمانی تصویری یک طرح‌بندی SmartArt است که برای نمودارهای سلسله‌مراتبی شامل محل‌نگهدارهای تصویر طراحی شده است. هنگام افزودن شیء SmartArt به اسلاید، از مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` استفاده کنید.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**آیا SmartArt از آینه‌کردن یا وارونه‌سازی برای زبان‌های راست به چپ پشتیبانی می‌کند؟**

بله. ویژگی [SmartArt.is_reversed](https://reference.aspose.com/slides/fa/python-net/aspose.slides.smartart/smartart/is_reversed/) جهت نمودار را از چپ به راست به راست به چپ یا بالعکس تغییر می‌دهد، هنگامی که طرح‌بندی SmartArt انتخابی از وارونه‌سازی پشتیبانی کند.

**چگونه می‌توانم SmartArt را در همان اسلاید یا در یک ارائه دیگر کپی کنم در حالی که قالب‌بندی حفظ شود؟**

می‌توانید با استفاده از [ShapeCollection.add_clone](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/add_clone/) شکل SmartArt را [کلون کنید](/slides/fa/python-net/shape-manipulations/) یا با کلون کردن تمام اسلایدی که SmartArt را شامل می‌شود [/slides/fa/python-net/clone-slides/](/slides/fa/python-net/clone-slides/). هر دو روش اندازه، موقعیت و قالب‌بندی را حفظ می‌کنند.

**چگونه می‌توانم SmartArt را به تصویر رستر برای پیش‌نمایش یا صادرات وب رندر کنم؟**

[/slides/fa/python-net/convert-powerpoint-to-png/](/slides/fa/python-net/convert-powerpoint-to-png/) اسلاید یا کل ارائه را به PNG یا JPEG تبدیل کنید. SmartArt به‌عنوان بخشی از اسلاید رندر می‌شود.

**اگر چندین SmartArt روی یک اسلاید وجود داشته باشد، چگونه می‌توانم شیء SmartArt خاصی را پیدا کنم؟**

یک مقدار متمایز برای [Shape.alternative_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/alternative_text/) یا [Shape.name](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/name/) روی شکل SmartArt تنظیم کنید، آن مقدار را در [Slide.shapes](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/shapes/) جستجو کنید و سپس بررسی کنید که شکل یافت‌شده یک [SmartArt](https://reference.aspose.com/slides/fa/python-net/aspose.slides.smartart/smartart/) باشد.