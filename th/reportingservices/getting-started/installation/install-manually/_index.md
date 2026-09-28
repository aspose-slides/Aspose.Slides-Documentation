---
title: การติดตั้งด้วยตนเอง
type: docs
weight: 30
url: /th/reportingservices/install-manually/
keywords:
- การติดตั้งด้วยตนเอง
- rsreportserver.config
- rssrvpolicy.config
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "ติดตั้ง Aspose.Slides for Reporting Services ด้วยตนเองจากแพ็กเกจ ZIP ที่มีเฉพาะ DLLs: กำหนดว่า Assembly ใดจะคัดลอกและต้องเพิ่มอะไรใน rsreportserver.config และ rssrvpolicy.config."
---
## **ภาพรวม**

ทำตามขั้นตอนเหล่านี้เพื่อติดตั้ง Aspose.Slides for Reporting Services โดยไม่ใช้ตัวติดตั้ง MSI จากแพ็กเกจ ZIP *Aspose.Slides for Reporting Services XX.XX (DLLs Only)* บน[download page](https://releases.aspose.com/slides/th/reportingservices/). พวกมันจะแสดงส่วนขยายเดียวกับ[MSI installer](/slides/th/reportingservices/install-with-msi-installer/). ทำซ้ำสำหรับแต่ละอินสแตนซ์ของเซิร์ฟเวอร์รายงาน

ก่อนเริ่ม ตรวจสอบ[system requirements](/slides/th/reportingservices/system-requirements/). คุณต้องมีสิทธิ์ผู้ดูแลระบบระดับท้องถิ่นบนเซิร์ฟเวอร์รายงาน

## **เลือก Assembly**

แพ็กเกจ ZIP มีหลายบิลด์ คัดลอกไฟล์ *Aspose.Slides.ReportingServices.dll* เพียงไฟล์เดียวไปยังเซิร์ฟเวอร์รายงาน:

| ไฟล์ในแพ็กเกจ ZIP | ใช้สำหรับ |
| :- | :- |
| *Bin\Universal\Aspose.Slides.ReportingServices.dll* | SQL Server 2008 ขึ้นไป Reporting Services และ Power BI Report Server |
| *Bin\SSRS2005\Aspose.Slides.ReportingServices.dll* | SQL Server 2005 Reporting Services |
| *Bin\ReportViewer2010\Aspose.Slides.ReportingServices.dll* | ไม่ใช่สำหรับเซิร์ฟเวอร์รายงาน: แอปพลิเคชันที่ส่งออกจากคอนโทรล ReportViewer 2010 หรือ 2012, ดู[Using Aspose.Slides with ReportViewer 2010 and 2012](/slides/th/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/) |
| *Bin\RplExport\Aspose.ReportingServices.Debug.Rpl.dll* | ตัวเลือก: บันทึกรายงานในรูปแบบ RPL สำหรับรายงานปัญหา, ดู[Exporting Reports to RPL Format](/slides/th/reportingservices/exporting-reports-to-rpl-format/) |

## **ค้นหาโฟลเดอร์ Report Server**

ขั้นตอนต่อไปนี้อ้างอิงถึงโฟลเดอร์ *ReportServer* ของเซิร์ฟเวอร์รายงาน ซึ่งเก็บไฟล์ *rsreportserver.config* และ *rssrvpolicy.config*. ในการติดตั้งค่าเริ่มต้น โฟลเดอร์นี้คือ:

| เซิร์ฟเวอร์รายงาน | โฟลเดอร์ *ReportServer* เริ่มต้น |
| :- | :- |
| SQL Server 2017 ขึ้นไป Reporting Services | `C:\Program Files\Microsoft SQL Server Reporting Services\SSRS\ReportServer` |
| Power BI Report Server | `C:\Program Files\Microsoft Power BI Report Server\PBIRS\ReportServer` |
| SQL Server 2016 และก่อนหน้า Reporting Services | `C:\Program Files\Microsoft SQL Server\<instance folder>\Reporting Services\ReportServer`, โดยที่โฟลเดอร์อินสแตนซ์อาจเป็น `MSRS13.MSSQLSERVER` สำหรับ SQL Server 2016 หรือ `MSSQL.x` สำหรับ SQL Server 2005 |

สำหรับตำแหน่งเพิ่มเติม ดูบทความของ Microsoft[RsReportServer.config configuration file](https://learn.microsoft.com/en-us/sql/reporting-services/report-server/rsreportserver-config-configuration-file)

## **ติดตั้ง Extension**

1. คัดลอก Assembly ที่คุณเลือกไปยังโฟลเดอร์ย่อย *bin* ของโฟลเดอร์ *ReportServer*  

   ไฟล์ที่คัดลอกต้องไม่มีการกำหนดสิทธิ์ NTFS อย่างเจาะจง มิฉะนั้นเซิร์ฟเวอร์รายงานจะถูกปฏิเสธการเข้าถึงเมื่อโหลด Assembly และรูปแบบการส่งออกใหม่จะไม่แสดง ให้คลิกขวาไฟล์ เลือก**Properties** แล้วที่แท็บ**Security** ลบสิทธิ์ที่กำหนดโดยตรงไว้ ทั้งหมดให้เหลือเฉพาะสิทธิ์ที่สืบทอด หากแท็บ**General** มีตัวเลือก**Unblock** ให้เลือก

2. บันทึกสำเนา*rsreportserver.config* แล้วเปิดไฟล์ในโปรแกรมแก้ไขข้อความ เพิ่มรายการเหล่านี้ภายในแท็ก `<Render>`:  

   ```xml
   <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASXPSS" Type="Aspose.Slides.ReportingServices.XpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASODP" Type="Aspose.Slides.ReportingServices.OdpRenderer,Aspose.Slides.ReportingServices"/>
   ```

   แต่ละรายการลงทะเบียนรูปแบบการส่งออกหนึ่งรูปแบบ; `Name` ต้องไม่ซ้ำกับส่วนขยายการเรนเดอร์อื่น ตัวติดตั้ง MSI ลงทะเบียนชื่อและประเภทเดียวกันหกรายการ หากไม่ต้องการรูปแบบใดในรายการส่งออก ให้ลบรายการนั้นออก

3. บันทึกสำเนา*rssrvpolicy.config* แล้วเปิดไฟล์ในโปรแกรมแก้ไขข้อความ ค้นหากลุ่มโค้ดที่ `Description` เป็น "This code group grants MyComputer code Execution permission." แล้วเพิ่มกลุ่มโค้ดนี้เป็นบุตรสุดท้ายของมัน:  

   ```xml
   <CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_for_Reporting_Services" Description="This code group grants full trust to the Aspose.Slides.ReportingServices.dll assembly.">
       <IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf"/>
   </CodeGroup>
   ```

   `PublicKeyBlob` คือคีย์สาธารณะของ Assembly Aspose.Slides.ReportingServices เก็บไว้ในบรรทัดเดียว

4. บันทึกไฟล์ทั้งสอง เซิร์ฟเวอร์รายงานจะอ่านไฟล์กำหนดค่าใหม่ทุกครั้งที่บันทึก หากไฟล์มี XML ที่ไม่ถูกต้อง เซิร์ฟเวอร์จะละเลยหรือไม่เริ่มทำงาน ดังนั้นให้กู้คืนสำเนาที่บันทึกไว้หากพบปัญหา

## **ตรวจสอบการติดตั้ง**

เปิดรายงานแบบหน้าในเว็บพอร์ทัล (Report Manager บน SQL Server 2014 หรือต่ำกว่า) แล้วเปิดรายการ**Export** รายการนี้จะปรากฏรูปแบบต่อไปนี้:

- PPT – พรีเซนเทชัน PowerPoint ผ่าน Aspose.Slides
- PPS – สไลด์โชว์ PowerPoint ผ่าน Aspose.Slides
- PPTX – พรีเซนเทชัน PowerPoint 2007 ผ่าน Aspose.Slides
- PPSX – สไลด์โชว์ PowerPoint 2007 ผ่าน Aspose.Slides
- ODP – พรีเซนเทชัน OpenDocument ผ่าน Aspose.Slides
- XPS – ผ่าน Aspose.Slides

เลือกหนึ่งรายการเพื่อส่งออกรายงาน ไฟล์จะเปิดในแอปพลิเคชันที่เชื่อมโยงกับรูปแบบนั้น

![รายงานที่ส่งออกเป็น PowerPoint โดย Aspose.Slides for Reporting Services](install-manually_2.png)

หากรูปแบบไม่ปรากฏ ตรวจสอบสิทธิ์ NTFS ของ Assembly ที่คัดลอก หากไม่มีลิขสิทธิ์ ไฟล์ที่ส่งออกจะมีลายน้ำการประเมิน; ดู[Licensing](/slides/th/reportingservices/license-aspose-slides-for-reporting-services/).