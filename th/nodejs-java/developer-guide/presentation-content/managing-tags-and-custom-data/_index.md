---
title: จัดการแท็กและข้อมูลแบบกำหนดเองในงานนำเสนอโดยใช้ JavaScript
linktitle: แท็กและข้อมูลแบบกำหนดเอง
type: docs
weight: 300
url: /th/nodejs-java/managing-tags-and-custom-data/
keywords:
- คุณสมบัติของเอกสาร
- แท็ก
- ข้อมูลแบบกำหนดเอง
- XML แบบกำหนดเอง
- ส่วน XML แบบกำหนดเอง
- เมตาดาต้า XML
- ItemId
- เพิ่มแท็ก
- ค่าคู่
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีการจัดการแท็กและข้อมูล XML แบบกำหนดเองในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java รวมถึงการเพิ่ม, อ่าน, อัปเดต, ตรวจสอบ, และลบส่วน XML แบบกำหนดเอง."
---
## **ภาพรวม**

บทความนี้อธิบายว่า Aspose.Slides ทำงานกับแท็กและข้อมูลแบบกำหนดเองในงานนำเสนอ PowerPoint อย่างไร ข้อมูลเฉพาะของงานนำเสนอสามารถจัดเก็บเป็นแท็กหรือส่วน XML แบบกำหนดเองได้ แท็กเป็นคู่ค่าสตริงแบบคีย์‑ค่าอย่างง่าย ในขณะที่ส่วน XML แบบกำหนดเองสามารถจัดเก็บเมตาดาต้าแบบมีโครงสร้างและ payload XML เฉพาะแอปพลิเคชัน

Aspose.Slides มี API สำหรับการเพิ่ม, อ่าน, ปรับปรุง, ตรวจสอบและลบส่วน XML แบบกำหนดเองในระดับงานนำเสนอ, สไลด์และรูปร่าง ส่วน XML แบบกำหนดเองมีประโยชน์สำหรับการรวมระบบที่จัดเก็บข้อมูลเช่น ตัวระบุการจัดการเอกสาร, สถานะของเวิร์กโฟลว์, เมตาดาต้าการปฏิบัติตาม, ข้อมูลการผูกเทมเพลต หรือข้อมูลแอปพลิเคชันที่มีโครงสร้างอื่น ๆ ภายในงานนำเสนอ

## **การจัดเก็บข้อมูลในไฟล์งานนำเสนอ**

ไฟล์ PPTX — ไฟล์ที่มีนามสกุล `.pptx` — ถูกจัดเก็บในรูปแบบ PresentationML ซึ่งเป็นส่วนหนึ่งของสเปค Office Open XML Office Open XML กำหนดโครงสร้างแพ็กเกจและความสัมพันธ์ที่ใช้ในการเก็บเนื้อหาและข้อมูลที่เกี่ยวข้องของงานนำเสนอ

งานนำเสนอประกอบด้วยหลายส่วนที่เชื่อมต่อกันด้วยความสัมพันธ์ ตัวอย่างเช่น ส่วนสไลด์จะบรรจุเนื้อหาของสไลด์เดียวและอาจมีความสัมพันธ์โดยชัดเจนกับส่วนอื่น ๆ ตามที่ ISO/IEC 29500 กำหนด

ข้อมูลแบบกำหนดเองสามารถจัดเก็บเป็นแท็ก ([TagCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tagcollection/)) หรือส่วน XML แบบกำหนดเอง ([CustomXmlPartCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/customxmlpartcollection/)) ทั้งสองแบบสามารถเข้าถึงได้ผ่านคลาส [`CustomData`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/customdata/)

{{% alert color="primary" %}}
แท็กจัดเก็บคู่ค่าสตริงแบบคีย์‑ค่าอย่างง่าย ส่วน XML แบบกำหนดเองจัดเก็บข้อมูล XML ที่มีโครงสร้างและสามารถผูกกับงานนำเสนอ, สไลด์ หรือรูปร่างได้
{{% /alert %}}

## **ทำงานกับส่วน XML แบบกำหนดเอง**

เมธอด `getCustomXmlParts()` ของ [`CustomData`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/customdata/) จะคืนค่าคอลเลกชันของส่วน XML แบบกำหนดเองที่เชื่อมโยงกับอ็อบเจ็กต์งานนำเสนอที่ระบุ ตัวอย่างเช่น:

- `presentation.getCustomData().getCustomXmlParts()` มีส่วน XML แบบกำหนดเองที่เชื่อมโยงกับงานนำเสนอเอง
- `slide.getCustomData().getCustomXmlParts()` มีส่วน XML แบบกำหนดเองที่เชื่อมโยงกับสไลด์เฉพาะ
- `shape.getCustomData().getCustomXmlParts()` มีส่วน XML แบบกำหนดเองที่เชื่อมโยงกับรูปร่างเฉพาะ

ใช้ [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) เมื่อคุณต้องการตรวจสอบส่วน XML แบบกำหนดเองทั้งหมดในงานนำเสนอโดยไม่คำนึงว่ามันเชื่อมโยงกับออบเจ็กต์ใด

### **เพิ่มส่วน XML แบบกำหนดเองลงในงานนำเสนอ**

ใช้เมธอด `add` ของ [`CustomXmlPartCollection`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/customxmlpartcollection/) เพื่อเพิ่มข้อมูล XML ลงในคอลเลกชันส่วน XML แบบกำหนดเอง XML ต้องเป็นค่าใช้ได้และไม่ว่างเปล่า

ตัวอย่างต่อไปนี้เพิ่มเมตาดาต้าแบบมีโครงสร้างลงในคอลเลกชันข้อมูลแบบกำหนดเองระดับงานนำเสนอ:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' +
    '<metadata xmlns="urn:example:metadata">' +
        '<documentId>DOC-1001</documentId>' +
        '<workflowState>Draft</workflowState>' +
    '</metadata>';

const presentation = new aspose.slides.Presentation();
try {
    const customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add จะกำหนดตัวระบุโดยอัตโนมัติ. ตั้งค่า UUID เฉพาะเมื่อต้องการเท่านั้น.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("presentation_with_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เมธอด `add` ยังสามารถรับ XML เป็นอาร์เรย์ไบต์ได้ ซึ่งเป็นประโยชน์เมื่อเนื้อหา XML มีอยู่แล้วในรูปแบบไบนารี

### **เพิ่มส่วน XML แบบกำหนดเองลงในสไลด์หรือรูปร่าง**

ข้อมูล XML แบบกำหนดเองสามารถผูกกับสไลด์หรือรูปร่างเฉพาะแทนการผูกกับงานนำเสนอทั้งหมด ซึ่งมีประโยชน์เมื่อเมตาดาต้าอธิบายเฉพาะอ็อบเจ็กต์หนึ่ง เช่น คีย์เทมเพลต, ตัวระบุบันทึกภายนอก หรือข้อมูลการผูก

ตัวอย่างต่อไปนี้เพิ่มส่วน XML แบบกำหนดเองหนึ่งส่วนลงในสไลด์และอีกส่วนหนึ่งลงในรูปร่าง:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        '<slideMetadata xmlns="urn:example:slides">' +
            '<templateKey>TitleSlide</templateKey>' +
        '</slideMetadata>');

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        '<shapeMetadata xmlns="urn:example:shapes">' +
            '<recordId>CRM-4281</recordId>' +
        '</shapeMetadata>');

    presentation.save("object_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ระดับที่ส่วนถูกเพิ่มจะกำหนดว่าคอลเลกชัน `getCustomData().getCustomXmlParts()` ของอ็อบเจ็กต์ใดบ้างที่จะมีความสัมพันธ์กับส่วนนั้น ข้อมูลระดับงานนำเสนอเหมาะสำหรับเมตาดาต้าระดับเอกสารทั้งหมด ข้อมูลระดับสไลด์เหมาะสำหรับข้อมูลที่เป็นของสไลด์เฉพาะ และข้อมูลระดับรูปร่างเหมาะสำหรับเมตาดาต้าที่ผูกกับรูปร่างแต่ละอัน

### **แสดงรายการและตรวจสอบส่วน XML แบบกำหนดเองทั้งหมด**

ใช้ [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) เพื่อดึงส่วน XML แบบกำหนดเองทั้งหมดจากงานนำเสนอ แต่ละอ็อบเจ็กต์ [`CustomXmlPart`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/customxmlpart/) จะเปิดเผยตัวระบุ, เนื้อหา XML และสคีมเนมสเปซที่เชื่อมโยง

ตัวอย่างต่อไปนี้แสดงรายการส่วน XML แบบกำหนดเองทั้งหมดพร้อมสคีมเนมสเปซ:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        const customXmlPart = customXmlParts[partIndex];

        console.log("ItemId: " + customXmlPart.getItemId());
        console.log("XML:");
        console.log(customXmlPart.getXmlAsString());

        const namespaceSchemas = customXmlPart.getNamespaceSchemas();
        for (let schemaIndex = 0; schemaIndex < namespaceSchemas.length; schemaIndex++) {
            console.log("Namespace schema: " + namespaceSchemas[schemaIndex]);
        }

        console.log();
    }
} finally {
    presentation.dispose();
}
```

เมธอด [`CustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/customxmlpart/) จะคืนค่าสคีม XML ที่เชื่อมโยงกับส่วน XML แบบกำหนดเอง ข้อมูลนี้อาจเป็นประโยชน์เมื่อทำการตรวจสอบงานนำเสนอที่มี XML มาจากระบบภายนอก

### **อ่านและอัปเดตเนื้อหา XML และ ItemId**

ใช้ `getXmlAsString()` และ `setXmlAsString()` จาก [`CustomXmlPart`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/customxmlpart/) เพื่อทำงานกับ XML ในรูปแบบสตริง UTF‑8 หรือใช้ `getXmlData()` และ `setXmlData()` เพื่อทำงานกับไบต์ XML ดิบ

เมธอด `getItemId()` จะคืนค่า UUID ที่ระบุส่วน XML แบบกำหนดเองในเอกสาร Office Open XML ใช้ `setItemId()` เมื่อการบูรณาการต้องการตัวระบุใหม่

ตัวอย่างต่อไปนี้อัปเดตเนื้อหา XML และตัวระบุ:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlPart = presentation.getAllCustomXmlParts()[0];

    // อ่าน XML ปัจจุบันเป็นข้อความ.
    const currentXmlContent = customXmlPart.getXmlAsString();
    console.log(currentXmlContent);

    // อัปเดต XML เป็นสตริง UTF-8.
    customXmlPart.setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' +
            '<documentId>DOC-1001</documentId>' +
            '<workflowState>Approved</workflowState>' +
        '</metadata>');

    // getXmlData ให้เนื้อหา XML แบบเดียวกันเป็นไบต์ดิบ.
    const customXmlData = customXmlPart.getXmlData();
    console.log(Buffer.from(customXmlData).toString("utf8"));

    // เปลี่ยนตัวระบุเมื่อการบูรณาการต้องการ.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("updated_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เมื่อเรียก `setXmlAsString` หรือ `setXmlData` ให้ระบุ XML ที่ใช้ได้และไม่ว่างเปล่า ใช้รูปแบบใดรูปแบบหนึ่งขึ้นอยู่กับแอปพลิเคชันทำงานหลักกับสตริงหรือไบต์ข้อมูล

### **ลบส่วน XML แบบกำหนดเอง**

Aspose.Slides มีหลายวิธีสำหรับลบข้อมูล XML แบบกำหนดเอง:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/customxmlpart/) ลบส่วน XML แบบกำหนดเองจากงานนำเสนอ
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/customxmlpartcollection/) ลบส่วนเฉพาะจากคอลเลกชันส่วน XML แบบกำหนดเอง
- [`CustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/customxmlpartcollection/) ลบส่วนที่ตำแหน่งอินเดกซ์ที่ระบุในคอลเลกชัน
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/customxmlpartcollection/) ลบทุกส่วนจากคอลเลกชันที่ระบุ

ตัวอย่างต่อไปนี้ลบส่วน XML แบบกำหนดเองระดับงานนำเสนอหนึ่งส่วนโดยอ้างอิง:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        const customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากคุณมีอ็อบเจ็กต์ `CustomXmlPart` อยู่แล้วและต้องการลบส่วนนั้นจากงานนำเสนอแทนการอ้างอิงคอลเลกชัน ให้เรียก `customXmlPart.remove()`  

คุณยังสามารถลบรายการโดยอินเดกซ์ได้อีกด้วย:

```javascript
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **ล้างส่วน XML แบบกำหนดเองทั้งหมดจากคอลเลกชัน**

ใช้ `clear` เมื่อส่วน XML แบบกำหนดเองทั้งหมดที่เชื่อมโยงกับอ็อบเจ็กต์งานนำเสนอใด ๆ ควรถูกลบ

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` มีผลเฉพาะกับคอลเลกชันที่เลือก ตัวอย่างเช่น การล้างคอลเลกชันของสไลด์จะไม่ล้างคอลเลกชันระดับงานนำเสนอหรือระดับรูปร่าง

หากต้องการลบส่วน XML แบบกำหนดเองทุกส่วนในงานนำเสนอ ให้วนลูปผ่าน `getAllCustomXmlParts()` และลบแต่ละส่วน:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        customXmlParts[partIndex].remove();
    }

    presentation.save("all_custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **จัดการส่วน XML แบบกำหนดเองที่เชื่อมโยงหรือใช้ร่วมกัน**

ในงานนำเสนอ Office Open XML ส่วน XML แบบกำหนดเองเดียวกันอาจถูกอ้างอิงจากอ็อบเจ็กต์งานนำเสนอหลายอัน ตัวอย่างเช่นไฟล์ที่มีอยู่แล้วอาจมีความสัมพันธ์จากหลายสไลด์หรือรูปร่างไปยังส่วน XML แบบกำหนดเองเดียวกัน

ส่วนที่ใช้ร่วมกันควรถือเป็นออบเจ็กต์ข้อมูลหนึ่งที่มีหลายการอ้างอิง:

- การอัปเดตด้วย `setXmlAsString`, `setXmlData` หรือ `setItemId` จะเปลี่ยนส่วน XML แบบกำหนดเองพื้นฐาน ดังนั้นการเปลี่ยนแปลงจะส่งผลทุกที่ที่ส่วนนั้นถูกอ้างอิง
- `getItemId()` สามารถใช้ระบุส่วน XML แบบกำหนดเองเดียวกันขณะตรวจสอบคอลเลกชันระดับอ็อบเจ็กต์
- การลบส่วนจากคอลเลกชัน `getCustomXmlParts()` เฉพาะจะลบส่วนนั้นออกจากคอลเลกชันนั้น ใช้ `CustomXmlPart.remove()` เมื่อส่วนเองควรถูกลบออกจากงานนำเสนอ
- ก่อนลบหรือแทนที่ส่วนที่ใช้ร่วมกัน ให้ตรวจสอบคอลเลกชันระดับอ็อบเจ็กต์เพื่อดูว่ายังมีสไลด์หรือรูปร่างอื่นที่อ้างอิงอยู่หรือไม่

เมธอด `add` overload จะสร้างส่วน XML แบบกำหนดใหม่จากเนื้อหา XML; มันไม่รับ `CustomXmlPart` ที่มีอยู่แล้ว ดังนั้นความสัมพันธ์ที่ใช้ร่วมกันมักพบเมื่อโหลดงานนำเสนอที่มีส่วนเหล่านั้นแล้ว

ตัวอย่างต่อไปนี้ตรวจสอบคอลเลกชันระดับงานนำเสนอ, สไลด์และรูปร่างโดย `ItemId` และรายงานส่วนที่ถูกอ้างอิงจากหลายตำแหน่ง:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const referencesByItemId = new Map();

    const registerCustomXmlParts = (ownerName, customXmlParts) => {
        for (let partIndex = 0; partIndex < customXmlParts.size(); partIndex++) {
            const customXmlPart = customXmlParts.get_Item(partIndex);
            const itemId = customXmlPart.getItemId().toString();

            if (!referencesByItemId.has(itemId)) {
                referencesByItemId.set(itemId, []);
            }

            referencesByItemId.get(itemId).push(ownerName);
        }
    };

    registerCustomXmlParts("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        registerCustomXmlParts("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);

            registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (const [itemId, owners] of referencesByItemId) {
        if (owners.length > 1) {
            console.log("Shared custom XML part: " + itemId);

            for (const ownerName of owners) {
                console.log("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

การตรวจสอบประเภทนี้มีประโยชน์ก่อนทำการแก้ไขหรือลบข้อมูล XML แบบกำหนดเองในงานนำเสนอที่สร้างโดยระบบภายนอก เนื่องจากส่วนเมตาดาต้าเดียวกันอาจมีส่วนร่วมในความสัมพันธ์มากกว่าหนึ่งที่

## **รับค่าของแท็ก**

ใน Slides แท็กสอดคล้องกับเมธอด `DocumentProperties.getKeywords()` ตัวอย่างโค้ดนี้แสดงวิธีดึงค่าของแท็กด้วย Aspose.Slides for Node.js via Java สำหรับ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **เพิ่มแท็กในงานนำเสนอ**

Aspose.Slides อนุญาตให้คุณเพิ่มแท็กในงานนำเสนอ แท็กโดยทั่วไปประกอบด้วยสองรายการ:

- ชื่อของคุณสมบัติแบบกำหนดเอง เช่น `MyTag`;
- ค่าของคุณสมบัติแบบกำหนดเอง เช่น `My Tag Value`.

หากต้องการจัดประเภทงานนำเสนอโดยกฎหรือคุณสมบัติเฉพาะ คุณสามารถเพิ่มแท็กเพื่อวัตถุประสงค์นั้นได้ ตัวอย่างเช่น หากต้องการจัดกลุ่มงานนำเสนอจากประเทศในอเมริกาเหนือ คุณสามารถสร้างแท็ก North American และกำหนดค่าประเทศที่เกี่ยวข้องเป็นค่า

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่มแท็กใน [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) ด้วย Aspose.Slides for Node.js via Java:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

แท็กยังสามารถตั้งค่าสำหรับ [Slide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/) ได้ด้วย:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

หรือสำหรับ [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) รายบุคคล:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);

    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **ข้อจำกัด**

แท็กที่เพิ่มผ่านคอลเลกชัน `getCustomData().getTags()` จะถูกจัดเก็บไว้เฉพาะในไฟล์ PowerPoint เท่านั้น พวกมัน **จะไม่** ถูกโอนไปยังโครงสร้างแท็ก PDF เมื่อส่งออกงานนำเสนอเป็น PDF ดังนั้น ตัวระบุแบบกำหนดเองที่กำหนดเป็นแท็กจะไม่สามารถดึงคืนจาก PDF ที่มีแท็กได้

**วิธีแก้**: คุณสามารถเก็บตัวระบุแบบกำหนดเองใน **Alt Text** ของอ็อบเจ็กต์ (เช่น `shape.setAlternativeText("MyId")`) หลังจากส่งออกเป็น PDF Alt Text อาจปรากฏในโครงสร้างแท็กของ PDF

## **คำถามที่พบบ่อย**

**ฉันสามารถลบแท็กทั้งหมดจากงานนำเสนอ, สไลด์ หรือรูปร่างในขั้นตอนเดียวได้หรือไม่?**

ได้เลย คอลเลกชัน [tag collection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tagcollection/) รองรับการทำงาน [clear](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tagcollection/) ที่ลบคู่คีย์‑ค่าทั้งหมดพร้อมกัน

**ฉันจะลบแท็กเดี่ยวโดยใช้ชื่อของมันโดยไม่ต้องวนลูปคอลเลกชันทั้งหมดอย่างไร?**

ใช้ `remove(name)` บน [tag collection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tagcollection/) เพื่ออ้างอิงแท็กโดยคีย์ของมัน

**ฉันจะดึงรายการชื่อแท็กทั้งหมดเพื่อการวิเคราะห์หรือกรองได้อย่างไร?**

ใช้ `getNamesOfTags()` บน [tag collection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tagcollection/) จะได้อาร์เรย์ของชื่อแท็กทั้งหมด

**ฉันจะค้นหาส่วน XML แบบกำหนดเองทั้งหมดโดยไม่คำนึงว่าถูกเก็บไว้ที่ไหน?**

ใช้ [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) เพื่อดึงส่วน XML แบบกำหนดเองทั้งหมดในงานนำเสนอ

**ควรใช้ `getXmlAsString`/`setXmlAsString` หรือ `getXmlData`/`setXmlData` เพื่ออัปเดตส่วน XML แบบกำหนดเอง?**

ใช้ `getXmlAsString` และ `setXmlAsString` เมื่อแอปพลิเคชันทำงานกับข้อความ XML แบบ UTF‑8 ใช้ `getXmlData` และ `setXmlData` เมื่อ XML มีอยู่แล้วในรูปแบบอาเรย์ไบต์หรือเมื่อการประมวลผลเชิงไบต์สะดวกกว่า ทั้งสองรูปแบบอ้างอิงถึงเนื้อหา XML ของส่วน XML แบบกำหนดเดียวกัน