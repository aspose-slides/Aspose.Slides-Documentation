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
- snap pemisah vertikal
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
description: "Temukan properti tampilan Aspose.Slides untuk .NET untuk menyesuaikan format slide PPT, PPTX, dan ODP—atur tata letak, tingkat zoom, dan pengaturan tampilan."
---
## **Introduction**

Tampilan normal terdiri dari tiga wilayah konten: slide itu sendiri, wilayah konten samping, dan wilayah konten bagian bawah. Properti yang berkaitan dengan penempatan wilayah konten yang berbeda. Informasi ini memungkinkan aplikasi menyimpan keadaan tampilan ke file, sehingga ketika dibuka kembali tampilan berada dalam keadaan yang sama seperti saat presentasi terakhir disimpan.

Properti [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/id/net/aspose.slides/iviewproperties/properties/normalviewproperties) telah ditambahkan untuk menyediakan akses ke properti tampilan normal presentasi. 

[INormalViewProperties](https://reference.aspose.com/slides/id/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/id/net/aspose.slides/inormalviewrestoredproperties), antarmuka dan turunannya, enum [SplitterBarStateType](https://reference.aspose.com/slides/id/net/aspose.slides/splitterbarstatetype) telah ditambahkan.

## **About INormalViewProperties**

Mewakili properti tampilan normal.

Properti **ShowOutlineIcons** menentukan apakah aplikasi harus menampilkan ikon saat menampilkan konten outline di salah satu wilayah konten mode tampilan normal.

Properti **SnapVerticalSplitter** menentukan apakah splitter vertikal harus beralih ke keadaan diminimalkan ketika wilayah samping cukup kecil.

Properti **PreferSingleView** menentukan apakah pengguna lebih suka melihat satu wilayah konten layar penuh dibandingkan tampilan normal standar dengan tiga wilayah konten. Jika diaktifkan, aplikasi dapat memilih menampilkan salah satu wilayah konten di seluruh jendela.

Properti **VerticalBarState** dan **HorizontalBarState** menentukan keadaan yang harus ditampilkan oleh bilah splitter horizontal atau vertikal. Bilah splitter horizontal memisahkan slide dari wilayah konten di bawah slide, sedangkan bilah splitter vertikal memisahkan slide dari wilayah konten samping. Nilai yang mungkin adalah: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized**, dan **SplitterBarStateType.Restored**.

Properti **RestoredLeft** dan **RestoredTop** menentukan ukuran wilayah slide atas atau samping pada tampilan normal, ketika nilai **SplitterBarStateType.Restored** diterapkan pada **VerticalBarState** dan **HorizontalBarState** masing‑masing.

## **Tentang Pemulihan INormalViewProperties**

Menentukan ukuran wilayah slide (lebar ketika menjadi anak RestoredTop, tinggi ketika menjadi anak RestoredLeft) pada tampilan normal, ketika wilayah tersebut memiliki ukuran pemulihan variabel (tidak diminimalkan maupun dimaksimalkan). 

Properti **DimensionSize** menentukan ukuran wilayah slide (lebar ketika menjadi anak restoredTop, tinggi ketika menjadi anak restoredLeft).

Properti **AutoAdjust** menentukan apakah ukuran wilayah konten samping harus menyesuaikan dengan ukuran baru saat mengubah ukuran jendela yang berisi tampilan dalam aplikasi.

Contoh di bawah ini menunjukkan cara mengakses properti **ViewProperties.NormalViewProperties** untuk sebuah presentasi.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // Pulihkan properti tampilan presentasi
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **Set the Default Zoom Value**

Aspose.Slides for .NET kini mendukung penetapan nilai zoom default untuk presentasi sehingga ketika presentasi dibuka, zoom sudah diatur. Hal ini dapat dilakukan dengan mengatur [ViewProperties](https://reference.aspose.com/slides/id/net/aspose.slides/viewproperties) sebuah presentasi. Properti Tampilan Slide serta [NotesViewProperties](https://reference.aspose.com/slides/id/net/aspose.slides/viewproperties/properties/notesviewproperties) dapat diatur secara programatik. Pada topik ini, kita akan melihat dengan contoh cara mengatur View Properties pada Presentation di Aspose.Slides.

Untuk mengatur properti tampilan, ikuti langkah‑langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation)
1. Atur View [Properties](https://reference.aspose.com/slides/id/net/aspose.slides/viewproperties) Presentation
1. Tuliskan presentasi sebagai file PPTX

Pada contoh di bawah ini, kami telah mengatur nilai zoom untuk tampilan slide maupun tampilan catatan.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Mengatur properti tampilan presentasi
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Nilai zoom dalam persentase untuk tampilan slide
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Nilai zoom dalam persentase untuk tampilan catatan 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Set the Grid Spacing**

Gunakan [Presentation.ViewProperties](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/viewproperties/) untuk mengakses pengaturan tampilan seluruh presentasi. Properti [IViewProperties.GridSpacing](https://reference.aspose.com/slides/id/net/aspose.slides/iviewproperties/gridspacing/) membaca atau mengubah interval grid pengeditan yang mendasarinya. Pengaturan ini berlaku untuk seluruh presentasi, bukan untuk slide individu. Jarak grid ditentukan dalam poin, di mana 72 poin sama dengan satu inci. Gunakan nilai positif, sebagaimana diminta oleh dokumentasi API.

Contoh berikut membuka `demo.pptx` yang ada, mencetak jarak grid saat ini, menetapkan interval seperempat inci, dan menyimpan hasilnya.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");
var gridSpacing = presentation.ViewProperties.GridSpacing;
Console.WriteLine($"Current grid spacing: {gridSpacing} points");

presentation.ViewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

Grid berbeda dari [drawing guides](/slides/id/net/drawing-guides/). Jarak grid mengontrol interval reguler, sementara drawing guides adalah garis penyelarasan horizontal atau vertikal yang diposisikan secara individual. Menambah, memindahkan, atau menghapus drawing guides tidak mengubah jarak grid.

Baik grid maupun drawing guides merupakan bantuan pengeditan. Mereka tidak dirender sebagai konten slide dalam PDF, gambar, SVG, atau tayangan slide. Menyimpan jarak grid tidak menjamin editor akan menampilkan grid: visibilitasnya juga bergantung pada preferensi penampil atau editor.

## **FAQ**

**Mengapa grid tidak terlihat setelah saya membuka kembali presentasi?**

File menyimpan jarak grid, tetapi editor yang mengontrol apakah grid ditampilkan. Periksa pengaturan visibilitas grid pada editor.

**Apakah menghapus drawing guides mengubah jarak grid?**

Tidak. Drawing guides dan jarak grid adalah pengaturan yang independen. Menghapus guides tidak mengubah interval grid yang tersimpan.

**Bisakah saya mengatur pengaturan tampilan yang berbeda untuk bagian-bagian berbeda dari sebuah presentasi?**

Pengaturan [View settings](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/viewproperties/) didefinisikan pada tingkat presentasi ([Normal View](https://reference.aspose.com/slides/id/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/id/net/aspose.slides/viewproperties/slideviewproperties/)), bukan per bagian, sehingga satu set parameter berlaku untuk seluruh dokumen saat dibuka.

**Bisakah saya mendefinisikan sebelumnya keadaan tampilan yang berbeda untuk pengguna yang berbeda?**

Tidak. Pengaturan disimpan dalam file dan bersifat berbagi. Aplikasi penampil dapat menghormati preferensi pengguna, namun file itu sendiri hanya berisi satu set properti tampilan.

**Bisakah saya menyiapkan templat dengan View Properties yang telah ditentukan sebelumnya sehingga presentasi baru dibuka dengan cara yang sama?**

Ya. Karena [view properties](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/viewproperties/) disimpan pada tingkat presentasi, Anda dapat menyematkannya dalam templat dan membuat dokumen baru darinya dengan konfigurasi tampilan awal yang sama.