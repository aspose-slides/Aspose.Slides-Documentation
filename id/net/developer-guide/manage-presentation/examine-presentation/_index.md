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
- dapatkan properti
- baca properti
- ubah properti
- modifikasi properti
- perbarui properti
- periksa PPTX
- periksa PPT
- periksa ODP
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Jelajahi slide, struktur, dan metadata dalam presentasi PowerPoint dan OpenDocument menggunakan .NET untuk wawasan lebih cepat dan audit konten yang lebih cerdas."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara memeriksa informasi presentasi di Aspose.Slides. Artikel ini menjelaskan cara menentukan format saat ini dari sebuah presentasi tanpa memuat seluruh file, membaca properti dokumennya, dan memperbarui properti tersebut bila diperlukan.

Contoh-contoh didasarkan pada API [PresentationInfo](https://reference.aspose.com/slides/id/net/aspose.slides/presentationinfo/) dan [DocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/documentproperties/) serta mendemonstrasikan operasi tipikal untuk bekerja dengan metadata presentasi.

## **Periksa Format Presentasi**

Sebelum mengerjakan sebuah presentasi, Anda mungkin ingin mengetahui format (PPT, PPTX, ODP, dan lain‑lain) yang sedang digunakan oleh presentasi tersebut.

Anda dapat memeriksa format presentasi tanpa memuat presentasi. Lihat kode C# berikut:

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **Dapatkan Properti Presentasi**

Kode C# ini menunjukkan cara mendapatkan properti presentasi (informasi tentang presentasi):

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ..
```

Anda mungkin ingin melihat [properti dalam DocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/documentproperties/#properties) class.

## **Perbarui Properti Presentasi**

Aspose.Slides menyediakan metode [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) yang memungkinkan Anda membuat perubahan pada properti presentasi.

Misalkan kita memiliki sebuah presentasi PowerPoint dengan properti dokumen seperti di bawah ini.

![Properti dokumen asli dari presentasi PowerPoint](input_properties.png)

Contoh kode ini menunjukkan cara mengedit beberapa properti presentasi:

```c#
using Aspose.Slides;

string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

Hasil perubahan properti dokumen ditampilkan di bawah.

![Properti dokumen yang diubah dari presentasi PowerPoint](output_properties.png)

## **Tautan Berguna**

Untuk mendapatkan informasi lebih lanjut tentang presentasi dan atribut keamanannya, Anda mungkin menemukan tautan ini berguna:

- [Presentasi dengan Perlindungan Kata Sandi](/slides/id/net/password-protected-presentation/)
- [Presentasi dengan Perlindungan Penulisan](/slides/id/net/write-protected-presentation/)

## **FAQ**

**Bagaimana saya dapat memeriksa apakah font disematkan dan font mana yang disematkan?**

Cari [informasi font yang disematkan](https://reference.aspose.com/slides/id/net/aspose.slides/fontsmanager/getembeddedfonts/) di tingkat presentasi, lalu bandingkan entri tersebut dengan kumpulan [font yang benar-benar digunakan di seluruh konten](https://reference.aspose.com/slides/id/net/aspose.slides/fontsmanager/getfonts/) untuk mengidentifikasi font mana yang kritis untuk rendering.

**Bagaimana saya dapat dengan cepat mengetahui apakah file memiliki slide tersembunyi dan berapa banyak?**

Iterasi melalui [koleksi slide](https://reference.aspose.com/slides/id/net/aspose.slides/slidecollection/) dan inspeksi setiap [bendera visibilitas](https://reference.aspose.com/slides/id/net/aspose.slides/slide/hidden/) slide.

**Apakah saya dapat mendeteksi apakah ukuran dan orientasi slide khusus digunakan, dan apakah berbeda dari default?**

Ya. Bandingkan [ukuran slide](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/slidesize/) dan orientasi saat ini dengan preset standar; ini membantu memperkirakan perilaku untuk pencetakan dan ekspor.

**Apakah ada cara cepat untuk melihat apakah chart merujuk ke sumber data eksternal?**

Ya. Telusuri semua [chart](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chart/), periksa [sumber data](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chartdata/datasourcetype/), dan catat apakah data bersifat internal atau berbasis tautan, termasuk tautan yang rusak.

**Bagaimana saya dapat menilai slide 'berat' yang mungkin memperlambat rendering atau ekspor PDF?**

Untuk setiap slide, hitung jumlah objek dan cari gambar besar, transparansi, bayangan, animasi, serta multimedia; berikan skor kompleksitas kasar untuk menandai potensi hotspot kinerja.