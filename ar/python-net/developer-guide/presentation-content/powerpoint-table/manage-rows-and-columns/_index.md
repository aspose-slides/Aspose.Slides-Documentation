---
title: إدارة الصفوف والأعمدة في جداول PowerPoint باستخدام Python
linktitle: الصفوف والأعمدة
type: docs
weight: 20
url: /ar/python-net/manage-rows-and-columns/
keywords:
- صف الجدول
- عمود الجدول
- الصف الأول
- رأس الجدول
- استنساخ صف
- استنساخ عمود
- نسخ صف
- نسخ عمود
- إزالة صف
- إزالة عمود
- تنسيق نص الصف
- تنسيق نص العمود
- نمط الجدول
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إدارة صفوف وأعمدة الجداول في PowerPoint وOpenDocument باستخدام Aspose.Slides for Python عبر .NET وتسريع تحرير العروض التقديمية وتحديث البيانات."
---

## **نظرة عامة**

هذا المقال يوضح كيفية إدارة صفوف وأعمدة الجداول في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for Python. ستتعلم كيفية إضافة، إدراج، استنساخ، وحذف الصفوف أو الأعمدة، تعيين الصف الأول كعنوان، ضبط الحجم والتخطيط، وتطبيق تنسيق النص والأسلوب على مستوى الصف أو العمود. كل مهمة موضحة بمقتطفات شفرة مختصرة ومستقلة تستند إلى واجهة برمجة التطبيقات [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)، بحيث يمكنك بسرعة العثور على جدول في شريحة وإعادة تشكيل هيكله ليتوافق مع تصميمك.

## **تعيين الصف الأول كعنوان**

ضع علامة على الصف الأول للجدول كعنوان لتمييز عناوين الأعمدة عن البيانات بوضوح. في Aspose.Slides for Python، يكفي تمكين خيار *First Row* للجدول لتطبيق تنسيق العنوان المحدد بنمط الجدول المختار.

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وحمِّل العرض.
1. احصل على الشريحة باستخدام فهرسها.
1. استعرض جميع كائنات [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) للعثور على الجدول المناسب.
1. عيّن الصف الأول للجدول كعنوان.

هذا الكود Python يوضح كيفية تعيين الصف الأول للجدول كعنوان:
```python
import aspose.slides as slides

# إنشاء كائن من فئة Presentation.
with slides.Presentation("table.pptx") as presentation:
    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # التكرار عبر الأشكال والحصول على مرجع إلى الجدول.
    for shape in slide.shapes:
        if type(shape) is slides.Table:
            table = shape
            break

    # تعيين الصف الأول للجدول كعنوان.
    table.first_row = True
    
    # حفظ العرض التقديمي إلى القرص.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```


## **استنساخ صف أو عمود في الجدول**

استنسخ أي صف أو عمود في الجدول وأدرِ النسخة في الموضع المطلوب داخل الجدول. النسخة المستنسخة تحتفظ بمحتوى الخلايا، التنسيق، والأحجام، مما يتيح لك توسيع التخطيطات بسرعة وبشكل متسق.

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وحمِّل العرض.
1. احصل على الشريحة باستخدام فهرسها.
1. عرّف مصفوفة بعرض الأعمدة.
1. عرّف مصفوفة بارتفاعات الصفوف.
1. أضف [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) إلى الشريحة باستخدام `add_table(x, y, column_widths, row_heights)`.
1. استنسخ صفًا في الجدول.
1. استنسخ عمودًا في الجدول.
1. احفظ العرض المعدل.

هذا الكود Python يوضح كيفية استنساخ صف وعمود في جدول PowerPoint:
```python
 import aspose.slides as slides

# إنشاء كائن من فئة Presentation.
with slides.Presentation() as presentation:
    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # تعريف عرض الأعمدة وارتفاعات الصفوف.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # إضافة جدول إلى الشريحة.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # إضافة نص إلى الصف 1، العمود 1.
    table.rows[0][0].text_frame.text = "Row 1 Cell 1"

    # إضافة نص إلى الصف 2، العمود 1.
    table.rows[1][0].text_frame.text = "Row 1 Cell 2"

    # استنساخ الصف 1 في نهاية الجدول.
    table.rows.add_clone(table.rows[0], False)

    # إضافة نص إلى الصف 1، العمود 2.
    table.rows[0][1].text_frame.text = "Row 2 Cell 1"

    # إضافة نص إلى الصف 2، العمود 2.
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"

    # استنساخ الصف 2 كصف رابع في الجدول.
    table.rows.insert_clone(3,table.rows[1], False)

    # استنساخ العمود الأول في النهاية.
    table.columns.add_clone(table.columns[0], False)

    # استنساخ العمود الثاني في الفهرس 3 (الموقع الرابع).
    table.columns.insert_clone(3,table.columns[1], False)
    
    # حفظ العرض التقديمي إلى القرص.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```


## **إزالة صف أو عمود من الجدول**

قم بتبسيط الجدول بإزالة أي صف أو عمود باستخدام الفهرس عبر Aspose.Slides for Python—سيتم تعديل التخطيط تلقائيًا مع الحفاظ على تنسيق الخلايا المتبقية. هذا مفيد لتقليل تعقيد الشبكات البيانية أو حذف العناصر النائبة دون الحاجة إلى إعادة بناء الجدول.

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وحمِّل العرض.
1. احصل على الشريحة باستخدام فهرسها.
1. عرّف مصفوفة بعرض الأعمدة.
1. عرّف مصفوفة بارتفاعات الصفوف.
1. أضف ITable إلى الشريحة باستخدام `add_table(x, y, column_widths, row_heights)`.
1. أزل صف الجدول.
1. أزل عمود الجدول.
1. احفظ العرض المعدل.

الكود Python التالي يوضح كيفية إزالة صف وعمود من جدول:
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

طبق نمط نص موحد على صف كامل في خطوة واحدة. باستخدام Aspose.Slides for Python، يمكنك تحديد عائلة الخط، الحجم، الوزن، اللون، والمحاذاة لجميع خلايا الصف دفعة واحدة للحفاظ على تناسق العناوين أو مجموعات البيانات.

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وحمِّل العرض.
1. احصل على الشريحة باستخدام فهرسها.
1. احصل على كائن [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) المناسب في الشريحة.
1. عيّن ارتفاع الخط لخلايا الصف الأول.
1. عيّن المحاذاة والهوامش اليمنى لخلايا الصف الأول.
1. عيّن نوع النص العمودي لخلايا الصف الثاني.
1. احفظ العرض المعدل.

هذا الكود Python يُظهر العملية.
```python
import aspose.slides as slides

# إنشاء نسخة من فئة Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # تعيين ارتفاع الخط لخلايا الصف الأول.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    # تعيين محاذاة النص وهوامش اليمين لخلايا الصف الأول.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    # تعيين نوع النص العمودي لخلايا الصف الثاني.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)
	
    # حفظ العرض التقديمي إلى القرص.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```


## **تطبيق تنسيق النص على مستوى عمود الجدول**

طبق نمط نص موحد على عمود كامل مرة واحدة. باستخدام Aspose.Slides for Python، يمكنك تحديد عائلة الخط، الحجم، الوزن، اللون، والمحاذاة لجميع خلايا العمود لإنشاء أشرطة رأسية موحدة للعناوين أو البيانات.

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وحمِّل العرض.
1. احصل على الشريحة باستخدام فهرسها.
1. احصل على كائن [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) المناسب في الشريحة.
1. عيّن ارتفاع الخط لخلايا العمود الأول.
1. عيّن المحاذاة والهوامش اليمنى لخلايا العمود الأول.
1. عيّن نوع النص العمودي لخلايا العمود الثاني.
1. احفظ العرض المعدل.

الكود Python التالي يُظهر العملية:
```python
import aspose.slides as slides

# إنشاء نسخة من فئة Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # تعيين ارتفاع الخط لخلايا العمود الأول.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    # تعيين محاذاة النص وهوامش اليمين لخلايا العمود الأول.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    # تعيين نوع النص العمودي لخلايا العمود الثاني.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```


## **الحصول على خصائص نمط الجدول**

تتيح لك Aspose.Slides استرجاع خصائص نمط الجدول لتتمكن من إعادة استخدامها في جدول آخر أو في أماكن أخرى. الكود Python التالي يوضح كيفية الحصول على خصائص النمط من نمط جدول مُعرّف مسبقًا:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة الشائعة**

**هل يمكنني تطبيق سمات/أنماط PowerPoint على جدول تم إنشاؤه مسبقًا؟**

نعم. الورقة تستقبل سمة الشريحة/التخطيط/القالب، ولا يزال بإمكانك تجاوز التعبئات، الحدود، وألوان النص فوق تلك السمة.

**هل يمكنني فرز صفوف الجدول كما في Excel؟**

لا، لا تدعم جداول Aspose.Slides الفرز أو الفلاتر المدمجة. قم بفرز البيانات في الذاكرة أولاً، ثم أعد ملء صفوف الجدول بالترتيب المطلوب.

**هل يمكنني الحصول على أعمدة مخططة (مخططة) مع الحفاظ على ألوان مخصصة لخلايا معينة؟**

نعم. فعِّل الأعمدة المخططة، ثم قم بتجاوز خلايا معينة بالتنسيق المحلي؛ التنسيق على مستوى الخلية يتفوق على نمط الجدول.