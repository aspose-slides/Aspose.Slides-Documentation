---
title: Membatasi Penyuntingan Presentasi dengan Kunci Bentuk di Python
linktitle: Membatasi Penyuntingan Presentasi
type: docs
weight: 60
url: /id/python-java/applying-protection-to-presentation/
keywords:
- mencegah penyuntingan
- melindungi dari penyuntingan
- kunci bentuk
- kunci posisi
- kunci pemilihan
- kunci pengubahan ukuran
- kunci pengelompokan
- PowerPoint
- PPTX
- presentasi
- Python
- Java
- Aspose.Slides
description: "Pelajari cara mengunci dan membuka kunci bentuk dalam presentasi PPTX dengan Aspose.Slides untuk Python via Java untuk membatasi pemilihan, pergerakan, pengubahan ukuran, dan pengelompokan."
---
## **Latar Belakang**

Penggunaan umum Aspose.Slides untuk Python via Java adalah untuk membuat, memperbarui, dan menyimpan presentasi PowerPoint (PPTX) sebagai bagian dari alur kerja otomatis. Ketika pengguna menerima presentasi ini, membatasi perubahan pada bentuk dapat membantu mempertahankan tata letak dan konten yang dimaksud.

Artikel ini menjelaskan bagaimana bentuk diatur pada slide dan cara menerapkan serta menghapus kunci bentuk dalam presentasi PPTX. Kunci ini memungkinkan Anda membatasi operasi penyuntingan tertentu pada bentuk individual.

## **Komposisi Slide**

Sebuah slide presentasi terdiri dari komponen seperti autoshape, tabel, objek OLE, bentuk yang dikelompokkan, bingkai gambar, bingkai video, konektor, dan elemen lain yang digunakan untuk membangun sebuah presentasi. Dalam Aspose.Slides untuk Python via Java, setiap elemen pada slide direpresentasikan oleh objek yang mewarisi dari kelas [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/).

Berbagai tipe bentuk menampilkan opsi penguncian yang berbeda. Kelas [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) adalah kelas dasar untuk kunci bentuk. Aspose.Slides untuk Python via Java menyediakan kelas kunci berikut:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) mengunci autoshape.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) mengunci bentuk konektor.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) mengunci objek grafis.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) mengunci bentuk grup.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) mengunci bingkai gambar.  

Untuk menerapkan kunci pada seluruh [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), iterasikan slide-nya dan tetapkan kunci yang sesuai pada setiap bentuk yang didukung.

## **Terapkan dan Hapus Perlindungan**

Editor presentasi yang kompatibel menggunakan kunci bentuk untuk membatasi operasi penyuntingan individual. Enkripsi file dan perlindungan penulisan tingkat dokumen merupakan [pengaturan perlindungan presentasi](/slides/id/python-java/password-protected-presentation/) yang terpisah.

### **Terapkan Perlindungan pada Bentuk PPTX**

Aspose.Slides untuk Python via Java menyediakan kelas [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) untuk bekerja dengan bentuk pada slide.

Contoh memanggil [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked), dan [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) dengan `True` untuk autoshape, dengan kunci setara untuk bentuk grup, konektor, dan bingkai gambar. Konektor menggunakan [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) untuk pergerakan; grup juga menggunakan [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) untuk membatasi pengelompokan.

Contoh memuat presentasi PPTX yang ada, memeriksa bentuk dalam koleksi bentuk tiap slide, dan menyimpan salinan dengan pembatasan ini diterapkan. Bentuk di luar empat tipe yang ditangani dibiarkan tidak berubah. Loop tidak menelusuri bentuk anak di dalam grup.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(True)
                auto_shape_lock.setSelectLocked(True)
                auto_shape_lock.setSizeLocked(True)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(True)
                group_shape_lock.setPositionLocked(True)
                group_shape_lock.setSelectLocked(True)
                group_shape_lock.setSizeLocked(True)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(True)
                connector_shape_lock.setSelectLocked(True)
                connector_shape_lock.setSizeLocked(True)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(True)
                picture_frame_lock.setSelectLocked(True)
                picture_frame_lock.setSizeLocked(True)

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Hapus Perlindungan**

Untuk menghapus kunci bentuk, setel nilainya ke `False`. Contoh berikut memuat presentasi dengan kunci bentuk dan menghapus pembatasan pemilihan, pergerakan, serta pengubahan ukuran melalui [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/), dan [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/). Itu juga menghapus pembatasan pengelompokan dengan memberikan `False` ke [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked), dan menyimpan salinan presentasi. Pengaturan kunci lainnya dibiarkan tidak berubah.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("ProtectedSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(False)
                auto_shape_lock.setSelectLocked(False)
                auto_shape_lock.setSizeLocked(False)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(False)
                group_shape_lock.setPositionLocked(False)
                group_shape_lock.setSelectLocked(False)
                group_shape_lock.setSizeLocked(False)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(False)
                connector_shape_lock.setSelectLocked(False)
                connector_shape_lock.setSizeLocked(False)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(False)
                picture_frame_lock.setSelectLocked(False)
                picture_frame_lock.setSizeLocked(False)

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Pertahankan Pemotongan Gambar**

Tempatkan foto dengan nama `photo.jpg` di direktori kerja. Contoh memotong 12% dari kiri dan 8% dari kanan, kemudian memanggil [setCropLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setCropLocked) dengan `True` untuk mempertahankan pemotongan.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.getImages().addImage(photo_bytes)
    
    picture_frame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo)
    picture_frame.getPictureFormat().setCropLeft(12)
    picture_frame.getPictureFormat().setCropRight(8)

    picture_lock = picture_frame.getPictureFrameLock()
    picture_lock.setAspectRatioLocked(False)
    picture_lock.setCropLocked(True)

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Di `PictureLocked.pptx`, PowerPoint menonaktifkan perintah **Crop** saat Anda memilih foto.

### **Pertahankan Diagram Tergrup**

Contoh mengelompokkan persegi panjang dan panah, kemudian memanggil [setUngroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setUngroupingLocked) dengan `True` untuk menjaga kedua bentuk tetap bersama. Anda masih dapat memindahkan grup atau mengubah isi sebuah komponen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    group = shapes.addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50)
    group.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30)
    group.getGroupShapeLock().setUngroupingLocked(True)

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Di `DiagramLocked.pptx`, PowerPoint menonaktifkan perintah **Ungroup** saat Anda memilih seluruh diagram.

### **Laporkan Kunci Bentuk yang Ada**

Untuk meninjau sebuah templat, buka dan baca objek kunci untuk setiap bentuk. Metode [getNoLocks](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/#getNoLocks) mengembalikan `True` ketika semua flag pada objek tersebut dinonaktifkan dan `False` ketika setidaknya satu diaktifkan. Sebuah grup dan anak‑anaknya memiliki objek kunci terpisah, jadi periksa anak‑anaknya bahkan ketika grup tidak memiliki kunci.

Contoh ini memeriksa pergerakan untuk autoshape, bingkai gambar, dan grup. Ia juga memeriksa pemotongan untuk gambar dan pengelompokan untuk grup. Laporan mencantumkan flag yang diaktifkan yang dikenalnya dan menandai tipe bentuk yang tidak diperiksanya.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, GroupShape, PictureFrame, Presentation


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = f"{prefix}{shape.getName()}"
        label = f"Slide {slide_number} | {path} | {shape.getClass().getSimpleName()}"
        flags = []

        if isinstance(shape, GroupShape):
            shape_lock = shape.getGroupShapeLock()
            if shape_lock.getUngroupingLocked():
                flags.append("UngroupingLocked")
        elif isinstance(shape, PictureFrame):
            shape_lock = shape.getPictureFrameLock()
            if shape_lock.getCropLocked():
                flags.append("CropLocked")
        elif isinstance(shape, AutoShape):
            shape_lock = shape.getAutoShapeLock()
        else:
            print(f"{label} | Uninspected")
            continue

        if shape_lock.getPositionLocked():
            flags.append("PositionLocked")
        if not shape_lock.getNoLocks():
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, GroupShape):
            inspect_shapes(shape.getShapes(), slide_number, f"{path}/")


presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        inspect_shapes(slide.getShapes(), slide.getSlideNumber())
finally:
    presentation.dispose()
```

Misalkan slide 1 dari `Sample.pptx` berisi grup bernama `Layout` dengan pengelompokan terkunci, sebuah gambar bernama `Photo` di dalamnya dengan pemotongan terkunci, dan persegi panjang yang tidak terkunci bernama `Free`. Laporan melewatkan `Free` dan mencetak dua baris berikut:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Laporan membaca flag penyuntingan tingkat bentuk yang disimpan tanpa mengubahnya atau menyimpan presentasi. Perlindungan penulisan tingkat dokumen adalah pengaturan terpisah, dan penegakan setiap flag tergantung pada editor.

### **Kesimpulan**

Aspose.Slides untuk Python via Java memungkinkan Anda membatasi operasi penyuntingan tertentu pada bentuk individual atau menerapkan pembatasan yang sama di seluruh slide. Pilih kunci yang didukung oleh setiap tipe bentuk, dan setel nilainya ke `False` ketika Anda perlu menghapus pembatasan tersebut.

## **FAQ**

**Bisakah saya menggabungkan kunci bentuk dan perlindungan kata sandi dalam presentasi yang sama?**

Ya. Kunci bentuk membatasi operasi penyuntingan tertentu, sementara [perlindungan kata sandi](/slides/id/python-java/password-protected-presentation/) dapat membatasi pembukaan atau modifikasi presentasi. Anda dapat menggunakan keduanya dalam file yang sama.

**Bisakah saya membatasi penyuntingan pada slide tertentu tanpa memengaruhi yang lain?**

Ya. Terapkan kunci hanya pada bentuk di slide yang dipilih. Ini tidak mengubah pengaturan kunci pada slide lain.

**Bagaimana saya dapat menerapkan kunci pada bentuk individual di dalam grup?**

Iterasikan koleksi yang dikembalikan oleh metode [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) pada grup dan terapkan kunci yang sesuai pada setiap bentuk anak. Ulangi ini untuk grup bersarang apa pun, mengikuti penelusuran dalam contoh pelaporan.