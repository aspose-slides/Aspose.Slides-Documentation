---
title: استخراج الصور من أشكال العرض التقديمي في .NET
linktitle: صورة من الشكل
type: docs
weight: 90
url: /ar/net/extracting-images-from-presentation-shapes/
keywords:
- استخراج صورة
- استرجاع صورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استخراج الصور من الأشكال في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides لـ .NET - حل سريع ومناسب للبرمجة."
---
## **نظرة عامة**

يمكن أن تظهر الصور في عرض تقديمي بأنواع متعددة من الأشكال: كإطارات صور عادية، كملء صور يُطبق على الأشكال، كصور معاينة لكائن OLE، كصغار صورة لإطارات الفيديو أو الصوت، كصور تكبير، أو كصور مدمجة داخل جداول أو مخططات أو أشكال SmartArt. تقوم Aspose.Slides بتخزين هذه الصور في مجموعة صور العرض التقديمي، والتي يمكن الوصول إليها عبر كائنات [مجموعة الصور](https://reference.aspose.com/slides/ar/net/aspose.slides/imagecollection/) و[IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/).

إذا كنت تحتاج فقط إلى تصدير كل موارد الصورة المدمجة في عرض تقديمي، فقم بالتكرار عبر `presentation.Images`. يركز هذا المقال على مهمة مختلفة: استعراض الأشكال للعثور على الأماكن التي تُستخدم فيها الصور في الشرائح، بحيث يمكن للملفات المحفوظة الاحتفاظ بسياق مفيد مثل رقم الشريحة، موقع الشكل، ونوع المصدر (إطار صورة، صورة ملء، معاينة وسائط، معاينة OLE، أو صورة تكبير).

{{% alert title="Tip" color="info" %}}

استخدم [IPPImage.BinaryData](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) للحفاظ على بيانات الصورة الأصلية المشفرة ونوع الملف. استخدم [IPPImage.Image](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) مع [IImage.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/) عندما تريد توحيد المخرجات إلى تنسيق محدد مثل PNG.

{{% /alert %}}

## **طرق المساعدة المشتركة**

الطرق المساعدة أدناه تجعل الأمثلة مختصرة. `SaveOriginalImage` يكتب البايتات الأصلية المدمجة، يختار امتدادًا آمنًا من نوع MIME، ويتخطى الصور الثنائية المكررة باستخدام تجزئة SHA-256.

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

## **استخراج الصور من إطارات الصور**

استخدم هذا الأسلوب للصور التي تم إدراجها ككائنات مستقلة. يخزن [IPictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ipictureframe/) صورته في `PictureFormat.Picture.Image`، والذي يُعيد كائنًا من النوع [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/).

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

## **استخراج الصور من الأشكال المملوءة بالصور**

يمكن للأشكال استخدام صورة كملئ لها. تحقق أولاً من نوع ملئ الشكل: إذا لم يكن [FillType.Picture](https://reference.aspose.com/slides/ar/net/aspose.slides/filltype/)، فليس هناك صورة لاستخراجها من ذلك الملئ. المثال أدناه يتعامل مع كائنات [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) ويحفظ كل صورة كـ PNG عبر [IPPImage.Image](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/).

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

## **استخراج صور المعاينة من إطارات كائن OLE**

يمكن أن يحتوي [IOleObjectFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ioleobjectframe/) على صورة بديلة يستخدمها PowerPoint كمعاينة للكائن على الشريحة. تتوفر هذه الصورة عبر `SubstitutePictureFormat.Picture.Image`. استخراج هذه الصورة يمنحك صورة المعاينة، وليس محتويات حزمة OLE المدمجة.

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

## **استخراج صور المعاينة من إطارات الفيديو**

يمكن أيضًا أن يخزن [IVideoFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/) صورة معاينة في `PictureFormat.Picture.Image`. هذه هي الصورة أو المصغرة المعروضة على الشريحة، وليس إطارًا مُستخرجًا من تدفق الفيديو.

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

## **استخراج صور المعاينة من إطارات الصوت**

يمكن أن يخزن [IAudioFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/iaudioframe/) مصغرة في `PictureFormat.Picture.Image`. هذه هي الصورة المعروضة لكائن الصوت على الشريحة.

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

## **استخراج الصور من كائنات التكبير**

يمكن للأشكال [IZoomFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/izoomframe/) و[ISectionZoomFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/isectionzoomframe/) استخدام صور مخصصة. اقرأ `ZoomImage` من إطار التكبير.

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

## **استخراج الصور من إطارات التكبير الملخص**

كائن [ISummaryZoomFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/isummaryzoomframe/) هو أيضًا شكل. يمكن لعناصر القسم الخاصة به استخدام صور مخصصة، والتي تُظهر من خلال خاصية `ZoomImage` لكل قسم من أقسام التكبير الملخص.

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

## **استخراج الصور من أشكال الجداول**

كائن [ITable](https://reference.aspose.com/slides/ar/net/aspose.slides/itable/) هو شكل. عادةً ما تُخزن الصور في جدول كملئ صور داخل خلايا الجدول.

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

## **استخراج الصور من أشكال المخططات**

كائن [IChart](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichart/) هو شكل. المثال أدناه يستخرج صورة من ملء صورة منطقة المخطط.

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

## **استخراج الصور من أشكال SmartArt**

كائن [ISmartArt](https://reference.aspose.com/slides/ar/net/aspose.slides.smartart/ismartart/) هو شكل. اعتمادًا على تخطيط SmartArt، قد تُخزن الصور في ملء نقاط العقد أو في تنسيقات ملء أشكال العقد.

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

## **تضمين الصور داخل الأشكال المجمعة**

تحتوي الأشكال المجمعة على مجموعات الأشكال الخاصة بها. تحتوي أداة المساعدة المشتركة `EnumerateShapes` على خيار `includeGroupedShapes`. اضبطه على `true` عندما تريد فحص الأشكال داخل كائنات [IGroupShape](https://reference.aspose.com/slides/ar/net/aspose.slides/igroupshape/). المثال أدناه يستخرج الصور من إطارات الصور، الأشكال المملوءة بالصور، معاينات كائن OLE، مصغرات إطارات الفيديو، ومصغرات إطارات الصوت. لتضمين صور الجداول، المخططات، SmartArt، وإطارات التكبير الملخص أيضًا، أعد استخدام منطق الاستخراج المتخصص من الأقسام السابقة مع الحفاظ على نفس الاستعراض المتداخل للأشكال.

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

## **حالات الحافة وملاحظات عملية**

- **الصور المكررة:** قد تشير أشكال متعددة إلى نفس الصورة أو إلى صور منفصلة ذات بايتات متطابقة. احسب تجزئة [IPPImage.BinaryData](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) قبل كتابة الملفات إذا كنت ترغب في ملف إخراج واحد لكل صورة فريدة.
- **البيانات الأصلية مقابل الإخراج المحول:** حفظ [IPPImage.BinaryData](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) يحافظ على بيانات JPEG أو PNG أو GIF أو SVG أو EMF أو WMF المدمجة. حفظ [IPPImage.Image](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) عبر [IImage.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/) مفيد عندما تريد تنسيق إخراج موحد.
- **أنواع الملء غير المدعومة:** الأشكال الصلبة، المتدرجة، المنقوشة، أو بدون ملء لا تحتوي على ملء صورة. تحقق من [FillType](https://reference.aspose.com/slides/ar/net/aspose.slides/filltype/) قبل قراءة `PictureFillFormat`.
- **الأشكال المجمعة:** مجموعة أشكال الشريحة ذات المستوى الأعلى لا تقوم بفك التجميع. قم بفحص [IGroupShape.Shapes](https://reference.aspose.com/slides/ar/net/aspose.slides/igroupshape/) بشكل متكرر عندما يكون المحتوى المجمّع مهمًا.
- **معاينات كائن OLE:** قد يُظهر [IOleObjectFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ioleobjectframe/) صورة معاينة عبر `SubstitutePictureFormat`، لكن هذه الصورة هي فقط معاينة الشريحة. ليست الملف المدمج داخل كائن OLE.
- **مصغرات إطارات الفيديو:** قد يُظهر [IVideoFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/) صورة معاينة عبر `PictureFormat`، لكن هذه الصورة هي فقط الملصق المعروض على الشريحة. ليست مستخرجة من تدفق الفيديو.
- **مصغرات إطارات الصوت:** قد يُظهر [IAudioFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/iaudioframe/) أيقونة أو مصغرة عبر `PictureFormat`؛ ليست بيانات الصوت المدمجة.
- **صور التكبير:** قد تستخدم أشكال تكبير الشريحة، تكبير القسم، وتكبير الملخص كائنات [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) مخصصة عبر `ZoomImage`.
- **نماذج الأشكال المتداخلة:** كائنات الجدول، المخطط، وSmartArt تنفذ [IShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/)، لكن صورها غالبًا ما تُخزن في خلايا الجدول المتداخلة، عنصر المخطط، أو كائنات تنسيق عقد SmartArt.
- **الصور المقصوصة أو المحوّلة:** الوصول إلى [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) يمنحك مورد الصورة المخزن. لا يقوم بعرض القص، الشفافية، إعادة التلوين، الدوران، أو غيرها من التأثيرات البصرية التي يطبقها الشكل.

## **الأسئلة المتكررة**

### هل يمكنني استخراج الصورة الأصلية دون قص أو تأثيرات أو تحولات الشكل؟

نعم. قم بالوصول إلى كائن [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) واكتب [IPPImage.BinaryData](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) إلى القرص. هذا يحافظ على الصورة المشفرة الأصلية المخزنة في العرض التقديمي، وليس الطريقة التي يتم عرض الصورة بها على الشريحة.

### هل يمكنني تصدير كل صورة مستخرجة كـ PNG؟

نعم. استخدم [IPPImage.Image](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) للحصول على كائن [IImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/)، ثم استدعِ [IImage.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/) باستخدام [ImageFormat.Png](https://reference.aspose.com/slides/ar/net/aspose.slides/imageformat/). هذا يحول المخرجات وقد لا يحافظ على نوع الملف الأصلي أو البيانات المتجهة.

### كيف يمكنني تجنب حفظ نفس الصورة أكثر من مرة؟

استخدم تجزئة [IPPImage.BinaryData](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) واحتفظ بالتجزئات في مجموعة. إذا كانت صورة جديدة لها تجزئة موجودة بالفعل، فتخطها أو سجّل إشارة أخرى إلى ملف الإخراج الموجود.

### لماذا لا تنتج بعض الأشكال صورة؟

إطارات الصور، الأشكال المملوءة بالصور، إطارات كائن OLE، إطارات الوسائط، إطارات التكبير، الجداول، المخططات، وكائنات SmartArt يمكنها الإشارة إلى صور. بعض أنواع الأشكال تُظهر الصور من خلال كائنات تنسيق متداخلة، لذا فحص بسيط لـ `PictureFormat` أو `FillFormat` للشكل لا يكون دائمًا كافيًا.

### هل يمكنني استخراج المصغرة المعروضة لإطار الفيديو؟

نعم. استخدم [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/) واقرأ `PictureFormat.Picture.Image`. هذا يستخرج صورة الملصق المخزنة مع إطار الفيديو، ولا إطار مُولَّد من ملف الفيديو.

### كيف يمكنني تحديد الأشكال التي تستخدم صورة محددة من مجموعة صور العرض التقديمي؟

لا يقوم Aspose.Slides بتخزين روابط عكسية من [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) إلى الأشكال. قم بإنشاء خريطة أثناء الاستعراض: كلما وجدت إشارة إلى صورة، سجِّل رقم الشريحة، مسار الشكل، وتجزئة الصورة أو عنصر المجموعة.

### هل يمكنني استخراج الصور المدمجة داخل كائنات OLE، مثل المستندات المرفقة؟

يمكنك استخراج معاينة شريحة كائن OLE من [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ioleobjectframe/). ومع ذلك، هذه المعاينة ليست المستند المدمج نفسه. لاستخراج الصور من داخل الملف المدمج، استخرج بيانات OLE وتفحصها بأدوات مناسبة لذلك النوع من الملفات.