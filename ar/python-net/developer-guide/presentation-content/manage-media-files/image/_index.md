---
title: تحسين إدارة الصور في PowerPoint باستخدام Python
linktitle: إدارة الصور
type: docs
weight: 10
url: /ar/python-net/image/
keywords:
- إضافة صورة
- إضافة صورة
- إضافة صورة نقطية
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
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تبسيط إدارة الصور في PowerPoint وOpenDocument باستخدام Aspose.Slides للغة Python عبر .NET، تحسين الأداء وأتمتة سير العمل الخاص بك."
---
## **المقدمة**

تجعل الصور العروض التقديمية أكثر جاذبية وإثارة للاهتمام. في Microsoft PowerPoint، يمكنك إدراج صور من ملف أو من الإنترنت أو من مصادر أخرى على الشرائح. وبالمثل، يتيح لك Aspose.Slides إضافة الصور إلى الشرائح بطرق عدة.

{{% alert  title="نصيحة" color="primary" %}}
Aspose يقدم محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/ar/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/ar/import/png-to-ppt)—تسمح لك بإنشاء عروض تقديمية بسرعة من الصور.
{{% /alert %}}

{{% alert title="معلومات" color="info" %}}
إذا كنت ترغب في إضافة صورة ككائن إطار—خاصة إذا كنت تخطط لاستخدام خيارات تنسيق معيارية مثل تغيير الحجم أو تطبيق التأثيرات—اطلع على [إضافة إطارات الصور إلى العروض التقديمية باستخدام Python] (https://docs.aspose.com/slides/ar/python-net/picture-frame/).
{{% /alert %}}

{{% alert title="ملاحظة" color="warning" %}}
يمكنك استخدام عمليات الإدخال والإخراج للصور والعروض التقديمية لتحويل الصور بين الصيغ. راجع هذه الصفحات: تحويل [الصورة إلى JPG](https://products.aspose.com/slides/ar/python-net/conversion/image-to-jpg/)؛ تحويل [JPG إلى صورة](https://products.aspose.com/slides/ar/python-net/conversion/jpg-to-image/)؛ تحويل [JPG إلى PNG](https://products.aspose.com/slides/ar/python-net/conversion/jpg-to-png/)؛ تحويل [PNG إلى JPG](https://products.aspose.com/slides/ar/python-net/conversion/png-to-jpg/)؛ تحويل [PNG إلى SVG](https://products.aspose.com/slides/ar/python-net/conversion/png-to-svg/)؛ وتحويل [SVG إلى PNG](https://products.aspose.com/slides/ar/python-net/conversion/svg-to-png/).
{{% /alert %}}

يدعم Aspose.Slides العمل مع الصور بصيغ شائعة مثل JPEG وPNG وBMP وGIF وغيرها.

## **إضافة صور مخزَّنة محليًا إلى الشرائح**

يمكنك إضافة صورة واحدة أو أكثر من جهاز الكمبيوتر الخاص بك إلى شريحة في عرض تقديمي. يوضح المثال التالي بلغة Python كيفية إضافة صورة إلى شريحة:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **إضافة صور من الويب إلى الشرائح**

إذا لم تكن الصورة التي تريد إضافتها إلى شريحة متوفرة على جهازك، يمكنك إدراجها مباشرة من الويب.

يوضح المثال التالي بلغة Python كيفية إضافة صورة من عنوان URL إلى شريحة:

```py
import aspose.slides as slides
from urllib.request import urlopen

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # تحميل بايتات الصورة الخام.
    with urlopen("[REPLACE WITH URL]") as response:
        image_data = response.read()

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **إضافة صور إلى أسس الشرائح**

أساس الشريحة هو الشريحة العليا التي تخزن وتتحكم في المعلومات—السمة، التخطيط، وما إلى ذلك—لكل الشرائح التي تحته. عندما تضيف صورة إلى أساس شريحة، تظهر تلك الصورة على كل شريحة تستخدم ذلك الأساس.

يوضح المثال التالي بلغة Python كيفية إضافة صورة إلى أساس شريحة:

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

## **إضافة صور كخلفية للشرائح**

يمكنك استخدام صورة كخلفية لشريحة واحدة أو أكثر. للحصول على تفاصيل، راجع *[تعيين الصور كخلفيات للشرائح](/slides/ar/python-net/presentation-background/#setting-images-as-background-for-slides)*.

## **إضافة SVG إلى العروض التقديمية**

يمكن إضافة محتوى SVG إلى عرض تقديمي باستخدام الفئة [SvgImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/svgimage/). يمكن بعد ذلك إضافة صورة SVG الناتجة إلى مجموعة صور العرض واستخدامها لإنشاء إطار صورة.

يوضح المثال التالي بلغة Python استيراد سلسلة SVG مكتملة ذاتيًا. جميع الصور والأنماط والموارد الأخرى المستخدمة بواسطة هذا الـ SVG مضمنة مباشرة في محتوى الـ SVG.

```py
import aspose.slides as slides

svg_content = """
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>
"""

with slides.Presentation() as presentation:
    svg_image = slides.SvgImage(svg_content)
    image = presentation.images.add_image(svg_image)

    presentation.slides[0].shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE, 20, 20, image.width, image.height, image
    )

    presentation.save("self-contained-svg.pptx", slides.export.SaveFormat.PPTX)
```

## **تحويل SVG إلى مجموعة من الأشكال**

يقوم Aspose.Slides بتحويل ملفات SVG إلى مجموعة من الأشكال بطريقة مشابهة لمعالجة SVG في PowerPoint.

![قائمة منبثقة في PowerPoint](img_01_01.png)

توفر هذه الوظيفة من خلال تحميل زائد لطريقة [add_group_shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/add_group_shape/) في الفئة [ShapeCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/) التي تستقبل كوسيط أول كائنًا من نوع [SvgImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/svgimage/).

يعرض الكود النموذجي أدناه كيفية تحويل ملف SVG إلى مجموعة من الأشكال.

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # قراءة محتوى ملف SVG.
    with open("sample.svg","rt") as image_stream:
        svg_content = image_stream.read()
        # إنشاء كائن SvgImage.
        svg_image = slides.SvgImage(svg_content)

        # الحصول على حجم الشريحة.
        slide_size = presentation.slide_size.size

        # تحويل صورة SVG إلى مجموعة من الأشكال وتوسيعها لتتناسب مع حجم الشريحة.
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # حفظ العرض التقديمي بصيغة PPTX.
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **إضافة صور بصيغة EMF إلى الشرائح**

يسمح Aspose.Slides للغة Python بإدراج صور Enhanced Metafile (EMF) في العروض التقديمية.

يوضح المثال التالي بلغة Python ذلك:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```

## **استبدال الصور في مجموعة الصور**

يتيح Aspose.Slides لك استبدال الصور المخزنة في مجموعة صور العرض التقديمي، بما في ذلك تلك المستخدمة في أشكال الشرائح. يوضح هذا القسم عدة أساليب لتحديث الصور في المجموعة. توفر API طرقًا بسيطة لاستبدال صورة ببيانات بايت أولية، أو كائن [IImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iimage/)، أو صورة أخرى موجودة بالفعل في المجموعة.

اتباع الخطوات التالية:

1. قم بتحميل العرض التقديمي الذي يحتوي على الصور باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. قم بتحميل صورة جديدة من ملف إلى مصفوفة بايت.
3. استبدل الصورة المستهدفة بالصورة الجديدة باستخدام مصفوفة البايت.
4. بدلاً من ذلك، حمّل الصورة إلى كائن [IImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iimage/) واستبدل الصورة المستهدفة بهذا الكائن.
5. أو استبدل الصورة المستهدفة بصورة موجودة مسبقًا في مجموعة صور العرض.
6. احفظ العرض التقديمي المعدل كملف PPTX.

```py
import aspose.slides as slides

def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
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
مع محول Aspose المجاني [نص إلى GIF](https://products.aspose.app/slides/ar/text-to-gif) يمكنك بسهولة تحريك النص وإنشاء ملفات GIF من النص.
{{% /alert %}}

## **الأسئلة الشائعة**

**هل تظل دقة الصورة الأصلية محفوظة بعد الإدراج؟**

نعم. يتم الحفاظ على بكسلات المصدر، لكن المظهر النهائي يعتمد على كيفية مقاس [الصورة](/slides/ar/python-net/picture-frame/) على الشريحة وأي ضغط يُطبق عند الحفظ.

**ما هي أفضل طريقة لاستبدال الشعار نفسه عبر العشرات من الشرائح دفعة واحدة؟**

ضع الشعار على الشريحة الأساس أو التخطيط واستبدله في مجموعة صور العرض—ستنتقل التحديثات إلى جميع العناصر التي تستخدم هذا المورد.

**هل يمكن تحويل SVG المدخل إلى أشكال قابلة للتحرير؟**

نعم. يمكنك تحويل SVG إلى مجموعة من الأشكال، وبعد ذلك تصبح الأجزاء الفردية قابلة للتحرير باستخدام خصائص الشكل القياسية.

**كيف يمكنني تعيين صورة كخلفية لعدة شرائح في نفس الوقت؟**

[عيّن الصورة كخلفية](/slides/ar/python-net/presentation-background/) على الشريحة الأساس أو التخطيط المناسب—ستورث جميع الشرائح التي تستخدم ذلك الأساس/التخطيط الخلفية.

**كيف أمنع أن يصبح العرض التقديمي كبيرًا جدًا بسبب كثرة الصور؟**

أعد استخدام مورد صورة واحد بدلًا من التكرار، اختَر دقة معقولة، طبّق الضغط عند الحفظ، واحتفظ بالرسومات المتكررة على الأساس حيثما كان ذلك مناسبًا.