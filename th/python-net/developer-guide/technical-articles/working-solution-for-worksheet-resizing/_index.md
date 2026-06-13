---
title: วิธีแก้ปัญหาการปรับขนาดแผ่นงาน
type: docs
weight: 40
url: /th/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- ภาพตัวอย่าง
- การปรับขนาดภาพ
- Excel
- แผ่นงาน
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "แก้ไขการปรับขนาด OLE ของแผ่นงาน Excel ในการนำเสนอ: สองวิธีเพื่อคงความสอดคล้องของกรอบอ็อบเจกต์—ปรับขนาดกรอบหรือปรับขนาดแผ่นงาน—ในรูปแบบ PPT และ PPTX"
---
{{% alert color="primary" %}} 

พบว่าแผ่นงาน Excel ที่ฝังเป็นอ็อบเจ็กต์ OLE ในงานนำเสนอ PowerPoint ผ่านคอมโพเนนต์ของ Aspose จะถูกปรับขนาดเป็นสเกลที่ไม่ระบุหลังจากการเปิดใช้งานครั้งแรก พฤติกรรมนี้ทำให้เกิดความแตกต่างทางสายตาที่เห็นได้ชัดในพรีเซนเทชันระหว่างสถานะก่อนและหลังการเปิดใช้งานอ็อบเจ็กต์ OLE เราได้สำรวจปัญหานี้อย่างละเอียดและให้วิธีแก้ซึ่งอธิบายไว้ในบทความนี้

{{% /alert %}} 

## **พื้นหลัง**

ในบทความ [จัดการ OLE](/slides/th/python-net/manage-ole/), เราอธิบายวิธีการเพิ่มกรอบ OLE ไปยังงานพรีเซนเทชัน PowerPoint ด้วย Aspose.Slides for Python via .NET เพื่อแก้ไข [ปัญหาการแสดงตัวอย่างอ็อบเจ็กต์](/slides/th/python-net/object-preview-issue-when-adding-oleobjectframe/), เราได้กำหนดภาพของพื้นที่แผ่นงานที่เลือกให้กับกรอบอ็อบเจ็กต์ OLE ในงานพรีเซนเทชันผลลัพธ์ เมื่อคุณดับเบิลคลิกที่กรอบอ็อบเจ็กต์ OLE ที่แสดงภาพแผ่นงาน Excel ไฟล์งาน Excel จะถูกเปิดใช้งาน ผู้ใช้ขั้นสุดท้ายสามารถทำการเปลี่ยนแปลงใด ๆ ที่ต้องการกับไฟล์ Excel จริงได้และจากนั้นกลับไปที่สไลด์โดยคลิกนอกไฟล์ Excel ที่เปิดใช้งาน ขนาดของกรอบอ็อบเจ็กต์ OLE จะเปลี่ยนแปลงเมื่อผู้ใช้กลับไปที่สไลด์ ปัจจัยการปรับขนาดจะแตกต่างกันไปตามขนาดของกรอบอ็อบเจ็กต์ OLE และไฟล์ Excel ที่ฝังอยู่

## **สาเหตุของการปรับขนาด**

เนื่องจากไฟล์ Excel มีขนาดหน้าต่างของตนเอง มันพยายามคงขนาดเดิมไว้เมื่อเปิดใช้งานครั้งแรก ในขณะเดียวกันกรอบอ็อบเจ็กต์ OLE มีขนาดของมันเอง ตามข้อมูลของ Microsoft เมื่อไฟล์ Excel ถูกเปิดใช้งาน Excel และ PowerPoint จะเจรจาขนาดเพื่อให้แน่ใจว่าการฝังรักษาสัดส่วนที่ถูกต้อง การปรับขนาดเกิดจากความแตกต่างระหว่างขนาดหน้าต่าง Excel กับขนาดและตำแหน่งของกรอบอ็อบเจ็กต์ OLE

## **วิธีแก้ที่ทำงานได้**

มีสองวิธีแก้ที่เป็นไปได้เพื่อหลีกเลี่ยงผลกระทบของการปรับขนาด

- ปรับขนาดกรอบ OLE ในพรีเซนเทชัน PowerPoint ให้ตรงกับความสูงและความกว้างของจำนวนแถวและคอลัมน์ที่ต้องการในกรอบ OLE
- คงขนาดกรอบ OLE ไม่เปลี่ยนแปลงและปรับขนาดของแถวและคอลัมน์ที่เกี่ยวข้องให้พอดีกับขนาดกรอบ OLE ที่เลือก

### **ปรับขนาดกรอบ OLE**

ในแนวทางนี้ เราจะเรียนรู้วิธีตั้งค่าขนาดกรอบ OLE ของไฟล์ Excel ที่ฝังไว้ให้ตรงกับขนาดรวมของแถวและคอลัมน์ที่เกี่ยวข้องในแผ่นงาน Excel

สมมติว่าเรามีแผ่นงาน Excel แบบเทมเพลตและต้องการเพิ่มเป็นกรอบ OLE ในพรีเซนเทชัน ในกรณีนี้ ขนาดของกรอบอ็อบเจ็กต์ OLE จะถูกคำนวณเป็นขั้นแรกโดยอิงจากความสูงรวมของแถวและความกว้างรวมของคอลัมน์ของแถวและคอลัมน์ที่เกี่ยวข้องในไฟล์งาน จากนั้นเราจะตั้งค่าขนาดของกรอบ OLE ให้เป็นค่าที่คำนวณได้ เพื่อหลีกเลี่ยงข้อความสีแดง "EMBEDDED OLE OBJECT" ในกรอบ OLE ของ PowerPoint เราจะจับภาพส่วนที่ต้องการของแถวและคอลัมน์ในไฟล์งานและตั้งเป็นภาพกรอบ OLE ด้วย

```py
def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # ตั้งค่าขนาดที่แสดงเมื่อไฟล์เวิร์กบุ๊กใช้เป็นอ็อบเจ็กต์ OLE ใน PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # ดึงความกว้างและความสูงของภาพ OLE เป็นหน่วยพอยต์.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # เราต้องใช้เวิร์กบุ๊กที่แก้ไขแล้ว.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # เพิ่มภาพ OLE ไปยังทรัพยากรของพรีเซนเทชัน.
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # สร้างกรอบอ็อบเจ็กต์ OLE.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **ปรับขนาดช่วงเซลล์**

ในแนวทางนี้ เราจะเรียนรู้วิธีปรับความสูงของแถวที่เกี่ยวข้องและความกว้างของคอลัมน์ที่เกี่ยวข้องให้ตรงกับขนาดกรอบ OLE ที่กำหนดเอง

สมมติว่าเรามีแผ่นงาน Excel แบบเทมเพลตและต้องการเพิ่มเป็นกรอบ OLE ในพรีเซนเทชัน ในกรณีนี้ เราจะตั้งค่าขนาดของกรอบ OLE และปรับขนาดของแถวและคอลัมน์ที่เข้าร่วมในพื้นที่กรอบ OLE จากนั้นเราจะบันทึกไฟล์งานลงในสตรีมเพื่อใช้การเปลี่ยนแปลงและแปลงเป็นอาเรย์ไบต์เพื่อเพิ่มไปยังกรอบ OLE เพื่อหลีกเลี่ยงข้อความสีแดง "EMBEDDED OLE OBJECT" ในกรอบ OLE ของ PowerPoint เราจะจับภาพส่วนที่ต้องการของแถวและคอลัมน์ในไฟล์งานและตั้งเป็นภาพกรอบ OLE ด้วย

```py
# <param name="width">ความกว้างที่คาดหวังของช่วงเซลล์ในหน่วยพอยต์.</param>
# <param name="height">ความสูงที่คาดหวังของช่วงเซลล์ในหน่วยพอยต์.</param>
def scale_cell_range(cell_range, width, height):
    range_width = cell_range.width
    range_height = cell_range.height

    for i in range(cell_range.column_count):
        column_index = cell_range.first_column + i
        column_width = cell_range.worksheet.cells.get_column_width(column_index, False, cells.CellsUnitType.POINT)

        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72
        cell_range.worksheet.cells.set_column_width_inch(column_index, width_in_inches)

    for i in range(cell_range.row_count):
        row_index = cell_range.first_row + i
        row_height = cell_range.worksheet.cells.get_row_height(row_index, False, cells.CellsUnitType.POINT)

        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72
        cell_range.worksheet.cells.set_row_height_inch(row_index, height_in_inches)
```

```py
def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # ตั้งค่าขนาดที่แสดงเมื่อไฟล์เวิร์กบุ๊กใช้เป็นอ็อบเจ็กต์ OLE ใน PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # ปรับขนาดช่วงเซลล์ให้พอดีกับขนาดกรอบ.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # เราต้องใช้เวิร์กบุ๊กที่แก้ไขแล้ว.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # เพิ่มภาพ OLE ไปยังทรัพยากรของพรีเซนเทชัน.
            ole_image = presentation.images.add_image(image_stream)

            # สร้างกรอบอ็อบเจ็กต์ OLE.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **สรุป**

{{% alert color="primary" %}}

มีสองวิธีเพื่อแก้ไขปัญหาการปรับขนาดแผ่นงาน การเลือกวิธีที่เหมาะสมขึ้นอยู่กับความต้องการและกรณีการใช้งานเฉพาะ ทั้งสองวิธีทำงานเช่นเดียวกัน ไม่ว่าจะสร้างพรีเซนเทชันจากเทมเพลตหรือจากศูนย์ นอกจากนี้ไม่มีขีดจำกัดขนาดของกรอบอ็อบเจ็กต์ OLE ในวิธีแก้นี้

{{% /alert %}}