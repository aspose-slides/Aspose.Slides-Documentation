---
title: استخراج تصاویر از اشکال ارائه در .NET
linktitle: تصویر از شکل
type: docs
weight: 90
url: /fa/net/extracting-images-from-presentation-shapes/
keywords:
- استخراج تصویر
- بازیابی تصویر
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "تصاویر را از اشکال در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای .NET استخراج کنید - راه‌حل سریع و مناسب برای کدنویسی."
---
## **بررسی کلی**

تصاویر در یک ارائه می‌توانند در چندین نوع شکل ظاهر شوند: به عنوان فریم‌های تصویر معمولی، به عنوان پرکننده‌های تصویر که بر شکل‌ها اعمال می‌شوند، به عنوان تصاویر پیش‌نمایش شیء OLE، به عنوان تصویر بندانگشتی فریم‌های ویدئو یا صدا، به عنوان تصاویر زوم، یا به عنوان تصاویری که در داخل جدول، نمودار و اشکال SmartArt تو در تو هستند. Aspose.Slides این تصاویر را در مجموعه تصویر ارائه ذخیره می‌کند که از طریق اشیای [ImageCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/imagecollection/) و [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) در دسترس است.

اگر فقط نیاز به استخراج تمام منابع تصویری که در یک ارائه جاسازی شده‌اند دارید، می‌توانید از `presentation.Images` عبور کنید. این مقاله بر یک وظیفه متفاوت تمرکز دارد: پیمایش شکل‌ها برای یافتن مکان‌های استفاده از تصاویر در اسلایدها، به‌طوری‌که فایل‌های ذخیره‌شده بتوانند زمینهٔ مفیدی مانند شمارهٔ اسلاید، موقعیت شکل و نوع منبع (فریم تصویر، تصویر پرکننده، پیش‌نمایش رسانه، پیش‌نمایش OLE یا تصویر زوم) را حفظ کنند.

{{% alert title="Tip" color="primary" %}}
از [IPPImage.BinaryData](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) برای حفظ دادهٔ تصویر اصلی کدگذاری‌شده و نوع فایل استفاده کنید. وقتی می‌خواهید خروجی را به قالب خاصی مانند PNG نرمال کنید، از [IPPImage.Image](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) همراه با [IImage.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) بهره ببرید.
{{% /alert %}}

## **متدهای کمکی مشترک**

متدهای کمکی زیر مثال‌ها را کوتاه نگه می‌دارند. `SaveOriginalImage` بایت‌های جاسازی‌شدهٔ اصلی را می‌نویسد، پسوند امنی بر پایهٔ نوع MIME انتخاب می‌کند و تصویرهای تکراری باینری را با استفاده از هش SHA‑256 عبور می‌دهد.

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

## **استخراج تصاویر از فریم‌های تصویر**

از این روش برای تصاویری که به‌عنوان اشیای مستقل وارد می‌شوند استفاده کنید. یک [IPictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ipictureframe/) تصویر خود را در `PictureFormat.Picture.Image` ذخیره می‌کند که یک شیء [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) بازمی‌گرداند.

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

## **استخراج تصاویر از شکل‌های پرکننده با تصویر**

شکل‌ها می‌توانند تصویر را به‌عنوان پرکنندهٔ خود استفاده کنند. ابتدا نوع پرکنندهٔ شکل را بررسی کنید: اگر برابر با [FillType.Picture](https://reference.aspose.com/slides/fa/net/aspose.slides/filltype/) نباشد، تصویری برای استخراج از این پرکننده وجود ندارد. مثال زیر اشیای [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) را مدیریت می‌کند و هر تصویر را از طریق [IPPImage.Image](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) به‌صورت PNG ذخیره می‌نماید.

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

## **استخراج تصاویر پیش‌نمایش از فریم‌های شیء OLE**

یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ioleobjectframe/) می‌تواند تصویر جایگزینی داشته باشد که PowerPoint به‌عنوان پیش‌نمایش شیء در اسلاید استفاده می‌کند. این تصویر از طریق `SubstitutePictureFormat.Picture.Image` قابل دسترسی است. استخراج این تصویر پیش‌نمایش را به‌دست می‌دهد، نه محتویات بستهٔ OLE جاسازی‌شده.

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

## **استخراج تصاویر پیش‌نمایش از فریم‌های ویدئو**

یک [IVideoFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/) نیز می‌تواند تصویر پیش‌نمایشی در `PictureFormat.Picture.Image` ذخیره کند. این تصویر پوستر یا بندانگشتی است که در اسلاید نمایش داده می‌شود، نه فریمی که از جریان ویدئو رمزگشایی شده باشد.

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

## **استخراج تصاویر پیش‌نمایش از فریم‌های صدا**

یک [IAudioFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/iaudioframe/) می‌تواند یک تصویر بندانگشتی در `PictureFormat.Picture.Image` ذخیره کند. این همان تصویری است که برای شیء صدا در اسلاید نشان داده می‌شود.

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

## **استخراج تصاویر از اشیای زوم**

اشکال [IZoomFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/izoomframe/) و [ISectionZoomFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/isectionzoomframe/) می‌توانند از تصاویر سفارشی استفاده کنند. `ZoomImage` را از فریم زوم بخوانید.

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

## **استخراج تصاویر از فریم‌های زوم خلاصه**

یک [ISummaryZoomFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/isummaryzoomframe/) نیز یک شکل است. موارد بخش آن می‌توانند از تصاویر سفارشی استفاده کنند که از طریق ویژگی `ZoomImage` هر بخش زوم خلاصه در دسترس است.

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

## **استخراج تصاویر از اشکال جدول**

یک [ITable](https://reference.aspose.com/slides/fa/net/aspose.slides/itable/) یک شکل است. تصاویر در یک جدول معمولاً به‌صورت پرکنندهٔ تصویر در سلول‌های جدول ذخیره می‌شوند.

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

## **استخراج تصاویر از اشکال نمودار**

یک [IChart](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichart/) یک شکل است. مثال زیر تصویری را از پرکنندهٔ تصویر ناحیهٔ نمودار استخراج می‌کند.

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

## **استخراج تصاویر از اشکال SmartArt**

یک شیء [ISmartArt](https://reference.aspose.com/slides/fa/net/aspose.slides.smartart/ismartart/) یک شکل است. بسته به چیدمان SmartArt، ممکن است تصاویر در پرکننده‌های گلولهٔ گره یا در فرمت‌های پرکنندهٔ اشکال گره‌ها ذخیره شوند.

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

## **شامل کردن تصاویر داخل اشکال گروهی**

اشکال گروهی مجموعهٔ شکل‌های خود را دارند. متد کمکی مشترک `EnumerateShapes` گزینهٔ `includeGroupedShapes` دارد. وقتی می‌خواهید داخل اشیای [IGroupShape](https://reference.aspose.com/slides/fa/net/aspose.slides/igroupshape/) را بررسی کنید، آن را به `true` تنظیم کنید. مثال زیر تصاویر را از فریم‌های تصویر، شکل‌های پرکننده با تصویر، پیش‌نمایش‌های شیء OLE، بندانگشتی‌های فریم ویدئو و بندانگشتی‌های فریم صدا استخراج می‌کند. برای شامل کردن تصاویر جدول، نمودار، SmartArt و زوم خلاصه نیز، منطق استخراج تخصصی بخش‌های قبلی را بازاستفاده کنید و همان عبور بازگشتی اشکال را حفظ کنید.

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

## **موارد حاشیه‌ای و نکات عملی**

- **تصاویر تکراری:** ممکن است چندین شکل به یک تصویر اشاره کنند یا تصاویری جداگانه با بایت‌های یکسان داشته باشند. قبل از نوشتن فایل‌ها، [IPPImage.BinaryData](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) را هش کنید تا برای هر تصویر منحصر به‌فرد یک فایل خروجی داشته باشید.
- **دادهٔ اصلی در مقابل خروجی تبدیل‌شده:** ذخیرهٔ [IPPImage.BinaryData](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) دادهٔ JPEG، PNG، GIF، SVG، EMF یا WMF جاسازی‌شده را حفظ می‌کند. ذخیرهٔ [IPPImage.Image](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) از طریق [IImage.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) زمانی مفید است که به قالب خروجی ثابت مثل PNG نیاز داشته باشید.
- **انواع پرکنندهٔ پشتیبانی‌نشده:** شکل‌های Solid، Gradient، Pattern و No‑Fill تصویر پرکننده‌ای ندارند. قبل از خواندن `PictureFillFormat`، [FillType](https://reference.aspose.com/slides/fa/net/aspose.slides/filltype/) را بررسی کنید.
- **اشکال گروهی:** مجموعهٔ شکل‌های اسلاید در سطح بالا گروه‌ها را مسطح نمی‌کند. وقتی محتویات گروه مهم است، به‌صورت بازگشتی [IGroupShape.Shapes](https://reference.aspose.com/slides/fa/net/aspose.slides/igroupshape/) را بررسی کنید.
- **پیش‌نمایش‌های شیء OLE:** یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ioleobjectframe/) ممکن است تصویر پیش‌نمایشی از طریق `SubstitutePictureFormat` ارائه دهد، اما این تصویر فقط پیش‌نمایش اسلاید است و نه فایل جاسازی‌شده داخل شیء OLE.
- **بندانگشتی‌های فریم ویدئو:** یک [IVideoFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/) ممکن است تصویر پیش‌نمایشی از طریق `PictureFormat` ارائه دهد، اما این تصویر فقط پوستر نمایش‌داده‌شده در اسلاید است و نه فریمی که از جریان ویدئو استخراج شده.
- **بندانگشتی‌های فریم صدا:** یک [IAudioFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/iaudioframe/) ممکن است یک نماد یا بندانگشتی از طریق `PictureFormat` ارائه دهد؛ این تصویر خود دادهٔ صوتی جاسازی‌شده نیست.
- **تصاویر زوم:** اشکال زوم اسلاید، زوم بخش و زوم خلاصه می‌توانند اشیای سفارشی [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) از طریق `ZoomImage` داشته باشند.
- **مدل‌های تو در توی شکل:** اشیای جدول، نمودار و SmartArt پیاده‌سازی [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/) را دارند، اما تصاویرشان اغلب در اشیای قالب‌بندی سلول جدول، عنصر نمودار یا گره SmartArt تو در تو ذخیره می‌شود.
- **تصاویر برش‌خورده یا تبدیل‌شده:** دسترسی به [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) تنها منبع تصویری ذخیره‌شده را می‌دهد؛ این روش برش، شفافیت، تغییر رنگ، چرخش یا سایر افکت‌های بصری اعمال‌شده توسط شکل را رندر نمی‌کند.

## **سوالات متداول**

**آیا می‌توانم تصویر اصلی را بدون برش، افکت یا تبدیل شکل استخراج کنم؟**

بله. شیء [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) را دسترسی پیدا کنید و [IPPImage.BinaryData](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) را بر روی دیسک بنویسید. این کار تصویر اصلی کدگذاری‌شدهٔ ذخیره‌شده در ارائه را حفظ می‌کند، نه طریقی که تصویر در اسلاید رندر می‌شود.

**آیا می‌توانم تمام تصاویر استخراج‌شده را به‌صورت PNG صادر کنم؟**

بله. از [IPPImage.Image](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) برای دریافت یک شیء [IImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) استفاده کنید و سپس با [IImage.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) همراه با [ImageFormat.Png](https://reference.aspose.com/slides/fa/net/aspose.slides/imageformat/) ذخیره کنید. این کار خروجی را به PNG تبدیل می‌کند و ممکن است نوع فایل اصلی یا داده‌های برداری را حفظ نکند.

**چگونه می‌توانم از ذخیرهٔ یک تصویر بیش از یک بار جلوگیری کنم؟**

هش [IPPImage.BinaryData](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) را محاسبه کنید و هش‌ها را در یک مجموعه نگه دارید. اگر تصویری جدید هش مساوی با هش موجود داشته باشد، آن را نادیده بگیرید یا مرجع دیگری به فایل خروجی موجود ثبت کنید.

**چرا برخی از شکل‌ها تصویر تولید نمی‌کنند؟**

فریم‌های تصویر، شکل‌های پرکننده با تصویر، فریم‌های شیء OLE، فریم‌های رسانه، فریم‌های زوم، جداول، نمودارها و اشیای SmartArt می‌توانند به تصاویر ارجاع دهند. برخی انواع شکل‌ها تصویری را از طریق اشیای قالب‌بندی تو در تو ارائه می‌دهند، بنابراین یک بررسی سادهٔ `PictureFormat` یا `FillFormat` شکل همیشه کافی نیست.

**آیا می‌توانم بندانگشتی نمایش‌داده‌شده برای فریم ویدئو را استخراج کنم؟**

بله. از [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/) استفاده کنید و `PictureFormat.Picture.Image` را بخوانید. این تصویر پوستر ذخیره‌شده با فریم ویدئو را استخراج می‌کند، نه فریمی که از فایل ویدئویی تولید شده باشد.

**چگونه می‌توانم تشخیص دهم کدام شکل‌ها از تصویر خاصی در مجموعه تصویر ارائه استفاده می‌کنند؟**

Aspose.Slides پیوند معکوسی از [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) به شکل‌ها ذخیره نمی‌کند. در حین پیمایش، هر زمان که به یک ارجاع تصویر برخوردید، شمارهٔ اسلاید، مسیر شکل و هش یا آیتم مجموعه تصویر را ثبت کنید.

**آیا می‌توانم تصاویر جاسازی‌شده داخل اشیای OLE، مانند اسناد پیوست‌شده، را استخراج کنم؟**

می‌توانید پیش‌نمایش اسلاید شیء OLE را از [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ioleobjectframe/) استخراج کنید. اما این پیش‌نمایش خود سند جاسازی‌شده نیست. برای استخراج تصاویر از داخل فایل جاسازی‌شده، دادهٔ OLE را استخراج کنید و با ابزارهای مربوط به آن نوع فایل بررسی نمایید.