---
title: แปลงงานนำเสนอ PowerPoint เป็น XPS ด้วย Python
linktitle: PowerPoint เป็น XPS
type: docs
weight: 70
url: /th/python-net/convert-powerpoint-to-xps/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- PowerPoint เป็น XPS
- งานนำเสนอเป็น XPS
- PPT เป็น XPS
- PPTX เป็น XPS
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "แปลง PowerPoint PPT/PPTX เป็น XPS คุณภาพสูง ไม่ขึ้นกับแพลตฟอร์ม ด้วย Python และ Aspose.Slides. รับคำแนะนำขั้นตอนต่อขั้นและตัวอย่างโค้ด."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณแปลงงานนำเสนอ PowerPoint ไปเป็น XPS โดยการบันทึกไฟล์ PPT หรือ PPTX ในรูปแบบ XPS บทความนี้อธิบายว่าเมื่อใดที่รูปแบบ XPS จะเป็นประโยชน์และแสดงวิธีทำการแปลงด้วย Aspose.Slides โดยใช้การตั้งค่าเริ่มต้นหรือการตั้งค่าแบบกำหนดเองของ [XpsOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/xpsoptions/)  

## **เกี่ยวกับ XPS**

Microsoft พัฒนา [XPS](https://docs.fileformat.com/page-description-language/xps/) เป็นทางเลือกของ [PDF](https://docs.fileformat.com/pdf/) ซึ่งช่วยให้คุณพิมพ์เนื้อหาโดยสร้างไฟล์ที่คล้ายกับ PDF รูปแบบ XPS ใช้พื้นฐาน XML โครงสร้างของไฟล์ XPS จะคงเดิมบนทุกระบบปฏิบัติการและเครื่องพิมพ์  

## เมื่อใดควรใช้รูปแบบ XPS ของ Microsoft

{{% alert color="primary" %}} 

เพื่อดูว่า Aspose.Slides แปลงงานนำเสนอ PPT หรือ PPTX เป็นรูปแบบ XPS อย่างไร คุณสามารถตรวจสอบ [แอปแปลงออนไลน์ฟรีนี้](https://products.aspose.app/slides/th/conversion)  

{{% /alert %}} 

หากคุณต้องการลดต้นทุนการจัดเก็บข้อมูล คุณสามารถแปลงงานนำเสนอ Microsoft PowerPoint ของคุณเป็นรูปแบบ XPS ได้ วิธีนี้จะทำให้การบันทึก การแชร์ และการพิมพ์เอกสารของคุณง่ายขึ้น  

Microsoft ยังคงสนับสนุน XPS อย่างเต็มรูปแบบใน Windows (แม้ใน Windows 10) ดังนั้นคุณอาจพิจารณาบันทึกไฟล์เป็นรูปแบบนี้ หากคุณทำงานกับ Windows 8.1, Windows 8, Windows 7 และ Windows Vista XPS อาจเป็นตัวเลือกที่ดีที่สุดสำหรับบางการดำเนินการ  

- **Windows 8** ใช้รูปแบบ OXPS (Open XPS) สำหรับไฟล์ XPS OXPS เป็นเวอร์ชันมาตรฐานของรูปแบบ XPS ดั้งเดิม Windows 8 ให้การสนับสนุนไฟล์ XPS ดีกว่าไฟล์ PDF  
  - **XPS:** มีตัวแสดง/อ่าน XPS ในตัวและฟีเจอร์การพิมพ์เป็น XPS พร้อมใช้งาน  
  - **PDF:** มีตัวอ่าน PDF แต่ไม่มีฟีเจอร์การพิมพ์เป็น PDF  

- **Windows 7 และ Windows Vista** ใช้รูปแบบ XPS ดั้งเดิม ระบบปฏิบัติการเหล่านี้ยังให้การสนับสนุนไฟล์ XPS ดีกว่า PDF ด้วย  
  - **XPS:** มีตัวแสดง XPS ในตัวและฟีเจอร์การพิมพ์เป็น XPS พร้อมใช้งาน  
  - **PDF:** ไม่มีตัวอ่าน PDF และไม่มีฟีเจอร์การพิมพ์เป็น PDF  

|<p>**อินพุต PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**เอาต์พุต XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft ไม่นานมานี้ได้เพิ่มการรองรับการพิมพ์เป็น PDF ผ่านฟีเจอร์ Print to PDF ใน Windows 10 ก่อนหน้านี้ผู้ใช้ต้องพิมพ์เอกสารผ่านรูปแบบ XPS  

## การแปลง XPS ด้วย Aspose.Slides

ใน [**Aspose.Slides**](https://products.aspose.com/slides/th/python-net/) สำหรับ .NET คุณสามารถใช้เมธอด [**Save**](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) เพื่อแปลงงานนำเสนอทั้งหมดเป็นเอกสาร XPS  

เมื่อแปลงงานนำเสนอเป็น XPS คุณต้องบันทึกงานนำเสนอโดยใช้การตั้งค่าใดการตั้งหน้าต่อไปนี้:  

- การตั้งค่าเริ่มต้น (โดยไม่มี [**XPSOptions**](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/xpsoptions/))  
- การตั้งค่าแบบกำหนดเอง (โดยใช้ [**XPSOptions**](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/xpsoptions/))  

### **แปลงงานนำเสนอเป็น XPS ด้วยการตั้งค่าเริ่มต้น**

ตัวอย่างโค้ดใน Python นี้แสดงวิธีแปลงงานนำเสนอเป็นเอกสาร XPS ด้วยการตั้งค่ามาตรฐาน:  

```py
import aspose.slides as slides

# สร้างออบเจกต์ Presentation ที่แสดงไฟล์งานนำเสนอ
pres = slides.Presentation("Convert_XPS.pptx")

# บันทึกงานนำเสนอเป็นเอกสาร XPS
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```

### **แปลงงานนำเสนอเป็น XPS ด้วยการตั้งค่าแบบกำหนดเอง**

ตัวอย่างโค้ดนี้แสดงวิธีแปลงงานนำเสนอเป็นเอกสาร XPS ด้วยการตั้งค่าแบบกำหนดเองใน Python:  

```py
import aspose.slides as slides

# สร้างอ็อบเจกต์ Presentation ที่แสดงไฟล์งานนำเสนอ
pres = slides.Presentation("Convert_XPS_Options.pptx")

# สร้างอ็อบเจกต์คลาส TiffOptions
options = slides.export.XpsOptions()

# บันทึก MetaFiles เป็น PNG
options.save_metafiles_as_png = True

# บันทึกงานนำเสนอเป็นเอกสาร XPS
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```

## **คำถามที่พบบ่อย**

**ฉันสามารถบันทึกเป็น XPS ลงในสตรีมแทนไฟล์ได้หรือไม่?**  

ใช่—Aspose.Slides ให้คุณส่งออกโดยตรงเป็นสตรีม ซึ่งเหมาะกับ Web API, พิพพลิเคชันฝั่งเซิร์ฟเวอร์ หรือกรณีใด ๆ ที่ต้องการส่ง XPS โดยไม่ต้องเขียนไฟล์ลงระบบ  

**สไลด์ที่ซ่อนอยู่จะถูกนำเข้าไปใน XPS หรือไม่และฉันสามารถเอาออกได้หรือไม่?**  

โดยค่าเริ่มต้นจะเรนเดอร์เฉพาะสไลด์ที่มองเห็นได้ คุณสามารถ [รวมหรือยกเว้นสไลด์ที่ซ่อนอยู่](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) ผ่าน [การตั้งค่าการส่งออก](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/xpsoptions/) ก่อนบันทึกเป็น XPS เพื่อให้ผลลัพธ์มีหน้าตรงตามที่ต้องการ.