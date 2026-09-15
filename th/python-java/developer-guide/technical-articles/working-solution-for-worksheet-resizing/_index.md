---
title: โซลูชันการทำงานสำหรับการปรับขนาดเวิร์กชีต
type: docs
weight: 20
url: /th/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- ภาพตัวอย่าง
- การปรับขนาดภาพ
- Excel
- เวิร์กชีต
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "แก้ไขการปรับขนาด OLE ของเวิร์กชีต Excel ในงานนำเสนอ: สองวิธีเพื่อคงความสอดคล้องของเฟรมอ็อบเจกต์—ปรับสเกลเฟรมหรือแผ่นงาน—ทั่วรูปแบบ PPT และ PPTX."
---
{{% alert color="info" title="หมายเหตุ" %}}

พบว่าเวิร์กชีต Excel ที่ฝังเป็นอ็อบเจกต์ OLE ในงานนำเสนอ PowerPoint ผ่านคอมโพเนนท์ Aspose จะถูกปรับขนาดเป็นสเกลที่ไม่ระบุหลังจากการเปิดใช้งานครั้งแรก พฤติกรรมนี้ทำให้เกิดความแตกต่างที่มองเห็นได้ระหว่างสถานะก่อนและหลังการเปิดใช้งานของอ็อบเจกต์ OLE เราได้ตรวจสอบปัญหานี้อย่างละเอียดและนำเสนอวิธีแก้ไขในบทความนี้

{{% /alert %}}

## **พื้นหลัง**

ในบทความ [จัดการ OLE](/slides/th/python-java/manage-ole/) เราได้อธิบายวิธีเพิ่มเฟรม OLE ลงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for Python via Java เพื่อแก้ไขปัญหา [object preview issue](/slides/th/python-java/object-preview-issue-when-adding-oleobjectframe/) เราได้กำหนดรูปภาพของพื้นที่เวิร์กชีตที่เลือกให้กับเฟรมอ็อบเจกต์ OLE ในงานนำออกที่ได้ เมื่อคุณดับเบิลคลิกที่เฟรมอ็อบเจกต์ OLE ที่แสดงรูปภาพเวิร์กชีต Excel จะทำการเปิดใช้งานเวิร์กบุค์ Excel ผู้ใช้สามารถทำการเปลี่ยนแปลงใด ๆ ที่ต้องการในเวิร์กบุ๊คจริง แล้วคลิกนอกเวิร์กบุ๊กที่เปิดใช้งานเพื่อกลับสู่สไลด์ ขนาดของเฟรมอ็อบเจกต์ OLE จะเปลี่ยนแปลงเมื่อผู้ใช้กลับสู่สไลด์ ปัจจัยการปรับขนาดจะแตกต่างกันไปตามขนาดของเฟรมอ็อบเจกต์ OLE และเวิร์กบุ๊ก Excel ที่ฝังอยู่

## **สาเหตุของการปรับขนาด**

เนื่องจากเวิร์กบุ๊ก Excel มีขนาดหน้าต่างของตนเอง มันพยายามรักษาขนาดเดิมเมื่อเปิดใช้งานครั้งแรก ในขณะเดียวกันเฟรมอ็อบเจกต์ OLE มีขนาดของตนเอง ตาม Microsoft เมื่อเวิร์กบุ๊ก Excel ถูกเปิดใช้งาน Excel และ PowerPoint จะเจรจากันเพื่อกำหนดขนาดให้คงอัตราส่วนที่ถูกต้องเป็นส่วนหนึ่งของกระบวนการฝัง การปรับขนาดเกิดจากความแตกต่างระหว่างขนาดหน้าต่าง Excel กับขนาดและตำแหน่งของเฟรมอ็อบเจกต์ OLE

## **วิธีแก้ไขที่ทำงานได้**

มีสองวิธีที่เป็นไปได้เพื่อหลีกเลี่ยงผลกระทบจากการปรับขนาด

- ปรับสเกลขนาดเฟรม OLE ในงานนำเสนอ PowerPoint ให้ตรงกับความสูงและความกว้างของจำนวนแถวและคอลัมน์ที่ต้องการในเฟรม OLE
- รักษาขนาดเฟรม OLE คงที่และปรับสเกลขนาดของแถวและคอลัมน์ที่เข้าร่วมเพื่อให้พอดีกับขนาดเฟรม OLE ที่เลือก

### **ปรับสเกลขนาดเฟรม OLE**

ในวิธีนี้ เราจะเรียนรู้วิธีตั้งค่าขนาดเฟรม OLE ของเวิร์กบุ๊ก Excel ที่ฝังให้ตรงกับขนาดรวมของแถวและคอลัมน์ที่เข้าร่วมในเวิร์กชีต

สมมติว่ามีเทมเพลตเวิร์กชีต Excel และต้องการเพิ่มลงในงานนำเสนอเป็นเฟรม OLE ในสถานการณ์นี้ ขนาดของเฟรมอ็อบเจกต์ OLE จะถูกคำนวณเป็นครั้งแรกตามความสูงรวมของแถวและความกว้างรวมของคอลัมน์ที่เข้าร่วมในเวิร์กบุ๊ก จากนั้นเราจะตั้งค่าขนาดของเฟรม OLE ให้เป็นค่าที่คำนวณนี้ เพื่อหลีกเลี่ยงข้อความสีแดง "EMBEDDED OLE OBJECT" สำหรับเฟรม OLE ใน PowerPoint เราจะจับภาพส่วนที่ต้องการของแถวและคอลัมน์ในเวิร์กบุ๊กและตั้งค่าเป็นรูปภาพของเฟรม OLE

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96

workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # ตั้งขนาดที่แสดงเมื่อเวิร์กบุ๊กถูกใช้เป็นอ็อบเจกต์ OLE ใน PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # รับความกว้างและความสูงของภาพ OLE เป็นหน่วยจุด.
        image_io = jpype.JClass("javax.imageio.ImageIO")
        image = image_io.read(image_stream)
        frame_width = image.getWidth() * 72.0 / image_resolution
        frame_height = image.getHeight() * 72.0 / image_resolution

        # ใช้เวิร์กบุ๊กที่แก้ไขแล้ว.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # เพิ่มภาพ OLE ไปยังทรัพยากรของงานนำเสนอ.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # สร้างเฟรมอ็อบเจกต์ OLE.
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

### **ปรับสเกลขนาดช่วงเซลล์**

ในวิธีนี้ เราจะเรียนรู้วิธีปรับสเกลความสูงของแถวที่เข้าร่วมและความกว้างของคอลัมน์ที่เข้าร่วมให้ตรงกับขนาดเฟรม OLE ที่กำหนดเอง

สมมติว่ามีเทมเพลตเวิร์กชีต Excel และต้องการเพิ่มลงในงานนำเสนอเป็นเฟรม OLE ในสถานการณ์นี้ เราจะตั้งค่าขนาดของเฟรม OLE และปรับสเกลขนาดของแถวและคอลัมน์ที่เข้าร่วมในพื้นที่เฟรม OLE จากนั้นจะบันทึกเวิร์กบุ๊กลงในสตรีมเพื่อใช้การเปลี่ยนแปลงและแปลงเป็นอาร์เรย์ไบต์เพื่อเพิ่มลงในเฟรม OLE เพื่อหลีกเลี่ยงข้อความสีแดง "EMBEDDED OLE OBJECT" สำหรับเฟรม OLE ใน PowerPoint เราจะจับภาพส่วนที่ต้องการของแถวและคอลัมน์ในเวิร์กบุ๊กและตั้งค่าเป็นรูปภาพของเฟรม OLE

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpate.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


def scale_cell_range(cell_range, width, height):
    # ความกว้างและความสูงที่คาดหวังของช่วงเซลล์เป็นหน่วยจุด.
    range_width = cell_range.getWidth()
    range_height = cell_range.getHeight()
    cells = cell_range.getWorksheet().getCells()

    for i in range(cell_range.getColumnCount()):
        column_index = cell_range.getFirstColumn() + i
        column_width = cells.getColumnWidth(column_index, False, CellsUnitType.POINT)
        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72.0
        cells.setColumnWidthInch(column_index, width_in_inches)

    for i in range(cell_range.getRowCount()):
        row_index = cell_range.getFirstRow() + i
        row_height = cells.getRowHeight(row_index, False, CellsUnitType.POINT)
        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72.0
        cells.setRowHeightInch(row_index, height_in_inches)


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96
frame_width, frame_height = 400.0, 100.0
workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # ตั้งขนาดที่แสดงเมื่อเวิร์กบุ๊กถูกใช้เป็นอ็อบเจกต์ OLE ใน PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # ปรับสเกลช่วงเซลล์ให้พอดีกับขนาดเฟรม.
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # ใช้เวิร์กบุ๊กที่แก้ไขแล้ว.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # เพิ่มภาพ OLE ไปยังทรัพยากรของงานนำเสนอ.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # สร้างเฟรมอ็อบเจกต์ OLE.
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

## **สรุป**

{{% alert color="info" title="หมายเหตุ" %}} 

มีสองวิธีในการแก้ปัญหาการปรับขนาดของเวิร์กชีต การเลือกวิธีที่เหมาะสมขึ้นอยู่กับความต้องการและกรณีการใช้งาน ทั้งสองวิธีทำงานในลักษณะเดียวกัน ไม่ว่าจะสร้างงานนำเสนอจากเทมเพลตหรือจากศูนย์ นอกจากนี้ไม่มีขีดจำกัดขนาดของเฟรมอ็อบเจกต์ OLE ในวิธีนี้

{{% /alert %}}

## **คำถามที่พบบ่อย**

**ทำไมเวิร์กชีต Excel ที่ฝังอยู่ถึงเปลี่ยนขนาดเมื่อเปิดใช้งานครั้งแรกใน PowerPoint?**

เกิดจาก Excel พยายามรักษาขนาดหน้าต่างเดิมขณะเปิดใช้งาน ในขณะที่เฟรมอ็อบเจกต์ OLE ใน PowerPoint มีขนาดของตนเอง PowerPoint และ Excel จะเจรจาขนาดเพื่อรักษาอัตราส่วน ซึ่งอาจทำให้เกิดการปรับขนาด

**สามารถป้องกันปัญหาการปรับขนาดนี้ได้โดยสมบูรณ์หรือไม่?**

ทำได้ โดยการปรับสเกลเฟรม OLE ให้พอดีกับช่วงเซลล์ Excel หรือปรับสเกลช่วงเซลล์ให้พอดีกับขนาดเฟรม OLE ที่ต้องการ คุณจะป้องกันการปรับขนาดที่ไม่ต้องการได้

**ควรใช้วิธีการสเกลแบบใด ระหว่างการสเกลเฟรม OLE หรือการสเกลช่วงเซลล์?**

เลือก **การสเกลเฟรม OLE** หากต้องการรักษาขนาดแถวและคอลัมน์ของ Excel ดั้งเดิม เลือก **การสเกลช่วงเซลล์** หากต้องการขนาดคงที่สำหรับเฟรม OLE ในงานนำเสนอของคุณ

**วิธีการเหล่านี้จะทำงานหากงานนำเสนอของฉันสร้างจากเทมเพลตหรือไม่?**

ใช่ ทั้งสองวิธีทำงานกับงานนำเสนอที่สร้างจากเทมเพลตและจากศูนย์

**มีขีดจำกัดขนาดของเฟรม OLE เมื่อใช้วิธีเหล่านี้หรือไม่?**

ไม่มี คุณสามารถกำหนดขนาดเฟรมอ็อบเจกต์ OLE ใด ๆ ก็ได้ตราบใดที่ตั้งค่าสเกลอย่างเหมาะสม

**มีวิธีใดที่จะหลีกเลี่ยงข้อความตัวอักษร "EMBEDDED OLE OBJECT" ใน PowerPoint หรือไม่?**

มี โดยการจับภาพช่วงเซลล์ Excel ที่ต้องการและตั้งเป็นรูปภาพแทนที่ของเฟรม OLE คุณจะได้แสดงภาพตัวอย่างที่กำหนดเองแทนตัวแทนค่าเริ่มต้น

## **บทความที่เกี่ยวข้อง**

[การสร้างแผนภูมิ Excel และฝังลงในงานนำเสนอเป็นอ็อบเจกต์ OLE](/slides/th/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)