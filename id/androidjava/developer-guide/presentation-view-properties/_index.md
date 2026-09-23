---
title: Mengambil dan Memperbarui Properti Tampilan Presentasi di Android
linktitle: Properti Tampilan
type: docs
weight: 80
url: /id/androidjava/presentation-view-properties/
keywords:
- properti tampilan
- tampilan normal
- konten kerangka
- ikon kerangka
- snap pemisah vertikal
- tampilan tunggal
- status bar
- ukuran dimensi
- penyesuaian otomatis
- zoom default
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Temukan properti tampilan Aspose.Slides untuk Android via Java untuk menyesuaikan format slide PPT, PPTX, dan ODP—atur tata letak, tingkat zoom, dan pengaturan tampilan."
---
## **Pendahuluan**

Tampilan normal terdiri dari tiga wilayah konten: slide itu sendiri, wilayah konten samping, dan wilayah konten bagian bawah. Properti yang berkaitan dengan penempatan berbagai wilayah konten. Informasi ini memungkinkan aplikasi menyimpan status tampilan ke file, sehingga ketika dibuka kembali tampilan berada dalam keadaan yang sama seperti saat presentasi terakhir kali disimpan.

Metode[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) telah ditambahkan untuk menyediakan akses ke properti tampilan normal dari presentasi.  

[INormalViewProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewRestoredProperties) antarmuka dan turunannya, [SplitterBarStateType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SplitterBarStateType) enum telah ditambahkan.

## **Tentang INormalViewProperties**

Mewakili properti tampilan normal.

Metode[getShowOutlineIcons](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) dan [setShowOutlineIcons](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) menentukan apakah aplikasi harus menampilkan ikon saat menampilkan konten kerangka dalam salah satu wilayah konten mode tampilan normal.

Metode[getSnapVerticalSplitter](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) dan [setSnapVerticalSplitter](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) menentukan apakah pemisah vertikal harus menempel pada keadaan diperkecil ketika wilayah samping cukup kecil.

Properti[getPreferSingleView](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) dan [setPreferSingleView](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) menentukan apakah pengguna lebih suka melihat satu wilayah konten penuh‑jendela dibandingkan tampilan normal standar dengan tiga wilayah konten. Jika diaktifkan, aplikasi dapat memilih untuk menampilkan salah satu wilayah konten di seluruh jendela.

Metode[getVerticalBarState](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) dan [getHorizontalBarState](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) menentukan keadaan bar pemisah horizontal atau vertikal yang harus ditampilkan. Bar pemisah horizontal memisahkan slide dari wilayah konten di bawah slide, bar pemisah vertikal memisahkan slide dari wilayah konten samping. Nilai yang mungkin adalah [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) dan [SplitterBarStateType.Restored](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Metode[getRestoredLeft](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) dan [getRestoredTop](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) menentukan ukuran wilayah slide atas atau samping pada tampilan normal, ketika nilai [SplitterBarStateType.Restored](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SplitterBarStateType#Restored) diterapkan pada[getVerticalBarState](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) dan[getHorizontalBarState](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) masing‑masing.

## **Tentang Memulihkan INormalViewProperties**

Menentukan ukuran wilayah slide (lebar ketika menjadi anak dari[getRestoredTop](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), tinggi ketika menjadi anak dari[getRestoredLeft](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) pada tampilan normal, ketika wilayah tersebut memiliki ukuran terpulihkan yang variabel (tidak diperkecil maupun diperbesar).  

Metode[getDimensionSize](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) menentukan ukuran wilayah slide (lebar ketika anak dari restoredTop, tinggi ketika anak dari restoredLeft).  

Metode[getAutoAdjust](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) menentukan apakah ukuran wilayah konten samping harus menyesuaikan ukuran baru saat mengubah ukuran jendela yang berisi tampilan dalam aplikasi  

Contoh di bawah ini menunjukkan cara mengakses [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) properti untuk sebuah presentasi.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Pulihkan properti tampilan presentasi
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Atur Nilai Zoom Default**

{{% alert color="info" %}} 

Aspose.Slides untuk Android via Java kini mendukung pengaturan nilai zoom default untuk presentasi sehingga ketika presentasi dibuka, zoom sudah diatur. Hal ini dapat dilakukan dengan menyetel [ViewProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ViewProperties) dari sebuah presentasi. [getSlideViewProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) serta [getNotesViewProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) dapat diatur secara programatik. Pada topik ini, kami akan melihat contoh cara menyetel [View Properties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ViewProperties) dari [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation) di Aspose.Slides.

{{% /alert %}} 

Untuk menyetel properti tampilan, ikuti langkah‑langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation).
1. Setel [View Properties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ViewProperties) dari [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation).
1. Tuliskan presentasi sebagai file [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   Pada contoh di bawah, kami telah menyetel nilai zoom untuk tampilan slide maupun tampilan catatan.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Mengatur properti tampilan presentasi
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Nilai zoom dalam persentase untuk tampilan slide
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Nilai zoom dalam persentase untuk tampilan catatan 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Jarak Grid**

Gunakan [Presentation.getViewProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getViewProperties--) untuk mengakses pengaturan tampilan tingkat presentasi. Metode [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) dan [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) membaca atau mengubah interval grid penyuntingan yang mendasarinya. Pengaturan ini berlaku untuk seluruh presentasi, bukan untuk satu slide tertentu. Jarak grid ditentukan dalam poin, di mana 72 poin sama dengan satu inci. Gunakan nilai positif, sesuai dengan dokumentasi API.

Contoh berikut membuka file `demo.pptx` yang ada, mencetak jarak grid saat ini, mengatur interval seperempat inci, dan menyimpan hasilnya.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("demo.pptx");
try {
    float gridSpacing = presentation.getViewProperties().getGridSpacing();
    System.out.println("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18f);
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Grid berbeda dari [drawing guides](/slides/id/androidjava/drawing-guides/). Jarak grid mengontrol interval reguler, sementara panduan gambar adalah garis penyelarasan horizontal atau vertikal yang diposisikan secara individual. Menambahkan, memindahkan, atau menghapus panduan gambar tidak mengubah jarak grid.

Kedua grid dan panduan gambar merupakan bantuan penyuntingan. Mereka tidak dirender sebagai konten slide dalam PDF, gambar, SVG, atau tayangan slide. Menyimpan jarak grid tidak menjamin bahwa penyunting akan menampilkan grid: visibilitasnya juga tergantung pada preferensi penampil atau penyunting.

## **Tampilkan atau Sembunyikan Komentar Saat Membuka Presentasi**

Gunakan [Presentation.getViewProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getViewProperties--) untuk mengakses pengaturan tampilan tingkat presentasi. Gunakan [IViewProperties.getShowComments](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iviewproperties/#getShowComments--) dan [IViewProperties.setShowComments](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) untuk membaca atau mengubah preferensi yang disimpan mengenai apakah komentar harus ditampilkan saat presentasi dibuka di PowerPoint atau penyunting kompatibel lainnya.

Pengaturan ini hanya mengontrol preferensi tampilan yang disimpan. Tidak menambah, menghapus, mengedit, atau menyelesaikan komentar. Menyembunyikan komentar mempertahankan isi, penulis, posisi, balasan, dan statusnya. Lihat [Presentation Comments](/slides/id/androidjava/presentation-comments/) untuk operasi yang mengubah komentar itu sendiri.

Contoh berikut memerlukan file `comments.pptx` yang sudah ada dan berisi komentar. Ia mencetak pengaturan visibilitas saat ini, meminta komentar disembunyikan, dan menyimpan PPTX baru tanpa menghapus komentar apa pun. Ia juga menggunakan [IViewProperties.setLastView](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) dengan [ViewType.SlideView](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/viewtype/#SlideView) untuk mengonfigurasi tampilan penyuntingan awal bersamaan dengan visibilitas komentar.

```java
import com.aspose.slides.NullableBool;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation("comments.pptx");
try {
    byte showComments = presentation.getViewProperties().getShowComments();
    System.out.println("Current comment visibility: " + showComments);

    presentation.getViewProperties().setShowComments(NullableBool.False);
    presentation.getViewProperties().setLastView(ViewType.SlideView);
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pengaturan ini tidak menentukan apakah komentar termasuk dalam ekspor PDF, HTML, gambar, catatan, atau handout. Konfigurasikan opsi khusus ekspor yang relevan secara terpisah.

## **FAQ**

**Mengapa grid tidak terlihat setelah saya membuka kembali presentasi?**

File menyimpan jarak grid, tetapi penyunting yang mengontrol apakah grid ditampilkan. Periksa pengaturan visibilitas grid pada penyunting.

**Apakah menghapus panduan gambar mengubah jarak grid?**

Tidak. Panduan gambar dan jarak grid adalah pengaturan yang independen. Menghapus panduan tidak mengubah interval grid yang disimpan.

**Bisakah saya mengatur pengaturan tampilan yang berbeda untuk bagian‑bagian berbeda dari sebuah presentasi?**

Pengaturan tampilan didefinisikan pada tingkat presentasi (Normal View/Slide View), bukan per bagian, sehingga satu set parameter berlaku untuk seluruh dokumen saat dibuka.

**Bisakah saya mendefinisikan sebelumnya keadaan tampilan yang berbeda untuk pengguna yang berbeda?**

Tidak. Pengaturan disimpan di dalam file dan bersifat bersama. Aplikasi penampil mungkin menghormati preferensi pengguna, tetapi file itu sendiri hanya berisi satu set properti tampilan.

**Bisakah saya menyiapkan templat dengan View Properties yang telah ditentukan sehingga presentasi baru terbuka dengan cara yang sama?**

Ya. Karena view properties disimpan pada tingkat presentasi, Anda dapat menyematkannya dalam templat dan membuat dokumen baru darinya dengan konfigurasi tampilan awal yang sama.