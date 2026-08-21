---
title: Operasi Presentasi Low-Code dalam PHP
linktitle: API Low-Code
type: docs
weight: 50
url: /id/php-java/low-code-presentation-operations/
keywords:
- API presentasi low-code
- konversi presentasi
- gabungkan presentasi
- iterasi slide
- iterasi shape
- iterasi teks
- kumpulkan shape
- kompres presentasi
- hapus slide master yang tidak terpakai
- hapus slide layout yang tidak terpakai
- kompres font tersemat
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Gunakan API low-code Aspose.Slides di PHP untuk mengonversi dan menggabungkan presentasi, iterasi konten, mengumpulkan shape, dan mengurangi ukuran presentasi."
---
## **Gambaran Umum**

Namespace [aspose.slides](https://reference.aspose.com/slides/id/php-java/aspose.slides/) menyediakan kelas pembantu statis untuk operasi presentasi umum. Pembantu ini membungkus alur kerja model objek yang sering digunakan ke dalam metode yang terfokus, sehingga Anda dapat mengonversi atau menggabungkan file, memproses elemen presentasi, mengumpulkan shape, dan menghapus konten yang tidak terpakai dengan lebih sedikit kode.

Pembantu low-code paling berguna ketika operasi diterapkan pada seluruh file atau presentasi dan alur kerja default sesuai dengan kebutuhan Anda. Gunakan model objek [Aspose.Slides object model](https://reference.aspose.com/slides/id/php-java/aspose.slides/) penuh ketika Anda memerlukan kontrol granular atas slide individual, master, layout, shape, pengaturan ekspor, atau hubungan antar elemen presentasi.

Tabel berikut merangkum pembantu yang tersedia:

| Pembantu | Gunakan untuk |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/id/php-java/aspose.slides/convert/) | Mengonversi presentasi ke format lain dengan panggilan file-ke-file langsung. |
| [Merger](https://reference.aspose.com/slides/id/php-java/aspose.slides/merger/) | Menggabungkan file presentasi lengkap dengan format yang sama. |
| [ForEach_](https://reference.aspose.com/slides/id/php-java/aspose.slides/foreach_/) | Menjalankan callback untuk setiap slide, shape, paragraf, atau bagian teks. |
| [Collect](https://reference.aspose.com/slides/id/php-java/aspose.slides/collect/) | Mengambil shape dari seluruh presentasi untuk pemrosesan atau analisis berulang. |
| [Compress](https://reference.aspose.com/slides/id/php-java/aspose.slides/compress/) | Menghapus master dan layout yang tidak terpakai serta mengurangi data font yang tersemat. |

## **Mengonversi Presentasi**

Gunakan [Convert::autoByExtension](https://reference.aspose.com/slides/id/php-java/aspose.slides/convert/#autoByExtension) ketika ekstensi file keluaran cukup untuk memilih format ekspor. Metode ini membuka presentasi sumber, menentukan format yang diperlukan dari path keluaran, dan menulis hasilnya.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

Kelas [Convert](https://reference.aspose.com/slides/id/php-java/aspose.slides/convert/) juga menyediakan metode khusus untuk output PDF, SVG, JPEG, PNG, dan TIFF. Gunakan model objek penuh ketika Anda perlu memeriksa atau memodifikasi presentasi sebelum ekspor atau mengkonfigurasi opsi ekspor yang tidak tersedia pada pembantu yang dipilih. Lihat [Convert Presentation](/php-java/convert-presentation/) untuk alur kerja dan opsi spesifik format.

## **Menggabungkan Presentasi**

Gunakan [Merger::process](https://reference.aspose.com/slides/id/php-java/aspose.slides/merger/#process) untuk menggabungkan file presentasi lengkap dengan satu panggilan. Presentasi masukan harus memiliki format file yang sama.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

Pembantu ini cocok ketika semua slide harus ditambahkan ke satu hasil tanpa memilih atau memetakan ulang secara individual. Gunakan model objek penuh ketika Anda perlu menggabungkan slide yang dipilih, menerapkan master atau layout tujuan, mempertahankan bagian secara eksplisit, atau menyamakan ukuran slide yang berbeda. Lihat [Merge Presentations](/php-java/merge-presentation/) untuk skenario tersebut.

## **Iterasi Elemen Presentasi**

Kelas [ForEach_](https://reference.aspose.com/slides/id/php-java/aspose.slides/foreach_/) memanggil callback untuk setiap tipe elemen presentasi yang diminta. Ini menghindari loop koleksi bersarang dan memudahkan inspeksi atau perubahan format di seluruh presentasi.

Contoh berikut menggunakan [ForEach_::slide](https://reference.aspose.com/slides/id/php-java/aspose.slides/foreach_/#slide), [ForEach_::shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/foreach_/#paragraph), dan [ForEach_::portion](https://reference.aspose.com/slides/id/php-java/aspose.slides/foreach_/#portion) untuk memeriksa elemen yang bersesuaian:

```php
use aspose\slides\ForEach_;
use aspose\slides\Presentation;

class SlideCallback {
    public function invoke($slide, $index): void {
        $slideIndex = java_values($index);
        $shapeCount = java_values($slide->getShapes()->size());
        echo sprintf("Slide %d: %d shapes", $slideIndex, $shapeCount) . PHP_EOL;
    }
}

class ShapeCallback {
    public function invoke($shape, $slide, $index): void {
        $shapeIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $shapeName = java_values($shape->getName());
        echo sprintf("Shape %d on %s: %s", $shapeIndex, $slideType, $shapeName) . PHP_EOL;
    }
}

class ParagraphCallback {
    public function invoke($paragraph, $slide, $index): void {
        $paragraphIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($paragraph->getText());
        echo sprintf("Paragraph %d on %s: %s", $paragraphIndex, $slideType, $text) . PHP_EOL;
    }
}

class PortionCallback {
    public function invoke($portion, $paragraph, $slide, $index): void {
        $portionIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($portion->getText());
        echo sprintf("Portion %d on %s: %s", $portionIndex, $slideType, $text) . PHP_EOL;
    }
}

$presentation = new Presentation("input.pptx");
try {
    $slideCallback = java_closure(new SlideCallback(), null, java('com.aspose.slides.ForEach_$ForEachSlideCallback'));
    $shapeCallback = java_closure(new ShapeCallback(), null, java('com.aspose.slides.ForEach_$ForEachShapeCallback'));
    $paragraphCallback = java_closure(new ParagraphCallback(), null, java('com.aspose.slides.ForEach_$ForEachParagraphCallback'));
    $portionCallback = java_closure(new PortionCallback(), null, java('com.aspose.slides.ForEach_$ForEachPortionCallback'));

    ForEach_::slide($presentation, $slideCallback);
    ForEach_::shape($presentation, $shapeCallback);
    ForEach_::paragraph($presentation, $paragraphCallback);
    ForEach_::portion($presentation, $portionCallback);
} finally {
    $presentation->dispose();
}
```

Secara default, traversal shape dan teks di seluruh presentasi mencakup slide normal, master, dan layout. Overload dengan parameter `includeNotes` dapat juga memproses slide catatan. Gunakan loop koleksi langsung ketika urutan traversal, keluar lebih awal, penyaringan sebelum pemanggilan callback, atau kontrol orangtua‑anak yang detail menjadi penting.

## **Kumpulkan Shape**

Gunakan [Collect::shapes](https://reference.aspose.com/slides/id/php-java/aspose.slides/collect/#shapes) ketika Anda memerlukan koleksi semua shape dalam satu presentasi, bukan callback untuk tiap shape. Ini berguna ketika set yang sama akan difilter, dihitung, atau diproses lebih dari satu kali.

```php
use aspose\slides\Collect;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $shapes = Collect::shapes($presentation);

    foreach ($shapes as $shape) {
        $shapeName = java_values($shape->getName());
        $shapeType = java_values($shape->getClass()->getSimpleName());
        echo sprintf("%s: %s", $shapeName, $shapeType) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Gunakan [ForEach_::shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/foreach_/#shape) sebagai gantinya ketika setiap shape dapat diproses langsung dan Anda tidak perlu menyimpan hasil yang dikumpulkan.

## **Kompres Konten Presentasi**

Kelas [Compress](https://reference.aspose.com/slides/id/php-java/aspose.slides/compress/) dapat menghapus elemen struktural yang tidak terpakai dan mengurangi data font yang tersemat:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) menghapus slide layout yang tidak direferensikan oleh slide normal.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/compress/#removeUnusedMasterSlides) menghapus slide master yang tidak lagi digunakan.
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/id/php-java/aspose.slides/compress/#compressEmbeddedFonts) menghapus karakter yang tidak terpakai dari font yang tersemat.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    Compress::removeUnusedMasterSlides($presentation);
    Compress::compressEmbeddedFonts($presentation);

    $presentation->save("compressed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hapus layout yang tidak terpakai sebelum master yang tidak terpakai sehingga master yang menjadi tidak terreferensi setelah pembersihan layout juga dapat dihapus. Simpan presentasi yang dioptimalkan ke file baru jika Anda mungkin membutuhkan master, layout, atau data font tersemat lengkap asalnya nanti. Untuk detail lebih lanjut, lihat [Slide Master](/php-java/slide-master/) dan [Embedded Font](/php-java/embedded-font/).

## **FAQ**

**Kapan saya harus menggunakan API low-code alih-alih model objek penuh?**

Gunakan pembantu low-code ketika operasi standar diterapkan pada file atau presentasi lengkap dan tidak memerlukan kontrol detail atas elemen individu. Gunakan model objek penuh ketika Anda perlu memilih slide tertentu, mengontrol hubungan master dan layout, memeriksa status antara, atau mengkonfigurasi perilaku yang tidak disediakan oleh pembantu.

**Apakah Merger dapat menggabungkan presentasi dengan format file yang berbeda?**

Tidak. [Merger::process](https://reference.aspose.com/slides/id/php-java/aspose.slides/merger/#process) memerlukan presentasi masukan dengan format yang sama. Konversi file masukan ke format umum terlebih dahulu, misalnya dengan [Convert::autoByExtension](https://reference.aspose.com/slides/id/php-java/aspose.slides/convert/#autoByExtension), kemudian gabungkan file yang telah dikonversi.

**Apakah ForEach_ memproses slide master, layout, dan catatan?**

[ForEach_::slide](https://reference.aspose.com/slides/id/php-java/aspose.slides/foreach_/#slide) mengiterasi slide presentasi normal. Operasi [ForEach_::shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/foreach_/#paragraph), dan [ForEach_::portion](https://reference.aspose.com/slides/id/php-java/aspose.slides/foreach_/#portion) di seluruh presentasi mencakup slide normal, master, dan layout secara default. Gunakan overload mereka dengan `includeNotes` diatur ke `true` untuk menyertakan slide catatan.

**Apa perbedaan antara ForEach_::shape dan Collect::shapes?**

Gunakan [ForEach_::shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/foreach_/#shape) untuk memproses setiap shape secara langsung melalui callback. Gunakan [Collect::shapes](https://reference.aspose.com/slides/id/php-java/aspose.slides/collect/#shapes) ketika Anda memerlukan hasil yang dapat diiterasi, disimpan, difilter, dihitung, atau dilalui berkali‑kali.

**Apakah Compress selalu membuat file presentasi lebih kecil?**

Tidak selalu. Hasilnya tergantung pada apakah presentasi berisi layout yang tidak terpakai, master yang tidak terpakai, atau font tersemat dengan karakter yang tidak terpakai. Jika tidak ada yang demikian, operasi [Compress](https://reference.aspose.com/slides/id/php-java/aspose.slides/compress/) yang bersangkutan mungkin tidak mengurangi ukuran file.

**Apakah perubahan yang dibuat oleh ForEach_ atau Compress disimpan secara otomatis?**

Tidak. Pembantu ini beroperasi pada objek [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) yang dimuat di memori. Setelah mengubah elemen dalam callback [ForEach_](https://reference.aspose.com/slides/id/php-java/aspose.slides/foreach_) atau menjalankan [Compress](https://reference.aspose.com/slides/id/php-java/aspose.slides/compress/), panggil [Presentation::save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#save) untuk menulis hasilnya.

## **Artikel Terkait**

- [Konversi Presentasi](/php-java/convert-presentation/)
- [Gabungkan Presentasi](/php-java/merge-presentation/)
- [Slide Master](/php-java/slide-master/)
- [Kelola Kotak Teks](/php-java/manage-textbox/)
- [Font Tersemat](/php-java/embedded-font/)