---
title: ปกป้องการนำเสนอด้วยรหัสผ่านใน JavaScript
linktitle: การป้องกันด้วยรหัสผ่าน
type: docs
weight: 20
url: /th/nodejs-java/password-protected-presentation/
keywords:
- การนำเสนอที่มีการป้องกันด้วยรหัสผ่าน
- รหัสผ่านเปิดใช้งาน
- เข้ารหัส PowerPoint
- ถอดรหัส PowerPoint
- ตรวจสอบรหัสผ่านการนำเสนอ
- เช็ครหัสผ่านการนำเสนอ
- เปิดการนำเสนอที่เข้ารหัส
- ลบการเข้ารหัส
- PowerPoint
- PPT
- PPTX
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เข้ารหัส, ตรวจจับ, ตรวจสอบ, เปิด, และถอดรหัสการนำเสนอ PowerPoint PPT และ PPTX ที่มีการป้องกันด้วยรหัสผ่านใน JavaScript ด้วย Aspose.Slides."
---
## **ภาพรวม**

รหัสผ่านเปิดใช้งานจะทำการเข้ารหัสการนำเสนอ รหัสผ่านที่ถูกต้องจำเป็นต้องใช้ในการโหลดและดูเนื้อหาการนำเสนอ ดังนั้นการป้องกันนี้จึงให้ความลับ

รหัสผ่านเปิดใช้งานจะแตกต่างจากรหัสผ่านการป้องกันการเขียน การป้องกันการเขียนจำกัดการแก้ไขแต่ไม่ได้เข้ารหัสเนื้อหา หรือป้องกันไม่ให้การนำเสนอถูกโหลด เพื่อจัดการรหัสผ่านสำหรับการแก้ไขการนำเสนอ ดูที่ [Write-Protect Presentations](/slides/th/nodejs-java/write-protected-presentation/).

เวิร์กโฟลว์ด้านล่างใช้ได้กับการนำเสนอทั้งรูปแบบ PPT และ PPTX ตัวอย่างใช้ทั้งสองรูปแบบเมื่อพฤติกรรมที่อิงไฟล์และสตรีมสำคัญ

## **เข้ารหัสการนำเสนอด้วยรหัสผ่านเปิดใช้งาน**

ใช้ [ProtectionManager.encrypt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/protectionmanager/#encrypt) เพื่อกำหนดรหัสผ่านเปิดใช้งาน แล้วใช้ [Presentation.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#save) เพื่อบันทึกการนำเสนอที่เข้ารหัส

ตัวอย่างต่อไปนี้เข้ารหัสการนำเสนอ PPTX:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **โหลดการนำเสนอที่เข้ารหัส**

ตั้งค่า [LoadOptions.setPassword](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#setPassword) ให้เป็นรหัสผ่านเปิดใช้งานและส่งออปชันนี้ไปยัง [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) เมื่อโหลดไฟล์ การโหลดจะล้มเหลือเมื่อต้องการรหัสผ่านเปิดใช้งานแต่รหัสที่ให้มาขาดหายหรือไม่ถูกต้อง

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // ทำงานกับการนำเสนอที่ถอดรหัสแล้ว.
} finally {
    presentation.dispose();
}
```

## **ลบการเข้ารหัสจากการนำเสนอ**

โหลดการนำเสนอพร้อมรหัสผ่านเปิดใช้งานเรียกใช้ [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/protectionmanager/#removeEncryption) แล้วบันทึกผลลัพธ์ การนำเสนอที่บันทึกแล้วสามารถโหลดได้โดยไม่ต้องใช้รหัสผ่าน

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตรวจสอบรหัสผ่านเปิดใช้งานก่อนโหลด**

ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) เพื่อดึง [PresentationInfo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/) โดยไม่ต้องสร้างอินสแตนซ์การนำเสนอเต็ม ตรวจสอบ [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) ก่อนขอหรือการตรวจสอบรหัสผ่าน เมื่อมีการป้องกัน ให้ตรวจสอบค่าที่ให้ด้วย [PresentationInfo.checkPassword](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/#checkPassword)

### **เวิร์กโฟลว์แบบไฟล์พาธ**

ตัวอย่างต่อไปนี้ตรวจสอบรหัสผ่านเปิดใช้งานสำหรับไฟล์ PPTX ส่งค่าที่ตรวจสอบแล้วไปยัง [LoadOptions.setPassword](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#setPassword) แล้วโหลดการนำเสนอเต็ม:

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "protected-presentation.pptx";
const password = "open_password";
const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    console.log("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    console.log("The opening password is incorrect.");
} else {
    const loadOptions = new slides.LoadOptions();
    loadOptions.setPassword(password);

    const presentation = new slides.Presentation(filePath, loadOptions);
    try {
        console.log("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **เวิร์กโฟลว์สตรีม**

ใช้ [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) เพื่อตรวจสอบสตรีมอ่านของ Node.js หลังจากสตรีมตรวจสอบถูกใช้งานแล้ว สร้างสตรีมใหม่ก่อนโหลดการนำเสนอเต็มด้วย [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#createPresentationFromStream)

ตัวอย่างต่อไปนี้ใช้ไฟล์ PPT:

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");

const filePath = "protected-presentation.ppt";
const password = "open_password";
const presentationFactory = slides.PresentationFactory.getInstance();
const infoStream = fs.createReadStream(filePath);

slides.PresentationFactory.getPresentationInfoFromStream(presentationFactory, infoStream, function(infoError, presentationInfo) {
    if (infoError) {
        console.log("The presentation information could not be read: " + infoError.message);
    } else if (!presentationInfo.isPasswordProtected()) {
        console.log("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        console.log("The opening password is incorrect.");
    } else {
        const loadOptions = new slides.LoadOptions();
        loadOptions.setPassword(password);
        const presentationStream = fs.createReadStream(filePath);

        slides.Presentation.createPresentationFromStream(presentationStream, loadOptions, function(loadError, presentation) {
            if (loadError) {
                console.log("The presentation could not be loaded: " + loadError.message);
            } else {
                try {
                    console.log("The presentation was validated and loaded successfully.");
                } finally {
                    presentation.dispose();
                }
            }
        });
    }
});
```

### **ค่าที่ส่งกลับจาก checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/#checkPassword) คืนค่า `true` เฉพาะเมื่อการนำเสนอมีรหัสผ่านเปิดใช้งานและรหัสที่ให้ถูกต้อง จะคืนค่า `false` ในกรณีต่อไปนี้:
- รหัสผ่านไม่ถูกต้อง.
- การนำเสนอไม่มีรหัสผ่านเปิดใช้งาน.
- รหัสผ่านที่ให้เป็น `null` หรือว่างเปล่า.

พฤติกรรมเดียวกันสำหรับการนำเสนอ PPT และ PPTX.

## **ตรวจสอบว่าการนำเสนอที่โหลดแล้วถูกเข้ารหัสหรือไม่**

หลังจากโหลดการนำเสนอด้วยรหัสผ่านที่ถูกต้อง ให้ตรวจสอบ [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/protectionmanager/#isEncrypted) เพื่อยืนยันว่าการนำแหล่งต้นถูกเข้ารหัส เพื่อค้นพบการป้องกันด้วยรหัสผ่านเปิดใช้งานก่อนโหลด ให้ใช้ [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) ตามที่แสดงข้างต้น

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const isEncrypted = presentation.getProtectionManager().isEncrypted();
    console.log("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **คำแนะนำด้านความปลอดภัย**

{{% alert color="warning" title="Security" %}}
ห้ามบันทึกรหัสผ่านเปิดใช้งานหรือรวมไว้ในข้อความการวินิจฉัย หลีกเลี่ยงการตรวจสอบซ้ำโดยไม่จำเป็น เก็บรหัสผ่านในหน่วยความจำเฉพาะระยะเวลาที่จำเป็นเท่านั้น และใช้ผลการตรวจสอบที่สำเร็จซ้ำเมื่อโหลดการนำเสนอโดยทันที.
{{% /alert %}}

## **ป้องกันการนำเสนอด้วยรหัสผ่านออนไลน์**

1. เปิดแอปพลิเคชัน [Aspose.Slides Lock](https://products.aspose.app/slides/th/lock)
2. เลือกหรืออัปโหลดการนำเสนอ
3. ป้อนรหัสผ่านสำหรับการป้องกันการดู
4. หากต้องการให้ป้อนรหัสผ่านแยกสำหรับการป้องกันการแก้ไข
5. ใช้การป้องกันและดาวน์โหลดไฟล์ที่ได้

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/th/nodejs-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/th/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างรหัสผ่านเปิดใช้งานและรหัสผ่านการป้องกันการเขียนคืออะไร?**

รหัสผ่านเปิดใช้งานจะเข้ารหัสการนำเสนอและจำเป็นต้องใช้เพื่อโหลดเนื้อหา ส่วนรหัสผ่านการป้องกันการเขียนจำกัดการแก้ไขโดยไม่ได้เข้ารหัสเนื้อหา.

**ฉันสามารถตรวจสอบรหัสผ่านเปิดใช้งานโดยไม่ต้องโหลดสไลด์ทั้งหมดได้หรือไม่?**

ได้ ขึ้นอยู่กับการดึงข้อมูลการนำเสนอ ตรวจสอบว่ามีการป้องกันด้วยรหัสผ่านเปิดใช้งานหรือไม่ และตรวจสอบรหัสผ่านก่อนสร้างอินสแตนซ์การนำเสนอเต็ม

**เวิร์กโฟลว์การตรวจสอบรหัสผ่านสนับสนุนทั้ง PPT และ PPTX หรือไม่?**

ใช่ เวิร์กโฟลว์การตรวจจับและตรวจสอบรหัสผ่านแบบไฟล์พาธและสตรีมทำงานเช่นเดียวกันสำหรับการนำเสนอ PPT และ PPTX.