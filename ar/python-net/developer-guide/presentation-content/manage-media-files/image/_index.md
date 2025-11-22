---
title: تحسين إدارة الصور في PowerPoint باستخدام Python
linktitle: إدارة الصور
type: docs
weight: 10
url: /ar/python-net/image/
keywords:
- إضافة صورة
- إضافة صورة
- إضافة بت ماب
- استبدال صورة
- استبدال صورة
- من الويب
- خلفية
- إضافة PNG
- إضافة JPG
- إضافة SVG
- إضافة EMF
- إضافة WMF
- إضافة TIFF
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تبسيط إدارة الصور في PowerPoint وOpenDocument باستخدام Aspose.Slides لبايثون عبر .NET، مع تحسين الأداء وأتمتة سير العمل الخاص بك."
---

## **نظرة عامة**

تجعل الصور العروض التقديمية أكثر جاذبية وإثارة للاهتمام. في Microsoft PowerPoint، يمكنك إدراج صور من ملف أو من الإنترنت أو من مصادر أخرى إلى الشرائح. وبالمثل، يتيح لك Aspose.Slides إضافة الصور إلى الشرائح بطرق متعددة.

{{% alert  title="نصيحة" color="primary" %}}
توفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تتيح لك إنشاء عروض تقديمية بسرعة من الصور.
{{% /alert %}}

{{% alert title="معلومات" color="info" %}}
إذا كنت ترغب في إضافة صورة ككائن إطار—خاصة إذا كنت تخطط لاستخدام خيارات تنسيق قياسية مثل تغيير الحجم أو تطبيق التأثيرات—انظر إلى [إضافة إطارات صور إلى العروض التقديمية باستخدام Python](https://docs.aspose.com/slides/python-net/picture-frame/).
{{% /alert %}}

{{% alert title="ملاحظة" color="warning" %}}
يمكنك استخدام عمليات الإدخال والإخراج للصور والعروض التقديمية لتحويل الصور بين الصيغ. راجع هذه الصفحات: تحويل [صورة إلى JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/); تحويل [PNG إلى JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/); وتحويل [SVG إلى PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).
{{% /alert %}}

يدعم Aspose.Slides العمل مع الصور في الصيغ الشائعة مثل JPEG وPNG وBMP وGIF وغير ذلك.

## **إضافة الصور المخزنة محليًا إلى الشرائح**

يمكنك إضافة صورة أو أكثر من جهاز الكمبيوتر الخاص بك إلى شريحة في عرض تقديمي. يوضح المثال التالي بلغة Python كيفية إضافة صورة إلى شريحة:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```


## **إضافة الصور من الويب إلى الشرائح**

إذا كانت الصورة التي تريد إضافتها إلى شريحة غير متوفرة على جهازك، يمكنك إدراجها مباشرةً من الويب.

يعرض المثال التالي بلغة Python كيفية إضافة صورة من URL إلى شريحة:
```py
import aspose.slides as slides
import urllib2
import base64

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image_data = base64.b64encode(urllib2.urlopen("[REPLACE WITH URL]").read())

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **إضافة الصور إلى ماستر الشرائح**

ماستر الشريحة هو الشريحة العليا التي تخزن وتتحكم في المعلومات—المظهر، التخطيط، وما إلى ذلك—لجميع الشرائح تحته. عندما تضيف صورة إلى ماستر الشريحة، تظهر تلك الصورة في كل شريحة تستخدم ذلك الماستر.

يعرض المثال التالي بلغة Python كيفية إضافة صورة إلى ماستر الشريحة:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    master_slide = slide.layout_slide.master_slide

    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        master_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("master_with_image.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين صورة كخلفية للشريحة**

قد ترغب في استخدام صورة كخلفية لشريحة معينة أو لعدة شرائح. للتفاصيل، انظر إلى [تعيين صورة كخلفية للشرائح](https://docs.aspose.com/slides/python-net/presentation-background/#set-image-as-background-for-slide).

## **إضافة SVG إلى العروض التقديمية**

يمكنك إدراج أي صورة في عرض تقديمي باستخدام طريقة [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) من الفئة [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).

لإنشاء كائن صورة من SVG، اتبع الخطوات التالية:

1. إنشاء كائن [SvgImage](https://reference.aspose.com/slides/python-net/aspose.slides/svgimage/) وإضافته إلى مجموعة صور العرض.  
2. إنشاء كائن [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) من [SvgImage](https://reference.aspose.com/slides/python-net/aspose.slides/svgimage/).  
3. إنشاء كائن [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) باستخدام [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/).

يعرض المثال التالي بلغة Python كيفية إضافة صورة SVG إلى عرض تقديمي باستخدام هذه الخطوات:
```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # اقرأ محتوى ملف SVG.
    with open("sample.svg", "rt") as image_stream:
        svg_content = image_stream.read()
        # أنشئ كائن SvgImage.
        svg_image = slides.SvgImage(svg_content)

        # أنشئ كائن PPImage.
        pp_image = presentation.images.add_image(svg_image)

        # أنشئ PictureFrame جديد.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 200, 100, pp_image.width, pp_image.height, pp_image)

        # احفظ العرض التقديمي بتنسيق PPTX.
        presentation.save("presentation_with_SVG.pptx", slides.export.SaveFormat.PPTX)
```


## **تحويل SVG إلى مجموعة من الأشكال**

يقوم Aspose.Slides بتحويل ملفات SVG إلى مجموعة من الأشكال بطريقة مشابهة لمعالجة SVG في PowerPoint.

![قائمة منبثقة في PowerPoint](img_01_01.png)

توفر هذه الوظيفة عبر نسخة مُحمّلة من طريقة [add_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_group_shape/) في الفئة [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) التي تقبل كمعامل أول كائن [SvgImage](https://reference.aspose.com/slides/python-net/aspose.slides/svgimage/).

يعرض رمز العينة أدناه كيفية تحويل ملف SVG إلى مجموعة من الأشكال.
```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # اقرأ محتوى ملف SVG.
    with open("sample.svg","rt") as image_stream:
        svg_content = image_stream.read()
        # أنشئ كائن SvgImage.
        svg_image = slides.SvgImage(svg_content)

        # احصل على حجم الشريحة.
        slide_size = presentation.slide_size.size

        # حوّل صورة SVG إلى مجموعة من الأشكال وقم بتعديل الحجم ليتناسب مع حجم الشريحة.
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # احفظ العرض التقديمي بتنسيق PPTX.
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```


## **إضافة الصور كـ EMF في الشرائح**

يتيح Aspose.Slides for Python إدراج صور Enhanced Metafile (EMF) في العروض التقديمية.

يعرض المثال التالي بلغة Python ذلك:
```py 
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMM.pptx", slides.export.SaveFormat.PPTX)
```


## **استبدال الصور في مجموعة الصور**

يتيح Aspose.Slides لك استبدال الصور المخزنة في مجموعة صور العرض التقديمي، بما في ذلك تلك المستخدمة في أشكال الشرائح. يوضح هذا القسم عدة طرق لتحديث الصور في المجموعة. توفر API طرقًا بسيطة لاستبدال صورة ببيانات بايت خام، أو كائن [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/)، أو صورة أخرى موجودة بالفعل في المجموعة.

اتبع الخطوات التالية:

1. حمِّل العرض التقديمي الذي يحتوي على الصور باستخدام الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. حمِّل صورة جديدة من ملف إلى مصفوفة بايت.  
3. استبدل الصورة المستهدفة بالصورة الجديدة باستخدام مصفوفة البايت.  
4. بدلاً من ذلك، حمِّل الصورة إلى كائن [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) واستبدل الصورة المستهدفة بذلك الكائن.  
5. أو استبدل الصورة المستهدفة بصورة موجودة بالفعل في مجموعة صور العرض.  
6. احفظ العرض التقديمي المعدل كملف PPTX.

```py
def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# إنشاء كائن الفئة Presentation الذي يمثل ملف عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:

    # الطريقة الأولى.
    image_data = read_all_bytes("image0.jpeg")
    old_image = presentation.images[0]
    old_image.replace_image(image_data)

    # الطريقة الثانية.
    new_image = slides.Images.from_file("image1.jpeg")
    old_image = presentation.images[1]
    old_image.replace_image(new_image)

    # الطريقة الثالثة.
    old_image = presentation.images[2]
    old_image.replace_image(presentation.images[3])

    # حفظ العرض التقديمي إلى ملف.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="معلومات" color="info" %}}
مع محول Aspose المجاني [Text to GIF](https://products.aspose.app/slides/text-to-gif)، يمكنك بسهولة تحريك النص وإنشاء ملفات GIF من النص.
{{% /alert %}}

## **الأسئلة الشائعة**

**هل تبقى دقة الصورة الأصلية محفوظة بعد الإدراج؟**

نعم. يتم الحفاظ على بكسلات المصدر، لكن المظهر النهائي يعتمد على كيفية تحجيم [الصورة](/slides/ar/python-net/picture-frame/) في الشريحة وأي ضغط يُطبق عند الحفظ.

**ما هي أفضل طريقة لاستبدال الشعار نفسه عبر العشرات من الشرائح دفعة واحدة؟**

ضع الشعار على ماستر الشريحة أو على تخطيط واستبدله في مجموعة صور العرض التقديمي—ستنتقل التحديثات إلى جميع العناصر التي تستخدم هذا المورد.

**هل يمكن تحويل SVG المُدرج إلى أشكال قابلة للتحرير؟**

نعم. يمكنك تحويل SVG إلى مجموعة من الأشكال، ثم تصبح الأجزاء الفردية قابلة للتحرير باستخدام خصائص الشكل القياسية.

**كيف يمكنني تعيين صورة كخلفية لعدة شرائح في آن واحد؟**

[عيّن الصورة كخلفية](/slides/ar/python-net/presentation-background/) على ماستر الشريحة أو على التخطيط ذي الصلة—سيتوارث أي شريحة تستخدم ذلك الماستر/التخطيط الخلفية.

**كيف يمكنني منع تضخم حجم العرض التقديمي بسبب الكثير من الصور؟**

أعد استعمال مورد صورة واحد بدلاً من النسخ المتعددة، اختر دقات معقولة، طبّق ضغطًا عند الحفظ، واحفظ الرسومات المتكررة على الماستر حيثما كان ذلك مناسبًا.