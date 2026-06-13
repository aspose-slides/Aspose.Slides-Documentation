---
title: บทนำและการตั้งค่าสภาพแวดล้อม
type: docs
weight: 10
url: /th/reportingservices/introduction-and-environment-setup/
---
{{% alert color="primary" %}} 

มีคำถามเข้ามาในอดีตเกี่ยวกับการผสาน Aspose.Slides สำหรับ Reporting Services กับ SharePoint ในบทความนี้ เราจะมุ่งเน้นที่ SharePoint 2010 ถือว่าคุณได้ตั้งค่าสภาพแวดล้อม SharePoint Farm ไว้แล้ว ตัวอย่างที่เราจะทำตามในบทความนี้จะเป็น SharePoint Cloud แบบเต็มรูปแบบ แต่ขั้นตอนจะคล้ายกับ SharePoint Foundation Server ก่อนที่เราจะดำเนินการต่อ ให้เริ่มด้วยเอกสารสำคัญที่คุณสามารถอ้างอิงได้เมื่อทำสิ่งนี้: 

- [ภาพรวมของ Reporting Services และการผสานเทคโนโลยี SharePoint](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))
- [การกำหนดค่า Reporting Services สำหรับการผสานกับ SharePoint 2010](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}} 
#### **การตั้งค่าสภาพแวดล้อม**
การตั้งค่าที่เราจะมีประกอบด้วย **4 เซิร์ฟเวอร์**. ซึ่งรวมถึง **Domain Controller**, **SQL Server**, **SharePoint Server** และเซิร์ฟเวอร์สำหรับ **Reporting Services**. คุณอาจเลือกให้ SharePoint และ Reporting Services อยู่บนเครื่องเดียวกัน.