---
title: Kelola Placeholder dalam Presentasi dengan Python
linktitle: Kelola Placeholder
type: docs
weight: 10
url: /id/python-net/manage-placeholder/
keywords:
- placeholder
- placeholder teks
- placeholder gambar
- placeholder bagan
- teks prompt
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Kelola placeholder dengan mudah di Aspose.Slides untuk Python melalui .NET: ganti teks, sesuaikan prompt, dan atur transparansi gambar dalam PowerPoint serta OpenDocument."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengelola placeholder presentasi secara programatis. Artikel ini menjelaskan cara menemukan placeholder pada slide dan mengubah teksnya, menetapkan teks prompt khusus untuk tata letak placeholder, serta menyesuaikan transparansi gambar yang digunakan sebagai latar belakang placeholder. Artikel ini juga menyertakan FAQ singkat yang menjelaskan perbedaan antara placeholder dasar dan bentuk lokal, menjelaskan cara perubahan placeholder dapat diterapkan melalui tata letak atau master, dan mengarahkan ke pengelolaan placeholder header dan footer.

## **Ubah Teks dalam Placeholder**

Dengan Aspose.Slides untuk Python, Anda dapat menemukan dan mengubah placeholder pada slide dalam sebuah presentasi. Aspose.Slides memungkinkan Anda mengubah teks dalam sebuah placeholder.

**Prasyarat:** Anda memerlukan presentasi yang berisi placeholder. Anda dapat membuat presentasi tersebut di Microsoft PowerPoint.

Berikut cara menggunakan Aspose.Slides untuk mengganti teks dalam sebuah placeholder:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan berikan presentasi sebagai argumen.
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Iterasi melalui shape untuk menemukan placeholder.
1. Ubah teks menggunakan [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) yang terkait dengan [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/).
1. Simpan presentasi yang telah diubah.

Kode Python berikut menunjukkan cara mengubah teks dalam sebuah placeholder:

```python
import aspose.slides as slides

# Membuat instance kelas Presentation.
with slides.Presentation("ReplacingText.pptx") as presentation:
    # Mengakses slide pertama.
    slide = presentation.slides[0]

    # Mengiterasi shape untuk menemukan placeholder.
    for shape in slide.shapes:
        if shape.placeholder is not None:
            # Mengubah teks pada setiap placeholder.
            shape.text_frame.text = "This is Placeholder"

    # Menyimpan presentasi ke disk.
    presentation.save("ReplacingText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Setel Teks Prompt untuk Placeholder**

Tata letak standar dan bawaan menyertakan teks prompt placeholder seperti **Click to add a title** atau **Click to add a subtitle**. Dengan Aspose.Slides, Anda dapat mengganti prompt tersebut dengan teks Anda sendiri dalam tata letak placeholder.

Contoh Python berikut menunjukkan cara mengatur teks prompt untuk sebuah placeholder:

```python
import aspose.slides as slides

with slides.Presentation("PromptText.pptx") as presentation:
    slide = presentation.slides[0]

    # Mengiterasi shape untuk menemukan placeholder.
    for shape in slide.slide.shapes:
        if shape.placeholder is not None and type(shape) is slides.AutoShape:
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE:
                text = "Add Title"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE:
                text = "Add Subtitle"

            shape.text_frame.text = text
            print(f"Placeholder with text: {text}")

    presentation.save("PromptText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Setel Transparansi Gambar dalam Placeholder**

Aspose.Slides memungkinkan Anda mengatur transparansi gambar latar belakang dalam placeholder teks. Dengan menyesuaikan transparansi gambar dalam frame tersebut, Anda dapat menonjolkan teks atau gambar, tergantung pada warnanya.

Contoh Python berikut menunjukkan cara mengatur transparansi latar belakang gambar di dalam sebuah shape:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    auto_shape.fill_format.fill_type = slides.FillType.PICTURE

    with open("image.png", "rb") as image_stream:
        auto_shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_stream)
        auto_shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        auto_shape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)
```

## **FAQ**

**Apa itu placeholder dasar, dan bagaimana perbedaannya dengan bentuk lokal pada slide?**

Placeholder dasar adalah shape asli pada tata letak atau master yang shape slide mewarisinya—tipe, posisi, dan beberapa format diambil darinya. Shape lokal bersifat independen; bila tidak ada placeholder dasar, pewarisan tidak berlaku.

**Bagaimana cara memperbarui semua judul atau keterangan di seluruh presentasi tanpa harus iterasi setiap slide?**

Edit placeholder yang bersangkutan pada tata letak atau master. Slide yang menggunakan tata letak/master tersebut secara otomatis akan mewarisi perubahan.

**Bagaimana cara mengontrol placeholder header/footer standar—tanggal & waktu, nomor slide, dan teks footer?**

Gunakan pengelola HeaderFooter pada ruang lingkup yang sesuai (slide normal, tata letak, master, catatan/handout) untuk mengaktifkan atau menonaktifkan placeholder tersebut dan mengatur isinya.