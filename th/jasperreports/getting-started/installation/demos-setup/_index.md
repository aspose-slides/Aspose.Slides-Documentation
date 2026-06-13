---
title: การตั้งค่าตัวอย่าง
type: docs
weight: 70
url: /th/jasperreports/demos-setup/
---
ตัวอย่างทั้งหมดที่ให้มาใน Aspose.Slides for JasperReports เป็นตัวอย่างมาตรฐานที่ได้ทำการปรับเปลี่ยนแล้ว ควรคัดลอกตัวอย่างทั้งหมดไปยังโฟลเดอร์ demo ของ JasperReports:
...\jasperreports-x.x.x\demo\samples\

ใช้ลำดับคำสั่งมาตรฐานเพื่อสร้างและส่งออกรายงาน:

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="primary" %}} 
กรุณาอย่าลืมเรียกใช้ HSQLDB พร้อมฐานข้อมูลทดสอบเพื่อเติมข้อมูลลงในรายงานและคัดลอกไฟล์ aspose.slides.jasperreports.library-xx.x.jar จากโฟลเดอร์ \lib\JasperReports X.X.X - X.X.X ของไฟล์ aspose-slides-xx.x-jasperreports.zip ไปยังไดเรกทรี &#60;InstallDir&#62;\lib directory.
{{% /alert %}} 

ตัวอย่างส่วนใหญ่ (ยกเว้น Charts) มีการสร้างพรีเซนเทชันไว้แล้ว ดังนั้นคุณจึงสามารถข้ามขั้นตอน “ant” ทั้งหมดและตรวจสอบผลลัพธ์ได้ทันที.