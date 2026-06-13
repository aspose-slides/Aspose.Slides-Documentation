---
title: "คำถามที่พบบ่อย"
type: docs
weight: 340
url: /th/python-net/faq/
keywords:
- "คำถามที่พบบ่อย"
- "รูปแบบงานนำเสนอ"
- "ข้อผิดพลาดหน่วยความจำไม่พอ"
- "ขนาดสไลด์"
- "ดึงข้อความ"
- "เรียกคืนข้อความ"
- "ขนาดย่อหน้า"
- "การจัดรูปแบบตาราง"
- "ฟอนต์"
- "PowerPoint"
- "OpenDocument"
- "งานนำเสนอ"
- "Python"
- "Aspose.Slides"
description: "รับคำตอบสำหรับคำถามที่พบบ่อยเกี่ยวกับ Aspose.Slides สำหรับ Python ผ่าน .NET รวมถึงการสนับสนุน PowerPoint และ OpenDocument คำแนะนำการติดตั้ง การให้สิทธิ์การใช้งาน และการแก้ไขปัญหา"
---
## **Overview**

คำถามที่พบบ่อยนี้ให้คำตอบสำหรับคำถามทั่วไปเกี่ยวกับ Aspose.Slides รวมถึงรูปแบบไฟล์ที่รองรับ การจัดการข้อยกเว้นเมื่อทำงานกับงานนำเสนอขนาดใหญ่ การเปลี่ยนขนาดสไลด์ การแสดงตัวอย่างสไลด์ การดึงข้อความจากงานนำเสนอ การจัดรูปแบบขอบตาราง การวางภาพ และการแก้ไขปัญหาเรื่องฟอนต์เมื่อแปลงงานนำเสนอเป็น PDF หรือภาพ

## **Supported File Formats**

**Q: What file formats does Aspose.Slides for Python via .NET support?**  
**A**: Aspose.Slides for Python via .NET รองรับรูปแบบไฟล์ที่อธิบายอยู่ใน [Supported File Formats](/slides/th/python-net/supported-file-formats/).

## **Exceptions**

**Q: I am getting an out of memory exception while loading a large PPT file with images. Is there a limitation in Aspose.Slides regarding file size?**  
**A**: ไม่มีสูตรเฉพาะใด ๆ สำหรับการคำนวนขนาดของงานนำเสนอที่ Aspose.Slides รองรับ ควรมีพื้นที่เพียงพอเพื่อเก็บโครงสร้างงานนำเสนอทั้งหมดและรูปภาพในหน่วยความจำ โดยทั่วไปรูปภาพในหน่วยความจำจะใช้พื้นที่มากกว่าบนฮาร์ดดิสก์ โดยเฉพาะเมื่อรูปภาพมีเอฟเฟกต์เพิ่มเติม

โดยทั่วไป Aspose.Slides for Python via .NET สามารถจัดการไฟล์งานนำเสนอขนาดประมาณ 300 MB ได้อย่างง่ายดายบนเซิร์ฟเวอร์ที่มี RAM 4 GB

## **Working with Slides**

**Q: Can I change the size of the slides in a presentation?**  
**A**: คุณสามารถใช้คุณสมบัติ `slide_size` ที่เปิดเผยโดยคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) เพื่อกำหนดขนาดของสไลด์ในงานนำเสนอ

**Q: Is there a way to define slides of different size in a presentation?**  
**A**: เนื่องจากขนาดของสไลด์ถูกกำหนดที่ระดับงานนำเสนอในเอกสาร Microsoft PowerPoint จึงไม่มีวิธีทำเช่นนั้น

**Q: Does Aspose.Slides for Python via .NET support previewing a slide before saving?**  
**A**: คุณสามารถเรนเดอร์สไลด์ของงานนำเสนอเป็นภาพและใช้ภาพเหล่านั้นเพื่อแสดงตัวอย่างสไลด์ได้

## **Working with Text**

**Q: Is it possible to retrieve all the text from a presentation?**  
**A**: Aspose.Slides for Python via .NET มีคลาส [SlideUtil](https://reference.aspose.com/slides/th/python-net/aspose.slides.util/slideutil/) ภายใต้เนมสเปซ `aspose.slides.util` ซึ่งให้เมธอดต่าง ๆ สำหรับดึงข้อความทั้งหมดจากงานนำเสนอ

**Q: Why are paragraph sizes different on Windows and Linux operating systems?**  
**A**: การคำนวนขนาดย่อหน้าขึ้นอยู่กับการคำนวนขนาดข้อความที่แสดงย่อหน้านั้น ขนาดข้อความคำนวนจากเมตริกของฟอนต์ที่ระบุในงานนำเสนอ PowerPoint หากฟอนต์ที่ระบุไม่มีอยู่ ระบบจะเปลี่ยนเป็นฟอนต์ที่ใกล้เคียงที่สุด แต่ฟอนต์นั้นมีเมตริกที่แตกต่างจากฟอนต์เดิม ดังนั้นการคำนวนขนาดย่อหน้าในระบบต่าง ๆ จะให้ผลลัพธ์ที่ต่างกันตามชุดฟอนต์ที่ติดตั้งไว้ เพื่อให้ได้ผลลัพธ์เดียวกันบนระบบปฏิบัติการต่าง ๆ คุณต้องติดตั้งฟอนต์เดียวกันบนระบบหรือโหลดฟอนต์ในขณะทำงานเป็น [external fonts](/slides/th/python-net/custom-font/)

## **Formatting and Images**

**Q: How can I set the color of a table border?**  
**A**: คุณสามารถเปลี่ยนสีของขอบตารางทั้งหมดหรือเพียงขอบรอบตารางโดยใช้คุณสมบัติ `cell_format` จากคลาส [Cell](https://reference.aspose.com/slides/th/python-net/aspose.slides/cell/) หากต้องการเปลี่ยนสีของขอบรอบตารางทั้งหมด ให้วนลูปผ่านเซลล์และเปลี่ยนสีของขอบภายนอก

**Q: What measure does Aspose.Slides for Python via .NET use to place pictures?**  
**A**: พิกัดและขนาดของรูปร่างทั้งหมดบนสไลด์วัดเป็นหน่วย points (72 dpi)

## **Working with Fonts**

**Q: When converting PPT to PDF or images, why are the fonts different in the output documents?**  
**A**: ปัญหานี้อาจบ่งบอกว่าฟอนต์ที่ใช้ในงานนำเสนอไม่มีอยู่ในระบบปฏิบัติการที่รันโค้ด คุณควรติดตั้งฟอนต์บนระบบปฏิบัติการหรือโหลดฟอนต์เป็นฟอนต์ภายนอกโดยใช้คลาส [FontsLoader](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsloader/) ตามตัวอย่างด้านล่าง:
```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```