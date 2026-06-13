---
title: บทนำ &amp; การตั้งค่าสภาพแวดล้อม
type: docs
weight: 10
url: /th/reportingservices/introduction-&amp;-environment-setup/
---
{{% alert color="primary" %}} 

เคยมีการสอบถามในอดีตเกี่ยวกับ Aspose.Slides สำหรับการบูรณาการ Reporting Services กับ SharePoint ในบทความนี้ เราจะมุ่งเน้นที่ SharePoint 2010 โดยถือว่าผู้ใช้ได้ตั้งค่า SharePoint Farm ไว้แล้ว ตัวอย่างที่เราจะทำตามในบทความนี้จะเป็น SharePoint Cloud ฉบับเต็ม แต่ขั้นตอนจะคล้ายกับ SharePoint Foundation Server ก่อนที่เราจะดำเนินการต่อ ให้เริ่มด้วยเอกสารสำคัญที่คุณสามารถใช้เป็นอ้างอิงได้ดังนี้: 

- [ภาพรวมของ Reporting Services และการบูรณาการเทคโนโลยี SharePoint](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))
- [การกำหนดค่า Reporting Services สำหรับการบูรณาการกับ SharePoint 2010](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}} 
#### **การตั้งค่าสภาพแวดล้อม**
การตั้งค่าที่เราจะใช้ประกอบด้วย **4 เซิร์ฟเวอร์** ซึ่งรวมถึง **Domain Controller**, **SQL Server**, **SharePoint Server** และเซิร์ฟเวอร์สำหรับ **Reporting Services** คุณอาจเลือกให้ SharePoint และ Reporting Services อยู่บนเครื่องเดียวกันได้