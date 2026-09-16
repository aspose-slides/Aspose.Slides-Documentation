---
title: Kelola Hyperlink Presentasi dalam PHP
linktitle: Kelola Hyperlink
type: docs
weight: 20
url: /id/php-java/manage-hyperlinks/
keywords:
- tambah URL
- tambah hyperlink
- buat hyperlink
- formatkan hyperlink
- hapus hyperlink
- perbarui hyperlink
- hyperlink teks
- hyperlink slide
- hyperlink bentuk
- hyperlink gambar
- hyperlink video
- hyperlink yang dapat diubah
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Menambahkan, memformat, memperbarui, dan menghapus hyperlink dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk PHP via Java, menggunakan contoh PHP."
---
## **Pendahuluan**

Sebuah hyperlink menghubungkan konten presentasi ke situs web atau ke lokasi di dalam presentasi. Di PowerPoint, hyperlink biasanya melayani dua tujuan:

* Membuka situs web dari teks, bentuk, atau bingkai media.
* Menavigasi ke slide lain, misalnya, dari daftar isi.

Aspose.Slides for PHP via Java memungkinkan Anda menambahkan tautan ini, mengontrol tampilan dan suara mereka, memperbarui properti mereka, dan menghapusnya. Contoh di bawah ini menunjukkan cara bekerja dengan hyperlink pada elemen individual dan cara mengakses hyperlink pada tingkat presentasi, slide, atau bingkai teks. Contoh mengasumsikan bahwa PHP/Java Bridge dan pembungkus Aspose.Slides PHP telah diinisialisasi. Anggota API tanpa halaman referensi PHP akan menautkan ke API Java yang mendasarinya.

{{% alert color="info" title="Note" %}}
Anda juga dapat mengedit presentasi dengan [editor PowerPoint online gratis Aspose](https://products.aspose.app/slides/id/editor).
{{% /alert %}} 

## **Tambahkan Hyperlink URL**

Anda dapat menetapkan URL situs web ke teks, bentuk, atau bingkai media. Elemen yang Anda beri hyperlink menentukan area yang dapat diklik: sebagian teks menautkan teks yang dipilih, sementara bentuk atau bingkai menautkan objek slide.

### **Tambahkan Hyperlink URL ke Teks**

Untuk menautkan teks ke situs web, berikan sebuah [Hyperlink](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlink/) ke metode [setHyperlinkClick](https://reference.aspose.com/slides/id/php-java/aspose.slides/portionformat/sethyperlinkclick/) bagian teks, seperti yang ditunjukkan di bawah. Hanya bagian teks itu yang menjadi dapat diklik.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $textShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $textShape->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");
    $portionFormat->setFontHeight(32);

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Tambahkan Hyperlink URL ke Bentuk dan Bingkai Media**

Untuk membuat bentuk atau bingkai dapat diklik, panggil metode [setHyperlinkClick](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/sethyperlinkclick/) miliknya. Hyperlink dimiliki oleh objek itu sendiri, bukan oleh bagian teks di dalamnya.

Pendekatan yang sama berlaku untuk bingkai gambar, audio, dan video: tetapkan hyperlink ke bingkai dan panggil [setTooltip](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlink/settooltip/) bila diperlukan.

Contoh berikut membuat sebuah persegi panjang dapat diklik:

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Gunakan Hyperlink untuk Membuat Daftar Isi**

Hyperlink internal memungkinkan pembaca melompat dari daftar isi ke slide tertentu. Contoh berikut menggunakan [setInternalHyperlinkClick](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) untuk menautkan teks “Page 2” pada slide pertama ke slide kedua.

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $tableOfContents = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $tableOfContents->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getTextFrame()->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");

    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);

    $paragraph->getPortions()->add($linkPortion);
    $tableOfContents->getTextFrame()->getParagraphs()->add($paragraph);

    $presentation->save("link_to_slide.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Format Hyperlink**

### **Warna**

Metode [setColorSource](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlink/setcolorsource/) dari [Hyperlink](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlink/) menentukan apakah hyperlink menggunakan warna hyperlink presentasi atau pemformatan bagian teks. Untuk menerapkan warna teks khusus, pilih [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlinkcolorsource/) dan tetapkan warna isi bagian. Fitur ini diperkenalkan di PowerPoint 2019; versi lebih lama tidak menerapkan pengaturan ini.

Contoh berikut menambahkan dua hyperlink teks ke slide yang sama. Yang pertama menggunakan isi teks merah, sementara yang kedua mempertahankan warna hyperlink default.

```php
use aspose\slides\FillType;
use aspose\slides\Hyperlink;
use aspose\slides\HyperlinkColorSource;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $coloredShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $coloredShape->addTextFrame("This hyperlink uses a custom color.");
    $coloredPortionFormat = $coloredShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $coloredPortionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $coloredPortionFormat->getHyperlinkClick()->setColorSource(HyperlinkColorSource::PortionFormat);
    $coloredPortionFormat->getFillFormat()->setFillType(FillType::Solid);
    $coloredPortionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $defaultShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $defaultShape->addTextFrame("This hyperlink uses the default color.");
    $defaultShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    $presentation->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
### **Suara**

Sebuah hyperlink dapat memutar suara saat diaktifkan atau menghentikan suara yang sedang diputar. Gunakan metode berikut untuk mengonfigurasi perilaku ini:

- [Hyperlink::setSound](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlink/setsound/) menentukan audio yang terkait dengan hyperlink.
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlink/setstopsoundonclick/) mengontrol apakah mengaktifkan hyperlink menghentikan suara sebelumnya.

#### **Tambahkan Suara Hyperlink**

Contoh berikut memuat `sampleaudio.wav` dan mengaitkannya dengan tombol pada slide pertama. Mengklik tombol memutar suara dan menavigasi ke slide berikutnya. Bentuk kedua pada slide itu menghentikan suara sebelumnya ketika diklik, tanpa melakukan aksi navigasi.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $audioFile = new Java("java.io.File", "sampleaudio.wav");
    $audioPath = $audioFile->toPath();
    $audioData = java("java.nio.file.Files")->readAllBytes($audioPath);
    $hyperlinkSound = $presentation->getAudios()->addAudio($audioData);

    $firstSlide = $presentation->getSlides()->get_Item(0);

    $playButton = $firstSlide->getShapes()->addAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
    $playButton->setHyperlinkClick(Hyperlink::getNextSlide());

    if (!java_values($playButton->getHyperlinkClick()->getStopSoundOnClick()) && java_is_null($playButton->getHyperlinkClick()->getSound()))
    {
        $playButton->getHyperlinkClick()->setSound($hyperlinkSound);
    }

    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $stopButton = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
    $stopButton->setHyperlinkClick(Hyperlink::getNoAction());

    $stopButton->getHyperlinkClick()->setStopSoundOnClick(true);

    $presentation->save("hyperlink-sound.pptx", SaveFormat::Pptx);
} catch (JavaException $exception) {
    echo "Unable to read the audio file: " . $exception->getMessage() . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

#### **Ekstrak Suara Hyperlink**

Contoh berikut membuka presentasi yang dibuat di atas dan membaca audio hyperlink bentuk pertama ke memori melalui [getSound](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlink/getsound/) dan [getBinaryData](https://reference.aspose.com/slides/id/php-java/aspose.slides/audio/getbinarydata/).

```php
use aspose\slides\Presentation;

$presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0 && java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) > 0) {
        $hyperlink = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getHyperlinkClick();
        $sound = java_is_null($hyperlink) ? null : $hyperlink->getSound();
        if (!java_is_null($sound)) {
            $audioData = $sound->getBinaryData();
            echo "Extracted " . strlen(java_values($audioData)) . " bytes of hyperlink audio." . PHP_EOL;
        } else {
            echo "The first shape has no hyperlink sound." . PHP_EOL;
        }
    } else {
        echo "The presentation has no first slide or shape to inspect." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Tooltip dan Pengaturan Interaksi**

Anda dapat memanggil metode [Hyperlink](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlink/) berikut setelah menetapkan hyperlink ke teks atau bentuk:

- [setTooltip](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlink/settooltip/) menetapkan teks yang dapat ditampilkan penonton sebagai petunjuk untuk tautan.
- [setTargetFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlink/settargetframe/) menentukan bingkai target dalam satu set bingkai HTML induk, bila berlaku.
- [setHistory](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlink/sethistory/) mengontrol apakah mengaktifkan tautan menambahkan destinasinya ke daftar hyperlink yang telah dilihat.
- [setHighlightClick](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlink/sethighlightclick/) mengontrol apakah hyperlink disorot ketika diklik.

## **Hapus Hyperlink dari Presentasi**

Gunakan [getAnyHyperlinks](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) untuk mengumpulkan kontainer hyperlink, termasuk tautan bagian teks, sebelum mengubahnya. Contoh berikut menghapus kedua tipe aktivasi dari slide pertama. Untuk menghapus hanya satu tipe, panggil hanya [removeHyperlinkClick](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) atau [removeHyperlinkMouseOver](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/); menghapus aksi klik tidak menghapus pasangan mouse-overnya.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0) {
        $containers = [];
        foreach ($presentation->getSlides()->get_Item(0)->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $containers[] = $container;
        }
        foreach ($containers as $container) {
            $container->getHyperlinkManager()->removeHyperlinkClick();
            $container->getHyperlinkManager()->removeHyperlinkMouseOver();
        }
        $presentation->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
    } else {
        echo "The presentation has no slides to process." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Untuk penghapusan tanpa syarat, [removeAllHyperlinks](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) menghapus kedua tipe aktivasi dalam ruang lingkup yang dipilih dalam satu panggilan. Untuk pembersihan selektif dan cakupan master, tata letak, serta catatan, lihat [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Buat Inventaris Hyperlink Lengkap**

Sebelum mendistribusikan presentasi, inventarisasikan aksi interaktif serta tautan webnya. [getAnyHyperlinks](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) mengembalikan objek [IHyperlinkContainer](https://reference.aspose.com/slides/id/java/com.aspose.slides/ihyperlinkcontainer/), bukan daftar datar string URL. Periksa baik [getHyperlinkClick](https://reference.aspose.com/slides/id/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) maupun [getHyperlinkMouseOver](https://reference.aspose.com/slides/id/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) pada setiap kontainer. Mereka independen: kontainer yang sama dapat menampilkan kedua aksi, sehingga laporan lengkap membutuhkan hingga dua baris per kontainer.

Pemindaian hanya hyperlink tingkat bentuk dapat melewatkan tautan yang terlampir pada bagian teks. Kueri ruang lingkup yang tepat sebagai gantinya, dan simpan kontainer yang dikembalikan sehingga Anda dapat memperbarui atau menghapus aksi mereka nanti.

### **Kueri Ruang Lingkup Presentasi, Slide, dan Bingkai Teks**

Kelas [HyperlinkQueries](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlinkqueries/) tersedia melalui [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/gethyperlinkqueries/), [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), dan [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/gethyperlinkqueries/). Setiap ruang lingkup mendukung kueri yang sama:

- [getHyperlinkClicks](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) mengembalikan kontainer dengan aksi klik.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) mengembalikan kontainer dengan aksi mouse-over.
- [getAnyHyperlinks](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) mengembalikan kontainer dengan salah satu atau kedua aksi.

Contoh berikut membuat `hyperlink-audit-input.pptx` dengan tautan klik eksternal, tautan mouse-over berkas, navigasi slide internal, tautan mouse-over teks, dan aksi makro. Contoh tidak mengeksekusi tindakan apa pun. Ketiga kueri yang sama berfungsi pada setiap ruang lingkup; hitungan menggambarkan kontainer, bukan total aksi. Ruang lingkup bingkai teks mengecualikan tautan milik bentuk yang mengelilinginya.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function printQueryCounts($scope, $queries) {
    $clickCount = java_values($queries->getHyperlinkClicks()->size());
    $mouseOverCount = java_values($queries->getHyperlinkMouseOvers()->size());
    $anyCount = java_values($queries->getAnyHyperlinks()->size());
    echo "$scope: click=$clickCount, mouse-over=$mouseOverCount, any=$anyCount" . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addEmptySlide($slide->getLayoutSlide());
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Click the text to go to slide 2");
    $shape->getHyperlinkManager()->setExternalHyperlinkClick("https://example.com/");
    $shape->getHyperlinkClick()->setTooltip("Public website");
    $shape->getHyperlinkManager()->setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    $portionFormat = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->getHyperlinkManager()->setInternalHyperlinkClick($destination);
    $portionFormat->getHyperlinkManager()->setExternalHyperlinkMouseOver("https://example.com/help");
    $macroButton = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
    $macroButton->getHyperlinkManager()->setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", $presentation->getHyperlinkQueries());
    printQueryCounts("Slide 1", $slide->getHyperlinkQueries());
    printQueryCounts("Text frame", $shape->getTextFrame()->getHyperlinkQueries());
    $presentation->save("hyperlink-audit-input.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Untuk contoh ini, kueri presentasi dan slide masing‑masing melaporkan tiga kontainer klik, dua kontainer mouse‑over, dan tiga kontainer dengan salah satu aksi. Kueri bingkai teks melaporkan satu kontainer di setiap kategori.

### **Klasifikasikan Aksi dan Tujuan**

Gunakan [Hyperlink::getActionType](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlink/getactiontype/) untuk menafsirkan aksi sebelum menafsirkan tujuannya. Nilai [HyperlinkActionType](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlinkactiontype/) mencakup lebih dari sekadar navigasi web:

| Nilai | Arti untuk audit |
| --- | --- |
| `Hyperlink` | Hyperlink eksternal; periksa URL dan skemanya. |
| `JumpSpecificSlide` | Navigasi internal ke slide tertentu. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navigasi slideshow bawaan, diselesaikan dalam konteks slideshow. |
| `JumpEndShow`, `StartCustomSlideShow` | Mengakhiri pertunjukan saat ini atau memulai pertunjukan khusus. |
| `StartMacro` | Menjalankan makro. |
| `StartProgram` | Meluncurkan program. |
| `OpenFile`, `OpenPresentation` | Membuka berkas atau presentasi lain; tinjau terpisah dari URL web. |
| `StartStopMedia` | Memulai atau menghentikan pemutaran media. |
| `NoAction`, `Unknown` | Tidak ada aksi navigasi, atau aksi tidak dikenali yang memerlukan peninjauan. |

Baca tujuan eksternal dari [getExternalUrl](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlink/getexternalurl/) dan tujuan internal spesifik dari [getTargetSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlink/gettargetslide/). Aksi internal dan perintah bawaan mungkin tidak memiliki URL eksternal; URL kosong tidak berarti kontainer tidak memiliki aksi. Simpan nilai yang dikembalikan oleh [getExternalUrlOriginal](https://reference.aspose.com/slides/id/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) bila berbeda dari URL yang dinormalkan, dan sertakan tooltip yang dikembalikan oleh [getTooltip](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlink/gettooltip/) bila tersedia.

### **Laporan, Sanitasi, dan Verifikasi Hyperlink**

Contoh PHP berikut membaca presentasi yang ada (gunakan berkas yang dibuat di atas), menulis `hyperlink-audit.json`, menerapkan kebijakan, menyimpan `hyperlink-sanitized.pptx`, dan membukanya kembali untuk memeriksa kembali kedua tipe aktivasi. Contoh mengumpulkan kontainer sebelum mengubahnya dan menggunakan kesetaraan referensi untuk menghindari memproses kontainer yang sama dua kali. Kueri presentasi mencakup slide biasa; untuk inventaris seluruh paket, contoh juga secara eksplisit mengkueri master, tata letak, catatan, serta master catatan dan handout bila ada.

Laporan mencatat indeks slide berbasis satu dan [getSlideId](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibaseslide/#getSlideId--) bila tersedia. [ISlideComponent::getSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/islidecomponent/#getSlide--) menyediakan slide pemilik untuk kontainer yang didukung. Master, tata letak, dan catatan tidak memiliki indeks slide biasa dan diidentifikasi oleh ruang lingkupnya. Kontainer bentuk dan kontainer pemformatan bagian teks diberi label terpisah; tipe kontainer lain mempertahankan nama tipe runtime mereka. Setiap kontainer mendapat ID lokal laporan sehingga dua aksinya dapat dikaitkan. Laporan menyimpan tipe aksi sebagai konstanta integer yang didefinisikan oleh enumerasi PHP.

Kebijakan aplikasi yang sengaja restriktif ini hanya memperbolehkan URL HTTPS absolut dan target slide internal yang valid. Kebijakan menolak makro, program, aksi berkas, aksi slideshow lain, aksi tak dikenal, dan skema URL lain. Penolakan tersebut adalah keputusan kebijakan, bukan penilaian keamanan Aspose.Slides. HTTPS saja tidak menjamin kepercayaan: tambahkan daftar izinkan host dan pemeriksaan lain untuk aplikasi Anda. Baik URL eksternal asli maupun yang dinormalkan diperiksa. Contoh mengaudit metadata tanpa mengikuti tautan atau menjalankan aksi.

Untuk remediasi, [getHyperlinkManager](https://reference.aspose.com/slides/id/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) kontainer mendukung [setExternalHyperlinkClick](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), [removeHyperlinkClick](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/), dan [removeHyperlinkMouseOver](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/). Di sini, tautan klik eksternal yang dilarang digantikan dengan halaman landing HTTPS tetap; klik terlarang lain dan aksi mouse‑over terlarang dihapus secara independen. Atur `$replaceExternalClicks` ke `false` untuk menghapus semua pelanggaran kebijakan. Pilih halaman pengganti milik aplikasi sebelum penyebaran.

Flag ekspor laporan menggunakan kebijakan peninjauan PDF yang konservatif: beri flag aksi mouse‑over dan apa pun selain tautan eksternal atau loncatan slide spesifik sebagai kemungkinan tidak didukung. Ini hanyalah petunjuk peninjauan, bukan tes kemampuan atau jaminan bahwa tautan yang tidak terflag akan bertahan saat diekspor. Ekspor PDF dan HTML yang didukung mungkin mempertahankan hyperlink, tergantung pada aksi, opsi ekspor, dan penampil. Gambar raster dan video tidak dapat mempertahankan hyperlink interaktif; beri flag setiap aksi ketika mengaudit untuk output tersebut.

```php
use aspose\slides\HyperlinkActionType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class HyperlinkAudit {
    public function slideIndex($presentation, $slide) {
        if (java_is_null($slide)) return null;
        for ($index = 0; $index < java_values($presentation->getSlides()->size()); $index++) {
            if (java_values($presentation->getSlides()->get_Item($index)->equals($slide))) return $index + 1;
        }
        return null;
    }

    public function isHttps($value) {
        if ($value === null || $value === '') return false;
        $parts = parse_url($value);
        return $parts !== false && isset($parts['scheme'], $parts['host']) && strcasecmp($parts['scheme'], 'https') === 0 && $parts['host'] !== '';
    }

    public function policyViolation($link) {
        if (java_is_null($link)) return null;
        $action = java_values($link->getActionType());
        if ($action === HyperlinkActionType::JumpSpecificSlide) {
            return java_is_null($link->getTargetSlide()) ? 'Missing target slide' : null;
        }
        if ($action !== HyperlinkActionType::Hyperlink) return 'Action is not allowed';
        if (!$this->isHttps(java_values($link->getExternalUrl()))) return 'Normalized URL is not absolute HTTPS';
        $original = java_values($link->getExternalUrlOriginal());
        if ($original !== null && $original !== '' && !$this->isHttps($original)) return 'Original URL is not absolute HTTPS';
        return null;
    }

    public function addScope(&$found, $slide) {
        if (!java_is_null($slide)) {
            foreach ($slide->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
                $found[] = $container;
            }
        }
    }

    public function collectContainers($presentation) {
        $found = [];
        foreach ($presentation->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $found[] = $container;
        }
        $masters = $presentation->getMasters();
        for ($index = 0; $index < java_values($masters->size()); $index++) {
            $this->addScope($found, $masters->get_Item($index));
        }
        $layouts = $presentation->getLayoutSlides();
        for ($index = 0; $index < java_values($layouts->size()); $index++) {
            $this->addScope($found, $layouts->get_Item($index));
        }
        $slides = $presentation->getSlides();
        for ($index = 0; $index < java_values($slides->size()); $index++) {
            $this->addScope($found, $slides->get_Item($index)->getNotesSlideManager()->getNotesSlide());
        }
        $this->addScope($found, $presentation->getMasterNotesSlideManager()->getMasterNotesSlide());
        $this->addScope($found, $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide());
        $seen = new Java('java.util.IdentityHashMap');
        $unique = [];
        foreach ($found as $container) {
            if (!java_values($seen->containsKey($container))) {
                $seen->put($container, true);
                $unique[] = $container;
            }
        }
        return $unique;
    }

    public function addRow(&$rows, $presentation, $link, $activation, $container, $containerId) {
        if (java_is_null($link)) return;
        $ownerSlide = java_instanceof($container, java('com.aspose.slides.ISlideComponent')) ? $container->getSlide() : null;
        $targetSlide = $link->getTargetSlide();
        $violation = $this->policyViolation($link);
        $ownerType = java_instanceof($container, java('com.aspose.slides.IShape')) ? 'Shape' : (java_instanceof($container, java('com.aspose.slides.IPortionFormat')) ? 'Text portion' : java_values($container->getClass()->getSimpleName()));
        $action = java_values($link->getActionType());
        $ordinaryAction = $action === HyperlinkActionType::Hyperlink || $action === HyperlinkActionType::JumpSpecificSlide;
        $externalUrl = java_values($link->getExternalUrl());
        $originalUrl = java_values($link->getExternalUrlOriginal());
        $rows[] = [
            'ContainerId' => $containerId,
            'SlideIndex' => $this->slideIndex($presentation, $ownerSlide),
            'SlideId' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getSlideId()),
            'Scope' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getClass()->getSimpleName()),
            'OwnerType' => $ownerType,
            'Activation' => $activation,
            'ActionType' => $action,
            'ExternalUrl' => $externalUrl,
            'TargetSlideIndex' => $this->slideIndex($presentation, $targetSlide),
            'TargetSlideId' => java_is_null($targetSlide) ? null : java_values($targetSlide->getSlideId()),
            'Tooltip' => java_values($link->getTooltip()),
            'OriginalExternalUrl' => $originalUrl === $externalUrl ? null : $originalUrl,
            'PotentiallyUnsafe' => $violation !== null,
            'PolicyViolation' => $violation,
            'TargetExport' => 'PDF',
            'PotentiallyUnsupportedByExport' => $activation === 'mouse-over' || !$ordinaryAction
        ];
    }
}

$replaceExternalClicks = true;
$replacementUrl = 'https://example.com/blocked-link';
$audit = new HyperlinkAudit();
$presentation = new Presentation('hyperlink-audit-input.pptx');
try {
    $containers = $audit->collectContainers($presentation);
    $rows = [];
    foreach ($containers as $index => $container) {
        $audit->addRow($rows, $presentation, $container->getHyperlinkClick(), 'click', $container, $index + 1);
        $audit->addRow($rows, $presentation, $container->getHyperlinkMouseOver(), 'mouse-over', $container, $index + 1);
    }
    $json = json_encode($rows, JSON_PRETTY_PRINT | JSON_UNESCAPED_SLASHES);
    if ($json === false) {
        echo 'Unable to encode the audit report: ' . json_last_error_msg() . PHP_EOL;
    } elseif (file_put_contents('hyperlink-audit.json', $json . PHP_EOL) === false) {
        echo 'Unable to write the audit report.' . PHP_EOL;
    } else {
        foreach ($containers as $container) {
            $click = $container->getHyperlinkClick();
            if ($audit->policyViolation($click) !== null) {
                if ($replaceExternalClicks && java_values($click->getActionType()) === HyperlinkActionType::Hyperlink) {
                    $container->getHyperlinkManager()->setExternalHyperlinkClick($replacementUrl);
                } else {
                    $container->getHyperlinkManager()->removeHyperlinkClick();
                }
            }
            if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) {
                $container->getHyperlinkManager()->removeHyperlinkMouseOver();
            }
        }
        $presentation->save('hyperlink-sanitized.pptx', SaveFormat::Pptx);

        $reopened = new Presentation('hyperlink-sanitized.pptx');
        try {
            $remainingContainers = $audit->collectContainers($reopened);
            $violations = 0;
            foreach ($remainingContainers as $container) {
                if ($audit->policyViolation($container->getHyperlinkClick()) !== null) $violations++;
                if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) $violations++;
            }
            echo 'Audit rows: ' . count($rows) . '; prohibited actions after reopening: ' . $violations . PHP_EOL;
            if ($violations !== 0) {
                echo 'Verification failed: do not distribute the saved presentation.' . PHP_EOL;
            }
        } finally {
            $reopened->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

Dengan input yang dibuat di atas, laporan berisi lima baris aksi. Tautan mouse‑over berkas dan klik makro dihapus, sementara tautan HTTPS dan navigasi slide internal tetap. Verifikasi mencetak nol aksi terlarang. Input yang berisi URL klik eksternal terlarang juga menguji cabang penggantian. Kontainer dengan klik yang diizinkan dan mouse‑over terlarang mempertahankan aksi kliknya.

Pembersihan selektif ini berbeda dari [removeAllHyperlinks](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/), yang menghapus kedua tipe aktivasi di seluruh ruang lingkup terpilih tanpa memperhatikan kebijakan. Verifikasi di sini hanya memeriksa aksi hyperlink; tidak menghapus proyek VBA tertanam, objek OLE, atau konten aktif lainnya, dan tidak memvalidasi berkas PDF atau HTML yang diekspor.

## **FAQ**

**Bagaimana saya dapat menautkan ke sebuah bagian atau slide pertamanya?**

Bagian di PowerPoint mengelompokkan slide, tetapi hyperlink internal menargetkan slide individu. Untuk membuat navigasi ke sebuah bagian, tautkan ke slide pertama dalam bagian tersebut.

**Apakah saya dapat menempelkan hyperlink pada elemen master slide sehingga berfungsi pada semua slide?**

Ya. Elemen master slide dan tata letak mendukung hyperlink. Tautan pada elemen ini tersedia selama pertunjukan slide pada slide yang menggunakan master atau tata letak yang bersangkutan.

**Apakah hyperlink akan dipertahankan saat mengekspor ke PDF, HTML, gambar, atau video?**

Ekspor PDF dan HTML yang didukung mungkin mempertahankan hyperlink; gambar raster dan video tidak dapat. Lihat pertimbangan ekspor pada [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).