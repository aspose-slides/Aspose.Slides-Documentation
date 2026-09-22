---
title: Mengambil dan Memperbarui Properti Tampilan Presentasi di Java
linktitle: Properti Tampilan
type: docs
weight: 80
url: /id/java/presentation-view-properties/
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
- Java
- Aspose.Slides
description: "Temukan properti tampilan Aspose.Slides untuk Java untuk menyesuaikan format slide PPT, PPTX, dan ODP—atur tata letak, tingkat zoom, dan pengaturan tampilan."
---
## **Introduction**

Tampilan normal terdiri dari tiga wilayah konten: slide itu sendiri, wilayah konten samping, dan wilayah konten bagian bawah. Properti yang berkaitan dengan penempatan berbagai wilayah konten. Informasi ini memungkinkan aplikasi menyimpan status tampilan ke file, sehingga saat dibuka kembali tampilan berada dalam keadaan yang sama seperti saat presentasi terakhir disimpan.

Metode [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) telah ditambahkan untuk memberikan akses ke properti tampilan normal presentasi. 

[INormalViewProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/INormalViewRestoredProperties) interface dan turunannya, serta enum [SplitterBarStateType](https://reference.aspose.com/slides/id/java/com.aspose.slides/SplitterBarStateType) telah ditambahkan.

## **About INormalViewProperties**

Mewakili properti tampilan normal.

Metode [getShowOutlineIcons](https://reference.aspose.com/slides/id/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) dan [setShowOutlineIcons](https://reference.aspose.com/slides/id/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) menentukan apakah aplikasi harus menampilkan ikon saat menampilkan konten outline di salah satu wilayah konten mode tampilan normal.

Metode [getSnapVerticalSplitter](https://reference.aspose.com/slides/id/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) dan [setSnapVerticalSplitter](https://reference.aspose.com/slides/id/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) menentukan apakah pemisah vertikal harus menempel ke keadaan terkecil ketika wilayah samping cukup kecil.

Properti [getPreferSingleView](https://reference.aspose.com/slides/id/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) dan [setPreferSingleView](https://reference.aspose.com/slides/id/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) menentukan apakah pengguna lebih suka melihat satu wilayah konten penuh-jendela dibandingkan tampilan normal standar dengan tiga wilayah konten. Jika diaktifkan, aplikasi dapat memilih menampilkan salah satu wilayah konten di seluruh jendela.

Metode [getVerticalBarState](https://reference.aspose.com/slides/id/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) dan [getHorizontalBarState](https://reference.aspose.com/slides/id/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) menentukan keadaan yang harus ditampilkan pada bilah pemisah horizontal atau vertikal. Bilah pemisah horizontal memisahkan slide dari wilayah konten di bawah slide, bilah pemisah vertikal memisahkan slide dari wilayah konten samping. Nilai yang mungkin adalah: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/id/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/id/java/com.aspose.slides/SplitterBarStateType#Maximized) dan [SplitterBarStateType.Restored](https://reference.aspose.com/slides/id/java/com.aspose.slides/SplitterBarStateType#Restored).

Metode [getRestoredLeft](https://reference.aspose.com/slides/id/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) dan [getRestoredTop](https://reference.aspose.com/slides/id/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) menentukan ukuran wilayah slide atas atau samping pada tampilan normal, ketika nilai [SplitterBarStateType.Restored](https://reference.aspose.com/slides/id/java/com.aspose.slides/SplitterBarStateType#Restored) diterapkan untuk [getVerticalBarState](https://reference.aspose.com/slides/id/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) dan [getHorizontalBarState](https://reference.aspose.com/slides/id/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) secara bersangkutan.

## **About Restoring INormalViewProperties** 

Menentukan ukuran wilayah slide (lebar ketika anak dari [getRestoredTop](https://reference.aspose.com/slides/id/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), tinggi ketika anak dari [getRestoredLeft](https://reference.aspose.com/slides/id/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) pada tampilan normal, ketika wilayah tersebut memiliki ukuran pemulihan variabel (tidak terkecil maupun terbesar). 

Metode [getDimensionSize](https://reference.aspose.com/slides/id/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) menentukan ukuran wilayah slide (lebar ketika anak dari restoredTop, tinggi ketika anak dari restoredLeft).

Metode [getAutoAdjust](https://reference.aspose.com/slides/id/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) menentukan apakah ukuran wilayah konten samping harus menyesuaikan dengan ukuran baru saat mengubah ukuran jendela yang berisi tampilan dalam aplikasi.

Contoh berikut menunjukkan cara mengakses properti [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) untuk sebuah presentasi.

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

## **Set the Default Zoom Value**

{{% alert color="info" %}} 

Aspose.Slides for Java kini mendukung penetapan nilai zoom default untuk presentasi sehingga ketika presentasi dibuka, zoom sudah diatur. Ini dapat dilakukan dengan mengatur [ViewProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/ViewProperties) dari sebuah presentasi. [getSlideViewProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) serta [getNotesViewProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) dapat diatur secara programatis. Pada topik ini, kita akan melihat dengan contoh cara mengatur [View Properties](https://reference.aspose.com/slides/id/java/com.aspose.slides/ViewProperties) dari [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation) di Aspose.Slides.

{{% /alert %}} 

Untuk mengatur properti tampilan, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation).
1. Atur [View Properties](https://reference.aspose.com/slides/id/java/com.aspose.slides/ViewProperties) dari [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation).
1. Tulis presentasi sebagai file [PPTX](https://docs.fileformat.com/presentation/pptx/).
   Dalam contoh di bawah ini, kami telah mengatur nilai zoom untuk tampilan slide serta tampilan catatan.

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

## **Set the Grid Spacing**

Gunakan [Presentation.getViewProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getViewProperties--) untuk mengakses pengaturan tampilan seluruh presentasi. Metode [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/id/java/com.aspose.slides/iviewproperties/#getGridSpacing--) dan [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/id/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) membaca atau mengubah interval grid pengeditan yang mendasarinya. Pengaturan ini berlaku untuk seluruh presentasi, bukan untuk slide individu. Jarak grid ditentukan dalam poin, di mana 72 poin sama dengan satu inci. Gunakan nilai positif, sesuai dokumentasi API.

Contoh berikut membuka `demo.pptx` yang ada, mencetak jarak grid saat ini, mengatur interval seperempat inci, dan menyimpan hasilnya.

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

Grid berbeda dari [drawing guides](/slides/id/java/drawing-guides/). Jarak grid mengontrol interval reguler, sementara drawing guides adalah garis penyelarasan horizontal atau vertikal yang diposisikan secara individual. Menambahkan, memindahkan, atau menghapus drawing guides tidak mengubah jarak grid.

Baik grid maupun drawing guides merupakan bantuan pengeditan. Mereka tidak dirender sebagai konten slide dalam PDF, gambar, SVG, atau tayangan slide. Menyimpan jarak grid tidak menjamin editor akan menampilkan grid: visibilitasnya juga bergantung pada preferensi penampil atau editor.

## **FAQ**

**Why is the grid not visible after I reopen the presentation?**

File menyimpan jarak grid, tetapi editor yang mengontrol apakah grid ditampilkan. Periksa pengaturan visibilitas grid pada editor.

**Does clearing drawing guides change the grid spacing?**

Tidak. Drawing guides dan jarak grid merupakan pengaturan yang independen. Menghapus guides tidak mengubah interval grid yang disimpan.

**Can I set different view settings for different sections of a presentation?**

[Pengaturan tampilan](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getViewProperties--) didefinisikan pada tingkat presentasi ([Normal View](https://reference.aspose.com/slides/id/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/id/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), bukan per bagian, sehingga satu set parameter berlaku untuk seluruh dokumen saat dibuka.

**Can I predefine different view states for different users?**

Tidak. Pengaturan disimpan dalam file dan bersifat bersama. Aplikasi penampil mungkin menghormati preferensi pengguna, tetapi file itu sendiri hanya berisi satu set properti tampilan.

**Can I prepare a template with predefined View Properties so new presentations open the same way?**

Ya. Karena [view properties](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getViewProperties--) disimpan pada tingkat presentasi, Anda dapat menyematkannya dalam sebuah templat dan membuat dokumen baru darinya dengan konfigurasi tampilan awal yang sama.