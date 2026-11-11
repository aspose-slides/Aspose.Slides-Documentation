---
title: แสดงสไลด์การนำเสนอเป็นภาพ SVG ใน .NET
linktitle: สไลด์เป็น SVG
type: docs
weight: 50
url: /th/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint เป็น SVG
- การนำเสนอเป็น SVG
- สไลด์เป็น SVG
- PPT เป็น SVG
- PPTX เป็น SVG
- ตัวเลือกการส่งออก SVG
- SVG แบบโต้ตอบ
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ส่งออกสไลด์ PowerPoint เป็นภาพ SVG ใน .NET และควบคุมฟอนต์ ข้อความ ภาพ ID และเหตุการณ์ด้วย Aspose.Slides."
---
## **ภาพรวม**

SVG เป็นรูปแบบภาพแบบ XML ที่สามารถขยายขนาดได้ ซึ่งทำงานได้ดีสำหรับการเผยแพร่บนเว็บ ตัวแสดงสไลด์ กระบวนการทำให้เข้าถึงได้ และการประมวลผลหลังการส่งออกอัตโนมัติ Aspose.Slides ส่งออกแต่ละสไลด์เป็นไฟล์ SVG แยกไฟล์และให้คุณควบคุมวิธีการเขียนข้อความ ฟอนต์ รูปภาพ และองค์ประกอบ SVG

ใช้ [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) เมื่อต้องการให้ SVG ที่ส่งออกมีขนาดกระชับ คาดเดาได้ในทุกเบราว์เซอร์ หรือพร้อมสำหรับการใช้งานแบบโต้ตอบ

## **ส่งออกสไลด์เป็น SVG**

สร้าง [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), เลือกสไลด์หนึ่งสไลด์และเขียนออกเป็นสตรีม ตัวอย่างต่อไปนี้ส่งออกทุกสไลด์ในงานนำเสนอเป็นไฟล์ SVG แยกไฟล์

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

ชื่อไฟล์ใช้ [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) แทนการใช้ดัชนีของลูป คุณยังสามารถส่งออกรูปร่างเดี่ยวด้วย [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/) เมื่อผู้แสดงสไลด์หรือหน้าเว็บต้องการเพียงรูปร่างนั้น

## **กำหนดค่าเอาต์พุต SVG**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) ควบคุมการเรนเดอร์ของ SVG สำหรับกรอบข้อความ, [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) จะรวมกรอบข้อความในพื้นที่เรนเดอร์ และ [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) จะกำหนดว่าจะใช้การหมุนกรอบหรือไม่ ตั้งค่า [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) เป็น `true` เมื่อต้องการให้ข้อความแสดงโดยไม่มีลิเกเจอร์

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    DisableFontLigatures = true,
    UseFrameSize = true,
    UseFrameRotation = false
};

using var svgStream = File.Create("slide-with-custom-options.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **ควบคุมข้อความและฟอนต์**

เมื่อส่งออกสไลด์เป็น SVG คุณสามารถควบคุมว่าข้อความจะคงอยู่เป็นข้อความหรือแปลงเป็นกราฟิกเวกเตอร์ได้ และวิธีการรวมหรืออ้างอิงฟอนต์ภายนอก ตัวเลือกต่อไปนี้ช่วยให้คุณสมดุลความสอดคล้องกันของภาพ การเลือกข้อความ และการพึ่งพาฟอนต์ใน SVG ที่ส่งออก

### **แปลงข้อความทั้งหมดเป็นเวกเตอร์**

ตั้งค่า [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) เป็น `true` เพื่อเขียนข้อความทั้งหมดของสไลด์เป็นกราฟิกเวกเตอร์ สิ่งนี้จะขจัดการพึ่งพาฟอนต์และทำให้ผลลัพธ์ภาพสอดคล้องกันมากขึ้นในหลากหลายเบราว์เซอร์ แต่ข้อความจะไม่สามารถเลือกหรือค้นหาได้ในรูปแบบข้อความของ SVG

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    VectorizeText = true
};

using var svgStream = File.Create("slide-with-vectorized-text.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

### **เลือกวิธีการจัดการฟอนต์ภายนอก**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) ใช้ค่า [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) สำหรับฟอนต์ที่โหลดจากภายนอก เลือก `AddLinksToFontFiles` เพื่ออ้างอิงไฟล์ฟอนต์แยกส่วน, `Embed` เพื่อฝังข้อมูลฟอนต์ใน SVG, หรือ `Vectorize` เพื่อเรนเดอร์เฉพาะข้อความที่ใช้ฟอนต์ภายนอกเป็นกราฟิก ตรวจสอบลิขสิทธิ์ของฟอนต์ก่อนฝังฟอนต์

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var linkedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.AddLinksToFontFiles
};

using var linkedFontsStream = File.Create("slide-with-font-links.svg");
presentation.Slides[0].WriteAsSvg(linkedFontsStream, linkedFontsOptions);

var embeddedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Embed
};

using var embeddedFontsStream = File.Create("slide-with-embedded-fonts.svg");
presentation.Slides[0].WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);

var vectorizedExternalFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Vectorize
};

using var vectorizedExternalFontsStream = File.Create("slide-with-vectorized-external-fonts.svg");
presentation.Slides[0].WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
```

## **ลดขนาดภาพที่ฝังไว้**

ใช้ [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) เพื่อลดความละเอียดของภาพที่ฝังไว้, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) เพื่อตัดส่วนภาพที่ถูกครอปออก, และ [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) เพื่อควบคุมคุณภาพการเข้ารหัส JPEG การตั้งค่าเหล่านี้จะลดขนาดไฟล์โดยเสียคุณภาพภาพหรือข้อมูลภาพที่เก็บไว้

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    PicturesCompression = PicturesCompression.Dpi150,
    DeletePicturesCroppedAreas = true,
    JpegQuality = 80
};

using var svgStream = File.Create("compressed-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **ควบคุมความละเอียดการเรซิซาเมทะไฟล์**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) กำหนดขีดจำกัดความละเอียดต่ำสุดสำหรับการเรซิซาเมทะไฟล์ขณะส่งออกเป็น SVG ใช้เพื่อสมดุลรายละเอียดและขนาดไฟล์เมื่อภาพ EMF หรือ WMF ถูกเรซิซา มันไม่ได้กำหนด DPI ทั้งหมดสำหรับ SVG หรือบังคับให้ทุกวัตถุบนสไลด์กลายเป็นภาพเรซิซา

ดาวน์โหลดไฟล์ [metafile-rasterization.pptx](metafile-rasterization.pptx) ซึ่งมีภาพ EMF ที่มีเส้นทแยงมุมห่างกันใกล้ ตัวอย่างต่อไปนี้ส่งออกสไลด์แรกของไฟล์นั้นที่ความละเอียดการเรซิซา 3 ระดับผ่าน [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/) การตั้งค่าอื่น ๆ ของการส่งออกยังคงเหมือนเดิมเพื่อให้เปรียบเทียบผลลัพธ์ได้

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("metafile-rasterization.pptx");

foreach (var dpi in new[] { 72, 150, 300 })
{
    var svgOptions = new SVGOptions
    {
        MetafileRasterizationDpi = dpi,
        PicturesCompression = PicturesCompression.Dpi330,
        JpegQuality = 90
    };

    using var svgStream = File.Create($"slide-{dpi}.svg");
    presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
}
```

ในผลลัพธ์, EMF จะถูกแปลงเป็น PNG ที่ฝังอยู่หนึ่งไฟล์ในแต่ละ SVG การวัดต่อไปนี้เป็นของงานนำเสนอที่ให้มา; ไม่ใช่สูตรทั่วไปสำหรับการแปลง DPI เป็นขนาดพิกเซล

| DPI การเรซิซาเมทะไฟล์ | ขนาด PNG ที่ฝังอยู่ | ขนาดไฟล์ SVG (ไบต์) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

การเปรียบเทียบด้านล่างแสดงพื้นที่เดียวกันของภาพเรซิซาที่ฝังอยู่ที่ขนาดการแสดงผลขยายเท่ากัน เส้นทแยงมุมแสดงพิกเซลที่มองเห็นได้ที่ 72 DPI และขอบที่เรียบขึ้นที่ความละเอียดสูงกว่า ในขณะที่ไฟล์ SVG มีขนาดเพิ่มขึ้น การเพิ่มค่าดังกล่าวไม่ได้หมายความว่าจะปรับปรุงรายละเอียดทุกอย่างหรือเปลี่ยนภาพที่ส่งออกทั้งหมด

![รายละเอียดเส้นทแยงมุมที่ขยายที่ 72, 150, และ 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) ควบคุมการลดความละเอียดของภาพและอาจปิดบังผลของการเปลี่ยนความละเอียดการเรซิซาเมทะไฟล์ [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) ควบคุมคุณภาพการเข้ารหัส JPEG ไม่ใช่ความละเอียดการเรซิซาเมทะไฟล์

## **กำหนด ID คงที่ให้กับรูปร่างและข้อความ**

ใช้ [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) เพื่อตั้งค่า [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) ให้กับแต่ละรูปร่าง SVG เพื่อกำหนดค่า [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) สำหรับองค์ประกอบ `tspan` ของข้อความด้วย ให้ทำการ Implement [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/) กำหนดตัวควบคุมใดตัวหนึ่งด้วย [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/)

คอนโทรลเลอร์ต่อไปนี้ใช้ [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/) ซึ่งคงที่ตลอดอายุของรูปร่าง และตัวนับที่ทำซ้ำได้สำหรับ `tspan` ของข้อความ ทำให้ ID ที่สร้างขึ้นเหมาะสำหรับการประมวลผลต่อจากงานนำเสนอที่ไม่เปลี่ยนแปลง

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new StableSvgIdController()
};

using var svgStream = File.Create("slide-with-stable-ids.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class StableSvgIdController : ISvgShapeAndTextFormattingController
{
    private string currentShapeId = string.Empty;
    private int textSpanIndex;

    public ISvgShapeFormattingController AsISvgShapeFormattingController => this;

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        currentShapeId = $"shape-{shape.OfficeInteropShapeId}";
        textSpanIndex = 0;
        svgShape.Id = currentShapeId;
    }

    public void FormatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame)
    {
        svgTSpan.Id = $"{currentShapeId}-text-{textSpanIndex++}";
    }
}
```

## **เพิ่มตัวจัดการเหตุการณ์ SVG**

ใน [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) ให้เรียก [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) พร้อมค่าของ [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/) เพื่อเพิ่มตัวจัดการเหตุการณ์ JavaScript ให้กับรูปร่างที่ส่งออก กำหนดคอนโทรลเลอร์ด้วย [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) และกำหนดฟังก์ชัน JavaScript ในหน้าเว็บหรือเอกสาร SVG ที่โฮสต์ผลลัพธ์

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new SvgEventController()
};

using var svgStream = File.Create("interactive-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class SvgEventController : ISvgShapeFormattingController
{
    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        if (shape.Name == "ActionButton")
        {
            svgShape.Id = "action-button";
            svgShape.SetEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}
```

หน้าโฮสต์สามารถกำหนดฟังก์ชัน JavaScript ที่อ้างอิงโดยตัวจัดการได้ การกำหนด ID และตัวจัดการเหตุการณ์ทำให้ผู้แสดงสไลด์ การเพิ่มการเข้าถึง และกระบวนการทำงาน SVG ที่โต้ตอบได้อื่น ๆ สามารถทำงานได้

## **คำถามที่พบบ่อย**

**เมื่อใดควรใช้ [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) แทน [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)?**

ใช้ [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) เมื่อข้อความทั้งหมดต้องเป็นอิสระจากฟอนต์ ใช้ [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) เมื่อต้องการแปลงเป็นกราฟิกเฉพาะข้อความที่ใช้ฟอนต์ภายนอก

**วิธีที่ดีที่สุดในการทำให้ SVG มีขนาดเล็กลงคืออะไร?**

เริ่มต้นด้วยการบีบอัดภาพที่ฝังอยู่, ลบส่วนภาพที่ถูกครอป, และเลือกไฟล์ฟอนต์แบบลิงก์เมื่อตัวแวดล้อมเป้าหมายสามารถให้บริการได้ ทดสอบผลลัพธ์เนื่องจากความละเอียดภาพที่ต่ำลง, คุณภาพ JPEG ที่ต่ำลง, และการแปลงข้อความเป็นเวกเตอร์ต่างมีการแลกเปลี่ยนระหว่างคุณภาพและขนาดที่แตกต่างกัน

**ฉันสามารถแก้ไของค์ประกอบ SVG ที่ส่งออกหลังการส่งออกได้หรือไม่?**

ได้เลย กำหนด ID ผ่านตัวควบคุมการจัดรูปแบบ แล้วเลือกองค์ประกอบ SVG ที่ตรงกันในเครื่องมือประมวลผลต่อหรือสคริปต์ของเบราว์เซอร์ของคุณ