---
title: Kelola Frame Gambar dalam Presentasi dengan Python
linktitle: Frame Gambar
type: docs
weight: 10
url: /id/python-net/picture-frame/
keywords:
- frame gambar
- tambahkan frame gambar
- buat frame gambar
- gambar tersemat
- gambar terhubung
- ekstrak gambar
- gambar raster
- gambar SVG
- potong gambar
- hapus area yang dipotong
- kompres gambar
- StretchOffset
- pemformatan frame gambar
- skala relatif
- efek gambar
- rasio aspek
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Buat, format, tautkan, potong, ekstrak, dan kompres frame gambar dalam presentasi dengan Aspose.Slides untuk Python via .NET."
---
## **Gambaran Umum**

Picture frame adalah bentuk slide yang menampilkan gambar. Di Aspose.Slides, sumber daya gambar dan bentuk yang menampilkannya merupakan objek terpisah: sebuah [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) memiliki sumber daya gambar tersemat melalui [ImageCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/imagecollection/), sementara sebuah [PictureFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/) mengontrol posisi gambar, ukuran, format garis, rotasi, pemotongan, efek gambar, dan pengaturan tingkat frame lainnya.

Pemisahan ini berguna ketika gambar yang sama ditampilkan lebih dari satu kali. Tambahkan gambar ke presentasi sekali, simpan [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) yang dikembalikan, dan gunakan sumber daya gambar tersebut saat membuat picture frame.

Picture frame dapat berisi gambar raster seperti PNG atau JPEG serta gambar vektor SVG. Mereka juga dapat merujuk ke gambar terhubung alih‑alih menyimpan byte gambar di dalam presentasi. Pilihan ini memengaruhi portabilitas, ukuran file, ekstraksi, dan perilaku ekspor, sehingga penting untuk memutuskan bagaimana gambar harus disimpan sebelum menerapkan pemformatan atau optimasi.

## **Menambahkan dan Memformat Gambar Tersemat**

Untuk gambar tersemat, tambahkan data gambar ke presentasi dan buat picture frame dengan [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/add_picture_frame/). Gambar menjadi bagian dari paket presentasi, sehingga presentasi tetap mandiri ketika dipindahkan ke komputer lain.

Contoh berikut menambahkan gambar JPEG, membuat frame dengan dimensi asli gambar, serta menerapkan format garis dan rotasi:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
    picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    picture_frame.line_format.width = 3
    picture_frame.rotation = 15

    presentation.save("picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

Picture frame mengontrol geometri yang ditampilkan; mengubah ukuran frame tidak mengubah dimensi piksel asli yang disimpan dalam sumber daya gambar tersemat. Perbedaan ini menjadi penting ketika memotong atau mengompres gambar di kemudian hari.

## **Menggunakan Skala Relatif**

[PictureFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/) menyediakan [relative_scale_width](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/relative_scale_width/) dan [relative_scale_height](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/relative_scale_height/) untuk frame. Nilai `1.0` berarti 100 % ukuran gambar asli. Skala relatif berguna ketika alur kerja perlu mempertahankan hubungan terhadap ukuran gambar sumber alih‑alih menghitung dimensi akhir secara manual.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)
    picture_frame.relative_scale_width = 1.35
    picture_frame.relative_scale_height = 0.8

    presentation.save("relative-scale.pptx", slides.export.SaveFormat.PPTX)
```

Skala relatif mengubah pengaturan skala frame; tidak melakukan resampling atau kompresi pada gambar tersemat.

## **Gambar Tersemat dan Terhubung**

Gambar tersemat menyimpan data gambar di dalam presentasi dan oleh karena itu menjadi pilihan paling aman untuk portabilitas dan rendering yang dapat diprediksi. Gambar terhubung menyimpan lokasi eksternal melalui jalur tautan [Picture](https://reference.aspose.com/slides/id/python-net/aspose.slides/picture/) alih‑alih menyematkan data gambar dengan cara yang sama.

Gambar terhubung dapat mengurangi jumlah data gambar yang disimpan dalam PPTX, tetapi memperkenalkan ketergantungan eksternal. File yang ditautkan harus tetap dapat diakses oleh aplikasi yang membuka atau merender presentasi. Jika jalur berubah, file dipindahkan, atau sumber tidak tersedia, gambar terhubung mungkin tidak ditampilkan sebagaimana mestinya. Untuk presentasi yang harus dikirim lewat email, diarsipkan, atau dirender dalam lingkungan terisolasi, gambar tersemat biasanya lebih andal.

### **Menambahkan Gambar Terhubung**

Contoh berikut membuat picture frame dan menunjukannya ke file gambar lokal. Contoh ini hanya menangani penautan gambar; penautan video merupakan alur kerja media terpisah dan sengaja tidak dicampur dalam contoh ini.

```python
import os
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 320, 180, None)
    linked_image_path = os.path.abspath("linked-image.jpg")
    picture_frame.picture_format.picture.link_path_long = linked_image_path

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

Gunakan tautan ketika manajemen file eksternal memang diinginkan. Jangan gunakan hanya sebagai pengganti kompresi: PPTX kecil dengan ketergantungan gambar yang rusak biasanya kurang berguna daripada presentasi mandiri yang lebih besar.

## **Mengekstrak Gambar dari Picture Frame**

Sebelum mengekstrak gambar dari presentasi yang ada, pastikan bentuk tersebut benar‑benarnya adalah [PictureFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/) dan berisi gambar tersemat. Picture frame terhubung mungkin tidak berisi byte gambar yang dapat diekstrak dengan cara yang sama.

### **Mengekstrak Gambar Raster**

API gambar modern menggunakan [IImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/iimage/) secara langsung. Contoh berikut menemukan gambar raster tersemat pertama pada slide dan menyimpannya sebagai PNG:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        if embedded_image is None or embedded_image.svg_image is not None:
            continue

        raster_image = embedded_image.image
        raster_image.save("extracted-image.png", slides.ImageFormat.PNG)
        break
```

Menyimpan melalui [IImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/iimage/) mengubah gambar yang diekstrak ke format keluaran yang diminta. Jika Anda membutuhkan byte yang dikodekan yang disimpan dalam presentasi alih‑alih file raster yang telah dikonversi, gunakan properti [PPImage.binary_data](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/binary_data/) sebagai gantinya.

### **Mengekstrak Gambar SVG**

Untuk gambar SVG, [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) menyediakan objek [SvgImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/svgimage/). Ini memungkinkan Anda mengambil data SVG secara langsung alih‑alih merasterkan gambar terlebih dahulu.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        svg_image = embedded_image.svg_image if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = bytes(svg_image.svg_data)
        with open("extracted-image.svg", "wb") as svg_stream:
            svg_stream.write(svg_data)
        break
```

Menyimpan konten SVG sebagai SVG mempertahankan sumber vektor di dalam presentasi. Ekspor raster seperti PNG atau JPEG memang harus merender konten vektor ke piksel. Ekspor slide ke PDF atau SVG juga merupakan operasi rendering, sehingga grafik yang diekspor tidak boleh dianggap sebagai salinan byte‑per‑byte dari SVG tersemat asli; gunakan [SvgImage.svg_data](https://reference.aspose.com/slides/id/python-net/aspose.slides/svgimage/svg_data/) ketika sumber vektor asli diperlukan.

## **Memotong Gambar**

Pemotongan mengubah bagian gambar yang terlihat di dalam frame. Nilai pemotongan pada [PictureFillFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/) adalah persentase dari dimensi gambar sumber. Pemotongan tidak menghapus piksel tersembunyi dari gambar tersemat pada awalnya; hanya mengubah wilayah yang terlihat.

Contoh berikut menemukan picture frame secara aman dan menerapkan nilai pemotongan:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.picture_format.crop_left = 23.6
        picture_frame.picture_format.crop_right = 21.5
        picture_frame.picture_format.crop_top = 3
        picture_frame.picture_format.crop_bottom = 31
        presentation.save("cropped-image.pptx", slides.export.SaveFormat.PPTX)
```

Karena data gambar yang tersembunyi masih ada, pemotongan dapat diubah nanti tanpa kehilangan piksel asli. Jika ukuran file lebih penting daripada kemampuan membatalkan, wilayah yang dipotong dapat dihapus secara fisik seperti yang dijelaskan pada bagian berikut.

## **Menghapus Data Gambar yang Dipotong**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) menghapus data gambar di luar persegi pemotongan saat ini dan mengembalikan sumber daya gambar yang dihasilkan. Ini dapat mengurangi ukuran file, tetapi merupakan optimasi destruktif: setelah presentasi disimpan, piksel yang dihapus tidak lagi tersedia untuk operasi un‑crop di kemudian hari.

```python
import aspose.slides as slides

with slides.Presentation("cropped-image.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", slides.export.SaveFormat.PPTX)
```

Metode ini mungkin menambahkan sumber daya gambar baru ke presentasi. Jika gambar asli juga digunakan oleh picture frame lain, frame‑frame tersebut tetap memerlukan sumber daya yang ada, sehingga penghapusan area yang dipotong tidak selalu mengurangi total jumlah gambar. Memotong konten WMF atau EMF dengan metode ini merasterkan hasil yang dipotong menjadi PNG.

## **Mengompres Gambar Raster**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/compress_image/) mengurangi resolusi gambar raster relatif terhadap ukuran saat gambar ditampilkan. Ia juga dapat menghapus wilayah yang dipotong dalam operasi yang sama. Metode mengembalikan `True` bila gambar diubah ukuran atau dipotong dan `False` bila tidak ada perubahan yang diperlukan.

Gunakan nilai [PicturesCompression](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/picturescompression/) yang telah ditentukan sebelumnya ketika resolusi target standar cukup:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", slides.export.SaveFormat.PPTX)
```

Nilai DPI positif khusus dapat diberikan alih‑alih nilai enum ketika target spesifik diperlukan.

Kompresi ditujukan untuk gambar raster. Konten SVG dan metafile tidak dikurangi oleh alur kerja kompresi raster ini. Ingat juga bahwa resolusi lebih rendah dan wilayah yang dipotong tidak dapat dipulihkan dari presentasi yang telah dioptimasi. Pilih resolusi target berdasarkan ukuran terbesar di mana gambar sebenarnya akan dilihat atau diekspor, bukan dengan menerapkan DPI terendah secara global.

## **Mengelola Efek Transformasi Gambar**

Untuk alur kerja lengkap yang mencakup kecerahan, kontras, transformasi warna, blur, efek alfa, rantai terurut, inspeksi, penghapusan, dan verifikasi putar‑balik, lihat [Image Transform Effects](/slides/id/python-net/image-transform-effects/).

## **Mengunci Geometri Picture Frame**

Pengaturan [PictureFrameLock](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframelock/) mengontrol operasi penyuntingan mana yang dinonaktifkan untuk picture frame. Misalnya, properti [aspect_ratio_locked](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) mempertahankan proporsi bentuk saat diubah ukuran.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("locked-picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

Kunci berlaku pada bentuk picture frame. Itu tidak memaksa gambar sumber untuk di‑resample atau secara permanen diubah menjadi rasio aspek yang sama.

## **Menyesuaikan Nilai StretchOffset**

Ketika mode isian gambar adalah stretch, nilai stretch‑offset pada [PictureFillFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/) mendefinisikan persegi isian relatif terhadap kotak pembatas picture frame. Persentase positif membuat inset dari tepi, sementara persentase negatif membuat outset.

Ini berbeda dari pemotongan. Nilai pemotongan memilih bagian gambar sumber yang terlihat; stretch offset mengubah persegi dimana isian gambar yang terlihat diregangkan.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 400, 300, image)
    picture_frame.picture_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    picture_frame.picture_format.stretch_offset_left = 12
    picture_frame.picture_format.stretch_offset_right = 12
    picture_frame.picture_format.stretch_offset_top = 8
    picture_frame.picture_format.stretch_offset_bottom = 8

    presentation.save("stretch-offsets.pptx", slides.export.SaveFormat.PPTX)
```

Gunakan stretch offset untuk penempatan isian. Gunakan properti pemotongan ketika tujuan Anda adalah menyembunyikan tepi gambar sumber.

## **Penyimpanan, Ukuran File, dan Pertimbangan Ekspor**

Trade‑off utama lebih mudah dikelola ketika penyimpanan gambar dan pemformatan picture frame diperlakukan terpisah:

- **Gambar tersemat** membuat presentasi mandiri dan paling dapat diandalkan untuk berbagi serta rendering sisi server, tetapi gambar raster besar meningkatkan ukuran PPTX dan penggunaan memori.
- **Gambar terhubung** dapat membuat paket lebih kecil, tetapi presentasi bergantung pada file eksternal yang tetap tersedia pada jalur atau lokasi yang disimpan.
- **Pemotongan** pada awalnya tidak merusak. Piksel tersembunyi tetap tersemat hingga area yang dipotong secara eksplisit dihapus atau dihilangkan selama kompresi.
- **Kompresi** dapat mengurangi ukuran file secara signifikan untuk gambar raster yang terlalu besar, tetapi mengorbankan resolusi sumber. Sebaiknya diterapkan setelah ukuran pada slide yang diinginkan diketahui.
- **Gambar SVG** sebaiknya tetap dalam format SVG ketika preservasi vektor penting. Ekstrak SVG tersemat secara langsung ketika Anda memerlukan sumber vektor itu sendiri. Ekspor slide ke raster selalu mengonversi slide yang dirender menjadi piksel.
- **Gambar berulang** sebaiknya menggunakan kembali sumber daya [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) yang ada bila memungkinkan alih‑alih memuat berulang file yang sama ke dalam alur kerja presentasi.

Untuk presentasi besar, optimasi gambar biasanya paling efektif bila dilakukan secara selektif: pertahankan logo dan diagram sebagai konten vektor, kompres foto sesuai ukuran tampilan sebenarnya, hapus piksel yang dipotong hanya ketika penyuntingan di kemudian hari tidak diperlukan, dan hindari tautan eksternal kecuali manajemen ketergantungan menjadi bagian dari desain penyebaran.

## **FAQ**

**Apa perbedaan antara picture frame dan sumber daya gambar?**

[PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) mewakili sumber daya gambar yang terkait dengan presentasi. [PictureFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/) adalah bentuk pada slide yang menampilkan gambar dan menyimpan geometri serta format tingkat frame seperti ukuran, rotasi, nilai pemotongan, efek, dan kunci.

**Haruskah saya menyematkan atau menautkan gambar?**

Sematkan gambar ketika presentasi harus portabel, diarsipkan, atau dirender tanpa akses ke sumber eksternal. Tautkan gambar hanya ketika menyimpan file gambar di luar PPTX memang diinginkan dan lokasi eksternal dapat dipertahankan secara andal.

**Apakah pemotongan mengurangi ukuran file PPTX?**

Tidak secara otomatis. Pengaturan pemotongan normal menyembunyikan bagian gambar sumber tetapi tetap menyimpan piksel di bawahnya. Gunakan [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) atau kompresi gambar dengan penghapusan area yang dipotong ketika piksel tersebut dapat dibuang secara permanen.

**Bisakah saya memulihkan kualitas gambar setelah kompresi?**

Tidak. Kompresi dapat mengurangi resolusi raster yang disimpan, dan penghapusan wilayah yang dipotong membuang data gambar. Simpan gambar sumber asli di luar presentasi bila penyuntingan resolusi tinggi di kemudian hari mungkin diperlukan.

**Bagaimana sebaiknya menangani gambar SVG?**

Pertahankan konten SVG sebagai SVG ketika fidelitas vektor penting. [SvgImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/svgimage/) yang tersemat dapat diekstrak secara langsung. Merender slide ke format raster seperti PNG atau JPEG merasterkan SVG sebagai bagian dari gambar slide.

**Bagaimana cara menghindari cast tidak aman saat membaca slide yang ada?**

Periksa tipe bentuk sebelum menggunakan anggota khusus picture frame. Menggunakan `isinstance(shape, slides.PictureFrame)` menghindari cast yang tidak valid dan memungkinkan kode menangani slide yang tidak berisi picture frame.