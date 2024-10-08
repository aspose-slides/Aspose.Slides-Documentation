---
title: صورة
type: docs
weight: 10
url: /ar/python-net/image/
keywords: "إضافة صورة، إضافة صورة، عرض PowerPoint، EMF، SVG، بايثون، Aspose.Slides لـ بايثون عبر .NET"
description: "إضافة صورة إلى شريحة PowerPoint أو عرض تقديمي في بايثون"
---

## **الصور في الشرائح في العروض التقديمية**

تجعل الصور العروض التقديمية أكثر تفاعلًا واهتمامًا. في Microsoft PowerPoint، يمكنك إدراج صور من ملف أو من الإنترنت أو من مواقع أخرى إلى الشرائح. وبالمثل، تتيح لك Aspose.Slides إضافة صور إلى الشرائح في عروضك التقديمية من خلال إجراءات مختلفة.

{{% alert title="نصيحة" color="primary" %}} 

توفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تتيح للناس إنشاء عروض تقديمية بسرعة من الصور.

{{% /alert %}} 

{{% alert title="معلومات" color="info" %}}

إذا كنت ترغب في إضافة صورة ككائن إطار—خاصة إذا كنت تخطط لاستخدام خيارات التنسيق القياسية لتغيير حجمها وإضافة تأثيرات وما إلى ذلك—راجع [إطار الصورة](https://docs.aspose.com/slides/python-net/picture-frame/).

{{% /alert %}} 

{{% alert title="ملاحظة" color="warning" %}}

يمكنك التلاعب بعمليات الإدخال/الإخراج المتعلقة بالصور وعروض PowerPoint لتحويل صورة من تنسيق إلى آخر. راجع هذه الصفحات: تحويل [صورة إلى JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/)؛ تحويل [JPG إلى صورة](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/)؛ تحويل [JPG إلى PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/)؛ تحويل [PNG إلى JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/)؛ تحويل [PNG إلى SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/)؛ تحويل [SVG إلى PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

تدعم Aspose.Slides عمليات الصور في هذه التنسيقات الشائعة: JPEG، PNG، BMP، GIF، وغيرها.

## **إضافة الصور المخزنة محليًا إلى الشرائح**

يمكنك إضافة صورة واحدة أو عدة صور من جهاز الكمبيوتر الخاص بك إلى شريحة في عرض تقديمي. يوضح لك هذا الرمز المصدري في بايثون كيفية إضافة صورة إلى شريحة:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    pres.save("pres_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **إضافة الصور من الويب إلى الشرائح**

إذا كانت الصورة التي تريد إضافتها إلى شريحة غير متاحة على جهاز الكمبيوتر الخاص بك، يمكنك إضافة الصورة مباشرة من الويب.

هذا الرمز المصدري يظهر لك كيفية إضافة صورة من الويب إلى شريحة في بايثون:

```py
import aspose.slides as slides
import urllib2
import base64

with slides.Presentation() as pres:
    slide = pres.slides[0]
    imageData = base64.b64encode(urllib2.urlopen("[REPLACE WITH URL]").read())

    image = pres.images.add_image(imageData)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **إضافة الصور إلى مقدمة الشرائح**

مقدمة الشريحة هي الشريحة العلوية التي تخزن وتتحكم في المعلومات (الموضوع، التنسيق، الخ) حول جميع الشرائح تحتها. لذا، عند إضافة صورة إلى مقدمة الشريحة، ستظهر تلك الصورة في كل شريحة تحت تلك المقدمة.

يوضح لك هذا الرمز المصدري في بايثون كيفية إضافة صورة إلى مقدمة الشريحة:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    masterSlide = slide.layout_slide.master_slide
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)
        masterSlide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
        
    pres.save("master_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **إضافة الصور كخلفية للشرائح**

قد تقرر استخدام صورة كخلفية لشريحة معينة أو عدة شرائح. في هذه الحالة، يجب أن ترى *[تعيين الصور كخلفيات للشرائح](https://docs.aspose.com/slides/python-net/presentation-background/#setting-images-as-background-for-slides)*.

## **إضافة SVG إلى العروض التقديمية**
يمكنك إضافة أو إدراج أي صورة إلى عرض تقديمي باستخدام طريقة [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) التي تنتمي إلى واجهة [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).

لإنشاء كائن صورة بناءً على صورة SVG، يمكنك القيام بذلك على النحو التالي:

1. إنشاء كائن SvgImage لإدراجه في ImageShapeCollection
2. إنشاء كائن PPImage من ISvgImage
3. إنشاء كائن PictureFrame باستخدام واجهة IPPImage

يوضح لك هذا الرمز المصدري كيفية تنفيذ الخطوات المذكورة أعلاه لإضافة صورة SVG إلى عرض تقديمي:
```py 
import aspose.slides as slides

# إنشاء عرض تقديمي جديد
with slides.Presentation() as p:
    # قراءة محتوى ملف SVG
    with open("sample.svg","rt") as in_file:
        svgContent = in_file.read()
        # إنشاء كائن SvgImage
        svgImage = slides.SvgImage(svgContent)

        # إنشاء كائن PPImage
        ppImage = p.images.add_image(svgImage)

        # إنشاء إطار صورة جديد
        p.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 200, 100, ppImage.width, ppImage.height, ppImage)

        # حفظ العرض التقديمي في تنسيق PPTX
        p.save("presentation_with-svg.pptx", slides.export.SaveFormat.PPTX)
```

## **تحويل SVG إلى مجموعة من الأشكال**
تحويل Aspose.Slides لـ SVG إلى مجموعة من الأشكال مشابه لوظائف PowerPoint المستخدمة للعمل مع صور SVG:


![القائمة المنبثقة PowerPoint](img_01_01.png)

تتم توفير الوظيفة بواسطة أحد التحميلات الفائضة لطريقة [add_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/addgroupshape/) في واجهة [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) التي تأخذ كائن [ISvgImage](https://reference.aspose.com/slides/python-net/aspose.slides/isvgimage/) كأول معلمة.

يوضح لك هذا الرمز المصدري كيفية استخدام الطريقة الموصوفة لتحويل ملف SVG إلى مجموعة من الأشكال:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # قراءة محتوى ملف SVG
    with open("sample.svg","rt") as in_file:
        svgContent = in_file.read()
        # إنشاء كائن SvgImage
        svgImage = slides.SvgImage(svgContent)

        # الحصول على حجم الشريحة
        slide_size = presentation.slide_size.size

        # تحويل صورة SVG إلى مجموعة من الأشكال مع تعديل حجمها إلى حجم الشريحة
        presentation.slides[0].shapes.add_group_shape(svgImage, 0, 0, slide_size.width, slide_size.height)

        # حفظ العرض التقديمي في تنسيق PPTX
        presentation.save("presentation_with_shape_svg.pptx", slides.export.SaveFormat.PPTX)
```

## **إضافة الصور كـ EMF في الشرائح**
تتيح لك Aspose.Slides لـ بايثون عبر .NET إضافة صورة EMF.

يوضح لك هذا الرمز المصدري كيفية تنفيذ المهمة الموصوفة:

```py 
with slides.Presentation() as pres:
    slide = pres.slides[0]
    with open("image.emf", "rb") as in_file:
        emfImage = pres.images.add_image(in_file)
        slide_size = pres.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emfImage)
    
    pres.save("pres_with_emf.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="معلومات" color="info" %}}

باستخدام محول Aspose المجاني [Text to GIF](https://products.aspose.app/slides/text-to-gif)، يمكنك بسهولة تحريك النصوص، وإنشاء GIFs من النصوص، إلخ.

{{% /alert %}}