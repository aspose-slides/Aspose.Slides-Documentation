---
title: กำหนดค่าการแทนที่แบบอักษรในพรีเซนเทชันโดยใช้ Python ผ่าน Java
linktitle: การแทนที่แบบอักษร
type: docs
weight: 70
url: /th/python-java/font-substitution/
keywords:
- แบบอักษร
- แบบอักษรสำรอง
- การแทนที่แบบอักษร
- เปลี่ยนแบบอักษร
- การเปลี่ยนแบบอักษร
- กฎการแทนที่
- กฎการเปลี่ยน
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- Python
- Java
- Aspose.Slides
description: "กำหนดค่ากฎการแทนที่แบบอักษรและตรวจสอบแบบอักษรที่ถูกแทนที่ใน Aspose.Slides สำหรับ Python ผ่าน Java เมื่อทำการเรนเดอร์หรือแปลงพรีเซนเทชัน PowerPoint และ OpenDocument"
---
## **ภาพรวม**

การแทนที่แบบอักษร (Font substitution) ทำให้ Aspose.Slides สามารถใช้แบบอักษรที่มีอยู่แทนแบบอักษรที่ไม่สามารถเข้าถึงได้เมื่อทำการเรนเดอร์หรือแปลงพรีเซนเทชัน การแทนที่จะส่งผลต่อผลลัพธ์ที่เรนเดอร์เท่านั้น; ไม่ได้เปลี่ยนแบบอักษรที่กำหนดให้กับเนื้อหาในพรีเซนเทชัน  

คุณสามารถกำหนดแบบอักษรที่จะใช้เมื่อแบบอักษรบางตัวไม่พร้อมใช้งานและสามารถตรวจสอบการแทนที่ที่ Aspose.Slides จะทำระหว่างการเรนเดอร์ได้ สิ่งนี้ช่วยให้ผลลัพธ์คงที่ในสภาพแวดล้อมที่มีแบบอักษรติดตั้งแตกต่างกัน  

## **รับการแทนที่แบบอักษร**

ใช้เมธอด [FontsManager.getSubstitutions](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/#getSubstitutions) เพื่อกำหนดว่ามีแบบอักษรใดจะถูกแทนที่เมื่อพรีเซนเทชันถูกเรนเดอร์ เมธอดจะคืนค่าอ็อบเจ็กต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsubstitutioninfo/) ที่ระบุชื่อแบบอักษรต้นฉบับและแบบอักษรที่แทนที่  

ตัวอย่าง Python ด้านล่างนี้แสดงรายการการแทนที่แบบอักษรทั้งหมดสำหรับพรีเซนเทชัน:  

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

ใช้ overload ของ [FontsManager.getSubstitutions](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/#getSubstitutions) พร้อมอาร์กิวเมนต์เป็นอาร์เรย์จำนวนเต็มของ Java เพื่อดูการแทนที่ที่จำเป็นสำหรับการเรนเดอร์สไลด์เฉพาะเท่านั้น ซึ่งมีประโยชน์เมื่อคุณกำลังเรนเดอร์หรือส่งออกส่วนของพรีเซนเทชัน ตรวจสอบพรีเซนเทชันขนาดใหญ่เป็นขั้นเป็นตอน ค้นหาสไลด์ที่พึ่งพาแบบอักษรที่ไม่มีอยู่ เตรียมแพคเกจแบบอักษรขนาดเล็กสำหรับเซิร์ฟเวอร์หรือคอนเทนเนอร์ หรือวินิจฉัยความแตกต่างในการเรนเดอร์โดยไม่ต้องประมวลผลสไลด์ที่ไม่เกี่ยวข้อง  

อาร์เรย์ `slides` มีดัชนีสไลด์เริ่มจากเลขหนึ่ง: `1` ระบุสไลด์แรก ในทางตรงกันข้าม ตัวเข้าถึงคอลเลกชัน [Presentation.getSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSlides) ใช้ดัชนีเริ่มจากศูนย์ ดังนั้นสไลด์เดียวกันจะเข้าถึงด้วย `presentation.getSlides().get_Item(0)` ควรคำนึงถึงความแตกต่างนี้เมื่อสร้างอาร์เรย์เพื่อหลีกเลี่ยงข้อผิดพลาด off-by-one  

เรียก overload ผ่านเมธอด [Presentation.getFontsManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getFontsManager) ซึ่งจะคืนค่าการแทนที่ที่กำหนดระหว่างการเรนเดอร์สไลด์ที่เลือกเท่านั้น ผลลัพธ์แต่ละรายการเป็นอ็อบเจ็กต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsubstitutioninfo/) ที่มีชื่อแบบอักษรต้นฉบับและแบบอักษรที่แทนที่ ผลลัพธ์สะท้อนสภาพแวดล้อมแบบอักษรปัจจุบัน, กฎ fallback ที่กำหนด, กฎการแทนที่ที่เก็บใน [FontSubstRuleCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsubstrulecollection/) และ [externally loaded fonts](/slides/th/python-java/custom-font/)  

การแทนที่เดียวกันอาจต้องการโดยสไลด์ที่เลือกหลายสไลด์ ให้ทำการลบรายการซ้ำเมื่อคุณสร้างรายการแบบอักษรหรือรายงาน preflight ตัวอย่างต่อไปนี้แสดงการรายงานการแทนที่ที่ได้รับทั้งหมดและจากนั้นสร้างรายการเรียงลำดับของการแมปแบบอักษรที่ไม่ซ้ำกัน:  

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

คลาส [FontsManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/) มี overload ทั้งสองให้เลือก ใช้ตามขอบเขตของการดำเนินการเรนเดอร์:  

| โอเวอร์โหลด | ใช้เมื่อ |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/#getSubstitutions) with no arguments | คุณต้องการการแทนที่สำหรับพรีเซนเทชันทั้งหมด. |
| [getSubstitutions](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/#getSubstitutions) with a Java integer array | คุณต้องการการแทนที่สำหรับช่วงที่เลือก, การตรวจสอบแบบเพิ่มขั้น, หรือการส่งออกบางส่วน. |

## **ตั้งกฎการแทนที่แบบอักษร**

เพื่อระบุแบบอักษรที่ Aspose.Slides ควรใช้เมื่อแบบอักษรต้นทางไม่พร้อมใช้งาน:  

1. โหลดพรีเซนเทชัน.  
2. สร้างการกำหนดแบบอักษรสำหรับแบบอักษรต้นทางและแบบอักษรแทนที่.  
3. สร้าง [FontSubstRule](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsubstrule/) พร้อมเงื่อนไข [WhenInaccessible](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible).  
4. เพิ่มกฎลงใน [FontSubstRuleCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsubstrulecollection/).  
5. กำหนดคอลเลกชันโดยใช้เมธอด [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList).  
6. เรนเดอร์หรือแปลงพรีเซนเทชัน.  

ตัวอย่าง Python ด้านล่างนี้แทนที่ `Arial` ด้วย `SomeRareFont` เมื่อ `SomeRareFont` ไม่พร้อมใช้งาน และจากนั้นเรนเดอร์สไลด์แรกเพื่อยืนยันผลลัพธ์ แบบอักษรแทนที่ต้องพร้อมใช้งานสำหรับ Aspose.Slides.  

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
สำหรับการเปลี่ยนแบบอักษรโดยไม่มีเงื่อนไขทั่วทั้งพรีเซนเทชัน, ดูที่ [Font Replacement](/slides/th/python-java/font-replacement/).
{{% /alert %}}

## **ข้อจำกัดสำหรับแบบอักษรสมการคณิตศาสตร์**

กฎการแทนที่แบบอักษรเป็นส่วนหนึ่งของกระบวนการเลือกแบบอักษรมาตฐานที่ใช้ระหว่างการเรนเดอร์และการแปลง ซึ่งทำงานกับข้อความทั่วไปเมื่อ Aspose.Slides สามารถแทนที่แบบอักษรที่ไม่สามารถเข้าถึงได้ด้วยแบบอักษรที่พร้อมใช้งานตามกฎที่กำหนด  

สมการ Office Math มีข้อกำหนดเพิ่มเติม หากสมการใช้แบบอักษร **Cambria Math** Aspose.Slides อาจต้องการแบบอักษรนั้นอย่างตรงไปตรงมาเพื่อคำนวณและเรนเดอร์โครงสร้างสมการ กฎที่แทนที่ด้วยแบบอักษรคณิตศาสตร์อื่น เช่น **STIX Two Math** ไม่สามารถแทนที่ **Cambria Math** เพื่อวัตถุประสงค์นี้ได้ และการเรนเดอร์อาจยังระบุว่าต้องการ **Cambria Math**  

เพื่อเรนเดอร์หรือแปลงพรีเซนเทชันดังกล่าว ให้ทำให้ **Cambria Math** พร้อมใช้งานสำหรับ Aspose.Slides ติดตั้งในระบบปฏิบัติการหรือโหลดเป็น [external font](/slides/th/python-java/custom-font/)  

ข้อจำกัดนี้ใช้กับโครงสร้างสมการเท่านั้น ส่วนกฎการแทนที่ที่อธิบายไว้ข้างต้นยังคงใช้กับข้อความปกติในพรีเซนเทชัน  

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่าง Font Replacement กับ Font Substitution คืออะไร?**  
[Font replacement](/slides/th/python-java/font-replacement/) เปลี่ยนแบบอักษรหนึ่งเป็นอีกแบบหนึ่งโดยเจตนาในทั่วพรีเซนเทชัน ส่วน Font substitution จะเลือกแบบอักษรสำหรับผลลัพธ์ที่เรนเดอร์เมื่อเงื่อนไขที่กำหนดตรง, เช่น เมื่อแบบอักษรต้นฉบับไม่พร้อมใช้งาน.  

**กฎการแทนที่จะถูกนำไปใช้เมื่อใด?**  
กฎเหล่านี้เข้าร่วมใน [font selection sequence](/slides/th/python-java/font-selection-sequence/) ระหว่างการเรนเดอร์และการแปลง หากใช้ `WhenInaccessible` กฎจะถูกใช้เฉพาะเมื่อ Aspose.Slides ไม่สามารถเข้าถึงแบบอักษรต้นทาง.  

**จะเกิดอะไรขึ้นเมื่อแบบอักษรหายและไม่มีการกำหนดกฎการแทนที่?**  
Aspose.Slides จะเลือกแบบอักษรที่ใกล้เคียงที่สุดตามกระบวนการเลือกแบบอักษรของมัน ผลลัพธ์ขึ้นอยู่กับแบบอักษรที่มีอยู่ในสภาพแวดล้อมการทำงาน.  

**ฉันสามารถโหลดแบบอักษรภายนอกเพื่อหลีกเลี่ยงการแทนที่ได้หรือไม่?**  
ได้ คุณสามารถ [load external fonts](/slides/th/python-java/custom-font/) เพื่อให้ Aspose.Slides ใช้ในระหว่างการเรนเดอร์และการแปลง.  

**Aspose มีการแจกจ่ายแบบอักษรมาพร้อมกับไลบรารีหรือไม่?**  
ไม่ คุณต้องรับผิดชอบในการจัดเตรียมแบบอักษรและปฏิบัติตามสัญญาอนุญาตของแบบอักษรเหล่านั้น.  

**ผลลัพธ์การแทนที่อาจแตกต่างกันระหว่าง Windows, Linux และ macOS หรือไม่?**  
ใช่ แบบอักษรที่ติดตั้งและตำแหน่งการค้นหาแบบอักษรจะแตกต่างกันตามระบบปฏิบัติการ ดังนั้นแบบอักษรที่พร้อมใช้งานบนเครื่องหนึ่งอาจต้องการการแทนที่บนเครื่องอื่น.  

**จะทำให้การเลือกแบบอักษรสอดคล้องกันในการแปลงแบบเป็นชุดได้อย่างไร?**  
ใช้ไฟล์แบบอักษรและเวอร์ชันเดียวกันบนทุกเครื่องหรือคอนเทนเนอร์, [load required external fonts](/slides/th/python-java/custom-font/), และ [embed fonts](/slides/th/python-java/embedded-font/) เมื่อได้รับอนุญาตจากสัญญาอนุญาต คุณยังสามารถเรียก [FontsManager.getSubstitutions](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/#getSubstitutions) ก่อนส่งออกเพื่อระบุการแทนที่ที่ไม่คาดคิด.