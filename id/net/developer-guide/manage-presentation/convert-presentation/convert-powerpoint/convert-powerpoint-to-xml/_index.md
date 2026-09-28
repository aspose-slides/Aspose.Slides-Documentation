---
title: Mengonversi Presentasi PowerPoint ke XML di .NET
linktitle: PowerPoint ke XML
type: docs
weight: 145
url: /id/net/convert-powerpoint-to-xml/
keywords:
- mengonversi PowerPoint ke XML
- mengonversi presentasi ke XML
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
description: "Mengonversi presentasi PowerPoint dan OpenDocument menjadi file atau stream XML PowerPoint dalam C# dengan Aspose.Slides untuk .NET."
---
## **Gambaran Umum**

Aspose.Slides untuk .NET dapat mengonversi presentasi PowerPoint ke format PowerPoint XML Presentation. Output XML berguna ketika Anda memerlukan representasi berbasis teks untuk memeriksa struktur presentasi, memecahkan masalah dokumen yang dihasilkan, membandingkan output dalam pengujian otomatis, atau mengintegrasikan dengan alur kerja yang mengonsumsi XML bukan paket presentasi.

Gunakan metode [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) dengan nilai `Xml` dari enumerasi [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/). Anda dapat menulis hasilnya langsung ke file atau ke stream.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` menghasilkan PowerPoint XML Presentation. Itu tidak mengekstrak bagian Office Open XML individu yang disimpan di dalam paket PPTX. Jika Anda membutuhkan bagian paket PPTX yang tepat, seperti `ppt/presentation.xml` atau file XML slide individu, periksa paket PPTX itu sendiri.
{{% /alert %}}

## **Mengonversi Presentasi ke File XML**

Muat presentasi sumber dengan kelas [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) , lalu berikan jalur output dan `SaveFormat.Xml` ke [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Sumber dapat berupa format presentasi apa pun yang didukung untuk pemuatan, seperti PPT, PPTX, atau ODP.

Contoh berikut mengonversi presentasi PPTX menjadi file XML:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **Menulis Output XML ke Stream**

Gunakan overload stream dari [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) ketika XML harus tetap berada di memori atau diteruskan ke komponen lain, seperti layanan web, penyedia penyimpanan, atau pipeline pemrosesan XML. Contoh berikut menulis hasil ke [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) dan mengatur posisi kembali untuk membaca selanjutnya:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// Lewatkan xmlStream ke komponen berikutnya dalam alur kerja.
```

## **Membandingkan XML dengan Format Presentasi dan Ekspor**

Pilih format output sesuai cara hasil akan digunakan:

| Format | Output | Penggunaan umum |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | Memeriksa struktur, pemecahan masalah, membandingkan output yang dihasilkan, dan integrasi berbasis XML |
| PPT (`.ppt`) | File presentasi biner warisan | Kompatibilitas dengan alur kerja PowerPoint lama |
| PPTX (`.pptx`) | Paket Office Open XML yang berisi banyak bagian | Pengeditan PowerPoint reguler dan pertukaran presentasi |
| PDF atau TIFF | Halaman berlayout tetap atau gambar TIFF | Melihat, mencetak, dan mengarsipkan |
| PNG, JPEG, atau SVG | Representasi rendering dari satu slide | Thumbnail, pratinjau, dan aset gambar |
| HTML atau HTML5 | Output presentasi berorientasi web | Melihat di browser dan penerbitan web |

Berbeda dengan PPT dan PPTX, output XML terutama ditujukan untuk inspeksi dan alur kerja berbasis data. Berbeda dengan PDF, TIFF, HTML, dan format gambar slide, XML mewakili data presentasi bukan rendering slide sebagai halaman atau aset visual. Tabel [supported file formats](/slides/id/net/supported-file-formats/) mencantumkan setiap format yang dapat dimuat, diimpor, disimpan, atau dirender oleh Aspose.Slides.

## **FAQ**

**Apakah `SaveFormat.Xml` sama dengan menyimpan file PPTX?**

Tidak. PPTX adalah paket yang berisi banyak bagian Office Open XML, sedangkan `SaveFormat.Xml` menghasilkan file PowerPoint XML Presentation.

**Apakah saya dapat menyimpan output XML tanpa membuat file di disk?**

Ya. Berikan stream yang dapat ditulis ke [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Misalnya, gunakan [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) untuk pemrosesan dalam memori.

**Apakah Aspose.Slides dapat memuat file XML yang diekspor kembali?**

Ya. Berikan file XML atau stream ke konstruktor [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) kemudian mengembalikan `SourceFormat.Xml`. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) melaporkan `LoadFormat.Unknown` untuk format ini, sehingga jangan gunakan nilai tersebut untuk menentukan apakah file XML dapat dibuka.

**Apakah konversi XML merender setiap slide sebagai halaman atau gambar?**

Tidak. Konversi XML menulis data presentasi terstruktur. Gunakan PDF atau TIFF untuk output berorientasi halaman, atau PNG, JPEG, dan SVG untuk gambar slide individu.