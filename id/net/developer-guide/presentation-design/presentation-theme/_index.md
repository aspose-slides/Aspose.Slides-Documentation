---
title: Kelola Tema Presentasi di .NET
linktitle: Tema Presentasi
type: docs
weight: 10
url: /id/net/presentation-theme/
keywords:
- Tema PowerPoint
- tema presentasi
- tema slide
- mengatur tema
- mengubah tema
- mengelola tema
- tema eksternal
- THMX
- warna tema
- palet tambahan
- font tema
- gaya tema
- efek tema
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kuasai tema presentasi di Aspose.Slides untuk .NET untuk membuat, menyesuaikan, dan mengonversi file PowerPoint dengan merek yang konsisten."
---
## **Pendahuluan**

Tema presentasi menentukan satu set warna, font, gaya latar belakang, isi, garis, dan efek yang terkoordinasi. Objek yang menyadari tema merujuk pada definisi bersama ini alih-alih menyimpan setiap properti visual sebagai nilai tetap, sehingga perubahan tema dapat memperbarui banyak objek sekaligus.

Di Aspose.Slides, tema tingkat presentasi tersedia melalui properti [Presentation.MasterTheme](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/mastertheme/). Presentasi juga dapat berisi penimpaan tema pada level yang lebih rendah. Sebuah master dapat menimpa tema presentasi melalui [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/id/net/aspose.slides.theme/masterthememanager/overridetheme/), sebuah tata letak dapat menimpa tema yang diwarisi melalui [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/id/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), dan sebuah slide individual dapat melakukan hal yang sama. Secara praktik, tema efektif untuk sebuah slide diselesaikan melalui rantai pewarisan ini: tema presentasi, penimpaan master, penimpaan tata letak, dan penimpaan slide.

![Komponen tema: warna, font, gaya latar belakang, dan efek](theme-constituents.png)

Bagian di bawah ini menunjukkan alur kerja tema yang paling umum: memeriksa tema, mengubah warna dan font, menyalin atau menerapkan tema, memperbarui gaya latar belakang dan efek, serta membaca nilai efektif setelah pewarisan dan penimpaan diselesaikan.

## **Memeriksa Tema**

Objek [MasterTheme](https://reference.aspose.com/slides/id/net/aspose.slides.theme/mastertheme/) menampilkan [ColorScheme](https://reference.aspose.com/slides/id/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/id/net/aspose.slides.theme/mastertheme/fontscheme/), dan [FormatScheme](https://reference.aspose.com/slides/id/net/aspose.slides.theme/mastertheme/formatscheme/). Memeriksa koleksi ini sebelum mengubahnya sangat berguna ketika presentasi berasal dari sumber eksternal karena jumlah dan isi entri gaya dapat bervariasi.

Contoh berikut membaca properti tema utama dan melaporkan berapa banyak gaya latar belakang, isi, garis, dan efek yang disimpan dalam tema:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var theme = presentation.MasterTheme;

Console.WriteLine($"Theme name: {theme.Name}");
Console.WriteLine($"Accent 1: {theme.ColorScheme.Accent1.Color}");
Console.WriteLine($"Major Latin font: {theme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Minor Latin font: {theme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Background fill styles: {theme.FormatScheme.BackgroundFillStyles.Count}");
Console.WriteLine($"Fill styles: {theme.FormatScheme.FillStyles.Count}");
Console.WriteLine($"Line styles: {theme.FormatScheme.LineStyles.Count}");
Console.WriteLine($"Effect styles: {theme.FormatScheme.EffectStyles.Count}");
```

Jika sebuah file menggunakan beberapa master, jangan mengasumsikan bahwa setiap slide memiliki tema efektif yang sama. Periksa master yang terkait dengan slide, dan gunakan alur kerja tema-efektif yang ditunjukkan nanti dalam artikel ini ketika penimpaan tata letak atau slide mungkin ada.

## **Mengubah Warna Tema**

Isi, garis, dan teks yang menyadari tema dapat merujuk pada warna logis dari enumerasi [SchemeColor](https://reference.aspose.com/slides/id/net/aspose.slides/schemecolor/). Ketika Anda mengubah entri yang bersangkutan dalam [IColorScheme](https://reference.aspose.com/slides/id/net/aspose.slides.theme/icolorscheme/) tema, semua objek yang masih merujuk ke warna tema tersebut akan diselesaikan terhadap nilai baru. Objek yang menggunakan warna RGB langsung tidak berubah oleh pembaruan warna tema.

Contoh end-to-end berikut membuat sebuah bentuk yang menggunakan `Accent4`, mengubah warna `Accent4` tema menjadi merah, menyimpan presentasi, membukanya kembali, dan mencetak warna isi efektif:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
presentation.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
presentation.Save("theme-color.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("theme-color.pptx");
var savedSlide = savedPresentation.Slides[0];
var savedShape = savedSlide.Shapes[0];
var effectiveFill = savedShape.FillFormat.GetEffective();
Console.WriteLine($"Effective fill color: {effectiveFill.SolidFillColor}");
```

Karena persegi tetap terhubung ke `Accent4`, warnanya menjadi merah setelah tema diubah. Jika Anda mengganti warna skema dengan warna langsung pada bentuk, perubahan selanjutnya pada `Accent4` tidak lagi memengaruhi isi tersebut.

### **Gunakan Warna dari Palet Tambahan**

PowerPoint menghasilkan varian lebih terang dan lebih gelap dari warna tema dengan menerapkan transformasi warna. Aspose.Slides mengekspos transformasi ini melalui [ColorTransformOperation](https://reference.aspose.com/slides/id/net/aspose.slides/colortransformoperation/).

![Warna tema utama serta warna lebih terang dan lebih gelap yang dihasilkan dari palet tambahan](additional-palette-colors.png)

**1** – Warna tema utama.

**2** – Varian lebih terang dan lebih gelap yang dihasilkan dari warna tema utama.

Contoh berikut membuat enam persegi berdasarkan `Accent4`, menerapkan transformasi luminansi pada lima di antaranya, dan menyimpan hasilnya:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
shape1.FillFormat.FillType = FillType.Solid;
shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
shape2.FillFormat.FillType = FillType.Solid;
shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
shape3.FillFormat.FillType = FillType.Solid;
shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
shape4.FillFormat.FillType = FillType.Solid;
shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

var shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
shape5.FillFormat.FillType = FillType.Solid;
shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

var shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
shape6.FillFormat.FillType = FillType.Solid;
shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

presentation.Save("theme-color-palette.pptx", SaveFormat.Pptx);
```

Varian ini tetap berbasis pada warna tema. Jika `Accent4` berubah kemudian, warna yang ditransformasi akan dihitung ulang dari nilai `Accent4` yang baru.

### **Petakan Nilai `SchemeColor` ke Slot `IColorScheme`**

Enumerasi [SchemeColor](https://reference.aspose.com/slides/id/net/aspose.slides/schemecolor/) menggunakan `Text1`, `Background1`, `Text2`, dan `Background2`, sementara [IColorScheme](https://reference.aspose.com/slides/id/net/aspose.slides.theme/icolorscheme/) menampilkan slot tema yang sama sebagai `Dark1`, `Light1`, `Dark2`, dan `Light2`. Pemetaan ini tetap:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ini adalah nama alternatif untuk slot tema yang sama; bukan nilai yang dikonversi secara dinamis dari satu bentuk ke bentuk lain.

## **Mengubah Font Tema**

Skema font tema berisi satu set font utama untuk judul dan satu set font minor untuk teks badan. Properti [FontScheme.Major](https://reference.aspose.com/slides/id/net/aspose.slides.theme/fontscheme/major/) dan [FontScheme.Minor](https://reference.aspose.com/slides/id/net/aspose.slides.theme/fontscheme/minor/) menampilkan set tersebut.

Pengidentifikasi font tema yang kompatibel dengan PowerPoint dapat digunakan dalam pemformatan teks:

* `+mn-lt` – Font Tubuh Latin (Minor Latin Font)
* `+mj-lt` – Font Judul Latin (Major Latin Font)
* `+mn-ea` – Font Tubuh Asia Timur (Minor East Asian Font)
* `+mj-ea` – Font Judul Asia Timur (Major East Asian Font)

Contoh berikut membuat satu judul yang menggunakan font tema Latin utama dan satu baris tubuh yang menggunakan font tema Latin minor. Kemudian mengubah font tema dan menyimpan hasilnya:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var heading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
heading.TextFrame.Text = "Theme heading";
heading.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mj-lt");

var body = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
body.TextFrame.Text = "Theme body text";
body.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mn-lt");

presentation.MasterTheme.FontScheme.Major.LatinFont = new FontData("Aptos Display");
presentation.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");

presentation.Save("theme-fonts.pptx", SaveFormat.Pptx);
```

Judul mengikuti font utama dan teks tubuh mengikuti font minor. Teks yang memiliki nama font eksplisit alih-alih pengidentifikasi tema tidak akan beralih secara otomatis ketika skema font tema berubah.

Koleksi font utama dan minor juga dapat berisi pemetaan font untuk sistem penulisan individual, seperti Cyrillic, Arab, Jepang, Georgia, dan Thaana. Untuk memeriksa, menambah, mengganti, atau menghapus pemetaan ini, lihat [Script-Specific Theme Fonts](/slides/id/net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Untuk informasi lebih lanjut tentang font presentasi, lihat [PowerPoint Fonts](/slides/id/net/powerpoint-fonts/).
{{% /alert %}}

## **Menyalin atau Menerapkan Tema**

Alur kerja di bawah ini menyelesaikan masalah tema yang berbeda.

### **Menerapkan Tema Eksternal ke Slide yang Bergantung pada Master**

Gunakan [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) ketika Anda memiliki file tema PowerPoint (`.thmx`) dan ingin mengubah gaya setiap slide yang bergantung pada master tertentu. Pilih master dari koleksi [Presentation.Masters](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/masters/), yang mengimplementasikan [IMasterSlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslidecollection/), dan berikan jalur file tema ke metode tersebut.

Metode melakukan operasi berikut:

1. Membuat master slide baru berdasarkan master terpilih.
1. Menerapkan tema eksternal ke master baru.
1. Menetapkan master baru ke semua slide yang sebelumnya bergantung pada master terpilih.
1. Mengembalikan [IMasterSlide](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslide/) yang baru dibuat.

Contoh berikut menerapkan tema eksternal ke slide yang bergantung pada master pertama, menyimpan presentasi, dan membuka kembali hasilnya:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var selectedMaster = presentation.Masters[0];
var themedMaster = selectedMaster.ApplyExternalThemeToDependingSlides("corporate-theme.thmx");

Console.WriteLine($"Created master: {themedMaster.Name}");
presentation.Save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
```

Tema yang tidak valid, rusak, atau tidak didukung dapat menyebabkan [PptxException](https://reference.aspose.com/slides/id/net/aspose.slides/pptxexception/) atau salah satu subclass terkait formatnya. Validasi jalur yang diberikan pengguna, tangani kegagalan akses sistem file, dan simpan presentasi hanya setelah tema berhasil diterapkan.

Hanya slide yang bergantung pada master terpilih yang dipindahkan. Slide yang terkait dengan master lain mempertahankan master dan tema mereka yang ada. Warna, font, isi, garis, latar belakang, dan efek yang menyadari tema diselesaikan terhadap tema eksternal. Warna, font, isi, dan pemformatan eksplisit yang ditetapkan secara langsung mungkin tetap tidak berubah. Penimpaan pada level tata letak dan slide juga dapat memiliki prioritas atas nilai yang diwarisi dari master baru.

Tema dapat merujuk pada font yang tidak tersedia di lingkungan runtime. Untuk rendering dan ekspor yang konsisten, instal font yang diperlukan, sediakan melalui [custom font sources](/slides/id/net/custom-font/), atau konfigurasikan [font substitution](/slides/id/net/font-substitution/).

Ini adalah alur kerja level master langsung: metode menerima jalur file `.thmx` dan tidak memerlukan pembuatan penimpaan tema pada level slide atau tata letak secara manual.

### **Menerapkan Tema Eksternal Berbeda dalam Presentasi Multi-Master**

Ketika master yang relevan tidak diketahui sebelumnya, peroleh master tersebut dari slide perwakilan melalui [ISlide.LayoutSlide](https://reference.aspose.com/slides/id/net/aspose.slides/islide/layoutslide/) dan [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/id/net/aspose.slides/ilayoutslide/masterslide/). Simpan referensi master asli sebelum menerapkan tema apa pun karena setiap panggilan membuat master lain dalam presentasi.

Contoh berikut menggunakan slide dari dua bagian untuk menemukan master mereka dan menerapkan tema eksternal yang berbeda untuk masing‑masing grup:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("multi-master-presentation.pptx");

if (presentation.Slides.Count < 5)
{
    Console.WriteLine("The presentation does not contain the expected representative slides.");
}
else
{
    var firstGroupMaster = presentation.Slides[0].LayoutSlide.MasterSlide;
    var secondGroupMaster = presentation.Slides[4].LayoutSlide.MasterSlide;

    if (ReferenceEquals(firstGroupMaster, secondGroupMaster))
    {
        Console.WriteLine("The representative slides use the same master.");
    }
    else
    {
        var firstThemedMaster = firstGroupMaster.ApplyExternalThemeToDependingSlides("blue-theme.thmx");
        var secondThemedMaster = secondGroupMaster.ApplyExternalThemeToDependingSlides("green-theme.thmx");

        Console.WriteLine($"First themed master: {firstThemedMaster.Name}");
        Console.WriteLine($"Second themed master: {secondThemedMaster.Name}");
        presentation.Save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
    }
}
```

Panggilan pertama memengaruhi hanya slide yang bergantung pada `firstGroupMaster`, dan panggilan kedua memengaruhi hanya slide yang bergantung pada `secondGroupMaster`. Slide yang termasuk dalam master lain tidak diubah gayanya.

### **Mempertahankan Tema Sumber Saat Memindahkan Slide**

Jika Anda ingin memindahkan slide ke presentasi lain dan mempertahankan desain aslinya, kloning master sumber ke presentasi target dengan [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslidecollection/addclone/), lalu kloning slide dengan [ISlideCollection.AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/addclone/) dan master yang dikloning. Ini membawa master, tata letaknya, dan tema terkait bersama-sama.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var sourceSlide = source.Slides[0];
var sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
var clonedMaster = target.Masters.AddClone(sourceMaster);
target.Slides.AddClone(sourceSlide, clonedMaster, true);

target.Save("theme-preserved.pptx", SaveFormat.Pptx);
```

Ini adalah alur kerja yang disarankan ketika slide sumber harus tampak sama di tujuan. Hanya mengkloning konten ke master tujuan yang tidak terkait dapat mengubah warna, font, latar belakang, dan efek yang dipengaruhi tema.

### **Menerapkan Nilai Tema ke Slide yang Ada**

Jika slide target harus tetap pada master dan tata letak saat ini, inisialisasi penimpaan level slide dari tema sumber. Metode [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/id/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/id/net/aspose.slides.theme/overridetheme/initfontschemefrom/), dan [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/id/net/aspose.slides.theme/overridetheme/initformatschemefrom/) menyalin tiga komponen tema utama ke penimpaan.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetSlide = target.Slides[0];
var overrideTheme = targetSlide.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
```

Ini mengubah tema yang digunakan slide tersebut tanpa mengubah tema yang diwarisi oleh slide lain. Untuk menghapus penimpaan lokal dan kembali ke nilai yang diwarisi, panggil [OverrideTheme.Clear](https://reference.aspose.com/slides/id/net/aspose.slides.theme/overridetheme/clear/).

### **Menerapkan Penimpaan Tema ke Tata Letak**

Penimpaan level tata letak berlaku untuk slide yang menggunakan tata letak tersebut, kecuali slide tertentu memiliki penimpaan sendiri. Metode inisialisasi yang sama dapat digunakan melalui [LayoutSlideThemeManager](https://reference.aspose.com/slides/id/net/aspose.slides.theme/layoutslidethememanager/) tata letak:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetLayout = target.Slides[0].LayoutSlide;
var overrideTheme = targetLayout.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
```

Gunakan tema master atau tingkat presentasi ketika banyak tata letak dan slide harus berbagi desain dasar yang sama, penimpaan tata letak ketika satu keluarga tata letak memerlukan gaya berbeda, dan penimpaan slide hanya untuk pengecualian sejati. Penimpaan level slide yang berlebihan membuat perubahan tema global di kemudian hari menjadi lebih sulit diprediksi.

## **Memperbarui Gaya Latar Belakang Tema**

Isi latar belakang tema disimpan dalam [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/id/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint dapat menampilkan lebih banyak pilihan latar belakang di UI-nya daripada jumlah definisi isi yang secara fisik disimpan dalam koleksi ini karena UI dapat menggabungkan isi tema dengan warna tema dan referensi gaya lainnya.

![Galeri gaya latar belakang PowerPoint untuk tema presentasi](presentation-design_8.png)

Sebelum menggunakan gaya latar belakang, periksa koleksi yang disimpan dan [Background.StyleIndex](https://reference.aspose.com/slides/id/net/aspose.slides/background/styleindex/) saat ini. `StyleIndex` menggunakan `0` untuk tidak ada isi tema; nilai positif merupakan referensi gaya latar belakang tema. Ini berbeda dari mengindeks koleksi .NET secara langsung, di mana `[0]` berarti item pertama yang disimpan. Jangan mengasumsikan setiap presentasi memiliki jumlah gaya isi latar belakang yang sama.

Contoh berikut melaporkan jumlah isi latar belakang yang tersedia, menetapkan referensi latar belakang tema ke master pertama, dan menyimpan presentasi:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var backgroundStyles = presentation.MasterTheme.FormatScheme.BackgroundFillStyles;
Console.WriteLine($"Background fill styles: {backgroundStyles.Count}");

if (backgroundStyles.Count == 0)
{
    throw new InvalidOperationException("The presentation theme does not contain background fill styles.");
}

presentation.Masters[0].Background.Type = BackgroundType.Themed;
presentation.Masters[0].Background.StyleIndex = 1;

presentation.Save("theme-background.pptx", SaveFormat.Pptx);
```

Hasil yang terlihat tergantung pada entri tema yang dirujuk oleh master dan pada penimpaan latar belakang di level tata letak atau slide. Jika sebuah slide menggunakan latar belakangnya sendiri, mengubah hanya latar belakang master mungkin tidak mengubah slide tersebut. Gunakan [Background.GetEffective](https://reference.aspose.com/slides/id/net/aspose.slides/background/geteffective/) ketika Anda perlu mengetahui latar belakang akhir setelah pewarisan diterapkan.

{{% alert color="warning" title="Peringatan" %}}
Jangan memperlakukan `StyleIndex` sebagai indeks koleksi berbasis nol. Hindari juga mengkodekan nomor gaya dari satu file dan menganggapnya memiliki tampilan yang sama di file lain; definisi gaya tema bersifat spesifik presentasi.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Untuk pemformatan latar belakang langsung dan pewarisan latar belakang, lihat [Presentation Background](/slides/id/net/presentation-background/).
{{% /alert %}}

## **Memperbarui Efek Tema**

Skema format tema berisi koleksi terpisah [FillStyles](https://reference.aspose.com/slides/id/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/id/net/aspose.slides.theme/formatscheme/linestyles/), dan [EffectStyles](https://reference.aspose.com/slides/id/net/aspose.slides.theme/formatscheme/effectstyles/). Tema Office tipikal sering berisi tiga entri gaya utama yang secara visual berkorespondensi dengan pemformatan halus, sedang, dan intens, tetapi kode harus memeriksa setiap koleksi alih-alih mengasumsikan jumlah tetap.

![Efek tema halus, sedang, dan intens yang diterapkan pada bentuk yang sama](presentation-design_10.png)

Ketika Anda mengakses koleksi ini dalam C#, indeks koleksi berbasis nol: `[0]` adalah gaya pertama yang disimpan dan `[2]` adalah gaya ketiga. Indeks referensi gaya pada bentuk merupakan konsep terpisah, diekspos melalui [IShapeStyle](https://reference.aspose.com/slides/id/net/aspose.slides/ishapestyle/). Memodifikasi gaya tema memengaruhi bentuk yang merujuk ke gaya tema tersebut; bentuk dengan pemformatan langsung mungkin tetap tidak berubah.

Contoh berikut memeriksa apakah entri gaya yang diperlukan ada, mengubah gaya garis pertama, mengubah gaya isi ketiga, mengaktifkan bayangan luar pada gaya efek ketiga, dan menyimpan hasilnya:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Subtle_Moderate_Intense.pptx");
var formatScheme = presentation.MasterTheme.FormatScheme;

if (formatScheme.LineStyles.Count < 1 || formatScheme.FillStyles.Count < 3 || formatScheme.EffectStyles.Count < 3)
{
    throw new InvalidOperationException("The theme does not contain the style entries required by this example.");
}

formatScheme.LineStyles[0].FillFormat.FillType = FillType.Solid;
formatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;
formatScheme.FillStyles[2].FillType = FillType.Solid;
formatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;
formatScheme.EffectStyles[2].EffectFormat.EnableOuterShadowEffect();
formatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

presentation.Save("theme-effects.pptx", SaveFormat.Pptx);
```

Untuk bentuk yang merujuk ke slot ini, gaya garis tema pertama menjadi merah, gaya isi tema ketiga menjadi hijau hutan solid, dan gaya efek ketiga mendapatkan bayangan luar dengan jarak 10 poin. Hasil visual tepat tetap bergantung pada slot gaya mana yang dirujuk masing‑masing bentuk dan apakah pemformatan langsung menimpa tema.

![Gaya efek tema setelah mengubah garis, isi, dan pengaturan bayangan](presentation-design_11.png)

## **Menentukan Apakah Isi Solid Efektif Menggunakan Warna Tema**

Sebuah isi dapat disimpan langsung pada objek atau diwarisi dari paragraf, tata letak, master, gaya tema, atau level pemformatan lainnya. Panggil [IFillFormat.GetEffective](https://reference.aspose.com/slides/id/net/aspose.slides/ifillformat/geteffective/) untuk menyelesaikan hierarki tersebut menjadi [IFillFormatEffectiveData](https://reference.aspose.com/slides/id/net/aspose.slides/ifillformateffectivedata/) yang tidak dapat diubah. Pertama periksa [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/id/net/aspose.slides/ifillformateffectivedata/filltype/). Hanya ketika nilai tersebut `FillType.Solid` Anda harus membaca properti isi solid.

Untuk isi solid, [IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/id/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) mengembalikan nilai RGB akhir setelah pewarisan, pencarian tema, dan transformasi warna diterapkan. [IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/id/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) mengembalikan slot logis [SchemeColor](https://reference.aspose.com/slides/id/net/aspose.slides/schemecolor/) yang bersesuaian, seperti `Text1` atau `Accent6`. Nilai `SchemeColor.NotDefined` berarti isi solid efektif tidak berbasis pada warna skema. Dalam alur kerja di mana isi hanya berupa warna tema atau warna RGB langsung, nilai ini mengidentifikasi isi RGB langsung.

Jangan hanya menggunakan nilai lokal [IColorFormat.SchemeColor](https://reference.aspose.com/slides/id/net/aspose.slides/icolorformat/schemecolor/) untuk mengklasifikasikan isi. Misalnya, bagian teks dapat tidak memiliki warna skema yang didefinisikan secara lokal, sehingga nilainya `NotDefined`, sementara isi efektifnya mewarisi warna tema dan beresolusi ke `Text1` atau `Accent6`. Sebaliknya, `SolidFillSchemeColor` memberi tahu Anda slot tema logis yang menghasilkan warna efektif, tetapi tidak memberi tahu dari level mana slot tersebut berasal (objek, paragraf, tata letak, master, atau level lainnya).

Contoh berikut memuat presentasi, mengaudit isi bentuk dan isi bagian teks, mencetak setiap nilai RGB akhir serta skema warna yang terkait, dan menandai isi solid yang tidak akan melacak perubahan warna tema:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

var slideCount = presentation.Slides.Count;
for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];

    var shapeCount = slide.Shapes.Count;
    for (var shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        var shapeName = $"Slide {slideIndex + 1}, shape {shapeIndex + 1}";
        AuditFill(shapeName, shape.FillFormat);

        if (shape is IAutoShape autoShape)
        {
            var paragraphCount = autoShape.TextFrame.Paragraphs.Count;
            for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                var paragraph = autoShape.TextFrame.Paragraphs[paragraphIndex];

                var portionCount = paragraph.Portions.Count;
                for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    var portion = paragraph.Portions[portionIndex];
                    var portionName = $"{shapeName}, paragraph {paragraphIndex + 1}, portion {portionIndex + 1}";
                    AuditFill(portionName, portion.PortionFormat.FillFormat);
                }
            }
        }
    }
}

static void AuditFill(string objectName, IFillFormat localFill)
{
    var effectiveFill = localFill.GetEffective();

    if (effectiveFill.FillType != FillType.Solid)
    {
        Console.WriteLine($"{objectName}: fill type = {effectiveFill.FillType}; not a solid fill.");
        return;
    }

    var rgb = effectiveFill.SolidFillColor;
    var effectiveSchemeColor = effectiveFill.SolidFillSchemeColor;
    var localSchemeColor = localFill.SolidFillColor.SchemeColor;

    Console.WriteLine($"{objectName}: RGB = #{rgb.R:X2}{rgb.G:X2}{rgb.B:X2}");
    Console.WriteLine($"{objectName}: local scheme = {localSchemeColor}, effective scheme = {effectiveSchemeColor}");

    if (effectiveSchemeColor == SchemeColor.NotDefined)
    {
        Console.WriteLine($"{objectName}: direct RGB or another non-scheme fill; audit as theme-independent.");
    }
    else
    {
        Console.WriteLine($"{objectName}: theme-dependent through {effectiveSchemeColor}.");
    }
}
```

Cabang `NotDefined` menyediakan daftar audit isi solid yang tidak akan merespons perubahan slot warna tema. Tinjau objek-objek ini ketika presentasi harus mengikuti palet merek baru. Nilai RGB yang dilaporkan masih menunjukkan tampilan saat ini, sementara nilai skema menjelaskan apakah tampilan tersebut terhubung ke tema.

Objek format‑efektif adalah snapshot. Setelah mengubah tema presentasi, penimpaan tema, atau pemformatan yang diwarisi, panggil kembali `GetEffective` dan baca objek `IFillFormatEffectiveData` baru sebelum membandingkan atau melaporkan warna.

## **Membaca Nilai Tema Efektif**

Objek tema mentah memberi tahu Anda apa yang didefinisikan pada level tertentu. Nilai efektif memberi tahu apa yang sebenarnya digunakan slide atau bentuk setelah pewarisan dan penimpaan lokal diselesaikan. Untuk slide, panggil [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/id/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). Untuk latar belakang, gunakan [Background.GetEffective](https://reference.aspose.com/slides/id/net/aspose.slides/background/geteffective/), dan untuk isi, gunakan [FillFormat.GetEffective](https://reference.aspose.com/slides/id/net/aspose.slides/fillformat/geteffective/).

Contoh berikut membaca tema efektif, latar belakang, dan isi bentuk pertama dari sebuah slide:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var effectiveTheme = slide.ThemeManager.CreateThemeEffective();
var effectiveBackground = slide.Background.GetEffective();

Console.WriteLine($"Effective major Latin font: {effectiveTheme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Effective minor Latin font: {effectiveTheme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Effective background fill type: {effectiveBackground.FillFormat.FillType}");

if (slide.Shapes.Count > 0)
{
    var effectiveFill = slide.Shapes[0].FillFormat.GetEffective();
    Console.WriteLine($"First shape effective fill type: {effectiveFill.FillType}");
    if (effectiveFill.FillType == FillType.Solid)
    {
        Console.WriteLine($"First shape effective fill color: {effectiveFill.SolidFillColor}");
    }
}
```

Gunakan data efektif untuk diagnostik rendering, validasi, dan perbandingan. Jika Anda hanya memeriksa [Presentation.MasterTheme](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/mastertheme/), Anda dapat melewatkan penimpaan master, tata letak, slide, atau bentuk yang mengubah tampilan akhir.

## **FAQ**

**Apakah menerapkan tema eksternal memengaruhi setiap slide dalam presentasi?**

Tidak. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) hanya menugaskan ulang slide yang bergantung pada master terpilih. Slide yang menggunakan master lain mempertahankan tema yang ada.

**Bisakah saya menerapkan tema ke satu slide tanpa mengubah master?**

Ya. Gunakan [SlideThemeManager](https://reference.aspose.com/slides/id/net/aspose.slides.theme/slidethememanager/) slide dan inisialisasi penimpaan temanya. Perubahan tetap lokal pada slide tersebut; slide lain tetap mewarisi tema mereka yang ada.

**Apa cara paling aman untuk membawa tema dari satu presentasi ke presentasi lain?**

Saat memindahkan slide dan mempertahankan tampilan sumbernya, kloning master sumber ke tujuan dan kloning slide dengan master itu menggunakan [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslidecollection/addclone/) serta [ISlideCollection.AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/addclone/). Ini menjaga master, tata letak, dan tema tetap bersama.

**Bagaimana saya dapat melihat nilai efektif setelah pewarisan dan penimpaan?**

Gunakan [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/id/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) untuk slide atau tema tata letak serta metode data‑efektif yang sesuai untuk objek format seperti [Background.GetEffective](https://reference.aspose.com/slides/id/net/aspose.slides/background/geteffective/) dan [FillFormat.GetEffective](https://reference.aspose.com/slides/id/net/aspose.slides/fillformat/geteffective/). API‑API ini mengembalikan nilai yang telah diselesaikan setelah pewarisan dan penimpaan diterapkan.