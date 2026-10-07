---
title: إدارة خلايا الجداول في العروض التقديمية باستخدام بايثون
linktitle: إدارة الخلايا
type: docs
weight: 30
url: /ar/python-net/manage-cells/
keywords:
- خلية جدول
- دمج الخلايا
- إزالة الحدود
- تقسيم الخلية
- صورة داخل الخلية
- لون الخلفية
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إدارة خلايا الجداول في PowerPoint باستخدام بايثون: تحديد الخلايا المدمجة، إزالة الحدود، تقسيم الخلايا، وتعيين ألوان الخلفية والصور باستخدام Aspose.Slides للبايثون عبر .NET."
---
## **نظرة عامة**

يتيح لك Aspose.Slides الوصول إلى خلايا الجداول وتعديلها في عروض PowerPoint. يوضح هذا المقال كيفية تحديد خلايا الجدول المدمجة، وإزالة حدود الخلية، والعمل بأرقام الخلايا بعد دمجها أو تقسيمها، وتغيير لون خلفية الخلية، وإضافة صورة داخل خلية الجدول. تُظهر الأمثلة كيفية إنشاء أو فتح عرض تقديمي، الحصول على جدول من شريحة، تحديث تنسيق الخلية عبر خصائص الخلية، وحفظ العرض المعدل كملف PPTX.

يستخدم Aspose.Slides مؤشرات تبدأ من الصفر. تُكتب الإحداثيات في هذه المقالة على الشكل `(column, row)`.

## **تحديد خلية جدول مدمجة**

يفتح المثال عرضًا تقديميًا موجودًا ويصل إلى الشكل الأول في الشريحة الأولى كجدول. يفترض أن الشريحة والشكل موجودان وأن الشكل هو جدول. ثم يتنقل عبر جميع الصفوف والأعمدة ويستخدم [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) لتحديد الخلايا في المناطق المدمجة. لكل مطابقة، يطبع إحداثيات الخلية بترتيب `row;column`، و[row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/)، و[col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/)، وإحداثيات بدء المنطقة، و[first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) و[first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/).

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print(f"Cell {row_index};{column_index} belongs to a merged region with row_span={cell.row_span} and col_span={cell.col_span} starting at {cell.first_row_index};{cell.first_column_index}.")
```

## **إزالة حدود خلية الجدول**

إنشاء [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وإضافة جدول إلى شريحته الأولى باستخدام [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/). تُحدد عرض الأعمدة، ارتفاع الصفوف، وموقع الجدول بالنقاط. يقوم المثال بتعيين جميع الحدود الأربعة للخلية إلى [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)، مما يجعلها غير مرئية.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **دمج خلايا الجدول**

استخدام [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) لدمج نطاق مستطيل من خلايا الجدول في خلية واحدة. حدد الخلايا في الزاوية العليا اليسرى والسفلى اليمنى للنطاق. المتغير الأخير يتحكم فيما إذا كان الدمج قد يشمل خلايا خارج النطاق المحدد؛ `False` يبقي الدمج داخل ذلك النطاق.

ينشئ المثال جدولًا 4×4 بأعمدة وصفوف بطول 70 نقطة، ثم يدمج الخلايا المركزية الأربعة من `(1, 1)` حتى `(2, 2)`. تمتد الخلية الناتجة على عمودين وصفين، بينما يظل شبكة الجدول الأساسية مكوّنة من أربعة أعمدة وأربعة صفوف. للوصول إلى محتوى أو تنسيق الخلية المدمجة، استخدم موقعها العلوي الأيسر: `table.rows[1][1]` في هذا المثال. تبقى المواقع الأخرى في النطاق المدمج جزءًا من شبكة الجدول، لذا لا تتغير مؤشرات الخلايا خارج النطاق.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.merge_cells(table.rows[1][1], table.rows[2][2], False)

    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

## **تقسيم خلايا الجدول**

يحافظ دمج الخلايا في المثال السابق على شبكة الجدول. قد يؤدي تقسيم خلية إلى إضافة عمود شبكة جديد وتغيير مؤشرات الأعمدة للخلايا التي على يمينها. يتبع Aspose.Slides نموذج شبكة جدول PowerPoint.

ينشئ هذا المثال جدولًا 4×4 بأعمدة وصفوف بطول 70 نقطة ويستدعي [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) على الخلية `(1, 1)`. يتم تمرير نصف عرض الخلية البالغ 70 نقطة لإنشاء خليتين بعرض متساوٍ.

بعد هذا التقسيم، يتم الوصول إلى النصفين عبر `table.rows[1][1]` و`table.rows[1][2]`. أصبحت شبكة الجدول الآن تتألف من خمسة أعمدة: تنتقل الخلايا الأصلية في الأعمدة 2 و3 إلى الأعمدة 3 و4 على التوالي. تبقى مؤشرات الصفوف دون تغيير. استخدم مؤشرات الأعمدة المحدثة عند الوصول إلى الخلايا بعد التقسيم.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[1][1].split_by_width(table.rows[1][1].width / 2)

    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

### **تقسيم الخلايا المدمجة حسب امتداد الصف أو العمود**

لتحضير خلايا القالب المدمجة لتعبئة البيانات، استخدم [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) لتقسيم على طول حد صف موجود، أو [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) لتقسيم على طول حد عمود.

يحسب معامل `index` الصفوف في الجزء العلوي أو الأعمدة في الجزء الأيسر من التقسيم؛ وهو نسبي للمنطقة المدمجة:

- تقسيم الصف: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- تقسيم العمود: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

يفترض المثال وجود عرض تقديمي يحتوي على جدول كالشكل الأول في الشريحة الأولى، مع دمج الخلايا `(1, 2)` و`(1, 3)` عموديًا. يبدأ من الموقع الأسفل، ويستخدم [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) و[first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) لتحديد الأصل ويتحقق من كلا الامتدادين. ثم يقوم `split_by_row_span` بمعامل 1 بفصل الصفين 2 و3 لأسماء المنتجات. لدمج أفقي بعمودين، استخدم `split_by_col_span` بمعامل 1 بدلاً من ذلك.

```python
import aspose.slides as slides

with slides.Presentation("table_template.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    selected_cell = table.rows[3][1]
    first_column_index = selected_cell.first_column_index
    first_row_index = selected_cell.first_row_index
    merged_cell = table.rows[first_row_index][first_column_index]

    if merged_cell.is_merged_cell and merged_cell.row_span == 2 and merged_cell.col_span == 1:
        merged_cell.split_by_row_span(1)

        # استرجع الخلايا الناتجة من الجدول بعد التقسيم.
        upper_cell = table.rows[first_row_index][first_column_index]
        lower_cell = table.rows[first_row_index + 1][first_column_index]
        print(f"Upper cell merged: {upper_cell.is_merged_cell}")
        print(f"Lower cell merged: {lower_cell.is_merged_cell}")

        upper_cell.text_frame.text = "Product A"
        lower_cell.text_frame.text = "Product B"

        presentation.save("split_template.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
```

تظل شبكة الجدول ومؤشرات الخلايا المجاورة دون تغيير. استرجع الخلايا الناتجة بإحداثياتها؛ هنا، كلاهما يمتد إلى 1 وتطبع [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) قيمة `False`. يمكن أن تظل المناطق الأكبر مدمجة جزئيًا بعد تقسيم واحد.

يبقى النص الأصلي وتنسيقه في الخلية العلوية (أو اليسرى)؛ الخلية الجديدة تكون فارغة لكنها تورث تنسيق الخلية مثل التعبئة والحدود والهوامش. قم بتعبئة الخلايا بعد التقسيم وتعيين أي تنسيق نص مطلوب صراحة.

العرض التقديمي المحفوظ يحتوي على خلايا "Product A" و"Product B" منفصلة مع الحفاظ على تنسيق خلية القالب. راجع [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) للمزيد من التفاصيل.

## **تغيير لون خلفية خلية الجدول**

ينشئ هذا المثال جدولًا بأعمدة بطول 150 نقطة وصفوف بطول 50 نقطة. يضبط [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) على ثابت و[solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) إلى اللون الأحمر للخلية `(2, 3)`, في العمود الثالث والصف الرابع.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **إضافة صورة داخل خلية جدول**

ضع صورة الإدخال في دليل العمل قبل تشغيل هذا المثال. يقوم بتحميل الصورة باستخدام [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) ويضيفها إلى مجموعة صور العرض التقديمي عبر [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/). ثم يعين الصورة إلى تعبئة الصورة للخلية `(0, 0)`, الخلية الأولى في الجدول.

يمدد [PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) الصورة لملء الخلية، مما قد يغير نسبة أبعادها. تُحدد أعمدة العرض وارتفاع الصفوف بالنقاط. تُصرف الصورة المحمَّلة تلقائيًا عند انتهاء كتلة `with`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    with slides.Images.from_file("aspose_logo.jpg") as image:
        presentation_image = presentation.images.add_image(image)

    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("table_cell_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**هل يمكنني تعيين سماكات وأنماط خطوط مختلفة لجوانب خلية واحدة؟**

نعم. للحدود العليا [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)، السفلية [bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)، اليسرى [left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)، واليمنى [right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) خصائص منفصلة، لذا يمكن أن تختلف السماكة والنمط لكل جانب.

**ماذا يحدث للصورة إذا غيرت حجم العمود/الصف بعد تعيين صورة كخلفية للخلية؟**

السلوك يعتمد على [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (تمدد/تكرار). عند التمدد، تضبط الصورة لتناسب الخلية الجديدة؛ عند التكرار، تُعاد حساب مربعات التكرار.

**هل يمكنني إرفاق رابط تشعبي لكامل محتوى الخلية؟**

يتم ضبط [Hyperlinks](/slides/ar/python-net/manage-hyperlinks/) على مستوى الجزء النصي داخل إطار نص الخلية أو على مستوى الجدول/الشكل بأكمله. عمليًا، يمكنك إرفاق الرابط إلى جزء أو إلى كل النص داخل الخلية.

**هل يمكنني تعيين خطوط مختلفة داخل خلية واحدة؟**

نعم. يدعم إطار نص الخلية [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (تشغيلات) بتنسيق مستقل—عائلة الخط، النمط، الحجم، واللون.