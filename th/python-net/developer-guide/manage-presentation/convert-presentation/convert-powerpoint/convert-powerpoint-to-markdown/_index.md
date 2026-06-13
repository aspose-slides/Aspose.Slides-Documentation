---
title: แปลงงานนำเสนอ PowerPoint เป็น Markdown ด้วย Python
linktitle: PowerPoint เป็น Markdown
type: docs
weight: 140
url: /th/python-net/convert-powerpoint-to-markdown/
keywords:
- แปลง PowerPoint เป็น Markdown
- แปลง OpenDocument เป็น Markdown
- แปลงงานนำเสนอเป็น Markdown
- แปลงสไลด์เป็น Markdown
- แปลง PPT เป็น Markdown
- แปลง PPTX เป็น Markdown
- แปลง ODP เป็น Markdown
- แปลง PowerPoint เป็น MD
- แปลง OpenDocument เป็น MD
- แปลงงานนำเสนอเป็น MD
- แปลงสไลด์เป็น MD
- แปลง PPT เป็น MD
- แปลง PPTX เป็น MD
- แปลง ODP เป็น MD
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Markdown
- Python
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint และ OpenDocument—PPT, PPTX, ODP—เป็น Markdown ที่สะอาดด้วย Aspose.Slides สำหรับ Python via .NET, ทำการอัตโนมัติเอกสารและรักษาการจัดรูปแบบ."
---
## **บทนำ**

Aspose.Slides ให้คุณแปลงการนำเสนอ PowerPoint เป็น Markdown ซึ่งเป็นประโยชน์สำหรับกระบวนการทำเอกสาร, การสร้างเว็บไซต์แบบสถิตย์, การย้ายเนื้อหา, และการเผยแพร่ข้อความที่ควบคุมด้วยเวอร์ชัน ระบบ API รองรับการส่งออกโดยตรงจากการนำเสนอ PPT และ PPTX ไปเป็นไฟล์ MD และให้ตัวเลือกเพิ่มเติมเพื่อควบคุมวิธีการแสดงเนื้อหาในสไลด์ภายในเอกสาร Markdown ที่สร้างขึ้น

คุณสามารถส่งออกการนำเสนอเป็น Markdown ธรรมดา, เลือกจากหลายรูปแบบ Markdown เช่น CommonMark และ GitHub Flavored Markdown, และกำหนดวิธีการจัดการรูปภาพระหว่างการส่งออก สำหรับการนำเสนอที่มีเนื้อหาภาพ, Aspose.Slides ยังสามารถบันทึกรูปภาพไปยังโฟลเดอร์แยกต่างหากและอ้างอิงจากไฟล์ Markdown ที่สร้างขึ้นได้

{{% alert color="warning" %}}
การส่งออก PowerPoint‑to‑Markdown **ไม่มีรูปภาพ** โดยค่าเริ่มต้น หากคุณต้องการส่งออกเอกสาร PowerPoint ที่มีรูปภาพ คุณต้องตั้งค่า `export_type = MarkdownExportType.VISUAL` และระบุ `base_path` ซึ่งเป็นที่บันทึกรูปภาพที่อ้างอิงในเอกสาร Markdown
{{% /alert %}}

## **แปลงการนำเสนอเป็น Markdown**

ตัวอย่างด้านล่างแสดงวิธีที่ง่ายที่สุดในการแปลงการนำเสนอ PowerPoint เป็น Markdown ด้วย Aspose.Slides for Python via .NET โดยใช้ค่าตั้งต้น

1. สร้างอินสแตนซ์ของ [การนำเสนอ](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) เพื่อโหลดการนำเสนอ
1. เรียก `save` เพื่อส่งออกเป็นไฟล์ Markdown

ใช้โค้ดสคริปต์ Python ด้านล่างเพื่อทำการแปลง:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:  
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **แปลงการนำเสนอเป็นรูปแบบ Markdown**

Aspose.Slides ให้คุณแปลงการนำเสนอเป็นรูปแบบ Markdown ต่าง ๆ รวมถึง Markdown พื้นฐาน, CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab, และอีก 17 รูปแบบ Markdown อื่น ๆ

ตัวอย่าง Python ต่อไปนี้แสดงวิธีแปลงการนำเสนอ PowerPoint ไปเป็น CommonMark:

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, save_options)
```

23 รูปแบบ Markdown ที่สนับสนุนถูกระบุใน enumeration [Flavor](https://reference.aspose.com/slides/th/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) ของคลาส [MarkdownSaveOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/)

## **แปลงการนำเสนอที่มีภาพเป็น Markdown**

คลาส [MarkdownSaveOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) มีคุณสมบัติและ enumeration ที่ให้คุณกำหนดไฟล์ Markdown ที่ได้ ตัวอย่างเช่น enumeration [MarkdownExportType](https://reference.aspose.com/slides/th/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) ควบคุมวิธีการจัดการรูปภาพ: `SEQUENTIAL`, `TEXT_ONLY` หรือ `VISUAL`

### **แปลงภาพแบบต่อเนื่อง**

หากต้องการให้รูปภาพปรากฏเป็นรายการแยกกัน—ต่อเนื่องกัน—ใน Markdown ที่สร้างขึ้น ให้เลือกตัวเลือก `SEQUENTIAL` ตัวอย่าง Python ด้านล่างแสดงวิธีแปลงการนำเสนอที่มีรูปภาพเป็น Markdown

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.show_hidden_slides = True
save_options.show_slide_number = True
save_options.flavor = slides.export.Flavor.GITHUB
save_options.export_type = slides.export.MarkdownExportType.SEQUENTIAL
save_options.new_line_type = slides.export.NewLineType.WINDOWS

slide_indices = [1, 3, 5]

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slide_indices, slides.export.SaveFormat.MD, save_options)
```

### **แปลงภาพแบบภาพรวม**

หากต้องการให้รูปภาพปรากฏร่วมกันใน Markdown ที่ได้ ให้เลือกตัวเลือก `VISUAL` ในโหมดนี้ รูปภาพจะถูกบันทึกลงในไดเรกทอรีปัจจุบันของแอปพลิเคชัน (และเอกสาร Markdown จะใช้เส้นทางสัมพัทธ์) หรือคุณสามารถระบุเส้นทางการส่งออกและชื่อโฟลเดอร์ที่กำหนดเองได้

ตัวอย่าง Python ด้านล่างแสดงการทำงานนี้:

```python
import os
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.export_type = slides.export.MarkdownExportType.VISUAL
save_options.images_save_folder_name = "md-images"
save_options.base_path = "c:\\documents"

with slides.Presentation("presentation.pptx") as presentation:
    file_path = os.path.join(save_options.base_path, "presentation.md")
    presentation.save(file_path, slides.export.SaveFormat.MD, save_options)
```

## **คำถามที่พบบ่อย**

**ลิงก์ไฮเปอร์ลิงก์จะคงอยู่หลังการส่งออกเป็น Markdown หรือไม่?**

ใช่ ลิงก์ข้อความ [hyperlinks](/slides/th/python-net/manage-hyperlinks/) จะถูกรักษาเป็นลิงก์ Markdown มาตรฐาน ส่วนสไลด์ [transitions](/slides/th/python-net/slide-transition/) และ [animations](/slides/th/python-net/powerpoint-animation/) จะไม่ถูกแปลง

**ฉันสามารถเร่งความเร็วการแปลงโดยรันในหลายเธรดได้หรือไม่?**

คุณสามารถทำงานแบบขนานต่อไฟล์ได้ แต่ **ห้ามแชร์** อินสแตนซ์เดียวของ [การนำเสนอ](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) ระหว่างเธรด ใช้อินสแตนซ์หรือกระบวนการแยกสำหรับแต่ละไฟล์เพื่อหลีกเลี่ยงการแย่งใช้ทรัพยากร

**รูปภาพจะถูกจัดเก็บที่ไหน และเส้นทางเป็นสัมพัทธ์หรือไม่?**

[รูปภาพ](/slides/th/python-net/image/) จะถูกส่งออกไปยังโฟลเดอร์เฉพาะ และไฟล์ Markdown จะอ้างอิงพวกมันด้วยเส้นทางสัมพัทธ์โดยค่าเริ่มต้น คุณสามารถกำหนดเส้นทางพื้นฐานของการส่งออกและชื่อโฟลเดอร์ทรัพยากรเพื่อให้โครงสร้างที่คาดการณ์ได้ในคลังจัดเก็บ.