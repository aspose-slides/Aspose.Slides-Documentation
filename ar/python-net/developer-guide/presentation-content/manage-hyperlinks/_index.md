---
title: إدارة الارتباطات التشعبية
type: docs
weight: 20
url: /python-net/manage-hyperlinks/
keywords: "إضافة ارتباط تشعبي، عرض PowerPoint، الارتباط التشعبي PowerPoint، ارتباط نصي، ارتباط شريحة، ارتباط شكل، ارتباط صورة، ارتباط فيديو، Python"
description: "إضافة ارتباط تشعبي إلى عرض PowerPoint في Python"
---

الارتباط التشعبي هو إشارة إلى كائن أو بيانات أو مكان في شيء ما. هذه هي الارتباطات التشعبية الشائعة في عروض PowerPoint:

* روابط لمواقع الويب داخل النصوص أو الأشكال أو الوسائط
* روابط إلى الشرائح

تسمح لك Aspose.Slides for Python عبر .NET بتنفيذ العديد من المهام المتعلقة بالارتباطات التشعبية في العروض التقديمية.

{{% alert color="primary" %}} 

قد ترغب في الاطلاع على محرر PowerPoint المجاني عبر الإنترنت من Aspose، [محرر PowerPoint](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **إضافة ارتباطات URL**

### **إضافة ارتباطات URL إلى النصوص**

يوضح هذا الرمز بلغة Python كيفية إضافة ارتباط تشعبي لموقع ويب إلى نص:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape1 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("Aspose: واجهات برمجة التطبيقات لتنسيقات الملفات")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click.tooltip = "أكثر من 70% من شركات Fortune 100 تثق في واجهات برمجة التطبيقات من Aspose"
    shape1.text_frame.paragraphs[0].portions[0].portion_format.font_height = 32
    
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **إضافة ارتباطات URL إلى الأشكال أو الإطارات**

يوضح هذا الرمز النموذجي بلغة Python كيفية إضافة ارتباط تشعبي لموقع ويب إلى شكل:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "أكثر من 70% من شركات Fortune 100 تثق في واجهات برمجة التطبيقات من Aspose"

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

### **إضافة ارتباطات URL إلى الوسائط**

تسمح لك Aspose.Slides بإضافة ارتباطات تشعبية إلى الصور وملفات الصوت والفيديو.

يوضح هذا الرمز النموذجي كيفية إضافة ارتباط تشعبي إلى **صورة**:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    # إضافة صورة إلى العرض التقديمي
    with open("img.jpeg", "rb") as fs:
        data = fs.read()
        image = pres.images.add_image(data)
        
        # إنشاء إطار صورة في الشريحة 1 بناءً على الصورة المضاف إليها سابقًا
        pictureFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

        pictureFrame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
        pictureFrame.hyperlink_click.tooltip = "أكثر من 70% من شركات Fortune 100 تثق في واجهات برمجة التطبيقات من Aspose"

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

يوضح هذا الرمز النموذجي كيفية إضافة ارتباط تشعبي إلى **ملف صوتي**:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    with open("audio.mp3", "rb") as fs:
        data = fs.read()
        audio = pres.audios.add_audio(data)
        
        audioFrame = pres.slides[0].shapes.add_audio_frame_embedded(10, 10, 100, 100, audio)

        audioFrame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
        audioFrame.hyperlink_click.tooltip = "أكثر من 70% من شركات Fortune 100 تثق في واجهات برمجة التطبيقات من Aspose"

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

يوضح هذا الرمز النموذجي كيفية إضافة ارتباط تشعبي إلى **فيديو**:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    with open("video.avi", "rb") as fs:
        data = fs.read()
        video = pres.videos.add_video(data)
        
        videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 100, 100, video)

        videoFrame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
        videoFrame.hyperlink_click.tooltip = "أكثر من 70% من شركات Fortune 100 تثق في واجهات برمجة التطبيقات من Aspose"

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert  title="نصيحة"  color="primary"  %}} 

قد ترغب في رؤية *[إدارة OLE](https://docs.aspose.com/slides/python-net/manage-ole/)*.

{{% /alert %}}


## **استخدام الارتباطات التشعبية لإنشاء جدول محتويات**

نظرًا لأن الارتباطات التشعبية تتيح لك إضافة مراجع إلى كائنات أو أماكن، يمكنك استخدامها لإنشاء جدول محتويات.

يوضح هذا الرمز النموذجي كيفية إنشاء جدول محتويات مع روابط:

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
    paragraph.text = "عنوان الشريحة 2 .......... "

    linkPortion = slides.Portion()
    linkPortion.text = "الصفحة 2"
    linkPortion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)

    paragraph.portions.add(linkPortion)
    content_table.text_frame.paragraphs.add(paragraph)

    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```


## **تنسيق الارتباطات التشعبية**

### **اللون**

مع خاصية [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/) في واجهة [IHyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)، يمكنك تعيين اللون للارتباطات التشعبية وأيضًا الحصول على معلومات اللون من الارتباطات التشعبية. تم تقديم هذه الميزة لأول مرة في PowerPoint 2019، لذا فإن التغييرات التي تتعلق بالخاصة لا تنطبق على إصدارات PowerPoint الأقدم.

يوضح هذا الرمز النموذجي عملية حيث تمت إضافة ارتباطات تشعبية بألوان مختلفة إلى نفس الشريحة:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape1 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("هذا نموذج لارتباط تشعبي ملون.")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    shape1.text_frame.paragraphs[0].portions[0].portion_format.fill_format.fill_type = slides.FillType.SOLID
    shape1.text_frame.paragraphs[0].portions[0].portion_format.fill_format.solid_fill_color.color = draw.Color.red

    shape2 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    shape2.add_text_frame("هذا نموذج لارتباط تشعبي عادي.")
    shape2.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")

    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```


## **إزالة الارتباطات التشعبية في العروض التقديمية**

### **إزالة الارتباطات التشعبية من النصوص**

يوضح هذا الرمز بلغة Python كيفية إزالة الارتباط التشعبي من نص في شريحة عرض تقديمي:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    for shape in slide.shapes:
        if type(shape) is slides.AutoShape:
            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    portion.portion_format.hyperlink_manager.remove_hyperlink_click()
    pres.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

### **إزالة الارتباطات التشعبية من الأشكال أو الإطارات**

يوضح هذا الرمز بلغة Python كيفية إزالة الارتباط التشعبي من شكل في شريحة عرض تقديمي:

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as pres:
   slide = pres.slides[0]
   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()
   pres.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```


## **الارتباط التشعبي القابل للتعديل**

فئة [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink) قابلة للتعديل. مع هذه الفئة، يمكنك تغيير القيم لهذه الخصائص:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.History](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)

يوضح مقتطف الرمز كيفية إضافة ارتباط تشعبي إلى شريحة وتحرير نص التلميح الخاص به لاحقًا:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape1 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("Aspose: واجهات برمجة التطبيقات لتنسيقات الملفات")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click.tooltip = "أكثر من 70% من شركات Fortune 100 تثق في واجهات برمجة التطبيقات من Aspose"
    shape1.text_frame.paragraphs[0].portions[0].portion_format.font_height = 32

    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```


## **الخصائص المدعومة في IHyperlinkQueries**

يمكنك الوصول إلى IHyperlinkQueries من عرض تقديمي أو شريحة أو نص تم تعريف الارتباط التشعبي لها.

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/)

تدعم فئة IHyperlinkQueries هذه الطرق والخصائص:

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)