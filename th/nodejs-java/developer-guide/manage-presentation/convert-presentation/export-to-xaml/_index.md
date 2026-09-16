---
title: ส่งออกงานนำเสนอเป็น XAML ใน JavaScript
linktitle: งานนำเสนอเป็น XAML
type: docs
weight: 30
url: /th/nodejs-java/export-to-xaml/
keywords:
- ส่งออก PowerPoint
- ส่งออก OpenDocument
- ส่งออกงานนำเสนอ
- แปลง PowerPoint
- แปลง OpenDocument
- แปลงงานนำเสนอ
- PowerPoint เป็น XAML
- OpenDocument เป็น XAML
- งานนำเสนอเป็น XAML
- PPT เป็น XAML
- PPTX เป็น XAML
- ODP เป็น XAML
- บันทึก PPT เป็น XAML
- บันทึก PPTX เป็น XAML
- บันทึก ODP เป็น XAML
- ส่งออก PPT เป็น XAML
- ส่งออก PPTX เป็น XAML
- ส่งออก ODP เป็น XAML
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint และ OpenDocument เป็น XAML ใน JavaScript ด้วย Aspose.Slides—โซลูชันที่รวดเร็ว ปราศจาก Office ซึ่งรักษาเค้าโครงของคุณไว้ครบถ้วน"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการส่งออกงานนำเสนอ PowerPoint ไปเป็น XAML ด้วย Aspose.Slides โดยรวมการแนะนำสั้น ๆ เกี่ยวกับ XAML, แสดงวิธีบันทึกงานนำเสนอเป็น XAML ด้วยการตั้งค่าเริ่มต้น, และสาธิตวิธีปรับแต่งการส่งออกผ่าน [XamlOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/xamloptions/), รวมถึงการส่งออกสไลด์ที่ซ่อนอยู่ บทความยังตอบคำถามทั่วไปบางข้อที่เกี่ยวกับฟอนต์สำรอง, ความเข้ากันได้ของสแต็ก XAML, และพฤติกรรมการส่งออกสไลด์ที่ซ่อนอยู่

## **เกี่ยวกับ XAML**

XAML เป็นภาษามาร์กอัปประเภท XML ที่ใช้อธิบายส่วนต่อประสานผู้ใช้ในเฟรมเวิร์กเช่น WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) และ Xamarin.Forms

คุณสามารถทำงานกับไฟล์ XAML ในเครื่องมืออกแบบแบบภาพหรือเขียนและแก้ไขมาร์กอัปโดยตรงได้

## **ส่งออกงานนำเสนอเป็น XAML ด้วยตัวเลือกเริ่มต้น**

ตัวอย่าง JavaScript ด้านล่างแสดงวิธีส่งออกงานนำเสนอเป็น XAML ด้วยการตั้งค่าเริ่มต้น:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

โดยค่าเริ่มต้น สไลด์ที่ส่งออกจะถูกบันทึกในโฟลเดอร์ `input` ย่อยของไดเรกทอรีทำงานปัจจุบันของกระบวนการ โฟลเดอร์จะถูกสร้างโดยอัตโนมัติและรูปภาพที่จำเป็นใดๆ จะถูกบันทึกในนั้นเช่นกัน

ชื่อโฟลเดอร์ผลลัพธ์จะถูกนำมาจากชื่อไฟล์ต้นฉบับโดยไม่มีส่วนขยาย ใน Aspose.Slides for Node.js via Java 26.8 การส่งออก `input.pptx` จะสร้างเส้นทางซ้อนกันเช่น `input/input/Slide_1.xaml` ให้เก็บเส้นทางที่สร้างทั้งหมดไว้เมื่อติดตามผลลัพธ์ การส่งออกเริ่มต้นจะอิงตามไดเรกทอรีทำงานปัจจุบัน ไม่จำเป็นต้องอยู่ในโฟลเดอร์เดียวกับไฟล์อินพุต

## **ส่งออกงานนำเสนอเป็น XAML ด้วยตัวเลือกที่กำหนดเอง**

ใช้ interface [IXamlOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/ixamloptions/) เพื่อควบคุมวิธีที่ Aspose.Slides ส่งออกงานนำเสนอเป็น XAML

เพื่อบันทึกผลลัพธ์ลงในตำแหน่งที่กำหนดเอง ให้ implement [IXamlOutputSaver](https://reference.aspose.com/slides/th/java/com.aspose.slides/ixamloutputsaver/) แล้วส่งออบเจกต์ของคุณไปยังเมธอด [setOutputSaver](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) ของ [XamlOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/xamloptions/)

เพื่อรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์ XAML ให้เรียก [setExportHiddenSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) ด้วยค่า `true` ตามตัวอย่าง JavaScript ด้านล่าง:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **จับบันทึก XAML ที่สร้างทั้งหมด**

การส่งออก XAML สามารถสร้างเอกสาร XAML สำหรับแต่ละสไลด์ที่ส่งออกพร้อมกับรูปภาพและทรัพยากรเสริมแยกต่างหาก กำหนด [IXamlOutputSaver](https://reference.aspose.com/slides/th/java/com.aspose.slides/ixamloutputsaver/) แบบกำหนดเองให้กับ [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) เพื่อรับบันทึกเหล่านี้แทนการใช้ตัวบันทึกไฟล์ระบบเริ่มการส่งออกด้วยเมธอด overload ของ [Presentation.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#save) ที่รับ XAML options

ใน Node.js ให้ implement interface Java ด้วย `java.newProxy` จากแพ็กเกจ `java` ที่ Aspose.Slides ใช้ ควรรักษา proxy ให้เข้าถึงได้จนกว่าการส่งออกจะเสร็จ

### **ทำความเข้าใจวงจร Callback**

ตัวส่งออกจะเรียก [IXamlOutputSaver.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) แยกกันสำหรับแต่ละบันทึกที่สร้าง:

- `path` ระบุบันทึกและอาจรวมไดเรกทอรีแบบสัมพันธ์ เก็บข้อมูลนี้ไว้เพราะ XAML อาจอ้างอิงทรัพยากรโดยใช้เส้นทางสัมพันธ์
- `data` มีไบต์ของบันทึก รูปภาพและทรัพยากรไบนารีอื่น ๆ ต้องไม่ถูกถอดรหัสเป็นข้อความ
- ตัวบันทึกต้องรับผิดชอบในการเก็บหรือคงข้อมูลก่อนคืนค่า ตัวอย่างจะคัดลอกอาร์เรย์ไบต์ของ Java ไปยังบัฟเฟอร์ Node.js ที่เป็นของแอปพลิเคชัน
- ถือว่าการส่งออกสำเร็จเมื่อเมธอดบันทึกงานนำเสนอคืนค่าและทุก callback ทำงานสำเร็จ อย่ารับข้อผิดพลาดการจัดเก็บหรือเริ่มการเขียนในพื้นหลังโดยไม่ตรวจสอบ หากการคงข้อมูลเกิดขึ้นภายหลัง ให้รายงานความสำเร็จโดยรวมหลังจากขั้นตอนนั้นสำเร็จด้วย

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) ยังใช้กับตัวบันทึกที่กำหนดเอง ค่าเริ่มต้น `false` จะไม่รวมเอกสาร XAML ของสไลด์ที่ซ่อนอยู่ การตั้งค่าเป็น `true` จะรวมสไลด์เหล่านั้นและทรัพยากรที่จำเป็น จำนวนทรัพยากรขึ้นกับงานนำเสนอ; อย่าสมมติว่ามี callback หนึ่งครั้งต่อสไลด์หรือมีลำดับ callback คงที่

### **ส่งออกเป็นหน่วยความจำและตรวจสอบบันทึก**

ตัวอย่างเต็มนี้โหลด `input.pptx` เก็บบันทึกทั้งหมดไว้ในแผนที่ JavaScript จากชื่อไปยังบัฟเฟอร์ แล้วพิมพ์ชื่อ, ชนิด, และจำนวนไบต์ โดยรักษาชื่อที่ให้มาอย่างเคร่งครัด ชื่อซ้ำทำให้คอลเลกชันถือว่าไม่ถูกต้องแทนการเขียนทับบันทึกโดยไม่แจ้ง ตัวอย่างตรวจสอบเงื่อนไขนี้ก่อนใช้ผลลัพธ์

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const inspectXamlText = false;
    for (const [name, data] of artifacts) {
        const isXaml = /\.xaml$/i.test(name);
        const isImage = /\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$/i.test(name);
        const kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
        console.log(name + ": " + data.length + " bytes (" + kind + ")");

        // ถอดรหัสเฉพาะ XAML และเท่านั้นเมื่อจำเป็นต้องตรวจสอบข้อความ
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

การตรวจสอบชนิดของส่วนขยายเป็นประโยชน์สำหรับการตรวจสอบ; เก็บบันทึกทั้งหมดไว้รวมถึงชนิดทรัพยากรที่ไม่คุ้นเคย อย่าแก้ไขไบต์เมื่อเก็บหรือส่งต่อ ใช้การถอดรหัส UTF-8 เฉพาะกับ XAML ที่ต้องการการประมวลผลข้อความ

### **บรรจุบันทึกที่เก็บไว้ในไฟล์ ZIP**

ตัวอย่างแยกนี้รวบรวมผลการส่งออก ตรวจสอบชื่อ แล้วเขียนไบต์ดิบลงในไฟล์ ZIP โดยใช้ Java bridge ZIP จะถูกประกอบในหน่วยความจำก่อนบันทึกลงดิสก์ ชื่อไฟล์ ZIP ที่ไม่ซ้ำกันจะแยกงานส่งออกที่ทำงานพร้อมกัน รายการใน ZIP ใช้เครื่องหมายทับหน้า (`/`) และรักษาไดเรกทอรีสัมพันธ์ ชื่อที่ไม่ปลอดภัยหรือชน overlapping หลังการทำ normalization จะทำให้แพ็คเกจทั้งหมดถูกปฏิเสธก่อนเขียน

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

const entries = new Map();
const entryNames = new Set();
for (const [name, data] of artifacts) {
    const entryName = name.replace(/\\/g, "/");
    const segments = entryName.split("/");
    const unsafeName = entryName.startsWith("/") || entryName.includes(":") || segments.some(segment => segment.trim() === "" || segment === "." || segment === "..");
    const comparisonName = entryName.toLowerCase();
    if (unsafeName || entryNames.has(comparisonName)) {
        valid = false;
        console.error("Export rejected: unsafe or duplicate artifact name: " + name);
        break;
    }
    entryNames.add(comparisonName);
    entries.set(entryName, data);
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const fs = require("node:fs");
    const crypto = require("node:crypto");
    const archivePath = "xaml-" + crypto.randomUUID() + ".zip";
    const output = java.newInstanceSync("java.io.ByteArrayOutputStream");
    const archive = java.newInstanceSync("java.util.zip.ZipOutputStream", output);
    try {
        for (const [name, data] of entries) {
            const entry = java.newInstanceSync("java.util.zip.ZipEntry", name);
            archive.putNextEntry(entry);
            const signedBytes = Array.from(data, value => value > 127 ? value - 256 : value);
            const bytes = java.newArray("byte", signedBytes);
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // การปิดทำให้ไดเรกทอรี ZIP สมบูรณ์ก่อนที่ไฟล์อาร์ไคฟ์จะถูกบันทึก
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

ตัวอย่างใช้ [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) เพื่อเขียนไฟล์ ZIP ภายในเครื่องส่งออกเองไม่ได้เขียนไฟล์ XAML หรือรูปภาพแยกออก สำหรับการจัดเก็บระยะไกล ให้แทนที่ขั้นตอนการเขียน ZIP ด้วยการอัปโหลดอาร์เรย์ไบต์ที่รวบรวมไว้ ใช้ตัวระบุงานส่งออกพร้อมชื่อสัมพันธ์เต็มเป็นคีย์บล็อบ หรือเก็บตัวระบุงาน, ชื่อสัมพันธ์, และข้อมูลไบต์ในแถวฐานข้อมูล เผยแพร่งานเฉพาะหลังจากการอัปโหลดทั้งหมดเสร็จหรือการทำธุรกรรมฐานข้อมูลคอมมิต ทำความสะอาดผลลัพธ์บางส่วนหากการคงข้อมูลล้มเหลว

สำหรับงานนำเสนอขนาดใหญ่ ตัวบันทึกแบบกำหนดเองสามารถคงบันทึกแต่ละรายการโดยตรงลงในที่จัดเก็บของแอปพลิเคชันเพื่อหลีกเลี่ยงการเก็บสำเนาเพิ่มเติมของการส่งออกทั้งหมดในหน่วยความจำของแอป ควรทำให้แต่ละ callback เป็นแบบ synchronous จากมุมมองของตัวส่งออก: คืนค่าเพียงหลังจากปลายทางยอมรับไบต์และให้ความล้มเหลวส่งต่อไปยังผู้เรียก

### **คงชื่อทรัพยากรและตรวจสอบการอ้างอิง**

- ทำ normalization ตัวแยกเส้นทางเมื่อปลายทางต้องการ แต่คงไดเรกทอรีสัมพันธ์ไว้ อย่าใช้เฉพาะ basename เว้นแต่ชื่อที่สร้างทั้งหมดเป็นเอกลักษณ์และการอ้างอิงทรัพยากรยังคงถูกต้อง
- ใช้การตรวจสอบชื่อเฉพาะปลายทาง เมื่อเขียนไฟล์แยก ให้ปฏิเสธเส้นทางที่เริ่มต้นด้วย root หรือส่วน traversal, แก้ปลายทางเป็นเส้นทางเต็ม, และตรวจสอบให้แน่ใจว่าอยู่ภายใต้ไดเรกทอรีส่งออกที่ตั้งใจ รวมเครื่องหมายแยกเส้นทางในขั้นตรวจสอบการครอบครอง ใช้ไดเรกทอรีที่แอปควบคุมโดยไม่มี symbolic link ที่อาจเปลี่ยนที่เขียน
- ใช้ตัวบันทึกและ namespace การจัดเก็บแยกสำหรับแต่ละงานส่งออก ตรวจจับการชนกันหลังจากทำ normalization ของตัวแยกและตามกฎความไวต่อกรณีของปลายทาง
- ก่อนเผยแพร่ ให้พาร์สเอกสาร XAML แต่ละไฟล์เป็น XML แล้วตรวจสอบการอ้างอิงทรัพยากรแบบไฟล์ เช่น แอตทริบิวต์ `Source` หรือ `ImageSource` ของรูปภาพ แก้ URI สัมพัทธ์ต่อไดเรกทอรีของบันทึก XAML นั้น, ทำ normalization ชื่อการจัดเก็บที่ได้, และยืนยันว่าคีย์แผนที่, รายการ ZIP, หรืออ็อบเจ็กต์ที่จัดเก็บนั้นมีอยู่ แยกการจัดการ URI ภายนอกและการแสดง XAML expression ออกจากชื่อไฟล์สัมพันธ์

ตัวอย่างเช่น ถ้า `input/Slide_1.xaml` อ้างอิง `images/image1.png` ทรัพยากรที่จัดเก็บต้องพร้อมใช้งานเป็น `input/images/image1.png` การเก็บแค่ `image1.png` จะทำให้ความสัมพันธ์นี้เสียหาย สำหรับการจัดเก็บแบบ object storage ให้คงโครงสร้างเดียวกันภายใต้คำนำหน้างานและทำให้ URL ของทรัพยากรเหล่านั้นเข้าถึงได้โดยผู้ใช้ XAML เปิด ZIP ที่เสร็จแล้วเพื่อตรวจสอบชื่อรายการและไบต์ของทรัพยากร แล้วโหลดสไลด์ตัวอย่างในสภาพแวดล้อม XAML ปลายทางเพื่อยืนยันว่ารูปภาพถูก resolve อย่างถูกต้อง

## **คำถามที่พบบ่อย**

**ฉันจะทำอย่างไรเพื่อให้ฟอนต์คาดการณ์ได้ถ้าไม่มีฟอนต์ต้นฉบับบนเครื่อง?**

เรียก [setDefaultRegularFont](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) ใน [XamlOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/xamloptions/) — ฟอนต์นี้จะถูกใช้เป็นฟอนต์สำรองระหว่างการส่งออกเมื่อไม่มีฟอนต์ต้นฉบับ อย่างไรก็ตาม ไม่ได้รับประกันว่า XAML ที่สร้างจะอ้างอิงฟอนต์สำรองหรือฟอนต์นั้นจะมีบนเครื่องเป้าหมาย ตรวจสอบให้ฟอนต์ที่อ้างอิงโดย XAML มีอยู่ในสภาพแวดล้อมที่แสดงผล

**XAML ที่ส่งออกออกแบบมาสำหรับ WPF เท่านั้นหรือสามารถใช้ในสแต็ก XAML อื่นได้เช่นกัน?**

Aspose.Slides ส่งออก XAML ของ WPF ผ่าน API สาธารณะ ความเข้ากันได้กับสแต็ก XAML อื่น ๆ เช่น UWP และ Xamarin.Forms ไม่ได้รับประกัน ควรทดสอบมาร์กอัปที่สร้างในสภาพแวดล้อมเป้าหมายของคุณ

**สไลด์ที่ซ่อนอยู่ได้รับการสนับสนุนหรือไม่ และฉันจะป้องกันไม่ให้มันถูกส่งออกโดยค่าเริ่มต้นได้อย่างไร?**

โดยค่าเริ่มต้น สไลด์ที่ซ่อนจะไม่ถูกรวมไว้ คุณสามารถควบคุมพฤติกรรมนี้ผ่าน [setExportHiddenSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) ใน [XamlOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/xamloptions/) — ควรปิดการใช้งานหากไม่ต้องการส่งออกสไลด์ที่ซ่อนอยู่