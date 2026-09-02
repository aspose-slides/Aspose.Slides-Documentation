---
title: Mengambil dan Memperbarui Informasi Presentasi di PHP
linktitle: Informasi Presentasi
type: docs
weight: 30
url: /id/php-java/examine-presentation/
keywords:
- format presentasi
- properti presentasi
- properti dokumen
- mengambil properti
- membaca properti
- mengubah properti
- memodifikasi properti
- memperbarui properti
- memeriksa PPTX
- memeriksa PPT
- memeriksa ODP
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Jelajahi slide, struktur, dan metadata dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk PHP untuk wawasan yang lebih cepat dan audit konten yang lebih cerdas."
---
## **Gambaran Umum**

Aspose.Slides dapat mengidentifikasi format sebuah presentasi dan membaca metadata dokumen tanpa membuat model objek presentasi yang lengkap. Ini berguna ketika Anda perlu mengklasifikasikan file, membangun inventaris, atau memeriksa properti sebelum memutuskan apakah akan memuat dan memproses konten presentasi.

Artikel ini menunjukkan inspeksi ringan melalui [PresentationFactory](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationfactory/) dan [PresentationInfo](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationinfo/), serta pembaruan yang ditargetkan melalui [DocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/documentproperties/).

## **Periksa Format Presentasi**

Gunakan [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationfactory/) untuk memeriksa sebuah file tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/). Metode [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationinfo/#getLoadFormat) melaporkan format yang terdeteksi, seperti PPTX, PPT, atau ODP.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

foreach ($fileNames as $fileName) {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($fileName);
    $loadFormat = java_values($presentationInfo->getLoadFormat());
    $formatName = "Other (" . $loadFormat . ")";

    if ($loadFormat === LoadFormat::Pptx) {
        $formatName = "PPTX";
    } elseif ($loadFormat === LoadFormat::Ppt) {
        $formatName = "PPT";
    } elseif ($loadFormat === LoadFormat::Odp) {
        $formatName = "ODP";
    }

    echo $fileName . ": " . $formatName . PHP_EOL;
}
```

## **Bangun Inventaris Presentasi Ringan**

Saat Anda memproses banyak file presentasi, Anda mungkin memerlukan inventaris yang kompak untuk validasi, pengindeksan, atau sistem manajemen dokumen. Dalam skenario ini, gunakan [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationfactory/) untuk memperoleh objek [PresentationInfo](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationinfo/), lalu panggil [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationinfo/#readDocumentProperties) untuk membaca metadata dokumen. Pendekatan ini tidak membuat instance [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) atau mengharuskan Anda menelusuri model objek presentasi secara lengkap.

Properti tambahan yang diekspos oleh [DocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/documentproperties/) menyediakan nilai inventaris berikut:

| Metode | Nilai inventaris |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/documentproperties/#getSlides) | Total jumlah slide. |
| [getHiddenSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/documentproperties/#getHiddenSlides) | Jumlah slide tersembunyi. |
| [getNotes](https://reference.aspose.com/slides/id/php-java/aspose.slides/documentproperties/#getNotes) | Jumlah slide yang berisi catatan. |
| [getParagraphs](https://reference.aspose.com/slides/id/php-java/aspose.slides/documentproperties/#getParagraphs) | Total jumlah paragraf, bila tersedia. |
| [getWords](https://reference.aspose.com/slides/id/php-java/aspose.slides/documentproperties/#getWords) | Total jumlah kata. |
| [getMultimediaClips](https://reference.aspose.com/slides/id/php-java/aspose.slides/documentproperties/#getMultimediaClips) | Total jumlah klip audio dan video. |

Contoh berikut membaca nilai‑nilai ini tanpa membuat objek [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) dan mencetak inventaris yang kompak. Ia juga menggabungkan [DocumentProperties::getHeadingPairs](https://reference.aspose.com/slides/id/php-java/aspose.slides/documentproperties/#getHeadingPairs) dengan [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/id/php-java/aspose.slides/documentproperties/#getTitlesOfParts) untuk menampilkan grup konten seperti font, tema, dan judul slide.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$filePath = "sample.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);
$documentProperties = $presentationInfo->readDocumentProperties();

$loadFormat = java_values($presentationInfo->getLoadFormat());
$formatName = "Other (" . $loadFormat . ")";

if ($loadFormat === LoadFormat::Pptx) {
    $formatName = "PPTX";
} elseif ($loadFormat === LoadFormat::Ppt) {
    $formatName = "PPT";
} elseif ($loadFormat === LoadFormat::Odp) {
    $formatName = "ODP";
}

echo "File: " . basename($filePath) . PHP_EOL;
echo "Format: " . $formatName . PHP_EOL;
echo "Title: " . java_values($documentProperties->getTitle()) . PHP_EOL;
echo "Author: " . java_values($documentProperties->getAuthor()) . PHP_EOL;
echo "Statistics:" . PHP_EOL;
echo "  Slides: " . java_values($documentProperties->getSlides()) . PHP_EOL;
echo "  Hidden slides: " . java_values($documentProperties->getHiddenSlides()) . PHP_EOL;
echo "  Slides with notes: " . java_values($documentProperties->getNotes()) . PHP_EOL;
echo "  Paragraphs: " . java_values($documentProperties->getParagraphs()) . PHP_EOL;
echo "  Words: " . java_values($documentProperties->getWords()) . PHP_EOL;
echo "  Multimedia clips: " . java_values($documentProperties->getMultimediaClips()) . PHP_EOL;

$headingPairs = $documentProperties->getHeadingPairs();
$titlesOfParts = $documentProperties->getTitlesOfParts();

if (java_is_null($headingPairs) || java_is_null($titlesOfParts)) {
    echo "Content groups: not available" . PHP_EOL;
} else {
    $headingPairs = java_values($headingPairs);
    $titlesOfParts = java_values($titlesOfParts);
    $partIndex = 0;

    if (count($headingPairs) === 0 || count($titlesOfParts) === 0) {
        echo "Content groups: not available" . PHP_EOL;
    } else {
        echo "Content groups:" . PHP_EOL;

        foreach ($headingPairs as $headingPair) {
            $partCount = java_values($headingPair->getCount());
            echo "  " . java_values($headingPair->getName()) . " (" . $partCount . ")" . PHP_EOL;

            for ($partOffset = 0; $partOffset < $partCount && $partIndex < count($titlesOfParts); $partOffset++) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }

        if ($partIndex < count($titlesOfParts)) {
            echo "  Other parts:" . PHP_EOL;

            while ($partIndex < count($titlesOfParts)) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }
    }
}
```

Setiap [HeadingPair](https://reference.aspose.com/slides/id/php-java/aspose.slides/headingpair/) menyediakan nama grup dan jumlah item dalam grup tersebut. [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/id/php-java/aspose.slides/documentproperties/#getTitlesOfParts) mengembalikan array datar yang berurutan, jadi konsumsi jumlah judul berurutan yang ditentukan oleh setiap pasangan heading.

### **Metadata yang Disimpan dan Batasan Format**

Properti inventaris yang dikembalikan oleh [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationinfo/#readDocumentProperties) mencerminkan metadata yang tersedia dalam dokumen sumber. Aspose.Slides tidak memuat dan menelusuri model objek presentasi untuk menghitung ulang nilai‑nilai ini pada pemanggilan ini. Properti yang tidak ada direpresentasikan oleh nilai default, dan nilai yang disimpan dapat usang jika aplikasi yang terakhir menyimpan file tidak memperbarui properti dokumennya.

- **PPTX:** Format ini menyediakan properti dokumen tambahan untuk hitungan slide, catatan, slide tersembunyi, paragraf, kata, dan multimedia, serta pasangan heading dan judul bagian. Ketersediaannya tergantung pada properti mana yang ditulis oleh pembuat dokumen.
- **PPT:** Format biner dapat menyimpan properti ringkasan dokumen yang bersesuaian. Jika sebuah properti tidak ada atau tidak diperbarui oleh pembuat dokumen, Aspose.Slides mengembalikan nilai yang disimpan atau nilai default alih‑alih menghitungnya dari slide.
- **ODP:** Metadata OpenDocument menyediakan statistik dokumen umum, seperti hitungan halaman, paragraf, dan kata, tetapi nilai‑nilai ini tidak dipetakan ke setiap properti tambahan khusus PowerPoint. Metadata slide tersembunyi, slide catatan, multimedia, heading‑pair, dan judul bagian mungkin tidak tersedia, dan properti inventaris dapat mengembalikan nilai default. Jangan menganggap nilai nol atau array kosong sebagai bukti otoritatif bahwa konten terkait tidak ada.

Gunakan pendekatan metadata ringan untuk inventaris dan pemeriksaan awal. Muat presentasi dan inspeksi model objeknya yang aktif ketika hasil harus mencerminkan perubahan di memori atau ketika Anda perlu memverifikasi konten presentasi yang sebenarnya.

## **Perbarui Properti Presentasi**

Properti yang dikembalikan oleh [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationinfo/#readDocumentProperties) juga dapat diubah tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) . Terapkan perubahan dengan [PresentationInfo::updateDocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationinfo/#updateDocumentProperties), kemudian tulis presentasi yang terikat dengan [PresentationInfo::writeBindedPresentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationinfo/#writeBindedPresentation).

Gambar berikut menunjukkan properti dokumen asli dari presentasi PowerPoint.

![Properti dokumen asli dari presentasi PowerPoint](input_properties.png)

Contoh berikut mengubah judul dan waktu terakhir disimpan serta menulis hasilnya ke file baru:

```php
use aspose\slides\PresentationFactory;

$sourceFile = "sample.pptx";
$outputFile = "sample_with_updated_properties.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($sourceFile);
$documentProperties = $presentationInfo->readDocumentProperties();

$documentProperties->setTitle("Quarterly sales report");
$documentProperties->setLastSavedTime(new Java("java.util.Date"));

$presentationInfo->updateDocumentProperties($documentProperties);
$outputStream = new Java("java.io.FileOutputStream", $outputFile);
try {
    $presentationInfo->writeBindedPresentation($outputStream);
} finally {
    $outputStream->close();
}
```

Gambar berikut menunjukkan properti dokumen yang diubah dari presentasi PowerPoint.

![Properti dokumen yang diubah dari presentasi PowerPoint](output_properties.png)

## **Tautan Berguna**

Untuk pemeriksaan keamanan terkait dan pengaturan perlindungan, lihat artikel berikut:

- [Presentasi yang Dilindungi Kata Sandi](/slides/id/php-java/password-protected-presentation/)
- [Presentasi yang Dilindungi Penulisan](/slides/id/php-java/write-protected-presentation/)

## **Tanya Jawab**

**Bagaimana saya dapat memeriksa apakah font tertanam dan yang mana?**

Muat presentasi dan gunakan [Presentation::getFontsManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getFontsManager). Panggil [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) untuk memperoleh font yang tertanam dan [FontsManager::getFonts](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/#getFonts) untuk memperoleh font yang digunakan oleh presentasi. Bandingkan kedua hasil untuk menemukan font yang diperlukan untuk rendering tetapi tidak tertanam.

**Bagaimana saya dapat dengan cepat mengetahui apakah file memiliki slide tersembunyi dan berapa banyak?**

Ketika metadata dokumen yang disimpan cukup, baca [DocumentProperties::getHiddenSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/documentproperties/#getHiddenSlides) melalui [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationfactory/) dan [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationinfo/#readDocumentProperties). Ini cocok untuk inventaris ringan. Jika presentasi telah dimodifikasi di memori, metadata yang disimpan mungkin tidak ada atau usang, atau Anda perlu memverifikasi nilai hidup, iterasi melalui [Presentation::getSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getSlides) dan inspeksi metode [Slide::getHidden](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/#getHidden) tiap slide sebagai gantinya.

**Apakah saya dapat mendeteksi apakah ukuran slide khusus dan orientasi digunakan, serta apakah berbeda dari default?**

Ya. Muat presentasi dan panggil [Presentation::getSlideSize](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getSlideSize). Gunakan [SlideSize::getType](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidesize/#getType), [SlideSize::getSize](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidesize/#getSize), dan [SlideSize::getOrientation](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidesize/#getOrientation) untuk membandingkan pengaturan saat ini dengan preset dan dimensi yang diharapkan.

**Apakah ada cara cepat untuk melihat apakah bagan merujuk sumber data eksternal?**

Ya. Temukan setiap [Chart](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/) dan panggil [ChartData::getDataSourceType](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/#getDataSourceType). Untuk buku kerja eksternal, panggil [ChartData::getExternalWorkbookPath](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/#getExternalWorkbookPath). Tipe sumber data dan jalur mengidentifikasi referensi eksternal, namun memverifikasi apakah target tersedia memerlukan pemeriksaan sumber daya terpisah.

**Bagaimana saya dapat menilai slide “berat” yang mungkin memperlambat rendering atau ekspor PDF?**

Tidak ada properti kompleksitas tunggal. Telusuri [Presentation::getSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getSlides) dan koleksi [BaseSlide::getShapes](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseslide/#getShapes) tiap slide. Gunakan jumlah shape serta kehadiran gambar besar, efek, animasi, atau multimedia sebagai sinyal penyaringan, dan ukur rendering atau ekspor representatif sebelum menganggap sebuah slide sebagai bottleneck kinerja yang pasti.