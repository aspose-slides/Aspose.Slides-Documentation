---
title: Sesuaikan Tabel Data Diagram dalam Presentasi di .NET
linktitle: Tabel Data
type: docs
url: /id/net/chart-data-table/
keywords:
- data diagram
- tabel data
- properti font
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Sesuaikan tabel data diagram di .NET untuk PPT dan PPTX dengan Aspose.Slides untuk meningkatkan efisiensi dan daya tarik dalam presentasi."
---
## **Ikhtisar**

Artikel ini menjelaskan cara bekerja dengan tabel data diagram di Aspose.Slides. Artikel ini menunjukkan cara menampilkan tabel data untuk diagram dan menyesuaikan pemformatan teksnya dengan mengatur properti font seperti gaya tebal dan tinggi font. Contoh ini mendemonstrasikan memuat presentasi, menambahkan diagram, mengaktifkan tabel data diagram, menerapkan pengaturan font, dan menyimpan presentasi yang diperbarui.

Artikel ini juga mencakup jawaban singkat untuk pertanyaan umum tentang menampilkan kunci legenda dalam tabel data diagram, mempertahankan tabel data saat mengekspor, bekerja dengan diagram yang dimuat dari presentasi atau templat yang ada, serta mengidentifikasi diagram di mana tabel data diaktifkan.

## **Atur Properti Font untuk Tabel Data Diagram**
Aspose.Slides untuk .NET menyediakan dukungan untuk mengubah warna kategori dalam warna seri. 

1. Instansiasi objek kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Tambahkan diagram pada slide.
1. Atur tabel diagram.
1. Atur tinggi font.
1. Simpan presentasi yang dimodifikasi.

Contoh contoh diberikan di bawah. 

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.HasDataTable = true;

	chart.ChartDataTable.TextFormat.PortionFormat.FontBold = NullableBool.True;
	chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 20;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Apakah saya dapat menampilkan kunci legenda kecil di sebelah nilai dalam tabel data diagram?**

Ya. Tabel data mendukung [legend keys](https://reference.aspose.com/slides/id/net/aspose.slides.charts/datatable/showlegendkey/), dan Anda dapat mengaktifkan atau menonaktifkannya.

**Apakah tabel data akan dipertahankan saat mengekspor presentasi ke PDF, HTML, atau gambar?**

Ya. Aspose.Slides merender diagram sebagai bagian dari slide, sehingga [PDF](/slides/id/net/convert-powerpoint-to-pdf/)/[HTML](/slides/id/net/convert-powerpoint-to-html/)/[image](/slides/id/net/convert-powerpoint-to-png/) yang diekspor menyertakan diagram dengan tabel datanya.

**Apakah tabel data didukung untuk diagram yang berasal dari file templat?**

Ya. Untuk setiap diagram yang dimuat dari presentasi atau templat yang ada, Anda dapat memeriksa dan mengubah apakah tabel data [is shown](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chart/hasdatatable/) menggunakan properti diagram.

**Bagaimana cara cepat menemukan diagram mana dalam file yang memiliki tabel data diaktifkan?**

Periksa properti setiap diagram yang menunjukkan apakah tabel data [is shown](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chart/hasdatatable/) dan iterasi melalui slide untuk mengidentifikasi diagram di mana tabel tersebut diaktifkan.