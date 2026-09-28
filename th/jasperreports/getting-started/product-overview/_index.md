---
title: ภาพรวมผลิตภัณฑ์
type: docs
weight: 10
url: /th/jasperreports/product-overview/
description: "เรียนรู้ว่า Aspose.Slides for JasperReports ทำอะไร, รองรับเวอร์ชันของ JasperReports และรูปแบบผลลัพธ์ใดบ้าง, และไฟล์ jar สองไฟล์ของมันมีไว้เพื่ออะไร."
---
![Aspose.Slides for JasperReports](product-overview_1.png)

## **คำอธิบายผลิตภัณฑ์**

Aspose.Slides for JasperReports ส่งออกรายงานจาก JasperReports ไปเป็นงานนำเสนอ PowerPoint ในแอปพลิเคชัน Java และใน JasperReports Server โดยไม่ต้องใช้ Microsoft PowerPoint รองรับ JasperReports ตั้งแต่เวอร์ชัน 3.7.2 ถึง 6.16.0 โดยมีไฟล์ jar แยกต่างหากสำหรับแต่ละช่วงเวอร์ชัน — ดู [Installing Aspose.Slides for JasperReports](/slides/th/jasperreports/installing-aspose-slides-for-jasperreports/).

มันส่งออกรายงานที่เติมเต็มเป็นสี่รูปแบบ หนึ่งสไลด์หรือหนึ่งหน้าต่อหน้ารายงาน:

- PPT – การนำเสนอ PowerPoint 97–2003
- PPTX – การนำเสนอ PowerPoint (Office Open XML)
- PDF
- HTML

ผลิตภัณฑ์นี้มีสองส่วน:

- ไฟล์ jar ของไลบรารีเพิ่มตัวส่งออก `ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` และ `ASHtmlExporter` ไปยัง JasperReports Library.
- ไฟล์ jar ของเซิร์ฟเวอร์ให้การกระทำการส่งออกสำหรับสี่รูปแบบเดียวกันซึ่งคุณลงทะเบียนใน JasperReports Server — ดู [Integration with JasperServer](/slides/th/jasperreports/integration-with-jasperserver/).

### **ตัวอย่างผลลัพธ์**

ตัวส่งออกขยายคลาสตัวส่งออกของ JasperReports เองและใช้วิธีเดียวกัน: ส่งรายงานที่เติมเต็มและไฟล์ผลลัพธ์ให้กับมัน แล้วเรียก `exportReport`. สำหรับโปรแกรมเต็มที่เติมรายงานและส่งออกเป็น PPTX ดูที่ [Your first export](/slides/th/jasperreports/#your-first-export); สำหรับสี่รูปแบบทั้งหมด ดูที่ [PPT, PPTX, PDF and HTML Export](/slides/th/jasperreports/ppt-pptx-pdf-and-html-export/).

![รายงานที่ส่งออกเป็นงานนำเสนอโดยไม่มีไลเซนส์ พร้อมลายน้ำการประเมินที่ศูนย์ของสไลด์](product-overview_2.png)