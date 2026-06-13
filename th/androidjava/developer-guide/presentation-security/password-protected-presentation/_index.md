---
title: ปกป้องการนำเสนอด้วยรหัสผ่านบน Android
linktitle: การปกป้องด้วยรหัสผ่าน
type: docs
weight: 20
url: /th/androidjava/password-protected-presentation/
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
- ความปลอดภัย PowerPoint
- ความปลอดภัยการนำเสนอ
- ลบรหัสผ่าน
- ลบการปกป้อง
- ลบการเข้ารหัส
- ปิดการใช้รหัสผ่าน
- ปิดการปกป้อง
- ลบการป้องกันการเขียน
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ล็อกและปลดล็อกการนำเสนอ PowerPoint และ OpenDocument ที่ปกป้องด้วยรหัสผ่านได้อย่างง่ายดายด้วย Aspose.Slides สำหรับ Android ผ่าน Java. ปกป้องการนำเสนอของคุณ."
---
## **บทนำ**

เมื่อคุณปกป้องการนำเสนอด้วยรหัสผ่าน หมายความว่าคุณกำหนดรหัสผ่านเพื่อบังคับใช้ข้อจำกัดบางอย่างบนการนำเสนอ หากต้องการลบข้อจำกัดเหล่านั้น จำเป็นต้องป้อนรหัสผ่าน การนำเสนอที่ปกป้องด้วยรหัสผ่านถือเป็นการนำเสนอที่ถูกล็อก

โดยทั่วไป คุณสามารถตั้งรหัสผ่านเพื่อบังคับใช้ข้อจำกัดเหล่านี้บนการนำเสนอได้:

- **การแก้ไข**

  หากคุณต้องการให้ผู้ใช้บางคนเท่านั้นที่สามารถแก้ไขการนำเสนอของคุณได้ คุณสามารถตั้งข้อจำกัดการแก้ไข ข้อจำกัดนี้จะป้องกันไม่ให้คนอื่นแก้ไข, เปลี่ยนแปลง หรือคัดลอกสิ่งต่าง ๆ ในการนำเสนอของคุณ (หากไม่ได้ให้รหัสผ่าน) 

  อย่างไรก็ตาม ในกรณีนี้ แม้ไม่มีรหัสผ่าน ผู้ใช้ก็ยังสามารถเข้าถึงเอกสารของคุณและเปิดได้ ในโหมดอ่าน‑เท่านั้น ผู้ใช้สามารถดูเนื้อหา หรือสิ่งต่าง ๆ เช่น ลิงก์, เอฟเฟกต์การเคลื่อนไหว, เอฟเฟกต์ และอื่น ๆ ภายในการนำเสนอของคุณ แต่ไม่สามารถคัดลอกรายการหรือบันทึกการนำเสนอได้ 

- **การเปิด**

  หากคุณต้องการให้ผู้ใช้บางคนเท่านั้นที่สามารถเปิดการนำเสนอของคุณได้ คุณสามารถตั้งข้อจำกัดการเปิดได้ ข้อจำกัดนี้จะป้องกันไม่ให้ผู้คนแม้แต่ดูเนื้อหาการนำเสนอของคุณ (หากไม่ได้ให้รหัสผ่าน) 

  โดยเทคนิคแล้ว ข้อจำกัดการเปิดยังป้องกันไม่ให้ผู้ใช้แก้ไขการนำเสนอของคุณ: เมื่อผู้คนไม่สามารถเปิดการนำเสนอได้ พวกเขาไม่สามารถทำการแก้ไขหรือเปลี่ยนแปลงใด ๆ ได้  

  **หมายเหตุ** หากคุณปกป้องการนำเสนอด้วยรหัสผ่านเพื่อป้องกันการเปิด ไฟล์การนำเสนอจะถูกเข้ารหัส

## **การปกป้องด้วยรหัสผ่านสำหรับการนำเสนอใน Aspose.Slides**
**รูปแบบที่รองรับ**

Aspose.Slides รองรับการปกป้องด้วยรหัสผ่าน การเข้ารหัส และการดำเนินการคล้ายกันสำหรับการนำเสนอในรูปแบบต่อไปนี้: 

- PPTX และ PPT - Microsoft PowerPoint Presentation 
- ODP - OpenDocument Presentation 
- OTP - OpenDocument Presentation Template 

**การดำเนินการที่รองรับ**

Aspose.Slides อนุญาตให้คุณใช้การปกป้องด้วยรหัสผ่านบนการนำเสนอเพื่อป้องกันการแก้ไขได้ด้วยวิธีต่อไปนี้:

- การเข้ารหัสการนำเสนอ
- การตั้งการป้องกันการเขียนสำหรับการนำเสนอ

**การดำเนินการอื่น ๆ**

Aspose.Slides อนุญาตให้คุณทำงานอื่น ๆ ที่เกี่ยวข้องกับการปกป้องด้วยรหัสผ่านและการเข้ารหัสได้ดังนี้:

- การถอดรหัสการนำเสนอ; การเปิดการนำเสนอที่เข้ารหัส
- การลบการเข้ารหัส; การปิดการปกป้องด้วยรหัสผ่าน
- การลบการป้องกันการเขียนจากการนำเสนอ
- การดึงคุณสมบัติของการนำเสนอที่เข้ารหัส
- การตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่
- การตรวจสอบว่าการนำเสนอถูกปกป้องด้วยรหัสผ่านหรือไม่

## **เข้ารหัสการนำเสนอ**

คุณสามารถเข้ารหัสการนำเสนอโดยตั้งรหัสผ่าน จากนั้นเพื่อแก้ไขการนำเสนอที่ถูกล็อก ผู้ใช้ต้องใส่รหัสผ่าน 

เพื่อเข้ารหัสหรือปกป้องการนำเสนอด้วยรหัสผ่าน คุณต้องใช้เมธอด encrypt (จาก[IProtectionManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IProtectionManager)) เพื่อกำหนดรหัสผ่านให้กับการนำเสนอ คุณส่งรหัสผ่านไปยังเมธอด encrypt แล้วใช้เมธอด save เพื่อบันทึกการนำเสนอที่ถูกเข้ารหัสแล้ว

โค้ดตัวอย่างนี้แสดงวิธีการเข้ารหัสการนำเสนอ:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ตั้งการป้องกันการเขียนสำหรับการนำเสนอ**

คุณสามารถเพิ่มเครื่องหมายที่ระบุว่า “ห้ามแก้ไข” ลงในการนำเสนอได้ วิธีนี้ทำให้คุณบอกผู้ใช้ว่าคุณไม่ต้องการให้พวกเขาแก้ไขการนำเสนอ  

**หมายเหตุ** กระบวนการป้องกันการเขียนไม่ได้ทำให้การนำเสนอเข้ารหัส ดังนั้นผู้ใช้—หากต้องการจริง ๆ—สามารถแก้ไขการนำเสนอได้ แต่เพื่อบันทึกการเปลี่ยนแปลง พวกเขาต้องสร้างการนำเสนอด้วยชื่อใหม่ 

เพื่อกำหนดการป้องกันการเขียน คุณต้องใช้เมธอด[setWriteProtection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) นี้ โค้ดตัวอย่างแสดงวิธีการตั้งการป้องกันการเขียนสำหรับการนำเสนอ:

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

Aspose.Slides อนุญาตให้คุณโหลดไฟล์ที่เข้ารหัสโดยส่งรหัสผ่านของไฟล์นั้น หากต้องการถอดรหัสการนำเสนอ คุณต้องเรียกเมธอด[removeEncryption](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) โดยไม่มีพารามิเตอร์ หลังจากนั้นคุณต้องใส่รหัสผ่านที่ถูกต้องเพื่อโหลดการนำเสนอ

โค้ดตัวอย่างนี้แสดงวิธีการถอดรหัสการนำเสนอ: 

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

คุณสามารถลบการเข้ารหัสหรือการปกป้องด้วยรหัสผ่านจากการนำเสนอได้ วิธีนี้ทำให้ผู้ใช้สามารถเข้าถึงหรือแก้ไขการนำเสนอโดยไม่มีข้อจำกัด 

เพื่อเลิกการเข้ารหัสหรือการปกป้องด้วยรหัสผ่าน คุณต้องเรียกเมธอด[removeEncryption](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) นี้ โค้ดตัวอย่างแสดงวิธีลบการเข้ารหัสจากการนำเสนอ:

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

คุณสามารถใช้ Aspose.Slides เพื่อลบการป้องกันการเขียนที่ใช้กับไฟล์การนำเสนอ วิธีนี้ทำให้ผู้ใช้สามารถแก้ไขตามต้องการโดยไม่มีการเตือนใด ๆ  

คุณสามารถลบการป้องกันการเขียนจากการนำเสนอโดยใช้เมธอด[removeWriteProtection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) นี้ โค้ดตัวอย่างแสดงวิธีลบการป้องกันการเขียนจากการนำเสนอ:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **รับคุณสมบัติของการนำเสนอที่เข้ารหัส**

โดยทั่วไป ผู้ใช้มักประสบปัญหาในการดึงคุณสมบัติของเอกสารจากการนำเสนอที่เข้ารหัสหรือถูกปกป้องด้วยรหัสผ่าน อย่างไรก็ตาม Aspose.Slides มีกลไกที่ให้คุณปกป้องการนำเสนอด้วยรหัสผ่านพร้อมยังคงให้ผู้ใช้เข้าถึงคุณสมบัติของการนำเสนอนั้นได้  

**หมายเหตุ** เมื่อ Aspose.Slides เข้ารหัสการนำเสนอ คุณสมบัติของเอกสารการนำเสนอจะถูกปกป้องด้วยรหัสผ่านโดยอัตโนมัติด้วย อย่างไรก็ตาม หากคุณต้องการให้คุณสมบัติของการนำเสนอสามารถเข้าถึงได้ (แม้หลังจากการนำเสนอถูกเข้ารหัส) Aspose.Slides อนุญาตให้ทำเช่นนั้นได้  

หากคุณต้องการให้ผู้ใช้ยังคงสามารถเข้าถึงคุณสมบัติของการนำเสนอที่คุณได้เข้ารหัสไว้ คุณสามารถตั้งค่า property[encryptDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) เป็น `true` โค้ดตัวอย่างนี้แสดงวิธีการเข้ารหัสการนำเสนอพร้อมให้ผู้ใช้เข้าถึงคุณสมบัติของเอกสารได้:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ตรวจสอบว่าการนำเสนอได้รับการปกป้องด้วยรหัสผ่านหรือไม่**

ก่อนที่คุณจะโหลดการนำเสนอ คุณอาจต้องการตรวจสอบและยืนยันว่าการนำเสนอไม่ได้ถูกปกป้องด้วยรหัสผ่าน วิธีนี้ช่วยหลีกเลี่ยงข้อผิดพลาดและปัญหาอื่น ๆ ที่เกิดขึ้นเมื่อโหลดการนำเสนอที่ปกป้องด้วยรหัสผ่านโดยไม่ได้ใส่รหัสผ่าน

โค้ด Java นี้แสดงวิธีการตรวจสอบการนำเสนอเพื่อดูว่ามีการปกป้องด้วยรหัสผ่านหรือไม่ (โดยไม่ต้องโหลดการนำเสนอเอง):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **ตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่**

Aspose.Slides ให้คุณตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่ เพื่อทำงานนี้คุณสามารถใช้ property[isEncrypted](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) ซึ่งจะคืนค่า `true` หากการนำเสนอถูกเข้ารหัส หรือ `false` หากไม่ได้เข้ารหัส

โค้ดตัวอย่างนี้แสดงวิธีตรวจสอบว่าการนำเข้าสั้นเข้ารหัสหรือไม่:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ตรวจสอบว่าการนำเสนอถูกป้องกันการเขียนหรือไม่**

Aspose.Slides ให้คุณตรวจสอบว่าการนำเสนอถูกป้องกันการเขียนหรือไม่ เพื่อทำงานนี้คุณสามารถใช้ property[isWriteProtected](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) ซึ่งจะคืนค่า `true` หากการนำเสนอถูกเข้ารหัส หรือ `false` หากไม่ได้เข้ารหัส

โค้ดตัวอย่างนี้แสดงวิธีตรวจสอบว่าการนำเสนอถูกป้องกันการเขียนหรือไม่:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ตรวจสอบหรือยืนยันว่ามีการใช้รหัสผ่านเฉพาะ**

คุณอาจต้องการตรวจสอบและยืนยันว่ามีการใช้รหัสผ่านเฉพาะเพื่อปกป้องเอกสารการนำเสนอ Aspose.Slides ให้วิธีการตรวจสอบรหัสผ่าน

โค้ดตัวอย่างนี้แสดงวิธีการตรวจสอบรหัสผ่าน:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // ตรวจสอบว่า "pass" ตรงกับ
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

มันจะคืนค่า `true` หากการนำเสนอถูกเข้ารหัสด้วยรหัสผ่านที่ระบุ มิฉะนั้นจะคืนค่า `false`. 

{{% alert color="primary" title="ดูเพิ่มเติม" %}} 
- [ลายเซ็นดิจิทัลใน PowerPoint](/slides/th/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**วิธีการเข้ารหัสที่ Aspose.Slides สนับสนุนคืออะไร?**

Aspose.Slides รองรับวิธีการเข้ารหัสสมัยใหม่ รวมถึงอัลกอริทึมที่ใช้ AES ซึ่งรับประกันระดับความปลอดภัยของข้อมูลสูงสำหรับการนำเสนอของคุณ  

**จะเกิดอะไรขึ้นหากใส่รหัสผ่านไม่ถูกต้องเมื่อพยายามเปิดการนำเสนอ?**

ข้อยกเว้นจะถูกโยนออกถ้ารหัสผ่านไม่ถูกต้อง ทำให้คุณได้รับการแจ้งว่าไม่สามารถเข้าถึงการนำเสนอได้ ซึ่งช่วยป้องกันการเข้าถึงโดยไม่ได้รับอนุญาตและรักษาเนื้อหาการนำเสนอไว้  

**การทำงานกับการนำเสนอที่ปกป้องด้วยรหัสผ่านมีผลต่อประสิทธิภาพหรือไม่?**

กระบวนการเข้ารหัสและถอดรหัสอาจเพิ่มภาระการทำงานเล็กน้อยในระหว่างการเปิดและบันทึก ในหลายกรณี ผลกระทบต่อประสิทธิภาพนี้เล็กน้อยและไม่ส่งผลอย่างมีนัยสำคัญต่อเวลาการประมวลผลรวมของงานการนำเสนอของคุณ