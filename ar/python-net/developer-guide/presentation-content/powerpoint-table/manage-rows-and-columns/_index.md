---
title: إدارة الصفوف والأعمدة في جداول PowerPoint باستخدام Python
linktitle: صفوف وأعمدة
type: docs
weight: 20
url: /ar/python-net/manage-rows-and-columns/
keywords:
- صف جدول
- عمود جدول
- الصف الأول
- رأس جدول
- استنساخ صف
- استنساخ عمود
- نسخ صف
- نسخ عمود
- إزالة صف
- إزالة عمود
- تنسيق نص الصف
- تنسيق نص العمود
- نمط جدول
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إدارة صفوف وأعمدة الجداول في PowerPoint باستخدام Aspose.Slides للغة Python عبر .NET وتسريع تحرير العروض التقديمية وتحديث البيانات."
---
## **المقدمة**

تتيح لك Aspose.Slides للغة Python عبر .NET إدارة بنية الجداول وتنسيقها في عروض PowerPoint عبر الفئة [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) . يمكنك تعيين صف رأس، استنساخ أو إزالة الصفوف والأعمدة، وتطبيق تنسيق النص على صف أو عمود كامل.

تشرح هذه المقالة هذه العمليات باستخدام أمثلة Python. كما تظهر كيفية استرجاع إعداد النمط المسبق للجدول بحيث يمكنك إعادة استخدامه. مؤشرات الصفوف والأعمدة في الجدول تبدأ من الصفر.

## **التحكم في ارتفاع الصف**

استخدم [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) لتعيين الحد الأدنى لارتفاع الصف بالنقاط. إنه حد أدنى، وليس ارتفاعًا ثابتًا. [Row.height](https://reference.aspose.com/slides/python-net/aspose.slides/row/height/) يعيد الارتفاع الفعلي وهو للقراءة فقط. يمكن الوصول إلى الصف عبر [Table.rows](https://reference.aspose.com/slides/python-net/aspose.slides/table/rows/).

يقوم المثال بتحميل [row-height-input.pptx](row-height-input.pptx)، والذي يحتوي على جدول كأول شكل في الشريحة الأولى. يبدأ صفه الأول عند 70 نقطة. الخلايا تستخدم نص Arial بحجم 18 نقطة، مع الالتفاف، وهوامش علوية وسفلية بحجم 6 نقاط؛ النص الأطول في العمود الثاني يلتف إلى عدة أسطر. يزيد المثال الحد الأدنى إلى 100 نقطة، ثم يقلّله إلى 20 نقطة، يطبع الارتفاع الفعلي بعد كل تغيير، ويحفظ كلا النتيجتين.

```python
import aspose.slides as slides

with slides.Presentation("row-height-input.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    row = table.rows[0]

    row.minimal_height = 100
    print(f"Increased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-increased.pptx", slides.export.SaveFormat.PPTX)

    row.minimal_height = 20
    print(f"Decreased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-decreased.pptx", slides.export.SaveFormat.PPTX)
```

مع العرض التقديمي المرفق، يؤدي زيادة الحد الأدنى إلى إضافة مساحة للصف. يقلّصها يزيل تلك المساحة الإضافية، لكن الارتفاع الفعلي يبقى أكبر من 20 نقطة لأن النص وهوامش الخلية تحتاج إلى مساحة أكبر. لا يمكن لتقليل الحد الأدنى وحده أن يجبر الصف على أن يكون أقل من المساحة المطلوبة لمحتواه.

عدة عوامل تؤثر على الارتفاع الفعلي:
- **النص وحجم الخط:** النص الأطول، أو فواصل أسطر صريحة، أو خط أكبر قد يتطلب مساحة رأسية أكبر.
- **الالتفاف وعرض العمود:** مع تمكين الالتفاف، يمكن لعرض [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) الضيق أن ينتج مزيدًا من الأسطر. العمود الأوسع يمكن أن يقلل المساحة المطلوبة رأسيًا.
- **هوامش الخلية:** [Cell.margin_top](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_top/) و[Cell.margin_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_bottom/) تضيف مساحة رأسية. [Cell.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_left/) و[Cell.margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_right/) تقلل عرض النص المتاح ويمكن أن تتسبب في التفاف إضافي.

بالنسبة لهذا الجدول بدون خلايا مدمجة، تحدد الخلية التي تحتاج إلى أكبر مساحة رأسية الحد الأدنى المستند إلى المحتوى للصف بأكمله. لجعل الصف أقصر، قد تحتاج أيضًا إلى تقصير النص، أو تقليل حجم الخط أو الهوامش، أو توسيع عمود.

الصور أدناه تظهر نفس الجدول بنفس المقياس. في هذه التجربة، كانت الارتفاعات الفعلية 70 و100 و55.2 نقطة: ظل الصف النهائي أطول من الحد الأدنى البالغ 20 نقطة. قد تختلف قياسات النص الدقيقة باختلاف الخطوط المتوفرة في بيئتك. حمّل النتائج المحفوظة: [increased minimum](row-height-increased.pptx) و[decreased minimum](row-height-decreased.pptx).

| الأصل: الحد الأدنى 70 نقطة، الفعلي 70 نقطة | تم الزيادة: الحد الأدنى 100 نقطة، الفعلي 100 نقطة | تم التخفيض: الحد الأدنى 20 نقطة، الفعلي 55.2 نقطة |
| --- | --- | --- |
| ![الجدول الأصلي مع صف أول بارتفاع 70 نقطة.](row-height-before.png) | ![جدول بعد زيادة الحد الأدنى للصف الأول إلى 100 نقطة.](row-height-increased.png) | ![جدول بعد تقليل الحد الأدنى للصف الأول إلى 20 نقطة؛ النص الملتف يبقي الصف أعلى من الحد الأدنى.](row-height-decreased.png) |

## **تعيين الصف الأول كرأس جدول**

استخدم الخاصية [first_row](https://reference.aspose.com/slides/python-net/aspose.slides/table/first_row/) لتعيين الصف الأول لتنسيق الرأس. مظهره يعتمد على نمط الجدول المطبق على الجدول.

1. قم بتحميل العرض التقديمي باستخدام الفئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الوصول إلى الشريحة الأولى.
3. الوصول إلى الجدول المخزن كأول شكل على الشريحة.
4. تمكين تنسيق الرأس للصف الأول.
5. حفظ العرض التقديمي المعدل.

المثال يتطلب `table.pptx` يحتوي على جدول كأول شكل على الشريحة الأولى. يقوم بتمكين تنسيق الرأس للصف الأول ويحفظه كـ `First_row_header.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]
    table.first_row = True

    presentation.save("First_row_header.pptx", slides.export.SaveFormat.PPTX)
```

## **استنساخ صف أو عمود في الجدول**

استنساخ الصفوف أو الأعمدة لإعادة استخدام محتواها وتنسيقها. يمكنك إضافة نسخة إلى نهاية الجدول أو إدراجها في موضع محدد.

1. قم بتحميل العرض التقديمي باستخدام الفئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الوصول إلى الشريحة الأولى.
3. تحديد عرض الأعمدة وارتفاعات الصفوف.
4. إضافة جدول باستخدام الطريقة [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) .
5. استنساخ الصفوف المطلوبة.
6. استنساخ الأعمدة المطلوبة.
7. حفظ العرض التقديمي المعدل.

المثال يتطلب `Test.pptx` يحتوي على شريحة واحدة على الأقل. ينشئ جدولًا بثلاثة أعمدة وخمسة صفوف، بأبعاد محددة بالنقاط. يضيف نسخًا من الصف والعمود الأول، ثم يدرج نسخًا من الصف والعمود الثاني في الفهرس 3 (الموضع الرابع). يصبح الجدول الناتج مكونًا من سبعة صفوف وخمسة أعمدة. الوسيط `False` يمنع الاستنساخ إلى الصفوف أو الأعمدة المدمجة المجاورة؛ لا يحتوي هذا الجدول على خلايا مدمجة.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[0][0].text_frame.text = "Row 1 Cell 1"
    table.rows[0][1].text_frame.text = "Row 1 Cell 2"
    table.rows.add_clone(table.rows[0], False)

    table.rows[1][0].text_frame.text = "Row 2 Cell 1"
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"
    table.rows.insert_clone(3, table.rows[1], False)

    table.columns.add_clone(table.columns[0], False)
    table.columns.insert_clone(3, table.columns[1], False)

    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **إزالة صف أو عمود من جدول**

إزالة الصفوف أو الأعمدة التي لم تعد بحاجة إليها في جدول. إزالة عنصر تحرك مؤشرات الصفوف أو الأعمدة التي تليه.

1. إنشاء عرض تقديمي باستخدام الفئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الوصول إلى الشريحة الأولى.
3. تحديد عرض الأعمدة وارتفاعات الصفوف.
4. إضافة جدول باستخدام الطريقة [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) .
5. إزالة الصف الثاني والعمود الثاني.
6. حفظ العرض التقديمي المعدل.

هذا المثال ينشئ جدولًا بثلاثة صفوف وثلاثة أعمدة ثم يزيل الصف والعمود عند الفهرس 1، فيبقى جدولًا ثنائيًا في `TestTable_out.pptx`. الأبعاد بالنقاط. الوسيط `False` يمنع إزالة الصفوف أو الأعمدة المدمجة المجاورة؛ لا يحتوي هذا الجدول على خلايا مدمجة.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.shapes.add_table(100, 100, column_widths, row_heights)

    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)

    presentation.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تطبيق تنسيق النص على مستوى صف الجدول**

تطبيق تنسيق النص على صف كامل للحفاظ على توحيد خلاياه. يمكنك ضبط خصائص الخط، وتنسيق الفقرة، واتجاه النص دون تنسيق كل خلية على حدة.

1. قم بتحميل العرض التقديمي باستخدام الفئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الوصول إلى الجدول على الشريحة الأولى.
3. ضبط [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) للصف الأول.
4. ضبط [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) و[margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) للصف الأول.
5. ضبط [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) للصف الثاني.
6. حفظ العرض التقديمي المعدل.

المثال يتطلب `table.pptx` يحتوي على جدول كأول شكل على الشريحة الأولى وعلى الأقل صفين. يطبق نصًا بحجم 25 نقطة، ومحاذاة إلى اليمين، وهوامش فقرة يمنى بحجم 20 نقطة على الصف الأول، ثم يضبط النص عموديًا في الصف الثاني.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)

    presentation.save("row_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **تطبيق تنسيق النص على مستوى عمود الجدول**

تطبيق تنسيق النص على عمود كامل للحفاظ على توحيد خلاياه. يمكنك ضبط خصائص الخط، وتنسيق الفقرة، واتجاه النص دون تنسيق كل خلية على حدة.

1. قم بتحميل العرض التقديمي باستخدام الفئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الوصول إلى الجدول على الشريحة الأولى.
3. ضبط [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) للعمود الأول.
4. ضبط [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) و[margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) للعمود الأول.
5. ضبط [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) للعمود الثاني.
6. حفظ العرض التقديمي المعدل.

المثال يتطلب `table.pptx` يحتوي على جدول كأول شكل على الشريحة الأولى وعلى الأقل عمودين. يطبق نصًا بحجم 25 نقطة، ومحاذاة إلى اليمين، وهوامش فقرة يمنى بحجم 20 نقطة على العمود الأول، ثم يضبط النص عموديًا في العمود الثاني.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    presentation.save("column_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **الحصول على خصائص نمط الجدول**

استخدم الخاصية [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) لاسترجاع الإعداد المسبق المطبق على جدول وإعادة استخدامه في جدول آخر. يحدد هذا الإعداد المسبق بدلاً من تجاوز تنسيقات الخلايا الفردية.

المثال ينشئ جدولًا، يطبق [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) ، ثم يقرأ الإعداد المسبق مرة أخرى. يطبع `True` عندما يتطابق الإعداد المسترجع مع الإعداد المطبق ويحفظ الجدول في `table.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(style_preset == slides.TableStylePreset.DARK_STYLE1)

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**هل يمكنني تطبيق سمات/أنماط PowerPoint على جدول تم إنشاؤه بالفعل؟**

نعم. يرث الجدول سمة الشريحة/التخطيط/الماستر، ولا يزال بإمكانك تجاوز التعبئات والحدود وألوان النص فوق تلك السمة.

**هل يمكنني فرز صفوف الجدول كما في Excel؟**

لا، لا تحتوي جداول Aspose.Slides على فرز أو فلاتر مدمجة. قم بفرز البيانات في الذاكرة أولًا، ثم أعد ملء صفوف الجدول بهذا الترتيب.

**هل يمكنني الحصول على أعمدة مخططة (متسلسلة) مع الحفاظ على ألوان مخصصة في خلايا معينة؟**

نعم. فعّل الأعمدة المخططة، ثم قم بتجاوز خلايا محددة بتنسيق محلي؛ يملك تنسيق الخلية أولوية على نمط الجدول.