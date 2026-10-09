---
title: ส่งออกรายการนำเสนอเป็น XAML ใน JavaScript
linktitle: การนำเสนอเป็น XAML
type: docs
weight: 30
url: /th/nodejs-java/export-to-xaml/
keywords:
- ส่งออก PowerPoint
- ส่งออก OpenDocument
- ส่งออกการนำเสนอ
- แปลง PowerPoint
- แปลง OpenDocument
- แปลงการนำเสนอ
- PowerPoint ไปยัง XAML
- OpenDocument ไปยัง XAML
- การนำเสนอไปยัง XAML
- PPT ไปยัง XAML
- PPTX ไปยัง XAML
- ODP ไปยัง XAML
- บันทึก PPT เป็น XAML
- บันทึก PPTX เป็น XAML
- บันทึก ODP เป็น XAML
- ส่งออก PPT ไปยัง XAML
- ส่งออก PPTX ไปยัง XAML
- ส่งออก ODP ไปยัง XAML
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint และ OpenDocument เป็น XAML ด้วย JavaScript โดยใช้ Aspose.Slides—โซลูชันที่รวดเร็วและไม่ต้องใช้ Office ที่คงรูปแบบการจัดวางของคุณไว้โดยสมบูรณ์"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการส่งออกการนำเสนอ PowerPoint เป็น XAML ด้วย Aspose.Slides รวมบทนำสั้น ๆ เกี่ยวกับ XAML แสดงวิธีบันทึกการนำเสนอเป็น XAML ด้วยการตั้งค่าเริ่มต้น และสาธิตการปรับแต่งการส่งออกผ่าน [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/), รวมถึงการส่งออกสไลด์ที่ซ่อนอยู่ บทความยังตอบคำถามทั่วไปบางส่วนเกี่ยวกับฟอนต์สำรอง ความเข้ากันได้ของสแต็ก XAML และพฤติกรรมการส่งออกสไลด์ที่ซ่อนอยู่

## **เกี่ยวกับ XAML**

XAML เป็นภาษามาร์กอัปแบบ XML ที่ใช้อธิบายส่วนต่อประสานผู้ใช้ในเฟรมเวิร์กต่าง ๆ เช่น WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) และ Xamarin.Forms

คุณสามารถทำงานกับไฟล์ XAML ในตัวออกแบบแบบภาพหรือเขียนและแก้ไขมาร์กอัปโดยตรง

## **ส่งออกการนำเสนอเป็น XAML ด้วยตัวเลือกเริ่มต้น**

ตัวอย่าง JavaScript ด้านล่างแสดงวิธีการส่งออกการนำเสนอเป็น XAML ด้วยการตั้งค่าเริ่มต้น:

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

โดยค่าเริ่มต้น สไลด์ที่ส่งออกจะถูกบันทึกในโฟลเดอร์ย่อย `input` ของไดเรกทอรีทำงานปัจจุบันของกระบวนการ โฟลเดอร์จะถูกสร้างโดยอัตโนมัติ และภาพที่จำเป็นใด ๆ จะถูกบันทึกไว้ที่นั่นด้วย

ชื่อโฟลเดอร์ผลลัพธ์จะถูกนำมาจากชื่อไฟล์ต้นทางโดยไม่มีนามสกุล ใน Aspose.Slides for Node.js via Java 26.8 การส่งออก `input.pptx` จะสร้างเส้นทางซ้อนกันเช่น `input/input/Slide_1.xaml` เก็บเส้นทางที่สร้างทั้งหมดไว้เมื่อจัดการผลลัพธ์ การส่งออกค่าเริ่มต้นเป็นแบบสัมพัทธ์กับไดเรกทอรีทำงานปัจจุบัน ไม่จำเป็นต้องอยู่ข้าง ๆ กับไฟล์ต้นทาง

## **ส่งออกการนำเสนอเป็น XAML ด้วยตัวเลือกกำหนดเอง**

ใช้อินเตอร์เฟส [IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloptions/) เพื่อควบคุมวิธีที่ Aspose.Slides ส่งออกการนำเสนอเป็น XAML

เพื่อบันทึกผลลัพธ์ไปยังตำแหน่งที่กำหนดเอง ให้ทำการใช้งาน [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) และส่งออบเจกต์ของการทำงานนั้นให้กับเมธอด [setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) ของ [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/)

เพื่อรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์ XAML ให้เรียก [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) ด้วยค่า `true` ดังที่แสดงในตัวอย่าง JavaScript ด้านล่าง:

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

## **จับทุกอาร์ติแฟกต์ XAML ที่สร้างขึ้น**

การส่งออก XAML อาจสร้างเอกสาร XAML สำหรับแต่ละสไลด์ที่ส่งออก รวมถึงภาพแยกต่างหากและทรัพยากรสนับสนุนอื่น ๆ กำหนด [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) ที่กำหนดเองให้กับ [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) เพื่อรับอาร์ติแฟกต์เหล่านี้แทนการใช้ตัวบันทึกระบบไฟล์เริ่มต้น เริ่มการส่งออกด้วยเมธอดโอเวอร์โหลดของ [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) ที่รับตัวเลือก XAML

ใน Node.js ให้ทำการใช้งานอินเตอร์เฟส Java ด้วย `java.newProxy` จากแพ็กเกจ `java` ที่ Aspose.Slides ใช้ ควรรักษา proxy ให้เข้าถึงได้จนกว่าการส่งออกจะเสร็จสมบูรณ์

### **ทำความเข้าใจวงจรการเรียกกลับ**

ตัวส่งออกจะเรียก [IXamlOutputSaver.save](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) แยกกันสำหรับแต่ละอาร์ติแฟกต์ที่สร้างขึ้น:

- `path` ระบุตำแหน่งอาร์ติแฟกต์และอาจมีไดเรกทอรีแบบสัมพัทธ์ เก็บข้อมูลนี้ไว้เนื่องจาก XAML อาจอ้างอิงทรัพยากรด้วยเส้นทางสัมพัทธ์
- `data` มีไบต์ของอาร์ติแฟกต์ ภาพและทรัพยากรไบนารีอื่น ๆ ต้องไม่ถูกถอดรหัสเป็นข้อความ
- ตัวบันทึกต้องรับผิดชอบการเก็บหรือคงข้อมูลไว้ก่อนคืนค่า ตัวอย่างจะคัดลอกอาร์เรย์ไบต์ของ Java ไปยังบัฟเฟอร์ Node.js ของแอปพลิเคชัน
- ถือว่าการส่งออกสำเร็จก็ต่อเมื่อเมธอดบันทึกการนำเสนอคืนค่าและทุกการเรียกกลับทำงานสำเร็จ อย่าละเลยข้อผิดพลาดการจัดเก็บหรือเริ่มการเขียนพื้นหลังที่ไม่ถูกตรวจสอบ หากการคงข้อมูลเกิดขึ้นภายหลัง ให้รายงานความสำเร็จโดยรวมเฉพาะหลังขั้นตอนนั้นสำเร็จด้วย

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) ยังมีผลกับตัวบันทึกที่กำหนดเอง การตั้งค่าเริ่มต้น `false` จะไม่รวมเอกสาร XAML ของสไลด์ที่ซ่อนอยู่ การกำหนดค่า `true` จะรวมสไลด์เหล่านั้นและทรัพยากรที่จำเป็นสำหรับการส่งออก จำนวนทรัพยากรขึ้นอยู่กับการนำเสนอ; อย่าสมมติว่ามีการเรียกกลับหนึ่งครั้งต่อสไลด์หรือว่าลำดับการเรียกกลับคงที่

### **ส่งออกเป็นหน่วยความจำและตรวจสอบอาร์ติแฟกต์**

ตัวอย่างสมบัตินี้โหลด `input.pptx` รวบรวมอาร์ติแฟกต์ทั้งหมดในแผนที่ JavaScript จากชื่อไปยังบัฟเฟอร์ และพิมพ์ชื่อ ประเภท และจำนวนไบต์ของแต่ละรายการ โดยคงชื่อที่ให้มาไว้โดยตรง ชื่อซ้ำจะทำให้การรวบรวมเป็นโมฆะแทนที่จะเขียนทับอาร์ติแฟกต์โดยเงียบ ตัวอย่างจะตรวจสอบสิ่งนี้ก่อนใช้ผลลัพธ์

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

        // ถอดรหัสเฉพาะ XAML เท่านั้น และเมื่อจำเป็นต้องตรวจสอบข้อความ
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

การตรวจสอบส่วนขยายมีประโยชน์สำหรับการตรวจสอบ; ควรเก็บอาร์ติแฟกต์ทั้งหมดรวมถึงชนิดทรัพยากรที่ไม่คุ้นเคย อย่าแก้ไขไบต์เมื่อจัดเก็บหรือส่งต่อ ใช้การถอดรหัส UTF-8 เฉพาะกับ XAML ที่ต้องการการประมวลผลข้อความ

### **บรรจุอาร์ติแฟกต์ที่รวบรวมเป็นไฟล์ ZIP**

ตัวอย่างอิสระนี้รวบรวมการส่งออก ตรวจสอบชื่อ แล้วเขียนไบต์ดิบลงในไฟล์ ZIP ด้วยบริดจ์ Java ZIP จะถูกรวบรวมในหน่วยความจำก่อนบันทึกลงดิสก์ ชื่อไฟล์ ZIP ที่ไม่ซ้ำกันจะแยกงานส่งออกที่ทำงานพร้อมกัน ไฟล์ ZIP ใช้เครื่องหมายทับหน้า (`/`) และคงไดเรกทอรีสัมพัทธ์ ชื่อที่ไม่ปลอดภัยหรือชื่อที่ชนกันหลังการทำให้เป็นมาตรฐานจะทำให้แพคเกจทั้งหมดถูกปฏิเสธก่อนเขียน

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
            const bytes = java.newArray("byte", Array.from(data));
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // การปิดทำให้ไดเรกทอรี ZIP เสร็จสมบูรณ์ก่อนที่ไฟล์เก็บจะถูกบันทึก.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

ตัวอย่างใช้ [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) เพื่อเขียนไฟล์ ZIP เฉพาะหนึ่งไฟล์; ตัวส่งออกเองจะไม่เขียนไฟล์ XAML หรือภาพแยกต่างหาก สำหรับการจัดเก็บระยะไกล ให้แทนขั้นตอนการเขียน ZIP ด้วยการอัปโหลดอาร์เรย์ไบต์ที่รวบรวม ใช้รหัสงานส่งออกร่วมกับชื่ออาร์ติแฟกต์สัมพัทธ์เต็มเป็นคีย์ blob หรือเก็บรหัสงาน ชื่อสัมพัทธ์ และข้อมูลไบนารีในแถวฐานข้อมูล เผยแพร่งานเฉพาะหลังจากอัปโหลดทั้งหมดเสร็จหรือการทำธุรกรรมฐานข้อมูลคอมมิทแล้ว ทำความสะอาดผลลัพธ์บางส่วนหากการคงข้อมูลล้มเหลว

สำหรับการนำเสนอขนาดใหญ่ ตัวบันทึกที่กำหนดเองสามารถคงอาร์ติแฟกต์แต่ละรายการโดยตรงไปยังพื้นที่เก็บข้อมูลของแอปพลิเคชันเพื่อหลีกเลี่ยงการเก็บสำเนาเพิ่มเติมของการส่งออกทั้งหมดในหน่วยความจำของแอป ควรรักษาการเรียกกลับแต่ละครั้งให้สอดคล้องจากมุมมองของตัวส่งออก: คืนค่าเฉพาะหลังปลายทางรับไบต์แล้ว และให้ความล้มเหลวส่งต่อไปยังผู้เรียก

### **คงชื่อทรัพยากรและตรวจสอบการอ้างอิง**

- ทำให้ตัวคั่นเส้นทางเป็นมาตรฐานเมื่อต้องการในปลายทาง แต่ให้คงไดเรกทอรีสัมพัทธ์ อย่าใช้เพียงชื่อไฟล์ฐาน เว้นแต่ทุกชื่อที่สร้างขึ้นจะเป็นเอกลักษณ์และการอ้างอิงทรัพยากรยังคงถูกต้อง
- ใช้การตรวจสอบชื่อเฉพาะปลายทาง เมื่อเขียนไฟล์แยก ควรปฏิเสธเส้นทางที่เริ่มจากรากและส่วนที่ชี้ไปยังไดเรกทอรีอื่น ๆ ตรวจสอบให้ปลายทางแปลงเป็นเส้นทางเต็มและยืนยันว่าคงอยู่ภายใต้ไดเรกทอรีส่งออกที่กำหนดรวมถึงตัวคั่นไดเรกทอรีในขั้นตอนตรวจสอบความเป็นอยู่ ใช้ไดเรกทอรีที่ควบคุมโดยแอปพลิเคชันโดยไม่มีลิงก์สัญลักษณ์ที่จะเปลี่ยนเส้นทางการเขียน
- ใช้ตัวบันทึกและเนมสเปซการจัดเก็บแยกกันสำหรับแต่ละงานส่งออก ตรวจจับการชนกันหลังจากทำให้ตัวคั่นเป็นมาตรฐานและตามกฎการตรวจสอบความแตกต่างตัวพิมพ์ของปลายทาง
- ก่อนเผยแพร่ ให้พาร์สแต่ละเอกสาร XAML เป็น XML และตรวจสอบการอ้างอิงทรัพยากรที่อิงไฟล์ เช่น แอตทริบิวต์ `Source` หรือ `ImageSource` ของภาพ แก้ไข URI สัมพัทธ์แต่ละรายการเทียบกับไดเรกทอรีของอาร์ติแฟกต์ XAML ที่บรรจุ ปรับให้เป็นชื่อการจัดเก็บที่ทำให้เป็นมาตรฐานและยืนยันว่าคีย์ในแผนที่, รายการ ZIP หรืออ็อบเจ็กต์ที่เก็บอยู่มีอยู่จริง แยกการอ้างอิง URI ภายนอกและนิพจน์มาร์กอัป XAML ออกจากชื่อไฟล์สัมพัทธ์

เช่น หาก `input/Slide_1.xaml` อ้างอิง `images/image1.png` ทรัพยากรที่เก็บต้องพร้อมใช้งานเป็น `input/images/image1.png` การเก็บเพียง `image1.png` จะทำให้ความสัมพันธ์เสียหาย สำหรับการจัดเก็บแบบอ็อบเจ็กต์ ให้คงโครงสร้างเดียวกันภายใต้คำนำหน้างานและทำให้ URL ของทรัพยากรเหล่านั้นเข้าถึงได้สำหรับผู้บริโภค XAML เปิด ZIP ที่เสร็จสมบูรณ์เพื่อตรวจสอบชื่อตัวเข้าและไบต์ของทรัพยากร แล้วโหลดสไลด์ตัวอย่างในสภาพแวดล้อม XAML เป้าหมายเพื่อยืนยันว่าภาพถูกแก้ไขอย่างถูกต้อง

## **คำถามที่พบบ่อย**

**ฉันจะทำให้ฟอนต์เป็นไปอย่างคาดการณ์ได้เมื่อฟอนต์ต้นฉบับไม่มีบนเครื่องอย่างไร?**

เรียก [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) ใน [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — จะใช้เป็นฟอนต์สำรองระหว่างการส่งออกเมื่อฟอนต์ต้นฉบับหายไป อย่างไรก็ตาม สิ่งนี้ไม่รับประกันว่า XAML ที่สร้างจะอ้างอิงฟอนต์สำรองหรือว่าฟอนต์นั้นมีบนเครื่องเป้าหมาย ตรวจสอบให้ฟอนต์ที่ XAML อ้างอิงพร้อมใช้งานในสภาพแวดล้อมที่แสดงผล

**XAML ที่ส่งออกออกแบบมาเฉพาะสำหรับ WPF เท่านั้นหรือสามารถใช้ในสแต็ก XAML อื่นได้เช่นกัน?**

Aspose.Slides ส่งออก XAML ของ WPF ผ่าน API สาธารณะ ความเข้ากันได้กับสแต็ก XAML อื่น ๆ เช่น UWP และ Xamarin.Forms ไม่ได้รับการรับประกัน ควรทดสอบมาร์กอัปที่สร้างในสภาพแวดล้อมเป้าหมายของคุณ

**สไลด์ที่ซ่อนอยู่ได้รับการสนับสนุนหรือไม่ และฉันจะป้องกันไม่ให้ส่งออกโดยค่าเริ่มต้นได้อย่างไร?**

โดยค่าเริ่มต้น สไลด์ที่ซ่อนอยู่จะไม่ถูกรวม คุณสามารถควบคุมพฤติกรรมนี้ได้ผ่าน [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) ใน [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — อย่าเปิดใช้งานหากไม่ต้องการส่งออกสไลด์ที่ซ่อนอยู่