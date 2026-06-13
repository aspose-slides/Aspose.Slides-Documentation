---
title: ปรับแต่งแบบอักษรเริ่มต้นในการนำเสนอด้วย Python
linktitle: แบบอักษรเริ่มต้น
type: docs
weight: 30
url: /th/python-net/default-font/
keywords:
- แบบอักษรเริ่มต้น
- แบบอักษรทั่วไป
- แบบอักษรปกติ
- แบบอักษรเอเชีย
- การส่งออก PDF
- การส่งออก XPS
- การส่งออกภาพ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "ตั้งค่าแบบอักษรเริ่มต้นใน Aspose.Slides สำหรับ Python เพื่อให้แน่ใจว่าการแปลง PowerPoint (PPT, PPTX) และ OpenDocument (ODP) เป็น PDF, XPS และภาพทำได้อย่างถูกต้อง."
---
## **Overview**

Aspose.Slides ให้คุณระบุแบบอักษรเริ่มต้นที่ใช้เมื่อการนำเสนอถูกเรนเดอร์ ซึ่งมีประโยชน์เมื่อสร้างภาพย่อของสไลด์หรือส่งออกรูปแบบเช่น PDF และ XPS แบบอักษรเริ่มต้นจะถูกกำหนดผ่าน `LoadOptions` ก่อนโหลดการนำเสนอ

คุณสมบัติ `default_regular_font` กำหนดแบบอักษรเริ่มต้นสำหรับข้อความทั่วไป ส่วน `default_asian_font` กำหนดแบบอักษรเริ่มต้นสำหรับข้อความเอเชีย หลังจากตั้งค่าตัวเลือกเหล่านี้แล้ว การนำเสนอสามารถโหลดและเรนเดอร์โดยใช้แบบอักษรที่ระบุได้

## **Using Default Fonts for Rendering Presentation**
Aspose.Slides ให้คุณตั้งค่าแบบอักษรเริ่มต้นสำหรับการเรนเดอร์การนำเสนอเป็น PDF, XPS หรือภาพย่อ บทความนี้แสดงวิธีกำหนด DefaultRegular Font และ DefaultAsian Font ให้ใช้เป็นแบบอักษรเริ่มต้น โปรดทำตามขั้นตอนด้านล่างเพื่อโหลดแบบอักษรจากไดเรกทอรีภายนอกโดยใช้ Aspose.Slides for Python via .NET API:

1. สร้างอินสแตนซ์ของ LoadOptions.
1. ตั้งค่า DefaultRegularFont เป็นแบบอักษรที่คุณต้องการ ในตัวอย่างต่อไปนี้ฉันใช้ Wingdings.
1. ตั้งค่า DefaultAsianFont เป็นแบบอักษรที่คุณต้องการ ฉันใช้ Wingdings ในตัวอย่างต่อไปนี้.
1. โหลดการนำเสนอโดยใช้ Presentation และตั้งค่าตัวเลือกการโหลด.
1. ตอนนี้สร้างภาพย่อของสไลด์, PDF และ XPS เพื่อยืนยันผลลัพธ์.

การดำเนินการของข้างต้นแสดงด้านล่าง

```py
import aspose.slides as slides

# ใช้ตัวเลือกการโหลดเพื่อกำหนดแบบอักษรปกติและเอเชียเริ่มต้น# ใช้ตัวเลือกการโหลดเพื่อกำหนดแบบอักษรปกติและเอเชียเริ่มต้น
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# โหลดการนำเสนอ
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # สร้างภาพย่อของสไลด์
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # สร้าง PDF
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # สร้าง XPS
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```

## **FAQ**

**What exactly do default_regular_font and default_asian_font affect—only export, or also thumbnails, PDF, XPS, HTML, and SVG?**

พวกเขามีส่วนร่วมในกระบวนการเรนเดอร์สำหรับผลลัพธ์ที่รองรับทั้งหมด รวมถึงภาพย่อของสไลด์, [PDF](/slides/th/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/th/python-net/convert-powerpoint-to-xps/), [raster images](/slides/th/python-net/convert-powerpoint-to-png/), [HTML](/slides/th/python-net/convert-powerpoint-to-html/), และ [SVG](/slides/th/python-net/render-a-slide-as-an-svg-image/), เนื่องจาก Aspose.Slides ใช้ตรรกะการวางเลย์เอาต์และการแก้ไข glyph เดียวกันในทุกเป้าหมาย

**Are default fonts applied when simply reading and saving a PPTX without any rendering?**

ไม่  เมื่ออ่านและบันทึก PPTX อย่างตรง ๆ แบบอักษรเริ่มต้นจะไม่ถูกนำไปใช้ การเปิด‑บันทึกแบบเปิด‑บันทึกไม่ทำการวัดหรือวาดข้อความ ดังนั้นแบบอักษรเริ่มต้นจะเข้ามามีบทบาทเฉพาะในปฏิบัติการที่ต้องเรนเดอร์หรือจัดเรียงข้อความใหม่

**If I add my own font folders or supply fonts from memory, will they be considered when choosing default fonts?**

ใช่  [Custom font sources](/slides/th/python-net/custom-font/) จะขยายแคตาล็อกของครอบครัวและ glyph ที่เครื่องยนต์สามารถใช้ได้ แบบอักษรเริ่มต้นและ [fallback rules](/slides/th/python-net/fallback-font/) จะค้นหาจากแหล่งเหล่านี้ก่อน ทำให้ครอบคลุมได้ดีขึ้นในเซิร์ฟเวอร์และคอนเทนเนอร์

**Will default fonts affect text metrics (kerning, advances) and therefore line breaks and wrapping?**

ใช่  การเปลี่ยนแบบอักษรจะเปลี่ยนเมตริกของ glyph และอาจทำให้การตัดบรรทัด, การห่อข้อความ, และการแบ่งหน้าในระหว่างการเรนเดอร์เปลี่ยนแปลงได้ เพื่อความเสถียรของเลย์เอาต์ ควร [embed the original fonts](/slides/th/python-net/embedded-font/) หรือเลือกครอบครัวแบบอักษรเริ่มต้นและสำรองที่มีเมตริกสอดคล้องกัน

**Is there any point in setting default fonts if all fonts used in the presentation are embedded?**

บางครั้งอาจไม่จำเป็น เพราะ [embedded fonts](/slides/th/python-net/embedded-font/) ทำให้แสดงผลสอดคล้องกันอยู่แล้ว อย่างไรก็ตามแบบอักษรเริ่มต้นยังคงเป็นเครือข่ายความปลอดภัยสำหรับตัวอักษรที่ไม่ได้รวมอยู่ในชุดฝังหรือเมื่อไฟล์มีข้อความผสมระหว่างที่ฝังและไม่ได้ฝัง