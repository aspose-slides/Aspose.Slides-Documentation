---
title: จัดการแบบอักษรธีมเฉพาะสคริปต์ใน Python
linktitle: แบบอักษรธีมเฉพาะสคริปต์
type: docs
weight: 15
url: /th/python-net/script-specific-font-mappings/
keywords:
- แบบอักษรเฉพาะสคริปต์
- การแมพแบบอักษรธีม
- งานนำเสนอหลายภาษา
- ระบบการเขียน
- แบบอักษร Cyrillic
- แบบอักษร Arabic
- แบบอักษร Japanese
- แบบอักษร Georgian
- แบบอักษร Thaana
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ตรวจสอบ, เพิ่ม, แทนที่ และลบการแมพแบบอักษรเฉพาะสคริปต์ในธีม PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **ภาพรวม**

ธีมของงานนำเสนอสามารถเลือกชุดแบบอักษรที่ต่างกันสำหรับระบบการเขียนที่แตกต่างกันได้ ซึ่งทำให้ข้อความหลายภาษา ที่ยังคงใช้แบบอักษรของธีม สามารถใช้โครงแบบอักษรที่สอดคล้องกันเดียวกัน ในขณะที่ใช้แบบอักษรที่เหมาะสมสำหรับ Cyrillic, Arabic, Japanese, Georgian, Thaana และสคริปต์อื่นๆ  

ธีมของงานนำเสนอ [FontScheme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/fontscheme/) มีคอลเลกชันแบบอักษรหลัก (major) ที่โดยทั่วไปใช้สำหรับหัวข้อและคอลเลกชันแบบอักษรรอง (minor) ที่โดยทั่วไปใช้สำหรับข้อความส่วนเนื้อหา นอกจากนี้ ทั้งสองคอลเลกชันยังเปิดเผยการแมพจากแท็กระบบการเขียนไปยังชื่อชุดแบบอักษรผ่านคลาส [Fonts](https://reference.aspose.com/slides/th/python-net/aspose.slides/fonts/) ด้วย  

บทความนี้จะแสดงวิธีตรวจสอบและแก้ไขการแมพเหล่านั้นในธีมมาสเตอร์ของงานนำเสนอ และตรวจสอบว่าการเปลี่ยนแปลงยังคงอยู่หลังการบันทึกและโหลดใหม่  

## **ทำความเข้าใจกับแท็กสคริปต์**

เมธอดแบบอักษรสคริปต์ใช้แท็กสคริปต์ย่อยแบบ BCP 47 ที่มีสี่ตัวอักษรเพื่อระบุตัวระบบการเขียน ค่าโดยทั่วไปได้แก่:

| แท็กสคริปต์ | ระบบการเขียน |
|---|---|
| `Cyrl` | Cyrillic |
| `Arab` | Arabic |
| `Hans` | Simplified Chinese |
| `Jpan` | Japanese |
| `Geor` | Georgian |
| `Thaa` | Thaana |

การแมพเหล่านี้เป็นของสกีมแบบอักษรของธีม ไม่ใช่ของส่วนข้อความแต่ละส่วน งานนำเสนออาจกำหนดการแมพที่แตกต่างกันสำหรับคอลเลกชันหลักและรอง และอาจละเว้นการแมพบางสคริปต์  

## **เข้าถึงและตรวจสอบการแมพแบบอักษรสคริปต์**

ใช้ [Presentation.master_theme](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/master_theme/) เพื่อเข้าถึงธีมระดับงานนำเสนอ คุณสมบัติ [FontScheme.major](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/fontscheme/major/) และ [FontScheme.minor](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/fontscheme/minor/) จะส่งคืนคอลเลกชัน [Fonts](https://reference.aspose.com/slides/th/python-net/aspose.slides/fonts/) สองชุด  

เรียก [Fonts.get_script_font_map](https://reference.aspose.com/slides/th/python-net/aspose.slides/fonts/get_script_font_map/) เพื่อดึงการแมพทั้งหมดจากคอลเลกชันหนึ่ง หากต้องการค้นหาระบบการเขียนหนึ่ง ให้เรียก [Fonts.get_script_font](https://reference.aspose.com/slides/th/python-net/aspose.slides/fonts/get_script_font/) พร้อมแท็กสคริปต์ของมัน `get_script_font` จะคืนค่า `None` เมื่อคอลเลกชันนั้นไม่ได้กำหนดการแมพที่ร้องขอ  

## **แก้ไขการแมพและตรวจสอบการคงอยู่**

ใช้ [Fonts.set_script_font](https://reference.aspose.com/slides/th/python-net/aspose.slides/fonts/set_script_font/) เพื่อสร้างการแมพหรือแทนที่ชุดแบบอักษรปัจจุบัน ใช้ [Fonts.remove_script_font](https://reference.aspose.com/slides/th/python-net/aspose.slides/fonts/remove_script_font/) เพื่อเอาการแมพออก  

ตัวอย่างเต็มขั้นต่อไปนี้อ่านการแมพหลักและรองที่มีอยู่ทั้งหมด ค้นหาแบบอักษรหลักของญี่ปุ่น เปลี่ยนแบบอักษรหลักของซีริลลิก ลบการแมพรองของธานา บันทึกงานนำเสนอ และเปิดใหม่เพื่อยืนยันการเปลี่ยนแปลงทั้งสอง เพื่อทำให้ขั้นตอนการลบเป็นอิสระจากธีมเริ่มต้น ตัวอย่างจะสร้างการแมพธานาเท่านั้นเมื่อยังไม่มีการกำหนดไว้ก่อนหน้า  

```python
import aspose.slides as slides


def print_script_font_map(label, fonts):
    print(label)
    for mapping in fonts.get_script_font_map():
        print(f"  {mapping.key}: {mapping.value}")


with slides.Presentation() as presentation:
    font_scheme = presentation.master_theme.font_scheme
    major_fonts = font_scheme.major
    minor_fonts = font_scheme.minor

    print_script_font_map("Existing major mappings:", major_fonts)
    print_script_font_map("Existing minor mappings:", minor_fonts)

    japanese_font = major_fonts.get_script_font("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.set_script_font("Cyrl", "Arial")

    if minor_fonts.get_script_font("Thaa") is None:
        minor_fonts.set_script_font("Thaa", "Arial")

    minor_fonts.remove_script_font("Thaa")
    presentation.save("script-font-mappings.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("script-font-mappings.pptx") as saved_presentation:
    saved_major_fonts = saved_presentation.master_theme.font_scheme.major
    saved_minor_fonts = saved_presentation.master_theme.font_scheme.minor
    saved_cyrillic_font = saved_major_fonts.get_script_font("Cyrl")
    saved_thaana_font = saved_minor_fonts.get_script_font("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
```

การตรวจสอบใช้พฤติกรรม `None` เดียวกับการค้นหาปกติ: หลังจากบันทึกการลบแล้ว `get_script_font("Thaa")` จะคืนค่า `None` สำหรับคอลเลกชันรอง  

## **แยกแยะการแมพธีมจากการตั้งค่าแบบอักษรอื่น**

การแมพธีมเฉพาะสคริปต์มีส่วนร่วมในการเลือกแบบอักษร แต่พวกมันแก้ปัญหาที่ต่างจากการจัดรูปแบบข้อความโดยตรง, การแทนที่, และการสำรองแบบอักษร:  

| กลไก | จุดประสงค์ | ผลของการเปลี่ยนการแมพธีม |
|---|---|---|
| การแมพแบบอักษรธีมเฉพาะสคริปต์ | เลือกแบบอักษรธีมหลักหรือรองสำหรับระบบการเขียนหนึ่ง | ข้อความที่ยังคงใช้แบบอักษรธีมที่สอดคล้องสามารถแก้ไขไปยังชุดแบบอักษรใหม่ที่แมพไว้ |
| แบบอักษรที่กำหนดอย่างชัดเจนให้กับส่วนข้อความ | กำหนดชุดแบบอักษรที่ร้องขอให้กับส่วนนั้นแทนการพึ่งธีม | ส่วนนั้นอาจไม่เปลี่ยนแปลงเพราะการจัดรูปแบบโดยตรงเหนือกว่าการเลือกของธีม |
| การแทนที่แบบอักษร | แทนที่แบบอักษรที่ร้องขอเมื่อแบบอักษรนั้นไม่มีอยู่หรือเมื่อตัวแทนที่มีผลบังคับใช้ | ทำงานหลังจากมีการร้องขอแบบอักษร; ไม่ได้กำหนดการแมพสคริปต์ของธีมใหม่ |
| การสำรองแบบอักษร | ให้ glyph ที่แบบอักษรที่เลือกไม่มีอยู่ โดยมักสำหรับช่วง Unicode เฉพาะ | เติมเต็ม glyph ที่ขาดหาย; ไม่ได้เปลี่ยนการแมพธีมที่จัดเก็บไว้ |

[การแทนที่แบบอักษร](/slides/th/python-net/font-substitution/) และ [แบบอักษรสำรอง](/slides/th/python-net/fallback-font/)  

การเปลี่ยนการแมพใน [Presentation.master_theme](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/master_theme/) มีผลต่อเนื้อหาเท่านั้นที่การจัดรูปแบบที่มีผลยังคงพึ่งพาธีมนั้น ข้อความอาจสืบทอดการโอเวอร์ไรด์ของธีมจากมาสเตอร์, เลย์เอาต์, หรือสไลด์, หรือใช้แบบอักษรที่กำหนดโดยชัดเจน ตรวจสอบระดับเหล่านั้นเมื่อผลลัพธ์ที่มองเห็นไม่ได้ตามการแมพระดับงานนำเสนอ  

## **ทำให้แบบอักษรที่แมพพร้อมใช้งานและตรวจสอบผลลัพธ์**

การแมพสคริปต์จะเก็บชื่อชุดแบบอักษร; มันไม่ได้ติดตั้งหรือโหลดไฟล์แบบอักษรที่สอดคล้องกัน เพื่อการเรนเดอร์และการส่งออกที่สอดคล้องกัน ทุกแบบอักษรที่แมพต้องถูกติดตั้งในสภาพแวดล้อมหรือถูกจัดหาให้กับ Aspose.Slides ผ่านแหล่งข้อมูลแบบกำหนดเอง เช่น [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsloader/load_external_fonts/) หรือ [LoadOptions.document_level_font_sources](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/document_level_font_sources/) ดู [แบบอักษรกำหนดเอง](/slides/th/python-net/custom-font/) สำหรับตัวเลือกการโหลดที่มี  

การตรวจสอบการแมพที่บันทึกไว้ ยืนยันเพียงว่าการนิยามธีมยังคงอยู่ ไม่ได้ยืนยันว่าแบบอักษรพร้อมใช้งาน, มี glyph ทั้งหมดที่ต้องการ, หรือสร้างการจัดวางตามที่ตั้งใจ ทำการเรนเดอร์ข้อความตัวอย่างสำหรับระบบการเขียนที่ต้องการแต่ละระบบเป็นภาพหรือ PDF แล้วตรวจสอบผลลัพธ์ สิ่งนี้ช่วยจับแบบอักษรที่ขาด, การครอบคลุม glyph ที่ไม่สมบูรณ์, พฤติกรรมสำรอง, และการเปลี่ยนแปลงการจัดวาง ก่อนที่งานนำเสนอจะถูกแจกจ่าย ดู [แปลงการนำเสนอ PowerPoint](/slides/th/python-net/convert-powerpoint/) สำหรับตัวอย่างการเรนเดอร์และส่งออก  

## **คำถามที่พบบ่อย**

**`get_script_font` จะคืนค่าอะไรเมื่อสคริปต์ไม่มีการแมพ?**

[Fonts.get_script_font](https://reference.aspose.com/slides/th/python-net/aspose.slides/fonts/get_script_font/) จะคืนค่า `None` เมื่อการแมพสคริปต์ที่ร้องขอไม่ได้ถูกกำหนดในคอลเลกชันแบบอักษรหลักหรือรองนั้น  

**`set_script_font` จะเพิ่มการแมพที่สองเมื่อสคริปต์มีอยู่แล้วหรือไม่?**

ไม่. [Fonts.set_script_font](https://reference.aspose.com/slides/th/python-net/aspose.slides/fonts/set_script_font/) จะสร้างการแมพเมื่อยังไม่มีและแทนที่ชุดแบบอักษรที่แมพไว้เมื่อแท็กสคริปต์เดียวกันมีอยู่แล้ว  

**ทำไมการเปลี่ยนการแมพธีมไม่ทำให้ข้อความบางส่วนเปลี่ยนแปลง?**

ข้อความอาจมีแบบอักษรที่กำหนดอย่างชัดเจน, สืบทอดธีมที่ต่างออกไปผ่านการโอเวอร์ไรด์, หรือถูกกระทบโดยการแทนที่หรือสำรองระหว่างการเรนเดอร์ การแมพสคริปต์ระดับงานนำเสนอควบคุมเฉพาะข้อความที่การจัดรูปแบบที่มีผลยังอ้างอิงคอลเลกชันแบบอักษรของธีมนั้น  

**การบันทึกและเปิดใหม่เพียงพอที่จะตรวจสอบผลลัพธ์หลายภาษาหรือไม่?**

ไม่. การเปิดใหม่ตรวจสอบการคงอยู่ของข้อมูลธีม นอกจากนี้ยังต้องเรนเดอร์ข้อความตัวอย่างจากแต่ละระบบการเขียนที่ต้องการเพื่อยืนยันว่าแบบอักษรที่แมพพร้อมใช้งานและมี glyph ที่จำเป็น