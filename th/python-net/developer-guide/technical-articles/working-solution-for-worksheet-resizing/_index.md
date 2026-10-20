---
title: โซลูชันที่ทำงานได้สำหรับการปรับขนาดแผ่นงาน
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
- พรีเซ็นเทชัน
- Python
- Aspose.Slides
description: "แก้ไขการปรับขนาด OLE ของแผ่นงาน Excel ในพรีเซ็นเทชัน: สองวิธีเพื่อคงกรอบอ็อบเจ็กต์ให้สม่ำเสมอ—ปรับขนาดกรอบหรือแผ่นงาน—ในรูปแบบ PPT และ PPTX"
---
{{% alert color="info" title="Note" %}}
แผ่นงาน Excel ที่ฝังเป็นอ็อบเจ็กต์ OLE ในพรีเซ็นเทชัน PowerPoint ด้วยคอมโพเนนท์ Aspose อาจเปลี่ยนขนาดโดยไม่คาดคิดหลังจากการเปิดใช้งานครั้งแรก พฤติกรรมนี้ทำให้เกิดความแตกต่างด้านภาพที่เห็นได้ชัดระหว่างอ็อบเจ็กต์ OLE ก่อนและหลังการเปิดใช้งาน บทความนี้อธิบายปัญหาและวิธีแก้สองวิธี
{{% /alert %}}

## **พื้นฐาน**

ในบทความ [จัดการ OLE](/slides/th/python-net/manage-ole/) เราได้อธิบายวิธีเพิ่มกรอบ OLE ลงในพรีเซ็นเทชัน PowerPoint โดยใช้ Aspose.Slides for Python via .NET เพื่อแก้ไข [ปัญหาการแสดงตัวอย่างอ็อบเจ็กต์](/slides/th/python-net/object-preview-issue-when-adding-oleobjectframe/) เราได้กำหนดรูปภาพของพื้นที่แผ่นงานที่เลือกให้กับกรอบอ็อบเจ็กต์ OLE ในพรีเซ็นเทชันที่ส่งออก เมื่อคุณดับเบิลคลิกกรอบอ็อบเจ็กต์ OLE ที่แสดงภาพแผ่นงาน Excel จะทำการเปิดใช้งานเวิร์กบุ๊ก Excel ผู้ใช้สามารถทำการเปลี่ยนแปลงใด ๆ ที่ต้องการกับเวิร์กบุ๊กจริง แล้วกลับไปยังสไลด์โดยคลิกนอกเวิร์กบุ๊กที่เปิดใช้งาน ขนาดของกรอบอ็อบเจ็กต์ OLE จะเปลี่ยนเมื่อผู้ใช้กลับไปยังสไลด์ ปัจจัยการปรับขนาดจะแตกต่างกันขึ้นอยู่กับขนาดของกรอบอ็อบเจ็กต์ OLEและเวิร์กบุ๊ก Excel ที่ฝังอยู่

## **สาเหตุของการปรับขนาด**

เนื่องจากเวิร์กบุ๊ก Excel มีขนาดหน้าต่างของตนเอง มันพยายามรักษาขนาดเดิมไว้เมื่อเปิดใช้งานครั้งแรก ในขณะเดียวกันกรอบอ็อบเจ็กต์ OLE มีขนาดของตนเอง ตามข้อมูลของ Microsoft เมื่อเวิร์กบุ๊ก Excel ถูกเปิดใช้งาน Excel และ PowerPoint จะเจรจาขนาดเพื่อให้รักษาสัดส่วนที่ถูกต้องเป็นส่วนหนึ่งของกระบวนการฝัง การปรับขนาดเกิดขึ้นจากความแตกต่างระหว่างขนาดหน้าต่าง Excel กับขนาดและตำแหน่งของกรอบอ็อบเจ็กต์ OLE

## **วิธีแก้ที่ทำงานได้**

มีวิธีแก้สองวิธีเพื่อหลีกเลี่ยงผลการปรับขนาด

- ปรับขนาดกรอบ OLE ในพรีเซ็นเทชัน PowerPoint ให้ตรงกับความสูงและความกว้างรวมของแถวและคอลัมน์ที่เลือก
- รักษาขนาดกรอบ OLE คงที่และปรับขนาดแถวและคอลัมน์ที่เลือกให้พอดีกับกรอบ

### **ปรับขนาดกรอบ OLE**

วิธีนี้ตั้งค่าขนาดกรอบ OLE ให้ตรงกับความสูงและความกว้างรวมของแถวและคอลัมน์ที่เลือกในแผ่นงาน Excel ที่ฝังอยู่

ตัวอย่างโหลดเวิร์กบุ๊ก Excel ที่มีอยู่และเลือกแถวแรก 10 แถวและคอลัมน์แรก 13 คอลัมน์ของแผ่นงานแรกโดยใช้ดัชนีเริ่มจากศูนย์ [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) กำหนดช่วงที่จะแสดง การแสดงผลลัพธ์ถูกเรนเดอร์ที่ 96 DPI และมิติพิกเซลถูกแปลงเป็นพอยต์โดยใช้ 72 พอยต์ต่ออินช์ [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) ฝังเวิร์กบุ๊กที่แก้ไขแล้วในกรอบที่มีมิตินั้น การแสดงผลลัพธ์ถูกกำหนดผ่าน [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) เพื่อแทนที่ข้อความตัวอย่าง "EMBEDDED OLE OBJECT" ในพรีเซ็นเทชันที่บันทึก

ตัวช่วยแสดงตัวอย่างตั้งค่า [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) เป็นช่วงที่เลือกและลบขอบกระดาษส่วนหัวและส่วนท้าย พร้อมเปิดใช้งาน [ImageOrPrintOptions.only_area](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/imageorprintoptions/only_area/) [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) เรนเดอร์ช่วงเป็นภาพ PNG ตัวช่วยจะเลื่อนตำแหน่งสตรีมภาพกลับไปยังจุดเริ่มต้นก่อนส่งกลับเพื่อใช้ในพรีเซ็นเทชัน

```py
import io
import aspose.cells as cells

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

ตัวอย่างเต็มด้านล่างผสานตัวช่วยต่าง ๆ กับการฝังเวิร์กบุ๊กและบันทึกพรีเซ็นเทชันเป็น `output.pptx`

```py
import io
import aspose.slides as slides
import aspose.cells as cells

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

    # รับความกว้างและความสูงของภาพ OLE ในหน่วยพอยต์.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # เราต้องใช้เวิร์กบุ๊กที่แก้ไขแล้ว.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # เพิ่มภาพ OLE ไปยังทรัพยากรของพรีเซ็นเทชัน.
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

วิธีนี้ปรับความสูงของแถวที่เลือกและความกว้างของคอลัมน์ที่เลือกให้ตรงกับขนาดกรอบ OLE ที่กำหนดเอง

ตัวอย่างโหลดเวิร์กบุ๊ก Excel ที่มีอยู่และเลือกแถวแรก 10 แถวและคอลัมน์แรก 13 คอลัมน์ของแผ่นงานแรกโดยใช้ดัชนีเริ่มจากศูนย์ [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) กำหนดช่วงที่แสดง และตัวช่วยด้านล่างปรับขนาดช่วงนั้นให้พอดีกับกรอบกว้าง 400 พอยต์ สูง 100 พอยต์ หลังจากบันทึกเวิร์กบุ๊กที่แก้ไขลงในสตรีม [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) ฝังมันที่ขนาดที่ระบุ การแสดงผลลัพธ์ที่เรนเดอร์ที่ 96 DPI ถูกกำหนดผ่าน [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) ดังนั้นพรีเซ็นเทชันที่บันทึกจะแสดงเซลล์ที่เลือกแทนข้อความตัวอย่างเริ่มต้น

ตัวช่วยการปรับขนาดคำนวณอัตราส่วนความกว้างและความสูงแยกกันสำหรับช่วงที่เลือกโดยรักษาสัดส่วนความกว้างของคอลัมน์และความสูงของแถวไว้ มันแปลงมิติที่คำนวณจากพอยต์เป็นนิ้วก่อนนำไปใช้กับ [Cells.set_column_width_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_column_width_inch/) และ [Cells.set_row_height_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_row_height_inch/) ช่วงที่เลือกต้องมีความกว้างและความสูงที่ไม่เป็นศูนย์

```py
import aspose.cells as cells

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

ตัวช่วยแสดงตัวอย่างนี้เรนเดอร์ช่วงที่ปรับขนาดโดยใช้ [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) มันจำกัด [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) ให้เป็นช่วงนั้น ลบขอบ กระดาษส่วนหัวและส่วนท้าย แล้วส่งกลับสตรีม PNG ที่ตำแหน่งเริ่มต้น

```py
import io
import aspose.cells as cells

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

ตัวอย่างเต็มด้านล่างผสานตัวช่วยต่าง ๆ กับการฝังเวิร์กบุ๊กและบันทึกพรีเซ็นเทชันเป็น `output.pptx`

```py
import io
import aspose.slides as slides
import aspose.cells as cells

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

            # เพิ่มภาพ OLE ไปยังทรัพยากรของพรีเซ็นเทชัน.
            ole_image = presentation.images.add_image(image_stream)

            # สร้างกรอบอ็อบเจ็กต์ OLE.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **สรุป**

{{% alert color="info" title="Note" %}}
มีสองวิธีในการแก้ไขปัญหาการปรับขนาดแผ่นงาน เลือกวิธีที่เหมาะกับความต้องการและกรณีการใช้งานของคุณ ทั้งสองวิธีทำงานเหมือนกัน ไม่ว่าจะสร้างพรีเซ็นเทชันจากเทมเพลตหรือจากศูนย์ นอกจากนี้ไม่มีขีดจำกัดขนาดของกรอบอ็อบเจ็กต์ OLE ในวิธีนี้
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ทำไมแผ่นงาน Excel ที่ฝังอยู่ถึงเปลี่ยนขนาดเมื่อเปิดใช้งานครั้งแรกใน PowerPoint?**

เนื่องจาก Excel พยายามรักษาขนาดหน้าต่างเดิมเมื่อเปิดใช้งาน ขณะที่กรอบอ็อบเจ็กต์ OLE ใน PowerPoint มีขนาดของตนเอง PowerPoint และ Excel จะเจรจาขนาดเพื่อรักษาอัตราส่วนภาพ ซึ่งอาจทำให้เกิดการปรับขนาด

**สามารถป้องกันปัญหาการปรับขนาดนี้ได้อย่างสมบูรณ์หรือไม่?**

ได้ โดยการปรับขนาดกรอบ OLE ให้พอดีกับช่วงเซลล์ของ Excel หรือปรับขนาดช่วงเซลล์ให้พอดีกับกรอบ OLE ที่ต้องการ คุณจะสามารถป้องกันการปรับขนาดที่ไม่ต้องการได้

**ควรใช้วิธีปรับขนาดแบบใด OLE frame scaling หรือ cell range scaling?**

เลือก **OLE frame scaling** หากต้องการรักษาขนาดแถวและคอลัมน์ของ Excel ต้นฉบับ เลือก **cell range scaling** หากต้องการให้กรอบ OLE มีขนาดคงที่ในพรีเซ็นเทชันของคุณ

**วิธีแก้เหล่านี้จะทำงานได้หรือไม่หากพรีเซ็นเทชันของฉันสร้างจากเทมเพลต?**

ได้ ทั้งสองวิธีทำงานกับพรีเซ็นเทชันที่สร้างจากเทมเพลตและจากศูนย์

**มีขีดจำกัดขนาดของกรอบ OLE เมื่อใช้วิธีเหล่านี้หรือไม่?**

ไม่มี คุณสามารถตั้งกรอบอ็อบเจ็กต์ OLE ให้มีขนาดใดก็ได้ตราบใดที่ตั้งค่าสเกลอย่างเหมาะสม

**มีวิธีหลีกเลี่ยงข้อความตัวอย่าง "EMBEDDED OLE OBJECT" ใน PowerPoint หรือไม่?**

ได้ โดยการถ่ายภาพช่วงเซลล์ Excel ที่ต้องการและตั้งเป็นภาพตัวอย่างของกรอบ OLE คุณสามารถแสดงภาพตัวอย่างที่กำหนดเองแทนข้อความตัวอย่างเริ่มต้นได้