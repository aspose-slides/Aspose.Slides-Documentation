---
title: استخراج النص المتقدم من العروض التقديمية في Python عبر Java
linktitle: استخراج النص
type: docs
weight: 90
url: /ar/python-java/extract-text-from-presentation/
keywords:
- استخراج النص
- استخراج النص من الشريحة
- استخراج النص من العرض التقديمي
- استخراج النص من PowerPoint
- استخراج النص من OpenDocument
- استخراج النص من PPT
- استخراج النص من PPTX
- استخراج النص من ODP
- استرجاع النص
- استرجاع النص من الشريحة
- استرجاع النص من العرض التقديمي
- استرجاع النص من PowerPoint
- استرجاع النص من OpenDocument
- استرجاع النص من PPT
- استرجاع النص من PPTX
- استرجاع النص من ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "استخراج النص بسرعة من عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة Python عبر Java. اتبع دليلنا البسيط خطوة بخطوة لتوفير الوقت."
---
## **نظرة عامة**

استخراج النص من العروض التقديمية هو مهمة شائعة ولكنها أساسية للمطورين الذين يعملون مع محتوى الشرائح. سواء كنت تتعامل مع ملفات Microsoft PowerPoint بصيغة PPT أو PPTX، أو عروض OpenDocument التقديمية (ODP)، فإن الوصول إلى البيانات النصية واسترجاعها قد يكون حيويًا للتحليل، والأتمتة، والفهرسة، أو أغراض نقل المحتوى.

توفر هذه المقالة دليلًا شاملاً حول كيفية استخراج النص بكفاءة من صيغ العروض المختلفة، بما في ذلك PPT وPPTX وODP، باستخدام Aspose.Slides for Python via Java. ستتعلم كيفية iterating عبر عناصر العرض التقديمي بشكل منهجي لاسترجاع محتوى النص الذي تحتاجه بدقة.

## **استخراج النص من شريحة**

توفر Aspose.Slides for Python via Java الفئة [SlideUtil](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideutil/). تكشف هذه الفئة عن عدة طرق ثابتة محملة لاستخراج جميع النصوص من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض تقديمي، استخدم طريقة [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideutil/#getAllTextBoxes). تقبل هذه الطريقة كمعامل كائن من نوع [BaseSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/). عند التنفيذ، تقوم الطريقة بمسح الشريحة بالكامل للبحث عن النص وتعيد مصفوفة من الكائنات من نوع [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/)، مع الحفاظ على أي تنسيق نصي.

المقتطف البرمجي التالي يستخرج جميع النصوص من الشريحة الأولى في العرض التقديمي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

slide_index = 0

presentation = Presentation("demo.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    text_frames = SlideUtil.getAllTextBoxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **استخراج النص من عرض تقديمي**

لمسح النص من كامل العرض التقديمي، استخدم الطريقة الثابتة [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideutil/#getAllTextFrames) التي تُكشف عبر فئة [SlideUtil](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideutil/). تقبل هذه الطريقة معاملين:

1. أولاً، كائن من نوع [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) يمثل عرض PowerPoint أو OpenDocument سيتم استخراج النص منه.
1. ثانياً، قيمة `bool` تشير إلى ما إذا كان يجب تضمين الشرائح الرئيسية عند مسح النص من العرض التقديمي.

تُعيد الطريقة مصفوفة من الكائنات من نوع [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/)، متضمنةً معلومات تنسيق النص. الكود أدناه يمسح النص وتفاصيل التنسيق من عرض تقديمي، بما في ذلك الشرائح الرئيسية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

presentation = Presentation("demo.pptx")
try:
    include_master_slides = True
    text_frames = SlideUtil.getAllTextFrames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **استخراج النص المصنف والسريع**

توفر فئة [PresentationFactory](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationfactory/) أيضًا طرقًا لاستخراج جميع النصوص من العروض التقديمية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationFactory, TextExtractionArrangingMode
from java.io import FileInputStream

mode = TextExtractionArrangingMode.Unarranged
load_options = LoadOptions()

# استخراج النص من ملف.
file_text = PresentationFactory.getInstance().getPresentationText("presentation.pptx", mode)

# استخراج النص من تدفق.
stream = FileInputStream("presentation.pptx")
try:
    stream_text = PresentationFactory.getInstance().getPresentationText(stream, mode)
finally:
    stream.close()

# استخراج النص من تدفق باستخدام خيارات التحميل.
stream_with_options = FileInputStream("presentation.pptx")
try:
    stream_text_with_options = PresentationFactory.getInstance().getPresentationText(stream_with_options, mode, load_options)
finally:
    stream_with_options.close()
```

معامل تعداد [TextExtractionArrangingMode](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textextractionarrangingmode/) يحدد وضع تنظيم نتيجة استخراج النص ويمكن ضبطه على القيم التالية:

- [Unarranged](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textextractionarrangingmode/#Unarranged) - النص الخام دون اعتبار لموقعه على الشريحة.  
- [Arranged](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textextractionarrangingmode/#Arranged) - يُرتب النص بالترتيب نفسه كما هو على الشريحة.

يمكن استخدام وضع unarranged عندما تكون السرعة أمرًا حاسمًا؛ فهو أسرع من وضع arranged.

تمثل الفئة [PresentationText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationtext/) النص الخام المستخرج من العرض التقديمي. تُعيد طريقة [getSlidesText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationtext/#getSlidesText) مصفوفة من الكائنات من نوع `SlideText`. كل كائن يمثل النص على الشريحة المقابلة. يحتوي كائن النوع `SlideText` على الطرق التالية:

- `getText` - النص داخل أشكال الشريحة.  
- `getMasterText` - النص داخل أشكال الشريحة الرئيسية المرتبطة بهذه الشريحة.  
- `getLayoutText` - النص داخل أشكال شريحة التخطيط المرتبطة بهذه الشريحة.  
- `getNotesText` - النص داخل أشكال شريحة الملاحظات المرتبطة بهذه الشريحة.  
- `getCommentsText` - النص داخل التعليقات المرتبطة بهذه الشريحة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, TextExtractionArrangingMode

presentation_path = "presentation.ppt"
arranging_mode = TextExtractionArrangingMode.Unarranged
presentation_text = PresentationFactory.getInstance().getPresentationText(presentation_path, arranging_mode)
first_slide_text = presentation_text.getSlidesText()[0]

print(first_slide_text.getText())
print(first_slide_text.getLayoutText())
print(first_slide_text.getMasterText())
print(first_slide_text.getNotesText())
print(first_slide_text.getCommentsText())
```

## **الأسئلة المتداولة**

**ما مدى سرعة معالجة Aspose.Slides للعروض الكبيرة أثناء استخراج النص؟**

تم تحسين Aspose.Slides للأداء العالي ويمكنه معالجة حتى [العروض الكبيرة](/slides/ar/python-java/open-presentation/)، مما يجعله مناسبًا للسيناريوهات الفورية أو المعالجة الضخمة.

**هل يمكن لـ Aspose.Slides استخراج النص من الجداول والرسوم البيانية داخل العروض؟**

نعم. يمكن لـ Aspose.Slides استخراج النص من العديد من عناصر الشريحة، بما في ذلك الجداول والكائنات المتعلقة بالرسوم البيانية، بحيث يمكنك الوصول إلى المحتوى النصي وتحليله في البُنى الشائعة للعروض التقديمية.

**هل أحتاج إلى ترخيص خاص من Aspose.Slides لاستخراج النص من العروض؟**

يمكنك استخراج النص باستخدام النسخة التجريبية المجانية من Aspose.Slides، رغم أنها ستحمل [بعض القيود](/slides/ar/python-java/licensing/)، مثل معالجة عدد محدود من الشرائح فقط. للحصول على استخدام غير مقيد وللتعامل مع عروض تقديمية أكبر، يُنصح بشراء ترخيص كامل.