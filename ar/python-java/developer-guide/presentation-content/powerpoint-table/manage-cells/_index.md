---
title: إدارة خلايا الجداول في العروض التقديمية باستخدام Python
linktitle: إدارة الخلايا
type: docs
weight: 30
url: /ar/python-java/manage-cells/
keywords:
- خلية جدول
- دمج خلايا
- إزالة حدود
- تقسيم خلية
- صورة في خلية
- لون خلفية
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "قم بإدارة خلايا الجداول في PowerPoint بسهولة باستخدام Aspose.Slides لبايثون عبر Java. اتقن الوصول إلى الخلايا، تعديلها وتنسيقها بسرعة لتحقيق أتمتة شرائح سلسة."
---
## **نظرة عامة**

تسمح لك Aspose.Slides بالوصول إلى خلايا الجداول وتعديلها في عروض PowerPoint. يشرح هذا المقال كيفية تحديد الخلايا المدمجة في الجدول، إزالة حدود الخلية، التعامل مع ترقيم الخلايا بعد الدمج أو الفصل، تغيير لون خلفية الخلية، وإضافة صورة داخل خلية الجدول. توضح الأمثلة كيفية إنشاء أو فتح عرض تقديمي، الحصول على جدول من شريحة، تحديث تنسيق الخلية عبر خصائص الخلية، وحفظ العرض المعدل كملف PPTX.

## **تحديد خلية جدول مدمجة**

1. إنشاء مثال من الفئة [العرض](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. الحصول على الجدول من الشريحة الأولى.
3. التكرار عبر صفوف وأعمدة الجدول للعثور على الخلايا المدمجة.
4. طباعة رسالة عند العثور على خلايا مدمجة.

يظهر هذا الكود بلغة Python كيفية تحديد الخلايا المدمجة في عرض تقديمي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation("SomePresentationWithTable.pptx")
try:
    # افترض أن الشكل الأول في الشريحة الأولى هو جدول.
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        for i in range(table.getRows().size()):
            for j in range(table.getColumns().size()):
                current_cell = table.getRows().get_Item(i).get_Item(j)
                if current_cell.isMergedCell():
                    print(f"Cell {i};{j} is part of a merged cell with RowSpan={current_cell.getRowSpan()} and ColSpan={current_cell.getColSpan()} starting from Cell {current_cell.getFirstRowIndex()};{current_cell.getFirstColumnIndex()}.")
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **إزالة حدود خلية الجدول**

1. إنشاء مثال من الفئة [العرض](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. الحصول على إشارة إلى شريحة بواسطة فهرسها.
3. تعريف قائمة بعروض الأعمدة.
4. تعريف قائمة بارتفاعات الصفوف.
5. إضافة جدول إلى الشريحة عبر طريقة [addTable](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addTable) .
6. التكرار عبر كل خلية لمسح الحدود العلوية والسفلية واليمنى واليسرى.
7. حفظ العرض المعدل كملف PPTX.

يظهر هذا الكود بلغة Python كيفية إزالة الحدود من خلايا الجدول:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    # الوصول إلى الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    # تحديد عروض الأعمدة وارتفاعات الصفوف.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # إضافة جدول إلى الشريحة.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # تعيين تنسيق الحدود لكل خلية.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    # حفظ العرض التقديمي كملف PPTX.
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الترقيم في الخلايا المدمجة**

إذا دمجنا زوجين من الخلايا، (1, 1) و(2, 1)، و(1, 2) و(2, 2)، يحتفظ الجدول الناتج بترقيم خلاياه. يوضح هذا الكود بلغة Python العملية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # الوصول إلى الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    # تحديد عروض الأعمدة وارتفاعات الصفوف.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # إضافة جدول إلى الشريحة.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # تعيين تنسيق الحدود لكل خلية.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # دمج الخلايا (1, 1) و (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # دمج الخلايا (1, 2) و (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # حفظ العرض التقديمي كملف PPTX.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

بعد ذلك ندمج الخلايا أكثر بدمج (1, 1) و(1, 2). النتيجة جدول يحتوي على خلية مدمجة كبيرة في مركزه:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # الوصول إلى الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    # تحديد عروض الأعمدة وارتفاعات الصفوف.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # إضافة جدول إلى الشريحة.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # تعيين تنسيق الحدود لكل خلية.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # دمج الخلايا (1, 1) و (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # دمج الخلايا (1, 2) و (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # دمج الخلايا (1, 1) و (1, 2).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(1, 2), True)

    # حفظ العرض التقديمي كملف PPTX.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الترقيم في خلية مُقسَّمة**

في الأمثلة السابقة، لم يغيّر دمج خلايا الجدول ترقيم الخلايا الأخرى.

هذه المرة، نأخذ جدولًا عاديًا (جدول بدون خلايا مدمجة) ثم نحاول تقسيم الخلية (1, 1) للحصول على جدول خاص. قد ترغب في إيلاء انتباه خاص لترقيم هذا الجدول، الذي قد يبدو غريبًا. ومع ذلك، هذه هي الطريقة التي يرقم بها Microsoft PowerPoint خلايا الجدول ويقوم Aspose.Slides بنفس الأمر.

يُظهر هذا الكود بلغة Python العملية التي وصفناها:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # الوصول إلى الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    # تحديد عروض الأعمدة وارتفاعات الصفوف.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # إضافة جدول إلى الشريحة.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # تعيين تنسيق الحدود لكل خلية.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # تقسيم الخلية (1, 1).
    table.get_Item(1, 1).splitByWidth(table.get_Item(2, 1).getWidth() / 2)

    # حفظ العرض التقديمي كملف PPTX.
    presentation.save("SplitCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تغيير لون خلفية خلية الجدول**

يظهر هذا الكود بلغة Python كيفية تغيير لون خلفية خلية الجدول:

```python
import jpype
import asposeslides

if not jpage.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # الوصول إلى الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    # تحديد عروض الأعمدة وارتفاعات الصفوف.
    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # إضافة جدول إلى الشريحة.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # تعيين لون خلفية خلية.
    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # حفظ العرض التقديمي كملف PPTX.
    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **إضافة صورة داخل خلية الجدول**

1. إنشاء مثال من الفئة [العرض](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. الحصول على إشارة إلى شريحة بواسطة فهرسها.
3. تعريف قائمة بعروض الأعمدة.
4. تعريف قائمة بارتفاعات الصفوف.
5. إضافة جدول إلى الشريحة عبر طريقة [addTable](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addTable) .
6. تحميل ملف الصورة باستخدام [Images.fromFile](https://reference.aspose.com/slides/ar/python-java/aspose.slides/images/#fromFile) .
7. إضافة الصورة إلى العرض لإنشاء كائن [PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/) .
8. تعيين نوع ملء خلية الجدول عبر خاصية [FillFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fillformat/) إلى [FillType.Picture](https://reference.aspose.com/slides/ar/python-java/aspose.slides/filltype/#Picture) .
9. إضافة الصورة إلى الخلية الأولى في الجدول.
10. حفظ العرض المعدل كملف PPTX.

يظهر هذا الكود بلغة Python كيفية وضع صورة داخل خلية جدول أثناء إنشاء جدول:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    # الوصول إلى الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    # تحديد عروض الأعمدة وارتفاعات الصفوف.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]

    # إضافة جدول إلى الشريحة.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # إنشاء صورة عرض تقديمي من ملف الصورة.
    image = Images.fromFile("image.jpg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # إضافة الصورة إلى الخلية الأولى في الجدول.
    cell_format = table.get_Item(0, 0).getCellFormat()
    cell_format.getFillFormat().setFillType(FillType.Picture)
    cell_format.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    cell_format.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # حفظ العرض التقديمي كملف PPTX.
    presentation.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**هل يمكنني تعيين سماكات وأنماط خطوط مختلفة للجوانب المختلفة لخلية واحدة؟**

نعم. الحدود العليا/[top](https://reference.aspose.com/slides/ar/python-java/aspose.slides/cellformat/#getBorderTop) / السفلية/[bottom](https://reference.aspose.com/slides/ar/python-java/aspose.slides/cellformat/#getBorderBottom) / اليسرى/[left](https://reference.aspose.com/slides/ar/python-java/aspose.slides/cellformat/#getBorderLeft) / اليمنى/[right](https://reference.aspose.com/slides/ar/python-java/aspose.slides/cellformat/#getBorderRight) لها خصائص منفصلة، لذا يمكن أن تختلف السماكة والنمط لكل جانب. وهذا يتماشى منطقيًا مع التحكم في الحدود حسب الجانب للخلية الموضح في المقال.

**ماذا يحدث للصورة إذا غيرت حجم العمود/الصف بعد تعيين صورة كخلفية للخلية؟**

السلوك يعتمد على [وضع الملء](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturefillmode/) (تمدد/بلاط). عند التمدد، تتكيف الصورة مع الخلية الجديدة؛ عند البلاط، يُعاد حساب البلاط. يذكر المقال أوضاع عرض الصورة داخل الخلية.

**هل يمكنني تعيين ارتباط تشعبي لجميع محتويات الخلية؟**

يتم تعيين [الارتباطات التشعبية](/slides/ar/python-java/manage-hyperlinks/) على مستوى النص (الجزء) داخل إطار نص الخلية أو على مستوى الجدول/الشكل بأكمله. عمليًا، يمكنك ربط الجزء أو كل النص في الخلية.

**هل يمكنني تعيين خطوط مختلفة داخل خلية واحدة؟**

نعم. يدعم إطار نص الخلية [الأجزاء](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/) (runs) بتنسيق مستقل—عائلة الخط، النمط، الحجم، واللون.