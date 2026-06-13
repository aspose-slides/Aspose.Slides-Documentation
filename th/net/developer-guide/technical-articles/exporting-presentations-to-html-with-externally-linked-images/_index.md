---
title: ส่งออกงานนำเสนอเป็น HTML พร้อมรูปภาพที่เชื่อมโยงภายนอก
type: docs
weight: 100
url: /th/net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- ส่งออก PowerPoint
- ส่งออก OpenDocument
- ส่งออกงานนำเสนอ
- ส่งออกสไลด์
- ส่งออก PPT
- ส่งออก PPTX
- ส่งออก ODP
- PowerPoint เป็น HTML
- OpenDocument เป็น HTML
- งานนำเสนอเป็น HTML
- สไลด์เป็น HTML
- PPT เป็น HTML
- PPTX เป็น HTML
- ODP เป็น HTML
- รูปภาพที่เชื่อมโยง
- รูปภาพที่เชื่อมโยงภายนอก
- ทรัพยากรที่เชื่อมโยง
- ทรัพยากรภายนอก
- .NET
- C#
- Aspose.Slides
description: "ส่งออกงานนำเสนอ PowerPoint และ OpenDocument ไปเป็น HTML บน .NET โดยใช้ Aspose.Slides พร้อมภาพและทรัพยากรอื่น ๆ ที่บันทึกเป็นไฟล์ที่เชื่อมโยงภายนอก"
---
## **ภาพรวม**

โดยค่าเริ่มต้น Aspose.Slides จะส่งออกงานนำเสนอเป็นไฟล์ HTML ที่เป็นอิสระโดยรวม ภาพและทรัพยากรอื่น ๆ จะถูกเขียนโดยตรงลงใน HTML ส่วนมากเป็นข้อมูล Base64 สิ่งนี้สะดวกเมื่อคุณต้องการไฟล์พกพาเพียงไฟล์เดียว แต่ไม่จำเป็นต้องเป็นรูปแบบที่ดีที่สุดสำหรับเว็บไซต์, CMS หรือกระบวนการแปลงฝั่งเซิร์ฟเวอร์

ใช้ทรัพยากรที่เชื่อมโยงภายนอกเมื่อคุณต้องการ:

- ลดขนาดของเอกสาร HTML;
- แคชภาพ, ฟอนต์, เสียง หรือวิดีโอแยกต่างหากในเบราว์เซอร์หรือ CDN;
- ตรวจสอบ, แทนที่, บีบอัด หรือประมวลผลต่อทรัพยากรที่สร้างขึ้นหลังการส่งออก;
- ทำให้โครงสร้างผลลัพธ์ใกล้เคียงกับที่แอปพลิเคชันเว็บคาดหวัง

สำหรับกระบวนการแปลง HTML ทั่วไป, ดูที่[Convert PowerPoint Presentations to HTML](/slides/th/net/convert-powerpoint-to-html/) . บทความนี้มุ่งเน้นไปที่ส่วนการเชื่อมโยงทรัพยากรของการส่งออก

## **วิธีการทำงานของการส่งออกทรัพยากรที่เชื่อมโยง**

[ILinkEmbedController](https://reference.aspose.com/slides/th/net/aspose.slides.export/ilinkembedcontroller/) ให้แอปพลิเคชันของคุณตัดสินใจ, ทรัพยากรต่อทรัพยากร, ว่าตัวส่งออกจะแทรกข้อมูลลงใน HTML หรือบันทึกเป็นไฟล์ภายนอกและเขียนลิงก์

อินเทอร์เฟซมีสามเมธอด:

- [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/th/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) ตัดสินว่าทรัพยากรควรเชื่อมโยงหรือฝังไว้
- [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/th/net/aspose.slides.export/ilinkembedcontroller/geturl/) คืนค่า URL ที่จะเขียนลงใน HTML ที่สร้างหรือในทรัพยากรที่เชื่อมโยงอื่น
- [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/th/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) เขียนข้อมูลทรัพยากรที่เชื่อมโยงลงดิสก์หรือเป้าหมายการจัดเก็บอื่น

เส้นทางระบบไฟล์และ URL ของเบราว์เซอร์เป็นเรื่องแยกกัน ตัวอย่างเช่น ตัวอย่างด้านล่างเขียนไฟล์ทรัพยากรไปยัง `html-output/assets` บนดิสก์ ขณะที่ HTML มี URL แบบสัมพันธ์เช่น `assets/resource-1.svg` เบราว์เซอร์จะแก้ URL เหล่านี้สัมพันธ์กับไฟล์ที่มีลิงก์ ดังนั้นลิงก์จาก `presentation.html` ไปยังไฟล์ SVG จะใช้ `assets/resource-1.svg` ส่วนลิงก์จากไฟล์ SVG นั้นไปยังภาพที่บันทึกในโฟลเดอร์ `assets` เดียวกันจะใช้ `resource-4.jpg`

## **ส่งออก HTML พร้อมทรัพยากรที่เชื่อมโยง**

ตัวอย่าง C# ด้านล่างสร้างไดเรกทอรีผลลัพธ์, บันทึกไฟล์ HTML ไว้ที่นั่น, และจัดเก็บทรัพยากรที่เชื่อมโยงในโฟลเดอร์ย่อย `assets` ตัวควบคุมจะเชื่อมโยงรูปภาพ, ฟอนต์, เสียง, วิดีโอ, และทรัพยากร CSS ทั่วไปเมื่อ Aspose.Slides มีหรือสามารถสรุปส่วนขยายไฟล์ที่ปลอดภัยได้ ทรัพยากรที่ไม่รู้จักจะยังคงฝังอยู่

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using System;
using System.Collections.Generic;
using System.IO;

var inputFilePath = "presentation.pptx";
var outputDirectory = "html-output";
var assetDirectoryName = "assets";
var assetDirectory = Path.Combine(outputDirectory, assetDirectoryName);

Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(assetDirectory);

var assetUrlPrefix = assetDirectoryName + "/";
var controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = HtmlFormatter.CreateDocumentFormatter(string.Empty, false),
    SlideImageFormat = slideImageFormat
};

using var presentation = new Presentation(inputFilePath);

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);

public sealed class ExternalResourceController : ILinkEmbedController
{
    private static readonly Dictionary<string, string> ExtensionsByContentType = new(StringComparer.OrdinalIgnoreCase)
    {
        ["image/jpeg"] = ".jpg",
        ["image/png"] = ".png",
        ["image/gif"] = ".gif",
        ["image/bmp"] = ".bmp",
        ["image/svg+xml"] = ".svg",
        ["image/tiff"] = ".tiff",
        ["image/x-emf"] = ".emf",
        ["image/x-wmf"] = ".wmf",
        ["font/woff"] = ".woff",
        ["font/woff2"] = ".woff2",
        ["font/ttf"] = ".ttf",
        ["application/font-woff"] = ".woff",
        ["application/vnd.ms-fontobject"] = ".eot",
        ["application/x-font-ttf"] = ".ttf",
        ["text/css"] = ".css",
        ["audio/mpeg"] = ".mp3",
        ["audio/mp4"] = ".m4a",
        ["audio/wav"] = ".wav",
        ["video/mp4"] = ".mp4",
        ["video/webm"] = ".webm"
    };

    private readonly string assetDirectory;
    private readonly string assetUrlPrefix;
    private readonly Dictionary<int, string> fileNamesByResourceId = new();

    public ExternalResourceController(string assetDirectory, string assetUrlPrefix)
    {
        if (string.IsNullOrWhiteSpace(assetDirectory))
        {
            throw new ArgumentException("The asset output directory must not be empty.", nameof(assetDirectory));
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = NormalizeUrlPrefix(assetUrlPrefix);
    }

    public LinkEmbedDecision GetObjectStoringLocation(
        int resourceId,
        byte[] entityData,
        string semanticName,
        string contentType,
        string recommendedExtension)
    {
        var extension = ResolveExtension(contentType, recommendedExtension);
        if (extension == null)
        {
            return LinkEmbedDecision.Embed;
        }

        fileNamesByResourceId[resourceId] = $"resource-{resourceId}{extension}";
        return LinkEmbedDecision.Link;
    }

    public string GetUrl(int resourceId, int referrer)
    {
        if (!fileNamesByResourceId.TryGetValue(resourceId, out var fileName))
        {
            return null;
        }

        if (fileNamesByResourceId.ContainsKey(referrer))
        {
            return fileName;
        }

        return assetUrlPrefix + fileName;
    }

    public void SaveExternal(int resourceId, byte[] entityData)
    {
        if (!fileNamesByResourceId.TryGetValue(resourceId, out var fileName))
        {
            throw new InvalidOperationException(
                $"Resource {resourceId} was not registered for external storage.");
        }

        if (entityData == null || entityData.Length == 0)
        {
            throw new InvalidOperationException(
                $"Resource {resourceId} contains no data and cannot be saved.");
        }

        Directory.CreateDirectory(assetDirectory);

        var filePath = Path.Combine(assetDirectory, fileName);
        File.WriteAllBytes(filePath, entityData);
    }

    private static string ResolveExtension(string contentType, string recommendedExtension)
    {
        if (!string.IsNullOrWhiteSpace(contentType) &&
            ExtensionsByContentType.TryGetValue(contentType, out var mappedExtension))
        {
            return mappedExtension;
        }

        if (!IsSupportedContentType(contentType))
        {
            return null;
        }

        return NormalizeExtension(recommendedExtension);
    }

    private static bool IsSupportedContentType(string contentType)
    {
        return contentType != null &&
            (contentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("font/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("audio/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("video/", StringComparison.OrdinalIgnoreCase));
    }

    private static string NormalizeExtension(string extension)
    {
        if (string.IsNullOrWhiteSpace(extension))
        {
            return null;
        }

        var extensionCharacters = extension.Trim().TrimStart('.');
        foreach (var character in extensionCharacters)
        {
            if (!char.IsLetterOrDigit(character))
            {
                return null;
            }
        }

        return "." + extensionCharacters.ToLowerInvariant();
    }

    private static string NormalizeUrlPrefix(string urlPrefix)
    {
        if (string.IsNullOrEmpty(urlPrefix))
        {
            return string.Empty;
        }

        var normalizedUrlPrefix = urlPrefix.Replace('\\', '/');
        return normalizedUrlPrefix.EndsWith("/")
            ? normalizedUrlPrefix
            : normalizedUrlPrefix + "/";
    }
}
```

หลังการส่งออก โฟลเดอร์ผลลัพธ์จะมีโครงสร้างดังนี้:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

ไฟล์ที่แน่นอนขึ้นอยู่กับเนื้อหาของงานนำเสนอและตัวเลือกการส่งออก ตัวอย่างเช่น ภาพแบบเรสเตอร์มักจะส่งออกเป็น JPEG หรือ PNG Aspose.Slides อาจเลือกโค้ดภาพที่แตกต่างจากที่ใช้ในงานนำเสนอเดิมเมื่อทำให้ไฟล์มีขนาดเล็กลงหรือเหมาะสมกว่า ภาพที่มีความโปร่งใสจะส่งออกเป็น PNG

## **การเลือก URL สำหรับการปรับใช้**

ตัวอย่างใช้คำนำหน้า URL แบบสัมพันธ์: `assets/` หากเปิด `presentation.html` จาก `html-output/presentation.html` เบราว์เซอร์จะโหลด `html-output/assets/resource-1.svg`

เมื่อทรัพยากรที่เชื่อมโยงหนึ่งอ้างอิงถึงอีกทรัพยากรที่เชื่อมโยง, ตัวอย่างใช้พารามิเตอร์ `referrer` ใน [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/th/net/aspose.slides.export/ilinkembedcontroller/geturl/) และคืนเฉพาะชื่อไฟล์ ตัวอย่างเช่น หาก `resource-1.svg` และ `resource-4.jpg` อยู่ในโฟลเดอร์ `assets` ไฟล์ SVG ควรอ้างถึง `resource-4.jpg` ไม่ใช่ `assets/resource-4.jpg`

ใช้คำนำหน้า URL ที่แตกต่างเมื่อไฟล์ถูกปรับใช้ในตำแหน่งอื่น:

- ใช้ `assets/` เมื่อไดเรกทอรีทรัพยากรอยู่ถัดจากไฟล์ HTML
- ใช้ `../assets/` เมื่อไดเรกทอรีทรัพยากรอยู่ระดับหนึ่งเหนือไฟล์ HTML
- ใช้ `https://cdn.example.com/presentations/job-123/assets/` เมื่อไฟล์ถูกอัปโหลดไปยัง CDN หรือเซิร์ฟเวอร์ไฟล์สถิต

URL ที่คืนโดย [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/th/net/aspose.slides.export/ilinkembedcontroller/geturl/) ต้องตรงกับตำแหน่งการปรับใช้สุดท้ายของไฟล์ที่เขียนโดย [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/th/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) ในแอปพลิเคชันเซิร์ฟเวอร์, ใช้ไดเรกทอรีผลลัพธ์หรือคำนำหน้าการจัดเก็บแบบยูนีคสำหรับแต่ละงานแปลงเพื่อหลีกเลี่ยงการเขียนทับไฟล์จากการส่งออกอื่น

## **เมื่อใดควรฝังแทนที่จะแยกไฟล์**

HTML ที่ฝังข้อมูล Base64 ยังคงมีประโยชน์เมื่อผลลัพธ์ต้องเป็นไฟล์เดียว เช่น แนบไปกับอีเมล, ตัวอย่างออฟไลน์, หรือเอกสารที่ต้องย้ายโดยไม่มีโฟลเดอร์ทรัพยากรสนับสนุน ทรัพยากรที่เชื่อมโยงเหมาะกว่าเมื่อ HTML จะให้บริการโดยแอปพลิเคชันเว็บ, จัดเก็บใน CMS, ปรับแต่งโดย pipeline การสร้าง, หรือแคชโดยเบราว์เซอร์แยกจาก HTML

## **FAQ**

**ฉันสามารถแยกเฉพาะภาพและให้ทรัพยากรอื่นฝังอยู่ได้หรือไม่?**

ใช่ ใน [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/th/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) ให้คืนค่า `LinkEmbedDecision.Link` เฉพาะสำหรับชนิดเนื้อหาที่คุณต้องการบันทึกเป็นไฟล์แยก, และคืนค่า `LinkEmbedDecision.Embed` สำหรับส่วนอื่นทั้งหมด

**ทำไมส่วนขยายของภาพที่ส่งออกจึงแตกต่างจากงานนำเสนอที่เป็นแหล่งที่มา?**

Aspose.Slides อาจทำการเข้ารหัสใหม่ของภาพแบบเรสเตอร์ระหว่างการส่งออก HTML เพื่อปรับขนาดหรือความเข้ากันได้กับเบราว์เซอร์ ตัวอย่างเช่น ภาพจากไฟล์ต้นฉบับอาจถูกเขียนเป็น JPEG หรือ PNG ขึ้นอยู่กับผลลัพธ์ที่เรนเดอร์

**URL แบบสัมพันธ์ทำงานได้หรือไม่หลังจากที่ย้ายไฟล์ HTML?**

URL แบบสัมพันธ์ทำงานได้เฉพาะเมื่อโครงสร้างโฟลเดอร์เชิงสัมพันธ์เดียวกันถูกคงไว้ หาก HTML อ้างถึง `assets/resource-1.png` โฟลเดอร์ `assets` ต้องอยู่ข้างๆไฟล์ HTML เว้นแต่คุณจะสร้างคำนำหน้า URL ที่แตกต่าง

**แอปพลิเคชันเซิร์ฟเวอร์ควรใช้โฟลเดอร์ผลลัพธ์เดียวกันซ้ำหรือไม่?**

ไม่ ควรใช้ไดเรกทอรีผลลัพธ์หรือคำนำหน้าการจัดเก็บแบบยูนีคสำหรับแต่ละงานแปลง เพื่อหลีกเลี่ยงการชนกันของชื่อไฟล์และป้องกันการเขียนทับทรัพยากรที่สร้างโดยการส่งออกอื่น```