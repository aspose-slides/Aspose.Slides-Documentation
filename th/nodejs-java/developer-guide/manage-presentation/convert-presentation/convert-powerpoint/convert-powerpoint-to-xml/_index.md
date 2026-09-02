---
title: แปลงไฟล์การนำเสนอ PowerPoint เป็น XML ใน JavaScript
linktitle: PowerPoint เป็น XML
type: docs
weight: 145
url: /th/nodejs-java/convert-powerpoint-to-xml/
keywords:
- แปลง PowerPoint เป็น XML
- แปลงการนำเสนอเป็น XML
- PPT เป็น XML
- PPTX เป็น XML
- ODP เป็น XML
- PowerPoint XML Presentation
- SaveFormat.Xml
- บันทึกการนำเสนอเป็น XML
- ส่งออกการนำเสนอเป็น XML
- สตรีม XML
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลงไฟล์การนำเสนอ PowerPoint และ OpenDocument เป็นไฟล์หรือสตรีม PowerPoint XML ใน JavaScript ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **Overview**

Aspose.Slides สำหรับ Node.js ผ่าน Java สามารถแปลงไฟล์การนำเสนอ PowerPoint ไปเป็นรูปแบบ PowerPoint XML Presentation ได้ ผลลัพธ์ XML มีความสำคัญเมื่อคุณต้องการการแสดงผลแบบข้อความเพื่อการตรวจสอบโครงสร้างการนำเสนอ, แก้ไขปัญหาเอกสารที่สร้างขึ้น, เปรียบเทียบผลลัพธ์ในการทดสอบอัตโนมัติ, หรือผสานกับกระบวนการทำงานที่ใช้ XML แทนแพ็กเกจการนำเสนอ

ใช้เมธอด [Presentation.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#save) พร้อมค่ `Xml` จาก enumeration [SaveFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/saveformat/) คุณสามารถเขียนผลลัพธ์โดยตรงไปยังไฟล์หรือสตรีมได้

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` สร้าง PowerPoint XML Presentation มันไม่ได้ดึงส่วนย่อยของ Office Open XML ที่เก็บอยู่ภายในแพ็กเกจ PPTX หากคุณต้องการส่วนของแพ็กเกจ PPTX อย่างเช่น `ppt/presentation.xml` หรือไฟล์ XML ของสไลด์แต่ละไฟล์ ให้ตรวจสอบแพ็กเกจ PPTX เอง
{{% /alert %}}

## **Convert a Presentation to an XML File**

โหลดการนำเสนอต้นฉบับด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) จากนั้นส่งพาธผลลัพธ์และ `SaveFormat.Xml` ไปยัง [Presentation.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#save) แหล่งข้อมูลสามารถเป็นรูปแบบการนำเสนอใดก็ได้ที่รองรับการโหลด เช่น PPT, PPTX หรือ ODP

ตัวอย่างต่อไปนี้แปลงการนำเสนอ PPTX เป็นไฟล์ XML:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("presentation.xml", aspose.slides.SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **Write the XML Output to a Stream**

ใช้ overload แบบสตรีมของ [Presentation.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#save) เมื่อ XML ต้องคงอยู่ในหน่วยความจำหรือส่งต่อไปยังคอมโพเนนต์อื่น เช่น เว็บเซอร์วิส, ผู้ให้บริการเก็บข้อมูล, หรือ pipeline การประมวลผล XML ตัวอย่างต่อไปนี้เขียนผลลัพธ์ไปยัง Java `ByteArrayOutputStream` และคัดลอกข้อมูลที่สร้างขึ้นไปยัง Node.js `Buffer`:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xmlStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        presentation.save(xmlStream, aspose.slides.SaveFormat.Xml);

        const xmlBuffer = Buffer.from(xmlStream.toByteArray());
        console.log(`XML size: ${xmlBuffer.length} bytes`);

        // ส่ง xmlBuffer ไปยังคอมโพเนนต์ต่อไปในกระบวนการทำงาน.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Compare XML with Presentation and Export Formats**

เลือกรูปแบบผลลัพธ์ตามการใช้งานของผลลัพธ์:

| Format | Output | Typical use |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | การนำเสนอ PowerPoint XML | การตรวจสอบโครงสร้าง, แก้ไขปัญหา, เปรียบเทียบผลลัพธ์ที่สร้างขึ้น, และการรวมระบบโดยใช้ XML |
| PPT (`.ppt`) | ไฟล์การนำเสนอแบบไบนารีแบบเก่า | ความเข้ากันได้กับกระบวนการทำงาน PowerPoint รุ่นเก่า |
| PPTX (`.pptx`) | แพ็กเกจ Office Open XML ที่มีหลายส่วน | การแก้ไข PowerPoint ปกติและการแลกเปลี่ยนการนำเสนอ |
| PDF or TIFF | หน้าแบบจัดวางคงที่หรือภาพหลายหน้า | การดู, การพิมพ์, และการเก็บถาวร |
| PNG, JPEG, or SVG | การแสดงผลของสไลด์เดี่ยวหนึ่งสไลด์ | ภาพย่อ, ตัวอย่าง, และทรัพย์สินภาพ |
| HTML or HTML5 | ผลลัพธ์การนำเสนอแบบเว็บ | การดูในเบราว์เซอร์และการเผยแพร่บนเว็บ |

แตกต่างจาก PPT และ PPTX, ผลลัพธ์ XML มีจุดมุ่งหมายหลักเพื่อการตรวจสอบและการทำงานที่เน้นข้อมูลเป็นหลัก แตกต่างจาก PDF, TIFF, HTML, และรูปแบบภาพสไลด์, XML แสดงข้อมูลการนำเสนอแทนที่จะเรนเดอร์สไลด์เป็นหน้า หรือทรัพย์สินภาพ ตาราง [supported file formats](/slides/th/nodejs-java/supported-file-formats/) ระบุว่า PowerPoint XML Presentation เป็นรูปแบบที่บันทึกได้เท่านั้น ดังนั้นห้ามใช้เมื่อกระบวนการทำงานต้องโหลดไฟล์ที่ส่งออกกลับเข้าสู่ Aspose.Slides เพื่อการแก้ไขต่อไป

## **FAQ**

**Is `SaveFormat.Xml` the same as saving a PPTX file?**

ไม่. PPTX คือแพ็กเกจที่มีหลายส่วนของ Office Open XML, ในขณะที่ `SaveFormat.Xml` สร้างไฟล์ PowerPoint XML Presentation

**Can I save the XML output without creating a file on disk?**

ได้. ส่งสตรีมที่เขียนได้ไปยัง [Presentation.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#save). ตัวอย่างเช่น ใช้ Java `ByteArrayOutputStream` และคัดลอกข้อมูลไปยัง Node.js `Buffer` เพื่อประมวลผลในหน่วยความจำ

**Can Aspose.Slides load the exported XML file again?**

ไม่ได้. PowerPoint XML Presentation รองรับการบันทึกเท่านั้น ไม่รองรับการโหลด ใช้ PPTX หรือรูปแบบการนำเสนอที่รองรับอื่นเมื่อจำเป็นต้องทำการแก้ไขแบบรอบกลับ

**Does XML conversion render each slide as a page or image?**

ไม่. การแปลง XML จะเขียนข้อมูลการนำเสนอเป็นโครงสร้าง ใช้ PDF หรือ TIFF สำหรับผลลัพธ์แบบหน้า, หรือ PNG, JPEG, และ SVG สำหรับภาพสไลด์แต่ละสไลด์