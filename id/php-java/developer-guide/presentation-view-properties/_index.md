---
title: Ambil dan Perbarui Properti Tampilan Presentasi di PHP
linktitle: Properti Tampilan
type: docs
weight: 80
url: /id/php-java/presentation-view-properties/
keywords:
- properti tampilan
- tampilan normal
- konten outline
- ikon outline
- snap pemisah vertikal
- tampilan tunggal
- status bar
- ukuran dimensi
- penyesuaian otomatis
- zoom default
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Temukan properti tampilan Aspose.Slides untuk PHP via Java untuk menyesuaikan format slide PPT, PPTX, dan ODP — sesuaikan tata letak, level zoom, dan pengaturan tampilan."
---
## **Pendahuluan**

Tampilan normal terdiri dari tiga wilayah konten: slide itu sendiri, wilayah konten samping, dan wilayah konten bagian bawah. Properti yang berhubungan dengan penempatan berbagai wilayah konten. Informasi ini memungkinkan aplikasi menyimpan status tampilan ke file, sehingga ketika dibuka kembali tampilan berada dalam keadaan yang sama seperti saat presentasi terakhir disimpan.

Metode[getViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) telah ditambahkan untuk menyediakan akses ke properti tampilan normal presentasi.  

[NormalViewProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/NormalViewRestoredProperties) kelas dan turunannya, [SplitterBarStateType](https://reference.aspose.com/slides/id/php-java/aspose.slides/SplitterBarStateType) enum telah ditambahkan.

## **Tentang INormalViewProperties**

Mewakili properti tampilan normal.

Metode[getShowOutlineIcons](https://reference.aspose.com/slides/id/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) dan [setShowOutlineIcons](https://reference.aspose.com/slides/id/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) menentukan apakah aplikasi harus menampilkan ikon saat menampilkan konten outline di salah satu wilayah konten mode tampilan normal.

Metode[getSnapVerticalSplitter](https://reference.aspose.com/slides/id/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) dan [setSnapVerticalSplitter](https://reference.aspose.com/slides/id/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) menentukan apakah pemisah vertikal harus menempel pada keadaan diperkecil ketika wilayah samping cukup kecil.

Properti[getPreferSingleView](https://reference.aspose.com/slides/id/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) dan [setPreferSingleView](https://reference.aspose.com/slides/id/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) menentukan apakah pengguna lebih suka melihat satu wilayah konten penuh jendela dibandingkan tampilan normal standar dengan tiga wilayah konten. Jika diaktifkan, aplikasi dapat memilih menampilkan salah satu wilayah konten di seluruh jendela.

Metode[getVerticalBarState](https://reference.aspose.com/slides/id/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) dan [getHorizontalBarState](https://reference.aspose.com/slides/id/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) menentukan keadaan yang harus ditampilkan oleh bilah pemisah vertikal atau horizontal. Bilah pemisah horizontal memisahkan slide dari wilayah konten di bawah slide, bilah pemisah vertikal memisahkan slide dari wilayah konten samping. Nilai yang mungkin adalah [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/id/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/id/php-java/aspose.slides/SplitterBarStateType/#Maximized) dan [SplitterBarStateType::Restored](https://reference.aspose.com/slides/id/php-java/aspose.slides/SplitterBarStateType/#Restored).

Metode[getRestoredLeft](https://reference.aspose.com/slides/id/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) dan [getRestoredTop](https://reference.aspose.com/slides/id/php-java/aspose.slides/NormalViewProperties#getRestoredTop) menentukan ukuran wilayah slide atas atau samping pada tampilan normal, ketika nilai [SplitterBarStateType::Restored](https://reference.aspose.com/slides/id/php-java/aspose.slides/SplitterBarStateType/#Restored) diterapkan pada [getVerticalBarState](https://reference.aspose.com/slides/id/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) dan [getHorizontalBarState](https://reference.aspose.com/slides/id/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) secara bersamaan.

## **Tentang Mengembalikan INormalViewProperties**

Menentukan ukuran wilayah slide (lebar ketika anak dari [getRestoredTop](https://reference.aspose.com/slides/id/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), tinggi ketika anak dari [getRestoredLeft](https://reference.aspose.com/slides/id/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) pada tampilan normal, ketika wilayah tersebut memiliki ukuran dipulihkan yang variabel (tidak diperkecil maupun diperbesar).  

Metode[getDimensionSize](https://reference.aspose.com/slides/id/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) menentukan ukuran wilayah slide (lebar ketika anak dari restoredTop, tinggi ketika anak dari restoredLeft).

Metode[getAutoAdjust](https://reference.aspose.com/slides/id/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) menentukan apakah ukuran wilayah konten samping harus menyesuaikan ukuran baru saat jendela tampilan dalam aplikasi diubah ukurannya.

Contoh berikut memperlihatkan cara mengakses properti[ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) untuk sebuah presentasi.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # Pulihkan properti tampilan presentasi
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Atur Nilai Zoom Default**
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java kini mendukung penetapan nilai zoom default untuk presentasi sehingga ketika presentasi dibuka, zoom sudah ditetapkan. Hal ini dapat dilakukan dengan mengatur [ViewProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/ViewProperties) sebuah presentasi. [getSlideViewProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) serta [getNotesViewProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) dapat diatur secara programatik. Pada topik ini, kami akan menunjukkan contoh cara mengatur [View Properties](https://reference.aspose.com/slides/id/php-java/aspose.slides/ViewProperties) dari [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation) di Aspose.Slides.

{{% /alert %}} 

Untuk mengatur properti tampilan, ikuti langkah-langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation).
1. Atur [View Properties](https://reference.aspose.com/slides/id/php-java/aspose.slides/ViewProperties) dari [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation).
1. Simpan presentasi sebagai file [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   Pada contoh di bawah, kami telah mengatur nilai zoom untuk tampilan slide serta tampilan catatan.

```php
  $presentation = new Presentation();
  try {
    # Mengatur properti tampilan presentasi
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Nilai zoom dalam persentase untuk tampilan slide
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Nilai zoom dalam persentase untuk tampilan catatan

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Atur Jarak Kisi**

Gunakan [Presentation::getViewProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getViewProperties) untuk mengakses pengaturan tampilan tingkat presentasi. Metode [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/id/php-java/aspose.slides/viewproperties/#getGridSpacing) dan [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/id/php-java/aspose.slides/viewproperties/#setGridSpacing) membaca atau mengubah interval kisi penyuntingan yang mendasarinya. Pengaturan ini berlaku untuk seluruh presentasi, bukan untuk slide individu. Jarak kisi ditentukan dalam poin, di mana 72 poin sama dengan satu inci. Gunakan nilai positif, sesuai dokumentasi API.

Contoh berikut membuka file `demo.pptx` yang ada, mencetak jarak kisi saat ini, menetapkan interval seperempat inci, dan menyimpan hasilnya.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $gridSpacing = $presentation->getViewProperties()->getGridSpacing();
    echo "Current grid spacing: " . $gridSpacing . " points\n";

    $presentation->getViewProperties()->setGridSpacing(18.0);
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kisi berbeda dari [drawing guides](/slides/id/php-java/drawing-guides/). Jarak kisi mengontrol interval reguler, sedangkan drawing guides adalah garis penyejajaran horizontal atau vertikal yang diposisikan secara individual. Menambahkan, memindahkan, atau menghapus drawing guides tidak mengubah jarak kisi.

Baik kisi maupun drawing guides adalah bantuan penyuntingan. Mereka tidak dirender sebagai konten slide dalam PDF, gambar, SVG, atau tayangan slide. Menyimpan jarak kisi tidak menjamin editor akan menampilkan kisi: visibilitasnya juga bergantung pada preferensi penampil atau editor.

## **Tampilkan atau Sembunyikan Komentar Saat Membuka Presentasi**

Gunakan [Presentation::getViewProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/getviewproperties/) untuk mengakses pengaturan tampilan tingkat presentasi. Gunakan [ViewProperties::getShowComments](https://reference.aspose.com/slides/id/php-java/aspose.slides/viewproperties/getshowcomments/) dan [ViewProperties::setShowComments](https://reference.aspose.com/slides/id/php-java/aspose.slides/viewproperties/setshowcomments/) untuk membaca atau mengubah preferensi yang disimpan mengenai apakah komentar harus ditampilkan saat presentasi dibuka di PowerPoint atau editor kompatibel lainnya.

Pengaturan ini hanya mengontrol preferensi tampilan yang disimpan. Ia tidak menambah, menghapus, mengedit, atau menyelesaikan komentar. Menyembunyikan komentar mempertahankan isi, penulis, posisi, balasan, dan statusnya. Lihat [Presentation Comments](/slides/id/php-java/presentation-comments/) untuk operasi yang mengubah komentar itu sendiri.

Contoh berikut memerlukan file `comments.pptx` yang ada berisi komentar. Ia mencetak pengaturan visibilitas saat ini, meminta komentar disembunyikan, dan menyimpan PPTX baru tanpa menghapus komentar apa pun. Ia juga menggunakan [ViewProperties::setLastView](https://reference.aspose.com/slides/id/php-java/aspose.slides/viewproperties/setlastview/) dengan [ViewType::SlideView](https://reference.aspose.com/slides/id/php-java/aspose.slides/viewtype/#SlideView) untuk mengonfigurasi tampilan penyuntingan awal bersamaan dengan visibilitas komentar.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $showComments = $presentation->getViewProperties()->getShowComments();
    echo "Current comment visibility: " . java_values($showComments) . PHP_EOL;

    $presentation->getViewProperties()->setShowComments(NullableBool::False);
    $presentation->getViewProperties()->setLastView(ViewType::SlideView);
    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pengaturan ini tidak menentukan apakah komentar disertakan dalam ekspor PDF, HTML, gambar, catatan, atau handout. Konfigurasikan opsi khusus ekspor yang relevan secara terpisah.

## **FAQ**

**Mengapa kisi tidak terlihat setelah saya membuka kembali presentasi?**  
File menyimpan jarak kisi, tetapi editor mengontrol apakah kisi ditampilkan. Periksa pengaturan visibilitas kisi pada editor.

**Apakah menghapus drawing guides mengubah jarak kisi?**  
Tidak. Drawing guides dan jarak kisi merupakan pengaturan yang independen. Menghapus guides tidak mengubah interval kisi yang disimpan.

**Bisakah saya mengatur pengaturan tampilan berbeda untuk bagian presentasi yang berbeda?**  
[View settings](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/getviewproperties/) didefinisikan pada level presentasi ([Normal View](https://reference.aspose.com/slides/id/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/id/php-java/aspose.slides/viewproperties/getslideviewproperties/)), bukan per bagian, sehingga satu set parameter berlaku untuk seluruh dokumen saat dibuka.

**Bisakah saya mendefinisikan status tampilan berbeda untuk pengguna yang berbeda?**  
Tidak. Pengaturan disimpan dalam file dan bersifat bersama. Aplikasi penampil dapat menghormati preferensi pengguna, tetapi file itu sendiri berisi satu set properti tampilan.

**Bisakah saya menyiapkan templat dengan View Properties yang telah ditentukan sehingga presentasi baru membuka dengan cara yang sama?**  
Ya. Karena [view properties](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/getviewproperties/) disimpan pada level presentasi, Anda dapat menyematkannya dalam templat dan membuat dokumen baru darinya dengan konfigurasi tampilan awal yang sama.