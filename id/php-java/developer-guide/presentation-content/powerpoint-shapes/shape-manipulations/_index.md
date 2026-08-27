---
title: Kelola Bentuk Presentasi dalam PHP
linktitle: Manipulasi Bentuk
type: docs
weight: 40
url: /id/php-java/shape-manipulations/
keywords:
- Bentuk PowerPoint
- Bentuk presentasi
- Bentuk pada slide
- Temukan bentuk
- Gandakan bentuk
- Hapus bentuk
- Sembunyikan bentuk
- Ubah urutan bentuk
- Dapatkan ID bentuk interop
- Teks alternatif bentuk
- Titik penyesuaian bentuk
- Penyesuaian bentuk preset
- Geometri bentuk
- Format tata letak bentuk
- Bentuk sebagai SVG
- Bentuk ke SVG
- Jajarkan bentuk
- Balikkan bentuk
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara mengidentifikasi, menyesuaikan, menggandakan, menghapus, menyembunyikan, mengubah urutan, mengekspor, menjajarkan, dan membalikkan bentuk presentasi dengan Aspose.Slides untuk PHP via Java."
---
## **Gambaran Umum**

Aspose.Slides for PHP via Java merepresentasikan bentuk‑bentuk pada slide sebagai sebuah [ShapeCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/) yang terurut. Koleksi ini sekaligus menjadi tempat Anda menemukan dan memodifikasi bentuk serta sumber urutan tumpukan mereka: indeks `0` adalah bentuk paling belakang, sedangkan indeks terakhir adalah bentuk paling depan.

Artikel ini mengikuti model tersebut. Pertama menjelaskan cara mengidentifikasi bentuk secara andal dan mengubah titik penyesuaian bentuk yang sudah ditetapkan, kemudian menunjukkan cara menggandakan, menghapus, menyembunyikan, dan mengubah urutan bentuk. Bagian akhir mencakup pemformatan pada tingkat tata letak, ekspor SVG, penjajaran, dan pengaturan flip. Setiap contoh bersifat independen, sehingga Anda dapat menggunakan hanya operasi yang diperlukan dalam alur kerja Anda.

## **Identifikasi dan Temukan Bentuk**

Indeks koleksi memang praktis saat memproses file yang sudah diketahui, tetapi bukan pengidentifikasi yang stabil. Menambahkan, menghapus, atau mengubah urutan sebuah bentuk dapat mengubah indeksnya. Pilih pengidentifikasi sesuai cara presentasi dibuat dan dipelihara:

- [Name](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getname/) berguna untuk templat yang dikendalikan pengembang dan mudah dilihat di Panel Seleksi PowerPoint. Nama dapat diedit dan tidak dijamin unik, jadi tetapkan konvensi penamaan bila kode bergantung padanya.
- [AlternativeText](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getalternativetext/) berguna ketika deskripsi aksesibilitas atau tag yang diberikan penulis sudah mengidentifikasi bentuk. Teks ini terlihat oleh pengguna, dapat dilokalisasi atau ditulis ulang untuk aksesibilitas, dan tidak dijamin unik. Jangan diam‑diam mengubah teks aksesibilitas yang bermakna menjadi kunci basis data.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getofficeinteropshapeid/) adalah pengidentifikasi baca‑saja yang unik dalam satu slide dan sesuai dengan ID bentuk yang digunakan oleh PowerPoint interop. Gunakan bila berintegrasi dengan PowerPoint atau ketika Anda membutuhkan referensi yang tidak ambigu selama masa hidup sebuah bentuk. Bentuk yang digandakan atau dibuat kembali adalah bentuk yang berbeda dan menerima ID‑nya masing‑mahasiswa.

Metode terkait [Shape::getUniqueId](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getuniqueid/) mengembalikan pengidentifikasi dengan cakupan presentasi, tetapi pengidentifikasi tersebut ditujukan untuk add‑in dan dapat dipindahtangankan. Itu tidak boleh diperlakukan sebagai kunci eksternal permanen. Jika identitas jangka panjang penting, simpan pemetaan dalam data aplikasi dan validasi bahwa bentuk yang diharapkan masih ada.

Contoh berikut mencari berdasarkan nama dengan perbandingan tepat dan melaporkan ID interop berskala slide. Ketika templat tidak berisi bentuk yang diharapkan, kode melaporkan hasil tersebut alih‑alih melanjutkan dengan objek yang salah.

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

Ketika sebuah operasi bersifat khusus pada tipe bentuk, periksa kelas runtime sebelum menggunakan anggota tipe‑spesifik. Contoh ini memperbarui teks dan teks alternatif hanya bila objek bernama merupakan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/).

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

## **Identifikasi dan Modifikasi Penyesuaian Bentuk Bawaan**

Bentuk geometri bawaan dapat menampilkan titik penyesuaian yang mengontrol fitur seperti ukuran sudut, proporsi panah, atau sudut busur. Akses melalui koleksi baca‑saja [GeometryShape::getAdjustments](https://reference.aspose.com/slides/id/php-java/aspose.slides/geometryshape/#getAdjustments). Koleksi sendiri disediakan oleh bentuk, tetapi setiap [AdjustValue](https://reference.aspose.com/slides/id/php-java/aspose.slides/adjustvalue/) berisi nilai yang dapat diubah.

Jangan hanya mengandalkan indeks koleksi yang tetap. Iterasi melalui penyesuaian dan periksa metode baca‑saja [AdjustValue::getType](https://reference.aspose.com/slides/id/php-java/aspose.slides/adjustvalue/#getType), yang nilai [ShapeAdjustmentType](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapeadjustmenttype/)‑nya menjelaskan apa yang dikontrol oleh penyesuaian tersebut. Metode baca‑saja [AdjustValue::getName](https://reference.aspose.com/slides/id/php-java/aspose.slides/adjustvalue/getname/) memberi informasi identifikasi tambahan dan sangat berguna bila satu preset berisi lebih dari satu penyesuaian dengan tipe semantik yang sama.

Gunakan metode nilai yang sesuai dengan arti penyesuaian:

| Tipe Penyesuaian | Tujuan | Nilai yang diubah |
|---|---|---|
| `CornerSize` | Ukuran sudut melengkung | [setRawValue](https://reference.aspose.com/slides/id/php-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | Ketebalan ekor panah | `setRawValue` |
| `ArrowheadLength` | Panjang kepala panah | `setRawValue` |
| `ArrowheadWidth` | Lebar kepala panah | `setRawValue` |
| `StartAngle` | Sudut mulai pai atau busur | [setAngleValue](https://reference.aspose.com/slides/id/php-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | Sudut akhir pai atau busur | `setAngleValue` |

`getType` dan `getName` mengembalikan informasi baca‑saja. `getRawValue` dan `setRawValue` bekerja dengan bilangan bulat dalam satuan geometri asli preset, sedangkan `getAngleValue` dan `setAngleValue` bekerja dengan sudut dalam derajat. Jumlah, urutan, arti, dan rentang nilai yang valid tergantung pada preset [GeometryShape::getShapeType](https://reference.aspose.com/slides/id/php-java/aspose.slides/geometryshape/#getShapeType). Nilai yang valid untuk satu preset mungkin tidak valid atau memberi efek yang berbeda untuk preset lain.

Ketika `getType` mengembalikan `ShapeAdjustmentType::Custom`, API tidak mengenali arti semantik standar. Periksa `getName`, tipe preset, dan nilai yang ada, dan biarkan penyesuaian tidak berubah kecuali arti dan rentang yang diharapkan diketahui. Bahkan untuk tipe yang dikenali, periksa apakah tipe yang sama muncul lebih dari satu kali sebelum memilih nilai. Artikel [Connector](/slides/id/php-java/connector/) menampilkan situasi ini dengan penyesuaian lengkung penghubung.

Contoh lengkap berikut membuat versi default dan versi yang dimodifikasi dari tiga bentuk preset. Ia mengiterasi setiap penyesuaian, melaporkan nama dan tipe, mengubah nilai yang terkait ukuran lewat `setRawValue`, mengubah sudut lewat `setAngleValue`, dan menyimpan hasilnya. Kolom kiri mempertahankan geometri default; kolom kanan menampilkan persegi panjang bulat yang disesuaikan, panah empat arah, dan pai.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Tambahkan header untuk kolom bentuk default dan yang disesuaikan.
    $defaultColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
    $defaultColumnLabel->getTextFrame()->setText("Default preset geometry");
    $adjustedColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
    $adjustedColumnLabel->getTextFrame()->setText("Modified adjustment values");

    $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
    $modifiedRoundedRectangle = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
    $modifiedRoundedRectangle->setName("ModifiedRoundedRectangle");

    $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
    $modifiedArrow = $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
    $modifiedArrow->setName("ModifiedQuadArrow");

    $slide->getShapes()->addAutoShape(ShapeType::Pie, 95, 330, 130, 130);
    $modifiedPie = $slide->getShapes()->addAutoShape(ShapeType::Pie, 445, 330, 130, 130);
    $modifiedPie->setName("ModifiedPie");

    $shapesToAdjust = [
        $modifiedRoundedRectangle,
        $modifiedArrow,
        $modifiedPie
    ];

    foreach ($shapesToAdjust as $shape) {
        $adjustmentCount = java_values($shape->getAdjustments()->size());
        for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
            $adjustment = $shape->getAdjustments()->get_Item($adjustmentIndex);
            $shapeName = java_values($shape->getName());
            $adjustmentName = java_values($adjustment->getName());
            $adjustmentType = java_values($adjustment->getType());
            echo $shapeName . " / " . $adjustmentName . ": " . $adjustmentType . PHP_EOL;

            switch ($adjustmentType) {
                case ShapeAdjustmentType::CornerSize:
                    $adjustment->setRawValue(5000);
                    break;
                case ShapeAdjustmentType::ArrowTailThickness:
                    $adjustment->setRawValue(25000);
                    break;
                case ShapeAdjustmentType::ArrowheadLength:
                    $adjustment->setRawValue(30000);
                    break;
                case ShapeAdjustmentType::ArrowheadWidth:
                    $adjustment->setRawValue(40000);
                    break;
                case ShapeAdjustmentType::StartAngle:
                    $adjustment->setAngleValue(30);
                    break;
                case ShapeAdjustmentType::EndAngle:
                    $adjustment->setAngleValue(300);
                    break;
                case ShapeAdjustmentType::Custom:
                    echo "Custom adjustment '" . $adjustmentName . "' was not changed." . PHP_EOL;
                    break;
            }
        }
    }

    $presentation->save("preset-shape-adjustments.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Memeriksa tipe semantik sebelum mengubah nilai membuat kode eksplisit mengenai maksudnya dan menghindari asumsi bahwa indeks koleksi tertentu memiliki arti yang sama pada bentuk preset yang berbeda.

## **Modifikasi Koleksi Bentuk**

Metode tambah, gandakan, hapus, dan ubah urutan beroperasi pada koleksi secara langsung. Jika suatu operasi mengubah jumlah atau urutan bentuk, jangan terus mengandalkan indeks yang diambil sebelum operasi tersebut.

### **Gandakan Sebuah Bentuk**

[ShapeCollection::addClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/addclone/) membuat salinan independen dan menambahkannya ke koleksi target. [ShapeCollection::insertClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/insertclone/) juga membuat salinan tetapi menempatkannya pada indeks z‑order yang ditentukan. Overload yang menerima koordinat memindahkan gandaan tanpa mengubah ukurannya; overload dengan lebar dan tinggi dapat meresizenya juga.

Contoh membuat slide tujuan, menggandakan persegi panjang berlabel ke depan, dan menyisipkan gandaan kedua di belakang. Perubahan pada salah satu gandaan tidak memodifikasi bentuk sumber.

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

Penggandaan menyalin konten dan format bentuk, termasuk nama dan teks alternatifnya. Tetapkan pengidentifikasi logis baru untuk gandaan bila nilai‑nilai tersebut harus unik. Sumber daya yang dipakai oleh bentuk kompleks ditangani oleh presentasi, tetapi gandaan tetap menjadi item koleksi baru dengan identitas bentuk baru.

### **Hapus Bentuk**

[ShapeCollection::remove](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/remove/) menghapus objek bentuk tertentu dari koleksinya. Saat menghapus beberapa kecocokan selama iterasi berbasis indeks, lakukan penelusuran dari akhir sehingga setiap indeks yang tersisa tetap valid.

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

Setelah penghapusan, jumlah bentuk dan indeks bentuk‑bentuk berikutnya berubah. Referensi ke bentuk yang tidak terpengaruh tetap lebih dapat diandalkan daripada indeks yang disimpan. Pertimbangkan pula konektor, animasi, dan fitur presentasi lain yang mungkin merujuk ke objek yang dihapus; menghapus bentuk yang terlihat dapat mengubah lebih dari sekadar tampilan slide.

### **Sembunyikan Sebuah Bentuk**

Menetapkan [Shape::setHidden](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/sethidden/) ke `true` mempertahankan bentuk dalam koleksi tetapi mencegahnya muncul pada tampilan slide normal. Indeks, format, dan kontennya tetap tersedia bagi kode, sehingga penyembunyian cocok untuk elemen opsional yang dapat dipulihkan kemudian.

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

Penyembunyian bukan penghapusan atau keamanan. Objek masih dapat ditemukan dan ditampilkan kembali oleh pengguna atau kode, dan tetap menjadi bagian dari berkas presentasi.

### **Ubah Z‑Order**

Bentuk yang saling tumpang tindih digambar sesuai urutan koleksi. [ShapeCollection::reorder](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/reorder/) memindahkan bentuk yang ada ke indeks target tanpa menggandakannya. Indeks `0` adalah belakang; `size() - 1` adalah depan.

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

Persegi panjang dibuat dulu dan pada awalnya berada di belakang elips. Memindahkannya ke indeks akhir menempatkannya di depan. Finalisasikan urutan z setelah menambah atau menggandakan semua bentuk terkait, karena operasi tersebut menambahkan atau menyisipkan item koleksi baru dan dapat mengubah tumpukan yang dimaksud.

## **Periksa Bentuk pada Slide Tata Letak**

Slide normal, slide tata letak, dan slide master memiliki koleksi bentuk yang terpisah. Bentuk dalam koleksi tata letak bukan objek yang sama dengan bentuk yang posisinya serupa pada slide normal. Periksa bentuk tata letak ketika Anda perlu memahami atau mengubah pemformatan yang disediakan oleh tata letak.

Contoh berikut membaca masing‑masing [FillFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getfillformat/) dan [LineFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getlineformat/) pada setiap bentuk tata letak tanpa mengasumsikan bahwa setiap bentuk adalah sebuah `AutoShape`.

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

Menyunting tata letak dapat memengaruhi beberapa slide yang menggunakannya. Sebelum mengubah bentuk tata letak, tentukan apakah slide normal mewarisi objek tersebut atau berisi penimpaan lokal, dan uji setiap slide yang memakai tata letak itu.

## **Ekspor Bentuk ke SVG**

[Shape::writeAsSvg](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/writeassvg/) menulis konten ter‑render satu bentuk ke aliran. Hasilnya berisi bentuk saja, bukan latar belakang slide lengkap atau bentuk‑bentuk tetangganya.

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

Biarkan presentasi tetap terbuka saat merender. Output bergantung pada format bentuk serta sumber daya seperti font dan gambar. Jika Anda memerlukan seluruh komposisi, ekspor slide bukan bentuk individu. Pemanggil memiliki aliran dan harus menutupnya.

## **Jajarkan Bentuk**

Overload [SlideUtil::alignShapes](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideutil/alignshapes/) dapat menjajarkan semua bentuk atau indeks koleksi yang dipilih. [ShapesAlignmentType](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapesalignmenttype/) menentukan tepi, garis tengah, atau mode distribusi. Atur `alignToSlide` ke `true` untuk memakai tepi slide; atur ke `false` untuk menjajarkan bentuk terpilih relatif satu sama lain.

Contoh ini menjajarkan tiga bentuk ke tepi atas slide. Referensi bentuk yang dikembalikan diubah menjadi indeks terkini tepat sebelum penjajaran.

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

Penjajaran mengubah posisi, bukan z‑order. Penjajaran relatif biasanya memerlukan setidaknya dua bentuk, sementara distribusi horizontal atau vertikal memerlukan cukup bentuk untuk menentukan jarak. Hitung ulang indeks bila Anda memodifikasi koleksi sebelum memanggil metode.

## **Balikkan Bentuk**

Kelas [ShapeFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapeframe/) menyimpan posisi, ukuran, pengaturan flip horizontal dan vertikal, serta rotasi. Nilai `getFlipH` dan `getFlipV` menggunakan [NullableBool](https://reference.aspose.com/slides/id/php-java/aspose.slides/nullablebool/): `True` mengaktifkan flip, `False` menonaktifkannya, dan `NotDefined` mempertahankan keadaan tak ditentukan/default.

Presentasi input di bawah berisi satu bentuk yang tidak dibalik.

![The shape before flipping](shape_to_be_flipped.png)

Contoh ini mempertahankan semua nilai frame lain dan hanya mengganti dua pengaturan flip. Ini penting karena menetapkan [Frame](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/setframe/) yang baru akan menggantikan seluruh frame.

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

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Haruskah saya memakai indeks koleksi sebagai pengidentifikasi bentuk?**

Hanya untuk pemrosesan singkat ketika koleksi tidak akan berubah sebelum indeks digunakan. Lebih baik gunakan konvensi `Name` atau `AlternativeText` yang tervalidasi untuk templat yang dibuat, atau `OfficeInteropShapeId` untuk pekerjaan interop berskala slide.

**Apakah menyembunyikan bentuk menghapusnya dari z‑order?**

Tidak. Bentuk tersembunyi tetap berada di koleksi pada indeks yang sama. Ia dapat ditemukan, diubah urutannya, disunting, atau ditampilkan kembali.

**Mengapa bentuk yang digandakan muncul di depan bentuk lain?**

`addClone` menambahkan gandaan ke akhir koleksi, yang merupakan depan z‑order. Gunakan `insertClone` untuk memilih indeks awal atau `reorder` setelah semua bentuk ditambahkan.

**Dapatkah saya memakai indeks tetap untuk mengidentifikasi penyesuaian bentuk preset?**

Hanya setelah memvalidasi preset dan tata letak koleksi secara tepat. Lebih baik iterasi melalui `GeometryShape::getAdjustments` dan memeriksa `AdjustValue::getType`; gunakan `AdjustValue::getName` sebagai informasi tambahan bila tipe semantik yang sama muncul lebih dari satu kali.