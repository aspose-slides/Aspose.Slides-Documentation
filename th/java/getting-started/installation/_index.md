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
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ติดตั้ง Aspose.Slides สำหรับ Java จาก Maven repository ของ Aspose หรือเป็นไฟล์ JAR, ตั้งค่าเงื่อนไขเบื้องต้นของ Linux, และตรวจสอบการติดตั้งด้วยโปรแกรมแรก."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีเพิ่ม Aspose.Slides for Java ลงในโปรเจกต์ Aspose.Slides for Java เผยแพร่ใน Maven repository ของ Aspose เอง ไม่ได้อยู่ใน Maven Central ดังนั้นโปรเจกต์ Maven จำเป็นต้องระบุ repository นั้น คุณยังสามารถดาวน์โหลดไฟล์ JAR และใส่ลงใน class path เองได้ เส้นทางทั้งสองจะลงท้ายด้วยโปรแกรมสั้น ๆ ที่ยืนยันว่าห้องสมุดทำงานได้

Aspose.Slides for Java ไม่ต้องการ Microsoft PowerPoint มันสร้างไฟล์งานนำเสนอที่จำเป็นโดยอัตโนมัติ อย่างไรก็ตามเพื่อดูงานนำเสนอที่สร้างขึ้น คุณอาจต้องใช้ Microsoft PowerPoint หรือโปรแกรมดูงานนำเสนออื่น

## **ข้อกำหนดเบื้องต้น**

- ชุดพัฒนาซอฟต์แวร์ Java (JDK) โปรเจกต์และคำสั่งในบทความนี้ต้องการ JDK 11 หรือใหม่กว่า ใน JDK 11 โปรแกรมตรวจสอบการติดตั้งจะแสดงคำเตือนที่เริ่มด้วย "WARNING: An illegal reflective access operation has occurred"; คำเตือนนี้ไม่ส่งผลต่อผลลัพธ์และสามารถละเว้นได้
- [Apache Maven](https://maven.apache.org/install.html), หากคุณใช้เส้นทาง Maven.
- บน Linux ไลบรารี fontconfig และอย่างน้อยหนึ่งฟอนต์ที่ติดตั้งไว้ ดู [Linux](#linux).

## **ติดตั้งจาก Maven Repository**

Aspose โฮสต์ไลบรารี Java ของตนใน [Maven repository](https://releases.aspose.com/java/repo/com/aspose/) ของเอง เพื่อใช้ [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) ในโปรเจกต์ Maven ให้เพิ่มสองรายการใน *pom.xml* ของคุณ.

1. **ระบุ Maven repository ของ Aspose.**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **เพิ่ม dependency ของ Aspose.Slides for Java.**

   ```xml
   <dependencies>
       <dependency>
           <groupId>com.aspose</groupId>
           <artifactId>aspose-slides</artifactId>
           <version>26.10</version>
           <classifier>jdk8</classifier>
       </dependency>
   </dependencies>
   ```

จำเป็นต้องใช้ classifier `jdk8`: มันเลือกเวอร์ชัน Java SE ของไลบรารี เปลี่ยน `26.10` เป็นเวอร์ชันล่าสุดที่ระบุใน [คลัง](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) Repository จะเผยแพร่ไฟล์ตรวจสอบ SHA-1 เคียงคู่กับแต่ละ JAR ซึ่ง Maven จะตรวจสอบเมื่อดาวน์โหลดไลบรารี

### **ตรวจสอบการติดตั้ง**

เพื่อตรวจสอบการตั้งค่าด้วยโปรเจกต์ใหม่:

1. สร้างโฟลเดอร์สำหรับโปรเจกต์และบันทึก *pom.xml* นี้ลงในนั้น:

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
               <version>26.10</version>
               <classifier>jdk8</classifier>
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

   นอกจาก repository และ dependency แล้ว *pom.xml* นี้กำหนด Java release ที่จะคอมไพล์, ตั้งชื่อคลาสที่ `mvn exec:java` จะเรียกใช้, และระบุ compiler plugin เนื่องจาก plugin รุ่นเก่าที่บางการติดตั้ง Maven ใช้โดยค่าเริ่มต้นจะละเว้นการตั้งค่า `maven.compiler.release`

2. บันทึกตัวอย่างแรกใน [สร้างงานนำเสนอ](/slides/th/java/create-presentation/) เป็นไฟล์ *src/main/java/HelloSlides.java*.

3. ในโฟลเดอร์โปรเจกต์, รัน:

   ```bash
   mvn compile exec:java
   ```

Maven จะดาวน์โหลด Aspose.Slides for Java, คอมไพล์โปรแกรมและรันมัน โปรแกรมจะบันทึกไฟล์ *new_presentation.pptx* ในโฟลเดอร์โปรเจกต์

## **ใช้ไฟล์ JAR โดยไม่ต้องใช้ Maven**

1. ดาวน์โหลด *aspose-slides-26.10-jdk8.jar* จาก [โฟลเดอร์เวอร์ชัน](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.10/) ใน repository สำหรับเวอร์ชันอื่น ให้เปิดโฟลเดอร์ของเวอร์ชันนั้นใน [คลัง](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) แล้วดาวน์โหลดไฟล์ที่ลงท้ายด้วย *-jdk8.jar*.

2. บันทึกตัวอย่างแรกใน [สร้างงานนำเสนอ](/slides/th/java/create-presentation/) เป็นไฟล์ *HelloSlides.java* ในโฟลเดอร์เดียวกับไฟล์ JAR

3. ในโฟลเดอร์นั้น, รัน:

   ```bash
   java -cp aspose-slides-26.10-jdk8.jar HelloSlides.java
   ```

JDK จะคอมไพล์และรันไฟล์ซอร์สเดียวนี้ และโปรแกรมจะบันทึกไฟล์ *new_presentation.pptx* ในโฟลเดอร์นั้น ในแอปพลิเคชันของคุณเอง ให้เพิ่มไฟล์ JAR ไปยัง class path ในเครื่องมือ build หรือ IDE ของคุณ

## **Linux**

Aspose.Slides for Java ใช้การสนับสนุนฟอนต์ของ Java ซึ่งบน Linux จำเป็นต้องมีไลบรารี fontconfig และอย่างน้อยหนึ่งฟอนต์ที่ติดตั้งไว้ หากไม่มีจะทำให้การบันทึกงานนำเสนอล้มเหลวพร้อมข้อผิดพลาด "Fontconfig head is null, check your fonts or fonts configuration" เซิร์ฟเวอร์และอิมเมจคอนเทนเนอร์ขนาดเล็กอาจขาดทั้งสองอย่าง; ตัวอย่างเช่น อิมเมจคอนเทนเนอร์ Ubuntu อย่างเป็นทางการไม่มีเลย

บน Debian และ Ubuntu คำสั่งต่อไปนี้จะติดตั้ง JDK, Maven, fontconfig, และฟอนต์ DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

ฟอนต์ที่ใช้ในงานนำเสนอของคุณ หรือฟอนต์แทนที่ที่เหมาะสม จะต้องถูกติดตั้งด้วยเพื่อให้ข้อความแสดงอย่างถูกต้อง

## **คำถามที่พบบ่อย**

### ฉันจะตรวจสอบว่า Aspose.Slides ถูกผสานอย่างถูกต้องได้อย่างไร?

สร้างโปรเจกต์ของคุณ, สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ว่าง ๆ แล้วบันทึกด้วยชื่อใหม่ หากไฟล์ถูกสร้างโดยไม่มีข้อยกเว้นใด ๆ แสดงว่าไลบรารีได้ถูกผสานสำเร็จ

### ฉันจะจำกัดการใช้หน่วยความจำเมื่อประมวลผลงานนำเสนอขนาดใหญ่ได้อย่างไร?

เพิ่มขีดจำกัดหน่วยความจำของ JVM เฉพาะตามที่ต้องการเท่านั้น, และเรียกใช้ [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) บนแต่ละอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ในบล็อก `finally` เพื่อปล่อยแคชอย่างรวดเร็ว นี้จะป้องกันข้อผิดพลาด out‑of‑memory และทำให้การใช้หน่วยความจำโดยรวมคาดการณ์ได้ในระหว่างการทำงานแบบเป็นชุด

### ฉันสามารถลบรูปแบบการส่งออกที่ไม่ต้องการเพื่อลดขนาด JAR สุดท้ายได้หรือไม่?

เวอร์ชันปัจจุบันของ Aspose.Slides จะจัดจำหน่ายเป็นไลบรารีเดี่ยวที่เป็นมอนโอลลิธ จึงไม่สามารถปิดการทำงานของตัวส่งออกเฉพาะ เช่น PDF หรือ SVG ได้ในระหว่างการสร้าง