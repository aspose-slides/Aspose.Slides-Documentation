---
title: สร้างแผนภูมิ Excel และฝังลงในงานนำเสนอเป็นวัตถุ OLE
type: docs
weight: 30
url: /th/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- แผนภูมิ Excel
- ฝังแผนภูมิ
- วัตถุ OLE
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "สร้างแผนภูมิ Excel และฝังเป็นวัตถุ OLE ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Python. คู่มือแบบทีละขั้นตอนพร้อมตัวอย่างโค้ด."
---
## **พื้นหลัง**

ใน PowerPoint การใช้แผนภูมิที่แก้ไขได้เพื่อแสดงข้อมูลเป็นกราฟิกเป็นการปฏิบัติที่พบทั่วไป Aspose รองรับการสร้างแผนภูมิ Excel ด้วย Aspose.Cells for Python via Java และแผนภูมิเหล่านี้สามารถฝังเป็นวัตถุ OLE ลงในสไลด์ PowerPoint ผ่าน Aspose.Slides for Python via Java บทความนี้ครอบคลุมขั้นตอนที่จำเป็นและให้ตัวอย่างโค้ด Python สำหรับการสร้างแผนภูมิ Excel และฝังเป็นวัตถุ OLE ในงานนำเสนอ PowerPoint โดยใช้ Aspose.Cells และ Aspose.Slides

## **ขั้นตอนที่จำเป็น**

ขั้นตอนต่อไปนี้เป็นสิ่งที่ต้องทำเพื่อสร้างและฝังแผนภูมิ Excel เป็นวัตถุ OLE ในสไลด์ PowerPoint:

1. สร้างแผนภูมิ Excel ด้วย Aspose.Cells
1. กำหนดขนาด OLE ของแผนภูมิ Excel ด้วย Aspose.Cells
1. ดึงภาพของแผนภูมิ Excel ด้วย Aspose.Cells
1. ฝังแผนภูมิ Excel เป็นวัตถุ OLE ในงานนำเสนอ PPTX ด้วย Aspose.Slides
1. แทนที่ภาพ "EMBEDDED OLE OBJECT" ด้วยภาพที่ได้จากขั้นตอนที่ 3 เพื่อแก้ไขปัญหา[ปัญหาการแสดงตัวอย่างวัตถุ](/slides/th/python-java/object-preview-issue-when-adding-oleobjectframe/)
1. บันทึกงานนำเสนอลงดิสก์ในรูปแบบ PPTX

## **การดำเนินการตามขั้นตอนที่ต้องทำ**

การดำเนินการด้วย Python ของขั้นตอนข้างต้นมีดังต่อไปนี้:

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
    # อาร์เรย์ของชื่อเซลล์.
    cell_names = [
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4",
    ]

    # อาร์เรย์ของข้อมูลเซลล์.
    cell_values = [
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25,
    ]

    # เพิ่มเวิร์กชีตใหม่เพื่อเติมข้อมูลให้เซลล์.
    data_sheet_index = workbook.getWorksheets().add()
    data_sheet = workbook.getWorksheets().get(data_sheet_index)
    sheet_name = "DataSheet"
    data_sheet.setName(sheet_name)

    # เติมข้อมูลลงในแผ่นข้อมูล.
    for cell_name, cell_value in zip(cell_names, cell_values):
        data_sheet.getCells().get(cell_name).setValue(jpype.JInt(cell_value))

    # เพิ่มแผ่นแผนภูมิ.
    worksheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(worksheet_index)
    chart_sheet.setName("ChartSheet")
    chart_sheet_index = chart_sheet.getIndex()

    # เพิ่มแผนภูมิลงในแผ่นแผนภูมิโดยใช้ชุดข้อมูลจากแผ่นข้อมูล.
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, chart_rows, 0, chart_columns)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add(sheet_name + "!A1:E1", False)
    chart.getNSeries().add(sheet_name + "!A2:E2", False)
    chart.getNSeries().add(sheet_name + "!A3:E3", False)
    chart.getNSeries().add(sheet_name + "!A4:E4", False)

    # ตั้งค่าแผ่นแผนภูมิให้เป็นแผ่นที่ใช้งานอยู่.
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    return chart_sheet_index


def add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image):
    ole_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    ole_width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())

    # อธิบายเวิร์กบุ๊กเป็นข้อมูล OLE ฝัง.
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(0.0, 0.0, ole_width, ole_height, data_info)
    image = presentation.getImages().addImage(chart_image)
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(image)


# สร้างเวิร์กบุ๊ก.
workbook = Workbook()

# เพิ่มแผนภูมิ Excel.
chart_rows = 55
chart_columns = 25
chart_sheet_index = add_excel_chart_in_workbook(workbook, chart_rows, chart_columns)

# กำหนดขนาด OLE ของแผนภูมิ.
workbook.getWorksheets().setOleSize(0, chart_rows, 0, chart_columns)

# ดึงภาพแผนภูมิและบันทึกลงสตรีม.
print_options = ImageOrPrintOptions()
print_options.setImageType(ImageType.PNG)
image_stream = ByteArrayOutputStream()
workbook.getWorksheets().get(chart_sheet_index).getCharts().get(0).toImage(image_stream, print_options)
chart_image = image_stream.toByteArray()

# บันทึกเวิร์กบุ๊กลงสตรีม.
workbook_stream = ByteArrayOutputStream()
workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)
workbook_data = workbook_stream.toByteArray()

# สร้างงานนำเสนอ.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มเวิร์กบุ๊กลงในสไลด์.
    add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image)

    # บันทึกงานนำเสนอลงดิสก์.
    presentation.save("OutputChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

งานนำเสนอที่สร้างด้วยวิธีข้างต้นจะประกอบด้วยแผนภูมิ Excel เป็นวัตถุ OLE ที่สามารถเปิดใช้งานได้โดยการดับเบิลคลิกที่กรอบวัตถุ OLE

## **สรุป**

โดยการใช้ Aspose.Cells for Python via Java ร่วมกับ Aspose.Slides for Python via Java เราสามารถสร้างแผนภูมิ Excel ใด ๆ ที่รองรับโดย Aspose.Cells และฝังแผนภูมินั้นเป็นวัตถุ OLE ในสไลด์ PowerPoint ขนาด OLE ของแผนภูมิ Excel ยังสามารถกำหนดได้ ผู้ใช้ขั้นสุดท้ายจึงสามารถแก้ไขแผนภูมิ Excel ได้เช่นเดียวกับวัตถุ OLE อื่น ๆ

## **ส่วนที่เกี่ยวข้อง**

- [วิธีแก้ปัญหาการปรับขนาดแผนภูมิใน PPTX](/slides/th/python-java/working-solution-for-chart-resizing-in-pptx/)
- [ปัญหาการแสดงตัวอย่างวัตถุเมื่อเพิ่ม OleObjectFrame](/slides/th/python-java/object-preview-issue-when-adding-oleobjectframe/)

## **คำถามที่พบบ่อย**

**ไลบรารีใดที่ใช้ในการสร้างและฝังแผนภูมิ Excel?**

Aspose.Cells for Python via Java สร้างแผนภูมิ Excel และ Aspose.Slides for Python via Java ฝังมันเป็นวัตถุ OLE ในสไลด์ PowerPoint

**ผู้ใช้จะสามารถแก้ไขแผนภูมิ Excel ที่ฝังได้อย่างไร?**

ผู้ใช้สามารถดับเบิลคลิกที่กรอบวัตถุ OLE เพื่อเปิดใช้งานแผนภูมิและแก้ไขมันเหมือนกับวัตถุ OLE อื่น ๆ

**การแทนที่ภาพตัวอย่าง OLE object เริ่มต้นทำอย่างไร?**

ตัวอย่างจะดึงภาพของแผนภูมิ Excel ด้วย Aspose.Cells แล้วใช้ภาพนั้นแทนที่ภาพ "EMBEDDED OLE OBJECT"