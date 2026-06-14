---
title: 從 .NET 簡報形狀擷取影像
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
## **概述**

在簡報中，影像可以出現在多種形狀類型：作為普通的圖片框架、作為套用於形狀的圖片填充、作為 OLE 物件預覽影像、作為影片或音訊框架的縮圖、作為縮放影像，或作為嵌入於表格、圖表和 SmartArt 形狀中的影像。Aspose.Slides 將這些影像存儲於簡報的影像集合中，透過 [ImageCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imagecollection/) 與 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 物件公開。

如果只需要匯出簡報中嵌入的每個影像資源，可遍歷 `presentation.Images`。本文聚焦於另一項任務：遍歷形狀以找出影像在投影片中的使用位置，讓儲存的檔案能保留投影片編號、形狀位置及來源類型（圖片框架、填充影像、媒體預覽、OLE 預覽或縮放影像）的有用上下文。

{{% alert title="Tip" color="primary" %}}
使用 [IPPImage.BinaryData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 可保留原始編碼的影像資料與檔案類型。若想將輸出正規化為特定格式（例如 PNG），請使用 [IPPImage.Image](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 結合 [IImage.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/)。
{{% /alert %}}

## **共用輔助方法**

以下的輔助方法可讓範例保持簡潔。`SaveOriginalImage` 會寫入原始嵌入的位元組，依 MIME 類型選擇安全的副檔名，並使用 SHA-256 雜湊跳過重複的影像二進位資料。

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

## **從圖片框架擷取影像**

此方法適用於以獨立物件插入的圖片。 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframe/) 會將圖片存於 `PictureFormat.Picture.Image`，該屬性會回傳一個 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 物件。

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

## **從圖片填充形狀擷取影像**

形狀可以使用圖片作為填充。先檢查形狀的填充類型：若不是 [FillType.Picture](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/)，則該填充中沒有可擷取的圖片。以下範例處理 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 物件，並透過 [IPPImage.Image](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 以 PNG 格式儲存每張影像。

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

## **從 OLE 物件框架擷取預覽影像**

[IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ioleobjectframe/) 可能有 PowerPoint 用於在投影片上顯示的替代圖片。此影像可透過 `SubstitutePictureFormat.Picture.Image` 取得。擷取此圖片只能得到預覽影像，而非嵌入的 OLE 套件內容。

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

## **從影片框架擷取預覽影像**

[IVideoFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/) 也可以在 `PictureFormat.Picture.Image` 中儲存預覽影像。這是投影片上顯示的海報或縮圖，並非從影片串流中解碼的畫格。

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

## **從音訊框架擷取預覽影像**

[IAudioFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iaudioframe/) 可以在 `PictureFormat.Picture.Image` 中存放縮圖。這是音訊物件在投影片上顯示的圖示或縮圖。

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

## **從縮放物件擷取影像**

[IZoomFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/izoomframe/) 與 [ISectionZoomFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isectionzoomframe/) 形狀可以使用自訂影像。從縮放框架讀取 `ZoomImage`。

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

## **從摘要縮放框架擷取影像**

[ISummaryZoomFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isummaryzoomframe/) 也是形狀。其區段項目可以使用自訂影像，透過每個摘要縮放區段的 `ZoomImage` 屬性取得。

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

## **從表格形狀擷取影像**

[ITable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itable/) 為形狀。表格中的影像通常以圖片填充的方式儲存在表格儲存格中。

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

## **從圖表形狀擷取影像**

[IChart](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichart/) 為形狀。以下範例從圖表區域的圖片填充中擷取影像。

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

## **從 SmartArt 形狀擷取影像**

[ISmartArt](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.smartart/ismartart/) 物件是形狀。依據 SmartArt 版面配置，影像可能儲存在節點項目的項目符號填充中，或儲存在節點形狀的填充格式裡。

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

## **包含於群組形狀內的影像**

群組形狀擁有自己的形狀集合。共用的 `EnumerateShapes` 輔助方法提供 `includeGroupedShapes` 選項。當需要檢查 [IGroupShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igroupshape/) 內的形狀時，將其設為 `true`。以下範例從圖片框架、圖片填充形狀、OLE 物件預覽、影片框架縮圖與音訊框架縮圖中擷取影像。若同時想包含表格、圖表、SmartArt 與摘要縮放的影像，請在保持相同遞迴形狀遍歷的前提下，重新使用前面章節的專屬擷取邏輯。

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

## **邊緣情況與實務說明**

- **重複的影像：** 多個形狀可能參考相同的影像或不同的影像但位元組相同。若想對每個唯一影像產生一個輸出檔，寫入檔案前先對 [IPPImage.BinaryData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 做雜湊。
- **原始資料與轉換後輸出：** 儲存 [IPPImage.BinaryData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 可保留嵌入的 JPEG、PNG、GIF、SVG、EMF 或 WMF 資料。透過 [IPPImage.Image](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 再使用 [IImage.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/) 儲存可在需要統一格式（如 PNG）時使用。
- **不支援的填充類型：** 實心、漸層、圖案與無填充形狀不含圖片填充。讀取 `PictureFillFormat` 前先檢查 [FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/)。
- **群組形狀：** 上層投影片形狀集合不會自動展平群組。當群組內容重要時，需遞迴檢查 [IGroupShape.Shapes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igroupshape/)。
- **OLE 物件預覽：** [IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ioleobjectframe/) 可能透過 `SubstitutePictureFormat` 提供預覽影像，但該影像僅為投影片預覽，並非 OLE 物件內嵌檔案。
- **影片框架縮圖：** [IVideoFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/) 可能透過 `PictureFormat` 提供預覽影像，但僅為投影片上顯示的海報，並非從影片串流中解碼的框格。
- **音訊框架縮圖：** [IAudioFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iaudioframe/) 可能透過 `PictureFormat` 提供圖示或縮圖；它不包含嵌入的音訊資料。
- **縮放影像：** 投影片縮放、區段縮放與摘要縮放形狀可能使用自訂的 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 物件，透過 `ZoomImage` 取得。
- **巢狀形狀模型：** 表格、圖表與 SmartArt 物件實作 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/)，但其影像常儲存在巢狀的表格儲存格、圖表元素或 SmartArt 節點格式物件中。
- **裁切或變形的圖片：** 取得 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 可得到儲存的影像資源。它不會渲染形狀套用的裁切、透明度、重新著色、旋轉或其他視覺效果。

## **常見問題**

**我可以在不裁切、特效或形狀變換的情況下擷取原始影像嗎？**

是的。存取 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 物件，將 [IPPImage.BinaryData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 寫入磁碟，即可保留簡報中儲存的原始編碼影像，而非在投影片上呈現的樣貌。

**我可以將所有擷取的影像匯出為 PNG 嗎？**

可以。使用 [IPPImage.Image](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 取得 [IImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/) 物件，然後以 [IImage.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/) 搭配 [ImageFormat.Png](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imageformat/) 儲存。這會將輸出轉換為 PNG，可能無法保留原始檔案類型或向量資料。

**我如何避免重複儲存相同的影像？**

對 [IPPImage.BinaryData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 計算雜湊，將雜湊值存入集合。若新影像的雜湊已存在，則跳過或將其記錄為指向已存在輸出檔的另一個參考。

**為什麼某些形狀不會產生影像？**

圖片框架、圖片填充形狀、OLE 物件框架、媒體框架、縮放框架、表格、圖表與 SmartArt 物件都可能參考影像。有些形狀類型需要透過巢狀的格式物件才能取得影像，因此僅檢查 `PictureFormat` 或形狀的 `FillFormat` 有時不足以捕捉所有影像。

**我可以擷取影片框架顯示的縮圖嗎？**

可以。使用 [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/) 並讀取 `PictureFormat.Picture.Image`，即可擷取與影片框架一起儲存的海報影像，而非從影片檔案中產生的實際畫格。

**我該如何判斷哪些形狀使用簡報影像集合中的特定影像？**

Aspose.Slides 不會從 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 反向連結到形狀。遍歷時建立映射：每當發現影像參考時，記錄投影片編號、形狀路徑以及影像雜湊或集合項目，以便之後查詢。

**我可以擷取嵌入於 OLE 物件（如附加檔案）內的影像嗎？**

您可以從 [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ioleobjectframe/) 取得 OLE 物件的投影片預覽影像，但該預覽並非嵌入的文件本身。若要從嵌入的檔案內部擷取影像，需先提取 OLE 資料，然後使用相應檔案類型的工具進行檢查。