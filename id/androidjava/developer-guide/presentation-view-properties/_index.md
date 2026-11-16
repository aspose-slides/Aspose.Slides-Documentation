---
title: Ambil dan Perbarui Properti Tampilan Presentasi di Android
linktitle: Properti Tampilan
type: docs
weight: 80
url: /id/androidjava/presentation-view-properties/
keywords:
- properti tampilan
- tampilan normal
- konten outline
- ikon outline
- pemisah vertikal snap
- tampilan tunggal
- status bilah
- ukuran dimensi
- penyesuaian otomatis
- zoom bawaan
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Gunakan Aspose.Slides untuk Android via Java untuk mengonfigurasi tata letak tampilan normal, zoom slide dan catatan, jarak kisi, serta visibilitas komentar dalam presentasi PowerPoint."
---
## **Pendahuluan**

Dalam tampilan normal PowerPoint, slide muncul di antara panel samping untuk thumbnail atau outline dan panel catatan di bawah. Aspose.Slides untuk Android via Java menampilkan preferensi penyuntingan yang disimpan dari presentasi melalui [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--). Ini mencakup tata letak panel, tingkat zoom, jarak kisi, dan visibilitas komentar.

## **Tentang INormalViewProperties**

Gunakan [getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNormalViewProperties--) untuk mengakses antarmuka [INormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) mengontrol apakah ikon muncul di samping judul slide dalam outline. [setSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) memungkinkan panel samping menempel pada keadaan diperkecil ketika pengguna mempersempitnya. [setPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) menunjukkan preferensi menampilkan satu panel dalam jendela penuh.

[setVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) mengontrol pembagi antara panel samping dan slide. [setHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) mengontrol pembagi di atas panel catatan. Keduanya menerima nilai [SplitterBarStateType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/splitterbarstatetype/) berupa `Minimized`, `Maximized`, atau `Restored`.

## **Tentang Memulihkan INormalViewProperties**

Saat pembagi dipulihkan, [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) menyediakan ukuran panel samping yang disimpan dan [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) menyediakan ukuran area slide atas yang disimpan. Keduanya mengekspos [INormalViewRestoredProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/). Metode [setDimensionSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) menerima persentase dari 0 hingga 100, dan [setAutoAdjust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) mengontrol apakah editor menyesuaikan ukuran ketika jendela diubah ukurannya.

Contoh ini memperbarui presentasi yang ada. Ini memulihkan pembagi horizontal, mengatur ukuran yang dikembalikan oleh [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) menjadi 80% dengan penyesuaian otomatis diaktifkan, dan memaksimalkan pembagi vertikal. Ia juga memanggil [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) untuk menampilkan ikon dalam tampilan outline.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    INormalViewProperties normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(SplitterBarStateType.Restored);
    normalView.setVerticalBarState(SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Nilai Zoom Bawaan**

[getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getSlideViewProperties--) dan [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNotesViewProperties--) menyimpan pengaturan zoom independen untuk editor. Pengaturan ini tidak memengaruhi dimensi slide, pemutaran slide-show, atau resolusi ekspor gambar.

Contoh ini membuka presentasi yang ada dan memanggil [setVariableScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) untuk menyesuaikan slide dengan jendela penyuntingan. Untuk halaman catatan, ia menonaktifkan skala otomatis dan memanggil [setScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setScale-int-) untuk mengatur zoom tetap 80%.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Jarak Kisi**

[setGridSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) mengatur jarak antara garis kisi penyuntingan di seluruh presentasi. Nilai yang diberikan harus positif dalam poin, dengan 72 poin per inci. Contoh ini mencetak jarak saat ini dalam presentasi yang ada dan menyimpan kisi seperempat inci dengan mengatur interval menjadi 18 poin.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18f);

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kisi berulang pada interval tetap. [Panduan gambar](/slides/id/androidjava/drawing-guides/) menandai posisi horizontal atau vertikal individual. Kedua elemen ini merupakan bantuan penyuntingan dan muncul hanya di editor yang menampilkannya. Slide show serta ekspor ke PDF, gambar, atau SVG tidak menyertakannya.

## **Tampilkan atau Sembunyikan Komentar Saat Membuka Presentasi**

[setShowComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) menyimpan preferensi yang digunakan editor yang kompatibel saat membuka presentasi. Untuk presentasi yang ada dengan komentar, contoh ini mencetak pengaturan saat ini dan menyimpan salinan dengan komentar disembunyikan. Ia juga memanggil [setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) dengan [ViewType.SlideView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/#SlideView) sehingga salinan terbuka dalam tampilan slide.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("comments.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current comment visibility: " + viewProperties.getShowComments());

    viewProperties.setShowComments(NullableBool.False);
    viewProperties.setLastView(ViewType.SlideView);

    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Menyembunyikan komentar mempertahankan teks, penulis, posisi, balasan, dan statusnya. Untuk mengubah komentar itu sendiri, lihat [Komentar Presentasi](/slides/id/androidjava/presentation-comments/). Pengaturan ekspor mengontrol apakah komentar muncul dalam PDF, HTML, gambar, catatan, atau handout.

## **FAQ**

**Kenapa kisi tersembunyi saat saya membuka kembali presentasi?**

Presentasi menyimpan interval kisi. Untuk melihat kisi, aktifkan visibilitas kisi di editor.

**Apakah menghapus panduan gambar mengubah jarak kisi?**

Tidak. Menambahkan, memindahkan, atau menghapus panduan tidak mengubah interval kisi.

**Apakah bagian berbeda dalam satu presentasi dapat memiliki pengaturan tampilan yang berbeda?**

Tidak. [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) berlaku untuk seluruh presentasi.

**Apakah saya dapat menyimpan pengaturan tampilan yang berbeda untuk pengguna yang berbeda?**

Berkas menyimpan satu set properti tampilan untuk semua orang. Editor mungkin juga menerapkan preferensi lokal pengguna.

**Apakah saya dapat menyimpan pengaturan tampilan dalam templat?**

Ya. Presentasi yang dibuat dari templat mewarisi pengaturan tampilan yang disimpannya.