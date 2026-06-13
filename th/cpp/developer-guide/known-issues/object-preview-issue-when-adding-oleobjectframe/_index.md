---
title: ปัญหาการแสดงตัวอย่างวัตถุเมื่อเพิ่ม OleObjectFrame
linktitle: ปัญหา OLE Object
type: docs
weight: 10
url: /th/cpp/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- ปัญหาการแสดงตัวอย่าง
- ฝังอ็อบเจ็กต์
- ฝังไฟล์
- อ็อบเจ็กต์เปลี่ยนแปลง
- การแสดงตัวอย่างอ็อบเจ็กต์
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้สาเหตุที่ข้อความ EMBEDDED OLE OBJECT ปรากฏเมื่อเพิ่ม OleObjectFrame ใน Aspose.Slides สำหรับ C++ และวิธีแก้ไขปัญหาการแสดงตัวอย่างในงานนำเสนอรูปแบบ PPT, PPTX และ ODP"
---
## **บทนำ**

เมื่อใช้ Aspose.Slides สำหรับ C++ และคุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/oleobjectframe/) ไปยังสไลด์ ข้อความ "EMBEDDED OLE OBJECT" จะปรากฏบนสไลด์ผลลัพธ์ ข้อความนี้ตั้งใจไว้และไม่ได้เป็นข้อบกพร่อง

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการทำงานกับอ็อบเจ็กต์ OLE ให้ดูที่ [Manage OLE](/slides/th/cpp/manage-ole/)

## **คำอธิบายและวิธีแก้ไข**

Aspose.Slides แสดงข้อความ "EMBEDDED OLE OBJECT" เพื่อแจ้งว่ามีการเปลี่ยนแปลงอ็อบเจ็กต์ OLE และต้องอัปเดตรูปภาพตัวอย่าง

ตัวอย่างเช่น หากคุณเพิ่มแผนภูมิ Microsoft Excel เป็น [OleObjectFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/oleobjectframe/) ลงในสไลด์ (ดูรายละเอียดเพิ่มเติมในบทความ "Manage OLE") แล้วเปิดงานนำเสนอด้วย Microsoft PowerPoint คุณจะเห็นภาพนี้บนสไลด์:

![ข้อความอ็อบเจ็กต์ OLE](OLE_object_message.png)

หากคุณต้องการตรวจสอบและยืนยันว่าอ็อบเจ็กต์ OLE ของคุณถูกเพิ่มลงในสไลด์แล้ว จะต้องดับเบิลคลิกที่ข้อความ "EMBEDDED OLE OBJECT" หรือคลิกขวาที่ข้อความแล้วเลือกตัวเลือก **Object > Edit**:

![อ็อบเจ็กต์ OLE > แก้ไข](OLE_object_edit.png)

PowerPoint จากนั้นเปิดอ็อบเจ็กต์ OLE ที่ฝังไว้:

![ข้อมูลอ็อบเจ็กต์ OLE](OLE_object_data.png)

สไลด์อาจยังคงมีข้อความ "EMBEDDED OLE OBJECT" อยู่ เมื่อคุณคลิกที่อ็อบเจ็กต์ OLE ใบหน้าตัวอย่างสไลด์จะอัปเดตและข้อความ "EMBEDDED OLE OBJECT" จะถูกแทนที่ด้วยรูปภาพจริงของอ็อบเจ็กต์ OLE:

![ตัวอย่างอ็อบเจ็กต์ OLE](OLE_object_preview.png)

ตอนนี้คุณอาจต้องการบันทึกงานนำเสนอของคุณเพื่อให้แน่ใจว่ารูปภาพของอ็อบเจ็กต์ OLE ได้รับการอัปเดตอย่างถูกต้อง ด้วยวิธีนี้ หลังจากบันทึกงานนำเสนอแล้ว เมื่อคุณเปิดงานนำเสนออีกครั้ง คุณจะ **ไม่** เห็นข้อความ "EMBEDDED OLE OBJECT"

## **วิธีแก้ไขอื่น ๆ**

### **วิธีแก้ไข 1: แทนที่ข้อความ "Embedded OLE Object" ด้วยภาพ**

หากคุณไม่ต้องการลบข้อความ "EMBEDDED OLE OBJECT" โดยเปิดงานนำเสนอใน PowerPoint แล้วบันทึกใหม่ คุณสามารถแทนที่ข้อความด้วยภาพตัวอย่างที่คุณต้องการได้ โค้ดต่อไปนี้แสดงกระบวนการ:

```cpp
auto presentation = MakeObject<Presentation>(u"embeddedOLE.pptx");

auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Add an image to presentation resources.
auto imageStream = File::OpenRead(u"myImage.png");
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Set a title and the image for the OLE object preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"embeddedOLE-newImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

สไลด์ที่มี `OleObjectFrame` จะเปลี่ยนเป็นแบบนี้:

![ภาพอ็อบเจ็กต์ OLE ใหม่](OLE_object_new_image.png)

### **วิธีแก้ไข 2: สร้างส่วนเสริมสำหรับ PowerPoint**

คุณยังสามารถสร้างส่วนเสริมสำหรับ Microsoft PowerPoint ที่อัปเดตอ็อบเจ็กต์ OLE ทั้งหมดเมื่อคุณเปิดงานนำเสนอในโปรแกรมได้