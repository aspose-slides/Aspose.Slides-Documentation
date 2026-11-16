---
title: Mengambil dan Memperbarui Properti Tampilan Presentasi dalam JavaScript
linktitle: Properti Tampilan
type: docs
weight: 80
url: /id/nodejs-java/presentation-view-properties/
keywords:
- properti tampilan
- tampilan normal
- konten outline
- ikon outline
- snap pembagi vertikal
- tampilan tunggal
- keadaan bar
- ukuran dimensi
- penyesuaian otomatis
- zoom default
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Gunakan Aspose.Slides untuk Node.js via Java untuk mengonfigurasi tata letak tampilan normal, zoom slide dan catatan, jarak grid, serta visibilitas komentar dalam presentasi PowerPowerPoint."
---
## **Pendahuluan**

Dalam tampilan normal PowerPoint, slide muncul di antara panel samping untuk thumbnail atau outline dan panel catatan di bawah. Aspose.Slides untuk Node.js via Java mengekspos preferensi penyuntingan yang disimpan dalam presentasi melalui [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties). Ini mencakup tata letak panel, tingkat zoom, jarak grid, dan visibilitas komentar.

## **Tentang NormalViewProperties**

Gunakan [getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNormalViewProperties) untuk mengakses kelas [NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) mengontrol apakah ikon muncul di sebelah judul slide dalam outline. [setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) memungkinkan panel samping menempel ke keadaan diminimalkan ketika pengguna memperkecilnya. [setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setPreferSingleView) menunjukkan preferensi untuk menampilkan satu panel dalam jendela penuh.

[setVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setVerticalBarState) mengontrol pemisah antara panel samping dan slide. [setHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setHorizontalBarState) mengontrol pemisah di atas panel catatan. Kedua metode menerima nilai [SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/splitterbarstatetype/) berupa `Minimized`, `Maximized`, atau `Restored`.

## **Tentang Mengembalikan NormalViewProperties**

Ketika pemisah dipulihkan, [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredLeft) memberikan ukuran tersimpan dari panel samping dan [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) memberikan ukuran tersimpan dari area slide bagian atas. Kedua metode mengekspos [NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/). Metode [setDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) menerima persentase dari 0 hingga 100, dan [setAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) mengontrol apakah penyunting menyesuaikan ukuran ketika jendela diubah ukurannya.

Contoh ini memperbarui presentasi yang ada. Ia mengembalikan pembagi horizontal, mengatur ukuran yang dikembalikan oleh [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) menjadi 80% dengan penyesuaian otomatis diaktifkan, dan memaksimalkan pembagi vertikal. Ia juga memanggil [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) untuk menampilkan ikon dalam tampilan outline.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(slides.SplitterBarStateType.Restored);
    normalView.setVerticalBarState(slides.SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Nilai Zoom Default**

[getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getSlideViewProperties) dan [getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNotesViewProperties) menyimpan pengaturan zoom terpisah untuk penyunting. Pengaturan ini tidak memengaruhi dimensi slide, pemutaran slide-show, atau resolusi ekspor gambar.

Contoh ini membuka presentasi yang ada dan memanggil [setVariableScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setVariableScale) untuk menyesuaikan slide ke jendela penyunting. Untuk halaman catatan, ia menonaktifkan skala otomatis dan memanggil [setScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setScale) untuk mengatur zoom tetap 80%.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Jarak Grid**

[setGridSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setGridSpacing) menetapkan jarak antar garis grid penyuntingan di seluruh presentasi. Nilai yang diberikan harus positif dalam satuan point, dengan 72 point per inci. Contoh ini mencetak jarak saat ini dalam presentasi yang ada dan menyimpan grid seperempat inci dengan mengatur interval menjadi 18 point.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18);

    presentation.save("grid-spacing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Grid berulang pada interval tetap. [Drawing guides](/slides/id/nodejs-java/drawing-guides/) menandai posisi horizontal atau vertikal secara individual. Kedua alat ini merupakan bantuan penyuntingan dan hanya muncul di penyunting yang menampilkannya. Slide show serta ekspor ke PDF, gambar, atau SVG tidak menyertakannya.

## **Tampilkan atau Sembunyikan Komentar Saat Membuka Presentasi**

[setShowComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setShowComments) menyimpan preferensi yang digunakan penyunting yang kompatibel saat membuka presentasi. Untuk presentasi yang ada dengan komentar, contoh ini mencetak pengaturan saat ini dan menyimpan salinan dengan komentar disembunyikan. Ia juga memanggil [setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) dengan [ViewType.SlideView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/#SlideView) sehingga salinan terbuka dalam tampilan slide.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current comment visibility: " + viewProperties.getShowComments());

    const hideComments = java.newByte(slides.NullableBool.False);
    viewProperties.setShowComments(hideComments);
    viewProperties.setLastView(slides.ViewType.SlideView);

    presentation.save("comments-hidden.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Menyembunyikan komentar mempertahankan teks, penulis, posisi, balasan, dan statusnya. Untuk mengubah komentar itu sendiri, lihat [Presentation Comments](/slides/id/nodejs-java/presentation-comments/). Pengaturan ekspor mengontrol apakah komentar muncul dalam PDF, HTML, gambar, catatan, atau selebaran.

## **FAQ**

**Mengapa grid tersembunyi saat saya membuka kembali presentasi?**

Presentasi menyimpan interval grid. Untuk melihat grid, aktifkan visibilitas grid di penyunting.

**Apakah menghapus drawing guides mengubah jarak grid?**

Tidak. Menambahkan, memindahkan, atau menghapus sebuah guide tidak mengubah interval grid.

**Apakah bagian berbeda dari sebuah presentasi dapat memiliki pengaturan tampilan yang berbeda?**

Tidak. [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) berlaku untuk seluruh presentasi.

**Dapatkah saya menyimpan pengaturan tampilan yang berbeda untuk pengguna yang berbeda?**

Berkas menyimpan satu set properti tampilan untuk semua orang. Penyunting juga dapat menerapkan preferensi lokal pengguna.

**Dapatkah saya menyimpan pengaturan tampilan dalam sebuah templat?**

Ya. Presentasi yang dibuat dari templat mewarisi pengaturan tampilan yang disimpan di dalamnya.