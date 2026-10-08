---
title: กำหนดค่าการแทนที่แบบอักษรในการนำเสนอโดยใช้ Python ผ่าน Java
linktitle: การแทนที่แบบอักษร
type: docs
weight: 70
url: /th/python-java/font-substitution/
keywords:
- แบบอักษร
- แบบอักษรทดแทน
- การแทนที่แบบอักษร
- เปลี่ยนแบบอักษร
- การเปลี่ยนแบบอักษร
- กฎการแทนที่
- กฎการเปลี่ยน
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "กำหนดค่ากฎการแทนที่แบบอักษรและตรวจสอบแบบอักษรที่ถูกแทนที่ใน Aspose.Slides สำหรับ Python ผ่าน Java ขณะเรนเดอร์หรือแปลงการนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

การแทนที่แบบอักษรทำให้ Aspose.Slides สามารถใช้แบบอักษรที่มีอยู่แทนแบบอักษรที่ไม่สามารถเข้าถึงได้เมื่อการนำเสนอได้รับการเรนเดอร์หรือแปลง การแทนที่มีผลต่อผลลัพธ์ที่เรนเดอร์; ไม่ได้เปลี่ยนแบบอักษรที่กำหนดให้กับเนื้อหาในงานนำเสนอ

คุณสามารถกำหนดแบบอักษรที่จะใช้เมื่อแบบอักษรเฉพาะไม่พร้อมใช้งาน และคุณสามารถตรวจสอบการแทนที่ที่ Aspose.Slides จะทำระหว่างการเรนเดอร์ สิ่งนี้ช่วยให้ผลลัพธ์สอดคล้องกันในสภาพแวดล้อมที่ติดตั้งแบบอักษรต่างกัน

หากแบบอักษรพร้อมใช้งานแต่ไม่มีตัวหนาที่กำหนดไว้ให้ ดูที่ [จัดการแบบอักษรที่ไม่มีตัวหนาที่กำหนดไว้](/slides/th/python-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) ส่วนนี้อธิบายวิธีทำเรสเตอร์ไลซ์ข้อความที่ได้รับผลกระทบระหว่างการส่งออกเป็น PDF และผลที่ตามมาสำหรับการเลือกข้อความ การค้นหา และการสเกล

## **รับการแทนที่แบบอักษร**

ใช้เมธอด [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) เพื่อกำหนดว่ามีการแทนที่แบบอักษรใดบ้างเมื่อการนำเสนอได้รับการเรนเดอร์ เมธอดนี้คืนค่าอ็อบเจ็กต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) ที่ระบุชื่อแบบอักษรต้นฉบับและแบบอักษรที่แทนที่

ตัวอย่าง Python ต่อไปนี้แสดงรายการการแทนที่แบบอักษรทั้งหมดสำหรับการนำเสนอ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    for substitution in presentation.getFontsManager().getSubstitutions():
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")
finally:
    presentation.dispose()
```

## **รับการแทนที่แบบอักษรสำหรับสไลด์ที่เลือก**

ใช้โอเวอร์โหลดของ [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) พร้อมอาร์กิวเมนต์อาร์เรย์จำนวนเต็ม Java เพื่อสำรวจเฉพาะการแทนที่ที่จำเป็นสำหรับการเรนเดอร์สไลด์ที่ระบุเท่านั้น ซึ่งมีประโยชน์เมื่อคุณกำลังเรนเดอร์หรือส่งออกบางส่วนของการนำเสนอ ตรวจสอบการนำเสนอขนาดใหญ่แบบเพิ่มขั้นตั่ง ค้นหาสไลด์ที่พึ่งพาแบบอักษรที่ไม่มีอยู่ เตรียมแพ็คเกจแบบอักษรขั้นต่ำสำหรับเซิร์ฟเวอร์หรือคอนเทนเนอร์ หรือวิเคราะห์ความแตกต่างของการเรนเดอร์โดยไม่ต้องประมวลผลสไลด์ที่ไม่เกี่ยวข้อง

อาร์เรย์ `slides` มีดัชนีสไลด์แบบหนึ่ง‑ฐาน: `1` ระบุสไลด์แรก ในทางตรงกันข้าม ตัวเข้าถึงคอลเลกชัน [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) ใช้การจัดอันดับแบบศูนย์‑ฐาน ดังนั้นสไลด์เดียวกันจะถูกเข้าถึงเป็น `presentation.getSlides().get_Item(0)` จำไว้ว่ามีความแตกต่างนี้เมื่อตั้งค่าอาร์เรย์เพื่อหลีกเลี่ยงข้อผิดพลาดแบบ off‑by‑one

เรียกโอเวอร์โหลดผ่านเมธอด [Presentation.getFontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getFontsManager) มันจะคืนค่าการแทนที่ที่กำหนดขณะเรนเดอร์สไลด์ที่เลือกแต่ละผลลัพธ์เป็นอ็อบเจ็กต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) ที่มีชื่อแบบอักษรต้นฉบับและแบบอักษรที่แทนที่ ผลลัพธ์สะท้อนสภาพแวดล้อมแบบอักษรปัจจุบัน กฎการสำรองที่กำหนดค่า กฎการแทนที่ที่เก็บอยู่ใน [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/) และ [แบบอักษรที่โหลดจากภายนอก](/slides/th/python-java/custom-font/)

การแทนที่เดียวกันอาจจำเป็นสำหรับสไลด์ที่เลือกหลายสไลด์ ให้ทำการลบข้อมูลซ้ำเมื่อคุณสร้างรายการแบบอักษรหรือรายงานการตรวจสอบ ตัวอย่างต่อไปนี้รายงานการแทนที่ทุกรายการที่ส่งกลับแล้วสร้างรายการแบบอักษรที่ไม่ซ้ำเรียงลำดับ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    selected_slides = jpype.JArray(jpype.JInt)([1, 3, 5])
    substitutions = list(presentation.getFontsManager().getSubstitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")

    unique_entries = {}
    for substitution in substitutions:
        entry = f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}"
        unique_entries.setdefault(entry.casefold(), entry)

    print("Deduplicated font preflight report:")
    for key in sorted(unique_entries):
        print(unique_entries[key])
finally:
    presentation.dispose()
```

คลาส [FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/) มีโอเวอร์โหลดทั้งสองแบบ ให้เลือกตามขอบเขตของการดำเนินการเรนเดอร์:

| โอเวอร์โหลด | ใช้เมื่อ |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) ที่ไม่มีอาร์กิวเมนต์ | คุณต้องการการแทนที่สำหรับการนำเสนอทั้งหมด |
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) พร้อมอาร์เรย์จำนวนเต็ม Java | คุณต้องการการแทนที่สำหรับช่วงที่เลือก การตรวจสอบแบบเพิ่มขั้นตั่ง หรือการส่งออกบางส่วน |

## **กำหนดกฎการแทนที่แบบอักษร**

เพื่อระบุแบบอักษรที่ Aspose.Slides ควรใช้เมื่อแบบอักษรต้นทางไม่มีอยู่:

1. โหลดการนำเสนอ
2. สร้างการกำหนดแบบอักษรสำหรับแบบอักษรต้นฉบับและแบบอักษรทดแทน
3. สร้าง [FontSubstRule](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrule/) ด้วยเงื่อนไข [WhenInaccessible](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible)
4. เพิ่มกฎลงใน [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/)
5. กำหนดค่าคอลเลกชันโดยใช้เมธอด [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList)
6. เรนเดอร์หรือแปลงการนำเสนอ

ตัวอย่าง Python ต่อไปนี้แทนที่ `Arial` ด้วย `SomeRareFont` เมื่อ `SomeRareFont` ไม่พร้อมใช้งาน แล้วเรนเดอร์สไลด์แรกเพื่อยืนยันผลลัพธ์ แบบอักษรทดแทนต้องมีให้กับ Aspose.Slides

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, FontSubstCondition, FontSubstRule, FontSubstRuleCollection, ImageFormat, Presentation

presentation = Presentation("Fonts.pptx")
try:
    source_font = FontData("SomeRareFont")
    substitute_font = FontData("Arial")
    substitution_rule = FontSubstRule(source_font, substitute_font, FontSubstCondition.WhenInaccessible)

    substitution_rules = FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.getFontsManager().setFontSubstRuleList(substitution_rules)

    image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        image.save("slide.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
สำหรับการเปลี่ยนแปลงแบบไม่มีเงื่อนไขต่อแบบอักษรที่ใช้ทั่วทั้งการนำเสนอ ให้ดูที่ [Font Replacement](/slides/th/python-java/font-replacement/)
{{% /alert %}}

## **ข้อจำกัดสำหรับแบบอักษรสมการคณิตศาสตร์**

กฎการแทนที่แบบอักษรเป็นส่วนหนึ่งของกระบวนการเลือกแบบอักษรมาตรฐานที่ใช้ระหว่างการเรนเดอร์และการแปลง พวกมันทำงานกับข้อความทั่วไปเมื่อ Aspose.Slides สามารถแทนที่แบบอักษรที่เข้าถึงไม่ได้ด้วยแบบอักษรที่กำหนดโดยกฎ

สมการ Office Math มีความต้องการเพิ่มเติม หากสมการใช้ **Cambria Math** Aspose.Slides อาจต้องการแบบอักษรนั้นอย่างแม่นยำเพื่อคำนวณและเรนเดอร์โครงสร้างสมการ กฎที่แทนที่ด้วยแบบอักษรคณิตศาสตร์อื่นเช่น **STIX Two Math** ไม่สามารถแทนที่ **Cambria Math** ได้ และการเรนเดอร์อาจยังรายงานว่าจำเป็นต้องใช้ **Cambria Math**

เพื่อเรนเดอร์หรือแปลงการนำเสนอที่ใช้สมการดังกล่าว ให้ทำให้ **Cambria Math** พร้อมใช้งานกับ Aspose.Slides ติดตั้งในระบบปฏิบัติการหรือโหลดเป็น [แบบอักษรภายนอก](/slides/th/python-java/custom-font/)

ข้อจำกัดนี้ใช้กับการจัดรูปสมการ การแทนที่แบบอักษรที่อธิบายข้างต้นยังคงใช้ได้กับข้อความทั่วไปในงานนำเสนอ

## **FAQ**

**ความแตกต่างระหว่างการแทนที่แบบอักษรและการเปลี่ยนแบบอักษรคืออะไร?**

[Font replacement](/slides/th/python-java/font-replacement/) เปลี่ยนแบบอักษรหนึ่งเป็นอีกแบบหนึ่งทั่วทั้งการนำเสนออย่างตั้งใจ ส่วนการแทนที่แบบอักษรเลือกแบบอักษรสำหรับผลลัพธ์ที่เรนเดอร์เมื่อเงื่อนไขที่กำหนดตรง เช่น เมื่อแบบอักษรต้นฉบับไม่มีอยู่

**กฎการแทนที่จะถูกนำไปใช้เมื่อใด?**

กฎเข้ามามีส่วนร่วมใน [ลำดับการเลือกแบบอักษร](/slides/th/python-java/font-selection-sequence/) ระหว่างการเรนเดอร์และการแปลง ด้วย `WhenInaccessible` กฎจะใช้เฉพาะเมื่อ Aspose.Slides ไม่สามารถเข้าถึงแบบอักษรต้นฉบับได้

**จะเกิดอะไรขึ้นเมื่อแบบอักษรหายและไม่มีการกำหนดกฎการแทนที่?**

Aspose.Slides จะเลือกแบบอักษรที่ใกล้เคียงที่สุดตามกระบวนการเลือกแบบอักษร ผลลัพธ์ขึ้นกับแบบอักษรที่มีในสภาพแวดล้อมเวลารัน

**ฉันสามารถโหลดแบบอักษรภายนอกเพื่อหลีกเลี่ยงการแทนที่ได้หรือไม่?**

ได้ คุณสามารถ [โหลดแบบอักษรภายนอก](/slides/th/python-java/custom-font/) เพื่อให้ Aspose.Slides ใช้ได้ระหว่างการเรนเดอร์และการแปลง

**Aspose แจกจ่ายแบบอักษรพร้อมกับไลบรารีหรือไม่?**

ไม่ คุณต้องรับผิดชอบในการจัดหาแบบอักษรและปฏิบัติตามใบอนุญาตของพวกมัน

**ผลลัพธ์การแทนที่อาจแตกต่างระหว่าง Windows, Linux, และ macOS หรือไม่?**

ใช่ แบบอักษรที่ติดตั้งและตำแหน่งการค้นหาแบบอักษรจะแตกต่างตามระบบปฏิบัติการ ดังนั้นแบบอักษรที่มีในเครื่องหนึ่งอาจต้องการการแทนที่ในเครื่องอื่น

**ฉันจะทำให้การเลือกแบบอักษรสอดคล้องกันในการแปลงแบบชุดได้อย่างไร?**

ใช้ไฟล์และเวอร์ชันแบบอักษรเดียวกันในทุกเครื่องหรือคอนเทนเนอร์ [โหลดแบบอักษรภายนอกที่จำเป็น](/slides/th/python-java/custom-font/) และ [ฝังแบบอักษร](/slides/th/python-java/embedded-font/) หากใบอนุญาตอนุญาต คุณยังสามารถเรียกใช้ [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) ก่อนส่งออกเพื่อระบุการแทนที่ที่ไม่คาดคิด