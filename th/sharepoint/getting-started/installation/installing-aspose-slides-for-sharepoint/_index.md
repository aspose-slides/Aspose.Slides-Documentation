---
title: การติดตั้ง Aspose.Slides for SharePoint
type: docs
weight: 10
url: /th/sharepoint/installing-aspose-slides-for-sharepoint/
description: "ติดตั้ง Aspose.Slides for SharePoint บนฟาร์ม SharePoint: เลือกโปรแกรมติดตั้งตามเวอร์ชัน SharePoint ของคุณ, รันการตรวจสอบระบบ, และปรับใช้และเปิดใช้งานโซลูชัน."
---
## **เนื้อหาแพ็กเกจ**

Aspose.Slides for SharePoint ดาวน์โหลดจาก [download page](https://releases.aspose.com/slides/sharepoint/) เป็นไฟล์ ZIP. ไฟล์ ZIP นี้ประกอบด้วยแพ็กเกจโซลูชัน SharePoint (WSP) หนึ่งไฟล์และโปรแกรมติดตั้งหนึ่งไฟล์สำหรับแต่ละเวอร์ชันของ SharePoint ที่รองรับ:

| เวอร์ชัน SharePoint | โปรแกรมติดตั้ง | แพ็กเกจโซลูชัน |
| :- | :- | :- |
| SharePoint 2007 | Setup2007.exe | Aspose.Slides.SharePoint2007.wsp |
| SharePoint 2010 | Setup2010.exe | Aspose.Slides.SharePoint2010.wsp |
| SharePoint Server 2013 | Setup2013.exe | Aspose.Slides.SharePoint2013.wsp |
| SharePoint Server 2016 | Setup2016.exe | Aspose.Slides.SharePoint2016.wsp |
| SharePoint Server 2019 | Setup2019.exe | Aspose.Slides.SharePoint2019.wsp |

แต่ละโปรแกรมติดตั้งจะมีไฟล์กำหนดค่าอยู่ข้างๆ (เช่น *Setup2019.exe.config*) ที่ระบุชื่อแพ็กจ์โซลูชันที่ติดตั้ง. โฟลเดอร์ *License* มีลิงก์ไปยังข้อตกลงสัญญาอนุญาตผู้ใช้ขั้นสุดท้ายและประกาศสัญญาอนุญาตของบุคคลที่สาม.

Aspose.Slides for SharePoint ถูกบรรจุเป็นโซลูชัน SharePoint ซึ่ง SharePoint จะทำการปรับใช้บนฟาร์มของเซิร์ฟเวอร์. คุณลักษณะของมันจะถูกเปิดหรือปิดการใช้งานต่อคอลเลกชันไซต์.

## **กระบวนการติดตั้ง**

ก่อนทำการติดตั้ง โปรแกรมติดตั้งจะทำการตรวจสอบระบบ. มันตรวจสอบว่า:

- SharePoint ถูกติดตั้งบนเซิร์ฟเวอร์.
- ผู้ใช้ปัจจุบันมีสิทธิ์ในการติดตั้งและปรับใช้โซลูชัน SharePoint.
- บริการ SharePoint Administration ถูกเริ่มทำงาน.
- บริการ SharePoint Timer ถูกเริ่มทำงาน.
- แพ็กจ์โซลูชันที่ระบุในไฟล์กำหนดค่ายังมีอยู่.

บริการ Administration และ Timer จำเป็นเนื่องจากบางขั้นตอนการติดตั้งทำงานเป็นงาน timer ที่กระจายโซลูชันไปยังเซิร์ฟเวอร์ทั้งหมดในฟาร์ม.

### **การรันการติดตั้ง**

เพื่อทำการติดตั้ง Aspose.Slides for SharePoint:

1. แยกไฟล์ ZIP ไปยังไดรฟ์ในเครื่องบนเซิร์ฟเวอร์ที่อยู่ในฟาร์ม SharePoint
2. เรียกใช้โปรแกรมติดตั้งที่ตรงกับเวอร์ชัน SharePoint ของคุณ (ดูตารางข้างต้น) และทำตามคำแนะนำบนหน้าจอ. โปรแกรมติดตั้ง:
   1. ทำการตรวจสอบระบบ. โปรแกรมติดตั้งจะไม่ดำเนินการต่อหากการตรวจสอบใดล้มเหลว.

      **การตรวจสอบระบบ**

      ![หน้าจอการตรวจสอบระบบของโปรแกรมติดตั้ง](installing-aspose-slides-for-sharepoint_1.png)

   2. แสดงข้อตกลงสัญญาอนุญาตผู้ใช้ขั้นสุดท้าย. คุณต้องยอมรับเพื่อดำเนินการต่อ.

      **ข้อตกลงสัญญาอนุญาต**

      ![หน้าจอข้อตกลงสัญญาอนุญาตของโปรแกรมติดตั้ง](installing-aspose-slides-for-sharepoint_2.png)

   3. แสดงเป้าหมายการปรับใช้. เลือกเว็บแอปพลิเคชันและคอลเลกชันไซต์ที่ต้องการเปิดคุณลักษณะ.

      **เลือกเป้าหมายการปรับใช้**

      ![หน้าจอเป้าหมายการปรับใช้คอลเลกชันไซต์ของโปรแกรมติดตั้ง](installing-aspose-slides-for-sharepoint_3.png)

   4. ปรับใช้โซลูชันไปยังฟาร์ม.

      **ความคืบหน้าการติดตั้ง**

      ![หน้าจอความคืบหน้าการติดตั้งของโปรแกรมติดตั้ง](installing-aspose-slides-for-sharepoint_4.png)

   5. เปิดใช้งาน Aspose.Slides for SharePoint บนคอลเลกชันไซต์ที่เลือก
   6. แสดงรายการเว็บแอปพลิเคชันและคอลเลกชันไซต์ที่โซลูชันได้รับการปรับใช้และเปิดใช้งาน

      **การติดตั้งสำเร็จ**

      ![หน้าจอการติดตั้งเสร็จสมบูรณ์ของโปรแกรมติดตั้ง](installing-aspose-slides-for-sharepoint_5.png)

{{% alert color="info" title="Note" %}}
ภาพหน้าจอถูกถ่ายบน SharePoint 2007. โปรแกรมติดตั้งสำหรับเวอร์ชันถัดไปจะผ่านหน้าจอเดียวกัน.
{{% /alert %}}

หากมีการติดตั้ง Aspose.Slides for SharePoint เวอร์ชันเดียวกันอยู่แล้ว โปรแกรมติดตั้งจะเสนอให้ซ่อมแซมหรือถอนการติดตั้ง. หากมีการติดตั้งเวอร์ชันอื่นอยู่ โปรแกรมจะเสนอให้อัปเกรดหรือถอนการติดตั้ง.

หลังการติดตั้ง รายการ **แปลงผ่าน Aspose.Slides** จะปรากฏในเมนูไฟล์ของไลบรารีเอกสารในคอลเลกชันไซต์ที่เลือก (บน SharePoint 2007 จะเป็น **แปลงด้วย Aspose.Slides**). เพื่อแปลงการนำเสนอแรก ให้ดูที่ [การแปลงเอกสาร Microsoft PowerPoint ไปเป็นรูปแบบอื่น](/slides/th/sharepoint/converting-microsoft-powerpoint-documents-into-other-formats/). สิ่งที่โซลูชันเพิ่มไปยังฟาร์มอธิบายไว้ใน [การปรับใช้และเปิดใช้งาน](/slides/th/sharepoint/deployment-and-activation/).

## **คำถามที่พบบ่อย**

**ฉันควรรันโปรแกรมติดตั้งใด?**

เป็นโปรแกรมที่ชื่อสอดคล้องกับเวอร์ชัน SharePoint ของคุณ. ตัวอย่างเช่น ให้เรียกใช้ *Setup2016.exe* บนฟาร์ม SharePoint Server 2016. แต่ละโปรแกรมติดตั้งจะติดตั้งเฉพาะแพ็กจ์โซลูชันของตนเองเท่านั้น.

**ฉันต้องดาวน์โหลดแยกต่างหากสำหรับเวอร์ชันที่มีลิขสิทธิ์หรือไม่?**

ไม่จำเป็น. แพ็กจ์เดียวกันทำงานในโหมดประเมินผลจนกว่าคุณจะติดตั้งโซลูชันลิขสิทธิ์; ดูที่ [การติดตั้ง Aspose.Slides for SharePoint License](/slides/th/sharepoint/installing-aspose-slides-for-sharepoint-license/).

**ฉันจะลบผลิตภัณฑ์นี้อย่างไร?**

เรียกใช้โปรแกรมติดตั้งเดียวกันอีกครั้งและเลือก **Remove**; ดูที่ [การถอนการติดตั้ง Aspose.Slides for SharePoint](/slides/th/sharepoint/uninstalling-aspose-slides-for-sharepoint/).