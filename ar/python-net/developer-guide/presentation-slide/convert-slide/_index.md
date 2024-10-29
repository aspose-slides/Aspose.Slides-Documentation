---
title: تحويل الشريحة
type: docs
weight: 41
url: /ar/python-net/convert-slide/
keywords: 
- تحويل الشريحة إلى صورة
- تصدير الشريحة كصورة
- حفظ الشريحة كصورة
- الشريحة إلى صورة
- الشريحة إلى PNG
- الشريحة إلى JPEG
- الشريحة إلى بت ماب
- PHP
- Aspose.Slides لبايثون عبر .NET
description: "تحويل شريحة PowerPoint إلى صورة (بت ماب، PNG، أو JPG) باستخدام بايثون"
---

Aspose.Slides لبايثون عبر .NET يتيح لك تحويل الشرائح (في العروض التقديمية) إلى صور. وهذه هي تنسيقات الصور المدعومة: BMP، PNG، JPG (JPEG)، GIF، وغيرها.

لتحويل شريحة إلى صورة، قم بما يلي:

1. أولاً، قم بتعيين معلمات التحويل وكائنات الشرائح لتحويلها باستخدام:
   * واجهة [ITiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/itiffoptions/) أو
   * واجهة [IRenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/irenderingoptions/). 

2. ثانياً، قم بتحويل الشريحة إلى صورة باستخدام طريقة [get_image](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).

## **حول بت ماب وتنسيقات الصور الأخرى**

في .NET، [بت ماب](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) هو كائن يتيح لك العمل مع الصور المحددة بواسطة بيانات البكسل. يمكنك استخدام مثيل من هذه الفئة لحفظ الصور في مجموعة واسعة من التنسيقات (BMP، JPG، PNG، إلخ).

{{% alert title="معلومات" color="info" %}}

قامت Aspose مؤخرًا بتطوير محول عبر الإنترنت [Text to GIF](https://products.aspose.app/slides/text-to-gif).

{{% /alert %}}

## **تحويل الشرائح إلى بت ماب وحفظ الصور في PNG**

هذا الكود بلغة بايثون يوضح لك كيفية تحويل الشريحة الأولى من عرض تقديمي إلى كائن بت ماب ثم كيفية حفظ الصورة في تنسيق PNG:

```py 
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    # تحويل الشريحة الأولى في العرض التقديمي إلى كائن بت ماب
    with pres.slides[0].get_image() as bmp:
        # حفظ الصورة في تنسيق PNG
        bmp.save("Slide_0.png", slides.ImageFormat.PNG)
```

{{% alert title="نصيحة" color="primary" %}} 

يمكنك تحويل الشريحة إلى كائن بت ماب ثم استخدام الكائن مباشرة في مكان ما. أو يمكنك تحويل الشريحة إلى بت ماب ثم حفظ الصورة في JPEG أو أي تنسيق آخر تفضله.

{{% /alert %}}  

## **تحويل الشرائح إلى صور بأحجام مخصصة**

قد تحتاج إلى الحصول على صورة بحجم معين. باستخدام overload من [get_image](https://reference.aspose.com/slides/python-net/aspose.slides/islide/)، يمكنك تحويل شريحة إلى صورة بأبعاد محددة (طول وعرض).

هذا الكود النموذجي يوضح عملية التحويل المقترحة باستخدام طريقة [get_image](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) في بايثون:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    # تحويل الشريحة الأولى في العرض التقديمي إلى بت ماب بالحجم المحدد
    with pres.slides[0].get_image(draw.Size(1820, 1040)) as bmp:
        # حفظ الصورة في تنسيق JPEG
        bmp.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **تحويل الشرائح مع الملاحظات والتعليقات إلى صور**

بعض الشرائح تحتوي على ملاحظات وتعليقات.

توفر Aspose.Slides واجهتين—[ITiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/itiffoptions/) و[IRenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/irenderingoptions/)—التي تتيح لك التحكم في عرض الشرائح التقديمية كصور. تحتوي كلا الواجهتين على واجهة [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/) التي تتيح لك إضافة ملاحظات وتعليقات على الشريحة عند تحويل تلك الشريحة إلى صورة.

{{% alert title="معلومات" color="info" %}} 

باستخدام واجهة [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/)، يمكنك تحديد موقع تفضيلي للملاحظات والتعليقات في الصورة الناتجة. 

{{% /alert %}} 

هذا الكود بلغة بايثون يوضح عملية التحويل لشريحة تحتوي على ملاحظات وتعليقات:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("AddNotesSlideWithNotesStyle_out.pptx") as pres:
    # إنشاء خيارات العرض
    options = slides.export.RenderingOptions()
                
    # تعيين موقع الملاحظات على الصفحة
    options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
                
    # تعيين موقع التعليقات على الصفحة 
    options.notes_comments_layouting.comments_position = slides.export.CommentsPositions.RIGHT

    # تعيين عرض منطقة إخراج التعليقات
    options.notes_comments_layouting.comments_area_width = 500
                
    # تعيين اللون لمنطقة التعليقات
    options.notes_comments_layouting.comments_area_color = draw.Color.antique_white
                
    # تحويل الشريحة الأولى من العرض التقديمي إلى كائن بت ماب
    with pres.slides[0].get_image(options, 2, 2) as bmp:
        # حفظ الصورة في تنسيق GIF
        bmp.save("Slide_Notes_Comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="ملاحظة" color="warning" %}} 

في أي عملية تحويل شريحة إلى صورة، لا يمكن تعيين خاصية [NotesPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/) إلى BottomFull (لتحديد الموقع للملاحظات) لأن نص الملاحظة قد يكون كبيرًا، مما يعني أنه قد لا يناسب حجم الصورة المحدد.

{{% /alert %}} 

## **تحويل الشرائح إلى صور باستخدام ITiffOptions**

واجهة [ITiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/itiffoptions/) تمنحك مزيدًا من التحكم (من حيث المعلمات) على الصورة الناتجة. باستخدام هذه الواجهة، يمكنك تحديد الحجم والدقة ولوحة الألوان ومعلمات أخرى للصورة الناتجة.

هذا الكود بلغة بايثون يظهر عملية التحويل حيث يتم استخدام ITiffOptions لإخراج صورة بالأبيض والأسود بدقة 300 نقطة في البوصة وحجم 2160 × 2800:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation(path + "Comments1.pptx") as pres:
    # الحصول على شريحة بواسطة فهرسها
    slide = pres.slides[0]

    # إنشاء كائن TiffOptions
    options = slides.export.TiffOptions() 
    options.image_size = draw.Size(2160, 2880)

    # تعيين الخط المستخدم في حالة عدم العثور على خط المصدر
    options.default_regular_font = "Arial Black"

    # تعيين موقع الملاحظات على الصفحة 
    options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    # تعيين تنسيق البكسل (أسود وأبيض)
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT_1BPP_INDEXED

    # تعيين الدقة
    options.dpi_x = 300
    options.dpi_y = 300

    # تحويل الشريحة إلى كائن بت ماب
    with slide.get_image(options) as bmp:
        # حفظ الصورة في تنسيق BMP
        bmp.save("PresentationNotesComments.tiff", slides.ImageFormat.TIFF)
```

## **تحويل جميع الشرائح إلى صور**

Aspose.Slides يسمح لك بتحويل جميع الشرائح في عرض تقديمي واحد إلى صور. بشكل أساسي، يمكنك تحويل العرض التقديمي (بشكل كامل) إلى صور.

هذا الكود النموذجي يوضح لك كيفية تحويل جميع الشرائح في عرض تقديمي إلى صور باستخدام بايثون:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    # عرض العرض التقديمي إلى مصفوفة الصور شريحة بشريحة
    for i in range(len(pres.slides)):
        # تحديد الإعدادات للشرائح المخفية (عدم عرض الشرائح المخفية)
        if pres.slides[i].hidden:
            continue

        # تحويل الشريحة إلى كائن بت ماب
        with pres.slides[i].get_image() as bmp:
            # حفظ الصورة في تنسيق JPEG
            bmp.save("image_{0}.jpeg".format(i), slides.ImageFormat.JPEG)
```