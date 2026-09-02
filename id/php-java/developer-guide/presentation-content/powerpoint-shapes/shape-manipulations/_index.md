---
title: Kelola Bentuk Presentasi dalam PHP
linktitle: Manipulasi Bentuk
type: docs
weight: 40
url: /id/php-java/shape-manipulations/
keywords:
- Bentuk PowerPoint
- bentuk presentasi
- bentuk pada slide
- temukan bentuk
- gandakan bentuk
- hapus bentuk
- sembunyikan bentuk
- ubah urutan bentuk
- dapatkan ID bentuk interop
- teks alternatif bentuk
- format tata letak bentuk
- bentuk sebagai SVG
- bentuk ke SVG
- selaraskan bentuk
- balikkan bentuk
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara mengidentifikasi, menggandakan, menghapus, menyembunyikan, mengubah urutan, mengekspor, menyelaraskan, dan membalikkan bentuk presentasi dengan Aspose.Slides untuk PHP via Java."
---
## **Ringkasan**

Aspose.Slides for PHP via Java merepresentasikan bentuk pada sebuah slide sebagai [ShapeCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/) yang terurut. Koleksi ini sekaligus tempat Anda menemukan dan memodifikasi bentuk serta sumber urutan tumpukan mereka: indeks `0` adalah bentuk paling belakang, sedangkan indeks terakhir adalah bentuk paling depan.

Artikel ini mengikuti model tersebut. Pertama dijelaskan cara mengidentifikasi bentuk secara andal, kemudian ditunjukkan cara menggandakan, menghapus, menyembunyikan, dan mengubah urutan bentuk. Bagian akhir mencakup pemformatan tingkat tata letak, ekspor SVG, penyelarasan, dan pengaturan pembalikan. Setiap contoh bersifat independen, sehingga Anda dapat menggunakan hanya operasi yang diperlukan dalam alur kerja Anda.

## **Identifikasi dan Temukan Bentuk**

Indeks koleksi berguna saat memproses file yang sudah diketahui, tetapi bukan pengenal yang stabil. Menambahkan, menghapus, atau mengubah urutan bentuk dapat mengubah indeksnya. Pilih pengenal sesuai cara presentasi dibuat dan dipelihara:

- [Name](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getname/) berguna untuk templat yang dikendalikan pengembang dan mudah diperiksa di Panel Seleksi PowerPoint. Nama dapat diedit dan tidak dijamin unik, sehingga tetapkan konvensi penamaan bila kode bergantung padanya.
- [AlternativeText](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getalternativetext/) berguna ketika deskripsi aksesibilitas atau tag yang diberikan penulis sudah mengidentifikasi bentuk. Teks ini terlihat oleh pengguna, dapat dilokalisasi atau ditulis ulang untuk aksesibilitas, dan tidak dijamin unik. Jangan diam‑diam memanfaatkan teks aksesibilitas yang bermakna sebagai kunci basis data.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getofficeinteropshapeid/) adalah pengenal baca‑saja yang unik dalam satu slide dan sesuai dengan ID bentuk yang digunakan oleh interop PowerPoint. Gunakan ketika berintegrasi dengan PowerPoint atau saat Anda memerlukan referensi yang tidak ambigu selama masa hidup sebuah bentuk. Bentuk yang digandakan atau dibuat kembali adalah bentuk yang berbeda dan menerima ID sendiri.

Metode terkait [Shape::getUniqueId](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getuniqueid/) mengembalikan pengenal dengan cakupan presentasi, tetapi pengenal tersebut ditujukan untuk add‑in dan dapat dipertukarkan kembali. Tidak boleh diperlakukan sebagai kunci eksternal permanen. Jika identitas jangka panjang penting, simpan pemetaan dalam data aplikasi dan validasi bahwa bentuk yang diharapkan masih ada.

Contoh berikut mencari berdasarkan nama dengan perbandingan tepat dan melaporkan ID interop berskala slide. Ketika templat tidak berisi bentuk yang diharapkan, kode melaporkan hasil itu alih‑alih melanjutkan dengan objek yang salah.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "RevenueChart") {
            $targetShape = $shape;
            break;
        }
    }

    if ($targetShape === null) {
        echo "The shape 'RevenueChart' was not found on slide 1." . PHP_EOL;
    } else {
        $shapeName = java_values($targetShape->getName());
        $interopId = java_values($targetShape->getOfficeInteropShapeId());
        echo "Found " . $shapeName . "; interop ID: " . $interopId . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Ketika suatu operasi khusus untuk tipe bentuk, periksa kelas runtime sebelum menggunakan anggota spesifik tipe. Contoh ini memperbarui teks dan teks alternatif hanya bila objek bernama merupakan [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $candidate = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "StatusLabel") {
            $candidate = $shape;
            break;
        }
    }

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if ($candidate !== null && java_instanceof($candidate, $autoShapeClass)) {
        $candidate->getTextFrame()->setText("Approved");
        $candidate->setAlternativeText("Approval status: approved");
        $presentation->save("identified-shape.pptx", SaveFormat::Pptx);
    } else {
        echo "'StatusLabel' is missing or is not an AutoShape." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Modifikasi Koleksi Bentuk**

Metode tambah, gandakan, hapus, dan ubah urutan beroperasi pada koleksi secara langsung. Jika suatu operasi mengubah jumlah atau urutan bentuk, jangan terus mengandalkan indeks yang diambil sebelum operasi tersebut.

### **Gandakan Sebuah Bentuk**

[ShapeCollection::addClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/addclone/) membuat salinan independen dan menambahkannya ke koleksi target. [ShapeCollection::insertClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/insertclone/) juga membuat salinan tetapi menempatkannya pada indeks z‑order yang ditentukan. Overload yang menerima koordinat memindahkan salinan tanpa mengubah ukuran; overload dengan lebar dan tinggi dapat mengubah ukuran pula.

Contoh membuat slide tujuan, menggandakan sebuah persegi panjang berlabel ke depan, dan menyisipkan gandaan kedua di belakang. Perubahan pada salah satu gandaan tidak memodifikasi bentuk sumber.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $sourceSlide = $presentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
    $sourceShape->setName("SourceLabel");
    $sourceShape->getTextFrame()->setText("Source");

    $blankLayout = $presentation->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destinationSlide = $presentation->getSlides()->addEmptySlide($blankLayout);

    $frontCloneShape = $destinationSlide->getShapes()->addClone($sourceShape, 80, 80);
    $frontCloneShape->setName("FrontClone");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if (java_instanceof($frontCloneShape, $autoShapeClass)) {
        $frontCloneShape->getTextFrame()->setText("Front clone");
    } else {
        echo "The front clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $backCloneShape = $destinationSlide->getShapes()->insertClone(0, $sourceShape, 80, 180);
    $backCloneShape->setName("BackClone");
    if (java_instanceof($backCloneShape, $autoShapeClass)) {
        $backCloneShape->getTextFrame()->setText("Back clone");
    } else {
        echo "The back clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $presentation->save("cloned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Menggandakan menyalin konten dan pemformatan bentuk, termasuk nama dan teks alternatifnya. Tetapkan pengenal logis baru pada gandaan ketika nilai tersebut harus unik. Sumber daya yang digunakan oleh bentuk kompleks dikelola oleh presentasi, tetapi gandaan tetap menjadi item koleksi baru dengan identitas bentuk baru.

### **Hapus Bentuk**

[ShapeCollection::remove](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/remove/) menghapus objek bentuk tertentu dari koleksinya. Saat menghapus beberapa kecocokan selama iterasi berindeks, lakukan penelusuran dari akhir supaya setiap indeks yang tersisa tetap valid.

Contoh ini menghapus setiap bentuk dengan nama yang ditentukan. Ia membaca bentuk pada indeks saat ini, bukan item koleksi tetap, dan tidak melakukan cast bentuk secara tidak perlu.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $keepShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
    $keepShape->setName("Keep");

    $firstTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
    $firstTemporaryShape->setName("Temporary");

    $secondTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
    $secondTemporaryShape->setName("Temporary");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = $shapeCount - 1; $shapeIndex >= 0; $shapeIndex--) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "Temporary") {
            $slide->getShapes()->remove($shape);
        }
    }

    $presentation->save("removed-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Setelah penghapusan, jumlah bentuk dan indeks bentuk berikutnya berubah. Referensi ke bentuk yang tidak terpengaruh tetap lebih dapat diandalkan daripada indeks yang disimpan. Pertimbangkan juga penghubung, animasi, dan fitur presentasi lain yang mungkin merujuk ke objek yang dihapus; menghapus bentuk yang terlihat dapat mengubah lebih dari sekadar tampilan slide.

### **Sembunyikan Sebuah Bentuk**

Menetapkan [Shape::setHidden](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/sethidden/) ke `true` mempertahankan bentuk dalam koleksi tetapi mencegahnya muncul dalam tayangan slide normal. Indeks, pemformatan, dan kontennya tetap tersedia bagi kode, sehingga menyembunyikan cocok untuk elemen opsional yang mungkin dipulihkan kemudian.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $visibleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
    $visibleShape->setName("VisibleLabel");

    $optionalShape = $slide->getShapes()->addAutoShape(ShapeType::Moon, 240, 40, 100, 100);
    $optionalShape->setName("OptionalDecoration");

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "OptionalDecoration") {
            $shape->setHidden(true);
        }
    }

    $presentation->save("hidden-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Menyembunyikan bukan menghapus atau mengamankan. Objek masih dapat ditemukan dan ditampilkan kembali oleh pengguna atau kode, dan tetap menjadi bagian dari file presentasi.

### **Ubah Z‑Order**

Bentuk yang tumpang tindih digambar sesuai urutan koleksi. [ShapeCollection::reorder](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/reorder/) memindahkan bentuk yang ada ke indeks target tanpa menggandakannya. Indeks `0` adalah belakang; `size() - 1` adalah depan.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $blueRectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
    $blueRectangle->setName("BlueRectangle");
    $blueRectangle->getFillFormat()->setFillType(FillType::Solid);
    $blueRectangle->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 255));

    $orangeEllipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
    $orangeEllipse->setName("OrangeEllipse");
    $orangeEllipse->getFillFormat()->setFillType(FillType::Solid);
    $orangeEllipse->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $frontIndex = java_values($slide->getShapes()->size()) - 1;
    $slide->getShapes()->reorder($frontIndex, $blueRectangle);
    $presentation->save("reordered-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Persegi panjang dibuat dulu dan awalnya berada di belakang elips. Memindahkannya ke indeks akhir menempatkannya di depan. Selesaikan urutan z setelah menambah atau menggandakan semua bentuk terkait, karena operasi tersebut menambah atau menyisipkan item koleksi baru dan dapat mengubah tumpukan yang diinginkan.

## **Periksa Bentuk pada Slide Tata Letak**

Slide normal, slide tata letak, dan slide master memiliki koleksi bentuk terpisah. Bentuk dalam koleksi tata letak bukan objek yang sama dengan bentuk yang diposisikan serupa pada slide normal. Periksa bentuk tata letak ketika Anda perlu memahami atau mengubah pemformatan yang disediakan oleh tata letak.

Contoh berikut membaca setiap [FillFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getfillformat/) dan [LineFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getlineformat/) bentuk tata letak tanpa mengasumsikan setiap bentuk adalah `AutoShape`.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getLayoutSlides();
    $layoutSlideCount = java_values($layoutSlides->size());
    for ($layoutIndex = 0; $layoutIndex < $layoutSlideCount; $layoutIndex++) {
        $layoutSlide = $layoutSlides->get_Item($layoutIndex);
        $layoutShapes = $layoutSlide->getShapes();
        $layoutShapeCount = java_values($layoutShapes->size());
        for ($shapeIndex = 0; $shapeIndex < $layoutShapeCount; $shapeIndex++) {
            $shape = $layoutShapes->get_Item($shapeIndex);
            $fillType = java_values($shape->getFillFormat()->getFillType());
            $lineWidth = java_values($shape->getLineFormat()->getWidth());
            $layoutName = java_values($layoutSlide->getName());
            $shapeName = java_values($shape->getName());
            echo $layoutName . " / " . $shapeName . ": fill=" . $fillType . ", line width=" . $lineWidth . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Mengedit tata letak dapat memengaruhi beberapa slide yang menggunakannya. Sebelum mengubah bentuk tata letak, tentukan apakah slide normal mewarisi objek tersebut atau berisi penimpaan lokal, dan uji setiap slide yang memakai tata letak itu.

## **Ekspor Bentuk ke SVG**

[Shape::writeAsSvg](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/writeassvg/) menulis konten yang dirender dari satu bentuk ke aliran. Hasilnya berisi bentuk saja, bukan latar belakang slide lengkap atau bentuk tetangga.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    if ($shapeCount === 0) {
        echo "Slide 1 does not contain a shape to export." . PHP_EOL;
    } else {
        $shape = $slide->getShapes()->get_Item(0);
        $svgStream = null;
        try {
            $svgStream = new Java("java.io.FileOutputStream", "shape.svg");
            $shape->writeAsSvg($svgStream);
        } catch (JavaException $exception) {
            echo "The SVG file could not be written: " . $exception->getMessage() . PHP_EOL;
        } finally {
            if ($svgStream !== null && !java_is_null($svgStream)) {
                $svgStream->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Biarkan presentasi tetap terbuka saat merender. Output bergantung pada pemformatan bentuk serta sumber daya seperti font dan gambar. Jika Anda memerlukan seluruh komposisi, ekspor slide alih‑alih bentuk tunggal. Pemanggil memiliki aliran dan harus menutupnya.

## **Selaraskan Bentuk**

Overload [SlideUtil::alignShapes](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideutil/alignshapes/) menyelaraskan semua bentuk atau indeks koleksi terpilih. [ShapesAlignmentType](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapesalignmenttype/) menentukan tepi, garis tengah, atau mode distribusi. Atur `alignToSlide` ke `true` untuk menggunakan tepi slide; atur ke `false` untuk menyelaraskan bentuk terpilih secara relatif satu sama lain.

Contoh ini menyelaraskan tiga bentuk ke tepi atas slide. Referensi bentuk yang dikembalikan diubah menjadi indeks saat ini tepat sebelum penyelarasan.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\ShapesAlignmentType;
use aspose\slides\SlideUtil;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
    $thirdShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
    $firstShape->setName("FirstAlignedShape");
    $secondShape->setName("SecondAlignedShape");
    $thirdShape->setName("ThirdAlignedShape");

    $shapeIndexes = [
        java_values($slide->getShapes()->indexOf($firstShape)),
        java_values($slide->getShapes()->indexOf($secondShape)),
        java_values($slide->getShapes()->indexOf($thirdShape))
    ];

    SlideUtil::alignShapes(ShapesAlignmentType::AlignTop, true, $slide, $shapeIndexes);
    $presentation->save("aligned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Penyelarasan mengubah posisi, bukan urutan z. Penyelarasan relatif biasanya memerlukan setidaknya dua bentuk, sementara distribusi horizontal atau vertikal memerlukan cukup bentuk untuk menentukan jarak. Hitung kembali indeks bila Anda memodifikasi koleksi sebelum memanggil metode.

## **Balikkan Sebuah Bentuk**

Kelas [ShapeFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapeframe/) menyimpan posisi, ukuran, pengaturan flip horizontal dan vertikal, serta rotasi. Nilai `getFlipH` dan `getFlipV` menggunakan [NullableBool](https://reference.aspose.com/slides/id/php-java/aspose.slides/nullablebool/): `True` mengaktifkan flip, `False` menonaktifkannya, dan `NotDefined` mempertahankan keadaan tak ditentukan/default.

Presentasi input di bawah ini berisi satu bentuk yang tidak dibalik.

![Bentuk sebelum dibalik](shape_to_be_flipped.png)

Contoh ini mempertahankan setiap nilai frame lain dan mengganti hanya dua pengaturan flip. Ini penting karena menetapkan [Frame](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/setframe/) baru menggantikan seluruh frame.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $frame = $shape->getFrame();

    $horizontalFlip = java_values($frame->getFlipH());
    $verticalFlip = java_values($frame->getFlipV());
    echo "Horizontal flip before change: " . $horizontalFlip . PHP_EOL;
    echo "Vertical flip before change: " . $verticalFlip . PHP_EOL;

    $shape->setFrame(new ShapeFrame($frame->getX(), $frame->getY(), $frame->getWidth(), $frame->getHeight(), NullableBool::True, NullableBool::True, $frame->getRotation()));

    $presentation->save("flipped-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Bentuk yang disimpan tercermin secara horizontal dan vertikal sambil mempertahankan posisi, ukuran, dan rotasinya.

![Bentuk setelah dibalik](flipped_shape.png)

## **FAQ**

**Haruskah saya menggunakan indeks koleksi sebagai pengenal bentuk?**

Hanya untuk pemrosesan singkat ketika koleksi tidak akan berubah sebelum indeks digunakan. Lebih baik gunakan konvensi `Name` atau `AlternativeText` yang tervalidasi untuk templat yang dibuat, atau `OfficeInteropShapeId` untuk pekerjaan interop berskala slide.

**Apakah menyembunyikan bentuk menghapusnya dari urutan z?**

Tidak. Bentuk tersembunyi tetap berada dalam koleksi pada indeks yang sama. Bentuk tersebut dapat ditemukan, diubah urutannya, diedit, atau dibuat terlihat kembali.

**Mengapa bentuk yang digandakan muncul di depan bentuk lain?**

`addClone` menambahkan gandaan ke akhir koleksi, yang merupakan depan urutan z. Gunakan `insertClone` untuk memilih indeks awal atau `reorder` setelah semua bentuk ditambahkan.