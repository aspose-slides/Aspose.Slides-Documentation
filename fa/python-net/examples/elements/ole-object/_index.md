---
title: شیء OLE
type: docs
weight: 210
url: /fa/python-net/examples/elements/ole-object/
keywords:
- شیء OLE
- افزودن شیء OLE
- دسترسی به شیء OLE
- حذف شیء OLE
- به‌روزرسانی شیء OLE
- مثال‌های کد
- پاورپوینت
- سند باز
- ارائه
- پایتون
- Aspose.Slides
description: "کار با اشیاء OLE در پایتون با استفاده از Aspose.Slides: درج یا به‌روزرسانی فایل‌های جاسازی‌شده، تنظیم آیکون یا لینک‌ها، استخراج محتوا، کنترل رفتار برای PPT، PPTX و ODP."
---
نشان می‌دهد که چگونه یک فایل را به‌عنوان شیء OLE جاسازی کنید و داده‌های آن را با استفاده از **Aspose.Slides for Python via .NET** به‌روزرسانی کنید.

## **افزودن یک شیء OLE**

یک فایل PDF را در ارائه جاسازی کنید.

```py
def add_ole_object():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # داده‌های PDF را برای جاسازی بارگیری کنید.
        with open("doc.pdf", "rb") as file_stream:
            data_info = slides.dom.ole.OleEmbeddedDataInfo(file_stream.read(), "pdf")

        # یک قاب شیء OLE به اسلاید اضافه کنید.
        ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

        presentation.save("ole_frame.pptx", slides.export.SaveFormat.PPTX)
```

## **دسترسی به یک شیء OLE**

قاب اولیه شیء OLE را در یک اسلاید بازیابی کنید.

```py
def access_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # دریافت اولین قاب شیء OLE روی اسلاید.
        first_ole = next(shape for shape in slide.shapes if isinstance(shape, slides.OleObjectFrame))
```

## **حذف یک شیء OLE**

یک شیء OLE جاسازی شده را از اسلاید حذف کنید.

```py
def remove_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # فرض بر این است که اولین شکل یک شیء OleObjectFrame است.
        ole_frame = slide.shapes[0]

        slide.shapes.remove(ole_frame)

        presentation.save("ole_frame_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **به‌روزرسانی داده‌های شیء OLE**

داده‌های جاسازی‌شده در یک شیء OLE موجود را جایگزین کنید.

```py
def update_ole_object_data():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # فرض بر این است که اولین شکل یک شیء OleObjectFrame است.
        ole_frame = slide.shapes[0]

        with open("Picture.png", "rb") as picture_stream:
            new_data = slides.dom.ole.OleEmbeddedDataInfo(picture_stream.read(), "png")

        # به‌روزرسانی شیء OLE با داده‌های جدید جاسازی‌شده.
        ole_frame.set_embedded_data(new_data)

        presentation.save("ole_frame_updated.pptx", slides.export.SaveFormat.PPTX)
```