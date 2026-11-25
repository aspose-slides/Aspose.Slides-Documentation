---
title: Membatasi Penyuntingan Presentasi dengan Kunci Shape di Python
linktitle: Membatasi Penyuntingan Presentasi
type: docs
weight: 70
url: /id/python-net/applying-protection-to-presentation/
keywords:
- mencegah penyuntingan
- melindungi dari penyuntingan
- kunci shape
- kunci posisi
- kunci seleksi
- kunci mengubah ukuran
- kunci pengelompokan
- PowerPoint
- PPTX
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara mengunci dan membuka kunci shape pada presentasi PPTX dengan Aspose.Slides for Python via .NET untuk membatasi seleksi, pergerakan, pengubahan ukuran, dan pengelompokan."
---
## **Latar Belakang**

Penggunaan umum Aspose.Slides for Python via .NET adalah untuk membuat, memperbarui, dan menyimpan presentasi PowerPoint (PPTX) sebagai bagian dari alur kerja otomatis. Ketika pengguna menerima presentasi ini, membatasi perubahan pada shape dapat membantu mempertahankan tata letak dan konten yang dimaksudkan.

Artikel ini menjelaskan cara shape diatur pada slide dan cara menerapkan serta menghapus kunci shape dalam presentasi PPTX. Kunci ini memungkinkan Anda membatasi operasi pengeditan tertentu pada shape individual.

## **Komposisi Slide**

Sebuah slide presentasi terdiri dari komponen seperti autoshape, tabel, objek OLE, shape yang dikelompokkan, bingkai gambar, bingkai video, konektor, dan elemen lain yang digunakan untuk membangun presentasi. Dalam Aspose.Slides for Python via .NET, setiap elemen pada slide direpresentasikan oleh objek yang mewarisi dari kelas [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

Berbagai tipe shape menyediakan opsi penguncian yang berbeda. Kelas [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) merupakan kelas dasar untuk kunci shape. Aspose.Slides for Python via .NET menyediakan kelas kunci berikut:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) mengunci autoshape.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) mengunci shape konektor.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) mengunci objek grafis.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) mengunci shape grup.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) mengunci bingkai gambar.  

Untuk menerapkan kunci pada seluruh [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), iterasi melalui slide‑nya dan atur kunci yang sesuai pada setiap shape yang didukung.

## **Terapkan dan Hapus Perlindungan**

Editor presentasi yang kompatibel menggunakan kunci shape untuk membatasi operasi pengeditan individual. Enkripsi file dan perlindungan tulis tingkat dokumen merupakan [pengaturan perlindungan presentasi](/slides/id/python-net/password-protected-presentation/) yang terpisah.

### **Terapkan Perlindungan pada Shape PPTX**

Aspose.Slides for Python via .NET menyediakan kelas [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) untuk bekerja dengan shape pada slide.

Contoh ini mengatur [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/), dan [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) menjadi `True` untuk autoshape, dengan kunci serupa untuk shape grup, konektor, dan bingkai gambar. Konektor menggunakan [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) untuk pergerakan; grup juga menggunakan [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) untuk membatasi pengelompokan.

Contoh ini memuat presentasi PPTX yang ada, memeriksa shape pada koleksi shape setiap slide, dan menyimpan salinan dengan pembatasan ini diterapkan. Shape di luar empat tipe yang ditangani dibiarkan tidak berubah. Loop tidak menelusuri shape anak di dalam grup.

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True

    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Hapus Perlindungan**

Untuk menghapus kunci shape, atur nilainya menjadi `False`. Contoh berikut memuat presentasi dengan kunci shape dan menghapus pembatasan seleksi, pergerakan, dan pengubahan ukuran melalui [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/), dan [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Contoh ini juga menghapus [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) dan menyimpan salinan presentasi. Pengaturan kunci lainnya dibiarkan tidak berubah.

```python
import aspose.slides as slides

with slides.Presentation("ProtectedSample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False

    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Mempertahankan Pemotongan Gambar**

Tempatkan foto bernama `photo.jpg` di direktori kerja. Contoh ini memotong 12% dari kiri dan 8% dari kanan, lalu mengatur [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) pada bingkai gambar. Flag ini membatasi pemotongan lebih lanjut dan mempertahankan pemotongan yang sudah ada.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.images.add_image(photo_bytes)

    picture_frame = shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 30, 270, 160, photo)
    picture_frame.picture_format.crop_left = 12
    picture_frame.picture_format.crop_right = 8
    picture_frame.shape_lock.aspect_ratio_locked = False
    picture_frame.shape_lock.crop_locked = True

    presentation.save("PictureLocked.pptx", slides.export.SaveFormat.PPTX)
```

`PictureLocked.pptx` menyimpan kunci pemotongan sebagai `True`. Di PowerPoint, perintah **Crop** dinonaktifkan ketika foto dipilih.

### **Menjaga Diagram Tetap Dikelompokkan**

Contoh ini mengelompokkan persegi panjang dan panah, lalu mengatur [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) pada grup itu sendiri untuk menjaga komponen diagram tetap bersama. Penyuntingan lain, seperti memindahkan grup atau mengubah isi komponen, tetap tersedia.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    group_shape = shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 70, 90, 50)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 190, 80, 60, 30)
    group_shape.shape_lock.ungrouping_locked = True

    presentation.save("DiagramLocked.pptx", slides.export.SaveFormat.PPTX)
```

`DiagramLocked.pptx` menyimpan kunci ungrouping sebagai `True`. Di PowerPoint, perintah **Ungroup** dinonaktifkan ketika keseluruhan diagram dipilih.

### **Laporkan Kunci Shape yang Ada**

Untuk meninjau template, buka template tersebut dan baca objek kunci untuk tiap shape. [no_locks](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/no_locks/) bernilai `True` ketika semua flag pada objek tersebut dinonaktifkan dan `False` ketika setidaknya satu flag diaktifkan. Grup dan anak‑anaknya memiliki objek kunci terpisah, sehingga periksa anak‑anak meskipun grup tidak memiliki kunci.

Contoh ini memeriksa pergerakan untuk autoshape, bingkai gambar, dan grup, pemotongan untuk gambar, serta ungrouping untuk grup. Ia melaporkan flag yang dikenali dan menandai tipe shape yang tidak diperiksa.

```python
import aspose.slides as slides


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = prefix + shape.name
        label = f"Slide {slide_number} | {path} | {type(shape).__name__}"
        if not isinstance(shape, (slides.GroupShape, slides.PictureFrame, slides.AutoShape)):
            print(f"{label} | Uninspected")
            continue

        shape_lock = shape.shape_lock
        if not shape_lock.no_locks:
            flags = []
            if isinstance(shape, slides.GroupShape) and shape_lock.ungrouping_locked:
                flags.append("ungrouping_locked")
            if isinstance(shape, slides.PictureFrame) and shape_lock.crop_locked:
                flags.append("crop_locked")
            if shape_lock.position_locked:
                flags.append("position_locked")
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, slides.GroupShape):
            inspect_shapes(shape.shapes, slide_number, path + "/")


with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        inspect_shapes(slide.shapes, slide.slide_number)
```

Misalkan slide 1 dari `Sample.pptx` berisi grup bernama `Layout` dengan ungrouping terkunci, gambar bernama `Photo` di dalamnya dengan pemotongan terkunci, dan persegi panjang yang tidak terkunci bernama `Free`. Laporan akan melewatkan `Free` dan mencetak dua baris berikut:

```text
Slide 1 | Layout | GroupShape | ungrouping_locked
Slide 1 | Layout/Photo | PictureFrame | crop_locked
```

Laporan membaca flag penyuntingan tingkat shape yang disimpan tanpa mengubahnya atau menyimpan presentasi. Perlindungan tulis tingkat dokumen merupakan pengaturan terpisah, dan penegakan tiap flag tergantung pada editor yang digunakan.

### **Kesimpulan**

Aspose.Slides for Python via .NET memungkinkan Anda membatasi operasi penyuntingan tertentu pada shape individual atau menerapkan pembatasan yang sama di seluruh slide. Pilih kunci yang didukung oleh tiap tipe shape, dan atur nilainya menjadi `False` ketika Anda perlu menghapus pembatasan tersebut.

## **FAQ**

**Apakah saya dapat menggabungkan kunci shape dan perlindungan kata sandi dalam presentasi yang sama?**

Ya. Kunci shape membatasi operasi penyuntingan tertentu, sementara [password protection](/slides/id/python-net/password-protected-presentation/) dapat membatasi pembukaan atau modifikasi presentasi. Anda dapat menggunakan keduanya dalam satu file.

**Apakah saya dapat membatasi penyuntingan pada slide tertentu tanpa memengaruhi slide lain?**

Ya. Terapkan kunci hanya pada shape di slide yang dipilih. Ini tidak mengubah pengaturan kunci pada slide lain.

**Bagaimana cara menerapkan kunci pada shape individual di dalam grup?**

Iterasi melalui koleksi [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) grup dan terapkan kunci yang sesuai pada tiap shape anak. Ulangi proses ini untuk grup bersarang, mengikuti penelusuran pada contoh pelaporan.