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
description: "Permudah manajemen gambar di PowerPoint dan OpenDocument dengan Aspose.Slides untuk .NET, mengoptimalkan kinerja dan mengotomatisasi alur kerja Anda."
---
## **Pendahuluan**

Gambar membuat presentasi lebih menarik dan visual. Di Microsoft PowerPoint, Anda dapat menyisipkan gambar ke slide dari file, internet, atau sumber lain. Demikian pula, Aspose.Slides memungkinkan Anda menambahkan gambar ke slide presentasi dengan beberapa cara.

{{% alert  title="Tip" color="primary" %}} 
Aspose menyediakan konverter gratis—[JPEG ke PowerPoint](https://products.aspose.app/slides/id/import/jpg-to-ppt) dan [PNG ke PowerPoint](https://products.aspose.app/slides/id/import/png-to-ppt)—yang memungkinkan Anda dengan cepat membuat presentasi dari gambar. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Jika Anda ingin menambahkan gambar sebagai bingkai gambar—terutama jika Anda berencana mengubah ukurannya, menerapkan efek, atau menggunakan opsi pemformatan standar lainnya—lihat [Bingkai Gambar](/slides/id/net/picture-frame/). 
{{% /alert %}} 

{{% alert title="Catatan" color="warning" %}}
Anda dapat mengonversi gambar dari satu format ke format lain. Lihat halaman berikut: konversi [gambar ke JPG](https://products.aspose.com/slides/id/net/conversion/image-to-jpg/), [JPG ke gambar](https://products.aspose.com/slides/id/net/conversion/jpg-to-image/), [JPG ke PNG](https://products.aspose.com/slides/id/net/conversion/jpg-to-png/), [PNG ke JPG](https://products.aspose.com/slides/id/net/conversion/png-to-jpg/), [PNG ke SVG](https://products.aspose.com/slides/id/net/conversion/png-to-svg/), dan [SVG ke PNG](https://products.aspose.com/slides/id/net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides mendukung gambar dalam format populer seperti JPEG, PNG, BMP, GIF, dan lainnya. 

## **Menambahkan Gambar yang Disimpan Secara Lokal ke Slide**

Anda dapat menambahkan satu atau beberapa gambar yang disimpan di komputer Anda ke slide presentasi. Kode contoh C# berikut menunjukkan cara menambahkan gambar ke slide:

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

Jika gambar yang ingin Anda tambahkan ke slide tidak disimpan di komputer Anda, Anda dapat menambahkannya langsung dari web. 

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

Slide master menyimpan dan mengontrol informasi seperti tema dan tata letak untuk slide yang menggunakannya. Ketika Anda menambahkan gambar ke slide master, gambar tersebut muncul pada setiap slide yang berbasis master itu. 

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

Anda dapat menggunakan gambar sebagai latar belakang untuk satu atau beberapa slide. Untuk detail, lihat *[Mengatur Gambar sebagai Latar Belakang Slide](/slides/id/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Menambahkan SVG ke Presentasi**

Konten SVG dapat ditambahkan ke presentasi menggunakan kelas [SvgImage](https://reference.aspose.com/slides/id/net/aspose.slides/svgimage/). Objek [ISvgImage](https://reference.aspose.com/slides/id/net/aspose.slides/isvgimage/) yang dihasilkan kemudian dapat ditambahkan ke koleksi gambar presentasi dan digunakan untuk membuat bingkai gambar.

Contoh C# berikut mengimpor string SVG yang berdiri sendiri. Semua gambar, gaya, dan sumber daya lain yang digunakan oleh SVG ini disematkan langsung dalam konten SVG.

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

File SVG yang diekspor dari alat desain, editor diagram, sistem ikon, dan pipeline web dapat merujuk pada sumber daya yang disimpan di luar dokumen SVG. Misalnya, SVG dapat berisi tautan gambar seperti `images/photo.png`, nilai CSS `url(...)`, atau URL font.

Untuk mengimpor konten SVG tersebut, buat implementasi [IExternalResourceResolver](https://reference.aspose.com/slides/id/net/aspose.slides.import/iexternalresourceresolver/) dan berikan bersama dengan basis URI ke konstruktor `SvgImage` yang sesuai. Basis URI mengidentifikasi lokasi dokumen SVG dan digunakan untuk menyelesaikan tautan relatif.

Antarmuka [ISvgImage](https://reference.aspose.com/slides/id/net/aspose.slides/isvgimage/) menyediakan akses ke informasi tentang SVG yang diimpor:

- `SvgContent` mengembalikan markup SVG sebagai string.
- `SvgData` mengembalikan konten SVG sebagai array byte.
- `BaseUri` mengembalikan basis URI yang digunakan untuk tautan relatif.
- `ExternalResourceResolver` mengembalikan resolver yang ditetapkan untuk gambar SVG.

### **Menerapkan Resolver Sumber Daya Eksternal**

Resolver memiliki dua metode:

- [ResolveUri](https://reference.aspose.com/slides/id/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) menggabungkan basis URI dan tautan sumber daya relatif serta mengembalikan URI absolut. Kembalikan `null` bila tautan tidak dapat diselesaikan atau tidak diizinkan.
- [GetEntity](https://reference.aspose.com/slides/id/net/aspose.slides.import/iexternalresourceresolver/getentity/) mengembalikan aliran yang dapat dibaca untuk URI sumber daya absolut. Kembalikan `null` bila sumber daya tidak ada, diblokir, atau tidak tersedia. Aliran fallback juga dapat dikembalikan bila sesuai.

Resolver berikut memuat sumber daya tertaut hanya dari direktori lokal yang diizinkan. Sumber daya jaringan dan jalur di luar direktori yang diizinkan diblokir. Gambar fallback opsional dikembalikan untuk tautan gambar yang tidak terpecahkan.

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

        // Resolver ini sengaja hanya memperbolehkan file lokal.
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

### **Menyelesaikan Sumber Daya Tertaut Selama Impor SVG**

Anggap bahwa `assets/diagram.svg` berisi referensi relatif seperti:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Contoh C# berikut memberikan URI file SVG sebagai basis URI dan menyediakan resolver khusus. Resolver mengubah tautan gambar relatif menjadi URI absolut dan mengembalikan aliran yang berisi sumber daya tertaut saat Aspose.Slides memproses SVG.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// URI dasar mewakili lokasi dokumen SVG.
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage memperlihatkan konten sumber, data biner, URI dasar, dan resolver.
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

Kelas `SvgImage` juga menyediakan overload yang menerima data SVG sebagai array byte atau aliran, bersama dengan resolver sumber daya eksternal dan basis URI.

{{% alert title="Penting" color="warning" %}}
Resolver sumber daya membuat sumber daya eksternal tersedia saat Aspose.Slides memproses dan merender SVG. Ia tidak memodifikasi markup SVG asli atau secara otomatis menyematkan sumber daya yang telah diselesaikan ke dalamnya.

Ketika `ISvgImage` ditambahkan ke koleksi gambar presentasi, file PPTX dapat berisi baik representasi SVG asli maupun gambar raster fallback. Sumber daya tertaut dapat muncul dalam gambar fallback yang dihasilkan sementara tautan relatif seperti `images/photo.png` tetap tidak berubah dalam SVG yang disimpan. Aplikasi yang merender representasi SVG asli mungkin mengabaikan konten tertaut bila sumber daya eksternal asli tidak tersedia.
{{% /alert %}}

### **Membuat Gambar SVG Portabel**

Untuk membuat gambar SVG yang tidak bergantung pada file eksternal, buat SVG menjadi mandiri sebelum membuat `SvgImage`. Misalnya, gantilah URL gambar tertaut dengan URI `data:` yang berisi data gambar:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Setelah semua sumber daya yang diperlukan disematkan dalam konten SVG, buat `SvgImage`, tambahkan ke koleksi gambar presentasi, dan sisipkan ke dalam bingkai gambar seperti pada contoh sebelumnya.

### **Menangani Sumber Daya yang Hilang atau Diblokir**

Kembalikan `null` dari `ResolveUri` bila URI sumber daya tidak valid, dilarang, atau tidak dapat diselesaikan. Kembalikan `null` dari `GetEntity` bila sumber daya tidak dapat dibaca. Aspose.Slides melanjutkan pemrosesan SVG tanpa sumber daya tersebut bila memungkinkan.

Aliran fallback dapat dikembalikan untuk sumber daya yang hilang, tetapi isinya harus kompatibel dengan jenis sumber daya yang diminta. Misalnya, kembalikan aliran gambar hanya untuk gambar yang hilang, bukan untuk font atau stylesheet.

{{% alert title="Keamanan" color="warning" %}}
Jangan selesaikan jalur file arbitrer atau URL jaringan yang tidak dibatasi dari file SVG yang tidak terpercaya. Batasi skema, direktori, dan host yang diizinkan. Untuk sumber daya jaringan, terapkan batas waktu koneksi, batas ukuran respons, dan validasi konten.
{{% /alert %}}

## **Mengonversi SVG menjadi Sekelompok Bentuk**
Aspose.Slides dapat mengonversi SVG menjadi sekumpulan bentuk, serupa dengan fungsi yang ada di PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Fungsi ini disediakan oleh overload metode [AddGroupShape](https://reference.aspose.com/slides/id/net/aspose.slides.ishapecollection/addgroupshape/methods/1) pada antarmuka [IShapeCollection](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection) yang menerima objek [ISvgImage](https://reference.aspose.com/slides/id/net/aspose.slides/isvgimage) sebagai argumen pertama.

Kode contoh C# berikut menunjukkan cara menggunakan metode ini untuk mengonversi file SVG menjadi sekumpulan bentuk:

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

    // Konversi gambar SVG menjadi grup bentuk dan skala ke ukuran slide
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Simpan presentasi dalam format PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Menambahkan Gambar sebagai EMF ke Slide**
Aspose.Slides untuk .NET memungkinkan Anda menghasilkan gambar EMF dari lembar kerja Excel dengan Aspose.Cells dan menambahkannya ke slide presentasi.

Kode contoh C# berikut menunjukkan cara melakukannya:

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

Aspose.Slides memungkinkan Anda mengganti gambar yang disimpan dalam koleksi gambar presentasi, termasuk gambar yang digunakan oleh bentuk slide. Bagian ini menjelaskan beberapa cara memperbarui gambar dalam koleksi. Anda dapat mengganti gambar menggunakan data byte mentah, sebuah instance [IImage](https://reference.aspose.com/slides/id/net/aspose.slides/iimage/) , atau gambar lain yang sudah ada dalam koleksi.

Ikuti langkah‑langkah berikut:

1. Muat file presentasi yang berisi gambar menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
2. Muat gambar baru dari file ke dalam array byte.
3. Ganti gambar target dengan gambar baru menggunakan array byte.
4. Pada pendekatan kedua, muat gambar ke dalam objek [IImage](https://reference.aspose.com/slides/id/net/aspose.slides/iimage/) dan ganti gambar target dengan objek tersebut.
5. Pada pendekatan ketiga, ganti gambar target dengan gambar yang sudah ada dalam koleksi gambar presentasi.
6. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiasi kelas Presentation yang mewakili file presentasi.
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

// Simpan presentasi ke file.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}
Dengan konverter gratis [Teks ke GIF](https://products.aspose.app/slides/id/text-to-gif) dari Aspose, Anda dapat dengan mudah menganimasikan teks dan membuat GIF dari teks. 
{{% /alert %}}

## **FAQ**

**Apakah resolusi gambar asli tetap utuh setelah penyisipan?**

Ya. Piksel sumber dipertahankan, tetapi tampilan akhir tergantung pada bagaimana [gambar](/slides/id/net/picture-frame/) diubah skalanya pada slide dan kompresi yang diterapkan saat menyimpan.

**Apa cara terbaik untuk mengganti logo yang sama di puluhan slide sekaligus?**

Letakkan logo pada slide master atau layout dan ganti di koleksi gambar presentasi—pembaruan akan menyebar ke semua elemen yang menggunakan sumber daya tersebut.

**Apakah SVG yang disisipkan dapat dikonversi menjadi bentuk yang dapat diedit?**

Ya. Anda dapat mengonversi SVG menjadi grup bentuk, setelah itu bagian‑bagian individual menjadi dapat diedit dengan properti bentuk standar.

**Bagaimana cara mengatur gambar sebagai latar belakang untuk beberapa slide sekaligus?**

[Atur gambar sebagai latar belakang](/slides/id/net/presentation-background/) pada slide master atau layout yang relevan—setiap slide yang menggunakan master/layout tersebut akan mewarisi latar belakang.

**Bagaimana saya mencegah presentasi menjadi terlalu besar karena banyak gambar?**

Gunakan kembali satu sumber gambar alih‑alih duplikat, pilih resolusi yang wajar, terapkan kompresi saat menyimpan, dan simpan grafik berulang pada master bila tepat.