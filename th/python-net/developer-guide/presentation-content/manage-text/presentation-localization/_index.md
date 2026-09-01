---
title: อัตโนมัติการแปลภาษาเอกสารนำเสนอด้วย Python
linktitle: การแปลภาษาเอกสารนำเสนอ
type: docs
weight: 100
url: /th/python-net/presentation-localization/
keywords:
- เปลี่ยนภาษา
- การตรวจการสะกด
- ปิดการตรวจการสะกด
- ภาษาการพิสูจน์อักษร
- รหัสภาษา
- ข้อความหลายภาษา
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "ตั้งค่าภาษาการพิสูจน์อักษรสำหรับข้อความเอกสารนำเสนอ PowerPoint และ OpenDocument ด้วย Python และ Aspose.Slides รวมถึงค่าปริยายและย่อหน้าหลายภาษา."
---
## **ภาพรวม**

Aspose.Slides for Python via .NET ให้คุณกำหนดเมตาดาต้าการพิสูจน์อักษรสำหรับส่วนข้อความแต่ละส่วน ใช้ [BasePortionFormat.language_id](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseportionformat/language_id/) เพื่อระบุภาษาการพิสูจน์อักษร, [BasePortionFormat.spell_check](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseportionformat/spell_check/) เพื่อเปิดหรือปิดการตรวจการสะกด, และ [BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseportionformat/proof_disabled/) เพื่อควบคุมสถานะ “ไม่พิสูจน์” ทั้งหมด เนื่องจากการตั้งค่าเหล่านี้ทำงานระดับส่วนข้อความ ย่อหน้าเดียวจึงสามารถมีหลายภาษาและกฎการพิสูจน์ที่ต่างกันได้

บทความนี้อธิบายวิธีกำหนดภาษาต่อข้อความเฉพาะ ตั้งค่าภาษาปริยายสำหรับข้อความใหม่ด้วย [LoadOptions.default_text_language](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/default_text_language/), สร้างย่อหน้าหลายภาษา, เลือกใช้งานระหว่าง `spell_check` กับ `proof_disabled`, และรักษาการตั้งค่าเดิมเมื่อใช้ [Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/join_portions_with_same_formatting/). คุณสมบัติเหล่านี้เก็บเมตาดาต้าสำหรับแอปพลิเคชันพรีเซนเทชัน; ไม่ได้ทำการแปลข้อความ, ตรวจการสะกดโดยพจนานุกรม, หรือคืนค่าคำที่สะกดผิด

## **กำหนดภาษาการพิสูจน์อักษรสำหรับข้อความ**

สร้างหรือโหลด [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/), เข้าถึงส่วนข้อความที่ต้องการผ่าน [Portion.portion_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/portion_format/), แล้วกำหนดตัวระบุภาษา ตัวอย่างต่อไปนี้สร้างรูปทรง ตั้งค่าภาษาอังกฤษแบบบริติชเป็นภาษาการพิสูจน์อักษร และบันทึกผลลัพธ์ด้วย [Presentation.save](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/save/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Set the proofing language for this text."

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.language_id = "en-GB"

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **กำหนดภาษาปริยายสำหรับข้อความใหม่**

ใช้ [LoadOptions.default_text_language](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/default_text_language/) เพื่อระบุภาษาการพิสูจน์อักษรที่ Aspose.Slides จะกำหนดให้กับข้อความที่สร้างใหม่ การตั้งค่านี้มีประโยชน์เมื่อข้อความใหม่ส่วนใหญ่หรือทั้งหมดในพรีเซนเทชันใช้ภาษาเดียวกัน ไม่ได้เปลี่ยนเมตาดาต้าภาษาในข้อความที่มีการกำหนดภาษาอย่างชัดเจนแล้ว

ตัวอย่างต่อไปนี้สร้างพรีเซนเทชันที่ข้อความใหม่ใช้กฎการพิสูจน์อักษรภาษาเยอรมัน:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "de-DE"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Willkommen zur Präsentung"

    presentation.save("default_text_language.pptx", slides.export.SaveFormat.PPTX)
```

## **ใช้หลายภาษาในย่อหน้าเดียว**

[Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) มีคอลเลกชันของส่วนข้อความ สร้าง [Portion](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/) แยกต่างหากสำหรับแต่ละภาษา แล้วกำหนด `language_id` ของแต่ละส่วนอย่างอิสระ

ตัวอย่างนี้สร้างย่อหน้าเดียวที่มีส่วนข้อความภาษาอังกฤษและภาษาฝรั่งเศส:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    english_portion = slides.Portion("Welcome")
    english_portion.portion_format.language_id = "en-US"
    paragraph.portions.add(english_portion)

    french_portion = slides.Portion(" — Bienvenue")
    french_portion.portion_format.language_id = "fr-FR"
    paragraph.portions.add(french_portion)

    presentation.save("multilingual_text.pptx", slides.export.SaveFormat.PPTX)
```

## **เปิดหรือปิดการตรวจการสะกดสำหรับส่วนข้อความแต่ละส่วน**

[PortionFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/) สืบทอดคุณสมบัติเข้าถึงข้อความทั่วไปที่กำหนดโดย [BasePortionFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseportionformat/). เข้าถึงรูปแบบของส่วนข้อความผ่าน [Portion.portion_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/portion_format/) แล้วตั้งค่า [BasePortionFormat.spell_check](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseportionformat/spell_check/) เพื่อควบคุมว่ามอซอฟต์แวร์พรีเซนเทชันอาจตรวจการสะกดสำหรับส่วนนั้นหรือไม่ ค่าเริ่มต้นคือ `False`: `True` เปิดการตรวจการสะกด, `False` ปิดการตรวจ

การตั้งค่านี้ใช้กับส่วนข้อความแต่ละส่วน ส่วนต่าง ๆ ในย่อหน้าเดียวกันจึงสามารถมีค่าต่างกันได้ [BasePortionFormat.language_id](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseportionformat/language_id/) และ `spell_check` มีวัตถุประสงค์เสริมกัน: `language_id` ระบุภาษาการพิสูจน์อักษร, ส่วน `spell_check` กำหนดว่าการตรวจการสะกดจะเปิดหรือปิดสำหรับส่วนนั้น

[BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseportionformat/proof_disabled/) ยังควบคุมการพิสูจน์อักษร แต่เป็นตัวแทนของสถานะ “ไม่พิสูจน์” อย่างกว้างโดยใช้ [NullableBool](https://reference.aspose.com/slides/th/python-net/aspose.slides/nullablebool/). ใช้ `spell_check` เมื่อต้องการสวิตช์แบบบูลีนโดยตรงสำหรับการตรวจการสะกด ใช้ `proof_disabled` เมื่อต้องการเก็บหรือควบคุมเมตาดาต้า “ไม่พิสูจน์” ของพรีเซนเทชันอย่างชัดเจน รวมถึงสถานะ `NOT_DEFINED` ของมัน หากกำหนดทั้งสองคุณสมบัติ ควรรักษาค่าของพวกมันให้สอดคล้องกัน; อย่าผสม `spell_check = True` กับ `proof_disabled = slides.NullableBool.TRUE`

คุณสมบัติเหล่านี้กำหนดเมตาดาต้าการพิสูจน์อักษรที่ใช้โดย PowerPoint และแอปพลิเคชันพรีเซนเทชันอื่น ๆ Aspose.Slides ไม่ได้ใช้มันเพื่อรันการตรวจการสะกดแบบพจนานุกรมหรือคืนรายการคำที่สะกดผิด

ตัวอย่างเต็มต่อไปนี้สร้างพรีเซนเทชันต้นฉบับ, โหลดมัน, กำหนดการตั้งค่าการตรวจการสะกดและภาษาการพิสูจน์อักษรที่ต่างกันให้สองส่วนในย่อหน้าเดียวกัน, บันทึกผลลัพธ์, เปิดใหม่อีกครั้ง, และตรวจสอบค่าที่เก็บไว้:

```python
import aspose.slides as slides

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

with slides.Presentation() as source_presentation:
    source_slide = source_presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    source_paragraph = source_shape.text_frame.paragraphs[0]
    source_paragraph.portions.clear()

    source_english_portion = slides.Portion("Check this text. ")
    source_english_portion.portion_format.language_id = "en-US"
    source_paragraph.portions.add(source_english_portion)

    source_french_portion = slides.Portion("Ignorer ce code : ZX-81.")
    source_french_portion.portion_format.language_id = "fr-FR"
    source_paragraph.portions.add(source_french_portion)

    source_presentation.save(input_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(input_file) as presentation:
    shape = presentation.slides[0].shapes[0]
    portions = shape.text_frame.paragraphs[0].portions

    checked_portion = portions[0]
    checked_portion.portion_format.language_id = "en-US"
    checked_portion.portion_format.spell_check = True

    suppressed_portion = portions[1]
    suppressed_portion.portion_format.language_id = "fr-FR"
    suppressed_portion.portion_format.spell_check = False

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]
    stored_portions = reopened_shape.text_frame.paragraphs[0].portions

    has_two_portions = stored_portions.count == 2

    first_portion_stored = (
        has_two_portions 
        and stored_portions[0].portion_format.language_id == "en-US" 
        and stored_portions[0].portion_format.spell_check
    )

    second_portion_stored = (
        has_two_portions
        and stored_portions[1].portion_format.language_id == "fr-FR" 
        and not stored_portions[1].portion_format.spell_check
    )

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")
```

[Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) จะรวมส่วนข้อความที่อยู่ติดกันและมีรูปแบบเดียวกัน ความแตกต่างเพียงอย่างเดียวใน `spell_check` จะไม่ทำให้ส่วนแยกจากกัน; หลังจากรวมแล้วส่วนที่ได้จะคงค่าของ `spell_check` จากส่วนแรก หากต้องการให้ส่วนต่าง ๆ มีการตั้งค่าการตรวจการสะกดที่แตกต่างกัน ให้เรียก `join_portions_with_same_formatting` ก่อนกำหนดค่าดังกล่าว, หรือสแกนขอบเขตของส่วนที่ได้และใส่ค่าตั้งใหม่หลังจากนั้น ส่วนที่มีค่าของ `language_id` แตกต่างกันจะยังคงแยกจากกันเนื่องจากรูปแบบภาษาการพิสูจน์อักษรต่างกัน

## **คำถามที่พบบ่อย**

**รหัสภาษา (Language ID) จะทำการแปลข้อความหรือไม่?**

ไม่. [BasePortionFormat.language_id](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseportionformat/language_id/) เก็บเมตาดาต้าการพิสูจน์อักษรสำหรับการสะกดและไวยากรณ์; ไม่ได้เปลี่ยนเนื้อหาข้อความ แปลข้อความแยกต่างหาก แล้วจึงกำหนดตัวระบุภาษาที่เหมาะสมให้กับแต่ละส่วนที่แปลแล้ว

**ภาษาการพิสูจน์อักษรควบคุมแบบอักษร, การตัดคำ, หรือการตัดบรรทัดหรือไม่?**

ไม่. ตัวระบุภาษาใช้สำหรับการพิสูจน์อักษรเท่านั้น การแสดงผลและการจัดวางข้อความขึ้นอยู่กับ [แบบอักษร](/slides/th/python-net/powerpoint-fonts/), ระบบการเขียน, และการตั้งค่าเฟรมข้อความ เพื่อให้การแสดงผลเชื่อถือได้ ให้จัดเตรียมแบบอักษรที่ต้องการ, ตั้งค่า [การแทนที่แบบอักษร](/slides/th/python-net/font-substitution/), หรือ [ฝังแบบอักษร](/slides/th/python-net/embedded-font/) ลงในพรีเซนเทชัน

**ย่อหน้าเดียวสามารถใช้หลายภาษาการพิสูจน์อักษรได้หรือไม่?**

ได้. กำหนดแต่ละภาษาให้กับส่วนข้อความแยกต่างหากตามที่แสดงในตัวอย่างย่อหน้าหลายภาษา

**ควรใช้ `default_text_language` หรือ `language_id`?**

ใช้ [LoadOptions.default_text_language](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/default_text_language/) เมื่อต้องการค่าปริยายสำหรับข้อความที่สร้างใหม่ ใช้ [BasePortionFormat.language_id](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseportionformat/language_id/) เมื่อต้องการกำหนดภาษาการพิสูจน์อักษรอย่างชัดเจนสำหรับส่วนข้อความเฉพาะ หรือเมื่อย่อหน้ามีหลายภาษา