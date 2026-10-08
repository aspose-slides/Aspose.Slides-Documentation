---
title: กำหนดค่าการแทนที่แบบอักษรในงานนำเสนอด้วย Python
linktitle: การแทนที่แบบอักษร
type: docs
weight: 70
url: /th/python-net/font-substitution/
keywords:
- แบบอักษร
- แบบอักษรทดแทน
- การแทนที่แบบอักษร
- แทนที่แบบอักษร
- การเปลี่ยนแบบอักษร
- กฎการแทนที่
- กฎการเปลี่ยน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "กำหนดค่ากฎการแทนที่แบบอักษรและตรวจสอบแบบอักษรที่ถูกแทนที่ใน Aspose.Slides สำหรับ Python ผ่าน .NET เมื่อต้องเรนเดอร์หรือแปลงงานนำเสนอ PowerPoint และ OpenDocument."
---
## **ภาพรวม**

การแทนที่แบบอักษรช่วยให้ Aspose.Slides ใช้แบบอักษรที่มีอยู่แทนแบบอักษรที่ไม่สามารถเข้าถึงได้เมื่อนำเสนอถูกเรนเดอร์หรือแปลง การแทนที่จะส่งผลต่อผลลัพธ์ที่เรนเดอร์เท่านั้น; มันไม่ได้เปลี่ยนแบบอักษรที่กำหนดให้กับเนื้อหาในงานนำเสนอ

คุณสามารถกำหนดแบบอักษรที่จะใช้เมื่อแบบอักษรเฉพาะไม่พร้อมใช้งานได้ และคุณสามารถตรวจสอบการแทนที่ที่ Aspose.Slides จะทำขณะเรนเดอร์ นี้ช่วยให้ผลลัพธ์สอดคล้องกันในสภาพแวดล้อมที่มีแบบอักษรติดตั้งต่างกัน

หากแบบอักษรพร้อมใช้งานแต่ไม่มีรูปแบบหนาแยกเฉพาะ โปรดดูที่ [จัดการแบบอักษรที่ไม่มีรูปแบบหนาแยกเฉพาะ](/slides/th/python-net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) ส่วนนี้อธิบายวิธีเรสเตอร์ไอซ์ข้อความที่ได้รับผลกระทบระหว่างการส่งออกเป็น PDF และผลที่ตามมาสำหรับการเลือกข้อความ การค้นหา และการสเกล

## **รับการแทนที่แบบอักษร**

ใช้เมธอด [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) เพื่อกำหนดว่าบางแบบอักษรจะถูกแทนที่เมื่อการนำเสนอถูกเรนเดอร์หรือไม่ เมธอดจะคืนค่าอ็อบเจกต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) ที่ระบุชื่อแบบอักษรต้นฉบับและแบบอักษรที่แทนที่

ตัวอย่าง Python ด้านล่างแสดงรายการการแทนที่แบบอักษรทั้งหมดสำหรับงานนำเสนอ:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **รับการแทนที่แบบอักษรสำหรับสไลด์ที่เลือก**

ใช้ [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) พร้อมรายการดัชนีสไลด์เพื่อพิจารณาการแทนที่ที่จำเป็นสำหรับการเรนเดอร์สไลด์เฉพาะเท่านั้น สิ่งนี้มีประโยชน์เมื่อคุณกำลังเรนเดอร์หรือส่งออกส่วนของงานนำเสนอ ตรวจสอบงานนำเสนอขนาดใหญ่แบบเพิ่มขั้น ตรวจหาสไลด์ที่พึ่งพาแบบอักษรที่ไม่มีอยู่ เตรียมชุดแบบอักษรขั้นต่ำสำหรับเซิร์ฟเวอร์หรือคอนเทนเนอร์ หรือวินิจฉัยความแตกต่างของการเรนเดอร์โดยไม่ต้องประมวลผลสไลด์ที่ไม่เกี่ยวข้อง

รายการประกอบด้วยดัชนีสไลด์ที่เริ่มจาก 1: `1` ระบุสไลด์แรก ในขณะเดียวกันคอลเลกชัน [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) ใช้ดัชนีเริ่มจาก 0 ดังนั้นสไลด์เดียวกันจะเข้าถึงได้ด้วย `presentation.slides[0]` ควรคำนึงถึงความแตกต่างนี้เมื่อตั้งค่ารายการเพื่อหลีกเลี่ยงข้อผิดพลาด off‑by‑one

เรียกเมธอดผ่านคุณสมบัติ [Presentation.fonts_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/) มันจะคืนค่าการแทนที่ที่กำหนดขณะเรนเดอร์สไลด์ที่เลือกเท่านั้น แต่ละผลลัพธ์เป็นอ็อบเจกต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) ที่มีชื่อแบบอักษรต้นฉบับและแบบอักษรที่แทนที่ ผลลัพธ์สะท้อนสภาพแวดล้อมแบบอักษรปัจจุบัน กฎ fallback ที่กำหนดไว้ กฎการแทนที่ที่จัดเก็บใน [IFontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontsubstrulecollection/) และ [แบบอักษรที่โหลดจากภายนอก](/slides/th/python-net/custom-font/)

การแทนที่เดียวกันอาจจำเป็นสำหรับสไลด์ที่เลือกหลายสไลด์ ให้ทำการกำจัดรายการซ้ำเมื่อคุณสร้างรายการทรัพยากรแบบอักษรหรือรายงาน preflight ตัวอย่างต่อไปนี้รายงานการแทนที่ที่คืนค่าแต่ละรายการแล้วสร้างรายการแบบอักษรแผนที่ที่เป็นเอกลักษณ์เรียงลำดับ:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    selected_slides = [1, 3, 5]
    substitutions = list(presentation.fonts_manager.get_substitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")

    preflight_entries = [f"{substitution.original_font_name} -> {substitution.substituted_font_name}" for substitution in substitutions]
    unique_preflight_entries = {entry.casefold(): entry for entry in preflight_entries}
    sorted_preflight_entries = sorted(unique_preflight_entries.values(), key=str.casefold)

    print("Deduplicated font preflight report:")
    for entry in sorted_preflight_entries:
        print(entry)
```

คลาส [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) ให้บริการเมธอดทั้งสองรูปแบบ เลือกหนึ่งตามขอบเขตของการดำเนินการเรนเดอร์:

| วิธีเรียก | ใช้เมื่อ |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) โดยไม่มีอาร์กิวเมนต์ | คุณต้องการการแทนที่สำหรับงานนำเสนอทั้งหมด |
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) พร้อมรายการดัชนีสไลด์ | คุณต้องการการแทนที่สำหรับช่วงที่เลือก การตรวจสอบแบบเพิ่มขั้น หรือการส่งออกบางส่วน |

## **ตั้งค่ากฎการแทนที่แบบอักษร**

เพื่อระบุแบบอักษรที่ Aspose.Slides ควรใช้เมื่อแบบอักษรต้นฉบับไม่พร้อมใช้งาน:

1. โหลดงานนำเสนอ
2. สร้างการกำหนดแบบอักษรสำหรับแบบอักษรต้นฉบับและแบบอักษรแทนที่
3. สร้างอ็อบเจกต์ [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/) พร้อมเงื่อนไข [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstcondition/)
4. เพิ่มกฎลงใน [FontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrulecollection/)
5. กำหนดคอลเลกชันให้กับคุณสมบัติ [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/font_subst_rule_list/)
6. เรนเดอร์หรือแปลงงานนำเสนอ

ตัวอย่าง Python ด้านล่างแทนที่ `Arial` ด้วย `SomeRareFont` เมื่อ `SomeRareFont` ไม่พร้อมใช้งานแล้วเรนเดอร์สไลด์แรกเพื่อยืนยันผลลัพธ์ แบบอักษรแทนที่ต้องพร้อมใช้งานสำหรับ Aspose.Slides

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    source_font = slides.FontData("SomeRareFont")
    substitute_font = slides.FontData("Arial")
    substitution_rule = slides.FontSubstRule(source_font, substitute_font, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    substitution_rules = slides.FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.fonts_manager.font_subst_rule_list = substitution_rules

    with presentation.slides[0].get_image(1, 1) as image:
        image.save("slide.jpg", slides.ImageFormat.JPEG)
```

{{% alert color="info" title="หมายเหตุ" %}}
สำหรับการเปลี่ยนแบบอักษรทั่วงานนำเสนอโดยไม่มีเงื่อนไข โปรดดูที่ [การเปลี่ยนแบบอักษร](/slides/th/python-net/font-replacement/) 
{{% /alert %}}

## **ข้อจำกัดสำหรับแบบอักษรสมการคณิตศาสตร์**

กฎการแทนที่แบบอักษรเป็นส่วนหนึ่งของกระบวนการเลือกแบบอักษรมาตรฐานที่ใช้ขณะเรนเดอร์และแปลง พวกมันทำงานกับข้อความทั่วไปเมื่อ Aspose.Slides สามารถแทนที่แบบอักษรที่ไม่สามารถเข้าถึงได้ด้วยแบบอักษรที่ระบุในกฎ

สมการ Office Math มีความต้องการพิเศษ หากสมการใช้ **Cambria Math** Aspose.Slides อาจจำเป็นต้องใช้แบบอักษรนั้นโดยตรงเพื่อคำนวณและเรนเดอร์โครงร่างสมการ กฎที่แทนที่ด้วยแบบอักษรคณิตศาสตร์อื่น เช่น **STIX Two Math** ไม่สามารถแทนที่ **Cambria Math** สำหรับวัตถุประสงค์นี้ได้ และการเรนเดอร์อาจยังรายงานว่า **Cambria Math** จำเป็น

เพื่อเรนเดอร์หรือแปลงงานนำเสนอที่มีสมการเช่นนี้ ให้ทำให้ **Cambria Math** พร้อมใช้งานสำหรับ Aspose.Slides ติดตั้งในระบบปฏิบัติการหรือโหลดเป็น [แบบอักษรภายนอก](/slides/th/python-net/custom-font/)

ข้อจำกัดนี้ใช้กับการจัดรูปสมการเท่านั้น กฎการแทนที่ที่กล่าวถึงข้างต้นยังคงใช้กับข้อความทั่วไปในงานนำเสนอ

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างการเปลี่ยนแบบอักษรและการแทนที่แบบอักษรคืออะไร?**

[การเปลี่ยนแบบอักษร](/slides/th/python-net/font-replacement/) เปลี่ยนแบบอักษรหนึ่งเป็นอีกแบบหนึ่งทั่วงานนำเสนออย่างตั้งใจ การแทนที่แบบอักษรเลือกแบบอักษรสำหรับผลลัพธ์ที่เรนเดอร์เมื่อเงื่อนไขที่กำหนดตรงตามที่ตั้งค่าไว้ เช่น เมื่อแบบอักษรต้นฉบับไม่มีอยู่

**กฎการแทนที่จะถูกนำไปใช้เมื่อใด?**

กฎเข้าร่วมใน [ลำดับการเลือกแบบอักษร](/slides/th/python-net/font-selection-sequence/) ระหว่างการเรนเดอร์และแปลง ด้วย `WHEN_INACCESSIBLE` กฎจะใช้เฉพาะเมื่อ Aspose.Slides ไม่สามารถเข้าถึงแบบอักษรต้นฉบับได้

**จะเกิดอะไรขึ้นเมื่อแบบอักษรขาดหายและไม่มีการกำหนดกฎการแทนที่?**

Aspose.Slides จะเลือกแบบอักษรที่ใกล้เคียงที่สุดที่มีอยู่ตามกระบวนการเลือกแบบอักษรของมัน ผลลัพธ์ขึ้นอยู่กับแบบอักษรที่มีในสภาพแวดล้อมการทำงาน

**ฉันสามารถโหลดแบบอักษรภายนอกเพื่อหลีกเลี่ยงการแทนที่ได้หรือไม่?**

ได้ คุณสามารถ [โหลดแบบอักษรภายนอก](/slides/th/python-net/custom-font/) เพื่อให้ Aspose.Slides ใช้ได้ระหว่างการเรนเดอร์และแปลง

**Aspose แจกจ่ายแบบอักษรมาพร้อมกับไลบรารีหรือไม่?**

ไม่ คุณต้องรับผิดชอบในการจัดหาแบบอักษรและปฏิบัติตามเงื่อนไขการอนุญาตของแต่ละแบบอักษร

**ผลลัพธ์การแทนที่อาจแตกต่างระหว่าง Windows, Linux, และ macOS หรือไม่?**

ใช่ ฟอนท์ที่ติดตั้งและตำแหน่งการค้นหาแบบอักษรแตกต่างกันตามระบบปฏิบัติการ ดังนั้นแบบอักษรที่พร้อมใช้งานในเครื่องหนึ่งอาจต้องแทนที่ในเครื่องอื่น

**ฉันจะทำให้การเลือกแบบอักษรสม่ำเสมอในการแปลงแบบกลุ่มได้อย่างไร?**

ใช้ไฟล์แบบอักษรและเวอร์ชันเดียวกันบนทุกเครื่องหรือคอนเทนเนอร์ [โหลดแบบอักษรภายนอกที่จำเป็น](/slides/th/python-net/custom-font/) และ [ฝังแบบอักษร](/slides/th/python-net/embedded-font/) เมื่อใบอนุญาตอนุญาต คุณยังสามารถเรียกใช้ [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) ก่อนการส่งออกเพื่อระบุการแทนที่ที่ไม่คาดคิด