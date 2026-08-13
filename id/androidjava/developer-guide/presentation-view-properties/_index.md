---
title: Mengambil dan Memperbarui Properti Tampilan Presentasi di Android
linktitle: Properti Tampilan
type: docs
weight: 80
url: /id/androidjava/presentation-view-properties/
keywords: 
- properti tampilan
- tampilan normal
- konten outline
- ikon outline
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
description: "Temukan properti tampilan Aspose.Slides untuk Android melalui Java untuk menyesuaikan format slide PPT, PPTX, dan ODP—atur tata letak, tingkat zoom, dan pengaturan tampilan."
---
## **Pendahuluan**

Tampilan normal terdiri dari tiga wilayah konten: slide itu sendiri, wilayah konten samping, dan wilayah konten bawah. Properti yang berhubungan dengan penempatan berbagai wilayah konten. Informasi ini memungkinkan aplikasi menyimpan status tampilan ke file, sehingga saat dibuka kembali tampilan berada dalam keadaan yang sama seperti saat presentasi terakhir disimpan.

Metode [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) telah ditambahkan untuk memberikan akses ke properti tampilan normal presentasi.

[INormalViewProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewRestoredProperties) antarmuka dan turunannya, [SplitterBarStateType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SplitterBarStateType) enum telah ditambahkan.

## **Tentang INormalViewProperties**

Mewakili properti tampilan normal.

Metode [getShowOutlineIcons](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) dan [setShowOutlineIcons](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) menentukan apakah aplikasi harus menampilkan ikon ketika menampilkan konten outline di salah satu wilayah konten mode tampilan normal.

Metode [getSnapVerticalSplitter](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) dan [setSnapVerticalSplitter](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) menentukan apakah pemisah vertikal harus menempel ke keadaan diperkecil ketika wilayah samping cukup kecil.

Properti [getPreferSingleView](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) dan [setPreferSingleView](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) menentukan apakah pengguna lebih suka melihat wilayah konten tunggal layar penuh dibandingkan tampilan normal standar dengan tiga wilayah konten. Jika diaktifkan, aplikasi dapat memilih menampilkan salah satu wilayah konten di seluruh jendela.

Metode [getVerticalBarState](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) dan [getHorizontalBarState](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) menentukan keadaan yang harus ditampilkan pada batang pemisah horizontal atau vertikal. Batang pemisah horizontal memisahkan slide dari wilayah konten di bawah slide, batang pemisah vertikal memisahkan slide dari wilayah konten samping. Nilai yang mungkin adalah: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SplitterBarStateType#Maximized), dan [SplitterBarStateType.Restored](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Metode [getRestoredLeft](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) dan [getRestoredTop](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) menentukan ukuran wilayah slide atas atau samping tampilan normal, ketika nilai [SplitterBarStateType.Restored](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SplitterBarStateType#Restored) diterapkan pada [getVerticalBarState](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) dan [getHorizontalBarState](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) secara bersangkutan.

## **Tentang Memulihkan INormalViewProperties**

Menentukan ukuran wilayah slide (lebar ketika menjadi turunan dari [getRestoredTop](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), tinggi ketika menjadi turunan dari [getRestoredLeft](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) pada tampilan normal, ketika wilayah tersebut memiliki ukuran dipulihkan yang variabel (tidak diperkecil maupun dimaksimalkan).

Metode [getDimensionSize](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) menentukan ukuran wilayah slide (lebar ketika menjadi anak dari restoredTop, tinggi ketika menjadi anak dari restoredLeft).

Metode [getAutoAdjust](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) menentukan apakah ukuran wilayah konten samping harus menyesuaikan dengan ukuran baru saat mengubah ukuran jendela yang berisi tampilan dalam aplikasi.

Contoh di bawah ini menunjukkan cara mengakses properti [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) untuk sebuah presentasi.

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

Aspose.Slides untuk Android melalui Java kini mendukung pengaturan nilai zoom default untuk presentasi sehingga ketika presentasi dibuka, zoom sudah diatur. Hal ini dapat dilakukan dengan mengatur [ViewProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ViewProperties) dari sebuah presentasi. [getSlideViewProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) serta [getNotesViewProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) dapat diatur secara programatis. Pada topik ini, kita akan melihat contoh cara mengatur [View Properties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ViewProperties) dari [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation) dalam [Aspose.Slides](/slides/id/).

{{% /alert %}} 

Untuk mengatur properti tampilan, ikuti langkah-langkah berikut:

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation).
1. Atur [View Properties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ViewProperties) dari [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation).
1. Simpan presentasi sebagai file [PPTX](https://docs.fileformat.com/presentation/pptx/) . Pada contoh di bawah, kami telah mengatur nilai zoom untuk tampilan slide serta tampilan catatan.

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

## **FAQ**

### Bisakah saya mengatur pengaturan tampilan yang berbeda untuk bagian yang berbeda dari sebuah presentasi?

[Pengaturan tampilan](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getViewProperties--) didefinisikan pada tingkat presentasi ([Normal View](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), bukan per bagian, sehingga satu set parameter berlaku untuk seluruh dokumen saat dibuka.

### Bisakah saya menentukan sebelumnya keadaan tampilan yang berbeda untuk pengguna yang berbeda?

Tidak. Pengaturan disimpan dalam file dan bersifat bersama. Aplikasi penampil mungkin menghormati preferensi pengguna, tetapi file itu sendiri berisi satu set properti tampilan.

### Bisakah saya menyiapkan templat dengan View Properties yang telah ditentukan sebelumnya sehingga presentasi baru terbuka dengan cara yang sama?

Ya. Karena [view properties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getViewProperties--) disimpan pada tingkat presentasi, Anda dapat menyematkannya dalam templat dan membuat dokumen baru darinya dengan konfigurasi tampilan awal yang sama.