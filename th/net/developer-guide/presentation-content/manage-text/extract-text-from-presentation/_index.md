---
title: "การสกัดข้อความขั้นสูงจากงานนำเสนอใน .NET"
linktitle: "สกัดข้อความ"
type: docs
weight: 90
url: /th/net/extract-text-from-presentation/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/overview/
  - /net/slides-on-cloud-platforms/extracting-text/slides/th/
keywords:
- "สกัดข้อความ"
- "สกัดข้อความจากสไลด์"
- "สกัดข้อความจากงานนำเสนอ"
- "สกัดข้อความจาก PowerPoint"
- "สกัดข้อความจาก OpenDocument"
- "สกัดข้อความจาก PPT"
- "สกัดข้อความจาก PPTX"
- "สกัดข้อความจาก ODP"
- "ดึงข้อความ"
- "ดึงข้อความจากสไลด์"
- "ดึงข้อความจากงานนำเสนอ"
- "ดึงข้อความจาก PowerPoint"
- "ดึงข้อความจาก OpenDocument"
- "ดึงข้อความจาก PPT"
- "ดึงข้อความจาก PPTX"
- "ดึงข้อความจาก ODP"
- "PowerPoint"
- "OpenDocument"
- "งานนำเสนอ"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "สกัดข้อความจากงานนำเสนอ PowerPoint และ OpenDocument อย่างรวดเร็วด้วย Aspose.Slides สำหรับ .NET ปฏิบัติตามคู่มือขั้นตอนง่ายของเราเพื่อประหยัดเวลา."
---
## **ภาพรวม**

การสกัดข้อความจากงานนำเสนอเป็นงานที่พบบ่อยแต่ก็สำคัญสำหรับนักพัฒนาที่ทำงานกับเนื้อหาสไลด์ ไม่ว่าคุณจะทำงานกับไฟล์ Microsoft PowerPoint ในรูปแบบ PPT หรือ PPTX หรือการนำเสนอ OpenDocument (ODP) การเข้าถึงและดึงข้อมูลข้อความสามารถเป็นสิ่งสำคัญสำหรับการวิเคราะห์, การทำอัตโนมัติ, การทำดัชนี, หรือการย้ายเนื้อหา

บทความนี้ให้คำแนะนำแบบครอบคลุมเกี่ยวกับวิธีการสกัดข้อความจากรูปแบบการนำเสนอที่หลากหลายอย่างมีประสิทธิภาพ รวมถึง PPT, PPTX, และ ODP โดยใช้ Aspose.Slides for .NET คุณจะได้เรียนรู้วิธีการวนผ่านองค์ประกอบของงานนำเสนออย่างเป็นระบบเพื่อดึงข้อมูลข้อความที่คุณต้องการอย่างแม่นยำ

## **สกัดข้อความจากสไลด์**

Aspose.Slides for .NET มีเนมสเปส [Aspose.Slides.Util](https://reference.aspose.com/slides/th/net/aspose.slides.util/) ซึ่งรวมคลาส [SlideUtil](https://reference.aspose.com/slides/th/net/aspose.slides.util/slideutil/) คลาสนี้เปิดเผยเมธอดสแตติกที่มีการโอเวอร์โหลดหลายรูปแบบสำหรับการสกัดข้อความทั้งหมดจากงานนำเสนอหรือสไลด์ เพื่อสกัดข้อความจากสไลด์ในงานนำเสนอ ให้ใช้เมธอด [GetAllTextBoxes](https://reference.aspose.com/slides/th/net/aspose.slides.util/slideutil/getalltextboxes/) เมธอดนี้รับออบเจ็กต์ประเภท [IBaseSlide](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseslide/) เป็นพารามิเตอร์ เมื่อทำงาน เมธอดจะสแกนสไลด์ทั้งหมดเพื่อค้นหาข้อความและคืนค่าอาเรย์ของออบเจ็กต์ประเภท [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) โดยคงรูปแบบข้อความไว้

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

เพื่อสแกนข้อความจากงานนำเสนอทั้งหมด ให้ใช้เมธอดสแตติก [GetAllTextFrames](https://reference.aspose.com/slides/th/net/aspose.slides.util/slideutil/getalltextframes/) ที่เปิดเผยโดยคลาส [SlideUtil](https://reference.aspose.com/slides/th/net/aspose.slides.util/slideutil/) เมธอดนี้รับพารามิเตอร์สองค่า:

1. ค่แรกคือออบเจ็กต์ [IPresentation](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/) ที่แสดงถึงงานนำเสนอ PowerPoint หรือ OpenDocument ที่จะสกัดข้อความออกจากมัน
1. ค่าที่สองคือค่า `Boolean` ที่ระบุว่าควรรวมสไลด์มาสเตอร์ในการสแกนข้อความจากงานนำเสนอหรือไม่

เมธอดจะคืนค่าอาเรย์ของออบเจ็กต์ประเภท [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) พร้อมข้อมูลการจัดรูปแบบข้อความ โค้ดด้านล่างสแกนข้อความและรายละเอียดการจัดรูปแบบจากงานนำเสนอ รวมถึงสไลด์มาสเตอร์

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

## **การสกัดข้อความแบบจัดประเภทและรวดเร็ว**

คลาส [PresentationFactory](https://reference.aspose.com/slides/th/net/aspose.slides/presentationfactory/) ยังมีเมธอดสำหรับสกัดข้อความทั้งหมดจากงานนำเสนอ:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

อาร์กิวเมนต์ enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/th/net/aspose.slides/textextractionarrangingmode/) ระบุโหมดการจัดเรียงผลลัพธ์การสกัดข้อความและสามารถตั้งค่าเป็นค่าเหล่านี้ได้:
- `Unarranged` - ข้อความดิบโดยไม่คำนึงถึงตำแหน่งบนสไลด์
- `Arranged` - ข้อความถูกจัดเรียงตามลำดับเดียวกับบนสไลด์

โหมด Unarranged สามารถใช้เมื่อความเร็วเป็นสิ่งสำคัญ; มันเร็วกว่าโหมด Arranged

[IPresentationText](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentationtext/) แสดงถึงข้อความดิบที่สกัดจากงานนำเสนอ คุณสมบัติ `SlidesText` ของมันจะคืนค่าอาเรย์ของออบเจ็กต์ประเภท [ISlideText](https://reference.aspose.com/slides/th/net/aspose.slides/islidetext/) แต่ละออบเจ็กต์แทนข้อความบนสไลด์ที่สอดคล้องกัน ออบเจ็กต์ประเภท [ISlideText](https://reference.aspose.com/slides/th/net/aspose.slides/islidetext/) มีคุณสมบัติดังต่อไปนี้:

- `Text` - ข้อความภายในรูปร่างของสไลด์
- `MasterText` - ข้อความภายในรูปร่างของสไลด์มาสเตอร์ที่เกี่ยวข้องกับสไลด์นี้
- `LayoutText` - ข้อความภายในรูปร่างของสไลด์เลเอาท์ที่เกี่ยวข้องกับสไลด์นี้
- `NotesText` - ข้อความภายในรูปร่างของสไลด์โน้ตที่เกี่ยวข้องกับสไลด์นี้
- `CommentsText` - ข้อความภายในความคิดเห็นที่เกี่ยวข้องกับสไลด์นี้

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

**Aspose.Slides ประมวลผลงานนำเสนอขนาดใหญ่ในระหว่างการสกัดข้อความเร็วแค่ไหน?**

Aspose.Slides ถูกออกแบบให้มีประสิทธิภาพสูงและสามารถประมวลผลแม้กระทั่ง [งานนำเสนอขนาดใหญ่](/slides/th/net/open-presentation/) ทำให้เหมาะสำหรับสถานการณ์การประมวลผลแบบเรียลไทม์หรือแบบชุดจำนวนมาก

**Aspose.Slides สามารถสกัดข้อความจากตารางและแผนภูมิในงานนำเสนอได้หรือไม่?**

ใช่ Aspose.Slides สามารถสกัดข้อความจากหลายองค์ประกอบของสไลด์ รวมถึงตารางและวัตถุที่เกี่ยวกับแผนภูมิ ดังนั้นคุณจึงสามารถเข้าถึงและวิเคราะห์เนื้อหาข้อความในโครงสร้างการนำเสนอทั่วไป

**ฉันต้องการไลเซนส์พิเศษของ Aspose.Slides เพื่อสกัดข้อความจากงานนำเสนอหรือไม่?**

คุณสามารถสกัดข้อความโดยใช้เวอร์ชันทดลองฟรีของ Aspose.Slides แต่จะมี [ข้อจำกัดบางอย่าง](/slides/th/net/licensing/) เช่น การประมวลผลจำนวนสไลด์ที่จำกัด สำหรับการใช้งานไม่จำกัดและการจัดการงานนำเสนอขนาดใหญ่ การซื้อไลเซนส์เต็มรุ่นเป็นที่แนะนำ