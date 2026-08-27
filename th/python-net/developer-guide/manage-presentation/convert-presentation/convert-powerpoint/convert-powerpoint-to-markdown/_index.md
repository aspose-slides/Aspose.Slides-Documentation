---
title: แปลงงานนำเสนอ PowerPoint เป็น Markdown ใน Python
linktitle: PowerPoint เป็น Markdown
type: docs
weight: 140
url: /th/python-net/convert-powerpoint-to-markdown/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น MD
- งานนำเสนอเป็น MD
- สไลด์เป็น MD
- PPT เป็น MD
- PPTX เป็น MD
- บันทึก PowerPoint เป็น Markdown
- บันทึกงานนำเสนอเป็น Markdown
- บันทึกสไลด์เป็น Markdown
- บันทึก PPT เป็น MD
- บันทึก PPTX เป็น MD
- ส่งออก PPT เป็น MD
- ส่งออก PPTX เป็น MD
- การส่งออกภาพ Markdown
- ลิงก์ภาพ CDN
- PowerPoint
- งานนำเสนอ
- Markdown
- Python
- Python ผ่าน .NET
- Aspose.Slides
description: "แปลงงานนำเสนอ PPT และ PPTX เป็น Markdown ใน Python และควบคุมตำแหน่งที่บันทึกภาพที่ส่งออกและวิธีที่ Markdown ที่สร้างอ้างอิงถึงภาพเหล่านั้น"
---
## **ภาพรวม**

Aspose.Slides for Python via .NET สามารถแปลงงานนำเสนอ PPT และ PPTX เป็น Markdown เพื่อใช้ในงานเอกสาร เว็บไซต์แบบสถิต การย้ายเนื้อหา และกระบวนการควบคุมเวอร์ชัน คุณสามารถเลือกรูปแบบ Markdown ควบคุมวิธีการแสดงเนื้อหาสไลด์ และกำหนดตำแหน่งที่จัดเก็บภาพที่ส่งออกและวิธีที่ Markdown ที่สร้างอ้างอิงถึงภาพเหล่านั้นได้

โดยค่าเริ่มต้น การส่งออกเป็น Markdown จะใช้เอาต์พุตแบบข้อความเท่านั้น เพื่อส่งออกเนื้อหาภาพ ให้ตั้งค่าคุณสมบัติ [MarkdownSaveOptions.export_type](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/markdownsaveoptions/export_type/) เป็นค่า `SEQUENTIAL` หรือ `VISUAL` จาก enumeration [MarkdownExportType](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/markdownexporttype/) `SEQUENTIAL` จะเรนเดอร์รายการสไลด์แยกกันและตามลำดับ ในขณะที่ `VISUAL` จะเก็บรายการที่จัดกลุ่มไว้ด้วยกันเพื่อรักษาความสัมพันธ์เชิงภาพค่า `TEXT_ONLY` จะไม่สร้างทรัพยากรภาพ

## **แปลงงานนำเสนอเป็น Markdown**

โหลดไฟล์ต้นทางด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) แล้วเรียกเมธอด [Presentation.save](https://reference.aspose.com/slides/th/python-net/aspose.slides/ipresentation/save/) ด้วยค่า `MD` จาก enumeration [SaveFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/saveformat/)

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **เลือกรูปแบบ Markdown**

คุณสมบัติ [MarkdownSaveOptions.flavor](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/markdownsaveoptions/flavor/) ควบคุมสเปค Markdown ที่ใช้สำหรับเอาต์พุต enumeration [Flavor](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/flavor/) มี CommonMark, GitHub Flavored Markdown และรูปแบบอื่นที่รองรับ

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น CommonMark:

```python
import aspose.slides as slides

options = slides.export.MarkdownSaveOptions()
options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, options)
```

## **ส่งออกภาพโดยใช้พฤติกรรมการบันทึกแบบโลคัลเริ่มต้น**

คลาส [MarkdownSaveOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/markdownsaveoptions/) มีคุณสมบัติสองรายการสำหรับภาพที่บันทึกในเครื่อง:

- [base_path](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/markdownsaveoptions/base_path/) ระบุไดเรกทอรีฐานสำหรับเอกสาร Markdown และทรัพยากรของมัน
- [images_save_folder_name](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) ระบุโฟลเดอร์ย่อยสำหรับภาพ ค่าเริ่มต้นคือ `Images`

ตัวอย่างต่อไปนี้เรนเดอร์เนื้อหาภาพ เขียนภาพไปที่ `output/assets` และสร้างการอ้างอิงภาพแบบ relative ในเอกสาร Markdown:

```python
import os
import aspose.slides as slides

output_directory = "output"
os.makedirs(output_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = output_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(output_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

Aspose.Slides จะสร้างโฟลเดอร์ย่อยสำหรับภาพเมื่อการส่งออกสร้างทรัพยากรภาพ แต่แอปพลิเคชันต้องสร้าง `base_path` ก่อนบันทึกไฟล์ Markdown

## **เตรียม Markdown และภาพสำหรับการเผยแพร่**

Aspose.Slides for Python via .NET ไม่เปิดเผย callback การบันทึกภาพของ .NET เพื่อเปลี่ยนลิงก์ภาพที่สร้างระหว่างการส่งออก แทนที่นั้นให้ส่งออกเอกสาร Markdown และโฟลเดอร์ภาพไปยังไดเรกทอรีการเผยแพร่ แล้วเผยแพร่ไดเรกทอรีนั้นโดยไม่เปลี่ยนโครงสร้าง relative

ตัวอย่างต่อไปนี้เตรียม `cdn-origin/presentations/quarterly-report` เป็นไดเรกทอรีการเผยแพร่ที่เมานท์หรือซิงโครไนซ์ ตัวอย่างเองไม่ได้อัปโหลดเครือข่าย: ลิงก์ที่สร้างจะทำงานได้หลังจากไดเรกทอรีถูกเผยแพร่ที่ไซต์หรือตำแหน่ง CDN ที่กำหนด

```python
import os
import aspose.slides as slides

publication_directory = os.path.join(
    "cdn-origin",
    "presentations",
    "quarterly-report")
os.makedirs(publication_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = publication_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(publication_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

เผยแพร่ `presentation.md` พร้อมกับโฟลเดอร์ `assets` เอกสาร Markdown ใช้การอ้างอิงภาพแบบ relative ดังนั้นทั้งสองรายการต้องรักษาความสัมพันธ์แบบเดียวกันที่ปลายทาง หากระบบการเผยแพร่ต้องการ URL ภายนอกแบบ absolute ให้เขียนลิงก์ที่สร้างใหม่ในขั้นตอน post‑processing แยกต่างหากหลังจากไฟล์ภาพทั้งหมดถูกเผยแพร่แล้ว

## **คำถามที่พบบ่อย**

**Python callbacks สามารถปรับแต่งไฟล์ภาพและลิงก์แต่ละไฟล์ระหว่างการส่งออก Markdown ได้หรือไม่?**

ไม่ได้ Aspose.Slides for Python via .NET ไม่เปิดเผย callback `ImageSaving` และ `SvgImageSaving` ของ .NET ให้กำหนดผลลัพธ์แบบโลคัลด้วย [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/markdownsaveoptions/base_path/) และ [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) แล้วเผยแพร่หรือทำ post‑process ทรัพยากรที่สร้างขึ้น

**ภาพที่ส่งออกถูกบันทึกไว้ที่ไหน?**

ตำแหน่งภาพถูกควบคุมโดย [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/markdownsaveoptions/base_path/) และ [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) เอกสาร Markdown จะอ้างอิงภาพเหล่านั้นด้วยเส้นทางแบบ relative

**ตัวแบ่งเส้นทางควรใช้เครื่องหมายอะไรสำหรับลิงก์ภาพ?**

ใช้เครื่องหมายทั่ง (forward slash) ในลิงก์และ URL ของ Markdown ใช้ `os.path.join` เฉพาะสำหรับเส้นทางของระบบไฟล์ และทำการ normalize ลิงก์ที่สร้างในขั้นตอน post‑processing แยกต่างหาก

**ลิงก์ไฮเปอร์ลิงก์จะถูกเก็บไว้ระหว่างการส่งออก Markdown หรือไม่?**

ใช่ ข้อความ [hyperlinks](/slides/th/python-net/manage-hyperlinks/) จะถูกเก็บไว้เป็นลิงก์ Markdown มาตรฐาน สไลด์ [transitions](/slides/th/python-net/slide-transition/) และ [animations](/slides/th/python-net/powerpoint-animation/) จะไม่ถูกแปลง

**สามารถแปลงงานนำเสนอเป็น Markdown พร้อมกันหลายไฟล์ได้หรือไม่?**

คุณสามารถประมวลผลไฟล์งานนำเสนอหลายไฟล์พร้อมกันได้ แต่ห้ามแชร์อินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) เดียวกันระหว่างเธรด ให้ปฏิบัติตาม [multithreading guidelines](/slides/th/python-net/multithreading/) และใช้อินสแตนซ์แยกสำหรับแต่ละไฟล์