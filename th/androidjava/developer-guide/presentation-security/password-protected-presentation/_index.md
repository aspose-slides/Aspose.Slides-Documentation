---
title: การรักษาความปลอดภัยของงานนำเสนอด้วยรหัสผ่านบน Android
linktitle: การป้องกันด้วยรหัสผ่าน
type: docs
weight: 20
url: /th/androidjava/password-protected-presentation/
keywords:
- ล็อก PowerPoint
- ล็อกงานนำเสนอ
- ปลดล็อก PowerPoint
- ปลดล็อกงานนำเสนอ
- ป้องกัน PowerPoint
- ป้องกันงานนำเสนอ
- ตั้งรหัสผ่าน
- เพิ่มรหัสผ่าน
- เข้ารหัส PowerPoint
- เข้ารหัสงานนำเสนอ
- ถอดรหัส PowerPoint
- ถอดรหัสงานนำเสนอ
- การป้องกันการเขียน
- ความปลอดภัย PowerPoint
- ความปลอดภัยงานนำเสนอ
- ลบรหัสผ่าน
- ลบการป้องกัน
- ลบการเข้ารหัส
- ปิดการทำงานของรหัสผ่าน
- ปิดการทำงานของการป้องกัน
- ลบการป้องกันการเขียน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ล็อกและปลดล็อกงานนำเสนอ PowerPoint และ OpenDocument ที่ป้องกันด้วยรหัสผ่านได้อย่างง่ายดายด้วย Aspose.Slides สำหรับ Android ผ่าน Java. รักษาความปลอดภัยของงานนำเสนอของคุณ."
---
## **บทนำ**

เมื่อคุณตั้งรหัสผ่านป้องกันงานนำเสนอ หมายความว่าคุณกำหนดรหัสผ่านที่บังคับใช้ข้อจำกัดบางอย่างบนงานนำเสนอ เพื่อยกเลิกข้อจำกัดเหล่านั้น จำเป็นต้องป้อนรหัสผ่าน งานนำเสนอที่ตั้งรหัสผ่านจะถือว่าเป็นงานนำเสนอที่ถูกล็อก

โดยทั่วไป คุณสามารถตั้งรหัสผ่านเพื่อบังคับใช้ข้อจำกัดเหล่านี้บนงานนำเสนอได้:

- **การแก้ไข**

  หากคุณต้องการให้ผู้ใช้บางคนเท่านั้นที่สามารถแก้ไขงานนำเสนอของคุณได้ คุณสามารถตั้งข้อจำกัดการแก้ไขได้ ข้อจำกัดนี้จะป้องกันไม่ให้ผู้ใช้แก้ไข เปลี่ยนแปลง หรือคัดลอกสิ่งต่าง ๆ ในงานนำเสนอของคุณ (หากไม่ได้ให้รหัสผ่าน) 

  อย่างไรก็ตาม ในกรณีนี้ แม้ไม่ได้ใส่รหัสผ่าน ผู้ใช้ก็สามารถเข้าถึงเอกสารของคุณและเปิดได้ ในโหมดอ่านอย่างเดียว ผู้ใช้สามารถดูเนื้อหา หรือองค์ประกอบต่าง ๆ เช่น ลิงก์, แอนิเมชัน, เอฟเฟกต์ และอื่น ๆ ภายในงานนำเสนอของคุณได้ แต่ไม่สามารถคัดลอกรายการหรือบันทึกงานนำเสนอได้ 

- **การเปิด**

  หากคุณต้องการให้ผู้ใช้บางคนเท่านั้นที่สามารถเปิดงานนำเสนอของคุณได้ คุณสามารถตั้งข้อจำกัดการเปิดได้ ข้อจำกัดนี้จะป้องกันไม่ให้ผู้ใช้แม้แต่ดูเนื้อหาของงานนำเสนอ (หากไม่ได้ให้รหัสผ่าน) 

  โดยเทคนิคแล้ว ข้อจำกัดการเปิดยังป้องกันผู้ใช้จากการแก้ไขงานนำเสนอของคุณ: เมื่อผู้ใช้ไม่สามารถเปิดงานนำเสนอได้ พวกเขาจะไม่สามารถทำการแก้ไขหรือเปลี่ยนแปลงใด ๆ ได้  

  **หมายเหตุ** เมื่อคุณตั้งรหัสผ่านป้องกันงานนำเสนอเพื่อป้องกันการเปิด ไฟล์งานนำเสนอจะถูกเข้ารหัส

## **การป้องกันด้วยรหัสผ่านสำหรับงานนำเสนอใน Aspose.Slides**
**รูปแบบที่รองรับ**

Aspose.Slides รองรับการป้องกันด้วยรหัสผ่าน การเข้ารหัส และการดำเนินการที่คล้ายกันสำหรับงานนำเสนอในรูปแบบต่อไปนี้: 

- PPTX และ PPT - Microsoft PowerPoint Presentation 
- ODP - OpenDocument Presentation 
- OTP - OpenDocument Presentation Template 

**การดำเนินการที่รองรับ**

Aspose.Slides ให้คุณใช้การป้องกันด้วยรหัสผ่านบนงานนำเสนอเพื่อป้องกันการแก้ไขได้ด้วยวิธีต่อไปนี้:

- การเข้ารหัสงานนำเสนอ
- การตั้งค่าการป้องกันการเขียนบนงานนำเสนอ

**การดำเนินการอื่น ๆ**

Aspose.Slides ให้คุณทำงานอื่น ๆ ที่เกี่ยวกับการป้องกันด้วยรหัสผ่านและการเข้ารหัสได้ด้วยวิธีต่อไปนี้:

- การถอดรหัสงานนำเสนอ; การเปิดงานนำเสนอที่ถูกเข้ารหัส
- การลบการเข้ารหัส; การปิดการป้องกันด้วยรหัสผ่าน
- การลบการป้องกันการเขียนจากงานนำเสนอ
- การรับคุณสมบัติของงานนำเสนอที่เข้ารหัส
- การตรวจสอบว่างานนำเสนอถูกเข้ารหัสหรือไม่
- การตรวจสอบว่างานนำเสนอถูกป้องกันด้วยรหัสผ่านหรือไม่.

## **เข้ารหัสงานนำเสนอ**

คุณสามารถเข้ารหัสงานนำเสนอโดยกำหนดรหัสผ่านได้ หลังจากนั้นเพื่อแก้ไขงานนำเสนอที่ถูกล็อก ผู้ใช้จำเป็นต้องให้รหัสผ่าน

เพื่อเข้ารหัสหรือป้องกันงานนำเสนอด้วยรหัสผ่าน คุณต้องใช้เมธอด encrypt (จาก [IProtectionManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IProtectionManager)) เพื่อกำหนดรหัสผ่านให้กับงานนำเสนอ คุณส่งรหัสผ่านไปยังเมธอด encrypt และใช้เมธอด save เพื่อบันทึกงานนำเสนอที่ถูกเข้ารหัสใหม่

ตัวอย่างโค้ดนี้แสดงวิธีการเข้ารหัสงานนำเสนอ:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ตั้งค่าการป้องกันการเขียนบนงานนำเสนอ**

คุณสามารถเพิ่มเครื่องหมาย “Do not modify” ลงในงานนำเสนอ วิธีนี้ทำให้คุณบอกผู้ใช้ว่าคุณไม่ต้องการให้พวกเขาแก้ไขงานนำเสนอ

**หมายเหตุ** กระบวนการป้องกันการเขียนไม่ได้ทำการเข้ารหัสงานนำเสนอ ดังนั้นผู้ใช้—หากต้องการ—สามารถแก้ไขงานนำเสนอได้ แต่หากต้องการบันทึกการเปลี่ยนแปลง พวกเขาต้องสร้างงานนำเสนอด้วยชื่อใหม่

เพื่อกำหนดการป้องกันการเขียน คุณต้องใช้เมธอด [setWriteProtection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) วิธีนี้ ตัวอย่างโค้ดแสดงวิธีการตั้งค่าการป้องกันการเขียนบนงานนำเสนอ:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **โหลดงานนำเสนอที่ถูกเข้ารหัส**

Aspose.Slides ให้คุณโหลดไฟล์ที่ถูกเข้ารหัสโดยใส่รหัสผ่านของมัน เพื่อถอดรหัสงานนำเสนอ คุณต้องเรียกเมธอด [removeEncryption](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) โดยไม่มีพารามิเตอร์ แล้วคุณจะต้องใส่รหัสผ่านที่ถูกต้องเพื่อโหลดงานนำเสนอ

ตัวอย่างโค้ดนี้แสดงวิธีการถอดรหัสงานนำเสนอ: 

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // ทำงานกับงานนำเสนอที่ถอดรหัสแล้ว
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ลบการเข้ารหัสจากงานนำเสนอ**

คุณสามารถลบการเข้ารหัสหรือการป้องกันด้วยรหัสผ่านจากงานนำเสนอได้ วิธีนี้ทำให้ผู้ใช้สามารถเข้าถึงหรือแก้ไขงานนำเสนอโดยไม่มีข้อจำกัด

เพื่อทำการลบการเข้ารหัสหรือการป้องกันด้วยรหัสผ่าน คุณต้องเรียกเมธอด [removeEncryption](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) ตัวอย่างโค้ดนี้แสดงวิธีการลบการเข้ารหัสจากงานนำเสนอ:

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

## **ลบการป้องกันการเขียนจากงานนำเสนอ**

คุณสามารถใช้ Aspose.Slides เพื่อลบการป้องกันการเขียนที่ใช้ในไฟล์งานนำเสนอ วิธีนี้ผู้ใช้สามารถแก้ไขได้ตามต้องการ—และจะไม่มีคำเตือนเมื่อทำเช่นนั้น

คุณสามารถลบการป้องกันการเขียนจากงานนำเสนอได้โดยใช้เมธอด [removeWriteProtection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) ตัวอย่างโค้ดนี้แสดงวิธีการลบการป้องกันการเขียนจากงานนำเสนอ:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **รับคุณสมบัติของงานนำเสนอที่ถูกเข้ารหัส**

โดยทั่วไป ผู้ใช้มักประสบความยากลำบากในการดึงคุณสมบัติของเอกสารจากงานนำเสนอที่ถูกเข้ารหัสหรือป้องกันด้วยรหัสผ่าน อย่างไรก็ตาม Aspose.Slides มีกลไกที่ให้คุณป้องกันงานนำเสนอด้วยรหัสผ่านในขณะเดียวกันยังคงให้ผู้ใช้เข้าถึงคุณสมบัติของมันได้

**หมายเหตุ:** โดยค่าเริ่มต้นเมื่อ Aspose.Slides เข้ารหัสงานนำเสนอ คุณสมบัติของเอกสารของงานนำเสนอจะถูกป้องกันด้วยรหัสผ่านด้วย หากคุณต้องการให้คุณสมบัติของเอกสารเข้าถึงได้แม้หลังจากการเข้ารหัส Aspose.Slides ให้คุณทำเช่นนั้นได้

หากคุณต้องการให้ผู้ใช้ยังคงสามารถเข้าถึงคุณสมบัติของงานนำเสนอที่ถูกเข้ารหัสได้ ให้ส่งค่า `false` ไปยัง [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) ตัวอย่างโค้ดนี้แสดงวิธีการเข้ารหัสงานนำเสนอโดยยังคงให้ผู้ใช้เข้าถึงคุณสมบัติของเอกสารได้:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **โหลดเฉพาะคุณสมบัติเข้ามจากงานนำเสนอที่ถูกเข้ารหัส**

เพื่อตรวจสอบเมตาดาต้าของงานนำเสนอที่ถูกเข้ารหัสโดยไม่ต้องโหลดสไลด์หรือเนื้อหาอื่น ๆ ให้สร้างอ็อบเจ็กต์ [LoadOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/) แล้วส่งค่า `true` ไปยัง [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-) ในโหมดนี้ Aspose.Slides จะละเว้นรหัสผ่านและโหลดเฉพาะคุณสมบัติของเอกสารที่เปิดเผยต่อสาธารณะ

ตัวอย่างโค้ดต่อไปนี้อ่านคุณสมบัติเอกสารที่มีอยู่แล้วและที่กำหนดเองผ่าน [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // อ่านคุณสมบัติเอกสารที่มีมาในตัว
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // อ่านคุณสมบัติเอกสารที่กำหนดเอง
    int customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        String propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

เวิร์กโฟลว์นี้ทำงานได้เฉพาะเมื่อคุณสมบัติของเอกสารถูกปล่อยให้ไม่เข้ารหัส (สาธารณะ) ขณะเข้ารหัสงานนำเสนอ หากคุณสมบัติของเอกสารถูกเข้ารหัส การส่งค่า `true` ไปยัง `loadOptions.setOnlyLoadDocumentProperties` จะทำให้เกิดข้อยกเว้นเพราะรหัสผ่านจะถูกละเว้นในโหมดนี้ เพื่อเข้าถึงคุณสมบัติของเอกสารที่เข้ารหัสหรือโหลดงานนำเสนอเต็มรูปแบบรวมทั้งสไลด์และเนื้อหาอื่น ๆ ให้ใส่รหัสผ่านที่ถูกต้องผ่าน [ILoadOptions.setPassword](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).

## **ตรวจสอบว่างานนำเสนอถูกป้องกันด้วยรหัสผ่านหรือไม่**

ก่อนที่คุณจะโหลดงานนำเสนอ คุณอาจต้องการตรวจสอบและยืนยันว่างานนำเสนอไม่ได้ถูกป้องกันด้วยรหัสผ่าน วิธีนี้ช่วยหลีกเลี่ยงข้อผิดพลาดและปัญหาอื่น ๆ ที่เกิดขึ้นเมื่อโหลดงานนำเสนอที่ถูกป้องกันด้วยรหัสผ่านโดยไม่ได้ใส่รหัสผ่าน

โค้ด Java นี้แสดงวิธีการตรวจสอบงานนำเสนอเพื่อดูว่าถูกป้องกันด้วยรหัสผ่านหรือไม่ (โดยไม่ต้องโหลดงานนำเสนอเอง):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **ตรวจสอบว่างานนำเสนอถูกเข้ารหัสหรือไม่**

Aspose.Slides ให้คุณตรวจสอบว่างานนำเสนอถูกเข้ารหัสหรือไม่ เพื่อทำงานนี้ คุณสามารถใช้คุณสมบัติ [isEncrypted](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) ซึ่งจะคืนค่า `true` หากงานนำถูกเข้ารหัสหรือ `false` หากไม่ถูกเข้ารหัส

ตัวอย่างโค้ดนี้แสดงวิธีการตรวจสอบว่างานนำเสนอถูกเข้ารหัสหรือไม่:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ตรวจสอบว่างานนำเสนอถูกป้องกันการเขียนหรือไม่**

Aspose.Slides ให้คุณตรวจสอบว่างานนำเสนอถูกป้องกันการเขียนหรือไม่ เพื่อทำงานนี้ คุณสามารถใช้คุณสมบัติ [isWriteProtected](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) ซึ่งจะคืนค่า `true` หากงานนำถูกป้องกันการเขียนหรือ `false` หากไม่ถูกป้องกันการเขียน

ตัวอย่างโค้ดนี้แสดงวิธีการตรวจสอบว่างานนำเสนอถูกป้องกันการเขียนหรือไม่:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ตรวจสอบหรือยืนยันว่ามีการใช้รหัสผ่านเฉพาะหรือไม่**

คุณอาจต้องการตรวจสอบและยืนยันว่ามีการใช้รหัสผ่านเฉพาะเพื่อป้องกันเอกสารงานนำเสนอหรือไม่ Aspose.Slides มีวิธีให้คุณตรวจสอบความถูกต้องของรหัสผ่าน

ตัวอย่างโค้ดนี้แสดงวิธีการตรวจสอบรหัสผ่าน:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // ตรวจสอบว่า "pass" ตรงกับ
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

มันจะคืนค่า `true` หากงานนำถูกเข้ารหัสด้วยรหัสผ่านที่ระบุ มิฉะนั้นจะคืนค่า `false`

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/th/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**วิธีการเข้ารหัสที่รองรับโดย Aspose.Slides คืออะไร?**

Aspose.Slides รองรับวิธีการเข้ารหัสสมัยใหม่ รวมถึงอัลกอริทึมที่ใช้ AES ซึ่งรับประกันระดับความปลอดภัยของข้อมูลสูงสำหรับงานนำเสนอของคุณ

**เกิดอะไรขึ้นหากใส่รหัสผ่านผิดเมื่อพยายามเปิดงานนำเสนอ?**

ระบบจะโยนข้อยกเว้นหากใช้รหัสผ่านไม่ถูกต้อง ทำให้คุณทราบว่าการเข้าถึงงานนำเสนอถูกปฏิเสธ ซึ่งช่วยป้องกันการเข้าถึงโดยไม่ได้รับอนุญาตและปกป้องเนื้อหาของงานนำเสนอ

**มีผลต่อประสิทธิภาพหรือไม่เมื่อทำงานกับงานนำเสนอที่ป้องกันด้วยรหัสผ่าน?**

กระบวนการเข้ารหัสและถอดรหัสอาจทำให้เกิดภาระเล็กน้อยในระหว่างการเปิดและบันทึกงานนำเสนอ ในกรณีส่วนใหญ่ ผลกระทบต่อประสิทธิภาพนี้เล็กน้อยและไม่ส่งผลอย่างมีนัยสำคัญต่อเวลาการประมวลผลโดยรวมของงานนำเสนอของคุณ