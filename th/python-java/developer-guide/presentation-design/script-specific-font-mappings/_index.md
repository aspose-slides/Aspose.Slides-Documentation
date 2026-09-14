---
title: จัดการฟอนต์ธีมแบบเจาะจงสคริปต์ใน Python ผ่าน Java
linktitle: ฟอนต์ธีมแบบเจาะจงสคริปต์
type: docs
weight: 15
url: /th/python-java/script-specific-font-mappings/
keywords:
- ฟอนต์ตามสคริปต์
- การแมพฟอนต์ธีม
- การนำเสนอหลายภาษา
- ระบบการเขียน
- ฟอนต์ไซริลลิก
- ฟอนต์อาหรับ
- ฟอนต์ญี่ปุ่น
- ฟอนต์จอร์เจีย
- ฟอนต์ธานา
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ตรวจสอบ, เพิ่ม, แทนที่และลบการแมพฟอนต์ตามสคริปต์ในธีม PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ภาพรวม**

ธีมการนำเสนอสามารถเลือกตระกูลฟอนต์ที่แตกต่างกันสำหรับระบบการเขียนที่แตกต่างกันได้ สิ่งนี้ทำให้ข้อความหลายภาษา ที่ยังคงใช้ฟอนต์ธีม สามารถปฏิบัติตามโครงร่างฟอนต์ที่สอดคล้องกันในขณะที่ใช้ฟอนต์ที่เหมาะสมสำหรับ Cyrillic, Arabic, Japanese, Georgian, Thaana และสคริปต์อื่น ๆ

[FontScheme](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontscheme/) ของธีมมีคอล렉ชันฟอนต์หลัก (major) ซึ่งมักใช้สำหรับหัวเรื่องและคอล렉ชันฟอนต์รอง (minor) ซึ่งมักใช้สำหรับข้อความส่วนใหญ่ นอกจากการตั้งค่าฟอนต์ Latin และ East Asian แล้ว ทั้งสองคอล렉ชันยังเปิดเผยการแมพจากแท็กระบบการเขียนไปยังชื่อตระกูลฟอนต์ผ่านคลาส [Fonts](https://reference.aspose.com/slides/th/python-java/aspose.slides/fonts/)

บทความนี้แสดงวิธีตรวจสอบและแก้ไขการแมพเหล่านั้นในธีมมาสเตอร์ของการนำเสนอและตรวจสอบว่าการเปลี่ยนแปลงคงอยู่หลังการบันทึกและโหลดใหม่

## **ทำความเข้าใจแท็กสคริปต์**

วิธีฟอนต์สคริปต์ใช้แท็กสคริปต์ย่อย BCP 47 ที่มีสี่ตัวอักษรเพื่อระบุกระบบการเขียน ค่าโดยทั่วไปได้แก่:

| แท็กสคริปต์ | ระบบการเขียน |
|---|---|
| `Cyrl` | ไซริลลิก |
| `Arab` | อาหรับ |
| `Hans` | จีนแบบง่าย |
| `Jpan` | ญี่ปุ่น |
| `Geor` | จอร์เจีย |
| `Thaa` | ธานา |

การแมพเหล่านี้เป็นของสกีมฟอนต์ธีม ไม่ได้เป็นของส่วนข้อความแต่ละส่วน การนำเสนออาจกำหนดการแมพต่างกันสำหรับคอล렉ชันหลักและรอง และอาจไม่มีการแมพสำหรับบางสคริปต์

## **เข้าถึงและตรวจสอบการแมพฟอนต์สคริปต์**

ใช้ [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getMasterTheme) เพื่อเข้าถึงธีมระดับการนำเสนอ วิธี [FontScheme.getMajor](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontscheme/#getMajor) และ [FontScheme.getMinor](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontscheme/#getMinor) จะคืนคอล렉ชัน [Fonts](https://reference.aspose.com/slides/th/python-java/aspose.slides/fonts/) สองชุด

เรียก [Fonts.getScriptFontMap](https://reference.aspose.com/slides/th/python-java/aspose.slides/fonts/#getScriptFontMap) เพื่อดึงการแมพทั้งหมดจากคอล렉ชันหนึ่ง อย่างต้องการค้นหาระบบการเขียนหนึ่ง ให้ใช้ [Fonts.getScriptFont](https://reference.aspose.com/slides/th/python-java/aspose.slides/fonts/#getScriptFont) พร้อมแท็กสคริปต์ `getScriptFont` จะคืนค่า `None` เมื่อคอล렉ชันนั้นไม่ได้กำหนดการแมพที่ร้องขอ

## **แก้ไขการแมพและตรวจสอบความคงที่**

ใช้ [Fonts.setScriptFont](https://reference.aspose.com/slides/th/python-java/aspose.slides/fonts/#setScriptFont) เพื่อสร้างการแมพหรือแทนที่ตระกูลฟอนต์ปัจจุบัน ใช้ [Fonts.removeScriptFont](https://reference.aspose.com/slides/th/python-java/aspose.slides/fonts/#removeScriptFont) เพื่อลบการแมพ

ตัวอย่างครบวงจรต่อไปนี้อ่านการแมพหลักและรองทั้งหมด ค้นหา ฟอนต์หลักของญี่ปุ่น เปลี่ยนฟอนต์หลักของไซริลลิก ลบการแมพรองของธานา บันทึกการนำเสนอและเปิดใหม่เพื่อยืนยันการเปลี่ยนแปลงทั้งสอง ขั้นตอนการลบจะสร้างการแมพธานาเฉพาะเมียังไม่มีการแมพนั้นอยู่แล้ว

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    font_scheme = presentation.getMasterTheme().getFontScheme()
    major_fonts = font_scheme.getMajor()
    minor_fonts = font_scheme.getMinor()

    print("Existing major mappings:")
    major_mappings = major_fonts.getScriptFontMap().iterator()
    while major_mappings.hasNext():
        mapping = major_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    print("Existing minor mappings:")
    minor_mappings = minor_fonts.getScriptFontMap().iterator()
    while minor_mappings.hasNext():
        mapping = minor_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    japanese_font = major_fonts.getScriptFont("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.setScriptFont("Cyrl", "Arial")

    if minor_fonts.getScriptFont("Thaa") is None:
        minor_fonts.setScriptFont("Thaa", "Arial")

    minor_fonts.removeScriptFont("Thaa")
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("script-font-mappings.pptx")
try:
    saved_major_fonts = saved_presentation.getMasterTheme().getFontScheme().getMajor()
    saved_minor_fonts = saved_presentation.getMasterTheme().getFontScheme().getMinor()
    saved_cyrillic_font = saved_major_fonts.getScriptFont("Cyrl")
    saved_thaana_font = saved_minor_fonts.getScriptFont("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
finally:
    saved_presentation.dispose()
```

การตรวจสอบใช้พฤติกรรม `None` แบบเดียวกับการค้นหาทั่วไป: หลังจากบันทึกการลบแล้ว `getScriptFont("Thaa")` จะคืนค่า `None` สำหรับคอล렉ชันรอง

## **แยกแยะการแมพธีมจากการตั้งค่าอื่นของฟอนต์**

การแมพฟอนต์ธีมตามสคริปต์มีส่วนร่วมในการเลือกฟอนต์ แต่แก้ปัญหาแตกต่างจากการจัดรูปแบบข้อความโดยตรง การแทนที่ฟอนต์ และการสำรองฟอนต์:

| กลไก | จุดประสงค์ | ผลของการเปลี่ยนแปลงการแมพธีม |
|---|---|---|
| การแมพฟอนต์ธีมตามสคริปต์โดยเฉพาะ | เลือกฟอนต์ธีมหลักหรือรองสำหรับระบบการเขียน | ข้อความที่ยังใช้ธีมฟอนต์ที่สอดคล้องจะสามารถเปลี่ยนไปใช้ตระกูลฟอนต์ที่แมพใหม่ได้ |
| ฟอนต์ที่กำหนดโดยชัดเจนให้กับส่วนข้อความ | กำหนดตระกูลฟอนต์ที่ต้องการบนส่วนนั้นแทนการพึ่งธีม | ส่วนนั้นอาจคงเดิมไว้เนื่องจากการจัดรูปแบบโดยตรงบังคับเหนือการเลือกของธีม |
| การแทนที่ฟอนต์ | แทนที่ฟอนต์ที่ร้องขอเมื่อฟอนต์นั้นไม่พร้อมใช้งานหรือเมื่อนโยบายการแทนที่ใช้ได้ | มันทำงานหลังจากฟอนต์ถูกร้องขอ; ไม่ได้กำหนดการแมพสคริปต์ของธีมใหม่ |
| การสำรองฟอนต์ | ให้ glyph ที่ฟอนต์ที่เลือกไม่มีโดยส่วนมากสำหรับช่วง Unicode เฉพาะ | มันเติมส่วนที่ขาดของ glyph; ไม่เปลี่ยนการแมพธีมที่จัดเก็บไว้ |

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับสองกลไกสุดท้าย ดูที่ [Font Substitution](/slides/th/python-java/font-substitution/) และ [Fallback Fonts](/slides/th/python-java/fallback-font/)

การเปลี่ยนแปลงการแมพใน [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getMasterTheme) มีผลต่อเนื้อหาเท่านั้นที่การจัดรูปแบบที่มีผลยังพึ่งธีมนี้ ข้อความอาจสืบทอดการแมพจากมาสเตอร์, เลย์เอาต์, หรือสไลด์ หรือใช้ฟอนต์ที่กำหนดโดยชัดเจน ตรวจสอบระดับเหล่านั้นเมื่อผลลัพธ์ที่มองเห็นไม่เป็นไปตามการแมพระดับการนำเสนอ

## **ทำให้ฟอนต์ที่แมพพร้อมใช้งานและตรวจสอบผลลัพธ์**

การแมพสคริปต์เก็บชื่อตระกูลฟอนต์เท่านั้น ไม่ได้ติดตั้งหรือโหลดไฟล์ฟอนต์ที่สอดคล้องกัน เพื่อการเรนเดอร์และส่งออกที่สอดคล้อง ทุกฟอนต์ที่แมพต้องถูกติดตั้งในสภาพแวดล้อมหรือให้ Aspose.Slides โหลดผ่านแหล่งกำหนดเอง เช่น [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsloader/#loadExternalFonts) หรือ [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) ดูที่ [Custom Fonts](/slides/th/python-java/custom-font/) สำหรับตัวเลือกการโหลดที่มีให้

การยืนยันการแมพที่บันทึกไว้ยืนยันเพียงว่าการกำหนดธีมยังคงอยู่ ไม่ได้พิสูจน์ว่าฟอนต์พร้อมใช้งาน มี glyph ครบหรือให้ผลลัพธ์การจัดวางที่ต้องการ ให้เรนเดอร์ข้อความตัวอย่างสำหรับทุกระบบการเขียนที่ต้องการเป็นภาพหรือ PDF แล้วตรวจสอบผลลัพธ์ สิ่งนี้จะจับฟอนต์ที่หายไป, การครอบคลุม glyph ไม่ครบ, พฤติกรรมสำรอง, และการเปลี่ยนแปลงการจัดวางก่อนแจกจ่ายการนำเสนอ ดูที่ [Convert PowerPoint Presentations](/slides/th/python-java/convert-powerpoint/) เพื่อดูตัวอย่างการเรนเดอร์และส่งออก

## **คำถามที่พบบ่อย**

**`getScriptFont` คืนค่าอะไรเมื่อสคริปต์ไม่มีการแมพ?**

[Fonts.getScriptFont](https://reference.aspose.com/slides/th/python-java/aspose.slides/fonts/#getScriptFont) คืนค่า `None` เมื่อการแมพสคริปต์ที่ร้องขอไม่ได้กำหนดในคอล렉ชันหลักหรือรองนั้น

**`setScriptFont` จะเพิ่มการแมพที่สองเมื่อสคริปต์มีอยู่แล้วหรือไม่?**

ไม่. [Fonts.setScriptFont](https://reference.aspose.com/slides/th/python-java/aspose.slides/fonts/#setScriptFont) จะสร้างการแมพเมื่อไม่มีและแทนที่ตระกูลฟอนต์ที่แมพเมื่อแท็กสคริปต์นั้นมีอยู่แล้ว

**ทำไมการเปลี่ยนแปลงการแมพธีมไม่ทำให้ข้อความบางอย่างเปลี่ยน?**

ข้อความอาจมีฟอนต์ที่กำหนดโดยชัดเจน, สืบทอดธีมที่ต่างผ่านการโอเวอร์ไรด์, หรือได้รับผลกระทบจากการแทนที่หรือสำรองระหว่างการเรนเดอร์ การแมพสคริปต์ระดับการนำเสนอควบคุมเฉพาะข้อความที่การจัดรูปแบบที่มีผลยังอ้างอิงคอล렉ชันฟอนต์ธีมนี้

**การบันทึกและเปิดใหม่เพียงพอที่จะตรวจสอบผลลัพธ์หลายภาษาหรือไม่?**

ไม่. การเปิดใหม่ยืนยันความคงที่ของข้อมูลธีมเท่านั้น ควรเรนเดอร์ข้อความตัวอย่างจากแต่ละระบบการเขียนเพื่อยืนยันว่าฟอนต์ที่แมพพร้อมใช้งานและมี glyph ที่จำเป็น**