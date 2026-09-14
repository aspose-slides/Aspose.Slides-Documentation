---
title: กำหนดค่าคอลเลกชันฟอนต์สำรองใน Python ผ่าน Java
linktitle: คอลเลกชันฟอนต์สำรอง
type: docs
weight: 20
url: /th/python-java/create-fallback-fonts-collection/
keywords:
- ฟอนต์สำรอง
- กฎฟอนต์สำรอง
- คอลเลกชันฟอนต์
- กำหนดค่าฟอนต์
- ตั้งค่าฟอนต์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ตั้งค่าคอลเลกชันฟอนต์สำรองใน Aspose.Slides สำหรับ Python ผ่าน Java เพื่อให้ข้อความคงความสอดคล้องและคมชัดในงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

Aspose.Slides ให้คุณกำหนดคอลเลกชันของกฎฟอนต์สำรองสำหรับงานนำเสนอ แต่ละกฎฟอนต์สำรองจะถูกแทนด้วยคลาส [FontFallBackRule](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontfallbackrule/) และสามารถเพิ่มไปยัง [FontFallBackRulesCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontfallbackrulescollection/) ได้  

หลังจากสร้างคอลเลกชันแล้ว คุณสามารถกำหนดให้โดยใช้เมธอด [setFontFallBackRulesCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) ของ [FontsManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/) ของงานนำเสนอ [FontsManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/) ควบคุมฟอนต์ทั่วทั้งงานนำเสนอ และแต่ละอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) จะมี [FontsManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/) ของตนเอง  

เมื่อ [FontsManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/) ถูกกำหนดค่าเริ่มต้นด้วยคอลเลกชันฟอนต์สำรอง ฟอนต์สำรองที่ระบุจะถูกนำไปใช้ระหว่างการเรนเดอร์งานนำเสนอ  

## **ใช้กฎฟอนต์สำรอง**

อินสแตนซ์ของคลาส [FontFallBackRule](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontfallbackrule/) สามารถจัดระเบียบเป็น [FontFallBackRulesCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontfallbackrulescollection/) ได้ คุณสามารถเพิ่มหรือเอากฎออกจากคอลเลกชัน  

คอลเลกชันนี้สามารถกำหนดให้โดยใช้เมธอด [setFontFallBackRulesCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) ของคลาส [FontsManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/) ซึ่งควบคุมฟอนต์ทั่วทั้งงานนำเสนอ  

แต่ละ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) มีเมธอด [getFontsManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getFontsManager) ที่ส่งคืนอินสแตนซ์ของคลาส [FontsManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/) ของตนเอง  

ตัวอย่างต่อไปนี้แสดงวิธีสร้างคอลเลกชันกฎฟอนต์สำรองและกำหนดให้กับ [FontsManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/) ของงานนำเสนอ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, Presentation

presentation = Presentation()
try:
    fallback_rules = FontFallBackRulesCollection()

    tamil_rule = FontFallBackRule(0x0B80, 0x0BFF, "Vijaya")
    fallback_rules.add(tamil_rule)
    hiragana_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")
    fallback_rules.add(hiragana_rule)

    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)
finally:
    presentation.dispose()
```

หลังจากที่ [FontsManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/) ถูกกำหนดค่าเริ่มต้นด้วยคอลเลกชันฟอนต์สำรอง ฟอนต์สำรองจะถูกนำไปใช้ระหว่างการเรนเดอร์งานนำเสนอ  

{{% alert color="info" title="Note" %}}
อ่านเพิ่มเติมเกี่ยวกับวิธีการ [เรนเดอร์การนำเสนอด้วยฟอนต์สำรอง](/slides/th/python-java/render-presentation-with-fallback-font/) .
{{% /alert %}}

## **คำถามที่พบบ่อย**

**กฎฟอนต์สำรองของฉันจะถูกฝังลงในไฟล์ PPTX และมองเห็นใน PowerPoint หลังจากบันทึกหรือไม่?**

ไม่ กฎฟอนต์สำรองเป็นการตั้งค่าการเรนเดอร์ขณะทำงาน; ไม่ได้ถูกจัดเก็บเป็นส่วนหนึ่งของไฟล์ PPTX และจะไม่ปรากฏใน UI ของ PowerPoint  

**กฎสำรองจะนำไปใช้กับข้อความภายใน SmartArt, WordArt, แผนภูมิ และตารางหรือไม่?**

ใช่ กลไกการแทนที่ glyph เดียวกันจะถูกใช้กับข้อความใด ๆ ในวัตถุเหล่านี้  

**Aspose มีฟอนต์ใด ๆ มาพร้อมกับไลบรารีหรือไม่?**

ไม่ คุณต้องเพิ่มและใช้งานฟอนต์ด้วยตนเองและรับผิดชอบเอง  

**สามารถใช้การทดแทน/การเปลี่ยนฟอนต์สำหรับฟอนต์ที่หายไปและการสำรองสำหรับ glyph ที่หายไปร่วมกันได้หรือไม่?**

ใช่ ทั้งสองเป็นขั้นตอนอิสระของกระบวนการแก้ไขฟอนต์เดียวกัน: ขั้นแรกเอ็นจิ้นจะตรวจสอบความพร้อมของฟอนต์ ([การทดแทน](/slides/th/python-java/font-replacement/)/[การเปลี่ยน](/slides/th/python-java/font-substitution/)) จากนั้นการสำรองจะเติมเต็มช่องว่างของ glyph ที่หายไปในฟอนต์ที่มีอยู่.