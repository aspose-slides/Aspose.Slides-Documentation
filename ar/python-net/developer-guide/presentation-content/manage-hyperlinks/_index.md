---
title: إدارة الروابط التشعبية في العروض التقديمية باستخدام Python
linktitle: إدارة الرابط التشعبي
type: docs
weight: 20
url: /ar/python-net/manage-hyperlinks/
keywords:
- إضافة URL
- إضافة رابط تشعبي
- إنشاء رابط تشعبي
- تنسيق رابط تشعبي
- إزالة رابط تشعبي
- تحديث رابط تشعبي
- نص رابط تشعبي
- شريحة رابط تشعبي
- شكل رابط تشعبي
- صورة رابط تشعبي
- فيديو رابط تشعبي
- رابط تشعبي قابل للتغيير
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
description: "قم بإدارة الروابط التشعبية بسهولة في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for Python عبر .NET—عزّز التفاعل وسير العمل في دقائق."
---

## **نظرة عامة**

الرابط التشعبي هو إشارة إلى مورد خارجي أو كائن أو عنصر بيانات، أو إلى موقع محدد داخل ملف. تشمل أنواع الروابط التشعبية الشائعة في عروض PowerPoint:

* روابط إلى مواقع ويب مدمجة في النص أو الأشكال أو الوسائط
* روابط إلى شرائح

يمكّن Aspose.Slides for Python عبر .NET مجموعة واسعة من العمليات المتعلقة بالروابط التشعبية في العروض التقديمية.

## **إضافة روابط URL**

يوضح هذا القسم كيفية إضافة روابط URL إلى عناصر الشريحة عند العمل مع Aspose.Slides. يغطي تعيين عناوين الروابط إلى النص، الأشكال، والصور لضمان تنقل سلس أثناء العرض.

### **إضافة روابط URL إلى النص**

يظهر المثال التالي كيفية إضافة رابط موقع ويب إلى النص:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")
    
    text_portion = shape.text_frame.paragraphs[0].portions[0]

    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **إضافة روابط URL إلى الأشكال أو الإطارات**

يظهر المثال التالي كيفية إضافة رابط موقع ويب إلى شكل:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)

    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **إضافة روابط URL إلى الوسائط**

يسمح Aspose.Slides لك بإضافة روابط إلى الصور، الصوت، وملفات الفيديو.

#### إضافة رابط إلى **صورة**

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add an image to the presentation.
    with open("image.jpeg", "rb") as image_stream:
        image_data = image_stream.read()
        image = presentation.images.add_image(image_data)

    # Create a picture frame on slide 1 using the image added earlier.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    picture_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    picture_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

#### إضافة رابط إلى **ملف صوتي**

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()
        audio = presentation.audios.add_audio(audio_data)
        
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 100, 100, audio)

    audio_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    audio_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

#### إضافة رابط إلى **فيديو**

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.avi", "rb") as video_stream:
        video_data = video_stream.read()
        video = presentation.videos.add_video(video_data)
        
    video_frame = slide.shapes.add_video_frame(10, 10, 100, 100, video)

    video_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    video_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="نصيحة" color="primary" %}}
قد ترغب في الاطلاع على [إدارة OLE في العروض التقديمية باستخدام Python](/slides/ar/python-net/manage-ole/).
{{% /alert %}}

## **استخدام الروابط التشعبية لإنشاء جدول محتويات**

نظرًا لأن الروابط التشعبية تتيح لك الإشارة إلى كائنات أو مواقع، يمكنك استخدامها لبناء جدول محتويات.

يوضح الكود أدناه كيفية إنشاء جدول محتويات مع روابط تشعبية:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)

    content_table = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    content_table.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "

    link_text_portion = slides.Portion()
    link_text_portion.text = "Page 2"
    link_text_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)

    paragraph.portions.add(link_text_portion)
    content_table.text_frame.paragraphs.add(paragraph)

    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **تنسيق الروابط التشعبية**

يوضح هذا القسم كيفية تنسيق مظهر الروابط التشعبية في Aspose.Slides. ستتعلم كيفية التحكم في اللون وخيارات النمط الأخرى للحفاظ على تنسيق الروابط موحدًا عبر النصوص، الأشكال، والصور.

### **لون الرابط التشعبي**

باستخدام الخاصية [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) لفئة [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/)، يمكنك تعيين لون الرابط وقراءة معلومات لونه. تم تقديم هذه الميزة في PowerPoint 2019، لذا لا تُطبّق التغييرات التي تُجرى عبر هذه الخاصية على الإصدارات الأقدم من PowerPoint.

يوضح المثال التالي كيفية إضافة روابط بألوان مختلفة إلى نفس الشريحة:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("This is a sample of a colored hyperlink.")

    text_portion1 = shape1.text_frame.paragraphs[0].portions[0]
    text_portion1.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion1.portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    text_portion1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_portion1.portion_format.fill_format.solid_fill_color.color = draw.Color.red

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    shape2.add_text_frame("This is a sample of a regular hyperlink.")

    text_portion2 = shape2.text_frame.paragraphs[0].portions[0]
    text_portion2.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")

    presentation.save("hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **إزالة الروابط التشعبية من العروض التقديمية**

يشرح هذا القسم كيفية إزالة الروابط التشعبية من العروض التقديمية عند العمل مع Aspose.Slides. ستتعلم كيفية مسح أهداف الروابط من النصوص، الأشكال، والصور مع الحفاظ على المحتوى والتنسيق الأصلي.

### **إزالة الروابط التشعبية من النص**

يوضح الكود التالي كيفية إزالة الروابط التشعبية من النص داخل شريحة عرض تقديمي:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if type(shape) is slides.AutoShape:
            for paragraph in shape.text_frame.paragraphs:
                for text_portion in paragraph.portions:
                    text_portion.portion_format.hyperlink_manager.remove_hyperlink_click()

    presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

### **إزالة الروابط التشعبية من الأشكال أو الإطارات**

يوضح الكود التالي كيفية إزالة الروابط التشعبية من الأشكال على شريحة عرض تقديمي:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   slide = presentation.slides[0]

   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()

   presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **الروابط التشعبية القابلة للتعديل**

فئة [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) قابلة للتعديل. باستخدام هذه الفئة، يمكنك تغيير قيم الخصائص التالية:

- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/)
- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/)
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/)
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/)
- [stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/)

يوضح المقطع التالي كيفية إضافة رابط إلى شريحة ثم تعديل النص التوضيحي له:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")

    text_portion = shape.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **الخصائص المدعومة في IHyperlinkQueries**

يمكنك الوصول إلى [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) من العرض التقديمي، الشريحة، أو النص الذي يحتوي على الرابط.

- [Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/)
- [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/)
- [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/)

تدعم فئة [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) الطرق التالية:

- [get_hyperlink_clicks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/)
- [get_hyperlink_mouse_overs()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/)
- [get_any_hyperlinks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)
- [remove_all_hyperlinks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)

{{% alert color="primary" %}}
قد ترغب في تجربة محرر PowerPoint البسيط والمجاني من Aspose على الإنترنت [هنا](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **الأسئلة الشائعة**

**كيف يمكنني إنشاء تنقل داخلي ليس فقط إلى شريحة، بل إلى "قسم" أو الشريحة الأولى من قسم؟**

الأقسام في PowerPoint هي مجموعات من الشرائح؛ يستهدف التنقل تقنيًا شريحة معينة. للـ "انتقال إلى قسم"، عادةً ما ترتبط بأول شريحة في ذلك القسم.

**هل يمكنني إرفاق رابط تشعبي بعناصر الشريحة الرئيسة بحيث يعمل على جميع الشرائح؟**

نعم. تدعم عناصر الشريحة الرئيسة (Master) وتخطيطاتها الروابط التشعبية. تظهر هذه الروابط على الشرائح الفرعية وتكون قابلة للنقر خلال عرض الشرائح.

**هل تُحافظ الروابط التشعبية عند التصدير إلى PDF أو HTML أو الصور أو الفيديو؟**

في [PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/) و[HTML](/slides/ar/python-net/convert-powerpoint-to-html/)، نعم—عادةً ما تُحفظ الروابط. عند التصدير إلى [الصور](/slides/ar/python-net/convert-powerpoint-to-png/) و[الفيديو](/slides/ar/python-net/convert-powerpoint-to-video/)، لن تُحفظ القابلية للنقر بسبب طبيعة تلك الصيغ (الإطارات النقطية/الفيديو لا تدعم الروابط التشعبية).