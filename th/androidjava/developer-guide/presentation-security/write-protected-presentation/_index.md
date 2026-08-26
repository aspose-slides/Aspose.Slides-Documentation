---
title: การป้องกันการเขียนพรีเซนเทชันบน Android
linktitle: การป้องกันการเขียน
type: docs
weight: 25
url: /th/androidjava/write-protected-presentation/
keywords:
- การป้องกันการเขียน
- PowerPoint ป้องกันการเขียน
- รหัสผ่านสำหรับแก้ไข
- จำกัดการแก้ไขพรีเซนเทชัน
- ลบการป้องกันการเขียน
- ตรวจสอบรหัสผ่านการแก้ไข
- PowerPoint
- พรีเซนเทชัน
- Android
- Java
- Aspose.Slides
description: "ตั้งค่า, ตรวจจับ, ยืนยันและลบรหัสผ่านการป้องกันการเขียนในพรีเซนเทชัน PowerPoint PPT และ PPTX โดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **บทนำ**

รหัสผ่านการป้องกันการเขียนจำกัดการแก้ไขพรีเซนเทชัน แต่ไม่ได้เข้ารหัสเนื้อหา ผู้ใช้สามารถโหลดและดูพรีเซนเทชันที่ถูกป้องกันการเขียนได้โดยไม่ต้องใช้รหัสผ่าน ขึ้นอยู่กับแอปพลิเคชัน พวกเขาอาจสามารถแก้ไขเนื้อหาและบันทึกเป็นชื่ออื่นได้ ดังนั้นการป้องกันการเขียนไม่ควรถือเป็นกลไกความลับ.

รหัสผ่านการเปิดทำหน้าที่ต่างออกไป: มันเข้ารหัสพรีเซนเทชันและจำเป็นต้องใช้เพื่อโหลดเนื้อหา เพื่อเข้ารหัสพรีเซนเทชันหรือยืนยันรหัสผ่านการเปิด ดูที่ [Password-Protect Presentations](/slides/th/androidjava/password-protected-presentation/).

ขั้นตอนการทำงานในบทความนี้ใช้ได้กับพรีเซนเทชันทั้งแบบ PPT และ PPTX ตัวอย่างใช้ไฟล์ PPTX; เมื่อบันทึกเป็น PPT ให้ใช้ส่วนขยาย `.ppt` และรูปแบบการบันทึก PPT ที่สอดคล้องกัน.

## **ตั้งการป้องกันการเขียนบนพรีเซนเทชัน**

ใช้ [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) เพื่อตั้งรหัสผ่านสำหรับการแก้ไขพรีเซนเทชัน การบันทึกพรีเซนเทชันจะทำให้การตั้งค่าการป้องกันคงอยู่.

ตัวอย่างต่อไปนี้ตั้งการป้องกันการเขียนบนพรีเซนเทชัน PPTX:

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

## **โหลดพรีเซนเทชันที่ป้องกันการเขียน**

เนื่องจากการป้องกันการเขียนไม่ได้เข้ารหัสเนื้อหาพรีเซนเทชัน จึงไม่จำเป็นต้องใช้รหัสผ่านเพื่อโหลดพรีเซนเทชัน รหัสผ่านเกี่ยวข้องเฉพาะเมื่อตรวจสอบสิทธิ์ในการแก้ไขพรีเซนเทชันที่ถูกป้องกัน.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

อย่าส่งรหัสผ่านการป้องกันการเขียนไปที่ [ILoadOptions.setPassword](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) วิธีนี้รับรหัสผ่านการเปิดสำหรับเนื้อหาที่เข้ารหัส หากพรีเซนเทชันมีทั้งสองประเภทของการป้องกัน ให้ส่งรหัสผ่านการเปิดเพื่อโหลดและจัดการรหัสผ่านการป้องกันการเขียนแยกกัน.

## **ลบการป้องกันการเขียนออกจากพรีเซนเทชัน**

ใช้ [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) เพื่อลบข้อจำกัดการแก้ไข แล้วบันทึกพรีเซนเทชัน.

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

## **ตรวจสอบว่าพรีเซนเทชันได้รับการป้องกันการเขียนหรือไม่**

เพื่อตรวจสอบไฟล์โดยไม่ต้องสร้างอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) อย่างครบถ้วน ให้เรียก [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) และตรวจสอบ [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--). วิธีนี้ใช้ [NullableBool](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/nullablebool/) และคืนค่า `NullableBool.True` เมื่อพบการป้องกันการเขียน.

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

อีกรูปแบบที่รับสตรีมของ [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) ให้ข้อมูลเดียวกันสำหรับพรีเซนเทชันที่ถูกส่งเป็นสตรีม.

## **ตรวจสอบรหัสผ่านการป้องกันการเขียน**

ใช้ [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) เพื่อตรวจสอบรหัสผ่านการแก้ไขโดยไม่ต้องโหลดพรีเซนเทชันเต็ม ตรวจสอบ [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--) ก่อน เพื่อให้แอปพลิเคชันร้องขอหรือยืนยันรหัสผ่านเฉพาะเมื่อมีการป้องกันการเขียน.

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

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) ตรวจสอบเฉพาะรหัสผ่านการป้องกันการเขียนเท่านั้น ไม่ได้ตรวจสอบรหัสผ่านการเปิดหรือกำหนดว่าข้อมูลที่เข้ารหัสสามารถโหลดได้หรือไม่ ในทางกลับกัน [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) ตรวจสอบเฉพาะรหัสผ่านการเปิด หากพรีเซนเทชันเต็มได้ถูกโหลดแล้ว [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) จะให้การตรวจสอบการป้องกันการเขียนในลักษณะเทียบเท่าผ่านผู้จัดการการป้องกัน.

ในแอปพลิเคชันจริง อย่าบันทึกรหัสผ่านลงบันทึกหรือรวมไว้ในข้อความวินิจฉัย หลีกเลี่ยงการทดลองตรวจสอบซ้ำโดยไม่จำเป็น และเก็บรหัสผ่านในหน่วยความจำเพียงเท่าที่ต้องการ.

{{% alert color="info" title="ดูเพิ่มเติม" %}}
- [Password-Protect Presentations](/slides/th/androidjava/password-protected-presentation/)
- [Read-Only Presentations](/slides/th/androidjava/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/th/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**การป้องกันการเขียนเข้ารหัสพรีเซนเทชันหรือไม่?**

ไม่มี. มันจำกัดการแก้ไขแต่ทำให้เนื้อหาพรีเซนเทชันยังคงสามารถโหลดและดูได้.

**รหัสผ่านการป้องกันการเขียนจำเป็นต้องใช้เพื่อเปิดพรีเซนเทชันหรือไม่?**

ไม่มี. จะต้องใช้รหัสผ่านการเปิดเท่านั้นเพื่อโหลดเนื้อหาพรีเซนเทชันที่เข้ารหัส.

**พรีเซนเทชันสามารถมีรหัสผ่านการเปิดและรหัสผ่านการป้องกันการเขียนพร้อมกันได้หรือไม่?**

ได้. ส่งรหัสผ่านการเปิดผ่านตัวเลือกการโหลดเพื่อเปิดพรีเซนเทชันที่เข้ารหัส และตรวจสอบรหัสผ่านการป้องกันการเขียนแยกต่างหากเมื่อจำเป็นต้องได้รับสิทธิ์การแก้ไข.