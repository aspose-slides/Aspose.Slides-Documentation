---
title: الحل العملي لتغيير حجم المخطط في PPTX
type: docs
weight: 40
url: /ar/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- تغيير حجم المخطط
- مخطط Excel
- كائن OLE
- تضمين المخطط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إصلاح تغيّر حجم المخطط غير المتوقع في ملفات PPTX عند استخدام كائنات OLE المدمجة من Excel مع Aspose.Slides لبايثون عبر جافا. تعرف على طريقتين مع الشيفرة للحفاظ على التناسق في الأحجام."
---
## **الخلفية**

لقد لوحظ أن المخططات في Excel المُدمجة ككائنات OLE في عرض PowerPoint عبر مكوّنات Aspose يتم تغيير حجمها إلى مقياس غير محدد بعد تفعيلها لأول مرة. يتسبب هذا السلوك في فرق مرئي ملحوظ في العرض بين حالة المخطط قبل التفعيل وبعده. قام فريق Aspose بالتحقيق في المشكلة بالتفصيل ووجد حلاً. تصف هذه المقالة أسباب المشكلة والإصلاح المقابل.

في [المقال السابق](/slides/ar/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)، شرحنا كيفية إنشاء مخطط Excel باستخدام Aspose.Cells for Python via Java ودمجه في عرض PowerPoint باستخدام Aspose.Slides for Python via Java. لمعالجة [مشكلة معاينة الكائن](/slides/ar/python-java/object-preview-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة المخطط إلى إطار كائن OLE الخاص بالمخطط. في العرض الناتج، عند النقر المزدوج على إطار كائن OLE الذي يعرض صورة المخطط، يتم تفعيل مخطط Excel. يمكن للمستخدمين إجراء أي تغييرات مرغوبة في دفتر عمل Excel الأساسي ثم العودة إلى الشريحة المقابلة بالنقر خارج دفتر العمل المفعل. يتغير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة، وتختلف قيمة تعديل الحجم اعتمادًا على الأحجام الأصلية لكل من إطار كائن OLE ودفتر عمل Excel المدمج.

## **سبب تغيير الحجم**

نظرًا لأن دفتر عمل Excel له حجم نافذة خاص به، فإنه يحاول الاحتفاظ بحجمه الأصلي عند تفعيله لأول مرة. ومع ذلك، لإطار كائن OLE حجمه الخاص. وفقًا لمايكروسوفت، عندما يتم تفعيل دفتر عمل Excel، يتفاوض Excel وPowerPoint على الحجم ويحافظان على النسب الصحيحة كجزء من عملية الدمج. بناءً على الفروقات بين حجم نافذة Excel وحجم أو موقع إطار كائن OLE، يحدث تغيير في الحجم.

## **الحل العملي**

هناك سيناريوهين محتملين لإنشاء عروض PowerPoint باستخدام Aspose.Slides for Python via Java.

**السيناريو 1:** إنشاء عرض بناءً على قالب موجود.

**السيناريو 2:** إنشاء عرض من الصفر.

الحل الذي نقدمه هنا ينطبق على كلا السيناريوهين. أساس جميع نهج الحل هو نفسه: **يجب أن يتطابق حجم نافذة الكائن OLE المدمج مع إطار كائن OLE في شريحة PowerPoint**. سنناقش الآن النهجين لهذا الحل.

## **النهج الأول**

في هذا النهج، سنتعلم كيفية ضبط حجم نافذة دفتر عمل Excel المدمج بحيث يتطابق مع حجم إطار كائن OLE في شريحة PowerPoint.

**السيناريو 1**

افترض أننا عرّفنا قالبًا ونريد إنشاء عروض بناءً عليه. لنفترض أن هناك شكلًا في الفهرس 2 داخل القالب حيث نريد وضع إطار OLE يحتوي على دفتر عمل Excel مدمج. في هذا السيناريو، حجم إطار كائن OLE محدد مسبقًا — يتطابق مع حجم الشكل في الفهرس 2 داخل القالب. كل ما نحتاجه هو ضبط حجم نافذة دفتر العمل ليتساوى مع حجم ذلك الشكل. يحقق الشفرة التالية هذا الغرض:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# تحميل دفتر عمل Excel الذي يحتوي على المخطط.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # ضبط حجم نافذة دفتر العمل بالبوصة (PowerPoint يستخدم 72 نقطة لكل بوصة).
    workbook.getSettings().setWindowWidthInch(shape.getWidth() / 72.0)
    workbook.getSettings().setWindowHeightInch(shape.getHeight() / 72.0)

    # حفظ دفتر العمل إلى تدفق ذاكرة.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # إنشاء إطار كائن OLE مع البيانات المدمجة من Excel.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**السيناريو 2**

لنفترض أننا نريد إنشاء عرض من الصفر وتضمين إطار كائن OLE بحجم أي كان مع دفتر عمل Excel مدمج. في الشفرة التالية، ننشئ إطار كائن OLE بارتفاع 4 بوصات وعرض 9.5 بوصة عند x = 0.5 بوصة و y = 1 بوصة على الشريحة. ثم نضبط نافذة دفتر عمل Excel لتكون بنفس الحجم — ارتفاع 4 بوصات وعرض 9.5 بوصة.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# تحميل دفتر عمل Excel الذي يحتوي على المخطط.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 بوصات (4 * 72).
    desired_width = 684  # 9.5 بوصة (9.5 * 72).

    # تعريف حجم المخطط باستخدام نافذة.
    chart.setSizeWithWindow(True)

    # ضبط حجم نافذة دفتر العمل بالبوصة (PowerPoint يستخدم 72 نقطة لكل بوصة).
    workbook.getSettings().setWindowWidthInch(desired_width / 72.0)
    workbook.getSettings().setWindowHeightInch(desired_height / 72.0)

    # حفظ دفتر العمل إلى تدفق ذاكرة.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # إنشاء إطار كائن OLE مع البيانات المدمجة من Excel.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **النهج الثاني**

في هذا النهج، سنتعلم كيفية ضبط حجم المخطط في دفتر عمل Excel المدمج ليتطابق مع حجم إطار كائن OLE في شريحة PowerPoint. هذا النهج مفيد عندما يكون حجم المخطط معروفًا مسبقًا ولن يتغير.

**السيناريو 1**

افترض أننا عرّفنا قالبًا ونريد إنشاء عروض بناءً عليه. لنفترض أن هناك شكلًا في الفهرس 2 داخل القالب حيث نعتزم وضع إطار OLE يحتوي على دفتر عمل Excel مدمج. في هذا السيناريو، حجم إطار OLE محدد مسبقًا — يتطابق مع حجم الشكل في الفهرس 2 داخل القالب. كل ما نحتاجه هو ضبط حجم المخطط في دفتر العمل ليتساوى مع حجم الشكل. يحقق الشفرة التالية هذا الغرض:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# تحميل دفتر عمل Excel الذي يحتوي على المخطط.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # تعريف حجم المخطط بدون نافذة.
    chart.setSizeWithWindow(False)

    # ضبط حجم المخطط بالبكسل (Excel يستخدم 96 بكسل لكل بوصة).
    chart.getChartObject().setWidth(int((shape.getWidth() / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((shape.getHeight() / 72.0) * 96.0))

    # تعريف حجم طباعة المخطط.
    chart.setPrintSize(PrintSizeType.CUSTOM)

    # حفظ دفتر العمل إلى تدفق ذاكرة.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # إنشاء إطار كائن OLE مع البيانات المدمجة من Excel.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**السيناريو 2**:

لنفترض أننا نريد إنشاء عرض من الصفر وتضمين إطار كائن OLE بحجم أي كان مع دفتر عمل Excel مدمج. في الشفرة التالية، ننشئ إطار كائن OLE بارتفاع 4 بوصات وعرض 9.5 بوصة على الشريحة عند x = 0.5 بوصة و y = 1 بوصة. كما نضبط حجم المخطط المقابل لنفس الأبعاد: ارتفاع 4 بوصات وعرض 9.5 بوصة.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# تحميل دفتر عمل Excel الذي يحتوي على المخطط.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 بوصات (4 * 72).
    desired_width = 684  # 9.5 بوصة (9.5 * 72).

    # تعريف حجم المخطط بدون نافذة.
    chart.setSizeWithWindow(False)

    # ضبط حجم المخطط بالبكسل (Excel يستخدم 96 بكسل لكل بوصة).
    chart.getChartObject().setWidth(int((desired_width / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((desired_height / 72.0) * 96.0))

    # حفظ دفتر العمل إلى تدفق ذاكرة.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # إنشاء إطار كائن OLE مع البيانات المدمجة من Excel.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **الخلاصة**

هناك نهجان لحل مشكلة تغيير حجم المخطط. يعتمد اختيار النهج على المتطلبات وحالة الاستخدام. كلا النهجين يعملان بنفس الطريقة سواء تم إنشاء العروض من قالب أو من الصفر. أيضًا، لا يوجد حد لحجم إطار كائن OLE في هذا الحل.

## **الأسئلة المتداولة**

**لماذا يتغير حجم مخطط Excel المدمج بعد تفعيله في PowerPoint؟**

يحدث هذا لأن Excel يحاول استعادة حجم النافذة الأصلي عند التفعيل الأول، في حين أن إطار كائن OLE في PowerPoint له أبعاده الخاصة. يتفاوض PowerPoint وExcel على الحجم للحفاظ على نسبة الأبعاد، مما قد يسبب تعديل الحجم.

**هل يمكن منع هذه المشكلة تمامًا؟**

نعم. من خلال مطابقة حجم نافذة دفتر عمل Excel أو حجم المخطط مع حجم إطار كائن OLE قبل الدمج، يمكنك الحفاظ على حجم المخطط ثابتًا.

**أي نهج ينبغي أن أختار، ضبط حجم النافذة أم ضبط حجم المخطط؟**

استخدم **النهج 1 (حجم النافذة)** إذا كنت تريد الحفاظ على نسبة أبعاد دفتر العمل وربما السماح بإعادة الحجم لاحقًا.  
استخدم **النهج 2 (حجم المخطط)** إذا كانت أبعاد المخطط ثابتة ولن تتغير بعد الدمج.

**هل هذه الطرق تعمل مع العروض القائمة على القوالب والجديدة على حد سواء؟**

نعم. كلا النهجين يعملان بنفس الطريقة للعروض التي تم إنشاؤها من القوالب أو من الصفر.

**هل هناك حد لحجم إطار كائن OLE؟**

لا. يمكنك ضبط إطار OLE إلى أي حجم طالما أنه يتناسب بشكل مناسب مع حجم دفتر العمل أو المخطط.

**هل يمكنني استخدام هذه الطرق مع المخططات التي تم إنشاؤها في برامج جداول بيانات أخرى؟**

تم تصميم الأمثلة لمخططات Excel التي تم إنشاؤها باستخدام Aspose.Cells، لكن المبادئ تنطبق على برامج جداول بيانات أخرى متوافقة مع OLE طالما أنها تدعم خيارات حجم مماثلة.

## **الأقسام ذات الصلة**

- [إنشاء مخططات Excel وتضمينها ككائنات OLE في العروض](/slides/ar/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)