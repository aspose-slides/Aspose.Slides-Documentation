---
title: البحث واستبدال النص في عروض PowerPoint التقديمية باستخدام بايثون
linktitle: البحث واستبدال النص
type: docs
weight: 55
url: /ar/python-net/search-and-replace-text/
keywords:
- بحث نص
- تمييز نص
- استبدال نص
- تعبير نمطي
- إطار نص
- PowerPoint
- OpenDocument
- عرض تقديمي
- بايثون
- Aspose.Slides
description: "ابحث، ظلل، واستبدل النص في عروض PowerPoint التقديمية باستخدام Aspose.Slides for Python عبر .NET."
---
## **نظرة عامة**

Aspose.Slides for Python via .NET يمكنه البحث عن النص وتظليله واستبداله في إطار نصي فردي أو عبر العرض التقديمي بأكمله. تُعدّ هذه القدرات مفيدة للمراجعة، وإزالة المعلومات الحساسة، وفحص المصطلحات، وتنظيف القوالب، وغيرها من سير عمل معالجة المستندات الآلية.

في الأمثلة الأولى أدناه، نستخدم ملفًا اسمه "sample.pptx"، يحتوي على صندوق نص واحد في الشريحة الأولى بالنص التالي:

![نص العينة](sample_text.png)

## **اختر نطاق البحث**

استخدم الأساليب على [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) لتحديد عملية لإطار نص واحد. واستخدم الأساليب على [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) لمعالجة جميع النصوص القابلة للتطبيق في العرض التقديمي.

| العملية | إطار نص واحد | العرض التقديمي كامل |
|---|---|---|
| تمييز النص الحرفي | [TextFrame.highlight_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/highlight_text/) |
| تمييز مطابقة التعابير النمطية | [TextFrame.highlight_regex](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/highlight_regex/) |
| استبدال النص الحرفي | [TextFrame.replace_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/replace_text/) |
| استبدال مطابقة التعابير النمطية | [TextFrame.replace_regex](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/replace_regex/) |

## **تكوين مطابقة النص**

للعمليات التي تعتمد على النص الحرفي، استخدم [TextSearchOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textsearchoptions/) للتحكم في المطابقة:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textsearchoptions/whole_words_only/) يحدّ المطابقات إلى الكلمات الكاملة.
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textsearchoptions/case_sensitive/) يتحكم فيما إذا كان يجب مطابقة حالة الأحرف.
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textsearchoptions/include_notes/) يشمل ملاحظات الشرائح في عمليات البحث والاستبدال والتمييز على مستوى العرض التقديمي.

تستخدم عمليات التعابير النمطية سلسلة نمط، لذا تُحدَّد قواعد المطابقة مثل حساسية الحالة وحدود الكلمات داخل التعبير نفسه.

## **تمييز النص**

استخدم طريقة [TextFrame.highlight_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/highlight_text/) لتظليل التطابقات النصية الحرفية في إطار نص. مرّر [TextSearchOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textsearchoptions/) للتحكم في البحث.

مثال الشيفرة أدناه يبرز جميع تكرارات الأحرف **"try"** ثم يبرز فقط الكلمة الكاملة **"to"**.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # تمييز كل ظهور لكلمة "try" في إطار النص.
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # تمييز الكلمة الكاملة "to" فقط.
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![النص المميز](highlighted_text.png)

## **تمييز النص باستخدام التعابير النمطية**

طريقة [TextFrame.highlight_regex](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/highlight_regex/) تبرز التطابقات النصية التي يتم العثور عليها عبر تعبير نمطي في إطار نص.

الشيفرة التالية تبرز جميع الكلمات التي تحتوي على سبعة أحرف أو أكثر:

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

استخدم [Presentation.highlight_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/highlight_text/) و[Presentation.highlight_regex](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/highlight_regex/) للبحث في جميع إطارات النص القابلة للتطبيق في العرض التقديمي. المثال التالي يبرز مصطلحًا حرفيًا وجميع عناوين البريد الإلكتروني:

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

## **استبدال النص في إطار نص**

استخدم [TextFrame.replace_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/replace_text/) للنص الحرفي و[TextFrame.replace_regex](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/replace_regex/) للاستبدال القائم على النمط. تقوم هذه الأساليب بتحديث النص المطابق داخل إطار النص الحالي، مع الحفاظ على تنسيق الجزء المحيط بدلاً من إنشاء إطار نص جديد من سلسلة نصية عادية.

المثال التالي يموّج متغير تهجئة ثم يستبدل تسميات الإصدارات:

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

إذا امتدت إحدى المطابقات على أجزاء ذات تنسيقات مختلفة، راجع الإخراج لتأكيد أي تنسيق يجب تطبيقه على النص المستبدل.

## **استبدال النص عبر العرض التقديمي**

استخدم [Presentation.replace_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/replace_text/) و[Presentation.replace_regex](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/replace_regex/) لتطبيق نفس العمليات عبر العرض التقديمي. هذا مفيد لتنظيف القوالب، وتحديث المصطلحات، وإزالة المعلومات الحساسة.

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

## **الأسئلة الشائعة**

**كيف يمكنني البحث في صندوق نص واحد فقط بدلاً من العرض التقديمي بأكمله؟**

احصل على إطار النص الخاص بالشكل واستدعِ [TextFrame.highlight_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/highlight_text/)، [TextFrame.highlight_regex](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/highlight_regex/)، [TextFrame.replace_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/replace_text/)، أو [TextFrame.replace_regex](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/replace_regex/) على ذلك الإطار. تقوم الأساليب على مستوى العرض التقديمي بمعالجة جميع إطارات النص القابلة للتطبيق بدلاً من ذلك.

**كيف يمكنني مطابقة الكلمات الكاملة مع حالة الأحرف الصحيحة؟**

عيّن [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textsearchoptions/whole_words_only/) و[TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textsearchoptions/case_sensitive/) إلى `True`، ومرّر الخيارات إلى طريقة تمييز أو استبدال النص الحرفي. بالنسبة للتعابير النمطية، عرّف حدود الكلمات وحساسية الحالة داخل النمط نفسه.

**هل يمكن أن تشمل عمليات البحث والاستبدال النص الموجود في ملاحظات الشرائح؟**

نعم. عيّن [TextSearchOptions.include_notes](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textsearchoptions/include_notes/) إلى `True` عند استخدام عملية نصية حرفية على مستوى العرض التقديمي.

**هل يحافظ استبدال النص على تنسيقه؟**

[TextFrame.replace_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/replace_text/) و[TextFrame.replace_regex](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/replace_regex/) يغيّران النص المطابق داخل إطار النص الحالي ويحتفظان بتنسيق الجزء المحيط. إذا امتدت المطابقة على أجزاء ذات تنسيقات مختلفة، راجع النتيجة للتأكد من أن الاستبدال يستخدم النمط المطلوب.