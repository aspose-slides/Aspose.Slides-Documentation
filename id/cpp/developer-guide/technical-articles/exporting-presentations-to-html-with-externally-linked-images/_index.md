---
title: Ekspor Presentasi ke HTML dengan Gambar Tertaut Secara Eksternal
type: docs
weight: 50
url: /id/cpp/exporting-presentations-to-html-with-externally-linked-images/
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
- C++
- Aspose.Slides
description: "Ekspor presentasi PowerPoint dan OpenDocument ke HTML dalam C++ menggunakan Aspose.Slides dengan gambar dan sumber daya lain disimpan sebagai berkas tertaut eksternal."
---
## **Gambaran Umum**

Secara default, Aspose.Slides mengekspor presentasi ke file HTML yang berdiri sendiri. Gambar dan sumber daya lainnya ditulis langsung ke HTML, biasanya sebagai data Base64. Ini memudahkan ketika Anda membutuhkan satu file yang dapat dipindahkan, tetapi tidak selalu menjadi format terbaik untuk situs web, CMS, atau pipeline konversi sisi server.

Gunakan sumber daya yang ditautkan secara eksternal ketika Anda ingin:

- mengurangi ukuran dokumen HTML;
- menyimpan cache gambar, font, audio, atau video secara terpisah di browser atau CDN;
- memeriksa, mengganti, mengompres, atau memproses lebih lanjut sumber daya yang dihasilkan setelah ekspor;
- menjaga struktur keluaran lebih mirip dengan yang diharapkan aplikasi web.

Untuk alur kerja konversi HTML umum, lihat [Convert PowerPoint Presentations to HTML](/slides/id/cpp/convert-powerpoint-to-html/). Artikel ini berfokus pada bagian penautan sumber daya dari ekspor.

## **Bagaimana Ekspor Sumber Daya Tertaut Bekerja**

[ILinkEmbedController](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/ilinkembedcontroller/) memungkinkan aplikasi Anda memutuskan, sumber daya demi sumber daya, apakah pengekspor menyematkan data di HTML atau menyimpannya secara eksternal dan menulis tautan.

Antarmuka memiliki tiga metode:

- [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) menentukan apakah sebuah sumber daya harus ditautkan atau disematkan.
- [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) mengembalikan URL yang akan ditulis ke HTML yang dihasilkan atau ke sumber daya tertaut lainnya.
- [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) menulis data sumber daya tertaut ke disk atau ke target penyimpanan lainnya.

Jalur sistem berkas dan URL browser adalah perhatian terpisah. Misalnya, contoh di bawah menulis berkas sumber daya ke `html-output/assets` di disk, sementara HTML berisi URL relatif seperti `assets/resource-1.svg`. Browser menyelesaikan URL tersebut relatif terhadap berkas yang berisi tautan. Oleh karena itu, tautan dari `presentation.html` ke berkas SVG menggunakan `assets/resource-1.svg`, sementara tautan dari berkas SVG tersebut ke gambar yang disimpan di folder `assets` yang sama menggunakan `resource-4.jpg`.

## **Ekspor HTML dengan Sumber Daya Tertaut**

Contoh C++ berikut membuat direktori output, menyimpan berkas HTML di sana, dan menyimpan sumber daya tertaut di subdirektori `assets`. Kontroler menautkan gambar, font, audio, video, dan sumber daya CSS umum ketika Aspose.Slides menyediakan atau dapat menyimpulkan ekstensi berkas yang aman. Sumber daya yang tidak dikenali tetap disematkan.

```cpp
class ExternalResourceController : public ILinkEmbedController
{
public:
    ExternalResourceController(String assetDirectory, String assetUrlPrefix)
    {
        if (IsNullOrWhiteSpace(assetDirectory))
        {
            throw Exception(u"The asset output directory must not be empty.");
        }

        m_assetDirectory = assetDirectory;
        m_assetUrlPrefix = NormalizeUrlPrefix(assetUrlPrefix);
        m_fileNamesByResourceId = MakeObject<Dictionary<int, String>>();
    }

    LinkEmbedDecision GetObjectStoringLocation(
        int resourceId,
        ArrayPtr<uint8_t> entityData,
        String semanticName,
        String contentType,
        String recommendedExtension) override
    {
        auto extension = ResolveExtension(contentType, recommendedExtension);
        if (String::IsNullOrEmpty(extension))
        {
            return LinkEmbedDecision::Embed;
        }

        auto fileName = String::Format(u"resource-{0}{1}", resourceId, extension);
        m_fileNamesByResourceId->Add(resourceId, fileName);
        return LinkEmbedDecision::Link;
    }

    String GetUrl(int resourceId, int referrer) override
    {
        String fileName;
        if (!m_fileNamesByResourceId->TryGetValue(resourceId, fileName))
        {
            return nullptr;
        }

        if (m_fileNamesByResourceId->ContainsKey(referrer))
        {
            return fileName;
        }

        return m_assetUrlPrefix + fileName;
    }

    void SaveExternal(int resourceId, ArrayPtr<uint8_t> entityData) override
    {
        String fileName;
        if (!m_fileNamesByResourceId->TryGetValue(resourceId, fileName))
        {
            auto message = String::Format(u"Resource {0} was not registered for external storage.", resourceId);
            throw Exception(message);
        }

        if (entityData == nullptr || entityData->get_Length() == 0)
        {
            auto message = String::Format(u"Resource {0} contains no data and cannot be saved.", resourceId);
            throw Exception(message);
        }

        Directory::CreateDirectory_(m_assetDirectory);

        auto filePath = Path::Combine(m_assetDirectory, fileName);
        auto fileStream = MakeObject<FileStream>(filePath, FileMode::Create, FileAccess::Write);
        fileStream->Write(entityData, 0, entityData->get_Length());
        fileStream->Close();
    }

private:
    String m_assetDirectory;
    String m_assetUrlPrefix;
    SharedPtr<Dictionary<int, String>> m_fileNamesByResourceId;

    static SharedPtr<Dictionary<String, String>> GetExtensionsByContentType()
    {
        auto extensionsByContentType = MakeObject<Dictionary<String, String>>();
        extensionsByContentType->Add(u"image/jpeg", u".jpg");
        extensionsByContentType->Add(u"image/png", u".png");
        extensionsByContentType->Add(u"image/gif", u".gif");
        extensionsByContentType->Add(u"image/bmp", u".bmp");
        extensionsByContentType->Add(u"image/svg+xml", u".svg");
        extensionsByContentType->Add(u"image/tiff", u".tiff");
        extensionsByContentType->Add(u"image/x-emf", u".emf");
        extensionsByContentType->Add(u"image/x-wmf", u".wmf");
        extensionsByContentType->Add(u"font/woff", u".woff");
        extensionsByContentType->Add(u"font/woff2", u".woff2");
        extensionsByContentType->Add(u"font/ttf", u".ttf");
        extensionsByContentType->Add(u"application/font-woff", u".woff");
        extensionsByContentType->Add(u"application/vnd.ms-fontobject", u".eot");
        extensionsByContentType->Add(u"application/x-font-ttf", u".ttf");
        extensionsByContentType->Add(u"text/css", u".css");
        extensionsByContentType->Add(u"audio/mpeg", u".mp3");
        extensionsByContentType->Add(u"audio/mp4", u".m4a");
        extensionsByContentType->Add(u"audio/wav", u".wav");
        extensionsByContentType->Add(u"video/mp4", u".mp4");
        extensionsByContentType->Add(u"video/webm", u".webm");
        return extensionsByContentType;
    }

    static String ResolveExtension(String contentType, String recommendedExtension)
    {
        auto normalizedContentType = NormalizeContentType(contentType);
        auto extensionsByContentType = GetExtensionsByContentType();

        String mappedExtension;
        if (!String::IsNullOrEmpty(normalizedContentType) &&
            extensionsByContentType->TryGetValue(normalizedContentType, mappedExtension))
        {
            return mappedExtension;
        }

        if (!IsSupportedContentType(normalizedContentType))
        {
            return nullptr;
        }

        return NormalizeExtension(recommendedExtension);
    }

    static bool IsSupportedContentType(String contentType)
    {
        return !String::IsNullOrEmpty(contentType) &&
            (contentType.StartsWith(u"image/") ||
                contentType.StartsWith(u"font/") ||
                contentType.StartsWith(u"audio/") ||
                contentType.StartsWith(u"video/"));
    }

    static String NormalizeContentType(String contentType)
    {
        if (IsNullOrWhiteSpace(contentType))
        {
            return nullptr;
        }

        return contentType.Trim().ToLowerInvariant();
    }

    static String NormalizeExtension(String extension)
    {
        if (IsNullOrWhiteSpace(extension))
        {
            return nullptr;
        }

        auto extensionCharacters = extension.Trim();
        if (extensionCharacters.StartsWith(u"."))
        {
            extensionCharacters = extensionCharacters.Substring(1);
        }

        if (String::IsNullOrEmpty(extensionCharacters))
        {
            return nullptr;
        }

        auto extensionLength = extensionCharacters.get_Length();
        for (int index = 0; index < extensionLength; index++)
        {
            auto character = extensionCharacters[index];
            if (!Char::IsLetterOrDigit(character))
            {
                return nullptr;
            }
        }

        return u"." + extensionCharacters.ToLowerInvariant();
    }

    static String NormalizeUrlPrefix(String urlPrefix)
    {
        if (String::IsNullOrEmpty(urlPrefix))
        {
            return String::Empty;
        }

        auto normalizedUrlPrefix = urlPrefix.Replace(u"\\", u"/");
        if (normalizedUrlPrefix.EndsWith(u"/"))
        {
            return normalizedUrlPrefix;
        }

        return normalizedUrlPrefix + u"/";
    }

    static bool IsNullOrWhiteSpace(String value)
    {
        return String::IsNullOrEmpty(value) || String::IsNullOrEmpty(value.Trim());
    }
};
```
```cpp
auto inputFilePath = String(u"presentation.pptx");
auto outputDirectory = String(u"html-output");
auto assetDirectoryName = String(u"assets");
auto assetDirectory = Path::Combine(outputDirectory, assetDirectoryName);

Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(assetDirectory);

auto assetUrlPrefix = assetDirectoryName + u"/";
auto controller = MakeObject<ExternalResourceController>(assetDirectory, assetUrlPrefix);
auto svgOptions = MakeObject<SVGOptions>(controller);
auto slideImageFormat = SlideImageFormat::Svg(svgOptions);

auto htmlOptions = MakeObject<HtmlOptions>(controller);
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(String::Empty, false));
htmlOptions->set_SlideImageFormat(slideImageFormat);

auto presentation = MakeObject<Presentation>(inputFilePath);

auto htmlFilePath = Path::Combine(outputDirectory, u"presentation.html");
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);
presentation->Dispose();
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

Berkas yang tepat bergantung pada konten presentasi dan opsi ekspor. Misalnya, gambar raster biasanya diekspor sebagai JPEG atau PNG. Aspose.Slides dapat memilih codec gambar yang berbeda dari yang digunakan dalam presentasi sumber bila hal itu menghasilkan berkas yang lebih kecil atau lebih cocok. Gambar dengan transparansi diekspor sebagai PNG.

## **Memilih URL untuk Penyebaran**

Contoh menggunakan prefiks URL relatif: `assets/`. Jika `presentation.html` dibuka dari `html-output/presentation.html`, browser memuat `html-output/assets/resource-1.svg`.

Ketika satu sumber daya tertaut merujuk ke sumber daya tertaut lainnya, contoh menggunakan parameter `referrer` di [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) dan mengembalikan hanya nama berkas. Misalnya, jika `resource-1.svg` dan `resource-4.jpg` keduanya berada di folder `assets`, berkas SVG harus merujuk ke `resource-4.jpg`, bukan ke `assets/resource-4.jpg`.

Gunakan prefiks URL yang berbeda ketika berkas-berkas tersebut ditempatkan di tempat lain:

- Gunakan `assets/` ketika direktori aset berada di samping berkas HTML.
- Gunakan `../assets/` ketika direktori aset berada satu level di atas berkas HTML.
- Gunakan `https://cdn.example.com/presentations/job-123/assets/` ketika berkas diunggah ke CDN atau server berkas statis.

URL yang dikembalikan oleh [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) harus cocok dengan lokasi akhir penyebaran berkas yang ditulis oleh [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/). Pada aplikasi server, gunakan direktori output atau prefiks penyimpanan objek yang unik untuk setiap pekerjaan konversi agar tidak menimpa berkas dari ekspor lain.

## **Kapan Harus Menyematkan Sebagai Ganti**

HTML dengan Base64 yang disematkan masih berguna ketika output harus berupa satu berkas tunggal, seperti lampiran email, pratinjau offline, atau dokumen yang akan dipindahkan tanpa folder aset pendukung. Sumber daya yang ditautkan lebih cocok ketika HTML akan dilayani oleh aplikasi web, disimpan dalam CMS, dioptimalkan oleh pipeline build, atau di-cache oleh browser secara terpisah dari HTML.

## **FAQ**

**Apakah saya dapat mengeksternalisasi hanya gambar dan membiarkan sumber daya lain tetap disematkan?**

Ya. Pada [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/), kembalikan `LinkEmbedDecision::Link` hanya untuk tipe konten yang ingin Anda simpan sebagai berkas terpisah, dan kembalikan `LinkEmbedDecision::Embed` untuk semua yang lainnya.

**Mengapa ekstensi gambar yang diekspor berbeda dari presentasi sumber?**

Aspose.Slides dapat melakukan enkoding ulang gambar raster selama ekspor HTML untuk memperbaiki ukuran atau kompatibilitas browser. Misalnya, gambar dari berkas sumber dapat ditulis sebagai JPEG atau PNG tergantung pada hasil render.

**Apakah URL relatif tetap berfungsi setelah saya memindahkan berkas HTML?**

URL relatif hanya berfungsi ketika struktur folder relatif yang sama dipertahankan. Jika HTML merujuk ke `assets/resource-1.png`, folder `assets` harus tetap berada di samping berkas HTML kecuali Anda menghasilkan prefiks URL yang berbeda.

**Haruskah aplikasi server menggunakan kembali folder output yang sama?**

Tidak. Gunakan direktori output atau prefiks penyimpanan yang unik untuk setiap pekerjaan konversi. Hal ini mencegah tabrakan nama berkas dan menghindari satu ekspor menimpa sumber daya yang dihasilkan oleh ekspor lain.