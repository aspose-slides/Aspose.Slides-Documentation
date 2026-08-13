---
title: 從 .NET 簡報形狀中擷取影像
linktitle: 形狀中的影像
type: docs
weight: 90
url: /zh-hant/net/extracting-images-from-presentation-shapes/
keywords:
- 擷取影像
- 取得影像
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 從 PowerPoint 與 OpenDocument 簡報的形狀中擷取影像 - 快速、程式碼友善的解決方案。"
---
## **概觀**

簡報中的影像可出現在多種形狀類型：普通的圖片框、套用於形狀的圖片填充、OLE 物件預覽圖、影音框縮圖、放大圖，或是嵌入於表格、圖表與 SmartArt 形狀內的影像。Aspose.Slides 會將這些影像儲存在簡報的影像集合中，透過 [ImageCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imagecollection/) 與 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 物件對外提供。

如果只需要匯出簡報中嵌入的每一個影像資源，只要遍歷 `presentation.Images` 即可。本篇文章著重於另一項任務：遍歷形狀以找出投影片中使用影像的地方，讓儲存的檔案能保留投影片編號、形狀位置以及來源類型（圖片框、填充影像、媒體預覽、OLE 預覽或放大圖）等有用的上下文資訊。

{{% alert title="Tip" color="info" %}}
使用 [IPPImage.BinaryData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 可保留原始編碼的影像資料與檔案類型。當需要將輸出正規化為特定格式（例如 PNG）時，請使用 [IPPImage.Image](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 搭配 [IImage.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/)。
{{% /alert %}}

## **共用輔助方法**

下列輔助方法用於簡化範例。`SaveOriginalImage` 會寫入原始嵌入的位元組，根據 MIME 類型選取安全的副檔名，並透過 SHA-256 雜湊避免寫入重複的影像二進位資料。

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

## **從圖片框擷取影像**

此方法適用於以獨立物件插入的圖片。[IPictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframe/) 會將圖片儲存在 `PictureFormat.Picture.Image`，該屬性回傳一個 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 物件。

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

## **從填充圖片的形狀擷取影像**

形狀可以使用圖片作為填充。先檢查形狀的填充類型：若不是 [FillType.Picture](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/)，則表示該填充沒有圖片可擷取。以下範例處理 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 物件，並透過 [IPPImage.Image](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 將每個影像儲存為 PNG。

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

## **從 OLE 物件框擷取預覽影像**

[IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ioleobjectframe/) 可能具有 PowerPoint 用於投影片預覽的替代圖片。此影像可透過 `SubstitutePictureFormat.Picture.Image` 取得。擷取此圖片會得到預覽影像，而非嵌入的 OLE 套件內容。

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

## **從影片框擷取預覽影像**

[IVideoFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/) 也可以在 `PictureFormat.Picture.Image` 中保存預覽圖片。這是投影片上顯示的海報或縮圖，並非從影片串流解碼的畫格。

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

## **從音訊框擷取預覽影像**

[IAudioFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iaudioframe/) 可以在 `PictureFormat.Picture.Image` 中保存縮圖。這是投影片上音訊物件顯示的圖片。

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

## **從放大物件擷取影像**

[IZoomFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/izoomframe/) 與 [ISectionZoomFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isectionzoomframe/) 形狀可以使用自訂影像。從放大框讀取 `ZoomImage` 即可。

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

## **從摘要放大框擷取影像**

[ISummaryZoomFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isummaryzoomframe/) 同樣是一個形狀。其章節項目可透過每個摘要放大章節的 `ZoomImage` 屬性使用自訂影像。

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

## **從表格形狀擷取影像**

[ITable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itable/) 為形狀。表格中的影像通常以圖片填充的方式儲存在儲存格中。

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

## **從圖表形狀擷取影像**

[IChart](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichart/) 為形狀。下列範例從圖表區域的圖片填充中擷取影像。

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

## **從 SmartArt 形狀擷取影像**

[ISmartArt](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.smartart/ismartart/) 物件為形狀。依據 SmartArt 版面配置，影像可能儲存在節點項目的項目符號填充或節點形狀的填充格式中。

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

## **包含群組形狀內的影像**

群組形狀有自己的形狀集合。共用的 `EnumerateShapes` 輔助方法提供 `includeGroupedShapes` 選項。當需要檢查 [IGroupShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igroupshape/) 內的形狀時，將其設為 `true`。以下範例擷取圖片框、填充圖片的形狀、OLE 物件預覽、影片框縮圖與音訊框縮圖的影像。若同時想加入表格、圖表、SmartArt 與摘要放大影像，只需在相同的遞迴形狀遍歷中重複使用前面章節的專屬擷取邏輯。

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

## **邊緣案例與實務說明**

- **重複影像：** 多個形狀可能參考相同的影像，或是不同影像卻擁有完全相同的位元組。寫入檔案前先以雜湊比對 [IPPImage.BinaryData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/)，即可確保每個唯一影像只產出一個檔案。
- **原始資料與轉換輸出：** 儲存 [IPPImage.BinaryData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 會保留嵌入的 JPEG、PNG、GIF、SVG、EMF 或 WMF 資料。若使用 [IPPImage.Image](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 搭配 [IImage.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/) 則可將輸出正規化為一致的格式。
- **不支援的填充類型：** 實體色、漸層、圖案與無填充的形狀不會包含圖片填充。讀取 `PictureFillFormat` 前請先檢查 [FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/)。
- **群組形狀：** 投影片的頂層形狀集合不會自動展平群組。若群組內容重要，請遞迴檢查 [IGroupShape.Shapes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igroupshape/)。
- **OLE 物件預覽：** [IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ioleobjectframe/) 可能透過 `SubstitutePictureFormat` 暴露預覽圖，但此圖僅為投影片預覽，並非嵌入於 OLE 物件內的檔案。
- **影片框縮圖：** [IVideoFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/) 可能透過 `PictureFormat` 暴露預覽圖，該圖僅是投影片上顯示的海報，並非從影片串流中擷取的畫格。
- **音訊框縮圖：** [IAudioFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iaudioframe/) 可能透過 `PictureFormat` 暴露圖示或縮圖，與嵌入的音訊資料無關。
- **放大影像：** 投影片放大、章節放大與摘要放大形狀可透過 `ZoomImage` 使用自訂的 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 物件。
- **巢狀形狀模型：** 表格、圖表與 SmartArt 物件實作 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/)，但它們的影像通常儲存在巢狀的表格儲存格、圖表元素或 SmartArt 節點的格式物件中。
- **裁切或變形的圖片：** 取得 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 只會得到儲存的影像資源，並不會套用形狀所做的裁切、透明度、重新上色、旋轉或其他視覺效果。

## **常見問題**

### 能否在不裁切、套用效果或形狀變形的情況下擷取原始影像？

可以。存取 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 物件，將 [IPPImage.BinaryData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 寫入磁碟，即可保留簡報中儲存的原始編碼影像，而不是投影片上呈現的樣子。

### 能否將所有擷取的影像匯出為 PNG？

可以。使用 [IPPImage.Image](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 取得 [IImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/) 物件，然後以 [ImageFormat.Png](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imageformat/) 呼叫 [IImage.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/)。此方法會將輸出轉換為 PNG，可能無法保留原始檔案類型或向量資料。

### 如何避免重複儲存同一張影像？

對 [IPPImage.BinaryData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 計算雜湊，並將雜湊值存於集合中。若新影像的雜湊已存在，就跳過寫入或記錄另一個指向已存在輸出檔案的參考。

### 為什麼某些形狀不會產生影像？

圖片框、填充圖片的形狀、OLE 物件框、媒體框、放大框、表格、圖表與 SmartArt 物件都可能參考影像。有些形狀類型會透過巢狀的格式物件暴露影像，因此僅檢查 `PictureFormat` 或形狀的 `FillFormat` 並不足以捕捉所有情況。

### 能否擷取影片框顯示的縮圖？

可以。存取 [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/) 並讀取 `PictureFormat.Picture.Image` 即可取得與影片框一起儲存的海報圖，該圖不是從影片檔案中產生的畫格。

### 如何判斷哪些形狀使用了簡報影像集合中的特定影像？

Aspose.Slides 不會從 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 反向追蹤到形狀。遍歷過程中自行建立映射：每當發現影像參考時，記錄投影片編號、形狀路徑以及影像雜湊或集合項目。

### 能否擷取嵌入於 OLE 物件內的影像（例如附加的文件）？

您可以從 [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ioleobjectframe/) 取得 OLE 物件的投影片預覽圖。但此預覽圖並不是嵌入的文件本身。若要從嵌入的檔案中擷取影像，需要先提取 OLE 資料，然後使用相應檔案類型的工具進行檢查。