---
title: Ekstrak Gambar dari Bentuk Presentasi dengan Python
linktitle: Gambar dari Bentuk
type: docs
weight: 90
url: /id/python-net/extracting-images-from-presentation-shapes/
keywords:
- ekstrak gambar
- ambil gambar
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Ekstrak gambar dari bentuk dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk Python melalui .NET - solusi cepat dan ramah kode."
---
## **Gambaran Umum**

Gambar dalam presentasi dapat muncul dalam beberapa jenis bentuk: sebagai bingkai gambar biasa, sebagai isian gambar yang diterapkan pada bentuk, sebagai gambar pratinjau objek OLE, sebagai thumbnail bingkai video atau audio, sebagai gambar zoom, atau sebagai gambar yang berada di dalam tabel, diagram, dan bentuk SmartArt. Aspose.Slides menyimpan gambar‑gambar tersebut dalam koleksi gambar presentasi, yang dapat diakses melalui objek [ImageCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/imagecollection/) dan [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/).

Jika Anda hanya perlu mengekspor setiap sumber gambar yang disematkan dalam presentasi, iterasi melalui `presentation.images`. Artikel ini berfokus pada tugas yang berbeda: menelusuri bentuk untuk menemukan di mana gambar digunakan pada slide, sehingga file yang disimpan dapat mempertahankan konteks berguna seperti nomor slide, posisi bentuk, dan jenis sumber (bingkai gambar, gambar isian, pratinjau media, pratinjau OLE, atau gambar zoom).

{{% alert title="Tip" color="primary" %}}
Gunakan properti `binary_data` dari [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) untuk mempertahankan data gambar yang terkodekan asli dan tipe berkasnya. Gunakan properti `image` dengan `save` ketika Anda ingin menormalkan output ke format tertentu seperti PNG.
{{% /alert %}}

## **Metode Pembantu Bersama**

Metode pembantu di bawah ini membuat contoh tetap singkat. `save_original_image` menulis byte yang disematkan asli, memilih ekstensi yang aman dari tipe MIME, dan melewatkan gambar duplikat berdasarkan hash SHA-256.

```py
import hashlib
import re
from pathlib import Path

import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.smartart as smartart


def save_original_image(image, output_directory, file_name_base, saved_image_hashes):
    image_data = bytes(image.binary_data)
    image_hash = hashlib.sha256(image_data).hexdigest()
    if image_hash in saved_image_hashes:
        return False

    saved_image_hashes.add(image_hash)
    extension = get_extension_from_content_type(image.content_type)
    file_name = f"{file_name_base}.{extension}"
    output_path = Path(output_directory) / file_name
    output_path.write_bytes(image_data)
    return True


def save_image_as_png(image, output_directory, file_name_base):
    file_name = f"{file_name_base}.png"
    output_path = Path(output_directory) / file_name
    image.image.save(str(output_path), slides.ImageFormat.PNG)


def get_picture_fill_image(fill_format):
    if fill_format is None or fill_format.fill_type != slides.FillType.PICTURE:
        return None

    return fill_format.picture_fill_format.picture.image


def enumerate_shapes(shapes, prefix, include_grouped_shapes):
    for shape_index, shape in enumerate(shapes, start=1):
        shape_name_part = f"{prefix}_shape_{shape_index}"
        yield shape, shape_name_part

        if include_grouped_shapes and isinstance(shape, slides.GroupShape):
            yield from enumerate_shapes(
                shape.shapes,
                shape_name_part,
                include_grouped_shapes)


def get_extension_from_content_type(content_type):
    if not content_type:
        return "bin"

    media_type = content_type.split(";")[0].strip().lower()
    extensions = {
        "image/jpeg": "jpg",
        "image/png": "png",
        "image/gif": "gif",
        "image/bmp": "bmp",
        "image/tiff": "tiff",
        "image/x-emf": "emf",
        "image/emf": "emf",
        "image/x-wmf": "wmf",
        "image/wmf": "wmf",
        "image/svg+xml": "svg",
    }

    if media_type in extensions:
        return extensions[media_type]

    if media_type.startswith("image/"):
        extension = media_type[len("image/"):]
        return make_safe_file_name_part(extension)

    return "bin"


def make_safe_file_name_part(value):
    return re.sub(r'[<>:"/\\|?*]', "_", value)
```

## **Ekstrak Gambar dari Bingkai Gambar**

Gunakan pendekatan ini untuk gambar yang dimasukkan sebagai objek terpisah. Sebuah [PictureFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/) menyimpan gambar dalam `picture_format.picture.image`, yang mengembalikan objek [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/).

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "extracted-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if type(shape) is slides.PictureFrame:
                image = shape.picture_format.picture.image
                save_original_image(image, output_directory, name_part, saved_image_hashes)
```

## **Ekstrak Gambar dari Bentuk yang Diisi Gambar**

Bentuk dapat menggunakan gambar sebagai isian mereka. Periksa jenis isian bentuk terlebih dahulu: jika bukan [FillType.PICTURE](https://reference.aspose.com/slides/id/python-net/aspose.slides/filltype/), tidak ada gambar yang dapat diekstrak dari isian tersebut. Contoh di bawah menangani objek [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) dan menyimpan setiap gambar sebagai PNG melalui properti `image` dari [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/).

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "shape-fill-images"
output_directory.mkdir(parents=True, exist_ok=True)

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.AutoShape):
                image = get_picture_fill_image(shape.fill_format)
                if image is not None:
                    save_image_as_png(image, output_directory, name_part)
```

## **Ekstrak Gambar Pratinjau dari Bingkai Objek OLE**

Sebuah [OleObjectFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/oleobjectframe/) dapat memiliki gambar pengganti yang digunakan PowerPoint sebagai pratinjau objek pada slide. Gambar ini tersedia melalui `substitute_picture_format.picture.image`. Mengekstrak gambar ini memberikan gambar pratinjau, bukan isi paket OLE yang disematkan.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "ole-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.OleObjectFrame):
                image = shape.substitute_picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Ekstrak Gambar Pratinjau dari Bingkai Video**

Sebuah [VideoFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/) juga dapat menyimpan gambar pratinjau di `picture_format.picture.image`. Ini adalah poster atau thumbnail yang ditampilkan pada slide, bukan frame yang di‑decode dari aliran video.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "video-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.VideoFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Ekstrak Gambar Pratinjau dari Bingkai Audio**

Sebuah [AudioFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/audioframe/) dapat menyimpan thumbnail di `picture_format.picture.image`. Ini adalah gambar yang ditampilkan untuk objek audio pada slide.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "audio-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.AudioFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Ekstrak Gambar dari Objek Zoom**

[ZoomFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/zoomframe/) dan [SectionZoomFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/sectionzoomframe/) dapat menggunakan gambar khusus. Baca `zoom_image` dari bingkai zoom.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.ZoomFrame) and shape.zoom_image is not None:
                file_name_base = f"{name_part}_zoom"
                save_original_image(shape.zoom_image, output_directory, file_name_base, saved_image_hashes)
                continue

            if isinstance(shape, slides.SectionZoomFrame) and shape.zoom_image is not None:
                file_name_base = f"{name_part}_section_zoom"
                save_original_image(shape.zoom_image, output_directory, file_name_base, saved_image_hashes)
                continue
```

## **Ekstrak Gambar dari Bingkai Ringkasan Zoom**

Sebuah [SummaryZoomFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/summaryzoomframe/) juga merupakan sebuah bentuk. Item bagianannya dapat menggunakan gambar khusus, yang dapat diakses melalui properti `zoom_image` masing‑masing pada setiap bagian ringkasan zoom.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "summary-zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.SummaryZoomFrame):
                section_count = len(shape.summary_zoom_collection)
                for section_index in range(section_count):
                    section = shape.summary_zoom_collection[section_index]
                    if section.zoom_image is not None:
                        display_index = section_index + 1
                        file_name_base = f"{name_part}_summary_zoom_{display_index}"
                        save_original_image(section.zoom_image, output_directory, file_name_base, saved_image_hashes)
```

## **Ekstrak Gambar dari Bentuk Tabel**

Sebuah [Table](https://reference.aspose.com/slides/id/python-net/aspose.slides/table/) adalah sebuah bentuk. Gambar dalam tabel biasanya disimpan sebagai isian gambar di sel tabel.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "table-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, slides.Table):
                row_count = len(shape.rows)
                column_count = len(shape.columns)
                for row_index in range(row_count):
                    for column_index in range(column_count):
                        cell = shape.rows[row_index][column_index]
                        image = get_picture_fill_image(cell.cell_format.fill_format)
                        if image is not None:
                            file_name_base = f"{name_part}_cell_{row_index + 1}_{column_index + 1}"
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Ekstrak Gambar dari Bentuk Diagram**

Sebuah [Chart](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/) adalah sebuah bentuk. Contoh di bawah mengekstrak gambar dari isian gambar area diagram.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "chart-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, charts.Chart):
                fill_format = shape.fill_format
                image = get_picture_fill_image(fill_format)
                if image is not None:
                    file_name_base = f"{name_part}_chart_area"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Ekstrak Gambar dari Bentuk SmartArt**

Sebuah objek [SmartArt](https://reference.aspose.com/slides/id/python-net/aspose.slides.smartart/smartart/) adalah sebuah bentuk. Tergantung pada tata letak SmartArt, gambar dapat disimpan dalam isian bullet node atau dalam format isian bentuk node.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "smartart-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, smartart.SmartArt):
                node_count = len(shape.all_nodes)
                for node_index in range(node_count):
                    node = shape.all_nodes[node_index]
                    bullet_image = get_picture_fill_image(node.bullet_fill_format)
                    if bullet_image is not None:
                        file_name_base = f"{name_part}_smartart_node_{node_index + 1}_bullet"
                        save_original_image(bullet_image, output_directory, file_name_base, saved_image_hashes)

                    node_shape_count = len(node.shapes)
                    for node_shape_index in range(node_shape_count):
                        node_shape = node.shapes[node_shape_index]
                        image = get_picture_fill_image(node_shape.fill_format)
                        if image is not None:
                            file_name_base = f"{name_part}_smartart_node_{node_index + 1}_shape_{node_shape_index + 1}"
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Sertakan Gambar di dalam Bentuk yang Dikelompokkan**

Bentuk yang dikelompokkan memiliki koleksi bentuk mereka sendiri. Pembantu `enumerate_shapes` yang dibagikan memiliki opsi `include_grouped_shapes`. Atur menjadi `True` ketika Anda ingin memeriksa bentuk di dalam objek [GroupShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/groupshape/) . Contoh di bawah mengekstrak gambar dari bingkai gambar, bentuk yang diisi gambar, pratinjau objek OLE, thumbnail bingkai video, dan thumbnail bingkai audio. Untuk menyertakan gambar tabel, diagram, SmartArt, dan zoom ringkasan juga, gunakan kembali logika ekstraksi khusus dari bagian sebelumnya sambil mempertahankan penelusuran bentuk rekursif yang sama.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "all-shape-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, slides.OleObjectFrame):
                image = shape.substitute_picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if isinstance(shape, slides.VideoFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if isinstance(shape, slides.AudioFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if type(shape) is slides.PictureFrame:
                image = shape.picture_format.picture.image
                save_original_image(image, output_directory, name_part, saved_image_hashes)
                continue

            if isinstance(shape, slides.AutoShape):
                image = get_picture_fill_image(shape.fill_format)
                if image is not None:
                    save_original_image(image, output_directory, name_part, saved_image_hashes)
```

## **Kasus Pinggir dan Catatan Praktis**

- **Gambar duplikat:** Banyak bentuk dapat merujuk pada gambar yang sama atau gambar terpisah dengan byte yang identik. Buat hash dari properti `binary_data` pada [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) sebelum menulis file jika Anda menginginkan satu file output per gambar unik.
- **Data asli vs. output yang dikonversi:** Menyimpan properti `binary_data` dari [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) mempertahankan data JPEG, PNG, GIF, SVG, EMF, atau WMF yang disematkan. Menyimpan properti `image` melalui `save` berguna ketika Anda menginginkan format output yang konsisten.
- **Jenis isian yang tidak didukung:** Jenis isian solid, gradien, pola, dan tanpa isian tidak mengandung isian gambar. Periksa [FillType](https://reference.aspose.com/slides/id/python-net/aspose.slides/filltype/) sebelum membaca `picture_fill_format`.
- **Bentuk yang dikelompokkan:** Koleksi bentuk slide tingkat atas tidak meratakan grup. Periksa secara rekursif [GroupShape.shapes](https://reference.aspose.com/slides/id/python-net/aspose.slides/groupshape/shapes/) ketika konten yang dikelompokkan penting.
- **Pratinjau objek OLE:** Sebuah [OleObjectFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/oleobjectframe/) mungkin menampilkan gambar pratinjau melalui `substitute_picture_format`, tetapi gambar tersebut hanya pratinjau slide. Itu bukan berkas yang disematkan di dalam objek OLE.
- **Thumbnail bingkai video:** Sebuah [VideoFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/) mungkin menampilkan gambar pratinjau melalui `picture_format`, tetapi gambar tersebut hanya poster yang ditampilkan pada slide. Itu tidak diambil dari aliran video.
- **Thumbnail bingkai audio:** Sebuah [AudioFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/audioframe/) mungkin menampilkan ikon atau thumbnail melalui `picture_format`; itu bukan data audio yang disematkan.
- **Gambar zoom:** Bentuk zoom slide, zoom bagian, dan zoom ringkasan dapat menggunakan objek [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) khusus melalui `image`.
- **Model bentuk bersarang:** Objek tabel, diagram, dan SmartArt mengimplementasikan [Shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/), tetapi gambar mereka sering disimpan dalam sel tabel bersarang, elemen diagram, atau objek pemformatan node SmartArt.
- **Gambar yang dipotong atau diubah:** Mengakses [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) memberikan Anda sumber gambar yang disimpan. Ini tidak menerapkan pemotongan, transparansi, recoloring, rotasi, atau efek visual lain yang diterapkan oleh bentuk.

## **Pertanyaan yang Sering Diajukan**

**Bisakah saya mengekstrak gambar asli tanpa pemotongan, efek, atau transformasi bentuk?**

Ya. Akses objek [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) dan tulis properti `binary_data`‑nya ke disk. Ini mempertahankan gambar terkodekan asli yang disimpan dalam presentasi, bukan cara gambar tersebut dirender pada slide.

**Bisakah saya mengekspor setiap gambar yang diekstrak sebagai PNG?**

Ya. Gunakan properti `image` dari [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) untuk mendapatkan objek gambar, lalu panggil `save` dengan [ImageFormat.PNG](https://reference.aspose.com/slides/id/python-net/aspose.slides/imageformat/). Ini mengonversi output dan mungkin tidak mempertahankan tipe berkas asli atau data vektor.

**Bagaimana cara menghindari penyimpanan gambar yang sama lebih dari sekali?**

Gunakan hash dari properti `binary_data` pada [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) dan simpan hash tersebut dalam sebuah set. Jika gambar baru memiliki hash yang sudah ada, lewati atau catat referensi lain ke file output yang sudah ada.

**Mengapa beberapa bentuk tidak menghasilkan gambar?**

Bingkai gambar, bentuk yang diisi gambar, bingkai objek OLE, bingkai media, bingkai zoom, tabel, diagram, dan objek SmartArt dapat merujuk pada gambar. Beberapa tipe bentuk menampilkan gambar melalui objek pemformatan bersarang, sehingga pemeriksaan sederhana `picture_format` atau `fill_format` pada bentuk tidak selalu cukup.

**Bisakah saya mengekstrak thumbnail yang ditampilkan untuk bingkai video?**

Ya. Gunakan [VideoFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/videoframe/) dan baca `picture_format.picture.image`. Ini mengekstrak gambar poster yang disimpan bersama bingkai video, bukan frame yang dihasilkan dari berkas video.

**Bagaimana saya dapat menentukan bentuk mana yang menggunakan gambar tertentu dari koleksi gambar presentasi?**

Aspose.Slides tidak menyimpan tautan terbalik dari [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) ke bentuk. Bangun pemetaan selama penelusuran: setiap kali Anda menemukan referensi gambar, catat nomor slide, jalur bentuk, dan hash gambar atau item koleksi.

**Bisakah saya mengekstrak gambar yang disematkan di dalam objek OLE, seperti dokumen terlampir?**

Anda dapat mengekstrak pratinjau slide objek OLE dari properti `substitute_picture_format` pada [OleObjectFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/oleobjectframe/). Namun, pratinjau tersebut bukan dokumen yang disematkan itu sendiri. Untuk mengekstrak gambar dari dalam berkas yang disematkan, ekstrak data OLE dan periksa dengan alat yang sesuai untuk tipe berkas tersebut.