---
title: تحويل عروض PowerPoint إلى HTML في Python عبر Java
linktitle: PowerPoint إلى HTML
type: docs
weight: 30
url: /ar/python-java/convert-powerpoint-to-html/
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
- Java
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى HTML في Python عبر Java. استخدم Aspose.Slides لتصدير ملفات PPT و PPTX، الشرائح المختارة، الملاحظات، الخطوط، الصور، SVG، والوسائط."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Python via Java حفظ عروض PowerPoint كملفات HTML دون الحاجة إلى Microsoft PowerPoint. التحويل الأساسي يتم بعملية تحميل واحدة لـ [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) واستدعاء [save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) مع [SaveFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/). استخدم [HtmlOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/) عندما تحتاج إلى التحكم في تخطيط التصدير، الخطوط، الصور، الملاحظات، التعليقات، إخراج SVG، أو الموارد المرتبطة.

يركز هذا الدليل على سيناريوهات تصدير HTML العملية:

- تصدير العرض بالكامل أو شرائح مختارة.
- إنشاء HTML بتخطيط ثابت، أو تصميم متجاوب، أو مبني على SVG.
- تضمين ملاحظات المتحدث والتعليقات.
- التحكم في جودة الصورة وبيانات الصور المقصوصة.
- تضمين الخطوط أو حفظ ملفات الخطوف بشكل منفصل.
- اختيار طريقة كتابة وإحالة الموارد الخارجية وملفات الوسائط.

بشكل افتراضي، ينتج تصدير HTML مستند HTML شامل تُدمج فيه معظم الموارد. هذا مريح لمشاركة ملف واحد، لكنه قد يزيد حجم الناتج. للنشر على الويب، فكر في استخدام موارد خارجية، خفض DPI للصور، وتضمين الخطوط فقط عندما لا تكون متوفرة بشكل موثوق في البيئة المستهدفة.

## **تحويل عرض تقديمي إلى HTML**

لتصدير عرض تقديمي إلى HTML، قم بتحميله باستخدام [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) واحفظه باستخدام [SaveFormat.Html](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/#Html).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

كل مثال يحمل `presentation.pptx` من دليل العمل الحالي. قم بتثبيت Aspose.Slides for Python via Java وبيئة تشغيل Java متوافقة قبل تشغيله. يُبدأ الـ JVM مرة واحدة لكل عملية Python.

هذا المثال يكتب ملف HTML واحد. يتم تحرير كائن العرض في كتلة `finally`، مما يحرر مقابض الملفات وموارد التصيير بعد التصدير.

## **تهيئة تصدير HTML**

[HtmlOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/) هي الفئة الرئيسية لتكوين تصدير HTML. تشمل الإعدادات الشائعة:

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions): يضيف الملاحظات، التعليقات، النشرات، أو معلومات تخطيط أخرى.
- [setHtmlFormatter](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/#setHtmlFormatter): يغيّر بنية مستند HTML أو يفوض التنسيق إلى وحدة تحكم.
- [setSlideImageFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/#setSlideImageFormat): يغيّر طريقة تمثيل الشرائح، مثلًا كـ SVG.
- [setPicturesCompression](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/#setPicturesCompression): يتحكم في DPI الصورة وحجم الناتج.
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas): يحتفظ أو يزيل بيانات الصور المقصوصة.
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout): يجعل محتوى SVG المُصدّر يتكيف مع الحاوية.
- [setShowHiddenSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/#setShowHiddenSlides): يتضمن الشرائح المخفية عند الحاجة.

الأقسام التالية تعرض أكثر الخيارات شيوعًا بشكل منفصل بحيث يمكنك دمج فقط ما يحتاجه سير العمل الخاص بك.

## **تحويل شرائح مختارة إلى HTML**

التحميل الزائد [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) الذي يقبل أرقام الشرائح يستخدم مواضع الشرائح بدءًا من 1. الحلقة أدناه تحفظ كل شريحة في ملف HTML منفصل.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = jpype.JArray(jpype.JInt)([slide_number])
        html_file_name = f"slide-{slide_number}.html"
        presentation.save(html_file_name, slide_numbers, SaveFormat.Html)
finally:
    presentation.dispose()
```

استخدم هذا النمط عندما يحتاج موقع ويب أو تطبيق إلى صفحة HTML واحدة لكل شريحة. إذا كان يجب أن تكون كل شريحة بنفس التخطيط، أنشئ كائنًا واحدًا من [HtmlOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/) ومرره إلى كل استدعاء لـ [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save).

## **إنشاء HTML متجاوب**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ar/python-java/aspose.slides/responsivehtmlcontroller/) يوفر مخرجات HTML متجاوبة عبر [HtmlFormatter](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmlformatter/). استخدمه عندما يجب أن يتكيف الصفّ المُصدّر بشكل أفضل مع عرض المتصفح.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, ResponsiveHtmlController, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    controller = ResponsiveHtmlController()
    formatter = HtmlFormatter.createCustomFormatter(controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

للحصول على تخطيط متجاوب مبني على SVG، استدعِ [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout) مع `True`. هذا مفيد عندما يتم تصدير محتوى الشريحة كعلامة SVG قابلة للتوسع.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setSvgResponsiveLayout(True)

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **تضمين ملاحظات المتحدث والتعليقات**

استخدم [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notescommentslayoutingoptions/) عبر [HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions) لتضمين ملاحظات المتحدث أو التعليقات. تكون الملاحظات والتعليقات مخفية افتراضيًا ما لم تحدد مواضعها.

لنفترض أن العرض الأصلي يحتوي على ملاحظات المتحدث:

![شريحة مع ملاحظات المتحدث في PowerPoint](slide_with_notes.png)

الكود التالي يصدر محتوى الشريحة مع ملاحظات المتحدث أسفل الشريحة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    html_options = HtmlOptions()
    html_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation-with-notes.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

يتضمن HTML المُصدّر منطقة الملاحظات:

![مخرجات HTML مع الشريحة وملاحظات المتحدث](HTML_with_notes.png)

لتصدير التعليقات، استدعِ [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition)، على سبيل المثال مع [CommentsPositions.Right](https://reference.aspose.com/slides/ar/python-java/aspose.slides/commentspositions/#Right) أو [CommentsPositions.Bottom](https://reference.aspose.com/slides/ar/python-java/aspose.slides/commentspositions/#Bottom). إذا كنت بحاجة فقط إلى التعليقات، احذف استدعاء [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). إذا كنت بحاجة إلى كل من الملاحظات والتعليقات، استدعِ الطريقتين.

## **التحكم في جودة الصورة والمساحات المقصوصة**

يمكن لتصدير HTML ضغط صور الشرائح لتقليل حجم الناتج. مرّر قيمة إلى [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/#setPicturesCompression) من [PicturesCompression](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturescompression/) عندما تحتاج إلى جودة صورة أعلى.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, PicturesCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setPicturesCompression(PicturesCompression.Dpi150)

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

بشكل افتراضي، قد يتم إزالة المناطق المقصوصة من الصور في المخرجات المُصدَّرة. احتفظ بالبيانات المقصوصة فقط عندما يجب أن يتمكن المستخدمون من استعادة أو فحص تلك الأجزاء المخفية من الصورة. الإبقاء عليها قد يزيد من حجم HTML.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setDeletePicturesCroppedAreas(False)

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **إضافة CSS**

للتنسيق البسيط، مرّر سلسلة CSS إلى [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmlformatter/#createDocumentFormatter). هذا يغيّر مستند HTML المحيط بينما تستمر Aspose.Slides في تصيير محتوى الشريحة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = HtmlFormatter.createDocumentFormatter(css_rules, True)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-styled.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

لرأس مستند مخصص، ملف CSS مرتبط، أو علامات مخصصة حول الشرائح والأشكال، استخدم وحدة تحكم تنسيق مخصصة عبر وكيل واجهة JPype ومرّرها إلى [HtmlFormatter](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmlformatter/) باستخدام [HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmlformatter/#createCustomFormatter).

## **تضمين الخطوط**

إذا كان من المحتمل أن بيئة الهدف لا تتوفر على خطوط العرض المثبتة، قم بتضمين الخطوط في HTML باستخدام [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ar/python-java/aspose.slides/embedallfontshtmlcontroller/). يرفع التضمين من دقة العرض البصري لكنه يزيد من حجم الناتج.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedAllFontsHtmlController, HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    font_names_to_exclude = jpype.JArray(jpype.JString)(["Arial"])
    font_controller = EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = HtmlFormatter.createCustomFormatter(font_controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

استبعد الخطوط فقط عندما تكون واثقًا أن المتصفحات أو الأنظمة المستهدفة توفرها بالفعل. بالنسبة للخطوط العلامة التجارية أو الخطوط غير الشائعة، يكون التضمين عادةً أكثر أمانًا.

## **حفظ الموارد خارجيًا**

HTML المتضمن ذاتيًا سهل النقل، لكن الموارد المشفرة بـ Base64 يمكن أن تجعل الملف كبيرًا. إذا كان تطبيقك يحتاج إلى ملفات صور خارجية، نفّذ وحدة تحكم ربط الموارد عبر وكيل واجهة JPype ومرّرها إلى مُنشئ [HtmlOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/).

عند تحويل الموارد إلى خارجية، اختر مسارين بعناية:

- مسار مخرجات نظام الملفات، حيث يكتب تطبيقك الصور، الخطوط، الصوت أو الفيديو المُنشأة.
- مسار URL، وهو ما يستخدمه المتصفح من داخل مستند HTML لتحميل تلك الملفات.

## **تصدير ملفات الوسائط**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ar/python-java/aspose.slides/videoplayerhtmlcontroller/) يصدر ملفات الفيديو والصوت ويكتب HTML يمكن تشغيله في المتصفح. يأخذ مُنشئه:

- `path`: الدليل حيث سيتم كتابة ملفات الوسائط المُنشأة.
- `fileName`: اسم ملف HTML الجاري إنشاؤه.
- `baseUri`: بادئة URI مطلقة تُستخدم في روابط HTML لملفات الوسائط.

المثال التالي يصدر وسائط مدمجة مسبقًا في `presentation.pptx`. يربط HTML المُنشأ ملفات الوسائط بالاسم فقط، نسبياً إلى مستند HTML، لذا يجب أن يكون `path` هو الدليل الذي يتلقى أيضًا ملف HTML. يجب أن يكون `baseUri` URI مطلقًا: للمعاينة المحلية، يمكنك بناء URI من نوع `file:///` من دليل الإخراج؛ للتطبيق المنشور، استخدم URL المطلق للدليل المنشور.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SVGOptions, SaveFormat, SlideImageFormat, VideoPlayerHtmlController

from pathlib import Path

output_directory = Path("html-output").resolve()
output_directory.mkdir(parents=True, exist_ok=True)
html_file_name = "presentation.html"
media_base_uri = output_directory.as_uri() + "/"

presentation = Presentation("presentation.pptx")
try:
    controller = VideoPlayerHtmlController(str(output_directory), html_file_name, media_base_uri)
    formatter = HtmlFormatter.createCustomFormatter(controller)
    svg_options = SVGOptions(controller)
    slide_image_format = SlideImageFormat.svg(svg_options)

    html_options = HtmlOptions(controller)
    html_options.setHtmlFormatter(formatter)
    html_options.setSlideImageFormat(slide_image_format)

    html_file_path = output_directory / html_file_name
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

استخدم أدلة إخراج فريدة لكل مهمة تصدير، خاصة في تطبيقات الخادم. يمكن أن تتسبب مسارات الإخراج المشتركة في الكتابة فوق ملفات التحويلات المختلفة.

## **الأداء وإدارة الموارد**

تحويل HTML عملية تصيير، لذا يعتمد زمن المعالجة واستهلاك الذاكرة على عدد الشرائح، دقة الصور، الخطوط، التأثيرات، المخططات، والوسائط المدمجة. القيم الأعلى لـ DPI التي تُمرَّر إلى [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/#setPicturesCompression)، الخطوط المضمَّنة، إخراج SVG، والحفاظ على مناطق الصور المقصوصة يمكن أن تحسن الدقة لكنها عادةً ما ترفع حجم الناتج.

للتحويل على دفعات:

- حرّر كل كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) فورًا.
- استخدم أدلة إخراج منفصلة للمهام المختلفة.
- تجنّب تضمين الخطوط الشائعة ما لم تتطلب الدقة ذلك.
- خفّض DPI الصورة عندما يكون HTML مخصصًا للمعاينة أو للصور المصغرة.
- احتفظ بالعرض الأصلي، HTML المُنشأ، والموارد الخارجية معًا حتى تصبح مسارات النشر نهائية.

## **الأسئلة المتكررة**

**هل تُحافظ الروابط التشعبية في مخرجات HTML؟**

نعم. تُصدَّر روابط العرض إلى HTML وتظل قابلة للنقر عندما يكون عنوان URL الهدف صالحًا.

**هل يمكنني تحويل العروض إلى HTML بشكل متوازي؟**

نعم، لكن لا تشارك كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) واحد عبر الخيوط. عالج ملفات مختلفة باستخدام مثيلات عرض منفصلة، وتدفقات منفصلة، وأدلة إخراج منفصلة. راجع دليل [multithreading guidance](/slides/ar/python-java/multithreading/) للمزيد من التفاصيل.

**هل كائن العرض آمن للاستخدام عبر الخيوط؟**

لا. يجب تحميل وتعديل وحفظ وتحرير كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) على خيط واحد فقط. للعمل المتوازي، أنشئ نسخة مستقلة لكل خيط أو عملية.

**لماذا حجم ملف HTML المُولد كبير؟**

التصدير الافتراضي يمكن أن يدمج الموارد مباشرةً في HTML. الخطوط المدمجة، الصور بدقة DPI عالية، الوسائط، محتوى SVG، والحفاظ على مناطق الصور المقصوصة كلها تزيد من الحجم. استخدم موارد خارجية، استبعد الخطوط الشائعة من التضمين، ومرّر قيمة DPI أقل إلى [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/#setPicturesCompression) عندما يكون حجم الناتج الأصغر أهم من أعلى دقة.

**لماذا قد تختلف قيم حجم الخط في HTML عن قيم PowerPoint؟**

قد يستخدم الصف المُصدَّر أنظمة إحداثيات SVG وتحويلات مقياس. قيمة CSS أو SVG لحجم الخط وحدها لا تصف الحجم النهائي المعروض. قارن الشريحة المصورة عند مستوى التكبير المقصود، وتحقق من توفر الخط إذا ظهر النص مختلفًا.

**كيف ينبغي اختيار baseUri لتصدير الوسائط؟**

اختر `baseUri` من منظور المتصفح ومرره كـ URI مطلق. للمعاينة المحلية، يمكنك اشتقاقه من دليل الإخراج باستخدام `output_directory.as_uri() + "/"`. للنشر، استخدم URL المطلق للدليل المنشور. لا يلزم أن يكون `path` في نظام الملفات و`baseUri` في المتصفح نفس السلسلة، لكنهما يجب أن يصفا نفس الموقع، ويجب أن يكون ذلك الموقع هو الدليل الذي يحتوي على ملف HTML المُولَّد لأن روابط الوسائط تُكتب نسبةً إليه. 

**هل يمكنني تضمين الشرائح المخفية؟**

نعم. استدعِ [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/#setShowHiddenSlides) مع `True` عندما يجب تصدير الشرائح المخفية.