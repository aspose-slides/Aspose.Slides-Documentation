---
title: วิธีแก้ปัญหาการปรับขนาดแผ่นงาน
type: docs
weight: 20
url: /th/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- ภาพตัวอย่าง
- การปรับขนาดภาพ
- Excel
- แผ่นงาน
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "แก้ไขการปรับขนาด OLE ของแผ่นงาน Excel ในงานนำเสนอ: วิธีสองวิธีเพื่อให้กรอบวัตถุคงที่—ปรับสเกลกรอบหรือแผ่นงาน—ในรูปแบบ PPT และ PPTX"
---
{{% alert color="info" title="หมายเหตุ" %}}

แผ่นงาน Excel ที่ฝังเป็นวัตถุ OLE ในงานนำเสนอ PowerPoint ด้วยส่วนประกอบ Aspose อาจปรับขนาดอย่างไม่คาดคิดหลังจากการเปิดใช้งานครั้งแรก พฤติกรรมนี้ทำให้เกิดความแตกต่างที่มองเห็นได้ระหว่างวัตถุ OLE ก่อนและหลังการเปิดใช้งาน บทความนี้อธิบายปัญหาและเสนอวิธีแก้ไขสองวิธี

{{% /alert %}}

## **พื้นหลัง**

ในบทความ [จัดการ OLE](/slides/th/python-java/manage-ole/) เราได้อธิบายวิธีเพิ่มกรอบ OLE ลงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for Python via Java เพื่อแก้ไข [ปัญหาการดูตัวอย่างวัตถุ](/slides/th/python-java/object-preview-issue-when-adding-oleobjectframe/) เราได้กำหนดภาพของพื้นที่แผ่นงานที่เลือกให้กับกรอบวัตถุ OLE ในงานนำเสนอ เมื่อคุณดับเบิลคลิกกรอบวัตถุ OLE ที่แสดงภาพแผ่นงาน Excel จะเปิดใช้งานเวิร์กบุ๊ก Excel ผู้ใช้สามารถทำการเปลี่ยนแปลงใด ๆ ที่ต้องการในเวิร์กบุ๊ก Excel จริง แล้วกลับไปที่สไลด์โดยคลิกนอกเวิร์กบุ๊ก Excel ที่เปิดใช้งาน ขนาดของกรอบวัตถุ OLE จะเปลี่ยนเมื่ผู้ใช้กลับไปที่สไลด์ ปัจจัยการปรับขนาดจะต่างกันตามขนาดของกรอบวัตถุ OLE และเวิร์กบุ๊ก Excel ที่ฝังอยู่

## **สาเหตุของการปรับขนาด**

เพราะเวิร์กบุ๊ก Excel มีขนาดหน้าต่างของตนเอง มันพยายามรักษาขนาดเดิมเมื่เปิดใช้งานครั้งแรก ในขณะที่กรอบวัตถุ OLE มีขนาดของมันเอง ตามที่ Microsoft ระบุ เมื่อเวิร์กบุ๊ก Excel ถูกเปิดใช้งาน Excel และ PowerPoint จะเจรจาขนาดเพื่อให้คงอัตราส่วนที่ถูกต้องเป็นส่วนหนึ่งของกระบวนการฝัง การปรับขนาดเกิดจากความแตกต่างระหว่างขนาดหน้าต่าง Excel กับขนาดและตำแหน่งของกรอบวัตถุ OLE

## **วิธีแก้ไขที่ทำงาน**

มีวิธีแก้ไขสองวิธีเพื่อหลีกเลี่ยงผลการปรับขนาด

- ปรับสเกลกรอบ OLE ในงานนำเสนอ PowerPoint ให้ตรงกับความสูงและความกว้างรวมของแถวและคอลัมน์ที่เลือก
- คงขนาดกรอบ OLE ไค่อย่างคงที่และปรับสเกลแถวและคอลัมน์ที่เลือกให้พอดีภายในกรอบ

### **ปรับขนาดกรอบ OLE**

วิธีนี้ตั้งค่าขนาดกรอบ OLE ให้ตรงกับความสูงและความกว้างรวมของแถวและคอลัมน์ที่เลือกในแผ่นงาน Excel ที่ฝังอยู่

ตัวอย่างโหลดเวิร์กบุ๊ก Excel ที่มีอยู่และเลือกแถวแรก 10 แถวและคอลัมน์แรก 13 คอลัมน์ของแผ่นงานแรกโดยใช้อินเดกซ์เริ่มจากศูนย์ [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) กำหนดช่วงที่แสดง ผลตัวอย่างถูกเรนเดอร์ที่ 96 DPI และแปลงขนาดพิกเซลเป็นจุดโดยอิง 72 จุดต่ออินช์ [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) ฝังเวิร์กบุ๊กที่แก้ไขไว้ในกรอบที่มีขนาดดังกล่าว ผลตัวอย่างถูกกำหนดผ่าน [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) เพื่อแทนที่ตัวเทียบทดแทน "EMBEDDED OLE OBJECT" ในงานนำเสนอที่บันทึก

ตัวช่วยผลตัวอย่างตั้งค่า [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) ให้เป็นช่วงที่เลือกและลบขอบกระดาษ ส่วนหัวและส่วนท้าย ด้วยการเปิดใช้งาน [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/python-java/asposecells.api/imageorprintoptions/#onlyarea) [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) จะเรนเดอร์ช่วงเป็นภาพ PNG ตัวช่วยจะคืน stream อินพุตใหม่ที่มีภาพ PNG อยู่ตรงแรกเพื่อใช้ในงานนำเสนอ

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

    # ตั้งค่าขนาดที่แสดงเมื่อเวิร์กบุ๊กถูกใช้เป็นวัตถุ OLE ใน PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # รับความกว้างและความสูงของภาพ OLE เป็นจุด.
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

            # เพิ่มภาพ OLE ลงในทรัพยากรของงานนำเสนอ.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # สร้างกรอบวัตถุ OLE.
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

### **ปรับขนาดช่วงเซลล์**

วิธีนี้ปรับความสูงของแถวที่เลือกและความกว้างของคอลัมน์ที่เลือกให้ตรงกับขนาดกรอบ OLE แบบกำหนดเอง

ตัวอย่างโหลดเวิร์กบุ๊ก Excel ที่มีอยู่และเลือกแถวแรก 10 แถวและคอลัมน์แรก 13 คอลัมน์ของแผ่นงานแรกโดยใช้อินเดกซ์เริ่มจากศูนย์ [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) กำหนดช่วงที่แสดง และตัวช่วย scale_cell_range จะปรับสเกลช่วงนั้นให้พอดีกับกรอบที่กว้าง 400 จุดและสูง 100 จุด หลังจากบันทึกเวิร์กบุ๊กที่แก้ไขลงใน stream แล้ว [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) จะฝังมันที่ขนาดที่ระบุ ผลตัวอย่างที่เรนเดอร์ที่ 96 DPI ถูกกำหนดผ่าน [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) ทำให้งานนำเสนอที่บันทึกแสดงเซลล์ที่เลือกแทนตัวเทียมเริ่มต้น

ตัวช่วยการสเกลคำนวณอัตราส่วนความกว้างและความสูงแยกกันสำหรับช่วงที่เลือก โดยคงอัตราส่วนความกว้างของคอลัมน์และความสูงของแถวไว้ จากนั้นแปลงมิติที่คำนวณจากจุดเป็นอินช์ก่อนนำไปใช้กับ [Cells.setColumnWidthInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setcolumnwidthinch) และ [Cells.setRowHeightInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setrowheightinch) ช่วงที่เลือกต้องมีความกว้างและความสูงไม่เป็นศูนย์

ตัวช่วยผลตัวอย่างนี้เรนเดอร์ช่วงที่ปรับขนาดใหม่โดยใช้ [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) มันจำกัด [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) ให้เหลือเพียงช่วงนั้น ลบขอบกระดาษ ส่วนหัวและส่วนท้าย และคืน stream PNG ที่ตำแหน่งเริ่มต้น

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

    # ตั้งค่าขนาดที่แสดงเมื่อเวิร์กบุ๊กถูกใช้เป็นวัตถุ OLE ใน PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # ปรับสเกลช่วงเซลล์ให้พอดีกับขนาดกรอบ.
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

            # เพิ่มภาพ OLE ลงในทรัพยากรของงานนำเสนอ.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # สร้างกรอบวัตถุ OLE.
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

มีสองวิธีในการแก้ไขปัญหาการปรับขนาดของแผ่นงาน เลือกวิธีที่ตรงกับความต้องการและกรณีการใช้งานของคุณ ทั้งสองวิธีทำงานเช่นเดียวกัน ไม่ว่าจะสร้างงานนำเสนอจากเทมเพลตหรือสร้างใหม่จากศูนย์ นอกจากนี้ไม่มีขีดจำกัดขนาดของกรอบวัตถุ OLE ในวิธีนี้

{{% /alert %}}

## **FAQ**

**ทำไมแผ่นงาน Excel ที่ฝังอยู่จึงเปลี่ยนขนาดเมื่อเปิดใช้งานครั้งแรกใน PowerPoint?**

เหตุการณ์นี้เกิดจาก Excel พยายามรักษาขนาดหน้าต่างเดิมเมื่เปิดใช้งาน ในขณะที่กรอบวัตถุ OLE ใน PowerPoint มีขนาดของมันเอง PowerPoint และ Excel จะเจรจาขนาดเพื่อคงอัตราส่วน ซึ่งทำให้เกิดการปรับขนาด

**สามารถป้องกันปัญหาการปรับขนาดนี้ได้ทั้งหมดหรือไม่?**

ได้ โดยการสเกลกรอบ OLE ให้พอดีกับขนาดช่วงเซลล์ Excel หรือสเกลช่วงเซลล์ให้พอดีกับขนาดกรอบ OLE ที่ต้องการ คุณจะป้องกันการปรับขนาดที่ไม่ต้องการได้

**ควรใช้วิธีสเกลแบบใด OLE frame scaling หรือ cell range scaling?**

เลือก **OLE frame scaling** หากต้องการคงขนาดแถวและคอลัมน์เดิมของ Excel เลือก **cell range scaling** หากต้องการให้กรอบ OLE มีขนาดคงที่ในงานนำเสนอของคุณ

**วิธีเหล่านี้จะทำงานหากงานนำเสนอของฉันสร้างจากเทมเพลตหรือไม่?**

ใช่ ทั้งสองวิธีทำงานได้กับงานนำเสนอที่สร้างจากเทมเพลตและจากศูนย์

**มีขีดจำกัดขนาดของกรอบ OLE เมื่อใช้วิธีเหล่านี้หรือไม่?**

ไม่มี คุณสามารถกำหนดขนาดกรอบวัตถุ OLE ได้ตามต้องการ เพียงตั้งค่าสเกลให้เหมาะสม

**มีวิธีใดที่จะหลีกเลี่ยงข้อความตัวเทียม "EMBEDDED OLE OBJECT" ใน PowerPoint หรือไม่?**

ได้ โดยการถ่ายภาพช่วงเซลล์ Excel ที่ต้องการและตั้งเป็นภาพตัวเทียมของกรอบ OLE คุณจะสามารถแสดงภาพตัวอย่างที่กำหนดเองแทนข้อความตัวเทียมเริ่มต้นได้

## **บทความที่เกี่ยวข้อง**

[สร้างแผนภูมิ Excel และฝังไว้ในงานนำเสนอเป็นวัตถุ OLE](/slides/th/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[อัปเดตวัตถุ OLE โดยอัตโนมัติด้วย MS PowerPoint Add-In](/slides/th/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)