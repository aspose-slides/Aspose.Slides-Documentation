---
title: تحويل شرائح العرض إلى صور في بايثون
linktitle: شريحة إلى صورة
type: docs
weight: 41
url: /ar/python-net/convert-slide/
keywords:
- تحويل شريحة
- تصدير شريحة
- شريحة إلى صورة
- حفظ الشريحة كصورة
- شريحة إلى EMF
- شريحة إلى PNG
- شريحة إلى JPEG
- شريحة إلى bitmap
- شريحة إلى TIFF
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تحويل الشرائح من عروض PPT و PPTX و ODP إلى PNG و JPEG و GIF و TIFF و EMF وغيرها من صيغ الصور في بايثون باستخدام Aspose.Slides."
---
## **المقدمة**

يمكن لـ Aspose.Slides for Python via .NET عرض الشرائح الفردية من عروض PowerPoint و OpenDocument كصيغ PNG و JPEG و GIF و TIFF وغيرها من صيغ الصور.

لتحويل شريحة إلى صورة، اتبع الخطوات التالية:

1. حمِّل العرض باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
2. اختر الشريحة التي تريد عرضها.
3. إذا لزم الأمر، اضبط إعدادات العرض باستخدام الفئة [RenderingOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/renderingoptions/) أو الفئة [TiffOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/tiffoptions/) .
4. استدعِ الطريقة [Slide.get_image](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/get_image/) . تُرجِع كائنًا من النوع [IImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iimage/) .
5. استدعِ الطريقة [IImage.save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iimage/save/) وحدد تنسيق الإخراج باستخدام قيمة من النوع [ImageFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imageformat/) .

## **تحويل شريحة إلى صورة PNG**

أبسط طريقة تحويل تستخدم إعدادات العرض الافتراضية. يمكن معالجة كائن [IImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iimage/) الناتج في الذاكرة أو حفظه إلى ملف.

المثال التالي بلغة Python يقوم بعرض الشريحة الأولى ويحفظها كصورة PNG:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **تحويل الشرائح إلى صور بأحجام مخصصة**

استخدم التحميل الزائد للطريقة [Slide.get_image](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) الذي يقبل قيمة [Size](https://reference.aspose.com/slides/ar/python-net/aspose.pydrawing/size/) لعرض الشريحة بأبعاد بكسل دقيقة.

المثال التالي ينشئ صورة JPEG بحجم 1820 × 1040:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(image_size) as image:
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **تحويل الشرائح التي تحتوي على ملاحظات وتعليقات إلى صور**

بشكل افتراضي، لا تتضمن صور الشرائح ملاحظات أو تعليقات. عين كائنًا من النوع [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/notescommentslayoutingoptions/) إلى الخاصية [RenderingOptions.slides_layout_options](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/renderingoptions/slides_layout_options/) للتحكم في موضع ظهور الملاحظات والتعليقات.

المثال التالي يضع ملاحظات مقصوصة أسفل الشريحة وتعليقات على يمينها:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
layout_options.comments_position = slides.export.CommentsPositions.RIGHT
layout_options.comments_area_width = 500
layout_options.comments_area_color = draw.Color.antique_white

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(rendering_options, scale_x, scale_y) as image:
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="تحذير" color="warning" %}}
في تحويل الشرائح إلى صور، لا تقم بتعيين الخاصية [NotesCommentsLayoutingOptions.notes_position](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) إلى القيمة [NotesPositions.BOTTOM_FULL](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/notespositions/). قد تحتوي الملاحظات على نص أكثر مما تستطيع الصورة الثابتة استيعابه. استخدم القيمة [NotesPositions.BOTTOM_TRUNCATED](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/notespositions/) بدلاً من ذلك.
{{% /alert %}}

## **تحويل الشرائح إلى صور باستخدام خيارات TIFF**

تتيح لك الفئة [TiffOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/tiffoptions/) التحكم في الحجم والدقة وغيرها من خصائص صورة TIFF المُصدرة.

المثال التالي يعرض الشريحة الأولى كصورة TIFF بحجم 2160 × 2880 وبدقة 300 DPI:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.image_size = draw.Size(2160, 2880)
tiff_options.dpi_x = 300
tiff_options.dpi_y = 300

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(tiff_options) as image:
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **تحويل جميع الشرائح إلى صور**

قم بالتكرار عبر مجموعة الشرائح لتحويل العرض بالكامل إلى سلسلة من الصور. يتم تضمين الشرائح المخفية ما لم تقم بتجاوزها صراحة.

المثال التالي يعرض كل شريحة كصورة JPEG بعامل قياس أفقي ورأسي مقداره 2:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save("Slide_{}.jpg".format(index), slides.ImageFormat.JPEG)
```

## **إنشاء إخراج Enhanced Metafile**

Enhanced Metafile (EMF) مفيد عندما يجب تبادل الرسومات القائمة على المتجهات مع Microsoft Office أو تطبيقات Windows الأخرى التي تدعم ملفات Windows metafile. على عكس الصورة القائمة على البكسل، يمكن لـ EMF الاحتفاظ بعمليات الرسم المتجهة التي تتوسع دون فقدان الحدة. ومع ذلك، يُعد EMF في الأساس تنسيق توافق للتطبيقات التي تدعم ملفات Windows metafile، وليس تنسيق تبادل عالمي. بالإضافة إلى ذلك، قد يتم تخزين محتوى الشرائح المعقد، مثل الصور النقطية وبعض التأثيرات، كعناصر مُرصّصة داخل حاوية ملف المتجه.

### **تصدير شريحة إلى EMF**

الطريقة [Slide.write_as_emf](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/write_as_emf/) تكتب كائن [Slide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/) إلى تدفق هدف بتنسيق EMF. المثال التالي يحمل عرضًا، يختار الشريحة الأولى، ويكتبها إلى تدفق ملف EMF:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("Slide_0.emf", "wb") as emf_stream:
        slide.write_as_emf(emf_stream)
```

المستدعي يمتلك التدفق الممرر إلى [Slide.write_as_emf](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/write_as_emf/) ويجب إغلاقه. تقوم Aspose.Slides بالكتابة في موضع التدفق الحالي وتترك التدفق مفتوحًا.

### **تحويل صورة SVG إلى EMF وإضافتها إلى عرض**

استخدم [SvgImage.write_as_emf](https://reference.aspose.com/slides/ar/python-net/aspose.slides/svgimage/write_as_emf/) لتحويل محتوى SVG إلى EMF. يمكن إضافة البايتات الناتجة إلى العرض عبر [ImageCollection.add_image](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imagecollection/add_image/) ووضعها على شريحة باستخدام [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/add_picture_frame/).

المثال التالي ينشئ كائن [SvgImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/svgimage/) من ترميز SVG، يحوله إلى EMF في الذاكرة، يُدرج ملف الميتافايل على الشريحة الأولى، ويحفظ العرض:

```py
import io
import aspose.slides as slides

svg_content = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>'
svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with io.BytesIO() as emf_stream:
        svg_image.write_as_emf(emf_stream)
        emf_data = emf_stream.getvalue()

    image = presentation.images.add_image(emf_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 100, image)

    presentation.save("Presentation_with_emf.pptx", slides.export.SaveFormat.PPTX)
```

الطريقة [SvgImage.write_as_emf](https://reference.aspose.com/slides/ar/python-net/aspose.slides/svgimage/write_as_emf/) لا تتولى ملكية التدفق الوجهة. بعد الكتابة، يكون موضع التدفق في نهاية البيانات المُولدة. استدعِ `getvalue` للحصول على الـ buffer الكامل بغض النظر عن موضع التدفق الحالي، كما هو موضح أعلاه. احتفظ بالتدفق مفتوحًا حتى تُقرأ البيانات، ثم أغلقه بعد ذلك.

تتوفر عملية إنشاء EMF على أنظمة التشغيل التي تدعمها Aspose.Slides for Python via .NET، لكن عملية العرض قد تختلف بين المنصات عندما تكون الخطوط أو تبعيات الرسومات الأصلية غير متوفرة. قم بتثبيت الخطوط المستخدمة في المحتوى الأصلي أو اضبط بدائل مناسبة، واتبع [platform requirements](/slides/ar/python-net/system-requirements/) لـ Aspose.Slides، وتحقق من النتيجة في التطبيق المستهدف الذي يستهلك ملفات EMF. غالبًا ما تكون تطبيقات Linux و macOS ذات دعم محدود أو غير متسق لعرض وتحرير ملفات Windows metafile.

## **عرض إيموجي ملونة**

{{% alert title="ملاحظة" color="info" %}}
لعرض الإيموجي الملونة بشكل صحيح عند تحويل شرائح العرض إلى صور، يجب تثبيت خطوط الإيموجي المستخدمة في العرض وتوافرها على النظام الذي يجري التحويل. على سبيل المثال، إذا كان العرض يستخدم **Segoe UI Emoji** وكان هذا الخط غير موجود، قد تظهر الإيموجي بالأبيض والأسود في الصور الناتجة.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل تدعم Aspose.Slides عرض الشرائح مع الرسوم المتحركة؟**

لا. الطريقة [Slide.get_image](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/get_image/) تعرض صورة ثابتة للشريحة ولا تصدر الرسوم المتحركة.

**هل يمكن تصدير الشرائح المخفية كصور؟**

نعم. يمكن عرض الشرائح المخفية مثل الشرائح العادية. أدرجها في حلقة المعالجة، كما هو موضح في المثال أعلاه.

**هل يتم الحفاظ على الظلال وغيرها من التأثيرات في صور الشرائح؟**

نعم. تقوم Aspose.Slides بعرض الظلال والشفافية وغيرها من التأثيرات الرسومية المدعومة في صور الشرائح.