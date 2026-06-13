---
title: การสกัดข้อความขั้นสูงจากงานนำเสนอใน .NET
linktitle: สกัดข้อความ
type: docs
weight: 90
url: /th/net/extract-text-from-presentation/
keywords:
- สกัดข้อความ
- สกัดข้อความจากสไลด์
- สกัดข้อความจากงานนำเสนอ
- สกัดข้อความจาก PowerPoint
- สกัดข้อความจาก OpenDocument
- สกัดข้อความจาก PPT
- สกัดข้อความจาก PPTX
- สกัดข้อความจาก ODP
- ดึงข้อความ
- ดึงข้อความจากสไลด์
- ดึงข้อความจากงานนำเสนอ
- ดึงข้อความจาก PowerPoint
- ดึงข้อความจาก OpenDocument
- ดึงข้อความจาก PPT
- ดึงข้อความจาก PPTX
- ดึงข้อความจาก ODP
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สกัดข้อความจากงานนำเสนอ PowerPoint และ OpenDocument อย่างรวดเร็วด้วย Aspose.Slides สำหรับ .NET. ให้ทำตามคู่มือแบบขั้นตอนง่าย ๆ ของเราเพื่อประหยัดเวลา."
---
## **ภาพรวม**

การสกัดข้อความจากงานนำเสนอเป็นงานที่พบบ่อยแต่จำเป็นสำหรับนักพัฒนาที่ทำงานกับเนื้อหาในสไลด์ ไม่ว่าจะเป็นไฟล์ Microsoft PowerPoint ในรูปแบบ PPT หรือ PPTX หรือการนำเสนอ OpenDocument (ODP) การเข้าถึงและดึงข้อมูลข้อความสามารถมีความสำคัญต่อการวิเคราะห์ การทำอัตโนมัติ การจัดทำดัชนี หรือการย้ายเนื้อหา

บทความนี้ให้คำแนะนำอย่างครบถ้วนเกี่ยวกับวิธีการสกัดข้อความอย่างมีประสิทธิภาพจากรูปแบบงานนำเสนอหลายประเภท รวมถึง PPT, PPTX และ ODP โดยใช้ Aspose.Slides สำหรับ .NET คุณจะได้เรียนรู้วิธีการวนซ้ำผ่านองค์ประกอบของงานนำเสนออย่างเป็นระบบเพื่อดึงข้อมูลข้อความที่คุณต้องการได้อย่างแม่นยำ

## **สกัดข้อความจากสไลด์**

Aspose.Slides for .NET มีเนมสเปซ [Aspose.Slides.Util](https://reference.aspose.com/slides/th/net/aspose.slides.util/) ซึ่งรวมคลาส [SlideUtil](https://reference.aspose.com/slides/th/net/aspose.slides.util/slideutil/) คลาสนี้เปิดให้ใช้เมธอดสถิติดิจิทัลหลายเวอร์ชันสำหรับการสกัดข้อความทั้งหมดจากงานนำเสนอหรือสไลด์ เพื่อสกัดข้อความจากสไลด์ในงานนำเสนอ ให้ใช้เมธอด [GetAllTextBoxes](https://reference.aspose.com/slides/th/net/aspose.slides.util/slideutil/getalltextboxes/) เมธอดนี้รับอ็อบเจ็กต์ชนิด [IBaseSlide](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseslide/) เป็นพารามิเตอร์ เมื่อทำงาน เมธอดจะสแกนสไลด์ทั้งหมดเพื่อค้นหาข้อความและคืนค่าอาร์เรย์ของอ็อบเจ็กต์ชนิด [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) โดยรักษาการจัดรูปแบบข้อความไว้

โค้ดตัวอย่างต่อไปนี้สกัดข้อความทั้งหมดจากสไลด์แรกของงานนำเสนอ:

```cs
int slideIndex = 0;

using var presentation = new Presentation("demo.pptx");

var slide = presentation.Slides[slideIndex];

var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **สกัดข้อความจากงานนำเสนอ**

เพื่อสแกนข้อความจากงานนำเสนอทั้งหมด ให้ใช้เมธอดสถิต [GetAllTextFrames](https://reference.aspose.com/slides/th/net/aspose.slides.util/slideutil/getalltextframes/) ที่เปิดโดยคลาส [SlideUtil](https://reference.aspose.com/slides/th/net/aspose.slides.util/slideutil/) เมธอดนี้รับพารามิเตอร์สองค่า:

1. อย่างแรก เป็นอ็อบเจ็กต์ [IPresentation](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/) ที่แทนงานนำเสนอ PowerPoint หรือ OpenDocument ที่ต้องสกัดข้อความออก
1. อย่างสอง เป็นค่า `Boolean` ที่ระบุว่าควรรวมสไลด์มาสเตอร์ในการสแกนข้อความจากงานนำเสนอหรือไม่

เมธอดจะคืนค่าอาร์เรย์ของอ็อบเจ็กต์ชนิด [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) พร้อมข้อมูลการจัดรูปแบบข้อความ โค้ดด้านล่างสแกนข้อความและรายละเอียดการจัดรูปแบบจากงานนำเสนอ รวมถึงสไลด์มาสเตอร์

```cs
using var presentation = new Presentation("demo.pptx");

var includeMasterSlides = true;
var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, includeMasterSlides);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **การสกัดข้อความแบบจัดหมวดหมู่และเร็ว**

คลาส [PresentationFactory](https://reference.aspose.com/slides/th/net/aspose.slides/presentationfactory/) ยังมีเมธอดสำหรับสกัดข้อความทั้งหมดจากงานนำเสนอ:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

อาร์กิวเมนต์ enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/th/net/aspose.slides/textextractionarrangingmode/) ระบุโหมดการจัดระเบียบผลการสกัดข้อความและสามารถตั้งค่าเป็นค่าต่อไปนี้:
- `Unarranged` - ข้อความดิบโดยไม่พิจารณาตำแหน่งบนสไลด์
- `Arranged` - ข้อความจัดเรียงตามลำดับเดียวกับบนสไลด์

โหมด Unarranged สามารถใช้เมื่อความเร็วเป็นสิ่งสำคัญ; มันเร็วกว่าโหมด Arranged

[IPresentationText](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationtext/) แสดงถึงข้อความดิบที่สกัดจากงานนำเสนอ property `SlidesText` จะคืนค่าอาร์เรย์ของอ็อบเจ็กต์ชนิด [ISlideText](https://reference.aspose.com/slides/th/net/aspose.slides/islidetext/) แต่ละอ็อบเจ็กต์แทนข้อความบนสไลด์ที่สอดคล้องกัน อ็อบเจ็กต์ชนิด [ISlideText](https://reference.aspose.com/slides/th/net/aspose.slides/islidetext/) มีคุณสมบัติดังต่อไปนี้:

- `Text` - ข้อความภายในรูปร่างของสไลด์
- `MasterText` - ข้อความภายในรูปร่างของสไลด์มาสเตอร์ที่เชื่อมโยงกับสไลด์นี้
- `LayoutText` - ข้อความภายในรูปร่างของสไลด์เลเอาต์ที่เชื่อมโยงกับสไลด์นี้
- `NotesText` - ข้อความภายในรูปร่างของสไลด์โน้ตที่เชื่อมโยงกับสไลด์นี้
- `CommentsText` - ข้อความภายในคอมเมนต์ที่เชื่อมโยงกับสไลด์นี้

```cs
var presentationPath = "presentation.ppt";
var arrangingMode = TextExtractionArrangingMode.Unarranged;
var presentationText = PresentationFactory.Instance.GetPresentationText(presentationPath, arrangingMode);
var firstSlideText = presentationText.SlidesText[0];

Console.WriteLine(firstSlideText.Text);
Console.WriteLine(firstSlideText.LayoutText);
Console.WriteLine(firstSlideText.MasterText);
Console.WriteLine(firstSlideText.NotesText);
Console.WriteLine(firstSlideText.CommentsText);
```

## **คำถามที่พบบ่อย**

**Aspose.Slides ประมวลผลงานนำเสนอขนาดใหญ่ในการสกัดข้อความเร็วแค่ไหน?**

Aspose.Slides ถูกทำให้ทำงานได้อย่างเร็วและสามารถประมวลผลแม้ [งานนำเสนอขนาดใหญ่](/slides/th/net/open-presentation/) ทำให้เหมาะสำหรับสถานการณ์การประมวลผลแบบเรียลไทม์หรือแบบกลุ่ม

**Aspose.Slides สามารถสกัดข้อความจากตารางและแผนภูมิภายในงานนำเสนอได้หรือไม่?**

ใช่ Aspose.Slides สามารถสกัดข้อความจากองค์ประกอบหลายอย่างของสไลด์ รวมถึงตารางและวัตถุที่เกี่ยวกับแผนภูมิ ทำให้คุณสามารถเข้าถึงและวิเคราะห์เนื้อหาข้อความในโครงสร้างงานนำเสนอทั่วไปได้

**ฉันต้องการไลเซนส์พิเศษของ Aspose.Slides เพื่อสกัดข้อความจากงานนำเสนอหรือไม่?**

คุณสามารถสกัดข้อความโดยใช้เวอร์ชันทดลองฟรีของ Aspose.Slides แม้ว่าจะมี [ข้อจำกัดบางประการ](/slides/th/net/licensing/) เช่น การประมวลผลได้เพียงจำนวนสไลด์ที่จำกัด สำหรับการใช้งานโดยไม่มีข้อจำกัดและเพื่อจัดการกับงานนำเสนอขนาดใหญ่ การซื้อไลเซนส์เต็มรุ่นเป็นที่แนะนำ.