---
title: Ambil dan Perbarui Properti Tampilan Presentasi di Java
linktitle: Properti Tampilan
type: docs
weight: 80
url: /id/java/presentation-view-properties/
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
- Java
- Aspose.Slides
description: "Gunakan Aspose.Slides untuk Java untuk mengonfigurasi tata letak tampilan normal, zoom slide dan catatan, jarak grid, serta visibilitas komentar pada presentasi PowerPoint."
---
## **Pendahuluan**

Dalam tampilan normal PowerPoint, slide muncul di antara panel samping untuk thumbnail atau outline dan panel catatan di bawah. Aspose.Slides for Java mengekspos preferensi penyuntingan yang disimpan dalam presentasi melalui [Presentation.getViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--). Ini termasuk tata letak panel, tingkat zoom, jarak grid, dan visibilitas komentar.

## **Tentang INormalViewProperties**

Gunakan [getNormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getNormalViewProperties--) untuk mengakses antarmuka [INormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) mengontrol apakah ikon muncul di sebelah judul slide dalam outline. [setSnapVerticalSplitter](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) memungkinkan panel samping menempel ke keadaan diperkecil saat pengguna mempersempitnya. [setPreferSingleView](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) menunjukkan preferensi menampilkan satu panel dalam jendela penuh.

[setVerticalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) mengontrol pembagi antara panel samping dan slide. [setHorizontalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) mengontrol pembagi di atas panel catatan. Kedua metode menerima nilai [SplitterBarStateType](https://reference.aspose.com/slides/java/com.aspose.slides/splitterbarstatetype/) berupa `Minimized`, `Maximized`, atau `Restored`.

## **Tentang Mengembalikan INormalViewProperties**

Ketika pembagi dipulihkan, [getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) memberikan ukuran tersimpan dari panel samping dan [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredTop--) memberikan ukuran tersimpan dari area slide atas. Kedua metode mengekspos [INormalViewRestoredProperties](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/). Metode [setDimensionSize](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) menerima persentase dari 0 hingga 100, dan [setAutoAdjust](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) mengontrol apakah penyunting menyesuaikan ukuran saat jendela diubah ukurannya.

Contoh ini memperbarui presentasi yang ada. Ia mengembalikan pembagi horizontal, mengatur ukuran yang dikembalikan oleh [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredTop--) menjadi 80% dengan penyesuaian otomatis diaktifkan, dan memaksimalkan pembagi vertikal. Ia juga memanggil [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) untuk menampilkan ikon dalam tampilan outline.

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

## **Atur Nilai Zoom Default**

[getSlideViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getSlideViewProperties--) dan [getNotesViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getNotesViewProperties--) menyimpan pengaturan zoom terpisah untuk penyunting. Pengaturan ini tidak memengaruhi dimensi slide, pemutaran slide-show, atau resolusi ekspor gambar.

Contoh ini membuka presentasi yang ada dan memanggil [setVariableScale](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) untuk menyesuaikan slide dengan jendela penyunting. Untuk halaman catatan, ia menonaktifkan skala otomatis dan memanggil [setScale](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#setScale-int-) untuk menetapkan zoom tetap 80%.

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

## **Atur Jarak Grid**

[setGridSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) mengatur jarak antara garis grid penyuntingan di seluruh presentasi. Nilai yang diterima adalah nilai positif dalam poin, dengan 72 poin per inci. Contoh ini mencetak jarak saat ini dalam presentasi yang ada dan menyimpan grid seperempat inci dengan mengatur interval menjadi 18 poin.

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

Grid mengulang pada interval tetap. [Drawing guides](/slides/id/java/drawing-guides/) menandai posisi horizontal atau vertikal individu. Kedua alat tersebut merupakan bantuan penyuntingan dan hanya muncul di penyunting yang menampilkannya. Slide show dan ekspor ke PDF, gambar, atau SVG tidak menyertakannya.

## **Tampilkan atau Sembunyikan Komentar Saat Membuka Presentasi**

[setShowComments](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) menyimpan preferensi yang digunakan penyunting yang kompatibel saat membuka presentasi. Untuk presentasi yang ada dengan komentar, contoh ini mencetak pengaturan saat ini dan menyimpan salinan dengan komentar disembunyikan. Ia juga memanggil [setLastView](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setLastView-int-) dengan [ViewType.SlideView](https://reference.aspose.com/slides/java/com.aspose.slides/viewtype/#SlideView) sehingga salinan terbuka dalam tampilan slide.

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

Menyembunyikan komentar mempertahankan teks, penulis, posisi, balasan, dan statusnya. Untuk mengubah komentar itu sendiri, lihat [Presentation Comments](/slides/id/java/presentation-comments/). Pengaturan ekspor mengontrol apakah komentar muncul dalam PDF, HTML, gambar, catatan, atau handout.

## **FAQ**

**Mengapa grid disembunyikan saat saya membuka kembali presentasi?**  
Presentasi menyimpan interval grid. Untuk melihat grid, aktifkan visibilitas grid di penyunting.

**Apakah menghapus drawing guides mengubah jarak grid?**  
Tidak. Menambahkan, memindahkan, atau menghapus sebuah panduan tidak mengubah interval grid.

**Dapatkah bagian berbeda dari sebuah presentasi memiliki pengaturan tampilan yang berbeda?**  
Tidak. [Presentation.getViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--) berlaku untuk seluruh presentasi.

**Bisakah saya menyimpan pengaturan tampilan yang berbeda untuk pengguna yang berbeda?**  
File menyimpan satu set properti tampilan untuk semua orang. Penyunting juga dapat menerapkan preferensi lokal pengguna.

**Bisakah saya menyimpan pengaturan tampilan dalam sebuah templat?**  
Ya. Presentasi yang dibuat dari templat mewarisi pengaturan tampilan yang disimpannya.