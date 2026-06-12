---
title: Ekstrak Gambar dari Bentuk Presentasi di .NET
linktitle: Gambar dari Bentuk
type: docs
weight: 90
url: /id/net/extracting-images-from-presentation-shapes/
keywords:
- ekstrak gambar
- ambil gambar
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Ekstrak gambar dari bentuk dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk .NET - solusi cepat dan mudah diprogram."
---
## **Gambaran Umum**

Gambar dalam sebuah presentasi dapat muncul dalam beberapa jenis bentuk: sebagai bingkai gambar biasa, sebagai isian gambar yang diterapkan pada bentuk, sebagai gambar pratinjau objek OLE, sebagai thumbnail bingkai video atau audio, sebagai gambar zoom, atau sebagai gambar yang ditempatkan di dalam bentuk tabel, bagan, dan SmartArt. Aspose.Slides menyimpan gambar-gambar tersebut dalam koleksi gambar presentasi, yang dapat diakses melalui objek [ImageCollection](https://reference.aspose.com/slides/id/net/aspose.slides/imagecollection/) dan [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/) .

Jika Anda hanya perlu mengekspor setiap sumber gambar yang disisipkan dalam sebuah presentasi, iterasi melalui `presentation.Images`. Artikel ini fokus pada tugas yang berbeda: menelusuri bentuk untuk menemukan di mana gambar digunakan pada slide, sehingga file yang disimpan dapat mempertahankan konteks berguna seperti nomor slide, posisi bentuk, dan tipe sumber (bingkai gambar, gambar isian, pratinjau media, pratinjau OLE, atau gambar zoom).

{{% alert title="Tip" color="primary" %}}
Gunakan [IPPImage.BinaryData](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/) untuk mempertahankan data gambar yang dikodekan asli dan tipe file. Gunakan [IPPImage.Image](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/) dengan [IImage.Save](https://reference.aspose.com/slides/id/net/aspose.slides/iimage/) ketika Anda ingin menormalkan output ke format tertentu seperti PNG.
{{% /alert %}}

## **Metode Pembantu Bersama**

Metode pembantu di bawah ini membuat contoh tetap singkat. `SaveOriginalImage` menulis byte yang disisipkan asli, memilih ekstensi yang aman dari tipe MIME, dan melewatkan duplikat biner gambar dengan hash SHA-256.

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

## **Ekstrak Gambar dari Bingkai Gambar**

Gunakan pendekatan ini untuk gambar yang disisipkan sebagai objek terpisah. Sebuah [IPictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ipictureframe/) menyimpan gambarnya di `PictureFormat.Picture.Image`, yang mengembalikan objek [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/) .

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

## **Ekstrak Gambar dari Bentuk yang Diisi Gambar**

Bentuk dapat menggunakan gambar sebagai isian mereka. Periksa tipe isian bentuk terlebih dahulu: jika bukan [FillType.Picture](https://reference.aspose.com/slides/id/net/aspose.slides/filltype/), tidak ada gambar untuk diekstrak dari isian tersebut. Contoh di bawah menangani objek [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) dan menyimpan setiap gambar sebagai PNG melalui [IPPImage.Image](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/) .

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

## **Ekstrak Gambar Pratinjau dari Bingkai Objek OLE**

Sebuah [IOleObjectFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ioleobjectframe/) dapat memiliki gambar pengganti yang digunakan PowerPoint sebagai pratinjau objek pada slide. Gambar ini tersedia melalui `SubstitutePictureFormat.Picture.Image`. Mengekstrak gambar ini memberi Anda gambar pratinjau, bukan isi paket OLE yang disisipkan.

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

## **Ekstrak Gambar Pratinjau dari Bingkai Video**

Sebuah [IVideoFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/) juga dapat menyimpan gambar pratinjau di `PictureFormat.Picture.Image`. Ini adalah poster atau thumbnail yang ditampilkan pada slide, bukan sebuah frame yang didekode dari aliran video.

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

## **Ekstrak Gambar Pratinjau dari Bingkai Audio**

Sebuah [IAudioFrame](https://reference.aspose.com/slides/id/net/aspose.slides/iaudioframe/) dapat menyimpan thumbnail di `PictureFormat.Picture.Image`. Ini adalah gambar yang ditampilkan untuk objek audio pada slide.

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

## **Ekstrak Gambar dari Objek Zoom**

Bentuk [IZoomFrame](https://reference.aspose.com/slides/id/net/aspose.slides/izoomframe/) dan [ISectionZoomFrame](https://reference.aspose.com/slides/id/net/aspose.slides/isectionzoomframe/) dapat menggunakan gambar khusus. Baca `ZoomImage` dari bingkai zoom.

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

## **Ekstrak Gambar dari Bingkai Zoom Ringkasan**

Sebuah [ISummaryZoomFrame](https://reference.aspose.com/slides/id/net/aspose.slides/isummaryzoomframe/) juga merupakan bentuk. Item bagianannya dapat menggunakan gambar khusus, yang tersedia melalui properti `ZoomImage` setiap bagian zoom ringkasan.

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

## **Ekstrak Gambar dari Bentuk Tabel**

Sebuah [ITable](https://reference.aspose.com/slides/id/net/aspose.slides/itable/) adalah bentuk. Gambar dalam tabel biasanya disimpan sebagai isian gambar pada sel tabel.

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

## **Ekstrak Gambar dari Bentuk Bagan**

Sebuah [IChart](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichart/) adalah bentuk. Contoh di bawah mengekstrak gambar dari isian gambar area bagan.

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

## **Ekstrak Gambar dari Bentuk SmartArt**

Sebuah objek [ISmartArt](https://reference.aspose.com/slides/id/net/aspose.slides.smartart/ismartart/) adalah bentuk. Bergantung pada tata letak SmartArt, gambar dapat disimpan dalam isian bullet node atau dalam format isian bentuk node.

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

## **Sertakan Gambar di Dalam Bentuk yang Dikelompokkan**

Bentuk yang dikelompokkan memiliki koleksi bentuk mereka sendiri. Pembantu bersama `EnumerateShapes` memiliki opsi `includeGroupedShapes`. Atur ke `true` ketika Anda ingin memeriksa bentuk di dalam objek [IGroupShape](https://reference.aspose.com/slides/id/net/aspose.slides/igroupshape/) . Contoh di bawah mengekstrak gambar dari bingkai gambar, bentuk yang diisi gambar, pratinjau objek OLE, thumbnail bingkai video, dan thumbnail bingkai audio. Untuk menyertakan gambar tabel, bagan, SmartArt, dan zoom ringkasan juga, gunakan kembali logika ekstraksi khusus dari bagian sebelumnya sambil mempertahankan penelusuran bentuk rekursif yang sama.

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

## **Kasus Tepi dan Catatan Praktis**

- **Gambar duplikat:** Beberapa bentuk dapat merujuk ke gambar yang sama atau gambar terpisah dengan byte yang identik. Lakukan hash pada [IPPImage.BinaryData](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/) sebelum menulis file jika Anda menginginkan satu file output per gambar unik.
- **Data asli vs. output yang dikonversi:** Menyimpan [IPPImage.BinaryData](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/) mempertahankan data JPEG, PNG, GIF, SVG, EMF, atau WMF yang disisipkan. Menyimpan [IPPImage.Image](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/) melalui [IImage.Save](https://reference.aspose.com/slides/id/net/aspose.slides/iimage/) berguna ketika Anda menginginkan format output yang konsisten.
- **Tipe isian yang tidak didukung:** Bentuk solid, gradien, pola, dan tanpa isian tidak mengandung isian gambar. Periksa [FillType](https://reference.aspose.com/slides/id/net/aspose.slides/filltype/) sebelum membaca `PictureFillFormat`.
- **Bentuk yang dikelompokkan:** Koleksi bentuk slide tingkat atas tidak meratakan grup. Periksa secara rekursif [IGroupShape.Shapes](https://reference.aspose.com/slides/id/net/aspose.slides/igroupshape/) ketika konten yang dikelompokkan penting.
- **Pratinjau objek OLE:** Sebuah [IOleObjectFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ioleobjectframe/) dapat menampilkan gambar pratinjau melalui `SubstitutePictureFormat`, tetapi gambar itu hanya pratinjau slide. Itu bukan file yang disisipkan di dalam objek OLE.
- **Thumbnail bingkai video:** Sebuah [IVideoFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/) dapat menampilkan gambar pratinjau melalui `PictureFormat`, tetapi gambar itu hanya poster yang ditampilkan pada slide. Itu tidak diekstrak dari aliran video.
- **Thumbnail bingkai audio:** Sebuah [IAudioFrame](https://reference.aspose.com/slides/id/net/aspose.slides/iaudioframe/) dapat menampilkan ikon atau thumbnail melalui `PictureFormat`; itu bukan data audio yang disisipkan.
- **Gambar zoom:** Bentuk zoom slide, zoom bagian, dan zoom ringkasan dapat menggunakan objek [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/) khusus melalui `ZoomImage`.
- **Model bentuk bersarang:** Objek tabel, bagan, dan SmartArt mengimplementasikan [IShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/), tetapi gambar mereka sering disimpan dalam sel tabel bersarang, elemen bagan, atau objek format node SmartArt.
- **Gambar yang dipangkas atau ditransformasi:** Mengakses [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/) memberi Anda sumber gambar yang disimpan. Itu tidak menerapkan pemangkasan, transparansi, pewarnaan ulang, rotasi, atau efek visual lain yang diterapkan oleh bentuk.

## **FAQ**

**Apakah saya dapat mengekstrak gambar asli tanpa pemangkasan, efek, atau transformasi bentuk?**

Ya. Akses objek [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/) dan tulis [IPPImage.BinaryData](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/) ke disk. Ini mempertahankan gambar yang dikodekan asli yang disimpan dalam presentasi, bukan cara gambar tersebut dirender pada slide.

**Apakah saya dapat mengekspor setiap gambar yang diekstrak sebagai PNG?**

Ya. Gunakan [IPPImage.Image](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/) untuk mendapatkan objek [IImage](https://reference.aspose.com/slides/id/net/aspose.slides/iimage/) , kemudian panggil [IImage.Save](https://reference.aspose.com/slides/id/net/aspose.slides/iimage/) dengan [ImageFormat.Png](https://reference.aspose.com/slides/id/net/aspose.slides/imageformat/). Ini mengonversi output dan mungkin tidak mempertahankan tipe file asli atau data vektor.

**Bagaimana cara menghindari menyimpan gambar yang sama lebih dari satu kali?**

Gunakan hash dari [IPPImage.BinaryData](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/) dan simpan hash tersebut dalam sebuah set. Jika gambar baru memiliki hash yang sudah ada, lewati atau catat referensi lain ke file output yang sudah ada.

**Mengapa beberapa bentuk tidak menghasilkan gambar?**

Bingkai gambar, bentuk yang diisi gambar, bingkai objek OLE, bingkai media, bingkai zoom, tabel, bagan, dan objek SmartArt dapat merujuk ke gambar. Beberapa tipe bentuk menampilkan gambar melalui objek format bersarang, sehingga pemeriksaan sederhana `PictureFormat` atau `FillFormat` pada bentuk tidak selalu cukup.

**Apakah saya dapat mengekstrak thumbnail yang ditampilkan untuk bingkai video?**

Ya. Gunakan [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ivideoframe/) dan baca `PictureFormat.Picture.Image`. Ini mengekstrak poster yang disimpan bersama bingkai video, bukan frame yang dihasilkan dari file video.

**Bagaimana saya dapat menentukan bentuk mana yang menggunakan gambar tertentu dari koleksi gambar presentasi?**

Aspose.Slides tidak menyimpan tautan terbalik dari [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/) ke bentuk. Bangun pemetaan selama penelusuran: setiap kali Anda menemukan referensi gambar, catat nomor slide, jalur bentuk, dan hash gambar atau item koleksi.

**Apakah saya dapat mengekstrak gambar yang disisipkan di dalam objek OLE, seperti dokumen terlampir?**

Anda dapat mengekstrak pratinjau slide objek OLE dari [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ioleobjectframe/). Namun, pratinjau tersebut bukan dokumen yang disisipkan itu sendiri. Untuk mengekstrak gambar dari dalam file yang disisipkan, ekstrak data OLE dan periksa dengan alat untuk tipe file tersebut.