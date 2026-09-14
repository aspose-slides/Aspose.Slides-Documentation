---
title: ระบุฟอนต์สำรองสำหรับงานนำเสนอใน Python ผ่าน Java
linktitle: ฟอนต์สำรอง
type: docs
weight: 10
url: /th/python-java/create-fallback-font/
keywords:
- ฟอนต์สำรอง
- กฎสำรอง
- ใช้ฟอนต์
- แทนที่ฟอนต์
- ช่วง Unicode
- glyph ที่ขาดหาย
- glyph ที่ถูกต้อง
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เชี่ยวชาญ Aspose.Slides สำหรับ Python ผ่าน Java เพื่อกำหนดฟอนต์สำรองในไฟล์ PPT, PPTX และ ODP, ช่วยให้การแสดงผลข้อความสม่ำเสมอบนอุปกรณ์หรือระบบปฏิบัติการใดก็ได้."
---
## **ภาพรวม**

Aspose.Slides ให้คุณระบุฟอนต์สำรองสำหรับการเรนเดอร์และการส่งออกงานนำเสนอ ฟอนต์สำรองจะถูกใช้เมื่อตัวฟอนต์หลักไม่มี glyph สำหรับอักขระบางตัว

พฤติกรรมการสำรองจะถูกกำหนดผ่านกฎสำรองแต่ละกฎเชื่อมช่วง Unicode กับฟอนต์หนึ่งหรือหลายฟอนต์ที่อาจมี glyph ที่ต้องการ คุณสามารถกำหนดกฎสำหรับช่วงอักขระต่าง ๆ เพิ่มหรือเอาฟอนต์สำรองออกจากกฎที่มีอยู่ และจัดระเบียบหลายกฎในชุดกฎฟอนต์สำรอง

กฎสำรองเป็นการตั้งค่าการเรนเดอร์ในเวลาเรียกใช้งาน ไม่ได้แก้ไขไฟล์งานนำเสนอโดยตรงและไม่ได้ถูกบันทึกภายในไฟล์ PPTX

## **กฎสำรอง**

Aspose.Slides มีคลาส [FontFallBackRule](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontfallbackrule/) เพื่อระบุกฎการใช้ฟอนต์สำรอง คลาสนี้เป็นการเชื่อมโยงระหว่างช่วง Unicode ที่ใช้ค้นหา glyph ที่ขาดหายกับรายการฟอนต์ที่อาจมี glyph ดังกล่าว:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule

start_unicode_index = 0x0B80
end_unicode_index = 0x0BFF

first_rule = FontFallBackRule(start_unicode_index, end_unicode_index, "Vijaya")
second_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

# ใช้หลายวิธีในการระบุรายการฟอนต์.
font_names = jpype.JArray(jpype.JString)(["Segoe UI Emoji, Segoe UI Symbol", "Arial"])

third_rule = FontFallBackRule(0x1F300, 0x1F64F, font_names)
```

คุณสามารถเอาฟอนต์สำรองออกโดยใช้ [remove](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontfallbackrule/#remove) หรือเพิ่มฟอนต์สำรองโดยใช้ [addFallBackFonts](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) ในอ็อบเจ็กต์ [FontFallBackRule](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontfallbackrule/) ที่มีอยู่

[FontFallBackRulesCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontfallbackrulescollection/) สามารถจัดระเบียบรายการของอ็อบเจ็กต์ [FontFallBackRule](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontfallbackrule/) เมื่อคุณต้องการระบุกฎการแทนฟอนต์สำรองสำหรับหลายช่วง Unicode

{{% alert color="info" title="See also" %}} 
- [สร้างคอลเลกชันฟอนต์สำรอง](/slides/th/python-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**ความแตกต่างระหว่างฟอนต์สำรอง, การแทนที่ฟอนต์, และการฝังฟอนต์คืออะไร?**

ฟอนต์สำรองจะถูกใช้เฉพาะกับอักขระที่ไม่มีในฟอนต์หลัก [การแทนที่ฟอนต์](/slides/th/python-java/font-substitution/) จะเปลี่ยนฟอนต์ที่ระบุทั้งหมดเป็นฟอนต์อื่น [การฝังฟอนต์](/slides/th/python-java/embedded-font/) จะบรรจุฟอนต์ไว้ในไฟล์ผลลัพธ์เพื่อให้ผู้รับสามารถดูข้อความได้ตามที่ตั้งใจ

**ฟอนต์สำรองจะถูกนำไปใช้ในการส่งออกเช่น PDF, PNG, หรือ SVG หรือใช้เฉพาะการเรนเดอร์บนหน้าจอเท่านั้น?**

ใช่ ฟอนต์สำรองส่งผลต่อทุก [การเรนเดอร์และการส่งออก](/slides/th/python-java/convert-presentation/) ที่ต้องวาดอักขระแต่ฟอนต์ต้นทางไม่มี

**การกำหนดฟอนต์สำรองจะเปลี่ยนไฟล์งานนำเสนอหรือไม่และการตั้งค่าจะคงอยู่เมื่อเปิดไฟล์ในครั้งต่อไปหรือไม่?**

ไม่ กฎสำรองเป็นการตั้งค่าการเรนเดอร์ตอนรันในโค้ดของคุณ ไม่ได้ถูกเก็บในไฟล์ .pptx และจะไม่ปรากฏใน PowerPoint

**ระบบปฏิบัติการ (Windows/Linux/macOS) และชุดไดเรกทอรีฟอนต์มีผลต่อการเลือกฟอนต์สำรองหรือไม่?**

ใช่ เอนจินจะค้นหาฟอนต์จากโฟลเดอร์ระบบที่มีและจาก [เส้นทางเพิ่มเติม](/slides/th/python-java/custom-font/) ที่คุณระบุ หากฟอนต์ไม่มีอยู่จริง กฎที่อ้างอิงฟอนต์นั้นจะไม่มีผล

**ฟอนต์สำรองทำงานกับ WordArt, SmartArt และแผนภูมิหรือไม่?**

ใช่ เมื่ออ็อบเจ็กต์เหล่านี้มีข้อความ กลไกการแทนที่ glyph เดียวกันจะถูกนำมาใช้เพื่อเรนเดอร์อักขระที่ขาดหาย