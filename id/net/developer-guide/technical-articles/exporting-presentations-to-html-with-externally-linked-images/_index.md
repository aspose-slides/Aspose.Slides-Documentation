---
title: Ekspor Presentasi ke HTML dengan Gambar Tertaut Secara Eksternal
type: docs
weight: 100
url: /id/net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- ekspor PowerPoint
- ekspor OpenDocument
- ekspor presentasi
- ekspor slide
- ekspor PPT
- ekspor PPTX
- ekspor ODP
- PowerPoint ke HTML
- OpenDocument ke HTML
- presentasi ke HTML
- slide ke HTML
- PPT ke HTML
- PPTX ke HTML
- ODP ke HTML
- gambar tertaut
- gambar tertaut secara eksternal
- sumber daya tertaut
- sumber daya eksternal
- .NET
- C#
- Aspose.Slides
description: "Ekspor presentasi PowerPoint dan OpenDocument ke HTML di .NET menggunakan Aspose.Slides dengan gambar dan sumber daya lainnya disimpan sebagai file tertaut eksternal."
---
## **Ikhtisar**

Secara default, Aspose.Slides mengekspor presentasi ke file HTML yang berdiri sendiri. Gambar dan sumber daya lainnya ditulis langsung ke dalam HTML, biasanya sebagai data Base64. Ini praktis ketika Anda membutuhkan satu file portabel, tetapi tidak selalu menjadi format terbaik untuk situs web, CMS, atau pipeline konversi sisi server.

Gunakan sumber daya yang ditautkan secara eksternal ketika Anda ingin:

- mengurangi ukuran dokumen HTML;
- menyimpan gambar, font, audio, atau video secara terpisah di browser atau CDN;
- memeriksa, mengganti, mengompres, atau memproses lebih lanjut sumber daya yang dihasilkan setelah ekspor;
- menjaga struktur output lebih mendekati apa yang diharapkan oleh aplikasi web.

Untuk alur kerja konversi HTML umum, lihat [Convert PowerPoint Presentations to HTML](/slides/id/net/convert-powerpoint-to-html/). Artikel ini berfokus pada bagian penautan sumber daya dari ekspor.

## **Bagaimana Ekspor Sumber Daya Tertaut Bekerja**

[ILinkEmbedController](https://reference.aspose.com/slides/id/net/aspose.slides.export/ilinkembedcontroller/) memungkinkan aplikasi Anda memutuskan, sumber daya per sumber daya, apakah pengekspor menyematkan data ke dalam HTML atau menyimpannya secara eksternal dan menulis tautan.

Antarmuka memiliki tiga metode:

- [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/id/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) menentukan apakah sebuah sumber daya harus ditautkan atau disematkan.
- [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/id/net/aspose.slides.export/ilinkembedcontroller/geturl/) mengembalikan URL yang akan ditulis ke HTML yang dihasilkan atau ke sumber daya tertaut lainnya.
- [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/id/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) menulis data sumber daya tertaut ke disk atau ke target penyimpanan lain.

Jalur sistem file dan URL browser adalah hal yang terpisah. Misalnya, contoh di bawah menulis file sumber daya ke `html-output/assets` di disk, sementara HTML berisi URL relatif seperti `assets/resource-1.svg`. Browser menyelesaikan URL tersebut relatif terhadap file yang berisi tautan. Oleh karena itu, tautan dari `presentation.html` ke file SVG menggunakan `assets/resource-1.svg`, sementara tautan dari file SVG itu ke gambar yang disimpan di folder `assets` yang sama menggunakan `resource-4.jpg`.

## **Ekspor HTML dengan Sumber Daya Tertaut**

Contoh C# berikut membuat direktori output, menyimpan file HTML di sana, dan menyimpan sumber daya tertaut dalam subdirektori `assets`. Kontroler menautkan gambar, font, audio, video, dan sumber daya CSS umum ketika Aspose.Slides menyediakan atau dapat menyimpulkan ekstensi file yang aman. Sumber daya yang tidak dikenali tetap disematkan.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using System;
using System.Collections.Generic;
using System.IO;

var inputFilePath = "presentation.pptx";
var outputDirectory = "html-output";
var assetDirectoryName = "assets";
var assetDirectory = Path.Combine(outputDirectory, assetDirectoryName);

Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(assetDirectory);

var assetUrlPrefix = assetDirectoryName + "/";
var controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = HtmlFormatter.CreateDocumentFormatter(string.Empty, false),
    SlideImageFormat = slideImageFormat
};

using var presentation = new Presentation(inputFilePath);

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);

public sealed class ExternalResourceController : ILinkEmbedController
{
    private static readonly Dictionary<string, string> ExtensionsByContentType = new(StringComparer.OrdinalIgnoreCase)
    {
        ["image/jpeg"] = ".jpg",
        ["image/png"] = ".png",
        ["image/gif"] = ".gif",
        ["image/bmp"] = ".bmp",
        ["image/svg+xml"] = ".svg",
        ["image/tiff"] = ".tiff",
        ["image/x-emf"] = ".emf",
        ["image/x-wmf"] = ".wmf",
        ["font/woff"] = ".woff",
        ["font/woff2"] = ".woff2",
        ["font/ttf"] = ".ttf",
        ["application/font-woff"] = ".woff",
        ["application/vnd.ms-fontobject"] = ".eot",
        ["application/x-font-ttf"] = ".ttf",
        ["text/css"] = ".css",
        ["audio/mpeg"] = ".mp3",
        ["audio/mp4"] = ".m4a",
        ["audio/wav"] = ".wav",
        ["video/mp4"] = ".mp4",
        ["video/webm"] = ".webm"
    };

    private readonly string assetDirectory;
    private readonly string assetUrlPrefix;
    private readonly Dictionary<int, string> fileNamesByResourceId = new();

    public ExternalResourceController(string assetDirectory, string assetUrlPrefix)
    {
        if (string.IsNullOrWhiteSpace(assetDirectory))
        {
            throw new ArgumentException("The asset output directory must not be empty.", nameof(assetDirectory));
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = NormalizeUrlPrefix(assetUrlPrefix);
    }

    public LinkEmbedDecision GetObjectStoringLocation(
        int resourceId,
        byte[] entityData,
        string semanticName,
        string contentType,
        string recommendedExtension)
    {
        var extension = ResolveExtension(contentType, recommendedExtension);
        if (extension == null)
        {
            return LinkEmbedDecision.Embed;
        }

        fileNamesByResourceId[resourceId] = $"resource-{resourceId}{extension}";
        return LinkEmbedDecision.Link;
    }

    public string GetUrl(int resourceId, int referrer)
    {
        if (!fileNamesByResourceId.TryGetValue(resourceId, out var fileName))
        {
            return null;
        }

        if (fileNamesByResourceId.ContainsKey(referrer))
        {
            return fileName;
        }

        return assetUrlPrefix + fileName;
    }

    public void SaveExternal(int resourceId, byte[] entityData)
    {
        if (!fileNamesByResourceId.TryGetValue(resourceId, out var fileName))
        {
            throw new InvalidOperationException(
                $"Resource {resourceId} was not registered for external storage.");
        }

        if (entityData == null || entityData.Length == 0)
        {
            throw new InvalidOperationException(
                $"Resource {resourceId} contains no data and cannot be saved.");
        }

        Directory.CreateDirectory(assetDirectory);

        var filePath = Path.Combine(assetDirectory, fileName);
        File.WriteAllBytes(filePath, entityData);
    }

    private static string ResolveExtension(string contentType, string recommendedExtension)
    {
        if (!string.IsNullOrWhiteSpace(contentType) &&
            ExtensionsByContentType.TryGetValue(contentType, out var mappedExtension))
        {
            return mappedExtension;
        }

        if (!IsSupportedContentType(contentType))
        {
            return null;
        }

        return NormalizeExtension(recommendedExtension);
    }

    private static bool IsSupportedContentType(string contentType)
    {
        return contentType != null &&
            (contentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("font/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("audio/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("video/", StringComparison.OrdinalIgnoreCase));
    }

    private static string NormalizeExtension(string extension)
    {
        if (string.IsNullOrWhiteSpace(extension))
        {
            return null;
        }

        var extensionCharacters = extension.Trim().TrimStart('.');
        foreach (var character in extensionCharacters)
        {
            if (!char.IsLetterOrDigit(character))
            {
                return null;
            }
        }

        return "." + extensionCharacters.ToLowerInvariant();
    }

    private static string NormalizeUrlPrefix(string urlPrefix)
    {
        if (string.IsNullOrEmpty(urlPrefix))
        {
            return string.Empty;
        }

        var normalizedUrlPrefix = urlPrefix.Replace('\\', '/');
        return normalizedUrlPrefix.EndsWith("/")
            ? normalizedUrlPrefix
            : normalizedUrlPrefix + "/";
    }
}
```

Setelah ekspor, folder output memiliki struktur berikut:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

File yang tepat bergantung pada konten presentasi dan opsi ekspor. Misalnya, gambar raster biasanya diekspor sebagai JPEG atau PNG. Aspose.Slides dapat memilih kodek gambar yang berbeda dari yang digunakan dalam presentasi sumber jika itu menghasilkan file yang lebih kecil atau lebih cocok. Gambar dengan transparansi diekspor sebagai PNG.

## **Memilih URL untuk Penyebaran**

Contoh menggunakan awalan URL relatif: `assets/`. Jika `presentation.html` dibuka dari `html-output/presentation.html`, browser memuat `html-output/assets/resource-1.svg`.

Ketika satu sumber daya tertaut merujuk ke sumber daya tertaut lain, contoh menggunakan parameter `referrer` dalam [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/id/net/aspose.slides.export/ilinkembedcontroller/geturl/) dan mengembalikan hanya nama file. Misalnya, jika `resource-1.svg` dan `resource-4.jpg` keduanya berada di folder `assets`, file SVG harus merujuk ke `resource-4.jpg`, bukan ke `assets/resource-4.jpg`.

Gunakan awalan URL yang berbeda ketika file disebarkan di tempat lain:

- Gunakan `assets/` ketika direktori aset berada di samping file HTML.
- Gunakan `../assets/` ketika direktori aset satu level di atas file HTML.
- Gunakan `https://cdn.example.com/presentations/job-123/assets/` ketika file diunggah ke CDN atau server file statis.

URL yang dikembalikan oleh [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/id/net/aspose.slides.export/ilinkembedcontroller/geturl/) harus cocok dengan lokasi akhir file yang ditulis oleh [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/id/net/aspose.slides.export/ilinkembedcontroller/saveexternal/). Pada aplikasi server, gunakan direktori output unik atau awalan penyimpanan objek untuk setiap pekerjaan konversi guna menghindari penimpaan file dari ekspor lain.

## **Kapan Harus Menyematkan Sebagai Ganti**

HTML berisi Base64 yang disematkan masih berguna ketika output harus berupa satu file, seperti lampiran email, pratinjau offline, atau dokumen yang akan dipindahkan tanpa folder aset pendukung. Sumber daya tertaut lebih cocok ketika HTML akan disajikan oleh aplikasi web, disimpan di CMS, dioptimalkan oleh pipeline build, atau di-cache oleh browser secara terpisah dari HTML.

## **FAQ**

**Apakah saya dapat memisahkan hanya gambar dan tetap menyematkan sumber daya lainnya?**

Ya. Di [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/id/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/), kembalikan `LinkEmbedDecision.Link` hanya untuk tipe konten yang ingin Anda simpan sebagai file terpisah, dan kembalikan `LinkEmbedDecision.Embed` untuk semua yang lain.

**Mengapa ekstensi gambar yang diekspor berbeda dari presentasi sumber?**

Aspose.Slides dapat mengkode ulang gambar raster selama ekspor HTML untuk memperbaiki ukuran atau kompatibilitas browser. Misalnya, sebuah gambar dari file sumber dapat ditulis sebagai JPEG atau PNG tergantung pada hasil rendernya.

**Apakah URL relatif berfungsi setelah saya memindahkan file HTML?**

URL relatif hanya berfungsi ketika struktur folder relatif yang sama dipertahankan. Jika HTML merujuk ke `assets/resource-1.png`, folder `assets` harus tetap berada di samping file HTML kecuali Anda menghasilkan awalan URL yang berbeda.

**Apakah aplikasi server harus menggunakan kembali folder output yang sama?**

Tidak. Gunakan direktori output unik atau awalan penyimpanan untuk setiap pekerjaan konversi. Ini menghindari bentrok nama file dan mencegah satu ekspor menimpa sumber daya yang dihasilkan oleh ekspor lain.