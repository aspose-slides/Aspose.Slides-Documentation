---
title: إدارة خلايا الجداول في العروض التقديمية باستخدام بايثون
linktitle: إدارة الخلايا
type: docs
weight: 30
url: /ar/python-net/manage-cells/
keywords:
- خلية جدول
- دمج خلايا
- إزالة الحدود
- تقسيم الخلية
- صورة داخل الخلية
- لون الخلفية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إدارة خلايا الجداول بسهولة في PowerPoint وOpenDocument باستخدام Aspose.Slides لبايثون عبر .NET. إتقان الوصول إلى الخلايا وتعديلها وتنسيقها بسرعة لتفعيل أتمتة الشرائح بسلاسة."
---

## **نظرة عامة**

توضح هذه المقالة كيفية العمل مع خلايا الجداول في العروض التقديمية باستخدام Aspose.Slides. ستتعلم كيفية اكتشاف الخلايا المدمجة، مسح أو تخصيص حدود الخلايا، وفهم كيفية ترقيم PowerPoint للخلايا بعد عمليات الدمج والتقسيم حتى تتمكن من توقع الفهرسة في التخطيطات المعقدة. تُظهر المقالة أيضًا مهام التنسيق الشائعة—مثل تغيير تعبئة خلفية الخلية—وتظهر كيفية وضع صورة مباشرة داخل خلية جدول باستخدام إعدادات تعبئة الصورة. كل سيناريو يرافقه أمثلة مختصرة بلغة Python تقوم بإنشاء أو تعديل الجداول ثم حفظ العرض المحدث، بحيث يمكنك تعديل الشفرات لتناسب شرائحك بسرعة.

## **تحديد خلايا الجدول المدمجة**

غالبًا ما تحتوي الجداول على خلايا مدمجة للرؤوس أو لتجميع البيانات ذات الصلة. في هذا القسم، ستتعرف على كيفية تحديد ما إذا كانت خلية معينة تنتمي إلى منطقة مدمجة وكيفية الإشارة إلى الخلية الرئيسية (الزاوية العلوية اليسرى) حتى تتمكن من قراءة أو تنسيق الكتلة بأكملها بشكل موحد.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على الجدول من الشريحة الأولى.
1. التنقل عبر صفوف وأعمدة الجدول للعثور على الخلايا المدمجة.
1. طباعة رسالة عند العثور على خلايا مدمجة.

الكود Python التالي يحدد خلايا الجدول المدمجة في عرض تقديمي:
```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # بافتراض أن الشكل الأول على الشريحة الأولى هو جدول.
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```


## **إزالة حدود خلايا الجدول**

أحيانًا تشتت حدود الجدول الانتباه عن المحتوى أو تخلق فوضى بصرية. يوضح هذا القسم كيفية إزالة الحدود من الخلايا المحددة—أو من جوانب محددة للخلية—حتى تحصل على تخطيط أنظف ويتماشى بشكل أفضل مع تصميم شريحتك.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على الشريحة بواسطة فهرسها.
1. تعريف مصفوفة لعرض الأعمدة.
1. تعريف مصفوفة لارتفاع الصفوف.
1. إضافة جدول إلى الشريحة باستخدام طريقة [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) .
1. التنقل عبر كل خلية لمسح الحدود العلوية والسفلية واليسرى واليمنى.
1. حفظ العرض المعدل كملف PPTX.

الكود Python التالي يوضح كيفية إزالة الحدود من خلايا الجدول:
```python
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل ملف PPTX.
with slides.Presentation() as presentation:
    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # تعريف الأعمدة بعرضها والصفوف بارتفاعها.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # إضافة شكل جدول إلى الشريحة.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # مسح تعبئة الحدود لكل خلية.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # حفظ ملف PPTX على القرص.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```


## **الترقيم في الخلايا المدمجة**

إذا دمجت زوجين من الخلايا—على سبيل المثال، (1, 1) × (2, 1) و(1, 2) × (2, 2)—ستحتفظ الجدول الناتج بنفس ترقيم الخلايا كما لو لم يتم الدمج. الكود Python التالي يوضح هذا السلوك:
```python
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل ملف PPTX.
with slides.Presentation() as presentation:
    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # تعريف الأعمدة بعرضها والصفوف بارتفاعها.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # إضافة شكل جدول إلى الشريحة.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # دمج الخلايا (1,1) و (2,1).
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # دمج الخلايا (1, 2) و (2, 2).
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # طباعة مؤشرات الخلايا.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # حفظ ملف PPTX على القرص.
    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```


الإخراج:
```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```


## **الترقيم في الخلايا المقسمة**

في المثال السابق، عندما تم دمج خلايا الجدول، لم يتغير الترقيم في الخلايا الأخرى. هذه المرة، ننشئ جدولًا عاديًا (بدون خلايا مدمجة) ثم نقسم الخلية (1, 1) لننتج جدولًا خاصًا. انتبه إلى ترقيم هذا الجدول—قد يبدو غير مألوف. ومع ذلك، هذا هو طريقة ترقيم Microsoft PowerPoint لخلايا الجداول، ويتبع Aspose.Slides نفس السلوك.

الكود Python التالي يوضح هذا السلوك:
```python
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل ملف PPTX.
with slides.Presentation() as presentation:
    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # تعريف عرض الأعمدة وارتفاع الصفوف.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # إضافة شكل جدول إلى الشريحة.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # تقسيم الخلية (1, 1).
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # طباعة مؤشرات الخلايا.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # حفظ ملف PPTX على القرص.
    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```


الإخراج:
```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```


## **تغيير لون خلفية خلية الجدول**

مثال Python التالي يوضح كيفية تغيير لون خلفية خلية الجدول:
```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # إنشاء جدول جديد.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # تعيين لون الخلفية لخلية.
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```


## **إدراج صور في خلايا الجدول**

يظهر هذا القسم كيفية إدراج صورة في خلية جدول باستخدام Aspose.Slides. يغطي تطبيق تعبئة صورة على الخلية المستهدفة وتكوين خيارات العرض مثل التمدد أو التكرار.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع شريحة بواسطة فهرستها.
1. تعريف مصفوفة لعرض الأعمدة.
1. تعريف مصفوفة لارتفاع الصفوف.
1. إضافة جدول إلى الشريحة باستخدام طريقة [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) .
1. تحميل الصورة من ملف.
1. إضافة الصورة إلى مجموعة صور العرض للحصول على كائن [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) .
1. ضبط خاصية [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) للخلية إلى `PICTURE`.
1. تطبيق الصورة على خلية الجدول واختيار وضع التعبئة (مثال: `STRETCH`).
1. حفظ العرض كملف PPTX.

الكود Python التالي يوضح كيفية وضع صورة داخل خلية جدول عند إنشاء جدول:
```python
import aspose.slides as slides

# إنشاء كائن Presentation.
with slides.Presentation() as presentation:
    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # تعريف عرض الأعمدة وارتفاع الصفوف.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # إضافة شكل جدول إلى الشريحة.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # تحميل الصورة وإضافتها إلى العرض للحصول على PPImage.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # تطبيق الصورة على خلية الجدول الأولى.
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # حفظ العرض على القرص.
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة المتكررة**

**هل يمكنني ضبط سماكات وأنماط الخطوط المختلفة لجوانب خلية واحدة؟**

نعم. حدود [العلوية](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[السفلية](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[اليسرى](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[اليمنى](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) لها خصائص منفصلة، لذلك يمكن أن تختلف السماكة والنمط لكل جانب. هذا يتبع من التحكم في الحدود الجانبية للخلية كما هو موضح في المقالة.

**ماذا يحدث للصورة إذا قمت بتغيير حجم العمود/الصف بعد تعيين صورة كخلفية للخلية؟**

السلوك يعتمد على [وضع التعبئة](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (تمدد/تكرار). مع التمدد، تتكيف الصورة مع الخلية الجديدة؛ ومع التكرار، يتم إعادة حساب البلاطات. المقالة تشير إلى أوضاع عرض الصورة داخل الخلية.

**هل يمكنني إرفاق ارتباط تشعبي بكل محتوى الخلية؟**

يتم تعيين [الارتباطات التشعبية](/slides/ar/python-net/manage-hyperlinks/) على مستوى النص (القطعة) داخل إطار نص الخلية أو على مستوى الجدول/الشكل بالكامل. عمليًا، يمكنك ربط الجزء أو جميع النص في الخلية.

**هل يمكنني تعيين خطوط مختلفة داخل خلية واحدة؟**

نعم. يدعم إطار نص الخلية [القطع](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (runs) التي لها تنسيق مستقل—عائلة الخط، النمط، الحجم، واللون.