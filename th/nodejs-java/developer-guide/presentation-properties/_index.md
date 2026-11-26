---
title: จัดการคุณสมบัติงานนำเสนอใน JavaScript
linktitle: คุณสมบัติงานนำเสนอ
type: docs
weight: 70
url: /th/nodejs-java/presentation-properties/
keywords:
- คุณสมบัติ PowerPoint
- คุณสมบัติงานนำเสนอ
- คุณสมบัติเอกสาร
- คุณสมบัติในตัว
- คุณสมบัติที่กำหนดเอง
- คุณสมบัติขั้นสูง
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมทาดาต้าเอกสาร
- แก้ไขเมทาดาต้า
- ภาษาการพิสูจน์
- ภาษาปริยาย
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ควบคุมคุณสมบัติงานนำเสนอใน Aspose.Slides สำหรับ Node.js ผ่าน Java และทำให้การค้นหา การสร้างแบรนด์ และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณเป็นเรื่องง่าย"
---
## **บทนำ**

Aspose.Slides for Node.js via Java รองรับคุณสมบัติของเอกสาร **built-in** และ **custom** ใช้คุณสมบัติเหล่านี้เพื่ออ่านและอัปเดตเมตาดาต้าของงานนำเสนอ เช่น ผู้เขียน ชื่อเรื่อง และค่าที่ผู้ใช้กำหนด

Aspose.Slides อนุญาตให้คุณทำงานกับคุณสมบัติของเอกสารงานนำเสนอผ่านคลาส [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) ตัวอย่างของคลาสนี้จะถูกคืนค่าจาก [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) ตัวอย่างต่อไปนี้แสดงวิธีการอ่าน แก้ไข และจัดการคุณสมบัติเหล่านี้

{{% alert color="info" title="หมายเหตุ" %}}
Aspose.Slides จัดการข้อมูลเมตาดาต้าแอปพลิเคชันและผู้ผลิตเมื่อบันทึกงานนำเสนอ; ฟิลด์เหล่านี้ระบุซอฟต์แวร์ที่สร้างผลลัพธ์
{{% /alert %}}

## **จัดการคุณสมบัติงานนำเสนอ**

คุณสมบัติของเอกสารเก็บข้อมูลอธิบายเคียงคู่กับเนื้อหาของงานนำเสนอ พวกมันแบ่งออกเป็นสองประเภท

- **คุณสมบัติในตัว** มีเมตาดาต้ามาตรฐาน เช่น ชื่อเรื่อง ผู้เขียน และสถิติของเอกสาร
- **คุณสมบัติกำหนดเอง** เก็บคู่ชื่อ/ค่า ที่ผู้ใช้กำหนดเอง

Aspose.Slides for Node.js via Java ให้การเข้าถึงทั้งสองประเภท ใน PowerPoint ให้เลือก **File → Info → Properties → Advanced Properties** เพื่อดูเมตาดาต้าเอกสาร กล่องโต้ตอบจะจัดกลุ่มข้อมูลเป็นแท็บต่างๆ เช่น **Summary**, **Statistics**, **Contents**, และ **Custom** ใช้แท็บ **Custom** เพื่อจัดการคุณสมบัติที่ผู้ใช้กำหนด

## **อ่านคุณสมบัติสาธารณะจากงานนำเสนอที่เข้ารหัส**

รหัสผ่านเปิดไฟล์ปกติจะปกป้องทั้งเนื้อหาและคุณสมบัติของเอกสาร เมื่อมีการเข้ารหัสงานนำเสนอหลังจากเรียก [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) ด้วย `false` คุณสมบัติของเอกสารจะยังคงเป็นสาธารณะ แอปพลิเคชันสามารถเรียก [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) ด้วย `true` และอ่านเมตาดาต้าสาธารณะโดยไม่ต้องให้รหัสผ่านเปิดไฟล์

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) ควบคุมสิ่งที่ Aspose.Slides โหลด; มันไม่ได้ทำการถอดรหัสใดๆ หากคุณสมบัติอยู่ในขั้นตอนการเข้ารหัส การโหลดโดยไม่มีรหัสผ่านจะล้มเหลว หากงานนำเสนอไม่ได้ถูกเข้ารหัส ตัวเลือกนี้จะถูกละเว้นและงานนำเสนอทั้งหมดจะถูกโหลด

ตัวอย่างนี้ต้องใช้งานนำเสนอที่เข้ารหัสโดยที่คุณสมบัติของเอกสารถูกทิ้งไว้เป็นสาธารณะ มันตรวจสอบโหมดการโหลดผ่าน [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) แล้วอ่านคุณสมบัติในตัวผ่าน [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties):

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const documentProperties = presentation.getDocumentProperties();

        console.log("Author: " + documentProperties.getAuthor());
        console.log("Title: " + documentProperties.getTitle());
        console.log("Keywords: " + documentProperties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

ในโหมดนี้ เนื้อหาสไลด์จะไม่ถูกโหลด สไลด์ มาสเตอร์ เลย์เอาต์ รูปร่าง สื่อ และวัตถุอื่น ๆ ของงานนำเสนอจะไม่พร้อมใช้งาน แอปพลิเคชันควรตรวจสอบ [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) เสมอก่อนทำการดำเนินการที่ต้องการโมเดลวัตถุของงานนำเสนอทั้งหมด

{{% alert color="warning" title="คำเตือน" %}}
เมตาดาต้าสาธารณะอาจเปิดเผยชื่อผู้เขียน ชื่อเรื่อง หัวข้อ คำสำคัญ ข้อมูลบริษัท ความคิดเห็นและค่ากำหนดเอง เข้ารหัสคุณสมบัติที่สำคัญพร้อมกับงานนำเสนอ ทิ้งไว้เป็นสาธารณะเฉพาะเมื่อระบบจัดทำดัชนี การจำแนก การค้นหา หรือระบบจัดการเอกสารต้องการเข้าถึงโดยไม่ต้องใช้รหัสผ่าน
{{% /alert %}}

## **อัปเดตคุณสมบัติของงานนำเสนอที่เข้ารหัส**

สำหรับไฟล์ PPTX ที่เข้ารหัส การโหลดงานนำเสนอหลังจากเรียก [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) ด้วย `true` มีจุดประสงค์เพื่ออ่านเมตาดาต้าสาธารณะ Aspose.Slides ไม่สามารถบันทึกการเปลี่ยนแปลงคุณสมบัติจากวัตถุที่โหลดเฉพาะเมตาดาต้านี้ได้ เนื่องจากคุณสมบัติสาธารณะต้องสอดคล้องกับข้อมูลที่อยู่ภายในงานนำเสนอที่เข้ารหัส การอัปเดตจึงต้องใช้รหัสผ่านเปิดไฟล์ที่ถูกต้องและโหลดเต็มรูปแบบ

ตัวอย่างนี้ต้องใช้ไฟล์ PPTX ที่เข้ารหัสโดยมีคุณสมบัติของเอกสารเป็นสาธารณะและรหัสผ่านเปิดไฟล์ที่ทราบ มันเปิดงานนำเสนอเต็มรูปแบบด้วย [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setPassword) อัปเดตคุณสมบัติในตัวสาธารณะ แล้วบันทึกผลลัพธ์ จากนั้นใช้ [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#isEncrypted) เพื่อตรวจสอบว่าการเข้ารหัสยังคงอยู่และเปิดเมตาดาต้าสาธารณะโดยไม่มีรหัสผ่านเพื่อยืนยันค่าที่ใหม่:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");
    
    presentation.save(outputPath, slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(outputPath);
console.log("The presentation is encrypted: " + presentationInfo.isEncrypted());

const metadataLoadOptions = new slides.LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

const metadataPresentation = new slides.Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        console.log("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        console.log("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

หากแอปพลิเคชันไม่ได้รับอนุญาตให้ถอดรหัสหรือโหลดเนื้อหาของงานนำเสนอ จะต้องถือว่าคุณสมบัติสาธารณะของไฟล์ PPTX ที่เข้ารหัสเป็นแบบอ่านอย่างเดียว

## **เข้าถึงคุณสมบัติในตัว**

คลาส [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) เปิดเผยเมตาดาต้าฟิลด์ในตัวผ่านเมธอด getter รวมถึง [getAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getAuthor), [getTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTitle) และ [getCreatedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCreatedTime) ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่และพิมพ์เมตาดาต้าที่จัดเก็บลงคอนโซล ค่าต่าง ๆ จะขึ้นอยู่กับงานนำเข้า บางฟิลด์อาจว่างเปล่า

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    console.log("Category: " + documentProperties.getCategory());
    console.log("Content status: " + documentProperties.getContentStatus());
    console.log("Creation date: " + documentProperties.getCreatedTime());
    console.log("Author: " + documentProperties.getAuthor());
    console.log("Comments: " + documentProperties.getComments());
    console.log("Keywords: " + documentProperties.getKeywords());
    console.log("Last modified by: " + documentProperties.getLastSavedBy());
    console.log("Manager: " + documentProperties.getManager());
    console.log("Modified date: " + documentProperties.getLastSavedTime());
    console.log("Presentation format: " + documentProperties.getPresentationFormat());
    console.log("Last print date: " + documentProperties.getLastPrinted());
    console.log("Is shared between producers: " + documentProperties.getSharedDoc());
    console.log("Subject: " + documentProperties.getSubject());
    console.log("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

### **รายงานเลขเวอร์ชันและเวลาการแก้ไข**

เพื่อรายงานเลขเวอร์ชันและเวลาการแก้ไขรวมของแต่ละไฟล์ PPTX ในโฟลเดอร์ `presentations` ให้ใช้ [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) มันจะคืนค่า [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) ของไฟล์โดยไม่ต้องโหลดสไลด์เพื่อแก้ไข ตัวอย่างจะแปลงระยะเวลาที่บันทึกจากมิลลิวินาทีเป็นชั่วโมง นาที และวินาที สำหรับระยะเวลาที่เท่ากับ 24 ชั่วโมงหรือมากกว่าจะเพิ่มจำนวนวันเต็มหน้าเวลา

```javascript
const fs = require("fs");
const path = require("path");
const slides = require("aspose.slides.via.java");

const folder = "presentations";
const files = fs.readdirSync(folder, { withFileTypes: true });
const factory = slides.PresentationFactory.getInstance();

console.log("File | RevisionNumber | TotalEditingTime");
for (const file of files) {
    if (!file.isFile() || path.extname(file.name).toLowerCase() !== ".pptx") {
        continue;
    }
    const filePath = path.join(folder, file.name);
    const info = factory.getPresentationInfo(filePath);
    const properties = info.readDocumentProperties();
    const totalSeconds = Math.floor(properties.getTotalEditingTime() / 1000);
    const days = Math.floor(totalSeconds / 86400);
    const hours = Math.floor(totalSeconds / 3600) % 24;
    const minutes = Math.floor(totalSeconds / 60) % 60;
    const seconds = totalSeconds % 60;
    const time = [hours, minutes, seconds].map(value => String(value).padStart(2, "0")).join(":");
    const editingTime = days > 0 ? `${days}.${time}` : time;
    console.log(`${file.name} | ${properties.getRevisionNumber()} | ${editingTime}`);
}
```

สำหรับงานนำเสนอที่บันทึกเวลาการแก้ไขเป็น 1 วัน 2 ชั่วโมง 5 นาที รายงานจะแสดงผลดังต่อไปนี้

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[getRevisionNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getRevisionNumber) อ่านค่าที่แอปพลิเคชันสามารถเปลี่ยนได้ด้วย [setRevisionNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setRevisionNumber) ตัวเลขเวอร์ชันนั้นเองไม่สามารถบ่งชี้จำนวนครั้งที่งานนำเสนอถูกบันทึกหรือสร้างประวัติเวอร์ชันได้

[getTotalEditingTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTotalEditingTime) อ่านระยะเวลาการแก้ไขที่บันทึกในไฟล์ ค่า `00:00:00` หมายถึงระยะเวลาที่บันทึกเป็นศูนย์ แม้ว่าจะมีการแก้ไขงานนำเสนอ

## **แก้ไขคุณสมบัติในตัว**

เพื่ออัปเดตเมตาดาต้าในตัว ให้ใช้เมธอด setter ของอ็อบเจกต์ที่ส่งคืนโดย [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่ เรียก [setAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setAuthor), [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setTitle), [setSubject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setSubject), [setComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setComments) และ [setManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setManager) แล้วบันทึกงานนำเสนอที่อัปเดตด้วย [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save) ไฟล์ PPTX ที่บันทึกจะมีเมตาดาต้าใหม่

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ModifyBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Node.js via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **จัดการฐานลิงก์**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getHyperlinkBase) คืนค่าฐานของเอกสารสำหรับลิงก์เชิงสัมพันธ์ ใช้ [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setHyperlinkBase) เพื่อเปลี่ยนหรือเคลียร์มัน สิ่งนี้มีประโยชน์เมื่อย้ายงานนำเสนอและไฟล์ที่ลิงก์ไปยังตำแหน่งอื่น มันแยกจาก [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) ของลิงก์แต่ละอัน: การเปลี่ยนฐานจะไม่เขียนทับที่อยู่ลิงก์ที่จัดเก็บหรือเปลี่ยนปลายทางเป็นแบบสัมบูรณ์

ตัวอย่างนี้ต้องการงานนำเสนอที่มีลิงก์เชิงสัมพันธ์ เช่น `target.html` และลิงก์สัมบูรณ์ เช่น `https://example.org/absolute.html` มันอ่านฐานที่มีอยู่ กำหนดฐานใหม่ แล้วบันทึกและเปิดงานนำเสนอใหม่เพื่อตรวจสอบค่า จากนั้นเคลียร์ฐานด้วยสตริงว่างและตรวจสอบค่าเปล่าในไฟล์ที่บันทึกแยกออกมา แทนที่ฐานตัวอย่างด้วยตำแหน่งของไฟล์ที่ลิงก์ของคุณ

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("hyperlinks.pptx");
try {
    console.log("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    const newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", slides.SaveFormat.Pptx);

    const updatedPresentation = new slides.Presentation("hyperlinks-updated.pptx");
    try {
        console.log("Base preserved: " + (newBase === updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", slides.SaveFormat.Pptx);

        const clearedPresentation = new slides.Presentation("hyperlinks-cleared.pptx");
        try {
            console.log("Base cleared: " + ("" === clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

ข้อความตรวจสอบทั้งสองควรพิมพ์ `true` การเคลียร์ฐานไม่ทำให้ที่อยู่ลิงก์เดี่ยวเปลี่ยนแปลง

ลิงก์เชิงสัมพันธ์ `target.pptx` ที่เปิด `old/target.pptx` เมื่อฐานชี้ไปที่โฟลเดอร์ `old` หลังจากเปลี่ยนฐานเป็นโฟลเดอร์ `new` บันทึกและเปิดงานนำเสนอใหม่ ลิงก์เดียวกันจะเปิด `new/target.pptx` ลิงก์สัมบูรณ์จะยังคงเปิดไฟล์เดิม ทดสอบลิงก์เชิงสัมพันธ์ของคุณใน PowerPoint ก่อนและหลังย้ายงานนำเสนอหรือเปลี่ยนฐาน

## **เพิ่มคุณสมบัติการนำเสนอที่กำหนดเอง**

คุณสมบัติกำหนดเองเก็บเมตาดาต้าที่ไม่มีฟิลด์ในตัวที่สอดคล้องกัน วิธี [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) ให้คุณกำหนดค่าโดยใช้ชื่อคุณสมบัติ ตัวอย่างนี้สร้างงานนำเสนอ เพิ่มค่าข้อความสองค่าและค่ารุ่นเป็นจำนวนเต็ม แล้วบันทึกงานนำเสนอด้วย [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save) การกำหนดค่าชื่อที่มีอยู่แล้วจะแทนที่ค่าของคุณสมบัตินั้น

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เข้าถึงและแก้ไขคุณสมบัติกำหนดเอง**

ตัวอย่างนี้เปิดงานนำเสนอที่มีคุณสมบัติกำหนดเองและใช้ [getCountOfCustomProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCountOfCustomProperties) เพื่อวนซ้ำผ่านพวกมัน [getCustomPropertyName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCustomPropertyName) รับดัชนีเริ่มจากศูนย์และคืนชื่อที่ใช้ใน [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) ตัวอย่างพิมพ์ชื่อและค่าต้นฉบับแต่ละรายการ แทนที่ค่าทั้งหมดด้วยสตริงลำดับเลขโดยไม่คำนึงถึงประเภทเดิม แล้วบันทึกการเปลี่ยนแปลง หากไม่มีคุณสมบัติกำหนดเอง ลูปจะไม่มีการเปลี่ยนแปลงใดๆ

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessAndModifyProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    for (let i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        const propertyName = documentProperties.getCustomPropertyName(i);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log("Custom property name: " + propertyName);
        console.log("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตัวอย่างสด**

ลองใช้แอปออนไลน์ [**ดูและแก้ไขเมตาดาต้า PowerPoint**](https://products.aspose.app/slides/metadata) เพื่อดูวิธีการทำงานกับคุณสมบัติของเอกสารโดยใช้ Aspose.Slides API:

[![ดูและแก้ไขเมตาดาต้า PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **คำถามที่พบบ่อย**

**ฉันจะลบคุณสมบัติในตัวจากงานนำเสนอได้อย่างไร?**

คุณสมบัติในตัวเป็นส่วนสำคัญของงานนำเสนอและไม่สามารถลบออกได้ทั้งหมด อย่างไรก็ตาม คุณสามารถเปลี่ยนค่าของมันหรือกำหนดค่าว่างได้หากคุณสมบัตินั้นอนุญาต

**เกิดอะไรขึ้นถ้าฉันเพิ่มคุณสมบัติกำหนดเองที่มีอยู่แล้ว?**

หากคุณเพิ่มคุณสมบัติกำหนดเองที่มีอยู่แล้ว ค่าที่มีอยู่จะถูกเขียนทับด้วยค่าใหม่ คุณไม่จำเป็นต้องลบหรือเช็คคุณสมบัติก่อนหน้านั้น เนื่องจาก Aspose.Slides จะอัปเดตค่าโดยอัตโนมัติ

**ฉันสามารถเข้าถึงคุณสมบัติงานนำเสนอโดยไม่ต้องโหลดงานนำเสนอทั้งหมดได้หรือไม่?**

ได้ ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationFactory#getPresentationInfo) แล้วเรียก [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) เพื่ออ่านเมตาดาต้าเอกสารที่จัดเก็บโดยไม่ต้องสร้างอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) ดูตัวอย่างการรายงานเต็มรูปแบบและข้อจำกัดตามประเภทเอกสารที่ [Build a Lightweight Presentation Inventory](/slides/th/nodejs-java/examine-presentation/)

**ฉันสามารถอ่านคุณสมบัติสาธารณะของงานนำเสนอที่เข้ารหัสโดยไม่ต้องใช้รหัสผ่านเปิดไฟล์ได้หรือไม่?**

ได้ งานนำเสนอจะต้องถูกเข้ารหัสหลังจากเรียก [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) ด้วย `false` และต้องถูกโหลดหลังจากเรียก [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) ด้วย `true`

**ฉันสามารถอัปเดตไฟล์ PPTX ที่เข้ารหัสในโหมดโหลดเฉพาะคุณสมบัติเ�เอกสารได้หรือไม่?**

ไม่ได้ ข้อมูลคุณสมบัติสาธารณะและที่เข้ารหัสต้องสอดคล้องกัน ดังนั้นการอัปเดตไฟล์ PPTX ที่เข้ารหัสจำเป็นต้องโหลดงานนำเสนอเต็มรูปแบบพร้อมรหัสผ่านเปิดไฟล์ที่ถูกต้อง