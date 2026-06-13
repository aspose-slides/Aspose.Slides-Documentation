---
title: ปัญหาการแสดงตัวอย่างวัตถุเมื่อเพิ่ม OleObjectFrame
linktitle: ปัญหาวัตถุ OLE
type: docs
weight: 10
url: /th/python-net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- ปัญหาการแสดงตัวอย่าง
- ฝังวัตถุ
- ฝังไฟล์
- วัตถุเปลี่ยนแปลง
- การแสดงตัวอย่างวัตถุ
- งานนำเสนอ
- PowerPoint
- Python
- Aspose.Slides
description: "เรียนรู้ว่าทำไมข้อความ EMBEDDED OLE OBJECT ปรากฏเมื่อเพิ่ม OleObjectFrame ใน Aspose.Slides สำหรับ Python และวิธีแก้ไขปัญหาการแสดงตัวอย่างในงานนำเสนอรูปแบบ PPT, PPTX และ ODP."
---
## **บทนำ**

เมื่อใช้ Aspose.Slides for Python ผ่าน .NET, หากคุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/oleobjectframe/) ลงในสไลด์ จะมีข้อความ "EMBEDDED OLE OBJECT" ปรากฏบนสไลด์ผลลัพธ์ ข้อความนี้เป็นการทำงานตามปกติและไม่ได้เป็นข้อบกพร่อง

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการทำงานกับวัตถุ OLE โปรดดูที่ [จัดการ OLE](/slides/th/python-net/manage-ole/).

## **คำอธิบายและวิธีแก้ไข**

Aspose.Slides แสดงข้อความ "EMBEDDED OLE OBJECT" เพื่อแจ้งให้คุณทราบว่ามีการเปลี่ยนแปลงวัตถุ OLE และต้องอัปเดตรูปภาพตัวอย่าง

ตัวอย่างเช่น หากคุณเพิ่มแผนภูมิ Microsoft Excel เป็น [OleObjectFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/oleobjectframe/) ลงในสไลด์ (ดูรายละเอียดเพิ่มเติมในบทความ "Manage OLE") แล้วเปิดงานนำเสนอใน Microsoft PowerPoint คุณจะเห็นรูปภาพนี้บนสไลด์:

![ข้อความวัตถุ OLE](OLE_object_message.png)

หากคุณต้องการตรวจสอบและยืนยันว่าวัตถุ OLE ของคุณถูกเพิ่มลงในสไลด์แล้ว คุณต้องดับเบิลคลิกที่ข้อความ "EMBEDDED OLE OBJECT" หรือคลิกขวาที่ข้อความแล้วเลือกตัวเลือก **Object > Edit**

![วัตถุ OLE > แก้ไข](OLE_object_edit.png)

PowerPoint จากนั้นจะเปิดวัตถุ OLE ที่ฝังไว้

![ข้อมูลวัตถุ OLE](OLE_object_data.png)

สไลด์อาจยังคงมีข้อความ "EMBEDDED OLE OBJECT" อยู่ เมื่อคุณคลิกที่วัตถุ OLE ตัวอย่างสไลด์จะได้รับการอัปเดตและข้อความ "EMBEDDED OLE OBJECT" จะถูกแทนที่ด้วยรูปภาพจริงของวัตถุ OLE

![ตัวอย่างวัตถุ OLE](OLE_object_preview.png)

ตอนนี้คุณอาจต้องการบันทึกงานนำเสนอของคุณเพื่อให้แน่ใจว่ารูปภาพของวัตถุ OLE ได้รับการอัปเดตอย่างถูกต้อง ด้วยวิธีนี้ หลังจากบันทึกงานนำเสนอแล้ว เมื่อคุณเปิดงานนำเสนออีกครั้ง คุณจะไม่เห็นข้อความ "EMBEDDED OLE OBJECT"

## **วิธีแก้ไขอื่นๆ**

### **วิธีแก้ไข 1: แทนที่ข้อความ "Embedded OLE Object" ด้วยภาพ**

หากคุณไม่ต้องการลบข้อความ "EMBEDDED OLE OBJECT" โดยเปิดงานนำเสนอใน PowerPoint แล้วบันทึก คุณสามารถแทนที่ข้อความด้วยภาพตัวอย่างที่คุณต้องการได้ บรรทัดโค้ดต่อไปนี้แสดงกระบวนการ:

```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # เพิ่มรูปภาพไปยังทรัพยากรของงานนำเสนอ.
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # ตั้งค่าชื่อเรื่องและรูปภาพสำหรับการแสดงตัวอย่างวัตถุ OLE.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```

สไลด์ที่มี `OleObjectFrame` จะเปลี่ยนเป็นดังนี้:

![ภาพวัตถุ OLE ใหม่](OLE_object_new_image.png)

### **วิธีแก้ไข 2: สร้าง Add-On สำหรับ PowerPoint**

คุณยังสามารถสร้าง Add-On สำหรับ Microsoft PowerPoint ที่อัปเดตวัตถุ OLE ทั้งหมดเมื่อเปิดงานนำเสนอในโปรแกรมได้.