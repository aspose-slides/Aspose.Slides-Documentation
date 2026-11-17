---
title: إدارة خلايا الجداول في العروض التقديمية باستخدام Python
linktitle: إدارة الخلايا
type: docs
weight: 30
url: /ar/python-net/manage-cells/
keywords:
- خلية جدول
- دمج خلايا
- إزالة الحد
- تقسيم خلية
- صورة في الخلية
- لون الخلفية
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إدارة خلايا جداول PowerPoint في Python: تحديد الخلايا المدمجة، إزالة الحدود، تقسيم الخلايا، وتعيين ألوان الخلفية والصور باستخدام Aspose.Slides للـ Python عبر .NET."
---
## **نظرة عامة**

Aspose.Slides يتيح لك الوصول إلى خلايا الجداول وتعديلها في عروض PowerPoint التقديمية. يشرح هذا المقال كيف تقوم بتحديد خلايا الجداول المدمجة، إزالة حدود الخلية، التعامل مع ترقيم الخلايا بعد دمجها أو تقسيمها، تغيير لون خلفية الخلية، وإضافة صورة داخل خلية جدول. تُظهر الأمثلة كيفية إنشاء أو فتح عرض تقديمي، الحصول على جدول من شريحة، تحديث تنسيق الخلية عبر خصائص الخلية، وحفظ العرض المعدل كملف PPTX.

Aspose.Slides يستخدم فهارس تبدأ من الصفر. الإحداثيات في هذا المقال مكتوبة كـ `(column, row)`.

## **تحديد خلية جدول مدمجة**

يفتح المثال عرض تقديمي موجود ويصل إلى الشكل الأول في الشريحة الأولى كجدول. يفترض أن الشريحة والشكل موجودان وأن الشكل جدول. ثم يتنقل عبر جميع الصفوف والأعمدة ويستخدم [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) لتحديد الخلايا في مناطق مدمجة. لكل تطابق، يطبع إحداثيات الخلية بترتيب `row;column`، [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/)، [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/)، وإحداثيات بداية المنطقة، [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) و [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/).

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

إنشاء [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وإضافة جدول إلى شريحته الأولى باستخدام [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/). يتم تحديد عرض الأعمدة، ارتفاع الصفوف، وموقع الجدول بالنقاط. يضبط المثال جميع الحدود الأربعة للخلية إلى [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), مما يجعلها غير مرئية.

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

## **إضافة حدود قطرية للخلية**

استخدم [border_diagonal_down](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_down/) لرسم خط من الزاوية العليا اليسرى إلى الزاوية السفلى اليمنى، واستخدم [border_diagonal_up](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_up/) لرسم خط من الزاوية السفلى اليسرى إلى الزاوية العليا اليمنى. يمكن للخط القطري أن يميز رأسًا زاويًا؛ كلا الخطين يمكن أن يشكلا X لتحديد الخلية بأنها غير قابلة للتطبيق.

كل قطر هو [LineFormat](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/). في خاصية [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/), اضبط [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) إلى [FillType.SOLID](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) واختر [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/). اضبط [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) للخط بالنقاط.

ينشئ المثال ثلاث خلايا في صف واحد: قطري سفلي أحمر، قطري علوي أزرق، وكلا القطرين. يترك حدود الخلية العليا، السفلى، اليسرى، واليمنى دون تغيير.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [210, 210, 210]
    row_heights = [160]
    table = slide.shapes.add_table(45, 130, column_widths, row_heights)

    downward_border = table.rows[0][0].cell_format.border_diagonal_down
    downward_border.fill_format.fill_type = slides.FillType.SOLID
    downward_border.fill_format.solid_fill_color.color = slides.Color.red
    downward_border.width = 3

    upward_border = table.rows[0][1].cell_format.border_diagonal_up
    upward_border.fill_format.fill_type = slides.FillType.SOLID
    upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    upward_border.width = 5

    cross_downward_border = table.rows[0][2].cell_format.border_diagonal_down
    cross_downward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_downward_border.fill_format.solid_fill_color.color = slides.Color.red
    cross_downward_border.width = 3

    cross_upward_border = table.rows[0][2].cell_format.border_diagonal_up
    cross_upward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    cross_upward_border.width = 5

    presentation.save("diagonal_cell_borders.pptx", slides.export.SaveFormat.PPTX)
```

القطري هو خاصية تنسيق، ليس تقسيمًا للخلية. كل خلية تحتفظ بـ [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) واحدة؛ ولا يمكن تحرير المناطق على جانبي القطر بشكل مستقل.

The saved table, rendered in Microsoft PowerPoint:

![ثلاث خلايا جدول تُظهر قطريًا أحمر من الأعلى اليسار إلى الأسفل اليمين، قطريًا أزرق من الأسفل اليسار إلى الأعلى اليمين، وكلا القطرين يشكلان X.](diagonal-cell-borders.png)

*من اليسار إلى اليمين: قطري سفلي (أحمر، 3 نقطة)، قطري علوي (أزرق، 5 نقاط)، وكلا القطرين.*

## **دمج خلايا الجدول**

استخدم [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) لدمج نطاق مستطيل من خلايا الجدول في خلية واحدة. حدد الخلايا في الزوايا العليا اليسرى والسفلى اليمنى للنطاق. المتغيّر الأخير يتحكم فيما إذا كان الدمج قد يشمل خلايا خارج النطاق المحدد؛ `False` يبقي الدمج داخل ذلك النطاق.

ينشئ المثال جدولًا 4×4 بأعمدة وصفوف عرضها 70 نقطة، ثم يدمج الأربع خلايا المركزية من `(1, 1)` إلى `(2, 2)`. الخلية الناتجة تمتد عبر عمودين وصفين، بينما يظل شبكة الجدول الأساسية تحتوي على أربعة أعمدة وأربعة صفوف. للوصول إلى محتوى أو تنسيق الخلية المدمجة، استخدم موضعها العلوي الأيسر: `table.rows[1][1]` في هذا المثال. تبقى المواضع الأخرى في النطاق المدمج جزءًا من شبكة الجدول، لذا لا تتغير فهارس الخلايا خارج النطاق.

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

يحافظ دمج الخلايا في المثال السابق على شبكة الجدول. تقسيم خلية قد يُدخل عمود شبكة جديد ويُغيّر فهارس الأعمدة للخلايا التي على يمينها. تتبع Aspose.Slides نموذج شبكة جدول PowerPoint.

هذا المثال ينشئ جدولًا 4×4 بأعمدة وصفوف عرضها 70 نقطة ويستدعي [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) على الخلية `(1, 1)`. يتم تمرير نصف عرض الخلية البالغ 70 نقطة لإنشاء خليتين بعرض متساوٍ.

بعد هذا التقسيم، يتم الوصول إلى النصفين كـ `table.rows[1][1]` و `table.rows[1][2]`. الآن تحتوي شبكة الجدول على خمسة أعمدة: الخلايا التي كانت في الأعمدة 2 و3 تنتقل إلى الأعمدة 3 و4 على التوالي. تظل فهارس الصفوف دون تغيير. استخدم هذه الفهارس المحدثة للأعمدة عند الوصول إلى الخلايا بعد التقسيم.

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

<!-- visual-explanation:manage-cells:start -->
[![خلية غير مدمجة عرضها 70 نقطة تنقسم إلى خليتين كل منهما عرضها 35 نقطة، مما يضيف عمود شبكة خامس ويُحرك الفهارس إلى يمينها.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*تقسيم العرض يؤثر على الخلية (1, 1)، باستخدام فهارس (column, row) التي تبدأ من الصفر. الصفوف الأخرى تحتفظ بخلية تمتد عبر كلّ الموقعين الجديدين للعمود.*
<!-- visual-explanation:manage-cells:end -->

### **تقسيم الخلايا المدمجة حسب امتداد الصف أو العمود**

لتحضير خلايا القالب المدمجة للتعبئة بالبيانات، استخدم [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) لتقسيم على طول حد الصف الموجود، أو [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) لتقسيم على طول حد العمود.

المعامل `index` يُحصي الصفوف في الجزء العلوي أو الأعمدة في الجزء الأيسر من التقسيم؛ وهو نسبي للمنطقة المدمجة:

- تقسيم الصف: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- تقسيم العمود: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

يفترض المثال وجود عرض تقديمي يحتوي على جدول كشكل أول في الشريحة الأولى، مع دمج رأسي للخلية `(1, 2)` و `(1, 3)`. بدءًا من الموضع الأسفل، يستخدم [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) و [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) لتحديد الأصل ويتحقق من كلا الامتدادين. `split_by_row_span` بقيمة مؤشر 1 ثم يفصل الصفين 2 و3 لأسماء المنتجات. للدمج الأفقي ذي عمودين، استخدم `split_by_col_span` بمؤشر 1 بدلاً من ذلك.

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

        # استرجاع الخلايا الناتجة من الجدول بعد التقسيم.
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

تظل شبكة الجدول والفهارس المحيطة بالخلايا دون تغيير. استرجع الخلايا الناتجة بحسب إحداثياتها؛ هنا، كلاهما يمتد بواحد وتعيد [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) القيمة `False`. يمكن أن تبقى المناطق الأكبر مدمجة جزئيًا بعد تقسيم واحد.

النص الأصلي وتنسيقه يبقى في الخلية العليا (أو اليسرى)؛ الخلية الجديدة فارغة لكنها ترث تنسيق الخلية مثل التعبئة، الحدود والهوامش. قم بملء الخلايا بعد التقسيم وضع أي تنسيق نص مطلوب صراحةً.

العرض المحفوظ يحتوي على خلايا "Product A" و "Product B" منفصلة مع الحفاظ على تنسيق خلية القالب. راجع [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) للمزيد من التفاصيل.

### **تقسيم خلية بارتفاع محدد**

يأخذ [split_by_height](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_height/) ارتفاع الجزء العلوي بالنقاط. يأخذ [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) عدد صفوف الشبكة الموجودة في الجزء العلوي. لتوسيط خلية بارتفاع 40 نقطة عموديًا في العمود الأيمن، اطرح 40 من ارتفاع الخلية الفعلي ووزع المساحة المتبقية بالتساوي فوقها وتحتها.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [160, 160]
    row_heights = [140]
    
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Left"

    height = table.rows[0][1].height
    margin = (height - 40) / 2

    table.rows[0][1].split_by_height(margin)
    table.rows[1][1].split_by_height(40)
    table.rows[1][1].text_frame.text = "Middle"

    presentation.save("split_by_height.pptx", slides.export.SaveFormat.PPTX)
```

الإضافة الأولى للتقسيم تضيف صفًا شبكيًا، وتترك 90 نقطة أسفل في `table.rows[1][1]`. التقسيم الثاني يقسم تلك الخلية إلى خلية وسط بارتفاع 40 نقطة وخلية سفلية بارتفاع 50 نقطة. الآن الخلايا الثلاث في العمود الأيمن هي 50، 40، و50 نقطة ارتفاعًا من الأعلى إلى الأسفل. الخلية اليسرى تمتد عبر جميع الصفوف الثلاثة بارتفاعها الأصلي 140 نقطة.

![الخلية اليسرى تمتد عبر ارتفاع الجدول بالكامل بجانب ثلاث خلايا مع الخلية المتوسطة في الوسط.](split-by-height.png)

## **تغيير لون خلفية خلية الجدول**

ينشئ هذا المثال جدولًا بأعمدة عرضها 150 نقطة وصفوف بارتفاع 50 نقطة. يضبط [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) إلى صلب و[solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) إلى الأحمر للخلية `(2, 3)`, في العمود الثالث والصف الرابع.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = slides.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **إضافة صورة داخل خلية جدول**

ضع صورة الإدخال في دليل العمل قبل تشغيل هذا المثال. يقوم بتحميل الصورة باستخدام [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) ويضيفها إلى مجموعة صور العرض باستخدام [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/). ثم يعين الصورة إلى تعبئة الصورة للخلية `(0, 0)`, الخلية الأولى في الجدول.

تُمد [PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) الصورة لتملأ الخلية، مما قد يغير نسبة العرض إلى الارتفاع. عرض الأعمدة وارتفاع الصفوف بالنقاط. تُصرف الصورة المحملة تلقائيًا عند انتهاء بلوك `with` الخاص بها.

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

## **الأسئلة الشائعة**

**هل يمكنني ضبط سماكات خطوط وأنماط مختلفة لجوانب مختلفة من خلية واحدة؟**

نعم. الحدود [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) لها خصائص منفصلة، لذا يمكن أن يختلف السماك والنمط لكل جانب.

**ماذا يحدث للصورة إذا قمت بتغيير حجم العمود/الصف بعد تعيين صورة كخلفية للخلية؟**

السلوك يعتمد على [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). مع التمدد، تتكيف الصورة مع الخلية الجديدة؛ ومع التبليط، يتم إعادة حساب البلاطات.

**هل يمكنني تعيين ارتباط تشعبي لكامل محتوى الخلية؟**

[Hyperlinks](/slides/ar/python-net/manage-hyperlinks/) تُضبط على مستوى النص (جزء) داخل إطار نص الخلية أو على مستوى الجدول/الشكل بأكمله. عمليًا، تقوم بتعيين الرابط إلى جزء أو إلى كل النص في الخلية.

**هل يمكنني ضبط خطوط مختلفة داخل خلية واحدة؟**

نعم. يدعم إطار نص الخلية [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (runs) بتنسيق مستقل — عائلة الخط، النمط، الحجم، واللون.