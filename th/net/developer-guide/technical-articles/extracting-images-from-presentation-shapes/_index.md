---
title: สกัดรูปภาพจากรูปร่างในงานนำเสนอด้วย .NET
linktitle: รูปจากรูปร่าง
type: docs
weight: 90
url: /th/net/extracting-images-from-presentation-shapes/
keywords:
- สกัดรูปภาพ
- ดึงรูปภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สกัดรูปภาพจากรูปร่างในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ .NET - วิธีแก้ไขที่รวดเร็วและเป็นมิตรต่อโค้ด."
---
## **ภาพรวม**

รูปภาพในงานนำเสนออาจปรากฏในหลายประเภทของรูปร่าง: เป็นกรอบรูปธรรมดา, เป็นพื้นหลังรูปที่ใส่ในรูปร่าง, เป็นภาพตัวอย่างของวัตถุ OLE, เป็นภาพย่อของเฟรมวิดีโอหรือเสียง, เป็นรูปซูม, หรือเป็นรูปที่ฝังอยู่ภายในรูปร่างตาราง, แผนภูมิและ SmartArt. Aspose.Slides จัดเก็บรูปเหล่านี้ในคอลเลกชันรูปของงานนำเสนอ ซึ่งเปิดให้เข้าถึงผ่านอ็อบเจกต์ [ImageCollection](https://reference.aspose.com/slides/th/net/aspose.slides/imagecollection/) และ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/).

หากคุณต้องการส่งออกทรัพยากรรูปภาพทุกไฟล์ที่ฝังอยู่ในงานนำเสนอ ให้วนลูปผ่าน `presentation.Images`. บทความนี้เน้นงานที่ต่างออกไป: การท่องรูปร่างเพื่อค้นหาที่ที่รูปภาพถูกใช้บนสไลด์ เพื่อตั้งชื่อไฟล์ที่บันทึกให้มีข้อมูลบริบทที่เป็นประโยชน์ เช่น หมายเลขสไลด์, ตำแหน่งรูปร่าง และประเภทแหล่งที่ม (กรอบรูป, รูปพื้นหลัง, ตัวอย่างสื่อ, ตัวอย่าง OLE หรือรูปซูม).

{{% alert title="Tip" color="primary" %}}
ใช้ [IPPImage.BinaryData](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) เพื่อรักษาข้อมูลรูปที่เข้ารหัสเดิมและประเภทไฟล์เดิม ใช้ [IPPImage.Image](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) ร่วมกับ [IImage.Save](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) เมื่อคุณต้องการแปลงผลลัพธ์เป็นรูปแบบเฉพาะเช่น PNG.
{{% /alert %}}

## **เมธอดช่วยเหลือที่ใช้ร่วมกัน**

เมธอดช่วยเหลือด้านล่างทำให้ตัวอย่างสั้นลง `SaveOriginalImage` จะเขียนไบต์ที่ฝังอยู่เดิม, เลือกสกุลไฟล์ที่ปลอดภัยจาก MIME type, และข้ามรูปภาพซ้ำโดยใช้แฮช SHA-256.

```c#
using Aspose.Slides;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

private static bool SaveOriginalImage(
    IPPImage image,
    string outputDirectory,
    string fileNameBase,
    ISet<string> savedImageHashes)
{
    byte[] imageData = image.BinaryData;
    string imageHash = GetSha256Hash(imageData);
    if (!savedImageHashes.Add(imageHash))
    {
        return false;
    }

    string extension = GetExtensionFromContentType(image.ContentType);
    string fileName = $"{fileNameBase}.{extension}";
    string outputPath = Path.Combine(outputDirectory, fileName);
    File.WriteAllBytes(outputPath, imageData);
    return true;
}

private static void SaveImageAsPng(IPPImage image, string outputDirectory, string fileNameBase)
{
    string fileName = $"{fileNameBase}.png";
    string outputPath = Path.Combine(outputDirectory, fileName);

    using (IImage outputImage = image.Image)
    {
        outputImage.Save(outputPath, ImageFormat.Png);
    }
}

private static IPPImage GetPictureFillImage(IFillFormat fillFormat)
{
    if (fillFormat == null || fillFormat.FillType != FillType.Picture)
    {
        return null;
    }

    return fillFormat.PictureFillFormat.Picture.Image;
}

private static IEnumerable<(IShape Shape, string NamePart)> EnumerateShapes(
    IShapeCollection shapes,
    string prefix,
    bool includeGroupedShapes)
{
    int shapeCount = shapes.Count;
    for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        IShape shape = shapes[shapeIndex];
        int displayIndex = shapeIndex + 1;
        string shapeNamePart = $"{prefix}_shape_{displayIndex}";
        yield return (shape, shapeNamePart);

        if (includeGroupedShapes && shape is IGroupShape groupShape)
        {
            foreach ((IShape Shape, string NamePart) childShape in EnumerateShapes(
                groupShape.Shapes,
                shapeNamePart,
                includeGroupedShapes))
            {
                yield return childShape;
            }
        }
    }
}

private static string GetSha256Hash(byte[] data)
{
    using (SHA256 sha256 = SHA256.Create())
    {
        byte[] hash = sha256.ComputeHash(data);
        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
    }
}

private static string GetExtensionFromContentType(string contentType)
{
    if (string.IsNullOrWhiteSpace(contentType))
    {
        return "bin";
    }

    string mediaType = contentType.Split(';')[0].Trim().ToLowerInvariant();
    switch (mediaType)
    {
        case "image/jpeg":
            return "jpg";
        case "image/png":
            return "png";
        case "image/gif":
            return "gif";
        case "image/bmp":
            return "bmp";
        case "image/tiff":
            return "tiff";
        case "image/x-emf":
        case "image/emf":
            return "emf";
        case "image/x-wmf":
        case "image/wmf":
            return "wmf";
        case "image/svg+xml":
            return "svg";
        default:
            if (mediaType.StartsWith("image/"))
            {
                string extension = mediaType.Substring("image/".Length);
                return MakeSafeFileNamePart(extension);
            }

            return "bin";
    }
}

private static string MakeSafeFileNamePart(string value)
{
    foreach (char invalidCharacter in Path.GetInvalidFileNameChars())
    {
        value = value.Replace(invalidCharacter, '_');
    }

    return value;
}
```

## **สกัดรูปภาพจากกรอบรูป**

ใช้วิธีนี้สำหรับรูปที่แทรกเป็นอ็อบเจกต์อิสระ. [IPictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ipictureframe/) เก็บรูปภาพใน `PictureFormat.Picture.Image`, ซึ่งคืนค่าอ็อบเจกต์ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/).

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "extracted-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IPictureFrame pictureFrame)
            {
                IPPImage image = pictureFrame.PictureFormat.Picture.Image;
                SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
            }
        }
    }
}
```

## **สกัดรูปภาพจากรูปร่างที่เติมรูป**

รูปร่างสามารถใช้รูปเป็นพื้นหลังได้. ตรวจสอบประเภทการเติมของรูปร่างก่อน: หากไม่ใช่ [FillType.Picture](https://reference.aspose.com/slides/th/net/aspose.slides/filltype/), จะไม่มีรูปให้สกัดจากการเติมนั้น. ตัวอย่างด้านล่างจัดการอ็อบเจกต์ [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) และบันทึกรูปแต่ละไฟล์เป็น PNG ผ่าน [IPPImage.Image](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/).

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "shape-fill-images");
Directory.CreateDirectory(outputDirectory);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IAutoShape autoShape)
            {
                IPPImage image = GetPictureFillImage(autoShape.FillFormat);
                if (image != null)
                {
                    SaveImageAsPng(image, outputDirectory, item.NamePart);
                }
            }
        }
    }
}
```

## **สกัดรูปภาพตัวอย่างจากกรอบวัตถุ OLE**

[IOleObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ioleobjectframe/) สามารถมีรูปทดแทนที่ PowerPoint ใช้เป็นตัวอย่างของวัตถุบนสไลด์. รูปนี้สามารถเข้าถึงได้ผ่าน `SubstitutePictureFormat.Picture.Image`. การสกัดรูปนี้จะให้ได้รูปตัวอย่าง, ไม่ใช่เนื้อหาแพ็คเกจ OLE ที่ฝังอยู่.

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "ole-preview-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IOleObjectFrame oleObjectFrame)
            {
                IPPImage image = oleObjectFrame.SubstitutePictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_ole_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **สกัดรูปภาพตัวอย่างจากกรอบวิดีโอ**

[IVideoFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/) สามารถเก็บรูปตัวอย่างใน `PictureFormat.Picture.Image`. นี่คือโปสเตอร์หรือภาพย่อที่แสดงบนสไลด์, ไม่ใช่เฟรมที่ถอดรหัสจากสตรีมวิดีโอ.

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "video-preview-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IVideoFrame videoFrame)
            {
                IPPImage image = videoFrame.PictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_video_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **สกัดรูปภาพตัวอย่างจากกรอบเสียง**

[IAudioFrame](https://reference.aspose.com/slides/th/net/aspose.slides/iaudioframe/) สามารถเก็บภาพย่อใน `PictureFormat.Picture.Image`. นี่คือรูปที่แสดงสำหรับวัตถุเสียงบนสไลด์.

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "audio-preview-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IAudioFrame audioFrame)
            {
                IPPImage image = audioFrame.PictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_audio_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **สกัดรูปภาพจากวัตถุซูม**

รูปร่าง [IZoomFrame](https://reference.aspose.com/slides/th/net/aspose.slides/izoomframe/) และ [ISectionZoomFrame](https://reference.aspose.com/slides/th/net/aspose.slides/isectionzoomframe/) สามารถใช้รูปภาพกำหนดเอง. อ่าน `ZoomImage` จากเฟรมซูม.

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "zoom-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IZoomFrame zoomFrame && zoomFrame.ZoomImage != null)
            {
                string fileNameBase = $"{item.NamePart}_zoom";
                SaveOriginalImage(zoomFrame.ZoomImage, outputDirectory, fileNameBase, savedImageHashes);
                continue;
            }

            if (item.Shape is ISectionZoomFrame sectionZoomFrame && sectionZoomFrame.ZoomImage != null)
            {
                string fileNameBase = $"{item.NamePart}_section_zoom";
                SaveOriginalImage(sectionZoomFrame.ZoomImage, outputDirectory, fileNameBase, savedImageHashes);
                continue;
            }

        }
    }
}
```

## **สกัดรูปภาพจากกรอบซูมสรุป**

[ISummaryZoomFrame](https://reference.aspose.com/slides/th/net/aspose.slides/isummaryzoomframe/) ก็เป็นรูปร่างเช่นกัน. รายการส่วนสรุปของมันอาจใช้รูปภาพกำหนดเอง, ซึ่งเปิดให้เข้าถึงผ่านคุณสมบัติ `ZoomImage` ของแต่ละส่วนสรุป.

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "summary-zoom-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is ISummaryZoomFrame summaryZoomFrame)
            {
                int sectionCount = summaryZoomFrame.SummaryZoomCollection.Count;
                for (int sectionIndex = 0; sectionIndex < sectionCount; sectionIndex++)
                {
                    ISummaryZoomSection section = summaryZoomFrame.SummaryZoomCollection[sectionIndex];
                    if (section.ZoomImage != null)
                    {
                        int displayIndex = sectionIndex + 1;
                        string fileNameBase = $"{item.NamePart}_summary_zoom_{displayIndex}";
                        SaveOriginalImage(section.ZoomImage, outputDirectory, fileNameBase, savedImageHashes);
                    }
                }
            }
        }
    }
}
```

## **สกัดรูปภาพจากรูปร่างตาราง**

[ITable](https://reference.aspose.com/slides/th/net/aspose.slides/itable/) เป็นรูปร่าง. รูปภาพในตารางมักจะถูกเก็บเป็นพื้นหลังรูปในเซลล์ของตาราง.

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "table-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: true))
        {
            if (item.Shape is ITable table)
            {
                int rowCount = table.Rows.Count;
                int columnCount = table.Columns.Count;
                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                    {
                        ICell cell = table[columnIndex, rowIndex];
                        IPPImage image = GetPictureFillImage(cell.CellFormat.FillFormat);
                        if (image != null)
                        {
                            string fileNameBase = $"{item.NamePart}_cell_{rowIndex + 1}_{columnIndex + 1}";
                            SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }
}
```

## **สกัดรูปภาพจากรูปร่างแผนภูมิ**

[IChart](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichart/) เป็นรูปร่าง. ตัวอย่างด้านล่างสกัดรูปภาพจากพื้นหลังรูปของพื้นที่แผนภูมิ.

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "chart-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: true))
        {
            if (item.Shape is Aspose.Slides.Charts.IChart chart)
            {
                IFillFormat fillFormat = chart.FillFormat;
                IPPImage image = GetPictureFillImage(fillFormat);
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_chart_area";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **สกัดรูปภาพจากรูปร่าง SmartArt**

[ISmartArt](https://reference.aspose.com/slides/th/net/aspose.slides.smartart/ismartart/) เป็นอ็อบเจกต์รูปร่าง. ขึ้นอยู่กับเค้าโครง SmartArt, รูปภาพอาจถูกเก็บในพื้นหลังรูปของจุดรายการ (node bullet) หรือในรูปแบบการเติมของรูปร่างจุด.

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "smartart-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: true))
        {
            if (item.Shape is Aspose.Slides.SmartArt.ISmartArt smartArt)
            {
                int nodeCount = smartArt.AllNodes.Count;
                for (int nodeIndex = 0; nodeIndex < nodeCount; nodeIndex++)
                {
                    Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes[nodeIndex];
                    IPPImage bulletImage = GetPictureFillImage(node.BulletFillFormat);
                    if (bulletImage != null)
                    {
                        string fileNameBase = $"{item.NamePart}_smartart_node_{nodeIndex + 1}_bullet";
                        SaveOriginalImage(bulletImage, outputDirectory, fileNameBase, savedImageHashes);
                    }

                    int nodeShapeCount = node.Shapes.Count;
                    for (int nodeShapeIndex = 0; nodeShapeIndex < nodeShapeCount; nodeShapeIndex++)
                    {
                        var nodeShape = node.Shapes[nodeShapeIndex];
                        IPPImage image = GetPictureFillImage(nodeShape.FillFormat);
                        if (image != null)
                        {
                            string fileNameBase = $"{item.NamePart}_smartart_node_{nodeIndex + 1}_shape_{nodeShapeIndex + 1}";
                            SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }
}
```

## **รวมรูปภาพที่อยู่ภายในรูปร่างกลุ่ม**

รูปร่างกลุ่มมีคอลเลกชันรูปร่างของตนเอง. ตัวช่วย `EnumerateShapes` ที่ใช้ร่วมกันมีตัวเลือก `includeGroupedShapes`. ตั้งค่าเป็น `true` เมื่อคุณต้องการตรวจสอบรูปร่างภายในอ็อบเจกต์ [IGroupShape](https://reference.aspose.com/slides/th/net/aspose.slides/igroupshape/). ตัวอย่างด้านล่างสกัดรูปภาพจากกรอบรูป, รูปที่เติมในรูปร่าง, ตัวอย่าง OLE, ภาพย่อเฟรมวิดีโอ, และภาพย่อเฟรมเสียง. เพื่อรวมรูปภาพตาราง, แผนภูมิ, SmartArt, และรูปซูมสรุปด้วย, ให้ใช้ตรรกะการสกัดเฉพาะจากส่วนก่อนหน้าโดยยังคงการท่องรูปร่างแบบเรียกซ้ำเหมือนเดิม.

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "all-shape-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: true))
        {
            if (item.Shape is IPictureFrame pictureFrame)
            {
                IPPImage image = pictureFrame.PictureFormat.Picture.Image;
                SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
                continue;
            }

            if (item.Shape is IAutoShape autoShape)
            {
                IPPImage image = GetPictureFillImage(autoShape.FillFormat);
                if (image != null)
                {
                    SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
                }

                continue;
            }

            if (item.Shape is IOleObjectFrame oleObjectFrame)
            {
                IPPImage image = oleObjectFrame.SubstitutePictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_ole_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (item.Shape is IVideoFrame videoFrame)
            {
                IPPImage image = videoFrame.PictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_video_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (item.Shape is IAudioFrame audioFrame)
            {
                IPPImage image = audioFrame.PictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_audio_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **กรณีขอบเขตและบันทึกปฏิบัติ**

- **รูปภาพซ้ำ:** รูปร่างหลายรูปร่างอาจอ้างอิงรูปเดียวกันหรือรูปแยกต่างหากที่มีไบต์เท่ากัน. ทำแฮช [IPPImage.BinaryData](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) ก่อนเขียนไฟล์หากคุณต้องการไฟล์ผลลัพธ์หนึ่งไฟล์ต่อรูปภาพที่ไม่ซ้ำ.
- **ข้อมูลดั้งเดิม vs. ผลลัพธ์แปลง:** การบันทึก [IPPImage.BinaryData](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) จะคงข้อมูล JPEG, PNG, GIF, SVG, EMF หรือ WMF ที่ฝังอยู่. การบันทึก [IPPImage.Image](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) ผ่าน [IImage.Save](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) มีประโยชน์เมื่อคุณต้องการรูปแบบผลลัพธ์ที่สม่ำเสมอ.
- **ประเภทการเติมที่ไม่รองรับ:** รูปร่างที่เติมสีทึบ, ไล่สี, ลวดลาย หรือไม่มีการเติมจะไม่บรรจุรูปภาพ. ตรวจสอบ [FillType](https://reference.aspose.com/slides/th/net/aspose.slides/filltype/) ก่อนอ่าน `PictureFillFormat`.
- **รูปร่างกลุ่ม:** คอลเลกชันรูปร่างระดับบนของสไลด์ไม่ทำให้กลุ่มแบน. ตรวจสอบอย่างเรียกซ้ำ [IGroupShape.Shapes](https://reference.aspose.com/slides/th/net/aspose.slides/igroupshape/) เมื่อเนื้อหากลุ่มมีความสำคัญ.
- **ตัวอย่างวัตถุ OLE:** [IOleObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ioleobjectframe/) อาจเปิดเผยภาพตัวอย่างผ่าน `SubstitutePictureFormat`, แต่ภาพนั้นเป็นเพียงตัวอย่างบนสไลด์ ไม่ได้เป็นไฟล์ที่ฝังอยู่ภายในวัตถุ OLE.
- **ภาพย่อเฟรมวิดีโอ:** [IVideoFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/) อาจเปิดเผยภาพตัวอย่างผ่าน `PictureFormat`, แต่ภาพนั้นเป็นเพียงโปสเตอร์ที่แสดงบนสไลด์ ไม่ได้สกัดจากสตรีมวิดีโอ.
- **ภาพย่อเฟรมเสียง:** [IAudioFrame](https://reference.aspose.com/slides/th/net/aspose.slides/iaudioframe/) อาจเปิดเผยไอคอนหรือภาพย่อผ่าน `PictureFormat`; ไม่ได้เป็นข้อมูลเสียงที่ฝังอยู่.
- **รูปภาพซูม:** รูปร่างซูมสไลด์, ซูมส่วน, และซูมสรุปอาจใช้ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) กำหนดเองผ่าน `ZoomImage`.
- **โมเดลรูปร่างซ้อนกัน:** วัตถุตาราง, แผนภูมิ, และ SmartArt ทำตาม [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/), แต่รูปภาพมักถูกเก็บในวัตถุการจัดรูปแบบของเซลล์ตาราง, ส่วนของแผนภูมิ, หรือโหนด SmartArt ที่ซ้อนกัน.
- **รูปภาพที่ถูกครอปหรือแปลง:** การเข้าถึง [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) จะให้ทรัพยากรรูปที่เก็บไว้. มันจะไม่แสดงการครอป, ความโปร่งใส, การเปลี่ยนสี, การหมุน หรือเอฟเฟ็กต์ภาพอื่น ๆ ที่รูปแบบของรูปร่างกำหนด.

## **คำถามที่พบบ่อย**

**ฉันสามารถสกัดรูปภาพดั้งเดิมโดยไม่ครอป, ไม่ใช้เอฟเฟ็กต์, หรือไม่แปลงรูปร่างได้หรือไม่?**  

ใช่. เข้าถึงอ็อบเจกต์ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) และเขียน [IPPImage.BinaryData](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) ลงดิสก์. วิธีนี้จะคงรูปที่ถูกเข้ารหัสเดิมที่เก็บในงานนำเสนอ, ไม่ใช่วิธีที่รูปแสดงบนสไลด์.

**ฉันสามารถส่งออกทุกรูปที่สกัดเป็น PNG ได้หรือไม่?**  

ใช่. ใช้ [IPPImage.Image](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) เพื่อรับอ็อบเจกต์ [IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/), แล้วเรียก [IImage.Save](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) พร้อม [ImageFormat.Png](https://reference.aspose.com/slides/th/net/aspose.slides/imageformat/). วิธีนี้จะเปลี่ยนรูปเป็น PNG และอาจไม่ได้รักษาประเภทไฟล์หรือข้อมูลเวกเตอร์เดิม.

**ฉันจะหลีกเลี่ยงการบันทึกรูปเดียวกันหลายครั้งได้อย่างไร?**  

ใช้แฮชของ [IPPImage.BinaryData](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) และเก็บแฮชไว้ในเซ็ต. หากรูปใหม่มีแฮชที่มีอยู่แล้ว, ให้ข้ามหรือบันทึกการอ้างอิงอื่นไปยังไฟล์ผลลัพธ์ที่มีอยู่.

**ทำไมบางรูปร่างถึงไม่สร้างรูปภาพ?**  

กรอบรูป, รูปที่เติมในรูปร่าง, กรอบวัตถุ OLE, กรอบสื่อ, กรอบซูม, ตาราง, แผนภูมิ, และอ็อบเจกต์ SmartArt สามารถอ้างอิงรูปภาพได้. บางประเภทรูปร่างเปิดเผยรูปผ่านวัตถุการจัดรูปแบบที่ซ้อนกัน, ดังนั้นการตรวจสอบเพียง `PictureFormat` หรือ `FillFormat` ของรูปร่างอาจไม่เพียงพอ.

**ฉันสามารถสกัดภาพย่อที่แสดงสำหรับเฟรมวิดีโอได้หรือไม่?**  

ใช่. ใช้ [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/) แล้วอ่าน `PictureFormat.Picture.Image`. วิธีนี้จะสกัดภาพโปสเตอร์ที่เก็บกับเฟรมวิดีโอ, ไม่ใช่เฟรมที่สร้างจากไฟล์วิดีโอ.

**ฉันจะกำหนดได้อย่างไรว่ารูปร่างใดใช้รูปภาพเฉพาะจากคอลเลกชันรูปของงานนำเสนอ?**  

Aspose.Slides ไม่เก็บลิงก์ย้อนกลับจาก [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) ไปยังรูปร่าง. ให้สร้างแมพปิ้งในระหว่างการท่อง: เมื่อพบการอ้างอิงรูป, ให้บันทึกหมายเลขสไลด์, เส้นทางรูปร่าง, และแฮชหรือดัชนีของรูปในคอลเลกชัน.

**ฉันสามารถสกัดรูปภาพที่ฝังอยู่ในวัตถุ OLE, เช่น เอกสารแนบ, ได้หรือไม่?**  

คุณสามารถสกัดตัวอย่างสไลด์ของวัตถุ OLE จาก [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ioleobjectframe/). อย่างไรก็ตาม ตัวอย่างนั้นไม่ใช่เอกสารที่ฝังอยู่. หากต้องการสกัดรูปภาพจากไฟล์ที่ฝังอยู่, ให้สกัดข้อมูล OLE แล้วตรวจสอบด้วยเครื่องมือที่รองรับประเภทไฟล์นั้น.