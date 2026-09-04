---
title: ปกป้องงานนำเสนอด้วยรหัสผ่านใน Java
linktitle: การป้องกันด้วยรหัสผ่าน
type: docs
weight: 20
url: /th/java/password-protected-presentation/
keywords:
- งานนำเสนอที่ป้องกันด้วยรหัสผ่าน
- รหัสผ่านเปิดใช้งาน
- เข้ารหัส PowerPoint
- ถอดรหัส PowerPoint
- ตรวจสอบความถูกต้องของรหัสผ่านงานนำเสนอ
- ตรวจสอบรหัสผ่านงานนำเสนอ
- เปิดงานนำเสนอที่เข้ารหัส
- ลบการเข้ารหัส
- PowerPoint
- PPT
- PPTX
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เข้ารหัส, ตรวจจับ, ตรวจสอบความถูกต้อง, เปิด และถอดรหัสงานนำเสนอ PowerPoint PPT และ PPTX ที่ป้องกันด้วยรหัสผ่านใน Java ด้วย Aspose.Slides."
---
## **ภาพรวม**

รหัสผ่านเปิดใช้งานจะทำการเข้ารหัสงานนำเสนอ รหัสผ่านที่ถูกต้องจำเป็นต้องใช้ในการโหลดและดูเนื้อหาของงานนำเสนอ ดังนั้นการป้องกันนี้จึงให้ความลับของข้อมูล

รหัสผ่านเปิดใช้งานแตกต่างจากรหัสผ่านป้องกันการเขียน การป้องกันการเขียนจำกัดการแก้ไขแต่ไม่ทำการเข้ารหัสเนื้อหาหรือป้องกันไม่ให้โหลดงานนำเสนอ หากต้องการจัดการรหัสผ่านสำหรับการแก้ไขงานนำเสนอ ดูที่ [ป้องกันการเขียนงานนำเสนอ](/slides/th/java/write-protected-presentation/)

ขั้นตอนการทำงานด้านล่างนี้ใช้ได้กับงานนำเสนอทั้งแบบ PPT และ PPTX ตัวอย่างใช้ทั้งสองรูปแบบเมื่อพฤติกรรมตามไฟล์และสตรีมมีความสำคัญ

## **เข้ารหัสงานนำเสนอด้วยรหัสผ่านเปิดใช้งาน**

ใช้ [IProtectionManager.encrypt](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) เพื่อกำหนดรหัสผ่านเปิดใช้งาน แล้วใช้ [IPresentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) เพื่อบันทึกงานนำเสนอที่เข้ารหัสแล้ว

ตัวอย่างต่อไปนี้เข้ารหัสงานนำเสนอ PPTX:

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

## **ทำให้คุณสมบัติของเอกสารเป็นสาธารณะ**

โดยค่าเริ่มต้น Aspose.Slides จะรวมคุณสมบัติของเอกสารในกระบวนการเข้ารหัสงานนำเสนอ วิธีการ [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) ควบคุมพฤติกรรมนี้อย่างอิสระจากการเข้ารหัสเนื้อหาสไลด์ ให้ส่งค่า `false` ก่อนเรียก [IProtectionManager.encrypt](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) เมื่อระบบการทำดัชนี การจำแนกประเภท การค้นหา หรือการจัดการเอกสารต้องอ่านข้อมูลเมตาโดยไม่ต้องใช้รหัสผ่านเปิดใช้งาน

ตัวอย่างต่อไปนี้สร้างงานนำเสนอ PPTX ที่เข้ารหัสพร้อมทิ้งคุณสมบัติของเอกสารในตัวให้เป็นสาธารณะ:

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

การส่งค่า `false` ไปยัง [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) ไม่ทำให้สไลด์ มาสเตอร์ การจัดเรียง รูปร่าง สื่อ หรืองานนำเสนอส่วนอื่นเป็นสาธารณะ จะส่งผลต่อเพียงคุณสมบัติของเอกสารเท่านั้น หากต้องอ่านคุณสมบัติเหล่านี้โดยไม่โหลดเนื้อหาที่เข้ารหัส ให้ดูที่ [จัดการคุณสมบัติงานนำเสนอ](/slides/th/java/presentation-properties/)

## **โหลดงานนำเสนอที่เข้ารหัส**

ตั้งค่า [ILoadOptions.setPassword](https://reference.aspose.com/slides/th/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) ให้เป็นรหัสผ่านเปิดใช้งานและส่งออปชันเหล่านั้นไปยังคอนสตรัคเตอร์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) เมื่อทำการโหลดไฟล์ การโหลดจะล้มเหลวเมื่อจำเป็นต้องใช้รหัสผ่านเปิดใช้งานแต่ไม่ได้ระบุหรือระบุผิด

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // ทำงานกับงานนำเสนอที่ถอดรหัสแล้ว.
} finally {
    presentation.dispose();
}
```

## **ลบการเข้ารหัสออกจากงานนำเสนอ**

โหลดงานนำเสนอพร้อมรหัสผ่านเปิดใช้งาน เรียก [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprotectionmanager/#removeEncryption--) แล้วบันทึกผลลัพธ์ งานนำเสนอที่บันทึกแล้วสามารถโหลดได้โดยไม่มีรหัสผ่าน

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

## **ตรวจสอบรหัสผ่านเปิดใช้งานก่อนการโหลด**

ใช้ [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) เพื่อรับ [IPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/) โดยไม่ต้องสร้างอินสแตนซ์งานนำเสนอเต็มรูปแบบ ตรวจสอบ [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) ก่อนขอหรือยืนยันรหัสผ่าน เมื่อพบว่ามีการป้องกัน ให้ตรวจสอบค่าที่ให้โดยใช้ [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-)

### **ขั้นตอนทำงานโดยใช้ไฟล์พาธ**

ตัวอย่างต่อไปนี้ตรวจสอบรหัสผ่านเปิดใช้งานสำหรับไฟล์ PPTX ส่งค่าที่ตรวจสอบแล้วไปยัง [ILoadOptions.setPassword](https://reference.aspose.com/slides/th/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) แล้วโหลดงานนำเสนอเต็มรูปแบบ:

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

### **ขั้นตอนทำงานโดยใช้สตรีม**

อิมพอร์ตของสตรีมสำหรับ [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) ให้กระบวนการเดียวกัน รีเซ็ตตำแหน่งของสตรีมที่สามารถ seek ได้ก่อนโหลดงานนำเสนอเต็มรูปแบบจากสตรีมนั้น

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

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) จะคืนค่า `true` เท่านั้นเมื่องานนำเสนอมีรหัสผ่านเปิดใช้งานและรหัสผ่านที่ให้มาตรงกัน มิฉะนั้นจะคืนค่า `false` ในกรณีต่อไปนี้

- รหัสผ่านไม่ถูกต้อง
- งานนำเสนอไม่มีรหัสผ่านเปิดใช้งาน
- รหัสผ่านที่ให้เป็น `null` หรือว่างเปล่า

พฤติกรรมนี้เหมือนกันสำหรับงานนำเสนอ PPT และ PPTX

## **ตรวจสอบว่างานนำเสนอที่โหลดแล้วถูกเข้ารหัสหรือไม่**

หลังจากโหลดงานนำเสนอด้วยรหัสผ่านที่ถูกต้อง ให้ตรวจสอบ [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) เพื่อยืนยันว่าต้นฉบับงานนำเสนอถูกเข้ารหัส การตรวจจับการป้องกันด้วยรหัสผ่านเปิดใช้งานก่อนการโหลดสามารถทำได้โดยใช้ `IPresentationInfo.isPasswordProtected` ตามที่แสดงด้านบน

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
ห้ามบันทึกรหัสผ่านเปิดใช้งานในล็อกหรือใส่ไว้ในข้อความวินิจฉัย หลีกเลี่ยงการลองตรวจสอบรหัสผ่านซ้ำโดยไม่จำเป็น เก็บรหัสผ่านในหน่วยความจำเฉพาะช่วงที่ต้องใช้เท่านั้น และใช้ผลลัพธ์การตรวจสอบที่สำเร็จแล้วใหม่เมื่อต้องโหลดงานนำเสนอโดยทันที

คุณสมบัติของเอกสารสาธารณะอาจเปิดเผยชื่อผู้เขียน หัวข้อ รายวิชา คำสำคัญ ข้อมูลบริษัท ความคิดเห็น และค่าที่กำหนดเอง แม้งานนำเสนอจะถูกเข้ารหัสแล้วก็ตาม ควรเข้ารหัสเมตาดาต้าที่สำคัญพร้อมกับงานนำเสนอ การทำให้คุณสมบัติสาธารณะควรเป็นการตัดสินใจอย่างชัดเจนเมื่อระบบต้องทำการทำดัชนี จำแนกประเภท ค้นหา หรือจัดการไฟล์โดยไม่ต้องใช้รหัสผ่านเปิดใช้งาน
{{% /alert %}}

## **ป้องกันงานนำเสนอด้วยรหัสผ่านออนไลน์**

1. เปิดแอปพลิเคชัน [Aspose.Slides Lock](https://products.aspose.app/slides/th/lock)
2. เลือกหรืออัปโหลดงานนำเสนอ
3. ป้อนรหัสผ่านสำหรับการป้องกันการดู
4. หากต้องการ ป้อนรหัสผ่านแยกต่างหากสำหรับการป้องกันการแก้ไข
5. ใช้การป้องกันและดาวน์โหลดไฟล์ที่ได้

{{% alert color="info" title="See also" %}}
- [ป้องกันการเขียนงานนำเสนอ](/slides/th/java/write-protected-presentation/)
- [ลายเซ็นดิจิทัลใน PowerPoint](/slides/th/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**รหัสผ่านเปิดใช้งานและรหัสผ่านป้องกันการเขียนแตกต่างกันอย่างไร?**

รหัสผ่านเปิดใช้งานทำการเข้ารหัสงานนำเสนอและจำเป็นต้องใช้ในการโหลดเนื้อหา ส่วนรหัสผ่านป้องกันการเขียนจำกัดการแก้ไขโดยไม่ต้องเข้ารหัสเนื้อหา

**ฉันสามารถตรวจสอบรหัสผ่านเปิดใช้งานโดยไม่ต้องโหลดสไลด์ทั้งหมดได้หรือไม่?**

ได้ โดยการรับข้อมูลงานนำเสนอ ตรวจสอบว่ามีการป้องกันด้วยรหัสผ่านเปิดใช้งานหรือไม่ และตรวจสอบรหัสผ่านก่อนสร้างอินสแตนซ์งานนำเสนอเต็มรูปแบบ

**แอปพลิเคชันสามารถอ่านเมตาดาต้าโดยไม่ต้องใช้รหัสผ่านเปิดใช้งานได้หรือไม่?**

ได้ แต่เฉพาะเมื่อการเข้ารหัสงานนำเสนอทำโดยปิดการเข้ารหัสคุณสมบัติของเอกสาร ระบบต้องใช้โหมดการโหลดเฉพาะคุณสมบัติของเอกสารตามที่อธิบายใน [จัดการคุณสมบัติงานนำเสนอ](/slides/th/java/presentation-properties/)

**ขั้นตอนตรวจสอบรหัสผ่านทำงานกับ PPT และ PPTX ทั้งสองประเภทหรือไม่?**

ทำงานได้ ทั้งการตรวจจับและการตรวจสอบด้วยไฟล์พาธและสตรีมทำงานแบบเดียวกันสำหรับงานนำเสนอ PPT และ PPTX