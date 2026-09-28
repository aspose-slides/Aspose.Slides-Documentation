---
title: ข้อกำหนดของระบบ
type: docs
weight: 15
url: /th/reportingservices/system-requirements/
keywords:
- ข้อกำหนดของระบบ
- SQL Server Reporting Services
- SSRS
- Power BI Report Server
- .NET Framework 3.5
- Aspose.Slides for Reporting Services
description: "ตรวจสอบว่าเซิร์ฟเวอร์รายงาน รุ่นต่างๆ และเวอร์ชันของ .NET Framework ที่ Aspose.Slides for Reporting Services ต้องการก่อนที่คุณจะติดตั้งมัน."
---
## **ภาพรวม**

Aspose.Slides for Reporting Services ทำงานภายในเซิร์ฟเวอร์รายงานเป็นส่วนขยายการเรนเดอร์ หน้านี้แสดงรายการสิ่งที่เครื่องเซิร์ฟเวอร์รายงานต้องมีก่อนที่คุณจะ [ติดตั้ง](/slides/th/reportingservices/installing-aspose-slides-for-reporting-services/) มัน. Microsoft PowerPoint และ Microsoft Office ไม่จำเป็น.

## **เซิร์ฟเวอร์รายงานที่รองรับ**

- Microsoft SQL Server 2005 Reporting Services
- Microsoft SQL Server 2008 and 2008 R2 Reporting Services
- Microsoft SQL Server 2012 Reporting Services
- Microsoft SQL Server 2014 Reporting Services
- Microsoft SQL Server 2016 Reporting Services
- Microsoft SQL Server 2017 Reporting Services
- Microsoft SQL Server 2019 Reporting Services
- Power BI Report Server, สำหรับรายงานแบบแบ่งหน้า (RDL)

รองรับเซิร์ฟเวอร์รายงานทั้งแบบ 32-bit และ 64-bit SQL Server 2005 ใช้บิลด์ของส่วนขยายของตนเอง; เวอร์ชันหลังจากนั้นทั้งหมดและ Power BI Report Server ใช้บิลด์เดียวกัน [ติดตั้งด้วยตนเอง](/slides/th/reportingservices/install-manually/) แสดงไฟล์ที่ต้องคัดลอก.

หากเวอร์ชันเซิร์ฟเวอร์รายงานของคุณไม่ได้อยู่ในรายการนี้ ให้ถามใน [ฟอรัมสนับสนุนฟรี](https://forum.aspose.com/c/slides/11) ก่อนที่คุณจะปรับใช้.

## **รุ่นของเซิร์ฟเวอร์รายงาน**

สำหรับ SQL Server 2016 Reporting Services และรุ่นต่อไปและสำหรับ Power BI Report Server, Microsoft รองรับส่วนขยายการเรนเดอร์ในรุ่น Enterprise, Standard, Developer และ Evaluation; รุ่น Web และ Express ไม่รองรับ ดูที่ [ฟีเจอร์ของ Reporting Services ที่รองรับตามรุ่น](https://learn.microsoft.com/en-us/sql/reporting-services/reporting-services-features-supported-by-the-editions-of-sql-server). ตัวติดตั้ง MSI จะข้ามอินสแตนซ์รุ่น Express ของ SQL Server 2016 และก่อนหน้า.

## **.NET Framework**

.NET Framework 3.5 ต้องติดตั้งบนเครื่องเซิร์ฟเวอร์รายงาน. ชุดประกอบของส่วนขยายสร้างสำหรับ runtime ของ .NET Framework 2.0, และตัวติดตั้ง MSI จะหยุดพร้อมข้อความหากไม่มี .NET Framework 3.5. บน Windows Server ให้เพิ่ม **.NET Framework 3.5 Features** ในวิซาร์ด Add Roles and Features; ดูที่ [ติดตั้ง .NET Framework 3.5 บน Windows](https://learn.microsoft.com/en-us/dotnet/framework/install/dotnet-35-windows).

## **สิทธิ์**

การติดตั้งส่วนขยายจะเปลี่ยนไฟล์ในโฟลเดอร์เซิร์ฟเวอร์รายงาน, ดังนั้นทั้งสองวิธีการติดตั้งต้องการสิทธิ์ผู้ดูแลระบบในเครื่อง. หากคุณเริ่มตัวติดตั้ง MSI โดยไม่มีสิทธิ์เหล่านั้น, มันจะเสนให้รีสตาร์ทด้วยสิทธิ์ผู้ดูแลระบบ.

## **คำถามที่พบบ่อย**

**ฉันต้องการ Microsoft PowerPoint บนเซิร์ฟเวอร์รายงานหรือไม่?**

ไม่. ส่วนขยายสร้างงานนำเสนอด้วยตนเอง; ไม่จำเป็นต้องติดตั้ง PowerPoint หรือ Microsoft Office.

**ฉันสามารถติดตั้งส่วนขยายบนรุ่น Express ได้หรือไม่?**

ไม่. รุ่น Express ไม่รองรับส่วนขยายการเรนเดอร์. ตัวติดตั้ง MSI จะซ่อนอินสแตนซ์ Express ของ SQL Server 2016 และก่อนหน้า; ในเวอร์ชันหลังๆ อย่าเลือกอินสแตนซ์ Express.

**รูปแบบใดบ้างที่ส่วนขยายเพิ่มลงในรายการส่งออก?**

PPT, PPS, PPTX, PPSX, ODP และ XPS. ดูที่ [รูปแบบไฟล์ที่รองรับ](/slides/th/reportingservices/supported-file-formats/).