---
title: Slide Master
type: docs
weight: 30
url: /id/net/examples/elements/master-slide/
keywords:
- slide master
- tambahkan slide master
- akses slide master
- hapus slide master
- slide master yang tidak digunakan
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Jelajahi contoh slide master Aspose.Slides untuk .NET: buat, edit, dan atur gaya master, placeholder, serta tema dalam PPT, PPTX, dan ODP dengan kode C# yang jelas."
---
Master slide membentuk tingkat teratas dari hierarki pewarisan slide di PowerPoint. **Master slide** mendefinisikan elemen desain umum seperti latar belakang, logo, dan pemformatan teks. **Layout slide** mewarisi dari master slide, dan **normal slide** mewarisi dari layout slide.

Artikel ini menunjukkan cara membuat, memodifikasi, dan mengelola master slide menggunakan Aspose.Slides untuk .NET.

## **Tambahkan Master Slide**

Contoh ini menunjukkan cara membuat master slide baru dengan mengkloning master default. Kemudian menambahkan spanduk nama perusahaan ke semua slide melalui pewarisan layout.

```csharp
static void AddMasterSlide()
{
    using var presentation = new Presentation();

    // Gandakan master slide default.
    var defaultMasterSlide = presentation.Masters[0];
    var newMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

    // Tambahkan spanduk dengan nama perusahaan ke bagian atas master slide.
    var textBox = newMasterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // Tetapkan master slide baru ke layout slide.
    var layoutSlide = presentation.LayoutSlides[0];
    layoutSlide.MasterSlide = newMasterSlide;

    // Tetapkan layout slide ke slide pertama dalam presentasi.
    presentation.Slides[0].LayoutSlide = layoutSlide;
}
```

> 💡 **Catatan 1:** Master slide menyediakan cara untuk menerapkan branding konsisten atau elemen desain bersama di semua slide. Setiap perubahan yang dilakukan pada master secara otomatis akan tercermin pada layout dan normal slide yang bergantung.

> 💡 **Catatan 2:** Setiap bentuk atau pemformatan yang ditambahkan ke master slide akan diwarisi oleh layout slide dan, pada gilirannya, semua normal slide yang menggunakan layout tersebut.

> Gambar di bawah menggambarkan bagaimana kotak teks yang ditambahkan pada master slide secara otomatis ditampilkan pada slide akhir.

![Contoh Pewarisan Master](master-slide-banner.png)

## **Akses Master Slide**

Anda dapat mengakses master slide menggunakan koleksi `Presentation.Masters`. Berikut cara mengambil dan bekerja dengan mereka:

```csharp
static void AccessMasterSlide()
{
    using var presentation = new Presentation();

    // Akses master slide pertama.
    var firstMasterSlide = presentation.Masters[0];

    // Ubah jenis latar belakang.
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## **Hapus Master Slide**

Master slide dapat dihapus baik dengan indeks maupun dengan referensi.

```csharp
static void RemoveMasterSlide()
{
    using var presentation = new Presentation("sample.pptx");

    // Hapus master slide berdasarkan indeks.
    presentation.Masters.RemoveAt(0);

    // Hapus master slide berdasarkan referensi.
    var firstMasterSlide = presentation.Masters[0];
    presentation.Masters.Remove(firstMasterSlide);
}
```

## **Hapus Master Slide yang Tidak Digunakan**

Beberapa presentasi berisi master slide yang tidak digunakan. Menghapus slide ini dapat membantu mengurangi ukuran file.

```csharp
static void RemoveUnusedMasterSlide()
{
    using var presentation = new Presentation();

    // Hapus semua master slide yang tidak digunakan (bahkan yang ditandai sebagai Preserve).
    presentation.Masters.RemoveUnused(ignorePreserveField: true);
}
```