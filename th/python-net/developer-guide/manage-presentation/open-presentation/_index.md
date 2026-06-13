---
title: เปิดงานนำเสนอใน Python
linktitle: เปิดงานนำเสนอ
type: docs
weight: 20
url: /th/python-net/open-presentation/
keywords:
- เปิด PowerPoint
- เปิดงานนำเสนอ
- เปิด PPTX
- เปิด PPT
- เปิด ODP
- โหลดงานนำเสนอ
- โหลด PPTX
- โหลด PPT
- โหลด ODP
- งานนำเสนอที่ได้รับการป้องกัน
- งานนำเสนอขนาดใหญ่
- ทรัพยากรภายนอก
- วัตถุไบนารี
- Python
- Aspose.Slides
description: "เปิดงานนำเสนอ PowerPoint (.pptx, .ppt) และ OpenDocument (.odp) อย่างง่ายดายด้วย Aspose.Slides สำหรับ Python ผ่าน .NET—เร็ว, น่าเชื่อถือ, มีฟีเจอร์ครบถ้วน."
---
## **คำนำ**

นอกจากการสร้างงานนำเสนอ PowerPoint ตั้งแต่ต้นแล้ว Aspose.Slides ยังให้คุณเปิดงานนำเสนอที่มีอยู่แล้วได้ หลังจากโหลดงานนำเสนอแล้ว คุณสามารถดึงข้อมูลเกี่ยวกับงานนำเสนอ แก้ไขเนื้อหาในสไลด์ เพิ่มสไลด์ใหม่ ลบสไลด์ที่มีอยู่ และทำอย่างอื่นได้อีกมากมาย

## **เปิดงานนำเสนอ**

เพื่อเปิดงานนำเสนอที่มีอยู่แล้ว ให้สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) และส่งพาธของไฟล์ไปยังคอนสตรักเตอร์

ตัวอย่าง Python ด้านล่างแสดงวิธีเปิดงานนำเสนอและรับจำนวนสไลด์:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation และส่งพาธของไฟล์ไปยังคอนสตรักเตอร์ของมัน.
with slides.Presentation("sample.pptx") as presentation:
    # พิมพ์จำนวนสไลด์ทั้งหมดในงานนำเสนอ.
    print(presentation.slides.length)
```

## **เปิดงานนำเสนอที่มีรหัสผ่าน**

เมื่อคุณต้องการเปิดงานนำเสนอที่มีรหัสผ่าน ให้ส่งรหัสผ่านผ่านคุณสมบัติ [password](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/password/) ของคลาส [LoadOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/) เพื่อถอดรหัสและโหลด งานนำเสนอ ตัวอย่างโค้ด Python ด้านล่างแสดงการทำงานนี้:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # ทำการดำเนินการบนงานนำเสนอที่ถอดรหัสแล้ว.
```

## **เปิดงานนำเสนอขนาดใหญ่**

Aspose.Slides มีตัวเลือก—โดยเฉพาะคุณสมบัติ [blob_management_options](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/blob_management_options/) ในคลาส [LoadOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/)—เพื่อช่วยคุณโหลดงานนำเสนอขนาดใหญ่

โค้ด Python นี้แสดงการโหลดงานนำเสนอขนาดใหญ่ (เช่น 2 GB):

```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# เลือกพฤติกรรม KeepLocked—ไฟล์งานนำเสนอจะถูกล็อกตลอดอายุของ 
# อินสแตนซ์ Presentation แต่ไม่จำเป็นต้องโหลดลงหน่วยความจำหรือคัดลอกไปยังไฟล์ชั่วคราว.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # งานนำเสนอขนาดใหญ่ได้ถูกโหลดแล้วและสามารถใช้งานได้ ในขณะที่การใช้หน่วยความจำยังคงต่ำ.

    # ทำการเปลี่ยนแปลงงานนำเสนอ.
    presentation.slides[0].name = "Large presentation"

    # บันทึกงานนำเสนอลงไฟล์อื่น การใช้หน่วยความจำยังคงต่ำในระหว่างการดำเนินการนี้.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # อย่าทำอย่างนี้! จะเกิดข้อยกเว้น I/O เนื่องจากไฟล์ถูกล็อกจนกว่าอ็อบเจกต์งานนำเสนอจะถูกทำลาย.
    os.remove(file_path)

# ทำได้ที่นี่ไฟล์ต้นทางไม่ได้ถูกล็อกโดยอ็อบเจกต์งานนำแล้ว.
os.remove(file_path)
```

{{% alert color="info" title="Info" %}}
เพื่อหลีกเลี่ยงข้อจำกัดบางประการเมือทำงานกับสตรีม Aspose.Slides อาจคัดลอกเนื้อหาของสตรีม การโหลดงานนำเสนอขนาดใหญ่จากสตรีมทำให้ต้องคัดลอกงานนำเสนอและอาจทำให้การโหลดช้าลง ดังนั้นเมื่อคุณต้องการโหลดงานนำเสนอขนาดใหญ่ เราขอแนะนำอย่างยิ่งให้ใช้พาธของไฟล์งานนำเสนอแทนการใช้สตรีม

เมื่อสร้างงานนำเสนอที่มีวัตถุขนาดใหญ่ (วิดีโอ, เสียง, รูปความละเอียดสูง ฯลฯ) คุณสามารถใช้ [BLOB management](/slides/th/python-net/manage-blob/) เพื่อลดการใช้หน่วยความจำ
{{%/alert %}}

## **โหลดงานนำเสนอโดยไม่มีวัตถุไบนารีฝัง**

งานนำเสนอ PowerPoint สามารถประกอบด้วยวัตถุไบนารีฝังประเภทต่อไปนี้:

- โครงการ VBA (เข้าถึงได้ผ่าน [Presentation.vba_project](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/vba_project/));
- ข้อมูลที่ฝังอยู่ของวัตถุ OLE (เข้าถึงได้ผ่าน [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/th/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- ข้อมูลไบนารีของคอนโทรล ActiveX (เข้าถึงได้ผ่าน [Control.active_x_control_binary](https://reference.aspose.com/slides/th/python-net/aspose.slides/control/active_x_control_binary/)).

โดยใช้คุณสมบัติ [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) คุณสามารถโหลดงานนำเสนอโดยไม่มีวัตถุไบนารีฝังใด ๆ

คุณสมบัตินี้มีประโยชน์สำหรับการลบเนื้อหาไบนารีที่อาจเป็นอันตราย ตัวอย่างโค้ด Python ด้านล่างแสดงวิธีโหลดงานนำเสนอโดยไม่มีเนื้อหาไบนารีฝังใด ๆ:

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # ทำการดำเนินการบนงานนำเสนอ.
```

## **FAQ**

**ฉันจะรู้ได้อย่างไรว่าไฟล์เสียหายและไม่สามารถเปิดได้?**

คุณจะได้รับข้อยกเว้นการตรวจสอบรูปแบบ/การพาร์เซิงระหว่างการโหลด ข้อผิดพลาดเหล่านี้มักจะระบุโครงสร้าง ZIP ที่ไม่ถูกต้องหรือบันทึก PowerPoint ที่เสียหาย

**ถ้าฟอนต์ที่จำเป็นหายไปขณะเปิดจะเกิดอะไรขึ้น?**

ไฟล์จะเปิดได้ แต่ภายหลังการ [rendering/export](/slides/th/python-net/convert-presentation/) อาจแทนที่ฟอนต์ด้วยฟอนต์อื่น คุณสามารถ [Configure font substitutions](/slides/th/python-net/font-substitution/) หรือ [add the required fonts](/slides/th/python-net/custom-font/) ไปยังสภาพแวดล้อมการทำงาน

**ส่วนสื่อที่ฝังอยู่ (วิดีโอ/เสียง) จะเป็นอย่างไรเมื่อเปิด?**

สื่อเหล่านั้นจะถูกทำให้เป็นทรัพยากรของงานนำเสนอ หากสื่อถูกอ้างอิงผ่านพาธภายนอก ให้แน่ใจว่าพาธเหล่านั้นเข้าถึงได้ในสภาพแวดล้อมของคุณ ไม่เช่นนั้นการ [rendering/export](/slides/th/python-net/convert-presentation/) อาจละเว้นสื่อนั้น.