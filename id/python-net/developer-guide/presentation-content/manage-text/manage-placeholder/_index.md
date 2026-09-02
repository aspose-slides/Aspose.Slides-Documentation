---
title: Kelola Placeholder Presentasi dalam Python
linktitle: Kelola Placeholder
type: docs
weight: 10
url: /id/python-net/manage-placeholder/
keywords:
- placeholder
- placeholder teks
- placeholder gambar
- placeholder diagram
- placeholder konten
- teks prompt
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara memeriksa dan mengedit placeholder teks, gambar, diagram, dan konten serta memahami pewarisan placeholder dengan Aspose.Slides untuk Python melalui .NET."
---
## **Ikhtisar**

Placeholder adalah sebuah shape yang menyimpan posisi untuk jenis konten tertentu dalam templat presentasi. Contoh umum meliputi placeholder judul, isi, gambar, diagram, dan placeholder konten serbaguna. Tidak seperti shape biasa, placeholder dapat mewarisi posisi, ukuran, pemformatan, dan pengaturan lainnya dari slide tata letak atau slide master.

Aspose.Slides mengekspos informasi placeholder melalui properti [Shape.placeholder](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/placeholder/). Properti ini mengembalikan objek [Placeholder](https://reference.aspose.com/slides/id/python-net/aspose.slides/placeholder/) atau `None` untuk shape normal. Gunakan [Placeholder.type](https://reference.aspose.com/slides/id/python-net/aspose.slides/placeholder/type/) untuk menentukan apa yang dimaksudkan untuk dimuat oleh placeholder.

Kelas shape tetap penting setelah Anda mengetahui tipe placeholder:

- Placeholder teks, gambar, diagram, atau konten kosong biasanya direpresentasikan oleh [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/).
- Placeholder gambar yang telah terisi dapat direpresentasikan oleh [PictureFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/).
- Placeholder diagram yang telah terisi dapat direpresentasikan oleh [Chart](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/).
- Placeholder konten dapat berisi beberapa jenis konten. Periksa baik [Placeholder.type](https://reference.aspose.com/slides/id/python-net/aspose.slides/placeholder/type/) maupun kelas shape runtime alih‑alih mengasumsikan setiap placeholder adalah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.type](https://reference.aspose.com/slides/id/python-net/aspose.slides/placeholder/type/) menjelaskan peran placeholder; ia tidak menjamin kelas runtime shape. Selalu lakukan pemeriksaan tipe sebelum mengakses anggota khusus teks, gambar, diagram, tabel, atau media.
{{% /alert %}}

## **Pahami Pewarisan Placeholder**

Placeholder membentuk hierarki:

1. Slide master mendefinisikan gaya yang dapat digunakan kembali dan, dalam beberapa kasus, placeholder tingkat master.
2. Slide tata letak mendefinisikan susunan yang digunakan oleh satu atau lebih slide normal dan dapat mewarisi dari master.
3. Slide normal berisi placeholder untuk slide tersebut dan dapat mewarisi dari tata letaknya.

Panggil [Shape.get_base_placeholder](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/get_base_placeholder/) untuk naik satu tingkat dalam hierarki ini. Placeholder slide biasanya mengembalikan placeholder tata letaknya; placeholder tata letak dapat mengembalikan placeholder masternya. Metode ini mengembalikan `None` ketika shape tidak memiliki placeholder dasar.

Contoh berikut mencantumkan placeholder pada slide pertama dan melaporkan placeholder dasarnya:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        type_name = type(shape).__name__
        print(f"Slide placeholder: {placeholder_type}; shape class: {type_name}")

        layout_placeholder = shape.get_base_placeholder()
        if layout_placeholder is not None:
            layout_placeholder_type = layout_placeholder.placeholder.type if layout_placeholder.placeholder is not None else None
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.get_base_placeholder()
            if master_placeholder is not None:
                master_placeholder_type = master_placeholder.placeholder.type if master_placeholder.placeholder is not None else None
                print(f"  Master placeholder: {master_placeholder_type}")
```

Mengedit placeholder pada slide normal membuat atau mengubah penimpaan lokal untuk slide tersebut. Mengedit tata letak atau master yang terkait dapat memengaruhi semua slide yang masih mewarisi pengaturan itu. Shape biasa lokal tidak memiliki placeholder dasar dan tidak mulai mewarisi hanya karena menempati koordinat yang sama.

## **Ubah Teks dalam Placeholder**

Placeholder judul, judul terpusat, subjudul, isi, dan teks biasanya mendukung teks. Periksa [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) sebelum menggunakan properti [text_frame](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/text_frame/).

Contoh ini memperbarui placeholder judul pertama pada slide pertama dan menyimpan hasilnya:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    title_shape = None

    for shape in slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            title_shape = shape
            break

    if title_shape is None:
        raise RuntimeError("The first slide does not contain a title placeholder.")

    title_shape.text_frame.text = "Quarterly Business Review"
    presentation.save("title-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Pola ini menghindari memperlakukan placeholder gambar, diagram, tabel, atau media sebagai objek [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/). Ia juga mengidentifikasi placeholder berdasarkan tujuan alih‑alih mengandalkan indeks shape yang rapuh.

## **Atur Teks Prompt pada Tata Letak**

Teks prompt adalah instruksi waktu‑desain yang ditampilkan dalam placeholder kosong, misalnya *Click to add title*. Atur teks prompt kustom pada placeholder tata letak alih‑alih mencoba mencapainya melalui koleksi shape slide normal. Akses tata letak melalui [Slide.layout_slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/layout_slide/) dan iterasikan [LayoutSlide.shapes](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseslide/shapes/).

Contoh berikut mengubah prompt judul dan subjudul pada tata letak yang digunakan oleh slide pertama:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    layout_slide = presentation.slides[0].layout_slide

    for shape in layout_slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            shape.text_frame.text = "Enter a concise slide title"
        elif placeholder_type == slides.PlaceholderType.SUBTITLE:
            shape.text_frame.text = "Enter a subtitle or reporting period"

    presentation.save("custom-placeholder-prompts.pptx", slides.export.SaveFormat.PPTX)
```

Teks prompt bukan konten slide normal. Ia ditujukan untuk placeholder kosong di aplikasi pengeditan seperti PowerPoint. Setelah pengguna atau program menyediakan konten nyata, prompt tidak lagi ditampilkan. Mengubah prompt juga tidak menggantikan teks yang sudah ada pada slide yang menggunakan tata letak tersebut.

## **Perbarui Placeholder Gambar**

Ada dua kasus yang harus ditangani:

- Jika placeholder gambar sudah terisi dan direpresentasikan oleh [PictureFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/), ganti gambar melalui [PictureFillFormat.picture](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/picture/) dan [Picture.image](https://reference.aspose.com/slides/id/python-net/aspose.slides/picture/image/).
- Jika masih berupa placeholder kosong, tambahkan picture frame pada koordinat placeholder dengan [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/add_picture_frame/) dan hapus placeholder kosong.

Contoh berikut mendukung kedua kasus dan menyimpan presentasi:

```python
import aspose.slides as slides

with slides.Presentation("picture-template.pptx") as presentation:
    slide = presentation.slides[0]
    picture_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        raise RuntimeError("The first slide does not contain a picture placeholder.")

    with open("replacement.png", "rb") as image_stream:
        image_bytes = image_stream.read()

    image = presentation.images.add_image(image_bytes)

    if isinstance(picture_placeholder, slides.PictureFrame):
        picture_placeholder.picture_format.picture.image = image
    else:
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, picture_placeholder.x, picture_placeholder.y, picture_placeholder.width, picture_placeholder.height, image)
        slide.shapes.remove(picture_placeholder)

    presentation.save("picture-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Penggantian yang dibuat untuk placeholder kosong adalah picture frame lokal, bukan placeholder baru, karena [Shape.placeholder](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/placeholder/) bersifat read‑only. Ia mempertahankan posisi yang dipesan tetapi tidak lagi mewarisi perilaku khusus placeholder. Jika mempertahankan hubungan placeholder penting, siapkan dan isi placeholder di PowerPoint terlebih dahulu, kemudian perbarui [PictureFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/) yang dihasilkan dengan Aspose.Slides.

Untuk transparansi gambar, pemotongan, dan efek khusus gambar lainnya, lihat [Manage Picture Frames](/slides/id/python-net/picture-frame/). Operasi tersebut berada pada picture frame atau picture fill, bukan pada metadata placeholder.

## **Bekerja dengan Placeholder Diagram dan Konten**

Placeholder diagram yang telah terisi dapat direpresentasikan oleh [Chart](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/). Contoh ini menemukan diagram tersebut dengan mengacu pada tipe placeholder dan kelas runtime, mengubah judulnya, dan menyimpan berkas:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-template.pptx") as presentation:
    slide = presentation.slides[0]
    placeholder_chart = None

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.CHART:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        raise RuntimeError("The first slide does not contain a populated chart placeholder.")

    placeholder_chart.has_title = True
    placeholder_chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    presentation.save("chart-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Placeholder konten umum biasanya memiliki [PlaceholderType.OBJECT](https://reference.aspose.com/slides/id/python-net/aspose.slides/placeholdertype/). Di PowerPoint ia berperan sebagai peluncur untuk beberapa jenis konten, termasuk diagram, tabel, diagram alur, gambar, dan media. Setelah terisi, periksa kelas shape aktual untuk mengetahui apa yang dikandungnya. Tata letak khusus juga dapat mengekspos [PlaceholderType.CHART](https://reference.aspose.com/slides/id/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/id/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/id/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/id/python-net/aspose.slides/placeholdertype/), atau [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/id/python-net/aspose.slides/placeholdertype/).

Aspose.Slides tidak mengubah placeholder [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) kosong menjadi [Chart](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/) hanya dengan mengubah [Placeholder.type](https://reference.aspose.com/slides/id/python-net/aspose.slides/placeholder/type/); tipe tersebut bersifat read‑only. Untuk mengisi area diagram atau konten kosong secara programatis, tambahkan objek yang diperlukan pada koordinat placeholder lalu hapus placeholder kosong. Contoh berikut melakukan hal itu untuk sebuah diagram:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("content-template.pptx") as presentation:
    slide = presentation.slides[0]
    target_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type in (slides.PlaceholderType.CHART, slides.PlaceholderType.OBJECT):
            target_placeholder = shape
            break

    if target_placeholder is None:
        raise RuntimeError("The first slide does not contain a chart or content placeholder.")

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, target_placeholder.x, target_placeholder.y, target_placeholder.width, target_placeholder.height)
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    slide.shapes.remove(target_placeholder)
    presentation.save("content-placeholder-replaced-with-chart.pptx", slides.export.SaveFormat.PPTX)
```

Diagram yang ditambahkan adalah diagram lokal biasa. Ia menempati area placeholder tetapi tidak mewarisi dari placeholder tata letak. Gunakan artikel [chart management articles](/slides/id/python-net/powerpoint-charts/) ketika Anda perlu mengganti kategori, seri, atau data workbook diagram tersebut.

## **Contoh Lengkap: Perbarui Teks atau Konten Gambar**

Contoh end‑to‑end berikut membuka templat, mencari slide pertama untuk placeholder judul atau gambar, memeriksa tipe placeholder dan shape, memperbarui konten yang sesuai, dan menyimpan output. Contoh ini sengaja menghindari asumsi indeks shape atau memperlakukan setiap placeholder sebagai kelas shape yang sama.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    updated = False

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE) and isinstance(shape, slides.AutoShape):
            shape.text_frame.text = "Quarterly Business Review"
            updated = True
            break

        if placeholder_type == slides.PlaceholderType.PICTURE:
            with open("replacement.png", "rb") as image_stream:
                image_bytes = image_stream.read()

            image = presentation.images.add_image(image_bytes)

            if isinstance(shape, slides.PictureFrame):
                shape.picture_format.picture.image = image
            else:
                slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, image)
                slide.shapes.remove(shape)

            updated = True
            break

    if not updated:
        raise RuntimeError("No supported title or picture placeholder was found on the first slide.")

    presentation.save("placeholder-content-updated.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apa itu placeholder dasar?**

Placeholder dasar adalah shape yang bersesuaian pada tata letak atau master dari mana placeholder lain mewarisi. Gunakan [Shape.get_base_placeholder](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/get_base_placeholder/) untuk mengambilnya. Shape lokal biasa mengembalikan `None` karena tidak termasuk dalam hierarki placeholder.

**Apakah saya dapat mengubah semua judul slide dengan menyunting placeholder tata letak?**

Anda dapat mengubah format atau teks prompt yang diwarisi melalui tata letak, tetapi konten judul yang ada disimpan pada slide normal. Untuk mengganti teks judul sebenarnya di seluruh presentasi, iterasikan slide dan perbarui setiap placeholder judul.

**Bagaimana cara mengelola placeholder tanggal, nomor slide, header, dan footer?**

Gunakan manajer header dan footer pada lingkup slide, tata letak, master, catatan, atau handout yang sesuai. Lihat [Manage Presentation Header and Footer](/slides/id/python-net/presentation-header-and-footer/) untuk contoh lengkap.