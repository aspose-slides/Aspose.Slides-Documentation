---
title: การติดตั้ง Aspose.Slides สำหรับ JasperReports
type: docs
weight: 40
url: /th/jasperreports/installing-aspose-slides-for-jasperreports/
description: "เลือกไฟล์ JAR ของ Aspose.Slides สำหรับ JasperReports ที่ตรงกับเวอร์ชันของ JasperReports ของคุณ และเพิ่มลงใน JasperReports, โปรเจกต์ Maven หรือ JasperReports Server."
---
## **เลือกไฟล์ JAR สำหรับเวอร์ชัน JasperReports ของคุณ**

Aspose.Slides สำหรับ JasperReports จัดจำหน่ายเป็นไฟล์ ZIP บน [download page](https://releases.aspose.com/slides/jasperreport/). โฟลเดอร์ *lib* มีโฟลเดอร์ย่อยหนึ่งโฟลเดอร์ต่อช่วงเวอร์ชันของ JasperReports ให้เลือกไฟล์ JAR จากโฟลเดอร์ย่อยที่ครอบคลุมเวอร์ชัน JasperReports ที่คุณใช้งาน:

| เวอร์ชัน JasperReports | โฟลเดอร์ย่อยของ *lib* |
| :- | :- |
| 3.7.2 to 5.5.1 | *JasperReports 3.7.2 - 5.5.1 (JDK 1.6)* |
| 5.5.2 to 6.4.0 | *JasperReports 5.5.2 - 6.4.0 (JDK 1.6)* |
| 6.5.0 to 6.16.0 | *JasperReports 6.5.0 - 6.16.0 (JDK 1.6)* |

ไม่มีโฟลเดอร์ย่อยสำหรับ JasperReports 6.17.0 หรือรุ่นถัดไป รวมถึง JasperReports 7 โฟลเดอร์ย่อย *JasperReports 2.0.3 - 3.7.1 (JDK 1.4)* ไม่มีไฟล์ JAR เพียงบันทึกว่าการสนับสนุนสำหรับรุ่นเหล่านั้นได้สิ้นสุดใน Aspose.Slides สำหรับ JasperReports 17.6.

แต่ละโฟลเดอร์ย่อยมีไฟล์ JAR สองไฟล์; *xx.x* ในชื่อของไฟล์เป็นเวอร์ชันของผลิตภัณฑ์:

- *aspose.slides.jasperreports.library-xx.x.jar* มีตัวส่งออกสำหรับ JasperReports Library (`ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` และ `ASHtmlExporter`) และคลาส `License` .
- *aspose.slides.jasperreports.server-xx.x.jar* มีการกระทำการส่งออกสำหรับ JasperReports Server มันอิงจากไฟล์ library ดังนั้นเซิร์ฟเวอร์จะต้องใช้ไฟล์ JAR ทั้งสองจากโฟลเดอร์ย่อยเดียวกันเสมอ.

## **เพิ่มไฟล์ JAR ของไลบรารีไปยัง JasperReports หรือแอปพลิเคชันของคุณ**

คัดลอก *aspose.slides.jasperreports.library-xx.x.jar* จากโฟลเดอร์ย่อยที่ตรงกันไปยังโฟลเดอร์ *lib* ของ JasperReports หรือไปยัง classpath ของแอปพลิเคชันของคุณ แอปพลิเคชันของคุณจะสามารถสร้างตัวส่งออกได้ในโค้ด

{{% alert color="info" title="Note" %}}
บน Linux, JasperReports จำเป็นต้องมี fontconfig และอย่างน้อยหนึ่งฟอนท์ที่ติดตั้งเพื่อทำการเติมรายงาน หากไม่มีฟอนท์ การเติมรายงานจะล้มเหลวพร้อมข้อผิดพลาด "Error initializing graphic environment".
{{% /alert %}}

## **เพิ่มไฟล์ JAR ของไลบรารีไปยังโปรเจกต์ Maven**

ไฟล์ JAR มาพร้อมกับไฟล์ ZIP แทนที่จะมาจากที่เก็บ Maven เพื่อใช้ในการสร้างด้วย Maven ให้ติดตั้งไฟล์ลงในที่เก็บ Maven ภายในเครื่องของคุณ สำหรับเวอร์ชัน 26.6 ให้เรียกใช้คำสั่งนี้ในโฟลเดอร์ที่มีไฟล์ JAR:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

จากนั้นเพิ่มมันลงในส่วน dependencies ของ *pom.xml* พร้อมกับเวอร์ชัน JasperReports ที่โฟลเดอร์ย่อยของไฟล์ JAR รองรับ:

```xml
<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides-jasperreports</artifactId>
    <version>26.6</version>
</dependency>
```

ค่า group และ artifact ID เป็นค่าที่คุณเลือกในคำสั่งติดตั้ง; เพียงต้องตรงกัน โปรเจกต์เต็มที่ใช้ JasperReports 6.16.0 มีอยู่ใน [Your first export](/slides/th/jasperreports/#your-first-export).

## **เพิ่มไฟล์ JAR ไปยัง JasperReports Server**

คัดลอกไฟล์ JAR ทั้งสองจากโฟลเดอร์ย่อยที่ตรงกันไปยังโฟลเดอร์ *WEB-INF/lib* ของเว็บแอปพลิเคชัน JasperReports Server จากนั้นลงทะเบียนตัวส่งออกตามที่อธิบายใน [Integration with JasperServer](/slides/th/jasperreports/integration-with-jasperserver/).