---
title: PowerPoint Sunum Şekillerinden Görselleri Çıkar (.NET)
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

Sunumdaki görseller çeşitli şekil türlerinde görünebilir: normal resim çerçeveleri olarak, şekillere uygulanan resim dolgu olarak, OLE nesne önizleme görselleri olarak, video veya ses çerçeve küçük resimleri olarak, yakınlaştırma görselleri olarak veya tablo, grafik ve SmartArt şekilleri içinde iç içe yer alan görseller olarak. Aspose.Slides bu görselleri sunum görüntü koleksiyonunda depolar ve bu koleksiyon [ImageCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/imagecollection/) ve [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) nesneleri aracılığıyla sunulur.

Eğer bir sunuma gömülü tüm görüntü kaynaklarını dışa aktarmanız yeterliyse, `presentation.Images` koleksiyonunu dolaşın. Bu makale farklı bir göreve odaklanır: kaydırılarda görsellerin nerede kullanıldığını bulmak için şekilleri gezmek, böylece kaydedilen dosyalar slayt numarası, şekil konumu ve kaynak türü (resim çerçevesi, dolgu resmi, medya önizlemesi, OLE önizlemesi veya yakınlaştırma resmi) gibi yararlı bağlamı tutabilir.

{{% alert title="Tip" color="primary" %}}
Orijinal kodlanmış görüntü verisini ve dosya tipini korumak için [IPPImage.BinaryData](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) kullanın. Çıktıyı PNG gibi belirli bir formata normalleştirmek istediğinizde [IPPImage.Image](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) ile [IImage.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) kullanın.
{{% /alert %}}

## **Ortak Yardımcı Metodlar**

Aşağıdaki yardımcı metodlar örnekleri kısa tutar. `SaveOriginalImage` orijinal gömülü baytları yazar, MIME tipinden güvenli bir dosya uzantısı seçer ve SHA-256 karmasıyla yinelenen görüntü ikili dosyalarını atlar.

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

Bu yaklaşımı bağımsız nesne olarak eklenen resimler için kullanın. Bir [IPictureFrame] resmini `PictureFormat.Picture.Image` içinde saklar ve bu, bir [IPPImage] nesnesi döndürür.

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

## **Resim Dolu Şekillerden Görselleri Çıkar**

Şekiller bir resmi dolgu olarak kullanabilir. Öncelikle şeklin dolgu tipini kontrol edin: eğer [FillType.Picture] değilse, bu dolgu üzerinden çıkarılacak bir resim yoktur. Aşağıdaki örnek [IAutoShape] nesnelerini yönetir ve her bir resmi [IPPImage.Image] aracılığıyla PNG olarak kaydeder.

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

## **OLE Nesne Çerçevelerinden Önizleme Görselleri Çıkar**

Bir [IOleObjectFrame], PowerPoint'in bir slaytta nesnenin önizlemesi olarak kullandığı bir yedek resme sahip olabilir. Bu resim `SubstitutePictureFormat.Picture.Image` aracılığıyla elde edilebilir. Bu resmi çıkarmak, size önizleme görselini verir, gömülü OLE paket içeriğini değildir.

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

## **Video Çerçevelerinden Önizleme Görselleri Çıkar**

Bir [IVideoFrame] ayrıca `PictureFormat.Picture.Image` içinde bir önizleme resmi saklayabilir. Bu, slaytta gösterilen poster ya da küçük resimdir, video akışından ayrıştırılan bir çerçeve değildir.

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

## **Ses Çerçevelerinden Önizleme Görselleri Çıkar**

Bir [IAudioFrame] `PictureFormat.Picture.Image` içinde bir küçük resim saklayabilir. Bu, slayttaki ses nesnesi için gösterilen görseldir.

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

## **Yakınlaştırma Nesnelerinden Görselleri Çıkar**

[IZoomFrame] ve [ISectionZoomFrame] şekilleri özel resimler kullanabilir. Yakınlaştırma çerçevesinden `ZoomImage` değerini okuyun.

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

## **Özet Yakınlaştırma Çerçevelerinden Görselleri Çıkar**

Bir [ISummaryZoomFrame] aynı zamanda bir şekildir. Bölüm öğeleri özel resimler kullanabilir ve bu resimler her özet yakınlaştırma bölümünün `ZoomImage` özelliği sayesinde ortaya çıkar.

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

## **Tablo Şekillerinden Görselleri Çıkar**

Bir [ITable] bir şekildir. Tablodaki görseller genellikle tablo hücrelerindeki resim dolguları olarak saklanır.

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

## **Grafik Şekillerinden Görselleri Çıkar**

Bir [IChart] bir şekildir. Aşağıdaki örnek, grafik alanının resim dolgusundan bir görsel çıkarır.

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

## **SmartArt Şekillerinden Görselleri Çıkar**

Bir [ISmartArt] nesnesi bir şekildir. SmartArt düzenine bağlı olarak, görseller düğüm madde işareti dolgularında ya da düğüm şekillerinin dolgu formatlarında saklanabilir.

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

## **Gruplanmış Şekiller İçindeki Görselleri Dahil Et**

Gruplanmış şekiller kendi şekil koleksiyonlarını içerir. Paylaşılan `EnumerateShapes` yardımcı metodunda `includeGroupedShapes` seçeneği bulunur. [IGroupShape] nesneleri içindeki şekilleri incelemek istediğinizde bunu `true` olarak ayarlayın. Aşağıdaki örnek, resim çerçevelerinden, resim dolgulu şekillerden, OLE nesne önizlemelerinden, video çerçeve küçük resimlerinden ve ses çerçeve küçük resimlerinden görselleri çıkarır. Tablo, grafik, SmartArt ve özet yakınlaştırma görsellerini de dahil etmek için, aynı yinelemeli şekil dolaşımını koruyarak önceki bölümlerdeki özel çıkarma mantığını yeniden kullanın.

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

## **Köşe Durumları ve Pratik Notlar**

- **Yinelenen görseller:** Birden fazla şekil aynı görsele veya aynı baytlara sahip ayrı görsellere referans verebilir. Her benzersiz görsel için bir çıktı dosyası istiyorsanız, dosyaları yazmadan önce [IPPImage.BinaryData] üzerinde hash alın.
- **Orijinal veri vs. dönüştürülmüş çıktı:** [IPPImage.BinaryData] kaydetmek, gömülü JPEG, PNG, GIF, SVG, EMF veya WMF verilerini korur. [IPPImage.Image] üzerinden [IImage.Save] kullanarak kaydetmek, çıktıyı tutarlı bir formatta (ör. PNG) almak istediğinizde faydalıdır.
- **Desteklenmeyen dolgu türleri:** Katı, degrade, desen ve dolgu olmayan şekiller resim dolgusu içermez. `PictureFillFormat` okuma öncesi [FillType] kontrol edin.
- **Gruplanmış şekiller:** Üst düzey slayt şekil koleksiyonu grupları düzleştirmez. Grup içeriği önemli olduğunda [IGroupShape.Shapes] öğesini yinelemeli olarak inceleyin.
- **OLE nesne önizlemeleri:** Bir [IOleObjectFrame] `SubstitutePictureFormat` aracılığıyla bir önizleme resmi sunabilir, ancak bu sadece slayt önizlemesidir. OLE nesnesinin içinde gömülü dosya değildir.
- **Video çerçeve küçük resimleri:** Bir [IVideoFrame] `PictureFormat` aracılığıyla bir önizleme resmi sunabilir, ancak bu sadece slaytta gösterilen posterdir. Video akışından çıkarılan bir çerçeve değildir.
- **Ses çerçeve küçük resimleri:** Bir [IAudioFrame] `PictureFormat` üzerinden bir ikon veya küçük resim sunabilir; bu gömülü ses verisi değildir.
- **Yakınlaştırma görselleri:** Slayt yakınlaştırma, bölüm yakınlaştırma ve özet yakınlaştırma şekilleri, `ZoomImage` aracılığıyla özel [IPPImage] nesneleri kullanabilir.
- **İç içe şekil modelleri:** Tablo, grafik ve SmartArt nesneleri [IShape] uygular, ancak görseller genellikle iç içe tablo hücresi, grafik öğesi veya SmartArt düğüm formatı nesnelerinde saklanır.
- **Kırpılmış veya dönüştürülmüş resimler:** [IPPImage] erişmek, saklanan görüntü kaynağını verir. Şeklin uyguladığı kırpma, şeffaflık, yeniden renkleme, döndürme veya diğer görsel etkileri yansıtmaz.

## **SSS**

**Orijinal resmi kırpma, efektler veya şekil dönüşümleri olmadan çıkarabilir miyim?**

Evet. [IPPImage] nesnesine erişin ve [IPPImage.BinaryData] dosyasına yazın. Bu, sunumda depolanan orijinal kodlanmış resmi korur, slaytta görüntünün nasıl render edildiği değil.

**Çıkarılan her resmi PNG olarak dışa aktarabilir miyim?**

Evet. [IPPImage.Image] kullanarak bir [IImage] nesnesi alın ve ardından [IImage.Save] metodunu [ImageFormat.Png] ile çağırın. Bu, çıktıyı dönüştürür ve orijinal dosya tipi veya vektör verisini korumayabilir.

**Aynı resmi birden fazla kez kaydetmekten nasıl kaçınırım?**

[IPPImage.BinaryData] üzerinde bir hash kullanın ve hash'leri bir sette tutun. Yeni bir resmin hash'i zaten mevcutsa, onu atlayın veya mevcut çıktı dosyasına başka bir referans kaydedin.

**Neden bazı şekiller resim üretmiyor?**

Resim çerçeveleri, resim dolgulu şekiller, OLE nesne çerçeveleri, medya çerçeveleri, yakınlaştırma çerçeveleri, tablolar, grafikler ve SmartArt nesneleri resim referansına sahip olabilir. Bazı şekil türleri resimleri iç içe biçimlendirme nesneleri aracılığıyla ortaya çıkar, bu yüzden basit bir `PictureFormat` veya şekil `FillFormat` kontrolü her zaman yeterli değildir.

**Bir video çerçevesi için gösterilen küçük resmi çıkarabilir miyim?**

Evet. [IVideoFrame.PictureFormat] kullanın ve `PictureFormat.Picture.Image` değerini okuyun. Bu, video çerçevesiyle birlikte saklanan poster görselini çıkarır, video dosyasından oluşturulan bir çerçeve değildir.

**Sunum görüntü koleksiyonundan belirli bir resmi kullanan şekilleri nasıl belirleyebilirim?**

Aspose.Slides, [IPPImage] nesnelerinden şekillere ters bağlantılar tutmaz. Gezinme sırasında bir eşleme oluşturun: bir görüntü referansı bulduğunuzda slayt numarasını, şekil yolunu ve görüntü hash'ini veya koleksiyon öğesini kaydedin.

**OLE nesneleri içinde gömülü görselleri, örneğin ekli belgeleri, çıkarabilir miyim?**

[IOleObjectFrame.SubstitutePictureFormat] aracılığıyla OLE nesnesinin slayt önizlemesini çıkarabilirsiniz. Ancak bu önizleme, gömülü belgeyi içermez. Gömülü dosyanın içindeki görselleri çıkarmak için OLE verisini çıkarın ve dosya tipine uygun araçlarla inceleyin.