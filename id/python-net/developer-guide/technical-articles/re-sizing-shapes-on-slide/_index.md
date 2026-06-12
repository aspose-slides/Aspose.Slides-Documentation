---
title: Ubah Ukuran Bentuk dalam Presentasi dengan Python
linktitle: Mengubah Ukuran Bentuk
type: docs
weight: 130
url: /id/python-net/re-sizing-shapes-on-slide/
keywords:
- ubah ukuran bentuk
- ubah ukuran bentuk
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Dengan mudah ubah ukuran bentuk pada slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python via .NET—otomatisasi penyesuaian tata letak slide dan tingkatkan produktivitas."
---
## **Ikhtisar**

Salah satu pertanyaan paling umum dari pelanggan Aspose.Slides for Python adalah cara mengubah ukuran bentuk sehingga, ketika ukuran slide berubah, data tidak terpotong. Artikel teknis singkat ini menunjukkan cara melakukannya.

## **Ubah Ukuran Bentuk**

Untuk mencegah bentuk menjadi tidak sejajar ketika ukuran slide berubah, perbarui posisi dan dimensi setiap bentuk agar sesuai dengan tata letak slide yang baru.

```py
import aspose.slides as slides

# Muat file presentasi.
with slides.Presentation("sample.pptx") as presentation:
    # Dapatkan ukuran slide asli.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Ubah ukuran slide tanpa menskalakan bentuk yang ada.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Dapatkan ukuran slide yang baru.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Ubah ukuran dan posisikan kembali bentuk pada setiap slide.
    for slide in presentation.slides:
        for shape in slide.shapes:
            # Skalakan ukuran bentuk.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Skalakan posisi bentuk.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 
Jika sebuah slide berisi tabel, kode di atas tidak akan berfungsi dengan benar. Dalam kasus tersebut, setiap sel dalam tabel harus diubah ukurannya.
{{% /alert %}} 

Gunakan kode berikut di sisi Anda untuk mengubah ukuran slide yang berisi tabel. Untuk tabel, mengatur lebar atau tinggi merupakan kasus khusus: Anda harus menyesuaikan tinggi baris dan lebar kolom secara individual untuk mengubah ukuran keseluruhan tabel.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Dapatkan ukuran slide asli.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Ubah ukuran slide tanpa menskalakan bentuk yang ada.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Dapatkan ukuran slide yang baru.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.masters:
        for shape in master.shapes:
            # Skalakan ukuran bentuk.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Skalakan posisi bentuk.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

        for layout_slide in master.layout_slides:
            for shape in layout_slide.shapes:
                # Skalakan ukuran bentuk.
                shape.height = shape.height * height_ratio
                shape.width = shape.width * width_ratio

                # Skalakan posisi bentuk.
                shape.y = shape.y * height_ratio
                shape.x = shape.x * width_ratio

    for slide in presentation.slides:
        for shape in slide.shapes:
            # Skalakan ukuran bentuk.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Skalakan posisi bentuk.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * height_ratio
                for column in shape.columns:
                    column.width = column.width * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Tanya Jawab**

**Mengapa bentuk menjadi terdistorsi atau terpotong setelah mengubah ukuran slide?**

Saat mengubah ukuran slide, bentuk mempertahankan posisi dan ukuran aslinya kecuali skala diubah secara eksplisit. Hal ini dapat menyebabkan konten terpotong atau bentuk menjadi tidak sejajar.

**Apakah kode yang disediakan berfungsi untuk semua jenis bentuk?**

Contoh dasar berfungsi untuk sebagian besar jenis bentuk (kotak teks, gambar, diagram, dll.). Namun, untuk tabel, Anda perlu menangani baris dan kolom secara terpisah, karena tinggi dan lebar tabel ditentukan oleh dimensi sel individual.

**Bagaimana cara mengubah ukuran tabel saat mengubah ukuran slide?**

Anda perlu melintasi semua baris dan kolom tabel dan mengubah tinggi serta lebar mereka secara proporsional, seperti yang ditunjukkan pada contoh kode kedua.

**Apakah perubahan ukuran ini akan berfungsi untuk slide master dan slide tata letak?**

Ya, tetapi Anda juga harus melintasi [Master](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/masters/) dan [Slide tata letak](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/layout_slides/) dan menerapkan logika skala yang sama pada bentuk-bentuk mereka untuk memastikan konsistensi di seluruh presentasi.

**Bisakah saya mengubah orientasi slide (potret/lanskap) bersama dengan mengubah ukuran?**

Ya. Anda dapat menggunakan [presentation.slide_size.orientation](https://reference.aspose.com/slides/id/python-net/aspose.slides/islidesize/orientation/) untuk mengubah orientasi. Pastikan Anda mengatur logika skala dengan tepat untuk mempertahankan tata letak.

**Apakah ada batasan ukuran slide yang dapat saya atur?**

Aspose.Slides mendukung ukuran kustom, tetapi ukuran yang sangat besar dapat memengaruhi kinerja atau kompatibilitas dengan beberapa versi PowerPoint.

**Bagaimana cara mencegah bentuk dengan rasio aspek tetap menjadi terdistorsi?**

Anda dapat memeriksa properti `aspect_ratio_locked` dari bentuk sebelum melakukan skala. Jika properti tersebut terkunci, sesuaikan lebar atau tinggi secara proporsional daripada menskalakan keduanya secara terpisah.