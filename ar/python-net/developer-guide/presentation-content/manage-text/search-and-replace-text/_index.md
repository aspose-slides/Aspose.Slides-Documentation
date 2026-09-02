---
title: البحث واستبدال النص في عروض PowerPoint التقديمية باستخدام بايثون
linktitle: بحث واستبدال النص
type: docs
weight: 55
url: /ar/python-net/search-and-replace-text/
keywords:
- بحث النص
- تمييز النص
- استبدال النص
- تعبير نمطي
- إطار النص
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "بحث وتمييز واستبدال النص في عروض PowerPoint التقديمية باستخدام Aspose.Slides for Python عبر .NET."
---
## **نظرة عامة**

Aspose.Slides for Python via .NET يمكنه البحث، وتمييز، واستبدال النص في إطار نص فردي أو عبر كامل العرض التقديمي. تُعد هذه الإمكانيات مفيدة للمراجعة، والإزالة، وفحص المصطلحات، وتنظيف القوالب، وغيرها من سير عمل معالجة المستندات المؤتمتة.

في الأمثلة الأولى أدناه، نستخدم ملفًا باسم “sample.pptx”، يحتوي على مربع نص واحد في الشريحة الأولى مع النص التالي:

![نص العينة](sample_text.png)

## **اختر نطاق البحث**

استخدم الطرق المتوفرة على [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) لتقييد العملية بإطار نص واحد. واستخدم الطرق المتوفرة على [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) لمعالجة جميع النصوص القابلة للمعالجة في العرض التقديمي.

| العملية | إطار نص واحد | العرض التقديمي بالكامل |
|---|---|---|
| تمييز النص الحرفي | [TextFrame.highlight_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/highlight_text/) |
| تمييز التطابقات باستخدام تعبير نمطي | [TextFrame.highlight_regex](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/highlight_regex/) |
| استبدال النص الحرفي | [TextFrame.replace_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/replace_text/) |
| استبدال التطابقات باستخدام تعبير نمطي | [TextFrame.replace_regex](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/replace_regex/) |

## **تكوين مطابقة النص**

للعمليات الحرفية، استخدم [TextSearchOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textsearchoptions/) للتحكم في المطابقة:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textsearchoptions/whole_words_only/) يقتصر على التطابقات التي تكون كلمات كاملة.
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textsearchoptions/case_sensitive/) يتحكم فيما إذا كان يجب مطابقة حالة الأحرف.
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textsearchoptions/include_notes/) يضم ملاحظات الشرائح في عمليات البحث والاستبدال والتمييز على مستوى العرض التقديمي.

العمليات التي تعتمد على التعبيرات النمطية تستخدم سلسلة نمط، وبالتالي يتم تعريف قواعد المطابقة مثل حساسية الحالة وحدود الكلمات داخل التعبير نفسه.

## **تحديد مالك إطار النص**

غالبًا ما تتلقى سير عمل معالجة النص العامة كائنًا من [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) أثناء البحث أو الاستبدال أو التحقق أو التصدير. استخدم [TextFrame.parent_shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/parent_shape/) و[TextFrame.parent_cell](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/parent_cell/) لتحديد أي كائن عرض تقديمي يملك إطار النص.

القيم المتوقعة تعتمد على المالك:

| مالك إطار النص | `parent_shape` | `parent_cell` |
|---|---|---|
| AutoShape أو شكل آخر يحتوي على نص | الشكل المالك [Shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/) | `None` |
| خلية جدول | `None` | الخلية المالكة [Cell](https://reference.aspose.com/slides/ar/python-net/aspose.slides/cell/) |

كلا الخاصيتين عبارة عن خصائص تنقل للقراءة فقط. لا تُحرك قراءة هذه الخصائص إطار النص ولا تُغيّر مالكه. يجب على الشيفرة العامة فحص القيمتين ضد `None` ومعالجة احتمال عدم توفر أي من المالكين.

المثال التالي يستخدم [SlideUtil.get_all_text_frames](https://reference.aspose.com/slides/ar/python-net/aspose.slides.util/slideutil/get_all_text_frames/) للمرور عبر جميع إطارات النص في عرض تقديمي. بالنسبة للأشكال، يُظهر اسم الشكل، ونوعه في وقت تشغيل بايثون، والشرائح التي يحتويها. بالنسبة لخلايا الجداول، يُظهر إحداثيات العمود والصف بدءًا من الصفر والشرائح المضمنة.

```python
import aspose.slides as slides


def get_slide_label(base_slide):
    if isinstance(base_slide, slides.Slide):
        return f"slide {base_slide.slide_number}"

    if isinstance(base_slide, slides.NotesSlide):
        return f"notes for slide {base_slide.parent_slide.slide_number}"

    return type(base_slide).__name__


with slides.Presentation("presentation.pptx") as presentation:
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, False)

    for text_frame in text_frames:
        owner_shape = text_frame.parent_shape
        if owner_shape is not None:
            shape_name = owner_shape.name or "(unnamed)"
            shape_type = type(owner_shape).__name__
            slide_label = get_slide_label(owner_shape.slide)
            print(f"Shape: {shape_name}; type: {shape_type}; {slide_label}")
            continue

        owner_cell = text_frame.parent_cell
        if owner_cell is not None:
            slide_label = get_slide_label(owner_cell.slide)
            print(f"Table cell: column {owner_cell.first_column_index}, row {owner_cell.first_row_index}; {slide_label}")
            continue

        print("The text frame owner is not available as a shape or table cell.")
```

للمحتوى في SmartArt، مر عبر الأشكال في [SmartArtNode.shapes](https://reference.aspose.com/slides/ar/python-net/aspose.slides.smartart/smartartnode/shapes/) وادخل إلى كل [ISmartArtShape.text_frame](https://reference.aspose.com/slides/ar/python-net/aspose.slides.smartart/ismartartshape/text_frame/). يمكن تتبع إطار النص إلى الشكل المرتبط من خلال [TextFrame.parent_shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/parent_shape/)، بينما [TextFrame.parent_cell](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/parent_cell/) تكون `None`. لذلك يتعامل فرع الشكل في المثال أيضًا مع النص من عقد SmartArt.

## **تمييز النص**

استخدم الطريقة [TextFrame.highlight_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/highlight_text/) لتمييز التطابقات الحرفية في إطار نص. مرر كائنًا من [TextSearchOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textsearchoptions/) للتحكم في البحث.

تُظهر عينة الشيفرة أدناه كيفية تمييز جميعOccurrences من الأحرف **"try"** ثم تمييز الكلمة الكاملة **"to"** فقط.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # تمييز كل حدوث لكلمة "try" في إطار النص.
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # تمييز الكلمة الكاملة فقط "to".
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![النص المميز](highlighted_text.png)

## **تمييز النص باستخدام التعبيرات النمطية**

الطريقة [TextFrame.highlight_regex](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/highlight_regex/) تُمّيز التطابقات التي يجدها تعبير نمطي داخل إطار نص.

الشيفرة التالية تقوم بتمييز جميع الكلمات التي تحتوي على سبعة أحرف أو أكثر:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    word_pattern = r"\b[^\s]{7,}\b"

    shape.text_frame.highlight_regex(word_pattern, draw.Color.yellow, None)

    presentation.save(
        "highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX
    )
```

النتيجة:

![النص المميز باستخدام التعبير النمطي](highlighted_text_using_regex.png)

## **تمييز النص عبر العرض التقديمي**

استخدم [Presentation.highlight_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/highlight_text/) و[Presentation.highlight_regex](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/highlight_regex/) للبحث في جميع إطارات النص القابلة للمعالجة في العرض التقديمي. المثال التالي يميز مصطلحًا حرفيًا وجميع عناوين البريد الإلكتروني:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    presentation.highlight_text(
        "confidential", draw.Color.orange, search_options, None
    )

    email_pattern = r"(?i)\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b"
    presentation.highlight_regex(email_pattern, draw.Color.yellow)

    presentation.save(
        "highlighted_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **استبدال النص في إطار النص**

استخدم [TextFrame.replace_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/replace_text/) للنص الحرفي و[TextFrame.replace_regex](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/replace_regex/) للاستبدال القائم على النمط. تُحدّث هذه الطرق النص المطابق داخل إطار النص الموجود، مع الحفاظ على تنسيق الجزء المحيط بدلاً من إعادة بناء إطار النص من سلسلة نصية عادية.

المثال التالي يُوحّد شكل كتابة كلمة معينة ثم يستبدل تسميات الإصدارات:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    shape.text_frame.replace_text(
        "colour", "color", search_options, None
    )

    version_pattern = r"(?i)\bv\d+(?:\.\d+)*\b"
    shape.text_frame.replace_regex(version_pattern, "current version")

    presentation.save(
        "updated_text_frame.pptx", slides.export.SaveFormat.PPTX
    )
```

إذا امتد تطابق إلى أجزاء ذات تنسيقات مختلفة، راجع الناتج لتأكيد أي تنسيق يجب أن يُطبق على النص المستبدل.

## **استبدال النص عبر العرض التقديمي**

استخدم [Presentation.replace_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/replace_text/) و[Presentation.replace_regex](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/replace_regex/) لتطبيق نفس العمليات على مستوى العرض التقديمي بأكمله. هذا مفيد لتنظيف القوالب، وتحديث المصطلحات، والإزالة.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True

    presentation.replace_text(
        "Contoso", "Example Corp", search_options, None
    )

    account_number_pattern = r"\bACCT-\d{6}\b"
    presentation.replace_regex(account_number_pattern, "ACCT-REDACTED")

    presentation.save(
        "updated_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **الأسئلة المتداولة**

**كيف يمكنني البحث في مربع نص واحد فقط بدلاً من كامل العرض التقديمي؟**

احصل على إطار النص الخاص بالشكل واستدعِ [TextFrame.highlight_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/highlight_text/)، [TextFrame.highlight_regex](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/highlight_regex/)، [TextFrame.replace_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/replace_text/)، أو [TextFrame.replace_regex](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/replace_regex/) على ذلك الإطار. تُعالج طرق مستوى العرض التقديمي جميع إطارات النص القابلة للمعالجة بدلاً من ذلك.

**كيف يمكنني مطابقة الكلمات الكاملة مع الحفاظ على حالة الأحرف الصحيحة؟**

عيّن [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textsearchoptions/whole_words_only/) و[TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textsearchoptions/case_sensitive/) إلى `True`، ومرّر الخيارات إلى طريقة تمييز أو استبدال النص الحرفي. بالنسبة للتعبيرات النمطية، عرف حدود الكلمات وحساسية الحالة داخل النمط نفسه.

**هل يمكن أن تشمل عمليات البحث والاستبدال النص الموجود في ملاحظات الشرائح؟**

نعم. عيّن [TextSearchOptions.include_notes](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textsearchoptions/include_notes/) إلى `True` عند استخدام عملية حرفية على مستوى العرض التقديمي.

**هل يحافظ استبدال النص على تنسيقه؟**

[TextFrame.replace_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/replace_text/) و[TextFrame.replace_regex](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/replace_regex/) يغيّران النص المطابق داخل إطار النص الموجود مع الحفاظ على تنسيق الجزء المحيط. إذا امتد التطابق إلى أجزاء ذات تنسيقات مختلفة، فافحص النتيجة للتأكد من أن الاستبدال يستخدم النمط المطلوب.