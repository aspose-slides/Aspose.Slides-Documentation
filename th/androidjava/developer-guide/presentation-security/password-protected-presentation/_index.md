---
title: การรักษาความปลอดภัยของการนำเสนอด้วยรหัสผ่านบน Android
linktitle: การปกป้องด้วยรหัสผ่าน
type: docs
weight: 20
url: /th/androidjava/password-protected-presentation/
keywords:
- ล็อค PowerPoint
- ล็อคการนำเสนอ
- ปลดล็อค PowerPoint
- ปลดล็อคการนำเสนอ
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
- ปิดการใช้งานรหัสผ่าน
- ปิดการปกป้อง
- ลบการป้องกันการเขียน
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ล็อคและปลดล็อคการนำเสนอ PowerPoint และ OpenDocument ที่ปกป้องด้วยรหัสผ่านได้อย่างง่ายดายด้วย Aspose.Slides สำหรับ Android ผ่าน Java. รักษาความปลอดภัยการนำเสนอของคุณ."
---
## **บทนำ**

เมื่อคุณตั้งรหัสผ่านเพื่อปกป้องการนำเสนอ หมายความว่าคุณกำหนดรหัสผ่านที่บังคับใช้ข้อจำกัดบางอย่างบนการนำเสนอ หากต้องการลบข้อจำกัดเหล่านั้น จำเป็นต้องป้อนรหัสผ่าน การนำเสนอที่มีการปกป้องด้วยรหัสผ่านจะถือว่าเป็นการนำเสนอที่ถูกล็อก

โดยทั่วไปคุณสามารถตั้งรหัสผ่านเพื่อบังคับใช้ข้อจำกัดเหล่านี้บนการนำเสนอได้:

- **การแก้ไข**

  หากคุณต้องการให้ผู้ใช้บางคนเท่านั้นที่สามารถแก้ไขการนำเสนอของคุณได้ คุณสามารถตั้งข้อจำกัดการแก้ไขได้ ข้อจำกัดนี้จะป้องกันไม่ให้คนอื่นแก้ไข, เปลี่ยนแปลง หรือคัดลอกข้อมูลในการนำเสนอของคุณ (เว้นแต่พวกเขาจะให้รหัสผ่าน)

  อย่างไรก็ตามในกรณีนี้ แม้ไม่มีรหัสผ่าน ผู้ใช้ก็ยังสามารถเข้าถึงเอกสารของคุณและเปิดมันได้ ในโหมดอ่านอย่างเดียว ผู้ใช้สามารถดูเนื้อหา หรือสิ่งต่าง ๆ เช่น ไฮเปอร์ลิงก์, แอนิเมชัน, เอฟเฟ็กต์ ฯลฯ ภายในการนำเสนอของคุณได้ แต่ไม่สามารถคัดลอกรายการหรือบันทึกการนำเสนอได้

- **การเปิด**

  หากคุณต้องการให้ผู้ใช้บางคนเท่านั้นที่สามารถเปิดการนำเสนอของคุณได้ คุณสามารถตั้งข้อจำกัดการเปิดได้ ข้อจำกัดนี้จะป้องกันไม่ให้คนอื่นดูเนื้อหาของการนำเสนอของคุณ (เว้นแต่พวกเขาจะให้รหัสผ่าน)

  ทางเทคนิคแล้ว ข้อจำกัดการเปิดยังป้องกันไม่ให้ผู้ใช้แก้ไขการนำเสนอของคุณด้วย: เมื่อผู้ไม่สามารถเปิดการนำเสนอได้ พวกเขาจึงไม่สามารถทำการแก้ไขหรือเปลี่ยนแปลงใด ๆ ได้

  **หมายเหตุ** เมื่อคุณตั้งรหัสผ่านป้องกันการนำเสนอเพื่อป้องกันการเปิดไฟล์ การนำเสนอจะถูกเข้ารหัส

## **การปกป้องด้วยรหัสผ่านสำหรับการนำเสนอใน Aspose.Slides**
**รูปแบบที่รองรับ**

Aspose.Slides รองรับการปกป้องด้วยรหัสผ่าน, การเข้ารหัส, และการดำเนินการที่คล้ายคลึงกันสำหรับการนำเสนอในรูปแบบต่อไปนี้:

- PPTX และ PPT - Microsoft PowerPoint Presentation
- ODP - OpenDocument Presentation
- OTP - OpenDocument Presentation Template

**การดำเนินการที่รองรับ**

Aspose.Slides ช่วยให้คุณใช้การปกป้องด้วยรหัสผ่านบนการนำเสนอเพื่อป้องกันการแก้ไขได้หลายวิธี:

- การเข้ารหัสการนำเสนอ
- การตั้งการป้องกันการเขียนบนการนำเสนอ

**การดำเนินการอื่น ๆ**

Aspose.Slides ยังให้คุณทำงานอื่น ๆ ที่เกี่ยวกับการปกป้องด้วยรหัสผ่านและการเข้ารหัสได้ดังนี้:

- การถอดรหัสการนำเสนอ; การเปิดการนำเสนอที่เข้ารหัส
- การลบการเข้ารหัส; การปิดการปกป้องด้วยรหัสผ่าน
- การลบการป้องกันการเขียนจากการนำเสนอ
- การดึงคุณสมบัติของการนำเสนอที่เข้ารหัส
- การตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่
- การตรวจสอบว่าการนำเสนอถูกปกป้องด้วยรหัสผ่านหรือไม่

## **เข้ารหัสการนำเสนอ**

คุณสามารถเข้ารหัสการนำเสนอโดยตั้งรหัสผ่าน จากนั้นเพื่อแก้ไขการนำเสนอที่ถูกล็อก ผู้ใช้ต้องให้รหัสผ่าน

เพื่อเข้ารหัสหรือปกป้องการนำเสนอด้วยรหัสผ่าน คุณต้องใช้เมธอด `encrypt` (จาก[IProtectionManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IProtectionManager)) เพื่อกำหนดรหัสผ่านให้กับการนำเสนอ คุณส่งรหัสผ่านไปยังเมธอด `encrypt` แล้วใช้เมธอด `save` เพื่อบันทึกการนำเสนอที่เพิ่งเข้ารหัส

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีเข้ารหัสการนำเสนอ:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ตั้งการป้องกันการเขียนบนการนำเสนอ**

คุณสามารถเพิ่มเครื่องหมายว่า “ห้ามแก้ไข” ไปยังการนำเสนอ วิธีนี้ช่วยให้คุณบอกผู้ใช้ว่าไม่ต้องการให้พวกเขาแก้ไขการนำเสนอ

**หมายเหตุ** กระบวนการป้องกันการเขียนไม่ได้ทำการเข้ารหัสการนำเสนอ ดังนั้นผู้ใช้—หากต้องการ—สามารถแก้ไขการนำเสนอได้ แต่เพื่อบันทึกการเปลี่ยนแปลง พวกเขาต้องบันทึกการนำเสนอด้วยชื่อไฟล์อื่น

เพื่อกำหนดการป้องกันการเขียน คุณต้องใช้เมธอด[setWriteProtection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งการป้องกันการเขียนบนการนำเสนอ:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **โหลดการนำเสนอที่เข้ารหัส**

Aspose.Slides อนุญาตให้คุณโหลดการนำเสนอที่เข้ารหัสโดยส่งรหัสผ่านที่ถูกต้องผ่าน[LoadOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีเปิดการนำเสนอที่เข้ารหัส:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // ทำงานกับการนำเสนอที่ถอดรหัสแล้ว
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ลบการเข้ารหัสออกจากการนำเสนอ**

คุณสามารถลบการเข้ารหัสหรือการปกป้องด้วยรหัสผ่านออกจากการนำเสนอ ทำให้ผู้ใช้สามารถเข้าถึงหรือแก้ไขการนำเสนอได้โดยไม่มีข้อจำกัด

เพื่อทำเช่นนี้ ให้เรียกเมธอด[removeEncryption](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) ตัวอย่างโค้ดต่อไปนี้แสดงวิธีลบการเข้ารหัสจากการนำเสนอ:

```java
import com.aspose.slides.*;

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

## **ลบการป้องกันการเขียนออกจากการนำเสนอ**

คุณสามารถใช้ Aspose.Slides เพื่อลบการป้องกันการเขียนที่ใช้บนไฟล์การนำเสนอ ทำให้ผู้ใช้สามารถแก้ไขได้ตามต้องการ—และไม่มีคำเตือนใด ๆ ขณะทำงานดังกล่าว

คุณสามารถลบการป้องกันการเขียนจากการนำเสนอโดยใช้เมธอด[removeWriteProtection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) ตัวอย่างโค้ดต่อไปนี้แสดงวิธีลบการป้องกันการเขียนจากการนำเสนอ:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **รับคุณสมบัติของการนำเสนอที่เข้ารหัส**

โดยทั่วไปผู้ใช้มักประสบปัญหาในการดึงคุณสมบัติของเอกสารจากการนำเสนอที่เข้ารหัสหรือปกป้องด้วยรหัสผ่าน อย่างไรก็ตาม Aspose.Slides มีกลไกที่ช่วยให้คุณปกป้องการนำเสนอด้วยรหัสผ่านพร้อมยังคงให้ผู้ใช้เข้าถึงคุณสมบัติของมันได้

**หมายเหตุ:** โดยค่าเริ่มต้นเมื่อ Aspose.Slides เข้ารหัสการนำเสนอ คุณสมบัติของเอกสารการนำเสนอจะถูกปกป้องด้วยรหัสผ่านด้วย หากคุณต้องการให้คุณสมบัติเอกสารสามารถเข้าถึงได้แม้หลังจากเข้ารหัส Aspose.Slides อนุญาตให้ทำได้เช่นนั้น

หากต้องการให้ผู้ใช้ยังคงเข้าถึงคุณสมบัติของการนำเสนอที่เข้ารหัส ให้ส่งค่า`false`ไปยัง[IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) ตัวอย่างโค้ดต่อไปนี้แสดงวิธีเข้ารหัสการนำเสนอพร้อมให้ผู้ใช้เข้าถึงคุณสมบัติของเอกสาร:

```java
import com.aspose.slides.*;

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

เพื่อสืบตรวจสอบเมตาดาต้าของการนำเสนอที่เข้ารหัสโดยไม่ต้องโหลดสไลด์หรือเนื้อหาอื่น ๆ ให้สร้างอ็อบเจ็กต์[LoadOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/) แล้วส่งค่า`true`ไปยัง[setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-) ในโหมดนี้ Aspose.Slides จะละเลยรหัสผ่านและโหลดเฉพาะคุณสมบัติเอกสารที่เปิดให้เข้าถึงได้สาธารณะ

โค้ดตัวอย่างต่อไปนี้อ่านคุณสมบัติก่อนกำหนดและคุณสมบัติกำหนดเองผ่าน[IPresentation.getDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // อ่านคุณสมบัติเบื้องต้นของเอกสาร
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // อ่านคุณสมบัติที่กำหนดเองของเอกสาร
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

เวิร์กโฟลว์นี้ทำงานได้เฉพาะเมื่อคุณสมบัติเอกสารถูกปล่อยให้ไม่เข้ารหัส (สาธารณะ) ในขณะที่การนำเสนอถูกเข้ารหัส หากคุณสมบัติเอกสารถูกเข้ารหัส การส่งค่า`true`ไปยัง`loadOptions.setOnlyLoadDocumentProperties` จะทำให้เกิดข้อยกเว้นเนื่องจากรหัสผ่านถูกละเลยในโหมดนี้ เพื่อเข้าถึงคุณสมบัติเอกสารที่เข้ารหัสหรือโหลดการนำเสนอเต็มรูปแบบรวมสไลด์และเนื้อหาอื่น ๆ ให้ส่งรหัสผ่านที่ถูกต้องผ่าน[ILoadOptions.setPassword](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-)

## **ตรวจสอบว่าการนำเสนอถูกปกป้องด้วยรหัสผ่านหรือไม่**

ก่อนที่คุณจะโหลดการนำเสนอ คุณอาจต้องการตรวจสอบและยืนยันว่าการนำเสนอไม่ได้ถูกปกป้องด้วยรหัสผ่าน วิธีนี้ช่วยหลีกเลี่ยงข้อผิดพลาดและปัญหาอื่น ๆ ที่เกิดขึ้นเมื่อโหลดการนำเสนอที่ปกป้องด้วยรหัสผ่านโดยไม่มีรหัสผ่าน

โค้ด Java นี้แสดงวิธีตรวจสอบการนำเสนอว่าเป็นการปกป้องด้วยรหัสผ่านหรือไม่ (โดยไม่ต้องโหลดการนำเสนอเอง):

```java
import com.aspose.slides.*;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **ตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่**

Aspose.Slides ให้คุณตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่ เพื่อทำเช่นนี้ คุณสามารถใช้คุณสมบัติ[isEncrypted](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) ซึ่งจะคืนค่า`true`หากการนำเสนอถูกเข้ารหัส หรือ`false`หากไม่ได้เข้ารหัส

ตัวอย่างโค้ดแสดงวิธีตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ตรวจสอบว่าการนำเสนอถูกป้องกันการเขียนหรือไม่**

Aspose.Slides ให้คุณตรวจสอบว่าการนำเสนอถูกป้องกันการเขียนหรือไม่ เพื่อทำเช่นนี้ คุณสามารถใช้คุณสมบัติ[isWriteProtected](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) ซึ่งจะคืนค่า`true`หากการนำเสนอถูกป้องกันการเขียน หรือ`false`หากไม่ได้รับการป้องกัน

ตัวอย่างโค้ดแสดงวิธีตรวจสอบว่าการนำเสนอถูกป้องกันการเขียนหรือไม่:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ตรวจสอบหรือยืนยันว่ารหัสผ่านเฉพาะได้ถูกใช้**

คุณอาจต้องการตรวจสอบและยืนยันว่ารหัสผ่านเฉพาะได้ถูกใช้เพื่อปกป้องเอกสารการนำเสนอ Aspose.Slides มีวิธีให้คุณตรวจสอบรหัสผ่าน

ตัวอย่างโค้ดแสดงวิธีตรวจสอบรหัสผ่าน:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    // ตรวจสอบว่า "pass" ตรงกับหรือไม่
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

มันจะคืนค่า`true`หากการนำเสนอถูกป้องกันการเขียนด้วยรหัสผ่านที่ระบุ มิฉะนั้นจะคืนค่า`false`

{{% alert color="info" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/th/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับวิธีการเข้ารหัสแบบใดบ้าง?**

Aspose.Slides รองรับวิธีการเข้ารหัสสมัยใหม่รวมถึงอัลกอริทึมที่ใช้ AES ทำให้การรักษาความปลอดภัยของข้อมูลการนำเสนอของคุณอยู่ในระดับสูง

**จะเกิดอะไรขึ้นหากใส่รหัสผ่านผิดขณะพยายามเปิดการนำเสนอ?**

ระบบจะโยนข้อยกเว้นเมื่อรหัสผ่านไม่ถูกต้อง แจ้งให้คุณทราบว่าการเข้าถึงการนำเสนอถูกปฏิเสธ ซึ่งช่วยป้องกันการเข้าถึงโดยไม่ได้รับอนุญาตและรักษาเนื้อหาการนำเสนอ

**การทำงานกับการนำเสนอที่ปกป้องด้วยรหัสผ่านมีผลต่อประสิทธิภาพหรือไม่?**

กระบวนการเข้ารหัสและการถอดรหัสอาจทำให้เกิดภาระเพิ่มเติมเล็กน้อยในระหว่างการเปิดและบันทึก แต่ในส่วนใหญ่ผลกระทบต่อประสิทธิภาพจะต่ำและไม่ส่งผลอย่างมีนัยสำคัญต่อระยะเวลาการประมวลผลงานนำเสนอของคุณ