---
title: อัตโนมัติการแปลภาษาในงานนำเสนอด้วย Python ผ่าน Java
linktitle: การแปลภาษาในงานนำเสนอ
type: docs
weight: 100
url: /th/python-java/presentation-localization/
keywords:
- เปลี่ยนภาษา
- ตรวจสอบการสะกด
- ปิดการตรวจสอบการสะกด
- ภาษาการตรวจสอบ
- รหัสภาษา
- ข้อความหลายภาษา
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "กำหนดภาษาการตรวจสอบสำหรับข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Python ผ่าน Java ด้วย Aspose.Slides รวมถึงค่าเริ่มต้นและย่อหน้าหลายภาษา."
---
## **ภาพรวม**

Aspose.Slides for Python via Java ให้คุณกำหนดค่า metadata การตรวจสอบภาษาสำหรับส่วนข้อความแต่ละส่วน ใช้ [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setLanguageId) เพื่อระบุภาษาการตรวจสอบ, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setSpellCheck) เพื่อเปิดหรือปิดการตรวจสอบการสะกด, และ [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setProofDisabled) เพื่อควบคุมสถานะ “ไม่ตรวจสอบ” อย่างกว้างขวาง เนื่องจากการตั้งค่าเหล่านี้ถูกนำไปใช้ระดับส่วนข้อความ หนึ่งย่อหน้าจึงสามารถมีหลายภาษาและกฎการตรวจสอบที่ต่างกันได้

บทความนี้อธิบายวิธีกำหนดภาษาสำหรับข้อความเฉพาะ, ตั้งค่าภาษาเริ่มต้นสำหรับข้อความใหม่ด้วย [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage), สร้างย่อหน้าหลายภาษา, เลือกระหว่าง [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setSpellCheck) และ [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setProofDisabled), และรักษาการตั้งค่าเดิมเมื่อใช้ [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) คุณสมบัติเหล่านี้เก็บ metadata สำหรับแอปพลิเคชันนำเสนอ; ไม่ได้แปลข้อความ, ทำการตรวจสอบการสะกดแบบพจนานุกรม, หรือคืนคำที่สะกดผิด

## **ตั้งค่าภาษาการตรวจสอบสำหรับข้อความ**

สร้างหรือโหลด [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/), เข้าถึงส่วนข้อความที่ต้องการผ่าน [Portion.getPortionFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/#getPortionFormat), แล้วกำหนดตัวระบุภาษา ตัวอย่างต่อไปนี้สร้างรูปทรง, ตั้งค่าภาษาอังกฤษแบบบริติชเป็นภาษาการตรวจสอบ, และบันทึกผลลัพธ์ด้วย [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Set the proofing language for this text.")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setLanguageId("en-GB")

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งค่าภาษาเริ่มต้นสำหรับข้อความใหม่**

ใช้ [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) เพื่อระบุภาษาการตรวจสอบที่ Aspose.Slides กำหนดให้กับข้อความที่สร้างใหม่ การตั้งค่านี้เป็นประโยชน์เมื่อข้อความใหม่ส่วนใหญ่หรือทั้งหมดในงานนำเสนอใช้ภาษาเดียวกัน ไม่ได้เปลี่ยนแปลง metadata ของข้อความที่มีการระบุภาษาไว้แล้วแล้ว

ตัวอย่างต่อไปนี้สร้างงานนำเสนอที่ข้อความใหม่ใช้กฎการตรวจสอบภาษาเยอรมนี:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("de-DE")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Willkommen zur Präsentation")

    presentation.save("default_text_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ใช้หลายภาษาในย่อหน้าหนึ่ง**

[Paragraph](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/) มีคอลเลกชันของส่วนข้อความ สร้าง [Portion](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/) แยกสำหรับแต่ละภาษาและตั้งค่า [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setLanguageId) อย่างอิสระ

ตัวอย่างนี้สร้างย่อหน้าหนึ่งที่มีส่วนข้อความภาษาอังกฤษและภาษาฝรั่งเศส:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    english_portion = Portion("Welcome")
    english_portion.getPortionFormat().setLanguageId("en-US")
    paragraph.getPortions().add(english_portion)

    french_portion = Portion(" — Bienvenue")
    french_portion.getPortionFormat().setLanguageId("fr-FR")
    paragraph.getPortions().add(french_portion)

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เปิดหรือปิดการตรวจสอบการสะกดสำหรับส่วนข้อความแต่ละส่วน**

[PortionFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/) สืบทอดคุณสมบัติข้อความทั่วไปที่กำหนดโดย [BasePortionFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/) เข้าถึงรูปแบบของส่วนข้อความผ่าน [Portion.getPortionFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/#getPortionFormat) และใช้ [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setSpellCheck) เพื่อควบคุมว่ารายการนำเสนออาจตรวจสอบการสะกดสำหรับส่วนนั้นหรือไม่ ค่าเริ่มต้นคือ `False`: `True` ให้การตรวจสอบการสะกด, `False` ปิดการตรวจสอบ

การตั้งค่านี้ใช้กับส่วนข้อความแต่ละส่วน ส่วนต่าง ๆ ในย่อหน้าหนึ่งจึงสามารถใช้ค่าที่ต่างกันได้ [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setLanguageId) และ [setSpellCheck](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setSpellCheck) ทำหน้าที่เสริมกัน: [setLanguageId](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setLanguageId) ระบุภาษาการตรวจสอบ, ในขณะที่ [setSpellCheck](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setSpellCheck) กำหนดว่าการตรวจสอบการสะกดจะถูกเปิดหรือปิดสำหรับส่วนนั้น

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setProofDisabled) ก็ทำหน้าที่ควบคุมการตรวจสอบเช่นกัน แต่เป็นการแสดงสถานะ “ไม่ตรวจสอบ” อย่างกว้างขวางในรูปแบบ [NullableBool](https://reference.aspose.com/slides/th/python-java/aspose.slides/nullablebool/) ใช้ [setSpellCheck](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setSpellCheck) เมื่อคุณต้องการสวิตซ์ Boolean ตรงสำหรับการตรวจสอบการสะกด ใช้ [setProofDisabled](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setProofDisabled) เมื่อคุณต้องการเก็บหรือควบคุม metadata “ไม่ตรวจสอบ” ของงานนำเสนออย่างชัดเจน รวมถึงสถานะ [NullableBool.NotDefined](https://reference.aspose.com/slides/th/python-java/aspose.slides/nullablebool/#NotDefined) หากคุณตั้งค่าทั้งสองคุณสมบัติให้สอดคล้องกัน; อย่าสับ <[setSpellCheck](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setSpellCheck)> เป็น `True` กับ [setProofDisabled](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setProofDisabled) เป็นสถานะ [NullableBool.True](https://reference.aspose.com/slides/th/python-java/aspose.slides/nullablebool/#True)

คุณสมบัติเหล่านี้กำหนด metadata การตรวจสอบที่ใช้โดย PowerPoint และแอปพลิเคชันนำเสนออื่น ๆ Aspose.Slides ไม่ได้ใช้เพื่อรันการตรวจสอบการสะกดแบบพจนานุกรมหรือคืนรายการคำที่สะกดผิด

ตัวอย่างเต็มต่อไปนี้สร้างงานนำเข้าการนำเสนอ, โหลดมัน, กำหนดการตั้งค่าการตรวจสอบการสะกดและภาษาการตรวจสอบที่แตกต่างสำหรับสองส่วนในย่อหน้าเดียวกัน, บันทึกผลลัพธ์, เปิดใหม่อีกครั้ง, และยืนยันค่าที่เก็บไว้:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

source_presentation = Presentation()
try:
    source_slide = source_presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    source_paragraph = source_shape.getTextFrame().getParagraphs().get_Item(0)
    source_paragraph.getPortions().clear()

    source_english_portion = Portion("Check this text. ")
    source_english_portion.getPortionFormat().setLanguageId("en-US")
    source_paragraph.getPortions().add(source_english_portion)

    source_french_portion = Portion("Ignorer ce code : ZX-81.")
    source_french_portion.getPortionFormat().setLanguageId("fr-FR")
    source_paragraph.getPortions().add(source_french_portion)

    source_presentation.save(input_file, SaveFormat.Pptx)
finally:
    source_presentation.dispose()

presentation = Presentation(input_file)
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    checked_portion = portions.get_Item(0)
    checked_portion.getPortionFormat().setLanguageId("en-US")
    checked_portion.getPortionFormat().setSpellCheck(True)

    suppressed_portion = portions.get_Item(1)
    suppressed_portion.getPortionFormat().setLanguageId("fr-FR")
    suppressed_portion.getPortionFormat().setSpellCheck(False)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    stored_portions = reopened_shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    first_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(0).getPortionFormat().getLanguageId() == "en-US" and stored_portions.get_Item(0).getPortionFormat().getSpellCheck()

    second_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(1).getPortionFormat().getLanguageId() == "fr-FR" and not stored_portions.get_Item(1).getPortionFormat().getSpellCheck()

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")

finally:
    reopened_presentation.dispose()
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) รวมส่วนข้อความที่ต่อเนื่องกันที่มีรูปแบบเดียวกัน ความแตกต่างใน [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setSpellCheck) เพียงอย่างเดียวจะไม่ทำให้ส่วนเหล่านั้นแยกต่างหาก; หลังจากรวมแล้วส่วนที่ได้จะคงค่าของ [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setSpellCheck) ของส่วนแรก หากส่วนต้องการการตั้งค่าการตรวจสอบการสะกดที่ต่างกัน ให้เรียก [joinPortionsWithSameFormatting](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) ก่อนกำหนดการตั้งค่าเหล่านั้น, หรือสแกนขอบเขตของส่วนที่ได้และกำหนดค่าใหม่หลังจากนั้น ส่วนที่มีค่า [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setLanguageId) ต่างกันจะคงแยกกันอยู่เนื่องจากรูปแบบภาษาการตรวจสอบที่ต่างกัน

## **คำถามที่พบบ่อย**

**ID ของภาษาแปลข้อความหรือไม่?**

ไม่. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setLanguageId) จะเก็บ metadata การตรวจสอบการสะกดและไวยากรณ์; ไม่ได้เปลี่ยนเนื้อหาข้อความ แปลข้อความแยกต่างหาก, แล้วตั้งค่าตัวระบุภาษาที่เหมาะสมสำหรับแต่ละส่วนที่แปลแล้ว

**ภาษาการตรวจสอบควบคุมฟอนต์, การแยกคำ, หรือการตัดบรรทัดหรือไม่?**

ไม่. ตัวระบุภาษามีไว้สำหรับการตรวจสอบเท่านั้น การแสดงผลและการจัดวางข้อความขึ้นอยู่กับ [fonts](/slides/th/python-java/powerpoint-fonts/), ระบบการเขียน, และการตั้งค่ากรอบข้อความ สำหรับการเรนเดอร์ที่เชื่อถือได้ ให้จัดเตรียมฟอนต์ที่จำเป็น, กำหนด [font substitution](/slides/th/python-java/font-substitution/), หรือ [embed fonts](/slides/th/python-java/embedded-font/) ในงานนำเสนอ

**ย่อหน้าหนึ่งสามารถใช้หลายภาษาการตรวจสอบได้หรือไม่?**

ได้. กำหนดแต่ละภาษาให้กับส่วนข้อความแยกตามตัวอย่างย่อหน้าหลายภาษา

**ควรใช้ [setDefaultTextLanguage](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) หรือ [setLanguageId](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setLanguageId)?**

ใช้ [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) เมื่อคุณต้องการค่าเริ่มต้นสำหรับข้อความที่สร้างใหม่ ใช้ [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setLanguageId) เมื่อส่วนข้อความเฉพาะต้องการภาษาการตรวจสอบที่ชัดเจนหรือเมื่อย่อหน้ามีหลายภาษา