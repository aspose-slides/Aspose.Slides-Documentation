---
title: Kelola Placeholder Presentasi dalam PHP
linktitle: Kelola Placeholder
type: docs
weight: 10
url: /id/php-java/manage-placeholder/
keywords:
- placeholder
- placeholder teks
- placeholder gambar
- placeholder diagram
- placeholder konten
- teks prompt
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara memeriksa dan mengedit placeholder teks, gambar, diagram, dan konten serta memahami pewarisan placeholder dengan Aspose.Slides untuk PHP via Java."
---
## **Gambaran Umum**

Placeholder adalah shape yang memesan posisi untuk jenis konten tertentu dalam templat presentasi. Contoh umum meliputi placeholder judul, isi, gambar, diagram, dan placeholder konten tujuan umum. Tidak seperti shape biasa, placeholder dapat mewarisi posisi, ukuran, format, dan pengaturan lainnya dari slide tata letak atau slide master.

Aspose.Slides mengekspos informasi placeholder melalui metode [Shape::getPlaceholder](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getplaceholder/). Metode ini mengembalikan objek [Placeholder](https://reference.aspose.com/slides/id/php-java/aspose.slides/placeholder/) atau `null` untuk shape normal. Gunakan [Placeholder::getType](https://reference.aspose.com/slides/id/php-java/aspose.slides/placeholder/gettype/) untuk menentukan apa yang dimaksudkan untuk diisi oleh placeholder.

Kelas shape masih penting setelah Anda mengetahui tipe placeholder:

- Placeholder teks, gambar, diagram, atau konten yang kosong biasanya direpresentasikan oleh [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/).
- Placeholder gambar yang sudah terisi dapat direpresentasikan oleh [PictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframe/).
- Placeholder diagram yang sudah terisi dapat direpresentasikan oleh [Chart](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/).
- Placeholder konten dapat berisi beberapa jenis konten. Periksa baik [Placeholder::getType](https://reference.aspose.com/slides/id/php-java/aspose.slides/placeholder/gettype/) maupun kelas shape runtime alih-alih mengasumsikan setiap placeholder adalah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Peringatan" %}}
[Placeholder::getType] menjelaskan peran placeholder; itu tidak menjamin kelas runtime shape. Selalu lakukan pemeriksaan tipe sebelum mengakses anggota khusus teks, gambar, diagram, tabel, atau media.
{{% /alert %}}

## **Memahami Pewarisan Placeholder**

Placeholder membentuk hierarki:

1. Slide master mendefinisikan gaya yang dapat digunakan kembali dan, dalam beberapa kasus, placeholder tingkat master.
2. Slide tata letak mendefinisikan susunan yang digunakan oleh satu atau lebih slide normal dan dapat mewarisi dari master.
3. Slide normal berisi placeholder untuk slide tersebut dan dapat mewarisi dari tata letaknya.

Panggil [Shape::getBasePlaceholder](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getbaseplaceholder/) untuk naik satu tingkat dalam hierarki ini. Placeholder slide biasanya mengembalikan placeholder tata letaknya; placeholder tata letak dapat mengembalikan placeholder masternya. Metode ini mengembalikan `null` ketika shape tidak memiliki base placeholder.

Contoh berikut mencantumkan placeholder pada slide pertama dan melaporkan base placeholder‑nya:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        $shapeClass = $shape->getClass();
        $shapeClassNameValue = $shapeClass->getSimpleName();
        $shapeClassName = java_values($shapeClassNameValue);
        echo "Slide placeholder: " . $placeholderType . "; shape class: " . $shapeClassName . PHP_EOL;

        $layoutPlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($layoutPlaceholder)) {
            $layoutPlaceholderInfo = $layoutPlaceholder->getPlaceholder();
            if (!java_is_null($layoutPlaceholderInfo)) {
                $layoutPlaceholderTypeValue = $layoutPlaceholderInfo->getType();
                $layoutPlaceholderType = java_values($layoutPlaceholderTypeValue);
                echo "  Layout placeholder: " . $layoutPlaceholderType . PHP_EOL;
            }

            $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
            if (!java_is_null($masterPlaceholder)) {
                $masterPlaceholderInfo = $masterPlaceholder->getPlaceholder();
                if (!java_is_null($masterPlaceholderInfo)) {
                    $masterPlaceholderTypeValue = $masterPlaceholderInfo->getType();
                    $masterPlaceholderType = java_values($masterPlaceholderTypeValue);
                    echo "  Master placeholder: " . $masterPlaceholderType . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Mengedit placeholder pada slide normal membuat atau mengubah override lokal untuk slide tersebut. Mengedit tata letak atau master yang terkait dapat memengaruhi semua slide yang masih mewarisi pengaturan itu. Shape lokal biasa tidak memiliki base placeholder dan tidak mulai mewarisi hanya karena menempati koordinat yang sama.

## **Mengubah Teks dalam Placeholder**

Placeholder judul, centered-title, subtitle, body, dan teks biasanya mendukung teks. Periksa [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) sebelum menggunakan metode [getTextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/gettextframe/)‑nya.

Contoh ini memperbarui placeholder judul pertama pada slide pertama dan menyimpan hasilnya:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $titleShape = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $titleShape = $shape;
            break;
        }
    }

    if ($titleShape === null) {
        throw new RuntimeException("The first slide does not contain a title placeholder.");
    }

    $titleShape->getTextFrame()->setText("Quarterly Business Review");
    $presentation->save("title-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pola ini menghindari perlakuan placeholder gambar, diagram, tabel, atau media sebagai objek [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/). Ini juga mengidentifikasi placeholder berdasarkan tujuan alih-alih mengandalkan indeks shape yang rapuh.

## **Mengatur Teks Prompt pada Tata Letak**

Prompt text adalah instruksi waktu‑desain yang ditampilkan dalam placeholder kosong, misalnya *Click to add title*. Tetapkan prompt teks khusus pada placeholder tata letak daripada mencoba mencapainya melalui koleksi shape slide normal. Akses tata letak lewat [Slide::getLayoutSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/#getLayoutSlide) dan iterasi koleksi yang dikembalikan oleh [BaseSlide::getShapes](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseslide/#getShapes).

Contoh berikut mengubah prompt judul dan subtitle pada tata letak yang digunakan oleh slide pertama:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $shapes = $layoutSlide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $shape->getTextFrame()->setText("Enter a concise slide title");
        } elseif ($placeholderType === PlaceholderType::Subtitle) {
            $shape->getTextFrame()->setText("Enter a subtitle or reporting period");
        }
    }

    $presentation->save("custom-placeholder-prompts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Prompt text bukan konten slide normal. Itu ditujukan untuk placeholder kosong dalam aplikasi pengeditan seperti PowerPoint. Setelah pengguna atau program menyediakan konten nyata, prompt tidak lagi ditampilkan. Mengubah prompt juga tidak menggantikan teks yang ada pada slide yang menggunakan tata letak tersebut.

## **Memperbarui Placeholder Gambar**

Ada dua kasus yang harus ditangani:

- Jika placeholder gambar sudah terisi dan direpresentasikan oleh [PictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframe/), ganti gambar melalui [PictureFillFormat::getPicture](https://reference.aspose.com/slides/id/php-java/aspose.slides/picturefillformat/getpicture/) dan [SlidesPicture::setImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidespicture/setimage/).
- Jika masih merupakan placeholder kosong, tambahkan picture frame pada koordinat placeholder dengan [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/addpictureframe/) dan hapus placeholder kosong.

Contoh berikut mendukung kedua kasus dan menyimpan presentasi:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("picture-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $picturePlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Picture) {
            $picturePlaceholder = $shape;
            break;
        }
    }

    if ($picturePlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a picture placeholder.");
    }

    $imageData = file_get_contents("replacement.png");
    $image = $presentation->getImages()->addImage($imageData);

    if (java_instanceof($picturePlaceholder, $pictureFrameClass)) {
        $picture = $picturePlaceholder->getPictureFormat()->getPicture();
        $picture->setImage($image);
    } else {
        $x = $picturePlaceholder->getX();
        $y = $picturePlaceholder->getY();
        $width = $picturePlaceholder->getWidth();
        $height = $picturePlaceholder->getHeight();
        $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
        $shapes->remove($picturePlaceholder);
    }

    $presentation->save("picture-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pengganti yang dibuat untuk placeholder kosong adalah picture frame lokal, bukan placeholder baru, karena [Shape::getPlaceholder](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getplaceholder/) tidak menyediakan setter. Ia mempertahankan posisi yang dipesan tetapi tidak lagi mewarisi perilaku khusus placeholder. Jika mempertahankan hubungan placeholder penting, siapkan dan isi placeholder di PowerPoint terlebih dahulu, lalu perbarui [PictureFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/pictureframe/) yang dihasilkan dengan Aspose.Slides.

Untuk transparansi gambar, pemotongan, dan efek khusus gambar lainnya, lihat [Manage Picture Frames](/slides/id/php-java/picture-frame/). Operasi tersebut terkait dengan picture frame atau picture fill, bukan metadata placeholder.

## **Bekerja dengan Placeholder Diagram dan Konten**

Placeholder diagram yang terisi dapat direpresentasikan oleh [Chart](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/). Contoh ini menemukan diagram tersebut berdasarkan tipe placeholder dan kelas runtime, mengubah judulnya, dan menyimpan file:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $chartClass = new JavaClass("com.aspose.slides.Chart");
    $placeholderChart = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $chartClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart) {
            $placeholderChart = $shape;
            break;
        }
    }

    if ($placeholderChart === null) {
        throw new RuntimeException("The first slide does not contain a populated chart placeholder.");
    }

    $placeholderChart->setTitle(true);
    $placeholderChart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $presentation->save("chart-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Placeholder konten umum biasanya memiliki [PlaceholderType::Object](https://reference.aspose.com/slides/id/php-java/aspose.slides/placeholdertype/). Di PowerPoint ia berfungsi sebagai peluncur untuk beberapa jenis konten, termasuk diagram, tabel, diagram, gambar, dan media. Setelah terisi, periksa kelas shape aktual untuk mengetahui apa yang terkandung di dalamnya. Tata letak khusus juga dapat mengekspose [PlaceholderType::Chart](https://reference.aspose.com/slides/id/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/id/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/id/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/id/php-java/aspose.slides/placeholdertype/), atau [PlaceholderType::Diagram](https://reference.aspose.com/slides/id/php-java/aspose.slides/placeholdertype/).

Aspose.Slides tidak mengubah placeholder [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) yang kosong menjadi [Chart](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/) hanya dengan mengubah [Placeholder::getType](https://reference.aspose.com/slides/id/php-java/aspose.slides/placeholder/gettype/); tipe tidak dapat diubah melalui kelas. Untuk mengisi area diagram atau konten kosong secara programatis, tambahkan objek yang diperlukan pada koordinat placeholder lalu hapus placeholder kosong. Contoh berikut melakukannya untuk sebuah diagram:

```php
use aspose\slides\ChartType;
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("content-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $targetPlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart || $placeholderType === PlaceholderType::Object) {
            $targetPlaceholder = $shape;
            break;
        }
    }

    if ($targetPlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a chart or content placeholder.");
    }

    $x = $targetPlaceholder->getX();
    $y = $targetPlaceholder->getY();
    $width = $targetPlaceholder->getWidth();
    $height = $targetPlaceholder->getHeight();
    $chart = $shapes->addChart(ChartType::ClusteredColumn, $x, $y, $width, $height);
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $shapes->remove($targetPlaceholder);
    $presentation->save("content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Diagram yang ditambahkan adalah diagram lokal biasa. Ia menempati area placeholder tetapi tidak mewarisi dari placeholder tata letak. Gunakan artikel manajemen diagram khusus [chart management articles](/slides/id/php-java/powerpoint-charts/) ketika Anda perlu mengganti kategori, seri, atau data workbook‑nya.

## **Contoh Lengkap: Memperbarui Teks atau Konten Gambar**

Contoh end‑to‑end berikut membuka templat, mencari slide pertama untuk placeholder judul atau gambar, memeriksa tipe placeholder dan shape, memperbarui konten yang sesuai, dan menyimpan output. Contoh ini sengaja menghindari asumsi indeks shape atau memperlakukan setiap placeholder sebagai kelas yang sama.

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $updated = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);

        if (($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) && java_instanceof($shape, $autoShapeClass)) {
            $shape->getTextFrame()->setText("Quarterly Business Review");
            $updated = true;
            break;
        }

        if ($placeholderType === PlaceholderType::Picture) {
            $imageData = file_get_contents("replacement.png");
            $image = $presentation->getImages()->addImage($imageData);

            if (java_instanceof($shape, $pictureFrameClass)) {
                $picture = $shape->getPictureFormat()->getPicture();
                $picture->setImage($image);
            } else {
                $x = $shape->getX();
                $y = $shape->getY();
                $width = $shape->getWidth();
                $height = $shape->getHeight();
                $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
                $shapes->remove($shape);
            }

            $updated = true;
            break;
        }
    }

    if (!$updated) {
        throw new RuntimeException("No supported title or picture placeholder was found on the first slide.");
    }

    $presentation->save("placeholder-content-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Apa itu placeholder dasar?**

Placeholder dasar adalah shape yang bersesuaian pada tata letak atau master dari mana placeholder lain mewarisi. Gunakan [Shape::getBasePlaceholder](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getbaseplaceholder/) untuk mengambilnya. Shape lokal biasa mengembalikan `null` karena tidak menjadi bagian dari hierarki placeholder.

**Apakah saya dapat mengubah semua judul slide dengan mengedit placeholder tata letak?**

Anda dapat mengubah format atau prompt text yang diwariskan melalui tata letak, tetapi konten judul yang ada disimpan pada slide normal. Untuk mengganti teks judul aktual di seluruh presentasi, iterasi slide dan perbarui setiap placeholder judul.

**Bagaimana cara mengelola placeholder tanggal, nomor slide, header, dan footer?**

Gunakan manajer header dan footer pada skop slide, tata letak, master, notes, atau handout yang sesuai. Lihat [Manage Presentation Header and Footer](/slides/id/php-java/presentation-header-and-footer/) untuk contoh lengkap.