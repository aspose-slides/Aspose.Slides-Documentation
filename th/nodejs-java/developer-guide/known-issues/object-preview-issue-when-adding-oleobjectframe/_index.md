---
title: ปัญหาการแสดงตัวอย่างวัตถุเมื่อเพิ่ม OleObjectFrame
linktitle: ปัญหา OLE Object
type: docs
weight: 10
url: /th/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
aliases:
  - /nodejs-java/object-changed-issue-when-adding-oleobjectframe/
keywords:
  - OLE
  - ปัญหาการแสดงตัวอย่าง
  - ฝังวัตถุ
  - ฝังไฟล์
  - วัตถุเปลี่ยนแปลง
  - ตัวอย่างวัตถุ
  - PowerPoint
  - การนำเสนอ
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "เรียนรู้สาเหตุที่ปรากฏข้อความ EMBEDDED OLE OBJECT เมื่อเพิ่ม OleObjectFrame ใน Aspose.Slides สำหรับ Node.js และวิธีแก้ปัญหาการแสดงตัวอย่างในงานนำเสนอ PPT, PPTX และ ODP."
---
## **บทนำ**

โดยใช้ Aspose.Slides for Java เมื่อคุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/oleobjectframe/) ไปยังสไลด์ จะมีข้อความ "EMBEDDED OLE OBJECT" แสดงบนสไลด์ผลลัพธ์ ข้อความนี้เป็นเจตนาและไม่ใช่บั๊ก

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการทำงานกับอ็อบเจ็กต์ OLE โปรดดูที่ [Manage OLE](/slides/th/nodejs-java/manage-ole/). 

## **คำอธิบายและวิธีแก้**

Aspose.Slides แสดงข้อความ "EMBEDDED OLE OBJECT" เพื่อแจ้งให้คุณทราบว่าอ็อบเจ็กต์ OLE ได้ถูกเปลี่ยนแปลงและต้องอัปเดตภาพตัวอย่าง 

ตัวอย่างเช่น หากคุณเพิ่มแผนภูมิ Microsoft Excel เป็น [OleObjectFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/oleobjectframe/) ลงในสไลด์ (ดูรายละเอียดเพิ่มเติมในบทความ "Manage OLE") แล้วเปิดงานนำเสนอด้วย Microsoft PowerPoint คุณจะเห็นภาพนี้บนสไลด์:

![ข้อความอ็อบเจ็กต์ OLE](OLE_object_message.png)

หากคุณต้องการตรวจสอบและยืนยันว่าอ็อบเจ็กต์ OLE ของคุณถูกเพิ่มลงในสไลด์แล้ว คุณต้องดับเบิลคลิกที่ข้อความ "EMBEDDED OLE OBJECT" หรือสามารถคลิกขวาที่ข้อความและเลือกตัวเลือก **Object > Edit**.

![อ็อบเจ็กต์ OLE > แก้ไข](OLE_object_edit.png)

PowerPoint จากนั้นจะเปิดอ็อบเจ็กต์ OLE ที่ฝังไว้

![ข้อมูลอ็อบเจ็กต์ OLE](OLE_object_data.png)

สไลด์อาจยังคงแสดงข้อความ "EMBEDDED OLE OBJECT" อยู่ เมื่อคุณคลิกที่อ็อบเจ็กต์ OLE การแสดงตัวอย่างของสไลด์จะอัปเดตและข้อความ "EMBEDDED OLE OBJECT" จะถูกแทนที่ด้วยภาพจริงของอ็อบเจ็กต์ OLE 

![ตัวอย่างอ็อบเจ็กต์ OLE](OLE_object_preview.png)

ตอนนี้คุณอาจต้องการบันทึกงานนำเสนอของคุณเพื่อให้แน่ใจว่าภาพของอ็อบเจ็กต์ OLE ถูกอัปเดตอย่างถูกต้อง วิธีนี้หลังจากบันทึกงานนำเสนอแล้ว เมื่อคุณเปิดงานนำเสนออีกครั้ง คุณจะไม่เห็นข้อความ "EMBEDDED OLE OBJECT". 

## **วิธีแก้ไขอื่น ๆ**

### **วิธีแก้ 1: แทนที่ข้อความ "Embedded OLE Object" ด้วยภาพ**

หากคุณไม่ต้องการลบข้อความ "EMBEDDED OLE OBJECT" ด้วยการเปิดงานนำเสนอใน PowerPoint แล้วบันทึก คุณสามารถแทนที่ข้อความด้วยภาพตัวอย่างที่คุณต้องการได้ โค้ดต่อไปนี้แสดงกระบวนการ:

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // เพิ่มรูปภาพไปยังทรัพยากรของงานนำเสนอ.
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // ตั้งชื่อและรูปภาพสำหรับการแสดงตัวอย่างวัตถุ OLE.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

สไลด์ที่มี `OleObjectFrame` จะเปลี่ยนเป็นดังนี้:

![ภาพอ็อบเจ็กต์ OLE ใหม่](OLE_object_new_image.png)

### **วิธีแก้ 2: สร้าง Add-On สำหรับ PowerPoint**

คุณยังสามารถสร้างแอดออนสำหรับ Microsoft PowerPoint ที่อัปเดตอ็อบเจ็กต์ OLE ทั้งหมดเมื่อคุณเปิดงานนำเสนอในโปรแกรม.