---
title: Kelola Aksesibilitas Presentasi di .NET
linktitle: Aksesibilitas Presentasi
type: docs
weight: 30
url: /id/net/presentation-accessibility/
keywords:
- aksesibilitas presentasi
- teks alternatif
- judul teks alternatif
- deskripsi teks alternatif
- tandai sebagai dekoratif
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Otomatisasi pemeriksaan aksesibilitas presentasi pada file PPT, PPTX, dan ODP dengan Aspose.Slides untuk .NET—tingkatkan pengalaman pembaca layar dan tingkatkan kepatuhan."
---
## **Pendahuluan**

Teks alternatif membantu orang yang menggunakan teknologi bantu memahami makna gambar, diagram, dan bentuk informatif lainnya. Artikel ini menjelaskan cara membaca dan memperbarui judul serta deskripsi teks alternatif dengan Aspose.Slides untuk .NET, membedakan deskripsi aksesibilitas dari nama bentuk yang digunakan dalam kode, dan memeriksa apakah sebuah bentuk ditandai sebagai dekoratif.

Fitur-fitur ini mendukung aksesibilitas presentasi, namun tidak menjaminnya. Urutan membaca, kontras warna, keterbacaan teks, dan persyaratan aksesibilitas lainnya juga perlu ditinjau.

## **Kelola Judul dan Deskripsi Teks Alternatif**

Gunakan teks alternatif untuk menjelaskan makna gambar, diagram, dan bentuk informatif lainnya kepada orang yang tidak dapat melihatnya. Properti berikut memiliki tujuan yang berbeda:

| Properti atau konten | Tujuan |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/alternativetexttitle/) | Judul singkat untuk deskripsi alternatif. |
| [AlternativeText](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/alternativetext/) | Deskripsi bermakna tentang konten atau tujuan bentuk dalam konteks slide. |
| [Name](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/name/) | Nama bentuk, yang dapat digunakan kode untuk menemukan bentuk tertentu dalam presentasi. |
| Teks yang terlihat | Konten yang ditampilkan pada slide, seperti teks bentuk atau judul dan label diagram. Memperbarui teks alternatif tidak mengubah konten ini. |

Ketika sebuah presentasi digunakan kembali sebagai templat, kode dapat menemukan bentuk melalui [Name](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/name/) sebelum memperbaruinya. Nama ini memiliki tujuan yang berbeda dari teks alternatif, yang menjelaskan apa yang disampaikan visual kepada pembaca. Pencarian berdasarkan nama memungkinkan penulis memperbaiki atau menerjemahkan deskripsi tanpa mengubah cara kode menemukan bentuk. Nama dapat diedit dan tidak dijamin unik, jadi pastikan nama tersebut cocok dengan bentuk yang dimaksud; lihat [Identifikasi dan Temukan Bentuk](/slides/id/net/shape-manipulations/#identify-and-find-shapes).

Contoh berikut memerlukan `input.pptx` dengan gambar pintu masuk kantor sebagai bentuk pertama pada slide pertama. Gambar tersebut tidak boleh ditandai sebagai dekoratif. Contoh ini membaca dan mencetak judul serta deskripsi teks alternatif saat ini, memperbarui kedua nilai, dan menyimpan presentasi sebagai `output.pptx`. Sesuaikan kata-kata dengan gambar sebenarnya dan informasi yang disampaikannya.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var shape = presentation.Slides[0].Shapes[0];

Console.WriteLine($"Alternative text title: {shape.AlternativeTextTitle}");
Console.WriteLine($"Alternative text description: {shape.AlternativeText}");

shape.AlternativeTextTitle = "Office entrance";
shape.AlternativeText = "The office entrance has a wheelchair ramp to the right of the steps.";

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Menambahkan teks alternatif saja tidak menjamin aksesibilitas presentasi atau kepatuhan terhadap standar aksesibilitas. Tinjau deskripsi untuk akurasi dan relevansi, serta periksa urutan membaca, kontras warna, keterbacaan teks, dan persyaratan aksesibilitas lainnya. Visual informatif tidak boleh ditandai sebagai dekoratif; bagian berikutnya menunjukkan cara membaca [IsDecorative](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/isdecorative/).

## **Tandai sebagai Dekoratif**

Tandai sebagai dekoratif menandai visual yang semata-mata ornamental agar pembaca layar melewatkannya, mengurangi kebisingan dan menjaga fokus pada konten yang berarti. Terapkan pada latar belakang, hiasan, dan pemisah—tidak pernah pada diagram, ikon, atau gambar yang menyampaikan informasi. Aspose.Slides menyediakan flag ini untuk deteksi dan validasi, memungkinkan pemeriksaan aksesibilitas otomatis dan pembersihan.

![Tandai sebagai Dekoratif](mark_as_decorative.png)

Potongan kode berikut menunjukkan cara menentukan apakah sebuah bentuk ditandai sebagai dekoratif.

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```

## **Tanya Jawab**

**Apa yang harus saya masukkan dalam judul dan deskripsi teks alternatif?**

Gunakan judul singkat untuk mengidentifikasi subjek dan deskripsi untuk menjelaskan informasi yang disampaikan visual dalam konteks slide. Untuk diagram, jelaskan tren atau perbandingan yang relevan alih‑alih hanya menyebut "diagram."

**Haruskah saya menggunakan teks alternatif untuk menemukan bentuk dalam templat?**

Lebih baik menemukan bentuk melalui [Name](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/name/) dan memastikan bahwa itu adalah bentuk yang diharapkan. Teks alternatif dapat diedit atau diterjemahkan, yang dapat memutus kode yang mencari deskripsi tepat; lihat [Identifikasi dan Temukan Bentuk](/slides/id/net/shape-manipulations/).

**Kapan sebuah bentuk harus ditandai sebagai dekoratif?**

Gunakan flag dekoratif untuk visual yang tidak menambah informasi, seperti hiasan ornamental. Gambar dan diagram yang menyampaikan makna memerlukan deskripsi yang sesuai sebagai gantinya.

**Apakah menambahkan teks alternatif membuat presentasi sepenuhnya dapat diakses?**

Tidak. Teks alternatif hanya menangani sebagian dari aksesibilitas. Tinjau juga urutan membaca, kontras warna, keterbacaan teks, dan persyaratan lain yang berlaku; mengatur properti‑properti ini saja tidak menjamin kepatuhan.