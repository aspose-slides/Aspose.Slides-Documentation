---
title: ปรับแต่งแบบอักษร PowerPoint ใน Python
linktitle: แบบอักษรแบบกำหนดเอง
type: docs
weight: 20
url: /th/python-net/custom-font/
keywords:
- แบบอักษร
- แบบอักษรกำหนดเอง
- แบบอักษรภายนอก
- โหลดแบบอักษร
- จัดการแบบอักษร
- โฟลเดอร์แบบอักษร
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ฝังแบบอักษรแบบกำหนดเองลงในสไลด์ PowerPoint ด้วย Aspose.Slides for Python ผ่าน .NET เพื่อให้การนำเสนอของคุณคมชัดและสอดคล้องกันในทุกอุปกรณ์."
---
## **ภาพรวม**

Aspose.Slides for Python ให้คุณระบุแบบอักษรแบบกำหนดเองในขณะทำงาน เพื่อให้การเรนเดอร์งานนำเสนอทำงานได้ถูกต้องแม้ว่าแบบอักษรที่ต้องการจะไม่ได้ถูกติดตั้งบนระบบโฮสต์ ในระหว่างการส่งออกเป็น PDF หรือรูปภาพ คุณสามารถระบุโฟลเดอร์แบบอักษรหรือข้อมูลแบบอักษรในหน่วยความจำเพื่อคงรูปแบบข้อความ, เมตริกซ์ glyph, และการจัดหน้า typography สิ่งนี้ทำให้การเรนเดอร์บนเซิร์ฟเวอร์คาดการณ์ได้ในสภาพแวดล้อมที่ต่างกัน, ลดการพึ่งพาแบบอักษรระดับ OS, และป้องกันการเปลี่ยนเป็นแบบอักษรสำรองหรือการจัดหน้าใหม่ บทความนี้แสดงวิธีลงทะเบียนแหล่งแบบอักษร

Aspose.Slides ให้คุณโหลดแบบอักษรต่อไปนี้โดยใช้เมธอด `load_external_font` และ `load_external_fonts` ของคลาส [FontsLoader](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsloader/) :

- TrueType (.ttf) และ TrueType Collection (.ttc) ดูข้อมูลเพิ่มเติมที่ [TrueType](https://en.wikipedia.org/wiki/TrueType) .
- OpenType (.otf) ดูข้อมูลเพิ่มเติมที่ [OpenType](https://en.wikipedia.org/wiki/OpenType) .

## **โหลดแบบอักษรแบบกำหนดเอง**

Aspose.Slides อนุญาตให้คุณโหลดแบบอักษรที่ใช้ในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบ สิ่งนี้มีผลต่อผลลัพธ์การส่งออก—เช่น PDF, รูปภาพ, และรูปแบบที่สนับสนุนอื่น ๆ—เพื่อให้เอกสารที่ได้มีลักษณะสอดคล้องกันในทุกสภาพแวดล้อม แบบอักษรถูกโหลดจากไดเรกทอรีที่กำหนดเอง

1. ระบุหนึ่งหรือหลายโฟลเดอร์ที่มีไฟล์แบบอักษร
2. เรียกเมธอดแบบคงที่ [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsloader/load_external_fonts/) เพื่อโหลดแบบอักษรจากโฟลเดอร์เหล่านั้น
3. โหลดและเรนเดอร์/ส่งออกงานนำเสนอ
4. เรียก [FontsLoader.clear_cache](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsloader/clear_cache/) เพื่อล้างแคชแบบอักษร

ตัวอย่างโค้ดต่อไปนี้แสดงกระบวนการโหลดแบบอักษร :

```py
import aspose.slides as slides

# กำหนดโฟลเดอร์ที่มีไฟล์แบบอักษรแบบกำหนดเอง.
font_folders = [ external_font_folder1, external_font_folder2 ]

# โหลดแบบอักษรแบบกำหนดเองจากโฟลเดอร์ที่ระบุ.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # เรนเดอร์/ส่งออกงานนำเสนอ (เช่น PDF, รูปภาพ หรือรูปแบบอื่น) โดยใช้แบบอักษรที่โหลดไว้.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# ล้างแคชแบบอักษรหลังจากทำงานเสร็จ.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Note" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsloader/load_external_fonts/) เพิ่มโฟลเดอร์เพิ่มเติมไปยังเส้นทางค้นหาแบบอักษร, แต่ไม่ได้เปลี่ยนลำดับการเริ่มต้นแบบอักษร
แบบอักษรถูกเริ่มต้นตามลำดับนี้ :

1. เส้นทางแบบอักษรเริ่มต้นของระบบปฏิบัติการ
1. เส้นทางที่โหลดผ่าน [FontsLoader](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsloader/) .
{{%/alert %}}

## **รับโฟลเดอร์แบบอักษรแบบกำหนดเอง**

Aspose.Slides มีเมธอด `get_font_folders` เพื่อดึงรายการโฟลเดอร์แบบอักษร ซึ่งจะคืนค่าโฟลเดอร์ที่เพิ่มด้วย `load_external_fonts` รวมถึงโฟลเดอร์แบบอักษรของระบบ

โค้ด Python นี้แสดงวิธีใช้ `get_font_folders` :

```python
import aspose.slides as slides

# การเรียกนี้คืนค่าโฟลเดอร์ที่ตรวจสอบไฟล์แบบอักษร.
# โฟลเดอร์เหล่านี้รวมถึงโฟลเดอร์ที่เพิ่มผ่านเมธอด load_external_fonts และโฟลเดอร์แบบอักษรของระบบ.
font_folders = slides.FontsLoader.get_font_folders()
```

## **ระบุแบบอักษรแบบกำหนดเองสำหรับงานนำเสนอ**

Aspose.Slides มีคุณสมบัติ `document_level_font_sources` ที่ให้คุณระบุแบบอักษรภายนอกที่ใช้ร่วมกับงานนำเสนอ

ตัวอย่าง Python ด้านล่างแสดงวิธีใช้ `document_level_font_sources` :

```python
import aspose.slides as slides

with open("CustomFont1.ttf", "br") as font1_stream:
    font1_data = font1_stream.read()
    
with open("CustomFont2.ttf", "br") as font2_stream:
    font2_data = font2_stream.read()

load_options = slides.LoadOptions()
load_options.document_level_font_sources.font_folders = ["assets\\fonts", "global\\fonts"] 
load_options.document_level_font_sources.memory_fonts = [font1_data, font2_data]

with slides.Presentation("Fonts.pptx", load_options) as presentation:
    # ...
    # ทำงานกับงานนำเสนอ.
    # CustomFont1, CustomFont2 และแบบอักษรจากโฟลเดอร์ assets\fonts และ global\fonts (รวมถึงโฟลเดอร์ย่อยของพวกมัน) สามารถใช้ได้ในงานนำเสนอ.
    # ...
    print(len(presentation.slides))
```

## **โหลดแบบอักษรภายนอกจากข้อมูลไบต์**

Aspose.Slides มีเมธอด `load_external_font` เพื่อโหลดแบบอักษรภายนอกจากข้อมูลไบต์

ตัวอย่าง Python ต่อไปนี้แสดงการโหลดแบบอักษรจากอาร์เรย์ไบต์ :

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# โหลดแบบอักษรภายนอกจากอาเรย์ไบต์.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # แบบอักษรภายนอาจใช้ได้ตลอดอายุของอินสแตนซ์งานนำเสนอนี้.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **คำถามที่พบบ่อย**

**แบบอักษรแบบกำหนดเองมีผลต่อการส่งออกทุกรูปแบบ (PDF, PNG, SVG, HTML) หรือไม่?**

ใช่. แบบอักษรที่เชื่อมต่อจะถูกใช้โดยเรนเดอร์ในทุกรูปแบบการส่งออก

**แบบอักษรแบบกำหนดเองจะถูกฝังโดยอัตโนมัติใน PPTX ที่ได้หรือไม่?**

ไม่. การลงทะเบียนแบบอักษรเพื่อการเรนเดอร์ไม่เท่ากับการฝังลงใน PPTX หากคุณต้องการให้แบบอักษรถูกบรรจุภายในไฟล์งานนำเสนอ ต้องใช้คุณลักษณะการ [embedding](/slides/th/python-net/embedded-font/) อย่างชัดเจน

**ฉันสามารถควบคุมพฤติกรรมสำรองเมื่อแบบอักษรกำหนดเองไม่มี glyph บางตัวได้หรือไม่?**

ได้. ตั้งค่า [font substitution](/slides/th/python-net/font-substitution/), [replacement rules](/slides/th/python-net/font-replacement/), และ [fallback sets](/slides/th/python-net/fallback-font/) เพื่อกำหนดว่าแบบอักษรใดจะถูกใช้เมื่อ glyph ที่ร้องขอไม่มีอยู่

**ฉันสามารถใช้แบบอักษรในคอนเทนเนอร์ Linux/Docker โดยไม่ต้องติดตั้งบนระบบทั้งหมดได้หรือไม่?**

ได้. ชี้ไปยังโฟลเดอร์แบบอักษรของคุณเองหรือโหลดแบบอักษรจากอาร์เรย์ไบต์ สิ่งนี้จะลบการพึ่งพาไดเรกทอรีแบบอักษรของระบบออกจากอิมเมจของคอนเทนเนอร์

**เรื่องลิขสิทธิ์—ฉันสามารถฝังแบบอักษรกำหนดเองใดก็ได้โดยไม่มีข้อจำกัดหรือไม่?**

คุณต้องรับผิดชอบต่อการปฏิบัติตามเงื่อนไขลิขสิทธิ์ของแบบอักษร เงื่อนไขอาจแตกต่างกัน; บางลิขสิทธิ์ห้ามการฝังหรือการใช้งานเชิงพาณิชย์ ตรวจสอบข้อตกลง EULA ของแบบอักษรก่อนเผยแพร่ผลลัพธ์เสมอ