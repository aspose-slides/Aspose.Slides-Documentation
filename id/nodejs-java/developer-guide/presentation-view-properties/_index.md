---
title: Mendapatkan dan Memperbarui Properti Tampilan Presentasi dalam JavaScript
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
description: "Temukan Aspose.Slides untuk Node.js via Java dengan properti tampilan untuk menyesuaikan format slide PPT, PPTX, dan ODP — sesuaikan tata letak, level zoom, dan pengaturan tampilan."
---
## **Pendahuluan**

Tampilan normal terdiri dari tiga wilayah konten: slide itu sendiri, wilayah konten samping, dan wilayah konten bawah. Properti yang terkait dengan penempatan masing‑masing wilayah konten. Informasi ini memungkinkan aplikasi menyimpan status tampilan ke dalam file, sehingga ketika dibuka kembali tampilan berada dalam keadaan yang sama seperti saat presentasi terakhir disimpan.

Metode [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) telah ditambahkan untuk memberikan akses ke properti tampilan normal dari presentasi.  

[NormalViewProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewRestoredProperties) kelas dan turunannya, serta enum [SplitterBarStateType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SplitterBarStateType) telah ditambahkan.

## **Tentang NormalViewProperties**

Mewakili properti tampilan normal.

Metode [getShowOutlineIcons](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) dan [setShowOutlineIcons](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) menentukan apakah aplikasi harus menampilkan ikon saat menampilkan konten outline di salah satu wilayah konten mode tampilan normal.

Metode [getSnapVerticalSplitter](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) dan [setSnapVerticalSplitter](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) menentukan apakah pemisah vertikal harus menempel ke keadaan diminimalkan ketika wilayah samping cukup kecil.

Properti [getPreferSingleView](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) dan [setPreferSingleView](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) menentukan apakah pengguna lebih suka melihat satu wilayah konten penuh jendela daripada tampilan normal standar dengan tiga wilayah konten. Jika diaktifkan, aplikasi dapat memilih untuk menampilkan salah satu wilayah konten di seluruh jendela.

Metode [getVerticalBarState](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) dan [getHorizontalBarState](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) menentukan keadaan yang harus ditampilkan oleh baris pemisah horizontal atau vertikal. Baris pemisah horizontal memisahkan slide dari wilayah konten di bawah slide, sedangkan baris pemisah vertikal memisahkan slide dari wilayah konten samping. Nilai yang mungkin adalah: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) dan [SplitterBarStateType.Restored](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Metode [getRestoredLeft](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) dan [getRestoredTop](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) menentukan ukuran wilayah slide atas atau samping pada tampilan normal, ketika nilai [SplitterBarStateType.Restored](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SplitterBarStateType#Restored) diterapkan pada [getVerticalBarState](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) dan [getHorizontalBarState](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) secara bersamaan.

## **Tentang Memulihkan NormalViewProperties**

Menentukan ukuran wilayah slide (lebar ketika menjadi anak dari [getRestoredTop](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), tinggi ketika menjadi anak dari [getRestoredLeft](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) pada tampilan normal, ketika wilayah tersebut memiliki ukuran pemulihan variabel (tidak diminimalkan maupun dimaksimalkan).  

Metode [getDimensionSize](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) menentukan ukuran wilayah slide (lebar ketika menjadi anak dari restoredTop, tinggi ketika menjadi anak dari restoredLeft).  

Metode [getAutoAdjust](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) menentukan apakah ukuran wilayah konten samping harus menyesuaikan dengan ukuran baru saat mengubah ukuran jendela yang berisi tampilan dalam aplikasi.  

Contoh berikut menunjukkan bagaimana Anda dapat mengakses properti [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) untuk sebuah presentasi.

```javascript

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

## **Atur Nilai Zoom Default**

{{% alert color="primary" %}} 

Aspose.Slides untuk Node.js via Java kini mendukung pengaturan nilai zoom default untuk presentasi sehingga saat presentasi dibuka, zoom sudah diatur. Hal ini dapat dilakukan dengan mengatur [ViewProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ViewProperties) dari sebuah presentasi. [getSlideViewProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) serta [getNotesViewProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) dapat diatur secara programatis. Pada topik ini, kami akan melihat dengan contoh cara mengatur [View Properties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ViewProperties) dari [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation) di [Aspose.Slides](/slides/id/).

{{% /alert %}} 

Untuk mengatur properti tampilan, ikuti langkah-langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).
1. Atur [View Properties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ViewProperties) dari [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).
1. Simpan presentasi sebagai file [PPTX](https://docs.fileformat.com/presentation/pptx/). Pada contoh di bawah, kami telah mengatur nilai zoom untuk tampilan slide serta tampilan catatan.

```javascript
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

## **FAQ**

**Apakah saya dapat mengatur pengaturan tampilan yang berbeda untuk bagian yang berbeda dari sebuah presentasi?**

[View settings](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/getviewproperties/) didefinisikan pada tingkat presentasi ([Normal View](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), bukan per bagian, sehingga satu set parameter berlaku untuk seluruh dokumen saat dibuka.

**Apakah saya dapat mendefinisikan sebelumnya keadaan tampilan yang berbeda untuk pengguna yang berbeda?**

Tidak. Pengaturan disimpan dalam file dan bersifat bersama. Aplikasi penampil dapat menghormati preferensi pengguna, tetapi file itu sendiri hanya berisi satu set properti tampilan.

**Apakah saya dapat menyiapkan templat dengan View Properties yang telah ditentukan sehingga presentasi baru dibuka dengan cara yang sama?**

Ya. Karena [view properties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/getviewproperties/) disimpan pada tingkat presentasi, Anda dapat menyertakannya dalam sebuah templat dan membuat dokumen baru darinya dengan konfigurasi tampilan awal yang sama.