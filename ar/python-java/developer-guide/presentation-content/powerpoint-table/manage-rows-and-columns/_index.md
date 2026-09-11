---
title: إدارة الصفوف والأعمدة في جداول PowerPoint باستخدام Python
linktitle: الصفوف والأعمدة
type: docs
weight: 20
url: /ar/python-java/manage-rows-and-columns/
keywords:
- صف الجدول
- عمود الجدول
- الصف الأول
- رأس الجدول
- استنساخ الصف
- استنساخ العمود
- نسخ الصف
- نسخ العمود
- إزالة الصف
- إزالة العمود
- تنسيق نص الصف
- تنسيق نص العمود
- نمط الجدول
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إدارة صفوف وأعمدة الجداول في PowerPoint باستخدام Aspose.Slides للغة Python عبر Java وتسريع تحرير العروض التقديمية وتحديث البيانات."
---
## **المقدمة**

لتمكينك من إدارة صفوف وأعمدة الجدول في عرض PowerPoint تقديمي، توفر Aspose.Slides فئة [Table](https://reference.aspose.com/slides/ar/python-java/aspose.slides/table/) والعديد من الأنواع الأخرى.

## **تعيين الصف الأول كعنوان**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) وتحميل العرض التقديمي.  
2. الحصول على مرجع إلى شريحة بواسطة فهرسها.  
3. إنشاء مرجع إلى [Table](https://reference.aspose.com/slides/ar/python-java/aspose.slides/table/) وتعيينه إلى `None`.  
4. التكرار عبر جميع كائنات [Shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/) للعثور على الجدول المناسب.  
5. تعيين الصف الأول للجدول كعنوان له.

يظهر لك هذا الشيفرة بلغة Python كيفية تعيين الصف الأول للجدول كعنوان له:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = None
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            table.setFirstRow(True)
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **استنساخ صف أو عمود في الجدول**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) وتحميل العرض التقديمي.  
2. الحصول على مرجع إلى شريحة بواسطة فهرسها.  
3. تحديد قائمة بعرض الأعمدة.  
4. تحديد قائمة بارتفاعات الصفوف.  
5. إضافة كائن [Table](https://reference.aspose.com/slides/ar/python-java/aspose.slides/table/) إلى الشريحة عبر طريقة [addTable](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addTable).  
6. استنساخ صف الجدول.  
7. استنساخ عمود الجدول.  
8. حفظ العرض التقديمي المعدل.

يظهر لك هذا الشيفرة بلغة Python كيفية استنساخ صف أو عمود في جدول PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1")
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2")
    table.getRows().addClone(table.getRows().get_Item(0), False)
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1")
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2")
    table.getRows().insertClone(3, table.getRows().get_Item(1), False)
    table.getColumns().addClone(table.getColumns().get_Item(0), False)
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), False)
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **إزالة صف أو عمود من جدول**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).  
2. الحصول على مرجع إلى شريحة بواسطة فهرسها.  
3. تحديد قائمة بعرض الأعمدة.  
4. تحديد قائمة بارتفاعات الصفوف.  
5. إضافة كائن [Table](https://reference.aspose.com/slides/ar/python-java/aspose.slides/table/) إلى الشريحة عبر طريقة [addTable](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addTable).  
6. إزالة صف الجدول.  
7. إزالة عمود الجدول.  
8. حفظ العرض التقديمي المعدل.

يظهر لك هذا الشيفرة بلغة Python كيفية إزالة صف أو عمود من جدول:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)
    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)
    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعيين تنسيق النص على مستوى صف الجدول**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) وتحميل العرض التقديمي.  
2. الحصول على مرجع إلى شريحة بواسطة فهرسها.  
3. الوصول إلى كائن [Table](https://reference.aspose.com/slides/ar/python-java/aspose.slides/table/) المناسب من الشريحة.  
4. تعيين ارتفاع الخط لخلايا الصف الأول باستخدام [setFontHeight](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setFontHeight).  
5. تعيين محاذاة النص والهوامش اليمنى لخلايا الصف الأول باستخدام [setAlignment](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setAlignment) و [setMarginRight](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setMarginRight).  
6. تعيين نوع النص العمودي لخلايا الصف الثاني باستخدام [setTextVerticalType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#setTextVerticalType).  
7. حفظ العرض التقديمي المعدل.

توضح هذه الشيفرة بلغة Python العملية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getRows().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getRows().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getRows().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **تعيين تنسيق النص على مستوى عمود الجدول**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) وتحميل العرض التقديمي.  
2. الحصول على مرجع إلى شريحة بواسطة فهرسها.  
3. الوصول إلى كائن [Table](https://reference.aspose.com/slides/ar/python-java/aspose.slides/table/) المناسب من الشريحة.  
4. تعيين ارتفاع الخط لخلايا العمود الأول باستخدام [setFontHeight](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setFontHeight).  
5. تعيين محاذاة النص والهوامش اليمنى لخلايا العمود الأول باستخدام [setAlignment](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setAlignment) و [setMarginRight](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#setMarginRight).  
6. تعيين نوع النص العمودي لخلايا العمود الثاني باستخدام [setTextVerticalType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#setTextVerticalType).  
7. حفظ العرض التقديمي المعدل.

توضح هذه الشيفرة بلغة Python العملية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getColumns().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getColumns().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getColumns().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **الحصول على خصائص نمط الجدول**

تتيح لك Aspose.Slides استرداد خصائص النمط لجدول حتى تتمكن من استخدام هذه التفاصيل لجدول آخر أو في مكان آخر. يوضح لك هذا الشيفرة بلغة Python كيفية الحصول على خصائص النمط من نمط جدول مسبق:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)
    style_preset = table.getStylePreset()
    print(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**هل يمكنني تطبيق سمات/أنماط PowerPoint على جدول تم إنشاؤه مسبقًا؟**

نعم. يرث الجدول سمة الشريحة/التخطيط/الماستَر، ولا يزال بإمكانك تجاوز التعبئات والحدود وألوان النص فوق تلك السمة.

**هل يمكنني فرز صفوف الجدول كما في Excel؟**

لا، جداول Aspose.Slides لا تحتوي على فرز مدمج أو فلاتر. قم بفرز البيانات في الذاكرة أولاً، ثم أعد ملء صفوف الجدول وفقًا لذلك الترتيب.

**هل يمكنني الحصول على أعمدة مخططة (مخططة) مع الحفاظ على ألوان مخصصة لخلايا محددة؟**

نعم. فعّل الأعمدة المخططة، ثم تجاوز تنسيق الخلايا المحددة بالتنسيق المحلي؛ تنسيق الخلية يتفوق على نمط الجدول.