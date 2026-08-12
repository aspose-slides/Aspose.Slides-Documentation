---
title: จัดการ Sensitivity Labels ในงานนำเสนอ PowerPoint ด้วย JavaScript
linktitle: เลเบลความละเอียด
type: docs
weight: 50
url: /th/nodejs-java/sensitivity-labels/
keywords:
- เลเบลความละเอียด
- Microsoft Purview
- Microsoft Information Protection
- เมตาดาต้า MIP
- การทำเครื่องหมายเนื้อหา
- การปกป้องข้อมูล
- การกำกับดูแลเอกสาร
- PowerPoint
- PPTX
- ความปลอดภัยของงานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "อ่าน, เพิ่ม, ปรับปรุง, ลบ, และย้ายเลเบลความละเอียดของ Microsoft Purview ในงานนำเสนอ PowerPoint PPTX ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **ภาพรวม**

Microsoft Purview sensitivity labels ช่วยองค์กรจำแนกและควบคุมเอกสาร ระหว่างการประมวลผลงานนำเสนออัตโนมัติ แอปพลิเคชันอาจต้องคงรักษาเลเบลที่มีอยู่แล้ว ใช้เลเบลที่นโยบายเลือกไว้ ปรับสถานะ หรือย้ายข้อมูลเมตาเลเบลที่เขียนโดยขั้นตอนการทำงานของ Microsoft Information Protection (MIP) รุ่นเก่า

Aspose.Slides for Node.js via Java เปิดเผยข้อมูลเมตาเลเบลความละเอียดใหม่ผ่าน [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) วิธีนี้จะคืนค่า [SensitivityLabelCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabelcollection/) ที่สามารถตรวจสอบและแก้ไขก่อนบันทึกงานนำเสนอเป็น PPTX

{{% alert color="primary" title="Note" %}}
ตัวระบุเลเบลความละเอียดและข้อมูลนโยบายถูกกำหนดโดยการกำหนดค่า Microsoft Purview ของคุณ ตรวจสอบความพร้อมของเลเบลและข้อกำหนดนโยบายในสภาพแวดล้อมของคุณก่อนเพิ่มหรือย้ายข้อมูลเมตา ค่าของ [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) บรรยายการทำเครื่องหมายเนื้อหาที่เชื่อมโยงกับเลเบล; ค่านี้ไม่ได้เพิ่มข้อความหรือรูปร่างที่มองเห็นได้ลงในสไลด์
{{% /alert %}}

## **ทำความเข้าใจคุณสมบัติของ Sensitivity Label**

แต่ละ [SensitivityLabel](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabel/) มีเมตาดาต้าดังต่อไปนี้:

| Methods | Purpose |
| --- | --- |
| [SensitivityLabel.getId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabel/#getId) and [SensitivityLabel.setId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabel/#setId) | รับหรือกำหนดตัวระบุเลเบลความละเอียดในนโยบาย Purview |
| [SensitivityLabel.getSiteId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabel/#getSiteId) and [SensitivityLabel.setSiteId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabel/#setSiteId) | รับหรือกำหนดไซต์ที่เชื่อมโยงกับนโยบายเลเบล |
| [SensitivityLabel.isEnabled](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabel/#isEnabled) and [SensitivityLabel.setEnabled](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabel/#setEnabled) | รับหรือกำหนดว่าเลเบลถูกเปิดใช้งานหรือไม่ |
| [SensitivityLabel.isRemoved](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabel/#isRemoved) and [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) | รับหรือกำหนดว่าเลเบลถูกลบหรือไม่ กำหนดค่าเป็น `true` เมื่อสถานะการลบต้องถูกเก็บไว้ในเมตาดาต้า |
| [SensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) and [SensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | รับหรือกำหนดว่าเลเบลถูกนำไปใช้โดยอัตโนมัติหรือโดยการตัดสินใจของผู้ใช้ |
| [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | รับประเภทการทำเครื่องหมายเนื้อหาที่เชื่อมโยงกับเลเบล |

คลาส [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) กำหนดวิธีการที่เลเบลถูกกำหนด:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) แสดงถึงเลเบลเริ่มต้นหรือที่ถูกนำไปใช้โดยอัตโนมัติ
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) แสดงถึงเลเบลที่ถูกนำไปใช้โดยการตัดสินใจของผู้ใช้ รวมถึงเลเบลที่นำไปใช้ด้วยตนเอง, ที่แนะนำ, และที่บังคับใช้

คลาส [SensitivityLabelContentType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) กำหนดการทำเครื่องหมายที่เชื่อมโยงกับเลเบล:

| Value | Meaning |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | เลเบลถูกนำไปใช้เป็นค่าปริยายหรือโดยอัตโนมัติ |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | มีการทำเครื่องหมายเนื้อหาหัวเรื่องที่เชื่อมโยงกับเลเบล |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | มีการทำเครื่องหมายเนื้อหาท้ายกระดาษที่เชื่อมโยงกับเลเบล |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | มีการทำเครื่องหมายเนื้อหาน้ำหมึกที่เชื่อมโยงกับเลเบล |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | มีการปกป้องด้วยการเข้ารหัสที่เชื่อมโยงกับเลเบล |

หลายประเภทการทำเครื่องหมายสามารถเชื่อมโยงกับเลเบลเดียวกันได้

## **รายชื่อ Sensitivity Labels ที่มีอยู่**

อ่านคอลเลกชันเลเบลสมัยใหม่จาก [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) แล้วทำการวนลูป ตัวอย่างต่อไปนี้จะแสดงทุกคุณสมบัติและการทำเครื่องหมายเนื้อหาที่จัดเก็บสำหรับแต่ละเลเบล:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const siteIdentifier = sensitivityLabel.getSiteId();
        const isEnabled = sensitivityLabel.isEnabled();
        const isRemoved = sensitivityLabel.isRemoved();
        const assignmentMethod = sensitivityLabel.getAssignmentMethodType();

        console.log("Label ID: " + labelIdentifier);
        console.log("Site ID: " + siteIdentifier);
        console.log("Enabled: " + isEnabled);
        console.log("Removed: " + isRemoved);
        console.log("Assignment method: " + assignmentMethod);

        const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
        const contentMarkCount = contentMarkTypes.size();

        for (let contentMarkIndex = 0; contentMarkIndex < contentMarkCount; contentMarkIndex++) {
            const contentMarkType = contentMarkTypes.get_Item(contentMarkIndex);
            console.log("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **เพิ่ม Sensitivity Label พร้อมการทำเครื่องหมายเนื้อหา**

ใช้ [SensitivityLabelCollection.add](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) พร้อมตัวระบุเลเบล, ตัวระบุไซต์, สถานะเปิดใช้งาน, และวิธีการกำหนด หลังจากเมธอดคืนค่า [SensitivityLabel](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabel/) ใหม่ ให้เพิ่มค่าการทำเครื่องหมายที่ต้องการผ่านรายการที่คืนจาก [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes)

ตัวอย่างต่อไปนี้เพิ่มเลเบลที่เลือกด้วยตนเองซึ่งเชื่อมโยงกับการทำเครื่องหมายที่ท้ายกระดาษและน้ำหมึก แล้วบันทึกผลลัพธ์เป็น PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();

    const labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const siteIdentifier = java.callStaticMethodSync(
        "java.util.UUID",
        "fromString",
        "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    const isEnabled = true;
    const assignmentMethod = aspose.slides.SensitivityLabelAssignmentType.Privileged;

    const sensitivityLabel = sensitivityLabels.add(
        labelIdentifier,
        siteIdentifier,
        isEnabled,
        assignmentMethod);

    const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Footer);
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **อัปเดต Sensitivity Label**

ค่าของ [SensitivityLabel](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabel/) สามารถอ่าน/เขียนได้ ยกเว้นรายการที่คืนจาก [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) ซึ่งต้องแก้ไขผ่านการดำเนินการของรายการ หลังจากค้นหาเลเบลที่ต้องการ คุณสามารถอัปเดตตัวระบุ, ตัวระบุไซต์, สถานะเปิดใช้งาน, วิธีการกำหนด, สถานะการลบ และประเภทการทำเครื่องหมายเนื้อหา แล้วบันทึกงานนำเสนอเพื่อบันทึกการเปลี่ยนแปลง

ตัวอย่างต่อไปนี้อัปเดตสถานะเปิดใช้งานและวิธีการกำหนดของเลเบลแรก:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    if (labelCount > 0) {
        const sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(
            aspose.slides.SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ทำเครื่องหมาย Sensitivity Label ว่า ถูกลบ**

เพื่อคงไว้ซึ่งข้อเท็จจริงว่าเลเบลถูกลบ ให้ค้นหาเลเบลและเรียก [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) ด้วยค่า `true` การทำเช่นนี้จะคงรายการเลเบลไว้พร้อมบันทึกสถานะการลบ หากคุณต้องการลบรายการออกจากคอลเลกชันสมัยใหม่ ให้ใช้ [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt); ใช้ [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabelcollection/#clear) เพื่อลบทุกรายการ

ตัวอย่างต่อไปนี้ทำเครื่องหมายเลเบลเฉพาะว่าถูกลบและบันทึกงานนำเสนอที่อัปเดตแล้ว:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const isTargetLabel = labelIdentifier.toLowerCase() === targetLabelIdentifier.toLowerCase();

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **อ่านและย้าย Sensitivity Labels จากระบบ MIP เก่า**

ขั้นตอนการทำงานที่ใช้ MIP รุ่นเก่าสามารถเก็บเมตาดาต้าเลเบลความละเอียดในคุณสมบัติเสริมของเอกสารแทนคอลเลกชันเลเบลสมัยใหม่ อ่านเมตาดาต้านั้นด้วย [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels) เมธอดจะวิเคราะห์คุณสมบัติเสริมแบบเก่าและคืนอาร์เรย์ของอ็อบเจ็กต์ [SensitivityLabel](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabel/)

เพื่อย้ายเมตาดาต้า ให้เพิ่มแต่ละเลเบลที่คืนค่ามาเข้าใน [SensitivityLabelCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabelcollection/) สมัยใหม่ผ่าน [SensitivityLabelCollection.add](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) เนื่องจากการเพิ่มเลเบลที่ซ้ำกันจะทำให้เกิดข้อยกเว้น ตัวอย่างจึงตรวจสอบคอลเลกชันปลายทางก่อนคัดลอกแต่ละเลเบล คุณสามารถเพิ่มการตรวจสอบเพิ่มเติมเพื่อยืนยันว่าเลเบลเก่ายังคงอยู่ในนโยบาย Purview ปัจจุบันหรือไม่

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation_with_legacy_labels.pptx");
try {
    const legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    const modernSensitivityLabels = presentation.getSensitivityLabels();

    for (let legacyLabelIndex = 0; legacyLabelIndex < legacySensitivityLabels.length; legacyLabelIndex++) {
        const legacySensitivityLabel = legacySensitivityLabels[legacyLabelIndex];
        const legacyLabelIdentifier = legacySensitivityLabel.getId();
        const modernLabelCount = modernSensitivityLabels.getCount();
        let labelAlreadyExists = false;

        for (let modernLabelIndex = 0; modernLabelIndex < modernLabelCount; modernLabelIndex++) {
            const modernSensitivityLabel = modernSensitivityLabels.get_Item(modernLabelIndex);
            const modernLabelIdentifier = modernSensitivityLabel.getId();

            labelAlreadyExists =
                modernLabelIdentifier.toLowerCase() === legacyLabelIdentifier.toLowerCase();

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การย้ายจะคัดลอกอ็อบเจ็กต์เลเบลที่วิเคราะห์แล้วไปยังคอลเลกชันสมัยใหม่ ไม่จำเป็นต้องล้างคุณสมบัติเสริมทั้งหมดของเอกสาร ดังนั้นเมตาดาต้าเอกสารที่ไม่เกี่ยวข้องจะยังคงอยู่ ใช้ [Presentation.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#save) พร้อม [SaveFormat.Pptx](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/saveformat/) เพื่อเขียนเมตาดาต้าเลเบลสมัยใหม่ลงในไฟล์ PPTX

## **FAQ**

**การเพิ่มประเภทการทำเครื่องหมายเนื้อหา จะสร้างหัวเรื่อง, ท้ายกระดาษ หรือสลิปน้ำหมึกที่มองเห็นได้บนสไลด์หรือไม่?**

ไม่ ค่าเหล่านี้ถูกเพิ่มผ่านรายการที่คืนจาก [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) เพียงแค่บรรยายการทำเครื่องหมายที่เชื่อมโยงกับเลเบลความละเอียด ไม่ได้สร้างข้อความหรือรูปร่างที่มองเห็นได้ในงานนำเสนอ ให้เพิ่มเนื้อหาสไลด์ที่สอดคล้องกันแยกต่างหากหากเวิร์กโฟลว์ของคุณต้องแสดงการทำเครื่องหมายเหล่านั้น

**ความแตกต่างระหว่างการทำเครื่องหมายเลเบลว่า ถูกลบ กับการลบออกจากคอลเลกชันคืออะไร?**

เรียก [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) ด้วย `true` จะคงรายการเลเบลและบันทึกสถานะการลบ ส่วนการเรียก [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt) จะลบรายการออกจากคอลเลกชันสมัยใหม่ เลือกการกระทำที่สอดคล้องกับข้อกำหนดการเก็บรักษาเมตาดาต้าขององค์กรของคุณ

**งานนำเสนอสามารถมีเมตาดาต้า MIP แบบเก่าและเลเบลความละเอียดสมัยใหม่พร้อมกันได้หรือไม่?**

ได้ เลเบลแบบเก่าสามารถคงอยู่ในคุณสมบัติเสริมของเอกสารขณะที่เลเบลสมัยใหม่สามารถเข้าถึงได้ผ่าน [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) ใช้ [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels) เพื่ออ่านเมตาดาต้าแบบเก่าและย้ายเฉพาะเลเบลที่ยังไม่มีอยู่ในคอลเลกชันสมัยใหม่

**เมื่อเลเบลที่มีตัวระบุเดียวกันถูกเพิ่มหลายครั้ง จะเกิดอะไรขึ้น?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) จะยกข้อยกเว้นเมื่อคอลเลกชันมีเลเบลที่มีตัวระบุเดียวกันอยู่แล้ว ตรวจสอบค่าที่มีอยู่แล้วโดยใช้ [SensitivityLabel.getId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sensitivitylabel/#getId) ก่อนทำการเพิ่มหรือย้ายเลเบล

**ควรใช้รูปแบบไฟล์ใดเพื่อรักษาเลเบลความละเอียดที่อัปเดต?**

บันทึกงานนำเสนอเป็น PPTX โดยเรียก [Presentation.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#save) พร้อม [SaveFormat.Pptx](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/saveformat/) ตามที่แสดงในตัวอย่างข้างต้น