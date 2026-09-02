---
title: กำหนดการแทนที่ฟอนต์ในงานนำเสนอด้วย Python
linktitle: การแทนที่ฟอนต์
type: docs
weight: 70
url: /th/python-net/font-substitution/
keywords:
- ฟอนต์
- ฟอนต์ทดแทน
- การแทนที่ฟอนต์
- เปลี่ยนฟอนต์
- การเปลี่ยนฟอนต์
- กฎการแทนที่
- กฎการเปลี่ยน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "กำหนดกฎการแทนที่ฟอนต์และตรวจสอบฟอนต์ที่ถูกแทนที่ใน Aspose.Slides สำหรับ Python ผ่าน .NET เมื่อทำการเรนเดอร์หรือแปลงงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

การแทนที่ฟอนต์ช่วยให้ Aspose.Slides ใช้ฟอนต์ที่มีอยู่แทนฟอนต์ที่ไม่สามารถเข้าถึงได้เมื่อทำการเรนเดอร์หรือแปลงงานนำเสนอ การแทนที่จะส่งผลต่อผลลัพธ์ที่ถูกแสดงออก; ไม่ได้เปลี่ยนฟอนต์ที่กำหนดให้กับเนื้อหาของงานนำเสนอ

คุณสามารถกำหนดฟอนต์ที่จะใช้เมื่อฟอนต์บางตัวไม่มีอยู่ และคุณสามารถตรวจสอบการแทนที่ที่ Aspose.Slides จะทำระหว่างการเรนเดอร์ ซึ่งช่วยให้ผลลัพธ์คงที่ในสภาพแวดล้อมที่มีฟอนต์ติดตั้งต่างกัน

## **รับการแทนที่ฟอนต์**

ใช้เมธอด [FontsManager.get_substitutions](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/get_substitutions/) เพื่อระบุว่าฟอนต์ใดบ้างจะถูกแทนที่เมื่อทำการเรนเดอร์งานนำเสนอ เมธอดจะคืนค่าอ็อบเจ็กต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsubstitutioninfo/) ที่บ่งบอกชื่อฟอนต์ต้นฉบับและฟอนต์ที่แทนที่

ตัวอย่าง Python ต่อไปนี้แสดงรายการการแทนที่ฟอนต์ทั้งหมดสำหรับงานนำเสนอ:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **รับการแทนที่ฟอนต์สำหรับสไลด์ที่เลือก**

ใช้ [FontsManager.get_substitutions](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/get_substitutions/) พร้อมรายชื่อดัชนีสไลด์เพื่อดูการแทนที่ที่จำเป็นสำหรับการเรนเดอร์สไลด์เฉพาะส่วน ซึ่งเป็นประโยชน์เมื่อคุณกำลังเรนเดอร์หรือส่งออกบางส่วนของงานนำเสนอ, ตรวจสอบงานนำเสนอขนาดใหญ่เป็นขั้นเป็นตอน, ค้นหาสไลด์ที่พึ่งพาฟอนต์ที่ไม่มีอยู่, เตรียมชุดฟอนต์ขนาดเล็กสำหรับเซิร์ฟเวอร์หรือคอนเทนเนอร์, หรือวินิจฉัยความแตกต่างของการเรนเดอร์โดยไม่ต้องประมวลผลสไลด์ที่ไม่เกี่ยวข้อง

รายการนี้ประกอบด้วยดัชนีสไลด์แบบหนึ่ง‑ฐาน: `1` ระบุสไลด์แรก ในขณะที่คอลเลกชัน [Presentation.slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/slides/th/) ใช้ศูนย์‑ฐาน ดังนั้นสไลด์เดียวกันจะเข้าถึงได้ด้วย `presentation.slides[0]` ควรคำนึงถึงความแตกต่างนี้เมื่อลิสต์ดัชนีเพื่อหลีกเลี่ยงข้อผิดพลาดลำดับหนึ่ง

เรียกเมธอดผ่านคุณสมบัติ [Presentation.fonts_manager](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/fonts_manager/) จะคืนค่าเฉพาะการแทนที่ที่กำหนดขณะเรนเดอร์สไลด์ที่เลือก แต่ละผลลัพธ์เป็นอ็อบเจ็กต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsubstitutioninfo/) ที่บรรจุชื่อฟอนต์ต้นฉบับและฟอนต์ที่แทนที่ ผลลัพธ์สะท้อนสภาพแวดล้อมฟอนต์ปัจจุบัน, กฎ fallback ที่กำหนด, กฎการแทนที่ที่เก็บไว้ใน [IFontSubstRuleCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/ifontsubstrulecollection/), และ [ฟอนต์ที่โหลดจากภายนอก](/slides/th/python-net/custom-font/)

การแทนที่เดียวกันอาจจำเป็นสำหรับสไลด์ที่เลือกหลายสไลด์ ให้ลบรายการซ้ำเมื่อคุณสร้างรายการสินค้าฟอนต์หรือรายงาน preflight ตัวอย่างต่อไปนี้รายงานการแทนที่ทุกรายการที่คืนค่าแล้วสร้างรายการที่เรียงลำดับของการแมปฟอนต์ที่ไม่ซ้ำ:

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

คลาส [FontsManager](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/) มีเมธอดในรูปแบบทั้งสอง ให้เลือกใช้ตามขอบเขตของการเรนเดอร์:

| การเรียกใช้เมธอด | ใช้เมื่อ |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/get_substitutions/) โดยไม่มีอาร์กิวเมนต์ | คุณต้องการการแทนที่สำหรับงานนำเสนอทั้งหมด |
| [get_substitutions](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/get_substitutions/) พร้อมรายการดัชนีสไลด์ | คุณต้องการการแทนที่สำหรับช่วงที่เลือก, การตรวจสอบแบบขั้นเป็นขั้น, หรือการส่งออกบางส่วน |

## **กำหนดกฎการแทนที่ฟอนต์**

เพื่อตั้งค่าฟอนต์ที่ Aspose.Slides ควรใช้เมื่อฟอนต์ต้นทางไม่มีอยู่:

1. โหลดงานนำเสนอ
2. สร้างคำจำกัดความฟอนต์สำหรับฟอนต์ต้นทางและฟอนต์ทดแทน
3. สร้างอ็อบเจ็กต์ [FontSubstRule](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsubstrule/) พร้อมเงื่อนไข [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsubstcondition/)
4. เพิ่มกฎลงใน [FontSubstRuleCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsubstrulecollection/)
5. กำหนดคอลเลกชันให้กับคุณสมบัติ [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/font_subst_rule_list/)
6. เรนเดอร์หรือแปลงงานนำเสนอ

ตัวอย่าง Python ต่อไปนี้แทนที่ `Arial` ด้วย `SomeRareFont` เมื่อ `SomeRareFont` ไม่มีอยู่ แล้วเรนเดอร์สไลด์แรกเพื่อยืนยันผลลัพธ์ ฟอนต์ทดแทนจะต้องมีอยู่สำหรับ Aspose.Slides

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

{{% alert color="info" title="Note" %}}
สำหรับการเปลี่ยนแปลงฟอนต์โดยไม่มีเงื่อนไขทั่วทั้งงานนำเสนอ ดูที่ [Font Replacement](/slides/th/python-net/font-replacement/)
{{% /alert %}}

## **ข้อจำกัดสำหรับฟอนต์สมการคณิตศาสตร์**

กฎการแทนที่ฟอนต์เป็นส่วนหนึ่งของกระบวนการเลือกฟอนต์มาตรฐานที่ใช้ระหว่างการเรนเดอร์และการแปลง มันทำงานกับข้อความทั่วไปเมื่อ Aspose.Slides สามารถแทนที่ฟอนต์ที่เข้าถึงไม่ได้ด้วยฟอนต์ที่กำหนดโดยกฎ

สมการ Office Math มีข้อกำหนดพิเศษ หากสมการใช้ **Cambria Math** Aspose.Slides อาจต้องการฟอนต์นั้นอย่างแม่นยำเพื่อคำนวณและเรนเดอร์เค้าโครงสมการ กฎที่แทนที่ด้วยฟอนต์คณิตศาสตร์อื่น เช่น **STIX Two Math** ไม่สามารถแทนที่ **Cambria Math** ในกรณีนี้ได้ และการเรนเดอร์อาจยังระบุว่าต้องการ **Cambria Math**

เพื่อเรนเดอร์หรือแปลงงานนำเสนอเช่นนี้ ให้ทำให้ **Cambria Math** มีพร้อมใช้งานสำหรับ Aspose.Slides ติดตั้งในระบบปฏิบัติการหรือโหลดเป็น [ฟอนต์ภายนอก](/slides/th/python-net/custom-font/)

ข้อจำกัดนี้ใช้กับการจัดวางสมการเท่านั้น กฎการแทนที่ที่กล่าวมาข้างต้นยังคงใช้กับข้อความทั่วไปของงานนำเสนอ

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างการแทนที่ฟอนต์และการเปลี่ยนฟอนต์คืออะไร?**

[Font replacement](/slides/th/python-net/font-replacement/) เปลี่ยนฟอนต์หนึ่งเป็นฟอนต์อื่นทั่วทั้งงานนำเสนอโดยตั้งใจ ส่วนการแทนที่ฟอนต์จะเลือกฟอนต์สำหรับผลลัพธ์ที่เรนเดอร์เมื่อเงื่อนไขที่กำหนดเป็นจริง เช่น ฟอนต์ต้นฉบับไม่มีอยู่

**กฎการแทนที่จะถูกใช้เมื่อใด?**

กฎเข้าร่วมใน [ขั้นตอนการเลือกฟอนต์](/slides/th/python-net/font-selection-sequence/) ระหว่างการเรนเดอร์และการแปลง เมื่อตั้งค่า `WHEN_INACCESSIBLE` กฎจะใช้เฉพาะเมื่อ Aspose.Slides ไม่สามารถเข้าถึงฟอนต์ต้นทาง

**จะเกิดอะไรขึ้นเมื่อฟอนต์หายไปและไม่มีการกำหนดกฎการแทนที่?**

Aspose.Slides จะเลือกฟอนต์ที่ใกล้เคียงที่สุดตามกระบวนการเลือกฟอนต์ ผลลัพธ์ขึ้นอยู่กับฟอนต์ที่มีในสภาพแวดล้อมรันไทม์

**ฉันสามารถโหลดฟอนต์ภายนอกเพื่อหลีกเลี่ยงการแทนที่ได้ไหม?**

ได้ คุณสามารถ [โหลดฟอนต์ภายนอก](/slides/th/python-net/custom-font/) เพื่อให้ Aspose.Slides ใช้ในระหว่างการเรนเดอร์และการแปลง

**Aspose แจกจ่ายฟอนต์มาพร้อมไลบรารีหรือไม่?**

ไม่ คุณต้องเป็นผู้จัดหาฟอนต์และปฏิบัติตามเงื่อนไขของไลเซนส์ฟอนต์

**ผลลัพธ์การแทนที่อาจแตกต่างระหว่าง Windows, Linux, และ macOS หรือไม่?**

ใช่ ฟอนต์ที่ติดตั้งและตำแหน่งการค้นหาฟอนต์ต่างกันตามระบบปฏิบัติการ ดังนั้นฟอนต์ที่มีบนเครื่องหนึ่งอาจต้องการการแทนที่บนเครื่องอื่น

**ฉันจะทำให้การเลือกฟอนต์สอดคล้องกันในการแปลงแบบกลุ่มอย่างไร?**

ใช้ไฟล์ฟอนต์และเวอร์ชันเดียวกันบนทุกเครื่องหรือคอนเทนเนอร์, [โหลดฟอนต์ภายนอกที่จำเป็น](/slides/th/python-net/custom-font/), และ [ฝังฟอนต์](/slides/th/python-net/embedded-font/) เมื่อไลเซนส์อนุญาต คุณยังสามารถเรียก [FontsManager.get_substitutions](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/get_substitutions/) ก่อนการส่งออกเพื่อระบุการแทนที่ที่ไม่คาดคิด