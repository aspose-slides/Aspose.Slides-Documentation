---
title: ตำแหน่งตัวอย่างวัตถุก่อนแสดงเมื่อเพิ่ม OleObjectFrame
linktitle: ตัวอย่าง OLE ก่อนแสดง
type: docs
weight: 10
url: /th/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- ปัญหาการแสดงตัวอย่าง
- ตำแหน่งตัวอย่างก่อนแสดง
- ตามการออกแบบ
- ฝังวัตถุ
- ฝังไฟล์
- วัตถุถูกเปลี่ยนแปลง
- ตัวอย่างวัตถุ
- งานนำเสนอ
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "ทำไมวัตถุ OLE ที่เพิ่มด้วย Aspose.Slides สำหรับ .NET ถึงแสดงตำแหน่ง EMBEDDED OLE OBJECT จนกว่าจะมีการอัปเดตตัวอย่างและวิธีการตั้งค่าภาพตัวอย่างของคุณเอง"
---
## **บทนำ**

โดยใช้ Aspose.Slides สำหรับ .NET เมื่อคุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/oleobjectframe/) ลงในสไลด์ จะมีข้อความ "EMBEDDED OLE OBJECT" แสดงบนสไลด์ผลลัพธ์ ข้อความนี้เป็นการทำงานตามปกติและไม่ได้เป็นบั๊ก

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการทำงานกับวัตถุ OLE ดูที่ [Manage OLE](/slides/th/net/manage-ole/).

## **คำอธิบายและวิธีแก้**

Aspose.Slides แสดงข้อความ "EMBEDDED OLE OBJECT" เพื่อแจ้งให้คุณทราบว่ามีการเปลี่ยนแปลงวัตถุ OLE และต้องอัปเดตรูปภาพตัวอย่าง

ตัวอย่างเช่น หากคุณเพิ่มแผนภูมิ Microsoft Excel เป็น [OleObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/oleobjectframe/) ลงในสไลด์ (สำหรับรายละเอียดเพิ่มเติม ดูบทความ "Manage OLE") แล้วเปิดงานนำเสนอใน Microsoft PowerPoint คุณจะเห็นรูปภาพนี้บนสไลด์:

![ข้อความวัตถุ OLE](OLE_object_message.png)

หากต้องการตรวจสอบและยืนยันว่วัตถุ OLE ของคุณถูกเพิ่มลงในสไลด์ คุณต้องดับเบิลคลิกที่ข้อความ "EMBEDDED OLE OBJECT" หรือคุณสามารถคลิกขวาที่ข้อความและเลือกตัวเลือก **Object > Edit**:

![วัตถุ OLE > แก้ไข](OLE_object_edit.png)

PowerPoint จะเปิดวัตถุ OLE ที่ฝังอยู่

![ข้อมูลวัตถุ OLE](OLE_object_data.png)

สไลด์อาจยังคงแสดงข้อความ "EMBEDDED OLE OBJECT" อยู่ เมื่อคุณคลิ้ววัตถุ OLE แล้ว ตัวอย่างสไลด์จะอัปเดตและข้อความ "EMBEDDED OLE OBJECT" จะถูกแทนที่ด้วยภาพจริงของวัตถุ OLE

![ตัวอย่างวัตถุ OLE](OLE_object_preview.png)

ตอนนี้ คุณอาจต้องการบันทึกงานนำเสนอของคุณเพื่อให้แน่ใจว่าภาพของวัตถุ OLE จะอัปเดตอย่างถูกต้อง ด้วยวิธีนี้ หลังจากบันทึกงานนำเสนอ แล้วเปิดงานนำเสนออีกครั้ง คุณจะไม่เห็นข้อความ "EMBEDDED OLE OBJECT"

## **วิธีแก้ไขอื่นๆ**

### **วิธีแก้ 1: แทนที่ข้อความ "Embedded OLE Object" ด้วยภาพ**

หากคุณไม่ต้องการลบข้อความ "EMBEDDED OLE OBJECT" โดยการเปิดงานนำเสนอใน PowerPoint แล้วบันทึก คุณสามารถแทนที่ข้อความนั้นด้วยภาพตัวอย่างที่คุณต้องการได้ โค้ดต่อไปนี้แสดงกระบวนการ:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// เพิ่มรูปภาพไปยังทรัพยากรของงานนำเสนอ.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// ตั้งค่ารูปภาพสำหรับการแสดงตัวอย่างของวัตถุ OLE.
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

สไลด์ที่มี `OleObjectFrame` จะเปลี่ยนเป็นดังนี้:

![ภาพวัตถุ OLE ใหม่](OLE_object_new_image.png)

### **วิธีแก้ 2: สร้าง Add-On สำหรับ PowerPoint**

คุณยังสามารถสร้างส่วนเสริมสำหรับ Microsoft PowerPoint ที่อัปเดตวัตถุ OLE ทั้งหมดเมื่อคุณเปิดงานนำเสนอในโปรแกรมได้