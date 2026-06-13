---
title: การตั้งค่า SharePoint บนเซิร์ฟเวอร์ RS
type: docs
weight: 40
url: /th/reportingservices/setting-up-sharepoint-on-the-rs-server/
---
{{% alert color="primary" %}} 

ดังนั้น เราจำเป็นต้องทำเช่นเดียวกับที่ทำกับ SharePoint WFE ขั้นตอนแรกคือดำเนินการติดตั้งข้อกำหนดเบื้องต้นและจากนั้นเริ่มการตั้งค่า SharePoint

สำหรับการตั้งค่า เราเลือก Server Farm และทำการติดตั้งแบบเต็มเพื่อตรงกับ SharePoint Box ของฉัน เนื่องจากเราไม่ต้องการการติดตั้งแบบอิสระสำหรับ SharePoint 

{{% /alert %}} 
### **การกำหนดค่า SharePoint**
ในตัวช่วยสร้างการกำหนดค่า SharePoint เราต้องการเชื่อมต่อกับฟาร์มที่มีอยู่แล้ว

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_1.png)

**รูปที่ 13**: ตัวช่วยสร้างการกำหนดค่า SharePoint 

จากนั้นเราจะระบุให้เชื่อมต่อกับฐานข้อมูล **SharePoint_Config** ที่ฟาร์มของเราใช้ หากคุณไม่ทราบตำแหน่งของมัน คุณสามารถค้นหาได้ผ่าน Central Admin ที่ **System Settings -> Manager Servers in this farm.** 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_2.png)

**รูปที่ 14**: ตัวช่วยสร้างการกำหนดค่า SharePoint 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_3.png)

**รูปที่ 15**: ตัวช่วยสร้างการกำหนดค่า SharePoint 

เมื่อวิเศษกฎเสร็จสิ้น นั่นคือทั้งหมดที่เราต้องทำบน Report Server Box ในขณะนี้ เมื่อกลับไปที่ URL ของ ReportServer เราจะพบข้อผิดพลาดอีกหนึ่งรายการ เนื่องจากเรายังไม่ได้กำหนดค่าผ่าน Central Administrator 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_4.png)

**รูปที่ 16**: ข้อผิดพลาดของ Report Server