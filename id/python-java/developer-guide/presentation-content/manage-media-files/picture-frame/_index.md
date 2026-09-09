---
title: Kelola Bingkai Gambar dalam Presentasi Menggunakan Python
linktitle: Bingkai Gambar
type: docs
weight: 10
url: /id/python-java/picture-frame/
keywords:
- bingkai gambar
- tambahkan bingkai gambar
- buat bingkai gambar
- gambar tersemat
- gambar tertaut
- ekstrak gambar
- gambar raster
- gambar SVG
- potong gambar
- hapus area yang dipotong
- kompres gambar
- StretchOffset
- pemformatan bingkai gambar
- skala relatif
- efek gambar
- rasio aspek
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Buat, format, tautkan, potong, ekstrak, dan kompres bingkai gambar dalam presentasi dengan Aspose.Slides untuk Python via Java."
---
## **Gambaran Umum**

Bingkai gambar adalah bentuk slide yang menampilkan sebuah gambar. Di Aspose.Slides, sumber gambar dan bentuk yang menampilkannya adalah objek terpisah: sebuah [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) memiliki sumber gambar tersemat melalui [ImageCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagecollection/), sementara sebuah [PictureFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/) mengontrol posisi gambar, ukuran, format garis, rotasi, pemotongan, efek gambar, dan pengaturan level bingkai lainnya.

Pemisahan ini berguna ketika gambar yang sama ditampilkan lebih dari sekali. Tambahkan gambar ke presentasi satu kali, simpan [PPImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/) yang dikembalikan, dan gunakan sumber gambar tersebut saat membuat bingkai gambar.

Bingkai gambar dapat berisi gambar raster seperti PNG atau JPEG dan gambar vektor SVG. Mereka juga dapat merujuk ke gambar yang ditautkan alih-alih menyimpan byte gambar di dalam presentasi. Pilihan ini memengaruhi portabilitas, ukuran file, ekstraksi, dan perilaku ekspor, sehingga penting untuk memutuskan bagaimana gambar harus disimpan sebelum menerapkan pemformatan atau optimasi.

## **Menambahkan dan Memformat Gambar Tersemat**

Untuk gambar tersemat, tambahkan data gambar ke presentasi dan buat bingkai gambar dengan [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#addPictureFrame). Gambar menjadi bagian dari paket presentasi, sehingga presentasi tetap mandiri ketika dipindahkan ke komputer lain.

Contoh berikut menambahkan gambar JPEG, membuat bingkai dengan dimensi asli gambar, dan menerapkan format garis serta rotasi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from asposeslides.api import FillType, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    picture_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    picture_frame.getLineFormat().setWidth(3)
    picture_frame.setRotation(15)

    presentation.save("picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bingkai gambar mengontrol geometri yang ditampilkan; mengubah ukuran bingkai tidak mengubah dimensi piksel asli yang disimpan dalam sumber gambar tersemat. Perbedaan ini menjadi penting ketika memotong atau mengompres gambar kemudian.

## **Gunakan Skala Relatif**

[PictureFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/) menyediakan skala lebar dan tinggi relatif untuk bingkai melalui [setRelativeScaleWidth](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) dan [setRelativeScaleHeight](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight). Nilai `1.0` berarti 100% ukuran gambar asli. Skala relatif berguna ketika alur kerja perlu mempertahankan hubungan dengan ukuran sumber gambar alih-alih menghitung dimensi akhir secara manual.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image)
    picture_frame.setRelativeScaleWidth(1.35)
    picture_frame.setRelativeScaleHeight(0.8)

    presentation.save("relative-scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Skala relatif mengubah pengaturan skala bingkai; tidak melakukan resample atau kompresi pada gambar tersemat.

## **Gambar Tersemat dan Tertaut**

Gambar tersemat menyimpan data gambar di dalam presentasi dan karenanya merupakan pilihan paling aman untuk portabilitas dan rendering yang dapat diprediksi. Gambar tertaut menyimpan lokasi eksternal melalui metode [Picture.setLinkPathLong](https://reference.aspose.com/slides/id/python-java/aspose.slides/picture/#setLinkPathLong) alih-alih menanamkan data gambar dengan cara yang sama.

Gambar tertaut dapat mengurangi jumlah data gambar yang disimpan dalam PPTX, tetapi memperkenalkan ketergantungan eksternal. Berkas tertaut harus tetap dapat diakses oleh aplikasi yang membuka atau merender presentasi. Jika jalur berubah, berkas dipindahkan, atau sumber tidak tersedia, gambar tertaut mungkin tidak ditampilkan sebagaimana mestinya. Untuk presentasi yang harus dikirim melalui email, diarsipkan, atau dirender dalam lingkungan terisolasi, gambar tersemat biasanya lebih andal.

### **Menambahkan Gambar Tertaut**

Contoh berikut membuat bingkai gambar dan mengarahkannya ke berkas gambar lokal. Contoh ini hanya menangani penautan gambar; penautan video merupakan alur kerja media terpisah dan sengaja tidak dicampur dalam contoh ini.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, None)
    linked_image_file = Path("linked-image.jpg").resolve()
    link_path = str(linked_image_file)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong(link_path)

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Gunakan tautan ketika manajemen berkas eksternal memang diinginkan. Jangan menggunakannya semata-mata sebagai pengganti kompresi: PPTX kecil dengan ketergantungan gambar yang rusak biasanya kurang berguna dibandingkan presentasi mandiri yang lebih besar.

## **Mengekstrak Gambar dari Bingkai Gambar**

Sebelum mengekstrak gambar dari presentasi yang ada, periksa bahwa bentuk tersebut sebenarnya adalah [PictureFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/) dan bahwa ia berisi gambar tersemat. Bingkai gambar tertaut mungkin tidak berisi byte gambar yang dapat diekstrak dengan cara yang sama.

### **Mengekstrak Gambar Raster**

API gambar modern bekerja langsung dengan gambar raster dan tidak memerlukan pembungkus gambar Java lama. Contoh berikut menemukan gambar raster tersemat pertama pada slide dan menyimpannya sebagai PNG:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        if embedded_image is None or embedded_image.getSvgImage() is not None:
            continue

        raster_image = embedded_image.getImage()
        try:
            raster_image.save("extracted-image.png", ImageFormat.Png)
        finally:
            raster_image.dispose()
        break
finally:
    presentation.dispose()
```

Menyimpan gambar raster mengonversi gambar yang diekstrak ke format keluaran yang diminta. Jika Anda memerlukan byte terenkode yang disimpan dalam presentasi alih-alih berkas raster yang telah dikonversi, gunakan data biner sumber gambar tersebut.

### **Mengekstrak Gambar SVG**

Untuk gambar SVG, [PPImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/) menyediakan objek [SvgImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgimage/). Ini memungkinkan Anda mengambil data SVG secara langsung alih-alih merasterkan gambar terlebih dahulu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        svg_image = embedded_image.getSvgImage() if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = svg_image.getSvgData()
        Path("extracted-image.svg").write_bytes(bytes(svg_data))
        break
finally:
    presentation.dispose()
```

Menyimpan konten SVG sebagai SVG mempertahankan sumber vektor di dalam presentasi. Ekspor raster seperti PNG atau JPEG memang mengubah konten vektor tersebut menjadi piksel. Ekspor slide ke PDF atau SVG juga merupakan operasi rendering, sehingga grafik yang diekspor tidak boleh dianggap sebagai salinan byte-per-byte dari SVG tersemat asli; gunakan data [SvgImage.getSvgData](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgimage/#getSvgData) ketika sumber vektor asli dibutuhkan.

## **Memotong Gambar**

Pemotongan mengubah bagian gambar yang terlihat di dalam bingkai. Nilai pemotongan pada [PictureFillFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/picturefillformat/) adalah persentase dari dimensi gambar sumber. Pemotongan tidak secara langsung menghapus piksel tersembunyi dari gambar tersemat; hanya mengubah wilayah yang terlihat.

Contoh berikut menemukan bingkai gambar secara aman dan menerapkan nilai pemotongan:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.getPictureFormat().setCropLeft(23.6)
        picture_frame.getPictureFormat().setCropRight(21.5)
        picture_frame.getPictureFormat().setCropTop(3)
        picture_frame.getPictureFormat().setCropBottom(31)
        presentation.save("cropped-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Karena data gambar yang tersembunyi masih ada, pemotongan dapat diubah nanti tanpa kehilangan piksel asli. Jika ukuran berkas lebih penting daripada kemampuan mengembalikan, wilayah yang dipotong dapat dihapus secara fisik seperti dijelaskan pada bagian berikut.

## **Menghapus Data Gambar yang Dipotong**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/id/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) menghapus data gambar di luar persegi pemotongan saat ini dan mengembalikan sumber gambar yang dihasilkan. Ini dapat mengurangi ukuran berkas, tetapi merupakan optimasi destruktif: setelah presentasi disimpan, piksel yang dihapus tidak lagi tersedia untuk operasi un‑crop di kemudian hari.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("cropped-image.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.getPictureFormat().deletePictureCroppedAreas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Metode ini dapat menambahkan sumber gambar baru ke presentasi. Jika gambar asli juga digunakan oleh bingkai gambar lain, bingkai tersebut masih membutuhkan sumber yang ada, sehingga menghapus area yang dipotong tidak selalu mengurangi total jumlah gambar. Memotong konten WMF atau EMF dengan metode ini merasterkan hasil yang dipotong menjadi PNG.

## **Mengompres Gambar Raster**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/picturefillformat/#compressImage) mengurangi resolusi gambar raster relatif terhadap ukuran tampilan gambar. Metode ini juga dapat menghapus wilayah yang dipotong dalam satu operasi. Metode ini mengembalikan `True` ketika gambar diubah ukurannya atau dipotong dan `False` ketika tidak ada perubahan yang diperlukan.

Gunakan nilai [PicturesCompression](https://reference.aspose.com/slides/id/python-java/aspose.slides/picturescompression/) yang telah ditentukan sebelumnya ketika resolusi target standar cukup:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.getPictureFormat().compressImage(True, PicturesCompression.Dpi150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Nilai DPI positif khusus dapat diberikan alih-alih nilai yang telah ditentukan ketika target tertentu diperlukan.

Kompresi ditujukan untuk gambar raster. Konten SVG dan metafile tidak berkurang oleh alur kerja kompresi raster ini. Juga ingat bahwa resolusi lebih rendah dan wilayah yang dipotong yang dihapus tidak dapat dipulihkan dari presentasi yang telah dioptimalkan. Pilih resolusi target berdasarkan ukuran terbesar di mana gambar akan benar‑benar dilihat atau diekspor, bukan dengan menerapkan DPI terendah secara global.

## **Kelola Efek Transformasi Gambar**

Untuk alur kerja lengkap yang mencakup kecerahan, kontras, transformasi warna, blur, efek alfa, rantai berurutan, inspeksi, penghapusan, dan verifikasi putar‑balik, lihat [Image Transform Effects](/slides/id/python-java/image-transform-effects/).

## **Kunci Geometri Bingkai Gambar**

Pengaturan [PictureFrameLock](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframelock/) mengontrol operasi penyuntingan mana yang dinonaktifkan untuk sebuah bingkai gambar. Sebagai contoh, [setAspectRatioLocked](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) mempertahankan proporsi bentuk saat diubah ukurannya.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getPictureFrameLock().setAspectRatioLocked(True)

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kunci ini berlaku pada bentuk bingkai gambar. Tidak memaksa gambar sumber untuk di‑resample atau secara permanen diubah ke rasio aspek yang sama.

## **Sesuaikan Nilai StretchOffset**

Ketika mode isian gambar adalah stretch, nilai stretch‑offset pada [PictureFillFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/picturefillformat/) mendefinisikan persegi isian relatif terhadap kotak pembatas bingkai gambar. Persentase positif membuat inset dari tepi, sementara persentase negatif membuat outset.

Ini berbeda dari pemotongan. Nilai pemotongan memilih bagian gambar sumber yang terlihat; stretch offset mengubah persegi tempat isian gambar yang terlihat diregangkan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image)
    picture_frame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch)
    picture_frame.getPictureFormat().setStretchOffsetLeft(12)
    picture_frame.getPictureFormat().setStretchOffsetRight(12)
    picture_frame.getPictureFormat().setStretchOffsetTop(8)
    picture_frame.getPictureFormat().setStretchOffsetBottom(8)

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Gunakan stretch offset untuk penempatan isian. Gunakan properti pemotongan ketika tujuan Anda adalah menyembunyikan tepi gambar sumber.

## **Pertimbangan Penyimpanan, Ukuran File, dan Ekspor**

Trade‑off utama lebih mudah dikelola ketika penyimpanan gambar dan pemformatan bingkai gambar diperlakukan terpisah:

- **Gambar tersemat** membuat presentasi mandiri dan paling andal untuk berbagi serta rendering sisi server, tetapi gambar raster besar meningkatkan ukuran PPTX dan penggunaan memori.
- **Gambar tertaut** dapat membuat paket lebih kecil, tetapi presentasi bergantung pada berkas eksternal yang tetap tersedia di jalur atau lokasi yang disimpan.
- **Pemotongan** pada awalnya tidak destruktif. Piksel tersembunyi tetap tersemat sampai area yang dipotong secara eksplisit dihapus atau dihapus selama kompresi.
- **Kompresi** dapat secara signifikan mengurangi ukuran berkas untuk gambar raster yang terlalu besar, tetapi mengorbankan resolusi sumber. Harus diterapkan setelah ukuran pada slide yang diinginkan diketahui.
- **Gambar SVG** sebaiknya tetap sebagai SVG ketika preservasi vektor penting. Ekstrak SVG tersemat langsung ketika Anda memerlukan sumber vektor itu sendiri. Ekspor slide raster selalu mengubah slide yang dirender menjadi piksel.
- **Gambar berulang** sebaiknya menggunakan kembali sumber [PPImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/) yang ada bila memungkinkan, alih-alih memuat berkas yang sama berulang‑ulang ke dalam alur kerja presentasi.

Untuk presentasi besar, optimasi gambar biasanya paling efektif bila dilakukan secara selektif: pertahankan logo dan diagram sebagai konten vektor, kompres foto sesuai ukuran tampilan sesungguhnya, hapus piksel yang dipotong hanya ketika penyuntingan lanjutan tidak diperlukan, dan hindari tautan eksternal kecuali manajemen ketergantungan menjadi bagian dari desain penyebaran.

## **FAQ**

**Apa perbedaan antara bingkai gambar dan sumber gambar?**

[PPImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/) mewakili sumber gambar yang terkait dengan presentasi. [PictureFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/) adalah bentuk pada slide yang menampilkan gambar dan menyimpan geometri serta pemformatan level bingkai seperti ukuran, rotasi, nilai pemotongan, efek, dan kunci.

**Haruskah saya menanamkan atau menautkan gambar?**

Tanamkan gambar ketika presentasi harus portabel, diarsipkan, atau dirender tanpa akses ke sumber eksternal. Tautkan gambar hanya ketika menyimpan berkas gambar di luar PPTX memang disengaja dan lokasi eksternal dapat dipertahankan secara andal.

**Apakah pemotongan mengurangi ukuran file PPTX?**

Tidak secara otomatis. Pengaturan pemotongan normal menyembunyikan bagian gambar sumber tetapi tetap menyimpan piksel di bawahnya. Gunakan [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/id/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) atau kompresi gambar dengan penghapusan area yang dipotong ketika piksel tersebut dapat dibuang secara permanen.

**Bisakah saya memulihkan kualitas gambar setelah kompresi?**

Tidak. Kompresi dapat mengurangi resolusi raster yang disimpan, dan penghapusan wilayah yang dipotong membuang data gambar. Simpan gambar sumber asli di luar presentasi jika nanti diperlukan penyuntingan beresolusi tinggi.

**Bagaimana sebaiknya menangani gambar SVG?**

Pertahankan konten SVG sebagai SVG ketika fidelitas vektor penting. [SvgImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgimage/) yang tersemat dapat diekstrak langsung. Merender slide ke format raster seperti PNG atau JPEG merasterkan SVG sebagai bagian dari gambar slide.

**Bagaimana cara menghindari cast tidak aman saat membaca slide yang ada?**

Periksa tipe bentuk sebelum menggunakan anggota khusus bingkai gambar. Pemeriksaan `isinstance` terhadap [PictureFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/) menghindari cast yang tidak valid dan memungkinkan kode menangani slide yang tidak berisi bingkai gambar.