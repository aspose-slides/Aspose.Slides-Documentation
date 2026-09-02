---
title: تحويل شرائح PowerPoint إلى صور في Python
linktitle: شريحة إلى صورة
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
- الشريحة إلى bitmap
- Python
- Aspose.Slides
description: "تعلم كيفية تحويل شرائح PowerPoint وOpenDocument إلى صيغ متعددة باستخدام Aspose.Slides for Python عبر .NET. قم بتصدير شرائح PPTX وODP بسهولة إلى BMP وPNG وJPEG وTIFF وغيرها مع نتائج عالية الجودة."
---
## **المقدمة**

Aspose.Slides for Python عبر .NET يوفّر لك طريقة سهلة لتحويل شرائح PowerPoint وOpenDocument إلى صيغ صور مختلفة، بما في ذلك BMP وPNG وJPG (JPEG) وGIF وغيرها.

لتحويل شريحة إلى صورة، اتبع الخطوات التالية:

1. حدد إعدادات التحويل المطلوبة واختر الشرائح التي تريد تصديرها باستخدام:
    - فئة [TiffOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/tiffoptions/) ، أو
    - فئة [RenderingOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/renderingoptions/) .
2. أنشئ صورة الشريحة عن طريق استدعاء طريقة `get_image` من الفئة [Slide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/) .

في Aspose.Slides for Python عبر .NET، تُعد فئة [IImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iimage/) فئة تسمح لك بالعمل مع الصور المعرّفة ببيانات البكسل. يمكنك استخدام كائن من هذه الفئة لحفظ الصور بمجموعة واسعة من الصيغ (BMP ،JPG ،PNG ،إلخ).

## **تحويل الشرائح إلى Bitmap وحفظ الصور بصيغة PNG**

يمكنك تحويل شريحة إلى كائن bitmap واستخدامه مباشرة في تطبيقك. أو يمكنك تحويل الشريحة إلى bitmap ثم حفظ الصورة بصيغة JPEG أو أي صيغة أخرى تفضّلها.

يوضح هذا الكود بلغة Python كيفية تحويل الشريحة الأولى في العرض التقديمي إلى كائن bitmap ثم حفظ الصورة بصيغة PNG:

```py 
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    # تحويل الشريحة الأولى في العرض التقديمي إلى bitmap.
    with presentation.slides[0].get_image() as image:
        # احفظ الصورة بصيغة PNG.
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **تحويل الشرائح إلى صور بأحجام مخصصة**

قد تحتاج إلى الحصول على صورة بحجم معين. باستخدام أحد أشكال overload من طريقة [get_image](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) ، يمكنك تحويل شريحة إلى صورة بأبعاد محددة (العرض والارتفاع).

يوضح هذا المثال كيفية القيام بذلك:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    # تحويل الشريحة الأولى في العرض التقديمي إلى bitmap بالحجم المحدد.
    with presentation.slides[0].get_image(image_size) as image:
        # احفظ الصورة بصيغة JPEG.
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **تحويل الشرائح مع الملاحظات والتعليقات إلى صور**

بعض الشرائح قد تحتوي على ملاحظات وتعليقات.

توفر Aspose.Slides فئتين — [TiffOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/tiffoptions/) و[RenderingOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/renderingoptions/) — تسمحان لك بالتحكم في عملية تحويل شرائح العرض إلى صور. كلا الفئتين تتضمنان الخاصية `slides_layout_options` التي تتيح لك تكوين طريقة عرض الملاحظات والتعليقات على الشريحة عند تحويلها إلى صورة.

باستخدام الفئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/notescommentslayoutingoptions/) ، يمكنك تحديد الموقع المفضّل للملاحظات والتعليقات في الصورة الناتجة.

يوضح هذا الكود بلغة Python كيفية تحويل شريحة تحتوي على ملاحظات وتعليقات:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    notes_comments_options = slides.export.NotesCommentsLayoutingOptions()
    notes_comments_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED  # تعيين موضع الملاحظات.
    notes_comments_options.comments_position = slides.export.CommentsPositions.RIGHT       # تعيين موضع التعليقات.
    notes_comments_options.comments_area_width = 500                                       # تعيين عرض مساحة التعليقات.
    notes_comments_options.comments_area_color = draw.Color.antique_white                  # تعيين لون مساحة التعليقات.

    # إنشاء خيارات التصيير.
    options = slides.export.RenderingOptions()
    options.slides_layout_options = notes_comments_options

    # تحويل الشريحة الأولى في العرض التقديمي إلى صورة.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as image:
        # حفظ الصورة بصيغة GIF.
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Note" color="warning" %}} 

في أي عملية تحويل شريحة إلى صورة، لا يمكن تعيين الخاصية [notes_position](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) إلى القيمة `BOTTOM_FULL` (لتحديد موقع الملاحظات) لأن نص الملاحظة قد يكون كبيرًا جدًا ولا يمكن أن يتناسب مع حجم الصورة المحدد.

{{% /alert %}} 

## **تحويل الشرائح إلى صور باستخدام خيارات TIFF**

توفر فئة [TiffOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/tiffoptions/) سيطرة أكبر على الصورة TIFF الناتجة من خلال السماح لك بتحديد معلمات مثل الحجم، الدقة، لوحة الألوان، والمزيد.

يوضح هذا الكود بلغة Python عملية التحويل حيث تُستخدم خيارات TIFF لإنتاج صورة أبيض‑أسود بدقة 300 DPI وحجم 2160 × 2800:

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
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT_1BPP_INDEXED  # تحديد صيغة البكسل (أبيض وأسود).
    options.dpi_x = 300                                                        # تحديد الدقة الأفقية.
    options.dpi_y = 300                                                        # تحديد الدقة العمودية.

    # تحويل الشريحة إلى صورة باستخدام الخيارات المحددة.
    with slide.get_image(options) as image:
        # حفظ الصورة بصيغة TIFF.
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **تحويل جميع الشرائح إلى صور**

تتيح لك Aspose.Slides تحويل جميع الشرائح في عرض تقديمي إلى صور، مما يُحوّل العرض بأكمله إلى سلسلة من الصور.

يوضح هذا المثال كيفية تحويل جميع الشرائح في عرض تقديمي إلى صور باستخدام Python:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    # عرض التقديم إلى صور شريحة بشريحة.
    for i, slide in enumerate(presentation.slides):
        # التحكم في الشرائح المخفية (لا يتم عرض الشرائح المخفية).
        if slide.hidden:
            continue

        # تحويل الشريحة إلى صورة.
        with slide.get_image(scale_x, scale_y) as image:
            # حفظ الصورة بصيغة JPEG.
            image.save("Slide_{0}.jpg".format(i), slides.ImageFormat.JPEG)
```

## **عرض رموز الإيموجي الملونة**

{{% alert title="Note" color="warning" %}} 
لتصrender إيموجي ملونة بشكل صحيح عند تحويل شرائح العرض إلى صور، يجب أن تكون خطوط الإيموجي المستخدمة في العرض مثبتة ومتاحة على النظام الذي ينفّذ عملية التحويل. على سبيل المثال، إذا كان العرض يستخدم **Segoe UI Emoji** وكانت هذه الخط غير موجودة، قد تظهر الإيموجي بالأبيض والأسود في الصور الناتجة.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل تدعم Aspose.Slides عرض الشرائح مع الرسوم المتحركة؟**

لا، طريقة `get_image` تحفظ صورة ثابتة فقط للشفرة، دون الرسوم المتحركة.

**هل يمكن تصدير الشرائح المخفيّة كصور؟**

نعم، يمكن معالجة الشرائح المخفيّة تمامًا كما يتم معالجة العادية. فقط تأكّد من أنّها مدرجة في حلقة المعالجة.

**هل يمكن حفظ الصور مع الظلال والتأثيرات؟**

نعم، تدعم Aspose.Slides عرض الظلال والشفافية وغيرها من تأثيرات الرسومات عند حفظ الشرائح كصور.