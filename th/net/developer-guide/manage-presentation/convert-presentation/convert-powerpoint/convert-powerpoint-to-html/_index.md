---
title: แปลงงานนำเสนอ PowerPoint เป็น HTML ใน .NET
linktitle: PowerPoint เป็น HTML
type: docs
weight: 30
url: /th/net/convert-powerpoint-to-html/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น HTML
- งานนำเสนอเป็น HTML
- สไลด์เป็น HTML
- PPT เป็น HTML
- PPTX เป็น HTML
- บันทึก PowerPoint เป็น HTML
- บันทึกงานนำเสนอเป็น HTML
- บันทึกสไลด์เป็น HTML
- บันทึก PPT เป็น HTML
- บันทึก PPTX เป็น HTML
- ส่งออก PPT เป็น HTML
- ส่งออก PPTX เป็น HTML
- .NET
- C#
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint เป็น HTML ใน .NET ใช้ Aspose.Slides เพื่อส่งออกไฟล์ PPT และ PPTX, สไลด์ที่เลือก, โน้ต, ฟอนต์, รูปภาพ, SVG และสื่อ."
---
## **ภาพรวม**

Aspose.Slides for .NET สามารถบันทึกงานนำเสนอ PowerPoint เป็น HTML ได้โดยไม่ต้องใช้ Microsoft PowerPoint การแปลงพื้นฐานคือการโหลด [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) เพียงครั้งเดียวและเรียก [Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/) ด้วย [SaveFormat](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveformat/) ใช้ [HtmlOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/htmloptions/) เมื่อคุณต้องการควบคุมการจัดรูปแบบที่ส่งออก ฟอนต์ รูปภาพ โน้ต ความคิดเห็น การส่งออก SVG หรือทรัพยากรที่เชื่อมโยง

คู่มือนี้มุ่งเน้นที่สถานการณ์การส่งออก HTML ที่ใช้งานจริง:

- ส่งออกงานนำเสนอทั้งหมดหรือสไลด์ที่เลือก
- สร้าง HTML แบบจัดแนวคงที่, แบบตอบสนอง, หรือแบบใช้ SVG
- รวมโน้ตของผู้พูดและความคิดเห็น
- ควบคุมคุณภาพของรูปภาพและข้อมูลส่วนที่ตัดออกของรูปภาพ
- ฝังฟอนต์หรือบันทึกไฟล์ฟอนต์แยกต่างหาก
- เลือกวิธีการเขียนและอ้างอิงทรัพยากรภายนอกและไฟล์สื่อ

โดยค่าเริ่มต้น การส่งออก HTML จะสร้างเอกสาร HTML แบบรวมทุกอย่างซึ่งทรัพยากรส่วนใหญ่ฝังไว้ในไฟล์ ซึ่งสะดวกสำหรับการแชร์ไฟล์เดียว แต่จะทำให้ขนาดไฟล์เพิ่มขึ้น สำหรับการเผยแพร่บนเว็บ ให้พิจารณาใช้ทรัพยากรภายนอก ลด DPI ของรูปภาพ และฝังฟอนต์เฉพาะที่ไม่มีอยู่ในสภาพแวดล้อมเป้าหมายอย่างมั่นคง

## **แปลงงานนำเสนอเป็น HTML**

เพื่อส่งออกงานนำเสนอเป็น HTML ให้โหลดด้วย [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) แล้วบันทึกด้วย [SaveFormat.Html](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveformat/)

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Save("presentation.html", SaveFormat.Html);
```

ตัวอย่างนี้เขียนไฟล์ HTML หนึ่งไฟล์ วัตถุ Presentation จะถูกทำลายโดยคำสั่ง `using` ซึ่งจะปล่อยไฟล์แฮนด์เดิลและทรัพยากรการเรนเดอร์หลังการส่งออก

## **ใช้ HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/htmloptions/) เป็นคลาสการกำหนดค่าหลักสำหรับการส่งออก HTML การตั้งค่าทั่วไปรวมถึง:

- `SlidesLayoutOptions`: เพิ่มโน้ต, ความคิดเห็น, สไลด์แจกเอกสาร, หรือข้อมูลการจัดรูปแบบอื่น
- `HtmlFormatter`: เปลี่ยนโครงสร้างเอกสาร HTML หรือมอบหมายการจัดรูปแบบให้กับคอนโทรลเลอร์
- `SlideImageFormat`: เปลี่ยนวิธีการแทนสไลด์ เช่น เป็น SVG
- `PicturesCompression`: ควบคุม DPI ของรูปภาพและขนาดผลลัพธ์
- `DeletePicturesCroppedAreas`: รักษาหรือลบข้อมูลส่วนที่ตัดของรูปภาพ
- `SvgResponsiveLayout`: ทำให้เนื้อหา SVG ที่ส่งออกปรับให้เข้ากับคอนเทนเนอร์ของมัน
- `ShowHiddenSlides`: รวมสไลด์ที่ซ่อนเมื่อจำเป็น

ส่วนต่อไปนี้จะแสดงตัวเลือกที่พบบ่อยที่สุดแยกกันเพื่อให้คุณสามารถรวมเฉพาะตัวเลือกที่จำเป็นต่อขั้นตอนการทำงานของคุณ

## **แปลงสไลด์ที่เลือกเป็น HTML**

เมทอดโอเวอร์โหลด [Presentation.Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/) ที่รับหมายเลขสไลด์ใช้ตำแหน่งสไลด์แบบ 1‑based ลูปด้านล่างจะบันทึกแต่ละสไลด์เป็นไฟล์ HTML แยกกัน

```csharp
using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slideNumber = slideIndex + 1;
    var slideNumbers = new[] { slideNumber };
    var htmlFileName = $"slide-{slideNumber}.html";

    presentation.Save(htmlFileName, slideNumbers, SaveFormat.Html);
}
```

ใช้รูปแบบนี้เมื่อต้องการหน้า HTML หนึ่งหน้าต่อสไลด์ หากแต่ละสไลด์ต้องการเลเอาท์เดียวกัน ให้สร้างอินสแตนซ์ของ [HtmlOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/htmloptions/) หนึ่งตัวและส่งผ่านให้กับการเรียก `Save` ทุกครั้ง

## **สร้าง HTML แบบตอบสนอง**

[ResponsiveHtmlController](https://reference.aspose.com/slides/th/net/aspose.slides.export/responsivehtmlcontroller/) ให้ผลลัพธ์ HTML แบบตอบสนองผ่าน [HtmlFormatter](https://reference.aspose.com/slides/th/net/aspose.slides.export/htmlformatter/) ใช้มันเมื่อหน้าที่ส่งออกต้องปรับให้เข้ากับความกว้างของเบราว์เซอร์ได้ดีขึ้น

```csharp
using var presentation = new Presentation("presentation.pptx");

var controller = new ResponsiveHtmlController();
var formatter = HtmlFormatter.CreateCustomFormatter(controller);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
```

สำหรับการจัดวางแบบตอบสนองที่ใช้ SVG ให้ตั้งค่า `SvgResponsiveLayout` บน [HtmlOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/htmloptions/) นี่เป็นประโยชน์เมื่อเนื้อหาสไลด์ถูกส่งออกเป็น SVG ที่สามารถปรับขนาดได้

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    SvgResponsiveLayout = true
};

presentation.Save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
```

## **รวมโน้ตผู้พูดและความคิดเห็น**

ใช้ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/notescommentslayoutingoptions/) ผ่าน `HtmlOptions.SlidesLayoutOptions` เพื่อรวมโน้ตผู้พูดหรือความคิดเห็น โน้ตและความคิดเห็นจะถูกซ่อนไว้ตามค่าเริ่มต้นจนกว่าจะกำหนดตำแหน่งของมัน

สมมติว่าต้นฉบับงานนำเสนอมีโน้ตผู้พูด:

![สไลด์พร้อมโน้ตผู้พูดใน PowerPoint](slide_with_notes.png)

โค้ดด้านล่างส่งออกเนื้อหาสไลด์พร้อมโน้ตผู้พูดใต้สไลด์

```csharp
using var presentation = new Presentation("presentation.pptx");

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomFull
};

var htmlOptions = new HtmlOptions
{
    SlidesLayoutOptions = layoutOptions
};

presentation.Save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
```

![ผลลัพธ์ HTML พร้อมสไลด์และโน้ตผู้พูด](HTML_with_notes.png)

เพื่อส่งออกความคิดเห็น ให้ตั้งค่า `CommentsPosition` เช่น `CommentsPositions.Right` หรือ `CommentsPositions.Bottom` หากต้องการเฉพาะความคิดเห็นให้ละเว้น `NotesPosition` หากต้องการทั้งโน้ตและความคิดเห็นให้ตั้งค่าทั้งสองคุณสมบัติ

## **ควบคุมคุณภาพรูปภาพและพื้นที่ที่ถูกตัด**

การส่งออก HTML สามารถบีบอัดรูปภาพสไลด์เพื่อลดขนาดผลลัพธ์ ตั้งค่า `PicturesCompression` เป็นค่าจาก [PicturesCompression](https://reference.aspose.com/slides/th/net/aspose.slides.export/picturescompression/) เมื่อคุณต้องการคุณภาพรูปภาพสูงขึ้น

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};

presentation.Save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
```

โดยค่าเริ่มต้น พื้นที่ที่ถูกตัดของรูปภาพอาจถูกลบออกจากผลลัพธ์ที่ส่งออก เก็บข้อมูลที่ถูกตัดไว้เฉพาะเมื่อผู้ใช้จำเป็นต้องกู้คืนหรือตรวจสอบส่วนรูปภาพที่ซ่อนอยู่ การเก็บไว้จะทำให้ขนาด HTML เพิ่มขึ้น

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};

presentation.Save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
```

## **เพิ่ม CSS**

สำหรับการจัดรูปแบบแบบง่าย ให้ส่งสตริง CSS ไปยัง [HtmlFormatter.CreateDocumentFormatter](https://reference.aspose.com/slides/th/net/aspose.slides.export/htmlformatter/createdocumentformatter/) ซึ่งจะเปลี่ยนเอกสาร HTML รอบ ๆ ขณะที่ Aspose.Slides ยังคงเรนเดอร์เนื้อหาสไลด์

```csharp
using var presentation = new Presentation("presentation.pptx");

var cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
var formatter = HtmlFormatter.CreateDocumentFormatter(cssRules, true);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-styled.html", SaveFormat.Html, htmlOptions);
```

หากต้องการส่วนหัวเอกสารแบบกำหนดเอง ไฟล์ CSS ที่เชื่อมโยง หรือมาร์กอัปแบบกำหนดเองรอบสไลด์และรูปร่าง ให้ทำการ implement [IHtmlFormattingController](https://reference.aspose.com/slides/th/net/aspose.slides.export/ihtmlformattingcontroller/) และส่งให้กับ [HtmlFormatter](https://reference.aspose.com/slides/th/net/aspose.slides.export/htmlformatter/) ด้วย `CreateCustomFormatter`

## **ฝังฟอนต์**

หากสภาพแวดล้อมเป้าหมายอาจไม่มีฟอนต์ของงานนำเสนอที่ติดตั้งไว้ ให้ฝังฟอนต์ใน HTML ด้วย [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/th/net/aspose.slides.export/embedallfontshtmlcontroller/) การฝังฟอนต์ช่วยเพิ่มความแม่นยำของภาพแต่ทำให้ขนาดผลลัพธ์เพิ่มขึ้น

```csharp
using var presentation = new Presentation("presentation.pptx");

string[] fontNamesToExclude = { "Arial", "Calibri" };
var fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
```

ยกเว้นฟอนต์เฉพาะเมื่อคุณมั่นใจว่าบราวเซอร์หรือระบบเป้าหมายมีฟอนต์เหล่านั้นแล้ว สำหรับฟอนต์ของแบรนด์หรือฟอนต์ที่ไม่ทั่วไป การฝังฟอนต์มักจะปลอดภัยกว่า

## **ลิงก์ไฟล์ฟอนต์แทนการฝังฟอนต์**

เพื่อลดขนาดไฟล์ HTML คุณสามารถเขียนข้อมูลฟอนต์เป็นไฟล์ WOFF แยกต่างหากและเพิ่มกฎ `@font-face` ลงใน HTML ตัวช่วยด้านล่างทำการขยาย [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/th/net/aspose.slides.export/embedallfontshtmlcontroller/) และ override `WriteFont`

```cs
using var presentation = new Presentation("presentation.pptx");

var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var fontsDirectory = Path.Combine(outputDirectory, "fonts");
Directory.CreateDirectory(outputDirectory);

var fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```
```cs
public sealed class LinkedFontsHtmlController : EmbedAllFontsHtmlController
{
    private readonly string _fontOutputDirectory;
    private readonly string _fontUrlPrefix;

    public LinkedFontsHtmlController(
        string fontOutputDirectory,
        string fontUrlPrefix)
        : base(Array.Empty<string>())
    {
        _fontOutputDirectory = fontOutputDirectory;
        _fontUrlPrefix = fontUrlPrefix.TrimEnd('/') + "/";

        Directory.CreateDirectory(_fontOutputDirectory);
    }

    public override void WriteFont(
        IHtmlGenerator generator,
        IFontData originalFont,
        IFontData substitutedFont,
        string fontStyle,
        string fontWeight,
        byte[] fontData)
    {
        var font = substitutedFont ?? originalFont;
        var safeFontName = MakeSafeFileName(font.FontName);
        var safeFontStyle = string.IsNullOrWhiteSpace(fontStyle) ? "normal" : fontStyle;
        var safeFontWeight = string.IsNullOrWhiteSpace(fontWeight) ? "normal" : fontWeight;
        var fontFileName = $"{safeFontName}-{safeFontStyle}-{safeFontWeight}.woff";
        var fontFilePath = Path.Combine(_fontOutputDirectory, fontFileName);

        File.WriteAllBytes(fontFilePath, fontData);

        var fontUrl = _fontUrlPrefix + Uri.EscapeDataString(fontFileName);
        var fontFamily = font.FontName.Replace("\\", "\\\\").Replace("'", "\\'");

        generator.AddHtml("<style>");
        generator.AddHtml("@font-face {");
        generator.AddHtml($"font-family: '{fontFamily}';");
        generator.AddHtml($"font-style: {safeFontStyle};");
        generator.AddHtml($"font-weight: {safeFontWeight};");
        generator.AddHtml($"src: url('{fontUrl}') format('woff');");
        generator.AddHtml("}");
        generator.AddHtml("</style>");
    }

    private static string MakeSafeFileName(string fileName)
    {
        var invalidCharacters = Path.GetInvalidFileNameChars();
        var safeCharacters = fileName.ToCharArray();

        for (var characterIndex = 0; characterIndex < safeCharacters.Length; characterIndex++)
        {
            if (Array.IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new string(safeCharacters);
    }
}
```

ในตัวอย่างนี้ไฟล์ฟอนต์จะบันทึกลงใน `html-output/fonts` และ HTML จะอ้างอิงไฟล์เหล่านั้นด้วย URL เช่น `fonts/BrandFont-normal-400.woff` หากไฟล์ HTML และฟอนต์ถูกปรับใช้งานในตำแหน่งอื่น ให้เลือก `fontUrlPrefix` ให้ตรงกับพาธ URL ที่ปรับใช้

## **บันทึกทรัพยากรเป็นไฟล์ภายนอก**

HTML แบบรวมทุกอย่างทำให้ย้ายง่าย แต่ทรัพยากรที่ฝังเป็น Base64 จะทำให้ไฟล์ใหญ่ หากแอปพลิเคชันของคุณต้องการไฟล์รูปภาพภายนอก ให้ implement [ILinkEmbedController](https://reference.aspose.com/slides/th/net/aspose.slides.export/ilinkembedcontroller/) และส่งให้กับคอนสตรัคเตอร์ของ [HtmlOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/htmloptions/htmloptions/)

เมื่อคุณทำให้ทรัพยากรเป็นไฟล์ภายนอก ให้เลือกสองพาธอย่างชัดเจน:
- พาธการออกไฟล์ในระบบไฟล์ ซึ่งแอปพลิเคชันของคุณจะเขียนรูปภาพ, ฟอนต์, เสียง หรือวิดีโอที่สร้างขึ้น
- พาธ URL ที่เบราว์เซอร์ใช้จากเอกสาร HTML เพื่อโหลดไฟล์เหล่านั้น

สำหรับการทำงานเชื่อมโยงรูปภาพเต็มรูปแบบ ดู [Export Presentations to HTML with Externally Linked Images](/slides/th/net/exporting-presentations-to-html-with-externally-linked-images/)

## **ส่งออกไฟล์สื่อ**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/th/net/aspose.slides.export/videoplayerhtmlcontroller/) ส่งออกไฟล์วิดีโอและเสียงและเขียน HTML ที่สามารถเล่นไฟล์เหล่านี้ในเบราว์เซอร์ ตัวคอนสตรัคเตอร์รับ:
- `path`: ไดเรกทอรีที่ไฟล์สื่อที่สร้างขึ้นจะถูกเขียน
- `fileName`: ชื่อไฟล์ HTML ที่กำลังสร้าง
- `baseUri`: คำต่อ URI สัมบูรณ์ที่ใช้ในลิงก์ HTML ไปยังไฟล์สื่อ

หากไฟล์ HTML คือ `html-output/presentation.html` และไฟล์สื่อบันทึกไว้ใน `html-output/media` `path` ควรชี้ไปที่ไดเรกทอรีสื่อบนดิสก์ ส่วน `baseUri` ควรชี้ไปที่ไดเรกทอรีเดียวกันจากมุมมองของเบราว์เซอร์ สำหรับการพรีวิวแบบโลคัล คุณสามารถสร้าง URI แบบ `file:///` จากไดเรกทอรีสื่อได้ สำหรับแอปพลิเคชันที่ปรับใช้ ให้ใช้ URL สมบูรณ์ของไดเรกทอรีสื่อที่เผยแพร่

```csharp
var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var mediaDirectory = Path.Combine(outputDirectory, "media");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(mediaDirectory);

var htmlFileName = "presentation.html";
var mediaBaseUri = new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri;

using var presentation = new Presentation();
using var videoStream = new FileStream("intro.mp4", FileMode.Open, FileAccess.Read);

var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
var slide = presentation.Slides[0];
slide.Shapes.AddVideoFrame(20, 20, 480, 270, video);

var controller = new VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
var formatter = HtmlFormatter.CreateCustomFormatter(controller);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = formatter,
    SlideImageFormat = slideImageFormat
};

var htmlFilePath = Path.Combine(outputDirectory, htmlFileName);
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

ใช้ไดเรกทอรีผลลัพธ์ที่เป็นเอกลักษณ์ต่อแต่ละงานส่งออก โดยเฉพาะในแอปพลิเคชันเซิร์ฟเวอร์ พาธผลลัพธ์ที่ใช้ร่วมกันอาจทำให้ไฟล์จากการแปลงหลาย ๆ งานทับกัน

## **ประสิทธิภาพและการจัดการทรัพยากร**

การแปลงเป็น HTML เป็นการดำเนินการเรนเดอร์ ดังนั้นเวลาในการประมวลผลและการใช้หน่วยความจำขึ้นอยู่กับจำนวนสไลด์ ความละเอียดของรูปภาพ ฟอนต์ เอฟเฟกต์ แผนภูมิ และสื่อที่ฝังอยู่ ค่า DPI ของ `PicturesCompression` ที่สูงขึ้น, ฟอนต์ที่ฝัง, ผลลัพธ์ SVG, และการเก็บส่วนที่ตัดของรูปภาพสามารถเพิ่มความแม่นยำได้แต่โดยทั่วไปทำให้ขนาดผลลัพธ์เพิ่มขึ้น

สำหรับการแปลงเป็นชุด:
- ทำการ dispose อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) ทุกตัวโดยเร็ว
- ใช้ไดเรกทอรีผลลัพธ์แยกกันสำหรับงานแยกต่างหาก
- หลีกเลี่ยงการฝังฟอนต์ทั่วไปเว้นแต่ความแม่นยำต้องการ
- ลด DPI ของรูปภาพเมื่อ HTML ใช้สำหรับพรีวิวหรือภาพย่อ
- เก็บงานนำเสนอต้นฉบับ, HTML ที่สร้าง, และทรัพยากรภายนอกไว้ด้วยกันจนกว่าจะกำหนดเส้นทางการปรับใช้ขั้นสุดท้าย

## **คำถามที่พบบ่อย**

**ลิงก์ไฮเปอร์เท็กซ์จะถูกเก็บไว้ในผลลัพธ์ HTML หรือไม่?**

ใช่. ลิงก์ไฮเปอร์เท็กซ์ของงานนำเสนอจะถูกส่งออกเป็น HTML และยังคงคลิกได้เมื่อ URL ปลายทางถูกต้อง

**ฉันสามารถแปลงงานนำเสนอเป็น HTML แบบขนานได้หรือไม่?**

ได้, แต่ห้ามใช้อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) เดียวกันข้ามเธรดต่าง ๆ ให้ประมวลผลไฟล์ที่แตกต่างกันด้วยอินสแตนซ์งานนำเสนอแยก, สตรีมแยก, และไดเรกทอรีผลลัพธ์แยก ดูคำแนะนำเกี่ยวกับ [multithreading guidance](/slides/th/net/multithreading/) สำหรับรายละเอียด

**อ็อบเจ็กต์ Presentation ปลอดภัยต่อการทำงานหลายเธรดหรือไม่?**

ไม่. อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) ควรโหลด, แก้ไข, บันทึก, และ dispose บนเธรดเดียว สำหรับงานขนานให้สร้างอินสแตนซ์อิสระต่อเธรดหรือกระบวนการ

**ทำไมไฟล์ HTML ที่สร้างขึ้นจึงมีขนาดใหญ่?**

การส่งออกค่าเริ่มต้นอาจฝังทรัพยากรโดยตรงใน HTML ฟอนต์ที่ฝัง, รูปภาพ DPI สูง, สื่อ, เนื้อหา SVG, และการเก็บส่วนที่ตัดของรูปภาพก็ทำให้ขนาดเพิ่ม ใช้ทรัพยากรภายนอก, ยกเว้นฟอนต์ทั่วไปจากการฝัง, และลด `PicturesCompression` เมื่อขนาดผลลัพธ์ที่เล็กกว่าสำคัญกว่าความแม่นยำสูงสุด

**ทำไมขนาดฟอนต์ PowerPoint เช่น 24 pt จึงแสดงเป็น 17.999819 pt ใน HTML?**

สิ่งนี้อาจเกิดจาก PowerPoint และ HTML ใช้โมเดล DPI ที่แตกต่างกัน PowerPoint เก็บขนาดข้อความเป็นจุดพิมพ์ตาม 72 DPI ขณะที่การจัดวาง HTML ใช้พิกเซล CSS ในโมเดล 96 DPI เมื่อ Aspose.Slides ส่งออกงานนำเสนอเป็น HTML ขนาดฟอนต์จะถูกแปลงระหว่างระบบเหล่านี้และการแปลงอาจทำให้เกิดความแตกต่างในการปัดเศษเล็กน้อย

ค่าต่าง ๆ เหล่านี้ไม่ได้บ่งบอกถึงการเปลี่ยนแปลงขนาดฟอนต์ที่มองเห็นจริง เพียงผลกระทบทางคณิตศาสตร์ของการแปลงเมตริกซ์ข้อความระหว่าง PowerPoint และ HTML

**ฉันควรเลือก baseUri สำหรับการส่งออกสื่ออย่างไร?**

เลือก `baseUri` จากมุมมองของเบราว์เซอร์และส่งเป็น URI สมบูรณ์ สำหรับพรีวิวแบบโลคัล คุณสามารถสร้างจากไดเรกทอรีผลลัพธ์ด้วย `new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri` สำหรับการปรับใช้ ให้ใช้ URL สมบูรณ์ของไดเรกทอรีสื่อที่เผยแพร่ พาธระบบไฟล์ `path` และ `baseUri` ของเบราว์เซอร์ไม่จำเป็นต้องเป็นสตริงเดียวกัน แต่ต้องอธิบายตำแหน่งทรัพยากรเดียวกัน

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ได้หรือไม่?**

ได้. ตั้งค่า `ShowHiddenSlides = true` บน [HtmlOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/htmloptions/) เมื่อต้องการส่งออกสไลด์ที่ซ่อนอยู่