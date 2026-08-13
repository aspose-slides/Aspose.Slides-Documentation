---
title: 프레젠테이션 도형에서 이미지 추출 (.NET)
linktitle: 도형의 이미지
type: docs
weight: 90
url: /ko/net/extracting-images-from-presentation-shapes/
keywords:
- 이미지 추출
- 이미지 가져오기
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 도형에서 이미지를 추출합니다 - 빠르고 코드 친화적인 솔루션."
---
## **개요**

프레젠테이션의 이미지는 여러 형태 유형으로 나타날 수 있습니다: 일반 사진 프레임, 도형에 적용된 사진 채우기, OLE 개체 미리보기 이미지, 비디오 또는 오디오 프레임 썸네일, 줌 이미지, 혹은 표, 차트 및 SmartArt 도형 내부에 중첩된 이미지 등. Aspose.Slides는 이러한 이미지를 프레젠테이션 이미지 컬렉션에 저장하며, 이는 [ImageCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/imagecollection/) 및 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/) 객체를 통해 노출됩니다.

프레젠테이션에 포함된 모든 이미지 리소스를 내보내기만 하면 된다면 `presentation.Images`를 순회하면 됩니다. 이 문서는 다른 작업에 초점을 맞춥니다: 슬라이드에서 이미지가 사용된 위치를 찾기 위해 도형을 탐색하고, 저장된 파일에 슬라이드 번호, 도형 위치 및 원본 유형(사진 프레임, 채우기 이미지, 미디어 미리보기, OLE 미리보기 또는 줌 이미지)과 같은 유용한 컨텍스트를 유지하도록 합니다.

{{% alert title="Tip" color="info" %}}
[IPPImage.BinaryData](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/)을 사용하면 원본 인코딩된 이미지 데이터와 파일 형식을 보존할 수 있습니다. 특정 형식(PNG 등)으로 출력을 정규화하려면 [IPPImage.Image](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/)와 [IImage.Save](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/)를 사용하십시오.
{{% /alert %}}

## **공유 헬퍼 메서드**

아래 헬퍼 메서드는 예제를 간결하게 유지합니다. `SaveOriginalImage`는 원본 임베드된 바이트를 기록하고 MIME 유형에서 안전한 확장자를 선택하며 SHA-256 해시로 중복 이미지 바이너리를 건너뜁니다.

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

## **사진 프레임에서 이미지 추출**

독립 객체로 삽입된 사진에 대해 이 방법을 사용하십시오. [IPictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ipictureframe/)은 사진을 `PictureFormat.Picture.Image`에 저장하며, 이는 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/) 객체를 반환합니다.

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

## **그림 채워진 도형에서 이미지 추출**

도형은 그림을 채우기로 사용할 수 있습니다. 먼저 도형의 채우기 유형을 확인하십시오: [FillType.Picture](https://reference.aspose.com/slides/ko/net/aspose.slides/filltype/)이 아닌 경우 해당 채우기에서 추출할 그림이 없습니다. 아래 예제는 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/) 객체를 처리하고 각 이미지를 [IPPImage.Image](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/)을 통해 PNG로 저장합니다.

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

## **OLE 개체 프레임에서 미리보기 이미지 추출**

[IOleObjectFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ioleobjectframe/)는 PowerPoint가 슬라이드에서 개체의 미리보기로 사용하는 대체 그림을 가질 수 있습니다. 이 이미지에는 `SubstitutePictureFormat.Picture.Image`를 통해 접근할 수 있습니다. 이 그림을 추출하면 미리보기 이미지를 얻을 수 있으며, 임베드된 OLE 패키지 내용은 아닙니다.

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

## **비디오 프레임에서 미리보기 이미지 추출**

[IVideoFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ivideoframe/)도 `PictureFormat.Picture.Image`에 미리보기 이미지를 저장할 수 있습니다. 이는 슬라이드에 표시되는 포스터 또는 썸네일이며, 비디오 스트림에서 디코드된 프레임이 아닙니다.

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

## **오디오 프레임에서 미리보기 이미지 추출**

[IAudioFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/iaudioframe/)는 `PictureFormat.Picture.Image`에 썸네일을 저장할 수 있습니다. 이는 슬라이드에 표시되는 오디오 객체용 이미지입니다.

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

## **줌 개체에서 이미지 추출**

[IZoomFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/izoomframe/)와 [ISectionZoomFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/isectionzoomframe/) 도형은 사용자 지정 이미지를 사용할 수 있습니다. 줌 프레임에서 `ZoomImage`를 읽으십시오.

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

## **요약 줌 프레임에서 이미지 추출**

[ISummaryZoomFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/isummaryzoomframe/)도 도형입니다. 해당 섹션 항목은 사용자 지정 이미지를 사용할 수 있으며, 각 요약 줌 섹션의 `ZoomImage` 속성을 통해 노출됩니다.

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

## **표 도형에서 이미지 추출**

[ITable](https://reference.aspose.com/slides/ko/net/aspose.slides/itable/)은 도형입니다. 표의 이미지들은 일반적으로 표 셀의 그림 채우기로 저장됩니다.

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

## **차트 도형에서 이미지 추출**

[IChart](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichart/)은 도형입니다. 아래 예제는 차트 영역의 그림 채우기에서 이미지를 추출합니다.

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

## **SmartArt 도형에서 이미지 추출**

[ISmartArt](https://reference.aspose.com/slides/ko/net/aspose.slides.smartart/ismartart/) 객체는 도형입니다. SmartArt 레이아웃에 따라 이미지는 노드 글머리 기호 채우기 또는 노드 도형의 채우기 형식에 저장될 수 있습니다.

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

## **그룹화된 도형 내 이미지 포함**

그룹화된 도형은 자체 도형 컬렉션을 포함합니다. 공유된 `EnumerateShapes` 헬퍼에는 `includeGroupedShapes` 옵션이 있습니다. [IGroupShape](https://reference.aspose.com/slides/ko/net/aspose.slides/igroupshape/) 객체 내부의 도형을 검사하려면 이를 `true`로 설정하십시오. 아래 예제는 사진 프레임, 그림 채워진 도형, OLE 개체 미리보기, 비디오 프레임 썸네일 및 오디오 프레임 썸네일에서 이미지를 추출합니다. 표, 차트, SmartArt 및 요약 줌 이미지를 포함하려면 이전 섹션의 특수 추출 로직을 재사용하면서 동일한 재귀 도형 순회를 유지하십시오.

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

## **예외 상황 및 실용적인 참고사항**

- **Duplicate images:** 여러 도형이 동일한 이미지를 참조하거나 바이트가 동일한 별도 이미지를 가질 수 있습니다. 고유 이미지당 하나의 파일을 원한다면 파일을 기록하기 전에 [IPPImage.BinaryData](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/)의 해시를 확인하십시오.
- **Original data vs. converted output:** [IPPImage.BinaryData](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/)를 저장하면 임베드된 JPEG, PNG, GIF, SVG, EMF 또는 WMF 데이터를 보존합니다. [IPPImage.Image](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/)를 [IImage.Save](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/)와 함께 저장하면 PNG와 같이 일관된 출력 형식으로 변환됩니다.
- **Unsupported fill types:** 단색, 그라디언트, 패턴 및 무채우기 도형은 그림 채우기를 포함하지 않습니다. `PictureFillFormat`을 읽기 전에 [FillType](https://reference.aspose.com/slides/ko/net/aspose.slides/filltype/)을 확인하십시오.
- **Grouped shapes:** 최상위 슬라이드 도형 컬렉션은 그룹을 평탄화하지 않습니다. 그룹화된 내용이 중요할 경우 [IGroupShape.Shapes](https://reference.aspose.com/slides/ko/net/aspose.slides/igroupshape/)를 재귀적으로 검사하십시오.
- **OLE object previews:** [IOleObjectFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ioleobjectframe/)는 `SubstitutePictureFormat`을 통해 미리보기 이미지를 제공할 수 있지만, 이는 슬라이드 미리보기일 뿐이며 OLE 개체 내부의 임베드된 파일은 아닙니다.
- **Video frame thumbnails:** [IVideoFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ivideoframe/)는 `PictureFormat`을 통해 미리보기 이미지를 제공할 수 있지만, 이는 슬라이드에 표시되는 포스터일 뿐이며 비디오 스트림에서 추출된 프레임이 아닙니다.
- **Audio frame thumbnails:** [IAudioFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/iaudioframe/)는 `PictureFormat`을 통해 아이콘 또는 썸네일을 제공할 수 있으며, 이는 임베드된 오디오 데이터가 아닙니다.
- **Zoom images:** 슬라이드 줌, 섹션 줌 및 요약 줌 도형은 `ZoomImage`를 통해 사용자 지정 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/) 객체를 사용할 수 있습니다.
- **Nested shape models:** 표, 차트 및 SmartArt 객체는 [IShape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/)를 구현하지만, 그 이미지들은 종종 중첩된 표 셀, 차트 요소 또는 SmartArt 노드 서식 개체에 저장됩니다.
- **Cropped or transformed pictures:** [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/)에 접근하면 저장된 이미지 리소스를 얻을 수 있지만, 도형이 적용한 자르기, 투명도, 재색상, 회전 또는 기타 시각 효과는 반영되지 않습니다.

## **FAQ**

### 원본 이미지를 자르기, 효과, 또는 도형 변환 없이 추출할 수 있나요?

예. [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/) 객체에 접근하고 [IPPImage.BinaryData](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/)를 디스크에 기록하면 프레젠테이션에 저장된 원본 인코딩 이미지를 보존합니다. 이는 슬라이드에 표시되는 방식과는 무관합니다.

### 추출한 모든 이미지를 PNG로 내보낼 수 있나요?

예. [IPPImage.Image](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/)를 사용해 [IImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/) 객체를 얻은 다음, [IImage.Save](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/)에 [ImageFormat.Png](https://reference.aspose.com/slides/ko/net/aspose.slides/imageformat/)을 지정하여 저장하십시오. 이렇게 하면 출력 형식이 변환되며 원본 파일 형식이나 벡터 데이터는 보존되지 않을 수 있습니다.

### 동일한 이미지를 여러 번 저장하지 않으려면 어떻게 해야 하나요?

[IPPImage.BinaryData](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/)의 해시를 계산하고 해시 집합에 보관하십시오. 새 이미지의 해시가 이미 존재하면 해당 이미지를 건너뛰거나 기존 출력 파일에 대한 또 다른 참조를 기록하십시오.

### 일부 도형에서 이미지가 생성되지 않는 이유는 무엇인가요?

사진 프레임, 그림 채워진 도형, OLE 개체 프레임, 미디어 프레임, 줌 프레임, 표, 차트 및 SmartArt 객체는 이미지를 참조할 수 있습니다. 그러나 일부 도형 유형은 중첩된 서식 객체를 통해 이미지를 노출하므로 단순히 `PictureFormat`이나 도형 `FillFormat`만 확인하는 것으로는 충분하지 않을 수 있습니다.

### 비디오 프레임에 표시되는 썸네일을 추출할 수 있나요?

예. [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ivideoframe/)에 접근하고 `PictureFormat.Picture.Image`를 읽으면 비디오 프레임에 저장된 포스터 이미지를 추출할 수 있습니다. 이는 비디오 파일에서 생성된 프레임이 아니라 슬라이드에 저장된 썸네일입니다.

### 프레젠테이션 이미지 컬렉션에서 특정 이미지를 사용하는 도형을 어떻게 파악할 수 있나요?

Aspose.Slides는 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/)에서 도형으로의 역링크를 저장하지 않습니다. 순회 중에 이미지가 발견될 때마다 슬라이드 번호, 도형 경로 및 이미지 해시 또는 컬렉션 항목을 기록하여 매핑을 구축하십시오.

### OLE 개체 내부에 포함된 문서와 같은 이미지도 추출할 수 있나요?

[IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ioleobjectframe/)를 통해 OLE 개체의 슬라이드 미리보기 이미지는 추출할 수 있지만, 해당 미리보기는 임베드된 문서 자체가 아닙니다. 임베드된 파일 내부의 이미지를 추출하려면 OLE 데이터를 추출한 뒤 해당 파일 형식에 맞는 도구로 검토해야 합니다.