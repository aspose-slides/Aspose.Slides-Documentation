---
title: กำหนดรูปแบบพรีเซนเทชันต้นฉบับใน Node.js
linktitle: รูปแบบแหล่งที่มา
type: docs
weight: 35
url: /th/nodejs-java/detect-presentation-source-format/
keywords:
- รูปแบบแหล่งที่มา
- ตรวจจับรูปแบบพรีเซนเทชัน
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "อ่านรูปแบบต้นฉบับของพรีเซนเทชันที่โหลดใน Node.js ด้วย Aspose.Slides for Node.js ผ่าน Java, เปรียบเทียบ API การตรวจจับ, และจัดการไฟล์, สตรีม, และรูปแบบดั้งเดิม."
---
## **ภาพรวม**

หลังจากโหลดพรีเซนเทชันแล้ว ให้เรียกเมธอด [Presentation.getSourceFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getSourceFormat) เพื่อตรวจสอบรูปแบบเดิมของพรีเซนเทชัน ใช้เมธอดนี้เมื่อการประมวลผลต่อไปขึ้นอยู่กับรูปแบบที่อินสแตนซ์ปัจจุบันถูกโหลดมาจาก

รูปแบบแหล่งที่มานั้นแตกต่างจาก [SaveFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/saveformat/) ที่เลือกสำหรับไฟล์ผลลัพธ์ การบันทึกเป็นรูปแบบอื่นจะไม่ได้เปลี่ยนรูปแบบแหล่งที่มาของอินสแตนซ์ที่มีอยู่

## **อ่านรูปแบบแหล่งที่มาของไฟล์**

ตัวอย่างนี้ต้องการไฟล์ `sample.pptx` ที่มีอยู่แล้ว จะโหลดไฟล์และเลือกนโยบายการประมวลผลของแอปพลิเคชันโดยใช้ [Presentation.getSourceFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getSourceFormat) แทนการอ้างอิงจากชื่อไฟล์ เปลี่ยนเส้นทางอินพุตเพื่อทดสอบรูปแบบอื่น ตัวอย่างจะแสดงนโยบายที่เลือก; สามารถแทนข้อความเหล่านี้ด้วยตรรกะของแอปพลิเคชันของคุณได้

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
        case aspose.SourceFormat.Pps:
        case aspose.SourceFormat.Pot:
            console.log("Use the legacy PowerPoint processing policy.");
            break;
        case aspose.SourceFormat.Pptx:
            console.log("Use the standard PPTX processing policy.");
            break;
        default:
            console.log("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **รู้จักค่าที่รองรับ**

คลาส [SourceFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sourceformat/) กำหนดค่าคงที่จำนวนเต็มที่แยกรูปแบบพรีเซนเทชันต่าง ๆ ด้านล่างเป็นนามสกุลที่เป็นที่ยอมรับ, ไม่ได้เป็นการสร้างชื่อไฟล์เดิมใหม่

| ค่า SourceFormat | นามสกุล | รูปแบบ |
| --- | --- | --- |
| `Ppt` | `.ppt` | การนำเสนอ PowerPoint 97–2003 |
| `Pptx` | `.pptx` | การนำเสนอ Office Open XML |
| `Pptm` | `.pptm` | การนำเสนอ Office Open XML ที่มีแมโคร |
| `Pps` | `.pps` | การแสดงสไลด์ PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | การแสดงสไลด์ Office Open XML |
| `Ppsm` | `.ppsm` | การแสดงสไลด์ Office Open XML ที่มีแมโคร |
| `Pot` | `.pot` | แม่แบบ PowerPoint 97–2003 |
| `Potx` | `.potx` | แม่แบบ Office Open XML |
| `Potm` | `.potm` | แม่แบบ Office Open XML ที่มีแมโคร |
| `Odp` | `.odp` | การนำเสนอ OpenDocument |
| `Otp` | `.otp` | แม่แบบการนำเสนอ OpenDocument |
| `Fodp` | `.fodp` | การนำเสนอ Flat XML ODF |
| `Xml` | `.xml` | การนำเสนอ PowerPoint XML |

## **อ่านรูปแบบแหล่งที่มาของสตรีม**

ตัวอย่างนี้ต้องการไฟล์ `sample.pps` ที่มีอยู่แล้ว การอ่านไบต์ของไฟล์นี้ใส่ลงใน MemoryStream จำลองสถานการณ์ที่รับข้อมูลโดยไม่มีชื่อไฟล์ เช่น ค่าที่เก็บในฐานข้อมูลหรืออาร์เรย์ไบต์ที่อัปโหลด ตัวคอนสตรัคเตอร์ของ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) จะรับเฉพาะสตรีมเท่านั้น

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const buffer = fs.readFileSync("sample.pps");
const bytes = java.newArray("byte", Array.from(buffer));
const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
try {
    const presentation = new aspose.Presentation(stream);
    try {
        console.log("Source format: " + presentation.getSourceFormat());
    } finally {
        presentation.dispose();
    }
} finally {
    stream.close();
}
```

PPT, PPS และ POT ใช้รูปแบบไบนารีพื้นฐานเดียวกัน เมื่อโหลดโดยเส้นทางไฟล์ นามสกุลสามารถช่วยแยกสไลด์โชว์หรือแม่แบบได้ หากไม่มีชื่อไฟล์ เนื้อหา PPS หรือ POT แบบดั้งเดิมอาจถูกรายงานเป็น `SourceFormat.Ppt`; ตัวอย่าง PPS ด้านบนจะแสดงค่าจำนวนเต็มของ `SourceFormat.Ppt`

หากแอปพลิเคชันของคุณต้องคงความแตกต่างนี้ไว้ ควรเก็บชื่อไฟล์เดิมหรือเมตาดาต้าย่อยแยกต่างหาก นามสกุลเป็นสัญญาณที่เป็นประโยชน์สำหรับย่อยแบบดั้งเดิมเหล่านี้แต่ไม่ควรเป็นฐานเดียวในการระบุเนื้อหาพรีเซนเทชันใด ๆ

## **เปรียบเทียบการตรวจจับก่อนและหลังการโหลด**

ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) และ [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/#getLoadFormat) เมื่อต้องการตรวจสอบไฟล์ก่อนโหลดโมเดลอ็อบเจ็กต์ของพรีเซนเทชันทั้งหมด ใช้ [Presentation.getSourceFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getSourceFormat) เมื่ออินสแตนซ์มีอยู่แล้ว

ตัวอย่างนี้ต้องการ `sample.pptx` และจะแสดงค่าจำนวนเต็มของ `LoadFormat.Pptx` และ `SourceFormat.Pptx` ตามลำดับ ในการใช้งานจริง ให้เลือก API ที่เหมาะสมกับขั้นตอนการประมวลผลของคุณ; พรีเซนเทชันที่โหลดแล้วไม่จำเป็นต้องตรวจสอบอีกครั้งเพียงเพื่อรับรูปแบบแหล่งที่มา

```javascript
const aspose = require("aspose.slides.via.java");

const path = "sample.pptx";
const information = aspose.PresentationFactory.getInstance().getPresentationInfo(path);
console.log("Before loading: " + information.getLoadFormat());

const presentation = new aspose.Presentation(path);
try {
    console.log("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

ผลลัพธ์ใช้ค่าคงที่จากคลาสต่าง ๆ: [LoadFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadformat/) และ [SourceFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sourceformat/) อย่าเปรียบเทียบค่าตัวเลขของพวกมันหรือสันนิษฐานว่าทุกรูปแบบมีผลลัพธ์การตรวจจับที่เท่ากัน PowerPoint XML อาจถูกรายงานเป็น `LoadFormat.Unknown` ก่อนการโหลดและ `SourceFormat.Xml` หลังการโหลด

## **แยกรูปแบบแหล่งที่มาและรูปแบบผลลัพธ์ออกจากกัน**

ตัวอย่างนี้ต้องการ `sample.pptx` และเขียนไฟล์ `converted.odp` จะพิมพ์ค่าจำนวนเต็มของ `SourceFormat.Pptx` ก่อนและหลังการบันทึกอินสแตนซ์ต้นฉบับ อินสแตนซ์ใหม่ที่โหลดจากผลลัพธ์ ODP จะรายงานค่า `Odp`

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    console.log("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", aspose.SaveFormat.Odp);
    console.log("After saving: " + presentation.getSourceFormat());

    const reopened = new aspose.Presentation("converted.odp");
    try {
        console.log("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

พรีเซนเทชันที่สร้างจากศูนย์ด้วย `new Presentation()` จะรายงาน `SourceFormat.Pptx` เนื่องจากไม่มีไฟล์อินพุต: นี่เป็นค่าเริ่มต้นสำหรับอินสแตนซ์ที่สร้างใหม่ ไม่ได้เป็นหลักฐานว่าไฟล์ PPTX ถูกโหลด หากความแตกต่างนี้สำคัญ ให้ติดตามว่าแอปพลิเคชันของคุณสร้างหรือโหลดอินสแตนซ์แยกต่างหาก

## **แมปรูปแบบแหล่งที่มากับนามสกุล**

ตัวอย่างต่อไปนี้ต้องการ `sample.pptx` จะแมปค่าของ [SourceFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sourceformat/) ทุกค่าที่รองรับในปัจจุบันเป็นนามสกุลที่เป็นที่ยอมรับ, โดยไม่ต้องพาร์สชื่อไฟล์ อินพุต ตัวสำรองจะหลีกเลี่ยงการกำหนดนามสกุลให้กับค่าที่ไม่รู้จักอย่างเงียบ ๆ

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    let extension;
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case aspose.SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case aspose.SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case aspose.SourceFormat.Pps:
            extension = ".pps";
            break;
        case aspose.SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case aspose.SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case aspose.SourceFormat.Pot:
            extension = ".pot";
            break;
        case aspose.SourceFormat.Potx:
            extension = ".potx";
            break;
        case aspose.SourceFormat.Potm:
            extension = ".potm";
            break;
        case aspose.SourceFormat.Odp:
            extension = ".odp";
            break;
        case aspose.SourceFormat.Otp:
            extension = ".otp";
            break;
        case aspose.SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case aspose.SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    console.log(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

การแมปนี้ไม่ได้ทำการแปลงไฟล์หรือกู้คืนย่อยแบบ PPS/POT ที่สูญหายระหว่างการโหลดสตรีม สำหรับการบันทึกจริง ให้เลือก [SaveFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/saveformat/) อย่างชัดเจน, หรือใช้การแปลงที่แสดงใน [Save Presentations in Their Original Format](/slides/th/nodejs-java/save-presentation/#save-presentations-in-their-original-format)

## **ยืนยันรูปแบบโดยการบันทึกและเปิดใหม่**

ตัวอย่างแบบ self‑contained นี้สร้างพรีเซนเทชันและเขียนไฟล์สามไฟล์ในไดเรกทอรีทำงาน, ทับไฟล์ที่มีชื่อเดียวกันใหม่ จากนั้นเปิดแต่ละไฟล์ผลลัพธ์ทั้งโดยเส้นทางและผ่านสตรีมหน่วยความจำ สำหรับ PPTX และ ODP ทั้งสองวิธีจะแจ้งรูปแบบที่บันทึกไว้ สำหรับ PPS, การโหลดโดยเส้นทางจะรายงาน `Pps` ขณะที่การโหลดไบต์เดียวกันโดยไม่มีชื่อไฟล์จะรายงาน `Ppt`

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.Presentation();
try {
    const formats = [aspose.SaveFormat.Pptx, aspose.SaveFormat.Odp, aspose.SaveFormat.Pps];
    const extensions = ["pptx", "odp", "pps"];

    for (let i = 0; i < formats.length; i++) {
        const path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        const fromFile = new aspose.Presentation(path);
        try {
            const buffer = fs.readFileSync(path);
            const bytes = java.newArray("byte", Array.from(buffer));
            const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
            try {
                const fromStream = new aspose.Presentation(stream);
                try {
                    console.log(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            } finally {
                stream.close();
            }
        } finally {
            fromFile.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

ตารางต่อไปสรุปการระบุรูปแบบแหล่งที่มาสำหรับพรีเซนเทชันที่มีนามสกุลตรงกัน ชื่อตัวแปรเป็นค่าคงที่; ตัวอย่าง JavaScript จะพิมพ์ค่าจำนวนเต็มของมัน:

| รูปแบบที่บันทึก | SourceFormat จากเส้นทางไฟล์ | SourceFormat จากสตรีมไม่มีชื่อ |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` ตามลำดับ | เหมือนกับเส้นทางไฟล์ |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` ตามลำดับ | เหมือนกับเส้นทางไฟล์ |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` ตามลำดับ | เหมือนกับเส้นทางไฟล์ |
| ODP, OTP | `Odp`, `Otp` ตามลำดับ | เหมือนกับเส้นทางไฟล์ |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

เนื้อหา PPS/POT จะถูกระบุเป็น `Ppt` สำหรับสตรีมที่ไม่มีชื่อ ตารางบรรยายการระบุรูปแบบ, ไม่ได้หมายถึงการคงคุณลักษณะของพรีเซนเทชันทุกอย่างระหว่างการแปลง

## **คำถามที่พบบ่อย**

**การบันทึกเป็น ODP จะเปลี่ยนรูปแบบแหล่งที่มาของพรีเซนเทชันที่โหลดจาก PPTX หรือไม่?**

ไม่ได้ อินสแตนซ์ที่มีอยู่จะยังคงรายงาน `Pptx` อินสแตนซ์ที่โหลดจากไฟล์ ODP ที่บันทึกไว้จะรายงาน `Odp`

**สตรีมสามารถแยกแยะพรีเซนเทชันแบบดั้งเดิม, การแสดงสไลด์, และแม่แบบได้เสมอหรือไม่?**

ไม่ได้ PPT, PPS และ POT ใช้รูปแบบไบนารีเดียวกัน ต้องเก็บชื่อไฟล์หรือเมตาดาต้าย่อยแยกต่างหากเมื่อความแตกต่างนี้จำเป็น

**ควรใช้ API ใดเมื่อพรีเซนเทชันโหลดแล้ว?**

อ่าน [Presentation.getSourceFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getSourceFormat) ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) สำหรับการตรวจสอบก่อนการโหลด