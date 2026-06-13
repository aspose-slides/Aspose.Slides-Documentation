---
title: บันทึกการนำเสนอใน JavaScript
linktitle: บันทึกการนำเสนอ
type: docs
weight: 80
url: /th/nodejs-java/save-presentation/
keywords:
- บันทึก PowerPoint
- บันทึก OpenDocument
- บันทึกการนำเสนอ
- บันทึกสไลด์
- บันทึก PPT
- บันทึก PPTX
- บันทึก ODP
- การนำเสนอเป็นไฟล์
- การนำเสนอเป็นสตรีม
- ประเภทมุมมองที่กำหนดล่วงหน้า
- รูปแบบ Strict Office Open XML
- โหมด Zip64
- รีเฟรชภาพย่อ
- บันทึกความคืบหน้า
- Node.js
- JavaScript
- Aspose.Slides
description: "ค้นพบวิธีบันทึกการนำเสนอโดยใช้ Aspose.Slides สำหรับ Node.js ผ่าน Java—ส่งออกเป็น PowerPoint หรือ OpenDocument พร้อมรักษาการจัดวาง ฟอนต์และเอฟเฟกต์"
---
## **ภาพรวม**

[Open Presentations in JavaScript](/slides/th/nodejs-java/open-presentation/) อธิบายวิธีใช้คลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) เพื่อเปิดการนำเสนอ บทความนี้อธิบายวิธีสร้างและบันทึกการนำเสนอ คลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) มีเนื้อหาของการนำเสนอ ไม่ว่าคุณจะสร้างการนำเสนอจากศูนย์หรือแก้ไขการนำเสนอที่มีอยู่แล้ว คุณจะต้องบันทึกเมื่อทำเสร็จแล้ว ด้วย Aspose.Slides สำหรับ Node.js คุณสามารถบันทึกเป็น **ไฟล์** หรือ **สตรีม** บทความนี้อธิบายวิธีต่าง ๆ ในการบันทึกการนำเสนอ

## **บันทึกการนำเสนอเป็นไฟล์**

บันทึกการนำเสนอเป็นไฟล์โดยเรียกเมธอด `save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) ส่งชื่อไฟล์และรูปแบบการบันทึกให้เมธอด ตัวอย่างต่อไปนี้แสดงวิธีบันทึกการนำเสนอด้วย Aspose.Slides

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    // ทำงานบางอย่างที่นี่...

    // บันทึกการนำเสนอเป็นไฟล์.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **บันทึกการนำเสนอเป็นสตรีม**

คุณสามารถบันทึกการนำเสนอเป็นสตรีมโดยส่งสตรีมเอาต์พุตให้กับเมธอด `save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) การนำเสนอสามารถเขียนไปยังสตรีมประเภทต่าง ๆ ได้ ในตัวอย่างด้านล่าง เราได้สร้างการนำเสนอใหม่และบันทึกเป็นสตรีมไฟล์

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // บันทึกการนำเสนอลงในสตรีม.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **บันทึกการนำเสนอด้วยประเภทมุมมองที่กำหนดล่วงหน้า**

Aspose.Slides ให้คุณตั้งค่ามุมมองเริ่มต้นที่ PowerPoint ใช้เมื่อเปิดการนำเสนอที่สร้างขึ้นผ่านคลาส [ViewProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/viewproperties/) ใช้เมธอด [setLastView](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/viewproperties/#setLastView) พร้อมค่าจาก enum [ViewType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/viewtype/)

```js
let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **บันทึกการนำเสนอในรูปแบบ Strict Office Open XML**

Aspose.Slides ให้คุณบันทึกการนำเสนอในรูปแบบ Strict Office Open XML ใช้คลาส [PptxOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pptxoptions/) และตั้งค่า property conformance ขณะบันทึก หากคุณตั้งค่า [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict) ไฟล์ผลลัพธ์จะถูกบันทึกในรูปแบบ Strict Office Open XML

ตัวอย่างด้านล่างสร้างการนำเสนอและบันทึกเป็นรูปแบบ Strict Office Open XML

```js
let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    // บันทึกการนำเสนอในรูปแบบ Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **บันทึกการนำเสนอในรูปแบบ Office Open XML ในโหมด Zip64**

ไฟล์ Office Open XML คือไฟล์ ZIP ที่กำหนดขีดจำกัด 4 GB (2^32 ไบต์) สำหรับขนาดไฟล์ที่ไม่ได้บีบอัด, ขนาดไฟล์ที่บีบอัด, และขนาดรวมของเอกสาร นอกจากนี้ยังจำกัดจำนวนไฟล์ในเอกสารไม่เกิน 65 535 (2^16‑1) ไฟล์ รูปแบบขยาย Zip64 จะเพิ่มขีดจำกัดเหล่านี้เป็น 2^64

เมธอด [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) ให้คุณเลือกใช้ส่วนขยายรูปแบบ ZIP64 เมื่อบันทึกไฟล์ Office Open XML

เมธอดนี้สามารถใช้กับโหมดต่อไปนี้:

- [IfNecessary](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/zip64mode/#IfNecessary) ใช้ส่วนขยายรูปแบบ ZIP64 เฉพาะเมื่อการนำเสนอเกินขีดจำกัดข้างต้น นี่คือโหมดเริ่มต้น
- [Never](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/zip64mode/#Never) ไม่ใช้ส่วนขยายรูปแบบ ZIP64 เลย
- [Always](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/zip64mode/#Always) ใช้ส่วนขยายรูปแบบ ZIP64 เสมอ

โค้ดต่อไปนี้แสดงวิธีบันทึกการนำเสนอเป็น PPTX พร้อมเปิดใช้ส่วนขยายรูปแบบ ZIP64:

```js
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
เมื่อบันทึกโดยใช้ [Zip64Mode.Never](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/zip64mode/#Never) จะมีการโยน [PptxException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pptxexception/) หากไม่สามารถบันทึกการนำเสนอในรูปแบบ ZIP32 ได้
{{% /alert %}}

## **บันทึกการนำเสนอโดยไม่รีเฟรชภาพย่อ**

เมธอด [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) ควบคุมการสร้างภาพย่อเมื่อบันทึกการนำเสนอเป็น PPTX:

- หากตั้งค่าเป็น `true` ภาพย่อจะถูกรีเฟรชขณะบันทึก นี่เป็นค่าเริ่มต้น
- หากตั้งค่าเป็น `false` ภาพย่อปัจจุบันจะถูกคงไว้ หากการนำเสนอไม่มีภาพย่อ จะไม่มีการสร้างภาพย่อ

ในโค้ดด้านล่าง การนำเสนอถูกบันทึกเป็น PPTX โดยไม่รีเฟรชภาพย่อของมัน

```js
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
ตัวเลือกนี้ช่วยลดเวลาที่ใช้ในการบันทึกการนำเสนอในรูปแบบ PPTX
{{% /alert %}}

## **บันทึกการอัปเดตความคืบหน้าเป็นเปอร์เซ็นต์**

การรายงานความคืบหน้าในการบันทึกกำหนดค่าผ่านเมธอด [setProgressCallback](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) ของ [SaveOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/saveoptions/) และคลาสย่อยของมัน ให้จัดหา Java proxy ที่ทำตามอินเทอร์เฟซ [IProgressCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprogresscallback/) ระหว่างการส่งออก คอลแบ็กจะรับการอัปเดตเปอร์เซ็นต์เป็นระยะ

โค้ดตัวอย่างต่อไปนี้แสดงวิธีใช้ `IProgressCallback`

```javascript
const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // ใช้ค่าร้อยละของความคืบหน้าที่นี่.
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
Aspose ได้พัฒนาแอป [PowerPoint Splitter ฟรี](https://products.aspose.app/slides/th/splitter) โดยใช้ API ของตนเอง แอปนี้ช่วยให้คุณแยกการนำเสนอเป็นหลายไฟล์โดยบันทึกสไลด์ที่เลือกเป็นไฟล์ PPTX หรือ PPT ใหม่
{{% /alert %}}

## **คำถามที่พบบ่อย**

**Is "fast save" (incremental save) supported so only changes are written?**

ไม่ การบันทึกจะสร้างไฟล์เป้าหมายเต็มรูปแบบทุกครั้ง; การบันทึกแบบเพิ่มส่วน "fast save" ไม่ได้รับการสนับสนุน

**Is it thread-safe to save the same Presentation instance from multiple threads?**

ไม่ อินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) [ไม่มีความปลอดภัยต่อหลายเธรด](/slides/th/nodejs-java/multithreading/) ควรบันทึกจากเธรดเดียว

**What happens to hyperlinks and externally linked files when saving?**

[Hyperlinks](/slides/th/nodejs-java/manage-hyperlinks/) จะถูกเก็บไว้ ไฟล์ที่เชื่อมโยงจากภายนอก (เช่น วิดีโอที่อ้างอิงด้วยเส้นทาง relative) จะไม่ถูกคัดลอกรวมโดยอัตโนมัติ — ควรตรวจสอบให้เส้นทางที่อ้างอิงยังคงเข้าถึงได้

**Can I set/save document metadata (Author, Title, Company, Date)?**

ใช่ คุณสมบัติมาตรฐานของ [document properties](/slides/th/nodejs-java/presentation-properties/) ได้รับการสนับสนุนและจะถูกเขียนลงในไฟล์เมื่อบันทึก