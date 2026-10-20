---
title: Membatasi Penyuntingan Presentasi dengan Kunci Bentuk di Python
linktitle: Membatasi Penyuntingan Presentasi
type: docs
weight: 70
url: /id/python-net/applying-protection-to-presentation/
keywords:
- mencegah penyuntingan
- melindungi dari penyuntingan
- kunci bentuk
- kunci posisi
- kunci pilih
- kunci mengubah ukuran
- kunci pengelompokan
- PowerPoint
- PPTX
- presentasi
- Python
- Aspose.Slides
description: Pelajari cara mengunci dan membuka kunci bentuk dalam presentasi PPTX dengan Aspose.Slides for Python via .NET untuk membatasi pemilihan, pergerakan, pengubahan ukuran, dan pengelompokan.
---
## **Latar Belakang**

Penggunaan umum Aspose.Slides for Python via .NET adalah untuk membuat, memperbarui, dan menyimpan presentasi PowerPoint (PPTX) sebagai bagian dari alur kerja otomatis. Ketika pengguna menerima presentasi ini, membatasi perubahan pada bentuk dapat membantu mempertahankan tata letak dan konten yang dimaksud.

Artikel ini menjelaskan bagaimana bentuk diatur pada slide dan cara menerapkan serta menghapus kunci bentuk dalam presentasi PPTX. Kunci ini memungkinkan Anda membatasi operasi penyuntingan tertentu pada bentuk individu.

## **Komposisi Slide**

Sebuah slide presentasi terdiri dari komponen seperti autoshapes, tabel, objek OLE, bentuk yang digabungkan, bingkai gambar, bingkai video, konektor, dan elemen lain yang digunakan untuk membangun sebuah presentasi. Dalam Aspose.Slides for Python via .NET, setiap elemen pada slide direpresentasikan oleh sebuah objek yang mewarisi dari kelas [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) .

Berbagai tipe bentuk menampilkan opsi penguncian yang berbeda. Kelas [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) adalah kelas dasar untuk kunci bentuk. Aspose.Slides for Python via .NET menyediakan kelas kunci berikut:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) mengunci autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) mengunci bentuk konektor.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) mengunci objek grafis.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) mengunci bentuk grup.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) mengunci bingkai gambar.  

Untuk menerapkan kunci pada seluruh [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), iterasikan slide‑slidenya dan tetapkan kunci yang sesuai pada setiap bentuk yang didukung.

## **Terapkan dan Hapus Proteksi**

Kunci bentuk membatasi operasi seperti memilih, memindahkan, dan mengubah ukuran bentuk. Mereka tidak membuat seluruh presentasi tidak dapat diedit.

### **Terapkan Proteksi pada Bentuk PPTX**

Aspose.Slides for Python via .NET menyediakan kelas [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) untuk bekerja dengan bentuk pada slide.

Contoh mengatur [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) , dan [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) menjadi `True` untuk autoshapes, dengan kunci serupa untuk bentuk grup, konektor, dan bingkai gambar. Konektor menggunakan [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) untuk pergerakan; grup juga menggunakan [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) untuk membatasi pengelompokan.

Contoh memuat presentasi PPTX yang ada, memeriksa bentuk‑bentuk dalam koleksi bentuk setiap slide, dan menyimpan salinan dengan pembatasan ini diterapkan. Bentuk di luar empat tipe yang ditangani dibiarkan tidak berubah. Loop tidak menelusuri bentuk anak di dalam grup.

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

### **Hapus Proteksi**

Untuk menghapus kunci bentuk, setel nilainya menjadi `False`. Contoh berikut memuat presentasi dengan kunci bentuk dan menghapus pembatasan pemilihan, pergerakan, serta perubahan ukuran melalui [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/), dan [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Ia juga menghapus [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) dan menyimpan salinan presentasi. Pengaturan kunci lainnya dibiarkan tidak berubah.

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

### **Kesimpulan**

Aspose.Slides for Python via .NET memungkinkan Anda membatasi operasi penyuntingan tertentu pada bentuk individu atau menerapkan pembatasan yang sama pada seluruh slide. Pilih kunci yang didukung oleh tiap tipe bentuk, dan setel nilainya ke `False` bila Anda perlu menghapus pembatasan tersebut.

## **FAQ**

**Apakah saya dapat menggabungkan kunci bentuk dan proteksi kata sandi dalam satu presentasi?**

Ya. Kunci bentuk membatasi operasi penyuntingan tertentu, sementara [password protection](/slides/id/python-net/password-protected-presentation/) dapat membatasi pembukaan atau modifikasi presentasi. Anda dapat menggunakan keduanya dalam satu berkas.

**Apakah saya dapat membatasi penyuntingan pada slide tertentu tanpa memengaruhi slide lain?**

Ya. Terapkan kunci hanya pada bentuk di slide yang dipilih. Hal ini tidak mengubah pengaturan kunci pada slide lain.

**Bagaimana cara menerapkan kunci pada bentuk individu di dalam sebuah grup?**

Iterasikan koleksi [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) grup dan terapkan kunci yang sesuai pada tiap bentuk anak. Ulangi proses ini untuk setiap grup bersarang. Contoh di atas hanya memproses koleksi bentuk slide, sehingga tidak mengatur kunci pada anggota grup individu.