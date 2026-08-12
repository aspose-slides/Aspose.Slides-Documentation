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
- กรอบข้อความ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ค้นหา, ไฮไลท์, และแทนที่ข้อความในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **ภาพรวม**

Aspose.Slides for Python via .NET สามารถค้นหา ไลท์ไฮไลท์ และแทนที่ข้อความใน Text Frame เดียวหรือทั่วทั้งงานนำเสนอ ความสามารถเหล่านี้มีประโยชน์สำหรับการตรวจทาน การปกปิดข้อมูล การตรวจสอบคำศัพท์ การทำความสะอาดแม่แบบ และกระบวนการประมวลผลเอกสารอัตโนมัติต่าง ๆ

ในตัวอย่างแรกด้านล่าง เราใช้ไฟล์ชื่อ “sample.pptx” ซึ่งมีกล่องข้อความเดียวในสไลด์แรกพร้อมข้อความต่อไปนี้:

![Sample text](sample_text.png)

## **เลือกขอบเขตการค้นหา**

ใช้เมธอดบน [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) เพื่อลดการทำงานให้เฉพาะ Text Frame เดียว ใช้เมธอดบน [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) เพื่อประมวลผลข้อความทั้งหมดที่เกี่ยวข้องในงานนำเสนอ

| การดำเนินการ | Text Frame เดียว | งานนำเสนอทั้งหมด |
|---|---|---|
| ไฮไลท์ข้อความตามตัวอักษร | [TextFrame.highlight_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/highlight_text/) |
| ไฮไลท์ผลลัพธ์จาก regular‑expression | [TextFrame.highlight_regex](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/highlight_regex/) |
| แทนที่ข้อความตามตัวอักษร | [TextFrame.replace_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/replace_text/) |
| แทนที่ผลลัพธ์จาก regular‑expression | [TextFrame.replace_regex](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/replace_regex/) |

## **กำหนดการจับคู่ข้อความ**

สำหรับการทำงานแบบข้อความตามตัวอักษร ให้ใช้ [TextSearchOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides/textsearchoptions/) เพื่อควบคุมการจับคู่:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/th/python-net/aspose.slides/textsearchoptions/whole_words_only/) จำกัดการจับคู่ให้เป็นคำเต็มเท่านั้น
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/th/python-net/aspose.slides/textsearchoptions/case_sensitive/) ควบคุมว่าต้องตรงตามตัวพิมพ์ใหญ่‑เล็กหรือไม่
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/th/python-net/aspose.slides/textsearchoptions/include_notes/) รวมโน้ตสไลด์ในการค้นหา แทนที่ และไฮไลท์ระดับงานนำเสนอ

การทำงานแบบ regular‑expression ใช้สตริงแพทเทิร์น ดังนั้นกฎการจับคู่เช่นความไวต่อกรณีและขอบเขตคำจะกำหนดโดยนิพจน์เอง

## **ไฮไลท์ข้อความ**

ใช้เมธอด [TextFrame.highlight_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/highlight_text/) เพื่อไฮไลท์ผลลัพธ์จากข้อความตามตัวอักษรใน Text Frame ส่งค่า [TextSearchOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides/textsearchoptions/) เพื่อควบคุมการค้นหา

ตัวอย่างโค้ดด้านล่างไฮไลท์ทุกกรณีของอักขระ **"try"** แล้วจึงไฮไลท์เฉพาะคำเต็ม **"to"** เท่านั้น

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # ไฮไลท์ทุกตำแหน่งที่ปรากฏของ "try" ใน text frame.
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # ไฮไลท์เฉพาะคำเต็ม "to" เท่านั้น.
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The highlighted text](highlighted_text.png)

## **ไฮไลท์ข้อความโดยใช้ Regular Expressions**

เมธอด [TextFrame.highlight_regex](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/highlight_regex/) จะไฮไลท์ข้อความที่ตรงกับ regular expression ใน Text Frame

โค้ดต่อไปนี้ไฮไลท์ทุกคำที่มีอักขระเจ็ดตัวหรือมากกว่า:

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

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **ไฮไลท์ข้อความทั่วทั้งงานนำเสนอ**

ใช้ [Presentation.highlight_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/highlight_text/) และ [Presentation.highlight_regex](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/highlight_regex/) เพื่อค้นหา Text Frame ทั้งหมดที่เกี่ยวข้องในงานนำเสนอ ตัวอย่างต่อไปนี้ไฮไลท์คำตามตัวอักษรและที่อยู่อีเมลทั้งหมด:

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

## **แทนที่ข้อความใน Text Frame**

ใช้ [TextFrame.replace_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/replace_text/) สำหรับข้อความตามตัวอักษรและ [TextFrame.replace_regex](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/replace_regex/) สำหรับการแทนที่แบบแพทเทิร์น เมธอดเหล่านี้อัปเดตข้อความที่ตรงกันภายใน Text Frame เดิม ซึ่งจะคงรูปแบบส่วนรอบ ๆ ไว้แทนการสร้าง Text Frame ใหม่จากสตริงธรรมดา

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

หากการจับคู่หนึ่งครอบคลุมส่วนที่มีรูปแบบต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อยืนยันว่ารูปแบบใดควรนำมาใช้กับข้อความที่แทนที่

## **แทนที่ข้อความทั่วทั้งงานนำเสนอ**

ใช้ [Presentation.replace_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/replace_text/) และ [Presentation.replace_regex](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/replace_regex/) เพื่อทำการเดียวกันทั่วทั้งงานนำเสนอ สิ่งนี้มีประโยชน์สำหรับการทำความสะอาดแม่แบบ การอัปเดตคำศัพท์ และการปกปิดข้อมูล

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

**ฉันจะค้นหาใน Text Box เพียงอันเดียวแทนที่จะเป็นทั้งงานนำเสนอได้อย่างไร?**

ให้ดึง Text Frame ของรูปร่างและเรียกใช้ [TextFrame.highlight_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/replace_text/) หรือ [TextFrame.replace_regex](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/replace_regex/) บน Text Frame นั้น เมธอดระดับ Presentation จะประมวลผล Text Frame ทั้งหมดที่เกี่ยวข้องแทน

**ฉันจะจับคู่อย่คำเต็มโดยคำนึงถึงการใช้ตัวพิมพ์ใหญ่‑เล็กได้อย่างไร?**

ตั้งค่า [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/th/python-net/aspose.slides/textsearchoptions/whole_words_only/) และ [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/th/python-net/aspose.slides/textsearchoptions/case_sensitive/) ให้เป็น `True` แล้วส่งตัวเลือกเหล่านั้นไปยังเมธอดไฮไลท์หรือแทนที่ข้อความตามตัวอักษร สำหรับ regular expression ให้กำหนดขอบเขตคำและความไวต่อกรณีในแพทเทิร์นเอง

**การค้นหาและแทนที่สามารถรวมข้อความในโน้ตสไลด์ได้หรือไม่?**

ได้ ตั้งค่า [TextSearchOptions.include_notes](https://reference.aspose.com/slides/th/python-net/aspose.slides/textsearchoptions/include_notes/) ให้เป็น `True` เมื่อต้องการใช้การทำงานตามตัวอักษรระดับ Presentation

**การแทนที่ข้อความจะคงรูปแบบเดิมไว้หรือไม่?**

[TextFrame.replace_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/replace_text/) และ [TextFrame.replace_regex](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/replace_regex/) จะปรับเปลี่ยนข้อความที่ตรงกันภายใน Text Frame ที่มีอยู่และคงรูปแบบส่วนรอบ ๆ หากการจับคู่อยู่ในส่วนที่มีรูปแบบต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อให้แน่ใจว่าการแทนที่จะใช้สไตล์ที่ต้องการ