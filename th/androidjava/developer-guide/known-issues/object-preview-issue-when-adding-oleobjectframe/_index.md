---
title: ปัญหาการแสดงตัวอย่างวัตถุเมื่อเพิ่ม OleObjectFrame
linktitle: ปัญหาวัตถุ OLE
type: docs
weight: 10
url: /th/androidjava/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- ปัญหาการแสดงตัวอย่าง
- ฝังวัตถุ
- ฝังไฟล์
- วัตถุถูกเปลี่ยนแปลง
- การแสดงตัวอย่างวัตถุ
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้เหตุผลที่ข้อความ EMBEDDED OLE OBJECT ปรากฏเมื่อเพิ่ม OleObjectFrame ใน Aspose.Slides สำหรับ Android ผ่าน Java และวิธีแก้ไขปัญหาการแสดงตัวอย่างในงานนำเสนอรูปแบบ PPT, PPTX และ ODP"
---
## **บทนำ**

เมื่อใช้ Aspose.Slides for Android ผ่าน Java หากคุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/oleobjectframe/) ไปยังสไลด์ จะมีข้อความ "EMBEDDED OLE OBJECT" ปรากฏบนสไลด์ผลลัพธ์ ข้อความนี้เป็นที่ตั้งใจและไม่ใช่บั๊ก

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการทำงานกับวัตถุ OLE ดูที่ [Manage OLE](/slides/th/androidjava/manage-ole/)

## **คำอธิบายและวิธีแก้ปัญหา**

Aspose.Slides แสดงข้อความ "EMBEDDED OLE OBJECT" เพื่อแจ้งว่าวัตถุ OLE ได้รับการเปลี่ยนแปลงและภาพตัวอย่างต้องอัปเดต

เช่น หากคุณเพิ่มกราฟ Microsoft Excel เป็น [OleObjectFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/oleobjectframe/) ลงในสไลด์ (สำหรับรายละเอียดเพิ่มเติม ดูบทความ "Manage OLE") แล้วเปิดงานนำเสนอใน Microsoft PowerPoint คุณจะเห็นภาพนี้บนสไลด์:

![ข้อความวัตถุ OLE](OLE_object_message.png)

หากคุณต้องการตรวจสอบและยืนยันว่าวัตถุ OLE ของคุณถูกเพิ่มลงในสไลด์ คุณต้องคลิกสองครั้งที่ข้อความ "EMBEDDED OLE OBJECT" หรือคุณสามารถคลิกขวาที่ข้อความแล้วเลือกตัวเลือก **Object > Edit**:

![วัตถุ OLE > แก้ไข](OLE_object_edit.png)

PowerPoint จากนั้นจะเปิดวัตถุ OLE ที่ฝังไว้

![ข้อมูลวัตถุ OLE](OLE_object_data.png)

สไลด์อาจยังคงมีข้อความ "EMBEDDED OLE OBJECT" อยู่ เมื่อคุณคลิกที่วัตถุ OLE, ภาพตัวอย่างของสไลด์จะได้รับการอัปเดตและข้อความ "EMBEDDED OLE OBJECT" จะถูกแทนที่ด้วยภาพจริงของวัตถุ OLE

![ภาพตัวอย่างวัตถุ OLE](OLE_object_preview.png)

ขณะนี้คุณอาจต้องการบันทึกงานนำเสนอของคุณเพื่อให้แน่ใจว่าภาพของวัตถุ OLE ถูกอัปเดตอย่างถูกต้อง ด้วยวิธีนี้ หลังจากบันทึกงานนำเสนอแล้ว เมื่อคุณเปิดงานนำเสนออีกครั้ง คุณจะไม่เห็นข้อความ "EMBEDDED OLE OBJECT"

## **วิธีแก้ไขอื่นๆ**

### **วิธีแก้ 1: แทนที่ข้อความ "Embedded OLE Object" ด้วยภาพ**

หากคุณไม่ต้องการลบข้อความ "EMBEDDED OLE OBJECT" โดยการเปิดงานนำเสนอใน PowerPoint แล้วบันทึก, คุณสามารถแทนที่ข้อความด้วยภาพตัวอย่างที่คุณต้องการได้ โค้ดต่อไปนี้แสดงกระบวนการ:

```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // เพิ่มภาพไปยังทรัพยากรของงานนำเสนอ.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // ตั้งชื่อเรื่องและภาพสำหรับตัวอย่างวัตถุ OLE.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

สไลด์ที่มี `OleObjectFrame` จะเปลี่ยนเป็นดังนี้:

![ภาพวัตถุ OLE ใหม่](OLE_object_new_image.png)

### **วิธีแก้ 2: สร้างแอด‑ออนสำหรับ PowerPoint**

คุณยังสามารถสร้างแอด‑ออนสำหรับ Microsoft PowerPoint ที่จะอัปเดตวัตถุ OLE ทั้งหมดเมื่อคุณเปิดงานนำเสนอในโปรแกรมได้.