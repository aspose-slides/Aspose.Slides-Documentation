---
title: إدارة جداول العروض التقديمية في بايثون
linktitle: إدارة الجدول
type: docs
weight: 10
url: /ar/python-java/manage-table/
keywords:
- إضافة جدول
- إنشاء جدول
- الوصول إلى الجدول
- نسبة الأبعاد
- محاذاة النص
- تنسيق النص
- نمط الجدول
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إنشاء وتعديل الجداول في شرائح PowerPoint باستخدام Aspose.Slides للبايثون عبر Java. اكتشف أمثلة رمزية بسيطة لتبسيط عمليات العمل الخاصة بالجدول."
---
## **مقدمة**

الجدول في PowerPoint هو طريقة فعّالة لعرض المعلومات. المعلومات في شبكة من الخلايا (المرتبة في صفوف وأعمدة) تكون مباشرة وسهلة الفهم.

توفر Aspose.Slides الفئة [Table](https://reference.aspose.com/slides/ar/python-java/aspose.slides/table/) والفئة [Cell](https://reference.aspose.com/slides/ar/python-java/aspose.slides/cell/) وأنواع أخرى تسمح لك بإنشاء وتحديث وإدارة الجداول في جميع أنواع العروض التقديمية.

## **إنشاء جدول من الصفر**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة بواسطة فهرسها.
3. تحديد قائمة بعروض الأعمدة.
4. تحديد قائمة بارتفاعات الصفوف.
5. إضافة كائن [Table](https://reference.aspose.com/slides/ar/python-java/aspose.slides/table/) إلى الشريحة عبر طريقة [addTable](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addTable) .
6. تكرار عبر كل [Cell](https://reference.aspose.com/slides/ar/python-java/aspose.slides/cell/) لتطبيق تنسيق على الحدود العلوية والسفلية واليمين واليسار.
7. دمج أول خليتين في الصف الأول للجدول.
8. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) الخاص بـ [Cell](https://reference.aspose.com/slides/ar/python-java/aspose.slides/cell/) .
9. إضافة بعض النص إلى [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) .
10. حفظ العرض التقديمي المعدل.

هذا الكود بلغة Python يظهر لك كيفية إنشاء جدول في عرض تقديمي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# ينشئ كائن من فئة Presentation يمثل ملف PPTX
presentation = Presentation()
try:

    # الوصول إلى الشريحة الأولى
    slide = presentation.getSlides().get_Item(0)

    # تحديد الأعمدة بعروضها والصفوف بارتفاعاتها
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # إضافة شكل جدول إلى الشريحة
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # تعيين تنسيق الحدود لكل خلية
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

    # دمج الخليتين 1 و 2 في الصف 1
    table.mergeCells(table.getRows().get_Item(0).get_Item(0), table.getRows().get_Item(0).get_Item(1), False)

    # إضافة نص إلى الخلية المدمجة
    table.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells")

    # حفظ العرض التقديمي إلى القرص
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الترقيم في جدول قياسي**

في جدول قياسي، يكون ترقيم الخلايا بسيطًا ويبدأ من الصفر. الخلية الأولى في الجدول لها الفهرس 0,0 (عمود 0، صف 0).

على سبيل المثال، يتم ترقيم الخلايا في جدول يحتوي على 4 أعمدة و4 صفوف بهذه الطريقة:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

هذا الكود بلغة Python يظهر لك كيفية إنشاء جدول بترقيم خلايا قياسي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# ينشئ كائنًا من فئة Presentation يمثل ملف PPTX
presentation = Presentation()
try:

    # يصل إلى الشريحة الأولى
    slide = presentation.getSlides().get_Item(0)

    # يحدد الأعمدة بعروضها والصفوف بارتفاعاتها
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # يضيف شكل جدول إلى الشريحة
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # يعيّن تنسيق الحدود لكل خلية
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

    # يحفظ العرض التقديمي إلى القرص
    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الوصول إلى جدول موجود**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة التي تحتوي على الجدول عبر فهرستها.
3. تهيئة متغيّر لكائن [Table](https://reference.aspose.com/slides/ar/python-java/aspose.slides/table/) وتعيينه إلى `None` .
4. التنقل عبر جميع كائنات [Shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/) حتى يتم العثور على الجدول.  
   إذا كنت تشك أن الشريحة التي تتعامل معها تحتوي على جدول واحد، يمكنك ببساطة فحص جميع الأشكال التي تحتويها. عندما يتم التعرف على شكل كجدول، يمكنك استخدامه ككائن [Table](https://reference.aspose.com/slides/ar/python-java/aspose.slides/table/) . لكن إذا كانت الشريحة تحتوي على عدة جداول، فمن الأفضل البحث عن الجدول الذي تحتاجه عبر خاصية [getAlternativeText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getAlternativeText) الخاصة به.
5. استخدم كائن [Table](https://reference.aspose.com/slides/ar/python-java/aspose.slides/table/) للعمل مع الجدول. في المثال أدناه، نقوم بتحديث النص في العمود الأول من الصف الثاني.
6. حفظ العرض التقديمي المعدل.

هذا الكود بلغة Python يظهر لك كيفية الوصول إلى جدول موجود والعمل معه:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

# ينشئ كائنًا من فئة Presentation يمثل ملف PPTX
presentation = Presentation("UpdateExistingTable.pptx")
try:

    # يصل إلى الشريحة الأولى
    slide = presentation.getSlides().get_Item(0)

    # يهيء مرجع الجدول.
    table = None

    # يتنقل عبر الأشكال ويضبط مرجعًا للجدول الذي تم العثور عليه
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape

            # يعيّن النص للعمود الأول من الصف الثاني
            table.get_Item(0, 1).getTextFrame().setText("New")

    # يحفظ العرض التقديمي المعدل إلى القرص
    presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **العثور على الخلية التي تمتلك إطار نص**

عند استلام كود معالجة نص عام لكائن [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) من جدول، استخدم طريقة [TextFrame.getParentCell](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#getParentCell) لاسترداد الخلية المالكة [Cell](https://reference.aspose.com/slides/ar/python-java/aspose.slides/cell/) . بالنسبة لإطار نص خلية جدول، تُعيد [TextFrame.getParentCell](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#getParentCell) المالك وتُعيد [TextFrame.getParentShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#getParentShape) القيمة `None`، رغم أن الجدول نفسه يُعد شكلاً.

إحداثيات الخلية متاحة عبر الطريقتين للقراءة فقط [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/ar/python-java/aspose.slides/cell/#getFirstColumnIndex) و[Cell.getFirstRowIndex](https://reference.aspose.com/slides/ar/python-java/aspose.slides/cell/#getFirstRowIndex) . كما تُقدم [TextFrame.getParentCell](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#getParentCell) تنقلًا للقراءة فقط: تُعيد المالك لكنها لا تغير الملكية. تحقق دائمًا من أن الخلية المرجعة ليست `None` قبل استخدامها.

لمثال كامل يحدد مالكي خلايا الجدول والأشكال، بما في ذلك الأشكال المرتبطة بعُقد SmartArt، راجع [Search and Replace Text](/slides/ar/python-java/search-and-replace-text/).

## **محاذاة النص في جدول**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة بواسطة فهرسها.
3. إضافة كائن [Table](https://reference.aspose.com/slides/ar/python-java/aspose.slides/table/) إلى الشريحة.
4. الوصول إلى كائن [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) من الجدول.
5. الوصول إلى كائن [Paragraph](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/) الخاص بـ [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) .
6. محاذاة النص عموديًا.
7. حفظ العرض التقديمي المعدل.

هذا الكود بلغة Python يظهر لك كيفية محاذاة النص في جدول:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

# ينشئ مثيلًا من فئة Presentation
presentation = Presentation()
try:

    # يحصل على الشريحة الأولى
    slide = presentation.getSlides().get_Item(0)

    # يحدد الأعمدة بعروضها والصفوف بارتفاعاتها
    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # يضيف شكل الجدول إلى الشريحة
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    # يصل إلى إطار النص
    text_frame = table.get_Item(0, 0).getTextFrame()

    # يصل إلى الفقرة الأولى في إطار النص.
    paragraph = text_frame.getParagraphs().get_Item(0)

    # يصل إلى الجزء الأول في الفقرة.
    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # محاذاة النص عموديًا
    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    # يحفظ العرض التقديمي إلى القرص
    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تحديد تنسيق النص على مستوى الجدول**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة بواسطة فهرسها.
3. الوصول إلى كائن [Table](https://reference.aspose.com/slides/ar/python-java/aspose.slides/table/) من الشريحة.
4. تعيين ارتفاع خط النص باستخدام [setFontHeight](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setFontHeight) .
5. تعيين المحاذاة والهامش الأيمن باستخدام [setAlignment](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setAlignment) و[setMarginRight](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setMarginRight) .
6. تعيين نوع النص العمودي باستخدام [setTextVerticalType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#setTextVerticalType) .
7. حفظ العرض التقديمي المعدل.

هذا الكود بلغة Python يظهر لك كيفية تطبيق خيارات التنسيق المفضلة على النص في جدول:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

# ينشئ مثيلًا من فئة Presentation
presentation = Presentation("simpletable.pptx")
try:

    # لنفترض أن الشكل الأول في الشريحة الأولى هو جدول
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape

        # يعيّن ارتفاع خط خلايا الجدول
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.setTextFormat(portion_format)

        # يعيّن محاذاة نص خلايا الجدول والهامش الأيمن في استدعاء واحد
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.setTextFormat(paragraph_format)

        # يعيّن نوع النص العمودي لخلايا الجدول
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **الحصول على خصائص نمط الجدول**

تمكنك Aspose.Slides من استرداد خصائص النمط لجدول بحيث يمكنك استخدام هذه التفاصيل لجداول أخرى أو في أماكن أخرى. هذا الكود بلغة Python يوضح كيفية الحصول على خصائص النمط من نمط جدول مُعَد مسبقًا:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, [100, 150], [5, 5, 5])
    table.setStylePreset(TableStylePreset.DarkStyle1)  # تغيير نمط الإعداد المسبق الافتراضي

    # يحصل على نمط الإعداد المسبق للجدول
    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    # يطبق نمط الإعداد المسبق المسترجع على جدول آخر
    another_table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 100, [100, 150], [5, 5, 5])
    another_table.setStylePreset(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **قفل نسبة الأبعاد للجدول**

نسبة الأبعاد لشكل هندسي هي نسبة أحجامه في أبعاد مختلفة. توفر Aspose.Slides الطريقة [setAspectRatioLocked](https://reference.aspose.com/slides/ar/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) لتسمح لك بقفل إعداد نسبة الأبعاد للجداول والأشكال الأخرى.

هذا الكود بلغة Python يوضح كيفية قفل نسبة الأبعاد لجدول:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        table.getGraphicalObjectLock().setAspectRatioLocked(not table.getGraphicalObjectLock().getAspectRatioLocked())  # عكس
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        presentation.save("pres-out.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **FAQ**

**هل يمكنني تمكين اتجاه القراءة من اليمين إلى اليسار (RTL) لجدول كامل والنص داخل خلاياه؟**

نعم. ي expose الجدول طريقة [setRightToLeft](https://reference.aspose.com/slides/ar/python-java/aspose.slides/table/#setRightToLeft) ، وللفقرات توجد الطريقة [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setRightToLeft). استخدام كلاهما يضمن الترتيب الصحيح للـ RTL وعرضه داخل الخلايا.

**كيف يمكنني منع المستخدمين من تحريك أو تغيير حجم الجدول في الملف النهائي؟**

استخدم [shape locks](/slides/ar/python-java/applying-protection-to-presentation/) لتعطيل التحريك، تغيير الحجم، التحديد، إلخ. تنطبق هذه الأقفال على الجداول أيضًا.

**هل يدعم إدراج صورة داخل خلية كخلفية؟**

نعم. يمكنك تعيين [picture fill](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturefillformat/) للخلية؛ ستغطي الصورة مساحة الخلية وفقًا للوضع المختار (تمدد أو تجانب).