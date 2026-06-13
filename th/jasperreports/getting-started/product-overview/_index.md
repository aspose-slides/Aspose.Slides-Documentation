---
title: ภาพรวมผลิตภัณฑ์
type: docs
weight: 10
url: /th/jasperreports/product-overview/
---
![Aspose.Slides for JasperReports](product-overview_1.png)

## **ยินดีต้อนรับสู่ Aspose.Slides for JasperReports!**

Aspose.Slides for JasperReports เป็นไลบรารีที่ออกแบบและพัฒนาเป็นพิเศษสำหรับนักพัฒนาที่ต้องการส่งออกรายงานจาก JasperReports ไปยังรูปแบบ Microsoft PowerPoint Presentation (PPT) และ Microsoft PowerPoint Show (PPS) อย่างง่ายในแอปพลิเคชัน Java ของพวกเขา คุณสมบัติของรายงานทั้งหมดจะถูกแปลงด้วยความแม่นยำสูงสุดเป็นงานนำเสนอ Microsoft PowerPoint Aspose.Slides for JasperReports รองรับ JasperReports 5+

## **รายละเอียดผลิตภัณฑ์**
JasperReports และ JasperServer ไม่มีความสามารถในตัวสำหรับการส่งออกรายงานเป็นงานนำเสนอ Microsoft PowerPoint แต่ Aspose.Slides for JasperReports ให้คุณเข้าถึงรูปแบบการส่งออกเพิ่มเติมสองรูปแบบ:

- PPT – การนำเสนอ PowerPoint ผ่าน Aspose.Slides
- PPS – การแสดง PowerPoint ผ่าน Aspose.Slides
- PPTX – การนำเสนอ PowerPoint ผ่าน Aspose.Slides
- PPSX – การแสดง PowerPoint ผ่าน Aspose.Slides

Aspose.Slides for JasperReports ใช้ไลบรารี Java 100% แท้ของเรา คือ Aspose.Slides for Java และ Aspose.Metafiles for Java ซึ่งเป็นไลบรารีระดับโลกสำหรับการประมวลผลงานนำเสนอและเมตาไฟล์บนเซิร์ฟเวอร์

Aspose.Slides for JasperReports ทำให้สามารถส่งออกรายงานใด ๆ ในรูปแบบ PPT หรือ PPS ได้

### **ตัวอย่างผลลัพธ์**
คลาส ASPptExporter สืบทอดจากคลาส ASAbstractExporter ดังนั้นจึงสามารถใช้ได้เช่นเดียวกับตัวส่งออกมาตรฐานอื่น ๆ ตัวอย่างสั้น ๆ นี้แสดงโค้ดทั่วไปและภาพหน้าจอของรายงานที่ดูใน MS PowerPoint ตัวอย่างโดยละเอียดสามารถพบได้ในรายงานสาธิตที่จัดเตรียมไว้

``` java
File sourceFile = new File(fileName); 
JasperPrint jasperPrint = (JasperPrint)JRLoader.loadObject(sourceFile);
File destFile = new File(sourceFile.getParent(), jasperPrint.getName() + ".ppt");
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, destFile.toString());
exporter.exportReport();
```

**การนำเสนอที่สร้างจาก JasperReports xmldatasource demo** 

![Presentation generated with JasperReports](product-overview_2.png)