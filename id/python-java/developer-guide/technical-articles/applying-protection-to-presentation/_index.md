---
title: Batasi Pengeditan Presentasi dengan Kunci Bentuk di Python
linktitle: Batasi Pengeditan Presentasi
type: docs
weight: 60
url: /id/python-java/applying-protection-to-presentation/
keywords:
- mencegah pengeditan
- melindungi dari pengeditan
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
description: "Pelajari cara mengunci dan membuka kunci bentuk dalam presentasi PPTX dengan Aspose.Slides for Python via Java untuk membatasi pemilihan, pergerakan, pengubahan ukuran, dan pengelompokan."
---
## **Latar Belakang**

Penggunaan umum Aspose.Slides for Python via Java adalah untuk membuat, memperbarui, dan menyimpan presentasi PowerPoint (PPTX) sebagai bagian dari alur kerja otomatis. Ketika pengguna menerima presentasi ini, membatasi perubahan pada bentuk dapat membantu mempertahankan tata letak dan konten yang dimaksud.

Artikel ini menjelaskan bagaimana bentuk diatur pada slide dan cara menerapkan serta menghapus kunci bentuk dalam presentasi PPTX. Kunci ini memungkinkan Anda membatasi operasi pengeditan tertentu pada bentuk individu.

## **Komposisi Slide**

Slide presentasi terdiri dari komponen seperti autoshape, tabel, objek OLE, bentuk yang dikelompokkan, bingkai gambar, bingkai video, konektor, dan elemen lain yang digunakan untuk membangun presentasi. Dalam Aspose.Slides for Python via Java, setiap elemen pada slide direpresentasikan oleh sebuah objek yang mewarisi dari kelas [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) .

Berbagai tipe bentuk menyediakan opsi penguncian yang berbeda. Kelas [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) adalah kelas dasar untuk kunci bentuk. Aspose.Slides for Python via Java menyediakan kelas kunci berikut:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) mengunci autoshape.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) mengunci bentuk konektor.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) mengunci objek grafis.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) mengunci bentuk grup.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) mengunci bingkai gambar.  

Untuk menerapkan kunci pada seluruh [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), iterasikan melalui slide-nya dan tetapkan kunci yang sesuai pada setiap bentuk yang didukung.

## **Terapkan dan Hapus Perlindungan**

Kunci bentuk membatasi operasi seperti memilih, memindahkan, dan mengubah ukuran bentuk. Mereka tidak membuat seluruh presentasi tidak dapat diedit.

### **Terapkan Perlindungan pada Bentuk PPTX**

Aspose.Slides for Python via Java menyediakan kelas [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) untuk bekerja dengan bentuk pada slide.

Contoh memanggil [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked), dan [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) dengan `True` untuk autoshape, dengan kunci yang setara untuk bentuk grup, konektor, dan bingkai gambar. Konektor menggunakan [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) untuk pergerakan; grup juga menggunakan [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) untuk membatasi pengelompokan.

Contoh memuat presentasi PPTX yang ada, memeriksa bentuk dalam koleksi bentuk setiap slide, dan menyimpan salinan dengan pembatasan ini diterapkan. Bentuk di luar empat tipe yang ditangani dibiarkan tidak berubah. Loop tidak menelusuri bentuk anak di dalam grup.

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

Untuk menghapus kunci bentuk, atur nilainya menjadi `False`. Contoh berikut memuat presentasi dengan kunci bentuk dan menghapus pembatasan pemilihan, pergerakan, dan pengubahan ukuran melalui [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/), dan [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/). Ini juga menghapus pembatasan pengelompokan dengan memberikan `False` ke [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked), dan menyimpan salinan presentasi. Pengaturan kunci lainnya dibiarkan tidak berubah.

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

### **Kesimpulan**

Aspose.Slides for Python via Java memungkinkan Anda membatasi operasi pengeditan tertentu pada bentuk individual atau menerapkan pembatasan yang sama di seluruh slide. Pilih kunci yang didukung oleh masing-masing tipe bentuk, dan atur nilainya menjadi `False` ketika Anda perlu menghapus pembatasan tersebut.

## **Tanya Jawab**

**Apakah saya dapat menggabungkan kunci bentuk dan perlindungan kata sandi dalam presentasi yang sama?**

Ya. Kunci bentuk membatasi operasi pengeditan tertentu, sementara [password protection](/slides/id/python-java/password-protected-presentation/) dapat membatasi pembukaan atau modifikasi presentasi. Anda dapat menggunakan keduanya dalam file yang sama.

**Apakah saya dapat membatasi pengeditan pada slide tertentu tanpa memengaruhi yang lain?**

Ya. Terapkan kunci hanya pada bentuk di slide yang dipilih. Hal ini tidak mengubah pengaturan kunci pada slide lain.

**Bagaimana saya dapat menerapkan kunci pada bentuk individual di dalam grup?**

Iterasikan melalui koleksi yang dikembalikan oleh metode [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) grup dan terapkan kunci yang sesuai pada setiap bentuk anak. Ulangi ini untuk setiap grup bersarang. Contoh di atas hanya memproses koleksi bentuk slide, sehingga tidak menetapkan kunci pada anggota grup individual.