---
title: ปัญหาการแสดงตัวอย่างวัตถุเมื่อเพิ่ม OleObjectFrame
linktitle: ปัญหาวัตถุ OLE
type: docs
weight: 10
url: /th/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- ปัญหาการแสดงตัวอย่าง
- ฝังวัตถุ
- ฝังไฟล์
- เปลี่ยนแปลงวัตถุ
- ตัวอย่างวัตถุ
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้ว่าทำไมข้อความ EMBEDDED OLE OBJECT ปรากฏเมื่อเพิ่ม OleObjectFrame ใน Aspose.Slides สำหรับ Java และวิธีแก้ไขปัญหาการแสดงตัวอย่างในงานนำเสนอ PPT, PPTX และ ODP"
---
## **บทนำ**

เมื่อคุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/oleobjectframe/) ไปยังสไลด์ จะมีข้อความ “EMBEDDED OLE OBJECT” ปรากฏบนสไลด์ผลลัพธ์ ข้อความนี้เป็นเจตนาและไม่ได้เป็นบั๊ก

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการทำงานกับวัตถุ OLE ดูที่ [จัดการ OLE](/slides/th/java/manage-ole/) 

## **คำอธิบายและวิธีแก้ไข**

Aspose.Slides แสดงข้อความ “EMBEDDED OLE OBJECT” เพื่อแจ้งว่ามีการเปลี่ยนแปลงวัตถุ OLE และต้องอัปเดตภาพตัวอย่าง

ตัวอย่างเช่น หากคุณเพิ่มแผนภูมิ Microsoft Excel เป็น [OleObjectFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/oleobjectframe/) ไปบนสไลด์ (ดูรายละเอียดเพิ่มเติมในบทความ “จัดการ OLE”) แล้วเปิดงานนำเสนอใน Microsoft PowerPoint คุณจะเห็นภาพนี้บนสไลด์:

![ข้อความวัตถุ OLE](OLE_object_message.png)

หากคุณต้องการตรวจสอบและยืนยันว่าวัตถุ OLE ของคุณถูกเพิ่มไปยังสไลด์แล้ว คุณต้องดับเบิลคลิกที่ข้อความ “EMBEDDED OLE OBJECT” หรือคลิกขวาที่ข้อความแล้วเลือก **Object > Edit**:

![วัตถุ OLE > แก้ไข](OLE_object_edit.png)

PowerPoint จะเปิดวัตถุ OLE ที่ฝังไว้:

![ข้อมูลวัตถุ OLE](OLE_object_data.png)

สไลด์อาจยังคงแสดงข้อความ “EMBEDDED OLE OBJECT” อยู่ เมื่อตัวคุณคลิกที่วัตถุ OLE สไลด์จะอัปเดตตัวอย่างและข้อความ “EMBEDDED OLE OBJECT” จะถูกแทนที่ด้วยภาพจริงของวัตถุ OLE:

![ภาพตัวอย่างวัตถุ OLE](OLE_object_preview.png)

ตอนนี้คุณอาจต้องการบันทึกงานนำเสนอเพื่อให้แน่ใจว่าภาพของวัตถุ OLE ถูกอัปเดตอย่างถูกต้อง ด้วยวิธีนี้ หลังจากบันทึกงานนำเสนอแล้ว เมื่อเปิดงานนำเสนออีกครั้ง คุณจะ **ไม่** เห็นข้อความ “EMBEDDED OLE OBJECT”

## **วิธีแก้ไขอื่น ๆ**

### **วิธีแก้ไข 1: แทนที่ข้อความ “Embedded OLE Object” ด้วยภาพ**

หากคุณไม่ต้องการลบข้อความ “EMBEDDED OLE OBJECT” โดยการเปิดงานนำเสนอใน PowerPoint แล้วบันทึกใหม่ คุณสามารถแทนที่ข้อความนั้นด้วยภาพตัวอย่างที่คุณต้องการได้ โค้ดต่อไปนี้แสดงกระบวนการ:

```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // เพิ่มภาพไปยังทรัพยากรของงานนำเสนอ.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // ตั้งชื่อเรื่องและภาพสำหรับการแสดงตัวอย่างวัตถุ OLE.
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

### **วิธีแก้ไข 2: สร้าง Add-On สำหรับ PowerPoint**

คุณยังสามารถสร้าง Add‑On สำหรับ Microsoft PowerPoint ที่อัปเดตวัตถุ OLE ทั้งหมดเมื่อคุณเปิดงานนำเสนอในโปรแกรมได้อีกด้วย.