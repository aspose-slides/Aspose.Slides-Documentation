---
title: تحويل عروض PowerPoint إلى HTML باستخدام Python عبر Java
linktitle: PowerPoint إلى HTML
type: docs
weight: 30
url: /ar/python-java/convert-powerpoint-to-html/
keywords:
- تحويل PowerPoint
- تحويل العرض
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى HTML
- العرض إلى HTML
- الشريحة إلى HTML
- PPT إلى HTML
- PPTX إلى HTML
- حفظ PowerPoint كـ HTML
- حفظ العرض كـ HTML
- حفظ الشريحة كـ HTML
- حفظ PPT كـ HTML
- حفظ PPTX كـ HTML
- تصدير PPT إلى HTML
- تصدير PPTX إلى HTML
- Python
- Java
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى HTML باستخدام Python عبر Java. استخدم Aspose.Slides لتصدير ملفات PPT وPPTX، الشرائح المحددة، الملاحظات، الخطوط، الصور، SVG، والوسائط."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Python via Java حفظ عروض PowerPoint كملفات HTML دون الحاجة إلى Microsoft PowerPoint. التحويل الأساسي هو تحميل [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) واحد وإجراء نداء [save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) باستخدام [SaveFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/). استخدم [HtmlOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/) عندما تحتاج إلى التحكم في تخطيط التصدير، الخطوط، الصور، الملاحظات، التعليقات، مخرجات SVG، أو الموارد المرتبطة.

تركز هذه الدليل على سيناريوهات تصدير HTML العملية:

- تصدير العرض بالكامل أو الشرائح المحددة.
- إنشاء HTML ثابت التخطيط، أو متجاوب، أو معتمد على SVG.
- تضمين ملاحظات المتحدث والتعليقات.
- التحكم في جودة الصورة ومناطق الصورة المقصوصة.
- تضمين الخطوط أو حفظ ملفات الخطوط منفصلة.
- اختيار طريقة كتابة وإشارة الموارد والملفات الإعلامية الخارجية.

بشكل افتراضي، ينتج تصدير HTML مستند HTML ذاتي الاحتواء حيث تُدمج معظم الموارد. هذا ملاءم لمشاركة ملف واحد، لكنه قد يزيد حجم المخرجات. للنشر على الويب، ضع في اعتبارك الموارد الخارجية، خفض DPI للصور، وتضمين الخطوط فقط عندما لا تكون متوفرة بموثوقية في البيئة المستهدفة.

## **تحويل عرض إلى HTML**

لتصدير عرض إلى HTML، حمّله باستخدام [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) واحفظه باستخدام [SaveFormat.Html](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/#Html).

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

كل مثال يحمل `presentation.pptx` من دليل العمل الحالي. ثبّت Aspose.Slides for Python via Java وبيئة تشغيل Java متوافقة قبل تشغيله. تُبدأ JVM مرة واحدة لكل عملية Python.

يكتب هذا المثال ملف HTML واحد. يتم التخلص من كائن العرض في كتلة `finally`، مما يحرّر مقبض الملف وموارد التصيير بعد التصدير.

## **تكوين تصدير HTML**

[HtmlOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/) هي الفئة الرئيسية لتكوين تصدير HTML. تشمل الإعدادات الشائعة:

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions): يضيف الملاحظات، التعليقات، النسخ الموزعة، أو معلومات تخطيط أخرى.
- [setHtmlFormatter](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/#setHtmlFormatter): يغيّر بنية مستند HTML أو يُفوّض التنسيق إلى متحكم.
- [setSlideImageFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/#setSlideImageFormat): يغيّر طريقة تمثيل الشرائح، على سبيل المثال كـ SVG.
- [setPicturesCompression](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/#setPicturesCompression): يتحكم في DPI الصورة وحجم المخرجات.
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas): يبقي أو يزيل بيانات الصور المقصوصة.
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout): يجعل محتوى SVG المصدّر يتكيف مع حاويته.
- [setShowHiddenSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/#setShowHiddenSlides): يتضمن الشرائح المخفية عند الحاجة.

تظهر الأقسام التالية أكثر الخيارات شيوعًا بشكل منفصل حتى تتمكن من دمج ما تحتاجه فقط في تدفق عملك.

## **تحويل الشرائح المحددة إلى HTML**

يتقبل التحميل الزائد لـ [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) أرقام الشرائح باستخدام مواضع 1‑based. الحلقة أدناه تحفظ كل شريحة في ملف HTML منفصل.

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

استخدم هذا النمط عندما يحتاج موقع ويب أو تطبيق إلى صفحة HTML واحدة لكل شريحة. إذا كان يجب أن تكون كل شريحة ذات تخطيط موحَّد، أنشئ كائن [HtmlOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/) واحدًا ومرره إلى كل استدعاء لـ [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save).

## **إنشاء HTML متجاوب**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ar/python-java/aspose.slides/responsivehtmlcontroller/) يُوفر مخرجات HTML متجاوبة عبر [HtmlFormatter](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmlformatter/). استخدمه عندما يجب أن تتكيف الصفحة المصدَّرة بشكل أفضل مع عرض المتصفح.

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

للتخطيط المتجاوب المعتمد على SVG، استدعِ [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout) مع `True`. هذا مفيد عندما يُصدَّر محتوى الشريحة كعلامات SVG قابلة للتوسيع.

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

افترض أن العرض المصدر يحتوي على ملاحظات المتحدث:

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

يَتضمن HTML المصدَّر منطقة الملاحظات:

![إخراج HTML مع الشريحة وملاحظات المتحدث](HTML_with_notes.png)

لتصدير التعليقات، استدعِ [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition)، على سبيل المثال مع [CommentsPositions.Right](https://reference.aspose.com/slides/ar/python-java/aspose.slides/commentspositions/#Right) أو [CommentsPositions.Bottom](https://reference.aspose.com/slides/ar/python-java/aspose.slides/commentspositions/#Bottom). إذا كنت تحتاج فقط إلى تعليقات، احذف استدعاء [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). إذا كنت تحتاج كلًا من الملاحظات والتعليقات، استدعِ الطريقتين.

## **التحكم في جودة الصورة والمناطق المقصوصة**

يمكن لتصدير HTML ضغط صور الشرائح لتقليل حجم المخرجات. مرِّر قيمة إلى [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/#setPicturesCompression) من [PicturesCompression](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturescompression/) عندما تحتاج جودة صورة أعلى.

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

افتراضيًا، قد تُزيل المناطق المقصوصة من الصور في المخرجات المصدَّرة. احتفظ بالبيانات المقصوصة فقط عندما يحتاج المستخدمون إلى استعادة أو فحص تلك الأجزاء المخفية من الصورة. الاحتفاظ بها قد يزيد من حجم HTML.

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

للتنسيق البسيط، مرِّر سلسلة CSS إلى [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmlformatter/#createDocumentFormatter). يغيّر ذلك مستند HTML المحيط بينما يواصل Aspose.Slides تصيير محتوى الشريحة.

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

لرأس مستند مخصص، ملف CSS مرتبط، أو علامات مخصصة حول الشرائح والأشكال، استخدم متحكم تنسيق مخصص عبر وكيل واجهة JPype ومرره إلى [HtmlFormatter](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmlformatter/) باستخدام [HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmlformatter/#createCustomFormatter).

## **تضمين الخطوط**

إذا كان من المحتمل أن البيئة المستهدفة لا تحتوي على خطوط العرض المثبتة، قم بتضمين الخطوط في HTML باستخدام [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ar/python-java/aspose.slides/embedallfontshtmlcontroller/). يُحسّن التضمين من دقة العرض البصري لكنه يزيد من حجم المخرجات.

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

استثنِ الخطوط فقط عندما تكون متأكدًا من أن المتصفحات أو الأنظمة المستهدفة توفرها بالفعل. بالنسبة للخطوط العلامية أو الخطوط الأقل شيوعًا، يكون التضمين عادةً أكثر أمانًا.

## **حفظ الموارد خارجيًا**

HTML ذاتي الاحتواء سهل النقل، لكن الموارد المشفرة بقاعدة64 قد تجعل الملف كبيرًا. إذا كان تطبيقك يحتاج ملفات صور خارجية، نفّذ متحكم ربط موارد عبر وكيل واجهة JPype ومرره إلى مُنشئ [HtmlOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/).

عند جعل الموارد خارجية، اختر مسارين بصورة متعمدة:

- مسار إخراج نظام الملفات، حيث يكتب تطبيقك الصور، الخطوط، الصوت، أو الفيديو المولَّدة.
- مسار URL، وهو ما يستخدمه المتصفح من مستند HTML لتحميل تلك الملفات.

## **تصدير ملفات الوسائط**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ar/python-java/aspose.slides/videoplayerhtmlcontroller/) يصدر ملفات الفيديو والصوت ويكتب HTML يمكنه تشغيلها في المتصفح. يأخذ مُنشئه:

- `path`: الدليل الذي ستُكتب فيه ملفات الوسائط المولَّدة.
- `fileName`: اسم ملف HTML الجاري توليده.
- `baseUri`: بادئة URI المطلقة المستخدمة في روابط HTML إلى ملفات الوسائط.

المثال التالي يصدر وسائل تم تضمينها مسبقًا في `presentation.pptx`. يُشير HTML المولَّد إلى ملفات الوسائط بالاسم فقط، نسبةً إلى مستند HTML، لذا يجب أن يكون `path` هو الدليل الذي يُستقبل فيه أيضًا ملف HTML. يجب أن يكون `baseUri` URI مطلقًا: للمعاينة المحلية، كوّن URI من نوع `file:///` من دليل الإخراج؛ للتطبيق المنشور، استخدم URL المطلق للدليل المنشور.

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

استخدم أدلة إخراج فريدة لكل مهمة تصدير، خاصة في تطبيقات الخادم. قد تؤدي المسارات المشتركة إلى استبدال ملفات التحويلات المختلفة بعضها ببعض.

## **الأداء وإدارة الموارد**

تحويل HTML عملية تصيير، لذا يعتمد زمن المعالجة واستهلاك الذاكرة على عدد الشرائح، دقة الصور، الخطوط، التأثيرات، المخططات، والوسائط المضمنة. القيم الأعلى لـ DPI التي تُمرَّر إلى [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/#setPicturesCompression)، الخطوط المضمَّنة، مخرجات SVG، ومناطق الصور المقصوصة المحتفظ بها يمكن أن تحسِّن الدقة لكنها عادةً ما تزيد من حجم المخرجات.

للتحويل على دفعات:

- تخلّص من كل كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) فورًا.
- استخدم أدلة إخراج منفصلة للوظائف المختلفة.
- تجنّب تضمين الخطوط الشائعة ما لم تتطلب الدقة ذلك.
- اخفض DPI للصور عندما يكون HTML مخصصًا للمعاينة أو المصغرات.
- حافظ على العرض الأصلي، HTML المولَّد، والموارد الخارجية معًا حتى تصبح مسارات النشر نهائية.

## **الأسئلة المتكررة**

**هل يتم الحفاظ على الروابط التشعبية في مخرجات HTML؟**

نعم. تُصدَّر روابط العرض إلى HTML وتظل قابلة للنقر عندما يكون عنوان URL المستهدف صالحًا.

**هل يمكنني تحويل العروض إلى HTML بشكل متوازي؟**

نعم، لكن لا تشارك كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) واحد عبر الخيوط. عالج ملفات مختلفة باستخدام كائنات عرض منفصلة، وتيارات منفصلة، وأدلة إخراج منفصلة. راجع دليل [multithreading guidance](/slides/ar/python-java/multithreading/) للمزيد من التفاصيل.

**هل كائن العرض آمن للاستخدام من عدة خيوط؟**

لا. يجب تحميل، تعديل، حفظ، وتخلّص من كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) واحد على خيط واحد فقط. للعمل المتوازي، أنشئ كائنًا مستقلاً لكل خيط أو عملية.

**لماذا يكون ملف HTML المولَّد كبيرًا؟**

التحويل الافتراضي قد يدمج الموارد مباشرةً في HTML. الخطوط المضمنة، الصور ذات DPI العالي، الوسائط، محتوى SVG، ومناطق الصور المقصوصة المحتفظ بها كلها تزيد من الحجم. استخدم موارد خارجية، استثنِ الخطوط الشائعة من التضمين، ومرّر قيمة DPI أقل إلى [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/#setPicturesCompression) عندما يكون حجم المخرج الصغير أهم من أقصى دقة.

**لماذا قد تختلف قيم حجم الخط في HTML عن قيم PowerPoint؟**

قد تستخدم الصفحة المصدَّرة أنظمة إحداثيات SVG وتحويلات مقياس. قيمة CSS أو SVG الخام لحجم الخط لا تصف الحجم النهائي المعروض. قارن الشريحة المصورة عند مستوى التكبير المقصود، وتحقق من توفر الخط إذا كان النص يبدوا مختلفًا.

**كيف يجب اختيار baseUri لتصدير الوسائط؟**

اختر `baseUri` من وجهة نظر المتصفح ومرره كـ URI مطلق. للمعاينة المحلية، يمكنك اشتقاقه من دليل الإخراج باستخدام `output_directory.as_uri() + "/"`. للنشر، استخدم URL المطلق للدليل المنشور. لا يلزم أن تكون سلسلة نظام الملفات `path` و `baseUri` متطابقتين، لكنهما يجب أن يصفا الموقع نفسه، ويجب أن يكون هذا الموقع هو الدليل الذي يحتوي على ملف HTML المولَّد لأن روابط الوسائط تُكتب نسبيةً إليه.

**هل يمكنني تضمين الشرائح المخفية؟**

نعم. استدعِ [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/#setShowHiddenSlides) مع `True` عندما يجب تصدير الشرائح المخفية.