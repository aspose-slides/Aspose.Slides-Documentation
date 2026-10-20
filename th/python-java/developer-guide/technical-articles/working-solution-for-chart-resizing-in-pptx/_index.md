---
title: วิธีแก้ปัญหาการปรับขนาดแผนภูมิใน PPTX
type: docs
weight: 40
url: /th/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- การปรับขนาดแผนภูมิ
- แผนภูมิ Excel
- อ็อบเจกต์ OLE
- ฝังแผนภูมิ
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "แก้ไขปัญหาการปรับขนาดแผนภูมิที่ไม่คาดคิดใน PPTX เมื่อใช้วัตถุ OLE ของ Excel ที่ฝังอยู่ร่วมกับ Aspose.Slides สำหรับ Python ผ่าน Java. ตั้งค่าขนาดแผนภูมิคงที่เพื่อให้ขนาดแผนภูมิและกรอบ OLE สอดคล้องกัน."
---
## **พื้นหลัง**

แผนภูมิ Excel ที่ฝังเป็นอ็อบเจกต์ OLE ในงานนำเสนอ PowerPoint โดยใช้คอมโพเนนต์ของ Aspose สามารถเปลี่ยนขนาดได้หลังจากการเปิดใช้งานครั้งแรก ซึ่งอาจทำให้เกิดความแตกต่างที่เห็นได้ชัดในลักษณะของแผนภูมิก่อนและหลังการเปิดใช้งาน บทความนี้อธิบายสาเหตุที่ทำให้ขนาดเปลี่ยนและแสดงวิธีป้องกันโดยการทำให้ขนาดแผนภูมิที่กำหนดตรงกับกรอบ OLE

ใน [สร้างแผนภูมิ Excel และฝังเป็นอ็อบเจกต์ OLE ในงานนำเสนอ](/slides/th/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) เราอธิบายวิธีสร้างแผนภูมิ Excel ด้วย Aspose.Cells for Python via Java และฝังลงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for Python via Java เพื่อแก้ไขปัญหา[ปัญหาการแสดงตัวอย่างอ็อบเจกต์](/slides/th/python-java/object-preview-issue-when-adding-oleobjectframe/) เราได้กำหนดภาพแผนภูมิให้กับกรอบอ็อบเจกต์ OLE ของแผนภูมิ ในงานนำเสนอที่ได้ผลลัพธ์ เมื่อคุณดับเบิลคลิกที่กรอบอ็อบเจกต์ OLE ที่แสดงภาพแผนภูมิ แผนภูมิ Excel จะถูกเปิดใช้งาน ผู้ใช้สามารถแก้ไขสมุดงาน Excel ที่ฝังไว้แล้วคลิกนอกสมุดงานที่เปิดใช้งานเพื่อกลับไปยังสไลด์ได้ ขนาดของกรอบอ็อบเจกต์ OLE จะเปลี่ยนเมื่อผู้ใช้กลับไปยังสไลด์ และอัตราการเปลี่ยนขนาดจะแตกต่างกันตามขนาดเดิมของกรอบอ็อบเจกต์ OLE และสมุดงาน Excel ที่ฝังอยู่

## **สาเหตุของการเปลี่ยนขนาด**

สมุดงาน Excel ที่ฝังไว้มีขนาดหน้าต่างของตนเอง ซึ่ง Excel พยายามเก็บไว้เมื่ออ็อบเจกต์ถูกเปิดใช้งานครั้งแรก กรอบ OLE บนสไลด์มีขนาดที่กำหนดแยกกัน เมื่อสมุดงาน Excel ถูกเปิดใช้งาน Excel และ PowerPoint จะเจรจากขนาดของอ็อบเจกต์เพื่อรักษาส่วนอัตราส่วนเป็นส่วนหนึ่งของกระบวนการฝัง ความแตกต่างระหว่างหน้าต่างสมุดงานและกรอบ OLE จึงอาจทำให้เกิดการเปลี่ยนขนาดของอ็อบเจกต์ได้

## **วิธีแก้ที่ใช้งานได้**

ทำให้ขนาดแผนภูมิตรงกับกรอบ OLE บนสไลด์และทำให้ขนาดของแผนภูมิเป็นอิสระจากหน้าต่างสมุดงาน วิธีแก้นี้ทำงานได้กับงานนำเสนอใหม่หรือเทมเพลตที่มีอยู่แล้ว

ตัวอย่างนี้ต้องใช้ Aspose.Cells for Python via Java และ Aspose.Slides for Python via Java โดยจะสร้างแผนภูมิคอลัมน์ง่ายบนชีตแผนภูมิที่เปิดใช้งานและฝังสมุดงานในรูปแบบ XLS ไม่ได้กำหนดภาพแสดงตัวอย่างของแผนภูมิ; แผนภูมิจะปรากฏเมื่ออ็อบเจกต์ OLE ถูกเปิดใช้งานใน PowerPoint

ตัวอย่างสร้างงานนำเสนอใหม่โดยมีกรอบ OLE ขนาด 9.5 × 4 นิ้ว ตั้งไว้ห่างจากขอบซ้าย 0.5 นิ้วและห่างจากด้านบน 1 นิ้ว พิกัดและขนาดของสไลด์ใช้หน่วยเป็นพอยต์ (72 พอยต์ต่อหนึ่งนิ้ว) สำหรับงานนำเสนอที่มีอยู่แล้ว, ดูที่ [ใช้เทมเพลต](#use-a-template)

## **ตั้งขนาดแผนภูมิคงที่**

ตั้งค่า [setSizeWithWindow](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#sizewithwindow) เป็น false เพื่อให้ขนาดแผนภูมิเป็นอิสระจากหน้าต่างสมุดงาน ตั้งค่าขนาดของ [getChartObject](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#chartobject) ผ่าน [setWidth](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#width) และ [setHeight](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#height) โดยแปลงพอยต์เป็นพิกเซลโดยใช้ 96 พิกเซลต่อหนึ่งนิ้ว: กรอบที่วัดได้ 684 × 288 พอยต์ตรงกับแผนภูมิขนาด 912 × 384 พิกเซล ตั้งค่า [setPrintSize](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#printsize) เป็นค่า CUSTOM ของ [PrintSizeType](https://reference.aspose.com/cells/python-java/asposecells.api/printsizetype/) ตัวอย่างฝังสมุดงานด้วย [addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) และบันทึกงานนำเสนอที่มีกรอบ OLE ขนาด 9.5 × 4 นิ้ว

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

        # พิกัดและขนาดของสไลด์ใช้หน่วยเป็นพอยต์ (72 พอยต์ต่อหนึ่งนิ้ว).
        width = 684.0  # 9.5 นิ้ว.
        height = 288.0  # 4 นิ้ว.

        chart.setSizeWithWindow(False)
        # แปลงพอยต์เป็นพิกเซลของแผนภูมิโดยใช้ 96 พิกเซลต่อหนึ่งนิ้ว.
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

## **ใช้เทมเพลต**

ตรรกะการกำหนดขนาดเหมือนกันสำหรับงานนำเสนอที่มีอยู่แล้ว เพื่อปรับตัวอย่างให้ทำตามขั้นตอนต่อไปนี้:

1. โหลดงานนำเสนอเทมเพลตแทนการสร้างงานนำเสนอเปล่า
1. ตรวจสอบให้แน่ใจว่าหนังสือเล่มแรกมีรูปร่างอย่างน้อยสามรูป แล้วใช้รูปร่างที่ตำแหน่งดัชนี 2 เป็นตัวแทนที่วางไว้
1. ดึงความกว้างและความสูงของกรอบจากรูปร่างนั้นแทนการใช้ค่าคงที่ 684 และ 288 คำนวณขนาดโดยไม่เปลี่ยนแปลง
1. เพิ่มกรอบ OLE ที่ตำแหน่งของตัวแทนแทนการใช้พิกัดคงที่ 36 และ 72
1. ลบตัวแทนก่อนบันทึกงานนำเสนอ

## **FAQ**

**ทำไมแผนภูมิ Excel ที่ฝังไว้ถึงเปลี่ยนขนาดหลังจากเปิดใช้งานใน PowerPoint?**

เกิดจาก Excel พยายามคืนขนาดหน้าต่างเดิมเมื่อเปิดใช้งานครั้งแรก ในขณะที่กรอบอ็อบเจกต์ OLE ใน PowerPoint มีขนาดของตนเอง PowerPoint และ Excel จะเจรจาขนาดเพื่อรักษาอัตราส่วน ซึ่งอาจทำให้เกิดการเปลี่ยนขนาดได้

**ฉันจะทำให้ขนาดของแผนภูมิและกรอบ OLE สอดคล้องกันได้อย่างไร?**

กำหนดขนาดแผนภูมิคงที่ให้ตรงกับกรอบ OLE และใช้ขนาดการพิมพ์ของแผนภูมิแบบกำหนดเองก่อนฝังสมุดงาน ตัวอย่างด้านบนแสดงการตั้งค่าที่จำเป็นและการแปลงหน่วย

**การทำให้ขนาดหน้าต่างสมุดงานตรงกันพอหรือไม่?**

การทำให้ขนาดหน้าต่างสมุดงานตรงกันเพียงอย่างเดียวไม่สามารถป้องกันกรอบ OLE จากการเปลี่ยนขนาดหลังจากเปิดใช้งานได้อย่างเชื่อถือได้ ให้ใช้ขนาดแผนภูมิคงที่ตามที่แสดงในตัวอย่าง

**วิธีแก้นี้ทำงานได้กับงานนำเสนอที่ใช้เทมเพลตและงานนำเสนอใหม่ทั้งสองหรือไม่?**

ใช่ สำหรับเทมเพลตให้ใช้ขนาดและตำแหน่งของตัวแทน สำหรับงานนำเสนอใหม่ให้ระบุขนาดและตำแหน่งของกรอบโดยตรง

**ฉันสามารถใช้ตัวอย่างนี้กับแผนภูมิที่สร้างจากโปรแกรมสเปรดชีตอื่นได้หรือไม่?**

ตัวอย่างใช้สมุดงาน Excel ที่สร้างด้วย Aspose.Cells ไม่ได้แสดงพฤติกรรมการเปิดใช้งานสำหรับโปรแกรมสเปรดชีตอื่น

## **ส่วนที่เกี่ยวข้อง**

- [สร้างแผนภูมิ Excel และฝังเป็นอ็อบเจกต์ OLE ในงานนำเสนอ](/slides/th/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)