---
title: Ekspor Presentasi ke HTML dengan Gambar yang Ditautkan Secara Eksternal di Python
linktitle: Ekspor Presentasi ke HTML dengan Gambar yang Ditautkan Secara Eksternal
type: docs
weight: 100
url: /id/python-net/exporting-presentations-to-html-with-externally-linked-images/
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
- gambar yang ditautkan
- gambar yang ditautkan secara eksternal
- sumber daya yang ditautkan
- sumber daya eksternal
- Python
- Aspose.Slides
description: "Ekspor presentasi PowerPoint dan OpenDocument ke HTML di Python menggunakan Aspose.Slides dengan gambar disimpan sebagai file tertaut eksternal."
---
## **Ikhtisar**

Secara default, Aspose.Slides mengekspor presentasi ke file HTML yang mandiri. Gambar dan sumber daya lainnya ditulis langsung ke dalam HTML, biasanya sebagai data Base64. Ini nyaman ketika Anda membutuhkan satu file yang dapat dipindahkan, tetapi tidak selalu menjadi format terbaik untuk situs web, CMS, atau pipeline konversi sisi server.

Gunakan gambar yang ditautkan secara eksternal ketika Anda ingin:

- mengurangi ukuran dokumen HTML;
- menyimpan gambar secara terpisah di browser atau CDN;
- memeriksa, mengganti, mengompres, atau memproses lanjutan gambar yang dihasilkan setelah ekspor;
- menjaga struktur output lebih dekat dengan apa yang diharapkan aplikasi web.

Untuk alur kerja konversi HTML umum, lihat [Convert PowerPoint Presentations to HTML](/slides/id/python-net/convert-powerpoint-to-html/). Artikel ini berfokus pada bagian penautan gambar dalam proses ekspor.

## **Cara Kerja Ekspor Gambar yang Ditautkan**

Di .NET dan Java, [ILinkEmbedController](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/ilinkembedcontroller/) mewakili antarmuka callback yang digunakan oleh exporter untuk memutuskan apakah sebuah sumber daya harus disematkan atau ditautkan. Di Python melalui .NET, kelas Python saat ini tidak dapat mengimplementasikan antarmuka callback .NET ini secara langsung, sehingga alur kerja praktisnya adalah:

1. Mengekspor presentasi ke HTML dengan [HtmlOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/htmloptions/).
1. Menggunakan [SlideImageFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/slideimageformat/) bersama [SVGOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/svgoptions/) sehingga slide direpresentasikan sebagai SVG dalam HTML.
1. Memindahkan data gambar Base64 dari URL `data:` di HTML ke file terpisah.
1. Mengganti URL `data:` asli dengan tautan relatif seperti `assets/resource-1.jpg`.

Jalur sistem file dan URL browser adalah dua hal yang terpisah. Misalnya, contoh di bawah menulis file gambar ke `html-output/assets` di disk, sementara HTML berisi URL relatif seperti `assets/resource-1.jpg`. Browser akan menyelesaikan URL tersebut relatif terhadap file HTML yang berisi tautan.

## **Ekspor HTML dengan Gambar yang Ditautkan**

Contoh Python berikut membuat direktori output, menyimpan file HTML di sana, menyimpan gambar yang diekstrak di subdirektori `assets`, dan menulis ulang URL gambar Base64 menjadi tautan relatif. Contoh ini mengekstrak format gambar Base64 umum ketika Aspose.Slides menyediakan ekstensi file yang aman. URL data yang tidak dikenali tetap disematkan.

```python
import base64
import os
import re

import aspose.slides as slides
import aspose.slides.export as slides_export


EXTENSIONS_BY_CONTENT_TYPE = {
    "image/jpeg": ".jpg",
    "image/png": ".png",
    "image/gif": ".gif",
    "image/bmp": ".bmp",
    "image/svg+xml": ".svg",
    "image/tiff": ".tiff",
    "image/x-emf": ".emf",
    "image/x-wmf": ".wmf",
}

DATA_URI_PATTERN = re.compile(
    r"data:(?P<content_type>[-\w.+]+/[-\w.+]+);base64,(?P<data>[A-Za-z0-9+/=\r\n]+)"
)


def export_presentation_to_html_with_linked_images(
    input_file_path,
    output_directory,
    asset_directory_name="assets",
):
    asset_directory = os.path.join(output_directory, asset_directory_name)

    os.makedirs(output_directory, exist_ok=True)
    os.makedirs(asset_directory, exist_ok=True)

    html_options = slides_export.HtmlOptions()
    html_options.html_formatter = slides_export.HtmlFormatter.create_document_formatter("", False)
    html_options.slide_image_format = slides_export.SlideImageFormat.svg(
        slides_export.SVGOptions()
    )

    html_file_path = os.path.join(output_directory, "presentation.html")

    with slides.Presentation(input_file_path) as presentation:
        presentation.save(html_file_path, slides_export.SaveFormat.HTML, html_options)

    externalize_base64_images(html_file_path, asset_directory, asset_directory_name)


def externalize_base64_images(html_file_path, asset_directory, asset_directory_name):
    with open(html_file_path, "r", encoding="utf-8-sig") as html_file:
        html_content = html_file.read()

    saved_resource_names = {}
    resource_index = 1

    def replace_data_uri(match):
        nonlocal resource_index

        data_uri = match.group(0)
        if data_uri in saved_resource_names:
            return saved_resource_names[data_uri]

        content_type = match.group("content_type").lower()
        extension = EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if extension is None:
            return data_uri

        encoded_data = match.group("data")
        image_data = base64.b64decode(encoded_data)
        if len(image_data) == 0:
            return data_uri

        file_name = f"resource-{resource_index}{extension}"
        resource_index += 1

        file_path = os.path.join(asset_directory, file_name)
        with open(file_path, "wb") as image_file:
            image_file.write(image_data)

        linked_url = f"{asset_directory_name}/{file_name}"
        saved_resource_names[data_uri] = linked_url
        return linked_url

    updated_html_content = DATA_URI_PATTERN.sub(replace_data_uri, html_content)

    with open(html_file_path, "w", encoding="utf-8", newline="\n") as html_file:
        html_file.write(updated_html_content)


input_file_path = "presentation.pptx"
output_directory = "html-output"

export_presentation_to_html_with_linked_images(input_file_path, output_directory)
```

Setelah ekspor, folder output mungkin memiliki struktur sebagai berikut:

```text
html-output/
  presentation.html
  assets/
    resource-1.jpg
    resource-2.png
```

File yang tepat bergantung pada konten presentasi dan opsi ekspor. Misalnya, gambar raster biasanya diekspor sebagai JPEG atau PNG. Aspose.Slides dapat memilih codec gambar yang berbeda dari yang digunakan dalam presentasi sumber ketika itu menghasilkan file yang lebih kecil atau lebih cocok. Gambar dengan transparansi diekspor sebagai PNG.

## **Memilih URL untuk Penyebaran**

Contoh menggunakan awalan URL relatif: `assets/`. Jika `presentation.html` dibuka dari `html-output/presentation.html`, browser akan memuat `html-output/assets/resource-1.jpg`.

Gunakan nama direktori aset yang berbeda atau tulis ulang tautan yang dihasilkan ketika file disebarkan ke lokasi lain:

- Gunakan `assets/` ketika direktori aset berada di samping file HTML.
- Gunakan `../assets/` ketika direktori aset satu tingkat di atas file HTML.
- Gunakan `https://cdn.example.com/presentations/job-123/assets/` ketika file diunggah ke CDN atau server file statis.

Dalam aplikasi server, gunakan direktori output unik atau awalan penyimpanan objek untuk setiap pekerjaan konversi agar tidak menimpa file dari ekspor lain.

## **Kapan Harus Menyematkan Sebagai Ganti Penautan**

HTML Base64 yang disematkan masih berguna ketika output harus berupa satu file, seperti lampiran email, pratinjau offline, atau dokumen yang akan dipindahkan tanpa folder aset pendukung. Gambar yang ditautkan lebih cocok ketika HTML akan disajikan oleh aplikasi web, disimpan dalam CMS, dioptimalkan oleh pipeline build, atau di‑cache oleh browser secara terpisah dari HTML.

## **FAQ**

**Apakah saya dapat mengeksternalisasi hanya gambar dan tetap menyematkan sumber daya lain?**

Ya. Contoh ini mengekstrak hanya URL data Base64 `image/*` yang tipe kontennya tercantum dalam `EXTENSIONS_BY_CONTENT_TYPE`. URL data lain tetap disematkan.

**Mengapa ekstensi gambar yang diekspor berbeda dari presentasi sumber?**

Aspose.Slides dapat melakukan pengkodean ulang gambar raster selama ekspor HTML untuk memperbaiki ukuran atau kompatibilitas browser. Misalnya, gambar dari file sumber dapat ditulis sebagai JPEG atau PNG tergantung pada hasil render.

**Apakah URL relatif tetap berfungsi setelah saya memindahkan file HTML?**

URL relatif hanya berfungsi ketika struktur folder relatif yang sama dipertahankan. Jika HTML merujuk ke `assets/resource-1.png`, folder `assets` harus tetap berada di samping file HTML kecuali Anda menghasilkan awalan URL yang berbeda.

**Haruskah aplikasi server menggunakan kembali folder output yang sama?**

Tidak. Gunakan direktori output unik atau awalan penyimpanan untuk setiap pekerjaan konversi. Hal ini menghindari tabrakan nama file dan mencegah satu ekspor menimpa sumber daya yang dihasilkan oleh ekspor lain.