---
title: ป้องกันพรีเซนเทชันด้วยรหัสผ่านบน Android
linktitle: การป้องกันด้วยรหัสผ่าน
type: docs
weight: 20
url: /th/androidjava/password-protected-presentation/
keywords:
- พรีเซนเทชันที่ป้องด้วยรหัสผ่าน
- รหัสผ่านเปิดใช้
- เข้ารหัส PowerPoint
- ถอดรหัส PowerPoint
- ตรวจสอบรหัสผ่านพรีเซนเทชัน
- ตรวจสอบรหัสผ่านพรีเซนเทชัน
- เปิดพรีเซนเทชันที่เข้ารหัส
- ลบการเข้ารหัส
- PowerPoint
- PPT
- PPTX
- พรีเซนเทชัน
- Android
- Java
- Aspose.Slides
description: "เข้ารหัส, ตรวจจับ, ตรวจสอบ, เปิดและถอดรหัสพรีเซนเทชัน PowerPoint PPT และ PPTX ที่ป้องด้วยรหัสผ่านด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

รหัสผ่านเปิดใช้เพื่อเข้ารหัสพรีเซนเทชัน รหัสผ่านที่ถูกต้องจำเป็นสำหรับการโหลดและดูเนื้อหาพรีเซนเทชัน ดังนั้นการป้องกันนี้จึงให้ความลับของข้อมูล

รหัสผ่านเปิดใช้แตกต่างจากรหัสผ่านป้องกันการเขียน (write‑protection) ซึ่งการป้องกันการเขียนจำกัดการแก้ไขแต่ไม่ได้เข้ารหัสเนื้อหาหรือป้องกันการโหลดพรีเซนเทชัน เพื่อจัดการรหัสผ่านสำหรับการแก้ไขพรีเซนเทชัน ดูที่ [ป้องกันการเขียนพรีเซนเทชัน](/slides/th/androidjava/write-protected-presentation/)

ขั้นตอนการทำงานด้านล่างใช้กับพรีเซนเทชันทั้งแบบ PPT และ PPTX ตัวอย่างใช้ทั้งสองรูปแบบเมื่อพฤติกรรมแบบไฟล์และสตรีมมีความสำคัญ

## **เข้ารหัสพรีเซนเทชันด้วยรหัสผ่านเปิดใช้**

ใช้ [IProtectionManager.encrypt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) เพื่อกำหนดรหัสผ่านเปิดใช้ จากนั้นใช้ [IPresentation.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) เพื่อบันทึกพรีเซนเทชันที่เข้ารหัสแล้ว

ตัวอย่างต่อไปนี้เข้ารหัสพรีเซนเทชันแบบ PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ทำให้คุณสมบัติลูกค้าเป็นสาธารณะ**

โดยค่าเริ่มต้น Aspose.Slides จะรวมคุณสมบัติลูกค้าไว้ในการเข้ารหัสพรีเซนเทชัน วิธีการ [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) ควบคุมพฤติกรรมนี้โดยอิสระจากการเข้ารหัสเนื้อหาสไลด์ ให้ส่งค่า `false` ก่อนเรียก [IProtectionManager.encrypt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) เมื่อต้องการให้ระบบการทำดัชนี การจำแนก การค้นหา หรือการจัดการเอกสารสามารถอ่านเมตาดาต้าได้โดยไม่ต้องใช้รหัสผ่านเปิดใช้

ตัวอย่างต่อไปนี้สร้างพรีเซนเทชัน PPTX ที่เข้ารหัสโดยทำให้คุณสมบัติลูกค้าภายในเป็นสาธารณะ:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การส่งค่า `false` ไปยัง [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) ไม่ได้ทำให้สไลด์ มาสเตอร์ เลเอาต์ รูปทรง สื่อ หรือเนื้อหาอื่นของพรีเซนเทชันเป็นสาธารณะ มันส่งผลแค่คุณสมบัติลูกค้าเท่านั้น เพื่ออ่านคุณสมบัติเหล่านั้นโดยไม่ต้องโหลดเนื้อหาที่เข้ารหัส ดูที่ [จัดการคุณสมบัติพรีเซนเทชัน](/slides/th/androidjava/presentation-properties/)

## **โหลดพรีเซนเทชันที่เข้ารหัส**

ตั้งค่า [ILoadOptions.setPassword](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) ให้เป็นรหัสผ่านเปิดใช้และส่งอ็อปชันนี้ไปยังตัวสร้าง [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) เมื่อทำการโหลดไฟล์ การโหลดจะล้มเหลือเมื่อพรีเซนเทชันต้องการรหัสผ่านเปิดใช้แต่ไม่ได้ระบุหรือระบุผิด

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // ทำงานกับพรีเซนเทชันที่ถอดรหัสแล้ว.
} finally {
    presentation.dispose();
}
```

## **ลบการเข้ารหัสจากพรีเซนเทชัน**

โหลดพรีเซนเทชันพร้อมรหัสผ่านเปิดใช้ เรียก [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--) แล้วบันทึกผลลัพธ์ พรีเซนเทชันที่บันทึกแล้วสามารถโหลดได้โดยไม่ต้องใช้รหัสผ่าน

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตรวจสอบรหัสผ่านเปิดใช้ก่อนโหลด**

ใช้ [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) เพื่อรับ [IPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/) โดยไม่ต้องสร้างออบเจกต์พรีเซนเทชันเต็มรูปแบบ ตรวจสอบ [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) ก่อนขอหรือยืนยันรหัสผ่าน เมื่อพบการป้องกัน ให้ตรวจสอบค่าที่ระบุด้วย [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-)

### **เวิร์กโฟลว์แบบไฟล์พาธ**

ตัวอย่างต่อไปนี้ตรวจสอบรหัสผ่านเปิดใช้สำหรับไฟล์ PPTX ส่งค่าที่ตรวจสอบแล้วไปยัง [ILoadOptions.setPassword](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) แล้วโหลดพรีเซนเทชันเต็มรูปแบบ:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;

String filePath = "protected-presentation.pptx";
String password = "open_password";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    System.out.println("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    System.out.println("The opening password is incorrect.");
} else {
    LoadOptions loadOptions = new LoadOptions();
    loadOptions.setPassword(password);

    Presentation presentation = new Presentation(filePath, loadOptions);
    try {
        System.out.println("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **เวิร์กโฟลว์แบบสตรีม**

เมธอด overload ของ [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) ให้เวิร์กโฟลว์เดียวกัน รีเซ็ตตำแหน่งของสตรีมที่รองรับการ seek ก่อนโหลดพรีเซนเทชันเต็มรูปแบบจากสตรีมนั้น

ตัวอย่างต่อไปนี้ใช้ไฟล์ PPT:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import java.io.FileInputStream;

String password = "open_password";

FileInputStream presentationStream = new FileInputStream("protected-presentation.ppt");
try {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(presentationStream);

    if (!presentationInfo.isPasswordProtected()) {
        System.out.println("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        System.out.println("The opening password is incorrect.");
    } else {
        presentationStream.getChannel().position(0);

        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setPassword(password);

        Presentation presentation = new Presentation(presentationStream, loadOptions);
        try {
            System.out.println("The presentation was validated and loaded successfully.");
        } finally {
            presentation.dispose();
        }
    }
} finally {
    presentationStream.close();
}
```

### **ค่าที่คืนจาก checkPassword**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) จะคืนค่า `true` เฉพาะเมื่อพรีเซนเทชันมีรหัสผ่านเปิดใช้และรหัสผ่านที่ระบุถูกต้อง จะคืนค่า `false` ในกรณีต่อไปนี้

- รหัสผ่านไม่ถูกต้อง
- พรีเซนเทชันไม่มีรหัสผ่านเปิดใช้
- รหัสผ่านที่ระบุเป็น `null` หรือเป็นค่าว่าง

พฤติกรรมนี้เหมือนกันสำหรับพรีเซนเทชันแบบ PPT และ PPTX

## **ตรวจสอบว่าพรีเซนเทชันที่โหลดแล้วถูกเข้ารหัสหรือไม่**

หลังจากโหลดพรีเซนเทชันด้วยรหัสผ่านที่ถูกต้อง ให้ตรวจสอบ [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--) เพื่อยืนยันว่าพรีเซนเทชันต้นฉบับถูกเข้ารหัส หากต้องการตรวจจับการป้องกันด้วยรหัสผ่านเปิดใช้ก่อนโหลด ให้ใช้ `IPresentationInfo.isPasswordProtected` ตามที่แสดงข้างต้น

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
    System.out.println("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **คำแนะนำด้านความปลอดภัย**

{{% alert color="warning" title="Security" %}}
อย่าบันทึกรหัสผ่านเปิดใช้ในบันทึกหรือใส่ไว้ในข้อความวินิจฉัย หลีกเลี่ยงการตรวจสอบรหัสผ่านซ้ำโดยไม่จำเป็น เก็บรหัสผ่านในหน่วยความจำไว้เพียงระยะเวลาที่จำเป็นเท่านั้น และใช้ผลลัพธ์การตรวจสอบที่สำเร็จซ้ำเมื่อโหลดพรีเซนเทชันโดยทันที

คุณสมบัติลูกค้าสาธารณะอาจเปิดเผยชื่อผู้เขียน ชื่อเรื่อง หัวข้อ คำสำคัญ ข้อมูลบริษัท ความคิดเห็น และค่าที่กำหนดเองแม้ว่าข้อมูลพรีเซนเทชันจะถูกเข้ารหัสก็ตาม ควรเข้ารหัสเมตาดาต้าที่เป็นประเด็นสำคัญพร้อมกับพรีเซนเทชัน การทำให้คุณสมบัติลูกค้าเป็นสาธารณะควรเป็นการตัดสินใจอย่างชัดเจนและทำเฉพาะเมื่อระบบต้องทำการทำดัชนี จำแนก ค้นหา หรือจัดการไฟล์โดยไม่ต้องใช้รหัสผ่านเปิดใช้
{{% /alert %}}

## **ป้องกันพรีเซนเทชันด้วยรหัสผ่านออนไลน์**

1. เปิดแอปพลิเคชัน [Aspose.Slides Lock](https://products.aspose.app/slides/th/lock)
2. เลือกหรืออัปโหลดพรีเซนเทชัน
3. ป้อนรหัสผ่านสำหรับการป้องกันการดู
4. หากต้องการ ป้อนรหัสผ่านแยกต่างหากสำหรับการป้องกันการแก้ไข
5. ใช้การป้องกันและดาวน์โหลดไฟล์ที่ได้

{{% alert color="info" title="See also" %}}
- [ป้องกันการเขียนพรีเซนเทชัน](/slides/th/androidjava/write-protected-presentation/)
- [ลายเซ็นดิจิทัลใน PowerPoint](/slides/th/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**รหัสผ่านเปิดใช้และรหัสผ่านป้องกันการเขียนแตกต่างกันอย่างไร?**

รหัสผ่านเปิดใช้จะเข้ารหัสพรีเซนเทชันและจำเป็นสำหรับการโหลดเนื้อหา ส่วนรหัสผ่านป้องกันการเขียนจะจำกัดการแก้ไขโดยไม่เข้ารหัสเนื้อหา

**ฉันสามารถตรวจสอบรหัสผ่านเปิดใช้โดยไม่ต้องโหลดสไลด์ทั้งหมดได้หรือไม่?**

ได้ ใช้ข้อมูลพรีเซนเทชัน ตรวจสอบว่ามีการป้องกันด้วยรหัสผ่านเปิดใช้หรือไม่ แล้วตรวจสอบรหัสผ่านก่อนสร้างออบเจกต์พรีเซนเทชันเต็มรูปแบบ

**แอปพลิเคชันสามารถอ่านเมตาดาต้าโดยไม่ต้องใช้รหัสผ่านเปิดใช้ได้หรือไม่?**

ได้ แต่เฉพาะเมื่อพรีเซนเทชันถูกเข้ารหัสโดยปิดการเข้ารหัสคุณสมบัติลูกค้า แอปพลิเคชันต้องใช้โหมดโหลดเฉพาะคุณสมบัติลูกค้าที่อธิบายใน [จัดการคุณสมบัติพรีเซนเทชัน](/slides/th/androidjava/presentation-properties/)

**เวิร์กโฟลว์การตรวจสอบรหัสผ่านสนับสนุนทั้ง PPT และ PPTX หรือไม่?**

สนับสนุน ทั้งเวิร์กโฟลว์แบบไฟล์พาธและแบบสตรีมทำงานเช่นเดียวกันสำหรับพรีเซนเทชันประเภท PPT และ PPTX