---
title: Ekspor Presentasi ke HTML dengan Gambar Tertaut Secara Eksternal
type: docs
weight: 100
url: /id/python-java/exporting-presentations-to-html-with-externally-linked-images/
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
- Python
- Java
- Aspose.Slides
description: "Ekspor presentasi PowerPoint dan OpenDocument ke HTML dalam Python menggunakan Aspose.Slides dengan gambar dan sumber daya lainnya disimpan sebagai berkas tertaut eksternal."
---
## **Ringkasan**

Secara default, Aspose.Slides mengekspor presentasi ke file HTML yang berdiri sendiri. Gambar dan sumber daya lain ditulis langsung ke dalam HTML, biasanya sebagai data Base64. Hal ini nyaman ketika Anda memerlukan satu file yang dapat dipindahkan, tetapi tidak selalu menjadi format terbaik untuk situs web, CMS, atau alur konversi sisi server.

Gunakan sumber daya yang ditautkan secara eksternal ketika Anda ingin:

- mengurangi ukuran dokumen HTML;
- menyimpan gambar, font, audio, atau video secara terpisah di browser atau CDN;
- memeriksa, mengganti, mengompres, atau memproses lanjutan sumber daya yang dihasilkan setelah ekspor;
- menjaga struktur keluaran lebih mendekati apa yang diharapkan aplikasi web.

Untuk alur kerja konversi HTML secara umum, lihat [Convert PowerPoint Presentations to HTML](/slides/id/python-java/convert-powerpoint-to-html/). Artikel ini berfokus pada bagian penautan sumber daya dari ekspor.

## **Cara Kerja Ekspor Sumber Daya yang Ditautkan**

`ILinkEmbedController` memungkinkan aplikasi Anda memutuskan, sumber daya per sumber daya, apakah pengekspor menyematkan data dalam HTML atau menyimpannya secara eksternal dan menulis tautan.

Antarmuka memiliki tiga metode:

- `ILinkEmbedController.getObjectStoringLocation` menentukan apakah sebuah sumber daya harus ditautkan atau disematkan.
- `ILinkEmbedController.getUrl` mengembalikan URL yang akan ditulis ke HTML yang dihasilkan atau ke sumber daya tertaut lainnya.
- `ILinkEmbedController.saveExternal` menulis data sumber daya tertaut ke disk atau ke target penyimpanan lain.

Jalur sistem berkas dan URL browser adalah hal yang terpisah. Misalnya, contoh di bawah ini menulis berkas sumber daya ke `html-output/assets` di disk, sementara HTML berisi URL relatif seperti `assets/resource-1.svg`. Browser menyelesaikan URL tersebut relatif terhadap berkas yang berisi tautan. Oleh karena itu, tautan dari `presentation.html` ke berkas SVG menggunakan `assets/resource-1.svg`, sementara tautan dari berkas SVG itu ke gambar yang disimpan di folder `assets` yang sama menggunakan `resource-4.jpg`.

## **Ekspor HTML dengan Sumber Daya Tertaut**

Contoh Python berikut membuat direktori output, menyimpan berkas HTML di sana, dan menyimpan sumber daya tertaut dalam subdirektori `assets`. Kontroler menautkan gambar, font, audio, video, dan sumber daya CSS umum ketika Aspose.Slides menyediakan atau dapat menyimpulkan ekstensi berkas yang aman. Sumber daya yang tidak dikenali tetap disematkan.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, LinkEmbedDecision, Presentation, SVGOptions, SaveFormat, SlideImageFormat


class ExternalResourceController:
    EXTENSIONS_BY_CONTENT_TYPE = {
        "image/jpeg": ".jpg",
        "image/png": ".png",
        "image/gif": ".gif",
        "image/bmp": ".bmp",
        "image/svg+xml": ".svg",
        "image/tiff": ".tiff",
        "image/x-emf": ".emf",
        "image/x-wmf": ".wmf",
        "font/woff": ".woff",
        "font/woff2": ".woff2",
        "font/ttf": ".ttf",
        "application/font-woff": ".woff",
        "application/vnd.ms-fontobject": ".eot",
        "application/x-font-ttf": ".ttf",
        "text/css": ".css",
        "audio/mpeg": ".mp3",
        "audio/mp4": ".m4a",
        "audio/wav": ".wav",
        "video/mp4": ".mp4",
        "video/webm": ".webm",
    }

    def __init__(self, asset_directory, asset_url_prefix):
        self.asset_directory = asset_directory
        normalized_prefix = asset_url_prefix.replace("\\", "/") if asset_url_prefix else ""
        self.asset_url_prefix = normalized_prefix.rstrip("/") + "/" if normalized_prefix else ""
        self.file_names_by_resource_id = {}

    def getObjectStoringLocation(self, resource_id, entity_data, semantic_name, content_type, recommended_extension):
        extension = self.resolve_extension(content_type, recommended_extension)
        if extension is None:
            return LinkEmbedDecision.Embed

        self.file_names_by_resource_id[resource_id] = f"resource-{resource_id}{extension}"
        return LinkEmbedDecision.Link

    def getUrl(self, resource_id, referrer):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            return None
        if referrer in self.file_names_by_resource_id:
            return file_name
        return self.asset_url_prefix + file_name

    def saveExternal(self, resource_id, entity_data):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            print(f"Resource {resource_id} was not registered for external storage.")
            return
        if entity_data is None or len(entity_data) == 0:
            print(f"Resource {resource_id} contains no data and cannot be saved.")
            return

        try:
            self.asset_directory.mkdir(parents=True, exist_ok=True)
            file_path = self.asset_directory / file_name
            resource_data = bytes(entity_data)
            file_path.write_bytes(resource_data)
        except OSError as error:
            print(f"Failed to save external resource {resource_id}: {error}")

    @classmethod
    def resolve_extension(cls, content_type, recommended_extension):
        content_type = str(content_type) if content_type is not None else ""
        mapped_extension = cls.EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if mapped_extension is not None:
            return mapped_extension
        if not content_type.lower().startswith(("image/", "font/", "audio/", "video/")):
            return None
        if recommended_extension is None:
            return None
        extension_characters = str(recommended_extension).strip().lstrip(".")
        if not extension_characters or not extension_characters.isalnum():
            return None
        return "." + extension_characters.lower()


input_file_path = Path("presentation.pptx")
output_directory = Path("html-output")
asset_directory_name = "assets"
asset_directory = output_directory / asset_directory_name

output_directory.mkdir(parents=True, exist_ok=True)
asset_directory.mkdir(parents=True, exist_ok=True)

asset_url_prefix = asset_directory_name + "/"
controller = ExternalResourceController(asset_directory, asset_url_prefix)
controller_proxy = jpype.JProxy("com.aspose.slides.ILinkEmbedController", inst=controller)
svg_options = SVGOptions(controller_proxy)
slide_image_format = SlideImageFormat.svg(svg_options)

html_options = HtmlOptions(controller_proxy)
html_formatter = HtmlFormatter.createDocumentFormatter("", False)
html_options.setHtmlFormatter(html_formatter)
html_options.setSlideImageFormat(slide_image_format)

presentation = Presentation(str(input_file_path))
try:
    html_file_path = output_directory / "presentation.html"
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
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

Berkas yang sebenarnya tergantung pada konten presentasi dan opsi ekspor. Misalnya, gambar raster biasanya diekspor sebagai JPEG atau PNG. Aspose.Slides dapat memilih codec gambar yang berbeda dari yang digunakan dalam presentasi sumber ketika itu menghasilkan berkas yang lebih kecil atau lebih cocok. Gambar dengan transparansi diekspor sebagai PNG.

## **Memilih URL untuk Penyebaran**

Contoh menggunakan prefiks URL relatif: `assets/`. Jika `presentation.html` dibuka dari `html-output/presentation.html`, browser memuat `html-output/assets/resource-1.svg`.

Ketika satu sumber daya tertaut merujuk ke sumber daya tertaut lainnya, contoh menggunakan parameter `referrer` dalam `ILinkEmbedController.getUrl` dan mengembalikan hanya nama berkas. Misalnya, jika `resource-1.svg` dan `resource-4.jpg` keduanya berada di folder `assets`, berkas SVG harus merujuk ke `resource-4.jpg`, bukan ke `assets/resource-4.jpg`.

Gunakan prefiks URL yang berbeda ketika berkas disebarkan ke tempat lain:

- Gunakan `assets/` ketika direktori aset berada di samping berkas HTML.
- Gunakan `../assets/` ketika direktori aset satu tingkat di atas berkas HTML.
- Gunakan `https://cdn.example.com/presentations/job-123/assets/` ketika berkas diunggah ke CDN atau server berkas statis.

URL yang dikembalikan oleh `ILinkEmbedController.getUrl` harus sesuai dengan lokasi penyebaran akhir berkas yang ditulis oleh `ILinkEmbedController.saveExternal`. Dalam aplikasi server, gunakan direktori output unik atau prefiks penyimpanan objek untuk setiap pekerjaan konversi guna menghindari penimpaan berkas dari ekspor lain.

## **Kapan Harus Menyematkan Sebagai Ganti**

HTML berbasis Base64 yang disematkan masih berguna ketika output harus berupa satu berkas, seperti lampiran email, pratinjau offline, atau dokumen yang akan dipindahkan tanpa folder aset pendukung. Sumber daya tertaut lebih cocok ketika HTML akan disajikan oleh aplikasi web, disimpan dalam CMS, dioptimalkan oleh pipeline build, atau di-cache oleh browser secara terpisah dari HTML.

## **FAQ**

**Bisakah saya mengeksternalisasi hanya gambar dan tetap menyematkan sumber daya lain?**

Ya. Di `ILinkEmbedController.getObjectStoringLocation`, kembalikan [LinkEmbedDecision.Link](https://reference.aspose.com/slides/id/python-java/aspose.slides/linkembeddecision/#Link) hanya untuk tipe konten yang ingin Anda simpan sebagai berkas terpisah, dan kembalikan [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/id/python-java/aspose.slides/linkembeddecision/#Embed) untuk semua yang lain.

**Mengapa ekstensi gambar yang diekspor berbeda dari presentasi sumber?**

Aspose.Slides dapat mengkode ulang gambar raster selama ekspor HTML untuk memperbaiki ukuran atau kompatibilitas browser. Misalnya, sebuah gambar dari berkas sumber dapat ditulis sebagai JPEG atau PNG tergantung pada hasil render.

**Apakah URL relatif tetap berfungsi setelah saya memindahkan berkas HTML?**

URL relatif hanya berfungsi ketika struktur folder relatif yang sama dipertahankan. Jika HTML merujuk ke `assets/resource-1.png`, folder `assets` harus tetap berada di samping berkas HTML kecuali Anda membuat prefiks URL yang berbeda.

**Haruskah aplikasi server menggunakan kembali folder output yang sama?**

Tidak. Gunakan direktori output unik atau prefiks penyimpanan untuk setiap pekerjaan konversi. Ini menghindari bentrok nama berkas dan mencegah satu ekspor menimpa sumber daya yang dihasilkan oleh ekspor lain.