---
title: ข้อกำหนดการติดตั้ง
type: docs
weight: 20
url: /th/reportingservices/installation-prerequisites/
---
{{% alert color="primary" %}} 
ต้องมีการทำตามข้อกำหนดเบื้องต้นก่อนที่เราจะดำเนินการติดตั้ง 
{{% /alert %}} 
## **Reporting Services Add-In for SharePoint**
The **Reporting Services Add-In for SharePoint** เป็นหนึ่งในส่วนประกอบสำคัญที่ทำให้การทำงานของ Integration ทำงานได้อย่างถูกต้อง แอดอินต้องติดตั้งบน **Web Front Ends (WFE)** ใด ๆ ที่อยู่ในฟาร์ม SharePoint ของคุณพร้อมกับเซิร์ฟเวอร์ Central Admin การเปลี่ยนแปลงใหม่กับ SQL 2008 R2 & SharePoint 2010 คือแอดอิน 2008 R2 ตอนนี้เป็นข้อกำหนดก่อนการติดตั้ง SharePoint หมายความว่าแอดอิน RS จะถูกติดตั้งอัตโนมัติเมื่อคุณทำการติดตั้ง SharePoint ซึ่งได้แสดงและไฮไลท์ในรูปด้านล่าง นี้ช่วยหลีกเลี่ยงปัญหาหลายอย่างที่เราเคยเจอกับ SP 2007 และ RS 2008 เมื่อติดตั้งแอดอิน 

![todo:image_alt_text](installation-prerequisites_1.png)


**Figure 1**: Reporting Services Add-In for SharePoint 
## **SharePoint Authentication**
ก่อนจะดำเนินการต่อในส่วนของการเชื่อมรวม RS สิ่งหนึ่งที่สำคัญและควรใส่ใจคือวิธีการตั้งค่า **Site** ของคุณในฟาร์ม SharePoint โดยเฉพาะอย่างยิ่งวิธีการกำหนดค่า authentication สำหรับ Site ว่าจะเป็น **Classic** หรือ **Claims** ตัวเลือกนี้สำคัญตั้งแต่แรก เราไม่เชื่อว่าเปลี่ยนตัวเลือกนี้ได้หลังจากตั้งค่าแล้ว หากสามารถเปลี่ยนได้ก็จะไม่เป็นกระบวนการง่าย 

{{% alert color="primary" %}} 
Reporting Services 2008 R2 ไม่รองรับ Claims 
{{% /alert %}} 

แม้ว่าคุณจะเลือกให้ไซต์ SharePoint ใช้ **Claims** แต่ Reporting Services เองไม่รองรับ Claims สิ่งนี้ส่งผลต่อวิธีการทำงานของ authentication กับ Reporting Services ดังนั้นความแตกต่างจากมุมมองของ Reporting Services คือการตัดสินใจว่าจะส่งต่อข้อมูลประจำตัวผู้ใช้ไปยัง datasource หรือไม่ 

***Classic*** - สามารถใช้ Kerberos และส่งต่อข้อมูลประจำตัวผู้ใช้ไปยัง datasource ของคุณ (ต้องใช้ Kerberos สำหรับนั้น). 

***Claims*** - ใช้โทเคน Claims แทนโทเคน Windows RS จะใช้ Trusted Authentication เสมอในสถานการณ์นี้และจะเข้าถึงได้เฉพาะโทเคน SPUser เท่านั้น คุณต้องเก็บข้อมูลประจำตัวของคุณไว้ใน datasource. 

ในขณะนี้ เราต้องการเน้นการตั้งค่า RS เท่านั้น ณ จุดนี้ SharePoint ได้รับการติดตั้งบนเครื่อง SharePoint Box และตั้งค่าเป็น **Classic Auth Site** ที่ **port 80** นอกจากนี้บนเซิร์ฟเวอร์ RS ผมได้ **just installed Reporting Services** แล้วจบ.