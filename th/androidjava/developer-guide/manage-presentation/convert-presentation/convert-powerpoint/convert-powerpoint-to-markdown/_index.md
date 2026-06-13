---
title: แปลงงานนำเสนอ PowerPoint เป็น Markdown บน Android
linktitle: PowerPoint ไปยัง Markdown
type: docs
weight: 140
url: /th/androidjava/convert-powerpoint-to-markdown/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint ไปยัง MD
- งานนำเสนอไปยัง MD
- สไลด์ไปยัง MD
- PPT ไปยัง MD
- PPTX ไปยัง MD
- บันทึก PowerPoint เป็น Markdown
- บันทึกงานนำเสนอเป็น Markdown
- บันทึกสไลด์เป็น Markdown
- บันทึก PPT เป็น MD
- บันทึก PPTX เป็น MD
- ส่งออก PPT เป็น MD
- exportPPTX ไปยัง MD
- PowerPoint
- งานนำเสนอ
- Markdown
- Android
- Java
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint—PPT, PPTX—เป็น Markdown ที่สะอาดด้วย Aspose.Slides สำหรับ Android ผ่าน Java, ทำงานเอกสารอัตโนมัติและคงรูปแบบ."
---
## **แนะนำ**

Aspose.Slides ให้คุณแปลงงานนำเสนอ PowerPoint ไปเป็น Markdown ซึ่งเป็นประโยชน์สำหรับกระบวนการทำเอกสาร การสร้างเว็บไซต์แบบสถิต การย้ายเนื้อหา และการเผยแพร่ข้อความที่ควบคุมด้วยระบบเวอร์ชัน API รองรับการส่งออกโดยตรงจากงานนำเสนอ PPT และ PPTX ไปเป็นไฟล์ MD และมีตัวเลือกเพิ่มเติมเพื่อควบคุมวิธีการแสดงเนื้อหาสไลด์ในเอกสาร Markdown ที่ได้

คุณสามารถส่งออกงานนำเสนอเป็น Markdown ธรรมดา เลือกจากหลายรูปแบบ Markdown เช่น CommonMark และ GitHub Flavored Markdown และกำหนดวิธีการจัดการรูปภาพระหว่างการส่งออก สำหรับงานนำเสนอที่มีเนื้อหาเป็นภาพ Aspose.Slides ยังสามารถบันทึกรูปภาพลงในโฟลเดอร์แยกต่างหากและอ้างอิงจากไฟล์ Markdown ที่สร้างขึ้นได้

Aspose.Slides รองรับการแปลงงานนำเสนอเป็น Markdown

{{% alert color="warning" %}} 
การส่งออก PowerPoint ไปเป็น markdown **ไม่มีรูปภาพ** เป็นค่าเริ่มต้น หากคุณต้องการส่งออกเอกสาร PowerPoint ที่มีรูปภาพ คุณต้องตั้งค่า `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` และยังต้องกำหนด `BasePath` ที่จะบันทึกรูปภาพที่อ้างอิงในเอกสาร markdown
{{% /alert %}} 

## **แปลง PowerPoint ไปเป็น Markdown**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) เพื่อเป็นตัวแทนของอ็อบเจกต์งานนำเสนอ
2. ใช้เมธอด [Save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) เพื่อบันทึกอ็อบเจกต์เป็นไฟล์ markdown

โค้ด Java ด้านล่างแสดงวิธีแปลง PowerPoint ไปเป็น markdown:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **แปลง PowerPoint ไปเป็นรูปแบบ Markdown**

Aspose.Slides ให้คุณแปลง PowerPoint ไปเป็น markdown (ที่มีไวยากรณ์พื้นฐาน) CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab และรูปแบบ markdown อื่น ๆ อีก 17 รูปแบบ

โค้ด Java นี้แสดงวิธีแปลง PowerPoint ไปเป็น CommonMark:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(Flavor.CommonMark);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

รูปแบบ markdown ทั้ง 23 ที่รองรับได้ถูก [ระบุไว้ใน enumeration Flavor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/flavor/) จากคลาส [MarkdownSaveOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/markdownsaveoptions/)

## **แปลงงานนำเสนอที่มีรูปภาพไปเป็น Markdown**

คลาส [MarkdownSaveOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/markdownsaveoptions/) มีคุณสมบัติและ enumeration ที่ให้คุณใช้ตัวเลือกหรือการตั้งค่าต่าง ๆ สำหรับไฟล์ markdown ที่ได้ ตัวอย่างเช่น enum [MarkdownExportType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/markdownexporttype/) สามารถตั้งค่าเป็นค่าต่าง ๆ ที่กำหนดวิธีการเรนเดอร์หรือจัดการรูปภาพ: `Sequential`, `TextOnly`, `Visual`

### **แปลงรูปภาพแบบต่อเนื่อง (Sequential)**

หากคุณต้องการให้รูปภาพปรากฏเป็นรายการแต่ละภาพต่อกันใน markdown ที่ได้ คุณต้องเลือกตัวเลือก sequential โค้ด Java นี้แสดงวิธีแปลงงานนำเสนอที่มีรูปภาพไปเป็น markdown:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(Flavor.Github);
    markdownSaveOptions.setExportType(MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(NewLineType.Windows);
    pres.save("doc.md", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **แปลงรูปภาพแบบภาพรวม (Visual)**

หากคุณต้องการให้รูปภาพปรากฏร่วมกันใน markdown ที่ได้ คุณต้องเลือกตัวเลือก visual ในกรณีนี้รูปภาพจะถูกบันทึกลงในไดเรกทอรีปัจจุบันของแอปพลิเคชัน (และเส้นทางสัมพันธ์จะถูกสร้างสำหรับรูปภาพในเอกสาร markdown) หรือคุณสามารถระบุเส้นทางและชื่อโฟลเดอร์ที่ต้องการได้

โค้ด Java นี้แสดงการทำงาน:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    final String outPath = "c:/documents";
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setExportType(MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**ลิงก์จะคงอยู่หลังการส่งออกเป็น Markdown หรือไม่?**

ใช่ ข้อความ [hyperlinks](/slides/th/androidjava/manage-hyperlinks/) จะถูกเก็บไว้เป็นลิงก์ Markdown มาตรฐาน สไลด์ [transitions](/slides/th/androidjava/slide-transition/) และ [animations](/slides/th/androidjava/powerpoint-animation/) จะไม่ถูกแปลง

**ฉันสามารถเร่งความเร็วการแปลงโดยรันหลายเธรดพร้อมกันได้หรือไม่?**

คุณสามารถทำงานขนานตามไฟล์ได้ แต่ **อย่าแชร์** อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) เดียวกันระหว่างเธรด ใช้อินสแตนซ์หรือโปรเซสแยกกันต่อไฟล์เพื่อหลีกเลี่ยงการแย่งทรัพยากร

**รูปภาพจะเกิดอะไรขึ้น—บันทึกไว้ที่ไหนและเส้นทางเป็นแบบสัมพันธ์หรือไม่?**

[Images](/slides/th/androidjava/image/) จะถูกส่งออกไปยังโฟลเดอร์เฉพาะ และไฟล์ Markdown จะอ้างอิงรูปภาพด้วยเส้นทางสัมพันธ์เป็นค่าเริ่มต้น คุณสามารถกำหนดเส้นทางฐานและชื่อโฟลเดอร์สำหรับทรัพยากรเพื่อรักษาโครงสร้างที่คาดเดาได้ในที่เก็บข้อมูล

