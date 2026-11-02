---
title: จัดการคุณสมบัติการนำเสนอใน JavaScript
linktitle: คุณสมบัติการนำเสนอ
type: docs
weight: 70
url: /th/nodejs-java/presentation-properties/
keywords:
- คุณสมบัติ PowerPoint
- คุณสมบัติการนำเสนอ
- คุณสมบัติเอกสาร
- คุณสมบัติ built-in
- คุณสมบัติ custom
- คุณสมบัติขั้นสูง
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมตาดาต้าเอกสาร
- แก้ไขเมตาดาต้า
- ภาษาการตรวจสอบ
- ภาษาดีฟอลต์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ควบคุมคุณสมบัติการนำเสนอใน Aspose.Slides สำหรับ Node.js ผ่าน Java และปรับปรุงการค้นหา, การสร้างแบรนด์และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณ."
---
## **บทนำ**

Aspose.Slides สำหรับ Node.js ผ่าน Java รองรับคุณสมบัติเอกสาร **built-in** และ **custom**. ใช้คุณสมบัติเหล่านี้เพื่ออ่านและอัปเดตเมตาดาตาการนำเสนอ เช่น ผู้เขียน, ชื่อเรื่อง, และค่าที่กำหนดโดยผู้ใช้.

Aspose.Slides ช่วยให้คุณทำงานกับคุณสมบัติเอกสารการนำเสนอผ่านคลาส [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) . ตัวอย่างของคลาสนี้จะถูกส่งคืนโดย [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties). ตัวอย่างต่อไปนี้แสดงวิธีการอ่าน, แก้ไข, และจัดการคุณสมบัติเหล่านี้.

{{% alert color="info" title="Note" %}}
Aspose.Slides จัดการเมตาดาต้าแอปพลิเคชันและผู้ผลิตเมื่อบันทึกการนำเสนอ; ฟิลด์เหล่านี้ระบุซอฟต์แวร์ที่สร้างผลลัพธ์.
{{% /alert %}}

## **จัดการคุณสมบัติการนำเสนอ**

คุณสมบัติเอกสารเก็บข้อมูลเชิงบรรยายพร้อมกับเนื้อหาการนำเสนอ. พวกมันแบ่งเป็นสองประเภท:

- **Built-in properties** มีเมตาดาต้ามาตรฐาน เช่น ชื่อเรื่อง, ผู้เขียน, และสถิติเอกสาร.
- **Custom properties** เก็บคู่ชื่อ/ค่า ที่ผู้ใช้กำหนดเอง.

Aspose.Slides สำหรับ Node.js ผ่าน Java ให้เข้าถึงทั้งสองประเภท. ใน PowerPoint, เลือก **File → Info → Properties → Advanced Properties** เพื่อดูเมตาดาต้าเอกสาร. กล่องโต้ตอบจัดข้อมูลเป็นแท็บเช่น **Summary**, **Statistics**, **Contents**, และ **Custom**. ใช้แท็บ **Custom** เพื่อจัดการคุณสมบัติที่ผู้ใช้กำหนด.

## **อ่านคุณสมบัติสาธารณะจากการนำเสนอที่เข้ารหัส**

รหัสผ่านสำหรับเปิดปกติจะแปลงทั้งเนื้อหาการนำเสนอและคุณสมบัติเอกสาร. เมื่อการนำเสนอถูกเข้ารหัสหลังจากเรียก [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) ด้วยค่า `false`, คุณสมบัติเอกสารจะยังคงเป็นสาธารณะ. แอปพลิเคชันสามารถเรียก [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) ด้วยค่า `true` และอ่านเมตาดาต้าสาธารณะโดยไม่ต้องระบุรหัสผ่านเปิด.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) ควบคุมสิ่งที่ Aspose.Slides โหลด; ไม่ทำการถอดรหัสใดๆ. หากคุณสมบัติติดอยู่ในการเข้ารหัส, การโหลดโดยไม่มีรหัสผ่านจะล้มเหลว. หากการนำเสนอไม่ได้เข้ารหัส, ตัวเลือกนี้จะถูกละเลยและการนำเสนอทั้งหมดจะถูกโหลด.

ตัวอย่างนี้ต้องการการนำเสนอที่เข้ารหัสซึ่งคุณสมบัติเอกสารถูกปล่อยเป็นสาธารณะ. มันตรวจสอบโหมดการโหลดผ่าน [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) และจากนั้นอ่านคุณสมบัติ built-in ผ่าน [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties):

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

ในโหมดนี้, เนื้อหาสไลด์จะไม่ถูกโหลด. สไลด์, มาสเตอร์, เลย์เอาต์, รูปร่าง, สื่อ, และออบเจ็กต์การนำเสนออื่นๆ จะไม่พร้อมใช้งาน. แอปพลิเคชันควรตรวจสอบ [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) เสมอก่อนดำเนินการที่ต้องการโมเดลออบเจ็กต์การนำเสนอแบบเต็ม.

{{% alert color="warning" title="Warning" %}}
เมตาดาต้าสาธารณะอาจเปิดเผยชื่อผู้เขียน, ชื่อเรื่อง, หัวข้อ, คีย์เวิร์ด, ข้อมูลบริษัท, ความคิดเห็น, และค่าที่กำหนดเอง. ให้เข้ารหัสคุณสมบัติที่เป็นความลับพร้อมกับการนำเสนอ. ทำให้เป็นสาธารณะเฉพาะเมื่อระบบการจัดทำดัชนี, การจัดประเภท, การค้นหา, หรือระบบการจัดการเอกสารมีความต้องการเฉพาะในการเข้าถึงโดยไม่มีรหัสผ่าน.
{{% /alert %}}

## **อัปเดตคุณสมบัติของการนำเสนอที่เข้ารหัส**

สำหรับไฟล์ PPTX ที่เข้ารหัส, การนำเสนอที่โหลดหลังจากเรียก [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) ด้วยค่า `true` มีจุดประสงค์เพื่ออ่านเมตาดาต้าสาธารณะ. Aspose.Slides ไม่สามารถบันทึกคุณสมบัติที่เปลี่ยนจากออบเจ็กต์ที่มีเมตาดาต้าเท่านั้นได้ เนื่องจากคุณสมบัติสาธารณะต้องสอดคล้องกับข้อมูลที่อยู่ภายในการนำเสนอที่เข้ารหัส. การอัปเดตจึงต้องใช้รหัสผ่านเปิดที่ถูกต้องและการโหลดเต็ม.

ตัวอย่างนี้ต้องการการนำเสนอ PPTX ที่เข้ารหัสพร้อมคุณสมบัติเอกสารสาธารณะและรหัสเปิดที่ทราบ. มันเปิดการนำเสนอเต็มด้วย [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setPassword), อัปเดตคุณสมบัติ built-in สาธารณะ, แล้วบันทึกผลลัพธ์. จากนั้นใช้ [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#isEncrypted) เพื่อยืนยันว่าการเข้ารหัสยังคงอยู่และเปิดเมตาดาต้าสาธารณะโดยไม่มีรหัสผ่านเพื่อยืนยันค่าที่ใหม่:

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

หากแอปพลิเคชันไม่ได้รับอนุญาตให้ถอดรหัสหรือโหลดเนื้อหาการนำเสนอ, จะต้องถือคุณสมบัติสาธารณะของไฟล์ PPTX ที่เข้ารหัสเป็นแบบอ่านอย่างเดียว.

## **เข้าถึงคุณสมบัติ Built-in**

คลาส [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) เปิดเผยเมตาดาต้า built-in ผ่านเมธอด getter, รวมถึง [getAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getAuthor), [getTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTitle), และ [getCreatedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCreatedTime). ตัวอย่างนี้เปิดการนำเสนอที่มีอยู่และพิมพ์เมตาดาต้าที่เก็บไว้ไปยังคอนโซล. ค่าเหล่านี้ขึ้นอยู่กับการนำเข้าการนำเสนอ; บางฟิลด์อาจว่าง.

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

## **แก้ไขคุณสมบัติ Built-in**

เพื่ออัปเดตเมตาดาต้า built-in, ใช้เมธอด setter บนวัตถุที่ได้จาก [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties). ตัวอย่างนี้เปิดการนำเสนอที่มีอยู่, เรียก [setAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setAuthor), [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setTitle), [setSubject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setSubject), [setComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setComments), และ [setManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setManager), จากนั้นบันทึกการนำเสนอที่อัปเดตด้วย [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save). PPTX ที่บันทึกจะมีเมตาดาต้าใหม่.

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

## **จัดการฐาน Hyperlink**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getHyperlinkBase) ส่งคืนฐานระดับเอกสารสำหรับลิงก์เชิงสัมพันธ์. ใช้ [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setHyperlinkBase) เพื่อเปลี่ยนหรือเคลียร์มัน. นี้มีประโยชน์เมื่อย้ายการนำเสนอและไฟล์ที่เชื่อมโยงไปยังตำแหน่งอื่น. มันแยกจาก [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) ของลิงก์แต่ละอัน: การเปลี่ยนฐานจะไม่เขียนทับที่อยู่ลิงก์ที่เก็บไว้หรือเปลี่ยนจุดหมายแบบ absolute.

ตัวอย่างนี้ต้องการการนำเสนอที่มีลิงก์เชิงสัมพันธ์ เช่น `target.html` และลิงก์แบบ absolute เช่น `https://example.org/absolute.html`. มันอ่านฐานที่มีอยู่, กำหนดฐานใหม่, แล้วบันทึกและเปิดการนำเสนอใหม่เพื่อเช็คค่า. จากนั้นเคลียร์ฐานด้วยสตริงว่างและตรวจสอบค่าที่ว่างในไฟล์บันทึกแยกต่างหาก. แทนที่ฐานตัวอย่างด้วยตำแหน่งของไฟล์ที่เชื่อมโยงของคุณ.

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

สองข้อความตรวจสอบควรพิมพ์ `true`. การเคลียร์ฐานจะทำให้ที่อยู่ลิงก์แต่ละอันยังคงอยู่.

ลิงก์เชิงสัมพันธ์ไปยัง `target.pptx` เปิด `old/target.pptx` เมื่อฐานชี้ไปที่โฟลเดอร์ `old`. หลังจากเปลี่ยนฐานเป็นโฟลเดอร์ `new`, บันทึกและเปิดการนำเสนอใหม่, ลิงก์เดียวกันเปิด `new/target.pptx`. ลิงก์แบบ absolute ยังคงเปิดไฟล์เดิม. ทดสอบลิงก์เชิงสัมพันธ์ของคุณใน PowerPoint ก่อนและหลังย้ายการนำเสนอหรือเปลี่ยนฐาน.

## **เพิ่มคุณสมบัติการนำเสนอแบบกำหนดเอง**

คุณสมบัติที่กำหนดเองเก็บเมตาดาต้าที่ไม่มีฟิลด์ built-in ที่สอดคล้อง. เมธอด [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) ให้คุณกำหนดค่าโดยใช้ชื่อคุณสมบัติ. ตัวอย่างนี้สร้างการนำเสนอ, เพิ่มค่าข้อความสองค่าและค่าเวอร์ชันเป็นจำนวนเต็ม, แล้วบันทึกการนำเสนอด้วย [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save). การกำหนดค่าที่ชื่อที่มีอยู่แล้วจะแทนที่ค่าของคุณสมบัตินั้น.

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

## **เข้าถึงและแก้ไขคุณสมบัติที่กำหนดเอง**

ตัวอย่างนี้เปิดการนำเสนอที่มีคุณสมบัติกำหนดเองและใช้ [getCountOfCustomProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCountOfCustomProperties) เพื่อวนลูปผ่านพวกมัน. [getCustomPropertyName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCustomPropertyName) รับดัชนีตั้งแต่ศูนย์และส่งคืนชื่อที่ใช้โดย [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item). ตัวอย่างพิมพ์ชื่อและค่าต้นฉบับแต่ละรายการ, แทนที่ค่าทั้งหมดด้วยสตริงเลขลำดับโดยไม่คำนึงถึงประเภทเดิม, แล้วบันทึกการเปลี่ยนแปลง. หากไม่มีคุณสมบัติกำหนดเอง, ลูปจะไม่ทำการเปลี่ยนแปลงใดๆ.

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

ลองแอปออนไลน์ [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) เพื่อดูวิธีทำงานกับคุณสมบัติเอกสารโดยใช้ Aspose.Slides API:

[![ดูและแก้ไขเมตาดาต้า PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **คำถามที่พบบ่อย**

**ฉันจะลบคุณสมบัติ built-in ออกจากการนำเสนอได้อย่างไร?**

คุณสมบัติ built-in เป็นส่วนสำคัญของการนำเสนอและไม่สามารถลบออกได้ทั้งหมด. อย่างไรก็ตามคุณสามารถเปลี่ยนค่าเหล่านั้นหรือตั้งค่าเป็นค่าว่างได้หากคุณสมบัตินั้นอนุญาต.

**เกิดอะไรขึ้นหากฉันเพิ่มคุณสมบัติกำหนดเองที่มีอยู่แล้ว?**

หากคุณเพิ่มคุณสมบัติกำหนดเองที่มีอยู่แล้ว, ค่าที่มีอยู่จะถูกเขียนทับด้วยค่าที่ใหม่. คุณไม่จำเป็นต้องลบหรือเช็กคุณสมบัติก่อนหน้า, เนื่องจาก Aspose.Slides จะอัปเดตค่าของคุณสมบัติโดยอัตโนมัติ.

**ฉันสามารถเข้าถึงคุณสมบัติการนำเสนอโดยไม่ต้องโหลดการนำเสนอเต็มได้หรือไม่?**

ได้. ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationFactory#getPresentationInfo) แล้วตามด้วย [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) เพื่ออ่านเมตาดาต้าเอกสารที่จัดเก็บไว้โดยไม่ต้องสร้างออบเจ็กต์ [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). ดู [Build a Lightweight Presentation Inventory](/slides/th/nodejs-java/examine-presentation/) สำหรับตัวอย่างการรายงานอย่างสมบูรณ์และข้อจำกัดตามรูปแบบ.

**ฉันสามารถอ่านคุณสมบัติสาธารณะของการนำเสนอที่เข้ารหัสโดยไม่ต้องใช้รหัสผ่านเปิดได้หรือไม่?**

ได้. การนำเสนอจะต้องถูกเข้ารหัสหลังจากเรียก [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) ด้วย `false`, และต้องโหลดหลังจากเรียก [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) ด้วย `true`.

**ฉันสามารถอัปเดตไฟล์ PPTX ที่เข้ารหัสในโหมด document-properties-only ได้หรือไม่?**

ไม่ได้. ข้อมูลคุณสมบัติสาธารณะและที่เข้ารหัสต้องสอดคล้องกัน, ดังนั้นการอัปเดตไฟล์ PPTX ที่เข้ารหัสต้องโหลดการนำเสนอเต็มด้วยรหัสผ่านเปิดที่ถูกต้อง.