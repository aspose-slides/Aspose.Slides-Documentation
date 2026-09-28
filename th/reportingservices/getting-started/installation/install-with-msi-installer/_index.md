---
title: ติดตั้งด้วย MSI Installer
type: docs
weight: 20
url: /th/reportingservices/install-with-msi-installer/
keywords:
- ตัวติดตั้ง MSI
- การติดตั้ง
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "ติดตั้ง Aspose.Slides for Reporting Services ด้วยตัวติดตั้ง MSI: สิ่งที่ตัวติดตั้งต้องการ สิ่งที่มันเปลี่ยนแปลงในแต่ละอินสแตนซ์ของเซิร์ฟเวอร์รายงาน, และวิธีตรวจสอบผลลัพธ์."
---
## **การติดตั้ง**

MSI installer เป็นวิธีที่ง่ายที่สุดในการติดตั้ง Aspose.Slides for Reporting Services. จำเป็นต้องมี .NET Framework 3.5 และสิทธิ์ผู้ดูแลระบบบนเซิร์ฟเวอร์รายงาน; ดู [ความต้องการระบบ](/slides/th/reportingservices/system-requirements/).

1. ดาวน์โหลด MSI installer, *Aspose.Slides for Reporting Services XX.XX*, จาก [หน้าดาวน์โหลด](https://releases.aspose.com/slides/th/reportingservices/) แล้วคัดลอกไปยังเซิร์ฟเวอร์รายงาน.
1. เรียกใช้โดยเป็นผู้ดูแลระบบ. หากไม่มี .NET Framework 3.5 ตัวติดตั้งจะหยุดพร้อมข้อความ; ให้ติดตั้งคุณลักษณะของ .NET Framework 3.5 แล้วเรียกใช้อีกครั้ง.
1. ยอมรับข้อตกลงการใช้งาน.
1. บนหน้า **Custom Setup**, ต้นไม้ฟีเจอร์จะแสดงแต่ละอินสแตนซ์ของ SQL Server Reporting Services และ Power BI Report Server ที่ตัวติดตั้งตรวจพบบนเครื่อง. เพื่อคงอินสแตนซ์เดิมไว้, คลิกไอคอนของมันและเลือก **Entire feature will be unavailable**. รุ่น Express ไม่รองรับส่วนขยายการแสดงผล, ดังนั้นอย่าเลือกอินสแตนซ์ Express. ตัวติดตั้งจะซ่อนอินสแตนซ์ Express ของ SQL Server 2016 และก่อนหน้า.
1. เลือก **Next**, แล้วคลิก **Install**.

ฟีเจอร์ **Rpl Export** ทางเลือกจะไม่ได้เลือกโดยค่าเริ่มต้น. มันเพิ่มส่วนขยายที่ซ่อนอยู่ซึ่งบันทึกรายงานในรูปแบบ RPL, ซึ่งมีประโยชน์เมื่อคุณส่งรายงานปัญหาไปยัง Aspose; ดู [การส่งออกรายงานเป็นรูปแบบ RPL](/slides/th/reportingservices/exporting-reports-to-rpl-format/).

## **สิ่งที่ตัวติดตั้งเปลี่ยนแปลง**

ตัวติดตั้งจะเก็บไฟล์ไว้ใน *Aspose\Aspose.Slides for Reporting Services* ภายใต้โฟลเดอร์ Program Files — *Program Files (x86)* บน Windows 64-bit, เนื่องจากตัวติดตั้งเป็นแพ็คเกจ 32-bit. จากนั้นสำหรับแต่ละอินสแตนซ์ที่เลือก, มันจะ:

- คัดลอก *Aspose.Slides.ReportingServices.dll* ไปยังโฟลเดอร์ *ReportServer\bin* ของอินสแตนซ์ — สร้างสำหรับ SQL Server 2005, หรือสร้างสำหรับ SQL Server 2008 ขึ้นไปและ Power BI Report Server;
- เพิ่มส่วนขยายการเรนเดอร์หกตัว — ASPPT, ASPPS, ASPPTX, ASPPSX, ASXPSS และ ASODP — ไปยังองค์ประกอบ `<Render>` ของ *rsreportserver.config*;
- เพิ่มกลุ่มโค้ดที่ให้ความไว้ใจเต็มที่แก่ assembly ใน *rssrvpolicy.config*;
- บันทึกสำเนาของไฟล์การกำหนดค่าที่เปลี่ยนแปลงแต่ละไฟล์, โดยเพิ่มนามสกุล *.bak* ไปที่ชื่อไฟล์.

[Install Manually](/slides/th/reportingservices/install-manually/) แสดงการเปลี่ยนแปลงเหล่านี้ขั้นตอนต่อขั้นตอน.

หากไม่สามารถกำหนดค่าอินสแตนซ์ได้, ตัวติดตั้งจะแสดงชื่อในข้อความและบันทึกรายละเอียดลงในไฟล์ *rserrors&lt;date&gt;.log* ในโฟลเดอร์การติดตั้ง. ให้ติดตั้งส่วนขยายบนอินสแตนซ์นั้นด้วยตนเอง.

## **ตรวจสอบการติดตั้ง**

เปิดรายงานแบบแบ่งหน้าในพอร์ทัลเว็บ (Report Manager บน SQL Server 2014 และก่อนหน้า) และเปิดรายการ **Export**. ตอนนี้รวมรูปแบบต่อไปนี้:

- PPT - การนำเสนอ PowerPoint ผ่าน Aspose.Slides
- PPS - สไลด์โชว์ PowerPoint ผ่าน Aspose.Slides
- PPTX - การนำเสนอ PowerPoint 2007 ผ่าน Aspose.Slides
- PPSX - สไลด์โชว์ PowerPoint 2007 ผ่าน Aspose.Slides
- ODP - การนำเสนอ OpenDocument ผ่าน Aspose.Slides
- XPS - ผ่าน Aspose.Slides

หากไม่มีลิขสิทธิ์, ไฟล์ที่ส่งออกจะมีลายน้ำการประเมิน; ดู [Licensing](/slides/th/reportingservices/license-aspose-slides-for-reporting-services/).

## **เมื่อควรติดตั้งด้วยตนเอง**

ติดตั้งส่วนขยาย [manually](/slides/th/reportingservices/install-manually/) ด้วยตนเองเมื่อ:

- ตัวติดตั้งไม่สามารถกำหนดค่าอินสแตนซ์ได้, ตัวอย่างเช่นเนื่องจากการตั้งค่าความปลอดภัยบนเซิร์ฟเวอร์;
- หลังการอัปเกรด, คุณต้องการแทนที่เฉพาะ assembly เท่านั้นแทนการถอนการติดตั้งเวอร์ชันเก่าและรันตัวติดตั้งใหม่.

การถอนการติดตั้งผลิตภัณฑ์จะลบ assembly และรายการการกำหนดค่าออกจากแต่ละอินสแตนซ์.