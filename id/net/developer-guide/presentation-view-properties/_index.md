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
- keadaan bar
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

Tampilan normal terdiri dari tiga wilayah konten: slide itu sendiri, wilayah konten samping, dan wilayah konten bagian bawah. Properti yang berkaitan dengan penempatan berbagai wilayah konten. Informasi ini memungkinkan aplikasi menyimpan status tampilan ke file, sehingga ketika dibuka kembali tampilan berada dalam keadaan yang sama seperti saat presentasi terakhir disimpan.

Properti [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/id/net/aspose.slides/iviewproperties/properties/normalviewproperties) telah ditambahkan untuk memberikan akses ke properti tampilan normal presentasi.  

[INormalViewProperties](https://reference.aspose.com/slides/id/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/id/net/aspose.slides/inormalviewrestoredproperties) antarmuka dan turunannya, serta enum [SplitterBarStateType](https://reference.aspose.com/slides/id/net/aspose.slides/splitterbarstatetype) telah ditambahkan.

## **About INormalViewProperties**

Mewakili properti tampilan normal.

Properti **ShowOutlineIcons** menentukan apakah aplikasi harus menampilkan ikon ketika menampilkan konten outline di salah satu wilayah konten mode tampilan normal.

Properti **SnapVerticalSplitter** menentukan apakah pemisah vertikal harus menempel pada keadaan diperkecil ketika wilayah samping cukup kecil.

Properti **PreferSingleView** menentukan apakah pengguna lebih suka melihat satu wilayah konten penuh jendela daripada tampilan normal standar dengan tiga wilayah konten. Jika diaktifkan, aplikasi dapat memilih menampilkan salah satu wilayah konten di seluruh jendela.

Properti **VerticalBarState** dan **HorizontalBarState** menentukan keadaan yang harus ditampilkan oleh bar pemisah vertikal atau horizontal. Bar pemisah horizontal memisahkan slide dari wilayah konten di bawah slide, sedangkan bar pemisah vertikal memisahkan slide dari wilayah konten samping. Nilai yang mungkin adalah **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized**, dan **SplitterBarStateType.Restored**.

Properti **RestoredLeft** dan **RestoredTop** menentukan ukuran wilayah slide atas atau samping tampilan normal, ketika nilai **SplitterBarStateType.Restored** diterapkan pada **VerticalBarState** dan **HorizontalBarState** secara bersesuaian.

## **About Restoring INormalViewProperties** 

Menentukan ukuran wilayah slide (lebar ketika anak dari RestoredTop, tinggi ketika anak dari RestoredLeft) tampilan normal, ketika wilayah tersebut memiliki ukuran yang dipulihkan secara variabel (tidak diperkecil maupun diperbesar).  

Properti **DimensionSize** menentukan ukuran wilayah slide (lebar ketika anak dari restoredTop, tinggi ketika anak dari restoredLeft).

Properti **AutoAdjust** menentukan apakah ukuran wilayah konten samping harus menyesuaikan ukuran baru ketika mengubah ukuran jendela yang berisi tampilan dalam aplikasi.

Contoh di bawah menunjukkan cara mengakses properti **ViewProperties.NormalViewProperties** untuk sebuah presentasi.

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

Aspose.Slides untuk .NET kini mendukung penetapan nilai zoom default untuk presentasi sehingga ketika presentasi dibuka, zoom sudah diatur. Hal ini dapat dilakukan dengan mengatur [ViewProperties](https://reference.aspose.com/slides/id/net/aspose.slides/viewproperties) sebuah presentasi. Properti Tampilan Slide serta [NotesViewProperties](https://reference.aspose.com/slides/id/net/aspose.slides/viewproperties/properties/notesviewproperties) dapat diatur secara programatis. Pada topik ini, kami akan menunjukkan dengan contoh cara mengatur Properti Tampilan Presentasi di Aspose.Slides.

Untuk mengatur properti tampilan, ikuti langkah-langkah di bawah ini:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation)
1. Atur **ViewProperties** presentasi
1. Simpan presentasi sebagai file PPTX

Dalam contoh di bawah, kami telah mengatur nilai zoom untuk tampilan slide maupun tampilan catatan.

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

Gunakan [Presentation.ViewProperties](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/viewproperties/) untuk mengakses pengaturan tampilan seluruh presentasi. Properti [IViewProperties.GridSpacing](https://reference.aspose.com/slides/id/net/aspose.slides/iviewproperties/gridspacing/) membaca atau mengubah interval grid penyuntingan yang mendasarinya. Pengaturan ini berlaku untuk seluruh presentasi, bukan untuk satu slide tertentu. Jarak grid ditentukan dalam poin, di mana 72 poin sama dengan satu inci. Gunakan nilai positif, sesuai dokumentasi API.

Contoh berikut membuka file `demo.pptx` yang sudah ada, mencetak jarak grid saat ini, menetapkan interval seperempat inci, dan menyimpan hasilnya.

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

Grid berbeda dari [drawing guides](/slides/id/net/drawing-guides/). Jarak grid mengontrol interval reguler, sementara drawing guides adalah garis penjajaran horizontal atau vertikal yang diposisikan secara individual. Menambah, memindahkan, atau menghapus drawing guides tidak mengubah jarak grid.

Baik grid maupun drawing guides adalah bantuan penyuntingan. Mereka tidak dirender sebagai konten slide dalam PDF, gambar, SVG, atau presentasi slide. Menyimpan jarak grid tidak menjamin editor akan menampilkan grid: visibilitasnya juga tergantung pada preferensi penampil atau editor.

## **Show or Hide Comments When Opening a Presentation**

Gunakan [Presentation.ViewProperties](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/viewproperties/) untuk mengakses pengaturan tampilan seluruh presentasi. Baca atau ubah [IViewProperties.ShowComments](https://reference.aspose.com/slides/id/net/aspose.slides/iviewproperties/showcomments/) untuk menyimpan preferensi apakah komentar harus ditampilkan ketika presentasi dibuka di PowerPoint atau editor kompatibel lainnya.

Pengaturan ini hanya mengontrol preferensi tampilan yang disimpan. Itu tidak menambah, menghapus, mengedit, atau menyelesaikan komentar. Menyembunyikan komentar mempertahankan konten, penulis, posisi, balasan, dan statusnya. Lihat [Presentation Comments](/slides/id/net/presentation-comments/) untuk operasi yang mengubah komentar itu sendiri.

Contoh berikut membutuhkan file `comments.pptx` yang sudah ada dan berisi komentar. Ia mencetak pengaturan visibilitas saat ini, meminta komentar disembunyikan, dan menyimpan PPTX baru tanpa menghapus komentar apa pun. Ia juga mengatur [IViewProperties.LastView](https://reference.aspose.com/slides/id/net/aspose.slides/iviewproperties/lastview/) ke [ViewType.SlideView](https://reference.aspose.com/slides/id/net/aspose.slides/viewtype/) untuk mengonfigurasi tampilan penyuntingan awal bersama visibilitas komentar.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");
var showComments = presentation.ViewProperties.ShowComments;
Console.WriteLine($"Current comment visibility: {showComments}");

presentation.ViewProperties.ShowComments = NullableBool.False;
presentation.ViewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

Pengaturan ini tidak menentukan apakah komentar termasuk dalam ekspor PDF, HTML, gambar, catatan, atau handout. Konfigurasikan opsi spesifik ekspor yang relevan secara terpisah.

## **FAQ**

**Mengapa grid tidak terlihat setelah saya membuka kembali presentasi?**

File menyimpan jarak grid, tetapi editor mengontrol apakah grid ditampilkan. Periksa pengaturan visibilitas grid pada editor.

**Apakah menghapus drawing guides mengubah jarak grid?**

Tidak. Drawing guides dan jarak grid adalah pengaturan yang independen. Menghapus guides tidak mengubah interval grid yang disimpan.

**Bisakah saya menetapkan pengaturan tampilan berbeda untuk bagian berbeda dari sebuah presentasi?**

[Pengaturan tampilan](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/viewproperties/) didefinisikan pada tingkat presentasi ([Normal View](https://reference.aspose.com/slides/id/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/id/net/aspose.slides/viewproperties/slideviewproperties/)), bukan per bagian, sehingga satu set parameter berlaku untuk seluruh dokumen saat dibuka.

**Bisakah saya mendefinisikan status tampilan berbeda untuk pengguna berbeda?**

Tidak. Pengaturan disimpan dalam file dan bersifat bersama. Aplikasi penampil mungkin menghormati preferensi pengguna, tetapi file itu sendiri hanya berisi satu set properti tampilan.

**Bisakah saya menyiapkan templat dengan Properti Tampilan yang telah ditentukan sehingga presentasi baru membuka dengan cara yang sama?**

Ya. Karena [properti tampilan](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/viewproperties/) disimpan pada tingkat presentasi, Anda dapat menyematkannya dalam templat dan membuat dokumen baru darinya dengan konfigurasi tampilan awal yang sama.