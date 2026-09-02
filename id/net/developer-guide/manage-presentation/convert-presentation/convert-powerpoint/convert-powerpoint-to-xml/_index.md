---
title: Konversi Presentasi PowerPoint ke XML di .NET
linktitle: PowerPoint ke XML
type: docs
weight: 145
url: /id/net/convert-powerpoint-to-xml/
keywords:
- konversi PowerPoint ke XML
- konversi presentasi ke XML
- PPT ke XML
- PPTX ke XML
- ODP ke XML
- Presentasi XML PowerPoint
- SaveFormat.Xml
- simpan presentasi sebagai XML
- ekspor presentasi ke XML
- stream XML
- .NET
- C#
- Aspose.Slides
description: "Konversi presentasi PowerPoint dan OpenDocument ke file atau stream XML PowerPoint dalam C# dengan Aspose.Slides untuk .NET."
---
## **Gambaran Umum**

Aspose.Slides untuk .NET dapat mengonversi presentasi PowerPoint ke format PowerPoint XML Presentation. Output XML berguna ketika Anda memerlukan representasi berbasis teks untuk memeriksa struktur presentasi, memecahkan masalah dokumen yang dihasilkan, membandingkan output dalam tes otomatis, atau mengintegrasikan dengan alur kerja yang mengonsumsi XML alih‑alih paket presentasi.

Gunakan metode [Presentation.Save](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/save/) dengan nilai `Xml` dari enumerasi [SaveFormat](https://reference.aspose.com/slides/id/net/aspose.slides.export/saveformat/). Anda dapat menulis hasilnya langsung ke file atau ke stream.

{{% alert color="info" title="Note" %}}

`SaveFormat.Xml` membuat PowerPoint XML Presentation. Ia tidak mengekstrak bagian Office Open XML individual yang disimpan di dalam paket PPTX. Jika Anda memerlukan bagian paket PPTX yang tepat, seperti `ppt/presentation.xml` atau file XML slide individual, periksa paket PPTX itu sendiri.

{{% /alert %}}

## **Mengonversi Presentasi ke File XML**

Muat presentasi sumber dengan kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/), lalu berikan jalur output dan `SaveFormat.Xml` ke [Presentation.Save](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/save/). Sumber dapat berupa format presentasi apa pun yang didukung untuk pemuatan, seperti PPT, PPTX, atau ODP.

Contoh berikut mengonversi presentasi PPTX ke file XML:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **Menulis Output XML ke Stream**

Gunakan overload stream dari [Presentation.Save](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/save/) ketika XML harus tetap berada di memori atau dilewatkan ke komponen lain, seperti layanan web, penyedia penyimpanan, atau pipeline pemrosesan XML. Contoh berikut menulis hasil ke [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) dan memutar kembali untuk pembacaan selanjutnya:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// Kirim xmlStream ke komponen berikutnya dalam alur kerja.
```

## **Membandingkan XML dengan Format Presentasi dan Ekspor**

Pilih format output sesuai cara hasil akan digunakan:

| Format | Output | Penggunaan umum |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | Memeriksa struktur, pemecahan masalah, perbandingan output yang dihasilkan, dan integrasi berbasis XML |
| PPT (`.ppt`) | File presentasi biner lama | Kompatibilitas dengan alur kerja PowerPoint versi lama |
| PPTX (`.pptx`) | Paket Office Open XML yang berisi banyak bagian | Pengeditan PowerPoint reguler dan pertukaran presentasi |
| PDF atau TIFF | Halaman berlayar tetap atau gambar multi‑halaman | Melihat, mencetak, dan mengarsipkan |
| PNG, JPEG, atau SVG | Representasi render dari satu slide | Thumbnail, pratinjau, dan aset gambar |
| HTML atau HTML5 | Output presentasi berorientasi web | Penampilan di browser dan penerbitan web |

Berbeda dengan PPT dan PPTX, output XML terutama ditujukan untuk inspeksi dan alur kerja berbasis data. Berbeda dengan PDF, TIFF, HTML, dan format gambar slide, ia mewakili data presentasi bukan merender slide sebagai halaman atau aset visual. Tabel [format file yang didukung](/slides/id/net/supported-file-formats/) mencantumkan PowerPoint XML Presentation sebagai format hanya‑simpan, jadi jangan gunakan saat alur kerja harus memuat file yang diekspor kembali ke Aspose.Slides untuk pengeditan lanjutan.

## **FAQ**

**Apakah `SaveFormat.Xml` sama dengan menyimpan file PPTX?**

Tidak. PPTX adalah paket yang berisi banyak bagian Office Open XML, sedangkan `SaveFormat.Xml` membuat file PowerPoint XML Presentation.

**Bisakah saya menyimpan output XML tanpa membuat file di disk?**

Ya. Berikan stream yang dapat ditulis ke [Presentation.Save](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/save/). Misalnya, gunakan [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) untuk pemrosesan dalam memori.

**Apakah Aspose.Slides dapat memuat kembali file XML yang diekspor?**

Tidak. PowerPoint XML Presentation saat ini hanya didukung untuk penyimpanan, bukan untuk pemuatan. Gunakan PPTX atau format presentasi lain yang didukung ketika diperlukan pengeditan bolak‑balik.

**Apakah konversi XML merender setiap slide sebagai halaman atau gambar?**

Tidak. Konversi XML menulis data presentasi yang terstruktur. Gunakan PDF atau TIFF untuk output berorientasi halaman, atau PNG, JPEG, dan SVG untuk gambar slide individual.