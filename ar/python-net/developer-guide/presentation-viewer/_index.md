---
title: عارض العروض التقديمية
type: docs
weight: 50
url: /python-net/presentation-viewer/
keywords: "عرض عرض PowerPoint، عرض ppt، عرض PPTX، بايثون، Aspose.Slides لـ Python عبر .NET"
description: "عرض عرض PowerPoint في بايثون"
---



تُستخدم Aspose.Slides لـ Python عبر .NET لإنشاء ملفات العروض التقديمية، كاملةً مع الشرائح. يمكن عرض هذه الشرائح عن طريق فتح العروض باستخدام Microsoft PowerPoint. ولكن في بعض الأحيان، قد يحتاج المطورون أيضًا إلى عرض الشرائح كصور في عارض الصور المفضل لديهم أو إنشاء عارض عروض تقديمية خاص بهم. في مثل هذه الحالات، تتيح لك Aspose.Slides لـ Python عبر .NET تصدير شريحة فردية إلى صورة. يصف هذا المقال كيفية القيام بذلك.
## **مثال حي**
يمكنك تجربة التطبيق المجاني [**عارض Aspose.Slides**](https://products.aspose.app/slides/viewer/) لرؤية ما يمكنك تنفيذه باستخدام واجهة برمجة التطبيقات Aspose.Slides:

![powerpoint-in-aspose-viewer](powerpoint-in-aspose-viewer.png)

## **إنشاء صورة SVG من شريحة**
لإنشاء صورة SVG من أي شريحة مرغوبة باستخدام Aspose.Slides لـ Python، يرجى اتباع الخطوات أدناه:

- إنشاء نسخة من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
- الحصول على مرجع الشريحة المطلوبة باستخدام معرفها أو فهرسها.
- الحصول على صورة SVG في دفق ذاكرة.
- حفظ دفق الذاكرة إلى ملف.

```py
import aspose.slides as slides

# إنشاء مثيل لفئة Presentation التي تمثل ملف العرض التقديمي
with slides.Presentation(path + "CreateSlidesSVGImage.pptx") as pres:
    # الوصول إلى الشريحة الأولى
    sld = pres.slides[0]

    # إنشاء كائن دفق ذاكرة
    with open("Aspose_out-1.svg", "wb") as svg_stream:
        # إنشاء صورة SVG من الشريحة وحفظها في دفق الذاكرة
        sld.write_as_svg(svg_stream)
```


## **إنشاء SVG مع معرفات شكل مخصصة**
يمكن استخدام Aspose.Slides لـ Python عبر .NET لإنشاء [SVG ](https://docs.fileformat.com/page-description-language/svg/)من الشريحة مع معرف شكل مخصص. للقيام بذلك، استخدم خاصية ID من [ISvgShape](https://reference.aspose.com/slides/python-net/aspose.slides.export/isvgshape/)، والتي تمثّل معرف الشكل المخصص في SVG الناتج. يمكن استخدام CustomSvgShapeFormattingController لتعيين معرف الشكل.

```py
import aspose.slides as slides

with slides.Presentation(path + "CreateSlidesSVGImage.pptx") as pres:
    with open("Aspose_out-2.svg", "wb") as svg_stream:
        svgOptions = slides.export.SVGOptions()
        pres.slides[0].write_as_svg(svg_stream, svgOptions)
```


## **إنشاء صورة مصغرة للشرائح**
تساعدك Aspose.Slides لـ Python عبر .NET في إنشاء صور مصغرة للشرائح. لإنشاء الصورة المصغرة لأي شريحة مرغوبة باستخدام Aspose.Slides لـ Python عبر .NET:

1. إنشاء نسخة من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. الحصول على مرجع لأي شريحة مرغوبة باستخدام معرفها أو فهرسها.
1. الحصول على صورة مصغرة للشريحة المرجعية بمقياس محدد.
1. حفظ الصورة المصغرة بأي تنسيق صورة مرغوب.

```py
import aspose.slides as slides

# إنشاء مثيل لفئة Presentation التي تمثل ملف العرض التقديمي
with slides.Presentation("pres.pptx") as pres:
    # الوصول إلى الشريحة الأولى
    sld = pres.slides[0]

    # إنشاء صورة بدقة كاملة
    with sld.get_image(1, 1) as bmp:
        # حفظ الصورة على القرص بتنسيق JPEG
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```


## **إنشاء صورة مصغرة بأبعاد محددة من قبل المستخدم**
1. إنشاء نسخة من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. الحصول على مرجع لأي شريحة مرغوبة باستخدام معرفها أو فهرسها.
1. الحصول على صورة مصغرة للشريحة المرجعية بمقياس محدد.
1. حفظ الصورة المصغرة بأي تنسيق صورة مرغوب.

```py
import aspose.slides as slides

# إنشاء مثيل لفئة Presentation التي تمثل ملف العرض التقديمي
with slides.Presentation("pres.pptx") as pres:
    # الوصول إلى الشريحة الأولى
    sld = pres.slides[0]

    # الأبعاد المحددة من قبل المستخدم
    desiredX = 1200
    desiredY = 800

    # الحصول على القيمة المقاسة لـ X و Y
    ScaleX = (1.0 / pres.slide_size.size.width) * desiredX
    ScaleY = (1.0 / pres.slide_size.size.height) * desiredY


    # إنشاء صورة بدقة كاملة
    with sld.get_image(ScaleX, ScaleY) as bmp:
        # حفظ الصورة على القرص بتنسيق JPEG
        bmp.save("Thumbnail2_out.jpg", slides.ImageFormat.JPEG)
```


## **إنشاء صورة مصغرة من شريحة في عرض ملاحظات الشرائح**
لإنشاء الصورة المصغرة لأي شريحة مرغوبة في عرض ملاحظات الشرائح باستخدام Aspose.Slides لـ Python عبر .NET:

1. إنشاء نسخة من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. الحصول على مرجع لأي شريحة مرغوبة باستخدام معرفها أو فهرسها.
1. الحصول على صورة مصغرة للشريحة المرجعية بمقياس محدد في عرض ملاحظات الشرائح.
1. حفظ الصورة المصغرة بأي تنسيق صورة مرغوب.

يؤدي مقتطف الشيفرة أدناه إلى إنتاج صورة مصغرة من الشريحة الأولى لعرض تقديمي في عرض ملاحظات الشرائح.

```py
import aspose.slides as slides

# إنشاء مثيل لفئة Presentation التي تمثل ملف العرض التقديمي
with slides.Presentation("pres.pptx") as pres:
    # الوصول إلى الشريحة الأولى
    sld = pres.slides[0]

    # الأبعاد المحددة من قبل المستخدم
    desiredX = 1200
    desiredY = 800

    # الحصول على القيمة المقاسة لـ X و Y
    ScaleX = (1.0 / pres.slide_size.size.width) * desiredX
    ScaleY = (1.0 / pres.slide_size.size.height) * desiredY

   
    # إنشاء صورة بدقة كاملة                
    with sld.get_image(ScaleX, ScaleY) as bmp:
        # حفظ الصورة على القرص بتنسيق JPEG
        bmp.save("Notes_tnail_out.jpg", slides.ImageFormat.JPEG)
```