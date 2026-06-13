---
title: แปลงงานนำเสนอ PowerPoint เป็น Markdown ด้วย JavaScript
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
- PowerPoint
- งานนำเสนอ
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint ด้วย JavaScript—PPT, PPTX—เป็น Markdown ที่สะอาดด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java, ทำให้การสร้างเอกสารอัตโนมัติและรักษาการจัดรูปแบบ."
---
## **บทนำ**

Aspose.Slides ช่วยให้คุณแปลงงานนำเสนอ PowerPoint เป็น Markdown ซึ่งเป็นประโยชน์สำหรับกระบวนการทำเอกสาร การสร้างเว็บไซต์แบบสถิตย์ การย้ายเนื้อหา และการเผยแพร่ข้อความที่ควบคุมเวอร์ชัน API รองรับการส่งออกโดยตรงจากงานนำเสนอ PPT และ PPTX ไปเป็นไฟล์ MD และให้ตัวเลือกเพิ่มเติมเพื่อควบคุมว่าข้อมูลสไลด์จะแสดงในเอกสาร Markdown ที่ได้อย่างไร

คุณสามารถส่งออกงานนำเสนอเป็น Markdown ธรรมดา เลือกจากหลายรูปแบบของ Markdown เช่น CommonMark และ GitHub Flavored Markdown และกำหนดวิธีการจัดการรูปภาพระหว่างการส่งออก สำหรับงานนำเสนอที่มีเนื้อหาภาพ Aspose.Slides ยังให้คุณบันทึกรูปภาพไปยังโฟลเดอร์แยกต่างหากและอ้างอิงจากไฟล์ Markdown ที่สร้างขึ้น

{{% alert color="warning" %}} 

การส่งออก PowerPoint ไปเป็น markdown จะ **ไม่มีรูปภาพ** เป็นค่าเริ่มต้น หากคุณต้องการส่งออกเอกสาร PowerPoint ที่มีรูปภาพ คุณต้องเรียก `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` และตั้งค่า `BasePath` ที่จะบันทึกรูปภาพที่อ้างอิงในเอกสาร markdown

{{% /alert %}} 

## **แปลง PowerPoint เป็น Markdown**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) เพื่อเป็นวัตถุงานนำเสนอ
2. ใช้เมธอด [save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#save-aspose.slides.IXamlOptions-) เพื่อบันทึกวัตถุเป็นไฟล์ markdown

โค้ด JavaScript นี้แสดงวิธีแปลง PowerPoint เป็น markdown:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.md", aspose.slides.SaveFormat.Md);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **แปลง PowerPoint เป็นรูปแบบ Markdown**

Aspose.Slides ช่วยให้คุณแปลง PowerPoint เป็น markdown (ที่มีไวยากรณ์พื้นฐาน) , CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab และอีก 17 รูปแบบ markdown อื่น ๆ

โค้ด JavaScript นี้แสดงวิธีแปลง PowerPoint เป็น CommonMark:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.CommonMark);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

รูปแบบ markdown ที่รองรับ 23 แบบถูก [listed under the Flavor enumeration](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/flavor/) จากคลาส [MarkdownSaveOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/markdownsaveoptions/)

## **แปลงงานนำเสนอที่มีรูปภาพเป็น Markdown**

คลาส [MarkdownSaveOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/markdownsaveoptions/) ให้คุณสมบัติและ enumeration ที่ช่วยให้คุณใช้ตัวเลือกหรือการตั้งค่าต่าง ๆ สำหรับไฟล์ markdown ที่ได้ ตัวอย่างเช่น enum [MarkdownExportType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/markdownexporttype/) สามารถกำหนดค่าเป็น `Sequential`, `TextOnly`, `Visual` เพื่อกำหนดวิธีการแสดงหรือจัดการรูปภาพ

### **แปลงรูปภาพแบบต่อเนื่อง**

หากคุณต้องการให้รูปภาพปรากฏเป็นรายการเดี่ยวต่อเนื่องกันใน markdown ที่ได้ คุณต้องเลือกตัวเลือก sequential โค้ด JavaScript นี้แสดงวิธีแปลงงานนำเสนอที่มีรูปภาพเป็น markdown:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.Github);
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(aspose.slides.NewLineType.Windows);
    pres.save("doc.md", java.newArray("int", [1, 2, 3, 4, 5, 6, 7, 8, 9]), aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **แปลงรูปภาพแบบแสดงภาพ**

หากคุณต้องการให้รูปภาพปรากฏร่วมกันใน markdown ที่ได้ คุณต้องเลือกตัวเลือก visual ในกรณีนี้ รูปภาพจะถูกบันทึกไปยังไดเรกทอรีปัจจุบันของแอปพลิเคชัน (และจะสร้างเส้นทาง relative สำหรับพวกมันในเอกสาร markdown) หรือคุณสามารถระบุเส้นทางและชื่อโฟลเดอร์ที่ต้องการ

โค้ด JavaScript นี้แสดงการทำงาน:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    final var outPath = "c:/documents";
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**ลิงก์ไฮเปอร์ลิงก์จะคงอยู่หลังการส่งออกเป็น Markdown หรือไม่?**

ใช่ ข้อความ [hyperlinks](/slides/th/nodejs-java/manage-hyperlinks/) จะถูกเก็บเป็นลิงก์ Markdown มาตรฐาน สไลด์ [transitions](/slides/th/nodejs-java/slide-transition/) และ [animations](/slides/th/nodejs-java/powerpoint-animation/) ไม่ถูกแปลง

**ฉันสามารถเร่งความเร็วการแปลงโดยรันในหลายเธรดได้หรือไม่?**

คุณสามารถทำงานแบบขนานตามไฟล์ได้ แต่ [don’t share](/slides/th/nodejs-java/multithreading/) อินสแตนซ์เดียวของ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) ระหว่างเธรด ควรใช้อินสแตนซ์หรือกระบวนการแยกตามไฟล์เพื่อหลีกเลี่ยงการแย่งใช้ทรัพยากร

**เกิดอะไรขึ้นกับรูปภาพ—พวกมันบันทึกที่ไหน และเส้นทางเป็น relative หรือไม่?**

[Images](/slides/th/nodejs-java/image/) จะถูกส่งออกไปยังโฟลเดอร์เฉพาะ และไฟล์ Markdown จะอ้างอิงพวกมันด้วยเส้นทาง relative เป็นค่าเริ่มต้น คุณสามารถกำหนดค่าฐานเส้นทางออกและชื่อโฟลเดอร์สินทรัพย์เพื่อรักษาโครงสร้างรีพอสิตอรีที่คาดเดาได้