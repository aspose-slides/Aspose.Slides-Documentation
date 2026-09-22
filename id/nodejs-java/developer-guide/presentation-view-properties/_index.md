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
description: "Temukan Aspose.Slides untuk Node.js via Java properti tampilan untuk menyesuaikan format slide PPT, PPTX, dan ODP—sesuaikan tata letak, tingkat zoom, dan pengaturan tampilan."
---
## **Pendahuluan**

Tampilan normal terdiri dari tiga wilayah konten: slide itu sendiri, wilayah konten samping, dan wilayah konten bawah. Properti yang berkaitan dengan posisi berbagai wilayah konten. Informasi ini memungkinkan aplikasi menyimpan keadaan tampilan ke dalam file, sehingga ketika dibuka kembali tampilan berada dalam keadaan yang sama seperti saat presentasi terakhir disimpan.

Metode [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) telah ditambahkan untuk memberikan akses ke properti tampilan normal dari presentasi.  

[NormalViewProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewRestoredProperties) kelas dan turunannya, [SplitterBarStateType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SplitterBarStateType) enum telah ditambahkan.

## **Tentang NormalViewProperties**

Mewakili properti tampilan normal.

Metode [getShowOutlineIcons](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) dan [setShowOutlineIcons](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) menentukan apakah aplikasi harus menampilkan ikon saat menampilkan konten outline di salah satu wilayah konten mode tampilan normal.

Metode [getSnapVerticalSplitter](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) dan [setSnapVerticalSplitter](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) menentukan apakah pemisah vertikal harus menempel pada keadaan diperkecil ketika wilayah samping cukup kecil.

Properti [getPreferSingleView](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) dan [setPreferSingleView](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) menentukan apakah pengguna lebih suka melihat satu wilayah konten penuh-jendela daripada tampilan normal standar dengan tiga wilayah konten. Jika diaktifkan, aplikasi dapat memilih menampilkan satu wilayah konten pada seluruh jendela.

Metode [getVerticalBarState](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) dan [getHorizontalBarState](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) menentukan keadaan yang harus ditampilkan oleh pemisah batang horizontal atau vertikal. Pemisah batang horizontal memisahkan slide dari wilayah konten di bawah slide, pemisah batang vertikal memisahkan slide dari wilayah konten samping. Nilai yang mungkin adalah: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) dan [SplitterBarStateType.Restored](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Metode [getRestoredLeft](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) dan [getRestoredTop](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) menentukan ukuran wilayah slide atas atau samping pada tampilan normal, ketika nilai [SplitterBarStateType.Restored](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SplitterBarStateType#Restored) diterapkan pada [getVerticalBarState](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) dan [getHorizontalBarState](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) secara bersamaan.

## **Tentang Memulihkan NormalViewProperties** 

Menentukan ukuran wilayah slide (lebar ketika anak dari [getRestoredTop](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), tinggi ketika anak dari [getRestoredLeft](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) pada tampilan normal, ketika wilayah tersebut memiliki ukuran dipulihkan yang variabel (tidak diperkecil maupun diperbesar).  

Metode [getDimensionSize](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) menentukan ukuran wilayah slide (lebar ketika anak dari restoredTop, tinggi ketika anak dari restoredLeft).  

Metode [getAutoAdjust](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) menentukan apakah ukuran wilayah konten samping harus menyesuaikan ukuran baru saat mengubah ukuran jendela yang berisi tampilan dalam aplikasi.  

Contoh di bawah memperlihatkan cara mengakses properti [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) untuk sebuah presentasi.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // Pulihkan properti tampilan presentasi
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Set Nilai Zoom Default**

{{% alert color="info" %}} 

Aspose.Slides for Node.js via Java kini mendukung penetapan nilai zoom default untuk presentasi sehingga ketika presentasi dibuka, zoom sudah diatur. Hal ini dapat dilakukan dengan mengatur [ViewProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ViewProperties) dari sebuah presentasi. [getSlideViewProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) serta [getNotesViewProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) dapat diatur secara programatis. Dalam topik ini, kami akan memperlihatkan dengan contoh cara mengatur [View Properties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ViewProperties) dari [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation) di Aspose.Slides.

{{% /alert %}} 

Untuk mengatur properti tampilan, ikuti langkah-langkah berikut:

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).
1. Atur [View Properties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ViewProperties) dari [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).
1. Simpan presentasi sebagai berkas [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   Pada contoh di bawah, kami telah mengatur nilai zoom untuk tampilan slide serta tampilan catatan.

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

## **Set Jarak Kisi**

Gunakan [Presentation.getViewProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getViewProperties--) untuk mengakses pengaturan tampilan tingkat presentasi. Metode [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) dan [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) membaca atau mengubah interval kisi pengeditan yang mendasari. Pengaturan ini berlaku untuk seluruh presentasi, bukan untuk satu slide tertentu. Jarak kisi ditentukan dalam poin, di mana 72 poin sama dengan satu inci. Gunakan nilai positif, sesuai dengan dokumentasi API.

Contoh berikut membuka file `demo.pptx` yang ada, mencetak jarak kisi saat ini, menetapkan interval seperempat inci, dan menyimpan hasilnya.

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

Kisi berbeda dari [drawing guides](/slides/id/nodejs-java/drawing-guides/). Jarak kisi mengontrol interval reguler, sementara drawing guides adalah garis penyejajaran horizontal atau vertikal yang diposisikan secara individu. Menambah, memindah, atau menghapus drawing guides tidak mengubah jarak kisi.

Baik kisi maupun drawing guides merupakan bantuan pengeditan. Mereka tidak dirender sebagai konten slide dalam PDF, gambar, SVG, atau tayangan slide. Menyimpan jarak kisi tidak menjamin editor akan menampilkan kisi: visibilitasnya juga tergantung pada preferensi penampil atau editor.

## **FAQ**

**Mengapa kisi tidak terlihat setelah saya membuka kembali presentasi?**  
Berkas menyimpan jarak kisi, tetapi editor yang mengontrol apakah kisi ditampilkan. Periksa pengaturan visibilitas kisi pada editor.

**Apakah menghapus drawing guides mengubah jarak kisi?**  
Tidak. Drawing guides dan jarak kisi adalah pengaturan yang independen. Menghapus guides tidak mengubah interval kisi yang disimpan.

**Bisakah saya mengatur pengaturan tampilan yang berbeda untuk bagian berbeda dari sebuah presentasi?**  
[View settings](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/getviewproperties/) didefinisikan pada tingkat presentasi ([Normal View](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), bukan per bagian, sehingga satu set parameter berlaku untuk seluruh dokumen ketika dibuka.

**Bisakah saya mendefinisikan status tampilan yang berbeda untuk pengguna yang berbeda?**  
Tidak. Pengaturan disimpan dalam berkas dan bersifat bersama. Aplikasi penampil dapat menghormati preferensi pengguna, tetapi berkas itu sendiri hanya berisi satu set properti tampilan.

**Bisakah saya menyiapkan templat dengan View Properties yang telah ditentukan sehingga presentasi baru membuka dengan cara yang sama?**  
Ya. Karena [view properties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/getviewproperties/) disimpan pada tingkat presentasi, Anda dapat menyematkannya dalam templat dan membuat dokumen baru darinya dengan konfigurasi tampilan awal yang sama.