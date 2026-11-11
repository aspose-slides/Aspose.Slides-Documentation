---
title: เรนเดอร์สไลด์พรีเซนเทชั่นเป็นภาพ SVG ใน .NET
linktitle: สไลด์เป็น SVG
type: docs
weight: 50
url: /th/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint เป็น SVG
- พรีเซนเทชั่นเป็น SVG
- สไลด์เป็น SVG
- PPT เป็น SVG
- PPTX เป็น SVG
- ตัวเลือกการส่งออก SVG
- SVG แบบโต้ตอบ
- PowerPoint
- พรีเซนเทชั่น
- .NET
- C#
- Aspose.Slides
description: "ส่งออกสไลด์ PowerPoint เป็นภาพ SVG ใน .NET และควบคุมแบบอักษร, ข้อความ, รูปภาพ, ID และเหตุการณ์ด้วย Aspose.Slides."
---
## **ภาพรวม**

SVG เป็นรูปแบบภาพที่ขยายได้โดยใช้ XML ซึ่งทำงานได้ดีสำหรับการเผยแพร่บนเว็บ, ตัวดูสไลด์, กระบวนการทำให้เข้าถึงได้, และการประมวลผลหลังอัตโนมัติ. Aspose.Slides ส่งออกแต่ละสไลด์เป็นไฟล์ SVG แยกไฟล์และให้คุณควบคุมว่าข้อความ, ฟอนต์, รูปภาพ, และองค์ประกอบ SVG ถูกเขียนอย่างไร.

ใช้ [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) เมื่อ SVG ที่ส่งออกต้องมีขนาดกระชับ, คาดเดาได้ในหลายเบราว์เซอร์, หรือพร้อมสำหรับการใช้งานแบบโต้ตอบ.

## **ส่งออกสไลด์เป็น SVG**

สร้าง [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), เลือกสไลด์หนึ่งและเขียนลงสตรีม. ตัวอย่างต่อไปนี้ส่งออกทุกสไลด์ในงานนำเสนอเป็นไฟล์ SVG แยกไฟล์.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

ชื่อไฟล์ใช้ [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) แทนการใช้ดัชนีของลูป. คุณยังสามารถส่งออกรูปทรงเดี่ยวโดยใช้ [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/) เมื่อผู้ดูสไลด์หรือเว็บเพจต้องการเพียงรูปทรงนั้น.

## **กำหนดค่าการส่งออก SVG**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) ควบคุมการเรนเดอร์ SVG. สำหรับกรอบข้อความ, [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) จะรวมกรอบข้อความในพื้นที่การเรนเดอร์, และ [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) กำหนดว่าการหมุนกรอบจะถูกนำมาใช้หรือไม่. ตั้งค่า [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) เป็น `true` เมื่อต้องการเรนเดอร์ข้อความโดยไม่มีลิกะเจอร์.

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

## **ควบคุมการครอบส่วนสิ้นสุดเส้นที่หัวลูกศร**

SVG 1.1 ไม่มีการตั้งค่า marker inset เพื่อกำหนดว่าต้องหยุดเส้นที่ตำแหน่งใดใต้หัวลูกศร. โดยค่าเริ่มต้น, Aspose.Slides จะย่อความยาวของเส้นที่ส่งออกเพื่อให้เส้นขอบไม่ยื่นผ่านเครื่องหมาย. ตั้งค่า [SVGOptions.DisableLineEndCropping](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablelineendcropping/) เป็น `true` เพื่อวาดเส้นขอบจนถึงจุดสิ้นสุดดั้งเดิมของเส้น. การตั้งค่านี้ส่งผลต่อการส่งออก SVG เท่านั้น. เส้นจะคงตำแหน่งและความยาวบนสไลด์.

ตัวอย่างวาดหัวลูกศรรูปสามเหลี่ยมและเพชรบนเส้นที่กว้าง 2 และ 10 จุด. มันส่งออกสไลด์เดียวกันสองครั้งโดยเปลี่ยนเฉพาะตัวเลือกการครอบเท่านั้น.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var y = 40;

foreach (var style in new[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond })
{
    foreach (var width in new[] { 2, 10 })
    {
        var line = slide.Shapes.AddAutoShape(ShapeType.Line, 40, y, 200, 0);
        var format = line.LineFormat;
        format.FillFormat.FillType = FillType.Solid;
        format.FillFormat.SolidFillColor.Color = Color.DarkBlue;
        format.Width = width;
        format.EndArrowheadStyle = style;
        y += 50;
    }
}

var options = new SVGOptions { DisableLineEndCropping = false };
using var cropped = File.Create("cropped.svg");
slide.WriteAsSvg(cropped, options);

options.DisableLineEndCropping = true;
using var uncropped = File.Create("uncropped.svg");
slide.WriteAsSvg(uncropped, options);
```

การเปรียบเทียบแสดงหัวลูกศรรูปสามเหลี่ยมบนเส้นที่กว้าง 10 จุด. เมื่อเปิดการครอบ, ปลายจะคม. เมื่อปิดการครอบ, เส้นขอบยื่นผ่านด้านลาดของเครื่องหมายและเหลือปลายแบน.

![สามเหลี่ยมขนาด 10 จุดที่ขยายขึ้นพร้อมปลายคมเมื่อเปิดการครอบและปลายแบนเมื่อปิดการครอบ](line-end-cropping.png)

ในเส้นอื่นจากตัวอย่าง, เส้นขอบที่ยื่นจะมองเห็นได้น้อยลงบนสามเหลี่ยมที่กว้าง 2 จุด. เพชรที่เติมสีเต็มจะปกปิดส่วนปลายของเส้นขอบในความกว้างทั้งสอง.

## **ควบคุมข้อความและแบบอักษร**

เมื่อส่งออกสไลด์เป็น SVG, คุณสามารถควบคุมว่าข้อความจะคงเป็นข้อความหรือแปลงเป็นกราฟิกเวกเตอร์, และวิธีการรวมหรืออ้างอิงแบบอักษรภายนอก. ตัวเลือกต่อไปนี้ช่วยให้คุณสมดุลความสอดคล้องของภาพ, การเลือกข้อความ, และการพึ่งพาแบบอักษรใน SVG ที่ส่งออก.

### **เวกเตอร์ข้อความทั้งหมด**

ตั้งค่า [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) เป็น `true` เพื่อเขียนข้อความทั้งหมดในสไลด์เป็นกราฟิกเวกเตอร์. วิธีนี้กำจัดการพึ่งพาแบบอักษรและทำให้ผลลัพธ์ภาพสอดคล้องกันมากขึ้นในหลายเบราว์เซอร์, แต่ข้อความจะไม่สามารถเลือกหรือค้นหาได้ในรูปแบบข้อความ SVG อีกต่อไป.

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

### **เลือกวิธีจัดการแบบอักษรภายนอก**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) ใช้ค่า [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) สำหรับแบบอักษรที่โหลดจากภายนอก. เลือก `AddLinksToFontFiles` เพื่ออ้างอิงไฟล์แบบอักษรแยก, `Embed` เพื่อรวมข้อมูลแบบอักษรใน SVG, หรือ `Vectorize` เพื่อแปลงข้อความที่ใช้แบบอักษรภายนอกเป็นกราฟิกเท่านั้น. ตรวจสอบลิขสิทธิ์ของแบบอักษรก่อนทำการฝัง.

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

## **ลดขนาดภาพที่ฝัง**

ใช้ [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) เพื่อลดความละเอียดของรูปภาพที่ฝัง, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) เพื่อละเว้นพื้นที่ภาพที่ถูกตัด, และ [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) เพื่อควบคุมคุณภาพการเข้ารหัส JPEG. การตั้งค่าเหล่านี้ลดขนาดไฟล์โดยอาจสูญเสียความละเอียดของภาพหรือข้อมูลรูปภาพที่เก็บไว้.

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

## **ควบคุมความละเอียดการเรเซอร์เมตาฟายล์**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) กำหนดขีดจำกัดความละเอียดต่ำสุดสำหรับการเรเซอร์เมตาฟายล์ระหว่างการส่งออก SVG. ใช้เพื่อสมดุลรายละเอียดและขนาดไฟล์เมื่อภาพ EMF หรือ WMF ถูกเรเซอร์. ค่าตัวนี้ไม่ได้กำหนด DPI สากลสำหรับ SVG หรือบังคับให้วัตถุทุกอย่างบนสไลด์กลายเป็นภาพราสเตอร์.

ดาวน์โหลด [metafile-rasterization.pptx](metafile-rasterization.pptx) ซึ่งมีภาพ EMF ที่มีเส้นทแยงมุมห่างกันอย่างใกล้ชิด. ตัวอย่างต่อไปนี้ส่งออกสไลด์แรกของไฟล์ที่ความละเอียดการเรเซอร์สามระดับผ่าน [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/). การตั้งค่าอื่น ๆ ของการส่งออกจะคงเดิมเพื่อให้สามารถเปรียบเทียบผลลัพธ์ได้.

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

ในผลลัพธ์, EMF จะถูกแปลงเป็น PNG ที่ฝังหนึ่งไฟล์ในแต่ละ SVG. การวัดต่อไปนี้เป็นสำหรับงานนำเสนอที่ให้มา; ไม่ใช่สูตรทั่วไปสำหรับการแปลง DPI เป็นขนาดพิกเซล.

| DPI การเรเซอร์เมตาฟายล์ | ขนาด PNG ที่ฝัง | ขนาดไฟล์ SVG (ไบต์) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

การเปรียบเทียบด้านล่างแสดงพื้นที่เดียวกันของภาพราสเตอร์ที่ฝังในขนาดการแสดงผลที่ขยายเท่าเดิม. เส้นทแยงมุมแสดงพิกเซลชัดที่ 72 DPI และขอบที่เรียบเนียนยิ่งขึ้นที่ความละเอียดสูงกว่า, ในขณะที่ไฟล์ SVG จะใหญ่ขึ้น. การเพิ่มค่าดังกล่าวไม่ได้จำเป็นต้องปรับปรุงทุกรายละเอียดหรือเปลี่ยนภาพที่ส่งออกทั้งหมด.

![รายละเอียดเส้นทแยงมุมที่ขยายที่ 72, 150 และ 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) ควบคุมการลดความละเอียดของภาพและอาจปิดบังผลของการเปลี่ยนความละเอียดการเรเซอร์เมตาฟายล์. [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) ควบคุมคุณภาพการเข้ารหัส JPEG, ไม่ใช่ความละเอียดการเรเซอร์เมตาฟายล์.

## **กำหนด ID ที่คงที่ให้กับรูปทรงและข้อความ**

ใช้ [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) เพื่อกำหนดค่า [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) สำหรับแต่ละรูปทรง SVG. เพื่อกำหนดค่า [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) ให้กับองค์ประกอบ `tspan` ของข้อความด้วย, ให้ทำการใช้งาน [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). กำหนดคอนโทรลเลอร์ใดก็ได้ด้วย [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

คอนโทรลเลอร์ต่อไปนี้ใช้ [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/), ซึ่งคงที่ตลอดอายุของรูปทรง, พร้อมกับตัวนับที่ทำซ้ำได้สำหรับ `tspan` ของข้อความ. สิ่งนี้ทำให้ ID ที่สร้างขึ้นเหมาะสำหรับการประมวลผลต่อในงานนำเสนอที่ไม่มีการเปลี่ยนแปลง.

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

ใน [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/), เรียก [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) พร้อมค่าของ [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/) เพื่อเพิ่มตัวจัดการเหตุการณ์ JavaScript ให้กับรูปทรงที่ส่งออก. กำหนดคอนโทรลเลอร์ด้วย [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) และกำหนดฟังก์ชัน JavaScript ในหน้าเว็บหรือเอกสาร SVG ที่เป็นโฮสต์ของผลลัพธ์.

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

หน้าโฮสต์สามารถกำหนดฟังก์ชัน JavaScript ที่อ้างอิงโดยตัวจัดการได้. การกำหนด ID และตัวจัดการเหตุการณ์ทำให้ผู้ดูสไลด์, การปรับปรุงการเข้าถึง, และกระบวนการทำงาน SVG แบบโต้ตอบอื่น ๆ ทำงานได้.

## **คำถามที่พบบ่อย**

**เมื่อใดที่ควรใช้ [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) แทน [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)?**

ใช้ [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) เมื่อข้อความทั้งหมดต้องไม่พึ่งพาแบบอักษร. ใช้ [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) เมื่อเฉพาะข้อความที่ใช้แบบอักษรภายนอกควรแปลงเป็นกราฟิก.

**วิธีที่ดีที่สุดในการทำให้ SVG มีขนาดเล็กลงคืออะไร?**

เริ่มต้นด้วยการบีบอัดรูปภาพที่ฝัง, ลบพื้นที่รูปภาพที่ถูกตัด, และเลือกไฟล์แบบอักษรแบบลิงก์เมื่อสภาพแวดล้อมเป้าหมายสามารถให้บริการไฟล์เหล่านั้นได้. ทดสอบผลลัพธ์เนื่องจากความละเอียดภาพที่ต่ำลง, คุณภาพ JPEG ที่ต่ำลง, และข้อความที่เวกเตอร์ล้วนต่างมีข้อแลกเปลี่ยนด้านคุณภาพและขนาดที่แตกต่างกัน.

**ฉันสามารถแก้ไของค์ประกอบ SVG ที่ส่งออกหลังการส่งออกได้หรือไม่?**

ได้. กำหนด ID ผ่านคอนโทรลเลอร์การจัดรูปแบบ, แล้วเลือกองค์ประกอบ SVG ที่ตรงกันในเครื่องมือประมวลผลต่อหรือสคริปต์ของเบราว์เซอร์ของคุณ.