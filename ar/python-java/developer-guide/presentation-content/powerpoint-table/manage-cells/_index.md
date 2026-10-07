---
title: إدارة خلايا الجداول في العروض التقديمية باستخدام بايثون
linktitle: إدارة الخلايا
type: docs
weight: 30
url: /ar/python-java/manage-cells/
keywords:
- خلية جدول
- دمج خلايا
- إزالة الحدود
- تقسيم خلية
- صورة داخل خلية
- لون الخلفية
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إدارة خلايا جداول PowerPoint في بايثون: تحديد الخلايا المدمجة، إزالة الحدود، تقسيم الخلايا، وتعيين ألوان الخلفية والصور باستخدام Aspose.Slides لبايثون عبر جافا."
---
## **نظرة عامة**

تتيح لك Aspose.Slides الوصول إلى خلايا الجداول وتعديلها في عروض PowerPoint التقديمية. توضح هذه المقالة كيفية تحديد خلايا الجداول المدمجة، وإزالة حدود الخلايا، والعمل مع ترقيم الخلايا بعد دمجها أو تقسيمها، وتغيير لون خلفية الخلية، وإضافة صورة داخل خلية جدول. تُظهر الأمثلة كيفية إنشاء أو فتح عرض تقديمي، الحصول على جدول من شريحة، تحديث تنسيق الخلية من خلال خصائص الخلية، وحفظ العرض المعدل كملف PPTX.

تستخدم Aspose.Slides مؤشرات تبدأ من الصفر للوصول إلى خلايا الجداول بالترتيب `(column, row)`.

## **تحديد خلية جدول مدمجة**

يفتح المثال عرضًا تقديميًا موجودًا ويصل إلى الشكل الأول في الشريحة الأولى باعتباره جدولًا. يفترض أن الشريحة والشكل موجودان وأن الشكل هو جدول. ثم يتنقل عبر جميع الصفوف والأعمدة ويستخدم [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) لتحديد الخلايا في المناطق المدمجة. بالنسبة لكل تطابق، يطبع إحداثيات الخلية بترتيب `row;column`، و[getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan)، و[getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan)، وإحداثيات بداية المنطقة، [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) و[getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex).

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

أنشئ كائن [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) وأضف جدولًا إلى شريكته الأولى باستخدام [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable). يتم تحديد عرض الأعمدة، ارتفاع الصفوف، وموقع الجدول بالنقاط. يضبط المثال جميع حدود الخلية الأربعة إلى [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/)، مما يجعلها غير مرئية.

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

## **دمج خلايا الجدول**

استخدم [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) لدمج نطاق مستطيل من خلايا الجدول في خلية واحدة. حدد الخلايا في الزاوية العلوية اليسرى والزاوية السفلية اليمنى للنطاق. يتحكم الوسيط الأخير فيما إذا كان الدمج قد يشمل خلايا خارج النطاق المحدد؛ `False` يبقي الدمج داخل ذلك النطاق.

يقوم المثال بإنشاء جدول 4×4 بأعمدة وصفوف بحجم 70 نقطة، ثم يدمج الخلايا الأربع المركزية من `(1, 1)` إلى `(2, 2)`. الخلية الناتجة تمتد عبر عمودين وصفين، بينما يحتفظ شبكة الجدول الأساسية بأربعة أعمدة وأربعة صفوف. للوصول إلى محتوى الخلية المدمجة أو تنسيقها، استخدم موقعها العلوي الأيسر: `table.get_Item(1, 1)` في هذا المثال. تظل المواقع الأخرى في النطاق المدمج جزءًا من شبكة الجدول، لذا لا تتغير مؤشرات الخلايا خارج النطاق.

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

يحتفظ دمج الخلايا في المثال السابق بشبكة الجدول. يمكن أن يؤدي تقسيم خلية إلى إدخال عمود شبكة جديد وتغيير مؤشرات الأعمدة للخلايا الموجودة إلى يمينها. تتبع Aspose.Slides نموذج شبكة الجداول في PowerPoint.

ينشئ هذا المثال جدولًا 4×4 بأعمدة وصفوف بحجم 70 نقطة ويستدعي [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) على الخلية `(1, 1)`. يتم تمرير نصف عرض الخلية البالغ 70 نقطة لإنشاء خليتين بعرض متساوٍ.

بعد هذا التقسيم، يتم الوصول إلى النصفين كـ `table.get_Item(1, 1)` و `table.get_Item(2, 1)`. الآن تحتوي شبكة الجدول على خمسة أعمدة: الخلايا التي كانت في الأعمدة 2 و3 تنتقل إلى الأعمدة 3 و4 على التوالي. تبقى مؤشرات الصفوف دون تغيير. استخدم هذه المؤشرات المحدثة للأعمدة عند الوصول إلى الخلايا بعد التقسيم.

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

### **تقسيم الخلايا المدمجة حسب امتداد الصف أو العمود**

لتحضير خلايا القالب المدمجة لتعبئة البيانات، استخدم [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) للتقسيم على طول حد صف موجود، أو [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) للتقسيم على طول حد عمود.

حجة `index` تحسب الصفوف في الجزء العلوي أو الأعمدة في الجزء الأيسر من التقسيم؛ وهي نسبية إلى المنطقة المدمجة:

- تقسيم الصف: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- تقسيم العمود: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

يتوقع المثال أن يحتوي العرض التقديمي على جدول كشكل أول في الشريحة الأولى، مع دمج عمودين عموديًا `(1, 2)` و `(1, 3)`. بدءًا من الموضع السفلي، يستخدم [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) و [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) لتحديد الأصل ويفحص كلا الامتدادين. ثم يقوم `splitByRowSpan(1)` بفصل الصفوف 2 و3 لأسماء المنتجات. للدمج الأفقي لعمودين، استخدم `splitByColSpan(1)` بدلاً من ذلك.

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

تبقى شبكة الجدول ومؤشرات الخلايا المحيطة دون تغيير. استرجع الخلايا الناتجة باستخدام إحداثياتها؛ هنا، كلاهما يمتلك امتدادًا قدره 1 و [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) يُظهر `False`. يمكن أن تظل المناطق الأكبر مدمجة جزئيًا بعد تقسيم واحد.

يبقى النص الأصلي وتنسيقه في الخلية العلوية (أو اليسرى)؛ الخلية الجديدة فارغة لكنها ترث تنسيق الخلية مثل التعبئة والحدود والهوامش. عبء الخلايا بعد التقسيم وعيّن أي تنسيق نص مطلوب صراحةً.

يحتوي العرض التقديمي المحفوظ على خلايا منفصلة "Product A" و "Product B" مع الاحتفاظ بتنسيق خلية القالب. راجع [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) للمزيد من التفاصيل.

## **تغيير لون خلفية خلية الجدول**

يُنشئ هذا المثال جدولًا بأعمدة بطول 150 نقطة وصفوف بطول 50 نقطة. يستخدم [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) لاختيار تعبئة صلبة ويضبط اللون الذي تُعيده [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) إلى اللون الأحمر للخلية `(2, 3)`, في العمود الثالث والصف الرابع.

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

ضع صورة الإدخال في دليل العمل قبل تشغيل هذا المثال. يقوم بتحميل الصورة باستخدام [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) ويضيفها إلى مجموعة صور العرض التقديمي باستخدام [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). ثم يعيّن الصورة إلى تعبئة الصورة للخلية `(0, 0)`, أول خلية في الجدول.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) يمتد الصورة لتملأ الخلية، مما قد يغير نسبة العرض إلى الارتفاع. عرض الأعمدة وارتفاع الصفوف بالنقاط. تُحرّص الصورة المحملة على الإلغاء في كتلة `finally` بعد إضافتها إلى العرض التقديمي.

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

**هل يمكنني ضبط سماكات الخطوط وأنماطها المختلفة لأجزاء مختلفة من خلية واحدة؟**

نعم. حدود [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) لها خصائص منفصلة، لذا يمكن أن تختلف سماكة كل جانب ونمطه.

**ماذا يحدث للصورة إذا قمت بتغيير حجم العمود/الصف بعد تعيين صورة كخلفية للخلية؟**

السلوك يعتمد على [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) (stretch/tile). عند التمدد، تُعدَّل الصورة لتناسب الخلية الجديدة؛ عند التبليط، يتم إعادة حساب البلاطات.

**هل يمكنني تعيين ارتباط تشعبي إلى كل محتوى الخلية؟**

[Hyperlinks](/slides/ar/python-java/manage-hyperlinks/) تُحدد على مستوى النص (الجزء) داخل إطار نص الخلية أو على مستوى الجدول/الشكل بالكامل. عمليًا، تقوم بتعيين الرابط إلى جزء أو إلى كل النص في الخلية.

**هل يمكنني ضبط خطوط مختلفة داخل خلية واحدة؟**

نعم. يدعم إطار نص الخلية [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (تشغيلات) بتنسيق مستقل—عائلة الخط، والستايل، والحجم، واللون.