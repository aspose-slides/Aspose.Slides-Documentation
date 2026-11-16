---
title: Mengambil dan Memperbarui Properti Tampilan Presentasi di PHP
linktitle: Properti Tampilan
type: docs
weight: 80
url: /id/php-java/presentation-view-properties/
keywords:
- properti tampilan
- tampilan normal
- konten outline
- ikon outline
- snap pembagi vertikal
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
description: "Gunakan Aspose.Slides untuk PHP via Java untuk mengkonfigurasi tata letak tampilan normal, zoom slide dan catatan, jarak grid, serta visibilitas komentar dalam presentasi PowerPoint."
---
## **Introduction**

Pada tampilan normal PowerPoint, slide muncul di antara panel samping untuk thumbnail atau outline dan panel catatan di bawah. Aspose.Slides untuk PHP via Java mengekspos preferensi penyuntingan yang disimpan dalam presentasi melalui [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/). Preferensi ini mencakup tata letak panel, tingkat zoom, jarak grid, dan visibilitas komentar.

## **Tentang NormalViewProperties**

Gunakan [getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/) untuk mengakses kelas [NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) mengontrol apakah ikon muncul di samping judul slide dalam outline. [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setsnapverticalsplitter/) memungkinkan panel samping menempel pada keadaan diminimalkan ketika pengguna memperkecilnya. [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setprefersingleview/) menunjukkan preferensi untuk menampilkan satu panel di jendela penuh.

[setVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setverticalbarstate/) mengontrol pembagi antara panel samping dan slide. [setHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/sethorizontalbarstate/) mengontrol pembagi di atas panel catatan. Kedua metode menerima nilai [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/splitterbarstatetype/) berupa `Minimized`, `Maximized`, atau `Restored`.

## **Tentang Mengembalikan NormalViewProperties**

Ketika pembagi dipulihkan, [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredleft/) memberikan ukuran panel samping yang disimpan dan [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) memberikan ukuran area slide atas yang disimpan. Kedua metode mengekspos [NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/). Metode [setDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setdimensionsize/) menerima persentase dari 0 hingga 100, dan [setAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setautoadjust/) mengontrol apakah penyunting menyesuaikan ukuran saat jendela diubah ukurannya.

Contoh ini memperbarui presentasi yang ada. Ia memulihkan pembagi horizontal, mengatur ukuran yang dikembalikan oleh [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) menjadi 80% dengan penyesuaian otomatis diaktifkan, dan memaksimalkan pembagi vertikal. Ia juga memanggil [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) untuk menampilkan ikon dalam tampilan outline.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SplitterBarStateType;

$presentation = new Presentation("demo.pptx");
try {
    $normalView = $presentation->getViewProperties()->getNormalViewProperties();
    $normalView->setHorizontalBarState(SplitterBarStateType::Restored);
    $normalView->setVerticalBarState(SplitterBarStateType::Maximized);
    $normalView->getRestoredTop()->setAutoAdjust(true);
    $normalView->getRestoredTop()->setDimensionSize(80);
    $normalView->setShowOutlineIcons(true);

    $presentation->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Atur Nilai Zoom Default**

[getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/) dan [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnotesviewproperties/) menyimpan pengaturan zoom terpisah untuk penyunting. Pengaturan ini tidak memengaruhi dimensi slide, pemutaran slide-show, atau resolusi ekspor gambar.

Contoh ini membuka presentasi yang ada dan memanggil [setVariableScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setvariablescale/) untuk menyesuaikan slide dengan jendela penyuntingan. Untuk halaman catatan, ia menonaktifkan penskalaan otomatis dan memanggil [setScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setscale/) untuk mengatur zoom tetap 80%.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    $viewProperties->getSlideViewProperties()->setVariableScale(true);
    $viewProperties->getNotesViewProperties()->setVariableScale(false);
    $viewProperties->getNotesViewProperties()->setScale(80);

    $presentation->save("zoom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Atur Jarak Grid**

Metode `setGridSpacing` pada [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/) mengatur jarak antara garis-garis grid penyuntingan di seluruh presentasi. Metode ini menerima nilai positif dalam poin, dengan 72 poin per inci. Contoh ini mencetak jarak saat ini dalam presentasi yang ada dan menyimpan grid seperempat inci dengan mengatur interval menjadi 18 poin.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current grid spacing: " . java_values($viewProperties->getGridSpacing()) . " points" . PHP_EOL;

    $viewProperties->setGridSpacing(18.0);
    
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Grid berulang pada interval tetap. [Drawing guides](/slides/id/php-java/drawing-guides/) menandai posisi horizontal atau vertikal individu. Keduanya merupakan bantuan penyuntingan dan hanya muncul di penyunting yang menampilkannya. Slide show dan ekspor ke PDF, gambar, atau SVG tidak menyertakannya.

## **Tampilkan atau Sembunyikan Komentar Saat Membuka Presentasi**

[setShowComments](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setshowcomments/) menyimpan preferensi yang digunakan penyunting kompatibel saat membuka presentasi. Untuk presentasi yang ada dengan komentar, contoh ini mencetak pengaturan saat ini dan menyimpan salinan dengan komentar disembunyikan. Ia juga memanggil [setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setlastview/) dengan [ViewType::SlideView](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/#SlideView) sehingga salinan terbuka dalam tampilan slide.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current comment visibility: " . java_values($viewProperties->getShowComments()) . PHP_EOL;

    $viewProperties->setShowComments(NullableBool::False);
    $viewProperties->setLastView(ViewType::SlideView);

    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Menyembunyikan komentar mempertahankan teks, penulis, posisi, balasan, dan statusnya. Untuk mengubah komentar itu sendiri, lihat [Presentation Comments](/slides/id/php-java/presentation-comments/). Pengaturan ekspor mengontrol apakah komentar muncul di PDF, HTML, gambar, catatan, atau handout.

## **FAQ**

**Mengapa grid tersembunyi saat saya membuka kembali presentasi?**

Presentasi menyimpan interval grid. Untuk melihat grid, aktifkan visibilitas grid di penyunting.

**Apakah menghapus drawing guides mengubah jarak grid?**

Tidak. Menambah, memindahkan, atau menghapus sebuah guide tidak mengubah interval grid.

**Apakah bagian berbeda dari sebuah presentasi dapat memiliki pengaturan tampilan yang berbeda?**

Tidak. [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) berlaku untuk seluruh presentasi.

**Bisakah saya menyimpan pengaturan tampilan yang berbeda untuk pengguna yang berbeda?**

File menyimpan satu set properti tampilan untuk semua orang. Penyunting juga dapat menerapkan preferensi lokal pengguna.

**Bisakah saya menyimpan pengaturan tampilan dalam templat?**

Ya. Presentasi yang dibuat dari templat mewarisi pengaturan tampilan yang disimpan.