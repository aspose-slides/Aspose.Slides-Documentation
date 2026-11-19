---
title: إدارة الروابط التشعبية للعرض في بايثون
linktitle: إدارة الروابط التشعبية
type: docs
weight: 20
url: /ar/python-net/manage-hyperlinks/
keywords:
- إضافة URL
- إضافة ارتباط تشعبي
- إنشاء ارتباط تشعبي
- تنسيق ارتباط تشعبي
- إزالة ارتباط تشعبي
- تحديث ارتباط تشعبي
- ارتباط تشعبي للنص
- ارتباط تشعبي للشرائح
- ارتباط تشعبي للشكل
- ارتباط تشعبي للصورة
- ارتباط تشعبي للفيديو
- ارتباط تشعبي قابل للتغيير
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إضافة وتنسيق وتحديث وإزالة الروابط التشعبية في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لبايثون عبر .NET، مع أمثلة بايثون."
---
## **المقدمة**

يُربط الارتباط التشعبي محتوى العرض بموقع ويب أو بموقع داخل العرض نفسه. في PowerPoint، يُستخدم الارتباط التشعبي عادةً لأغراضين:

* فتح موقع ويب من نص أو شكل أو إطار وسائط.
* الانتقال إلى شريحة أخرى، على سبيل المثال من جدول المحتويات.

تتيح لك Aspose.Slides for Python via .NET إضافة هذه الروابط، التحكم في مظهرها وصوتها، تحديث خصائصها، وإزالتها. تُظهر الأمثلة أدناه كيفية التعامل مع الروابط التشعبية على العناصر الفردية وكيفية الوصول إلى الروابط على مستوى العرض أو الشريحة أو إطار النص.

{{% alert color="info" title="Note" %}}
يمكنك أيضًا تحرير العروض باستخدام [محرر Aspose PowerPoint المجاني عبر الإنترنت](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **إضافة روابط تشعبية URL**

يمكنك تعيين عنوان URL لموقع ويب إلى نص أو شكل أو إطار وسائط. العنصر الذي تُعيّن إليه الارتباط يحدد المنطقة القابلة للنقر: ربط جزء من النص يجعل النص المحدد قابلًا للنقر، بينما يجعل الشكل أو الإطار كامل الكائن في الشريحة قابلًا للنقر.

للعروض التي تحتوي على روابط تشعبية نسبية، راجع [Manage the Hyperlink Base](/slides/ar/python-net/presentation-properties/#manage-the-hyperlink-base) لقراءة أو تغيير أو مسح القاعدة على مستوى المستند.

### **إضافة روابط تشعبية URL إلى النص**

لربط النص بموقع ويب، عيّن [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) إلى خاصية [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/hyperlink_click/) لجزء النص، كما هو موضح أدناه. سيصبح ذلك الجزء فقط من النص قابلًا للنقر.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    text_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    text_shape.add_text_frame("Aspose: File Format APIs")
    portion_format = text_shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    portion_format.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    portion_format.font_height = 32
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **إضافة روابط تشعبية URL إلى الأشكال وإطارات الوسائط**

عيّن عنوان URL إلى خاصية [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/shape/hyperlink_click/) للمستطيل لجعل كامل مساحته قابلة للنقر. تُظهر خاصية [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) تلميحًا للقراء حول الوجهة عند تمرير الماوس فوق المستطيل. تنطبق نفس الخصائص على إطارات الصور والصوت والفيديو.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **استخدام الروابط لإنشاء جدول محتويات**

تسمح الروابط الداخلية للقراء بالانتقال من جدول المحتويات إلى شريحة معينة. يستخدم المثال التالي الدالة [set_internal_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) لربط نص “Page 2” في الشريحة الأولى بالشريحة الثانية.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    table_of_contents = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    table_of_contents.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.text_frame.paragraphs.clear()
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "
    link_portion = slides.Portion()
    link_portion.text = "Page 2"
    link_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)
    paragraph.portions.add(link_portion)
    table_of_contents.text_frame.paragraphs.add(paragraph)
    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **تنسيق الروابط**

يمكنك تغيير لون النص المرتبط، تشغيل أو إيقاف صوت عند تنشيط القارئ للارتباط، وتعيين التلميح (tooltip) الذي يظهر عند المرور فوقه.

### **اللون**

تحدد خاصية [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) لكائن [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) ما إذا كان الارتباط يستخدم لون الروابط في العرض أو تنسيق جزء النص. لتطبيق لون نص مخصص، اختر [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkcolorsource/) واضبط لون تعبئة الجزء. تم تقديم هذه الميزة في PowerPoint 2019؛ الإصدارات الأقدم لا تطبق هذا الإعداد.

في هذا المثال، يجعل تعيين [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) على الرابط الأول نصه يظهر باللون الأحمر. الرابط الثاني يحتفظ بلون الروابط في العرض.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    colored_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 450, 50, False)
    colored_shape.add_text_frame("This hyperlink uses a custom color.")
    colored_portion_format = colored_shape.text_frame.paragraphs[0].portions[0].portion_format
    colored_portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    colored_portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    colored_portion_format.fill_format.fill_type = slides.FillType.SOLID
    colored_portion_format.fill_format.solid_fill_color.color = draw.Color.red
    default_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    default_shape.add_text_frame("This hyperlink uses the default color.")
    default_shape.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

### **الصوت**

يمكن للارتباط تشغيل صوت عند التنشيط أو إيقاف صوت يُشغل بالفعل. استخدم الخصائص التالية لتكوين هذه السلوكيات:

- [Hyperlink.sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) يحدد الصوت المرتبط بالارتباط.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) يتحكم فيما إذا كان تنشيط الارتباط يوقف الصوت السابق.

#### **إضافة صوت للارتباط**

يستخدم الزر في الشريحة الأولى الخاصية [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) لتشغيل ملف WAV عندما ينقر القارئ للتقدم. في الشريحة الثانية، يستخدم زر منفصل الخاصية [stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) لإيقاف التشغيل وإبقاء القارئ على تلك الشريحة.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("sampleaudio.wav", "rb") as audio_file:
        audio_data = audio_file.read()
    hyperlink_sound = presentation.audios.add_audio(audio_data)
    first_slide = presentation.slides[0]
    play_button = first_slide.shapes.add_auto_shape(slides.ShapeType.SOUND_BUTTON, 100, 100, 100, 50)
    play_button.hyperlink_click = slides.Hyperlink.next_slide
    if not play_button.hyperlink_click.stop_sound_on_click and play_button.hyperlink_click.sound is None:
        play_button.hyperlink_click.sound = hyperlink_sound

    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    stop_button = second_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 100, 50)
    stop_button.hyperlink_click = slides.Hyperlink.no_action
    stop_button.hyperlink_click.stop_sound_on_click = True
    presentation.save("hyperlink-sound.pptx", slides.export.SaveFormat.PPTX)
```

#### **استخراج صوت الارتباط**

يفتح المثال التالي العرض الذي تم إنشاؤه أعلاه ويقرأ صوت الارتباط للعنصر الأول إلى الذاكرة عبر الخاصيتين [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) و [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/).

```python
import aspose.slides as slides

with slides.Presentation("hyperlink-sound.pptx") as presentation:
    if len(presentation.slides) > 0 and len(presentation.slides[0].shapes) > 0:
        hyperlink = presentation.slides[0].shapes[0].hyperlink_click
        sound = hyperlink.sound if hyperlink is not None else None
        if sound is not None:
            audio_data = sound.binary_data
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
```

### **التلميح وإعدادات التفاعل**

يمكنك تحديث الخصائص التالية لكائن [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) بعد تعيين الارتباط إلى نص أو شكل:

- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) يحدد النص الذي يمكن للمشاهد عرضه كتلميح للارتباط.
- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/) يحدد إطار الهدف داخل مجموعة إطارات HTML أصلية، إذا كان ذلك مناسبًا.
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/) يتحكم فيما إذا كان تنشيط الارتباط يضيف هدفه إلى قائمة الروابط التي تم عرضها.
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/) يتحكم فيما إذا كان الارتباط يُبرز عند النقر.

## **إزالة الروابط من العروض**

استخدم الدالة [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) لجمع حاويات الروابط، بما في ذلك روابط أجزاء النص، قبل تعديلها. يزيل المثال التالي كلا نوعي التنشيط من الشريحة الأولى. لإزالة نوع واحد فقط، استدعِ فقط [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) أو [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/)؛ إزالة إجراء النقر لا تُزيل نظيره عند مرور الماوس.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    if len(presentation.slides) > 0:
        containers = list(presentation.slides[0].hyperlink_queries.get_any_hyperlinks())
        for container in containers:
            container.hyperlink_manager.remove_hyperlink_click()
            container.hyperlink_manager.remove_hyperlink_mouse_over()
        presentation.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The presentation has no slides to process.")
```

لإزالة غير مشروطة، تُزيل الدالة [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) كلا نوعي التنشيط في النطاق المحدد في استدعاء واحد. للتنظيف الانتقائي وتغطية القوالب، التخطيطات، والملاحظات، راجع [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

### **مسح الروابط قبل استبدال نص SmartArt**

عند استبدال فقرة في عقدة SmartArt موجودة، قد يؤدي مسح أجزاء النص إلى ترك ارتباط قديم ساري. استرجع الفقرة عبر [SmartArtNode.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/text_frame/). قبل مسح أجزائها، استدعِ [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) عبر [hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/) على إطار النص للشكل الذي يعرض الفقرة. يزيل ذلك كل ارتباط في ذلك الإطار، بما فيها الروابط في الفقرات الأخرى.

في ملف `SmartArtHyperlink.pptx`، الشكل الثالث في الشريحة الأولى هو رسم SmartArt. يستبدل المثال الفقرة الأولى من العقدة الرابعة. في هذا العرض، يعرض الشكل الأول من العقدة تلك الفقرة.

بعد إضافة الجزأين، تقرأ الأمثلة تنسيقهما الفعّال باستخدام الدالة [get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/). تُعيد خاصية [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/iportionformateffectivedata/hyperlink_click/) الفعّالية الرابط الجديد للجزء الأول و`None` للثاني.

```python
import aspose.slides as slides

with slides.Presentation("SmartArtHyperlink.pptx") as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes[2]
    node = smart_art.all_nodes[3]
    paragraph = node.text_frame.paragraphs[0]

    node.shapes[0].text_frame.hyperlink_queries.remove_all_hyperlinks()
    paragraph.portions.clear()

    link = slides.Portion("New reference")
    link.portion_format.hyperlink_click = slides.Hyperlink("https://example.com/new")
    paragraph.portions.add(link)
    text = slides.Portion(" (updated)")
    paragraph.portions.add(text)

    print(link.portion_format.get_effective().hyperlink_click.external_url)  # https://example.com/new
    print(text.portion_format.get_effective().hyperlink_click)  # لا شيء
```

## **إنشاء جرد كامل للروابط**

قبل توزيع العرض، اجمع جردًا للإجراءات التفاعلية وروابط الويب. تُعيد الدالة [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) كائنات من نوع [IHyperlinkContainer](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/)، وليس قائمة مسطحة من سلاسل URL. افحص كلًا من [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) و [hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) على كل حاوية. هما مستقلان: يمكن لنفس الحاوية أن تعرض كلا الإجراءين، لذا يحتاج التقرير الكامل إلى صفين كحد أقصى لكل حاوية.

قد يفوتك فحص الروابط على مستوى الشكل إذا لم تشمل الروابط المرفقة بأجزاء النص. استعلم عن النطاق المناسب بدلاً من ذلك، واحتفظ بالحاويات المرجعة لتتمكن لاحقًا من تحديثها أو إزالتها.

### **استعلام عن نطاقات العرض، الشريحة، وإطار النص**

تتوفر الفئة [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) عبر الخصائص [Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/)، [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/)، و [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/). يدعم كل نطاق نفس الاستعلامات:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) يُعيد الحاويات ذات إجراء النقر.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) يُعيد الحاويات ذات إجراء المرور فوق الماوس.
- [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) يُعيد الحاويات التي لديها أي من الإجراءين أو كليهما.

يُسند هذا المثال إجراءات النقر والمرور فوق الماوس إلى شكل ونصه، وإجراء ماكرو إلى زر منفصل. يقارن الحاويات المرجعة من [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) مع عدد كل نوع من إجراءات التنشيط. يُظهر استعلام إطار النص عدد الروابط الموجودة في النص فقط. تظهر إجراءات الشكل الخاصة بالاحتواء في استعلامات الشريحة والعرض.

```python
import aspose.slides as slides


def print_counts(scope, queries):
    click_containers = queries.get_hyperlink_clicks()
    mouse_over_containers = queries.get_hyperlink_mouse_overs()
    all_containers = queries.get_any_hyperlinks()
    print(f"{scope}: click={len(click_containers)}, mouse-over={len(mouse_over_containers)}, any={len(all_containers)}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    destination = presentation.slides.add_empty_slide(slide.layout_slide)
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Click the text to go to slide 2"
    shape.hyperlink_manager.set_external_hyperlink_click("https://example.com/")
    shape.hyperlink_click.tooltip = "Public website"
    shape.hyperlink_manager.set_external_hyperlink_mouse_over("file:///C:/private/report.xlsx")

    portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_manager.set_internal_hyperlink_click(destination)
    portion_format.hyperlink_manager.set_external_hyperlink_mouse_over("https://example.com/help")
    macro_button = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 120, 200, 60)
    macro_button.hyperlink_manager.set_macro_hyperlink_click("ReviewPresentation")

    print_counts("Presentation", presentation.hyperlink_queries)
    print_counts("Slide 1", slide.hyperlink_queries)
    print_counts("Text frame", shape.text_frame.hyperlink_queries)
    presentation.save("hyperlink-audit-input.pptx", slides.export.SaveFormat.PPTX)
```

في هذا المثال، تُبلغ استعلامات العرض والشريحة عن ثلاثة حاويات نقر، وحاويتين مرور فوق الماوس، وثلاث حاويات ذات أي إجراء. يُبلغ استعلام إطار النص عن حاوية واحدة في كل فئة.

### **تصنيف الإجراءات والوجهات**

استخدم الخاصية [Hyperlink.action_type](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/action_type/) لتفسير الإجراء قبل تفسير الوجهة. تغطي قيم [HyperlinkActionType](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkactiontype/) ما هو أكثر من تنقل ويب:

| القيم | المعنى للتدقيق |
| --- | --- |
| `HYPERLINK` | ارتباط تشعبي خارجي؛ افحص URL ومخططه. |
| `JUMP_SPECIFIC_SLIDE` | تنقل داخلي إلى شريحة معينة. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | تنقل مدمج في عرض الشرائح، يُفسّر في سياق العرض. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | إنهاء العرض الحالي أو بدء عرض مخصص. |
| `START_MACRO` | تنفيذ ماكرو. |
| `START_PROGRAM` | تشغيل برنامج. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | فتح ملف أو عرض آخر؛ راجعها منفصلًا عن عناوين URL للويب. |
| `START_STOP_MEDIA` | تشغيل أو إيقاف تشغيل وسائط. |
| `NO_ACTION`, `UNKNOWN` | لا يوجد إجراء تنقل، أو إجراء غير معروف يتطلب مراجعة. |

اقرأ الوجهات الخارجية من الخاصية [external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) والوجهات الداخلية المحددة من الخاصية [target_slide](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_slide/). قد لا تحتوي الإجراءات الداخلية والأوامر المدمجة على URL خارجي؛ URL الفارغ لا يعني أن الحاوية لا تحتوي على إجراء. احتفظ بـ [external_url_original](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url_original/) عندما يختلف عن URL المُقنّن، وضمّن [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) عندما يكون متاحًا.

### **التقرير، التنظيف، والتحقق من الروابط**

يفتح هذا المثال العرض من المثال السابق ويكتب سجل JSON واحد لكل إجراء. يستخدم [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) لجمع الحاويات على الشرائح العادية، القوالب، التخطيطات، والملاحظات، بما في ذلك قوالب الملاحظات والنشرات عند وجودها. يستعلم كل نطاق مرة واحدة لتفادي المعالجة المتكررة، يطبق السياسة الموضحة أدناه، ثم يعيد فتح العرض المحفوظ للتحقق من إجراءات النقر والمرور فوق الماوس.

يسجل التقرير فهرس شريحة يبدأ من واحد و[slide_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/slide_id/) عندما يكون متاحًا. يحتفظ الجمع بالشرائح المالكة والنطاق إلى جانب كل حاوية مرتجعة. القوالب، التخطيطات، والملاحظات ليس لها فهرس شريحة عادي وتُعرف بنطاقها. تُصنّف حاويات الشكل وحاويات تنسيق جزء النص بشكل منفصل؛ تحتفظ الأنواع الأخرى باسم نوعها في وقت التشغيل. يُعطى كل حاوية معرف تقرير محلي لتقريبه بين إجراءي النقر والمرور فوق الماوس.

تسمح سياسة التطبيق الصارمة هذه بوجود عناوين URL مطلقة فقط عبر HTTPS ووجهات شرائح داخلية صالحة. تُرفض الماكروهات، البرامج، إجراءات الملفات، إجراءات عرض الشرائح الأخرى، الإجراءات غير المعروفة، ومخططات URL الأخرى. هذه الرفضات قرارات سياسة، ولا تُعدّ حُكمًا على أمان Aspose.Slides. HTTPS وحده لا يضمن الثقة: أضف قوائم السماح للمضيف وفحوصات أخرى لتطبيقك. تُفحص كل من URL الأصلي والـ URL المُقنّن. يُجرى التدقيق على البيانات الوصفية دون تتبع الروابط أو تشغيل الإجراءات.

للتصحيح، يدعم [hyperlink_manager](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) الخاص بالحاوية الدوال [set_external_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/)، [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/)، و [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/). هنا، تُستبدل روابط النقر الخارجية المحظورة بصفحة هبوط HTTPS ثابتة؛ تُزال النقرات والمرور فوق الماوس المحظورة بشكل مستقل. اضبط المتغير `replace_external_clicks` إلى `False` لإزالة جميع مخالفات السياسة بدلًا من استبدالها. اختر صفحة بديلة مملوكة للتطبيق قبل النشر.

يستخدم علم تصدير التقرير سياسة مراجعة PDF متحفظة: يُعلَّم إجراءات المرور فوق الماوس وأي شيء غير رابط خارجي أو قفزة شريحة محددة على أنه قد لا يُدعم. هذا مجرد تلميح مراجعة، وليس اختبار قدرة أو ضمان بقاء الروابط غير المعلّمة عند التصدير. قد تحتفظ عمليات تصدير [PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/) و[HTML](/slides/ar/python-net/convert-powerpoint-to-html/) المدعومة بالروابط، اعتمادًا على الإجراء، خيارات التصدير، والمشاهد. لا يمكن لإطارات [images](/slides/ar/python-net/convert-powerpoint-to-png/) و[video](/slides/ar/python-net/convert-powerpoint-to-video/) الاحتفاظ بالروابط التفاعلية؛ علّم كل إجراء عند التدقيق لتلك المخرجات.

```python
import json
import sys
from urllib.parse import urlsplit
import aspose.slides as slides


def is_https(value):
    if not value or any(character.isspace() for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.action_type == slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE:
        return "Missing target slide" if link.target_slide is None else None
    if link.action_type != slides.HyperlinkActionType.HYPERLINK:
        return "Action is not allowed"
    if not is_https(link.external_url):
        return "Normalized URL is not absolute HTTPS"
    original = link.external_url_original
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def slide_index(presentation, slide):
    if slide is not None:
        for index, candidate in enumerate(presentation.slides, start=1):
            if candidate.slide_id == slide.slide_id:
                return index
    return None


def collect_containers(presentation):
    # استعلام كل نطاق شريحة مرة واحدة، مع الاحتفاظ بالمالك لكل حاوية.
    scopes = [("Slide", slide) for slide in presentation.slides]
    scopes.extend(("Master", master) for master in presentation.masters)
    scopes.extend(("Layout", layout) for layout in presentation.layout_slides)
    scopes.extend(("Notes", slide.notes_slide_manager.notes_slide) for slide in presentation.slides)
    scopes.append(("Notes master", presentation.master_notes_slide_manager.master_notes_slide))
    scopes.append(("Handout master", presentation.master_handout_slide_manager.master_handout_slide))
    found = []
    for scope, owner in scopes:
        if owner is not None:
            containers = list(owner.hyperlink_queries.get_any_hyperlinks())
            found.extend((container, scope, owner) for container in containers)
    return found


def add_row(rows, presentation, link, activation, container, container_id, scope, owner):
    if link is None:
        return
    target_slide = link.target_slide
    violation = policy_violation(link)
    if isinstance(container, slides.Shape):
        owner_type = "Shape"
    elif isinstance(container, slides.PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = type(container).__name__
    ordinary_action = link.action_type in (slides.HyperlinkActionType.HYPERLINK, slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE)
    original_url = link.external_url_original if link.external_url_original != link.external_url else None
    rows.append({
        "container_id": container_id,
        "slide_index": slide_index(presentation, owner) if scope == "Slide" else None,
        "slide_id": owner.slide_id,
        "scope": scope,
        "owner_type": owner_type,
        "activation": activation,
        "action_type": link.action_type.name,
        "external_url": link.external_url,
        "target_slide_index": slide_index(presentation, target_slide),
        "target_slide_id": target_slide.slide_id if target_slide is not None else None,
        "tooltip": link.tooltip,
        "original_external_url": original_url,
        "potentially_unsafe": violation is not None,
        "policy_violation": violation,
        "target_export": "PDF",
        "potentially_unsupported_by_export": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"

with slides.Presentation("hyperlink-audit-input.pptx") as presentation:
    containers = collect_containers(presentation)
    rows = []
    for container_id, (container, scope, owner) in enumerate(containers, start=1):
        add_row(rows, presentation, container.hyperlink_click, "click", container, container_id, scope, owner)
        add_row(rows, presentation, container.hyperlink_mouse_over, "mouse-over", container, container_id, scope, owner)

    with open("hyperlink-audit.json", "w", encoding="utf-8") as report_file:
        json.dump(rows, report_file, indent=2)

    for container, scope, owner in containers:
        click = container.hyperlink_click
        if policy_violation(click) is not None:
            if replace_external_clicks and click.action_type == slides.HyperlinkActionType.HYPERLINK:
                container.hyperlink_manager.set_external_hyperlink_click(replacement_url)
            else:
                container.hyperlink_manager.remove_hyperlink_click()
        if policy_violation(container.hyperlink_mouse_over) is not None:
            container.hyperlink_manager.remove_hyperlink_mouse_over()

    presentation.save("hyperlink-sanitized.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlink-sanitized.pptx") as reopened:
    remaining_containers = collect_containers(reopened)
    violations = 0
    for container, scope, owner in remaining_containers:
        if policy_violation(container.hyperlink_click) is not None:
            violations += 1
        if policy_violation(container.hyperlink_mouse_over) is not None:
            violations += 1
    print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
    if violations != 0:
        print("Verification failed: do not distribute the saved presentation.")
        sys.exit(1)
```

مع الإدخال المنشأ أعلاه، يحتوي التقرير على خمس صفوف إجراءات. تُزيل رابط المرور فوق الماوس والماكرو، بينما تُحافظ روابط HTTPS والتنقل الداخلي على وجودها. يطبع التحقق صفر إجراءات محظورة. يُظهر إدخال يحتوي على URL خارجي محظور فرع الاستبدال. حاوية ذات نقر مسموح ومرور فوق ماكرو محظور تحتفظ بإجراء النقر الخاص بها.

يختلف هذا التنظيف الانتقائي عن الدالة [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)، التي تُزيل كلا نوعي التنشيط عبر النطاق المحدد بغض النظر عن السياسة. تتحقق عملية التحقق هنا من إجراءات الروابط فقط؛ لا تُزيل مشاريع VBA المدمجة، كائنات OLE، أو محتوى نشط آخر، ولا تتحقق من ملف PDF أو HTML المصدر.

## **الأسئلة الشائعة**

**كيف يمكنني الربط بقسم أو أول شريحة له؟**

تُجَمّع الأقسام في PowerPoint شرائح معًا، لكن الارتباط الداخلي يستهدف شريحة فردية. لإنشاء تنقل إلى قسم، اربط بأول شريحة في ذلك القسم.

**هل يمكنني إرفاق ارتباط تشعبي لعناصر شريحة القالب لتعمل على جميع الشرائح؟**

نعم. تدعم عناصر شريحة القالب والتخطيط الارتباطات التشعبية. تكون الروابط على هذه العناصر متاحة أثناء عرض الشرائح للشرائح التي تستخدم القالب أو التخطيط المقابل.

**هل ستُحفظ الروابط عند التصدير إلى PDF أو HTML أو صور أو فيديو؟**

قد تحتفظ عمليات تصدير PDF وHTML المدعومة بالروابط؛ لا يمكن للصور النقطية والفيديو الاحتفاظ بالروابط التفاعلية. راجع اعتبارات التصدير في [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).