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
- ปิดการทำงานของรหัสผ่าน
- ปิดการทำงานของการป้องกัน
- ลบการป้องกันการเขียน
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการล็อกและปลดล็อกการนำเสนอ PowerPoint และ OpenDocument ที่ป้องกันด้วยรหัสผ่านอย่างง่ายดายด้วย Aspose.Slides สำหรับ Java เพื่อความปลอดภัยของการนำเสนอของคุณ"
---
## **บทนำ**

เมื่อคุณตั้งค่าการป้องกันการนำเสนอด้วยรหัสผ่าน หมายความว่าคุณได้กำหนดรหัสผ่านที่บังคับใช้ข้อจำกัดบางอย่างกับการนำเสนอ การลบข้อจำกัดเหล่านี้ออกจำเป็นต้องใส่รหัสผ่าน การนำเสนอที่ป้องกันด้วยรหัสผ่านจะถือว่าเป็นการนำเสนอที่ถูกล็อก

โดยทั่วไปคุณสามารถตั้งรหัสผ่านเพื่อบังคับใช้ข้อจำกัดเหล่านี้บนการนำเสนอ:

- **การแก้ไข**

หากคุณต้องการให้ผู้ใช้บางคนเท่านั้นแก้ไขการนำเสนอของคุณ คุณสามารถตั้งข้อจำกัดการแก้ไขได้ ข้อจำกัดนี้จะป้องกันไม่ให้คนอื่นแก้ไข เปลี่ยนแปลง หรือคัดลอกองค์ประกอบในการนำเสนอของคุณ เว้นแต่พวกเขาจะใส่รหัสผ่าน  

อย่างไรก็ตาม แม้ไม่มีรหัสผ่าน ผู้ใช้ยังสามารถเข้าถึงและเปิดเอกสารของคุณได้ ในโหมดอ่านอย่างเดียวนี้ ผู้ใช้สามารถดูเนื้อหา ได้แก่ ไฮเปอร์ลิงก์, แอนิเมชัน, เอฟเฟกต์ และองค์ประกอบอื่น ๆ ภายในการนำเสนอของคุณ แต่ไม่สามารถคัดลอกรายการหรือบันทึกการนำเสนอได้  

- **การเปิด**

หากคุณต้องการให้ผู้ใช้บางคนเท่านั้นเปิดการนำเสนอของคุณ คุณสามารถตั้งข้อจำกัดการเปิดได้ ข้อจำกัดนี้จะป้องกันไม่ให้คนอื่นแม้แต่ดูเนื้อหาของการนำเสนอของคุณ เว้นแต่พวกเขาจะใส่รหัสผ่าน  

โดยเทคนิค ข้อจำกัดการเปิดยังป้องกันไม่ให้ผู้ใช้แก้ไขการนำเสนอ — หากคนไม่สามารถเปิดการนำเสนอได้ พวกเขาก็ไม่สามารถแก้ไขหรือทำการเปลี่ยนแปลงใด ๆ ได้  

**หมายเหตุ:** เมื่อคุณตั้งค่าการป้องกันการนำเสนอด้วยรหัสผ่านเพื่อปิดกั้นการเปิดไฟล์ การนำเสนอจะถูกเข้ารหัส  

## **การป้องกันด้วยรหัสผ่านใน Aspose.Slides**
**รูปแบบที่รองรับ**

Aspose.Slides รองรับการป้องกันด้วยรหัสผ่าน การเข้ารหัส และการดำเนินการที่คล้ายกันสำหรับการนำเสนอในรูปแบบต่อไปนี้:

- PPTX and PPT - การนำเสนอ Microsoft PowerPoint
- ODP - การนำเสนอ OpenDocument
- OTP - เทมเพลตการนำเสนอ OpenDocument  

**การดำเนินการที่รองรับ**

Aspose.Slides ช่วยให้คุณใช้การป้องกันด้วยรหัสผ่านบนการนำเสนอเพื่อป้องกันการแก้ไขได้โดยวิธีต่อไปนี้:

- การเข้ารหัสการนำเสนอ
- การตั้งค่าการป้องกันการเขียนให้กับการนำเสนอ  

**การดำเนินการอื่น ๆ**

Aspose.Slides ช่วยให้คุณทำงานอื่น ๆ ที่เกี่ยวกับการป้องกันด้วยรหัสผ่านและการเข้ารหัสได้ดังนี้:

- การถอดรหัสการนำเสนอ; การเปิดการนำเสนอที่เข้ารหัส
- การลบการเข้ารหัส; การปิดการป้องกันด้วยรหัสผ่าน
- การลบการป้องกันการเขียนออกจากการนำเสนอ
- การดึงคุณสมบัติของการนำเสนอที่เข้ารหัส
- การตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่
- การตรวจสอบว่าการนำเสนอถูกป้องกันด้วยรหัสผ่านหรือไม่  

## **ป้องกันการนำเสนอด้วยรหัสผ่าน**

คุณสามารถเข้ารหัสการนำเสนอโดยตั้งรหัสผ่านได้ หลังจากนั้น เพื่อแก้ไขการนำเสนอที่ถูกล็อก ผู้ใช้ต้องใส่รหัสผ่าน  

เพื่อเข้ารหัสหรือป้องกันการนำเสนอด้วยรหัสผ่าน คุณจะต้องใช้เมธอด encrypt (จาก [IProtectionManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/IProtectionManager)) เพื่อกำหนดรหัสผ่านให้กับการนำเสนอ คุณจะส่งรหัสผ่านไปยังเมธอด encrypt และใช้เมธอด save เพื่อบันทึกการนำเสนอที่ถูกเข้ารหัสแล้ว  

ตัวอย่างโค้ดนี้แสดงให้คุณเห็นวิธีการเข้ารหัสการนำเสนอ:

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

## **ตั้งการป้องกันการเขียนให้กับการนำเสนอ**

คุณสามารถเพิ่มเครื่องหมาย “ห้ามแก้ไข” ลงในการนำเสนอ วิธีนี้ช่วยบอกผู้ใช้ว่าคุณไม่ต้องการให้พวกเขาเปลี่ยนแปลงการนำเสนอ  

**หมายเหตุ** ว่ากระบวนการป้องกันการเขียนไม่ทำให้การนำเสนอถูกเข้ารหัส ดังนั้น ผู้ใช้—หากต้องการจริง ๆ—สามารถแก้ไขการนำเสนอได้ แต่เพื่อบันทึกการเปลี่ยนแปลง พวกเขาต้องสร้างการนำเสนอใหม่ด้วยชื่อที่แตกต่าง  

เพื่อกำหนดการป้องกันการเขียน คุณต้องใช้เมธอด [setWriteProtection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) วิธีนี้ ตัวอย่างโค้ดแสดงให้คุณเห็นวิธีการตั้งการป้องกันการเขียนให้กับการนำเสนอ:

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

Aspose.Slides ให้คุณโหลดการนำเสนอที่เข้ารหัสโดยส่งรหัสผ่านที่ถูกต้องผ่าน [LoadOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/).  

ตัวอย่างโค้ดนี้แสดงให้คุณเห็นวิธีการโหลดการนำเสนอที่เข้ารหัส:  

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

คุณสามารถลบการเข้ารหัสหรือการป้องกันด้วยรหัสผ่านออกจากการนำเสนอได้ วิธีนี้ทำให้ผู้ใช้สามารถเข้าถึงหรือแก้ไขการนำเสนอได้โดยไม่มีข้อจำกัด  

เพื่อทำการลบการเข้ารหัสหรือการป้องกันด้วยรหัสผ่าน คุณต้องเรียกเมธอด [removeEncryption](https://reference.aspose.com/slides/th/java/com.aspose.slides/IProtectionManager#removeEncryption--) วิธีนี้ ตัวอย่างโค้ดแสดงวิธีลบการเข้ารหัสออกจากการนำเสนอ:  

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

คุณสามารถใช้ Aspose.Slides เพื่อลบการป้องกันการเขียนที่ใช้บนไฟล์การนำเสนอ วิธีนี้ทำให้ผู้ใช้สามารถแก้ไขตามต้องการ—และจะไม่ได้รับคำเตือนเมื่อทำการดังกล่าว  

คุณสามารถลบการป้องกันการเขียนออกจากการนำเสนอโดยใช้เมธอด [removeWriteProtection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) ตัวอย่างโค้ดนี้แสดงวิธีการลบการป้องกันการเขียนออกจากการนำเสนอ:  

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

## **ดึงคุณสมบัติของการนำเสนอที่เข้ารหัส**

โดยทั่วไปผู้ใช้มักมีปัญหาในการดึงคุณสมบัติของเอกสารจากการนำเสนอที่เข้ารหัสหรือป้องกันด้วยรหัสผ่าน อย่างไรก็ตาม Aspose.Slides มีกลไกที่ให้คุณป้องกันการนำเสนอด้วยรหัสผ่านพร้อมยังคงให้ผู้ใช้สามารถเข้าถึงคุณสมบัติของมันได้  

**หมายเหตุ:** ตามค่าเริ่มต้นเมื่อ Aspose.Slides เข้ารหัสการนำเสนอ คุณสมบัติของเอกสารการนำเสนอจะถูกป้องกันด้วยรหัสผ่านด้วยเช่นกัน หากคุณต้องการให้คุณสมบัติของเอกสารสามารถเข้าถึงได้แม้หลังจากการเข้ารหัส Aspose.Slides ให้คุณทำได้เช่นนั้น  

หากคุณต้องการให้ผู้ใช้ยังคงสามารถเข้าถึงคุณสมบัติของการนำเสนอที่เข้ารหัสได้ ให้ส่งค่า `false` ไปยัง [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) ตัวอย่างโค้ดนี้แสดงวิธีการเข้ารหัสการนำเสนอพร้อมให้ผู้ใช้ยังคงเข้าถึงคุณสมบัติของเอกสารได้:  

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

## **โหลดเฉพาะคุณสมบัติของเอกสารจากการนำเสนอที่เข้ารหัส**

เพื่อสำรวจเมทาดาต้าของการนำเสนอที่เข้ารหัสโดยไม่ต้องโหลดสไลด์หรือเนื้อหาอื่น ๆ ให้สร้างอ็อบเจ็กต์ [LoadOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/) แล้วส่งค่า `true` ไปยังเมธอด [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-) ในโหมดนี้ Aspose.Slides จะละเว้นรหัสผ่านและโหลดเฉพาะคุณสมบัติของเอกสารที่สามารถเข้าถึงสาธารณะได้  

ตัวอย่างโค้ดต่อไปนี้อ่านคุณสมบัติของเอกสารที่มีมาในระบบและที่กำหนดเองผ่าน [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#getDocumentProperties--):  

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // อ่านคุณสมบัติเอกสารที่มาพร้อมในตัว.
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // อ่านคุณสมบัติเจ้าของเอกสารที่กำหนดเอง.
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

ขั้นตอนการทำงานนี้ใช้ได้เฉพาะเมื่อคุณสมบัติของเอกสารถูกปล่อยให้ไม่เข้ารหัส (สาธารณะ) ในขณะที่การนำเสนอถูกเข้ารหัส หากคุณสมบัติของเอกสารถูกเข้ารหัส การส่งค่า `true` ไปยัง `loadOptions.setOnlyLoadDocumentProperties` จะทำให้เกิดข้อยกเว้นเนื่องจากรหัสผ่านจะถูกละเว้นในโหมดนี้ เพื่อเข้าถึงคุณสมบัติของเอกสารที่เข้ารหัสหรือโหลดการนำเสนอแบบเต็มรวมถึงสไลด์และเนื้อหาอื่น ๆ ให้ส่งรหัสผ่านที่ถูกต้องผ่าน [ILoadOptions.setPassword](https://reference.aspose.com/slides/th/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).  

## **ตรวจสอบว่าการนำเสนอถูกป้องกันด้วยรหัสผ่านหรือไม่**

ก่อนที่คุณจะโหลดการนำเสนอ คุณอาจต้องการตรวจสอบและยืนยันว่าการนำเสนอไม่ได้ถูกป้องกันด้วยรหัสผ่าน วิธีนี้ช่วยหลีกเลี่ยงข้อผิดพลาดและปัญหาอื่น ๆ ที่เกิดขึ้นเมื่อโหลดการนำเสนอที่ป้องกันด้วยรหัสผ่านโดยไม่ใส่รหัสผ่าน  

โค้ด Java นี้แสดงวิธีตรวจสอบการนำเสนอว่าถูกป้องกันด้วยรหัสผ่านหรือไม่ (โดยไม่ต้องโหลดการนำเสนอเอง):  

```java
import com.aspose.slides.*;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **ตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่**

Aspose.Slides ให้คุณตรวจสอบว่า การนำเสนอถูกเข้ารหัสหรือไม่ เพื่อทำเช่นนี้คุณสามารถใช้ property [isEncrypted](https://reference.aspose.com/slides/th/java/com.aspose.slides/IProtectionManager#isEncrypted--) ซึ่งจะคืนค่า `true` หากการนำเสนอถูกเข้ารหัสหรือ `false` หากไม่ถูกเข้ารหัส  

ตัวอย่างโค้ดนี้แสดงวิธีตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่:  

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

Aspose.Slides ให้คุณตรวจสอบว่าการนำเสนอถูกป้องกันการเขียนหรือไม่ เพื่อทำเช่นนี้คุณสามารถใช้ property [isWriteProtected](https://reference.aspose.com/slides/th/java/com.aspose.slides/IProtectionManager#isWriteProtected--) ซึ่งจะคืนค่า `true` หากการนำเสนอถูกป้องกันการเขียนหรือ `false` หากไม่ใช่  

ตัวอย่างโค้ดนี้แสดงวิธีตรวจสอบว่าการนำเสนอถูกป้องกันการเขียนหรือไม่:  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ตรวจสอบหรือยืนยันว่ามีการใช้รหัสผ่านเฉพาะ**

คุณอาจต้องการตรวจสอบและยืนยันว่ามีการใช้รหัสผ่านเฉพาะในการป้องกันเอกสารการนำเสนอ Aspose.Slides มีวิธีที่ให้คุณตรวจสอบความถูกต้องของรหัสผ่าน  

ตัวอย่างโค้ดนี้แสดงวิธีตรวจสอบความถูกต้องของรหัสผ่าน:  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    // ตรวจสอบว่า "pass" ตรงกับ
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

มันจะคืนค่า `true` หากการนำเสนอถูกป้องกันการเขียนด้วยรหัสผ่านที่ระบุ มิฉะนั้นจะคืนค่า `false`  

{{% alert color="info" title="ดูเพิ่มเติม" %}} 
- [ลายเซ็นดิจิทัลใน PowerPoint](/slides/th/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**วิธีการเข้ารหัสที่ Aspose.Slides รองรับคืออะไร?**  
Aspose.Slides รองรับวิธีการเข้ารหัสสมัยใหม่ รวมถึงอัลกอริทึมที่อ้างอิงจาก AES ซึ่งให้ระดับความปลอดภัยของข้อมูลสูงสำหรับการนำเสนอของคุณ  

**จะเกิดอะไรขึ้นหากใส่รหัสผ่านไม่ถูกต้องขณะพยายามเปิดการนำเสนอ?**  
ระบบจะทำการโยนข้อยกเว้นหากใช้รหัสผ่านไม่ถูกต้อง ซึ่งจะแจ้งเตือนว่าการเข้าถึงการนำเสนอถูกปฏิเสธ การกระทำนี้ช่วยป้องกันการเข้าถึงโดยไม่ได้รับอนุญาตและคุ้มครองเนื้อหาการนำเสนอ  

**มีผลกระทบต่อประสิทธิภาพหรือไม่เมื่อทำงานกับการนำเสนอที่ป้องกันด้วยรหัสผ่าน?**  
กระบวนการเข้ารหัสและถอดรหัสอาจทำให้เกิดภาระการทำงานเพิ่มเล็กน้อยระหว่างการเปิดและบันทึก ในหลาย ๆ กรณี ผลกระทบต่อประสิทธิภาพนี้เป็นเพียงเล็กน้อยและไม่ส่งผลอย่างมีนัยสำคัญต่อเวลาการประมวลผลโดยรวมของงานการนำเสนอของคุณ