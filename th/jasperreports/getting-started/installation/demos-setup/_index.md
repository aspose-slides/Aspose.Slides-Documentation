---
title: การตั้งค่าสาธิต
type: docs
weight: 70
url: /th/jasperreports/demos-setup/
description: "ตั้งค่าโครงการสาธิตจากการดาวน์โหลด Aspose.Slides for JasperReports, เปลี่ยนคลาสตัวส่งออกที่ใช้, และสร้างด้วย Ant."
---
## **สิ่งที่สาธิตคือ**

โฟลเดอร์ *samples* ของการดาวน์โหลด Aspose.Slides for JasperReports มีโครงการสาธิตทั้งหมดแปดโครงการ: *charts*, *fonts*, *images*, *landscape*, *shapes*, *subreport*, *text* และ *xmldatasource* พวกมันเป็นสาธิตมาตรฐานของ JasperReports ที่ถูกเปลี่ยนเพื่อเพิ่มเป้าหมายการสร้าง `ppt` ซึ่งส่งออกรายงานที่เติมข้อมูลเป็น PPT การดาวน์โหลดไม่มีไฟล์นำเสนอที่ส่งออกไว้; คุณต้องสร้างไฟล์เหล่านั้นโดยการคอมไพล์สาธิต

## **เปลี่ยนคลาสตัวส่งออกก่อนทำการสร้าง**

ตามที่จัดจำหน่าย โค้ด Java ของสาธิตใช้ `com.aspose.slides.jasperreports.JRPptExporter` ซึ่งเป็นคลาสที่ไฟล์ JAR ปัจจุบันไม่มี จึงทำให้สาธิตไม่คอมไพล์ ได้ในคลาสแอปพลิเคชันของสาธิต (เช่น *ShapesApp.java* ในสาธิต *shapes*) ให้เปลี่ยน `JRPptExporter` เป็น `ASPptExporter` ตัวส่งออก PPT ในแพ็กเกจเดียวกัน สาธิต *fonts* นำเข้าทั้งแพ็กเกจไว้ ดังนั้นจึงเปลี่ยนแค่ชื่อคลาสในโค้ดของมัน

สาธิตยังใช้คลาสของ JasperReports ที่ในเวอร์ชันหลังจากนี้ถูกลบออกไป เช่น `JExcelApiExporter` และ `JRExporterParameter.FONT_MAP` ด้วยการเปลี่ยนแปลงข้างต้น สาธิตจะคอมไพล์ได้ดังต่อไปนี้:

| เวอร์ชัน JasperReports | สาธิตที่คอมไพล์ได้ |
| :- | :- |
| 5.5.1 | ทั้งหมดแปด |
| 5.5.2 และ 6.4.0 | *charts*, *images*, *landscape*, *shapes* และ *xmldatasource* |
| 6.16.0 | *charts* |

## **สร้างสาธิต**

แต่ละสาธิตจะมีไฟล์ *build.xml* ที่คาดหวังโครงสร้างโฟลเดอร์ของโครงการ JasperReports: มันจะคอมไพล์โดยอ้างอิงกับ *../../../build/classes* และไฟล์ JAR ใน *../../../lib* โดยสัมพันธ์กับโฟลเดอร์สาธิต

1. คัดลอกโฟลเดอร์สาธิตไปยัง *demo/samples* ในโฟลเดอร์โครงการ JasperReports ของคุณ  
2. คัดลอกไฟล์ *aspose.slides.jasperreports.library-xx.x.jar* จากโฟลเดอร์ย่อย *lib* ของการดาวน์โหลดที่ตรงกับเวอร์ชัน JasperReports ของคุณไปยังโฟลเดอร์ *lib* ของโครงการ JasperReports ดูที่[Installing Aspose.Slides for JasperReports](/slides/th/jasperreports/installing-aspose-slides-for-jasperreports/)  
3. วางไฟล์ JAR ของเวอร์ชัน JasperReports ของคุณและไฟล์ JAR ที่มันพึ่งพาไว้ในโฟลเดอร์ *lib* เดียวกัน นอกจากไฟล์สาธิตแล้ว *build.xml* จะใส่เพียง *build/classes* และไฟล์ JAR ภายใต้ *lib* ลงใน classpath, และ *build/classes* จะมีคลาสตของ JasperReports เฉพาะหลังจากคุณคอมไพล์ JasperReports จากซอร์ส  
4. *charts*, *subreport* และ *text* สาธิตอ่านฐานข้อมูลตัวอย่าง HSQLDB ของ JasperReports (`jdbc:hsqldb:hsql://localhost`) ดังนั้นให้เริ่มเซิร์ฟเวอร์นั้นก่อน ตามที่อธิบายใน *samples/Readme.txt* ของการดาวน์โหลด สาธิตอื่น ๆ ไม่ต้องใช้ฐานข้อมูล  
5. ในโฟลเดอร์สาธิตให้คอมไพล์แอปพลิเคชัน, คอมไพล์การออกแบบรายงาน, เติมข้อมูล, แล้วส่งออกเป็น PPT:

```bash
ant javac
ant compile
ant fill
ant ppt
```

เป้าหมาย `ppt` จะเขียนไฟล์นำเสนอไว้ข้างๆ รายงานที่เติมข้อมูลแล้ว โดยตั้งชื่อเหมือนกับชื่อรายงาน (เช่น *LandscapeReport.ppt*)

สองสาธิตต้องทำขั้นตอนเพิ่มเติมเหนือขั้นตอนข้างต้น:

- สาธิต *images* โหลดรูปภาพหนึ่งภาพจาก `http://jasperreports.sourceforge.net/jasperreports.png` เมื่อทำการส่งออก ที่อยู่นี้ตอนนี้เปลี่ยนเป็นการเปลี่ยนเส้นทางไปยัง HTTPS ดังนั้นขั้นตอน `ppt` จะไม่เขียนไฟล์นำเสนอจนกว่าคุณจะเปลี่ยนที่อยู่เป็น `https://` ในไฟล์ *ImagesReport.jrxml* หากใช้ JasperReports 6.4.0 การส่งออกรูปภาพนั้นล้มเหลวแม้จะผ่าน HTTPS  

- รายงาน *xmldatasource* ใช้ฟอนต์ Arial หากระบบไม่มีฟอนต์ Arial `ant fill` จะพิมพ์ว่า ฟอนต์ "ไม่ได้ให้บริการกับ JVM" และจะไม่เขียนรายงานที่เติมข้อมูลไว้ ดังนั้น `ant ppt` จะไม่มีอะไรให้ส่งออก การสร้างยังคงรายงานว่าประสบความสำเร็จ ดังนั้นตรวจสอบผลลัพธ์ของแต่ละขั้นตอน