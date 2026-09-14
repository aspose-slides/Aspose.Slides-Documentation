---
title: เรนเดอร์งานนำเสนอด้วยฟอนต์สำรองใน Python ผ่าน Java
linktitle: เรนเดอร์งานนำเสนอ
type: docs
weight: 30
url: /th/python-java/render-presentation-with-fallback-font/
keywords:
- ฟอนต์สำรอง
- เรนเดอร์ PowerPoint
- เรนเดอร์งานนำเสนอ
- เรนเดอร์สไลด์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรนเดอร์งานนำเสนอด้วยฟอนต์สำรองใน Aspose.Slides สำหรับ Python ผ่าน Java – ทำให้ข้อความสอดคล้องกันใน PPT, PPTX, และ ODP ด้วยตัวอย่างโค้ด Python ทีละขั้นตอน."
---
## **ภาพรวม**

Aspose.Slides ให้คุณเรนเดอร์งานนำเสนอโดยใช้กฎฟอนต์สำรอง บทความนี้แสดงวิธีสร้างคอลเลกชันกฎฟอนต์สำรอง, ปรับเปลี่ยนกฎโดยการลบหรือเพิ่มฟอนต์สำรอง, และกำหนดคอลเลกชันโดยใช้เมธอด [FontsManager.setFontFallBackRulesCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection)。

เมื่อคอลเลกชันกฎฟอนต์สำรองถูกกำหนดให้กับ [FontsManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/) ของงานนำเสนอ, กฎเหล่านั้นจะถูกนำไปใช้ระหว่างการดำเนินการต่าง ๆ เช่น การบันทึก, การเรนเดอร์, และการแปลงงานนำเสนอ ตัวอย่างนี้แสดงวิธีใช้กฎที่กำหนดไว้เมื่อเรนเดอร์รูปย่อของสไลด์และบันทึกเป็นภาพ JPEG

## **เรนเดอร์สไลด์โดยใช้กฎฟอนต์สำรอง**

ตัวอย่างต่อไปนี้ประกอบด้วยขั้นตอนดังนี้：

1. [สร้างคอลเลกชันกฎฟอนต์สำรอง](/slides/th/python-java/create-fallback-fonts-collection/)。
2. [ลบ](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontfallbackrule/#remove) ฟอนต์สำรองจากกฎหนึ่งและ [เพิ่มฟอนต์สำรอง]((https://reference.aspose.com/slides/th/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) ไปยังกฎอีกอันหนึ่ง。
3. กำหนดคอลเลกชันกฎโดยใช้ [setFontFallBackRulesCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) บน FontManager ที่ได้จาก [getFontsManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getFontsManager)。
4. ใช้เมธอด [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) เพื่อบันทึกงานนำเสนอในรูปแบบเดียวกันหรือรูปแบบอื่น หลังจากที่คอลเลกชันกฎฟอนต์สำรองถูกกำหนดให้กับ [FontsManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/), กฎเหล่านี้จะถูกนำไปใช้ระหว่างการดำเนินการบนงานนำเสนอ: การบันทึก, การเรนเดอร์, การแปลง เป็นต้น

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, ImageFormat, Presentation

# สร้างคอลเลกชันกฎใหม่.
fallback_rules = FontFallBackRulesCollection()

# สร้างกฎหลายรายการ.
cyrillic_rule = FontFallBackRule(0x400, 0x4FF, "Times New Roman")
fallback_rules.add(cyrillic_rule)
arabic_rule = FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial")
fallback_rules.add(arabic_rule)

for fallback_rule in fallback_rules:
    # พยายามลบฟอนต์สำรอง "Tahoma" ออกจากกฎ.
    fallback_rule.remove("Tahoma")

    # ปรับปรุงกฎสำหรับช่วงที่ระบุ.
    if fallback_rule.getRangeEndIndex() >= 0x400 and fallback_rule.getRangeStartIndex() < 0x500:
        fallback_rule.addFallBackFonts("Verdana")

# ลบกฎที่มีอยู่, รักษาอย่างน้อยหนึ่งกฎสำหรับการเรนเดอร์.
if fallback_rules.size() > 1:
    rule_to_remove = fallback_rules.get_Item(1)
    fallback_rules.remove(rule_to_remove)

presentation = Presentation("input.pptx")
try:
    # กำหนดคอลเลกชันกฎที่เตรียมไว้.
    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)

    # เรนเดอร์รูปย่อโดยใช้คอลเลกชันกฎที่กำหนดค่าไว้.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # บันทึกภาพลงดิสก์ในรูปแบบ JPEG.
        slide_image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
อ่านเพิ่มเติมเกี่ยวกับวิธีการ [แปลง PPT และ PPTX เป็น JPG ใน Python ผ่าน Java](/slides/th/python-java/convert-powerpoint-to-jpg/)。
{{% /alert %}}