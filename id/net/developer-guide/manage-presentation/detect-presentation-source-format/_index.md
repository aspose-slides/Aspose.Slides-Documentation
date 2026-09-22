---
title: Tentukan Format Presentasi Asli di .NET
linktitle: Format Sumber
type: docs
weight: 35
url: /id/net/detect-presentation-source-format/
keywords:
- format sumber
- deteksi format presentasi
- PowerPoint
- OpenDocument
- presentasi
- PPT
- PPTX
- C#
- .NET
- Aspose.Slides
description: "Baca format asli dari presentasi yang dimuat dalam C# dengan Aspose.Slides untuk .NET, bandingkan API deteksi, dan tangani file, stream, serta format legacy."
---
## **Gambaran Umum**

Setelah memuat sebuah presentasi, baca properti read-only [Presentation.SourceFormat](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/sourceformat/) untuk menentukan format aslinya. Properti ini juga tersedia melalui [IPresentation.SourceFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentation/sourceformat/). Gunakan properti ini ketika pemrosesan selanjutnya bergantung pada format dari mana instance saat ini dimuat.

Source format berbeda dari [SaveFormat](https://reference.aspose.com/slides/id/net/aspose.slides.export/saveformat/) yang dipilih untuk file output. Menyimpan ke format lain tidak mengubah source format dari instance yang ada.

## **Baca Source Format dari Sebuah File**

Contoh ini memerlukan file `sample.pptx` yang sudah ada. Ia memuat file tersebut dan memilih kebijakan pemrosesan aplikasi menggunakan [Presentation.SourceFormat](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/sourceformat/), bukan nama file. Ubah jalur input untuk mencoba format lain. Contoh ini mencetak kebijakan yang dipilih; ganti pesan-pesan tersebut dengan logika aplikasi Anda.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

switch (presentation.SourceFormat)
{
    case SourceFormat.Ppt:
    case SourceFormat.Pps:
    case SourceFormat.Pot:
        Console.WriteLine("Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat.Pptx:
        Console.WriteLine("Use the standard PPTX processing policy.");
        break;
    default:
        Console.WriteLine($"Use the general policy for {presentation.SourceFormat}.");
        break;
}
```

## **Kenali Nilai-nilai yang Didukung**

Enumerasi [SourceFormat](https://reference.aspose.com/slides/id/net/aspose.slides/sourceformat/) membedakan format presentasi berikut. Ekstensi di bawah ini adalah ekstensi konvensional, bukan rekonstruksi nama file asli.

| Nilai SourceFormat | Ekstensi | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | presentasi PowerPoint 97–2003 |
| `Pptx` | `.pptx` | presentasi Office Open XML |
| `Pptm` | `.pptm` | presentasi Office Open XML dengan macro |
| `Pps` | `.pps` | tampilan slide PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | tampilan slide Office Open XML |
| `Ppsm` | `.ppsm` | tampilan slide Office Open XML dengan macro |
| `Pot` | `.pot` | template PowerPoint 97–2003 |
| `Potx` | `.potx` | template Office Open XML |
| `Potm` | `.potm` | template Office Open XML dengan macro |
| `Odp` | `.odp` | presentasi OpenDocument |
| `Otp` | `.otp` | template presentasi OpenDocument |
| `Fodp` | `.fodp` | presentasi Flat XML ODF |
| `Xml` | `.xml` | presentasi PowerPoint XML |

## **Baca Source Format dari Stream**

Contoh ini memerlukan file `sample.pps` yang sudah ada. Membaca byte‑byte file tersebut ke dalam memory stream mensimulasikan input yang diterima tanpa nama file, seperti nilai database atau array byte yang di‑upload. Konstruktor [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) menerima hanya stream.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var bytes = File.ReadAllBytes("sample.pps");
using var stream = new MemoryStream(bytes);
using var presentation = new Presentation(stream);

Console.WriteLine($"Source format: {presentation.SourceFormat}");
```

PPT, PPS, dan POT menggunakan format biner yang sama. Saat memuat menggunakan jalur file, ekstensi dapat membantu membedakan tampilan slide atau template. Tanpa nama file, konten legacy PPS dan POT dapat dilaporkan sebagai `SourceFormat.Ppt`; contoh PPS di atas melaporkan `Ppt`.

Jika aplikasi Anda harus mempertahankan perbedaan tersebut, simpan nama file asli atau metadata subtipe secara terpisah. Ekstensi merupakan petunjuk yang berguna untuk subtipe legacy ini, tetapi tidak boleh menjadi satu‑satunya dasar untuk mengidentifikasi konten presentasi apa pun.

## **Bandingkan Deteksi Sebelum dan Sesudah Memuat**

Gunakan [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/id/net/aspose.slides/presentationfactory/getpresentationinfo/) dan [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentationinfo/loadformat/) ketika Anda perlu memeriksa file sebelum memuat model objek presentasi lengkapnya. Gunakan [Presentation.SourceFormat](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/sourceformat/) ketika instance sudah ada.

Contoh ini memerlukan `sample.pptx` dan mencetak `Pptx` untuk kedua pemeriksaan. Dalam produksi, pilih API yang sesuai dengan tahapan pemrosesan Anda; presentasi yang sudah dimuat tidak memerlukan inspeksi kedua semata‑mata untuk memperoleh source format‑nya.

```csharp
using System;
using Aspose.Slides;

var path = "sample.pptx";
var information = PresentationFactory.Instance.GetPresentationInfo(path);
Console.WriteLine($"Before loading: {information.LoadFormat}");

using var presentation = new Presentation(path);
Console.WriteLine($"After loading: {presentation.SourceFormat}");
```

Hasilnya memiliki tipe enumerasi yang berbeda: [LoadFormat](https://reference.aspose.com/slides/id/net/aspose.slides/loadformat/) dan [SourceFormat](https://reference.aspose.com/slides/id/net/aspose.slides/sourceformat/). Jangan bandingkan keduanya dengan meng‑cast nilai numeriknya atau mengasumsikan setiap format memiliki hasil deteksi yang identik. Pada pemeriksaan simpan‑dan‑buka‑ulang yang dijelaskan di bawah, PowerPoint XML dilaporkan sebagai `LoadFormat.Unknown` sebelum pemuatan dan `SourceFormat.Xml` setelah pemuatan.

## **Pisahkan Source dan Output Format**

Contoh ini memerlukan `sample.pptx` dan menulis `converted.odp`. Ia mencetak `Pptx` baik sebelum maupun setelah menyimpan instance asli. Hanya instance baru yang dimuat dari output ODP yang melaporkan `Odp`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
Console.WriteLine($"Before saving: {presentation.SourceFormat}");

presentation.Save("converted.odp", SaveFormat.Odp);
Console.WriteLine($"After saving: {presentation.SourceFormat}");

using var reopened = new Presentation("converted.odp");
Console.WriteLine($"Reopened output: {reopened.SourceFormat}");
```

Sebuah presentasi yang dibuat dari awal dengan `new Presentation()` melaporkan `SourceFormat.Pptx`. Ia tidak memiliki file input: ini adalah nilai default untuk instance yang baru dibuat, bukan bukti bahwa file PPTX dimuat. Lacak apakah aplikasi Anda membuat atau memuat instance secara terpisah jika perbedaan tersebut penting.

## **Petakan Source Format ke Ekstensi**

Contoh berikut memerlukan `sample.pptx`. Ia memetakan setiap nilai [SourceFormat](https://reference.aspose.com/slides/id/net/aspose.slides/sourceformat/) yang saat ini didukung ke ekstensi konvensional, tanpa mengurai nama file input. Mekanisme fallback menghindari penetapan ekstensi secara diam‑diam pada nilai yang tidak dikenali.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var extension = presentation.SourceFormat switch
{
    SourceFormat.Ppt => ".ppt",
    SourceFormat.Pptx => ".pptx",
    SourceFormat.Pptm => ".pptm",
    SourceFormat.Pps => ".pps",
    SourceFormat.Ppsx => ".ppsx",
    SourceFormat.Ppsm => ".ppsm",
    SourceFormat.Pot => ".pot",
    SourceFormat.Potx => ".potx",
    SourceFormat.Potm => ".potm",
    SourceFormat.Odp => ".odp",
    SourceFormat.Otp => ".otp",
    SourceFormat.Fodp => ".fodp",
    SourceFormat.Xml => ".xml",
    _ => null
};

Console.WriteLine(extension ?? "No extension mapping is available.");
```

Pemeta ini tidak mengonversi file atau memulihkan subtipe legacy PPS/POT yang hilang selama pemuatan stream. Untuk penyimpanan sebenarnya, pilih [SaveFormat](https://reference.aspose.com/slides/id/net/aspose.slides.export/saveformat/) secara eksplisit, atau gunakan konversi yang ditunjukkan dalam [Save Presentations in Their Original Format](/slides/id/net/save-presentation/#save-presentations-in-their-original-format).

## **Verifikasi Format dengan Menyimpan dan Membuka Kembali**

Contoh mandiri ini membuat sebuah presentasi dan menulis tiga file di direktori kerja, menimpa file dengan nama yang sama. Ia membuka kembali setiap output baik melalui jalur maupun melalui memory stream. Untuk PPTX dan ODP, kedua cara melaporkan format yang disimpan. Untuk PPS, pemuatan via jalur melaporkan `Pps`, sementara pemuatan byte yang sama tanpa nama file melaporkan `Ppt`.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var formats = new[] { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };

foreach (var format in formats)
{
    var path = $"roundtrip.{format.ToString().ToLowerInvariant()}";
    presentation.Save(path, format);

    using var fromFile = new Presentation(path);
    var bytes = File.ReadAllBytes(path);
    using var stream = new MemoryStream(bytes);
    using var fromStream = new Presentation(stream);

    Console.WriteLine($"{format}: file={fromFile.SourceFormat}, stream={fromStream.SourceFormat}");
}
```

| Format Disimpan | SourceFormat dari jalur file | SourceFormat dari stream tanpa nama |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` masing‑masing | Sama seperti jalur file |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` masing‑masing | Sama seperti jalur file |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` masing‑masing | Sama seperti jalur file |
| ODP, OTP | `Odp`, `Otp` masing‑masing | Sama seperti jalur file |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Dalam pemeriksaan ini, satu‑satunya normalisasi source‑format adalah PPS/POT menjadi `Ppt` untuk stream tanpa nama. Tabel menggambarkan identifikasi format, bukan preservasi setiap fitur presentasi selama konversi.

## **FAQ**

**Apakah menyimpan ke ODP mengubah source format dari presentasi yang dimuat dari PPTX?**

Tidak. Instance yang ada tetap melaporkan `Pptx`. Instance yang dimuat dari file ODP yang disimpan melaporkan `Odp`.

**Dapatkah sebuah stream selalu membedakan presentasi legacy, tampilan slide, dan template?**

Tidak. PPT, PPS, dan POT berbagi format biner. Simpan nama file atau metadata subtipe secara terpisah ketika perbedaan tersebut diperlukan.

**API mana yang harus saya gunakan jika presentasi sudah dimuat?**

Baca [Presentation.SourceFormat](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/sourceformat/). Gunakan [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/id/net/aspose.slides/presentationfactory/getpresentationinfo/) untuk inspeksi sebelum pemuatan.