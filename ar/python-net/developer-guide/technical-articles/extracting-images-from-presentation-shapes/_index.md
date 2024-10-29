---
title: استخراج الصور من أشكال العرض التقديمي
type: docs
weight: 90
url: /ar/python-net/extracting-images-from-presentation-shapes/
keywords: "استخراج الصورة، PowerPoint، PPT، PPTX، عرض PowerPoint، بايثون، Aspose.Slides for Python"
description: "استخراج الصور من عرض PowerPoint في بايثون"
---

{{% alert color="primary" %}} 

غالبًا ما تتم إضافة الصور إلى الأشكال وتستخدم أيضًا كخلفيات للشرائح. يتم إضافة كائنات الصورة من خلال [IImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/)، وهي مجموعة من كائنات [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/). 

توضح هذه المقالة كيفية استخراج الصور المضافة إلى العروض التقديمية. 

{{% /alert %}} 

لاستخراج صورة من عرض تقديمي، يجب عليك تحديد موقع الصورة أولاً عن طريق المرور عبر كل شريحة ثم المرور عبر كل شكل. بمجرد العثور على الصورة أو تحديدها، يمكنك استخراجها وحفظها كملف جديد. XXX 

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
            #تعيين تنسيق الصورة المطلوب 
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