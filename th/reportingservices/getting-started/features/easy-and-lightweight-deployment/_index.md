---
title: การปรับใช้ที่ง่ายและเบา
type: docs
weight: 50
url: /th/reportingservices/easy-and-lightweight-deployment/
---
{{% alert color="primary" %}} 

Aspose.Slides for Reporting Services เป็น [ส่วนขยายการแสดงผล](http://msdn2.microsoft.com/en-us/library/ms154606.aspx) สำหรับ Microsoft SQL Server Reporting Services. 
Aspose.Slides for Reporting Services มีให้เป็นไฟล์ติดตั้ง MSI เดียวที่สามารถติดตั้งบนคอมพิวเตอร์ที่รันหนึ่งในต่อไปนี้: 

- Microsoft SQL Server 2005 Reporting Services (32-bit และ 64-bit)
- Microsoft SQL Server 2008 Reporting Services (32-bit และ 64-bit)

การปรับใช้และจัดการ Aspose.Slides for Reporting Services ด้วยตนเองก็ง่ายเช่นกัน เนื่องจากประกอบด้วยเพียง assembly ของ .NET เพียงอันเดียวคือ *Aspose.Slides* *.ReportingServices.dll* เขียนด้วย C# อย่างสมบูรณ์ ปฏิบัติตาม CLS และมีเพียงโค้ดที่จัดการได้อย่างปลอดภัยเท่านั้น. 

{{% /alert %}} 

ไฟล์ติดตั้ง MSI และไฟล์ดาวน์โหลด ZIP รวม Aspose.Slides for ReportingServices: 

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – สร้างสำหรับ Microsoft SQL Server 2005 และ .NET Framework 2.0 (ใช้สำหรับ x86 และ x64)
- Bin\SSRS2008\Aspose.Slides.ReportingServices.dll – สร้างสำหรับ Microsoft SQL Server 2008 และ .NET Framework 2.0 (ใช้สำหรับ x86 และ x64)

เมื่อทำการติดตั้ง Aspose.Slides.ReportingServices.dll จะถูกคัดลอกไปยังไดเรกทอรี ReportServer\bin และไฟล์กำหนดค่าจะได้รับการอัปเดตเพื่อให้ Reporting Services ทราบถึงส่วนขยายการแสดงผลใหม่ ขั้นตอนเหล่านี้ดำเนินการโดยตัวติดตั้ง Aspose.Slides for Reporting Services แต่อย่างไรก็ตาม คุณก็สามารถทำด้วยตนเองตามที่อธิบายต่อในเอกสารนี้. 

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Figure**: Aspose.Slides.ReportingServices.dll ถูกคัดลอกเข้าไปในไดเรกทอรี **ReportServer\bin** directory.