---
title: كائن OLE
type: docs
weight: 210
url: /ar/python-net/examples/elements/ole-object/
keywords:
- كائن OLE
- إضافة كائن OLE
- الوصول إلى كائن OLE
- إزالة كائن OLE
- تحديث كائن OLE
- أمثلة على الشيفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "العمل مع كائنات OLE في Python باستخدام Aspose.Slides: إدراج أو تحديث الملفات المضمّنة، تعيين الأيقونات أو الروابط، استخراج المحتوى، التحكم في السلوك لملفات PPT و PPTX و ODP."
---
يوضح تضمين ملف ككائن OLE وتحديث بياناته باستخدام **Aspose.Slides for Python via .NET**.

## **إضافة كائن OLE**

تضمين ملف PDF في العرض التقديمي.

```py
def add_ole_object():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # تحميل بيانات PDF لتضمينها.
        with open("doc.pdf", "rb") as file_stream:
            data_info = slides.dom.ole.OleEmbeddedDataInfo(file_stream.read(), "pdf")

        # إضافة إطار كائن OLE إلى الشريحة.
        ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

        presentation.save("ole_frame.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى كائن OLE**

استرجاع إطار كائن OLE الأول في الشريحة.

```py
def access_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # الحصول على إطار كائن OLE الأول في الشريحة.
        first_ole = next(shape for shape in slide.shapes if isinstance(shape, slides.OleObjectFrame))
```

## **إزالة كائن OLE**

حذف كائن OLE المضمّن من الشريحة.

```py
def remove_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # بافتراض أن الشكل الأول هو كائن OleObjectFrame.
        ole_frame = slide.shapes[0]

        slide.shapes.remove(ole_frame)

        presentation.save("ole_frame_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **تحديث بيانات كائن OLE**

استبدال البيانات المضمّنة في كائن OLE الحالي.

```py
def update_ole_object_data():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # بافتراض أن الشكل الأول هو كائن OleObjectFrame.
        ole_frame = slide.shapes[0]

        with open("Picture.png", "rb") as picture_stream:
            new_data = slides.dom.ole.OleEmbeddedDataInfo(picture_stream.read(), "png")

        # تحديث كائن OLE بالبيانات المضمنة الجديدة.
        ole_frame.set_embedded_data(new_data)

        presentation.save("ole_frame_updated.pptx", slides.export.SaveFormat.PPTX)
```