---
title: Batasi Pengeditan Presentasi dengan Kunci Bentuk di Node.js
linktitle: Batasi Pengeditan Presentasi
type: docs
weight: 60
url: /id/nodejs-java/applying-protection-to-presentation/
keywords:
- mencegah pengeditan
- melindungi dari pengeditan
- kunci bentuk
- kunci posisi
- kunci pemilihan
- kunci mengubah ukuran
- kunci pengelompokan
- PowerPoint
- PPTX
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara mengunci dan membuka kunci bentuk dalam presentasi PPTX dengan Aspose.Slides untuk Node.js via Java untuk membatasi pemilihan, pergerakan, pengubahan ukuran, dan pengelompokan."
---
## **Gambaran Umum**

Penggunaan umum Aspose.Slides for Node.js via Java adalah membuat, memperbarui, dan menyimpan presentasi PowerPoint (PPTX) sebagai bagian dari alur kerja otomatis. Ketika pengguna menerima presentasi ini, membatasi perubahan pada bentuk dapat membantu menjaga tata letak dan konten yang dimaksud.

Artikel ini menjelaskan cara bentuk diatur pada slide dan cara menerapkan serta menghapus kunci bentuk dalam presentasi PPTX. Kunci ini memungkinkan Anda membatasi operasi pengeditan tertentu pada bentuk individu.

## **Komposisi Slide**

Sebuah slide presentasi terdiri dari komponen seperti autoshape, tabel, objek OLE, grup bentuk, frame gambar, frame video, connector, dan elemen lain yang digunakan untuk membangun presentasi. Dalam Aspose.Slides for Node.js via Java, setiap elemen pada slide direpresentasikan oleh objek yang mewarisi dari kelas [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/).

Berbagai tipe bentuk menyediakan opsi penguncian yang berbeda. Kelas [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) adalah kelas dasar untuk kunci bentuk. Aspose.Slides for Node.js via Java menyediakan kelas kunci berikut:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) mengunci autoshape.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) mengunci connector.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) mengunci objek grafis.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) mengunci grup bentuk.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) mengunci frame gambar.  

Untuk menerapkan kunci pada seluruh [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), iterasikan slide‑slide nya dan setel kunci yang sesuai pada setiap bentuk yang didukung.

## **Terapkan dan Hapus Perlindungan**

Kunci bentuk membatasi operasi seperti memilih, memindahkan, dan mengubah ukuran bentuk. Kunci ini tidak membuat seluruh presentasi menjadi tidak dapat diedit.

### **Terapkan Perlindungan pada Bentuk PPTX**

Aspose.Slides for Node.js via Java menyediakan kelas [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) untuk bekerja dengan bentuk pada slide.

Contoh memanggil [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked), dan [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) dengan `true` untuk autoshape, serta kunci yang setara untuk grup bentuk, connector, dan frame gambar. Connector menggunakan [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) untuk pergerakan; grup juga menggunakan [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) untuk membatasi pengelompokan.

Contoh memuat presentasi PPTX yang ada, memeriksa bentuk‑bentuk dalam koleksi bentuk tiap slide, dan menyimpan salinan dengan pembatasan ini diterapkan. Bentuk di luar empat tipe yang ditangani dibiarkan tidak berubah. Loop tidak menelusuri bentuk anak di dalam grup.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Hapus Perlindungan**

Untuk menghapus kunci bentuk, setel nilainya menjadi `false`. Contoh berikut memuat presentasi dengan kunci bentuk dan membersihkan pembatasan pemilihan, pergerakan, serta pengubahan ukuran melalui [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/), dan [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/). Ia juga menghapus pembatasan pengelompokan dengan memberikan `false` ke [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) dan menyimpan salinan presentasi. Pengaturan kunci lainnya dibiarkan tidak berubah.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("ProtectedSample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Kesimpulan**

Aspose.Slides for Node.js via Java memungkinkan Anda membatasi operasi pengeditan tertentu pada bentuk individu atau menerapkan pembatasan yang sama di seluruh slide. Pilih kunci yang didukung oleh tiap tipe bentuk, dan setel nilainya ke `false` ketika Anda perlu menghapus pembatasan tersebut.

## **FAQ**

**Apakah saya dapat menggabungkan kunci bentuk dan perlindungan kata sandi dalam presentasi yang sama?**

Ya. Kunci bentuk membatasi operasi pengeditan tertentu, sementara [password protection](/slides/id/nodejs-java/password-protected-presentation/) dapat membatasi pembukaan atau modifikasi presentasi. Anda dapat menggunakan keduanya dalam satu file.

**Apakah saya dapat membatasi pengeditan pada slide tertentu tanpa memengaruhi slide lainnya?**

Ya. Terapkan kunci hanya pada bentuk di slide yang dipilih. Ini tidak mengubah pengaturan kunci pada slide lain.

**Bagaimana cara menerapkan kunci pada bentuk individual di dalam grup?**

Iterasikan koleksi yang dikembalikan oleh metode [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) grup dan terapkan kunci yang sesuai pada setiap bentuk anak. Ulangi proses ini untuk setiap grup bersarang. Contoh di atas hanya memproses koleksi bentuk slide, sehingga tidak mengatur kunci pada anggota grup secara individual.