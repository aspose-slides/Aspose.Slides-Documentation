---
title: ส่งออกงานนำเสนอเป็น XAML ด้วย Python
linktitle: ส่งออกเป็น XAML
type: docs
weight: 30
url: /th/python-net/export-to-xaml/
keywords:
- ส่งออก PowerPoint
- ส่งออก OpenDocument
- ส่งออกงานนำเสนอ
- แปลง PowerPoint
- แปลง OpenDocument
- แปลงงานนำเสนอ
- PowerPoint เป็น XAML
- OpenDocument เป็น XAML
- งานนำเสนอเป็น XAML
- PPT เป็น XAML
- PPTX เป็น XAML
- ODP เป็น XAML
- Python
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint และ OpenDocument เป็น XAML ใน Python ด้วย Aspose.Slides—โซลูชันรวดเร็ว ไม่ต้องใช้ Office ที่คงรูปแบบของคุณไว้"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการส่งออกงานนำเสนอ PowerPoint ไปเป็น XAML โดยใช้ Aspose.Slides รวมทั้งการแนะนำสั้น ๆ เกี่ยวกับ XAML แสดงวิธีการบันทึกงานนำเสนอเป็น XAML ด้วยการตั้งค่าเริ่มต้น และสาธิตวิธีการปรับแต่งการส่งออกผ่าน [XamlOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export.xaml/xamloptions/), รวมถึงการส่งออกสไลด์ที่ซ่อนอยู่ บทความนี้ยังตอบคำถามทั่วไปบางข้อที่เกี่ยวกับฟอนต์สำรอง ความเข้ากันได้ของสแตก XAML และพฤติกรรมการส่งออกสไลด์ที่ซ่อนอยู่

## **เกี่ยวกับ XAML**

XAML เป็นภาษาการเขียนโปรแกรมเชิงอธิบายที่ช่วยให้คุณสร้างหรือเขียนส่วนติดต่อผู้ใช้สำหรับแอปพลิเคชัน โดยเฉพาะแอปที่ใช้ WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) และ Xamarin Forms.  
XAML ซึ่งเป็นภาษาที่อิงจาก XML เป็นเวอร์ชันของ Microsoft สำหรับการอธิบาย GUI คุณมักจะใช้ดีไซเนอร์ในการทำงานกับไฟล์ XAML เป็นส่วนใหญ่ แต่คุณก็ยังสามารถเขียนและแก้ไข GUI ของคุณได้

## **ส่งออกงานนำเสนอเป็น XAML ด้วยตัวเลือกเริ่มต้น**

โค้ด Python นี้แสดงวิธีการส่งออกงานนำเสนอเป็น XAML ด้วยการตั้งค่าเริ่มต้น:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```

## **ส่งออกงานนำเสนอเป็น XAML ด้วยตัวเลือกกำหนดเอง**

คุณสามารถเลือกตัวเลือกจากคลาส [XamlOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export.xaml/xamloptions/) ที่ควบคุมกระบวนการส่งออกและกำหนดการที่ Aspose.Slides จะส่งออกงานนำเสนอของคุณเป็น XAML.  

ตัวอย่างเช่น หากคุณต้องการให้ Aspose.Slides เพิ่มสไลด์ที่ซ่อนอยู่จากงานนำเสนอของคุณเมื่อต้องการส่งออกเป็น XAML คุณสามารถตั้งค่าคุณสมบัติ [export_hidden_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) ให้เป็น `True`. ดูตัวอย่างโค้ด Python นี้: 

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```

## **คำถามที่พบบ่อย**

**ฉันจะทำอย่างไรเพื่อให้แน่ใจว่าฟอนต์คาดเดาได้ หากฟอนต์เดิมไม่มีอยู่ในเครื่อง?**

กำหนดค่า [default_regular_font](https://reference.aspose.com/slides/th/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) ใน [XamlOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export.xaml/xamloptions/) — ค่าจะใช้เป็นฟอนต์สำรองเมื่อฟอนต์ต้นแบบไม่มีอยู่ ช่วยป้องกันการแทนที่ที่ไม่คาดคิด

**XAML ที่ส่งออกออกแบบมาเพื่อใช้กับ WPF เท่านั้นหรือสามารถใช้กับสต็อก XAML อื่นได้หรือไม่?**

XAML เป็นภาษามาร์กอัป UI ทั่วไปที่ใช้ใน WPF, UWP, และ Xamarin.Forms การส่งออกมุ่งเน้นไปที่ความเข้ากันได้กับสต็อก XAML ของ Microsoft; พฤติกรรมและการสนับสนุนของโครงสร้างเฉพาะขึ้นอยู่กับแพลตฟอร์มเป้าหมาย ทดสอบมาร์กอัปในสภาพแวดล้อมของคุณ

**สไลด์ที่ซ่อนอยู่ได้รับการสนับสนุนหรือไม่ และฉันจะป้องกันไม่ให้มันถูกส่งออกโดยค่าเริ่มต้นได้อย่างไร?**

โดยค่าเริ่มต้น สไลด์ที่ซ่อนจะไม่ถูกรวมไว้ คุณสามารถควบคุมพฤติกรรมนี้ได้ผ่าน [export_hidden_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) ใน [XamlOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export.xaml/xamloptions/) — ปิดการใช้งานหากคุณไม่ต้องการส่งออกสไลด์เหล่านั้น