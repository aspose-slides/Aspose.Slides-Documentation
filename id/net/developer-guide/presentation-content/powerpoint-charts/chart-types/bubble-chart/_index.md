---
title: Sesuaikan Diagram Gelembung dalam Presentasi di .NET
linktitle: Diagram Gelembung
type: docs
url: /id/net/bubble-chart/
keywords:
- diagram gelembung
- ukuran gelembung
- skala ukuran
- representasi ukuran
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Buat dan sesuaikan diagram gelembung yang kuat di PowerPoint dengan Aspose.Slides untuk .NET guna meningkatkan visualisasi data Anda dengan mudah."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara bekerja dengan diagram gelembung di Aspose.Slides. Ini mencakup dua opsi penyesuaian khusus: mengatur skala ukuran gelembung melalui properti `BubbleSizeScale` dan mengontrol cara nilai ukuran gelembung direpresentasikan melalui properti `BubbleSizeRepresentation`.

Contoh-contoh memperlihatkan cara membuat diagram gelembung, menyesuaikan skala ukurannya, dan mengubah representasi ukuran gelembung untuk menggunakan lebar. Artikel ini juga menyertakan bagian FAQ singkat yang menjelaskan dukungan untuk tipe diagram “Bubble with 3-D”, mencatat bahwa batas praktis diagram tergantung pada kinerja dan versi PowerPoint target, serta menjelaskan bahwa ekspor mempertahankan tampilan diagram melalui mesin rendering Aspose.Slides.

## **Skala Ukuran Diagram gelembung**
Aspose.Slides for .NET menyediakan dukungan untuk skala ukuran diagram gelembung. Di Aspose.Slides for .NET **IChartSeries.BubbleSizeScale** dan **IChartSeriesGroup.BubbleSizeScale** telah ditambahkan. Contoh kode berikut diberikan.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```




## **Representasikan Data sebagai Ukuran Diagram gelembung**
Properti **BubbleSizeRepresentation** telah ditambahkan ke antarmuka IChartSeries, IChartSeriesGroup, dan kelas terkait. **BubbleSizeRepresentation** menentukan bagaimana nilai ukuran gelembung direpresentasikan dalam diagram gelembung. Nilai yang mungkin: **BubbleSizeRepresentationType.Area** dan **BubbleSizeRepresentationType.Width**. Oleh karena itu, enum **BubbleSizeRepresentationType** telah ditambahkan untuk menentukan cara-cara yang mungkin merepresentasikan data sebagai ukuran diagram gelembung. Kode contoh diberikan di bawah.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Apakah “diagram gelembung dengan efek 3-D” didukung, dan bagaimana perbedaannya dengan diagram biasa?**

Ya. Ada tipe diagram terpisah, “Bubble with 3-D.” Ini menerapkan gaya 3-D pada gelembung tetapi tidak menambah sumbu tambahan; data tetap X-Y-S (ukuran). Tipe ini tersedia dalam enumerasi [chart type](https://reference.aspose.com/slides/id/net/aspose.slides.charts/charttype/).

**Apakah ada batasan jumlah seri dan titik dalam diagram gelembung?**

Tidak ada batasan keras pada tingkat API; batasan ditentukan oleh kinerja dan versi PowerPoint target. Disarankan untuk menjaga jumlah titik tetap wajar demi keterbacaan dan kecepatan rendering.

**Bagaimana ekspor memengaruhi tampilan diagram gelembung (PDF, gambar)?**

Ekspor ke format yang didukung mempertahankan tampilan diagram; proses rendering dilakukan oleh mesin Aspose.Slides. Untuk format raster/vector, aturan umum rendering grafik diagram berlaku (resolusi, anti-aliasing), jadi pilih DPI yang cukup untuk pencetakan.