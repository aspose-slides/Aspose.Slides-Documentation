---
title: Mengambil dan Memperbarui Properti Tampilan Presentasi di .NET
linktitle: Properti Tampilan
type: docs
weight: 80
url: /id/net/presentation-view-properties/
keywords:
- properti tampilan
- tampilan normal
- konten outline
- ikon outline
- pemisah vertikal snap
- tampilan tunggal
- status bar
- ukuran dimensi
- penyesuaian otomatis
- zoom default
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Gunakan Aspose.Slides untuk .NET untuk mengonfigurasi tata letak tampilan normal, zoom slide dan catatan, jarak grid, serta visibilitas komentar dalam presentasi PowerPoint."
---
## **Pendahuluan**

Dalam tampilan normal PowerPoint, slide muncul di antara panel samping untuk thumbnail atau outline dan panel catatan di bawah. Aspose.Slides untuk .NET mengekspos preferensi penyuntingan yang disimpan pada presentasi melalui [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/). Ini mencakup tata letak panel, tingkat zoom, jarak grid, dan visibilitas komentar.

## **Tentang INormalViewProperties**

Gunakan [NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/normalviewproperties/) untuk mengakses antarmuka [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/). [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) mengontrol apakah ikon muncul di samping judul slide dalam outline. [SnapVerticalSplitter](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/snapverticalsplitter/) memungkinkan panel samping menempel pada keadaan diperkecil saat pengguna mempersempitnya. [PreferSingleView](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/prefersingleview/) menunjukkan preferensi untuk menampilkan satu panel dalam jendela penuh.

[VerticalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/verticalbarstate/) mengontrol pembagi antara panel samping dan slide. [HorizontalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/horizontalbarstate/) mengontrol pembagi di atas panel catatan. Keduanya menerima nilai [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype/) berupa `Minimized`, `Maximized`, atau `Restored`.

## **Tentang Mengembalikan INormalViewProperties**

Ketika pembagi dipulihkan, [RestoredLeft](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredleft/) menyediakan ukuran yang disimpan untuk panel samping dan [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) menyediakan ukuran yang disimpan untuk area slide atas. Keduanya mengekspos [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/). Properti [DimensionSize](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/dimensionsize/)‑nya menerima persentase dari 0 hingga 100, dan [AutoAdjust](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/autoadjust/) mengontrol apakah penyunting menyesuaikan ukuran saat jendela diubah ukurannya.

Contoh ini memperbarui presentasi yang ada. Ini mengembalikan pembagi horizontal, mengatur [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) menjadi 80% dengan penyesuaian otomatis diaktifkan, dan memaksimalkan pembagi vertikal. Juga mengaktifkan [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) untuk tampilan outline.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var normalView = presentation.ViewProperties.NormalViewProperties;
normalView.HorizontalBarState = SplitterBarStateType.Restored;
normalView.VerticalBarState = SplitterBarStateType.Maximized;
normalView.RestoredTop.AutoAdjust = true;
normalView.RestoredTop.DimensionSize = 80;
normalView.ShowOutlineIcons = true;

presentation.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
```

## **Atur Nilai Zoom Default**

[SlideViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/slideviewproperties/) dan [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/notesviewproperties/) menyimpan pengaturan zoom terpisah untuk penyunting. Pengaturan ini tidak memengaruhi dimensi slide, pemutaran slide‑show, atau resolusi ekspor gambar.

Contoh ini membuka presentasi yang ada dan mengaktifkan [VariableScale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/variablescale/) untuk menyesuaikan slide dengan jendela penyunting. Untuk halaman catatan, ia menonaktifkan skala otomatis dan mengatur [Scale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/scale/) ke zoom tetap 80%.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
viewProperties.SlideViewProperties.VariableScale = true;
viewProperties.NotesViewProperties.VariableScale = false;
viewProperties.NotesViewProperties.Scale = 80;

presentation.Save("zoom.pptx", SaveFormat.Pptx);
```

## **Atur Jarak Grid**

[GridSpacing](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/gridspacing/) mengatur jarak antara garis grid penyuntingan di seluruh presentasi. Nilainya positif dalam poin, dengan 72 poin per inci. Contoh ini mencetak jarak saat ini dalam presentasi yang ada dan menyimpan grid seperempat inci dengan mengatur interval menjadi 18 poin.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current grid spacing: {viewProperties.GridSpacing} points");

viewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

Grid berulang pada interval tetap. [Drawing guides](/slides/id/net/drawing-guides/) menandai posisi horizontal atau vertikal individual. Keduanya merupakan bantuan penyuntingan dan hanya muncul di penyunting yang menampilkannya. Slide show dan ekspor ke PDF, gambar, atau SVG tidak menyertakannya.

## **Tampilkan atau Sembunyikan Komentar Saat Membuka Presentasi**

[ShowComments](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/showcomments/) menyimpan preferensi yang digunakan penyunting kompatibel saat membuka presentasi. Untuk presentasi yang ada dengan komentar, contoh ini mencetak pengaturan saat ini dan menyimpan salinan dengan komentar disembunyikan. Juga mengatur [LastView](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/lastview/) ke [ViewType.SlideView](https://reference.aspose.com/slides/net/aspose.slides/viewtype/) sehingga salinan terbuka dalam tampilan slide.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current comment visibility: {viewProperties.ShowComments}");

viewProperties.ShowComments = NullableBool.False;
viewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

Menyembunyikan komentar mempertahankan teks, penulis, posisi, balasan, dan statusnya. Untuk mengubah komentar itu sendiri, lihat [Presentation Comments](/slides/id/net/presentation-comments/). Pengaturan ekspor mengontrol apakah komentar muncul dalam PDF, HTML, gambar, catatan, atau handout.

## **FAQ**

**Mengapa grid tersembunyi saat saya membuka kembali presentasi?**  
Presentasi menyimpan interval grid. Untuk melihat grid, aktifkan visibilitas grid di penyunting.

**Apakah menghapus drawing guides mengubah jarak grid?**  
Tidak. Menambahkan, memindahkan, atau menghapus panduan tidak mengubah interval grid.

**Apakah bagian berbeda dari sebuah presentasi dapat memiliki pengaturan tampilan yang berbeda?**  
Tidak. [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) berlaku untuk seluruh presentasi.

**Apakah saya dapat menyimpan pengaturan tampilan yang berbeda untuk pengguna yang berbeda?**  
File menyimpan satu set properti tampilan untuk semua orang. Penyunting juga dapat menerapkan preferensi lokal pengguna.

**Apakah saya dapat menyimpan pengaturan tampilan dalam template?**  
Ya. Presentasi yang dibuat dari template mewarisi pengaturan tampilan yang disimpan.