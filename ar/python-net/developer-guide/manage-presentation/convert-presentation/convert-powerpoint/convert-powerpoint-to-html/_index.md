---
title: تحويل عروض PowerPoint التقديمية إلى HTML في Python
linktitle: PowerPoint إلى HTML
type: docs
weight: 30
url: /ar/python-net/convert-powerpoint-to-html/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى HTML
- العرض التقديمي إلى HTML
- الشريحة إلى HTML
- PPT إلى HTML
- PPTX إلى HTML
- حفظ PowerPoint كـ HTML
- حفظ العرض التقديمي كـ HTML
- حفظ الشريحة كـ HTML
- حفظ PPT كـ HTML
- حفظ PPTX كـ HTML
- تصدير PPT إلى HTML
- تصدير PPTX إلى HTML
- Python
- Aspose.Slides
description: تحويل عروض PowerPoint التقديمية إلى HTML في Python. استخدم Aspose.Slides لتصدير ملفات PPT و PPTX، الشرائح المختارة، الملاحظات، الخطوط، الصور، SVG، والوسائط.
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Python عبر .NET حفظ عروض PowerPoint التقديمية كـ HTML دون الحاجة إلى Microsoft PowerPoint. التحويل الأساسي هو تحميل واحد لـ [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) ثم استدعاء `save` باستخدام [SaveFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/saveformat/). استخدم [HtmlOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/htmloptions/) عندما تحتاج إلى التحكم في تخطيط التصدير، الخطوط، الصور، الملاحظات، التعليقات، إخراج SVG، أو الموارد المرتبطة.

يركز هذا الدليل على سيناريوهات تصدير HTML العملية:

- تصدير عرض تقديمي كامل أو شرائح مختارة.
- إنشاء HTML ثابت التخطيط، متجاوب، أو مبني على SVG.
- تضمين ملاحظات المتحدث والتعليقات.
- التحكم في جودة الصورة وبيانات الصورة المقطوعة.
- تضمين الخطوط أو حفظ ملفات الخط بشكل منفصل.
- اختيار طريقة كتابة ومراجعة الموارد الخارجية وملفات الوسائط.

بشكل افتراضي، ينتج تصدير HTML مستند HTML ذاتي‑الإحتواء حيث تُضمّن معظم الموارد. هذا مريح لمشاركة ملف واحد، لكنه قد يزيد من حجم الناتج. للنشر على الويب، ضع في اعتبارك الموارد الخارجية، خفض DPI الصورة، وتضمين الخطوط فقط عندما لا تكون متوفرة بثقة في البيئة المستهدفة.

## **تحويل عرض تقديمي إلى HTML**

لتصدير عرض تقديمي إلى HTML، حمله باستخدام [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) واحفظه باستخدام [SaveFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/saveformat/).

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.html", slides.export.SaveFormat.HTML)
```

هذا المثال يكتب ملف HTML واحد. جملة `with` تتخلص من كائن العرض وتطلق مقابض الملفات وموارد التصيير بعد التصدير.

## **استخدام HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/htmloptions/) هي الفئة الرئيسية للتهيئة لتصدير HTML. تشمل الإعدادات الشائعة:

- `slides_layout_options`: يضيف الملاحظات، التعليقات، الملخصات، أو معلومات تخطيط أخرى.
- `html_formatter`: يغيّر بنية مستند HTML أو يفوض التنسيق إلى المتحكم.
- `slide_image_format`: يغيّر طريقة تمثيل الشرائح، على سبيل المثال كـ SVG.
- `pictures_compression`: يتحكم في DPI الصورة وحجم الناتج.
- `delete_pictures_cropped_areas`: يحتفظ أو يزيل بيانات الصورة المقطوعة.
- `svg_responsive_layout`: يجعل محتوى SVG المُصدّر يتكيف مع حاويته.
- `show_hidden_slides`: يتضمن الشرائح المخفية عند الحاجة.

توضح الأقسام التالية أكثر الخيارات شيوعًا بشكل منفصل حتى تتمكن من دمج فقط ما تحتاجه سير عملك.

## **تحويل شرائح مختارة إلى HTML**

التحميل الزائد `save` الذي يقبل أرقام الشرائح يستخدم مواقع شرائح تبدأ من 1. الحلقة أدناه تحفظ كل شريحة إلى ملف HTML منفصل.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide_count = len(presentation.slides)

    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = [slide_number]
        html_file_name = "slide-{}.html".format(slide_number)

        presentation.save(html_file_name, slide_numbers, slides.export.SaveFormat.HTML)
```

استخدم هذا النمط عندما يحتاج موقع ويب أو تطبيق إلى صفحة HTML واحدة لكل شريحة. إذا كان يجب أن يكون لكل شريحة نفس التخطيط، أنشئ كائنًا واحدًا من [HtmlOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/htmloptions/) ومرره إلى كل استدعاء `save`.

## **إنشاء HTML متجاوب**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/responsivehtmlcontroller/) يوفر ناتج HTML متجاوب عبر [HtmlFormatter](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/htmlformatter/). استخدمه عندما ينبغي للصفحة المصدرة أن تتكيف بشكل أفضل مع عرض المتصفح.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    controller = slides.export.ResponsiveHtmlController()
    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

للتخطيط المتجاوب المستند إلى SVG، اضبط `svg_responsive_layout` على [HtmlOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/htmloptions/). هذا مفيد عندما يُصدّر محتوى الشريحة كعلامات SVG قابلة للتوسيع.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.svg_responsive_layout = True

    presentation.save("presentation-svg-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

## **تضمين ملاحظات المتحدث والتعليقات**

استخدم [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/notescommentslayoutingoptions/) من خلال `html_options.slides_layout_options` لتضمين ملاحظات المتحدث أو التعليقات. تكون الملاحظات والتعليقات مخفية افتراضيًا ما لم تُحدد مواقعها.

لنفترض أن العرض المصدر يحتوي على ملاحظات المتحدث:

![شريحة تحتوي على ملاحظات المتحدث في PowerPoint](slide_with_notes.png)

الكود التالي يُصدّر محتوى الشريحة مع ملاحظات المتحدث أسفل الشريحة.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    layout_options = slides.export.NotesCommentsLayoutingOptions()
    layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    html_options = slides.export.HtmlOptions()
    html_options.slides_layout_options = layout_options

    presentation.save("presentation-with-notes.html", slides.export.SaveFormat.HTML, html_options)
```

يتضمن HTML المُصدّر منطقة الملاحظات:

![ناتج HTML مع الشريحة وملاحظات المتحدث](HTML_with_notes.png)

لتصدير التعليقات، اضبط `comments_position`، على سبيل المثال إلى `CommentsPositions.RIGHT` أو `CommentsPositions.BOTTOM`. إذا كنت تحتاج إلى التعليقات فقط، احذف `notes_position`. إذا كنت تحتاج إلى كل من الملاحظات والتعليقات، اضبط الخاصيتين.

## **التحكم في جودة الصورة والمساحات المقصوصة**

يمكن لتصدير HTML ضغط صور الشرائح لتقليل حجم الناتج. اضبط `pictures_compression` إلى قيمة من [PicturesCompression](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/picturescompression/) عندما تحتاج إلى جودة صورة أعلى.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.pictures_compression = slides.export.PicturesCompression.DPI150

    presentation.save("presentation-dpi-150.html", slides.export.SaveFormat.HTML, html_options)
```

افتراضيًا، قد تُزال المناطق المقصوصة من الصور في الناتج المصدّر. احتفظ بالبيانات المقصوصة فقط عندما يجب أن يتمكن المستخدمون من استعادة أو فحص تلك الأجزاء المخفية من الصورة. الاحتفاظ بها قد يزيد من حجم HTML.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.delete_pictures_cropped_areas = False

    presentation.save("presentation-with-cropped-areas.html", slides.export.SaveFormat.HTML, html_options)
```

## **إضافة CSS**

للتنسيق البسيط، مرّر سلسلة CSS إلى [HtmlFormatter](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/htmlformatter/). يغيّر هذا مستند HTML المحيط بينما يواصل Aspose.Slides تصيير محتوى الشريحة.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = slides.export.HtmlFormatter.create_document_formatter(css_rules, True)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-styled.html", slides.export.SaveFormat.HTML, html_options)
```

لإنشاء رأس مستند مخصص، ملف CSS مرتبط، أو تعليمات HTML مخصّصة حول الشرائح والأشكال، استخدم متحكم تنسيق مخصّص ومرره إلى [HtmlFormatter](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/htmlformatter/) باستخدام `create_custom_formatter`.

## **تضمين الخطوط**

إذا كان من الممكن أن لا تكون خطوط العرض موجودة في البيئة المستهدفة، قم بتضمين الخطوط في HTML باستخدام [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/embedallfontshtmlcontroller/). يضيف التضمين دقة بصرية أكبر لكنه يزيد من حجم الناتج.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    font_names_to_exclude = ["Arial"]
    font_controller = slides.export.EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = slides.export.HtmlFormatter.create_custom_formatter(font_controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-embedded-fonts.html", slides.export.SaveFormat.HTML, html_options)
```

استثنِ الخط فقط عندما تكون واثقًا من أن المتصفحات أو الأنظمة المستهدفة توفره بالفعل. للخطوط الخاصة بالعلامة التجارية أو الخطوط الأقل شيوعًا، يعتبر التضمين غالبًا أكثر أمانًا.

## **ربط ملفات الخط بدلاً من تضمينها**

لتقليل حجم ملف HTML، يمكنك كتابة بيانات الخط إلى ملفات WOFF منفصلة وإضافة قواعد `@font-face` إلى HTML. يتطلب ذلك متحكم يخصص طريقة كتابة بيانات الخط أثناء التصدير. في Python عبر .NET، نفّذ ذلك المتحكم في تجميعة مساعدة .NET صغيرة، حمّلها في Python، ومرّر كائن المساعدة إلى [HtmlFormatter](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/htmlformatter/) باستخدام `create_custom_formatter`.

عند فصل الخطوط خارجيًا، اختر مسارين عمدًا:

- دليل الإخراج في نظام الملفات حيث سيتم كتابة ملفات WOFF المتولدة.
- مسار URL الذي سيظهر في مستند HTML والذي سيستخدمه المتصفح لتحميل ملفات الخط تلك.

احتفظ بملف HTML وملفات الخط المتولدة معًا حتى تصبح مسارات النشر نهائية. إذا نُشرت الملفات في موقع آخر، اجعل بادئة URL مطابقة لمسار URL المنشور.

## **حفظ الموارد خارجيًا**

HTML ذاتية الإحتواء سهلة النقل، لكن الموارد المضمَّنة بصيغة Base64 قد تجعل الملف كبيرًا. إذا كان تطبيقك يحتاج إلى صور، خطوط، صوت أو فيديو خارجي، استخدم متحكم ربط/تضمين مخصص ومرره إلى مُنشئ [HtmlOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/htmloptions/).

عند فصل الموارد خارجيًا، اختر مسارين عمدًا:

- مسار الإخراج في نظام الملفات، حيث يكتب تطبيقك الصور، الخطوط، الصوت أو الفيديو المتولد.
- مسار URL، وهو ما يستخدمه المتصفح من مستند HTML لتحميل تلك الملفات.

لمناقشة شاملة حول ربط الصور، راجع [تصدير العروض التقديمية إلى HTML مع صور مرتبطة خارجيًا](/slides/ar/python-net/exporting-presentations-to-html-with-externally-linked-images/).

## **تصدير ملفات الوسائط**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/videoplayerhtmlcontroller/) يصدر ملفات الفيديو والصوت ويكتب HTML يمكن تشغيله في المتصفح. يأخذ المُنشئ:

- `path`: الدليل الذي سيتم كتابة ملفات الوسائط المتولدة فيه.
- `file_name`: اسم ملف HTML المتولد.
- `base_uri`: بادئة الـ URI المطلقة المستخدمة في روابط HTML لملفات الوسائط.

إذا كان ملف HTML هو `html-output/presentation.html` وكانت ملفات الوسائط محفوظة في `html-output/media`، يجب أن يشير `path` إلى دليل الوسائط على القرص، بينما يجب أن يشير `base_uri` إلى نفس الدليل من وجهة نظر المتصفح. للمعاينة المحلية، يمكنك بناء URI من النوع `file:///` من دليل الوسائط. لتطبيق منشور، استخدم عنوان URL المطلق لدليل الوسائط المنشور.

```python
import os
from pathlib import Path

import aspose.slides as slides

output_directory = os.path.join(os.getcwd(), "html-output")
media_directory = os.path.join(output_directory, "media")
os.makedirs(output_directory, exist_ok=True)
os.makedirs(media_directory, exist_ok=True)

html_file_name = "presentation.html"
media_base_uri = Path(media_directory).as_uri() + "/"

with slides.Presentation() as presentation:
    with open("intro.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(
            video_stream,
            slides.LoadingStreamBehavior.READ_STREAM_AND_RELEASE)

    slide = presentation.slides[0]
    slide.shapes.add_video_frame(20, 20, 480, 270, video)

    controller = slides.export.VideoPlayerHtmlController(
        media_directory,
        html_file_name,
        media_base_uri)

    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
    svg_options = slides.export.SVGOptions(controller)
    slide_image_format = slides.export.SlideImageFormat.svg(svg_options)

    html_options = slides.export.HtmlOptions(controller)
    html_options.html_formatter = formatter
    html_options.slide_image_format = slide_image_format

    html_file_path = os.path.join(output_directory, html_file_name)
    presentation.save(html_file_path, slides.export.SaveFormat.HTML, html_options)
```

استخدم دلائل إخراج فريدة لكل مهمة تصدير، خاصة في تطبيقات الخادم. قد تتسبب دلائل الإخراج المشتركة في استبدال ملفات من تحويلات مختلفة بعضها البعض.

## **الأداء وإدارة الموارد**

تحويل HTML هو عملية تصيير، لذا يعتمد زمن المعالجة واستهلاك الذاكرة على عدد الشرائح، دقة الصورة، الخطوط، التأثيرات، المخططات، والوسائط المضمنة. القيم الأعلى لـ DPI في `pictures_compression`، الخطوط المضمنة، إخراج SVG، والاحتفاظ بمناطق الصورة المقصوصة قد تحسن الدقة لكنها عادةً ما تزيد من حجم الناتج.

للتحويل على دفعات:

- تخلص من كل كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) فورًا.
- استخدم دلائل إخراج منفصلة لكل مهمة.
- تجنّب تضمين الخطوط الشائعة إلا إذا كانت الدقة تتطلب ذلك.
- قلل DPI الصورة عندما يكون HTML للمعاينة أو الصور المصغرة.
- احفظ العرض المصدر، HTML المتولد، والموارد الخارجية معًا حتى تصبح مسارات النشر نهائية.

## **الأسئلة الشائعة**

**هل تم الحفاظ على الروابط التشعبية في ناتج HTML؟**

نعم. يتم تصدير روابط العروض التقديمية إلى HTML وتبقى قابلة للنقر عندما يكون عنوان URL الهدف صالحًا.

**هل يمكنني تحويل العروض التقديمية إلى HTML بشكل متوازي؟**

نعم، لكن لا تشارك كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) واحد بين الخيوط. عالج ملفات مختلفة باستخدام كائنات عرض منفصلة، تدفقات منفصلة، ودلائل إخراج منفصلة. راجع [إرشادات تعدد الخيوط](/slides/ar/python-net/multithreading/) للحصول على التفاصيل.

**هل كائن Presentation آمن للاستخدام عبر خيوط متعددة؟**

لا. يجب تحميل وتعديل وحفظ وتطهير كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) واحد على خيط واحد فقط. للعمل المتوازي، أنشئ كائنًا مستقلاً لكل خيط أو عملية.

**لماذا يكون ملف HTML المتولد كبيرًا؟**

يمكن للتصدير الافتراضي تضمين الموارد مباشرة في HTML. الخطوط المضمنة، الصور عالية DPI، الوسائط، محتوى SVG، والاحتفاظ بمناطق الصورة المقصوصة تزيد أيضًا من الحجم. استخدم موارد خارجية، استثنِ الخطوط الشائعة من التضمين، وقلل `pictures_compression` عندما يكون حجم الناتج الصغير أهم من أقصى دقة.

**كيف يجب اختيار base_uri لتصدير الوسائط؟**

اختر `base_uri` من وجهة نظر المتصفح ومرره كـ URI مطلق. للمعاينة المحلية، يمكنك استنتاجه من دليل الإخراج باستخدام `Path(media_directory).as_uri() + "/"`. للنشر، استخدم عنوان URL المطلق للدليل الإعلامي المنشور. لا يلزم أن يكون مسار نظام الملفات `path` و `base_uri` المتصفح نفس النص، لكن يجب أن يصفا نفس موقع المورد.

**هل يمكنني تضمين الشرائح المخفية؟**

نعم. اضبط `show_hidden_slides = True` على [HtmlOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/htmloptions/) عندما يجب تصدير الشرائح المخفية.