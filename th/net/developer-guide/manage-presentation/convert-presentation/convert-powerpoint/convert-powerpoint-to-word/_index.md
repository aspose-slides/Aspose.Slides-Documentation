---
title: แปลงงานนำเสนอ PowerPoint เป็นเอกสาร Word ใน .NET
linktitle: PowerPoint เป็น Word
type: docs
weight: 110
url: /th/net/convert-powerpoint-to-word/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint ไปยัง Word
- งานนำเสนอไปยัง Word
- สไลด์ไปยัง Word
- PPT ไปยัง Word
- PPTX ไปยัง Word
- PowerPoint ไปยัง DOCX
- งานนำเสนอไปยัง DOCX
- สไลด์ไปยัง DOCX
- PPT ไปยัง DOCX
- PPTX ไปยัง DOCX
- PowerPoint ไปยัง DOC
- งานนำเสนอไปยัง DOC
- สไลด์ไปยัง DOC
- PPT ไปยัง DOC
- PPTX ไปยัง DOC
- บันทึก PPT เป็น DOCX
- บันทึก PPTX เป็น DOCX
- ส่งออก PPT เป็น DOCX
- ส่งออก PPTX เป็น DOCX
- .NET
- C#
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint PPT และ PPTX เป็นเอกสาร Word ที่แก้ไขได้ใน C# ด้วย Aspose.Slides for .NET พร้อมรักษาเค้าโครง รูปภาพ และการจัดรูปแบบอย่างแม่นยำ."
---
## **ภาพรวม**

บทความนี้ให้วิธีแก้ไขสำหรับนักพัฒนาในการแปลงงานนำเสนอ PowerPoint และ OpenDocument เป็นเอกสาร Word โดยใช้ Aspose.Slides for .NET และ Aspose.Words for .NET ขั้นตอนโดยละเอียดจะพาคุณผ่านแต่ละขั้นตอนของกระบวนการแปลง

## **แปลงงานนำเสนอเป็นเอกสาร Word**

ทำตามขั้นตอนด้านล่างเพื่อแปลงงานนำเสนอ PowerPoint หรือ OpenDocument เป็นเอกสาร Word:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)และโหลดไฟล์งานนำเสนอ
2. สร้างอินสแตนซ์ของคลาส [Document](https://reference.aspose.com/words/net/aspose.words/document/)และ[DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/)เพื่อสร้างเอกสาร Word
3. ตั้งค่าขนาดหน้าเอกสาร Word ให้ตรงกับงานนำเสนอโดยใช้คุณสมบัติ [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/)
4. ตั้งค่าขอบกระดาษในเอกสาร Word โดยใช้คุณสมบัติ [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/)
5. วนลูปผ่านสไลด์ทั้งหมดของงานนำเสนอโดยใช้คุณสมบัติ [Presentation.Slides](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/slides/th/)
   - สร้างภาพสไลด์โดยใช้เมธอด `GetImage` จากอินเทอร์เฟซ [ISlide](https://reference.aspose.com/slides/th/net/aspose.slides/islide/) แล้วบันทึกลงใน MemoryStream
   - ใส่ภาพสไลด์ลงในเอกสาร Word โดยใช้เมธอด `InsertImage` จากคลาส [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/)
6. บันทึกเอกสาร Word ลงไฟล์

สมมติว่าเรามีงานนำเสนอ "sample.pptx" ที่มีลักษณะดังนี้:

![งานนำเสนอ PowerPoint](PowerPoint.png)

```cs
using Aspose.Slides;
using Aspose.Words;

// โหลดไฟล์งานนำเสนอ.
using var presentation = new Presentation("sample.pptx");

// สร้างอ็อบเจ็กต์ Document และ DocumentBuilder.
var document = new Document();
var builder = new DocumentBuilder(document);

// ตั้งค่าขนาดหน้าของเอกสาร Word.
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// ตั้งค่าขอบกระดาษในเอกสาร Word.
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// วนผ่านสไลด์ทั้งหมดของงานนำเสนอ.
foreach (var slide in presentation.Slides)
{
    // สร้างภาพสไลด์และบันทึกลงใน MemoryStream.
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // เพิ่มภาพสไลด์ลงในเอกสาร Word.
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// บันทึกเอกสาร Word ลงไฟล์.
document.Save("output.docx");
```

ผลลัพธ์:

![เอกสาร Word](Word.png)

{{% alert color="info" %}} 
ลองใช้ [**Online PPT to Word Converter**](https://products.aspose.app/slides/th/conversion/ppt-to-word) เพื่อดูประโยชน์ที่คุณจะได้รับจากการแปลงงานนำเสนอ PowerPoint และ OpenDocument เป็นเอกสาร Word 
{{% /alert %}}

## **คำถามที่พบบ่อย**

### ต้องติดตั้งส่วนประกอบใดบ้างเพื่อแปลงงานนำเสนอ PowerPoint และ OpenDocument เป็นเอกสาร Word?

คุณเพียงแค่ต้องเพิ่มแพ็กเกจ NuGet ของ [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)และ[Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/)ลงในโครงการ C# ของคุณ ทั้งสองไลบรารีทำงานเป็น API แบบสแตนด์อโลนและไม่จำเป็นต้องติดตั้ง Microsoft Office

### รองรับรูปแบบไฟล์งานนำเสนอ PowerPoint และ OpenDocument ทั้งหมดหรือไม่?

Aspose.Slides for .NET [รองรับรูปแบบไฟล์งานนำเสนอทั้งหมด](/slides/th/net/supported-file-formats/)รวมถึง PPT, PPTX, ODP และประเภทไฟล์ทั่วไปอื่น ๆ ซึ่งทำให้คุณสามารถทำงานกับงานนำเสนอที่สร้างด้วยเวอร์ชันต่าง ๆ ของ Microsoft PowerPoint ได้