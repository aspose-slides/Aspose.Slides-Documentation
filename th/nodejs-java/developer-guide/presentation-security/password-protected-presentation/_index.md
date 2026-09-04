---
title: ป้องกันการนำเสนอด้วยรหัสผ่านใน JavaScript
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
- ยืนยันรหัสผ่านการนำเสนอ
- เปิดการนำเสนอที่เข้ารหัส
- ลบการเข้ารหัส
- PowerPoint
- PPT
- PPTX
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เข้ารหัส, ตรวจจับ, ตรวจสอบ, เปิด, และถอดรหัสการนำเสนอ PowerPoint PPT และ PPTX ที่ป้องกันด้วยรหัสผ่านใน JavaScript ด้วย Aspose.Slides."
---
## **ภาพรวม**

รหัสผ่านเปิดใช้งานจะทำการเข้ารหัสการนำเสนอ รหัสผ่านที่ถูกต้องจำเป็นต่อการโหลดและดูเนื้อหาการนำเสนอ ดังนั้นการป้องกันนี้จึงให้ความลับ

รหัสผ่านเปิดใช้งานแตกต่างจากรหัสผ่านป้องกันการเขียน การป้องกันการเขียนจำกัดการแก้ไขแต่ไม่เข้ารหัสเนื้อหา หรือป้องกันไม่ให้โหลดการนำเสนอ เพื่อจัดการรหัสผ่านสำหรับการแก้ไขการนำเสนอ โปรดดู [Write-Protect Presentations](/slides/th/nodejs-java/write-protected-presentation/).

เวิร์กโฟลว์ด้านล่างใช้ได้กับการนำเสนอทั้งประเภท PPT และ PPTX ตัวอย่างใช้ทั้งสองรูปแบบเมื่อพฤติกรรมตามไฟล์และตามสตรีมมีความสำคัญ

## **เข้ารหัสการนำเสนอด้วยรหัสผ่านเปิดใช้งาน**

ใช้ [ProtectionManager.encrypt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/protectionmanager/#encrypt) เพื่อตั้งค่ารหัสผ่านเปิดใช้งาน จากนั้นใช้ [Presentation.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#save) เพื่อบันทึกการนำเสนอที่เข้ารหัส

ตัวอย่างต่อไปนี้จะเข้ารหัสการนำเสนอ PPTX:

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

## **คงคุณสมบัติเอกสารให้อยู่ในสาธารณะ**

โดยค่าเริ่มต้น Aspose.Slides จะรวมคุณสมบัติเอกสารในการเข้ารหัสการนำเสนอ วิธีการ [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) ควบคุมพฤติกรรมนี้แยกจากการเข้ารหัสเนื้อหาสไลด์ ให้ส่งค่า `false` ก่อนเรียก [ProtectionManager.encrypt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/protectionmanager/#encrypt) เมื่อระบบทำดัชนี การจัดประเภท การค้นหา หรือการจัดการเอกสารต้องอ่านเมทาดาท้าโดยไม่มีรหัสผ่านเปิดใช้งาน

ตัวอย่างต่อไปนี้สร้างการนำเสนอ PPTX ที่เข้ารหัสพร้อมกับคงคุณสมบัติเอกสารในตัวให้เป็นสาธารณะ:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การส่งค่า `false` ให้กับ [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) ไม่ได้ทำให้สไลด์ มาสเตอร์ การจัดวาง รูปทรง สื่อ หรือเนื้อหาอื่นของการนำเสนอเป็นสาธารณะ มันส่งผลต่อคุณสมบัติเอกสารเท่านั้น เพื่ออ่านคุณสมบัติเหล่านั้นโดยไม่โหลดเนื้อหาที่เข้ารหัส โปรดดู [Manage Presentation Properties](/slides/th/nodejs-java/presentation-properties/).

## **โหลดการนำเสนอที่เข้ารหัส**

ตั้งค่า [LoadOptions.setPassword](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#setPassword) ให้เป็นรหัสผ่านเปิดใช้งานและส่งตัวเลือกไปยัง [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) เมื่อโหลดไฟล์ การโหลดจะล้มเหลือเมื่อจำเป็นต้องใช้รหัสผ่านเปิดใช้งานแต่รหัสผ่านที่ให้มาขาดหายหรือไม่ถูกต้อง

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

## **ลบการเข้ารหัสออกจากการนำเสนอ**

โหลดการนำเสนอพร้อมรหัสผ่านเปิดใช้งาน เรียกใช้ [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/protectionmanager/#removeEncryption) แล้วบันทึกผลลัพธ์ การนำเสนอที่บันทึกแล้วสามารถโหลดได้โดยไม่ต้องใช้รหัสผ่าน

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

ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) เพื่อดึงข้อมูล [PresentationInfo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/) โดยไม่ต้องสร้างอินสแตนซ์การนำเสนอเต็มรูปแบบ ตรวจสอบ [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) ก่อนขอหรือยืนยันรหัสผ่าน เมื่อมีการป้องกัน ให้ตรวจสอบค่าที่ให้มาด้วย [PresentationInfo.checkPassword](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/#checkPassword)

### **เวิร์กโฟลว์แบบไฟล์พาธ**

ตัวอย่างต่อไปนี้ตรวจสอบรหัสผ่านเปิดใช้งานสำหรับไฟล์ PPTX ส่งค่าที่ตรวจสอบแล้วไปยัง [LoadOptions.setPassword](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#setPassword) แล้วโหลดการนำเสนอเต็มรูปแบบ:

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

### **เวิร์กโฟลว์แบบสตรีม**

ใช้ [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) เพื่อตรวจสอบสตรีมที่อ่านได้ของ Node.js หลังจากสตรีมตรวจสอบถูกใช้หมด ให้สร้างสตรีมใหม่ก่อนโหลดการนำเสนอเต็มรูปแบบด้วย [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#createPresentationFromStream)

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

### **ค่าการคืนของ checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/#checkPassword) จะคืนค่า `true` ก็ต่อเมื่อการนำเสนอมีรหัสผ่านเปิดใช้งานและรหัสผ่านที่ให้มาถูกต้อง จะคืนค่า `false` ในกรณีต่อไปนี้:
- รหัสผ่านไม่ถูกต้อง.
- การนำเสนอไม่มีรหัสผ่านเปิดใช้งาน.
- รหัสผ่านที่ให้มาเป็น `null` หรือว่างเปล่า.

พฤติกรรมนี้เหมือนกันสำหรับการนำเสนอทั้ง PPT และ PPTX.

## **ตรวจสอบว่าการนำเสนอที่โหลดแล้วถูกเข้ารหัสหรือไม่**

หลังจากโหลดการนำเสนอด้วยรหัสผ่านที่ถูกต้อง ให้ตรวจสอบ [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/protectionmanager/#isEncrypted) เพื่อยืนยันว่าการนำแหล่งที่มาถูกเข้ารหัส เพื่อค้นหาการป้องกันด้วยรหัสผ่านเปิดใช้งานก่อนโหลด ให้ใช้ [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) ตามที่แสดงข้างต้น

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
ไม่ควรบันทึกรหัสผ่านเปิดใช้งานหรือใส่ไว้ในข้อความวินิจฉัย หลีกเลี่ยงการพยายามตรวจสอบซ้ำโดยไม่จำเป็น เก็บรหัสผ่านในหน่วยความจำเพียงเท่าที่จำเป็นเท่านั้น และใช้ผลการตรวจสอบที่สำเร็จซ้ำเมื่อโหลดการนำเสนอทันที

คุณสมบัติเอกสารสาธารณะอาจเปิดเผยชื่อผู้เขียน ชื่อเรื่อง หัวข้อ คำสำคัญ ข้อมูลบริษัท คอมเมนต์ และค่าที่กำหนดเอง แม้ว่าข้อมูลการนำเสนอจะถูกเข้ารหัส ควรเข้ารหัสเมทาดาต้าอ่อนไหวนั้นพร้อมกับการนำเสนอ การทำให้คุณสมบัติเป็นสาธารณะควรเป็นการตัดสินใจอย่างชัดเจนและทำเฉพาะเมื่อระบบต้องทำการจัดทำดัชนี การจัดประเภท การค้นหา หรือการจัดการไฟล์โดยไม่ต้องใช้รหัสผ่านเปิดใช้งาน
{{% /alert %}}

## **ป้องกันการนำเสนอด้วยรหัสผ่านออนไลน์**

1. เปิดแอปพลิเคชัน [Aspose.Slides Lock](https://products.aspose.app/slides/th/lock)
2. เลือกหรืออัปโหลดการนำเสนอ
3. ป้อนรหัสผ่านสำหรับการป้องกันการดู
4. หากต้องการให้ป้อนรหัสผ่านแยกต่างหากสำหรับการป้องกันการแก้ไข
5. ใช้การป้องกันและดาวน์โหลดไฟล์ที่ได้

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/th/nodejs-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/th/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**What is the difference between an opening password and a write-protection password?**

รหัสผ่านเปิดใช้งานจะเข้ารหัสการนำเสนอและจำเป็นต่อการโหลดเนื้อหา ส่วนรหัสผ่านป้องกันการเขียนจะจำกัดการแก้ไขโดยไม่เข้ารหัสเนื้อหา

**Can I validate an opening password without loading all slides?**

ได้  ใช้การรับข้อมูลการนำเสนอ ตรวจสอบว่ามีการป้องกันด้วยรหัสผ่านเปิดใช้งานหรือไม่ และตรวจสอบรหัสผ่านก่อนสร้างอินสแตนซ์การนำเสนอเต็มรูปแบบ

**Can an application read metadata without the opening password?**

ได้ แต่เฉพาะเมื่อการนำเสนอถูกเข้ารหัสโดยปิดการเข้ารหัสคุณสมบัติเอกสาร แอปพลิเคชันจะต้องใช้โหมดการโหลดเฉพาะคุณสมบัติเอกสารตามที่อธิบายใน [Manage Presentation Properties](/slides/th/nodejs-java/presentation-properties/).

**Do the password-checking workflows support both PPT and PPTX?**

ได้ การตรวจจับและตรวจสอบรหัสผ่านแบบไฟล์พาธและสตรีมทำงานเช่นเดียวกันสำหรับการนำเสนอทั้ง PPT และ PPTX.