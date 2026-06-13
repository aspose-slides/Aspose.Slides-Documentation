---
title: บันทึกงานนำเสนอในโหมดอ่านอย่างเดียวบน Android
linktitle: งานนำเสนอแบบอ่านอย่างเดียว
type: docs
weight: 30
url: /th/androidjava/read-only-presentation/
keywords:
- อ่านอย่างเดียว
- ปกป้องงานนำเสนอ
- ป้องกันการแก้ไข
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "บันทึกไฟล์ PowerPoint (PPT, PPTX) ในโหมดอ่านอย่างเดียวด้วย Aspose.Slides สำหรับ Android ผ่าน Java ให้การแสดงตัวอย่างสไลด์ที่แม่นยำโดยไม่ทำการเปลี่ยนแปลงงานนำเสนอของคุณ"
---
## **แนะนำ**

ใน PowerPoint 2019, Microsoft ได้นำการตั้งค่า **Always Open Read-Only** มาเป็นหนึ่งในตัวเลือกที่ผู้ใช้สามารถใช้เพื่อปกป้องงานนำเสนอของพวกเขา คุณอาจต้องการใช้การตั้งค่าอ่านอย่างเดียวนี้เพื่อปกป้องงานนำเสนอเมื่อ

- คุณต้องการป้องกันการแก้ไขโดยไม่ได้ตั้งใจและรักษาเนื้อหาของงานนำเสนอให้ปลอดภัย  
- คุณต้องการแจ้งให้ผู้คนทราบว่าการนำเสนอที่คุณให้เป็นเวอร์ชันสุดท้าย  

หลังจากคุณเลือกรายการ **Always Open Read-Only** สำหรับงานนำเสนอ เมื่อผู้ใช้เปิดงานนำเสนอ พวกเขาจะเห็นคำแนะนำ **Read-Only** และอาจเห็นข้อความในรูปแบบต่อไปนี้: *To prevent accidental changes, the author has set this file to open as read-only.*

คำแนะนำ **Read-Only** เป็นการยับยั้งที่เรียบง่ายแต่มีประสิทธิภาพซึ่งทำให้ผู้ใช้ต้องทำขั้นตอนเพื่อลบก่อนที่จะสามารถแก้ไขงานนำเสนอได้ หากคุณไม่ต้องการให้ผู้ใช้ทำการเปลี่ยนแปลงใด ๆ กับงานนำเสนอและต้องการบอกพวกเขาอย่างสุภาพ คำแนะนำ **Read-Only** อาจเป็นตัวเลือกที่ดีสำหรับคุณ  

> หากงานนำเสนอที่มีการป้องกัน **Read-Only** ถูกเปิดในแอปพลิเคชัน Microsoft PowerPoint รุ่นก่อน—ที่ไม่รองรับฟังก์ชันใหม่นี้— คำแนะนำ **Read-Only** จะถูกละเลย (งานนำเสนอจะเปิดตามปกติ)

## **ใช้โหมด Read-Only**

Aspose.Slides for Android via Java อนุญาตให้คุณตั้งค่างานนำเสนอเป็น **Read-Only**, ซึ่งหมายความว่าผู้ใช้ (หลังจากเปิดงานนำเสนอ) จะเห็นคำแนะนำ **Read-Only** ตัวอย่างโค้ดนี้แสดงวิธีตั้งค่างานนำเสนอเป็น **Read-Only** ใน Java โดยใช้ Aspose.Slides:

```java
Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

**หมายเหตุ**: คำแนะนำ **Read-Only** มีจุดประสงค์เพื่อยับยั้งการแก้ไขหรือหยุดผู้ใช้จากการทำการเปลี่ยนแปลงโดยไม่ได้ตั้งใจใน PowerPoint หากบุคคลที่มีความรู้และตั้งใจแก้ไขงานนำเสนอของคุณ พวกเขาก็สามารถลบการตั้งค่า Read-Only ได้อย่างง่ายดาย หากคุณต้องการป้องกันการแก้ไขโดยไม่ได้รับอนุญาตอย่างจริงจัง คุณควรใช้ [การป้องกันที่เข้มงวดกว่าโดยใช้การเข้ารหัสและรหัสผ่าน](https://docs.aspose.com/slides/th/androidjava/password-protected-presentation/) 

{{% /alert %}} 

## **ถาม‑ตอบ**

**การแนะนำ 'Read-Only' แตกต่างจากการป้องกันด้วยรหัสผ่านเต็มอย่างไร?**  

'Read-Only recommended' จะแสดงเพียงข้อเสนอแนะให้เปิดไฟล์ในโหมดอ่านอย่างเดียวและสามารถข้ามได้ง่าย [Password protection](/slides/th/androidjava/password-protected-presentation/) จะจำกัดการเปิดหรือแก้ไขและเหมาะเมื่อคุณต้องการการควบคุมความปลอดภัยที่แท้จริง  

**สามารถผสาน 'Read-Only recommended' กับ watermark เพื่อยับยั้งการแก้ไขเพิ่มเติมได้หรือไม่?**  

ได้. คำแนะนำสามารถจับคู่กับ [watermarks](/slides/th/androidjava/watermark/) เป็นการยับยั้งทางสายตา; พวกมันเป็นกลไกแยกต่างหากและทำงานร่วมกันได้ดี  

**แมโครหรือเครื่องมือภายนอกยังสามารถแก้ไขไฟล์ได้เมื่อเปิดใช้งานคำแนะนำนี้หรือไม่?**  

ได้. คำแนะนำไม่บล็อกการเปลี่ยนแปลงโดยโปรแกรม หากต้องการป้องกันการแก้ไขอัตโนมัติ ให้ใช้ [passwords and encryption](/slides/th/androidjava/password-protected-presentation/)  

**'Read-Only recommended' มีความสัมพันธ์อย่างไรกับเมธอด 'isEncrypted' และ 'isWriteProtected'?**  

พวกมันเป็นสัญญาณที่แตกต่างกัน 'Read-Only recommended' เป็นการแจ้งเตือนแบบอ่อนและเป็นตัวเลือก; [isWriteProtected](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) และ [isEncrypted](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) แสดงการจำกัดการเขียนหรือการอ่านจริงที่ขึ้นกับรหัสผ่านหรือการเข้ารหัส.