---
title: การประกาศ
type: docs
weight: 60
url: /th/java/artifact-classifier-change/
keywords:
- ตัวจัดประเภท Aspose.Slides
- ตัวจัดประเภท artifact
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
description: "Aspose.Slides สำหรับ Java ตอนนี้ใช้ตัวจัดประเภท jdk8 แทน jdk16. เรียนรู้เหตุผลและวิธีอัปเดตการอ้างอิงของคุณ."
---
## **การเปลี่ยนแปลง Classifier ของ Artifact จาก `jdk16` ไปเป็น `jdk8`**

เริ่มตั้งแต่เวอร์ชัน **26.10** เราได้เปลี่ยน classifier ที่ใช้ใน artifact ที่เผยแพร่ของเราจาก **`jdk16`** (Java 6) เป็น **`jdk8`** (Java 8).

### **สิ่งที่เปลี่ยนแปลง**

| | ก่อน | หลัง |
|---|---|---|
| Classifier | `jdk16` | `jdk8` |
| Minimum Java version | Java 1.6 | Java 8 |

**ก่อน:**  
```
com.aspose:aspose-slides:26.10:jdk16
```

**หลัง:**  
```
com.aspose:aspose-slides:26.10:jdk8
```

### **เหตุผลที่เราทำการเปลี่ยนแปลงนี้**

หลังจากการตรวจสอบภายใน เราตัดสินใจ **ยกเลิกการสนับสนุนเวอร์ชัน Java เก่า** ที่ไม่ให้คุณค่าและเป็นอุปสรรคต่อการบำรุงรักษาอย่างต่อเนื่อง Java 8 ถูกเลือกให้เป็นพื้นฐานที่ปลอดภัยใหม่สำหรับผู้ใช้ทั้งหมด

ในส่วนนี้ classifier ถูกอัปเดตเพื่อสะท้อนเวอร์ชันขั้นต่ำที่รองรับจริง เราได้สอดคล้องกับแนวปฏิบัติการตั้งชื่อของ Oracle ปัจจุบัน ที่ผลิตภัณฑ์เรียกอย่างเป็นทางการว่า **JDK 8** (แทนรูปแบบ `1.8` เก่าที่ใช้)

### **สิ่งที่คุณต้องทำ**

1. **อัปเดต classifier** ในการประกาศ dependency ของคุณจาก `jdk16` เป็น `jdk8`.

   **Maven:**  
   ```xml
   <dependency>
     <groupId>com.aspose</groupId>
     <artifactId>aspose-slides</artifactId>
     <version>26.10</version>
     <classifier>jdk8</classifier>
   </dependency>
   ```

   **Gradle:**  
   ```groovy
   implementation 'com.aspose:aspose-slides:26.10:jdk8'
   ```

2. **ตรวจสอบว่าสภาพแวดล้อมการทำงานของคุณเป็น Java 8 หรือสูงกว่า**.

3. **รีเฟรชไฟล์ล็อกหรือแคชของ dependencies** ที่ระบุ classifier เก่า.

### **หมายเหตุการย้าย: jdk16 และ jdk8**

เริ่มตั้งแต่เวอร์ชัน 26.10​ ทั้ง classifier jdk16 และ jdk8 จะให้ JAR ที่เข้ากันได้กับ Java 8 (สร้างด้วยการตั้งค่า source/target compatibility เป็น Java 8)

- `jdk16` → ยังคงเผยแพร่เพื่อความเข้ากันย้อนกลับ (การรวมระบบที่มีอยู่)
- `jdk8` → แนะนำเป็น classifier ที่แนะนำใหม่สำหรับสภาพแวดล้อม Java 8

⚠️ หมายเหตุ: ขั้นตอนการเผยแพร่ออกเป็นคู่นี้กำหนดว่าจะสิ้นสุดในวันที่ 31 มีนาคม 2027​. หลังจากวันดังกล่าว classifier jdk16 จะถูกยกเลิกและจะสนับสนุนเฉพาะ jdk8 เท่านั้น.

### **หมายเหตุความเข้ากันได้**

- classifier `jdk16` **จะไม่ถูกเผยแพร่อีกหลังจาก** **31 มีนาคม 2027**.
- หากคุณยังต้องการการสนับสนุน Java 1.6 โปรดคงอยู่ในสาขาเวอร์ชันหลักก่อนหน้าจนกว่าจะสามารถย้ายได้.

### **ต้องการความช่วยเหลือ?**

หากคุณพบปัญหาระหว่างการย้าย โปรดติดต่อ [Aspose support](https://forum.aspose.com/) เพื่อขอความช่วยเหลือเพิ่มเติม.