---
title: Cegah Penyuntingan Presentasi dengan Kunci Bentuk
linktitle: Cegah Penyuntingan Presentasi
type: docs
weight: 60
url: /id/python-java/applying-protection-to-presentation/
keywords:
- mencegah penyuntingan
- melindungi dari penyuntingan
- kunci bentuk
- kunci posisi
- kunci seleksi
- kunci ukuran
- kunci pengelompokan
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Temukan cara Aspose.Slides for Python via Java mengunci atau membuka kunci bentuk dalam file PPT, PPTX, dan ODP, mengamankan presentasi sambil memungkinkan penyuntingan terkontrol dan pengiriman lebih cepat."
---
## **Latar Belakang**

Penggunaan umum Aspose.Slides adalah untuk membuat, memperbarui, dan menyimpan presentasi Microsoft PowerPoint (PPTX) sebagai bagian dari alur kerja otomatis. Pengguna aplikasi yang memanfaatkan Aspose.Slides dengan cara ini memiliki akses ke presentasi yang dihasilkan, sehingga melindungi mereka dari penyuntingan menjadi keprihatinan umum. Penting agar presentasi yang dihasilkan secara otomatis mempertahankan format dan konten aslinya.

Artikel ini menjelaskan bagaimana presentasi dan slide disusun serta bagaimana Aspose.Slides for Python via Java dapat menerapkan proteksi pada sebuah presentasi dan kemudian menghapusnya. Ini memberi pengembang cara mengendalikan penggunaan presentasi yang dihasilkan aplikasi mereka.

## **Komposisi Slide**

Sebuah slide presentasi terdiri dari komponen seperti autoshape, tabel, objek OLE, bentuk yang dikelompokkan, bingkai gambar, bingkai video, konektor, dan elemen lain yang digunakan untuk membangun sebuah presentasi. Di Aspose.Slides for Python via Java, setiap elemen pada slide direpresentasikan oleh objek yang mewarisi kelas [Shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/) .

Struktur PPTX bersifat kompleks, sehingga tidak seperti PPT, di mana kunci generik dapat digunakan untuk semua jenis bentuk, tipe bentuk yang berbeda memerlukan kunci yang berbeda. Kelas [BaseShapeLock](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseshapelock/) adalah kelas kunci generik untuk PPTX. Jenis kunci berikut didukung dalam Aspose.Slides for Python via Java untuk PPTX:

- [AutoShapeLock](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshapelock/) mengunci autoshape.  
- [ConnectorLock](https://reference.aspose.com/slides/id/python-java/aspose.slides/connectorlock/) mengunci bentuk konektor.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/id/python-java/aspose.slides/graphicalobjectlock/) mengunci objek grafis.  
- [GroupShapeLock](https://reference.aspose.com/slides/id/python-java/aspose.slides/groupshapelock/) mengunci bentuk grup.  
- [PictureFrameLock](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframelock/) mengunci bingkai gambar.  

Setiap tindakan yang dilakukan pada semua objek bentuk dalam objek [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) diterapkan ke seluruh presentasi.

## **Terapkan dan Hapus Proteksi**

Menerapkan proteksi memastikan bahwa sebuah presentasi tidak dapat diedit. Ini merupakan teknik yang berguna untuk melindungi konten presentasi.

### **Terapkan Proteksi pada Bentuk PPTX**

Aspose.Slides for Python via Java menyediakan kelas [Shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/) untuk bekerja dengan bentuk pada slide.

Seperti yang disebutkan sebelumnya, setiap kelas bentuk memiliki kelas kunci‑bentuk yang terkait untuk proteksi. Artikel ini berfokus pada kunci NoSelect, NoMove, dan NoResize. Kunci‑kunci ini memastikan bahwa bentuk tidak dapat dipilih (melalui klik mouse atau metode pemilihan lainnya) serta tidak dapat dipindahkan atau diubah ukurannya.

Contoh kode berikut menerapkan proteksi pada semua tipe bentuk dalam sebuah presentasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# Buat instance kelas Presentation yang merepresentasikan file PPTX.
presentation = Presentation("Sample.pptx")
try:
    # Telusuri semua slide dalam presentasi.
    for slide in presentation.getSlides():
        # Telusuri semua bentuk dalam slide.
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

    # Simpan file presentasi.
    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Hapus Proteksi**

Untuk membuka kunci sebuah bentuk, atur nilai kunci yang diterapkan menjadi `False`. Contoh kode berikut menunjukkan cara membuka kunci bentuk dalam presentasi yang terkunci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# Buat instance kelas Presentation yang merepresentasikan file PPTX.
presentation = Presentation("ProtectedSample.pptx")
try:
    # Telusuri semua slide dalam presentasi.
    for slide in presentation.getSlides():
        # Telusuri semua bentuk dalam slide.
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

    # Simpan file presentasi.
    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kesimpulan**

Aspose.Slides menawarkan beberapa opsi untuk melindungi bentuk dalam sebuah presentasi. Anda dapat mengunci satu bentuk secara individu atau iterasi melalui semua bentuk dalam sebuah presentasi dan mengunci masing‑masing untuk secara efektif mengamankan seluruh file. Anda dapat menghapus proteksi dengan mengatur nilai kunci menjadi `False`.

## **FAQ**

**Apakah saya dapat menggabungkan kunci bentuk dan perlindungan kata sandi dalam presentasi yang sama?**

Ya. Kunci membatasi penyuntingan objek di dalam file, sementara [password protection](/slides/id/python-java/password-protected-presentation/) mengontrol akses untuk membuka dan/atau menyimpan perubahan. Mekanisme ini saling melengkapi dan bekerja bersama.

**Apakah saya dapat membatasi penyuntingan pada slide tertentu tanpa memengaruhi yang lain?**

Ya. Terapkan kunci pada bentuk di slide yang dipilih; slide yang tersisa tetap dapat diedit.

**Apakah kunci bentuk berlaku untuk objek yang dikelompokkan dan konektor?**

Ya. Jenis kunci khusus didukung untuk grup, konektor, objek grafis, dan jenis bentuk lainnya.