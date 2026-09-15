---
title: ปัญหาการแสดงตัวอย่างอ็อบเจกต์เมื่อเพิ่ม OleObjectFrame
linktitle: ปัญหาอ็อบเจกท์ OLE
type: docs
weight: 10
url: /th/python-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- ปัญหาการแสดงตัวอย่าง
- ฝังอ็อบเจกท์
- ฝังไฟล์
- อ็อบเจกท์เปลี่ยนแปลง
- ตัวอย่างอ็อบเจกท์
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้ว่าทำไมข้อความ EMBEDDED OLE OBJECT แสดงเมื่อเพิ่ม OleObjectFrame ใน Aspose.Slides สำหรับ Python ผ่าน Java และวิธีแก้ไขปัญหาการแสดงตัวอย่างในงานนำเสนอรูปแบบ PPT, PPTX และ ODP."
---
## **บทนำ**

เมื่อคุณใช้ Aspose.Slides สำหรับ Python ผ่าน Java เพื่อเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/oleobjectframe/) ลงในสไลด์ จะมีข้อความ "EMBEDDED OLE OBJECT" แสดงบนสไลด์ผลลัพธ์ ข้อความนี้ตั้งใจไว้และไม่ใช่ข้อบกพร่อง

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการทำงานกับอ็อบเจกท์ OLE ดูที่ [Manage OLE](/slides/th/python-java/manage-ole/)

## **คำอธิบายและวิธีแก้ไข**

Aspose.Slides แสดงข้อความ "EMBEDDED OLE OBJECT" เพื่อแจ้งให้คุณทราบว่าอ็อบเจกท์ OLE ถูกเปลี่ยนแปลงและต้องอัปเดตรูปภาพตัวอย่าง

ตัวอย่างเช่น หากคุณเพิ่มแผนภูมิ Microsoft Excel เป็น [OleObjectFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/oleobjectframe/) ลงในสไลด์ (สำหรับรายละเอียดเพิ่มเติม ดูบทความ "Manage OLE") แล้วเปิดงานนำเสนอใน Microsoft PowerPoint คุณจะเห็นภาพนี้บนสไลด์:

![ข้อความอ็อบเจกต์ OLE](OLE_object_message.png)

เพื่อยืนยันว่าอ็อบเจกท์ OLE ของคุณถูกเพิ่มลงในสไลด์แล้ว ให้ดับเบิลคลิกข้อความ "EMBEDDED OLE OBJECT" หรือคลิกขวาแล้วเลือก **Object > Edit**.

![อ็อบเจกต์ OLE > แก้ไข](OLE_object_edit.png)

PowerPoint จากนั้นจะเปิดอ็อบเจกท์ OLE ที่ฝังอยู่

![ข้อมูลอ็อบเจกต์ OLE](OLE_object_data.png)

สไลด์อาจยังคงมีข้อความ "EMBEDDED OLE OBJECT" อยู่ เมื่อคุณคลิกอ็อบเจกท์ OLE ตัวอย่างสไลด์จะอัปเดตและข้อความ "EMBEDDED OLE OBJECT" จะถูกแทนที่ด้วยภาพจริงของอ็อบเจกท์ OLE

![ภาพตัวอย่างอ็อบเจกต์ OLE](OLE_object_preview.png)

บันทึกงานนำเสนอของคุณเพื่อเก็บภาพตัวอย่างอ็อบเจกท์ OLE ที่อัปเดตไว้ เมื่อเปิดงานนำเสนออีกครั้ง คุณจะไม่เห็นข้อความ "EMBEDDED OLE OBJECT" อีกต่อไป

## **วิธีแก้อื่น**

หากคุณไม่ต้องการลบข้อความ "EMBEDDED OLE OBJECT" โดยการเปิดงานนำเสนอใน PowerPoint แล้วบันทึก คุณสามารถแทนที่ข้อความด้วยภาพตัวอย่างที่คุณชอบ โค้ดต่อไปนี้แสดงขั้นตอนการทำเช่นนั้น:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("embeddedOLE.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # เพิ่มรูปภาพไปยังทรัพยากรของงานนำเสนอ
    image = Images.fromFile("myImage.png")
    try:
        ole_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # ตั้งชื่อเรื่องและรูปภาพสำหรับการแสดงตัวอย่างอ็อบเจกท์ OLE
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(False)

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

สไลด์ที่มี [OleObjectFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/oleobjectframe/) แล้วจะเปลี่ยนเป็นรูปดังนี้:

![รูปภาพอ็อบเจกต์ OLE ใหม่](OLE_object_new_image.png)

## **คำถามที่พบบ่อย**

**ทำไมจึงแสดงข้อความ "EMBEDDED OLE OBJECT"?**

ข้อความนี้บ่งบอกว่าอ็อบเจกท์ OLE ได้เปลี่ยนแปลงและต้องอัปเดตรูปภาพตัวอย่าง พฤติกรรมนี้เป็นการออกแบบโดยเจตนา

**ฉันจะอัปเดตรูปภาพตัวอย่างใน PowerPoint ได้อย่างไร?**

ดับเบิลคลิกข้อความหรือเลือก **Object > Edit** เพื่อเปิดอ็อบเจกท์ OLE ที่ฝังอยู่ คลิกอ็อบเจกท์ OLE เพื่ออัปเดตตัวอย่าง แล้วบันทึกงานนำเสนอ

**ฉันสามารถแทนที่ข้อความโดยไม่ต้องเปิดงานนำเสนอใน PowerPoint ได้หรือไม่?**

ได้ คุณสามารถกำหนดภาพตัวอย่างที่ต้องการให้กับอ็อบเจกท์ OLE ตามที่แสดงในตัวอย่างโค้ดด้านบน