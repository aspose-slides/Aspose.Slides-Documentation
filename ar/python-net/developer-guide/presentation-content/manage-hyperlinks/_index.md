---
title: إدارة الارتباطات التشعبية للعرض التقديمي في بايثون
linktitle: إدارة الارتباطات التشعبية
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
- ارتباط تشعبي للشريحة
- ارتباط تشعبي للشكل
- ارتباط تشعبي للصورة
- ارتباط تشعبي للفيديو
- ارتباط تشعبي قابل للتعديل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إضافة وتنسيق وتحديث وإزالة الارتباطات التشعبية في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides لبايثون عبر .NET، مع أمثلة بايثون."
---
## **المقدمة**

يعمل الارتباط التشعبي على ربط محتوى العرض التقديمي بموقع ويب أو بموقع داخل العرض التقديمي. في PowerPoint، يُستخدم الارتباط التشعبي عادةً لغرضين:

* فتح موقع ويب من النص أو الشكل أو إطار الوسائط.
* الانتقال إلى شريحة أخرى، على سبيل المثال من جدول المحتويات.

يتيح لك Aspose.Slides for Python via .NET إضافة هذه الروابط، التحكم في مظهرها وصوتها، تحديث خصائصها، وإزالتها. تُظهر الأمثلة أدناه كيفية العمل مع الارتباطات التشعبية على العناصر الفردية وكيفية الوصول إلى الارتباطات التشعبية على مستوى العرض التقديمي أو الشريحة أو إطار النص.

{{% alert color="info" title="Note" %}}
يمكنك أيضًا تحرير العروض التقديمية باستخدام [محرر Aspose PowerPoint المجاني عبر الإنترنت](https://products.aspose.app/slides/ar/editor).
{{% /alert %}}

## **إضافة روابط URL**

يمكنك تعيين عنوان موقع ويب إلى النص أو الشكل أو إطار الوسائط. يحدد العنصر الذي تُعيّن إليه الارتباط المساحة القابلة للنقر: جزء النص يربط النص المحدد، بينما الشكل أو الإطار يربط كائن الشريحة.

### **إضافة روابط URL إلى النص**

لربط النص بموقع ويب، عيّن [Hyperlink](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlink/) إلى خاصية [hyperlink_click](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portionformat/hyperlink_click/) لجزء النص، كما هو موضح أدناه. يصبح فقط ذلك الجزء من النص قابلاً للنقر.

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

### **إضافة روابط URL إلى الأشكال وإطارات الوسائط**

لجعل الشكل أو الإطار قابلاً للنقر، اضبط خاصية [hyperlink_click](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/hyperlink_click/) الخاصة به. ينتمي الارتباط التشعبي إلى الكائن نفسه وليس إلى جزء نص داخلها.

ينطبق النهج نفسه على إطارات الصور والصوت والفيديو: عيّن الارتباط إلى الإطار واضبط [tooltip](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlink/tooltip/) إذا لزم الأمر.

المثال التالي يجعل مستطيلًا قابلاً للنقر:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **استخدام الارتباطات التشعبية لإنشاء جدول محتويات**

تسمح الارتباطات التشعبية الداخلية للقارئ بالانتقال من جدول المحتويات إلى شريحة محددة. يستخدم المثال التالي [set_internal_hyperlink_click](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) لربط نص “Page 2” في الشريحة الأولى بالشريحة الثانية.

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

## **تنسيق الارتباطات التشعبية**

### **اللون**

تحدد خاصية [color_source](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlink/color_source/) لـ [Hyperlink](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlink/) ما إذا كان الارتباط سيستخدم لون الارتباط التشعبي في العرض أو تنسيق جزء النص. لتطبيق لون نص مخصص، اختر [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlinkcolorsource/) واضبط لون تعبئة الجزء. تم تقديم هذه الميزة في PowerPoint 2019؛ الإصدارات القديمة لا تطبق هذا الإعداد.

المثال التالي يضيف رابطين نصيين إلى نفس الشريحة. يستخدم الأول تعبئة نص حمراء، بينما يحتفظ الثاني بلون الارتباط التشعبي الافتراضي.

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

يمكن للارتباط التشعبي تشغيل صوت عند تفعيله أو إيقاف صوت يعمل مسبقًا. استخدم الخصائص التالية لتكوين هذه السلوكيات:

- [Hyperlink.sound](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlink/sound/) يحدد الصوت المرتبط بالارتباط التشعبي.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlink/stop_sound_on_click/) يتحكم فيما إذا كان تفعيل الارتباط يوقف الصوت السابق.

#### **إضافة صوت للارتباط التشعبي**

المثال التالي يحمل `sampleaudio.wav` ويربطه بزر في الشريحة الأولى. النقر على الزر يشغل الصوت وينتقل إلى الشريحة التالية. الشكل الثاني على نفس الشريحة يوقف الصوت السابق عند النقر، دون تنفيذ إجراء تنقل.

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

#### **استخراج صوت الارتباط التشعبي**

المثال التالي يفتح العرض الذي تم إنشاؤه أعلاه ويقرأ صوت الارتباط التشعبي للشكل الأول إلى الذاكرة عبر [sound](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlink/sound/) و [binary_data](https://reference.aspose.com/slides/ar/python-net/aspose.slides/audio/binary_data/).

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

### **تلميحات الأدوات وإعدادات التفاعل**

يمكنك تحديث الخصائص التالية لـ [Hyperlink](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlink/) بعد تعيين ارتباط تشعبي للنص أو الشكل:

- [tooltip](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlink/tooltip/) يعيّن النص الذي يمكن للمشاهد عرضه كتلميح للارتباط.
- [target_frame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlink/target_frame/) يحدد إطار الهدف داخل مجموعة إطارات HTML الأصلية، إذا كان ذلك مناسبًا.
- [history](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlink/history/) يتحكم فيما إذا كان تفعيل الارتباط يضيف الهدف إلى قائمة الارتباطات المشاهدة.
- [highlight_click](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlink/highlight_click/) يتحكم فيما إذا كان الارتباط يظل مظللًا عند النقر.

## **إزالة الارتباطات التشعبية من العروض**

استخدم [get_any_hyperlinks](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) لجمع حاويات الارتباطات التشعبية، بما في ذلك روابط أجزاء النص، قبل تعديلها. يزيل المثال التالي كلا نوعي التفعيل من الشريحة الأولى. لإزالة نوع واحد فقط، استدعِ فقط [remove_hyperlink_click](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) أو [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/)؛ إزالة إجراء النقر لا يزيل النظير الخاص بالتمرير فوق الفأرة.

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

لإزالة غير مشروطة، يقوم [remove_all_hyperlinks](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) بإزالة كلا نوعي التفعيل في النطاق المحدد في استدعاء واحد. للتنظيف الانتقائي وتغطية الماسترز، التخطيطات، والملاحظات، راجع [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **بناء جرد كامل للارتباطات التشعبية**

قبل توزيع عرض تقديمي، قم بجرد الإجراءات التفاعلية وكذلك الروابط الويب. تُعيد [get_any_hyperlinks](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) كائنات [IHyperlinkContainer](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ihyperlinkcontainer/)، وليس قائمة مسطحة من سلاسل URL. افحص كل من [hyperlink_click](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) و [hyperlink_mouse_over](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) على كل حاوية. هما مستقلان: يمكن لنفس الحاوية أن تعرض كلا الإجراءين، لذا يحتاج التقرير الكامل إلى صفين كحد أقصى لكل حاوية.

قد يؤدي فحص الارتباطات على مستوى الشكل فقط إلى تفويت الروابط المرفقة بأجزاء النص. استعلم النطاق المناسب بدلاً من ذلك، واحتفظ بالحاويات المسترجعة لتتمكن لاحقًا من تحديثها أو إزالتها.

### **استعلام نطاقات العرض، الشريحة، وإطار النص**

الفئة [HyperlinkQueries](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlinkqueries/) متاحة عبر [Presentation.hyperlink_queries](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/hyperlink_queries/)، [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseslide/hyperlink_queries/)، و [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/hyperlink_queries/). يدعم كل نطاق نفس الاستعلامات:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) يُرجع حاويات ذات إجراء نقرة.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) يُرجع حاويات ذات إجراء تمرير فوق الفأرة.
- [get_any_hyperlinks](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) يُرجع حاويات ذات أي من الإجراءين أو كلاهما.

المثال التالي يُنشئ `hyperlink-audit-input.pptx` مع رابط نقرة خارجي، رابط تمرير فوق الفأرة إلى ملف، تنقل شريحة داخلي، رابط تمرير فوق الفأرة للنص، وإجراء ماكرو. لا يُنفّذ أيًا من هذه الإجراءات. تعمل الاستعلامات الثلاثة نفسها في كل نطاق؛ الأعداد تُصفّح الحاويات، لا إجماليات الإجراءات. يستثني نطاق إطار النص الروابط الخاصة بالشكل المحيط.

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

في هذا المثال، تُبلغ استعلامات العرض والشريحة عن ثلاث حاويات نقرة، حاويتين تمرير فوق الفأرة، وثلاث حاويات ذات أي إجراء. تُبلغ استعلامات إطار النص عن حاوية واحدة في كل فئة.

### **تصنيف الإجراءات والوجهات**

استخدم [Hyperlink.action_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlink/action_type/) لتفسير الإجراء قبل تفسير الوجهة. تغطي قيم [HyperlinkActionType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlinkactiontype/) ما هو أكثر من تنقل الويب:

| القيم | معنى أثناء التدقيق |
| --- | --- |
| `HYPERLINK` | ارتباط تشعبي خارجي؛ افحص URL ومخططه. |
| `JUMP_SPECIFIC_SLIDE` | تنقل داخلي إلى شريحة معينة. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | تنقل مدمج في عرض الشرائح، يُحل في سياق عرض الشرائح. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | إنهاء العرض الحالي أو بدء عرض مخصص. |
| `START_MACRO` | تنفيذ ماكرو. |
| `START_PROGRAM` | تشغيل برنامج. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | فتح ملف أو عرض تقديمي آخر؛ راجعها منفصلة عن عناوين URL للويب. |
| `START_STOP_MEDIA` | بدء أو إيقاف تشغيل وسائط. |
| `NO_ACTION`, `UNKNOWN` | لا إجراء تنقل، أو إجراء غير معروف يتطلب مراجعة. |

اقرأ الوجهات الخارجية من [external_url](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlink/external_url/) والوجهات الداخلية المحددة من [target_slide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlink/target_slide/). قد لا تحتوي الإجراءات الداخلية والأوامر المدمجة على URL خارجي؛ عدم وجود URL لا يعني أن الحاوية لا تحمل إجراءً. احتفظ بـ [external_url_original](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlink/external_url_original/) عندما يختلف عن URL المُطبع، وأدرج [tooltip](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlink/tooltip/) إذا كان متاحًا.

### **الإبلاغ، التنقية، والتحقق من الارتباطات التشعبية**

المثال التالي بلغة Python يقرأ عرضًا تقديميًا موجودًا (استخدم الملف الذي أنشئ أعلاه)، يكتب `hyperlink-audit.json`، يطبق سياسة، يحفظ `hyperlink-sanitized.pptx`، ثم يعيد فتحه للتحقق من كلا نوعي التفعيل مرة أخرى. يجمع الحاويات قبل تعديلها ويستعلم كل نطاق شريحة مرة واحدة لتجنب المعالجة المكررة. تغطي استعلامات العرض الشرائح العادية؛ لجرد كامل على مستوى الحزمة، يستعلم المثال عن الشرائح العادية، الماسترز، التخطيطات، الملاحظات، و мастرز الملاحظات والملاحظات إذا وجدت.

يسجل التقرير فهرس شريحة يبدأ من واحد و [slide_id](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseslide/slide_id/) حيثما كان متاحًا. يحتفظ الجامع بالشرائح المالكة والنطاق إلى جانب كل حاوية مسترجعة. لا تحمل الماسترز، التخطيطات، والملاحظات فهرس شريحة عادي وتُحدد بنطاقها. تُصنّف حاويات الشكل وحاويات تنسيق أجزاء النص بشكل منفصل؛ الأنواع الأخرى تحتفظ باسم نوعها في وقت التشغيل. يحصل كل حاوية على معرف محلي في التقرير لربط الإجراءين معًا.

تسمح هذه السياسة التطبيقية التقييدية فقط بعناوين URL مطلقة عبر HTTPS ووجهات شرائح داخلية صالحة. تُرفض الماكروهات، البرامج، إجراءات الملفات، إجراءات عروض الشرائح الأخرى، الإجراءات غير المعروفة، وأنواع URL غير HTTPS. هذه الرفض قرارات سياسة، ليست حكمًا أمنيًا من Aspose.Slides. لا يُنشئ HTTPS الثقة وحده: أضف قوائم السماح للمضيف وفحوصات أخرى لتطبيقك. يتم فحص كل من URLs الأصلية والمنتظمة. لا يتبع المثال الروابط أو ينفّذ الإجراءات أثناء تدقيق البيانات الوصفية.

للتصحيح، يدعم [hyperlink_manager](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) الخاص بالحاوية [set_external_hyperlink_click](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/)، [remove_hyperlink_click](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/)، و [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/). هنا تُستبدل روابط النقر الخارجية غير المسموح بها بصفحة هبوط HTTPS ثابتة؛ تُحذف النقرات غير المسموح بها وإجراءات المرور فوق الفأرة غير المسموح بها بشكل مستقل. اضبط `replace_external_clicks` إلى `False` لإزالة جميع انتهاكات السياسة بدلاً من ذلك. اختر صفحة استبدال مملوكة للتطبيق قبل النشر.

يستخدم علم تصدير التقرير سياسة مراجعة PDF تحفظية: يُعلِّم إجراءات المرور فوق الفأرة وأي شيء آخر غير رابط خارجي أو قفزة شريحة محددة على أنه محتمل عدم الدعم. هو مجرد تلميح مراجعة، ليس اختبار قدرة أو ضمان أن الروابط غير المعلَّمة ستبقى بعد التصدير. قد تحتفظ تصديرات PDF وHTML المدعومة بالارتباطات حسب الإجراء، خيارات التصدير، والمشاهد. لا يمكن للصور النقطية (PNG) والفيديو الحفاظ على الارتباطات التفاعلية؛ علِّم كل إجراء عند التدقيق لإخراج تلك الصيغ.

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
    # استعلام نطاق كل شريحة مرة واحدة مع الاحتفاظ بمالكها لكل حاوية.
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

مع الإدخال الذي تم إنشاؤه أعلاه، يحتوي التقرير على خمس صفوف إجراءات. يُزال رابط تمرير فوق الفأرة للملف والماكرو، بينما تبقى روابط HTTPS والتنقل الداخلي للشرائح. تُظهر عملية التحقق عدم وجود إجراءات ممنوعة. إدخال يحتوي على رابط نقرة خارجي ممنوع يُظهر فرع الاستبدال. الحاوية التي لها نقرة مسموح بها وتمرير فوق الفأرة ممنوع تحتفظ بإجراء النقرة.

هذا التنظيف الانتقائي يختلف عن [remove_all_hyperlinks](https://reference.aspose.com/slides/ar/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)، الذي يزيل كلا نوعي التفعيل في النطاق المحدد بغض النظر عن السياسة. تتحقق عملية التحقق هنا من إجراءات الارتباط فقط؛ لا تُزيل مشاريع VBA المدمجة، كائنات OLE، أو أي محتوى نشط آخر، ولا تُصادق على ملف PDF أو HTML المُصدَّر.

## **الأسئلة المتكررة**

**كيف يمكنني ربط قسم أو أول شريحة فيه؟**

تُجمع الشرائح في PowerPoint داخل أقسام، لكن الارتباط التشعبي الداخلي يستهدف شريحة فردية. لإنشاء تنقل إلى قسم، اربط بأول شريحة في ذلك القسم.

**هل يمكنني إرفاق ارتباط تشعبي إلى عناصر الشريحة الرئيسية بحيث يعمل على جميع الشرائح؟**

نعم. تدعم عناصر الشريحة الرئيسية والتخطيطية الارتباطات التشعبية. تكون الروابط على هذه العناصر متاحة أثناء عرض الشرائح على الشرائح التي تستخدم الماستر أو التخطيط المقابل.

**هل ستحافظ الارتباطات التشعبية عند التصدير إلى PDF أو HTML أو صور أو فيديو؟**

قد تحتفظ تصديرات PDF وHTML المدعومة بالارتباطات؛ لا يمكن للصور النقطية والفيديو الحفاظ عليها. راجع اعتبارات التصدير في [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).