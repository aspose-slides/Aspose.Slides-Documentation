---
title: อัปเดตวัตถุ OLE โดยอัตโนมัติด้วยแอดอิน PowerPoint
type: docs
weight: 10
url: /th/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- วัตถุ OLE
- อัปเดต OLE
- โดยอัตโนมัติ
- แอดอิน
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ค้นพบวิธีการอัปเดตอัตโนมัติแผนภูมิและวัตถุ OLE ใน PowerPoint ด้วยแอดอินและ Aspose.Slides for .NET พร้อมตัวอย่างโค้ดที่ใช้งานได้จริงและเคล็ดลับการเพิ่มประสิทธิภาพ"
---
## **บทนำ**

หนึ่งในคำถามที่พบบ่อยที่สุดที่ลูกค้า Aspose.Slides for .NET ถามคือวิธีการสร้างหรือแก้ไขแผนภูมิที่แก้ไขได้ (หรือวัตถุ OLE อื่น) เพื่อให้มันอัปเดตโดยอัตโนมัติเมื่อเปิดงานนำเสนอ อย่างไรก็ตาม PowerPoint ไม่รองรับแมโครอัตโนมัติในลักษณะเดียวกับ Excel และ Word แมโครที่มีอยู่เพียงสองตัวคือ `Auto_Open` และ `Auto_Close` ซึ่งทำงานอัตโนมัติได้เฉพาะจากแอดอินเท่านั้น เคล็ดลับทางเทคนิคสั้นนี้จะแสดงวิธีทำให้สำเร็จ

## **อัปเดตวัตถุ OLE โดยอัตโนมัติ**

ก่อนแรก มีแอดอินฟรีแวร์หลายตัวที่เพิ่มคุณสมบัติแมโคร Auto_Open ให้กับ PowerPoint เช่น [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) และ [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

หลังจากติดตั้งแอดอินใดแอดอินหนึ่ง เพียงแค่เพิ่มแมโคร `Auto_Open()` (หรือ `OnPresentationOpen()` หากคุณใช้ Event Generator) ลงในงานนำเสนอเทมเพลตของคุณตามที่แสดงด้านล่าง:

```cs
public void Auto_Open()
{
    // วนลูปผ่านแต่ละสไลด์ในงานนำเสนอ.
    foreach (var oSlide in ActivePresentation.Slides)
    {
        // วนลูปผ่านรูปทรงทั้งหมดบนสไลด์ปัจจุบัน.
        foreach (var oShape in oSlide.Shapes)
        {
            // ตรวจสอบว่ารูปร่างเป็นวัตถุ OLE หรือไม่.
            if (oShape.Type == msoEmbeddedOLEObject)
            {
                // พบวัตถุ OLE. รับการอ้างอิงวัตถุแล้วอัปเดตมัน.
                oObject = oShape.OLEFormat.Object;
                oObject.Application.Update();

                // ตอนนี้ออกจากโปรแกรมเซิร์ฟเวอร์ OLE.
                // สิ่งนี้จะปล่อยหน่วยความจำและป้องกันปัญหาใด ๆ.
                // นอกจากนี้ ตั้งค่า oObject เป็น Nothing เพื่อปล่อยวัตถุ.
                oObject.Application.Quit();
                oObject = null;
            }
        }
    }
}
```

การเปลี่ยนแปลงใด ๆ ที่ทำกับวัตถุ OLE ด้วย Aspose.Slides for .NET จะถูกอัปเดตโดยอัตโนมัติเมื่อ PowerPoint เปิดงานนำเสนอ หากคุณมีวัตถุ OLE จำนวนมากและไม่ต้องการอัปเดตทั้งหมด เพียงเพิ่มแท็กกำหนดเองให้กับรูปร่างที่ต้องการประมวลผลและตรวจสอบในแมโคร