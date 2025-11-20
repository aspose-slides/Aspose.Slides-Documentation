---
title: تحويل شرائح PowerPoint إلى صور في Python
linktitle: الشريحة إلى صورة
type: docs
weight: 41
url: /ar/python-net/convert-slide/
keywords:
- تحويل الشريحة
- تحويل الشريحة إلى صورة
- تصدير الشريحة كصورة
- حفظ الشريحة كصورة
- الشريحة إلى صورة
- الشريحة إلى PNG
- الشريحة إلى JPEG
- الشريحة إلى صورة نقطية
- Python
- Aspose.Slides
description: "تعلم كيفية تحويل شرائح PowerPoint وOpenDocument إلى صيغ مختلفة باستخدام Aspose.Slides for Python عبر .NET. قم بتصدير شرائح PPTX وODP بسهولة إلى BMP وPNG وJPEG وTIFF وغيرها مع نتائج عالية الجودة."
---

## **نظرة عامة**

Aspose.Slides for Python عبر .NET تتيح لك تحويل شرائح العروض التقديمية من PowerPoint وOpenDocument بسهولة إلى تنسيقات صور متعددة، بما في ذلك BMP وPNG وJPG (JPEG) وGIF وغيرها.

لتحويل شريحة إلى صورة، اتبع الخطوات التالية:

1. حدد إعدادات التحويل المطلوبة واختر الشرائح التي تريد تصديرها باستخدام:
    - الفئة [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/) ، أو
    - الفئة [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/)
2. توليد صورة الشريحة عن طريق استدعاء طريقة `get_image` من الفئة [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) .

في Aspose.Slides for Python عبر .NET، الفئة [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) هي فئة تتيح لك التعامل مع الصور المعرفة ببيانات البكسل. يمكنك استخدام نسخة من هذه الفئة لحفظ الصور في مجموعة واسعة من التنسيقات (BMP، JPG، PNG، إلخ).

## **تحويل الشرائح إلى صورة نقطية وحفظ الصور بتنسيق PNG**

يمكنك تحويل شريحة إلى كائن صورة نقطية واستخدامه مباشرةً في تطبيقك. بدلاً من ذلك، يمكنك تحويل شريحة إلى صورة نقطية ثم حفظ الصورة بتنسيق JPEG أو أي تنسيق آخر تفضله.

يظهر هذا الكود بايثون كيفية تحويل الشريحة الأولى في عرض تقديمي إلى كائن صورة نقطية ثم حفظ الصورة بتنسيق PNG:
```py 
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    # تحويل الشريحة الأولى في العرض التقديمي إلى صورة نقطية.
    with presentation.slides[0].get_image() as image:
        # حفظ الصورة بصيغة PNG.
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```


## **تحويل الشرائح إلى صور بأحجام مخصصة**

قد تحتاج إلى الحصول على صورة بحجم معين. باستخدام أحد إصدارات طريقة [get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)، يمكنك تحويل شريحة إلى صورة بأبعاد محددة (العرض والارتفاع).

يظهر هذا الكود المثال كيفية القيام بذلك:
```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    # تحويل الشريحة الأولى في العرض التقديمي إلى صورة نقطية بالحجم المحدد.
    with presentation.slides[0].get_image(image_size) as image:
        # حفظ الصورة بصيغة JPEG.
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```


## **تحويل الشرائح مع الملاحظات والتعليقات إلى صور**

قد تحتوي بعض الشرائح على ملاحظات وتعليقات.

توفر Aspose.Slides فئتين—[TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/) و[RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/)—تتيحان لك التحكم في عرض شرائح العرض التقديمي كصور. تشمل كلا الفئتين الخاصية `slides_layout_options`، التي تمكنك من تكوين عرض الملاحظات والتعليقات على الشريحة عند تحويلها إلى صورة.

باستخدام الفئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) يمكنك تحديد الموضع المفضل للملاحظات والتعليقات في الصورة الناتجة.

يظهر هذا الكود بايثون كيفية تحويل شريحة تحتوي على ملاحظات وتعليقات:
```py 
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    notes_comments_options = slides.export.NotesCommentsLayoutingOptions()
    notes_comments_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED  # تحديد موضع الملاحظات.
    notes_comments_options.comments_position = slides.export.CommentsPositions.RIGHT       # تحديد موضع التعليقات.
    notes_comments_options.comments_area_width = 500                                       # تحديد عرض مساحة التعليقات.
    notes_comments_options.comments_area_color = draw.Color.antique_white                  # تحديد لون مساحة التعليقات.

    # إنشاء خيارات التقديم.
    options = slides.export.RenderingOptions()
    options.slides_layout_options = notes_comments_options

    # تحويل الشريحة الأولى في العرض التقديمي إلى صورة.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as image:
        # حفظ الصورة بتنسيق GIF.
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```


{{% alert title="Note" color="warning" %}} 

في أي عملية تحويل شريحة إلى صورة، لا يمكن ضبط الخاصية [notes_position](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) إلى `BOTTOM_FULL` (لتحديد موضع الملاحظات) لأن نص الملاحظة قد يكون كبيرًا جدًا، مما يجعلها غير قادرة على الاحتواء ضمن حجم الصورة المحدد.

{{% /alert %}} 

## **تحويل الشرائح إلى صور باستخدام خيارات TIFF**

توفر الفئة [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/) سيطرة أكبر على صورة TIFF الناتجة من خلال السماح لك بتحديد معلمات مثل الحجم، الدقة، لوحة الألوان، والمزيد.

يظهر هذا الكود بايثون عملية تحويل يتم فيها استخدام خيارات TIFF لإنتاج صورة بالأبيض والأسود بدقة 300 DPI وحجم 2160 × 2800:
```py 
import aspose.pydrawing as draw
import aspose.slides as slides

# تحميل ملف عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:
    # الحصول على الشريحة الأولى من العرض التقديمي.
    slide = presentation.slides[0]

    # تكوين إعدادات صورة TIFF الناتجة.
    options = slides.export.TiffOptions()
    options.image_size = draw.Size(2160, 2880)                                 # تحديد حجم الصورة.
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT_1BPP_INDEXED  # تحديد تنسيق البكسل (أسود وأبيض).
    options.dpi_x = 300                                                        # تحديد الدقة الأفقية.
    options.dpi_y = 300                                                        # تحديد الدقة العمودية.

    # تحويل الشريحة إلى صورة باستخدام الإعدادات المحددة.
    with slide.get_image(options) as image:
        # حفظ الصورة بتنسيق TIFF.
        image.save("output.tiff", slides.ImageFormat.TIFF)
```


## **تحويل جميع الشرائح إلى صور**

تتيح لك Aspose.Slides تحويل جميع الشرائح في عرض تقديمي إلى صور، مما يحول العرض التقديمي بالكامل إلى سلسلة من الصور.

يظهر هذا الكود المثال كيفية تحويل جميع الشرائح في عرض تقديمي إلى صور باستخدام بايثون:
```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    # تحويل العرض التقديمي إلى صور شريحة بشريحة.
    for i, slide in enumerate(presentation.slides):
        # التحكم في الشرائح المخفية (عدم تحويل الشرائح المخفية).
        if slide.hidden:
            continue

        # تحويل الشريحة إلى صورة.
        with slide.get_image(scale_x, scale_y) as image:
            # حفظ الصورة بصيغة JPEG.
            image.save("Slide_{0}.jpg".format(i), slides.ImageFormat.JPEG)
```


## **الأسئلة الشائعة**

**هل تدعم Aspose.Slides عرض الشرائح مع الرسوم المتحركة؟**

لا، طريقة `get_image` تحفظ صورة ثابتة فقط للشريحة، دون رسوم متحركة.

**هل يمكن تصدير الشرائح المخفية كصور؟**

نعم، يمكن معالجة الشرائح المخفية تمامًا كما العادية. فقط تأكد من تضمينها في حلقة المعالجة.

**هل يمكن حفظ الصور مع الظلال والتأثيرات؟**

نعم، تدعم Aspose.Slides عرض الظلال، والشفافية، وغيرها من التأثيرات الرسومية عند حفظ الشرائح كصور.