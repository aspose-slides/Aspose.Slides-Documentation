---
title: Kelola Hyperlink Presentasi di .NET
linktitle: Kelola Hyperlink
type: docs
weight: 20
url: /id/net/manage-hyperlinks/
keywords:
- menambahkan URL
- menambahkan hyperlink
- membuat hyperlink
- memformat hyperlink
- menghapus hyperlink
- memperbarui hyperlink
- hyperlink teks
- hyperlink slide
- hyperlink bentuk
- hyperlink gambar
- hyperlink video
- hyperlink dapat diubah
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Menambahkan, memformat, memperbarui, dan menghapus hyperlink dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk .NET, menggunakan contoh C#."
---
## **Pendahuluan**

Hyperlink menghubungkan konten presentasi ke situs web atau lokasi dalam presentasi. Di PowerPoint, hyperlink biasanya melayani dua tujuan:

* Membuka situs web dari teks, bentuk, atau bingkai media.
* Menavigasi ke slide lain, misalnya, dari daftar isi.

Aspose.Slides for .NET memungkinkan Anda menambahkan tautan ini, mengontrol tampilan dan suaranya, memperbarui propertinya, dan menghapusnya. Contoh-contoh di bawah ini menunjukkan cara bekerja dengan hyperlink pada elemen individual dan cara mengakses hyperlink pada tingkat presentasi, slide, atau bingkai teks.

{{% alert color="info" title="Note" %}}
Anda juga dapat mengedit presentasi dengan [editor Aspose PowerPoint online gratis](https://products.aspose.app/slides/id/editor).
{{% /alert %}} 

## **Tambahkan Hyperlink URL**

Anda dapat menetapkan URL situs web ke teks, bentuk, atau bingkai media. Elemen yang Anda tetapkan hyperlink menentukan area yang dapat diklik: bagian teks menautkan teks yang dipilih, sedangkan bentuk atau bingkai menautkan objek slide.

### **Tambahkan Hyperlink URL ke Teks**

Untuk menautkan teks ke situs web, tetapkan sebuah [Hyperlink](https://reference.aspose.com/slides/id/net/aspose.slides/hyperlink/) ke properti [HyperlinkClick](https://reference.aspose.com/slides/id/net/aspose.slides/portionformat/hyperlinkclick/) pada bagian teks, seperti yang ditunjukkan di bawah. Hanya bagian teks tersebut yang menjadi dapat diklik.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var textShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
textShape.AddTextFrame("Aspose: File Format APIs");
var portionFormat = textShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
portionFormat.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";
portionFormat.FontHeight = 32;

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

### **Tambahkan Hyperlink URL ke Bentuk dan Bingkai Media**

Untuk membuat bentuk atau bingkai dapat diklik, atur properti [HyperlinkClick](https://reference.aspose.com/slides/id/net/aspose.slides/shape/hyperlinkclick/)‑nya. Hyperlink merupakan milik objek itu sendiri, bukan pada bagian teks di dalamnya.

Pendekatan yang sama berlaku untuk bingkai gambar, audio, dan video: tetapkan hyperlink ke bingkai dan atur [Tooltip](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlink/tooltip/) tautan jika diperlukan.

Contoh berikut membuat sebuah persegi panjang dapat diklik:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **Gunakan Hyperlink untuk Membuat Daftar Isi**

Hyperlink internal memungkinkan pembaca melompat dari daftar isi ke slide tertentu. Contoh berikut menggunakan [SetInternalHyperlinkClick](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) untuk menautkan teks "Page 2" pada slide pertama ke slide kedua.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var tableOfContents = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
tableOfContents.FillFormat.FillType = FillType.NoFill;
tableOfContents.LineFormat.FillFormat.FillType = FillType.NoFill;
tableOfContents.TextFrame.Paragraphs.Clear();

var paragraph = new Paragraph();
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
paragraph.Text = "Title of slide 2 .......... ";

var linkPortion = new Portion();
linkPortion.Text = "Page 2";
linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

paragraph.Portions.Add(linkPortion);
tableOfContents.TextFrame.Paragraphs.Add(paragraph);

presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
```

## **Format Hyperlink**

### **Warna**

Properti [ColorSource](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlink/colorsource/) dari [IHyperlink](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlink/) menentukan apakah hyperlink menggunakan warna hyperlink presentasi atau format bagian teks. Untuk menerapkan warna teks khusus, pilih [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/id/net/aspose.slides/hyperlinkcolorsource/) dan atur warna isi bagian tersebut. Fitur ini diperkenalkan di PowerPoint 2019; versi lama tidak menerapkan pengaturan ini.

Contoh berikut menambahkan dua hyperlink teks ke slide yang sama. Hyperlink pertama menggunakan isi teks merah, sementara yang kedua mempertahankan warna hyperlink default.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var coloredShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
coloredShape.AddTextFrame("This hyperlink uses a custom color.");
var coloredPortionFormat = coloredShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
coloredPortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
coloredPortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
coloredPortionFormat.FillFormat.FillType = FillType.Solid;
coloredPortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

var defaultShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
defaultShape.AddTextFrame("This hyperlink uses the default color.");
defaultShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
```

### **Suara**

Sebuah hyperlink dapat memutar suara saat diaktifkan atau menghentikan suara yang sedang diputar. Gunakan properti berikut untuk mengkonfigurasi perilaku ini:

- [IHyperlink.Sound](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlink/sound/) menentukan audio yang terkait dengan hyperlink.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlink/stopsoundonclick/) mengontrol apakah mengaktifkan hyperlink menghentikan suara sebelumnya.

#### **Tambahkan Suara Hyperlink**

Contoh berikut memuat `sampleaudio.wav` dan mengaitkannya dengan tombol pada slide pertama. Mengklik tombol memutar suara dan menavigasi ke slide berikutnya. Bentuk kedua pada slide tersebut menghentikan suara sebelumnya saat diklik, tanpa melakukan aksi navigasi.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var audioData = File.ReadAllBytes("sampleaudio.wav");
var hyperlinkSound = presentation.Audios.AddAudio(audioData);

var firstSlide = presentation.Slides[0];

var playButton = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
playButton.HyperlinkClick = Hyperlink.NextSlide;

if (!playButton.HyperlinkClick.StopSoundOnClick && playButton.HyperlinkClick.Sound == null)
{
    playButton.HyperlinkClick.Sound = hyperlinkSound;
}

var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var stopButton = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
stopButton.HyperlinkClick = Hyperlink.NoAction;

stopButton.HyperlinkClick.StopSoundOnClick = true;

presentation.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
```

#### **Ekstrak Suara Hyperlink**

Contoh berikut membuka presentasi yang dibuat di atas dan membaca audio hyperlink bentuk pertama ke memori melalui [Sound](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlink/sound/) dan [BinaryData](https://reference.aspose.com/slides/id/net/aspose.slides/iaudio/binarydata/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("hyperlink-sound.pptx");

if (presentation.Slides.Count > 0 && presentation.Slides[0].Shapes.Count > 0)
{
    var hyperlink = presentation.Slides[0].Shapes[0].HyperlinkClick;
    var sound = hyperlink?.Sound;
    if (sound != null)
    {
        var audioData = sound.BinaryData;
        Console.WriteLine($"Extracted {audioData.Length} bytes of hyperlink audio.");
    }
    else
    {
        Console.WriteLine("The first shape has no hyperlink sound.");
    }
}
else
{
    Console.WriteLine("The presentation has no first slide or shape to inspect.");
}
```

### **Pengaturan Tooltip dan Interaksi**

Anda dapat memperbarui properti [IHyperlink](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlink/) berikut setelah menetapkan hyperlink ke teks atau bentuk:

- [Tooltip](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlink/tooltip/) menetapkan teks yang dapat ditampilkan penonton sebagai petunjuk untuk tautan.
- [TargetFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlink/targetframe/) menentukan bingkai target dalam frameset HTML induk, bila berlaku.
- [History](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlink/history/) mengontrol apakah mengaktifkan tautan menambahkan destinasinya ke daftar hyperlink yang telah dilihat.
- [HighlightClick](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlink/highlightclick/) mengontrol apakah hyperlink disorot saat diklik.

## **Hapus Hyperlink dari Presentasi**

Gunakan [GetAnyHyperlinks](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) untuk mengumpulkan kontainer hyperlink, termasuk tautan bagian teks, sebelum mengubahnya. Contoh berikut menghapus kedua tipe aktivasi dari slide pertama. Untuk menghapus hanya satu tipe, panggil hanya [RemoveHyperlinkClick](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) atau [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); menghapus aksi klik tidak menghapus pasangan mouse-over-nya.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

if (presentation.Slides.Count > 0)
{
    var containers = presentation.Slides[0].HyperlinkQueries.GetAnyHyperlinks().ToList();
    foreach (var container in containers)
    {
        container.HyperlinkManager.RemoveHyperlinkClick();
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
    presentation.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The presentation has no slides to process.");
}
```

Untuk penghapusan tanpa syarat, [RemoveAllHyperlinks](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) menghapus kedua tipe aktivasi dalam ruang lingkup yang dipilih dalam satu panggilan. Untuk pembersihan selektif dan cakupan master, tata letak, serta catatan, lihat [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Bangun Inventaris Hyperlink Lengkap**

Sebelum mendistribusikan presentasi, inventarisasi tindakan interaktifnya serta tautan webnya. [GetAnyHyperlinks](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) mengembalikan objek [IHyperlinkContainer](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlinkcontainer/), bukan daftar datar string URL. Periksa baik [HyperlinkClick](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) maupun [HyperlinkMouseOver](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) pada setiap kontainer. Mereka bersifat independen: kontainer yang sama dapat mengungkapkan kedua aksi, sehingga laporan lengkap membutuhkan hingga dua baris per kontainer.

Pemindaian hanya hyperlink tingkat bentuk dapat melewatkan tautan yang terlampir pada bagian teks. Sebaiknya kueri ruang lingkup yang tepat, dan simpan kontainer yang dikembalikan sehingga Anda dapat memperbarui atau menghapus aksinya nanti.

### **Kueri Ruang Lingkup Presentasi, Slide, dan Bingkai Teks**

Antarmuka [IHyperlinkQueries](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlinkqueries/) tersedia melalui [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseslide/hyperlinkqueries/), dan [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/hyperlinkqueries/). Setiap ruang lingkup mendukung kueri yang sama:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) mengembalikan kontainer dengan aksi klik.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) mengembalikan kontainer dengan aksi mouse-over.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) mengembalikan kontainer dengan salah satu atau kedua aksi.

Contoh berikut membuat `hyperlink-audit-input.pptx` dengan tautan klik eksternal, tautan mouse-over berkas, navigasi slide internal, tautan mouse-over teks, dan aksi makro. Contoh ini tidak menjalankan aksi apa pun. Tiga kueri yang sama berfungsi pada setiap ruang lingkup; hitungan menggambarkan kontainer, bukan total aksi. Ruang lingkup bingkai teks mengecualikan tautan milik bentuk yang membungkusnya.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var destination = presentation.Slides.AddEmptySlide(slide.LayoutSlide);
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Click the text to go to slide 2";
shape.HyperlinkManager.SetExternalHyperlinkClick("https://example.com/");
shape.HyperlinkClick.Tooltip = "Public website";
shape.HyperlinkManager.SetExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

var portionFormat = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkManager.SetInternalHyperlinkClick(destination);
portionFormat.HyperlinkManager.SetExternalHyperlinkMouseOver("https://example.com/help");
var macroButton = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
macroButton.HyperlinkManager.SetMacroHyperlinkClick("ReviewPresentation");

PrintCounts("Presentation", presentation.HyperlinkQueries);
PrintCounts("Slide 1", slide.HyperlinkQueries);
PrintCounts("Text frame", shape.TextFrame.HyperlinkQueries);
presentation.Save("hyperlink-audit-input.pptx", SaveFormat.Pptx);

static void PrintCounts(string scope, IHyperlinkQueries queries)
{
    var clickContainers = queries.GetHyperlinkClicks();
    var mouseOverContainers = queries.GetHyperlinkMouseOvers();
    var allContainers = queries.GetAnyHyperlinks();
    Console.WriteLine($"{scope}: click={clickContainers.Count}, mouse-over={mouseOverContainers.Count}, any={allContainers.Count}");
}
```

Untuk contoh ini, kueri presentasi dan slide masing-masing melaporkan tiga kontainer klik, dua kontainer mouse-over, dan tiga kontainer dengan salah satu aksi. Kueri bingkai teks melaporkan satu kontainer di tiap kategori.

### **Klasifikasikan Aksi dan Tujuan**

Gunakan [IHyperlink.ActionType](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlink/actiontype/) untuk menafsirkan sebuah aksi sebelum menafsirkan tujuannya. Nilai [HyperlinkActionType](https://reference.aspose.com/slides/id/net/aspose.slides/hyperlinkactiontype/) mencakup lebih dari navigasi web:

| Nilai | Makna untuk audit |
| --- | --- |
| `Hyperlink` | Hyperlink eksternal; periksa URL dan skemanya. |
| `JumpSpecificSlide` | Navigasi internal ke slide tertentu. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navigasi slideshow bawaan, diselesaikan dalam konteks slideshow. |
| `JumpEndShow`, `StartCustomSlideShow` | Mengakhiri pertunjukan saat ini atau memulai pertunjukan khusus. |
| `StartMacro` | Menjalankan makro. |
| `StartProgram` | Meluncurkan program. |
| `OpenFile`, `OpenPresentation` | Membuka berkas atau presentasi lain; tinjau terpisah dari URL web. |
| `StartStopMedia` | Memulai atau menghentikan pemutaran media. |
| `NoAction`, `Unknown` | Tidak ada aksi navigasi, atau aksi tidak dikenal yang memerlukan tinjauan. |

Baca tujuan eksternal dari [ExternalUrl](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlink/externalurl/) dan tujuan internal spesifik dari [TargetSlide](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlink/targetslide/). Aksi internal dan perintah bawaan mungkin tidak memiliki URL eksternal; URL kosong tidak berarti kontainer tidak memiliki aksi. Pertahankan [ExternalUrlOriginal](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlink/externalurloriginal/) bila berbeda dari URL yang dinormalisasi, dan sertakan [Tooltip](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlink/tooltip/) bila tersedia.

### **Laporan, Sanitasi, dan Verifikasi Hyperlink**

Contoh .NET 6+ berikut membaca presentasi yang ada (gunakan berkas yang dibuat di atas), menulis `hyperlink-audit.json`, menerapkan kebijakan, menyimpan `hyperlink-sanitized.pptx`, dan membuka kembali untuk memeriksa kedua tipe aktivasi lagi. Ia mengumpulkan kontainer sebelum mengubahnya dan menggunakan kesetaraan referensi untuk menghindari memproses kontainer yang sama dua kali. Kueri presentasi mencakup slide biasa; untuk inventarisasi seluruh paket, juga secara eksplisit mengkueri master, tata letak, catatan, serta master catatan dan handout bila ada.

Laporan mencatat indeks slide berbasis satu dan [SlideId](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseslide/slideid/) bila tersedia. [ISlideComponent.Slide](https://reference.aspose.com/slides/id/net/aspose.slides/islidecomponent/slide/) menyediakan slide pemilik untuk kontainer yang didukung. Master, tata letak, dan catatan tidak memiliki indeks slide biasa dan diidentifikasi berdasarkan ruang lingkupnya. Kontainer bentuk dan kontainer format bagian teks diberi label terpisah; tipe kontainer lain mempertahankan nama tipe runtime mereka. Setiap kontainer mendapatkan ID lokal laporan sehingga dua aksinya dapat dikorelasikan.

Kebijakan aplikasi yang sengaja restriktif ini hanya memperbolehkan URL HTTPS absolut dan target slide internal yang valid. Ia menolak makro, program, aksi berkas, aksi slideshow lainnya, aksi tidak dikenal, dan skema URL lain. Penolakan ini adalah keputusan kebijakan, bukan keputusan keamanan Aspose.Slides. HTTPS saja tidak menjamin kepercayaan: tambahkan daftar izinkan host dan pemeriksaan lain untuk aplikasi Anda. Baik URL eksternal asli maupun yang dinormalisasi diperiksa. Contoh ini mengaudit metadata tanpa mengikuti tautan atau menjalankan aksi.

Untuk perbaikan, [HyperlinkManager](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) kontainer mendukung [SetExternalHyperlinkClick](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/), dan [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Di sini, tautan klik eksternal yang dilarang diganti dengan halaman landing HTTPS tetap; klik yang dilarang lainnya dan aksi mouse-over yang dilarang dihapus secara independen. Atur `replaceExternalClicks` ke `false` untuk menghapus semua pelanggaran kebijakan. Pilih halaman pengganti milik aplikasi sebelum penyebaran.

Flag ekspor laporan menggunakan kebijakan peninjauan PDF yang konservatif: beri tanda pada aksi mouse-over dan apa pun selain tautan eksternal atau lompat slide spesifik sebagai kemungkinan tidak didukung. Itu hanyalah petunjuk peninjauan, bukan uji kemampuan atau jaminan bahwa tautan yang tidak ditandai akan bertahan pada ekspor. Ekspor PDF dan HTML yang didukung [PDF](/slides/id/net/convert-powerpoint-to-pdf/) dan [HTML](/slides/id/net/convert-powerpoint-to-html/) dapat mempertahankan hyperlink, tergantung pada aksi, opsi ekspor, dan penampil. Gambar raster [images](/slides/id/net/convert-powerpoint-to-png/) dan [video](/slides/id/net/convert-powerpoint-to-video/) tidak dapat mempertahankan hyperlink interaktif; beri tanda pada setiap aksi saat mengaudit output tersebut.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

const bool replaceExternalClicks = true;
const string replacementUrl = "https://example.com/blocked-link";
using var presentation = new Presentation("hyperlink-audit-input.pptx");
var containers = CollectContainers(presentation);
var rows = new List<object>();

for (var index = 0; index < containers.Count; index++)
{
    var container = containers[index];
    AddRow(container.HyperlinkClick, "click", container, index + 1);
    AddRow(container.HyperlinkMouseOver, "mouse-over", container, index + 1);
}

var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
var json = JsonSerializer.Serialize(rows, jsonOptions);
File.WriteAllText("hyperlink-audit.json", json);

foreach (var container in containers)
{
    var click = container.HyperlinkClick;
    if (PolicyViolation(click) != null)
    {
        if (replaceExternalClicks && click.ActionType == HyperlinkActionType.Hyperlink)
        {
            container.HyperlinkManager.SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container.HyperlinkManager.RemoveHyperlinkClick();
        }
    }
    if (PolicyViolation(container.HyperlinkMouseOver) != null)
    {
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
}

presentation.Save("hyperlink-sanitized.pptx", SaveFormat.Pptx);
using var reopened = new Presentation("hyperlink-sanitized.pptx");
var remainingContainers = CollectContainers(reopened);
var violations = 0;
foreach (var container in remainingContainers)
{
    if (PolicyViolation(container.HyperlinkClick) != null) violations++;
    if (PolicyViolation(container.HyperlinkMouseOver) != null) violations++;
}
Console.WriteLine($"Audit rows: {rows.Count}; prohibited actions after reopening: {violations}");
if (violations != 0)
{
    Console.WriteLine("Verification failed: do not distribute the saved presentation.");
    Environment.ExitCode = 1;
}

void AddRow(IHyperlink? link, string activation, IHyperlinkContainer container, int containerId)
{
    if (link == null) return;
    var ownerSlide = (container as ISlideComponent)?.Slide;
    var targetSlide = link.TargetSlide;
    var violation = PolicyViolation(link);
    var ownerType = container is IShape ? "Shape" : container is IPortionFormat ? "Text portion" : container.GetType().Name;
    var ordinaryAction = link.ActionType == HyperlinkActionType.Hyperlink || link.ActionType == HyperlinkActionType.JumpSpecificSlide;
    rows.Add(new
    {
        ContainerId = containerId,
        SlideIndex = SlideIndex(presentation, ownerSlide),
        SlideId = ownerSlide?.SlideId,
        Scope = ownerSlide?.GetType().Name,
        OwnerType = ownerType,
        Activation = activation,
        ActionType = link.ActionType.ToString(),
        ExternalUrl = link.ExternalUrl,
        TargetSlideIndex = SlideIndex(presentation, targetSlide),
        TargetSlideId = targetSlide?.SlideId,
        Tooltip = link.Tooltip,
        OriginalExternalUrl = link.ExternalUrlOriginal != link.ExternalUrl ? link.ExternalUrlOriginal : null,
        PotentiallyUnsafe = violation != null,
        PolicyViolation = violation,
        TargetExport = "PDF",
        PotentiallyUnsupportedByExport = activation == "mouse-over" || !ordinaryAction
    });
}

static int? SlideIndex(IPresentation presentation, IBaseSlide? slide)
{
    for (var index = 0; index < presentation.Slides.Count; index++)
    {
        if (ReferenceEquals(presentation.Slides[index], slide)) return index + 1;
    }
    return null;
}

static string? PolicyViolation(IHyperlink? link)
{
    if (link == null) return null;
    if (link.ActionType == HyperlinkActionType.JumpSpecificSlide)
    {
        return link.TargetSlide == null ? "Missing target slide" : null;
    }
    if (link.ActionType != HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!IsHttps(link.ExternalUrl)) return "Normalized URL is not absolute HTTPS";
    var original = link.ExternalUrlOriginal;
    if (!string.IsNullOrEmpty(original) && !IsHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

static bool IsHttps(string? value)
{
    return Uri.TryCreate(value, UriKind.Absolute, out var uri) && uri.Scheme == Uri.UriSchemeHttps;
}

static List<IHyperlinkContainer> CollectContainers(IPresentation presentation)
{
    var found = new List<IHyperlinkContainer>();
    found.AddRange(presentation.HyperlinkQueries.GetAnyHyperlinks());
    foreach (var master in presentation.Masters) AddScope(master);
    foreach (var layout in presentation.LayoutSlides) AddScope(layout);
    foreach (var slide in presentation.Slides) AddScope(slide.NotesSlideManager.NotesSlide);
    AddScope(presentation.MasterNotesSlideManager.MasterNotesSlide);
    AddScope(presentation.MasterHandoutSlideManager.MasterHandoutSlide);
    return found.Distinct<IHyperlinkContainer>(ReferenceEqualityComparer.Instance).ToList();

    void AddScope(IBaseSlide? slide)
    {
        if (slide != null) found.AddRange(slide.HyperlinkQueries.GetAnyHyperlinks());
    }
}
```

Dengan input yang dibuat di atas, laporan berisi lima baris aksi. Tautan mouse-over berkas dan klik makro dihapus, sementara tautan HTTPS dan navigasi slide internal tetap. Verifikasi mencetak nol aksi yang dilarang. Input yang berisi URL klik eksternal yang dilarang juga menguji cabang penggantian. Kontainer dengan klik yang diizinkan dan mouse-over yang dilarang mempertahankan aksi kliknya.

Pembersihan selektif ini berbeda dari [RemoveAllHyperlinks](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), yang menghapus kedua tipe aktivasi di seluruh ruang lingkup yang dipilih tanpa memandang kebijakan. Verifikasi di sini hanya memeriksa aksi hyperlink; tidak menghapus proyek VBA tertanam, objek OLE, atau konten aktif lainnya, dan tidak memvalidasi berkas PDF atau HTML yang diekspor.

## **FAQ**

**Bagaimana saya dapat menautkan ke sebuah seksi atau slide pertamanya?**

Seksi di PowerPoint mengelompokkan slide, tetapi hyperlink internal menargetkan satu slide saja. Untuk membuat navigasi ke sebuah seksi, tautkan ke slide pertama dalam seksi tersebut.

**Bisakah saya menempelkan hyperlink pada elemen master slide sehingga berfungsi pada semua slide?**

Ya. Elemen master slide dan tata letak mendukung hyperlink. Tautan pada elemen tersebut tersedia selama presentasi pada slide yang menggunakan master atau tata letak yang bersangkutan.

**Apakah hyperlink akan dipertahankan saat mengekspor ke PDF, HTML, gambar, atau video?**

Ekspor PDF dan HTML yang didukung dapat mempertahankan hyperlink; gambar raster dan video tidak dapat. Lihat pertimbangan ekspor di [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).