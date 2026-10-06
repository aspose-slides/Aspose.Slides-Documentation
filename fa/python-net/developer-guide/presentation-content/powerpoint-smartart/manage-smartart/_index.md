---
title: مدیریت SmartArt در ارائه‌های PowerPoint با استفاده از Python
linktitle: مدیریت SmartArt
type: docs
weight: 10
url: /fa/python-net/manage-smartart/
keywords:
- SmartArt
- متن SmartArt
- نوع طرح
- ویژگی مخفی
- نمودار سازمانی
- نمودار سازمانی تصویری
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه SmartArt PowerPoint را با Aspose.Slides برای Python از طریق .NET بسازید و ویرایش کنید با استفاده از نمونه‌های کد واضح که طراحی اسلاید و خودکارسازی را تسریع می‌کند."
---
## **نمای کلی**

SmartArt یک نمودار PowerPoint است که از گره‌ها، اشکال گره و یک طرح ساخته شده است. با Aspose.Slides برای Python از طریق .NET، می‌توانید SmartArt ایجاد کنید، متن را از گره‌های آن بخوانید، طرح آن را تغییر دهید، گره‌های مخفی را بررسی کنید، طرح‌های نمودار سازمانی را پیکربندی کنید و نمودارهای سازمانی تصویری ایجاد کنید.

## **دریافت متن از یک شیء SmartArt**

یک گره SmartArt می‌تواند یک یا چند شکل را شامل شود. برای خواندن متن از اشکال گره، از طریق [SmartArt.all_nodes](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/all_nodes/) تکرار کنید، سپس [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) بازگردانده شده توسط [SmartArtShape.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/text_frame/) را بخوانید.

این مثال به یک ارائه با حداقل یک اسلاید و یک شیء SmartArt به عنوان اولین شکل در آن اسلاید نیاز دارد. هر فریم متن موجود را در کنسول چاپ می‌کند.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        for node in shape.all_nodes:
            for node_shape in node.shapes:
                if node_shape.text_frame is not None:
                    print(node_shape.text_frame.text)
```

## **تغییر نوع طرح یک شیء SmartArt**

طرح SmartArt کنترل می‌کند که گره‌ها چگونه مرتب و متصل می‌شوند. مثال زیر یک شیء SmartArt را با مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST` ایجاد می‌کند، آن را به مقدار `BASIC_PROCESS` تغییر می‌دهد و ارائه را ذخیره می‌کند. موقعیت و اندازه‌ای که به [ShapeCollection.add_smart_art](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_smart_art/) منتقل می‌شود بر حسب نقطه اندازه‌گیری می‌شود. برای تغییر طرح، [SmartArt.layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/layout/) را تنظیم کنید.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **بررسی اینکه آیا گره SmartArt مخفی است یا نه**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/is_hidden/) نشان می‌دهد که آیا گره در مدل داده SmartArt مخفی است یا نه. گره‌های مخفی می‌توانند در ساختار وجود داشته باشند حتی وقتی طرح انتخاب‌شده آن‌ها را به عنوان عناصر نمودار قابل مشاهده نمایش نمی‌دهد.

مثال زیر یک گره به یک شیء SmartArt که از مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` استفاده می‌کند اضافه می‌کند و وضعیت مخفی بودن گره اضافه‌شده را بررسی می‌کند. اگر گره مخفی باشد، یک پیام چاپ می‌کند و نمودار را ذخیره می‌کند.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)
    node = smart_art.all_nodes.add_node()
    is_hidden = node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", slides.export.SaveFormat.PPTX)
```

## **دریافت یا تنظیم طرح نمودار سازمانی**

برای نمودارهای SmartArt که از طرح نمودار سازمانی استفاده می‌کنند، [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) تعریف می‌کند که گره‌های فرزند تحت یک گره والد چگونه مرتب می‌شوند. برای مثال، می‌توانید گره‌های فرزند را طوری تنظیم کنید که از سمت چپ، راست یا هر دو طرف آویزان شوند، بسته به نوع [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) انتخاب‌شده.

مثال زیر یک نمودار سازمانی ایجاد می‌کند و طرح گره اول را به مقدار [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING` تنظیم می‌کند. اندیس صفر‑مبنا `0` اولین گره سطح بالا را انتخاب می‌کند؛ گره‌های فرزند آن از چینش انتخاب‌شده استفاده می‌کنند. سپس ارائه اصلاح‌شده ذخیره می‌شود.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)
    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **ایجاد نمودار سازمانی تصویری**

نمودار سازمانی تصویری یک طرح SmartArt است که برای نمودارهای سلسله‌مراتبی شامل نگهدارنده‌های تصویر طراحی شده است. هنگام افزودن شیء SmartArt به یک اسلاید، مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` را استفاده کنید. این مثال نموداری با نگهدارنده‌های تصویر ذخیره می‌کند؛ اما این نگهدارنده‌ها را با تصویر پر نمی‌کند.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **تبدیل نمودارهای قدیمی به گروهی از اشکال**

در هنگام به‌روزرسانی یک ارائه موجود، ممکن است نیاز داشته باشید نمودار سازمانی ایجادشده در PowerPoint 97–2003 را به‌روز کنید. Aspose.Slides این نمودارهای قدیمی را به عنوان اشیای [LegacyDiagram](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/) نمایش می‌دهد. از [LegacyDiagram.convert_to_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/convert_to_group_shape/) برای تبدیل یک نمودار به گروهی از اشکال استفاده کنید تا بتوانید عناصر بصری فردی را ویرایش کنید. برای جزئیات به [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/) مراجعه کنید.

تبدیل یک گروه جدید به مجموعه اشکال اضافه می‌کند بدون اینکه نمودار اصلی حذف شود. پس از تبدیل موفق، برای جلوگیری از محتوای تکراری، اصلی را با [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) حذف کنید. قبل از تبدیل، نمودارهای قدیمی را در یک لیست جمع‌آوری کنید تا اضافه و حذف اشکال در طول تکرار باعث اختلال نشود.

مثال زیر یک ارائه را باز می‌کند، هر اسلاید را جستجو می‌کند، نمودارها را به گروهی از اشکال تبدیل می‌کند و ارائه به‌روزشده را به صورت PPTX ذخیره می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("legacy-diagrams.ppt") as presentation:
    for slide in presentation.slides:
        legacy_diagrams = [shape for shape in slide.shapes if isinstance(shape, slides.LegacyDiagram)]
        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convert_to_group_shape()

            if group_shape is not None:
                slide.shapes.remove(legacy_diagram)

    presentation.save("modernized.pptx", slides.export.SaveFormat.PPTX)
```

ارائه ذخیره‌شده شامل گروه‌های قابل ویرایش از اشکال به‌جای نمودارهای قدیمی تبدیل‌شده است و دیگر هیچ نمودار اصلی در کنار آن‌ها باقی نمانده است. PPTX را در PowerPoint باز کنید تا عناصر فردی داخل هر گروه مانند متن، پرکننده یا موقعیت آن‌ها را ویرایش کنید.

## **سوالات رایج**

**آیا SmartArt از انعکاس یا معکوس‌سازی برای زبان‌های راست به چپ پشتیبانی می‌کند؟**  
بله. ویژگی [SmartArt.is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) جهت نمودار را از چپ به راست به راست به چپ یا برعکس تغییر می‌دهد وقتی طرح انتخاب‌شده SmartArt از معکوس‌سازی پشتیبانی می‌کند.

**چگونه می‌توانم SmartArt را در همان اسلاید یا به ارائه دیگری کپی کنم در حالی که قالب‌بندی حفظ شود؟**  
می‌توانید [کلون کردن شکل SmartArt](/slides/fa/python-net/shape-manipulations/) را با [ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/) یا [کلون کردن کل اسلاید](/slides/fa/python-net/clone-slides/) که شامل SmartArt است، انجام دهید. هر دو روش اندازه، موقعیت و قالب‌بندی را حفظ می‌کنند.

**چگونه می‌توانم SmartArt را به تصویر رستر برای پیش‌نمایش یا صادرات وب رندر کنم؟**  
می‌توانید [رندر اسلاید](/slides/fa/python-net/convert-powerpoint-to-png/) یا کل ارائه را به PNG یا JPEG تبدیل کنید. SmartArt به عنوان بخشی از اسلاید رندر می‌شود.

**چگونه می‌توانم یک شیء SmartArt خاص را در اسلاید پیدا کنم اگر چندین تا وجود داشته باشند؟**  
یک مقدار متمایز برای [Shape.alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) یا [Shape.name](https://reference.aspose.com/slides/python-net/aspose.slides/shape/name/) روی شکل SmartArt تنظیم کنید، آن مقدار را در [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) جستجو کنید و سپس بررسی کنید که شکل همسان یک [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) باشد.