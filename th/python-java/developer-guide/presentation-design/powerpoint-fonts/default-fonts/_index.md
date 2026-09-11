---
title: กำหนดแบบอักษรเริ่มต้นสำหรับการนำเสนอใน Python ผ่าน Java
linktitle: แบบอักษรเริ่มต้น
type: docs
weight: 30
url: /th/python-java/default-font/
keywords:
- แบบอักษรเริ่มต้น
- แบบอักษรปกติ
- แบบอักษรธรรมดา
- แบบอักษรเอเชีย
- การส่งออก PDF
- การส่งออก XPS
- การส่งออกภาพ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "กำหนดแบบอักษรเริ่มต้นใน Aspose.Slides สำหรับ Python ผ่าน Java เพื่อให้การแปลง PowerPoint (PPT, PPTX) และ OpenDocument (ODP) เป็น PDF, XPS และภาพทำได้อย่างถูกต้อง"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณกำหนดแบบอักษรเริ่มต้นที่ใช้เมื่อการนำเสนอถูกเรนเดอร์ ซึ่งมีประโยชน์เมื่อสร้างภาพย่อของสไลด์หรือส่งออกการนำเสนอเป็นรูปแบบเช่น PDF และ XPS แบบอักษรเริ่มต้นจะถูกกำหนดค่าผ่าน [LoadOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/) ก่อนที่การนำเสนอจะถูกโหลด

วิธีการ [setDefaultRegularFont](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) กำหนดแบบอักษรเริ่มต้นสำหรับข้อความปกติ ในขณะที่ [setDefaultAsianFont](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) กำหนดแบบอักษรเริ่มต้นสำหรับข้อความเอเชีย หลังจากตั้งค่าตัวเลือกเหล่านี้แล้ว การนำเสนอสามารถโหลดและเรนเดอร์โดยใช้แบบอักษรที่ระบุได้

## **ใช้แบบอักษรเริ่มต้นสำหรับการเรนเดอร์การนำเสนอ**

Aspose.Slides ให้คุณตั้งค่าแบบอักษรเริ่มต้นสำหรับการเรนเดอร์การนำเสนอเป็น PDF, XPS หรือภาพย่อ ส่วนนี้แสดงวิธีกำหนดแบบอักษรเริ่มต้นสำหรับข้อความปกติและเอเชียโดยใช้ Aspose.Slides for Python via Java:

1. สร้างอินสแตนซ์ของ [LoadOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/)  
2. ใช้ [setDefaultRegularFont](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) เพื่อระบุแบบอักษรที่ต้องการ ตัวอย่างต่อไปนี้ใช้ Wingdings  
3. ใช้ [setDefaultAsianFont](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) เพื่อระบุแบบอักษรที่ต้องการ ตัวอย่างต่อไปนี้ก็ใช้ Wingdings ด้วยเช่นกัน  
4. โหลดการนำเสนอโดยใช้ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) พร้อมกับตัวเลือกการโหลด  
5. สร้างภาพย่อของสไลด์, PDF, และ XPS เพื่อยืนยันผลลัพธ์  

ตัวอย่างต่อไปนี้ทำตามขั้นตอนเหล่านั้น:

```python
from asposeslides.api import ImageFormat, LoadFormat, LoadOptions, Presentation, SaveFormat

# ใช้ตัวเลือกการโหลดเพื่อกำหนดแบบอักษรปกติและเอเชียเริ่มต้น.
load_options = LoadOptions(LoadFormat.Auto)
load_options.setDefaultRegularFont("Wingdings")
load_options.setDefaultAsianFont("Wingdings")

# โหลดการนำเสนอ.
presentation = Presentation("DefaultFonts.pptx", load_options)
try:
    # สร้างภาพย่อของสไลด์.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # บันทึกภาพลงดิสก์.
        slide_image.save("output.png", ImageFormat.Png)
    finally:
        slide_image.dispose()

    # สร้าง PDF.
    presentation.save("output_out.pdf", SaveFormat.Pdf)

    # สร้างเอกสาร XPS.
    presentation.save("output_out.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**แบบอักษรเริ่มต้นสำหรับข้อความปกติและเอเชียส่งผลอย่างไรบ้าง—เฉพาะการส่งออกหรือรวมถึงภาพย่อ, PDF, XPS, HTML, และ SVG ด้วย?**  
พวกเขามีส่วนร่วมในขั้นตอนการเรนเดอร์สำหรับผลลัพธ์ที่รองรับทั้งหมด ซึ่งรวมถึงภาพย่อของสไลด์, [PDF](/slides/th/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/th/python-java/convert-powerpoint-to-xps/), [raster images](/slides/th/python-java/convert-powerpoint-to-png/), [HTML](/slides/th/python-java/convert-powerpoint-to-html/), และ [SVG](/slides/th/python-java/render-a-slide-as-an-svg-image/), เนื่องจาก Aspose.Slides ใช้ตรรกะการจัดวางและการแก้ไข glyph เดียวกันสำหรับเป้าหมายเหล่านี้

**แบบอักษรเริ่มต้นจะถูกนำไปใช้เมื่อเพียงอ่านและบันทึกไฟล์ PPTX โดยไม่มีการเรนเดอร์หรือไม่?**  
ไม่ใช่ แบบอักษรเริ่มต้นมีบทบาทเมื่อข้อความต้องถูกวัดและวาด การบันทึกเปิด‑ปิดแบบตรง ๆ ของการนำเสนอจะไม่เปลี่ยนแปลงการเก็บฟอนต์หรือโครงสร้างของไฟล์ แบบอักษรเริ่มต้นจะมีผลในกระบวนการที่เรนเดอร์หรือจัดข้อความใหม่

**ถ้าฉันเพิ่มโฟลเดอร์แบบอักษรของฉันเองหรือให้ฟอนต์จากหน่วยความจำ ระบบจะพิจารณาเป็นตัวเลือกแบบอักษรเริ่มต้นหรือไม่?**  
ใช่ [Custom font sources](/slides/th/python-java/custom-font/) จะขยายแคตาล็อกของฟอนต์และ glyph ที่เอนจินสามารถใช้ได้ แบบอักษรเริ่มต้นและ [fallback rules](/slides/th/python-java/fallback-font/) จะตรวจสอบจากแหล่งเหล่านี้ก่อน ทำให้ครอบคลุมได้ดีขึ้นบนเซิร์ฟเวอร์และคอนเทนเนอร์

**แบบอักษรเริ่มต้นจะส่งผลต่อเมตริกของข้อความ (เช่น kerning, advances) และทำให้การตัดบรรทัดหรือการตัดบรรทัดอัตโนมัติต่าง ๆ เปลี่ยนแปลงหรือไม่?**  
ใช่ การเปลี่ยนแบบอักษรจะเปลี่ยนเมตริกของ glyph และอาจทำให้การตัดบรรทัด, การตัดบรรทัดอัตโนมัติ, และการจัดหน้าในระหว่างการเรนเดอร์เปลี่ยนแปลงได้ เพื่อรักษาเสถียรภาพของการจัด layout ควร [embed the original fonts](/slides/th/python-java/embedded-font/) หรือเลือกฟอนต์เริ่มต้นและ fallback ที่เข้ากันทางเมตริก

**การตั้งค่าแบบอักษรเริ่มต้นมีประโยชน์ไหมหากฟอนต์ทั้งหมดที่ใช้ในการนำเสนอถูกฝังไว้แล้ว?**  
บ่อยครั้งไม่จำเป็น เพราะ [embedded fonts](/slides/th/python-java/embedded-font/) ทำให้ลักษณะการแสดงผลคงที่อยู่แล้ว อย่างไรก็ตามแบบอักษรเริ่มต้นยังคงเป็นเครือข่ายความปลอดภัยสำหรับอักขระที่ไม่ได้ครอบคลุมโดยฟอนต์ที่ฝังไว้ หรือเมื่อไฟล์มีการผสมระหว่างข้อความที่ฝังฟอนต์และข้อความที่ไม่ได้ฝังฟอนต์.