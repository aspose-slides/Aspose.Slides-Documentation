---
title: Trích xuất hình ảnh từ các hình dạng trong bài thuyết trình bằng .NET
linktitle: Hình ảnh từ hình dạng
type: docs
weight: 90
url: /vi/net/extracting-images-from-presentation-shapes/
keywords:
- trích xuất hình ảnh
- lấy hình ảnh
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Trích xuất hình ảnh từ các hình dạng trong bài thuyết trình PowerPoint và OpenDocument bằng Aspose.Slides cho .NET - giải pháp nhanh, thân thiện với mã."
---
## **Tổng quan**

Hình ảnh trong một bản trình bày có thể xuất hiện trong một số loại hình dạng: như khung ảnh thông thường, như hình nền ảnh được áp dụng cho các hình dạng, như ảnh xem trước của đối tượng OLE, như hình thu nhỏ khung video hoặc âm thanh, như hình ảnh thu phóng, hoặc như hình ảnh lồng trong các hình dạng bảng, biểu đồ và SmartArt. Aspose.Slides lưu trữ những hình ảnh đó trong bộ sưu tập hình ảnh của bản trình bày, được mở ra qua các đối tượng [ImageCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/imagecollection/) và [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) .

Nếu bạn chỉ cần xuất mọi tài nguyên hình ảnh được nhúng trong một bản trình bày, hãy lặp qua `presentation.Images`. Bài viết này tập trung vào một nhiệm vụ khác: duyệt các hình dạng để tìm nơi hình ảnh được sử dụng trên các slide, để các tệp đã lưu có thể giữ ngữ cảnh hữu ích như số slide, vị trí hình dạng và loại nguồn (khung ảnh, ảnh nền, xem trước phương tiện, xem trước OLE hoặc ảnh thu phóng).

{{% alert title="Tip" color="primary" %}}
Sử dụng [IPPImage.BinaryData](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) để bảo tồn dữ liệu ảnh đã mã hoá gốc và kiểu tệp. Sử dụng [IPPImage.Image](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) với [IImage.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/) khi bạn muốn chuẩn hoá đầu ra sang định dạng cụ thể như PNG.
{{% /alert %}}

## **Phương thức Trợ giúp Chung**

Các phương thức trợ giúp bên dưới giúp các ví dụ ngắn gọn. `SaveOriginalImage` ghi các byte nhúng gốc, chọn phần mở rộng an toàn từ loại MIME và bỏ qua các ảnh nhị phân trùng lặp bằng hàm băm SHA-256.

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

## **Trích xuất Hình ảnh từ Khung Ảnh**

Sử dụng cách tiếp cận này cho các ảnh được chèn dưới dạng đối tượng độc lập. Một [IPictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframe/) lưu ảnh của nó trong `PictureFormat.Picture.Image`, trả về một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) .

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

## **Trích xuất Hình ảnh từ Hình dạng Được Điền Hình ảnh**

Các hình dạng có thể sử dụng một bức ảnh làm nền. Kiểm tra loại nền của hình dạng trước: nếu không phải là [FillType.Picture](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/), thì không có ảnh nào để trích xuất từ nền đó. Ví dụ dưới đây xử lý các đối tượng [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) và lưu mỗi ảnh dưới dạng PNG qua [IPPImage.Image](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) .

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

## **Trích xuất Hình ảnh Xem trước từ Khung Đối tượng OLE**

Một [IOleObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ioleobjectframe/) có thể có một ảnh thay thế mà PowerPoint dùng làm xem trước của đối tượng trên slide. Ảnh này có sẵn qua `SubstitutePictureFormat.Picture.Image`. Trích xuất ảnh này sẽ cho bạn ảnh xem trước, không phải nội dung gói OLE được nhúng.

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

## **Trích xuất Hình ảnh Xem trước từ Khung Video**

Một [IVideoFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ivideoframe/) cũng có thể lưu một ảnh xem trước trong `PictureFormat.Picture.Image`. Đây là poster hoặc hình thu nhỏ hiển thị trên slide, không phải một khung được giải mã từ luồng video.

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

## **Trích xuất Hình ảnh Xem trước từ Khung Âm thanh**

Một [IAudioFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/iaudioframe/) có thể lưu một hình thu nhỏ trong `PictureFormat.Picture.Image`. Đây là ảnh hiển thị cho đối tượng âm thanh trên slide.

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

## **Trích xuất Hình ảnh từ Đối tượng Thu phóng**

[IZoomFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/izoomframe/) và [ISectionZoomFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/isectionzoomframe/) có thể sử dụng ảnh tùy chỉnh. Đọc `ZoomImage` từ khung thu phóng.

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

## **Trích xuất Hình ảnh từ Khung Thu phóng Tổng hợp**

Một [ISummaryZoomFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/isummaryzoomframe/) cũng là một hình dạng. Các mục phần có thể sử dụng ảnh tùy chỉnh, được cung cấp qua thuộc tính `ZoomImage` của từng phần tổng hợp.

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

## **Trích xuất Hình ảnh từ Hình dạng Bảng**

Một [ITable](https://reference.aspose.com/slides/vi/net/aspose.slides/itable/) là một hình dạng. Hình ảnh trong bảng thường được lưu dưới dạng nền ảnh trong các ô bảng.

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

## **Trích xuất Hình ảnh từ Hình dạng Biểu đồ**

Một [IChart](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichart/) là một hình dạng. Ví dụ dưới đây trích xuất ảnh từ nền ảnh của vùng biểu đồ.

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

## **Trích xuất Hình ảnh từ Hình dạng SmartArt**

Một [ISmartArt](https://reference.aspose.com/slides/vi/net/aspose.slides.smartart/ismartart/) là một hình dạng. Tùy thuộc vào bố cục SmartArt, hình ảnh có thể được lưu trong nền bullet của nút hoặc trong định dạng nền của các hình dạng nút.

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

## **Bao gồm Hình ảnh bên trong Hình dạng Nhóm**

Các hình dạng nhóm chứa bộ sưu tập hình dạng riêng. Trợ giúp chung `EnumerateShapes` có tùy chọn `includeGroupedShapes`. Đặt thành `true` khi bạn muốn kiểm tra các hình dạng bên trong các đối tượng [IGroupShape](https://reference.aspose.com/slides/vi/net/aspose.slides/igroupshape/) . Ví dụ dưới đây trích xuất hình ảnh từ khung ảnh, hình dạng được điền ảnh, xem trước đối tượng OLE, hình thu nhỏ khung video và hình thu nhỏ khung âm thanh. Để bao gồm hình ảnh bảng, biểu đồ, SmartArt và thu phóng tổng hợp nữa, hãy tái sử dụng logic trích xuất chuyên biệt từ các phần trước trong khi duy trì cùng một quá trình duyệt hình dạng đệ quy.

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

## **Các Trường hợp Cực đoan và Ghi chú Thực tiễn**

- **Duplicate images:** Nhiều hình dạng có thể tham chiếu cùng một ảnh hoặc các ảnh riêng biệt có byte giống hệt nhau. Băm [IPPImage.BinaryData](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) trước khi ghi tệp nếu bạn muốn một tệp đầu ra cho mỗi ảnh duy nhất.
- **Original data vs. converted output:** Lưu [IPPImage.BinaryData](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) bảo tồn dữ liệu JPEG, PNG, GIF, SVG, EMF hoặc WMF đã nhúng. Lưu [IPPImage.Image](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) qua [IImage.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/) hữu ích khi bạn muốn định dạng đầu ra nhất quán.
- **Unsupported fill types:** Các hình dạng rắn, gradient, pattern và không nền không chứa ảnh nền. Kiểm tra [FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) trước khi đọc `PictureFillFormat`.
- **Grouped shapes:** Bộ sưu tập hình dạng slide cấp cao không làm phẳng các nhóm. Kiểm tra đệ quy [IGroupShape.Shapes](https://reference.aspose.com/slides/vi/net/aspose.slides/igroupshape/) khi nội dung nhóm quan trọng.
- **OLE object previews:** Một [IOleObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ioleobjectframe/) có thể hiển thị ảnh xem trước qua `SubstitutePictureFormat`, nhưng ảnh này chỉ là xem trước trên slide, không phải tệp được nhúng bên trong đối tượng OLE.
- **Video frame thumbnails:** Một [IVideoFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ivideoframe/) có thể hiển thị ảnh xem trước qua `PictureFormat`, nhưng ảnh này chỉ là poster hiển thị trên slide, không được trích xuất từ luồng video.
- **Audio frame thumbnails:** Một [IAudioFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/iaudioframe/) có thể hiển thị biểu tượng hoặc hình thu nhỏ qua `PictureFormat`; nó không phải là dữ liệu âm thanh được nhúng.
- **Zoom images:** Các hình dạng thu phóng slide, thu phóng phần và thu phóng tổng hợp có thể sử dụng các đối tượng [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) tùy chỉnh qua `ZoomImage`.
- **Nested shape models:** Các đối tượng bảng, biểu đồ và SmartArt thực hiện [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/), nhưng hình ảnh của chúng thường được lưu trong các đối tượng định dạng ô bảng, phần tử biểu đồ hoặc nút SmartArt lồng nhau.
- **Cropped or transformed pictures:** Truy cập [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) cho bạn tài nguyên ảnh đã lưu. Nó không áp dụng cắt, trong suốt, đổi màu, xoay hoặc các hiệu ứng trực quan khác mà hình dạng áp dụng.

## **Câu hỏi thường gặp**

**Tôi có thể trích xuất ảnh gốc mà không cắt, không hiệu ứng hay biến đổi hình dạng không?**

Có. Truy cập đối tượng [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) và ghi [IPPImage.BinaryData](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) ra đĩa. Điều này bảo tồn dữ liệu ảnh đã mã hoá gốc được lưu trong bản trình bày, không phải cách ảnh được hiển thị trên slide.

**Tôi có thể xuất mọi ảnh đã trích xuất dưới dạng PNG không?**

Có. Sử dụng [IPPImage.Image](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) để nhận một đối tượng [IImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/), sau đó gọi [IImage.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/) với [ImageFormat.Png](https://reference.aspose.com/slides/vi/net/aspose.slides/imageformat/). Điều này chuyển đổi đầu ra và có thể không bảo tồn kiểu tệp gốc hoặc dữ liệu vector.

**Làm sao tránh lưu cùng một ảnh nhiều lần?**

Sử dụng hàm băm của [IPPImage.BinaryData](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) và giữ các giá trị băm trong một tập hợp. Nếu ảnh mới có băm đã tồn tại, bỏ qua hoặc ghi nhận một tham chiếu khác tới tệp đầu ra hiện có.

**Tại sao một số hình dạng không tạo ra ảnh?**

Khung ảnh, hình dạng được điền ảnh, khung OLE, khung phương tiện, khung thu phóng, bảng, biểu đồ và đối tượng SmartArt có thể tham chiếu ảnh. Một số loại hình dạng công bố ảnh qua các đối tượng định dạng lồng nhau, vì vậy việc chỉ kiểm tra `PictureFormat` hoặc `FillFormat` của hình dạng không luôn đủ.

**Tôi có thể trích xuất hình thu nhỏ hiển thị cho khung video không?**

Có. Sử dụng [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ivideoframe/) và đọc `PictureFormat.Picture.Image`. Điều này trích xuất ảnh poster được lưu cùng với khung video, không phải một khung được tạo ra từ tệp video.

**Làm sao xác định hình dạng nào sử dụng một ảnh cụ thể từ bộ sưu tập ảnh của bản trình bày?**

Aspose.Slides không lưu liên kết ngược từ [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) tới các hình dạng. Xây dựng một ánh xạ trong quá trình duyệt: mỗi khi tìm thấy tham chiếu ảnh, ghi lại số slide, đường dẫn hình dạng và băm ảnh hoặc mục trong bộ sưu tập.

**Tôi có thể trích xuất ảnh nhúng trong đối tượng OLE, chẳng hạn như tài liệu đính kèm?**

Bạn có thể trích xuất ảnh xem trước slide của đối tượng OLE từ [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ioleobjectframe/). Tuy nhiên, ảnh xem trước này không phải là tài liệu được nhúng. Để trích xuất ảnh từ bên trong tệp nhúng, bạn cần xuất dữ liệu OLE và kiểm tra nó bằng các công cụ dành cho loại tệp tương ứng.