---
title: Kelola Frame Gambar dalam Presentasi Menggunakan Python
linktitle: Frame Gambar
type: docs
weight: 10
url: /id/python-java/picture-frame/
keywords:
- frame gambar
- tambahkan frame gambar
- buat frame gambar
- gambar tersemat
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
- Java
- Aspose.Slides
description: "Buat, format, tautkan, potong, ekstrak, dan kompres frame gambar dalam presentasi dengan Aspose.Slides untuk Python via Java."
---
## **Overview**

Sebuah picture frame adalah bentuk slide yang menampilkan gambar. Di Aspose.Slides, sumber daya gambar dan bentuk yang menampilkannya adalah objek terpisah: sebuah [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) memiliki sumber daya gambar yang disematkan melalui [ImageCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagecollection/), sementara sebuah [PictureFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/) mengontrol posisi gambar, ukuran, format garis, rotasi, pemotongan, efek gambar, dan pengaturan tingkat frame lainnya.

Pemisahan ini berguna ketika gambar yang sama ditampilkan lebih dari satu kali. Tambahkan gambar ke presentasi sekali, simpan [PPImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/) yang dikembalikan, dan gunakan sumber daya gambar tersebut saat membuat picture frame.

Picture frame dapat berisi gambar raster seperti PNG atau JPEG serta gambar vektor SVG. Mereka juga dapat merujuk ke gambar yang ditautkan alih‑alih menyimpan byte gambar di dalam presentasi. Pilihan tersebut memengaruhi portabilitas, ukuran berkas, ekstraksi, dan perilaku ekspor, sehingga penting untuk memutuskan bagaimana gambar harus disimpan sebelum menerapkan format atau optimasi.

## **Add and Format an Embedded Image**

Untuk gambar yang disematkan, tambahkan data gambar ke presentasi dan buat picture frame dengan [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#addPictureFrame). Gambar menjadi bagian dari paket presentasi, sehingga presentasi tetap mandiri ketika dipindahkan ke komputer lain.

Contoh berikut menambahkan gambar JPEG, membuat frame dengan dimensi asli gambar, dan menerapkan format garis serta rotasi:

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

Picture frame mengontrol geometri yang ditampilkan; mengubah ukuran frame tidak mengubah dimensi piksel asli yang disimpan dalam sumber daya gambar yang disematkan. Perbedaan ini menjadi penting ketika memotong atau mengompres gambar di kemudian hari.

## **Use Relative Scale**

[PictureFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/) menyediakan skala lebar dan tinggi relatif untuk frame melalui [setRelativeScaleWidth](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) dan [setRelativeScaleHeight](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight). Nilai `1.0` mengacu pada 100 % ukuran gambar asli. Skala relatif berguna ketika alur kerja perlu mempertahankan hubungan terhadap ukuran gambar sumber alih‑alih menghitung dimensi akhir secara manual.

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

Skala relatif mengubah pengaturan skala frame; ia tidak melakukan resampling atau kompresi pada gambar yang disematkan.

## **Embedded and Linked Images**

Gambar yang disematkan menyimpan data gambar di dalam presentasi dan karena itu merupakan pilihan paling aman untuk portabilitas dan rendering yang dapat diprediksi. Gambar yang ditautkan menyimpan lokasi eksternal melalui metode [Picture.setLinkPathLong](https://reference.aspose.com/slides/id/python-java/aspose.slides/picture/#setLinkPathLong) alih‑alih menyematkan data gambar dengan cara yang sama.

Gambar yang ditautkan dapat mengurangi jumlah data gambar yang disimpan dalam PPTX, tetapi mereka memperkenalkan ketergantungan eksternal. File yang ditautkan harus tetap dapat diakses oleh aplikasi yang membuka atau merender presentasi. Jika jalur berubah, file dipindahkan, atau sumber tidak tersedia, picture yang ditautkan mungkin tidak ditampilkan sebagaimana mestinya. Untuk presentasi yang harus dikirim melalui email, diarsipkan, atau dirender dalam lingkungan terisolasi, gambar yang disematkan biasanya lebih dapat diandalkan.

### **Add a Linked Image**

Contoh berikut membuat picture frame dan menunjukkannya ke file gambar lokal. Contoh ini hanya menangani penautan gambar; penautan video adalah alur media terpisah dan sengaja tidak dicampur dalam contoh ini.

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

Gunakan tautan ketika manajemen file eksternal disengaja. Jangan gunakan hanya sebagai pengganti kompresi: PPTX kecil dengan dependensi gambar yang rusak biasanya kurang berguna daripada presentasi yang lebih besar dan mandiri.

## **Extract Images from Picture Frames**

Sebelum mengekstrak gambar dari presentasi yang ada, periksa bahwa sebuah bentuk memang merupakan [PictureFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/) dan bahwa ia berisi gambar yang disematkan. Picture frame yang ditautkan mungkin tidak berisi byte gambar yang dapat diekstrak dengan cara yang sama.

### **Extract a Raster Image**

API gambar modern bekerja langsung dengan gambar raster dan tidak memerlukan wrapper gambar Java lama. Contoh berikut menemukan gambar raster yang disematkan pertama pada slide dan menyimpannya sebagai PNG:

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

Menyimpan gambar raster mengonversi gambar yang diekstrak ke format output yang diminta. Jika Anda memerlukan byte yang telah dikodekan yang disimpan dalam presentasi alih‑alih file raster yang telah dikonversi, gunakan data biner sumber daya gambar tersebut.

### **Extract an SVG Image**

Untuk gambar SVG, [PPImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/) menyediakan objek [SvgImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgimage/). Ini memungkinkan Anda mengambil data SVG secara langsung alih‑alih merasterkan gambar terlebih dahulu.

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

Menjaga konten SVG sebagai SVG mempertahankan sumber vektor di dalam presentasi. Ekspor raster seperti PNG atau JPEG pasti merender konten vektor tersebut ke piksel. Ekspor slide ke PDF atau SVG juga merupakan operasi rendering, sehingga grafik yang diekspor tidak boleh diperlakukan sebagai salinan byte‑per‑byte dari SVG yang disematkan; gunakan data [SvgImage.getSvgData](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgimage/#getSvgData) yang disematkan ketika sumber vektor asli diperlukan.

## **Crop an Image**

Pemotongan mengubah bagian gambar mana yang terlihat di dalam frame. Nilai pemotongan pada [PictureFillFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/picturefillformat/) berupa persentase dari dimensi gambar sumber. Pemotongan tidak langsung menghapus piksel tersembunyi dari gambar yang disematkan; ia hanya mengubah wilayah yang terlihat.

Contoh berikut menemukan picture frame dengan aman dan menerapkan nilai pemotongan:

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

Karena data gambar tersembunyi masih ada, pemotongan dapat diubah nanti tanpa kehilangan piksel asli. Jika ukuran berkas lebih penting daripada kemampuan membatalkan, wilayah yang dipotong dapat dihapus secara fisik seperti yang dijelaskan pada bagian berikut.

## **Remove Cropped Image Data**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/id/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) menghapus data gambar di luar area pemotongan saat ini dan mengembalikan sumber daya gambar yang dihasilkan. Ini dapat mengurangi ukuran berkas, tetapi merupakan optimasi yang destruktif: setelah presentasi disimpan, piksel yang dihapus tidak lagi tersedia untuk operasi un‑crop di kemudian hari.

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

Metode ini mungkin menambahkan sumber daya gambar baru ke presentasi. Jika gambar asli juga digunakan oleh picture frame lain, frame‑frame tersebut masih memerlukan sumber daya yang ada, sehingga menghapus area yang dipotong tidak selalu mengurangi total jumlah gambar. Memotong konten WMF atau EMF dengan metode ini merasterkan hasil yang dipotong menjadi PNG.

## **Compress Raster Images**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/picturefillformat/#compressImage) mengurangi resolusi gambar raster relatif terhadap ukuran tempat gambar ditampilkan. Ia juga dapat menghapus wilayah yang dipotong dalam operasi yang sama. Metode mengembalikan `True` bila gambar diubah ukuran atau dipotong dan `False` bila tidak ada perubahan yang diperlukan.

Gunakan nilai [PicturesCompression](https://reference.aspose.com/slides/id/python-java/aspose.slides/picturescompression/) yang telah ditentukan sebelumnya ketika resolusi target standar sudah memadai:

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

Nilai DPI positif yang disesuaikan dapat diberikan alih‑alih nilai yang telah ditentukan ketika target khusus diperlukan.

Kompresi ditujukan untuk gambar raster. Konten SVG dan metafile tidak berkurang oleh alur kerja kompresi raster ini. Ingat juga bahwa resolusi yang lebih rendah dan wilayah yang dipotong yang dihapus tidak dapat dipulihkan dari presentasi yang telah dioptimalkan. Pilih resolusi target berdasarkan ukuran terbesar tempat gambar akan benar‑benar dilihat atau diekspor, alih‑alih menerapkan DPI terendah secara global.

## **Manage Image Transform Effects**

Untuk alur kerja lengkap yang mencakup kecerahan, kontras, transformasi warna, blur, efek alfa, rantai berurutan, inspeksi, penghapusan, dan verifikasi putar‑balik, lihat [Image Transform Effects](/slides/id/python-java/image-transform-effects/).

## **Lock Picture Frame Geometry**

Pengaturan [PictureFrameLock](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframelock/) mengontrol operasi penyuntingan mana yang dinonaktifkan untuk picture frame. Misalnya, [setAspectRatioLocked](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) mempertahankan proporsi bentuk saat diubah ukuran.

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

Kunci ini berlaku pada bentuk picture frame. Ia tidak memaksa gambar sumber untuk di‑resample atau secara permanen diubah menjadi rasio aspek yang sama.

## **Adjust the StretchOffset Values**

Ketika mode isian gambar adalah stretch, nilai stretch‑offset pada [PictureFillFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/picturefillformat/) menentukan persegi panjang isian relatif terhadap kotak pembatas picture frame. Persentase positif membuat inset dari tepi, sementara persentase negatif membuat outset.

Ini berbeda dengan pemotongan. Nilai pemotongan memilih bagian gambar sumber yang terlihat; stretch offset mengubah persegi panjang tempat isian gambar yang terlihat diregangkan.

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

## **Storage, File Size, and Export Considerations**

Pertukaran utama menjadi lebih mudah dikelola ketika penyimpanan gambar dan pemformatan picture‑frame diperlakukan terpisah:

- **Embedded images** membuat presentasi mandiri dan merupakan yang paling dapat diandalkan untuk berbagi serta rendering sisi server, tetapi gambar raster besar meningkatkan ukuran PPTX dan penggunaan memori.
- **Linked images** dapat membuat paket lebih kecil, tetapi presentasi bergantung pada file eksternal yang tetap tersedia pada jalur atau lokasi yang disimpan.
- **Cropping** pada awalnya tidak destruktif. Piksel tersembunyi tetap disematkan sampai area yang dipotong secara eksplisit dihapus atau dihilangkan selama kompresi.
- **Compression** dapat mengurangi ukuran berkas secara signifikan untuk gambar raster yang berukuran berlebih, tetapi mengorbankan resolusi sumber. Kompresi sebaiknya diterapkan setelah ukuran akhir pada slide diketahui.
- **SVG images** sebaiknya tetap sebagai SVG ketika preservasi vektor penting. Ekstrak SVG yang disematkan secara langsung ketika Anda memerlukan sumber vektor itu sendiri. Ekspor slide raster selalu mengonversi slide yang dirender ke piksel.
- **Repeated images** sebaiknya menggunakan kembali sumber daya [PPImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/) yang ada bila memungkinkan alih‑alih memuat berkas yang sama berulang kali ke dalam alur kerja presentasi.

Untuk presentasi besar, optimasi gambar biasanya paling efektif bila dilakukan secara selektif: pertahankan logo dan diagram sebagai konten vektor, kompres foto sesuai ukuran tampilan sebenarnya, hapus piksel yang dipotong hanya bila penyuntingan di kemudian hari tidak diperlukan, dan hindari tautan eksternal kecuali manajemen dependensi menjadi bagian dari desain penyebaran.

## **FAQ**

**What is the difference between a picture frame and an image resource?**

[PPImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/) mewakili sumber daya gambar yang terkait dengan presentasi. [PictureFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/) adalah bentuk pada slide yang menampilkan gambar dan menyimpan geometri serta format tingkat frame seperti ukuran, rotasi, nilai pemotongan, efek, dan kunci.

**Should I embed or link images?**

Sematkan gambar ketika presentasi harus portabel, diarsipkan, atau dirender tanpa akses ke sumber eksternal. Tautkan gambar hanya ketika menyimpan file gambar di luar PPTX disengaja dan lokasi eksternal dapat dipelihara secara handal.

**Does cropping reduce PPTX file size?**

Tidak secara langsung. Pengaturan crop normal menyembunyikan bagian gambar sumber tetapi tetap menyimpan piksel di bawahnya. Gunakan [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/id/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) atau kompresi gambar dengan penghapusan area yang dipotong ketika piksel tersebut dapat dibuang secara permanen.

**Can I restore image quality after compression?**

Tidak. Kompresi dapat menurunkan resolusi raster yang disimpan, dan penghapusan wilayah yang dipotong membuang data gambar. Simpan gambar sumber asli di luar presentasi jika penyuntingan beresolusi tinggi di kemudian hari mungkin diperlukan.

**How should SVG images be handled?**

Pertahankan konten SVG sebagai SVG ketika kesetiaan vektor penting. [SvgImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgimage/) yang disematkan dapat diekstrak secara langsung. Merender slide ke format raster seperti PNG atau JPEG merasterkan SVG sebagai bagian dari gambar slide.

**How can I avoid unsafe casts when reading existing slides?**

Periksa tipe bentuk sebelum menggunakan anggota khusus picture‑frame. Pemeriksaan `isinstance` terhadap [PictureFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/) menghindari cast yang tidak valid dan memungkinkan kode menangani slide yang tidak berisi picture frame.