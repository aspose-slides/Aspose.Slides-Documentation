---
title: "تغيير حجم واتجاه صفحة الملاحظات في بايثون"
linktitle: "حجم صفحة الملاحظات"
type: docs
weight: 10
url: /ar/python-net/notes-size/
keywords:
- حجم صفحة الملاحظات
- اتجاه الملاحظات
- ملاحظات أفقية
- ملاحظات رأسية
- حجم النشرة
- PowerPoint
- عرض تقديمي
- PPT
- PPTX
- Python
- Aspose.Slides
description: "قراءة وتغيير أبعاد صفحة الملاحظات في Aspose.Slides for Python عبر .NET، تغيير الاتجاه، التحقق من الأحجام المحفوظة، وتصدير الملاحظات أو النشرات إلى PDF وصور."
---
## **نظرة عامة**

استخدم [Presentation.notes_size](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/notes_size/) للوصول إلى إعدادات صفحة ملاحظات العرض التقديمي. يتم إرجاع كائن [NotesSize](https://reference.aspose.com/slides/ar/python-net/aspose.slides/notessize/) يمكن كتابة خاصية [size](https://reference.aspose.com/slides/ar/python-net/aspose.slides/notessize/size/) الخاصة به. على الرغم من أن كائن الإعدادات نفسه للقراءة فقط، يمكنك تعيين أبعاد جديدة لخاصية الحجم.

يتم تحديد العرض والارتفاع بوحدات **النقاط**، حيث 72 نقطة لكل بوصة. على سبيل المثال، 900 × 600 نقطة يساوي 12.5 × 8⅓ بوصة. تُطبق هذه الإعدادات على العرض التقديمي ككل، وليس على ملاحظات شريحة فردية.

| الإعداد | الغرض |
| --- | --- |
| [Presentation.notes_size](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/notes_size/) | يتحكم في أبعاد صفحة الملاحظات وأبعاد الصفحة المستخدمة لتصدير النشرات. |
| [Presentation.slide_size](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/slide_size/) | يتحكم في أبعاد شرائح العرض التقديمي العادية عبر [SlideSize](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidesize/). |

تغيير أي من الإعدادين لا يغيّر الآخر تلقائيًا. كما أن تغيير اتجاه صفحة الملاحظات لا يدير الشرائح العادية. راجع [Slide Size](/slides/ar/python-net/slide-size/) لتغيير حجم الشرائح العادية.

تستخدم الأمثلة أدناه ملف `sample.pptx` موجود مسبقًا. بالنسبة لأمثلة التصدير، استخدم عرضًا تقديميًا يحتوي على شريحة واحدة على الأقل تحتوي على ملاحظات المتحدث. يمكن تشغيل كل مثال بشكل مستقل.

## **قراءة حجم واتجاه صفحة الملاحظات**

اقرأ العرض والارتفاع وقارنهما لتحديد الاتجاه: الصفحة الأعرض تكون أفقية، والصفحة الأطول تكون رأسية، والأبعاد المتساوية تصف صفحة مربعة. يطبع هذا المثال الأبعاد الفعلية بالنقاط دون افتراض حجم ورق قياسي.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size
    orientation = "Square"

    if size.width > size.height:
        orientation = "Landscape"
    elif size.width < size.height:
        orientation = "Portrait"

    print(f"Notes page: {size.width:g} x {size.height:g} points")
    print(f"Orientation: {orientation}")
```

## **التبديل إلى الوضع الأفقي دون تغيير حجم الورق**

لتغيير الاتجاه فقط، قم بتبديل العرض والارتفاع الحاليين. يحافظ هذا على أطوال الجانبين، بما في ذلك حجم ورق مخصص. الشرط أدناه يمنع تحويل صفحة أفقية موجودة مسبقًا إلى وضع رأسي ويترك الصفحة المربعة دون تغيير.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size

    if size.width < size.height:
        presentation.notes_size.size = drawing.SizeF(size.height, size.width)

    presentation.save("landscape-notes.pptx", slides.export.SaveFormat.PPTX)
```

للوضع الرأسي، استخدم نفس التعيين عندما تكون `size.width > size.height`. لا تستبدل أبعاد A4 أو Letter ما لم ترغب أيضًا في تغيير حجم الورق.

## **تعيين والتحقق من حجم صفحة ملاحظات مخصص**

عين كلا البعدين معًا، ثم استخدم [Presentation.save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/save/) لحفظ العرض التقديمي. يضبط هذا المثال صفحة أفقية بحجم 900 × 600 نقطة، ويحفظها كملف PPTX، ثم يفتح الملف المحفوظ مرة أخرى للتحقق من القيم التي تم حفظها. يسمح المقارنة بتحمل فرق 0.01 نقطة للقيم العشرية؛ وهذا ليس ضمانًا للدقة في كل تنسيق ملف.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

expected_size = drawing.SizeF(900, 600)

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = expected_size
    presentation.save("custom-notes.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom-notes.pptx") as reopened:
    actual_size = reopened.notes_size.size
    width_matches = abs(actual_size.width - expected_size.width) < 0.01
    height_matches = abs(actual_size.height - expected_size.height) < 0.01
    preserved = width_matches and height_matches

    print(f"Stored notes page: {actual_size.width:g} x {actual_size.height:g} points")
    print(f"Size preserved: {preserved}")
```

النتيجة المتوقعة هي `900 x 600 points` و`Size preserved: True`. يتحقق فحص عرض تقديمي مُفتح حديثًا من الملف المحفوظ بدلاً من التحقق من الإعدادات في الذاكرة فقط.

## **تصدير الملاحظات والنشرات**

تحدد أبعاد الصفحة المنطقة المتاحة لتنسيقات الملاحظات أو النشرات. هذه الأبعاد لا تُفعّل تلك التنسيقات بحد ذاتها: يجب أيضًا تكوين خيارات التصدير. يواصل تصدير الشرائح العادية استخدام أبعاد الشريحة.

### **تصدير الملاحظات إلى PDF و PNG**

عيّن [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/notescommentslayoutingoptions/) إلى [PdfOptions.slides_layout_options](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/pdfoptions/slides_layout_options/) لتضمين الملاحظات في ملف PDF. يقوم هذا المثال أيضًا بتحويل الشريحة الأولى التي تحتوي على ملاحظات إلى PNG باستخدام [Slide.get_image](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/get_image/) و[RenderingOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/renderingoptions/).

الوضع [BOTTOM_TRUNCATED](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/notespositions/) يبقي الملاحظات في صفحة واحدة؛ يمكن تقليم الملاحظات التي لا تتسع. يستخدم PDF صفحات بحجم 900 × 600 نقطة. عند مقياس الصورة 1 × 1 المستخدم أدناه، يكون PNG بحجم 900 × 600 بكسل. النقاط تصف هندسة الصفحة؛ البكسل يصف الخرج الرقمي، والذي يعتمد أيضًا على مقياس العرض.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.NotesCommentsLayoutingOptions()
    layout.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("notes.pdf", slides.export.SaveFormat.PDF, pdf_options)

    rendering_options = slides.export.RenderingOptions()
    rendering_options.slides_layout_options = layout

    with presentation.slides[0].get_image(rendering_options, 1, 1) as image:
        image.save("first-slide-notes.png", slides.ImageFormat.PNG)
```

للـ PDF مع ملاحظات طويلة، يسمح الوضع [BOTTOM_FULL](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/notespositions/) بإضافة صفحات إضافية حسب الحاجة. لا تستخدم هذا الوضع مع استدعاء صورة شريحة واحدة أعلاه، لأنه لا يدعمه. بعد تعديل الحجم، تحقق من الخرج للتأكد من عدم تقليم الملاحظات وموقع كائنات الملاحظات‑ماستر القائمة؛ لا ينبغي اعتبار تغيير أبعاد الصفحة وحده كضمان لتناسب جميع المحتويات. راجع [Convert PowerPoint to PDF with Notes](/slides/ar/python-net/convert-powerpoint-to-pdf-with-notes/) لمزيد من المعلومات حول تصدير الملاحظات.

### **تصدير النشرات إلى PDF**

استخدم [HandoutLayoutingOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/handoutlayoutingoptions/) للحصول على عدة مصغرات شرائح في صفحة واحدة. يضبط المثال التالي صفحة بحجم 900 × 600 نقطة ويستخدم [HandoutType.HANDOUTS_4_HORIZONTAL](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/handouttype/) لترتيب ما يصل إلى أربع شرائح لكل صفحة. يتحكم الإعداد الأفقي في ترتيب الشرائح؛ يأتي اتجاه الصفحة من عرضه وارتفاعه.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.HandoutLayoutingOptions()
    layout.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("handouts.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

تغيير حجم الصفحة يغيّر المنطقة المتاحة لشبكة النشرة دون تعديل أبعاد الشرائح الأصلية. بالنسبة لصور النشرات، استخدم [Presentation.get_images](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/get_images/) مع تخطيط النشرة، بدلاً من طريقة استخراج صورة شريحة فردية. في Aspose.Slides، يستخدم تصيير النشرة على مستوى العرض التقديمي أبعاد صفحة الملاحظات، بينما لا تُنتج طريقة استخراج صورة الشريحة الفردية صفحة النشرة. راجع [Handout Mode](/slides/ar/python-net/convert-powerpoint-in-handout-mode/) لخيارات التخطيط.

## **حجم الصفحة في العارضات، والتصدير، والطباعة**

احفظ الفروق بين حجم العرض التقديمي المخزن، وحجم الصفحة المُصدَّر، وحجم الورق المطبوع:

- **عارضات العرض التقديمي:** يمكن للعارض عرض أو طباعة الملاحظات باستخدام قواعد تخطيطه الخاصة. إذا حفظ تطبيق آخر الملف، أعد فتحه وتحقق من الأبعاد مرة أخرى؛ قد تقوم عملية تحويل التنسيق في ذلك التطبيق بتطبيعها.
- **تنسيقات التصدير:** تستخدم أمثلة PDF للملاحظات والنشرات أعلاه أبعاد الصفحة المكوَّنة. تستخدم الصور النقطية أبعاد بكسل صحيحة ومقياس عرض، لذلك قد تُقرب القيم النقطية الكسرية في الخرج. لا يُطبق تصدير الشرائح العادية حجم صفحة الملاحظات.
- **برامج تشغيل الطابعات:** يمكن لاختيار الورق، والدوران التلقائي، وإعدادات الملاءمة للصفحة أن تُغيّر المخرجات المادية دون تغيير الأبعاد المخزنة في العرض التقديمي أو PDF. للحصول على حجم ورق محدد، طابق إعدادات الطابعة وتحقق من معاينة الطباعة.

## **الأسئلة المتكررة**

**هل يمكنني تعيين حجم الملاحظات لشريحة واحدة فقط؟**

حجم صفحة الملاحظات هو إعداد على مستوى العرض التقديمي. يمكن للشرائح الفردية أن تحتوي على محتوى ملاحظات مختلف، لكن هذه الخاصية لا توفر حجم صفحة منفصل لكل شريحة.

**لماذا لم يغيّر تغيير اتجاه الملاحظات شرائحي؟**

صفحات الملاحظات والشرائح العادية لها أبعاد مستقلة. استخدم إعدادات حجم الشريحة العادية عندما تريد تعديل حجم الشرائح نفسها.

**لماذا يكون للنتيجة المحفوظة أو المطبوعة حجم مختلف؟**

أعد أولاً فتح العرض التقديمي المحفوظ وقارن أبعاد ملاحظاته. إذا تغيرت، تحقق مما إذا كان حفظ أو تحويل الملف في تطبيق آخر قد غيّر إعدادات الصفحة. إذا لم يحدث ذلك، فافحص تخطيط التصدير، مقياس الصورة، إعدادات العارض، واختيار ورق الطابعة.