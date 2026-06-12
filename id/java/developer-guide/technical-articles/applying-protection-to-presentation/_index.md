---
title: "Mencegah Pengeditan Presentasi dengan Kunci Shape"
linktitle: "Mencegah Pengeditan Presentasi"
type: docs
weight: 60
url: /id/java/applying-protection-to-presentation/
keywords:
- mencegah pengeditan
- melindungi dari pengeditan
- kunci shape
- kunci posisi
- kunci pemilihan
- kunci ukuran
- kunci pengelompokan
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Temukan bagaimana Aspose.Slides untuk Java mengunci atau membuka kunci shape dalam file PPT, PPTX, dan ODP, mengamankan presentasi sambil memungkinkan pengeditan terkontrol dan pengiriman lebih cepat."
---
## **Latar Belakang**

Penggunaan umum Aspose.Slides adalah untuk membuat, memperbarui, dan menyimpan presentasi Microsoft PowerPoint (PPTX) sebagai bagian dari alur kerja otomatis. Pengguna aplikasi yang menggunakan Aspose.Slides dengan cara ini memiliki akses ke presentasi yang dihasilkan, sehingga melindungi mereka dari pengeditan menjadi perhatian umum. Penting agar presentasi yang dibuat secara otomatis mempertahankan format dan konten aslinya.

Artikel ini menjelaskan cara struktur presentasi dan slide serta bagaimana Aspose.Slides untuk Java dapat menerapkan perlindungan pada sebuah presentasi dan kemudian menghapusnya. Artikel ini memberikan pengembang cara mengendalikan bagaimana presentasi yang dihasilkan aplikasi mereka digunakan.

## **Komposisi Slide**

Slide presentasi terdiri dari komponen seperti autoshape, tabel, objek OLE, shape yang dikelompokkan, bingkai gambar, bingkai video, konektor, dan elemen lain yang digunakan untuk membangun presentasi. Dalam Aspose.Slides untuk Java, setiap elemen pada slide diwakili oleh objek yang mengimplementasikan antarmuka [IShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/) atau mewarisi dari kelas yang melakukannya.

Struktur PPTX bersifat kompleks, sehingga tidak seperti PPT, di mana kunci generik dapat digunakan untuk semua tipe shape, tipe shape yang berbeda memerlukan kunci yang berbeda. Antarmuka [IBaseShapeLock](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibaseshapelock/) adalah kelas kunci generik untuk PPTX. Jenis kunci berikut didukung dalam Aspose.Slides untuk Java untuk PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshapelock/) mengunci autoshape.  
- [IConnectorLock](https://reference.aspose.com/slides/id/java/com.aspose.slides/iconnectorlock/) mengunci shape konektor.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/id/java/com.aspose.slides/igraphicalobjectlock/) mengunci objek grafik.  
- [IGroupShapeLock](https://reference.aspose.com/slides/id/java/com.aspose.slides/igroupshapelock/) mengunci grup shape.  
- [IPictureFrameLock](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipictureframelock/) mengunci bingkai gambar.  

Setiap tindakan yang dilakukan pada semua objek shape dalam objek [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) diterapkan pada seluruh presentasi.

## **Menerapkan dan Menghapus Perlindungan**

Menerapkan perlindungan memastikan bahwa sebuah presentasi tidak dapat diedit. Ini merupakan teknik yang berguna untuk melindungi konten presentasi.

### **Terapkan Perlindungan pada Shape PPTX**

Aspose.Slides untuk Java menyediakan antarmuka [IShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/) untuk bekerja dengan shape pada slide.

Seperti disebutkan sebelumnya, setiap kelas shape memiliki kelas shape‑lock yang terkait untuk perlindungan. Artikel ini berfokus pada kunci NoSelect, NoMove, dan NoResize. Kunci ini memastikan shape tidak dapat dipilih (melalui klik mouse atau metode seleksi lainnya) dan tidak dapat dipindahkan atau diubah ukurannya.

Contoh kode berikut menerapkan perlindungan pada semua tipe shape dalam sebuah presentasi.

```java
// Instansiasi kelas Presentation yang mewakili file PPTX.
Presentation presentation = new Presentation("Sample.pptx");

// Menelusuri semua slide dalam presentasi.
for (ISlide slide : presentation.getSlides()) {

    // Menelusuri semua shape dalam slide.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // Melakukan type-casting shape menjadi autoshape dan memperoleh kunci shape-nya.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(true);
            autoShapeLock.setSelectLocked(true);
            autoShapeLock.setSizeLocked(true);
        } else if (shape instanceof IGroupShape) {
            // Melakukan type-casting shape menjadi grup shape dan memperoleh kunci shape-nya.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(true);
            groupShapeLock.setPositionLocked(true);
            groupShapeLock.setSelectLocked(true);
            groupShapeLock.setSizeLocked(true);
        } else if (shape instanceof IConnector) {
            // Melakukan type-casting shape menjadi shape konektor dan memperoleh kunci shape-nya.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(true);
            connectorShapeLock.setSelectLocked(true);
            connectorShapeLock.setSizeLocked(true);
        } else if (shape instanceof IPictureFrame) {
            // Melakukan type-casting shape menjadi picture frame dan memperoleh kunci shape-nya.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(true);
            pictureFrameLock.setSelectLocked(true);
            pictureFrameLock.setSizeLocked(true);
        }
    }
}

// Menyimpan file presentasi.
presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Hapus Perlindungan**

Untuk membuka kunci sebuah shape, atur nilai kunci yang diterapkan menjadi `false`. Contoh kode berikut memperlihatkan cara membuka kunci shape dalam presentasi yang terkunci.

```java
// Instansiasi kelas Presentation yang mewakili file PPTX.
Presentation presentation = new Presentation("ProtectedSample.pptx");

// Menelusuri semua slide dalam presentasi.
for (ISlide slide : presentation.getSlides()) {

    // Menelusuri semua shape dalam slide.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // Melakukan type-casting shape menjadi autoshape dan memperoleh kunci shape-nya.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(false);
            autoShapeLock.setSelectLocked(false);
            autoShapeLock.setSizeLocked(false);
        } else if (shape instanceof IGroupShape) {
            // Melakukan type-casting shape menjadi grup shape dan memperoleh kunci shape-nya.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(false);
            groupShapeLock.setPositionLocked(false);
            groupShapeLock.setSelectLocked(false);
            groupShapeLock.setSizeLocked(false);
        } else if (shape instanceof IConnector) {
            // Melakukan type-casting shape menjadi shape konektor dan memperoleh kunci shape-nya.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(false);
            connectorShapeLock.setSelectLocked(false);
            connectorShapeLock.setSizeLocked(false);
        } else if (shape instanceof IPictureFrame) {
            // Melakukan type-casting shape menjadi picture frame dan memperoleh kunci shape-nya.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(false);
            pictureFrameLock.setSelectLocked(false);
            pictureFrameLock.setSizeLocked(false);
        }
    }
}

// Menyimpan file presentasi.
presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Kesimpulan**

Aspose.Slides menawarkan beberapa opsi untuk melindungi shape dalam sebuah presentasi. Anda dapat mengunci shape secara individual atau mengiterasi semua shape dalam presentasi dan mengunci masing‑masing untuk secara efektif mengamankan seluruh file. Anda dapat menghapus perlindungan dengan mengatur nilai kunci menjadi `false`.

## **Tanya Jawab**

**Apakah saya dapat menggabungkan kunci shape dan perlindungan kata sandi dalam satu presentasi?**

Ya. Kunci membatasi pengeditan objek di dalam file, sementara [password protection](/slides/id/java/password-protected-presentation/) mengontrol akses untuk membuka dan/atau menyimpan perubahan. Mekanisme ini saling melengkapi dan bekerja bersama.

**Apakah saya dapat membatasi pengeditan pada slide tertentu tanpa memengaruhi yang lain?**

Ya. Terapkan kunci pada shape di slide yang dipilih; slide lainnya tetap dapat diedit.

**Apakah kunci shape berlaku untuk objek yang dikelompokkan dan konektor?**

Ya. Jenis kunci khusus didukung untuk grup, konektor, objek grafis, dan jenis shape lainnya.