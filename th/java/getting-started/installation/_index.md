---
title: การติดตั้ง
type: docs
weight: 70
url: /th/java/installation/
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
- การนำเสนอ
- Java
- Aspose.Slides
description: "ติดตั้ง Aspose.Slides for Java จาก Maven repository ของ Aspose หรือเป็นไฟล์ JAR ตั้งค่าเงื่อนไขเบื้องต้นสำหรับ Linux และตรวจสอบการติดตั้งด้วยโปรแกรมแรก"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีเพิ่ม Aspose.Slides for Java ไปยังโครงการ Aspose.Slides for Java ถูกเผยแพร่ในที่เก็บ Maven ของ Aspose เอง ไม่ใช่ใน Maven Central ดังนั้นโครงการ Maven จึงต้องประกาศที่เก็บนั้น คุณยังสามารถดาวน์โหลดไฟล์ JAR และใส่ลงใน class path ด้วยตนเอง ทั้งสองวิธีจะจบด้วยโปรแกรมสั้น ๆ ที่ยืนยันว่าห้องสมุดทำงานได้

Aspose.Slides for Java ไม่จำเป็นต้องมี Microsoft PowerPoint มันสร้างไฟล์พรีเซนเทชันที่จำเป็นโดยอัตโนมัติ อย่างไรก็ตาม หากต้องการดูพรีเซนเทชันที่สร้างขึ้น คุณอาจต้องใช้ Microsoft PowerPoint หรือโปรแกรมดูพรีเซนเทชันอื่น

## **ข้อกำหนดเบื้องต้น**

- ชุดพัฒนา Java (JDK) โครงการและคำสั่งในบทความนี้ต้องการ JDK 11 หรือใหม่กว่า บน JDK 11 โปรแกรมที่ตรวจสอบการติดตั้งจะแสดงคำเตือนที่ขึ้นต้นด้วย “WARNING: An illegal reflective access operation has occurred”; คำเตือนนี้ไม่กระทบผลลัพธ์และสามารถละเลยได้
- [Apache Maven](https://maven.apache.org/install.html) หากคุณใช้วิธี Maven
- บน Linux จำเป็นต้องมีไลบรารี fontconfig และฟอนต์อย่างน้อยหนึ่งตัว ดูที่ [Linux](#linux)

## **ติดตั้งจากที่เก็บ Maven**

Aspose โฮสต์ไลบรารี Java ของตนใน [Maven repository](https://releases.aspose.com/java/repo/com/aspose/) ของเอง เพื่อใช้ [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) ในโครงการ Maven ให้เพิ่มสองรายการลงใน *pom.xml* ของคุณ

1. **ประกาศที่เก็บ Maven ของ Aspose.**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **เพิ่มการอ้างอิง Aspose.Slides for Java.**

   ```xml
   <dependencies>
       <dependency>
           <groupId>com.aspose</groupId>
           <artifactId>aspose-slides</artifactId>
           <version>26.9</version>
           <classifier>jdk16</classifier>
       </dependency>
   </dependencies>
   ```

ตัวจัดประเภท `jdk16` จำเป็นต้องใช้: มันเลือกรุ่น Java SE ของไลบรารี แทนที่ `26.9` ด้วยเวอร์ชันล่าสุดที่แสดงใน [repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) ที่เก็บจะเผยไฟล์ตรวจสอบ SHA‑1 ควบคู่กับแต่ละ JAR ซึ่ง Maven จะตรวจสอบเมื่อดาวน์โหลดไลบรารี

### **ตรวจสอบการติดตั้ง**

เพื่อทดสอบการตั้งค่าโดยสร้างโครงการใหม่:

1. สร้างโฟลเดอร์สำหรับโครงการและบันทึก *pom.xml* นี้ลงในนั้น:

   ```xml
   <project xmlns="http://maven.apache.org/POM/4.0.0">
       <modelVersion>4.0.0</modelVersion>
       <groupId>com.example</groupId>
       <artifactId>hello-slides</artifactId>
       <version>1.0</version>

       <properties>
           <maven.compiler.release>11</maven.compiler.release>
           <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
           <exec.mainClass>HelloSlides</exec.mainClass>
       </properties>

       <repositories>
           <repository>
               <id>AsposeJavaAPI</id>
               <name>Aspose Java API</name>
               <url>https://releases.aspose.com/java/repo/</url>
           </repository>
       </repositories>

       <dependencies>
           <dependency>
               <groupId>com.aspose</groupId>
               <artifactId>aspose-slides</artifactId>
               <version>26.9</version>
               <classifier>jdk16</classifier>
           </dependency>
       </dependencies>

       <build>
           <plugins>
               <plugin>
                   <groupId>org.apache.maven.plugins</groupId>
                   <artifactId>maven-compiler-plugin</artifactId>
                   <version>3.15.0</version>
               </plugin>
           </plugins>
       </build>
   </project>
   ```

   นอกเหนือจากที่เก็บและการอ้างอิง *pom.xml* นี้กำหนดค่า Java release ที่จะคอมไพล์ ชื่อคลาสที่ `mvn exec:java` จะเรียกใช้ และตรึงปลั๊กอินคอมไพเลอร์ เนื่องจากปลั๊กอินเก่าบางตัวที่ Maven เริ่มต้นใช้จะละเลยการตั้งค่า `maven.compiler.release`

2. บันทึกตัวอย่างแรกจาก [Create Presentations](/slides/th/java/create-presentation/) เป็น *src/main/java/HelloSlides.java*.

3. ในโฟลเดอร์โครงการให้รัน:

   ```bash
   mvn compile exec:java
   ```

Maven จะดาวน์โหลด Aspose.Slides for Java คอมไพล์โปรแกรมและรัน โปรแกรมจะบันทึกไฟล์ *new_presentation.pptx* ไว้ในโฟลเดอร์โครงการ

## **ใช้ไฟล์ JAR โดยไม่ใช้ Maven**

1. ดาวน์โหลดไฟล์ *aspose-slides-26.9-jdk16.jar* จาก [โฟลเดอร์เวอร์ชัน](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.9/) ในที่เก็บ หากต้องการเวอร์ชันอื่น ให้เปิดโฟลเดอร์ของเวอร์ชันนั้นใน [repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) และดาวน์โหลดไฟล์ที่ลงท้ายด้วย *-jdk16.jar*  
2. บันทึกตัวอย่างแรกจาก [Create Presentations](/slides/th/java/create-presentation/) เป็น *HelloSlides.java* ในโฟลเดอร์เดียวกับไฟล์ JAR  
3. ในโฟลเดอร์นั้นให้รัน:

   ```bash
   java -cp aspose-slides-26.9-jdk16.jar HelloSlides.java
   ```

JDK จะคอมไพล์และรันไฟล์ซอร์สเดียวนี้ และโปรแกรมจะบันทึก *new_presentation.pptx* ไว้ในโฟลเดอร์นั้น ในแอปพลิเคชันของคุณเองให้เพิ่มไฟล์ JAR ไปยัง class path ของเครื่องมือสร้างหรือ IDE ที่ใช้

## **Linux**

Aspose.Slides for Java ใช้การสนับสนุนฟอนต์ของ Java ซึ่งบน Linux จำเป็นต้องมีไลบรารี fontconfig และฟอนต์อย่างน้อยหนึ่งตัว หากไม่มี ฟังก์ชันการบันทึกพรีเซนเทชันจะล้มเหลวด้วยข้อผิดพลาด “Fontconfig head is null, check your fonts or fonts configuration” ภาพลักษณ์เซิร์ฟเวอร์และคอนเทนเนอร์ขนาดเล็กอาจไม่มีทั้งสองอย่าง เช่น ภาพคอนเทนเนอร์ Ubuntu อย่างเป็นทางการไม่มีเลย

บน Debian และ Ubuntu คำสั่งต่อไปนี้จะติดตั้ง JDK, Maven, fontconfig และฟอนต์ DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

ฟอนต์ที่ใช้ในพรีเซนเทชันของคุณ หรือฟอนต์ทดแทนที่เหมาะสม ต้องติดตั้งด้วยเพื่อให้ข้อความแสดงผลถูกต้อง

## **คำถามที่พบบ่อย**

### วิธีตรวจสอบว่า Aspose.Slides ได้รวมอย่างถูกต้องหรือไม่?

สร้างโครงการของคุณ ประกอบออบเจ็กต์เปล่า [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) แล้วบันทึกด้วยชื่อใหม่ หากไฟล์สร้างสำเร็จโดยไม่เกิดข้อยกเว้น หมายความว่าห้องสมุดได้รวมอย่างถูกต้องแล้ว

### วิธีจำกัดการใช้หน่วยความจำเมื่อต้องประมวลผลการนำเสนอขนาดใหญ่?

ปรับขีดจำกัดหน่วยความจำของ JVM ให้สูงเท่าที่จำเป็นเท่านั้น และเรียกใช้เมธอด [dispose](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#dispose--) บนแต่ละอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) ภายในบล็อก `finally` เพื่อคืนค่าแคชโดยเร็ว วิธีนี้จะป้องกันข้อผิดพลาด out‑of‑memory และทำให้การใช้หน่วยความจำโดยรวมคาดการณ์ได้ระหว่างการดำเนินการแบบแบตช์

### ฉันสามารถยกเว้นรูปแบบการส่งออกที่ไม่ต้องการเพื่อลดขนาด JAR สุดท้ายได้หรือไม่?

รุ่นปัจจุบันของ Aspose.Slides จะจัดส่งเป็นไลบรารีเดี่ยวแบบโมโนลิธิก จึงไม่สามารถปิดการทำงานของผู้ส่งออกเฉพาะอย่าง PDF หรือ SVG ได้ในขั้นตอนการสร้าง​