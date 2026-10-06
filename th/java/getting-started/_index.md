---
title: เริ่มต้นใช้งาน
type: docs
weight: 10
url: /th/java/getting-started/
keywords:
- เริ่มต้นใช้งาน
- ความต้องการของระบบ
- การติดตั้ง
- พรีเซนเทชันแรก
- Maven
- การประมวลผล PPT
- การประมวลผล PPTX
- การประมวลผล ODP
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- Java
- Aspose.Slides
description: "เส้นทางจากโครงการ Java ใหม่ไปสู่พรีเซนเทชันแรกที่บันทึกด้วย Aspose.Slides: ตรวจสอบความต้องการ, เพิ่มไลบรารีจากรีพอซิทอรี Maven ของ Aspose, รันโปรแกรมแรก, และทำต่อด้วยงานทั่วไป."
---
## **ภาพรวม**

ทำตามสี่ขั้นตอนด้านล่างตามลำดับ ขั้นตอนแต่ละขั้นจะระบุสิ่งที่ต้องทำและเชื่อมโยงบทความที่มีรายละเอียด การประเมิน การออกใบอนุญาต และการสนับสนุนจะอธิบายหลังจากขั้นตอนเหล่านั้น

## **ขั้นตอนที่ 1: ตรวจสอบความต้องการของระบบ**

Aspose.Slides for Java เป็นไฟล์ JAR เดียวที่ไม่มีโค้ดเนทีฟ ดังนั้นจึงทำงานได้บนระบบปฏิบัติการใด ๆ ที่มี Java runtime ที่รองรับ [ข้อกำหนดของระบบ](/slides/th/java/system-requirements/) ระบุระบบปฏิบัติการและเวอร์ชัน Java ที่รองรับ โครงการและคำสั่งในขั้นตอนต่อไปต้องใช้ JDK 11 หรือใหม่กว่า และสำหรับเส้นทาง Maven ต้องใช้ [Apache Maven](https://maven.apache.org/install.html)

## **ขั้นตอนที่ 2: เพิ่มไลบรารีลงในโครงการของคุณ**

Aspose.Slides for Java ถูกเผยแพร่ในรีพอซิทอรี Maven ของ Aspose เอง ไม่ได้อยู่ใน Maven Central เลือกหนึ่งในเส้นทางต่อไปนี้:

- กับ Maven: ประกาศรีพอซิทอรี `https://releases.aspose.com/java/repo/` ใน *pom.xml* ของคุณและเพิ่ม dependency `com.aspose:aspose-slides` พร้อม classifier `jdk16`
- ไม่มี Maven: ดาวน์โหลดไฟล์ JAR ที่ลงท้ายด้วย *-jdk16.jar* จากรีพอซิทอรีและวางไว้ใน class path

บน Linux ให้ติดตั้งไลบรารี fontconfig และอย่างน้อยหนึ่งฟอนต์ หากไม่มีจะทำให้การบันทึกพรีเซนเทชันล้มเหลวพร้อมข้อความ error “Fontconfig head is null, check your fonts or fonts configuration”

[การติดตั้ง](/slides/th/java/installation/) ให้ข้อมูล entry ของ *pom.xml* การดาวน์โหลด JAR และคำสั่งสำหรับ Linux

## **ขั้นตอนที่ 3: สร้างพรีเซนเทชันแรกของคุณ**

[การเริ่มต้นอย่างรวดเร็วบนหน้าแรกของ Aspose.Slides for Java](/slides/th/java/#your-first-presentation) เป็นโครงการ Maven สมบูรณ์: ไฟล์ *pom.xml* และโปรแกรมที่เพิ่มรูปคลาวด์พร้อมข้อความลงในสไลด์และบันทึกพรีเซนเทชันเป็นไฟล์ PPTX คุณรันโดยใช้ `mvn compile exec:java` [สร้างพรีเซนเทชัน](/slides/th/java/create-presentation/) อธิบายโปรแกรมเดียวกันขั้นตอนต่อขั้นตอน เพื่ิอเปิดพรีเซนเทชันที่มีอยู่และบันทึกเป็นรูปแบบอื่น ดูที่ [เปิดพรีเซนเทชัน](/slides/th/java/open-presentation/) และ [บันทึกพรีเซนเทชัน](/slides/th/java/save-presentation/)

## **ขั้นตอนที่ 4: ทำต่อด้วยงานทั่วไป**

- [เปิดพรีเซนเทชัน](/slides/th/java/open-presentation/)
- [บันทึกพรีเซนเทชัน](/slides/th/java/save-presentation/)
- [แปลงพรีเซนเทชันเป็น PDF](/slides/th/java/convert-powerpoint-to-pdf/)
- [แปลงสไลด์เป็นภาพ](/slides/th/java/convert-slide/)
- [แก้ไขข้อความในพรีเซนเทชัน](/slides/th/java/manage-text/)
- [ตัวอย่างตามองค์ประกอบสไลด์](/slides/th/java/examples/)

## **ประเมินและขอใบอนุญาต**

หากไม่มีใบอนุญาต Aspose.Slides จะทำงานในโหมดประเมินผล: จะใส่ลายน้ำบนทุกสไลด์ที่บันทึกและตัดข้อความที่โค้ดของคุณอ่านจากพรีเซนเทชัน

- [ประเมิน Aspose.Slides](/slides/th/java/evaluate-aspose-slides/) อธิบายข้อจำกัดของการประเมินและวิธีขอรับใบอนุญาตชั่วคราว
- [การออกใบอนุญาต](/slides/th/java/licensing/) แสดงวิธีใช้ใบอนุญาตจากไฟล์หรือสตรีม
- [การออกใบอนุญาตแบบตามการใช้งาน](/slides/th/java/metered-licensing/) ครอบคลุมการออกใบอนุญาตที่คิดค่าบริการตามการใช้
- [รูปแบบไฟล์ที่รองรับ](/slides/th/java/supported-file-formats/) รายการรูปแบบที่ Aspose.Slides สามารถโหลดและบันทึกได้

## **ขอความช่วยเหลือ**

[การสนับสนุนทางเทคนิค](/slides/th/java/technical-support/) อธิบายวิธีตั้งคำถามใน [ฟอรั่มสนับสนุนฟรี](https://forum.aspose.com/c/slides/th/11) และสิ่งที่ควรใส่เมื่อรายงานปัญหา

## **คำถามที่พบบ่อย**

**ฉันต้องติดตั้ง Microsoft PowerPoint ไว้หรือไม่?**

ไม่จำเป็น Aspose.Slides อ่านและเขียนไฟล์พรีเซนเทชันด้วยตนเองและไม่ใช้ PowerPoint ดังนั้นจึงทำงานได้บนเซิร์ฟเวอร์และบน Linux ด้วย

**ทำไม Maven ไม่พบ Aspose.Slides for Java?**

ไลบรารีไม่อยู่ใน Maven Central ให้ประกาศรีพอซิทอรีของ Aspose ใน *pom.xml* ตามที่แสดงใน [การติดตั้ง](/slides/th/java/installation/) แล้ว Maven จะดาวน์โหลดไลบรารีจากที่นั่น

**Classifier `jdk16` หมายความว่าไลบรารีต้องใช้ Java 16 หรือไม่?**

ไม่ จำเป็นต้องใช้ Java 16 เพียงแค่เลือก build ของ Java SE; build อื่นเป็นสำหรับ Android build เดียวกันทำงานบน JDK ปัจจุบัน เช่น JDK 21