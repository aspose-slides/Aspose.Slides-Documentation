---
title: การปรับใช้ที่ง่ายและเบา
type: docs
weight: 50
url: /th/reportingservices/easy-and-lightweight-deployment/
description: "เรียนรู้วิธีการปรับใช้ Aspose.Slides for Reporting Services: ชุดประกอบหนึ่งชุดในโฟลเดอร์ bin ของเซิร์ฟเวอร์รายงาน, ลงทะเบียนในการกำหนดค่าของเซิร์ฟเวอร์รายงาน."
---
{{% alert color="info" title="หมายเหตุ" %}}

Aspose.Slides for Reporting Services เป็นส่วนขยายการแสดงผลสำหรับ Microsoft SQL Server Reporting Services และ Power BI Report Server.
Aspose.Slides for Reporting Services มีให้เป็นตัวติดตั้ง MSI ตัวเดียวที่สามารถติดตั้งบนคอมพิวเตอร์ที่ใช้เซิร์ฟเวอร์รายงานที่รองรับ, 32‑bit หรือ 64‑bit; ดู [System Requirements](/slides/th/reportingservices/system-requirements/).

การปรับใช้และจัดการ Aspose.Slides for Reporting Services ด้วยตนเองก็ง่ายเช่นกัน เนื่องจากประกอบด้วยเพียงชุดประกอบ .NET ชุดเดียวคือ *Aspose.Slides* *.ReportingServices.dll* เขียนด้วย C# อย่างสมบูรณ์, ปฏิบัติตาม CLS และมีเพียงโค้ดที่จัดการได้อย่างปลอดภัยเท่านั้น.

{{% /alert %}}

ไฟล์ ZIP ที่ดาวน์โหลดรวมสองชุดของ Aspose.Slides.ReportingServices.dll สำหรับเซิร์ฟเวอร์รายงาน:

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – สร้างสำหรับ Microsoft SQL Server 2005 และ .NET Framework 2.0 (ใช้สำหรับ x86 และ x64)
- Bin\Universal\Aspose.Slides.ReportingServices.dll – สร้างสำหรับ Microsoft SQL Server 2008 และรุ่นต่อไป, Power BI Report Server และ .NET Framework 2.0 (ใช้สำหรับ x86 และ x64)

ตัวติดตั้ง MSI จะติดตั้งสองชุดเดียวกันและเลือกชุดที่เหมาะสมสำหรับแต่ละอินสแตนซ์ของเซิร์ฟเวอร์รายงาน. [Install Manually](/slides/th/reportingservices/install-manually/) แสดงรายการไฟล์ทั้งหมดในไฟล์ ZIP ที่ดาวน์โหลด.

เมื่อทำการติดตั้ง, Aspose.Slides.ReportingServices.dll จะถูกคัดลอกไปยังไดเรกทอรี ReportServer\bin และไฟล์การกำหนดค่าจะถูกอัปเดตเพื่อให้ Reporting Services รับรู้ถึงส่วนขยายการแสดงผลใหม่. ขั้นตอนเหล่านี้ดำเนินการโดยตัวติดตั้ง Aspose.Slides for Reporting Services, แต่คุณก็สามารถทำด้วยตนเองตามที่อธิบายในเอกสารนี้ต่อไป.

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**รูปที่**: Aspose.Slides.ReportingServices.dll ถูกคัดลอกไปยังไดเรกทอรี **ReportServer\bin**.