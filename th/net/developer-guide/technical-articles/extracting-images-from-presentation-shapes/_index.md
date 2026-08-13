---
title: สกัดรูปภาพจากรูปทรงในงานนำเสนอด้วย .NET
linktitle: รูปภาพจากรูปทรง
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
description: "สกัดรูปภาพจากรูปทรงในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ .NET - วิธีแก้ไขที่เร็วและเป็นมิตรต่อโค้ด"
---
## **ภาพรวม**

รูปภาพในงานนำเสนอสามารถปรากฏในหลายประเภทของรูปทรง: เป็นกรอบรูปทั่วไป, เป็นการเติมรูปที่ใช้กับรูปทรง, เป็นภาพตัวอย่างของอ็อบเจ็กต์ OLE, เป็นภาพย่อของเฟรมวิดีโอหรือเสียง, เป็นภาพซูม, หรือเป็นรูปภาพที่ซ้อนอยู่ภายในรูปทรงตาราง, แผนภูมิ และ SmartArt. Aspose.Slides จัดเก็บรูปภาพเหล่านี้ในคอลเลกชันรูปภาพของงานนำเสนอ, ที่เปิดเผยผ่าน [ImageCollection](https://reference.aspose.com/slides/th/net/aspose.slides/imagecollection/) และ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) objects.

หากคุณต้องการส่งออกทรัพยากรรูปภาพทั้งหมดที่ฝังอยู่ในงานนำเสนอ, ให้วนลูปผ่าน `presentation.Images`. บทความนี้เน้นงานที่แตกต่าง: การเดินสำรวจรูปทรงเพื่อค้นหาที่ที่ใช้รูปภาพบนสไลด์, เพื่อให้ไฟล์ที่บันทึกสามารถเก็บบริบทยังใช้ได้ เช่น หมายเลขสไลด์, ตำแหน่งรูปทรง, และประเภทแหล่งที่ม (กรอบรูป, รูปเติม, ตัวอย่างสื่อ, ตัวอย่าง OLE หรือรูปซูม).

{{% alert title="Tip" color="info" %}}
ใช้ [IPPImage.BinaryData](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) เพื่อรักษาข้อมูลภาพที่เข้ารหัสต้นฉบับและประเภทไฟล์ไว้. ใช้ [IPPImage.Image](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) ร่วมกับ [IImage.Save](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) เมื่อคุณต้องการทำให้เอาต์พุตเป็นรูปแบบเฉพาะเช่น PNG.
{{% /alert %}}

## **วิธีการช่วยเหลือที่ใช้ร่วมกัน**

วิธีการช่วยเหลือด้านล่างทำให้ตัวอย่างสั้นลง. `SaveOriginalImage` จะเขียนไบต์ที่ฝังอยู่เดิม, เลือกส่วนขยายที่ปลอดภัยจาก MIME type, และข้ามไบนารีรูปภาพที่ซ้ำกันโดยใช้แฮช SHA-256.

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

## **ดึงรูปภาพจากกรอบรูป**

ใช้วิธีนี้สำหรับรูปที่แทรกเป็นออบเจ็กต์อิสระ. ออบเจ็กต์ [IPictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ipictureframe/) เก็บรูปภาพใน `PictureFormat.Picture.Image`, ซึ่งคืนค่าออบเจ็กต์ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/).

```c#
using Aspose.Slides;

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

## **ดึงรูปภาพจากรูปทรงที่เติมด้วยรูป**

รูปทรงสามารถใช้รูปภาพเป็นการเติมของมันได้. ตรวจสอบประเภทการเติมของรูปทรงก่อน: หากไม่ใช่ [FillType.Picture](https://reference.aspose.com/slides/th/net/aspose.slides/filltype/), จะไม่มีรูปภาพให้ดึงจากการเติมนั้น. ตัวอย่างด้านล่างจัดการกับออบเจ็กต์ [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) และบันทึกรูปแต่ละภาพเป็น PNG ผ่าน [IPPImage.Image](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/).

```c#
using Aspose.Slides;

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

## **ดึงภาพตัวอย่างจากเฟรมออบเจ็กต์ OLE**

ออบเจ็กต์ [IOleObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ioleobjectframe/) สามารถมีรูปภาพทดแทนที่ PowerPoint ใช้เป็นตัวอย่างของออบเจ็กต์บนสไลด์. ภาพนี้สามารถเข้าถึงได้ผ่าน `SubstitutePictureFormat.Picture.Image`. การดึงรูปภาพนี้จะให้ภาพตัวอย่าง, ไม่ใช่เนื้อหาแพ็คเกจ OLE ที่ฝังอยู่.

```c#
using Aspose.Slides;

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

## **ดึงภาพตัวอย่างจากเฟรมวิดีโอ**

ออบเจ็กต์ [IVideoFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/) สามารถเก็บภาพตัวอย่างใน `PictureFormat.Picture.Image`. นี้เป็นโปสเตอร์หรือภาพย่อที่แสดงบนสไลด์, ไม่ใช่เฟรมที่ถอดรหัสจากสตรีมวิดีโอ.

```c#
using Aspose.Slides;

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

## **ดึงภาพตัวอย่างจากเฟรมเสียง**

ออบเจ็กต์ [IAudioFrame](https://reference.aspose.com/slides/th/net/aspose.slides/iaudioframe/) สามารถเก็บภาพย่อใน `PictureFormat.Picture.Image`. นี้คือภาพที่แสดงสำหรับออบเจ็กต์เสียงบนสไลด์.

```c#
using Aspose.Slides;

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

## **ดึงรูปภาพจากวัตถุซูม**

รูปทรง [IZoomFrame](https://reference.aspose.com/slides/th/net/aspose.slides/izoomframe/) และ [ISectionZoomFrame](https://reference.aspose.com/slides/th/net/aspose.slides/isectionzoomframe/) สามารถใช้รูปภาพกำหนดเองได้. อ่าน `ZoomImage` จากเฟรมซูม.

```c#
using Aspose.Slides;

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

## **ดึงรูปภาพจากเฟรมสรุปซูม**

ออบเจ็กต์ [ISummaryZoomFrame](https://reference.aspose.com/slides/th/net/aspose.slides/isummaryzoomframe/) ก็เป็นรูปทรงเช่นกัน. รายการส่วนของสรุปซูมแต่ละส่วนสามารถใช้รูปภาพกำหนดเอง, ซึ่งเปิดเผยผ่านคุณสมบัติ `ZoomImage` ของแต่ละส่วนสรุปซูม.

```c#
using Aspose.Slides;

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

## **ดึงรูปภาพจากรูปทรงตาราง**

ออบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/net/aspose.slides/itable/) เป็นรูปทรง. รูปภาพในตารางส่วนใหญ่ถูกเก็บเป็นการเติมรูปในเซลล์ตาราง.

```c#
using Aspose.Slides;

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

## **ดึงรูปภาพจากรูปทรงแผนภูมิ**

ออบเจ็กต์ [IChart](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichart/) เป็นรูปทรง. ตัวอย่างด้านล่างดึงรูปภาพจากการเติมรูปของพื้นที่แผนภูมิ.

```c#
using Aspose.Slides;

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

## **ดึงรูปภาพจากรูปทรง SmartArt**

ออบเจ็กต์ [ISmartArt](https://reference.aspose.com/slides/th/net/aspose.slides.smartart/ismartart/) เป็นรูปทรง. ขึ้นอยู่กับเค้าโครง SmartArt, รูปภาพอาจถูกเก็บในการเติมรูปของจุดหัวข้อหรือในรูปแบบการเติมของรูปร่างจุด.

```c#
using Aspose.Slides;

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

## **รวมรูปภาพภายในรูปทรงที่จัดกลุ่ม**

รูปทรงที่จัดกลุ่มมีคอลเลกชันรูปทรงของตนเอง. ตัวช่วย `EnumerateShapes` ที่ใช้ร่วมกันมีตัวเลือก `includeGroupedShapes`. ตั้งค่าเป็น `true` เมื่อคุณต้องการตรวจสอบรูปทรงภายในออบเจ็กต์ [IGroupShape](https://reference.aspose.com/slides/th/net/aspose.slides/igroupshape/). ตัวอย่างด้านล่างดึงรูปภาพจากกรอบรูป, รูปทรงที่เติมด้วยรูป, ตัวอย่าง OLE, ภาพย่อเฟรมวิดีโอ, และภาพย่อเฟรมเสียง. เพื่อรวมรูปภาพจากตาราง, แผนภูมิ, SmartArt, และสรุปซูมด้วย, ให้ใช้ตรรกะการดึงเฉพาะที่อธิบายในส่วนก่อนหน้าในขณะที่ยังคงการเดินสำรวจรูปทรงแบบเรียกซ้ำเดิม.

```c#
using Aspose.Slides;

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

## **กรณีขอบและข้อสังเกตที่เป็นประโยชน์**

- **Duplicate images:** รูปหลายรูปทรงอาจอ้างอิงรูปเดียวกันหรือรูปภาพแยกที่มีไบต์เท่าเดิม. ให้ทำแฮช [IPPImage.BinaryData](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) ก่อนบันทึกไฟล์หากต้องการไฟล์ผลลัพธ์หนึ่งไฟล์ต่อรูปที่ไม่ซ้ำกัน.
- **Original data vs. converted output:** การบันทึก [IPPImage.BinaryData](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) จะคงข้อมูล JPEG, PNG, GIF, SVG, EMF, หรือ WMF ที่ฝังไว้. การบันทึก [IPPImage.Image](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) ผ่าน [IImage.Save](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) มีประโยชน์เมื่อคุณต้องการรูปแบบเอาต์พุตที่สม่ำเสมอ.
- **Unsupported fill types:** รูปทรงแบบ Solid, Gradient, Pattern, และ No-Fill ไม่ได้มีการเติมรูปภาพ. ตรวจสอบ [FillType](https://reference.aspose.com/slides/th/net/aspose.slides/filltype/) ก่อนอ่าน `PictureFillFormat`.
- **Grouped shapes:** คอลเลกชันรูปทรงระดับบนของสไลด์ไม่ได้ทำให้กลุ่มแบนลง. ให้ตรวจสอบ [IGroupShape.Shapes](https://reference.aspose.com/slides/th/net/aspose.slides/igroupshape/) อย่างเรียกซ้ำเมื่อเนื้อหาที่จัดกลุ่มสำคัญ.
- **OLE object previews:** ออบเจ็กต์ [IOleObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ioleobjectframe/) อาจเปิดเผยภาพตัวอย่างผ่าน `SubstitutePictureFormat`, แต่ภาพนั้นเป็นเพียงตัวอย่างบนสไลด์. ไม่ใช่ไฟล์ที่ฝังอยู่ในออบเจ็กต์ OLE.
- **Video frame thumbnails:** ออบเจ็กต์ [IVideoFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/) อาจเปิดเผยภาพตัวอย่างผ่าน `PictureFormat`, แต่ภาพนั้นเป็นโปสเตอร์ที่แสดงบนสไลด์เท่านั้น. ไม่ได้ดึงจากสตรีมวิดีโอ.
- **Audio frame thumbnails:** ออบเจ็กต์ [IAudioFrame](https://reference.aspose.com/slides/th/net/aspose.slides/iaudioframe/) อาจเปิดเผยไอคอนหรือภาพย่อผ่าน `PictureFormat`; ไม่ได้เป็นข้อมูลเสียงที่ฝังอยู่.
- **Zoom images:** รูปซูม, ซูมส่วน, และรูปสรุปซูมอาจใช้ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) กำหนดเองผ่าน `ZoomImage`.
- **Nested shape models:** ออบเจ็กต์ตาราง, แผนภูมิ, และ SmartArt ทำตามอินเตอร์เฟส [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/), แต่ภาพของพวกมันมักถูกเก็บในออบเจ็กต์การจัดรูปแบบของเซลล์ตาราง, องค์ประกอบแผนภูมิ, หรือโหนด SmartArt.
- **Cropped or transformed pictures:** การเข้าถึง [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) ให้คุณได้ทรัพยากรภาพที่จัดเก็บไว้. มันไม่ได้เรนเดอร์การครอป, ความโปร่งใส, การเปลี่ยนสี, การหมุน, หรือเอฟเฟกต์ภาพอื่น ๆ ที่รูปทรงทำไว้.

## **คำถามที่พบบ่อย**

### ฉันสามารถดึงรูปภาพต้นฉบับโดยไม่ต้องครอป, เอฟเฟกต์ หรือการแปลงรูปทรงได้หรือไม่?

ใช่. เข้าถึงออบเจ็กต์ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) แล้วเขียน [IPPImage.BinaryData](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) ลงดิสก์. วิธีนี้จะคงภาพที่เข้ารหัสต้นฉบับที่เก็บในงานนำเสนอ, ไม่ใช่วิธีที่ภาพถูกแสดงบนสไลด์.

### ฉันสามารถส่งออกรูปภาพที่ดึงออกทั้งหมดเป็น PNG ได้หรือไม่?

ใช่. ใช้ [IPPImage.Image](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) เพื่อรับออบเจ็กต์ [IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/), แล้วเรียก [IImage.Save](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) พร้อม [ImageFormat.Png](https://reference.aspose.com/slides/th/net/aspose.slides/imageformat/). วิธีนี้จะแปลงเอาต์พุตและอาจไม่คงประเภทไฟล์หรือข้อมูลเวกเตอร์เดิม.

### ฉันจะหลีกเลี่ยงการบันทึกรูปเดียวกันหลายครั้งได้อย่างไร?

ใช้แฮชของ [IPPImage.BinaryData](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) และเก็บแฮชเหล่านั้นในชุดข้อมูล. หากรูปภาพใหม่มีแฮชที่มีอยู่แล้ว, ให้ข้ามหรือบันทึกการอ้างอิงเพิ่มเติมไปยังไฟล์ผลลัพธ์ที่มีอยู่.

### ทำไมรูปทรงบางประเภทถึงไม่สร้างรูปภาพ?

กรอบรูป, รูปทรงที่เติมรูป, เฟรมอ็อบเจ็กต์ OLE, เฟรมสื่อ, เฟรมซูม, ตาราง, แผนภูมิ, และอ็อบเจ็กต์ SmartArt สามารถอ้างอิงรูปภาพได้. บางประเภทรูปทรงเปิดเผยรูปภาพผ่านออบเจ็กต์การจัดรูปแบบที่ซ้อนอยู่, ดังนั้นการตรวจสอบแค่ `PictureFormat` หรือ `FillFormat` ของรูปทรงอาจไม่เพียงพอ.

### ฉันสามารถดึงภาพย่อที่แสดงสำหรับเฟรมวิดีโอได้หรือไม่?

ใช่. ใช้ [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ivideoframe/) แล้วอ่าน `PictureFormat.Picture.Image`. วิธีนี้ดึงภาพโปสเตอร์ที่เก็บไว้กับเฟรมวิดีโอ, ไม่ใช่เฟรมที่สร้างจากไฟล์วิดีโอ.

### ฉันจะกำหนดว่ารูปทรงใดใช้รูปภาพเฉพาะจากคอลเลกชันรูปภาพของงานนำเสนอได้อย่างไร?

Aspose.Slides ไม่จัดเก็บลิงก์ย้อนกลับจาก [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) ไปยังรูปทรง. ให้สร้างแมประหว่างการเดินสำรวจ: เมื่อพบการอ้างอิงรูปภาพ, บันทึกหมายเลขสไลด์, เส้นทางรูปทรง, และแฮชหรือรายการของคอลเลกชันรูปภาพ.

### ฉันสามารถดึงรูปภาพที่ฝังอยู่ในอ็อบเจ็กต์ OLE เช่น เอกสารแนบได้หรือไม่?

คุณสามารถดึงภาพตัวอย่างของอ็อบเจ็กต์ OLE จาก [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ioleobjectframe/) ได้. อย่างไรก็ตาม, ภาพตัวอย่างนั้นไม่ใช่เอกสารที่ฝังอยู่จริง. หากต้องการดึงรูปภาพจากไฟล์ที่ฝังอยู่, ให้ดึงข้อมูล OLE แล้วตรวจสอบด้วยเครื่องมือที่รองรับประเภทไฟล์นั้น.