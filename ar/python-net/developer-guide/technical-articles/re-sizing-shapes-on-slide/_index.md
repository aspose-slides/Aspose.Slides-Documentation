---
title: تغيير حجم الأشكال على الشريحة
type: docs
weight: 130
url: /python-net/re-sizing-shapes-on-slide/
---

## **تغيير حجم الأشكال على الشريحة**
أحد الأسئلة الأكثر تكرارًا التي يطرحها عملاء Aspose.Slides لـ Python عبر .NET هو كيفية تغيير حجم الأشكال بحيث عندما يتم تغيير حجم الشريحة لا يتم قطع البيانات. تعرض هذه النصيحة الفنية القصيرة كيفية تحقيق ذلك.

لتجنب انحراف الأشكال، يجب تحديث كل شكل على الشريحة وفقًا لحجم الشريحة الجديد.

```py
import aspose.slides as slides

#تحميل عرض تقديمي
with slides.Presentation("pres.pptx") as presentation:
    #حجم الشريحة القديم
    currentHeight = presentation.slide_size.size.height
    currentWidth = presentation.slide_size.size.width

    #تغيير حجم الشريحة
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    #حجم الشريحة الجديد
    newHeight = presentation.slide_size.size.height
    newWidth = presentation.slide_size.size.width

    ratioHeight = newHeight / currentHeight
    ratioWidth = newWidth / currentWidth

    for slide in presentation.slides:
        for shape in slide.shapes:
            #تغيير حجم الموقع
            shape.height = shape.height * ratioHeight
            shape.width = shape.width * ratioWidth

            #تغيير حجم الشكل إذا لزم الأمر 
            shape.y = shape.y * ratioHeight
            shape.x = shape.x * ratioWidth

    presentation.save("Resize-1.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

إذا كان هناك أي جدول في الشريحة، فإن الكود أعلاه قد لا يعمل بشكل مثالي. في هذه الحالة، يجب تغيير حجم كل خلية من خلايا الجدول.

{{% /alert %}} 

تحتاج إلى استخدام الكود التالي من جانبك إذا كنت بحاجة إلى تغيير حجم الشرائح التي تحتوي على جداول. ضبط عرض أو ارتفاع الجدول هو حالة خاصة في الأشكال حيث تحتاج إلى تغيير ارتفاع الصفوف الفردية وعرض الأعمدة لتغيير ارتفاع الجدول وعرضه.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    #حجم الشريحة القديم
    currentHeight = presentation.slide_size.size.height
    currentWidth = presentation.slide_size.size.width

    #تغيير حجم الشريحة
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    #حجم الشريحة الجديد
    newHeight = presentation.slide_size.size.height
    newWidth = presentation.slide_size.size.width


    ratioHeight = newHeight / currentHeight
    ratioWidth = newWidth / currentWidth

    for master in presentation.masters:
        for shape in master.shapes:
            #تغيير حجم الموقع
            shape.height = shape.height * ratioHeight
            shape.width = shape.width * ratioWidth

            #تغيير حجم الشكل إذا لزم الأمر 
            shape.y = shape.y * ratioHeight
            shape.x = shape.x * ratioWidth

        for layoutslide in master.layout_slides:
            for shape in layoutslide.shapes:
                #تغيير حجم الموقع
                shape.height = shape.height * ratioHeight
                shape.width = shape.width * ratioWidth

                #تغيير حجم الشكل إذا لزم الأمر 
                shape.y = shape.y * ratioHeight
                shape.x = shape.x * ratioWidth

    for slide in presentation.slides:
        for shape in slide.shapes:
            #تغيير حجم الموقع
            shape.height = shape.height * ratioHeight
            shape.width = shape.width * ratioWidth

            #تغيير حجم الشكل إذا لزم الأمر 
            shape.y = shape.y * ratioHeight
            shape.x = shape.x * ratioWidth
            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * ratioHeight
                for col in shape.columns:
                    col.width = col.width * ratioWidth

    presentation.save("Resize-2.pptx", slides.export.SaveFormat.PPTX)
```