---
title: هایپرلینک
type: docs
weight: 130
url: /fa/python-net/examples/elements/hyperlink/
keywords:
- هایپرلینک
- افزودن هایپرلینک
- دسترسی به هایپرلینک
- حذف هایپرلینک
- به‌روزرسانی هایپرلینک
- نمونه‌های کد
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "افزودن، ویرایش و حذف هایپرلینک‌ها در پایتون با Aspose.Slides: متن پیوند، اشکال، اسلایدها، URLها و ایمیل؛ تعیین هدف‌ها و اقدامات برای PPT، PPTX و ODP."
---
اضافه کردن، دسترسی، حذف و به روز رسانی هایپرلینک‌ها بر روی اشکال را با استفاده از **Aspose.Slides for Python via .NET** نشان می‌دهد.

## **افزودن یک هایپرلینک**
یک شکل مستطیلی با یک هایپرلینک که به یک وب سایت خارجی اشاره می‌کند ایجاد کنید.

```py
def add_hyperlink():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 50)
        shape.text_frame.text = "Aspose"

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com")

        presentation.save("hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **دسترسی به یک هایپرلینک**
اطلاعات هایپرلینک را از بخش متن یک شکل بخوانید.

```py
def access_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        hyperlink = text_portion.portion_format.hyperlink_click
```

## **حذف یک هایپرلینک**
هایپرلینک را از متن یک شکل پاک کنید.

```py
def remove_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = None

        presentation.save("hyperlink_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **به روز رسانی یک هایپرلینک**
هدف یک هایپرلینک موجود را تغییر دهید. از `HyperlinkManager` برای اصلاح متنی که قبلاً شامل یک هایپرلینک است استفاده کنید، که نحوه به روز رسانی ایمن هایپرلینک‌ها در PowerPoint را شبیه سازی می‌کند.

```py
def update_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        # تغییر یک هایپرلینک در متن موجود باید از طریق
        # HyperlinkManager نه تنظیم مستقیم ویژگی انجام شود.
        # این شبیه‌سازی نحوه به‌روزرسانی ایمن هایپرلینک‌ها در PowerPoint است.
        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://new.example.com")

        presentation.save("hyperlink_updated.pptx", slides.export.SaveFormat.PPTX)
```