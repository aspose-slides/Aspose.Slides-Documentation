---
title: สร้างแผนภูมิ Excel และฝังไว้ในงานนำเสนอเป็นวัตถุ OLE
type: docs
weight: 30
url: /th/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- แผนภูมิ Excel
- ฝังแผนภูมิ
- วัตถุ OLE
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "สร้างแผนภูมิ Excel ด้วย Aspose.Cells สำหรับ Python ผ่าน Java และฝังสมุดงานในงานนำเสนอ PowerPoint ด้วย Aspose.Slides รวมถึงภาพตัวอย่างของแผนภูมิ"
---
## **ภาพรวม**

บทความนี้แสดงวิธีสร้างแผนภูมิคอลัมน์ Excel ด้วย Aspose.Cells สำหรับ Python ผ่าน Java และฝังสมุดงานของมันในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน Java. สมุดงานที่ฝังไว้ประกอบด้วยข้อมูลต้นฉบับและแผนภูมิ. ตัวอย่าง PNG แยกต่างหากจะแสดงแผนภูมิบนสไลด์ก่อนที่วัตถุ OLE จะถูกเปิดใช้งาน.

ผลลัพธ์คือวัตถุ Excel ที่ฝังอยู่ ไม่ใช่แผนภูมิ PowerPoint ดั้งเดิม การแก้ไขสมุดงานผ่าน OLE ต้องการแอปพลิเคชันบนเดสก์ท็อปที่รองรับการเปิดใช้งาน OLE และการติดตั้ง Excel ที่เข้ากันได้.

## **ข้อกำหนดเบื้องต้น**

ติดตั้งแพ็กเกจ Python `aspose-cells` และ `aspose-slides-java` รวมถึงรันไทม์ Java ที่เข้ากันได้. นำเข้าแพ็กเกจทั้งสองก่อนเริ่ม JVM เพื่อให้ไลบรารี Java ของพวกมันพร้อมใช้ใน JPype. ไม่จำเป็นต้องมี Microsoft Office เพื่อสร้างงานนำเสนอด้วยไลบรารีเหล่านี้.

ไม่จำเป็นต้องใช้ไฟล์อินพุต: ตัวอย่างสร้างข้อมูลและแผนภูมิในหน่วยความจำ, แล้วเขียน `OutputChart.pptx` ไปยังไดเรกทอรีทำงานปัจจุบัน. ให้ใช้ใบอนุญาตสำหรับผลิตภัณฑ์ทั้งสองเมื่อทำงานนอกโหมดประเมินผล.

## **วิธีการทำงานของการฝัง**

1. สร้างสมุดงานที่มีแผ่นงานข้อมูลและแผ่นงานแผนภูมิ.
1. ทำให้แผ่นงานแผนภูมิกลับเป็นแผ่นงานที่เปิดอยู่เพื่อให้สมุดงานเปิดที่แผนภูมิ.
1. ตั้งค่าช่วงการแสดงผล OLE ของสมุดงานและเรนเดอร์แผนภูมิเป็น PNG.
1. บันทึกสมุดงานเป็น XLSX ในหน่วยความจำและฝังไบต์เหล่านั้นลงในสไลด์.
1. กำหนด PNG เป็นภาพตัวอย่างของวัตถุ OLE และบันทึกงานนำเสนอเป็น PPTX.

ช่วงการแสดงผลของสมุดงานและกรอบบนสไลด์มีบทบาทที่แตกต่างกัน. [setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) รับพิกัดแถวและคอลัมน์เริ่มต้น/สิ้นสุดที่นับจากศูนย์. [ChartCollection.add](https://reference.aspose.com/cells/python-java/asposecells.api/chartcollection/#add) แทนที่จะรับแถวบน, คอลัมน์ซ้าย, แถวล่าง, และคอลัมน์ขวา. ตัวอย่างใช้ดัชนีแถว 55 และดัชนีคอลัมน์ 25 เป็นขอบล่างขวา; ค่าตัวนี้เป็นการเลือกการจัดวาง, ไม่ใช่จำนวนแถวหรือคอลัมน์ของข้อมูล.

กรอบสไลด์ใช้หน่วย points. ตัวอย่างทำให้มันพอดีภายในสไลด์และจัดกึ่งกลางโดยคงอัตราส่วนของ PNG, แทนการยืดภาพตัวอย่างให้เต็มสไลด์.

## **สร้างและฝังแผนภูมิ**

ตัวอย่างเต็มที่ต่อไปนี้เติมค่าใน `DataSheet` ด้วยแถวสี่แถวและคอลัมน์ห้าคอลัมน์. แต่ละแถวจะกลายเป็นชุดข้อมูลของแผนภูมิ. `ChartSheet` ถูกเลือกเป็นแผ่นงานที่เปิดอยู่ก่อนบันทึกสมุดงาน.

สมุดงานจะถูกบันทึกเป็น XLSX อย่างชัดเจน เพื่อให้ตรงกับส่วนขยาย `xlsx` ที่ส่งให้กับ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/). สตรีมอาร์เรย์ไบต์ของ Java เก็บสมุดงานและภาพในหน่วยความจำและให้ไบต์อาร์เรย์ที่จำเป็นต่อ API ของ Java. PNG จะถูกโหลดโดยตรงจากไบต์โดยไม่ต้องแปลงเป็นบิตแมพกลาง. การกำหนดผ่าน [getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) จะทดแทนตัวแทน OLE เริ่มต้น.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Images, OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("DataSheet")

    values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25],
    ]
    for row, row_values in enumerate(values):
        for column, value in enumerate(row_values):
            data_sheet.getCells().get(row, column).putValue(jpype.JInt(value))

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_sheet.setName("ChartSheet")

    last_chart_row = 55
    last_chart_column = 25
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
    chart = chart_sheet.getCharts().get(chart_index)
    for row in range(1, len(values) + 1):
        chart.getNSeries().add(f"DataSheet!A{row}:E{row}", False)

    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    workbook.getWorksheets().setOleSize(0, last_chart_row, 0, last_chart_column)

    # เร็นเดอร์ภาพตัวอย่างของแผนภูมิและทำการซีเรียลไลซ์สมุดงานที่สามารถแก้ไขได้แยกกัน.
    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    chart_image_stream = ByteArrayOutputStream()
    chart.toImage(chart_image_stream, image_options)
    chart_image_bytes = chart_image_stream.toByteArray()

    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.XLSX)
    workbook_bytes = workbook_stream.toByteArray()

    chart_image = Images.fromData(chart_image_bytes)
    try:
        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)
            slide_width = presentation.getSlideSize().getSize().getWidth()
            slide_height = presentation.getSlideSize().getSize().getHeight()

            # ปรับภาพตัวอย่างให้พอดีภายในสไลด์โดยไม่เปลี่ยนอัตราส่วนภาพ.
            scale = min(slide_width / chart_image.getWidth(), slide_height / chart_image.getHeight())
            frame_width = chart_image.getWidth() * scale
            frame_height = chart_image.getHeight() * scale
            frame_x = (slide_width - frame_width) / 2
            frame_y = (slide_height - frame_height) / 2

            embedded_data = OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.getImages().addImage(chart_image)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(preview_image)

            presentation.save("OutputChart.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        chart_image.dispose()
finally:
    workbook.dispose()
```

## **ผลลัพธ์ที่คาดหวัง**

`OutputChart.pptx` มีสไลด์หนึ่งสไลด์ที่มีสมุดงาน Excel ที่ฝังไว้และภาพตัวอย่างของแผนภูมิ. สมุดงานมีข้อมูลต้นฉบับและแผนภูมิคอลัมน์ที่มีสี่ชุดข้อมูล. ภาพตัวอย่างถูกจัดกึ่งกลางบนสไลด์และคงอัตราส่วนเดิม.

![แผนภูมิคอลัมน์ Excel แสดงเป็นภาพตัวอย่างของสมุดงานที่ฝังไว้](excel-chart-ole-preview.png)

ในสภาพแวดล้อม PowerPoint บนเดสก์ท็อปที่เข้ากันได้และมี Excel พร้อมใช้งาน, คลิกสองครั้งที่วัตถุเพื่อเปิดใช้งานและแก้ไขสมุดงานที่ฝังไว้. การเปิดใช้งานและการแก้ไขขึ้นอยู่กับการสนับสนุน OLE ของแอปพลิเคชันโฮสต์และการตั้งค่าความปลอดภัย.

## **คำถามที่พบบ่อย**

**ทำไมจึงต้องการภาพตัวอย่าง?**

สมุดงานที่ฝังไว้และภาพตัวอย่างของสไลด์เป็นเนื้อหาแยกกัน. ให้ภาพแผนภูมิเพื่อให้สไลด์แสดงแผนภูมิแทนตัวแทนเริ่มต้น "EMBEDDED OLE OBJECT". ดู [ปัญหาภาพตัวอย่างของอ็อบเจกต์เมื่อเพิ่ม OleObjectFrame](/slides/th/python-java/object-preview-issue-when-adding-oleobjectframe/).

**ภาพตัวอย่างจะอัปเดตโดยอัตโนมัติเมื่อฉันเปลี่ยนสมุดงานในโค้ดหรือไม่?**

ถือว่าภาพตัวอย่างเป็นสแนปชอต. เมื่ออัปเดตข้อมูลสมุดงานโดยโปรแกรม, ให้สร้างภาพแผนภูมิใหม่และแทนที่ภาพตัวอย่างพร้อมกับข้อมูลสมุดงานที่ฝังไว้.

**ฉันสามารถใช้ XLS แทน XLSX ได้หรือไม่?**

ได้. บันทึกสมุดงานในรูปแบบ XLS และใช้ `xls` เป็นส่วนขยายของข้อมูลที่ฝังไว้. ส่วนขยายต้องตรงกับรูปแบบสมุดงานจริง; การเปลี่ยนส่วนขยายอย่างเดียวไม่ทำให้ข้อมูลแปลงรูปแบบ.

**ทำไมวัตถุจึงอาจเปลี่ยนขนาดหลังจากการเปิดใช้งาน?**

แอปพลิเคชันโฮสต์อาจอัปเดตการแสดงผลของวัตถุ OLE เมื่อเปิดใช้งานสมุดงาน. ช่วงการแสดงผล OLE ของสมุดงานและมิติของกรอบสไลด์ล้วนมีผล. ดู [วิธีแก้ปัญหาการปรับขนาดแผนภูมิใน PPTX](/slides/th/python-java/working-solution-for-chart-resizing-in-pptx/).

## **ส่วนที่เกี่ยวข้อง**

- [วิธีแก้ปัญหาการปรับขนาดแผนภูมิใน PPTX](/slides/th/python-java/working-solution-for-chart-resizing-in-pptx/)
- [ปัญหาภาพตัวอย่างของอ็อบเจกต์เมื่อเพิ่ม OleObjectFrame](/slides/th/python-java/object-preview-issue-when-adding-oleobjectframe/)