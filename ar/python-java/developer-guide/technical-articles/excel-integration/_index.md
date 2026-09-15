---
title: دمج بيانات Excel في عروض PowerPoint التقديمية
linktitle: دمج Excel
type: docs
weight: 330
url: /ar/python-java/excel-integration/
keywords:
- Excel
- دفتر عمل
- قراءة Excel
- دمج Excel
- مصدر البيانات
- دمج البريد
- استيراد جدول
- Excel إلى PowerPoint
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "قراءة البيانات من دفاتر عمل Excel في Aspose.Slides للغة Python عبر Java باستخدام واجهة برمجة التطبيقات ExcelDataWorkbook. تحميل الأوراق والخلايا واستخدام القيم لإنشاء عروض PowerPoint تقديمية معتمدة على البيانات."
---
## **المقدمة**

العروض التقديمية في PowerPoint طريقة قوية لعرض المعلومات والتواصل بها. غالبًا ما تُستخدم بالاشتراك مع دفاتر عمل Excel، حيث يُعد Excel مصدرًا ممتازًا للبيانات المنظمة ويتفوق PowerPoint في تصور تلك البيانات للجمهور.

هناك العديد من السيناريوهات العملية التي يكون فيها دمج Excel وPowerPoint ضروريًا: دمج البريد، ملء جداول البيانات، إنشاء شريحة واحدة لكل سجل بيانات (إنشاء شرائح دفعة)، إعداد مواد تدريبية، وتوحيد تقارير Excel متعددة في عرض تقديمي واحد، على سبيل المثال لا الحصر.

حتى الآن، كان تنفيذ مثل هذه الميزات باستخدام Aspose.Slides API يتطلب الاعتماد على حلول طرف ثالث مثل Aspose.Cells. بينما هذه الأدوات قوية، قد تكون معقدة للغاية ومكلفة للمستخدمين الذين يحتاجون فقط إلى وظائف تكامل بيانات أساسية.

## **كيفية العمل**

لتسهيل العمل مع بيانات Excel وجعله أكثر سلاسة، قدمت Aspose.Slides فئات جديدة لقراءة البيانات من دفاتر عمل Excel واستيراد المحتوى إلى عرض تقديمي. تفتح هذه الميزة إمكانات جديدة قوية لمستخدمي API الذين يرغبون في الاستفادة من Excel كمصدر بيانات داخل سير عمل العروض التقديمية.

تم تصميم الوظيفة الجديدة للوصول العام إلى البيانات ولم يتم دمجها في نموذج كائن المستند (DOM) للعرض التقديمي. وهذا يعني *أنها لا تسمح بتحرير أو حفظ ملفات Excel* — هدفها الوحيد هو فتح دفاتر العمل والتنقل عبر محتواها لاسترجاع بيانات الخلايا.

في صميم هذه الميزة فئة [ExcelDataWorkbook](https://reference.aspose.com/slides/ar/python-java/aspose.slides/exceldataworkbook/) الجديدة. تسمح لك هذه الفئة بتحميل دفتر عمل Excel من ملف محلي أو من تدفق. بمجرد تحميله، توفر عدة تحميلات للطريقة [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/ar/python-java/aspose.slides/exceldataworkbook/#getCell)، والتي يمكنك استخدامها لاسترجاع خلايا محددة بموقعها (مثل مؤشرات الصف والعمود أو النطاقات المسماة).

كل استدعاء للطريقة [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/ar/python-java/aspose.slides/exceldataworkbook/#getCell) يُعيد كائن [ExcelDataCell](https://reference.aspose.com/slides/ar/python-java/aspose.slides/exceldatacell/). يمثل هذا الكائن خلية واحدة في دفتر عمل Excel ويمنحك الوصول إلى قيمتها بطريقة بسيطة وبديهية.

#### **استيراد مخطط Excel**

الخطوة التالية لتوسيع الوظيفة هي فئة [ExcelWorkbookImporter](https://reference.aspose.com/slides/ar/python-java/aspose.slides/excelworkbookimporter/). توفر هذه الفئة المساعدة وظائف لاستيراد المحتوى من دفتر عمل Excel إلى عرض تقديمي. تحتوي على عدة تحميلات للطريقة [ExcelWorkbookImporter.addChartFromWorkbook](https://reference.aspose.com/slides/ar/python-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook)، والتي تساعدك على استرجاع المخطط المحدد من دفتر عمل Excel المحدد وإضافته إلى نهاية مجموعة الأشكال المحددة عند الإحداثيات المحددة.

#### **استيراد جدول Excel**

تحتوي فئة [ExcelWorkbookImporter](https://reference.aspose.com/slides/ar/python-java/aspose.slides/excelworkbookimporter/) أيضًا على عدة تحميلات للطريقة [ExcelWorkbookImporter.addTableFromWorkbook](https://reference.aspose.com/slides/ar/python-java/aspose.slides/excelworkbookimporter/#addTableFromWorkbook). تسمح لك هذه الطرق باستيراد نطاق خلايا محدد من ورقة عمل محددة وإضافته كجدول إلى نهاية مجموعة الأشكال المحددة عند الإحداثيات المحددة.

باختصار، إنها API خفيفة الوزن وبسيطة لقراءة بيانات Excel — بالضبط ما يحتاجه الكثير من المطورين دون عبء مكتبة معالجة جداول البيانات الكاملة.

## **لنكتب الشيفرة**

### **مثال سيناريو دمج البريد**

في المثال التالي، سننفذ سيناريو دمج بريد بسيط عن طريق إنشاء عروض تقديمية متعددة استنادًا إلى البيانات المخزنة في دفتر عمل Excel.

لبدء العمل، نحتاج إلى شيئين:

1. دفتر عمل Excel يحتوي على البيانات

![مثال على بيانات Excel](example1_image0.png)

2. قالب عرض تقديمي PowerPoint

![مثال على قالب PowerPoint](example1_image1.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# تحميل دفتر عمل Excel ببيانات الموظفين.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# تحميل قالب العرض التقديمي.
template_presentation = Presentation("PresentationTemplate.pptx")

try:
    # التكرار عبر صفوف Excel (مع استبعاد الرأس في الصف 0).
    for row_index in range(1, 5):

        # إنشاء عرض تقديمي لكل سجل موظف.
        employee_presentation = Presentation()

        try:
            # إزالة الشريحة الفارغة الافتراضية.
            employee_presentation.getSlides().removeAt(0)

            # استنساخ شريحة القالب إلى العرض التقديمي.
            slide = employee_presentation.getSlides().addClone(template_presentation.getSlides().get_Item(0))

            # الحصول على الفقرات من الشكل المستهدف (يفترض استخدام الفهرس 1 للشكل).
            paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs()

            # استبدال العناصر النائبة بالبيانات من Excel.
            employee_name = str(workbook.getCell(worksheet_index, row_index, 0).getValue())
            name_portion = paragraphs.get_Item(0).getPortions().get_Item(0)
            name_portion.setText(str(name_portion.getText()).replace("{{EmployeeName}}", employee_name))

            department = str(workbook.getCell(worksheet_index, row_index, 1).getValue())
            department_portion = paragraphs.get_Item(1).getPortions().get_Item(0)
            department_portion.setText(str(department_portion.getText()).replace("{{Department}}", department))

            years_of_service = str(workbook.getCell(worksheet_index, row_index, 2).getValue())
            years_portion = paragraphs.get_Item(2).getPortions().get_Item(0)
            years_portion.setText(str(years_portion.getText()).replace("{{YearsOfService}}", years_of_service))

            # حفظ العرض المخصص في ملف منفصل.
            employee_presentation.save(f"{employee_name} Report.pptx", SaveFormat.Pptx)
        finally:
            employee_presentation.dispose()
finally:
    template_presentation.dispose()
```

![النتيجة](example1_image2.png)

### **مثال جدول Excel**

في المثال الثاني، نقوم ببساطة بنسخ البيانات من جدول Excel وعرضها على شريحة PowerPoint بتنسيق أكثر جاذبية بصريًا.

في هذا المثال، نعيد استخدام نفس دفتر عمل Excel من المثال الأول، الذي يحتوي على جدول موظفين بسيط.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# تحميل دفتر عمل Excel الذي يحتوي على بيانات الموظف.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# إنشاء عرض PowerPoint.
presentation = Presentation()

try:
    # إضافة شكل جدول إلى الشريحة الأولى.
    column_widths = jpype.JArray(jpype.JDouble)([200, 200, 200])
    row_heights = jpype.JArray(jpype.JDouble)([30, 30, 30, 30, 30])
    table = presentation.getSlides().get_Item(0).getShapes().addTable(50, 200, column_widths, row_heights)

    # ملء جدول PowerPoint بالبيانات من دفتر عمل Excel.
    for row_index in range(5):
        for column_index in range(3):
            cell_value = str(workbook.getCell(worksheet_index, row_index, column_index).getValue())
            table.getColumns().get_Item(column_index).get_Item(row_index).getTextFrame().setText(cell_value)

    # حفظ العرض الناتج إلى ملف.
    presentation.save("Table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![النتيجة](example2_image0.png)

### **مثال استيراد مخطط Excel**

في هذا المثال، نستورد مخططًا من الورقة الأولى لدفتر عمل Excel المستخدم في المثال السابق. سيرتبط المخطط بدفتر العمل الخارجي في العرض التقديمي الناتج.

أولاً، نضيف مخططًا دائريًا إلى دفتر عمل Excel استنادًا إلى جدول الموظفين.

![مثال على مخطط Excel](example3_image0.png)

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# إنشاء عرض PowerPoint.
presentation = Presentation()
try:
    # الحصول على مجموعة الأشكال في الشريحة الأولى.
    shapes = presentation.getSlides().get_Item(0).getShapes()

    # استيراد المخطط المسمى "Chart 1" من الورقة الأولى لدفتر العمل وإضافته إلى مجموعة الأشكال.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # حفظ العرض الناتج إلى ملف.
    presentation.save("Chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![النتيجة](example3_image1.png)

### **مثال استيراد جميع مخططات Excel**

لنتخيل أن لديك دفتر عمل Excel مليئًا بالمخططات وتحتاج إلى استيرادها جميعًا إلى عرض تقديمي. يجب وضع كل مخطط في شريحة جديدة.

يقوم الكود التالي بالتكرار عبر جميع الأوراق في ملف Excel المصدر، استخراج المخططات من كل ورقة، وإضافة كل مخطط إلى شريحة منفصلة باستخدام تخطيط شريحة فارغة. في العرض التقديمي الناتج، سيتم تضمين بيانات المخطط فقط، وليس دفتر العمل بالكامل.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, ExcelWorkbookImporter, Presentation, SaveFormat, SlideLayoutType

# تحميل دفتر عمل Excel الذي يحتوي على بيانات الموظف.
workbook = ExcelDataWorkbook("ExcelWithCharts.xlsx")

# إنشاء عرض PowerPoint.
presentation = Presentation()
try:
    # استرجاع تخطيط الشريحة الفارغة.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    # إزالة الشريحة الافتراضية بحيث يحتوي الناتج على شريحة واحدة لكل مخطط.
    presentation.getSlides().removeAt(0)

    # الحصول على أسماء جميع الأوراق الموجودة في دفتر عمل Excel.
    worksheet_names = workbook.getWorksheetNames()

    for name in worksheet_names:
        # استرجاع خريطة تربط فهارس المخططات بأسماء المخططات للورقة.
        worksheet_charts = workbook.getChartsFromWorksheet(name)

        for chart in worksheet_charts:
            # إضافة شريحة باستخدام التخطيط الفارغ.
            slide = presentation.getSlides().addEmptySlide(blank_layout)

            # استيراد المخطط المحدد من دفتر عمل Excel إلى مجموعة أشكال الشريحة.
            ExcelWorkbookImporter.addChartFromWorkbook(slide.getShapes(), 10, 10, workbook, name, chart.getKey(), False)

    # حفظ العرض الناتج إلى ملف.
    presentation.save("Charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **مثال استيراد جدول Excel**

في هذا المثال، نستورد جدولًا منسقًا من ورقة عمل Excel مباشرةً إلى عرض PowerPoint.

تحتوي ورقة العمل المصدر على جدول منسق ببيانات الموظفين:

![مثال على جدول Excel](example4_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# إنشاء عرض PowerPoint.
presentation = Presentation()
try:
    # الحصول على الشريحة الأولى ومجموعة الأشكال الخاصة بها.
    slide = presentation.getSlides().get_Item(0)
    shapes = slide.getShapes()

    # استيراد الجدول من الورقة الأولى لدفتر العمل وإضافته إلى مجموعة الأشكال.
    ExcelWorkbookImporter.addTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5")

    # حفظ العرض الناتج إلى ملف.
    presentation.save("FormattedTable.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![النتيجة](example4_image1.png)

## **الملخص**

هذه الآلية، المتوفرة مباشرة في Aspose.Slides، تجمع بين العمل مع بيانات Excel والعروض التقديمية في مكان واحد. تتيح لك إنشاء شرائح بمخططات مرئية وبيانات مقدمة كجداول Excel — دون أي مكتبات إضافية أو تكاملات معقدة.