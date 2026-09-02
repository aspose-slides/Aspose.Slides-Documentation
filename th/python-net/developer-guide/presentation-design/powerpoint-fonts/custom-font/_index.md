---
title: ปรับแต่งฟอนต์ PowerPoint ใน Python
linktitle: ฟอนต์แบบกำหนดเอง
type: docs
weight: 20
url: /th/python-net/custom-font/
keywords:
  - ฟอนต์
  - ฟอนต์แบบกำหนดเอง
  - ฟอนต์ภายนอก
  - โหลดฟอนต์
  - จัดการฟอนต์
  - โฟลเดอร์ฟอนต์
  - PowerPoint
  - การนำเสนอ
  - Python
  - Aspose.Slides
description: "ฝังฟอนต์แบบกำหนดเองในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET เพื่อให้การนำเสนอของคุณคมชัดและสอดคล้องกันบนทุกอุปกรณ์."
---
## **ภาพรวม**

Aspose.Slides for Python ให้คุณสามารถจัดเตรียมฟอนต์แบบกำหนดเองในระหว่างการทำงาน เพื่อให้การนำเสนอแสดงผลอย่างถูกต้องแม้ว่าไม่มีการติดตั้งฟอนต์ที่ต้องการบนระบบโฮสต์ ระหว่างการส่งออกเป็น PDF หรือรูปภาพ คุณสามารถระบุโฟลเดอร์ฟอนต์หรือข้อมูลฟอนต์ในหน่วยความจำเพื่อรักษาการจัดรูปแบบข้อความ, มาตรฐานการวางรูปทรงอักขระ, และการพิมพ์ดีด สิ่งนี้ทำให้การเรนเดอร์ฝั่งเซิร์ฟเวอร์คาดการณ์ได้ในสภาพแวดล้อมต่าง ๆ ลบการพึ่งพาฟอนต์ระดับระบบปฏิบัติการ และป้องกันการใช้ฟอนต์สำรองหรือการทำซ้ำแบบไม่ต้องการ บทความนี้แสดงวิธีการลงทะเบียนแหล่งฟอนต์

ธีมการนำเสนอสามารถอ้างอิงฟอนต์หลายตระกูลสำหรับระบบการเขียนแต่ละระบบ การแมปนี้จะเก็บชื่อฟอนต์แต่ไม่ทำการติดตั้งหรือโหลดไฟล์ฟอนต์ ดู [ฟอนต์ธีมเฉพาะสคริปต์](/slides/th/python-net/script-specific-font-mappings/) เพื่อจัดการการแมปและใช้ตัวเลือกการโหลดด้านล่างเพื่อทำให้ฟอนต์ที่อ้างอิงพร้อมใช้งานสำหรับการเรนเดอร์ที่สอดคล้องกัน

Aspose.Slides ให้คุณโหลดฟอนต์ต่อไปนี้โดยใช้เมธอด `load_external_font` และ `load_external_fonts` ของคลาส [FontsLoader](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsloader/) :

- ฟอนต์ TrueType (.ttf) และ TrueType Collection (.ttc) ดู [TrueType](https://en.wikipedia.org/wiki/TrueType).
- ฟอนต์ OpenType (.otf) ดู [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **โหลดฟอนต์แบบกำหนดเอง**

Aspose.Slides อนุญาตให้คุณโหลดฟอนต์ที่ใช้ในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบ สิ่งนี้ส่งผลต่อผลลัพธ์การส่งออก เช่น PDF, รูปภาพ, และรูปแบบที่สนับสนุนอื่น ๆ ทำให้เอกสารที่ได้ดูสม่ำเสมอข้ามสภาพแวดล้อม ฟอนต์จะถูกโหลดจากไดเรกทอรีที่กำหนดเอง

1. ระบุหนึ่งหรือหลายโฟลเดอร์ที่มีไฟล์ฟอนต์
2. เรียกเมธอดสถิตย์ [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsloader/load_external_fonts/) เพื่อโหลดฟอนต์จากโฟลเดอร์เหล่านั้น
3. โหลดและเรนเดอร์/ส่งออกงานนำเสนอ
4. เรียก [FontsLoader.clear_cache](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsloader/clear_cache/) เพื่อลบแคชฟอนต์

ตัวอย่างโค้ดต่อไปนี้แสดงกระบวนการโหลดฟอนต์:

```py
import aspose.slides as slides

# กำหนดโฟลเดอร์ที่มีไฟล์ฟอนต์แบบกำหนดเอง
font_folders = ["fonts", "external_fonts"]

# โหลดฟอนต์แบบกำหนดเองจากโฟลเดอร์ที่ระบุ
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # เรนเดอร์/ส่งออกการนำเสนอ (เช่น PDF, รูปภาพ หรือรูปแบบอื่น) โดยใช้ฟอนต์ที่โหลดไว้
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# ลบแคชฟอนต์หลังจากทำงานเสร็จสิ้น
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="หมายเหตุ" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsloader/load_external_fonts/) เพิ่มโฟลเดอร์เพิ่มเติมไปยังเส้นทางค้นหาฟอนต์ แต่ไม่ได้เปลี่ยนลำดับการเริ่มต้นฟอนต์ ฟอนต์จะถูกเริ่มต้นตามลำดับนี้:

1. เส้นทางฟอนต์เริ่มต้นของระบบปฏิบัติการ
1. เส้นทางที่โหลดผ่าน [FontsLoader](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsloader/).
{{%/alert %}}

## **รับโฟลเดอร์ฟอนต์แบบกำหนดเอง**

Aspose.Slides มีเมธอด `get_font_folders` เพื่อดึงรายการโฟลเดอร์ฟอนต์ คืนค่าโฟลเดอร์ที่เพิ่มผ่าน `load_external_fonts` รวมทั้งโฟลเดอร์ฟอนต์ของระบบ

โค้ด Python ตัวอย่างต่อไปนี้แสดงวิธีใช้ `get_font_folders`:

```python
import aspose.slides as slides

# การเรียกนี้ส่งคืนโฟลเดอร์ที่ตรวจสอบสำหรับไฟล์ฟอนต์.
# ซึ่งรวมถึงโฟลเดอร์ที่เพิ่มผ่านเมธอด load_external_fonts และโฟลเดอร์ฟอนต์ของระบบ.
font_folders = slides.FontsLoader.get_font_folders()
```

## **ระบุฟอนต์แบบกำหนดเองสำหรับการนำเสนอ**

Aspose.Slides มีคุณสมบัติ `document_level_font_sources` ที่ให้คุณระบุฟอนต์ภายนอกที่จะใช้กับงานนำเสนอ

ตัวอย่าง Python ต่อไปนี้แสดงวิธีใช้ `document_level_font_sources`:

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
    # ทำงานกับการนำเสนอ.
    # CustomFont1, CustomFont2, และฟอนต์จากโฟลเดอร์ assets\fonts และ global\fonts (รวมถึงโฟลเดอร์ย่อย) พร้อมใช้งานในการนำเสนอ.
    # ...
    print(len(presentation.slides))
```

## **โหลดฟอนต์ภายนอกจากข้อมูลไบนารี**

Aspose.Slides มีเมธอด `load_external_font` เพื่อโหลดฟอนต์ภายนอกจากข้อมูลไบนารี

ตัวอย่าง Python ต่อไปนี้สาธิตการโหลดฟอนต์จากอาเรย์ไบต์:

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# โหลดฟอนต์ภายนอกจากอาเรย์ไบต์.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # ฟอนต์ภายนือพร้อมใช้งานตลอดอายุของออบเจกต์การนำเสนอนี้.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **คำถามที่พบบ่อย**

### ฟอนต์แบบกำหนดเองมีผลต่อการส่งออกไปยังทุกรูปแบบ (PDF, PNG, SVG, HTML) หรือไม่?

ใช่. ฟอนต์ที่เชื่อมต่อจะถูกใช้โดยเรนเดอร์ในทุกรูปแบบการส่งออก

### ฟอนต์แบบกำหนดเองจะถูกฝังลงในไฟล์ PPTX ที่ได้โดยอัตโนมัติหรือไม่?

ไม่. การลงทะเบียนฟอนต์เพื่อการเรนเดอร์ไม่เท่ากับการฝังฟอนต์ลงใน PPTX หากคุณต้องการให้ฟอนต์อยู่ภายในไฟล์การนำเสนอ คุณต้องใช้ [ฟีเจอร์การฝัง](/slides/th/python-net/embedded-font/)

### สามารถควบคุมพฤติกรรมสำรองเมื่อฟอนต์แบบกำหนดเองขาดบาง glyph ได้หรือไม่?

ได้. ตั้งค่า [font substitution](/slides/th/python-net/font-substitution/), [replacement rules](/slides/th/python-net/font-replacement/), และ [fallback sets](/slides/th/python-net/fallback-font/) เพื่อกำหนดแน่ชัดว่าฟอนต์ใดจะใช้เมื่อ glyph ที่ต้องการไม่มีอยู่

### สามารถใช้ฟอนต์ในคอนเทนเนอร์ Linux/Docker โดยไม่ต้องติดตั้งทั่วระบบได้หรือไม่?

ได้. ชี้ไปยังโฟลเดอร์ฟอนต์ของคุณเองหรือโหลดฟอนต์จากอาเรย์ไบต์ สิ่งนี้จะลบการพึ่งพาไดเรกทอรีฟอนต์ของระบบในอิมเมจคอนเทนเนอร์

### เรื่องลิขสิทธิ์—สามารถฝังฟอนต์แบบกำหนดเองใดก็ได้โดยไม่มีข้อจำกัดหรือไม่?

คุณต้องรับผิดชอบต่อการปฏิบัติตามลิขสิทธิ์ของฟอนต์ เงื่อนไขอาจแตกต่างกัน; บางลิขสิทธิ์ห้ามการฝังหรือการใช้เชิงพาณิชย์ ควรตรวจสอบ EULA ของฟอนต์ก่อนแจกจ่ายผลลัพธ์