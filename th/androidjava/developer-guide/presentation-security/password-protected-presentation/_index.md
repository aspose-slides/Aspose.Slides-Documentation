---
title: ป้องกันการนำเสนอด้วยรหัสผ่านบน Android
linktitle: การป้องกันรหัสผ่าน
type: docs
weight: 20
url: /th/androidjava/password-protected-presentation/
keywords:
- การนำเสนอที่ป้องกันด้วยรหัสผ่าน
- รหัสผ่านเปิด
- เข้ารหัส PowerPoint
- ถอดรหัส PowerPoint
- ตรวจสอบความถูกต้องของรหัสผ่านการนำเสนอ
- ตรวจสอบรหัสผ่านการนำเสนอ
- เปิดการนำเสนอที่เข้ารหัส
- ลบการเข้ารหัส
- PowerPoint
- PPT
- PPTX
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เข้ารหัส, ตรวจจับ, ตรวจสอบความถูกต้อง, เปิดและถอดรหัสการนำเสนอ PowerPoint PPT และ PPTX ที่ป้องกันด้วยรหัสผ่านด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

รหัสผ่านเปิดทำให้การนำเสนอถูกเข้ารหัส จำเป็นต้องใช้รหัสผ่านที่ถูกต้องเพื่อโหลดและดูเนื้อหาการนำเสนอ ดังนั้นการป้องกันนี้ช่วยให้ข้อมูลเป็นความลับ

รหัสผ่านเปิดแตกต่างจากรหัสผ่านป้องกันการเขียน การป้องกันการเขียนจำกัดการแก้ไขแต่ไม่ได้เข้ารหัสเนื้อหาหรือป้องกันการนำเสนอจากการโหลด หากต้องการจัดการรหัสผ่านสำหรับการแก้ไขการนำเสนอ ดูที่ [Write-Protect Presentations](/slides/th/androidjava/write-protected-presentation/)

ขั้นตอนการทำงานด้านล่างใช้ได้กับการนำเสนอทั้งรูปแบบ PPT และ PPTX ตัวอย่างใช้ทั้งสองรูปแบบเมื่อพฤติกรรมตามไฟล์และสตรีมมีความสำคัญ

## **เข้ารหัสการนำเสนอด้วยรหัสผ่านเปิด**

ใช้ [IProtectionManager.encrypt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) เพื่อตั้งรหัสผ่านเปิด แล้วใช้ [IPresentation.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) เพื่อบันทึกการนำเสนอที่ถูกเข้ารหัส

ตัวอย่างต่อไปนี้เข้ารหัสการนำเสนอ PPTX:

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

## **โหลดการนำเสนอที่ถูกเข้ารหัส**

ตั้งค่า [ILoadOptions.setPassword](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) เป็นรหัสผ่านเปิดและส่งตัวเลือกนี้ไปยัง [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) เมื่อโหลดไฟล์ การโหลดจะล้มเหลือเมื่อต้องการรหัสผ่านเปิดแต่ไม่ได้กำหนดหรือกำหนดไม่ถูกต้อง

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

โหลดการนำเสนอพร้อมรหัสผ่านเปิด เรียกใช้ [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--) แล้วบันทึกผล การนำเสนอที่บันทึกแล้วสามารถโหลดได้โดยไม่ต้องใช้รหัสผ่าน

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

## **ตรวจสอบรหัสผ่านเปิดก่อนการโหลด**

ใช้ [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) เพื่อรับ [IPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/) โดยไม่ต้องสร้างอินสแตนซ์การนำเสนอเต็มรูปแบบ ตรวจสอบ [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) ก่อนขอหรือยืนยันรหัสผ่าน เมื่อมีการป้องกัน ให้ตรวจสอบค่าที่ส่งด้วย [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-)

### **ขั้นตอนทำงานโดยใช้เส้นทางไฟล์**

ตัวอย่างต่อไปนี้ตรวจสอบรหัสผ่านเปิดสำหรับไฟล์ PPTX ส่งค่าที่ตรวจสอบแล้วไปยัง [ILoadOptions.setPassword](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) แล้วโหลดการนำเสนอเต็มรูปแบบ:

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

การโอเวอร์โหลดสตรีมของ [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) ให้ขั้นตอนทำงานเดียวกัน รีเซ็ตตำแหน่งของสตรีมที่สามารถเลื่อนได้ก่อนโหลดการนำเสนอเต็มรูปแบบจากสตรีมนั้น

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

### **ค่า Return ของ checkPassword**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) จะคืนค่า `true` ก็ต่อเมื่อการนำเสนอมีรหัสผ่านเปิดและรหัสที่ให้มาถูกต้อง จะคืนค่า `false` ในกรณีต่อไปนี้

- รหัสผ่านไม่ถูกต้อง
- การนำเสนอไม่มีรหัสผ่านเปิด
- รหัสที่ให้เป็น `null` หรือว่างเปล่า

พฤติกรรมนี้เหมือนกันสำหรับการนำเสนอ PPT และ PPTX

## **ตรวจสอบว่าการนำเสนอที่โหลดแล้วถูกเข้ารหัสหรือไม่**

หลังจากโหลดการนำเสนอด้วยรหัสผ่านที่ถูกต้อง ให้ตรวจสอบ [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--) เพื่อยืนยันว่าการนำแหล่งที่มาถูกเข้ารหัส หากต้องการตรวจจับการป้องกันรหัสผ่านเปิดก่อนการโหลด ให้ใช้ `IPresentationInfo.isPasswordProtected` ตามที่แสดงด้านบน

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
อย่าเก็บบันทึกรหัสผ่านเปิดหรือใส่รหัสผ่านในข้อความวินิจฉัย หลีกเลี่ยงการตรวจสอบซ้ำโดยไม่จำเป็น เก็บรหัสผ่านในหน่วยความจำเฉพาะช่วงที่ต้องใช้เท่านั้น และใช้ผลการตรวจสอบที่สำเร็จซ้ำเมื่อโหลดการนำเสนอโดยทันที
{{% /alert %}}

## **ป้องกันการนำเสนอด้วยรหัสผ่านออนไลน์**

1. เปิดแอปพลิเคชัน [Aspose.Slides Lock](https://products.aspose.app/slides/th/lock)
2. เลือกหรืออัปโหลดการนำเสนอ
3. ป้อนรหัสผ่านสำหรับการป้องกันการดู
4. หากต้องการ สามารถป้อนรหัสผ่านแยกต่างหากสำหรับการป้องกันการแก้ไข
5. ใช้การป้องกันและดาวน์โหลดไฟล์ที่ได้

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/th/androidjava/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/th/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**รหัสผ่านเปิดและรหัสผ่านป้องกันการเขียนต่างกันอย่างไร?**

รหัสผ่านเปิดทำให้การนำเสนอถูกเข้ารหัสและจำเป็นต้องใช้เพื่อโหลดเนื้อหา ส่วนรหัสผ่านป้องกันการเขียนจำกัดการแก้ไขโดยไม่เข้ารหัสเนื้อหา

**ฉันสามารถตรวจสอบรหัสผ่านเปิดโดยไม่ต้องโหลดสไลด์ทั้งหมดได้หรือไม่?**

ได้ สามารถรับข้อมูลการนำเสนอ ตรวจสอบว่ามีการป้องกันรหัสผ่านเปิดหรือไม่ และตรวจสอบรหัสผ่านก่อนสร้างอินสแตนซ์การนำเสนอเต็มรูปแบบ

**ขั้นตอนการตรวจสอบรหัสผ่านทำงานกับทั้ง PPT และ PPTX หรือไม่?**

ทำงานได้ทั้งคู่ การตรวจจับและตรวจสอบรหัสผ่านโดยใช้เส้นทางไฟล์หรือสตรีมทำงานเช่นเดียวกันสำหรับการนำเสนอ PPT และ PPTX