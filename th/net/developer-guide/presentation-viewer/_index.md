---
title: สร้างตัวชมพรีเซนเทชันใน .NET
linktitle: ตัวชมพรีเซนเทชัน
type: docs
weight: 50
url: /th/net/presentation-viewer/
keywords:
- ดูพรีเซนเทชัน
- ตัวชมพรีเซนเทชัน
- สร้างตัวชมพรีเซนเทชัน
- ดูไฟล์ PPT
- ดูไฟล์ PPTX
- ดูไฟล์ ODP
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- .NET
- C#
- Aspose.Slides
description: "สร้างตัวชมพรีเซนเทชันแบบกำหนดเองใน .NET ด้วย Aspose.Slides แสดงไฟล์ PowerPoint และ OpenDocument ได้อย่างง่ายดายโดยไม่ต้องใช้ Microsoft PowerPoint."
---
## **บทนำ**

Aspose.Slides for .NET ใช้ในการสร้างไฟล์พรีเซนเทชันที่มีสไลด์ สไลด์เหล่านี้สามารถดูได้โดยการเปิดพรีเซนเทชันใน Microsoft PowerPoint เป็นต้น อย่างไรก็ตาม นักพัฒนาบางครั้งอาจต้องการดูสไลด์เป็นภาพในโปรแกรมดูรูปภาพที่ชอบหรือใช้ในตัวชมพรีเซนเทชันแบบกำหนดเอง ในกรณีเช่นนั้น Aspose.Slides อนุญาตให้คุณส่งออกสไลด์แต่ละรายการเป็นภาพ บทความนี้อธิบายวิธีทำ.

## **สร้างภาพ SVG จากสไลด์**

เพื่อสร้างภาพ SVG จากสไลด์พรีเซนเทชันโดยใช้ Aspose.Slides ให้ทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation).
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน.
1. เปิดสตรีมไฟล์.
1. บันทึกสไลด์เป็นภาพ SVG ไปยังสตรีมไฟล์.

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream);
    }
}
```

## **สร้าง SVG พร้อม ID รูปร่างที่กำหนดเอง**

Aspose.Slides สามารถใช้เพื่อสร้าง [SVG](https://docs.fileformat.com/page-description-language/svg/) จากสไลด์ที่มีรูปทรงที่กำหนด ID เองได้ การทำเช่นนี้ใช้คุณสมบัติ Id จากอินเทอร์เฟซ [ISvgShape](https://reference.aspose.com/slides/th/net/aspose.slides.export/isvgshape) คลาส `CustomSvgShapeFormattingController` สามารถใช้เพื่อกำหนด ID ของรูปทรง.

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];
    
    SVGOptions svgOptions = new SVGOptions
    {
        ShapeFormattingController = new CustomSvgShapeFormattingController()
    };

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream, svgOptions);
    }
}
```

```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
    }
}
```

## **สร้างภาพย่อของสไลด์**

Aspose.Slides ช่วยคุณสร้างภาพย่อของสไลด์ เพื่อสร้างภาพย่อของสไลด์โดยใช้ Aspose.Slides ให้ทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation).
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน.
1. สร้างภาพย่อของสไลด์ที่อ้างอิงด้วยสเกลที่ต้องการ.
1. บันทึกภาพย่อในรูปแบบภาพที่คุณต้องการ.

```c#
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(scaleX, scaleY))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **สร้างภาพย่อของสไลด์ด้วยมิติที่กำหนดโดยผู้ใช้**

เพื่อสร้างภาพย่อของสไลด์ด้วยมิติที่กำหนดโดยผู้ใช้ ให้ทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation).
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน.
1. สร้างภาพย่อของสไลด์ที่อ้างอิงด้วยมิตาที่ระบุ.
1. บันทึกภาพย่อในรูปแบบภาพที่คุณต้องการ.

```c#
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(slideSize))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **สร้างภาพย่อของสไลด์พร้อมบันทึกโน๊ตของผู้พูด**

เพื่อสร้างภาพย่อของสไลด์พร้อมบันทึกโน๊ตของผู้พูดโดยใช้ Aspose.Slides ให้ทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [RenderingOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/renderingoptions/).
1. ใช้คุณสมบัติ `RenderingOptions.SlidesLayoutOptions` เพื่อกำหนดตำแหน่งของบันทึกโน๊ตของผู้พูด.
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation).
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน.
1. สร้างภาพย่อของสไลด์ที่อ้างอิงโดยใช้ตัวเลือกการเรนเดอร์.
1. บันทึกภาพย่อในรูปแบบภาพที่คุณต้องการ.

```c#
int slideIndex = 0;

RenderingOptions renderingOptions = new RenderingOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomTruncated
    }
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(renderingOptions))
    {
        image.Save("output.png", ImageFormat.Png);
    }
}
```

## **ตัวอย่างสด**

ลองใช้แอปฟรี [**Aspose.Slides Viewer**](https://products.aspose.app/slides/th/viewer/) เพื่อดูว่าคุณสามารถทำอะไรด้วย Aspose.Slides API:

[![ตัวชม PowerPoint ออนไลน์](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/th/viewer/)

## **คำถามที่พบบ่อย**

**ฉันสามารถฝังตัวชมการนำเสนอในเว็บแอปพลิเคชัน ASP.NET ได้หรือไม่?**

ใช่ คุณสามารถใช้ Aspose.Slides ฝั่งเซิร์ฟเวอร์เพื่อเรนเดอร์สไลด์เป็นภาพหรือ HTML และแสดงผลในเบราว์เซอร์ คุณสมบัติการนำทางและการซูมสามารถทำได้ด้วย JavaScript เพื่อสร้างประสบการณ์แบบโต้ตอบ.

**วิธีที่ดีที่สุดในการแสดงสไลด์ภายในตัวชม .NET แบบกำหนดเองคืออะไร?**

วิธีที่แนะนำคือเรนเดอร์สไลด์แต่ละหน้เป็นภาพ (เช่น PNG หรือ SVG) หรือแปลงเป็น HTML ด้วย Aspose.Slides แล้วแสดงผลลัพธ์ใน picture box (สำหรับเดสก์ท็อป) หรือในคอนเทนเนอร์ HTML (สำหรับเว็บ).

**ฉันจะจัดการกับพรีเซนเทชันขนาดใหญ่ที่มีสไลด์จำนวนมากอย่างไร?**

สำหรับเด็คขนาดใหญ่ ควรพิจารณาการโหลดแบบ lazy หรือการเรนเดอร์ตามความต้องการของสไลด์หมายถึงการสร้างเนื้อหาของสไลด์เฉพาะเมื่อผู้ใช้เข้าถึงสไลด์นั้น ซึ่งช่วยลดการใช้หน่วยความจำและเวลาโหลด.