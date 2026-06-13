---
title: แปลงงานนำเสนอ PowerPoint เป็น Markdown ใน Java
linktitle: PowerPoint เป็น Markdown
type: docs
weight: 140
url: /th/java/convert-powerpoint-to-markdown/
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
- Java
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint—PPT, PPTX—เป็น Markdown ที่สะอาดด้วย Aspose.Slides สำหรับ Java, ทำให้การจัดทำเอกสารอัตโนมัติและรักษาการจัดรูปแบบ"
---
## **บทนำ**

Aspose.Slides ช่วยให้คุณแปลงงานนำเสนอ PowerPoint เป็น Markdown ซึ่งสามารถเป็นประโยชน์สำหรับกระบวนการทำเอกสาร การสร้างเว็บไซต์แบบสแตติก การย้ายเนื้อหา และการเผยแพร่ข้อความที่ควบคุมด้วยเวอร์ชัน API สนับสนุนการส่งออกโดยตรงจากงานนำเสนอ PPT และ PPTX เป็นไฟล์ MD และให้ตัวเลือกเพิ่มเติมเพื่อควบคุมวิธีการแสดงเนื้อหาในสไลด์ในเอกสาร Markdown ที่ได้

คุณสามารถส่งออกงานนำเสนอเป็น Markdown ธรรมดา เลือกจากหลายรูปแบบของ Markdown เช่น CommonMark และ GitHub Flavored Markdown และกำหนดค่าการจัดการรูปภาพระหว่างการส่งออก สำหรับงานนำเสนอที่มีเนื้อหาภาพ Aspose.Slides ยังอนุญาตให้บันทึกรูปภาพไปยังโฟลเดอร์แยกต่างหากและอ้างอิงจากไฟล์ Markdown ที่สร้างขึ้น

{{% alert color="warning" %}}

การส่งออก PowerPoint เป็น markdown **ไม่มีรูปภาพ** เป็นค่าเริ่มต้น หากคุณต้องการส่งออกเอกสาร PowerPoint ที่มีรูปภาพ คุณต้องใช้ `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` และยังต้องใช้ `setBasePath` เพื่อกำหนดตำแหน่งที่รูปภาพที่อ้างอิงในเอกสาร markdown จะถูกบันทึก

{{% /alert %}}

## **แปลง PowerPoint เป็น Markdown**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) เพื่อเป็นตัวแทนของอ็อบเจ็กต์งานนำเสนอ
2. ใช้เมธอด [Save ](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) เพื่อบันทึกอ็อบเจ็กต์เป็นไฟล์ markdown

โค้ด Java นี้แสดงวิธีการแปลง PowerPoint เป็น markdown:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **แปลง PowerPoint เป็นรูปแบบ Markdown**

Aspose.Slides ช่วยให้คุณแปลง PowerPoint เป็น markdown (รวมไวยากรณ์พื้นฐาน), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab และรูปแบบ markdown อื่น ๆ อีก 17 แบบ

โค้ด Java นี้แสดงวิธีการแปลง PowerPoint เป็น CommonMark:

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

รูปแบบ markdown ทั้ง 23 ที่รองรับได้รับการ [แสดงในรายการ Flavor enumeration](https://reference.aspose.com/slides/th/java/com.aspose.slides/flavor/) จากคลาส [MarkdownSaveOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/markdownsaveoptions/)

## **แปลงงานนำเสนอที่มีรูปภาพเป็น Markdown**

คลาส [MarkdownSaveOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/markdownsaveoptions/) ให้คุณสมบัติและการนับเป็นที่ทำให้คุณสามารถใช้ตัวเลือกหรือการตั้งค่าต่าง ๆ สำหรับไฟล์ markdown ที่ได้ enum [MarkdownExportType](https://reference.aspose.com/slides/th/java/com.aspose.slides/markdownexporttype/) สามารถตั้งค่าเป็นค่าเพื่อกำหนดวิธีการแสดงหรือจัดการรูปภาพ: `Sequential`, `TextOnly`, `Visual`

### **แปลงรูปภาพต่อเนื่อง**

หากคุณต้องการให้รูปภาพปรากฏเป็นแต่ละภาพต่อกันใน markdown ที่ได้ คุณต้องเลือกตัวเลือก sequential โค้ด Java นี้แสดงวิธีการแปลงงานนำเสนอที่มีรูปภาพเป็น markdown:

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

### **แปลงรูปภาพแบบ Visual**

หากคุณต้องการให้รูปภาพปรากฏพร้อมกันใน markdown ที่ได้ คุณต้องเลือกตัวเลือก visual ในกรณีนี้ รูปภาพจะถูกบันทึกไปยังไดเรกทอรีปัจจุบันของแอปพลิเคชัน (และเส้นทางสัมพันธ์จะถูกสร้างสำหรับรูปภาพในเอกสาร markdown) หรือคุณสามารถระบุเส้นทางและชื่อโฟลเดอร์ที่ต้องการได้

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

## **คำถามที่พบบ่อย**

**ลิงก์ไฮเปอร์เท็กซ์จะคงอยู่หลังการส่งออกเป็น Markdown หรือไม่?**

ใช่. ข้อความ [ลิงก์](/slides/th/java/manage-hyperlinks/) จะถูกรักษาเป็นลิงก์ Markdown มาตรฐาน สไลด์ [การเปลี่ยนสไลด์](/slides/th/java/slide-transition/) และ [แอนิเมชัน](/slides/th/java/powerpoint-animation/) จะไม่ถูกแปลง

**ฉันสามารถเร่งความเร็วการแปลงโดยรันในหลายเธรดได้หรือไม่?**

คุณสามารถทำงานแบบขนานตามไฟล์ได้ แต่ต้อง [อย่าแชร์](/slides/th/java/multithreading/) อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) เดียวกันข้ามเธรด ใช้อินสแตนซ์หรือกระบวนการแยกตามไฟล์เพื่อหลีกเลี่ยงการแย่งกันใช้ทรัพยากร

**เกิดอะไรขึ้นกับรูปภาพ—พวกมันถูกบันทึกที่ไหน และเส้นทางเป็นแบบสัมพันธ์หรือไม่?**

[รูปภาพ](/slides/th/java/image/) จะถูกส่งออกไปยังโฟลเดอร์เฉพาะ และไฟล์ Markdown จะอ้างอิงพวกมันด้วยเส้นทางสัมพันธ์โดยค่าเริ่มต้น คุณสามารถกำหนดค่าเส้นทางผลลัพธ์พื้นฐานและชื่อโฟลเดอร์ทรัพยากรเพื่อรักษาโครงสร้างที่คาดเดาได้ของรีโพซิทอรี