---
title: استخراج تصاویر از اشکال ارائه در .NET
linktitle: تصویر از شکل
type: docs
weight: 90
url: /fa/net/extracting-images-from-presentation-shapes/
keywords:
- استخراج تصویر
- به‌دست آوردن تصویر
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "تصاویر را از اشکال در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای .NET استخراج کنید - راه‌حل سریع و مناسب برای کدنویسی."
---
## **نمای کلی**

تصاویر در یک ارائه می‌توانند در چندین نوع شکل ظاهر شوند: به‌عنوان فریم‌های تصویر عادی، به‌عنوان پرکننده‌های تصویری اعمال‌شده به شکل‌ها، به‌عنوان پیش‌نمایش‌های شیء OLE، به‌عنوان تصویرهای بندانگشتی فریم‌های ویدیو یا صدا، به‌عنوان تصاویر زوم، یا به‌عنوان تصاویری که در داخل جدول، نمودار و اشکال SmartArt تو در تو هستند. Aspose.Slides این تصاویر را در مجموعه تصاویر ارائه ذخیره می‌کند که از طریق اشیاء [ImageCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/imagecollection/) و [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) در دسترس است.

اگر فقط نیاز دارید تمام منابع تصویری جاسازی‌شده در یک ارائه را صادر کنید، از `presentation.Images` عبور کنید. این مقاله به وظیفه متفاوتی می‌پردازد: مرور شکل‌ها برای یافتن محل استفاده از تصاویر در اسلایدها، به‌طوری که فایل‌های ذخیره‌شده بتوانند زمینه مفیدی مانند شماره اسلاید، موقعیت شکل و نوع منبع (فریم تصویر، تصویر پرکننده، پیش‌نمایش رسانه، پیش‌نمایش OLE یا تصویر زوم) را حفظ کنند.

{{% alert title="Tip" color="info" %}}
از [IPPImage.BinaryData](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) برای حفظ داده‌های تصویر اصلی کدگذاری‌شده و نوع فایل استفاده کنید. هنگام نیاز به نرمال‌سازی خروجی به قالب خاصی مانند PNG، از [IPPImage.Image](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) به‌همراه [IImage.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) استفاده کنید.
{{% /alert %}}

## **متدهای کمکی مشترک**

متدهای کمکی زیر مثال‌ها را کوتاه نگه می‌دارند. `SaveOriginalImage` بایت‌های جاسازی‌شده اصلی را می‌نویسد، پسوند ایمن را از نوع MIME انتخاب می‌کند و با هش SHA-256 تصاویر دوباره تکراری را نادیده می‌گیرد.

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

از این روش برای تصاویری که به‌عنوان اشیای مستقل وارد شده‌اند استفاده کنید. یک [IPictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ipictureframe/) تصویر خود را در `PictureFormat.Picture.Image` ذخیره می‌کند که یک شیء [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) برمی‌گرداند.

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

## **استخراج تصاویر از شکل‌های پر شده با تصویر**

شکل‌ها می‌توانند به‌عنوان پرکننده از یک تصویر استفاده کنند. ابتدا نوع پرکننده شکل را بررسی کنید: اگر برابر با [FillType.Picture](https://reference.aspose.com/slides/fa/net/aspose.slides/filltype/) نباشد، تصویری برای استخراج از آن پرکننده وجود ندارد. مثال زیر اشیاء [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) را پردازش می‌کند و هر تصویر را از طریق [IPPImage.Image](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) به صورت PNG ذخیره می‌کند.

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

## **استخراج پیش‌نمایش تصاویر از فریم‌های شیء OLE**

یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ioleobjectframe/) می‌تواند تصویر جایگزینی داشته باشد که PowerPoint به‌عنوان پیش‌نمایش شیء در اسلاید استفاده می‌کند. این تصویر از طریق `SubstitutePictureFormat.Picture.Image` در دسترس است. استخراج این تصویر به شما پیش‌نمایش می‌دهد، نه محتویات بسته OLE جاسازی‌شده.

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

## **استخراج پیش‌نمایش تصاویر از فریم‌های ویدیو**

یک [IVideoFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/) نیز می‌تواند تصویر پیش‌نمایش را در `PictureFormat.Picture.Image` ذخیره کند. این تصویر پوستر یا بندانگشتی‌ای است که در اسلاید نشان داده می‌شود، نه فریمی که از جریان ویدیو استخراج شده باشد.

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

## **استخراج پیش‌نمایش تصاویر از فریم‌های صدا**

یک [IAudioFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/iaudioframe/) می‌تواند یک بندانگشتی را در `PictureFormat.Picture.Image` ذخیره کند. این تصویر برای شیء صدا در اسلاید نشان داده می‌شود.

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

## **استخراج تصاویر از اشیای زوم**

اشیای [IZoomFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/izoomframe/) و [ISectionZoomFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/isectionzoomframe/) می‌توانند از تصاویر سفارشی استفاده کنند. `ZoomImage` را از فریم زوم بخوانید.

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

## **استخراج تصاویر از فریم‌های زوم خلاصه**

یک [ISummaryZoomFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/isummaryzoomframe/) نیز یک شکل است. آیتم‌های بخش آن می‌توانند از تصاویر سفارشی استفاده کنند که از طریق ویژگی `ZoomImage` هر بخش زوم خلاصه در دسترس است.

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

## **استخراج تصاویر از شکل‌های جدول**

یک [ITable](https://reference.aspose.com/slides/fa/net/aspose.slides/itable/) یک شکل است. تصاویر در جدول معمولاً به‌عنوان پرکننده‌های تصویری در سلول‌های جدول ذخیره می‌شوند.

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

## **استخراج تصاویر از شکل‌های نمودار**

یک [IChart](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichart/) یک شکل است. مثال زیر تصویری را از پرکننده تصویری ناحیه نمودار استخراج می‌کند.

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

## **استخراج تصاویر از شکل‌های SmartArt**

یک شیء [ISmartArt](https://reference.aspose.com/slides/fa/net/aspose.slides.smartart/ismartart/) یک شکل است. بسته به طرح‌بندی SmartArt، تصاویر ممکن است در پرکننده‌های گلوله گره‌ها یا در فرمت‌های پرکننده‌ی شکل‌های گره ذخیره شوند.

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

## **شامل تصاویر درون شکل‌های گروهی**

شکل‌های گروهی مجموعه‌های شکل خود را دارند. متد کمکی مشترک `EnumerateShapes` گزینه‌ای به نام `includeGroupedShapes` دارد. وقتی می‌خواهید شکل‌های داخل اشیای [IGroupShape](https://reference.aspose.com/slides/fa/net/aspose.slides/igroupshape/) را بررسی کنید، آن را به `true` تنظیم کنید. مثال زیر تصاویر را از فریم‌های تصویر، شکل‌های پر شده با تصویر، پیش‌نمایش‌های شیء OLE، بندانگشتی‌های فریم ویدیو و بندانگشتی‌های فریم صدا استخراج می‌کند. برای شامل کردن تصاویر جدول، نمودار، SmartArt و زوم خلاصه نیز می‌توانید منطق استخراج مخصوص بخش‌های قبلی را بازاستفاده کنید در حالی که همان پیمایش بازگشتی شکل را حفظ می‌کنید.

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

## **موارد لبه و نکات عملی**

- **تصاویر تکراری:** چندین شکل ممکن است به یک تصویر اشاره کنند یا تصاویر جداگانه‌ای با بایت‌های یکسان داشته باشند. قبل از نوشتن فایل‌ها هش [IPPImage.BinaryData](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) را محاسبه کنید تا برای هر تصویر منحصر به‌فرد تنها یک فایل خروجی داشته باشید.
- **داده اصلی در مقابل خروجی تبدیل‌شده:** ذخیره [IPPImage.BinaryData](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) داده‌های JPEG، PNG، GIF، SVG، EMF یا WMF جاسازی‌شده را حفظ می‌کند. ذخیره [IPPImage.Image](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) از طریق [IImage.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) زمانی مفید است که بخواهید خروجی را به فرمتی ثابت مانند PNG تبدیل کنید.
- **انواع پرکننده پشتیبانی‌نشده:** شکل‌های ثابت، گرادیان، الگو و بدون پرکننده تصویر ندارند. قبل از خواندن `PictureFillFormat`، [FillType](https://reference.aspose.com/slides/fa/net/aspose.slides/filltype/) را بررسی کنید.
- **شکل‌های گروهی:** مجموعه شکل‌های سطح بالای اسلاید گروه‌ها را صاف‌نمی‌کند. هنگام نیاز به محتوای گروهی، به‌صورت بازگشتی [IGroupShape.Shapes](https://reference.aspose.com/slides/fa/net/aspose.slides/igroupshape/) را بررسی کنید.
- **پیش‌نمایش‌های شیء OLE:** یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ioleobjectframe/) ممکن است تصویر پیش‌نمایش را از طریق `SubstitutePictureFormat` ارائه دهد، اما این تصویر تنها پیش‌نمایش اسلاید است و نه فایل جاسازی‌شده داخل شیء OLE.
- **بندانگشتی فریم ویدیو:** یک [IVideoFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/) ممکن است تصویر پیش‌نمایش را از طریق `PictureFormat` ارائه دهد، اما این تصویر تنها پوستری است که در اسلاید نشان داده می‌شود و نه فریمی استخراج‌شده از جریان ویدیو.
- **بندانگشتی فریم صدا:** یک [IAudioFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/iaudioframe/) ممکن است یک آیکون یا بندانگشتی را از طریق `PictureFormat` ارائه دهد؛ این تصویر داده‌های صوتی جاسازی‌شده را نشان نمی‌دهد.
- **تصاویر زوم:** اشکال زوم اسلاید، زوم بخش و زوم خلاصه ممکن است از اشیای سفارشی [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) از طریق `ZoomImage` استفاده کنند.
- **مدل‌های شکل تو در تو:** اشیای جدول، نمودار و SmartArt پیاده‌سازی [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/) را دارند، اما تصاویر آن‌ها اغلب در سلول‌های جدول تو در تو، عنصر نمودار یا شیء قالب‌بندی گره SmartArt ذخیره می‌شود.
- **تصاویر برش‌خورده یا تبدیل‌شده:** دسترسی به [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) تصویر ذخیره‌شده را به‌دست می‌دهد. این تصویر برش، شفافیت، تغییر رنگ، چرخش یا سایر اثرات بصری اعمال‌شده توسط شکل را رندر نمی‌کند.

## **پرسش‌های متداول**

### آیا می‌توانم تصویر اصلی را بدون برش، افکت یا تبدیل شکل استخراج کنم؟

بله. شیء [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) را دسترسی پیدا کنید و [IPPImage.BinaryData](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) را روی دیسک بنویسید. این کار تصویر اصلی کدگذاری‌شده‌ای را که در ارائه ذخیره شده حفظ می‌کند، نه نحوه رندر تصویر در اسلاید.

### آیا می‌توانم همه تصاویر استخراج‌شده را به PNG صادر کنم؟

بله. از [IPPImage.Image](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) برای دریافت شیء [IImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) استفاده کنید و سپس با [IImage.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) و [ImageFormat.Png](https://reference.aspose.com/slides/fa/net/aspose.slides/imageformat/) خروجی را به PNG تبدیل کنید. این کار ممکن است نوع فایل اصلی یا داده‌های برداری را حفظ نکند.

### چگونه می‌توانم از ذخیره‌سازی مجدد یک تصویر جلوگیری کنم؟

هش [IPPImage.BinaryData](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) را محاسبه کنید و هش‌ها را در یک مجموعه نگه دارید. اگر تصویر جدیدی هشی داشته باشد که در مجموعه موجود باشد، آن را نادیده بگیرید یا مرجع دیگری به فایل خروجی موجود ثبت کنید.

### چرا برخی از شکل‌ها تصویری تولید نمی‌کنند؟

فریم‌های تصویر، شکل‌های پر شده با تصویر، فریم‌های شیء OLE، فریم‌های رسانه‌ای، فریم‌های زوم، جدول‌ها، نمودارها و اشیای SmartArt می‌توانند به تصاویر ارجاع دهند. برخی انواع شکل‌ها تصویر را از طریق شیء قالب‌بندی تو در تو ارائه می‌دهند، بنابراین بررسی ساده `PictureFormat` یا `FillFormat` شکل همیشه کافی نیست.

### آیا می‌توانم بندانگشتی نمایش داده‌شده برای فریم ویدیو را استخراج کنم؟

بله. از [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/) استفاده کنید و `PictureFormat.Picture.Image` را بخوانید. این تصویر پوستر ذخیره‌شده با فریم ویدیو را استخراج می‌کند، نه فریمی که از فایل ویدیو تولید شده است.

### چگونه می‌توانم تعیین کنم کدام شکل‌ها از یک تصویر خاص در مجموعه تصاویر ارائه استفاده می‌کنند؟

Aspose.Slides لینک معکوسی از [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) به شکل‌ها ذخیره نمی‌کند. در طول پیمایش یک نگاشت بسازید: هر بار که به یک ارجاع تصویر برخوردید، شماره اسلاید، مسیر شکل و هش یا شناسهٔ آیتم مجموعه را ثبت کنید.

### آیا می‌توانم تصاویر جاسازی‌شده داخل اشیای OLE، مانند اسناد پیوست‌شده، را استخراج کنم؟

می‌توانید پیش‌نمایش اسلاید شیء OLE را از [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ioleobjectframe/) استخراج کنید. اما این پیش‌نمایش خود سند جاسازی‌شده نیست. برای استخراج تصاویر از داخل فایل جاسازی‌شده، دادهٔ OLE را استخراج کرده و با ابزارهای مناسب برای آن نوع فایل بررسی کنید.