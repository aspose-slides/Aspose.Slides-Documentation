---
title: Kelola Bidang Teks dalam Presentasi PowerPoint di PHP
linktitle: Bidang Teks
type: docs
weight: 52
url: /id/php-java/text-fields/
keywords:
- bidang teks
- teks otomatis
- nomor slide
- tanggal dan waktu
- header
- footer
- bagian teks
- PowerPoint
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Buat, inspeksi, modifikasi, dan hapus bidang teks dalam presentasi PowerPoint dengan Aspose.Slides untuk PHP via Java. Pertahankan pemformatan dan verifikasi file PPTX dan PPT yang disimpan."
---
## **Gambaran Umum**

Sebuah paragraf teks terdiri dari portion. Sebuah [Portion](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/) biasa berisi teks literal; sebuah portion bidang juga memiliki [Field](https://reference.aspose.com/slides/id/php-java/aspose.slides/field/) yang tipenya mengidentifikasi nilai yang diperbarui secara otomatis, seperti nomor slide atau tanggal. Dua portion dapat menampilkan karakter yang sama sementara hanya satu yang berisi bidang.

Gunakan [Portion::getField](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/#getField) untuk membedakannya: nilainya `null` untuk teks biasa. [Portion::addField](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/#addField) mengubah portion yang ada menjadi bidang. Simpan label dan nilai dinamisnya dalam portion terpisah sehingga mengubah nilai tidak juga menggantikan label.

Panduan ini mencakup bidang di dalam teks, pemformatannya, dan penyimpanan dalam PPTX dan PPT. Untuk bingkai teks dan paragraf, lihat [Manage Text](/slides/id/php-java/manage-text/).

## **Buat Bidang Nomor Slide**

Contoh lengkap berikut membuat kotak teks yang berisi label literal `Slide ` diikuti oleh nomor yang diperbarui secara otomatis. Ia mengatur ukuran, berat, dan warna nomor sebelum menambahkan bidang, kemudian membuka kembali presentasi yang disimpan dan memeriksa tipe bidang, teks, serta pemformatannya. Tidak diperlukan file masukan.

```php
use aspose\slides\FieldType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
    $shape->addTextFrame("Slide ");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);

    $numberPortion = new Portion();
    $numberColor = new Java("java.awt.Color", 0, 0, 139);
    $numberPortion->getPortionFormat()->setFontHeight(24);
    $numberPortion->getPortionFormat()->setFontBold(NullableBool::True);
    $numberPortion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $numberPortion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($numberColor);
    $paragraph->getPortions()->add($numberPortion);
    $numberPortion->addField(FieldType::getSlideNumber());

    $presentation->save("slide_number.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("slide_number.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedNumber = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1);
        $savedField = $savedNumber->getField();
        $hasNumberField = !java_is_null($savedField) && java_values(FieldType::getSlideNumber()->getInternalString()) === java_values($savedField->getType()->getInternalString());
        $format = $savedNumber->getPortionFormat();
        $formattingPreserved = java_values($format->getFontHeight()) == 24 && java_values($format->getFontBold()) == NullableBool::True;
        $formattingPreserved = $formattingPreserved && java_values($format->getFillFormat()->getSolidFillColor()->getColor()->getRGB()) == java_values($numberColor->getRGB());

        echo "Text: " . $savedShape->getTextFrame()->getText() . PHP_EOL;
        echo "Slide number field: " . ($hasNumberField ? "true" : "false") . PHP_EOL;
        echo "Formatting preserved: " . ($formattingPreserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Presentasi baru dimulai dengan nomor slide 1, sehingga teksnya `Slide 1`, dan kedua pemeriksaan mencetak `true`. Nomor tetap menjadi bidang setelah dibuka kembali; itu bukan literal `1`. Indeks pada verifikasi merujuk pada shape dan portion yang dibuat oleh contoh ini.

## **Pilih Tipe Bidang**

[FieldType](https://reference.aspose.com/slides/id/php-java/aspose.slides/fieldtype/) menyediakan metode berikut untuk memperoleh nilai yang telah ditentukan. Berikan nilai yang sesuai ke [addField](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/#addField).

| Metode | Tujuan |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/id/php-java/aspose.slides/fieldtype/#getSlideNumber) | Nomor slide saat ini. |
| [getDateTime](https://reference.aspose.com/slides/id/php-java/aspose.slides/fieldtype/#getDateTime) | Tanggal/waktu dalam format default aplikasi rendering. |
| [getDateTime1](https://reference.aspose.com/slides/id/php-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/id/php-java/aspose.slides/fieldtype/#getDateTime9) | Format tanggal atau kombinasi tanggal/waktu yang telah ditentukan. |
| [getDateTime10](https://reference.aspose.com/slides/id/php-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/id/php-java/aspose.slides/fieldtype/#getDateTime13) | Format waktu yang telah ditentukan, dengan opsi detik dan jam 12‑jam. |
| [getHeader](https://reference.aspose.com/slides/id/php-java/aspose.slides/fieldtype/#getHeader) | Bidang header; lihat batasan placeholder dan format di bawah. |
| [getFooter](https://reference.aspose.com/slides/id/php-java/aspose.slides/fieldtype/#getFooter) | Bidang footer. |

Sebagai contoh, [getDateTime3](https://reference.aspose.com/slides/id/php-java/aspose.slides/fieldtype/#getDateTime3) mewakili hari, nama bulan lengkap, dan tahun dalam bahasa Inggris. Ini adalah format bidang yang telah ditentukan, bukan string format tanggal PHP sewenang‑wenang. Bahasa yang diatur dengan [setLanguageId](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#setLanguageId) dan aplikasi yang memproses presentasi dapat memengaruhi hasil yang ditampilkan.

## **Buat Bidang dari String Internal**

Overload string dari [addField](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/#addField) menerima pengenal bidang internal. Gunakan saat mempertahankan pengenal yang diberikan oleh aplikasi lain yang tidak memiliki nilai yang telah ditentukan. Anda juga dapat membuat [FieldType](https://reference.aspose.com/slides/id/php-java/aspose.slides/fieldtype/#FieldType) dari pengenal tersebut. [FieldType::getInternalString](https://reference.aspose.com/slides/id/php-java/aspose.slides/fieldtype/#getInternalString) menampilkan pengenal itu untuk inspeksi.

Contoh ini menyimpan bidang spesifik aplikasi `custom-report-id` dengan teks cadangan `Report-042`. Pengenal tersebut tidak mendaftarkan perhitungan: Aspose.Slides tidak menghasilkan ID laporan untuk tipe yang tidak dikenal. Aplikasi yang memahami pengenal ini harus menyediakan maknanya dan memperbarui nilainya.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
    $shape->addTextFrame("Report-042");
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->addField("custom-report-id");

    $presentation->save("custom_field.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom_field.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedPortion = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $savedField = $savedPortion->getField();
        $typeName = java_is_null($savedField) ? "ordinary text" : java_values($savedField->getType()->getInternalString());
        echo "Type: " . $typeName . PHP_EOL;
        echo "Text: " . $savedPortion->getText() . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Setelah putaran PPTX ini, tipe menjadi `custom-report-id` dan teksnya `Report-042`. Memberikan string seperti `Y-m-d` akan menamai tipe bidang; itu tidak akan mengonfigurasi format tanggal khusus. Untuk tanggal tetap dalam format sewenang‑wenang, gunakan teks biasa.

## **Periksa, Modifikasi, dan Hapus Bidang Tanggal/Waktu**

Ubah bidang yang ada melalui [Field::setType](https://reference.aspose.com/slides/id/php-java/aspose.slides/field/#setType). Periksa bahwa bidang ada sebelum mengakses tipenya. Untuk menghentikan pembaruan otomatis, panggil [Portion::removeField](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/#removeField). Ini mempertahankan portion dan teksnya saat ini sambil menghapus asosiasi bidang. Jika Anda memerlukan nilai tetap tertentu, tetapkan teks tersebut setelah menghapus bidang.

Untuk pengaturan API yang terkait dengan pemrosesan bidang tanggal/waktu, lihat [Presentation::setCurrentDateTime](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#setCurrentDateTime). Contoh di bawah menggunakan tanggal persetujuan eksplisit saat mengonversi bidang menjadi teks biasa.

Unduh [sample.pptx](sample.pptx) dan letakkan di direktori kerja JavaBridge, atau berikan path absolutnya ke konstruktor presentasi. Ia berisi dua shape teks bernama, `UpdatedAt` dan `ApprovedDate`, masing‑masing dengan bidang tanggal/waktu, serta label teks biasa. Contoh berikut melintasi shape teks tingkat atas pada slide reguler. Ia mengubah bidang tanggal/waktu ke format tanggal panjang dan membuatnya miring, sambil mempertahankan pemformatan lainnya. Hanya bidang dalam `ApprovedDate` yang menjadi teks tetap.

Sampel mengenali pengenal internal bawaan `datetime` dan `datetime1` hingga `datetime13`. Grup, tabel, catatan, tata letak, dan master memerlukan penelusuran kontainer teks masing‑masing dan berada di luar ruang lingkup contoh ini.

```php
use aspose\slides\FieldType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $approvalDate = new DateTimeImmutable("2030-04-05");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {

        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textShape->getTextFrame()->getParagraphs()->getCount()); $paragraphIndex++) {

                $paragraph = $textShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $field = $portion->getField();
                    if (java_is_null($field)) {
                        continue;
                    }

                    $typeName = java_values($field->getType()->getInternalString());
                    $isDateTime = $typeName != null && preg_match("/\Adatetime([1-9]|1[0-3])?\z/", $typeName) === 1;
                    if (!$isDateTime) {
                        continue;
                    }

                    $field->setType(FieldType::getDateTime3());
                    $portion->getPortionFormat()->setLanguageId("en-US");
                    $portion->getPortionFormat()->setFontItalic(NullableBool::True);

                    if (java_values($textShape->getName()) === "ApprovedDate") {
                        $portion->removeField();
                        $fixedDate = $approvalDate->format("d F Y");
                        $portion->setText($fixedDate);
                    }
                }
            }
        }
    }

    $presentation->save("updated_dates.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("updated_dates.pptx");
    try {
        for ($shapeIndex = 0; $shapeIndex < java_values($reopened->getSlides()->get_Item(0)->getShapes()->size()); $shapeIndex++) {
            $shape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }
            if (java_values($textShape->getName()) !== "UpdatedAt" && java_values($textShape->getName()) !== "ApprovedDate") {
                continue;
            }

            $portion = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $field = $portion->getField();
            $typeName = java_is_null($field) ? "ordinary text" : java_values($field->getType()->getInternalString());
            echo $textShape->getName() . ": " . $typeName . "; " . $portion->getText() . PHP_EOL;
            echo "Italic: " . $portion->getPortionFormat()->getFontItalic() . PHP_EOL;
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Setelah dibuka kembali, `UpdatedAt` memiliki tipe `datetime3` dan tetap dinamis. `ApprovedDate` tidak memiliki bidang dan berisi `05 April 2030`. Kedua portion tanggal miring, dan ukuran font, pengaturan tebal, serta warna asli tetap tidak berubah. Label teks biasa tidak berubah. Verifikasi membaca portion pertama dari dua shape yang diketahui dalam sampel yang disediakan.

## **Pertahankan Pemformatan Teks**

Bekerja dengan portion yang ada saat menambahkan bidang, mengubah tipenya, atau menghapusnya. Operasi ini mempertahankan pemformatan portion tersebut. Gunakan [Portion::getPortionFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/#getPortionFormat) untuk mengubah hanya properti yang diperlukan, seperti contoh untuk warna atau miring.

Hindari membangun kembali seluruh bingkai teks hanya untuk memperbarui satu bidang: hal itu dapat menghilangkan batasan portion asli serta pemformatan individualnya. Juga bedakan pemformatan yang ditetapkan secara eksplisit dari yang diwarisi dari paragraf, tata letak, atau tema. Lihat [Text Formatting](/slides/id/php-java/text-formatting/) untuk opsi pemformatan yang lebih luas.

## **Bidang dan Placeholder Header/Footer**

Bidang adalah bagian dari portion teks. Placeholder adalah shape dengan peran presentasi, seperti footer atau nomor slide. Menambahkan bidang ke kotak teks biasa tidak menjadikan shape tersebut placeholder.

Manajer header/footer mengontrol teks placeholder dan visibilitasnya pada slide, tata letak, dan master, termasuk propagasi ke slide turunan. Bidang nomor dalam kotak teks khusus dapat berguna bahkan saat Anda tidak memakai placeholder nomor slide. Sebaliknya, mengubah visibilitas placeholder tidak menghapus bidang dari kotak teks yang tidak terkait.

Tipe header dan footer yang telah ditentukan tidak membuat placeholder yang bersesuaian atau menyediakan kontennya. Khususnya, slide PowerPoint reguler tidak memiliki placeholder header; header termasuk dalam halaman catatan dan handout. Jangan mengasumsikan bahwa bidang header atau footer dalam shape sewenang‑wenang akan otomatis memperoleh teks yang dikonfigurasi melalui manajer placeholder. Untuk alur kerja itu, lihat [Presentation Headers and Footers](/slides/id/php-java/presentation-header-and-footer/).

## **Batasan PPTX dan PPT**

Periksa baik tipe bidang maupun teks hasilnya setelah menyimpan dan membuka kembali. Mempertahankan pengenal tidak membuktikan bahwa aplikasi dapat menghitung atau menampilkan nilainya.

| Format | Perilaku bidang dan batasan |
|---|---|
| PPTX | Menyimpan pengenal bidang internal bersama teks bidang. Pada pemeriksaan putar‑balik, tipe yang telah ditentukan dan pengenal khusus yang digunakan di atas tetap ada setelah menyimpan dan membuka kembali. Tipe khusus yang tidak dikenali mempertahankan teks cadangannya; ia tidak memperoleh logika perhitungan otomatis. Aplikasi lain mungkin memperlakukan pengenal yang tidak didukung secara berbeda. |
| PPT | Menggunakan representasi bidang warisan dan memiliki kompatibilitas yang lebih terbatas. Pada pemeriksaan putar‑balik, bidang nomor slide dan bidang tanggal/waktu yang telah ditentukan tetap ada setelah menyimpan dan membuka kembali. Bidang khusus dalam kotak teks slide biasa dibuka kembali dengan pengenalannya namun teksnya `*`; bidang header dalam konteks yang sama juga menghasilkan `*`. Jangan mengandalkan bidang khusus atau konteks bidang yang tidak didukung tetap mempertahankan teks yang terlihat. |

Untuk output yang dapat dipindahkan dan tetap, konversikan bidang yang tidak didukung menjadi teks biasa dan tetapkan nilai yang diinginkan secara eksplisit sebelum menyimpan. Ini mempertahankan teks yang dipilih namun sengaja menghentikan pembaruan otomatis. Uji juga aplikasi target ketika perhitungan ulang bidangnya menjadi bagian dari alur kerja Anda.

## **FAQ**

**Bagaimana saya bisa mengetahui apakah angka atau tanggal yang ditampilkan merupakan bidang?**  
Periksa [Portion::getField](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/#getField). Nilai non‑null mengidentifikasi bidang; teks yang ditampilkan saja tidak dapat memberi tahu Anda.

**Apakah menghapus bidang menghapus teks atau pemformatannya?**  
Tidak. [removeField](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/#removeField) mengubah portion yang ada menjadi teks biasa. Tetapkan nilai eksplisit setelahnya bila Anda memerlukan tanggal beku atau teks cadangan tertentu.

**Apakah string internal dapat mendefinisikan format tanggal atau formula baru?**  
Tidak. Itu hanya mengidentifikasi tipe bidang. Pengenal yang tidak dikenal tidak menyediakan evaluator atau pola format tanggal PHP. Gunakan tipe yang didukung atau format nilai sendiri sebagai teks biasa.

**Mengapa memeriksa presentasi lagi setelah menyimpannya?**  
Pengenal bidang, teks yang dihitung, dan pemformatan adalah hal terpisah yang perlu diverifikasi. Konversi format dapat mengubah hasil yang terlihat meskipun pengenal bidang masih ada.