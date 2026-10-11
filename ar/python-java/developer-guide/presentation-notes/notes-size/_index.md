---
title: تغيير حجم صفحة الملاحظات واتجاهها في بايثون عبر جافا
linktitle: حجم صفحة الملاحظات
type: docs
weight: 10
url: /ar/python-java/notes-size/
keywords:
- حجم صفحة الملاحظات
- اتجاه الملاحظات
- ملاحظات أفقية
- ملاحظات رأسية
- حجم الكتيب
- PowerPoint
- عرض تقديمي
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "قراءة وتغيير أبعاد صفحة الملاحظات في Aspose.Slides لبايثون عبر جافا، تغيير الاتجاه، التحقق من الأحجام المحفوظة، وتصدير الملاحظات أو الكتيبات إلى PDF والصور."
---
## **نظرة عامة**

استخدم [Presentation.getNotesSize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getNotesSize) للوصول إلى إعدادات صفحة الملاحظات في العرض التقديمي. تُعيد كائنًا من نوع [NotesSize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notessize/) حيث تقوم طريقة [setSize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notessize/#setSize) بتعيين أبعاد الصفحة. على الرغم من أنه لا يمكن استبدال كائن الإعدادات نفسه، يمكنك تعيين أبعاد جديدة عبر هذه الطريقة.

يتم تحديد العرض والارتفاع بوحدة **النقطة**، حيث توجد 72 نقطة لكل بوصة. على سبيل المثال، 900 × 600 نقطة يساوي 12.5 × 8⅓ بوصة. تنطبق هذه الإعدادات على العرض التقديمي ككل، وليس على ملاحظات شريحة فردية.

| الإعداد | الغرض |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getNotesSize) | يتحكم في أبعاد صفحة الملاحظات وأبعاد الصفحة المستخدمة لتصدير الكتيبات. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSlideSize) | يتحكم في أبعاد شرائح العرض التقديمي العادية عبر [SlideSize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidesize/). |

تغيير أي من الإعدادين لا يغيّر الآخر تلقائيًا. تغيير اتجاه صفحة الملاحظات لا يدور أيضًا الشرائح العادية. راجع [Slide Size](/slides/ar/python-java/slide-size/) لتغيير حجم الشرائح العادية.

تستخدم الأمثلة أدناه ملف `sample.pptx` موجود مسبقًا. لأمثلة التصدير، استخدم عرضًا تقديميًا يحتوي على شريحة واحدة على الأقل تتضمن ملاحظات المتحدث. يمكن تشغيل كل مثال بشكل مستقل.

## **قراءة حجم واتجاه صفحة الملاحظات**

اقرأ العرض والارتفاع وقارنهما لتحديد الاتجاه: الصفحة الأعرض هي أفقية، والصفحة الأطول هي رأسية، والأبعاد المتساوية تصف صفحة مربعة. يطبع هذا المثال الأبعاد الفعلية بالنقاط، دون افتراض حجم ورق قياسي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()
    orientation = "Square"

    if size.getWidth() > size.getHeight():
        orientation = "Landscape"
    elif size.getWidth() < size.getHeight():
        orientation = "Portrait"

    print(f"Notes page: {size.getWidth()} x {size.getHeight()} points")
    print(f"Orientation: {orientation}")
finally:
    presentation.dispose()
```

## **التبديل إلى الوضع الأفقي دون تغيير حجم الورق**

لتغيير الاتجاه فقط، قم بتبديل العرض والارتفاع الحاليين. هذا يحافظ على أطوال الجانبين، بما في ذلك تلك الخاصة بحجم ورق مخصص. الشرط أدناه يمنع تحويل صفحة أفقية بالفعل إلى وضع رأسي ويترك الصفحات المربعة دون تغيير.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()

    if size.getWidth() < size.getHeight():
        width = size.getWidth()
        size.setSize(size.getHeight(), width)
        presentation.getNotesSize().setSize(size)

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

للوضع الرأسي، استخدم نفس التعيين عندما `size.getWidth() > size.getHeight()`. لا تستبدل أبعاد A4 أو Letter إلا إذا كنت تريد أيضًا تغيير حجم الورق.

## **تعيين والتحقق من حجم صفحة ملاحظات مخصص**

قم بتعيين كلا البعدين معًا، ثم استخدم [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) لكتابة العرض التقديمي. يحدد هذا المثال صفحة أفقية بحجم 900 × 600 نقطة، يحفظها كملف PPTX، ثم يفتح الملف المحفوظ مرة أخرى للتحقق من القيم المستمرة. يسمح المقارن بتحمل فرق قدره 0.01 نقطة للقيم العشرية؛ وهذا ليس ضمانًا للدقة في كل تنسيق ملف.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    expected_size = Dimension(900, 600)
    presentation.getNotesSize().setSize(expected_size)

    presentation.save("custom-notes.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom-notes.pptx")
    try:
        actual_size = reopened.getNotesSize().getSize()
        width_matches = abs(actual_size.getWidth() - expected_size.getWidth()) < 0.01
        height_matches = abs(actual_size.getHeight() - expected_size.getHeight()) < 0.01
        preserved = width_matches and height_matches

        print(f"Stored notes page: {actual_size.getWidth()} x {actual_size.getHeight()} points")
        print(f"Size preserved: {preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

النتيجة المتوقعة هي `900.0 x 600.0 points` و `Size preserved: True`. فحص عرض تقديمي تم فتحه حديثًا يتحقق من الملف المحفوظ، وليس فقط الإعدادات الموجودة في الذاكرة.

## **تصدير الملاحظات والكتيبات**

تحدد أبعاد الصفحة المنطقة المتاحة لتخطيطات الملاحظات أو الكتيب. هذه الأبعاد لا تُفعِّل تلك التخطيطات بحد ذاتها: يجب أيضًا تكوين خيارات التصدير. يستمر تصدير الشرائح العادية في استخدام أبعاد الشريحة.

### **تصدير الملاحظات إلى PDF و PNG**

عيّن [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notescommentslayoutingoptions/) إلى [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) لتضمين الملاحظات في ملف PDF. يقوم هذا المثال أيضًا بتصيير الشريحة الأولى مع الملاحظات إلى PNG باستخدام [Slide.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getImage) و [RenderingOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/renderingoptions/).

وضع [BottomTruncated](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notespositions/) يحتفظ بالملاحظات على صفحة واحدة؛ يمكن تقصير الملاحظات التي لا تتناسب. يستخدم ملف PDF صفحات بحجم 900 × 600 نقطة. عند مقياس الصورة 1 × 1 المستخدم أدناه، يكون حجم PNG 900 × 600 بكسل. النقاط تصف هندسة الصفحة؛ والبكسل يصف الإخراج النقطي، الذي تعتمد أبعاده أيضًا على مقياس التصيير.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, RenderingOptions, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = NotesCommentsLayoutingOptions()
    layout.setNotesPosition(NotesPositions.BottomTruncated)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("notes.pdf", SaveFormat.Pdf, pdf_options)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout)

    image = presentation.getSlides().get_Item(0).getImage(rendering_options, 1.0, 1.0)
    try:
        image.save("first-slide-notes.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

لتصدير PDF مع ملاحظات طويلة، يسمح [BottomFull](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notespositions/) بصفحات إضافية حسب الحاجة. لا تستخدم هذا الوضع مع استدعاء صورة شريحة واحدة أعلاه، لأنه لا يدعمه. بعد تغيير الحجم، افحص الناتج بحثًا عن ملاحظات مقطوعة وموقع كائنات notes-master الموجودة؛ تغيير أبعاد الصفحة فقط لا ينبغي أن يُعتبر ضمانًا لتناسب كل المحتوى. راجع [Convert PowerPoint to PDF with Notes](/slides/ar/python-java/convert-powerpoint-to-pdf-with-notes/) للمزيد حول تصدير الملاحظات.

### **تصدير الكتيبات إلى PDF**

استخدم [HandoutLayoutingOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/handoutlayoutingoptions/) لإظهار صور مصغرة متعددة للشرائح على صفحة واحدة. يحدد المثال التالي صفحة بحجم 900 × 600 نقطة ويستخدم [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/ar/python-java/aspose.slides/handouttype/) لترتيب ما يصل إلى أربع شرائح لكل صفحة. يتحكم الإعداد الأفقي في ترتيب الشرائح؛ يأتي اتجاه الصفحة من عرضه وارتفاعه.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = HandoutLayoutingOptions()
    layout.setHandout(HandoutType.Handouts4Horizontal)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

تغيير حجم الصفحة يغيّر المنطقة المتاحة لشبكة الكتيب دون تغيير أبعاد الشرائح المصدرية. للحصول على صور الكتيب، استخدم [Presentation.getImages](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getImages) مع تخطيط الكتيب، بدلاً من طريقة صورة شريحة فردية. في Aspose.Slides، يستخدم تصيير الكتيب على مستوى العرض التقديمي أبعاد صفحة الملاحظات، بينما لا تنتج طريقة صورة الشريحة الفردية صفحة كتيب. راجع [Handout Mode](/slides/ar/python-java/convert-powerpoint-in-handout-mode/) لخيارات التخطيط.

## **حجم الصفحة في عارضات، التصدير، والطباعة**

حافظ على تمييز حجم العرض التقديمي المخزن، حجم الصفحة المُصدَّر، وحجم الورق المطبع:

- **Presentation viewers:** يمكن للعارض عرض أو طباعة الملاحظات باستخدام قواعد التخطيط الخاصة به. إذا قام تطبيق آخر بحفظ الملف، أعد فتحه وتحقق من الأبعاد مرة أخرى؛ قد تقوم عملية تحويل الصيغة في ذلك التطبيق بتطبيعه.
- **Export formats:** تستخدم أمثلة PDF للملاحظات والكتيب أعلاه أبعاد الصفحة المُكوَّنة. تستخدم الصور النقطية أبعاد بكسل صحيحة ومقياس تصيير، لذا يمكن تقريب قيم النقاط الكسرية في ناتج الصورة. لا يتم تطبيق حجم صفحة الملاحظات عند تصدير الشرائح العادية.
- **Printer drivers:** يمكن لاختيار الورق، أو الدوران التلقائي، أو إعدادات ملاءمة الصفحة أن تُغيّر المخرجات الفعلية دون تغيير الأبعاد المخزنة في العرض التقديمي أو PDF. للحصول على حجم ورق محدد، طابق إعدادات الطابعة وتحقق من معاينة الطباعة.

## **الأسئلة الشائعة**

**هل يمكنني تعيين حجم الملاحظات لشريحة واحدة فقط؟**

حجم صفحة الملاحظات هو إعداد على مستوى العرض التقديمي. يمكن أن تحتوي الشرائح الفردية على محتوى ملاحظات مختلف، لكن هذه الخاصية لا توفر حجم صفحة منفصل لكل شريحة.

**لماذا لم يؤدي تغيير اتجاه الملاحظات إلى تغيير شرائحي؟**

صفحات الملاحظات والشرائح العادية لها أبعاد مستقلة. استخدم إعدادات حجم الشريحة العادية عندما تريد تغيير حجم الشرائح نفسها.

**لماذا يكون للنتيجة المحفوظة أو المطبوعة حجم مختلف؟**

ابدأ بإعادة فتح العرض التقديمي المحفوظ ومقارنة أبعاد ملاحظاته. إذا تغيرت تلك الأبعاد، تحقق مما إذا كان حفظ الملف أو تحويله في تطبيق آخر قد غير إعدادات الصفحة. إذا لم يحدث ذلك، فافحص تخطيط التصدير، مقياس الصورة، إعدادات العارض، واختيار ورق الطابعة.