---
title: การป้องกันการนำเสนอด้วยรหัสผ่านใน Java
linktitle: การป้องกันด้วยรหัสผ่าน
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
- ลบการป้องกัน
- ลบการเข้ารหัส
- ปิดการใช้งานรหัสผ่าน
- ปิดการใช้งานการป้องกัน
- ลบการป้องกันการเขียน
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีล็อกและปลดล็อกการนำเสนอ PowerPoint และ OpenDocument ที่ป้องกันด้วยรหัสผ่านอย่างง่ายด้วย Aspose.Slides สำหรับ Java. ปกป้องการนำเสนอของคุณ."
---
## **บทนำ**

เมื่อคุณป้องกันการนำเสนอด้วยรหัสผ่าน หมายความว่าคุณกำหนดรหัสผ่านซึ่งบังคับใช้ข้อจำกัดบางอย่างบนการนำเสนอ หากต้องการลบข้อจำกัดเหล่านั้น ต้องป้อนรหัสผ่าน การนำเสนอที่ป้องกันด้วยรหัสผ่านถือเป็นการนำเสนอที่ถูกล็อก

โดยทั่วไป คุณสามารถตั้งรหัสผ่านเพื่อบังคับใช้ข้อจำกัดเหล่านี้บนการนำเสนอได้:

- **การแก้ไข**

หากคุณต้องการให้ผู้ใช้บางคนเท่านั้นที่สามารถแก้ไขการนำเสนอของคุณได้ คุณสามารถตั้งข้อจำกัดการแก้ไขได้ ข้อจำกัดนี้จะป้องกันไม่ให้คนอื่นแก้ไข เปลี่ยนแปลง หรือคัดลอกองค์ประกอบในการนำเสนอของคุณ เว้นแต่พวกเขาจะให้รหัสผ่าน  

อย่างไรก็ตาม แม้ไม่มีรหัสผ่าน ผู้ใช้ยังสามารถเข้าถึงและเปิดเอกสารของคุณได้ ในโหมดอ่านอย่างเดียวนี้ ผู้ใช้สามารถดูเนื้อหา—รวมถึงลิงก์, แอนิเมชัน, เอฟเฟกต์และองค์ประกอบอื่น ๆ—ในการนำเสนอของคุณได้ แต่ไม่สามารถคัดลอกรายการหรือบันทึกการนำเสนอได้  

- **การเปิด**

หากคุณต้องการให้ผู้ใช้บางคนเท่านั้นที่สามารถเปิดการนำเสนอของคุณได้ คุณสามารถตั้งข้อจำกัดการเปิดได้ ข้อจำกัดนี้จะป้องกันไม่ให้คนอื่นดูเนื้อหาของการนำเสนอของคุณเลย เว้นแต่พวกเขาจะให้รหัสผ่าน  

โดยเทคนิค ข้อจำกัดการเปิดยังป้องกันผู้ใช้จากการแก้ไขการนำเสนอของคุณด้วย—หากคนไม่สามารถเปิดการนำเสนอได้ พวกเขาจึงไม่สามารถแก้ไขหรือทำการเปลี่ยนแปลงใด ๆ ได้  

**หมายเหตุ:** เมื่อคุณป้องกันการนำเสนอด้วยรหัสผ่านเพื่อป้องกันการเปิดไฟล์ การนำเสนอจะถูกเข้ารหัส

## **การป้องกันด้วยรหัสผ่านใน Aspose.Slides**
**รูปแบบที่รองรับ**

Aspose.Slides รองรับการป้องกันด้วยรหัสผ่าน การเข้ารหัส และการดำเนินการที่คล้ายคลึงสำหรับการนำเสนอในรูปแบบต่อไปนี้:

- PPTX และ PPT - Microsoft PowerPoint Presentation
- ODP - OpenDocument Presentation
- OTP - OpenDocument Presentation Template

**การดำเนินการที่รองรับ**

Aspose.Slides อนุญาตให้คุณใช้การป้องกันด้วยรหัสผ่านบนการนำเสนอเพื่อป้องกันการแก้ไขในวิธีต่อไปนี้:

- การเข้ารหัสการนำเสนอ
- การตั้งการป้องกันการเขียนให้กับการนำเสนอ

**การดำเนินการอื่น ๆ**

Aspose.Slides อนุญาตให้คุณทำงานอื่น ๆ ที่เกี่ยวข้องกับการป้องกันด้วยรหัสผ่านและการเข้ารหัสในวิธีต่อไปนี้:

- การถอดรหัสการนำเสนอ; การเปิดการนำเสนอที่เข้ารหัส
- การลบการเข้ารหัส; การปิดการป้องกันด้วยรหัสผ่าน
- การลบการป้องกันการเขียนจากการนำเสนอ
- การรับคุณสมบัติของการนำเสนอที่เข้ารหัส
- การตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่
- การตรวจสอบว่าการนำเสนอถูกป้องกันด้วยรหัสผ่านหรือไม่

## **ป้องกันการนำเสนอด้วยรหัสผ่าน**

คุณสามารถเข้ารหัสการนำเสนอโดยตั้งรหัสผ่าน จากนั้นหากต้องการแก้ไขการนำเสนอที่ถูกล็อก ผู้ใช้ต้องให้รหัสผ่าน

เพื่อเข้ารหัสหรือป้องกันการนำเสนอด้วยรหัสผ่าน คุณต้องใช้เมธอด encrypt (จาก [IProtectionManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/IProtectionManager)) เพื่อกำหนดรหัสผ่านให้กับการนำเสนอ คุณส่งรหัสผ่านให้กับเมธอด encrypt แล้วใช้เมธอด save เพื่อบันทึกการนำเสนอที่ถูกเข้ารหัสแล้ว

ตัวอย่างโค้ดนี้แสดงวิธีเข้ารหัสการนำเสนอ:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ตั้งการป้องกันการเขียนให้กับการนำเสนอ**

คุณสามารถเพิ่มเครื่องหมาย “Do not modify” ลงในการนำเสนอ วิธีนี้ทำให้คุณบอกผู้ใช้ว่าไม่ต้องการให้พวกเขาแก้ไขการนำเสนอ  

**หมายเหตุ** กระบวนการป้องกันการเขียนไม่ได้เข้ารหัสการนำเสนอ ดังนั้นผู้ใช้—หากต้องการจริง ๆ—สามารถแก้ไขการนำเสนอได้ แต่เพื่อบันทึกการเปลี่ยนแปลง พวกเขาต้องสร้างการนำเสนอด้วยชื่อใหม่

เพื่อกำหนดการป้องกันการเขียน คุณต้องใช้เมธอด [setWriteProtection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) ตัวอย่างโค้ดนี้แสดงวิธีตั้งการป้องกันการเขียนให้กับการนำเสนอ:

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

Aspose.Slides ให้คุณโหลดไฟล์ที่เข้ารหัสโดยส่งรหัสผ่านของไฟล์นั้น เพื่อถอดรหัสการนำเสนอ คุณต้องเรียกเมธอด [removeEncryption](https://reference.aspose.com/slides/th/java/com.aspose.slides/IProtectionManager#removeEncryption--) โดยไม่มีพารามิเตอร์ จากนั้นคุณจะต้องป้อนรหัสผ่านที่ถูกต้องเพื่อโหลดการนำเสนอ

ตัวอย่างโค้ดนี้แสดงวิธีถอดรหัสการนำเสนอ:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // ทำงานกับการนำเสนอที่ถอดรหัสแล้ว
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ลบการเข้ารหัสจากการนำเสนอ**

คุณสามารถลบการเข้ารหัสหรือการป้องกันด้วยรหัสผ่านบนการนำเสนอได้ วิธีนี้ทำให้ผู้ใช้สามารถเข้าถึงหรือแก้ไขการนำเสนอโดยไม่มีข้อจำกัด

เพื่อลบการเข้ารหัสหรือการป้องกันด้วยรหัสผ่าน คุณต้องเรียกเมธอด [removeEncryption](https://reference.aspose.com/slides/th/java/com.aspose.slides/IProtectionManager#removeEncryption--) ตัวอย่างโค้ดนี้แสดงวิธีลบการเข้ารหัสจากการนำเสนอ:

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

คุณสามารถใช้ Aspose.Slides เพื่อลบการป้องกันการเขียนที่ใช้อยู่ในไฟล์การนำเสนอ วิธีนี้ทำให้ผู้ใช้สามารถแก้ไขได้ตามต้องการโดยไม่แสดงคำเตือนใด ๆ

คุณสามารถลบการป้องกันการเขียนจากการนำเสนอได้โดยใช้เมธอด [removeWriteProtection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) ตัวอย่างโค้ดนี้แสดงวิธีลบการป้องกันการเขียนจากการนำเสนอ:

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

โดยทั่วไป ผู้ใช้มักประสบปัญหาในการดึงคุณสมบัติของเอกสารจากการนำเสนอที่เข้ารหัสหรือป้องกันด้วยรหัสผ่าน อย่างไรก็ตาม Aspose.Slides มีกลไกที่ทำให้คุณสามารถป้องกันการนำเสนอด้วยรหัสผ่านพร้อมยังคงให้ผู้ใช้เข้าถึงคุณสมบัติของเอกสารได้

**หมายเหตุ:** ตามค่าเริ่มต้น เมื่อ Aspose.Slides เข้ารหัสการนำเสนอ คุณสมบัติของเอกสารการนำเสนอจะถูกป้องกันด้วยรหัสผ่านด้วย หากคุณต้องการให้คุณสมบัติของเอกสารสามารถเข้าถึงได้แม้หลังจากการเข้ารหัส Aspose.Slides รองรับการทำเช่นนั้น

หากคุณต้องการให้ผู้ใช้ยังคงสามารถเข้าถึงคุณสมบัติของการนำเสนอที่เข้ารหัสได้ ให้ส่งค่า `false` ไปยัง [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) ตัวอย่างโค้ดนี้แสดงวิธีเข้ารหัสการนำเสนอในขณะที่ยังให้ผู้ใช้เข้าถึงคุณสมบัติของเอกสารได้:

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

## **โหลดเฉพาะคุณสมบัติเอกสารจากการนำเสนอที่เข้ารหัส**

เพื่อสำรวจเมตาดาต้าของการนำเสนอที่เข้ารหัสโดยไม่โหลดสไลด์หรือเนื้อหาอื่น ๆ ให้สร้างอ็อบเจ็กต์ [LoadOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/) และส่งค่า `true` ไปยังเมธอด [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-) ในโหมดนี้ Aspose.Slides จะละเว้นรหัสผ่านและโหลดเฉพาะคุณสมบัติเอกสารที่สามารถเข้าถึงได้สาธารณะ

โค้ดตัวอย่างต่อไปนี้อ่านคุณสมบัติเชื่อมต่อและกำหนดเองผ่าน [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // อ่านคุณสมบัติเอกสารที่มีมาโดยอัตโนมัติ.
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // อ่านคุณสมบัติเอกสารที่กำหนดเอง.
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

ขั้นตอนนี้ทำงานได้เฉพาะเมื่อคุณสมบัติเอกสารถูกตั้งค่าให้ไม่เข้ารหัส (เป็นสาธารณะ) ขณะเข้ารหัสการนำเสนอ หากคุณสมบัติเอกสารถูกเข้ารหัส การส่งค่า `true` ไปยัง `loadOptions.setOnlyLoadDocumentProperties` จะทำให้เกิดข้อยกเว้น เนื่องจากรหัสผ่านจะถูกละเว้นในโหมดนี้ หากต้องการเข้าถึงคุณสมบัติเอกสารที่เข้ารหัสหรือโหลดการนำเสนอทั้งหมดรวมถึงสไลด์และเนื้อหาอื่น ๆ ให้ส่งรหัสผ่านที่ถูกต้องผ่าน [ILoadOptions.setPassword](https://reference.aspose.com/slides/th/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-)

## **ตรวจสอบว่าการนำเสนอถูกป้องกันด้วยรหัสผ่านหรือไม่**

ก่อนที่คุณจะโหลดการนำเสนอ คุณอาจต้องการตรวจสอบและยืนยันว่าการนำเสนอไม่ได้ถูกป้องกันด้วยรหัสผ่าน วิธีนี้ช่วยหลีกเลี่ยงข้อผิดพลาดและปัญหาอื่น ๆ ที่เกิดขึ้นเมื่อมีการโหลดการนำเสนอที่ป้องกันด้วยรหัสผ่านโดยไม่มีรหัสผ่าน

โค้ด Java นี้แสดงวิธีตรวจสอบการนำเสนอว่าเป็นการป้องกันด้วยรหัสผ่านหรือไม่ (โดยไม่ต้องโหลดการนำเสนอเอง):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **ตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่**

Aspose.Slides ให้คุณตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่ เพื่อทำเช่นนี้คุณสามารถใช้คุณสมบัติ [isEncrypted](https://reference.aspose.com/slides/th/java/com.aspose.slides/IProtectionManager#isEncrypted--) ซึ่งจะคืนค่า `true` หากการนำเสนอถูกเข้ารหัสหรือ `false` หากไม่ได้ถูกเข้ารหัส

ตัวอย่างโค้ดนี้แสดงวิธีตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ตรวจสอบว่าการนำเสนอถูกป้องกันการเขียนหรือไม่**

Aspose.Slides ให้คุณตรวจสอบว่าการนำเสนอถูกป้องกันการเขียนหรือไม่ เพื่อทำเช่นนี้คุณสามารถใช้คุณสมบัติ [isWriteProtected](https://reference.aspose.com/slides/th/java/com.aspose.slides/IProtectionManager#isWriteProtected--) ซึ่งจะคืนค่า `true` หากการนำเสนอถูกป้องกันการเขียนหรือ `false` หากไม่ได้ถูกป้องกัน

ตัวอย่างโค้ดนี้แสดงวิธีตรวจสอบว่าการนำเสนอถูกป้องกันการเขียนหรือไม่:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ตรวจสอบหรือยืนยันว่ามีการใช้รหัสผ่านเฉพาะหรือไม่**

คุณอาจต้องการตรวจสอบและยืนยันว่ามีการใช้รหัสผ่านเฉพาะเพื่อป้องกันเอกสารการนำเสนอหรือไม่ Aspose.Slides มีวิธีให้คุณตรวจสอบรหัสผ่าน

ตัวอย่างโค้ดนี้แสดงวิธีตรวจสอบรหัสผ่าน:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // ตรวจสอบว่า "pass" ตรงกับหรือไม่
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

มันจะคืนค่า `true` หากการนำเสนอถูกเข้ารหัสด้วยรหัสผ่านที่ระบุ มิฉะนั้นจะคืนค่า `false`.

{{% alert color="primary" title="ดูเพิ่มเติม" %}} 
- [ลายเซ็นดิจิทัลใน PowerPoint](/slides/th/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**วิธีการเข้ารหัสที่รองรับโดย Aspose.Slides คืออะไร?**

Aspose.Slides รองรับวิธีการเข้ารหัสสมัยใหม่ รวมถึงอัลกอริธึมที่ใช้ AES เพื่อให้ระดับความปลอดภัยของข้อมูลสูงสำหรับการนำเสนอของคุณ

**จะเกิดอะไรขึ้นหากป้อนรหัสผ่านไม่ถูกต้องเมื่อพยายามเปิดการนำเสนอ?**

จะมีการโยนข้อยกเว้นโดยแจ้งว่าการเข้าถึงการนำเสนอถูกปฏิเสธ ซึ่งช่วยป้องกันการเข้าถึงโดยไม่ได้รับอนุญาตและปกป้องเนื้อหาการนำเสนอ

**มีผลต่อประสิทธิภาพหรือไม่เมื่อทำงานกับการนำเสนอที่ป้องกันด้วยรหัสผ่าน?**

กระบวนการเข้ารหัสและถอดรหัสอาจทำให้เกิดค่าใช้จ่ายเล็กน้อยในขณะเปิดและบันทึก แต่ส่วนใหญ่ผลกระทบต่อประสิทธิภาพจะอยู่ในระดับต่ำและไม่ส่งผลอย่างมีนัยสำคัญต่อเวลาในการประมวลผลโดยรวมของงานการนำเสนอของคุณ.