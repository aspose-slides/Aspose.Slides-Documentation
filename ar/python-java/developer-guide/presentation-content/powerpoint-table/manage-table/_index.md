---
title: إدارة جداول العروض التقديمية في بايثون
linktitle: إدارة الجدول
type: docs
weight: 10
url: /ar/python-java/manage-table/
keywords:
- إضافة جدول
- إنشاء جدول
- الوصول إلى جدول
- نسبة العرض إلى الارتفاع
- محاذاة النص
- تنسيق النص
- نمط الجدول
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إنشاء وتحرير الجداول في شرائح PowerPoint باستخدام Aspose.Slides للبايثون عبر Java. اكتشف أمثلة شفرة بسيطة لتبسيط سير عمل الجداول."
---
## **المقدمة**

تنظم الجداول في PowerPoint المعلومات في صفوف وأعمدة، مما يجعل قراءتها ومقارنة القيم أسهل.

توفر Aspose.Slides الفئات [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) و [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) وأنواع أخرى لتتيح لك إنشاء الجداول وتحديثها وإدارتها في العروض التقديمية.

## **إنشاء جدول من الصفر**

قم بإنشاء جدول عن طريق تحديد موضعه وعرض الأعمدة وارتفاع الصفوف. بعد إضافته إلى شريحة، يمكنك تنسيق حدود الخلايا، دمج الخلايا، وإدراج النص.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة حسب الفهرس.
3. تعريف قائمة بعروض الأعمدة بالنقاط.
4. تعريف قائمة بارتفاعات الصفوف بالنقاط.
5. إضافة كائن [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) إلى الشريحة عبر طريقة [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable).
6. التنقل عبر كل [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) لتطبيق تنسيق الحدود العليا والسفلى واليمين واليسار.
7. دمج الخليتين الأوليين في الصف الأول للجدول.
8. الوصول إلى الخلية المدموجة عبر طريقة [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame).
9. تعيين النص في الخلية المدموجة.
10. حفظ العرض التقديمي المعدل.

المثال أدناه ينشئ جدولًا بثلاثة أعمدة وخمسة صفوف عند النقاط (100, 50). يطبق حدودًا حمراء بعرض 5 نقاط، يدمج الخليتين الأوليين في الصف الأول، ويحفظ النتيجة كملف `table.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), False)
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells")

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الترقيم في جدول قياسي**

في جدول قياسي، تكون مؤشرات الخلايا صفرية وتُستخدم الصيغة (عمود، صف). تُرقم الخلية الأولى كـ (0, 0).

على سبيل المثال، تُرقم الخلايا في جدول يحتوي على 4 أعمدة و4 صفوف بهذه الطريقة:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

هذا المثال ينشئ جدول 4 × 4 الموضح أعلاه، بعرض أعمدة وارتفاع صفوف يبلغ 70 نقطة، وحدود خلية حمراء بعرض 5 نقاط. تُظهر الإحداثيات مؤشرات الخلايا؛ يترك المثال الخلايا فارغة ويحفظ الجدول كملف `StandardTables_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الوصول إلى جدول موجود**

تُخزن الجداول في مجموعة أشكال الشريحة. استعرض الأشكال لتحديد جدول، ثم استخدم فئة [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) لقراءة خلاياه أو تحديثها.

1. تحميل العرض التقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة التي تحتوي على الجدول حسب الفهرس.
3. استعراض كائنات [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) وإيقافه عند العثور على جدول. إذا كانت الشريحة تحتوي على عدة جداول، استخدم [getAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText) لتحديد الجدول المطلوب.
4. تحديث النص في الخلية المستهدفة.
5. حفظ العرض التقديمي المعدل.

المثال أدناه يفتح الملف `UpdateExistingTable.pptx` ويعثر على أول جدول في الشريحة الأولى. يعيّن الخلية في العمود 0، الصف 1 إلى `New` ويحفظ النتيجة كملف `table1_out.pptx`. يجب أن يحتوي الإدخال على شريحة واحدة على الأقل، ويجب أن يحتوي أول جدول في تلك الشريحة على عمود واحد على الأقل وصفين.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("UpdateExistingTable.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = None

    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            break

    if table is not None:
        table.get_Item(0, 1).getTextFrame().setText("New")
        presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

لتغيير حجم صف في جدول موجود وفهم سبب إمكانية تجاوز ارتفاعه الفعلي للحد الأدنى المطلوب، راجع [Control Row Height](/slides/ar/python-java/manage-rows-and-columns/#control-row-height).

## **العثور على الخلية التي تمتلك إطار نص**

عند استلام كود عام لمعالجة النص كائن [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) من جدول، استخدم طريقة [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) لاسترجاع الخلية المالكة [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/). بالنسبة لإطار نص خلية جدول، تُعيد [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) المالك وتُعيد [TextFrame.getParentShape](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentShape) القيمة `None`، رغم أن الجدول نفسه يعتبر شكلًا.

تتوفر إحداثيات الخلية عبر طريقتي القراءة فقط [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) و [Cell.getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex). كما تُوفر [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) تنقلًا للقراءة فقط: تُعيد المالك دون تغيير الملكية. تحقق دائمًا من أن الخلية المُسترجَعة ليست `None` قبل استخدامها.

لمثال كامل يحدد مالكي خلايا الجدول والأشكال، بما في ذلك الأشكال المرتبطة بعقد SmartArt، راجع [Search and Replace Text](/slides/ar/python-java/search-and-replace-text/).

## **محاذاة النص في جدول**

يمكنك التحكم في تثبيت النص عموديًا واتجاهه داخل خلايا الجدول الفردية. المثال في هذا القسم يوسّط النص داخل الخلية الأولى ويدوره بزاوية 270 درجة.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة حسب الفهرس.
3. إضافة كائن [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) إلى الشريحة.
4. الوصول إلى كائن [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) من الجدول.
5. الوصول إلى أول [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) وتعيين نصه ولونه.
6. تعيين تثبيت النص العمودي واتجاهه باستخدام [setTextAnchorType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextAnchorType) و [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextVerticalType).
7. حفظ العرض التقديمي المعدل.

هذا المثال ينشئ جدولًا 4 × 4 بعرض أعمدة 120 نقطة وارتفاع صفوف 100 نقطة. ينسق النص في الخلية (0, 0)، ويضيف قيمًا إلى الخلايا المتبقية في الصف الأول، ويحفظ النتيجة كملف `Vertical_Align_Text_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    text_frame = table.get_Item(0, 0).getTextFrame()
    paragraph = text_frame.getParagraphs().get_Item(0)

    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ضبط تنسيق النص على مستوى الجدول**

استخدم [setTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setTextFormat) لتطبيق تنسيق النص على جميع خلايا الجدول. تدعم هذه الطريقة إصدارات تسمح بتنسيق جزء، وفقرة، وإطار نص، لذا يمكنك ضبط هذه الخصائص دون iterating عبر خلايا منفردة.

1. تحميل العرض التقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة حسب الفهرس.
3. الوصول إلى كائن [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) من الشريحة.
4. ضبط حجم الخط باستخدام [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) للنص.
5. ضبط محاذاة الفقرة والهامش الأيمن باستخدام [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) و [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. ضبط اتجاه النص باستخدام [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. حفظ العرض التقديمي المعدل.

المثال أدناه يفتح الملف `table.pptx`، والذي يجب أن يحتوي على شريحة واحدة على الأقل مع جدول كأول شكل. يضبط حجم الخط إلى 25 نقطة، يوازن الفقرات إلى اليمين مع هامش أيمن 20 نقطة، ويجعل النص رأسيًا. يُحفظ العرض المنسق كملف `result.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.setTextFormat(text_frame_format)
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الحصول على خصائص نمط الجدول**

استخدم [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) لقراءة النمط المسبق للجدول و [setStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setStylePreset) لتعيينه. يطبق هذا المثال [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/) على جدول واحد، يطبع القيمة المسبقة، ويعيّن نفس النمط للجدول الثاني. تُحفظ كلا الجدولين في الملف `table-style.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    another_table = slide.getShapes().addTable(10, 100, column_widths, row_heights)
    another_table.setStylePreset(style_preset)

    presentation.save("table-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **قفل نسبة العرض إلى الارتفاع للجدول**

نسبة العرض إلى الارتفاع للجدول هي نسبة عرضه إلى ارتفاعه. استخدم [setAspectRatioLocked](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) لقفل هذه النسبة للجدول.

المثال أدناه يفتح الملف `pres.pptx`، والذي يجب أن يحتوي على شريحة واحدة على الأقل مع جدول كأول شكل. يطبع حالة القفل الحالية، يمكّن قفل النسبة، يطبع الحالة المحدثة (`True`)، ويحفظ النتيجة كملف `pres-out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    table.getGraphicalObjectLock().setAspectRatioLocked(True)
    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**هل يمكنني تفعيل اتجاه القراءة من اليمين إلى اليسار (RTL) لجدول كامل والنص داخل خلاياه؟**

نعم. يوفر الجدول طريقة [setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setRightToLeft)، وتملك الفقرات طريقة [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setRightToLeft). يضمن استخدامهما ترتيب RTL الصحيح وعرضه داخل الخلايا.

**كيف يمكنني منع المستخدمين من نقل أو تغيير حجم جدول في الملف النهائي؟**

استخدم [قفل الأشكال](/slides/ar/python-java/applying-protection-to-presentation/) لتعطيل النقل، تغيير الحجم، التحديد، إلخ. تُطبق هذه الأقفال على الجداول أيضًا.

**هل يتم دعم إدراج صورة داخل خلية كخلفية؟**

نعم. يمكنك تعيين [ملء صورة](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) للخلية؛ ستغطي الصورة مساحة الخلية وفق الوضع المختار (تمدد أو تكرار).