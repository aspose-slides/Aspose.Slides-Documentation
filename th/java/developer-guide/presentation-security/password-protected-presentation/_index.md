---
title: ป้องกันการนำเสนอด้วยรหัสผ่านใน Java
linktitle: การป้องกันด้วยรหัสผ่าน
type: docs
weight: 20
url: /th/java/password-protected-presentation/
keywords:
- การนำเสนอที่ป้องกันด้วยรหัสผ่าน
- รหัสผ่านเปิดใช้งาน
- เข้ารหัส PowerPoint
- ถอดรหัส PowerPoint
- ยืนยันรหัสผ่านการนำเสนอ
- ตรวจสอบรหัสผ่านการนำเสนอ
- เปิดการนำเสนอที่เข้ารหัส
- ลบการเข้ารหัส
- PowerPoint
- PPT
- PPTX
- การนำเสนอ
- Java
- Aspose.Slides
description: "เข้ารหัส, ตรวจจับ, ยืนยัน, เปิด, และถอดรหัสการนำเสนอ PowerPoint PPT และ PPTX ที่ป้องกันด้วยรหัสผ่านใน Java ด้วย Aspose.Slides."
---
## **ภาพรวม**

รหัสผ่านเปิดใช้งานจะทำการเข้ารหัสการนำเสนอ ต้องมีรหัสผ่านที่ถูกต้องจึงจะสามารถโหลดและดูเนื้อหาของการนำเสนอได้ ดังนั้นการป้องกันนี้จึงให้ความลับ

รหัสผ่านเปิดใช้งานแตกต่างจากรหัสผ่านป้องกันการเขียน การป้องกันการเขียนจำกัดการแก้ไขแต่ไม่เข้ารหัสเนื้อหาหรือป้องกันการโหลดการนำเสนอ เพื่อจัดการรหัสผ่านสำหรับการแก้ไขการนำเสนอ ดูที่ [ป้องกันการเขียนการนำเสนอ](/slides/th/java/write-protected-presentation/)

ขั้นตอนการทำงานด้านล่างใช้ได้กับการนำเสนอทั้งแบบ PPT และ PPTX ตัวอย่างใช้ทั้งสองรูปแบบเมื่อพิจารณาการทำงานบนไฟล์และสตรีมเป็นสิ่งสำคัญ

## **เข้ารหัสการนำเสนอด้วยรหัสผ่านเปิดใช้งาน**

ใช้ [IProtectionManager.encrypt](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) เพื่อกำหนดรหัสผ่านเปิดใช้งาน จากนั้นใช้ [IPresentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) เพื่อบันทึกการนำเสนอที่เข้ารหัส

ตัวอย่างต่อไปนี้ทำการเข้ารหัสการนำเสนอแบบ PPTX:

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

## **โหลดการนำเสนอที่เข้ารหัส**

ตั้งค่า [ILoadOptions.setPassword](https://reference.aspose.com/slides/th/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) เป็นรหัสผ่านเปิดใช้งานและส่งตัวเลือกเหล่านั้นให้กับ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) ขณะโหลดไฟล์ การโหลดจะล้มเหลือเมื่อจำเป็นต้องใช้รหัสผ่านเปิดใช้งานแต่รหัสผ่านที่ให้มาขาดหรือไม่ถูกต้อง

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // ทำงานกับการนำเสนอที่ถอดรหัสแล้ว.
} finally {
    presentation.dispose();
}
```

## **ลบการเข้ารหัสออกจากการนำเสนอ**

โหลดการนำเสนอพร้อมรหัสผ่านเปิดใช้งาน, เรียกใช้ [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprotectionmanager/#removeEncryption--), และบันทึกผลลัพธ์ การนำเสนอที่บันทึกแล้วสามารถโหลดได้โดยไม่ต้องใช้รหัสผ่าน

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

ใช้ [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) เพื่อรับ [IPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/) โดยไม่ต้องสร้างอินสแตนซ์การนำเสนอเต็มรูปแบบ ตรวจสอบ [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) ก่อนขอหรือยืนยันรหัสผ่าน เมื่อมีการป้องกัน ให้ตรวจสอบค่าที่ให้มาด้วย [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-)

### **กระบวนการทำงานด้วยไฟล์พาธ**

ตัวอย่างต่อไปนี้ตรวจสอบรหัสผ่านเปิดใช้งานสำหรับไฟล์ PPTX, ส่งค่าที่ตรวจสอบแล้วไปยัง [ILoadOptions.setPassword](https://reference.aspose.com/slides/th/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-), แล้วโหลดการนำเสนอเต็มรูปแบบ:

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

### **กระบวนการทำงานด้วยสตรีม**

เวอร์ชันสตรีมของ [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) ให้กระบวนการทำงานเดียวกัน รีเซ็ตตำแหน่งของสตรีมที่สามารถเลื่อนได้ก่อนโหลดการนำเสนอเต็มรูปแบบจากสตรีมนั้น

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

### **ค่าที่ส่งกลับของ checkPassword**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) จะคืนค่า `true` เฉพาะเมื่อการนำเสนอมีรหัสผ่านเปิดใช้งานและรหัสผ่านที่ให้ถูกต้อง จะคืนค่า `false` ในแต่ละกรณีต่อไปนี้:

- รหัสผ่านไม่ถูกต้อง.
- การนำเสนอไม่มีรหัสผ่านเปิดใช้งาน.
- รหัสผ่านที่ให้เป็น `null` หรือว่างเปล่า.

พฤติกรรมนี้เหมือนกันสำหรับการนำเสนอ PPT และ PPTX

## **ตรวจสอบว่าการนำเสนอที่โหลดแล้วถูกเข้ารหัสหรือไม่**

หลังจากโหลดการนำเสนอด้วยรหัสผ่านที่ถูกต้อง ให้ตรวจสอบ [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) เพื่อยืนยันว่าการนำเสนอต้นฉบับถูกเข้ารหัส เพื่อค้นหาการป้องกันด้วยรหัสผ่านเปิดใช้งานก่อนการโหลด ให้ใช้ `IPresentationInfo.isPasswordProtected` ตามที่แสดงด้านบน

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

{{% alert color="warning" title="ความปลอดภัย" %}}
ห้ามบันทึกรหัสผ่านเปิดใช้งานหรือรวมไว้ในข้อความวินิจฉัย หลีกเลี่ยงการพยายามตรวจสอบซ้ำโดยไม่จำเป็น เก็บรหัสผ่านในหน่วยความจำเพียงเท่าที่ต้องการเท่านั้น และนำผลการตรวจสอบที่สำเร็จกลับมาใช้ใหม่เมื่อโหลดการนำเสนอโดยทันที
{{% /alert %}}

## **ป้องกันการนำเสนอด้วยรหัสผ่านออนไลน์**

1. เปิดแอปพลิเคชัน [Aspose.Slides Lock](https://products.aspose.app/slides/th/lock).
2. เลือกหรืออัปโหลดการนำเสนอ.
3. ป้อนรหัสผ่านสำหรับการป้องกันการดู.
4. หากต้องการ สามารถป้อนรหัสผ่านแยกต่างหากสำหรับการป้องกันการแก้ไข.
5. ใช้งานการป้องกันและดาวน์โหลดไฟล์ที่ได้.

{{% alert color="info" title="ดูเพิ่มเติม" %}}
- [ป้องกันการเขียนการนำเสนอ](/slides/th/java/write-protected-presentation/)
- [ลายเซ็นดิจิทัลใน PowerPoint](/slides/th/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างรหัสผ่านเปิดใช้งานและรหัสผ่านป้องกันการเขียนคืออะไร?**

รหัสผ่านเปิดใช้งานทำการเข้ารหัสการนำเสนอและจำเป็นต้องใช้เพื่อโหลดเนื้อหา รหัสผ่านป้องกันการเขียนจำกัดการแก้ไขโดยไม่เข้ารหัสเนื้อหา

**ฉันสามารถตรวจสอบรหัสผ่านเปิดใช้งานโดยไม่โหลดสไลด์ทั้งหมดได้หรือไม่?**

ได้. รับข้อมูลการนำเสนอ ตรวจสอบว่ามีการป้องกันด้วยรหัสผ่านเปิดใช้งานหรือไม่ และตรวจสอบรหัสผ่านก่อนสร้างอินสแตนซ์การนำเสนอเต็มรูปแบบ

**ขั้นตอนการตรวจสอบรหัสผ่านรองรับทั้ง PPT และ PPTX หรือไม่?**

ได้. การตรวจจับและตรวจสอบรหัสผ่านโดยใช้ไฟล์พาธและสตรีมทำงานเช่นเดียวกันสำหรับการนำเสนอ PPT และ PPTX