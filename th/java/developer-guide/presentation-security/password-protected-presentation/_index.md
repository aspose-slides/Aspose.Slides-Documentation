---
title: การปกป้องการนำเสนอด้วยรหัสผ่านใน Java
linktitle: การปกป้องด้วยรหัสผ่าน
type: docs
weight: 20
url: /th/java/password-protected-presentation/
keywords:
- ล็อก PowerPoint
- ล็อกการนำเสนอ
- ปลดล็อก PowerPoint
- ปลดล็อกการนำเสนอ
- ปกป้อง PowerPoint
- ปกป้องการนำเสนอ
- ตั้งรหัสผ่าน
- เพิ่มรหัสผ่าน
- เข้ารหัส PowerPoint
- เข้ารหัสการนำเสนอ
- ถอดรหัส PowerPoint
- ถอดรหัสการนำเสนอ
- การป้องกันการเขียน
- ความปลอดภัยของ PowerPoint
- ความปลอดภัยของการนำเสนอ
- ลบรหัสผ่าน
- ลบการปกป้อง
- ลบการเข้ารหัส
- ปิดการทำงานของรหัสผ่าน
- ปิดการทำงานของการปกป้อง
- ลบการป้องกันการเขียน
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการล็อกและปลดล็อกการนำเสนอ PowerPoint และ OpenDocument ที่ถูกปกป้องด้วยรหัสผ่านอย่างง่ายดายด้วย Aspose.Slides สำหรับ Java. ปกป้องการนำเสนอของคุณ."
---
## **บทนำ**

เมื่อคุณตั้งรหัสผ่านเพื่อปกป้องการนำเสนอ หมายความว่าคุณกำหนดรหัสผ่านที่บังคับใช้ข้อจำกัดบางอย่างบนการนำเสนอ เพื่อลบข้อจำกัดเหล่านี้ ต้องป้อนรหัสผ่าน การนำเสนอที่ปกป้องด้วยรหัสผ่านถือเป็นการนำเสนอที่ถูกล็อก

โดยทั่วไป คุณสามารถตั้งรหัสผ่านเพื่อบังคับใช้ข้อจำกัดเหล่านี้บนการนำเสนอ:

- **การแก้ไข**

หากคุณต้องการให้ผู้ใช้บางคนเท่านั้นที่สามารถแก้ไขการนำเสนอของคุณได้ คุณสามารถตั้งข้อจำกัดการแก้ไขได้ ข้อจำกัดนี้จะป้องกันไม่ให้ผู้คนแก้ไข, เปลี่ยนแปลง หรือคัดลอกส่วนประกอบในการนำเสนอของคุณ เว้นแต่พวกเขาจะให้รหัสผ่าน  

อย่างไรก็ตาม แม้ไม่มีรหัสผ่าน ผู้ใช้ยังคงสามารถเข้าถึงและเปิดเอกสารของคุณได้ ในโหมดอ่านอย่างเดียวนี้ ผู้ใช้สามารถดูเนื้อหา—รวมถึงลิงก์, แอนิเมชัน, เอฟเฟกต์ และส่วนประกอบอื่น ๆ—ภายในการนำเสนอของคุณได้ แต่ไม่สามารถคัดลอกรายการหรือบันทึกการนำเสนอได้  

- **การเปิด**

หากคุณต้องการให้ผู้ใช้บางคนเท่านั้นที่สามารถเปิดการนำเสนอของคุณได้ คุณสามารถตั้งข้อจำกัดการเปิดได้ ข้อจำกัดนี้จะป้องกันไม่ให้ผู้คนแม้แต่ดูเนื้อหาของการนำเสนอของคุณ เว้นแต่พวกเขาจะให้รหัสผ่าน  

โดยเทคนิค ข้อจำกัดการเปิดยังป้องกันผู้ใช้จากการแก้ไขการนำเสนอของคุณ—หากผู้คนไม่สามารถเปิดการนำเสนอได้ พวกเขาก็ไม่สามารถแก้ไขหรือทำการเปลี่ยนแปลงใด ๆ ได้  

**หมายเหตุ:** เมื่อคุณตั้งรหัสผ่านเพื่อป้องกันการเปิดการนำเสนอ ไฟล์การนำเสนอจะถูกเข้ารหัส  

## **การปกป้องด้วยรหัสผ่านใน Aspose.Slides**
### รูปแบบที่รองรับ

Aspose.Slides รองรับการปกป้องด้วยรหัสผ่าน, การเข้ารหัส, และการดำเนินการที่คล้ายกันสำหรับการนำเสนอในรูปแบบต่อไปนี้:

- PPTX และ PPT - การนำเสนอ Microsoft PowerPoint  
- ODP - การนำเสนอ OpenDocument  
- OTP - แม่แบบการนำเสนอ OpenDocument  

### การดำเนินการที่รองรับ

Aspose.Slides อนุญาตให้คุณใช้การปกป้องด้วยรหัสผ่านบนการนำเสนอเพื่อป้องกันการแก้ไขในวิธีต่อไปนี้:

- การเข้ารหัสการนำเสนอ  
- การตั้งการป้องกันการเขียนบนการนำเสนอ  

### การดำเนินการอื่น ๆ

Aspose.Slides อนุญาตให้คุณทำงานอื่น ๆ ที่เกี่ยวกับการปกป้องด้วยรหัสผ่านและการเข้ารหัสในวิธีต่อไปนี้:

- การถอดรหัสการนำเสนอ; เปิดการนำเสนอที่เข้ารหัส  
- การลบการเข้ารหัส; ปิดการปกป้องด้วยรหัสผ่าน  
- การลบการป้องกันการเขียนจากการนำเสนอ  
- การรับคุณลักษณะของการนำเสนอที่เข้ารหัส  
- ตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่  
- ตรวจสอบว่าการนำเสนอถูกปกป้องด้วยรหัสผ่านหรือไม่  

## **ปกป้องการนำเสนอด้วยรหัสผ่าน**

คุณสามารถเข้ารหัสการนำเสนอโดยกำหนดรหัสผ่าน จากนั้นเพื่อแก้ไขการนำเสนอที่ถูกล็อก ผู้ใช้ต้องให้รหัสผ่าน  

เพื่อเข้ารหัสหรือปกป้องการนำเสนอด้วยรหัสผ่าน คุณต้องใช้เมธอด encrypt (จาก [IProtectionManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/IProtectionManager)) เพื่อตั้งรหัสผ่านสำหรับการนำเสนอ คุณส่งรหัสผ่านไปยังเมธอด encrypt แล้วใช้เมธอด save เพื่อบันทึกการนำเสนอที่ถูกเข้ารหัสแล้ว  

ตัวอย่างโค้ดนี้แสดงวิธีการเข้ารหัสการนำเสนอ:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ตั้งการป้องกันการเขียนบนการนำเสนอ**

คุณสามารถเพิ่มเครื่องหมายที่ระบุว่า “ห้ามแก้ไข” ลงในการนำเสนอได้ วิธีนี้คุณจะบอกผู้ใช้ว่าคุณไม่ต้องการให้พวกเขาเปลี่ยนแปลงการนำเสนอ  

**หมายเหตุ** กระบวนการป้องกันการเขียนไม่ได้เข้ารหัสการนำเสนอ ดังนั้นผู้ใช้—หากพวกเขาต้องการจริง ๆ—สามารถแก้ไขการนำเสนอได้ แต่เพื่อบันทึกการเปลี่ยนแปลง พวกเขาต้องสร้างการนำเสนอด้วยชื่อใหม่  

เพื่อตั้งการป้องกันการเขียน คุณต้องใช้เมธอด [setWriteProtection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) จากนั้น ตัวอย่างโค้ดนี้จะแสดงวิธีการตั้งการป้องกันการเขียนบนการนำเสนอ:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **โหลดการนำเสนอที่เข้ารหัส**

Aspose.Slides อนุญาตให้คุณโหลดไฟล์ที่เข้ารหัสโดยส่งรหัสผ่านของมัน เพื่อถอดรหัสการนำเสนอ คุณต้องเรียกเมธอด [removeEncryption](https://reference.aspose.com/slides/th/java/com.aspose.slides/IProtectionManager#removeEncryption--) โดยไม่มีพารามิเตอร์ จากนั้นคุณจะต้องป้อนรหัสผ่านที่ถูกต้องเพื่อโหลดการนำเสนอ  

ตัวอย่างโค้ดนี้แสดงวิธีการถอดรหัสการนำเสนอ:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // ทำงานกับการนำเสนอที่ถอดรหัสแล้ว
} finally {
    if (presentation != null) presentation.dispose();
}
}
```

## **ลบการเข้ารหัสจากการนำเสนอ**

คุณสามารถลบการเข้ารหัสหรือการปกป้องด้วยรหัสผ่านบนการนำเสนอได้ วิธีนี้ผู้ใช้จะสามารถเข้าถึงหรือแก้ไขการนำเสนอโดยไม่มีข้อจำกัด  

เพื่อลบการเข้ารหัสหรือการปกป้องด้วยรหัสผ่าน คุณต้องเรียกเมธอด [removeEncryption](https://reference.aspose.com/slides/th/java/com.aspose.slides/IProtectionManager#removeEncryption--) ตัวอย่างโค้ดนี้แสดงวิธีการลบการเข้ารหัสจากการนำเสนอ:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ลบการป้องกันการเขียนจากการนำเสนอ**

คุณสามารถใช้ Aspose.Slides เพื่อลบการป้องกันการเขียนที่ใช้กับไฟล์การนำเสนอ วิธีนี้ผู้ใช้สามารถแก้ไขตามต้องการ—และจะไม่มีคำเตือนเมื่อทำเช่นนั้น  

คุณสามารถลบการป้องกันการเขียนจากการนำเสนอโดยใช้เมธอด [removeWriteProtection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) ตัวอย่างโค้ดนี้แสดงวิธีการลบการป้องกันการเขียนจากการนำเสนอ:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **รับคุณลักษณะของการนำเสนอที่เข้ารหัส**

โดยทั่วไป ผู้ใช้มักประสบปัญหาในการรับคุณลักษณะของเอกสารจากการนำเสนอที่เข้ารหัสหรือปกป้องด้วยรหัสผ่าน อย่างไรก็ตาม Aspose.Slides มีกลไกที่ทำให้คุณสามารถปกป้องการนำเสนอด้วยรหัสผ่านในขณะเดียวกันก็ยังให้ผู้ใช้เข้าถึงคุณลักษณะของการนำเสมนั้นได้  

**หมายเหตุ** เมื่อ Aspose.Slides เข้ารหัสการนำเสนอ คุณลักษณะของเอกสารการนำเสนอจะถูกปกป้องด้วยรหัสผ่านด้วยโดยค่าเริ่มต้น แต่หากคุณต้องการให้คุณลักษณะของการนำเสนอสามารถเข้าถึงได้ (แม้หลังจากการนำเสนอถูกเข้ารหัส) Aspose.Slides อนุญาตให้คุณทำเช่นนั้นได้  

หากคุณต้องการให้ผู้ใช้ยังคงสามารถเข้าถึงคุณลักษณะของการนำเสนอที่คุณได้เข้ารหัสไว้ คุณสามารถตั้งค่า property [encryptDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) เป็น `true` ตัวอย่างโค้ดนี้แสดงวิธีการเข้ารหัสการนำเสนอพร้อมให้ผู้ใช้เข้าถึงคุณลักษณะของเอกสารได้:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ตรวจสอบว่าการนำเสนอถูกปกป้องด้วยรหัสผ่านหรือไม่**

ก่อนที่คุณจะโหลดการนำเสนอ คุณอาจต้องการตรวจสอบและยืนยันว่าการนำเสนอไม่ได้ถูกปกป้องด้วยรหัสผ่าน วิธีนี้จะช่วยหลีกเลี่ยงข้อผิดพลาดและปัญหาอื่น ๆ ที่เกิดขึ้นเมื่อมีการโหลดการนำเสนอที่ปกป้องด้วยรหัสผ่านโดยไม่มีรหัสผ่าน  

โค้ด Java นี้แสดงวิธีการตรวจสอบการนำเสนอเพื่อดูว่ามีการปกป้องด้วยรหัสผ่านหรือไม่ (โดยไม่ต้องโหลดการนำเสนอเอง):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **ตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่**

Aspose.Slides อนุญาตให้คุณตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่ เพื่อทำงานนี้ คุณสามารถใช้ property [isEncrypted](https://reference.aspose.com/slides/th/java/com.aspose.slides/IProtectionManager#isEncrypted--) ซึ่งคืนค่า `true` หากการนำเสนอถูกเข้ารหัส หรือ `false` หากไม่ถูกเข้ารหัส  

ตัวอย่างโค้ดนี้แสดงวิธีการตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ตรวจสอบว่าการนำเสนอถูกป้องกันการเขียนหรือไม่**

Aspose.Slides อนุญาตให้คุณตรวจสอบว่าการนำเสนอถูกป้องกันการเขียนหรือไม่ เพื่อทำงานนี้ คุณสามารถใช้ property [isWriteProtected](https://reference.aspose.com/slides/th/java/com.aspose.slides/IProtectionManager#isWriteProtected--) ซึ่งคืนค่า `true` หากการนำเสนอถูกเข้ารหัส หรือ `false` หากการนำเสนอไม่ได้ถูกเข้ารหัส  

ตัวอย่างโค้ดนี้แสดงวิธีการตรวจสอบว่าการนำเสนอถูกป้องกันการเขียนหรือไม่:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ตรวจสอบหรือยืนยันว่ามีการใช้รหัสผ่านเฉพาะ**

คุณอาจต้องการตรวจสอบและยืนยันว่ามีการใช้รหัสผ่านเฉพาะเพื่อปกป้องเอกสารการนำเสนอ Aspose.Slides มีวิธีการให้คุณตรวจสอบความถูกต้องของรหัสผ่าน  

ตัวอย่างโค้ดนี้แสดงวิธีการตรวจสอบความถูกต้องของรหัสผ่าน:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // ตรวจสอบว่า "pass" ตรงกับหรือไม่
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

มันจะคืนค่า `true` หากการนำเสนอถูกเข้ารหัสด้วยรหัสผ่านที่ระบุ มิฉะนั้นจะคืนค่า `false`

{{% alert color="primary" title="ดูเพิ่มเติม" %}} 
- [ลายเซ็นดิจิทัลใน PowerPoint](/slides/th/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Aspose.Slides รองรับวิธีการเข้ารหัสใดบ้าง?**

Aspose.Slides รองรับวิธีการเข้ารหัสสมัยใหม่ รวมถึงอัลกอริธึมที่ใช้ AES ซึ่งให้ความปลอดภัยของข้อมูลระดับสูงสำหรับการนำเสนอของคุณ  

**เกิดอะไรขึ้นหากใส่รหัสผ่านไม่ถูกต้องเมื่อพยายามเปิดการนำเสนอ?**

ระบบจะโยนข้อยกเว้นหากใช้รหัสผ่านไม่ถูกต้อง เพื่อแจ้งว่าไม่ได้รับอนุญาตให้เข้าถึงการนำเสนอ วิธีนี้ช่วยป้องกันการเข้าถึงโดยไม่ได้รับอนุญาตและปกป้องเนื้อหาของการนำเสนอ  

**การทำงานกับการนำเสนอที่ปกป้องด้วยรหัสผ่านมีผลต่อประสิทธิภาพหรือไม่?**

กระบวนการเข้ารหัสและถอดรหัสอาจทำให้มีภาระเล็กน้อยในระหว่างการเปิดและบันทึก ในส่วนใหญ่ผลกระทบต่อประสิทธิภาพจะน้อยและไม่ส่งผลกระทบอย่างมีนัยสำคัญต่อเวลาการประมวลผลโดยรวมของงานนำเสนอของคุณ