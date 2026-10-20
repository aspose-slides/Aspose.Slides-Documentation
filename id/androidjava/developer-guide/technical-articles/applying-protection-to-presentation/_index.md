---
title: Batasi Penyuntingan Presentasi dengan Kunci Bentuk di Android
linktitle: Batasi Penyuntingan Presentasi
type: docs
weight: 60
url: /id/androidjava/applying-protection-to-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Pelajari cara mengunci dan membuka kunci bentuk dalam presentasi PPTX dengan Aspose.Slides untuk Android via Java untuk membatasi pemilihan, pergerakan, pengubahan ukuran, dan pengelompokan."
---
## **Gambaran Umum**

Penggunaan umum Aspose.Slides untuk Android via Java adalah untuk membuat, memperbarui, dan menyimpan presentasi PowerPoint (PPTX) sebagai bagian dari alur kerja otomatis. Ketika pengguna menerima presentasi ini, membatasi perubahan pada bentuk dapat membantu mempertahankan tata letak dan konten yang dimaksud.

Artikel ini menjelaskan bagaimana bentuk diatur pada slide dan cara menerapkan serta menghapus kunci bentuk dalam presentasi PPTX. Kunci ini memungkinkan Anda membatasi operasi penyuntingan tertentu pada bentuk individu.

## **Komposisi Slide**

Sebuah slide presentasi terdiri dari komponen seperti autoshapes, tabel, objek OLE, bentuk yang dikelompokkan, bingkai gambar, bingkai video, konektor, dan elemen lain yang digunakan untuk membangun presentasi. Di Aspose.Slides for Android via Java, setiap elemen pada slide diwakili oleh objek yang mengimplementasikan antarmuka [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) atau mewarisi dari kelas yang melakukannya.

Berbagai jenis bentuk memperlihatkan opsi kunci yang berbeda. Antarmuka [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) adalah antarmuka dasar untuk kunci bentuk. Aspose.Slides for Android via Java menyediakan antarmuka kunci berikut:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) mengunci autoshape.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) mengunci bentuk konektor.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) mengunci objek grafis.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) mengunci bentuk grup.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) mengunci bingkai gambar.  

Untuk menerapkan kunci pada seluruh [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), iterasi melalui slide‑slidenya dan tetapkan kunci yang sesuai pada setiap bentuk yang didukung.

## **Terapkan dan Hapus Perlindungan**

Kunci bentuk membatasi operasi seperti memilih, memindahkan, dan mengubah ukuran bentuk. Mereka tidak membuat seluruh presentasi tidak dapat diedit.

### **Terapkan Perlindungan pada Bentuk PPTX**

Aspose.Slides for Android via Java menyediakan antarmuka [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) untuk bekerja dengan bentuk pada slide.

Contoh memanggil [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), dan [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) dengan `true` untuk autoshape, serta kunci yang setara untuk bentuk grup, konektor, dan bingkai gambar. Konektor menggunakan [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) untuk pergerakan; grup juga menggunakan [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) untuk membatasi pengelompokan.

Contoh memuat presentasi PPTX yang ada, memeriksa bentuk‑bentuk dalam koleksi bentuk setiap slide, dan menyimpan salinan dengan pembatasan ini diterapkan. Bentuk di luar empat tipe yang ditangani dibiarkan tidak berubah. Loop tidak menelusuri bentuk anak di dalam grup.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Hapus Perlindungan**

Untuk menghapus kunci bentuk, setel nilainya menjadi `false`. Contoh berikut memuat presentasi dengan kunci bentuk dan menghapus pembatasan pemilihan, pergerakan, dan pengubahan ukuran melalui [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/), dan [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/). Itu juga menghapus pembatasan pengelompokan dengan memberikan `false` ke [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) dan menyimpan salinan presentasi. Pengaturan kunci lainnya dibiarkan tidak berubah.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ProtectedSample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Kesimpulan**

Aspose.Slides for Android via Java memungkinkan Anda membatasi operasi penyuntingan tertentu pada bentuk individu atau menerapkan pembatasan yang sama pada seluruh slide. Pilih kunci yang didukung oleh masing‑masing tipe bentuk, dan setel nilainya menjadi `false` ketika Anda perlu menghapus pembatasan tersebut.

## **FAQ**

**Apakah saya dapat menggabungkan kunci bentuk dan perlindungan kata sandi dalam presentasi yang sama?**

Ya. Kunci bentuk membatasi operasi penyuntingan tertentu, sementara [perlindungan kata sandi](/slides/id/androidjava/password-protected-presentation/) dapat membatasi pembukaan atau modifikasi presentasi. Anda dapat menggunakan keduanya dalam file yang sama.

**Apakah saya dapat membatasi penyuntingan pada slide tertentu tanpa memengaruhi yang lain?**

Ya. Terapkan kunci hanya pada bentuk di slide yang dipilih. Hal ini tidak mengubah pengaturan kunci pada slide lain.

**Bagaimana saya dapat menerapkan kunci pada bentuk individu di dalam grup?**

Iterasi melalui koleksi yang dikembalikan oleh metode [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) grup dan terapkan kunci yang sesuai pada setiap bentuk anak. Ulangi ini untuk setiap grup bersarang. Contoh di atas hanya memproses koleksi bentuk slide, sehingga tidak menetapkan kunci pada anggota grup individu.