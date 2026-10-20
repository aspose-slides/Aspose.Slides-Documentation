---
title: สร้างแผนภูมิ Excel และฝังไว้ในงานนำเสนอเป็นอ็อบเจกต์ OLE
type: docs
weight: 50
url: /th/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- แผนภูมิ Excel
- ฝังแผนภูมิ
- อ็อบเจกต์ OLE
- PowerPoint
- งานนำเสนอ
- Python
- Python via .NET
- Aspose.Slides
description: "สร้างแผนภูมิ Excel ด้วย Aspose.Cells for Python via .NET และฝังเวิร์กบุ๊กในงานนำเสนอ PowerPoint ด้วย Aspose.Slides พร้อมตัวอย่างแผนภูมิ"
---
## **ภาพรวม**

บทความนี้แสดงวิธีสร้างแผนภูมิคอลัมน์ของ Excel ด้วย Aspose.Cells for Python via .NET และฝังเวิร์กบุ๊กของมันลงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for Python via .NET เวิร์กบุ๊กที่ฝังไว้จะประกอบด้วยข้อมูลต้นทางและแผนภูมิทั้งสอง ส่วนตัวอย่าง PNG แยกต่างหากจะแสดงแผนภูมิบนสไลด์ก่อนที่วัตถุ OLE จะถูกเปิดใช้งาน

ผลลัพธ์คืออ็อบเจกต์ Excel ที่ฝังคือ ไม่ใช่แผนภูมิ PowerPoint แบบดั้งเดิม การแก้ไขเวิร์กบุ๊กผ่าน OLE ต้องใช้แอปพลิเคชันบนเดสก์ท็อปที่รองรับการเปิดใช้งาน OLE และการติดตั้ง Excel ที่เข้ากันได้

## **ข้อกำหนดเบื้องต้น**

ติดตั้งแพคเกจ `aspose-cells-python` และ `aspose-slides` ในสภาพแวดล้อม Python ของคุณ ไม่จำเป็นต้องมี Microsoft Office เพื่อสร้างงานนำเสนอด้วยไลบรารีเหล่านี้

ไม่ต้องใช้ไฟล์อินพุตใด ๆ: ตัวอย่างจะสร้างข้อมูลและแผนภูมิในหน่วยความจำ แล้วเขียนไฟล์ `OutputChart.pptx` ไปยังไดเรกทอรีทำงานปัจจุบัน ใช้ไลเซนส์สำหรับผลิตภัณฑ์ทั้งสองเมื่อรันนอกโหมดประเมินผล

## **วิธีการทำงานของการฝัง**

1. สร้างเวิร์กบุ๊กที่มีแผ่นงานข้อมูลและแผ่นแผนภูมิ
2. ตั้งค่าแผ่นแผนภูมิให้เป็นแผ่นที่ทำงานอยู่เพื่อให้เวิร์กบุ๊กเปิดที่แผนภูมิ
3. กำหนดช่วงการแสดงผล OLE ของเวิร์กบุ๊กและเรนเดอร์แผนภูมิเป็น PNG
4. บันทึกเวิร์กบุ๊กเป็น XLSX ในหน่วยความจำและฝังไบต์เหล่านั้นลงในสไลด์
5. กำหนด PNG เป็นตัวอย่างของอ็อบเจกต์ OLE และบันทึกงานนำเสนอเป็น PPTX

ช่วงการแสดงผลของเวิร์กบุ๊กและกรอบบนสไลด์มีบทบาทที่แตกต่างกัน [set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) รับค่าตำแหน่งแถวและคOLUMN เริ่มต้น/สิ้นสุดแบบศูนย์ฐาน. [ChartCollection.add](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chartcollection/add/) แทนที่จะรับแถวบน, คอลัมน์ซ้าย, แถวล่าง, และคอลัมน์ขวา. ตัวอย่างใช้ดัชนีแถว 55 และดัชนีคอลัมน์ 25 เป็นขอบล่าง‑ขวา; ค่าต่าง ๆ เหล่านี้เป็นการกำหนดเค้าโครง ไม่ได้หมายถึงจำนวนแถวหรือคอลัมน์ของข้อมูล

กรอบสไลด์ใช้หน่วยจุด ตัวอย่างปรับให้พอดีกับสไลด์และจัดกึ่งกลางขณะคงอัตราส่วนภาพของ PNG ไว้ ไม่ได้ยืดตัวอย่างให้เต็มสไลด์

## **สร้างและฝังแผนภูมิ**

ตัวอย่างเต็มต่อไปนี้จะเติมค่าใน `DataSheet` ด้วยแถวสี่แถวและคอลัมน์ห้าคอลัมน์ ค่าของแต่ละแถวจะกลายเป็นชุดข้อมูลของแผนภูมิ `ChartSheet` จะถูกเลือกเป็นแผ่นทำงานที่ใช้งานอยู่ก่อนบันทึกเวิร์กบุ๊ก

เวิร์กบุ๊กจะถูกบันทึกเป็น XLSX อย่างชัดเจน เพื่อให้ตรงกับส่วนขยาย `xlsx` ที่ส่งผ่านไปยัง [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/). PNG จะถูกโหลดโดยตรงจากสตรีมโดยไม่ต้องแปลงเป็นบิตแมประหว่างขั้นตอน การใส่ค่าโดยใช้ [substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/ioleobjectframe/substitute_picture_format/) จะทำให้แทนที่ตัวอธิบายภาพ OLE เริ่มต้น

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.cells.drawing as drawing
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "DataSheet"

values = [
    [67, 44, 46, 43, 24],
    [86, 64, 97, 29, 40],
    [68, 89, 78, 69, 38],
    [91, 48, 60, 26, 25],
]

for row, row_values in enumerate(values):
    for column, value in enumerate(row_values):
        data_sheet.cells.get(row, column).put_value(value)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_sheet.name = "ChartSheet"

last_chart_row = 55
last_chart_column = 25
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
chart = chart_sheet.charts[chart_index]
for row in range(1, len(values) + 1):
    chart.n_series.add(f"DataSheet!A{row}:E{row}", False)

workbook.worksheets.active_sheet_index = chart_sheet_index
workbook.worksheets.set_ole_size(0, last_chart_row, 0, last_chart_column)

# เรนเดอร์ภาพตัวอย่างของแผนภูมิและทำการจัดเก็บเวิร์กบุ๊กที่แก้ไขได้แยกออกจากกัน.
with io.BytesIO() as chart_image_stream, io.BytesIO() as workbook_stream:
    chart.to_image(chart_image_stream, drawing.ImageType.PNG)
    chart_image_stream.seek(0)
    workbook.save(workbook_stream, cells.SaveFormat.XLSX)
    workbook_bytes = workbook_stream.getvalue()

    with slides.Images.from_stream(chart_image_stream) as chart_image:
        with slides.Presentation() as presentation:
            slide = presentation.slides[0]
            slide_size = presentation.slide_size.size

            # ปรับให้ภาพตัวอย่างพอดีกับสไลด์โดยไม่เปลี่ยนอัตราส่วนของภาพ.
            scale = min(slide_size.width / chart_image.width, slide_size.height / chart_image.height)
            frame_width = chart_image.width * scale
            frame_height = chart_image.height * scale
            frame_x = (slide_size.width - frame_width) / 2
            frame_y = (slide_size.height - frame_height) / 2

            embedded_data = slides.dom.ole.OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.images.add_image(chart_image)
            ole_frame.substitute_picture_format.picture.image = preview_image

            presentation.save("OutputChart.pptx", slides.export.SaveFormat.PPTX)
```

## **ผลลัพธ์ที่คาดหวัง**

`OutputChart.pptx` มีสไลด์หนึ่งที่ฝังเวิร์กบุ๊ก Excel และตัวอย่างแผนภูมิ ตัวเวิร์กบุ๊กมีข้อมูลต้นฉบับและแผนภูมิคอลัมน์ที่มีสี่ชุด ข้อเสนอนั้นถูกจัดกึ่งกลางบนสไลด์และคงสัดส่วนไว้

![แผนภูมิคอลัมน์ของ Excel แสดงเป็นตัวอย่างของเวิร์กบุ๊กที่ฝัง](excel-chart-ole-preview.png)

ในสภาพแวดล้อม PowerPoint บนเดสก์ท็อปที่รองรับพร้อมกับ Excel ที่มีอยู่ การคลิกสองครั้งที่อ็อบเจกต์จะทำให้เปิดใช้งานและแก้ไขเวิร์กบุ๊กที่ฝัง การเปิดใช้งานและการแก้ไขขึ้นอยู่กับการสนับสนุน OLE ของแอปพลิเคชันโฮสต์และการตั้งค่าความปลอดภัย

## **คำถามที่พบบ่อย**

**ทำไมต้องใช้ภาพตัวอย่าง?**

เวิร์กบุ๊กที่ฝังและตัวอย่างบนสไลด์เป็นเนื้อหาแยกกัน ให้ภาพแผนภูมิเพื่อให้สไลด์แสดงแผนภูมิแทนที่ตัวอธิบายค่าเริ่มต้น "EMBEDDED OLE OBJECT" ดู [ปัญหาการแสดงตัวอย่างอ็อบเจกต์เมื่อเพิ่ม OleObjectFrame](/slides/th/python-net/object-preview-issue-when-adding-oleobjectframe/).

**ตัวอย่างจะอัปเดตโดยอัตโนมัติเมื่อฉันเปลี่ยนเวิร์กบุ๊กในโค้ดหรือไม่?**

ให้ถือว่าตัวอย่างเป็นภาพสแนปช็อต เมื่อต้องการอัปเดตข้อมูลเวิร์กบุ๊กโดยโปรแกรม ให้สร้างภาพแผนภูมิใหม่และแทนที่ตัวอย่างพร้อมกับข้อมูลเวิร์กบุ๊กที่ฝัง

**ฉันสามารถใช้ XLS แทน XLSX ได้หรือไม่?**

ได้. ให้บันทึกเวิร์กบุ๊กในรูปแบบ XLS และใช้ `xls` เป็นส่วนขยายของข้อมูลที่ฝัง ส่วนขยายต้องตรงกับรูปแบบเวิร์กบุ๊กจริง; การเปลี่ยนส่วนขยายอย่างเดียวไม่ได้แปลงข้อมูล

**ทำไมอ็อบเจกต์อาจเปลี่ยนขนาดหลังจากเปิดใช้งาน?**

แอปพลิเคชันโฮสต์อาจอัปเดตการนำเสนอของอ็อบเจกต์ OLE เมื่อเปิดใช้งานเวิร์กบุ๊ก ช่วงการแสดงผล OLE ของเวิร์กบุ๊กและขนาดกรอบสไลด์ล้วนมีความสำคัญ ดู [ปรับขนาดอ็อบเจกต์ OLE โดยอัตโนมัติในงานนำเสนอ PowerPoint](/slides/th/python-net/working-solution-for-worksheet-resizing/).

## **ส่วนที่เกี่ยวข้อง**

- [ปรับขนาดอ็อบเจกต์ OLE โดยอัตโนมัติในงานนำเสนอ PowerPoint](/slides/th/python-net/working-solution-for-worksheet-resizing/)
- [ปัญหาการแสดงตัวอย่างอ็อบเจกต์เมื่อเพิ่ม OleObjectFrame](/slides/th/python-net/object-preview-issue-when-adding-oleobjectframe/)
- [จัดการอ็อบเจกต์ OLE](/slides/th/python-net/manage-ole/)