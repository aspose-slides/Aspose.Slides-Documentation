---
title: Gabungkan Presentasi Secara Efisien di PHP
linktitle: Gabungkan Presentasi
type: docs
weight: 40
url: /id/php-java/merge-presentation/
keywords:
- gabungkan PowerPoint
- gabungkan presentasi
- gabungkan slide
- gabungkan PPT
- gabungkan PPTX
- gabungkan ODP
- gabungkan PowerPoint
- gabungkan presentasi
- gabungkan slide
- gabungkan PPT
- gabungkan PPTX
- gabungkan ODP
- PHP
- Aspose.Slides
description: "Pelajari cara menggabungkan presentasi PowerPoint dan OpenDocument di PHP dengan menyalin slide, mengontrol master dan layout, mengubah ukuran konten slide, mempertahankan bagian, serta menangani file yang dilindungi atau berukuran besar."
---
## **Ringkasan**

Aspose.Slides untuk PHP via Java menggabungkan presentasi dengan menyalin slide dari satu [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) ke yang lain. Operasi utama adalah [SlideCollection::addClone()](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidecollection/addclone/), yang dapat mempertahankan format slide sumber atau menempelkan slide yang disalin ke master atau layout di presentasi tujuan.

Artikel ini mencakup alur kerja penggabungan yang paling umum:

- menggabungkan semua slide sambil mempertahankan format sumbernya;
- menggabungkan slide terpilih;
- menerapkan master dari presentasi tujuan;
- menerapkan layout tertentu dari presentasi tujuan;
- menormalkan ukuran slide yang berbeda sebelum digabungkan;
- menambahkan slide yang disalin ke sebuah bagian;
- menggabungkan beberapa presentasi dalam satu alur kerja end-to-end;
- menangani master, sumber daya, catatan, komentar, media, font, kata sandi, file besar, dan masalah multithreading.

## **Bagaimana Penyalinan Slide Mempengaruhi Master dan Layout**

Sebuah slide mewarisi banyak tampilan visualnya dari layout dan master. Oleh karena itu, overload penyalinan yang Anda pilih menentukan bagaimana slide yang digabungkan diintegrasikan ke dalam presentasi tujuan.

Gunakan [SlideCollection::addClone()](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidecollection/addclone/) dengan salah satu cara berikut:

- `addClone(sourceSlide)` — mempertahankan layout dan format slide sumber. Jika diperlukan, master sumber dapat disalin secara otomatis ke dalam presentasi tujuan. Aspose.Slides melacak master yang disalin secara otomatis sehingga slide berulang yang menggunakan master sumber yang sama tidak menyebabkan master tersebut disalin berulang kali.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — menempelkan slide yang disalin ke [MasterSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslide/) tujuan tertentu. Aspose.Slides mencari layout yang cocok di bawah master tersebut berdasarkan tipe atau nama layout.
- `addClone(sourceSlide, destinationLayout)` — menempelkan slide yang disalin langsung ke [LayoutSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutslide/) tujuan tertentu.

Master atau layout yang diberikan ke overload `addClone` harus berasal dari **presentasi tujuan**, bukan dari presentasi sumber.

## **Gabungkan Seluruh Presentasi dan Pertahankan Format Sumber**

Penggabungan paling sederhana menyalin setiap slide dari presentasi sumber ke presentasi tujuan. Ini merupakan pilihan yang tepat ketika slide yang diimpor harus menjaga tema, master, dan hubungan layout aslinya.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Presentasi yang dihasilkan mungkin berisi beberapa master ketika sumber dan tujuan menggunakan desain yang berbeda. Hal ini diharapkan ketika format sumber sengaja dipertahankan.

## **Gabungkan Slide Terpilih**

Anda tidak harus menyalin setiap slide. Contoh berikut mengimpor hanya indeks slide terpilih dari presentasi sumber.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $slideIndexes = [0, 2, 4];

        foreach ($slideIndexes as $index) {
            $destination->getSlides()->addClone($source->getSlides()->get_Item($index));
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-selected-slides.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Validasi indeks slide sebelum menyalin ketika indeks tersebut berasal dari input pengguna atau konfigurasi eksternal.

## **Gabungkan Slide Menggunakan Master Tujuan**

Gunakan overload [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidecollection/addclone/) ketika slide yang diimpor harus mengikuti master yang sudah menjadi bagian dari presentasi tujuan.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationMaster = $destination->getMasters()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationMaster, true);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-master.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Aspose.Slides memilih layout yang sesuai di bawah master yang ditentukan dengan mencocokkan tipe atau nama layout sumber. Jika tidak ada layout yang cocok dan `allowCloneMissingLayout` bernilai `true`, layout sumber akan disalin sehingga slide dapat ditambahkan. Jika bernilai `false`, sebuah [PptxEditException](https://reference.aspose.com/slides/id/php-java/aspose.slides/pptxeditexception/) akan dilempar.

Gunakan `false` ketika Anda ingin penggabungan gagal daripada menambahkan layout tambahan ke master tujuan.

## **Gabungkan Slide Menggunakan Layout Tujuan Tertentu**

Gunakan overload [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidecollection/addclone/) ketika Anda sudah mengetahui layout tujuan mana yang harus digunakan oleh slide yang diimpor.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationLayout = $destination->getLayoutSlides()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationLayout);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-layout.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Menerapkan layout tujuan mengubah hubungan layout yang diwarisi; hal ini tidak merancang ulang konten slide sumber. Jika layout sumber dan tujuan memiliki struktur placeholder yang berbeda, periksa hasilnya untuk memastikan bahwa format yang diwarisi dan perilaku placeholder sudah tepat.

## **Gabungkan Presentasi dengan Ukuran Slide Berbeda**

Presentasi dengan dimensi slide yang berbeda dapat digabungkan, tetapi menyalin slide ke presentasi dengan ukuran slide lain tidak secara otomatis merancang ulang kontennya untuk kanvas baru. Oleh karena itu, bentuk dapat terlihat bergeser, berubah skala secara tak terduga, atau berada di luar area slide yang terlihat.

Pendekatan praktis adalah mengubah ukuran presentasi sumber sebelum menyalin. Metode [SlideSize::setSize()](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidesize/setsize/) dapat menskalakan konten yang ada sambil mengubah dimensi slide. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidesizescaletype/) menskalakan konten agar muat dalam ukuran yang diminta.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
        $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());
        $destinationWidth = java_values($destination->getSlideSize()->getSize()->getWidth());
        $destinationHeight = java_values($destination->getSlideSize()->getSize()->getHeight());

        if ($sourceWidth != $destinationWidth || $sourceHeight != $destinationHeight) {
            $source->getSlideSize()->setSize($destinationWidth, $destinationHeight, SlideSizeScaleType::EnsureFit);
        }

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-same-slide-size.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Mengubah ukuran mengubah objek presentasi sumber dalam memori. Jika Anda memerlukan presentasi sumber asli tetap tidak berubah untuk operasi lain, buka instance terpisah untuk penggabungan.

## **Gabungkan Slide ke Bagian Presentasi**

Loop penyalinan slide dasar tidak membuat kembali hierarki bagian (section) presentasi sumber. Jika bagian penting dalam output, buat atau pilih bagian di presentasi tujuan dan salin slide ke dalamnya secara eksplisit dengan [addClone(Slide, Section)](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidecollection/addclone/).

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $importedSection = $destination->getSections()->appendEmptySection("Imported slides");

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $importedSection);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-section.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Slide yang disalin ditambahkan ke bagian tujuan yang ditentukan. Untuk mempertahankan beberapa bagian sumber, enumerasi [Presentation::getSections](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation/#getSections), ambil slide saat ini dari tiap bagian sumber dengan [Section::getSlidesListOfSection](https://reference.aspose.com/slides/id/php-java/aspose.slides/Section/#getSlidesListOfSection), buat kembali bagian di tujuan, dan salin tiap slide yang dikembalikan ke bagian tujuan yang bersesuaian. Lihat [Manage Slide Sections](/slides/id/php-java/slide-section/) untuk contoh enumerasi bagian lengkap, termasuk bagian kosong dan perubahan struktural.

## **Gabungkan Beberapa Presentasi dengan Aman**

Contoh end-to-end berikut menggunakan presentasi pertama sebagai tujuan, menormalkan ukuran slide setiap sumber tambahan, membuka tiap sumber hanya saat sedang disalin, dan menyimpan file akhir sekali saja.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

$merged = new Presentation($inputFiles[0]);
try {
    $mergedWidth = java_values($merged->getSlideSize()->getSize()->getWidth());
    $mergedHeight = java_values($merged->getSlideSize()->getSize()->getHeight());

    for ($fileIndex = 1; $fileIndex < count($inputFiles); $fileIndex++) {
        $source = new Presentation($inputFiles[$fileIndex]);
        try {
            $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
            $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());

            if ($sourceWidth != $mergedWidth || $sourceHeight != $mergedHeight) {
                $source->getSlideSize()->setSize($mergedWidth, $mergedHeight, SlideSizeScaleType::EnsureFit);
            }

            foreach ($source->getSlides() as $slide) {
                $merged->getSlides()->addClone($slide);
            }
        } finally {
            $source->dispose();
        }
    }

    $merged->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $merged->dispose();
}
```

Ini merupakan baseline yang berguna untuk mempertahankan format sumber slide yang diimpor. Jika output Anda harus menggunakan satu tema tujuan, ganti pemanggilan sederhana `addClone($slide)` dengan overload master atau layout tujuan yang sesuai seperti yang ditunjukkan sebelumnya.

## **Pertimbangan Praktis**

### **Master, Layout, dan Keakuratan Format**

Penyalinan slide default dapat secara otomatis membawa master sumber yang diperlukan ke dalam presentasi tujuan. Aspose.Slides menyimpan registri internal untuk master yang disalin otomatis agar tidak menyalin master yang sama berulang-ulang. Master yang disalin secara manual tidak tercatat dalam registri tersebut, jadi hindari menyalin master terlebih dahulu kecuali Anda memerlukan kontrol eksplisit atas struktur master.

Jangan menganggap dua master atau layout dengan nama yang sama secara visual identik. Jika template perusahaan harus mengontrol tampilan akhir, pilih master atau layout tujuan secara eksplisit dan verifikasi hasil setelah penggabungan.

### **Catatan dan Komentar**

Catatan pembicara dan komentar slide terkait dengan konten slide dan disalin ketika slide disalin. Aspose.Slides juga menyediakan API khusus untuk [presentation notes](/slides/id/php-java/presentation-notes/) dan [presentation comments](/slides/id/php-java/presentation-comments/).

Jika format halaman catatan penting, periksa presentasi yang digabung karena master catatan berada pada level presentasi dan mungkin berbeda antar file sumber. Untuk alur kerja review, verifikasi juga penulis komentar dan komentar beruntai setelah menggabungkan file dari penulis atau template yang berbeda.

### **Gambar, Audio, Video, Objek OLE, dan Tautan Eksternal**

Slide dapat merujuk pada sumber daya pada tingkat presentasi seperti gambar, audio tertanam, video tertanam, dan data OLE. Salin slide itu sendiri, bukan hanya bentuk yang terlihat, sehingga Aspose.Slides dapat mempertahankan hubungan slide dengan sumber dayanya.

Sumber daya yang tertanam dan yang ditautkan harus diperlakukan berbeda. Audio, video, objek OLE, atau hiperta yang ditautkan tetap bergantung pada target eksternal; menyalin slide tidak mengubah tautan eksternal menjadi konten tertanam. Uji jalur dan URL sumber daya yang ditautkan di lingkungan tempat presentasi yang digabung akan dibuka.

Aspose.Slides melacak master yang disalin otomatis, tetapi hal ini tidak berarti bahwa semua sumber daya biner yang identik dari presentasi sumber yang tidak terkait akan selalu didedupikasi. Jika ukuran file output penting, inspeksi paket yang digabung dan ukur hasilnya alih-alih mengandalkan deduplikasi implisit.

### **Font Tertanam dan Ketersediaan Font**

Font dikelola pada tingkat presentasi. Jika tipografi harus konsisten di seluruh mesin, jangan menganggap bahwa menyalin slide saja menjamin semua font yang diperlukan tersedia di lingkungan tujuan. Anda dapat memeriksa font tertanam dengan [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/getembeddedfonts/) dan mengelola penanaman secara eksplisit seperti yang dijelaskan dalam [Embed Fonts in Presentations](/slides/id/php-java/embedded-font/).

Juga pastikan Anda memiliki izin untuk menanamkan font yang digunakan oleh file sumber. Lisensi font dapat membatasi penanaman.

### **Presentasi yang Dilindungi Kata Sandi**

Sumber yang dilindungi kata sandi harus dibuka berhasil sebelum slidenya dapat disalin. Berikan kata sandi melalui [LoadOptions::setPassword()](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/setpassword/).

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // Bekerja dengan presentasi yang telah didekripsi.
} finally {
    $source->dispose();
}
```

Membuka sumber yang terenkripsi tidak secara otomatis menerapkan perlindungan yang sama pada presentasi tujuan. Konfigurasikan perlindungan output secara terpisah bila diperlukan.

### **Presentasi Besar dan Penggunaan Memori**

Presentasi besar yang berisi gambar resolusi tinggi, audio, video, atau objek biner besar lainnya dapat memakan memori yang signifikan. [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) menyediakan kontrol untuk penanganan BLOB dan penggunaan file sementara. Lihat [Open Presentations](/slides/id/php-java/open-presentation/#open-large-presentations) untuk contoh file besar PHP via Java.

Untuk file besar, lebih baik memuat dari jalur file bila memungkinkan, buang (dispose) setiap presentasi sumber segera setelah selesai digabung, dan hindari menyimpan hasil menengah berulang kali kecuali alur kerja memerlukan checkpoint.

### **Keamanan Thread**

Jangan memuat, memodifikasi, menyimpan, atau menyalin instance [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) di beberapa thread. Operasi tersebut tidak didukung untuk penggunaan multithread di PHP via Java. Jika Anda memerlukan pekerjaan penggabungan paralel, jalankan dalam proses terpisah yang masing‑masing menggunakan instance presentasi sendiri, dan ikuti panduan [Aspose.Slides multithreading guidance](/slides/id/php-java/multithreading/).

## **FAQ**

**Bagaimana cara mempertahankan desain asli masing‑masing presentasi sumber?**

Gunakan [SlideCollection::addClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidecollection/addclone/) tanpa memberikan master atau layout tujuan. Aspose.Slides dapat menyalin master sumber secara otomatis ketika diperlukan oleh slide yang diimpor.

**Bagaimana cara membuat slide yang diimpor menggunakan tema tujuan?**

Gunakan overload yang menerima master tujuan. Berikan master dari presentasi tujuan, bukan dari sumber. Aspose.Slides akan mencoba memetakan tiap slide sumber ke layout yang sesuai di bawah master tersebut.

**Kapan harus menggunakan layout tujuan tertentu daripada master tujuan?**

Gunakan layout tertentu ketika setiap slide yang diimpor harus memakai satu layout yang sudah dikenal. Gunakan master ketika Anda ingin Aspose.Slides memilih di antara layout master tersebut berdasarkan tipe atau nama layout sumber.

**Apakah presentasi dengan ukuran slide berbeda dapat digabungkan?**

Ya, tetapi konten slide tidak secara otomatis dirancang ulang untuk dimensi tujuan. Ubah ukuran presentasi sumber terlebih dahulu ketika Anda memerlukan penempatan yang dapat diprediksi, misalnya dengan [SlideSize::setSize()](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidesize/setsize/) dan [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidesizescaletype/).

**Bisakah saya menggabungkan file PPT, PPTX, dan ODP menjadi satu file?**

Ya. Muat tiap presentasi sumber, salin slide yang diperlukan ke satu tujuan, dan simpan tujuan dalam format output yang didukung. Karena format presentasi tidak mendukung set fitur yang persis sama, verifikasi konten kompleks setelah penggabungan lintas format. Lihat [Supported File Formats](/slides/id/php-java/supported-file-formats/).

**Apakah bagian sumber (source sections) dipertahankan secara otomatis?**

Tidak oleh loop dasar yang hanya menyalin slide. Buat kembali bagian yang diperlukan di tujuan dan gunakan overload section dari [addClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidecollection/addclone/) ketika struktur bagian harus dipertahankan.

**Apakah catatan pembicara dan komentar dipertahankan?**

Mereka disalin bersama slide yang disalin. Untuk alur kerja yang bergantung pada styling master catatan, penulis komentar, atau data review beruntai, verifikasi hasil penggabungan karena skenario tersebut melibatkan struktur pada tingkat presentasi serta konten pada tingkat slide.

**Apa yang terjadi pada audio, video, objek OLE, dan tautan?**

Konten tertanam dibawa sebagai bagian dari hubungan sumber daya slide yang disalin. Tautan eksternal tetap eksternal, sehingga file atau URL target harus tetap tersedia setelah penggabungan.

**Apakah font tertanam dari setiap sumber dijamin tersedia di presentasi yang digabung?**

Jangan mengandalkan penyalinan slide saja untuk penyebaran font. Periksa font tertanam di tujuan dan kelola penanaman font atau ketersediaan font eksternal secara eksplisit ketika tipografi penting.

**Bagaimana cara menggabungkan file yang dilindungi kata sandi?**

Buka dengan [LoadOptions::setPassword()](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/setpassword/) yang benar, lalu salin slidennya seperti biasa. Perlindungan output dikonfigurasi terpisah.

**Bagaimana sebaiknya menangani presentasi yang sangat besar?**

Gunakan manajemen BLOB ketika objek biner besar mendominasi penggunaan memori, lebih pilih memuat dari jalur file untuk file sangat besar, buang (dispose) presentasi sumber segera setelah selesai digabung, dan simpan hasil akhir hanya ketika diperlukan.

**Bisakah saya menggabungkan slide dari beberapa thread?**

Memuat, menyimpan, atau menyalin presentasi di beberapa thread tidak didukung dalam PHP via Java. Untuk pekerjaan paralel, gunakan proses single‑thread terpisah dan pastikan instance presentasi terisolasi di setiap proses.