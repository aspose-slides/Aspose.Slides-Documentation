---
title: การติดตั้ง
type: docs
weight: 70
url: /th/php-java/installation/
keywords:
- ติดตั้ง Aspose.Slides
- ดาวน์โหลด Aspose.Slides
- ใช้ Aspose.Slides
- การติดตั้ง Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ติดตั้ง Aspose.Slides for PHP via Java อย่างรวดเร็ว คู่มือแบบขั้นตอน ระบบที่ต้องการ และตัวอย่างโค้ด — เริ่มทำงานกับงานนำเสนอ PowerPoint วันนี้!"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการติดตั้งและกำหนดค่า Aspose.Slides for PHP via Java โดยจะครอบคลุมการตั้งค่าสภาพแวดล้อมที่จำเป็น การดาวน์โหลดไลบรารีผ่าน Packagist การกำหนดค่า Apache Tomcat พร้อม PHP/Java Bridge และการรันตัวอย่างเพื่อยืนยันการติดตั้ง

## **กำหนดค่าสภาพแวดล้อม**

1. ติดตั้ง PHP 7, เพิ่มเส้นทางของ PHP ไปยังตัวแปรระบบ `PATH` และตั้งค่า `allow_url_include` เป็น `On` ในไฟล์ `php.ini`
1. ติดตั้ง JRE 8. ตั้งค่าตัวแปรสภาพแวดล้อม `JAVA_HOME` ให้ชี้ไปยังตำแหน่งที่ติดตั้ง JRE
1. ติดตั้ง Apache Tomcat 8.0

## **ดาวน์โหลด Aspose.Slides for PHP via Java** 

`packagist` เป็นวิธีที่ง่ายที่สุดในการดาวน์โหลด [Aspose.Slides for PHP via Java](https://packagist.org/packages/aspose/slides). 

เพื่อทำการติดตั้ง Aspose.Slides ด้วย Packagist ให้เรียกใช้คำสั่งนี้: 
   ```bash
   composer require aspose/slides
   ```

## **กำหนดค่า Apache Tomcat**

1. ดาวน์โหลด PHP/Java Bridge (`php-java-bridge_x.x.x_documentation.zip`) จาก http://php-java-bridge.sourceforge.net/pjb/download.php และแตกไฟล์ `JavaBridge.war` ไปยังโฟลเดอร์ `webapps` ของ Tomcat
1. เริ่มต้นบริการ Apache Tomcat
1. ดาวน์โหลด [“Aspose.Slides for PHP via Java”](https://downloads.aspose.com/slides/th/php-java) และแตกไฟล์ไปยังโฟลเดอร์ `aspose.slides` คัดลอกไฟล์ `jar/aspose-slides-x.x-php.jar` ไปยังโฟลเดอร์ `webapps\JavaBridge\WEB-INF\lib` หากคุณใช้ **PHP 8** ให้แทนที่ `Java.inc` ดั้งเดิมจาก PHP-Java Bridge ด้วย `Java.inc` จากไฟล์ `Java.inc.php8.zip`
1. รีสตาร์ทบริการ Apache Tomcat
1. เรียกใช้ `example.php` ในโฟลเดอร์ `aspose.slides` เพื่อรันตัวอย่างโดยใช้คำสั่งนี้:
   ```bash
   php example.php
   ```

## **คำถามที่พบบ่อย**

**วิธีตรวจสอบว่า Aspose.Slides ถูกผสานรวมอย่างถูกต้อง**

สร้างโปรเจกต์ของคุณ, สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ที่ว่างเปล่าและบันทึกเป็นชื่อใหม่ หากไฟล์ถูกสร้างขึ้นโดยไม่มีข้อยกเว้น แสดงว่าห้ัลไลบรารีได้ถูกรวมอย่างสำเร็จ

**วิธีจำกัดการใช้หน่วยความจำเมื่อประมวลผลงานนำเสนอขนาดใหญ่**

เพิ่มขีดจำกัดหน่วยความจำของ JVM เฉพาะตามที่จำเป็น และปิดแต่ละอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ในบล็อก `finally` เพื่อปล่อยแคชอย่างทันท่วงที สิ่งนี้จะป้องกันข้อผิดพลาด out‑of‑memory และทำให้การใช้งานหน่วยความจำโดยรวมคาดเดาได้ในระหว่างการประมวลผลแบบแบช

**สามารถตัดรูปแบบการส่งออกที่ไม่ต้องการเพื่อลดขนาด JAR สุดท้ายได้หรือไม่**

รุ่นปัจจุบันของ Aspose.Slides จะถูกแจกจ่ายเป็นไลบรารีแบบโมโนลิธจึงไม่สามารถปิดการทำงานของตัวส่งออกเฉพาะเช่น PDF หรือ SVG ในระหว่างการสร้างได้