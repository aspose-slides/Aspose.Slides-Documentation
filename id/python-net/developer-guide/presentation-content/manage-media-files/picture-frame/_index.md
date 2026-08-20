---
title: Kelola Picture Frame dalam Presentasi dengan Python
linktitle: Frame Gambar
type: docs
weight: 10
url: /id/python-net/picture-frame/
keywords:
- frame gambar
- tambahkan frame gambar
- buat frame gambar
- gambar tertanam
- gambar tertaut
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
## **Ikhtisar**

Sebuah picture frame adalah bentuk slide yang menampilkan gambar. Dalam Aspose.Slides, sumber daya gambar dan bentuk yang menampilkannya adalah objek terpisah: sebuah [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) memiliki sumber daya gambar tertanam melalui [ImageCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/imagecollection/), sementara sebuah [PictureFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/) mengontrol posisi gambar, ukuran, pemformatan garis, rotasi, pemotongan, efek gambar, dan pengaturan tingkat frame lainnya.

Pemisahan ini berguna ketika gambar yang sama ditampilkan lebih dari satu kali. Tambahkan gambar ke presentasi sekali, simpan [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) yang dikembalikan, dan gunakan sumber daya gambar tersebut saat membuat picture frame.

Picture frame dapat berisi gambar raster seperti PNG atau JPEG serta gambar vektor SVG. Mereka juga dapat merujuk ke gambar yang ditautkan alih-alih menyimpan byte gambar dalam presentasi. Pilihan tersebut memengaruhi portabilitas, ukuran file, ekstraksi, dan perilaku ekspor, sehingga penting untuk memutuskan bagaimana gambar harus disimpan sebelum menerapkan pemformatan atau optimisasi.

## **Tambahkan dan Format Gambar Tertanam**

Untuk gambar tertanam, tambahkan data gambar ke presentasi dan buat picture frame dengan [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/add_picture_frame/). Gambar menjadi bagian dari paket presentasi, sehingga presentasi tetap mandiri ketika dipindahkan ke komputer lain.

Contoh berikut menambahkan gambar JPEG, membuat frame dengan dimensi asli gambar, dan menerapkan pemformatan garis serta rotasi:

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

Picture frame mengendalikan geometri yang ditampilkan; mengubah ukuran frame tidak mengubah dimensi piksel asli yang disimpan dalam sumber daya gambar tertanam. Perbedaan ini menjadi penting saat memotong atau mengompresi gambar nanti.

## **Gunakan Skala Relatif**

[PictureFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/) menyediakan [relative_scale_width](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/relative_scale_width/) dan [relative_scale_height](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/relative_scale_height/) untuk frame. Nilai `1.0` berarti 100 % dari ukuran gambar asli. Skala relatif berguna ketika alur kerja perlu mempertahankan hubungan dengan ukuran gambar sumber alih-alih menghitung dimensi akhir secara manual.

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

Skala relatif mengubah pengaturan skala frame; ia tidak melakukan resampling atau kompresi pada gambar tertanam.

## **Gambar Tertanam dan Tertaut**

Gambar tertanam menyimpan data gambar di dalam presentasi dan oleh karena itu merupakan pilihan paling aman untuk portabilitas dan rendering yang dapat diprediksi. Gambar tertaut menyimpan lokasinya secara eksternal melalui jalur tautan [Picture](https://reference.aspose.com/slides/id/python-net/aspose.slides/picture/) alih-alih menanamkan data gambar dengan cara yang sama.

Gambar tertaut dapat mengurangi jumlah data gambar yang disimpan dalam PPTX, tetapi mereka menimbulkan ketergantungan eksternal. File tertaut harus tetap dapat diakses oleh aplikasi yang membuka atau merender presentasi. Jika jalur berubah, file dipindahkan, atau sumber tidak tersedia, picture frame tertaut mungkin tidak ditampilkan sebagaimana mestinya. Untuk presentasi yang harus dikirim lewat email, diarsipkan, atau dirender dalam lingkungan terisolasi, gambar tertanam biasanya lebih dapat diandalkan.

### **Tambahkan Gambar Tertaut**

Contoh berikut membuat picture frame dan menunjukannya ke file gambar lokal. Contoh ini hanya menangani penautan gambar; penautan video adalah alur kerja media terpisah dan sengaja tidak dicampur dalam contoh ini.

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

Gunakan tautan ketika manajemen file eksternal memang diinginkan. Jangan gunakan hanya sebagai pengganti kompresi: PPTX kecil dengan ketergantungan gambar yang rusak biasanya kurang berguna daripada presentasi yang lebih besar dan mandiri.

## **Ekstrak Gambar dari Picture Frame**

Sebelum mengekstrak gambar dari presentasi yang ada, pastikan bahwa bentuk sebenarnya adalah [PictureFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/) dan bahwa ia berisi gambar tertanam. Picture frame tertaut mungkin tidak berisi byte gambar yang dapat diekstrak dengan cara yang sama.

### **Ekstrak Gambar Raster**

API gambar modern menggunakan [IImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/iimage/) secara langsung. Contoh berikut menemukan gambar raster tertanam pertama pada slide dan menyimpannya sebagai PNG:

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

Menyimpan melalui [IImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/iimage/) mengonversi gambar yang diekstrak ke format output yang diminta. Jika Anda membutuhkan byte terkode yang disimpan dalam presentasi alih-alih file raster yang dikonversi, gunakan properti [PPImage.binary_data](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/binary_data/) sebagai gantinya.

### **Ekstrak Gambar SVG**

Untuk gambar SVG, [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) menyediakan objek [SvgImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/svgimage/). Ini memungkinkan Anda mengambil data SVG langsung alih-alih merasterkan gambar terlebih dahulu.

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

Mempertahankan konten SVG sebagai SVG menjaga sumber vektor di dalam presentasi. Ekspor raster seperti PNG atau JPEG secara wajib merender konten vektor tersebut ke piksel. Ekspor slide ke PDF atau SVG juga merupakan operasi rendering, sehingga grafik yang diekspor tidak boleh dianggap sebagai salinan byte-per-byte dari SVG tertanam asli; gunakan [SvgImage.svg_data](https://reference.aspose.com/slides/id/python-net/aspose.slides/svgimage/svg_data/) ketika sumber vektor asli diperlukan.

## **Potong Gambar**

Pemotongan mengubah bagian gambar yang terlihat di dalam frame. Nilai pemotongan pada [PictureFillFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/) adalah persentase dari dimensi gambar sumber. Pemotongan tidak langsung menghapus piksel tersembunyi dari gambar tertanam; ia hanya mengubah wilayah yang terlihat.

Contoh berikut menemukan picture frame dengan aman dan menerapkan nilai pemotongan:

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

Karena data gambar tersembunyi masih ada, pemotongan dapat diubah nanti tanpa kehilangan piksel asli. Jika ukuran file lebih penting daripada kemampuan balik, wilayah yang dipotong dapat dihapus secara fisik seperti dijelaskan pada bagian berikutnya.

## **Hapus Data Gambar yang Dipotong**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) menghapus data gambar di luar persegi pemotongan saat ini dan mengembalikan sumber daya gambar yang dihasilkan. Ini dapat mengurangi ukuran file, tetapi merupakan optimisasi destruktif: setelah presentasi disimpan, piksel yang dihapus tidak lagi tersedia untuk operasi un‑crop di kemudian hari.

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

Metode ini mungkin menambahkan sumber daya gambar baru ke presentasi. Jika gambar asli juga digunakan oleh picture frame lain, frame‑frame tersebut tetap memerlukan sumber daya yang ada, sehingga menghapus area yang dipotong tidak selalu mengurangi total jumlah gambar. Memotong konten WMF atau EMF dengan metode ini merasterkan hasil potongan ke PNG.

## **Kompres Gambar Raster**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/compress_image/) mengurangi resolusi gambar raster relatif terhadap ukuran saat gambar ditampilkan. Ia juga dapat menghapus wilayah yang dipotong dalam operasi yang sama. Metode mengembalikan `True` ketika gambar diubah ukuran atau dipotong dan `False` ketika tidak ada perubahan yang diperlukan.

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

Nilai DPI positif khusus dapat diberikan alih-alih nilai enum ketika target tertentu diperlukan.

Kompresi ditujukan untuk gambar raster. Konten SVG dan metafile tidak dikurangi oleh alur kerja kompresi raster ini. Juga ingat bahwa resolusi lebih rendah dan wilayah yang dipotong yang dihapus tidak dapat dipulihkan dari presentasi yang telah dioptimalkan. Pilih resolusi target berdasarkan ukuran terbesar di mana gambar akan benar‑benar dilihat atau diekspor, bukan menerapkan DPI terendah secara global.

## **Periksa Efek Gambar**

Efek gambar disimpan pada gambar yang digunakan oleh frame. Koleksi transformasi gambar dapat berisi efek seperti modulasi alfa tetap untuk transparansi dan luminansi untuk kecerahan serta kontras. Contoh di bawah ini membaca dengan aman kedua jenis efek dari picture frame pertama pada slide:

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
        for effect in picture_frame.picture_format.picture.image_transform:
            if isinstance(effect, slides.effects.AlphaModulateFixed):
                transparency = 100 - effect.amount
                print("Transparency: " + str(transparency))

            if isinstance(effect, slides.effects.Luminance):
                luminance = effect.get_effective()
                print("Brightness: " + str(luminance.brightness))
                print("Contrast: " + str(luminance.contrast))
```

[AlphaModulateFixed](https://reference.aspose.com/slides/id/python-net/aspose.slides.effects/alphamodulatefixed/) dan [Luminance](https://reference.aspose.com/slides/id/python-net/aspose.slides.effects/luminance/) mengubah cara gambar dirender dalam frame; mereka tidak menulis ulang byte gambar tertanam asli.

## **Kunci Geometri Picture Frame**

Pengaturan [PictureFrameLock](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframelock/) mengontrol operasi pengeditan mana yang dinonaktifkan untuk picture frame. Misalnya, properti [aspect_ratio_locked](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) mempertahankan proporsi bentuk saat diubah ukurannya.

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

Kunci berlaku untuk shape picture frame. Ia tidak memaksa gambar sumber untuk di‑resample atau secara permanen diubah menjadi rasio aspek yang sama.

## **Sesuaikan Nilai StretchOffset**

Ketika mode isian gambar adalah stretch, nilai stretch‑offset pada [PictureFillFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/) menentukan persegi isian relatif terhadap kotak pembatas picture frame. Persentase positif menciptakan inset dari tepi, sementara persentase negatif menciptakan outset.

Ini berbeda dari pemotongan. Nilai crop memilih bagian gambar sumber yang terlihat; stretch offset mengubah persegi tempat isian gambar yang terlihat diregangkan.

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

Gunakan stretch offset untuk penempatan isian. Gunakan properti crop ketika tujuan Anda adalah menyembunyikan tepi gambar sumber.

## **Penyimpanan, Ukuran File, dan Pertimbangan Ekspor**

Pertimbangan utama lebih mudah dikelola ketika penyimpanan gambar dan pemformatan picture frame diperlakukan terpisah:

- **Gambar tertanam** membuat presentasi mandiri dan paling dapat diandalkan untuk berbagi serta rendering sisi server, tetapi gambar raster besar meningkatkan ukuran PPTX dan penggunaan memori.
- **Gambar tertaut** dapat menjaga paket tetap kecil, tetapi presentasi bergantung pada file eksternal yang tetap tersedia di jalur atau lokasi yang disimpan.
- **Pemotongan** awalnya non‑destruktif. Piksel tersembunyi tetap tertanam hingga area yang dipotong secara eksplisit dihapus atau dihapus selama kompresi.
- **Kompresi** dapat mengurangi ukuran file secara signifikan untuk gambar raster yang berukuran berlebih, tetapi mengorbankan resolusi sumber. Kompresi sebaiknya diterapkan setelah ukuran pada slide yang diinginkan diketahui.
- **Gambar SVG** sebaiknya tetap sebagai SVG ketika preservasi vektor penting. Ekstrak SVG tertanam secara langsung ketika Anda membutuhkan sumber vektor itu sendiri. Ekspor slide raster selalu mengonversi slide yang dirender ke piksel.
- **Gambar berulang** sebaiknya menggunakan kembali sumber daya [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) yang ada bila memungkinkan, alih-alih memuat file yang sama berulang kali ke alur kerja presentasi.

Untuk presentasi besar, optimisasi gambar biasanya paling efektif bila dilakukan secara selektif: pertahankan logo dan diagram sebagai konten vektor, kompres foto sesuai ukuran tampilan sebenarnya, hapus piksel yang dipotong hanya jika pengeditan selanjutnya tidak diperlukan, dan hindari tautan eksternal kecuali manajemen ketergantungan merupakan bagian dari desain penyebaran.

## **FAQ**

**Apa perbedaan antara picture frame dan sumber daya gambar?**

[PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) mewakili sumber daya gambar yang terkait dengan presentasi. [PictureFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/) adalah shape pada slide yang menampilkan gambar dan menyimpan geometri serta pemformatan tingkat frame seperti ukuran, rotasi, nilai crop, efek, dan kunci.

**Haruskah saya menanamkan atau menautkan gambar?**

Tanamkan gambar ketika presentasi harus portabel, diarsipkan, atau dirender tanpa akses ke sumber eksternal. Tautkan gambar hanya ketika menyimpan file gambar di luar PPTX memang diinginkan dan lokasi eksternal dapat dipelihara secara handal.

**Apakah pemotongan mengurangi ukuran file PPTX?**

Tidak secara otomatis. Pengaturan crop standar menyembunyikan bagian gambar sumber tetapi tetap menyimpan piksel di bawahnya. Gunakan [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) atau kompresi gambar dengan penghapusan area yang dipotong ketika piksel tersebut dapat dibuang secara permanen.

**Dapatkah saya mengembalikan kualitas gambar setelah kompresi?**

Tidak. Kompresi dapat mengurangi resolusi raster yang disimpan, dan menghapus wilayah yang dipotong membuang data gambar. Simpan gambar sumber asli di luar presentasi jika pengeditan beresolusi tinggi di kemudian hari mungkin diperlukan.

**Bagaimana sebaiknya menangani gambar SVG?**

Pertahankan konten SVG sebagai SVG ketika fidelitas vektor penting. [SvgImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/svgimage/) yang tertanam dapat diekstrak secara langsung. Merender slide ke format raster seperti PNG atau JPEG merasterkan SVG sebagai bagian dari gambar slide.

**Bagaimana cara menghindari cast tidak aman saat membaca slide yang ada?**

Periksa tipe shape sebelum menggunakan anggota khusus picture‑frame. Menggunakan `isinstance(shape, slides.PictureFrame)` menghindari cast yang tidak valid dan memungkinkan kode menangani slide yang tidak berisi picture frame.