---
title: إدارة خلايا الجداول في العروض التقديمية باستخدام بايثون
linktitle: إدارة الخلايا
type: docs
weight: 30
url: /ar/python-java/manage-cells/
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
description: "إدارة خلايا جداول PowerPoint في بايثون: تحديد الخلايا المدمجة، إزالة الحدود، تقسيم الخلايا، وتعيين ألوان الخلفية والصور باستخدام Aspose.Slides لبايثون عبر جافا."
---
## **نظرة عامة**

يتيح لك Aspose.Slides الوصول إلى خلايا الجداول وتعديلها في عروض PowerPoint التقديمية. يشرح هذا المقال كيفية تحديد الخلايا المدمجة في الجدول، وإزالة حدود الخلية، والعمل مع ترقيم الخلايا بعد دمجها أو تقسيمها، وتغيير لون خلفية الخلية، وإضافة صورة داخل خلية جدول. تُظهر الأمثلة كيفية إنشاء أو فتح عرض تقديمي، الحصول على جدول من شريحة، تحديث تنسيق الخلية عبر خصائص الخلية، وحفظ العرض المعدل كملف PPTX.

يستخدم Aspose.Slides مؤشرات تبدأ من الصفر للوصول إلى خلايا الجداول بالترتيب `(column, row)`.

## **تحديد خلية جدول مدمجة**

يفتح المثال عرضًا تقديميًا موجودًا ويصل إلى الشكل الأول في الشريحة الأولى كجدول. يفترض أن الشريحة والشكل موجودان وأن الشكل هو جدول. ثم يكرر عبر جميع الصفوف والأعمدة ويستخدم [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) لتحديد الخلايا في المناطق المدمجة. لكل تطابق، يطبع إحداثيات الخلية بترتيب `row;column`، و[getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan)، و[getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan)، وإحداثيات بداية المنطقة، [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) و[getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation_with_table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    row_count = table.getRows().size()
    for row_index in range(row_count):
        column_count = table.getColumns().size()
        for column_index in range(column_count):
            cell = table.get_Item(column_index, row_index)
            if cell.isMergedCell():
                print(f"Cell {row_index};{column_index} belongs to a merged region with RowSpan={cell.getRowSpan()} and ColSpan={cell.getColSpan()} starting at {cell.getFirstRowIndex()};{cell.getFirstColumnIndex()}.")
finally:
    presentation.dispose()
```

## **إزالة حدود خلايا الجدول**

أنشئ [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) وأضف جدولًا إلى الشريحة الأولى باستخدام [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable). يتم تحديد عرض الأعمدة، ارتفاع الصفوف، وموقع الجدول بالنقاط. يضبط المثال جميع حدود الخلية الأربعة إلى [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/)، مما يجعلها غير مرئية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **إضافة حدود خلية مائلة**

استخدم [getBorderDiagonalDown](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalDown) لرسم خط من الزاوية العلوية اليسرى إلى الزاوية السفلية اليمنى، و[getBorderDiagonalUp](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalUp) لرسم خط من الزاوية السفلية اليسرى إلى الزاوية العلوية اليمنى. يمكن للخط المائل أن يميز عنوانًا زاوية. يمكن للخطين معًا تشكيل X لتحديد الخلية كغير صالحة.

كل خط مائل هو كائن من نوع [LineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/). في خاصية [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat)، استخدم [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) لاختيار [FillType.Solid](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) وتحديد لون عبر [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor). اضبط عرض الخط بالنقاط باستخدام [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth).

ينشئ المثال ثلاثة خلايا في صف واحد: خط مائل نزولي أحمر، خط مائل صاعد أزرق، وكلا الخطين معًا. يترك حدود الخلية العلوية والسفلية واليسرى واليمنى دون تغيير.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color


def format_border(border, color, width):
    fill = border.getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setColor(color)
    border.setWidth(width)


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(45, 130, [210, 210, 210], [160])

    left_cell = table.get_Item(0, 0).getCellFormat()
    middle_cell = table.get_Item(1, 0).getCellFormat()
    right_cell = table.get_Item(2, 0).getCellFormat()
    format_border(left_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(middle_cell.getBorderDiagonalUp(), Color.BLUE, 5)
    format_border(right_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(right_cell.getBorderDiagonalUp(), Color.BLUE, 5)

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

الخط المائل هو خاصية تنسيق، ليست تقسيمًا للخلية. تحتفظ كل خلية بإطار نص واحد، يمكن الوصول إليه عبر [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame). لا يمكن تحرير المناطق على جانبي الخط المائل بشكل مستقل.

الجدول المحفوظ، معروض في Microsoft PowerPoint:
![ثلاث خلايا جدول تُظهر خطًا مائلًا أحمر من أعلى اليسار إلى أسفل اليمين، وخطًا مائلًا أزرق من أسفل اليسار إلى أعلى اليمين، وكلا الخطين معًا يشكلان X.](diagonal-cell-borders.png)

*من اليسار إلى اليمين: خط مائل نزولي (أحمر، 3 pt)، خط مائل صاعد (أزرق، 5 pt)، وكلا الخطين معًا.*

## **دمج خلايا الجدول**

استخدم [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) لدمج نطاق مستطيل من خلايا الجدول في خلية واحدة. حدد الخلايا في الزاويتين العلوية اليسرى والسفلية اليمنى للنطاق. يتحكم الوسيط الأخير فيما إذا كان الدمج قد يشمل خلايا خارج النطاق المحدد؛ `False` يبقي الدمج داخل ذلك النطاق.

ينشئ المثال جدولًا بحجم 4×4 بأعمدة وصفوف بعرض 70 نقطة، ثم يدمج الأربع خلايا المركزية من `(1, 1)` حتى `(2, 2)`. الخلية الناتجة تمتد عبر عمودين وصفين، بينما يحتفظ شبكة الجدول الأساسية بأربعة أعمدة وأربعة صفوف. للوصول إلى محتوى أو تنسيق الخلية المدمجة، استخدم موقعها العلوي الأيسر: `table.get_Item(1, 1)` في هذا المثال. تبقى المواضع الأخرى في النطاق المدمج جزءًا من شبكة الجدول، لذا لا تتغير فهارس الخلايا خارج النطاق.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), False)

    presentation.save("merged_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تقسيم خلايا الجدول**

الحفاظ على دمج الخلايا في المثال السابق يحافظ على شبكة الجدول. قد يؤدي تقسيم خلية إلى إدخال عمود شبكة جديد وتغيير فهارس الأعمدة للخلايا التي على يمينها. يتبع Aspose.Slides نموذج شبكة جدول PowerPoint.

ينشئ هذا المثال جدولًا بحجم 4×4 بأعمدة وصفوف بعرض 70 نقطة ويستدعي [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) على الخلية `(1, 1)`. تُمرَّر نصف عرض الخلية البالغ 70 نقطة لإنشاء خلايا ذات عرض متساوٍ.

بعد هذا التقسيم، يتم الوصول إلى النصفين عبر `table.get_Item(1, 1)` و`table.get_Item(2, 1)`. أصبحت شبكة الجدول الآن تحتوي على خمسة أعمدة: الخلايا التي كانت في الأعمدة 2 و3 تنتقل إلى الأعمدة 3 و4 على التوالي. تظل فهارس الصفوف دون تغيير. استخدم فهارس الأعمدة المحدثة عند الوصول إلى الخلايا بعد التقسيم.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2)

    presentation.save("split_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

<!-- visual-explanation:manage-cells:start -->
[![خلية غير مدمجة بعرض 70 نقطة تنقسم إلى خليتين بعرض 35 نقطة، مضافة عمود شبكة خامس وتحريك الفهارس إلى يمينها.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*تقسيم العرض يؤثر على الخلية (1, 1)، باستخدام فهارس (العمود، الصف) التي تبدأ من الصفر. الصفوف الأخرى تحافظ على خلية تمتد عبر موضعى العمودين الجديدين.*
<!-- visual-explanation:manage-cells:end -->

### **تقسيم الخلايا المدمجة حسب امتداد الصف أو العمود**

لتحضير خلايا القالب المدمجة لتعبئة البيانات، استخدم [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) للتقسيم على طول حد صف موجود، أو [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) للتقسيم على طول حد عمود.

المعامل `index` يحصي الصفوف في الجزء العلوي أو الأعمدة في الجزء الأيسر من التقسيم؛ وهو نسبي للمنطقة المدمجة:

- تقسم الصف: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- تقسم العمود: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

يفترض المثال وجود عرض تقديمي يحتوي على جدول كشكل أول في الشريحة الأولى، مع دمج الخلايا `(1, 2)` و`(1, 3)` عموديًا. بدءًا من الموضع الأدنى، يستخدم [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) و[getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) لتحديد الأصل ويتحقق من كلا الامتدادين. ثم يقوم `splitByRowSpan(1)` بفصل الصفين 2 و3 لأسماء المنتجات. لدمج عمودين أفقيًا، استخدم `splitByColSpan(1)` بدلاً من ذلك.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table_template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    selected_cell = table.get_Item(1, 3)
    first_column_index = selected_cell.getFirstColumnIndex()
    first_row_index = selected_cell.getFirstRowIndex()
    merged_cell = table.get_Item(first_column_index, first_row_index)

    if merged_cell.isMergedCell() and merged_cell.getRowSpan() == 2 and merged_cell.getColSpan() == 1:
        merged_cell.splitByRowSpan(1)

        # استرجاع الخلايا الناتجة من الجدول بعد التقسيم.
        upper_cell = table.get_Item(first_column_index, first_row_index)
        lower_cell = table.get_Item(first_column_index, first_row_index + 1)
        print(f"Upper cell merged: {upper_cell.isMergedCell()}")
        print(f"Lower cell merged: {lower_cell.isMergedCell()}")

        upper_cell.getTextFrame().setText("Product A")
        lower_cell.getTextFrame().setText("Product B")

        presentation.save("split_template.pptx", SaveFormat.Pptx)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
finally:
    presentation.dispose()
```

تظل شبكة الجدول وفهارس الخلايا المحيطة دون تغيير. استرجع الخلايا الناتجة باستخدام إحداثياتها؛ هنا، كلاهما يمتد بامتداد 1 و[isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) يطبع `False`. يمكن أن تبقى المناطق الأكبر مدمجة جزئيًا بعد تقسيم واحد.

يبقى النص الأصلي وتنسيقه في الخلية العليا (أو اليسرى)؛ الخلية الجديدة تكون فارغة لكنها ترث تنسيق الخلية مثل التعبئة والحدود والهوامش. قم بملء الخلايا بعد التقسيم وضع أي تنسيق نص مطلوب صراحة.

العرض المحفوظ يحتوي على خلايا منفصلة "Product A" و"Product B" مع الحفاظ على تنسيق خلية القالب. راجع [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) للحصول على التفاصيل.

### **تقسيم خلية بارتفاع محدد**

[splitByHeight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByHeight) يأخذ ارتفاع الجزء العلوي بالنقاط. [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) يأخذ عدد صفوف الشبكة الحالية في الجزء العلوي. لتوسيط خلية بارتفاع 40 نقطة في العمود الأيمن، اطرح 40 من الارتفاع الفعلي للخلية وقسّم المساحة المتبقية بالتساوي فوقها وتحتها.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().addTable(50, 50, [160, 160], [140])
    table.get_Item(0, 0).getTextFrame().setText("Left")

    height = table.get_Item(1, 0).getHeight()
    margin = (height - 40) / 2
    
    table.get_Item(1, 0).splitByHeight(margin)
    table.get_Item(1, 1).splitByHeight(40)
    table.get_Item(1, 1).getTextFrame().setText("Middle")

    presentation.save("split_by_height.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

يضيف التقسيم الأول صفًا في الشبكة ويترك 90 نقطة في أسفل الخلية `(1, 1)`. يقسم التقسيم الثاني تلك الخلية إلى خلية وسطى بارتفاع 40 نقطة وخلية سفلية بارتفاع 50 نقطة. يحتوي العمود الأيمن الآن على ثلاث خلايا بارتفاعات 50 و40 و50 نقطة من أعلى إلى أسفل. الخلية اليسرى تمتد عبر جميع الصفوف الثلاثة وتحتفظ بارتفاعها الأصلي 140 نقطة.

![الخلية اليسرى تمتد على طول ارتفاع الجدول بالكامل بجوار ثلاث خلايا مع وسط في المركز.](split-by-height.png)

## **تغيير لون خلفية خلية الجدول**

ينشئ هذا المثال جدولًا بأعمدة بعرض 150 نقطة وصفوف بعرض 50 نقطة. يستخدم [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) لاختيار تعبئة صلبة ويضبط اللون الذي تُعيده [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) إلى الأحمر للخلية `(2, 3)`، في العمود الثالث والصف الرابع.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **إضافة صورة داخل خلية جدول**

ضع صورة الإدخال في دليل العمل قبل تشغيل هذا المثال. يقوم بتحميل الصورة باستخدام [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) ويضيفها إلى مجموعة صور العرض باستخدام [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). ثم يعيّن الصورة لتعبئة الصورة للخلية `(0, 0)`, وهي الخلية الأولى في الجدول.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) يمدّد الصورة لملء الخلية، مما قد يغيّر نسبة الأبعاد. عرض الأعمدة وارتفاع الصفوف يُقاس بالنقاط. تُفرغ الصورة المحمّلة في كتلة `finally` بعد إضافتها إلى العرض.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    image = Images.fromFile("aspose_logo.jpg")
    try:
        presentation_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**هل يمكنني تعيين سماكات خطوط وأنماط مختلفة للجوانب المختلفة لخلية واحدة؟**

نعم. للحدود [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) خصائص منفصلة، لذا يمكن أن تختلف سماكة ونمط كل جانب.

**ماذا يحدث للصورة إذا قمت بتغيير حجم العمود/الصف بعد تعيين صورة كخلفية للخلية؟**

يعتمد السلوك على [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/). مع التمدد، تتكيف الصورة مع الخلية الجديدة؛ مع التكرار، يتم إعادة حساب البلاط.

**هل يمكنني تعيين ارتباط تشعبي لجميع محتوى الخلية؟**

[Hyperlinks](/slides/ar/python-java/manage-hyperlinks/) تُعيّن على مستوى النص (الجزء) داخل إطار نص الخلية أو على مستوى الجدول/الشكل بالكامل. عمليًا، تعيّن الرابط إلى جزء أو إلى كل النص في الخلية.

**هل يمكنني تعيين خطوط مختلفة داخل خلية واحدة؟**

نعم. يدعم إطار نص الخلية [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (مقاطع) بتنسيق مستقل—عائلة الخط، النمط، الحجم، واللون.