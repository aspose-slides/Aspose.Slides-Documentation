---
title: Mengambil dan Memperbarui Properti Tampilan Presentasi di Android
linktitle: Properti Tampilan
type: docs
weight: 80
url: /id/androidjava/presentation-view-properties/
keywords:
- properti tampilan
- tampilan normal
- konten garis besar
- ikon garis besar
- snap pemisah vertikal
- tampilan tunggal
- keadaan bilah
- ukuran dimensi
- penyesuaian otomatis
- zoom default
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Temukan properti tampilan Aspose.Slides untuk Android via Java untuk menyesuaikan format slide PPT, PPTX, dan ODP - menyesuaikan tata letak, tingkat zoom, dan pengaturan tampilan."
---
## **Pendahuluan**

Tampilan normal terdiri dari tiga wilayah konten: slide itu sendiri, wilayah konten samping, dan wilayah konten bagian bawah. Properti yang berhubungan dengan penempatan wilayah konten yang berbeda. Informasi ini memungkinkan aplikasi menyimpan status tampilan ke file, sehingga ketika dibuka kembali tampilan berada dalam keadaan yang sama seperti saat presentasi terakhir disimpan.

Metode [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) telah ditambahkan untuk memberikan akses ke properti tampilan normal presentasi. 

[INormalViewProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewRestoredProperties) interface dan turunannya, enum [SplitterBarStateType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SplitterBarStateType) telah ditambahkan.

## **Tentang INormalViewProperties**

Mewakili properti tampilan normal.

Metode [getShowOutlineIcons](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) dan [setShowOutlineIcons](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) menentukan apakah aplikasi harus menampilkan ikon bila menampilkan konten garis besar di salah satu wilayah konten mode tampilan normal.

Metode [getSnapVerticalSplitter](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) dan [setSnapVerticalSplitter](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) menentukan apakah pemisah vertikal harus menempel ke keadaan diperkecil ketika wilayah samping cukup kecil.

Properti [getPreferSingleView](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) dan [setPreferSingleView](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) menentukan apakah pengguna lebih suka melihat satu wilayah konten penuh-jendela dibandingkan tampilan normal standar dengan tiga wilayah konten. Jika diaktifkan, aplikasi dapat memilih untuk menampilkan salah satu wilayah konten di seluruh jendela.

Metode [getVerticalBarState](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) dan [getHorizontalBarState](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) menentukan keadaan yang harus ditampilkan oleh bilah pemisah horizontal atau vertikal. Bilah pemisah horizontal memisahkan slide dari wilayah konten di bawah slide, bilah pemisah vertikal memisahkan slide dari wilayah konten samping. Nilai yang mungkin adalah: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) dan [SplitterBarStateType.Restored](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Metode [getRestoredLeft](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) dan [getRestoredTop](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) menentukan ukuran wilayah slide atas atau samping pada tampilan normal, ketika nilai [SplitterBarStateType.Restored](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SplitterBarStateType#Restored) diterapkan untuk [getVerticalBarState](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) dan [getHorizontalBarState](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) secara bersamaan.

## **Tentang Pemulihan INormalViewProperties**

Menentukan ukuran wilayah slide (lebar ketika menjadi anak dari [getRestoredTop](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), tinggi ketika menjadi anak dari [getRestoredLeft](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) pada tampilan normal, ketika wilayah tersebut memiliki ukuran pemulihan variabel (tidak diperkecil maupun diperbesar). 

Metode [getDimensionSize](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) menentukan ukuran wilayah slide (lebar ketika menjadi anak dari restoredTop, tinggi ketika menjadi anak dari restoredLeft).

Metode [getAutoAdjust](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) menentukan apakah ukuran wilayah konten samping harus menyesuaikan dengan ukuran baru saat mengubah ukuran jendela yang berisi tampilan dalam aplikasi.

Contoh berikut menunjukkan cara mengakses properti [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) untuk sebuah presentasi.

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

Aspose.Slides untuk Android via Java kini mendukung pengaturan nilai zoom default untuk presentasi sehingga saat presentasi dibuka, zoom sudah diatur. Hal ini dapat dilakukan dengan mengatur [ViewProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ViewProperties) dari sebuah presentasi. [getSlideViewProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) maupun [getNotesViewProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) dapat diatur secara programatik. Pada topik ini, kita akan melihat dengan contoh cara mengatur [View Properties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ViewProperties) dari [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation) di Aspose.Slides.

{{% /alert %}} 

Untuk mengatur properti tampilan, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation).
1. Atur [View Properties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ViewProperties) dari [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation).
1. Simpan presentasi sebagai file [PPTX](https://docs.fileformat.com/presentation/pptx/).
   Dalam contoh di bawah ini, kami telah mengatur nilai zoom untuk tampilan slide sekaligus tampilan catatan.

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

## **Atur Jarak Kisi**

Gunakan [Presentation.getViewProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getViewProperties--) untuk mengakses pengaturan tampilan seluruh presentasi. Metode [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) dan [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) membaca atau mengubah interval kisi penyuntingan yang mendasarinya. Pengaturan ini berlaku untuk seluruh presentasi, bukan untuk slide individu. Jarak kisi ditentukan dalam poin, di mana 72 poin sama dengan satu inci. Gunakan nilai positif, sesuai dengan dokumentasi API.

Contoh berikut membuka `demo.pptx` yang ada, mencetak jarak kisi saat ini, mengatur interval seperempat inci, dan menyimpan hasilnya.

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

Kisi berbeda dari [drawing guides](/slides/id/androidjava/drawing-guides/). Jarak kisi mengontrol interval reguler, sedangkan drawing guides adalah garis penyelarasan horizontal atau vertikal yang diposisikan secara individual. Menambahkan, memindahkan, atau menghapus drawing guides tidak mengubah jarak kisi.

Baik kisi maupun drawing guides merupakan bantuan penyuntingan. Mereka tidak dirender sebagai konten slide dalam PDF, gambar, SVG, atau pertunjukan slide. Menyimpan jarak kisi tidak menjamin editor akan menampilkan kisi: visibilitasnya juga bergantung pada preferensi penampil atau editor.

## **FAQ**

**Mengapa kisi tidak terlihat setelah saya membuka kembali presentasi?**

File menyimpan jarak kisi, tetapi editor yang mengontrol apakah kisi ditampilkan. Periksa pengaturan visibilitas kisi pada editor.

**Apakah menghapus drawing guides mengubah jarak kisi?**

Tidak. Drawing guides dan jarak kisi adalah pengaturan yang independen. Menghapus guides tidak mengubah interval kisi yang disimpan.

**Bisakah saya mengatur pengaturan tampilan yang berbeda untuk bagian-bagian berbeda dari sebuah presentasi?**

[View settings](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getViewProperties--) didefinisikan pada tingkat presentasi ([Normal View](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), bukan per bagian, sehingga satu set parameter berlaku untuk seluruh dokumen saat dibuka.

**Bisakah saya mendefinisikan sebelumnya keadaan tampilan yang berbeda untuk pengguna yang berbeda?**

Tidak. Pengaturan disimpan dalam file dan bersifat bersama. Aplikasi penampil dapat menghormati preferensi pengguna, tetapi file itu sendiri hanya berisi satu set properti tampilan.

**Bisakah saya menyiapkan templat dengan View Properties yang telah ditentukan sehingga presentasi baru terbuka dengan cara yang sama?**

Ya. Karena [view properties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getViewProperties--) disimpan pada tingkat presentasi, Anda dapat menyematkannya dalam templat dan membuat dokumen baru darinya dengan konfigurasi tampilan awal yang sama.