---
title: البحث واستبدال النص في عروض PowerPoint التقديمية باستخدام Python عبر Java
linktitle: البحث واستبدال النص
type: docs
weight: 55
url: /ar/python-java/search-and-replace-text/
keywords:
- بحث نص
- تمييز النص
- استبدال النص
- تعبير نمطي
- رد نداء النتيجة
- إطار النص
- تقرير تدقيق
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "البحث، وتظليل، واستبدال النص في عروض PowerPoint التقديمية مع جمع كل تطابق باستخدام Aspose.Slides for Python via Java."
---
## **نظرة عامة**

Aspose.Slides for Python via Java يمكنه البحث وتظليل واستبدال النص في إطار نص فردي أو عبر العرض التقديمي بأكمله. يمكن لكل عملية أيضًا إبلاغ التطبيق عن كل تطابق من خلال رد نداء النتيجة. وهذا يجعل من الممكن تحديث العرض التقديمي وفي نفس الوقت إنشاء سجل تدقيق يحتوي على النص المتطابق وسياقه وموقعه وإطار النص ورقم الشريحة.

هذه القدرات مفيدة للمراجعة، الحجب، فحص المصطلحات، تنظيف القوالب، وتدفقات العمل للتقارير الآلية.

في الأمثلة الأولى أدناه، نستخدم ملفًا باسم "sample.pptx"، يحتوي على مربع نص واحد في الشريحة الأولى بالنص التالي:

![نص العينة](sample_text.png)

## **اختيار نطاق البحث**

استخدم الطرق على [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) لتحديد عملية لإطار نص واحد. استخدم الطرق على [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) لمعالجة جميع النصوص القابلة للتطبيق في العرض التقديمي.

| العملية | إطار نص واحد | العرض التقديمي كامل |
|---|---|---|
| تمييز النص الحرفي | [TextFrame.highlightText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#highlightText) | [Presentation.highlightText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#highlightText) |
| تمييز مطابقات التعبير النمطي | [TextFrame.highlightRegex](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#highlightRegex) | [Presentation.highlightRegex](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#highlightRegex) |
| استبدال النص الحرفي | [TextFrame.replaceText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#replaceText) | [Presentation.replaceText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#replaceText) |
| استبدال مطابقت التعبير النمطي | [TextFrame.replaceRegex](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#replaceRegex) | [Presentation.replaceRegex](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#replaceRegex) |

## **تهيئة مطابقة النص**

للعمليات التي تتعامل مع نص حرفي، استخدم [TextSearchOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textsearchoptions/) للتحكم في المطابقة:

- [setWholeWordsOnly](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) يحد المطابقات إلى كلمات كاملة.
- [setCaseSensitive](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textsearchoptions/#setCaseSensitive) يتحكم فيما إذا كان يجب مطابقة حالة الأحرف.
- [setIncludeNotes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textsearchoptions/#setIncludeNotes) يضمن تضمين ملاحظات الشرائح في عمليات البحث والاستبدال والتمييز على مستوى العرض التقديمي.

تستخدم عمليات التعبير النمطي كائن Java `Pattern`، لذا فإن قواعد المطابقة مثل حساسية الحالة وحدود الكلمات تُعرّف بواسطة التعبير وعلاماته.

## **تحديد مالك إطار النص**

تستقبل سير عمل معالجة النص العامة عادةً كائنًا من نوع [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) أثناء البحث أو الاستبدال أو التحقق أو التصدير. استخدم [TextFrame.getParentShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#getParentShape) و[TextFrame.getParentCell](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#getParentCell) لتحديد أي كائن في العرض التقديمي يملك إطار النص.

القيم المتوقعة تعتمد على المالك:

| مالك إطار النص | `getParentShape` | `getParentCell` |
|---|---|---|
| شكل [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) أو أي شكل آخر يحتوي على نص | الشكل المالك [Shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/) | `None` |
| خلية جدول | `None` | الخلية المالك [Cell](https://reference.aspose.com/slides/ar/python-java/aspose.slides/cell/) |

كلا الطريقتين توفران تنقلًا للقراءة فقط. استدعاؤهما لا ينقل إطار النص ولا يغيّر مالكه. يجب على الكود العام فحص كلا القيمتين للتأكد من عدم وجود `None` ومعالجة الحالة التي لا يتوفر فيها أي مالك.

المثال التالي يستخدم [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideutil/#getAllTextFrames) للمرور عبر جميع إطارات النص في عرض تقديمي. بالنسبة للأشكال، يُبلغ عن اسم الشكل، نوعه في وقت تشغيل Java، والشريحة الحاوية. بالنسبة لخلايا الجداول، يُبلغ عن إحداثيات العمود والصف (الصفرية) والشريحة الحاوية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

presentation = Presentation("presentation.pptx")
try:
    text_frames = SlideUtil.getAllTextFrames(presentation, False)
    for text_frame in text_frames:
        owner_shape = text_frame.getParentShape()
        owner_cell = text_frame.getParentCell()
        if owner_shape is not None:
            shape_name = str(owner_shape.getName()) or "(unnamed)"
            shape_type = owner_shape.getClass().getSimpleName()
            base_slide = owner_shape.getSlide()
        elif owner_cell is not None:
            base_slide = owner_cell.getSlide()
        else:
            print("The text frame owner is not available as a shape or table cell.")
            continue

        if isinstance(base_slide, Slide):
            slide_label = f"slide {base_slide.getSlideNumber()}"
        elif isinstance(base_slide, NotesSlide):
            slide_label = f"notes for slide {base_slide.getParentSlide().getSlideNumber()}"
        else:
            slide_label = str(base_slide.getClass().getSimpleName())

        if owner_shape is not None:
            print(f"Shape: {shape_name}; type: {shape_type}; {slide_label}")
        else:
            print(f"Table cell: column {owner_cell.getFirstColumnIndex()}, row {owner_cell.getFirstRowIndex()}; {slide_label}")
finally:
    presentation.dispose()
```

بالنسبة لمحتوى SmartArt، يُمرّ عبر الأشكال في [SmartArtNode.getShapes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartartnode/#getShapes) ويُحصل على كل [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartartshape/#getTextFrame). يمكن تتبع إطار النص إلى الشكل المرتبط عبر [TextFrame.getParentShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#getParentShape)، بينما تُعيد [TextFrame.getParentCell](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#getParentCell) `None`. لذلك، يتعامل فرع الشكل في المثال أيضًا مع النص من عقد SmartArt.

## **جمع معلومات التطابق عبر رد نداء**

نفّذ `IFindResultCallback` عبر `jpype.JProxy` لتلقي إشعار عن كل تطابق. يوفر أسلوبه `foundResult` إطار النص ذو الصلة، النص الأصلي، النص المتطابق، وموقع التطابق.

رد النداء لا يحصل على رقم الشريحة مباشرة. يستخرج التنفيذ أدناه رقم الشريحة من الشريحة الأصلية ويتعامل أيضًا مع النص الموجود في ملاحظات الشرائح. يسمح رقم الشريحة الاختياري لنفس نموذج النتيجة بتمثيل النص المرتبط بأنواع شرائح أخرى.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)
```

في عمليات الاستبدال، يحتوي `found_text` على النص الأصلي المتطابق، وبالتالي يمكن لرد النداء تسجيل المصطلحات التي تم استبدالها بالضبط.

## **تمييز النص**

استخدم أسلوب [TextFrame.highlightText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#highlightText) لتظليل مطابقات النص الحرفي في إطار نص. مرّر [TextSearchOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textsearchoptions/) للتحكم في البحث ورد نداء لجمع تفاصيل التطابق.

المثال البرمجي أدناه يظلل جميع تكرارات الأحرف **"try"** ثم يظلل الكلمة الكاملة **"to"** فقط. كلا البحثين يبلغان عن تطابقاتهما إلى نفس رد النداء.

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)

    substring_search_options = TextSearchOptions()
    substring_search_options.setCaseSensitive(False)
    substring_highlight_color = Color(173, 216, 230)

    # تمييز كل ظهور لكلمة "try" في إطار النص.
    shape.getTextFrame().highlightText("try", substring_highlight_color, substring_search_options, callback)

    whole_word_search_options = TextSearchOptions()
    whole_word_search_options.setWholeWordsOnly(True)
    whole_word_search_options.setCaseSensitive(False)
    whole_word_highlight_color = Color(238, 130, 238)

    # تمييز الكلمة الكاملة "to" فقط.
    shape.getTextFrame().highlightText("to", whole_word_highlight_color, whole_word_search_options, callback)

    for result in callback_handler.results:
        print(f"Found '{result.found_text}' at position {result.text_position} on slide {result.slide_number}.")

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![النص المظلل](highlighted_text.png)

## **تمييز النص باستخدام التعابير النمطية**

أسلوب [TextFrame.highlightRegex](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#highlightRegex) يظلل مطابقات النص التي يُعثر عليها عبر تعبير نمطي في إطار نص.

الكود التالي يظلل جميع الكلمات التي تحتوي على سبعة أحرف أو أكثر ويجمع كل تطابق:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)
    regex = Pattern.compile("\\b[^\\s]{7,}\\b")

    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, callback)

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![النص المظلل باستخدام التعبير النمطي](highlighted_text_using_regex.png)

## **تمييز النص عبر العرض التقديمي**

استخدم [Presentation.highlightText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#highlightText) و[Presentation.highlightRegex](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#highlightRegex) للبحث في جميع إطارات النص القابلة للتطبيق في عرض تقديمي. المثال التالي يظلل مصطلحًا حرفيًا وجميع عناوين البريد الإلكتروني مع الحفاظ على مجموعتي نتائج منفصلتين للبحثين.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("presentation.pptx")
try:
    term_callback_handler = TextSearchCallback()
    term_callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=term_callback_handler)
    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(False)

    presentation.highlightText("confidential", Color.ORANGE, search_options, term_callback)

    email_callback_handler = TextSearchCallback()
    email_callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=email_callback_handler)
    email_regex = Pattern.compile("\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b", Pattern.CASE_INSENSITIVE)

    presentation.highlightRegex(email_regex, Color.YELLOW, email_callback)
    presentation.save("highlighted_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **استبدال النص في إطار نص**

استخدم [TextFrame.replaceText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#replaceText) للنص الحرفي و[TextFrame.replaceRegex](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#replaceRegex) للاستبدال القائم على نمط. تقوم هذه الأساليب بتحديث النص المتطابق داخل إطار النص الحالي، مع الحفاظ على تنسيق الجزء المحيط بدلاً من إعادة بناء إطار النص من سلسلة عادية.

المثال التالي يوحد صيغة تهجئة ثم يستبدل تسميات الإصدارات. يسجل نفس رد النداء المصطلحات الأصلية التي طابقها كل من العمليتين.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)
    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(False)

    shape.getTextFrame().replaceText("colour", "color", search_options, callback)

    version_regex = Pattern.compile("\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE)
    shape.getTextFrame().replaceRegex(version_regex, "current version", callback)

    presentation.save("updated_text_frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

إذا امتد أحد التطابقات عبر أقسام ذات تنسيقات مختلفة، راجع الناتج لتأكيد أي تنسيق يجب تطبيقه على النص المستبدل.

## **استبدال النص عبر العرض التقديمي**

استخدم [Presentation.replaceText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#replaceText) و[Presentation.replaceRegex](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#replaceRegex) لتطبيق نفس العمليات عبر العرض التقديمي. هذا مفيد لتنظيف القوالب، تحديث المصطلحات، والحجب.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("presentation.pptx")
try:
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)
    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)

    presentation.replaceText("Contoso", "Example Corp", search_options, callback)

    account_number_regex = Pattern.compile("\\bACCT-\\d{6}\\b")
    presentation.replaceRegex(account_number_regex, "ACCT-REDACTED", callback)

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تجميع التطابقات للتقارير**

نظرًا لأن كل نتيجة تخزن رقم الشريحة وإطار النص، يمكن للتطبيقات تجميع التطابقات للتدقيق أو التقارير أو سير عمل المراجعة. المثال التالي يجمع النتائج المجمّعة أولًا حسب الشريحة ثم حسب إطار النص:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("presentation.pptx")
try:
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)
    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)

    presentation.replaceText("Contoso", "Example Corp", search_options, callback)

    account_number_regex = Pattern.compile("\\bACCT-\\d{6}\\b")
    presentation.replaceRegex(account_number_regex, "ACCT-REDACTED", callback)

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx)
    matches_by_slide = {}
    for result in callback_handler.results:
        matches_by_text_frame = matches_by_slide.setdefault(result.slide_number, {})
        text_frame_matches = matches_by_text_frame.setdefault(result.text_frame, [])
        text_frame_matches.append(result)

    for slide_number, matches_by_text_frame in matches_by_slide.items():
        slide_label = "Other" if slide_number is None else str(slide_number)
        print(f"Slide: {slide_label}")
        for text_frame, results in matches_by_text_frame.items():
            print(f"  Text frame: {text_frame.getText()}")
            for result in results:
                print(f"    '{result.found_text}' at position {result.text_position}; context: '{result.source_text}'")
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**كيف يمكنني البحث في مربع نص واحد فقط بدلاً من كامل العرض التقديمي؟**

احصل على إطار النص الخاص بالشكل واستدعِ [TextFrame.highlightText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#highlightText)، [TextFrame.highlightRegex](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#highlightRegex)، [TextFrame.replaceText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#replaceText) أو [TextFrame.replaceRegex](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#replaceRegex) على ذلك الإطار. تتعامل طرق مستوى العرض التقديمي مع جميع إطارات النص القابلة للتطبيق بدلاً من ذلك.

**كيف يمكنني مطابقة الكلمات الكاملة مع الحالة الصحيحة للأحرف؟**

عيّن `TextSearchOptions.setWholeWordsOnly` و`TextSearchOptions.setCaseSensitive` إلى `True`، ومرّر الخيارات إلى أسلوب التمييز أو الاستبدال للنص الحرفي. بالنسبة للتعبيرات النمطية، عرّف حدود الكلمات وحساسية الحالة في كائن Java `Pattern` نفسه.

**هل يمكن أن تشمل عمليات البحث والاستبدال النص الموجود في ملاحظات الشرائح؟**

نعم. عيّن `TextSearchOptions.setIncludeNotes` إلى `True` عند استخدام عملية نص حرفي على مستوى العرض التقديمي. تنفيذ رد النداء الموضح أعلاه يربط التطابق في شريحة الملاحظات بالرقم الأصلي للشريحة الأم.

**كيف يمكنني إنشاء تقرير دون مسح العرض التقديمي مرة ثانية؟**

مرّر تنفيذًا لـ `IFindResultCallback` إلى عملية التمييز أو الاستبدال. يتلقى رد النداء كل تطابق أثناء تشغيل العملية، ويمكن للتطبيق تخزين النص الأصلي، النص المتطابق، الموقع، إطار النص، ورقم الشريحة المستنتج لتجميعه لاحقًا أو تصديره.

**هل يحافظ استبدال النص على تنسيقه؟**

`TextFrame.replaceText` و`TextFrame.replaceRegex` يعدّلان النص المتطابق داخل إطار النص الحالي ويحتفظان بتنسيق الجزء المحيط. إذا امتد التطابق عبر أقسام ذات تنسيقات مختلفة، افحص النتيجة للتأكد من أن الاستبدال يستخدم النمط المطلوب.