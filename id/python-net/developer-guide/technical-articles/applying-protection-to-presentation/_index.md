---
title: Mencegah Pengeditan Presentasi dengan Kunci Shape di Python
linktitle: Mencegah Pengeditan Presentasi
type: docs
weight: 70
url: /id/python-net/applying-protection-to-presentation/
keywords:
- mencegah pengeditan
- melindungi dari pengeditan
- mengunci shape
- mengunci posisi
- mengunci pemilihan
- mengunci ukuran
- mengunci pengelompokan
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Temukan bagaimana Aspose.Slides for Python via .NET mengunci atau membuka kunci shape dalam file PPT, PPTX, dan ODP, mengamankan presentasi sekaligus memungkinkan pengeditan terkontrol dan pengiriman lebih cepat."
---
## **Latar Belakang**

Penggunaan umum Aspose.Slides adalah untuk membuat, memperbarui, dan menyimpan presentasi Microsoft PowerPoint (PPTX) sebagai bagian dari alur kerja otomatis. Pengguna aplikasi yang memanfaatkan Aspose.Slides dengan cara ini memiliki akses ke presentasi yang dihasilkan, sehingga melindungi mereka dari pengeditan menjadi perhatian umum. Penting agar presentasi yang dihasilkan secara otomatis mempertahankan format dan kontennya yang asli.

Artikel ini menjelaskan bagaimana presentasi dan slide disusun serta bagaimana Aspose.Slides for Python dapat menerapkan proteksi pada sebuah presentasi dan kemudian menghapusnya. Ini memberi pengembang cara mengendalikan bagaimana presentasi yang dihasilkan aplikasi mereka digunakan.

## **Komposisi Slide**

Slide presentasi terdiri dari komponen seperti autoshape, tabel, objek OLE, shape yang dikelompokkan, bingkai gambar, bingkai video, penghubung, dan elemen lain yang digunakan untuk membangun sebuah presentasi. Dalam Aspose.Slides for Python, setiap elemen pada slide direpresentasikan oleh objek yang mewarisi kelas [Shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/).

Struktur PPTX bersifat kompleks, sehingga tidak seperti PPT, di mana kunci generik dapat digunakan untuk semua jenis shape, tipe shape yang berbeda memerlukan kunci yang berbeda. Kelas [BaseShapeLock](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseshapelock/) adalah kelas kunci generik untuk PPTX. Jenis kunci berikut didukung dalam Aspose.Slides for Python untuk PPTX:

- [AutoShapeLock](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshapelock/) mengunci autoshape.  
- [ConnectorLock](https://reference.aspose.com/slides/id/python-net/aspose.slides/connectorlock/) mengunci shape penghubung.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/id/python-net/aspose.slides/graphicalobjectlock/) mengunci objek grafis.  
- [GroupShapeLock](https://reference.aspose.com/slides/id/python-net/aspose.slides/groupshapelock/) mengunci shape grup.  
- [PictureFrameLock](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframelock/) mengunci bingkai gambar.  

Setiap tindakan yang dilakukan pada semua objek shape dalam sebuah objek [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) diterapkan pada seluruh presentasi.

## **Terapkan dan Hapus Proteksi**

Menerapkan proteksi memastikan bahwa sebuah presentasi tidak dapat diedit. Ini merupakan teknik yang berguna untuk melindungi konten presentasi.

### **Terapkan Proteksi ke Shape PPTX**

Aspose.Slides for Python menyediakan kelas [Shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/) untuk bekerja dengan shape pada slide.

Seperti disebutkan sebelumnya, setiap kelas shape memiliki kelas shape‑lock terkait untuk proteksi. Artikel ini berfokus pada kunci NoSelect, NoMove, dan NoResize. Kunci‑kunci ini memastikan bahwa shape tidak dapat dipilih (melalui klik mouse atau metode pemilihan lainnya) serta tidak dapat dipindahkan atau diubah ukurannya.

Contoh kode berikut menerapkan proteksi pada semua tipe shape dalam sebuah presentasi.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili file PPTX.
with slides.Presentation("Sample.pptx") as presentation:
    # Menelusuri semua slide dalam presentasi.
    for slide in presentation.slides:
        # Menelusuri semua shape dalam slide.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
    # Menyimpan file presentasi.
    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Hapus Proteksi**

Untuk membuka kunci sebuah shape, setel nilai kunci yang diterapkan menjadi `False`. Contoh kode berikut menunjukkan cara membuka kunci shape dalam presentasi yang terkunci.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili file PPTX.
with slides.Presentation("ProtectedSample.pptx") as presentation:
    # Menelusuri semua slide dalam presentasi.
    for slide in presentation.slides:
        # Menelusuri semua shape dalam slide.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
    # Menyimpan file presentasi.
    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Kesimpulan**

Aspose.Slides menawarkan beberapa opsi untuk melindungi shape dalam sebuah presentasi. Anda dapat mengunci shape individu atau mengiterasi semua shape dalam sebuah presentasi dan mengunci masing‑masing untuk secara efektif mengamankan seluruh file. Anda dapat menghapus proteksi dengan mengatur nilai kunci menjadi `False`.

## **FAQ**

**Apakah saya dapat menggabungkan kunci shape dan proteksi kata sandi dalam satu presentasi?**

Ya. Kunci membatasi pengeditan objek di dalam file, sementara [perlindungan kata sandi](/slides/id/python-net/password-protected-presentation/) mengendalikan akses untuk membuka dan/atau menyimpan perubahan. Kedua mekanisme ini saling melengkapi dan bekerja bersama.

**Apakah saya dapat membatasi pengeditan pada slide tertentu tanpa memengaruhi slide lain?**

Ya. Terapkan kunci pada shape di slide yang dipilih; slide yang tersisa tetap dapat diedit.

**Apakah kunci shape berlaku untuk objek yang dikelompokkan dan penghubung?**

Ya. Tipe kunci khusus didukung untuk grup, penghubung, objek grafis, dan jenis shape lainnya.