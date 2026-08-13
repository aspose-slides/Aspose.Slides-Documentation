---
title: Optimalkan Manajemen Gambar dalam Presentasi di .NET
linktitle: Kelola Gambar
type: docs
weight: 10
url: /id/net/image/
keywords:
- menambahkan gambar
- menambahkan gambar
- menambahkan bitmap
- mengganti gambar
- mengganti gambar
- dari web
- latar belakang
- menambahkan PNG
- menambahkan JPG
- menambahkan SVG
- sumber daya SVG eksternal
- resolver SVG
- gambar SVG tertaut
- font SVG
- menambahkan EMF
- menambahkan WMF
- menambahkan TIFF
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Menyederhanakan manajemen gambar di PowerPoint dan OpenDocument dengan Aspose.Slides untuk .NET, mengoptimalkan kinerja dan mengotomatiskan alur kerja Anda."
---
## **Pendahuluan**

Gambar membuat presentasi lebih menarik dan tampak visual. Di Microsoft PowerPoint, Anda dapat menyisipkan gambar ke slide dari file, internet, atau sumber lainnya. Demikian pula, Aspose.Slides memungkinkan Anda menambahkan gambar ke slide presentasi dalam beberapa cara.

{{% alert  title="Tip" color="info" %}} 

Aspose menyediakan konverter gratis—[JPEG ke PowerPoint](https://products.aspose.app/slides/id/import/jpg-to-ppt) dan [PNG ke PowerPoint](https://products.aspose.app/slides/id/import/png-to-ppt)—yang memungkinkan Anda dengan cepat membuat presentasi dari gambar. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Jika Anda ingin menambahkan gambar sebagai bingkai gambar—terutama jika Anda berencana mengubah ukuran, menerapkan efek, atau menggunakan opsi pemformatan standar lainnya—lihat [Picture Frame](/slides/id/net/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Anda dapat mengonversi gambar dari satu format ke format lain. Lihat halaman berikut: konversi [image to JPG](https://products.aspose.com/slides/id/net/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/id/net/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/id/net/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/id/net/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/id/net/conversion/png-to-svg/), dan [SVG to PNG](https://products.aspose.com/slides/id/net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides mendukung gambar dalam format populer seperti JPEG, PNG, BMP, GIF, dan lainnya. 

## **Menambahkan Gambar yang Disimpan Secara Lokal ke Slide**

Anda dapat menambahkan satu atau beberapa gambar yang disimpan di komputer ke slide presentasi. Kode contoh C# berikut menunjukkan cara menambahkan gambar ke slide:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Menambahkan Gambar dari Web ke Slide**

Jika gambar yang ingin Anda tambahkan ke slide tidak disimpan di komputer, Anda dapat menambahkannya langsung dari web. 

Kode contoh C# berikut menunjukkan cara menambahkan gambar dari web ke slide:

```c#
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Menambahkan Gambar ke Slide Master**

Slide master menyimpan dan mengontrol informasi seperti tema dan tata letak untuk slide yang menggunakannya. Ketika Anda menambahkan gambar ke slide master, gambar tersebut muncul di setiap slide yang berbasis master itu. 

Kode contoh C# berikut menunjukkan cara menambahkan gambar ke slide master:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Menambahkan Gambar sebagai Latar Belakang Slide**

Anda dapat menggunakan gambar sebagai latar belakang untuk satu atau beberapa slide. Untuk detailnya, lihat *[Setting Images as Backgrounds for Slides](/slides/id/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Menambahkan SVG ke Presentasi**

Konten SVG dapat ditambahkan ke presentasi menggunakan kelas [SvgImage](https://reference.aspose.com/slides/id/net/aspose.slides/svgimage/). Objek [ISvgImage](https://reference.aspose.com/slides/id/net/aspose.slides/isvgimage/) yang dihasilkan kemudian dapat ditambahkan ke koleksi gambar presentasi dan digunakan untuk membuat bingkai gambar.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string svgContent = @"
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>";

using (Presentation presentation = new Presentation())
{
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("self-contained-svg.pptx", SaveFormat.Pptx);
}
```

## **Mengimpor Konten SVG dengan Sumber Daya Eksternal**

File SVG yang diekspor dari alat desain, editor diagram, sistem ikon, dan pipeline web dapat merujuk ke sumber daya yang disimpan di luar dokumen SVG. Misalnya, SVG dapat berisi tautan gambar seperti `images/photo.png`, nilai CSS `url(...)`, atau URL font.

Untuk mengimpor konten SVG semacam itu, buat implementasi [IExternalResourceResolver](https://reference.aspose.com/slides/id/net/aspose.slides.import/iexternalresourceresolver/) dan berikan bersama dengan base URI ke konstruktor `SvgImage` yang sesuai. Base URI mengidentifikasi lokasi dokumen SVG dan digunakan untuk menyelesaikan tautan relatif.

Antarmuka [ISvgImage](https://reference.aspose.com/slides/id/net/aspose.slides/isvgimage/) menyediakan akses ke informasi tentang SVG yang diimpor:

- `SvgContent` mengembalikan markup SVG sebagai string.
- `SvgData` mengembalikan konten SVG sebagai array byte.
- `BaseUri` mengembalikan base URI yang digunakan untuk tautan relatif.
- `ExternalResourceResolver` mengembalikan resolver yang ditetapkan untuk gambar SVG.

### **Menerapkan Penyelesai Sumber Daya Eksternal**

Resolver memiliki dua metode:

- [ResolveUri](https://reference.aspose.com/slides/id/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) menggabungkan base URI dan tautan sumber daya relatif serta mengembalikan URI absolut. Mengembalikan `null` bila tautan tidak dapat diselesaikan atau tidak diizinkan.
- [GetEntity](https://reference.aspose.com/slides/id/net/aspose.slides.import/iexternalresourceresolver/getentity/) mengembalikan aliran yang dapat dibaca untuk URI sumber daya absolut. Mengembalikan `null` bila sumber daya hilang, diblokir, atau tidak tersedia. Aliran cadangan juga dapat dikembalikan bila sesuai.

```csharp
using System;
using System.IO;
using Aspose.Slides.Import;

internal sealed class LocalSvgResourceResolver : IExternalResourceResolver
{
    private readonly string _allowedRoot;
    private readonly byte[] _fallbackImageData;

    public LocalSvgResourceResolver(string allowedRoot, byte[] fallbackImageData = null)
    {
        _allowedRoot = Path.GetFullPath(allowedRoot);
        _fallbackImageData = fallbackImageData;
    }

    public string ResolveUri(string baseUri, string relativeUri)
    {
        if (string.IsNullOrWhiteSpace(baseUri) ||
            string.IsNullOrWhiteSpace(relativeUri))
        {
            return null;
        }

        if (!Uri.TryCreate(baseUri, UriKind.Absolute, out Uri baseAddress) ||
            !Uri.TryCreate(baseAddress, relativeUri, out Uri absoluteAddress))
        {
            return null;
        }

        // Resolver ini secara sengaja hanya mengizinkan file lokal.
        if (!absoluteAddress.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(absoluteAddress.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        return absoluteAddress.AbsoluteUri;
    }

    public Stream GetEntity(string absoluteUri)
    {
        if (!Uri.TryCreate(absoluteUri, UriKind.Absolute, out Uri resourceUri) ||
            !resourceUri.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(resourceUri.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        if (File.Exists(resourcePath))
        {
            return File.OpenRead(resourcePath);
        }

        // Gunakan fallback hanya untuk sumber daya gambar. Mengembalikan aliran gambar
        // untuk font atau stylesheet yang hilang tidak akan valid.
        if (_fallbackImageData != null && IsImageFile(resourcePath))
        {
            return new MemoryStream(_fallbackImageData, writable: false);
        }

        return null;
    }

    private bool IsInsideAllowedRoot(string resourcePath)
    {
        string normalizedRoot = _allowedRoot.TrimEnd(
            Path.DirectorySeparatorChar,
            Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;

        string normalizedPath = Path.GetFullPath(resourcePath);
        StringComparison comparison = Path.DirectorySeparatorChar == '\\'
            ? StringComparison.OrdinalIgnoreCase
            : StringComparison.Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               string.Equals(normalizedPath, _allowedRoot, comparison);
    }

    private static bool IsImageFile(string path)
    {
        string extension = Path.GetExtension(path);

        return extension.Equals(".png", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".gif", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".bmp", StringComparison.OrdinalIgnoreCase);
    }
}
```

### **Menyelesaikan Sumber Daya Tertaut selama Impor SVG**

Anggap `assets/diagram.svg` berisi referensi relatif seperti:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Contoh C# berikut memberikan URI file SVG sebagai base URI dan menyediakan resolver khusus. Resolver mengubah tautan gambar relatif menjadi URI absolut dan mengembalikan aliran yang berisi sumber daya tertaut saat Aspose.Slides memproses SVG.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// Base URI mewakili lokasi dokumen SVG.
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage mengekspos konten sumber, data biner, base URI, dan resolver.
string importedContent = svgImage.SvgContent;
byte[] importedData = svgImage.SvgData;
string importedBaseUri = svgImage.BaseUri;
IExternalResourceResolver importedResolver = svgImage.ExternalResourceResolver;

using (Presentation presentation = new Presentation())
{
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
}
```

Kelas `SvgImage` juga menyediakan overload yang menerima data SVG sebagai array byte atau aliran, bersama dengan penyelesai sumber daya eksternal dan base URI.

{{% alert title="Important" color="warning" %}}

Penyelesai sumber daya membuat sumber daya eksternal tersedia saat Aspose.Slides memproses dan merender SVG. Ia tidak mengubah markup SVG asli atau secara otomatis menyematkan sumber daya yang telah diselesaikan ke dalamnya.

Ketika sebuah `ISvgImage` ditambahkan ke koleksi gambar presentasi, berkas PPTX dapat berisi baik representasi SVG asli maupun gambar raster cadangan. Sumber daya tertaut dapat muncul dalam gambar cadangan yang dihasilkan sementara tautan relatif seperti `images/photo.png` tetap tidak berubah dalam SVG yang disimpan. Aplikasi yang merender representasi SVG asli mungkin tidak menampilkan konten tertaut ketika sumber daya eksternal asli tidak tersedia.

{{% /alert %}}

### **Membuat Gambar SVG Portabel**

Untuk membuat gambar SVG yang tidak tergantung pada file eksternal, buat SVG menjadi mandiri sebelum membuat `SvgImage`. Misalnya, ganti URL gambar yang tertaut dengan URI `data:` yang berisi data gambar:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Kemudian setelah semua sumber daya yang diperlukan disematkan dalam konten SVG, buat `SvgImage`, tambahkan ke koleksi gambar presentasi, dan sisipkan ke dalam bingkai gambar seperti pada contoh sebelumnya.

### **Menangani Sumber Daya yang Hilang atau Diblokir**

Kembalikan `null` dari `ResolveUri` bila URI sumber daya tidak valid, dilarang, atau tidak dapat diselesaikan. Kembalikan `null` dari `GetEntity` bila sumber daya tidak dapat dibaca. Aspose.Slides terus memproses SVG tanpa sumber daya tersebut bila memungkinkan.

Aliran cadangan dapat dikembalikan untuk sumber daya yang hilang, tetapi isinya harus cocok dengan tipe sumber daya yang diminta. Misalnya, kembalikan aliran gambar hanya untuk gambar yang hilang, bukan untuk font atau stylesheet.

{{% alert title="Security" color="warning" %}}

Jangan menyelesaikan jalur file arbitrer atau URL jaringan tak terbatas dari file SVG yang tidak terpercaya. Batasi skema, direktori, dan host yang diizinkan. Untuk sumber daya jaringan, terapkan batas waktu koneksi, batas ukuran respons, dan validasi konten.

{{% /alert %}}

## **Mengonversi SVG menjadi Sekelompok Bentuk**
Aspose.Slides dapat mengonversi SVG menjadi sekumpulan bentuk, mirip dengan fungsi yang bersamaan di PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Fungsionalitas ini disediakan oleh overload metode [AddGroupShape](https://reference.aspose.com/slides/id/net/aspose.slides.ishapecollection/addgroupshape/methods/1) pada antarmuka [IShapeCollection](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection) yang menerima objek [ISvgImage](https://reference.aspose.com/slides/id/net/aspose.slides/isvgimage) sebagai argumen pertama.

``` csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Nama file SVG sumber
string svgFileName = "sample.svg";

// Nama file presentasi output
string outPptxPath = "presentation.pptx";

// Buat presentasi baru
using (IPresentation presentation = new Presentation())
{
    // Baca konten file SVG
    string svgContent = File.ReadAllText(svgFileName);

    // Buat objek SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Dapatkan ukuran slide
    SizeF slideSize = presentation.SlideSize.Size;

    // Konversi gambar SVG menjadi grup bentuk dan skalakan ke ukuran slide
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Simpan presentasi dalam format PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Menambahkan Gambar sebagai EMF ke Slide**
Aspose.Slides untuk .NET memungkinkan Anda menghasilkan gambar EMF dari lembar kerja Excel dengan Aspose.Cells dan menambahkannya ke slide presentasi.

``` csharp 
using Aspose.Slides;
using Aspose.Cells;
using Aspose.Cells.Rendering;


using (Workbook book = new Workbook("chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageType = Aspose.Cells.Drawing.ImageType.Emf;

    // Simpan workbook ke aliran
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save("Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **Mengganti Gambar dalam Koleksi Gambar**

Aspose.Slides memungkinkan Anda mengganti gambar yang disimpan dalam koleksi gambar presentasi, termasuk gambar yang digunakan oleh bentuk slide. Bagian ini menjelaskan beberapa cara memperbarui gambar dalam koleksi. Anda dapat mengganti gambar menggunakan data byte mentah, contoh [IImage](https://reference.aspose.com/slides/id/net/aspose.slides/iimage/) , atau gambar lain yang sudah ada dalam koleksi.

Ikuti langkah-langkah berikut:

1. Muat berkas presentasi yang berisi gambar menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
1. Muat gambar baru dari sebuah file ke dalam array byte.
1. Ganti gambar target dengan gambar baru menggunakan array byte.
1. Pada pendekatan kedua, muat gambar ke dalam objek [IImage](https://reference.aspose.com/slides/id/net/aspose.slides/iimage/) dan ganti gambar target dengan objek tersebut.
1. Pada pendekatan ketiga, ganti gambar target dengan gambar yang sudah ada di koleksi gambar presentasi.
1. Tuliskan presentasi yang telah dimodifikasi sebagai berkas PPTX.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Membuat instance kelas Presentation yang mewakili file presentasi.
using Presentation presentation = new Presentation("sample.pptx");

// Cara pertama.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// Cara kedua.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// Cara ketiga.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Simpan presentasi ke sebuah file.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}

Dengan konverter gratis [Text to GIF](https://products.aspose.app/slides/id/text-to-gif) dari Aspose, Anda dapat dengan mudah menganimasikan teks dan membuat GIF dari teks. 

{{% /alert %}}

## **Tanya Jawab**

**Apakah resolusi gambar asli tetap utuh setelah disisipkan?**

Ya. Piksel sumber dipertahankan, tetapi tampilan akhir tergantung pada bagaimana [picture](/slides/id/net/picture-frame/) diskalakan pada slide dan kompresi apa pun yang diterapkan saat menyimpan.

**Apa cara terbaik untuk mengganti logo yang sama di puluhan slide sekaligus?**

Letakkan logo pada slide master atau layout dan ganti di koleksi gambar presentasi—pembaruan akan menyebar ke semua elemen yang menggunakan sumber daya tersebut.

**Apakah SVG yang disisipkan dapat dikonversi menjadi bentuk yang dapat diedit?**

Ya. Anda dapat mengonversi SVG menjadi grup bentuk, setelah itu bagian‑bagian individu menjadi dapat diedit dengan properti bentuk standar.

**Bagaimana saya dapat menyetel gambar sebagai latar belakang untuk beberapa slide sekaligus?**

[Assign the image as the background](/slides/id/net/presentation-background/) pada slide master atau layout yang relevan—setiap slide yang menggunakan master/layout tersebut akan mewarisi latar belakang.

**Bagaimana cara mencegah presentasi menjadi terlalu besar karena banyak gambar?**

Gunakan kembali satu sumber gambar alih‑alih duplikat, pilih resolusi yang wajar, terapkan kompresi saat menyimpan, dan simpan grafik yang berulang pada master bila sesuai.