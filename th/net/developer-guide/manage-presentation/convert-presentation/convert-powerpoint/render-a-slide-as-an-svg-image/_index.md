---
title: เรนเดอร์สไลด์การนำเสนอเป็นภาพ SVG ใน .NET
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
- SVG เชิงโต้ตอบ
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ส่งออกสไลด์ PowerPoint เป็นภาพ SVG ใน .NET และควบคุมแบบอักษร, ข้อความ, รูปภาพ, ID, และเหตุการณ์ด้วย Aspose.Slides."
---
## **ภาพรวม**

SVG เป็นรูปแบบภาพที่ขยายได้และอิง XML ซึ่งทำงานได้ดีสำหรับการเผยแพร่บนเว็บ, ตัวดูสไลด์, กระบวนการทำให้เข้าถึงได้, และการประมวลผลหลังอัตโนมัติ Aspose.Slides ส่งออกแต่ละสไลด์เป็นไฟล์ SVG แยกไฟล์และให้คุณควบคุมวิธีการเขียนข้อความ, แบบอักษร, รูปภาพ, และองค์ประกอบ SVG

ใช้ [SVGOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/svgoptions/) เมื่อไฟล์ SVG ที่ส่งออกต้องมีขนาดกะทัดรัด, พฤติกรรมคาดเดาได้ในหลายเบราว์เซอร์, หรือพร้อมสำหรับการใช้งานแบบโต้ตอบ

## **ส่งออกสไลด์เป็น SVG**

สร้าง [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) เลือกสไลด์หนึ่งและเขียนลงในสตรีม ตัวอย่างต่อไปนี้ส่งออกรายการสไลด์ทั้งหมดในงานนำเสนอเป็นไฟล์ SVG แยกไฟล์

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

ชื่อไฟล์จะใช้ [ISlide.SlideNumber](https://reference.aspose.com/slides/th/net/aspose.slides/islide/slidenumber/) แทนการใช้ดัชนีของลูป คุณยังสามารถส่งออกรูปร่างเดี่ยวด้วย [IShape.WriteAsSvg](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/writeassvg/) เมื่อผู้ดูสไลด์หรือหน้าเว็บต้องการเพียงรูปร่างนั้นเท่านั้น

## **กำหนดค่าการส่งออก SVG**

[SVGOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/svgoptions/) ควบคุมการแสดงผล SVG สำหรับกรอบข้อความ, [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/th/net/aspose.slides.export/svgoptions/useframesize/) จะรวมกรอบข้อความในพื้นที่การเรนเดอร์ และ [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/th/net/aspose.slides.export/svgoptions/useframerotation/) จะกำหนดว่าการหมุนของกรอบจะถูกนำไปใช้หรือไม่ ตั้งค่า [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/th/net/aspose.slides.export/svgoptions/disablefontligatures/) เป็น `true` เมื่อข้อความต้องแสดงผลโดยไม่มีลิแกเจอร์

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

## **ควบคุมข้อความและแบบอักษร**

### **เวกเตอร์ข้อความทั้งหมด**

ตั้งค่า [SVGOptions.VectorizeText](https://reference.aspose.com/slides/th/net/aspose.slides.export/svgoptions/vectorizetext/) เป็น `true` เพื่อเขียนข้อความทั้งหมดของสไลด์เป็นกราฟิกเวกเตอร์ สิ่งนี้จะขจัดการพึ่งพาแบบอักษรและทำให้ผลลัพธ์ภาพคงที่มากขึ้นในหลายเบราว์เซอร์ แต่ข้อความจะไม่สามารถเลือกหรือค้นหาเป็นข้อความ SVG ได้อีกต่อไป

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

### **เลือกวิธีการจัดการแบบอักษรภายนอก**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/th/net/aspose.slides.export/svgoptions/externalfontshandling/) ใช้ค่า [SvgExternalFontsHandling](https://reference.aspose.com/slides/th/net/aspose.slides.export/svgexternalfontshandling/) สำหรับแบบอักษรที่โหลดจากภายนอก เลือก `AddLinksToFontFiles` เพื่ออ้างอิงไฟล์แบบอักษรแยกต่างหาก, `Embed` เพื่อฝังข้อมูลแบบอักษรลงใน SVG, หรือ `Vectorize` เพื่อเรนเดอร์เฉพาะข้อความที่ใช้แบบอักษรภายนอกเป็นกราฟิก ตรวจสอบใบอนุญาตแบบอักษรก่อนฝังแบบอักษร

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

## **ลดขนาดภาพที่ฝังอยู่**

ใช้ [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/th/net/aspose.slides.export/svgoptions/picturescompression/) เพื่อลดความละเอียดของรูปภาพที่ฝังอยู่, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/th/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) เพื่อตัดพื้นที่ภาพที่ถูกครอปออก, และ [SVGOptions.JpegQuality](https://reference.aspose.com/slides/th/net/aspose.slides.export/svgoptions/jpegquality/) เพื่อควบคุมคุณภาพการเข้ารหัส JPEG การตั้งค่าเหล่านี้จะลดขนาดไฟล์โดยอาจส่งผลต่อความคมชัดของภาพหรือข้อมูลภาพที่เก็บไว้

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

## **กำหนด ID คงที่ให้กับรูปร่างและข้อความ**

ใช้ [ISvgShapeFormattingController](https://reference.aspose.com/slides/th/net/aspose.slides.export/isvgshapeformattingcontroller/) เพื่อกำหนดค่า [ISvgShape.Id](https://reference.aspose.com/slides/th/net/aspose.slides.export/isvgshape/id/) สำหรับแต่ละรูปร่าง SVG หากต้องการกำหนดค่า [ISvgTSpan.Id](https://reference.aspose.com/slides/th/net/aspose.slides.export/isvgtspan/id/) ให้กับองค์ประกอบข้อความ `tspan` ด้วย ให้ใช้ [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/th/net/aspose.slides.export/isvgshapeandtextformattingcontroller/) กำหนดคอนโทรลเลอร์ใดก็ได้ด้วย [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/th/net/aspose.slides.export/svgoptions/shapeformattingcontroller/)

คอนโทรลเลอร์ต่อไปนี้ใช้ [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/officeinteropshapeid/) ซึ่งคงที่ตลอดอายุของรูปร่าง และตัวนับที่ทำซ้ำได้สำหรับข้อความ `tspan` ของมัน ทำให้ ID ที่สร้างขึ้นเหมาะสำหรับการประมวลผลต่อจากงานนำเสนอที่ไม่เปลี่ยนแปลง

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

ใน [ISvgShapeFormattingController](https://reference.aspose.com/slides/th/net/aspose.slides.export/isvgshapeformattingcontroller/) ให้เรียก [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/th/net/aspose.slides.export/isvgshape/seteventhandler/) พร้อมค่าของ [SvgEvent](https://reference.aspose.com/slides/th/net/aspose.slides.export/svgevent/) เพื่อติดตั้งตัวจัดการเหตุการณ์ JavaScript ให้กับรูปร่างที่ส่งออก กำหนดคอนโทรลเลอร์ด้วย [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/th/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) และกำหนดฟังก์ชัน JavaScript ในหน้าเว็บหรือเอกสาร SVG ที่โฮสต์ผลลัพธ์

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

หน้าผู้โฮสต์สามารถกำหนดฟังก์ชัน JavaScript ที่อ้างอิงโดยตัวจัดการเหตุการณ์ การกำหนด ID และตัวจัดการเหตุการณ์ช่วยให้ผู้ดูสไลด์, การปรับปรุงการเข้าถึง, และกระบวนการทำงาน SVG แบบโต้ตอบอื่น ๆ ทำงานได้

## **คำถามที่พบบ่อย**

**เมื่อใดควรใช้ [SVGOptions.VectorizeText](https://reference.aspose.com/slides/th/net/aspose.slides.export/svgoptions/vectorizetext/) แทน [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/th/net/aspose.slides.export/svgexternalfontshandling/)?**

ใช้ [SVGOptions.VectorizeText](https://reference.aspose.com/slides/th/net/aspose.slides.export/svgoptions/vectorizetext/) เมื่อข้อความทั้งหมดต้องเป็นอิสระจากแบบอักษร ใช้ [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/th/net/aspose.slides.export/svgexternalfontshandling/) เมื่อต้องการแปลงเป็นกราฟิกเฉพาะข้อความที่ใช้แบบอักษรภายนอกเท่านั้น

**วิธีที่ดีที่สุดในการทำให้ไฟล์ SVG มีขนาดเล็กลงคืออะไร?**

เริ่มต้นด้วยการบีบอัดรูปภาพที่ฝังอยู่, ลบพื้นที่ภาพที่ถูกครอป, และเลือกไฟล์แบบอักษรที่เชื่อมโยงเมื่อสภาพแวดล้อมเป้าหมายสามารถให้บริการได้ ทดสอบผลลัพธ์เนื่องจากความละเอียดภาพที่ต่ำลง, คุณภาพ JPEG ที่ต่ำลง, และข้อความที่เวกเตอร์化 มีการแลกเปลี่ยนคุณภาพและขนาดที่แตกต่างกัน

**ฉันสามารถแก้ไของค์ประกอบ SVG ที่ส่งออกหลังจากการส่งออกได้หรือไม่?**

ได้ คุณสามารถกำหนด ID ผ่านคอนโทรลเลอร์การฟอร์แม็ต แล้วเลือกองค์ประกอบ SVG ที่ตรงกันในเครื่องมือหลังการประมวลผลหรือสคริปต์ของเบราว์เซอร์ของคุณ