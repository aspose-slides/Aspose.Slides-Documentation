---
title: Batasi Penyuntingan Presentasi dengan Kunci Shape di PHP
linktitle: Batasi Penyuntingan Presentasi
type: docs
weight: 60
url: /id/php-java/applying-protection-to-presentation/
keywords:
- mencegah penyuntingan
- melindungi dari penyuntingan
- kunci shape
- kunci posisi
- kunci pemilihan
- kunci perubahan ukuran
- kunci pengelompokan
- PowerPoint
- PPTX
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara mengunci dan membuka kunci shape dalam presentasi PPTX dengan Aspose.Slides untuk PHP via Java guna membatasi pemilihan, pergerakan, perubahan ukuran, dan pengelompokan."
---
## **Gambaran Umum**

Penggunaan umum Aspose.Slides for PHP via Java adalah untuk membuat, memperbarui, dan menyimpan presentasi PowerPoint (PPTX) sebagai bagian dari alur kerja otomatis. Ketika pengguna menerima presentasi ini, pembatasan perubahan pada shape dapat membantu menjaga tata letak dan konten yang dimaksud.

Artikel ini menjelaskan bagaimana shape diatur pada slide dan cara menerapkan serta menghapus kunci shape dalam presentasi PPTX. Kunci ini memungkinkan Anda membatasi operasi penyuntingan tertentu pada setiap shape.

## **Komposisi Slide**

Sebuah slide presentasi terdiri dari komponen seperti autoshapes, tabel, objek OLE, shape yang dikelompokkan, bingkai gambar, bingkai video, konektor, dan elemen lain yang digunakan untuk membangun presentasi. Dalam Aspose.Slides for PHP via Java, setiap elemen pada slide direpresentasikan oleh objek yang mewarisi dari kelas [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/).

Berbagai tipe shape memiliki opsi kunci yang berbeda. Kelas [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) adalah kelas dasar untuk kunci shape. Aspose.Slides for PHP via Java menyediakan kelas kunci berikut:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) mengunci autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) mengunci shape konektor.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) mengunci objek grafis.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) mengunci shape grup.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) mengunci bingkai gambar.  

Untuk menerapkan kunci pada seluruh [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), iterasikan slide‑nya dan tetapkan kunci yang sesuai pada setiap shape yang didukung.

## **Menerapkan dan Menghapus Perlindungan**

Editor presentasi yang kompatibel menggunakan kunci shape untuk membatasi operasi penyuntingan individual. Enkripsi file dan perlindungan penulisan tingkat dokumen merupakan [pengaturan perlindungan presentasi](/slides/id/php-java/password-protected-presentation/).

### **Menerapkan Perlindungan pada Shape PPTX**

Aspose.Slides for PHP via Java menyediakan kelas [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) untuk bekerja dengan shape pada slide.

Contoh memanggil [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked), dan [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) dengan nilai `true` untuk autoshapes, serta kunci setara untuk shape grup, konektor, dan bingkai gambar. Konektor menggunakan [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) untuk pergerakan; grup juga menggunakan [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) untuk membatasi pengelompokan.

Contoh memuat presentasi PPTX yang ada, memeriksa shape dalam koleksi shape tiap slide, dan menyimpan salinan dengan pembatasan ini diterapkan. Shape di luar empat tipe yang ditangani dibiarkan tidak berubah. Loop tidak menelusuri shape anak di dalam grup.

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

### **Menghapus Perlindungan**

Untuk menghapus kunci shape, setel nilainya menjadi `false`. Contoh berikut memuat presentasi dengan kunci shape dan menghapus pembatasan pemilihan, pergerakan, serta perubahan ukuran melalui [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/), dan [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/). Ia juga menghapus pembatasan pengelompokan dengan memberikan `false` ke [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) dan menyimpan salinan presentasi. Pengaturan kunci lain dibiarkan tidak berubah.

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

### **Mengawetkan Pemotongan Gambar**

Letakkan foto bernama `photo.jpg` di direktori kerja. Contoh memotong 12 % dari kiri dan 8 % dari kanan, kemudian memanggil [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked) pada kunci bingkai gambar. Memberikan `true` membatasi pemotongan lebih lanjut dan mempertahankan pemotongan yang ada.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $image = Images::fromFile("photo.jpg");
    try {
        $photo = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $pictureFrame = $shapes->addPictureFrame(ShapeType::Rectangle, 20, 30, 270, 160, $photo);
    $pictureFrame->getPictureFormat()->setCropLeft(12);
    $pictureFrame->getPictureFormat()->setCropRight(8);

    $pictureFrameLock = $pictureFrame->getPictureFrameLock();
    $pictureFrameLock->setAspectRatioLocked(false);
    $pictureFrameLock->setCropLocked(true);

    $presentation->save("PictureLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`PictureLocked.pptx` menyimpan kunci pemotongan sebagai `true`. Di PowerPoint, perintah **Crop** dinonaktifkan ketika foto dipilih.

### **Menjaga Diagram Tetap Tergrup**

Contoh mengelompokkan sebuah persegi panjang dan panah, kemudian memanggil [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) pada kunci grup untuk menjaga komponen diagram tetap bersama. Penyuntingan lain, seperti memindahkan grup atau mengubah isi suatu komponen, tetap tersedia.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $groupShape = $shapes->addGroupShape();
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 70, 90, 50);
    $groupShape->getShapes()->addAutoShape(ShapeType::RightArrow, 190, 80, 60, 30);
    $groupShape->getGroupShapeLock()->setUngroupingLocked(true);

    $presentation->save("DiagramLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`DiagramLocked.pptx` menyimpan kunci pembatalan pengelompokan sebagai `true`. Di PowerPoint, perintah **Ungroup** dinonaktifkan ketika seluruh diagram dipilih.

### **Melaporkan Kunci Shape yang Ada**

Untuk meninjau sebuah templat, buka dan baca objek kunci untuk setiap shape. Metode [getNoLocks](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/#getNoLocks) mengembalikan `true` ketika semua flag pada objek tersebut dinonaktifkan dan `false` ketika setidaknya satu diaktifkan. Sebuah grup dan anak‑anaknya memiliki objek kunci terpisah, jadi periksa anak‑anaknya meskipun grup tidak memiliki kunci.

Contoh ini memeriksa pergerakan untuk autoshapes, bingkai gambar, dan grup. Ia juga memeriksa pemotongan untuk gambar serta pembatalan pengelompokan untuk grup. Laporan mencantumkan flag yang diaktifkan yang dikenalnya dan menandai tipe shape yang tidak ia inspeksi.

```php
use aspose\slides\Presentation;

function reportShapeLocks($shapes, $slideNumber, $prefix = "") {
    foreach ($shapes->toArray() as $shape) {
        $path = $prefix . java_values($shape->getName());
        $type = java_values($shape->getClass()->getSimpleName());
        $label = "Slide $slideNumber | $path | $type";
        $flags = [];
        $isGroup = java_instanceof($shape, java("com.aspose.slides.IGroupShape"));

        if ($isGroup) {
            $lock = $shape->getGroupShapeLock();
            if (java_values($lock->getUngroupingLocked())) {
                $flags[] = "UngroupingLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IPictureFrame"))) {
            $lock = $shape->getPictureFrameLock();
            if (java_values($lock->getCropLocked())) {
                $flags[] = "CropLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IAutoShape"))) {
            $lock = $shape->getAutoShapeLock();
        } else {
            echo "$label | Uninspected", PHP_EOL;
            continue;
        }

        if (java_values($lock->getPositionLocked())) {
            $flags[] = "PositionLocked";
        }
        if (!java_values($lock->getNoLocks())) {
            $restrictions = $flags ? implode(", ", $flags) : "Active flag not identified";
            echo "$label | $restrictions", PHP_EOL;
        }

        if ($isGroup) {
            reportShapeLocks($shape->getShapes(), $slideNumber, $path . "/");
        }
    }
}

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        reportShapeLocks($slide->getShapes(), java_values($slide->getSlideNumber()));
    }
} finally {
    $presentation->dispose();
}
```

Misalkan slide 1 dari `Sample.pptx` berisi grup bernama `Layout` dengan pembatalan pengelompokan terkunci, sebuah gambar bernama `Photo` di dalamnya dengan pemotongan terkunci, dan sebuah persegi panjang tidak terkunci bernama `Free`. Laporan melewatkan `Free` dan mencetak dua baris berikut:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Laporan membaca flag penyuntingan tingkat shape yang disimpan tanpa mengubahnya atau menyimpan presentasi. Perlindungan penulisan tingkat dokumen merupakan pengaturan terpisah, dan penegakan setiap flag tergantung pada editor.

### **Kesimpulan**

Aspose.Slides for PHP via Java memungkinkan Anda membatasi operasi penyuntingan tertentu pada shape individual atau menerapkan pembatasan yang sama pada seluruh slide. Pilih kunci yang didukung oleh tiap tipe shape, dan setel nilai mereka ke `false` ketika Anda perlu menghapus pembatasan tersebut.

## **FAQ**

**Apakah saya dapat menggabungkan kunci shape dan perlindungan kata sandi dalam satu presentasi?**

Ya. Kunci shape membatasi operasi penyuntingan tertentu, sementara [perlindungan kata sandi](/slides/id/php-java/password-protected-presentation/) dapat membatasi pembukaan atau modifikasi presentasi. Anda dapat menggunakan keduanya dalam satu file.

**Apakah saya dapat membatasi penyuntingan pada slide tertentu tanpa memengaruhi slide lain?**

Ya. Terapkan kunci hanya pada shape di slide yang dipilih. Ini tidak mengubah pengaturan kunci pada slide lain.

**Bagaimana cara menerapkan kunci pada shape individual di dalam sebuah grup?**

Iterasikan koleksi yang dikembalikan oleh metode [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) pada grup dan terapkan kunci yang sesuai pada setiap shape anak. Ulangi proses ini untuk grup bersarang, mengikuti penelusuran pada contoh pelaporan.