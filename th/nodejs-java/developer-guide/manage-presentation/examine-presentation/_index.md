---
title: ดึงและอัปเดตข้อมูลการนำเสนอใน JavaScript
linktitle: ข้อมูลการนำเสนอ
type: docs
weight: 30
url: /th/nodejs-java/examine-presentation/
keywords:
- รูปแบบการนำเสนอ
- คุณสมบัติการนำเสนอ
- คุณสมบัติเอกสาร
- รับคุณสมบัติ
- อ่านคุณสมบัติ
- เปลี่ยนคุณสมบัติ
- แก้ไขคุณสมบัติ
- อัปเดตคุณสมบัติ
- ตรวจสอบ PPTX
- ตรวจสอบ PPT
- ตรวจสอบ ODP
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สำรวจสไลด์ โครงสร้าง และเมตาดาต้าในงานนำเสนอ PowerPoint และ OpenDocument ด้วย JavaScript เพื่อให้ได้ข้อมูลเชิงลึกที่รวดเร็วและการตรวจสอบเนื้อหาที่ฉลาดขึ้น."
---
## **ภาพรวม**

Aspose.Slides สามารถระบุรูปแบบของการนำเสนอและอ่านเมตาดาต้าของเอกสารได้โดยไม่ต้องสร้างโมเดลวัตถุการนำเสนอแบบเต็ม ซึ่งเป็นประโยชน์เมื่อคุณต้องการจัดประเภทไฟล์ สร้างรายการตรวจสอบ หรือตรวจสอบคุณสมบัติก่อนตัดสินใจว่าจะโหลดและประมวลผลเนื้อหาการนำเสนอหรือไม่.  
บทความนี้จะแสดงการตรวจสอบแบบน้ำหนักเบาผ่าน [PresentationFactory](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationfactory/) และ [PresentationInfo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/), รวมถึงการอัปเดตแบบเจาะจงผ่าน [DocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/).

## **ตรวจสอบรูปแบบการนำเสนอ**

ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) เพื่อตรวจสอบไฟล์โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) วิธีการ [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/getloadformat/) จะรายงานรูปแบบที่ตรวจพบ เช่น PPTX, PPT หรือ ODP.

```javascript
const aspose = require("aspose.slides.via.java");

const fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

for (const fileName of fileNames) {
    const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(fileName);
    const loadFormat = presentationInfo.getLoadFormat();
    let formatName = `Other (${loadFormat})`;

    if (loadFormat === aspose.LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat === aspose.LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat === aspose.LoadFormat.Odp) {
        formatName = "ODP";
    }

    console.log(`${fileName}: ${formatName}`);
}
```

## **สร้างรายการนำเสนอน้ำหนักเบา**

เมื่อคุณต้องทำงานกับไฟล์การนำเสนอหลายไฟล์ คุณอาจต้องการรายการตรวจสอบที่กะทัดรัดสำหรับการตรวจสอบความถูกต้อง การทำดัชนี หรือระบบจัดการเอกสาร ในกรณีนี้ ให้ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) เพื่อรับอ็อบเจ็กต์ [PresentationInfo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/) แล้วเรียก [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) เพื่ออ่านเมตาดาต้าเอกสาร วิธีนี้ไม่สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) หรือจำเป็นต้องเดินทางผ่านโมเดลวัตถุการนำเสนอแบบสมบูรณ์.  

คุณสมบัติเพิ่มเติมที่เปิดเผยโดย [DocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/) จะให้ค่าต่อไปนี้สำหรับรายการตรวจสอบ:

| เมธอด | ค่ารายการตรวจสอบ |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/#getSlides) | จำนวนทั้งหมดของสไลด์ |
| [getHiddenSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | จำนวนสไลด์ที่ซ่อนอยู่ |
| [getNotes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/#getNotes) | จำนวนสไลด์ที่มีโน้ต |
| [getParagraphs](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | จำนวนทั้งหมดของย่อหน้า (ถ้ามี) |
| [getWords](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/#getWords) | จำนวนทั้งหมดของคำ |
| [getMultimediaClips](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | จำนวนทั้งหมดของคลิปเสียงและวิดีโอ |

ตัวอย่างต่อไปนี้อ่านค่าดังกล่าวโดยไม่สร้างอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) และพิมพ์รายการตรวจสอบแบบกะทัดรัด นอกจากนี้ยังรวม [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) กับ [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) เพื่อแสดงกลุ่มเนื้อหา เช่น แบบอักษร ธีม และชื่อสไลด์

```javascript
const path = require("path");
const aspose = require("aspose.slides.via.java");

const filePath = "sample.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(filePath);
const documentProperties = presentationInfo.readDocumentProperties();

const loadFormat = presentationInfo.getLoadFormat();
let formatName = `Other (${loadFormat})`;

if (loadFormat === aspose.LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat === aspose.LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat === aspose.LoadFormat.Odp) {
    formatName = "ODP";
}

console.log(`File: ${path.basename(filePath)}`);
console.log(`Format: ${formatName}`);
console.log(`Title: ${documentProperties.getTitle()}`);
console.log(`Author: ${documentProperties.getAuthor()}`);
console.log("Statistics:");
console.log(`  Slides: ${documentProperties.getSlides()}`);
console.log(`  Hidden slides: ${documentProperties.getHiddenSlides()}`);
console.log(`  Slides with notes: ${documentProperties.getNotes()}`);
console.log(`  Paragraphs: ${documentProperties.getParagraphs()}`);
console.log(`  Words: ${documentProperties.getWords()}`);
console.log(`  Multimedia clips: ${documentProperties.getMultimediaClips()}`);

const headingPairs = documentProperties.getHeadingPairs() || [];
const titlesOfParts = documentProperties.getTitlesOfParts() || [];
let partIndex = 0;

if (headingPairs.length === 0 || titlesOfParts.length === 0) {
    console.log("Content groups: not available");
} else {
    console.log("Content groups:");

    for (const headingPair of headingPairs) {
        const partCount = headingPair.getCount();
        console.log(`  ${headingPair.getName()} (${partCount})`);

        for (let partOffset = 0; partOffset < partCount && partIndex < titlesOfParts.length; partOffset++) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        console.log("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }
}
```

แต่ละ [HeadingPair](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/headingpair/) จะให้ชื่อกลุ่มผ่าน [HeadingPair.getName](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/headingpair/#getName) และจำนวนรายการในกลุ่มนั้นผ่าน [HeadingPair.getCount](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/headingpair/#getCount) [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) จะคืนค่าเป็นอาเรย์แบนเรียงลำดับ ดังนั้นให้ใช้จำนวนชื่อที่ต่อเนื่องตามที่แต่ละ heading pair ระบุ

### **เมตาดาต้าที่เก็บไว้และข้อจำกัดของรูปแบบ**

คุณสมบัติรายการตรวจสอบที่คืนค่าจาก [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) สะท้อนเมตาดาต้าที่มีในเอกสารต้นทาง Aspose.Slides จะไม่โหลดและเดินทางผ่านโมเดลวัตถุการนำเสนอเพื่อคำนวณค่าต่าง ๆ ใหม่สำหรับการเรียกนี้ คุณสมบัติที่หายไปจะแสดงด้วยค่าเริ่มต้น และค่าที่จัดเก็บอาจล้าสมัยหากแอปพลิเคชันที่บันทึกไฟล์ครั้งสุดท้ายไม่ได้อัปเดตคุณสมบัติเข้าเอกสาร  

- **PPTX:** รูปแบบนี้ให้คุณสมบัติเข้าเอกสารเพิ่มสำหรับจำนวนสไลด์, โน้ต, สไลด์ที่ซ่อน, ย่อหน้า, คำ, และมัลติมีเดีย รวมถึง heading pairs และ part titles ความพร้อมใช้งานขึ้นอยู่กับว่าผู้สร้างเอกสารได้เขียนคุณสมบัติเหล่านั้นหรือไม่  
- **PPT:** รูปแบบไบนารีสามารถเก็บคุณสมบัติสรุปเอกสารที่สอดคล้องได้ หากคุณสมบัติใดหายไปหรือไม่ได้รับการรีเฟรชโดยผู้สร้างเอกสาร Aspose.Slides จะคืนค่าที่จัดเก็บหรือค่าเริ่มต้นแทนการคำนวณจากสไลด์  
- **ODP:** เมตาดาต้า OpenDocument ให้สถิติทั่วไปของเอกสาร เช่น จำนวนหน้า ย่อหน้า และคำ แต่ค่าดังกล่าวไม่สอดคล้องกับคุณสมบัติเพิ่มเติมของ PowerPoint ทุกอย่าง เมตาดาต้าของสไลด์ที่ซ่อน, โน้ตสไลด์, มัลติมีเดีย, heading‑pair, และ part‑title อาจไม่มีและคุณสมบัติรายการตรวจสอบอาจคืนค่าเริ่มต้น อย่าใช้ค่าเป็นศูนย์หรืออาเรย์ว่างเป็นหลักฐานยืนยันว่ามีเนื้อหาที่สอดคล้องไม่มีอยู่  

ใช้วิธีเมตาดาต้าแบบน้ำหนักเบาสำหรับการสร้างรายการตรวจสอบและการตรวจสอบเบื้องต้น โหลดการนำเสนอและตรวจสอบโมเดลวัตถุแบบสดเมื่อผลลัพธ์ต้องสะท้อนการเปลี่ยนแปลงในหน่วยความจำหรือเมื่อคุณต้องการยืนยันเนื้อหาการนำเสนอจริง

## **อัปเดตคุณสมบัตินำเสนอ**

คุณสมบัติที่คืนค่าจาก [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) สามารถแก้ไขได้โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) ใช้การเปลี่ยนแปลงด้วย [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/) แล้วเขียนการนำเสนอที่ผูกไว้ด้วย [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/).  

ภาพต่อไปนี้แสดงคุณสมบัติเข้าเอกสารต้นฉบับของการนำเสนอ PowerPoint:

![คุณสมบัติเข้าเอกสารต้นฉบับของการนำเสนอ PowerPoint](input_properties.png)

ตัวอย่างต่อไปนี้จะเปลี่ยนชื่อเรื่องและเวลาการบันทึกล่าสุดแล้วเขียนผลลัพธ์ลงในไฟล์ใหม่:

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");

const sourceFile = "sample.pptx";
const outputFile = "sample_with_updated_properties.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(sourceFile);
const documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

presentationInfo.updateDocumentProperties(documentProperties);
const outputStream = java.newInstanceSync("java.io.FileOutputStream", outputFile);
try {
    presentationInfo.writeBindedPresentation(outputStream);
} finally {
    outputStream.close();
}
```

ภาพต่อไปนี้แสดงคุณสมบัติเอกสารที่อัปเดตของการนำเสนอ PowerPoint:

![คุณสมบัติเอกสารที่อัปเดตของการนำเสนอ PowerPoint](output_properties.png)

## **ลิงก์ที่เป็นประโยชน์**

สำหรับการตรวจสอบความปลอดภัยและการตั้งค่าการป้องกันที่เกี่ยวข้อง ดูบทความต่อไปนี้:

- [ปกป้องการนำเสนอด้วยรหัสผ่าน](/slides/th/nodejs-java/password-protected-presentation/)
- [ปกป้องการนำเสนอจากการเขียน](/slides/th/nodejs-java/write-protected-presentation/)

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรว่าฟอนท์ถูกฝังอยู่และเป็นฟอนท์ใดบ้าง?**

โหลดการนำเสนอและใช้ [Presentation.getFontsManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getfontsmanager/) เรียก [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) เพื่อรับฟอนท์ที่ถูกฝัง และ [FontsManager.getFonts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/getfonts/) เพื่อรับฟอนท์ที่การนำใช้ เปรียบเทียบผลลัพธ์สองชุดเพื่อหาฟอนท์ที่จำเป็นต่อการเรนเดอร์แต่ไม่ได้ฝังไว้  

**ฉันจะบอกได้อย่างรวดเร็วว่าไฟล์มีสไลด์ที่ซ่อนอยู่หรือไม่และจำนวนเท่าไร?**

เมื่อเมตาดาต้าเอกสารที่จัดเก็บไว้เพียงพอ ให้อ่าน [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) ผ่าน [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) และ [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) ซึ่งเหมาะสำหรับรายการตรวจสอบแบบน้ำหนักเบา หากการนำเสนอถูกแก้ไขในหน่วยความจำ เมตาดาต้าที่จัดเก็บอาจหายหรือเก่า หรือคุณต้องการตรวจสอบค่าที่เป็นสด ให้วนผ่าน [Presentation.getSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getslides/) และตรวจสอบเมธอด [Slide.getHidden](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/gethidden/) ของแต่ละสไลด์แทน  

**ฉันสามารถตรวจจับได้หรือไม่ว่ามีการใช้ขนาดและการวางแนวสไลด์ที่กำหนดเองหรือไม่และว่ามันแตกต่างจากค่าเริ่มต้นหรือไม่?**

ใช่ โหลดการนำเสนอและเรียก [Presentation.getSlideSize](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getslidesize/) ใช้ [SlideSize.getType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidesize/gettype/), [SlideSize.getSize](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidesize/getsize/), และ [SlideSize.getOrientation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidesize/getorientation/) เพื่อเปรียบเทียบการตั้งค่าปัจจุบันกับค่าที่กำหนดไว้ล่วงหน้าและมิติที่คาดหวัง  

**มีวิธีเร็ว ๆ ที่จะตรวจสอบว่าชาร์ตอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**

ใช่ ค้นหาแต่ละ [Chart](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chart/) แล้วเรียก [ChartData.getDataSourceType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) สำหรับเวิร์กบุ๊กภายนอก ให้เรียก [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) ประเภทและเส้นทางของแหล่งข้อมูลบ่งชี้ถึงการอ้างอิงภายนอก แต่การตรวจสอบว่าปลายทางพร้อมใช้งานหรือไม่ต้องการการตรวจสอบทรัพยากรแยกต่างหาก  

**ฉันจะประเมินสไลด์ที่ 'หนัก' ที่อาจทำให้การเรนเดอร์หรือการส่งออกเป็น PDF ช้าลงได้อย่างไร?**

ไม่มีคุณสมบัติความซับซ้อนเดียวที่จะบอกได้ให้เดินผ่าน [Presentation.getSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getslides/) และคอลเลกชัน [BaseSlide.getShapes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseslide/#getShapes) ของแต่ละสไลด์ ใช้จำนวนรูปร่างและการมีอยู่ของภาพขนาดใหญ่ เอฟเฟกต์ แอนิเมชัน หรือมัลติมีเดียเป็นสัญญาณคัดกรอง และทำการวัดการเรนเดอร์หรือการส่งออกตัวอย่างก่อนที่จะถือว่าสไลด์เป็นคอขวดประสิทธิภาพที่ยืนยันแล้ว