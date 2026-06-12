---
title: Ambil dan Perbarui Properti Tampilan Presentasi di .NET
linktitle: Properti Tampilan
type: docs
weight: 80
url: /id/net/presentation-view-properties/
keywords:
- properti tampilan
- tampilan normal
- konten outline
- ikon outline
- penyambungan pemisah vertikal
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
## **Pendahuluan**

Tampilan normal terdiri dari tiga wilayah konten: slide itu sendiri, wilayah konten samping, dan wilayah konten bawah. Properti yang berkaitan dengan penempatan berbagai wilayah konten. Informasi ini memungkinkan aplikasi menyimpan status tampilan ke dalam file, sehingga ketika dibuka kembali tampilan berada dalam keadaan yang sama seperti saat presentasi terakhir disimpan.

Properti [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/id/net/aspose.slides/iviewproperties/properties/normalviewproperties) telah ditambahkan untuk menyediakan akses ke properti tampilan normal presentasi.  

[INormalViewProperties](https://reference.aspose.com/slides/id/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/id/net/aspose.slides/inormalviewrestoredproperties) antarmuka dan turunannya, enum [SplitterBarStateType](https://reference.aspose.com/slides/id/net/aspose.slides/splitterbarstatetype) telah ditambahkan.

## **Tentang INormalViewProperties**

Mewakili properti tampilan normal.

Properti **ShowOutlineIcons** menentukan apakah aplikasi harus menampilkan ikon saat menampilkan konten outline di salah satu wilayah konten mode tampilan normal.

Properti **SnapVerticalSplitter** menentukan apakah pemisah vertikal harus beralih ke keadaan diminimalkan ketika wilayah samping cukup kecil.

Properti **PreferSingleView** menentukan apakah pengguna lebih suka melihat satu wilayah konten layar penuh dibandingkan tampilan normal standar dengan tiga wilayah konten. Jika diaktifkan, aplikasi dapat memilih untuk menampilkan salah satu wilayah konten di seluruh jendela.

Properti **VerticalBarState** dan **HorizontalBarState** menentukan keadaan yang harus ditunjukkan oleh bilah pemisah horizontal atau vertikal. Bilah pemisah horizontal memisahkan slide dari wilayah konten di bawah slide, bilah pemisah vertikal memisahkan slide dari wilayah konten samping. Nilai yang mungkin adalah: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** dan **SplitterBarStateType.Restored**.

Properti **RestoredLeft** dan **RestoredTop** menentukan ukuran wilayah slide atas atau samping pada tampilan normal, ketika nilai **SplitterBarStateType.Restored** diterapkan pada **VerticalBarState** dan **HorizontalBarState** secara berurutan.

## **Tentang Memulihkan INormalViewProperties**

Menentukan ukuran wilayah slide (lebar ketika menjadi anak dari RestoredTop, tinggi ketika menjadi anak dari RestoredLeft) pada tampilan normal, ketika wilayah tersebut memiliki ukuran pulih yang variabel (tidak diminimalkan maupun dimaksimalkan).  

Properti **DimensionSize** menentukan ukuran wilayah slide (lebar ketika menjadi anak dari restoredTop, tinggi ketika menjadi anak dari restoredLeft).  

Properti **AutoAdjust** menentukan apakah ukuran wilayah konten samping harus menyesuaikan dengan ukuran baru saat mengubah ukuran jendela yang berisi tampilan dalam aplikasi.  

Contoh di bawah menunjukkan cara mengakses properti **ViewProperties.NormalViewProperties** untuk sebuah presentasi.

```c#
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

## **Atur Nilai Zoom Default**

Aspose.Slides untuk .NET kini mendukung pengaturan nilai zoom default untuk presentasi sehingga ketika presentasi dibuka, zoom sudah ditetapkan. Hal ini dapat dilakukan dengan mengatur [ViewProperties](https://reference.aspose.com/slides/id/net/aspose.slides/viewproperties) sebuah presentasi. Properti Tampilan Slide serta [NotesViewProperties](https://reference.aspose.com/slides/id/net/aspose.slides/viewproperties/properties/notesviewproperties) dapat diatur secara programatik. Pada topik ini, kita akan melihat contoh cara mengatur View Properties dari Presentation di Aspose.Slides.

Untuk mengatur properti tampilan, ikuti langkah-langkah berikut:
1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation)
1. Atur View [Properties](https://reference.aspose.com/slides/id/net/aspose.slides/viewproperties) pada Presentation
1. Tulis presentasi sebagai file PPTX

Pada contoh di bawah, kami telah mengatur nilai zoom untuk tampilan slide serta tampilan catatan.

```c#
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Mengatur properti tampilan presentasi
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Nilai zoom dalam persentase untuk tampilan slide
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Nilai zoom dalam persentase untuk tampilan catatan 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Apakah saya dapat mengatur pengaturan tampilan yang berbeda untuk bagian yang berbeda dari sebuah presentasi?**

[View settings](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/viewproperties/) didefinisikan pada tingkat presentasi ([Normal View](https://reference.aspose.com/slides/id/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/id/net/aspose.slides/viewproperties/slideviewproperties/)), bukan per bagian, sehingga satu set parameter berlaku untuk seluruh dokumen ketika dibuka.

**Apakah saya dapat menentukan sebelumnya keadaan tampilan yang berbeda untuk pengguna yang berbeda?**

Tidak. Pengaturan disimpan dalam file dan bersifat bersama. Aplikasi penampil dapat menghormati preferensi pengguna, tetapi file itu sendiri berisi satu set properti tampilan.

**Apakah saya dapat menyiapkan templat dengan View Properties yang telah ditentukan sehingga presentasi baru dibuka dengan cara yang sama?**

Ya. Karena [view properties](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/viewproperties/) disimpan pada tingkat presentasi, Anda dapat menyematkannya dalam sebuah templat dan membuat dokumen baru darinya dengan konfigurasi tampilan awal yang sama.