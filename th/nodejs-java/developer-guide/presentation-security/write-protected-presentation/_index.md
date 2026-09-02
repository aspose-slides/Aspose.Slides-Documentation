---
title: การป้องกันการเขียนงานนำเสนอใน JavaScript
linktitle: การป้องกันการเขียน
type: docs
weight: 25
url: /th/nodejs-java/write-protected-presentation/
keywords:
- การป้องกันการเขียน
- การป้องกันการเขียน PowerPoint
- รหัสผ่านสำหรับแก้ไข
- จำกัดการแก้ไขงานนำเสนอ
- ลบการป้องกันการเขียน
- ตรวจสอบความถูกต้องของรหัสผ่านการแก้ไข
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ตั้งค่า, ตรวจจับ, ตรวจสอบความถูกต้อง, และลบรหัสผ่านการป้องกันการเขียนในงานนำเสนอ PowerPoint PPT และ PPTX โดยใช้ Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **บทนำ**

รหัสผ่านการป้องกันการเขียนจำกัดการแก้ไขงานนำเสนอแต่ไม่ได้เข้ารหัสเนื้อหา ผู้ใช้สามารถโหลดและดูงานนำเสนอที่มีการป้องกันการเขียนโดยไม่ต้องใช้รหัสผ่าน ขึ้นอยู่กับแอปพลิเคชัน พวกเขาอาจสามารถแก้ไขเนื้อหาและบันทึกเป็นชื่ออื่นได้ ดังนั้นการป้องกันการเขียนไม่ควรถือเป็นกลไกความลับ

รหัสผ่านการเปิดใช้งานทำหน้าที่ต่างออกไป: มันเข้ารหัสงานนำเสนอและจำเป็นต้องใช้เพื่อโหลดเนื้อหา เพื่อเข้ารหัสงานนำเสนอหรือยืนยันรหัสผ่านการเปิดใช้งาน ดูที่ [Password-Protect Presentations](/slides/th/nodejs-java/password-protected-presentation/)

ขั้นตอนการทำงานในบทความนี้ใช้ได้กับงานนำเสนอทั้งแบบ PPT และ PPTX ตัวอย่างใช้ไฟล์ PPTX; เมื่อบันทึกเป็น PPT ให้ใช้ส่วนขยาย `.ppt` และรูปแบบการบันทึก PPT ที่สอดคล้องกัน

## **ตั้งการป้องกันการเขียนบนงานนำเสนอ**

ใช้ [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/protectionmanager/#setWriteProtection) เพื่อกำหนดรหัสผ่านสำหรับแก้ไขงานนำเสนอ การบันทึกงานนำเสนอจะคงการตั้งค่าการป้องกันไว้

ตัวอย่างต่อไปนี้ตั้งการป้องกันการเขียนบนงานนำเสนอ PPTX:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **โหลดงานนำเสนอที่มีการป้องกันการเขียน**

เนื่องจากการป้องกันการเขียนไม่ได้เข้ารหัสเนื้อหาของงานนำเสนอ จึงไม่ต้องใช้รหัสผ่านในการโหลดงานนำเสนอ รหัสผ่านมีความสำคัญเฉพาะเมื่อยืนยันการอนุญาตให้แก้ไขงานนำเสนอที่ถูกป้องกันเท่านั้น

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

ห้ามส่งรหัสผ่านการป้องกันการเขียนไปยัง [LoadOptions.setPassword](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#setPassword) เมธอดนั้นรับรหัสผ่านการเปิดใช้งานสำหรับเนื้อหาที่เข้ารหัส หากงานนำเสนอมีประเภทการป้องกันทั้งสอง ให้ส่งรหัสผ่านการเปิดใช้งานเพื่อโหลดงานนำเสนอและจัดการรหัสผ่านการป้องกันการเขียนแยกต่างหาก

## **ลบการป้องกันการเขียนออกจากงานนำเสนอ**

ใช้ [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/protectionmanager/#removeWriteProtection) เพื่อลบข้อจำกัดการแก้ไข แล้วบันทึกงานนำเสนอ

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตรวจสอบว่างานนำเสนอถูกป้องกันการเขียนหรือไม่**

เพื่อตรวจสอบไฟล์โดยไม่ต้องสร้างอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) ที่สมบูรณ์ ให้เรียก [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) และตรวจสอบ [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected) เมธอดนี้ใช้ [NullableBool](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/nullablebool/) และคืนค่า `NullableBool.True` เมื่อพบการป้องกันการเขียน

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() === slides.NullableBool.True) {
    console.log("The presentation is write protected.");
} else {
    console.log("Write protection was not detected.");
}
```

เมธอดแบบสตรีมของ [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) ให้ข้อมูลเดียวกันสำหรับงานนำเสนอที่ส่งมาเป็นสตรีมอ่านได้ของ Node.js

## **ตรวจสอบความถูกต้องของรหัสผ่านการป้องกันการเขียน**

ใช้ [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) เพื่อตรวจสอบรหัสผ่านการแก้ไขโดยไม่ต้องโหลดงานนำเสนอเต็มรูปแบบ ตรวจสอบ [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected) ก่อนเพื่อให้แอปพลิเคชันร้องขอหรือยืนยันรหัสผ่านเฉพาะเมื่อมีการป้องกันการเขียน

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() !== slides.NullableBool.True) {
    console.log("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    console.log("The write-protection password is correct.");
} else {
    console.log("The write-protection password is incorrect.");
}
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) ตรวจสอบเพียงรหัสผ่านการป้องกันการเขียนเท่านั้น มันไม่ตรวจสอบรหัสผ่านการเปิดใช้งานหรือกำหนดว่าภาพเนื้อหาที่เข้ารหัสสามารถโหลดได้หรือไม่ ในทางกลับกัน [PresentationInfo.checkPassword](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/#checkPassword) ตรวจสอบเพียงรหัสผ่านการเปิดใช้งาน หากงานนำเสนอเต็มรูปแบบได้ถูกโหลดแล้ว [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/protectionmanager/#checkWriteProtection) ให้การตรวจสอบการป้องกันการเขียนที่เทียบเท่าผ่านตัวจัดการการป้องกันของมัน

ในแอปพลิเคชันที่ใช้งานจริง ไม่ควรบันทึกรหัสผ่านหรือใส่ไว้ในข้อความวินิจฉัย หลีกเลี่ยงการตรวจสอบซ้ำโดยไม่จำเป็น และเก็บรหัสผ่านในหน่วยความจำเฉพาะระยะเวลาที่จำเป็นเท่านั้น

{{% alert color="info" title="ดูเพิ่มเติม" %}}
- [การป้องกันงานนำเสนอด้วยรหัสผ่าน](/slides/th/nodejs-java/password-protected-presentation/)
- [งานนำเสนอแบบอ่านอย่างเดียว](/slides/th/nodejs-java/read-only-presentation/)
- [ลายเซ็นดิจิทัลใน PowerPoint](/slides/th/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**การป้องกันการเขียนเข้ารหัสงานนำเสนอหรือไม่?**  
ไม่. มันจำกัดการแก้ไขแต่ยังทำให้เนื้อหาของงานนำเสนอพร้อมสำหรับการโหลดและการดู

**รหัสผ่านการป้องกันการเขียนจำเป็นต้องใช้เพื่อเปิดงานนำเสนอหรือไม่?**  
ไม่. มีเพียงรหัสผ่านการเปิดใช้งานที่จำเป็นเพื่อโหลดเนื้อหาที่เข้ารหัสของงานนำเสนอ

**งานนำเสนอสามารถมีทั้งรหัสผ่านการเปิดใช้งานและรหัสผ่านการป้องกันการเขียนได้หรือไม่?**  
ได้. ให้ส่งรหัสผ่านการเปิดใช้งานผ่านตัวเลือกการโหลดเพื่อเปิดงานนำเสนอที่เข้ารหัส และตรวจสอบรหัสผ่านการป้องกันการเขียนแยกต่างหากเมื่อจำเป็นต้องได้รับอนุญาตการแก้ไข