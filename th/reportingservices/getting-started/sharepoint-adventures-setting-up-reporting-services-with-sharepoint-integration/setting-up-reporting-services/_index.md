---
title: การตั้งค่า Reporting Services
type: docs
weight: 30
url: /th/reportingservices/setting-up-reporting-services/
---
{{% alert color="primary" %}} 

จุดแรกที่เราจะไปบน RS Server คือ Reporting Services Configuration Manager. 

{{% /alert %}} 
## **บัญชีบริการ**
ตรวจสอบให้แน่ใจว่าคุณเข้าใจว่าบัญชีบริการใดที่ใช้สำหรับ Reporting Services หากพบปัญหาอาจเกี่ยวข้องกับบัญชีบริการที่ใช้ ค่าเริ่มต้นคือ Network Service ทุกครั้งที่ฉันทำการปรับใช้บิลด์ใหม่ ฉันจะใช้ Domain Account เสมอ เพราะเป็นจุดที่มักเกิดปัญหา สำหรับการตั้งค่านี้บนเซิร์ฟเวอร์ของฉัน ฉันได้ใช้ Domain Account ชื่อ **RSService**. 
## **Web Service URL**
เราจะต้องตั้งค่า Web Service URL นี้คือไดเรกทอรีเสมือน (vdir) **ReportServer** ที่โฮสต์เว็บเซอร์วิสที่ Reporting Services ใช้และที่ SharePoint จะสื่อสารด้วย หากคุณไม่ได้ต้องการปรับแต่งคุณสมบัติของ vdir (เช่น SSL, พอร์ต, host header ฯลฯ) คุณสามารถคลิก Apply ที่นี่แล้วใช้งานได้เลย. 

![todo:image_alt_text](setting-up-reporting-services_1.png)

![todo:image_alt_text](setting-up-reporting-services_2.png)


**รูปที่ 3**: ตั้งค่า Web Service URL 

เมื่อเสร็จแล้วคุณควรเห็นรูปต่อไปนี้. 

![todo:image_alt_text](setting-up-reporting-services_3.png)

**รูปที่ 4**: การตั้งค่า Web Service URL สำเร็จ 
## **ฐานข้อมูล**
เราต้องสร้างฐานข้อมูล Catalog ของ Reporting Services ซึ่งสามารถวางบน SQL 2008 หรือ SQL 2008 R2 Engine ได้ ฐานข้อมูล SQL11 ก็ทำงานได้เช่นกันแต่ยังอยู่ในระยะ BETA การกระทำนี้จะสร้างฐานข้อมูลสองชุดโดยค่าเริ่มต้นคือ **ReportServer** และ **ReportServerTempDB**. 
ขั้นตอนสำคัญอีกประการคือให้เลือก SharePoint Integrated เป็นประเภทฐานข้อมูล เมื่อเลือกแล้วไม่สามารถเปลี่ยนได้ โปรดดูรูปที่ 5, 6 และ 7 เป็นตัวอย่างอ้างอิง. 

![todo:image_alt_text](setting-up-reporting-services_4.png)

**รูปที่ 5**: การสร้างฐานข้อมูล Report Server 

![todo:image_alt_text](setting-up-reporting-services_5.png)

**รูปที่ 6**: การตั้งค่าเซิร์ฟเวอร์ฐานข้อมูลและประเภทการตรวจสอบสิทธิ์ 

![todo:image_alt_text](setting-up-reporting-services_6.png)

**รูปที่ 7**: การตั้งค่าชื่อและโหมดของฐานข้อมูล 

สำหรับข้อมูลประจำตัว นี่คือวิธีที่ Report Server จะสื่อสารกับ SQL Server บัญชีใดที่คุณเลือกจะได้รับสิทธิ์บางอย่างในฐานข้อมูล Catalog รวมถึงฐานข้อมูลระบบบางส่วนผ่าน RSExecRole ฐานข้อมูล MSDB เป็นหนึ่งในฐานข้อมูลที่ใช้สำหรับ Subscription เนื่องจากเราต้องใช้ SQL Agent. 

![todo:image_alt_text](setting-up-reporting-services_7.png)

**รูปที่ 8**: การตั้งค่าข้อมูลประจำตัวฐานข้อมูล Report Server 

เมื่อทำเสร็จแล้วควรมีลักษณะตามรูปต่อไปนี้. 

![todo:image_alt_text](setting-up-reporting-services_8.png)


**รูปที่ 9**: ความคืบหน้าเพื่อเสร็จสิ้นการตั้งค่าฐานข้อมูล Report Server 
## **URL ของ Report Manager**
เราสามารถข้ามขั้นตอน URL ของ Report Manager ได้ เนื่องจากไม่ใช้ในโหมด SharePoint Integrated SharePoint ทำหน้าที่เป็นส่วนหน้า ส่วน Report Manager จะไม่ทำงาน. 
## **คีย์การเข้ารหัส**
สำรองคีย์การเข้ารหัสของคุณและตรวจสอบว่าทราบตำแหน่งที่เก็บ หากคุณต้องย้ายหรือกู้คืนฐานข้อมูล คุณจะต้องใช้คีย์เหล่านี้. 

![todo:image_alt_text](setting-up-reporting-services_9.png)

นี่คือทั้งหมดสำหรับ Reporting Services Configuration Manager หากคุณเปิด URL บนแท็บ Web Service URL คุณควรเห็นอะไรที่คล้ายกับรูปต่อไปนี้. 

![todo:image_alt_text](setting-up-reporting-services_10.png)

**รูปที่ 12**: การเข้าถึง Report Server หลังการติดตั้ง 

อะไรเกิดขึ้น? SharePoint ถูกติดตั้งบน WFE ของฉันและฉันได้ตั้งค่า Reporting Services เสร็จแล้ว ในตัวอย่างนี้ Reporting Services และ SharePoint อยู่บนเครื่องต่างกัน หากอยู่บนเครื่องเดียวกันคุณจะไม่เห็นข้อผิดพลาดนี้ เราจำเป็นต้องติดตั้ง SharePoint บนเครื่อง RS ซึ่งหมายความว่า IIS จะถูกเปิดใช้งานเช่นกัน.