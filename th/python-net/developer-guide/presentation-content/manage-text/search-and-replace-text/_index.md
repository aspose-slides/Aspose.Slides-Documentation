---
title: ค้นหาและแทนที่ข้อความในงานนำเสนอ PowerPoint ด้วย Python
linktitle: ค้นหาและแทนที่ข้อความ
type: docs
weight: 55
url: /th/python-net/search-and-replace-text/
keywords:
- ค้นหาข้อความ
- ไฮไลท์ข้อความ
- แทนที่ข้อความ
- นิพจน์ปกติ
- เฟรมข้อความ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ค้นหา, ไฮไลท์, และแทนที่ข้อความในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **ภาพรวม**

Aspose.Slides สำหรับ Python ผ่าน .NET สามารถค้นหา, เน้นสี, และแทนที่ข้อความในเฟรมข้อความแต่ละอันหรือทั่วทั้งงานนำเสนอ ความสามารถเหล่านี้มีประโยชน์สำหรับการตรวจทาน, การลบข้อมูล, การตรวจสอบคำศัพท์, การทำความสะอาดแม่แบบ, และกระบวนการทำงานอัตโนมัติในการประมวลผลเอกสารอื่น ๆ

ในตัวอย่างแรกด้านล่าง เราใช้ไฟล์ชื่อ “sample.pptx” ซึ่งประกอบด้วยกล่องข้อความเดียวบนสไลด์แรกที่มีข้อความดังต่อไปนี้:

![ข้อความตัวอย่าง](sample_text.png)

## **เลือกขอบเขตการค้นหา**

ใช้เมธอดบน [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) เพื่อจำกัดการทำงานให้อยู่ในเฟรมข้อความหนึ่ง ใช้เมธอดบน [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) เพื่อประมวลผลข้อความทั้งหมดที่เกี่ยวข้องในงานนำเสนอ

| การดำเนินการ | เฟรมข้อความหนึ่ง | งานนำเสนอทั้งหมด |
|---|---|---|
| ไฮไลท์ข้อความตามตัวอักษร | [TextFrame.highlight_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/highlight_text/) |
| ไฮไลท์การจับคู่ตามนิพจน์ปกติ | [TextFrame.highlight_regex](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/highlight_regex/) |
| แทนที่ข้อความตามตัวอักษร | [TextFrame.replace_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/replace_text/) |
| แทนที่การจับคู่ตามนิพจน์ปกติ | [TextFrame.replace_regex](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/replace_regex/) |

## **กำหนดค่าการจับคู่ข้อความ**

สำหรับการทำงานกับข้อความตามตัวอักษร ให้ใช้ [TextSearchOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides/textsearchoptions/) เพื่อควบคุมการจับคู่:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/th/python-net/aspose.slides/textsearchoptions/whole_words_only/) จำกัดการจับคู่ให้เป็นคำเต็ม
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/th/python-net/aspose.slides/textsearchoptions/case_sensitive/) ควบคุมว่าต้องตรงกรณีตัวอักษรหรือไม่
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/th/python-net/aspose.slides/textsearchoptions/include_notes/) รวมบันทึกสไลด์ในการค้นหา, แทนที่, และไฮไลท์ระดับงานนำเสนอ

การทำงานกับนิพจน์ปกติใช้สตริงรูปแบบ ดังนั้นกฎการจับคู่เช่นการแยกตัวอักษรใหญ่‑เล็กและขอบเขตคำจะถูกกำหนดโดยนิพจน์เอง

## **ระบุเจ้าของของเฟรมข้อความ**

เวิร์กโฟลว์การประมวลผลข้อความทั่วไปมักได้รับ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ขณะทำการค้นหา, แทนที่, ตรวจสอบ, หรือส่งออกข้อความ ใช้ [TextFrame.parent_shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/parent_shape/) และ [TextFrame.parent_cell](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/parent_cell/) เพื่อระบุว่าออบเจกต์งานนำเสนอใดเป็นเจ้าของเฟรมข้อความ

ค่าที่คาดว่าจะได้ขึ้นอยู่กับเจ้าของ:

| เจ้าของเฟรมข้อความ | `parent_shape` | `parent_cell` |
|---|---|---|
| AutoShape หรือรูปร่างที่บรรจุข้อความอื่น | The owning [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) | `None` |
| เซลล์ตาราง | `None` | The owning [Cell](https://reference.aspose.com/slides/th/python-net/aspose.slides/cell/) |

คุณสมบัติเหล่านี้เป็นคุณสมบัติการนำทางแบบอ่าน‑อย่างเดียว การอ่านค่าเหล่านี้จะไม่ย้ายเฟรมข้อความหรือเปลี่ยนเจ้าของ โค้ดทั่วไปควรตรวจสอบทั้งสองค่าเพื่อดูว่าเป็น `None` หรือไม่ และจัดการกรณีที่ไม่มีเจ้าของใด ๆ

```python
import aspose.slides as slides


def get_slide_label(base_slide):
    if isinstance(base_slide, slides.Slide):
        return f"slide {base_slide.slide_number}"

    if isinstance(base_slide, slides.NotesSlide):
        return f"notes for slide {base_slide.parent_slide.slide_number}"

    return type(base_slide).__name__


with slides.Presentation("presentation.pptx") as presentation:
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, False)

    for text_frame in text_frames:
        owner_shape = text_frame.parent_shape
        if owner_shape is not None:
            shape_name = owner_shape.name or "(unnamed)"
            shape_type = type(owner_shape).__name__
            slide_label = get_slide_label(owner_shape.slide)
            print(f"Shape: {shape_name}; type: {shape_type}; {slide_label}")
            continue

        owner_cell = text_frame.parent_cell
        if owner_cell is not None:
            slide_label = get_slide_label(owner_cell.slide)
            print(f"Table cell: column {owner_cell.first_column_index}, row {owner_cell.first_row_index}; {slide_label}")
            continue

        print("The text frame owner is not available as a shape or table cell.")
```

สำหรับเนื้อหา SmartArt ให้วนลูปผ่านรูปร่างใน [SmartArtNode.shapes](https://reference.aspose.com/slides/th/python-net/aspose.slides.smartart/smartartnode/shapes/) และเข้าถึงแต่ละ [ISmartArtShape.text_frame](https://reference.aspose.com/slides/th/python-net/aspose.slides.smartart/ismartartshape/text_frame/) เฟรมข้อความสามารถตามรอยไปยังรูปร่างที่สังกัดผ่าน [TextFrame.parent_shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/parent_shape/) ส่วน [TextFrame.parent_cell](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/parent_cell/) มีค่าเป็น `None` ดังนั้นสาขารูปร่างในตัวอย่างจึงจัดการข้อความจากโหนด SmartArt ด้วย

## **ไฮไลท์ข้อความ**

ใช้เมธอด [TextFrame.highlight_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/highlight_text/) เพื่อไฮไลท์การจับคู่ข้อความตามตัวอักษรในเฟรมข้อความ ส่งผ่าน [TextSearchOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides/textsearchoptions/) เพื่อควบคุมการค้นหา

โค้ดตัวอย่างด้านล่างไฮไลท์ทุกครั้งที่ปรากฏของอักษร **"try"** แล้วไฮไลท์เฉพาะคำเต็ม **"to"** เท่านั้น

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # ไฮไลท์ทุกครั้งที่พบ "try" ในเฟรมข้อความ.
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # ไฮไลท์เฉพาะคำเต็ม "to".
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![ข้อความที่ถูกไฮไลท์](highlighted_text.png)

## **ไฮไลท์ข้อความโดยใช้นิพจน์ปกติ**

เมธอด [TextFrame.highlight_regex](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/highlight_regex/) จะไฮไลท์ข้อความที่ตรงกับนิพจน์ปกติในเฟรมข้อความ

โค้ดต่อไปนี้ไฮไลท์คำทั้งหมดที่มีตัวอักษรเจ็ดตัวหรือมากกว่า:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    word_pattern = r"\b[^\s]{7,}\b"

    shape.text_frame.highlight_regex(word_pattern, draw.Color.yellow, None)

    presentation.save(
        "highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX
    )
```

ผลลัพธ์:

![ข้อความที่ถูกไฮไลท์โดยใช้นิพจน์ปกติ](highlighted_text_using_regex.png)

## **ไฮไลท์ข้อความทั่วงานนำเสนอ**

ใช้ [Presentation.highlight_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/highlight_text/) และ [Presentation.highlight_regex](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/highlight_regex/) เพื่อค้นหาเฟรมข้อความทั้งหมดที่เกี่ยวข้องในงานนำเสนอ ตัวอย่างต่อไปนี้ไฮไลท์คำตามตัวอักษรและที่อยู่อีเมลทั้งหมด:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    presentation.highlight_text(
        "confidential", draw.Color.orange, search_options, None
    )

    email_pattern = r"(?i)\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b"
    presentation.highlight_regex(email_pattern, draw.Color.yellow)

    presentation.save(
        "highlighted_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **แทนที่ข้อความในเฟรมข้อความ**

ใช้ [TextFrame.replace_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/replace_text/) สำหรับข้อความตามตัวอักษรและ [TextFrame.replace_regex](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/replace_regex/) สำหรับการแทนที่แบบรูปแบบ เมธอดเหล่านี้จะอัปเดตข้อความที่ตรงกันภายในเฟรมข้อความที่มีอยู่ ซึ่งจะคงรูปแบบส่วนรอบ ๆ ไว้แทนการสร้างเฟรมข้อความใหม่จากสตริงธรรมดา

ตัวอย่างต่อไปนี้ทำให้รูปแบบการสะกดสอดคล้องกันแล้วแทนที่ป้ายเวอร์ชัน:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    shape.text_frame.replace_text(
        "colour", "color", search_options, None
    )

    version_pattern = r"(?i)\bv\d+(?:\.\d+)*\b"
    shape.text_frame.replace_regex(version_pattern, "current version")

    presentation.save(
        "updated_text_frame.pptx", slides.export.SaveFormat.PPTX
    )
```

หากหนึ่งการจับคู่ครอบคลุมส่วนที่มีรูปแบบต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อยืนยันว่ารูปแบบใดควรใช้กับข้อความที่แทนที่

## **แทนที่ข้อความทั่วงานนำเสนอ**

ใช้ [Presentation.replace_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/replace_text/) และ [Presentation.replace_regex](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/replace_regex/) เพื่อดำเนินการเดียวกันทั่วงานนำเสนอ สิ่งนี้มีประโยชน์สำหรับการทำความสะอาดแม่แบบ, การอัปเดตคำศัพท์, และการลบข้อมูล

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True

    presentation.replace_text(
        "Contoso", "Example Corp", search_options, None
    )

    account_number_pattern = r"\bACCT-\d{6}\b"
    presentation.replace_regex(account_number_pattern, "ACCT-REDACTED")

    presentation.save(
        "updated_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **คำถามที่พบบ่อย**

**ฉันจะค้นหาในกล่องข้อความเดียวแทนที่จะค้นทั้งงานนำเสนอได้อย่างไร?**

ดึงเฟรมข้อความของรูปร่างและเรียกใช้ [TextFrame.highlight_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/replace_text/), หรือ [TextFrame.replace_regex](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/replace_regex/) บนเฟรมข้อความนั้น เมธอดระดับงานนำเสนอจะประมวลผลเฟรมข้อความทั้งหมดที่เกี่ยวข้องแทน

**ฉันจะจับคู่คำเต็มพร้อมการใช้ตัวพิมพ์ใหญ่‑เล็กที่ถูกต้องได้อย่างไร?**

ตั้งค่า [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/th/python-net/aspose.slides/textsearchoptions/whole_words_only/) และ [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/th/python-net/aspose.slides/textsearchoptions/case_sensitive/) เป็น `True` แล้วส่งตัวเลือกเหล่านั้นไปยังเมธอดไฮไลท์หรือแทนที่ข้อความตามตัวอักษร สำหรับนิพจน์ปกติ ให้กำหนดขอบเขตคำและการแยกตัวพิมพ์ใหญ่‑เล็กในรูปแบบเอง

**การค้นหาและการแทนที่สามารถรวมข้อความในบันทึกสไลด์ได้หรือไม่?**

ได้ ตั้งค่า [TextSearchOptions.include_notes](https://reference.aspose.com/slides/th/python-net/aspose.slides/textsearchoptions/include_notes/) เป็น `True` เมื่อใช้การดำเนินการข้อความตามตัวอักษรระดับงานนำเสนอ

**การแทนที่ข้อความจะรักษาการจัดรูปแบบของมันไว้หรือไม่?**

[TextFrame.replace_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/replace_text/) และ [TextFrame.replace_regex](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/replace_regex/) จะแก้ไขข้อความที่ตรงกันภายในเฟรมข้อความที่มีอยู่และคงรูปแบบส่วนรอบไว้ หากการจับคู่อยู่ครอบส่วนที่มีรูปแบบต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อให้แน่ใจว่าการแทนที่ใช้สไตล์ตามที่ต้องการ