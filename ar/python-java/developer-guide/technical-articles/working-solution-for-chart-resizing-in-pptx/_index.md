---
title: حل عملي لتغيير حجم المخطط في PPTX
type: docs
weight: 40
url: /ar/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- تغيير حجم المخطط
- مخطط Excel
- كائن OLE
- تضمين المخطط
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إصلاح مشكلة تغيير حجم المخطط غير المتوقعة في ملفات PPTX عند استخدام كائنات Excel OLE المضمنة مع Aspose.Slides for Python via Java. اضبط أبعاد المخطط الثابتة للحفاظ على تناسق أحجام المخطط وإطار OLE."
---
## **الخلفية**

يمكن أن تتغير أبعاد مخططات Excel المضمنة ككائنات OLE في عروض PowerPoint التقديمية باستخدام مكونات Aspose بعد تفعيلها للمرة الأولى. وهذا قد يسبب فرقًا ملحوظًا في مظهر المخطط قبل وبعد التفعيل. يوضح هذا المقال سبب حدوث تعديل الحجم وكيفية منعه عن طريق مطابقة أبعاد المخطط الثابتة مع إطار OLE.

في [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/ar/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)، شرحنا طريقة إنشاء مخطط Excel باستخدام Aspose.Cells for Python via Java وتضمينه في عرض PowerPoint باستخدام Aspose.Slides for Python via Java. لمعالجة [object preview issue](/slides/ar/python-java/object-preview-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة المخطط إلى إطار كائن OLE الخاص بالمخطط. في العرض الناتج، عندما تنقر مزدوجًا على إطار كائن OLE الذي يعرض صورة المخطط، يتم تفعيل مخطط Excel. يمكن للمستخدمين تحرير دفتر عمل Excel المضمن ثم العودة إلى الشريحة بالنقر خارج دفتر العمل المفعل. يتغير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة، وتختلف نسبة التغيير بحسب الأحجام الأصلية لكل من إطار كائن OLE ودفتر عمل Excel المضمن.

## **سبب تعديل الحجم**

لدى دفتر عمل Excel المضمن أبعاده الخاصة للنافذة، التي يحاول Excel الاحتفاظ بها عند تفعيل الكائن لأول مرة. ويملك إطار OLE على الشريحة أبعادًا معرفة بشكل مستقل. عندما يتم تفعيل دفتر عمل Excel، يتفاوض Excel وPowerPoint على حجم الكائن للحفاظ على نسبه كجزء من عملية التضمين. لذا يمكن لاختلاف أبعاد نافذة دفتر العمل وإطار OLE أن يسبب تعديل حجم الكائن.

## **الحل العملي**

طابق حجم المخطط مع إطار OLE على الشريحة وابقِ أبعاد المخطط مستقلة عن نافذة دفتر العمل. يعمل هذا الحل مع عرض تقديمي جديد أو قالب موجود.

يتطلب المثال Aspose.Cells for Python via Java وAspose.Slides for Python via Java. فهو ينشئ مخطط عمودي بسيط على ورقة مخطط نشطة ويضمّن دفتر العمل بتنسيق XLS. لا يتم تعيين صورة معاينة للمخطط؛ يصبح المخطط مرئيًا عند تفعيل كائن OLE في PowerPoint.

ينشئ المثال عرضًا تقديميًا جديدًا بإطار OLE بحجم 9.5 × 4 بوصة يُوضع على بعد 0.5 بوصة من الحافة اليسرى و1 بوصة من الأعلى. إحداثيات الشريحة وأبعادها بوحدة النقاط (72 نقطة لكل بوصة). للعروض التقديمية الموجودة، راجع [Use a Template](#use-a-template).

## **تعيين حجم مخطط ثابت**

عيّن [setSizeWithWindow](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#sizewithwindow) على false حتى تكون أبعاد المخطط مستقلة عن نافذة دفتر العمل. اضبط أبعاد [getChartObject](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#chartobject) عبر [setWidth](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#width) و[setHeight](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#height)، محوّلاً النقاط إلى بكسل باستخدام 96 بكسل لكل بوصة: الإطار الذي قياسه 684 × 288 نقطة يعادل مخططًا حجمه 912 × 384 بكسل. عيّن [setPrintSize](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#printsize) إلى القيمة CUSTOM من [PrintSizeType](https://reference.aspose.com/cells/python-java/asposecells.api/printsizetype/). يضمّن المثال دفتر العمل عبر [addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) ويحفظ عرضًا تقديميًا بإطار OLE بحجم 9.5 × 4 بوصة.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import ChartType, FileFormatType, PrintSizeType, SheetType, Workbook
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("Data")
    data_sheet.getCells().get("A1").putValue(10)
    data_sheet.getCells().get("A2").putValue(20)

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add("Data!A1:A2", True)
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)

        # إحداثيات الشريحة وأبعادها بوحدة النقاط (72 نقطة لكل بوصة).
        width = 684.0  # 9.5 بوصة.
        height = 288.0  # 4 بوصة.

        chart.setSizeWithWindow(False)
        # تحويل النقاط إلى بكسلات المخطط باستخدام 96 بكسل لكل بوصة.
        chart.getChartObject().setWidth(int(width / 72.0 * 96.0))
        chart.getChartObject().setHeight(int(height / 72.0 * 96.0))
        chart.setPrintSize(PrintSizeType.CUSTOM)

        workbook_stream = ByteArrayOutputStream()
        workbook.save(workbook_stream, FileFormatType.EXCEL_97_TO_2003)
        workbook_data = workbook_stream.toByteArray()
        data_info = OleEmbeddedDataInfo(workbook_data, "xls")
        slide.getShapes().addOleObjectFrame(36.0, 72.0, width, height, data_info)

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    workbook.dispose()
```

## **استخدام قالب**

منطق تحديد الحجم نفسه ينطبق على عرض تقديمي موجود. لتكييف المثال:

1. حمّل قالب العرض التقديمي بدلًا من إنشاء عرض تقديمي فارغ.
1. تأكد من أن الشريحة الأولى تحتوي على ما لا يقل عن ثلاث أشكال، ثم استخدم الشكل عند الفهرس 2 كعنصر نائب.
1. خذ عرض وإرتفاع الإطار من ذلك الشكل بدلًا من القيم الثابتة 684 و288. احتفظ بحسابات الحجم دون تغيير.
1. أضف إطار OLE في موضع العنصر النائب بدلًا من الإحداثيات الثابتة 36 و72.
1. احذف العنصر النائب قبل حفظ العرض التقديمي.

## **الأسئلة المتكررة**

**لماذا يتغير حجم مخطط Excel المضمن بعد تفعيله في PowerPoint؟**

يحدث هذا لأن Excel يحاول استعادة حجم النافذة الأصلي عند التفعيل الأول، بينما يمتلك إطار كائن OLE في PowerPoint أبعادًا خاصة به. يتفاوض PowerPoint وExcel على الحجم للحفاظ على نسبة العرض إلى الارتفاع، مما قد يسبب تعديل الحجم.

**كيف يمكن الحفاظ على اتساق أحجام المخطط وإطار OLE؟**

عيّن أبعاد مخطط ثابتة تطابق إطار OLE واستخدم حجم طباعة مخطط مخصص قبل تضمين دفتر العمل. يظهر المثال أعلاه الإعدادات المطلوبة وتحويل الوحدات.

**هل مطابقة حجم نافذة دفتر العمل كافية؟**

مطابقة حجم نافذة دفتر العمل وحدها لا تمنع بشكل موثوق تغيير حجم إطار OLE بعد التفعيل. استخدم أبعاد مخطط ثابتة كما هو موضح في المثال.

**هل يعمل هذا الحل مع العروض التقديمية القائمة على القوالب والعروض الجديدة؟**

نعم. بالنسبة للقالب، استخدم أبعاد وموقع العنصر النائب. بالنسبة لعرض جديد، حدد أبعاد الإطار وموقعه مباشرة.

**هل يمكنني استخدام هذا المثال مع مخططات أنشئتها برامج جداول بيانات أخرى؟**

يستخدم المثال دفتر عمل Excel تم إنشاؤه باستخدام Aspose.Cells. ولا يوضح سلوك التفعيل لبرامج جداول بيانات أخرى.

## **الأقسام ذات الصلة**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/ar/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)