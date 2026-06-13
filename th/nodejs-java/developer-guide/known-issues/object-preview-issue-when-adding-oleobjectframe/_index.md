---
title: ปัญหาการแสดงตัวอย่างอ็อบเจกต์เมื่อเพิ่ม OleObjectFrame
linktitle: ปัญหา OLE Object
type: docs
weight: 10
url: /th/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- ปัญหาการแสดงตัวอย่าง
- ฝังอ็อบเจกต์
- ฝังไฟล์
- วัตถุถูกเปลี่ยนแปลง
- ตัวอย่างอ็อบเจกต์
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้ว่าเหตุใดข้อความ EMBEDDED OLE OBJECT ปรากฏเมื่อเพิ่ม OleObjectFrame ใน Aspose.Slides สำหรับ Node.js และวิธีแก้ไขปัญหาการแสดงตัวอย่างในงานนำเสนอรูปแบบ PPT, PPTX และ ODP."
---
## **แนะนำ**

โดยใช้ Aspose.Slides for Java, เมื่อคุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/oleobjectframe/) ไปยังสไลด์, จะมีข้อความ "EMBEDDED OLE OBJECT" แสดงบนสไลด์ผลลัพธ์ ข้อความนี้เป็นตามเจตนาและไม่ใช่บัค  

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการทำงานกับวัตถุ OLE, ดูที่ [จัดการ OLE](/slides/th/nodejs-java/manage-ole/). 

## **คำอธิบายและวิธีแก้ไข**

Aspose.Slides แสดงข้อความ "EMBEDDED OLE OBJECT" เพื่อบอกคุณว่าวัตถุ OLE ได้รับการเปลี่ยนแปลงและต้องอัปเดตรูปภาพตัวอย่าง  

ตัวอย่างเช่น, หากคุณเพิ่มแผนภูมิ Microsoft Excel เป็น [OleObjectFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/oleobjectframe/) ไปยังสไลด์ (สำหรับรายละเอียดเพิ่มเติม, ดูบทความ "จัดการ OLE") แล้วเปิดงานนำเสนอใน Microsoft PowerPoint, คุณจะเห็นภาพนี้บนสไลด์:  

![ข้อความวัตถุ OLE](OLE_object_message.png)

หากคุณต้องการตรวจสอบและยืนยันว่าวัตถุ OLE ของคุณถูกเพิ่มไปยังสไลด์, คุณต้องคลิกสองครั้งบนข้อความ "EMBEDDED OLE OBJECT", หรือคุณสามารถคลิกขวาที่ข้อความและเลือกตัวเลือก **Object > Edit**  

![วัตถุ OLE > แก้ไข](OLE_object_edit.png)

PowerPoint จะเปิดวัตถุ OLE ที่ฝังอยู่  

![ข้อมูลวัตถุ OLE](OLE_object_data.png)

สไลด์อาจยังคงมีข้อความ "EMBEDDED OLE OBJECT". เมื่อคุณคลิกที่วัตถุ OLE, ตัวอย่างสไลด์จะอัปเดตและข้อความ "EMBEDDED OLE OBJECT" จะถูกแทนที่ด้วยรูปภาพจริงของวัตถุ OLE  

![ตัวอย่างวัตถุ OLE](OLE_object_preview.png)

ขณะนี้คุณอาจต้องการบันทึกงานนำเสนอของคุณเพื่อให้แน่ใจว่าภาพของวัตถุ OLE ถูกอัปเดตอย่างถูกต้อง วิธีนี้จะทำให้หลังจากบันทึกงานนำเสนอแล้ว, เมื่อเปิดงานนำเสนออีกครั้ง, คุณจะไม่เห็นข้อความ "EMBEDDED OLE OBJECT".  

## **วิธีแก้ไขอื่น ๆ**

### **วิธีแก้ไข 1: แทนที่ข้อความ "Embedded OLE Object" ด้วยภาพ**

หากคุณไม่ต้องการลบข้อความ "EMBEDDED OLE OBJECT" โดยการเปิดงานนำเสนอใน PowerPoint แล้วบันทึก, คุณสามารถแทนที่ข้อความด้วยภาพตัวอย่างที่คุณต้องการได้ โค้ดต่อไปนี้แสดงกระบวนการ:  

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // เพิ่มภาพไปยังทรัพยากรของงานนำเสนอ.
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // ตั้งชื่อเรื่องและภาพสำหรับการแสดงตัวอย่างวัตถุ OLE.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

สไลด์ที่มี `OleObjectFrame` จะเปลี่ยนเป็นดังนี้:  

![ภาพวัตถุ OLE ใหม่](OLE_object_new_image.png)

### **วิธีแกน 2: สร้าง Add-On สำหรับ PowerPoint**

คุณยังสามารถสร้าง Add-On สำหรับ Microsoft PowerPoint ที่จะอัปเดตวัตถุ OLE ทั้งหมดเมื่อคุณเปิดงานนำเสนอในโปรแกรมได้.