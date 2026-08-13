---
title: Sunum Şekillerinden Görselleri .NET'te Çıkarma
linktitle: Şekilden Görsel
type: docs
weight: 90
url: /tr/net/extracting-images-from-presentation-shapes/
keywords:
- görsel çıkarma
- görsel alma
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint ve OpenDocument sunumlarındaki şekillerden görselleri çıkarın - hızlı, kod dostu çözüm."
---
## **Genel Bakış**

Sunumdaki görseller, çeşitli şekil türlerinde görünebilir: normal resim çerçeveleri olarak, şekillere uygulanan resim doldurmaları olarak, OLE nesne önizleme görselleri olarak, video veya ses çerçeve küçük resimleri olarak, yakınlaştırma görselleri olarak veya tablo, grafik ve SmartArt şekilleri içinde iç içe yer alan görseller olarak. Aspose.Slides bu görselleri sunum görüntü koleksiyonunda saklar ve [ImageCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/imagecollection/) ve [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) nesneleri aracılığıyla sunar.

Eğer yalnızca bir sunuma gömülü tüm resim kaynaklarını dışa aktarmanız gerekiyorsa, `presentation.Images` üzerinde yineleme yapın. Bu makale farklı bir göreve odaklanır: slaytlarda görsellerin nerede kullanıldığını bulmak için şekilleri dolaşmak, böylece kaydedilen dosyalar slayt numarası, şekil konumu ve kaynak tipi (resim çerçevesi, doldurma görseli, medya önizleme, OLE önizleme veya yakınlaştırma görseli) gibi yararlı bağlamı tutabilir.

{{% alert title="Tip" color="info" %}}
[IPPImage.BinaryData](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) kullanarak orijinal kodlanmış görsel verisini ve dosya tipini koruyun. Çıktıyı PNG gibi belirli bir biçime normalize etmek istediğinizde [IPPImage.Image](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) ile [IImage.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) kullanın.
{{% /alert %}}

## **Paylaşılan Yardımcı Metodlar**

Aşağıdaki yardımcı metodlar örnekleri kısa tutar. `SaveOriginalImage` orijinal gömülü baytları yazar, MIME tipinden güvenli bir uzantı seçer ve SHA-256 karmasıyla yinelenen görsel ikili dosyalarını atlar.

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

## **Resim Çerçevelerinden Görselleri Çıkar**

Bağımsız nesneler olarak eklenmiş resimler için bu yöntemi kullanın. Bir [IPictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ipictureframe/) resmi `PictureFormat.Picture.Image` içinde saklar ve bu bir [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) nesnesi döndürür.

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

## **Resim Doldurmalı Şekillerden Görselleri Çıkar**

Şekiller bir resmi doldurma olarak kullanabilir. Öncelikle şeklin doldurma tipini kontrol edin: eğer [FillType.Picture](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) değilse, o doldurmadan çıkarılacak bir resim yoktur. Aşağıdaki örnek [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) nesnelerini işler ve her görseli [IPPImage.Image](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) aracılığıyla PNG olarak kaydeder.

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

## **OLE Nesne Çerçevelerinden Önizleme Görsellerini Çıkar**

Bir [IOleObjectFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ioleobjectframe/) PowerPoint'in nesnenin slayt üzerindeki önizleme olarak kullandığı bir yedek resim içerebilir. Bu görsel `SubstitutePictureFormat.Picture.Image` üzerinden elde edilir. Bu resmi çıkarmak, OLE paketinin gömülü içeriğini değil, önizleme görselini verir.

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

## **Video Çerçevelerinden Önizleme Görsellerini Çıkar**

Bir [IVideoFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/) de `PictureFormat.Picture.Image` içinde bir önizleme resmi saklayabilir. Bu, slaytta gösterilen poster veya küçük resimdir, video akışından çözümlenen bir çerçeve değildir.

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

## **Ses Çerçevelerinden Önizleme Görsellerini Çıkar**

Bir [IAudioFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/iaudioframe/) `PictureFormat.Picture.Image` içinde bir küçük resim saklayabilir. Bu, slaytta ses nesnesi için gösterilen görseldir.

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

## **Zoom Nesnelerinden Görselleri Çıkar**

[IZoomFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/izoomframe/) ve [ISectionZoomFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/isectionzoomframe/) şekilleri özel görseller kullanabilir. Zoom çerçevesinden `ZoomImage` değerini okuyun.

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

## **Özet Zoom Çerçevelerinden Görselleri Çıkar**

[ISummaryZoomFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/isummaryzoomframe/) da bir şekildir. Bölüm öğeleri özel görseller kullanabilir; her özet zoom bölümünün `ZoomImage` özelliği aracılığıyla bu görseller ortaya çıkar.

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

## **Tablo Şekillerinden Görselleri Çıkar**

[ITable](https://reference.aspose.com/slides/tr/net/aspose.slides/itable/) bir şekildir. Tablo içindeki görseller genellikle tablo hücrelerindeki resim doldurmaları olarak saklanır.

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

## **Grafik Şekillerinden Görselleri Çıkar**

[IChart](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichart/) bir şekildir. Aşağıdaki örnek grafik alanının resim doldurmasından bir görsel çıkarır.

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

## **SmartArt Şekillerinden Görselleri Çıkar**

[ISmartArt](https://reference.aspose.com/slides/tr/net/aspose.slides.smartart/ismartart/) nesnesi bir şekildir. SmartArt düzenine bağlı olarak, görseller düğüm madde doldurmalarında veya düğüm şekillerinin doldurma biçimlerinde saklanabilir.

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

## **Gruplandırılmış Şekillerin İçindeki Görselleri Dahil Et**

Gruplandırılmış şekiller kendi şekil koleksiyonlarına sahiptir. Paylaşılan `EnumerateShapes` yardımcı metodunda `includeGroupedShapes` seçeneği vardır. [IGroupShape](https://reference.aspose.com/slides/tr/net/aspose.slides/igroupshape/) nesnelerindeki şekilleri incelemek istediğinizde bunu `true` yapın. Aşağıdaki örnek resim çerçevelerinden, resim doldurmalı şekillerden, OLE nesne önizlemelerinden, video çerçeve küçük resimlerinden ve ses çerçeve küçük resimlerinden görselleri çıkarır. Tablo, grafik, SmartArt ve özet zoom görsellerini de eklemek için önceki bölümlerdeki özel çıkarma mantığını aynı yinelemeli şekil geçişiyle yeniden kullanın.

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

## **Köşe Durumları ve Pratik Notlar**

- **Yinelenen görseller:** Birden fazla şekil aynı görsele ya da aynı baytlara sahip ayrı görsellere başvurabilir. Tek bir benzersiz görsel için bir çıktı dosyası istiyorsanız, dosyaları yazmadan önce [IPPImage.BinaryData](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) üzerinde karma oluşturun.
- **Orijinal veri vs. dönüştürülmüş çıktı:** [IPPImage.BinaryData](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) kaydetmek gömülü JPEG, PNG, GIF, SVG, EMF veya WMF verisini korur. [IPPImage.Image](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) ile [IImage.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) kaydetmek tutarlı bir çıktı biçimi (ör. PNG) istediğinizde faydalıdır.
- **Desteklenmeyen doldurma tipleri:** Düz, degrade, desen ve boş doldurma şekilleri resim doldurması içermez. `PictureFillFormat` okumadan önce [FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) kontrol edin.
- **Gruplandırılmış şekiller:** Üst seviyedeki slayt şekil koleksiyonu grupları düzleştirmez. Gruplandırılmış içerik önemliyse, [IGroupShape.Shapes](https://reference.aspose.com/slides/tr/net/aspose.slides/igroupshape/) üzerinde yinelemeli inceleme yapın.
- **OLE nesne önizlemeleri:** Bir [IOleObjectFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ioleobjectframe/) `SubstitutePictureFormat` üzerinden bir önizleme görseli sunabilir, ancak bu yalnızca slayt önizlemesidir. OLE nesnesinin içinde gömülü dosya değildir.
- **Video çerçeve küçük resimleri:** Bir [IVideoFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/) `PictureFormat` üzerinden bir önizleme görseli sunabilir; bu yalnızca slaytta gösterilen posterdır, video akışından çıkarılan bir çerçeve değildir.
- **Ses çerçeve küçük resimleri:** Bir [IAudioFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/iaudioframe/) `PictureFormat` üzerinden bir simge veya küçük resim sunabilir; bu gömülü ses verisi değildir.
- **Zoom görselleri:** Slayt zoom, bölüm zoom ve özet zoom şekilleri `ZoomImage` aracılığıyla özel [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) nesneleri kullanabilir.
- **İç içe şekil modelleri:** Tablo, grafik ve SmartArt nesneleri [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/) uygular, ancak görselleri genellikle iç içe tablo hücresi, grafik öğesi veya SmartArt düğüm biçimlendirme nesnelerinde saklanır.
- **Kırpılmış veya dönüştürülmüş resimler:** [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) erişimi, depolanan görsel kaynağını verir. Şeklin uyguladığı kırpma, şeffaflık, renk değiştirme, döndürme veya diğer görsel efektler burada işlenmez.

## **SSS**

### Orijinal görseli kırpma, efektler veya şekil dönüşümleri olmadan çıkarabilir miyim?

Evet. [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) nesnesine erişin ve [IPPImage.BinaryData](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) dosyaya yazın. Bu, sunumda saklanan orijinal kodlanmış görseli korur, slaytta nasıl render edildiğiyle ilgili değişiklikleri içermez.

### Çıkarılan tüm görselleri PNG olarak dışa aktarabilir miyim?

Evet. [IPPImage.Image](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) ile bir [IImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) nesnesi alın ve ardından [IImage.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) metodunu [ImageFormat.Png](https://reference.aspose.com/slides/tr/net/aspose.slides/imageformat/) ile çağırın. Bu çıktı biçimini PNG’ye dönüştürür ve orijinal dosya tipini ya da vektör verisini korumayabilir.

### Aynı görseli birden fazla kez kaydetmekten nasıl kaçınabilirim?

[IPPImage.BinaryData](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) karmasını bir kümede tutun. Yeni bir görselin karması zaten mevcutsa, dosyayı atlayın veya mevcut çıktı dosyasına başka bir referans kaydedin.

### Neden bazı şekiller görsel üretmiyor?

Resim çerçeveleri, resim doldurmalı şekiller, OLE nesne çerçeveleri, medya çerçeveleri, zoom çerçeveleri, tablolar, grafikler ve SmartArt nesneleri görsellere başvurabilir. Bazı şekil tipleri görselleri iç içe biçimlendirme nesneleri aracılığıyla sunar; bu yüzden yalnızca `PictureFormat` ya da şekil `FillFormat` kontrolü her zaman yeterli olmayabilir.

### Bir video çerçevesi için gösterilen küçük resmi çıkarabilir miyim?

Evet. [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/) kullanın ve `PictureFormat.Picture.Image` değerini okuyun. Bu, video çerçevesiyle birlikte saklanan poster görselini çıkarır, video dosyasından üretilen bir çerçeve değildir.

### Sunum görüntü koleksiyonundaki belirli bir görseli hangi şekillerin kullandığını nasıl belirleyebilirim?

Aspose.Slides, [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) nesnesinden şekillere ters bağlantılar tutmaz. Gezinme sırasında bir görsel referansı bulduğunuzda, slayt numarasını, şekil yolunu ve görsel karmasını veya koleksiyon öğesini kaydedin.

### Ekli belgeler gibi OLE nesneleri içinde gömülü görselleri çıkarabilir miyim?

[IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ioleobjectframe/) aracılığıyla OLE nesnesinin slayt önizlemesini çıkarabilirsiniz. Ancak bu önizleme, gömülü belgeyi içermez. Gömülü dosyanın içindeki görselleri çıkarmak için OLE verisini ayıklamalı ve ilgili dosya türü araçlarıyla incelemelisiniz.