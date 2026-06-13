---
title: ปัญหาการแสดงตัวอย่างวัตถุเมื่อเพิ่ม OleObjectFrame
linktitle: ปัญหาวัตถุ OLE
type: docs
weight: 10
url: /th/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- ปัญหาการแสดงตัวอย่าง
- ฝังวัตถุ
- ฝังไฟล์
- วัตถุเปลี่ยนแปลง
- ตัวอย่างวัตถุ
- การนำเสนอ
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้สาเหตุที่ข้อความ EMBEDDED OLE OBJECT ปรากฏเมื่อเพิ่ม OleObjectFrame ใน Aspose.Slides สำหรับ .NET และวิธีแก้ไขปัญหาการแสดงตัวอย่างในงานนำเสนอ PPT, PPTX และ ODP"
---
## **บทนำ**

ด้วย Aspose.Slides สำหรับ .NET เมื่อคุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/oleobjectframe) ลงในสไลด์ จะมีข้อความ "EMBEDDED OLE OBJECT" ปรากฏบนสไลด์ผลลัพธ์ ข้อความนี้ตั้งใจให้แสดงและ NOT a bug

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการทำงานกับวัตถุ OLE ดูที่ [Manage OLE](/slides/th/net/manage-ole/).

## **คำอธิบายและวิธีแก้ไข**

Aspose.Slides แสดงข้อความ "EMBEDDED OLE OBJECT" เพื่อแจ้งว่าวัตถุ OLE ได้รับการเปลี่ยนแปลงและต้องอัปเดตรูปภาพพรีวิว

ตัวอย่างเช่น หากคุณเพิ่มแผนภูมิ Microsoft Excel เป็น [OleObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/oleobjectframe) ลงในสไลด์ (สำหรับรายละเอียดเพิ่มเติม ดูบทความ "Manage OLE") และจากนั้นเปิดงานนำเสนอใน Microsoft PowerPoint คุณจะเห็นภาพนี้บนสไลด์:

![ข้อความวัตถุ OLE](OLE_object_message.png)

หากคุณต้องการตรวจสอบและยืนยันว่าวัตถุ OLE ของคุณถูกเพิ่มลงในสไลด์ คุณต้องดับเบิลคลิกที่ข้อความ "EMBEDDED OLE OBJECT" หรือคลิกขวาที่ข้อความแล้วเลือกตัวเลือก **วัตถุ > แก้ไข**:

![วัตถุ OLE > แก้ไข](OLE_object_edit.png)

PowerPoint จากนั้นเปิดวัตถุ OLE ฝังอยู่

![ข้อมูลวัตถุ OLE](OLE_object_data.png)

สไลด์อาจยังคงแสดงข้อความ "EMBEDDED OLE OBJECT" อยู่ เมื่อคุณคลิกที่วัตถุ OLE การพรีวิวสไลด์จะอัปเดตและข้อความ "EMBEDDED OLE OBJECT" จะถูกแทนที่ด้วยภาพจริงของวัตถุ OLE

![พรีวิววัตถุ OLE](OLE_object_preview.png)

ตอนนี้คุณอาจต้องการบันทึกงานนำเสนอของคุณเพื่อให้แน่ใจว่าภาพของวัตถุ OLE ถูกอัปเดตอย่างถูกต้อง ด้วยวิธีนี้ หลังจากบันทึกงานนำเสนอแล้ว เมื่อคุณเปิดงานนำเสนออีกครั้ง คุณจะ NOT see the "EMBEDDED OLE OBJECT" message.

## **วิธีแก้ไขอื่น ๆ**

### **วิธีแก้ไข 1: แทนที่ข้อความ "Embedded OLE Object" ด้วยรูปภาพ**

หากคุณไม่ต้องการลบข้อความ "EMBEDDED OLE OBJECT" โดยการเปิดงานนำเสนอใน PowerPoint แล้วบันทึก คุณสามารถแทนที่ข้อความนั้นด้วยภาพพรีวิวที่คุณต้องการได้ โค้ดต่อไปนี้แสดงกระบวนการ:

```cs
using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set a title and the image for the OLE object preview.
oleFrame.SubstitutePictureTitle = "My title";
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

สไลด์ที่มี `OleObjectFrame` จะเปลี่ยนเป็นดังนี้:

![ภาพวัตถุ OLE ใหม่](OLE_object_new_image.png)

### **วิธีแก้ไข 2: สร้างส่วนเสริมสำหรับ PowerPoint**

คุณยังสามารถสร้างส่วนเสริมสำหรับ Microsoft PowerPoint ที่อัปเดตวัตถุ OLE ทั้งหมดเมื่อคุณเปิดงานนำเสนอในโปรแกรมได้