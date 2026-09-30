---
title: จัดการแถวและคอลัมน์ในตาราง PowerPoint ด้วย Python
linktitle: แถวและคอลัมน์
type: docs
weight: 20
url: /th/python-net/manage-rows-and-columns/
keywords:
- แถวตาราง
- คอลัมน์ตาราง
- แถวแรก
- หัวตาราง
- คัดลอกแถว
- คัดลอกคอลัมน์
- คัดลอกแถว
- คัดลอกคอลัมน์
- ลบแถว
- ลบคอลัมน์
- การจัดรูปแบบข้อความในแถว
- การจัดรูปแบบข้อความในคอลัมน์
- สไตล์ตาราง
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "จัดการแถวและคอลัมน์ของตารางใน PowerPoint ด้วย Aspose.Slides for Python via .NET และเร่งการแก้ไขงานนำเสนอและการอัปเดตข้อมูล."
---
## **บทนำ**

Aspose.Slides for Python via .NET ช่วยให้คุณจัดการโครงสร้างตารางและการจัดรูปแบบในงานนำเสนอ PowerPoint ผ่านคลาส [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) คุณสามารถกำหนดแถวหัวเรื่อง, คัดลอกหรือเอาแถวและคอลัมน์ออก, และใช้การจัดรูปแบบข้อความกับแถวหรือคอลัมน์ทั้งหมดได้

บทความนี้อธิบายการดำเนินการเหล่านี้ด้วยตัวอย่าง Python นอกจากนี้ยังแสดงวิธีดึงค่า preset ของสไตล์ตารางเพื่อให้คุณนำกลับมาใช้ใหม่ ดัชนีแถวและคอลัมน์ของตารางเริ่มจาก 0

## **ควบคุมความสูงของแถว**

ใช้ [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) เพื่ตั้งความสูงขั้นต่ำของแถวเป็นจุด (points) ค่านี้เป็นค่าขอบล่าง ไม่ใช่ความสูงคงที่ [Row.height](https://reference.aspose.com/slides/python-net/aspose.slides/row/height/) จะคืนค่าความสูงจริงและเป็นแบบอ่านอย่างเดียว เข้าถึงแถวผ่าน [Table.rows](https://reference.aspose.com/slides/python-net/aspose.slides/table/rows/)

ตัวอย่างโหลดไฟล์ [row-height-input.pptx](row-height-input.pptx) ซึ่งมีตารางเป็นรูปร่างแรกบนสไลด์แรก แถวแรกเริ่มที่ 70 จุด เซลล์ใช้ข้อความ Arial ขนาด 18 จุด, พับบรรทัด, และระยะขอบบนและล่าง 6 จุด; ข้อความที่ยาวกว่าในคอลัมน์ที่สองจะพับเป็นหลายบรรทัด ตัวอย่างเพิ่มค่าขั้นต่ำเป็น 100 จุด, จากนั้นลดลงเป็น 20 จุด, พิมพ์ความสูงจริงหลังการเปลี่ยนแต่ละครั้ง, และบันทึกผลลัพธ์ทั้งสอง

```python
import aspose.slides as slides

with slides.Presentation("row-height-input.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    row = table.rows[0]

    row.minimal_height = 100
    print(f"Increased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-increased.pptx", slides.export.SaveFormat.PPTX)

    row.minimal_height = 20
    print(f"Decreased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-decreased.pptx", slides.export.SaveFormat.PPTX)
```

ด้วยงานนำเสนอที่ให้มา, การเพิ่มค่าขั้นต่ำจะเพิ่มพื้นที่ให้กับแถว การลดค่าขั้นต่ำจะลบพื้นที่เพิ่มนั้นออก, แต่ความสูงจริงยังคงมากกว่า 20 จุดเนื่องจากข้อความและระยะขอบของเซลล์ต้องการพื้นที่มาก การลดค่าขั้นต่ำเพียงอย่างเดียวไม่สามารถบังคับให้แถวต่ำกว่าพื้นที่ที่เนื้อหาต้องการได้

หลายปัจจัยส่งผลต่อความสูงจริง:

- **ข้อความและขนาดฟอนต์:** ข้อความยาว, การขึ้นบรรทัดใหม่โดยชัดเจน, หรือฟอนต์ที่ใหญ่กว่าจะต้องการพื้นที่แนวตั้งเพิ่มขึ้น
- **การพับบรรทัดและความกว้างคอลัมน์:** หากเปิดการพับบรรทัด, ความกว้าง [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) ที่แคบจะทำให้เกิดบรรทัดเพิ่มขึ้น คอลัมน์ที่กว้างขึ้นจะลดพื้นที่แนวตั้งที่ต้องการ
- **ระยะขอบของเซลล์:** [Cell.margin_top](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_top/) และ [Cell.margin_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_bottom/) เพิ่มพื้นที่แนวตั้ง [Cell.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_left/) และ [Cell.margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_right/) ลดความกว้างที่ใช้สำหรับข้อความและอาจทำให้เกิดการพับบรรทัดเพิ่มขึ้น

สำหรับตารางนี้ที่ไม่มีเซลล์ผสาน, เซลล์ที่ต้องการพื้นที่แนวตั้งมากที่สุดจะกำหนดขอบล่างตามเนื้อหาสำหรับแถวทั้งหมด หากต้องการทำให้แถวสั้นลง คุณอาจต้องย่นข้อความ, ลดขนาดฟอนต์หรือระยะขอบ, หรือเพิ่มความกว้างของคอลัมน์

รูปภาพด้านล่างแสดงตารางเดียวกันในสเกลเดียวกัน ในการทดลองนี้ ความสูงจริงเป็น 70, 100, และ 55.2 จุด: แถวสุดท้ายยังสูงกว่าขั้นต่ำ 20 จุด การวัดข้อความที่แม่นยำอาจแตกต่างกันตามฟอนต์ที่มีในสภาพแวดล้อมของคุณ ดาวน์โหลดผลลัพธ์ที่บันทึกไว้: [increased minimum](row-height-increased.pptx) และ [decreased minimum](row-height-decreased.pptx)

| Original: minimum 70 pt, actual 70 pt | Increased: minimum 100 pt, actual 100 pt | Decreased: minimum 20 pt, actual 55.2 pt |
| --- | --- | --- |
| ![Original table with a 70-point first row.](row-height-before.png) | ![Table after increasing the first row minimum to 100 points.](row-height-increased.png) | ![Table after decreasing the first row minimum to 20 points; wrapped text keeps the row taller than the minimum.](row-height-decreased.png) |

## **ตั้งค่าแถวแรกเป็นหัวเรื่อง**

ใช้คุณสมบัติ [first_row](https://reference.aspose.com/slides/python-net/aspose.slides/table/first_row/) เพื่อทำเครื่องหมายแถวแรกให้เป็นรูปแบบหัวเรื่อง รูปลักษณ์ของมันขึ้นอยู่กับสไตล์ตารางที่นำไปใช้กับตาราง

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. เข้าถึงสไลด์แรก
3. เข้าถึงตารางที่เก็บเป็นรูปร่างแรกบนสไลด์
4. เปิดใช้งานการจัดรูปแบบหัวเรื่องสำหรับแถวแรก
5. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างต้องการไฟล์ `table.pptx` ที่มีตารางเป็นรูปร่างแรกบนสไลด์แรก จะเปิดใช้งานการจัดรูปแบบหัวเรื่องสำหรับแถวแรกและบันทึกเป็น `First_row_header.pptx`

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]
    table.first_row = True

    presentation.save("First_row_header.pptx", slides.export.SaveFormat.PPTX)
```

## **คัดลอกแถวหรือคอลัมน์ของตาราง**

คัดลอกแถวหรือคอลัมน์เพื่อใช้เนื้อหาและการจัดรูปแบบซ้ำ คุณสามารถเพิ่มสำเนาที่ส่วนท้ายของตารางหรือแทรกไว้ที่ตำแหน่งเฉพาะ

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. เข้าถึงสไลด์แรก
3. กำหนดความกว้างของคอลัมน์และความสูงของแถว
4. เพิ่มตารางด้วยเมธอด [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/)
5. คัดลอกแถวที่ต้องการ
6. คัดลอกคอลัมน์ที่ต้องการ
7. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างต้องการไฟล์ `Test.pptx` ที่มีอย่างน้อยหนึ่งสไลด์ จะสร้างตารางที่มีสามคอลัมน์และห้าแถวโดยระบุขนาดเป็นจุด จะเพิ่มสำเนาของแถวและคอลัมน์แรก, จากนั้นแทรกสำเนาของแถวและคอลัมน์ที่สองที่ตำแหน่งดัชนี 3 (ตำแหน่งที่สี่) ตารางที่ได้มีเจ็ดแถวและห้าคอลัมน์ อาร์กิวเมนต์ `False` ปิดการคัดลอกเข้ากับแถวหรือคอลัมน์ที่ผสานอยู่; ตารางนี้ไม่มีเซลล์ผสาน

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[0][0].text_frame.text = "Row 1 Cell 1"
    table.rows[0][1].text_frame.text = "Row 1 Cell 2"
    table.rows.add_clone(table.rows[0], False)

    table.rows[1][0].text_frame.text = "Row 2 Cell 1"
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"
    table.rows.insert_clone(3, table.rows[1], False)

    table.columns.add_clone(table.columns[0], False)
    table.columns.insert_clone(3, table.columns[1], False)

    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ลบแถวหรือคอลัมน์จากตาราง**

ลบแถวหรือคอลัมน์ที่ไม่ต้องการอีกต่อไปในตาราง การลบรายการจะทำให้ดัชนีของแถวหรือคอลัมน์ที่ตามมาถูกเปลี่ยน

1. สร้างงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. เข้าถึงสไลด์แรก
3. กำหนดความกว้างของคอลัมน์และความสูงของแถว
4. เพิ่มตารางด้วยเมธอด [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/)
5. ลบแถวที่สองและคอลัมน์ที่สอง
6. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างนี้สร้างตารางสามโดยสามและลบแถวและคอลัมน์ที่ดัชนี 1 ทำให้เหลือตารางสองโดยสองในไฟล์ `TestTable_out.pptx` ขนาดเป็นจุด อาร์กิวเมนต์ `False` ปิดการลบแถวหรือคอลัมน์ที่ผสานอยู่; ตารางนี้ไม่มีเซลล์ผสาน

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.shapes.add_table(100, 100, column_widths, row_heights)

    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)

    presentation.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าการจัดรูปแบบข้อความที่ระดับแถวของตาราง**

ใช้การจัดรูปแบบข้อความกับแถวทั้งหมดเพื่อให้เซลล์มีความสอดคล้องกัน คุณสามารถตั้งคุณสมบัติฟอนต์, การจัดรูปแบบย่อหน้า, และทิศทางข้อความโดยไม่ต้องจัดรูปแบบแต่ละเซลล์แยกกัน

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. เข้าถึงตารางบนสไลด์แรก
3. ตั้งค่า [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) สำหรับแถวแรก
4. ตั้งค่า [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) และ [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) สำหรับแถวแรก
5. ตั้งค่า [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) สำหรับแถวที่สอง
6. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างต้องการไฟล์ `table.pptx` ที่มีตารางเป็นรูปร่างแรกบนสไลด์แรกและมีอย่างน้อยสองแถว จะใส่ข้อความขนาด 25 จุด, จัดแนวขวา, และระยะขอบย่อหน้าขวา 20 จุดให้กับแถวแรก, จากนั้นตั้งค่าข้อความแนวตั้งในแถวที่สอง

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)

    presentation.save("row_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าการจัดรูปแบบข้อความที่ระดับคอลัมน์ของตาราง**

ใช้การจัดรูปแบบข้อความกับคอลัมน์ทั้งหมดเพื่อให้เซลล์มีความสอดคล้องกัน คุณสามารถตั้งคุณสมบัติฟอนต์, การจัดรูปแบบย่อหน้า, และทิศทางข้อความโดยไม่ต้องจัดรูปแบบแต่ละเซลล์แยกกัน

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. เข้าถึงตารางบนสไลด์แรก
3. ตั้งค่า [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) สำหรับคอลัมน์แรก
4. ตั้งค่า [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) และ [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) สำหรับคอลัมน์แรก
5. ตั้งค่า [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) สำหรับคอลัมน์ที่สอง
6. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างต้องการไฟล์ `table.pptx` ที่มีตารางเป็นรูปร่างแรกบนสไลด์แรกและมีอย่างน้อยสองคอลัมน์ จะใส่ข้อความขนาด 25 จุด, จัดแนวขวา, และระยะขอบย่อหน้าขวา 20 จุดให้กับคอลัมน์แรก, จากนั้นตั้งค่าข้อความแนวตั้งในคอลัมน์ที่สอง

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    presentation.save("column_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **รับคุณสมบัติสไตล์ของตาราง**

ใช้คุณสมบัติ [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) เพื่อดึงค่า preset ที่ใช้กับตารางและนำกลับไปใช้กับตารางอื่น ค่านี้บ่งบอก preset แทนการแทนที่การจัดรูปแบบของเซลล์แต่ละเซลล์

ตัวอย่างสร้างตาราง, ใช้ [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) แล้วอ่านค่า preset กลับมา จะพิมพ์ `True` เมื่อ preset ที่อ่านได้ตรงกับ preset ที่กำหนดและบันทึกตารางเป็น `table.pptx`

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(style_preset == slides.TableStylePreset.DARK_STYLE1)

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้ธีม/สไตล์ของ PowerPoint กับตารางที่สร้างแล้วได้หรือไม่?**

ได้ ตารางจะสืบทอดธีมของสไลด์/เลเอาต์/มาสเตอร์, และคุณยังสามารถกำหนดสีเติม, เส้นขอบ, และสีข้อความเพิ่มเติมเหนือธีมนั้นได้

**ฉันสามารถจัดเรียงแถวของตารางแบบ Excel ได้หรือไม่?**

ไม่ได้ ตารางของ Aspose.Slides ไม่มีฟังก์ชันจัดเรียงหรือฟิลเตอร์ในตัว ให้จัดเรียงข้อมูลในหน่วยความจำก่อนแล้วจึงเติมแถวตารางตามลำดับนั้นใหม่

**ฉันสามารถทำคอลัมน์แบบลายเส้น (banded) พร้อมสีที่กำหนดเองสำหรับเซลล์เฉพาะได้หรือไม่?**

ได้ เปิดใช้งานคอลัมน์แบบลายเส้น แล้วค่อยกำหนดรูปแบบท้องถิ่นให้กับเซลล์ที่ต้องการ; การจัดรูปแบบระดับเซลล์จะมีลำดับความสำคัญเหนือสไตล์ของตาราง