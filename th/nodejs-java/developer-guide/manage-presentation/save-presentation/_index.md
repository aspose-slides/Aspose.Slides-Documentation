---
title: บันทึกงานนำเสนอใน JavaScript
linktitle: บันทึกงานนำเสนอ
type: docs
weight: 80
url: /th/nodejs-java/save-presentation/
keywords:
- บันทึก PowerPoint
- บันทึก OpenDocument
- บันทึกงานนำเสนอ
- บันทึกสไลด์
- บันทึก PPT
- บันทึก PPTX
- บันทึก ODP
- งานนำเสนอเป็นไฟล์
- งานนำเสนอเป็นสตรีม
- ประเภทมุมมองที่กำหนดล่วงหน้า
- รูปแบบ Strict Office Open XML
- โหมด Zip64
- รีเฟรชภาพย่อ
- บันทึกความคืบหน้า
- Node.js
- JavaScript
- Aspose.Slides
description: "ค้นหาวิธีบันทึกงานนำเสนอโดยใช้ Aspose.Slides สำหรับ Node.js ผ่าน Java—ส่งออกเป็น PowerPoint หรือ OpenDocument พร้อมคงการจัดวาง ฟอนต์ และเอฟเฟกต์."
---
## **ภาพรวม**

[Open Presentations in JavaScript](/slides/th/nodejs-java/open-presentation/) บรรยายวิธีใช้คลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) เพื่อเปิดงานนำเสนอ บทความนี้อธิบายวิธีสร้างและบันทึกงานนำเสนอ คลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) มีเนื้อหาของงานนำเสนอ ไม่ว่าคุณจะสร้างงานนำตั้งแต่ศูนย์หรือแก้ไขงานที่มีอยู่ คุณจะต้องบันทึกเมื่อทำเสร็จ กับ Aspose.Slides สำหรับ Node.js คุณสามารถบันทึกเป็น **ไฟล์** หรือ **สตรีม** บทความนี้อธิบายวิธีต่าง ๆ ในการบันทึกงานนำเสนอ

## **บันทึกงานนำเสนอเป็นไฟล์**

บันทึกงานนำเสนอเป็นไฟล์โดยเรียกเมธอด `save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) ส่งชื่อไฟล์และรูปแบบการบันทึกไปยังเมธอด ตัวอย่างต่อไปนี้แสดงวิธีบันทึกงานนำเสนอด้วย Aspose.Slides

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    // ทำงานบางอย่างที่นี่...

    // บันทึกงานนำเสนอเป็นไฟล์.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **บันทึกงานนำเสนอเป็นสตรีม**

คุณสามารถบันทึกงานนำเสนอเป็นสตรีมได้โดยส่งสตรีมผลลัพธ์ไปยังเมธอด `save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) งานนำเสนอสามารถเขียนลงสตรีมหลายประเภท ในตัวอย่างด้านล่าง เราจะสร้างงานนำเสนอใหม่และบันทึกลงสตรีมไฟล์

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // บันทึกงานนำเสนอไปยังสตรีม.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **บันทึกงานนำเสนอพร้อมประเภทมุมมองที่กำหนดไว้ล่วงหน้า**

Aspose.Slides ให้คุณกำหนดมุมมองเริ่มต้นที่ PowerPoint ใช้เมื่อเปิดงานนำเสนอที่สร้างขึ้นผ่านคลาส [ViewProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/viewproperties/) ใช้เมธอด [setLastView](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/viewproperties/#setLastView) พร้อมค่าจาก enumeration [ViewType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/viewtype/)

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **บันทึกงานนำเสนอในรูปแบบ Strict Office Open XML**

Aspose.Slides ให้คุณบันทึกงานนำเสนอในรูปแบบ Strict Office Open XML ใช้คลาส [PptxOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pptxoptions/) และตั้งค่า property conformance เมื่อบันทึก หากคุณตั้งค่า [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict) ไฟล์ผลลัพธ์จะถูกบันทึกในรูปแบบ Strict Office Open XML

ตัวอย่างด้านล่างสร้างงานนำเสนอและบันทึกเป็นรูปแบบ Strict Office Open XML

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    // บันทึกงานนำเสนอในรูปแบบ Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML โหมด Zip64**

ไฟล์ Office Open XML เป็นไฟล์ ZIP ที่กำหนดขีดจำกัด 4 GB (2^32 ไบต์) สำหรับขนาดไฟล์ที่ไม่บีบอัด ขนาดบีบอัดของไฟล์ใดไฟล์หนึ่ง และขนาดรวมของไฟล์เก็บรวม รวมถึงจำกัดจำนวนไฟล์ที่ 65 535 (2^16‑1) ไฟล์ ส่วนขยายรูปแบบ ZIP64 ยกขีดจำกัดเหล่านี้เป็น 2^64

เมธอด [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) ให้คุณเลือกว่าเมื่อใดจะใช้ส่วนขยายรูปแบบ ZIP64 เมื่อบันทึกไฟล์ Office Open XML

เมธอดนี้สามารถใช้กับโหมดต่อไปนี้:

- [IfNecessary](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/zip64mode/#IfNecessary) ใช้ส่วนขยาย ZIP64 เฉพาะเมื่อการนำเสนอเกินขีดจำกัดดังกล่าว นี่คือโหมดค่าเริ่มต้น
- [Never](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/zip64mode/#Never) ไม่เคยใช้ส่วนขยาย ZIP64
- [Always](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/zip64mode/#Always) ใช้ส่วนขยาย ZIP64 เสมอ

โค้ดต่อไปนี้แสดงวิธีบันทึกงานนำเสนอเป็นไฟล์ PPTX พร้อมเปิดใช้งานส่วนขยายรูปแบบ ZIP64:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
เมื่อบันทึกด้วย [Zip64Mode.Never](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/zip64mode/#Never) จะเกิดข้อยกเว้น [PptxException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pptxexception/) หากงานนำเสนอไม่สามารถบันทึกในรูปแบบ ZIP32
{{% /alert %}}

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML พร้อมระดับการบีบอัด**

เมื่อทำงานกับงานนำเสนอขนาดใหญ่ คุณสามารถปรับระดับการบีบอัดเพื่อสมดุลระหว่างขนาดไฟล์และเวลาประมวลผล ตามความต้องการของคุณ คุณอาจต้องการประมวลผลที่เร็วหรือไฟล์ผลลัพธ์ที่เล็กกว่า Aspose.Slides ให้บริการเมธอด [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel) ซึ่งอนุญาตให้คุณระบุระดับการบีบอัดที่ใช้เมื่อบันทึกงานนำเสนอในรูปแบบ Office Open XML

ระดับการบีบอัดที่พร้อมใช้งานมีดังนี้:

- [**None**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compressionlevel/#None): ไม่มีการบีบอัด ไฟล์จะถูกเก็บตามเดิม
- [**Level1**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compressionlevel/#Level1): การบีบอัดที่เร็วที่สุดด้วยอัตราการบีบอัดต่ำที่สุด
- [**Level2**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compressionlevel/#Level2): บีบอัดเร็วกว่าโดยอัตราการบีบอัดดีกว่า **Level1** เล็กน้อย
- [**Level3**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compressionlevel/#Level3): ให้การบีบอัดที่ดีกว่า **Level2** โดยมีผลกระทบปานกลางต่อเวลาประมวลผล
- [**Level4**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compressionlevel/#Level4): ให้การบีบอัดที่ดีกว่า **Level3**
- [**Level5**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compressionlevel/#Level5): ให้การบีบอัดที่ดีขึ้นเหนือ **Level4** พร้อมเวลาประมวลผลเพิ่ม
- [**Level6**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compressionlevel/#Level6): การบีบอัดมาตรฐานที่ให้ความสมดุลระหว่างความเร็วและขนาดไฟล์ นี่คือ *ระดับการบีบอัดเริ่มต้น*
- [**Level7**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compressionlevel/#Level7): ให้การบีบอัดที่ดีกว่า **Level6** แต่ประมวลผลช้ากว่า
- [**Level8**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compressionlevel/#Level8): ให้การบีบอัดที่ดีกว่า **Level7**
- [**Level9**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compressionlevel/#Level9): การบีบอัดสูงสุด ผลิตไฟล์ที่เล็กที่สุดแต่ใช้เวลาประมวลผลนานที่สุด

ตัวอย่างต่อไปนี้แสดงวิธีบันทึกงานนำเสนอเป็นไฟล์ PPTX *โดยไม่มีการบีบอัด*:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.None);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

ตัวอย่างนี้แสดงวิธีบันทึกงานนำเสนอเป็นไฟล์ PPTX พร้อม *การบีบอัดสูงสุด*:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **บันทึกงานนำเสนอโดยไม่รีเฟรชภาพย่อ**

เมธอด [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) ควบคุมการสร้างภาพย่อเมื่อบันทึกงานนำเสนอเป็น PPTX:

- หากตั้งค่าเป็น `true` ภาพย่อจะได้รับการรีเฟรชระหว่างการบันทึก นี่คือค่าเริ่มต้น
- หากตั้งค่าเป็น `false` ภาพย่อปัจจุบันจะถูกเก็บไว้ หากงานนำเสนอไม่มีภาพย่อ จะไม่มีการสร้าง

ในโค้ดด้านล่าง งานนำเสนอจะถูกบันทึกเป็น PPTX โดยไม่รีเฟรชภาพย่อของมัน

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setRefreshThumbnail(false);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
ตัวเลือกนี้ช่วยลดเวลาที่ต้องใช้ในการบันทึกงานนำเสนอในรูปแบบ PPTX
{{% /alert %}}

## **บันทึกการอัพเดตความคืบหน้าเป็นเปอร์เซ็นต์**

การรายงานความคืบหน้าในการบันทึกกำหนดค่าผ่านเมธอด [setProgressCallback](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) ของคลาส [SaveOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/saveoptions/) และคลาสย่อยของมัน ให้ทำการพร็อกซี่ Java ที่ 구현 인터페이스 [IProgressCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprogresscallback/) ; ในระหว่างการส่งออก คอลแบ็กจะรับอัปเดตเปอร์เซ็นต์เป็นระยะ

โค้ดส니ippets ต่อไปนี้แสดงวิธีใช้ `IProgressCallback`

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // ใช้ค่าร้อยละของความคืบหน้าในที่นี้.
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

let saveOptions = new aspose.slides.PdfOptions();
saveOptions.setProgressCallback(ExportProgressHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", aspose.slides.SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose ได้พัฒนาแอป [PowerPoint Splitter ฟรี](https://products.aspose.app/slides/th/splitter) โดยใช้ API ของตนเอง แอปนี้ช่วยให้คุณแยกงานนำเสนอเป็นหลายไฟล์โดยบันทึกสไลด์ที่เลือกเป็นไฟล์ PPTX หรือ PPT ใหม่
{{% /alert %}}

## **คำถามที่พบบ่อย**

**รองรับการ "บันทึกแบบเร็ว" (การบันทึกเป็นขั้นตอน) ที่บันทึกเฉพาะการเปลี่ยนแปลงหรือไม่?**

ไม่ การบันทึกจะสร้างไฟล์เป้าหมายเต็มรูปแบบทุกครั้ง; การบันทึกแบบ "เร็ว" แบบเพิ่มส่วนไม่รองรับ

**ปลอดภัยต่อการทำงานหลายเธรดหรือไม่ที่จะบันทึกอินสแตนซ์ Presentation เดียวจากหลายเธรด?**

ไม่ อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) [ไม่ได้ปลอดภัยต่อการทำงานหลายเธรด](/slides/th/nodejs-java/multithreading/) ; ควรบันทึกจากเธรดเดียว

**เกิดอะไรขึ้นกับไฮเปอร์ลิงก์และไฟล์ที่เชื่อมโยงจากภายนอกเมื่อบันทึก?**

[Hyperlinks](/slides/th/nodejs-java/manage-hyperlinks/) จะถูกเก็บไว้ ไฟล์ที่เชื่อมโยงจากภายนอก (เช่น วิดีโอผ่านเส้นทางสัมพันธ์) จะไม่ถูกคัดลอกโดยอัตโนมัติ — โปรดตรวจสอบให้แน่ใจว่าเส้นทางที่อ้างอิงยังคงเข้าถึงได้

**ฉันสามารถตั้งค่า/บันทึกเมตาดาต้าเอกสาร (ผู้เขียน, ชื่อเรื่อง, บริษัท, วันที่) ได้หรือไม่?**

ใช่ คุณสมบัติมาตรฐานของ [document properties](/slides/th/nodejs-java/presentation-properties/) ได้รับการสนับสนุนและจะถูกเขียนลงในไฟล์เมื่อบันทึก