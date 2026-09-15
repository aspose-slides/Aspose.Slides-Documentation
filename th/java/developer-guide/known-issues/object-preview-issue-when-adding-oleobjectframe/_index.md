---
title: ปัญหาการแสดงตัวอย่างอ็อบเจ็กต์เมื่อเพิ่ม OleObjectFrame
linktitle: ปัญหาอ็อบเจ็กต์ OLE
type: docs
weight: 10
url: /th/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- ปัญหาการแสดงตัวอย่าง
- ฝังอ็อบเจ็กต์
- ฝังไฟล์
- อ็อบเจ็กต์เปลี่ยนแปลง
- การแสดงตัวอย่างอ็อบเจ็กต์
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้เหตุผลที่แสดงข้อความ EMBEDDED OLE OBJECT เมื่อเพิ่ม OleObjectFrame ใน Aspose.Slides for Java และวิธีแก้ปัญหาการแสดงตัวอย่างในงานนำเสนอ PPT, PPTX และ ODP"
---
## **Introduction**

โดยใช้ Aspose.Slides for Java เมื่อคุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/oleobjectframe/) ไปยังสไลด์ จะมีข้อความ "EMBEDDED OLE OBJECT" แสดงบนสไลด์ผลลัพธ์ ข้อความนี้ตั้งใจไว้และไม่ใช่บัก

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการทำงานกับออบเจ็กต์ OLE ดูที่ [Manage OLE](/slides/th/java/manage-ole/).

## **Explanation and Solution**

Aspose.Slides แสดงข้อความ "EMBEDDED OLE OBJECT" เพื่อแจ้งให้คุณทราบว่าออบเจ็กต์ OLE ได้ถูกเปลี่ยนแปลงและภาพตัวอย่างต้องได้รับการอัปเดต

ตัวอย่างเช่น หากคุณเพิ่มแผนภูมิ Microsoft Excel เป็น [OleObjectFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/oleobjectframe/) ไปยังสไลด์ (สำหรับรายละเอียดเพิ่มเติม ดูบทความ "Manage OLE") แล้วเปิดงานนำเสนอใน Microsoft PowerPoint คุณจะเห็นภาพนี้บนสไลด์:

![OLE object message](OLE_object_message.png)

หากคุณต้องการตรวจสอบและยืนยันว่าออบเจ็กต์ OLE ของคุณถูกเพิ่มไปยังสไลด์แล้ว คุณต้องดับเบิลคลิกที่ข้อความ "EMBEDDED OLE OBJECT" หรือคุณสามารถคลิกขวาที่ข้อความและเลือกตัวเลือก **Object > Edit**

![OLE object > Edit](OLE_object_edit.png)

PowerPoint จากนั้นจะเปิดออบเจ็กต์ OLE ที่ฝังอยู่

![OLE object data](OLE_object_data.png)

สไลด์อาจยังคงแสดงข้อความ "EMBEDDED OLE OBJECT" อยู่ เมื่อคุณคลิกรูปออบเจ็กต์ OLE ตัวอย่างสไลด์จะอัปเดตและข้อความ "EMBEDDED OLE OBJECT" จะถูกแทนที่ด้วยภาพจริงของออบเจ็กต์ OLE

![OLE object preview](OLE_object_preview.png)

ตอนนี้คุณอาจต้องการบันทึกงานนำเสนอของคุณเพื่อให้แน่ใจว่าภาพของ OLE Object ได้รับการอัปเดตอย่างถูกต้อง วิธีนี้หลังจากบันทึกงานนำเสนอแล้ว เมื่อคุณเปิดงานนำเสนออีกครั้ง คุณจะไม่เห็นข้อความ "EMBEDDED OLE OBJECT"

## **Other Solution**

หากคุณไม่ต้องการลบข้อความ "EMBEDDED OLE OBJECT" โดยการเปิดงานนำเสนอใน PowerPoint แล้วบันทึกใหม่ คุณสามารถแทนที่ข้อความด้วยภาพตัวอย่างที่คุณต้องการได้ โค้ดต่อไปนี้แสดงกระบวนการดังกล่าว:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // เพิ่มรูปภาพไปยังทรัพยากรของงานนำเสนอ
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // ตั้งชื่อหัวเรื่องและรูปภาพสำหรับการแสดงตัวอย่างอ็อบเจ็กต์ OLE
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

สไลด์ที่มี `OleObjectFrame` จะเปลี่ยนเป็นดังนี้:

![New OLE object image](OLE_object_new_image.png)