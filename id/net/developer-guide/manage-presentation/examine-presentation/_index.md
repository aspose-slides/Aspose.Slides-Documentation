---
title: Mengambil dan Memperbarui Informasi Presentasi di .NET
linktitle: Informasi Presentasi
type: docs
weight: 30
url: /id/net/examine-presentation/
keywords:
- format presentasi
- properti presentasi
- properti dokumen
- mendapatkan properti
- membaca properti
- mengubah properti
- memodifikasi properti
- memperbarui properti
- memeriksa PPTX
- memeriksa PPT
- memeriksa ODP
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Jelajahi slide, struktur, dan metadata dalam presentasi PowerPoint dan OpenDocument menggunakan .NET untuk wawasan lebih cepat dan audit konten yang lebih cerdas."
---
## **Ikhtisar**

Aspose.Slides dapat mengidentifikasi format presentasi dan membaca metadata dokumen tanpa membuat model objek presentasi yang lengkap. Ini berguna ketika Anda perlu mengklasifikasikan file, membuat inventaris, atau memeriksa properti sebelum memutuskan apakah akan memuat dan memproses konten presentasi.

Artikel ini menunjukkan inspeksi ringan melalui [PresentationFactory](https://reference.aspose.com/slides/id/net/aspose.slides/presentationfactory/) dan [IPresentationInfo](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentationinfo/), serta pembaruan terarah melalui [IDocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/idocumentproperties/).

## **Periksa Format Presentasi**

Gunakan [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/id/net/aspose.slides/presentationfactory/getpresentationinfo/) untuk memeriksa file tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/). Properti [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentationinfo/loadformat/) melaporkan format yang terdeteksi, seperti PPTX, PPT, atau ODP.

```csharp
using System;
using Aspose.Slides;

var fileNames = new[] { "pres.pptx", "pres.ppt", "pres.odp" };

foreach (var fileName in fileNames)
{
    var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(fileName);
    Console.WriteLine($"{fileName}: {presentationInfo.LoadFormat}");
}
```

## **Buat Inventaris Presentasi Ringan**

Ketika Anda memproses banyak file presentasi, Anda mungkin memerlukan inventaris kompak untuk validasi, pengindeksan, atau sistem manajemen dokumen. Dalam skenario ini, gunakan [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/id/net/aspose.slides/presentationfactory/getpresentationinfo/) untuk memperoleh objek [IPresentationInfo](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentationinfo/), lalu panggil [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentationinfo/readdocumentproperties/) untuk membaca metadata dokumen. Pendekatan ini tidak membuat instance [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) atau mengharuskan Anda menelusuri model objek presentasi yang lengkap.

Properti yang diperluas yang diekspos oleh [IDocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/idocumentproperties/) menyediakan nilai inventaris berikut:

| Properti | Nilai inventaris |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/id/net/aspose.slides/idocumentproperties/slides/id/) | Jumlah total slide. |
| [HiddenSlides](https://reference.aspose.com/slides/id/net/aspose.slides/idocumentproperties/hiddenslides/) | Jumlah slide tersembunyi. |
| [Notes](https://reference.aspose.com/slides/id/net/aspose.slides/idocumentproperties/notes/) | Jumlah slide yang berisi catatan. |
| [Paragraphs](https://reference.aspose.com/slides/id/net/aspose.slides/idocumentproperties/paragraphs/) | Jumlah total paragraf, bila tersedia. |
| [Words](https://reference.aspose.com/slides/id/net/aspose.slides/idocumentproperties/words/) | Jumlah total kata. |
| [MultimediaClips](https://reference.aspose.com/slides/id/net/aspose.slides/idocumentproperties/multimediaclips/) | Jumlah total klip audio dan video. |

Contoh berikut membaca nilai‑nilai ini tanpa membuat objek [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) dan mencetak inventaris kompak. Ia juga menggabungkan [HeadingPairs](https://reference.aspose.com/slides/id/net/aspose.slides/idocumentproperties/headingpairs/) dengan [TitlesOfParts](https://reference.aspose.com/slides/id/net/aspose.slides/idocumentproperties/titlesofparts/) untuk menampilkan grup konten seperti font, tema, dan judul slide.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var filePath = "sample.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);
var documentProperties = presentationInfo.ReadDocumentProperties();

Console.WriteLine($"File: {Path.GetFileName(filePath)}");
Console.WriteLine($"Format: {presentationInfo.LoadFormat}");
Console.WriteLine($"Title: {documentProperties.Title}");
Console.WriteLine($"Author: {documentProperties.Author}");
Console.WriteLine("Statistics:");
Console.WriteLine($"  Slides: {documentProperties.Slides}");
Console.WriteLine($"  Hidden slides: {documentProperties.HiddenSlides}");
Console.WriteLine($"  Slides with notes: {documentProperties.Notes}");
Console.WriteLine($"  Paragraphs: {documentProperties.Paragraphs}");
Console.WriteLine($"  Words: {documentProperties.Words}");
Console.WriteLine($"  Multimedia clips: {documentProperties.MultimediaClips}");

var headingPairs = documentProperties.HeadingPairs ?? Array.Empty<IHeadingPair>();
var titlesOfParts = documentProperties.TitlesOfParts ?? Array.Empty<string>();
var partIndex = 0;

if (headingPairs.Length == 0 || titlesOfParts.Length == 0)
{
    Console.WriteLine("Content groups: not available");
}
else
{
    Console.WriteLine("Content groups:");

    foreach (var headingPair in headingPairs)
    {
        Console.WriteLine($"  {headingPair.Name} ({headingPair.Count})");

        for (var partOffset = 0; partOffset < headingPair.Count && partIndex < titlesOfParts.Length; partOffset++)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.Length)
    {
        Console.WriteLine("  Other parts:");

        while (partIndex < titlesOfParts.Length)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }
}
```

Setiap [IHeadingPair](https://reference.aspose.com/slides/id/net/aspose.slides/iheadingpair/) menyediakan nama grup dan jumlah item dalam grup tersebut. [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/id/net/aspose.slides/idocumentproperties/titlesofparts/) adalah array datar yang terurut, sehingga konsumsi jumlah judul berurutan yang ditentukan oleh setiap heading pair.

### **Metadata yang Disimpan dan Batasan Format**

Properti inventaris yang dikembalikan oleh [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentationinfo/readdocumentproperties/) mencerminkan metadata yang tersedia dalam dokumen sumber. Aspose.Slides tidak memuat dan menelusuri model objek presentasi untuk menghitung ulang nilai‑nilai ini pada pemanggilan ini. Properti yang tidak ada diwakili oleh nilai default, dan nilai yang disimpan mungkin usang jika aplikasi yang terakhir menyimpan file tidak memperbarui properti dokumennya.

- **PPTX:** Format ini menyediakan properti dokumen yang diperluas untuk hitungan slide, catatan, slide tersembunyi, paragraf, kata, dan multimedia, serta heading pairs dan judul bagian. Ketersediaannya bergantung pada properti yang ditulis oleh pembuat dokumen.
- **PPT:** Format biner dapat menyimpan properti ringkasan dokumen yang bersesuaian. Jika sebuah properti tidak ada atau tidak diperbarui oleh pembuat dokumen, Aspose.Slides mengembalikan nilai yang disimpan atau nilai default alih‑alih menghitungnya dari slide.
- **ODP:** Metadata OpenDocument menyediakan statistik dokumen umum, seperti hitungan halaman, paragraf, dan kata, tetapi nilai‑nilai ini tidak selalu berkorespondensi dengan setiap properti tambahan khusus PowerPoint. Metadata untuk slide tersembunyi, slide catatan, multimedia, heading‑pair, dan judul bagian mungkin tidak tersedia, dan properti inventaris dapat mengembalikan nilai default. Jangan menganggap nilai nol atau array kosong sebagai bukti otoritatif bahwa konten yang bersangkutan tidak ada.

Gunakan pendekatan metadata ringan untuk inventaris dan pemeriksaan awal. Muat presentasi dan inspeksi model objeknya yang aktif ketika hasil harus mencerminkan perubahan dalam memori atau ketika Anda perlu memverifikasi konten presentasi yang sebenarnya.

## **Perbarui Properti Presentasi**

Properti yang dikembalikan oleh [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentationinfo/readdocumentproperties/) juga dapat diubah tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/). Terapkan perubahan dengan [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentationinfo/updatedocumentproperties/), lalu tulis presentasi yang terikat dengan [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentationinfo/writebindedpresentation/).

Gambar berikut menunjukkan properti dokumen asli dari presentasi PowerPoint:

![Properti dokumen asli dari presentasi PowerPoint](input_properties.png)

Contoh berikut mengubah judul dan waktu terakhir disimpan serta menulis hasilnya ke file baru:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var sourceFile = "sample.pptx";
var outputFile = "sample_with_updated_properties.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(sourceFile);
var documentProperties = presentationInfo.ReadDocumentProperties();

documentProperties.Title = "Quarterly sales report";
documentProperties.LastSavedTime = DateTime.UtcNow;

presentationInfo.UpdateDocumentProperties(documentProperties);
using var outputStream = File.Create(outputFile);
presentationInfo.WriteBindedPresentation(outputStream);
```

Gambar berikut menunjukkan properti dokumen yang diperbarui dari presentasi PowerPoint:

![Properti dokumen yang diperbarui dari presentasi PowerPoint](output_properties.png)

## **Tautan Berguna**

Untuk pemeriksaan keamanan terkait dan pengaturan perlindungan, lihat artikel berikut:

- [Presentasi yang Dilindungi Kata Sandi](/slides/id/net/password-protected-presentation/)
- [Presentasi yang Dilindungi Penulisan](/slides/id/net/write-protected-presentation/)

## **FAQ**

**Bagaimana saya dapat memeriksa apakah font disematkan dan font apa saja yang disematkan?**

Muat presentasi dan gunakan [Presentation.FontsManager](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/fontsmanager/). Panggil [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/id/net/aspose.slides/fontsmanager/getembeddedfonts/) untuk memperoleh font yang disematkan dan [FontsManager.GetFonts](https://reference.aspose.com/slides/id/net/aspose.slides/fontsmanager/getfonts/) untuk memperoleh font yang digunakan oleh presentasi. Bandingkan kedua hasil untuk menemukan font yang diperlukan untuk rendering tetapi tidak disematkan.

**Bagaimana saya dapat dengan cepat mengetahui apakah file memiliki slide tersembunyi dan berapa banyak?**

Ketika metadata dokumen yang disimpan cukup, baca [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/id/net/aspose.slides/idocumentproperties/hiddenslides/) melalui [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/id/net/aspose.slides/presentationfactory/getpresentationinfo/) dan [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentationinfo/readdocumentproperties/). Ini cocok untuk inventaris ringan. Jika presentasi telah dimodifikasi dalam memori, metadata yang disimpan mungkin hilang atau usang, atau Anda perlu memverifikasi nilai hidup, iterasi melalui [Presentation.Slides](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/slides/id/) dan periksa properti [Slide.Hidden](https://reference.aspose.com/slides/id/net/aspose.slides/slide/hidden/) setiap slide.

**Bisakah saya mendeteksi apakah ukuran dan orientasi slide khusus digunakan, dan apakah berbeda dari default?**

Ya. Muat presentasi dan baca [Presentation.SlideSize](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/slidesize/). Periksa [ISlideSize.Type](https://reference.aspose.com/slides/id/net/aspose.slides/islidesize/type/), [ISlideSize.Size](https://reference.aspose.com/slides/id/net/aspose.slides/islidesize/size/), dan [ISlideSize.Orientation](https://reference.aspose.com/slides/id/net/aspose.slides/islidesize/orientation/) untuk membandingkan pengaturan saat ini dengan preset dan dimensi yang diharapkan.

**Apakah ada cara cepat untuk melihat apakah chart merujuk ke sumber data eksternal?**

Ya. Temukan setiap [Chart](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chart/) dan periksa [ChartData.DataSourceType](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chartdata/datasourcetype/). Untuk buku kerja eksternal, baca [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chartdata/externalworkbookpath/). Jenis sumber data dan jalur mengidentifikasi referensi eksternal, tetapi memverifikasi apakah target tersedia memerlukan pemeriksaan sumber daya terpisah.

**Bagaimana saya dapat menilai slide 'berat' yang dapat memperlambat rendering atau ekspor PDF?**

Tidak ada satu properti kompleksitas tunggal. Telusuri [Presentation.Slides](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/slides/id/) dan koleksi [IBaseSlide.Shapes](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseslide/shapes/) tiap slide. Gunakan jumlah shape serta keberadaan gambar besar, efek, animasi, atau multimedia sebagai sinyal penyaringan, dan ukurlah render atau ekspor representatif sebelum menganggap slide sebagai bottleneck kinerja yang terkonfirmasi.