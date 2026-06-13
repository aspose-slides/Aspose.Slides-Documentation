---
title: แปลงงานนำเสนอ PowerPoint เป็น Markdown ใน PHP
linktitle: PowerPoint เป็น Markdown
type: docs
weight: 140
url: /th/php-java/convert-powerpoint-to-markdown/
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
- PHP
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint — PPT, PPTX — ให้เป็น Markdown ที่สะอาดด้วย Aspose.Slides สำหรับ PHP ผ่าน Java, ทำเอกสารอัตโนมัติและคงรูปแบบ."
---
## **บทนำ**

Aspose.Slides ช่วยให้คุณแปลงงานนำเสนอ PowerPoint เป็น Markdown ซึ่งเป็นประโยชน์สำหรับกระบวนการทำเอกสาร, การสร้างเว็บไซต์แบบสแตติก, การย้ายเนื้อหา, และการเผยแพร่ข้อความที่ควบคุมเวอร์ชัน API รองรับการส่งออกโดยตรงจากงานนำเสนอ PPT และ PPTX เป็นไฟล์ MD และให้ตัวเลือกเพิ่มเติมเพื่อควบคุมว่าข้อมูลสไลด์จะแสดงในเอกสาร Markdown อย่างไร

คุณสามารถส่งออกงานนำเสนอเป็น Markdown ธรรมดา, เลือกจากหลายรูปแบบ Markdown เช่น CommonMark และ GitHub Flavored Markdown, และกำหนดวิธีการจัดการรูปภาพระหว่างการส่งออก สำหรับงานนำเสนอที่มีเนื้อหาภาพ, Aspose.Slides ยังอนุญาตให้คุณบันทึกรูปภาพลงในโฟลเดอร์แยกต่างหากและอ้างอิงจากไฟล์ Markdown ที่สร้างขึ้น

{{% alert color="warning" %}}
การส่งออก PowerPoint‑to‑Markdown **โดยไม่มีรูปภาพ** เป็นค่าเริ่มต้น หากคุณต้องการส่งออกเอกสาร PowerPoint ที่มีรูปภาพคุณต้องตั้งค่า `ExportType = MarkdownExportType::Visual` และระบุ `BasePath` ซึ่งเป็นตำแหน่งที่รูปภาพที่อ้างอิงในเอกสาร Markdown จะถูกบันทึก
{{% /alert %}}

## **แปลงงานนำเสนอเป็น Markdown**

ส่วนนี้อธิบายว่า Aspose.Slides แปลงงานนำเสนอ PowerPoint และ OpenDocument (PPT, PPTX, ODP) ให้เป็น Markdown ที่สะอาด โดยคงลำดับชั้นสไลด์, ข้อความ, และการจัดรูปแบบหลักไว้ เพื่อให้คุณสามารถนำเนื้อหาไปใช้ในเอกสารหรือกระบวนการทำงานที่ควบคุมเวอร์ชันได้โดยไม่ต้องทำขั้นตอนเพิ่มเติม

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) เพื่อเป็นตัวแทนของงานนำเสนอ
1. ใช้วิธีการ [save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#save) เพื่อส่งออกเป็นไฟล์ Markdown

โค้ด PHP นี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น Markdown:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.md", SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **แปลงงานนำเสนอเป็นรูปแบบ Markdown**

Aspose.Slides ให้คุณแปลงงานนำเสนอ PowerPoint เป็น Markdown ด้วยไวยากรณ์พื้นฐาน รวมถึง CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab, และรูปแบบ Markdown อื่น ๆ อีกสิบเจ็ดประเภท

โค้ด PHP ด้านล่างแสดงวิธีแปลงงานนำเสนอ PowerPoint ไปเป็น CommonMark:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setFlavor(Flavor->CommonMark);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

รูปแบบ Markdown ทั้งหมด 23 รูปแบบที่รองรับถูกแสดงใน [Flavor enumeration](https://reference.aspose.com/slides/th/php-java/aspose.slides/flavor/)

## **แปลงงานนำเสนอที่มีภาพเป็น Markdown**

คลาส [MarkdownSaveOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/markdownsaveoptions/) เปิดเผยคุณสมบัติและ enumeration ที่ให้คุณกำหนดไฟล์ Markdown ที่สร้างขึ้น ตัวอย่างเช่น enumeration [MarkdownExportType](https://reference.aspose.com/slides/th/php-java/aspose.slides/markdownexporttype/) ระบุวิธีการจัดการรูปภาพ: `Sequential`, `TextOnly`, หรือ `Visual`

{{% alert color="warning" %}}
โดยค่าเริ่มต้น การส่งออก PowerPoint‑to‑Markdown **จะไม่รวมรูปภาพ** หากต้องการฝังรูปภาพให้เรียก `markdownSaveOptions.setExportType(MarkdownExportType::Visual)` และตั้งค่า `BasePath` เพื่อระบุตำแหน่งที่รูปภาพที่อ้างอิงในไฟล์ Markdown จะถูกบันทึก
{{% /alert %}}

### **แปลงภาพแบบต่อเนื่อง**

หากคุณต้องการให้รูปภาพปรากฏเป็นรายการแยกกัน หนึ่งต่อหนึ่งใน Markdown ที่ได้ คุณต้องเลือกตัวเลือก `Sequential` โค้ด PHP ด้านล่างแสดงวิธีแปลงงานนำเสนอที่มีรูปภาพเป็น Markdown:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setShowHiddenSlides(true);
    $saveOptions->setShowSlideNumber(true);
    $saveOptions->setFlavor(Flavor->Github);
    $saveOptions->setExportType(MarkdownExportType::Sequential);
    $saveOptions->setNewLineType(NewLineType::Windows);

    $slideIndices = array(1, 2, 3, 4);
    $presentation->save("presentation.md", $slideIndices, SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

### **แปลงภาพแบบแสดงภาพ**

หากคุณต้องการให้รูปภาพปรากฏร่วมกันใน Markdown ที่ได้ คุณต้องเลือกตัวเลือก `Visual` ในกรณีนี้รูปภาพจะถูกบันทึกลงในไดเรกทอรีปัจจุบันของแอปพลิเคชัน (และจะสร้างเส้นทางสัมพันธ์สำหรับรูปภาพในเอกสาร Markdown) หรือคุณสามารถระบุไดเรกทอรีและชื่อโฟลเดอร์ที่ต้องการได้

โค้ด PHP ด้านล่างแสดงการทำงานนี้:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $outPath = "c:/documents";

    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setExportType(MarkdownExportType::Visual);
    $saveOptions->setImagesSaveFolderName("md-images");
    $saveOptions->setBasePath($outPath);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

## **คำถามที่พบบ่อย**

**ลิงก์ไฮเปอร์จะยังคงอยู่หลังการส่งออกเป็น Markdown หรือไม่?**

ใช่ ข้อความ [hyperlinks](/slides/th/php-java/manage-hyperlinks/) จะถูกเก็บไว้เป็นลิงก์ Markdown มาตรฐาน สไลด์ [transitions](/slides/th/php-java/slide-transition/) และ [animations](/slides/th/php-java/powerpoint-animation/) จะไม่ถูกแปลง

**ฉันสามารถเร่งความเร็วการแปลงโดยรันหลายเธรดได้หรือไม่?**

คุณสามารถทำงานแบบขนานระหว่างไฟล์ได้ แต่ [don’t share](/slides/th/php-java/multithreading/) อินสแตนซ์เดียวของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ระหว่างเธรด ใช้อินสแตนซ์หรือกระบวนการแยกกันต่อไฟล์เพื่อหลีกเลี่ยงการขัดแย้ง

**รูปภาพจะเกิดอะไรขึ้นบ้าง — ถูกบันทึกที่ไหนและเส้นทางเป็นแบบสัมพันธ์หรือไม่?**

[Images](/slides/th/php-java/image/) จะถูกส่งออกไปยังโฟลเดอร์เฉพาะ และไฟล์ Markdown จะอ้างอิงรูปภาพด้วยเส้นทางสัมพันธ์โดยค่าเริ่มต้น คุณสามารถกำหนดเส้นทางฐานสำหรับผลลัพธ์และชื่อโฟลเดอร์ assets เพื่อรักษาโครงสร้างที่คาดเดาได้ในที่เก็บข้อมูล