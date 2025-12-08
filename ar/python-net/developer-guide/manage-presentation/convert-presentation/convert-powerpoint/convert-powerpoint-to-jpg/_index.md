---
title: تحويل PPT و PPTX و ODP إلى JPG باستخدام Python
linktitle: تحويل الشرائح إلى صور JPG
type: docs
weight: 60
url: /ar/python-net/convert-powerpoint-to-jpg/
keywords:
- تحويل PowerPoint إلى JPG
- تحويل العرض التقديمي إلى JPG
- تحويل الشريحة إلى JPG
- تحويل PPT إلى JPG
- تحويل PPTX إلى JPG
- تحويل ODP إلى JPG
- PowerPoint إلى JPG
- العرض التقديمي إلى JPG
- الشريحة إلى JPG
- PPT إلى JPG
- PPTX إلى JPG
- ODP إلى JPG
- تحويل PowerPoint إلى JPEG
- تحويل العرض التقديمي إلى JPEG
- تحويل الشريحة إلى JPEG
- تحويل PPT إلى JPEG
- تحويل PPTX إلى JPEG
- تحويل ODP إلى JPEG
- PowerPoint إلى JPEG
- العرض التقديمي إلى JPEG
- الشريحة إلى JPEG
- PPT إلى JPEG
- PPTX إلى JPEG
- ODP إلى JPEG
- Python
- Aspose.Slides
description: "تعرّف على كيفية تحويل شرائحك من عروض PowerPoint وOpenDocument إلى صور JPEG عالية الجودة باستخدام بضعة أسطر فقط من الشيفرة في Python. احسن عروضك التقديمية للاستخدام على الويب ومشاركتها وأرشفتها. اقرأ الدليل الكامل الآن!"
---

## **نظرة عامة**

يساعد تحويل عروض PowerPoint وOpenDocument إلى صور JPG في مشاركة الشرائح، تحسين الأداء، وتضمين المحتوى في المواقع الإلكترونية أو التطبيقات. يتيح Aspose.Slides for Python تحويل ملفات PPTX وPPT وODP إلى صور JPEG عالية الجودة. يشرح هذا الدليل طرق التحويل المختلفة.

مع هذه الميزات، يصبح من السهل تنفيذ عارض عروض تقديمية خاص بك وإنشاء صورة مصغرة لكل شريحة. قد يكون ذلك مفيدًا إذا أردت حماية شرائح العرض من النسخ أو عرضها بوضع القراءة فقط. يتيح Aspose.Slides تحويل العرض الكامل أو شريحة محددة إلى صيغ صور.

## **تحويل شرائح العرض إلى صور JPG**

فيما يلي الخطوات لتحويل ملف PPT أو PPTX أو ODP إلى JPG:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على كائن الشريحة من النوع [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) من مجموعة [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/).
3. إنشاء صورة للشريحة باستخدام الطريقة [Slide.get_image(scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#float-float).
4. استدعاء الطريقة [IImage.save(filename, format)](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/#str-imageformat) على كائن الصورة. تمرير اسم ملف الإخراج وصيغة الصورة كوسائط.

{{% alert color="primary" %}}

**ملاحظة:** يختلف تحويل PPT أو PPTX أو ODP إلى JPG عن التحويل إلى صيغ أخرى في Aspose.Slides Python API. بالنسبة للصيغ الأخرى، عادةً ما تستخدم الطريقة [Presentation.save(fname, format, options)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions). ومع ذلك، لتحويل إلى JPG، يجب عليك استخدام الطريقة [IImage.save(filename, format)](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/#str-imageformat).

{{% /alert %}}
```py
import aspose.slides as slides

scale_x = 1
scale_y = scale_x

with slides.Presentation("PowerPoint_Presentation.ppt") as presentation:
    for slide in presentation.slides:
        with slide.get_image(scale_x, scale_y) as thumbnail:
            # احفظ الصورة على القرص بتنسيق JPEG.
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```


## **تحويل الشرائح إلى JPG بأبعاد مخصصة**

لتغيير أبعاد صور JPG الناتجة، يمكنك تعيين حجم الصورة بتمريره إلى الطريقة [Slide.get_image(image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposepydrawingsize). يتيح لك ذلك إنشاء صور بأبعاد عرض وارتفاع محددة، مما يضمن أن الناتج يلبي متطلباتك من حيث الدقة ونسبة العرض إلى الارتفاع. هذه المرونة مفيدة خصوصًا عند توليد صور لتطبيقات الويب أو التقارير أو الوثائق، حيث تتطلب أبعاد الصورة بدقة.

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

image_size = pydrawing.Size(1200, 800)

with slides.Presentation("PowerPoint_Presentation.pptx") as presentation:
    for slide in presentation.slides:
        # إنشاء صورة شريحة بالحجم المحدد.
        with slide.get_image(image_size) as thumbnail:
            # احفظ الصورة على القرص بتنسيق JPEG.
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```


## **تصيير التعليقات عند حفظ الشرائح كصور**

يوفر Aspose.Slides for Python ميزة تسمح لك بتصيير التعليقات على شرائح العرض عند تحويلها إلى صور JPG. هذه الوظيفة مفيدة بشكل خاص للحفاظ على الملاحظات أو الردود أو المناقشات التي أضافها المتعاونون في عروض PowerPoint. من خلال تفعيل هذا الخيار، تضمن أن التعليقات تكون مرئية في الصور المولدة، مما يسهل مراجعة ومشاركة الملاحظات دون الحاجة لفتح ملف العرض الأصلي.

لنفترض أن لدينا ملف عرض تقديمي "sample.pptx" يحتوي على شريحة بها تعليقات:

![الشريحة مع التعليقات](slide_with_comments.png)

يحول الكود التالي بلغة Python الشريحة إلى صورة JPG مع الحفاظ على التعليقات:

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    # تعيين خيارات تعليقات الشريحة.
    comments_options = slides.export.NotesCommentsLayoutingOptions()
    comments_options.comments_position = slides.export.CommentsPositions.RIGHT
    comments_options.comments_area_width = 200
    comments_options.comments_area_color = pydrawing.Color.dark_orange

    options = slides.export.RenderingOptions()
    options.slides_layout_options = comments_options

    # تحويل الشريحة الأولى إلى صورة.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as thumbnail:
        thumbnail.save("Slide_1.jpg", slides.ImageFormat.JPEG)
```


النتيجة:

![صورة JPG مع التعليقات](image_with_comments.png)

## **انظر أيضًا**

انظر خيارات أخرى لتحويل PPT أو PPTX أو ODP إلى صور، مثل:

- [تحويل PowerPoint إلى GIF](/slides/ar/python-net/convert-powerpoint-to-animated-gif/)
- [تحويل PowerPoint إلى PNG](/slides/ar/python-net/convert-powerpoint-to-png/)
- [تحويل PowerPoint إلى TIFF](/slides/ar/python-net/convert-powerpoint-to-tiff/)
- [تحويل PowerPoint إلى SVG](/slides/ar/python-net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

لرؤية طريقة تحويل Aspose.Slides لـ PowerPoint إلى صور JPG، جرّب هذه المحولات المجانية عبر الإنترنت: PowerPoint [PPTX إلى JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) و [PPT إلى JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

![محول PPTX إلى JPG مجاني على الإنترنت](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

توفر Aspose تطبيق ويب [Collage مجاني](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج صور [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، وإنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، وما إلى ذلك.

باستخدام نفس المبادئ الموضحة في هذه المقالة، يمكنك تحويل الصور من تنسيق إلى آخر. لمزيد من المعلومات، راجع هذه الصفحات: تحويل [image إلى JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); تحويل [JPG إلى image](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/), تحويل [PNG إلى JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/), تحويل [SVG إلى PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **الأسئلة المتكررة**

**هل يدعم هذا الأسلوب التحويل الدفعي؟**

نعم، يتيح Aspose.Slides تحويل دفعي لعدة شرائح إلى JPG في عملية واحدة.

**هل يدعم التحويل SmartArt والرسوم البيانية والكائنات المعقدة الأخرى؟**

نعم، يقوم Aspose.Slides بتصيير جميع المحتويات، بما في ذلك SmartArt والرسوم البيانية والجداول والأشكال، وغيرها. ومع ذلك، قد تختلف دقة التصيير قليلاً مقارنةً بـ PowerPoint، خصوصًا عند استخدام خطوط مخصصة أو مفقودة.

**هل هناك أي قيود على عدد الشرائح التي يمكن معالجتها؟**

لا يفرض Aspose.Slides نفسه أي حدود صارمة على عدد الشرائح التي يمكنك معالجتها. ومع ذلك، قد تواجه خطأ نفاد الذاكرة عند العمل على عروض تقديمية كبيرة أو صور عالية الدقة.