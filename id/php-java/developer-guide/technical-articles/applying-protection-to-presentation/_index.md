---
title: Batasi Pengeditan Presentasi dengan Kunci Shape di PHP
linktitle: Batasi Pengeditan Presentasi
type: docs
weight: 60
url: /id/php-java/applying-protection-to-presentation/
keywords:
- mencegah pengeditan
- melindungi dari pengeditan
- kunci shape
- kunci posisi
- kunci seleksi
- kunci pengubahan ukuran
- kunci pengelompokan
- PowerPoint
- PPTX
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara mengunci dan membuka kunci shape dalam presentasi PPTX dengan Aspose.Slides for PHP via Java untuk membatasi seleksi, pergerakan, pengubahan ukuran, dan pengelompokan."
---
## **Gambaran Umum**

Penggunaan umum Aspose.Slides for PHP via Java adalah untuk membuat, memperbarui, dan menyimpan presentasi PowerPoint (PPTX) sebagai bagian dari alur kerja otomatis. Ketika pengguna menerima presentasi ini, membatasi perubahan pada shape dapat membantu mempertahankan tata letak dan konten yang dimaksud.

Artikel ini menjelaskan bagaimana shape diatur pada slide dan cara menerapkan serta menghapus kunci shape dalam presentasi PPTX. Kunci ini memungkinkan Anda membatasi operasi pengeditan tertentu pada shape individu.

## **Komposisi Slide**

Sebuah slide presentasi terdiri dari komponen seperti autoshape, tabel, objek OLE, shape yang dikelompokkan, bingkai gambar, bingkai video, konektor, dan elemen lain yang digunakan untuk membangun presentasi. Dalam Aspose.Slides for PHP via Java, setiap elemen pada slide diwakili oleh objek yang mewarisi dari kelas [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) .

Berbagai tipe shape memiliki opsi kunci yang berbeda. Kelas [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) adalah kelas dasar untuk kunci shape. Aspose.Slides for PHP via Java menyediakan kelas kunci berikut:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) mengunci autoshape.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) mengunci shape konektor.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) mengunci objek grafik.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) mengunci shape grup.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) mengunci bingkai gambar.  

Untuk menerapkan kunci pada seluruh [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), iterasikan slide-nya dan tetapkan kunci yang sesuai pada setiap shape yang didukung.

## **Terapkan dan Hapus Perlindungan**

Kunci shape membatasi operasi seperti memilih, memindahkan, dan mengubah ukuran shape. Kunci ini tidak membuat seluruh presentasi tidak dapat diedit.

### **Terapkan Perlindungan pada Shape PPTX**

Aspose.Slides for PHP via Java menyediakan kelas [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) untuk bekerja dengan shape pada slide.

Contoh memanggil [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked), dan [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) dengan `true` untuk autoshape, serta kunci yang setara untuk shape grup, konektor, dan bingkai gambar. Konektor menggunakan [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) untuk pergerakan; grup juga menggunakan [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) untuk membatasi pengelompokan.

Contoh memuat presentasi PPTX yang ada, memeriksa shape dalam koleksi shape setiap slide, dan menyimpan salinan dengan pembatasan ini diterapkan. Shape di luar empat tipe yang ditangani dibiarkan tidak berubah. Loop tidak menelusuri shape anak di dalam grup.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(true);
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            }
        }
    }

    $presentation->save("ProtectedSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Hapus Perlindungan**

Untuk menghapus kunci shape, setel nilainya menjadi `false`. Contoh berikut memuat presentasi dengan kunci shape dan menghapus pembatasan pemilihan, pergerakan, serta pengubahan ukuran melalui [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/), dan [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/). Ini juga menghapus pembatasan pengelompokan dengan memberikan `false` ke [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) dan menyimpan salinan presentasi. Pengaturan kunci lain dibiarkan tidak berubah.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ProtectedSample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(false);
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            }
        }
    }

    $presentation->save("RemovedProtectionSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Kesimpulan**

Aspose.Slides for PHP via Java memungkinkan Anda membatasi operasi pengeditan tertentu pada shape individu atau menerapkan pembatasan yang sama pada seluruh slide. Pilih kunci yang didukung oleh masing-masing tipe shape, dan setel nilainya menjadi `false` ketika Anda perlu menghapus pembatasan tersebut.

## **FAQ**

**Apakah saya dapat menggabungkan kunci shape dan perlindungan kata sandi dalam presentasi yang sama?**

Ya. Kunci shape membatasi operasi pengeditan tertentu, sementara [password protection](/slides/id/php-java/password-protected-presentation/) dapat membatasi pembukaan atau pengubahan presentasi. Anda dapat menggunakan keduanya dalam file yang sama.

**Apakah saya dapat membatasi pengeditan pada slide tertentu tanpa memengaruhi slide lain?**

Ya. Terapkan kunci hanya pada shape di slide yang dipilih. Ini tidak mengubah pengaturan kunci pada slide lain.

**Bagaimana cara saya menerapkan kunci pada shape individu di dalam grup?**

Iterasikan koleksi yang dikembalikan oleh metode [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) milik grup dan terapkan kunci yang sesuai pada setiap shape anak. Ulangi ini untuk setiap grup bersarang. Contoh di atas hanya memproses koleksi shape slide, sehingga tidak menetapkan kunci pada anggota grup secara individu.