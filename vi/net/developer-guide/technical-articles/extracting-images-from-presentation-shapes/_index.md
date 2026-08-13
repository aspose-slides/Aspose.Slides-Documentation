---
title: Trích xuất hình ảnh từ các hình dạng trong bản trình chiếu bằng .NET
linktitle: Hình ảnh từ hình dạng
type: docs
weight: 90
url: /vi/net/extracting-images-from-presentation-shapes/
keywords:
  - trích xuất hình ảnh
  - lấy lại hình ảnh
  - PowerPoint
  - OpenDocument
  - bản trình chiếu
  - .NET
  - C#
  - Aspose.Slides
description: "Trích xuất hình ảnh từ các hình dạng trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho .NET - giải pháp nhanh, thân thiện với mã."
---
## **Tổng quan**

Hình ảnh trong một bài thuyết trình có thể xuất hiện trong nhiều kiểu hình dạng: như khung ảnh thông thường, như ảnh nền được áp dụng cho các hình dạng, như hình ảnh xem trước của đối tượng OLE, như hình thu nhỏ của khung video hoặc âm thanh, như ảnh thu phóng, hoặc như hình ảnh lồng trong các hình dạng bảng, biểu đồ và SmartArt. Aspose.Slides lưu các hình ảnh này trong bộ sưu tập hình ảnh của bản trình chiếu, được truy cập thông qua các đối tượng [ImageCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/imagecollection/) và [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) .

Nếu bạn chỉ cần xuất mọi tài nguyên hình ảnh được nhúng trong một bản trình chiếu, hãy lặp qua `presentation.Images`. Bài viết này tập trung vào một nhiệm vụ khác: duyệt các hình dạng để tìm nơi hình ảnh được sử dụng trên các slide, để các tệp đã lưu có thể giữ lại ngữ cảnh hữu ích như số slide, vị trí hình dạng và loại nguồn (khung ảnh, ảnh nền, xem trước phương tiện, xem trước OLE, hoặc ảnh thu phóng).

{{% alert title="Tip" color="info" %}}
Sử dụng [IPPImage.BinaryData](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) để giữ nguyên dữ liệu hình ảnh đã mã hoá và loại tệp gốc. Sử dụng [IPPImage.Image](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) cùng với [IImage.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/) khi bạn muốn chuẩn hoá đầu ra sang một định dạng cụ thể như PNG.
{{% /alert %}}

## **Các phương thức trợ giúp chung**

Các phương thức trợ giúp dưới đây giúp các ví dụ ngắn gọn. `SaveOriginalImage` ghi các byte nhúng gốc, chọn phần mở rộng an toàn dựa trên MIME type, và bỏ qua các hình ảnh nhị phân trùng lặp bằng hàm băm SHA-256.

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

## **Trích xuất hình ảnh từ khung ảnh**

Sử dụng cách này cho các hình ảnh được chèn dưới dạng đối tượng độc lập. Một [IPictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframe/) lưu hình ảnh của mình trong `PictureFormat.Picture.Image`, trả về một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) .

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

## **Trích xuất hình ảnh từ các hình dạng được điền bằng hình ảnh**

Các hình dạng có thể sử dụng một hình ảnh làm nền. Kiểm tra loại nền của hình dạng trước: nếu nó không phải là [FillType.Picture](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/), thì không có hình ảnh nào để trích xuất từ nền đó. Ví dụ bên dưới xử lý các đối tượng [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) và lưu mỗi hình ảnh dưới dạng PNG thông qua [IPPImage.Image](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) .

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

## **Trích xuất hình ảnh xem trước từ khung đối tượng OLE**

Một [IOleObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ioleobjectframe/) có thể có một ảnh thay thế mà PowerPoint sử dụng làm xem trước đối tượng trên slide. Ảnh này có sẵn thông qua `SubstitutePictureFormat.Picture.Image`. Trích xuất ảnh này sẽ cho bạn hình ảnh xem trước, không phải nội dung gói OLE đã nhúng.

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

## **Trích xuất hình ảnh xem trước từ khung video**

Một [IVideoFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ivideoframe/) cũng có thể lưu một hình ảnh xem trước trong `PictureFormat.Picture.Image`. Đây là ảnh poster hoặc thumbnail hiển thị trên slide, không phải một khung được giải mã từ luồng video.

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

## **Trích xuất hình ảnh xem trước từ khung âm thanh**

Một [IAudioFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/iaudioframe/) có thể lưu một thumbnail trong `PictureFormat.Picture.Image`. Đây là ảnh hiển thị cho đối tượng âm thanh trên slide.

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

## **Trích xuất hình ảnh từ đối tượng Zoom**

[IZoomFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/izoomframe/) và [ISectionZoomFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/isectionzoomframe/) có thể sử dụng hình ảnh tùy chỉnh. Đọc `ZoomImage` từ khung zoom.

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

## **Trích xuất hình ảnh từ khung Summary Zoom**

Một [ISummaryZoomFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/isummaryzoomframe/) cũng là một hình dạng. Các mục phần của nó có thể sử dụng hình ảnh tùy chỉnh, được mở rộng qua thuộc tính `ZoomImage` của từng phần summary zoom.

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

## **Trích xuất hình ảnh từ hình dạng Bảng**

Một [ITable](https://reference.aspose.com/slides/vi/net/aspose.slides/itable/) là một hình dạng. Hình ảnh trong bảng thường được lưu dưới dạng nền hình ảnh trong các ô bảng.

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

## **Trích xuất hình ảnh từ hình dạng Biểu đồ**

Một [IChart](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichart/) là một hình dạng. Ví dụ dưới đây trích xuất một hình ảnh từ nền hình ảnh của khu vực biểu đồ.

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

## **Trích xuất hình ảnh từ hình dạng SmartArt**

Một đối tượng [ISmartArt](https://reference.aspose.com/slides/vi/net/aspose.slides.smartart/ismartart/) là một hình dạng. Tùy thuộc vào bố cục SmartArt, hình ảnh có thể được lưu trong nền dấu chấm của nút hoặc trong định dạng nền của các hình dạng nút.

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

## **Bao gồm hình ảnh bên trong các hình dạng nhóm**

Các hình dạng nhóm chứa bộ sưu tập hình dạng riêng của chúng. Trợ giúp chung `EnumerateShapes` có tùy chọn `includeGroupedShapes`. Đặt nó thành `true` khi bạn muốn kiểm tra các hình dạng bên trong các đối tượng [IGroupShape](https://reference.aspose.com/slides/vi/net/aspose.slides/igroupshape/) . Ví dụ dưới đây trích xuất hình ảnh từ khung ảnh, các hình dạng được điền bằng hình ảnh, xem trước đối tượng OLE, thumbnail khung video và thumbnail khung âm thanh. Để bao gồm cả hình ảnh bảng, biểu đồ, SmartArt và summary zoom, hãy tái sử dụng logic trích xuất chuyên biệt từ các phần trước trong khi giữ cùng cách duyệt hình dạng đệ quy.

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

## **Các trường hợp đặc biệt và ghi chú thực tiễn**

- **Duplicate images:** Nhiều hình dạng có thể tham chiếu cùng một hình ảnh hoặc các hình ảnh riêng biệt với cùng byte. Tính băm [IPPImage.BinaryData](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) trước khi ghi tệp nếu bạn muốn một tệp đầu ra cho mỗi hình ảnh duy nhất.  
- **Original data vs. converted output:** Lưu [IPPImage.BinaryData](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) giữ nguyên dữ liệu JPEG, PNG, GIF, SVG, EMF hoặc WMF đã nhúng. Lưu [IPPImage.Image](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) qua [IImage.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/) hữu ích khi bạn muốn một định dạng đầu ra nhất quán.  
- **Unsupported fill types:** Các hình dạng đặc, gradient, mẫu và không nền không chứa nền hình ảnh. Kiểm tra [FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) trước khi đọc `PictureFillFormat`.  
- **Grouped shapes:** Bộ sưu tập hình dạng slide cấp cao nhất không làm phẳng các nhóm. Kiểm tra đệ quy [IGroupShape.Shapes](https://reference.aspose.com/slides/vi/net/aspose.slides/igroupshape/) khi nội dung nhóm quan trọng.  
- **OLE object previews:** Một [IOleObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ioleobjectframe/) có thể hiển thị một hình ảnh xem trước qua `SubstitutePictureFormat`, nhưng hình ảnh này chỉ là xem trước slide. Nó không phải là tệp được nhúng bên trong đối tượng OLE.  
- **Video frame thumbnails:** Một [IVideoFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ivideoframe/) có thể hiển thị hình ảnh xem trước qua `PictureFormat`, nhưng hình ảnh này chỉ là poster hiển thị trên slide. Nó không được trích xuất từ luồng video.  
- **Audio frame thumbnails:** Một [IAudioFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/iaudioframe/) có thể hiển thị biểu tượng hoặc thumbnail qua `PictureFormat`; nó không phải là dữ liệu âm thanh được nhúng.  
- **Zoom images:** Các hình dạng slide zoom, section zoom và summary zoom có thể sử dụng các đối tượng [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) tùy chỉnh qua `ZoomImage`.  
- **Nested shape models:** Các đối tượng Table, Chart và SmartArt triển khai [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/), nhưng hình ảnh của chúng thường được lưu trong ô bảng lồng nhau, phần tử biểu đồ hoặc đối tượng định dạng nút SmartArt.  
- **Cropped or transformed pictures:** Truy cập [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) cung cấp cho bạn tài nguyên hình ảnh đã lưu. Nó không thực hiện cắt, trong suốt, thay đổi màu, xoay hoặc các hiệu ứng hình ảnh khác được áp dụng bởi hình dạng.

## **Câu hỏi thường gặp**

### Tôi có thể trích xuất hình ảnh gốc mà không cắt, hiệu ứng hay biến đổi hình dạng không?

Có. Truy cập đối tượng [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) và ghi [IPPImage.BinaryData](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) ra đĩa. Điều này giữ nguyên hình ảnh đã mã hoá gốc được lưu trong bản trình chiếu, không phải cách hình ảnh được render trên slide.

### Tôi có thể xuất mọi hình ảnh đã trích xuất dưới dạng PNG không?

Có. Sử dụng [IPPImage.Image](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) để lấy một đối tượng [IImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/) , sau đó gọi [IImage.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/) với [ImageFormat.Png](https://reference.aspose.com/slides/vi/net/aspose.slides/imageformat/). Điều này chuyển đổi đầu ra và có thể không giữ nguyên loại tệp gốc hoặc dữ liệu vector.

### Làm thế nào để tránh lưu cùng một hình ảnh nhiều lần?

Sử dụng hàm băm của [IPPImage.BinaryData](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) , và giữ các băm trong một tập hợp. Nếu một hình ảnh mới có băm đã tồn tại, bỏ qua nó hoặc ghi lại một tham chiếu khác tới tệp đầu ra hiện có.

### Tại sao một số hình dạng không tạo ra hình ảnh?

Khung ảnh, các hình dạng được điền bằng hình ảnh, khung đối tượng OLE, khung phương tiện, khung zoom, bảng, biểu đồ và đối tượng SmartArt có thể tham chiếu hình ảnh. Một số loại hình dạng hiển thị hình ảnh thông qua các đối tượng định dạng lồng nhau, vì vậy việc kiểm tra đơn giản `PictureFormat` hoặc `FillFormat` của hình dạng không luôn đủ.

### Tôi có thể trích xuất thumbnail hiển thị cho một khung video không?

Có. Sử dụng [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ivideoframe/) và đọc `PictureFormat.Picture.Image`. Điều này trích xuất ảnh poster được lưu cùng với khung video, không phải một khung được tạo ra từ tệp video.

### Làm sao tôi có thể xác định những hình dạng nào sử dụng một hình ảnh cụ thể từ bộ sưu tập hình ảnh của bản trình chiếu?

Aspose.Slides không lưu liên kết ngược từ [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) tới các hình dạng. Xây dựng một bản đồ trong quá trình duyệt: mỗi khi bạn tìm thấy một tham chiếu hình ảnh, ghi lại số slide, đường dẫn hình dạng và băm hình ảnh hoặc mục trong bộ sưu tập.

### Tôi có thể trích xuất hình ảnh được nhúng trong các đối tượng OLE, chẳng hạn như tài liệu đính kèm không?

Bạn có thể trích xuất xem trước slide của đối tượng OLE từ [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ioleobjectframe/). Tuy nhiên, xem trước này không phải là tài liệu nhúng. Để trích xuất hình ảnh từ bên trong tệp nhúng, hãy trích xuất dữ liệu OLE và kiểm tra nó bằng các công cụ cho loại tệp đó.