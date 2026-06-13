---
title: นำเข้าการนำเสนอจาก PDF หรือ HTML ใน C++
linktitle: นำเข้าการนำเสนอ
type: docs
weight: 60
url: /th/cpp/import-presentation/
keywords:
- นำเข้าการนำเสนอ
- นำเข้าสไลด์
- นำเข้า PDF
- นำเข้า HTML
- PDF เป็นการนำเสนอ
- PDF เป็น PPT
- PDF เป็น PPTX
- PDF เป็น ODP
- HTML เป็นการนำเสนอ
- HTML เป็น PPT
- HTML เป็น PPTX
- HTML เป็น ODP
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "นำเข้าเอกสาร PDF และ HTML ไปยังการนำเสนอ PowerPoint และ OpenDocument อย่างง่ายดายใน C++ ด้วย Aspose.Slides สำหรับการประมวลผลสไลด์ที่ราบรื่นและมีประสิทธิภาพสูง."
---
## **บทนำ**

โดยใช้ [**Aspose.Slides for C++**](https://products.aspose.com/slides/th/cpp/), คุณสามารถนำเข้าการนำเสนอจากไฟล์ในรูปแบบอื่นได้ Aspose.Slides มีคลาส [SlideCollection](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.slide_collection) เพื่อให้คุณสามารถนำเข้าการนำเสนอจาก PDF, เอกสาร HTML ฯลฯ.

## **นำเข้า PowerPoint จาก PDF**

ในกรณีนี้ คุณจะทำการแปลงไฟล์ PDF เป็นงานนำเสนอ PowerPoint

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. สร้างออบเจ็กต์ของคลาส Presentation.  
2. เรียกใช้เมธอด [AddFromPdf()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) และส่งไฟล์ PDF.  
3. ใช้เมธอด [Save()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) เพื่อบันทึกไฟล์ในรูปแบบ PowerPoint.

```cpp
auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert  title="Tip" color="primary" %}} 
คุณอาจต้องการลองใช้แอปเว็บ **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/th/import/pdf-to-powerpoint) เพราะเป็นการนำกระบวนการที่อธิบายไว้ที่นี่ไปใช้จริง. 
{{% /alert %}} 

## **นำเข้า PowerPoint จาก HTML**

ในกรณีนี้ คุณจะทำการแปลงเอกสาร HTML เป็นงานนำเสนอ PowerPoint.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation/) .  
2. เรียกใช้เมธอด [AddFromHtml()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) และส่งไฟล์ HTML.  
3. ใช้เมธอด [Save()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) เพื่อบันทึกไฟล์ในรูปแบบ PowerPoint.

```c++
auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
คุณยังสามารถใช้ Aspose.Slides เพื่อแปลง HTML ไปยังรูปแบบไฟล์ที่นิยมอื่น ๆ: 

* [HTML ไปเป็นภาพ](https://products.aspose.com/slides/th/cpp/conversion/html-to-image/)
* [HTML เป็น JPG](https://products.aspose.com/slides/th/cpp/conversion/html-to-jpg/)
* [HTML เป็น XML](https://products.aspose.com/slides/th/cpp/conversion/html-to-xml/)
* [HTML เป็น TIFF](https://products.aspose.com/slides/th/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **FAQ**

**ตารางถูกเก็บไว้เมื่อทำการนำเข้า PDF หรือไม่ และการตรวจจับตารางสามารถปรับปรุงได้หรือไม่?**

สามารถตรวจจับตารางได้ระหว่างการนำเข้า; [PdfImportOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.import/pdfimportoptions/) มีเมธอด [set_DetectTables](https://reference.aspose.com/slides/th/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/) ที่เปิดใช้งานการจดจำตาราง ความแม่นยำขึ้นอยู่กับโครงสร้างของ PDF.