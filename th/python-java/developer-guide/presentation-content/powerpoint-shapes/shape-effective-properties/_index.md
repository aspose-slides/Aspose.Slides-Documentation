---
title: รับคุณสมบัติรูปทรงแบบ Effective จากการนำเสนอใน Python ผ่าน Java
linktitle: คุณสมบัติแบบ Effective
type: docs
weight: 50
url: /th/python-java/shape-effective-properties/
keywords:
- คุณสมบัติรูปทรง
- คุณสมบัติกล้อง
- ระบบแสง
- รูปทรง Bevel
- กรอบข้อความ
- สไตล์ข้อความ
- ความสูงฟอนต์
- รูปแบบการเติม
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีใช้ Aspose.Slides สำหรับ Python ผ่าน Java เพื่อแยกแยะการจัดรูปแบบรูปทรงแบบ local, inherited และ effective ในการนำเสนอ PowerPoint."
---
## **ทำความเข้าใจคุณสมบัติ Local, Inherited และ Effective**

การจัดรูปแบบ PowerPoint สามารถมาจากหลายแหล่ง ค่า ที่เก็บโดยตรงบนวัตถุคือ **local value** หากค่า นั้นไม่ได้ตั้งค่า PowerPoint จะตรวจสอบแหล่งกำหนดรูปแบบแม่ เช่น ค่าเริ่มต้นของย่อหน้า, สไตล์ข้อความ, เค้าโครงหรือสไลด์มาสเตอร์, ธีม, หรือค่าเริ่มต้นระดับการนำเสนอ ค่าที่ได้จะเป็น **inherited values** ค่า ที่เหลือหลังจากการแก้ไขลำดับขั้นทั้งหมดคือ **effective value** — ค่าที่ใช้ในการเรนเดอร์วัตถุ

เช่น ส่วนของข้อความอาจไม่ได้กำหนดความสูงของฟอนต์ของตนเอง ค่ local [getFontHeight](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#getFontHeight) จะเป็น `float("nan")` ซึ่งหมายถึง “ไม่ได้ตั้งค่าที่นี่” ส่วนนั้นสามารถสืบทอดความสูงจากย่อหน้า, สไตล์ข้อความเริ่มต้นของการนำเสนอ, หรือแหล่งที่ใช้ได้อื่น ๆ การเรียก [getEffective](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/#getEffective) บนรูปแบบส่วนจะคืนค่าความสูงที่แก้ไขเสร็จแล้ว

ใช้ข้อมูลการจัดรูปแบบสองประเภทสำหรับวัตถุประสงค์ที่แตกต่างกัน:

- อ่านหรือเปลี่ยนวัตถุรูปแบบ local เช่น [PortionFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/), เมื่อคุณต้องการควบคุมว่าค่าถูกกำหนดที่ใด
- อ่านวัตถุข้อมูล effective เช่น `PortionFormatEffectiveData`, เมื่อคุณต้องการผลลัพธ์ที่เรนเดอร์สุดท้าย ข้อมูล effective เป็นแบบอ่านอย่างเดียว

## **เปรียบเทียบค่า Local, Inherited และ Effective**

ตัวอย่างเต็มต่อไปนี้สร้างรูปทรงและกำหนดความสูงของฟอนต์ที่ระดับการนำเสนอ, ย่อหน้า, และส่วนข้อความ แต่ละขั้นจะพิมพ์ค่าที่กำหนดที่ระดับนั้นและค่า effective ที่ได้สำหรับส่วนข้อความเดียวกัน นอกจากนี้ยังแสดงเหตุผลที่ต้องอ่านข้อมูล effective อีกครั้งหลังการเปลี่ยนแปลงการจัดรูปแบบ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from math import isnan
from asposeslides.api import Presentation, SaveFormat, ShapeType


def format_local_value(value):
    return "<not set>" if isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight()
    paragraph_value = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight()
    local_value = portion.getPortionFormat().getFontHeight()

    # อ่านข้อมูล effective หลังจากการเปลี่ยนแปลงก่อนหน้า.
    effective_value = portion.getPortionFormat().getEffective().getFontHeight()

    print(caption)
    print(f"  Presentation default: {format_local_value(presentation_value)}")
    print(f"  Paragraph default:    {format_local_value(paragraph_value)}")
    print(f"  Portion local:        {format_local_value(local_value)}")
    print(f"  Portion effective:    {effective_value}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, False)
    text_frame = shape.addTextFrame("Effective formatting")
    paragraph = text_frame.getParagraphs().get_Item(0)
    portion = paragraph.getPortions().get_Item(0)

    # กำหนดค่าที่สืบทอดที่สองระดับต่างกัน.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # ค่าที่ local บน portion จะทับค่าที่สืบทอดทั้งสองค่า.
    portion.getPortionFormat().setFontHeight(36)
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # การเปลี่ยนค่าที่สืบทอดจะไม่ทับค่าที่ local อยู่แล้ว.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30)
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # ล้างค่าที่ local. Portion จะสืบทอดจากย่อหน้าอีกครั้ง.
    portion.getPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # ล้างค่าที่ย่อหน้า. ค่าเริ่มต้นของการนำเสนอจะให้ผลลัพธ์นี้.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ลำดับความสำคัญในตัวอย่างนี้คือการจัดรูปแบบ local ของส่วนข้อความ, จากนั้นการจัดรูปแบบของย่อหน้า, แล้วตามด้วยค่าเริ่มต้นของการนำเสนอ วัตถุอื่น ๆ อาจมีสายการสืบทอดที่แตกต่างกัน แต่หลักการเหมือนกัน: ค่าที่ระบุอย่างชัดเจนและเจาะจงมากกว่า จะเป็นผู้ชนะ, และ [getEffective](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/#getEffective) จะคืนผลลัพธ์สุดท้าย

## **รับคุณสมบัติข้อความแบบ Effective**

การจัดรูปแบบข้อความถูกแบ่งออกเป็นหลายวัตถุ:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/#getEffective) แก้ไขคุณสมบัติของเฟรมข้อความเช่น ขอบ, การยึด, autofit, และทิศทางข้อความแนวตั้ง
- [TextStyle.getEffective](https://reference.aspose.com/slides/th/python-java/aspose.slides/textstyle/#getEffective) แก้ไขการจัดรูปแบบย่อหน้าสำหรับแต่ละระดับสไตล์ข้อความ
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#getEffective) แก้ไขคุณสมบัติย่อหน้าเช่น การจัดแนว, การเยื้อง, และเครื่องหมายหัวข้อ
- [PortionFormat.getEffective](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/#getEffective) แก้ไขคุณสมบัติอักขระเช่น ความสูงของฟอนต์, ชนิดตัวอักษร, สี, ตัวหนา, และตัวเอียง

สำหรับตัวอย่างต่อไป, `text-formatting.pptx` ต้องมีอย่างน้อยหนึ่งสไลด์และหนึ่ง [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) ที่มีกรอบข้อความไม่ว่างเปล่า AutoShape สามารถปรากฏที่ตำแหน่งใดก็ได้ในคอลเลกชันรูปทรง; โค้ดจะค้นหาวัตถุที่เหมาะสมและตรวจสอบความถูกต้องก่อนใช้งาน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation


def has_non_empty_text(shape):
    text_frame = shape.getTextFrame()
    if text_frame is None or text_frame.getParagraphs().getCount() == 0:
        return False
    return text_frame.getParagraphs().get_Item(0).getPortions().getCount() > 0


def find_auto_shape_with_text(slide):
    for candidate in slide.getShapes():
        if isinstance(candidate, AutoShape) and has_non_empty_text(candidate):
            return candidate
    return None


presentation = Presentation("text-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        shape = find_auto_shape_with_text(presentation.getSlides().get_Item(0))
        if shape is None:
            print("The first slide must contain an AutoShape with non-empty text.")
        else:
            text_frame = shape.getTextFrame()
            paragraph = text_frame.getParagraphs().get_Item(0)
            portion = paragraph.getPortions().get_Item(0)

            text_frame_effective = text_frame.getTextFrameFormat().getEffective()
            paragraph_effective = paragraph.getParagraphFormat().getEffective()
            portion_effective = portion.getPortionFormat().getEffective()

            print("Text frame margins:")
            print(f"  Left: {text_frame_effective.getMarginLeft()}")
            print(f"  Top: {text_frame_effective.getMarginTop()}")
            print(f"  Right: {text_frame_effective.getMarginRight()}")
            print(f"  Bottom: {text_frame_effective.getMarginBottom()}")
            print(f"Paragraph alignment: {paragraph_effective.getAlignment()}")
            print(f"Font height: {portion_effective.getFontHeight()}")
            print(f"Bold: {portion_effective.getFontBold()}")

            effective_text_style = text_frame.getTextFrameFormat().getTextStyle().getEffective()
            for level in range(9):
                level_effective = effective_text_style.getLevel(level)
                print(f"Level {level} indent: {level_effective.getIndent()}")
finally:
    presentation.dispose()
```

## **รับคุณสมบัติ 3D แบบ Effective**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/th/python-java/aspose.slides/threedformat/#getEffective) คืนวัตถุ `ThreeDFormatEffectiveData` หนึ่งตัวที่กลุ่มการตั้งค่า 3D ที่แก้ไขแล้ว เมธอด `getCamera`, `getLightRig`, `getBevelTop`, และ `getBevelBottom` จะเปิดเผยข้อมูล effective ที่สอดคล้องกัน การอ่านการตั้งค่าเหล่านี้พร้อมกันทำให้เข้าใจลักษณะ 3D สุดท้ายของรูปทรงได้ง่ายขึ้น

สำหรับตัวอย่างนี้, `shape-3d.pptx` ต้องมีอย่างน้อยหนึ่งรูปทรงบนสไลด์แรกของมัน ให้กำหนดกล้อง 3D, แสง, หรือการตั้งค่า bevel ให้กับรูปทรงนั้นหากต้องการให้ผลลัพธ์มีค่าที่ต่างจากค่าเริ่มต้น

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("shape-3d.pptx")
try:
    if presentation.getSlides().size() == 0 or presentation.getSlides().get_Item(0).getShapes().size() == 0:
        print("The first slide must contain a shape.")
    else:
        shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        three_d_effective = shape.getThreeDFormat().getEffective()

        print("Camera:")
        print(f"  Type: {three_d_effective.getCamera().getCameraType()}")
        print(f"  Field of view: {three_d_effective.getCamera().getFieldOfViewAngle()}")
        print(f"  Zoom: {three_d_effective.getCamera().getZoom()}")

        print("Light rig:")
        print(f"  Type: {three_d_effective.getLightRig().getLightType()}")
        print(f"  Direction: {three_d_effective.getLightRig().getDirection()}")

        print("Top bevel:")
        print(f"  Type: {three_d_effective.getBevelTop().getBevelType()}")
        print(f"  Width: {three_d_effective.getBevelTop().getWidth()}")
        print(f"  Height: {three_d_effective.getBevelTop().getHeight()}")
finally:
    presentation.dispose()
```

## **รับการจัดรูปแบบตารางแบบ Effective**

การจัดรูปแบบตารางอาจมาจากสไตล์ของตารางและจากรูปแบบที่ใช้กับตารางทั้งหมด, คอลัมน์, แถว, หรือเซลล์แต่ละเซลล์ สำหรับความขัดแย้งระหว่างการเติมสีที่กำหนดอย่างชัดเจน ลำดับความสำคัญคือ เซลล์, แถว, คอลัมน์, แล้วจึงตารางทั้งหมด รูปแบบ effective ของเซลล์คือรูปแบบสุดท้ายที่ใช้วาดเซลล์นั้น

สำหรับตัวอย่างนี้, `table-formatting.pptx` ต้องมีอย่างน้อยหนึ่งตารางบนสไลด์แรกของมัน ตารางต้องมีอย่างน้อยหนึ่งแถวและหนึ่งคอลัมน์ โค้ดจะค้นหา [Table](https://reference.aspose.com/slides/th/python-java/aspose.slides/table/) แทนการสมมติว่า `getShapes().get_Item(0)` คือ ตาราง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table


def find_table(slide):
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            return shape
    return None


presentation = Presentation("table-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        table = find_table(presentation.getSlides().get_Item(0))
        if table is None:
            print("The first slide must contain a table.")
        elif table.getRows().size() == 0 or table.getColumns().size() == 0:
            print("The table must contain at least one cell.")
        else:
            table_effective = table.getTableFormat().getEffective()
            row_effective = table.getRows().get_Item(0).getRowFormat().getEffective()
            column_effective = table.getColumns().get_Item(0).getColumnFormat().getEffective()
            cell_effective = table.get_Item(0, 0).getCellFormat().getEffective()

            print(f"Table fill: {table_effective.getFillFormat().getFillType()}")
            print(f"Row fill: {row_effective.getFillFormat().getFillType()}")
            print(f"Column fill: {column_effective.getFillFormat().getFillType()}")
            print(f"Final cell fill: {cell_effective.getFillFormat().getFillType()}")
finally:
    presentation.dispose()
```

หากคุณต้องการสีแทนประเภทการเติมเพียงอย่างเดียว ให้ตรวจสอบ `getFillType` ของ effective ก่อน, แล้วอ่านเมธอดที่สอดคล้องกับประเภทนั้น—for example, `getSolidFillColor` สำหรับการเติมแบบสีทึบ

## **อ่านข้อมูล Effective ใหม่หลังการเปลี่ยนแปลง**

ข้อมูล effective อธิบายลำดับขั้นของการจัดรูปแบบในขณะที่ถูกแก้ไขแล้ว เรียก [getEffective](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/#getEffective) อีกครั้งหลังจากเปลี่ยนแปลงสิ่งใดที่อาจเข้าร่วมในลำดับขั้นนั้น, รวมถึง:

- การจัดรูปแบบ local ของวัตถุ;
- ค่าเริ่มต้นของย่อหน้า หรือเฟรมข้อความ;
- สไตล์ตาราง, ตาราง, คอลัมน์, แถว, หรือรูปแบบเซลล์;
- การจัดรูปแบบเค้าโครงหรือมาสเตอร์สไลด์;
- ข้อมูลธีมหรือค่าเริ่มต้นระดับการนำเสนอ;
- เค้าโครงหรือมาสเตอร์ที่กำหนดให้สไลด์

อย่าเก็บวัตถุข้อมูล effective ไว้เป็นสแนปช็อตถาวร Aspose.Slides อาจแคชข้อมูล effective บางส่วนภายใน, และการเรียก [getEffective](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/#getEffective) ในภายหลังสามารถรีเฟรชข้อมูลนั้นได้ หากคุณต้องการเปรียบเทียบค่าก่อนและหลังการเปลี่ยนแปลง, คัดลอกค่าขนาด scalar ที่ต้องการ เช่น ความสูงฟอนต์, สี, การจัดแนว, หรือความกว้าง bevel ไปยังตัวแปรของคุณเองก่อนทำการเปลี่ยนแปลง

เพื่อเปลี่ยนค่า, ปรับปรุงวัตถุรูปแบบ local ที่เหมาะสมแล้วเรียก [getEffective](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/#getEffective) เพื่อตรวจสอบผลลัพธ์ วัตถุข้อมูล effective เองเป็นแบบอ่านอย่างเดียว

## **คำถามที่พบบ่อย**

**ฉันจะบอกได้อย่างไรว่าระดับใดให้ค่าที่ effective?**

ข้อมูล effective มีค่าขั้นสุดท้าย, ไม่ได้บอกแหล่งที่มาของค่า ตรวจสอบวัตถุ local ที่เกี่ยวข้องจากระดับที่เจาะจงที่สุดออกมาทีละระดับ สำหรับข้อความอาจรวมถึง portion, paragraph, text frame, layout, master, theme, และค่าเริ่มต้นของการนำเสนอ ค่าที่ไม่ได้กำหนดเช่น `float("nan")` หรือ `None` บ่งบอกว่าการค้นหายังคงดำเนินต่อไปยังระดับอื่น

**จะเกิดอะไรขึ้นเมื่อไม่มีระดับใดกำหนดคุณสมบัติ?**

Aspose.Slides จะแก้ไขค่าเริ่มต้นของ PowerPoint หรือของไลบรารีที่เหมาะสม ค่าที่แก้ไขแล้วจะปรากฏในข้อมูล effective แม้ว่าจะไม่มีวัตถุ local ใดกำหนดค่าโดยตรงก็ตาม

**ทำไมค่าที่ effective บางครั้งจึงเท่ากับค่าที่ local?**

ค่าที่ local ชนะการคำนวณการสืบทอด ซึ่งเป็นสิ่งที่คาดหวังเมื่อคุณสมบัติกำหนดอย่างชัดเจนบนวัตถุและไม่มีกฎที่เจาะจงมากกว่ามาแทนที่มัน

**เมื่อใดที่ควรใช้ข้อมูล local แทนข้อมูล effective?**

ใช้ข้อมูล local เพื่อสำรวจหรือแก้ไขระดับการจัดรูปแบบเฉพาะ ใช้ข้อมูล effective เมื่อคุณต้องการลักษณะสุดท้ายหลังจากการสืบทอด, กฎธีม, และสไตล์ที่ใช้แล้ว ตัวอย่างการเปรียบเทียบเต็มรูปแบบ ([ตัวอย่างการเปรียบเทียบเต็มรูปแบบ](#compare-local-inherited-and-effective-values)) แสดงทั้งสองกรณีใน workflow เดียวกัน