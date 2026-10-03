---
title: ตัวแทนภาพล่วงหน้าของอ็อบเจกต์เมื่อเพิ่ม OleObjectFrame
linktitle: ตัวแทนภาพล่วงหน้า OLE
type: docs
weight: 10
url: /th/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- ปัญหาการแสดงภาพล่วงหน้า
- ตำแหน่งตัวแทนภาพล่วงหน้า
- ตามการออกแบบ
- ฝังอ็อบเจ็กต์
- ฝังไฟล์
- อ็อบเจ็กต์ถูกเปลี่ยนแปลง
- ภาพล่วงหน้าอ็อบเจ็กต์
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เหตุผลที่อ็อบเจ็กต์ OLE ที่เพิ่มด้วย Aspose.Slides สำหรับ Java แสดงตำแหน่งตัวแทน EMBEDDED OLE OBJECT จนกว่าภาพล่วงหน้าจะได้รับการอัปเดต และวิธีตั้งค่าภาพล่วงหน้าของคุณเอง"
---
## **บทนำ**

เมื่อใช้ Aspose.Slides for Java และเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/oleobjectframe/) ลงในสไลด์ จะมีข้อความ “EMBEDDED OLE OBJECT” ปรากฏบนสไลด์ผลลัพธ์ ข้อความนี้เป็นการแสดงเจตนาโดยเจตนา ไม่ใช่บั๊ก

เพื่อดูข้อมูลเพิ่มเติมเกี่ยวกับการทำงานกับ OLE objects โปรดดู [Manage OLE](/slides/th/java/manage-ole/)

## **คำอธิบายและวิธีแก้ไข**

Aspose.Slides แสดงข้อความ “EMBEDDED OLE OBJECT” เพื่อบอกว่ามีการเปลี่ยนแปลง OLE object และต้องอัปเดตภาพพรีวิว

ตัวอย่างเช่น หากคุณเพิ่มแผนภูมิ Microsoft Excel เป็น [OleObjectFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/oleobjectframe/) ลงในสไลด์ (สำหรับรายละเอียดเพิ่มเติม ดูบทความ “Manage OLE”) แล้วเปิดงานนำเสนอใน Microsoft PowerPoint คุณจะเห็นภาพนี้บนสไลด์:

![OLE object message](OLE_object_message.png)

หากต้องการตรวจสอบและยืนยันว่า OLE object ของคุณถูกเพิ่มลงในสไลด์แล้ว คุณต้องดับเบิลคลิกที่ข้อความ “EMBEDDED OLE OBJECT” หรือคลิกขวาแล้วเลือก **Object > Edit**:

![OLE object > Edit](OLE_object_edit.png)

PowerPoint จะเปิด OLE object ที่ฝังอยู่

![OLE object data](OLE_object_data.png)

สไลด์อาจยังคงแสดงข้อความ “EMBEDDED OLE OBJECT” อยู่ เมื่อคุณคลิกที่ OLE object แล้วภาพพรีวิวของสไลด์จะอัปเดตและข้อความ “EMBEDDED OLE OBJECT” จะถูกแทนที่ด้วยภาพจริงของ OLE object

![OLE object preview](OLE_object_preview.png)

ตอนนี้คุณอาจต้องการบันทึกงานนำเสนอเพื่อให้แน่ใจว่าภาพของ OLE Object ถูกอัปเดตอย่างถูกต้อง วิธีนี้หลังจากบันทึกงานนำเสนอแล้ว เมื่อเปิดงานนำเสนออีกครั้ง คุณจะไม่เห็นข้อความ “EMBEDDED OLE OBJECT”

## **วิธีแก้อื่น**

หากคุณไม่ต้องการลบข้อความ “EMBEDDED OLE OBJECT” โดยการเปิดงานนำเสนอใน PowerPoint แล้วบันทึกใหม่ คุณสามารถแทนที่ข้อความด้วยภาพพรีวิวที่คุณต้องการได้ โค้ดต่อไปนี้แสดงขั้นตอนการทำงาน โดยสมมติว่า shape แรกบนสไลด์แรกของ *embeddedOLE.pptx* คือกรอบ OLE object และ *myImage.png* เป็นภาพที่ต้องการแสดง แล้วบันทึกผลลัพธ์เป็น *embeddedOLE-newImage.pptx*:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // เพิ่มรูปภาพไปยังทรัพยากรของงานนำเสนอ.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);
    image.dispose();

    // ตั้งค่ารูปภาพสำหรับพรีวิว OLE object.
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

สไลด์ที่มี `OleObjectFrame` จะเปลี่ยนเป็นดังนี้:

![New OLE object image](OLE_object_new_image.png)