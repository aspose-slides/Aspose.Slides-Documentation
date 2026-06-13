---
title: ทำให้การแทนที่ฟอนต์ในงานนำเสนอด้วย Python มีประสิทธิภาพสูงสุด
linktitle: การแทนที่ฟอนต์
type: docs
weight: 60
url: /th/python-net/font-replacement/
keywords:
- ฟอนต์
- แทนที่ฟอนต์
- การแทนที่ฟอนต์
- เปลี่ยนฟอนต์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "แทนที่ฟอนต์ใน Aspose.Slides Python ผ่าน .NET อย่างราบรื่นเพื่อให้การจัดพิมพ์ในงานนำเสนอ PowerPoint และ OpenDocument มีความสอดคล้องกัน"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณสามารถแทนที่ฟอนต์หนึ่งด้วยอีกฟอนต์หนึ่งทั่วทั้งงานนำเสนอ เมื่อฟอนต์ถูกแทนที่ ทุกตำแหน่งที่ใช้ฟอนต์เดิมจะถูกเปลี่ยนเป็นฟอนต์ใหม่

เพื่อทำการแทนที่ฟอนต์ ให้โหลดงานนำเสนอ กำหนดฟอนต์ต้นฉบับและฟอนต์ที่จะแน��ที่ แล้วเรียกใช้เมธอดการแทนที่ฟอนต์และบันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX วิธีนี้มีประโยชน์เมื่อคุณต้องการเปลี่ยนครอบครัวฟอนต์จากหนึ่งเป็นอีกหนึ่งทั่วทั้งงานนำเสนอโดยเจตนา

## **แทนที่ฟอนต์**

หากคุณเปลี่ยนใจเกี่ยวกับการใช้ฟอนต์ คุณสามารถแทนที่ฟอนต์นั้นด้วยฟอนต์อื่นได้ ทุกตำแหน่งที่ใช้ฟอนต์เก่าจะถูกแทนที่ด้วยฟอนต์ใหม่

Aspose.Slides ให้คุณแทนที่ฟอนต์ได้ดังนี้:

1. โหลดงานนำเสนอที่เกี่ยวข้อง.  
2. โหลดฟอนต์ที่จะถูกแทนที่.  
3. โหลดฟอนต์ใหม่.  
4. ทำการแทนที่ฟอนต์.  
5. เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX.

โค้ด Python นี้แสดงการแทนที่ฟอนต์:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# โหลดงานนำเสนอ
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # โหลดฟอนต์ต้นฉบับที่จะถูกแทนที่
    sourceFont = slides.FontData("Arial")

    # โหลดฟอนต์ใหม่
    destFont = slides.FontData("Times New Roman")

    # แทนที่ฟอนต์
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # บันทึกงานนำเสนอ
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Note" color="warning" %}} 
เพื่อกำหนดกฎที่บ่งบอกว่ามีเหตุการณ์อะไรเกิดขึ้นในเงื่อนไขบางอย่าง (เช่น หากไม่สามารถเข้าถึงฟอนต์ได้) ดู [**การแทนที่ฟอนต์**](/slides/th/python-net/font-substitution/). 
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่าง “font replacement”, “font substitution”, และ “fallback fonts” คืออะไร?**

การแทนที่เป็นการสลับโดยเจตนาจากครอบครัวฟอนต์หนึ่งเป็นอีกครอบครัวหนึ่งทั่วทั้งเอกสาร [Substitution](/slides/th/python-net/font-substitution/) คือกฎเช่น “หากฟอนต์ไม่พร้อมใช้งาน ให้ใช้ X.” [Fallback](/slides/th/python-net/fallback-font/) จะถูกใช้เฉพาะกรณีตัวอักษรที่ขาดหายเมื่อฟอนต์พื้นฐานถูกติดตั้งแล้วแต่ไม่มีอักขระที่ต้องการ

**การแทนที่มีผลต่อ master slides, layouts, notes, และ comments หรือไม่?**

ใช่ การแทนที่จะส่งผลต่อวัตถุทั้งหมดในงานนำเสนอที่ใช้ฟอนต์เดิม รวมถึง master slides และ notes; comments ก็เป็นส่วนหนึ่งของเอกสารและจะได้รับการพิจารณาจากเอ็นจิ้นฟอนต์

**ฟอนต์ภายในวัตถุ OLE ที่ฝังอยู่ (เช่น Excel) จะถูกเปลี่ยนหรือไม่?**

ไม่ [OLE content](/slides/th/python-net/manage-ole/) ถูกควบคุมโดยแอปพลิเคชันของตนเอง การแทนที่ในงานนำเสนอจะไม่ทำการจัดรูปแบบใหม่ให้ข้อมูล OLE ภายใน; มันอาจแสดงเป็นภาพหรือเป็นเนื้อหาที่สามารถแก้ไขจากภายนอกได้

**ฉันสามารถแทนที่ฟอนต์ได้เฉพาะบางส่วนของงานนำเสนอ (โดยสไลด์หรือพื้นที่) หรือไม่?**

การแทนที่แบบเจาะจงเป็นไปได้หากคุณเปลี่ยนฟอนต์ในระดับของวัตถุ/ช่วงที่ต้องการแทนที่จะใช้การแทนที่ทั่วทั้งเอกสารตรรกะการเลือกฟอนต์โดยรวมระหว่างการเรนเดอร์จะยังคงเหมือนเดิม

**ฉันจะตรวจสอบล่วงหน้าว่างานนำเสนอใช้ฟอนต์ใดบ้าง?**

ใช้ [font manager](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/): มันให้รายการของ [families in use](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/get_fonts/) และข้อมูลเกี่ยวกับ [substitutions/"unknown" fonts](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/get_substitutions/) ซึ่งช่วยวางแผนการแทนที่

**การแทนที่ฟอนต์ทำงานเมื่อแปลงเป็น PDF/ภาพหรือไม่?**

ใช่ ในระหว่างการส่งออก Aspose.Slides ใช้ [font selection/substitution sequence](/slides/th/python-net/font-selection-sequence/) เดียวกัน ดังนั้นการแทนที่ที่ทำล่วงหน้าจะได้รับการพิจารณาในระหว่างการแปลง

**จำเป็นต้องติดตั้งฟอนต์เป้าหมายในระบบหรือสามารถแนบโฟลเดอร์ฟอนต์ได้หรือไม่?**

ไม่จำเป็นต้องติดตั้ง: ไลบรารีอนุญาตให้ [loading external fonts](/slides/th/python-net/custom-font/) จากโฟลเดอร์ของผู้ใช้เพื่อใช้ระหว่าง [rendering and export](/slides/th/python-net/convert-powerpoint/)

**การแทนที่จะทำให้ “tofu” (สี่เหลี่ยม) แทนตัวอักษรหายไปหายหรือไม่?**

เฉพาะเมื่อฟอนต์เป้าหมายมี glyph ที่ต้องการจริง ๆ หากไม่มี ให้ [configure fallback](/slides/th/python-net/fallback-font/) เพื่อครอบคลุมอักขระที่ขาดหาย