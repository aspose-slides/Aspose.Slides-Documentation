---
title: แปลงงานนำเสนอ PowerPoint เป็น Markdown ใน JavaScript
linktitle: PowerPoint เป็น Markdown
type: docs
weight: 140
url: /th/nodejs-java/convert-powerpoint-to-markdown/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น MD
- งานนำเสนอเป็น MD
- สไลด์เป็น MD
- PPT เป็น MD
- PPTX เป็น MD
- บันทึก PowerPoint เป็น Markdown
- บันทึกงานนำเสนอเป็น Markdown
- บันทึกสไลด์เป็น Markdown
- บันทึก PPT เป็น MD
- บันทึก PPTX เป็น MD
- ส่งออก PPT เป็น MD
- ส่งออก PPTX เป็น MD
- การส่งออกรูปภาพ Markdown
- ลิงก์รูปภาพ CDN
- PowerPoint
- งานนำเสนอ
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลงงานนำเสนอ PPT และ PPTX เป็น Markdown ใน JavaScript และควบคุมตำแหน่งที่บันทึกและอ้างอิงรูปภาพ bitmap, metafile และ SVG ที่ส่งออก"
---
## **ภาพรวม**

Aspose.Slides for Node.js ผ่าน Java สามารถแปลงงานนำเสนอ PPT และ PPTX เป็น Markdown เพื่อใช้ในเอกสาร เว็บไซต์สแตติก การย้ายเนื้อหา และกระบวนการควบคุมเวอร์ชัน คุณสามารถเลือกชนิดของ Markdown ควบคุมวิธีการแสดงเนื้อหาสไลด์ และกำหนดตำแหน่งที่จัดเก็บรูปภาพที่ส่งออกและวิธีที่ Markdown ที่สร้างขึ้นอ้างอิงถึงรูปเหล่านั้น

โดยค่าเริ่มต้น การส่งออก Markdown จะใช้ผลลัพธ์แบบข้อความเท่านั้น เพื่อส่งออกเนื้อหาภาพ ให้ตั้งค่าชนิดการส่งออกโดยใช้เมธอด [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/markdownsaveoptions/) เป็นค่า `Sequential` หรือ `Visual` จาก enumeration [MarkdownExportType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/markdownexporttype/) `Sequential` จะเรนเดอร์รายการสไลด์แยกกันและตามลำดับ ในขณะที่ `Visual` จะเก็บรายการที่จัดกลุ่มไว้ด้วยกันเพื่อรักษาความสัมพันธ์เชิงภาพ ค่า `TextOnly` จะไม่สร้างทรัพยากรรูปภาพ ดังนั้นคอลแบ๊กการบันทึกรูปภาพจะไม่ถูกเรียกใช้ในโหมดนี้

## **แปลงงานนำเสนอเป็น Markdown**

โหลดไฟล์ต้นฉบับด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) แล้วเรียกเมธอด [Presentation.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) ด้วยค่า `Md` จาก enumeration [SaveFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/saveformat/) 

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", aspose.slides.SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **เลือกชนิด Markdown**

เมธอด [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/markdownsaveoptions/) ควบคุมสเปคของ Markdown ที่ใช้สำหรับผลลัพธ์ enumeration [Flavor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/flavor/) มีค่า CommonMark, GitHub Flavored Markdown และรูปแบบที่รองรับอื่นๆ  

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น CommonMark:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setFlavor(aspose.slides.Flavor.CommonMark);

    presentation.save("presentation.md", aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **ส่งออกรูปภาพโดยใช้พฤติกรรมการบันทึกแบบโลคัลเริ่มต้น**

คลาส [MarkdownSaveOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/markdownsaveoptions/) มีเมธอดสองตัวสำหรับกำหนดค่าการบันทึกรูปภาพในเครื่อง:

- [setBasePath](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/markdownsaveoptions/) ระบุไดเรกทอรีฐานสำหรับเอกสาร Markdown และทรัพยากรของมัน  
- [setImagesSaveFolderName](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/markdownsaveoptions/) ระบุโฟลเดอร์ย่อยสำหรับรูปภาพ ค่าปริยายคือ `Images`

ตัวอย่างต่อไปนี้เรนเดอร์เนื้อหาภาพ เขียนรูปภาพไปยัง `output/assets` และสร้างลิงก์รูปแบบสัมพันธ์ในเอกสาร Markdown:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("assets");

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

พฤติกรรมนี้ยังทำหน้าที่เป็น fallback เมื่อแฮนด์เลอร์การบันทึกรูปภาพที่กำหนดเองคืนค่า `false`

## **ปรับแต่งการบันทึกรูปภาพและลิงก์ Markdown**

ใช้เมธอด [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/markdownsaveoptions/) เพื่อลงทะเบียนคอลแบ๊กสำหรับทรัพยากร bitmap และ metafile ที่ไม่ใช่ SVG ที่ถูกส่งออกระหว่างการส่งออก Markdown คอลแบ๊ก `MarkdownImageSavingHandler` จะรับอ็อบเจกต์ [IImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/) ค่า [ImageFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imageformat/) และลิงก์ Markdown ที่สร้างขึ้นเป็นอาร์เรย์สตริงที่มีหนึ่งสมาชิก ให้บันทึกหรืออัปโหลดรูปภาพด้วยฟอร์แมตที่ระบุ แล้วแทนที่ `link[0]` ด้วยการอ้างอิงที่ต้องการให้ปรากฏในผลลัพธ์ Markdown  

ทรัพยากรที่ส่งออกเป็น SVG จะถูกจัดการแยกต่างหาก ลงทะเบียนคอลแบ๊กด้วยเมธอด [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/markdownsaveoptions/) คอลแบ๊ก `MarkdownSvgImageSavingHandler` จะรับอ็อบเจกต์ `ISvgImage` และอาร์เรย์ `link` ที่มีหนึ่งสมาชิก SVG ไม่มีอาร์กิวเมนต์ `ImageFormat` ให้เขียนหรืออัปโหลดข้อมูล XML ของมันจากเมธอด `ISvgImage.getSvgData` แทน ขึ้นอยู่กับโหมดการส่งออกและการจัดกลุ่มเชิงภาพ SVG ในงานนำเสนออาจถูกแปลงเป็น raster หรือรวมกับเนื้อหาอื่นๆ; ทรัพยากรที่ไม่ใช่ SVG ที่ได้จะถูกส่งต่อให้คอลแบ๊กการบันทึกรูปภาพลงทะเบียนทั้งสองเมื่อทรัพยากรเชิงภาพทุกตัวต้องการการประมวลผลแบบกำหนดเอง  

ใน Node.js ให้สร้างการนำไปใช้ของอินเทอร์เฟซคอลแบ๊กเหล่านี้ด้วย `java.newProxy`  

ค่าที่คอลแบ๊กคืนจะกำหนดว่าใครเป็นผู้ประมวลผลรูปภาพ:

- คืนค่า `true` หลังจากคอลแบ๊กบันทึก อัปโหลด แปลงรูปภาพ หรือทำการประมวลผลอื่นใดและกำหนดค่าที่ถูกต้องให้กับ `link[0]` Aspose.Slides จะเขียนค่านั้นลงในเอกสาร Markdown และไม่ทำการบันทึกแบบโลคัลเริ่มต้น  
- คืนค่า `false` เพื่อให้ Aspose.Slides บันทึกรูปภาพลงในเครื่องและสร้างลิงก์ตามค่าที่ตั้งด้วย [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/markdownsaveoptions/) และ [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/markdownsaveoptions/)

{{% alert color="warning" title="Important" %}}
แฮนด์เลอร์ที่คืนค่า `true` จะรับผิดชอบรูปภาพ หากคืนค่า `true` โดยไม่ได้กำหนดลิงก์ที่ถูกต้องและไม่ว่างเปล่า การส่งออกจะล้มเหลวด้วย `InvalidOperationException`
{{% /alert %}}

### **บันทึกรูปภาพไปยังไดเรกทอรีต้นทาง CDN และใช้ URL ภายนอก**

ตัวอย่างต่อไปนี้ถือว่า `cdn-origin/presentations/quarterly-report` เป็นไดเรกทอรีต้นทาง CDN ที่เมานท์หรือซิงโครไนซ์แต่ละแฮนด์เลอร์จะดึงชื่อไฟล์ที่สร้างขึ้น บันทึกรูปภาพไปยังไดเรกทอรีที่กำหนดเองนั้น และแทนที่การอ้างอิงโลคัลที่สร้างขึ้นด้วย URL CDN สาธารณะ ตัวอย่างไม่มีการอัปโหลดผ่านเครือข่าย: URL จะใช้ได้ก็ต่อเมื่อไดเรกทอรีถูกเมานท์เป็นต้นทาง CDN หรือไฟล์ถูกเผยแพร่สู่ CDN สำหรับการจัดเก็บวัตถุ ให้แทนที่การเขียนไฟล์ระบบด้วยการอัปโหลดของ SDK ที่ใช้เก็บ แล้วกำหนด `link[0]` หลังจากอัปโหลดสำเร็จ

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
const publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
const storageDirectory = path.join("cdn-origin", "presentations", "quarterly-report");
fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(storageDirectory, { recursive: true });

const getFileNameFromLink = generatedLink => {
    const urlCompatibleLink = String(generatedLink).replace(/\\/g, "/");
    return path.posix.basename(urlCompatibleLink);
};
const buildPublicUrl = fileName => publicBaseUrl + "/" + encodeURIComponent(fileName);

const imageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", {
    invoke: function(image, format, link) {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        image.save(storagePath, format);
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

const svgImageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", {
    invoke: function(svgImage, link) {
        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        fs.writeFileSync(storagePath, svgImage.getSvgData());
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("fallback-images");
    options.setImageSaving(imageSavingHandler);
    options.setSvgImageSaving(svgImageSavingHandler);

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

แฮนด์เลอร์ bitmap ให้คืนค่า `false` อย่างเจตนาสำหรับรูปภาพที่มีขนาดเล็กกว่า 128 × 128 พิกเซล ดังนั้น Aspose.Slides จะบันทึกรูปภาพเหล่านั้นไปยัง `output/fallback-images` ด้วยพฤติกรรมเริ่มต้น รูปภาพ bitmap และ metafile ขนาดใหญ่ รวมถึงทรัพยากร SVG จะถูกจัดการโดยโค้ดกำหนดเอง ตัวอย่างเช่น การอ้างอิงโลคัลที่สร้างขึ้นเช่น `fallback-images/image1.png` จะกลายเป็น `https://cdn.example.com/presentations/quarterly-report/image1.png` แฮนด์เลอร์ใช้เส้นทางของระบบปฏิบัติการเฉพาะเมื่อเขียนไฟล์; ลิงก์ที่เขียนเข้าสู่ Markdown ใช้เครื่องหมายทับหน้า (`/`) และชื่อไฟล์ที่เข้ารหัส URL ให้ใช้กฎเดียวกันเมื่อสร้างลิงก์สัมพันธ์: ใช้ `/` ไม่ใช่ตัวแบ่งไดเรกทอรีของแพลตฟอร์ม

## **คำถามที่พบบ่อย**

**แฮนด์เลอร์หนึ่งสามารถประมวลผลทั้งภาพ raster และ SVG ได้หรือไม่?**  
ไม่ใช่ ใช้ [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/markdownsaveoptions/) สำหรับทรัพยากร bitmap และ metafile ที่ส่งออก และใช้ [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/markdownsaveoptions/) สำหรับทรัพยากรที่ส่งออกเป็น SVG ตัวแรกให้ได้อ็อบเจกต์ [IImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/) และค่า [ImageFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imageformat/) ตัวที่สองให้ได้อ็อบเจกต์ `ISvgImage` ซึ่งข้อมูล SVG สามารถอ่านได้ด้วย `ISvgImage.getSvgData` SVG ที่ถูก rasterize ระหว่างการส่งออกจะถูกประมวลผลโดยคอลแบ๊กการบันทึกรูปภาพแทน

**จะเกิดอะไรขึ้นเมื่อแฮนด์เลอร์การบันทึกรูปภาพคืนค่า `false`?**  
Aspose.Slides จะใช้พฤติกรรมการบันทึกแบบโลคัลเริ่มต้น ตำแหน่งรูปภาพและการอ้างอิงที่สร้างขึ้นถูกควบคุมโดยค่าที่ตั้งด้วย [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/markdownsaveoptions/) และ [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/markdownsaveoptions/)

**แฮนด์เลอร์สามารถให้ URL โดยไม่บันทึกรูปภาพลงในเครื่องได้หรือไม่?**  
ทำได้ แฮนด์เลอร์สามารถอัปโหลดรูปภาพไปยังแหล่งเก็บวัตถุหรือส่งต่อให้บริการอื่น แล้วกำหนด URL ที่ได้ให้กับ `link[0]` และคืนค่า `true` โดยแฮนด์เลอร์ต้องรับผิดชอบการประมวลผลทั้งหมด การคืนค่า `true` จะยับยั้งการบันทึกแบบโลคัลเริ่มต้น

**ทำไมการส่งออก Markdown จึงโยน `InvalidOperationException` จากแฮนด์เลอร์?**  
ข้อยกเว้นนี้เกิดเมื่อแฮนด์เลอร์คืนค่า `true` แต่ไม่ได้ให้ลิงก์ที่ถูกต้อง ให้กำหนดเส้นทางสัมพันธ์หรือ URL ภายนอกที่ควรเขียนลงใน Markdown ก่อนคืนค่า `true`

**ลิงก์รูปภาพควรใช้ตัวคั่นเส้นทางแบบใด?**  
ใช้เครื่องหมายทับหน้า (`/`) ในลิงก์ Markdown และ URL ใช้ `path.join` เฉพาะสำหรับเส้นทางระบบไฟล์ แล้วสร้างหรือทำให้มาตรฐานลิงก์ Markdown แยกต่างหาก

**ลิงก์ไฮเปอร์ลิงก์ถูกคงไว้ระหว่างการส่งออก Markdown หรือไม่?**  
ใช่ ข้อความที่เป็น [hyperlinks](/slides/th/nodejs-java/manage-hyperlinks/) จะคงเป็นลิงก์ Markdown มาตรฐาน แต่ [transitions](/slides/th/nodejs-java/slide-transition/) และ [animations](/slides/th/nodejs-java/powerpoint-animation/) ของสไลด์จะไม่ถูกแปลง

**สามารถแปลงงานนำเสนอเป็น Markdown แบบขนานได้หรือไม่?**  
สามารถประมวลผลไฟล์งานนำเสนอหลายไฟล์พร้อมกันได้ แต่ห้ามแชร์ออบเจกต์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) ระหว่างเธรด ปฏิบัติตาม [multithreading guidelines](/slides/th/nodejs-java/multithreading/) และสร้างอินสแตนซ์แยกสำหรับแต่ละไฟล์