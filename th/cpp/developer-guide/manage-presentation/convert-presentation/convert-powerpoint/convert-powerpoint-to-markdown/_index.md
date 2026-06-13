---
title: แปลงงานนำเสนอ PowerPoint เป็น Markdown ใน C++
linktitle: PowerPoint ไปยัง Markdown
type: docs
weight: 140
url: /th/cpp/convert-powerpoint-to-markdown/
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
- C++
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint—PPT, PPTX—to Markdown ที่สะอาดด้วย Aspose.Slides สำหรับ C++ เพื่อทำเอกสารอัตโนมัติและคงรูปแบบการจัดวาง"
---
## **คำนำ**

Aspose.Slides ช่วยให้คุณแปลงงานนำเสนอ PowerPoint ไปเป็น Markdown ซึ่งมีประโยชน์สำหรับกระบวนการทำเอกสาร การสร้างเว็บไซต์แบบสถิตย์ การย้ายเนื้อหา และการเผยแพร่ข้อความที่ควบคุมด้วยเวอร์ชัน API รองรับการส่งออกโดยตรงจากงานนำเสนอ PPT และ PPTX ไปเป็นไฟล์ MD และให้ตัวเลือกเพิ่มเติมเพื่อควบคุมวิธีที่เนื้อหาในสไลด์จะถูกแสดงในเอกสาร Markdown ที่ได้

คุณสามารถส่งออกงานนำเสนอเป็น Markdown ธรรมดา เลือกจากหลายรูปแบบของ Markdown เช่น CommonMark และ GitHub Flavored Markdown และกำหนดวิธีการจัดการรูปภาพระหว่างการส่งออก สำหรับงานนำเสนอที่มีเนื้อหาภาพ Aspose.Slides ยังอนุญาตให้บันทึกรูปภาพลงในโฟลเดอร์แยกต่างหากและอ้างอิงจากไฟล์ Markdown ที่สร้างขึ้น

{{% alert color="warning" %}} 
การส่งออก PowerPoint เป็น markdown **ไม่มีรูปภาพ** โดยค่าเริ่มต้น หากคุณต้องการส่งออกเอกสาร PowerPoint ที่มีรูปภาพ คุณต้องตั้งค่า `SaveOptions::MarkdownExportType::Visual)` และยังต้องกำหนด `BasePath` ที่จะบันทึกรูปภาพที่อ้างอิงในเอกสาร markdown
{{% /alert %}} 

## **แปลง PowerPoint เป็น Markdown**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) เพื่อเป็นตัวแทนของอ็อบเจ็กต์งานนำเสนอ
2. ใช้เมธอด [Save ](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method) เพื่อบันทึกอ็อบเจ็กต์เป็นไฟล์ markdown

This C++ code shows you how to convert PowerPoint to markdown:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```

## **แปลง PowerPoint เป็นรูปแบบ Markdown**

Aspose.Slides ช่วยให้คุณแปลง PowerPoint ไปเป็น markdown (ที่มีไวยากรณ์พื้นฐาน), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab และรูปแบบ markdown อีก 17 รูปแบบ

โค้ด C++ นี้แสดงวิธีการแปลง PowerPoint ไปเป็น CommonMark: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```

รูปแบบ markdown ทั้ง 23 ที่รองรับสามารถดูได้จาก [รายการภายใต้การนับจำนวน Flavor](https://reference.aspose.com/slides/th/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) ของคลาส [MarkdownSaveOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/)

## **แปลงงานนำเสนอที่มีรูปภาพเป็น Markdown**

คลาส [MarkdownSaveOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) ให้คุณสมบัติและการนับจำนวนที่ทำให้คุณสามารถใช้ตัวเลือกหรือการตั้งค่าบางอย่างสำหรับไฟล์ markdown ที่สร้างขึ้น ตัวอย่างเช่น enum [MarkdownExportType](https://reference.aspose.com/slides/th/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) สามารถตั้งค่าเป็นค่าเพื่อกำหนดวิธีที่รูปภาพจะถูกแสดงหรือจัดการ: `Sequential`, `TextOnly`, `Visual`.

### **แปลงรูปภาพแบบต่อเนื่อง**

หากคุณต้องการให้รูปภาพปรากฏเป็นรายการแยกกันต่อเนื่องกันใน markdown ที่ได้ คุณต้องเลือกตัวเลือก sequential โค้ด C++ นี้แสดงวิธีการแปลงงานนำเสนอที่มีรูปภาพเป็น markdown:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<MarkdownSaveOptions> markdownSaveOptions = System::MakeObject<MarkdownSaveOptions>();

markdownSaveOptions->set_ShowHiddenSlides(true);
markdownSaveOptions->set_ShowSlideNumber(true);
markdownSaveOptions->set_Flavor(Flavor::Github);
markdownSaveOptions->set_ExportType(MarkdownExportType::Sequential);
markdownSaveOptions->set_NewLineType(NewLineType::Windows);

pres->Save(u"doc.md", System::MakeArray<int32_t>({1, 2, 3, 4, 5, 6, 7, 8, 9}), SaveFormat::Md, markdownSaveOptions);
```

### **แปลงรูปภาพแบบภาพ**

หากคุณต้องการให้รูปภาพปรากฏพร้อมกันใน markdown ที่ได้ คุณต้องเลือกตัวเลือก visual ในกรณีนี้ รูปภาพจะถูกบันทึกลงในไดเรกทอรีปัจจุบันของแอปพลิเคชัน (และเส้นทางแบบ relative จะถูกสร้างสำหรับไฟล์เหล่านั้นในเอกสาร markdown) หรือคุณสามารถระบุเส้นทางและชื่อโฟลเดอร์ที่ต้องการได้

This C++ code demonstrates the operation: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
const System::String outPath = u"x:\\documents";
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_ExportType(Aspose::Slides::DOM::Export::Markdown::SaveOptions::MarkdownExportType::Visual);
opt->set_ImagesSaveFolderName(u"md-images");
opt->set_BasePath(outPath);
pres->Save(System::IO::Path::Combine(outPath, u"pres.md"), Aspose::Slides::Export::SaveFormat::Md, opt);
```

## **คำถามที่พบบ่อย**

**ลิงก์ไฮเปอร์ลิงก์ยังคงอยู่หลังการส่งออกเป็น Markdown หรือไม่?**

ใช่. ข้อความ [hyperlinks](/slides/th/cpp/manage-hyperlinks/) จะถูกเก็บเป็นลิงก์ Markdown มาตรฐาน ส่วนสไลด์ [transitions](/slides/th/cpp/slide-transition/) และ [animations](/slides/th/cpp/powerpoint-animation/) จะไม่ถูกแปลง

**สามารถเร่งความเร็วการแปลงโดยการรันหลายเธรดได้หรือไม่?**

คุณสามารถทำงานแบบขนานระหว่างไฟล์ได้ แต่ไม่ควร [don’t share](/slides/th/cpp/multithreading/) อินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) เดียวกันระหว่างเธรด ใช้อินสแตนซ์หรือโปรเซสแยกสำหรับแต่ละไฟล์เพื่อหลีกเลี่ยงการแย่งกันใช้ทรัพยากร

**รูปภาพจะเกิดอะไรขึ้น—บันทึกไว้ที่ไหนและเส้นทางเป็นแบบ relative หรือไม่?**

[Images](/slides/th/cpp/image/) จะถูกส่งออกไปยังโฟลเดอร์เฉพาะ และไฟล์ Markdown จะอ้างอิงพวกมันด้วยเส้นทางแบบ relative โดยค่าเริ่มต้น คุณสามารถกำหนดเส้นทางออกฐานและชื่อโฟลเดอร์ทรัพยากรเพื่อคงโครงสร้างที่คาดเดาได้ของที่เก็บรหัส