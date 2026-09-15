---
title: إنشاء مخططات Excel وتضمينها في العروض التقديمية ككائنات OLE
type: docs
weight: 30
url: /ar/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- مخطط Excel
- تضمين المخطط
- كائن OLE
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إنشاء مخططات Excel وتضمينها ككائنات OLE في عروض PowerPoint وOpenDocument باستخدام Python. دليل خطوة بخطوة مع أمثلة الشيفرة."
---
## **الخلفية**

في PowerPoint، يُعد استخدام المخططات القابلة للتحرير لعرض البيانات بشكل رسومي ممارسة شائعة. تدعم Aspose إنشاء مخططات Excel باستخدام Aspose.Cells for Python via Java، ويمكن بعد ذلك تضمين هذه المخططات ككائنات OLE في شرائح PowerPoint عبر Aspose.Slides for Python via Java. يغطي هذا المقال الخطوات اللازمة ويقدم مثالًا برمجيًا بلغة Python لإنشاء مخطط Excel وتضمينه ككائن OLE في عرض تقديمي لـ PowerPoint باستخدام Aspose.Cells وAspose.Slides.

## **الخطوات المطلوبة**

التسلسل التالي من الخطوات مطلوب لإنشاء وتضمين مخطط Excel ككائن OLE في شريحة PowerPoint:

1. إنشاء مخطط Excel باستخدام Aspose.Cells.
1. تحديد حجم OLE لمخطط Excel باستخدام Aspose.Cells.
1. الحصول على صورة لمخطط Excel باستخدام Aspose.Cells.
1. تضمين مخطط Excel ككائن OLE في عرض تقديمي PPTX باستخدام Aspose.Slides.
1. استبدال صورة "EMBEDDED OLE OBJECT" بالصورة التي تم الحصول عليها في الخطوة 3 لمعالجة مشكلة [مشكلة معاينة الكائن](/slides/ar/python-java/object-preview-issue-when-adding-oleobjectframe/).
1. حفظ العرض التقديمي على القرص بتنسيق PPTX.

## **تنفيذ الخطوات المطلوبة**

تنفيذ Python للخطوات المذكورة أعلاه كما يلي:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def add_excel_chart_in_workbook(workbook, chart_rows, chart_columns):
    # مصفوفة من أسماء الخلايا.
    cell_names = [
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4",
    ]

    # مصفوفة من بيانات الخلايا.
    cell_values = [
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25,
    ]

    # إضافة ورقة عمل جديدة لتعبئة الخلايا بالبيانات.
    data_sheet_index = workbook.getWorksheets().add()
    data_sheet = workbook.getWorksheets().get(data_sheet_index)
    sheet_name = "DataSheet"
    data_sheet.setName(sheet_name)

    # تعبئة ورقة البيانات بالبيانات.
    for cell_name, cell_value in zip(cell_names, cell_values):
        data_sheet.getCells().get(cell_name).setValue(jpype.JInt(cell_value))

    # إضافة ورقة مخطط.
    worksheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(worksheet_index)
    chart_sheet.setName("ChartSheet")
    chart_sheet_index = chart_sheet.getIndex()

    # إضافة مخطط إلى ورقة المخطط باستخدام سلسلة البيانات من ورقة البيانات.
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, chart_rows, 0, chart_columns)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add(sheet_name + "!A1:E1", False)
    chart.getNSeries().add(sheet_name + "!A2:E2", False)
    chart.getNSeries().add(sheet_name + "!A3:E3", False)
    chart.getNSeries().add(sheet_name + "!A4:E4", False)

    # تعيين ورقة المخطط كورقة نشطة.
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    return chart_sheet_index


def add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image):
    ole_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    ole_width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())

    # وصف دفتر العمل كبيانات OLE مضمّنة.
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(0.0, 0.0, ole_width, ole_height, data_info)
    image = presentation.getImages().addImage(chart_image)
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(image)


# إنشاء دفتر عمل.
workbook = Workbook()

# إضافة مخطط Excel.
chart_rows = 55
chart_columns = 25
chart_sheet_index = add_excel_chart_in_workbook(workbook, chart_rows, chart_columns)

# تعيين حجم OLE للمخطط.
workbook.getWorksheets().setOleSize(0, chart_rows, 0, chart_columns)

# الحصول على صورة المخطط وحفظها إلى تدفق.
print_options = ImageOrPrintOptions()
print_options.setImageType(ImageType.PNG)
image_stream = ByteArrayOutputStream()
workbook.getWorksheets().get(chart_sheet_index).getCharts().get(0).toImage(image_stream, print_options)
chart_image = image_stream.toByteArray()

# حفظ دفتر العمل إلى تدفق.
workbook_stream = ByteArrayOutputStream()
workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)
workbook_data = workbook_stream.toByteArray()

# إنشاء عرض تقديمي.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # إضافة دفتر العمل إلى شريحة.
    add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image)

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("OutputChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

العرض التقديمي الذي تم إنشاؤه بالطريقة المذكورة سيحتوي على مخطط Excel ككائن OLE يمكن تنشيطه بالنقر المزدوج على إطار كائن OLE.

## **الخلاصة**

باستخدام Aspose.Cells for Python via Java جنبًا إلى جنب مع Aspose.Slides for Python via Java، يمكننا إنشاء أي مخطط Excel مدعوم من Aspose.Cells وتضمينه ككائن OLE في شريحة PowerPoint. يمكن أيضًا تحديد حجم OLE لمخطط Excel. يمكن للمستخدمين النهائيين بعد ذلك تحرير مخطط Excel مثل أي كائن OLE آخر.

## **الأقسام ذات الصلة**

- [حل عملي لإعادة تحجيم المخططات في PPTX](/slides/ar/python-java/working-solution-for-chart-resizing-in-pptx/)
- [مشكلة معاينة الكائن عند إضافة OleObjectFrame](/slides/ar/python-java/object-preview-issue-when-adding-oleobjectframe/)

## **التعليمات المتكررة**

**ما المكتبات المستخدمة لإنشاء وتضمين مخطط Excel؟**

Aspose.Cells for Python via Java ينشئ مخطط Excel، وAspose.Slides for Python via Java يضمّه ككائن OLE في شريحة PowerPoint.

**كيف يمكن للمستخدمين تحرير مخطط Excel المضمن؟**

يمكن للمستخدمين النقر المزدوج على إطار كائن OLE لتنشيط المخطط وتحريره مثل أي كائن OLE آخر.

**كيف يتم استبدال معاينة كائن OLE الافتراضية؟**

يحصل المثال على صورة لمخطط Excel باستخدام Aspose.Cells ويستخدمها لاستبدال صورة "EMBEDDED OLE OBJECT".