---
title: ปรับแต่งฟอนท์ PowerPoint ใน Python ผ่าน Java
linktitle: ฟอนท์แบบกำหนดเอง
type: docs
weight: 20
url: /th/python-java/custom-font/
keywords:
- ฟอนท์
- ฟอนท์แบบกำหนดเอง
- ฟอนท์ภายนอก
- โหลดฟอนท์
- จัดการฟอนท์
- โฟลเดอร์ฟอนท์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ปรับแต่งฟอนท์ในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน Java เพื่อให้การนำเสนอของคุณคมชัดและสม่ำเสมอบนทุกอุปกรณ์"
---
## **ภาพรวม**

Aspose.Slides อนุญาตให้คุณใช้ฟอนท์แบบกำหนดเองในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบปฏิบัติการ คุณสามารถโหลดฟอนท์จากโฟลเดอร์กำหนดเอง, จัดหาฟอนท์สำหรับงานนำเสนอเฉพาะผ่านแหล่งฟอนท์ระดับเอกสาร, หรือโหลดฟอนท์ภายนอกจากข้อมูลไบต์โดยตรง

ฟอนท์ที่โหลดจะถูกใช้เมื่อทำการเรนเดอร์หรือส่งออกงานนำเสนอ เช่น ไปยัง PDF, รูปภาพและรูปแบบที่สนับสนุนอื่น ๆ สิ่งนี้ช่วยให้ผลลัพธ์ของงานนำเสนอคงที่ในสภาพแวดล้อมที่ต่างกัน บทความนี้ยังอธิบายวิธีตรวจสอบโฟลเดอร์ฟอนท์ที่ Aspose.Slides ใช้และวิธีลบแคชฟอนท์หลังจากทำงานกับฟอนท์ภายนอก

การลงทะเบียนฟอนท์แบบกำหนดเองสำหรับการเรนเดอร์เป็นขั้นตอนที่แยกจากการฝังฟอนท์ลงในไฟล์ PPTX หากต้องการให้ฟอนท์บันทึกอยู่ภายในงานนำเสนอเอง ให้ใช้ฟีเจอร์การฝังฟอนท์อย่างชัดเจน

ธีมของงานนำเสนอสามารถอ้างอิงฟอนท์ฟาแอมิลี่ต่าง ๆ สำหรับระบบการเขียนแต่ละระบบ การแมปนี้จะเก็บชื่อฟอนท์แต่ไม่ทำการติดตั้งหรือโหลดไฟล์ฟอนท์ ดู [Script-Specific Theme Fonts](/slides/th/python-java/script-specific-font-mappings/) เพื่อจัดการการแมป และใช้ตัวเลือกการโหลดด้านล่างเพื่อทำให้ฟอนท์ที่อ้างอิงพร้อมใช้งานสำหรับการเรนเดอร์ที่สม่ำเสมอ

{{% alert color="info" title="หมายเหตุ" %}}
Aspose.Slides อนุญาตให้คุณโหลดฟอนท์เหล่านี้โดยใช้เมธอด [loadExternalFonts](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsloader/#loadExternalFonts):

* ฟอนท์ TrueType (.ttf) และ TrueType Collection (.ttc) ดูที่ [TrueType](https://en.wikipedia.org/wiki/TrueType)
* ฟอนท์ OpenType (.otf) ดูที่ [OpenType](https://en.wikipedia.org/wiki/OpenType)
{{% /alert %}}

## **โหลดฟอนท์แบบกำหนดเอง**

Aspose.Slides อนุญาตให้คุณโหลดฟอนท์ที่ใช้ในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบ ซึ่งส่งผลต่อผลลัพธ์การส่งออก เช่น PDF, รูปภาพและรูปแบบที่สนับสนุนอื่น ๆ ทำให้เอกสารที่สร้างขึ้นดูสม่ำเสมอในสภาพแวดล้อมต่าง ๆ ฟอนท์จะถูกโหลดจากไดเรกทอรีกำหนดเอง

1. ระบุโฟลเดอร์หนึ่งหรือหลายโฟลเดอร์ที่มีไฟล์ฟอนท์
2. เรียกเมธอดสตาติก [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsloader/#loadExternalFonts) เพื่อโหลดฟอนท์จากโฟลเดอร์เหล่านั้น
3. โหลดและเรนเดอร์/ส่งออกงานนำเสนอ
4. เรียก [FontsLoader.clearCache](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsloader/#clearCache) เพื่อลบแคชฟอนท์

ตัวอย่างโค้ดต่อไปนี้สาธิตกระบวนการโหลดฟอนท์:

```python
from jpype import JArray, JString
from asposeslides.api import FontsLoader, Presentation, SaveFormat

# กำหนดโฟลเดอร์ที่มีไฟล์ฟอนท์แบบกำหนดเอง.
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])

# โหลดฟอนท์แบบกำหนดเองจากโฟลเดอร์ที่ระบุ.
FontsLoader.loadExternalFonts(font_folders)

presentation = None
try:
    presentation = Presentation("sample.pptx")

    # ทำการเรนเดอร์/ส่งออกงานนำเสนอโดยใช้ฟอนท์ที่โหลด.
    presentation.save("output.pdf", SaveFormat.Pdf)
finally:
    if presentation is not None:
        presentation.dispose()

    # ลบแคชฟอนท์หลังจากทำงานเสร็จ.
    FontsLoader.clearCache()
```

{{% alert color="info" title="หมายเหตุ" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsloader/#loadExternalFonts) เพิ่มโฟลเดอร์เพิ่มเติมไปยังเส้นทางค้นหาฟอนท์ แต่ไม่ได้เปลี่ยนลำดับการเริ่มต้นฟอนท์ ฟอนท์จะถูกเริ่มต้นตามลำดับนี้:

1. เส้นทางฟอนท์เริ่มต้นของระบบปฏิบัติการ
1. เส้นทางที่โหลดผ่าน [FontsLoader](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsloader/)
{{%/alert %}}

## **รับโฟลเดอร์ฟอนท์แบบกำหนดเอง**
Aspose.Slides มีเมธอด [getFontFolders](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsloader/#getFontFolders) เพื่อให้คุณค้นหาโฟลเดอร์ฟอนท์ เมธอดนี้จะคืนค่าโฟลเดอร์ที่เพิ่มผ่านเมธอด [loadExternalFonts](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsloader/#loadExternalFonts) และโฟลเดอร์ฟอนท์ของระบบ

โค้ด Python นี้แสดงวิธีใช้ [getFontFolders](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsloader/#getFontFolders):

```python
from asposeslides.api import FontsLoader

# รับโฟลเดอร์ที่เพิ่มผ่าน loadExternalFonts และโฟลเดอร์ฟอนท์ของระบบ.
font_folders = FontsLoader.getFontFolders()
```

## **ระบุฟอนท์แบบกำหนดเองที่ใช้กับงานนำเสนอ**
Aspose.Slides มีเมธอด [getDocumentLevelFontSources](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) เพื่อให้คุณระบุฟอนท์ภายนอกที่จะใช้กับงานนำเสนอ

โค้ด Python นี้แสดงวิธีใช้เมธอด [getDocumentLevelFontSources](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources):

```python
from pathlib import Path
from jpype import JArray, JByte, JString
from asposeslides.api import LoadOptions, Presentation

memory_font_primary = Path("customfonts/CustomFont1.ttf").read_bytes()
memory_font_secondary = Path("customfonts/CustomFont2.ttf").read_bytes()

load_options = LoadOptions()
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])
memory_fonts = JArray(JByte, 2)([memory_font_primary, memory_font_secondary])
load_options.getDocumentLevelFontSources().setFontFolders(font_folders)
load_options.getDocumentLevelFontSources().setMemoryFonts(memory_fonts)

presentation = Presentation("MyPresentation.pptx", load_options)
try:
    # ทำงานกับงานนำเสนอ.
    # CustomFont1, CustomFont2, และฟอนท์จาก assets/fonts และ global/fonts
    # และโฟลเดอร์ย่อยของพวกมันพร้อมใช้งานในงานนำเสนอ.
    pass
finally:
    presentation.dispose()
```

## **จัดการฟอนท์จากภายนอก**

Aspose.Slides มีเมธอด [loadExternalFont](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsloader/#loadExternalFont) เพื่อให้คุณโหลดฟอนท์ภายนอกจากข้อมูลไบต์

โค้ด Python นี้สาธิตกระบวนการโหลดฟอนท์จากอาเรย์ไบต์:

```python
from pathlib import Path
from jpype import JArray, JByte
from asposeslides.api import FontsLoader, Presentation

font_data = Path("ARIALN.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNBI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))

try:
    presentation = Presentation()
    try:
        # ฟอนท์ภายนอกถูกโหลดในช่วงอายุการทำงานของงานนำเสนอ.
        pass
    finally:
        presentation.dispose()
finally:
    FontsLoader.clearCache()
```

## **คำถามที่พบบ่อย**

**ฟอนท์แบบกำหนดเองส่งผลต่อการส่งออกไปยังทุกรูปแบบ (PDF, PNG, SVG, HTML) หรือไม่?**  
ใช่ ฟอนท์ที่เชื่อมต่อจะถูกใช้โดยเรนเดอร์สำหรับทุกรูปแบบการส่งออก

**ฟอนท์แบบกำหนดเองจะถูกฝังโดยอัตโนมัติในไฟล์ PPTX ที่สร้างหรือไม่?**  
ไม่ การลงทะเบียนฟอนท์สำหรับการเรนเดอร์ไม่เท่ากับการฝังฟอนท์ลงใน PPTX หากต้องการให้ฟอนท์อยู่ภายในไฟล์งานนำเสนอ ต้องใช้ [embedding features](/slides/th/python-java/embedded-font/)

**ฉันสามารถควบคุมพฤติกรรม fallback เมื่อฟอนท์แบบกำหนดเองไม่มี glyph บางตัวได้หรือไม่?**  
ได้ สามารถกำหนด [font substitution](/slides/th/python-java/font-substitution/), [replacement rules](/slides/th/python-java/font-replacement/) และ [fallback sets](/slides/th/python-java/fallback-font/) เพื่อระบุฟอนท์ที่ใช้เมื่อ glyph ที่ร้องขอหายไป

**ฉันสามารถใช้ฟอนท์ในคอนเทนเนอร์ Linux/Docker โดยไม่ต้องติดตั้งในระบบได้หรือไม่?**  
ได้ เพียงชี้ไปยังโฟลเดอร์ฟอนท์ของคุณเองหรือโหลดฟอนท์จากอาเรย์ไบต์ จะไม่พึ่งพาไดเรกทอรีฟอนท์ของระบบในอิมเมจคอนเทนเนอร์

**เรื่องลิขสิทธิ์—ฉันสามารถฝังฟอนท์แบบกำหนดเองใดก็ได้โดยไม่มีข้อจำกัดหรือไม่?**  
คุณต้องรับผิดชอบต่อการปฏิบัติตามลิขสิทธิ์ของฟอนท์ เงื่อนไขอาจแตกต่างกัน บางลิขสิทธิ์อาจห้ามการฝังหรือการใช้ในเชิงพาณิชย์ ควรตรวจสอบ EULA ของฟอนท์ก่อนนำผลลัพธ์ไปเผยแพร่