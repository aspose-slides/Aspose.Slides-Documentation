---
title: ดึงและอัปเดตข้อมูลงานนำเสนอใน JavaScript
linktitle: ข้อมูลงานนำเสนอ
type: docs
weight: 30
url: /th/nodejs-java/examine-presentation/
keywords:
- รูปแบบงานนำเสนอ
- คุณสมบัติงานนำเสนอ
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
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สำรวจสไลด์ โครงสร้างและเมตาดาต้าในงานนำเสนอ PowerPoint และ OpenDocument ด้วย JavaScript เพื่อให้ได้ข้อมูลเชิงลึกที่รวดเร็วและการตรวจสอบเนื้อหาที่ชาญฉลาดยิ่งขึ้น."
---
## **ภาพรวม**

Aspose.Slides สามารถระบุรูปแบบของงานนำเสนอและอ่านเมตาดาต้าเอกสารได้โดยไม่ต้องสร้างโมเดลวัตถุของงานนำเสนอทั้งหมด ซึ่งมีประโยชน์เมื่อคุณต้องการจัดประเภทไฟล์ สร้างรายการสินค้าคลัง หรือสืบตรวจสอบคุณสมบัติก่อนตัดสินใจว่าจะโหลดและประมวลผลเนื้อหางานนำเสนอหรือไม่

บทความนี้แสดงการตรวจสอบอย่างเบาโดยใช้ [PresentationFactory](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationfactory/) และ [PresentationInfo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/), รวมถึงการอัปเดตแบบเจาะจงโดยใช้ [DocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/)

## **ตรวจสอบรูปแบบของงานนำเสนอ**

หากคุณมีงานนำเสนอที่โหลดแล้วอยู่แล้ว ให้ดูที่ [Determine the Original Presentation Format](/slides/th/nodejs-java/detect-presentation-source-format/) เพื่อทำการตรวจจับหลังการโหลดและข้อจำกัดของสตรีม PPT, PPS, และ POT รุ่นเก่า

ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) เพื่อสแกนไฟล์โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) วิธี [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/getloadformat/) จะรายงานรูปแบบที่ตรวจพบ เช่น PPTX, PPT หรือ ODP

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

## **สร้างสินค้าคลังงานนำเสนอแบบเบา**

เมื่อคุณต้องประมวลผลไฟล์งานนำเสนอจำนวนมาก อาจต้องการสินค้าคลังแบบกะทัดรัดเพื่อการตรวจสอบ การทำดัชนี หรือระบบจัดการเอกสาร ในกรณีนี้ให้ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) เพื่อรับวัตถุ [PresentationInfo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/) แล้วเรียก [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) เพื่ออ่านเมตาดาต้าเอกสาร วิธีนี้ไม่ได้สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) หรือบังคับให้คุณเดินทางผ่านโมเดลวัตถุของงานนำเสนอทั้งหมด

คุณสมบัติเพิ่มเติมที่เผยโดย [DocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/) ให้ค่าดังต่อไปนี้ในสินค้าคลัง:

| เมธอด | ค่าในสินค้าคลัง |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/#getSlides) | จำนวนสไลด์ทั้งหมด |
| [getHiddenSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | จำนวนสไลด์ที่ซ่อนอยู่ |
| [getNotes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/#getNotes) | จำนวนสไลด์ที่มีบันทึกหมายเหตุ |
| [getParagraphs](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | จำนวนย่อหน้าทั้งหมด (หากมี) |
| [getWords](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/#getWords) | จำนวนคำทั้งหมด |
| [getMultimediaClips](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | จำนวนคลิปเสียงและวิดีโอทั้งหมด |

ตัวอย่างต่อไปนี้อ่านค่าดังกล่าวโดยไม่สร้างวัตถุ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) และพิมพ์สินค้าคลังแบบกะทัดรัด นอกจากนี้ยังรวม [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) กับ [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) เพื่อแสดงกลุ่มเนื้อหา เช่น ฟอนต์ ธีม และชื่อสไลด์

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

แต่ละ [HeadingPair](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/headingpair/) จะให้ชื่อกลุ่มผ่าน [HeadingPair.getName](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/headingpair/#getName) และจำนวนรายการในกลุ่มผ่าน [HeadingPair.getCount](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/headingpair/#getCount) [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) จะคืนอาร์เรย์แบนที่เรียงลำดับ ดังนั้นให้ใช้จำนวนหัวข้อที่ต่อเนื่องตามที่แต่ละ HeadingPair ระบุ

### **เมตาดาต้าที่จัดเก็บและข้อจำกัดของรูปแบบ**

ค่าคลังที่คืนโดย [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) สะท้อนเมตาดาต้าที่มีในเอกสารต้นทาง Aspose.Slides ไม่ได้โหลดและเดินทางผ่านโมเดลวัตถุของงานนำเสนอเพื่อคำนวณค่าเหล่านี้ใหม่สำหรับการเรียกนี้ คุณสมบัติที่ขาดหายจะถูกแทนด้วยค่าเริ่มต้น และค่าที่จัดเก็บอาจเป็นข้อมูลเก่า หากแอปพลิเคชันที่บันทึกไฟล์ครั้งล่าสุดไม่ได้อัปเดตคุณสมบัติของเอกสาร

- **PPTX:** รูปแบบนี้ให้คุณสมบัติเพิ่มเติมของเอกสารสำหรับจำนวนสไลด์, หมายเหตุ, สไลด์ซ่อน, ย่อหน้า, คำ และสื่อมัลติมีเดีย รวมทั้ง heading pairs และ part titles ความพร้อมใช้งานขึ้นอยู่กับว่าผู้ออกรายงานได้เขียนคุณสมบัติเหล่านั้นไว้หรือไม่
- **PPT:** รูปแบบไบนารีสามารถเก็บคุณสมบัติสรุปเอกสารที่สอดคล้องกันได้ หากคุณสมบัติใดหายหรือไม่ได้รับการรีเฟรชโดยผู้ออกรายงาน Aspose.Slides จะคืนค่าที่จัดเก็บหรือค่าเริ่มต้นแทนการคำนวณจากสไลด์
- **ODP:** เมตาดาต้า OpenDocument ให้สถิติทั่วไปของเอกสาร เช่น จำนวนหน้า, ย่อหน้าและคำ แต่ค่าต่าง ๆ นี้ไม่แมปกับคุณสมบัติเพิ่มเติมเฉพาะ PowerPoint ทุกอย่าง เช่น สไลด์ซ่อน, หมายเหตุสไลด์, สื่อมัลติมีเดีย, heading‑pair และ part‑title อาจไม่มีให้บริการ และค่าคลังอาจคืนค่าเริ่มต้น อย่าใช้ค่า 0 หรืออาร์เรย์ว่างเป็นหลักฐานที่แน่นอนว่าหน่วยข้อมูลที่สอดคล้องไม่มีอยู่

ใช้วิธีเมตาดาต้าแบบเบาสำหรับการทำสินค้าคลังและการตรวจสอบเบื้องต้น โหลดงานนำเสนอและตรวจสอบโมเดลวัตถุแบบสดเมื่อผลลัพธ์ต้องสะท้อนการเปลี่ยนแปลงในหน่วยความจำหรือเมื่อคุณต้องการยืนยันเนื้อหาจริงของงานนำเสนอ

## **อัปเดตคุณสมบัติงานนำเสนอ**

คุณสมบัติที่คืนโดย [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) สามารถเปลี่ยนแปลงได้โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) ใช้ [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/) เพื่อทำการเปลี่ยนแปลง แล้วเขียนงานนำเสนอที่ผูกไว้ด้วย [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/)

ภาพต่อไปนี้แสดงคุณสมบัติเบื้องต้นของเอกสารต้นฉบับ

![คุณสมบัติเบื้องต้นของงานนำเสนอ PowerPoint](input_properties.png)

ตัวอย่างต่อไปนี้เปลี่ยนชื่อและเวลาการบันทึกครั้งสุดท้ายและเขียนผลลัพธ์ไปยังไฟล์ใหม่:

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

ภาพต่อไปนี้แสดงคุณสมบัติเอกสารที่อัปเดตแล้ว

![คุณสมบัติเอกสารที่เปลี่ยนแปลงของงานนำเสนอ PowerPoint](output_properties.png)

## **ลิงก์ที่เป็นประโยชน์**

สำหรับการตรวจสอบความปลอดภัยและการตั้งค่าการปกป้องที่เกี่ยวข้อง ดูบทความต่อไปนี้:

- [Password-Protect Presentations](/slides/th/nodejs-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/th/nodejs-java/write-protected-presentation/)

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรว่าแบบอักษรถูกฝังอยู่และเป็นแบบใดบ้าง?**

โหลดงานนำเสนอและใช้ [Presentation.getFontsManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getfontsmanager/) เรียก [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) เพื่อรับฟอนต์ที่ฝังอยู่ และ [FontsManager.getFonts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/getfonts/) เพื่อรับฟอนต์ที่งานนำเสนอใช้ เปรียบเทียบผลลัพธ์สองชุดเพื่อหาฟอนต์ที่จำเป็นสำหรับการแสดงผลแต่ไม่ได้ฝังไว้

**ฉันจะบอกได้อย่างรวดเร็วว่าไฟล์มีสไลด์ซ่อนอยู่หรือไม่และมีกี่สไลด์?**

เมื่อเมตาดาต้าเอกสารที่จัดเก็บเพียงพอ ให้อ่าน [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) ผ่าน [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) และ [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) วิธีนี้เหมาะสำหรับสินค้าคลังแบบเบา หากงานนำเสนอถูกแก้ไขในหน่วยความจำ เมตาดาต้าที่จัดเก็บอาจขาดหายหรือเก่า หรือหากต้องการตรวจสอบค่าจริง ให้วนลูปผ่าน [Presentation.getSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getslides/) และตรวจสอบเมธอด [Slide.getHidden](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/gethidden/) ของแต่ละสไลด์แทน

**ฉันจะตรวจจับได้หรือไม่ว่ามีการใช้ขนาดและการวางแนวสไลด์แบบกำหนดเองและว่ามันต่างจากค่าเริ่มต้นหรือไม่?**

ได้ โหลดงานนำเสนอและเรียก [Presentation.getSlideSize](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getslidesize/) ใช้ [SlideSize.getType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidesize/gettype/), [SlideSize.getSize](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidesize/getsize/) และ [SlideSize.getOrientation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidesize/getorientation/) เพื่อเปรียบเทียบการตั้งค่าปัจจุบันกับพรีเซ็ตและมิติที่คาดหวัง

**มีวิธีง่าย ๆ เพื่อดูว่ากราฟอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**

ได้ ค้นหาวัตถุ [Chart](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chart/) แต่ละอันและเรียก [ChartData.getDataSourceType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) หากเป็นเวิร์กบุ๊กภายนอก ให้เรียก [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) ประเภทและเส้นทางของแหล่งข้อมูลจะบ่งบอกการอ้างอิงภายนอก อย่างไรก็ตามการตรวจสอบว่าไฟล์เป้าหมายมีอยู่หรือไม่ต้องทำการตรวจสอบทรัพยากรแยกต่างหาก

**ฉันจะประเมินสไลด์ ‘หนัก’ ที่อาจทำให้การเรนเดอร์หรือการส่งออกเป็น PDF ช้าได้อย่างไร?**

ไม่มีคุณสมบัติความซับซ้อนเดียวที่บ่งบอก ให้เดินทางผ่าน [Presentation.getSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getslides/) และคอลเลกชัน [BaseSlide.getShapes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseslide/#getShapes) ของแต่ละสไลด์ ใช้จำนวน shape และการมีอยู่ของรูปภาพขนาดใหญ่ เอฟเฟกต์ แอนิเมชัน หรือมัลติมีเดียเป็นสัญญาณคัดกรอง และทำการวัดการเรนเดอร์หรือการส่งออกตัวอย่างก่อนสรุปว่าสไลด์เป็นคอขวดด้านประสิทธิภาพจริง ๆ  