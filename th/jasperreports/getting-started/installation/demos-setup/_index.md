---
title: การตั้งค่าตัวอย่าง
type: docs
weight: 70
url: /th/jasperreports/demos-setup/
---
ตัวอย่างทั้งหมดที่ให้มาพร้อมกับ Aspose.Slides for JasperReports เป็นตัวอย่างมาตรฐานที่ได้รับการเปลี่ยนแปลง ควรคัดลอกตัวอย่างทั้งหมดไปยังโฟลเดอร์ตัวอย่างของ JasperReports:
...\jasperreports-x.x.x\demo\samples\

ใช้ลำดับคำสั่งมาตรฐานเพื่อสร้างและส่งออกรายงาน:

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="info" %}} 
กรุณาอย่าลืมรัน HSQLDB พร้อมฐานข้อมูลทดสอบเพื่อเติมข้อมูลให้กับรายงานและคัดลอกไฟล์ aspose.slides.jasperreports.library-xx.x.jar จาก \lib\JasperReports X.X.X - X.X.X ของไฟล์ aspose-slides-xx.x-jasperreports.zip ไปยังไดเรกทอรี &#60;InstallDir&#62;\lib
{{% /alert %}} 

ตัวอย่างส่วนใหญ่ (ยกเว้น Charts) มีการสร้างพรีเซนเทชันไว้แล้ว ดังนั้นคุณสามารถข้ามขั้นตอน “ant” ทั้งหมดและตรวจสอบผลลัพธ์ได้ทันที