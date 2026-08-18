---
title: Mengelola Tema Presentasi di .NET
linktitle: Tema Presentasi
type: docs
weight: 10
url: /id/net/presentation-theme/
keywords:
- tema PowerPoint
- tema presentasi
- tema slide
- mengatur tema
- mengubah tema
- mengelola tema
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
description: "Kelola tema presentasi master di Aspose.Slides untuk .NET untuk membuat, menyesuaikan, dan mengonversi file PowerPoint dengan merek yang konsisten."
---
## **Pengantar**

Tema presentasi mendefinisikan satu set warna, font, gaya latar belakang, isi, garis, dan efek yang terkoordinasi. Objek yang menyadari tema merujuk pada definisi bersama ini alih-alih menyimpan setiap properti visual sebagai nilai tetap, sehingga perubahan tema dapat memperbarui banyak objek sekaligus.

Di Aspose.Slides, tema tingkat presentasi tersedia melalui properti [Presentation.MasterTheme](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/mastertheme/). Sebuah presentasi juga dapat berisi penimpaan tema pada level yang lebih rendah. Sebuah master dapat menimpa tema presentasi melalui [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/id/net/aspose.slides.theme/masterthememanager/overridetheme/), sebuah tata letak dapat menimpa tema yang diwariskan melalui [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/id/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), dan slide individu dapat melakukan hal yang sama. Pada praktiknya, tema efektif untuk sebuah slide diselesaikan melalui rantai pewarisan ini: tema presentasi, penimpaan master, penimpaan tata letak, dan penimpaan slide.

![Komponen tema: warna, font, gaya latar belakang, dan efek](theme-constituents.png)

Bagian-bagian di bawah ini menunjukkan alur kerja tema yang paling umum: memeriksa tema, mengubah warna dan font, menyalin atau menerapkan tema, memperbarui gaya latar belakang dan efek, serta membaca nilai efektif setelah pewarisan dan penimpaan diselesaikan.

## **Memeriksa Tema**

Objek [MasterTheme](https://reference.aspose.com/slides/id/net/aspose.slides.theme/mastertheme/) menampilkan [ColorScheme](https://reference.aspose.com/slides/id/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/id/net/aspose.slides.theme/mastertheme/fontscheme/), dan [FormatScheme](https://reference.aspose.com/slides/id/net/aspose.slides.theme/mastertheme/formatscheme/). Memeriksa koleksi ini sebelum mengubahnya sangat berguna ketika sebuah presentasi berasal dari sumber eksternal karena jumlah dan isi entri gaya dapat bervariasi.

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

Jika sebuah berkas menggunakan beberapa master, jangan mengasumsikan bahwa setiap slide memiliki tema efektif yang sama. Periksa master yang terkait dengan slide, dan gunakan alur kerja tema-efektif yang ditunjukkan nanti dalam artikel ini ketika penimpaan tata letak atau slide mungkin ada.

## **Mengubah Warna Tema**

Isian, garis, dan teks yang menyadari tema dapat merujuk pada warna logis dari enumerasi [SchemeColor](https://reference.aspose.com/slides/id/net/aspose.slides/schemecolor/). Ketika Anda mengubah entri yang sesuai dalam [IColorScheme](https://reference.aspose.com/slides/id/net/aspose.slides.theme/icolorscheme/) tema, semua objek yang masih merujuk pada warna tema tersebut akan diselesaikan terhadap nilai baru. Objek yang menggunakan warna RGB langsung tidak diubah oleh pembaruan warna tema.

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

Karena persegi panjang tetap terhubung ke `Accent4`, warnanya yang terlihat menjadi merah setelah tema diubah. Jika Anda mengganti warna skema dengan warna langsung pada bentuk, perubahan selanjutnya pada `Accent4` tidak akan memengaruhi isi tersebut.

### **Gunakan Warna dari Palet Tambahan**

PowerPoint menghasilkan varian lebih terang dan lebih gelap dari sebuah warna tema dengan menerapkan transformasi warna. Aspose.Slides menyajikan transformasi ini melalui [ColorTransformOperation](https://reference.aspose.com/slides/id/net/aspose.slides/colortransformoperation/).

![Warna tema utama dan warna lebih terang serta lebih gelap yang dihasilkan dari palet tambahan](additional-palette-colors.png)

**1** - Warna tema utama.

**2** - Varian lebih terang dan lebih gelap yang dihasilkan dari warna tema utama.

Contoh berikut membuat enam persegi panjang berdasarkan `Accent4`, menerapkan transformasi luminansi pada lima di antaranya, dan menyimpan hasilnya:

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

Varian ini tetap berlandaskan pada warna tema. Jika `Accent4` berubah di kemudian hari, warna yang ditransformasi dihitung kembali dari nilai `Accent4` baru.

### **Petakan Nilai `SchemeColor` ke Slot `IColorScheme`**

Enumerasi [SchemeColor](https://reference.aspose.com/slides/id/net/aspose.slides/schemecolor/) menggunakan `Text1`, `Background1`, `Text2`, dan `Background2`, sementara [IColorScheme](https://reference.aspose.com/slides/id/net/aspose.slides.theme/icolorscheme/) menampilkan slot tema yang sama sebagai `Dark1`, `Light1`, `Dark2`, dan `Light2`. Pemetaan bersifat tetap:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ini adalah nama alternatif untuk slot tema yang sama; mereka bukan nilai yang dikonversi secara dinamis dari satu bentuk ke bentuk lainnya.

## **Mengubah Font Tema**

Sebuah skema font tema berisi satu set font utama untuk heading dan satu set font minor untuk teks badan. Properti [FontScheme.Major](https://reference.aspose.com/slides/id/net/aspose.slides.theme/fontscheme/major/) dan [FontScheme.Minor](https://reference.aspose.com/slides/id/net/aspose.slides.theme/fontscheme/minor/) menampilkan set tersebut.

Pengidentifikasi font tema yang kompatibel dengan PowerPoint dapat digunakan dalam pemformatan teks:

* `+mn-lt` - Font Tubuh Latin (Font Latin Minor)
* `+mj-lt` - Font Heading Latin (Font Latin Mayor)
* `+mn-ea` - Font Tubuh Asia Timur (Font Asia Timur Minor)
* `+mj-ea` - Font Heading Asia Timur (Font Asia Timur Mayor)

Contoh berikut membuat satu heading yang menggunakan font Latin tema mayor dan satu baris tubuh yang menggunakan font Latin tema minor. Kemudian mengubah font tema dan menyimpan hasilnya:

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

Heading mengikuti font mayor dan teks badan mengikuti font minor. Teks yang memiliki nama font eksplisit alih-alih pengidentifikasi tema tidak akan beralih secara otomatis ketika skema font tema berubah.

{{% alert color="info" title="Tip" %}}
Untuk informasi lebih lanjut tentang font presentasi, lihat [PowerPoint Fonts](/slides/id/net/powerpoint-fonts/).
{{% /alert %}}

## **Menyalin atau Menerapkan Tema**

Ada dua alur kerja umum, dan mereka menyelesaikan masalah yang berbeda.

### **Mempertahankan Tema Sumber Saat Memindahkan Slide**

Jika Anda ingin memindahkan slide ke presentasi lain dan mempertahankan desain aslinya, kloning master sumber ke dalam presentasi target dengan [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslidecollection/addclone/), lalu klon slide dengan [ISlideCollection.AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/addclone/) dan master yang dikloning. Ini membawa master, layoutnya, dan tema terkait bersama.

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

Ini adalah alur kerja yang disarankan ketika slide sumber harus terlihat sama di tujuan. Mengkloning konten ke master tujuan yang tidak terkait dapat mengubah warna, font, latar belakang, dan efek yang dipengaruhi tema.

### **Menerapkan Nilai Tema ke Slide yang Ada**

Jika slide tujuan harus tetap pada master dan tata letak saat ini, inisialisasi penimpaan tingkat slide dari tema sumber. Metode [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/id/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/id/net/aspose.slides.theme/overridetheme/initfontschemefrom/), dan [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/id/net/aspose.slides.theme/overridetheme/initformatschemefrom/) menyalin tiga komponen utama tema ke dalam penimpaan.

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

Ini mengubah tema yang digunakan oleh slide tersebut tanpa mengubah tema yang diwarisi oleh slide lain. Untuk menghapus penimpaan lokal dan kembali ke nilai yang diwariskan, panggil [OverrideTheme.Clear](https://reference.aspose.com/slides/id/net/aspose.slides.theme/overridetheme/clear/).

### **Menerapkan Penimpaan Tema ke Layout**

Penimpaan tingkat layout berlaku untuk slide yang menggunakan layout tersebut, kecuali slide tertentu memiliki penimpaan sendiri. Metode inisialisasi yang sama dapat digunakan melalui [LayoutSlideThemeManager](https://reference.aspose.com/slides/id/net/aspose.slides.theme/layoutslidethememanager/):

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

Gunakan tema master atau tingkat presentasi ketika banyak layout dan slide harus berbagi desain dasar yang sama, penimpaan layout ketika satu keluarga layout membutuhkan gaya yang berbeda, dan penimpaan slide hanya untuk pengecualian nyata. Penimpaan tingkat slide yang berlebihan membuat perubahan tema global di kemudian hari sulit diprediksi.

## **Memperbarui Gaya Latar Belakang Tema**

Isian latar belakang tema disimpan di [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/id/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint dapat menampilkan lebih banyak pilihan latar belakang di UI‑nya dibandingkan jumlah definisi isian yang secara fisik disimpan dalam koleksi ini karena UI dapat menggabungkan isian tema dengan warna tema dan referensi gaya lainnya.

![Galeri gaya latar belakang PowerPoint untuk tema presentasi](presentation-design_8.png)

Sebelum menggunakan gaya latar belakang, periksa koleksi yang disimpan dan [Background.StyleIndex](https://reference.aspose.com/slides/id/net/aspose.slides/background/styleindex/). `StyleIndex` menggunakan `0` untuk tidak ada isian bertema; nilai positif merupakan referensi gaya latar belakang tema. Ini berbeda dari mengindeks koleksi .NET secara langsung, di mana `[0]` berarti item pertama yang disimpan. Jangan mengasumsikan bahwa setiap presentasi memiliki jumlah gaya isian latar belakang yang sama.

Contoh berikut melaporkan jumlah isian latar belakang yang tersedia, menetapkan referensi latar belakang bertema ke master pertama, dan menyimpan presentasi:

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
Jangan memperlakukan `StyleIndex` sebagai indeks koleksi berbasis nol. Juga hindari mengkodekan keras nomor gaya dari satu berkas dan mengasumsikan memiliki tampilan yang sama di berkas lain; definisi gaya tema bersifat spesifik untuk presentasi.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Untuk pemformatan latar belakang langsung dan pewarisan latar belakang, lihat [Presentation Background](/slides/id/net/presentation-background/).
{{% /alert %}}

## **Memperbarui Efek Tema**

Sebuah skema format tema berisi koleksi terpisah [FillStyles](https://reference.aspose.com/slides/id/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/id/net/aspose.slides.theme/formatscheme/linestyles/), dan [EffectStyles](https://reference.aspose.com/slides/id/net/aspose.slides.theme/formatscheme/effectstyles/). Tema Office tipikal sering berisi tiga entri gaya utama yang secara visual sesuai dengan pemformatan halus, sedang, dan intens, tetapi kode harus memeriksa setiap koleksi alih‑alih mengasumsikan jumlah tetap.

![Efek tema halus, sedang, dan intens yang diterapkan pada bentuk yang sama](presentation-design_10.png)

Ketika Anda mengakses koleksi ini di C#, indeks koleksi berbasis nol: `[0]` adalah gaya pertama yang disimpan dan `[2]` adalah yang ketiga. Indeks referensi gaya sebuah bentuk adalah konsep terpisah, ditampilkan melalui [IShapeStyle](https://reference.aspose.com/slides/id/net/aspose.slides/ishapestyle/). Memodifikasi gaya tema memengaruhi bentuk yang merujuk pada gaya tema tersebut; bentuk dengan pemformatan langsung mungkin tetap tidak berubah.

Contoh berikut memeriksa bahwa entri gaya yang diperlukan ada, mengubah gaya garis pertama, mengubah gaya isi ketiga, mengaktifkan bayangan luar pada gaya efek ketiga, dan menyimpan hasilnya:

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

Untuk bentuk yang merujuk pada slot ini, gaya garis tema pertama menjadi merah, gaya isi tema ketiga menjadi hijau hutan solid, dan gaya efek ketiga mendapatkan bayangan luar dengan jarak 10 poin. Hasil visual yang tepat masih bergantung pada slot gaya mana yang dirujuk masing-masing bentuk dan apakah pemformatan langsung menimpa tema.

![Gaya efek tema setelah mengubah pengaturan garis, isi, dan bayangan](presentation-design_11.png)

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

Gunakan data efektif untuk diagnosa rendering, validasi, dan perbandingan. Jika Anda hanya memeriksa [Presentation.MasterTheme](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/mastertheme/), Anda dapat melewatkan penimpaan master, layout, slide, atau bentuk yang mengubah tampilan akhir.

## **FAQ**

**Bisakah saya menerapkan tema ke satu slide tanpa mengubah master?**

Ya. Gunakan [SlideThemeManager](https://reference.aspose.com/slides/id/net/aspose.slides.theme/slidethememanager/) slide dan inisialisasi tema penimpaan. Perubahan tetap lokal pada slide tersebut; slide lain terus mewarisi tema mereka yang ada.

**Apa cara paling aman untuk membawa tema dari satu presentasi ke presentasi lain?**

Ketika memindahkan slide dan mempertahankan tampilan sumbernya, klon master sumber ke destinasi dan klon slide dengan master itu menggunakan [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslidecollection/addclone/) dan [ISlideCollection.AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/addclone/). Ini menjaga master, layout, dan tema bersama.

**Bagaimana saya dapat melihat nilai efektif setelah pewarisan dan penimpaan?**

Gunakan [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/id/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) untuk tema slide atau layout dan metode data efektif yang sesuai untuk objek format seperti [Background.GetEffective](https://reference.aspose.com/slides/id/net/aspose.slides/background/geteffective/) dan [FillFormat.GetEffective](https://reference.aspose.com/slides/id/net/aspose.slides/fillformat/geteffective/). API ini mengembalikan nilai yang diselesaikan setelah pewarisan dan penimpaan diterapkan.