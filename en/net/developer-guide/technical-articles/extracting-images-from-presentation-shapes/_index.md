---
title: Extract Images from Presentation Shapes in .NET
linktitle: Image from Shape
type: docs
weight: 90
url: /net/extracting-images-from-presentation-shapes/
keywords:
- extract image
- retrieve image
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Extract images from shapes in PowerPoint and OpenDocument presentations with Aspose.Slides for .NET - quick, code-friendly solution."
---

## **Overview**

Images in a presentation can appear in several shape types: as ordinary picture frames, as picture fills applied to shapes, as OLE object preview images, as video or audio frame thumbnails, as zoom images, or as images nested inside table, chart, and SmartArt shapes. Aspose.Slides stores those images in the presentation image collection, exposed through [ImageCollection](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/) and [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) objects.

If you only need to export every image resource embedded in a presentation, iterate through `presentation.Images`. This article focuses on a different task: traversing shapes to find where images are used on slides, so the saved files can keep useful context such as the slide number, shape position, and source type (picture frame, fill image, media preview, OLE preview, or zoom image).

{{% alert title="Tip" color="primary" %}}

Use [IPPImage.BinaryData](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) to preserve the original encoded image data and file type. Use [IPPImage.Image](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) with [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/) when you want to normalize the output to a specific format such as PNG.

{{% /alert %}}

## **Shared Helper Methods**

The helper methods below keep the examples short. `SaveOriginalImage` writes the original embedded bytes, chooses a safe extension from the MIME type, and skips duplicate image binaries by SHA-256 hash.

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

## **Extract Images from Picture Frames**

Use this approach for pictures inserted as standalone objects. An [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) stores its picture in `PictureFormat.Picture.Image`, which returns an [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) object.

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

## **Extract Images from Picture-Filled Shapes**

Shapes can use a picture as their fill. Check the shape's fill type first: if it is not [FillType.Picture](https://reference.aspose.com/slides/net/aspose.slides/filltype/), there is no picture to extract from that fill. The example below handles [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) objects and saves each image as PNG through [IPPImage.Image](https://reference.aspose.com/slides/net/aspose.slides/ippimage/).

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

## **Extract Preview Images from OLE Object Frames**

An [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) can have a substitute picture that PowerPoint uses as the object's preview on a slide. This image is available through `SubstitutePictureFormat.Picture.Image`. Extracting this picture gives you the preview image, not the embedded OLE package contents.

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

## **Extract Preview Images from Video Frames**

An [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) can also store a preview image in `PictureFormat.Picture.Image`. This is the poster or thumbnail shown on the slide, not a frame decoded from the video stream.

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

## **Extract Preview Images from Audio Frames**

An [IAudioFrame](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/) can store a thumbnail in `PictureFormat.Picture.Image`. This is the image shown for the audio object on the slide.

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

## **Extract Images from Zoom Objects**

[IZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/izoomframe/) and [ISectionZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isectionzoomframe/) shapes can use custom images. Read `ZoomImage` from the zoom frame.

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

## **Extract Images from Summary Zoom Frames**

An [ISummaryZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomframe/) is also a shape. Its section items can use custom images, exposed through each summary zoom section's `ZoomImage` property.

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

## **Extract Images from Table Shapes**

An [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) is a shape. Images in a table are usually stored as picture fills in table cells.

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

## **Extract Images from Chart Shapes**

An [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) is a shape. The example below extracts an image from the chart area's picture fill.

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

## **Extract Images from SmartArt Shapes**

An [ISmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/) object is a shape. Depending on the SmartArt layout, images may be stored in node bullet fills or in the fill formats of node shapes.

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

## **Include Images Inside Grouped Shapes**

Grouped shapes contain their own shape collections. The shared `EnumerateShapes` helper has an `includeGroupedShapes` option. Set it to `true` when you want to inspect shapes inside [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/) objects. The example below extracts images from picture frames, picture-filled shapes, OLE object previews, video frame thumbnails, and audio frame thumbnails. To include table, chart, SmartArt, and summary zoom images as well, reuse the specialized extraction logic from the previous sections while keeping the same recursive shape traversal.

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

## **Edge Cases and Practical Notes**

- **Duplicate images:** Multiple shapes may reference the same image or separate images with identical bytes. Hash [IPPImage.BinaryData](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) before writing files if you want one output file per unique image.
- **Original data vs. converted output:** Saving [IPPImage.BinaryData](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) preserves the embedded JPEG, PNG, GIF, SVG, EMF, or WMF data. Saving [IPPImage.Image](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) through [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/) is useful when you want a consistent output format.
- **Unsupported fill types:** Solid, gradient, pattern, and no-fill shapes do not contain a picture fill. Check [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) before reading `PictureFillFormat`.
- **Grouped shapes:** The top-level slide shape collection does not flatten groups. Recursively inspect [IGroupShape.Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/) when grouped content matters.
- **OLE object previews:** An [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) may expose a preview image through `SubstitutePictureFormat`, but that image is only the slide preview. It is not the embedded file inside the OLE object.
- **Video frame thumbnails:** An [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) may expose a preview image through `PictureFormat`, but that image is only the poster shown on the slide. It is not extracted from the video stream.
- **Audio frame thumbnails:** An [IAudioFrame](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/) may expose an icon or thumbnail through `PictureFormat`; it is not the embedded audio data.
- **Zoom images:** Slide zoom, section zoom, and summary zoom shapes may use custom [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) objects through `ZoomImage`.
- **Nested shape models:** Table, chart, and SmartArt objects implement [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), but their images are often stored in nested table cell, chart element, or SmartArt node formatting objects.
- **Cropped or transformed pictures:** Accessing [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) gives you the stored image resource. It does not render cropping, transparency, recoloring, rotation, or other visual effects applied by the shape.

## **FAQ**

**Can I extract the original image without cropping, effects, or shape transformations?**

Yes. Access the [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) object and write [IPPImage.BinaryData](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) to disk. This preserves the original encoded image stored in the presentation, not the way the image is rendered on the slide.

**Can I export every extracted image as PNG?**

Yes. Use [IPPImage.Image](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) to get an [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) object, and then call [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/) with [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/). This converts the output and may not preserve the original file type or vector data.

**How do I avoid saving the same image more than once?**

Use a hash of [IPPImage.BinaryData](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) and keep the hashes in a set. If a new image has a hash that already exists, skip it or record another reference to the existing output file.

**Why do some shapes not produce an image?**

Picture frames, picture-filled shapes, OLE object frames, media frames, zoom frames, tables, charts, and SmartArt objects can reference images. Some shape types expose images through nested formatting objects, so a simple `PictureFormat` or shape `FillFormat` check is not always enough.

**Can I extract the thumbnail shown for a video frame?**

Yes. Use [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) and read `PictureFormat.Picture.Image`. This extracts the poster image stored with the video frame, not a frame generated from the video file.

**How can I determine which shapes use a specific image from the presentation image collection?**

Aspose.Slides does not store reverse links from [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) to shapes. Build a mapping during traversal: whenever you find an image reference, record the slide number, shape path, and image hash or collection item.

**Can I extract images embedded inside OLE objects, such as attached documents?**

You can extract the OLE object's slide preview from [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/). However, that preview is not the embedded document itself. To extract images from inside the embedded file, extract the OLE data and inspect it with tools for that file type.
