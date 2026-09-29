---
title: ความต้องการของ Security Manager
type: docs
weight: 190
url: /th/java/declaration/
keywords:
- ผู้จัดการความปลอดภัย
- นโยบายความปลอดภัย
- AllPermission
- สิทธิ์
- sandbox
- JDK 24
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "สิทธิ์ของ Security Manager ที่ Aspose.Slides for Java และโค้ดที่เรียกใช้ต้องการบน Java 23 และก่อนหน้า คืออะไร และทำไมจึงไม่มีสิ่งใดต้องกำหนดค่าใน Java 24 และหลังจากนั้น"
---
## **ภาพรวม**

Java Security Manager จำกัดสิ่งที่โค้ดสามารถทำได้ตามนโยบายความปลอดภัย Java 17 ยกเลิกการสนับสนุนเพื่อการลบในอนาคต ([JEP 411](https://openjdk.org/jeps/411)) และ Java 24 ปิดใช้งานอย่างถาวร ([JEP 486](https://openjdk.org/jeps/486)) บทความนี้อธิบายว่า Aspose.Slides for Java ต้องการอะไรเมื่อแอปพลิเคชันยังคงทำงานพร้อมกับ Security Manager หากแอปพลิเคชันของคุณไม่ได้เปิดใช้ Security Manager (ซึ่งเป็นค่าเริ่มต้น) จะไม่มีการกำหนดค่าใด ๆ ที่ต้องทำ

## **Java 23 และก่อนหน้า**

เมื่อ Security Manager ถูกเปิดใช้งาน นโยบายความปลอดภัยต้องให้สิทธิ์ต่อไปนี้กับไฟล์ JAR ของ Aspose.Slides และกับโค้ดแอปพลิเคชันที่เรียกใช้มัน:

- `java.util.PropertyPermission "*", "read"`: Aspose.Slides อ่านคุณสมบัติของระบบ
- `java.io.FilePermission "<<ALL FILES>>", "read"`: Aspose.Slides อ่านไฟล์ฟอนต์และไฟล์อื่น ๆ
- `java.io.FilePermission "<<ALL FILES>>", "execute"`: Aspose.Slides เริ่มโปรแกรมของระบบปฏิบัติการ เช่น `reg` บน Windows และ `fc-match` บน Linux
- `java.io.FilePermission` พร้อมการกระทำ `write` สำหรับโฟลเดอร์ที่แอปพลิเคชันของคุณบันทึกไฟล์

การให้สิทธิ์กับไฟล์ JAR เพียงอย่างเดียวไม่เพียงพอ: โค้ดที่เรียกใช้ Aspose.Slides ต้องการสิทธิ์เหล่านี้ด้วย การให้ `java.security.AllPermission` กับทั้งสองอย่างก็เป็นวิธีที่ใช้งานได้เช่นกัน

หากไม่มีสิทธิ์ให้อ่านคุณสมบัติของระบบหรือเริ่มโปรแกรม Aspose.Slides จะล้มเหลวในการใช้งานครั้งแรก: การสร้างอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) จะทำให้เกิด `ExceptionInInitializerError` หากไม่มีการเข้าถึงไฟล์ฟอนต์ การบันทึกงานนำเสนอเป็น PDF จะล้มเหลวพร้อมข้อความข้อผิดพลาด “Cannot find any fonts installed on the system”

## **Java 24 และหลังจากนั้น**

Security Manager ไม่สามารถเปิดใช้บน Java 24 และรุ่นต่อ ๆ ไป ดังนั้นจึงไม่มีสิทธิ์ใด ๆ ที่ต้องให้ Aspose.Slides ทำงานด้วยสิทธิ์ของบัญชีที่รันแอปพลิเคชันของคุณ เพื่อลดขอบเขตการเข้าถึงของแอปพลิเคชัน โครงการ OpenJDK แนะนำให้ใช้เทคโนโลยีภายนอก JDK เช่น คอนเทนเนอร์, ไฮเปอร์ไวเซอร์, และฟีเจอร์ sandbox ของระบบปฏิบัติการ ดูรายละเอียดที่ [JEP 486](https://openjdk.org/jeps/486)

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้ Aspose.Slides ในสภาพแวดล้อมที่รันแอปพลิเคชันภายใต้นโยบาย Security Manager ที่เข้มงวดได้หรือไม่?**

ทำได้เฉพาะเมื่อแนวทางนโยบายให้สิทธิ์ที่ระบุข้างต้นทั้งกับ Aspose.Slides และกับโค้ดที่เรียกใช้มัน ซึ่งรวมถึงการอ่านไฟล์ทั้งหมดและการเริ่มโปรแกรมใด ๆ