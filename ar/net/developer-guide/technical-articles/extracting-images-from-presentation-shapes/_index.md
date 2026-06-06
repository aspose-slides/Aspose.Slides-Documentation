---
title: استخراج الصور من أشكال العرض التقديمي في .NET
linktitle: صورة من الشكل
type: docs
weight: 90
url: /ar/net/extracting-images-from-presentation-shapes/
keywords:
- استخراج صورة
- استرداد صورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استخراج الصور من الأشكال في عروض PowerPoint و OpenDocument التقديمية باستخدام Aspose.Slides لـ .NET - حل سريع وصديق للمطورين."
---
## **نظرة عامة**

يمكن أن تظهر الصور في العرض التقديمي بأكثر من نوع من الأشكال: كإطارات صور عادية، أو كملء صور يُطبق على الأشكال، أو كصور معاينة لكائن OLE، أو كصورة مصغرة لإطار فيديو أو صوت، أو كصور تكبير، أو كصور متداخلة داخل جداول، مخططات، وأشكال SmartArt. تقوم Aspose.Slides بتخزين هذه الصور في مجموعة صور العرض التقديمي، التي تُعرض عبر كائنات [ImageCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/imagecollection/) و[IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) .

إذا كنت بحاجة فقط لتصدير كل مورد صورة مضمّن في العرض، قم بالتكرار عبر `presentation.Images`. يركز هذا المقال على مهمة مختلفة: استعراض الأشكال للعثور على أماكن استخدام الصور في الشرائح، بحيث يمكن للملفات المحفوظة الاحتفاظ بسياق مفيد مثل رقم الشريحة، موقع الشكل، ونوع المصدر (إطار صورة، صورة ملء، معاينة وسائط، معاينة OLE، أو صورة تكبير).

{{% alert title="نصيحة" color="primary" %}}
استخدم [IPPImage.BinaryData](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) للحفاظ على بيانات الصورة المشفرة الأصلية ونوع الملف. استخدم [IPPImage.Image](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) مع [IImage.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/) عندما تريد تطبيع المخرجات إلى تنسيق محدد مثل PNG.
{{% /alert %}}

## **طرق المساعدة المشتركة**

تُبقي طرق المساعدة أدناه الأمثلة مختصرة. يقوم `SaveOriginalImage` بكتابة البايتات المضمنة الأصلية، يختار امتدادًا آمنًا من نوع MIME، ويتخطى الصور المكررة عن طريق تجزئة SHA-256.

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

استخدم هذا الأسلوب للصور المُدرَجة ككائنات مستقلة. يخزن [IPictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ipictureframe/) صورته في `PictureFormat.Picture.Image`، والتي تُعيد كائنًا من نوع [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) .

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

## **استخراج الصور من الأشكال المملوءة بالصور**

يمكن للأشكال استخدام صورة كملء لها. تحقق أولًا من نوع ملء الشكل: إذا لم يكن [FillType.Picture](https://reference.aspose.com/slides/ar/net/aspose.slides/filltype/)، فلا توجد صورة لاستخراجها من هذا الملء. يتعامل المثال أدناه مع كائنات [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) ويُحفظ كل صورة كملف PNG عبر [IPPImage.Image](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) .

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

## **استخراج صور المعاينة من إطارات كائن OLE**

يمكن أن يحتوي [IOleObjectFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ioleobjectframe/) على صورة بديلة يستخدمها PowerPoint كمعاينة للكائن على الشريحة. تتوفر هذه الصورة عبر `SubstitutePictureFormat.Picture.Image`. استخراج هذه الصورة يمنحك صورة المعاينة، وليس محتوى حزمة OLE المضمّنة.

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

## **استخراج صور المعاينة من إطارات الفيديو**

يمكن أيضًا لـ[IVideoFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/) تخزين صورة معاينة في `PictureFormat.Picture.Image`. هذه هي الصورة أو المصغرة المعروضة على الشريحة، ليست إطارًا مُستخرجًا من تدفق الفيديو.

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

## **استخراج صور المعاينة من إطارات الصوت**

يمكن لـ[IAudioFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/iaudioframe/) تخزين صورة مصغرة في `PictureFormat.Picture.Image`. هذه هي الصورة المعروضة لكائن الصوت على الشريحة.

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

## **استخراج الصور من كائنات التكبير**

يمكن للأشكال [IZoomFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/izoomframe/) و[ISectionZoomFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/isectionzoomframe/) استخدام صور مخصصة. اقرأ `ZoomImage` من إطار التكبير.

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

## **استخراج الصور من إطارات التكبير الملخصة**

يُعد [ISummaryZoomFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/isummaryzoomframe/) أيضًا شكلًا. يمكن لعناصر القسم التابعة له استخدام صور مخصصة، تُعرض عبر خاصية `ZoomImage` لكل قسم تكبير ملخّص.

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

## **استخراج الصور من أشكال الجداول**

يُعد [ITable](https://reference.aspose.com/slides/ar/net/aspose.slides/itable/) شكلًا. تُخزن الصور في الجدول عادةً كملء صور داخل خلايا الجدول.

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

## **استخراج الصور من أشكال المخططات**

يُعد [IChart](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichart/) شكلًا. يَستخرِج المثال أدناه صورةً من ملء صورة منطقة المخطط.

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

## **استخراج الصور من أشكال SmartArt**

كائن [ISmartArt](https://reference.aspose.com/slides/ar/net/aspose.slides.smartart/ismartart/) هو شكل. بناءً على تخطيط SmartArt، قد تُخزن الصور في ملء نقاط العقد أو في تنسيقات ملء أشكال العقد.

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

## **تضمين الصور داخل الأشكال المجمّعة**

تحتوي الأشكال المجمّعة على مجموعات أشكال خاصة بها. يمتلك المساعد المشترك `EnumerateShapes` خيارًا `includeGroupedShapes`. اضبطه على `true` عندما تريد فحص الأشكال داخل كائنات [IGroupShape](https://reference.aspose.com/slides/ar/net/aspose.slides/igroupshape/) . يَستخرِج المثال أدناه الصور من إطارات الصور، الأشكال المملوءة بالصور، معاينات كائنات OLE، مصغرات إطارات الفيديو، ومصغرات إطارات الصوت. لتضمين صور الجداول، المخططات، SmartArt، وصور التكبير الملخّصة أيضًا، أعد استخدام منطق الاستخراج المتخصص من الأقسام السابقة مع الحفاظ على نفس عملية استعراض الأشكال المتكررة.

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

## **حالات الحافة والملاحظات العملية**

- **الصور المكررة:** قد تشير أشكال متعددة إلى نفس الصورة أو إلى صور منفصلة ذات بايتات متطابقة. احسب تجزئة [IPPImage.BinaryData](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) قبل كتابة الملفات إذا كنت تريد ملف ناتج واحد لكل صورة فريدة.
- **البيانات الأصلية مقابل المخرجات المحوَّلة:** حفظ [IPPImage.BinaryData](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) يحافظ على بيانات JPEG أو PNG أو GIF أو SVG أو EMF أو WMF المضمنة. حفظ [IPPImage.Image](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) عبر [IImage.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/) مفيد عندما تريد تنسيق مخرج ثابت.
- **أنواع الملء غير المدعومة:** لا تحتوي الأشكال الصلبة، المتدرجة، النمطية، ولا التي لا تحتوي على ملء على ملء صورة. تحقق من [FillType](https://reference.aspose.com/slides/ar/net/aspose.slides/filltype/) قبل قراءة `PictureFillFormat`.
- **الأشكال المجمّعة:** مجموعة أشكال الشريحة العليا لا تُبسط المجموعات. افحص بشكل متكرر [IGroupShape.Shapes](https://reference.aspose.com/slides/ar/net/aspose.slides/igroupshape/) عندما يكون محتوى المجموعة مهمًا.
- **معاينات كائن OLE:** قد يُظهر [IOleObjectFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ioleobjectframe/) صورة معاينة عبر `SubstitutePictureFormat`، لكن هذه الصورة هي فقط معاينة الشريحة. وهي ليست الملف المضمّن داخل كائن OLE.
- **مصغرات إطارات الفيديو:** قد يُظهر [IVideoFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/) صورة معاينة عبر `PictureFormat`، لكن هذه الصورة هي فقط الملصق المعروض على الشريحة. ولا تُستخرج من تدفق الفيديو.
- **مصغرات إطارات الصوت:** قد يُظهر [IAudioFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/iaudioframe/) أيقونة أو صورة مصغرة عبر `PictureFormat`؛ وهي ليست بيانات الصوت المضمنة.
- **صور التكبير:** قد تستخدم أشكال تكبير الشريحة، تكبير القسم، وتكبير الملخص [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) مخصصة عبر `ZoomImage`.
- **نماذج الأشكال المتداخلة:** تنفذ كائنات الجدول، المخطط، وSmartArt واجهة [IShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/)، لكن صورها غالبًا ما تُخزن في خلايا جدول متداخلة، عناصر المخطط، أو كائنات تنسيق عقد SmartArt.
- **الصور المقصوصة أو المُحوَّلة:** يقدِّم الوصول إلى [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) المورد الصوري المخزن. لا يُطبِّق القص، الشفافية، إعادة التلوين، الدوران أو أي تأثيرات بصرية أخرى طبقها الشكل.

## **الأسئلة الشائعة**

**هل يمكنني استخراج الصورة الأصلية بدون قص، أو تأثيرات، أو تحولات الشكل؟**

نعم. قم بالوصول إلى كائن [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) واكتب [IPPImage.BinaryData](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) إلى القرص. هذا يحافظ على الصورة المشفرة الأصلية المخزنة في العرض، وليس الطريقة التي تُعرض بها الصورة على الشريحة.

**هل يمكنني تصدير كل صورة مستخرجة كملف PNG؟**

نعم. استخدم [IPPImage.Image](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) للحصول على كائن [IImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/)، ثم استدعِ [IImage.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/) مع [ImageFormat.Png](https://reference.aspose.com/slides/ar/net/aspose.slides/imageformat/). هذا يحوِّل المخرجات وقد لا يحافظ على نوع الملف الأصلي أو البيانات المتجهة.

**كيف يمكنني تجنّب حفظ الصورة نفسها أكثر من مرة؟**

استخدم تجزئة [IPPImage.BinaryData](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) واحتفظ بالتجزئات في مجموعة. إذا كان للصورة الجديدة تجزئة موجودة مسبقًا، فتخطها أو سجِّل إشارة أخرى إلى ملف الإخراج الموجود.

**لماذا لا تُنتج بعض الأشكال صورة؟**

يمكن لإطارات الصور، الأشكال المملوءة بالصور، إطارات كائن OLE، إطارات الوسائط، إطارات التكبير، الجداول، المخططات، وكائنات SmartArt الإشارة إلى صور. بعض أنواع الأشكال تُظهر الصور عبر كائنات تنسيق متداخلة، لذا فإن فحص بسيط للـ`PictureFormat` أو `FillFormat` للشكل قد لا يكون كافيًا دائمًا.

**هل يمكنني استخراج الصورة المصغرة المعروضة لإطار فيديو؟**

نعم. استخدم [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/) واقرأ `PictureFormat.Picture.Image`. هذا يستخرج صورة الملصق المخزنة مع إطار الفيديو، وليس إطارًا مُولَّدًا من ملف الفيديو.

**كيف يمكنني تحديد الأشكال التي تستخدم صورة محددة من مجموعة صور العرض؟**

لا تقوم Aspose.Slides بتخزين روابط عكسية من [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) إلى الأشكال. بني خريطة أثناء الاستعراض: كلما وجدت إشارة إلى صورة، سجِّل رقم الشريحة، مسار الشكل، وتجزئة الصورة أو عنصر من المجموعة.

**هل يمكنني استخراج الصور المضمّنة داخل كائنات OLE، مثل المستندات المرفقة؟**

يمكنك استخراج معاينة شريحة كائن OLE من [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ioleobjectframe/). ومع ذلك، هذه المعاينة ليست المستند المضمّن نفسه. لاستخراج الصور من داخل الملف المضمّن، استخرج بيانات OLE وافحصها بأدوات مخصصة لنوع الملف.