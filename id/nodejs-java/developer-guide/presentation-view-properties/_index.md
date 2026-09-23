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
- snap pemisah vertikal
- tampilan tunggal
- status bar
- ukuran dimensi
- penyesuaian otomatis
- zoom default
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Temukan Aspose.Slides untuk Node.js melalui properti tampilan Java untuk menyesuaikan format slide PPT, PPTX, dan ODP—atur tata letak, tingkat zoom, dan pengaturan tampilan."
---
## **Pengantar**

Tampilan normal terdiri dari tiga wilayah konten: slide itu sendiri, wilayah konten samping, dan wilayah konten bawah. Properti yang berkaitan dengan penempatan wilayah konten yang berbeda. Informasi ini memungkinkan aplikasi menyimpan status tampilan ke file, sehingga saat dibuka kembali tampilan berada dalam kondisi yang sama seperti saat presentasi terakhir disimpan.

Metode [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) telah ditambahkan untuk menyediakan akses ke properti tampilan normal presentasi.  

Kelas [NormalViewProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewRestoredProperties) dan keturunannya, serta enum [SplitterBarStateType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SplitterBarStateType) telah ditambahkan.

## **Tentang NormalViewProperties**

Mewakili properti tampilan normal.

Metode [getShowOutlineIcons](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) dan [setShowOutlineIcons](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) menentukan apakah aplikasi harus menampilkan ikon saat menampilkan konten outline di salah satu wilayah konten mode tampilan normal.

Metode [getSnapVerticalSplitter](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) dan [setSnapVerticalSplitter](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) menentukan apakah pemisah vertikal harus menempel pada keadaan diperkecil ketika wilayah samping cukup kecil.

Properti [getPreferSingleView](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) dan [setPreferSingleView](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) menentukan apakah pengguna lebih suka melihat satu wilayah konten penuh jendela dibandingkan tampilan normal standar dengan tiga wilayah konten. Jika diaktifkan, aplikasi dapat memilih menampilkan salah satu wilayah konten pada seluruh jendela.

Metode [getVerticalBarState](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) dan [getHorizontalBarState](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) menentukan keadaan yang harus ditampilkan oleh bar pemisah horizontal atau vertikal. Bar pemisah horizontal memisahkan slide dari wilayah konten di bawah slide, sedangkan bar pemisah vertikal memisahkan slide dari wilayah konten samping. Nilai yang mungkin adalah: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SplitterBarStateType#Maximized), dan [SplitterBarStateType.Restored](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Metode [getRestoredLeft](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) dan [getRestoredTop](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) menentukan ukuran wilayah slide atas atau samping dari tampilan normal, ketika nilai [SplitterBarStateType.Restored](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SplitterBarStateType#Restored) diterapkan untuk [getVerticalBarState](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) dan [getHorizontalBarState](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) secara bersamaan.

## **Tentang Memulihkan NormalViewProperties**

Menentukan ukuran wilayah slide (lebar ketika anak dari [getRestoredTop](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), tinggi ketika anak dari [getRestoredLeft](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) dari tampilan normal, ketika wilayah memiliki ukuran dipulihkan yang variabel (tidak diperkecil maupun diperbesar).

Metode [getDimensionSize](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) menentukan ukuran wilayah slide (lebar ketika anak dari restoredTop, tinggi ketika anak dari restoredLeft).

Metode [getAutoAdjust](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) menentukan apakah ukuran wilayah konten samping harus disesuaikan dengan ukuran baru saat mengubah ukuran jendela yang berisi tampilan dalam aplikasi.

Contoh di bawah menunjukkan cara mengakses properti [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) untuk sebuah presentasi.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // Mengembalikan properti tampilan presentasi
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Mengatur Nilai Zoom Default**

{{% alert color="info" %}} 

Aspose.Slides untuk Node.js via Java kini mendukung penetapan nilai zoom default untuk presentasi sehingga ketika presentasi dibuka, zoom sudah diatur. Hal ini dapat dilakukan dengan mengatur [ViewProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ViewProperties) sebuah presentasi. [getSlideViewProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) serta [getNotesViewProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) dapat diatur secara programatik. Dalam topik ini, kami akan menampilkan contoh cara mengatur [View Properties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ViewProperties) dari [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation) di Aspose.Slides.

{{% /alert %}} 

Untuk mengatur properti tampilan, ikuti langkah-langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).
1. Atur [View Properties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ViewProperties) dari [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).
1. Simpan presentasi sebagai file [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   Pada contoh di bawah, kami telah mengatur nilai zoom untuk tampilan slide maupun tampilan catatan.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // Mengatur properti tampilan presentasi
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Nilai zoom dalam persentase untuk tampilan slide
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Nilai zoom dalam persentase untuk tampilan catatan
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mengatur Jarak Grid**

Gunakan [Presentation.getViewProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getViewProperties--) untuk mengakses pengaturan tampilan seluruh presentasi. Metode [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) dan [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) membaca atau mengubah interval grid pengeditan yang mendasari. Pengaturan ini berlaku untuk seluruh presentasi, bukan untuk satu slide tertentu. Jarak grid ditentukan dalam poin, di mana 72 poin sama dengan satu inci. Gunakan nilai positif, sesuai dokumentasi API.

Contoh berikut membuka file `demo.pptx` yang sudah ada, mencetak jarak grid saat ini, mengatur interval seperempat inci, dan menyimpan hasilnya.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("demo.pptx");
try {
    var gridSpacing = presentation.getViewProperties().getGridSpacing();
    console.log("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18);
    presentation.save("grid-spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Grid berbeda dari [drawing guides](/slides/id/nodejs-java/drawing-guides/). Jarak grid mengontrol interval reguler, sementara drawing guides adalah garis alignmen horizontal atau vertikal yang diposisikan secara individual. Menambahkan, memindahkan, atau menghapus drawing guides tidak mengubah jarak grid.

Baik grid maupun drawing guides adalah bantuan pengeditan. Mereka tidak dirender sebagai konten slide dalam PDF, gambar, SVG, atau presentasi slide. Menyimpan jarak grid tidak menjamin editor akan menampilkan grid: visibilitasnya juga tergantung pada preferensi penampil atau editor.

## **Menampilkan atau Menyembunyikan Komentar Saat Membuka Presentasi**

Gunakan [Presentation.getViewProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getViewProperties--) untuk mengakses pengaturan tampilan seluruh presentasi. Gunakan [ViewProperties.getShowComments](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/viewproperties/#getShowComments--) dan [ViewProperties.setShowComments](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/viewproperties/#setShowComments-byte-) untuk membaca atau mengubah preferensi yang disimpan apakah komentar harus ditampilkan saat presentasi dibuka di PowerPoint atau editor kompatibel lainnya.

Pengaturan ini hanya mengontrol preferensi tampilan yang disimpan. Tidak menambah, menghapus, mengedit, atau menyelesaikan komentar. Menyembunyikan komentar mempertahankan konten, penulis, posisi, balasan, dan statusnya. Lihat [Presentation Comments](/slides/id/nodejs-java/presentation-comments/) untuk operasi yang mengubah komentar itu sendiri.

Contoh berikut memerlukan file `comments.pptx` yang sudah ada berisi komentar. Ia mencetak pengaturan visibilitas saat ini, meminta komentar disembunyikan, dan menyimpan PPTX baru tanpa menghapus komentar apa pun. Ia juga menggunakan [ViewProperties.setLastView](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/viewproperties/#setLastView-int-) dengan [ViewType.SlideView](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/viewtype/#SlideView) untuk mengonfigurasi tampilan edit awal bersamaan dengan visibilitas komentar.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("comments.pptx");
try {
    var showComments = presentation.getViewProperties().getShowComments();
    console.log("Current comment visibility: " + showComments);

    var hideComments = java.newByte(aspose.slides.NullableBool.False);
    presentation.getViewProperties().setShowComments(hideComments);
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideView);
    presentation.save("comments-hidden.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pengaturan ini tidak menentukan apakah komentar termasuk dalam ekspor PDF, HTML, gambar, catatan, atau handout. Konfigurasikan opsi khusus ekspor yang relevan secara terpisah.

## **FAQ**

**Mengapa grid tidak terlihat setelah saya membuka kembali presentasi?**  

File menyimpan jarak grid, tetapi editor yang mengontrol apakah grid ditampilkan. Periksa pengaturan visibilitas grid pada editor.

**Apakah menghapus drawing guides mengubah jarak grid?**  

Tidak. Drawing guides dan jarak grid adalah pengaturan yang independen. Menghapus guides tidak mengubah interval grid yang disimpan.

**Bisakah saya menetapkan pengaturan tampilan berbeda untuk bagian berbeda dalam sebuah presentasi?**  

[View settings](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/getviewproperties/) didefinisikan pada level presentasi ([Normal View](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), bukan per bagian, sehingga satu set parameter berlaku untuk seluruh dokumen saat dibuka.

**Bisakah saya mendefinisikan keadaan tampilan berbeda untuk pengguna yang berbeda?**  

Tidak. Pengaturan disimpan dalam file dan bersifat bersama. Aplikasi penampil dapat memperhatikan preferensi pengguna, tetapi file itu sendiri berisi satu set properti tampilan.

**Bisakah saya menyiapkan templat dengan View Properties yang telah ditentukan sehingga presentasi baru terbuka dengan cara yang sama?**  

Ya. Karena [view properties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/getviewproperties/) disimpan pada level presentasi, Anda dapat menyematkannya dalam templat dan membuat dokumen baru darinya dengan konfigurasi tampilan awal yang sama.