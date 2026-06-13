---
title: แปลงงานนำเสนอเป็น GIF เคลื่อนไหวใน Python
linktitle: งานนำเสนอเป็น GIF
type: docs
weight: 65
url: /th/python-net/convert-powerpoint-to-animated-gif/
keywords:
- GIF เคลื่อนไหว
- แปลง PowerPoint
- แปลง OpenDocument
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- แปลง ODP
- PowerPoint เป็น GIF
- OpenDocument เป็น GIF
- งานนำเสนอเป็น GIF
- สไลด์เป็น GIF
- PPT เป็น GIF
- PPTX เป็น GIF
- ODP เป็น GIF
- การตั้งค่าเริ่มต้น
- การตั้งค่ากำหนดเอง
- Python
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint (PPT, PPTX) และไฟล์ OpenDocument (ODP) เป็น GIF เคลื่อนไหวได้อย่างง่ายดายด้วย Aspose.Slides สำหรับ Python ผลลัพธ์เร็วและคุณภาพสูง"
---
## **ภาพรวม**

Aspose.Slides ให้คุณแปลงงานนำเสนอ PowerPoint เป็นไฟล์ GIF ที่เคลื่อนไหวด้วยเพียงไม่กี่บรรทัดของโค้ด สิ่งนี้มีประโยชน์เมื่อคุณต้องการแชร์เนื้อหาสไลด์ในรูปแบบที่มีน้ำหนักเบา รองรับอย่างกว้างขวางและสามารถฝังในหน้าเว็บ แชท หรือเอกสารได้ บทความนี้อธิบายวิธีส่งออกงานนำเสนอเป็น GIF ด้วยการตั้งค่าเริ่มต้นและวิธีปรับแต่งผลลัพธ์โดยกำหนดตัวเลือกเช่น ขนาดเฟรม, ความหน่วงของสไลด์, และอัตราเฟรมการเปลี่ยนผ่านผ่าน [GifOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/gifoptions/)  

## **แปลงงานนำเสนอเป็น GIF แบบเคลื่อนไหวโดยใช้การตั้งค่าเริ่มต้น**

โค้ดตัวอย่างนี้ใน Python แสดงวิธีแปลงงานนำเสนอเป็น GIF แบบเคลื่อนไหวโดยใช้การตั้งค่ามาตรฐาน:

```py
import aspose.slides as slides

pres = slides.Presentation(path + "pres.pptx")
pres.save("pres.gif", slides.export.SaveFormat.GIF)
```

GIF แบบเคลื่อนไหวจะถูกสร้างด้วยพารามิเตอร์เริ่มต้น  

{{%  alert  title="TIP"  color="primary"  %}}  
หากคุณต้องการปรับแต่งพารามิเตอร์ของ GIF คุณสามารถใช้คลาส [GifOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/gifoptions/) ดูโค้ดตัวอย่างด้านล่าง  
{{% /alert %}}  

## **แปลงงานนำเสนอเป็น GIF แบบเคลื่อนไหวโดยใช้การตั้งค่ากำหนดเอง**

โค้ดตัวอย่างนี้แสดงวิธีแปลงงานนำเสนอเป็น GIF แบบเคลื่อนไหวโดยใช้การตั้งค่ากำหนดเองใน Python:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

options = slides.export.GifOptions()
options.frame_size = drawing.Size(960, 720) # ขนาดของ GIF ที่สร้างผลลัพธ์  
options.default_delay = 2000 # ระยะเวลาที่แต่ละสไลด์จะแสดงก่อนจะเปลี่ยนเป็นสไลด์ถัดไป
options.transition_fps = 35  # เพิ่ม FPS เพื่อคุณภาพการเคลื่อนไหวการเปลี่ยนภาพที่ดียิ่งขึ้น

pres.save("pres.gif", slides.export.SaveFormat.GIF, options)
```

{{% alert title="Info" color="info" %}}  
คุณอาจต้องการลองใช้ตัวแปลง [Text to GIF](https://products.aspose.app/slides/th/text-to-gif) ฟรีที่พัฒนาโดย Aspose.  
{{% /alert %}}  

## **คำถามที่พบบ่อย**

**ถ้าฟอนต์ที่ใช้ในงานนำเสนอไม่ได้ติดตั้งบนระบบจะทำอย่างไร?**

ติดตั้งฟอนต์ที่ขาดหายไปหรือ [กำหนดค่าสำรองฟอนต์](/slides/th/python-net/powerpoint-fonts/). Aspose.Slides จะทำการแทนที่ แต่รูปลักษณ์อาจแตกต่างกัน สำหรับการสร้างแบรนด์ ควรตรวจสอบให้แน่ใจว่าฟอนต์ที่ต้องการพร้อมใช้งานอย่างชัดเจน  

**ฉันสามารถใส่น้ำลายน้ำบนเฟรมของ GIF ได้หรือไม่?**

ได้. [เพิ่มวัตถุ/โลโก้ที่โปร่งแสงบางส่วน](/slides/th/python-net/watermark/) ลงในสไลด์แม่แบบหรือสไลด์แต่ละสไลด์ก่อนการส่งออก — น้ำลายน้ำจะปรากฏบนทุกเฟรม  