---
title: การป้องกันการเขียนงานนำเสนอใน Java
linktitle: การป้องกันการเขียน
type: docs
weight: 25
url: /th/java/write-protected-presentation/
keywords:
- การป้องกันการเขียน
- การป้องกันการเขียน PowerPoint
- รหัสผ่านเพื่อแก้ไข
- จำกัดการแก้ไขงานนำเสนอ
- ลบการป้องกันการเขียน
- ตรวจสอบรหัสผ่านการแก้ไข
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ตั้งค่า ตรวจจับ ตรวจสอบ และลบรหัสผ่านการป้องกันการเขียนในงานนำเสนอ PowerPoint PPT และ PPTX โดยใช้ Aspose.Slides สำหรับ Java."
---
## **บทนำ**

รหัสผ่านการป้องกันการเขียนจำกัดการแก้ไขของงานนำเสนอ แต่ไม่ได้เข้ารหัสเนื้อหา ผู้ใช้สามารถโหลดและดูงานนำเสนอที่ถูกป้องกันการเขียนได้โดยไม่ต้องใช้รหัสผ่าน ขึ้นอยู่กับแอปพลิเคชัน ผู้ใช้อาจสามารถแก้ไขเนื้อหาและบันทึกเป็นชื่ออื่นได้ ดังนั้นการป้องกันการเขียนไม่ควรถือเป็นกลไกความลับ

รหัสผ่านการเปิดทำหน้าที่ต่างออกไป: มันเข้ารหัสงานนำเสนอและจำเป็นต้องใช้เพื่อโหลดเนื้อหา หากต้องการเข้ารหัสงานนำเสนอหรือยืนยันรหัสผ่านการเปิด ดูที่ [การป้องกันด้วยรหัสผ่าน](/slides/th/java/password-protected-presentation/).

กระบวนการทำงานในบทความนี้ใช้ได้กับงานนำเสนอทั้ง PPT และ PPTX ตัวอย่างใช้ไฟล์ PPTX; เมื่อบันทึกเป็น PPT ให้ใช้ส่วนขยาย `.ppt` และฟอร์แมตการบันทึก PPT ที่สอดคล้องกัน

## **ตั้งค่าการป้องกันการเขียนบนงานนำเสนอ**

ใช้ [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) เพื่อกำหนดรหัสผ่านสำหรับการแก้ไขงานนำเสนอ การบันทึกงานนำเสนอจะรักษาการตั้งค่าการป้องกันไว้

ตัวอย่างต่อไปนี้ตั้งค่าการป้องกันการเขียนบนงานนำเสนอ PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **โหลดงานนำเสนอที่ป้องกันการเขียน**

เนื่องจากการป้องกันการเขียนไม่เข้ารหัสเนื้อหางานนำเสนอ จึงไม่จำเป็นต้องใช้รหัสผ่านเพื่อโหลดงานนำเสนอ รหัสผ่านมีความสำคัญเฉพาะเมื่อตรวจสอบสิทธิ์การแก้ไขงานนำเสนอที่ได้รับการป้องกัน

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

ห้ามส่งรหัสผ่านการป้องกันการเขียนไปยัง [ILoadOptions.setPassword](https://reference.aspose.com/slides/th/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) วิธีนี้รับรหัสผ่านการเปิดสำหรับเนื้อหาที่เข้ารหัส หากงานนำเสนอมีทั้งสองประเภทของการป้องกัน ให้ใช้รหัสผ่านการเปิดเพื่อโหลดงานและจัดการรหัสผ่านการป้องกันการเขียนแยกต่างหาก

## **ลบการป้องกันการเขียนออกจากงานนำเสนอ**

ใช้ [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) เพื่อลบข้อจำกัดการแก้ไข แล้วบันทึกงานนำเสนอ

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตรวจสอบว่างานนำเสนอถูกป้องกันการเขียนหรือไม่**

เพื่อสำรวจไฟล์โดยไม่ต้องสร้างอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) ฉบับเต็ม ให้เรียก [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) แล้วตรวจสอบ [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--). วิธีนี้ใช้ [NullableBool](https://reference.aspose.com/slides/th/java/com.aspose.slides/nullablebool/) และคืนค่า `NullableBool.True` เมื่อพบการป้องกันการเขียน

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() == NullableBool.True) {
    System.out.println("The presentation is write protected.");
} else {
    System.out.println("Write protection was not detected.");
}
```

เวอร์ชัน overload แบบสตรีมของ [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) ให้ข้อมูลเดียวกันสำหรับงานนำเสนอที่ส่งเป็นสตรีม

## **ตรวจสอบรหัสผ่านการป้องกันการเขียน**

ใช้ [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) เพื่อตรวจสอบรหัสผ่านการแก้ไขโดยไม่ต้องโหลดงานนำเสนอเต็ม ตรวจสอบ [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--) ก่อนเพื่อให้แอปพลิเคชันขอหรือยืนยันรหัสผ่านเฉพาะเมื่อมีการป้องกันการเขียน

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() != NullableBool.True) {
    System.out.println("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    System.out.println("The write-protection password is correct.");
} else {
    System.out.println("The write-protection password is incorrect.");
}
```

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) ตรวจสอบเฉพาะรหัสผ่านการป้องกันการเขียนเท่านั้น ไม่ตรวจสอบรหัสผ่านการเปิดหรือกำหนดว่ามีการโหลดเนื้อหาที่เข้ารหัสได้หรือไม่ ในทางกลับกัน [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) ตรวจสอบเฉพาะรหัสผ่านการเปิด หากงานนำเสนอเต็มได้ถูกโหลดแล้ว [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) จะให้การตรวจสอบการป้องกันการเขียนที่เทียบเท่าผ่านผู้จัดการการป้องกัน

ในแอปพลิเคชันที่ใช้งานจริง อย่าบันทึกรหัสผ่านลงบันทึกหรือใส่ในข้อความการวินิจฉัย หลีกเลี่ยงการตรวจสอบซ้ำโดยไม่จำเป็น และเก็บรหัสผ่านในหน่วยความจำเพียงเท่าที่จำเป็น

{{% alert color="info" title="ดูเพิ่มเติม" %}}
- [การป้องกันด้วยรหัสผ่าน](/slides/th/java/password-protected-presentation/)
- [งานนำเสนอแบบอ่านอย่างเดียว](/slides/th/java/read-only-presentation/)
- [ลายเซ็นดิจิทัลใน PowerPoint](/slides/th/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**การป้องกันการเขียนเข้ารหัสงานนำเสนอหรือไม่?**

ไม่. มันจำกัดการแก้ไขแต่ทำให้เนื้อหางานนำเสนอยังคงพร้อมสำหรับการโหลดและการดู

**จำเป็นต้องใช้รหัสผ่านการป้องกันการเขียนเพื่อเปิดงานนำเสนอหรือไม่?**

ไม่. มีเพียงรหัสผ่านการเปิดที่จำเป็นเพื่อโหลดเนื้อหาที่เข้ารหัสของงานนำเสนอ

**งานนำเสนอสามารถมีรหัสผ่านการเปิดและรหัสผ่านการป้องกันการเขียนพร้อมกันได้หรือไม่?**

ได้. ให้ใส่รหัสผ่านการเปิดผ่านตัวเลือกการโหลดเพื่อเปิดงานนำเสนอที่เข้ารหัส และตรวจสอบรหัสผ่านการป้อนกันการเขียนแยกต่างหากเมื่อจำเป็นต้องมีสิทธิ์การแก้ไข