---
title: อัปเดตวัตถุ OLE อัตโนมัติด้วยแอดอิน PowerPoint
type: docs
weight: 10
url: /th/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- วัตถุ OLE
- อัปเดต OLE
- อัตโนมัติ
- แอดอิน
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "ค้นพบวิธีการอัปเดตแผนภูมิและวัตถุ OLE โดยอัตโนมัติใน PowerPoint ด้วยแอดอินและ Aspose.Slides for Java พร้อมตัวอย่างโค้ดและเคล็ดลับการเพิ่มประสิทธิภาพ"
---
## **บทนำ**

หนึ่งในคำถามที่พบบ่อยที่สุดจากลูกค้า Aspose.Slides for Java คือวิธีการสร้างหรือแก้ไขแผนภูมิที่สามารถแก้ไขได้ (หรือวัตถุ OLE อื่น) เพื่อให้มันอัปเดตอัตโนมัติเมื่อเปิดการนำเสนอ อย่างไรก็ตาม PowerPoint ไม่รองรับแมโครอัตโนมัติในลักษณะเดียวกับ Excelและ Word แมโครที่มีอยู่คือ `Auto_Open` และ `Auto_Close` และแมโครเหล่านี้จะทำงานอัตโนมัติได้เฉพาะจากแอดอินเท่านั้น เคล็ดลับทางเทคนิคสั้นนี้จะแสดงวิธีทำเช่นนั้น

## **อัปเดตวัตถุ OLE อัตโนมัติ**

ก่อนแรก มีแอดอินฟรีหลายตัวที่เพิ่มฟีเจอร์แมโคร Auto_Open ให้กับ PowerPoint ตัวอย่างเช่น [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) และ [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

หลังจากติดตั้งหนึ่งในแอดอินเหล่านี้ ให้เพิ่มแมโคร `Auto_Open()` (หรือ `OnPresentationOpen()` หากคุณใช้ Event Generator) ไปยังเทมเพลตการนำเสนอของคุณตามที่แสดงด้านล่าง:

```java
// วนลูปผ่านแต่ละสไลด์ในงานนำเสนอ.
for (var oSlide : ActivePresentation.Slides) {
    // วนลูปผ่านรูปทรงทั้งหมดบนสไลด์ปัจจุบัน.
    for (var oShape : oSlide.Shapes) {
        // ตรวจสอบว่ารูปทรงเป็นวัตถุ OLE หรือไม่.
        if ((oShape.Type == msoEmbeddedOLEObject)) {
            // พบวัตถุ OLE. ดึงอ้างอิงของวัตถุและอัปเดตมัน.
            oObject = oShape.OLEFormat.Object;
            oObject.Application.Update();
            // ตอนนี้ออกจากโปรแกรมเซิร์ฟเวอร์ OLE.
            // การทำเช่นนี้จะปล่อยหน่วยความจำและป้องกันปัญหาต่าง ๆ.
            // นอกจากนี้ ให้ตั้งค่า oObject เป็น Nothing เพื่อปล่อยวัตถุ.
            oObject.Application.Quit();
            oObject = null;
        }
    }
}
```

การเปลี่ยนแปลงใด ๆ ที่ทำกับวัตถุ OLE ด้วย Aspose.Slides for Java จะถูกอัปเดตโดยอัตโนมัติเมื่อ PowerPoint เปิดการนำเสนอ หากคุณมีวัตถุ OLE จำนวนมากและไม่ต้องการอัปเดตทั้งหมด เพียงเพิ่มแท็กกำหนดเองให้กับรูปร่างที่ต้องการประมวลผลและตรวจสอบในแมโคร.