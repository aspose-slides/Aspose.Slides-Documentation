---
title: SmartArt
type: docs
weight: 140
url: /ar/python-net/examples/elements/smart-art/
keywords:
- SmartArt
- إضافة SmartArt
- الوصول إلى SmartArt
- إزالة SmartArt
- تخطيط SmartArt
- أمثلة على الشيفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إنشاء وتعديل SmartArt في Python باستخدام Aspose.Slides: إضافة العقد، تغيير التخطيطات والأنماط، تحويله إلى أشكال بدقة، وتصديره إلى PPT و PPTX و ODP."
---
يوضح كيفية إضافة رسومات SmartArt، الوصول إليها، إزالتها، وتغيير التخطيطات باستخدام **Aspose.Slides for Python via .NET**.

## **إضافة SmartArt**

إدراج رسم SmartArt باستخدام أحد التخطيطات المدمجة.

```py
def add_smart_art():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        smart_art = slide.shapes.add_smart_art(50, 50, 400, 300, slides.smartart.SmartArtLayoutType.BASIC_PROCESS)

        presentation.save("smart_art.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى SmartArt**

استرجاع أول كائن SmartArt في الشريحة.

```py
def access_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # الوصول إلى أول شكل SmartArt.
        first_smart_art = next(shape for shape in slide.shapes if isinstance(shape, slides.smartart.SmartArt))
```

## **إزالة SmartArt**

حذف شكل SmartArt من الشريحة.

```py
def remove_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # يفترض أن الشكل الأول هو كائن SmartArt.
        smart_art = slide.shapes[0]

        slide.shapes.remove(smart_art)

        presentation.save("smart_art_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **تغيير تخطيط SmartArt**

تحديث نوع التخطيط لرسمة SmartArt موجودة.

```py
def change_smart_art_layout():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # افتراض أن الشكل الأول هو كائن SmartArt.
        smart_art = slide.shapes[0]

        # تغيير تخطيط SmartArt.
        smart_art.layout = slides.smartart.SmartArtLayoutType.VERTICAL_PICTURE_LIST

        presentation.save("smart_art_changed.pptx", slides.export.SaveFormat.PPTX)
```