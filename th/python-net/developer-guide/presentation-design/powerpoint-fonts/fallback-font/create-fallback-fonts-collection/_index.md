---
title: กำหนดค่าคอลเลกชันฟอนท์สำรองใน Python
linktitle: คอลเลกชันฟอนท์สำรอง
type: docs
weight: 20
url: /th/python-net/create-fallback-fonts-collection/
keywords:
- ฟอนท์สำรอง
- กฎฟอนท์สำรอง
- คอลเลกชันฟอนท์
- กำหนดค่าฟอนท์
- ตั้งค่าฟอนท์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ตั้งค่าคอลเลกชันฟอนท์สำรองใน Aspose.Slides สำหรับ Python ผ่าน .NET เพื่อให้ข้อความคงความสอดคล้องและคมชัดในงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณกำหนดคอลเลกชันของกฎฟอนท์สำรองสำหรับงานนำเสนอแต่ละกฎสำรองจะถูกแทนด้วยคลาส `FontFallBackRule` และสามารถเพิ่มเข้าไปใน `FontFallBackRulesCollection`.

หลังจากสร้างคอลเลกชันแล้ว คุณสามารถกำหนดให้กับคุณสมบัติ `font_fall_back_rules_collection` ของ `fonts_manager` ของงานนำเสนอ `fonts_manager` จะควบคุมฟอนท์ทั่วทั้งงานนำเสนอและแต่ละอินสแตนซ์ของ `Presentation` จะมี `FontsManager` ของตัวเอง.

เมื่อ `FontsManager` ถูกเริ่มต้นด้วยคอลเลกชันฟอนท์สำรอง ฟอนท์สำรองที่ระบุจะถูกนำมาใช้ระหว่างการเรนเดอร์งานนำเสนอ.

## **ใช้กฎฟอนท์สำรอง**

อินสแตนซ์ของคลาส [FontFallBackRule](https://reference.aspose.com/slides/th/python-net/aspose.slides/FontFallBackRule/) สามารถจัดระเบียบเป็น [FontFallBackRulesCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontfallbackrulescollection/) ได้ สามารถเพิ่มหรือเอากฎออกจากคอลเลกชันได้.

จากนั้นคอลเลกชันนี้สามารถกำหนดให้กับคุณสมบัติ [font_fall_back_rules_collection](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/) ของคลาส [FontsManager](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/) FontsManager จะควบคุมฟอนท์ทั่วงานนำเสนอ.

แต่ละ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) มีคุณสมบัติ [fonts_manager](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/fonts_manager/) ที่มีอินสแตนซ์ของคลาส FontsManager ของตัวเอง.

ต่อไปนี้เป็นตัวอย่างวิธีสร้างคอลเลกชันกฎฟอนท์สำรองและกำหนดให้กับ FontsManager ของงานนำเสนอหนึ่ง:  

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    userRulesList = slides.FontFallBackRulesCollection()

    userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
    userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

    presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```

หลังจาก FontsManager ถูกเริ่มต้นด้วยคอลเลกชันฟอนท์สำรอง ฟอนท์สำรองจะถูกนำมาใช้ระหว่างการเรนเดอร์งานนำเสนอ.

{{% alert color="primary" %}} 
อ่านเพิ่มเติมเกี่ยวกับวิธี [เรนเดอร์งานนำเสนอด้วยฟอนท์สำรอง](/slides/th/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **คำถามที่พบบ่อย**

**กฎฟอนท์สำรองของฉันจะถูกฝังลงในไฟล์ PPTX และปรากฏใน PowerPoint หลังจากบันทึกหรือไม่?**  
ไม่. กฎฟอนท์สำรองเป็นการตั้งค่าการเรนเดอร์ขณะทำงาน; ไม่ได้ถูกจัดเก็บเป็นส่วนของไฟล์ PPTX และจะไม่ปรากฏในส่วนติดต่อผู้ใช้ของ PowerPoint.

**การใช้ฟอนท์สำรองจะนำไปใช้กับข้อความภายใน SmartArt, WordArt, แผนภูมิ และตารางหรือไม่?**  
ใช่. กลไกการแทนที่ glyph เดียวกันถูกใช้กับข้อความใด ๆ ในวัตถุเหล่านี้.

**Aspose แจกจ่ายฟอนท์ใด ๆ มาพร้อมกับไลบรารีหรือไม่?**  
ไม่. คุณต้องเพิ่มและใช้ฟอนท์ด้วยตนเองและรับผิดชอบต่อการใช้งานนั้น.

**สามารถใช้การแทนที่/การทดแทนฟอนท์ที่หายไปและฟอนท์สำรองสำหรับ glyph ที่หายไปร่วมกันได้หรือไม่?**  
ใช่. พวกเขาเป็นขั้นตอนอิสระของขั้นตอนการแก้ปัญหาฟอนท์เดียวกัน: ก่อนอื่นเอนจินจะตรวจสอบความพร้อมของฟอนท์ ([การแทนที่](/slides/th/python-net/font-replacement/)/[การทดแทน](/slides/th/python-net/font-substitution/)) แล้วฟอนท์สำรองจะเติมช่องว่างสำหรับ glyph ที่หายไปในฟอนท์ที่มีอยู่.