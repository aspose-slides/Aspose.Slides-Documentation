---
title: استخراج الصور من أشكال العرض التقديمي في Python
linktitle: صورة من الشكل
type: docs
weight: 90
url: /ar/python-net/extracting-images-from-presentation-shapes/
keywords:
- استخراج الصورة
- استرجاع الصورة
- خلفية الشريحة
- خلفية الشكل
- PowerPoint
- العرض التقديمي
- Python
- Aspose.Slides
description: "استخراج الصور من الأشكال في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for Python via .NET — حل سريع وصديق للشفرة."
---

## **استخراج الصور من الأشكال**

{{% alert color="primary" %}} 

غالبًا ما يتم إضافة الصور إلى الأشكال وتُستخدم أيضًا كثيرًا كخلفيات للشرائح. يتم إضافة كائنات الصورة عبر [IImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/)، وهي مجموعة من كائنات [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) . 

تشرح هذه المقالة كيفية استخراج الصور المضافة إلى العروض التقديمية. 

{{% /alert %}} 

لاستخراج صورة من عرض تقديمي، عليك أولاً تحديد موضع الصورة بالانتقال عبر كل شريحة ثم عبر كل شكل. بمجرد العثور على الصورة أو تحديدها، يمكنك استخراجها وحفظها كملف جديد. XXX 

```py
import aspose.slides as slides

def get_image_format(image_type):
    return {
        "jpeg": slides.ImageFormat.JPEG,
        "emf": slides.ImageFormat.EMF,
        "bmp": slides.ImageFormat.BMP,
        "png": slides.ImageFormat.PNG,
        "wmf": slides.ImageFormat.WMF,
        "gif": slides.ImageFormat.GIF,
    }.get(image_type, slides.ImageFormat.JPEG)

with slides.Presentation("pres.pptx") as pres:
    #الوصول إلى العرض التقديمي
    
    slideIndex = 0
    image_type = ""
    ifImageFound = False
    for slide in pres.slides:
        slideIndex += 1
        #الوصول إلى الشريحة الأولى
        image_format = slides.ImageFormat.JPEG

        back_image = None
        file_name = "BackImage_Slide_{0}{1}.{2}"
        is_layout = False

        if slide.background.fill_format.fill_type == slides.FillType.PICTURE:
            #الحصول على الصورة الخلفية  
            back_image = slide.background.fill_format.picture_fill_format.picture.image
        elif slide.layout_slide.background.fill_format.fill_type == slides.FillType.PICTURE:
            #الحصول على الصورة الخلفية  
            back_image = slide.layout_slide.background.fill_format.picture_fill_format.picture.image
            is_layout = True

        if back_image is not None:
            #تحديد تنسيق الصورة المطلوب 
            image_type = back_image.content_type.split("/")[1]
            image_format = get_image_format(image_type)

            back_image.image.save(
                file_name.format("LayoutSlide_" if is_layout else "", slideIndex, image_type), 
                image_format)

        for i in range(len(slide.shapes)):
            shape = slide.shapes[i]
            shape_image = None

            if type(shape) is slides.AutoShape and shape.fill_format.fill_type == slides.FillType.PICTURE:
                shape_image = shape.fill_format.picture_fill_format.picture.image
            elif type(shape) is slides.PictureFrame:
                shape_image = shape.picture_format.picture.image

            if shape_image is not None:
                image_type = shape_image.content_type.split("/")[1]
                image_format = get_image_format(image_type)

                shape_image.image.save(
                                file_name.format("shape_"+str(i)+"_", slideIndex, image_type), 
                                image_format)
```

## **الأسئلة المتكررة**

**هل يمكنني استخراج الصورة الأصلية دون أي قص أو تأثيرات أو تحويلات شكل؟**

نعم. عندما تصل إلى صورة الشكل، تحصل على كائن الصورة من [مجموعة الصور](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) الخاصة بالعرض التقديمي، ما يعني الحصول على البكسلات الأصلية دون قص أو تأثيرات تنسيق. يمر سير العمل عبر مجموعة الصور في العرض التقديمي وكائنات [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) التي تخزن البيانات الخام.

**هل هناك خطر من تكرار الملفات المتطابقة عند حفظ العديد من الصور دفعة واحدة؟**

نعم، إذا قمت بحفظ كل شيء دون تمييز. يمكن أن تحتوي [مجموعة الصور](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) الخاصة بالعرض التقديمي على بيانات ثنائية متطابقة يتم الإشارة إليها من أشكال أو شرائح مختلفة. لتجنب التكرار، قارن التجزئات أو الأحجام أو محتويات البيانات المستخرجة قبل الكتابة.

**كيف يمكنني تحديد أي الأشكال مرتبطة بصورة محددة من مجموعة العرض التقديمي؟**

Aspose.Slides لا يحتفظ بروابط عكسية من [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) إلى الأشكال. يمكنك بناء خريطة يدوية أثناء الاستعراض: كلما وجدت إشارة إلى [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)، سجل أي الأشكال تستخدمها.

**هل يمكنني استخراج الصور المدمجة داخل كائنات OLE، مثل المستندات المرفقة؟**

ليس مباشرة، لأن كائن OLE هو حاوية. تحتاج إلى استخراج حزمة OLE نفسها ثم تحليل محتوياتها باستخدام أدوات منفصلة. تعمل أشكال الصور في العرض التقديمي عبر [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)؛ OLE هو نوع كائن مختلف.