---
title: ปัญหาการแสดงตัวอย่างวัตถุเมื่อเพิ่ม OleObjectFrame
linktitle: ปัญหา OLE Object
type: docs
weight: 10
url: /th/php-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- ปัญหาการแสดงตัวอย่าง
- ฝังวัตถุ
- ฝังไฟล์
- วัตถุเปลี่ยนแปลง
- การแสดงตัวอย่างวัตถุ
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้ว่าทำไมข้อความ EMBEDDED OLE OBJECT ปรากฏเมื่อเพิ่ม OleObjectFrame ใน Aspose.Slides สำหรับ PHP และวิธีแก้ไขปัญหาการแสดงตัวอย่างในงานนำเสนอ PPT, PPTX และ ODP"
---
## **คำนำ**

เมื่อใช้ Aspose.Slides for PHP ผ่าน Java และคุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/oleobjectframe/) ลงในสไลด์ จะมีข้อความ “EMBEDDED OLE OBJECT” แสดงบนสไลด์ผลลัพธ์ ข้อความนี้เป็นตามตั้งใจและ NOT a bug.

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการทำงานกับวัตถุ OLE ดูที่ [Manage OLE](/slides/th/php-java/manage-ole/).

## **คำอธิบายและวิธีแก้**

Aspose.Slides แสดงข้อความ “EMBEDDED OLE OBJECT” เพื่อแจ้งว่าวัตถุ OLE ได้รับการเปลี่ยนแปลงและต้องอัปเดตภาพตัวอย่าง

ตัวอย่างเช่น หากคุณเพิ่มแผนภูมิ Microsoft Excel เป็น [OleObjectFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/oleobjectframe/) ลงในสไลด์ (ดูรายละเอียดเพิ่มเติมในบทความ “Manage OLE”) แล้วเปิดงานนำเสนอใน Microsoft PowerPoint คุณจะเห็นภาพนี้บนสไลด์:

![OLE object message](OLE_object_message.png)

หากคุณต้องการตรวจสอบและยืนยันว่าวัตถุ OLE ของคุณถูกเพิ่มลงในสไลด์ คุณต้องดับเบิลคลิกที่ข้อความ “EMBEDDED OLE OBJECT” หรือคุณสามารถคลิกขวาที่ข้อความแล้วเลือกตัวเลือก **Object > Edit**

![OLE object > Edit](OLE_object_edit.png)

PowerPoint จากนั้นจะเปิดวัตถุ OLE ที่ฝังอยู่

![OLE object data](OLE_object_data.png)

สไลด์อาจยังคงแสดงข้อความ “EMBEDDED OLE OBJECT” อยู่ เมื่อคุณคลิกที่วัตถุ OLE การแสดงตัวอย่างสไลด์จะอัปเดตและข้อความ “EMBEDDED OLE OBJECT” จะถูกแทนที่ด้วยภาพจริงของวัตถุ OLE

![OLE object preview](OLE_object_preview.png)

ตอนนี้คุณอาจต้องการบันทึกงานนำเสนอของคุณเพื่อให้มั่นใจว่าภาพของวัตถุ OLE จะอัปเดตอย่างถูกต้อง ด้วยวิธีนี้ หลังจากบันทึกงานนำเสนอแล้ว เมื่อคุณเปิดงานนำเสนออีกครั้ง คุณจะ NOT see the “EMBEDDED OLE OBJECT” message.

## **วิธีแก้ไขอื่น ๆ**

### **วิธีแก้ 1: แทนที่ข้อความ “Embedded OLE Object” ด้วยภาพ**

หากคุณไม่ต้องการลบข้อความ “EMBEDDED OLE OBJECT” ด้วยการเปิดงานนำเสนอใน PowerPoint แล้วบันทึกอีกครั้ง คุณสามารถแทนที่ข้อความด้วยภาพตัวอย่างที่คุณต้องการได้ โค้ดต่อไปนี้แสดงกระบวนการนี้:

```php
$presentation = new Presentation("embeddedOLE.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $oleFrame = $slide->getShapes()->get_Item(0);

    // เพิ่มรูปภาพไปยังทรัพยากรของงานนำเสนอ.
    $image = Images::fromFile("myImage.png");
    $oleImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    // ตั้งชื่อเรื่องและรูปภาพสำหรับการแสดงตัวอย่างวัตถุ OLE.
    $oleFrame->setSubstitutePictureTitle("My title");
    $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
    $oleFrame->setObjectIcon(false);

    $presentation->save("embeddedOLE-newImage.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

สไลด์ที่มี `OleObjectFrame` จะเปลี่ยนเป็นดังนี้:

![New OLE object image](OLE_object_new_image.png)

### **วิธีแก้ 2: สร้างส่วนเสริมสำหรับ PowerPoint**

คุณยังสามารถสร้างส่วนเสริมสำหรับ Microsoft PowerPoint ที่จะอัปเดตวัตถุ OLE ทั้งหมดเมื่อคุณเปิดงานนำเสนอในโปรแกรมได้