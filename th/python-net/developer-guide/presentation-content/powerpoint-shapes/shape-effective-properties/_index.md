---
title: รับคุณสมบัติรูปแบบที่มีประสิทธิภาพจากงานนำเสนอใน Python
linktitle: คุณสมบัติที่มีประสิทธิภาพ
type: docs
weight: 50
url: /th/python-net/shape-effective-properties/
keywords:
- คุณสมบัติรูปแบบ
- คุณสมบัติกล้อง
- ระบบแสง
- รูปร่างบีเวล
- กรอบข้อความ
- สไตล์ข้อความ
- ความสูงฟอนต์
- รูปแบบการเติม
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีใช้ Aspose.Slides สำหรับ Python ผ่าน .NET เพื่อแยกแยะการจัดรูปแบบรูปแบบในงานนำเสนอ PowerPoint ที่เป็น local, inherited, และ effective"
---
## **ทำความเข้าใจ Local, Inherited, และ Effective Properties**

PowerPoint formatting สามารถมาจากหลายแหล่ง ค่าที่จัดเก็บโดยตรงบนวัตถุเรียกว่า **local value** หากค่านั้นไม่ได้ตั้งค่า PowerPoint จะตรวจสอบแหล่งจัดรูปแบบแม่ เช่น ค่าปริยายของย่อหน้า สไตล์ข้อความ รูปแบบเลย์เอาต์หรือมาสเตอร์สไลด์ ธีม หรือค่าปริยายระดับการนำเสนอ ค่าต่างๆเหล่านี้คือ **inherited values** ค่าที่เหลือหลังจากลำดับชั้นทั้งหมดได้รับการแก้ไขคือ **effective value** ซึ่งใช้สำหรับการแสดงผลวัตถุ

ตัวอย่างเช่น ส่วนของข้อความอาจไม่ได้กำหนดความสูงฟอนต์ของตัวเอง ความสูง **local** ของมันคือ [font_height](https://reference.aspose.com/slides/th/python-net/aspose.slides/ibaseportionformat/font_height/) จะเป็น `float("nan")` ซึ่งหมายถึง “ไม่ได้ตั้งค่าที่นี่”. ส่วนนั้นสามารถสืบทอดความสูงจากย่อหน้า สไตล์ข้อความปริยายของการนำเสนอ หรือแหล่งอื่นที่ใช้ได้ การเรียกใช้ [get_effective](https://reference.aspose.com/slides/th/python-net/aspose.slides/iportionformat/get_effective/) บนรูปแบบส่วนจะคืนค่าความสูงที่แก้ไขขั้นสุดท้าย

ใช้ข้อมูลการจัดรูปแบบสองประเภทสำหรับวัตถุประสงค์ที่ต่างกัน:

- อ่านหรือเปลี่ยนวัตถุรูปแบบ local เช่น [IPortionFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/iportionformat/), เมื่อคุณต้องการควบคุมว่าค่าถูกกำหนดที่ตำแหน่งใด
- อ่านวัตถุข้อมูล effective เช่น [IPortionFormatEffectiveData](https://reference.aspose.com/slides/th/python-net/aspose.slides/iportionformateffectivedata/), เมื่อคุณต้องการผลลัพธ์ที่แสดงขั้นสุดท้าย ข้อมูล effective สามารถอ่านได้เท่านั้น

## **เปรียบเทียบ Local, Inherited, และ Effective Values**

ตัวอย่างเต็มต่อไปนี้สร้างรูปแบบและกำหนดความสูงฟอนต์ในระดับการนำเสนอ ย่อหน้า และส่วนของข้อความ แต่ละขั้นตอนจะพิมพ์ค่าที่กำหนดในระดับนั้นและค่าที่ได้จาก **effective** สำหรับส่วนของข้อความเดียวกัน นอกจากนี้ยังแสดงเหตุผลที่ต้องอ่านข้อมูล **effective** อีกครั้งหลังจากการเปลี่ยนแปลงการจัดรูปแบบ

```python
import math

import aspose.slides as slides


def format_local_value(value):
    return "<not set>" if math.isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.default_text_style.get_level(0).default_portion_format.font_height
    paragraph_value = paragraph.paragraph_format.default_portion_format.font_height
    local_value = portion.portion_format.font_height

    # อ่านข้อมูล effective หลังจากการเปลี่ยนแปลงก่อนหน้า.
    effective_value = portion.portion_format.get_effective().font_height

    print(caption)
    print("  Presentation default: " + format_local_value(presentation_value))
    print("  Paragraph default:    " + format_local_value(paragraph_value))
    print("  Portion local:        " + format_local_value(local_value))
    print("  Portion effective:    " + str(effective_value))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 80, False)
    text_frame = shape.add_text_frame("Effective formatting")
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    # กำหนดค่าที่สืบทอดในสองระดับที่แตกต่างกัน.
    presentation.default_text_style.get_level(0).default_portion_format.font_height = 20
    paragraph.paragraph_format.default_portion_format.font_height = 28

    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # ค่าท้องถิ่นใน portion จะทับค่าที่สืบทอดทั้งสองค่า.
    portion.portion_format.font_height = 36
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # การเปลี่ยนค่าที่สืบทอดจะไม่ทับค่าท้องถิ่นที่มีอยู่แล้ว.
    paragraph.paragraph_format.default_portion_format.font_height = 30
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # ลบค่าท้องถิ่นออก ตอนนี้ portion จะสืบทอดจากย่อหน้าอีกครั้ง.
    portion.portion_format.font_height = float("nan")
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # ลบค่าของย่อหน้าออก ตอนนี้ค่าปริยายของการนำเสนอจะให้ผลลัพธ์.
    paragraph.paragraph_format.default_portion_format.font_height = float("nan")
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", slides.export.SaveFormat.PPTX)
```

ลำดับความสำคัญในตัวอย่างนี้คือการจัดรูปแบบ **local** ของส่วน, ตามด้วยการจัดรูปแบบย่อหน้า, แล้วจึงค่าสำหรับการนำเสนอโดยปริยาย วัตถุอื่นอาจมีโซ่การสืบทอดที่แตกต่างกัน แต่หลักการเดียวกัน: ค่าที่ระบุอย่างเฉพาะเจาะจงจะชนะ และ [get_effective](https://reference.aspose.com/slides/th/python-net/aspose.slides/iportionformat/get_effective/) จะคืนค่าผลลัพธ์ขั้นสุดท้าย

## **รับ Effective Text Properties**

การจัดรูปแบบข้อความถูกแยกออกเป็นหลายวัตถุ:

- [ITextFrameFormat.get_effective()](https://reference.aspose.com/slides/th/python-net/aspose.slides/itextframeformat/get_effective/) แก้ไขคุณสมบัติของเฟรมข้อความ เช่น ระยะขอบ, การยึด, autofit, และทิศทางข้อความแนวตั้ง
- [ITextStyle.get_effective()](https://reference.aspose.com/slides/th/python-net/aspose.slides/itextstyle/get_effective/) แก้ไขการจัดรูปแบบย่อหน้าสำหรับแต่ละระดับสไตล์ข้อความ
- [IParagraphFormat.get_effective()](https://reference.aspose.com/slides/th/python-net/aspose.slides/iparagraphformat/get_effective/) แก้ไขคุณสมบัติของย่อหน้า เช่น การจัดแนว, การเยื้อง, และหัวข้อจุด
- [IPortionFormat.get_effective()](https://reference.aspose.com/slides/th/python-net/aspose.slides/iportionformat/get_effective/) แก้ไขคุณสมบัติตัวอักษร เช่น ความสูงฟอนต์, ชนิดฟอนต์, สี, ตัวหนา, และตัวเอียง

สำหรับตัวอย่างต่อไป, ไฟล์ `text-formatting.pptx` ต้องมีสไลด์อย่างน้อยหนึ่งสไลด์และมี [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) อย่างน้อยหนึ่งรูปที่มีเฟรมข้อความไม่ว่างเปล่า AutoShape สามารถอยู่ในตำแหน่งใดก็ได้ในคอลเลกชันของรูป; โค้ดจะค้นหาวัตถุที่เหมาะสมและตรวจสอบก่อนใช้งาน

```python
import aspose.slides as slides


def has_non_empty_text(shape):
    if not isinstance(shape, slides.AutoShape):
        return False
    if shape.text_frame is None:
        return False
    if shape.text_frame.paragraphs.count == 0:
        return False
    return shape.text_frame.paragraphs[0].portions.count > 0


with slides.Presentation("text-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    shape = None
    for candidate in presentation.slides[0].shapes:
        if has_non_empty_text(candidate):
            shape = candidate
            break

    if shape is None:
        raise RuntimeError("The first slide must contain an AutoShape with non-empty text.")

    text_frame = shape.text_frame
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    text_frame_effective = text_frame.text_frame_format.get_effective()
    paragraph_effective = paragraph.paragraph_format.get_effective()
    portion_effective = portion.portion_format.get_effective()

    print("Text frame margins:")
    print("  Left: " + str(text_frame_effective.margin_left))
    print("  Top: " + str(text_frame_effective.margin_top))
    print("  Right: " + str(text_frame_effective.margin_right))
    print("  Bottom: " + str(text_frame_effective.margin_bottom))
    print("Paragraph alignment: " + str(paragraph_effective.alignment))
    print("Font height: " + str(portion_effective.font_height))
    print("Bold: " + str(portion_effective.font_bold))

    effective_text_style = text_frame.text_frame_format.text_style.get_effective()
    for level in range(9):
        level_effective = effective_text_style.get_level(level)
        print("Level " + str(level) + " indent: " + str(level_effective.indent))
```

## **รับ Effective 3D Properties**

[IThreeDFormat.get_effective()](https://reference.aspose.com/slides/th/python-net/aspose.slides/ithreedformat/get_effective/) คืนค่าอ็อบเจ็กต์ [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/python-net/aspose.slides/ithreedformateffectivedata/) ที่รวมการตั้งค่า 3D ทั้งหมดที่ได้แก้ไขแล้ว คุณสมบัติ [camera](https://reference.aspose.com/slides/th/python-net/aspose.slides/ithreedformateffectivedata/camera/), [light_rig](https://reference.aspose.com/slides/th/python-net/aspose.slides/ithreedformateffectivedata/light_rig/), [bevel_top](https://reference.aspose.com/slides/th/python-net/aspose.slides/ithreedformateffectivedata/bevel_top/), และ [bevel_bottom](https://reference.aspose.com/slides/th/python-net/aspose.slides/ithreedformateffectivedata/bevel_bottom/) เปิดเผยข้อมูล effective ที่สอดคล้อง การอ่านการตั้งค่าเหล่านี้ร่วมกันทำให้เข้าใจลักษณะ 3D สุดท้ายของรูปได้ง่ายขึ้น

สำหรับตัวอย่างนี้, ไฟล์ `shape-3d.pptx` ต้องมีรูปอย่างน้อยหนึ่งรูปในสไลด์แรก ให้กำหนดค่ากล้อง 3D, แสง, หรือ bevel ให้กับรูปนั้นหากคุณต้องการให้ผลลัพธ์มีค่าที่แตกต่างจากค่าปริยาย

```python
import aspose.slides as slides


with slides.Presentation("shape-3d.pptx") as presentation:
    if presentation.slides.count == 0 or presentation.slides[0].shapes.count == 0:
        raise RuntimeError("The first slide must contain a shape.")

    shape = presentation.slides[0].shapes[0]
    three_d_effective = shape.three_d_format.get_effective()

    print("Camera:")
    print("  Type: " + str(three_d_effective.camera.camera_type))
    print("  Field of view: " + str(three_d_effective.camera.field_of_view_angle))
    print("  Zoom: " + str(three_d_effective.camera.zoom))

    print("Light rig:")
    print("  Type: " + str(three_d_effective.light_rig.light_type))
    print("  Direction: " + str(three_d_effective.light_rig.direction))

    print("Top bevel:")
    print("  Type: " + str(three_d_effective.bevel_top.bevel_type))
    print("  Width: " + str(three_d_effective.bevel_top.width))
    print("  Height: " + str(three_d_effective.bevel_top.height))
```

## **รับ Effective Table Formatting**

การจัดรูปแบบตารางสามารถมาจากสไตล์ของตารางและจากการจัดรูปแบบที่ใช้กับตารางทั้งหมด, คอลัมน์, แถว, หรือเซลล์เดี่ยว สำหรับความขัดแย้งระหว่างการเติมสีที่กำหนดโดยชัดเจน ลำดับความสำคัญคือเซลล์, แถว, คอลัมน์, และตารางทั้งหมด การจัดรูปแบบ **effective** ของเซลล์คือรูปแบบสุดท้ายที่ใช้วาดเซลล์นั้น

สำหรับตัวอย่างนี้, ไฟล์ `table-formatting.pptx` ต้องมีตารางอย่างน้อยหนึ่งตารางในสไลด์แรก ตารางต้องมีอย่างน้อยหนึ่งแถวและหนึ่งคอลัมน์ โค้ดจะค้นหา [Table](https://reference.aspose.com/slides/th/python-net/aspose.slides/table/) แทนที่จะสมมติว่า `shapes[0]` เป็นตาราง

```python
import aspose.slides as slides


with slides.Presentation("table-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    table = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is None:
        raise RuntimeError("The first slide must contain a table.")

    if table.rows.count == 0 or table.columns.count == 0:
        raise RuntimeError("The table must contain at least one cell.")

    table_effective = table.table_format.get_effective()
    row_effective = table.rows[0].row_format.get_effective()
    column_effective = table.columns[0].column_format.get_effective()
    cell_effective = table.rows[0][0].cell_format.get_effective()

    print("Table fill: " + str(table_effective.fill_format.fill_type))
    print("Row fill: " + str(row_effective.fill_format.fill_type))
    print("Column fill: " + str(column_effective.fill_format.fill_type))
    print("Final cell fill: " + str(cell_effective.fill_format.fill_type))
```

หากคุณต้องการสีแทนที่จะเป็นประเภทการเติมเพียงอย่างเดียว ให้ตรวจสอบ **effective** [fill_type](https://reference.aspose.com/slides/th/python-net/aspose.slides/ifillformateffectivedata/fill_type/) ก่อน แล้วอ่านคุณสมบัติที่ใช้กับประเภทนั้น ตัวอย่างเช่น [solid_fill_color](https://reference.aspose.com/slides/th/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) สำหรับการเติมแบบสีเดียว

## **อ่าน Effective Data อีกครั้งหลังการเปลี่ยนแปลง**

Effective data บรรยายลำดับชั้นการจัดรูปแบบในขณะที่มันได้รับการแก้ไข เรียก `get_effective` อีกครั้งหลังจากเปลี่ยนแปลงสิ่งใดที่สามารถเข้าร่วมในลำดับชั้นนั้น, รวมถึง:

- การจัดรูปแบบ **local** ของวัตถุ;
- ค่าปริยายของย่อหน้า หรือเฟรมข้อความ;
- สไตล์ตาราง, ตาราง, คอลัมน์, แถว, หรือรูปแบบเซลล์;
- การจัดรูปแบบเลย์เอาต์หรือมาสเตอร์สไลด์;
- ข้อมูลธีมหรือค่าปริยายระดับการนำเสนอ;
- เลย์เอาต์หรือมาสเตอร์ที่กำหนดให้กับสไลด์

ไม่ควรเก็บอ็อบเจ็กต์ effective data เป็นสแนปช็อตถาวร Aspose.Slides อาจแคชบางข้อมูล effective ไว้ภายใน และการเรียก `get_effective` ครั้งถัดไปสามารถรีเฟรชข้อมูลนั้นได้ หากต้องการเปรียบเทียบค่าก่อนและหลังการเปลี่ยนแปลง ให้นำค่าที่เป็นสเกลาร์ที่ต้องการ เช่น ความสูงฟอนต์, สี, การจัดแนว, หรือความกว้าง bevel ไปเก็บในตัวแปรของคุณเองก่อนทำการเปลี่ยนแปลง

เพื่อเปลี่ยนค่า, ปรับอ็อบเจ็กต์รูปแบบ **local** ที่เหมาะสมแล้วเรียก `get_effective` เพื่อตรวจสอบผลลัพธ์ อ็อบเจ็กต์ effective data เองเป็นแบบอ่านอย่างเดียว

## **FAQ**

**How can I tell which level supplied an effective value?**

Effective data มีค่าขั้นสุดท้าย, ไม่ได้บอกแหล่งที่มาของมัน ตรวจสอบวัตถุ **local** ที่เกี่ยวข้องจากระดับที่เฉพาะเจาะจงที่สุดไปด้านนอก สำหรับข้อความอาจรวมถึง portion, paragraph, text frame, layout, master, theme, และค่าปริยายของการนำเสนอ ค่าที่ไม่ได้กำหนดเช่น `float("nan")` หรือ `None` หมายความว่าการค้นหายังคงดำเนินต่อไปในระดับอื่น

**What happens when no level defines a property?**

Aspose.Slides จะใช้ค่าปริยายของ PowerPoint หรือของไลบรารีที่เกี่ยวข้อง ค่าที่ได้แก้ไขแล้วจะปรากฏใน effective data แม้ว่าวัตถุ **local** จะไม่ได้กำหนดค่าอย่างชัดเจน

**Why does an effective value sometimes equal the local value?**

ค่าที่ **local** ชนะการคำนวณการสืบทอด นี่เป็นผลที่คาดหวังเมื่อคุณตั้งค่าคุณสมบัตินั้นโดยตรงบนวัตถุและไม่มีกฎที่เฉพาะเจาะจงกว่าเข้ามาแทนที่

**When should I use local data instead of effective data?**

ใช้ข้อมูล **local** เพื่อสำรวจหรือแก้ไขระดับการจัดรูปแบบที่เฉพาะเจาะจง ใช้ข้อมูล **effective** เมื่อคุณต้องการผลลัพธ์สุดท้ายหลังจากการสืบทอด, กฎธีม, และสไตล์ที่เกี่ยวข้องทั้งหมดได้รับการแก้ไข ตัวอย่างการเปรียบเทียบทั้งหมด ([compare-local-inherited-and-effective-values](#compare-local-inherited-and-effective-values)) แสดงการใช้ทั้งสองแบบใน workflow เดียวกัน.