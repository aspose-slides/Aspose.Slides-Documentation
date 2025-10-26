---
title: إدارة الروابط التشعبية في العروض التقديمية باستخدام بايثون
linktitle: إدارة الارتباط التشعبي
type: docs
weight: 20
url: /ar/python-net/developer-guide/presentation-content/manage-hyperlinks/
keywords:
- add URL
- add hyperlink
- create hyperlink
- format hyperlink
- remove hyperlink
- update hyperlink
- text hyperlink
- slide hyperlink
- shape hyperlink
- image hyperlink
- video hyperlink
- mutable hyperlink
- PowerPoint
- OpenDocument
- presentation
- Python
description: "إدارة الروابط التشعبية بسهولة في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لبايثون عبر .NET—عزّز التفاعل وسير العمل في دقائق."
---

## **نظرة عامة**

الارتباط التشعبي هو مرجع لمورد خارجي أو كائن أو عنصر بيانات، أو موقع محدد داخل ملف. تشمل أنواع الروابط التشعبية الشائعة في عروض PowerPoint ما يلي:

* روابط إلى مواقع ويب مضمّنة في النص أو الأشكال أو الوسائط
* روابط إلى الشرائح

تمكّن Aspose.Slides لبايثون عبر .NET من تنفيذ مجموعة واسعة من العمليات المتعلقة بالروابط التشعبية في العروض التقديمية.

## **إضافة روابط URL تشعبية**

تشرح هذه الفقرة كيفية إضافة روابط URL تشعبية إلى عناصر الشريحة عند العمل مع Aspose.Slides. وتغطي تعيين عناوين الروابط إلى النصوص والأشكال والصور لضمان تنقل سلس أثناء العرض.

### **إضافة روابط URL تشعبية إلى النص**

يوضح المثال البرمجي التالي كيفية إضافة ارتباط تشعبي لموقع ويب إلى نص:

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

### **إضافة روابط URL تشعبية إلى الأشكال أو الإطارات**

يوضح المثال البرمجي التالي كيفية إضافة ارتباط تشعبي لموقع ويب إلى شكل:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)

    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **إضافة روابط URL تشعبية إلى الوسائط**

تتيح Aspose.Slides لك إضافة روابط تشعبية إلى الصور والصوت والفيديو.

#### إضافة ارتباط تشعبي إلى **صورة**:

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

#### إضافة ارتباط تشعبي إلى **ملف صوتي**:

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

#### إضافة ارتباط تشعبي إلى **فيديو**:

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

{{% alert title="Tip" color="primary" %}}
قد ترغب في الإطلاع على [إدارة OLE في العروض التقديمية باستخدام بايثون](/slides/ar/python-net/manage-ole/).
{{% /alert %}}

## **استخدام الروابط التشعبية لإنشاء جدول محتويات**

نظرًا لأن الروابط التشعبية تتيح لك الإشارة إلى كائنات أو مواقع، يمكنك استخدامها لبناء جدول محتويات.

يعرض الكود التالي كيفية إنشاء جدول محتويات مع روابط تشعبية:

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

توضح هذه الفقرة كيفية تنسيق مظهر الروابط التشعبية في Aspose.Slides. ستتعلم كيفية التحكم في اللون وخيارات النمط الأخرى لضمان تناسق تنسيق الروابط عبر النصوص والأشكال والصور.

### **لون الرابط التشعبي**

باستخدام خاصية [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) للفئة [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/)، يمكنك ضبط لون الرابط وقراءة معلومات لونه. تم إدخال هذه الميزة في PowerPoint 2019، لذا لا تُطبق التغييرات التي تتم عبر هذه الخاصية على إصدارات PowerPoint السابقة.

يعرض المثال التالي كيفية إضافة روابط بألوان مختلفة إلى نفس الشريحة:

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

## **حذف الروابط التشعبية من العروض التقديمية**

تشرح هذه الفقرة كيفية حذف الروابط التشعبية من العروض التقديمية عند العمل مع Aspose.Slides. ستتعلم كيفية مسح أهداف الروابط من النصوص والأشكال والصور مع الحفاظ على المحتوى والتنسيق الأصلي.

### **حذف الروابط التشعبية من النص**

يعرض الكود التالي كيفية حذف الروابط التشعبية من النص داخل شريحة عرض:

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

### **حذف الروابط التشعبية من الأشكال أو الإطارات**

يعرض الكود التالي كيفية حذف الروابط التشعبية من الأشكال داخل شريحة عرض:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   slide = presentation.slides[0]

   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()

   presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **روابط تشعبية قابلة للتغيير**

الفئة [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) قابلة للتغيير. باستخدام هذه الفئة، يمكنك تعديل القيم للخصائص التالية:

- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/)
- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/)
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/)
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/)
- [stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/)

يوضح المقتطف التالي كيفية إضافة ارتباط تشعبي إلى شريحة ثم تعديل تلميحه:

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

يمكنك الوصول إلى [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) من العرض أو الشريحة أو النص الذي يحتوي على الارتباط التشعبي.

- [Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/)
- [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/)
- [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/)

تدعم فئة [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) الطرق التالية:

- [get_hyperlink_clicks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/)
- [get_hyperlink_mouse_overs()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/)
- [get_any_hyperlinks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)
- [remove_all_hyperlinks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)

{{% alert color="primary" %}}
قد ترغب في تجربة محرِّر PowerPoint البسيط المجاني عبر الإنترنت من Aspose [PowerPoint editor](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **الأسئلة المتكررة**

**كيف يمكنني إنشاء تنقل داخلي ليس فقط إلى شريحة، بل إلى "قسم" أو الشريحة الأولى في القسم؟**

الأقسام في PowerPoint هي مجموعات من الشرائح؛ التقنية المستهدفة هي شريحة محددة. للتنقل إلى قسم، عادةً ما تقوم بربط الشريحة الأولى من ذلك القسم.

**هل يمكنني إرفاق ارتباط تشعبي لعناصر الشريحة الرئيسية ليعمل على جميع الشرائح؟**

نعم. تدعم عناصر الشريحة الرئيسية وتنسيقات التخطيط الروابط التشعبية. تظهر هذه الروابط على الشرائح الفرعية وتكون قابلة للنقر أثناء العرض.

**هل سيتم الاحتفاظ بالروابط التشعبية عند تصدير العرض إلى PDF أو HTML أو صور أو فيديو؟**

في [PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/) و[HTML](/slides/ar/python-net/convert-powerpoint-to-html/) نعم—تُحافظ الروابط عادةً. أما عند التصدير إلى [الصور](/slides/ar/python-net/convert-powerpoint-to-png/) أو [الفيديو](/slides/ar/python-net/convert-powerpoint-to-video/)، فإن القابلية للنقر لا تُنقل بسبب طبيعة تلك التنسيقات (إطارات نقطية/فيديو لا تدعم الروابط).